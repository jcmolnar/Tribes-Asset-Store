$WeaponAmmo[QuadMortar] = QuadMortarAmmo; 
 
$WeaponAmmo[Blaster] = ""; 
$WeaponAmmo[PlasmaGun] = PlasmaAmmo; 
$WeaponAmmo[Chaingun] = BulletAmmo; 
$WeaponAmmo[DiscLauncher] = DiscAmmo; 
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo; 
$WeaponAmmo[Mortar] = MortarAmmo; 
$WeaponAmmo[LaserRifle] = ""; 
$WeaponAmmo[EnergyRifle] = ""; 
$WeaponAmmo[RocketLauncher] = RocketAmmo; 
$WeaponAmmo[SniperRifle] = SniperAmmo; 
$WeaponAmmo[Railgun] = RailAmmo; 
$WeaponAmmo[WaveGun] = ""; 
$WeaponAmmo[IonGun] = ""; 
$WeaponAmmo[Flamer] = "FlamerAmmo"; 
$WeaponAmmo[Shotgun] = ShotgunAmmo; 
$WeaponAmmo[Silencer] = SilencerAmmo; 
$WeaponAmmo[Vulcan] = VulcanAmmo; 
$WeaponAmmo[Omega] = ""; 
$WeaponAmmo[TranqGun] = TranqAmmo; 
$WeaponAmmo[Napalm] = NapalmAmmo; 

$NextWeapon[JailGun] = Blaster; 
$NextWeapon[Blaster] = PlasmaGun; 
$NextWeapon[PlasmaGun] = Chaingun; 
$NextWeapon[Chaingun] = DiscLauncher; 
$NextWeapon[DiscLauncher] = GrenadeLauncher; 
$NextWeapon[GrenadeLauncher] = Mortar; 
$NextWeapon[Mortar] = LaserRifle; 
$NextWeapon[LaserRifle] = RocketLauncher; 
$NextWeapon[RocketLauncher] = SniperRifle; 
$NextWeapon[SniperRifle] = WaveGun; 
$NextWeapon[WaveGun] = EnergyRifle; 
$NextWeapon[EnergyRifle] = Railgun; 
$NextWeapon[Railgun] = Omega; 
$NextWeapon[Omega] = Silencer; 
$NextWeapon[Silencer] = Vulcan; 
$NextWeapon[Vulcan] = IonGun; 
$NextWeapon[IonGun] = Flamer; 
$NextWeapon[Flamer] = TranqGun; 
$NextWeapon[TranqGun] = Napalm; 
$NextWeapon[Napalm] = Shotgun; 
$NextWeapon[Shotgun] = Fixit; 
$NextWeapon[Fixit] = Hackit; 
$NextWeapon[Hackit] = Packit; 
$NextWeapon[Packit] = VehicleRepairGun; 
$NextWeapon[VehicleRepairGun] = VehiclePackit; 
$NextWeapon[VehiclePackit] = JailGun; 



$PrevWeapon[Packit] = Hackit; 
$PrevWeapon[VehicleRepairGun] = Packit; 
$PrevWeapon[VehiclePackit] = VehicleRepairGun; 
$PrevWeapon[JailGun] = VehiclePackit; 
$PrevWeapon[Blaster] = JailGun; 
$PrevWeapon[PlasmaGun] = Blaster; 
$PrevWeapon[Chaingun] = PlasmaGun; 
$PrevWeapon[DiscLauncher] = Chaingun; 
$PrevWeapon[GrenadeLauncher] = DiscLauncher; 
$PrevWeapon[Mortar] = GrenadeLauncher; 
$PrevWeapon[LaserRifle] = Mortar; 
$PrevWeapon[RocketLauncher] = LaserRifle; 
$PrevWeapon[SniperRifle] = RocketLauncher; 
$PrevWeapon[WaveGun] = SniperRifle; 
$PrevWeapon[EnergyRifle] = WaveGun; 
$PrevWeapon[Railgun] = EnergyRifle; 
$PrevWeapon[Omega] = Railgun; 
$PrevWeapon[Silencer] = Omega; 
$PrevWeapon[Vulcan] = Silencer; 
$PrevWeapon[Flamer] = Vulcan; 
$PrevWeapon[IonGun] = Flamer; 
$PrevWeapon[TranqGun] = IonGun; 
$PrevWeapon[Napalm] = TranqGun; 
$PrevWeapon[Shotgun] = Napalm; 
$PrevWeapon[Fixit] = Shotgun; 
$PrevWeapon[Hackit] = Fixit;

ItemData Weapon 
{ 
   description = "Weapon"; 
   showInventory = false; 
}; 

function Weapon::onUse(%player,%item) 
{
	%client = Player::getClient(%player);
	%ammo = %item.imageType.ammoType;
	%desc = %item.description;
	if(%ammo == "") { 
		Player::mountItem(%player,%item,$WeaponSlot);
		bottomprint(%client, "<jc><f2>-"@ %desc @"-", 2);
	} 
	else {
		if(Player::getItemCount(%player,%ammo) > 0){ 
			Player::mountItem(%player,%item,$WeaponSlot);
			bottomprint(%client, "<jc><f2>-"@ %desc @"-", 2);
		}
		else { 
			Client::sendMessage(Player::getClient(%player),0, strcat(%item.description," has no ammo.")); 
		} 
	} 
} 

