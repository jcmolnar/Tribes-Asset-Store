//---------------------------------------------------------------
//
//	MISC WEAPONS
//
//---------------------------------------------------------------

//----------------------------------------------------------------------------
//--CloakGun--
//----------------------------------------------------------------------------

$InvList[CloakGun] = 1;
$RemoteInvList[CloakGun] = 1;
$AutoUse[CloakGun] = false;
$WeaponAmmo[CloakGun] = "";

addWeapon(CloakGun);

ItemImageData CloakGunImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 0;
	//projectileType = "";
	accuFire = true;
	//reloadTime = 0.1;
	//fireTime = 0.5;
	//minEnergy = 10;
	//maxEnergy = 60;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 2.5, 2.5 };
	sfxActivate = SoundEnergyWhirl;
};

ItemData CloakGun
{
	description = "HH-Cloak Gun";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "energypack";
	heading = $InvHead[ihMwe];
	shadowDetailMask = 4;
	imageType = CloakGunImage;
	price = 175;
	showWeaponBar = true;
	validateShape = true;
	validateMaterials = true;
};

function CloakGun::onMount(%player,%item)
{
	GameBase::startFadeout(%player);
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc><f2>HH-Cloak Gun.");
	Client::sendMessage(Player::getClient(%player),1,"Cloaking On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function CloakGun::onUnmount(%player,%item)
{
	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),1,"Cloaking Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate); 
}

//----------------------------------------------------------------------------
//--Repair Rifle--
//----------------------------------------------------------------------------

$InvList[RepairRifle] = 1;
$RemoteInvList[RepairRifle] = 1;
$AutoUse[RepairRifle] = True;
$WeaponAmmo[RepairRifle] = "";

addWeapon(RepairRifle);

RepairEffectData RepairRifleBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 1000.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairRifleBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.05;
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
		%player.repairRate   = 0.1;
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

function RepairRifleBolt::onRelease(%this, %player)
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

function RepairRifleBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairRifle &&
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


ItemImageData RepairRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 2;
      mountRotation = { 0, 22.0, 0 };
	projectileType = RepairRifleBolt;
	accuFire = true;
	//reloadTime = 0.1;
	//fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 30;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepairRifle
{
	description = "Repair Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "repairpack";
	heading = $InvHead[ihMwe];
	shadowDetailMask = 4;
	imageType = RepairRifleImage;
	price = 500;
	showWeaponBar = true;
};

function RepairRifle::onMount(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Repair Rifle", 2);
}

//----------------------------------------------------------------------------
//--Anti-Grav Gun--
//----------------------------------------------------------------------------

$InvList[AntiGrav] = 1;
$RemoteInvList[AntiGrav] = 1;
$AutoUse[AntiGrav] = True;
$WeaponAmmo[AntiGrav] = "";

addWeapon(AntiGrav);

LightningData AntiGravCharge
{
	bitmapName = "lightningNew.bmp";
	damageType = $EnergyDamageType;
	boltLength = 30.0;
	coneAngle = 40.0;
	damagePerSec = 0.0;
	energyDrainPerSec = 0.01;
	segmentDivisions = 2;
	numSegments = 1;
	beamWidth = 0.125;
	updateTime = 120;
	skipPercent = 0.1;
	displaceBias = 0.35;
	lightRange = 3.0;
	lightColor = { 0.15, 0.85, 0.15 };
	soundId = SoundELFFire;
};


function AntiGravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
	%Zvalue = 20;
	%velocity = 30;
	%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
	Player::applyImpulse(%target, %shooterDir);
}

ItemImageData AntiGravImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = AntiGravCharge;
	minEnergy = 3;
	maxEnergy = 11;
	reloadTime = 0.2;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundElectricShock;
	sfxFire = SoundELFIdle;
};

ItemData AntiGrav
{
	className = "Weapon";
	description = "Anti-Grav Gun";
	heading = $InvHead[ihMwe];
	hudIcon = "energyRifle";
	imageType = AntiGravImage;
	price = 125;
	shadowDetailMask = 4;
	shapeFile = "paintgun";
	showWeaponBar = true;
};

function AntiGrav::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc><f2>Anti-Grav Gun");
}

//----------------------------------------------------------------------------
//--Targeting Laser--
//----------------------------------------------------------------------------
$InvList[TargetingLaser] = 1;
$RemoteInvList[TargetingLaser] = 1;
$AutoUse[TargetingLaser] = false;
$WeaponAmmo[TargetingLaser] = "";

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
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
	heading = $InvHead[ihMwe];
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

