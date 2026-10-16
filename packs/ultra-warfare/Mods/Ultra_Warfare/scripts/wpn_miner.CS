//================================================================
//Mine Layer
//================================================================
$AutoUse[Miner] = False;
//===========================================================
$InvList[miner] = 1;
$InvList[MinerAmmo] = 1;
$RemoteInvList[miner] = 1;
$RemoteInvList[MinerAmmo] = 1;
//================================================================
$DamageScale[larmor, $MineDamageType] = 1.0;
$DamageScale[lfemale, $MineDamageType] = 1.0;
$DamageScale[marmor, $MineDamageType] = 1.0;
$DamageScale[mfemale, $MineDamageType] = 1.0;
$DamageScale[harmor, $MineDamageType] = 1.0;
			
$ItemMax[larmor, Miner] = 1;				
$ItemMax[lfemale, Miner] = 1;				
$ItemMax[marmor, Miner] = 1;				
$ItemMax[mfemale, Miner] = 1;				
$ItemMax[harmor, Miner] = 1;

$ItemMax[larmor, MinerAmmo] = 8;
$ItemMax[lfemale, MinerAmmo] = 8;
$ItemMax[marmor, MinerAmmo] = 16;
$ItemMax[mfemale, MinerAmmo] = 16;
$ItemMax[harmor, MinerAmmo] = 32;
//================================================================
SoundData SoundWPNMiner
{
   wavFileName = "wpn_miner.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNMinerReLoad
{
   wavFileName = "wpn_miner_load.wav";
   profile = Profile3dNear;
};
SoundData mineExplosion
{
   wavFileName = "exp_mine.wav";
   profile     = Profile3dFar;
};
//================================================================
ExplosionData radiusmineexp
{
   shapeName = "shockwave_large.dts";
   soundId   = shockExplosion;

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 1;

   timeZero = 0.100;
   timeOne  = 0.300;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 0.0, 0.0, 0.0 };
   radFactors = { 1.0, 0.5, 0.0 };
};
ExplosionData mineExp
{
   shapeName = "shockwave.dts";
   soundId   = mineExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};
//================================================================
GrenadeData MinerShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = MineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.35;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $MineDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 25.0;
   maxLevelFlightDist = 275;
   totalTime          = 15.0;
   liveTime           = 10.0; // grenade time live after contact
   projSpecialTime    = 0.01; // smoke interval

   inheritedVelocityScale = 0.5;
   smokeName     = "smoke.dts";
	
};
GrenadeData MineFloaters
{
   bulletShapeName    = "mine.dts";
   explosionTag       = MineExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	//5.0
   elasticity         = 0.45;	//0.1

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3;
   damageType         = $MineDamageType; 

   explosionRadius    = 20.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; // grenade time live after contact
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
//================================================================
ItemData MinerAmmo
{
        description = "Mine Rounds";
        className = "Ammo";
        shapeFile = "ammo_miner";
   heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 0;
};
ItemImageData MinerImage
{
        shapeFile = "wpn_miner";
        mountPoint = 0;
        weaponType = 0; // Single Shot
        ammoType = MinerAmmo;
        //projectileType = Mineproj;
        accuFire = false;
        reloadTime = 0.75;
        fireTime = 0.05;

        lightType = 3;  // Weapon Fire
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };

        sfxFire = SoundWPNMiner;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundWPNMinerReload;
};
ItemData Miner
{
        description = "Mine Layer";
        className = "Weapon";
        shapeFile = "wpn_miner";
        hudIcon = "miner";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = minerImage;
        price = 0;
        showWeaponBar = true;
	  // validateShape = true;
  // validateMaterials = true;
};

function MinerImage::onFire(%this) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,MinerAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,MinerAmmo);

 		%newObj = Projectile::spawnProjectile("MinerShell", %trans, %this, %vel);
		schedule("TossMines(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitMines(" @ %newObj @ ", " @ %this @ ");", 2.9);
	}
}

function SplitMines(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossMines(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("MineFloaters", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	%rnd = (floor(getRandom()*20)/80);
		schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
		}
	deleteobject(%newObj);
	}
}
function SetMines(%newobj,%this){

	if (GameBase::getPosition(%newObj)){
		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%Mine = newObject("","Mine","antipersonelMine");
		GameBase::setTeam (%Mine,GameBase::getTeam (%this));
 		addToSet("MissionCleanup", %Mine);
      	GameBase::throw(%Mine,%this,-1,true);
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);
	deleteobject(%newObj);
	}
}
//================================================================
//echo("Miner Loaded");