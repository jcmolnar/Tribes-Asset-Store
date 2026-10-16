function Station::onActivate(%this)
{
	%obj = Station::getTarget(%this);
	if (%obj != -1)
	{
		GameBase::playSequence(%this, 1, "activate");
		GameBase::setSequenceDirection(%this, 1, 1);
		%this.lastPlayer = %obj;
	}
	else GameBase::setActive(%this, false);
}

function Station::onDeactivate(%this)
{
	GameBase::stopSequence(%this, 2);
	GameBase::setSequenceDirection(%this, 1, 0);
	%this.lastPlayer = "";
}

function Station::onEndSequence(%this, %thread)
{
	if (%thread == 1 && GameBase::isActive(%this))
	{
		GameBase::playSequence(%this, 2, "use");
		return true;
	}
	%client = %this.target;
	if(%client == "")
	{
		%player = Station::getTarget(%this);
		%client = Player::getClient(%player);
	}
	if(%client != "")
	{
		if(Client::getGuiMode(%client) != 1) Client::setGuiMode(%client, 1);
	}
	if(%this.target != "")
	{
		(Client::getOwnedObject(%this.target)).Station = "";
		%this.target = "";
	}
	if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime()) VehiclePad::checkSeq(%this.vehiclePad, %this);
	%this.clCreds = "";
	return false;
}

function Station::onPower(%this,%power,%generator)
{
	if (%power)
	{
		GameBase::playSequence(%this, 0, "power");
		GameBase::playSequence(%this, 1);
	}
	else
	{
		GameBase::stopSequence(%this, 0);
		GameBase::pauseSequence(%this, 1);
		GameBase::pauseSequence(%this, 2);
		Station::checkTarget(%this);
	}
}

function Station::onEnabled(%this)
{
	if (GameBase::isPowered(%this))
	{
		GameBase::playSequence(%this, 0, "power");
		GameBase::playSequence(%this, 1);
	}
}

function Station::checkTarget(%this)
{
	if(%this.target)
	{
		Client::setGuiMode(%this.target, 1);
		GameBase::setActive(%this, false);
	}
}

function Station::onDisabled(%this)
{
	GameBase::stopSequence(%this, 0);
	GameBase::setSequenceDirection(%this, 1, 0);
	GameBase::pauseSequence(%this, 1);
	GameBase::stopSequence(%this, 2);
	Station::checkTarget(%this);
}

function Station::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	GameBase::stopSequence(%this, 0);
	GameBase::stopSequence(%this, 1);
	GameBase::stopSequence(%this, 2);
	Station::checkTarget(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 
}

function Station::getTarget(%this)
{
	if(GameBase::getLOSInfo(%this, 1.5, "0 0 3.14"))
	{
// GetLOSInfo sets the following globals: los::position, los::normal, los::object
		%obj = getObjectType($los::object);
		dbecho(3, "STATION: LOS got " @ %obj);
		if (%obj == "Player")
		{
			if(Player::isAiControlled($los::object) != "True") return $los::object;
		}
	}
	dbecho(3, "STATION: LOS Got None");
	return -1;
}

function Station::onCollision(%this, %object)
{
	if(%this.target == "")
	{
		dbecho(3, "STATION: Collision (" @ %this @ "," @ %object @ ")");
		if (getObjectType(%object) == "Player" && isPlayerBusy(%object) == 0)
		{
			%client = Player::getClient(%object);
			if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1)
			{
				if (GameBase::getDamageState(%this) == "Enabled")
				{
					if (GameBase::isPowered(%this))
					{
						if(%this.enterTime == "") %this.enterTime = getSimTime();
						GameBase::setActive(%this,true);
					}
					else Client::sendMessage(%client, 0, "Unit is not powered");
				}
				else Client::sendMessage(%client, 0, "Unit is disabled");
			}
			else if(Station::getTarget(%this) == %object)
			{
				%curTime = getSimTime();
				if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
				{
					Client::clearItemShopping(%client);
					Station::onDeactivate(%this);
					Station::onEndSequence(%this, 1);
					if(Client::getGuiMode(%client) != 1) Client::setGuiMode(%client, 1);
					%object.stationDeniedStamp = %curTime;
					Client::sendMessage(%client, 0, "--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
				}
			}
		}
	}
}

