# ptrPack -> ptrFlag functions

function Player::hasFlag(%player)
{
	%flag = Player::getMountedItem(%player, $FlagSlot);
	$theFlag = %flag;

	if(%flag == Flag)	
		return true;
	else 
		return false;
}

function FindFlag(%pos,%xdist,%ydist,%zdist)
{
 	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,%pos,%xDist,%yDist,%zDist,0);
	%flag = CountObjects(%set,"FlagStand",%num);

	deleteObject(%set);

	if(%flag)
		return true;
	else
		FindActualFlag(%pos,%xdist,%ydist,%zdist);
}

function findActualFlag(%pos,%xdist,%ydist,%zdist)
{
 	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$ItemObjectType,%pos,%xDist,%yDist,%zDist,0);
	%flag = CountObjects(%set,"Flag",%num);

	deleteObject(%set);

	if(%flag)
		return true;
	else 
		return false;
}

//----------------------------------------------------------------------------
ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -8;
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

$InvList[Reactor] = 1;
$RemoteInvList[Reactor] = 1;

$ItemMax[harmor, Reactor] = 1;
$ItemMax[marmor, Reactor] = 0;
$ItemMax[mfemale, Reactor] = 0;
$ItemMax[larmor, Reactor] = 1;
$ItemMax[lfemale, Reactor] = 1;
$ItemMax[BlastechF, Reactor] = 1;
$ItemMax[BlastechM, Reactor] = 1;
$ItemMax[MagIonM, Reactor] = 0;
$ItemMax[MagIonF, Reactor] = 0;
$ItemMax[MECH, Reactor] = 1;

ItemImageData ReactorImage
{
	shapeFile = "shieldPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, 0, -0.3 };
	mountRotation = { 0, 0, 1.57 };

	minEnergy = -1;
 	maxEnergy = -27;
	firstPerson = false;
};

ItemData Reactor
{
	description = "Mini-Reactor";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = ReactorImage;
	price = 1200;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Reactor::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function Reactor::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}
//===========================

$InvList[Accelerator] = 1;
$RemoteInvList[Accelerator] = 1;

$ItemMax[harmor, Accelerator] = 1;
$ItemMax[marmor, Accelerator] = 1;
$ItemMax[mfemale, Accelerator] = 1;
$ItemMax[larmor, Accelerator] = 0;
$ItemMax[lfemale, Accelerator] = 0;
$ItemMax[BlastechF, Accelerator] = 1;
$ItemMax[BlastechM, Accelerator] = 1;
$ItemMax[MagIonM, Accelerator] = 1;
$ItemMax[MagIonF, Accelerator] = 1;
$ItemMax[MECH, Accelerator] = 1;

ItemImageData AcceleratorImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -12;
	firstPerson = false;
};

ItemData Accelerator
{
	description = "Particle Accelerator";
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

$InvList[MitziCharger] = 1;
$RemoteInvList[MitziCharger] = 1;

$ItemMax[harmor, MitziCharger] = 1;
$ItemMax[marmor, MitziCharger] = 1;
$ItemMax[mfemale, MitziCharger] = 1;
$ItemMax[larmor, MitziCharger] = 1;
$ItemMax[lfemale, MitziCharger] = 1;
$ItemMax[BlastechF, MitziCharger] = 1;
$ItemMax[BlastechM, MitziCharger] = 1;
$ItemMax[MagIonM, MitziCharger] = 1;
$ItemMax[MagIonF, MitziCharger] = 1;
$ItemMax[MECH, MitziCharger] = 1;

ItemImageData MitziChargerImage
{
	shapeFile = "mineammo";
	weaponType = 2;  // Sustained

	mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
	minEnergy = -1;
 	maxEnergy = -1;
	firstPerson = false;
};

ItemData MitziCharger
{
	description = "Mitzi Charger";
	shapeFile = "mineammo";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = MitziChargerImage;
	price = 1000;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

//----------------------------------------------------------------------------

$InvList[GravFieldPack] = 0;
$RemoteInvList[GravFieldPack] = 0;

$ItemMax[harmor, GravFieldPack] = 0;
$ItemMax[marmor, GravFieldPack] = 0;
$ItemMax[mfemale, GravFieldPack] = 0;
$ItemMax[larmor, GravFieldPack] = 0;
$ItemMax[lfemale, GravFieldPack] = 0;
$ItemMax[BlastechF, GravFieldPack] = 0;
$ItemMax[BlastechM, GravFieldPack] = 0;
$ItemMax[MagIonM, GravFieldPack] = 0;
$ItemMax[MagIonF, GravFieldPack] = 0;
$ItemMax[MECH, GravFieldPack] = 0;

ItemImageData GravFieldPackI
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, 0, -0.56 };
	mass = -8;
	minEnergy = -1;
 	maxEnergy = -1;
	firstPerson = false;
};

