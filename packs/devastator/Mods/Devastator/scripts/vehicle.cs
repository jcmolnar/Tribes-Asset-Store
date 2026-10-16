//----------------------------------------------------------------------------
//-NOTE: ALL NON-BASE FUNCTIONS IN THIS SCRIPT WERE WRITTEN BY ICE
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

	reloadDelay = 3.0;
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
	driverPose = 48;
	description = "F-14 Tomcat";
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

	reloadDelay = 2.0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireMortar;
	damageSound = SoundTankCrash;
	visibleToSensor = false;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "B-2";
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

	groundDamageScale = 0.05;

	reloadDelay = 2.0;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireMortar;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundNewFlyerIdle;
	moveSound = SoundWindGust;

	visibleDriver = true;
	driverPose = 23;
	description = "B-52 StratoFortress";
};

FlierData Kamikaze
{
	explosionId = LargeShockwave;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 9.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.5;
	maxPitch = 0.5;
	maxSpeed = 70;
	minSpeed = -2;
	lift = 0.75;
	maxAlt = 60;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	reloadDelay = 1.0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 10;
	ramDamageType = $KamikazeDamageType;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 38;
	description = "Kamikaze Jet";
};

FlierData KamiDive
{
	explosionId = LargeShockwave;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 7.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.5;
	maxPitch = 0.5;
	maxSpeed = 200;
	minSpeed = 90;
	lift = 0.75;
	maxAlt = 60;
	maxVertical = 10;
	maxDamage = 0.05;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 8.0;

	groundDamageScale = 2.0;

	reloadDelay = 1.0;
	repairRate = -0.2;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 20;
	ramDamageType = $KamiDiveDamageType;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 38;
	description = "Kamikaze Dive Sequence";
};

FlierData Jet
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 7.5;
	drag = 0.5;
	density = 1.2;
   	maxBank = 24.25;  //- 6 rolls
	maxPitch = 100.0;
	maxSpeed = 55;
	minSpeed = -55;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 60;
	accel = 0.6;

	groundDamageScale = 1.0;

	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = debrisSmallExplosion;
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

function Scout::onAdd(%this) 
{
	$VehicleAmmo[%this, RocketsA] = $MaxAmmoVehicle[Scout,RocketsA];
	$VehicleAmmo[%this, ShockMsl] = $MaxAmmoVehicle[Scout,ShockMsl];
	$VehicleAmmo[%this, SideWind] = $MaxAmmoVehicle[Scout,SideWind];
	$VehicleAmmo[%this, Grenades] = $MaxAmmoVehicle[Scout,Grenades];
	Vehicle::onAdd(%this);
}

function Jet::onAdd(%this) 
{
	$VehicleAmmo[%this, ChainGun] = $MaxAmmoVehicle[Jet,ChainGun];
	$VehicleAmmo[%this, StingerA] = $MaxAmmoVehicle[Jet,StingerA];
	$VehicleAmmo[%this, StingerB] = $MaxAmmoVehicle[Jet,StingerB];
	Vehicle::onAdd(%this);
}

function Kamikaze::onAdd(%this) 
{
	$VehicleAmmo[%this, Kamikaze] = $MaxAmmoVehicle[Kamikaze,Kamikaze];
	$VehicleAmmo[%this, KamiDive] = $MaxAmmoVehicle[Kamikaze,KamiDive];
	$VehicleAmmo[%this, Detonate] = $MaxAmmoVehicle[Kamikaze,Detonate];
	$VehicleAmmo[%this, SuperDet] = 0;
	Vehicle::onAdd(%this);
}

function LAPC::onAdd(%this) 
{
	$VehicleAmmo[%this, DropBomb] = $MaxAmmoVehicle[LAPC,DropBomb];
	$VehicleAmmo[%this, FlareDis] = $MaxAmmoVehicle[LAPC,FlareDis];
	$VehicleAmmo[%this, ScatMine] = $MaxAmmoVehicle[LAPC,ScatMine];
	Vehicle::onAdd(%this);
}

function HAPC::onAdd(%this) 
{
	$VehicleAmmo[%this, DevShell] = $MaxAmmoVehicle[HAPC,DevShell];
	$VehicleAmmo[%this, Deflects] = $MaxAmmoVehicle[HAPC,Deflects];
	$VehicleAmmo[%this, ParaBomb] = $MaxAmmoVehicle[HAPC,ParaBomb];
	Vehicle::onAdd(%this);
}

function New::onAdd(%this) 
{
	$VehicleAmmo[%this, CrzySpke] = $MaxAmmoVehicle[New,CrzySpke];
	$VehicleAmmo[%this, Deflects] = $MaxAmmoVehicle[New,Deflects];
	$VehicleAmmo[%this, RmoteDet] = $MaxAmmoVehicle[New,RmoteDet];
	Vehicle::onAdd(%this);
}

//-Debris Damage Type for each Vehicle
$VehDebrisDmgType[Scout] = $DebrisDamageType;
$VehDebrisDmgType[Jet] = $DebrisDamageType;
$VehDebrisDmgType[LAPC] = $DebrisDamageType;
$VehDebrisDmgType[HAPC] = $DebrisDamageType;
$VehDebrisDmgType[Kamikaze] = $KamikazeDamageType;
$VehDebrisDmgType[Kamidive] = $KamiDiveDamageType;
$VehDebrisDmgType[New] = $DebrisDamageType;

//-Weapons to their slots for each vehicle
$VehicleWeaponNum[Scout,   0] = RocketsA;
$VehicleWeaponNum[Scout,   1] = ShockMsl;
$VehicleWeaponNum[Scout,   2] = Grenades;
$VehicleWeaponNum[Scout,   3] = SideWind;
$VehicleWeaponNum[Jet,     0] = ChainGun;
$VehicleWeaponNum[Jet,     1] = StingerA;
$VehicleWeaponNum[Jet,     2] = StingerB;
$VehicleWeaponNum[Kamikaze,0] = Kamikaze;
$VehicleWeaponNum[Kamikaze,1] = KamiDive;
$VehicleWeaponNum[Kamikaze,2] = Detonate;
$VehicleWeaponNum[Kamikaze,3] = SuperDet;
$VehicleWeaponNum[LAPC,    0] = DropBomb;
$VehicleWeaponNum[LAPC,    1] = FlareDis;
$VehicleWeaponNum[LAPC,    2] = ScatMine;
$VehicleWeaponNum[HAPC,    0] = DevShell;
$VehicleWeaponNum[HAPC,    1] = Deflects;
$VehicleWeaponNum[HAPC,    2] = ParaBomb;
$VehicleWeaponNum[New,     0] = CrzySpke;
$VehicleWeaponNum[New,     1] = Deflects;
$VehicleWeaponNum[New,     2] = RmoteDet;

//-Max Ammo for each weapon for each Ace Vehicle
$MaxAmmoAce[Scout,   RocketsA] = 75;
$MaxAmmoAce[Scout,   ShockMsl] = 15;
$MaxAmmoAce[Scout,   SideWind] = 20;
$MaxAmmoAce[Scout,   Grenades] = 15;
$MaxAmmoAce[Jet,     ChainGun] = 2000;
$MaxAmmoAce[Jet,     StingerA] = 25;
$MaxAmmoAce[Jet,     StingerB] = 25;
$MaxAmmoAce[Kamikaze,Kamikaze] = 2;
$MaxAmmoAce[Kamikaze,KamiDive] = 1;
$MaxAmmoAce[Kamikaze,Detonate] = 1;
$MaxAmmoAce[Kamikaze,SuperDet] = 1;
$MaxAmmoAce[LAPC,    DropBomb] = 25;
$MaxAmmoAce[LAPC,    FlareDis] = 10;
$MaxAmmoAce[LAPC,    ScatMine] = 5;
$MaxAmmoAce[HAPC,    DevShell] = 15;
$MaxAmmoAce[HAPC,    Deflects] = 20;
$MaxAmmoAce[HAPC,    ParaBomb] = 10;
$MaxAmmoAce[New,     CrzySpke] = 1000;
$MaxAmmoAce[New,     Deflects] = 10;
$MaxAmmoAce[New,     RmoteDet] = 1;

