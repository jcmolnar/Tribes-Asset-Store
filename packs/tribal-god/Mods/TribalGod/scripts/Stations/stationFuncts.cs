$InvList[cactusPack] = 1;
$RemoteInvList[cactusPack] = 1;

$InvList[FlashGrenade] = 1; 
$RemoteInvList[FlashGrenade] = 1;

$InvList[RadiusMineAmmo] = 1; 
$RemoteInvList[RadiusMineAmmo] = 1;

$InvList[LiLBoostammo] = 1;
$RemoteInvList[LiLBoostammo] = 1;

$InvList[RepairKit] = 1;
$RemoteInvList[RepairKit] = 1;

$RemoteInvList[MineAmmo] = 1;
$RemoteInvList[Grenade] = 1;
$RemoteInvList[Beacon] = 1;

$VehicleInvList[ScoutVehicle] = 1;
$VehicleInvList[LAPCVehicle] = 1;
$VehicleInvList[HAPCVehicle] = 1;

$DataBlockName[ScoutVehicle] = Scout;
$DataBlockName[LAPCVehicle] = LAPC;
$DataBlockName[HAPCVehicle] = HAPC;

$VehicleToItem[Scout] = ScoutVehicle;
$VehicleToItem[LAPC] = LAPCVehicle;
$VehicleToItem[HAPC] = HAPCVehicle;
//===========================================================================================

function Station::onActivate(%this)
{
	%obj = Station::getTarget(%this);
	if (%obj != -1)
	{
		GameBase::playSequence(%this, 1, "activate");
		GameBase::setSequenceDirection(%this, 1, 1);
		%this.lastPlayer = %obj;
	}
	else 
	{ GameBase::setActive(%this, false); }
}

function Station::onDeactivate(%this)
{
	GameBase::stopSequence(%this,2);
	GameBase::setSequenceDirection(%this, 1, 0);
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
		if(Client::getGuiMode(%client) != 1)
		{ Client::setGuiMode(%client, 1); }
		
		%team = Client::getTeam(%client);
		if($TeamEnergy[%team] != "Infinite")
		{
			if(%this.clTeamEnergy != %client.TeamEnergy)
			{
				if(%client.teamEnergy < 0)
				{ Client::sendMessage(%client, 0, "Your total mission purchases have come to "@ (%client.teamEnergy * -1) @"."); }
				else
				{ Client::sendMessage(%client, 0, "You have increased the Team Energy by "@ %client.teamEnergy @"."); }
			}
			if((%client.teamEnergy - %client.EnergyWarning < $TeammateSpending) && ($TeammateSpending != 0) && !$TeamEnergyCheat)
			{
				TeamMessages(0, %team, "Teammate "@ Client::getName(%client) @" has spent "@ (%client.teamEnergy *-1) @" of the TeamEnergy"); 
				%client.EnergyWarning = %client.teamEnergy;
			}
			if($TeamEnergy[%team] < $WarnEnergyLow)
			{ TeamMessages(0, %team, "TeamEnergy Low: "@ $TeamEnergy[%team]); }
		}
	}
	if(%this.target != "")
	{
		(Client::getOwnedObject(%this.target)).Station = "";
		%this.target = "";
	}
	if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime())
	{ VehiclePad::checkSeq(%this.vehiclePad, %this); }
	%this.clTeamEnergy = "";
	return false;
}

function Station::onPower(%this, %power, %generator)
{
	if(%power)
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
	if(GameBase::isPowered(%this))
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
	Station::weaponCheck(%this);
	GameBase::stopSequence(%this, 0);
	GameBase::setSequenceDirection(%this, 1, 0);
	GameBase::pauseSequence(%this, 1);
	GameBase::stopSequence(%this, 2);
	Station::checkTarget(%this);
}

function Station::onDestroyed(%this)
{
	Station::weaponCheck(%this);
	StaticShape::objectiveDestroyed(%this);
	GameBase::stopSequence(%this,0);
	GameBase::stopSequence(%this,1);
	GameBase::stopSequence(%this,2);
	Station::checkTarget(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100); 
}

