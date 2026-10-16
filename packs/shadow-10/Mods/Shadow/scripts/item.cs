//----------------------------------------------------------------------------

$ItemFavoritesKey = "SHaDoW";  // Change this if you add new items
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

$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[Shotgun] = True;
$AutoUse[Mortar] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[TimedGrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EMPRocket] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;

$Use[Blaster] = True;

$ArmorType[Male, SoulArmor] = larmor;
$ArmorType[Male, GhostArmor] = marmor;
$ArmorType[Male, DemonArmor] = harmor;
$ArmorType[Female, SoulArmor] = lfemale;
$ArmorType[Female, GhostArmor] = mfemale;
$ArmorType[Female, DemonArmor] = harmor;

$ArmorName[larmor] = SoulArmor;
$ArmorName[marmor] = GhostArmor;
$ArmorName[harmor] = DemonArmor;
$ArmorName[lfemale] = SoulArmor;
$ArmorName[mfemale] = GhostArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[ShotgunShells] = 80;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[TimedGrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[HandgrenadeAmmo] = 5;
$SellAmmo[ConcussiongrenadeAmmo] = 5;
$SellAmmo[FlashgrenadeAmmo] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[ShotgunShells] = 20;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[TimedGrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = ShotgunShells;
$AmmoPackItems[3] = DiscAmmo;
$AmmoPackItems[4] = GrenadeAmmo;
$AmmoPackItems[5] = TimedGrenadeAmmo;
$AmmoPackItems[6] = Grenade;
$AmmoPackItems[7] = MineAmmo;
$AmmoPackItems[8] = MortarAmmo;
$AmmoPackItems[9] = Beacon;

$Grenade[0] = 3;
$Grenade[1] = HandgrenadeAmmo;
$Grenade[2] = ConcussiongrenadeAmmo;
$Grenade[3] = FlashgrenadeAmmo;

$Mine[0] = 3;
$Mine[1] = OriginalMineAmmo;
$Mine[2] = EMPMineAmmo;
$Mine[3] = StickyMineAmmo;

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[LaserPack] = 4;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[MineAmmo] = 35;

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
$WeaponAmmo[Shotgun] = ShotgunShells;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[TimedGrenadeLauncher] = TimedGrenadeAmmo;
$WeaponAmmo[Mortar] = MortarAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EMPRocket] = "";
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
						Player::decItemCount(%client,"LaserRifle");
						%gun=LaserRifle;
						teamEnergyBuySell(%player, %gun.price);
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
		else if(%item.className == Grenade)
		{
			if(checkResources(%player,%item,1))
			{

				for(%i = 1; %i <= $Grenade[0]; %i++)
				{
					%g = $Grenade[%i];
					if(%item == %g) {}
					else
					{
						teamEnergyBuySell(%player,%g.price * Player::getItemCount(%player, %g));
						Player::setItemCount(%player, %g, 0);
					}
				}
				%max = $ItemMax[%armor, %item];
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
					%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,Grenade, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}

		}
		else if(%item.className == Mine)
		{
			if(checkResources(%player,%item,1))
			{
				for(%i = 1; %i <= $Mine[0]; %i++)
				{
					%m = $Mine[%i];
					if(%item == %m) {}
					else
					{
						teamEnergyBuySell(%player,%m.price * Player::getItemCount(%player, %m));
						Player::setItemCount(%player, %m, 0);
					}
				}
				%max = $ItemMax[%armor, %item];
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
					%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,MineAmmo, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
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
					Player::decItemCount(%client,"LaserRifle");
					%gun=LaserRifle;
					teamEnergyBuySell(%player, %gun.price);
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

function remoteDeployItem(%client,%type)
{
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

//
$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Shotgun;
$NextWeapon[Shotgun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = TimedGrenadeLauncher;
$NextWeapon[TimedGrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = EMPRocket;
$NextWeapon[EMPRocket] = EnergyRifle;

$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Shotgun] = PlasmaGun;
$PrevWeapon[Chaingun] = Shotgun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[TimedGrenadeLauncher] = GrenadeLauncher;
$PrevWeapon[Mortar] = TimedGrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[EMPRocket] = LaserRifle;
$PrevWeapon[EnergyRifle] = EMPRocket;

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

ItemData SoulArmor
{
   heading = "aArmor";
	description = "Soul Armor";
	className = "Armor";
	price = 175;
};

ItemData GhostArmor
{
   heading = "aArmor";
	description = "Ghost Armor";
	className = "Armor";
	price = 250;
};

ItemData DemonArmor
{
   heading = "aArmor";
	description = "Demon Armor";
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
	shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
	heading = "bWeapons";
	description = "Blaster";
	className = "Weapon";
	shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Blaster");
}

//----------------------------------------------------------------------------

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
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

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
	description = "Chaingun";
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

function Chaingun::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Chaingun");
}

function Chaingun::checkNeedRefill(%player,%imageSlot,%curAmmo)
{
	if(%curAmmo == Player::getItemCount(%player,BulletAmmo))
		Chaingun::refill(%player,%imageSlot);
}

function Chaingun::refill(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if(Player::getMountedItem(%player, %imageSlot) != Chaingun && Player::getItemCount(%player,BulletAmmo) < $ItemMax[%armor, BulletAmmo]) {
			Player::incItemCount(%player,BulletAmmo);
			schedule("Chaingun::refill(" @ %player @ "," @ %imageSlot @ ");", 0.75);
	}
}

function Chaingun::onUnmount(%player,%imageSlot)
{
	%curAmmo = Player::getItemCount(%player,BulletAmmo);
	schedule("Chaingun::checkNeedRefill(" @ %player @ "," @ %imageSlot @ "," @ %curAmmo @ ");", 1.75);
}


//----------------------------------------------------------------------------

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
	fireTime = 0.5;

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

function PlasmaGun::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Plasma Gun");
}

function PlasmaGun::checkNeedRefill(%player,%imageSlot,%curAmmo)
{
	if(%curAmmo == Player::getItemCount(%player,PlasmaAmmo))
		PlasmaGun::refill(%player,%imageSlot);
}

function PlasmaGun::refill(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if(Player::getMountedItem(%player, %imageSlot) != PlasmaGun && Player::getItemCount(%player,PlasmaAmmo) < $ItemMax[%armor, PlasmaAmmo]) {
			Player::incItemCount(%player,PlasmaAmmo);
			schedule("PlasmaGun::refill(" @ %player @ "," @ %imageSlot @ ");", 1.5);
	}
}

function PlasmaGun::onUnmount(%player,%imageSlot)
{
	%curAmmo = Player::getItemCount(%player,PlasmaAmmo);
	schedule("PlasmaGun::checkNeedRefill(" @ %player @ "," @ %imageSlot @ "," @ %curAmmo @ ");", 2.5);
}


//----------------------------------------------------------------------------

ItemData ShotgunShells
{
	description = "Shotgun Shells";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = ShotgunShells;
	reloadTime = 0.99;
	accuFire = true;
	fireTime = 0.01;
	sfxFire = SoundFireShotgun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundPickUpWeapon; //SoundMortarReload;
	sfxReady = SoundPickUpWeapon;
};

ItemData Shotgun
{
	heading = "bWeapons";
	description = "Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "ammopack";
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	price = 85;
	showWeaponBar = true;
};

function Shotgun::Fire::Volley(%trans,%player,%vel)
{
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
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
        Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
}

function ShotgunImage::onFire(%player, %slot)
{
	Player::decItemCount(%player,ShotgunShells,1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Shotgun::Fire::Volley(%trans,%player,%vel);
}

function Shotgun::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Shotgun");
}

function Shotgun::checkNeedRefill(%player,%imageSlot,%curAmmo)
{
	if(%curAmmo == Player::getItemCount(%player,ShotgunShells))
		Shotgun::refill(%player,%imageSlot);
}

function Shotgun::refill(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if(Player::getMountedItem(%player, %imageSlot) != Shotgun && Player::getItemCount(%player,ShotgunShells) < $ItemMax[%armor, ShotgunShells]) {
		Player::incItemCount(%player,ShotgunShells);
		schedule("Shotgun::refill(" @ %player @ "," @ %imageSlot @ ");", 3);
	}
}

function Shotgun::onUnmount(%player,%imageSlot)
{
	%curAmmo = Player::getItemCount(%player,ShotgunShells);
	schedule("Shotgun::checkNeedRefill(" @ %player @ "," @ %imageSlot @ "," @ %curAmmo @ ");", 4);
}


//----------------------------------------------------------------------------

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
	reloadTime = 0.5;
	fireTime = 0.5;

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

function GrenadeLauncher::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Grenade Launcher");
}

function GrenadeLauncher::checkNeedRefill(%player,%imageSlot,%curAmmo)
{
	if(%curAmmo == Player::getItemCount(%player,GrenadeAmmo))
		GrenadeLauncher::refill(%player,%imageSlot);
}

function GrenadeLauncher::refill(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if(Player::getMountedItem(%player, %imageSlot) != GrenadeLauncher && Player::getItemCount(%player,GrenadeAmmo) < $ItemMax[%armor, GrenadeAmmo]) {
			Player::incItemCount(%player,GrenadeAmmo);
			schedule("GrenadeLauncher::refill(" @ %player @ "," @ %imageSlot @ ");", 3.5);
	}
}

function GrenadeLauncher::onUnmount(%player,%imageSlot)
{
	%curAmmo = Player::getItemCount(%player,GrenadeAmmo);
	schedule("GrenadeLauncher::checkNeedRefill(" @ %player @ "," @ %imageSlot @ "," @ %curAmmo @ ");", 4.5);
}


//----------------------------------------------------------------------------

ItemData TimedGrenadeAmmo
{
	description = "Timed Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData TimedGrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountRotation = { 0,3.14, 0 };

	weaponType = 0; // Single Shot
	ammoType = TimedGrenadeAmmo;
	projectileType = TimedGrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData TimedGrenadeLauncher
{
	description = "Timed Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TimedGrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
	validateShape = true;
};

function TimedGrenadeLauncher::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Timed Grenade Launcher");
}

function TimedGrenadeLauncher::checkNeedRefill(%player,%imageSlot,%curAmmo)
{
	if(%curAmmo == Player::getItemCount(%player,TimedGrenadeAmmo))
		TimedGrenadeLauncher::refill(%player,%imageSlot);
}

function TimedGrenadeLauncher::refill(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if(Player::getMountedItem(%player, %imageSlot) != TimedGrenadeLauncher && Player::getItemCount(%player,TimedGrenadeAmmo) < $ItemMax[%armor, TimedGrenadeAmmo]) {
			Player::incItemCount(%player,TimedGrenadeAmmo);
			schedule("TimedGrenadeLauncher::refill(" @ %player @ "," @ %imageSlot @ ");", 3.5);
	}
}

function TimedGrenadeLauncher::onUnmount(%player,%imageSlot)
{
	%curAmmo = Player::getItemCount(%player,TimedGrenadeAmmo);
	schedule("TimedGrenadeLauncher::checkNeedRefill(" @ %player @ "," @ %imageSlot @ "," @ %curAmmo @ ");", 4.5);
}


//----------------------------------------------------------------------------

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
	reloadTime = 0.5;
	fireTime = 2.0;

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

function Mortar::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Mortar");
}

function Mortar::checkNeedRefill(%player,%imageSlot,%curAmmo)
{
	if(%curAmmo == Player::getItemCount(%player,MortarAmmo))
		Mortar::refill(%player,%imageSlot);
}

function Mortar::refill(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if(Player::getMountedItem(%player, %imageSlot) != Mortar && Player::getItemCount(%player,MortarAmmo) < $ItemMax[%armor, MortarAmmo]) {
			Player::incItemCount(%player,MortarAmmo);
			schedule("Mortar::refill(" @ %player @ "," @ %imageSlot @ ");", 5);
	}
}

function Mortar::onUnmount(%player,%imageSlot)
{
	%curAmmo = Player::getItemCount(%player,MortarAmmo);
	schedule("Mortar::checkNeedRefill(" @ %player @ "," @ %imageSlot @ "," @ %curAmmo @ ");", 6);
}


//----------------------------------------------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function DiscLauncher::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Disc Launcher");
}

