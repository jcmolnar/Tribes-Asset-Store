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
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
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

//===========================

$InvList[Accelerator] = 1;
$RemoteInvList[Accelerator] = 1;

$ItemMax[harmor, Accelerator] = 1;
$ItemMax[marmor, Accelerator] = 1;
$ItemMax[mfemale, Accelerator] = 1;
$ItemMax[larmor, Accelerator] = 1;
$ItemMax[lfemale, Accelerator] = 1;
$ItemMax[MagIonM, Accelerator] = 1;
$ItemMax[MagIonF, Accelerator] = 1;
$ItemMax[MECH, Accelerator] = 1;
$ItemMax[sarmor, Accelerator] = 1;
$ItemMax[sfemale, Accelerator] = 1;
$ItemMax[ebarmor, Accelerator] = 1;
$ItemMax[ebfemale, Accelerator] = 1;
$ItemMax[mearmor, Accelerator] = 1;

ItemImageData AcceleratorImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -9;
	firstPerson = false;
};

ItemData Accelerator
{
	description = "Accelerator";
	shapeFile = "mortarpack";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = AcceleratorImage;
	price = 450;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Accelerator::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function Accelerator::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Accelerator::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == PBW) 
		Player::unmountItem(%player,$WeaponSlot);
}

//----------------------------------------------------------------------------

$InvList[GravFieldPack] = 1;
$RemoteInvList[GravFieldPack] = 1;

$ItemMax[harmor, GravFieldPack] = 1;
$ItemMax[marmor, GravFieldPack] = 0;
$ItemMax[mfemale, GravFieldPack] = 0;
$ItemMax[larmor, GravFieldPack] = 0;
$ItemMax[lfemale, GravFieldPack] = 0;
$ItemMax[MagIonM, GravFieldPack] = 0;
$ItemMax[MagIonF, GravFieldPack] = 0;
$ItemMax[MECH, GravFieldPack] = 1;
$ItemMax[sarmor, Accelerator] = 0;
$ItemMax[sfemale, Accelerator] = 0;
$ItemMax[ebarmor, Accelerator] = 0;
$ItemMax[ebfemale, Accelerator] = 0;
$ItemMax[mearmor, Accelerator] = 1;

ItemImageData GravFieldPackI
{
	shapeFile = "liqcyl";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, 0, -0.56 };
	mass = -4;
	minEnergy = -1;
 	maxEnergy = -2;
	firstPerson = false;
};

ItemData GravFieldPack
{
	description = "Gravitron Field Pack";
	shapeFile = "liqcyl";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = GravFieldPackI;
	price = 2500;
	hudIcon = "fear";
	showWeaponBar = true;
	hiliteOnActive = true;
};

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
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
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

//*************************************
// AAOD Mod BACKPACK Kit
//*************************************
//----------------------------------------------------------------------------
// ====================================
//		**** SuperRepair Pack ****
// ++++++++++++++++++++++++++++++++++++
//	Repairs Items Very Fast
//	Occupies 2 Slots BackPack & Flag
//	Can only Be unmounted At Inventory Station
//	Has 4 x The Range of normal repair bolts
//	Has 2 x the repair speed of normal Packs
//	Uses 11/3 the energy

$InvList[AODSuperRPack]			= 1;
$RemoteInvList[AODSuperRPack]		= 1;

$ItemMax[larmor, AODSuperRPack] = 0;
$ItemMax[lfemale, AODSuperRPack] = 0;
$ItemMax[marmor, AODSuperRPack] = 1;
$ItemMax[mfemale, AODSuperRPack] = 1;
$ItemMax[harmor, AODSuperRPack] = 1;
$ItemMax[MagIonM, AODSuperRPack] = 1;
$ItemMax[MagIonF, AODSuperRPack] = 1;
$ItemMax[MECH, AODSuperRPack] = 1;
$ItemMax[sarmor, AODSuperRPack] = 0;
$ItemMax[sfemale, AODSuperRPack] = 0;
$ItemMax[ebarmor, AODSuperRPack] = 1;
$ItemMax[ebfemale, AODSuperRPack] = 1;
$ItemMax[mearmor, AODSuperRPack] = 1;

RepairEffectData SuperRBolt
{	bitmapName			= "LightningNew.bmp";
	boltLength			= 200.0;
	segmentDivisions	= 6;
	beamWidth			= 0.175;
	updateTime			= 450;
	skipPercent			= 0.6;
	displaceBias		= 0.15;
	lightRange			= 6.0;
	lightColor			= { 0.85, 0.25, 0.25 };
};

ItemImageData SuperRPackImage
{	
	shapeFile		= "armorPack";
	mountPoint		= 2;
	weaponType		= 2;  // Sustained
	minEnergy		= 0;
	maxEnergy		= 0;   // Energy used/sec for sustained weapons
  	mountOffset		= { 0, -0.05, 0 };
  	mountRotation	= { 0, 0, 0 };
	firstPerson		= false;
};

ItemData AODSuperRPack
{	description		= "Super-Repair Pack";
	shapeFile		= "armorPack";
	className		= "Backpack";
	heading			= "kBackpacks";
	shadowDetailMask = 4;
	imageType		= SuperRPackImage;
	price			= 750;
	hudIcon			= "repairpack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

ItemImageData SuperR2Image
{	shapeFile		= "armorPack";
	mountPoint		= 2;
	weaponType		= 2;  // Sustained
	minEnergy		= 0;
	maxEnergy		= 0;   // Energy used/sec for sustained weapons
  	mountOffset		= { 0, -0.05, -0.10 };
  	mountRotation	= { 0, 3.14159, -0.015 };
	firstPerson		= false;
};

ItemData SuperR2Pack
{	description		= "Super-Repair Pack";
	shapeFile		= "armorPack";
	className		= "Backpack";
	heading			= "eBackpacks";
	shadowDetailMask = 4;
	imageType		= SuperR2Image;
	hudIcon			= "repairpack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

ItemImageData SuperRGunImage
{	shapeFile		= "repairgun";
	mountPoint		= 0;
	mountOffset		= { -0.15, 0, 0 };
	mountRotation	= { 0, 1.57, 0};
	weaponType		= 2;	// Sustained
	projectileType	= SuperRBolt;
	minEnergy		= 3;
	maxEnergy		= 13;	// Energy used/sec for sustained weapons
	lightType		= 3;	// Weapon Fire
	lightRadius		= 1;
	lightTime		= 1;
	lightColor		= { 0.25, 1, 0.25 };
	sfxActivate		= SoundPickUpWeapon;
	sfxFire			= SoundSuperRepair;
};

ItemData AODSuperRGun
{	description		= "Super-Repair Gun";
	shapeFile		= "repairgun";
	className		= "Weapon";
	shadowDetailMask = 4;
	imageType		= SuperRGunImage;
	showInventory	= false;
	price			= 150;
};

function AODSuperRPack::onUnmount(%player,%item)
{	if (Player::getMountedItem(%player,$WeaponSlot) == AODSuperRGun) 
	{	Player::unmountItem(%player,$WeaponSlot);
	}
	Player::UnMountItem(%player,$FlagSlot);
}

function AODSuperRPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	
	}
	else
	{	Player::mountItem(%player,AODSuperRGun,$WeaponSlot);
	}
}

