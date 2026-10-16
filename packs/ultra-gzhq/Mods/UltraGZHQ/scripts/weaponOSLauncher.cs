$InvList[OSLauncher] = 1;
$MobileInvList[OSLauncher] = 1;
$RemoteInvList[OSLauncher] = 1;

$InvList[OSAmmo] = 1;
$MobileInvList[OSAmmo] = 1;
$RemoteInvList[OSAmmo] = 1;

$AutoUse[OSLauncher] = false;
$SellAmmo[OSAmmo] = 3;
$WeaponAmmo[OSLauncher] = OSAmmo;

addWeapon(OSLauncher);
addAmmo(OSLauncher, OSAmmo, 1);

ItemData OSAmmo 
{
	description = "OS Rockets";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData OSLauncherImage
{
	shapeFile = "grenadel";
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
{
	description = "OS Laucher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "fear";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = OSLauncherImage;
	price = 5000;
	showWeaponBar = true;
};

function OSLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Optical Seeking Missile Launcher: <f2>When you fire it, be sure to control it immediately.\n<f1>*WARNING*<f2> Do not fire while in the air or inside a small or enclosed area.\n<F3>Bomblets: <F2>Enabled\n<F1>Press Your Fire Button To Drop Bomblets.");
}///
function OSLauncherImage::onFire(%this,%slot)
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %this @" cl# "@ Player::getclient(%this));	
	
//	Vehicle::TerrainCheck(%this);
//	schedule("FireOS("@%this@");",0.1);

	if(!%this.vehicle)
	{	
	%client = Player::getClient(%this);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	%trans = GameBase::getMuzzleTransform(%client);
	%vel = Item::getVelocity(%client);		
		
		%rot = GameBase::getRotation(%client);
		%posX = getWord(%trans,9);
		%posY = getWord(%trans,10);
		%posZ = getWord(%trans,11) + 1.5; // +3.0
		%position = %posX@" "@%posY@" "@%posZ;
		%obj = newObject("Optical Seeking Missile",flier,OSMissile,true);
		%obj.cloakable = true;
		addToSet("MissionCleanup",%obj);
		Gamebase::setMapName(%obj,"Optical Seeking Missile");
		GameBase::setTeam(%obj,GameBase::getTeam(%this));
		GameBase::setPosition(%obj,%position);
		GameBase::setRotation(%obj,%rot);
		GameBase::startFadeIn(%obj);
		Vehicle::TerrainCheck(%obj);
		%obj.OpOwner = %this; 	//plasmatic
		%player = Client::getOwnedObject(%client);
	 	//Client::setOwnedObject(%client, %vehicle);
		
		Client::setOwnedObject(%client, %obj);
		Client::setOwnedObject(%client, %player);
				
		Client::setControlObject(%client,%obj);
		
		%this.vehicle = %obj;
		%this.lastWeapon = %weapon;
		Player::unMountItem(%this,$WeaponSlot);
	}

	Player::decItemCount(%client,$WeaponAmmo[OSLauncher],1);	
	


}

function FireOS(%this)
{
	%client = Player::getClient(%this);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	%trans = GameBase::getMuzzleTransform(%client);
	%vel = Item::getVelocity(%client);
	
	%pPos	= GameBase::getPosition(%this);
	%tPos	= GameBase::getPosition(%this.terCheck);
	deleteobject(%this.terCheck);
	%AboveTerrain = (getWord(%pPos,2)+10 - getWord(%tPos,2)) >0;
	
	
	if(!%this.vehicle && %AboveTerrain)
	{	
		%rot = GameBase::getRotation(%client);
		%posX = getWord(%trans,9);
		%posY = getWord(%trans,10);
		%posZ = getWord(%trans,11) + 1.5; // +3.0
		%position = %posX@" "@%posY@" "@%posZ;
		%obj = newObject("Optical Seeking Missile",flier,OSMissile,true);
		%obj.cloakable = true;
		addToSet("MissionCleanup",%obj);
		Gamebase::setMapName(%obj,"Optical Seeking Missile");
		GameBase::setTeam(%obj,GameBase::getTeam(%this));
		GameBase::setPosition(%obj,%position);
		GameBase::setRotation(%obj,%rot);
		GameBase::startFadeIn(%obj);
		%obj.OpOwner = %this; 	//plasmatic
		%player = Client::getOwnedObject(%client);
	 	//Client::setOwnedObject(%client, %vehicle);
		
		Client::setOwnedObject(%client, %obj);
		Client::setOwnedObject(%client, %player);
				
		Client::setControlObject(%client,%obj);
		
		%this.vehicle = %obj;
		%this.lastWeapon = %weapon;
		Player::unMountItem(%this,$WeaponSlot);
	}
	else {
		//bottomprint(%client, "<f1><jc>Firing Unprogrammed missle.", 20);
		Projectile::spawnProjectile("SuperRocket",%trans,%this,%vel);		
		
	}
	Player::decItemCount(%client,$WeaponAmmo[OSLauncher],1);	
	
	
	
}


FlierData OSMissile
{
//	explosionId = Rocketexp;	//rocketExp;
//	debrisId = flashDebrisLarge;	//plasmatic
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
	maxAlt = 20000;
	maxVertical = 10; //200
	maxDamage = 0.001;
	destroyDamage = 0.001;
	damageLevel = {0.001, 0.001};
	maxEnergy = 15; // time in seconds until explodes
	accel = 60; //1.0
	groundDamageScale = 20.0;
	repairRate = 0;
	projectileType = OSBomblet;
	reloadDelay = 1.5;
	damageSound = shockExplosion;
	ramDamage = 0.5;
	ramDamageType = $ImpactDamageType;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	fireSound = SoundFireMortar;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundJetHeavy;
	moveSound = SoundJetHeavy;
	visibleDriver = false;
	driverPose = 22;
	description = "Optical Seeking Missile";

};

function OSMissile::onAdd(%this)
{	
	GameBase::setRechargeRate (%this,0);
	schedule("OSMissile::exhaustFuel("@%this@");",1,%this);
}

//plasmatic
function KillRocket (%this)
{
	%Pos = GameBase::getPosition(%this); 
   	%vel = Item::getVelocity(%this);

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%this);
 	if(!player::isdead(%this.OpOwner))
 	{
 		%obj = Projectile::spawnProjectile("RocketKilla", %trans, %this.OpOwner, %vel);
 		GameBase::setPosition(%obj, %pos);
 	}
	else 	return;
}

function OSMissile::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	KillRocket(%this);	//plasmatic
	//GameBase::applyDamage(%this,$MissileDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function OSMissile::jump(%this,%mom)
{	
	KillRocket (%this);	//plasmatic
	//GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function OSMissile::onDestroyed (%this,%mom)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	%this.cloakable = "";
	%this.nuetron = "";
	KillRocket(%this);
	%this.oprocketowner = %client; //Plasmatic
	if(%player != -1) 
	{
		Client::setControlObject(%client, %player);
		if(%player.lastWeapon != "") 
		{
			Player::useItem(%player,%player.lastWeapon);		 	
			%player.lastWeapon = "";
		}
		%player.driver = "";
		%player.vehicle= "";
	}
}

function OSMissile::exhaustFuel(%this)
{
	%fuel = GameBase::getEnergy(%this);
	if(%fuel < 1) 
		KillRocket (%this); 	//plasmatic
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
