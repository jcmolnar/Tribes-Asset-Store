$AutoUse[RepRif] = True;
$InvList[RepRif] = 1;
$RemoteInvList[RepRif] = 1;

$ItemMax[narmor, RepRif] = 0;
$ItemMax[aarmor, RepRif] = 1;
$ItemMax[darmor, RepRif] = 0;
$ItemMax[nfemale, RepRif] = 0;
$ItemMax[afemale, RepRif] = 1;
$ItemMax[warmor, RepRif] = 0;
$ItemMax[barmor, RepRif] = 1;
$ItemMax[sarmor, RepRif] = 1;
$ItemMax[avarmor, RepRif] = 0;
$ItemMax[wfemale, RepRif] = 0;
$ItemMax[bfemale, RepRif] = 1;

RepairEffectData LRRepairBolt
{
	bitmapName = "warp.bmp";
	boltLength = 2000;
	segmentDivisions = 1;
	beamWidth = 0.25;
	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

function LRRepairBolt::onAcquire(%this, %player, %target)
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

function LRRepairBolt::onRelease(%this, %player)
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

function LRRepairBolt::checkDone(%this, %player)
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

ItemImageData RepRifImage
{
	shapeFile = "Sniper";
	mountPoint = 0;
	weaponType = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	projectileType = LRRepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepRif
{
	description = "Repair Rifle";
	className = "Tool";
	shapeFile = "Sniper";
	hudIcon = "repairpack";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType = RepRifImage;
	price = 50;
	showWeaponBar = true;
};
function RepRif::onMount(%player,%item)
{
	%clientId = Player::getclient(%player);
	bottomprint(%clientId, "Repair Rifle: <f2>Repairs people or objects from far away.");
}