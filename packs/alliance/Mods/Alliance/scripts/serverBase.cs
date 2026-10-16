$ItemFavoritesKey = "base_alliance";
$Welcome="<jc><f2>Base Alliance\n http://alazane.surf-va.com/tribes/alliance.html\n\n";
$DefaultArmor[Male] = armormBaseLight;
$DefaultArmor[Female] = armorfBaseLight;

 // Initial buy list
$spawnBuyList[0] = iarmorBaseLight;
$spawnBuyList[1] = Blaster;
$spawnBuyList[2] = Plasmagun;
$spawnBuyList[3] = Beacon;
$spawnBuyList[4] = RepairKit;
$spawnBuyList[5] = Grenade;
$spawnBuyList[6] = Grenade;
$spawnBuyList[7] = Grenade;
$spawnBuyList[8] = Grenade;
$spawnBuyList[9] = Beacon;
$spawnBuyList[10] = Beacon;
$spawnBuyList[11] = Beacon;
$spawnBuyList[12] = Beacon;
$spawnBuyList[13] = TargetingLaser;
$spawnBuyList[14] = EnergyPack;
$spawnBuyList[15] = "";

function serverBase::Start()
{
   echo('>> Loading armor classes');
	exec(armorBaseLight);
	exec(armorBaseMedium);
	exec(armorBaseHeavy);
   echo('>> Loading weapons');
	exec(weaponBlaster);
	exec(weaponChaingun);
	exec(weaponPlasmaGun);
	exec(weaponGrenade);
	exec(weaponMortar);
	exec(weaponDiscLauncher);
	exec(weaponLaser);
	exec(weaponTargetLaser);
   echo('>> Loading packs');
	exec(packAmmo);
	exec(packEnergy);
	exec(packJammer);
	exec(packRepair);
	exec(packShield);
   echo('>> Loading misc');
	exec(miscBeacon);
	exec(miscGrenade);
	exec(miscMine);
	exec(miscRepairKit);
   echo('>> Loading deployable sensors');
	exec(deployMotionSensor);
	exec(deployPulseSensor);
        exec(deployCamera);
	exec(deploySensorJammer);
   echo('>> Loading deployable objects');
	exec(deploySmallInventoryStation);
	exec(deploySmallAmmoStation);
   echo('>> Loading deployable weapons');
	exec(deployTurret); 
   echo('>> Vehicles');
	exec(Vehicle);
	exec(vehicleScout);
	exec(vehicleLAPC);
	exec(vehicleHAPC);
   echo('>> Usage');
	exec(serverBase_ItemUsage);
}

function serverBase::InitializeMission()
{
         // Initialize vehicles
	vehicleScout::Initialize();
	vehicleLAPC::Initialize();
	vehicleHAPC::Initialize();

	 // Initialize deployables
	deploySmallInventoryStation::Initialize();
	deploySmallAmmoStation::Initialize();

	miscMine::Initialize();
	miscBeacon::Initialize();

	deploySensorJammer::Initialize();
	deployCamera::Initialize();
	deployPulseSensor::Initialize();
	deployMotionSensor::Initialize();

	deployTurret::Initialize();	
}