//-Max Ammo for each weapon for each Vehicle
$MaxAmmoVehicle[Scout,   RocketsA] = 50;
$MaxAmmoVehicle[Scout,   ShockMsl] = 15;
$MaxAmmoVehicle[Scout,   SideWind] = 10;
$MaxAmmoVehicle[Scout,   Grenades] = 10;
$MaxAmmoVehicle[Jet,     ChainGun] = 1000;
$MaxAmmoVehicle[Jet,     StingerA] = 15;
$MaxAmmoVehicle[Jet,     StingerB] = 15;
$MaxAmmoVehicle[Kamikaze,Kamikaze] = 1;
$MaxAmmoVehicle[Kamikaze,KamiDive] = 1;
$MaxAmmoVehicle[Kamikaze,Detonate] = 1;
$MaxAmmoVehicle[Kamikaze,SuperDet] = 0;
$MaxAmmoVehicle[LAPC,    DropBomb] = 20;
$MaxAmmoVehicle[LAPC,    FlareDis] = 5;
$MaxAmmoVehicle[LAPC,    ScatMine] = 2;
$MaxAmmoVehicle[HAPC,    DevShell] = 10;
$MaxAmmoVehicle[HAPC,    Deflects] = 10;
$MaxAmmoVehicle[HAPC,    ParaBomb] = 5;
$MaxAmmoVehicle[New,     CrzySpke] = 500;
$MaxAmmoVehicle[New,     Deflects] = 5;
$MaxAmmoVehicle[New,     RmoteDet] = 1;

//-How many shells to load per click
$MaintRate[RocketsA] = 10;
$MaintRate[ShockMsl] = 3;
$MaintRate[SideWind] = 2;
$MaintRate[Grenades] = 3;
$MaintRate[ChainGun] = 100;
$MaintRate[StingerA] = 3;
$MaintRate[StingerB] = 3;
$MaintRate[KamiDive] = 0;
$MaintRate[Kamikaze] = 1;
$MaintRate[Detonate] = 0;
$MaintRate[SuperDet] = 0;
$MaintRate[DropBomb] = 5;
$MaintRate[FlareDis] = 1;
$MaintRate[ScatMine] = 1;
$MaintRate[DevShell] = 1;
$MaintRate[Deflects] = 1;
$MaintRate[ParaBomb] = 1;
$MaintRate[CrzySpke] = 50;
$MaintRate[RmoteDet] = 0;

//-Reload delay for each type
$ReloadRate[RocketsA] = 2.0;
$ReloadRate[ShockMsl] = 2.0;
$ReloadRate[SideWind] = 1.5;
$ReloadRate[Grenades] = 3.0;
$ReloadRate[ChainGun] = 0.1;
$ReloadRate[StingerA] = 2.0;
$ReloadRate[StingerB] = 1.0;
$ReloadRate[Kamikaze] = 1.0;
$ReloadRate[KamiDive] = 100.0;
$ReloadRate[Detonate] = 100.0;
$ReloadRate[SuperDet] = 100.0;
$ReloadRate[DropBomb] = 3.0;
$ReloadRate[FlareDis] = 1.0;
$ReloadRate[ScatMine] = 4.0;
$ReloadRate[DevShell] = 5.0;
$ReloadRate[Deflects] = 5.0;
$ReloadRate[SDeflect] = 10.0;
$ReloadRate[ParaBomb] = 5.0;
$ReloadRate[CrzySpke] = 0.05;
$ReloadRate[RmoteDet] = 100.0;

//-Projectile for Modes
$VehWeapProjectile[RocketsA] = "FlierRocket";
$VehWeapProjectile[ShockMsl] = "ShockRocket";
$VehWeapProjectile[SideWind] = "SideWindDrop";
$VehWeapProjectile[Grenades] = "FalconGrenade";
$VehWeapProjectile[ChainGun] = "AssaultVehicleBullet";
$VehWeapProjectile[StingerA] = "StingerRocketA";
$VehWeapProjectile[StingerB] = "StingerRocketB";
$VehWeapProjectile[Kamikaze] = "KamikazeBlast";
$VehWeapProjectile[KamiDive] = KamiDive;
$VehWeapProjectile[Detonate] = "KamikazeDetonate";
$VehWeapProjectile[SuperDet] = SuperDet;
$VehWeapProjectile[DropBomb] = "BomberShell";
$VehWeapProjectile[FlareDis] = "FlareDrop";
$VehWeapProjectile[ScatMine] = "MinePod";
$VehWeapProjectile[DevShell] = "DevShell";
$VehWeapProjectile[Deflects] = Deflects;
$VehWeapProjectile[ParaBomb] = "ParaBomb";
$VehWeapProjectile[CrzySpke] = "CrazySpike";
$VehWeapProjectile[RmoteDet] = "RemoteDetonate";

//-Sounds for Modes
$VehWeapSound[RocketsA] = "SoundFireFlierRocket";
$VehWeapSound[ShockMsl] = "SoundFireFlierRocket";
$VehWeapSound[SideWind] = "SoundChainTurretOff";
$VehWeapSound[SideWind,2] = "SoundMortarTurretOn";
$VehWeapSound[Grenades] = "SoundFireGrenade";
$VehWeapSound[ChainGun] = "debrisSmallExplosion";
$VehWeapSound[StingerA] = "SoundFireFlierRocket";
$VehWeapSound[StingerB] = "SoundFireFlierRocket";
$VehWeapSound[Kamikaze] = "SoundFireFlierRocket";
$VehWeapSound[KamiDive] = "SoundTargetLaser";
$VehWeapSound[Detonate] = "SoundMineActivate";
$VehWeapSound[SuperDet] = "SoundMineActivate";
$VehWeapSound[SuperDet,2] = "ForceFieldClose";
$VehWeapSound[DropBomb] = "SoundFireMortar";
$VehWeapSound[FlareDis] = "SoundFireBlaster";
$VehWeapSound[ScatMine] = "SoundChainTurretOff";
$VehWeapSound[DevShell] = "SoundFireMortar";
$VehWeapSound[DevShell,2] = "SoundFirePlasma";
$VehWeapSound[Deflects] = "SoundBeaconUse";
$VehWeapSound[ParaBomb] = "SoundChainTurretOff";
$VehWeapSound[CrzySpke] = "SoundFireGun";
$VehWeapSound[RmoteDet] = "ForceFieldClose";

//-Modes that use Lock On
//::WingMount   = Mounted on the wings and alternate sides
//::BombA       = Fire from center of the vehicle and drops down
//::BombB       = Fire from center of the vehicle and uses path
//::LockOnA     = Requires a Lock On
//::LockOnB     = Lock On supported but not required
//::LockOnC     = Lock On supported but not required bomb fall mode
//::Deflect     = Deflects and shields against all attacks for a limited time
//::Detonate    = Detonates current vehicle
//::Spike       = Sequential projectiles spawned to form a sphere
$VehWeapType[RocketsA] = WingMount;
$VehWeapType[ShockMsl] = WingMount;
$VehWeapType[SideWind] = WingMount;
$VehWeapType[Grenades] = BombB;
$VehWeapType[ChainGun] = WingMount;
$VehWeapType[StingerA] = LockOnA;
$VehWeapType[StingerB] = LockOnB;
$VehWeapType[Kamikaze] = BombB;
$VehWeapType[KamiDive] = LockOnB;
$VehWeapType[Detonate] = Detonate;
$VehWeapType[SuperDet] = Detonate;
$VehWeapType[DropBomb] = BombA;
$VehWeapType[FlareDis] = BombB;
$VehWeapType[ScatMine] = BombA;
$VehWeapType[DevShell] = BombA;
$VehWeapType[Deflects] = Deflect;
$VehWeapType[SDeflect] = Deflect;
$VehWeapType[ParaBomb] = LockOnC;
$VehWeapType[CrzySpke] = Spike;
$VehWeapType[RmoteDet] = Detonate;

