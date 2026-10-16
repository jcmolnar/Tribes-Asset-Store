
// Global object damage skins (staticShapes Turrets Stations Sensors)
DamageSkinData objectDamageSkins
{
   bmpName[0] = "dobj1_object";
   bmpName[1] = "dobj2_object";
   bmpName[2] = "dobj3_object";
   bmpName[3] = "dobj4_object";
   bmpName[4] = "dobj5_object";
   bmpName[5] = "dobj6_object";
   bmpName[6] = "dobj7_object";
   bmpName[7] = "dobj8_object";
   bmpName[8] = "dobj9_object";
   bmpName[9] = "dobj10_object";
};

//----------------------------------------------------------------------------
// Server side methods


function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	// IF - Cost positive selling    IF - Cost Negitive buying 
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) {
		%station.Energy += %cost;			//Remote StationEnergy
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite") { 
		$TeamEnergy[%team] += %cost;    //Total TeamEnergy
 		%client.teamEnergy += %cost;   //Personal TeamEnergy
	}
}

function isPlayerBusy(%client)
{
	// Can't buy things if busy shooting.
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	if (isPlayerBusy(%client))
		return;

   // only can buy fav every 1/2 second
   %time = getIntegerTime(true) >> 4; // int half seconds
   if(%time <= %client.lastBuyFavTime)
      return;

   %client.lastBuyFavTime = %time;

	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" ) {
		%stationName = GameBase::getDataName(%station); 
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) 
			%energy = %station.Energy;
		else 
			%energy = $TeamEnergy[Client::getTeam(%client)];
		if(%energy == "Infinite" || %energy > 0) {
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				if ($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats) {
					%count = Player::getItemCount(%client,%item);
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			for (%i = 0; %i < 20; %i++) { 
				if(%favItem[%i] != "") {
					%item = getItemData(%favItem[%i]);
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) {
						if(!buyItem(%client,%item))  
							%error = 1;
						else
							%bought++;
					}
				}
		  	}
			if(%bought) {
				if(%error) 
					Client::sendMessage(%client,0,"~wC_BuySell.wav");
				else 
					Client::SendMessage(%client,0,"~wbuysellsound.wav");
			}
			updateBuyingList(%client);
		}
	}
}


function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}


function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
//
//-------------------------------------------
	if (Player::getMountedItem(%client,$BackpackSlot) == "AssaultPack" && $AssaultPackMax[%item] != "") {
		%extraAmmo = $AssaultPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	else if (Player::getMountedItem(%client,$BackpackSlot) == "DefenderPack" && $DefenderPackMax[%item] != "") {
		%extraAmmo = $DefenderPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	else if (Player::getMountedItem(%client,$BackpackSlot) == "SniperPack" && $SniperPackMax[%item] != "") {
		%extraAmmo = $SniperPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	else if (Player::getMountedItem(%client,$BackpackSlot) == "MinelayerPack" && $MinelayerPackMax[%item] != "") {
		%extraAmmo = $MinelayerPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
//-------------------------------------------
//
	if($TestCheats == 0 && %client.spawn == "") {
		%energy = $TeamEnergy[%team];
    	%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation){
			%energy = %station.Energy;
		}
		if(%energy != "Infinite") {
			if (%item.price * %delta > %energy)	
				%delta = %energy / %item.price; 
			if(%delta < 1 ) {
				if(%noMessage == "")
					Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
				return 0;
			}
		}
	}
	if(%item.className == Weapon) {
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Weapon");
		if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) {
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}
	else if(%item == RepairPatch) {
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) 
			return 1;
		return 0;
   }
   else if($TeamItemMax[%item] != "" && !$TestCheats) {
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) {
			Client::sendMessage(%client,0,"Team Item limit reached for " @ %item.description @ "s");
			return 0;
		}
	}
	if(%item.className != Armor && %item.className != Vehicle) {
	   %count = Player::getItemCount(%client,%item);
	  	%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
	   if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if (%item.className == Armor) {
//
//--------------------------------------
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
//--------------------------------------
//
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) {
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
     				Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				Player::setItemCount(%client, %item, 1);  
//
//--------------------------------------
					$TeamItemCount[GameBase::getTeam(%client) @ %item]++;
					$TeamItemCount[GameBase::getTeam(%client) @ %armor]--;

					if (Player::getMountedItem(%client,$BackpackSlot) == "DefenderPack") 
						fillDefenderPack(%client);	
					else if (Player::getMountedItem(%client,$BackpackSlot) == "SniperPack") 
						fillSniperPack(%client);	
					else if (Player::getMountedItem(%client,$BackpackSlot) == "AssaultPack") 
						fillAssaultPack(%client);	
					else if (Player::getMountedItem(%client,$BackpackSlot) == "MinelayerPack") 
						fillMinelayerPack(%client);	
//--------------------------------------
//
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
//
//--------------------------------------
			if (%pack != -1) {
				if(%pack == "AssaultPack" || %pack == "DefenderPack" || %pack == "SniperPack" || %pack == "MinelayerPack") 
					checkMax(%client,%armor);
//--------------------------------------
//
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
//
//--------------------------------------
				if(%item == "AssaultPack") 
					fillAssaultPack(%client);
				else if(%item == "DefenderPack") 
					fillDefenderPack(%client);
				else if(%item == "SniperPack") 
					fillSniperPack(%client);
				else if(%item == "MinelayerPack") 
					fillMinelayerPack(%client);
//--------------------------------------
//
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
//
//--------------------------------------
				if(%item == "AssaultPack") 
					fillAssaultPack(%client);
				else if(%item == "DefenderPack") 
					fillDefenderPack(%client);
				else if(%item == "SniperPack") 
					fillSniperPack(%client);
				else if(%item == "MinelayerPack") 
					fillMinelayerPack(%client);
//--------------------------------------
//
			}				 
		}
//
//--------------------------------------
		else if (%item.className == Sensor) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 	}
			if(Player::getMountedItem(%client,$BackpackSlot) == "ScoutPack" && %item != "Beacon") {
				Client::sendMessage(%client,0,"Can only use Beacon sensors while wearing a Scout Pack.");
				return 0;
				}
			%sensor = Player::getMountedItem(%client,$SensorSlot);
			if(%sensor != -1) {
				while(Player::getMountedItem(%client,$SensorSlot) != -1) {
					teamEnergyBuySell(%player,%sensor.price);
					Player::decItemCount(%client,%sensor);
					}
				}
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				if(%item != "Beacon" || Player::getMountedItem(%client,$SensorSlot) == -1)
					Player::useItem(%client,%item);									 
				return 1;
			}
		}
