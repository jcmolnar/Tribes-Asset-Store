
//Delta Paintball
//--------------------------------------
BulletData DeltaBUllet
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 1100.0;
   totalTime          = 2.0;
   liveTime           = 1.125;
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};
//--------------------------------------

ItemData DeltaAmmo
{
	description = "Paintballs";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
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

	sfxActivate = SoundWeaponSelect;
};

ItemData Delta
{
	description = "New:Speed Hand Gun ";
	className = "Tool";
	shapeFile = "paintgun";
	hudIcon = "paintgun";
   heading = "cMarkers";
	shadowDetailMask = 4;
	imageType = DeltaImage;
	price = 0;
	showWeaponBar = true;
};
function DeltaImage::onFire(%player,%slot) 
{
	%ammo = Player::getItemCount(%player,$WeaponAmmo[Delta]);
	if(%ammo)
	{
		%client = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%client);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("DeltaBullet",%trans,%player,%vel);
                GameBase::playSound(%player,SoundGrenadeFire,0);
		Player::decItemCount(%player,DeltaAmmo);
		Player::trigger(%player,$WeaponSlot,false);
	}
}

//Important Stuff
$ItemMax[larmor, Delta] = 1;
$ItemMax[larmor, DeltaAmmo] = 30;
$ItemMax[lfemale, Delta] = 1;
$ItemMax[lfemale, DeltaAmmo] = 30;
$InvList[Delta] = 1;
$InvList[DeltaAmmo] = 0;