//-How many weapons each Vehicle has
$VehicleWeapons[Scout] = 3;
$VehicleWeapons[Jet] = 3;
$VehicleWeapons[Kamikaze] = 4;
$VehicleWeapons[LAPC] = 3;
$VehicleWeapons[HAPC] = 3;
$VehicleWeapons[New] = 3;

function Vehicle::CheckAceMode(%this)
{
	%Kills = %this.Kills;
	%AirKills = %this.airKills;
	%SnipeX = %this.snipeKills;
	%PilotX = %this.pilotKills;
	%CheapX = %this.cheapKills;
	%Score = %this.Score;
}

function Vehicle::onWeaponSwitch(%this)
{
	%client = GameBase::getControlClient(%this);
	%data = GameBase::getDataName(%this);
	%curWeapNum = $VehicleWeaponMode[%this];
	%curWeap = $VehicleWeaponNum[%data,%curWeapNum];
	%ammo = $VehicleAmmo[%this,%curWeap];
	%delay = $ReloadRate[%curWeap];
	GameBase::playSound(%this,SoundPickUpWeapon,1);
	bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,5);
}

function Vehicle::onFire(%this)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	%data = GameBase::getDataName(%this);
	%curWeapNum = $VehicleWeaponMode[%this];
	%curWeap = $VehicleWeaponNum[%data,%curWeapNum];
	%ammo = $VehicleAmmo[%this,%curWeap];
	%delay = $ReloadRate[%curWeap];
	%weaps = $VehicleWeapons[%data];
	if($FireTime[%this] != 1) {
		if(%ammo >= 1) {
			%vel   = Item::getVelocity(%this);
			%rot1  = GameBase::getRotation(%this);                                  	   //- rotation aim forward
			%rot2  = Vector::Add(GameBase::getRotation(%this),"0 0 3.141592654");   	   //- rotation aim back
			%rot3  = Vector::Add(GameBase::getRotation(%this),"0 0 -1.570796327");  	   //- rotation aim left
			%rot4  = Vector::Add(GameBase::getRotation(%this),"0 0 1.570796327");   	   //- rotation aim right
			%rot5  = Vector::Add(GameBase::getRotation(%this),"1.570796327 0 0");   	   //- rotation aim up
			%rot6  = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0 0");  	   //- rotation aim down
			%rot7  = Vector::Add(GameBase::getRotation(%this),"-0.7853981635 0 0");		   //- rotation aim down/forward
			%rot8  = Vector::Add(GameBase::getRotation(%this),"0.7853981635 0 0");  	   //- rotation aim up/forward
			%rot9  = Vector::Add(GameBase::getRotation(%this),"-3.9269908175 0 0");            //- rotation aim down/back
			%rot10 = Vector::Add(GameBase::getRotation(%this),"3.9269908175 0 0");             //- rotation aim up/back
			%rot11 = Vector::Add(GameBase::getRotation(%this),"0 0 -0.7853981635");            //- rotation aim left/forward
			%rot12 = Vector::Add(GameBase::getRotation(%this),"0 0 0.7853981635");             //- rotation aim right/forward
			%rot13 = Vector::Add(GameBase::getRotation(%this),"0 0 -3.9269908175");            //- rotation aim left/back
			%rot14 = Vector::Add(GameBase::getRotation(%this),"0 0 3.9269908175");             //- rotation aim right/back
			%rot15 = Vector::Add(GameBase::getRotation(%this),"1.570796327 0.7853981635 0");   //- rotation aim up/right
			%rot16 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0.7853981635 0");  //- rotation aim down/right
			%rot17 = Vector::Add(GameBase::getRotation(%this),"1.570796327 -0.7853981635 0");  //- rotation aim up/left
			%rot18 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 -0.7853981635 0"); //- rotation aim down/left
			%vec1  = Vector::getFromRot(%rot1,1);
			%vec2  = Vector::getFromRot(%rot2,1);
			%vec3  = Vector::getFromRot(%rot3,1);
			%vec4  = Vector::getFromRot(%rot4,1);
			%vec5  = Vector::getFromRot(%rot5,1);
			%vec6  = Vector::getFromRot(%rot6,1);
			%vec7  = Vector::getFromRot(%rot7,1);
			%vec8  = Vector::getFromRot(%rot8,1);
			%vec9  = Vector::getFromRot(%rot9,1);
			%vec10 = Vector::getFromRot(%rot10,1);
			%vec11 = Vector::getFromRot(%rot11,1);
			%vec12 = Vector::getFromRot(%rot12,1);
			%vec13 = Vector::getFromRot(%rot13,1);
			%vec14 = Vector::getFromRot(%rot14,1);
			%vec15 = Vector::getFromRot(%rot15,1);
			%vec16 = Vector::getFromRot(%rot16,1);
			%vec17 = Vector::getFromRot(%rot17,1);
			%vec18 = Vector::getFromRot(%rot18,1);
			%vec19 = Vector::getFromRot(%rot1,7.5);
			%vec20 = Vector::getFromRot(%rot1,2.0);
			%vec21 = Vector::getFromRot(%rot6,10);
			%pos1  = getBoxCenter(%this);
			%pos2  = Vector::add(%pos1,%vec19);
			if(%curWeap == ChainGun || %curWeap == ShockMsl)
				%pos2 = Vector::add(%pos2,"0 0 0.95");
			%pos3  = Vector::add(%pos2,%vec3);
			%pos4  = Vector::add(%pos2,%vec4);
			%pos5  = Vector::add(%pos2,%vec5);
			%pos6  = Vector::add(%pos2,%vec6);
			%pos7  = Vector::add(%pos2,%vec7);
			%pos8  = Vector::add(%pos2,%vec8);
			%pos9  = Vector::add(%pos2,%vec9);
			%pos10 = Vector::add(%pos2,%vec10);
			%pos11 = Vector::add(%pos2,%vec11);
			%pos12 = Vector::add(%pos2,%vec12);
			%pos13 = Vector::add(%pos2,%vec13);
			%pos14 = Vector::add(%pos2,%vec14);
			%pos15 = Vector::add(%pos2,%vec15);
			%pos16 = Vector::add(%pos2,%vec16);
			%pos17 = Vector::add(%pos2,%vec17);
			%pos18 = Vector::add(%pos2,%vec18);
			%pos19 = Vector::add(%pos1,%vec1);
			%pos20 = Vector::add(%pos1,%vec2);
			%pos21 = Vector::add(%pos1,%vec3);
			%pos22 = Vector::add(%pos1,%vec4);
			%pos23 = Vector::add(%pos1,%vec5);
			%pos24 = Vector::add(%pos1,%vec6);
			%pos25 = Vector::add(%pos1,%vec7);
			%pos26 = Vector::add(%pos1,%vec8);
			%pos27 = Vector::add(%pos1,%vec9);
			%pos28 = Vector::add(%pos1,%vec10);
			%pos29 = Vector::add(%pos1,%vec11);
			%pos30 = Vector::add(%pos1,%vec12);
			%pos31 = Vector::add(%pos1,%vec13);
			%pos32 = Vector::add(%pos1,%vec14);
			%pos33 = Vector::add(%pos1,%vec15);
			%pos34 = Vector::add(%pos1,%vec16);
			%pos35 = Vector::add(%pos1,%vec17);
			%pos36 = Vector::add(%pos1,%vec18);
			%pos37 = Vector::add(%pos1,%vec20);
			%pos38 = Vector::add(%pos37,"0 0 -3");
			if($VehWeapProjectile[%curWeap] != "") {
				%type = $VehWeapProjectile[%curWeap];
				if(GameBase::getLOSInfo(%this,2000)) {
					if(getObjectType($los::object) == "Player") {
						if(GetTeam($los::object,%player) != Same) {
							if($VehWeapType[%curWeap] == LockOnA)
								%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos2;
							%target = $los::object;
						}
						else if($VehWeapType[%curWeap] == LockOnA)
							bottomprint(%client,"<jc><f5>Error Tracking... Wrong Team", %delay+1);
					}
					else if(getObjectType($los::object) == "Flier") {
						%LastPilot = $los::object.clLastMount;
						if(GetTeam(%LastPilot,%player) != Same && GetTeam(%LastPilot,%client) != You) {
							if($VehWeapType[%curWeap] == LockOnA)
								%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos2;
							%target = $los::object;
						}
						else if(GetTeam(%LastPilot,%player) == You && $VehWeapType[%curWeap] == LockOnA)
							bottomprint(%client,"<jc><f5>Error Tracking... Your Vehicle", 2);
						else if($VehWeapType[%curWeap] == LockOnA)
							bottomprint(%client,"<jc><f5>Error Tracking... Wrong Team", 2);
					}
					else if($VehWeapType[%curWeap] == LockOnA)
						bottomprint(%client,"<jc><f5>Could Not Acquire Lock", 2);
				}
				else if($VehWeapType[%curWeap] == LockOnA)
					bottomprint(%client,"<jc><f5>Could Not Acquire Lock", 2);
				if($VehWeapType[%curWeap] == LockOnB) {
					if(%curWeap == KamiDive) {
						%proj = "KamiDive";
						%this.KamiDive = true;
						if($KamiKazeDiveStyle == 0||$KamiKazeDiveStyle == "")
							Vehicle::dismount(%this,%mom);
						if(%target)
							schedule("Kamikaze::Dive(\""@%this@"\",\""@%target@"\",\""@True@"\");",0.1,%this);
						else
							schedule("Kamikaze::Dive(\""@%this@"\",\""@$los::position@"\",\""@False@"\");",0.1,%this);
					}
					else
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos2;
				}
				else if($VehWeapType[%curWeap] == LockOnC) {
					%trans = %rot1@" "@%vec6@" "@%rot1@" "@%pos6;
				}
				else if($VehWeapType[%curWeap] == Deflect) {
					%proj = "Deflecting";
					%this.superShield = 1.0;
					GameBase::setRechargeRate(%this,20);
					HAPC::Deflectors(%this);
					schedule(%this@".superShield = 0;",%delay,%this);
					schedule("GameBase::setRechargeRate("@%this@","@8@");",%delay,%this);
				}
				else if($VehWeapType[%curWeap] == Detonate) {
					%trans = %rot1@" "@%vec5@" "@%rot1@" "@%pos1;
					StaticShape::onDamage(%this,$KamiDiveDamageType,Kamikaze.maxDamage+0.1,%pos1,%vec1,%mom,%this);
				}
				else if($VehWeapType[%curWeap] == BombA) {
					%trans = %rot1@" "@%vec21@" "@%rot1@" "@%pos38;
				}
				else if($VehWeapType[%curWeap] == BombB) {
					%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos1;
				}
				else if($VehWeapType[%curWeap] == WingMount) {
					if($FireSide[%this] == 0 || $FireSide[%this] == "") {
						%FixVec = Vector::getFromRot(Vector::getRotAim(Vector::add(%pos3,Vector::getFromRot(%rot1,2000)),%pos3),100);
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos3;
						if($WingMountMethodFix)
							%trans = %rot1@" "@%FixVec@" "@%rot1@" "@%pos3;
						$FireSide[%this] = 1;
					}
					else if($FireSide[%this] == 1) {
						%FixVec = Vector::getFromRot(Vector::getRotAim(Vector::add(%pos4,Vector::getFromRot(%rot1,2000)),%pos4),100);
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos4;
						if($WingMountMethodFix)
							%trans = %rot1@" "@%FixVec@" "@%rot1@" "@%pos4;
						$FireSide[%this] = 0;
					}
					else { //- dont know how it got here, but just spawn center
						%FixVec = Vector::getFromRot(Vector::getRotAim(Vector::add(%pos2,Vector::getFromRot(%rot1,2000)),%pos2),100);
						%trans = %rot1@" "@%FixVec@" "@%rot1@" "@%pos2;
						$FireSide[%this] = 0;
					}
				}
				else if($VehWeapType[%curWeap] == Spike) {
					if($FireSide[%this] == 1 || $FireSide[%this] == "") {
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos19;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 2) {
						%trans = %rot1@" "@%vec2@" "@%rot1@" "@%pos20;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 3) {
						%trans = %rot1@" "@%vec3@" "@%rot1@" "@%pos21;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 4) {
						%trans = %rot1@" "@%vec4@" "@%rot1@" "@%pos22;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 5) {
						%trans = %rot1@" "@%vec5@" "@%rot1@" "@%pos23;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 6) {
						%trans = %rot1@" "@%vec6@" "@%rot1@" "@%pos24;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 7) {
						%trans = %rot1@" "@%vec7@" "@%rot1@" "@%pos25;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 8) {
						%trans = %rot1@" "@%vec8@" "@%rot1@" "@%pos26;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 9) {
						%trans = %rot1@" "@%vec9@" "@%rot1@" "@%pos27;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 10) {
						%trans = %rot1@" "@%vec10@" "@%rot1@" "@%pos28;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 11) {
						%trans = %rot1@" "@%vec11@" "@%rot1@" "@%pos29;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 12) {
						%trans = %rot1@" "@%vec12@" "@%rot1@" "@%pos30;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 13) {
						%trans = %rot1@" "@%vec13@" "@%rot1@" "@%pos31;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 14) {
						%trans = %rot1@" "@%vec14@" "@%rot1@" "@%pos32;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 15) {
						%trans = %rot1@" "@%vec15@" "@%rot1@" "@%pos33;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 16) {
						%trans = %rot1@" "@%vec16@" "@%rot1@" "@%pos34;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 17) {
						%trans = %rot1@" "@%vec17@" "@%rot1@" "@%pos35;
						$FireSide[%this]++;
					}
					else if($FireSide[%this] == 18) {
						%trans = %rot1@" "@%vec18@" "@%rot1@" "@%pos36;
						$FireSide[%this] = 1;
					}
					else { //- dont know how it got here, but just reset
						%trans = %rot1@" "@%vec1@" "@%rot1@" "@%pos19;
						$FireSide[%this] = 1;
					}
				}
			}
			if(%trans || %trans != "") {
				if(%target && ($VehWeapType[%curWeap] == LockonA||$VehWeapType[%curWeap] == LockonB||$VehWeapType[%curWeap] == LockonC) &&(getObjectType(%target) == "Player" || getObjectType(%target) == "Flier"))
					WarnLock(%target,4);
				if(%data == New)
					%proj = projectile::spawnProjectile(%type,%trans,%this,%vel,%target);
				else
					%proj = projectile::spawnProjectile(%type,%trans,%player,%vel,%target);
				$Shooter[%proj] = %client;
				$Target[%proj]  = %target;
			}
			if(%proj || %proj != "") {
				$VehicleAmmo[%this,%curWeap]--;
				%ammo = $VehicleAmmo[%this,%curWeap];
				%time = %delay+1;
				if(%ammo <= 0)
					%time = 1;
				bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,%time);
				GameBase::playSound(%this,$VehWeapSound[%curWeap],3);
				%sound2 = $VehWeapSound[%curWeap,2];
				if(%sound2 || %sound2 != "")
					schedule("GameBase::playSound("@%this@","@%sound2@",2);",0.01,%this);
			}
			$FireTime[%this] = 1;
			schedule("$FireTime["@%this@"] = 0;",%delay,%this);
		}
		else {
			GameBase::playSound(%this,SoundDryFire,3);
			$FireTime[%this] = 1;
			schedule("$FireTime["@%this@"] = 0;",0.2,%this);
		}
	}
}

