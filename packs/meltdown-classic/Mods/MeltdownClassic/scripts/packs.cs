//----------------------------------------------------------------------------
ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -6;
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
$ItemMax[larmor, Accelerator] = 0;
$ItemMax[lfemale, Accelerator] = 0;
$ItemMax[BlastechF, Accelerator] = 0;
$ItemMax[BlastechM, Accelerator] = 0;
$ItemMax[MagIonM, Accelerator] = 0;
$ItemMax[MagIonF, Accelerator] = 0;
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

$InvList[Reactor] = 1;
$RemoteInvList[Reactor] = 1;

$ItemMax[harmor, Reactor] = 1;
$ItemMax[marmor, Reactor] = 0;
$ItemMax[mfemale, Reactor] = 0;
$ItemMax[larmor, Reactor] = 0;
$ItemMax[lfemale, Reactor] = 0;
$ItemMax[MECH, Reactor] = 1;
$ItemMax[MagIonM, Reactor] = 0;
$ItemMax[MagIonF, Reactor] = 0;
$ItemMax[BlastechM, Reactor] = 0;
$ItemMax[BlastechF, Reactor] = 0;

ItemImageData ReactorImage
{
	shapeFile = "generator_p";
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
	shapeFile = "mortarpack";
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

//****************************************************
// AAOD Mod BACKPACK Kit
//************************************
//----------------------------------------------------------------------------
// ====================================
//		**** SuperRepair Pack ****
// ++++++++++++++++++++++++++++++++++++
//	Useable Only By Heavies....
//	Repairs Items Very Fast
//	Occupies 2 Slots BackPack & Flag
//	Can only Be unmounted At Inventory Station
//	Has 4 x The Range of normal repair bolts
//	Has 2 x the repair speed of normal Packs
//	Uses 11/3 the energy

$InvList[AODSuperRPack]				= 1;
$RemoteInvList[AODSuperRPack]		= 1;

$ItemMax[larmor, AODSuperRPack] = 0;
$ItemMax[lfemale, AODSuperRPack] = 0;
$ItemMax[marmor, AODSuperRPack] = 0;
$ItemMax[mfemale, AODSuperRPack] = 0;
$ItemMax[harmor, AODSuperRPack] = 0;
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
{	shapeFile		= "armorPack";
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

// ====================================
//		**** AAOD Combo Pack1  ****
// ++++++++++++++++++++++++++++++++++++
//	Useable Only By Medium & Heavies....
//	Combo ShieldPack/EnergyPack


$InvList[AODCombo1Pack]				= 1;
$RemoteInvList[AODCombo1Pack]		= 1;

$ItemMax[larmor, AODCombo1Pack]			= 0;
$ItemMax[lfemale, AODCombo1Pack]		= 0;
$ItemMax[marmor, AODCombo1Pack]			= 1;
$ItemMax[mfemale, AODCombo1Pack]		= 1;
$ItemMax[harmor, AODCombo1Pack]			= 1;
$ItemMax[BlastechF, AODCombo1Pack] = 0;
$ItemMax[BlastechM, AODCombo1Pack] = 0;
$ItemMax[MagIonM, AODCombo1Pack] = 0;
$ItemMax[MagIonF, AODCombo1Pack] = 0;
$ItemMax[MECH, AODCombo1Pack] = 1;

//----------------------------------------------------------------------------
ItemImageData Combo1PackImage
{	shapeFile		= "shieldPack";
	mountOffset		= { 0, 0, 0.12 };
	mountRotation	= { 0 ,0 , 0};
	mountPoint		= 2;
	weaponType		= 2;  // Sustained
	minEnergy		= 4;
	maxEnergy		= 9;   // Energy/sec for sustained weapons
	sfxFire			= SoundShieldOn;
	firstPerson		= false;
};

ItemData AODCombo1Pack
{	description		= "Energy + Shield Pack";
	shapeFile		= "shieldPack";
	className		= "Backpack";
	heading			= "kBackpacks";
	shadowDetailMask = 4;
	imageType		= Combo1PackImage;
	price			= 650;
	hudIcon			= "shieldpack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

ItemImageData Combo1APackImage
{	shapeFile		= "jetPack";
	weaponType		= 2;  // Sustained
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, -0.15 };
	minEnergy		= -1;
 	maxEnergy		= -3.5;
	firstPerson		= false;
	Mass			= 1.5;
};

ItemData Combo1APack
{	description		= "COMBO 1 Energy/Shield Pack";
	shapeFile		= "jetPack";
	className		= "Backpack";
	heading			= "cBackpacks";
	shadowDetailMask = 4;
	imageType		= Combo1APackImage;
	price			= 650;
	hudIcon			= "energypack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODCombo1Pack::onMount(%player,%item)
{	
	Player::mountItem(%player,Combo1APack,$FlagSlot);
	Player::trigger(%player,$FlagSlot,true);
}

function AODCombo1Pack::onUnmount(%player,%item)
{	Player::UnmountItem(%player,$FlagSlot);
}

function Combo1PackImage::onActivate(%player,%imageSlot)
{	echo("AOD Combo1 Pack on Activate");
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	Player::trigger(%player,$BackPackSlot,true);
	%player.shieldStrength = 0.012;
}

function Combo1PackImage::onDeactivate(%player,%imageSlot)
{	echo("AOD Combo1 Pack on DeActivate");
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackPackSlot,false);
	%player.shieldStrength = 0;
}

function AODCombo1Pack::onDrop(%player,%item)
{	%client = Player::getClient(%player);
	Client::SendMessage(%client,0,"Unable to DROP this type of Pack. Must BE Sold at an Inventory Station~WAAODSFX14.WAV");
}	

//**************************************
//	End Combo Pack Scripts
//**************************************

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
// Cloaking Device - 
//----------------------------------------------------------------------------

$InvList[CloakingDevice] = 1;
$RemoteInvList[CloakingDevice] = 1;

$ItemMax[harmor, CloakingDevice] = 0;
$ItemMax[marmor, CloakingDevice] = 1;
$ItemMax[mfemale, CloakingDevice] = 1;
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
	maxEnergy = 10;  // Energy used/sec for sustained weapons
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
	GameBase::playSound(%player,ForceFieldOpen,0);
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

$ItemMax[lfemale, AmmoGeneratorPack]	= 1;
$ItemMax[mfemale, AmmoGeneratorPack]	= 1;
$ItemMax[larmor, AmmoGeneratorPack]		= 1;
$ItemMax[marmor, AmmoGeneratorPack]		= 1;
$ItemMax[harmor, AmmoGeneratorPack]		= 1;
$ItemMax[BlastechF, AmmoGeneratorPack] = 1;
$ItemMax[BlastechM, AmmoGeneratorPack] = 1;
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
	minEnergy = 2.5;
	maxEnergy = 5;   // Energy/sec for sustained weapons
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

	if (checkResources(%player,BulletAmmo,1,1) > 0 && Player::getItemCount(%player,Chaingun) == 1) ammogenImage::resupply(%player,"ChainGun",BulletAmmo,1,0.5);
	else if (checkResources(%player,PlasmaAmmo,1,1) > 0 && Player::getItemCount(%player,PlasmaGun) == 1) ammogenImage::resupply(%player,"PlasmaGun",PlasmaAmmo,1,2);
	else if (checkResources(%player,DiscAmmo,1,1) > 0 && Player::getItemCount(%player,DiscLauncher) == 1) ammogenImage::resupply(%player,"DiscLauncher",DiscAmmo,1,2);
	else if (checkResources(%player,GrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,GrenadeLauncher) == 1) ammogenImage::resupply(%player,"GrenadeLauncher",GrenadeAmmo,1,2);
	else if (checkResources(%player,ImpactAmmo,1,1) > 0 && Player::getItemCount(%player,ImpactMortar) == 1) ammogenImage::resupply(%player,"ImpactMortar",ImpactAmmo,1,5);
	else if (checkResources(%player,MortarAmmo,1,1) > 0 && Player::getItemCount(%player,Mortar) == 1) ammogenImage::resupply(%player,"Mortar",MortarAmmo,1,5);
	else if (checkResources(%player,dualdiscs,1,1) > 0 && Player::getItemCount(%player,HDiscLauncher) == 1) ammogenImage::resupply(%player,"HDiscLauncher",dualdiscs,1,1);
	else if (checkResources(%player,gatlingammo,1,1) > 0 && Player::getItemCount(%player,HChaingun) == 1) ammogenImage::resupply(%player,"HChaingun",gatlingammo,1,0.5);
	else if (checkResources(%player,EMPGrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,EMPGrenadeLauncher) == 1) ammogenImage::resupply(%player,"EMPGrenadeLauncher",EMPGrenadeAmmo,1,5);
	else if (checkResources(%player,MissileAmmo,1,1) > 0 && Player::getItemCount(%player,AODStinger) == 1) ammogenImage::resupply(%player,"AODStinger",MissileAmmo,1,2);
	else if (checkResources(%player,MinigunAmmo,1,1) > 0 && Player::getItemCount(%player,Minigun) == 1) ammogenImage::resupply(%player,"Minigun",MinigunAmmo,1,0.25);
	else if (checkResources(%player,MMinigunAmmo,1,1) > 0 && Player::getItemCount(%player,MMinigun) == 1) ammogenImage::resupply(%player,"MMinigun",MMinigunAmmo,1,0.1);
	else if (checkResources(%player,GrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,RPGLauncher) == 1) ammogenImage::resupply(%player,"RPGLauncher",GrenadeAmmo,1,2);
	else if (checkResources(%player,MortarAmmo,1,1) > 0 && Player::getItemCount(%player,RPMLauncher) == 1) ammogenImage::resupply(%player,"RPMLauncher",MortarAmmo,1,5);
	else if (checkResources(%player,EMPGrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,RPEMPLauncher) == 1) ammogenImage::resupply(%player,"RPEMPLauncher",EMPGrenadeAmmo,1,5);
	else if (checkResources(%player,MissileAmmo,1,1) > 0 && Player::getItemCount(%player,MechRocketLauncher) == 1) ammogenImage::resupply(%player,"MechRocketLauncher",MissileAmmo,1,2);
	else if (checkResources(%player,MRPGAmmo,1,1) > 0 && Player::getItemCount(%player,MRPGLauncher) == 1) ammogenImage::resupply(%player,"MRPGLauncher",MRPGAmmo,1,1);
	else if (checkResources(%player,GaussAmmo,1,1) > 0 && Player::getItemCount(%player,Gauss) == 1) ammogenImage::resupply(%player,"Gauss",GaussAmmo,1,1);
	else if (checkResources(%player,MultiMineAmmo,1,1) > 0 && Player::getItemCount(%player,MineLauncher) == 1) ammogenImage::resupply(%player,"MineLauncher",MultiMineAmmo,1,5);	
	else if (checkResources(%player,Darts,1,1) > 0 && Player::getItemCount(%player,DartGun) == 1) ammogenImage::resupply(%player,"DartGun",Darts,1,2);	
	else if (checkResources(%player,Shells,1,1) > 0 && Player::getItemCount(%player,Rifle) == 1) ammogenImage::resupply(%player,"Shells",Rifle,1,2);	
	else if (checkResources(%player,bolts,1,1) > 0 && Player::getItemCount(%player,massdriver) == 1) ammogenImage::resupply(%player,"massdriver",bolts,1,2);	
	else if (checkResources(%player,Shells,1,1) > 0 && Player::getItemCount(%player,shotgun) == 1) ammogenImage::resupply(%player,"Shotgun",Shells,1,2);	
	else if (checkResources(%player,beaconammo,1,1) > 0 && Player::getItemCount(%player,aodbeacongun) == 1) ammogenImage::resupply(%player,"aodbeacongun",beaconammo,1,2);	
	else if (checkResources(%player,StubberShells,1,1) > 0 && Player::getItemCount(%player,Stubber) == 1) ammogenImage::resupply(%player,"Stubber",StubberShells,10,1);	
	else if (checkResources(%player,beacon,1,1) > 0 && Player::getItemCount(%player,aodbeacongun) == 1) ammogenImage::resupply(%player,"aodbeacongun",beacon,1,10);
	else if (checkResources(%player,JugAmmo,1,1) > 0 && Player::getItemCount(%player,JugLauncher) == 1) ammogenImage::resupply(%player,"JugLauncher",JugAmmo,1,1);
	else if (checkResources(%player,ImpAmmo,1,1) > 0 && Player::getItemCount(%player,ImpGun) == 1) ammogenImage::resupply(%player,"ImpGun",ImpAmmo,1,2);

	else if (checkResources(%player,Grenade,1,1) > 0 ) ammogenImage::resupply(%player,"",Grenade,1,2);
	else if (checkResources(%player,MineAmmo,1,1) > 0 ) ammogenImage::resupply(%player,"",MineAmmo,1,2);
	else if (checkResources(%player,Beacon,1,1) > 0 ) ammogenImage::resupply(%player,"",Beacon,1,10);
	else if (checkResources(%player,RepairKit,1,1) > 0 ) ammogenImage::resupply(%player,"",RepairKit,1,100);

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

$InvList[TargPack]				= 1;
$RemoteInvList[TargPack]		= 1;

$ItemMax[lfemale, TargPack]	= 1;
$ItemMax[mfemale, TargPack]	= 1;
$ItemMax[larmor, TargPack]		= 1;
$ItemMax[marmor, TargPack]		= 1;
$ItemMax[harmor, TargPack]		= 1;
$ItemMax[BlastechF, TargPack] = 1;
$ItemMax[BlastechM, TargPack] = 1;
$ItemMax[MagIonM, TargPack] = 1;
$ItemMax[MagIonF, TargPack] = 1;
$ItemMax[MECH, TargPack] = 1;

ItemImageData AODATPackImage
{	shapeFile		= "radar_small";
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, 0 };
	minEnergy		= 1;
 	maxEnergy		= 3;
	firstPerson		= false;
	mass			= 0.5;
};

ItemData TargPack
{	description		= "Missile Targeting Pack";
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
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);}
}

