//--------------------------------------

$AutoUse[Parachuteart] = True;
$Use[Parachuteart] = True;
$WeaponAmmo[Parachuteart] = "";

//--------------------------------------

$InvList[Parachuteart] = 0;
$RemoteInvList[Parachuteart] = 0;

//--------------------------------------

ItemImageData ParachuteartImage
{
   shapeFile  = "elevator_6x6_octagon";//B
	mountPoint = 0;//U
	mountOffset = { 0, 0, 0 };//L
	mountRotation = { 0, 0, 0 };//E

	weaponType = 0; // Single Shot//T
	reloadTime = 0;//Z
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;

//	projectileType = Cutstab;
	accuFire = true;

	sfxActivate = SoundFlagPickup;
};

ItemData Parachuteart
{
   heading = "kStuff";
	description = "Para";
	className = "Weapon";
   shapeFile  = "elevator_6x6_octagon";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = Parachuteart;
	price = 85;
	showWeaponBar = true;
};