function DiscLauncher::checkNeedRefill(%player,%imageSlot,%curAmmo)
{
	if(%curAmmo == Player::getItemCount(%player,DiscAmmo))
		DiscLauncher::refill(%player,%imageSlot);
}

function DiscLauncher::refill(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if(Player::getMountedItem(%player, %imageSlot) != DiscLauncher && Player::getItemCount(%player,DiscAmmo) < $ItemMax[%armor, DiscAmmo]) {
			Player::incItemCount(%player,DiscAmmo);
			schedule("DiscLauncher::refill(" @ %player @ "," @ %imageSlot @ ");", 3);
	}
}

function DiscLauncher::onUnmount(%player,%imageSlot)
{
	%curAmmo = Player::getItemCount(%player,DiscAmmo);
	schedule("DiscLauncher::checkNeedRefill(" @ %player @ "," @ %imageSlot @ "," @ %curAmmo @ ");", 4);
}


//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
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
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Laser Rifle.");
}

function LaserRifle::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Laser Rifle");
}

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
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

function TargetingLaser::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Targeting Laser");
}

//----------------------------------------------------------------------------
ItemImageData EMPRocketImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0,3.14, 0 };
	weaponType = 0; // Single Shot
	projectileType = EMPulse;
	accuFire = true;
	reloadTime = 0.3;
	fireTime = 1.0;
	minEnergy = 30;
	maxEnergy = 35;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundEMPRocketFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundEMPRocketReload;
};

