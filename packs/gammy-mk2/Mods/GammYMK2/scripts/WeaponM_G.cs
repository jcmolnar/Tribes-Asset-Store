//--------------------------------------

$AutoUse[Nuke] = True;
$SellAmmo[MortarAmmo] = 5;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackItems[6] = MortarAmmo;
$WeaponAmmo[Nuke] = MortarAmmo;

//--------------------------------------

$InvList[Nuke] = 1;
$InvList[MortarAmmo] = 1;
$RemoteInvList[Nuke] = 1;
$RemoteInvList[MortarAmmo] = 1;

//--------------------------------------
RocketData NukeMissile
{
   bulletShapeName = "Disc.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 20.0;
   terminalVelocity = 20.0;
   acceleration     = 20.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};


//--------------------------------------

ItemData StrikeAmmo
{
	description = "Radio Strikes";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData NukeImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = NukeMissile;
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
        soundId = SoundJetHeavy;
};

function NukeMissile::onAdd(%this)
{
	schedule("DeployBombs(" @ %this @ " , 25);",5.0,%this);
}

function DeployBombs(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2,true);
		
                %obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
                %obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,1,True);
                %obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2,True);
                %obj = newObject("","Mine","HandGrenade");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,3,True);
                %obj = newObject("","Mine","AntipersonelMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-3,True);
                %obj = newObject("","Mine","AntipersonelMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2,True);
		%obj = newObject("","Mine","AntipersonelMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-1,True);
                %obj = newObject("","Mine","AntipersonelMine");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-3,True); 
                %count -= 1;
		schedule("DeployBombs(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

ItemData Nuke
{
	description = "Silly Bomber";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bRocket Launchers";
	shadowDetailMask = 4;
	imageType = NukeImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

//--------------------------------------
function Nuke::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), " The Silly Bomber fly's a few seconds then drops explosives :) Fun at parties.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------
//--------------------------------------

$SellAmmo[StrikeAmmo] = 2;
$AmmoPackMax[StikeAmmo] = 10;
$AmmoPackItems[2] = StrikeAmmo;
$WeaponAmmo[RocketLauncher2Sky] = StrikeAmmo;


$InvList[RocketLauncher2sky] = 1;
$InvList[StrikeAmmo] = 1;
$RemoteInvList[RocketLauncher2sky] = 1;
$RemoteInvList[StrikeAmmo] = 1;


SeekingMissileData KH2sky
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = plasmaExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $PlasmaDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 30.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 30.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
    seekingTurningRadius = 5.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "PlasmaTrail.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};

SeekingMissileData SWAWave2sky
{
   bulletShapeName    = "Rocket.dts";
   explosionTag       = Largeshockwave;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ElectricityDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 330.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 30.0;
   acceleration     = 2.0;

   totalTime        = 58.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;
   seekingTurningRadius = 5.0;
   nonSeekingTurningRadius = 5.0;
   proximityDist = 1.5;   

    // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield_medium.dts";
   smokeDist   = 1;
 
   soundId = SoundTankCrash;
};

RocketData StingerMissile2s
{
   bulletShapeName = "Shield_large.dts";
   explosionTag    = GrenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.9;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 20.5;
   kickBackStrength = 300.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 2000.0;
   acceleration     = 50.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };


   inheritedVelocityScale = 0.5;

    // rocket specific
   trailType   = 3;                // smoke trail
   trailString = "Shield_large.dts";
   smokeDist   = 0.1;


   soundId = SoundJetHeavy;
};

//--------------------------------------

SeekingMissileData StingerMissileTracker2sky
{
bulletShapeName = "Rocket.dts";
explosionTag = MortarExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 1.0;
damageType = $MissileDamageType;
explosionRadius = 9.5;
kickBackStrength = 200.0;
muzzleVelocity = 50.0;
terminalVelocity = 30.0;
acceleration = 2.0;
totalTime = 50.0;
liveTime = 21.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
seekingTurningRadius = 5.0;
nonSeekingTurningRadius = 5.0;
proximityDist = 1.5;
lightRange = 30.0;
lightColor = { 0.4, 0.4, 1.0 };
trailType = 2;
trailString = "PlasmaTrail.dts";
smokeDist = 2.5;
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;

};




ItemImageData RocketImage2sky
{
	shapeFile = "Tumult_Large";
	mountPoint = 0;
	mountOffset = { 0, 0, 250 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = StrikeAmmo;
	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 2.3;
	fireTime = 1.2;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundTankActive;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundTankActive;
	sfxReady = SoundFlyerActive;
};

function RocketImage2sky::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher2sky]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher2sky],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,950)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "Simterrain" || %object == "StaticShape") 
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker2sky(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wacknow.wav");
						Projectile::spawnProjectile("StingerMissileTracker2sky",%trans,%player,%vel+1,$los::object);
Projectile::SpawnProjectile("SWAWave2sky",%trans,%player,%vel+30,$los::object);	
Projectile::SpawnProjectile("KH2sky",%trans,%player,%vel+60,$los::object);	
Projectile::spawnProjectile("StingerMissileTracker2sky",%trans,%player,%vel-1,$los::object);
Projectile::SpawnProjectile("SWAWave2sky",%trans,%player,%vel-30,$los::object);	
Projectile::SpawnProjectile("KH2sky",%trans,%player,%vel-60,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");
						
					}
				 }
				 else
				 {
Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");					 
				 }
		 	}
			else
			{
Client::sendMessage(Player::getClient(%player), 0,"Must have a target ~waccess_denied.wav");				
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no AirStrikes ~waccess_denied.wav");


} //=== End standard missile fire.




ItemData RocketLauncher2sky
{
	description = "Radio Strike";
	className = "Weapon";
	shapeFile = "Tumult_Large";
	hudIcon = "mortar";
    heading = "rTools";
	shadowDetailMask = 4;
	imageType = RocketImage2sky;
	price = 2375;
	showWeaponBar = true;
};

function Tracker2sky(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " Incomming Missiles from off the planet ~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher2sky::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Radio Strike, This weapon calls a dropship high above the planet to launch super powerfull missiles at the target.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------