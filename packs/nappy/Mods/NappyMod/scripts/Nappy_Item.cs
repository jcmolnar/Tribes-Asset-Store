function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	// IF - Cost positive selling    IF - Cost Negitive buying 
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 
	if((%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) && !$Nappy::BigStationEnergyDeployableStation) {
		%station.Energy += %cost;			//Remote StationEnergy
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite") { 
		$TeamEnergy[%team] += %cost;    //Total TeamEnergy
 		%client.teamEnergy += %cost;   //Personal TeamEnergy
	}
}


function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	if(Nappy::remoteCheck(%client, "BuyFavorites", 1))
		return;
	if (isPlayerBusy(%client))
		return;
	// only can buy fav every 1/2 second
	%time = getIntegerTime(true) >> 4; // int half seconds
	if(%time <= %client.lastBuyFavTime)
	      return;
	%client.lastBuyFavTime = %time;
	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" || %client.usingBuilderStation) {
		if(%client.usingBuilderStation){
			%energy = 999999999;
		}
		else{
			%stationName = GameBase::getDataName(%station); 
			if((%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) && !$Nappy::BigStationEnergyDeployableStation) //{
				%energy = %station.Energy;
			else 
				%energy = $TeamEnergy[Client::getTeam(%client)];
		}
		if(%energy == "Infinite" || %energy > 0) {
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for(%i = 0; %i < %max; %i = %i + 1) { 
				%item = getItemData(%i);
				if($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) {
					%count = Player::getItemCount(%client,%item);
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			for(%i = 0; %i < 20; %i++) { 
				if(%favItem[%i] != "") {
					%item = getItemData(%favItem[%i]);
					if(%item.className == Armor){
						if(!buyItem(%client,%item))  
							%error = 1;
						else{
							%bought++;
						}
					}
				}
		  	}
			if(%bought){
				%player = Client::getOwnedObject(%client);
				if(%client.usingBuilderStation){
					%list = "InvList";
				}
				else{
					%stationName = GameBase::getDataName(%player.Station);
					if(%stationName == "BaseStation" || %stationName == "InventoryStation")
						%list = "InvList";
					else if(%stationName == "DeployableInvStation")
						%list = "RemoteInvList";
				}
				setupShoppingList(%client,%player.Station,%list);
				
			}
			%error = 0;
			%bought = 0;
			for(%i = 0; %i < 20; %i++) { 
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

function remoteBuyItem(%client,%type)
{
	if(Nappy::remoteCheck(%client, "BuyItem", 1, %type))
		return;
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



function armorChange(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != "" && !$BuilderMode) {
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



function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") {
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	if (Player::getMountedItem(%client,$BackpackSlot) == GasPack && %item == "FlamerAmmo") { 
		%extraAmmo = 400; 
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo; 
	}
	if($TestCheats == 0 && %client.spawn == "") {
		%energy = $TeamEnergy[%team];
    	%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if((%sName == DeployableInvStation || %sName == DeployableAmmoStation) && !$Nappy::BigStationEnergyDeployableStation){
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
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
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





function remoteNextWeapon(%client)
{
	if(Nappy::remoteCheck(%client, "NextWeapon", 1))
		return;
	//if($ClientRepairing[%client])
	//	return;
	if($Client[%client, Nappy:stopLag] == 0){
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if(%item == -1 || $NextWeapon[%item] == "")
			selectValidWeapon(%client);
		else{
			for(%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) {
				if(isSelectableWeapon(%client,%weapon)) {
					Player::useItem(%client,%weapon);
					// Make sure it mounted (laser may not), or at least
					// next in line to be mounted.
					if(Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
						break;
				}
			}
		}
	}
}




function remotePrevWeapon(%client)
{
	if(Nappy::remoteCheck(%client, "PrevWeapon", 1))
		return;
	//if($ClientRepairing[%client])
	//	return;
	if($Client[%client, Nappy:stopLag] == 0){
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (%item == -1 || $PrevWeapon[%item] == "")
			selectValidWeapon(%client);
		else {
			for(%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon]){
				if(isSelectableWeapon(%client,%weapon)){
					Player::useItem(%client,%weapon);
					// Make sure it mounted (laser may not), or at least
					// next in line to be mounted.
					if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
						break;
				}
			}
		}
	}
}



function remoteUseItem(%client,%type)
{
	%item = getItemData(%type);
	%cl = Player::getClient(%client);
	if(Nappy::remoteCheck(%cl, "UseItem", 1, %item @ " | " @ %type))
		return;
	//echo("Use item: " @ %type @ " " @ %item);
	%client.throwStrength = 1;

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
	if(%client.stationOn)
		%lv = 1;
	else
		%lv = 4;
	if(Nappy::remoteCheck(%client, "ThrowItem", %lv, %type @ " | STRENGTH: " @ %strength))
		return;
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
		//if(GameBase::getControlClient(%player) != -1) {
	  		//echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo) {
				if (%strength < 0)
					%strength = 0;
				else
					if (%strength > 100)
						%strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%item);
			}
		}
	}
}



function Item::onDrop(%player,%item)
{
	if($matchStarted) {
		if(%item.className != Armor) {
			//echo("Item dropped: ",%player," ",%item);
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






function remoteSellItem(%client,%type)
{
	if(Nappy::remoteCheck(%client, "SellItem", 1, %type))
		return;
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
			else if (%item == ammopack || %item == GasPack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == EnergyPack) { 
				if(Player::getItemCount(%client,"LaserRifle") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					remoteSellItem(%client,22);						
				}
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}






function remoteDropItem(%client,%type)
{
	if(%client.stationOn)
		%lv = 1;
	else
		%lv = 4;
	if(Nappy::remoteCheck(%client, "DropItem", %lv, %type))
		return;
	if((Client::getOwnedObject(%client)).driver != 1) {
		//echo("Drop item: ",%type);
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
	if(Nappy::remoteCheck(%client, "DeployItem", 1, %type))
		return;
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}







function checkDeployArea(%client,%pos)
{
	if($Nappy::NoObjectInTheWay)
		return 1;
	else{ 
	 	%set=newObject("set",SimSet);
		%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
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
}


function checkDeployAreaForPlayers(%client,%pos)
{
 	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$SimPlayerObjectType,%pos,2,2,2,1);
	if(%num){
		if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
			%obj = Group::getObject(%set,0);	
			if(Player::getClient(%obj) == %client){	
				deleteObject(%set);
				return 1;
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
		}
		else if(%num > 1)
			Client::sendMessage(%client,0,"Unable to deploy - Players in the way");
	deleteObject(%set);
	return 0;
	}
	else{
		deleteObject(%set);
		return 1;
	}
}






function Nappy::DeployCheck::PlayerInStation(%client, %pos, %player)
{
	%deployingPlayer = Client::getOwnedObject(%client);
 	%su = newObject("stationUsers",SimSet);
	%num = containerBoxFillSet(%su,$SimPlayerObjectType,%pos,6,6,6,1);
	%count = 0;
	for(%i = 0;%i < %num;%i++) {
		%obj = Group::getObject(%su,%i);
		if(%obj.Station && GameBase::getTeam(%obj) == GameBase::getTeam(%deployingPlayer)) 
			%count++;
	}
	if(%count){
		Client::sendMessage(%client,0,"Unable to deploy - To close to player in station");
		deleteObject(%su);
		return 0;
	}
	else{
		deleteObject(%su);
		return 1;
	}
}



function Nappy::DeployCheck::StationNotInTheWay(%client, %pos)
{
 	%set = newObject("stationCheck",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,%pos,1,1,1,1);

	for(%i = 0;%i < %num;%i++){
		%obj = Group::getObject(%set,%i);
		%objName = GameBase::getDataName(%obj);
		if(%objName == "InventoryStation" || %objName == "AmmoStation"){
			Client::sendMessage(%client,0,"Too close to a station to deploy satchel.");
			deleteObject(%set);
			return 0;
		}
	}
	deleteObject(%set);
	return 1;


}



function CountObjects(%set,%name,%num) 
{
	if(%num < 1000){
		if (!$Nappy::NoObjectInterference){
			%count = 0;
			for(%i=0;%i<%num;%i++) {
				%obj=Group::getObject(%set,%i);
				if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
					%count++;
			}
			return %count;
		}
		else{
			return 0;
		}
	}
}








