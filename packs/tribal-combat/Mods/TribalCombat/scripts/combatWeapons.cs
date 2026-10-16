//**********************
// TRIBAL COMBAT WEAPONS
//**********************
//mount offset
//0 Left/Right
//1 Forward/Back
//2 Up/Down
//mountRotation
//0 up/down plane (z) + up/- down
//1 rotates the weapon around the y axis +/-
//2 left/right plane (x) + left/- right

$AutoUse[Blaster] = True;
$AutoUse[EDGun] = True;
$AutoUse[FusionRifle] = True;
$AutoUse[GaussRifle] = True;
$AutoUse[SilencedPistol] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[Chaingun] = True;
$AutoUse[HvyChaingun] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[KineticRifle] = True;
$AutoUse[AutoCannon] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[PlasmaRepeater] = True;
$AutoUse[EnergyCannon] = True;
$AutoUse[Mortar] = True;
$AutoUse[AMortar] = True;
$AutoUse[RocketLauncher] = True;
$AutoUse[MissileLauncher] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[CutterBeam] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TransferGun] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = True;
$AutoUse[FieldRepairGun] = False;
$AutoUse[DemoCharge] = False;

$Use[Blaster] = True;

// Weapon to ammo table
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[EDGun] = "";
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[CutterBeam] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[TransferGun] = "";
$WeaponAmmo[DemoCharge] = "";
$WeaponAmmo[EnergyCannon] = "";
$WeaponAmmo[FusionRifle] = FusionPack;
$WeaponAmmo[GaussRifle] = GaussAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[PlasmaRepeater] = PlasmaAmmo;
$WeaponAmmo[SilencedPistol] = PistolAmmo;
$WeaponAmmo[SniperRifle] = SniperAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[HvyChaingun] = HvyBulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[KineticRifle] = KineticAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = MortarAmmo;
$WeaponAmmo[AMortar] = MortarAmmo;
$WeaponAmmo[RocketLauncher] = RLAmmo;
$WeaponAmmo[MissileLauncher] = MLAmmo;
$WeaponAmmo[AutoCannon] = ACAmmo;

$NextWeapon[Blaster] = EDGun;
$NextWeapon[EDGun] = FusionRifle;
$NextWeapon[FusionRifle] = GaussRifle;
$NextWeapon[GaussRifle] = PlasmaGun;
$NextWeapon[PlasmaGun] = PlasmaRepeater;
$NextWeapon[PlasmaRepeater] = EnergyCannon;
$NextWeapon[EnergyCannon] = SilencedPistol;
$NextWeapon[SilencedPistol] = SniperRifle;
$NextWeapon[SniperRifle] = Chaingun;
$NextWeapon[Chaingun] = HvyChaingun;
$NextWeapon[HvyChaingun] = AutoCannon;
$NextWeapon[AutoCannon] = DiscLauncher;
$NextWeapon[DiscLauncher] = KineticRifle;
$NextWeapon[KineticRifle] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = AMortar;
$NextWeapon[AMortar] = RocketLauncher;
$NextWeapon[RocketLauncher] = MissileLauncher;
$NextWeapon[MissileLauncher] = LaserRifle;
$NextWeapon[LaserRifle] = CutterBeam;
$NextWeapon[CutterBeam] = EnergyRifle;
$NextWeapon[EnergyRifle] = TransferGun;
$NextWeapon[TransferGun] = FieldRepairGun;
$NextWeapon[FieldRepairGun] = DemoCharge;
$NextWeapon[DemoCharge] = Blaster;

$PrevWeapon[Blaster] = DemoCharge;
$PrevWeapon[EDGun] = Blaster;
$PrevWeapon[FusionRifle] = EDGun;
$PrevWeapon[GaussRifle] = FusionRifle;
$PrevWeapon[PlasmaGun] = GaussRifle;
$PrevWeapon[PlasmaRepeater] = PlasmaGun;
$PrevWeapon[EnergyCannon] = PlasmaRepeater;
$PrevWeapon[SilencedPistol] = EnergyCannon;
$PrevWeapon[SniperRifle] = SilencedPistol;
$PrevWeapon[Chaingun] = SniperRifle;
$PrevWeapon[HvyChaingun] = Chaingun;
$PrevWeapon[AutoCannon] = HvyChaingun;
$PrevWeapon[DiscLauncher] = AutoCannon;
$PrevWeapon[KineticRifle] = DiscLauncher;
$PrevWeapon[GrenadeLauncher] = KineticRifle;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[AMortar] = Mortar;
$PrevWeapon[RocketLauncher] = AMortar;
$PrevWeapon[MissileLauncher] = RocketLauncher;
$PrevWeapon[LaserRifle] = MissileLauncher;
$PrevWeapon[CutterBeam] = LaserRifle;
$PrevWeapon[EnergyRifle] = CutterBeam;
$PrevWeapon[TransferGun] = EnergyRifle;
$PrevWeapon[FieldRepairGun] = TransferGun;
$PrevWeapon[DemoCharge] = FieldRepairGun;