function AODSuperRPack::onMount(%player,%item)
{	Player::mountItem(%player,SuperR2Pack,$FlagSlot);
}

function AODSuperRPack::onDrop(%player,%item)
{	%client = Player::getClient(%player);
	Client::SendMessage(%client,0,"Unable to DROP this type of pack. Must be sold at an inventory station~wAAODSFX14.WAV");
}	

function AODSuperRGun::onMount(%player,%imageSlot)
{	Player::trigger(%player,$BackpackSlot,true);
	Player::trigger(%player,$FlagSlot,true);
}

function AODSuperRGun::onUnmount(%player,%imageSlot)
{	Player::trigger(%player,$BackpackSlot,false);
	Player::trigger(%player,$FlagSlot,false);
}

//******************************************************
//				End Super Repair Pack
//******************************************************

ItemImageData autoPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 11;   // Energy/sec for sustained weapons
	sfxFire = SoundElfFire;
	firstPerson = false;
};

ItemData AutoPack
{
	description = "AutoRepair Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = AutoPackImage;
	price = 1250;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AutoPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"AutoRepair On");
	gameBase::setAutoRepairRate(%player, 0.07649827560921836509256);
	checkAutoRepair(%player);
}

function checkAutorepair(%player, %imageslot, %this)
{
	if(GameBase::getDamageLevel(%player) == 0)
	{
		Player::trigger(%player,$BackpackSlot,false);
		gameBase::setAutoRepairRate(%player, 0);
	}
	else
	{
		schedule("checkAutoRepair(" @ %player @ ");", 0.5,%player);
	}
}

function AutoPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"AutoRepair Off");
	Player::trigger(%player,$BackpackSlot,false);
	gameBase::setAutoRepairRate(%player, 0);
}

$InvList[AutoPack] = 1;
$RemoteInvList[AutoPack] = 1;

$ItemMax[harmor, AutoPack] = 1;
$ItemMax[marmor, AutoPack] = 1;
$ItemMax[mfemale, AutoPack] = 1;
$ItemMax[larmor, AutoPack] = 0;
$ItemMax[lfemale, AutoPack] = 0;
$ItemMax[BlastechF, AutoPack] = 0;
$ItemMax[BlastechM, AutoPack] = 0;
$ItemMax[MagIonM, AutoPack] = 1;
$ItemMax[MagIonF, AutoPack] = 1;
$ItemMax[MECH, AutoPack] = 1;
$ItemMax[sarmor, AutoPack] = 0;
$ItemMax[sfemale, AutoPack] = 0;
$ItemMax[ebarmor, AutoPack] = 1;
$ItemMax[ebfemale, AutoPack] = 1;
$ItemMax[mearmor, AutoPack] = 1;

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
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
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
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
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

//----------------------------------------------------------------------------
// Cloaking Device - INH*DynaBlade
//----------------------------------------------------------------------------

$InvList[CloakingDevice] = 1;
$RemoteInvList[CloakingDevice] = 1;

$ItemMax[harmor, CloakingDevice] = 0;
$ItemMax[marmor, CloakingDevice] = 0;
$ItemMax[mfemale, CloakingDevice] = 0;
$ItemMax[larmor, CloakingDevice] = 1;
$ItemMax[lfemale, CloakingDevice] = 1;
$ItemMax[BlastechF, CloakingDevice] = 1;
$ItemMax[BlastechM, CloakingDevice] = 1;
$ItemMax[MagIonM, CloakingDevice] = 0;
$ItemMax[MagIonF, CloakingDevice] = 0;
$ItemMax[MECH, CloakingDevice] = 0;
$ItemMax[sarmor, CloakingDevice] = 0;
$ItemMax[sfemale, CloakingDevice] = 0;
$ItemMax[ebarmor, CloakingDevice] = 1;
$ItemMax[ebfemale, CloakingDevice] = 1;
$ItemMax[mearmor, CloakingDevice] = 0;

ItemImageData CloakingDeviceImage
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