function TargPack::onMount(%player,%item)
{	Player::trigger(%player,$BackpackSlot,true);
	#Oh look at me! I'm a special missile Targeting pack!
	#and you can't debo me! hahahahahahahahahaahahahhaah
	#Wanna know why? cause the mod is copyrighted! haha
	#and this even makes discs act like a rocket turret missile!
	#HAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA
}

function TargPack::onUnmount(%player,%item)
{
}

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
$ItemMax[MECH, BugPack] 	= 0;

ItemImageData BugI
{	shapeFile		= "remoteturret";
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, 0 };
	firstPerson		= false;
	mass			= 0.5;
};

ItemData BugPack
{	description		= "Coyote Ear";
	shapeFile		= "remoteturret";
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
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);}
}

function BugPack::onMount(%player,%item)
{	Player::trigger(%player,$BackpackSlot,true);
	#Oh look at me! I'm a special Coyote ear!!
	#and you can't debo me! hahahahahahahahahaahahahhaah
	#Wanna know why? cause the mod is copyrighted! haha
	#and this even lets you listen to enemy comm signals!!
	#HAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHAHA
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
//	showinventory="false";
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
			Client::sendMessage(Player::getClient(%player),1,"I'm not that stupid FOOL! Move that waypoint AWAY from your flag!!");
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
	if(%armor==harmor) %mass =18;
	if(%armor==BlastechM) %mass =0;
	if(%armor==BlastechF) %mass =0;
	if(%armor==MagIonM) %mass =0;
	if(%armor==MagIonF) %mass =0;
	if(%armor==MECH) %mass =36;

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

ItemImageData JumpGunImage
{
	shapeFile = "smoke";
	mountPoint = 0;

	weaponType = 0; // Sustained
	mountOffset = { 0, 0, -50 };
	mountRotation = { 0, 0, 0 };
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 0.0;

	sfxFire     = bigExplosion1;
	sfxActivate = SoundSwarmAcquire;
};

function JumpGunImage::onFire(%player, %slot)
{
	%client = Player::getclient(%player);

	%vel = $OOPVel[%client];
	%vec = $OOPVec[%client];
	
	%rot = GameBase::getRotation(%player);
	%jump = Vector::getFromRot(%rot,%vel,%vec);
	Player::applyImpulse(%player,%jump);
	GameBase::setEnergy(%player,0);

	JumpGunEmitFire(%player,0,Large);
	JumpGunEmitFire(%player,-3,Large);
	JumpGunEmitFire(%player,-5,Large);

	schedule("JumpGunEmitFire(" @ %player @ ",-5,Huge);",0.0,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Huge);",0.05,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Huge);",0.1,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-3,Huge);",0.15,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.2,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-3,Large);",0.25,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Huge);",0.3,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Huge);",0.35,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.4,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Huge);",0.5,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.55,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.6,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Huge);",0.65,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.7,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.75,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.8,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.85,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.9,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.95,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.0,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-5,Large);",2.1,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.05,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.1,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-3,Large);",1.15,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.2,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-3,Large);",1.25,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.3,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.35,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.4,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.5,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.55,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.6,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.65,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.7,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",1.75,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",1.8,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.85,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.9,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",1.95,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",2.0,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-5,Mini);",3.1,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",2.05,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",2.1,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-3,Large);",2.15,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.2,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-3,Small);",2.25,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",2.3,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",2.35,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.4,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.5,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.55,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",2.6,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",2.65,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.7,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.75,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.8,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Mini);",2.85,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.9,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.95,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Mini);",3.0,%player);
}

