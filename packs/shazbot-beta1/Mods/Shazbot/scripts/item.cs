//----------------------------------------------------------------------------

$ItemFavoritesKey = "SHAZBOTBETA";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

$ItemPopTime = 70;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = True;



$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[GunnerVehicle] = 5;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;


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

// Weapon to ammo table
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";


//----------------------------------------------------------------------------
// Server side methods
// The client side inventory dialogs call buyItem, sellItem,
// useItem and dropItem through remoteEvals.

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
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") {
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
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

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if (%item.className == Armor) {
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
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	
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
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack) {
					if(Player::getItemCount(%client,"LaserRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						remoteSellItem(%client,22);						
					}
				}	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopack) 
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == ammopack) 
					fillAmmoPack(%client);
			}				 
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
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
			else if (%item == ammopack) 
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

function remoteUseItem(%client,%type)
{
	//echo("Use item: " @ %type @ " " @ %item);
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
		//if(GameBase::getControlClient(%player) != -1) {
	  		echo("Throw item: " @ %type @ " " @ %strength);
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

function remoteDropItem(%client,%type)
{
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

//Function took out of sex mod - thanks for the code man :)
$FirstWeapon = "";
$LastWeapon = "";
$Item = 0;
$weaponCount = 0;

function AddItem(%Item,%dontallow){
	//damn Dynamix for creating Functions within the .exe and not showing them to me...
	$Item += 1;
	$Itemlist[$Item] = %Item;
	if (!%dontallow) {
	$quickbanlistmax++;
	%item.ShowQuick = true;
	$quickbanlist[$quickbanlistmax] = %item;
	}
}

function remoteDeployItem(%client,%type)
{
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

function addWeapon(%weap)
{
additem(%weap);
additem($WeaponAmmo[%weap]);
$weaponCount += 1;
$weaponlist[$weaponCount] = %weap;


	if ($FirstWeapon == "")
		$FirstWeapon = %weap;
	if ($LastWeapon == "") 
		$LastWeapon = %weap;

	$PrevWeapon[%weap] = $LastWeapon;
	$NextWeapon[%weap] = $FirstWeapon;
	$PrevWeapon[$FirstWeapon] = %weap;
	$NextWeapon[$LastWeapon] = %weap;

	$LastWeapon = %weap;
}


function remoteNextWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
		selectValidWeapon(%client);
	else {
		for (%weapon = $NextWeapon[%item]; %weapon != %item;
				%weapon = $NextWeapon[%weapon]) {
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

function remotePrevWeapon(%client)
{
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
  		else {
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
				%extraAmmo = $AmmoPackMax[%item];
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
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}


//----------------------------------------------------------------------------
// Default Inventory methods

function Item::onMount(%player,%item)
{
}

function Item::onUnmount(%player,%item)
{
}

function Item::onUse(%player,%item)
{
	//echo("Item used: ",%player," ",%item);
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
   validateShape = true;

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
	price = 175;
};

ItemData MediumArmor
{
   heading = "aArmor";
	description = "Medium Armor";
	className = "Armor";
	price = 250;
};

ItemData HeavyArmor
{
   heading = "aArmor";
	description = "Heavy Armor";
	className = "Armor";
	price = 400;
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

ItemData GunnerVehicle
{
	description = "Gun Ship";
	className = "Vehicle";
   heading = "aVehicle";
	price = 250;
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

ItemImageData BlasterImage
{
   shapeFile  = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bWeapons";
	description = "Hyper Blaster";
	className = "Weapon";
   shapeFile  = "plasma";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

function Blaster::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Hyper Blaster]:<f1> Sends bolts of red enegry at someone you love.", 2);
}

addWeapon(Blaster);

//--------------------------------------------shock rifle
$ItemMax[larmor, ShockRfile] = 1; 
$ItemMax[lfemale, ShockRfile] = 1; 
$ItemMax[marmor, ShockRfile] = 1; 
$ItemMax[mfemale, ShockRfile] = 1; 
$ItemMax[harmor, ShockRfile] = 1; 

$InvList[ShockRfile] = 1; 
$RemoteInvList[ShockRfile] = 1; 

 
$AutoUse[ShockRfile] = true;

$WeaponAmmo[ShockRfile] = ""; 

ItemImageData ShockRfileImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0; 
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	accuFire = true;
	reloadTime = 0.7;
	fireTime = 0.3;
	minEnergy = 0.06;
	maxEnergy = 0.06;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 0, 5.2 };	

	sfxFire     = SoundSpinUpDisc;
	
	sfxSpinUp = SoundSpinUpDisc;
	sfxReady    = SoundmortarIdle;
};

ItemData ShockRfile
{
	description = "Shock Rifle";
	className = weapon;
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ShockRfileImage;
	price = 125;
	showWeaponBar = true;
};

function ShockRfile::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Shock Rifle]:<f1> CoBlasterBoltine Blaster and laser techonlgy this little diddy is not to be messed with", 2);
}

function ShockRfileImage::onFire(%player, %slot)
{
	%oldenergy = Gamebase::getEnergy(%player);
	%oldenergy -= 5.0;
	Gamebase::setEnergy(%player, %oldenergy);
	projectile::spawnprojectile("ShockLaser",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("ShockRocket",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
}
addWeapon(ShockRfile); 

//----Rail Gun-------------------------------------------------------------
$ItemMax[larmor, RailX] = 1; 
$ItemMax[lfemale, RailX] = 1; 
$ItemMax[marmor, RailX] = 1; 
$ItemMax[mfemale, RailX] = 1; 
$ItemMax[harmor, RailX] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, RailXAmmo] = 50; 
$ItemMax[lfemale, RailXAmmo] = 50; 
$ItemMax[marmor, RailXAmmo] = 80; 
$ItemMax[mfemale, RailXAmmo] = 80; 
$ItemMax[harmor, RailXAmmo] = 100; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[RailX] = 1; 
$RemoteInvList[RailX] = 1; 
$InvList[RailXAmmo] = 1; 
$RemoteInvList[RailXAmmo] = 1; 
 
$AutoUse[RailX] = true; 
$SellAmmo[RailX] = 50; 
$AmmoPackMax[RailX] = 200; 
$WeaponAmmo[RailX] = RailXAmmo; 
 
//-=-=-=-= 
 
ItemData RailXAmmo 
{ 
	description = "Railgunammo"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 100; 
}; 

ItemImageData RailX2Image
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0.20, 3.14, 0 };
	weaponType = 0;
	//projectileType = RailXRocket;
	accuFire = true;
};

ItemData RailX2
{
	description = "Railgun";
	shapeFile = "energygun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RailX2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
}; 

function RailX2::onMount(%player,%item,$WeaponSlot)
{
 %client = Player::getclient(%player);
      Bottomprint(%client, "<jc><f2>[Rail Gun]:<f1> The Ulimate In sniper Technology", 5);
}
 

ItemImageData RailXImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	//projectileType = RailXRocket; 
	ammotype = RailXAmmo; 
	aimDeflection = 0.0; 
	accuFire = True; 
	reloadTime = 1.5; 
	fireTime = 1.2; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickupWeapon; 
}; 

ItemData RailX 
{ 
	description = "RailGun"; 
	className = weapon; 
	shapefile = "sniper"; 
	hudIcon = "sniper"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = RailXImage; 
	price = 200; 
	showWeaponBar = True; 
};




function RailX::onMount(%player,%imageSlot)
{
 Player::mountItem(%player,RailX2,5); 
 
function RailXImage::onFire(%player,%slot)
 {

if($debug)
	echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

   %enVal  = 25.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RailX]);
   if (%energy > 20.0)
{
		 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
		 Player::decItemCount(%player,$WeaponAmmo[RailX],1);
		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("RailXRocket",%trans,%player,%vel);
	 }
	 else
	{
	 playSound(SoundElevatorStop,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"Your energy level is to low to fire a rail shot.");
	}
 } 
  
}
function RailX::onUnmount(%player,%imageSlot)
{
 Player::unmountItem(%player,5); 
 
}

