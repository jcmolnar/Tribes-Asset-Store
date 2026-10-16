function Station::onActivate(%this)
{
	//echo("Activate " @ %this);
	%obj = Station::getTarget(%this);
	if (%obj != -1)
	{
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
		%this.lastPlayer = %obj;
	}
	else 
		GameBase::setActive(%this,false);
}

function Station::onDeactivate(%this)
{
	//echo("Dectivate " @ %this);
	GameBase::stopSequence(%this,2);
	GameBase::setSequenceDirection(%this,1,0);
}

function Station::onEndSequence(%this,%thread)
{
	//echo("End sequence " @ %this);
 	if (%thread == 1 && GameBase::isActive(%this))
 	{
		GameBase::playSequence(%this,2,"use");
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
			Client::setGuiMode(%client,1);
		
		%team = Client::getTeam(%client);
		if($TeamEnergy[%team] != "Infinite")
		{
			if(%this.clTeamEnergy != %client.TeamEnergy)
			{
				if(%client.teamEnergy < 0)
					Client::sendMessage(%client,0,"Your total mission purchases have come to " @ (%client.teamEnergy * -1) @ ".");
				else
					Client::sendMessage(%client,0,"You have increased the Team Energy by " @ %client.teamEnergy @ ".");
			}
			if((%client.teamEnergy -%client.EnergyWarning < $TeammateSpending) && ($TeammateSpending != 0) && !$TeamEnergyCheat)
			{
				TeamMessages(0, %team, "Teammate " @ Client::getName(%client) @ " has spent " @ (%client.teamEnergy *-1) @ " of the TeamEnergy"); 
				%client.EnergyWarning = %client.teamEnergy;
			}
			if($TeamEnergy[%team] < $WarnEnergyLow)  
				TeamMessages(0, %team, "TeamEnergy Low: " @ $TeamEnergy[%team]); 
		}
	}
	if(%this.target != "")
	{
		(Client::getOwnedObject(%this.target)).Station = "";
		%this.target = "";
	}
	if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime())
		VehiclePad::checkSeq(%this.vehiclePad, %this);
	%this.clTeamEnergy = "";
	return false;
}

function Station::onPower(%this,%power,%generator)
{
	if (%power)
	{
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
	}
	else
	{
		GameBase::stopSequence(%this,0);
		GameBase::pauseSequence(%this,1);
		GameBase::pauseSequence(%this,2);
		Station::checkTarget(%this);
	}
}

function Station::onEnabled(%this)
{
	if (GameBase::isPowered(%this))
	{		
		GameBase::playSequence(%this,0,"power");
		GameBase::playSequence(%this,1);
	}
}

function Station::checkTarget(%this)
{
	if(%this.target)
	{
		Client::setGuiMode(%this.target,1);
		GameBase::setActive(%this,false);
	}
}

function Station::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::pauseSequence(%this,1);
	GameBase::stopSequence(%this,2);
	Station::checkTarget(%this);
}

function Station::onDestroyed(%this)
{
	StaticShape::objectiveDestroyed(%this);
	GameBase::stopSequence(%this,0);
	GameBase::stopSequence(%this,1);
	GameBase::stopSequence(%this,2);
	Station::checkTarget(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 
		0.1, 250, 100); 
}

function Station::getTarget(%this)
{
	if(GameBase::getLOSInfo(%this,1.5,"0 0 3.14"))
	{
	  	// GetLOSInfo sets the following globals:
	  	// 	los::position
	  	// 	los::normal
	  	// 	los::object
	  	%obj = getObjectType($los::object);
		dbecho(3, "STATION: LOS got " @ %obj);
	  	if (%obj == "Player")
	  	{
			if( Player::isAiControlled( $los::object ) != "True" )
			{
				return $los::object;
			}
		}
	}
	dbecho(3, "STATION: LOS Got None");
	return -1;
}	

