$InvList[Shotgun] = 1;
$RemoteInvList[Shotgun] = 1;
$AutoUse[Shotgun] = True;
$WeaponAmmo[Shotgun] = ShotgunShells;
$SellAmmo[ShotgunShells] = 15;
$InvList[ShotgunShells] = 1;
$RemoteInvList[ShotgunShells] = 1;

addWeapon(Shotgun);
addAmmo(Shotgun, ShotgunShells, 5);

BulletData ShotgunBullet 
{
bulletShapeName = "tracer.dts";
explosionTag = ShotExp;
mass = 0.05;
bulletHoleIndex = 0;
damageClass = 0;
damageValue = 0.07;
damageType = $ShotgunDamageType;
kickBackStrength = 300.0;
aimDeflection = 0.02;
muzzleVelocity = 400.0;
acceleration = 5.0;
totalTime = 0.5;
inheritedVelocityScale = 1.0;
isVisible = False;
tracerPercentage = 1.0;
tracerLength = 30;
};

ItemData ShotgunShells 
{
description = "Shotgun Shells";
className = "Ammo";
shapeFile = "ammo2";
heading = $InvHead[ihAmm];
shadowDetailMask = 4;
price = 2;
};


ItemImageData ShotgunImage 
{
shapeFile = "shotgun";
mountPoint = 0;
weaponType = 0;
ammoType = ShotgunShells;
reloadTime = 1.0;
accuFire = false;
fireTime = 0.5;
sfxFire = SoundFireShotgun;
sfxActivate = SoundPickUpWeapon;
};


ItemData Shotgun 
{
description = "Shotgun";
shapeFile = "shotgun";
hudIcon = "ammopack";
className = "Weapon";
heading = $InvHead[ihWea];
shadowDetailMask = 4;
imageType = ShotgunImage;
showWeaponBar = true;
price = 85;
};

function ShotgunImage::onFire(%player, %slot) 
{
Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
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