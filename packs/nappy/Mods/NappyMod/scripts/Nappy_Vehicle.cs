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
   maxBank = 0.8; 
   maxPitch = 0.8; 
   maxSpeed = 125; 
   minSpeed = -2; 
   lift = 0.75; 
   maxAlt = 350; 
   maxVertical = 10; 
   maxDamage = 1.65; 
   damageLevel = {1.0, 1.0}; 
   maxEnergy = 100; 
   accel = 0.9; 
   groundDamageScale = 1.0; 
   projectileType = FlierMissile; 
   reloadDelay = 0.7; 
   repairRate = 1; 
   fireSound = SoundFireFlierRocket; 
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


FlierData Jet 
{ 
   explosionId = flashExpLarge; 
   debrisId = flashDebrisLarge; 
   className = "Vehicle"; 
   shapeFile = "flyer"; 
   shieldShapeName = "shield_medium"; 
   mass = 9.0; 
   drag = 1.0; 
   density = 1.2; 
   maxBank = 0.7; 
   maxPitch = 9.7; 
   maxSpeed = 160; 
   minSpeed = -2; 
   lift = 0.99; 
   maxAlt = 2500; 
   maxVertical = 360; 
   maxDamage = 1.6; 
   damageLevel = {1.0, 1.0}; 
   maxEnergy = 100; 
   accel = 1.8; 
   groundDamageScale = 1.0; 
   projectileType = JetBullet; 
   reloadDelay = 0.025; 
   repairRate = 0; 
   damageSound = SoundFlierCrash; 
   ramDamage = 1.5; 
   ramDamageType = -1; 
   mapFilter = 2; 
   mapIcon = "M_vehicle"; 
   visibleToSensor = true; 
   shadowDetailMask = 2; 
   fireSound = SoundFireMortar; 
   mountSound = SoundFlyerMount; 
   dismountSound = SoundFlyerDismount; 
   idleSound = SoundFlyerIdle; 
   moveSound = SoundFlyerActive; 
   visibleDriver = true; 
   driverPose = 22; 
	description = "Jet";
}; 

FlierData Wraith 
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
   maxAlt = 350; 
   maxVertical = 10; 
   maxDamage = 0.5; 
   damageLevel = {1.0, 1.0}; 
   maxEnergy = 100; 
   accel = 0.4; 
   groundDamageScale = 1.0; 
   reloadDelay = 0.1; 
   repairRate = 0; 
   fireSound = SoundFireFlierRocket; 
   damageSound = SoundFlierCrash; 
   ramDamage = 1.5; 
   ramDamageType = -1; 
   mapFilter = 2; 
   mapIcon = "M_vehicle"; 
   visibleToSensor = false; 
   shadowDetailMask = 2; 
   mountSound = SoundFlyerMount; 
   dismountSound = SoundFlyerDismount; 
   idleSound = SoundFlyerIdle; 
   moveSound = SoundFlyerActive; 
   visibleDriver = false; 
   driverPose = 22; 
	description = "Wraith";
}; 


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
   maxBank = 0.5; 
   maxPitch = 0.7; 
   maxSpeed = 70; 
   minSpeed = -1; 
   lift = 0.5; 
   maxAlt = 350; 
   maxVertical = 9; 
   maxDamage = 7.5; 
   damageLevel = {1.0, 1.0}; 
   destroyDamage = 1.0; 
   maxEnergy = 100; 
   accel = 0.55; 
   groundDamageScale = 0.50; 
   repairRate = 0; 
   ramDamage = 2; 
   ramDamageType = -1; 
   mapFilter = 2; 
   mapIcon = "M_vehicle"; 
   projectileType = MortarShell; 
   fireSound = SoundFireMortar; 
   reloadDelay = 4.0; 
   damageSound = SoundTankCrash; 
   visibleToSensor = true; 
   shadowDetailMask = 2; 
   mountSound = SoundFlyerMount; 
   dismountSound = SoundFlyerDismount; 
   idleSound = SoundFlyerIdle; 
   moveSound = SoundFlyerActive; 
   visibleDriver = true; 
   driverPose = 23; 
	description = "LAPC";
}; 