ItemData GravFieldPack
{
	description = "Gravitron Field Pack";
	shapeFile = "jetPack";
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
$ItemMax[BlastechF, AODSuperRPack] = 0;
$ItemMax[BlastechM, AODSuperRPack] = 0;
$ItemMax[MagIonM, AODSuperRPack] = 0;
$ItemMax[MagIonF, AODSuperRPack] = 0;
$ItemMax[MECH, AODSuperRPack] = 1;

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
	gameBase::setAutoRepairRate(%player, 0.075);
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

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 9;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CloakingDevice
{
	description = "3Dfx Cloaking Device";
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
	else if (checkResources(%player,EMPGrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,RPEMPLauncher) == 1) ammogenImage::resupply(%player,"RPEMPLauncher",EMPGrenadeAmmo,1,10);
	else if (checkResources(%player,MissileAmmo,1,1) > 0 && Player::getItemCount(%player,MechRocketLauncher) == 1) ammogenImage::resupply(%player,"MechRocketLauncher",MissileAmmo,1,10);
	else if (checkResources(%player,MRPGAmmo,1,1) > 0 && Player::getItemCount(%player,MRPGLauncher) == 1) ammogenImage::resupply(%player,"MRPGLauncher",MRPGAmmo,1,15);
	else if (checkResources(%player,GaussAmmo,1,1) > 0 && Player::getItemCount(%player,Gauss) == 1) ammogenImage::resupply(%player,"Gauss",GaussAmmo,1,5);
	else if (checkResources(%player,MultiMineAmmo,1,1) > 0 && Player::getItemCount(%player,MineLauncher) == 1) ammogenImage::resupply(%player,"MineLauncher",MultiMineAmmo,1,30);	
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

//--------------------------------------------------
//		ADVANCED TARGETING PACK by: Valya[AAOD]
//--------------------------------------------------

$InvList[TargPack]		= 1;
$RemoteInvList[TargPack]	= 1;

$ItemMax[lfemale, TargPack]	= 1;
$ItemMax[mfemale, TargPack]	= 1;
$ItemMax[larmor, TargPack]	= 1;
$ItemMax[marmor, TargPack]	= 1;
$ItemMax[harmor, TargPack]	= 1;
$ItemMax[BlastechF, TargPack] = 1;
$ItemMax[BlastechM, TargPack] = 1;
$ItemMax[MagIonM, TargPack] 	= 1;
$ItemMax[MagIonF, TargPack] 	= 1;
$ItemMax[MECH, TargPack] 	= 1;

ItemImageData AODATPackImage
{
	shapeFile		= "radar_small";
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, 0 };
	minEnergy		= 1;
 	maxEnergy		= 3;
	firstPerson		= false;
	mass			= 0.5;
};

ItemData TargPack
{
	description		= "Missile Targeting Pack";
	shapeFile		= "radar_small";
	classname		= "Backpack";
	heading			= "kBackpacks";
	shadowDetailMask = 4;
	imageType		= AODATPackImage;
	price			= 750;
	hudIcon			= "energypack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
	mass			= 0.5;
};

function TargPack::onUse(%player,%item)
{	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
	Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function TargPack::onMount(%player,%item)
{	
	Player::trigger(%player,$BackpackSlot,true);
}

function TargPack::onUnmount(%player,%item)
{
}

#--------------------------------------------------#
#=========Coyote Ear Pack by INH*DynaBlade=========#
#--------------------------------------------------#

$InvList[BugPack]			= 1;
$RemoteInvList[BugPack]		= 1;

$ItemMax[lfemale, BugPack]	= 0;
$ItemMax[mfemale, BugPack]	= 1;
$ItemMax[larmor, BugPack]	= 0;
$ItemMax[marmor, BugPack]	= 1;
$ItemMax[harmor, BugPack]	= 1;
$ItemMax[BlastechF, BugPack] 	= 0;
$ItemMax[BlastechM, BugPack] 	= 0;
$ItemMax[MagIonM, BugPack] 	= 1;
$ItemMax[MagIonF, BugPack] 	= 1;
$ItemMax[MECH, BugPack] 	= 1;

ItemImageData BugI
{	shapeFile		= "sensorjamPack";
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, 0 };
	firstPerson		= false;
	mass			= 0.5;
};

ItemData BugPack
{	description		= "TeamChat Tapper"; // NOW you know what it is!
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
$ItemMax[harmor, AODCmdPack]	= 0;
$ItemMax[BlastechF, AODCmdPack] = 0;
$ItemMax[BlastechM, AODCmdPack] = 0;
$ItemMax[MagIonM, AODCmdPack] = 0;
$ItemMax[MagIonF, AODCmdPack] = 0;
$ItemMax[MECH, AODCmdPack] = 0;

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

//--------------------------------------------------------------------------------------------------------
// Hyperdrive Pack 
//--------------------------------------------------------------------------------------------------------

$InvList[HyperPack] = 1;
$RemoteInvList[HyperPack] = 1;

$ItemMax[lfemale,HyperPack] = 0;	
$ItemMax[larmor,HyperPack] = 0;	
$ItemMax[mfemale,HyperPack] = 1;	
$ItemMax[marmor,HyperPack] = 1;	
$ItemMax[harmor,HyperPack] = 1;	
$ItemMax[BlastechF, HyperPack] = 0;
$ItemMax[BlastechM, HyperPack] = 0;
$ItemMax[MagIonM, HyperPack] = 1;
$ItemMax[MagIonF, HyperPack] = 1;
$ItemMax[MECH, HyperPack] = 1;

ItemImageData HyperPackImage
{
        shapeFile = "armorkit";
        mountPoint = 2;
        weaponType = 2;
        minEnergy = 1;
        maxEnergy = 1;
        lightType = 3;
        lightRadius = 10;
        lightTime = 10;
        lightColor = { 0.3, 0.1, 0.6 };
        firstPerson = false;
};

ItemData HyperPack
{
        description = "Hyperdrive Pack";
        shapeFile = "armorkit";
        className = "Backpack";
        heading = kBackpacks;
        shadowDetailMask = 4;
        imageType = HyperPackImage;
        price = 150;
        hudIcon = "compass";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function HyperPackImage::onActivate(%player,%imageSlot)
{
	%energy = GameBase::getEnergy(%player);

	if(%energy > 30)
	{
		%client = Player::getClient(%player);
		%pos = GameBase::getPosition(%player);

		if(GameBase::getLOSInfo(%player, 302))
		{
			if(Player::hasFlag(%player))
			{
				Player::dropItem(%player, $theFlag);	// pun city :)
				Client::sendMessage(%client, 1, "Cannot carry flag on Teleportation; dropping flag.~werror_message.wav");
			}

			if(FindFlag($los::position,50,50,1024))	// making sure
			{
				Client::sendMessage(%client, 1, "Cannot teleport within 50m of the flag.");
				Player::trigger(%player, $BackpackSlot,false);	
			}

			GameBase::setPosition(%player,$los::position);
			playSound(ForceFieldOpen,$los::position);
			useEnergy(%player,30);
			Player::trigger(%player,$BackPackSlot,false);
		}
		else
		{
			Bottomprint(%client, "<jc>Hyperdrive destination position out of range -- get within 300m");
			Player::trigger(%player,$BackPackSlot,false);
		}	
	}
	else
	{
		playSound(SoundPackFail,%pos);
		Player::trigger(%player,$BackPackSlot,false);
	}
}

function HyperPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}



//--------------------------------------------------------------------------------------------------------
// Slipstream Teleporter Pack 
//--------------------------------------------------------------------------------------------------------

$InvList[Slipstream] = 1;	
$RemoteInvList[Slipstream] = 1;

$ItemMax[lfemale,Slipstream] = 1;	
$ItemMax[larmor,Slipstream] = 1;	
$ItemMax[mfemale,Slipstream] = 1;	
$ItemMax[marmor,Slipstream] = 1;	
$ItemMax[harmor,Slipstream] = 0;	
$ItemMax[BlastechF, Slipstream] = 1;
$ItemMax[BlastechM, Slipstream] = 1;
$ItemMax[MagIonM, Slipstream] = 1;
$ItemMax[MagIonF, Slipstream] = 1;
$ItemMax[MECH, Slipstream] = 0;

ItemImageData SlipPackImage
{
	shapeFile = "mortarAmmo";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, 0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData Slipstream
{
	description = "Slipstream Teleporter";
	className = "Backpack";
	shapeFile = "mortarAmmo";
	hudIcon = "compass";
	heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = SlipPackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SlipPackImage::onActivate(%player, %imageSlot)
{
	Slipstream::Teleport(%player);
}

function Slipstream::Teleport(%player)
{
	%client = Player::getClient(%player);

	if($waypoint == "0 0" || !$waypoint)	// initial waypoint check
	{
		Client::sendMessage(%client,1,"Warning! No waypoint specified.~wfailpack.wav");
		Player::trigger(%player,$BackpackSlot,false);
		return;
	}
	else
	{
		%wpPos = WaypointToWorld($waypoint);
 		%waypointPos = Vector::add(%wpPos,"0 0 400");
		%energy = GameBase::getEnergy(%player);
		%armor =  Player::getArmor(%player);
		%pos = GameBase::getPosition(%player);

		%dpos = newObject("","Turret",cameraturret,true);	// for determining Z
		GameBase::setPosition(%zpos,%waypointPos);
		GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
		deleteObject(%dpos);

		if(Player::hasFlag(%player))
		{
			Player::dropItem(%player, $theFlag);	// pun city :)
			Client::sendMessage(%client, 1, "Cannot carry flag on Teleportation; dropping flag.~wC_buysell.wav");
		}

		if(FindFlag($los::position,50,50,1024))	// cant tele within 50 on waypoint
		{
			Client::sendMessage(%client, 1, "Cannot teleport within 50m of the flag.~werror_message.wav");
			Player::trigger(%player, $BackpackSlot,false);	
		}
		else if(FindFlag(%pos,50,50,1024))		// cant tele within 50 on player pos
		{
			Client::sendMessage(%client, 1, "Cannot teleport within 50m of the flag.~werror_message.wav");
			Player::trigger(%player, $BackpackSlot,false);	
		}
	
		if(%energy >= %armor.maxEnergy - 1) // for any armor
		{
			$waypoint = "0 0";

			useEnergy(%player,60);
			GameBase::startFadeIn(%player);
			Player::setDamageFlash(%player, 0.4);

			%zpos = newObject("","Turret",cameraturret,true);	// for determining Z
			GameBase::setPosition(%zpos,%waypointPos);
			GameBase::getLOSInfo(%zpos,1024,"-1.57 0 0");	// Z LOS
			deleteObject(%zpos);

			GameBase::setPosition(%player, $los::position);	// our LOS position :)
			playSound(SoundLaserHit,$los::position);
			setCommandStatus(%client, 0, "Teleporter ready at full energy.");
			Player::trigger(%player,$BackpackSlot,false);
		}
		else 
		{
			Client::sendMessage(%client,1,"Not enough Energy.~wfailpack.wav");
			Player::trigger(%player,$BackpackSlot,false);
		}
	}
}

//--------------------------------------------------------------------------------------------------------
// Leech Pack 
//--------------------------------------------------------------------------------------------------------

ItemImageData LeechPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = -1;
	maxEnergy = 4;   // Energy/sec for sustained weapons
	sfxFire = SoundSensorPower;
	firstPerson = false;
};

ItemData LeechPack
{
	description = "Leech Pack";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = LeechPackImage;
	price = 7500;
	hudIcon = "compass";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LeechPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Leech Field On");
	Xi::initLeech(%player);
}

function Xi::initLeech(%player)
{
	if(Player::isTriggered(%player,$BackpackSlot))
	{
		if(Player::getMountedItem(%player,$BackpackSlot) == LeechPack)
		{
			%team = GameBase::getTeam(%player);
			%set = newObject("set",SimSet);
			%pos = GameBase::getPosition(%player);
			containerBoxFillSet(%set,$SimPlayerObjectType | $MineObjectType,%pos,$Xi::LeechFieldSize,$Xi::LeechFieldSize,$Xi::LeechFieldSize,0); // will the real players (and mines) please stand up?
			%count = Group::objectCount(%set);

			if(%count)
      		{ 
				for(%i; %i < %count; %i++)
				{
					%tgt = Group::getObject(%set,%i);
					%tgtTeam = GameBase::getTeam(%tgt);
					%target = Group::getObject(%set, %count); 

					if(%team != %tgtTeam) // no TK leeching :)
					{
						%energy = GameBase::getEnergy(%player);
			 			%energy += %count; // Grabs their energy (collectively)
					      GameBase::setEnergy(%player, %energy);
						%damlevel = GameBase::getDamageLevel(%player);
						%damlevel -= 0.0025 * %count; // Grabs their health (collectively)
						GameBase::setDamageLevel(%player,%damlevel);

						%energy = GameBase::getEnergy(%tgt);	// Different DMG script for target.
			 			%energy -= 1; // Grabs their energy (collectively)
					      GameBase::setEnergy(%tgt, %energy);
						%pos = GameBase::getPosition(tgt);
						GameBase::applyDamage(%tgt,$DebrisDamageType,0.0025,%pos,"0 0 0","0 0 0",%player);
					}
				}
			}
		      deleteObject(%set); // no need for the set anymore, killit()
			schedule("Xi::initLeech(" @ %player @ ");", 0.05,%player); // 20x per second or 2x per 1/10th second
		}
	}
}

function LeechPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Leech Field Off");
	Player::trigger(%player,$BackpackSlot,false);
}

$InvList[LeechPack] = 1;
$RemoteInvList[LeechPack] = 1;

$ItemMax[harmor, LeechPack] = 1;
$ItemMax[marmor, LeechPack] = 0;
$ItemMax[mfemale, LeechPack] = 0;
$ItemMax[larmor, LeechPack] = 0; 
$ItemMax[lfemale, LeechPack] = 0;
$ItemMax[BlastechF, LeechPack] = 0;
$ItemMax[BlastechM, LeechPack] = 0;
$ItemMax[MagIonM, LeechPack] = 0;
$ItemMax[MagIonF, LeechPack] = 0;
$ItemMax[MECH, LeechPack] = 1;

//--------------------------------------------------------------------------------------------------------
// Capacitor Pack 
//--------------------------------------------------------------------------------------------------------

ItemData GigaWatt
{
	description = "GigaWatts: ";
	className = "Ammo";
	shapeFile = "zap_5";
   heading = "yElectrical";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData CapacitorImage
{
	shapeFile = "mortarAmmo";

	weaponType = 2;  // Sustained
	mountRotation = { 0, 0, -1.57 };
	mountPoint = 2;

	ammoType = GigaWatt;
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData Capacitor
{
	description = "Capacitor";
	shapeFile = "ammo2";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = CapacitorImage;
	price = 1000;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Capacitor::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function Capacitor::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Capacitor::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == NullWeapon) 
		Player::unmountItem(%player,$WeaponSlot);
}

$InvList[Capacitor] = 1; 
$RemoteInvList[Capacitor] = 1;

$ItemMax[harmor, Capacitor] = 1;
$ItemMax[marmor, Capacitor] = 1;
$ItemMax[mfemale, Capacitor] = 1;
$ItemMax[larmor, Capacitor] = 0;
$ItemMax[lfemale, Capacitor] = 0;
$ItemMax[BlastechF, Capacitor] = 0;
$ItemMax[BlastechM, Capacitor] = 0;
$ItemMax[MagIonM, Capacitor] = 1;
$ItemMax[MagIonF, Capacitor] = 1;
$ItemMax[MECH, Capacitor] = 1;

//--------------------------------------------------------------------------------------------------------
// Super Speed Pack 
//--------------------------------------------------------------------------------------------------------

ItemImageData SpeedPackImage
{
	shapeFile = "mortarAmmo";
	weaponType = 2;  // Sustained
	mountRotation = { 0, 0, -1.57 };
	minEnergy = 2;
	maxEnergy = 10;   // Energy/sec for sustained weapons
	sfxFire = SoundUseAmmoStation;
	firstPerson = false;
};

ItemData SpeedPack
{
	description = "SuperSpeed Pack";
	shapeFile = "mortarAmmo";
	className = "Backpack";
   heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = SpeedPackImage;
	price = 500;
	hudIcon = "clock";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpeedPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"SuperSpeed On");
	%armor = Player::getArmor(%player);

	if(!$SpeedPackOn)
	{
		%armor.maxForwardSpeed += 15;
		%armor.maxBackwardSpeed += 10;
		%armor.maxSideSpeed += 8;
		%armor.maxJetForwardVelocity += 8;
		$SpeedPackOn = "True";
	}
}

function SpeedPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"SuperSpeed Off");
	%armor = Player::getArmor(%player);

	if($SpeedPackOn) // So it doesn't screw up by double-negative LOL!!
	{
		%armor.maxForwardSpeed -= 15;
		%armor.maxBackwardSpeed -= 10;
		%armor.maxSideSpeed -= 8;
		%armor.maxJetForwardVelocity -= 8;
		$SpeedPackOn = "False";
	}

	Player::trigger(%player,$BackpackSlot,false);
}

