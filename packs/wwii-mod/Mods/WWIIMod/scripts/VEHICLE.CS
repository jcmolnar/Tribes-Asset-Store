//-------------------------------
function Vehicle::onAdd(%this, %nospawn)
{
	
	
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
	%this.spawnpos = GameBase::getPosition(%this);
	%this.spawnrot = GameBase::getRotation(%this);
	%this.weaponmode = 0; //0 Gun 1 Bomb
	if(string::findsubstr(gamebase::getdataname(%this), "Tank") != -1) { }
	else schedule("Plane::Loop(" @ %this @ ");",0.2);
	 if(%nospawn != 1) schedule(gamebase::getdataname(%this) @ "::onAdd(" @ %this @ ");", 0.3); 
}

function Vehicle::onCollision (%this, %object)
{
if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) 
{
if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
{
//if( Player::isAiControlled(%object) ) return;
               
%cl = player::getclient(%object);
if(!(gamebase::getcontrolclient(%this) > 2048))
	{
	player::setmountobject(%object, %this, 1);
	client::setcontrolobject(%cl, %this);
	%object.vehicle = %this;
	%this.lastcontrolobject = %object;
	%object.newmounttime = getsimtime() + 3;
	}

else    {			
	
	%vec = item::getvelocity(%this);
	%v1 = getword(%vel, 0);
	%v2 = getword(%vel, 1);
	%v3 = getword(%vel, 2);
	%speed1 = vector::getdistance(%vec, "0 0 0");
	if(%speed1 < 2) return; //fix the bug so we don't get hurt from running into tanks - by tanks.
	
	%vec = item::getvelocity(%object);
	%v1 = getword(%vel, 0);
	%v2 = getword(%vel, 1);
	%v3 = getword(%vel, 2);
	%speed2 = sqrt(%v1*%v1 + %v2*%v2 + %v3*%v3);
	if(%speed1-%speed2 >= 5)
		{
		
		%vehiclevector = vector::normalize(item::getvelocity(%this));
		%playervector = Muzzle::GetAim(%object);
		%alpha = getanglebetweenvectors(%vehiclevector, %playervector);
		if(%alpha < 60) %m = 35;
		if(%alpha > 120) %m = 33;
		else %m = randomitems("33 35",2);
		player::setanimation(%object, %m);	
		player::kill(%object);
		Client::onKilled(%cl, gamebase::getcontrolclient(%this), $tankcrush);
		item::setvelocity(%object, vector::add(vector::add(item::getvelocity(%this), vector::multiply(%vehiclevector, "4 4 4")), "0 0 0.5")); //Elastic impact :-D
		
		}


}	
}
}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1) {
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++) {
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") {
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   %passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
if(%this.controlcorrupt == 1 && getrandom() < 0.3) return;   
if(%this.controlcorrupt == 2 && getrandom() < 0.6) return; 
if(%this.controlcorrupt == 3) return;  //hehehe
Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
		   // dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 	Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				//Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
%this.isGone = 1;
  %cl = GameBase::getControlClient(%this);
	if(%cl > 2048) %pl = %this.lastcontrolobject;
	else %pl = -1;
echo("---VEHICLE DIED. id: " @ %this @ " killer: " @ %this.lastdamageobject);
if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
	   %pl.vehicle= "";
	}
	client::setcontrolobject(%cl, client::getobservercamera(%cl)); observer::setorbitobject(%cl, %this, 10,10,10); 
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	player::blowUp(%pl);
	player::kill(%pl);
	Client::onKilled(%cl, player::getclient(%this.lastdamageobject), %this.lastdamagetype);
		
	calcRadiusDamage(%this, $ImpactDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
	//if($fds == 1) return; else $fds = 1;
	schedule("Vehicle::Respawn(\"" @ %this.spawnpos @ "\",\"" @ %this.spawnrot @ "\"," @ GameBase::getDataName(%this) @ ");", $WWII::RespawnDelay);
	schedule("deleteobject(" @ %this @ ");", 15);
	GameBase::playsound(%this, debrisLargeExplosion, 3);
	for(%x = 0; %x < getnumwords($WWII::TankList); %x++)
		{
		if(getword($WWII::TankList, %x) != %this) %newlist = %newlist @ getword($WWII::TankList, %x) @ " ";
		}
	$WWII::TankList = %newlist;
	if(isObject(%this.shturman)) deleteobject(%this.shturman);
	eval(gamebase::getdataname(%this) @ "::isDestroyed(" @ %this @ ");");
	schedule("playercheck();", 0.3);
}	

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object,%delay)
{
//trace();
if(%delay == "") 
	{
	schedule("Vehicle::onDamage(" @ %this @ "," @ %type @ "," @ %value @ ",\"" @ %pos @ "\",\"" @ %vec @ "\",\"" @ %mom @ "\"," @ %object @ ",1);", getrandom()/7, %this);
	return;
	}
if(%value == 0) %value = 0.05;
%datablock = GameBase::getDataName(%this);
%dlevel = gamebase::getdamagelevel(%this);
%maxdamage = %datablock.maxdamage;
//if(%dlevel+0.05 >= %maxdamage) return; //Why would I ever do that?
if(%dlevel + %value > %maxdamage) %value = %maxdamage;
%this.lastdamageobject = %object;
%this.lastdamagetype = %type;
eval(%datablock @ "::isDamage(" @ %this @ ", " @ %type @ " ," @ %value @ ");");

}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}


function Vehicle::Respawn(%pos, %rot, %datablock)
{
%obj = newObject(%datablock,"Flier", %datablock );
%obj.respawned = 1;
addToSet("MissionCleanup", %obj);
GameBase::setPosition(%obj, %pos);
GameBase::SetRotation(%obj, %rot);

}

function Vehicle::SwitchWeapon(%cl)
{
%pl = Client::getOwnedObject(%cl);
%this = %pl.vehicle;
%this.weaponmode = !%this.weaponmode;
}

function playercheck()
{
for(%x = 8000; %x < 10000; %x++)
	if(isObject(%x))
		if(getobjecttype(%x) == "Player")
			if(player::getitemcount(%x, repairkit) == 0)
				if(%x.isvehicle && (!isObject(%x.pidar) || %x.pidar.isGone == 1)) deleteobject(%x); 
				

}		