ItemData EMPRocket
{
	description = "EMP Rocket";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = EMPRocketImage;
	price = 150;
	showWeaponBar = true;
};

function EMPRocket::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	if(!%client.firstSpawn)
		Bottomprint(%client, "EMP Rocket");
}


//------------------------------------------------------------------------------

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

function EnergyRifle::onMount(%player,%item)
{
  %client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "ELF Gun");
}

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

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
  	%client = Player::getClient(%player);
	if(!%client.firstSpawn)
		  Bottomprint(%client, "Repair Gun");
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


//----------------------------------------------------------------------------

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


//----------------------------------------------------------------------------

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


//----------------------------------------------------------------------------

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


//----------------------------------------------------------------------------

ItemImageData LessWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -4.0;
};

ItemData LessWeight
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = LessWeightImage;
	price = 0;
	showWeaponBar = false;
	mass = -4.0;
	showInventory = false;
};

function LessWeight::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	%armor = Player::getArmor(%player);
	%item.imageType.mass = %armor.mass / 4 * -1;
}

function LessWeight::onDrop(%player, %item)
{}

ItemImageData LessWeight2Image
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -7.0;
};

ItemData LessWeight2
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = LessWeight2Image;
	price = 0;
	showWeaponBar = false;
	mass = -4.0;
	showInventory = false;
};