//*****************
function resetWeaponModes(%client)
{
$WeaponMode[SilencedPistol,%client] = "";
$WeaponMode[Chaingun,%client] = "";
$WeaponMode[HvyChaingun,%client] = "";
$WeaponMode[AutoCannon,%client] = "";
$WeaponMode[GrenadeLauncher,%client] = "";
$WeaponMode[AMortar,%client] = "";
$WeaponMode[RocketLauncher,%client] = "";
$WeaponMode[MissileLauncher,%client] = "";
}

//*****************
function remoteWeaponModeNext(%client)
{
 %weapon = Player::getMountedItem(%client,$WeaponSlot);

 if(%weapon == -1) return;

 if($Combat::DisableWeaponMode)
 {
  bottomprint(%client,"<jc>Weapon mode switching is disabled in simulated base mode.");
  $WeaponMode[%weapon,%client] = false;
  return;
 }

 if($WeaponMode[%weapon,%client])
 {
  if(%weapon == Chaingun)
  {
   bottomprint(%client,"<jc>5.7mm Chaingun set to regulated fire mode.");
   $WeaponMode[%weapon,%client] = false;
  }
  else if(%weapon == HvyChaingun)
  {
   bottomprint(%client,"<jc>14.5mm Chaingun set to accurate fire mode.");
   $WeaponMode[%weapon,%client] = false;
  }
  else if(%weapon == SilencedPistol)
  {
   bottomprint(%client,"<jc>12mm Machine Pistol set to burst fire mode.");
   $WeaponMode[%weapon,%client] = false;
  }
  else if(%weapon == AutoCannon)
  {
   bottomprint(%client,"<jc>25mm Auto Cannon set to HEAP rounds.");
   $WeaponMode[%weapon,%client] = false;
  }
  else if(%weapon == GrenadeLauncher)
  {
   bottomprint(%client,"<jc>GrenadeLauncher set to regular fire mode.");
   $WeaponMode[%weapon,%client] = false;
  }
  else if(%weapon == AMortar)
  {
   bottomprint(%client,"<jc>Assault Mortar set to normal fire mode.");
   $WeaponMode[%weapon,%client] = false;
  }
  else if(%weapon == RocketLauncher)
  {
   bottomprint(%client,"<jc>Rocket Launcher set to Single fire mode.");
   $WeaponMode[%weapon,%client] = false;
  }
  else if(%weapon == MissileLauncher)
  {
   bottomprint(%client,"<jc>Missile Launcher set to Auto Target mode.");
   $WeaponMode[%weapon,%client] = false;
  }
  else return;

  %player = Client::getOwnedObject(%client);
  GameBase::playSound(%player,SoundDryFire,0);
 }
 else remoteWeaponModePrev(%client);
}

function remoteWeaponModePrev(%client)
{
 %weapon = Player::getMountedItem(%client,$WeaponSlot);
 if(%weapon == -1) return;

 if($Combat::DisableWeaponMode)
 {
  bottomprint(%client,"<jc>Weapon mode switching is disabled in simulated base mode.");
  $WeaponMode[%weapon,%client] = false;
  return;
 }
 
 if(!$WeaponMode[%weapon,%client])
  {
   if(%weapon == Chaingun)
   {
    bottomprint(%client,"<jc>5.7mm Chaingun set to Very Rapid Fire mode.");
	$WeaponMode[%weapon,%client] = true;
   }
   else if(%weapon == HvyChaingun)
   {
    bottomprint(%client,"<jc>14.5mm Chaingun set to spread fire mode.");
	$WeaponMode[%weapon,%client] = true;
   }
  else if(%weapon == SilencedPistol)
  {
   bottomprint(%client,"<jc>12mm Machine Pistol set to silent fire mode.");
   $WeaponMode[%weapon,%client] = true;
  }
   else if(%weapon == AutoCannon)
   {
    bottomprint(%client,"<jc>25mm Auto Cannon set to HVAP Rounds.");
	$WeaponMode[%weapon,%client] = true;
   }
   else if(%weapon == GrenadeLauncher)
   {
    bottomprint(%client,"<jc>GrenadeLauncher set to AGL fire mode.");
	$WeaponMode[%weapon,%client] = true;
   }
   else if(%weapon == AMortar)
   {
    bottomprint(%client,"<jc>Assault Mortar set to Close Quarters fire mode.");
	$WeaponMode[%weapon,%client] = true;
   }
   else if(%weapon == RocketLauncher)
   {
    bottomprint(%client,"<jc>Rocket Launcher set to Salvo fire mode.");
	$WeaponMode[%weapon,%client] = true;
   }
   else if(%weapon == MissileLauncher && !$Combat::NoDrones)
   {
    bottomprint(%client,"<jc>Missile Launcher set to Guidance mode.");
	$WeaponMode[%weapon,%client] = true;
   }
   else return;

  %player = Client::getOwnedObject(%client);
  GameBase::playSound(%player,SoundDryFire,0);
  }
  else remoteWeaponModeNext(%client);
}

//**********************
// Tools, Weapons & ammo
ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
 if(%player.Station == "")
 {
  %client = Player::getClient(%player);
  Player::mountItem(%player,%item,$ToolSlot);
  Weapon::showMessage(%client,%item);
 }
}

