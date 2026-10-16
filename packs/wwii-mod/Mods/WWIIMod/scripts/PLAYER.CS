$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;

//----------------------------------------------------------------------------
$CorpseTimeoutValue = 22;
//----------------------------------------------------------------------------

// Player & Armor data block callbacks

function Player::onAdd(%this)
{
	GameBase::setRechargeRate(%this,8);

schedule("animcheck(" @ %this @ ");", 0.3);


}
function animcheck(%this)
{
%group = getgroup(%this);
if(%group == nametoid("MissionGroup\\Dead")) 
	{
	player::kill(%this);
	player::setanimation(%this, 26+floor(getrandom()*10));
	}
}

function Player::onRemove(%this)
{
	// Drop anything left at the players pos
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			// Note: Player::dropItem ius not called here.
			%item = newObject("","Item",%type,1,false);
         schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);

         addToSet("MissionCleanup", %item);
			GameBase::setPosition(%item,GameBase::getPosition(%this));
		}
	}
}

function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
%cl = player::getClient(%player);
%playerweapon = %itemType;
if(%playerweapon == "exppack") 
	{
	player::unmountitem(%player, $weaponslot);
	player::mountitem(%player, detonator, $weaponslot);
	return;
	}
if(player::getitemcount(%player, $Clip[%playerweapon]) > 0) Player::useitem(%player, $Clip[%playerweapon]);
else bottomprint(%cl, "<jc>Out Of Clips/Charges", 4,RELOAD); 
}

function Player::onKilled(%this)
{
	if(gamebase::getteam(%this) < 0) return;
//	WWII::RealityDeath(%this);
	%isAI = player::isAIcontrolled(%this);
	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;
	if(!player::isAiControlled(%this)) if(%this.equipment == "") %this.equipment = %cl.spawnclass;
	schedule("cleardynamites(" @ %this @ ");", 1); //clear shit up...
	if(%isAi && $SmartBoton) { $Ai::Int[$Ai::IdToName[%cl]] = "I am dead"; }
	
	if(%this.outArea==1)	
		leaveMissionAreaDamage(%cl);
	if(%this.stimpack != 1) Player::setDamageFlash(%this,0.75);
	for (%i = 0; %i < 8; %i = %i + 1) {
		%type = Player::getMountedItem(%this,%i);
		if (%type != -1) {
			if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.2") 
				Player::dropItem(%this,%type);
		}
	}

   if(%cl != -1)
   {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
        	 	//Client::setControlObject(Player::getClient(%this), %this);
        	 	 Player::setMountObject(%this, -1, 0);
			}
			else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";		
		}
     // if(%isai) schedule("GameBase::startFadeOut(" @ %this @ ");", 36, %this);
      if(client::getcontrolobject(%cl) != %this) Client::setControlObject(%cl, Client::getObserverCamera(%cl));
	if(floor(getrandom()*5) > 2) { } //Client::setOwnedObject(%cl, -1);
     else { Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
	 }
      if(!(%isai && $Game::MissionType != "Conquest")) schedule("deleteObject(" @ %this @ ");", 40, %this);
      if(%this.specialbot == 1) schedule("deleteObject(" @ %this @ ");", 40, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
%cl.trigger = 0;
schedule("game::spawninterface(" @ %cl @ ");", 2);
schedule("Client::setOwnedObject(" @ %cl @ ", -1);", 1.4);
}

