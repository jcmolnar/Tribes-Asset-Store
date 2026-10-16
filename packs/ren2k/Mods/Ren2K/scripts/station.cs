
function Station::onActivate(%this) 
{
  %obj = Station::getTarget(%this);
  if (%obj != -1) 
  {    
    GameBase::playSequence(%this,1,"activate");
    GameBase::setSequenceDirection(%this,1,1);
    %this.lastPlayer = %obj;
    //IX:BEGIN
    %obj.inStation = %this;
    if($insomniax::StationTime) 
    {
      if($insomniax::StationTime < 10) 
        $insomniax::StationTime = 10;
      else if($insomniax::StationTime > 60)
        $insomniax::StationTime = 60;
      %obj.stationAccess++;
      %dName = GameBase::getdataName(%this);
      if(%dName == InventoryStation)
        ixCheckStationEject(%obj,%this,%obj.stationAccess,($insomniax::StationTime / 5));
    }  
    //IX:END
  }
  else 
    GameBase::setActive(%this,false);
}

function Station::onDeactivate(%this) 
{
  //IX:BEGIN
  %obj = %this.lastPlayer;
  if(%this == %obj.inStation)
    %obj.inStation = false;
  //IX:END
  GameBase::stopSequence(%this,2);
  GameBase::setSequenceDirection(%this,1,0);
}

function ixCheckStationEject(%player, %station, %stat, %count)
{
	if($Insomniax::StationTime)
	{
		if((%player.inStation) && (%player.inStation == %station) && (%stat == %player.stationAccess))
		{
			if(%count)
			{
				if(%count == 1)
					Client::sendMessage(GameBase::getOwnerClient(%player),1,"You will be Ejected from the station in 5 Seconds.~waccess_denied.wav");
				schedule("ixCheckStationEject(" @ %player @ "," @ %station @ "," @ %stat @ "," @ %count - 1 @ ");",5,%player);
			}
			else
			{
				Client::sendMessage(GameBase::getOwnerClient(%player),1,"You have been Ejected from the Station to give others access to it.~waccess_denied.wav");
				ixStationEjectPlayer(%station, %player);
			}
		}
	}
}

function ixStationEjectPlayer(%station, %player)
{
	%rot = GameBase::getRotation(%station);
	%rad = getWord(%rot, 2);
	%x = (-1) * (ixSin(%rad));
	%y = ixCos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = ixDotProd(Vector::neg(%dir),10);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%vel = %x @ " " @ %y @ " " @ 15;
	Item::setVelocity(%player,%vel);
}

function ixDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}	

function ixSin(%theta)
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta)
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}

function Station::onEndSequence(%this,%thread) 
{
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
    if(Client::getGuiMode(%client) != 1) Client::setGuiMode(%client,1);
    %team = Client::getTeam(%client);
    if($TeamEnergy[%team] != "Infinite") 
    {
      if(%this.clTeamEnergy != %client.TeamEnergy) 
      {
        if(%client.teamEnergy < 0) Client::sendMessage(%client,0,"Your total mission purchases have come to " @ (%client.teamEnergy * -1) @ ".");
        else Client::sendMessage(%client,0,"You have increased the Team Energy by " @ %client.teamEnergy @ ".");
      }
      if((%client.teamEnergy -%client.EnergyWarning < $TeammateSpending) && ($TeammateSpending != 0) && !$TeamEnergyCheat) 
      {
        TeamMessages(0, %team, "Teammate " @ Client::getName(%client) @ " has spent " @ (%client.teamEnergy *-1) @ " of the TeamEnergy");
        %client.EnergyWarning = %client.teamEnergy;
      }
      if($TeamEnergy[%team] < $WarnEnergyLow) TeamMessages(0, %team, "TeamEnergy Low: " @ $TeamEnergy[%team]);
    }
    }
  if(%this.target != "") 
  {
    (Client::getOwnedObject(%this.target)).Station = "";
    %this.target = "";
  }
  if(GameBase::getDataName(%this) == VehicleStation && %this.vehiclePad.busy < getSimTime()) VehiclePad::checkSeq(%this.vehiclePad, %this);
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
  if (%this.target) 
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
  calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.40, 0.1, 250, 100);
}