addWeapon(RailX);
//-------Titty Gun :) -Jinzo ---------------
$ItemMax[larmor, Titty] = 1; 
$ItemMax[lfemale, Titty] = 1; 
$ItemMax[marmor, Titty] = 1; 
$ItemMax[mfemale, Titty] = 1; 
$ItemMax[harmor, Titty] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, TittyAmmo] = 50; 
$ItemMax[lfemale, TittyAmmo] = 50; 
$ItemMax[marmor, TittyAmmo] = 100; 
$ItemMax[mfemale, TittyAmmo] = 100; 
$ItemMax[harmor, TittyAmmo] = 150;  
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
 
$InvList[Titty] = 1; 
$RemoteInvList[Titty] = 1; 
$InvList[TittyrAmmo] = 1; 
$RemoteInvList[TittyAmmo] = 1; 
 
$AutoUse[Titty] = true; 
$SellAmmo[Titty] = 50; 
$AmmoPackMax[Titty] = 200; 
$WeaponAmmo[Titty] = TittyAmmo; 
 
//-=-=-=-= 
 
ItemData TittyAmmo
{
	description = "flying titties";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData TittyImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = TittyAmmo;
	projectileType = TittyRocket;
	accuFire = false;
	reloadTime = 0.01;
	fireTime = 0.7;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Titty
{
	description = "Titty gun";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
        heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TittyImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

function Titty::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Titty Gun]:<f1> Annoying and funny!", 2);
}

addWeapon(Titty);
//--------------------Flame Thrower--------------------------
$ItemMax[larmor, Flamer] = 1; 
$ItemMax[lfemale, Flamer] = 1; 
$ItemMax[marmor, Flamer] = 1; 
$ItemMax[mfemale, Flamer] = 1; 
$ItemMax[harmor, Flamer] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, FlamerAmmo] = 70; 
$ItemMax[lfemale, FlamerAmmo] = 70; 
$ItemMax[marmor, FlamerAmmo] = 80; 
$ItemMax[mfemale, FlamerAmmo] = 80; 
$ItemMax[harmor, FlamerAmmo] = 100; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[Flamer] = 1; 
$RemoteInvList[Flamer] = 1; 
$InvList[FlamerAmmo] = 1; 
$RemoteInvList[FlamerAmmo] = 1; 
 