function Station::itemsToResupply(%player)
{
	%armor = Player::getArmor(%player);
	%cnt = 0;
	%cnt += AmmoStation::resupply(%player, RepairPatch, 1);
	%cnt += AmmoStation::resupply(%player, RepairKit, 1);
	for (%i = 0; %i < $AmmoCount; %i++)
	{
		if($Ammo_Weapon[%i] != "HandAmmo")
		{
			if(!Player::getItemCount(%player, $Ammo_Weapon[%i])) continue;
		}
		%cnt += AmmoStation::resupply(%player, $Ammo_Ammo[%i], $Ammo_Count[%i]);
	}
	return %cnt;
}

//----------------------------------------------------------------------------
// Deployable stations

function DeployableStation::onActivate(%this)
{
	%obj = Station::getTarget(%this);
	if (%obj != -1)
	{
		GameBase::playSequence(%this, 1, "activate");
		GameBase::setSequenceDirection(%this, 1, 1);
	}
	else GameBase::setActive(%this, false);
}


function DeployableStation::onEndSequence(%this,%thread)
{
	if(!%thread)
	{
		%this.deployed = 1;
		GameBase::playSequence(%this, 2, "power");
	}
}

function DeployableStation::deploy(%this)
{
	GameBase::playSequence(%this, 0, "deploy");
}

function DeployableStation::onDeactivate(%this)
{
	GameBase::stopSequence(%this, 1);
}

function DeployableStation::onEnabled(%this)
{
	GameBase::playSequence(%this, 2, "power");
}

function DeployableStation::onDisabled(%this)
{
	GameBase::stopSequence(%this, 2);
	GameBase::stopSequence(%this, 1);
	Station::checkTarget(%this);
}

function DeployableStation::onDestroyed(%this)
{
	DeployableStation::onDisabled(%this);
	%stationName = GameBase::getDataName(%this);
	if(%stationName == DeployableInvStation) $TeamItemCount[GameBase::getTeam(%this) @ "DeployableInvPack"]--;
	else if( %stationName == DeployableAmmoStation) $TeamItemCount[GameBase::getTeam(%this) @ "DeployableAmmoPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 0.1, 200, 100); 
}

function DeployableStation::onCollision(%this, %object)
{
	%obj = getObjectType(%object);
	if (%obj == "Player" && isPlayerBusy(%object) == 0)
	{
		%client = Player::getClient(%object);
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1)
		{
			if (GameBase::getDamageState(%this) == "Enabled")
			{
				if(%this.enterTime == "") %this.enterTime = getSimTime();
				GameBase::setActive(%this, true);
			}
			else Client::sendMessage(%client, 0, "Unit is disabled");
		}
		else if(Station::getTarget(%this) == %object)
		{
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
			{
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client, 0, "--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}

//----------------------------------------------------------------------------

StaticShapeData AmmoStation
{
	description = "Recharge Center";
	shapeFile = "ammounit";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateAmmoStation };
	sequenceSound[1] = { "power", SoundAmmoStationPower };
	sequenceSound[2] = { "use", SoundUseAmmoStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpLarge;
};

function AmmoStation::onEndSequence(%this,%thread)
{
	%player = Station::getTarget(%this);
	if(%this.clCreds == "") %this.clCreds = (Player::getClient(%player)).creds;
	if (Station::onEndSequence(%this, %thread))
	{
		AmmoStation::onResupply(%this);
	}
}

function AmmoStation::onResupply(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player)
		{
// Hardcoded here for the ammo types
			%cnt = Station::itemsToResupply(%player);
			if (%cnt != 0)
			{
				%player.waitThrowTime = getSimTime();
				schedule("AmmoStation::onResupply(" @ %this @ ");", 0.5, %this);
				return;
			}
			%player.Station = "";
			%client = Player::getClient(%player);
			%this.target = "";
			Client::sendMessage(%client, 0, "Resupply Complete");
			Client::setInventoryText(%client, "<f1><jc>Credits: " @ %client.creds);
		}
		else if(%this.target != "")
		{
			%player = Client::getOwnedObject(%this.target);
			%player.Station = "";
			%this.target = "";
		}
		else
		{
			%this.lastPlayer = "";
			%this.target = "";
		}
		GameBase::setActive(%this,false);
		%this.enterTime="";
	}
}
 
function AmmoStation::resupply(%player, %item, %delta)
{
	if(!Player::IsDead(%player))
	{
		%delta = checkResources(%player, %item, %delta, 1);
		if(%delta > 0)
		{
			if(%item == RepairPatch)
			{
				teamEnergyBuySell(%player, %item.price * %delta * -1);
				GameBase::repairDamage(%player, 0.2);
				return %delta;
			}
			else
			{
				teamEnergyBuySell(%player, %item.price * %delta * -1);
				Player::incItemCount(%player, %item, %delta);
				return %delta;
			}
		}
		return 0;
	}
}

//----------------------------------------------------------------------------
StaticShapeData DeployableAmmoStation
{
	description = "Rmt. Recharge Cntr.";
	shapeFile = "ammounit_remote";
	className = "DeployableStation";
	maxDamage = 0.25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundAmmoStationPower };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisSmall;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpMedium;
};

function DeployableAmmoStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "R-Recharge Center");
}

