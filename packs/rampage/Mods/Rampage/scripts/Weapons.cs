//=============================================================================================

ItemImageData BlasterImage 
{ 
shapeFile = "energygun"; 
mountPoint = 0;
mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
mountRotation = { 0, 7, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
weaponType = 0; 
reloadTime = 0.1; 
fireTime = 0.2; 
minEnergy = 0.6; 
maxEnergy = 0.6; 
projectileType = blasterBolt; 
accuFire = true; 
sfxFire = SoundFireBlaster; 
sfxActivate = SoundPickUpWeapon; 
};

ItemData Blaster 
{ 
heading = "bWeapons"; 
description = "Blaster"; 
className = "Weapon"; 
shapeFile = "repairgun"; 
hudIcon = "blaster"; 
shadowDetailMask = 4; 
imageType = BlasterImage; 
price = 25; 
showWeaponBar = true; 
}; 

//=============================================================================================
ItemData BulletAmmo 
{ 
description = "Assault Bullet"; 
className = "Ammo"; 
shapeFile = "ammo2"; 
heading = "xAmmunition"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData Chain2Image
{
	shapeFile = "Sniper";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Chain2
{
	description = "Chain2";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = Chain2Image;
	showWeaponBar = false;
};

ItemImageData ChaingunImage 
{ 
shapeFile = "chaingun"; 
mountPoint = 0; 
weaponType = 1; 
reloadTime = 0; 
spinUpTime = 0.5; 
spinDownTime = 3; 
fireTime = 0.09; 
ammoType = BulletAmmo; 
projectileType = ChaingunBullet; 
accuFire = false; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 1,1,1}; 
sfxFire = SoundFireChaingun; 
sfxActivate = SoundPickUpWeapon; 
sfxSpinUp = SoundSpinUp; 
sfxSpinDown = SoundSpinDown; 
}; 

ItemData Chaingun 
{ 
description = "Assault Gun"; 
className = "Weapon"; 
shapeFile = "chaingun"; 
hudIcon = "chain"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = ChaingunImage; 
price = 420; 
showWeaponBar = true; 
};

function Chaingun::onMount(%player,%item)
{
	Player::mountItem(%player,Chain2,7);
}

function Chaingun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//=============================================================================================
ItemData TranqAmmo 
{ 
description = "Venom Darts"; 
className = "Ammo"; 
heading = "xAmmunition"; 
shapeFile = "ammo2"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData Ven2Image
{
	shapeFile = "Bullet";
	mountPoint = 0; 
	mountOffset = { 0, 0.5, 0.18 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Ven2
{
	description = "Ven2";
	className = "Weapon";
	shapeFile = "Bullet";
	shadowDetailMask = 4;
	imageType = Ven2Image;
	showWeaponBar = false;
};

ItemImageData TranqGunImage 
{ 
shapeFile = "sniper"; 
mountPoint = 0; 
weaponType = 0; 
ammoType = TranqAmmo; 
projectileType = TranqDart; 
accuFire = true; 
reloadTime = 1.0; 
fireTime = 0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 2; 
lightColor = { 0, 1.0, 0 }; 
sfxFire = ricochet2; 
sfxReLoad = SoundWeapon5; 
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData TranqGun 
{ 
description = "Venom Fang Rilfe"; 
className = "Weapon"; 
shapeFile = "sniper"; 
hudIcon = "blaster"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = TranqGunImage; 
price = 420; 
showWeaponBar = true; 
}; 

function TranqGun::onMount(%player,%item)
{
	Player::mountItem(%player,Ven2,7);
}

function TranqGun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//=============================================================================================
ItemData DiscAmmo 
{ 
description = "Discs"; 
className = "Ammo"; 
shapeFile = "discammo"; 
heading = "xAmmunition"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData DiscLauncherImage 
{ 
shapeFile = "disc"; 
mountPoint = 0; 
weaponType = 3; 
ammoType = DiscAmmo; 
projectileType = DiscShell2; 
accuFire = true; 
reloadTime = 0.12; 
fireTime = 1.25; 
spinUpTime = 0.12; 
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
price = 420; 
showWeaponBar = true; 
}; 

//=============================================================================================
ItemData GrenadeAmmo 
{ 
description = "Grenade Ammo"; 
className = "Ammo"; 
shapeFile = "grenammo"; 
heading = "xAmmunition"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData Grenx1Image
{
	shapeFile = "Grenade";
	mountPoint = 0; 
	mountOffset = { 0, 0.3, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Grenx1
{
	description = "Grenx1";
	className = "Weapon";
	shapeFile = "Grenade";
	shadowDetailMask = 4;
	imageType = Grenx1Image;
	showWeaponBar = false;
};

ItemImageData Grenx2Image
{
	shapeFile = "Grenade";
	mountPoint = 0; 
	mountOffset = { 0, 0.3, -0.2 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Grenx2
{
	description = "Grenx2";
	className = "Weapon";
	shapeFile = "Grenade";
	shadowDetailMask = 4;
	imageType = Grenx2Image;
	showWeaponBar = false;
};

ItemImageData GrenadeLauncherImage 
{ 
shapeFile = "grenadeL"; 
mountPoint = 0; 
weaponType = 0; 
ammoType = GrenadeAmmo; 
projectileType = GrenadeShell; 
accuFire = false; 
reloadTime = 0.5; 
fireTime = 0.5; 
lightType = 3; 
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
price = 420; 
showWeaponBar = true; 
}; 

function GrenadeLauncher::onMount(%player,%item)
{
	Player::mountItem(%player,Grenx1,5);
	Player::mountItem(%player,Grenx2,6);
}

function GrenadeLauncher::onUnMount(%player,%item)
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
}
//=============================================================================================
ItemData PlasCAmmo 
{ 
description = "F.F.M.L Ammo"; 
className = "Ammo"; 
shapeFile = "grenammo"; 
heading = "xAmmunition"; 
shadowDetailMask = 4; 
price = 7; 
};

ItemImageData PlasCan1Image
{
	shapeFile = "MortarAmmo";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { -1.5, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData PlasCan1
{
	description = "PlasCan1";
	className = "Weapon";
	shapeFile = "MortarAmmo";
	shadowDetailMask = 4;
	imageType = PlasCan1Image;
	showWeaponBar = false;
};

ItemImageData PlasCan2Image
{
	shapeFile = "MortarAmmo";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 1.5, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData PlasCan2
{
	description = "PlasCan2";
	className = "Weapon";
	shapeFile = "MortarAmmo";
	shadowDetailMask = 4;
	imageType = PlasCan2Image;
	showWeaponBar = false;
};


ItemImageData PlasmaCannonImage
{
	shapeFile = "mortargun";
	mass = 2;
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 1.0;
      AmmoType = PlasCAmmo;
	//projectileType = ;
	minEnergy = 10;
	maxEnergy = 20;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1.75, 0.25, 3.0 };
	sfxFire = SoundCoolExplosion;
	sfxActivate = SoundRMTurret;
	sfxReload = SoundFailPack;
	sfxReady = SoundWeapon5;
};

ItemData PlasmaCannon
{
	description = "F.F.M.L";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 420;
	showWeaponBar = true;
	mass = 0;
};

function PlasmaCannon::onMount(%player,%item)
{
	Player::mountItem(%player,PlasCan1,5);
	Player::mountItem(%player,PlasCan2,6);
}

function PlasmaCannon::onUnMount(%player,%item)
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
}

function PlasmaCannonImage::onFire(%this,%player,%item) 
{ 
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,PlasCAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,PlasCAmmo);
	if(GameBase::getLOSInfo(%this,800)){
		%Dist=Vector::getDistance(GameBase::getPosition(%this),$los::position);
		if(%Dist == 0)  %time = 1;
		else	%time=(%Dist/180)-0.05;
 		%newObj = Projectile::spawnProjectile("AgedonShell", %trans, %this, %vel);
		schedule("SpawnAgedon(" @ %newObj @ ", " @ %this @ ");", %time);
		
	}
	else{
		%time = 1; 
 		%newObj = Projectile::spawnProjectile("AgedonShell", %trans, %this, %vel);
		schedule("SpawnAgedon(" @ %newObj @ ", " @ %this @ ");", %time);
	}
	}
}

function SpawnAgedon(%newobj,%this){

echo("this spawn agedon ",%this);

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 60) -30;

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("AgedonGrenadeShell", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);

	Item::setVelocity(%obj, %forceVel);

		}
	deleteobject(%newObj);
	}
}
//=============================================================================================
ItemImageData ArmLImage
{
	shapeFile = "Sniper";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData ArmL
{
	description = "ArmL";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = ArmLImage;
	showWeaponBar = false;
};

ItemImageData LaserRifleImage 
{ 
shapeFile = "repairgun"; 
mountPoint = 0;
mountOffset = { 0, 0, 0.10 }; //-  left-right, back-front, up-down
mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
weaponType = 0; 
projectileType = SniperLaser; 
accuFire = true; 
reloadTime = 0.2; 
fireTime = 0.5; 
minEnergy = 40; 
maxEnergy = 80; 
lightType = 3; 
lightRadius = 2; 
lightTime = 1; 
lightColor = { 2, 12, 234 }; 
sfxFire = SoundFirePistol; 
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData LaserRifle 
{ 
description = "Laser Rifle"; 
className = "Weapon"; 
shapeFile = "repairgun"; 
hudIcon = "sniper"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = LaserRifleImage; 
price = 420; 
showWeaponBar = true; 
};
 
function LaserRifle::onMount(%player,%item)
{
	Player::mountItem(%player,ArmL,7);
}

function LaserRifle::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//=============================================================================================
ItemData SilencerAmmo 
{ 
description = "Armageddon Bullets"; 
className = "Ammo"; 
heading = "xAmmunition"; 
shapeFile = "ammo2"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData Arm2Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 0.0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Arm2
{
	description = "Arm2";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = Arm2Image;
	showWeaponBar = false;
};


ItemImageData SilencerImage 
{ 
shapeFile = "sniper"; 
mountPoint = 0; 
weaponType = 0; 
ammoType = SilencerAmmo; 
projectileType = ArmaBullet; 
accuFire = true; 
reloadTime = 0.9; 
fireTime = 0.5; 
lightType = 3; 
lightRadius = 6; 
lightTime = 2; 
lightColor = { 0, 0, 0 }; 
sfxFire = SoundMortarTurretFire; 
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Silencer 
{ 
description = "Armageddon Rifle"; 
className = "Weapon"; 
shapeFile = "sniper"; 
hudIcon = "targetlaser"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = SilencerImage; 
price = 420; 
showWeaponBar = true; 
}; 

function Silencer::onMount(%player,%item)
{
	Player::mountItem(%player,Arm2,7);
}

function Silencer::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//=============================================================================================
ItemData MortarAmmo 
{ 
description = "Mortar Ammo"; 
className = "Ammo"; 
heading = "xAmmunition"; 
shapeFile = "ammo1"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData MortarImage 
{ 
shapeFile = "mortargun"; 
mountPoint = 0; 
weaponType = 0; 
ammoType = MortarAmmo; 
projectileType = MortarShell; 
accuFire = false; 
reloadTime = 0.5; 
fireTime = 2.0; 
lightType = 3; 
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
description = "Impact Mortar"; 
className = "Weapon"; 
shapeFile = "mortargun"; 
hudIcon = "mortar"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = MortarImage; 
price = 420; 
showWeaponBar = true; 
}; 
//=============================================================================================
ItemData NapalmAmmo 
{ 
description = "Napalm Shell"; 
heading = "xAmmunition"; 
className = "Ammo"; 
shapeFile = "plasammo"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData NapImage
{
	shapeFile = "plasma";
	mountPoint = 0; 
	mountOffset = { 0, -0.1, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Nap
{
	description = "Nap";
	className = "Weapon";
	shapeFile = "plasma";
	shadowDetailMask = 4;
	imageType = NapImage;
	showWeaponBar = false;
};

ItemImageData NapalmImage 
{
shapeFile = "grenadeL"; 
mountPoint = 0;
mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
weaponType = 0;
ammoType = NapalmAmmo; 
//projectileType = NapalmShell;
reloadTime = 0.5; 
fireTime = 2.0; 
accuFire = true; 
sfxFire = SoundDryFire; 
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundFireGrenade; 
}; 

ItemData Napalm 
{ 
heading = "bWeapons"; 
description = "Napalm Strike"; 
className = "Weapon"; 
shapeFile = "grenadeL"; 
hudIcon = "plasma"; 
shadowDetailMask = 4; 
imageType = NapalmImage; 
price = 420; 
showWeaponBar = true; 
}; 

function Napalm::onMount(%player,%item)
{
	Player::mountItem(%player,Nap,7);
}

function Napalm::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}


function NapalmImage::onFire(%player, %slot)
{
	Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
      Projectile::spawnProjectile("Nap1",%trans,%player,%vel-15);
      Projectile::spawnProjectile("Nap1",%trans,%player,%vel);
	Projectile::spawnProjectile("Nap1",%trans,%player,%vel+15);
	Projectile::spawnProjectile("Nap2",%trans,%player,%vel-15);
	Projectile::spawnProjectile("Nap2",%trans,%player,%vel);
	Projectile::spawnProjectile("Nap2",%trans,%player,%vel+15);
	Projectile::spawnProjectile("Nap3",%trans,%player,%vel-15);
	Projectile::spawnProjectile("Nap3",%trans,%player,%vel);
	Projectile::spawnProjectile("Nap3",%trans,%player,%vel+15);
	Player::decItemCount(%player,$WeaponAmmo[Napalm],1);
}
//=============================================================================================
ItemImageData OMG2Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData OMG2 
{
	description = "OMG2";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = OMG2Image;
	showWeaponBar = false;
};

ItemImageData OmegaImage 
{ 
shapeFile = "shotgun"; 
mountPoint = 0;
mountOffset = { 0, 0.0, 0.0 }; //-  left-right, back-front, up-down
mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
weaponType = 0; 
reloadTime = 1.0; 
fireTime = 0; 
minEnergy = 5; 
maxEnergy = 6; 
accuFire = false; 
sfxFire = shockExplosion; 
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Omega 
{ 
description = "Auto Electric Shotgun"; 
shapeFile = "shotgun"; 
hudIcon = "energyRifle"; 
className = "Weapon"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = OmegaImage; 
showWeaponBar = true; 
price = 420; 
};

function Omega::onMount(%player,%item)
{
	Player::mountItem(%player,OMG2,6);
}

function Omega::onUnMount(%player,%item)
{
      Player::unmountItem(%player,6);
}

function OmegaImage::onFire(%player,%slot)
{
	echo("Auto Electric 12g Fired, Someones hurt; call 911");

	for(%i = 0; %i < 10; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("EnergyPellet",%trans,%player,%vel);
	}
	//Player::decItemCount(%player,$WeaponAmmo[Omega],1);
}
//=============================================================================================
ItemData PlasmaAmmo 
{ 
description = "Plasma Bolt"; 
heading = "xAmmunition"; 
className = "Ammo"; 
shapeFile = "plasammo"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData plas1Image 
{ 
	 shapeFile = "Plasma"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 };
	 ammoType = PlasmaAmmo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.3;
	fireTime = 0.1;
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
	projectileType = PlasmaBolt; 
}; 

ItemData Plas1 
{ 
	description = "Plas1";
	 className = "Weapon"; 
	shapeFile = "Plasma"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Plas1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData Plas2Image 
{
	 shapeFile = "Plasma"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, -0.2 };
	 ammoType = PlasmaAmmo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.3;
	fireTime = 0.1;
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
	projectileType = PlasmaBolt; 
}; 

ItemData Plas2 
{ 
	description = "Plas2";
	 className = "Weapon"; 
	shapeFile = "plasma"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Plas2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData PlasmagunImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	ammoType = PlasmaAmmo; 
	reloadTime = 0.3;
	fireTime = 0.2;
 	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
}; 

ItemData Plasmagun
{ 
	description = "Plasma Gun"; 
	className = "Weapon"; 
	shapeFile = "Plasma"; 
	hudIcon = "plasma"; 
     heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = PlasmagunImage; 
	price = 420; 
	showWeaponBar = true;
}; 

function PlasmagunImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,5);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "PlasmaAmmo", 0.5);   
		%num = Player::getItemCount(%player, "PlasmaAmmo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "PlasmaAmmo", 0);    
			else     
			Player::setItemCount(%player, "PlasmaAmmo", %num);    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "PlasmaAmmo", 0);    
			else     
			Player::setItemCount(%player, "PlasmaAmmo", %num);    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function Plasmagun::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "PlasmaAmmo");  
	Player::setItemCount(%player, "PlasmaAmmo", %num);  
	Player::mountItem(%player,Plas1,4);  
	Player::mountItem(%player,Plas2,5); 
} 

function Plasmagun::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,5); 
}
//=============================================================================================
ItemData RailAmmo 
{ 
description = "Plasma Rifle Bolt"; 
className = "Ammo"; 
heading = "xAmmunition"; 
shapeFile = "ammo2"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData RailgunImage 
{ 
shapeFile = "sniper"; 
mountPoint = 0;
mountRotation = { 0, 3, 0 };  
weaponType = 0; 
ammoType = RailAmmo; 
projectileType = PlasmaBolt3; 
accuFire = true; 
reloadTime = 0.1; 
fireTime = 2.0; 
lightType = 3; 
lightRadius = 6; 
lightTime = 2; 
lightColor = { 1.0, 0, 0 }; 
sfxFire = SoundMissileTurretFire; 
sfxActivate = SoundPickUpWeapon; 
sfxSpinUp = SoundSpinUp; 
sfxSpinDown = SoundSpinDown; 
}; 

ItemData Railgun 
{ 
description = "Plasma Rifle"; 
className = "Weapon"; 
shapeFile = "sniper"; 
hudIcon = "targetlaser"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = RailgunImage; 
price = 420; 
showWeaponBar = true; 
}; 
//=============================================================================================
ItemImageData RepairGunImage 
{ 
shapeFile = "repairgun"; 
mountPoint = 0; 
weaponType = 2; 
projectileType = RepairBolt; 
reloadTime = 3;  
minEnergy = 3; 
maxEnergy = 10; 
lightType = 3; 
lightRadius = 1; 
lightTime = 1; 
lightColor = { 0.25, 1, 0.25 }; 
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
price = 420; 
}; 

function RepairGun::onMount(%player,%imageSlot)
{ 
Player::trigger(%player,$BackpackSlot,true); 
} 

function RepairGun::onUnmount(%player,%imageSlot) 
{ 
Player::trigger(%player,$BackpackSlot,false); 
} 
//=============================================================================================
ItemData RocketAmmo 
{ 
description = "Rockets"; 
className = "Ammo"; 
heading = "xAmmunition"; 
shapeFile = "ammo1"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData RocketImage 
{ 
shapeFile = "mortargun"; 
mountPoint = 0;
mountRotation = { 0, 7, 0 };
mountOffset = { 0, 0, -0.1 };
weaponType = 0; 
ammoType = RocketAmmo;
projectileType = StingerMissile;
accuFire = true; 
reloadTime = 0.3; 
fireTime = 2.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
sfxFire = BigExplosion2; 
sfxActivate = SoundPickUpWeapon; 
sfxReload = SoundMortarReload; 
sfxReady = SoundMortarIdle; 
}; 

ItemData RocketLauncher 
{ 
description = "Missile Launcher"; 
className = "Weapon"; 
shapeFile = "mortargun"; 
hudIcon = "mortar"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = RocketImage; 
price = 420; 
showWeaponBar = true; 
}; 
//=============================================================================================
ItemImageData WaveGunImage 
{ 
shapeFile = "shotgun"; 
mountPoint = 0; 
weaponType = 0; 
minEnergy = 40; 
maxEnergy = 45; 
//projectileType = Shock; 
accuFire = true; 
fireTime = 0.9; 
sfxFire = SoundTeleport2;
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData WaveGun 
{ 
description = "Blast Cannon"; 
className = "Weapon"; 
shapeFile = "shotgun"; 
hudIcon = "disk"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = WaveGunImage; 
price = 420; 
showWeaponBar = true; 
}; 

function WaveGunImage::onFire(%player, %slot)
{
	Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
      Projectile::spawnProjectile("Shock",%trans,%player,%vel-5);
      Projectile::spawnProjectile("Shock",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[WaveGun],1);
}
//=============================================================================================
ItemData ShotgunAmmo 
{ 
description = "Plasma ShotGun Shells"; 
className = "Ammo"; 
shapeFile = "ammo2"; 
heading = "xAmmunition"; 
shadowDetailMask = 4; 
price = 7; 
};
 
ItemImageData ShotgunImage 
{ 
shapeFile = "shotgun"; 
mountPoint = 0; 
weaponType = 0; 
reloadTime = 1; 
fireTime = 0.33; 
ammoType = ShotgunAmmo; 
accuFire = false; 
sfxFire = SoundFireMortar; 
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Shotgun 
{ 
heading = "bWeapons"; 
description = "Plasma Shotgun"; 
className = "Weapon"; 
shapeFile = "shotgun"; 
hudIcon = "mortar"; 
shadowDetailMask = 4; 
imageType = ShotgunImage; 
price = 420; 
showWeaponBar = true; 
}; 

function ShotgunImage::onFire(%player, %slot) 
	{
	%count = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
	if(%count) 
	{
	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
	%tran = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("PlasmaBolt2",%tran,%player,%vel);
	Projectile::spawnProjectile("PlasmaBolt2",%tran,%player,%vel);
	Projectile::spawnProjectile("PlasmaBolt2",%tran,%player,%vel);
	Projectile::spawnProjectile("PlasmaBolt2",%tran,%player,%vel);
	Projectile::spawnProjectile("PlasmaBolt2",%tran,%player,%vel);
	}
	else
	Client::sendMessage(%client, 0,"Plasma ShotGun has no ammo.");
	}
//=============================================================================================
ItemData SniperAmmo 
{ 
description = "Sniper Bullet"; 
className = "Ammo"; 
heading = "xAmmunition"; 
shapeFile = "ammo2"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData SScopeImage
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0.7, 0.18 }; //-  left-right, back-front, up-down
	mountRotation = { 1.6, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData SScope
{
	description = "SScope";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = SScopeImage;
	showWeaponBar = false;
};

ItemImageData SniperRifleImage 
{ 
shapeFile = "sniper"; 
mountPoint = 0; 
weaponType = 0; 
ammoType = SniperAmmo; 
projectileType = SniperRound; 
accuFire = true; 
reloadTime = 1.7; 
fireTime = 0; 
lightType = 3; 
lightRadius = 6; 
lightTime = 2; 
lightColor = { 1.0, 0, 0 }; 
sfxFire = SoundPickUpWeapon; 
sfxActivate = SoundPickUpWeapon; 
}; 

ItemData SniperRifle 
{ 
description = "Sniper Rifle"; 
className = "Weapon"; 
shapeFile = "sniper"; 
hudIcon = "targetlaser"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = SniperRifleImage; 
price = 420; 
showWeaponBar = true; 
}; 

function SniperRifle::onMount(%player,%item)
{
	Player::mountItem(%player,SScope,7);
}

function SniperRifle::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//=============================================================================================
ItemImageData EnergyRifleImage 
{ 
shapeFile = "shotgun"; 
mountPoint = 0; 
weaponType = 2; 
projectileType = boltCharge; 
minEnergy = 5; 
maxEnergy = 6; 
reloadTime = 0.2; 
lightType = 3; 
lightRadius = 2; 
lightTime = 1; 
lightColor = { 0.25, 0.25, 0.85 }; 
sfxActivate = SoundPickUpWeapon; 
sfxFire = SoundELFIdle; 
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
price = 420; 
}; 
//============================================================================================= 
ItemData VulcanAmmo 
{ 
description = "Annihillation Disks";           
className = "Ammo"; 
shapeFile = "ammo1"; 
heading = "xAmmunition"; 
shadowDetailMask = 4; 
price = 7; 
}; 

ItemImageData ADImage
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AD
{
	description = "AD";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = ADImage;
	showWeaponBar = false;
};

ItemImageData AD2Image
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AD2
{
	description = "AD2";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = AD2Image;
	showWeaponBar = false;
};

ItemImageData VulcanImage 
{ 
shapeFile = "grenadeL"; 
mountPoint = 0; 
weaponType = 3; 
reloadTime = 0.12; 
fireTime = 1.25; 
ammoType = VulcanAmmo; 
//projectileType = DiscShell; 
accuFire = true; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1 }; 
sfxFire = SoundFireDisc; 
sfxActivate = SoundPickUpWeapon; 
sfxSpinUp = SoundSpinUp; 
sfxSpinDown = SoundSpinDown; 
}; 

ItemData Vulcan 
{ 
description = "Annihillation Disk"; 
className = "Weapon"; 
shapeFile = "grenadeL"; 
hudIcon = "chain"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = VulcanImage; 
price = 420; 
showWeaponBar = true; 
}; 

function Vulcan::onMount(%player,%item)
{
      Player::mountItem(%player,AD2,6);
	Player::mountItem(%player,AD,7);
}

function Vulcan::onUnMount(%player,%item)
{
      Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function VulcanImage::onFire(%player, %slot)
{
	Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
      Projectile::spawnProjectile("DiscShell",%trans,%player,%vel-15);
      Projectile::spawnProjectile("DiscShell",%trans,%player,%vel);
	Projectile::spawnProjectile("DiscShell",%trans,%player,%vel+15);
	Player::decItemCount(%player,$WeaponAmmo[Vulcan],1);
}
//================================================================= Dual Vulcan ===============
ItemData MinigunAmmo 
{ 
	description = "Mini-Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "xAmmuntition"; 
	shadowDetailMask = 4; 
	price = 7; 
}; 

ItemImageData Mini1Image 
{ 
	 shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 };
	 ammoType = MinigunAmmo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0;
	fireTime = 0.1;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	projectileType = Minigunbullet; 
}; 

ItemData Mini1 
{ 
	description = "Mini1";
	 className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Mini1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData Mini2Image 
{
	 shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -0.8, 0, 0 };
	 ammoType = MinigunAmmo; 
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0;
	fireTime = 0.1;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	projectileType = Minigunbullet; 
}; 

ItemData Mini2 
{ 
	description = "Mini2";
	 className = "Weapon"; 
	shapeFile = "Chaingun"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Mini2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData MinigunImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	ammoType = MiniGunAmmo; 
	reloadTime = 0;
	fireTime = 0.2;
 	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
}; 

ItemData Minigun
{ 
	description = "Dual Fighter Assault"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chaingun"; 
     heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MinigunImage; 
	price = 420; 
	showWeaponBar = true;
}; 

function MinigunImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,5);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "MiniGunAmmo", 0.5);   
		%num = Player::getItemCount(%player, "MiniGunAmmo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "MiniGunAmmo", 0);    
			else     
			Player::setItemCount(%player, "MiniGunAmmo", %num);    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "MiniGunAmmo", 0);    
			else     
			Player::setItemCount(%player, "MiniGunAmmo", %num);    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function Minigun::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "MiniGunAmmo");  
	Player::setItemCount(%player, "MiniGunAmmo", %num);  
	Player::mountItem(%player,Mini1,4);  
	Player::mountItem(%player,Mini2,5); 
} 

function Minigun::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,5); 
}
//=============================================================================================
ItemData SRAmmo
{
	description = "Elite Sniper Bullets";
   	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData Scope1Image
{
	shapeFile = "force";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.18 }; //-  left-right, back-front, up-down
	mountRotation = { 1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Scope1
{
	description = "Scope1";
	className = "Weapon";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = Scope1Image;
	showWeaponBar = false;
};

ItemImageData SRImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = SRAmmo;
	projectileType = SniperBullet;
	accuFire = true;
	reloadTime = 1.25;
	fireTime = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundWeaponSelect;
	sfxReload = SoundWeaponSelect;
};

ItemData SR
{
	description = "Elite Sniper";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "reticle";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SRImage;
	price = 420;
	showWeaponBar = true;
};

function SR::onMount(%player,%item)
{
	Player::mountItem(%player,Scope1,7);
}

function SR::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//====================================================
ItemData AssFlakAmmo
{
	description = "Assault Flak Shells";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData AssFlak1Image
{ 
	shapeFile = "grenadeL";
	mountPoint = 0;
      mountRotation = {0, 1.5, 0}; 
      mountOffset = {0, 0, 0};
	

	 ammoType = AssFlakAmmo; 
	weaponType = 0; 
	accuFire = false; 
	reloadTime = 0.4;
	fireTime = 0.1;
	projectileType = FlakShell2;
      sfxFire = SoundMortarTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
      
}; 

ItemData AssFlak1 
{ 
	description = "AssFlak1";
	 className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = AssFlak1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData AssFlak2Image
{
	shapeFile = "grenadeL";
	mountPoint = 0;
      mountRotation = {0, -1.5, 0}; 
      mountOffset = {-0.1, 0, 0};


	 ammoType = AssFlakAmmo; 
	weaponType = 0; 
	accuFire = false; 
	reloadTime = 0.4;
	fireTime = 0.1;
	projectileType = FlakShell2;
      sfxFire = SoundMortarTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData AssFlak2
{ 
	description = "AssFlak2";
	 className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "ammopack"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = AssFlak2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData AssFlakImage
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	ammoType = AssFlakAmmo; 
	reloadTime = 0.4;
	fireTime = 0.1;
	sfxFire = SoundMortarTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;

}; 

ItemData AssFlak
{ 
	description = "Assault Flak Gun"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "chain"; 
     heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = AssFlakImage; 
	price = 420; 
	showWeaponBar = true;
}; 

function AssFlakImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,4);  
	%state2 = Player::getItemState(%player,5);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "AssFlakAmmo", 0.5);   
		%num = Player::getItemCount(%player, "AssFlakAmmo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "AssFlakAmmo", 0);    
			else     
			Player::setItemCount(%player, "AssFlakAmmo", %num);    
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "AssFlakAmmo", 0);    
			else     
			Player::setItemCount(%player, "AssFlakAmmo", %num);    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
}  

function AssFlak::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "AssFlakAmmo");  
	Player::setItemCount(%player, "AssFlakAmmo", %num);  
	Player::mountItem(%player,AssFlak1,4);  
	Player::mountItem(%player,AssFlak2,5);
} 

function AssFlak::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,4);  
	Player::unmountItem(%player,5);
}
//----------------------------------------------------------------------------
$TankRPGSlotA=4;
$TankRPGSlotB=7;
$TankRPGSlotC=6; 

ItemData TankRPGAmmo 
{	description = "Dual Flak"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 7; 
}; 

ItemImageData TankRPGLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = TankRPGAmmo; 
	accuFire = true; 
	sfxFire = SoundMortarTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData TankRPGLauncher 
{	description = "Dual Flak Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncherImage; 
	price = 420; 
	showWeaponBar = true; 
};

ItemImageData TankRPGLauncher2Image 
{	ammoType = TankRPGAmmo; 
	projectileType = FBlast; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, 0, 0 }; 
	mountRotation = { 0, -3, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData TankRPGLauncher2 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData TankRPGLauncher3Image 
{	ammoType = TankRPGAmmo; 
	projectileType = FBlast; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData TankRPGLauncher3 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData TankRPGLauncher4Image 
{	ammoType = TankRPGAmmo; 
	projectileType = FBlast; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0, 0, 0 }; 
	mountRotation = { 0, -3, 0}; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMortarTurretFire; 
};

ItemData TankRPGLauncher4 
{	description = "Tank RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$TankRPGSlotA=4;
$TankRPGSlotB=7;
$TankRPGSlotC=6;

function TankRPGLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,TankRPGLauncher2,$TankRPGSlotA); 
	Player::mountItem(%player,TankRPGLauncher3,$TankRPGSlotB); 
	Player::mountItem(%player,TankRPGLauncher4,$TankRPGSlotC);
	%client = Player::getclient(%player);
      Bottomprint(%client, "<jc><f3>]|[<f1> Dual Flak Launcher <f3>]|[\n<f3>]|[<f1> R.O.F - <f2>1.0 <f3>]|[  <f3>]|[<f1> D.P.S - <f2>0.125 <f3>]|[  <f3>]|[<F1> Range - <f2>Short To Medium <f3>]|[",5);
}

function TankRPGLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TankRPGSlotA);
	Player::unmountItem(%player,$TankRPGSlotB);	 
	Player::unmountItem(%player,$TankRPGSlotC);
}

function TankRPGLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,TankRPGammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("Fblast",%trans,%player,%vel,%player); 
	if(!$FiringTankRPGLauncher[%client]) 
		CheckTankRPGLauncher(%client, %player); 
}

function TankRPGLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TankRPGLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckTankRPGLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankRPGLauncher")) 
	{	Player::trigger(%player,$TankRPGSlotA,true);
		Player::trigger(%player,$TankRPGSlotB,true);
		Player::trigger(%player,$TankRPGSlotC,true); 
		schedule("CheckTankRPGLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringTankRPGLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$TankRPGSlotA,false); 
		Player::trigger(%player,$TankRPGSlotB,false); 
		Player::trigger(%player,$TankRPGSlotC,false); 
		$FiringTankRPGLauncher[%client] = false; 
	} 
}
//================================================================= New Rocket Gun ============
ItemData ShriekAmmo
{
	description = "Shriek Ammo";
	className = "Ammo";
	shapeFile = "rocket";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData R1Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, -0.2 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData R1
{
	description = "Raptor Part";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = R1Image;
	showWeaponBar = false;
};

ItemImageData RImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Spinning
	accuFire = true;
      ammotype = Shriekammo;
	reloadTime = 1.0;
	fireTime = 0.7;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundWeaponSelect;
};

ItemData R
{
	description = "Shriek Rocket Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "reticle";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RImage;
	price = 420;
	showWeaponBar = true;
};

function R::onMount(%player,%item)
{
	Player::mountItem(%player,R1,7);
}

function R::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function RImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[R]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1500))
		{
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Client::sendMessage(%client,3,"Shriek lock acquired - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"**WARNING** Shriek lock detected - " @ %clientId @ "~waccess_denied.wav");
				Projectile::spawnProjectile("StingerMissile2",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[R],1);
			}
			else
			{
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,%player);
				Player::decItemCount(%player,$WeaponAmmo[R],1);
			}
		}
		else
		{
			Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
			Player::decItemCount(%player,$WeaponAmmo[R],1);
		}
	}
	else 
		Client::sendMessage(Player::getClient(%player),0,"Shriek out of ammo.~waccess_denied.wav");
}
//================================================================= Particle ==================
ItemData KineticAmmo
{
	description = "Atom Disruptor Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData KineticRifleImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
    mountOffset = { -0.2, -0.85, 0.4 }; 
	weaponType = 0; // Single Shot
	ammoType = KineticAmmo;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.3;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 1 };
	sfxActivate = SoundPickUpWeapon;
      sfxFire = ForceFieldOpen; 
      sfxReLoad = SoundElevatorStop;
};