//$Roll = 0.196349540875; //- 1/32 Roll
$Roll = 0.130899693916; //- 1/48 Roll
//$Roll = 0.0981747704375; //- 1/64 Roll
function Vehicle::BarrelRoll(%this)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	%data = GameBase::getDataName(%this);
	%speed = sqrt(pow(getword(Item::getVelocity(%this),0),2) + pow(getword(Item::getVelocity(%this),1),2) + pow(getword(Item::getVelocity(%this),2),2));
	if(%data != Jet)
		return;
	if(%speed <= %data.maxSpeed/3) {
		Client::sendMessage(%client,0,"You must Accelerate more before you can Barrel Roll~wError_Message.wav");
		return;
	}
	if(getWord(GameBase::getRotation(%this),1) >= 0)
		Vehicle::RollLeft(%this);
	else
		Vehicle::RollRight(%this);
	%this.lastRoll = getSimTime();
}

function Vehicle::RollLeft(%this)
{
	%rot = GameBase::getRotation(%this);
	%NewRot = Vector::Add(%rot,"0 "@$Roll@" 0");
	GameBase::setRotation(%this,%NewRot);
	if(%this.rolling == 1)
		schedule("Vehicle::RollLeft("@%this@");",0.01,%this);
}

function Vehicle::RollRight(%this)
{
	%rot = GameBase::getRotation(%this);
	%NewRot = Vector::Sub(%rot,"0 "@$Roll@" 0");
	GameBase::setRotation(%this,%NewRot);
	if(%this.rolling == 1)
		schedule("Vehicle::RollRight("@%this@");",0.01,%this);
}