ItemData CloakingDevice
{
	description = "Cloaking Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 600;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	%radius = Player::getSensorSupression(%player) + 1;
	Player::setSensorSupression(%player,%radius);
	GameBase::playSound(%player,ForceFieldOpen,0);
 	GameBase::startFadeout(%player);
 	$cloaked[%player] = 1;
 	Cloaker(%player);
 	%ClientId = Player::getClient(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
	Player::trigger(%player,$BackpackSlot,true);
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{
	%radius = Player::getSensorSupression(%player) - 1;
	Player::setSensorSupression(%player,%radius);
	GameBase::playSound(%player,ForceFieldClose,0);
 	GameBase::startFadein(%player);
 	$cloaked[%player] = 0;
 	Cloaker(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "kBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 7 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.BulletAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.DiscAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

//----------------------------------------------------------------------------

$InvList[AmmoGeneratorPack]			= 1;
$RemoteInvList[AmmoGeneratorPack]		= 1;

$ItemMax[lfemale, AmmoGeneratorPack]	= 0;
$ItemMax[mfemale, AmmoGeneratorPack]	= 1;
$ItemMax[larmor, AmmoGeneratorPack]		= 0;
$ItemMax[marmor, AmmoGeneratorPack]		= 1;
$ItemMax[harmor, AmmoGeneratorPack]		= 1;
$ItemMax[BlastechF, AmmoGeneratorPack] = 0;
$ItemMax[BlastechM, AmmoGeneratorPack] = 0;
$ItemMax[MagIonM, AmmoGeneratorPack] = 1;
$ItemMax[MagIonF, AmmoGeneratorPack] = 1;
$ItemMax[MECH, AmmoGeneratorPack] = 1;
$ItemMax[sarmor, AmmoGeneratorPack] = 0;
$ItemMax[sfemale, AmmoGeneratorPack] = 0;
$ItemMax[ebarmor, AmmoGeneratorPack] = 0;
$ItemMax[ebfemale, AmmoGeneratorPack] = 0;
$ItemMax[mearmor, AmmoGeneratorPack] = 1;

ItemImageData AmmoGenI
{
	shapeFile = "ammopack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
   mountRotation = { 0, 1.57, 0 };
	weaponType = 2;  // Sustained
	minEnergy = 8;
	maxEnergy = 8;   // Energy/sec for sustained weapons
	firstPerson = false;
	mass = 4;
};

ItemData AmmoGeneratorPack
{
	description = "Ammo Generator";
	shapeFile = "ammopack";
	className = "Backpack";
   heading = "kBackpacks";
	imageType = AmmoGenI;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "ammogen";
	showWeaponBar = true;
	hiliteOnActive = true;
	mass = 4;
};

function AmmoGenI::onMount(%player,%item)
{
	%player.AmmoGenActive = "false";
	%player.AmmoGenCounter = 0;
}

function AmmoGenI::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),3,"Ammo Fabrication started...");
	%player.ammogenActive = "true";
	#Player::trigger(%player,$BackpackSlot,true);
	ammogenImage::RegenerateAmmo(%player);
}

function ammogenI::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"Ammo Fabrication stopped");
	Player::trigger(%player,$BackpackSlot,false);
	%player.ammogenActive = "false";
}

function AmmoGen::onDrop(%player, %item)
{
	Client::sendMessage(Player::getClient(%player),1,"Ammo Fabrication stopped");
	Player::trigger(%player,$BackpackSlot,false);
	%player.ammogenActive = "false";
}

function AmmoGenI::onDrop(%player, %item)
{
	Client::sendMessage(Player::getClient(%player),1,"Ammo Fabrication stopped");
	Player::trigger(%player,$BackpackSlot,false);
	%player.ammogenActive = "false";
}

function ammogenImage::RegenerateAmmo(%player)
{
	%player.ammogenCounter++;

	if (checkResources(%player,BulletAmmo,1,1) > 0 && Player::getItemCount(%player,Chaingun) == 1) ammogenImage::resupply(%player,"ChainGun",BulletAmmo,1,2);
	else if (checkResources(%player,PlasmaAmmo,1,1) > 0 && Player::getItemCount(%player,PlasmaGun) == 1) ammogenImage::resupply(%player,"PlasmaGun",PlasmaAmmo,1,4);
	else if (checkResources(%player,DiscAmmo,1,1) > 0 && Player::getItemCount(%player,DiscLauncher) == 1) ammogenImage::resupply(%player,"DiscLauncher",DiscAmmo,1,4);
	else if (checkResources(%player,GrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,GrenadeLauncher) == 1) ammogenImage::resupply(%player,"GrenadeLauncher",GrenadeAmmo,1,4);
	else if (checkResources(%player,ImpactAmmo,1,1) > 0 && Player::getItemCount(%player,ImpactMortar) == 1) ammogenImage::resupply(%player,"ImpactMortar",ImpactAmmo,1,10);
	else if (checkResources(%player,MortarAmmo,1,1) > 0 && Player::getItemCount(%player,Mortar) == 1) ammogenImage::resupply(%player,"Mortar",MortarAmmo,1,10);
	else if (checkResources(%player,EMPGrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,EMPGrenadeLauncher) == 1) ammogenImage::resupply(%player,"EMPGrenadeLauncher",EMPGrenadeAmmo,1,10);
	else if (checkResources(%player,MissileAmmo,1,1) > 0 && Player::getItemCount(%player,AODStinger) == 1) ammogenImage::resupply(%player,"AODStinger",MissileAmmo,1,10);
	else if (checkResources(%player,MinigunAmmo,1,1) > 0 && Player::getItemCount(%player,Minigun) == 1) ammogenImage::resupply(%player,"Minigun",MinigunAmmo,1,1);
	else if (checkResources(%player,MMinigunAmmo,1,1) > 0 && Player::getItemCount(%player,MMinigun) == 1) ammogenImage::resupply(%player,"MMinigun",MMinigunAmmo,1,1);
	else if (checkResources(%player,GrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,RPGLauncher) == 1) ammogenImage::resupply(%player,"RPGLauncher",GrenadeAmmo,1,4);
	else if (checkResources(%player,MortarAmmo,1,1) > 0 && Player::getItemCount(%player,RPMLauncher) == 1) ammogenImage::resupply(%player,"RPMLauncher",MortarAmmo,1,10);
	else if (checkResources(%player,MissileAmmo,1,1) > 0 && Player::getItemCount(%player,MechRocketLauncher) == 1) ammogenImage::resupply(%player,"MechRocketLauncher",MissileAmmo,1,10);
	else if (checkResources(%player,MRPGAmmo,1,1) > 0 && Player::getItemCount(%player,MRPGLauncher) == 1) ammogenImage::resupply(%player,"MRPGLauncher",MRPGAmmo,1,15);
	else if (checkResources(%player,GaussAmmo,1,1) > 0 && Player::getItemCount(%player,Gauss) == 1) ammogenImage::resupply(%player,"Gauss",GaussAmmo,1,5);	
	else if (checkResources(%player,Darts,1,1) > 0 && Player::getItemCount(%player,DartGun) == 1) ammogenImage::resupply(%player,"DartGun",Darts,1,5);	
	else if (checkResources(%player,Shells,1,1) > 0 && Player::getItemCount(%player,Rifle) == 1) ammogenImage::resupply(%player,"Shells",Rifle,1,5);	
	else if (checkResources(%player,bolts,1,1) > 0 && Player::getItemCount(%player,massdriver) == 1) ammogenImage::resupply(%player,"massdriver",bolts,1,5);	
	else if (checkResources(%player,SXAmmo,1,1) > 0 && Player::getItemCount(%player,AAODSniperX) == 1) ammogenImage::resupply(%player,"AAODSniperX",SXAmmo,1,10);	
	else if (checkResources(%player,beacon,1,1) > 0 && Player::getItemCount(%player,aodbeacongun) == 1) ammogenImage::resupply(%player,"aodbeacongun",beacon,1,10);
	else if (checkResources(%player,JugAmmo,1,1) > 0 && Player::getItemCount(%player,JugLauncher) == 1) ammogenImage::resupply(%player,"JugLauncher",JugAmmo,1,20);
	else if (checkResources(%player,ImpAmmo,1,1) > 0 && Player::getItemCount(%player,ImpGun) == 1) ammogenImage::resupply(%player,"ImpGun",ImpAmmo,1,10);
	else if (checkResources(%player,TwinFusorAmmo,1,1) > 0 && Player::getItemCount(%player,TwinFusorAmmo) == 1) ammogenImage::resupply(%player,"TwinFusor",TwinFusorAmmo,1,10);

	else if (checkResources(%player,Grenade,1,1) > 0 ) ammogenImage::resupply(%player,"",Grenade,1,25);
	else if (checkResources(%player,MineAmmo,1,1) > 0 ) ammogenImage::resupply(%player,"",MineAmmo,1,25);
	else if (checkResources(%player,Beacon,1,1) > 0 ) ammogenImage::resupply(%player,"",Beacon,1,25);
	else if (checkResources(%player,RepairKit,1,1) > 0 ) ammogenImage::resupply(%player,"",RepairKit,1,60);

	else 
		{
			%player.ammogenCounter = 0;
			Client::sendMessage(Player::getClient(%player),3,"Ammo level optimum--Fabrication complete.");
			Player::trigger(%player,$BackpackSlot,false);
			%player.ammogenActive = "false";
		}
      if (%player.ammogenActive == "true") {
		  schedule("ammogenImage::RegenerateAmmo(" @ %player @ ");", 0.1,%player);
		}
}

