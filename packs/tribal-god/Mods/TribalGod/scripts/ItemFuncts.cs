$TG::ShoppingList = true;// Armor assigned InvList.
//
//==========================================================================================
//                                 Item Functions:
//==========================================================================================
function Item::onAdd(%this)
{}

function Item::onUnmount(%player, %item)
{}

function Item::onDeploy(%player, %item, %pos)
{}

function Item::onUse(%player, %item){
	Player::mountItem(%player, %item, $DefaultSlot);
}

function Item::pop(%item){
	GameBase::startFadeOut(%item);
	Schedule("deleteObject("@ %item @");", 2.5, %item);
}

function Item::onDrop(%player, %item){
	if($matchStarted){
		if(%item.className != Armor){
			%obj = newObject("", "Item", %item, 1, false);
			Schedule("Item::Pop("@ %obj @");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			if(Player::isDead(%player)) 
			{ GameBase::throw(%obj, %player, 10, true); }
			else
			{ GameBase::throw(%obj, %player, 15, false); Item::playPickupSound(%obj); }
			Player::decItemCount(%player,%item,1);
			return %obj;
		}
	}
}

function Item::giveItem(%player, %item, %delta){
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]){		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack){
			if(Player::getMountedItem(%player,$BackpackSlot) == -1){
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
		 		return 1;
			}
		}else{
			if (%item.className == Weapon){
				if(Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor])
				{ return 0; }
			}  
			%extraAmmo = 0 ;
			if(Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "")
			{ %extraAmmo = $AmmoPackMax[%item]; }
			%count = Player::getItemCount(%player,%item);
			if(%count + %delta > $ItemMax[%armor, %item] + %extraAmmo)
			{ %delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count; }
			if (%delta > 0){
				Player::incItemCount(%player,%item,%delta);
				if(%count == 0 && $AutoUse[%item])
				{ Player::useItem(%player, %item); }
				if(%delta > 1){ %pluralize = "s"; }else{ %pluralize = ""; }
				Client::sendMessage(%client, 0, "You received "@ %delta @" "@ %item.description @ %pluralize);
				return %delta;
			}
		}
	}
	return 0;
}

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if(%sound != "")
	{ playSound(%sound,GameBase::getPosition(%this)); }
	else
	{ playSound(SoundPickupItem,GameBase::getPosition(%this)); }
}

function Item::respawn(%this){
	if(Item::isRotating(%this)){
		Item::hide(%this,True);
		Schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else{ Schedule("deleteObject("@ %this @");", 0.01, %this); }
}

function Item::onCollision(%this,%object){
	if(getObjectType(%object) == "Player"){
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if(Item::giveItem(%object,%item,Item::getCount(%this)))
		{ Item::playPickupSound(%this); Item::respawn(%this); }
	}
}

function Item::onMount(%player,%item){
	%client = Player::getClient(%player);
	if(%item.classname == Weapon)
	{ return; }
	if(%client.Tutorial == 1 || %client.Tutorial == "")
	{ BottomPrint(Player::getClient(%player), "<jc><f0>Carrying: <f2>"@ %item.description @".", 4); }
	else if(%client.Tutorial == 2)
	{ XBottomPrint(%client, $MountMsg[%item], 5); }// Level 2 BottomPrint.
}
//==========================================================================================


function EmplacementPack::rotVector(%vec, %rot){
	%vec_x = getWord(%vec, 0);
	%vec_y = getWord(%vec, 1);
	%vec_z = getWord(%vec, 2);
	%basevec = %vec_x @"  "@ %vec_y @" 0";
	%basedis = Vector::getDistance("0 0 0", %basevec);
	%normvec = Vector::normalize(%basevec);
	%baserot = Vector::add(Vector::getRotation(%normvec), "1.571 0 0");
	%newrot = Vector::add(%baserot, %rot);
	%newvec = Vector::getFromRot(%newrot, %basedis, %vec_z);
	return %newvec;
}
function teamEnergyBuySell(%player,%cost)
{ %client = Player::getClient(%player); %team = Client::getTeam(%client); %station = %player.Station; %stationName = GameBase::getDataName(%station); if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation){ %station.Energy += %cost; if(%station.Energy < 1){ %station.Energy = 0; } }else if($TeamEnergy[%team] != "Infinite"){ $TeamEnergy[%team] += %cost; %client.teamEnergy += %cost; } }
function isPlayerBusy(%client)
{ %state = Player::getItemState(%client,$WeaponSlot); return %state == "Fire" || %state == "Reload"; }
function replenishTeamEnergy(%team)
{ $TeamEnergy[%team] += $incTeamEnergy; Schedule("replenishTeamEnergy("@ %team @");", $secTeamEnergy); }