ItemData JumpGun
{
	description = "Jump Shot";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = JumpGunImage;
	showInventory = false;
	price = 125;
};

function JumpGun::onMount(%player,%imageSlot)
{
	%client = Player::getclient(%player);

	if($OOPVel[%client] == "")
		$OOPVel[%client] = 400;

if($OOPVec[%client] == "")
		$OOPVec[%client] = 900;

      Bottomprint(%client, "<jc><f3>Jump pack ready--Fire to Jump");
}

function JumpGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

$InvList[JumpPack] = 1;
$RemoteInvList[JumpPack] = 1;

$ItemMax[harmor, JumpPack] = 1;
$ItemMax[marmor, JumpPack] = 0;
$ItemMax[larmor, JumpPack] = 0;
$ItemMax[lfemale, JumpPack] = 0;
$ItemMax[mfemale, JumpPack] = 0;
$ItemMax[BlastechF, JumpPack] = 0;
$ItemMax[BlastechM, JumpPack] = 0;
$ItemMax[MagIonM, JumpPack] = 0;
$ItemMax[MagIonF, JumpPack] = 0;
$ItemMax[MECH, JumpPack] = 1;

ItemImageData JumpPackImage
{
	shapeFile = "jetpack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0.31 };
  	mountRotation = { 5, 0, 3 };
	firstPerson = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 15;
	lightTime = 2;
	lightColor = { 1, 1, 0.2 };
};

