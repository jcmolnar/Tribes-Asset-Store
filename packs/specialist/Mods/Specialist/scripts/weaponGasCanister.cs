$InvList[GasCanister] = 1;
$RemoteInvList[GasCanister] = 1;
$AutoUse[GasCanister] = 1;

$WeaponAmmo[GasCanister] = GasCanisterAmmo;
$SellAmmo[GasCanisterAmmo] = 5;
$InvList[GasCanisterAmmo] = 1;
$RemoteInvList[GasCanisterAmmo] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, GasCanister] = 0;
$ItemMax[reconfemalearmor, GasCanister] = 0;
$ItemMax[espionagearmor, GasCanister] = 0;
$ItemMax[espionagefemalearmor, GasCanister] = 0;
$ItemMax[engineerarmor, GasCanister] = 0;
$ItemMax[engineerfemalearmor, GasCanister] = 0;
$ItemMax[infantryarmor, GasCanister] = 0;
$ItemMax[infantryfemalearmor, GasCanister] = 0;
$ItemMax[falloutarmor, GasCanister] = 1;
$ItemMax[falloutfemalearmor, GasCanister] = 1;
$ItemMax[demolitionsarmor, GasCanister] = 0;
$ItemMax[assaultarmor, GasCanister] = 0;
$ItemMax[artilleryarmor, GasCanister] = 0;
$ItemMax[commanderarmor, GasCanister] = 0;

// Who can use this ammo (and how much they can carry)
$ItemMax[reconarmor, GasCanisterAmmo] = 0;
$ItemMax[reconfemalearmor, GasCanisterAmmo] = 0;
$ItemMax[espionagearmor, GasCanisterAmmo] = 0;
$ItemMax[espionagefemalearmor, GasCanisterAmmo] = 0;
$ItemMax[engineerarmor, GasCanisterAmmo] = 0;
$ItemMax[engineerfemalearmor, GasCanisterAmmo] = 0;
$ItemMax[infantryarmor, GasCanisterAmmo] = 0;
$ItemMax[infantryfemalearmor, GasCanisterAmmo] = 0;
$ItemMax[falloutarmor, GasCanisterAmmo] = 10;
$ItemMax[falloutfemalearmor, GasCanisterAmmo] = 10;
$ItemMax[demolitionsarmor, GasCanisterAmmo] = 0;
$ItemMax[assaultarmor, GasCanisterAmmo] = 0;
$ItemMax[artilleryarmor, GasCanisterAmmo] = 0;
$ItemMax[commanderarmor, GasCanisterAmmo] = 0;

// ================ Poison Gas Canister extras ===============
ExplosionData noDebrisExp
{
	shapeName = "mortartrail.dts";
	// soundId   = debrisSmallExplosion;
   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 2.5;
   timeZero = 0.250;
   timeOne  = 0.650;
   colors[0]  = { 0.0, 0.0, 0.0  };
   colors[1]  = { 1.0, 0.5, 0.16 };
   colors[2]  = { 1.0, 0.5, 0.16 };
   radFactors = { 0.0, 1.0, 1.0 };
};

DebrisData noDebris
{
   type      = 0;
   imageType = 0;
   mass       = 0.0;
   elasticity = 0.0;
   friction   = 1.0;
   center     = { 0, 0, 0 };
   //collisionMask = 0;    // default is Interior | Terrain, which is what we want
   //knockMask     = 0;
   animationSequence = -1;
   minTimeout = 3.0;
   maxTimeout = 6.0;
   explodeOnBounce = 0.0;
   damage          = 0.0;
   damageThreshold = 0.0;
   spawnedDebrisMask     = 1;
   spawnedDebrisStrength = 0;
   spawnedDebrisRadius   = 0.0;
   spawnedExplosionID = noDebrisExp;
   p = 1;
   explodeOnRest   = False;
   collisionDetail = 0;
};

// =================== Poison Gas Canister object that remains active ==============
MineData GasCanisterMine
{
	className = "Mine";
   	description = "Gas Canister";
   	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = noDebrisExp;
	explosionRadius = 10.0;
	damageValue = 0.001;
	damageType = $PoisonGasDamageType;
	kickBackStrength = 0;
	triggerRadius = 10.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function GasCanisterMineRespawn(%index) {

	// Create a Gas Canister Mine
	%canister = newObject("", "Mine", "GasCanisterMine");
	addToSet("MissionCleanup", %canister);

	// Set it's position
	GameBase::setPosition(%canister, $PoisonGasCloudPosition[%index]);

	Gamebase::setMapName(%canister, "Poison Gas Canister");

	// Set this mine's gas cloud data
	$PoisonGasCloudIndex[%canister] = %index;
	$PoisonGasCloudObject[%index] = %canister;

	// Let's set it to a different team so gas will hurt everyone
	GameBase::setTeam(%canister, GameBase::getTeam($PoisonGasCloudOwner[%index]));
	// GameBase::setTeam(%canister, -1);

}

function GasCanisterMine::onAdd(%this)
{
	%this.damage = 0;

 	GameBase::setActive(%this,true);
	%set = newObject("set",SimSet);
	if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
		%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	deleteObject(%set);
}

function GasCanisterMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function GasCanisterMine::deployCheck(%this)
{
}	

function GasCanisterMine::onDestroyed(%this)
{
	// Get this mine's gas cloud index
	%index = $PoisonGasCloudIndex[%this];

	// Reset this gas cloud's index and object data
	$PoisonGasCloudIndex[%this] = -1;
	$PoisonGasCloudObject[%index] = -1;

	// If TTG remains
	if ($PoisonGasCloudTTG[%index] > 0) {

		// Schedule a respawn of this mine so the gas cloud will persist
		schedule("GasCanisterMineRespawn(" @ %index @ ");", 0.1);

		// ****** Safety ****** to make sure that updates are still called
		if ($PoisonGasCloudUpdateScheduled == false) {

			$PoisonGasCloudUpdateScheduled = true;
			schedule("PoisonGasCloud::updateAll(true);", 1.0);
		}
	}
	else {
		// Decrement total number of gas clouds
		// $PoisonGasCloudTotal --;
		// echo("Gas Cloud deleted for total of: " @$PoisonGasCloudTotal);
	}

}

function GasCanisterMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	// Poison Gas will not destroy this canister
	if (%type == $PoisonGasDamageType)
		%value = 0;

	if (%type == $MineDamageType)
		%value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}