function ammogenImage::resupply(%player,%weapon,%item,%delta,%genreq)
{
	if (%player.ammogenCounter >= %genreq) 
		{
			%delta = checkResources(%player,%item,%delta,1);		
			if(%delta > 0) {						
				Player::incItemCount(%player,%item,%delta);
				%player.ammogenCounter = 0;
	 			return %delta;
			}
			return 0;
	}
}

//-----------------------------------------------

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 10 ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {
	        %numAdd = %item.BulletAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.DiscAmmo;
		}
		else if(%i == 3) {
	    	%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 4) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 5) {
		%numAdd = %item.MineAmmo;
		}
		else if(%i == 6) {
	    	%numAdd = %item.MortarAmmo;
		}
		else if(%i == 7) {
 	    	%numAdd = %item.Beacon;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.RocketAmmo;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.EMPGrenadeAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 10 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);

		}	
	}
}

ItemImageData UplinkPackImage
{
	shapeFile = "generator_p";
	mountOffset = { 0, 0, -0.3 };
	mountRotation = { 0, 0, 1.57 };
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 30;
	maxEnergy = 12;   // Energy/sec for sustained weapons
	firstPerson = false;
	mass = 8;
};

ItemData UplinkPack
{
	description = "Inventory Uplink Pack";
	shapeFile = "bridge";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = UplinkPackImage;
	price = 1500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	mass = 10;
};

function UplinkPackImage::onActivate(%player, %imageSlot)
{
	%InvShopList = "UplinkInvList";
	%client = Player::getClient(%player);
	Client::sendMessage(%client,3,"Satellite Uplink Acquired~wsensor_deploy.wav");
	%player.Station = %this;
	setupShoppingList(%client,%this,%InvShopList);
	updateBuyingList(%client);
	%this.target = %client;
 	Client::setGuiMode(%client,$GuiModeInventory);
	%player.ResupplyFlag = 1;
}

function UplinkPackImage::onDeactivate(%player, %imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"Connection Terminated~wfailpack.wav");
	%client = Player::getClient(%player);
	Client::clearItemShopping(%client);
	if(Client::getGuiMode(%client) != 1)
		Client::setGuiMode(%client ,1);

	%player.Station = "";
	%player.ResupplyFlag = 0;
}

$InvList[UplinkPack] = 1;
$RemoteInvList[UplinkPack] = 0;

$ItemMax[harmor, UplinkPack] = 1;
$ItemMax[marmor, UplinkPack] = 0;
$ItemMax[mfemale, UplinkPack] = 0;
$ItemMax[larmor, UplinkPack] = 0;
$ItemMax[lfemale, UplinkPack] = 0;
$ItemMax[BlastechF, UplinkPack] = 0;
$ItemMax[BlastechM, UplinkPack] = 0;
$ItemMax[MagIonM, UplinkPack] = 0;
$ItemMax[MagIonF, UplinkPack] = 0;
$ItemMax[MECH, UplinkPack] = 1;
$ItemMax[sarmor, UplinkPack] = 0;
$ItemMax[sfemale, UplinkPack] = 0;
$ItemMax[ebarmor, UplinkPack] = 0;
$ItemMax[ebfemale, UplinkPack] = 0;
$ItemMax[mearmor, UplinkPack] = 1;

#--------------------------------------------------#
#=========Coyote Ear Pack by INH*DynaBlade=========#
#--------------------------------------------------#

$InvList[BugPack]			= 1;
$RemoteInvList[BugPack]		= 1;

$ItemMax[lfemale, BugPack]	= 1;
$ItemMax[mfemale, BugPack]	= 1;
$ItemMax[larmor, BugPack]	= 1;
$ItemMax[marmor, BugPack]	= 1;
$ItemMax[harmor, BugPack]	= 1;
$ItemMax[BlastechF, BugPack] 	= 1;
$ItemMax[BlastechM, BugPack] 	= 1;
$ItemMax[MagIonM, BugPack] 	= 1;
$ItemMax[MagIonF, BugPack] 	= 1;
$ItemMax[MECH, BugPack] 	= 1;
$ItemMax[sarmor, BugPack]     = 1;
$ItemMax[sfemale, BugPack]    = 1;
$ItemMax[ebarmor, BugPack]    = 1;
$ItemMax[ebfemale, BugPack]   = 1;
$ItemMax[mearmor, BugPack]    = 1;

