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
$AutoUse[GaussRifle] = True;
$AutoUse[SilencedPistol] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[Chaingun] = True;
$AutoUse[AssaultRifle] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[KineticRifle] = True;
$AutoUse[AutoCannon] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[PlasmaRepeater] = True;
$AutoUse[EnergyCannon] = True;
$AutoUse[Mortar] = True;
// $AutoUse[PPC] = True;
$AutoUse[RocketLauncher] = True;
$AutoUse[MissileLauncher] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TransferGun] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = True;
$AutoUse[FieldRepairGun] = False;
$AutoUse[DemoCharge] = False;
$AutoUse[NARCLauncher] = True;

$Use[Blaster] = True;

// Weapon to ammo table
$WeaponAmmo[Blaster] = FusionAmmo;
$WeaponAmmo[EDGun] = "";
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[TransferGun] = "";
$WeaponAmmo[DemoCharge] = "";
$WeaponAmmo[EnergyCannon] = "";
$WeaponAmmo[GaussRifle] = GaussAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[PlasmaRepeater] = FThrowerAmmo;
$WeaponAmmo[SilencedPistol] = PistolAmmo;
$WeaponAmmo[SniperRifle] = SniperAmmo;
$WeaponAmmo[Chaingun] = HvyBulletAmmo;
$WeaponAmmo[AssaultRifle] = ARAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[KineticRifle] = KineticAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = MortarAmmo;
// $WeaponAmmo[PPC] = "";
$WeaponAmmo[RocketLauncher] = RLAmmo;
$WeaponAmmo[MissileLauncher] = MLAmmo;
$WeaponAmmo[AutoCannon] = ACAmmo;
$WeaponAmmo[NARCLauncher] = NARCAmmo;

$NextWeapon[Blaster] = EDGun;
$NextWeapon[EDGun] = GaussRifle;
$NextWeapon[GaussRifle] = PlasmaGun;
$NextWeapon[PlasmaGun] = PlasmaRepeater;
$NextWeapon[PlasmaRepeater] = EnergyCannon;
$NextWeapon[EnergyCannon] = SilencedPistol;
$NextWeapon[SilencedPistol] = SniperRifle;
$NextWeapon[SniperRifle] = Chaingun;
$NextWeapon[Chaingun] = AssaultRifle;
$NextWeapon[AssaultRifle] = AutoCannon;
$NextWeapon[AutoCannon] = DiscLauncher;
$NextWeapon[DiscLauncher] = KineticRifle;
$NextWeapon[KineticRifle] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = RocketLauncher;
$NextWeapon[RocketLauncher] = MissileLauncher;
$NextWeapon[MissileLauncher] = LaserRifle;
$NextWeapon[LaserRifle] = EnergyRifle;
$NextWeapon[EnergyRifle] = TransferGun;
$NextWeapon[TransferGun] = FieldRepairGun;
$NextWeapon[FieldRepairGun] = NARCLauncher;
$NextWeapon[NARCLauncher] = DemoCharge;
$NextWeapon[DemoCharge] = Blaster;

$PrevWeapon[Blaster] = DemoCharge;
$PrevWeapon[EDGun] = Blaster;
$PrevWeapon[GaussRifle] = EDGun;
$PrevWeapon[PlasmaGun] = GaussRifle;
$PrevWeapon[PlasmaRepeater] = PlasmaGun;
$PrevWeapon[EnergyCannon] = PlasmaRepeater;
$PrevWeapon[SilencedPistol] = EnergyCannon;
$PrevWeapon[SniperRifle] = SilencedPistol;
$PrevWeapon[Chaingun] = SniperRifle;
$PrevWeapon[AssaultRifle] = Chaingun;
$PrevWeapon[AutoCannon] = AssaultRifle;
$PrevWeapon[DiscLauncher] = AutoCannon;
$PrevWeapon[KineticRifle] = DiscLauncher;
$PrevWeapon[GrenadeLauncher] = KineticRifle;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[RocketLauncher] = Mortar;
$PrevWeapon[MissileLauncher] = RocketLauncher;
$PrevWeapon[LaserRifle] = MissileLauncher;
$PrevWeapon[EnergyRifle] = LaserRifle;