$AutoUse[Flamer] = true; 
$SellAmmo[Flamer] = 50; 
$AmmoPackMax[Flamer] = 200; 
$WeaponAmmo[Flamer] = FlamerAmmo; 
 
//-=-=-=-= 
 
ItemData FlamerAmmo
{
	description = "Firball Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData FlamerImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FlamerAmmo;
	projectileType = FlamerShell;
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Flamer
{
	description = "Flamer Thrower";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

function Flamer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Flame Thrower]:<f1> Jinzo's Verison of the flame thrower.", 2);
}

addWeapon(Flamer);
//--.45 APC-----------------------------------------------------------------------
$ItemMax[larmor, Pistol] = 1; 
$ItemMax[lfemale, Pistol] = 1; 
$ItemMax[marmor, Pistol] = 1; 
$ItemMax[mfemale, Pistol] = 1; 

 
//-=-=-=-= 
 
$ItemMax[larmor, PistolAmmo] = 30; 
$ItemMax[lfemale, PistolAmmo] = 30; 
$ItemMax[marmor, PistolAmmo] = 40; 
$ItemMax[mfemale, PistolAmmo] = 40; 

 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[Pistol] = 1; 
$RemoteInvList[Pistol] = 1; 
$InvList[PistolAmmo] = 1; 
$RemoteInvList[PistolAmmo] = 1; 
 
$AutoUse[Pistol] = true; 
$SellAmmo[Pistol] = 10; 
$AmmoPackMax[Pistol] = 50; 
$WeaponAmmo[Pistol] = PistolAmmo; 
 
//-=-=-=-= 
 
ItemData PistolAmmo 
{ 
	description = ".45 APC bullet"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 3; 
}; 

 
ItemImageData PistolImage 
{ 
	shapeFile = "energygun"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = PistolBullet; 
	ammotype = PistolAmmo; 
	aimDeflection = 0.0; 
	accuFire = True; 
	reloadTime = 1.0; 
	fireTime = 0.75; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = bigExplosion2; 
	sfxActivate = SoundPickupWeapon; 
	sfxReload = SoundMortarReload;
	
}; 
 
ItemData Pistol 
{ 
	description = ".45 APC"; 
	className = weapon; 
	shapefile = "energygun"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = PistolImage; 
	price = 250; 
	showWeaponBar = True; 
}; 


addWeapon(Pistol);
//----------Sniper Rifle---------------------------------------------------------------
$ItemMax[larmor, Railgun] = 1; 
$ItemMax[lfemale, Railgun] = 1; 
$ItemMax[marmor, Railgun] = 1; 
$ItemMax[mfemale, Railgun] = 1; 
$ItemMax[harmor, Railgun] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, RailgunAmmo] = 50; 
$ItemMax[lfemale, RailgunAmmo] = 50; 
$ItemMax[marmor, RailgunAmmo] = 80; 
$ItemMax[mfemale, RailgunAmmo] = 80; 
$ItemMax[harmor, RailgunAmmo] = 100; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[Railgun] = 1; 
$RemoteInvList[Railgun] = 1; 
$InvList[RailgunAmmo] = 1; 
$RemoteInvList[RailgunAmmo] = 1; 
 
$AutoUse[Railgun] = true; 
$SellAmmo[Railgun] = 25; 
$AmmoPackMax[Railgun] = 200; 
$WeaponAmmo[Railgun] = RailgunAmmo; 
 
//-=-=-=-= 
 
ItemData RailgunAmmo 
{ 
	description = "Railgun Ammo"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 100; 
}; 
 
ItemImageData RailgunImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = RailgunBullet; 
	ammotype = RailgunAmmo; 
	aimDeflection = 0.0; 
	accuFire = True; 
	reloadTime = 1.3; 
	fireTime = 1.5; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = SoundMortarReload; 
	sfxActivate = SoundPickupWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 
 
ItemData Railgun 
{ 
	description = "Sniper Rifle"; 
	className = weapon; 
	shapefile = "sniper"; 
	hudIcon = "sniper"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = RailgunImage; 
	price = 100; 
	showWeaponBar = True; 
}; 

function Railgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Sniper Rifle]:<f1> This is the hardest of the sniper rifles to use", 2);
}

addWeapon(Railgun);
//-----Machinery kk245-------------------------------------------------------------------
$ItemMax[larmor, Mach1] = 1; 
$ItemMax[lfemale, Mach1] = 1; 
$ItemMax[marmor, Mach1] = 1; 
$ItemMax[mfemale, Mach1] = 1; 
$ItemMax[harmor, Mach1] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, Mach1Ammo] = 150; 
$ItemMax[lfemale, Mach1Ammo] = 150; 
$ItemMax[marmor, Mach1Ammo] = 170; 
$ItemMax[mfemale, Mach1Ammo] = 170; 
$ItemMax[harmor, Mach1Ammo] = 200; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[Mach1] = 1; 
$RemoteInvList[Mach1n] = 1; 
$InvList[Mach1Ammo] = 1; 
$RemoteInvList[Mach1Ammo] = 1; 
 
$AutoUse[Mach1] = true; 
$SellAmmo[Mach1] = 25; 
$AmmoPackMax[Mach1] = 200; 
$WeaponAmmo[Mach1] = Mach1Ammo; 
 
