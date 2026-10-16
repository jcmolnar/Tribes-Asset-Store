//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::trigger(%player,$BackpackSlot);
}




//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Energy Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData EnergyPackImage
{
   shapeFile = "jetPack";
   weaponType = 2;  // Sustained
   mountPoint = 2;
   mountOffset = { 0, -0.1, 0 };
   minEnergy = -3;//1
   maxEnergy = -5;//3
   firstPerson = false;
};

ItemData EnergyPack
{
   description = "Energy Pack";
   shapeFile = "jetPack";
   className = "Backpack";
   heading = "fBackpacks";
   shadowDetailMask = 4;
   imageType = EnergyPackImage;
   price = 150;
   hudIcon = "energypack";
   showWeaponBar = true;
   hiliteOnActive = true;
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
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


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Repair Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   heading = "fBackpacks";
   shadowDetailMask = 4;
   imageType = RepairPackImage;
   price = 125;
   hudIcon = "repairpack";
   showWeaponBar = true;
   hiliteOnActive = true;
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) 
		Player::unmountItem(%player,$WeaponSlot);
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::mountItem(%player,RepairGun,$WeaponSlot);
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



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Shield Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   heading = "fBackpacks";
   shadowDetailMask = 4;
   imageType = ShieldPackImage;
   price = 175;
   hudIcon = "shieldpack";
   showWeaponBar = true;
   hiliteOnActive = true;
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
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



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Sensor Jammer Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   heading = "fBackpacks";
   shadowDetailMask = 4;
   imageType = SensorJammerPackImage;
   price = 200;
   hudIcon = "sensorjamerpack";
   showWeaponBar = true;
   hiliteOnActive = true;
   validateShape = $Nappy::validate;
   validateMaterials = $Nappy::validate;
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

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Gas Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData GasPackImage 
{ 
   shapeFile = "mortarammo"; 
   mountPoint = 2; 
   mountOffset = { 0, -0.12, 0 }; 
   mountRotation = { 0, 0, -1.59 }; 
   mass = 1.5; 
   firstPerson = false; 
}; 

ItemData GasPack 
{ 
   description = "Gas Pack"; 
   shapeFile = "mortarammo"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
   shadowDetailMask = 4; 
   imageType = GasPackImage; 
   price = 69; 
   hudIcon = "shieldpack"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function GasPack::onUnmount(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$WeaponSlot) == Flamer) 
		Player::unmountItem(%player,$WeaponSlot); 
	Player::setItemCount(%player, FlamerAmmo, 0); 
} 

function GasPack::onDrop(%player, %item) 
{ 
	if($matchStarted) { 
		%item = Item::onDrop(%player,%item); 
		%numPack = 0; 
		%ammoItem = FlamerAmmo; 
		%maxnum = 0; 
		%pCount = Player::getItemCount(%player, %ammoItem);  
		%numPack = %pCount - %maxnum; 
		Player::decItemCount(%player,%ammoItem,%numPack); 
		%item.FlamerAmmo = %numPack;
	}
}  

function GasPack::onCollision(%this,%object) 
{ 
	if (getObjectType(%object) == "Player") { 
		%item = Item::getItemData(%this); 
		%count = Player::getItemCount(%object,%item); 
		if (Item::giveItem(%object,%item,Item::getCount(%this))) { 
			Item::playPickupSound(%this); 
			checkGasAmmo(%object, %this); 
			Item::respawn(%this); 
		} 
	} 
} 

function checkGasAmmo(%player, %item) 
{ 
	%ammoItem = FlamerAmmo; 
	%numAdd = %item.FlamerAmmo;  
	Player::incItemCount(%player,%ammoItem,%numAdd); 
} 

