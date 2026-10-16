$FireModes[Mortar] = 2;
//--------------------------------------

$AutoUse[Mortar] = True;
addAmmo(Mortar,MortarAmmo,4,8);

addToInv(Mortar,1,1);
addToInv(MortarAmmo,1,1);

setArmorItemMax(Mortar,0,0,0,0,0,1,1, 1, 0,0,0,0);
setArmorItemMax(MortarAmmo,4,4,4,6,8,10,12, 99, 0,0,0,0);

//--------------------------------------

GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass 	      = 5.0;
   elasticity	      = 0.1;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 1.0;
   damageType	      = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime	      = 30.0;
   liveTime	      = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName		  = "mortartrail.dts";
};

//---------------------------------------
GrenadeData MGravShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass 	      = 5.0;
   elasticity	      = 0.1;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 1.0;
   damageType	      = $GravityDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = -250.0;
   maxLevelFlightDist = 275;
   totalTime	      = 30.0;
   liveTime	      = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName = "shield.dts";
};

//--------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = $InvCatAmmo;
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
//	  projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;	// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

function MortarImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	%ammo = Player::getItemCount(%player,MortarAmmo);
	if(%ammo > 0) {
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if($WeapMode[%client,Mortar] == 1 || $WeapMode[%client,Mortar] < 1  || $WeapMode[%client,Mortar] == "")
			Projectile::spawnProjectile(MortarShell,%trans,%player,%vel);
		else if($WeapMode[%client,Mortar] >= $FireModes[Mortar])
			Projectile::spawnProjectile(MGravShell,%trans,%player,%vel);
		Player::decItemCount(%player,MortarAmmo,1);
	}
}

function Mortar::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	if($WeapMode[%client,Mortar] == 2 || $WeapMode[%client,Mortar] > $FireModes[Mortar])
		Player::mountItem(%player,MortImpMod,$ExtraSlotA);
}

function Mortar::onUnMount(%player,%item)
{
	%client = Player::getClient(%player);
	if($WeapMode[%client,Mortar] == 2 || $WeapMode[%client,Mortar] > $FireModes[Mortar])
		Player::unmountItem(%player,$ExtraSlotA);
}

$MountMSG[Mortar,1] = "<JC><F2>Mortar <F0>- <F1>Set to fire explosion mortars.";
$MountMSG[Mortar,2] = "<JC><F2>Mortar <F0>- <F1>Set to fire implosion mortars.";

AddWeapon(Mortar);