ItemImageData BugI
{	shapeFile		= "sensorjamPack";
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, 0 };
	firstPerson		= false;
	mass			= 0.5;
};

ItemData BugPack
{	description		= "TeamChat Tapper"; 
	shapeFile		= "sensorjamPack";
	classname		= "Backpack";
	heading		= "kBackpacks";
	shadowDetailMask  = 4;
	imageType		= BugI;
	price			= 1000;
	hudIcon		= "energypack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
	mass			= 0.5;
};

function BugPack::onUse(%player,%item)
{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function BugPack::onMount(%player,%item)
{	
	Player::trigger(%player,$BackpackSlot,true);
}

function BugPack::onUnmount(%player,%item)
{
}

// 	AODCmdPack Backpack Script
$InvList[AODCmdPack]			= 1;
$RemoteInvList[AODCmdPack]		= 1;
$TeamItemMax[AODCmdPack]		= 999999999;

$ItemMax[larmor, AODCmdPack]	= 0;
$ItemMax[lfemale, AODCmdPack]	= 0;
$ItemMax[marmor, AODCmdPack]	= 1;
$ItemMax[mfemale, AODCmdPack]	= 1;
$ItemMax[harmor, AODCmdPack]	= 1;
$ItemMax[BlastechF, AODCmdPack] = 0;
$ItemMax[BlastechM, AODCmdPack] = 0;
$ItemMax[MagIonM, AODCmdPack] = 0;
$ItemMax[MagIonF, AODCmdPack] = 0;
$ItemMax[MECH, AODCmdPack] = 1;
$ItemMax[sarmor, AODCmdPack] = 0;
$ItemMax[sfemale, AODCmdPack] = 0;
$ItemMax[ebarmor, AODCmdPack] = 0;
$ItemMax[ebfemale, AODCmdPack] = 0;
$ItemMax[mearmor, AODCmdPack] = 0;

ItemImageData AODCmdPackImage 
{	shapeFile		= "ammounit_remote";
	mountPoint		= 2;
	mountOffset		= { 0, -0.25, 0.5 };
	mountRotation	= { 0, 3.141592654, 0 };


	mass			= 1.0;
	firstPerson		= false;
};

ItemData AODCmdPack 
{	description = "Turret Control pack";
	shapeFile = "CMDPNL";
	classname = "Backpack";
	heading = "kBackpacks";
	imageType = AODCmdPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 250;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODCmdPack::onUse(%player,%item)
{	
	%client = Player::getClient(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	
		remoteCommandMode(%client);
	}
}

//----------------------------------------------------------------------------
// Teleport Packs
//----------------------------------------------------------------------------

$InvList[HyperPack] = 1;
$RemoteInvList[HyperPack] = 1;

$ItemMax[lfemale,HyperPack]=1;	
$ItemMax[larmor,HyperPack]=1;	
$ItemMax[mfemale,HyperPack]=1;	
$ItemMax[marmor,HyperPack]=1;	
$ItemMax[harmor,HyperPack]=1;	
$ItemMax[BlastechF, HyperPack] = 1;
$ItemMax[BlastechM, HyperPack] = 1;
$ItemMax[MagIonM, HyperPack] = 1;
$ItemMax[MagIonF, HyperPack] = 1;
$ItemMax[MECH, HyperPack] = 1;
$ItemMax[sarmor, HyperPack] = 1;
$ItemMax[sfemale, HyperPack] = 1;
$ItemMax[ebarmor, HyperPack] = 1;
$ItemMax[ebfemale, HyperPack] = 1;
$ItemMax[mearmor, HyperPack] = 1;

ItemImageData HyperPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 10;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData HyperPack
{
	description = "Jump Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
    heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = HyperPackImage;
	price = 75;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HyperPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jumping to random location");
	%spawnMarker = GameBase::getPosition(%player);	

	%rnd = floor(getRandom() * 10);

		if (%rnd < 5)	
			%xPos = getWord(%spawnMarker, 0) + (15 + floor(getRandom() * 25));
		else
			%xPos = getWord(%spawnMarker, 0) - (15 + floor(getRandom() * 25));


	%rnd = floor(getRandom() * 10);

		if (%rnd < 5)	
			%yPos = getword(%spawnMarker, 1) + (15 + floor(getRandom() * 20));
		else
			%yPos = getword(%spawnMarker, 1) - (15 + floor(getRandom() * 20));
	
	%zPos = getWord(%spawnMarker, 2) + 15;	
	%rPos = GameBase::getRotation(%player);	
	%zcoor = getWord(%spawnMarker, 2);
	%o = %xPos @ "  " @ %yPos @ "  " @ %zPos;

		%clientId = (client::getownedobject(%player));

		%belowground = (gamebase::getLOSInfo(%player,5000, "0 3.14 0"));
		%object = $los::object;

		%objname1 = getobjecttype(%object);
		%objname = (GameBase::getDataName(%object)).description;

	if(GameBase::testPosition(%player, %o))
	{		
		GameBase::SetPosition(%player, %o);
		Player::trigger(%player,$BackpackSlot,false);

		%belowground = (gamebase::getLOSInfo(%player,5000, "0 3.14 0"));
		
		if (%belowground == "false")
		{
			%rnd = floor(getRandom() * 10);

			if (%rnd < 5)	
				%xPos = getWord(%spawnMarker, 0) + (15 + floor(getRandom() * 25));
			else
				%xPos = getWord(%spawnMarker, 0) - (15 + floor(getRandom() * 25));

			%rnd = floor(getRandom() * 10);

			if (%rnd < 5)	
				%yPos = getword(%spawnMarker, 1) + (15 + floor(getRandom() * 20));
			else
				%yPos = getword(%spawnMarker, 1) - (15 + floor(getRandom() * 20));
	
			%zPos = getWord(%spawnMarker, 2) + 25;	
			%rPos = GameBase::getRotation(%player);	
			%o = %xPos @ "  " @ %yPos @ "  " @ %zPos;

			GameBase::SetPosition(%player, %o);
			Player::trigger(%player,$BackpackSlot,false);
		}
	}
	else 
	{
		Client::sendMessage(Player::getClient(%player),0,"Object in random jump path");
		Player::trigger(%player,$BackpackSlot,false);
	}
}

function HyperPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Randomly jumped to location");
	Player::trigger(%player,$BackpackSlot,false);
}

$InvList[Warpxpack] = 1;
$RemoteInvList[Warpxpack] = 1;

$UserPrefCoolTime = 15;
$HDRange = 210;

$ItemMax[lfemale,Warpxpack]=0;	
$ItemMax[larmor,Warpxpack]=0;	
$ItemMax[mfemale,Warpxpack]=1;	
$ItemMax[marmor,Warpxpack]=1;	
$ItemMax[harmor,Warpxpack]=1;	
$ItemMax[BlastechF, Warpxpack] = 0;
$ItemMax[BlastechM, Warpxpack] = 0;
$ItemMax[MagIonM, Warpxpack] = 1;
$ItemMax[MagIonF, Warpxpack] = 1;
$ItemMax[MECH, Warpxpack] = 1;
$ItemMax[sarmor, Warpxpack] = 0;
$ItemMax[sfemale, Warpxpack] = 0;
$ItemMax[ebarmor, Warpxpack] = 1;
$ItemMax[ebfemale, Warpxpack] = 1;
$ItemMax[mearmor, Warpxpack] = 1;

ItemImageData WarpxpackImage
{
        shapeFile = "armorkit";
        mountPoint = 2;
        weaponType = 2;
        minEnergy = 10;
        maxEnergy = 10;
        lightType = 3;
        lightRadius = 10;
        lightTime = 10;
        lightColor = { 0.3, 0.1, 0.6 };
        firstPerson = false;
};

ItemData Warpxpack
{
        description = "Hyperdrive Pack";
        shapeFile = "armorkit";
        className = "Backpack";
        heading = kBackPacks;
        shadowDetailMask = 4;
        imageType = WarpxpackImage;
        price = 150;
        hudIcon = "energypack";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function WarpxpackImage::onActivate(%player,%imageSlot)
{
        %client = Player::getClient(%player);
        %player = Client::getOwnedObject(%client);
        if (GameBase::getLOSInfo(%player,$HDRange))
        {
                %dest = $los::position;
                if($CoolTime[%client] > 0)
                {
                        Bottomprint(%client, "<jc><f1>Warning!\n<f2>Hyperdrive not cooled yet.");
                }
                else
                {
                        Hyperdrive(%client,%player,%dest);
                        WarpxpackImage::onDeactivate(%client,%imageSlot);
                        $CoolTime[%client] = $UserPrefCoolTime;
                        CoolOff(%client,%player);
                }
        }
        else
        {
                Bottomprint(%client, "<jc>Hyperdrive destination position out of range -- get within 300m");
                WarpxpackImage::onDeactivate(%client,%imageSlot);
        }
}

function WarpxpackImage::onDeactivate(%player,%imageSlot)
{
        Player::trigger(%player,$BackpackSlot,false);
}

function Warpxpack::onMount(%player,%item)
{
        %client = Player::getClient(%player);
        Bottomprint(%client, "<f2>Teleport to whatever's in your Crosshair! because of it's instability, do not teleport directly into a wall and this can only teleport 1 person at a time.", 10);
}

function CoolOff(%client,%player)
{
        if ($CoolTime[%client] > 0)
        {
                $CoolTime[%client] -= 1;
                schedule("CoolOff(" @ %client @ "," @ %player @ ");",1,%player);
        }
        else
        {
                $CoolTime[%client] = 0;
                Bottomprint(%client, "<jc><f1>Hyperdrive cooled -- Ready");
        }
}

function Hyperdrive(%client,%player,%dest)
{
      GameBase::setPosition(%client,%dest);
     	Bottomprint(%client, "<jc><f1>Hyperdrive!\n<jc><f0>Hyperdrive cooling -- wait about 15 seconds.");
}

$InvList[Slipstream]=1;	

$ItemMax[lfemale,Slipstream]=1;	
$ItemMax[larmor,Slipstream]=1;	
$ItemMax[mfemale,Slipstream]=1;	
$ItemMax[marmor,Slipstream]=1;	
$ItemMax[harmor,Slipstream]=0;	
$ItemMax[BlastechF, Slipstream] = 1;
$ItemMax[BlastechM, Slipstream] = 1;
$ItemMax[MagIonM, Slipstream] = 1;
$ItemMax[MagIonF, Slipstream] = 1;
$ItemMax[MECH, Slipstream] = 0;
$ItemMax[sarmor, Slipstream] = 1;
$ItemMax[sfemale, Slipstream] = 1;
$ItemMax[ebarmor, Slipstream] = 1;
$ItemMax[ebfemale, Slipstream] = 1;
$ItemMax[mearmor, Slipstream] = 0;

ItemImageData SlipPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, 0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	
	sfxFire = ForceFieldOpen;
};

ItemData Slipstream
{
	description = "Personal Teleporter";
	className = "Backpack";
	shapeFile = "mortarpack";
	hudIcon = "energypack";
	heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = SlipPackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Slipstream::onMount(%player,%item)
{
	%client = Player::getClient(%player);
      Bottomprint(%client, "This Personal Teleporter will instantly transport you and nearby ppl to your current waypoint.  Use at your own risk, the ''Rx-S Slipstream'' Personal Teleporter is not compatible on heavy armor.", $displaytime);
}


function SlipPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%waypoint= $point[%client];
	if (%waypoint== " 0 0" || !%waypoint)
	{
		Client::sendMessage(%client,1,"The Slipsteam has no destination waypoint or it is set into a solid object.");
		Player::trigger(%player,$BackpackSlot,false);
	}
	else
	{
		%teamspot = WaypointToWorld(%waypoint);
		%vertical = "0 0 400";
 		%teamspot = Vector::add(%teamspot,%vertical);
 		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$ItemObjectType,%teamspot,25,25,1000,0); // 100 100 800
		%num2 = CountObjects(%set,"flag",%num);
		%totalnum = Group::objectCount(%set);
		%enemyflag=0;
		for(%i = 0; %i < %totalnum; %i++)
		{
			%obj = Group::getObject(%set, %i);
			%name = Item::getItemData(%obj);
			if(%name == "flag")
			{
				if(GameBase::getTeam(%obj) != Gamebase::getTeam(%player)) %enemyflag = %enemyflag+1;
			}
		}
		deleteObject(%set);
		if (%enemyflag == 0)
		{
			if(!$TeleUsed[%player]) 
			{
				GameBase::playSound(%player,ForceFieldOpen,0);
				Client::sendMessage(Player::getClient(%player),3,"30 seconds until teleporter ready.");
				%client = Player::getClient(%player);
				%object = Client::getOwnedObject(%client);
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$SimPlayerObjectType,GameBase::getPosition(%player),5,5,5,0);
				%totalnum = Group::objectCount(%set);
				%destinationspot[%player]=%teamspot;
				%mass=0;
				$point[%client]=" 0 0";
				for(%i = 0; %i < %totalnum; %i++)
				{
				 	%obj = Group::getObject(%set, %i);
				 	if(GameBase::GetTeam(%obj) == GameBase::GetTeam(%player))
					{
				 		%mass=%mass+getmass(%obj);
				 		if (%obj != %player)
				 		{
				 			%posobj = GameBase::getPosition(%obj);
				 			%posplayer = GameBase::getPosition(%player);
				 			%resultant = Vector::sub(%posplayer, %posobj);
				 			%destinationspot[%obj]=Vector::add(%teamspot,%resultant);
				 		}
				 	}
				}
				%rnd = floor(getRandom() * 55);
				for(%i = 0; %i < %totalnum; %i++)
				{
				 	
				 	%obj = Group::getObject(%set, %i);
				 	if(GameBase::GetTeam(%obj) == GameBase::GetTeam(%player))
					{
				 		%hasflag = Player::getMountedItem(%obj, 2);
				 		%armor = player::GetArmor(%obj);
				 		%PackClient = Player::getClient(%player);
				 		if(%hasflag!=-1 && %hasflag!="DeadWeight")
						{
							Player::dropItem(%obj, %hasflag);
							Client::sendMessage(Player::getClient(%obj),1,"Flag is made of material that cannot be teleported.");
						}
						if (%rnd > %mass)
						{
							if (%armor !=harmor)
							{
				 				TeleportPlayer(%obj,%destinationspot[%obj]);
				 				Client::sendMessage(Player::getClient(%obj),3,"You have jumped to your destination.");
				 				GameBase::playSound(%obj,ForceFieldOpen,0);
				 			}
				 		}
				 		else
				 		{
				 			TeleportPlayer(%obj,%destinationspot[%obj]);
				 			%damagedClient = Player::getClient(%obj);
				 			Client::sendMessage(Player::getClient(%obj),1,"Too much mass for the Slipstream to handle.. OVERLOAD!");
				 			GameBase::applyDamage(%obj,$TeleportDamageType,40,%destinationspot[%obj],"0 0 0","0 0 0",%damagedClient);
				 			if(%damagedClient.lastDamage < getSimTime()) 
							{
								%sound = radnomItems(3,injure1,injure2,injure3);
								playVoice(%damagedClient,%sound);
								%damagedClient.lastdamage = getSimTime() + 1.5;
							}
				 			Player::blowUp(%obj);
				 		}
					}
				}
				deleteObject(%set);
				setCommandStatus(%client, 0, "Deleting set waypoint...");
				Player::trigger(%player,$BackpackSlot,false);
				$TeleUsed[%player] = true;
			        %time = 30; 
				schedule("TelePackCooling(" @ %time @ ", " @ %player @ ");", 1, %player);
			}
			else 
			{
				Client::sendMessage(Player::getClient(%player),1,"Slipstream is still charging.");
				Player::trigger(%player,$BackpackSlot,false);
			}
	
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"I'm not stupid FOOL! Move that waypoint AWAY from that Flag!!");
			Player::trigger(%player,$BackpackSlot,false);
		}
	}
	
}