function LessWeight2::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	%armor = Player::getArmor(%player);
	%item.imageType.mass = %armor.mass * -2;
}

function LessWeight2::onDrop(%player, %item)
{}

//----------------------------------------------------------------------------

ItemImageData WingedPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0.2 };
	mountRotation = { 0,3.14, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
	mass = 0;
};

ItemData WingedPack
{
	description = "Winged Pack";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = WingedPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
	validateMaterials = true;
};

function WingedPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function WingedPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	Player::mountItem(%player,LessWeight, 4);
}

//----------------------------------------------------------------------------

ItemImageData HoverPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.2 };
	mountRotation = { 0,3.14, 0.1 };
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
	mass = 0;
};

ItemData HoverPack
{
	description = "Hover Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = HoverPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
	validateMaterials = true;
};

function HoverPackImage::onActivate(%player,%imageSlot)
{
	HoverPackImage::hover(%player,%imageSlot);
	GameBase::setRechargeRate(%player,0);
}

function HoverPackImage::hover(%player,%imageSlot)
{
	if(Player::isTriggered(%player, %imageSlot)) {
		if(Player::isJetting(%player))
			HoverPackImage::onDeactivate(%player,%imageSlot);
		else {
			item::setVelocity(%player, "0 0 0");
			Player::mountItem(%player,LessWeight2, 4);
		}
	}
}

function HoverPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player,8);
}

function HoverPack::onUnmount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------

