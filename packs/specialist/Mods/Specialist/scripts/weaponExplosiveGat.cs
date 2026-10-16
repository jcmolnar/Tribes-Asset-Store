$InvList[ExplosiveGat] = 1;
$RemoteInvList[ExplosiveGat] = 1;
$AutoUse[ExplosiveGat] = True;

$WeaponAmmo[ExplosiveGat] = ExplosiveGatAmmo;
$SellAmmo[ExplosiveGatAmmo] = 15;
$InvList[ExplosiveGatAmmo] = 1;
$RemoteInvList[ExplosiveGatAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, ExplosiveGat] = 0;
$ItemMax[reconfemalearmor, ExplosiveGat] = 0;
$ItemMax[espionagearmor, ExplosiveGat] = 0;
$ItemMax[espionagefemalearmor, ExplosiveGat] = 0;
$ItemMax[engineerarmor, ExplosiveGat] = 1;
$ItemMax[engineerfemalearmor, ExplosiveGat] = 1;
$ItemMax[infantryarmor, ExplosiveGat] = 1;
$ItemMax[infantryfemalearmor, ExplosiveGat] = 1;
$ItemMax[falloutarmor, ExplosiveGat] = 0;
$ItemMax[falloutfemalearmor, ExplosiveGat] = 0;
$ItemMax[demolitionsarmor, ExplosiveGat] = 1;
$ItemMax[assaultarmor, ExplosiveGat] = 1;
$ItemMax[artilleryarmor, ExplosiveGat] = 0;
$ItemMax[commanderarmor, ExplosiveGat] = 1;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, ExplosiveGatAmmo] = 0;
$ItemMax[reconfemalearmor, ExplosiveGatAmmo] = 0;
$ItemMax[espionagearmor, ExplosiveGatAmmo] = 0;
$ItemMax[espionagefemalearmor, ExplosiveGatAmmo] = 0;
$ItemMax[engineerarmor, ExplosiveGatAmmo] = 35;
$ItemMax[engineerfemalearmor, ExplosiveGatAmmo] = 35;
$ItemMax[infantryarmor, ExplosiveGatAmmo] = 50;
$ItemMax[infantryfemalearmor, ExplosiveGatAmmo] = 50;
$ItemMax[falloutarmor, ExplosiveGatAmmo] = 0;
$ItemMax[falloutfemalearmor, ExplosiveGatAmmo] = 0;
$ItemMax[demolitionsarmor, ExplosiveGatAmmo] = 60;
$ItemMax[assaultarmor, ExplosiveGatAmmo] = 80;
$ItemMax[artilleryarmor, ExplosiveGatAmmo] = 0;
$ItemMax[commanderarmor, ExplosiveGatAmmo] = 70;

ExplosionData specialistSmallExp
{
   shapeName = "tumult_small.dts";
   soundId   = debrisSmallExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeScale = 1.5;

   timeZero = 0.150;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0,  0.0 };
   colors[1]  = { 1.0, 0.63, 0.0 };
   colors[2]  = { 1.0, 0.63, 0.0 };
   radFactors = { 0.0, 1.0, 0.9 };
};

BulletData ExplosiveRound 
{
  bulletShapeName = "bullet.dts";
  explosionTag = specialistSmallExp;

  damageClass = 1; // 1 = radius
  damageValue = 0.25;
  damageType = $ExplosiveGatDamageType;
  explosionRadius = 6.0;

  aimDeflection = 0.005;
  muzzleVelocity = 150.0;
  totalTime = 3.0;
  liveTime = 2.0;
  lightRange = 3.0;
  lightColor = { 1.0, 1.0, 0.0};

  inheritedVelocityScale = 0.1;

  isVisible = true;
  tracerPercentage = 1.0;
  tracerLength = 90;

};

ItemData ExplosiveGatAmmo
{
	description = "Explosive Round";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 10;
};

SoundData SoundFireExpGat
{
   wavFileName = "Grenade.wav";
   profile = Profile3dNearLoop;
};


ItemImageData ExplosiveGatImage 
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 1.6, 0 };

	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0.8;
	spinUpTime = 0.2;
	spinDownTime = 1;
	fireTime = 0.5;

	ammoType = ExplosiveGatAmmo;
	projectileType = ExplosiveRound;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 1.0, 0.0 };
	sfxFire = SoundFireExpGat;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData ExplosiveGat 
{
	description = "Explosive Gatling";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ExplosiveGatImage;
	price = 275;
	showWeaponBar = true;
};

function ExplosiveGat::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Explosive Gatling fires small explosive rounds.");
	}
}
