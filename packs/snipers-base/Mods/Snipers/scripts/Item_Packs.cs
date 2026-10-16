//----------------------------------------------------------------------------
//
//	BACK PACKS
//
//----------------------------------------------------------------------------
$RemoteInvList[EnergyPack] = 1;
$RemoteInvList[RepairPack] = 1;
$RemoteInvList[ShieldPack] = 1;
$RemoteInvList[SensorJammerPack] = 1;
$RemoteInvList[AmmoPack] = 1;
$RemoteInvList[RepairKit] = 1;
$RemoteInvList[DeployableSensorJammerPack] = 1;
$RemoteInvList[MotionSensorPack] = 1;
$RemoteInvList[PulseSensorPack] = 1;
$RemoteInvList[CameraPack] = 1;
$RemoteInvList[TurretPack] = 1;

$InvList[TurretPack] = 1;
$InvList[CameraPack] = 1;
$InvList[PulseSensorPack] = 1;
$InvList[MotionSensorPack] = 1;
$InvList[DeployableSensorJammerPack] = 1;
$InvList[DeployableAmmoPack] = 1;
$InvList[DeployableInvPack] = 1;
$InvList[SensorJammerPack] = 1;
$InvList[EnergyPack] = 1;
$InvList[RepairPack] = 1;
$InvList[ShieldPack] = 1;
$InvList[AmmoPack] = 1;
$InvList[RepairKit] = 1;

ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
}

//----------------------------------------------------------------------------

ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
	validateMaterials = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

//----------------------------------------------------------------------------

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
	validateMaterials = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	


//----------------------------------------------------------------------------

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}

//----------------------------------------------------------------------------

$InvList[AmmoPack] = 1;
$RemoteInvList[AmmoPack] = 1;

$AmmoPackMult = 0.5;

ItemImageData AmmoPackImage 
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
};

ItemData AmmoPack 
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";	
	heading = eBackpacks;
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item) 
{
	if ($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
	// When the pack is dropped, subtract all ammo that can't normally be carried
	for(%i = 0; %i < $AmmoCount; %i++) 
	{
	%numPack = 0;
	%ammoItem = $Ammo_Ammo[%i];
	%maxnum = $ItemMax[Player::getArmor(%player), $Ammo_Ammo[%i]];
	%pCount = Player::getItemCount(%player, %ammoItem);
	if(%pCount > %maxnum) 
	{
		%numPack = %pCount - %maxnum;
		Player::decItemCount(%player,%ammoItem,%numPack);
		}

			// Set the amount that is thrown with the pack
			$Item_Ammo[%item, %i] = %numPack;
		}
	}
}

function AmmoPack::onRemove(%this)
{
	// Flush out the settings array (to conserve memory hopefully)
	for (%i = 0; i < $AmmoCount; %i++)
	$Item_Ammo[%this, %i] = "";  
}

function AmmoPack::onCollision(%this,%object) 
{
	if (getObjectType(%object) == "Player") 
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item) 
{
	for(%i = 0; %i < $AmmoCount; %i++) 
	{
		// Make sure the player isn't carrying more than they could normally with the AmmoPack
		// If this code holds true for base, you should be able to have a heavy toss a scout
		// a fully loaded ammo back--not sure though.
		%numAdd = $Item_Ammo[%item, %i];
		%maxnum = floor($ItemMax[Player::getArmor(%player), $Ammo_Ammo[%i]] * (1 + $AmmoPackMult));
		if (%numAdd > %maxnum) 
		%numAdd = %maxnum;
		Player::incItemCount(%player, $Ammo_Ammo[%i], %numAdd);
	}
}

function fillAmmoPack(%client) 
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $AmmoCount; %i++) 
	{
		%item = $Ammo_Ammo[%i];
		%maxnum = floor($ItemMax[Player::getArmor(%client), $Ammo_Ammo[%i]] * $AmmoPackMult);
		//%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum);
		if (%maxnum) 
		{
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}
	}
}

//----------------------------------------------------------------------------

ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "Sensor Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//---------------------------------------------------
//	BOOSTER PACKS
//---------------------------------------------------
ItemImageData MortarPackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData MortarPack
{
	shapeFile = "mortarpack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = MortarPackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
};

function MortarPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function MortarPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function MortarPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}
ItemImageData Booster1PackImage
{ 
	shapeFile = "mortargun";
	mountPoint = 2; 
	mountOffset = { 0.22, -0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	weaponType = 0; 
	projectileType = Booster;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	ammoType = BoosterAmmo;	
	accuFire = true; 
	reloadTime = 0.0; 
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster1Pack 
{ 
	description = "Booster";
	shapeFile = "mortargun";
   	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = Booster1PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
}; 

function Booster1PackImage::onActivate(%player,%imageSlot){}
function Booster1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Booster2PackImage
{ 
	shapeFile = "mortargun"; 
	mountPoint = 2; 
	mountOffset = { -0.25, -0.1, 0.20 };
	mountRotation = { -1.57, -2.99, 0 }; 
	weaponType = 0;
	projectileType = Booster; 
	minEnergy = 0.1;
	maxEnergy = 0.1;
	ammoType = BoosterAmmo;	
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.0; 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData Booster2Pack 
{ 
	description = "Booster";
	shapeFile = "mortargun";
   	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = Booster2PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
};
function Booster2PackImage::onActivate(%player,%imageSlot){}
function Booster2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//---------------------------------------------------
//	RIFLE PACK
//---------------------------------------------------

ItemImageData RiflePackImage
{ 
	shapeFile = "sniper";
	mountPoint = 2; 
	mountOffset = { 0.22, -0.1, 0.20 };
	mountRotation = { -1.57, 2.99, 0 };
	weaponType = 0; 
	//projectileType = Booster;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	//ammoType = BoosterAmmo;	
	accuFire = true; 
	reloadTime = 0.0; 
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData RiflePack
{ 
	description = "Rifle Pack";
	shapeFile = "sniper";
   	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = RiflePackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
}; 

function RiflePackImage::onActivate(%player,%imageSlot){}
function RiflePackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData RiflePack1Image
{ 
	shapeFile = "ammopack";
	mountPoint = 2;
	mountrotation = { 0, 0, -11 };
	mountOffset = { 0.2, -0.03, 0.2 };
	weaponType = 0; 
	//projectileType = Booster;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	//ammoType = BoosterAmmo;	
	accuFire = true; 
	reloadTime = 0.0; 
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 5; 
	lightTime = 2; 
	lightColor = { 1, 1, 0 }; 
}; 

ItemData RiflePack1
{ 
	description = "Rifle Pack";
	shapeFile = "ammopack";
   	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = RiflePack1Image;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
}; 

function RiflePackImage::onActivate(%player,%imageSlot){}
function RiflePackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//---------------------------------------------------
//	SEED PACK
//---------------------------------------------------

$InvList[TreePack] = 1;
$RemoteInvList[TreePack] = 1;

ItemImageData TreePackImage
{
	shapeFile = "jetpack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TreePack
{
	description = "Seed Pack";
	shapeFile = "jetpack";
	className = "Backpack";
	heading = "eBackpacks";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TreePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TreePack::onDeploy(%player,%item,%pos)
{
	if (TreePack::deployShape(%player,%item))
	{
		//Player::decItemCount(%player,%item); //thus infinite trees to plant
	}
}

function TreePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj != "InteriorShape")
			{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player);
						%rand = floor(getRandom() * 6);
						if(%rand == 0) %type = "TreeShapeTwo";
						else if(%rand == 1) %type = "Cactus1"; 
						//else if(%rand == 3) %type = "PlantOne"; 
						else if(%rand == 2) %type = "Cactus2";
						else if(%rand == 3) %type = "Cactus1"; 
						else if(%rand == 4) %type = "Cactus2"; 
						else %type = "Cactus3"; 

						%tree = newObject("A Tree","StaticShape",%type,true);
                 				addToSet("MissionCleanup", %tree);
						GameBase::setTeam(%tree,GameBase::getTeam(%player));
						GameBase::setPosition(%tree,$los::position);
						GameBase::setRotation(%tree,%rot);
						Gamebase::setMapName(%tree,"Tree " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Seed Planted");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
						echo("MSG: ",%client," planted a seed");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %tree); 
						// Client::setOwnedObject(%client, %player);
						return true;
					}
			}
			else 
				Client::sendMessage(%client,0,"Cannot deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description);

	return false;
}

//---------------------------------------------------
//	LASER PACK
//---------------------------------------------------

$InvList[LaserPack] = 1;
$RemoteInvList[LaserPack] = 1;

LaserData OpticLaser 
{
  laserBitmapName = "laserpulse.bmp";
  hitName = "laserhit.dts";
  damageConversion = 0.007;
  baseDamageType = $LaserDamageType;
  beamTime = 0.8;
  lightRange = 2.0;
  lightColor = { 1.0, 0.25, 0.25 } ;
  detachFromShooter = false;
  hitSoundId = SoundLaserHit;
};

ItemImageData LaserPackImage 
{
	shapeFile = "repairgun"; 
	mountPoint = 2; 
	mountOffset = { 0.2, 0.4, 0.45 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	projectileType = OpticLaser; 
	accuFire = true; 
	reloadTime = 6.5; 
	fireTime = 0.0; 
	minEnergy = 10; 
	maxEnergy = 60; 
	lightType = 3; 
	lightRadius = 2; 
	lightTime = 1; 
	lightColor = { 1, 0, 0 }; 
	sfxFire = SoundFireLaser; 
};

ItemData LaserPack
{
	description = "Cybernetic Laser"; 
	shapeFile = "repairgun"; 
	className = "Backpack"; 
	heading = "eBackpacks"; 
	shadowDetailMask = 4; 
	imageType = LaserPackImage; 
	price = 275; 
	hudIcon = "sniper"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
};

function OpticPackImage::onActivate(%player,%imageSlot) 
{ 
	schedule("use(\"backpack\");", 0.5); 
} 

function OpticPackImage::onDeactivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,false); 
}

//---------------------------------------------------
//	LIGHTNING PACK
//---------------------------------------------------

$InvList[LightningPack] = 1;
$RemoteInvList[LightningPack] = 1;

LightningData boltCharge 
{
  bitmapName = "discglow1.bmp";
  damageType = $ElectricityDamageType;
  boltLength = 130.0;
  coneAngle = 65.0;
  damagePerSec = 0.20;
  energyDrainPerSec = 60.0;
  segmentDivisions = 4;
  numSegments = 8;
  beamWidth = 0.125;
  updateTime = 120;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0, 2, 0.123439 };
  soundId = SoundELFFire;
};

ItemImageData LightningPackImage 
{
  shapeFile = "shieldPack";
  mountPoint = 2;
  weaponType = 2;
  projectileType = boltCharge;
  minEnergy = 9;
  maxEnergy = 10;
  reloadTime = 0.2;
  sfxFire = SoundELFIdle;
};

ItemData LightningPack 
{
  description = "Shock Pack";
  shapeFile = "shieldPack";
  className = "Backpack";
  heading = "eBackpacks";
  shadowDetailMask = 4;
  imageType = LightningPackImage;
  price = 275;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};


function LightningPackImage::onActivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Lightning Field On");
}

