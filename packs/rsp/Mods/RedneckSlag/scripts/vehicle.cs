//----------------------------------------------------------------------------
//

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

	projectileType = FlierRocket;
	reloadDelay = 2.0;
	repairRate = 0;
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

//--------------------------------------------
//Redneck Slag Fliers
//--------------------------------------------
$CloakRange = 20;

FlierData CHAPC
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
	maxDamage = 1.25;
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
	description = "Cloaking HPC";
};

FlierData Fighter
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
   maxSpeed = 80;
   minSpeed = -2;
	lift = 0.85;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.7;

	groundDamageScale = 1.0;

	projectileType = FighterBullet;
	reloadDelay = 0.005;
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
	description = "Fighter";
};

FlierData BLAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.35;
   maxPitch = 0.2;
   maxSpeed = 40;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;

	projectileType = BlanketBombShell;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireMortar;
	reloadDelay = 15.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Bomber LPC";
};

//----------------------------------------------------------------------------

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
$DamageScale[Scout, $MineDamageType]        = 1.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.2;
$DamageScale[HAPC, $BulletDamageType] = 1.2;
$DamageScale[HAPC, $PlasmaDamageType] = 1.2;
$DamageScale[HAPC, $EnergyDamageType] = 1.2;
$DamageScale[HAPC, $ExplosionDamageType] = 1.2;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.2;
$DamageScale[HAPC, $DebrisDamageType] = 1.2;
$DamageScale[HAPC, $MissileDamageType] = 1.2;
$DamageScale[HAPC, $LaserDamageType] = 0.7;
$DamageScale[HAPC, $MortarDamageType] = 1.5;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 0.4;
$DamageScale[HAPC, $MineDamageType]        = 1.0;