function SlipPackImage::onDeactivate(%player, %imageSlot)
{
}

function getmass(%obj)
{
	%mass = 18;
	%armor = player::GetArmor(%obj);
	if(%armor==larmor) %mass =0;
	if(%armor==lfemale) %mass =0;
	if(%armor==marmor) %mass =0;
	if(%armor==mfemale) %mass =0;
	if(%armor==harmor) %mass = 18;
	if(%armor==BlastechM) %mass =0;
	if(%armor==BlastechF) %mass =0;
	if(%armor==MagIonM) %mass =0;
	if(%armor==MagIonF) %mass =0;
	if(%armor==MECH) %mass = 18;
	if(%armor==mearmor) %mass = 9;
	if(%armor==sarmor) %mass = 0;
	if(%armor==sfemale) %mass = 0;
	if(%armor==ebarmor) %mass = 0;
	if(%armor==ebfemale) %mass = 0;
	return %mass;
}

function TeleportPlayer(%player,%tportspot)
{
	%vel = Item::getVelocity(%player);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
 	Projectile::spawnProjectile("TeleportShock",%trans,%player,%vel,%player);
	Player::setDamageFlash(%player, 0.4);
	GameBase::startFadein(%player);
	%camera = newObject("Camera","Turret",cameraturret,true);
	GameBase::setPosition(%camera,%tportspot);
	GameBase::getLOSInfo(%camera,600,"-1.5708 0 0");
	DeleteObject(%camera);
	GameBase::setPosition(%player, $los::position);
	%vel = Item::getVelocity(%player);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
 	Projectile::spawnProjectile("TeleportShock",%trans,%player,%vel,%player);
}



