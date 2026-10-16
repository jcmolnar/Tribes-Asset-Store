//PORT-OFF: echo("Loading gay weapons.....");
//Server Settings, needed for weapons to fire Correctly.. 
$pref::PacketRate = "30";
$pref::PacketSize = "500";
$AutoUse[LiLPOOmkii] = False;
$AutoUse[TaserRifle] = False;
$AutoUse[m16] = False;

$WeaponAmmo[LiLPOOmkii] = "LiLPOOmkiiammo";
$WeaponAmmo[TaserRifle] = "";
$WeaponAmmo[m16] = "m16ammo";

$SellAmmo[LiLPOOmkiiAmmo] = 50;
$SellAmmo[m16Ammo] = 50;

$ItemMax[larmor, m16] = 1;
$ItemMax[larmor, m16ammo] = 999;
$ItemMax[larmor, LiLPOOmkii] = 1;
$ItemMax[larmor, LiLPOOmkiiAmmo] = 500;
$ItemMax[larmor, TaserRifle] = 1;
$ItemMax[marmor, m16] = 1;
$ItemMax[marmor, m16ammo] = 999;
$ItemMax[marmor, LiLPOOmkii] = 1;
$ItemMax[marmor, LiLPOOmkiiAmmo] = 500;
$ItemMax[marmor, TaserRifle] = 1;
$ItemMax[harmor, m16] = 1;
$ItemMax[harmor, m16ammo] = 999;
$ItemMax[harmor, LiLPOOmkii] = 1;
$ItemMax[harmor, LiLPOOmkiiAmmo] = 250;
$ItemMax[harmor, TaserRifle] = 1;
$ItemMax[lfemale, m16] = 1;
$ItemMax[lfemale, m16ammo] = 999;
$ItemMax[lfemale, LiLPOOmkii] = 1;
$ItemMax[lfemale, LiLPOOmkiiAmmo] = 500;
$ItemMax[lfemale, TaserRifle] = 1;
$ItemMax[mfemale, m16] = 1;
$ItemMax[mfemale, m16ammo] = 999;
$ItemMax[mfemale, LiLPOOmkii] = 1;
$ItemMax[mfemale, LiLPOOmkiiAmmo] = 500;
$ItemMax[mfemale, TaserRifle] = 1;


$InvList[TaserRifle] = 1;
$RemoteInvList[TaserRifle] = 1;
$InvList[LiLPOOmkii] = 1; 
$InvList[LiLPOOmkiiAmmo] = 1;
$RemoteInvList[LiLPOOmkii] = 1; 
$RemoteInvList[LiLPOOmkiiAmmo] = 1;
$InvList[m16] = 1; 
$InvList[m16Ammo] = 1;
$RemoteInvList[m16] = 1; 
$RemoteInvList[m16Ammo] = 1;

ItemImageData TaserRifleImage
{
        shapeFile = "sniper";
        mountPoint = 0;

        weaponType = 0; // 2,Sustained
        projectileType = TaserRfLaser;
        accuFire = true;
        minEnergy = 1;
        maxEnergy = 15;//brightness of beamhere
        reloadTime = 0.08;

        //lightType   = 3;  // Weapon Fire
        //lightRadius = 3;
        //lightTime   = 0.08;
        //lightColor = { 0.4, 0, 0.6 };

        sfxFire     = SoundBeaconUse;
        sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundEnergyPackOn;
};

//PORT-OFF: echo("I think I'm gonna puke....");

ItemData TaserRifle
{
        description   = "Taser Rifle";
        className     = "Weapon";
        shapeFile     = "sniper";
        hudIcon       = "sniper";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType     = TaserRifleImage;
        price         = 100;
        showWeaponBar = true;
};

ItemData m16Ammo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData m16Image
{	
	mountRotation = { 0, 0.785, 0 };
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.5;
	//spinDownTime = 3;
	fireTime = 0.005;

	ammoType = m16ammo;
	projectileType = m16bullet;
	accuFire = true;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData m16
{
	description = "LiL POO mki";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = m16Image;
	price = 125;
	showWeaponBar = true;
};

ItemData LiLPOOmkiiAmmo
{
	description = "Bullet mkii";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData LiLPOOmkiiImage
{
	shapeFile = "sniper";
	mountPoint = 0;    

	weaponType = 0; // Spinning
	mountRotation = { 0, 0.785, 0 }; 
	reloadTime = 0.01;
	//spinUpTime = 0.5;
	//spinDownTime = 3;
	fireTime = 0.01;

	ammoType = LiLPOOmkiiAmmo;
	projectileType = LiLPOOmkiiBullet;
	accuFire = true;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData LiLPOOmkii
{
	description = "LiL POO mkii";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LiLPOOmkiiImage;
	price = 125;
	showWeaponBar = true;
};

//PORT-OFF: echo("Unfortunately, gay weapons loaded successfully...");