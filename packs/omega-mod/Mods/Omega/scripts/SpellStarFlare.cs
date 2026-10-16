
$AutoUse[StarFlare] = True;
$WeaponAmmo[StarFlare] = "";
//--------------------------------------

$InvList[StarFlare] = 0;
$RemoteInvList[StarFlare] = 0;


//--------------------------------------

BulletData StarFlar
{
   bulletShapeName    = "pyrm8.dts";
   validateShape      = false;
   explosionTag       = GrenadeExp;
   expRandCycle       = 1;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.5;
   damageType         = $StarDamageType;

   explosionRadius  = 40;
   aimDeflection      = 0.07;
   muzzleVelocity     = 70.0;
   totalTime          = 300.0;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

};

//++++++++++++++++++++++++++++++++++++++


$ItemMax[larmor, StarFlare] = 0;
$ItemMax[lfemale, StarFlare] = 0;
$ItemMax[marmor, StarFlare] = 0;
$ItemMax[mfemale, StarFlare] = 0;
$ItemMax[harmor, StarFlare] = 0;

//++++++++++++++++++++++++++++++++++++++
$DamageScale[larmor, $StarDamageType] = 1;
$DamageScale[lfemale, $StarDamageType] = 1;
$DamageScale[marmor, $StarDamageType] = 1;
$DamageScale[mfemale, $StarDamageType] = 1;
$DamageScale[harmor, $StarDamageType] = 1;
//+++++++++++++++++++++++++++++++++++++++


ItemImageData StarFlareImage 
{
	shapeFile = "shield_large";
	mountPoint = 0;
	mountOffset = { 0, 0, 600};
	mountRotation = { -1.5775, 0, 0 };
	weaponType = 0;
	ammoType = StarFlareAmmo;
	accuFire = true;
	reloadTime = 10.0;
	fireTime = 10.0;
	minEnergy = 36;
	maxEnergy = 36;

	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0, 1.0, 0 };
	sfxFire = SoundWindAmbient;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData StarFlare
{
	description = "Star Flare";
	className = "Weapon";
	shapeFile = "plasmabolt";
	hudIcon = "plasma";
        heading = "yIndalacios Weapons";
	shadowDetailMask = 4;
	imageType = StarFlareImage;
   validateShape = false;
   validateMaterials = false;
	price = 2500;
	showWeaponBar = true;
};

function StarFlareImage::onFire(%player,%slot)
{
	for(%i = 0; %i < 64; %i++) //thats gonna kick ass
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("StarFlar",%trans,%player,%vel);
	}
                messageAll(1,"[Star Flare]~wind2");
}

function StarFlare::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Make stars explode upon your command to shower your enemy with their deadly solar flare packets");
}

//--------------------------------------


