//===========================================================================
// IX-Weapon Data
//============================================================================
$AutoUse[Shotgun] = False;
$AutoUse[SniperRifle] = False;
$Use[Assault] = True;
//========================================================
$InvList[Assault] = 1;
$InvList[Shotgun] = 1;
$InvList[SniperRifle] = 1;
$InvList[IXShotAmmo] = 1;
$InvList[IXAssaultAmmo] = 1;
$InvList[IXSniperAmmo] = 1;
$RemoteInvList[Assault] = 1;
$RemoteInvList[Shotgun] = 1;
$RemoteInvList[SniperRifle] = 1;
$RemoteInvList[IXShotAmmo] = 1;
$RemoteInvList[IXAssaultAmmo] = 1;
$RemoteInvList[IXSniperAmmo] = 1;
//============================================================================
$DamageScale[larmor, $ShotgunDamageType] = 0.5;
$DamageScale[larmor, $AssaultDamageType] = 0.35;
$DamageScale[larmor, $SniperDamageType] = 1.5;
$DamageScale[lfemale, $ShotgunDamageType] = 0.5;
$DamageScale[lfemale, $AssaultDamageType] = 0.35;
$DamageScale[lfemale, $SniperDamageType] = 1.5;

$DamageScale[marmor, $ShotgunDamageType] = 0.5;
$DamageScale[marmor, $AssaultDamageType] = 0.35;
$DamageScale[marmor, $SniperDamageType] = 1.5;
$DamageScale[mfemale, $ShotgunDamageType] = 0.5;
$DamageScale[mfemale, $AssaultDamageType] = 0.35;
$DamageScale[mfemale, $SniperDamageType] = 1.5;

$DamageScale[harmor, $ShotgunDamageType] = 0.5;
$DamageScale[harmor, $AssaultDamageType] = 0.35;
$DamageScale[harmor, $SniperDamageType] = 1.5;

$ItemMax[larmor, Assault] = 1;
$ItemMax[lfemale, Assault] = 1;
$ItemMax[marmor, Assault] = 0;
$ItemMax[mfemale, Assault] = 0;
$ItemMax[harmor, Assault] = 0;

$ItemMax[larmor, Shotgun] = 1;
$ItemMax[lfemale, Shotgun] = 1;
$ItemMax[marmor, Shotgun] = 0;
$ItemMax[mfemale, Shotgun] = 0;
$ItemMax[harmor, Shotgun] = 0;

$ItemMax[larmor, SniperRifle] = 1;
$ItemMax[lfemale, SniperRifle] = 1;
$ItemMax[marmor, SniperRifle] = 0;
$ItemMax[mfemale, SniperRifle] = 0;
$ItemMax[harmor, SniperRifle] = 0;

$ItemMax[larmor, IXSniperAmmo] = 100;
$ItemMax[lfemale, IXSniperAmmo] = 100;
$ItemMax[marmor, IXSniperAmmo] = 0;
$ItemMax[mfemale, IXSniperAmmo] = 0;
$ItemMax[harmor, IXSniperAmmo] = 0;

$ItemMax[larmor, IXAssaultAmmo] = 300;
$ItemMax[lfemale, IXAssaultAmmo] = 300;
$ItemMax[marmor, IXAssaultAmmo] = 0;
$ItemMax[mfemale, IXAssaultAmmo] = 0;
$ItemMax[harmor, IXAssaultAmmo] = 0;

$ItemMax[larmor, IXShotAmmo] = 100;
$ItemMax[lfemale, IXShotAmmo] = 100;
$ItemMax[marmor, IXShotAmmo] = 0;
$ItemMax[mfemale, IXShotAmmo] = 0;
$ItemMax[harmor, IXShotAmmo] = 0;
//============================================================================
SoundData SoundWPNAssault
{
   wavFileName = "wpn_ixar.wav";
   profile = Profile3dNear;
};

SoundData SoundWPNShotgun
{
   wavFileName = "wpn_ixsg.wav";
   profile = Profile3dNear;
};