//***********
ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
 %client = Player::getClient(%player);
 if(%client.observerMode != "") return;

 if($matchStarted) 
 {
  if((GameBase::getOwnerClient(%player) == -1) || Player::isDead(%player)) return;
  
  %count = Player::getItemCount(%player,%item);
  %delta = $SellAmmo[%item];
  if(%count <= %delta) 
  { 
   if(%item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) %delta = %count;
   else %delta = %count - 1;
  }
  if(%delta > 0) 
  {
   %obj = newObject("","Item",%item,%delta,false);
   schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
   addToSet("MissionCleanup", %obj);
   GameBase::throw(%obj,%player,20,false);
   Item::playPickupSound(%obj);
   if(!Player::isDead(%this)) Player::decItemCount(%player,%item,%delta);
  }
 }
}	

//*******************
function remoteNextWeapon(%client)
{
 if(%client.observerMode != "") return;
 %item = Player::getMountedItem(%client,$WeaponSlot);
 if(%item == -1 || $NextWeapon[%item] == "") selectValidWeapon(%client);
 else 
 {
  for(%weapon = $NextWeapon[%item]; %weapon != %item;%weapon = $NextWeapon[%weapon]) 
  {
   if(isSelectableWeapon(%client,%weapon)) Player::useItem(%client,%weapon);
  }
 }
}

//******************
function remotePrevWeapon(%client)
{
    if(%client.observerMode != "") return;
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if(%item == -1 || $PrevWeapon[%item] == "") selectValidWeapon(%client);
	else 
	{
		for(%weapon = $PrevWeapon[%item]; %weapon != %item;%weapon = $PrevWeapon[%weapon]) 
		{
			if (isSelectableWeapon(%client,%weapon)) 
			{
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if(Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
				   Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
				   {
					bottomprint(%client,"<jc>"@weapon.description@" selected");
				    break;
					}
			}
		}
	}
}

//*****************
function selectValidWeapon(%client)
{
	%item = EnergyRifle;
	for (%weapon = $NextWeapon[%item]; %weapon != %item;%weapon = $NextWeapon[%weapon]) 
	{
		if (isSelectableWeapon(%client,%weapon)) 
		{
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

//****************
function isSelectableWeapon(%client,%weapon)
{
 if((Client::getOwnedObject(%client) == -1) || Player::isDead(%client)) return false;
 
 if(Player::getItemCount(%client,%weapon)) return true;
 else return false;
}

//*************
ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if(%state != "Fire" && %state != "Reload") Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{
 %client = Player::getClient(%player);
 if(%client.observerMode != "") return;

 if((GameBase::getOwnerClient(%player) == -1) || Player::isDead(%player)) return;

 if(%player.Station=="")
 {
  %ammo = %item.imageType.ammoType;
  if(%ammo != "" && Player::getItemCount(%player,%ammo) < 1) Client::sendMessage(Player::getClient(%player),0,strcat(%item.description," has no ammo"));
  Player::mountItem(%player,%item,$WeaponSlot);
  Weapon::showMessage(%client,%item);
 }
}

function Weapon::applyRecoil(%player,%force)
{

//DISABLED 
return;

 %client = Player::getClient(%player);
 if(!$Combat::playerProne[%client])
 {
	%armor = Player::getArmor(%player);
	%rot = GameBase::getRotation(%player);
	%recoil = ((%force * %force) / %armor.mass) * -1.0;
	%vect = Vector::getFromRot(%rot,%recoil,0);
	Player::applyImpulse(%player,%vect);
 }
//echo("Recoil: "@%recoil@" "@%vect);
}

function Weapon::showMessage(%client,%item)
{
 if(%item == SilencedPistol)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - Silent Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - Burst Fire Mode");
 }
 else if(%item == Chaingun)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - VRF Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - Regulated Fire Mode");
 }
 else if(%item == HvyChaingun)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - Spread Fire Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - Accurate Fire Mode");
 }
 else if(%item == AutoCannon)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - HVAP Fire Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - HEAP Fire Mode");
 }
 else if(%item == GrenadeLauncher)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - AGL Fire Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - Normal Fire Mode");
 }
 else if(%item == AMortar)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - Close Quaters Fire Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - Normal Fire Mode");
 }
 else if(%item == RocketLauncher)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - Salvo Fire Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - Single Fire Mode");
 }
 else if(%item == MissileLauncher)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - Guidance Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - AutoTarget Mode");
 }
 else
 {
  bottomprint(%client,"<jc>"@%item.description@" selected");
 }
}
//------------------------

ItemImageData BlasterImage
{
    shapeFile  = "energygun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 7;
	maxEnergy = 9;
	projectileType = BlasterBolt;
	accuFire = true;
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
    heading = "bGeneralWeapons";
	description = "Blaster";
	className = "Weapon";
    shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 45;
	showWeaponBar = true;
};

//*************************
ItemImageData EDGunImage
{
    shapeFile  = "paintgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 20;
	accuFire = true;
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EDGun
{
    heading = "cLightWeapons";
	description = "EDGun";
	className = "Weapon";
    shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = EDGunImage;
	price = 60;
	showWeaponBar = true;
};

function EDGun::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == ShieldPack) Weapon::onUse(%player,%item);
	else Client::sendMessage(Player::getClient(%player),1,"You must have a Shield Pack to use the EDGun."); 
}

