
//Delta Paintball
//--------------------------------------
BulletData DeltaBUllet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;

   aimDeflection      = 0.003;
   muzzleVelocity     = 1000.0;
   totalTime          = 2.0;
   liveTime           = 1.125;
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//-------------------------------------- Admin Manip
BulletData DeltaBUlletM
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = paintsplatExp;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $BlasterDamageType;

   aimDeflection      = 0.003 * $PB::Menu::ManipAim;
   muzzleVelocity     = 1000.0;
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
	price = 0;
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
	description = "Psycho Ballistics Delta .68";
	className = "Tool";
	shapeFile = "paintgun";
	hudIcon = "paintgun";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DeltaImage;
	price = 120;
	showWeaponBar = true;
};
function DeltaImage::onFire(%player,%slot) 
{
	checkFireTime(%player);

	%ammo = Player::getItemCount(%player,$WeaponAmmo[Delta]);
	if(%ammo)
	{
		%client	= Player::getClient(%player);
		%trans	= GameBase::getMuzzleTransform(%client);
		%vel	= Item::getVelocity(%player);
		%manip	= "";

		if (%client.manipAim)
			%manip = "M";

		Projectile::spawnProjectile("DeltaBullet" @ %manip, %trans, %player, %vel);
                GameBase::playSound(%player, SoundGrenadeFire, 0);
		Player::decItemCount(%player, DeltaAmmo);
		Player::trigger(%player, $WeaponSlot, false);
	}
}

//Important Stuff
$ItemMax[larmor, Delta] = 1;
$ItemMax[larmor, DeltaAmmo] = $PB::SpawnAmmoMax;
$ItemMax[lfemale, Delta] = 1;
$ItemMax[lfemale, DeltaAmmo] = $PB::SpawnAmmoMax;
$InvList[Delta] = 1;
$InvList[DeltaAmmo] = 0;