function Vehicle::EndRoll(%this)
{
	%this.rolling = "";
}

function WarnLock(%target)
{
	if(getObjectType($los::object) == "Flier")
		%target = GameBase::getControlClient(%target);
	else if(getObjectType($los::object) == "Player")
		%target = GameBase::getOwnerClient(%target);
	Client::sendMessage(%target,1,"You have beened locked onto.~wError_Message.wav");
}

//- My masterpiece of Vector working, 18 vectors to form a sphere
function HAPC::Deflectors(%this)
{
	%rot1  = GameBase::getRotation(%this);                                  	   //- rotation aim forward
	%rot2  = Vector::Add(GameBase::getRotation(%this),"0 0 3.141592654");   	   //- rotation aim back
	%rot3  = Vector::Add(GameBase::getRotation(%this),"0 0 -1.570796327");  	   //- rotation aim left
	%rot4  = Vector::Add(GameBase::getRotation(%this),"0 0 1.570796327");   	   //- rotation aim right
	%rot5  = Vector::Add(GameBase::getRotation(%this),"1.570796327 0 0");   	   //- rotation aim up
	%rot6  = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0 0");  	   //- rotation aim down
	%rot7  = Vector::Add(GameBase::getRotation(%this),"-0.7853981635 0 0");		   //- rotation aim down/forward
	%rot8  = Vector::Add(GameBase::getRotation(%this),"0.7853981635 0 0");  	   //- rotation aim up/forward
	%rot9  = Vector::Add(GameBase::getRotation(%this),"-3.9269908175 0 0");            //- rotation aim down/back
	%rot10 = Vector::Add(GameBase::getRotation(%this),"3.9269908175 0 0");             //- rotation aim up/back
	%rot11 = Vector::Add(GameBase::getRotation(%this),"0 0 -0.7853981635");            //- rotation aim left/forward
	%rot12 = Vector::Add(GameBase::getRotation(%this),"0 0 0.7853981635");             //- rotation aim right/forward
	%rot13 = Vector::Add(GameBase::getRotation(%this),"0 0 -3.9269908175");            //- rotation aim left/back
	%rot14 = Vector::Add(GameBase::getRotation(%this),"0 0 3.9269908175");             //- rotation aim right/back
	%rot15 = Vector::Add(GameBase::getRotation(%this),"1.570796327 0.7853981635 0");   //- rotation aim up/right
	%rot16 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 0.7853981635 0");  //- rotation aim down/right
	%rot17 = Vector::Add(GameBase::getRotation(%this),"1.570796327 -0.7853981635 0");  //- rotation aim up/left
	%rot18 = Vector::Add(GameBase::getRotation(%this),"-1.570796327 -0.7853981635 0"); //- rotation aim down/left
	%vec1  = Vector::getFromRot(%rot1,10);
	%vec2  = Vector::getFromRot(%rot2,10);
	%vec3  = Vector::getFromRot(%rot3,10);
	%vec4  = Vector::getFromRot(%rot4,10);
	%vec5  = Vector::getFromRot(%rot5,10);
	%vec6  = Vector::getFromRot(%rot6,10);
	%vec7  = Vector::getFromRot(%rot7,10);
	%vec8  = Vector::getFromRot(%rot8,10);
	%vec9  = Vector::getFromRot(%rot9,10);
	%vec10 = Vector::getFromRot(%rot10,10);
	%vec11 = Vector::getFromRot(%rot11,10);
	%vec12 = Vector::getFromRot(%rot12,10);
	%vec13 = Vector::getFromRot(%rot13,10);
	%vec14 = Vector::getFromRot(%rot14,10);
	%vec15 = Vector::getFromRot(%rot15,10);
	%vec16 = Vector::getFromRot(%rot16,10);
	%vec17 = Vector::getFromRot(%rot17,10);
	%vec18 = Vector::getFromRot(%rot18,10);
	GameBase::playSound(%this,SoundShield,2);
	schedule("GameBase::activateShield("@%this@",\""@%vec2@"\");",0.05,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec3@"\");",0.10,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec4@"\");",0.15,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec5@"\");",0.20,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec6@"\");",0.25,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec7@"\");",0.30,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec8@"\");",0.35,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec9@"\");",0.40,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec10@"\");",0.45,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec11@"\");",0.50,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec12@"\");",0.55,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec13@"\");",0.60,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec14@"\");",0.65,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec15@"\");",0.70,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec16@"\");",0.75,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec17@"\");",0.80,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec18@"\");",0.85,%this);
	schedule("GameBase::activateShield("@%this@",\""@%vec1@"\");",0.90,%this);
	if(%this.superShield)
		schedule("HAPC::Deflectors("@%this@");",1,%this);
}

