
//----------------------------------------------------------------------------

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bWeapons";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 149;
	showWeaponBar = true;
};


function Blaster::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "Blaster");
}

//--------------------------------------
// SniperRifle
//--------------------------------------


ItemData SniperAmmo 
{
  	description = "APHE 50cal Bullet";
  	className = "Ammo";
 	shapeFile = "ammo1";
  heading = "xAmmunition";
  	shadowDetailMask = 4;
	price = 9;
};

ItemImageData SniperRifleImage 
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 2.5;

	ammoType = SniperAmmo;
	projectileType = APHE50cal;
	accuFire = true;

	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
 	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
  heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 199;
	showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "Sniper Rifle");
}

//----------------------------------------------------------------------------


ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 149;
	showWeaponBar = true;
};


function LaserRifle::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		Bottomprint(%client, "Laser Rifle");
}

//----------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 9;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 199;
	showWeaponBar = true;
};


function PlasmaGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
 	if(!%client.firstSpawn)	
		 Bottomprint(%client, "Plasma Gun");
}

//--------------------------------------
// Plamsa Shotgun
//--------------------------------------

ItemImageData PlasmaShotgunImage
{
   shapeFile  = "plasma";
	mountPoint = 0;
	weaponType = 0; 
	reloadTime = 0.5;
	fireTime = 1.0;
	projectileType = whatever;
	accuFire = false;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
	sfxFire     = SoundFirePlasma;
};

ItemData PlasmaShotgun
{
   heading = "bWeapons";
	description = "Plasma Shotgun";
	className = "Weapon";
   shapeFile  = "plasma";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PlasmaShotgunImage;
	price = 199;
	showWeaponBar = true;
};


function PlasmaShotgunImage::onFire(%player, %slot)
{
if (GameBase::getEnergy(%player) > 40)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	for(%pelletCount=0; %pelletCount<=10; %pelletCount++)
		{ Projectile::spawnProjectile("PlasmaShotgunBolt",%transform,%player,%velocity); } 
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 40);
	}
else
	Client::sendMessage(Player::getClient(%player), 0,"Not Enough Energy");
}

function PlasmaShotgun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
 	if(!%client.firstSpawn)	
		 Bottomprint(%client, "Plasma Shotgun");
}

//------------------------------------------------------------------------------
// Lamprey
//------------------------------------------------------------------------------

ItemImageData LampreyImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   projectileType = LampreyCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Lamprey
{
   description = "Lamprey";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = LampreyImage;
	showWeaponBar = true;
   price = 199;
};

function Lamprey::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "Lamprey");
}

//------------------------------------------------------------------------------


ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 149;
};


function EnergyRifle::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "ELF Gun");
}

//----------------------------------------
// AutoBlaster
//----------------------------------------

ItemImageData AutoBlasterImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; 
	reloadTime = 0;
	spinUpTime = 0.3;
	spinDownTime = 3;
	fireTime = 0.1;
	minEnergy = 2;
	maxEnergy = 5;

	projectileType = VoltBolt;
	accuFire = false;

	lightType = 3; 
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData AutoBlaster
{
	description = "AutoBlaster";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AutoBlasterImage;
	price = 199;
	showWeaponBar = true;
};

function AutoBlaster::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
 	if(!%client.firstSpawn)	
		 Bottomprint(%client, "AutoBlaster");
}

//--------------------------------------
// Shotgun
//--------------------------------------

ItemData ShotgunAmmo
{
	description = "Shotgun Shells";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 9;
};

ItemImageData ShotgunImage
{
   shapeFile  = "energygun";
	mountPoint = 0;
	weaponType = 0; 
	reloadTime = 0.5;
	fireTime = 1.0;
	ammoType = ShotgunAmmo;
	projectileType = whatever;
	accuFire = false;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxFire     = SoundFireMortar;
};

ItemData Shotgun
{
   heading = "bWeapons";
	description = "Shotgun";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	price = 199;
	showWeaponBar = true;
};


function ShotgunImage::onFire(%player, %slot)
{
if (Player::getItemCount(%player, $WeaponAmmo[Shotgun]) > 0)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	for(%pelletCount=0; %pelletCount<=8; %pelletCount++)
		{ Projectile::spawnProjectile("ShotgunShell",%transform,%player,%velocity); } 
	Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
	}
}

