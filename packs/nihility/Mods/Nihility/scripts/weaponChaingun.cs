//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Chaingun);
$InvList[Chaingun] = 1;
$InvList[BulletAmmo] = 1;

$SellAmmo[BulletAmmo] = 50;
$AutoUse[Chaingun] = True;
$WeaponAmmo[Chaingun] = BulletAmmo;

$ItemMax[larmor, Chaingun] = 1;		//Seraph
$ItemMax[lfemale, Chaingun] = 1;	//Seraph
$ItemMax[earmor, Chaingun] = 1;		//Slave
$ItemMax[efemale, Chaingun] = 1;	//Slave
$ItemMax[marmor, Chaingun] = 1;		//Pawn
$ItemMax[aarmor, Chaingun] = 0;		//Navigator
$ItemMax[darmor, Chaingun] = 1;		//Atomizer
$ItemMax[barmor, Chaingun] = 1;		//Paladin

$ItemMax[larmor, BulletAmmo] = 100;	//Seraph
$ItemMax[lfemale, BulletAmmo] = 100;	//Seraph
$ItemMax[earmor, BulletAmmo] = 150;	//Slave
$ItemMax[efemale, BulletAmmo] = 150;	//Slave
$ItemMax[marmor, BulletAmmo] = 300;	//Pawn
$ItemMax[aarmor, BulletAmmo] = 0;	//Navigator
$ItemMax[darmor, BulletAmmo] = 350;	//Atomizer
$ItemMax[barmor, BulletAmmo] = 400;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


BulletData ChaingunBullet 
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;
	damageValue = 0.09;
	damageType = $BulletDamageType;
	aimDeflection = 0.002;
	muzzleVelocity = 475.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 60;
}; 

BulletData ExplodingBullet 
{
	bulletShapeName    = "bullet.dts";//tumult_small
	explosionTag       = debrisExpsmall;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.5;
	mass               = 1.0;
	elasticity         = 0.45;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $BulletDamageType;

	explosionRadius    = 2.5;
	kickBackStrength   = 150.0;
	maxLevelFlightDist = 150;
	totalTime          = 30.0;    // special meaning for grenades...
	liveTime           = 1.5;
	projSpecialTime    = 0.05;

	aimDeflection      = 0.002;
	muzzleVelocity     = 200.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 2.0;
	isVisible          = False;

	tracerPercentage   = 1.0;
	tracerLength       = 45;
};

BulletData MiniMissile
{	bulletShapeName = "rocket.dts";
	explosionTag = BlastExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.2;
	damageType = $BulletDamageType;
	explosionRadius = 4.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.0021;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//XXXXXXXXXXXXXX


ItemData BulletAmmo 
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemImageData ChaingunImage 
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.09;
	ammoType = BulletAmmo;
	//projectileType = ChaingunBullet;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1,0,0};
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
}; 

ItemData Chaingun 
{
	description = "Iron Storm A.C.";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 77;
	showWeaponBar = true;
};


function ChaingunImage::onFire(%player, %slot) 
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[Chaingun]);
	%playerId = Player::getClient(%player);
	 
	 if(%Ammo || %client.fireChaingun) 
	 {
	 	%fired.deployer = %player;
		%client = GameBase::getOwnerClient(%player);
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);

		if (!%playerId.Chaingun || %playerId.Chaingun == 0)
		{
			%fired = Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
		}
		else if (%playerId.Chaingun == 1)
		{
			%fired = Projectile::spawnProjectile("ExplodingBullet",%trans,%player,%vel);
		Player::decItemCount(%player,BulletAmmo);
		}
		else if (%playerId.Chaingun == 2)
		{
			%fired = Projectile::spawnProjectile("MiniMissile",%trans,%player,%vel);
			%fired.deployer = %client;
		Player::decItemCount(%player,BulletAmmo);
		Player::decItemCount(%player,BulletAmmo);
		}
		Player::decItemCount(%player,BulletAmmo);
	}	
}

function Chaingun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.Chaingun || %client.Chaingun == 0)
	{
	        bottomprint(%client, "<jc><f2>Iron Storm Autocannon<f1> Standard Rounds", 2);
	}
	if (%client.Chaingun == 1)
	{
	        bottomprint(%client, "<jc><f2>Iron Storm Autocannon<f1> Exploding Rounds", 2);
	}
	if (%client.Chaingun == 2)
	{
	        bottomprint(%client, "<jc><f2>Iron Storm Autocannon<f1> Valhalla Rounds", 2);
	}          
}