//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Sten);
$InvList[Sten] = 1;

$AutoUse[Sten] = True;
$WeaponAmmo[Sten] = "";

$ItemMax[larmor, Sten] = 0;		//Seraph
$ItemMax[lfemale, Sten] = 0;		//Seraph
$ItemMax[earmor, Sten] = 0;		//Slave
$ItemMax[efemale, Sten] = 0;		//Slave
$ItemMax[marmor, Sten] = 0;		//Pawn
$ItemMax[aarmor, Sten] = 1;		//Navigator
$ItemMax[darmor, Sten] = 0;		//Atomizer
$ItemMax[barmor, Sten] = 0;		//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ExplosionData stenExp
{
   shapeName = "fusionex.dts";
   //soundId   = turretExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0,  1.0,  1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

BulletData StenShot
{	bulletShapeName = "paint.dts";
	explosionTag = stenExp;
	expRandCycle       = 0.02;
   	aimDeflection      = 0.025;
	mass = 0.05;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.1;
	damageType = $ElectricityDamageType;
	explosionRadius = 2.5;
	muzzleVelocity = 375.0;
	totalTime = 0.67;
	liveTime = 0.66;
	isVisible = True;
	rotationPeriod = 1;
};

ItemImageData StenImage
{
shapeFile = "grenadeL";

   mountRotation = { 0, 3.14, 0 };
   mountOffset = { 0, -0.17, 0.05 };
   
   mountPoint = 0;
   weaponType = 0;  // Single
   //projectileType = StenCharge;
   minEnergy = 5;
   maxEnergy = 6;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;                    
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireBlaster;
   //sfxFire     =
};

ItemData Sten
{
   description = "Zettawatt Shotgun";
   shapeFile = "shotgun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = StenImage;
	showWeaponBar = true;
   price = 77;
   validateShape = true;
};





ItemImageData Sten2Image
{
   shapeFile = "grenadeL";
   mountRotation = {3.14 , 0 , 0 };
   mountOffset = { 0 , 0.27 , 0.17 };
   mountPoint = 0;
   weaponType = 0;  // Single
   projectileType = PlasEnShell;
   minEnergy = 0;
   maxEnergy = 0;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;                    
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireGrenade;
   sfxFire     = SoundELFIdle;
};

ItemData Sten2
{
   description = "Energy Shotgun";
   shapeFile = "shotgun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Sten2Image;
	showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemImageData Sten3Image
{
   shapeFile = "shotgun";
   mountRotation = {0 , -1.57 , 0 };
   mountOffset = { -0.07 , -0.42 , 0 };
   mountPoint = 0;
   weaponType = 0;  // Single
   projectileType = PlasEnShell;
   minEnergy = 0;
   maxEnergy = 0;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;                    
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireGrenade;
   sfxFire     = SoundELFIdle;
};

ItemData Sten3
{
   description = "Energy Shotgun";
   shapeFile = "energygun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Sten3Image;
	showWeaponBar = true;
   price = 77;
   validateShape = true;
};

ItemImageData Sten4Image
{
   shapeFile = "shotgun";
   mountRotation = {0 , 1.57 , 0 };
   mountOffset = { 0.07 , -0.42 , 0 };
   mountPoint = 0;
   weaponType = 0;  // Single
   projectileType = PlasEnShell;
   minEnergy = 0;
   maxEnergy = 0;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;                    
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireGrenade;
   sfxFire     = SoundELFIdle;
};

ItemData Sten4
{
   description = "Energy Shotgun";
   shapeFile = "energygun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = Sten4Image;
   showWeaponBar = true;
   price = 77;
   validateShape = true;
};

//function StenImage::onFire(%player, %slot)
//function enshot(%player) 
//{	
//	%energy = GameBase::getEnergy(%player);
//	%energy -= 5.5;
//	GameBase::setEnergy(%player,%energy);
//	//Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
//	%trans = GameBase::getMuzzleTransform(%player);
//	%vel = Item::getVelocity(%player);
//	//  BY PLASMATICA <<<<||>>>> CHECK OUT SEX MOD
//	for(%i=0; %i < 8; %i += 1) {
//	Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//}
//}

function StenImage::onFire(%player, %slot) 
{

	%playerId = Player::getClient(%player);
	%fired.deployer = %player;
	%client = GameBase::getOwnerClient(%player);
	%vel = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);

	if (!%playerId.Sten || %playerId.Sten == 0)
	{
		%energy = GameBase::getEnergy(%player);
		%energy -= 5.5;
		GameBase::setEnergy(%player,%energy);
		for(%i=0; %i < 8; %i += 1)
		{
			Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
		}
	}
	else if (%playerId.Sten == 1)
	{

		%fired = Projectile::spawnProjectile("PlasEnShell",%trans,%player,%vel);
		%energy = GameBase::getEnergy(%player);
		%energy -= 20;
		GameBase::setEnergy(%player,%energy);
	}
}

//function StenImage::onFire(%player, %slot) 
//{
//	%playerId = Player::getClient(%player);
// 	%fired.deployer = %player;
//	%client = GameBase::getOwnerClient(%player);
//	%vel = Item::getVelocity(%player);
//	%trans = GameBase::getMuzzleTransform(%player);
//	//
//	%energy = GameBase::getEnergy(%player);
//	%energy -= 5.5;
//	GameBase::setEnergy(%player,%energy);
//	//Player::trigger(%player, 0, true);
//	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//	%fired = Projectile::spawnProjectile("StenShot",%trans,%player,%vel);
//	//Player::trigger(%player, 0, false);			
//
//}

function Sten::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.Sten || %client.Sten == 0)
	{
	        bottomprint(%client, "<jc><f2>Zettawatt Shotgun<f1> Shotgun Mode", 2);
	}
	if (%client.Sten == 1)
	{
	        bottomprint(%client, "<jc><f2>Zettawatt Shotgun<f1> Grenade Mode", 2);
	}       
}


$StenSlotA=4;
$StenSlotB=6;
$StenSlotC=7;

function Sten::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Zettawatt Shotgun");
	Player::mountItem(%player,sten2,$StenSlotA);
	Player::mountItem(%player,sten3,$StenSlotB);
	Player::mountItem(%player,sten4,$StenSlotC);
}

function Sten::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$StenSlotA);
	Player::unmountItem(%player,$StenSlotB);
	Player::unmountItem(%player,$StenSlotC);
}

