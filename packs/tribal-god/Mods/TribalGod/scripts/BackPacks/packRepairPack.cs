// Repair Projectile Data:
RepairEffectData RepairRifleBolt
{
	bitmapName="staff.bmp";
	boltLength=1000.0;
	segmentDivisions=4;
	beamWidth=0.125;
	updateTime=450;
	skipPercent=0.6;
	displaceBias=0.15;
	lightRange=3.0;
	lightColor={0.85, 0.25, 0.25};
};

function RepairRifleBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	
	if (%target == %player) 
	{
		%player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) 
		{
			%player.repairRate = 350;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 3, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client,3,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	
	else 
	{
		%player.repairTarget = %target;
		%player.repairRate   = 350;
		
		if (getObjectType(%player.repairTarget) == "Player") 
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else
		{ 
			%name = GameBase::getMapName(%target);
			if(%name == "")
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
		{
			Client::sendMessage(%client,1,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") 
		{ Client::sendMessage(%rclient,3,"Being repaired by " @ Client::getName(%client)); }
		
		Client::sendMessage(%client,3,"Repairing " @ %name);
		BottomPrint(%client, "<jc><f0>Repairing "@ %name @"", 5);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairRifleBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) 
	{
		%client = Player::getClient(%player);
		if(%object == %player) 
		{ Client::sendMessage(%client,3,"AutoRepair Off"); }
		else 
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{ Client::sendMessage(%client, 3, "Repair Done");
			}
			else 
			{ Client::sendMessage(%client, 1, "Repair Stopped"); }
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if (%rate < 0)
		{ %rate = 0; }
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairRifleBolt::checkDone(%this, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairRifle && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if(%object == %player) 
		{
			if (GameBase::getDamageLevel(%player) == 0) 
			{ Player::trigger(%player, $WeaponSlot, false); return; }
		}
		else
		{
			if(GameBase::getDamageLevel(%object) == 0) 
			{ Player::trigger(%player, $WeaponSlot, false); return; }
		}
	}
}

RepairEffectData RepairBolt
{
	bitmapName="rsmoke05.bmp";
	boltLength=50.0;
	segmentDivisions=4;
	beamWidth=0.125;
	updateTime=450;
	skipPercent=0.6;
	displaceBias=0.15;
	lightRange=3.0;
	lightColor={ 0.25, 0.25, 0.85 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	if(GameBase::getTeam(%player) != GameBase::getTeam(%target) && getObjectType(%target) != "Player" && %target != %player)
	{
		%gender = Client::getGender(Player::getClient(%player));
		if(%gender == "Female")
		{ %genderName = "her"; }
		else
		{ %genderName = "his"; }
		Client::sendMessage(Player::getClient(%player), 0, "Don't help the enemy dip shit");
		MessageAll(0, Client::getName(Player::getClient(%player)) @" Has Tried To Betray "@ %genderName @" Team.~wCaptured_Tower.Wav");
		Player::trigger(%player, $WeaponSlot, false);
		%player.repairTarget = "Enemy";
		return;
	}
	
	%client = Player::getClient(%player);
	if (%target == %player) 
	{
		%player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 1.25;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 3, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client, 1, "Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{
		%player.repairTarget = %target;
		%player.repairRate   = 1.50;
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
			%player.repairTargetName = %name;
		}
		else
		{
			%name = GameBase::getMapName(%target);
			if(%name == "")
			{ 
				%name = (GameBase::getDataName(%player.repairTarget)).description; 
				%player.repairTargetName = %name;
			}
		}
		
		if (GameBase::getDamageLevel(%player.repairTarget) == 0)
		{
			Client::sendMessage(%client, 1, %name @" is not damaged");
			Player::trigger(%player, $WeaponSlot, false);
			%player.repairTarget = -1;
			return;
		}
		
		if(getObjectType(%player.repairTarget) == "Player") 
		{
			Client::sendMessage(%rclient, 3, "Being repaired by "@ Client::getName(Player::getClient(%player)) @".");
			BottomPrint(%rclient, "<jc><f0>Being repaired by "@ Client::getName(Player::getClient(%player)) @".", 5);
		}
		%client.hasRepaired = true;
		Client::sendMessage(%client, 3, "Repairing "@ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget, %rate);
}

function RepairBolt::onRelease(%this, %player){
	%client = Player::getClient(%player);
	%name = (GameBase::getDataName(%player.repairTarget)).description;
	// Addin to give points for repairs, still in the works kinda...
	if(%client.hasRepaired == true && %player.repairTarget != "Enemy" && GameBase::getDamageLevel(%player.repairTarget) == 0){
		%client.hasRepaired = false;
		if(GameBase::getTeam(%player.repairTarget) == GameBase::getTeam(%player))
		{
			%client.score += 1;
			BottomPrint(%client, "<jc><f1>You Recieve 1 Point For\n Repairing Your "@ %name @"\n Current Score: "@ %client.score, 5);
		}
		else if(%player.repairTarget == -1)
		{
			%client.score += 1;
			BottomPrint(%client, "<jc><f1>You Recieve 1 Point For Repairing\n"@ %name @"\nCurrent Score: "@ %client.score, 5);
		}
	}
	
	%object = %player.repairTarget;
	if (%object != -1) 
	{
		if (%object == %player) 
		{
			Client::sendMessage(%client, 3, "AutoRepair Off");
			%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
			if (%rate < 0) %rate = 0;
			GameBase::setAutoRepairRate(%object, %rate);
			return;
		}
		
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client, 3, "Repair Done");
				%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
				if (%rate < 0) %rate = 0;
				GameBase::setAutoRepairRate(%object, %rate);
				return;
			}
			else
			{
				Client::sendMessage(%client, 1, "Repair Stopped");
				%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
				if (%rate < 0) %rate = 0;
				GameBase::setAutoRepairRate(%object, %rate);
				return;
			}
		}
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{
		%object = %player.repairTarget;
		if (%object == %player) 
		{
			if (GameBase::getDamageLevel(%player) == 0) 
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else
		{
			if(GameBase::getDamageLevel(%object) == 0)
			{
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}
//===========================================================================================
// End Projectile Data:
//===========================================================================================

ItemImageData RepairGunImage
{
	shapeFile  = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy  = 10;
	lightType  = 3;
	lightRadius = 1;
	lightTime  = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire    = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	heading = $InvHeading[EnergyWeapons];
	showInventory = true;
	price = 125;
    validateShape = false;
};

function RepairGun::onMount(%player,%imageSlot){ Player::trigger(%player,$BackpackSlot,true); }
function RepairGun::onUnmount(%player,%imageSlot){ Player::trigger(%player,$BackpackSlot,false); }
function RepairGun::onUse(%player,%item){ Weapon::onUse(%player,%item); }
//====END REPAIR GUN====|


//====BEGIN REPAIR RIFLE====|
ItemImageData RepairRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType  = 2;
	projectileType = RepairRifleBolt;
	accuFire    = true;
	minEnergy   = 3;
	maxEnergy   = 10;
	lightType   = 3;
	lightRadius = 2;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepairRifle
{
	description = "Repair Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "repairpack";
    heading = $InvHeading[EnergyWeapons];
	shadowDetailMask = 4;
	imageType = RepairRifleImage;
	price = 500;
	showWeaponBar = true;
};

function RepairRifle::onUse(%player,%item)
{ Weapon::onUse(%player,%item); }
//====END REPAIR RIFLE====|



//====Begin Repair Pack====|
ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0.01;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
    heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
    validateShape = false;
    validateMaterials = false;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun || Player::getMountedItem(%player,$WeaponSlot) == RepairRifle)
	{ Player::unmountItem(%player, $WeaponSlot); }
}

function RepairPack::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{ Player::mountItem(%player, %item, $BackpackSlot); }
	else 
	{
		if(%clientId.RepairPref == AdvancedRepairGun)
		{Player::mountItem(%player, RepairRifle, $WeaponSlot);}
		else
		{Player::mountItem(%player, RepairGun, $WeaponSlot);}
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) 
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) 
		{ Player::unmountItem(%player,$WeaponSlot); }
		else
		{
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	
//====End Repair Pack====|