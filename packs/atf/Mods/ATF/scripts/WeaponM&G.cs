//--------------------------------------
$ItemMax[larmor, SentinelAmmo] = 3;
$ItemMax[lfemale, SentinelAmmo] = 3;
$ItemMax[Warmor, SentinelAmmo] = 2;
$ItemMax[barmor, SentinelAmmo] = 30;
$ItemMax[barmor, BR] = 1;
$ItemMax[harmor, SentinelAmmo] = 20;
$ItemMax[garmor, SentinelAmmo] = 0;
$ItemMax[xarmor, SentinelAmmo] = 0;
$ItemMax[sarmor, SentinelAmmo] = 17;
$ItemMax[larmor, gAmmo] = 3;
$ItemMax[lfemale, gAmmo] = 3;
$ItemMax[Warmor, gAmmo] = 2;
$ItemMax[barmor, gAmmo] = 40;
$ItemMax[harmor, gAmmo] = 20;
$ItemMax[garmor, gAmmo] = 0;
$ItemMax[xarmor, gAmmo] = 0;
$ItemMax[sarmor, gAmmo] = 17;
$AutoUse[Nuke] = True;

$SellAmmo[SentinelAmmo] = 5;
$AmmoPackMax[SentinelAmmo] = 30;
$AmmoPackItems[1] = SentinelAmmo;
$WeaponAmmo[Nuke] = SentinelAmmo;


//--------------------------------------

$InvList[Nuke] = 1;

$RemoteInvList[Nuke] = 1;


ItemData SentinelAmmo
{
	description = "Sentinel Ammo";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

//--------------------------------------
RocketData NukeMissile
{
   bulletShapeName = "Rocket.dts";
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
   trailString = "smoke.dts";
   smokeDist   = 1.8;

   
   soundId = SoundJetHeavy;
};


MineData grenaded
{
   mass = 0;
   drag = 0;
   density = 0;
	elasticity = 0;
	friction = 0;
	className = "Handgrenade";
   description = "Funade";
   shapeFile = "Mortar";
   shadowDetailMask = 4;
   explosionId = RocketExp;
	explosionRadius = 10.0;
	damageValue = 1;
	damageType = $ExplosionDamageType;
	kickBackStrength = 200;
	triggerRadius = 1.5;
	maxDamage = 2;
};

function grenaded::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("grenaded::Detonate(" @ %this @ ");",1.5,%this);
}


function grenaded::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function grenaded::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);	
}


MineData grenaded1
{
   mass = 200.2;
   drag = 10;
   density = 210;
	elasticity = 0;
	friction = 1000;
	className = "Handgrenade";
   description = "Funade2";
   shapeFile = "Mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 1.0;
	damageType = $ExplosionDamageType;
	kickBackStrength = 200;
	triggerRadius = 1.5;
	maxDamage = 20;
};

function grenaded1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("grenaded1::Detonate(" @ %this @ ");",3.7,%this);
}

function grenaded1::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function grenaded1::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


MineData grenadeA
{
   mass = 200.6;
   drag = 0;
   density = 200;
	elasticity = 0;
	friction = 200;
	className = "Handgrenade";
   description = "Funade";
   shapeFile = "Mortar";
   shadowDetailMask = 4;
   explosionId = GrenadeExp;
	explosionRadius = 10.0;
	damageValue = 1.0;
	damageType = $ExplosionDamageType;
	kickBackStrength = 300;
	triggerRadius = 1.5;
	maxDamage = 20;
};


function grenadea::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("grenadea::Detonate(" @ %this @ ");",3.9,%this);
}

function grenadea::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function grenadea::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

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
	ammoType = SentinelAmmo;
	projectileType = MrMitchell; // Mr. Mitchell is Teh Roxxor
	accuFire = false;
	reloadTime = 2.5;
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

//function NukeMissile::onAdd(%this)
//{
// schedule("DeployBombs(" @ %this @ " , 25);",5.0,%this);	
//}



function NukeImage::onFire(%player) 
{
				%client = Player::getClient(%player);
				%Sensor2 = newObject("remoteTurret","Turret",RocketTurret2,true); 
	   			Player::decItemCount(%player,$WeaponAmmo[Nuke],1);
				addToSet("MissionCleanup", %sensor2);
				Client::setOwnedObject(%client, %Sensor2); 
				Client::setOwnedObject(%client, %player);				      
				gameBase::setTeam(%sensor2,GameBase::getTeam(%player));
				gameBase::setRotation(%sensor2,"0 0 0");// %rot
				gameBase::setPosition(%sensor2,GameBase::getPosition(%player));
				gamebase::setMapName(%sensor2,"Sentinel#" @ $totalNumPlatforms++ @ " " @  Client::getName(%client));
				client::sendMessage(%client,3,"Sentinel Placed");
				playSound(SoundPickupBackpack,$los::position);
				
}

ItemData Nuke
{
	description = "Sentinel Gun";
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
	bottomprint(Player::getClient(%player), "Sentinel guns really aren't guns, When used it places a Sentinel. For about 5 seconds a sentinel stays in place, after which it blows up... during those five seconds if anything that sets out heat comes in range, it fires lockon rockets.", 10);Weapon::onUse(%player,%item);
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
   explosionTag       = RocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

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
   explosionTag       = RocketExp;

    collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

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
explosionTag = RocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1;
damageValue = 0.5;
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
	
				 if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "Simterrain") 
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
Projectile::spawnProjectile("StingerMissileTracker2sky",%trans,%player,%vel+80,$los::object);
Projectile::SpawnProjectile("SWAWave2sky",%trans,%player,%vel+90,$los::object);	
Projectile::SpawnProjectile("KH2sky",%trans,%player,%vel+100,$los::object);	
Projectile::spawnProjectile("StingerMissileTracker2sky",%trans,%player,%vel-80,$los::object);
Projectile::SpawnProjectile("SWAWave2sky",%trans,%player,%vel-90,$los::object);	
Projectile::SpawnProjectile("KH2sky",%trans,%player,%vel-100,$los::object);
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
	description = "Air Strike";
	className = "Weapon";
	shapeFile = "Tumult_Large";
	hudIcon = "mortar";
    heading = "rHaCk's Tools";
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
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " Incoming Missiles from off the planet ~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 



//--------------------------------------
function RocketLauncher2sky::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Air Strike, This weapon calls a dropship high above the planet to launch super powerfull missiles at the target.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------