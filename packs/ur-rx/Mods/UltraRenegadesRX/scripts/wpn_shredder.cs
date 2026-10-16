//================================================================
// Shredder
//================================================================

SoundData SoundFireShredder
{
   wavFileName = "mortar_fire.wav";
   profile = Profile3dNear;
};

SoundData SoundShredderReload
{
   wavFileName = "mortar_reload.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionShredder
{
   wavFileName = "ricoche1.wav";
   profile     = Profile3dNear;
};

//================================================================

ExplosionData ShredderExp
{
   shapeName = "chainspk.dts";
   soundId   = ExplosionShredder;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

//================================================================

BulletData ProjShredder
 {
 bulletShapeName = "tracer.dts";
 explosionTag = ShredderExp;
 mass = 0.05;
 bulletHoleIndex = 0;
 damageClass = 0;
 damageValue = 0.11;
 damageType = $ShredderDamageType;
 aimDeflection = 0.005;
 muzzleVelocity = 2500.0;
 totalTime = 0.5;
 inheritedVelocityScale = 1.0;
 isVisible = False;
 tracerPercentage = 1.0;
 tracerLength = 50;
 };

//================================================================
ItemData ShredderAmmo
{
	description = "Shredder Ammo";
   	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 0;
};


ItemImageData ChaingunImage
{
	shapeFile = "shotgun";
   	mountPoint = 0;


    	weaponType = 0; // Single Shot
   	ammoType = ShredderAmmo;
  	projectileType = undefinedproj;
   	accuFire = false;
   	reloadTime = 0.25;
   	fireTime = 0.0;
                        
   	lightType = 3;  // Weapon Fire
   	lightRadius = 1;
   	lightTime = 1;
   	lightColor = { 0.25, 0.25, 0.85 };

   	sfxActivate = SoundPickUpWeapon;
   	sfxFire     = SoundfireShredder;
	//sfxReload = SoundShredderReload;
};

ItemData Chaingun
{
   	description = "Shredder";
	shapeFile = "shotgun";
	hudIcon = "Chain";
   	className = "Weapon";
   	heading = "bWeapons";
   	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 0;
	showWeaponBar = true;
	showInventory = true;
  	//validateShape = true;
	//validateMaterials = true;
};

function ChaingunImage::onFire(%player, %slot) { %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Chaingun]);
 	if(%AmmoCount) { Player::decItemCount(%player,$WeaponAmmo[Chaingun],1);
 	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ProjShredder",%trans,%player,%vel);
		Projectile::spawnProjectile("ProjShredder",%trans,%player,%vel);
		Projectile::spawnProjectile("ProjShredder",%trans,%player,%vel);
		Projectile::spawnProjectile("ProjShredder",%trans,%player,%vel);
		Projectile::spawnProjectile("ProjShredder",%trans,%player,%vel);
	ShredderNoFireAnim(%player);
	Client::sendMessage(Player::getClient(%player), 0,"" @ %msg @ "~wmortar_fire.wav");
 	}
	
	else Client::sendMessage(Player::getClient(%player), 0,"You Ran Out Of Ammo for the shredder"); 
	}

function ShredderNoFireAnim(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	
	Player::mountItem(%player,Chaingun,$WeaponSlot);
}


//=================================================================
echo("Item Loaded");