//--------------------------------------
//

//
//--------------------------------------
		else if (%item.className == HandAmmo) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 	}
			if(Player::getMountedItem(%client,$BackpackSlot) == "MinelayerPack" && %item != "MineAmmo") {
				Client::sendMessage(%client,0,"Can only use mines while wearing a Minelayer Pack.");
				return 0;
				}
			if(Player::getMountedItem(%client,$BackpackSlot) == "DefenderPack" && %item != "MineAmmo") {
				Client::sendMessage(%client,0,"Can only use mines while wearing a Defender Pack.");
				return 0;
				}
			if(Player::getMountedItem(%client,$BackpackSlot) == "AssaultPack" && %item != "Grenade") {
				Client::sendMessage(%client,0,"Can only use frag grenades while wearing an Assault Pack.");
				return 0;
				}
			%mine = Player::getMountedItem(%client,$MineSlot);
			if(%mine != -1) {
				while(Player::getMountedItem(%client,$MineSlot) != -1) {
					teamEnergyBuySell(%player,%mine.price);
					Player::decItemCount(%client,%mine);
					}
				}
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				if(Player::getMountedItem(%client,$MineSlot) == -1) 
					Player::useItem(%client,%item);									 
				return 1;
			}
		}
//--------------------------------------
//

//
//--------------------------------------
		else if (%item.className == RepairKit) {
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				if(Player::getMountedItem(%client,$RepairKitSlot) == -1) 
					Player::useItem(%client,%item);									 
				return 1;
			}
		}
//--------------------------------------
//
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "") {
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats) {
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) {
		   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
		else {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
		    %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			 if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
		
 	}
	return 0;
}

function armorChange(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != "") {
		%sPos = GameBase::getPosition(%player.Station);
		%pPos	= GameBase::getPosition(%client);
		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1);	
	  	%newPosX = (getWord(%vec,0) * 1) + %posX;		 
		%newPosY = (getWord(%vec,1) * 1) + %posY;
		GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ);
	}
}

function remoteBuyItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	if(buyItem(%client,%item)) {
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else 
  		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

function remoteSellItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) {
		if(Player::getItemCount(%client,%item) && %item.className != Armor) {
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) {
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count; 
				else 
					%numsell = $SellAmmo[%item];
			}

//
//-------------------------
			else if (%item == "AssaultPack" || %item == "DefenderPack" || %item == "SniperPack" || %item == "MinelayerPack") 
				checkMax(%client,Player::getArmor(%client));
//-------------------------
//
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}

			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			if(%item.className == Weapon && $WeaponAmmo[%item] != "") {
				%ammo = $WeaponAmmo[%item];
				%count = Player::getItemCount(%client, %item);
				teamEnergyBuySell(%player,%ammo.price * %count);
				Player::setItemCount(%player,%ammo,0);
			}
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}

function remoteUseItem(%client,%type)
{
	%client.throwStrength = 1;

	%item = getItemData(%type);
	if (%item == Backpack) 
		%item = Player::getMountedItem(%client,$BackpackSlot);
	else {
		if (%item == Weapon) 
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	Player::useItem(%client,%item);
}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
				if (%strength < 0)
					%strength = 0;
				else
					if (%strength > 100)
						%strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%type);
		}
	}
}

function remoteDropItem(%client,%type)
{
	if((Client::getOwnedObject(%client)).driver != 1) {
		%client.throwStrength = 1;
		%item = getItemData(%type);
		if (%item == Backpack) {
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
	    else if (%item == Weapon) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon) {
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
		}
		else 
			Player::dropItem(%client,%item);
	}
}

