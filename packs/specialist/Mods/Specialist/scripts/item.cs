//----------------------------------------------------------------------------

$ItemFavoritesKey = "Specialistv2000c";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

// original weapons
$AutoUse[ChargeGun] = True;  // This may be superfluous junk (RJC)

// Amount to remove when selling or dropping ammo
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

// Limit on number of special Items you can buy
$TeamItemMax[TurretPack] = 0;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
// $TeamItemMax[ScoutVehicle] = 3;
// $TeamItemMax[HAPCVehicle] = 1;
// $TeamItemMax[LAPCVehicle] = 2;
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

			$BuyingFavs[%client] = true;

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

	$BuyingFavs[%client] = false;
}


function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}


function checkResources(%player,%item,%delta,%noMessage){

	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
	// Check for Ammo pack
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") {
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	// Check to see if player is wearing a mine pack
	if (Player::getMountedItem(%client,$BackpackSlot) == minepack && $MinePackMax[%item] != "") {
		%extraAmmo = $MinePackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	// Check to see if player is wearing a flame pack
	if (Player::getMountedItem(%client,$BackpackSlot) == flamepack && $FlamePackMax[%item] != "") {
		%extraAmmo = $FlamePackMax[%item];
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
		else if(GameBase::getDataName(%player.Vehicle) == Supply) {
			%energy = "Infinite";
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
			Client::sendMessage(%client,0,"Too many weapons for " @ $ArmorName[%armor].description @ " to carry");
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

		// The following section added by RCabrera for the Specialist mod, 7/10/00
		// if this is a core
		if ($CoreType[%item] == "Beacon") {
			// count number of cores player has
			for (%r = 1; %r <= $BeaconInitCounter; %r++) {
				%count += Player::getItemCount(%client, $Core[Beacon, %r]);
			}
			// set max to the number of beacons that they can carry
			%max = $ItemMax[(Player::getArmor(%client)), Beacon] + %extraAmmo ;
		}
		else if ($CoreType[%item] == "Grenade") {
			// count number of cores player has
			for (%r = 1; %r <= $GrenadeInitCounter; %r++) {
				%count += Player::getItemCount(%client, $Core[Grenade, %r]);
			}
			// set max to the number of grenades that they can carry
			%max = $ItemMax[(Player::getArmor(%client)), Grenade] + %extraAmmo ;
		}
		else if ($CoreType[%item] == "Mine") {
			// count number of cores player has
			for (%r = 1; %r <= $MineInitCounter; %r++) {
				%count += Player::getItemCount(%client, $Core[Mine, %r]);
			}
			// set max to the number of mines that they can carry
			%max = $ItemMax[(Player::getArmor(%client)), MineAmmo] + %extraAmmo ;
		}

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

					// Set armor abilities
					SpecialistArmorOnDon (%player, %buyarmor);

					checkMax(%client,%buyarmor);
					armorChange(%client);
	     				Player::setItemCount(%client, $ArmorName[%armor], 0);  
     					Player::setItemCount(%client, %item, 1);  
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);	

					// check for mine pack
					if (Player::getMountedItem(%client,$BackpackSlot) == minepack) 
						fillMinePack(%client);	

					// check for flame pack
					if (Player::getMountedItem(%client,$BackpackSlot) == flamepack) 
						fillFlamePack(%client);	

					// Here we buy "standard" equipment for that armor
					// This is to speed the learning curve for newbies
					// and aid in setting favorites

					if ($BuyingFavs[%client] != true) {
						SpecialistBuyArmorPresets(%client, %buyarmor);
					}

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
				if(%pack == ammopack || %pack == minepack || %pack == flamepack) 
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
				if(%item == minepack) 
					fillMinePack(%client);
				if(%item == flamepack) 
					fillFlamePack(%client);
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == ammopack) 
					fillAmmoPack(%client);
				if(%pack == minepack) 
					fillMinePack(%client);
				if(%pack == flamepack) 
					fillFlamePack(%client);
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

				// If buying a beacon core, then buy beacons too
				if ($CoreType[%item] == "Beacon") {
//				if(%item == Alarm || %item == Camera || %item == TimedExplosiveGrenade || %item == CommSilencer
//					|| %item == Eavesdropper || %item == ForceShield || %item == Loudmouth || %item == MotionSensor
//					|| %item == PersonalShield || %item == iPulseSensor || %item == RemoteBomb || %item == RepairBot
//					|| %item == SensorJammer || %item == SpyCamera) {
					// echo("Auto-buying beacons");
					buyItem(%client, "Beacon");
				}

				// If buying a grenade core, then buy grenades too
				if ($CoreType[%item] == "Grenade") {
//				if(%item == AcidGrenade || %item == EMPGrenade || %item == FlashGrenade || %item == IncendiaryGrenade
//					|| %item == PoisonGasGrenade || %item == RadiationGrenade || %item == ShrapnelGrenade 
//					|| %item == SmokeLineGrenade || %item == CircuitExplosive) {
					buyItem(%client, "Grenade");
				}

				// If buying a mine core, then buy mines too
				if ($CoreType[%item] == "Mine") {
//				if(%item == DecoyMine || %item == EMPMine || %item == FlagMine || %item == IncendiaryMine 
//					|| %item == NormalMine || %item == FlashMine) {
					buyItem(%client, "MineAmmo");
				}
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
			else if (%item == minepack) 
				checkMax(%client,Player::getArmor(%client));
			else if (%item == flamepack) 
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
	%client.throwStrength = 1;

	%item = getItemData(%type);
	// echo("Use item: " @ %type @ " " @ %item);

	if (%item == Backpack) {
		%item = Player::getMountedItem(%client,$BackpackSlot);

		// if trying to use a pack, but you don't have one
		// then you must be trying to undeploy something
		if (%item == -1) {
			SpecialistUndeploy(%client);
		}
	}
	else {
		if (%item == Weapon) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
		}
	}
	Player::useItem(%client,%item);
}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
		//if(GameBase::getControlClient(%player) != -1) {
	  		// echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo) {
				if (%strength < 0)
					%strength = 0;
				else
					if (%strength > 100)
						%strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);

				// use the correct grenade
				Player::useItem(%client,%item);
			}
		}
	}
}

