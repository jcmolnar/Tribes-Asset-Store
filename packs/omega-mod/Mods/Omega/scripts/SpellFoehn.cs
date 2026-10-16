
$AutoUse[FoehnWind] = True;
$WeaponAmmo[FoehnWind] = "";
//--------------------------------------

$InvList[FoehnWind] = 0;
$RemoteInvList[FoehnWind] = 0;

//--------------------------------------

RocketData FoehnWave
{
   bulletShapeName = "plasmawall.dts";
   explosionTag   = DiscExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.3;
   damageType       = $FoehnDamageType;

   explosionRadius  = 300.5;
   kickBackStrength = -300.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 50.0;
   acceleration     = 5.0;

   totalTime        = 80.0;
   liveTime         = 80.0;

   lightRange       = 5.0;
   lightColor       = { 0, 0, 1.0 };

   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;
   trailLength = 15000;
   trailWidth  = 700.0;

   soundId = SoundDiscSpin;
};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, FoehnWind] = 1;
$ItemMax[lfemale, FoehnWind] = 1;
$ItemMax[marmor, FoehnWind] = 0;
$ItemMax[mfemale, FoehnWind] = 0;
$ItemMax[harmor, FoehnWind] = 0;

//++++++++++++++++++++++++++++++++++++++

$DamageScale[larmor, $FoehnDamageType] = 1;
$DamageScale[lfemale, $FoehnDamageType] = 1;
$DamageScale[marmor, $FoehnDamageType] = 1;
$DamageScale[mfemale, $FoehnDamageType] = 1;
$DamageScale[harmor, $FoehnDamageType] = 1;
//+++++++++++++++++++++++++++++++++++++++




ItemImageData FoehnWindImage 
{
	shapeFile = "shotgunex";
	mountPoint = 0;
	mountOffset = { 0, 0, 0};
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	projectileType = FoehnWave;
	accuFire = true;
	reloadTime = 5.0;
	fireTime = 5.0;
	minEnergy = 54;
	maxEnergy = 54;


	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundWindGust;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData FoehnWind
{
	description = "Foehn Spell";
	className = "Weapon";
	shapeFile = "shield";
	hudIcon = "plasma";
        heading = "yIndalacios Weapons";
	shadowDetailMask = 4;
	imageType = FoehnWindImage;
   validateShape = false;
   validateMaterials = false;
	price = 2500;
	showWeaponBar = true;
};

function FoehnWind::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Apply knowledge into using the wind as a 'razor' that blows at about 600mph in a jet stream soo thin it can slice through enemys");
}

function FoehnWindImage::onFire(%player,%slot)
{
	}
               		messageAll(1,"[Foehn]");

//--------------------------------------