//- Ok, risky business here, gotta spawn a new vehicle because I can't manipulate the speed of one AND I have to keep it level for aim's sake
function Kamikaze::Dive(%this,%target,%bool)
{
	%mom = "0 0 50";
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%vel = Item::getVelocity(%this);
	%vec = Vector::getFromRot(%rot,10);
	%obj = newObject("","Flier","KamiDive",true);
	addToSet("MissionCleanup",%obj);
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,%rot);
	if($KamiKazeDiveStyle == 1) {
		Player::setMountObject(%this.clLastMount,%obj,1);
		Client::setControlObject(%this.clLastMount,%obj);
		%this.clLastMount.vehicle = %obj;
		%obj.clLastMount = %this.clLastMount;
	}
	Item::setVelocity(%this,"0 0 0");
	Item::setVelocity(%obj,%vel);
	Vehicle::onDestroyed(%this,%mom);
	deleteobject(%this);
	if(%bool)
		Kamikaze::Straight(%obj,%target,"Target");
	else
		Kamikaze::Straight(%obj,%target,"Pos");
	schedule("StaticShape::onDamage(\""@%obj@"\",\""@$KamiDiveDamageType@"\",\""@Kamikaze.maxDamage+0.1@"\",\""@%pos@"\",\""@%vec@"\",\""@%mom@"\",\""@%obj@"\");",20,%obj);
}

//- In the long run this will probably cause some lag... but hey, it will never last more than 20 secs
function Kamikaze::Straight(%this,%target,%type)
{
	%pos = %target;
	echo(%pos);
	if(%type == "Target")
		%pos = GameBase::getPosition(%target);
	GameBase::setRotation(%this,Vector::getRotAim(GameBase::getPosition(%this),%pos));
	schedule("Kamikaze::Straight(\""@%this@"\",\""@%target@"\",\""@%type@"\");",0.2,%this);
}

function GroundCheck(%this,%height)
{	
	GameBase::getLOSInfo(%this,200,"-1.570796327 0 0");
	%pos = GameBase::getPosition(%this);
	%dist = getword(%pos,2) - getword($los::position,2);
	if(%dist <= %height)
		DeployMineSet(%this,10);
	else
		schedule("GroundCheck("@%this@","@%height@");",0.1,%this);
}
$MineSpread = 27;
function DeployMineSet(%this,%num)
{
	for(%i = 0; %i <= %num; %i++) {
		%pos = GameBase::getPosition(%this);
		%NewPos = Vector::Add(%pos,floor(getRandom() * $MineSpread) - floor(getRandom() * $MineSpread)@" "@floor(getRandom() * $MineSpread) - floor(getRandom() * $MineSpread)@" 0");
		%obj = newObject("","Mine","antipersonelMine");
		addToSet("MissionCleanup",%obj);
		GameBase::setTeam(%obj,GameBase::getTeam($Shooter[%this]));
		GameBase::setPosition(%obj,%NewPos);
	}
}
$MaintPadTryTime = 3.0;
function MaintMine::onCollision(%this,%object)
{
	%obj = getObjectType(%object);
	if(%obj == "Flier") {
		%client = %object.clLastMount;
		%maint = $MaintPieceMain[%this];
		if(getTeam(%maint,%object) == Same) {
			%rot1 = GameBase::getRotation(%object);
			%pos1 = GameBase::getPosition(%object);
			%pos2 = GameBase::getPosition(%maint);
			%AngVec = Vector::getRotAim(%pos1,%pos2);
			%posZ = getWord(%pos1,2);
			%rotZ = getWord(%rot1,2);
			%vecZ = getWord(%AngVec,2);
			%Array = sqrt(pow(%rotZ,2));
			%dist = Vector::getDistance(%pos1,%pos2);
			if(%Array <= sqrt(pow(%vecZ,2))+$MaintPadViewArray && %Array >= sqrt(pow(%vecZ,2))-$MaintPadViewArray && %posZ > getWord(%pos2,2)+0.5 && %object.lastMaintTime + $MaintPadTryTime < getSimTime()) {
				%object.lastMaintTime = getSimTime();
				if(!%this.servicing)
					Vehicle::LandOnMaint(%object,$MaintPieceMain[%this]);
				else
					Client::sendMessage(%client,0,"Maintenance Bay Busy");
			}
		}
		else
			Client::sendMessage(%client,0,"Entering Wrong Team Maintenance Bay");
	}
}
$MaintPadViewArray = 0.2;
function Vehicle::LandOnMaint(%this,%object)
{
	%pos = GameBase::getPosition(%this);
	%client = GameBase::getControlClient(%this);
	bottomprint(%client,"<jc><f2>Vehicular Control Override. Landing Sequence Initiating...");
	GameBase::setRotation(%this,Vector::getRotAim(GameBase::getPosition(%this),GameBase::getPosition(%object)));
	%object.servicing = %this;
	%this.slowDown = getSimTime();
	Vehicle::Landing(%this,%object,3);
}

function Vehicle::Landing(%this,%object,%time)
{
	%rot1 = Vector::getRotAim(GameBase::getPosition(%this),Vector::add(GameBase::getPosition(%object),"0 0 5"));
	%rot2 = Vector::Add(GameBase::getRotation(%this),"0 0 3.141592654");
	%vec1 = Vector::getFromRot(%rot1,0.5);
	%pos1 = getBoxCenter(%this);
	%pos2 = GameBase::getPosition(%this);
	%pos3 = Vector::Add(%pos2,%vec1);
	GameBase::setPosition(%this,%pos3);
	if(%this.slowDown > getSimTime() - %time && Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object)) > 6)
		schedule("Vehicle::Landing("@%this@","@%object@","@%time@");",0.05,%this);
	else {
		GameBase::setRotation(%this,GameBase::getRotation(%object));
		GameBase::setPosition(%this,Vector::add(GameBase::getPosition(%object),"0 0 2"));
		schedule("Vehicle::CheckMaintReady("@%object@","@%this@");",1.0,%this);
		return;
	}
}

function Vehicle::CheckMaintReady(%object,%this)
{
	if(Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object)) > 5)
		return;
	if(Item::getVelocity(%object) == "0 0 0")
		Vehicle::Maintenance(%object,%this);
	else 
		schedule("Vehicle::CheckMaintReady("@%object@","@%this@");",0.2,%this);
}	

function Vehicle::Maintenance(%this,%object)
{
	%client = GameBase::getControlClient(%object);
	%player = Client::getOwnedObject(%client);
	%data = GameBase::getDataName(%object);
	%weaps = $VehicleWeapons[%data];
	for(%i = 0; %i <= %weaps; %i++)
		Vehicle::ReloadAmmo(%object,$VehicleWeaponNum[%data,%i]);
	Vehicle::RepairDmg(%object,%this);
	%lock = newObject("zap","StaticShape",MaintLock,true);
	GameBase::setPosition(%lock,Vector::add(GameBase::getPosition(%this),"0 0 1"));
	$VehicleLockDown[%object] = %lock;
	if(%data.shapeFile == "flyer")
		%size = 3;
	else if(%data.shapeFile == "hover_apc_sml")
		%size = 5;
	else if(%data.shapeFile == "hover_apc")
		%size = 8;
	else
		%size = 5;
	Maintenance::Smoke(%object,%this,%size);
}

function Vehicle::ReloadAmmo(%this,%curWeap)
{
	%data = GameBase::getDataName(%this);
	%ammo = $VehicleAmmo[%this,%curWeap];
	%need = $MaxAmmoVehicle[%data,%curWeap] - %ammo;
	%rate = $MaintRate[%curWeap];
	%time = %need / %rate;
	if(%need < %rate)
		%rate = %need;
	$VehicleAmmo[%this,%curWeap] = %ammo+%rate;
	if(%time > 0)
		schedule("Vehicle::ReloadAmmo("@%this@","@%curWeap@");",1.0,%this);
	else if($VehicleWeaponNum[%data,$VehicleWeapons[%data]] == %curWeap)
		%this.tempAllreloads = true;
}