//===========================================================================================================
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object,%forcedanim)
{
if(getobjecttype(%object) == "Flier") {  Vehicle::onCollision (%object, %this); return; }
if(Player::isDead(%this)) return; //BUG FIX
%s = player::getmountobject(%this); if(isobject(%s) && getobjecttype(%s) == "Flier") return;  
	if (1) {
	//if(%type <= 0 && %this.stimpack == 1) %value *= 0.7;
	if(%type <= 0 && %value > 1.5) player::blowup(%this);
	 if(player::iscrouching(%this)) %value *= 0.65;
	if(player::getarmor(%this) == "CrouchingDude") %value *= 0.65;
	%damagedClient = Player::getClient(%this);
	if(%this.client != "") %damagedclient = %this.client;
	if(%damagedclient.dead || %damagedclient.frozen) return;
     if(Player::isAiControlled(%this)) { $Ai::Int[$Ai::IdToName[%damagedclient]] = "I was damaged by: " @ %object @ " val: " @ %value @ " type: " @ %type; } 
	 %shooterClient = %object;
		if(%damagedclient.jailed) return;
		Player::applyImpulse(%this,%mom);	

		if (!Player::isDead(%this)) {
			%armor = Player::getArmor(%this);
			//More damage applyed to head shots
			if(%vertPos == "head") {
				    if(getrandom() > 0.667) client::sendmessage(%shooterclient, 2, "~whs.wav");
					%value *= 1.6;     //160% damage to head shots!!!
				}
			}
if(getdamagetype(%type) != other) WWII::Blood(%this, %value, %pos, %vec, (getdamagetype(%type) == "exp"));  			

if(getdamagetype(%type) == exp) WWII::ScreenShake(%this, %value/3);			
  			if (%value) {
			if(%type == $AiMine && getrandom() > 0.4) %value = 2;	
            %dlevel = GameBase::getDamageLevel(%this) + %value;
            %spillOver = %dlevel - %armor.maxDamage;
				if((%this.parachute && %type > 0) || !%this.parachute) { GameBase::setDamageLevel(%this,%dlevel);
				 %flash = Player::getDamageFlash(%this) + %value * 2; }
				if (%flash > 0.45) 
					%flash = 0.95;
				if(%this.stimpack != 1) Player::setDamageFlash(%this,%flash);
				//If player not dead then play a random hurt sound
				if(!Player::isDead(%this)) { 
					if(%damagedClient.lastDamage < getSimTime()) {
						if(%value > 0.4 && %value < 1.0 && !%this.parachute) gamebase::playsound(%this, SoundPlayerDeath, 3);
						%damagedClient.lastdamage = getSimTime() + 2.1;
					}
				}
				else { 
               if(%value > 1.0 && getdamagetype(%type) == exp) {
		 				Player::trigger(%this, $WeaponSlot, false);
						%weaponType = Player::getMountedItem(%this,$WeaponSlot);
						if(%weaponType != -1)
							Player::UnmountItem(%this, $weaponSlot);
                	Player::blowUp(%this); if(Player::isAiControlled(%this)) schedule("deleteobject(" @ %this @ ");",20);
				
					}
					else
					{
						if ((%value > 0.40 && getdamagetype(%type) == "exp") || (Player::getLastContactCount(%this) > 6) || %vertpos == "tank") { 
					  		if(%quadrant == "front_left" || %quadrant == "front_right" || %quadrant == 33) 
								%curDie = $PlayerAnim::DieBlownBack;
							else
								%curDie = $PlayerAnim::DieGrabBack;
							if(%quadrant == 35) %curDie = $PlayerAnim::DieForward;
						}
						
						
						else if( Player::isCrouching(%this) ) 
							%curDie = $PlayerAnim::Crouching;							
						else if(%vertPos=="head") {
							if(%quadrant == "front_left" ||	%quadrant == "front_right"	) 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
						  	else 
								%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
						}
						else if (%vertPos == "torso") {
							if(%quadrant == "front_left" ) 
								%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "front_right") 
								%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
							else if(%quadrant == "back_left" ) 
								%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
							else if(%quadrant == "back_right") 
								%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
						}
						else if (%vertPos == "legs") {
							if(%quadrant == "front_left" ||	%quadrant == "back_left") 
								%curDie = $PlayerAnim::DieLegLeft;
							if(%quadrant == "front_right" ||	%quadrant == "back_right") 
								%curDie = $PlayerAnim::DieLegRight;
						}
						if(!%this.parachute) 
							{
							
							if(%curdie < 33 && %curdie > 25 || %curdie == 35 || %curdie == 36) WWII::RealityDeath(%this, %curdie);
							if(%forcedanim > 0) player::setanimation(%this, %forcedanim);
							else if(%curdie != "") Player::setAnimation(%this, %curDie);
							else Player::setAnimation(%this, $PlayerAnim::DieGrabBack);
					}		}
					//if(%type == $ImpactDamageType && %object.clLastMount != "")  
						//%shooterClient = %object.clLastMount;
					
					Client::onKilled(%damagedClient,%shooterClient, %type);
				}
			}
		}
	
if (!Player::isDead(%this)) { if(%value > 0.4) Player::setAnimation(%damagedclient, 15); }
if(%pl.heartbeat != 1) WWII::DamageEffect(%this);
if(!player::isdead(%object) && Client::GetGuiMode(%shooterclient) == $GuiModePlay && %shooterclient.hasXhair && %damagedClient != %shooterclient && %type > 0) remoteeval(%shooterclient, XHit);
}
//----------------------------------------------------------------------------------------------------

function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
	return %an[floor(getRandom() * (%num - 0.01))];
}

