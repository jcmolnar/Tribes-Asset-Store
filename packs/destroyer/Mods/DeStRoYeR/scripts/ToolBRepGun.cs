$AutoUse[BRepGun] = True;
$InvList[BRepGun] = 1;
$RemoteInvList[BRepGun] = 1;

$ItemMax[narmor, BRepGun] = 0;
$ItemMax[aarmor, BRepGun] = 0;
$ItemMax[darmor, BRepGun] = 0;
$ItemMax[nfemale, BRepGun] = 0;
$ItemMax[afemale, BRepGun] = 0;
$ItemMax[warmor, BRepGun] = 0;
$ItemMax[barmor, BRepGun] = 1;
$ItemMax[sarmor, BRepGun] = 1;
$ItemMax[avarmor, BRepGun] = 0;
$ItemMax[wfemale, BRepGun] = 0;
$ItemMax[bfemale, BRepGun] = 1;

RepairEffectData SuperRepairBolt
{
	bitmapName = "repairadd.bmp";
	boltLength = 7.5;
	segmentDivisions = 4;
	beamWidth = 0.125;
	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

function SuperRepairBolt::onAcquire(%this, %player, %target)
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

function SuperRepairBolt::onRelease(%this, %player)
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

function SuperRepairBolt::checkDone(%this, %player)
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


$BRepGunSlotA=4;
$BRepGunSlotB=7;
$BRepGunSlotC=6;
$BRepGunSlotD=5;

ItemImageData BRepGunImage
{
	shapeFile = "breath";
	mountPoint = 0;
	weaponType = 2;
	mountOffset = { 0, -0.2, 0 };
	mountRotation = { 0, 0, 0 };
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BRepGun
{
	description = "Builder Repair-Gun";
	className = "Tool";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType = BRepGunImage;
	price = 50;
	showWeaponBar = true;
};
ItemImageData BRepGunImage2
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	mountOffset = { -0.1, 0, 0 };
	mountRotation = { 0, -1.575, 0 };
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BRepGun2
{
	description = "Builder Repair-Gun";
	className = "Tool";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType = BRepGunImage2;
	price = 50;
	showWeaponBar = true;
};

ItemImageData BRepGunImage3
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0.1, 0, 0 };
	mountRotation = { 0, 1.575, 0};
	weaponType = 2;
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BRepGun3
{
	description = "Builder's Repair-Gun";
	className = "Tool";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType = BRepGunImage3;
	showWeaponBar = true;
	showInventory = false;
	Price = 0;
};
ItemImageData BRepGunImage4
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 0, 0, 0 };
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BRepGun4
{
	description = "Builder Repair-Gun";
	className = "Tool";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType = BRepGunImage4;
	price = 50;
	showWeaponBar = true;
};
ItemImageData BRepGunImage5
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	mountOffset = { 0, 0, -0.1 };
	mountRotation = { 0, 3.1416, 0 };
	projectileType = SuperRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BRepGun5
{
	description = "Builder Repair-Gun";
	className = "Tool";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType = BRepGunImage5;
	price = 50;
	showWeaponBar = true;
};

function BRepGun::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if(%state != "Fire" && %state != "Reload")
	{
		Player::setItemCount(%player, BRepGun2, 0);
		Player::setItemCount(%player, BRepGun3, 0);
		Player::setItemCount(%player, BRepGun4, 0);
		Player::setItemCount(%player, BRepGun5, 0);
		Item::onDrop(%player,%item);
	}
}

function BRepGun::onMount(%player,%item)
{
	Player::mountItem(%player,BRepGun2,$BRepGunSlotA);
	Player::mountItem(%player,BRepGun3,$BRepGunSlotB);
	Player::mountItem(%player,BRepGun4,$BRepGunSlotC);
	Player::mountItem(%player,BRepGun5,$BRepGunSlotD);
	%clientId = Player::getclient(%player);
	bottomprint(%clientId, "Builder Repair Gun: <f2>Repairs people or objects faster and better then a repair pack.");
}

function BRepGun::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$BRepGunSlotA);
	Player::unmountItem(%player,$BRepGunSlotB);
	Player::unmountItem(%player,$BRepGunSlotC);
	Player::unmountItem(%player,$BRepGunSlotD);
}