$DamageScale[NLAPC, $PlasmaCannonDamageType] = 1.0;
$DamageScale[NLAPC, $ElectricityDamageType] = 1.0;
$DamageScale[NLAPC, $LiLPOOmkiiDamageType] = 1.0;
$DamageScale[NLAPC, $BeamOfPainDamageType] = 1.0;
$DamageScale[NLAPC, $ExplosionDamageType] = 1.0;
$DamageScale[NLAPC, $LiLRocketDamageType] = 1.0;
$DamageScale[NLAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[NLAPC, $MissileDamageType] = 1.0;
$DamageScale[NLAPC, $BlasterDamageType] = 0.5;
$DamageScale[NLAPC, $MiniELFDamageType] = 1.0;
$DamageScale[NLAPC, $ImpactDamageType] = 1.0;
$DamageScale[NLAPC, $BulletDamageType] = 1.0;
$DamageScale[NLAPC, $PlasmaDamageType] = 1.0;
$DamageScale[NLAPC, $EnergyDamageType] = 1.0;
$DamageScale[NLAPC, $DebrisDamageType] = 1.0;
$DamageScale[NLAPC, $MortarDamageType] = 1.0;
$DamageScale[NLAPC, $SmokeDamageType] = 1.0;
$DamageScale[NLAPC, $FlashDamageType] = 1.0;
$DamageScale[NLAPC, $LaserDamageType] = 0.5;
$DamageScale[NLAPC, $MineDamageType] = 1.0;
$DamageScale[NLAPC, $EMPDamageType] = 1.0;

FlierData NLAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	shieldShapeName = "shield_large";
	mass = 10.0;
	drag = 1.0;
	density = 1.2;
	maxBank = 1;
	maxPitch = 1;
	maxSpeed = 100;
	minSpeed = -100;
	lift = 10;
	maxAlt = 500;
	maxVertical = 20;
	maxDamage = 5;
	damageLevel = { 1.0, 1.0 };
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 2;
	groundDamageScale = 1.50; 
    projectileType = fireball;
	reloadDelay = 0.25;
	fireSound = SoundDryFire;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = false;
	driverPose = 23;
	description = "FlyerPack";
};


ItemImageData FlyerPackImage
{
	shapeFile = "ammopack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 4;
 	maxEnergy = 4.5;
	firstPerson = false;
};

ItemData FlyerPack
{
	description = "Flyer";
	shapeFile = "ammopack";
	className = "Backpack";
	heading   = $InvHeading[oddnend];
	shadowDetailMask = 4;
	imageType = FlyerPackImage;
	mass = 0.5;
	price = 400;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlyerPack::onUse(%player,%item)
{ if(Player::getMountedItem(%player, $BackpackSlot) != %item){ Player::mountItem(%player, %item, $BackpackSlot); }else{ Player::deployItem(%player, %item); } }

function FlyerPack::onDeploy(%player,%item,%pos)
{ if(DeployFlyerPack(%player, %item, NLAPC, Flier, NLAPC)){ if(!Player::isDead(%player)){ Player::decItemCount(%player,%item); } } }

function DeployFlyerPack(%player, %item, %shape, %data, %name){
	%client = Player::getClient(%player);
	%cName  = Client::getName(%client);
	
	if(%client.droid){
		Client::sendMessage(%client, 0, "You greedy bastard, one is enough.");
		Player::decItemCount(%player, %item);
		BuyItem(%player, RepairPack);
		return false;
	}
	if($TeamItemCount[GameBase::getTeam(%player) @ "FlyerPack"] >= $TeamItemMax["FlyerPack"]){
		Client::sendMessage(%client, 0, "Maximum number of Flyers deployed");
		Player::decItemCount(%player, %item);
		BuyItem(%player, RepairPack);
		return false;
	}
	
	if(GameBase::getLOSInfo(%player, 10)){
		// Just make sure this stays the same as the word below in the ::onDestroyed 
		// function
		%client.DroidType = "FlyerPack";
		%client.droid = true;
		%client.guiLock = true;
		%droid = $DroidType;
		%armor = Player::getArmor(%player);
		%pos = $los::position;
		%rot = GameBase::getRotation(%player);
		%obj = newObject(NLAPC, Flier, NLAPC, true);
		%client.newplayer = %obj;
		%client.oldPlayer = %player;
		
		addToSet("MissionCleanup", %obj);
		GameBase::setTeam(%obj, GameBase::getTeam(%player));
		GameBase::setPosition(%client.newplayer, %pos);
		GameBase::setRotation(%client.newplayer, %rot);
		
		GameBase::setDamageLevel(%obj, 0.99);
		GameBase::repairDamage(%obj, 0.99);
		%energy = GameBase::getEnergy(%obj);
		%energy = %energy - 400;
		if (%energy < 0)  %energy = 0;
		GameBase::setEnergy(%obj, %energy);
		GameBase::setRechargeRate(%obj, 42);
		
		Client::setControlObject(%client, Client::getObserverCamera(%client));
		Observer::setOrbitObject(%client, %client.newPlayer, 3, 3, 3);
		Client::sendMessage(%client, 0, "~wSensor_Deploy.wav");
		// Phase2 - Set new player to control
		Client::setControlObject(%client, %client.newplayer);
		Client::setOwnedObject(%client, %client.newplayer);
		
		Client::sendMessage(%client, 0, %item.description @" deployed");
		$TeamItemCount[GameBase::getTeam(%player) @"FlyerPack"]++;
		playSound(SoundPickupBackpack,$los::position);
		return true;
	}else{
		Client::sendMessage(%client, 0, "No, to far away... deploy closer.");
		return false;
	}
}

function FlyerPack::onDestroyed(%this){
	%client = GameBase::getControlClient(%this);
	
	// Re-Set Client To His Original Body.
	Client::setControlObject(%client, %client.oldPlayer);
	Client::setOwnedObject(%client, %client.oldPlayer);
	
	%client.droid = false;
	%client.DroidType = "";
	%client.guiLock = false;
	%client.oldPlayer.shieldStrength = 0;
	GameBase::setDamageLevel(%this, 10);
	Schedule("deleteObject("@ %this @");", 5);
	$TeamItemCount[GameBase::getTeam(%this) @"FlyerPack"]--;
	Client::sendMessage(%client, 0, "Connection To Your Flyer Has Been Lost~wusepack.wav");
	XBottomPrint(%client, "<jc><f1>Connection To Your Flyer Has Been Lost", 5);
}