function Vehicle::RepairDmg(%this,%maint)
{
	%data = GameBase::getDataName(%this);
	%damage = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damage-$MaintPadRate);
	if(GameBase::getDamageState(%maint) == "Enabled" && %damage > 0)
		schedule("Vehicle::RepairDmg("@%this@","@%maint@");",0.25,%this);
}

function Maintenance::Smoke(%this,%object,%size)
{
	%client = GameBase::getControlClient(%this);
	%pos = getBoxCenter(%this);
	for(%i = 0; %i < 6.283185308; %i += 0.7853981635) {
		%pos2 = Vector::add(%pos,Vector::getFromRot("0 0 "@%i,%size,0.0));
		Projectile::spawnProjectile("WorkSmoke", "0 0 1 0 0 0 0 0 1 "@%pos2,%this,"0 0 0",%client);
	}
	if(GameBase::getDamageLevel(%this) == 0 && %this.tempAllreloads == true) {
		%this.tempAllreloads = false;
		bottomprint(%client,"<jc><f2>All Systems Repaired and Reloaded.");
		deleteobject($VehicleLockDown[%this]);
		Maintenance::ReleaseVeh(%this,%object);
		%object.servicing = "";
	}
	else
		schedule("Maintenance::Smoke("@%this@","@%object@","@%size@");",1.0,%this);
}

function Maintenance::ReleaseVeh(%this,%object)
{
	//- Dunno... Maybe I'll keep it as an add on for Maps or something...?
}

//-Given two points, gives you the rotation aiming at the other point. EXAMPLE OF USE: ( GameBase::setRotation(%this,Vector::getRotAim(GameBase::getPosition(%this),GameBase::getPosition(%object))); )
function Vector::getRotAim(%pos1,%pos2,%neg)
{
	%vec = Vector::normalize(Vector::neg(Vector::sub(%pos1,%pos2)));
	if(%neg)
		%vec = Vector::normalize(Vector::sub(%pos1,%pos2));
	%rot = Vector::add(Vector::getRotation(%vec),"1.570796327 0 0");
	return %rot;
}
function Vector::Scale(%vec,%scalar)
{
	%vec = getWord(%vec,0)*%scalar@" "@getWord(%vec,1)*%scalar@" "@getWord(%vec,2)*%scalar;
	return %vec;
}

//----------------------------------------------------------------------------

$DamageScale[AllVeh, $BeamDamageType] = 0.01;
$DamageScale[AllVeh, $StingerADamageType] = 1.2;
$DamageScale[AllVeh, $StingerBDamageType] = 0.1;

$DamageScale[Scout, $ImpactDamageType] = 1.0;
$DamageScale[Scout, $BulletDamageType] = 1.0;
$DamageScale[Scout, $PlasmaDamageType] = 1.0;
$DamageScale[Scout, $EnergyDamageType] = 0.5;
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
$DamageScale[LAPC, $EnergyDamageType] = 0.5;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 0.5;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;

$DamageScale[Kamikaze, $ImpactDamageType] = 1.0;
$DamageScale[Kamikaze, $BulletDamageType] = 1.0;
$DamageScale[Kamikaze, $PlasmaDamageType] = 1.0;
$DamageScale[Kamikaze, $EnergyDamageType] = 0.5;
$DamageScale[Kamikaze, $ExplosionDamageType] = 1.0;
$DamageScale[Kamikaze, $ShrapnelDamageType] = 1.0;
$DamageScale[Kamikaze, $DebrisDamageType] = 1.0;
$DamageScale[Kamikaze, $MissileDamageType] = 1.0;
$DamageScale[Kamikaze, $LaserDamageType] = 1.0;
$DamageScale[Kamikaze, $MortarDamageType] = 1.0;
$DamageScale[Kamikaze, $BlasterDamageType] = 0.5;
$DamageScale[Kamikaze, $ElectricityDamageType] = 1.0;
$DamageScale[Kamikaze, $MineDamageType]        = 1.0;

$DamageScale[KamiDive, $ImpactDamageType] = 5.0;
$DamageScale[KamiDive, $BulletDamageType] = 5.0;
$DamageScale[KamiDive, $PlasmaDamageType] = 5.0;
$DamageScale[KamiDive, $EnergyDamageType] = 5.0;
$DamageScale[KamiDive, $ExplosionDamageType] = 5.0;
$DamageScale[KamiDive, $ShrapnelDamageType] = 5.0;
$DamageScale[KamiDive, $DebrisDamageType] = 5.0;
$DamageScale[KamiDive, $MissileDamageType] = 5.0;
$DamageScale[KamiDive, $LaserDamageType] = 5.0;
$DamageScale[KamiDive, $MortarDamageType] = 5.0;
$DamageScale[KamiDive, $BlasterDamageType] = 5.0;
$DamageScale[KamiDive, $ElectricityDamageType] = 5.0;
$DamageScale[KamiDive, $MineDamageType]        = 5.0;

$DamageScale[Jet, $ImpactDamageType] = 1.0;
$DamageScale[Jet, $BulletDamageType] = 1.0;
$DamageScale[Jet, $PlasmaDamageType] = 1.0;
$DamageScale[Jet, $EnergyDamageType] = 0.5;
$DamageScale[Jet, $ExplosionDamageType] = 1.0;
$DamageScale[Jet, $ShrapnelDamageType] = 1.0;
$DamageScale[Jet, $DebrisDamageType] = 1.0;
$DamageScale[Jet, $MissileDamageType] = 1.0;
$DamageScale[Jet, $LaserDamageType] = 1.0;
$DamageScale[Jet, $MortarDamageType] = 1.0;
$DamageScale[Jet, $BlasterDamageType] = 0.25;
$DamageScale[Jet, $ElectricityDamageType] = 1.0;
$DamageScale[Jet, $MineDamageType]        = 1.0;

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	if(%data != AirMineBob) {
		%this.shieldStrength = 0.0;
		GameBase::setRechargeRate (%this, 10);
		GameBase::setMapName (%this, "Vehicle");
	}		
	else
		GameBase::setMapName (%this, "Mine");		
	$FireTime[%this] = 0;
	$VehicleWeaponMode[%this] = 0;
	echo(%data@" added, ID: "@%this);
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage && GameBase::getDataName(%this) != AirMineBob) {
		if(getObjectType(%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") {
			if(Player::isAiControlled(%object))
				return;
			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);
			if((%armor == "larmor" || %armor == "lfemale" || %armor == "Icemor") && Vehicle::canMount(%this, %object)) {
				%weapon = Player::getMountedItem(%object,$WeaponSlot);
				if(%weapon != -1) {
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				Player::setMountObject(%object, %this, 1);
				Client::setControlObject(%client, %this);
				if(%this.drunk > 0 && %this.drunk != "") {
					echo("Drunk Driver!");
					DrunkStupidity(%this,%object,"Wreck");
				}
				playSound(GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				%object.driver = 1;
		            	%object.vehicle = %this;
				%this.clLastMount = %client;
				%data = GameBase::getDataName(%this);
				%curWeapNum = $VehicleWeaponMode[%this];
				%curWeap = $VehicleWeaponNum[%data,%curWeapNum];
				%ammo = $VehicleAmmo[%this,%curWeap];
				%delay = $ReloadRate[%curWeap];
				bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,%delay+1);
				if(%delay >= 15)
					bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,2);
			}
			else if((GameBase::getDataName(%this) != Scout) && (GameBase::getDataName(%this) != Jet) && (GameBase::getDataName(%this) != Kamikaze) && (GameBase::getDataName(%this) != New) )
			{
			 	%mountSlot = Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) 
				{
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					%this.clLastMount = %client;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound(GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
				}
			}
			else if(GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),0,"You must be a Pilot to maneuver the vehicles.~wError_Message.wav");
		}
	}
	if(GameBase::getDataName(%this) == AirMineBob)
		GameBase::setDamageLevel(%this, GameBase::getDataName(%this).maxDamage+0.1);
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
	echo(%armor);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
		}
	else if(%armor == "qarmor" || %armor == "qfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "srarmor" || %armor == "srfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "sarmor" || %armor == "sfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "parmor" || %armor == "pfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	else if(%armor == "tarmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	else if(%armor == "psarmor" || %armor == "psfemale") {
		%height = 2;
		%velocity = 120;
		%zVec = 120;
	}
	else if(%armor == "icemor") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
		%passenger.vehicle = "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passenger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
	Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
	%data = GameBase::getDataName(%this);
	if((%data == Kamikaze && !%this.KamiDive)|| %data == New)
		return;
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1) {
		%pl = Client::getOwnedObject(%cl);
		if(getObjectType(%pl) == "Player") {
			// dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				bottomprint(%cl,"Out",0.5);
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
				if(%pl.lastPack != "") {
					Player::mountItem(%pl,%pl.lastPack);		 	
					%pl.lastPack = "";					
				}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
	}
}