function TargetingLaser::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc><f2>Targeting Laser");
}

//----------------------------------------------------------------------------
//--RepairGun--
//----------------------------------------------------------------------------

$AutoUse[RepairGun] = false;
$WeaponAmmo[RepairGun] = "";

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	lightType   = 3;  // Weapon Fire
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
	validateShape = true;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------
//--JailGun--
//----------------------------------------------------------------------------

$InvList[JailGun] = 1;
$RemoteInvList[JailGun] = 1;
$AutoUse[JailGun] = True;
$WeaponAmmo[JailGun] = "";

addWeapon(JailGun);

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
	sfxFire     = SoundELFIdle;
};

ItemData JailGun
{
	heading = $InvHead[ihMwe];
	description = "Jailers Gun";
	className = "Weapon";
	shapeFile  = "repairgun";
	hadowDetailMask = 4;
	imageType = JailGunImage;
	price = 385;
	showWeaponBar = true;
};

function JailGun::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc><f2>Jail Gun");
}

//----------------------------------------------------------------------------
//--Grabbling Hook--
//----------------------------------------------------------------------------

$InvList[TractorDevice] = 1;
$RemoteInvList[TractorDevice] = 1;
$AutoUse[TractorDevice] = False;
$WeaponAmmo[TractorDevice] = "";

addWeapon(TractorDevice);

LightningData TractorBeam
{
	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 300.0; // 120
	coneAngle = 35.0;
	damagePerSec = 0.0;
	energyDrainPerSec = 0.0;
	segmentDivisions = 5;
	numSegments = 2;
	beamWidth = 0.5;//0.125//075;
	updateTime = 120;
	skipPercent = 0.25;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.85, 0.85, 0.15 };
	soundId = SoundELFFire;
};

$TractorPower = 50;

function TractorBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
	%obj1 = %target;
	%obj2 = %shooterId;
	// Get object's mass  
	if (getObjectType(%obj1) == "Player") 
	%obj1mass = Player::getArmor(%obj1).mass;
	else %obj1mass = 10000;
	%obj2mass = Player::getArmor(%obj2).mass;
	%vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%obj1), GameBase::getPosition(%obj2)));
	if (getObjectType(%obj1) == "Player")
	{
		%mul = $TractorPower - ($TractorPower * %obj1mass) / (%obj1mass + %obj2mass);
		%nvec = (getWord(%vec, 0) * %mul * -1) @ " " @
            (getWord(%vec, 1) * %mul * -1) @ " " @
            (getWord(%vec, 2) * %mul * -1);
		//Player::applyImpulse(%obj1, %nvec);
		Item::setVelocity(%obj1, %nvec);
	}
	// obj2 is always a player
	%mul = $TractorPower - ($TractorPower * %obj2mass) / (%obj1mass + %obj2mass);
	%nvec = (getWord(%vec, 0) * %mul) @ " " @(getWord(%vec, 1) * %mul) @ " " @(getWord(%vec, 2) * %mul);
	//Player::applyImpulse(%obj2, %nvec);
	Item::setVelocity(%obj2, %nvec);
}

ItemImageData TractorDeviceImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = TractorBeam;
	minEnergy = 3;
	maxEnergy = 11;
	reloadTime = 0.2;		
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.85, 0.85, 0.15 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundELFIdle;
};

ItemData TractorDevice
{
	className = "Tool";
	description = "Energy Grappling Hook";
	heading = $InvHead[ihMwe];
	hudIcon = "energyRifle";
	imageType = TractorDeviceImage;
	price = 125;
	shadowDetailMask = 4;
	shapeFile = "mortargun";
	showWeaponBar = true;
};

function TractorDevice::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc><f2>Energy Grappling Hook");
}

//----------------------------------------------------------------------------
//--HHRepairGun--
//----------------------------------------------------------------------------

$InvList[HHRepairGun] = 1;
$RemoteInvList[HHRepairGun] = 1;
$AutoUse[HHRepairGun] = False;
$WeaponAmmo[HHRepairGun] = "";

addWeapon(HHRepairGun);

ItemImageData HHRepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData HHRepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Tool";
	heading = $InvHead[ihMwe];
	hudIcon = "energyRifle";
	shadowDetailMask = 4;
	imageType = HHRepairGunImage;
	showInventory = true;
	price = 125;
	validateShape = true;
};

function HHRepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function HHRepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