function Player::onCollision(%this,%object)
{
%cl = player::getclient(%this);
if(%cl.scoutspecial == "cactus" && getobjecttype(%object) == "Player" && !Player::isDead(%object) && player::getmounteditem(%this, 2) == cactuscamo)
	{
	%pos = vector::multiply(vector::add(getboxcenter(%this), getboxcenter(%object)), "0.5 0.5 0.5");
	%vec = vector::normalize(vector::sub(getboxcenter(%object), getboxcenter(%this)));
	%deltaspeed = vector::sub(item::getvelocity(%this), item::getvelocity(%object));
	%impactspeed = vector::getdistance(%deltaspeed, "0 0 0"); 
	Player::onDamage(%object, $Cactus, 0.3*%impactspeed, %pos, %vec, 0, 0, 0, %cl); 
	gamebase::playsound(%object, SoundStabHuman);
	}
if(getobjecttype(%object) == "Player")
	{
	//echo("--COLISSION");
	//echo(%this, " was hit by " @ %object);
	//%this is the one who 'got hit'
	//100% elastic impact. Asume all masses are even, then U1 = V2 (switch speeds)
	%vel1 = item::getvelocity(%this);
	%vel2 = item::getvelocity(%object);
	//echo(%this, " vel: ", %vel1);
	//echo(%object, " vel: ", %vel2);
	%U1x = getword(%vel2, 0);
	%U1y = getword(%vel2, 1);
	%U1z = getword(%vel2, 2);
	%Impulse = %U1x @ " " @ %U1y @ " " @ %U1z;
	%impulse = vector::add(%impulse, "0 0 0.2");
	item::setvelocity(%this, %Impulse); //apply impulse won't work here.
	//echo(%this, " final boost: ", %impulse);
	}

}

function Player::getHeatFactor(%this)
{
	// Hack to avoid turret turret not tracking vehicles.
	// Assumes that if we are not in the player we are
	// controlling a vechicle, which is not always correct
	// but should be OK for now.
	%client = Player::getClient(%this);
	if (Client::getControlObject(%client) != %this)
		return 1.0;

   %time = getIntegerTime(true) >> 5;
   %lastTime = Player::lastJetTime(%this) >> 10;

   if ((%lastTime + 1.5) < %time) {
      return 0.0;
   } else {
      %diff = %time - %lastTime;
      %heat = 1.0 - (%diff / 1.5);
      return %heat;
   }
}

function Player::jump(%this,%mom)
{





//else player::applyimpulse(%this
}


//----------------------------------------------------------------------------

function remoteKill(%client)
{
if($WWII::TraceClients) %client.remotecall++;
if(%client.jailed) return;
if(%client.frozen) return;
   if(!$matchStarted)
      return;

   %player = Client::getOwnedObject(%client);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
   {
		playNextAnim(%client);
	   Player::kill(%client);
	   Client::onKilled(%client,%client);
		if($animnumber-1 < 33 && $animnumber-1 > 25) WWII::RealityDeath(%client, $animnumber-1);
   }
}

$animNumber = 25;	 
function playNextAnim(%client)
{
	if($animNumber > 36) 
		$animNumber = 25;		
	if(!client::getownedobject(%client).parachute) Player::setAnimation(%client,$animNumber);
	$animnumber++;
}
function Client::takeControl(%clientId, %objectId)
{
   // remote control
   if(%objectId == -1)
   {
      //echo("objectId = " @ %objectId);
      return;
   }

	%pl = Client::getOwnedObject(%clientId);
	// If mounted to a vehicle then can't mount any other objects
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;

   if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
   {
      //echo(GameBase::getTeam(%objectId) @ " " @ Client::getTeam(%clientId));
      return;
   }
   if(GameBase::getControlClient(%objectId) != -1)
   {
      echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
      return;
   }
	%name = GameBase::getDataName(%objectId);
	if(%name != CameraTurret && %name != DeployableTurret)
   {
	   if(!GameBase::isPowered(%objectId)) 
		{
	      // echo("Turret " @ %objectId @ " not powered.");
	      return;
		}
   }
   if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
      !$TestCheats) {
		Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
   		return;
   }
   if(GameBase::getDamageState(%objectId) == "Enabled") {
   	Client::setControlObject(%clientId, %objectId);
   	Client::setGuiMode(%clientId, $GuiModePlay);
	}
}