function TelePackCooling(%time, %player)
{
	if(%time > 0)
	{
		schedule("TelePackCooling( " @ %time - 1 @ ", " @ %player @ ");", 1, %player);
	}
	else if(%time == 0)
	{
		TeleReset(%player);
	}
}

function TeleReset(%player)
{
	$TeleUsed[%player] = false;
	Client::sendMessage(Player::getClient(%player),3,"Slipstream charge @100% Ready for teleport.");
}

//=========================================================================

$InvList[JetfirePack] = 1;
$RemoteInvList[JetfirePack] = 1;

$ItemMax[larmor, JetfirePack] = 0;
$ItemMax[lfemale, JetfirePack] = 0;
$ItemMax[marmor, JetfirePack] = 0;
$ItemMax[mfemale, JetfirePack] = 0;
$ItemMax[harmor, JetfirePack] = 1;
$ItemMax[BlastechF, JetfirePack] = 0;
$ItemMax[BlastechM, JetfirePack] = 0;
$ItemMax[MagIonM, JetfirePack] = 0;
$ItemMax[MagIonF, JetfirePack] = 0;
$ItemMax[MECH, JetfirePack] = 0;
$ItemMax[sarmor, JetfirePack] = 0;
$ItemMax[sfemale, JetfirePack] = 0;
$ItemMax[ebarmor, JetfirePack] = 0;
$ItemMax[ebfemale, JetfirePack] = 0;
$ItemMax[mearmor, JetfirePack] = 0;

