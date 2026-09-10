
$InvList[Glock] = 1;
$RemoteInvList[Glock] = 1;
$InvList[GlockAmmo] = 1;
$RemoteInvList[GlockAmmo] = 1;
$HelpMessage[Glock] = "A pistol with decent accuracy and medium damage.";


SoundData SoundGlock
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

BulletData GlockPellet
{
   bulletShapeName    = "breath.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;
    	soundId = SoundJetHeavy;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.40;
   damageType         = $BulletDmgType15;

   aimDeflection      = 0.003;
   muzzleVelocity     = 800.0;
   totalTime          = 2.5;
   inheritedVelocityScale = 0.0;
   isVisible          = False;

   tracerPercentage   = 0.1;
   tracerLength       = 1;


};


ExplosionData GlockExp
{
   shapeName = "bluex.dts";
   soundId   = SoundGlock;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 6.0;
   timeScale = 1.5;
   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

$ItemMax[hlarmor, Glock] = 1;
$ItemMax[hlfemale, Glock] = 1;
$ItemMax[marmor, Glock] = 1;
$ItemMax[mfemale, Glock] = 1;
$ItemMax[larmor, Glock] = 1;
$ItemMax[lfemale, Glock] = 1;
$ItemMax[earmor, Glock] = 1;
$ItemMax[efemale, Glock] = 1;
$ItemMax[harmor, Glock] = 1;
$ItemMax[uharmor, Glock] = 1;

$ItemMax[hlarmor, GlockAmmo] = 12;
$ItemMax[hlfemale, GlockAmmo] = 12;
$ItemMax[marmor, GlockAmmo] = 12;
$ItemMax[mfemale, GlockAmmo] = 12;
$ItemMax[larmor, GlockAmmo] = 12;
$ItemMax[lfemale, GlockAmmo] = 12;
$ItemMax[earmor, GlockAmmo] = 12;
$ItemMax[efemale, GlockAmmo] = 12;
$ItemMax[harmor, GlockAmmo] = 12;
$ItemMax[uharmor, GlockAmmo] = 12;



 addPluginWeapon(LaserRifle, Glock);
 $AutoUse[Glock] = True;

 $SellAmmo[GlockAmmo] = 5;
 $AmmoPackMax[GlockAmmo] = 0;
 $WeaponAmmo[Glock] = GlockAmmo;


ItemData GlockAmmo
{
	description = "Glock Ammo";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData GlockImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = GlockPellet;
	ammoType = GlockAmmo;
	accuFire = True;
	reloadTime = 0.0;
	fireTime = 0.5;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Glock
{
	description = "Glock 9mm";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "plasma";
	heading = "cSecondary Weapons";
	shadowDetailMask = 4;
	imageType = GlockImage;
	price = 250;
	showWeaponBar = true;
};

function Glock::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Glock - a nicely made 9mm pistol with good accuracy.", 2);
	}
}




