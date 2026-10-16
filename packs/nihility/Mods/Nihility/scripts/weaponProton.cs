//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(WaveGun);
$InvList[WaveGun] = 1;

$AutoUse[WaveGun] = True;
$WeaponAmmo[WaveGun] = "";

$ItemMax[larmor, WaveGun] = 0;		//Seraph
$ItemMax[lfemale, WaveGun] = 0;		//Seraph
$ItemMax[earmor, WaveGun] = 1;		//Slave
$ItemMax[efemale, WaveGun] = 1;		//Slave
$ItemMax[marmor, WaveGun] = 1;		//Pawn
$ItemMax[aarmor, WaveGun] = 1;		//Navigator
$ItemMax[darmor, WaveGun] = 1;		//Atomizer
$ItemMax[barmor, WaveGun] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++



RocketData Inverseshock
{
	bulletShapeName = "fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $MissileDamageType;
	explosionRadius = 30.0;
	kickBackStrength = -350.0; //350
	muzzleVelocity = 50.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 4.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
}; 


RocketData Shock 
{
	bulletShapeName = "fusionbolt.dts";
	explosionTag = LargeShockwave;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.0;
	damageType = $MissileDamageType;
	explosionRadius = 30.0;
	kickBackStrength = 350.0; //350
	muzzleVelocity = 50.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 4.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	soundId = SoundJetHeavy;
}; 



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
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
}; 

ItemData WaveGun 
{
	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = WaveGunImage;
	price = 77;
	showWeaponBar = true;
}; 

//function WaveGunImage::onfire(%player)
//{
//%smack = 3;
//%client = GameBase::getOwnerClient(%player); 
//%trans = GameBase::getMuzzleTransform(%player); 
//%vel = Item::getVelocity(%player); 
//%energy = GameBase::getEnergy(%player);
// %energy -= 40;
//%newObj = Projectile::spawnProjectile("shock", %trans, %player, %vel);
//WeaponKickBack(%player,%smack);
//}

function WaveGunImage::onFire(%player, %slot) 
{
	%playerId = Player::getClient(%player);
	%energy = GameBase::getEnergy(%player);
 	%fired.deployer = %player;
	%client = GameBase::getOwnerClient(%player);
	%vel = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	if (!%playerId.Wavegun || %playerId.Wavegun == 0)
	{
		%energy -= 40;
		GameBase::setEnergy(%player,%energy);
		//%smack = 5;
		//WeaponKickBack(%player,%smack);
		%newObj = Projectile::spawnProjectile("shock", %trans, %player, %vel);

	}
	else if (%playerId.Wavegun == 1)
	{
		%energy -= 40;
		GameBase::setEnergy(%player,%energy);
		%newObj = Projectile::spawnProjectile("inverseshock", %trans, %player, %vel);

	}
}

function WaveGun::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
	%client = GameBase::getOwnerClient(%player);
	if (!%client.WaveGun || %client.WaveGun == 0)
	{
	        bottomprint(%client, "<jc><f2>Shockwave Cannon<f1> Standard Mode", 2);
	}
	if (%client.WaveGun == 1)
	{
	        bottomprint(%client, "<jc><f2>Shockwave Cannon<f1> Inverse Mode", 2);
	}
       
}

//function WaveGun::onUse(%player,%item)
//{
//Weapon::onUse(%player,%item);
//        bottomprint(Player::getClient(%player), "<jc><f2>Proton Cannon", 2); }