function Station::weaponCheck(%this)
{
	if(%this.lastPlayer != "")
	{
		%player = %this.lastPlayer;
		%player.Station = "";
		if(Player::getMountedItem(%player, $WeaponSlot) == -1)
		{
			if(%player.lastWeapon != "")
			{
				Player::useItem(%player, %player.lastWeapon);		 	
				%player.lastWeapon = "";
	  		}
		}											
	 	%this.lastPlayer = "";
  	}
}

function Station::getTarget(%this)
{
	if(GameBase::getLOSInfo(%this, 1.5, "0 0 3.14"))
	{
	  	%obj = getObjectType($los::object);
		dbecho(3, "STATION: LOS got " @ %obj);
	  	if(%obj == "Player")
	  	{
		  	if(Player::isAiControlled($los::object) != "True")
		  	{ return $los::object; }
		}
	}
	dbecho(3, "STATION: LOS Got None");
	return -1;
}	

function Station::onCollision(%this, %object)
{
	if(%this.target == "")
	{
		dbecho(3, "STATION: Collision ("@ %this @","@ %object @")");
		%obj = getObjectType(%object);
		if (%obj == "Player" && isPlayerBusy(%object) == 0)
		{
			%client = Player::getClient(%object);
			if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1 || ((Player::getClient(%object)).isGodAdmin) == true)
			{
				if(GameBase::getDamageState(%this) == "Enabled")
				{
					if(GameBase::isPowered(%this))
					{ 
						if(%this.enterTime == "")
						{ %this.enterTime = getSimTime(); }
						GameBase::setActive(%this, true);
					}
					else 
					{ Client::sendMessage(%client, 0, "Unit is not powered"); }
				}
			}
			else if(Station::getTarget(%this) == %object)
			{
				%curTime = getSimTime();
				if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
				{
					Client::clearItemShopping(%client);
					Station::onDeactivate(%this);
					Station::onEndSequence(%this, 1);
					if(Client::getGuiMode(%client) != 1)
					{ Client::setGuiMode(%client, 1); }
					%object.stationDeniedStamp = %curTime;
					Client::sendMessage(%client, 0, "--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
				}
			}
			// Can't say this unless it's your teams stations, fixed August 4th 2002 4:14pm
			if(GameBase::getTeam(%object) == GameBase::getTeam(%this) && (Player::getClient(%object)).isGodAdmin == true && GameBase::getDamageState(%this) != "Enabled")
			{ Client::sendMessage(%client, 0, "Unit is disabled~wmale4.wneedrep.wav"); }
		}
	}
}

function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player, "", RepairPatch, 1);
	%cnt = %cnt + AmmoStation::resupply(%player,"", Beacon, 10);
	%cnt = %cnt + AmmoStation::resupply(%player, "", Grenade, 10);
	%cnt = %cnt + AmmoStation::resupply(%player, "", RepairKit, 1);
	%cnt = %cnt + AmmoStation::resupply(%player, "", MineAmmo, 10);
	%cnt = %cnt + AmmoStation::resupply(%player, ChainGun, BulletAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, PlasmaGun, PlasmaAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, GrenadeLauncher, GrenadeAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, DiscLauncher, DiscAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, Mortar, MortarAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, LiLPOOmkii, LiLPOOmkiiAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, FireBallAbility, FireBallAbilityAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, SmScreenAbility, SmScreenAbilityAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, ExSmScreenAbility, ExSmScreenAbilityAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, FireScreenAbility, FireScreenAbilityAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, LiLFFB,LiLFFBAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, LiLPOOmki,LiLPOOmkiAmmo, 50);
	%cnt = %cnt + AmmoStation::resupply(%player, spellability, spellabilityAmmo, 50);
	return %cnt;
}

function resupply(%this)
{
	if(GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1)
		{
			%cnt = Station::itemsToResupply(%player);
			if(getSimTime() - %this.enterTime > 11)
			{ %cnt = 0; }
			%client = Player::getClient(%player);
			if(%cnt != 0)
			{
				updateBuyingList(%client);
				return 1;
			}
			Client::sendMessage(%client, 0, "Resupply Complete");
			return 0;
		}
	}
	return 0;
}