function Station::onCollision(%this, %object)
{
	dbecho(3, "STATION: Collision (" @ %this @ "," @ %object @ ")");
	%obj = getObjectType(%object);
	if (%obj == "Player")
	{
  	 	%client = Player::getClient(%object);
 		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1)
 		{
			if (GameBase::getDamageState(%this) == "Enabled")
			{
				if (GameBase::isPowered(%this))
				{ 
					if(%this.enterTime == "")
						%this.enterTime = getSimTime();
					GameBase::setActive(%this,true);
				}
				else 
					Client::sendMessage(%client,0,"Unit is not powered");
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
		}
		else if(Station::getTarget(%this) == %object)
		{
			%curTime = getSimTime();
			if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled")
			{
				Client::clearItemShopping(%client);
				Station::onDeactivate(%this);
				Station::onEndSequence(%this,1);
				if(Client::getGuiMode(%client) != 1)
					Client::setGuiMode(%client,1);
				%object.stationDeniedStamp = %curTime;
				Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
			}
		}
	}
}

function Station::itemsToResupply(%player)
{
	%cnt = 0;
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
//	%cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
//	%cnt = %cnt + AmmoStation::resupply(%player,"",MineAmmo,1);
//	%cnt = %cnt + AmmoStation::resupply(%player,"",Beacon,1);
	if(Player::getItemCount(%player, EMPGrenade))
		%cnt = %cnt + AmmoStation::resupply(%player,"",EMPGrenade,2);
	else if(Player::getItemCount(%player, Plastique))
		%cnt = %cnt + AmmoStation::resupply(%player,"",Plastique,1);
	else if(Player::getItemCount(%player, FlareGrenade))
		%cnt = %cnt + AmmoStation::resupply(%player,"",FlareGrenade,3);
	else if(Player::getItemCount(%player, ConcussionGrenade))
		%cnt = %cnt + AmmoStation::resupply(%player,"",ConcussionGrenade,2);
	else if(Player::getItemCount(%player, PoisonGrenade))
		%cnt = %cnt + AmmoStation::resupply(%player,"",PoisonGrenade,1);
	else if(Player::getItemCount(%player, SuicideBomb))
	{
		 //max 1
	}
	else if(Player::getItemCount(%player, TearGasGrenade))
		%cnt = %cnt + AmmoStation::resupply(%player,"",TearGasGrenade,1);
	else if(Player::getItemCount(%player, ECMGrenade))
		%cnt = %cnt + AmmoStation::resupply(%player,"",ECMGrenade,2);
	else if(Player::getItemCount(%player, Scrambler))
		%cnt = %cnt + AmmoStation::resupply(%player,"",Scrambler,1);
	else
		%cnt = %cnt + AmmoStation::resupply(%player,"",OriginalGrenade,2);
	if(Player::getItemCount(%player, ReplicatingMine))
		%cnt = %cnt + AmmoStation::resupply(%player,"",ReplicatingMine,1);
	else if(Player::getItemCount(%player, HologramMine))
		%cnt = %cnt + AmmoStation::resupply(%player,"",HologramMine,1);
	else if(Player::getItemCount(%player, SatchelCharge))
		%cnt = %cnt + AmmoStation::resupply(%player,"",SatchelCharge,1);
	else if(Player::getItemCount(%player, SpringMine))
		%cnt = %cnt + AmmoStation::resupply(%player,"",SpringMine,1);
	else if(Player::getItemCount(%player, PhaseLokMine))
	{
		 //max 1
	}
	else if(Player::getItemCount(%player, FlagMine))
		%cnt = %cnt + AmmoStation::resupply(%player,"",FlagMine,1);
	else if(Player::getItemCount(%player, JailMine))
		%cnt = %cnt + AmmoStation::resupply(%player,"",JailMine,1);
	else if(Player::getItemCount(%player, PointLaserMine))
		%cnt = %cnt + AmmoStation::resupply(%player,"",PointLaserMine,1);
	else if(Player::getItemCount(%player, EMPMine))
		%cnt = %cnt + AmmoStation::resupply(%player,"",EMPMine,1);
	else
		%cnt = %cnt + AmmoStation::resupply(%player,"",OriginalMine,1);
	if(Player::getItemCount(%player, PulseBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",PulseBeacon,1);
	else if(Player::getItemCount(%player, MotionBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",MotionBeacon,1);
	else if(Player::getItemCount(%player, CameraBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",CameraBeacon,1);
	else if(Player::getItemCount(%player, JammerBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",JammerBeacon,1);
	else if(Player::getItemCount(%player, ShieldBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",ShieldBeacon,1);
	else if(Player::getItemCount(%player, TeleportBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",TeleportBeacon,1);
	else if(Player::getItemCount(%player, AlarmBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",AlarmBeacon,1);
	else if(Player::getItemCount(%player, CloakBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",CloakBeacon,1);
	else if(Player::getItemCount(%player, EnergyBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",EnergyBeacon,1);
	else if(Player::getItemCount(%player, PadBeacon))
		%cnt = %cnt + AmmoStation::resupply(%player,"",PadBeacon,1);
	else
		%cnt = %cnt + AmmoStation::resupply(%player,"",TargetBeacon,1);
	%cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
	%cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,20);
	%cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5);
	%cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,RocketLauncher,RocketAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,SniperAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,FlareGun,FlareAmmo,2);
	%cnt = %cnt + AmmoStation::resupply(%player,MineLauncher,MinelAmmo,2);

	return %cnt;
}

//----------------------------------------------------------------------------
// Deployable stations

function DeployableStation::onActivate(%this)
{
	//echo("Activate " @ %this);
	%obj = Station::getTarget(%this);
	if (%obj != -1)
	{
		GameBase::playSequence(%this,1,"activate");
		GameBase::setSequenceDirection(%this,1,1);
	}
	else 
		GameBase::setActive(%this,false);
}


function DeployableStation::onEndSequence(%this,%thread)
{
	if(!%thread)
	{
		%this.deployed = 1;
		GameBase::playSequence(%this,2,"power");
	}
}

function DeployableStation::deploy(%this)
{
	GameBase::playSequence(%this,0,"deploy");
}

function DeployableStation::onDeactivate(%this)
{
	//echo("Dectivate " @ %this);
	GameBase::stopSequence(%this,1);
}

function DeployableStation::onEnabled(%this)
{
	GameBase::playSequence(%this,2,"power");
}

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
		$TeamItemCount[GameBase::getTeam(%this) @ "DeployableInvPack"]--;
	else if( %stationName == DeployableAmmoStation) 
	  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableAmmoPack"]--;
	else if(%stationName == BotStation)
		$TeamItemCount[GameBase::getTeam(%this) @ "BotStationPack"]--;
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 
		0.1, 200, 100); 
}

function DeployableStation::onCollision(%this, %object)
{
	//echo("Collision (" @ %this @ "," @ %object @ ")");
	%obj = getObjectType(%object);
	if (%obj == "Player")
	{
  	 	%client = Player::getClient(%object);
		if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1)
		{
			if (GameBase::getDamageState(%this) == "Enabled") 
			{
				if(%this.enterTime == "") 
					%this.enterTime = getSimTime();
				GameBase::setActive(%this,true);
			}
			else 
				Client::sendMessage(%client,0,"Unit is disabled");
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

//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

StaticShapeData AmmoStation
{
	description = "Ammo Supply Unit";
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
	//echo("End Seq ",%thread);
	if(%this.clTeamEnergy == "")
		%this.clTeamEnergy = (Player::getClient(Station::getTarget(%this))).TeamEnergy;
	if (Station::onEndSequence(%this,%thread)) 
		AmmoStation::onResupply(%this);
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
			if(getSimTime() - %this.enterTime > 11)
				%cnt = 0;
			if (%cnt != 0)
			{
				schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
				return;
			}
			%client = Player::getClient(%player);
			Client::sendMessage(%client,0,"Resupply Complete");
			Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%client)]);
		}
		GameBase::setActive(%this,false);
		%this.enterTime="";
	}
}
		 											
function AmmoStation::resupply(%player,%weapon,%item,%delta)
{
	%delta = checkResources(%player,%item,%delta,1);		
	if(%delta > 0)
	{						
		if(%item == RepairPatch)
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			GameBase::repairDamage(%player,0.06);
		 	return %delta;
		}
		else if (%item == RepairKit)
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
		 	return %delta;
		}
		else if(%item.className == "Grenade")
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
			Player::setItemCount(%player,Grenade, Player::getItemCount(%player, %item));
		 	return %delta;
		}
		else if(%item.className == "mine")
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
			Player::setItemCount(%player,MineAmmo, Player::getItemCount(%player, %item));
		 	return %delta;
		}
		else if(%item.className == "Beacon")
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
			Player::setItemCount(%player,Beacon, Player::getItemCount(%player, %item));
		 	return %delta;
		}
		else if (Player::getItemCount(%player,%weapon))
		{
			teamEnergyBuySell(%player,%item.price * %delta * -1);
			Player::incItemCount(%player,%item,%delta);
		 	return %delta;
		}
	}
	return 0;
}

//----------------------------------------------------------------------------
StaticShapeData DeployableAmmoStation
{
   description = "Remote Ammo Unit";
	shapeFile = "ammounit_remote";
	className = "DeployableStation";
	maxDamage = 0.9;
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
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Ammo Station");
	%this.Energy = $RemoteAmmoEnergy;
}

function DeployableAmmoStation::onActivate(%this)
{
	if(%this.deployed == 1) {
		GameBase::playSequence(%this,1,"use");
		//echo("Activate " @ %this);
		schedule("AmmoStation::onResupply(" @ %this @ ");",0.5,%this);
		%this.lastPlayer = Station::getTarget(%this);
	}
	else 
		GameBase::setActive(%this,false);	
}


//----------------------------------------------------------------------------

StaticShapeData DeployableInvStation
{
	description = "Remote Inv Unit";
	shapeFile = "invent_remote";
	className = "DeployableStation";
	maxDamage = 0.9;
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
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "R-Inv Station");
	%this.Energy = $RemoteInvEnergy;
}

function DeployableInvStation::onActivate(%this)
{
	if(%this.deployed == 1)
	{
		GameBase::playSequence(%this,1,"use");
		//echo("Activate " @ %this);
 		InventoryStation::onResupply(%this,"RemoteInvList");
		%this.lastPlayer = Station::getTarget(%this);
	}
	else
		GameBase::setActive(%this,false);
}


//----------------------------------------------------------------------------

StaticShapeData InventoryStation
{
   description = "Station Supply Unit";
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
	//echo("End Seq ",%thread);
	if (Station::onEndSequence(%this,%thread))
		InventoryStation::onResupply(%this,"InvList");
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
				setupShoppingList(%client,%this,%InvShopList);
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				if(!%client.noEnterInventory)
					Client::setGuiMode(%client,$GuiModeInventory);
				Client::sendMessage(%client,0,"Station Access On");
				%player.ResupplyFlag = 1;
			}
			schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);
			if(%player.ResupplyFlag) 
			   %player.ResupplyFlag = resupply(%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{	   
		%player = Client::getOwnedObject(%this.target);
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		DeployableStation::onEndSequence(%this);
		if(GameBase::getDataName(%player.Station) == DeployableInvStation)
		{
			Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
			if(Client::getGuiMode(%this.target) != 1)
				Client::setGuiMode(%this.target,1);
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
			if(getSimTime() - %this.enterTime > 11)
				%cnt = 0;
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
function setupShoppingList(%client,%station,%ListType)
{
	%max = getNumItems();
	if(%ListType == "InvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			if($InvList[%item] != "" && $InvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
			else if(%item.className == Armor && !%station.dontSell[%item])  
				Client::setItemShopping(%client, %item);
		}
	}
	else if(%ListType == "RemoteInvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			if($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
	else if(%ListType == "BotInvList")
	{
		for (%i = 0; %i < %max; %i = %i + 1)
		{
			%item = getItemData(%i);
			if($BotInvList[%item] != "" && $BotInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
	else {
		for (%i = 0; %i < %max; %i = %i + 1)
		{						
			%item = getItemData(%i);
			if($VehicleInvList[%item] != "" && $VehicleInvList[%item] && !%station.dontSell[%item]) 
				Client::setItemShopping(%client, %item);
		}
	}
}

function updateBuyingList(%client)
{
   Client::clearItemBuying(%client);
	%station = (Client::getOwnedObject(%client)).Station;
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation || %stationName == BotStation)
	{
		%energy = %station.Energy;
		Client::setInventoryText(%client, "<f1><jc>STATION ENERGY: " @ %energy );
	}
	else
	{
		%energy = $TeamEnergy[Client::getTeam(%client)];
		Client::setInventoryText(%client, "<f1><jc>TEAM ENERGY: " @ %energy);
	}
	%armor = Player::getArmor(%client);
	%max = getNumItems();
	for (%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
		if(!%item.showInventory)
			continue;
		if($ItemMax[%armor, %item] != "" && Client::isItemShoppingOn(%client,%i))
		{
			%extraAmmo = 0;
			if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
				%extraAmmo = $AmmoPackMax[%item];
			if($ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item))
			{
				if(%energy >= %item.price )
				{
					if(%item.className == Weapon)
					{
						if(Player::getItemClassCount(%client,"Weapon") < $MaxWeapons[%armor])					
							Client::setItemBuying(%client, %item);
					}
					else if(%item.className == Tool)
					{
						if(Player::getItemClassCount(%client,"Tool") < $MaxTools[%armor])					
							Client::setItemBuying(%client, %item);
					}
					else
					{ 
						if($TeamItemMax[%item] != "")
						{						
							if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
								Client::setItemBuying(%client, %item);
						}
						else
							Client::setItemBuying(%client, %item);
					}
				}
			}
		}
		else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client,%i)) 
			Client::setItemBuying(%client, %item);
		else if(%item.className == Bot && $TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client,%i)) 
			Client::setItemBuying(%client, %item);
		else if(%item.className == Vehicle && $TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client,%i))
			Client::setItemBuying(%client, %item);
	}
}

//----------------------------------------------------------------------------
StaticShapeData CommandStation
{
	description = "Command Station";
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
	//echo("End Seq ",%thread);
	(Client::getOwnedObject(%this.target)).Station = "";
	%this.target = "";
	if (Station::onEndSequence(%this,%thread)) 
		CommandStation::onResupply(%this);
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
	description = "Station Vehicle Unit";
	shapeFile = "vehi_pur_pnl";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
//	explosionId = DebrisExp;
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
	//echo("End Seq ",%thread);
	if (Station::onEndSequence(%this,%thread))
		VehicleStation::onBuyingVechicle(%this);
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
				setupShoppingList(%client,%this,"VehicleInvList");
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
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
							teamEnergyBuySell(%player,$VehicleToItem[%sName].price);
							$TeamItemCount[Client::getTeam(%client) @ ($VehicleToItem[%sName])]--;
							GameBase::startFadeOut(%object);
							schedule("deleteObject(" @ %object @ ");",2.5,%object);
							schedule(%object @ ".fading = \"\";",2.5,%object);
							schedule(%station @ ".fadeOut = \"\";",2.5,%station);
							%objInWay--;
						}
						else
							return 2;
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
		else
			Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		deleteObject(%set);
	}	
	else
		Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");

	return 0;
}


StaticShapeData VehiclePad
{
	description = "Vehicle Pad";
	shapeFile = "vehi_pur_poles";
	className = "Station";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
	maxDamage = 1.5;
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
	if(!%power)
		GameBase::setActive(%this,false);
}

function VehiclePad::checkSeq(%this, %station)
{
	if(%station.target == "")
		GameBase::setActive(%this,false);
}

//----------------------------------------------------------------------------
StaticShapeData BotStation
{
	description = "Bot Purchase Station";
	shapeFile = "vehi_pur_pnl";
	className = "DeployableStation";
	visibleToSensor = true;
	sequenceSound[0] = { "activate", SoundActivateInventoryStation };
	sequenceSound[1] = { "power", SoundInventoryStationPower };
	sequenceSound[2] = { "use", SoundUseInventoryStation };
//	explosionId = DebrisExp;
	maxDamage = 1.0;
	debrisId = flashDebrisLarge;
	mapFilter = 4;
	mapIcon = "M_station";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	triggerRadius = 1.5;
	explosionId = flashExpLarge;
};

function BotStation::onAdd(%this)
{
	schedule("DeployableStation::deploy(" @ %this @ ");",1,%this);
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Bot Station");
	%this.Energy = 5000;
}

function BotStation::onEndSequence(%this,%thread)
{
	//echo("End Seq ",%thread);
 	if (%thread == 1 && GameBase::isActive(%this))
 	{
		GameBase::setSequenceDirection(%this,2,1);
		GameBase::playSequence(%this,2,"use");
		BotStation::onBuyingBot(%this);
	}
}


function BotStation::onBuyingBot(%this)
{
	if (GameBase::isActive(%this))
	{
		%player = Station::getTarget(%this);
		if (%player != -1) // && %this.lastPlayer == %player)
		{
			%client = Player::getClient(%player);
			if (%this.target != %client)
			{
				setupShoppingList(%client,%this,"BotInvList");
				updateBuyingList(%client);
				%this.target = %client;
				%this.clTeamEnergy = %client.TeamEnergy;
				Client::setGuiMode(%client,4);
				Client::sendMessage(%client,0,"Station Access On");
				%player.Station = %this;
			}
			schedule("BotStation::onBuyingBot(" @ %this @ ");",0.5,%this);
			return;
		}
		GameBase::setActive(%this,false);
	}
	if (%this.target)
	{	   
		Client::clearItemShopping(%this.target);
		Client::sendMessage(%this.target,0,"Station Access Off");
		DeployableStation::onEndSequence(%this);
		Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
		GameBase::stopSequence(%this,2);
		if(Client::getGuiMode(%this.target) != 1)
			Client::setGuiMode(%this.target,1);
		GameBase::stopSequence(%this,1);
		GameBase::setSequenceDirection(%this,2,0);
		GameBase::playSequence(%this,2,"use");
		%player.Station = "";
		%this.target = "";
	}
}


function BotStation::checkBuying(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%teamnum = GameBase::getTeam(%client);
	if (checkResources(%player,%item,1) && $TeamBotUnavailable[%teamnum] == 0)
	{
		%bot = $DataBlockName[%item];
		AI::SpawnAdditionalBot(%bot, %teamnum, %client, 1);
		echo("MSG: ",%client," deployed a ",%bot," bot");
		$TeamItemCount[Client::getTeam(%client) @ %item]++;
		$TeamBotUnavailable[%teamnum] = 1;
		TeamMessages(1, %teamnum, Client::GetName(%client) @ " bought a bot. No more bots available for 60 seconds.~waccess_denied.wav");
		schedule("BotStation::BotAvailable(" @ %teamnum @ ");",60);
		return 1;
	}
	return 0;
}

function BotStation::BotAvailable(%teamnum)
{
	$TeamBotUnavailable[%teamnum] = 0;
	TeamMessages(1, %teamnum, "Bots now available again.");
}