FlierData HAPC 
{ 
   explosionId = flashExpLarge; 
   debrisId = flashDebrisLarge; 
   className = "Vehicle"; 
   shapeFile = "hover_apc"; 
   shieldShapeName = "shield_large"; 
   mass = 18.0; drag = 1.0; 
   density = 1.2; 
   maxBank = 0.5; 
   maxPitch = 0.6; 
   maxSpeed = 55; 
   minSpeed = -1; 
  lift = 0.75; 
   maxAlt = 350; 
   maxVertical = 6; 
   maxDamage = 10.0; 
   damageLevel = {1.0, 1.0}; 
   maxEnergy = 100; 
   accel = 0.35; 
   groundDamageScale = 0.125; 
   repairRate = 0; 
   ramDamage = 2; 
   ramDamageType = -1; 
   mapFilter = 2; 
   mapIcon = "M_vehicle"; 
   fireSound = SoundFireFlierRocket; 
   reloadDelay = 3.0; 
   damageSound = SoundTankCrash; 
   visibleToSensor = false; 
   shadowDetailMask = 2; 
   mountSound = SoundFlyerMount; 
   dismountSound = SoundFlyerDismount; 
   idleSound = SoundFlyerIdle; 
   moveSound = SoundFlyerActive; 
   visibleDriver = true; 
   driverPose = 23; 
	description = "HAPC";
};




$DamageScale[Scout, $ImpactDamageType] = 1.0; 
$DamageScale[Scout, $BulletDamageType] = 1.0; 
$DamageScale[Scout, $PlasmaDamageType] = 1.0; 
$DamageScale[Scout, $EnergyDamageType] = 1.0; 
$DamageScale[Scout, $ExplosionDamageType] = 1.0; 
$DamageScale[Scout, $ShrapnelDamageType] = 1.0; 
$DamageScale[Scout, $DebrisDamageType] = 1.0; 
$DamageScale[Scout, $MissileDamageType] = 1.0; 
$DamageScale[Scout, $LaserDamageType] = 1.0; 
$DamageScale[Scout, $MortarDamageType] = 1.0; 
$DamageScale[Scout, $BlasterDamageType] = 0.5; 
$DamageScale[Scout, $ElectricityDamageType] = 1.0; 
$DamageScale[Scout, $MineDamageType] = 1.0; 
$DamageScale[Scout, $SniperDamageType] = 1.0; 
$DamageScale[Scout, $FlashDamageType] = 1.0; 
$DamageScale[Scout, $PoisonDamageType] = 1.0; 
$DamageScale[Scout, $FireDamageType] = 1.0; 
$DamageScale[Scout, $ShockDamageType] = 1.0;
$DamageScale[Scout, $AntiAirDamageType] = 1.0;

$DamageScale[Jet, $ImpactDamageType] = 1.0; 
$DamageScale[Jet, $BulletDamageType] = 1.0; 
$DamageScale[Jet, $PlasmaDamageType] = 1.0; 
$DamageScale[Jet, $EnergyDamageType] = 1.0; 
$DamageScale[Jet, $ExplosionDamageType] = 1.0; 
$DamageScale[Jet, $ShrapnelDamageType] = 1.0; 
$DamageScale[Jet, $DebrisDamageType] = 1.0; 
$DamageScale[Jet, $MissileDamageType] = 1.0; 
$DamageScale[Jet, $LaserDamageType] = 1.0; 
$DamageScale[Jet, $MortarDamageType] = 1.0; 
$DamageScale[Jet, $BlasterDamageType] = 0.5; 
$DamageScale[Jet, $ElectricityDamageType] = 1.0; 
$DamageScale[Jet, $MineDamageType] = 1.0; 
$DamageScale[Jet, $SniperDamageType] = 1.0; 
$DamageScale[Jet, $FlashDamageType] = 1.0; 
$DamageScale[Jet, $PoisonDamageType] = 1.0; 
$DamageScale[Jet, $FireDamageType] = 1.0; 
$DamageScale[Jet, $ShockDamageType] = 1.0;
$DamageScale[Jet, $AntiAirDamageType] = 1.0;