function remoteDropItem(%client,%type)
{
	if((Client::getOwnedObject(%client)).driver != 1) {
		// echo("Drop item: ",%type);
		%client.throwStrength = 1;

		%item = getItemData(%type);
		// echo("Dropping item: " @%item);

		// can't drop vehicle weapons
		if (%item == TankArtilleryShell || %item == TankCannon) return;

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
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

function remoteNextWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "") {
		selectValidWeapon(%client);
	}
	else {
		for (%weapon = $NextWeapon[%item]; %weapon != %item;
				%weapon = $NextWeapon[%weapon]) {
			if (isSelectableWeapon(%client,%weapon)) {
				Player::useItem(%client,%weapon);

				// Print out the name of this weapon
				bottomprint(%client, "   " @ %weapon.description, 2);

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

				// Print out the name of this weapon
				bottomprint(%client, "   " @ %weapon.description, 2);

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

			// Print out the name of this weapon
			bottomprint(%client, "   " @ %weapon.description, 2);

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
				Client::sendMessage(%client,0,"You received a " @ %item.description @ " backpack");
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
			if (Player::getMountedItem(%client,$BackpackSlot) == minepack && $MinePackMax[%item] != "") 
				%extraAmmo = $MinePackMax[%item];
			if (Player::getMountedItem(%client,$BackpackSlot) == flamepack && $FlamePackMax[%item] != "") 
				%extraAmmo = $FlamePackMax[%item];
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

	// === Added in Base v1.11 ===
	validateShape = true;
	// ===========================

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
	// echo("Using backpack");
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::trigger(%player,$BackpackSlot);
	}
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

ItemImageData PulseSensorPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

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


ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

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
	// === Added in Base v1.11 ===
	validateShape = true;
	validateMaterials = true;
	// ===========================

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
//----------------------------------------------------------------------------
																			
ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Ion Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "uTurrets";
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
	else {
//		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		return true;
		deleteObject(%set);
	}
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

//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
   // === Added in Base v1.11 ===
   validateShape = true;
   validateMaterials = true;
   // ===========================

};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
	// Nullify any poison effects (Specialist)
	$PoisonGasTTG[Player::getClient(%player)] = 0;
}


//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "hMines";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {

			%client = Player::getClient(%player);
			%item = %client.currentMineCore;

			// if the player does not have the core they currently want to use
			if (Player::incItemCount(%player, %item, 0) <= 0) {

				// Then we'll use a core that they DO have

				// Check to see if player has EMP Mines
				if (Player::incItemCount(%player, EMPMine, 0) > 0) {
					%item = EMPMine;
				}
				// Check to see if player has Flash Mines
				else if (Player::incItemCount(%player, FlashMine, 0) > 0) {
					%item = FlashMine;
				}
				// Check to see if player has Decoy Mines
				else if (Player::incItemCount(%player, DecoyMine, 0) > 0) {
					%item = DecoyMine;
				}
				// Check to see if player has Flag Mines
				else if (Player::incItemCount(%player, FlagMine, 0) > 0) {
					%item = FlagMine;
				}
				// Check to see if player has Incendiary Mines
				else if (Player::incItemCount(%player, IncendiaryMine, 0) > 0) {
					%item = IncendiaryMine;
				}
				// Check to see if player has Normal Mines
				else if (Player::incItemCount(%player, NormalMine, 0) > 0) {
					%item = NormalMine;
				}
				else {
					// Mine has no core, so we throw out a harmless mine
					Player::incItemCount(%player, NullMine, 1);
					%item = NullMine;
					Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Mine has no core");
				}
			}

			// use the correct mine
			Player::useItem(%player, %item);

		}
	}
}


//----------------------------------------------------------------------------