function remoteDeployItem(%client,%type)
{
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

function remoteNextWeapon(%client)
{
	if(GameBase::getDataName(%client.vehicle) == "Scout") {
		%vehicle = %client.vehicle;
		if(%vehicle.fireMode == Missiles) {
			%vehicle.fireMode = Chaingun;
			BottomPrint(%client, "Chaingun Mode - Bullets: "@ %vehicle.bullets); 
		}
		else {
			%vehicle.fireMode = Missiles;
			BottomPrint(%client, "Missile Mode - Missiles: "@ %vehicle.missiles); 
		}
	}
	else {
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (%item == -1 || $NextWeapon[%item] == "")
			selectValidWeapon(%client);
		else {
			for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) {
				if (isSelectableWeapon(%client,%weapon)) {
					Player::useItem(%client,%weapon);
					// Make sure it mounted (laser may not), or at least
					// next in line to be mounted.
					if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
							Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
						break;
				}	
			}
		}
	}
}

function remotePrevWeapon(%client)
{
	if(GameBase::getDataName(%client.vehicle) == "Scout") {
		%vehicle = %client.vehicle;
		if(%vehicle.fireMode == Missiles) {
			%vehicle.fireMode = Chaingun;
			BottomPrint(%client, "Chaingun Mode - Bullets: "@ %vehicle.bullets); 
		}
		else {
			%vehicle.fireMode = Missiles;
			BottomPrint(%client, "Missile Mode - Missiles: "@ %vehicle.missiles); 
		}
	}
	else {
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (%item == -1 || $PrevWeapon[%item] == "")
			selectValidWeapon(%client);
		else {
			for (%weapon = $PrevWeapon[%item]; %weapon != %item;
					%weapon = $PrevWeapon[%weapon]) {
				if (isSelectableWeapon(%client,%weapon)) {
					Player::useItem(%client,%weapon);
					// Make sure it mounted (laser may not), or at least
					// next in line to be mounted.
					if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
							Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
						break;
				}
			}
		}
	}
}

function selectValidWeapon(%client)
{
	%item = EnergyRifle;
	for (%weapon = $NextWeapon[%item]; %weapon != %item;
			%weapon = $NextWeapon[%weapon]) {
		if (isSelectableWeapon(%client,%weapon)) {
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if (Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
	}
	return false;
}

//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------


function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]) {		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack) {
			// Only one backpack per armor, and it's always mounted
			if (Player::getMountedItem(%player,$BackpackSlot) == -1) {
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
		 		return 1;
			}
		}
//
//---------------------------
		else if (%item.className == Sensor) {
			if (Player::getMountedItem(%player,$SensorSlot) == -1) {
		 		Player::incItemCount(%player,%item);
				if(%item == "Beacon" && Player::getMountedItem(%player,$SensorSlot) == -1)
					Player::useItem(%client,%item);
				else if(%item != "Beacon")
					Player::useItem(%client,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " ");
		 		return 1;
			}
		}
//---------------------------
//

//
//---------------------------
		else if (%item.className == HandAmmo) {
			if (Player::getMountedItem(%player,$MineSlot) == -1 || Player::getMountedItem(%player,$MineSlot) == %item) {
				if(Player::getItemCount(%player, %item) >= $ItemMax[%armor, %item]) {
					return 0;
					}
				if(Player::getMountedItem(%player,$BackpackSlot) == "MinelayerPack" && %item != "MineAmmo") {
//					Client::sendMessage(%client,0,"Can only use mines while wearing a Minelayer Pack.");
					return 0;
					}
				if(Player::getMountedItem(%player,$BackpackSlot) == "DefenderPack" && %item != "MineAmmo") {
//					Client::sendMessage(%client,0,"Can only use mines while wearing a Defender Pack.");
					return 0;
					}
				if(Player::getMountedItem(%player,$BackpackSlot) == "AssaultPack" && %item != "Grenade") {
//					Client::sendMessage(%client,0,"Can only use frag grenades while wearing an Assault Pack.");
					return 0;
					}
		 		Player::incItemCount(%player,%item);
				if(Player::getMountedItem(%player,$MineSlot) == -1)
		 			Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " ");
		 		return 1;
			}
		}
//---------------------------
//

//
//---------------------------
		else if (%item.className == RepairKit) {
			if(Player::getItemClassCount(%player,"RepairKit") >= $ItemMax[%armor, %item]) 
				return 0;
			else {
		 		Player::incItemCount(%player,%item);
				if(Player::getMountedItem(%player, $RepairKitSlot) == -1)
 	 				Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " ");
	 			return 1;
			}
		}
//---------------------------
//
//
//---------------------------
		else if (%item.className == Marker) {
	 		Player::incItemCount(%player,%item);
 			Player::useItem(%player,%item);
	 		return 1;
		}