// ======================= Explosion data ======================

ExplosionData gasCanisterExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 0.0;

   timeScale = 10.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 1.0, 0.0 };
   colors[1]  = { 0.0, 1.0, 0.0 };
   colors[2]  = { 0.0, 1.0, 0.0 };
   radFactors = { 0.0, 1.0, 0.0 };
};

// ================ Ammo data =================

ItemData GasCanisterAmmo
{
	description = "Gas Canisters";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 25;
};

// ===================== Thrown canister data ==================

MineData GasCanisterGrenade { 
 	mass = 1.0;
 	drag = 1.0;
 	density = 2.0;
 	elasticity = 0.25;
 	friction = 0.3;
 	className = "Handgrenade";
 	description = "Handgrenade";
 	shapeFile = "grenade";
 	shadowDetailMask = 4;
 	explosionId = GasCanisterExp;
 	explosionRadius = 10.5;
 	damageValue = 0.01;
 	damageType = $PoisonGasDamageType;
 	kickBackStrength = 0;
 	triggerRadius = 1.0;
 	maxDamage = 0.01;
};

function GasCanisterGrenade::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");", 3.0, %this);
}

function GasCanisterGrenade::onDestroyed(%this) { 

	%radius = 10.5;
	%type = $PoisonGasDamageType;
	// %dur = 5.0;

	// Create a Gas Canister Mine
	%canister = newObject("", "Mine", "GasCanisterMine");
	addToSet("MissionCleanup", %canister);
	GameBase::setPosition(%canister, GameBase::getPosition(%this));

	// Let's set it to a different team so gas will hurt everyone
	GameBase::setTeam(%canister, GameBase::getTeam(%this));
	// GameBase::setTeam(%canister, 7);

	Gamebase::setMapName(%canister, "Poison Gas Canister");

	// Get gas cloud index
	%index = $PoisonGasCloudIndex[%this];

	// Set new gas cloud data
	$PoisonGasCloudPosition[%index] = GameBase::getPosition(%this);
	// $PoisonGasCloudTTG[%index] = %dur;
	// echo("Set TTG at index " @%index@ " to: " @$PoisonGasCloudTTG[%index]);
	$PoisonGasCloudObject[%index] = %canister;
	$PoisonGasCloudIndex[%canister] = %index;

	// Increment total gas clouds
	$PoisonGasCloudTotal ++;


	// If this is our first gas cloud
	if ($PoisonGasCloudTotal == 1) {

		// Make the clock start ticking
		schedule("PoisonGasCloud::updateAll(false);", 1.0);
	}
}



// =================== Gas Canister Launcher data =================
ItemImageData GasCanisterImage
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };

	shapeFile  = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GasCanisterAmmo;
	// projectileType = GasCanisterGrenade;
	reloadTime = 1.0;
	fireTime = 0.5;

	accuFire = false;

	lightType = 3; // Weapon Fire
	lightRadius = 2;
	lightTime = 2;
	lightColor = { 0.0, 1.0, 0.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function GasCanisterImage::onFire(%this, %slot) {

	// Get some valuable info
	%client = Player::getClient(%this);

	// Get the next available poison gas cloud index
	%next = PoisonGasCloud::getNextIndex();

	// If maximum number of gas clouds is not exceeded
	if (%next != -1) {

		// We subtract one ammo
		Player::decItemCount(%this, GasCanisterAmmo, 1);

		// Create the grenade
		%obj = newObject("","Mine","GasCanisterGrenade");
		addToSet("MissionCleanup", %obj);

		// Set the poison gas cloud data
		$PoisonGasCloudOwner[%next] = %this;
		$PoisonGasCloudIndex[%obj] = %next;
		$PoisonGasCloudObject[%next] = %obj;
		$PoisonGasCloudTTG[%next] = 5.0;

		// Shoot the grenade forward
		SpecialistSpawnProjectile(%this, %obj, 30);

		// Assign the grenade to a team
		GameBase::setTeam(%obj, GameBase::getTeam(%client));
	}
	else {

		// We tell the user that there are too many gas clouds
		Client::sendMessage(%client, 0, "Limit reached for gas clouds");
	}
}

// =================== Item data for Gas Canister Launcher ================
ItemData GasCanister
{
	heading = "bWeapons";
	description = "Gas Delivery Device";
	className = "Weapon";
	shapeFile  = "grenadeL";
	hudIcon = "mortar";
	shadowDetailMask = 4;
	imageType = GasCanisterImage;
	price = 150;
	showWeaponBar = true;
};

function GasCanister::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "Fires canisters of poisonous gas which linger for a few seconds.");
	}
}
