$ItemMax[larmor, ControlPack] = 1;
$ItemMax[qarmor, ControlPack] = 1;
$ItemMax[srarmor, ControlPack] = 1;
$ItemMax[sarmor, ControlPack] = 1;
$ItemMax[marmor, ControlPack] = 1;
$ItemMax[parmor, ControlPack] = 1;
$ItemMax[harmor, ControlPack] = 1;
$ItemMax[tarmor, ControlPack] = 1;
$ItemMax[lfemale, ControlPack] = 1;
$ItemMax[qfemale, ControlPack] = 1;
$ItemMax[srfemale, ControlPack] = 1;
$ItemMax[sfemale, ControlPack] = 1;
$ItemMax[mfemale, ControlPack] = 1;
$ItemMax[pfemale, ControlPack] = 1;
$TeamItemMax[ControlPack] = 2;
$TeamItemMax[NewVehicle] = 2;

ItemImageData ControlPackImage
{
	shapeFile = "Mortarammo";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ControlPack
{
	description = "Remote Pack";
	shapeFile = "Mortarammo";
	className = "Backpack";
	heading = "fDeployables";
	imageType = ControlPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "Plasma";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ControlPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function ControlPack::onDeploy(%player,%item, %pos)
{
	%client = Player::getClient(%player);	
	if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[NewVehicle]) {
		%rot = "1.570796327 0 0";
		if( LOSCheck(%player, 10000, %rot) == FALSE ) {
			%rot = GameBase::getRotation(%player);
			%pos = GameBase::getPosition(%player);
			%vec = Vector::getfromrot(%rot,2);
			%NewPos = Vector::add(%pos,%vec);
			%obj = newObject("","Flier","New",true);
			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%client));
			GameBase::setPosition(%obj, %NewPos);
			GameBase::setRotation(%obj, %rot);
			Client::setControlObject(%client,%obj);
			%obj.clLastMount = %client;
			%player.driver = 1;
			%player.vehicle = %obj;
			%curWeap = $VehicleWeaponNum[New,0];
			%ammo = $VehicleAmmo[%obj,%curWeap];
			%delay = $ReloadRate[%curWeap];
			bottomprint(%client,"<jl><f1>Vehicle Weapon:<jc><f2>"@$WeapMountMSG[%curWeap]@"<jr><f5>"@%ammo,%delay+1);
			Player::trigger(%player,$BackpackSlot,false);
			Player::decItemCount(%player,ControlPack);
		}
		else
			remoteEval(%client, BP, "<jc> You need more head room.", 3);
	}
	else
		Client::sendMessage(%client,0,"You can't deploy any more Remotes.");
}

FlierData New
{
	explosionId = turretExp;
	debrisId = flashDebrisMedium;
	className = "Vehicle";
   	shapeFile = "remoteturret";
   	shieldShapeName = "shotgunex";
	mass = 1.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 0.75;
	maxPitch = 0.75;
	maxSpeed = 30;
	minSpeed = -30;
	lift = 0.75;
	maxAlt = 35;
	maxVertical = 10;
	maxDamage = 0.3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;
	groundDamageScale = 0.50;
	reloadDelay = 2.0;
	repairRate = 1.0;
	ramDamage = 0.01;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundHFootRHard;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundShellHilight;
	dismountSound = SoundShellClick;
	idleSound = SoundSnow;
	moveSound = SoundNewFlyerIdle;
	visibleDriver = false;
	driverPose = 23;
	description = "Remote";
};

$DamageScale[New, $ImpactDamageType] = 0.0;
$DamageScale[New, $BulletDamageType] = 2.0;
$DamageScale[New, $PlasmaDamageType] = 3.0;
$DamageScale[New, $EnergyDamageType] = 3.0;
$DamageScale[New, $ExplosionDamageType] = 1.0;
$DamageScale[New, $ShrapnelDamageType] = 1.0;
$DamageScale[New, $DebrisDamageType] = 1.0;
$DamageScale[New, $MissileDamageType] = 3.0;
$DamageScale[New, $LaserDamageType] = 5.0;
$DamageScale[New, $MortarDamageType] = 1.0;
$DamageScale[New, $BlasterDamageType] = 3.0;
$DamageScale[New, $ElectricityDamageType] = 3.0;
$DamageScale[New, $MineDamageType] = 1.0;

$VehicleInvList[ControlPack] = 1;
$InvList[ControlPack] = 1;
$VehicleToItem[New] = NewVehicle;
$DataBlockName[NewVehicle] = New;