$PrevWeapon[TransferGun] = EnergyRifle;
$PrevWeapon[FieldRepairGun] = TransferGun;
$PrevWeapon[NARCLauncher] = FieldRepairGun;
$PrevWeapon[DemoCharge] = NARCLauncher;

//*****************
function resetWeaponModes(%client)
{
$WeaponMode[Blaster,%client] = "";
$WeaponMode[SniperRifle,%client] = "";
$WeaponMode[SilencedPistol,%client] = "";
$WeaponMode[Chaingun,%client] = "";
$WeaponMode[AssaultRifle,%client] = "";
$WeaponMode[AutoCannon,%client] = "";
$WeaponMode[GrenadeLauncher,%client] = "";
$WeaponMode[Mortar,%client] = "";
$WeaponMode[RocketLauncher,%client] = "";
$WeaponMode[MissileLauncher,%client] = "";
}

//*****************
function remoteWeaponModeNext(%client)
{
 %weapon = Player::getMountedItem(%client,$WeaponSlot);

 if(%weapon == -1) return;

 if($WeaponMode[%weapon,%client])
 {
  if(%weapon == Blaster)
  {
   bottomprint(%client,"<jc>Blaster linked to internal armor power.");
   $WeaponMode[%weapon,%client] = false;
  }
//  else if(%weapon == Chaingun)
//  {
//   bottomprint(%client,"<jc>5.7mm Chaingun set to regulated fire mode.");
//   $WeaponMode[%weapon,%client] = false;
//  }
  else if(%weapon == Chaingun)
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
//  else if(%weapon == SniperRifle)
//  {
//   bottomprint(%client,"<jc>12.5mm rifle set to single fire mode.");
//   $WeaponMode[%weapon,%client] = false;
//  }
  else if(%weapon == GrenadeLauncher)
  {
   bottomprint(%client,"<jc>GrenadeLauncher set to regular fire mode.");
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

 if(!$WeaponMode[%weapon,%client])
  {
   if(%weapon == Blaster)
   {
    bottomprint(%client,"<jc>Blaster set to use Fusion Pack ammunition.");
    $WeaponMode[%weapon,%client] = true;
   }
//   else if(%weapon == Chaingun)
//   {
//    bottomprint(%client,"<jc>5.7mm Chaingun set to Very Rapid Fire mode.");
//	$WeaponMode[%weapon,%client] = true;
//   }
   else if(%weapon == Chaingun)
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
//   else if(%weapon == SniperRifle)
//   {
//    bottomprint(%client,"<jc>12.5mm rifle set to burst fire mode.");
//    $WeaponMode[%weapon,%client] = true;
//   }
   else if(%weapon == GrenadeLauncher)
   {
    bottomprint(%client,"<jc>GrenadeLauncher set to AGL fire mode.");
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
// - BW Admin Mod - No more prev/next spam, well spotted Labrat!

      if(!(%client.observerMode == "" || %client.observerMode == "pregame"))
	      return;

// - BW Admin Mod - No more prev/next spam, well spotted Labrat! - End

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
// - BW Admin Mod - No more prev/next spam, well spotted Labrat!

      if(!(%client.observerMode == "" || %client.observerMode == "pregame"))
	      return;

// - BW Admin Mod - No more prev/next spam, well spotted Labrat! - End

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
			bwadmin::isWeaponChangeInfoActive(%client, %weapon);
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

// - BWAdmin Mod - Long Walk Home support
function Weapon::onUse(%player,%item)
{
	if(%player.Station=="" && (!$bwadmin::walk || %player.carryflag ==""))
	{
		%client = Player::getClient(%player);
		if(%client.observerMode != "") return;

		if((GameBase::getOwnerClient(%player) == -1) || Player::isDead(%player)) return;

		if(%player.Station=="" && !%player.invulnerable){
			%ammo = %item.imageType.ammoType;
			if(%ammo != "" && Player::getItemCount(%player,%ammo) < 1) {
				Client::sendMessage(Player::getClient(%player),0,strcat(%item.description," has no ammo"));
			}

			Player::mountItem(%player,%item,$WeaponSlot);
			Weapon::showMessage(%client,%item);
		}
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
 if(%item == Blaster)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - Fusion Pack Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - Internal Power Mode");
 }
 else if(%item == SilencedPistol)
 {
  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - Silent Mode");
  else bottomprint(%client,"<jc>"@%item.description@" selected - Burst Fire Mode");
 }
// else if(%item == Chaingun)
// {
//  if($WeaponMode[%item,%client]) bottomprint(%client,"<jc>"@%item.description@" selected - VRF Mode");
//  else bottomprint(%client,"<jc>"@%item.description@" selected - Regulated Fire Mode");
// }
 else if(%item == Chaingun)
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
	// projectileType = BlasterBolt;
	accuFire = true;
	// sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
    heading = "bGeneralWeapons";
	description = "Blaster";
	className = "Weapon";
    shapeFile  = "energygun";
	hudIcon = "sniper";
	// hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 45;
	showWeaponBar = true;
};

function BlasterImage::onFire(%this,%slot)
{
	%client = Player::getClient(%this);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	%trans = GameBase::getMuzzleTransform(%client);
	%vel = Item::getVelocity(%client);

	if(!$WeaponMode[%weapon,%client]) {
		%energy = GameBase::getEnergy(%this);
		Projectile::spawnProjectile(BlasterBolt,%trans,%this,%vel);
		GameBase::playSound(%this,SoundFireBlaster,0);
		if (%energy > 9) {
			%energy -= 9;
		} else {
			%energy = 0;
		}
		if (!Player::isDead(%this)) GameBase::setEnergy(%this,%energy);
	} else {
		%ammo = Player::getItemCount(%this,"FusionPack");
		if (%ammo >= 1) {
			Projectile::spawnProjectile(MiniFusionBolt,%trans,%this,%vel);
			GameBase::playSound(%this,SoundEnergyTurretFire,0);
			if (!Player::isDead(%this)) Player::decItemCount(%client,FusionPack,1);
		} else {
			GameBase::playSound(%this,SoundPickUpWeapon,0);
			bottomprint(%client,"<jc><f1>Out of ammo - switching to internal power");
			$WeaponMode[%weapon,%client] = false;
		}
	}
}

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

 %energy = GameBase::getEnergy(%this);
 if(%energy > 30) %energy -= 30;
 else if($Combat::GaussDrain[%client] < 0) %energy= 0;
 else
 {
  GaussRifle::energyDrain(%this,%energy - 30);
  bottomprint(%client,"<jc>Your energy systems have been dampened.");
  %energy = 0;
 }
 GameBase::setEnergy(%this,%energy);
}

//*************************
ItemData FusionPack
{
	description = "Fusion Pack";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
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

ItemImageData AutoCannonImage2
{
	shapeFile = "chaingun";
    mountPoint = $SecondWeaponSlot;
    mountOffset = { -1.015, -0.5, 0.5 }; 
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.325;
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

ItemData AutoCannon2
{
	description = "25mm AutoCannon";
	className = "Tool";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = AutoCannonImage2;
	price = 450;
	showWeaponBar = false;
	showInventory = false;
};

function AutoCannonImage2::onFire(%this,%slot)
{
	%client = Player::getClient(%this);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	%trans = GameBase::getMuzzleTransform(%client);
	%vel = Item::getVelocity(%client);
	%mode = $WeaponMode[%weapon,%client];

	if(!%mode) Projectile::spawnProjectile(HEAPShellSpread,%trans,%this,%vel);
	else Projectile::spawnProjectile(HVAPShellSpread,%trans,%this,%vel);
	GameBase::playSound(%this,shockExplosion,0);
	GameBase::playSound(%this,debrisSmallExplosion,1);
	if(!Player::isDead(%this)) Player::decItemCount(%client,ACAmmo,1);
//	Weapon::applyRecoil(%this,24.0);
}

function AutoCannonImage2::CheckFire(%this)
{
	%client = Player::getClient(%this);
	if (Player::isTriggered(%client, $WeaponSlot)) {
		schedule("AutoCannonImage2::CheckFire("@%this@");",1.0,%this);
	} else {
		Player::trigger(%client,$SecondWeaponSlot,false);
	}
}


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
	%mode = $WeaponMode[%weapon,%client];

	if(!%mode) Projectile::spawnProjectile(HEAPShell,%trans,%this,%vel);
	else Projectile::spawnProjectile(HVAPShell,%trans,%this,%vel);
	GameBase::playSound(%this,shockExplosion,0);
	GameBase::playSound(%this,debrisSmallExplosion,1);
	if(!Player::isDead(%this)) Player::decItemCount(%client,ACAmmo,1);
//	Weapon::applyRecoil(%this,24.0);

	%weapon2 = Player::getMountedItem(%client,$SecondWeaponSlot);

	if (%weapon2 != "" && Player::getItemCount(%client,ACAmmo) > 0) {
		Player::trigger(%client,$SecondWeaponSlot,true);
		schedule("AutoCannonImage2::CheckFire("@%this@");",1.0,%this);
	}
}


function AutoCannon::onMount(%player,%imageSlot)
{
	%client = Player::getClient(%player);
	if (Player::getArmor(%player) == darmor) {
		Player::setItemCount(%player,AutoCannon2,1);
		Player::mountItem(%player,AutoCannon2,$SecondWeaponSlot); 
	}
}

function AutoCannon::onUnmount(%player,%imageSlot)
{
	if (Player::getMountedItem(%client,$SecondWeaponSlot)) {
		Player::trigger(%client,$SecondWeaponSlot,false);
		Player::unmountItem(%player,$SecondWeaponSlot); 
		Player::setItemCount(%player,AutoCannon2,0);
	}
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

ItemData Chaingun
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
	price = 4;
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

// ItemImageData ChaingunImage
// {
// 	shapeFile = "chaingun";
// 	mountPoint = 0;

// 	weaponType = 1; // Spinning
// 	reloadTime = 0;
// 	spinUpTime = 0.3;
// 	spinDownTime = 1.0;
// 	fireTime = 0.14;

// 	ammoType = BulletAmmo;
//	projectileType = ChaingunBullet;
// 	accuFire = false;

// 	lightType = 3;  // Weapon Fire
// 	lightRadius = 3;
// 	lightTime = 1;
// 	lightColor = { 0.6, 1, 1 };

// 	sfxFire = SoundFireChaingun;
// 	sfxActivate = SoundPickUpWeapon;
// 	sfxSpinUp = SoundSpinUp;
// 	sfxSpinDown = SoundSpinDown;
// };

// ItemData Chaingun
// {
// 	description = "7mm Chaingun";
// 	className = "Weapon";
// 	shapeFile = "chaingun";
// 	hudIcon = "chain";
//     heading = "bGeneralWeapons";
// 	shadowDetailMask = 4;
// 	imageType = ChaingunImage;
// 	price = 125;
// 	showWeaponBar = true;
// };

// function ChaingunImage::onFire(%this,%slot)
// {
//     %client = Player::getClient(%this);
//     %weapon = Player::getMountedItem(%client,$WeaponSlot);
//     %trans = GameBase::getMuzzleTransform(%client);
//     %vel = Item::getVelocity(%client);
// 	if(!$WeaponMode[%weapon,%client])
// 	{
// 	 Projectile::spawnProjectile(ChaingunBullet,%trans,%this,%vel);
//      if(!Player::isDead(%this)) Player::decItemCount(%client,BulletAmmo,1);
// 	}
// 	else
// 	{
//      Projectile::spawnProjectile(VRPBullet,%trans,%this,%vel);
//      Projectile::spawnProjectile(VRPBullet,%trans,%this,%vel);
//      Projectile::spawnProjectile(VRPBullet,%trans,%this,%vel);
// 	 Weapon::applyRecoil(%this,12.0);
//      if(!Player::isDead(%this)) Player::decItemCount(%client,BulletAmmo,3);
// 	}
// }

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

ItemData FThrowerAmmo
{ 
	description = "Pyro Charge"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 5; 
}; 

//*******************************
ItemImageData PlasmaRepeaterImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 1; 
	ammoType = FThrowerAmmo;
	accuFire = false; 
	reloadTime = 0; 
	spinUpTime = 0.3;
	spinDownTime = 1.0;
	fireTime = 0.17;
	projectileType = FlameBurst;
	mountRotation = {0,1.57,0};
      mountOffset = { 0, 0, 0 }; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFlyerActive; 
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundDryFire; 
	sfxSpinDown = SoundDryFire; 

};

ItemData PlasmaRepeater
{
	description = "Flamethrower"; 
	className = "Weapon";
	shapeFile = "mortar"; 
	hudIcon = "energypack"; 
    heading = "eHeavyWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaRepeaterImage;
	price = 400;
	showWeaponBar = true;
};


//*****************************
ItemImageData EnergyCannonImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = PPCCharge;
	minEnergy = 12;
	maxEnergy = 50;  // Energy used/sec for sustained weapons
	reloadTime = 3.0;
	mountRotation = {0,4.71,0};
                        
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.45, 1 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
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

// function EnergyCannon::onUse(%player,%item)
// {
// 	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item);
// 	else Client::sendMessage(Player::getClient(%player),0,"Must have an Energy Pack to use the Energy Cannon."); 
// }

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
	reloadTime = 0.5;
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
  schedule("GrenadeLauncher::repeatFire("@%this@","@%repeat@");",0.4,%this);
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
	mountRotation = {0,5.5,0};
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
	if (%client.observerMode != "") return;

	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	%trans = GameBase::getMuzzleTransform(%client);
	%vel = Item::getVelocity(%client);

	if (!$WeaponMode[%weapon,%client]) {
		Projectile::spawnProjectile(MiniRocket,%trans,%this,%vel);
		Weapon::applyRecoil(%this,10.0);
		if (!Player::isDead(%this)) Player::decItemCount(%client,RLAmmo,1);
	} else {
		%ammo = Player::getItemCount(%this,"RLAmmo");
		if (%ammo > 2) {
			if(!Player::isDead(%this)) Player::decItemCount(%client,RLAmmo,3);
			schedule("rocketSalvo("@%this@",4);",0.1,%this);
		} else {
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
  schedule("rocketSalvo("@%this@","@%repeat@");",0.2,%this);
}

//*************
ItemData MLAmmo
{
	description = "Missile Ammo";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 500;
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
	mountRotation = {0,1.57,0};

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
      %obj.deployer = %client;
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

//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;

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
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
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


//************************
$ItemMax[larmor,NARCLauncher] = 1;
$ItemMax[carmor,NARCLauncher] = 1;
$ItemMax[marmor,NARCLauncher] = 1;
$ItemMax[harmor,NARCLauncher] = 1;
$ItemMax[darmor,NARCLauncher] = 1;
$ItemMax[lfemale,NARCLauncher] = 1;
$ItemMax[fcarmor,NARCLauncher] = 1;
$ItemMax[mfemale,NARCLauncher] = 1;
$ItemMax[mfemale,NARCLauncher] = 1;
$ItemMax[scvarmor,NARCLauncher] = 0;

$ItemMax[larmor,NARCAmmo] = 5;
$ItemMax[carmor,NARCAmmo] = 5;
$ItemMax[marmor,NARCAmmo] = 5;
$ItemMax[harmor,NARCAmmo] = 5;
$ItemMax[darmor,NARCAmmo] = 5;
$ItemMax[lfemale,NARCAmmo] = 5;
$ItemMax[fcarmor,NARCAmmo] = 5;
$ItemMax[mfemale,NARCAmmo] = 5;
$ItemMax[scvarmor,NARCAmmo] = 5;

//------------------------------------------------------------------------------


//*************************
ItemData NARCAmmo
{
	description = "Beacon Rounds";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData NARCLauncherImage
{
	shapeFile  = "shotgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 1.0;
	fireTime = 0.15;
	ammoType = NARCAmmo;
	mountRotation = {0,3.14,0};

	// projectileType = MiniFusionBolt;

	accuFire = true;

	sfxActivate = SoundPickUpWeapon;
};

function NARCLauncherImage::putNarc(%beacon, %team, %rot, %pos) 
{
	GameBase::setRotation(%beacon, %rot);
	GameBase::setPosition(%beacon, %pos);
	Gamebase::setMapName(%beacon, "Target Beacon");
	Beacon::onEnabled(%beacon);
	playSound(SoundPickupBackpack,%pos);
	schedule("GameBase::setTeam("@%beacon@","@%team@");", 3.0, %beacon);
	schedule("deleteObject("@%beacon@");", 60.0, %beacon);
}

function NARCLauncherImage::onFire(%this,%slot)
{
	%client = Player::getClient(%this);

	if (GameBase::getLOSInfo(%this,300)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		%objname = GameBase::getDataName($los::object);

		// DH
		echo("TARGET: obj "@ %obj @", objname "@ %objname );
		
		if (%obj == "SimTerrain" || %obj == "InteriorShape" || %objname == "ssFloatingPad" || %objname == "LargeAirBasePlatform") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			} else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				} else {
					%rot = Vector::getRotation($los::normal);
				}
			}

// 		  	%set = newObject("set",SimSet);
// 			%num = containerBoxFillSet(%set, $StaticObjectType | $ItemObjectType,$los::position,0.2,0.2,0.2,1);
// 			deleteObject(%set);

// 			if(!%num) {

				%team = GameBase::getTeam(%this);
				%pos = $los::position;

				%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				addToSet("MissionCleanup", %obj);

				NARCLauncherImage::putNarc(%beacon, %team, %rot, %pos);
	
				%trans = GameBase::getMuzzleTransform(%client);
				%vel = Item::getVelocity(%client);
				GameBase::playSound(%this,debrisSmallExplosion,0);

				if (!Player::isDead(%this))	Player::decItemCount(%client,NARCAmmo,1);
 				Projectile::spawnProjectile(NARCShell,%trans,%this,%vel);

// 			} else bottomprint(%client,"<jc>Item in the way");
		} else bottomprint(%client,"<jc>Invalid target");
	} else bottomprint(%client,"<jc>Target out of range");
}


ItemData NARCLauncher
{
	heading = "vTools";
	description = "Beacon Launcher";
	className     = "Weapon";
//	className = "Weapon";
	shapeFile  = "shotgun";
	hudIcon = "targetlaser";
	shadowDetailMask = 4;
	imageType = NARCLauncherImage;
	price = 200;
	showWeaponBar = true;
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
//	%charge = newObject("","Mine",DemoGrenade);
	%charge = newObject("","Mine",mdDetPack);
   	addToSet("MissionCleanup", %charge);
	GameBase::throw(%charge,%client,3,false);
	%charge.deployer = %client;
	bottomprint(%client,"<jc>Demolitions charge deployed.",3);
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

//*************************
ItemData ARAmmo
{
	description = "Assault Rifle Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
    heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AssaultRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = {0,3.14,0};
	mountOffset = { -0.05, -0.18, 0.07 }; 
	weaponType = 0; // Single Shot
	ammoType = ARAmmo;
	accuFire = true;
	reloadTime = 1.1;
	fireTime = 0.55;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxReload = SoundMortarReload;
	sfxActivate = SoundPickUpWeapon;
};

function AssaultRifleImage::repeatFire(%this,%repeat)
{
	%client = Player::getClient(%this);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	%trans = GameBase::getMuzzleTransform(%client);
	%vel = Item::getVelocity(%client);

	Projectile::spawnProjectile(SniperBurstBullet,%trans,%this,%vel);
	GameBase::playSound(%this,shockExplosion,0);
	if(!Player::isDead(%this)) Player::decItemCount(%client,ARAmmo,1);
	%ammo = Player::getItemCount(%this,"ARAmmo");

	%repeat--;

	if ((%repeat > 0) && (%ammo > 0)) {
		schedule("AssaultRifleImage::repeatFire("@%this@","@%repeat@");",0.15,%this);
	}
}

function AssaultRifleImage::onFire(%this,%slot)
{
	if((GameBase::getOwnerClient(%this) == -1) || Player::isDead(%this)) return;

	%client = Player::getClient(%this);
	if(%client.observerMode != "") return;

	%weapon = Player::getMountedItem(%client,$WeaponSlot);

	schedule("AssaultRifleImage::repeatFire("@%this@",4);",0.01,%this);
}

ItemData AssaultRifle
{
	description = "Assault Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
    heading = "dMediumWeapons";
	shadowDetailMask = 4;
	imageType = AssaultRifleImage;
	price = 300;
	showWeaponBar = true;
};

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
	sfxFire = SoundFireLaser;
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
	schedule("kineticFire("@%this@","@6@");",0.1,%this);
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
	schedule("kineticFire("@%this@","@%repeat@");",0.10,%this);
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
	className = "Tool";
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


