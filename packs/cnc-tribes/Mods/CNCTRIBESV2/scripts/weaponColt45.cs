//Colt .45
$InvList[45] = 1;
$RemoteInvList[45] = 1;
$AutoUse[45] = False;
$WeaponAmmo[45] = "";
$VehicleInvList[45] = 1;

addWeapon(45);

BulletData 45Bolt
{
   bulletShapeName = "bullet.dts";
   explosionTag = bulletexp0;
   bulletHoleIndex = 0;
   damageClass        = 0;
   damageValue        = 0.556;
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


ItemImageData 45Image
{
   shapeFile  = "handg";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 0.6;
        projectileType = 45Bolt;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = false;
	sfxFire = SoundFirePlasma;
        sfxReload = SoundDiscReload;
	sfxActivate = SoundPickUpWeapon;
        sfxReady = SoundDiscSpin;
};

ItemData 45
{
   heading = $InvHead[ihWet];
	description = "HK .45 Mark 23";
	className = "Weapon";
   shapeFile  = "handg";
	hudIcon = "chaingun";
	shadowDetailMask = 4;
	imageType = 45Image;
	price = 50;
	showWeaponBar = true;
};

function 45::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "HK .45 Mark 23: <f2>Good weapon if you want a hole in your enemys head.");
}