$InvList[SpeedPack] = 1;
$RemoteInvList[SpeedPack] = 1;

$ItemMax[harmor, SpeedPack] = 1;
$ItemMax[marmor, SpeedPack] = 1;
$ItemMax[mfemale, SpeedPack] = 1;
$ItemMax[larmor, SpeedPack] = 0;
$ItemMax[lfemale, SpeedPack] = 0;
$ItemMax[BlastechF, SpeedPack] = 0;
$ItemMax[BlastechM, SpeedPack] = 0;
$ItemMax[MagIonM, SpeedPack] = 1;
$ItemMax[MagIonF, SpeedPack] = 1;
$ItemMax[MECH, SpeedPack] = 1;

//--------------------------------------------------------------------------------------------------------
// PyroXL Conversion Pack - spawned from NT auto-pack maker
//--------------------------------------------------------------------------------------------------------

$InvList[PyroXLPack] = 1;
$RemoteInvList[PyroXLPack] = 0;

$ItemMax[larmor, PyroXLPack] = 0;
$ItemMax[lfemale, PyroXLPack] = 0;
$ItemMax[marmor, PyroXLPack] = 0;
$ItemMax[mfemale, PyroXLPack] = 0;
$ItemMax[harmor, PyroXLPack] = 1;
$ItemMax[BlastechF, PyroXLPack] = 0;
$ItemMax[BlastechM, PyroXLPack] = 0;
$ItemMax[MagIonM, PyroXLPack] = 0;
$ItemMax[MagIonF, PyroXLPack] = 0;
$ItemMax[MECH, PyroXLPack] = 0;