function LightningPackImage::onDeactivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Lightning Field Off");
}

//---------------------------------------------------
//	ROCKET BOOSTER PACK
//---------------------------------------------------

$InvList[RocketBooster] = 1;
$InvList[BoosterCharge] = 1;
$RemoteInvList[RocketBooster] = 1;
$RemoteInvList[BoosterCharge] = 1;
$SellAmmo[BoosterCharge] = 25;
$WeaponAmmo[RocketBooster] = BoosterCharge;

addAmmo(RocketBooster, BoosterCharge, 2);

GrenadeData Booster 
{ 
	explosionTag = BoosterExp; 
	collideWithOwner = false; 
	ownerGraceMS = 50; 
	collisionRadius = 0.0; 
	mass = 5.0; 
	elasticity = 0.1; 
	damageClass = 1; 
	damageValue = 0.0002; 
	damageType = $BoosterDamageType; 
	explosionRadius = 10; 
	kickBackStrength = 75.0; 
	maxLevelFlightDist = 300; 
	totalTime = 0.1; 
	liveTime = 0.02; 
	projSpecialTime = 0.01; 
	lightRange = 10.0; 
	lightColor = { 1.0, 1.0, 0.0 }; 
	inheritedVelocityScale = 0.5; 
	smokeName = "plastrail.dts"; 
}; 