function EDGunImage::onFire(%this,%slot)
{
 %client = Player::getClient(%this);
 %trans = GameBase::getMuzzleTransform(%client);
 %vel = Item::getVelocity(%client);
 Projectile::spawnProjectile(EDGunBolt,%trans,%this,%vel);
 Projectile::spawnProjectile(ShieldKiller,%trans,%this,%vel);
}

//*************************
ItemData FusionPack
{
	description = "Fusion Pack";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 100;
};

ItemImageData FusionRifleImage
{
    shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.15;
	fireTime = 0.15;
	ammoType = FusionPack;

	projectileType = MiniFusionBolt;
	accuFire = true;

	sfxFire = SoundEnergyTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FusionRifle
{
    heading = "bGeneralWeapons";
	description = "Fusion Rifle";
	className = "Weapon";
    shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FusionRifleImage;
	price = 80;
	showWeaponBar = true;
};

//*************************
ItemData GaussAmmo
{
	description = "23mm Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData GaussRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
    mountOffset = { -0.1, -0.6, 0.3 }; 
	weaponType = 0; // Single Shot
	ammoType = GaussAmmo;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.3;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxActivate = SoundPickUpWeapon;
};

ItemData GaussRifle
{
	description = "23mm Gauss Cannon";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = GaussRifleImage;
	price = 350;
	showWeaponBar = true;
};

function GaussRifleImage::onFire(%this,%slot)
{
 %client = Player::getClient(%this);
 %weapon = Player::getMountedItem(%client,$WeaponSlot);
 %trans = GameBase::getMuzzleTransform(%client);
 %vel = Item::getVelocity(%client);
 Projectile::spawnProjectile(GaussBullet,%trans,%this,%vel);
 GameBase::playSound(%this,SoundMissileTurretFire,0);
 GameBase::playSound(%this,SoundPlasmaTurretFire,1);
 if(!Player::isDead(%this)) Player::decItemCount(%client,GaussAmmo,1);

 %energy = GameBase::getEnergy(%this);
 if(%energy > 60) %energy -= 60;
 else if($Combat::GaussDrain[%client] < 0) %energy= 0;
 else
 {
  GaussRifle::energyDrain(%this,%energy - 60);
  bottomprint(%client,"<jc>Your energy systems have been dampened.");
  %energy = 0;
 }
 GameBase::setEnergy(%this,%energy);
}

function GaussRifle::energyDrain(%this,%energy)
{
 if((GameBase::getOwnerClient(%this) == -1) || Player::isDead(%this)) return;
 %client = Player::getClient(%this);
 $Combat::GaussDrain[%client] = %energy;
 if($Combat::GaussDrain[%client] > 0) GameBase::setRechargeRate(%this,8);
 else
 {
  GameBase::setRechargeRate(%this,2);
  $Combat::GaussDrain[%client] += 10;
  schedule("GaussRifle::energyDrain("@%this@","@$Combat::GaussDrain[%client]@");",5,%this);
 }
}

//*************************
ItemData ACAmmo
{
	description = "25mm Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 3;
};

ItemImageData AutoCannonImage
{
	shapeFile = "chaingun";
    mountPoint = 0;
    mountOffset = { -0.2, -0.5, 0.5 }; 
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.6;
	spinDownTime = 1.5;
	fireTime = 0.65;
	ammoType = ACAmmo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData AutoCannon
{
	description = "25mm AutoCannon";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = AutoCannonImage;
	price = 450;
	showWeaponBar = true;
};

function AutoCannonImage::onFire(%this,%slot)
{
    %client = Player::getClient(%this);
    %weapon = Player::getMountedItem(%client,$WeaponSlot);
    %trans = GameBase::getMuzzleTransform(%client);
    %vel = Item::getVelocity(%client);
	if(!$WeaponMode[%weapon,%client]) Projectile::spawnProjectile(HEAPShell,%trans,%this,%vel);
	else Projectile::spawnProjectile(HVAPShell,%trans,%this,%vel);
	GameBase::playSound(%this,shockExplosion,0);
	GameBase::playSound(%this,debrisSmallExplosion,1);
	if(!Player::isDead(%this)) Player::decItemCount(%client,ACAmmo,1);
	Weapon::applyRecoil(%this,24.0);
}

//*************************
ItemData HvyBulletAmmo
{
	description = "14.5mm Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData HvyChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 2.5;
	fireTime = 0.1;
	ammoType = HvyBulletAmmo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData HvyChaingun
{
	description = "14.5mm Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = HvyChaingunImage;
	price = 250;
	showWeaponBar = true;
};

function HvyChaingunImage::onFire(%this,%slot)
{
    %client = Player::getClient(%this);
    %weapon = Player::getMountedItem(%client,$WeaponSlot);
    %trans = GameBase::getMuzzleTransform(%client);
    %vel = Item::getVelocity(%client);
	if(!$WeaponMode[%weapon,%client])
	{
	 Projectile::spawnProjectile(HvyChaingunBullet,%trans,%this,%vel);
	 Weapon::applyRecoil(%this,15.0);
     if(!Player::isDead(%this)) Player::decItemCount(%client,HvyBulletAmmo,1);
	}
	else
	{
	 Projectile::spawnProjectile(HvyBulletSpread,%trans,%this,%vel);
	 Projectile::spawnProjectile(HvyBulletSpread,%trans,%this,%vel);
	 Weapon::applyRecoil(%this,20.0);
     if(!Player::isDead(%this)) Player::decItemCount(%client,HvyBulletAmmo,2);
	}
}

//******************************************
ItemData PistolAmmo
{
	description = "12mm Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SilencedPistolImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.25;
	fireTime = 0.25;
	ammoType = PistolAmmo;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundPickUpWeapon;
};

ItemData SilencedPistol
{
	description = "12mm Machine Pistol";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "chain";
    heading = "cLightWeapons";
	shadowDetailMask = 4;
	imageType = SilencedPistolImage;
	price = 250;
	showWeaponBar = true;
};

function SilencedPistolImage::onFire(%this,%slot)
{
 if((GameBase::getOwnerClient(%this) == -1) || Player::isDead(%this)) return;

 %client = Player::getClient(%this);
 if(%client.observerMode != "") return;

 %weapon = Player::getMountedItem(%client,$WeaponSlot);
 %trans = GameBase::getMuzzleTransform(%client);
 %vel = Item::getVelocity(%client);
 if(!$WeaponMode[%weapon,%client])
 {
  %ammo = Player::getItemCount(%this,"PistolAmmo");
  if(%ammo > 2)
  {
   if(!Player::isDead(%this)) Player::decItemCount(%client,PistolAmmo,3);
   schedule("SilencedPistol::repeatFire("@%this@","@3@");",0.01,%this);
  }
  else
  {
   Projectile::spawnProjectile(PistolBullet,%trans,%this,%vel);
   GameBase::playSound(%this,SoundFireMortar,0);
   if(!Player::isDead(%this)) Player::decItemCount(%client,PistolAmmo,1);
  }
 }
 else
 {
  Projectile::spawnProjectile(PistolBullet,%trans,%this,%vel);
  if(!Player::isDead(%this)) Player::decItemCount(%client,PistolAmmo,1);
 }
 if(%ammo == 1)
 {
//	 remoteNextWeapon(%client);
  Player::unmountItem(%this,$WeaponSlot);
 }
}

function SilencedPistol::repeatFire(%this,%repeat)
{
  if(%repeat == 0) return;
  %client = Player::getClient(%this);
  %trans = GameBase::getMuzzleTransform(%client);
  %vel = Item::getVelocity(%client);
  Projectile::spawnProjectile(MPistolBullet,%trans,%this,%vel);
  GameBase::playSound(%this,SoundFireMortar,0);
  %repeat--;
  schedule("SilencedPistol::repeatFire("@%this@","@%repeat@");",0.05,%this);
}

//-----------------
ItemData BulletAmmo
{
	description = "7mm Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.3;
	spinDownTime = 1.0;
	fireTime = 0.14;

	ammoType = BulletAmmo;
//	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "7mm Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    heading = "bGeneralWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function ChaingunImage::onFire(%this,%slot)
{
    %client = Player::getClient(%this);
    %weapon = Player::getMountedItem(%client,$WeaponSlot);
    %trans = GameBase::getMuzzleTransform(%client);
    %vel = Item::getVelocity(%client);
	if(!$WeaponMode[%weapon,%client])
	{
	 Projectile::spawnProjectile(ChaingunBullet,%trans,%this,%vel);
     if(!Player::isDead(%this)) Player::decItemCount(%client,BulletAmmo,1);
	}
	else
	{
     Projectile::spawnProjectile(VRPBullet,%trans,%this,%vel);
     Projectile::spawnProjectile(VRPBullet,%trans,%this,%vel);
     Projectile::spawnProjectile(VRPBullet,%trans,%this,%vel);
	 Weapon::applyRecoil(%this,12.0);
     if(!Player::isDead(%this)) Player::decItemCount(%client,BulletAmmo,3);
	}
}

//-----------------
ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
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
    heading = "bGeneralWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};

//*******************************
ItemImageData PlasmaRepeaterImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaRepeater
{
	description = "Plasma Repeater";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaRepeaterImage;
	price = 750;
	showWeaponBar = true;
};

function PlasmaRepeaterImage::onFire(%this,%slot)
{
 if((GameBase::getOwnerClient(%this) == -1) || Player::isDead(%this)) return;
 
 %client = Player::getClient(%this);
 if(%client.observerMode != "") return;

 %trans = GameBase::getMuzzleTransform(%client);
 %vel = Item::getVelocity(%client);
 Projectile::spawnProjectile(RepeaterBolt,%trans,%this,%vel);
 if(!Player::isDead(%this)) Player::decItemCount(%client,PlasmaAmmo,1);
 if(Player::getItemCount(%this,"CoolantPack") == 0)
 {
  GameBase::applyDamage(%this,$PlasmaDamageType,0.3,GameBase::getPosition(%client),"0 0 0","0 0 0",%this);
  bottomprint(%client,"<jc>Without the coolant pack the Plasma Repeater overheats while firing!",2);
 }
}

//*****************************
ItemImageData EnergyCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = CannonBolt;
	accuFire = true;
	reloadTime = 1.25;
	fireTime = 1.25;

	minEnergy = 35;
	maxEnergy = 55;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EnergyCannon
{
	description = "Energy Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = EnergyCannonImage;
	price = 400;
	showWeaponBar = true;
};

function EnergyCannon::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item);
	else Client::sendMessage(Player::getClient(%player),0,"Must have an Energy Pack to use the Energy Cannon."); 
}

//------------------
ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	accuFire = false;
	reloadTime = 0.4;
	fireTime = 0.4;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
    heading = "dMediumWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function GrenadeLauncherImage::onFire(%this,%slot)
{
 if((GameBase::getOwnerClient(%this) == -1) || Player::isDead(%this)) return;

 %client = Player::getClient(%this);
 if(%client.observerMode != "") return;

 %weapon = Player::getMountedItem(%client,$WeaponSlot);
 %trans = GameBase::getMuzzleTransform(%client);
 %vel = Item::getVelocity(%client);
 if(!$WeaponMode[%weapon,%client])
 {
  GameBase::playSound(%this,SoundFireGrenade,0);
  Projectile::spawnProjectile(GrenadeShell,%trans,%this,%vel);
  if(!Player::isDead(%this)) Player::decItemCount(%client,GrenadeAmmo,1);
 }
 else
 {
  %ammo = Player::getItemCount(%this,"GrenadeAmmo");
  if(%ammo > 1)
  {
   if(!Player::isDead(%this)) Player::decItemCount(%client,GrenadeAmmo,2);
   schedule("GrenadeLauncher::repeatFire("@%this@","@2@");",0.01,%this);
  }
  else
  {
   Projectile::spawnProjectile(ImpactGrenade,%trans,%this,%vel);
   GameBase::playSound(%this,SoundFireGrenade,0);
   if(!Player::isDead(%this)) Player::decItemCount(%client,GrenadeAmmo,1);
  }
 }
}

function GrenadeLauncher::repeatFire(%this,%repeat)
{
  if(%repeat == 0) return;
  %client = Player::getClient(%this);
  %trans = GameBase::getMuzzleTransform(%client);
  %vel = Item::getVelocity(%client);
  Projectile::spawnProjectile(ImpactGrenade,%trans,%this,%vel);
  GameBase::playSound(%this,SoundFireGrenade,0);
  %repeat--;
  schedule("GrenadeLauncher::repeatFire("@%this@","@%repeat@");",0.3,%this);
}

//*************
ItemData RLAmmo
{
	description = "Rocket Ammo";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData RocketLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = RLAmmo;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData RocketLauncher
{
	description = "RocketLauncher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = RocketLauncherImage;
	price = 500;
	showWeaponBar = true;
};

function RocketLauncherImage::onFire(%this,%slot)
{
 if((GameBase::getOwnerClient(%this) == -1) || Player::isDead(%this)) return;

 %client = Player::getClient(%this);
 if(%client.observerMode != "") return;

 %weapon = Player::getMountedItem(%client,$WeaponSlot);
 %trans = GameBase::getMuzzleTransform(%client);
 %vel = Item::getVelocity(%client);
 if(!$WeaponMode[%weapon,%client])
 {
  Projectile::spawnProjectile(FlierRocket,%trans,%this,%vel);
  Weapon::applyRecoil(%this,10.0);
  if(!Player::isDead(%this)) Player::decItemCount(%client,RLAmmo,1);
 }
 else
 {
  %ammo = Player::getItemCount(%this,"RLAmmo");
  if(%ammo > 3)
  {
   if(!Player::isDead(%this)) Player::decItemCount(%client,RLAmmo,4);
   schedule("rocketSalvo("@%this@","@4@");",0.1,%this);
  }
  else
  {
   if(!Player::isDead(%this)) Player::decItemCount(%client,RLAmmo,%ammo);
   schedule("rocketSalvo("@%this@","@%ammo@");",0.1,%this);
  }
 }
}

function rocketSalvo(%this,%repeat)
{
  if(%repeat == 0) return;
  %client = Player::getClient(%this);
  %trans = GameBase::getMuzzleTransform(%client);
  %vel = Item::getVelocity(%client);
  Projectile::spawnProjectile(MiniRocket,%trans,%this,%vel);
  Weapon::applyRecoil(%this,10.0 * %repeat);
  %repeat--;
  schedule("rocketSalvo("@%this@","@%repeat@");",0.15,%this);
}

//*************
ItemData MLAmmo
{
	description = "Missile Ammo";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData MissileLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MLAmmo;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData MissileLauncher
{
	description = "MissileLauncher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "bGeneralWeapons";
	shadowDetailMask = 4;
	imageType = MissileLauncherImage;
	price = 800;
	showWeaponBar = true;
};

function MissileLauncher::onUse(%player,%item)
{
	schedule("MissileLauncher::acquireTarget("@%player@");",2,%player);
	Weapon::onUse(%player,%item);
}

function MissileLauncherImage::onFire(%this,%slot)
{
    %client = Player::getClient(%this);
    %weapon = Player::getMountedItem(%client,$WeaponSlot);
    %trans = GameBase::getMuzzleTransform(%client);
    %vel = Item::getVelocity(%client);

	if(!$WeaponMode[%weapon,%client])
	{
	 if(GameBase::getLOSInfo(%this,1000))
	 {
	  %obj = getObjectType($los::object);
	  if(%obj == "Player" || %obj == "Flier") Projectile::spawnProjectile(homingMissile,%trans,%this,%vel,$los::object);
	  else Projectile::spawnProjectile(homingMissile,%trans,%this,%vel);
	 }
	 else Projectile::spawnProjectile(homingMissile,%trans,%this,%vel);
     if(!Player::isDead(%this)) Player::decItemCount(%client,MLAmmo,1);
	}
	else
	{
	 if(!%player.vehicle)
	 {
	  %rot = GameBase::getRotation(%client);
	  %posX = getWord(%trans,9);
	  %posY = getWord(%trans,10);
	  %posZ = getWord(%trans,11) + 3.0;
	  %position = %posX@" "@%posY@" "@%posZ;
	   
      %obj = newObject("Guided Missile",flier,GuidedMissile,true);
      addToSet("MissionCleanup",%obj);
      GameBase::setTeam(%obj,GameBase::getTeam(%this));
	  GameBase::setPosition(%obj,%position);
      GameBase::setRotation(%obj,%rot);
      Gamebase::setMapName(%obj,"Guided Missile");
      GameBase::startFadeIn(%obj);
      Client::setControlObject(%client,%obj);
      %this.vehicle = %obj;
      if(!Player::isDead(%this)) Player::decItemCount(%client,MLAmmo,1);
      %this.lastWeapon = %weapon;
	  Player::unMountItem(%this,$WeaponSlot);
	 }
	}
}

function MissileLauncher::acquireTarget(%player)
{
 %client = Player::getClient(%player);
 %weapon = Player::getMountedItem(%client,$WeaponSlot);
 if(%weapon == MissileLauncher)
 {
  if(GameBase::getLOSInfo(%player,1000))
  {
   %obj = getObjectType($los::object);
   if(%obj == "Player" || %obj == "Flier")
   {
	Client::sendMessage(%client,0,"~wLeftMissionArea.wav");
	bottomprint(%client,"<jc><f1>You have a valid lock");
   }
  }
  schedule("MissileLauncher::acquireTarget("@%player@");",2,%player);
 }
}

//*****************
ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
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
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
};

//************************
$ItemMax[larmor,AMortar] = 0;
$ItemMax[carmor,AMortar] = 0;
$ItemMax[marmor,AMortar] = 0;
$ItemMax[harmor,AMortar] = 1;
$ItemMax[darmor,AMortar] = 1;
$ItemMax[lfemale,AMortar] = 0;
$ItemMax[fcarmor,AMortar] = 0;
$ItemMax[mfemale,AMortar] = 0;

ItemImageData AMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData AMortar
{
	description = "Assault Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = AMortarImage;
	price = 400;
	showWeaponBar = true;
};

function AMortarImage::onFire(%this,%slot)
{
    %client = Player::getClient(%this);
    %weapon = Player::getMountedItem(%client,$WeaponSlot);
    %trans = GameBase::getMuzzleTransform(%client);
    %vel = Item::getVelocity(%client);
	if(!$WeaponMode[%weapon,%client]) Projectile::spawnProjectile(MortarShell,%trans,%this,%vel);
	else Projectile::spawnProjectile(srMortarShell,%trans,%this,%vel); 
    if(!Player::isDead(%this)) Player::decItemCount(%client,MortarAmmo,1);
}

//---------------
ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.9;
	spinUpTime = 0.2;

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
    heading = "bGeneralWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

//---------------------------
ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 4.0;
	fireTime = 0.1;
	minEnergy = 60;
	//10;
	maxEnergy = 110;
	//60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
    heading = "cLightWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item);
	else Client::sendMessage(Player::getClient(%player),0,"Must have an Energy Pack to use Laser Rifle."); 
}

//***************************
ItemImageData CutterBeamImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = cutterLaser;
	accuFire = true;
	reloadTime = 0.06;
	fireTime = 0.06;
	minEnergy = 4;
	maxEnergy = 4;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData CutterBeam
{
	description = "Pulse Laser";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
    heading = "dMediumWeapons";
	shadowDetailMask = 4;
	imageType = CutterBeamImage;
	price = 600;
	showWeaponBar = true;
};

function CutterBeam::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item);
	else Client::sendMessage(Player::getClient(%player),1,"You must have an Energy Pack to use the Pulse Laser."); 
}

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 3;
	maxEnergy = 10;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
    heading = "vTools";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