//-=-=-=-= 
 
ItemData Mach1Ammo 
{ 
	description = "kk345 Ammo"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 50; 
}; 
 
ItemImageData Mach1Image 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = Mach1Bullet; 
	ammotype = Mach1Ammo; 
	aimDeflection = 0.0; 
	accuFire = True; 
	reloadTime = 0.03; 
	fireTime = 0.05; 
	
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.15;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = bigExplosion4; 
	sfxActivate = SoundPickupWeapon; 
	sfxReload = SoundMortarReload;
	
}; 
 
ItemData Mach1 
{ 
	description = "Machinery kk345"; 
	className = weapon; 
	shapefile = "sniper"; 
	hudIcon = "sniper"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Mach1Image; 
	price = 120; 
	showWeaponBar = True; 
}; 

function Mach1::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Machinery kk345]:<f1> This is a idea for a weapon from SMuRF. ", 2);
}

addWeapon(Mach1);
///--------------Shotgun------------------------------------------------------------
$ItemMax[larmor, Shotgun] = 1; 
$ItemMax[lfemale, Shotgun] = 1; 
$ItemMax[marmor, Shotgun] = 1; 
$ItemMax[mfemale, Shotgun] = 1; 
$ItemMax[harmor, Shotgun] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, ShotgunAmmo] = 25; 
$ItemMax[lfemale, ShotgunAmmo] = 25; 
$ItemMax[marmor, ShotgunAmmo] = 30; 
$ItemMax[mfemale, ShotgunAmmo] = 30; 
$ItemMax[harmor, ShotgunAmmo] = 50; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[Shotgun] = 1; 
$RemoteInvList[Shotgun] = 1; 
$InvList[ShotgunAmmo] = 1; 
$RemoteInvList[ShotgunAmmo] = 1; 
 
$AutoUse[Shotgun] = true; 
$SellAmmo[Shotgun] = 25; 
$AmmoPackMax[Shotgun] = 200; 
$WeaponAmmo[Shotgun] = ShotgunAmmo; 
 
//-=-=-=-= 
 
ItemData ShotgunAmmo 
{ 
	description = "Buckshot"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 100; 
}; 
 
ItemImageData ShotgunImage 
{ 
	shapeFile = "shotgun"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	ammotype = ShotgunAmmo; 
	aimDeflection = 0.0; 
	accuFire = True; 
	reloadTime = 0.3; 
	fireTime = 0.5; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = bigExplosion4; 
	sfxActivate = SoundPickupWeapon; 
	sfxReload = SoundMortarReload;
	
}; 
 
ItemData Shotgun 
{ 
	description = "Shotgun"; 
	className = weapon; 
	shapefile = "shotgun"; 
	hudIcon = "blaster"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = ShotgunImage; 
	price = 200; 
	showWeaponBar = True; 
}; 

function Shotgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Shotgun]:<f1> Yer Scatter Gun.", 2);
}

function ShotgunImage::onFire(%player, %slot)
{   
   Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
   %trans = GameBase::getMuzzleTransform(%player);
   %vel = Item::getVelocity(%player);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
   
   
   
   
   //%client = GameBase::getOwnerClient(%player);
   //%armor = Player::getArmor(%client);
   //centerprintall("client " @ %client.maxForwardSpeed @ "  player " @ %player.maxForwardSpeed @ "  armor " @ %armor.maxForwardSpeed,10);
   //centerprintall("armor " @ %armor,10);
   //echo(%armor);
   //%armor.maxForwardSpeed = %armor.maxForwardSpeed + 5.0;
}


addWeapon(Shotgun);
//--------------Blastoid Rifle------------------------------------------------------------
$ItemMax[larmor, BRifle] = 1; 
$ItemMax[lfemale, BRifle] = 1; 
$ItemMax[marmor, BRifle] = 1; 
$ItemMax[mfemale, BRifle] = 1; 
$ItemMax[harmor, BRifle] = 1; 
 
//-=-=-=-= 


//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[BRifle] = 1; 
$RemoteInvList[BRifle] = 1; 

$AutoUse[BRifle] = true; 
 

$WeaponAmmo[BRifle] = ""; 
 
//-=-=-=-= 
 
 
ItemImageData BRifleImage 
{ 
	shapeFile = "sniper"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = BRifleRocket; 
	aimDeflection = 0.0; 
	accuFire = True; 
	reloadTime = 0.03; 
	fireTime = 0.3; 
	minEnergy = 0.5;
	maxEnergy = 1.0;
 
	lightType = 3; 
	lightRadius = 7; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 1, 0}; 
 
	sfxFire = SoundFirePlasma; 
	sfxActivate = SoundPickupWeapon; 
	sfxReady = SoundMortarIdle;
}; 
 
ItemData BRifle 
{ 
	description = "Blastoid Rifle"; 
	className = weapon; 
	shapefile = "sniper"; 
	hudIcon = "blaster"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = BRifleImage; 
	price = 200; 
	showWeaponBar = True; 
};

function BRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Blastoid Rifle]:<f1> A Weapon Developed By Jinzo for no danm reason at all", 2);
}

