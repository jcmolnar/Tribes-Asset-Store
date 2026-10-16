 																					
FlierData Scout 
{ 
explosionId = flashExpLarge; 
debrisId = flashDebrisLarge; 
className = "Vehicle"; 
shapeFile = "flyer"; 
shieldShapeName = "shield_medium"; 
mass = 20.0; 
drag = 15.0; 
density = 1.2; 
maxBank = 0.8; 
maxPitch = 0.8; 
maxSpeed = 75; 
minSpeed = -25; 
lift = 0.5; 
maxAlt = 350; 
maxVertical = 1; 
maxDamage = 1.65; 
damageLevel = {1.0, 1.0}; 
maxEnergy = 100; 
accel = 0.9; 
groundDamageScale = 0; 
projectileType = Chaingunbullet; 
reloadDelay = 0.1; 
repairRate = 1; 
//fireSound = SoundFireChaingun; 
damageSound = SoundFlierCrash; 
ramDamage = 0.5; 
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
driverPose = 35; 
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
maxSpeed = 230; 
minSpeed = -2; 
lift = 0.99; 
maxAlt = 2500; 
maxVertical = 360; 
maxDamage = 1.6; 
damageLevel = {1.0, 1.0}; 
maxEnergy = 100; 
accel = 1.8; 
groundDamageScale = 1.0; 
projectileType = HyperBolt; 
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
driverPose = 13; 
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
projectileType = FlierRocket; 
reloadDelay = 0.5; 
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
projectileType = StingerMissile; 
fireSound = SoundFireMortar; 
reloadDelay = 1.0; 
damageSound = SoundTankCrash; 
visibleToSensor = true; 
shadowDetailMask = 2; 
mountSound = SoundFlyerMount; 
dismountSound = SoundFlyerDismount; 
idleSound = SoundFlyerIdle; 
moveSound = SoundFlyerActive; 
visibleDriver = true; 
driverPose = 23; 
}; 

FlierData HAPC 
{ 
explosionId = flashExpLarge; 
debrisId = flashDebrisLarge; 
className = "Vehicle"; 
shapeFile = "hover_apc"; 
shieldShapeName = "shield_large"; 
mass = 18.0; 
drag = 10.0; 
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
projectileType = MortarShell; 
reloadDelay = 1.0; 
damageSound = SoundTankCrash; 
visibleToSensor = false; 
shadowDetailMask = 2; 
mountSound = SoundFlyerMount; 
dismountSound = SoundFlyerDismount; 
idleSound = SoundFlyerIdle; 
moveSound = SoundFlyerActive; 
visibleDriver = true; 
driverPose = 23; 
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

function Vehicle::onAdd(%this) 
{ 
%this.shieldStrength = 0.0; 
GameBase::setRechargeRate (%this, 10); 
GameBase::setMapName (%this, "Vehicle"); 
} 

function Vehicle::onCollision (%this, %object) 
{
if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) 
{ 
if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") 
{ 
%armor = Player::getArmor(%object); 
%client = Player::getClient(%object); 
if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object)) 
{ 
%weapon = Player::getMountedItem(%object,$WeaponSlot); 
if(%weapon != -1) 
{ 
%object.lastWeapon = %weapon; 
Player::unMountItem(%object,$WeaponSlot); 
} 
if(GameBase::getDataName(%this) == Wraith) 
GameBase::startFadeout(%this); 
Player::setMountObject(%object, %this, 1); 
Client::setControlObject(%client, %this); 
playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this)); 
%object.driver= 1; 
%object.vehicle = %this; 
%this.clLastMount = %client; 
} 
else 
if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != Wraith) && (GameBase::getDataName(%this) != Jet) ) 
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
else 
if (GameBase::getControlClient(%this) == -1) 
Client::sendMessage(Player::getClient(%object),0,"You must be in Sniper Armor to pilot the vehicles.~wError_Message.wav"); 
} 
} 
} 