ItemImageData PyroXLPackImage
{
	shapeFile = "flyer";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, 0, 0 };
	mountRotation = { 1.57, 0, 0};
	firstPerson = false;
};

ItemData PyroXLPack
{
	description = "PyroXL Conversion";
	className = "Backpack";
	shapeFile = "flyer";
	hudIcon = "backpack";
	heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = PyroXLPackImage;
	price = 10000;
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PyroXLPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%vel = Item::getVelocity(%player);
	%flag = Player::getMountedItem(%player, $FlagSlot);
	%pos = GameBase::getPosition(%player);
	%team = GameBase::getTeam(%player);
	%rot = GameBase::getRotation(%player);
	%damage = GameBase::getDamageLevel(%player);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);

	%vehicle = newObject("PyroXL",flier,PyroXL,true);	// PyroXL spawn
      %vehicle.clLastMount = %client;	
  	%vehicle.fading = 1;
	%player.driver = 1;		// Ripped from various locations in vehicle.cs...
	%player.vehicle = %vehicle;
	%vehicle.clLastMount = %client;

	addToSet("MissionCleanup", %vehicle);
	GameBase::setMapName(%vehicle,"PyroXL"); 		// Spawn constants
	GameBase::setTeam(%vehicle,%team);
	GameBase::setPosition(%vehicle,%pos);
	GameBase::setRotation(%vehicle,%rot);
	Player::setMountObject(%player, %vehicle, 1);
	Client::setControlObject(%client, %vehicle);
	GameBase::setDamageLevel(%vehicle, %damage);
	bottomprint(%client, "<jc><f1>Converted to <f0>PyroXL<f1>", 5);

	if(%flag == Flag)			// Flag Check (pun ;])
	{
		Player::dropItem(%player, %flag);
		Client::sendMessage(%client, 1, "Warning! PyroXL does not have a flag slot; dropping flag.");
	}

	if(%weapon != -1)			// Weapon Check
	{
		%player.lastWeapon = %weapon;
		Player::unMountItem(%player,$WeaponSlot);
	}
}