ItemImageData RocketBoosterImage 
{ 
	shapeFile = "mortargun";
	mountOffset = { 0, 0, 0.20 };
	mountRotation = { -1.57, 2.99, 0 }; 
	mountPoint = 2; 
	weaponType = 1; 
	ammoType = BoosterCharge; 
	firstPerson = false; 
	mass = 2.0; 
}; 

ItemData RocketBooster
{ 
	description = "Rocket Booster"; 
	shapeFile = "mortarpack"; 
	className = "Backpack"; 
	heading = "eBackpacks"; 
	shadowDetailMask = 4; 
	imageType = RocketBoosterImage; 
	price = 500; 
	hudIcon = "energypack"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function RocketBooster::onUnmount(%player,%item) 
{ 
	%wpn = Player::getMountedItem(%player,$WeaponSlot); 
	if ((%wpn == MedThruster) || (%wpn == HvyThruster)) 
{ 

Player::unmountItem(%player,$WeaponSlot); 
} 
} 

function RocketBooster::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	Player::mountItem(%player,%item,$BackpackSlot); 
	else 
	{ 
		%armor = Player::getArmor(%player); 
		if(%armor == harmor) 
		Player::mountItem(%player,HvyThruster,$WeaponSlot); 
		else Player::mountItem(%player,MedThruster,$WeaponSlot); 
	} 
} 

function RocketBooster::onDrop(%player,%item) 
{ 
	if($matchStarted) 
	{ 
		if(!Player::isDead(%player)) 
		{ 
			%mounted = Player::getMountedItem(%player,$WeaponSlot); 
			if ((%mounted == HvyThruster) || (%mounted == MedThruster)) 
			Player::unmountItem(%player,$WeaponSlot); 
			else Player::mountItem(%player,%mounted,$WeaponSlot); 
			%item = Item::onDrop(%player,%item); 
			%item.BoosterCharge = 0; 
			} 
			else 
			{ 
			%item = Item::onDrop(%player,%item); 
			%pCount = Player::getItemCount(%player, "BoosterCharge"); 
			Player::decItemCount(%player,"BoosterCharge",%pCount); %item.BoosterCharge = %pCount; 
		} 
	} 
} 

function fillRocketBooster(%client) 
{ 
	%player = Client::getOwnedObject(%client); 
	%item = "BoosterCharge"; 
	%maxnum = checkResources(%player,%item,$RocketBoosterMax[Player::getArmor(%client), %item]); 
	if(%maxnum) 
	{ 
		Player::incItemCount(%client,%item,%maxnum); 
		teamEnergyBuySell(%player,%item.price * %maxnum * -1); 
	} 
} 

function RocketBooster::onCollision(%this,%object) 
{ 
	if (getObjectType(%object) == "Player") 
	{ 
		%item = Item::getItemData(%this); %count = Player::getItemCount(%object,%item); 
		if (Item::giveItem(%object,%item,Item::getCount(%this))) 
		{ 
			Item::playPickupSound(%this); 
			Player::incItemCount(%object,"BoosterCharge",%this.BoosterCharge); 
			Item::respawn(%this); 
		} 
	} 
} 

ItemData BoosterCharge 
{ 
	description = "Rocket Fuel"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "zAmmunition"; 
	shadowDetailMask = 4; 
	price = 5; 
}; 

ItemImageData HvyThrusterImage 
{ 
	shapeFile = "rsmoke"; 
	mountPoint = 0; 
	mountOffset = { -0.715, -0.5, 0.2 }; 
	mountRotation = { -2.0944, 0, 0}; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.0; 
	spinDownTime = 0.0; 
	fireTime = 0.1; 
	ammoType = BoosterCharge; 
	projectileType = Booster; 
	accuFire = false; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 1, 1, 0 }; 
	sfxFire = SoundFlyerActive; 
	sfxActivate = SoundPickUpWeapon; 
}; 

ItemData HvyThruster
{ 
	description = "Heavy Thruster"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	shadowDetailMask = 4; 
	imageType = HvyThrusterImage; 
	price = 50; 
	showInventory = false; 
}; 

function HvyThruster::onMount(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,true); 
} 

function HvyThruster::onUnmount(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,false); 
} 