function DeployableAmmoStation::onActivate(%this)
{
	if(%this.deployed == 1)
	{
		GameBase::playSequence(%this,1,"use");
		schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
		%this.lastPlayer = Station::getTarget(%this);
		%player = %this.lastPlayer; 
		%player.Station = %this;
		%this.target = Player::getClient(Station::getTarget(%this));
	}
	else GameBase::setActive(%this,false);
}

//----------------------------------------------------------------------------

StaticShapeData DeployableInvStation
{
	description = "Rmt. Upgrade Cntr.";
	shapeFile = "invent_remote";
	className = "DeployableStation";
	maxDamage = 0.25;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	sequenceSound[1] = { "use", SoundUseAmmoStation };
	sequenceSound[2] = { "power", SoundInventoryStationPower };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 4;
	mapIcon = "M_station";
	debrisId = flashDebrisMedium;
	damageSkinData = "objectDamageSkins";
	explosionId = flashExpSmall;
//	triggerRadius = 1.5;
};

function DeployableInvStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "R-Inv Station");
}

function DeployableInvStation::onActivate(%this)
{
	if(%this.deployed == 1)
	{
		GameBase::playSequence(%this,1,"use");
		InventoryStation::onResupply(%this,"RemoteInvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else GameBase::setActive(%this,false);
}

//----------------------------------------------------------------------------

StaticShapeData InventoryStation
{
	description = "Upgrade Center";
	shapeFile = "inventory_sta";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};

function InventoryStation::onEndSequence(%this,%thread)
{
	if (Station::onEndSequence(%this,%thread)) InventoryStation::onResupply(%this,"InvList");
}

function InventoryStation::onResupply(%this,%InvShopList)
{
	dbecho(3, "STATION::Resupply");
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				%player.Station = %this;
				setupShoppingList(%client,%this);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clCreds = %client.creds;
				if(!%client.noEnterInventory) Client::setGuiMode(%client,$GuiModeInventory);
				Client::sendMessage(%client,0,"Station Access On");
				if($time[$ExplosionDamageType, %player] > 0) $time[$ExplosionDamageType, %player] = 0;
				if(%player.arkfire >0) %player.arkfire = "";
				if($time[$MissileDamageType, %player] > 0) $time[$MissileDamageType, %player] = 0;
				if($time[$MineDamageType, %player] > 0) $time[$MineDamageType, %player] = 0;
				%player.ResupplyFlag = 1;
			}
			%player.waitThrowTime = getSimTime();
			schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);
			if(%player.ResupplyFlag) %player.ResupplyFlag = resupply(%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target != "")
	{
		%client = %this.target;
		%player = Client::getOwnedObject(%this.target);
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);
		if(GameBase::getDataName(%player.Station) == DeployableInvStation)
		{
			Client::setInventoryText(%client, "");
			if(Client::getGuiMode(%client) != 1) Client::setGuiMode(%client,1);
			%player.Station = "";
			%this.target = "";
		}
	}
	%this.enterTime="";
}