function PyroXLPackImage::onDeactivate(%player, %imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
	bottomprint(Player::getClient(%player), "<jc><f1>Conversion to <f0>Bipedal", 5);
}

//--------------------------------------------------------------------------------------------------------
// Jet Pack
//--------------------------------------------------------------------------------------------------------

$Jet::HoverValue = 1.15; // How much vel per 1/100th of a second to keep a player stationary
$Jet::Speed = 15; // How fast does it propel an object in the direction

ItemImageData JetGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.0;
	maxEnergy = 0.5;

	sfxFire     = SoundFlyerActive;
};

ItemData JetGun
{
	description = "Jet Pack";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = JetGunImage;
	showInventory = false;
	price = 0;
};

function JetGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ExplosionData nullExp
{
   shapeName = "breath.dts";

   faceCamera = false;
   randomSpin = false;
   hasLight   = false;
   lightRange = 3.0;

   timeZero = 0.450;
   timeOne  = 0.750;

   colors[0]  = { 0.25, 0.25, 1.0 };
   colors[1]  = { 0.25, 0.25, 1.0 };
   colors[2]  = { 1.0, 1.0,  1.0 };
   radFactors = { 1.0, 1.0,  1.0 };

   shiftPosition = false;
};

GrenadeData PassiveSmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = nullExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 0;
   damageValue        = 0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