function Weapon::onDrop(%player,%item)
{
	%client = Player::getClient(%player);
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

ItemData Tool 
{ 
   description = "Tool"; 
   showInventory = false; 
}; 

function Tool::onUse(%player,%item) 
{
	%client = Player::getClient(%player);
	%desc = %item.description;
	Player::mountItem(%player,%item,$ToolSlot);
	bottomprint(%client, "<jc><f2>-"@ %desc @"-", 2);
} 

ItemData Ammo 
{ 
   description = "Ammo"; 
   showInventory = false; 
}; 

function Ammo::onDrop(%player,%item) 
{ 
	if($matchStarted) { 
		%count = Player::getItemCount(%player,%item); 
		%delta = $SellAmmo[%item]; 
		if(%count <= %delta) { 
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) 
				%delta = %count; 
			else 
				%delta = %count - 1; 
		} 
		if(%delta > 0) { 
			%obj = newObject("","Item",%item,%delta,false); 
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); 
			addToSet("MissionCleanup", %obj); 
			GameBase::throw(%obj,%player,20,false); 
			Item::playPickupSound(%obj); 
			Player::decItemCount(%player,%item,%delta); 
		} 
	} 
} 

//=============================================================================================
//================================================================= Blaster ===================
//=============================================================================================

ItemImageData BlasterImage 
{ 
   shapeFile = "energygun"; 
   mountPoint = 0; 
   weaponType = 0; 
   reloadTime = 0; 
   fireTime = 0.2; 
   minEnergy = 6; 
   maxEnergy = 7; 
   projectileType = BlasterBolt; 
   accuFire = true; 
   sfxFire = SoundFireBlaster; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Blaster 
{ 
   heading = "cWeapons"; 
   description = "Blaster"; 
   className = "Weapon"; 
   shapeFile = "energygun"; 
   hudIcon = "blaster"; 
   shadowDetailMask = 4; 
   imageType = BlasterImage; 
   price = 420; 
   showWeaponBar = true; 
}; 


//=============================================================================================
//================================================================= Chaingun ==================
//=============================================================================================

ItemData BulletAmmo 
{ 
   description = "Bullet"; 
   className = "Ammo"; 
   shapeFile = "ammo2"; 
   heading = "zAmmunition"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData ChaingunImage 
{ 
   shapeFile = "chaingun"; 
   mountPoint = 0; 
   weaponType = 1; 
   reloadTime = 0; 
   spinUpTime = 0.5; 
   spinDownTime = 3; 
   fireTime = 0.09; 
   ammoType = BulletAmmo; 
   projectileType = ChaingunBullet; 
   accuFire = false; 
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 0.1; 
   lightColor = { 1,1,0.9}; 
   sfxFire = SoundFireChaingun; 
   sfxActivate = SoundPickUpWeapon; 
   sfxSpinUp = SoundSpinUp; 
   sfxSpinDown = SoundSpinDown; 
}; 

ItemData Chaingun 
{ 
   description = "Chaingun"; 
   className = "Weapon"; 
   shapeFile = "chaingun"; 
   hudIcon = "chain"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = ChaingunImage; 
   price = 420; 
   showWeaponBar = true; 
};

//=============================================================================================
//================================================================= Dart Rifle ================
//=============================================================================================

ItemData TranqAmmo 
{ 
   description = "Poison Dart"; 
   className = "Ammo"; 
   heading = "zAmmunition"; 
   shapeFile = "ammo2"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData TranqGunImage 
{ 
   shapeFile = "sniper"; 
   mountPoint = 0; 
   weaponType = 0; 
   ammoType = TranqAmmo; 
   projectileType = TranqDart; 
   accuFire = true; 
   reloadTime = 1.5; 
   fireTime = 0; 
   lightType = 3; 
   lightRadius = 6; 
   lightTime = 2; 
   lightColor = { 1.0, 0, 0 }; 
   sfxFire = SoundFireChainGun; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData TranqGun 
{ 
   description = "Dart Rifle"; 
   className = "Weapon"; 
   shapeFile = "sniper"; 
   hudIcon = "blaster"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = TranqGunImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Disc Launcher =============
//=============================================================================================

ItemData DiscAmmo 
{ 
   description = "Disc"; 
   className = "Ammo"; 
   shapeFile = "discammo"; 
   heading = "zAmmunition"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData DiscLauncherImage 
{ 
   shapeFile = "disc"; 
   mountPoint = 0; 
   weaponType = 3; 
   ammoType = DiscAmmo; 
   projectileType = DiscShell; 
   accuFire = true; 
   reloadTime = 0.25; 
   fireTime = 1.25; 
   spinUpTime = 0.25; 
   sfxFire = SoundFireDisc; 
   sfxActivate = SoundPickUpWeapon; 
   sfxReload = SoundDiscReload; 
   sfxReady = SoundDiscSpin; 
}; 

ItemData DiscLauncher 
{ 
   description = "Disc Launcher"; 
   className = "Weapon"; 
   shapeFile = "disc"; 
   hudIcon = "disk"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = DiscLauncherImage; 
   price = 420; 
   showWeaponBar = true; 
}; 




//=============================================================================================
//================================================================= Flamethrower  =============
//=============================================================================================

ItemData FlamerAmmo 
{ 
   description = "Gas"; 
   className = "Ammo"; 
   shapeFile = "discammo"; 
   heading = "zAmmunition"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData FlamerImage 
{ 
   shapeFile = "GrenadeL"; 
   mountPoint = 0; 
   weaponType = 0; 
   reloadTime = 0.05; 
   fireTime = 0; 
   ammoType = FlamerAmmo; 
   projectileType = FlamerBolt; 
   accuFire = true; 
   sfxFire = SoundJetHeavy; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Flamer 
{ 
   heading = "cWeapons"; 
   description = "Flame Thrower"; 
   className = "Weapon"; 
   shapeFile = "GrenadeL"; 
   hudIcon = "plasma"; 
   shadowDetailMask = 4; 
   imageType = FlamerImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

function Flamer::onUse(%player,%item) 
{ 
	if(Player::getMountedItem(%player,$BackpackSlot) == GasPack) 
		Weapon::onUse(%player,%item); 
	else 
		Client::sendMessage(Player::getClient(%player),0, "You must have a Gas Pack to use the Flamethrower."); 
} 

//=============================================================================================
//================================================================= Grenade Launcher ==========
//=============================================================================================

ItemData GrenadeAmmo 
{ 
   description = "Grenade Ammo"; 
   className = "Ammo"; 
   shapeFile = "grenammo"; 
   heading = "zAmmunition"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData GrenadeLauncherImage 
{ 
	shapeFile = "grenadeL"; 
	mountPoint = 0; 
	weaponType = 0; 
	ammoType = GrenadeAmmo; 
	projectileType = GrenadeShell; 
	accuFire = false; 
	reloadTime = 0.5; 
	fireTime = 0.5; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1.0 }; 
	sfxFire = SoundFireGrenade; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundDryFire; 
}; 

ItemData GrenadeLauncher 
{ 
	description = "Grenade Launcher"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "grenade"; 
	heading = "cWeapons"; 
	shadowDetailMask = 4; 
	imageType = GrenadeLauncherImage; 
	price = 420; 
	showWeaponBar = true; 
}; 


//=============================================================================================
//================================================================= Ion Rifle =================
//=============================================================================================

ItemImageData IonGunImage 
{ 
   shapeFile = "GrenadeL"; 
   mountPoint = 0; 
   weaponType = 0; 
   reloadTime = 0; 
   fireTime = 0.4; 
   minEnergy = 12.5; 
   maxEnergy = 12.5; 
   projectileType = IonBolt; 
   accuFire = true; 
   sfxFire = SoundFireLaser; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData IonGun 
{ 
   heading = "cWeapons"; 
   description = "Ion Rifle"; 
   className = "Weapon"; 
   shapeFile = "GrenadeL"; 
   hudIcon = "targetlaser"; 
   shadowDetailMask = 4; 
   imageType = IonGunImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Laser Rifle ===============
//=============================================================================================

ItemImageData LaserRifleImage 
{ 
   shapeFile = "sniper"; 
   mountPoint = 0; 
   weaponType = 0; 
   projectileType = SniperLaser; 
   accuFire = true; 
   reloadTime = 0.1; 
   fireTime = 0.5; 
   minEnergy = 10; 
   maxEnergy = 60; 
   lightType = 3; 
   lightRadius = 2; 
   lightTime = 1; 
   lightColor = { 0, 0, 0 }; 
   sfxFire = SoundFireLaser; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData LaserRifle 
{ 
   description = "Laser Rifle"; 
   className = "Weapon"; 
   shapeFile = "sniper"; 
   hudIcon = "sniper"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = LaserRifleImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

function LaserRifle::onUse(%player,%item) 
{ 
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) 
		Weapon::onUse(%player,%item); 
	else 
		Client::sendMessage(Player::getClient(%player),0, "You must have an Energy Pack to use the Laser Rifle."); 
} 

//=============================================================================================
//================================================================= Magnum ====================
//=============================================================================================

ItemData SilencerAmmo 
{ 
   description = "Magnum Bullets"; 
   className = "Ammo"; 
   heading = "zAmmunition"; 
   shapeFile = "ammo2"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData SilencerImage 
{ 
   shapeFile = "energygun"; 
   mountPoint = 0; 
   weaponType = 0; 
   ammoType = SilencerAmmo; 
   projectileType = SilencerBullet; 
   accuFire = true; 
   reloadTime = 0.0; 
   fireTime = 0.5; 
   lightType = 3; 
   lightRadius = 6; 
   lightTime = 2; 
   lightColor = { 0, 0, 0 }; 
   sfxFire = SoundFireMortar; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Silencer 
{ 
   description = "Magnum"; 
   className = "Weapon"; 
   shapeFile = "energygun"; 
   hudIcon = "targetlaser"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = SilencerImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Mortar ====================
//=============================================================================================

ItemData MortarAmmo 
{ 
   description = "Mortar Ammo"; 
   className = "Ammo"; 
   heading = "zAmmunition"; 
   shapeFile = "ammo1"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData MortarImage 
{ 
   shapeFile = "mortargun"; 
   mountPoint = 0; 
   weaponType = 0; 
   ammoType = MortarAmmo; 
   projectileType = MortarShell; 
   accuFire = false; 
   reloadTime = 0.5; 
   fireTime = 2.0; 
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 1; 
   lightColor = { 0.6, 1, 1.0 }; 
   sfxFire = SoundFireMortar; 
   sfxActivate = SoundPickUpWeapon; 
   sfxReload = SoundMortarReload; 
   sfxReady = SoundMortarIdle; 
}; 

ItemData Mortar 
{ 
   description = "Mortar"; 
   className = "Weapon"; 
   shapeFile = "mortargun"; 
   hudIcon = "mortar"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = MortarImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Napalm Launcher ===========
//=============================================================================================

ItemData NapalmAmmo 
{ 
   description = "Napalm Shell"; 
   heading = "zAmmunition"; 
   className = "Ammo"; 
   shapeFile = "plasammo"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData NapalmImage 
{
   shapeFile = "grenadeL"; 
   mountPoint = 0; 
   weaponType = 0;
   ammoType = NapalmAmmo; 
   projectileType = NapalmShell;
   reloadTime = 0.5; 
   fireTime = 2.0; 
   accuFire = true; 
   sfxFire = SoundFireMortar; 
   sfxActivate = SoundPickUpWeapon;
   sfxReload = SoundDryFire; 
}; 

ItemData Napalm 
{ 
   heading = "cWeapons"; 
   description = "Napalm Launcher"; 
   className = "Weapon"; 
   shapeFile = "grenadeL"; 
   hudIcon = "plasma"; 
   shadowDetailMask = 4; 
   imageType = NapalmImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Omega =====================
//=============================================================================================

ItemImageData OmegaImage 
{ 
   shapeFile = "shotgun"; 
   mountPoint = 0; 
   weaponType = 0; 
   reloadTime = 0.05; 
   fireTime = 0; 
   minEnergy = 5; 
   maxEnergy = 6; 
   projectileType = OmegaBolt; 
   accuFire = false; 
   sfxFire = SoundJetHeavy; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Omega 
{ 
   description = "Omega"; 
   shapeFile = "shotgun"; 
   hudIcon = "energyRifle"; 
   className = "Weapon"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = OmegaImage; 
   showWeaponBar = true; 
   price = 420; 
};

//=============================================================================================
//================================================================= Plasma Gun ================
//=============================================================================================
 
ItemData PlasmaAmmo 
{ 
   description = "Plasma Bolt"; 
   heading = "zAmmunition"; 
   className = "Ammo"; 
   shapeFile = "plasammo"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData PlasmaGunImage 
{ 
   shapeFile = "plasma"; 
   mountPoint = 0; 
   weaponType = 0; 
   ammoType = PlasmaAmmo; 
   projectileType = PlasmaBolt; 
   accuFire = true; 
   reloadTime = 0.1; 
   fireTime = 0.5; 
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 1; 
   lightColor = { 1, 1, 0.2 }; 
   sfxFire = SoundFirePlasma; 
   sfxActivate = SoundPickUpWeapon; 
   sfxReload = SoundDryFire; 
}; 

ItemData PlasmaGun 
{ 
   description = "Plasma Gun"; 
   className = "Weapon"; 
   shapeFile = "plasma"; 
   hudIcon = "plasma"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = PlasmaGunImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Railgun ===================
//=============================================================================================

ItemData RailAmmo 
{ 
   description = "Railgun Bolt"; 
   className = "Ammo"; 
   heading = "zAmmunition"; 
   shapeFile = "ammo2"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData RailgunImage 
{ 
   shapeFile = "sniper"; 
   mountPoint = 0; 
   weaponType = 0; 
   ammoType = RailAmmo; 
   projectileType = RailRound; 
   accuFire = true; 
   reloadTime = 0.2; 
   fireTime = 2.0; 
   lightType = 3; 
   lightRadius = 6; 
   lightTime = 2; 
   lightColor = { 1.0, 0, 0 }; 
   sfxFire = SoundMissileTurretFire; 
   sfxActivate = SoundPickUpWeapon; 
   sfxSpinUp = SoundSpinUp; 
   sfxSpinDown = SoundSpinDown; 
}; 

ItemData Railgun 
{ 
   description = "Railgun"; 
   className = "Weapon"; 
   shapeFile = "sniper"; 
   hudIcon = "targetlaser"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = RailgunImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Repair Gun ================
//=============================================================================================

ItemImageData RepairGunImage 
{ 
   shapeFile = "repairgun"; 
   mountPoint = 0; 
   weaponType = 2; 
   projectileType = RepairBolt; 
   reloadTime = $Nappy::Gun[RepairGun, reloadTime];// = 3  
   minEnergy = $Nappy::Gun[RepairGun, minEnergy];//3; 
   maxEnergy = $Nappy::Gun[RepairGun, maxEnergy];//10; 
   lightType = 3; 
   lightRadius = 1; 
   lightTime = 1; 
   lightColor = { 0.25, 1, 0.25 }; 
   sfxActivate = SoundPickUpWeapon; 
   sfxFire = SoundRepairItem; 
}; 

ItemData RepairGun 
{ 
   description = "Repair Gun"; 
   shapeFile = "repairgun"; 
   className = "Weapon"; 
   shadowDetailMask = 4; 
   imageType = RepairGunImage;
   showInventory = false; 
   price = 420; 
}; 

function RepairGun::onMount(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,true); 
} 

function RepairGun::onUnmount(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,false); 
} 

//=============================================================================================
//================================================================= Rocket Launcher ===========
//=============================================================================================

ItemData RocketAmmo 
{ 
   description = "Rockets"; 
   className = "Ammo"; 
   heading = "zAmmunition"; 
   shapeFile = "ammo1"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData RocketImage 
{ 
   shapeFile = "mortargun"; 
   mountPoint = 0; 
   weaponType = 0; 
   ammoType = RocketAmmo; 
   projectileType = StingerMissile; 
   accuFire = true; 
   reloadTime = 0.5; 
   fireTime = 2.0; 
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 1; 
   lightColor = { 0.6, 1, 1.0 }; 
   sfxFire = SoundMissileTurretFire; 
   sfxActivate = SoundPickUpWeapon; 
   sfxReload = SoundMortarReload; 
   sfxReady = SoundMortarIdle; 
}; 

ItemData RocketLauncher 
{ 
   description = "Rocket Launcher"; 
   className = "Weapon"; 
   shapeFile = "mortargun"; 
   hudIcon = "mortar"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = RocketImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Shockwave Cannon ==========
//=============================================================================================

ItemImageData WaveGunImage 
{ 
   shapeFile = "shotgun"; 
   mountPoint = 0; 
   weaponType = 0; 
   minEnergy = 40; 
   maxEnergy = 45; 
   projectileType = Shock; 
   accuFire = true; 
   fireTime = 0.9; 
   sfxFire = SoundPlasmaTurretFire; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData WaveGun 
{ 
   description = "Shockwave Cannon"; 
   className = "Weapon"; 
   shapeFile = "shotgun"; 
   hudIcon = "disk"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = WaveGunImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Shotgun ===================
//=============================================================================================

ItemData ShotgunAmmo 
{ 
   description = "Shotgun Shell"; 
   className = "Ammo"; 
   shapeFile = "ammo2"; 
   heading = "zAmmunition"; 
   shadowDetailMask = 4; 
   price = 7; 
};
 
ItemImageData ShotgunImage 
{ 
   shapeFile = "shotgun"; 
   mountPoint = 0; 
   weaponType = 0; 
   reloadTime = 1; 
   fireTime = 0.33; 
   ammoType = ShotgunAmmo; 
   accuFire = false; 
   sfxFire = SoundFireMortar; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Shotgun 
{ 
   heading = "cWeapons"; 
   description = "Shotgun"; 
   className = "Weapon"; 
   shapeFile = "shotgun"; 
   hudIcon = "mortar"; 
   shadowDetailMask = 4; 
   imageType = ShotgunImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

function ShotgunImage::onFire(%player, %slot) 
{
	%count = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
	if(%count) {
		%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
		%tran = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
		Projectile::spawnProjectile("ShotgunBullet",%tran,%player,%vel);
	}
	else
		Client::sendMessage(%client, 0,"Shotgun has no ammo.");
}

//=============================================================================================
//================================================================= Sniper Rifle ==============
//=============================================================================================

ItemData SniperAmmo 
{ 
   description = "Sniper Bullet"; 
   className = "Ammo"; 
   heading = "zAmmunition"; 
   shapeFile = "ammo2"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData SniperRifleImage 
{ 
   shapeFile = "sniper"; 
   mountPoint = 0; 
   weaponType = 0; 
   ammoType = SniperAmmo; 
   projectileType = SniperRound; 
   accuFire = true; 
   reloadTime = 2; 
   fireTime = 0; 
   lightType = 3; 
   lightRadius = 6; 
   lightTime = 2; 
   lightColor = { 1.0, 0, 0 }; 
   sfxFire = SoundFireLaser; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData SniperRifle 
{ 
   description = "Sniper Rifle"; 
   className = "Weapon"; 
   shapeFile = "sniper"; 
   hudIcon = "targetlaser"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = SniperRifleImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Thunderbolt ===============
//=============================================================================================

ItemImageData EnergyRifleImage 
{ 
   shapeFile = "shotgun"; 
   mountPoint = 0; 
   weaponType = 2; 
   projectileType = boltCharge; 
   minEnergy = 3; 
   maxEnergy = 15; 
   reloadTime = 0.2; 
   lightType = 3; 
   lightRadius = 2; 
   lightTime = 1; 
   lightColor = { 0.25, 0.25, 0.85 }; 
   sfxActivate = SoundPickUpWeapon; 
   sfxFire = SoundELFIdle; 
}; 

ItemData EnergyRifle 
{ 
   description = "Thunderbolt"; 
   shapeFile = "shotgun"; 
   hudIcon = "energyRifle"; 
   className = "Weapon"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = EnergyRifleImage; 
   showWeaponBar = true; 
   price = 420; 
}; 


//=============================================================================================
//================================================================= Vulcan ====================
//=============================================================================================

ItemData VulcanAmmo 
{ 
   description = "Vulcan Bullet"; 
   className = "Ammo"; 
   shapeFile = "ammo2"; 
   heading = "zAmmunition"; 
   shadowDetailMask = 4; 
   price = 7; 
}; 

ItemImageData VulcanImage 
{ 
   shapeFile = "chaingun"; 
   mountPoint = 0; 
   weaponType = 1; 
   reloadTime = 0; 
   spinUpTime = 0.75; 
   spinDownTime = 3; 
   fireTime = 0.045; 
   ammoType = VulcanAmmo; 
   projectileType = VulcanBullet; 
   accuFire = true; 
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 0.1; 
   lightColor = { 1, 1, 0.9 }; 
   sfxFire = SoundFireChaingun; 
   sfxActivate = SoundPickUpWeapon; 
   sfxSpinUp = SoundSpinUp; 
   sfxSpinDown = SoundSpinDown; 
}; 

ItemData Vulcan 
{ 
   description = "Vulcan"; 
   className = "Weapon"; 
   shapeFile = "chaingun"; 
   hudIcon = "chain"; 
   heading = "cWeapons"; 
   shadowDetailMask = 4; 
   imageType = VulcanImage; 
   price = 420; 
   showWeaponBar = true; 
}; 

//=============================================================================================
//================================================================= Targeting Laser ===========
//=============================================================================================

ItemImageData TargetingLaserImage 
{ 
   shapeFile = "paintgun"; 
   mountPoint = 0; 
   weaponType = 2; 
   projectileType = targetLaser; 
   accuFire = true; 
   minEnergy = 5; 
   maxEnergy = 15; 
   reloadTime = 1.0; 
   lightType = 3; 
   lightRadius = 1; 
   lightTime = 1; 
   lightColor = { 0.25, 1, 0.25 }; 
   sfxFire = SoundFireTargetingLaser; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData TargetingLaser 
{ 
   description = "Targeting Laser"; 
   className = "Tool"; 
   shapeFile = "paintgun"; 
   hudIcon = "targetlaser"; 
   heading = "dTools"; 
   shadowDetailMask = 4; 
   imageType = TargetingLaserImage; 
   price = 420; 
   showWeaponBar = false; 
}; 

//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Repair-Gun
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData FixitImage 
{ 
   shapeFile = "repairgun"; 
   mountPoint = 0; 
   weaponType = 2; 
   projectileType = RepairBolt; 
   reloadTime = 2.5;  
   minEnergy = 5; 
   maxEnergy = 15; 
   lightType = 3; 
   lightRadius = 1; 
   lightTime = 1; 
   lightColor = { 0.25, 1, 0.25 }; 
   sfxFire = SoundRepairItem; 
   sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Fixit 
{ 
   description = "Repair-Gun"; 
   className = "Tool"; 
   shapeFile = "repairgun"; 
   hudIcon = "targetlaser"; 
   heading = "dTools"; 
   shadowDetailMask = 4; 
   imageType = FixitImage; 
   price = 420; 
   showWeaponBar = false; 
}; 


//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Hackable
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

function checkHackable(%name, %shape)
{ 
if(%shape != "generator" || 
%shape == "generator" ||
%shape == "Generator" ||
%shape == "generator_p" ||
%shape == "solar_med" ||
%shape == "inventory_sta" ||
%shape == "elevator_4x4" ||
%shape == "elevator_6x6" ||
%shape == "elevator_6x6_octagon" ||
%shape == "elevator_8x4" ||
%shape == "elevator_8x6" ||
%shape == "elevator_9x9" ||
%shape == "elevator16x16_octo" ||
%shape == "elevator6X4" ||
%shape == "elevator_6x5" ||
%shape == "elevator_8x8" ||
%shape == "elevator6x4thin" ||
%shape == "elevator6x6thin" ||
%shape == "elevator_5x5" ||
%shape == "elevator_4x5" ||
%shape == "door_top" ||
%shape == "door_bot" ||
%shape == "newdoor1_l" ||
%shape == "newdoor1_r" ||
%shape == "newdoor2_l" ||
%shape == "newdoor2_r" ||
%shape == "newdoor3_l" ||
%shape == "newdoor3_r" ||
%shape == "newdoor4_l" ||
%shape == "newdoor4_r" ||
%shape == "newdoor6_l" ||
%shape == "newdoor6_r" ||
%shape == "door_8x8_l" ||
%shape == "door_8x8_r" ||
%shape == "forcefield" ||
%shape == "forcefield_3x4" ||
%shape == "forcefield_4x17" ||
%shape == "newdoor3_r" ||
%shape == "newdoor4_l" || 
%shape == "newdoor4_r" || 
%shape == "newdoor6_l" ||
%shape == "newdoor6_r"	||
%shape == "forcefield_4x14" ||
%shape == "forcefield_4x8" ||
%shape == "forcefield_5x5" || 
%shape == "door_4x4_diagonal" ||
%shape == "tower" ||
%shape == "camera" ||
%shape == "hellfiregun" ||
%shape == "mortar_turret" ||
%shape == "ammounit" || 
%shape == "sensor_pulse_med" ||
%shape == "station_cmdpnl" ||
%shape == "missileturret" ||
%shape == "cmdpnl" ||
%shape == "radar" ||
%shape == "anten_lava" ||
%shape == "vehi_pur_poles")
{
return 0;
}
return 1;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	if ($debug) 
		echo  ("Hacking");
	if(%time > 0){
		if($hacking[%client] == "true"){		
			$NappyPort::hackP[%client] = %pName; $NappyPort::hackT[%client] = %tName; $NappyPort::hackN[%client] = %name; // PORT: names are no longer spliced into the script text
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "',$NappyPort::hackP[" @ %client @ "],$NappyPort::hackT[" @ %client @ "],$NappyPort::hackN[" @ %client @ "],'" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
			return;
		}
	}
	else if ((%time < 0 || %time == 0) && $hacking[%client] == "true"){
		if ($debug) 
			echo ("PT - " @ %pteam @ "");
		if ($debug) 
			echo ("TT - " @ %team @ "");
		if ($debug) 
			echo ("HK - " @ $hacking[%client] @ "");
		if ($debug) 
			echo ("TG - " @ %target @ "");
		if ($debug) 
			echo ("Tm - " @ %time @ "");
		if($hacking[%client] == "true"){
			if(%team == %pTeam){
				if ($debug) 
					echo ("infecting");
				%target.infected = "true";
				schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.1);
				Client::sendMessage(%client,1,"Your " @ %name @ " is now protected by viral infection, from hacking.");
				return;
			}
			else{
				if (%target.infected == "true"){
					%rnd = floor(getRandom() * 100);	
					if (%rnd > 50){
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You disarm the protection virus in the " @ %name @ ", but it costs you!!!");
						%player = Client::getOwnedObject(%client);
						Player::blowUp(%this);
						GameBase::applyDamage(%player,$FlashDamageType,0.90,GameBase::getPosition(%player),"0 0 0","0 0 0",%target);
						%target.infected = "false";
						return;
					}
					else{
						schedule ("playSound(TargetingMissile,GameBase::getPosition(" @ %target @ "));",0.2);
						Client::sendMessage(%client,1,"You safely disarm the protection virus in the " @ %name @ ".");					
						%target.infected = "false";
						return;
					}
				}
				if(%name == "False" && %shape == "magcargo"){
					%rnd = floor(getRandom() * 10);
					if(%rnd == 1){	
						Client::sendMessage(%client,1,"OOPS! You cut the wrong wire...");
						schedule("Mine::Detonate(" @ %this @ ");",0,%this);
						return;
					}
					else{	
						Client::sendMessage(%client,1,"You disarm the DetPack.");
						%client.score = %client.score + 2;
						Game::refreshClientScore(%client);
						deleteObject(%target);
					}
				}
				else{
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);
					if($Shifter::HackedTime > 0){
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $Shifter::HackedTime);
					}
					if(%target < $minHacked || $minHacked == -1){
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1){
						$maxHacked = %target;
					}
				}
			}
		}
	}
}


ItemImageData HackitImage
{
   shapeFile = "repairgun";
   mountPoint = 0;
   weaponType = 2; // Sustained
   projectileType = "HackBolt";
   minEnergy = 5;
   maxEnergy = 12;
   lightType   = 3;  // Weapon Fire
   lightRadius = 1;
   lightTime   = 1;
   lightColor  = { 0.25, 0.25, 0.85 };
   sfxFire     = SoundRepairItem;
   sfxActivate = SoundPickUpWeapon;
};

ItemData Hackit
{
   description   = "Hack-Gun";
   className     = "Tool";
   shapeFile     = "repairgun";
   hudIcon       = "targetlaser";
   heading = "dTools";
   shadowDetailMask = 4;
   imageType     = HackitImage;
   price         = 420;
   showWeaponBar = true;
};





//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Jail Gun
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================



ItemImageData JailGunImage
{
   shapeFile = "shotgun";
   mountPoint = 0;
   weaponType = 2;
   projectileType = jailbolt;
   minEnergy = 5;
   maxEnergy = 80;
   reloadTime = 4.0;
   lightType = 3;
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire = SoundELFIdle;
};

ItemData JailGun
{
   heading = "dTools";
   description = "Jail-Gun";
   className = "Tool";
   shapeFile  = "paintgun";
   shadowDetailMask = 4;
   imageType = JailGunImage;
   price = 420;
   showWeaponBar = true;
};



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Packit
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData PackitImage
{
   shapeFile = "repairgun";
   mountPoint = 0;
   weaponType = 2; // Sustained
   projectileType = "PackBolt";
   minEnergy = 5;
   maxEnergy = 12;
   lightType   = 3;  // Weapon Fire
   lightRadius = 1;
   lightTime   = 1;
   lightColor  = { 0.25, 0.25, 0.85 };
   sfxFire     = SoundRepairItem;
   sfxActivate = SoundPickUpWeapon;
};

ItemData Packit
{
   description   = "Pack-Gun";
   className     = "Tool";
   shapeFile     = "repairgun";
   hudIcon       = "targetlaser";
   heading = "dTools";
   shadowDetailMask = 4;
   imageType     = PackitImage;
   price         = 420;
   showWeaponBar = true;
};



//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Vehicle Repair Gun
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData VehicleRepairGunImage
{
   shapeFile = "repairgun";
   mountPoint = 0;
   weaponType = 2; // Sustained
   projectileType = "VehicleRepairBolt";
   minEnergy = 5;
   maxEnergy = 12;
   lightType   = 3;  // Weapon Fire
   lightRadius = 1;
   lightTime   = 1;
   lightColor  = { 0.25, 0.25, 0.85 };
   sfxFire     = SoundRepairItem;
   sfxActivate = SoundPickUpWeapon;
};

ItemData VehicleRepairGun
{
   description   = "Vehicle Repair Gun";
   className     = "Tool";
   shapeFile     = "repairgun";
   hudIcon       = "targetlaser";
   heading = "dTools";
   shadowDetailMask = 4;
   imageType     = VehicleRepairGunImage;
   price         = 420;
   showWeaponBar = true;
};










//========================================================================
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//                              Vehicle Packit
//[][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][][]
//========================================================================

ItemImageData VehiclePackitImage
{
   shapeFile = "repairgun";
   mountPoint = 0;
   weaponType = 2; // Sustained
   projectileType = "VehiclePackBolt";
   minEnergy = 5;
   maxEnergy = 12;
   lightType   = 3;  // Weapon Fire
   lightRadius = 1;
   lightTime   = 1;
   lightColor  = { 0.25, 0.25, 0.85 };
   sfxFire     = SoundRepairItem;
   sfxActivate = SoundPickUpWeapon;
};

ItemData VehiclePackit
{
   description   = "Vehicle Pack-Gun";
   className     = "Tool";
   shapeFile     = "repairgun";
   hudIcon       = "targetlaser";
   heading       = "dTools";
   shadowDetailMask = 4;
   imageType     = VehiclePackitImage;
   price         = 420;
   showWeaponBar = true;
};














//============================================================================================= 
//================================================================= Quad Mortar =============== 
//============================================================================================= 
 
// Mortar One 
ItemData MortarOneAmmo { 
description = "Mortar One Ammo"; 
className = "Ammo"; 
shapeFile = "ammo1"; 
header = "xAmmunition"; 
shadowDetailMask = 4; 
        price = 7; }; 
 
ItemImageData MortarOneImage { 
shapeFile = "mortargun"; 
mountPoint = 0; 
mountOffset = { 0.2, 0, -0.2 }; 
ammoType = MortarOneAmmo; 
weaponType = 0; 
accuFire = False; 
reloadTime = 0.01; 
fireTime = 0.01; 
projectileType = mortarShell; }; 
 
ItemData MortarOne { 
description = "Mortar One"; 
className = "Weapon"; 
shapeFile = "mortargun"; 
hudIcon = "mortar"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = MortarOneImage; 
price = 400; 
showWeaponBar = False; 
showInventory = False; }; 
 
// Mortar Two 
ItemData MortarTwoAmmo { 
description = "Mortar Two Ammo"; 
className = "Ammo"; 
shapeFile = "ammo1"; 
header = "xAmmunition"; 
shadowDetailMask = 4; 
        price = 7; }; 
 
ItemImageData MortarTwoImage { 
shapeFile = "mortargun"; 
mountPoint = 0; 
mountOffset = { 0.2, 0, 0.2 }; 
ammoType = MortarTwoAmmo; 
weaponType = 0; 
accuFire = False; 
reloadTime = 0.01; 
fireTime = 0.01; 
projectileType = mortarShell; }; 
 
ItemData MortarTwo { 
description = "Mortar Two"; 
className = "Weapon"; 
shapeFile = "mortargun"; 
hudIcon = "mortar"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = MortarTwoImage; 
price = 400; 
showWeaponBar = False; 
showInventory = False; }; 
 
// Mortar Three 
ItemData MortarThreeAmmo { 
description = "Mortar Three Ammo"; 
className = "Ammo"; 
shapeFile = "ammo1"; 
header = "xAmmunition"; 
shadowDetailMask = 4; 
        price = 7; }; 
 
ItemImageData MortarThreeImage { 
shapeFile = "mortargun"; 
mountPoint = 0; 
mountOffset = { -0.25, 0, 0.25 }; 
ammoType = MortarThreeAmmo; 
weaponType = 0; 
accuFire = False; 
reloadTime = 0.01; 
fireTime = 0.01; 
projectileType = mortarShell; }; 
 
ItemData MortarThree { 
description = "Mortar Three"; 
className = "Weapon"; 
shapeFile = "mortargun"; 
hudIcon = "mortar"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = MortarThreeImage; 
price = 400; 
showWeaponBar = False; 
showInventory = False; }; 
 
//Mortar Four 
ItemData MortarFourAmmo { 
description = "Mortar Four Ammo"; 
className = "Ammo"; 
shapeFile = "ammo1"; 
header = "xAmmunition"; 
shadowDetailMask = 4; 
        price = 7; }; 
 
ItemImageData MortarFourImage { 
shapeFile = "mortargun"; 
mountPoint = 0; 
mountOffset = { -0.2, 0, -0.2 }; 
ammoType = MortarFourAmmo; 
weaponType = 0; 
accuFire = False; 
reloadTime = 0.01; 
fireTime = 0.01; 
projectileType = mortarShell; }; 
 
ItemData MortarFour { 
description = "Mortar Four"; 
className = "Weapon"; 
shapeFile = "mortargun"; 
hudIcon = "mortar"; 
heading = "bWeapons"; 
shadowDetailMask = 4; 
imageType = MortarFourImage; 
price = 400; 
showWeaponBar = False; 
showInventory = False; }; 
 
// The Gun Itself 
ItemData QuadMortarAmmo { 
description = "Quad Mortar Ammo"; 
className = "Ammo"; 
shapeFile = "ammo1"; 
header = "xAmmunition"; 
shadowDetailMask = 4; 
        price = 7; }; 
 
ItemImageData QuadMortarImage {  
shapeFile = "breath";  
mountPoint = 0;  
weaponType = 0;  
ammoType = QuadMortarAmmo;  
accuFire = false;  
reloadTime = 0.1;  
fireTime = 0.1;  
sfxFire = SoundFireMortar;  
sfxActivate = SoundPickUpWeapon;  
sfxReload = SoundMortarReload;  
sfxReady = SoundMortarIdle;  
};  
 
ItemData QuadMortar {  
description = "Quad Mortar";  
className = "Weapon";  
shapeFile = "mortargun";  
hudIcon = "mortar";  
heading = "bWeapons";  
shadowDetailMask = 4;  
imageType = QuadMortarImage;  
price = 420;  
showWeaponBar = true;  
};  
 
function QuadMortar::onMount(%player,%imageSlot) 
{ 
%num = Player::getItemCount(%player, "QuadMortarAmmo"); 
Player::setItemCount(%player, "MortarOneAmmo", %num); 
Player::mountItem(%player,MortarOne,4);  
Player::setItemCount(%player, "MortarTwoAmmo", %num); 
Player::mountItem(%player,MortarTwo,5); 
Player::setItemCount(%player, "MortarThreeAmmo", %num); 
Player::mountItem(%player,MortarThree,6);  
Player::setItemCount(%player, "MortarFourAmmo", %num); 
Player::mountItem(%player,MortarFour,7);  
} 
 
function QuadMortarImage::onFire(%player, %slot)  
{  
%state1 = Player::getItemState(%player,4); 
%state2 = Player::getItemState(%player,5); 
%state3 = Player::getItemState(%player,6); 
%state4 = Player::getItemState(%player,7); 
if (%state1 != "Fire" && %state1 != "Reload"  
&& %state2 != "Fire" && %state2 != "Reload"  
&& %state3 != "Fire" && %state3 != "Reload"  
&& %state4 != "Fire" && %state4 != "Reload")  
{ 
%client = GameBase::getOwnerClient(%player);  
Player::decItemCount(%player, "QuadMortarAmmo", 1); 
Player::trigger(%player,4,true); 
Player::trigger(%player,5,true); 
Player::trigger(%player,6,true); 
Player::trigger(%player,7,true); 
Player::trigger(%player,4,false); 
Player::trigger(%player,5,false); 
Player::trigger(%player,6,false); 
Player::trigger(%player,7,false); 
}  
} 
 
 
function QuadMortar::onUnmount(%player,%imageSlot) 
{ 
Player::unmountItem(%player,4);  
Player::unmountItem(%player,5);  
Player::unmountItem(%player,6);  
Player::unmountItem(%player,7);  
}





