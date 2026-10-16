
//----------------------------------------------------------------------------

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = -2;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;
	groundDamageScale = 1.0;

	projectileType = whatever;
	reloadDelay = 2.0;
	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Scout";
};

function Scout::onAdd(%this)
{
	%this.shieldStrength = 1.0;
	%this.shieldMax = 1.0;
	Vehicle::rechargeShield(%this);
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
	%this.missiles = 10;
	%this.bullets = 500;
	%this.fireMode = Missiles;
}

function Scout::onFire(%this, %slot)
{
	if(%this.fireMode == Missiles) {
		if(GameBase::getLOSInfo(%this,500)) {
			%obj = getObjectType($los::object);
			if(Vector::getDistance(GameBase::getPosition(%this), $los::position) >= 25) {
				if (%obj == "Player" || %obj == "Flier")
					%target = %obj;
				if(%this.missiles > 0 && (%this.missileActive == false || %this.missileActive == "")) {
					if(%target)
						Projectile::spawnProjectile("TurretMissile",GameBase::getMuzzleTransform(%this),%this,Item::getVelocity(%this), %target);
					else
						Projectile::spawnProjectile("TurretMissile",GameBase::getMuzzleTransform(%this),%this,Item::getVelocity(%this));
					GameBase::playSound(%this, SoundFireFlierRocket,0);
					%this.missiles--;
					%this.missileActive = true;
					schedule(%this @".missileActive = false;", 5, %this);
					if(%this.missiles == 0) {
						%cl = GameBase::getControlClient(%this);
						Client::sendMessage(%cl,0,"Out of Missiles ~wLeftMissionArea.wav");
					}
					else if(%this.missiles < 3) {
						%cl = GameBase::getControlClient(%this);
						Client::sendMessage(%cl,0,"Missiles Available: "@ %this.missiles @" ~wLeftMissionArea.wav");
					}
				}
			}
		}
	}
	if(%this.fireMode == Chaingun) {
		if(%this.bullets > 0 && (%this.pausing == false || %this.pausing == "")) {
			Projectile::spawnProjectile("FlierBullet",GameBase::getMuzzleTransform(%this),%this,Item::getVelocity(%this));
			%this.bullets--;
			GameBase::playSound(%this, SoundFireMortar,1);
			%this.bulletCounter++;
			if(%this.bulletCounter == 10) {
				%this.bulletCounter = 0; 
				%this.pausing = true;
				schedule(%this @".pausing = false;", 0.5, %this);
			}
			if(%this.bullets == 0) {
				%cl = GameBase::getControlClient(%this);
				Client::sendMessage(%cl,0,"Out of Bullets ~wLeftMissionArea.wav");
			}			
			else if(%this.bullets < 500 && %this.bullets%100 == 0) {
				%cl = GameBase::getControlClient(%this);
				Client::sendMessage(%cl,0,"Bullets Available: "@ %this.bullets @" ~wLeftMissionArea.wav");
			}			
			else if(%this.bullets < 100 && %this.bullets%20 == 0) {
				%cl = GameBase::getControlClient(%this);
				Client::sendMessage(%cl,0,"Bullets Available: "@ %this.bullets @" ~wLeftMissionArea.wav");
			}			
		}
	}
}

FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;
	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "LPC";
};

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 25;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;


	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "HPC";
};


//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 1.0;
	%this.shieldMax = 1.0;
	Vehicle::rechargeShield(%this);
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") {
            if( Player::isAiControlled(%object) )
            	return;
		%armor = Player::getArmor(%object);
		%client = Player::getClient(%object);
		if (((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object)) || ((%armor != "sarmor" && %armor != "harmor") && GameBase::getDataName(%this) != Scout)) {
			%weapon = Player::getMountedItem(%object,$WeaponSlot);
			if(%weapon != -1) {
				%object.lastWeapon = %weapon;
				Player::unMountItem(%object,$WeaponSlot);
				}
			Player::setMountObject(%object, %this, 1);
			Client::setControlObject(%client, %this);
			playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
			%object.driver = 1;
			%object.vehicle = %this;
			%client.vehicle = %this;
			%this.clLastMount = %client;
			Vehicle::resupply(%object);
			if(GameBase::getDataName(%this) == Scout) {
				BottomPrint(Player::getClient(%object),"Missiles: "@ %this.missiles @" Bullets: "@ %this.bullets @" FireMode: "@ %this.fireMode);
				
			}
		}
		else if(GameBase::getDataName(%this) != Scout) {
		 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
			if(%mountSlot) {
				%object.vehicleSlot = %mountSlot;
				%object.vehicle = %this;
				Player::setMountObject(%object, %this, %mountSlot);
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				Vehicle::resupply(%object);
				}
			}
		else if (GameBase::getControlClient(%this) == -1)
			if(%armor == "harmor" || %armor == "sarmor")
				Client::sendMessage(Player::getClient(%object),0,"Heavy Armor types cannot pilot vehicles.~wError_Message.wav");
			else if((%armor != "harmor" && %armor != "sarmor") &&  GameBase::getDataName(%this) == Scout)
				Client::sendMessage(Player::getClient(%object),0,"Only Light Armor types can pilot Scouts.~wError_Message.wav");
			}
		}
}

function Vehicle::resupply(%this)
{
	%cnt = Station::itemsToResupply(%this);
	if (%cnt != 0) {
		schedule("Vehicle::resupply(" @ %this @ ");",8,%this);
		return;
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
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale" || %armor == "carmor") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor" || %armor == "sarmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}

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
				Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
				%client = Player::getClient(%pl);
				%client.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
	   %pl.vehicle= "";
		%client = Player::getClient(%pl);
		%client.vehicle = "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type != -1 && %this.shieldStrength) {
		%strength = %this.shieldStrength;
		if (%value <= %strength) {
			%thisPos = getBoxCenter(%this);
			%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
			GameBase::activateShield(%this,%vec,%offsetZ);
			%this.shieldStrength = %this.shieldStrength - %value;
			%value = 0;
		}
		else {
			%thisPos = getBoxCenter(%this);
			%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
			GameBase::activateShield(%this,%vec,%offsetZ);
			%value = %value - %strength;
		}
	}
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
  %cl = GameBase::getControlClient(%this);
  if(%cl != -1 && (%this.waiting == false || %this.waiting == "")) {
	Client::sendMessage(%cl,0,"Enemy Missile Lock~wLeftMissionArea.wav");
	%this.waiting = true;
	schedule(%this @".waiting = false;",2.0,%this);
	}
  return 1.0;
}


function Vehicle::rechargeShield(%vehicle)
{
	if(%vehicle.shieldStrength < %vehicle.shieldMax )  {
		%vehicle.shieldStrength = %vehicle.shieldStrength + (%vehicle.shieldMax * 0.1);
		if(%vehicle.shieldStrength > %vehicle.shieldMax) {
			GameBase::setEnergy(%vehicle, GameBase::getEnergy(%vehicle) - ((%vehicle.shieldMax * 0.1) - (%vehicle.shieldStrength - %vehicle.shieldMax)) * 100);
			%vehicle.shieldStrength = %vehicle.shieldMax;
		}
		else {
			GameBase::setEnergy(%vehicle, GameBase::getEnergy(%vehicle) - (%vehicle.shieldMax * 10));
		}
	}
	schedule("Vehicle::rechargeShield("@ %vehicle @");", 0.5, %vehicle);
}