ItemImageData JetfirePackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData JetfirePack
{
	description = "Jetfire Transformer";
	className = "Backpack";
	shapeFile = "mortarpack";
	hudIcon = "shieldpack";
	heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = JetfirePackImage;
	price = 7500;
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JetfirePackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	Player::applyImpulse(%player, "0 0 300");
	bottomprint(Player::getClient(%player), "<jc><f2>Flier <f0>mode", 5);

	playSound (GameBase::getDataName(%this).MountSound, GameBase::getPosition(%this));

	%vel = Item::getVelocity(%client);

	if(Player::getMountedItem(%client, $FlagSlot) == "flag")
	{
		Player::dropItem(%client, Player::getMountedItem(%client, $FlagSlot));
		Client::sendMessage(%client, 1, "You dropped the flag while transforming!");
	}

	%item = JetfireVehicle;

	%markerPos = GameBase::getPosition(%client);
	%set = newObject("",Flier, Jetfire, true);

	%damage = GameBase::getDamageLevel(%player);

	%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;

	%vehicle = newObject("",flier,$DataBlockName[%item],true);
	Gamebase::setMapName(%vehicle,%item.description);
      %vehicle.clLastMount = %client;
	addToSet("MissionCleanup", %vehicle);
  	%vehicle.fading = 1;
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::setPosition(%vehicle,%markerPos);
	GameBase::setRotation(%vehicle,GameBase::getRotation(%client));
	deleteObject(%set);
	$TeamItemCount[Client::getTeam(%client) @ %item]++;

	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(%weapon != -1)
	{
		%player.lastWeapon = %weapon;
		Player::unMountItem(%player,$WeaponSlot);
	}

	Player::setMountObject(%player, %vehicle, 1);
	Client::setControlObject(%client, %vehicle);
	%player.driver = 1;
	%player.vehicle = %vehicle;
	%vehicle.clLastMount = %client;
	GameBase::setDamageLevel(%vehicle, %damage);

	Item::setVelocity(%client, %vel);
}

function JetfirePackImage::onDeactivate(%player, %imageSlot)
{
	bottomprint(Player::getClient(%player), "<jc><f2>Bipedal <f0>mode", 5);
}

//=========================================================================

$InvList[RetaliatorPack] = 1;
$RemoteInvList[RetaliatorPack] = 1;

$ItemMax[larmor, RetaliatorPack] = 0;
$ItemMax[lfemale, RetaliatorPack] = 0;
$ItemMax[marmor, RetaliatorPack] = 0;
$ItemMax[mfemale, RetaliatorPack] = 0;
$ItemMax[harmor, RetaliatorPack] = 0;
$ItemMax[BlastechF, RetaliatorPack] = 0;
$ItemMax[BlastechM, RetaliatorPack] = 0;
$ItemMax[MagIonM, RetaliatorPack] = 0;
$ItemMax[MagIonF, RetaliatorPack] = 0;
$ItemMax[MECH, RetaliatorPack] = 1;
$ItemMax[sarmor, RetaliatorPack] = 0;
$ItemMax[sfemale, RetaliatorPack] = 0;
$ItemMax[ebarmor, RetaliatorPack] = 0;
$ItemMax[ebfemale, RetaliatorPack] = 0;
$ItemMax[mearmor, RetaliatorPack] = 0;

ItemImageData RetaliatorPackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RetaliatorPack
{
	description = "Retaliator Transformer";
	className = "Backpack";
	shapeFile = "mortarpack";
	hudIcon = "shieldpack";
	heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = RetaliatorPackImage;
	price = 7500;
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RetaliatorPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	Player::applyImpulse(%player, "0 0 300");
	bottomprint(Player::getClient(%player), "<jc><f2>Flier <f0>mode", 5);

	playSound (GameBase::getDataName(%this).MountSound, GameBase::getPosition(%this));

	%vel = Item::getVelocity(%client);

	if(Player::getMountedItem(%client, $FlagSlot) == "flag")
	{
		Player::dropItem(%client, Player::getMountedItem(%client, $FlagSlot));
		Client::sendMessage(%client, 1, "You dropped the flag while transforming!");
	}

	%item = RetaliatorVehicle;

	%markerPos = GameBase::getPosition(%client);
	%set = newObject("",Flier, Retaliator, true);

	%damage = GameBase::getDamageLevel(%player);

	%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;

	%vehicle = newObject("",flier,$DataBlockName[%item],true);
	Gamebase::setMapName(%vehicle,%item.description);
      %vehicle.clLastMount = %client;
	addToSet("MissionCleanup", %vehicle);
  	%vehicle.fading = 1;
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::setPosition(%vehicle,%markerPos);
	GameBase::setRotation(%vehicle,GameBase::getRotation(%client));
	deleteObject(%set);
	$TeamItemCount[Client::getTeam(%client) @ %item]++;

	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(%weapon != -1)
	{
		%player.lastWeapon = %weapon;
		Player::unMountItem(%player,$WeaponSlot);
	}

	Player::setMountObject(%player, %vehicle, 1);
	Client::setControlObject(%client, %vehicle);
	%player.driver = 1;
	%player.vehicle = %vehicle;
	%vehicle.clLastMount = %client;
	GameBase::setDamageLevel(%vehicle, %damage);

	Item::setVelocity(%client, %vel);
}

function RetaliatorPackImage::onDeactivate(%player, %imageSlot)
{
	bottomprint(Player::getClient(%player), "<jc><f2>Bipedal <f0>mode", 5);
}