function remoteCmdrMountObject(%clientId, %objectIdx)
{
if($WWII::TraceClients) %clientId.remotecall++;
   //Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}

function checkControlUnmount(%clientId)
{
   %ownedObject = Client::getOwnedObject(%clientId);
   %ctrlObject = Client::getControlObject(%clientId);
   if(%ownedObject != %ctrlObject)
   {
      if(%ownedObject == -1 || %ctrlObject == -1)
         return;
      if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
         return;
      Client::setControlObject(%clientId, %ownedObject);
   }
}

function WWII::StripSoldier(%stripper, %deadguy)
{
%targetclass = %deadguy.equipment; if(%targetclass == "" || %targetclass == false) return;
%myclass = player::getclient(%stripper).spawnclass;
if(%stripper.equipment != "") %myclass = %stripper.equipment;
if(player::getitemcount(%stripper, ypistol) > 0) %myteam = 0;  else %myteam = 1;
if(player::getitemcount(%deadguy, ypistol) > 0) %histeam = 0; else %histeam = 1;
//empty your weapons, then take everything from body
player::unmountitem(%stripper, $weaponslot); %list = "";
if(%myteam == 0) 
	{ 
	%list = %list @ "ypistol ypistolammo secweapclip ";
	%list = %list @ "exppack exppackammo detonator detonatorammo ";
	%list = %list @ "nade nadeammo ";
	%weap = $Weapon[%myclass, $country[0]];
	%list = %list @ %weap @ " " @ $clip[%weap] @ " " @ $ammo[%weap] @ " ";
	%list = %list @ "medicalkit medicalkitammo binoculars deploymine deploymineammo xgrifle ";
	}
else if(%myteam == 1) 
	{ 
	%list = %list @ "xpistol xpistolammo secweapclip ";
	%list = %list @ "exppack exppackammo detonator detonatorammo ";
	%list = %list @ "nade nadeammo ";
	%weap = $Weapon[%myclass, $country[1]];
	%list = %list @ %weap @ " " @ $clip[%weap] @ " " @ $ammo[%weap] @ " ";
	%list = %list @ "medicalkit medicalkitammo binoculars deploymine deploymineammo xgrifle ";
	}
for(%x = 0; %x < getnumwords(%list); %x++) player::setitemcount(%stripper, getword(%list, %x), 0);
//----------------------------------------------------------------------
%list = "";
if(%histeam == 0) 
	{ 
	%list = %list @ "ypistol ypistolammo secweapclip ";
	%list = %list @ "exppack exppackammo detonator detonatorammo ";
	%list = %list @ "nade nadeammo ";
	%weap = $Weapon[%targetclass, $country[0]];
	%list = %list @ %weap @ " " @ $clip[%weap] @ " " @ $ammo[%weap] @ " ";
	%list = %list @ "medicalkit medicalkitammo binoculars deploymine deploymineammo xgrifle ";
	}
else if(%histeam == 1) 
	{ 
	%list = %list @ "xpistol xpistolammo secweapclip ";
	%list = %list @ "exppack exppackammo detonator detonatorammo ";
	%list = %list @ "nade nadeammo "; 
	%weap = $Weapon[%targetclass, $country[1]];
	%list = %list @ %weap @ " " @ $clip[%weap] @ " " @ $ammo[%weap] @ " ";
	%list = %list @ "medicalkit medicalkitammo binoculars deploymine deploymineammo xgrifle ";
	}
//echo(%list);
for(%x = 0; %x < getnumwords(%list); %x++) player::setitemcount(%stripper, getword(%list, %x), player::getitemcount(%deadguy,getword(%list,%x)));
for(%x = 0; %x < getnumwords(%list); %x++) player::setitemcount(%deadguy, getword(%list, %x), 0);
%stripper.equipment = %targetclass;
%deadguy.equipment = "";
if(%myteam == %histeam) player::mountitem(%stripper, $weapon[%targetclass, $country[%myteam]], $weaponslot);
else player::mountitem(%stripper, $weapon[%targetclass, $country[%histeam]], $weaponslot);
client::setskin(player::getclient(%stripper), client::getskinbase(player::getclient(%deadguy)));
}

function WWII::DamageEffect(%pl)
{
%dlevel = GameBase::GetDamageLevel(%pl);
%armor = player::getArmor(%pl);
%maxdamage = %armor.maxdamage;

%percent = %dlevel/%maxdamage;
if(%percent > 0.88)
	{
	%pl.heartbeat = 1;
	client::sendmessage(player::getClient(%pl), 1, "~wmfootlsnow.wav");
	schedule("client::sendmessage(" @ player::getClient(%pl) @ ", 1, \"~wmfootlsnow.wav\");", 0.3, %pl);
	schedule("WWII::DamageEffect(" @ %pl @ ");", 1.06,%pl);
	}
else %pl.heartbeat = 0;
}
