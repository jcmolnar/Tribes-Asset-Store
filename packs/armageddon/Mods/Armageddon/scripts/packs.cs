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
 	maxEnergy = -4;
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
	mass = 1;
	minEnergy = -1;
 	maxEnergy = -20;
	firstPerson = false;
};

ItemData Accelerator
{
	description = "Morpho-Plasmic Gen.";
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

$InvList[GravFieldPack] = 1;
$RemoteInvList[GravFieldPack] = 1;

$ItemMax[harmor, GravFieldPack] = 1;
$ItemMax[marmor, GravFieldPack] = 1;
$ItemMax[mfemale, GravFieldPack] = 1;
$ItemMax[larmor, GravFieldPack] = 0;
$ItemMax[lfemale, GravFieldPack] = 0;
$ItemMax[BlastechF, GravFieldPack] = 0;
$ItemMax[BlastechM, GravFieldPack] = 0;
$ItemMax[MagIonM, GravFieldPack] = 1;
$ItemMax[MagIonF, GravFieldPack] = 1;
$ItemMax[MECH, GravFieldPack] = 1;

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

$InvList[GravFieldPack2] = 1;
$RemoteInvList[GravFieldPack2] = 0;

$ItemMax[harmor, GravFieldPack2] = 1;
$ItemMax[marmor, GravFieldPack2] = 1;
$ItemMax[mfemale, GravFieldPack2] = 1;
$ItemMax[larmor, GravFieldPack2] = 1;
$ItemMax[lfemale, GravFieldPack2] = 1;
$ItemMax[BlastechF, GravFieldPack2] = 1;
$ItemMax[BlastechM, GravFieldPack2] = 1;
$ItemMax[MagIonM, GravFieldPack2] = 1;
$ItemMax[MagIonF, GravFieldPack2] = 1;
$ItemMax[MECH, GravFieldPack2] = 1;



ItemImageData HoverGravImage
{
	shapeFile = "plasmaex";
	weaponType = 2;  // Sustained
	mountPoint = 2;
      mass = -3;
	firstPerson = false;
};

ItemData HoverGrav
{
	description = "You can now HOVER forever.... however heavy weapons and energy based weapons may cause it to shut off";
	shapeFile = "force";
	className = "Backpack";
	heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = HoverGravImage;
	price = 2500;
	hudIcon = "fear";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemImageData GravFieldPackI2
{
	shapeFile = "liqcyl";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, 0, -0.56 };
//	mass = -8;
	minEnergy = 5;
 	maxEnergy = -2;
//	minEnergy = -1;
// 	maxEnergy = -2;
	firstPerson = false;
};

ItemData GravFieldPack2
{
	description = "Quantum Flux Gen.";
	shapeFile = "liqcyl";
	className = "Backpack";
	heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = GravFieldPackI2;
	price = 12500;
	hudIcon = "fear";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GravFieldpack2::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	%playerId = Player::getClient(%player);
      %armor = Player::getArmor(%player);
	 if (%armor == "larmor" ||%armor == "lfemale" ||%armor == "marmor" ||%armor == "mfemale" ||%armor == "BlastechM" ||%armor == "BlastechF" ||%armor == "MagIonF"||%armor == "MagIonM" || %armor == "harmor" || %armor == "MECH")
	{
	      Bottomprint(%client, "<jc><f1>" @ %item.description @ " \n<f0> Provides a <f1>Quantum Flux <f0>which allows you to<f2> Hover <f0>in mid air.", 10);
	}	
	
}

function HoverGrav(%client, %player)
{
	%clientId = Player::getClient(%player);
	%client = Player::getClient(%player);
	if(Player::getMountedItem(%client,$ExtraWeaponSlotC) == HoverGrav)
	{
		Item::setVelocity(%player, "0 0 1.14"); // Gravity "null-zone" is a constant 1.13 - 1.15 vel upwards; keeps you inplace instead of moving you down.
//		Player::applyImpulse(%client, Vector::getFromRot(GameBase::getRotation(%player),0,3.53));
//		%energy = GameBase::getEnergy(%player);
//		%energy -= 0.15;
//		GameBase::setEnergy(%player,%energy); 
		schedule("HoverGrav(" @ %client @ ", " @ %player @ ");",0.01,%player);
	}
	else if(Player::getMountedItem(%client,$ExtraWeaponSlotC) == PartialGrav)
	{
//		%energy = GameBase::getEnergy(%player);
//		%energy += 0.25;
//		GameBase::setEnergy(%player,%energy); 
		Player::setSensorSupression(%player,200);
		schedule("HoverGrav(" @ %client @ ", " @ %player @ ");",0.01,%player);
	}
}

function GravFieldPackI2::onActivate(%player,%imageSlot)
{
	%client = Player::getClient(%player);
	%playerId = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	Player::unmountItem(%player,$ExtraWeaponSlotC);
	Player::setSensorSupression(%player,0);
      	 if (%armor == "larmor" ||%armor == "lfemale" ||%armor == "marmor" ||%armor == "mfemale" ||%armor == "BlastechM" ||%armor == "BlastechF" ||%armor == "MagIonF"||%armor == "MagIonM" || %armor == "harmor" || %armor == "MECH")
	{
		Player::mountItem(%player,HoverGrav,$ExtraWeaponSlotC);
		Client::sendMessage(Player::getClient(%player),3,"Hover ability initiated. ~wmine_act.wav");
		HoverGrav(%client, %player);
	}	
		
}

function GravFieldPackI2::onDeactivate(%player,%imageSlot)
{
	Player::setSensorSupression(%player,0);
	Player::unmountItem(%player,$ExtraWeaponSlotC);
	Client::sendMessage(Player::getClient(%player),1,"Hover ability terminated. ~waccess_denied.wav");
	Player::trigger(%player,$BackpackSlot,false);
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
	maxEnergy = 13;   // Energy/sec for sustained weapons
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
	gameBase::setAutoRepairRate(%player, 0.6);
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
	%player.shieldStrength = 0.025;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}

//----------------------------------------------------------------------------


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

//----------------------------------------------------------------------------

$InvList[AmmoGeneratorPack]			= 1;
$RemoteInvList[AmmoGeneratorPack]		= 1;

$ItemMax[lfemale, AmmoGeneratorPack]	= 0;
$ItemMax[mfemale, AmmoGeneratorPack]	= 0;
$ItemMax[larmor, AmmoGeneratorPack]		= 0;
$ItemMax[marmor, AmmoGeneratorPack]		= 0;
$ItemMax[harmor, AmmoGeneratorPack]		= 1;
$ItemMax[BlastechF, AmmoGeneratorPack] = 0;
$ItemMax[BlastechM, AmmoGeneratorPack] = 0;
$ItemMax[MagIonM, AmmoGeneratorPack] = 0;
$ItemMax[MagIonF, AmmoGeneratorPack] = 0;
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

	if (checkResources(%player,ImpAmmo,1,1) > 0 && Player::getItemCount(%player,ImpGun) == 1) ammogenImage::resupply(%player,"ImpGun",ImpAmmo,1,30);
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
	else if (checkResources(%player,ATCAmmo,1,1) > 0 && Player::getItemCount(%player,ATC) == 1) ammogenImage::resupply(%player,"ATC",ATCAmmo,1,5);	
	else if (checkResources(%player,Darts,1,1) > 0 && Player::getItemCount(%player,DartGun) == 1) ammogenImage::resupply(%player,"DartGun",Darts,1,5);	
	else if (checkResources(%player,Shells,1,1) > 0 && Player::getItemCount(%player,Rifle) == 1) ammogenImage::resupply(%player,"Rifle",Shells,1,5);	
	else if (checkResources(%player,bolts,1,1) > 0 && Player::getItemCount(%player,massdriver) == 1) ammogenImage::resupply(%player,"Massdriver",Bolts,1,5);	
	else if (checkResources(%player,SXAmmo,1,1) > 0 && Player::getItemCount(%player,AAODSniperX) == 1) ammogenImage::resupply(%player,"AAODSniperX",SXAmmo,1,10);	
	else if (checkResources(%player,Beacon,1,1) > 0 && Player::getItemCount(%player,aodbeacongun) == 1) ammogenImage::resupply(%player,"AODBeaconGun",Beacon,1,10);
	
	else if (checkResources(%player,Grenade,1,1) > 0 ) ammogenImage::resupply(%player,"",Grenade,1,25);
	else if (checkResources(%player,MineAmmo,1,1) > 0 ) ammogenImage::resupply(%player,"",MineAmmo,1,25);
	else if (checkResources(%player,Beacon,1,1) > 0 ) ammogenImage::resupply(%player,"",Beacon,1,25);
	else if (checkResources(%player,RepairKit,1,1) > 0 ) ammogenImage::resupply(%player,"",RepairKit,1,20);

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
	        %numAdd = %item.ATCAmmo;
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


//----------------------------------------------------------------------------
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
{	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 0;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData BugPack
{	description		= "ChatTap+SensorJamr"; // NOW you know what it is!
	shapeFile		= "sensorjamPack";
	classname		= "Backpack";
	heading		= "kBackpacks";
	shadowDetailMask  = 4;
	imageType		= BugI;
	price			= 1000;
	hudIcon = "shieldpack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
//	mass			= 0.5;
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
	%rate = Player::getSensorSupression(%player) + 200;
	Player::setSensorSupression(%player,%rate);

        %client = Player::getClient(%player);
      Bottomprint(%client, "<jc><f1>Now you can listen in on the enemy team conversations and those people in Observer.\n<jc>Also acts as a 200 meter Sensor Jammer that is always on.", 10);
}

function BugPack::onUnmount(%player,%item)
{
	%rate = Player::getSensorSupression(%player) - 200;
	Player::setSensorSupression(%player,%rate);
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
        description = "Wormhole Manipulator";
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

function HyperPack::onMount(%player,%item)
{
	
        %client = Player::getClient(%player);
      Bottomprint(%client, "<jc><f1>This is an experimental technology pioneered by the <f2>Delta Corp.<f1> Shifts Dimensional realities.\n<f0>This pack has been known to malfunction and send people to hell.", 10);
}

function HyperPackImage::onActivate(%player,%imageSlot)
{
	%energy = GameBase::getEnergy(%player);
	%rnd = floor(getRandom() * 100);
	%pos2 = Vector::add(GameBase::getPosition(%player), "-5000 -5000 -5000");
	%cl = Player::getClient(%player);
	if(%energy > 30)
	{
		%client = Player::getClient(%player);
		%pos = GameBase::getPosition(%player);

		if(GameBase::getLOSInfo(%player, 302))
		{
			%object = getObjectType($los::object);
			
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
			if(%object == "StaticShape")
			{
			Bottomprint(%client, "<jc><f1>Naughty... Naughty....Cannot HyperDrive through this shape.");
			playSound(SoundSDCCharge,%pos);
		      Player::trigger(%player,$BackPackSlot,false);
			return false;
		      }
			if(%rnd > 15)
			{
	
			Player::setDamageFlash(%player,999);
			GameBase::setPosition(%player,$los::position);
			GameBase::startFadeIn(%player,$los::position);
			playSound(ForceFieldOpen,$los::position);
			useEnergy(%player,50);
			Player::trigger(%player,$BackPackSlot,false);
			}
			else
			{
			echo(Client::getName(%cl) @ " was sent to hell by hyperdrive");
			Player::setDamageFlash(%player,999);
			GameBase::setPosition(%player,%pos2);
			GameBase::startFadeIn(%player,%pos2);
			playSound(ForceFieldOpen, %pos2);
			useEnergy(%player,50);
			Player::trigger(%player,$BackPackSlot,false);
			centerprint(%cl, "<jc><f1>It looks like you were sent to <f0>! _-=**HELL**=-_ !\n<f2> YOU WERE WARNED OF THE DANGERS OF THIS EXPERIMENTAL TECHNOLOGY");
			BurnTheFlesh(%cl, %player);
			}

		  }      
		else
		{
		
		        Bottomprint(%client, "<jc>HyperDrive Destination out of range - get within 300m.");
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
// Leech Pack 
//--------------------------------------------------------------------------------------------------------
$Xi::LeechFieldSize = 45;
ItemImageData LeechPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = -1;
	maxEnergy = 10;   // Energy/sec for sustained weapons
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
	Client::sendMessage(Player::getClient(%player),1,"Leech Field On ~wshieldhit.wav");
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
			%armor = Player::getArmor(%player);
			%playerId = Player::getClient(%player);
			if (%armor == "larmor" || %armor == "lfemale")
			{
				$Xi::LeechFieldSize = 45; 	// How big the Leech field is for each player.
			}
			else if (%armor == "BlastechM" || %armor == "BlastechF")
			{
				$Xi::LeechFieldSize = 25; 	// How big the Leech field is for each player.
			}
			else if (%armor == "MagIonM" || %armor == "MagIonF")
			{
				$Xi::LeechFieldSize = 35; 	// How big the Leech field is for each player.
			}
			else if (%armor == "marmor" || %armor == "mfemale")
			{
				$Xi::LeechFieldSize = 50; 	// How big the Leech field is for each player.
			}
			else if(%armor == "MECH")
			{
				$Xi::LeechFieldSize = 30; 	// How big the Leech field is for each player.
			}
			else if(%armor == "harmor")
			{
				$Xi::LeechFieldSize = 40; 	// How big the Leech field is for each player.
			}

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
						%pos = GameBase::getPosition(%tgt);//was missing the % on tgt
						GameBase::applyDamage(%tgt,$TractorDamageType,0.0025,%pos,"0 0 0","0 0 0",%player);

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
	Client::sendMessage(Player::getClient(%player),1,"Leech Field Off ~wshieldhit.wav");
	Player::trigger(%player,$BackpackSlot,false);
}

$InvList[LeechPack] = 1;
$RemoteInvList[LeechPack] = 1;

$ItemMax[harmor, LeechPack] = 1;
$ItemMax[marmor, LeechPack] = 1;
$ItemMax[mfemale, LeechPack] = 1;
$ItemMax[larmor, LeechPack] = 1; 
$ItemMax[lfemale, LeechPack] = 1;
$ItemMax[BlastechF, LeechPack] = 1;
$ItemMax[BlastechM, LeechPack] = 1;
$ItemMax[MagIonM, LeechPack] = 1;
$ItemMax[MagIonF, LeechPack] = 1;
$ItemMax[MECH, LeechPack] = 1;