$DamageScale[Wraith, $ImpactDamageType] = 1.0; 
$DamageScale[Wraith, $BulletDamageType] = 1.0; 
$DamageScale[Wraith, $PlasmaDamageType] = 1.0; 
$DamageScale[Wraith, $EnergyDamageType] = 1.0; 
$DamageScale[Wraith, $ExplosionDamageType] = 1.0; 
$DamageScale[Wraith, $ShrapnelDamageType] = 1.0; 
$DamageScale[Wraith, $DebrisDamageType] = 1.0; 
$DamageScale[Wraith, $MissileDamageType] = 1.0; 
$DamageScale[Wraith, $LaserDamageType] = 1.0; 
$DamageScale[Wraith, $MortarDamageType] = 1.0; 
$DamageScale[Wraith, $BlasterDamageType] = 0.5; 
$DamageScale[Wraith, $ElectricityDamageType] = 1.0; 
$DamageScale[Wraith, $MineDamageType] = 1.0; 
$DamageScale[Wraith, $SniperDamageType] = 1.0; 
$DamageScale[Wraith, $FlashDamageType] = 1.0; 
$DamageScale[Wraith, $PoisonDamageType] = 1.0; 
$DamageScale[Wraith, $FireDamageType] = 1.0; 
$DamageScale[Wraith, $ShockDamageType] = 1.0;
$DamageScale[Wraith, $AntiAirDamageType] = 1.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0; 
$DamageScale[LAPC, $BulletDamageType] = 1.0; 
$DamageScale[LAPC, $PlasmaDamageType] = 1.0; 
$DamageScale[LAPC, $EnergyDamageType] = 1.0; 
$DamageScale[LAPC, $ExplosionDamageType] = 1.0; 
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0; 
$DamageScale[LAPC, $DebrisDamageType] = 1.0; 
$DamageScale[LAPC, $MissileDamageType] = 1.0; 
$DamageScale[LAPC, $LaserDamageType] = 0.5; 
$DamageScale[LAPC, $MortarDamageType] = 0.7; 
$DamageScale[LAPC, $BlasterDamageType] = 0.5; 
$DamageScale[LAPC, $ElectricityDamageType] = 1.0; 
$DamageScale[LAPC, $MineDamageType] = 1.0; 
$DamageScale[LAPC, $SniperDamageType] = 1.0; 
$DamageScale[LAPC, $FlashDamageType] = 1.0; 
$DamageScale[LAPC, $PoisonDamageType] = 1.0; 
$DamageScale[LAPC, $FireDamageType] = 1.0; 
$DamageScale[LAPC, $ShockDamageType] = 1.0;
$DamageScale[LAPC, $AntiAirDamageType] = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0; 
$DamageScale[HAPC, $BulletDamageType] = 1.0; 
$DamageScale[HAPC, $PlasmaDamageType] = 1.0; 
$DamageScale[HAPC, $EnergyDamageType] = 1.0; 
$DamageScale[HAPC, $ExplosionDamageType] = 1.0; 
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0; 
$DamageScale[HAPC, $DebrisDamageType] = 1.0; 
$DamageScale[HAPC, $MissileDamageType] = 1.0; 
$DamageScale[HAPC, $LaserDamageType] = 0.5; 
$DamageScale[HAPC, $MortarDamageType] = 1.0; 
$DamageScale[HAPC, $BlasterDamageType] = 0.5; 
$DamageScale[HAPC, $ElectricityDamageType] = 1.0; 
$DamageScale[HAPC, $MineDamageType] = 1.0; 
$DamageScale[HAPC, $SniperDamageType] = 1.0; 
$DamageScale[HAPC, $FlashDamageType] = 1.0; 
$DamageScale[HAPC, $PoisonDamageType] = 1.0; 
$DamageScale[HAPC, $FireDamageType] = 1.0; 
$DamageScale[HAPC, $ShockDamageType] = 1.0;
$DamageScale[HAPC, $AntiAirDamageType] = 1.0;