addWeapon(BRifle); 
//--------Missle Luncher--------------------------------------------------------------------------------------
$ItemMax[larmor, Missle] = 0; 
$ItemMax[lfemale, Missle] = 0; 
$ItemMax[marmor, Missle] = 0; 
$ItemMax[mfemale, Missle] = 0; 
$ItemMax[harmor, Missle] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, MissleAmmo] = 0; 
$ItemMax[lfemale, MissleAmmo] = 0; 
$ItemMax[marmor, MissleAmmo] = 0; 
$ItemMax[mfemale, MissleAmmo] = 0; 
$ItemMax[harmor, MissleAmmo] = 20; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[Missle] = 1; 
$RemoteInvList[Missle] = 1; 
$InvList[MissleAmmo] = 1; 
$RemoteInvList[MissleAmmo] = 1; 
 
$AutoUse[Missle] = true; 
$SellAmmo[Missle] = 50; 
$AmmoPackMax[Missle] = 25; 
$WeaponAmmo[Missle] = MissleAmmo; 
 
//-=-=-=-= 
 
ItemData MissleAmmo 
{ 
	description = "Missles"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 100; 
}; 
 
ItemImageData MissleImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = FlierRocket; 
	ammotype = MissleAmmo; 
	aimDeflection = 0.0; 
	accuFire = True; 
	reloadTime = 1.3; 
	fireTime = 0.3; 
 
	lightType = 3; 
	lightRadius = 7; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 1, 0}; 
 
	sfxFire = SoundFireFlierRocket; 
	sfxActivate = SoundPickupWeapon; 
	sfxReady = SoundMortarIdle;
}; 
 
ItemData Missle 
{ 
	description = "Missle Launcher"; 
	className = weapon; 
	shapefile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MissleImage; 
	price = 200; 
	showWeaponBar = True; 
};

function Missle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Missle Launcher]:<f1> this will give ya an eneama.", 2);
}

addWeapon(Missle); 
 
//-----Rocket chain Gun-----------------------------------------------------------------------
$ItemMax[larmor, Rocketgun] = 1; 
$ItemMax[lfemale, Rocketgun] = 1; 
$ItemMax[marmor, Rocketgun] = 1; 
$ItemMax[mfemale, Rocketgun] = 1; 
$ItemMax[harmor, Rocketgun] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, RocketgunAmmo] = 100; 
$ItemMax[lfemale, RocketgunAmmo] = 100; 
$ItemMax[marmor, RocketgunAmmo] = 120; 
$ItemMax[mfemale, RocketgunAmmo] = 120; 
$ItemMax[harmor, RocketgunAmmo] = 150; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[Rocketgun] = 1; 
$RemoteInvList[Rocketgun] = 1; 
$InvList[RocketgunAmmo] = 1; 
$RemoteInvList[RocketgunAmmo] = 1; 
 
$AutoUse[Rocketgun] = true; 
$SellAmmo[Rocketgun] = 50; 
$AmmoPackMax[Rocketgun] = 400; 
$WeaponAmmo[Rocketgun] = RocketgunAmmo; 
 
//-=-=-=-= 
 
ItemData RocketgunAmmo 
{ 
	description = "rockets"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 100; 
}; 
 
ItemImageData RocketgunImage 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
 
	weaponType = 1;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = RocketgunRocket; 
	ammotype = RocketgunAmmo; 
	aimDeflection = 0.03; 
	accuFire = True; 
	reloadTime = 0.9; 
	fireTime = 0.07; 
	spinUpTime = 0.4;
	DownTime = 1;
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = SoundFireChaingun; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData Rocketgun 
{ 
	description = "Rocket Chaingun"; 
	className = weapon; 
	shapefile = "chaingun"; 
	hudIcon = "grenade"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = RocketgunImage; 
	price = 150; 
	showWeaponBar = True; 
}; 

function Rocketgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Rocket Chaingun]:<f1> Go ahead and destory things.", 2);
}

addWeapon(Rocketgun);

//------------ChainGUN----=-==-=-=

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 1;
	fireTime = 0.0005;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Enforcer";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function Chaingun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Enforcer]:<f1> This gun has been known to make peace among people. ", 2);
}

addWeapon(Chaingun);

//-----------------Plasma-----------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

function PlasmaGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Plasma Gun]:<f1> Fires balls of glowing Plasma At your opponent.", 2);
}

addWeapon(PlasmaGun);
//------Grenade Luncher----------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

function GrenadeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Grenade Laucher]:<f1> Blow someone up make some extra cash.", 2);
}

addWeapon(GrenadeLauncher);
//------------Mortar----------------------------------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.7;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

function Mortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Mortar]:<f1> Nothing will surive when this this is fired", 2);
}

addWeapon(Mortar);
//----------------------------------------------------------------------------

//-----Thanks Armageddon for the Fire Code ^_^-------------Hyper fuser---------------

