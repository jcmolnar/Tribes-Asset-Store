//================================================================
// Rocket launcher 
//================================================================

SoundData SoundFireRocket
{
   wavFileName = "flierrocket.wav";
   profile = Profile3dNear;
};

SoundData SoundRocketReload
{
   wavFileName = "turreton2.wav";
   profile = Profile3dNearLoop;
};

SoundData ExplosionRocket
{
   wavFileName = "turretexp.wav";
   profile = Profile3dMedium;
};

//================================================================

ExplosionData MissileExp
{
   shapeName = "bluex.dts";
   soundId   = ExplosionRocket;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 3.0;

   timeScale = 1.5;

   timeZero = 0.250;
   timeOne  = 0.850;

   colors[0]  = { 0.4, 0.4,  1.0 };
   colors[1]  = { 1.0, 1.0,  1.0 };
   colors[2]  = { 1.0, 0.95, 1.0 };
   radFactors = { 0.0, 0.0, 0.0 };
};

//================================================================
SeekingMissileData ProjSeeker
{ 
   bulletShapeName = "rocket.dts";
   explosionTag = MissileExp;
   collisionRadius = 0.0;
   mass = 2.0;
   
   damageClass = 1;
   damageValue = 1.0;
   damageType = $MissileDamageType;
   explosionRadius = 9;
   kickBackStrength = 100;
   
   muzzleVelocity = 1000.0;
   terminalVelocity = 1000.0;
   acceleration = 25;
   
   totalTime = 15.0;
   liveTime = 15.0;
   seekingTurningRadius = 1;
   nonSeekingTurningRadius = 1; 
   proximityDist = 1.5;
   smokeDist = 5.0;
   
   trailType = 2; 
   trailString = "rsmoke.dts";
   
   inheritedVelocityScale = 0.76;
   
}; 

RocketData ProjRocket
{
   bulletShapeName = "rocket.dts";
   explosionTag    = MissileExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.0;
   kickBackStrength = 150.0;

   muzzleVelocity   = 1000.0;
   terminalVelocity = 2500.0;
   acceleration     = 100.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   //trailType   = 1;
   //trailLength = 15;
   //trailWidth  = 0.3;

};

//================================================================
ItemData RocketAmmo
{
	description = "Rocket Ammo";
   	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData EnergyRifleImage
{
	shapeFile = "grenadeL";
   	mountPoint = 0;
        mountoffset = { 0, 0, -0.2 };
        mountrotation = { 0, 3, 0 };
   	weaponType = 0; // Single Shot
	ammoType = RocketAmmo;
	//projectileType = Undefined;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.0;
                        
   	lightType = 3;  // Weapon Fire
   	lightRadius = 2;
   	lightTime = 1;
   	lightColor = { 0.25, 0.25, 0.85 };

   	sfxActivate = SoundPickUpWeapon;
   	sfxFire     = SoundfireRocket;
	//sfxReload = SoundRocketReload;
};

ItemData EnergyRifle
{
   	description = "Rocket Launcher";
	shapeFile = "grenadeL";
	hudIcon = "energyRifle";
   	className = "Weapon";
   	heading = "bWeapons";
   	shadowDetailMask = 4;
   	imageType = EnergyRifleImage;
	price = 0;
	showWeaponBar = true;
	showInventory = true;
  	//validateShape = true;
	//validateMaterials = true;
};

function EnergyRifleImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[EnergyRifle],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,1000)) 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("ProjSeeker",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("ProjRocket",%trans,%player,%vel,%player);
	} else 
                        Projectile::spawnProjectile("ProjRocket",%trans,%player,%vel,%player);  
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
	Client::sendMessage(%clientId,0,"Lock Aquired: " @ %msg @ "~mine_act.wav");
	//if(%targetType == Flier || whatArm(Player::getArmor(%target)) == 3) {
		if(%targetType == "Player" || %targetType == "Flier") {
		Client::sendMessage(%targetId,0,"WARNING - " @ %name @ " has a missile lock!~access_denied.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~error_message.wav\");", 1.0);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~error_message.wav\");", 2.0);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~error_message.wav\");", 3.0); 
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~error_message.wav\");", 4.0); 
	}
}






//=================================================================
//echo("Item Loaded");