function checkResources(%player, %item, %delta, %noMessage){
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
	if(Player::getMountedItem(%client, $BackpackSlot) == ammopack && $AmmoPackMax[%item] != ""){
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
		{ %delta = %delta + %extraAmmo; }
	}
	if($TestCheats == 0 && %client.spawn == ""){
		%energy = $TeamEnergy[%team];
    	%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation)
		{ %energy = %station.Energy; }
		
		if(%energy != "Infinite"){
			if(%item.price * %delta > %energy)	
			{ %delta = %energy / %item.price;  }
			if(%delta < 1 ){
				if(%noMessage == "")
				{ Client::sendMessage(%client, 0, "Couldn't buy "@ %item.description @" - "@ %energy @" Energy points left"); }
				return 0;
			}
		}
	}
	
	if(%item.className == Weapon){
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client, "Weapon");
		if(Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]){
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
	}
	else if(%item == RepairPatch){
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) 
		{ return 1; }
		return 0;
	}
	else if($TeamItemMax[%item] != "" && !$TestCheats){
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]){
			Client::sendMessage(%client, 0, "Deployable Item limit reached for "@ %item.description @"s");
			return 0;
		}
	}
	
	if(%item.className != Armor && %item.className != Vehicle){
		%count = Player::getItemCount(%client,%item);
		%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
		if(%delta + %count >= %max) 
		{ %delta = %max - %count; }
	}
	return %delta;
}

function buyItem(%client, %item)
{
	%station = (Client::getOwnedObject(%client)).Station;
	if(%station == "" && %item.heading != $InvHeading[BackPacks] && %item.classname != "Weapon"){
		if(%client.spawn == ""){
			if(!%client.isAdmin && ($missionName == "BloodBath" || $missionName == "No-Rail-No-Fog" || $missionName == "No-Rail" || $missionName == "Mono-Rail" || $missionName == "Desert_Of_Death")){
				MessageAll(0, Client::getName(%client) @" Is trying to cheat like a little bitch");
				return;
			}else{
				if(!%client.BuyEnabled && !%client.isAdmin){
					Client::sendMessage(%client, 0, "Nope Dont Think So Cheater");
					return;
				}
			}
		}
	}
	
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if(($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)){
		if(%item.className == Armor){ 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0){
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)){
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
     				Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				Player::setItemCount(%client, %item, 1);  
     				updateBuyingList(%client);
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	
					if($TG::ShoppingList)
						setupShoppingList(%client,%client.invo,%client.ListType);
					return 1;
				}
				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}else if (%item.className == Backpack){
			if($TeamItemMax[%item] != ""){						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client, $BackpackSlot);
			if(%pack != -1){
				if(%pack == ammopack){
					checkMax(%client, %armor);
				}
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			
			if(checkResources(%player,%item,1) || $testCheats) 
			{
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1){
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == ammopack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.className == Weapon){
			if(checkResources(%player,%item,1)){
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != ""){
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats){
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		}
	 	else if(%item.className == Vehicle){
		   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]){
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1){
					teamEnergyBuySell(%player, (%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2){
	 				return 1;
	 			}
			}
		}else{
			if($TeamItemMax[%item] != ""){						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
			 %delta = checkResources(%player, %item, $ItemMax[%armor, %item]);
			 if(%delta || $testCheats){
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
		
 	}
	return 0;
}

function armorChange(%client){
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != ""){
		%sPos = GameBase::getPosition(%player.Station);
		%pPos	= GameBase::getPosition(%client);

		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station), -1);
		GameBase::setPosition(%client, (getWord(%vec, 0) * 1) + getWord(%sPos, 0) @" "@ (getWord(%vec, 1) * 1) + getWord(%sPos, 1) @" "@ %posZ);
		
		for(%i=0; %i < 6.28; %i += 1.256){
			%trans = Vector::add(getBoxCenter(%player), Vector::getFromRot("0 0 "@ %i, 1.3, 1.2)); Projectile::spawnProjectile("ArmChangeFX", "0 0 1 0 0 0 0 0 1 "@ %trans, %player, "0 0 -2");
		}
	}
}

function remoteBuyItem(%client,%type){
	if(isPlayerBusy(%client)){
		return;
	}
	%item = getItemData(%type);
	if(buyItem(%client, %item)){
 		Client::sendMessage(%client, 0, "~wbuysellsound.wav");
		updateBuyingList(%client);
	}else{ Client::sendMessage(%client, 0, "You couldn't buy "@ %item.description @"~wC_BuySell.wav"); }
}

