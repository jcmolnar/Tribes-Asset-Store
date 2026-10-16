//--------------------------------------

$AutoUse[Chaingun] = True;
addAmmo(Chaingun,BulletAmmo,25,150);

addToInv(Chaingun,1,1);
addToInv(BulletAmmo,1,1);

setArmorItemMax(Chaingun,0,1,0,0,0,0,0, 1, 0,0,0,0);
setArmorItemMax(BulletAmmo,100,125,175,200,225,250,275, 300, 0,0,0,0);

//--------------------------------------

BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   validateShape      = true;
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass 	      = 0.05;
   bulletHoleIndex    = 0;

   damageClass	      = 0;	 // 0 impact, 1, radius
   damageValue	      = 0.1;
   damageType	      = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime	      = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible	      = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
GrenadeData BulletShell
{
   bulletShapeName = "plasmatrail.dts";
   explosionTag       = smokeExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass 	      = 5.0;
   elasticity	      = 0.01;

   damageClass	      = 1;	 // 0 impact, 1, radius
   damageValue	      = 0.0;
   damageType	      = $NullDamageType;

   explosionRadius    = 0.01;
   kickBackStrength   = 0.01;
   maxLevelFlightDist = 1;
   totalTime	      = 10.0;
   liveTime	      = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName		  = "breath.dts";
};

//----------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvCatAmmo;
	shadowDetailMask = 4;
	price = 1;
};

//--------------------------------------

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.1;

	ammoType = BulletAmmo;
//	  projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;	// Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = $InvCatWeapons[All];
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function ChaingunImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	%ammo = Player::getItemCount(%player,BulletAmmo);
	if(%ammo > 0) {
		%trans = getPerfectTrans(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile(ChaingunBullet,%trans,%player,%vel);
		Projectile::spawnProjectile(BulletShell,%trans,%player,%vel);
		Player::decItemCount(%player,BulletAmmo,1);
	}
}

$MountMSG[Chaingun] = "<JC><F2>Chaingun <F0>- <F1>Fires at a fast rate and deals moderate damage.";

AddWeapon(Chaingun);