function setupShoppingList(%client,%station,%ListType)
{
	Client::clearItemShopping(%client);
	%armor = Player::getarmor(%client);
	%max = getNumItems();
	if(%ListType == "InvList") 
	{
		for(%i = 0; %i < %max; %i = %i + 1) 
		{
			%item = getItemData(%i);
			if($TG::ShoppingList)
			{
				if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item] && $ItemMax[%armor,%item] > 0) 
					Client::setItemShopping(%client, %item);
				else if(%item.className == Armor && !%station.dontSell[%item])
					Client::setItemShopping(%client, %item);
			}
			else
			{
				if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item]) 
					Client::setItemShopping(%client, %item);
				else if(%item.className == Armor && !%station.dontSell[%item])
					Client::setItemShopping(%client, %item);
			}
		}
	}
	else if(%ListType == "RemoteInvList") 
	{
		for(%i = 0; %i < %max; %i = %i + 1) 
		{
			%item = getItemData(%i);
			if($TG::ShoppingList)
			{
				if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item] && $ItemMax[%armor,%item] > 0) 
					Client::setItemShopping(%client, %item);
			}
			else
			{
				if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]) 
					Client::setItemShopping(%client, %item);
			}
		}
	}
	else if(%ListType == "VehicleInvList")
	{
		for(%i = 0; %i < %max; %i = %i + 1) 
		{
			%item = getItemData(%i);
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
	else
		return;
}

function updateBuyingList(%client)
{
	Client::clearItemBuying(%client);
	%station = (Client::getOwnedObject(%client)).Station;
	%stationName = GameBase::getDataName(%station);
	
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation)
	{
		%energy = %station.Energy;
		Client::setInventoryText(%client, "<f1><jc>STATION ENERGY: "@ %energy);
	}
	else
	{
		%energy = $TeamEnergy[Client::getTeam(%client)];
		Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: "@ %energy);
	}
	
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	
	for(%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
		if(!%item.showInventory)
		{ continue; }
		
		if($ItemMax[%armor, %item] != "" && Client::isItemShoppingOn(%client, %i))
		{
			%extraAmmo = 0;
			if(Player::getMountedItem(%client, $BackpackSlot) == ammopack)
			{ %extraAmmo = $AmmoPackMax[%item]; }
			
			if($ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client, %item))
			{
				if(%energy >= %item.price)
				{
					if(%item.className == Weapon)
					{
						if(Player::getItemClassCount(%client, "Weapon") < $MaxWeapons[%armor])					
						{ Client::setItemBuying(%client, %item); }
					}
					else
					{ 
						if($TeamItemMax[%item] != "")
						{
							if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
							{ Client::setItemBuying(%client, %item); }
						}
						else
						{ Client::setItemBuying(%client, %item); }
					}
				}
			}
		}
		else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client, %i)) 
		{ Client::setItemBuying(%client, %item); }
		else if(%item.className == Vehicle && $TeamItemCount[Client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client, %i))
		{ Client::setItemBuying(%client, %item); }
	}
}
//===========================================================================================


function DeployableStation::onActivate(%this)
{
	%obj = Station::getTarget(%this);
	if (%obj != -1)
	{
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
	}
	else
	{ GameBase::setActive(%this, false); }
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
{ GameBase::playSequence(%this, 0, "deploy"); }

function DeployableStation::onDeactivate(%this)
{ GameBase::stopSequence(%this, 1); }

function DeployableStation::onEnabled(%this)
{ GameBase::playSequence(%this, 2, "power"); }

function DeployableStation::onDisabled(%this)
{
	GameBase::stopSequence(%this,2);
	GameBase::stopSequence(%this,1);
	Station::checkTarget(%this);
}

function DeployableStation::onDestroyed(%this)
{
	DeployableStation::onDisabled(%this);
	%stationName = GameBase::getDataName(%this);
	
	if(%stationName == DeployableInvStation)
	{ $TeamItemCount[GameBase::getTeam(%this) @ "DeployableInvPack"]--; }
	else if(%stationName == DeployableAmmoStation)
	{ $TeamItemCount[GameBase::getTeam(%this) @ "DeployableAmmoPack"]--; }
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 0.1, 200, 100);
	Station::weaponCheck(%this);
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
				if(%this.enterTime == "")
				%this.enterTime = getSimTime();
				GameBase::setActive(%this, true);
			}
			else
			{ Client::sendMessage(%client, 0, "Unit is disabled"); }
		}
		else if(Station::getTarget(%this) == %object)
		{
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
			{
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}
//===========================================================================================