ItemImageData MedThrusterImage 
{ 
	shapeFile = "rsmoke"; 
	mountPoint = 0; 
	mountOffset = { -0.524, -0.5, 0.2 }; 
	mountRotation = { -2.0944, 0, 0}; 
	weaponType = 1; reloadTime = 0; 
	spinUpTime = 0.0; 
	spinDownTime = 0.0; 
	fireTime = 0.1; 
	ammoType = BoosterCharge; 
	projectileType = Booster; 
	accuFire = false; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 1, 1, 0 }; 
	sfxFire = SoundFlyerActive; 
	sfxActivate = SoundPickUpWeapon; 
}; 

ItemData MedThruster 
{ 
	description = "Medium Thruster"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	shadowDetailMask = 4; 
	imageType = MedThrusterImage; 
	price = 50; 
	showInventory = false; 
}; 

function MedThruster::onMount(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,true); 
} 

function MedThruster::onUnmount(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,false); 
} 

//---------------------------------------------------
//	ANTI-GRAV PACK
//---------------------------------------------------

$InvList[AntiGravPack] = 1;
$RemoteInvList[AntiGravPack] = 1;
$WeaponAmmo[AntiGravPack] = "";

ItemImageData AntiGravPackImage 
{
	shapeFile = "sensor_small";
	mountRotation = { 11, 0, 0 };
	mountOffset = { 0, -0.10, 0.05 };
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData AntiGravPack 
{
	description = "Anti-Grav Pack";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = AntiGravPackImage;
	price = 650;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AntiGravPack::onMount(%player,%item) 
{
}

function AntiGravPackImage::onActivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),1,"Anti-Gravity Pack On.");
	%clientId = Player::getClient(%player);
	$antigrav[%clientId] = 1;
	Snipers_AntiGrav(%clientId, %player);
}

function AntiGravPackImage::onDeactivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),1,"Anti-Gravity Pack Off.");
	Player::trigger(%player,$BackpackSlot,false);
	%clientId = Player::getClient(%player);
	$antigrav[%clientId] = 0;
}

//---------------------------------------------------
//	FLAG DECOY PACK
//---------------------------------------------------

$InvList[FakeFlag] = 1;
$RemoteInvList[FakeFlag] = 1;
$WeaponAmmo[FakeFlag] = "";

ItemImageData FakeFlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData FakeFlag
{
        description = "Flag Decoy Pack";
	shapeFile = "flag";
        imageType = FakeFlagImage;
	className = "Backpack";
        heading = "eBackpacks";
        showInventory = true;
	shadowDetailMask = 4;
        price = 75;

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

function FakeFlag::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//---------------------------------------------------
//	COMM LISTENER PACK
//---------------------------------------------------

$InvList[CommPack] = 1;
$RemoteInvList[CommPack] = 1;
$WeaponAmmo[CommPack] = "";

ItemImageData CommPackImage 
{ 
	shapeFile = "shieldPack"; 
	weaponType = 2; 
	minEnergy = -1; 
	maxEnergy = 2; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, 0 }; 
	firstPerson = false; 
}; 

ItemData CommPack 
{ 
	description = "Comm. Listener Pack"; 
	shapeFile = "shieldPack"; 
	className = "Backpack"; 
	heading = "eBackpacks"; 
	shadowDetailMask = 4; 
	imageType = CommPackImage; 
	price = 175; 
	hudIcon = "shieldpack"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function CommPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{ 
		Player::mountItem(%player,%item,$BackpackSlot); 
	} 
} 

function CommPack::onMount(%player,%item) 
{ 
	Player::trigger(%player,$BackpackSlot,true); 
}

//---------------------------------------------------
//	KAMIKAZE PACK
//---------------------------------------------------

$InvList[KamikazePack] = 1;
$RemoteInvList[KamikazePack] = 1;

//RSP Globals
$KamikazeIsActive[0] = "false";
// End

//-------------------------------------
// Kamikaze Pack - RSP - HR
//-------------------------------------
ItemImageData KamikazePackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;
	sfxFire = SoundJammerOn;
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
	weaponType = 2;  // Sustained
    	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
	lightType = 2;   // Pulsing
	lightRadius = 6;
	lightTime = 1.5;
	lightColor = { 0.75, 0.15, 0.15 };
};