$DamageScale[CHAPC, $ImpactDamageType] = 1.0;
$DamageScale[CHAPC, $BulletDamageType] = 1.0;
$DamageScale[CHAPC, $PlasmaDamageType] = 1.0;
$DamageScale[CHAPC, $EnergyDamageType] = 1.0;
$DamageScale[CHAPC, $ExplosionDamageType] = 1.0;
$DamageScale[CHAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[CHAPC, $DebrisDamageType] = 1.0;
$DamageScale[CHAPC, $MissileDamageType] = 1.0;
$DamageScale[CHAPC, $LaserDamageType] = 0.5;
$DamageScale[CHAPC, $MortarDamageType] = 1.0;
$DamageScale[CHAPC, $BlasterDamageType] = 0.5;
$DamageScale[CHAPC, $ElectricityDamageType] = 1.0;
$DamageScale[CHAPC, $MineDamageType]        = 1.0;

$DamageScale[Fighter, $ImpactDamageType] = 1.0;
$DamageScale[Fighter, $BulletDamageType] = 1.0;
$DamageScale[Fighter, $PlasmaDamageType] = 1.0;
$DamageScale[Fighter, $EnergyDamageType] = 1.0;
$DamageScale[Fighter, $ExplosionDamageType] = 1.0;
$DamageScale[Fighter, $ShrapnelDamageType] = 1.0;
$DamageScale[Fighter, $DebrisDamageType] = 1.0;
$DamageScale[Fighter, $MissileDamageType] = 1.0;
$DamageScale[Fighter, $LaserDamageType] = 1.0;
$DamageScale[Fighter, $MortarDamageType] = 1.0;
$DamageScale[Fighter, $BlasterDamageType] = 0.6;
$DamageScale[Fighter, $ElectricityDamageType] = 1.0;
$DamageScale[Fighter, $MineDamageType]        = 1.0;

$DamageScale[BLAPC, $ImpactDamageType] = 1.0;
$DamageScale[BLAPC, $BulletDamageType] = 1.0;
$DamageScale[BLAPC, $PlasmaDamageType] = 1.0;
$DamageScale[BLAPC, $EnergyDamageType] = 1.0;
$DamageScale[BLAPC, $ExplosionDamageType] = 1.0;
$DamageScale[BLAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[BLAPC, $DebrisDamageType] = 1.0;
$DamageScale[BLAPC, $MissileDamageType] = 1.0;
$DamageScale[BLAPC, $LaserDamageType] = 0.5;
$DamageScale[BLAPC, $MortarDamageType] = 1.0;
$DamageScale[BLAPC, $BlasterDamageType] = 0.5;
$DamageScale[BLAPC, $ElectricityDamageType] = 1.0;
$DamageScale[BLAPC, $MineDamageType]        = 1.0;

$DamageScale[Scout, $FighterGunDamageType] = 1.0;
$DamageScale[LAPC, $FighterGunDamageType] = 1.0;
$DamageScale[HAPC, $FighterGunDamageType] = 1.0;
$DamageScale[CHAPC, $FighterGunDamageType] = 1.3;
$DamageScale[Fighter, $FighterGunDamageType] = 1.0;
$DamageScale[BLAPC, $FighterGunDamageType] = 1.0;

$DamageScale[Scout, $PulseMortarDamageType] = 1.0;
$DamageScale[LAPC, $PulseMortarDamageType] = 0.7;
$DamageScale[HAPC, $PulseMortarDamageType] = 0.8;
$DamageScale[CHAPC, $PulseMortarDamageType] = 1.0;
$DamageScale[Fighter, $PulseMortarDamageType] = 1.0;
$DamageScale[BLAPC, $PulseMortarDamageType] = 0.2;

$DamageScale[Scout, $SniperRifleDamageType] = 0.8;
$DamageScale[LAPC, $SniperRifleDamageType] = 0.7;
$DamageScale[HAPC, $SniperRifleDamageType] = 0.8;
$DamageScale[CHAPC, $SniperRifleDamageType] = 1.0;
$DamageScale[Fighter, $SniperRifleDamageType] = 1.0;
$DamageScale[BLAPC, $SniperRifleDamageType] = 0.7;

$DamageScale[Scout, $NukeGrenadeDamageType] = 10.0;
$DamageScale[LAPC, $NukeGrenadeDamageType] = 10.0;
$DamageScale[HAPC, $NukeGrenadeDamageType] = 10.0;
$DamageScale[CHAPC, $NukeGrenadeDamageType] = 10.0;
$DamageScale[Fighter, $NukeGrenadeDamageType] = 10.0;
$DamageScale[BLAPC, $NukeGrenadeDamageType] = 10.0;

$DamageScale[Scout, $RmtChainDamageType] = 1.0;
$DamageScale[LAPC, $RmtChainDamageType] = 1.0;
$DamageScale[HAPC, $RmtChainDamageType] = 1.2;
$DamageScale[CHAPC, $RmtChainDamageType] = 1.0;
$DamageScale[Fighter, $RmtChainDamageType] = 1.0;
$DamageScale[BLAPC, $RmtChainDamageType] = 1.0;

$DamageScale[Scout, $PlasmaCannonDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaCannonDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaCannonDamageType] = 1.2;
$DamageScale[CHAPC, $PlasmaCannonDamageType] = 1.0;
$DamageScale[Fighter, $PlasmaCannonDamageType] = 1.0;
$DamageScale[BLAPC, $PlasmaCannonDamageType] = 1.0;

$DamageScale[Scout, $HellfireDamageType] = 1.0;
$DamageScale[LAPC, $HellfireDamageType] = 1.0;
$DamageScale[HAPC, $HellfireDamageType] = 1.2;
$DamageScale[CHAPC, $HellfireDamageType] = 1.0;
$DamageScale[Fighter, $HellfireDamageType] = 1.0;
$DamageScale[BLAPC, $HellfireDamageType] = 1.0;

$DamageScale[Scout, $KamikazeDamageType] = 1.0;
$DamageScale[LAPC, $KamikazeDamageType] = 1.0;
$DamageScale[HAPC, $KamikazeDamageType] = 1.0;
$DamageScale[CHAPC, $KamikazeDamageType] = 1.0;
$DamageScale[Fighter, $KamikazeDamageType] = 1.0;
$DamageScale[BLAPC, $KamikazeDamageType] = 1.0;

$DamageScale[Scout, $AAMissileDamageType] = 1.0;
$DamageScale[LAPC, $AAMissileDamageType] = 1.0;
$DamageScale[HAPC, $AAMissileDamageType] = 1.2;
$DamageScale[CHAPC, $AAMissileDamageType] = 1.4;
$DamageScale[Fighter, $AAMissileDamageType] = 1.0;
$DamageScale[BLAPC, $AAMissileDamageType] = 1.5;

$DamageScale[Scout, $BlanketBombDamageType] = 1.0;
$DamageScale[LAPC, $BlanketBombDamageType] = 1.0;
$DamageScale[HAPC, $BlanketBombDamageType] = 1.0;
$DamageScale[CHAPC, $BlanketBombDamageType] = 1.0;
$DamageScale[Fighter, $BlanketBombDamageType] = 1.0;
$DamageScale[BLAPC, $BlanketBombDamageType] = 1.0;

$DamageScale[Scout, $FlakDamageType] = 2.0;
$DamageScale[LAPC, $FlakDamageType] = 1.5;
$DamageScale[HAPC, $FlakDamageType] = 2.5;
$DamageScale[CHAPC, $FlakDamageType] = 2.0;
$DamageScale[Fighter, $FlakDamageType] = 2.0;
$DamageScale[BLAPC, $FlakDamageType] = 2.0;

$DamageScale[Scout, $AntiMatterDamageType] = 1.0;
$DamageScale[LAPC, $AntiMatterDamageType] = 1.0;
$DamageScale[HAPC, $AntiMatterDamageType] = 1.0;
$DamageScale[CHAPC, $AntiMatterDamageType] = 1.0;
$DamageScale[Fighter, $AntiMatterDamageType] = 1.0;
$DamageScale[BLAPC, $AntiMatterDamageType] = 1.0;

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	if(GameBase::getDataName(%this) == Scout) 
		GameBase::setMapName (%this, "Scout");
	if(GameBase::getDataName(%this) == LAPC)
		GameBase::setMapName (%this, "LPC");
	if(GameBase::getDataName(%this) == HAPC)
		GameBase::setMapName (%this, "HPC");
	if(GameBase::getDataName(%this) == CHAPC)
		GameBase::setMapName (%this, "Cloaking HPC");
	if(GameBase::getDataName(%this) == Fighter) 
		GameBase::setMapName (%this, "Fighter");
	if(GameBase::getDataName(%this) == BLAPC)
		GameBase::setMapName (%this, "Bomber LPC");
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if (((%armor == "SCarmor" || %armor == "FSCarmor" || %armor == "INFarmor" || %armor == "FINFarmor") || ((%armor == "SNarmor" || %armor == "FSNarmor") && GameBase::getDataName(%this) == "Scout")) && Vehicle::canMount(%this, %object)){

						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						//---------
						if(GameBase::getDataName(%this) == CHAPC){
							%rate = Player::getSensorSupression(%object) + $CloakRange;
							Player::setSensorSupression(%object,%rate);
							GameBase::startFadeout(%this);
							GameBase::startFadeout(%client);
						}
						//---------
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if(GameBase::getDataName(%this) != Scout && GameBase::getDataName(%this) != Fighter) 
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
								
								if(GameBase::getDataName(%this) == CHAPC){
									GameBase::startFadeout(%client);
								}
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					if(%armor == "SNarmor" || %armor == "FSNarmor")
						Client::sendMessage(Player::getClient(%object),0,"Snipers can only fly scouts.~wError_Message.wav");
					else
						Client::sendMessage(Player::getClient(%object),0,"You must be in Scout Armor or Infiltrator Armor to pilot the vehicles.~wError_Message.wav");
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC || GameBase::getDataName(%this) == CHAPC)
		%numSlots = 4;
	else if(GameBase::getDataName(%this) == LAPC || GameBase::getDataName(%this) == BLAPC)
		%numSlots = 2;
	else
		%numSlots = 0;
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
	if(%armor == "SCarmor" || %armor == "FSCarmor" || %armor == "SNarmor" || %armor == "FSNarmor") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "EngArmor" || %armor == "FEngArmor" || %armor == "INFarmor" || %armor == "FINFarmor" || %armor == "DEarmor" || %armor == "FDEarmor") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "GOLarmor" || %armor == "FGOLarmor" || %armor == "HACKarmor" || %armor == "FHACKarmor") {
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

		// Uncloaking
		if(GameBase::getDataName(%this) == CHAPC)
			GameBase::startFadein(%client);
		// --------------
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
				// Uncloaking
				if(GameBase::getDataName(%this) == CHAPC) {
					%rate = Player::getSensorSupression(%pl) - $CloakRange; //*IX*Savage1
					Player::setSensorSupression(%pl,%rate); //*IX*Savage1

					GameBase::startFadein(%this);
					GameBase::startFadein(%cl);
				}
				// --------------
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
		//---------------
		if(GameBase::getDataName(%this) == CHAPC)
			GameBase::startFadein(%pl);
			%rate = Player::getSensorSupression(%pl) - $CloakRange;
			Player::setSensorSupression(%pl,%rate);
		// --------------
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
		
		//---------------
		if(GameBase::getDataName(%this) == CHAPC)
			GameBase::startFadein(%pl);
		// --------------
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100);
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}