ItemImageData AntiELFPackImage
{
	shapeFile = "sensorjampack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0.2 };
	mountRotation = { 0,3.14, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData AntiELFPack
{
	description = "Anti-ELF Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = AntiELFPackImage;
	price = 150;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
	validateShape = true;
	validateMaterials = true;
};

function AntiELFPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function AntiELFPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//----------------------------------------------------------------------------

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
	//mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

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
		for(%i = 0; %i < 12 ; %i = %i +1) {
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
	 	    		%item.ShotgunShells = %numPack;
			}
			else if(%i == 3) {
	 	    		%item.DiscAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    		%item.GrenadeAmmo = %numPack;
			}
			else if(%i == 5) {
	 	    		%item.TimedGrenadeAmmo = %numPack;
			}
			else if(%i == 6) {
	 	    		%item.Grenade = %numPack;
			}
			else if(%i == 7) {
				%item.MineAmmo = %numPack;
			}
			else if(%i == 8) {
				%item.MortarAmmo = %numPack;
			}
			else {
				%item.Beacon = %numPack;
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
	 	    	%item.BulletAmmo = %numPack;
		}
		else if(%i == 1) {
	 	    	%item.PlasmaAmmo = %numPack;
		}
		else if(%i == 2) {
	 	    	%item.ShotgunShells = %numPack;
		}
		else if(%i == 3) {
	 	    	%item.DiscAmmo = %numPack;
		}
		else if(%i == 4) {
	 	    	%item.GrenadeAmmo = %numPack;
		}
		else if(%i == 5) {
	 	    	%item.TimedGrenadeAmmo = %numPack;
		}
		else if(%i == 6) {
	 	    	%item.Grenade = %numPack;
		}
		else if(%i == 7) {
			%item.MineAmmo = %numPack;
		}
		else if(%i == 8) {
			%item.MortarAmmo = %numPack;
		}
		else {
			%item.Beacon = %numPack;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 12 ; %i = %i +1) {
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
	description = "Remote Turret";
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

ItemImageData LaserPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LaserPack
{
	description = "Laser Turret";
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
};

function LaserPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserPack::onDeploy(%player,%item,%pos)
{
	if (LaserPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function LaserPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
			%obj = getObjectType($los::object);
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
					%camera = newObject("Camera","Turret",DeployableLaser,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                              Client::setOwnedObject(%client, %camera);
                              Client::setOwnedObject(%client, %player);
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
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
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "gMiscellany";
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


//----------------------------------------------------------------------------

ItemData MineAmmo
{
	showInventory = false;
	description = "Mine";
	shapeFile = "mineammo";
	//heading = "eMines";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

ItemData OriginalMineAmmo
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = "eMines";
	shadowDetailMask = 4;
	price = 10;
	className = "Mine";
};

ItemData EMPMineAmmo
{
	description = "EMP Mine";
	shapeFile = "mineammo";
	heading = "eMines";
	shadowDetailMask = 4;
	price = 10;
	className = "Mine";
};

ItemData StickyMineAmmo
{
	description = "Sticky Mine";
	shapeFile = "mineammo";
	heading = "eMines";
	shadowDetailMask = 4;
	price = 10;
	className = "Mine";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			if(Player::getItemCount(%player, OriginalMineAmmo))
			{
				%name = "AntipersonelMine";
				%item = OriginalMineAmmo;
			}
			else if(Player::getItemCount(%player, EMPMineAmmo))
			{
				%name = "EMPMine";
				%item = EMPMineAmmo;
			}
			else if(Player::getItemCount(%player, StickyMineAmmo))
			{
				%name = "StickyMine";
				%item = StickyMineAmmo;
			}
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, MineAmmo);
			%obj = newObject("","Mine",%name);
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam(%obj,GameBase::getTeam(%client));
		}
	}
}


//----------------------------------------------------------------------------

ItemData Grenade
{
	showInventory = false;
	description = "Grenade";
	shapeFile = "breath";
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
	validateShape = true;
	validateMaterials = true;
};

ItemData HandgrenadeAmmo
{
	description = "Grenade";
	shapeFile = "grenade";
	heading = "fGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
	validateShape = true;
	validateMaterials = true;
};

ItemData ConcussiongrenadeAmmo
{
	description = "Concussion Grenade";
	shapeFile = "grenade";
	heading = "fGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
	validateShape = true;
	validateMaterials = true;
};

ItemData FlashgrenadeAmmo
{
	description = "Flash Grenade";
	shapeFile = "grenade";
	heading = "fGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
	validateShape = true;
	validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			if(Player::getItemCount(%player, HandgrenadeAmmo) > 0) {
				%item = HandgrenadeAmmo;
				%name = "Handgrenade";
			}
			else if(Player::getItemCount(%player, ConcussiongrenadeAmmo) > 0) {
				%item = ConcussiongrenadeAmmo;
				%name = "Concussiongrenade";
			}
			else if(Player::getItemCount(%player, FlashgrenadeAmmo) > 0) {
				%item = FlashgrenadeAmmo;
				%name = "Flashgrenade";
			}
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
			%armor = Player::getArmor(%player);
			%obj = newObject("","Mine",%name);
 	 	 	addToSet("MissionCleanup", %obj);
 	 	 	%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "gMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Beacon::onUse(%player,%item)
{
	if (Beacon::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
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
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "gMiscellany";
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
		Player::setItemCount(%clientId,TimedGrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EMPRocket,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,Mortar,1);

		Player::setItemCount(%clientId,Grenade, 200);
		Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);

		Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, HandgrenadeAmmo]);
		Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, ConcussiongrenadeAmmo]);
		Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, FlashgrenadeAmmo]);
		Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, OriginalMineAmmo]);
		Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, EMPMineAmmo]);
		Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, StickyMineAmmo]);
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