ItemData KamikazePack
{
	description = "Kamikaze Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
  	heading = eBackpacks;
	shadowDetailMask = 4;
	imageType = KamikazePackImage;
	price = 300;
	hudIcon = "grenade";
	showWeaponBar = true;
	hiliteOnActive = true;
	lightType = 2;   // Pulsing
	lightRadius = 8;
	lightTime = 1.5;
	lightColor = { 0.75, 0.15, 0.15 };
};

function KamikazePackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"Kamikaze Pack Initialized. 30 seconds till detonation!");
	$KamikazeIsActive[%player] = "true";
	KamikazePackCount(30, %player);
}

function KamikazePackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
	$KamikazeIsActive[%player] = "false";
}

function KamikazePack::onDrop(%player,%item)
{
	if($matchStarted) {
		if($KamikazeIsActive[%player]) {
			$KamikazeIsActive[%player] = "false";
		
			Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack dropped. Countdown terminated!");
		}

		Item::onDrop(%player,%item);
	}
}

function KamikazePackCount(%count, %player)
{
	if(!$matchStarted) return;

	%mounted = Player::getMountedItem(%player,$BackpackSlot);
	if (%mounted != KamikazePack){
		Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack not located. Countdown terminated!");
		$KamikazeIsActive[%player] = false;
		return;
	}
		
	if(%count && $KamikazeIsActive[%player]) {
		if(%count == 15)
			Client::sendMessage(Player::getClient(%player),1,"15");
		if(%count == 5)
			Client::sendMessage(Player::getClient(%player),1,"5");
		if(%count == 4)
			Client::sendMessage(Player::getClient(%player),1,"4");
		if(%count == 3)
			Client::sendMessage(Player::getClient(%player),1,"3");
		if(%count == 2)
			Client::sendMessage(Player::getClient(%player),1,"2");
		if(%count == 1)
			Client::sendMessage(Player::getClient(%player),1,"1");

		%count -= 1;
		schedule("KamikazePackCount('" @ %count @ "','" @ %player @ "');", 1);
	}
	else if($KamikazeIsActive[%player])
	{
		if($KamikazeIsActive[%player]) {
			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,1,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,-1,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,5,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,-5,false);
		}
		$KamikazeIsActive[%player] = "false";
	}
	else
	{
		Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack deactivated. Countdown terminated!");
	}
}

//---------------------------------------------------
//	SUICIDE PACK
//---------------------------------------------------

$InvList[SuicidePack] = 1;
$RemoteInvList[SuicidePack] = 1;

ItemImageData SuicidePackImage 
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SuicidePack 
{
	description = "DetPack";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = eBackpacks;
	imageType = SuicidePackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SuicidePack::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
		}
		else 
		{
		Player::deployItem(%player,%item);
	}
}

function SuicidePack::onUnmount(%player,%item) 
{
}

function SuicidePack::onDeploy(%player,%item,%pos) 
{
	if (SuicidePack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function SuicidePack::deployShape(%player,%item) 
{
	Player::unmountItem(%player,$BackpackSlot);
	%obj = newObject("","Mine","Suicidebomb2");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
	Client::sendMessage(%client,1,"Det Pack will destruct in 5 seconds");
}

//---------------------------------------------------
//	COMMAND LAPTOP PACK
//---------------------------------------------------

$InvList[Laptop] = 1;
$RemoteInvList[Laptop] = 1;

ItemImageData LaptopImage 
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	weaponType = 2;
	minEnergy = -1;
	maxEnergy = -3;
	mass = 0.5;
	firstPerson = false;
};

ItemData Laptop 
{
	description = "Laptop";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = eBackpacks;
	shadowDetailMask = 4;
	imageType = LaptopImage;
	price = 650;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Laptop::IsAvailable(%player)
{
	return (Player::getMountedItem(%player, $BackpackSlot) == Laptop);
}

function Laptop::Error(%client, %msg)
{
	Client::sendMessage(%client, 0, "Laptop Err: " @ %msg @ "~waccess_denied.wav");
}

function Laptop::Output(%client, %msg)
{
	Client::sendMessage(%client, 0, "Laptop: " @ %msg);
}

function Laptop::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	Player::mountItem(%player,%item,$BackpackSlot);
}

function Laptop::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	Bottomprint(%client, "The Laptop will allow you to control turrets without being at a command station... among other things.");
}

function Laptop::onUnmount(%player,%item)
{
}
