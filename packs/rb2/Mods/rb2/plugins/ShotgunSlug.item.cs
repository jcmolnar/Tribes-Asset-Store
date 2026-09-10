
$InvList[ShotgunSlug] = 1;
$RemoteInvList[ShotgunSlug] = 1;
$InvList[ShotgunSlugAmmo] = 1;
$RemoteInvList[ShotgunSlugAmmo] = 1;
$HelpMessage[ShotgunSlug] = "Fires a couple of slug rounds at your target.";


SoundData SoundShotgunSlug
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

BulletData ShotgunSlugPellet
{
   bulletShapeName    = "breath.dts";
   explosionTag       = BigBulletExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.9;
   damageType         = $BulletDmgType10;

   aimDeflection      = 0.010;
   muzzleVelocity     = 325.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;
    	soundId = SoundJetHeavy;
   tracerPercentage   = 0.1;
   tracerLength       = 1;


};

ExplosionData ShotgunSlugExp
{
   shapeName = "shockwave.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = true;
   lightRange = 6.0;
   timeScale = 0.5;
   timeZero = 0.250;
   timeOne  = 0.650;

   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

$ItemMax[hlarmor, ShotgunSlug] = 1;
$ItemMax[hlfemale, ShotgunSlug] = 1;
$ItemMax[marmor, ShotgunSlug] = 1;
$ItemMax[mfemale, ShotgunSlug] = 1;
$ItemMax[larmor, ShotgunSlug] = 1;
$ItemMax[lfemale, ShotgunSlug] = 1;
$ItemMax[earmor, ShotgunSlug] = 1;
$ItemMax[efemale, ShotgunSlug] = 1;
$ItemMax[harmor, ShotgunSlug] = 1;
$ItemMax[uharmor, ShotgunSlug] = 1;

$ItemMax[hlarmor, ShotgunSlugAmmo] = 10;
$ItemMax[hlfemale, ShotgunSlugAmmo] = 10;
$ItemMax[marmor, ShotgunSlugAmmo] = 30;
$ItemMax[mfemale, ShotgunSlugAmmo] = 30;
$ItemMax[larmor, ShotgunSlugAmmo] = 20;
$ItemMax[lfemale, ShotgunSlugAmmo] = 20;
$ItemMax[earmor, ShotgunSlugAmmo] = 30;
$ItemMax[efemale, ShotgunSlugAmmo] = 30;
$ItemMax[harmor, ShotgunSlugAmmo] = 35;
$ItemMax[uharmor, ShotgunSlugAmmo] = 40;



 addPluginWeapon(LaserRifle, ShotgunSlug);
 $AutoUse[ShotgunSlug] = True;

 $SellAmmo[ShotgunSlugAmmo] = 5;
 $AmmoPackMax[ShotgunSlugAmmo] = 20;
 $WeaponAmmo[ShotgunSlug] = ShotgunSlugAmmo;


ItemData ShotgunSlugAmmo
{
	description = "Shotgun Slugs";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData ShotgunSlugImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	// projectileType = ShotgunPellet;
	ammoType = ShotgunSlugAmmo;
	accuFire = True;
	reloadTime = 1.5;
	fireTime = 0.2;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData ShotgunSlug
{
	description = "Slug Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	heading = "cSecondary Weapons";
	shadowDetailMask = 4;
	imageType = ShotgunSlugImage;
	price = 250;
	showWeaponBar = true;
};

function ShotgunSlug::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Double Barrelled Shotgun with slugs - Kill an elephant.", 2);
	}
}

function ShotgunSlugImage::onFire(%player, %slot)
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[ShotgunSlug]);
	
	if (%AmmoCount)
	 {
   		 playSound(turretExplosion,GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("ShotgunSlugPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunSlugPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("GunFlame",%trans,%player,%vel);
		 Projectile::spawnProjectile("GunFlame",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[ShotgunSlug],1);
	 }
	 else
	 {
	 	playSound(SoundPackFail,GameBase::getPosition(%player));
	 	Player::trigger(%player,$WeaponSlot,false);
	 	Client::sendMessage(Player::getClient(%player), 0,"Shotgun is outta ammo!");
	 } 
}