ItemData Grenade
{
	description = "Grenade";
	shapeFile = "grenade";
	heading = "gGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	// === Added in Base v1.11 ===
	validateShape = true;
	validateMaterials = true;
	// ===========================

};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {


			%client = Player::getClient(%player);
			%item = %client.currentGrenadeCore;

			// if the player does not have the core they currently want to use
			if (Player::incItemCount(%player, %item, 0) <= 0) {

				// Then we'll use a core that they DO have

				// Check to see if player has Smoke Line Grenades
				if (Player::incItemCount(%player, SmokeLineGrenade, 0) > 0) {
					%item = SmokeLineGrenade;
				}
				// Check to see if player has EMP Grenades
				else if (Player::incItemCount(%player, EMPGrenade, 0) > 0) {
					%item = EMPGrenade;
				}
				// Check to see if player has Radiation Grenades
				else if (Player::incItemCount(%player, RadiationGrenade, 0) > 0) {
					%item = RadiationGrenade;
				}
				// Check to see if player has Poison Gas Grenades
				else if (Player::incItemCount(%player, PoisonGasGrenade, 0) > 0) {
					%item = PoisonGasGrenade;
				}
				// Check to see if player has Acid Grenades
				else if (Player::incItemCount(%player, AcidGrenade, 0) > 0) {
					%item = AcidGrenade;
				}
				// Check to see if player has Flash Grenades
				else if (Player::incItemCount(%player, FlashGrenade, 0) > 0) {
					%item = FlashGrenade;
				}
				// Check to see if player has Incendiary Grenades
				else if (Player::incItemCount(%player, IncendiaryGrenade, 0) > 0) {
					%item = IncendiaryGrenade;
				}
				// Check to see if player has Shrapnel Grenades
				else if (Player::incItemCount(%player, ShrapnelGrenade, 0) > 0) {
					%item = ShrapnelGrenade;
				}
				// Check to see if player has Remote Bomb Grenades
				else if (Player::incItemCount(%player, RemoteBomb, 0) > 0) {
					%item = RemoteBomb;
				}
				else {
					// Grenade has no core, so we throw out a harmless grenade
					Player::incItemCount(%player, NullGrenade, 1);
					%item = NullGrenade;
					Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Grenade has no core");
				}
			}

			// use the correct grenade
			Player::useItem(%player, %item);

		}
	}
}


//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
	// === Added in Base v1.11 ===
	validateShape = true;
	validateMaterials = true;
	// ===========================

};

function Beacon::onUse(%player,%item) {

	%client = Player::getClient(%player);
	%item = %client.currentBeaconCore;

	// if the player does not have the core they currently want to use
	if (Player::incItemCount(%player, %item, 0) <= 0) {

		// Then we'll use a core that they DO have

		// Check to see if player has Spy Camera Beacons
		if (Player::incItemCount(%player, SpyCamera, 0) > 0) {
			%item = SpyCamera;
		}
		// Check to see if player has SensorJammer Beacons
		else if (Player::incItemCount(%player, SensorJammer, 0) > 0) {
			%item = SensorJammer;
		}
		// Check to see if player has PulseSensor Beacons
		else if (Player::incItemCount(%player, iPulseSensor, 0) > 0) {
			%item = iPulseSensor;
		}
		// Check to see if player has PersonalShield Beacons
		else if (Player::incItemCount(%player, PersonalShield, 0) > 0) {
			%item = PersonalShield;
		}
		// Check to see if player has ForceShield Beacons
		else if (Player::incItemCount(%player, ForceShield, 0) > 0) {
			%item = ForceShield;
		}
		// Check to see if player has RepairBot Beacons
		else if (Player::incItemCount(%player, RepairBot, 0) > 0) {
			%item = RepairBot;
		}
		// Check to see if player has Loudmouth Beacons
		else if (Player::incItemCount(%player, Loudmouth, 0) > 0) {
			%item = Loudmouth;
		}
		// Check to see if player has Alarm Beacons
		else if (Player::incItemCount(%player, Alarm, 0) > 0) {
			%item = Alarm;
		}
		// Check to see if player has Circuit Explosive Beacons
		else if (Player::incItemCount(%player, CircuitExplosive, 0) > 0) {
			%item = CircuitExplosive;
		}
		// Check to see if player has Timed Explosive Beacons
		else if (Player::incItemCount(%player, TimedExplosiveGrenade, 0) > 0) {
			%item = TimedExplosiveGrenade;
		}
		// Check to see if player has Comm Silencer Beacons
		else if (Player::incItemCount(%player, CommSilencer, 0) > 0) {
			%item = CommSilencer;
		}
		// Check to see if player has Eavesdropper Beacons
		else if (Player::incItemCount(%player, Eavesdropper, 0) > 0) {
			%item = Eavesdropper;
		}
		// Check to see if player has MotionSensor Beacons
		else if (Player::incItemCount(%player, MotionSensor, 0) > 0) {
			%item = MotionSensor;
		}
		// Check to see if player has Camera Beacons
		else if (Player::incItemCount(%player, Camera, 0) > 0) {
			%item = Camera;
		}
		else {
			// Beacon has no core, so we throw out a default Beacon
			Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Beacon has no core, deploying target beacon.");
			if (Beacon::deployShape(%player,%item)) {
				Player::decItemCount(%player,%item);
			}
			return;
		}
	}

	// use the correct beacon
	Player::useItem(%player, %item);


	// if (Beacon::deployShape(%player,%item)) {
	//	Player::decItemCount(%player,%item);
	// }
}

function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape") {
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
				%rot = "0 0 0";
			}
			else {
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 0";
				}
				else {
					%rot = Vector::getRotation($los::normal);
				}
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Target Beacon");
   			   Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Beacon deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}


