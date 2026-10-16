//.45 S&W Pistol
$InvList[Blaster] = 1;
$RemoteInvList[Blaster] = 1;
$AutoUse[Blaster] = False;
$WeaponAmmo[Blaster] = "";
$VehicleInvList[Blaster] = 1;

addWeapon(Blaster);

BulletData fusionCBolt
{
   bulletShapeName = "bullet.dts";
   explosionTag = bulletexp0;
   bulletHoleIndex = 0;
   damageClass        = 0;
   damageValue        = 0.45;
   damageType         = $BulletDamageType;
   muzzleVelocity     = 200.0;
   totalTime          = 3.5;
   liveTime           = 3.5;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 1.0;
   isVisible          = True;
   trailType = 1;
   trailWidth = 0.5;
   trailLength = 20.0;
   soundId = SoundJetLight;
};


ItemImageData BlasterImage
{
   shapeFile  = "armngun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 0.6;
        projectileType = fusionCBolt;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = false;
	sfxFire = SoundFirePlasma;
        sfxReload = SoundDiscReload;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = $InvHead[ihScv];
	description = "Beretta 92FS 9MM";
	className = "Weapon";
   shapeFile  = "armngun";
	hudIcon = "chaingun";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 50;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Beretta 92FS 9MM: <f2>A large magazine and low recoil support this pistol in close encounter fire fights.");
}

