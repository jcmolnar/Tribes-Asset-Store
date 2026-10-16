$FireModes[GrenadeLauncher] = 3;
//--------------------------------------

$AutoUse[GrenadeLauncher] = True;
addAmmo(GrenadeLauncher,GrenadeAmmo,5,15);

addToInv(GrenadeLauncher,1,1);
addToInv(GrenadeAmmo,1,1);

setArmorItemMax(GrenadeLauncher,0,1,1,1,1,1,1, 1, 0,0,0,0);
setArmorItemMax(GrenadeAmmo,10,10,10,10,10,15,15, 99, 0,0,0,0);

//--------------------------------------

GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass 	      = 1.0;
   elasticity	      = 0.45;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.4;
   damageType	      = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime	      = 30.0;	 // special meaning for grenades...
   liveTime	      = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName		  = "smoke.dts";
};

//--------------------------------------
GrenadeData GFireShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass 	      = 1.0;
   elasticity	      = 0.45;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.2;
   damageType	      = $FireDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime	      = 30.0;	 // special meaning for grenades...
   liveTime	      = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName		  = "plasmatrail.dts";
};

//--------------------------------------

GrenadeData GEmpShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = LargeShockwave2;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass 	      = 1.0;
   elasticity	      = 0.45;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.25;
   damageType	      = $EmpDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime	      = 30.0;	 // special meaning for grenades...
   liveTime	      = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName		  = "enex.dts";
};

//--------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = $InvCatAmmo;
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
//	  projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;	// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

function GrenadeLauncherImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	%ammo = Player::getItemCount(%player,GrenadeAmmo);
	if(%ammo > 0) {
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if($WeapMode[%client,GrenadeLauncher] == 1 || $WeapMode[%client,GrenadeLauncher] < 1 || $WeapMode[%client,GrenadeLauncher] == "")
			Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
		else if($WeapMode[%client,GrenadeLauncher] == 2)
			Projectile::spawnProjectile("GFireShell",%trans,%player,%vel);
		else if($WeapMode[%client,GrenadeLauncher] >= $FireModes[GrenadeLauncher])
			Projectile::spawnProjectile("GEmpShell",%trans,%player,%vel);
		Player::decItemCount(%player,GrenadeAmmo,1);
	}
}

function GrenadeLauncher::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	if($WeapMode[%client,GrenadeLauncher] == 2)
		Player::mountItem(%player,GrenNapMod,$ExtraSlotA);
	else if($WeapMode[%client,GrenadeLauncher] == 3 || $WeapMode[%client,GrenadeLauncher] > $FireModes[GrenadeLauncher])
		Player::mountItem(%player,GrenEmpMod,$ExtraSlotA);
}

function GrenadeLauncher::onUnMount(%player,%item)
{
	%client = Player::getClient(%player);
	if($WeapMode[%client,GrenadeLauncher] == 2)
		Player::unmountItem(%player,$ExtraSlotA);
	else if($WeapMode[%client,GrenadeLauncher] == 3 || $WeapMode[%client,GrenadeLauncher] > $FireModes[GrenadeLauncher])
		Player::unmountItem(%player,$ExtraSlotA);
}

$MountMSG[GrenadeLauncher,1] = "<JC><F2>Grenade Launcher <F0>- <F1>Set to fire concussion grenades.";
$MountMSG[GrenadeLauncher,2] = "<JC><F2>Grenade Launcher <F0>- <F1>Set to fire napalm grenades.";
$MountMSG[GrenadeLauncher,3] = "<JC><F2>Grenade Launcher <F0>- <F1>Set to fire EMP grenades.";

AddWeapon(GrenadeLauncher);
