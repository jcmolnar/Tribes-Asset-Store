//********************
// TRIBAL COMBAT PACKS
//********************
ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
 if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
 else Player::trigger(%player,$BackpackSlot);
}

//***************************
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
    heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyPack::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
}

function EnergyPack::onMount(%player,%item)
{
Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
if(Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) Player::unmountItem(%player,$WeaponSlot);
else if(Player::getMountedItem(%player,$WeaponSlot) == Tazer) Player::unmountItem(%player,$WeaponSlot);
else if(Player::getMountedItem(%player,$WeaponSlot) == CutterBeam) Player::unmountItem(%player,$WeaponSlot);
else if(Player::getMountedItem(%player,$WeaponSlot) == EnergyCannon) Player::unmountItem(%player,$WeaponSlot);
}

//***************************
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
};

function RepairPack::onUnmount(%player,%item)
{
if(Player::getMountedItem(%player,$WeaponSlot) == RepairGun) Player::unmountItem(%player,$WeaponSlot);
else if(Player::getMountedItem(%player,$WeaponSlot) == TransferGun) Player::unmountItem(%player,$WeaponSlot);
}

function RepairPack::onUse(%player,%item)
{
if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
else Player::mountItem(%player,RepairGun,$WeaponSlot);
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) 
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if(%mounted == RepairGun) Player::unmountItem(%player,$WeaponSlot);
		else Player::mountItem(%player,%mounted,$WeaponSlot);
		Item::onDrop(%player,%item);
	}
}	

//***************************
ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 8;   // Energy/sec for sustained weapons
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
};

function ShieldPack::onUnmount(%player,%item)
{
 if(Player::getMountedItem(%player,$WeaponSlot) == EDGun) Player::unmountItem(%player,$WeaponSlot);
}

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


//*********************************
ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 8;  // Energy used/sec for sustained weapons
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

//**********************
// Items in the AmmoPack
//Missile Laucher has no extra ammo from ammo pack
$AmmoPackWeapon[0] = AutoCannon;
$AmmoPackWeapon[1] = Chaingun;
$AmmoPackWeapon[2] = PlasmaGun;
$AmmoPackWeapon[3] = DiscLauncher;
$AmmoPackWeapon[4] = GrenadeLauncher;
$AmmoPackWeapon[5] = Mortar;
$AmmoPackWeapon[6] = AMortar;
$AmmoPackWeapon[7] = RocketLauncher;
$AmmoPackWeapon[8] = HvyChaingun;
$AmmoPackWeapon[9] = GaussRifle;
$AmmoPackWeapon[10] = SilencedPistol;
$AmmoPackWeapon[11] = SniperRifle;
$AmmoPackWeapon[12] = Grenade;
$AmmoPackWeapon[13] = MineAmmo;
$NumAmmoPackWpn = 12;

$AmmoPackMax[ACAmmo] = 85;
$AmmoPackMax[BulletAmmo] = 200;
$AmmoPackMax[SniperAmmo] = 15;
$AmmoPackMax[PlasmaAmmo] = 35;
$AmmoPackMax[DiscAmmo] = 25;
$AmmoPackMax[GrenadeAmmo] = 20;
$AmmoPackMax[MortarAmmo] = 15;
$AmmoPackMax[RLAmmo] = 6;
$AmmoPackMax[HvyBulletAmmo] = 150;
$AmmoPackMax[GaussAmmo] = 10;
$AmmoPackMax[PistolAmmo] = 20;
$AmmoPackMax[Grenade] = 2;
$AmmoPackMax[MineAmmo] = 3;

