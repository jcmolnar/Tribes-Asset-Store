$InvList[OSLauncher] = 1;
$MobileInvList[OSLauncher] = 1;
$RemoteInvList[OSLauncher] = 1;

$InvList[OSAmmo] = 1;
$MobileInvList[OSAmmo] = 1;
$RemoteInvList[OSAmmo] = 1;

$AutoUse[OSLauncher] = True;
$SellAmmo[OSAmmo] = 3;
$WeaponAmmo[OSLauncher] = OSAmmo;

addWeapon(OSLauncher);
addAmmo(OSLauncher, OSAmmo, 1);

ItemData OSAmmo 
{	description = "OS Rockets";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData OSLauncherImage
{	shapeFile = "grenadel";
	ammoType = OSAmmo;
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	weaponType = 0; // Single Shot
	minEnergy = 32;
	maxEnergy = 32;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 2.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData OSLauncher 
{	description = "OS Laucher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "fear";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = OSLauncherImage;
	price = 5000;
	showWeaponBar = true;
};

function OSLauncher::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "<f0>Optical Seeking Missile Launcher: <f2>When you fire it, be sure to control it immediately.\n<f1>*WARNING*<f2> Do not fire while in the air or inside a small or enclosed area.");
}

function OSLauncherImage::onFire(%this,%slot)
{	%client = Player::getClient(%this);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	%trans = GameBase::getMuzzleTransform(%client);
	%vel = Item::getVelocity(%client);
	%obj = getObjectType($los::object);
	if(!%player.vehicle)
	{	
		%rot = GameBase::getRotation(%client);
		%posX = getWord(%trans,9);
		%posY = getWord(%trans,10);
		%posZ = getWord(%trans,11) + 1.5; // +3.0
		%position = %posX@" "@%posY@" "@%posZ;
		%obj = newObject("Optical Seeking Missile",flier,OSMissile,true);
		addToSet("MissionCleanup",%obj);
		Gamebase::setMapName(%obj,"Optical Seeking Missile");
		GameBase::setTeam(%obj,GameBase::getTeam(%this));
		GameBase::setPosition(%obj,%position);
		GameBase::setRotation(%obj,%rot);
		GameBase::startFadeIn(%obj);

		%player = Client::getOwnedObject(%client);
	 	//Client::setOwnedObject(%client, %vehicle);
		
		Client::setOwnedObject(%client, %obj);
		Client::setOwnedObject(%client, %player);
				
		Client::setControlObject(%client,%obj);
		
		%this.vehicle = %obj;
		%this.lastWeapon = %weapon;
		Player::unMountItem(%this,$WeaponSlot);
		
		
//			%pl = Client::getOwnedObject(%client);
// 	
// 	Client::setOwnedObject(%client, %vehicle);
//	Client::setOwnedObject(%client, %pl);
//	
//	Client::setControlObject(%client, %vehicle);
		
		
		
	}
	Player::decItemCount(%client,$WeaponAmmo[OSLauncher],1);
}

FlierData OSMissile
{	explosionId = rocketExp;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "rocket";
	shieldShapeName = "shield_medium";
	mass = 7.5; //0.1
	drag = 1.0;
	density = 1.2;
	maxBank = 8;
	maxPitch = 10;
	maxSpeed = 60; //80
	minSpeed = 40;
	lift = 0; //.85
	maxAlt = 200;
	maxVertical = 10; //200
	maxDamage = 0.001;
	destroyDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 15; // time in seconds until explodes
	accel = 60; //1.0
	groundDamageScale = 20.0;
	repairRate = 0;
	damageSound = shockExplosion;
	ramDamage = 0.5;
	ramDamageType = $ImpactDamageType;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundJetHeavy;
	moveSound = SoundJetHeavy;
	visibleDriver = false;
	driverPose = 22;
	description = "Optical Seeking Missile";
	//projectile = "Undefined";
};

function OSMissile::onAdd(%this)
{	
	GameBase::setRechargeRate (%this,0);
	schedule("OSMissile::exhaustFuel("@%this@");",1,%this);
}

function OSMissile::onCollision(%this,%object)
{	
	//GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function OSMissile::jump(%this,%mom)
{	
	GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function OSMissile::onDestroyed (%this,%mom)
{	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	%this.oprocketowner = %client; //Plasmatic
	if(%player != -1) 
	{
		//Player::setMountObject(%player, -1, 0);
		Client::setControlObject(%client, %player);
		if(%player.lastWeapon != "") 
		{
			Player::useItem(%player,%player.lastWeapon);		 	
			%player.lastWeapon = "";
		}
		%player.driver = "";
		%player.vehicle= "";
	}
	calcRadiusDamage(%this,$MissileDamageType, 35, 0.7, 25, 15, 12, 1.4, 0.9, 320, 220); 
}

function OSMissile::exhaustFuel(%this)
{	%fuel = GameBase::getEnergy(%this);
	if(%fuel < 1) 
		GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	else 
	{
		GameBase::setEnergy(%this,%fuel - 1);
		schedule("OSMissile::exhaustFuel("@%this@");",1,%this);
	}
}

function OSMissile::getHeatFactor(%this) 
{
	return 1.0;
}