ItemData DiscAmmo
{
	description = "";
	className = "Ammo";
	shapeFile = "discb";//discammo
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0; // 0, single 1, spinning, 2 cont ,3disc
	reloadTime = 0.50;
	accuFire = true;
	fireTime = 0.15;

	ammoType =DiscAmmo;
//	projectileType = DiscShell; //messes with onimagefire
	accuFire = True;

	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 3;
//	lightColor = { 0.6, 1, 1 };
   lightColor = { 0.25, 0.25, 0.85 };
	spinUpTime = 0.25;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Hyper Fuser";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function DiscLauncherImage::onFire(%player, %slot)
{
if (Player::getItemCount(%player, $WeaponAmmo[DiscLauncher]) >= 1)
	{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("DiscShell",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)-0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("DiscShell",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)+0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("DiscShell",%transform,%player,%velocity); 
	GameBase::setRotation(%player, %rot);
	Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
	}
	
if (Player::getItemCount(%player, $WeaponAmmo[DiscLauncher]) > 0 && Player::getItemCount(%player, $WeaponAmmo[DiscLauncher]) < 1) 
	{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("DiscShell",%transform,%player,%velocity);
	Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
	}

}


function DiscLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Hyper Fuser]:<f1> A 3 Disc Launcher.", 2);
}

addWeapon(DiscLauncher);

//--------------------Dual Spin fuser
$ItemMax[larmor, Dual] = 1; 
$ItemMax[lfemale, Dual] = 1; 
$ItemMax[marmor, Dual] = 1; 
$ItemMax[mfemale, Dual] = 1; 
$ItemMax[harmor, Dual] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, DualAmmo] = 40; 
$ItemMax[lfemale, DualAmmo] = 40; 
$ItemMax[marmor, DualAmmo] = 50; 
$ItemMax[mfemale, DualAmmo] = 50; 
$ItemMax[harmor, DualAmmo] = 60; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[Dual] = 1; 
$RemoteInvList[Dual] = 1; 
$InvList[DualAmmo] = 1; 
$RemoteInvList[DualAmmo] = 1; 
 
$AutoUse[Dual] = true; 
$SellAmmo[Dual] = 50; 
$AmmoPackMax[Dual] = 200; 
$WeaponAmmo[Dual] = DualAmmo;
 
ItemData DualAmmo
{	description = "Disc Ammo";
	className = "Ammo";
	shapeFile = "discammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
}; 

ItemData Dual1Ammo
{	description = "Disc Ammo";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 20;
	showInventory = false;
};

ItemData Dual2Ammo
{	description = "Disc Ammo";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 20;
	showInventory = false;
}; 

ItemImageData Dual1Image 
{	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	ammoType = Dual1Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	projectileType = DiscShell;
};

ItemData Dual1
{	description = "Dual Fuser";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Dual1Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData Dual2Image
{	shapeFile = "disc";
	mountPoint = 0;
	mountRotation = { 0, 3.14, 0 };
	ammoType = Dual2Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	projectileType = DiscShell;
};

ItemData Dual2
{	description = "Dual Fuser";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Dual2Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData DualImage
{	shapeFile = "breath";
	mountPoint = 3;
	weaponType = 3;
	ammoType = DualAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	spinUpTime = 0.2;
	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData Dual
{	description = "Dual Fuser";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DualImage;
	price = 250;
	showWeaponBar = true;
};

function Dual::onMount(%player,%imageSlot,%item)
{	
	%num = Player::getItemCount(%player, "DualAmmo");
	Player::setItemCount(%player, "Dual1Ammo", %num);
	Player::mountItem(%player,Dual1,6);
 	Player::setItemCount(%player, "Dual2Ammo", %num);
 	Player::mountItem(%player,Dual2,7);
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc><f2>[Dual Fuser]: <f1>This spinfuser will lay waste to any all your enemnys.");
}

function Dual::onUnmount(%player,%imageSlot)
{	
	Player::unmountItem(%player,6);
 	Player::unmountItem(%player,7);
}

function DualImage::onFire(%player, %slot)
{ 	
	%state1 = Player::getItemState(%player,6);
 	%state2 = Player::getItemState(%player,7);
 	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload")
	{	%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player, "DualAmmo", 1);
		%num = Player::getItemCount(%player, "DualAmmo");
		if(%client.hd == 0)
		{	%client.hd = 1;
			if(%num == 1)
				Player::setItemCount(%player, "DualAmmo", 0);
			else 
				Player::setItemCount(%player, "Dual1Ammo", %num);
 			Player::trigger(%player,6,true);
 			Player::trigger(%player,6,false);
	 	}
		else
		{	%client.hd = 0;
 			if(%num == 1)
 				Player::setItemCount(%player, "Dual2Ammo", 0);
 			else
				Player::setItemCount(%player, "Dual2Ammo", %num);
 			Player::trigger(%player,7,true);
 			Player::trigger(%player,7,false);
 		}
 	} 
}

addWeapon(Dual);
//-------------Tactical Nuke---------------------------------------------------------------
$ItemMax[larmor, TacticalN] = 0; 
$ItemMax[lfemale, TacticalN] = 0; 
$ItemMax[marmor, TacticalN] = 0; 
$ItemMax[mfemale, TacticalN] = 0; 
$ItemMax[harmor, TacticalN] = 1; 
 
//-=-=-=-= 
$ItemMax[harmor, TacticalNAmmo] = 2; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[TacticalN] = 1; 
$RemoteInvList[TacticalN] = 1; 
$InvList[TacticalNAmmo] = 1; 
$RemoteInvList[TacticalNAmmo] = 1; 
 
$AutoUse[TacticalN] = true; 
$SellAmmo[TacticalN] = 1; 
$AmmoPackMax[TacticalN] = 3; 
$WeaponAmmo[TacticalN] = TacticalNAmmo; 
 
//-=-=-=-= 
 
ItemData TacticalNAmmo 
{ 
	description = "Nuke missles"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 100; 
}; 
 
ItemImageData TacticalNImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	 
	ammotype = TacticalNAmmo; 
	projectileType = TactRocket;
	aimDeflection = 0.0; 
	accuFire = True; 
	reloadTime = 0.2; 
	fireTime = 0.2; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData TacticalN 
{ 
	description = "Tactical Nuke"; 
	className = weapon; 
	shapefile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = TacticalNImage; 
	price = 200; 
	showWeaponBar = True; 
}; 

function TacticalN::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Nuke Missle]:<f1> This weapon is pure evil.", 2);
}