$AmmoPackItems[0] = ACAmmo;
$AmmoPackItems[1] = BulletAmmo;
$AmmoPackItems[2] = PlasmaAmmo;
$AmmoPackItems[3] = DiscAmmo;
$AmmoPackItems[4] = GrenadeAmmo;
$AmmoPackItems[5] = MortarAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = RLAmmo;
$AmmoPackItems[8] = HvyBulletAmmo;
$AmmoPackItems[9] = GaussAmmo;
$AmmoPackItems[10] = PistolAmmo;
$AmmoPackItems[11] = SniperAmmo;
$AmmoPackItems[12] = Grenade;
$AmmoPackItems[13] = MineAmmo;

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
if((GameBase::getOwnerClient(%player) == -1) || Player::isDead(%player)) return;

	if($matchStarted) 
	{
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 12 ; %i = %i +1) 
		{
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) 
			{
				%numPack = %pCount - %maxnum;
				if(!Player::isDead(%player)) Player::decItemCount(%player,%ammoItem,%numPack);
			}
			if(%i == 0) %item.ACAmmo = %numPack;	
			else if(%i == 1) %item.BulletAmmo = %numPack;
			else if(%i == 2) %item.PlasmaAmmo = %numPack;
			else if(%i == 3) %item.DiscAmmo = %numPack;
			else if(%i == 4) %item.GrenadeAmmo = %numPack;
			else if(%i == 5) %item.MortarAmmo = %numPack;
			else if(%i == 6) %item.MortarAmmo = %numPack;
			else if(%i == 7) %item.RLAmmo = %numPack;
			else if(%i == 8) %item.HvyBulletAmmo = %numPack;
			else if(%i == 9) %item.GaussAmmo = %numPack;
			else if(%i == 10) %item.PistolAmmo = %numPack;
			else if(%i == 11) %item.SniperAmmo = %numPack;
			else if(%i == 12) %item.Grenade = %numPack;
			else if(%i == 13) %item.MineAmmo = %numPack;
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if(getObjectType(%object) == "Player") 
	{
        if((GameBase::getOwnerClient(%object) == -1) || Player::isDead(%object)) return;

		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if(Item::giveItem(%object,%item,Item::getCount(%this))) 
		{
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player,%item)
{
	%client = Player::getClient(%player);
    for(%i = 0;%i < $numAmmoPackWpn; %i++)
	{
	 %ammo = $AmmoPackItems[%i];
//	 if(Player::getItemCount(%client,$AmmoPackWeapon[%i]) > 0)
//	  {
	   if(%i == 0) Player::incItemCount(%player,%ammo,%item.ACAmmo);
	   if(%i == 1) Player::incItemCount(%player,%ammo,%item.BulletAmmo);
	   if(%i == 2) Player::incItemCount(%player,%ammo,%item.PlasmaAmmo);
	   if(%i == 3) Player::incItemCount(%player,%ammo,%item.DiscAmmo);
	   if(%i == 4) Player::incItemCount(%player,%ammo,%item.GrenadeAmmo);
	   if(%i == 5) Player::incItemCount(%player,%ammo,%item.MortarAmmo);
	   if(%i == 6) Player::incItemCount(%player,%ammo,%item.MortarAmmo);
	   if(%i == 7) Player::incItemCount(%player,%ammo,%item.RLAmmo);
	   if(%i == 8) Player::incItemCount(%player,%ammo,%item.HvyBulletAmmo);
	   if(%i == 9) Player::incItemCount(%player,%ammo,%item.GaussAmmo);
	   if(%i == 10) Player::incItemCount(%player,%ammo,%item.PistolAmmo);
	   if(%i == 11) Player::incItemCount(%player,%ammo,%item.SniperAmmo);
//	  }
	}
	 Player::incItemCount(%player,Grenade,%item.Grenade);
	 Player::incItemCount(%player,MineAmmo,%item.MineAmmo);
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);

    if((GameBase::getOwnerClient(%player) == -1) || Player::isDead(%player)) return;

    %max = 0;
	for(%i = 0;%i < $NumAmmoPackWpn;%i++)
	{
    %item = $AmmoPackItems[%i];
	 if(Player::getItemCount(%client,$AmmoPackWeapon[%i]) > 0)
	  {
	   %max = $AmmoPackMax[%item];
	   %max = checkResources(%player,%item,%max);
       Player::incItemCount(%client,%item,%max);
	   teamEnergyBuySell(%player,%item.price * %max * -1);
	  }
	}
    %max = $AmmoPackMax[Grenade];
	%max = checkResources(%player,Grenade,%max);
	Player::incItemCount(%client,Grenade,%max);
	teamEnergyBuySell(%player,Grenade.price * %max * -1);
    %max = $AmmoPackMax[MineAmmo];
	%max = checkResources(%player,MineAmmo,%max);
	Player::incItemCount(%client,MineAmmo,%max);
	teamEnergyBuySell(%player,MineAmmo.price * %max * -1);
}

//****************************
ItemImageData StealthPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData StealthPack
{
	description = "Stealth Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
    heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = StealthPackImage;
	price = 300;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StealthPackImage::onActivate(%player,%imageSlot)
{
   %client = Player::getClient(%player);
   %type = Player::getMountedItem(%player,$FlagSlot);
   if(%type == -1)
   {
	GameBase::startFadeout(%player);
	Client::sendMessage(%client,0,"Stealth Pack On");
	%radius = Player::getSensorSupression(%player) + 1;
	Player::setSensorSupression(%player,%radius);
   }
   else
    {
     Player::trigger(%player,$BackpackSlot,false);
	 centerprint(%client,"<jc>Carrying a flag interferes with the operation of the stealth pack.");
	}
}

function StealthPackImage::onDeactivate(%player,%imageSlot)
{
	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),0,"Stealth Pack Off");
	%radius = Player::getSensorSupression(%player) - 1;
	Player::setSensorSupression(%player,radius);
	Player::trigger(%player,$BackpackSlot,false);
}