function resupply(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
// Hardcoded here for the ammo types
			%cnt = Station::itemsToResupply(%player);
			%client = Player::getClient(%player);
			if (%cnt != 0)
			{
				updateBuyingList(%client);
				return 1;
			}
			Client::sendMessage(%client,0,"Resupply Complete");
			return 0;
		}
	}
	return 0;
}

//----------------------------------------------------------------------------
function setupShoppingList(%client,%station)
{
	Client::clearItemShopping(%client);
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	%ListType = GameBase::getDataName((Client::getOwnedObject(%client)).Station);
	if(%ListType == InventoryStation)
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			if(%item.className == Armor && !%station.dontSell[%item])
			{
				%type = $ArmorType[Client::getGender(%client), %item];
				if((%client.score < $NeedPoints[%type]) && !$NetRunner::TestMode) continue;
				Client::setItemShopping(%client, %item);
			}
			else if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item])
			{
				if(%client.score < $NeedPoints[%item] && !$NetRunner::TestMode) continue;
				if($itemmax[%armor, %item] == 0 || $itemmax[%armor, %item] == "") continue;
				if(%item.className == Tool && %client.power < 1) continue;
				Client::setItemShopping(%client, %item);
			}			 
		}
	}
	else if(%ListType == DeployableInvStation)
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			if(%client.score < $NeedPoints[%item] && !$NetRunner::TestMode) continue;
			if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item])
			{
				if($itemmax[%armor, %item] == 0 || $itemmax[%armor, %item] == "") continue;
				Client::setItemShopping(%client, %item);
			}
		}
	}
	else
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
//			if(%client.score < $NeedPoints[%item] && !$NetRunner::TestMode) continue;
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) Client::setItemShopping(%client, %item);
		}
	}
}