ItemData JumpPack
{
	description = "Jump Pack";
	shapeFile = "mortargun";
	className = "Backpack";
      heading = "kBackpacks";
	shadowDetailMask = 4;
	imageType = JumpPackImage;
	price = 475;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemImageData ExtraJumpPackImage
{
	shapeFile = "mortargun";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;

	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { -0.15, -0.05, 0 };
  	mountRotation = { 5, 0, 3 };
	firstPerson = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 15;
	lightTime = 2;
	lightColor = { 1, 1, 0.2 };
};

ItemData ExtraJumpPack
{
	description = "Jump Pack";
	shapeFile = "mortargun";
	className = "Backpack";
      heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ExtraJumpPackImage;
	price = 475;
	hudIcon = "sensorjamerpack";
	showWeaponBar = false;
	hiliteOnActive = true;
};

ItemImageData EnergyJumpPackImage
{
	shapeFile = "mortargun";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0.15, -0.05, 0.0 };
  	mountRotation = { 5, 0, 3 };
	firstPerson = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 15;
	lightTime = 2;
	lightColor = { 1, 1, 0.2 };
};

ItemData EnergyJumpPack
{
	description = "Jump Pack";
	shapeFile = "mortargun";
	className = "Backpack";
      heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyJumpPackImage;
	price = 475;
	hudIcon = "sensorjamerpack";
	showWeaponBar = false;
	hiliteOnActive = true;
};

