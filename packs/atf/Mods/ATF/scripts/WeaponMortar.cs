//--------------------------------------

$AutoUse[Mortar] = True;
$SellAmmo[MortarAmmo] = 5;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackItems[6] = MortarAmmo;
$WeaponAmmo[Mortar] = Mortar;

//--------------------------------------

$InvList[Mortar] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[Mortar] = 1;
$RemoteInvList[MortarAmmo] = 1;

//--------------------------------------

GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
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
   heading = "eTrajectory Guns";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function Mortar::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The Mortar has to be the single greatest weapon in tribes....what better way to launch explosives that blow your enemies into little chunks :).", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
ExplosionData AcidExp
{
   shapeName = "PlasmaBolt.dts";
   soundId   = Explosion4;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.5, 1.0, 1.0 };
};

$AutoUse[AMortar] = True;
$SellAmmo[MortarAmmo] = 5;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackItems[6] = MortarAmmo;
$WeaponAmmo[AMortar] = MortarAmmo;

//--------------------------------------

$InvList[AMortar] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[AMortar] = 1;
$RemoteInvList[MortarAmmo] = 1;

//--------------------------------------

GrenadeData AMortarShell
{
   bulletShapeName    = "Mortar.dts";
   explosionTag       = Mortarexp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $PoisonDamageType;

   explosionRadius    = 8.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 90.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "hflame.dts";
};

GrenadeData AMortarShellBurn
{
   bulletShapeName    = "Mortar.dts";
   explosionTag       = debrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $BurnDamageType;

   explosionRadius    = 8.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 90.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Tumult_small.dts";
};

GrenadeData AMortarShellBlind
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $BlindDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 90.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "hflame.dts";
};

GrenadeData AMortarShellEmp
{
   bulletShapeName    = "Mortar.dts";
   explosionTag       = TurretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $EmpDamageType;

   explosionRadius    = 8.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 90.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "FusionEx.dts";
};
//--------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = Kyle;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function AMortarImage::onFire(%player, %slot)
{
if (GameBase::getEnergy(%player) > 20)
{

if (Player::getItemCount(%Player,"EmpPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("AMortarShellEmp",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 5);
	}
if (Player::getItemCount(%Player,"FirePack") == 1)
	{
		
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("AMortarShellBurn",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 20);	
	}
if (Player::getItemCount(%Player,"PoisonPack") == 1)
	{
		
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("AMortarShell",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 10);	
	}
if (Player::getItemCount(%Player,"FlashPack") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	Projectile::spawnProjectile("AMortarShellBlind",%transform,%player,%velocity);
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 5);
	}

}
}

ItemData AMortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "gMulti Shot Guns";
	shadowDetailMask = 4;
	imageType = AMortarImage;
	price = 775;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function AMortar::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Multi Shot Mortar, Must Modifier Packs to use this gun", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

$AutoUse[Mortari] = True;
$SellAmmo[EnergyAmmo] = 500;
$AmmoPackMax[EnergyAmmo] = 1000;
$AmmoPackItems[6] = EnergyAmmo;
$WeaponAmmo[Mortari] = Energyammo;

GrenadeData MortarShelli
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ShockDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 20050.0;
   maxLevelFlightDist = 475;
   totalTime          = 60.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Tumult_Large.dts";
};

//--------------------------------------

ItemImageData MortarImagei
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = EnergyAmmo;
	projectileType = MortarShelli;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortari
{
	description = "The Punisher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eTrajectory Guns";
	shadowDetailMask = 4;
	imageType = MortarImagei;
	price = 785375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function Mortari::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Punisher....a weapon so strong it will never be used...except in case of a force so cheap that punishing must take place....If you have been granted this don't miss-use it", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$AutoUse[MortarX] = True;
//--------------------------------------

//$InvList[MortarX] = 1;
//$RemoteInvList[MortarX] = 1;
//--------------------------------------

GrenadeData MortarShellX
{
   bulletShapeName    = "PlasmaBolt.dts";
   explosionTag       = PlasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.9;
   damageType         = $AlienDamageType;

   explosionRadius    = 5.0;
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 1000;
   totalTime          = 30.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "PlasmaBolt.dts";
};

GrenadeData MortarShellX2
{
   bulletShapeName    = "PlasmaBolt.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.8;
   damageType         = $AlienDamageType;

   explosionRadius    = 9.0;
   kickBackStrength   = 200.0;
   maxLevelFlightDist = 2000;
   totalTime          = 30.0;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Plasmaex.dts";
};
//--------------------------------------


ItemImageData MortarImagex
{
	shapeFile = "Force";
	mountPoint = 0;
	mountoffset = { 0, -0.3, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { 0, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	projectileType = Kenny;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.2;
	minEnergy = 100;
	maxEnergy = 100;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 4;
	lightColor = { 0.6, 1, 1.0 };
        sfxFire = SoundMortarFire;
	sfxActivate = SoundLandOnGround;
	sfxReload = SoundLandOnGround;
	sfxReady = SoundMortarIdle;
};

function MortarImageX::onFire(%player, %slot)
{
if (Player::getItemCount(%Player,"EnergyPack5") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	
	for(%pelletCount=0; %pelletCount<=1; %pelletCount++)
		{
	Projectile::spawnProjectile("MortarShellX2",%transform,%player,%velocity);
		}
	}
if (Player::getItemCount(%Player,"EnergyPack4") == 1)
	{
	%transform = GameBase::getMuzzleTransform(%player);
	%velocity = Item::getVelocity(%player);
	
	for(%pelletCount=0; %pelletCount<=1; %pelletCount++)
		{
	Projectile::spawnProjectile("MortarShellX",%transform,%player,%velocity);
	        }
	}
}


ItemData MortarX
{
	description = "Plasma Stream";
	className = "Weapon";
	shapeFile = "Force";
	hudIcon = "mortar";
   heading = "wXythilian Attacks";
	shadowDetailMask = 4;
	imageType = MortarImagex;
	price = 3275;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function MortarX::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Plasma Stream draws power from your core and disperses it quickly and efficiently. Energy Needed To Fire: 1/3 and Core Generator", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

//$AutoUse[MortarS] = True;
//$SellAmmo[EnergyAmmo] = 5;
//$AmmoPackMax[EnergyAmmo] = 10;
//$AmmoPackItems[6] = EnergyAmmo;
//$WeaponAmmo[MortarS] = EnergyAmmo;

//--------------------------------------

//$InvList[MortarS] = 1;

//$RemoteInvList[MortarS] = 1;


//--------------------------------------

GrenadeData MortarShellS
{
   bulletShapeName    = "Shockwave_Large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $BlindDamageType;

   explosionRadius    = 100.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;
   liveTime           = 0.01;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "Shockwave_Large.dts";
};

//--------------------------------------


ItemImageData MortarImageS
{
	shapeFile = "Laserhit";
	mountPoint = 0;
	mountoffset = { 0, -0.5, 0 };
        mountrotation = { 3, 3, 3 };
	weaponType = 0; // Single Shot
	ammoType = EnergyAmmo;
	projectileType = MortarShellS;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 1;  // Weapon Fire
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundPlayerDeath;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundFallonground;
	sfxReady = SoundFallOnGround;
};

ItemData MortarS
{
	description = "Solar Flare";
	className = "Weapon";
	shapeFile = "laserhit";
	hudIcon = "mortar";
   heading = "pArmor Upgrades";
	shadowDetailMask = 4;
	imageType = MortarImageS;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function MortarS::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Solar Flare, this attack surges a strong amount of light to your opponent...blinding them and your self....use it sparingly", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------