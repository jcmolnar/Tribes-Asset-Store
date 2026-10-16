//--------------------------------------

$AutoUse[EnergyRifle] = True;
$WeaponAmmo[EnergyRifle] = "";

//--------------------------------------

$InvList[EnergyRifle] = 1;
$RemoteInvList[EnergyRifle] = 1;

//--------------------------------------

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 50.0;
   coneAngle        = 0.1;
   damagePerSec      = 0.26;
   energyDrainPerSec = 80.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.175;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------

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
   heading = "dLightning Guns";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

//--------------------------------------
function EnergyRifle::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Elf Gun, Another classic i just could not change :).", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$AutoUse[EnergyRifle2] = True;
$WeaponAmmo[EnergyRifle2] = "";

//--------------------------------------

$InvList[EnergyRifle2] = 1;
$RemoteInvList[EnergyRifle2] = 1;

//--------------------------------------


LightningData Grapple
{
   bitmapName       = "LaserPulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 580.0;
   coneAngle        = 40.8;
   damagePerSec      = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 3;
   numSegments      = 3;
   beamWidth        = 0.3;

   updateTime   = 1000;
   skipPercent  = 1000.1;
   displaceBias = 1000.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function grapple::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
		%prot = GameBase::getRotation(%player);
		%zRot = getWord(%prot,2);
		%xpos = getWord($los::Normal,0);
		%ypos = getWord($los::Normal,1);
		%zpos = getWord($los::Normal,2);
		%rot = Vector::getRotation($los::normal);
		%Rotation = getObjectType($los::object);
		%velocity = 20;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Rotation);
		Player::applyImpulse(%shooterId, %ShooterDir);
}



//GameBase::getRotation(%shooterId)

//--------------------------------------

ItemImageData EnergyRifleImage2
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = Grapple;
   minEnergy = 0;
   maxEnergy = 1;  // Energy used/sec for sustained weapons
	reloadTime = 0;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle2
{
   description = "Electro Grapple";
	shapeFile = "Mortargun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "dLightning Guns";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage2;
	showWeaponBar = true;
   price = 825;
   validateShape = true;
};

//--------------------------------------
function EnergyRifle2::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "The Electro Grapple, a grappling hook made easier to use by technology.", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------

//--------------------------------------

$AutoUse[EnergyRifle3] = True;
$WeaponAmmo[EnergyRifle3] = "";

//--------------------------------------

$InvList[EnergyRifle3] = 1;
$RemoteInvList[EnergyRifle3] = 1;

//--------------------------------------

LightningData lightningCharge3
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 300.0;
   coneAngle        = 5.1;
   damagePerSec      = 2;
   energyDrainPerSec = 0;
   segmentDivisions = 2;
   numSegments      = 3;
   beamWidth        = 3;//075;

   updateTime   = 120;
   skipPercent  = 0.1;
   displaceBias = 0.1;

   lightRange = 100.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------

ItemImageData EnergyRifleImage3
{
	shapeFile = "MortarGun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge3;
   minEnergy = 50;
   maxEnergy = 60;  // Energy used/sec for sustained weapons
	reloadTime = 0;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle3
{
   description = "Electro Blast";
	shapeFile = "Mortargun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "dLightning Guns";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage3;
	showWeaponBar = true;
   price = 1225;
   validateShape = true;
};

//--------------------------------------
function EnergyRifle3::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "A tessla coil just like momma used ta make...", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------
//--------------------------------------

$AutoUse[BR] = True;
$WeaponAmmo[BR] = "";

//--------------------------------------

$InvList[BR] = 1;
$RemoteInvList[BR] = 1;

//--------------------------------------

RepairEffectData RepairBolti
{
   bitmapName       = "Lightningnew.bmp";
   boltLength       = 1000.0;
   segmentDivisions = 4;
   beamWidth        = 1.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 3.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

//--------------------------------------
function Repairbolti::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 2.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 2.1;
		GameBase::generatePower(%this, true);
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolti::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolti::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}
ItemImageData BRImage
{
	shapeFile = "paintgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = Repairbolti;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.1;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData BR
{
   description = "Builder Gun";
	shapeFile = "paintgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "rHaCk's Tools";
   shadowDetailMask = 4;
   imageType = BRImage;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

//--------------------------------------
function BR::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "Repairs objects very quickly...(take that reassembler :) )...", 10);Weapon::onUse(%player,%item);
}
//--------------------------------------


$AutoUse[EnergyRifle4] = True;
$WeaponAmmo[EnergyRifle4] = "";

//--------------------------------------

$InvList[EnergyRifle4] = 1;
$RemoteInvList[EnergyRifle4] = 1;

//--------------------------------------


LightningData Grapple2
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 580.0;
   coneAngle        = 10.8;
   damagePerSec      = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments      = 1;
   beamWidth        = 0.3;

   updateTime   = 1000;
   skipPercent  = 1000.1;
   displaceBias = 1000.35;

   lightRange = 3.0;
   lightColor = { 0.15, 0.85, 0.15 };

   soundId = SoundELFFire;
};

function grapple2::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
		%prot = GameBase::getRotation(%player);
		%zRot = getWord(%prot,2);
		%xpos = getWord($los::Normal,0);
		%ypos = getWord($los::Normal,1);
		%zpos = getWord($los::Normal,2);
		%rot = Vector::getRotation($los::normal);
		%Rotation = getObjectType($los::object);
		%velocity = 20;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%target),%velocity,%Rotation);
		Player::applyImpulse(%target, %ShooterDir);
}