function JumpPack::onMount(%player,%item,$BackPackSlot)
{
	%client = Player::getclient(%player);
	Player::mountItem(%player,ExtraJumpPack,$ExtraWeaponSlotA);
	Player::mountItem(%player,EnergyJumpPack,$ExtraWeaponSlotB);
}

function JumpPack::onUnmount(%player,%item,$BackPackSlot)
{
	Player::unmountItem(%player,$ExtraWeaponSlotA);
	Player::unmountItem(%player,$ExtraWeaponSlotB);
	if (Player::getMountedItem(%player,$WeaponSlot) == JumpGun)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function JumpPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::trigger(%player,$BackpackSlot,true);
		Player::mountItem(%player,JumpGun,$WeaponSlot);
	}
}

function JumpPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == JumpGun)
		{
			Player::unmountItem(%player,$WeaponSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}

function JumpGunEmitFire(%player,%distance,%type)
{
	if(%type == Small)
		%obj = newObject("","Mine","Exhaust");
	if(%type == Huge)
		%obj = newObject("","Mine","ExhaustHuge");
	if(%type == Mini)
		%obj = newObject("","Mine","ExhaustMini");
	if(%type == Large)
		%obj = newObject("","Mine","ExhaustBig");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,%distance,true);
	GameBase::setTeam (%obj,GameBase::getTeam(%player));
}

MineData Exhaust
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Jump Pack";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = fire1Exp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $ExhaustDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Exhaust::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData ExhaustMini
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Jump Pack";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = fire2Exp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $ExhaustDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function ExhaustMini::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData ExhaustBig
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Jump Pack";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = fireExp;
	explosionRadius = 12.0;
	damageValue = 0.0;
	damageType = $MortarDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function ExhaustBig::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData ExhaustHuge
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Jump Pack";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = fire3Exp;
	explosionRadius = 12.0;
	damageValue = 0.0;
	damageType = $MortarDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function ExhaustHuge::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//=========================================================================

$TeamItemMax[JetfirePack] = 99999999; 

$TeamItemCount[0 @ JetfirePack] = 0;
$TeamItemCount[1 @ JetfirePack] = 0;
$TeamItemCount[2 @ JetfirePack] = 0;
$TeamItemCount[3 @ JetfirePack] = 0;

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

