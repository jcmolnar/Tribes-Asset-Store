//----------------------------------------------------------------------------
//

FlierData Interceptor
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 6.0;
   drag = 0.8;
   density = 1.2;
   maxBank = 0.85;
   maxPitch = 1.0;
   maxSpeed = 65;
   minSpeed = -10;
	lift = 0.95;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.95;

	groundDamageScale = 1.0;

	projectileType = FighterBullet;
	reloadDelay = 0.08;
	repairRate = 0;
	fireSound = SoundFireFightergun;
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
	description = "Interceptor";
};

FlierData Minelayer
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.40;
   maxPitch = 0.175;
   maxSpeed = 15;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 10;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.15;

	groundDamageScale = 0.50;

	projectileType = MineShell;
	reloadDelay = 4;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireMortar;
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
	description = "Minelayer";
};

FlierData APC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.45;
   maxPitch = 0.35;
   maxSpeed = 30;								   
   minSpeed = -5;
	lift = 0.45;
	maxAlt = 18;
	maxVertical = 7;
	maxDamage = 2.0;
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
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "APC";
};


//----------------------------------------------------------------------------

$DamageScale[Interceptor, $ImpactDamageType] = 1.0;
$DamageScale[Interceptor, $BulletDamageType] = 1.0;
$DamageScale[Interceptor, $PlasmaDamageType] = 1.0;
$DamageScale[Interceptor, $EnergyDamageType] = 1.0;
$DamageScale[Interceptor, $ExplosionDamageType] = 1.0;
$DamageScale[Interceptor, $ShrapnelDamageType] = 1.0;
$DamageScale[Interceptor, $DebrisDamageType] = 1.0;
$DamageScale[Interceptor, $MissileDamageType] = 1.0;
$DamageScale[Interceptor, $LaserDamageType] = 1.0;
$DamageScale[Interceptor, $MortarDamageType] = 1.0;
$DamageScale[Interceptor, $BlasterDamageType] = 0.5;
$DamageScale[Interceptor, $ElectricityDamageType] = 1.0;
$DamageScale[Interceptor, $MineDamageType]        = 1.0;
$DamageScale[Interceptor, $FighterGunDamageType] = 1.2;
$DamageScale[Interceptor, $LaserHPDamageType] = 1.6;
$DamageScale[Interceptor, $HornetDamageType] = 1.0;
$DamageScale[Interceptor, $CannonDamageType] = 1.0;
$DamageScale[Interceptor, $FlakDamageType] = 2.0;

$DamageScale[Minelayer, $ImpactDamageType] = 1.0;
$DamageScale[Minelayer, $BulletDamageType] = 1.0;
$DamageScale[Minelayer, $PlasmaDamageType] = 1.0;
$DamageScale[Minelayer, $EnergyDamageType] = 1.0;
$DamageScale[Minelayer, $ExplosionDamageType] = 1.0;
$DamageScale[Minelayer, $ShrapnelDamageType] = 1.0;
$DamageScale[Minelayer, $DebrisDamageType] = 1.0;
$DamageScale[Minelayer, $MissileDamageType] = 1.0;
$DamageScale[Minelayer, $LaserDamageType] = 0.5;
$DamageScale[Minelayer, $MortarDamageType] = 1.0;
$DamageScale[Minelayer, $BlasterDamageType] = 0.5;
$DamageScale[Minelayer, $ElectricityDamageType] = 1.0;
$DamageScale[Minelayer, $MineDamageType]        = 1.0;
$DamageScale[Minelayer, $FighterGunDamageType] = 1.0;
$DamageScale[Minelayer, $LaserHPDamageType] = 1.6;
$DamageScale[Minelayer, $HornetDamageType] = 1.0;
$DamageScale[Minelayer, $CannonDamageType] = 1.0;
$DamageScale[Minelayer, $FlakDamageType] = 2.0;