function Station::getTarget(%this) 
{
  if(GameBase::getLOSInfo(%this,1.5,"0 0 3.14")) 
  {
    %obj = getObjectType($los::object);
    dbecho(3, "STATION: LOS got " @ %obj);
    if (%obj == "Player") 
    {
      if( Player::isAiControlled( $los::object ) != "True" ) 
        return $los::object;
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
          if(%this.enterTime == "") %this.enterTime = getSimTime();
          GameBase::setActive(%this,true);
        }
        else Client::sendMessage(%client,0,"Unit is not powered");
      }
      else Client::sendMessage(%client,0,"Unit is disabled");
    }
    else if(Station::getTarget(%this) == %object) 
    {
      %curTime = getSimTime();
      if(%curTime - %object.stationDeniedStamp > 3.5 && GameBase::getDamageState(%this) == "Enabled") 
      {
        Client::clearItemShopping(%client);
        Station::onDeactivate(%this);
        Station::onEndSequence(%this,1);
        if(Client::getGuiMode(%client) != 1) Client::setGuiMode(%client,1);
        %object.stationDeniedStamp = %curTime;
        Client::sendMessage(%client,0,"--ACCESS DENIED-- Wrong Team ~waccess_denied.wav");
      }
    }
  }
}

function Station::itemsToResupply(%player) 
{
  %cnt = 0;

  for (%i = 0; %i < $AmmoCount; %i++)
    %cnt = %cnt + AmmoStation::resupply(%player, $Ammo_Weapon[%i],
                                                 $Ammo_Ammo[%i],
                                                 $Ammo_Count[%i]);

//  %cnt = %cnt + AmmoStation::resupply(%player,"",RepairPatch,1);
//  %cnt = %cnt + AmmoStation::resupply(%player,"",Grenade,2);
//  %cnt = %cnt + AmmoStation::resupply(%player,"",RepairKit,1);
//  %cnt = %cnt + AmmoStation::resupply(%player,ChainGun,BulletAmmo,20);
//  %cnt = %cnt + AmmoStation::resupply(%player,PlasmaGun,PlasmaAmmo,5);
//  %cnt = %cnt + AmmoStation::resupply(%player,GrenadeLauncher,GrenadeAmmo,2);
//  %cnt = %cnt + AmmoStation::resupply(%player,DiscLauncher,DiscAmmo,2);
//  %cnt = %cnt + AmmoStation::resupply(%player,Mortar,MortarAmmo,2);
//  %cnt = %cnt + AmmoStation::resupply(%player,RocketLauncher,RocketAmmo,1);
//  %cnt = %cnt + AmmoStation::resupply(%player,SMRPack,RocketAmmo,1);
//  %cnt = %cnt + AmmoStation::resupply(%player,SniperRifle,SniperAmmo,5);
//  %cnt = %cnt + AmmoStation::resupply(%player,Railgun,RailAmmo,2);
//  %cnt = %cnt + AmmoStation::resupply(%player,Silencer,SilencerAmmo,5);
//  %cnt = %cnt + AmmoStation::resupply(%player,Vulcan,VulcanAmmo,50);
//  %cnt = %cnt + AmmoStation::resupply(%player,TranqGun,TranqAmmo,5);

  return %cnt;
}

function DeployableStation::onActivate(%this) 
{
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
  if(%stationName == DeployableInvStation) $TeamItemCount[GameBase::getTeam(%this) @ "DeployableInvPack"]--;
  else if( %stationName == DeployableAmmoStation) $TeamItemCount[GameBase::getTeam(%this) @ "DeployableAmmoPack"]--;
  calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.30, 0.1, 200, 100);
}