ItemData KineticRifle
{
	description = "Atom Disruptor";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = KineticRifleImage;
	price = 420;
	showWeaponBar = true;
};

function KineticRifleImage::onFire(%this,%slot)
{
  %client = Player::getClient(%this);
  schedule("kineticFire("@%this@","@8@");",0.01,%this);
  if(!Player::isDead(%this)) Player::decItemCount(%client,KineticAmmo,1);
}

function kineticFire(%this,%repeat)
{
  if(%repeat == 0) return;
  %client = Player::getClient(%this);
  %trans = GameBase::getMuzzleTransform(%client);
  %vel = Item::getVelocity(%client);
  Projectile::spawnProjectile(ParticleBolt,%trans,%this,%vel);
  %repeat--;
  schedule("kineticFire("@%this@","@%repeat@");",0.12,%this);
}
//-------------------------------------------------
ItemData FlamerAmmo
{
	description = "Mini Atom Disruptor";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 7;
};

ItemImageData FlamerImage
{
	shapeFile = "Grenadel";
	mountPoint = 0;
      mountOffset = { -0.1, -0.6, 0.2 };
	weaponType = 0; // Single Shot
	ammoType = FlamerAmmo;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.3;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 1 };
	sfxActivate = SoundPickUpWeapon;
      sfxFire = ForceFieldOpen; 
      sfxReLoad = SoundElevatorStop;
};

ItemData Flamer
{
	description = "Mini Atom Disruptor";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "sniper";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 420;
	showWeaponBar = true;
};

function FlamerImage::onFire(%this,%slot)
{
  %client = Player::getClient(%this);
  schedule("FlamerFire("@%this@","@8@");",0.01,%this);
  if(!Player::isDead(%this)) Player::decItemCount(%client,FlamerAmmo,1);
}

function FlamerFire(%this,%repeat)
{
  if(%repeat == 0) return;
  %client = Player::getClient(%this);
  %trans = GameBase::getMuzzleTransform(%client);
  %vel = Item::getVelocity(%client);
  Projectile::spawnProjectile(MiniParticleBolt,%trans,%this,%vel);
  %repeat--;
  schedule("FlamerFire("@%this@","@%repeat@");",0.12,%this);
}
exec(weapons2);