function fillGasPack(%client) 
{ 
	%player = Client::getOwnedObject(%client); 
	%item = FlamerAmmo; 
	%maxnum = 400; 
	%count = Player::getItemCount(%player,%item); 	
	%fill = %maxnum - %count; 
	Player::incItemCount(%client,%item,%fill); 
	teamEnergyBuySell(%player,%item.price * %fill * -1); 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Cloaking Device
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData CloakingDeviceImage 
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

ItemData CloakingDevice 
{ 
   description = "Cloaking Device"; 
   shapeFile = "sensorjampack"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
   shadowDetailMask = 4; 
   imageType = CloakingDeviceimage; 
   price = 600; 
   hudIcon = "sensorjamerpack"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function CloakingDeviceImage::onActivate(%player,%imageSlot) 
{ 
	GameBase::startFadeout(%player); 
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On"); 
	%rate = Player::getSensorSupression(%player) + 5; 
	Player::setSensorSupression(%player,%rate); 
	%player.guiLock = true; 
	%c = Player::getClient(%player); 
	%c.guiLock = true; 
	%clientId.ghostDoneFlag = true; 
	startGhosting(%cl); 
} 

function CloakingDeviceImage::onDeactivate(%player,%imageSlot) 
{ 
	GameBase::startFadein(%player); 
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off"); 
	%rate = Player::getSensorSupression(%player) - 5; 
	Player::setSensorSupression(%player,%rate); 
	Player::trigger(%player,$BackpackSlot,false); 
	%player.guiLock = ""; 
	%c = Player::getClient(%player); 
	%c.guiLock = ""; 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              StealthShield Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData StealthShieldPackImage 
{ 
   shapeFile = "shieldPack"; 
   mountPoint = 2; 
   weaponType = 2; 
   minEnergy = 6; 
   maxEnergy = 9; 
   sfxFire = SoundShieldOn; 
   firstPerson = false; 
}; 

ItemData StealthShieldPack 
{ 
   description = "StealthShield Pack"; 
   shapeFile = "shieldPack"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
   shadowDetailMask = 4; 
   imageType = StealthShieldPackImage; 
   price = 275; 
   hudIcon = "shieldpack"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function StealthShieldPackImage::onActivate(%player,%imageSlot) 
{ 
	Client::sendMessage(Player::getClient(%player),0,"StealthShield On"); 
	%player.shieldStrength = 0.012; 
	%rate = Player::getSensorSupression(%player) + 20; 
	Player::setSensorSupression(%player,%rate); 
} 

function StealthShieldPackImage::onDeactivate(%player,%imageSlot) 
{ 
	Client::sendMessage(Player::getClient(%player),0,"StealthShield Off"); 
	Player::trigger(%player,$BackpackSlot,false); 
	%player.shieldStrength = 0; 
	%rate = Player::getSensorSupression(%player) - 20; 
	Player::setSensorSupression(%player,%rate); 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Regeneration Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData RegenerationPackImage 
{ 
   shapeFile = "shieldPack"; 
   mountPoint = 2; 
   weaponType = 2; 
   minEnergy = 8; 
   maxEnergy = 14; 
   sfxFire = SoundRepairItem; 
   projectileType = AutoBolt; 
}; 

ItemData RegenerationPack 
{ 
   description = "Regeneration Pack"; 
   shapeFile = "shieldPack"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
   shadowDetailMask = 4; 
   imageType = RegenerationPackImage; 
   price = 275; 
   hudIcon = "shieldpack"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function RegenerationPackImage::onActivate(%player,%imageSlot) 
{ 
	%clientId = Player::getClient(%player); 
} 

function RegenerationPackImage::onDeactivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,false); 
} 

function TransferHealth(%clientId, %player) 
{ 
	Client::sendMessage(%clientId,1,"Regeneration On"); 
	Player::unmountItem(%player,$WeaponSlot); 
	if($regTime[%clientId] == 0) { 
		GameBase::setEnergy(%player,0); 
		GameBase::setRechargeRate(%player,0); 
		$regTime[%clientId] = 10; 
		checkPlayerDrain(%clientId, %player); 
	} 
	else 
	$regTime[%clientId] = 10; 
} 

function checkPlayerDrain(%clientId, %player) 
{ 
	if($regTime[%clientId] > 0) { 
		$regTime[%clientId] -= 2; 
		if(GameBase::getDamageLevel(%player)) { 
			GameBase::repairDamage(%player,0.05); 
			GameBase::playSound(%player,ForceFieldOpen,0); 
		} 
		schedule("checkPlayerDrain(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} 
	else { 
		Client::sendMessage(%clientId,1,"Regeneration Off"); 
		GameBase::setRechargeRate(%player,8); 
	} 
} 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Lightning Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   description = "Lightning Pack"; 
   shapeFile = "shieldPack"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
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
	Player::trigger(%player,$BackpackSlot,false); 
} 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Cybernetic Laser
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData OpticPackImage 
{ 
   shapeFile = "repairgun"; 
   mountPoint = 2; 
   mountOffset = { 0.2, 0.4, 0.45 }; 
   mountRotation = { 0, 0, 0 }; 
   weaponType = 0; 
   projectileType = SniperLaser; 
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

ItemData OpticPack 
{ 
   description = "Cybernetic Laser"; 
   shapeFile = "repairgun"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
   shadowDetailMask = 4; 
   imageType = OpticPackImage; 
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

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Auto-Rocket Cannon
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemData MissileAmmo 
{ 
   description = "Missiles"; 
   className = "Ammo"; 
   heading = "zAmmunition"; 
   shapeFile = "ammo1"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData SMRPackImage 
{ 
   shapeFile = "mortargun"; 
   mountPoint = 2; 
   mountOffset = { -0.4, 0.1, 0.4 }; 
   mountRotation = { 0.2, 0, 0 }; 
   weaponType = 0; 
   ammoType = MissileAmmo; 
   projectileType = StingerMissile; 
   accuFire = true; 
   reloadTime = 5.0; 
   fireTime = 0.0; 
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 1; 
   lightColor = { 0.6, 1, 1.0 }; 
   sfxFire = SoundMissileTurretFire; 
   sfxReload = SoundMortarReload; 
}; 

ItemData SMRPack 
{ 
   description = "Auto-Rocket Cannon"; 
   shapeFile = "mortargun"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
   shadowDetailMask = 4; 
   imageType = SMRPackImage; 
   price = 350; 
   hudIcon = "mortar"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function SMRPackImage::onActivate(%player,%imageSlot) 
{ 
	schedule("use(\"backpack\");", 0.5); 
} 

function SMRPackImage::onDeactivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,false); 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Command Laptop
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   description = "Command Laptop"; 
   shapeFile = "ammounit_remote"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
   shadowDetailMask = 4; 
   imageType = LaptopImage; 
   price = 650; 
   hudIcon = "energypack"; 
   showWeaponBar = true; 
   hiliteOnActive = true; 
}; 

function Laptop::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)  
		Player::mountItem(%player,%item,$BackpackSlot);
} 

function Laptop::onMount(%player,%item) 
{ 
	Player::trigger(%player,$BackpackSlot,true); 
} 

function Laptop::onUnmount(%player,%item) { } 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Suicide DetPack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

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
   description = "Suicide DetPack"; 
   shapeFile = "magcargo"; 
   className = "Backpack"; 
   heading = "fBackpacks"; 
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
		Player::mountItem(%player,%item,$BackpackSlot); 
	else  
		Player::deployItem(%player,%item); 
} 

function SuicidePack::onUnmount(%player,%item) { } 

function SuicidePack::onDeploy(%player,%item,%pos) 
{ 
	if (SuicidePack::deployShape(%player,%item))  
		Player::decItemCount(%player,%item); 
} 

function SuicidePack::deployShape(%player,%item) 
{ 
	Player::unmountItem(%player,$BackpackSlot); 
	%obj = newObject("","Mine","Suicidebomb2"); 
	addToSet("MissionCleanup", %obj); 
	%client = Player::getClient(%player); 
	GameBase::throw(%obj,%player,3 * %client.throwStrength,false); 
	Client::sendMessage(%client,1,"Det Pack will destruct in 20 seconds"); 
} 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Ammo Pack
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData AmmoPackImage
{
   shapeFile = "AmmoPack";
   mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
   //mountRotation = { 1.57, 0, 0 };
   firstPerson = false;
};

ItemData AmmoPack
{
   description = "Ammo Pack";
   shapeFile = "AmmoPack";
   className = "Backpack";
   heading = "fBackpacks";
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
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 15 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0)  
				%item.BulletAmmo = %numPack;  
			else if(%i == 1)  
				%item.PlasmaAmmo = %numPack;  
			else if(%i == 2)  
				%item.DiscAmmo = %numPack;  
			else if(%i == 3)  
				%item.GrenadeAmmo = %numPack;  
			else if(%i == 4)  
				%item.Grenade = %numPack;  
			else if(%i == 5)  
				%item.MortarAmmo = %numPack;  
			else if(%i == 6)  
				%item.RocketAmmo = %numPack;  
			else if(%i == 7)  
				%item.SniperAmmo = %numPack;  
			else if(%i == 8)  
				%item.RailAmmo = %numPack;  
			else if(%i == 9)  
				%item.SilencerAmmo = %numPack;  
			else if(%i == 10)  
				%item.VulcanAmmo = %numPack; 
			else if(%i == 11)  
				%item.Beacon = %numPack;  
			else if(%i == 12)  
				%item.TranqAmmo = %numPack;  
			else if(%i == 13)  
				%item.ShotgunAmmo = %numPack;  
			else if(%i == 14)  
				%item.NapalmAmmo = %numPack;  
			else  
				%item.MineAmmo = %numPack;  
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

function checkPacksAmmo(%player, %item) 
{ 
	for(%i = 0; %i < 15 ; %i = %i +1) { 
		%ammoItem = $AmmoPackItems[%i]; 
		if(%i == 0)       
			%numAdd = %item.BulletAmmo;  
		else if(%i == 1)  
			%numAdd = %item.PlasmaAmmo;  
		else if(%i == 2)  
			%numAdd = %item.DiscAmmo;  
		else if(%i == 3)  
			%numAdd = %item.GrenadeAmmo;  
		else if(%i == 4)  
			%numAdd = %item.Grenade;  
		else if(%i == 5)  
			%numAdd = %item.MortarAmmo;  
		else if(%i == 6)  
			%numAdd = %item.RocketAmmo;  
		else if(%i == 7)  
			%numAdd = %item.SniperAmmo;  
		else if(%i == 8)  
			%numAdd = %item.RailAmmo;  
		else if(%i == 9)  
			%numAdd = %item.SilencerAmmo;  
		else if(%i == 10) 
			%numAdd = %item.VulcanAmmo; 
		else if(%i == 11) 
			%numAdd = %item.Beacon;  
		else if(%i == 12) 
			%numAdd = %item.NapalmAmmo;  
		else if(%i == 13) 
			%numAdd = %item.ShotgunAmmo;  
		else if(%i == 14) 
			%numAdd = %item.TranqAmmo; 
		else if(%i == 15) 
			%numAdd = %item.MineAmmo;  
		Player::incItemCount(%player,%ammoItem,%numAdd); 
	} 
} 

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 15 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}













