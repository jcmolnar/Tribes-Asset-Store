BulletData TazerLaser
{
	bulletShapeName    = "enbolt.dts";
	explosionTag       = energyExp;
	mass               = 0.75;

	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0;
	damageType         = $TazerDamageType;

	aimDeflection      = 0;
	muzzleVelocity     = 30.0;
	totalTime          = 0.35;
	inheritedVelocityScale = 0.5;
	isVisible          = true;
};

function TazerLaser::onAdd(%this)
{
	//- DC, if you want you can add a schedule to kill the proj after being alive for how many secs... this way it will explode rather than disapear
}
//----------------------------------------------------------------------------

ItemImageData TazerImage
{
	shapeFile = "PaintGun";
	mountPoint = 0;
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	projectileType = TazerLaser;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.1;
	maxenergy = 10.0;
	minenergy = 50.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Tazer
{
	description = "Tazer";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = TazerImage;
	price = 375;
	showWeaponBar = true;
};

//--------------------------------------------------------
	$InvList[Tazer] = 1;
	$RemoteInvList[Tazer] = 1;

	$ItemMax[larmor, Tazer] = 0;
	$ItemMax[marmor, Tazer] = 0;
	$ItemMax[harmor, Tazer] = 0;
	$ItemMax[qarmor, Tazer] = 1;
	$ItemMax[tarmor, Tazer] = 0;
	$ItemMax[sarmor, Tazer] = 0;
	$ItemMax[srarmor, Tazer] = 0;
	$ItemMax[parmor, Tazer] = 0;
	$ItemMax[lfemale, Tazer] = 0;
	$ItemMax[mfemale, Tazer] = 0;
	$ItemMax[qfemale, Tazer] = 1;
	$ItemMax[sfemale, Tazer] = 0;
	$ItemMax[srfemale, Tazer] = 0;
	$ItemMax[pfemale, Tazer] = 0;
	$ItemMax[IceMor, Tazer] = 1;