//------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
    mountPoint = 0;

    weaponType = 2;  // Sustained
	projectileType = lightningCharge;
    minEnergy = 3;
    maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
   shapeFile = "shotgun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bGeneralWeapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
   showWeaponBar = true;
   price = 125;
};

//********************************
ItemImageData TransferGunImage
{
   shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   projectileType = transferCharge;
   minEnergy = 5;
   maxEnergy = 10;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.85, 0.25, 0.25 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData TransferGun
{
   description = "Transfer Gun";
   shapeFile = "shotgun";
   hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bGeneralWeapons";
   shadowDetailMask = 4;
   imageType = TransferGunImage;
   showWeaponBar = true;
   price = 250;
};

function TransferGun::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == RepairPack) Weapon::onUse(%player,%item);
	else Client::sendMessage(Player::getClient(%player),0,"Must have a Repair Pack to use the Transfer Gun."); 
}

//********************************
ItemImageData FieldRepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };

	weaponType = 2;
	projectileType = RepairBolt;
	minEnergy  = 5;
	maxEnergy = 15;
	reloadTime = 0.2;

	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData FieldRepairGun
{
	description = "Field Repair Unit";
	shapeFile = "repairgun";
	hudIcon = "targetlaser";
	className = "Weapon"; //"Tool";
	heading = "vTools";
	shadowDetailMask = 4;
	imageType = FieldRepairGunImage;
	showWeaponBar = true;
	price = 150;
};