SoundData SoundWPNSniper
{
   wavFileName = "wpn_ixsr.wav";
   profile = Profile3dNear;
};

SoundData ricochetShot
{
   wavFileName = "rico_shot.wav";
   profile     = Profile3dNear;
};

SoundData ricochetBullet
{
   wavFileName = "rico_bullet.wav";
   profile     = Profile3dNear;
};

SoundData ricochetSniper
{
   wavFileName = "rico_Sniper.wav";
   profile     = Profile3dNear;
};

SoundData ricochetMini
{
   wavFileName = "rico_mini.wav";
   profile     = Profile3dNear;
};

SoundData ricochetCG
{
   wavFileName = "rico_CG.wav";
   profile = Profile3dNear;
};

//==============================================================

//============================================================================

// Minigun relocated here due to unknown spam bug with mini exps
ExplosionData MinigunExp
{
   shapeName = "chainspk.dts";
   soundId   = RicochetMini;
   //validateShape = true;
   //validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

// chaingun relocated here due to unknown spam bug with chain exps
ExplosionData ChaingunExp
{
   shapeName = "chainspk.dts";
   soundId   = RicochetBullet;
   //validateShape = true;
   //validateMaterials = true;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};
/////////////////////////////
ExplosionData IXshotExp 
{
 shapeName = "smoke.dts";
 soundId = RicochetShot;
 faceCamera = true;
 randomSpin = true;
 hasLight = true; 
lightRange = 1.0; 
timeZero = 0.100; 
timeOne = 0.900; 
colors[0] = { 0.0, 0.0, 0.0 };
 colors[1] = { 0.75, 1.0, 1.0 };
 colors[2] = { 0.75, 1.0, 1.0 }; 
radFactors = { 0.0, 1.0, 0.0 }; 
shiftPosition = True; 
}; 

ExplosionData IXSniperExp 
{
 shapeName = "smoke.dts";
 soundId = RicochetSniper;
 faceCamera = true;
 randomSpin = true;
 hasLight = true; 
lightRange = 1.0; 
timeZero = 0.100; 
timeOne = 0.900; 
colors[0] = { 0.0, 0.0, 0.0 };
 colors[1] = { 0.75, 1.0, 1.0 };
 colors[2] = { 0.75, 1.0, 1.0 }; 
radFactors = { 0.0, 1.0, 0.0 }; 
shiftPosition = True; 
};
ExplosionData IXBulletExp 
{
 shapeName = "smoke.dts";
 soundId = RicochetBullet;
 faceCamera = true;
 randomSpin = true;
 hasLight = true; 
lightRange = 1.0; 
timeZero = 0.100; 
timeOne = 0.900; 
colors[0] = { 0.0, 0.0, 0.0 };
 colors[1] = { 0.75, 1.0, 1.0 };
 colors[2] = { 0.75, 1.0, 1.0 }; 
radFactors = { 0.0, 1.0, 0.0 }; 
shiftPosition = True; 
};


//============================================================================
BulletData Shotgunproj
{
bulletShapeName = "tracer.dts";
explosionTag = IXShotExp;
 mass = 0.05;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 0.0;
 damageType = $ShotgunDamageType;
 aimDeflection = 0.005;
 muzzleVelocity = 5000.0;
 totalTime = 1.0;
 inheritedVelocityScale = 1.0;
 isVisible = False;
 tracerPercentage = 1.0;
 tracerLength = 50;
 };

BulletData Assaultproj
 {
 bulletShapeName = "bullet.dts";
 explosionTag = IXBulletExp;
 mass = 0.5;
 collisionRadius = 0.0;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 0.0;
 damageType = $AssaultDamageType;
 aimDeflection = 0.003;
 muzzleVelocity = 4000.0;
 totalTime = 2.0;
 inheritedVelocityScale = 0.5;
 isVisible = false;
 tracerPercentage = 1.0;
 tracerLength = 0;
 detachFromShooter = false;
};

RocketData Sniperproj
 {
 bulletShapeName = "bullet.dts";
 explosionTag = IXSniperExp;
 collisionRadius = 0.0;
 mass = 2.0;
 damageClass = 0;
 damageValue = 0;
 damageType = $SniperDamageType;
 kickBackStrength = 600.0;
 muzzleVelocity = 4000.0;
 terminalVelocity = 9000.0;
 acceleration = 15.0;
 totalTime = 10.0;
 liveTime = 11.0;
 lightRange = 1.0;
 lightColor = { 1, 1, 1};
 inheritedVelocityScale = 1.0;
 trailType = 1;
 trailLength = 1000;
 trailWidth = 0.25;
 
 };
//============================================================================
ItemData IXShotAmmo
 {
 description = "IX-Shotgun shells";
 className = "Ammo";
 heading = "xAmmunition";
 shapeFile = "ammo_shells";
 shadowDetailMask = 4;
 price = 0;
 };
ItemData IXSniperAmmo
 {
 description = "IX-Sniper rounds";
 className = "Ammo";
 heading = "xAmmunition";
 shapeFile = "ammo_clip";
 shadowDetailMask = 4;
 price = 0;
 };
ItemData IXAssaultAmmo
 {
 description = "IX-Bullets";
 className = "Ammo";
 heading = "xAmmunition";
 shapeFile = "ammo_clip";
 shadowDetailMask = 4;
 price = 0;
 };
//=============================================================================================

ItemImageData AssaultImage
 {
 shapeFile = "wpn_ixar";
 mountPoint = 0;
 weaponType = 0;
 ammoType = IXAssaultAmmo;
 projectileType = Assaultproj;
 accuFire = false;
 reloadTime = 0.03;
 fireTime = 0.03;
 sfxFire = SoundWPNAssault;
 sfxActivate = SoundPickupWeapon;
 };

ItemData Assault
 {
 description = "IX-Assault Rifle";
 className = "weapon";
 shapeFile = "wpn_ixar";
 hudIcon = "ixar";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = AssaultImage;
 price = 0;


 };
//======================================================================================
ItemImageData ShotgunImage
 {
 shapeFile = "wpn_ixsg";
 mountPoint = 0;
 weaponType = 0;
 ammoType = IXShotAmmo;
 projectileType = NoProjectile;
 accuFire = false;
 reloadTime = 0.5;
 fireTime = 0.25;
 sfxFire = SoundWPNShotgun;
 sfxActivate = SoundPickUpWeapon;
 };

ItemData Shotgun
 {
 description = "IX-Shotgun";
 className = "weapon";
 shapeFile = "wpn_ixsg";
 hudIcon = "ixshot";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = ShotgunImage;
 price = 0;


 };

function ShotgunImage::onFire(%player, %slot) { %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
 if(%AmmoCount) { Player::decItemCount(%player,$WeaponAmmo[Shotgun],5);
 %trans = GameBase::getMuzzleTransform(%player);
 %vel = Item::getVelocity(%player);
Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
 Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
 Projectile::spawnProjectile("Shotgunproj",%trans,%player,%vel);
 }
 else Client::sendMessage(Player::getClient(%player), 0,"You Ran Out Of Ammo for the Shotgun"); }
//====================================================================================================
ItemImageData SniperRifleImage
 {
 shapeFile = "wpn_ixsr";
 mountPoint = 0;
 weaponType = 0;
 ammoType = IXSniperAmmo;
 projectileType = Sniperproj;
 accuFire = true;
 reloadTime = 0.15;
 fireTime = 0.25;
 sfxFire = SoundWPNSniper;
 sfxActivate = SoundPickupWeapon;
 };

ItemData SniperRifle
 {
 description = "IX-Sniper Rifle";
 className = "weapon";
 shapeFile = "wpn_ixsr";
 hudIcon = "ixsr";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = SniperRifleImage;
 price = 0;
 };
//========================================================================================
//echo("IX weapons Loaded");