//---------------------------
//
  		else {
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			%extraAmmo = 0 ;
//
//---------------------------
			if (Player::getMountedItem(%client,$BackpackSlot) == "AssaultPack" && $AssaultPackMax[%item] != "") 
				%extraAmmo = $AssaultPackMax[%item];
			if (Player::getMountedItem(%client,$BackpackSlot) == "DefenderPack" && $DefenderPackMax[%item] != "") 
				%extraAmmo = $DefenderPackMax[%item];
			if (Player::getMountedItem(%client,$BackpackSlot) == "SniperPack" && $SniperPackMax[%item] != "") 
				%extraAmmo = $SniperPackMax[%item];
			if (Player::getMountedItem(%client,$BackpackSlot) == "MinelayerPack" && $MinelayerPackMax[%item] != "") 
				%extraAmmo = $MinelayerPackMax[%item];
//---------------------------
//
			// Make sure it doesn't exceed carrying capacity
			%count = Player::getItemCount(%player,%item);
			if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) 
				%delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
			if (%delta > 0) {
				Player::incItemCount(%player,%item,%delta);
				if (%count == 0 && $AutoUse[%item]) 
					Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
				return %delta;
			}
		}
   }
	return 0;
}

//----------------------------------------------------------------------------
// Default Item object methods


$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if (%sound != "")  
		playSound(%sound,GameBase::getPosition(%this));
	else {
		// Generic item sound
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
	// If the item is rotating we respawn it,
	if (Item::isRotating(%this)) {
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else { 
		deleteObject(%this);
	}
}	

function Item::onAdd(%this)
{
}

function Item::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)) && %item.className != "Marker") {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

//----------------------------------------------------------------------------
// Default Inventory methods
//----------------------------------------------------------------------------

function Item::onMount(%player,%item)
{
}

function Item::onUnmount(%player,%item)
{
}

function Item::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$DefaultSlot);
}

function Item::pop(%item)
{
 	GameBase::startFadeOut(%item);
   schedule("deleteObject(" @ %item @ ");",2.5, %item);
}

function Item::onDrop(%player,%item)
{
	if($matchStarted) {
		if(%item.className != Armor) {
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else {
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
}

//----------------------------------------------------------------------------
// Flags
//----------------------------------------------------------------------------


function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}


//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemData RaceFlag
{
	description = "Race Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------


ItemData LightArmor
{
   heading = "aArmor";
	description = "Light Armor";
	className = "Armor";
	price = 199;
};

ItemData MediumArmor
{
   heading = "aArmor";
	description = "Medium Armor";
	className = "Armor";
	price = 299;
};

ItemData HeavyArmor
{
   heading = "aArmor";
	description = "Heavy Armor";
	className = "Armor";
	price = 499;
};

ItemData SupportArmor
{
   heading = "aArmor";
	description = "Support Armor";
	className = "Armor";
	price = 499;
};

ItemData CommandArmor
{
   heading = "aArmor";
	description = "Command Armor";
	className = "Armor";
	price = 999;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
};

ItemData LAPCVehicle
{
	description = "LPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
};

//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------


ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
		Item::onDrop(%player,%item);
}	

function Weapon::onUse(%player,%item)
{
	if(%player.Station==""){
		%ammo = %item.imageType.ammoType;
		if (%ammo == "") {
			// Energy weapons dont have ammo types
			Player::mountItem(%player,%item,$WeaponSlot);
		}
		else {
			if (Player::getItemCount(%player,%ammo) > 0) 
				Player::mountItem(%player,%item,$WeaponSlot);
			else {
				Client::sendMessage(Player::getClient(%player),0,
				strcat(%item.description," has no ammo"));
			}
		}
	}
}


//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}



//----------------------------------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};

function Ammo::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta) { 
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0) {
			%obj = newObject("","Item",%item,%delta,false);
      	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			Item::playPickupSound(%obj);
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	

//----------------------------------------------------------------------------
// Weapons
//----------------------------------------------------------------------------

exec(Weapons);

//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

//-------------
exec(Packs);
//-------------

ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
}

//----------------------------------------------------------------------------
// Deployables
//----------------------------------------------------------------------------

exec(Deployables);

//----------------------------------------------------------------------------
// Deployable Methods
//----------------------------------------------------------------------------

function Item::deployShape(%player,%name,%shape,%item)
{
 	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])  {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}

	if (GameBase::getLOSInfo(%player,3) != true) {
		Client::sendMessage(%client,0,"Deploy position out of range");		
		return false;
	}

	%obj = getObjectType($los::object);
	if (%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape") {
		Client::sendMessage(%client,0,"Cannot deploy here");
		return false;
	}

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		return false;
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%sensor = newObject("","Sensor",%shape,true);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	GameBase::setPosition(%sensor,$los::position);
	Gamebase::setMapName(%sensor,%name);
	Client::sendMessage(%client,0,%item.description @ " deployed");
	playSound(SoundPickupBackpack,$los::position);
	echo("MSG: ",%client," deployed a ",%name);
	return true;
}

//----------------------------------------------------------------------------

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
//	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
//----------------------------
	%num=containerBoxFillSet(%set,$ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
//----------------------------
//
	if(!%num) {
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
		%obj = Group::getObject(%set,0);	
		if(Player::getClient(%obj) == %client)	
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;	
		

}



//----------------------------------------------------------------------------
// Miscellany
//----------------------------------------------------------------------------

exec(Misc);

//----------------------------------------------------------------------------
//  Player Functions
//----------------------------------------------------------------------------


function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if (%numweapon > $MaxWeapons[%armor]) {
	   %weaponflag = %numweapon - $MaxWeapons[%armor];
	}
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "") {
			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum) {
				%numsell =  %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon) {
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0) {
		    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item);
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
			} 
		}
	}
}

