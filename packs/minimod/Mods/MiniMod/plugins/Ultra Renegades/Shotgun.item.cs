// This is a MiniMod plugin
// This is the Shotgun From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.

$AutoUse[Shotgun] = True; 
$SellAmmo[ShotgunShells] = 80; 
$AmmoPackMax[ShotgunShells] = 20; 
$AmmoPackItems[12] = ShotgunShells; 
$WeaponAmmo[Shotgun] = ShotgunShells; 

MiniMod::WeaponCycle(Blaster, Shotgun, PlasmaGun);

function Shotgun::Fire::Volley(%trans,%player,%vel)
{
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
}

ItemData ShotgunShells
{
description = "Shotgun Shells";
className = "Ammo";
shapeFile = "ammo2";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 2;
}; 

function ShotgunImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
	Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
	if(%AmmoCount != 1)
		{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player); 
                Shotgun::Fire::Volley(%trans,%player,%vel);
                return;
		}
	else
	{
        Shotgun::Fire::Volley(%trans,%player,%vel);
        if(%AmmoCount == 1)
             {
             Shotgun::Fire::Volley(%trans,%player,%vel);
             remoteNextWeapon(%player);
             }
        }
}

SoundData SoundFireShotgun
{
wavFileName = "mine_exp.wav"; profile = Profile3dNear;
};

ItemImageData ShotgunImage
{
shapeFile = "shotgun";
mountPoint = 0;
weaponType = 0;
ammoType = ShotgunShells;
reloadTime = 0.99;
accuFire = true;
fireTime = 0.01;
sfxFire = SoundFireShotgun;
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundPickUpWeapon; //SoundMortarReload;
sfxReady = SoundPickUpWeapon;
};

ItemData Shotgun
{
heading = "bWeapons";
description = "Shotgun";
className = "Weapon";
shapeFile = "shotgun";
hudIcon = "ammopack";
shadowDetailMask = 4;
imageType = ShotgunImage;
price = 85;
showWeaponBar = true;
};