function updateBuyingList(%client)
{
	Client::clearItemBuying(%client);
	%station = (Client::getOwnedObject(%client)).Station;
	%stationName = GameBase::getDataName(%station); 
	%energy = %client.creds;
	Client::setInventoryText(%client, "<f1><jc>Credits: " @ %energy);
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	for (%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
		if(!Client::isItemShoppingOn(%client,%i)) continue;
		if(%item.className == Armor)
		{
			if(%energy < %item.price - $ArmorName[%client.armor].price) continue;
			if(%item == $ArmorName[%armor]) continue;
			Client::setItemBuying(%client, %item);
			continue;
		}
		if(%item.className == Backpack) 
		{
			if(%energy < %item.price - (Player::getMountedItem(%client, $BackpackSlot)).price) continue;
			if($ItemMax[%armor, %item] == "") continue;
			if($TeamItemMax[%item] != "") 
			{
				if($ItemMax[%armor, %item] <= Player::getItemCount(%client,%item)) continue;
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) Client::setItemBuying(%client, %item);
				continue;
			}
			if($ItemMax[%armor, %item] <= Player::getItemCount(%client,%item)) continue;
			Client::setItemBuying(%client, %item);
			continue;
		}
		if(%energy < %item.price) continue;
		if(%item.className == Weapon) 
		{
			if($ItemMax[%armor, %item] == "") continue;
			if($ItemMax[%armor, %item] <= Player::getItemCount(%client,%item)) continue;
			if(Player::getItemClassCount(%client,"Weapon") < ($MaxWeapons[%armor] + %client.maxwp)) Client::setItemBuying(%client, %item);
			continue;
		}
		if(%item.className == Tool) 
		{
			if($ItemMax[%armor, %item] == "") continue;
			if($ItemMax[%armor, %item] <= Player::getItemCount(%client,%item)) continue;
			if(%client.power < 1) continue;
			Client::setItemBuying(%client, %item);
			continue;
		}
		if(%item.className == Ammo || %item.className == HandAmmo)
		{
			if($ItemMax[%armor, %item] == "") continue;
			%extraAmmo = 0;
			if(Player::getMountedItem(%client,$BackpackSlot) == ammopack) %extraAmmo = floor($ItemMax[%armor, %item] * $AmmoPackMulti);
			%extraAmmo += floor(%extraAmmo * %client.ammom);
			if($ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item)) Client::setItemBuying(%client, %item);
			continue;
		}
		if($TeamItemMax[%item])
		{
			if($TeamItemCount[client::getTeam(%client) @ %item] > $TeamItemMax[%item]) continue;
			%vehicle = $DataBlockName[%item];
			if($vehicleUse[%armor, %vehicle]) Client::setItemBuying(%client, %item);
			continue;
		}
		if($ItemMax[%armor, %item] == "") continue;
		if($ItemMax[%armor, %item] > Player::getItemCount(%client,%item)) Client::setItemBuying(%client, %item);
	}
	%player = Client::getOwnedObject(%client);
	if(%player != -1)
	{
		%client.armor = Player::getArmor(%client);
		if(Player::getItemCount(%client,Beacon) > 0) %client.beacn = True;
		else %client.beacn = False;
		if(Player::getItemCount(%client,Grenade) > 0) %client.grena = True;
		else %client.grena = False;
		if(Player::getItemCount(%client,MineAmmo) > 0) %client.mines = True;
		else %client.mines = False;
		if(Player::getItemCount(%client,RepairKit) > 0) %client.repai = True;
		else %client.repai = False;
		%pack = Player::getMountedItem(%client,$BackpackSlot);
		if(%pack != -1) %client.bpack = %pack;
		%count = 1;
		for(%i = 0; %i < $WeaponCount; %i++)
		{
			if(Player::getItemCount(%client, $WeaponList[%i]))
			{
				%client.weap[%count] = $WeaponList[%i];
				%count++;
			}
		}
		for(%i = 0; %i < (10 - %count); %i++) %client.weap[%i + %count] = "";
	}
}

//----------------------------------------------------------------------------
StaticShapeData CommandStation
{
	description = "Network Center";
	shapeFile = "cmdpnl";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateCommandStation };
	sequenceSound[1] = { "power", SoundCommandStationPower };
	sequenceSound[2] = { "use", SoundUseCommandStation };
	maxDamage = 1.0;
	debrisId = flashDebrisMedium;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};

function CommandStation::onEndSequence(%this,%thread)
{
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";
	if (Station::onEndSequence(%this,%thread)) CommandStation::onResupply(%this);
}

function CommandStation::onResupply(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				%this.target = %client;
				%player.CommandTag = 1;
				Client::setGuiMode(%client,2);
				Client::sendMessage(%client,0,"Command Access On");
				%player.station = %this;
			}
			schedule("CommandStation::onResupply(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{
		Client::sendMessage(%this.target,0,"Command Access Off");
		(Client::getOwnedObject(%this.target)).CommandTag = "";
		checkControlUnmount(%this.target);
	}
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";
}

//----------------------------------------------------------------------------
StaticShapeData VehicleStation
{
	description = "Carrier Center";
	shapeFile = "vehi_pur_pnl";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};

function VehicleStation::onEndSequence(%this,%thread)
{
	if (Station::onEndSequence(%this,%thread)) VehicleStation::onBuyingVechicle(%this);
}

function VehicleStation::onBuyingVechicle(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1 && %this.lastPlayer == %player)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				setupShoppingList(%client,%this);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clCreds = %client.creds;
				Client::setGuiMode(%client,4);
				Client::sendMessage(%client,0,"Station Access On");
				%player.Station = %this;
				%numItems = Group::objectCount(GetGroup(%this));
				for(%i = 0 ; %i<%numItems ; %i++)
				{
					%obj = Group::getObject(GetGroup(%this), %i);
					%name = GameBase::getDataName(%obj); 
					if(%name == VehiclePad)
					{
						%this.vehiclePad = %obj;
						GameBase::setActive(%this.vehiclePad,true);
						%i = %numItems;
					}
				}
			}
			schedule("VehicleStation::onBuyingVechicle(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		Station::onEndSequence(%this);
	}
}