function Vehicle::findEmptySeat(%this,%client) { if(GameBase::getDataName(%this) == HAPC) %numSlots = 4; else %numSlots = 2; %count=0; for(%i=0;%i<%numSlots;%i++) if(%this.Seat[%i] == "") { %slotPos[%count] = Vehicle::getMountPoint(%this,%i+2); %slotVal[%count] = %i+2; %lastEmpty = %i+2; %count++; } if(%count == 1) { %this.Seat[%lastEmpty-2] = %client; return %lastEmpty; } else if (%count > 1) { %freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])]; %this.Seat[%freeSlot-2] = %client; return %freeSlot; } else return "False"; 
} 
function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3) { %playerX = getWord(%playerPos,0); %playerY = getWord(%playerPos,1); for(%i = 0 ;%i<%num;%i++) { %x = (getWord(%slotPos[%i],0)) - %playerX; %y = (getWord(%slotPos[%i],1)) - %playerY; if(%x < 0) %x *= -1; if(%y < 0) %y *= -1; %newDistance = sqrt((%x*%x)+(%y*%y)); if(%newDistance < %distance || %distance == "") { %distance = %newDistance; %closePos = %i; } } return %closePos; 
} 
function Vehicle::passengerJump(%this,%passenger,%mom) { %armor = Player::getArmor(%passenger); if(%armor == "larmor" || %armor == "lfemale") { %height = 2; %velocity = 70; %zVec = 70; } else if(%armor == "marmor" || %armor == "mfemale") { %height = 2; %velocity = 100; %zVec = 100; } else if(%armor == "harmor") { %height = 2; %velocity = 140; %zVec = 110; } else { %height = 2; %velocity = 70; %zVec = 70; } %pos = GameBase::getPosition(%passenger); %posX = getWord(%pos,0); %posY = getWord(%pos,1); %posZ = getWord(%pos,2); if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) { %client = Player::getClient(%passenger); %this.Seat[%passenger.vehicleSlot-2] = ""; %passenger.vehicleSlot = ""; %passenger.vehicle= ""; Player::setMountObject(%passenger, -1, 0); %rotZ = getWord(GameBase::getRotation(%passenger),2); GameBase::setRotation(%passenger, "0 0 " @ %rotZ); GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height)); %jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec); Player::applyImpulse(%passenger,%jumpDir); } else Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav"); 
} 
function Vehicle::jump(%this,%mom) { Vehicle::dismount(%this,%mom); 
} 
function Vehicle::dismount(%this,%mom) { %cl = GameBase::getControlClient(%this); if(%cl != -1) { %pl = Client::getOwnedObject(%cl); if(getObjectType(%pl) == "Player") { if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) { %pl.lastMount = %this; %pl.newMountTime = getSimTime() + 3.0; Player::setMountObject(%pl, %this, 0); Player::setMountObject(%pl, -1, 0); %rot = GameBase::getRotation(%this); %rotZ = getWord(%rot,2); GameBase::setRotation(%pl, "0 0 " @ %rotZ); Player::applyImpulse(%pl,%mom); Client::setControlObject(%cl, %pl); playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this)); if(%pl.lastWeapon != "") { Player::useItem(%pl,%pl.lastWeapon); %pl.lastWeapon = ""; if(GameBase::getDataName(%this) == Wraith) { GameBase::startFadein(%this); } } %pl.driver = ""; %pl.vehicle = ""; } else Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav"); } } 
} 
function Vehicle::onDestroyed (%this,%mom) { $TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--; %cl = GameBase::getControlClient(%this); %pl = Client::getOwnedObject(%cl); if(%pl != -1) { Player::setMountObject(%pl, -1, 0); Client::setControlObject(%cl, %pl); if(%pl.lastWeapon != "") { Player::useItem(%pl,%pl.lastWeapon); %pl.lastWeapon = ""; } %pl.driver = ""; } for(%i = 0 ; %i < 4 ; %i++) if(%this.Seat[%i] != "") { %pl = Client::getOwnedObject(%this.Seat[%i]); Player::setMountObject(%pl, -1, 0); Client::setControlObject(%this.Seat[%i], %pl); } calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); 
} 
function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) { %value *= $damageScale[GameBase::getDataName(%this), %type]; StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object); 
} 
function Vehicle::getHeatFactor(%this) { return 1.0; }