GrenadeData ActiveSmoke
{
   bulletShapeName    = "breath.dts";
   explosionTag       = nullExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 0;
   damageValue        = 0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "tumult_small.dts";
};

ItemImageData JetPackImage
{
	shapeFile = "mortargun";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 1;
	maxEnergy = 8.5;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, 0, 0.31 };
  	mountRotation = { 5, 0, 3 };
	firstPerson = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 15;
	lightTime = 2;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFlyerIdle;
};

ItemData JetPack
{
	description = "Jet Pack";
	shapeFile = "mortargun";
	className = "Backpack";
      heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = JetPackImage;
	price = 2000;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JetPack::onUnmount(%player,%item,$BackPackSlot)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == JetGun)
		Player::unmountItem(%player,$WeaponSlot);
}

function JetPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
	{
		Player::trigger(%player,$BackpackSlot,true);
		Player::mountItem(%player,JetGun,$WeaponSlot);
	}
}

function JetPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jetpack On"); // hehe :)
	%player.hasJetpack = true;
	TSR::JetPack(%player);
}

function TSR::JetPack(%player)
{
	if(%player.hasJetpack)	// Keep him there; negate the gravity effect
	{
		if(Player::isTriggered(%player,$WeaponSlot)) // Only if the trigger is on
		{
			if(Player::getMountedItem(%player,$WeaponSlot) == JetGun) // Incoming MATH BLASTER! AAAAAA!!
			{
				%trans = GameBase::getMuzzleTransform(%player);
				%c1 = getWord(getBoxCenter(%player), 0);
				%c2 = getWord(getBoxCenter(%player), 1);
				%c3 = getWord(getBoxCenter(%player), 2) + 0.125;
				%middle = %c1@" "@%c2@" "@%c3;
				%center = "0 0 1 0 0 0 0 0 1 " @ %middle; 
				%rot = GameBase::getRotation(%player);
				%zrot = getWord(%trans,5);
				%kick = Vector::getFromRot(%rot,$Jet::Speed,%zrot*10); // Sensitive :)
				%xkick = getWord(%kick, 0);
				%ykick = getWord(%kick, 1);
				%zkick = getWord(%kick, 2); 

				if(%zkick > 8.75)
					%vel = "0 0 "@%zkick + 5;
				else if(%zkick < -8.75)
					%vel = "0 0 "@%zkick - 5;
				else 
					%vel = %xkick@" "@%ykick@" "@%zkick; // New way of looking at velocity

				Item::setVelocity(%player, %vel);

				if(%player.smokeCount >= 15)
				{
					Projectile::spawnProjectile(PassiveSmoke,%center,%player,%vel);
					Projectile::spawnProjectile(ActiveSmoke,%center,%player,%vel);
					%player.smokeCount = 0;
				}
			}
		}
		else
		{
			Item::setVelocity(%player, "0 0 "@$Jet::HoverValue); // $Jet::HoverValue being the universal constanst taking place from the earlier float pack
			%player.jetActive = false;

			if(%player.smokeCount >= 15)
			{
				Projectile::spawnProjectile(PassiveSmoke,%center,%player,%vel);
				%player.smokeCount = 0;
			}
		}

		%player.smokeCount += 1;
		schedule("TSR::JetPack("@%player@");", 0.01, %player); // Only 100x a second...
	}
}

function JetPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jetpack Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.hasJetpack = false; // Strings in place to keep a const int on pack activation

	if(Player::getMountedItem(%player,$WeaponSlot) == JetGun)
		Player::unmountItem(%player,$WeaponSlot);
}

function JetPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);

		if (%mounted == JetGun)
			Player::unmountItem(%player,$WeaponSlot);
		else
			Player::mountItem(%player,%mounted,$WeaponSlot);

		Item::onDrop(%player,%item);
	}
}

$InvList[JetPack] = 1;
$RemoteInvList[JetPack] = 0;

$ItemMax[larmor, JetPack] = 0;
$ItemMax[lfemale, JetPack] = 0;
$ItemMax[marmor, JetPack] = 0;
$ItemMax[mfemale, JetPack] = 0;
$ItemMax[harmor, JetPack] = 1;
$ItemMax[BlastechF, JetPack] = 0;
$ItemMax[BlastechM, JetPack] = 0;
$ItemMax[MagIonM, JetPack] = 0;
$ItemMax[MagIonF, JetPack] = 0;
$ItemMax[MECH, JetPack] = 1;

