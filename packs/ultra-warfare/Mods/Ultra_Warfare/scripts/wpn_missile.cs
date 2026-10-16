//================================================================
//Missile
//================================================================
$AutoUse[MissileLauncher] = False;
//===========================================
$InvList[MissileLauncher] = 1;
$InvList[MissileAmmo] = 1;
$RemoteInvList[MissileLauncher] = 1;
$RemoteInvList[MissileAmmo] = 1;
//================================================================
$DamageScale[larmor, $MissileDamageType] = 2.0;
$DamageScale[lfemale, $MissileDamageType] = 2.0;
$DamageScale[marmor, $MissileDamageType] = 2.0;
$DamageScale[mfemale, $MissileDamageType] = 2.0;
$DamageScale[harmor, $MissileDamageType] = 2.0;
					
$ItemMax[larmor, MissileLauncher] = 0;				
$ItemMax[lfemale, MissileLauncher] = 0;				
$ItemMax[marmor, MissileLauncher] = 0;				
$ItemMax[mfemale, MissileLauncher] = 0;				
$ItemMax[harmor, MissileLauncher] = 1;				
			
$ItemMax[larmor, MissileAmmo] = 0;
$ItemMax[lfemale, MissileAmmo] = 0;
$ItemMax[marmor, MissileAmmo] = 0;
$ItemMax[mfemale, MissileAmmo] = 0;
$ItemMax[harmor, MissileAmmo] = 50;
//================================================================
SoundData SoundWPNMissileReload
{
   wavFileName = "wpn_missile_load.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNMissileAct
{
   wavFileName = "wpn_missile_act.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNMissile
{
   wavFileName = "wpn_missile.wav";
   profile = Profile3dNear;
};
SoundData MissileExplosion
{
	wavFilename = "exp_missile.wav";
	profile = Profile3dFar;
};
SoundData SoundWhizMissile
{
   wavFileName = "whiz_missile.wav";
   profile = Profile3dMediumLoop;
};
//================================================================
ExplosionData MissileExp
{
   shapeName = "fiery.dts";
   soundId   = MissileExplosion;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 7.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 0.75, 0.0 };
};
//================================================================
SeekingMissileData MissileONE
{ 
   bulletShapeName = "proj_missile.dts";
   explosionTag = MissileExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 5.0;
   damageType = $MissileDamageType;
   explosionRadius = 9;
   kickBackStrength = 100;
   
   muzzleVelocity = 550.0;
   terminalVelocity = 250.0;
   acceleration = 25.0;
   
   totalTime = 20.0;
   liveTime = 21.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 5;
   
   trailType = 2; 
   trailString = "msmoke.dts";
 
   inheritedVelocityScale = 0.76;
   
    soundId = SoundWhizMissile;
}; 
SeekingMissileData MissileTWO
{ 
   bulletShapeName = "proj_missile.dts";
   explosionTag = MissileExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 5.0;
   damageType = $MissileDamageType;
   explosionRadius = 9;
   kickBackStrength = 100;
   
   muzzleVelocity = 550.0;
   terminalVelocity = 250.0;
   acceleration = 25;
   
   totalTime = 15.0;
   liveTime = 15.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 5.0;
   
   trailType = 2; 
   trailString = "msmoke.dts";
   
   inheritedVelocityScale = 0.76;
   
   soundId = SoundWhizMissile;
}; 

RocketData Missilealt
{
   bulletShapeName  = "proj_missile.dts";
   explosionTag     = MissileExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2;
   damageType       = $MissileDamageType;

   explosionRadius  = 12.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 250.0;
   terminalVelocity = 250.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   //lightRange       = 5.0;
   //lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   //rocket specific
   trailType   = 2;                // smoke trail
   trailString = "msmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundWhizMissile;
};
//================================================================
ItemData MissileAmmo 
{ 
        description = "Missiles";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "ammo_missile";
        shadowDetailMask = 4;
        price = 0;
}; 
ItemImageData MissileLauncherImage 
{ 
        shapeFile = "wpn_MissileL";
        mountPoint = 0;
        weaponType = 0;
        ammoType = MissileAmmo;
        //projectileType = RocketProj;
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 0.5;
        sfxFire = SoundWPNMissile;
        sfxActivate = SoundWPNMissileAct;
        sfxReload = SoundWPNMissileReload;
       
};
ItemData MissileLauncher
{ 
        description = "Missile Launcher";
        className = "Weapon";
        shapeFile = "wpn_MissileL";
        hudIcon = "Missile";
        heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = MissileLauncherImage;
        price = 0;
        showWeaponBar = true;
       //validateShape = true;
      // validateMaterials = true;
};

function MissileLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[MissileLauncher],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,350)) 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("MissileOne",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("MissileTwo",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("MissileTwo",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("MissileAlt",%trans,%player,%vel,%player);
	} else 
                        Projectile::spawnProjectile("Missilealt",%trans,%player,%vel,%player);  
} 

function RocketLockWarning(%clientId, %target, %targetType) 
{ 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier) {
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else 
			%msg = "Vehicle"; 
	} else 
		%msg = %targetName; 
	Client::sendMessage(%clientId,0,"Lock Aquired: " @ %msg @ "~wwpn_missile_lock.wav");
	//if(%targetType == Flier || whatArm(Player::getArmor(%target)) == 3) {
		if(%targetType == "Player" || %targetType == "Flier") {
		Client::sendMessage(%targetId,0,"WARNING - " @ %name @ " has a missile lock!~wmsg_warning.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~wwpn_missile_tgt.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~wwpn_missile_tgt.wav\");", 1.0);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~wwpn_missile_inc.wav\");", 1.5); 
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~wwpn_missile_inc.wav\");", 2.0); 
	}
}
///////////////////////////////////////////////////////////
//echo("Missile Loaded");