function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
	%this.numOfPassengers = 0;
}


function Vehicle::onCollision(%this, %object)
{
	%client = Player::getClient(%object);
	if(Client::getTeam(%client) == -1)
		return;
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == ""){
			if(Player::isAiControlled(%object))
				return;               
			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);
			if ((%armor == "sarmor" || %armor == "sfemale" || %armor == "sparmor" || %armor == "spfemale" || %armor == "sniparmor" || %armor == "snipfemale" || $BuilderMode) && Vehicle::canMount(%this, %object)){
				%weapon = Player::getMountedItem(%object,$WeaponSlot);
				if(%weapon != -1) {
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				if(GameBase::getDataName(%this) == Wraith) { 
					GameBase::startFadeout(%this); 
				} 
				Player::setMountObject(%object, %this, 1);
				%this.beingUsed++;
				%client.usingThis = %this;
				//%this.numOfPassengers++;
				Client::setControlObject(%client, %this);
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%object.driver= 1;
				%object.vehicle = %this;
				%this.clLastMount = %client;
				Nappy::StartVehicleTracking(%this);
			}
			else if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != Wraith) && (GameBase::getDataName(%this) != Jet) )  {
				%mountSlot= Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) {
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					%this.beingUsed++;
					%client.usingThis = %this;
					//%this.numOfPassengers++;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				}
			}
			else if (GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
		}
	}
}





//;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
//::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><>

function Nappy::StartVehicleTracking(%this)
{
	%dataname = GameBase::getDataName(%this);//when vehicle is destroyed this will = ""

	%pos = GameBase::getPosition(%this);
	%BoxLength = $Nappy::VehicleServerCrashDistance::BoxLength;
	%BoxWidth = $Nappy::VehicleServerCrashDistance::BoxWidth;
	%BoxHeight = $Nappy::VehicleServerCrashDistance::BoxHeight;

	%set = newObject("AVScrash" @ %this,SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType, %pos, %BoxLength, %BoxWidth, %BoxHeight, 0);
	deleteObject(%set);
	if(%num > 3){
		StaticShape::onDamage(%this,$CrushDamageType,200,"0 0 0","0 0 0","0 0 0",%this);
	}
	else if(%dataname != ""){//so if vehicle isn't destroyed keep checking
		schedule("Nappy::StartVehicleTracking(" @ %this @ ");",0.1);
	}
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







function Vehicle::jump(%this,%mom)
{
	Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1){
		%pl = Client::getOwnedObject(%cl);
		if(getObjectType(%pl) == "Player"){
			// dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				%this.beingUsed--;//.numOfPassengers--;
				%cl.usingThis = "";
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
					if(GameBase::getDataName(%this) == Wraith) { 
						GameBase::startFadein(%this); 
					}
      				}
				%pl.driver = "";
				%pl.vehicle = "";
				//if(%this.numOfPassengers == 0)
				//	%this.beingUsed = 0;
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}



function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	else if(%armor == "sarmor" || %armor == "sfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "sparmor" || %armor == "spfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "sniparmor" || %armor == "snipfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "mercarmor" || %armor == "mercfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "flagarmor" || %armor == "flagfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "barmor" || %armor == "bfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "engarmor" || %armor == "engfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "darmor") {
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
		//%this.numOfPassengers--;
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   	%passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
		//if(%this.numOfPassengers == 0)
		%this.beingUsed--;
		%client.usingThis = "";
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}




function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%this);
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
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
			Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
			%pl.vehicle= "";
		}
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); 
}