function VehicleStation::checkBuying(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%obj = %player.Station.vehiclePad;
	if(GameBase::isPowered(%obj) && GameBase::getDamageState(%obj) == "Enabled")
	{
		%markerPos = GameBase::getPosition(%obj);
		%set = newObject("set",SimSet);
		%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;
		%objInWay = containerBoxFillSet(%set,%mask,%markerPos,6,5,14,1);
		%station = %player.Station;
		if(%objInWay == 1)
		{
			%object = Group::getObject(%set, 0);
			%sName = GameBase::getDataName(%object);
			if(%sName.className == Vehicle)
			{
				if(GameBase::getControlClient(%object) == -1)
				{
					if(%station.fadeOut == "")
					{
						if(%item != $VehicleToItem[%sname])
						{
							%object.fading = 1;
							%station.fadeOut=1;
							teamEnergyBuySell(%player, $VehicleToItem[%sName].price);
							$TeamItemCount[Client::getTeam(%client) @ ($VehicleToItem[%sName])]--;
							GameBase::startFadeOut(%object);
							schedule("deleteObject(" @ %object @ ");",2.5,%object);
							schedule(%object @ ".fading = \"\";",2.5,%object);
							schedule(%station @ ".fadeOut = \"\";",2.5,%station);
							%objInWay--;
						}
						else return 2;
					}
					else
					{
						Client::SendMessage(%client,0,"ERROR - Vehicle creation pad busy"); 
						return 0;
					}
				}
				else
				{
					Client::SendMessage(%client,0,"ERROR - Vehicle in creation area is mounted");
					return 0;
				}
			} 
		}
		if(!%objInWay)
		{
			if (checkResources(%player,%item,1))
			{
				%vehicle = newObject("",flier,$DataBlockName[%item],true);
				Gamebase::setMapName(%vehicle,%item.description);
				%vehicle.clLastMount = %client;
				addToSet("MissionCleanup", %vehicle);
				%vehicle.fading = 1;
				GameBase::setTeam(%vehicle,Client::getTeam(%client));
				if(%object.fading)
				{
					schedule("GameBase::startFadeIn(" @ %vehicle @ ");",2.5,%vehicle);
					schedule("GameBase::setPosition(" @ %vehicle @ ",\"" @ %markerPos @ "\");",2.5,%vehicle);
					schedule("GameBase::setRotation(" @ %vehicle @ ",\"" @ GameBase::getRotation(%obj) @ "\");",2.5,%vehicle);
					schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",5,%vehicle);
					%obj.busy = getSimTime() + 5;
				}
				else
				{
					GameBase::startFadeIn(%vehicle);
					GameBase::setPosition(%vehicle,%markerPos);
					GameBase::setRotation(%vehicle,GameBase::getRotation(%obj));
					schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",3,%vehicle);
					%obj.busy = getSimTime() + 3;
				}
				deleteObject(%set);
				$TeamItemCount[Client::getTeam(%client) @ %item]++;
				return 1;
			}
		}
		else Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		deleteObject(%set);
	}
	else Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");
	return 0;
}

StaticShapeData VehiclePad
{
	description = "Carrier Pad";
	shapeFile = "vehi_pur_poles";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	explosionId = flashExpLarge;
	damageSkinData = "objectDamageSkins";
};

function VehiclePad::onActivate(%this)
{
	GameBase::playSequence(%this,1,"use");
}

function VehiclePad::onDeactivate(%this)
{
	GameBase::stopSequence(%this,1);
}

function VehiclePad::onEnabled(%this)
{
}

function VehiclePad::onAdd(%this)
{
}

function VehiclePad::onCollision(%this, %object)
{
}

function VehiclePad::onPower(%this,%power,%generator)
{
	if(!%power) GameBase::setActive(%this,false);
}

function VehiclePad::checkSeq(%this, %station)
{
	if(%station.target == "") GameBase::setActive(%this,false);
}