function remoteSellItem(%client,%type)
{
	if(isPlayerBusy(%client))
	{ return; }

	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client, %item) || $TestCheats)
	{
		if(Player::getItemCount(%client, %item) && %item.className != Armor)
		{
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo)
			{
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
				%numsell = %count; 
				else 
				%numsell = $SellAmmo[%item];
			}
			else if (%item == ammopack) 
			{ checkMax(%client,Player::getArmor(%client)); }
			else if($TeamItemMax[%item] != ""){
				if(%item.className == Vehicle){
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
				}
			}
			else if(%item == EnergyPack){ 
				if(Player::getItemCount(%client,"LaserRifle") > 0){
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					remoteSellItem(%client, 22);						
				}
			}
			teamEnergyBuySell(%player, %item.price * %numsell);
			Player::setItemCount(%player,%item,(%count - %numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client, 0, "~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client, 0, "Cannot sell item ~wC_BuySell.wav");
}

function remoteThrowItem(%client, %type, %strength){
	if(%client.isPossessed == true){
		return;
	}
	else if(%client.isPossessing == true){
		%newClient = %client.hasPossClient;
	}else{
		%newClient = %client;
	}
	
	%player = Client::getOwnedObject(%newClient);
	
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()){
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != ""){
			%item = getItemData(%type);
			if(%item == Grenade || %item == MineAmmo || %item == flashgrenade){
				if(%strength < 0)
				{ %strength = 0; }
				else if(%strength > 100)
				{ %strength = 100; }
				%newClient.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%newClient, %item);
			}
		}
	}
}
//---------------------------------------------------------------------------------------------
function remoteDropItem(%client,%type){
	if(%client.isPossessed == true){
		return;
	}
	if(%client.isPossessing == true){
		%newClient = %newClient.hasPossClient;
	}else{
		%newClient = %client;
	}
	
	if((Client::getOwnedObject(%newClient)).driver != 1){
		%newClient.throwStrength = 1;
		%item = getItemData(%type);
		if(%item == Backpack){
			%item = Player::getMountedItem(%newClient, $BackpackSlot);
			Player::dropItem(%newClient, %item);
		}else if (%item == Weapon){
			%item = Player::getMountedItem(%newClient, $WeaponSlot);
			Player::dropItem(%newClient, %item);
		}else if (%item == Ammo){
			%item = Player::getMountedItem(%newClient,$WeaponSlot);
			if(%item.className == Weapon){
				%item = %item.imageType.ammoType;
				Player::dropItem(%newClient,%item);
			}
		}else{ Player::dropItem(%newClient, %item); }
	}
}

function remoteDeployItem(%client, %type){
	%item = getItemData(%type);
	Player::deployItem(%client, %item);
}

//====BEGIN HIDE IFF FUNCTION====| - Doesnt work for some reason.
function Cloaker(%player)  
{
	%cl = Player::getclient(%player);
	%plTeam = GameBase::GetTeam(%player);
	%UserPos = gamebase::getPosition(%player);
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%TargetPlayer = Client::getOwnedObject(%clientId);
		if(GameBase::GetTeam(%clientId) != %plTeam)
		{
			%TargetPos = gamebase::getPosition(%TargetPlayer);
			%dist = Vector::getDistance(%UserPos, %TargetPos);
			%matrix = %clientId @ %player;
			if(%dist < 200 && %player.cloaked == 1) 
			{
				if($cloakEffected[%matrix] != 1)
				{
					Player::setDetectParameters(%Targetplayer, 90, 300);
					$TotalCloaks[%ClientId]++;
					$cloakEffected[%matrix] = 1;
				}
			}
			else
			{
				if($cloakEffected[%matrix] == 1)
				$TotalCloaks[%clientId]--;
				if($TotalCloaks[%clientId] < 1)
				{
					Player::setDetectParameters(%Targetplayer, 0.027, 0);
					$cloakEffected[%matrix] = 0;
				}
			}
		}
	}
	if(Player::isTriggered(%player, $BackPackSlot))// && Player::getMountedItem(%player, $BackPackSlot) == "Hollowman Device")) 
	schedule("Cloaker("@ %player @");", 0.5, %player);
}
//====END HIDE IFF FUNCTION====|

function checkMax(%client, %armor)
{
	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client, "Weapon");
	if (%numweapon > $MaxWeapons[%armor])
	{ %weaponflag = %numweapon - $MaxWeapons[%armor]; }
	
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1)
	{
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		
		if(%maxnum != "")
		{
			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum)
			{ %numsell =  %count - %maxnum; }
			
			if (%count > 0 && %weaponflag && %item.className == Weapon)
			{ %numsell = 1; %weaponflag = %weaponflag - 1; }
			
			if(%numsell > 0) 
			{
				Client::sendMessage(%client, 0, "SOLD "@ %numsell @" "@ %item);
				teamEnergyBuySell(Client::getOwnedObject(%client), (%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
			}
		}
	}
}
//--------------------------------------------------------------------------------------------------
function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);	
	if($TeamEnergy[%team] != "Infinite")
	{
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1))
		{
			if(%client.teamEnergy >= 0)
			{ %diff = $InitialPlayerEnergy; }
			else 
			{ %diff = $InitialPlayerEnergy + %client.teamEnergy; }
			$TeamEnergy[%team] -= %diff;
		}
	}
}