//*************************
ItemImageData TelePackImage
{
	shapeFile = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData TelePack
{
	description = "Teleport Pack";
	shapeFile = "jetPack";
	className = "Backpack";
    heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = TelePackImage;
	price = 1500;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TelePackImage::onActivate(%player,%slot)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	%energy = GameBase::getEnergy(%player);

	if(%energy != %armor.maxEnergy)
	 {
	  centerprint(%client,"<jc>Teleport failed - Not enough energy.");
	  Player::trigger(%player,$BackpackSlot,false);
	  return;
	 }
	 else GameBase::setEnergy(%player,0);

	%position = false;
	%group = nameToID("MissionCleanup/TeleportPads");
	if(Group::objectCount(%group) != 0)
	{
	for(%i = 0;(%teleport = Group::getObject(%group,%i)) != -1;%i++)
	 {
	 if(GameBase::getTeam(%teleport) == GameBase::getTeam(%player)) %position = GameBase::getPosition(%teleport);
	 }
	}
	
	if(!%position) centerprint(%client,"<jc>Teleport failed - No destination point");

	else if(!Player::isDead(%client))
	{
	 %type = Player::getMountedItem(%player,$FlagSlot);
	 if(%type != -1)
	  {
		centerprint(%client,"<jc>Flags can not undergo teleportation.");
	    Player::dropItem(%client,%type);
	  }

//	 if(GameBase::testPosition(%player,%position)) 
     GameBase::setPosition(%player,%position);
//	 else centerprint(%client,"<jc>Teleport Field gateway blocked.");
	}

    Player::trigger(%player,$BackpackSlot,false);
}

//*****************************
ItemImageData RelocatePackImage
{
	shapeFile = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData RelocatePack
{
	description = "Relocator Pack";
	shapeFile = "jetPack";
	className = "Backpack";
    heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = RelocatePackImage;
	price = 1500;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RelocatePackImage::onActivate(%player,%slot)
{
  %client = Player::getClient(%player);

  if(GameBase::getEnergy(%player) < Player::getArmor(%player).maxEnergy * 0.5)
   {
    bottomprint(%client,"<jc>Energy levels are too low to use the Relocator.");
	Player::trigger(%player,$BackpackSlot,false);
	return;
   }

  if(GameBase::getLOSInfo(%player,245))
  {
   if(Vector::dot($los::normal,"0 0 1") > 0.7)
   {
	%type = Player::getMountedItem(%player,$FlagSlot);
	if(%type != -1)
	 {
	   centerprint(%client,"<jc>Flags can not undergo teleportation.");
	   Player::dropItem(%client,%type);
	 }
	else bottomprint(%client,"<jc>Energy systems depleted.");

    GameBase::setPosition(%player,$los::position);
    playSound(ForceFieldOpen,GameBase::getPosition(%player));
    GameBase::setEnergy(%player,0);
	GameBase::setRechargeRate(%player,1);
	Player::trigger(%player,$BackpackSlot,false);
	schedule("RelocatePack::Recharge("@%player@");",30,%player);
   }
   else bottomprint(%client,"<jc>Could not get a valid lock at the location.");
  }
  else bottomprint(%client,"<jc>Location is out of range.");
  Player::trigger(%player,$BackpackSlot,false);
}

function RelocatePack::Recharge(%player)
{
	if(%player != -1)
	 {
	  GameBase::setRechargeRate(%player,8);
      bottomprint(%client,"<jc>Energy systems recharging.");
	 }
}

//********************
ItemImageData VRPImage
{
	shapeFile = "armorpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData VehicleRepairPack
{
	description = "Vehicle Repair Pack";
	shapeFile = "armorpack";
	className = "Backpack";
    heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = VRPImage;
	price = 250;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function VehicleRepairPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
}

function VehicleRepairPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	schedule("VehicleRepairPack::Repair("@%player@","@%item@");",10,%player);
}

function VehicleRepairPack::Repair(%player,%item)
{
	%client = Player::getClient(%player);
	%vehicle = %player.vehicle;

	if(Player::getMountedItem(%player,$BackpackSlot) == %item)
	 {
	  if(%vehicle != "")
	   {
	    %damage = GameBase::getDamageLevel(%vehicle);
		if(%damage > 0)
		{
		 %damage -= 0.12;
		 if(%damage < 0) %damage = 0;
		 GameBase::setDamageLevel(%vehicle,%damage);
		}
	   }
	  schedule("VehicleRepairPack::Repair("@%player@","@%item@");",10,%player);
	 }
}

//************************
ItemImageData ComPackImage
{
	shapeFile = "AmmoPack";
    mountPoint = 2;
    mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData ComPack
{
	description = "CommLink Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
    heading = "fBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ComPack::onMount(%player,%item)
{
	%player.CommandTag = 1;
}

function ComPack::onUnmount(%player,%item)
{
	%player.CommandTag = 0;
}

//****************************
ItemImageData CoolantPackImage
{
	shapeFile = "jetpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 5;
 	maxEnergy = 5;
	firstPerson = false;
};

ItemData CoolantPack
{
	description = "Coolant Pack";
	shapeFile = "jetpack";
	className = "Backpack";
    heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = CoolantPackImage;
	price = 200;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CoolantPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
}

function CoolantPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function CoolantPack::onUnmount(%player,%item)
{
if(Player::getMountedItem(%player,$WeaponSlot) == PlasmaRepeater) Player::unmountItem(%player,$WeaponSlot);
}