//********************************
ItemImageData DemoChargeImage
{
	shapeFile = "AmmoPack";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0 };

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 0;
	fireTime = 0;

	sfxActivate = SoundPickUpWeapon;
};

ItemData DemoCharge
{
	description = "Demolitions Satchel";
	className = "Weapon";
	shapeFile = "AmmoPack";
	hudIcon = "grenade";
    heading = "bGeneralWeapons";
	shadowDetailMask = 4;
	imageType = DemoChargeImage;
	price = 500;
	showWeaponBar = true;
};

function DemoChargeImage::onFire(%this,%slot)
{
    %client = GameBase::getOwnerClient(%this);
	%charge = newObject("","Mine",DemoGrenade);
   	addToSet("MissionCleanup", %charge);
	GameBase::throw(%charge,%client,3,false);
	centerprint(%client,"<jc>Demolitions charge deployed.",3);
	playSound(SoundPickupBackpack,$los::position);
	if(!Player::isDead(%this)) Player::decItemCount(%client,DemoCharge);
}

//*************************
ItemData SniperAmmo
{
	description = "12.5mm Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = {0,0,0};
	weaponType = 0; // Single Shot
	ammoType = SniperAmmo;
	accuFire = true;
	projectileType = SniperBullet;
	reloadTime = 1.25;
	fireTime = 0.55;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = shockExplosion;
	sfxReload = SoundMortarReload;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle
{
	description = "12.5mm Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
    heading = "dMediumWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 300;
	showWeaponBar = true;
};

//function SniperRifleImage::onFire(%this,%slot)
//{
//    %client = Player::getClient(%this);
//    %trans = GameBase::getMuzzleTransform(%client);
//    %vel = Item::getVelocity(%client);
//	%i = 0;
//	while(%i < 12)
//	{
//	 %transVal[%i] = getWord(%trans,%i);
//	 %i++;
//	}
//	%trans = %transVal[0]@" "@%transVal[1]@" "@%transVal[2]@" "@%transVal[3]@" "@%transVal[4]@" "@%transVal[5]@" "@%transVal[6]@" "@%transVal[7]@" "@%transVal[8]@" "@%transVal[9]@" "@%transVal[10]@" "@%transVal[11];
//echo(%trans);
//	Projectile::spawnProjectile(SniperBullet,%trans,%this,%vel);
//  Weapon::applyRecoil(%this,30);
//    if(!Player::isDead(%this)) Player::decItemCount(%client,SniperAmmo,1);
//}

//*************************
ItemData KineticAmmo
{
	description = "Particle Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData KineticRifleImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
    mountOffset = { -0.2, -0.85, 0.4 }; 
	weaponType = 0; // Single Shot
	ammoType = KineticAmmo;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.3;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 1 };
	sfxActivate = SoundPickUpWeapon;
};

ItemData KineticRifle
{
	description = "Particle Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = KineticRifleImage;
	price = 400;
	showWeaponBar = true;
};

function KineticRifleImage::onFire(%this,%slot)
{
  %client = Player::getClient(%this);
  schedule("kineticFire("@%this@","@8@");",0.01,%this);
  if(!Player::isDead(%this)) Player::decItemCount(%client,KineticAmmo,1);
}

function kineticFire(%this,%repeat)
{
  if(%repeat == 0) return;
  %client = Player::getClient(%this);
  %trans = GameBase::getMuzzleTransform(%client);
  %vel = Item::getVelocity(%client);
  Projectile::spawnProjectile(KineticBolt,%trans,%this,%vel);
  %repeat--;
  schedule("kineticFire("@%this@","@%repeat@");",0.12,%this);
}

//----------------------------
ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;

	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

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
	price = 125;
};

function RepairGun::onMount(%player,%imageSlot)
{
Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
Player::trigger(%player,$BackpackSlot,false);
}
