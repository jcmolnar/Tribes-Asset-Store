//************************************************************
// wepDebug.cs
// Author: Dustin ']KyA[X-Ecutioner' Bruce.
// Email: dustin84@tribal-gods.com
// 
// Email me before using this code, thanks.
//************************************************************
BulletData MineSweepShell {
   bulletShapeName = "fusionbolt.dts";
   explosionTag = PlasmaCannonExp0;
   mass = 1.0;
   damageClass = 1;     
   damageValue = 2.5;
   damageType = $DebugDamageType;
   explosionRadius = 2.5;
   muzzleVelocity = 110;
   totalTime = 4.5;
   liveTime = 4.0;
   isVisible = true;
   rotationPeriod = 0.3;
};
ItemImageData MineSweeperImage {
	shapeFile   = "grenadeL";
	mountPoint  = 0;
	mountOffset = { -0.1, 0, 0 };
	mountRotation = { 0, -1.85, 0};
	weaponType  = 0; 
	reloadTime  = 0.25;
	fireTime    = 0.1;
	minEnergy   = 5;
	maxEnergy   = 6;
//	projectileType = MineSweepShell;
	accuFire    = true;
	sfxFire	    = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload   = SoundMortarReload;
};
ItemData MineSweeper {
	heading   = $InvHeading[EnergyWeapons];
	description = "Mine Sweeper";
	classname = "Weapon";
	shapeFile = "GrenadeL";
	hudIcon	  = "recon";
	shadowDetailMask = 4;
	imageType = MineSweeperImage;
	price     = 150;
	showWeaponBar = true;
};
ItemImageData MineSweeper2Image {
	shapeFile   = "mortargun";
	mountPoint  = 0;
	mountOffset = { -0.1, 0, 0 };
	mountRotation = { 0, -1.85, 0};
	weaponType  = 0; 
	reloadTime  = 0.25;
	fireTime    = 0.1;
	minEnergy   = 5;
	maxEnergy   = 6;
//	projectileType = MineSweepShell;
	accuFire    = true;
	sfxFire	    = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload   = SoundMortarReload;
};
ItemData MineSweeper2 {
	heading   = $InvHeading[EnergyWeapons];
	description = "Mine Sweeper";
	classname = "Weapon";
	shapeFile = "mortargun";
	hudIcon	  = "recon";
	shadowDetailMask = 4;
	imageType = MineSweeper2Image;
	price     = 150;
	showWeaponBar = false;
	showInventory = false;
};
function MineSweeper::onUse(%player, %item){
	Weapon::onUse(%player, %item);
}
function MineSweeper::onMount(%player, %item){
	Player::mountItem(%player, MineSweeper2, 4);
}
function MineSweeper::onDrop(%player, %item){
	%state = Player::getItemState(%player, $WeaponSlot);
	if(%state != "Fire" && %state != "Reload"){
		Player::setItemCount(%player, MineSweeper2, 0);
		Item::onDrop(%player, %item);
	}
}
function MineSweeper::onUnmount(%player, %imageSlot){
	Player::unmountItem(%player, 4);
}
function MineSweeperImage::onFire(%player, %slot){
	Projectile::spawnProjectile("MineSweepShell", GameBase::getMuzzleTransform(%player), %player, Item::getVelocity(%player));
	%client = Player::getClient(%player);
	Player::Trigger(%player, 4, true);
	Player::Trigger(%player, 4, false);
}