//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
	// === Added in Base v1.11 ===
	validateShape = true;
	validateMaterials = true;
	// ===========================

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
	// And nullify any poison effects (Specialist)
	$PoisonGasTTG[Player::getClient(%player)] = 0;
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
	// Specialist items
	$TeamItemCount[0 @ SpyCamera] = 0;
	$TeamItemCount[0 @ RemoteBomb] = 0;
	$TeamItemCount[0 @ Alarm] = 0;
	$TeamItemCount[0 @ CircuitExplosive] = 0;
	$TeamItemCount[0 @ RepairBot] = 0;
	$TeamItemCount[0 @ ForceShield] = 0;
	$TeamItemCount[0 @ CommSilencer] = 0;
	$TeamItemCount[0 @ Eavesdropper] = 0;
	$TeamItemCount[0 @ Loudmouth] = 0;
	$TeamItemCount[0 @ iSmokeTurret] = 0;
	$TeamItemCount[0 @ iFlakTurret] = 0;
	$TeamItemCount[0 @ iFlameTurret] = 0;
	$TeamItemCount[0 @ iPlasmaTurret] = 0;
	$TeamItemCount[0 @ iELFTurret] = 0;
	$TeamItemCount[0 @ iRocketTurret] = 0;
	$TeamItemCount[0 @ iMortarTurret] = 0;
	$TeamItemCount[0 @ iIndoorTurret] = 0;
	$TeamItemCount[0 @ iIonTurret] = 0;
	$TeamItemCount[0 @ iLaserTurret] = 0;
	$TeamItemCount[0 @ iTargetingTurret] = 0;
	$TeamItemCount[0 @ MotionSensor] = 0;
	$TeamItemCount[0 @ Camera] = 0;
	$TeamItemCount[0 @ SensorJammer] = 0;
	$TeamItemCount[0 @ iPulseSensor] = 0;
	$TeamItemCount[0 @ iEMPTurret] = 0;
	$TeamItemCount[0 @ iSmallForceField] = 0;
	$TeamItemCount[0 @ iForceField] = 0;
	$TeamItemCount[0 @ iBarricade] = 0;
	$TeamItemCount[0 @ iBlastWall] = 0;
	$TeamItemCount[0 @ iBlastPlatform] = 0;
	$TeamItemCount[0 @ iBlastCover] = 0;
	$TeamItemCount[0 @ iHoverPad] = 0;
	$TeamItemCount[0 @ iChainTurret] = 0;
	$TeamItemCount[0 @ iNuclearWaste] = 0;
	$TeamItemCount[0 @ iBackupGenerator] = 0;
	$TeamItemCount[0 @ iShieldGenerator] = 0;
	$TeamItemCount[0 @ iFlagStand] = 0;
	$TeamItemCount[0 @ iTeleporter] = 0;
	$TeamItemCount[0 @ iAccelerator] = 0;
	$TeamItemCount[0 @ BomberVehicle] = 0;
	$TeamItemCount[0 @ FighterVehicle] = 0;
	$TeamItemCount[0 @ HelicopterVehicle] = 0;
	$TeamItemCount[0 @ TankVehicle] = 0;
	$TeamItemCount[0 @ APCVehicle] = 0;
	$TeamItemCount[0 @ OutriderVehicle] = 0;
	$TeamItemCount[0 @ SupplyVehicle] = 0;
	$TeamItemCount[0 @ CargoVehicle] = 0;


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
	// Specialist items
	$TeamItemCount[1 @ SpyCamera] = 0;
	$TeamItemCount[1 @ RemoteBomb] = 0;
	$TeamItemCount[1 @ Alarm] = 0;
	$TeamItemCount[1 @ CircuitExplosive] = 0;
	$TeamItemCount[1 @ RepairBot] = 0;
	$TeamItemCount[1 @ ForceShield] = 0;
	$TeamItemCount[1 @ CommSilencer] = 0;
	$TeamItemCount[1 @ Eavesdropper] = 0;
	$TeamItemCount[1 @ Loudmouth] = 0;
	$TeamItemCount[1 @ iSmokeTurret] = 0;
	$TeamItemCount[1 @ iFlakTurret] = 0;
	$TeamItemCount[1 @ iFlameTurret] = 0;
	$TeamItemCount[1 @ iPlasmaTurret] = 0;
	$TeamItemCount[1 @ iELFTurret] = 0;
	$TeamItemCount[1 @ iRocketTurret] = 0;
	$TeamItemCount[1 @ iMortarTurret] = 0;
	$TeamItemCount[1 @ iIndoorTurret] = 0;
	$TeamItemCount[1 @ iIonTurret] = 0;
	$TeamItemCount[1 @ iLaserTurret] = 0;
	$TeamItemCount[1 @ iTargetingTurret] = 0;
	$TeamItemCount[1 @ MotionSensor] = 0;
	$TeamItemCount[1 @ Camera] = 0;
	$TeamItemCount[1 @ SensorJammer] = 0;
	$TeamItemCount[1 @ iPulseSensor] = 0;
	$TeamItemCount[1 @ iEMPTurret] = 0;
	$TeamItemCount[1 @ iSmallForceField] = 0;
	$TeamItemCount[1 @ iForceField] = 0;
	$TeamItemCount[1 @ iBarricade] = 0;
	$TeamItemCount[1 @ iBlastWall] = 0;
	$TeamItemCount[1 @ iBlastPlatform] = 0;
	$TeamItemCount[1 @ iBlastCover] = 0;
	$TeamItemCount[1 @ iHoverPad] = 0;
	$TeamItemCount[1 @ iChainTurret] = 0;
	$TeamItemCount[1 @ iNuclearWaste] = 0;
	$TeamItemCount[1 @ iBackupGenerator] = 0;
	$TeamItemCount[1 @ iShieldGenerator] = 0;
	$TeamItemCount[1 @ iFlagStand] = 0;
	$TeamItemCount[1 @ iTeleporter] = 0;
	$TeamItemCount[1 @ iAccelerator] = 0;
	$TeamItemCount[1 @ BomberVehicle] = 0;
	$TeamItemCount[1 @ FighterVehicle] = 0;
	$TeamItemCount[1 @ HelicopterVehicle] = 0;
	$TeamItemCount[1 @ TankVehicle] = 0;
	$TeamItemCount[1 @ APCVehicle] = 0;
	$TeamItemCount[1 @ OutriderVehicle] = 0;
	$TeamItemCount[1 @ SupplyVehicle] = 0;
	$TeamItemCount[1 @ CargoVehicle] = 0;


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
	// Specialist items
	$TeamItemCount[2 @ SpyCamera] = 0;
	$TeamItemCount[2 @ RemoteBomb] = 0;
	$TeamItemCount[2 @ Alarm] = 0;
	$TeamItemCount[2 @ CircuitExplosive] = 0;
	$TeamItemCount[2 @ RepairBot] = 0;
	$TeamItemCount[2 @ ForceShield] = 0;
	$TeamItemCount[2 @ CommSilencer] = 0;
	$TeamItemCount[2 @ Eavesdropper] = 0;
	$TeamItemCount[2 @ Loudmouth] = 0;
	$TeamItemCount[2 @ iSmokeTurret] = 0;
	$TeamItemCount[2 @ iFlakTurret] = 0;
	$TeamItemCount[2 @ iFlameTurret] = 0;
	$TeamItemCount[2 @ iPlasmaTurret] = 0;
	$TeamItemCount[2 @ iELFTurret] = 0;
	$TeamItemCount[2 @ iRocketTurret] = 0;
	$TeamItemCount[2 @ iMortarTurret] = 0;
	$TeamItemCount[2 @ iIndoorTurret] = 0;
	$TeamItemCount[2 @ iIonTurret] = 0;
	$TeamItemCount[2 @ iLaserTurret] = 0;
	$TeamItemCount[2 @ iTargetingTurret] = 0;
	$TeamItemCount[2 @ MotionSensor] = 0;
	$TeamItemCount[2 @ Camera] = 0;
	$TeamItemCount[2 @ SensorJammer] = 0;
	$TeamItemCount[2 @ iPulseSensor] = 0;
	$TeamItemCount[2 @ iEMPTurret] = 0;
	$TeamItemCount[2 @ iSmallForceField] = 0;
	$TeamItemCount[2 @ iForceField] = 0;
	$TeamItemCount[2 @ iBarricade] = 0;
	$TeamItemCount[2 @ iBlastWall] = 0;
	$TeamItemCount[2 @ iBlastPlatform] = 0;
	$TeamItemCount[2 @ iBlastCover] = 0;
	$TeamItemCount[2 @ iHoverPad] = 0;
	$TeamItemCount[2 @ iChainTurret] = 0;
	$TeamItemCount[2 @ iNuclearWaste] = 0;
	$TeamItemCount[2 @ iBackupGenerator] = 0;
	$TeamItemCount[2 @ iShieldGenerator] = 0;
	$TeamItemCount[2 @ iFlagStand] = 0;
	$TeamItemCount[2 @ iTeleporter] = 0;
	$TeamItemCount[2 @ iAccelerator] = 0;
	$TeamItemCount[2 @ BomberVehicle] = 0;
	$TeamItemCount[2 @ FighterVehicle] = 0;
	$TeamItemCount[2 @ HelicopterVehicle] = 0;
	$TeamItemCount[2 @ TankVehicle] = 0;
	$TeamItemCount[2 @ APCVehicle] = 0;
	$TeamItemCount[2 @ OutriderVehicle] = 0;
	$TeamItemCount[2 @ SupplyVehicle] = 0;
	$TeamItemCount[2 @ CargoVehicle] = 0;


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
	// Specialist items
	$TeamItemCount[3 @ SpyCamera] = 0;
	$TeamItemCount[3 @ RemoteBomb] = 0;
	$TeamItemCount[3 @ Alarm] = 0;
	$TeamItemCount[3 @ CircuitExplosive] = 0;
	$TeamItemCount[3 @ RepairBot] = 0;
	$TeamItemCount[3 @ ForceShield] = 0;
	$TeamItemCount[3 @ CommSilencer] = 0;
	$TeamItemCount[3 @ Eavesdropper] = 0;
	$TeamItemCount[3 @ Loudmouth] = 0;
	$TeamItemCount[3 @ iSmokeTurret] = 0;
	$TeamItemCount[3 @ iFlakTurret] = 0;
	$TeamItemCount[3 @ iFlameTurret] = 0;
	$TeamItemCount[3 @ iPlasmaTurret] = 0;
	$TeamItemCount[3 @ iELFTurret] = 0;
	$TeamItemCount[3 @ iRocketTurret] = 0;
	$TeamItemCount[3 @ iMortarTurret] = 0;
	$TeamItemCount[3 @ iIndoorTurret] = 0;
	$TeamItemCount[3 @ iIonTurret] = 0;
	$TeamItemCount[3 @ iLaserTurret] = 0;
	$TeamItemCount[3 @ iTargetingTurret] = 0;
	$TeamItemCount[3 @ MotionSensor] = 0;
	$TeamItemCount[3 @ Camera] = 0;
	$TeamItemCount[3 @ SensorJammer] = 0;
	$TeamItemCount[3 @ iPulseSensor] = 0;
	$TeamItemCount[3 @ iEMPTurret] = 0;
	$TeamItemCount[3 @ iSmallForceField] = 0;
	$TeamItemCount[3 @ iForceField] = 0;
	$TeamItemCount[3 @ iBarricade] = 0;
	$TeamItemCount[3 @ iBlastWall] = 0;
	$TeamItemCount[3 @ iBlastPlatform] = 0;
	$TeamItemCount[3 @ iBlastCover] = 0;
	$TeamItemCount[3 @ iHoverPad] = 0;
	$TeamItemCount[3 @ iChainTurret] = 0;
	$TeamItemCount[3 @ iNuclearWaste] = 0;
	$TeamItemCount[3 @ iBackupGenerator] = 0;
	$TeamItemCount[3 @ iShieldGenerator] = 0;
	$TeamItemCount[3 @ iFlagStand] = 0;
	$TeamItemCount[3 @ iTeleporter] = 0;
	$TeamItemCount[3 @ iAccelerator] = 0;
	$TeamItemCount[3 @ BomberVehicle] = 0;
	$TeamItemCount[3 @ FighterVehicle] = 0;
	$TeamItemCount[3 @ HelicopterVehicle] = 0;
	$TeamItemCount[3 @ TankVehicle] = 0;
	$TeamItemCount[3 @ APCVehicle] = 0;
	$TeamItemCount[3 @ OutriderVehicle] = 0;
	$TeamItemCount[3 @ SupplyVehicle] = 0;
	$TeamItemCount[3 @ CargoVehicle] = 0;


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
	// Specialist items
	$TeamItemCount[4 @ SpyCamera] = 0;
	$TeamItemCount[4 @ RemoteBomb] = 0;
	$TeamItemCount[4 @ Alarm] = 0;
	$TeamItemCount[4 @ CircuitExplosive] = 0;
	$TeamItemCount[4 @ RepairBot] = 0;
	$TeamItemCount[4 @ ForceShield] = 0;
	$TeamItemCount[4 @ CommSilencer] = 0;
	$TeamItemCount[4 @ Eavesdropper] = 0;
	$TeamItemCount[4 @ Loudmouth] = 0;
	$TeamItemCount[4 @ iSmokeTurret] = 0;
	$TeamItemCount[4 @ iFlakTurret] = 0;
	$TeamItemCount[4 @ iFlameTurret] = 0;
	$TeamItemCount[4 @ iPlasmaTurret] = 0;
	$TeamItemCount[4 @ iELFTurret] = 0;
	$TeamItemCount[4 @ iRocketTurret] = 0;
	$TeamItemCount[4 @ iMortarTurret] = 0;
	$TeamItemCount[4 @ iIndoorTurret] = 0;
	$TeamItemCount[4 @ iIonTurret] = 0;
	$TeamItemCount[4 @ iLaserTurret] = 0;
	$TeamItemCount[4 @ iTargetingTurret] = 0;
	$TeamItemCount[4 @ MotionSensor] = 0;
	$TeamItemCount[4 @ Camera] = 0;
	$TeamItemCount[4 @ SensorJammer] = 0;
	$TeamItemCount[4 @ iPulseSensor] = 0;
	$TeamItemCount[4 @ iEMPTurret] = 0;
	$TeamItemCount[4 @ iSmallForceField] = 0;
	$TeamItemCount[4 @ iForceField] = 0;
	$TeamItemCount[4 @ iBarricade] = 0;
	$TeamItemCount[4 @ iBlastWall] = 0;
	$TeamItemCount[4 @ iBlastPlatform] = 0;
	$TeamItemCount[4 @ iBlastCover] = 0;
	$TeamItemCount[4 @ iHoverPad] = 0;
	$TeamItemCount[4 @ iChainTurret] = 0;
	$TeamItemCount[4 @ iNuclearWaste] = 0;
	$TeamItemCount[4 @ iBackupGenerator] = 0;
	$TeamItemCount[4 @ iShieldGenerator] = 0;
	$TeamItemCount[4 @ iFlagStand] = 0;
	$TeamItemCount[4 @ iTeleporter] = 0;
	$TeamItemCount[4 @ iAccelerator] = 0;
	$TeamItemCount[4 @ BomberVehicle] = 0;
	$TeamItemCount[4 @ FighterVehicle] = 0;
	$TeamItemCount[4 @ HelicopterVehicle] = 0;
	$TeamItemCount[4 @ TankVehicle] = 0;
	$TeamItemCount[4 @ APCVehicle] = 0;
	$TeamItemCount[4 @ OutriderVehicle] = 0;
	$TeamItemCount[4 @ SupplyVehicle] = 0;
	$TeamItemCount[4 @ CargoVehicle] = 0;


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
	// Specialist items
	$TeamItemCount[5 @ SpyCamera] = 0;
	$TeamItemCount[5 @ RemoteBomb] = 0;
	$TeamItemCount[5 @ Alarm] = 0;
	$TeamItemCount[5 @ CircuitExplosive] = 0;
	$TeamItemCount[5 @ RepairBot] = 0;
	$TeamItemCount[5 @ ForceShield] = 0;
	$TeamItemCount[5 @ CommSilencer] = 0;
	$TeamItemCount[5 @ Eavesdropper] = 0;
	$TeamItemCount[5 @ Loudmouth] = 0;
	$TeamItemCount[5 @ iSmokeTurret] = 0;
	$TeamItemCount[5 @ iFlakTurret] = 0;
	$TeamItemCount[5 @ iFlameTurret] = 0;
	$TeamItemCount[5 @ iPlasmaTurret] = 0;
	$TeamItemCount[5 @ iELFTurret] = 0;
	$TeamItemCount[5 @ iRocketTurret] = 0;
	$TeamItemCount[5 @ iMortarTurret] = 0;
	$TeamItemCount[5 @ iIndoorTurret] = 0;
	$TeamItemCount[5 @ iIonTurret] = 0;
	$TeamItemCount[5 @ iLaserTurret] = 0;
	$TeamItemCount[5 @ iTargetingTurret] = 0;
	$TeamItemCount[5 @ MotionSensor] = 0;
	$TeamItemCount[5 @ Camera] = 0;
	$TeamItemCount[5 @ SensorJammer] = 0;
	$TeamItemCount[5 @ iPulseSensor] = 0;
	$TeamItemCount[5 @ iEMPTurret] = 0;
	$TeamItemCount[5 @ iSmallForceField] = 0;
	$TeamItemCount[5 @ iForceField] = 0;
	$TeamItemCount[5 @ iBarricade] = 0;
	$TeamItemCount[5 @ iBlastWall] = 0;
	$TeamItemCount[5 @ iBlastPlatform] = 0;
	$TeamItemCount[5 @ iBlastCover] = 0;
	$TeamItemCount[5 @ iHoverPad] = 0;
	$TeamItemCount[5 @ iChainTurret] = 0;
	$TeamItemCount[5 @ iNuclearWaste] = 0;
	$TeamItemCount[5 @ iBackupGenerator] = 0;
	$TeamItemCount[5 @ iShieldGenerator] = 0;
	$TeamItemCount[5 @ iFlagStand] = 0;
	$TeamItemCount[5 @ iTeleporter] = 0;
	$TeamItemCount[5 @ iAccelerator] = 0;
	$TeamItemCount[5 @ BomberVehicle] = 0;
	$TeamItemCount[5 @ FighterVehicle] = 0;
	$TeamItemCount[5 @ HelicopterVehicle] = 0;
	$TeamItemCount[5 @ TankVehicle] = 0;
	$TeamItemCount[5 @ APCVehicle] = 0;
	$TeamItemCount[5 @ OutriderVehicle] = 0;
	$TeamItemCount[5 @ SupplyVehicle] = 0;
	$TeamItemCount[5 @ CargoVehicle] = 0;


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
	// Specialist items
	$TeamItemCount[6 @ SpyCamera] = 0;
	$TeamItemCount[6 @ RemoteBomb] = 0;
	$TeamItemCount[6 @ Alarm] = 0;
	$TeamItemCount[6 @ CircuitExplosive] = 0;
	$TeamItemCount[6 @ RepairBot] = 0;
	$TeamItemCount[6 @ ForceShield] = 0;
	$TeamItemCount[6 @ CommSilencer] = 0;
	$TeamItemCount[6 @ Eavesdropper] = 0;
	$TeamItemCount[6 @ Loudmouth] = 0;
	$TeamItemCount[6 @ iSmokeTurret] = 0;
	$TeamItemCount[6 @ iFlakTurret] = 0;
	$TeamItemCount[6 @ iFlameTurret] = 0;
	$TeamItemCount[6 @ iPlasmaTurret] = 0;
	$TeamItemCount[6 @ iELFTurret] = 0;
	$TeamItemCount[6 @ iRocketTurret] = 0;
	$TeamItemCount[6 @ iMortarTurret] = 0;
	$TeamItemCount[6 @ iIndoorTurret] = 0;
	$TeamItemCount[6 @ iIonTurret] = 0;
	$TeamItemCount[6 @ iLaserTurret] = 0;
	$TeamItemCount[6 @ iTargetingTurret] = 0;
	$TeamItemCount[6 @ MotionSensor] = 0;
	$TeamItemCount[6 @ Camera] = 0;
	$TeamItemCount[6 @ SensorJammer] = 0;
	$TeamItemCount[6 @ iPulseSensor] = 0;
	$TeamItemCount[6 @ iEMPTurret] = 0;
	$TeamItemCount[6 @ iSmallForceField] = 0;
	$TeamItemCount[6 @ iForceField] = 0;
	$TeamItemCount[6 @ iBarricade] = 0;
	$TeamItemCount[6 @ iBlastWall] = 0;
	$TeamItemCount[6 @ iBlastPlatform] = 0;
	$TeamItemCount[6 @ iBlastCover] = 0;
	$TeamItemCount[6 @ iHoverPad] = 0;
	$TeamItemCount[6 @ iChainTurret] = 0;
	$TeamItemCount[6 @ iNuclearWaste] = 0;
	$TeamItemCount[6 @ iBackupGenerator] = 0;
	$TeamItemCount[6 @ iShieldGenerator] = 0;
	$TeamItemCount[6 @ iFlagStand] = 0;
	$TeamItemCount[6 @ iTeleporter] = 0;
	$TeamItemCount[6 @ iAccelerator] = 0;
	$TeamItemCount[6 @ BomberVehicle] = 0;
	$TeamItemCount[6 @ FighterVehicle] = 0;
	$TeamItemCount[6 @ HelicopterVehicle] = 0;
	$TeamItemCount[6 @ TankVehicle] = 0;
	$TeamItemCount[6 @ APCVehicle] = 0;
	$TeamItemCount[6 @ OutriderVehicle] = 0;
	$TeamItemCount[6 @ SupplyVehicle] = 0;
	$TeamItemCount[6 @ CargoVehicle] = 0;


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
	// Specialist items
	$TeamItemCount[7 @ SpyCamera] = 0;
	$TeamItemCount[7 @ RemoteBomb] = 0;
	$TeamItemCount[7 @ Alarm] = 0;
	$TeamItemCount[7 @ CircuitExplosive] = 0;
	$TeamItemCount[7 @ RepairBot] = 0;
	$TeamItemCount[7 @ ForceShield] = 0;
	$TeamItemCount[7 @ CommSilencer] = 0;
	$TeamItemCount[7 @ Eavesdropper] = 0;
	$TeamItemCount[7 @ Loudmouth] = 0;
	$TeamItemCount[7 @ iSmokeTurret] = 0;
	$TeamItemCount[7 @ iFlakTurret] = 0;
	$TeamItemCount[7 @ iFlameTurret] = 0;
	$TeamItemCount[7 @ iPlasmaTurret] = 0;
	$TeamItemCount[7 @ iELFTurret] = 0;
	$TeamItemCount[7 @ iRocketTurret] = 0;
	$TeamItemCount[7 @ iMortarTurret] = 0;
	$TeamItemCount[7 @ iIndoorTurret] = 0;
	$TeamItemCount[7 @ iIonTurret] = 0;
	$TeamItemCount[7 @ iLaserTurret] = 0;
	$TeamItemCount[7 @ iTargetingTurret] = 0;
	$TeamItemCount[7 @ MotionSensor] = 0;
	$TeamItemCount[7 @ Camera] = 0;
	$TeamItemCount[7 @ SensorJammer] = 0;
	$TeamItemCount[7 @ iPulseSensor] = 0;
	$TeamItemCount[7 @ iEMPTurret] = 0;
	$TeamItemCount[7 @ iSmallForceField] = 0;
	$TeamItemCount[7 @ iForceField] = 0;
	$TeamItemCount[7 @ iBarricade] = 0;
	$TeamItemCount[7 @ iBlastWall] = 0;
	$TeamItemCount[7 @ iBlastPlatform] = 0;
	$TeamItemCount[7 @ iBlastCover] = 0;
	$TeamItemCount[7 @ iHoverPad] = 0;
	$TeamItemCount[7 @ iChainTurret] = 0;
	$TeamItemCount[7 @ iNuclearWaste] = 0;
	$TeamItemCount[7 @ iBackupGenerator] = 0;
	$TeamItemCount[7 @ iShieldGenerator] = 0;
	$TeamItemCount[7 @ iFlagStand] = 0;
	$TeamItemCount[7 @ iTeleporter] = 0;
	$TeamItemCount[7 @ iAccelerator] = 0;
	$TeamItemCount[7 @ BomberVehicle] = 0;
	$TeamItemCount[7 @ FighterVehicle] = 0;
	$TeamItemCount[7 @ HelicopterVehicle] = 0;
	$TeamItemCount[7 @ TankVehicle] = 0;
	$TeamItemCount[7 @ APCVehicle] = 0;
	$TeamItemCount[7 @ OutriderVehicle] = 0;
	$TeamItemCount[7 @ SupplyVehicle] = 0;
	$TeamItemCount[7 @ CargoVehicle] = 0;


	$totalNumCameras = 0;
	$totalNumSpyCameras = 0;
	$totalNumIonTurrets = 0;
	$totalNumSmokeTurrets = 0;
	$totalNumFlakTurrets = 0;
	$totalNumFlameTurrets = 0;
	$totalNumPlasmaTurrets = 0;
	$totalNumELFTurrets = 0;
	$totalNumRocketTurrets = 0;
	$totalNumMortarTurrets = 0;
	$totalNumIndoorTurrets = 0;
	$totalNumLaserTurrets = 0;
	$totalNumTargetingTurrets = 0;
	$totalNumEMPTurrets = 0;
	$totalNumChainTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