function Shotgun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
 	if(!%client.firstSpawn)	
		 Bottomprint(%client, "Shotgun");
}

//----------------------------------------------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 9;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 199;
	showWeaponBar = true;
};


function DiscLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "DiscLauncher");
}

//----------------------------------------------------------------------------

ItemData SuperballAmmo
{
	description = "Superball";
	className = "Ammo";
	shapeFile = "discAmmo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 9;
};

ItemImageData SballLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // SballLauncher
	ammoType = SuperballAmmo;
	projectileType = Superball;
	accuFire = true;
	reloadTime = 0.10;
	fireTime = 0.25;
	spinUpTime = 0.15;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData SballLauncher
{
	description = "Superball Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SballLauncherImage;
	price = 199;
	showWeaponBar = true;
};


function SballLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "Superball Launcher");
}

//----------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 29;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.75;

	lightType = 3;  // Weapon Fire
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
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 199;
	showWeaponBar = true;
};


function GrenadeLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "Grenade Launcher");
}

//----------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 3;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.15;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
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
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 199;
	showWeaponBar = true;
};


function Chaingun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "Chaingun");
}

//----------------------------------------------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 49;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
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
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 299;
	showWeaponBar = true;
};


function Mortar::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
 	if(!%client.firstSpawn)	
		 Bottomprint(%client, "Mortar");
}

//----------------------------------------------------------------------------

ItemImageData MultiGrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = whatever;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
	sfxReady = SoundMortarIdle;
};

ItemData MultiGrenadeLauncher
{
	description = "MultiGrenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MultiGrenadeLauncherImage;
	price = 299;
	showWeaponBar = true;
};


function MultiGrenadeLauncherImage::onFire(%player, %slot)
{
if (Player::getItemCount(%player, $WeaponAmmo[MultiGrenadeLauncher]) >= 3)
	{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("GrenadeShell",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)-0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("GrenadeShell",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)+0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("GrenadeShell",%transform,%player,%velocity); 
	GameBase::setRotation(%player, %rot);
	Player::decItemCount(%player,$WeaponAmmo[MultiGrenadeLauncher],3);
	}
if (Player::getItemCount(%player, $WeaponAmmo[MultiGrenadeLauncher]) > 0 && Player::getItemCount(%player, $WeaponAmmo[MultiGrenadeLauncher]) < 3) 
	{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("GrenadeShell",%transform,%player,%velocity); 
	Player::decItemCount(%player,$WeaponAmmo[MultiGrenadeLauncher],1);
	}

}

function MultiGrenadeLauncher::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "MultiGrenade Launcher");
}

//----------------------------------------------------------------------------

ItemData HowitzerAmmo
{
	description = "Howitzer Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 69;
};

ItemImageData HowitzerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = HowitzerAmmo;
	projectileType = HowitzerShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.15;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Howitzer
{
	description = "Howitzer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HowitzerImage;
	price = 299;
	showWeaponBar = true;
};


function Howitzer::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "Howitzer");
}

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------
//  Repulsor Gun
//----------------------------------------------------------------------------

ItemImageData RepulsorGunImage
{
   shapeFile = "paintgun";
   mountPoint = 0;

   weaponType = 2; 
   projectileType = RepulsorBeam;
   minEnergy = 18;
   maxEnergy = 22;
   reloadTime = 0.2;
			
   lightType = 3;
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.85, 0.85, 0.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundRepairItem;
};

ItemData RepulsorGun
{
  className = "Weapon";
  description = "Repulsor Gun";
  heading = "bWeapons";
  hudIcon = "targetlaser";
  imageType = RepulsorGunImage;
  price = 199;
  shadowDetailMask = 4;
  shapeFile = "paintgun";
  showWeaponBar = true;
};

function RepulsorGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
 	if(!%client.firstSpawn)	
		 Bottomprint(%client, "Repulsor Gun");
}

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 99;
	showWeaponBar = false;
};


function TargetingLaser::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)	
		  Bottomprint(%client, "Targeting Laser");
}