addWeapon(TacticalN);
//--------------Nitro Nader--------------------------------------------------
$ItemMax[larmor, NitroN] = 1; 
$ItemMax[lfemale, NitroN] = 1; 
$ItemMax[marmor, NitroN] = 1; 
$ItemMax[mfemale, NitroN] = 1; 
$ItemMax[harmor, NitroN] = 1; 
 
//-=-=-=-= 
 
$ItemMax[larmor, NitroNAmmo] = 50; 
$ItemMax[lfemale, NitroNAmmo] = 50; 
$ItemMax[marmor, NitroNAmmo] = 80; 
$ItemMax[mfemale, NitroNAmmo] = 80; 
$ItemMax[harmor, NitroNAmmo] = 100; 
 
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-// 
 
 
$InvList[NitroN] = 1; 
$RemoteInvList[NitroN] = 1; 
$InvList[NitroNAmmo] = 1; 
$RemoteInvList[NitroNAmmo] = 1; 
 
$AutoUse[NitroN] = true; 
$SellAmmo[NitroN] = 50; 
$AmmoPackMax[NitroN] = 200; 
$WeaponAmmo[NitroN] = NitroNAmmo; 
 
//-=-=-=-= 
 
ItemData NitroNAmmo 
{ 
	description = "NitroAmmo"; 
	classname = "Ammo"; 
	shapefile = "ammo1"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 100; 
}; 
 
ItemImageData NitroNImage 
{ 
	shapeFile = "grenadel"; 
	mountPoint = 0; 
 
	weaponType = 0;  //Change to a 1 if it is a fast firing machinegun 
	projectileType = NitroShell; 
	ammotype = NitroNAmmo; 
	aimDeflection = 0.03; 
	accuFire = True; 
	reloadTime = 0.2; 
	fireTime = 0.2; 
 
	lightType = 3; 
	lightRadius = 5; 
	lightTime = 0.25;  //Quick burst light 
	lightColor = { 0, 0, 1}; 
 
	sfxFire = SoundFireGrenade; 
	sfxActivate = SoundPickupWeapon; 
}; 
 
ItemData NitroN 
{ 
	description = "Nitrous Grenader"; 
	className = weapon; 
	shapefile = "grenadel"; 
	hudIcon = "grenade"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = NitroNImage; 
	price = 110; 
	showWeaponBar = True; 
}; 

function NitroN::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Nitro Nader]:<f1> Go ahead and lob a few around", 2);
}

addWeapon(NitroN);
//--------------------Jinzo Laser--------------------------------------------
$ItemMax[larmor,XLaser] = 1; 
$ItemMax[lfemale, XLaser] = 1; 
$ItemMax[marmor, XLaser] = 1; 
$ItemMax[mfemale,XLaser] = 1; 
$ItemMax[harmor, XLaser] = 1;

$InvList[XLaser] = 1; 
$RemoteInvList[XLaser] = 1; 
$AutoUse[XLaser] = true; 


ItemImageData XLaserImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = XtraLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 1.0;
	minEnergy = 0.1;
	maxEnergy = 0.3;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0, 0, 0 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundShieldOn;
};

ItemData XLaser
{
	description = "Jinzo Laser" ;
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = XLaserImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};


function XLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Jinzo Laser]:<f1> The best laser rifle Ever", 2);
}

addWeapon(XLaser);
//--------------laser rifle--------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function LaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Laser Rifle]:<f1> The Ulimate in sniping weapons.", 2);
}

addWeapon(LaserRifle);
//----------------Target Laser------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

function TargetingLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[Target Laser]: Fear my Targeting laser of doom.:<f1>  ", 2);
}

//--------------ELF----------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

function EnergyRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>[ELF]:<f1> The little annoyance", 2);
}

addWeapon(EnergyRifle);
//--------------Repair GUN--------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 0;
	maxEnergy = 0;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
   validateShape = true;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}


//----------------------------------------------------------------------------
// Backpacks
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

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


//-----------------Invo-----------------------------------------------------------

ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

additem(DeployableInvPack);