function Vehicle::onDestroyed(%this,%mom)
{
	%data = GameBase::getDataName(%this);
	$TeamItemCount[GameBase::getTeam(%this)@$VehicleToItem[%data]]--;
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
			%pl.vehicle = "";
		}
	$VehicleStaringAt[%this] = "";
	if(%this.KamiDive != true)
		calcRadiusDamage(%this,$VehDebrisDmgType[%data], 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
	 
}

function Vehicle::DestroyMSG(%playerId,%killerId,%type,%Veh,%special)
{
	%killerName = Client::getName(%killerId);
	%victimName = Client::getName(%playerId);
	%vehcleName = $VehicleToItem[GameBase::getDataName(%this)].description;
	if(!String::ICompare(Client::getGender(%playerId), "Male")) {
		%playerGender1 = "his";
		%playerGender2 = "he";
		%playerGender3 = "him";
	}
	else {
		%playerGender1 = "her";
		%playerGender2 = "she";
		%playerGender3 = "her";
	}
	if(!String::ICompare(Client::getGender(%killerId), "Male")) {
		%killerGender1 = "his";
		%killerGender2 = "he";
		%killerGender3 = "him";
	}
	else {
		%killerGender1 = "her";
		%killerGender2 = "she";
		%killerGender3 = "her";
	}
	%ridx = %special;
	if(%special == ""||!%special)
		%ridx = floor(getRandom() * ($numDeathMsgs - 0.01));
	%obitMsg = sprintf($VehDeathMsg[%type,%ridx],%killerName,%victimName,%vehcleName,%killerGender1, %playerGender1, %killerGender2, %playerGender2, %killerGender3, %playerGender3);
	if(!%obitMsg || %obitMsg == False)
		%obitMsg = sprintf($VehDeathMsg[$Unknown,%ridx],%killerName,%victimName,%vehcleName,%killerGender1, %playerGender1, %killerGender2, %playerGender2, %killerGender3, %playerGender3);
	if(!%killerId) {
		if(%damageType == $NukeDamageType)
			%obitMsg = sprintf($VehDeathMsg[$Nuclear,%ridx],%killerName,%vehcleName,%killerGender1,%killerGender2,%killerGender3);
		else
			%obitMsg = sprintf($VehDeathMsg[$Unknown,%ridx],%killerName,%vehcleName,%killerGender1,%killerGender2,%killerGender3);
	}
	else if(%killerId == %playerId) {
		if($deathMsg[%damageType, %ridx])
			%oopsMsg = sprintf($deathMsg[%damageType,%ridx], %victimName, %playerGender, %playerGender2, %playerGender3);
		else
			%oopsMsg = sprintf($deathMsg[-2, %ridx], %victimName, %playerGender, %playerGender2, %playerGender3);
		messageAll(0, %oopsMsg, $DeathMessageMask);
		%playerId.scoreDeaths++;
		%playerId.score--;
		Game::refreshClientScore(%playerId);
	}
	else {
		if(getteam(%playerId,%killerId) == Same) {
			%obitMsg = sprintf($VehDeathMsg[$TeamVehicleDamage,%ridx],%killerName,%victimName,%vehcleName,%killerGender1, %playerGender1, %killerGender2, %playerGender2, %killerGender3, %playerGender3);
			%killerId.score-=2;
			Game::refreshClientScore(%killerId);
		}
		else {
			messageAll(0, %obitMsg, $DeathMessageMask);
			if(%killerId.Owner != "" && %killerId.Owner != 0) {
				%killerId.Owner.scoreKills++;
				%killerId.Owner.score++;
				Game::refreshClientScore(%killerId.Owner);
			} else {
				%killerId.scoreKills++;
				%killerId.score++;
				Game::refreshClientScore(%killerId);
			}
			%playerId.scoreDeaths++; // test play mode
			Game::refreshClientScore(%playerId);
		}
	}
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object,%special)
{
	%data = GameBase::getDataName(%this);
	%Dist = Vector::getDistance(GameBase::getPosition(%this),GameBase::getPosition(%object));
	if(%type == $LaserDamageType) {
		%type = $DamageToLaser[Player::getMountedItem(%object,$WeaponSlot)];
		if(%type == "")
			%type = $LaserDamageType;
		if(GetTeam(Player::getClient(%this),%object) == "Same")
			%value = 0;
	}
	if(%type == $LPDamageType) {
		%weap = Player::getMountedItem(%object,$WeaponSlot);
		if(%Dist > $LaserFullPwrRange[%weap]) {
			%DistSpillover = %Dist - $LaserFullPwrRange[%weap];
			%rate = $LaserDeterioRate[%weap] * %DistSpillover;
			%value -= %rate;
		}
		if(%Dist <= 1.75) //- Instant kill at point blank if its a laser
			%value = 1.5;
		if(%value <= 0.0005)
			%value = 0;
	}
	else if(%type == $BoomDamageType) {
		%DamagedClient = Player::getClient(%this);
		if(%object == %DamagedClient &&($WeapMode[%object,PAttack] == 1||$WeapMode[%object,PAttack] == ""))
			%value = 0;
		else {
			%delta = %object.tempRageCount / 100;
			%value *= %delta;
			%object.tempRageCount = "";
		}	
	}
	if($VehicleSayWTF == 1)
		GameBase::setRotation(%this,Vector::getRotAim(GameBase::getPosition(%this),GameBase::getPosition(%object)));
	if($VehicleSayWTF == 2) {
		%rot0 = Vector::getRotAim(GameBase::getPosition(%this),GameBase::getPosition(%object));
		%vec1 = Vector::getFromRot(%rot0,1);
		%NewPos1 = Vector::add(GameBase::getPosition(%this),%vec1);
		GameBase::setPosition(%this,%NewPos1);
	}
	if($VehicleSayWTF == 3) {
		%rot0 = Vector::getRotAim(GameBase::getPosition(%this),GameBase::getPosition(%object));
		%vec2 = Vector::getFromRot(%rot0,-1);
		%NewPos2 = Vector::add(GameBase::getPosition(%this),%vec2);
		GameBase::setPosition(%this,%NewPos2);
	}
	if($VehicleSayWTF == 4)
		GameBase::setRotation(%this,Vector::getRotAim(GameBase::getPosition(%this),GameBase::getPosition(%object),true));
	if($damageScale[AllVeh,%type])
		%value *= $damageScale[AllVeh, %type];
	else if($damageScale[%data,%type])
		%value *= $damageScale[%data, %type];
	StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}