//================================================================================
//====================Vehicle Smoke Trails Data===================================
//================================================================================
//
ExplosionData vehiclesmokeExp
{
	shapeName = "snowplume.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	lightRange = 0;
	timeScale = 15;
	timeZero = 0.2;
	timeOne = 0.9;
	colors[0] = { 0.25, 0.25, 1.0 };
	colors[1] = { 0.25, 0.25, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};

MineData VehicleDummy
{
	className = "smokepuff";
    shapeFile = "snowplume";
    shadowDetailMask = 1;
    explosionId = fakeExp;
	explosionRadius = 0;
	damageValue = 0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.0001;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
	mass = -1;
	drag = 0;
};

GrenadeData VehicleSmokeGren
{
	explosionTag       = vehiclesmokeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0;
	mass               = -1;
	elasticity         = 0;
	damageClass        = 1;
	damageValue        = 0;
	damageType         = $NullDamageType;
	explosionRadius    = 0;
	kickBackStrength   = 0;
	maxLevelFlightDist = 0;
	totalTime          = 0.3;
	liveTime           = 0.3;
	projSpecialTime    = 0.01;
};

function VehicleDummy::Detonate(%this,%ismoving)
{
	%cl = %this.deployer;
	%player = client::getownedobject(%cl);
	%vel = "0 0 0";
	if (!%player)
		return;
	%pos1 = gamebase::getposition(%this);
	%rot = (gamebase::getrotation(%this));
	%dir = (Vector::getfromrot(%rot));
	%trans1 = (%rot @ " " @ %dir @ " " @ %rot);
	%padd = "0 0 2.0";
	%pos = Vector::add(%pos1, %padd);
	%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;

	if(!%ismoving)
		schedule ("Projectile::spawnProjectile(VehicleSmokeGren, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);
	else
	{
		%velX = getWord(%ismoving, 0);
		%velY = getWord(%ismoving, 1);
		if(%velX >= %velY)
			%topvel = %velX;
		else
			%topvel = %velY;

		%timeperiod = ((%topvel/(%this.maxSpeed))*-0.20);
		if(%timeperiod > 0)
			%timeperiod = %timeperiod * -1;
		%timeperiod = %timeperiod + 1;
		schedule ("Projectile::spawnProjectile(VehicleSmokeGren, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",%timeperiod);
	}
}

function Vehicle::SetSmoke(%this)
{
	if(%this.fading != "")
	{
		Schedule("Vehicle::SetSmoke(" @ %this @ ");", 0.3, %this);
		return;
	}
	Vehicle::CheckSmoke(%this);
}


function Vehicle::CheckSmoke(%this)
{
	%vel = Item::getVelocity(%this);
	%velX = getWord(%vel, 0);
	%velY = getWord(%vel, 1);
	if(%velX > 4 || %velX < -4 || %velY > 4 || %velY < -4)
	{
      	%cl = GameBase::getControlClient(%this);
		%player = client::getOwnedobject(%cl);
		%thisPos = GameBase::getPosition(%this);
		%xcoord = getWord(%thisPos,0);
		%ycoord = getWord(%thisPos,1);
		%zcoord = getWord(%thisPos,2) - 2;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],%vel);
		deleteObject(%obj[%this]);
		Schedule("Vehicle::CheckSmoke(" @ %this @ ");", 0.05, %this);
	}
	else if(%this)
	{
	      %cl = GameBase::getControlClient(%this);
		%player = client::getOwnedobject(%cl);
		%thisPos = GameBase::getPosition(%this);

		%xcoord = getWord(%thisPos,0);
		%ycoord = getWord(%thisPos,1);
		%zcoord = getWord(%thisPos,2) - 2;
		%VehicleExplosionPosition = sprintf("%1 %2 %3",%xcoord, %ycoord, %zcoord);
		%obj[%this] = newObject("","Mine","VehicleDummy");
		addToSet("MissionCleanup", %obj[%this]);
		GameBase::setPosition(%obj[%this],%VehicleExplosionPosition);
		VehicleDummy::Detonate(%obj[%this],%vel);
		deleteObject(%obj[%this]);

		Schedule("Vehicle::CheckSmoke(" @ %this @ ");", 0.4, %this);
	}
	else return;
}