$DamageScale[APC, $ImpactDamageType] = 1.0;
$DamageScale[APC, $BulletDamageType] = 1.0;
$DamageScale[APC, $PlasmaDamageType] = 1.0;
$DamageScale[APC, $EnergyDamageType] = 1.0;
$DamageScale[APC, $ExplosionDamageType] = 1.0;
$DamageScale[APC, $ShrapnelDamageType] = 1.0;
$DamageScale[APC, $DebrisDamageType] = 1.0;
$DamageScale[APC, $MissileDamageType] = 1.0;
$DamageScale[APC, $LaserDamageType] = 0.5;
$DamageScale[APC, $MortarDamageType] = 1.0;
$DamageScale[APC, $BlasterDamageType] = 0.5;
$DamageScale[APC, $ElectricityDamageType] = 1.0;
$DamageScale[APC, $MineDamageType]        = 1.0;
$DamageScale[APC, $FighterGunDamageType] = 1.0;
$DamageScale[APC, $LaserHPDamageType] = 1.6;
$DamageScale[APC, $HornetDamageType] = 1.0;
$DamageScale[APC, $CannonDamageType] = 1.0;
$DamageScale[APC, $FlakDamageType] = 2.0;


//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	if(GameBase::getDataName(%this) == APC)
		%this.shieldStrength = 0.03;
	else
		%this.shieldStrength = 0.0;
	bdecho("Vehicle", "Vehicle added: " @ GameBase::getDataName(%this));
	$va[ %this ] = true;
	schedule( "Vehicle::checkSmoke( " @ %this @ " );", 1.0 );
	GameBase::setRechargeRate (%this, 6);
	GameBase::setMapName (%this, "Vehicle");
	GameBase::setActive(%this,true);
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
			if(%object.Station != "")
			{
		    	Client::sendMessage( Player::getClient( %object ),0,"You must leave the Inventory Station to pilot the vehicles.~wError_Message.wav");
				return;
			}
			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);
				if ((%armor == "larmor" || %armor == "lfemale")// || ((%armor != "harmor") && (GameBase::getDataName(%this) == Minelayer))
							&& Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if((GameBase::getDataName(%this) != Interceptor) && (GameBase::getDataName(%this) != Minelayer))
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == APC)
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
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
//	if($testcheats || $servercheats)
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
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
	deletevariables( "$va" @ %this );
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

ExplosionData vehiclesmokeExp
{
	shapeName = "smoke.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	lightRange = 0;
	timeZero = 0.250;
	timeOne = 0.35;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

ExplosionData vehiclefireExp
{
	shapeName = "tumult_small.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	lightRange = 0;
	timeZero = 0.250;
	timeOne = 0.35;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

GrenadeData VehicleSmokeGren
{
	explosionTag       = vehiclesmokeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 0.0;
	elasticity         = 0.0;
	damageClass        = 1;
	damageValue        = 0.01;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 0;
	kickBackStrength   = 0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
};

GrenadeData VehicleFireGren
{
	explosionTag       = vehiclefireExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = 0.0;
	elasticity         = 0.0;
	damageClass        = 1;
	damageValue        = 0;
	damageType         = $PlasmaDamageType;
	explosionRadius    = 0;
	kickBackStrength   = 0;
	maxLevelFlightDist = 375;
	totalTime          = 0.1;
	liveTime           = 0.1;
	projSpecialTime    = 0.01;
};

function Vehicle::checkSmoke( %this )
{
	if( $va[ %this ] )
	{
		%dam = GameBase::getDamageLevel( %this );
		%dataName = GameBase::getDataName( %this );
		%maxDam = %dataName.maxDamage;
		%damRatio = ( %dam / %maxDam );
		%pos = GameBase::getPosition( %this );
		%newPos = Vector::add( %pos, "0 0 2" );
		%trans = "0 0 0 0 0 0 0 0 0 " @ %newPos;
		%vel = "0 0 0";
		if( %damRatio >= 0.7 )
		{
			schedule ("Projectile::spawnProjectile(VehicleFireGren, \"" @ %trans @ "\", \"" @ %this @ "\", \"" @ %vel @ "\");",0.1);
		}
		else if( %damRatio >= 0.4 )
		{
			schedule ("Projectile::spawnProjectile(VehicleSmokeGren, \"" @ %trans @ "\", \"" @ %this @ "\", \"" @ %vel @ "\");",0.1);
		}
			
		%vel = Vector::getDistance( Item::getVelocity( %this ), "0 0 0" );
		if( %vel > 5 )
			schedule( "Vehicle::checkSmoke( " @ %this @ " );", 0.1, %this );
		else
			schedule( "Vehicle::checkSmoke( " @ %this @ " );", 0.5, %this );
	}
	else
		return;
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}