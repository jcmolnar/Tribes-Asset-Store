//================================================================
//Frag Grenade Launcher
//================================================================
$AutoUse[FGL] = False;
//================================================================
$InvList[FGL] = 1;
$InvList[FGLAmmo] = 1;
$RemoteInvList[FGL] = 1;
$RemoteInvList[FGLAmmo] = 1;
//================================================================
$DamageScale[larmor, $FGLDamageType] = 1.0;
$DamageScale[lfemale, $FGLDamageType] = 1.0;
$DamageScale[marmor, $FGLDamageType] = 1.0;
$DamageScale[mfemale, $FGLDamageType] = 1.0;
$DamageScale[harmor, $FGLDamageType] = 1.0;
	
$ItemMax[larmor, FGL] = 1;				
$ItemMax[lfemale, FGL] = 1;						
$ItemMax[marmor, FGL] = 1;				
$ItemMax[mfemale, FGL] = 1;				
$ItemMax[harmor, FGL] = 1;				

$ItemMax[larmor, FGLAmmo] = 15;
$ItemMax[lfemale, FGLAmmo] = 15;
$ItemMax[marmor, FGLAmmo] = 25;
$ItemMax[mfemale, FGLAmmo] = 25;
$ItemMax[harmor, FGLAmmo] = 50;
//================================================================
SoundData fglExplosion
{
   wavFileName = "exp_fgl.wav";
   profile = Profile3dFar;
};
SoundData SoundWPNFGLReload
{
   wavFileName = "wpn_fgl_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNFGL
{
   wavFileName = "wpn_fgl.wav";
   profile = Profile3dNear;
};
//================================================================
ExplosionData FGLExp
{
   shapeName = "chainspk.dts";
   soundId   = fglExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 10.0;

   timeZero = 0.200;
   timeOne  = 0.950;

   colors[0]  = { 3.0, 1.0, 1.0 };
   colors[1]  = { 3.0, 2.0, 2.0 };
   colors[2]  = { 3.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
ExplosionData FGLSplitExp
{
   shapeName = "smoke.dts";
   soundId   = fglExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = false;
   lightRange = 0.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 3.0, 1.0, 1.0 };
   colors[1]  = { 3.0, 0.0, 0.0 };
   colors[2]  = { 3.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};
//================================================================
GrenadeData FGLShell
{
   bulletShapeName    = "proj_fgl.dts";
   explosionTag       = FGLSplitExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.2;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $FGLDamageType;

   explosionRadius    = 5.0;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 375;
   totalTime          = 15.0;
   liveTime           = 15.0; // grenade time live after contact
   projSpecialTime    = 0.05; // smoke interval

   inheritedVelocityScale = 0.5;
   smokeName     = "chainspk.dts";
};
GrenadeData PrettySplit3// second stage split
{
   bulletShapeName    = "chainspk.dts";
   explosionTag       = FGLSplitExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $FGLDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 250;
   totalTime          = 0.15;    // special meaning for grenades...
   liveTime           = 0.15; // grenade time live after contact
   projSpecialTime    = 0.15;

   inheritedVelocityScale = 0.5;

   smokeName              = "chainspk.dts";
};
GrenadeData FGLproj// final stage exp
{
   bulletShapeName    = "chainspk.dts";
   explosionTag       = FGLExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.3;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.0;
   damageType         = $FGLDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 35;
   totalTime          = 0.35;    // special meaning for grenades...
   liveTime           = 0.35;     // grenade time live after contact
   projSpecialTime    = 0.15;

   inheritedVelocityScale = 3;

   smokeName              = "chainspk.dts";

};
//================================================================
ItemData FGLAmmo
 {
 description = "Frag Rounds";
 className = "Ammo";
 shapeFile = "grenammo";
 heading = "xAmmunition";
 shadowDetailMask = 4;
 price = 0;
 };


ItemImageData FGLImage
 {
 shapeFile = "wpn_fgl";
 mountPoint = 0;
 weaponType = 0;
 ammoType = FGLAmmo;
 //projectileType = Flakproj;
 reloadTime = 0.5;
 accuFire = false;
 fireTime = 0.25;
 sfxFire = SoundWPNFGL;
 sfxActivate = SoundPickUpWeapon;
 sfxReady = SoundWPNFGLReload;
 };

 ItemData FGL
 {
 heading = "bWeapons";
 description = "Frag Grenade Launcher";
 className = "Weapon";
 shapeFile = "wpn_fgl";
 hudIcon = "fgl";
 shadowDetailMask = 4;
 imageType = FGLImage;
 price = 0;
 showWeaponBar = true;
  // validateShape = true;
   //validateMaterials = true;
 };

function FGLImage::onFire(%this) 
{ 
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,FGLAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,FGLAmmo);
	if(GameBase::getLOSInfo(%this,800)){
		%Dist=Vector::getDistance(GameBase::getPosition(%this),$los::position);
		if(%Dist == 0)  %time = 1;
		else	%time=(%Dist/180)-0.05;
 		%newObj = Projectile::spawnProjectile("FGLShell", %trans, %this, %vel);
		schedule("SpawnFGL(" @ %newObj @ ", " @ %this @ ");", %time);
		
	}
	else{
		%time = 1; 
 		%newObj = Projectile::spawnProjectile("FGLShell", %trans, %this, %vel);
		schedule("SpawnFGL(" @ %newObj @ ", " @ %this @ ");", %time);
	}
	}
}

function SpawnFGL(%newobj,%this){

echo("this spawn FGL",%this);

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PrettySplit3", %trans, %this, %vel);
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
 		%obj = Projectile::spawnProjectile("FGLproj", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);

	Item::setVelocity(%obj, %forceVel);

		}
	deleteobject(%newObj);
	}
}
//================================================================
//echo("FGL Loaded");