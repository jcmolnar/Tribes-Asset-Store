// This is a MiniMod Plugin.
// This Plugin is the Repair Rifle.
// Requirements: MiniMod v.07 or later
//   and the Energizer Pack Plugin.

MiniMod::MonitorFile(start, "Repair Rifle.CodeFusion.cs", "Repair Rifle Plugin");
MiniMod::WeaponCycle(Blaster, RepairRifle, PlasmaGun);
MiniMod::Turbo::Class(RepairRifle, 18);

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

	weaponType = 2; // Sustained
	projectileType = RepairRifleBolt;
	accuFire = true;
//	reloadTime = 0.1;
//	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 30;  // Energy used/sec for sustained weapons

	lightType = 3;  // Weapon Fire
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
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RepairRifleImage;
	price = 500;
	showWeaponBar = true;
};

function RepairRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Repair Rifle.", 2);

	if(Player::getMountedItem(%player,$BackpackSlot) == EnergizerPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energizer Pack to use Repair Rifle."); 
}


$InvList[RepairRifle] = 1; // You want the main Inventory stations to show it right?
$RemoteInvList[RepairPack] = 1; // You want the deployable Inventory stations to show it right?

MiniMod::MonitorFile(stop, "Repair Rifle.CodeFusion.cs", "Repair Rifle Turret Plugin");
