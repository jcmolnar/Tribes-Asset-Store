
$InvList[SPAS] = 1;
$RemoteInvList[SPAS] = 1;
$InvList[SPASAmmo] = 1;
$RemoteInvList[SPASAmmo] = 1;
$HelpMessage[SPAS] = "Fires shotgun shells at a high fire rate.";


SoundData SoundSPAS
{
	wavFilename = "explo3.wav";
	profile = Profile3dLudicrouslyFar;
};

ExplosionData SPASExp
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

$ItemMax[hlarmor, SPAS] = 1;
$ItemMax[hlfemale, SPAS] = 1;
$ItemMax[marmor, SPAS] = 1;
$ItemMax[mfemale, SPAS] = 1;
$ItemMax[larmor, SPAS] = 1;
$ItemMax[lfemale, SPAS] = 1;
$ItemMax[earmor, SPAS] = 1;
$ItemMax[efemale, SPAS] = 1;
$ItemMax[harmor, SPAS] = 1;
$ItemMax[uharmor, SPAS] = 1;

$ItemMax[hlarmor, SPASAmmo] = 20;
$ItemMax[hlfemale, SPASAmmo] = 20;
$ItemMax[marmor, SPASAmmo] = 40;
$ItemMax[mfemale, SPASAmmo] = 40;
$ItemMax[larmor, SPASAmmo] = 30;
$ItemMax[lfemale, SPASAmmo] = 30;
$ItemMax[earmor, SPASAmmo] = 40;
$ItemMax[efemale, SPASAmmo] = 40;
$ItemMax[harmor, SPASAmmo] = 65;
$ItemMax[uharmor, SPASAmmo] = 80;



 addPluginWeapon(LaserRifle, SPAS);
 $AutoUse[SPAS] = True;

 $SellAmmo[SPASAmmo] = 5;
 $AmmoPackMax[SPASAmmo] = 20;
 $WeaponAmmo[SPAS] = SPASAmmo;


ItemData SPASAmmo
{
	description = "SPAS Shells";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData SPASImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	// projectileType = ShotgunPellet;
	ammoType = SPASAmmo;
	accuFire = True;
	reloadTime = 0.4;
	fireTime = 0.3;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData SPAS
{
	description = "SPAS Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	heading = "cSecondary Weapons";
	shadowDetailMask = 4;
	imageType = SPASImage;
	price = 250;
	showWeaponBar = true;
};

function SPAS::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Chameleon Device.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>SPAS Shotgun - Very high refire rate.", 2);
	}
}


function SPASImage::onFire(%player, %slot)
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SPAS]);
	
	if (%AmmoCount)
	 {
   		 playSound(turretExplosion,GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("GunFlame",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[SPAS],1);
	 }
	 else
	 {
	 	playSound(SoundPackFail,GameBase::getPosition(%player));
	 	Player::trigger(%player,$WeaponSlot,false);
	 	Client::sendMessage(Player::getClient(%player), 0,"Shotgun is outta ammo!");
	 } 
}