function DeployableStation::onCollision(%this, %object) 
{
  %obj = getObjectType(%object);
  if (%obj == "Player") 
  {
    %client = Player::getClient(%object);
    if(GameBase::getTeam(%object) == GameBase::getTeam(%this) || GameBase::getTeam(%this) == -1) 
    {
      if (GameBase::getDamageState(%this) == "Enabled") 
      {
        if(%this.enterTime == "") %this.enterTime = getSimTime();
        GameBase::setActive(%this,true);
      }
      else Client::sendMessage(%client,0,"Unit is disabled");
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

StaticShapeData AmmoStation 
{
  description = "Ammo Supply Unit";
  shapeFile = "ammounit";
  className = "Station";
  visibleToSensor = true;
  sequenceSound[0] = 
  {
    "activate", SoundActivateAmmoStation }
  ;
  sequenceSound[1] = 
  {
    "power", SoundAmmoStationPower }
  ;
  sequenceSound[2] = 
  {
    "use", SoundUseAmmoStation }
  ;
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
  if(%this.clTeamEnergy == "") %this.clTeamEnergy = (Player::getClient(Station::getTarget(%this))).TeamEnergy;
  if (Station::onEndSequence(%this,%thread)) AmmoStation::onResupply(%this);
}

function AmmoStation::onResupply(%this) 
{
  if (GameBase::isActive(%this)) 
  {
    %player = Station::getTarget(%this);
    if (%player != -1 && %this.lastPlayer == %player) 
    {
       // XXX Resupply needs work
      GameBase::SetDamageLevel(%player,0);

      %cnt = Station::itemsToResupply(%player);
      if(getSimTime() - %this.enterTime > 11) %cnt = 0;
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
     // Weaponless item such as mine, grenade, repairkit, etc 
    else if (%weapon=="" && %item!="")
    {
      teamEnergyBuySell(%player,%item.price * %delta * -1);
      Player::incItemCount(%player,%item,%delta);
      return %delta;
    }
     // Weapon item (ammo)
    else if (%weapon!="" && Player::getItemCount(%player,%weapon)>0) 
    {
      teamEnergyBuySell(%player,%item.price * %delta * -1);
      Player::incItemCount(%player,%item,%delta);
      return %delta;
    }
  }
  return 0;
}

StaticShapeData InventoryStation 
{
  description = "Station Supply Unit";
  shapeFile = "inventory_sta";
  className = "Station";
  visibleToSensor = true;
  sequenceSound[0] = 
  {
    "activate", SoundActivateInventoryStation }
  ;
  sequenceSound[1] = 
  {
    "power", SoundInventoryStationPower }
  ;
  sequenceSound[2] = 
  {
    "use", SoundUseInventoryStation }
  ;
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
       // XXX Resupply needs work
      GameBase::SetDamageLevel(%player,0);

      %client = Player::getClient(%player);
      if (%this.target != %client) 
      {
        %player.Station = %this;
        setupShoppingList(%client,%this,%InvShopList);
        updateBuyingList(%client);
        %this.target = %client;
        %this.clTeamEnergy = %client.TeamEnergy;
        if(!%client.noEnterInventory) Client::setGuiMode(%client,$GuiModeInventory);
        Client::sendMessage(%client,0,"Station Access On");
        %player.ResupplyFlag = 1;
      }
      schedule("InventoryStation::onResupply(" @ %this @ ");",0.5,%this);
      if(%player.ResupplyFlag) %player.ResupplyFlag = resupply(%this);
      return;
    }
    GameBase::setActive(%this,false);
  }
  if (%this.target) 
  {
    %player = Client::getOwnedObject(%this.target);
    Client::clearItemShopping(%this.target);
    Client::sendMessage(%this.target,0,"Station Access Off");
    Station::onEndSequence(%this);
    if(GameBase::getDataName(%player.Station) == DeployableInvStation) 
    {
      Client::setInventoryText(%this.target, "<f1><jc>TEAM ENERGY: " @ $TeamEnergy[Client::getTeam(%this.target)]);
      if(Client::getGuiMode(%this.target) != 1) Client::setGuiMode(%this.target,1);
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
      %cnt = Station::itemsToResupply(%player);
      if(getSimTime() - %this.enterTime > 11) %cnt = 0;
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

function setupShoppingList(%client,%station,%ListType) 
{

   // Fill the inventory station with the appropriate items

  %max = getNumItems();
  if(%ListType == "InvList") 
  {
    for (%i = 0; %i < %max; %i = %i + 1) 
    {
      %item = getItemData(%i);
      if ($InvList[%item] && $InvList[%item] != "" && !%station.dontSell[%item]) 
        Client::setItemShopping(%client, %item);
// Armor now uses $InvList
//      else if (%item.className == Armor && !%station.dontSell[%item] && %item != iarmorDeathmatch) 
//        Client::setItemShopping(%client, %item);
    }
  }
  else if(%ListType == "RemoteInvList") 
  {
    for (%i = 0; %i < %max; %i = %i + 1) 
    {
      %item = getItemData(%i);
      if ($RemoteInvList[%item] != "" && $RemoteInvList[%item] && !%station.dontSell[%item]) 
        Client::setItemShopping(%client, %item);
    }
  }
  else if(%ListType == "BigInvList") 
  {
    for (%i = 0; %i < %max; %i = %i + 1) 
    {
      %item = getItemData(%i);
      if ($BigInvList[%item] != "" && $BigInvList[%item] && !%station.dontSell[%item]) 
        Client::setItemShopping(%client, %item);
    }
  }
  else 
  {
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
  if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
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
    if(!%item.showInventory) continue;
    if($ItemMax[%armor, %item] != "" && Client::isItemShoppingOn(%client,%i)) 
    {
       // I'd love for this to be moved out of here
      %extraAmmo = 0;
      if(Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
        %extraAmmo = $ItemMax[%armor, %item] * $AmmoPackMult;
      if($ItemMax[%armor, %item] + %extraAmmo > Player::getItemCount(%client,%item)) 
      {
        if(%energy >= %item.price ) 
        {
          if(%item.className == Weapon) 
          {
            if(Player::getItemClassCount(%client,"Weapon") < $MaxWeapons[%armor]) Client::setItemBuying(%client, %item);
          }
          else 
          {
            if($TeamItemMax[%item] != "") 
            {
              if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) Client::setItemBuying(%client, %item);
            }
            else Client::setItemBuying(%client, %item);
          }
          }
        }
      }
    else if(%item.className == Armor && %item != $ArmorName[%armor] && Client::isItemShoppingOn(%client,%i)) Client::setItemBuying(%client, %item);
    else if(%item.className == Vehicle && $TeamItemCount[client::getTeam(%client) @ %item] < $TeamItemMax[%item] && Client::isItemShoppingOn(%client,%i)) Client::setItemBuying(%client, %item);
  }
}

StaticShapeData CommandStation 
{
  description = "Command Station";
  shapeFile = "cmdpnl";
  className = "Station";
  visibleToSensor = true;
  sequenceSound[0] = 
  {
    "activate", SoundActivateCommandStation }
  ;
  sequenceSound[1] = 
  {
    "power", SoundCommandStationPower }
  ;
  sequenceSound[2] = 
  {
    "use", SoundUseCommandStation }
  ;
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

StaticShapeData VehicleStation 
{
  description = "Station Vehicle Unit";
  shapeFile = "vehi_pur_pnl";
  className = "Station";
  visibleToSensor = true;
  sequenceSound[0] = 
  {
    "activate", SoundActivateInventoryStation }
  ;
  sequenceSound[1] = 
  {
    "power", SoundInventoryStationPower }
  ;
  sequenceSound[2] = 
  {
    "use", SoundUseInventoryStation }
  ;
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
        setupShoppingList(%client,%this,"VehicleInvList");
        updateBuyingList(%client);
        %this.target = %client;
        %this.clTeamEnergy = %client.TeamEnergy;
        Client::setGuiMode(%client,4);
        Client::sendMessage(%client,0,"Station Access On");
        %player.Station = %this;
        %numItems = Group::objectCount(GetGroup(%this));
        for(%i = 0; %i<%numItems; %i++) 
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
          schedule(%vehicle @ ".fading = \"\";VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",5,%vehicle);
          %obj.busy = getSimTime() + 5;
        }
        else 
        {
          GameBase::startFadeIn(%vehicle);
          GameBase::setPosition(%vehicle,%markerPos);
          GameBase::setRotation(%vehicle,GameBase::getRotation(%obj));
          schedule(%vehicle @ ".fading = \"\";VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",3,%vehicle);
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
  description = "Vehicle Pad";
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

function VehiclePad::onEnabled(%this) { }
function VehiclePad::onAdd(%this) { }
function VehiclePad::onCollision(%this, %object) { }
function VehiclePad::onPower(%this,%power,%generator) 
{
  if(!%power) GameBase::setActive(%this,false);
}

function VehiclePad::checkSeq(%this, %station) 
{
  if(%station.target == "") GameBase::setActive(%this,false);
}