function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
 	 		         addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Inventory Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
						echo("MSG: ",%client," deployed an Inventory Station");
						return true;
					}
				}
				else {
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//--------------ammo--------------------------------------------------------------

ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableAmmoPack
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
additem(DeployableAmmoPack);

function DeployableAmmoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableAmmoPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
	         	   addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Ammo Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
						echo("MSG: ",%client," deployed an Ammo Station");
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//--------------------enenrgy--------------------------------------------------------

ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};
additem(EnergyPack);

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

//--------------Repair--------------------------------------------------------------

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};
additem(RepairPack);

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	


//----------------------------------------------------------------------------

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};
additem(SheildPack);

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}



//----------------------------------------------------------------------------

ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

additem(SensorJammerPack);

ItemData SensorJammerPack
{
	description = "Sensor Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}


//----------------------------------------------------------------------------

ItemImageData MotionSensorPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

additem(SensorJammerPack);



ItemData MotionSensorPack
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "dDeployables";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

//	if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) {
function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor");
					Client::sendMessage(%client,0,"Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}


//----------------------------------------------------------------------------

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

additem(AmmoPack);

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 7 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.BulletAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.DiscAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 7 ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {
	        %numAdd = %item.BulletAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.DiscAmmo;
		}
		else if(%i == 3) {
	    	%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 4) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 7 ; %i = %i +1) {
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

//----------------------------------------------------------------------------

ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

additem(PulseSensorePack);

ItemData PulseSensorPack
{
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "dDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}


//----------------------------------------------------------------------------

ItemImageData DeployableSensorJamPackImage
{
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

additem(DeployableSensorJammerPack);

ItemData DeployableSensorJammerPack
{
	description = "Sensor Jammer";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = "dDeployables";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}


//----------------------------------------------------------------------------


function checkDeployArea(%client,%pos)
{
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
//----------------------------------------------------------------------------


ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};
additem(CameraPack);

ItemData CameraPack
{
	description = "Camera";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function CameraPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function CameraPack::onDeploy(%player,%item,%pos)
{
	if (CameraPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position)) {
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Camera");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
//---------------------------------------
																			
ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

additem(TurretPack);
ItemData TurretPack
{
	description = "Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

function checkDeployArea(%client,%pos)
{
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
//----------------------------------------------------------------------------
// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
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
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

function CountPlayerWeapons(%player){
	for (%i = 1; %i < $weaponCount +1; %i = %i + 1) {
		if ($weaponlist[%i] != "" && Player::getItemCount(%player,$weaponlist[%i])) %count+=1;
		}
	return %count;
}

//--Excute packs--------------------------------------------------------------------------
exec(Regenpack);//Regen pack
exec(Cloak);//Cloaker
//exec(mega); Taken out for debugging
//---------execute deyployables here
//-------------------------------------------------------------------
exec(ForceField);//Small FF
exec(ForceFieldDoor);// FF door
exec(Blastwall);// Blastwall
exec(Platform);// platform

//---turrets
exec(LaserTurret);
//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;
//--- repair kit
ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = true;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//----------------Mine------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//-----------------------AIR BRAKE-----------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
  if($matchStarted) {
	  Player::decItemCount(%player,%item);
	  %client = Player::getClient(%player);	
          %velocity = Item::getVelocity(%player);
    	  %velX = getWord(%velocity, 0);
    	  %velY = getWord(%velocity, 1);
	  %velZ = getWord(%velocity, 2);
	  %velXa = %velX / 6;
	  %velYa = %velY / 6;
	  %velZa = %velZ / 6;
	  Item::setVelocity(%player, %velXa @ " " @ %velYa @ " " @ %velZa);
	  Client::sendMessage(%client,0,"You stopped spanking your monkey.");
	}
}

//--------------BOOST--------------------------------------------------------------

 ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
        className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
        //if (Beacon::deployShape(%player,%item)) {
        //        Player::decItemCount(%player,%item);
        //}
                if($matchStarted) {
                if(%player.throwTime < getSimTime() ) {
                        Player::decItemCount(%player,%item);
                        %obj = newObject("","Mine","boost");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,0,false);
                        %player.throwTime = getSimTime() + 0.00005;
                        Client::sendMessage(Player::getClient(%player),0,"You Spanked your Monkey.");
                }
        }
}


//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
   validateShape = true;
   validateMaterials = true;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.125);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.1);
}


//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
	if ($TestCheats) {
		Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,Chaingun,1);
		Player::setItemCount(%clientId,PlasmaGun,1);
		Player::setItemCount(%clientId,GrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,Mortar,1);

		Player::setItemCount(%clientId,BulletAmmo,200);
		Player::setItemCount(%clientId,PlasmaAmmo,200);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DiscAmmo,200);
		Player::setItemCount(%clientId,MortarAmmo,200);

      Player::setItemCount(%clientId,Grenade, 200);
      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
		Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
		Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
		Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);

      Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
      Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);

		Player::setItemCount(%clientId,RepairKit,1);
	}
}


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
	$TeamItemCount[0 @ DeployableAmmoPack] = 0;
	$TeamItemCount[0 @ DeployableInvPack] = 0;
	$TeamItemCount[0 @ TurretPack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
	$TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[0 @ PulseSensorPack] = 0;
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;

	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableInvPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;

	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableInvPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;

	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableInvPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;

	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableInvPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;

	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableInvPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;

	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableInvPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;

	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableInvPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
