
//Delta Paintball
//--------------------------------------
BulletData DeltaBUllet
{
   bulletShapeName    = "laserhit.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 500.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 50.0, 0.0, 0.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------
ItemImageData DL2Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, -0.4, -0.26 }; //-  left-right, back-front, up-down
	mountRotation = { -3.05, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData DL2
{
	description = "DL2";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = DL2Image;
	showWeaponBar = false;
};


ItemData DeltaAmmo
{
	description = "Paintballs";
   heading = $InvHead[ihPbs];
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData DL1Image
{
	shapeFile = "energygun";
	mountPoint = 0; 
	mountOffset = { 0, -0.10, -0.08 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData DL1
{
	description = "DL1";
	className = "Weapon";
	shapeFile = "energygun";
	shadowDetailMask = 4;
	imageType = DL1Image;
	showWeaponBar = false;
};

ItemImageData DeltaImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
        mountOffset = { 0, 0, 0 };//-  left-right, back-front, up-down

	weaponType = 0; // Single Shot
	ammoType = DeltaAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.0;
	//projectileType = DeltaBullet;

	sfxFire = bigExplosion4;
	sfxActivate = SoundWeaponSelect;
};


ItemData Delta
{
	description = "ADG MiniMag";
	className = "weapon";
	shapeFile = "paintgun";
	hudIcon = "paintgun";
   heading = $InvHead[ihGun];
	shadowDetailMask = 4;
	imageType = DeltaImage;
	price = 0;
	showWeaponBar = true;
};

function DeltaImage::onFire(%player, %slot) 
{
	%trans = LabRat::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rand = getRandom();
	if (%rand <= 0.2)
		%proj = Projectile::spawnProjectile("DeltaBullet",%trans,%player,%vel);
	else
		%proj = Projectile::spawnProjectile("DeltaBullet",%trans,%player,%vel);

	coEject(%proj);
	Player::decItemCount(%player, DeltaAmmo, 1);

}
function Delta::onMount(%player,%item)
{
	Player::mountItem(%player, DL1, 4);
	Player::mountItem(%player, DL2, 5);
}

function Delta::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
}

//Important Stuff
$ItemMax[larmor, Delta] = 1;
$ItemMax[larmor, DeltaAmmo] = 250;
$ItemMax[lfemale, Delta] = 1;
$ItemMax[lfemale, DeltaAmmo] = 250;
$InvList[Delta] = 1;
$InvList[DeltaAmmo] = 0;