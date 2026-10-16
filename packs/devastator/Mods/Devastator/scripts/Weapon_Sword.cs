//----------------------------------------------

BulletData SwordBullet
{
	bulletShapeName    = "breath.dts";
	explosionTag       = BreathExp;
	mass               = 0.5;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 1.5;
	damageType         = $SwordDamageType;
	muzzleVelocity     = 30.0;
	totalTime          = 0.1;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	tracerPercentage   = 1.0;
	tracerLength       = 50;
};

//----------------------------------------------------------------------------

ItemImageData SwordImage
{
	shapeFile = "Rocket";
	mountRotation = {-1.575, 0, 0};
	mountPoint = 0;
	weaponType = 0; // Single Shot
        mountOffset = { -0.1, -0.1, 0 };
	minEnergy = 0;
	maxEnergy = 0;
        accuFire = true;
        reloadTime = 0.8;
        fireTime = 0.2;

        lightType = 3;  // Weapon Fire
        lightRadius = 0;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };

        sfxActivate = SoundPickUpWeapon;
        sfxFire = SoundThrowItem;
};

ItemData Sword
{
	description = "Flame Sword";
	className = "Weapon";
	shapeFile = "Rocket";
	hudIcon = "plasma";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SwordImage;
	price = 175;
	showWeaponBar = true;
   	validateShape = true;
};
$SwordAnim = 6; //- Jump Slash Attack
function SwordImage::onFire(%player,%slot)
{
	Weapon::onFire(%player,SwordBullet);
	Player::setAnimation(%player,$SwordAnim);
}

//--------------------------------------------------------
	$InvList[Sword] = 1;
	$RemoteInvList[Sword] = 1;

	$ItemMax[larmor, Sword] = 0;
	$ItemMax[marmor, Sword] = 0;
	$ItemMax[harmor, Sword] = 1;
	$ItemMax[qarmor, Sword] = 0;
	$ItemMax[tarmor, Sword] = 1;
	$ItemMax[sarmor, Sword] = 0;
	$ItemMax[srarmor, Sword] = 0;
	$ItemMax[parmor, Sword] = 1;
	$ItemMax[lfemale, Sword] = 0;
	$ItemMax[mfemale, Sword] = 0;
	$ItemMax[qarmor, Sword] = 0;
	$ItemMax[sarmor, Sword] = 0;
	$ItemMax[srarmor, Sword] = 0;
	$ItemMax[parmor, Sword] = 1;