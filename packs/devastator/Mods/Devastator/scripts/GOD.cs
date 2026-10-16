//--------------------------------------------------------------------------------------------------//|
//**************************************<>-|===GOD=CODE===|-<>**************************************//|_________________________________________
//--------------------------------------------------------------------------------------------------//                                          \
// THIS CODE IS USED TO CREATE THE GOD MODE SEQUENCE IN GAME, ANYONE WHO STEALS, OR USES THIS CODE WITHOUT MY PERMISSTION WILL BE SHOT AND EATEN |
//______________________________________________________________________________________________________________________________________________/
// COPYRIGHT 2002 "CT(R)" //|
//------------------------//|
// Ice / FishinSC@aol.com //|
//==========================|

ExplosionData DemiExp
{
	shapeName = "rsmoke.dts";
	faceCamera = true;
	randomSpin = false;
	hasLight   = true;
	lightRange = 0;
	timeZero = 0.450;
	timeOne  = 0.500;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

GrenadeData SuperDemi
{
	bulletShapeName    = "breath.dts";
	explosionTag       = DemiExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;
	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;
	inheritedVelocityScale = -0.5;
	smokeName              = "smoke.dts";
};

ExplosionData LightExp
{
	shapeName = "snowplume.dts";
	faceCamera = true;
	randomSpin = false;
	hasLight   = true;
	lightRange = 0;
	timeZero = 0.450;
	timeOne  = 0.500;
	colors[0]  = { 0.0, 0.0, 0.0 };
	colors[1]  = { 1.0, 1.0, 0.5 };
	colors[2]  = { 1.0, 1.0, 0.5 };
	radFactors = { 0.0, 1.0, 0.0 };
	shiftPosition = True;
};

GrenadeData SuperLight
{
	bulletShapeName    = "breath.dts";
	explosionTag       = LightExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;
	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;
	inheritedVelocityScale = -0.5;
	smokeName              = "snowplume.dts";
};

ExplosionData DarkExp
{
	shapeName = "plastrail.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight   = true;
	lightRange = 3.0;
	timeZero = 0.450;
	timeOne  = 0.750;
	colors[0]  = { 0.25, 0.25, 1.0 };
	colors[1]  = { 0.25, 0.25, 1.0 };
	colors[2]  = { 1.0, 1.0,  1.0 };
	radFactors = { 1.0, 1.0,  1.0 };
	shiftPosition = True;
};

GrenadeData SuperDark
{
	bulletShapeName    = "breath.dts";
	explosionTag       = DarkExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 5.0;
	elasticity         = 0;
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;
	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;
	inheritedVelocityScale = -0.5;
	smokeName              = "plastrail.dts";
};

GrenadeData SuperStart
{
	bulletShapeName    = "breath.dts";
	explosionTag       = LargeShockwave2;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.3;
	mass               = 0.1;
	elasticity         = 0;

	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.0;
	damageType         = $MortarDamageType;

	explosionRadius    = 0.0;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 0;
	totalTime          = 0.01;
	liveTime           = 0.01;
	projSpecialTime    = 0.01;

	inheritedVelocityScale = -0.5;
	smokeName              = "rsmoke.dts";
};

//--------------------------------------

ItemData GOD
{				
	description = "GOD pack";
	className = "Backpack";
	showInventory = false;
};

function GOD::onUse(%player,%item)
{
	if(AreGod(%player) == false && Player::getMountedItem(%player,$BackpackSlot) != DemiPack) {
		if(Player::getMountedItem(%player,$BackpackSlot) == UltraPack)
			PowerExplosion(GameBase::getPosition(%player));
		else if(Player::getMountedItem(%player,$BackpackSlot) == Perfect)
			PowerExplosion(GameBase::getPosition(%player));
		else
			projectile::spawnprojectile("SuperStart",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	}
	Backpack::onUse(%player,%item);
}

//--------------------------------------

ItemImageData DemiPackImage
{
	shapeFile = "force";
	mountPoint = 2; 
	weaponType = 0;
	mountOffset = { 0, 0.1, 0 }; //-  left-right, back-front, up-down
	projectileType = SuperDemi;
	reloadTime = 0;
	minEnergy = -1;
	maxEnergy = -6;   // Energy/sec for sustained weapons
	firstPerson = false;
};

ItemData DemiPack
{
	description = "Demi-God";
	shapeFile = "force";
	className = "GOD";
	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = DemiPackImage;
	price = 175;
	hudIcon = "fear";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemImageData SuperPack1Image
{
	shapeFile = "force";
	mountPoint = 2; 
	weaponType = 0;
	mountOffset = { 0, 0.1, 0 }; //-  left-right, back-front, up-down
	projectileType = SuperLight;
	reloadTime = 0;
	minEnergy = -1;
	maxEnergy = -8;   // Energy/sec for sustained weapons
	firstPerson = false;
};

ItemData SuperPack1
{
	description = "Light";
	shapeFile = "force";
	className = "GOD";
	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = SuperPack1Image;
	price = 175;
	hudIcon = "fear";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemImageData SuperPack2Image
{
	shapeFile = "force";
	mountPoint = 2; 
	weaponType = 0;
	mountOffset = { 0, 0.1, 0 }; //-  left-right, back-front, up-down
	projectileType = SuperDark;
	reloadTime = 0;
	minEnergy = -1;
	maxEnergy = -8;   // Energy/sec for sustained weapons
	firstPerson = false;
};

ItemData SuperPack2
{
	description = "Dark";
	shapeFile = "force";
	className = "GOD";
	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = SuperPack2Image;
	price = 175;
	hudIcon = "fear";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$ItemMax[larmor, DemiPack] = 0;
$ItemMax[qarmor, DemiPack] = 0;
$ItemMax[sarmor, DemiPack] = 0;
$ItemMax[srarmor, DemiPack] = 0;
$ItemMax[marmor, DemiPack] = 0;
$ItemMax[parmor, DemiPack] = 0;
$ItemMax[tarmor, DemiPack] = 0;
$ItemMax[harmor, DemiPack] = 0;
$ItemMax[lfemale, DemiPack] = 0;
$ItemMax[qfemale, DemiPack] = 0;
$ItemMax[sfemale, DemiPack] = 0;
$ItemMax[srfemale, DemiPack] = 0;
$ItemMax[mfemale, DemiPack] = 0;
$ItemMax[pfemale, DemiPack] = 0;
$ItemMax[psarmor, DemiPack] = 0;

$ItemMax[larmor, SuperPack1] = 0;
$ItemMax[qarmor, SuperPack1] = 0;
$ItemMax[sarmor, SuperPack1] = 0;
$ItemMax[srarmor, SuperPack1] = 0;
$ItemMax[marmor, SuperPack1] = 0;
$ItemMax[parmor, SuperPack1] = 0;
$ItemMax[tarmor, SuperPack1] = 0;
$ItemMax[harmor, SuperPack1] = 0;
$ItemMax[lfemale, SuperPack1] = 0;
$ItemMax[qfemale, SuperPack1] = 0;
$ItemMax[sfemale, SuperPack1] = 0;
$ItemMax[srfemale, SuperPack1] = 0;
$ItemMax[mfemale, SuperPack1] = 0;
$ItemMax[pfemale, SuperPack1] = 0;
$ItemMax[psarmor, SuperPack1] = 0;

$ItemMax[larmor, SuperPack2] = 0;
$ItemMax[qarmor, SuperPack2] = 0;
$ItemMax[sarmor, SuperPack2] = 0;
$ItemMax[srarmor, SuperPack2] = 0;
$ItemMax[marmor, SuperPack2] = 0;
$ItemMax[parmor, SuperPack2] = 0;
$ItemMax[tarmor, SuperPack2] = 0;
$ItemMax[harmor, SuperPack2] = 0;
$ItemMax[lfemale, SuperPack2] = 0;
$ItemMax[qfemale, SuperPack2] = 0;
$ItemMax[sfemale, SuperPack2] = 0;
$ItemMax[srfemale, SuperPack2] = 0;
$ItemMax[mfemale, SuperPack2] = 0;
$ItemMax[pfemale, SuperPack2] = 0;
$ItemMax[psarmor, SuperPack2] = 0;

function MakeGod(%clientId,%type)
{
	echo(%clientId.GODpref@", "@%type);
	if(%type == "Light") { //- A favorite of many, the Light GOD is easier to use with more fun weapons
		Player::setItemCount(%clientId,RL,1);
		Player::setItemCount(%clientId,MG,1);
		Player::setItemCount(%clientId,AR,1);
		Player::setItemCount(%clientId,SR,1);
		Player::setItemCount(%clientId,TB,1);
		Player::setItemCount(%clientId,BH,1);
		Player::setItemCount(%clientId,EL,1);
		Player::setItemCount(%clientId,Keg,1);
		Player::setItemCount(%clientId,Shotgun1,1);
		Player::setItemCount(%clientId,Sword,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,Tazer,1);
		Player::setItemCount(%clientId,Shock,1);
		Player::setItemCount(%clientId,Funk,1);
		Player::setItemCount(%clientId,Beam,1);
		Player::setItemCount(%clientId,V,1);
		Player::setItemCount(%clientId,R,1);

		Player::setItemCount(%clientId,GrenadeAmmo,500);
		Player::setItemCount(%clientId,DiscAmmo,500);
		Player::setItemCount(%clientId,MortarAmmo,500);
		Player::setItemCount(%clientId,MultiAmmo,500);
		Player::setItemCount(%clientId,RLAmmo,500);
		Player::setItemCount(%clientId,ELAmmo,200);
		Player::setItemCount(%clientId,MGAmmo,99999);
		Player::setItemCount(%clientId,PGLAmmo,500);
		Player::setItemCount(%clientId,SRAmmo,5);
		Player::setItemCount(%clientId,ARAmmo,30);
		Player::setItemCount(%clientId,Shotgun1Ammo,2);
		Player::setItemCount(%clientId,SniperClip,999);
		Player::setItemCount(%clientId,PistolClip,900);
		Player::setItemCount(%clientId,AssaultClip,900);
		Player::setItemCount(%clientId,ShotgunClip,900);
		Player::setItemCount(%clientId,SmokeAmmo,200);

		Player::setItemCount(%clientId,Grenade, 200);
		Player::setItemCount(%clientId,MineAmmo, 50);
		Player::setItemCount(%clientId,Beacon, 5);
		Player::setItemCount(%clientId,RepairKit,200);
		Player::setItemCount(%clientId,SuperPack1,1);

		Player::mountItem(%clientId,SuperPack1,1);
	}
	else if(%type == "Dark") { //- The most menacing of the GODs, with a more  powerful arsenal
		Player::setItemCount(%clientId,RL,1);
		Player::setItemCount(%clientId,MG,1);
		Player::setItemCount(%clientId,PC,1);
		Player::setItemCount(%clientId,BH,1);
		Player::setItemCount(%clientId,AR,1);
		Player::setItemCount(%clientId,SR,1);
		Player::setItemCount(%clientId,TB,1);
		Player::setItemCount(%clientId,EL,1);
		Player::setItemCount(%clientId,Shotgun1,1);
		Player::setItemCount(%clientId,PGL,1);
		Player::setItemCount(%clientId,Multi,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,SmokeLauncher,1);
		Player::setItemCount(%clientId,Shock,1);
		Player::setItemCount(%clientId,Funk,1);
		Player::setItemCount(%clientId,V,1);
		Player::setItemCount(%clientId,R,1);

		Player::setItemCount(%clientId,GrenadeAmmo,500);
		Player::setItemCount(%clientId,DiscAmmo,500);
		Player::setItemCount(%clientId,MortarAmmo,500);
		Player::setItemCount(%clientId,MultiAmmo,500);
		Player::setItemCount(%clientId,RLAmmo,500);
		Player::setItemCount(%clientId,ELAmmo,200);
		Player::setItemCount(%clientId,MGAmmo,99999);
		Player::setItemCount(%clientId,PGLAmmo,500);
		Player::setItemCount(%clientId,SRAmmo,5);
		Player::setItemCount(%clientId,ARAmmo,30);
		Player::setItemCount(%clientId,Shotgun1Ammo,2);
		Player::setItemCount(%clientId,SniperClip,999);
		Player::setItemCount(%clientId,PistolClip,900);
		Player::setItemCount(%clientId,AssaultClip,900);
		Player::setItemCount(%clientId,ShotgunClip,900);
		Player::setItemCount(%clientId,SmokeAmmo,200);

		Player::setItemCount(%clientId,Grenade,200);
		Player::setItemCount(%clientId,MineAmmo,50);
		Player::setItemCount(%clientId,Beacon,5);
		Player::setItemCount(%clientId,RepairKit,200);
		Player::setItemCount(%clientId,SuperPack2,1);

		Player::mountItem(%clientId,SuperPack2,1);
	}
	else if(%type == "Demi") { //- The fastest of the GODs but also the weakest
		Player::setItemCount(%clientId,RL,1);
		Player::setItemCount(%clientId,MG,1);
		Player::setItemCount(%clientId,PC,1);
		Player::setItemCount(%clientId,BH,1);
		Player::setItemCount(%clientId,Sword,1);
		Player::setItemCount(%clientId,AR,1);
		Player::setItemCount(%clientId,Keg,1);
		Player::setItemCount(%clientId,SR,1);
		Player::setItemCount(%clientId,TB,1);
		Player::setItemCount(%clientId,Shotgun1,1);
		Player::setItemCount(%clientId,PGL,1);
		Player::setItemCount(%clientId,Multi,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,SmokeLauncher,1);
		Player::setItemCount(%clientId,Shock,1);
		Player::setItemCount(%clientId,Funk,1);

		Player::setItemCount(%clientId,GrenadeAmmo,500);
		Player::setItemCount(%clientId,DiscAmmo,500);
		Player::setItemCount(%clientId,MultiAmmo,500);
		Player::setItemCount(%clientId,RLAmmo,100);
		Player::setItemCount(%clientId,MGAmmo,9999);
		Player::setItemCount(%clientId,PGLAmmo,500);
		Player::setItemCount(%clientId,SRAmmo,5);
		Player::setItemCount(%clientId,ARAmmo,30);
		Player::setItemCount(%clientId,Shotgun1Ammo,2);
		Player::setItemCount(%clientId,SniperClip,20);
		Player::setItemCount(%clientId,PistolClip,50);
		Player::setItemCount(%clientId,AssaultClip,50);
		Player::setItemCount(%clientId,ShotgunClip,50);

		Player::setItemCount(%clientId,Grenade,10);
		Player::setItemCount(%clientId,MineAmmo,10);
		Player::setItemCount(%clientId,Beacon,5);
		Player::setItemCount(%clientId,RepairKit,10);
		Player::setItemCount(%clientId,LessWeight,1);
		Player::setItemCount(%clientId,DemiPack,1);

		Player::mountItem(%clientId,DemiPack,1);
	}
}