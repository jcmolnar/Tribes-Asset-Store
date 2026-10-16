
$AutoUse[DivineWave] = True;
$WeaponAmmo[DivineWave] = "";
//--------------------------------------

$InvList[DivineWave] = 0;
$RemoteInvList[DivineWave] = 0;

//--------------------------------------

RocketData DivineWaveR
{
   bulletShapeName = "fusionbolt.dts";
   explosionTag   = DivineExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 130;
   damageType       = $DivineDamageType;

   explosionRadius  = 70.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 50.0;
   acceleration     = 5.0;

   totalTime        = 0.3;
   liveTime         = 0.3;

   lightRange       = 5.0;
   lightColor       = { 0, 0, 1.0 };

   inheritedVelocityScale = 1.0;

   soundId = SoundDiscSpin;
};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, DivineWave] = 0;
$ItemMax[lfemale, DivineWave] = 0;
$ItemMax[marmor, DivineWave] = 0;
$ItemMax[mfemale, DivineWave] = 0;
$ItemMax[harmor, DivineWave] = 0;

//++++++++++++++++++++++++++++++++++++++

$DamageScale[larmor, $DivineDamageType] = 1;
$DamageScale[lfemale, $DivineDamageType] = 1;
$DamageScale[marmor, $DivineDamageType] = 1;
$DamageScale[mfemale, $DivineDamageType] = 1;
$DamageScale[harmor, $DivineDamageType] = 1;
//+++++++++++++++++++++++++++++++++++++++


ItemImageData DivineWaveImage 
{
	shapeFile = "enex";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 1.5775, 0, 0 };
	weaponType = 0;
	projectileType = DivineWaveR;
	accuFire = true;
	reloadTime = 5.0;
	fireTime = 5.0;
	minEnergy = 2;
	maxEnergy = 2;

	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0.5 };
	sfxFire = SoundTeleportPower;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData DivineWave
{
	description = "Divine Wave";
	className = "Weapon";
	shapeFile = "shield";
	hudIcon = "plasma";
        heading = "yIndalacios Weapons";
	shadowDetailMask = 4;
	imageType = DivineWaveImage;
   validateShape = false;
   validateMaterials = false;
	price = 2500;
	showWeaponBar = true;
};

function DivineWave::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Project a wave of evil to resist against the light forces.");
}

//--------------------------------------