function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);	
	if($TeamEnergy[%team] != "Infinite") {
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) {
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}	

function Mission::reinitData()
{
$TeamItemCount[0 @ ScoutVehicle] = 0;
$TeamItemCount[1 @ ScoutVehicle] = 0;
$TeamItemCount[2 @ ScoutVehicle] = 0;
$TeamItemCount[3 @ ScoutVehicle] = 0;
$TeamItemCount[4 @ ScoutVehicle] = 0;
$TeamItemCount[5 @ ScoutVehicle] = 0;
$TeamItemCount[6 @ ScoutVehicle] = 0;
$TeamItemCount[7 @ ScoutVehicle] = 0;

$TeamItemCount[0 @ LAPCVehicle] = 0;
$TeamItemCount[1 @ LAPCVehicle] = 0;
$TeamItemCount[2 @ LAPCVehicle] = 0;
$TeamItemCount[3 @ LAPCVehicle] = 0;
$TeamItemCount[4 @ LAPCVehicle] = 0;
$TeamItemCount[5 @ LAPCVehicle] = 0;
$TeamItemCount[6 @ LAPCVehicle] = 0;
$TeamItemCount[7 @ LAPCVehicle] = 0;

$TeamItemCount[0 @ HAPCVehicle] = 0;
$TeamItemCount[1 @ HAPCVehicle] = 0;
$TeamItemCount[2 @ HAPCVehicle] = 0;
$TeamItemCount[3 @ HAPCVehicle] = 0;
$TeamItemCount[4 @ HAPCVehicle] = 0;
$TeamItemCount[5 @ HAPCVehicle] = 0;
$TeamItemCount[6 @ HAPCVehicle] = 0;
$TeamItemCount[7 @ HAPCVehicle] = 0;

$TeamItemCount[0 @ "AssaultPack"] = 0;
$TeamItemCount[1 @ "AssaultPack"] = 0;
$TeamItemCount[2 @ "AssaultPack"] = 0;
$TeamItemCount[3 @ "AssaultPack"] = 0;
$TeamItemCount[4 @ "AssaultPack"] = 0;
$TeamItemCount[5 @ "AssaultPack"] = 0;
$TeamItemCount[6 @ "AssaultPack"] = 0;
$TeamItemCount[7 @ "AssaultPack"] = 0;

$TeamItemCount[0 @ "DefenderPack"] = 0;
$TeamItemCount[1 @ "DefenderPack"] = 0;
$TeamItemCount[2 @ "DefenderPack"] = 0;
$TeamItemCount[3 @ "DefenderPack"] = 0;
$TeamItemCount[4 @ "DefenderPack"] = 0;
$TeamItemCount[5 @ "DefenderPack"] = 0;
$TeamItemCount[6 @ "DefenderPack"] = 0;
$TeamItemCount[7 @ "DefenderPack"] = 0;

$TeamItemCount[0 @ "SniperPack"] = 0;
$TeamItemCount[1 @ "SniperPack"] = 0;
$TeamItemCount[2 @ "SniperPack"] = 0;
$TeamItemCount[3 @ "SniperPack"] = 0;
$TeamItemCount[4 @ "SniperPack"] = 0;
$TeamItemCount[5 @ "SniperPack"] = 0;
$TeamItemCount[6 @ "SniperPack"] = 0;
$TeamItemCount[7 @ "SniperPack"] = 0;

$TeamItemCount[0 @ "ScoutPack"] = 0;
$TeamItemCount[1 @ "ScoutPack"] = 0;
$TeamItemCount[2 @ "ScoutPack"] = 0;
$TeamItemCount[3 @ "ScoutPack"] = 0;
$TeamItemCount[4 @ "ScoutPack"] = 0;
$TeamItemCount[5 @ "ScoutPack"] = 0;
$TeamItemCount[6 @ "ScoutPack"] = 0;
$TeamItemCount[7 @ "ScoutPack"] = 0;

$TeamItemCount[0 @ "MinelayerPack"] = 0;
$TeamItemCount[1 @ "MinelayerPack"] = 0;
$TeamItemCount[2 @ "MinelayerPack"] = 0;
$TeamItemCount[3 @ "MinelayerPack"] = 0;
$TeamItemCount[4 @ "MinelayerPack"] = 0;
$TeamItemCount[5 @ "MinelayerPack"] = 0;
$TeamItemCount[6 @ "MinelayerPack"] = 0;
$TeamItemCount[7 @ "MinelayerPack"] = 0;

$TeamItemCount[0 @ "Beacon"] = 0;
$TeamItemCount[1 @ "Beacon"] = 0;
$TeamItemCount[2 @ "Beacon"] = 0;
$TeamItemCount[3 @ "Beacon"] = 0;
$TeamItemCount[4 @ "Beacon"] = 0;
$TeamItemCount[5 @ "Beacon"] = 0;
$TeamItemCount[6 @ "Beacon"] = 0;
$TeamItemCount[7 @ "Beacon"] = 0;

$TeamItemCount[0 @ "CameraPack"] = 0;
$TeamItemCount[1 @ "CameraPack"] = 0;
$TeamItemCount[2 @ "CameraPack"] = 0;
$TeamItemCount[3 @ "CameraPack"] = 0;
$TeamItemCount[4 @ "CameraPack"] = 0;
$TeamItemCount[5 @ "CameraPack"] = 0;
$TeamItemCount[6 @ "CameraPack"] = 0;
$TeamItemCount[7 @ "CameraPack"] = 0;

$TeamItemCount[0 @ "LargeDecoyTurretPack"] = 0;
$TeamItemCount[1 @ "LargeDecoyTurretPack"] = 0;
$TeamItemCount[2 @ "LargeDecoyTurretPack"] = 0;
$TeamItemCount[3 @ "LargeDecoyTurretPack"] = 0;
$TeamItemCount[4 @ "LargeDecoyTurretPack"] = 0;
$TeamItemCount[5 @ "LargeDecoyTurretPack"] = 0;
$TeamItemCount[6 @ "LargeDecoyTurretPack"] = 0;
$TeamItemCount[7 @ "LargeDecoyTurretPack"] = 0;

$TeamItemCount[0 @ "MediumDecoyTurretPack"] = 0;
$TeamItemCount[1 @ "MediumDecoyTurretPack"] = 0;
$TeamItemCount[2 @ "MediumDecoyTurretPack"] = 0;
$TeamItemCount[3 @ "MediumDecoyTurretPack"] = 0;
$TeamItemCount[4 @ "MediumDecoyTurretPack"] = 0;
$TeamItemCount[5 @ "MediumDecoyTurretPack"] = 0;
$TeamItemCount[6 @ "MediumDecoyTurretPack"] = 0;
$TeamItemCount[7 @ "MediumDecoyTurretPack"] = 0;

$TeamItemCount[0 @ "SmallDecoyTurretPack"] = 0;
$TeamItemCount[1 @ "SmallDecoyTurretPack"] = 0;
$TeamItemCount[2 @ "SmallDecoyTurretPack"] = 0;
$TeamItemCount[3 @ "SmallDecoyTurretPack"] = 0;
$TeamItemCount[4 @ "SmallDecoyTurretPack"] = 0;
$TeamItemCount[5 @ "SmallDecoyTurretPack"] = 0;
$TeamItemCount[6 @ "SmallDecoyTurretPack"] = 0;
$TeamItemCount[7 @ "SmallDecoyTurretPack"] = 0;
	
$TeamItemCount[0 @ "DeployableInvPack"] = 0;
$TeamItemCount[1 @ "DeployableInvPack"] = 0;
$TeamItemCount[2 @ "DeployableInvPack"] = 0;
$TeamItemCount[3 @ "DeployableInvPack"] = 0;
$TeamItemCount[4 @ "DeployableInvPack"] = 0;
$TeamItemCount[5 @ "DeployableInvPack"] = 0;
$TeamItemCount[6 @ "DeployableInvPack"] = 0;
$TeamItemCount[7 @ "DeployableInvPack"] = 0;

$TeamItemCount[0 @ "DeployableSensorJammerPack"] = 0;
$TeamItemCount[1 @ "DeployableSensorJammerPack"] = 0;
$TeamItemCount[2 @ "DeployableSensorJammerPack"] = 0;
$TeamItemCount[3 @ "DeployableSensorJammerPack"] = 0;
$TeamItemCount[4 @ "DeployableSensorJammerPack"] = 0;
$TeamItemCount[5 @ "DeployableSensorJammerPack"] = 0;
$TeamItemCount[6 @ "DeployableSensorJammerPack"] = 0;
$TeamItemCount[7 @ "DeployableSensorJammerPack"] = 0;

$TeamItemCount[0 @ "MotionSensorPack"] = 0;
$TeamItemCount[1 @ "MotionSensorPack"] = 0;
$TeamItemCount[2 @ "MotionSensorPack"] = 0;
$TeamItemCount[3 @ "MotionSensorPack"] = 0;
$TeamItemCount[4 @ "MotionSensorPack"] = 0;
$TeamItemCount[5 @ "MotionSensorPack"] = 0;
$TeamItemCount[6 @ "MotionSensorPack"] = 0;
$TeamItemCount[7 @ "MotionSensorPack"] = 0;

$TeamItemCount[0 @ "PulseSensorPack"] = 0;
$TeamItemCount[1 @ "PulseSensorPack"] = 0;
$TeamItemCount[2 @ "PulseSensorPack"] = 0;
$TeamItemCount[3 @ "PulseSensorPack"] = 0;
$TeamItemCount[4 @ "PulseSensorPack"] = 0;
$TeamItemCount[5 @ "PulseSensorPack"] = 0;
$TeamItemCount[6 @ "PulseSensorPack"] = 0;
$TeamItemCount[7 @ "PulseSensorPack"] = 0;

$TeamItemCount[0 @ "BarrierPack"] = 0;
$TeamItemCount[1 @ "BarrierPack"] = 0;
$TeamItemCount[2 @ "BarrierPack"] = 0;
$TeamItemCount[3 @ "BarrierPack"] = 0;
$TeamItemCount[4 @ "BarrierPack"] = 0;
$TeamItemCount[5 @ "BarrierPack"] = 0;
$TeamItemCount[6 @ "BarrierPack"] = 0;
$TeamItemCount[7 @ "BarrierPack"] = 0;

$TeamItemCount[0 @ "SuspendedPlatform"] = 0;
$TeamItemCount[1 @ "SuspendedPlatform"] = 0;
$TeamItemCount[2 @ "SuspendedPlatform"] = 0;
$TeamItemCount[3 @ "SuspendedPlatform"] = 0;
$TeamItemCount[4 @ "SuspendedPlatform"] = 0;
$TeamItemCount[5 @ "SuspendedPlatform"] = 0;
$TeamItemCount[6 @ "SuspendedPlatform"] = 0;
$TeamItemCount[7 @ "SuspendedPlatform"] = 0;
		
$TeamItemCount[0 @ "AutoPlasmaTurretPack"] = 0;
$TeamItemCount[1 @ "AutoPlasmaTurretPack"] = 0;
$TeamItemCount[2 @ "AutoPlasmaTurretPack"] = 0;
$TeamItemCount[3 @ "AutoPlasmaTurretPack"] = 0;
$TeamItemCount[4 @ "AutoPlasmaTurretPack"] = 0;
$TeamItemCount[5 @ "AutoPlasmaTurretPack"] = 0;
$TeamItemCount[6 @ "AutoPlasmaTurretPack"] = 0;
$TeamItemCount[7 @ "AutoPlasmaTurretPack"] = 0;
		
$TeamItemCount[0 @ "BlasterTurretPack"] = 0;
$TeamItemCount[1 @ "BlasterTurretPack"] = 0;
$TeamItemCount[2 @ "BlasterTurretPack"] = 0;
$TeamItemCount[3 @ "BlasterTurretPack"] = 0;
$TeamItemCount[4 @ "BlasterTurretPack"] = 0;
$TeamItemCount[5 @ "BlasterTurretPack"] = 0;
$TeamItemCount[6 @ "BlasterTurretPack"] = 0;
$TeamItemCount[7 @ "BlasterTurretPack"] = 0;
		
$TeamItemCount[0 @ "ChaingunTurretPack"] = 0;
$TeamItemCount[1 @ "ChaingunTurretPack"] = 0;
$TeamItemCount[2 @ "ChaingunTurretPack"] = 0;
$TeamItemCount[3 @ "ChaingunTurretPack"] = 0;
$TeamItemCount[4 @ "ChaingunTurretPack"] = 0;
$TeamItemCount[5 @ "ChaingunTurretPack"] = 0;
$TeamItemCount[6 @ "ChaingunTurretPack"] = 0;
$TeamItemCount[7 @ "ChaingunTurretPack"] = 0;
		
$TeamItemCount[0 @ "DiscTurretPack"] = 0;
$TeamItemCount[1 @ "DiscTurretPack"] = 0;
$TeamItemCount[2 @ "DiscTurretPack"] = 0;
$TeamItemCount[3 @ "DiscTurretPack"] = 0;
$TeamItemCount[4 @ "DiscTurretPack"] = 0;
$TeamItemCount[5 @ "DiscTurretPack"] = 0;
$TeamItemCount[6 @ "DiscTurretPack"] = 0;
$TeamItemCount[7 @ "DiscTurretPack"] = 0;
		
$TeamItemCount[0 @ "FusionTurretPack"] = 0;
$TeamItemCount[1 @ "FusionTurretPack"] = 0;
$TeamItemCount[2 @ "FusionTurretPack"] = 0;
$TeamItemCount[3 @ "FusionTurretPack"] = 0;
$TeamItemCount[4 @ "FusionTurretPack"] = 0;
$TeamItemCount[5 @ "FusionTurretPack"] = 0;
$TeamItemCount[6 @ "FusionTurretPack"] = 0;
$TeamItemCount[7 @ "FusionTurretPack"] = 0;
		
$TeamItemCount[0 @ "GrenadeTurretPack"] = 0;
$TeamItemCount[1 @ "GrenadeTurretPack"] = 0;
$TeamItemCount[2 @ "GrenadeTurretPack"] = 0;
$TeamItemCount[3 @ "GrenadeTurretPack"] = 0;
$TeamItemCount[4 @ "GrenadeTurretPack"] = 0;
$TeamItemCount[5 @ "GrenadeTurretPack"] = 0;
$TeamItemCount[6 @ "GrenadeTurretPack"] = 0;
$TeamItemCount[7 @ "GrenadeTurretPack"] = 0;
		
$TeamItemCount[0 @ "LaserTurretPack"] = 0;
$TeamItemCount[1 @ "LaserTurretPack"] = 0;
$TeamItemCount[2 @ "LaserTurretPack"] = 0;
$TeamItemCount[3 @ "LaserTurretPack"] = 0;
$TeamItemCount[4 @ "LaserTurretPack"] = 0;
$TeamItemCount[5 @ "LaserTurretPack"] = 0;
$TeamItemCount[6 @ "LaserTurretPack"] = 0;
$TeamItemCount[7 @ "LaserTurretPack"] = 0;
	
$TeamItemCount[0 @ "RepulsorPack"] = 0;
$TeamItemCount[1 @ "RepulsorPack"] = 0;
$TeamItemCount[2 @ "RepulsorPack"] = 0;
$TeamItemCount[3 @ "RepulsorPack"] = 0;
$TeamItemCount[4 @ "RepulsorPack"] = 0;
$TeamItemCount[5 @ "RepulsorPack"] = 0;
$TeamItemCount[6 @ "RepulsorPack"] = 0;
$TeamItemCount[7 @ "RepulsorPack"] = 0;

$TeamItemCount[0 @ "EnergyVortexPack"] = 0;
$TeamItemCount[1 @ "EnergyVortexPack"] = 0;
$TeamItemCount[2 @ "EnergyVortexPack"] = 0;
$TeamItemCount[3 @ "EnergyVortexPack"] = 0;
$TeamItemCount[4 @ "EnergyVortexPack"] = 0;
$TeamItemCount[5 @ "EnergyVortexPack"] = 0;
$TeamItemCount[6 @ "EnergyVortexPack"] = 0;
$TeamItemCount[7 @ "EnergyVortexPack"] = 0;

$TeamItemCount[0 @ "EnergyFieldGeneratorPack"] = 0;
$TeamItemCount[1 @ "EnergyFieldGeneratorPack"] = 0;
$TeamItemCount[2 @ "EnergyFieldGeneratorPack"] = 0;
$TeamItemCount[3 @ "EnergyFieldGeneratorPack"] = 0;
$TeamItemCount[4 @ "EnergyFieldGeneratorPack"] = 0;
$TeamItemCount[5 @ "EnergyFieldGeneratorPack"] = 0;
$TeamItemCount[6 @ "EnergyFieldGeneratorPack"] = 0;
$TeamItemCount[7 @ "EnergyFieldGeneratorPack"] = 0;

$TeamItemCount[0 @ "StackableCrate"] = 0;
$TeamItemCount[1 @ "StackableCrate"] = 0;
$TeamItemCount[2 @ "StackableCrate"] = 0;
$TeamItemCount[3 @ "StackableCrate"] = 0;
$TeamItemCount[4 @ "StackableCrate"] = 0;
$TeamItemCount[5 @ "StackableCrate"] = 0;
$TeamItemCount[6 @ "StackableCrate"] = 0;
$TeamItemCount[7 @ "StackableCrate"] = 0;

$TeamItemCount[0 @ "LightArmor"] = 0;
$TeamItemCount[1 @ "LightArmor"] = 0;
$TeamItemCount[2 @ "LightArmor"] = 0;
$TeamItemCount[3 @ "LightArmor"] = 0;
$TeamItemCount[4 @ "LightArmor"] = 0;
$TeamItemCount[5 @ "LightArmor"] = 0;
$TeamItemCount[6 @ "LightArmor"] = 0;
$TeamItemCount[7 @ "LightArmor"] = 0;

$TeamItemCount[0 @ "MediumArmor"] = 0;
$TeamItemCount[1 @ "MediumArmor"] = 0;
$TeamItemCount[2 @ "MediumArmor"] = 0;
$TeamItemCount[3 @ "MediumArmor"] = 0;
$TeamItemCount[4 @ "MediumArmor"] = 0;
$TeamItemCount[5 @ "MediumArmor"] = 0;
$TeamItemCount[6 @ "MediumArmor"] = 0;
$TeamItemCount[7 @ "MediumArmor"] = 0;

$TeamItemCount[0 @ "HeavyArmor"] = 0;
$TeamItemCount[1 @ "HeavyArmor"] = 0;
$TeamItemCount[2 @ "HeavyArmor"] = 0;
$TeamItemCount[3 @ "HeavyArmor"] = 0;
$TeamItemCount[4 @ "HeavyArmor"] = 0;
$TeamItemCount[5 @ "HeavyArmor"] = 0;
$TeamItemCount[6 @ "HeavyArmor"] = 0;
$TeamItemCount[7 @ "HeavyArmor"] = 0;

$TeamItemCount[0 @ "CommandArmor"] = 0;
$TeamItemCount[1 @ "CommandArmor"] = 0;
$TeamItemCount[2 @ "CommandArmor"] = 0;
$TeamItemCount[3 @ "CommandArmor"] = 0;
$TeamItemCount[4 @ "CommandArmor"] = 0;
$TeamItemCount[5 @ "CommandArmor"] = 0;
$TeamItemCount[6 @ "CommandArmor"] = 0;
$TeamItemCount[7 @ "CommandArmor"] = 0;

$TeamItemCount[0 @ "SupportArmor"] = 0;
$TeamItemCount[1 @ "SupportArmor"] = 0;
$TeamItemCount[2 @ "SupportArmor"] = 0;
$TeamItemCount[3 @ "SupportArmor"] = 0;
$TeamItemCount[4 @ "SupportArmor"] = 0;
$TeamItemCount[5 @ "SupportArmor"] = 0;
$TeamItemCount[6 @ "SupportArmor"] = 0;
$TeamItemCount[7 @ "SupportArmor"] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

