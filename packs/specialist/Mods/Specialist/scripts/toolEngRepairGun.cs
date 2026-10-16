$InvList[EngRepairGun] = 1;
$RemoteInvList[EngRepairGun] = 1;
$AutoUse[EngRepairGun] = False;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this weapon
$ItemMax[reconarmor, EngRepairGun] = 0;
$ItemMax[reconfemalearmor, EngRepairGun] = 0;
$ItemMax[espionagearmor, EngRepairGun] = 0;
$ItemMax[espionagefemalearmor, EngRepairGun] = 0;
$ItemMax[engineerarmor, EngRepairGun] = 1;
$ItemMax[engineerfemalearmor, EngRepairGun] = 1;
$ItemMax[infantryarmor, EngRepairGun] = 0;
$ItemMax[infantryfemalearmor, EngRepairGun] = 0;
$ItemMax[falloutarmor, EngRepairGun] = 0;
$ItemMax[falloutfemalearmor, EngRepairGun] = 0;
$ItemMax[demolitionsarmor, EngRepairGun] = 0;
$ItemMax[assaultarmor, EngRepairGun] = 0;
$ItemMax[artilleryarmor, EngRepairGun] = 0;
$ItemMax[commanderarmor, EngRepairGun] = 1;

RepairEffectData ExtendedRepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 14.0; // original is 5.0, but was updated in Base v1.11 to 9.0 (RJC)
   segmentDivisions = 8; // original is 4 (RJC)
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function ExtendedRepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			// original repair rate is 0.05 (RJC)
			%player.repairRate = 0.08; 
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
		// original repair rate is 0.1 (RJC)
		%player.repairRate   = 0.15; 
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

function ExtendedRepairBolt::onRelease(%this, %player)
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

function ExtendedRepairBolt::checkDone(%this, %player)
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

ItemImageData EngRepairGunImage 
{
  shapeFile = "repairgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = ExtendedRepairBolt;
  minEnergy = 5;
  maxEnergy = 15;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundRepairItem;
  sfxActivate = SoundPickUpWeapon;
};

ItemData EngRepairGun 
{
  description = "Engineer Repair-Gun";
  className = "Tool";
  shapeFile = "repairgun";
  hudIcon = "targetlaser";
  heading = "tTools";
  shadowDetailMask = 4;
  imageType = EngRepairGunImage;
  price = 50;
  showWeaponBar = false;
};

