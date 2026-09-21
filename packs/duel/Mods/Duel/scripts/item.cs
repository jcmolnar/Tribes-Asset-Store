//exec("elevator code");
//----------------------------------------------------------------------------

$ItemFavoritesKey = "";  // Change this if you add new items
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
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;

%a=0;
$myguns[%a] = "CloneGun";
$myguns[%a++] = "GateGun";
$myguns[%a++] = "Grabbler";
$myguns[%a++] = "Orbital1";
$myguns[%a++] = "Flaggy";
$myguns[%a++] = "MotherOfGod";
$myguns[%a++] = "SlowBouncy";
$myguns[%a++] = "Bouncy";
$myguns[%a++] = "LeGun";
$myguns[%a++] = "LeNade";
$myguns[%a++] = "Sweeper";
$myguns[%a++] = "ThreeG";
$myguns[%a++] = "EveryGun";
$myguns[%a++] = "TreeGun";
$myguns[%a++] = "WeedEater";
$myguns[%a++] = "FireWorksGun";
$myguns[%a++] = "Halo";
$myguns[%a++] = "ScoutSeeka";
$myguns[%a++] = "PlasSeeka";
$myguns[%a++] = "DiscSeeka";
$myguns[%a++] = "Themrtwig";
$myguns[%a++] = "Thebigtwig";
function registerweapons()
{
	for(%i= 0 ; $myguns[%i] != ""; %i++)
	{
		//echo("Setting up guns..");
		$AutoUse[$myguns[%i]] = True;
		$ItemMax[larmor, $myguns[%i]] = 1;
		$ItemMax[marmor, $myguns[%i]] = 1;
		$ItemMax[harmor, $myguns[%i]] = 1;
		$ItemMax[lfemale, $myguns[%i]] = 1;
		$ItemMax[mfemale, $myguns[%i]] = 1;
		$ItemMax[Aarmor, $myguns[%i]] = 1;
		$ItemMax[Barmor, $myguns[%i]] = 1;
		$ItemMax[LestatArmor, $myguns[%i]] = 1;
		$ItemMax[LestatArmor, $myguns[%i]] = 1;
		$ItemMax[PeachMachine, $myguns[%i]] = 1;
		if($myguns[%i] != "Orbital1" && $myguns[%i] != "MotherOfGod" && $myguns[%i] != "Grabbler" && $myguns[%i] != "SlowBouncy" && $myguns[%i] != "Halo" && $myguns[%i] != "Halo")
		{
			$RemoteInvList[$myguns[%i]] = 1;
		}
		else {
			$RemoteInvList[$myguns[%i]] = false;
		}
	}
}
registerweapons();



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
$TeamItemMax[TurretPack] = 10*10;
$TeamItemMax[CameraPack] = 15*10;
$TeamItemMax[DeployableSensorJammerPack] = 8*10;
$TeamItemMax[PulseSensorPack] = 15*10;
$TeamItemMax[MotionSensorPack] = 15*10;
$TeamItemMax[ScoutVehicle] = 3*10;
$TeamItemMax[HAPCVehicle] = 1*10;
$TeamItemMax[LAPCVehicle] = 2*10;
$TeamItemMax[Beacon] = 400;
$TeamItemMax[mineammo] = 35;
$TeamItemMax[LaserRifle] = 2;

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
$WeaponAmmo[DiscLauncherBlue] = DiscAmmo;
$WeaponAmmo[DiscLauncherGreen] = DiscAmmo;
$WeaponAmmo[DiscLauncherKing] = DiscAmmo;
$WeaponAmmo[DiscLauncherYellow] = DiscAmmo;
$WeaponAmmo[DiscLauncherPink] = DiscAmmo;
$WeaponAmmo[DiscLauncherBlack] = DiscAmmo;
$WeaponAmmo[DiscLauncherPurple] = DiscAmmo;
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
						if(%item == "LaserRifle" && %client.dm != "true")
						{
							$TeamItemCount[%client.team, LaserRifle]--;
						}
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
		if(%item == "LaserRifle" && %client.dm!="true")
		{
			if($TeamItemMax[%item] <= $TeamItemCount[%client.team, %item])
			{
				Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
				return 0;
			}
		}
  	}
	else if(%item == RepairPatch) {
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0)
			return 1;
		return 0;
   }
   else if($TeamItemMax[%item] != "" && !$TestCheats && %client.dm != "true") {
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
			if(checkResources(%player,%item,1))
			{
				if(%item == LaserRifle)
				{
					if(Player::getItemCount(%client,"EnergyPack") == 0)
					{
						buyItem(%client,"EnergyPack");
						Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
					}

					echo("Laser Bought... "@%client.team@" "@$TeamItemCount[%client.team, %item]);

					if(%client.dm != "true")
						$TeamItemCount[%client.team, %item]++;
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
	%player = Client::getOwnedObject(%client);
	TwoThirtySeven(%player);
	%client.LastAction = floor(getSimTime());
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
	%client.LastAction = floor(getSimTime());
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
				if(%item.className == Vehicle || %item == "LaserRifle" && %client.dm != "true")
					$TeamItemCount[%client.team, %item]--;
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
	%client.LastAction = floor(getSimTime());
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
	%client.LastAction = floor(getSimTime());
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

//
$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = EnergyRifle;

$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[EnergyRifle] = LaserRifle;
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
				if(%item.description == "Repair Kit")
				{
					%playtype = GetPlayType(%client);
					Score::IncreaseStat(%client, "KitsPickedUp", 1, %playType);
				}
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
		%this.pos = gamebase::getposition(%this);
		//Item::hide(%this,True);
		gamebase::setposition(%this, getword(%this.pos, 0)@" "@getword(%this.pos, 1)@" "@getword(%this.pos, 2)-200);
		schedule("gamebase::setposition("@%this@",\""@%this.pos@"\");",$ItemRespawnTime,%this);
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
	%armor = Player::getArmor(%object);
	//echo("Item Max "@$ItemMax[%armor, Item::getItemData(%this)]@" ItemData: "@Item::getItemData(%this)@" Armor: "@%armor@" obj: "@%object@" this: "@%this);

	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{

			if(Item::getItemData(%this) == "RepairKit")
			{
				if(%this.owner != %object.owner)
				{
					%PlayType = GetPlayType(%this.owner);
					if((gamebase::getteam(%this.owner) != gamebase::Getteam(%object.owner) || %this.owner.DM) && %this.owner != "")
					{
						Score::IncreaseStat(%this.owner, "KitsGivenToEnemy", 1, %PlayType);
						Score::IncreaseStat(%object.owner, "KitsReceivedFromEnemy", 1, %PlayType);
					}
					else
					{
						if(!%this.owner.DM && %this.owner != "")
						{
							Score::IncreaseStat(%this.owner, "KitsGivenToAlly", 1, %PlayType);
							Score::IncreaseStat(%object.owner, "KitsReceivedFromAlly", 1, %PlayType);
						}
					}
				}
			}
			Item::playPickupSound(%this);
			Item::respawn(%this);
			%object.droppeditems--;
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
			echo("Item dropped: ",%player," ",%item);
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
			%obj.owner = %player.owner;
			if(%item == "RepairKit")
			{
				Score::IncreaseStat(%player.owner, "KitsDropped", 1, GetPlayType(%obj.owner));
			}
			TwoThirtySeven(%player);
			return %obj;
		}
	}
}//
function TwoThirtySeven(%player)
{
	%player.droppeditems++;
	echo(%player.droppeditems);
	//both("Tracking... "@%player.droppeditems);
	if(%player.droppeditems < 200)
	{
		%player.droppeditemsmax = false;
	}
	if(%player.droppeditems > 300 && %player.droppeditemsmax != "true")
	{
		%player.droppeditems = 0;
		%player.droppeditemsmax = true;
		%client = Player::getClient(%player);
		%client.private=true;
		Client::setGuiMode(%client, $GuiModePlay);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.observerTarget == %client)
			{
				Observer::nextObservable(%cl);
			}
		}
		projectload(%client, "PrisonXXX");


		%client.workingproject = "";
		%client.projectname = "";
		schedule("gamebase::setposition("@%client@", \"-3090.5 3092.5 162.075\");",0.5);
		//schedule("ban("@%client@", \"Permanent\");",1);
		//gamebase::setposition(%player, "-3090.5 3092.5 162.075");
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
   validateShape = false;

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
			TwoThirtySeven(%player);
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
   validateShape = false;
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};


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
   validateShape = false;
};


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
   validateShape = false;
};


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
   validateShape = false;
};


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
   validateShape = false;
   validateMaterials = false;
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Laser Rifle.");
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
   validateShape = false;
};

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
   validateShape = false;
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
   validateShape = false;
   validateMaterials = false;
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
   validateShape = false;
   validateMaterials = false;
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
   validateShape = false;
   validateMaterials = false;
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
   validateShape = false;
   validateMaterials = false;
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
//   mountRotation = { 1.57, 0, 0 };
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
   validateShape = false;
   validateMaterials = false;
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

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = false;
   validateMaterials = false;
};

function RepairKit::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	%playtype = GetPlayType(%client);
	Score::IncreaseStat(%client, "KitsConsumed", 1, %playType);

	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};



//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = false;
   validateMaterials = false;
};




//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = false;
   validateMaterials = false;
};

function Beacon::onUse(%player,%item)
{
	echo("Beacon use...");
	if (Beacon::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
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
   validateShape = false;
   validateMaterials = false;
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

//****************************************************************************
//****************************************************************************
//****************************************************************************
//****************************************************************************
//****************************************************************************
//Custom Items
//****************************************************************************
//****************************************************************************
//****************************************************************************
//****************************************************************************
//****************************************************************************


//****************************************************************************
//To Clean The Trees out
//****************************************************************************
ItemImageData WeedEaterImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.002;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet2;
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

ItemData WeedEater
{
	description = "Weed Eater";
	className     = "Tool";
	shapeFile = "chaingun";
   validateShape = false;
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = WeedEaterImage;
	price = 125;
	showWeaponBar = true;
};

function WeedEater::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Weed Eater is <F2>Equipped", 3);
}
//****************************************************************************
//Makes Trees for the Weed Eater To Clear ;)
//****************************************************************************
ItemImageData TreeGunImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = -10;
	maxEnergy = -10;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TreeGun
{
   heading = "bWeapons";
	description = "Tree Growth";
	className     = "Tool";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = TreeGunImage;
	price = 85;
	showWeaponBar = true;
};

function TreeGunImage::onFire(%player, %slot)
{
	%clientId = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,5000))
	{
	%obj = getObjectType($los::object);
	if (%obj == "")
	{
		return false;
	}
	else {
		if (Vector::dot($los::normal,"0 0 1") > 3.1)
		{
			%rot = "0 0 0";
		}
		else
		{
			if (Vector::dot($los::normal,"0 0 -1") > 3.1)
			{
				%rot = "3.14159 0 0";
			}
			else
			{
				%rot = Vector::getRotation($los::normal);
			}
		%NewTree = newObject("Static",StaticShape,TreeShape2,true);
		if(%clientId.workingproject)
		{
			%NewTree.project = %clientId.projectname ;
			addToSet("BuildGroup", %NewTree);
		}
		else {
			addToSet("MissionCleanup", %NewTree);
		}

		GameBase::setTeam(%NewTree,GameBase::getTeam(%player));
		GameBase::setRotation(%NewTree,%rot);
		GameBase::setPosition(%NewTree,$los::position);
		Gamebase::setMapName(%NewTree,"Tree");

		//schedule("TreeKill(" @ %NewTree @ ");", 500.5);
		}
		}
	}
}

function TreeKill(%NewTree)
{
	if(Object::getName(%NewTree) == "Static")
	{
		%type = $PlasmaDamageType;
		%pos = Gamebase::getPosition(%NewTree);
		%vec = GameBase::getRotation(%NewTree);
		%mom = "0 0 0";
		schedule("StaticShape::onDamage(" @ %NewTree @ ",%type,1.05,%pos,%vec,%mom,%NewTree);",0.5);
	}
}

function TreeGun::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Tree Gun is <F2>Equipped", 3);
}
//****************************************************************************
//CLOOOOOOOOOOOOOOOOOOOOOONES
//****************************************************************************

ItemImageData CloneGunImage
{
   shapeFile  = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.0;
	minEnergy = -10;
	maxEnergy = -10;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData CloneGun
{
   heading = "bWeapons";
	description = "Clone Gun";
	className     = "Tool";
   shapeFile  = "mortargun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = CloneGunImage;
	price = 85;
	showWeaponBar = true;
};

function CloneGunImage::onFire(%player, %slot)
{
	%PreVelo = Item::getVelocity(%turret);
	%client = Player::getClient(%player);
	//Spawning Shit
	%type = Player::getArmor(%player);
	%rot = gamebase::getrotation(%player);
	%class="Player";
	%turret = newObject("Jesus",%class,%type,true);
	addToSet("MissionCleanup", %turret);
	Client::setSkin(%turret, cphoenix);
	//Setting up where it goes
	GameBase::getLOSinfo(%player, 300);
	%test = $los::normal;
	//messageall(1, %test);
	%playerloc = gamebase::getposition(%player);
	gamebase::setposition(%turret, %playerloc);
	gamebase::setrotation(%turret, %rot);
	//knock the player back..
	%b = GameBase::getRotation(%player);
	%c1 = -400;
	%c2 = 0.0;
	%mom = Vector::getFromRot( %b, %c1, %c2 );
	Player::applyImpulse(%player, %mom);
	//Making it move...
	%b = GameBase::getRotation(%player);
	%c1 = 500;
	//messageall(0, %c1);
	%c2 = %c1 / 2.7;
	%mom = Vector::getFromRot( %b, %c1, %c2 );
	Player::applyImpulse(%turret, %mom);
	%client = Player::getClient(%player);
	item::pop(%player);
	Player::useItem(%player,Blaster);
	ControlIt(%player, %turret);

}
function ControlIt(%player, %turret)
{
	%client = Player::getClient(%player);
	schedule("Client::setControlObject(" @ %client @ ", " @ %turret @ ");", 0.3);
	schedule("Client::setOwnedObject(" @ %client @ ", " @ %turret @ ");", 0.2);
  	schedule("equiptime(" @ %client @ ");", 0.3);
  	schedule("Player::useItem(" @ %client @ ",CloneGun);", 0.2);
}

function CloneGun::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Clone Gun is <F2>Equipped", 3);
}
//****************************************************************************
//FIREWORKS!
//****************************************************************************
ItemImageData FireWorksGunImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FireWorksGun
{
   heading = "bWeapons";
	description = "Fireworks Gun";
	className     = "Tool";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FireWorksGunImage;
	price = 85;
	showWeaponBar = true;
};

function FireWorksGunImage::onFire(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("blastshot",%trans,%player,%vel);
	Projectile::spawnProjectile("blastshot2",%trans,%player,%vel);
	Projectile::spawnProjectile("sniperlaser2",%trans,%player,%vel);
	Projectile::spawnProjectile("sniperlaser3",%trans,%player,%vel);
	Projectile::spawnProjectile("GFFireFlames",%trans,%player,%vel);
	Projectile::spawnProjectile("GFFireFlames2",%trans,%player,%vel);
	Projectile::spawnProjectile("GFireFlamesBlank",%trans,%player,%vel);
	Projectile::spawnProjectile("GFireFlamesBlank2",%trans,%player,%vel);
}

function FireWorksGun::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Fire Works Gun is <F2>Equipped", 3);
}

//****************************************************************************
//Scout Seeker
//****************************************************************************
ItemImageData ScoutSeekaImage
{
   shapeFile  = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.6;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData ScoutSeeka
{
   heading = "bWeapons";
	description = "ScoutSeeka";
	className     = "Tool";
   shapeFile  = "mortargun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = ScoutSeekaImage;
	showWeaponBar = true;


};
function ScoutSeekaImage::onFire(%player, %slot)
{
	%target = "null";
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	resetlos();
	if(GameBase::getLOSInfo(%player, 2000))
	{
	    %object = getObjectType($los::object);
		if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape")
		{
	    	%obj = Projectile::spawnProjectile("ScoutSeek", %trans, %player, %vel, $los::object);
	    	%targetId = Gamebase::getOwnerClient($los::object);
	    	bottomprint(%clientId, "<F9>Target Locked", 3);
	    	%obj.target = $los::object;
		}
		if(%object == "SimTerrain" || %object == "InteriorShape")
		{
			%obj = Projectile::spawnProjectile("ScoutSeek", %trans, %player, %vel);
		}
	}
	else
	{
		%obj = Projectile::spawnProjectile("ScoutSeek", %trans, %player, %vel);
	}
	%obj.owner = %clientId;
	%obj.player = %player;

	ScoutFireAtTarget(%obj, 10);
	//ChangeVelocity(%obj);
}
function Seeka(%proj, %target)
{
	if(%target == "null")
	{
		%closest = "100";
		%closestcl = "";
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(Client::getOwnedObject(%cl) != -1)
			{
				%distance = Vector::getDistance(gamebase::getposition(%proj), GameBase::getPosition(Client::getOwnedObject(%cl)));
				%distancewithvelocity = Vector::getDistance(Vector::Add(gamebase::getposition(%proj), item::getvelocity(%proj)), GameBase::getPosition(Client::getOwnedObject(%cl)));
				//echo(client::getname(%cl)@" distance: "@%distance@" VelDistance: "@%distancewithvelocity);
				if(%distancewithvelocity < %distance && %distance < 400 && %closest > %distance && %cl != %proj.owner)
				{
					%closest = %distance;
					%closestcl = %cl;
					%proj.target = Client::getOwnedObject(%cl);
				}
			}
		}
		if(%closestcl != "")
		{

		}
	}
}
function ScoutFireAtTarget(%this, %counter)
{
	//both(%this@" count "@%counter);
	if(isobject(%this))
	{
		%pos = gamebase::getposition(%this);
		if(%this.target != "")
		{
			//gamebase::Getposition(%player);

			%pos2 = gamebase::getposition(%this.target);
			%distance = Vector::getDistance(%pos, %pos2);
			%rot = Vector::normalize(Vector::sub(%pos2, %pos));
			%trans = "0 0 1 "@%rot@" 0 0 1 "@%pos ;
			if(getObjectType(%this.target) == "Player")
			{
				%vel = item::getvelocity(%this.target);
			}
			else {
				%vel = item::getvelocity(%this);
			}
			%obj = Projectile::spawnProjectile(FlierRocket, %trans, %this.player, %vel);
		}
		//both("FAT"@Object::getName(%obj)@" a "@GameBase::getDataName(%obj)@" b "@GameBase::getMapName(%obj)@" c "@getObjectType(%my_object));

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			%clplayer = Client::getOwnedObject(%cl);
			if(%clplayer != -1 && %this.player != %clplayer)
			{
				%distance = Vector::getDistance(gamebase::getposition(%this), GameBase::getPosition(%clplayer));
				%distancewithvelocity = Vector::getDistance(Vector::Add(gamebase::getposition(%this), item::getvelocity(%this)), GameBase::getPosition(%clplayer));
				echo(%this.player@" "@client::getname(%cl)@" distance: "@%distance@" VelDistance: "@%distancewithvelocity);

				if(%distancewithvelocity < %distance && %distance < 400)
				{
					if(%closest > %distance)
					{
						%closest = %distance;
						%closestcl = %cl;
					}
					%rot = Vector::normalize(Vector::sub(GameBase::getPosition(%clplayer), %pos));//Vector::getRotation(


					%trans = "0 0 1 "@%rot@" 0 0 1 "@%pos;
					%vel = item::getvelocity(%clplayer);
					%obj = Projectile::spawnProjectile(FlierRocket, %trans, %this.player, %vel);

					resetlos();
					gamebase::getlosinfo(%obj, 400, "0 0 0");
					echo($los::object);
				}
			}
		}

		%counter++;
		//Projectile::spawnProjectile(DiscShell, %trans, %player, "0 0 0");
		//%obj = Projectile::spawnProjectile(FlierRocket, %trans, %this.player, %vel);
		schedule("ScoutFireAtTarget("@%this@","@%counter@");", 0.5, %this);
	}
}
function ChangeVelocity(%this)
{
   //Changing projectile speed. -Plasmatic
   %vel = Item::getVelocity(%this);
   %speed = vector::getdistance(%vel,"0 0 0");
   both(getlosinfo(vector::sub(gamebase::getposition(%this),"0 0 1"), 4, "1.57 0 0"));
   both(%vel@" "@%speed);
   if(%speed != 0 && %speed != "-NAN")
   {
      messageall(1,"vel ="@%speed);

      %x = 1.05;   //modifyer. >1 for faster, <1 to slow down.
      //Retardedly fast projectile speeds will lock up Tribes -Plasmatic

      %n = %speed * %x;   //calculate a new speed. This will be an exponential curve.

      %newspeed = vector::multiply(vector::normalize(%vel),%n@" "@%n@" "@%n);
      item::setvelocity(%this,%newSpeed);
      // Projectiles don't like going nowhere and get pissed off..
      // If this is 0 0 0, they will go boom. -Plasmatic
   }

   schedule("ChangeVelocity("@%this@");",0.1,%this);   // How often do we want to do this.
}
function ScoutSeeka::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Scout Seeka is <F2>Equipped", 3);
}
//****************************************************************************
//Plasma Seeker
//****************************************************************************
ItemImageData PlasSeekaImage
{
   shapeFile  = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.6;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasSeeka
{
   heading = "bWeapons";
	description = "PlasSeeka";
	className     = "Tool";
   shapeFile  = "plasma";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PlasSeekaImage;
	showWeaponBar = true;


};
function PlasSeeka::onFire(%player, %slot)
{
	if(GameBase::getLOSInfo(%player, 2000))
	{
	    %object = getObjectType($los::object);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(%object == "Player")
		{

			 %clientId = GameBase::getOwnerClient(%player);
			 %targetId = Gamebase::getOwnerClient($los::object);
			 bottomprint(%targetId, "<F9>Watch out!", 3);
			 bottomprint(%clientId, "<F9>Target Locked", 3);
	   		 Projectile::spawnProjectile("PlasSeek", %trans, %player, %vel, %object);
		}
		else
		{
	   		Projectile::spawnProjectile("PlasmaBolt", %trans, %player, %vel);
		}
	}
	resetlos();
}
function PlasSeeka::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Plas Seeka is <F2>Equipped", 3);
}
function PlasSeeka22Image::onFire(%player, %slot)
{
   if (Player::isTriggered(%player,$WeaponSlot))
   {
      %trans = GameBase::getMuzzleTransform(%player);
      %vel = Item::getVelocity(%player);
      %xrnd = (floor(getRandom() *21)-10)/100;
      %yrnd = (floor(getRandom() *21)-10)/100;
      %zrnd = (floor(getRandom() *21)-10)/100;

      %trans1= getWord(%trans,0);
      %trans2= getWord(%trans,1);
      %trans3= getWord(%trans,2);
      %trans4= getWord(%trans,3) + %xrnd;
      %trans5= getWord(%trans,4) + %yrnd;
      %trans6= getWord(%trans,5) + %zrnd;
      %trans7= getWord(%trans,6);
      %trans8= getWord(%trans,7);
      %trans9= getWord(%trans,8);
      %trans10=getWord(%trans,9);
      %trans11=getWord(%trans,10);
      %trans12=getWord(%trans,11);

      %NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;

      Projectile::spawnProjectile("PlasmaBolt", %NewTrans, %player, %vel);
  }
}
//****************************************************************************
//Disc Seeker
//****************************************************************************
ItemImageData DiscSeekaImage
{
   shapeFile  = "disc";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//reloadTime = 0;
	//fireTime = 1.75;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	reloadTime = 0.25;
	fireTime = 0.75;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscSeeka
{
	description = "DiscSeeka";
	className     = "Tool";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscSeekaImage;
	price = 85;
	showWeaponBar = true;
};

function DiscSeekaImage::onFire(%player, %slot)
{
	if(GameBase::getLOSInfo(%player, 2000))
	{
	    %object = getObjectType($los::object);

		if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "StaticShape")
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = item::getvelocity(%player);
	    	//Projectile::spawnProjectile("DiscSeek", %trans, %player, %vel, $los::object);
	    	%this =	Projectile::spawnProjectile("DiscShell", %trans, %player, %vel);
	    	%this.target = $los::object;
	    	%this.player = %player;
	    	%targetId = Gamebase::getOwnerClient($los::object);
			bottomprint(%targetId, "<F9>Watch out!", 3);
	    	%clientId = Player::getClient(%player);
	    	bottomprint(%clientId, "<F9>Target Locked", 3);
	    	schedule("ttransloop("@%this@",10);",1,%this);
	    	//schedule("SpiralLoop("@%this@",10);",1,%this);
		}
		if(%object == "SimTerrain" || %object == "InteriorShape" || %object == "StaticShape")
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			%this =	Projectile::spawnProjectile("DiscShell", %trans, %player, %vel);
			%this.target = $los::object;
			%this.pos = $los::position;
	    	%this.player = %player;

			schedule("ttransloop("@%this@",10);",1);
		}
	}
	else
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%this = Projectile::spawnProjectile("DiscShell", %trans, %player, %vel);
		%this.target = %player;
		%this.player = %player;

		schedule("ttransloop("@%this@",0);",1);
	}
}
function DiscSeeka::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Disc Seeka is <F2>Equipped", 3);
}
//****************************************************************************
//Didn't Make These
//****************************************************************************
function Admin::isMovingAllObject(%clientId)
{
    %bool = false;
    if(%clientId.isAdmin == true)
    {
        if(%clientId.isMovingAll == true)
            %bool = true;
    }
    return %bool;
}
function LayerSystem::isInLayerScope(%clientId, %obj)
{
    if(%obj.InLayer == %clientId.currLayer || %clientId.currLayer == -1 || Admin::isMovingAllObject(%clientId) == true)
        return true;
    return false;
}
function Vector::multiply(%vec1, %vec2)
{
    %vec1X = getWord(%vec1, 0);
    %vec1Y = getWord(%vec1, 1);
    %vec1Z = getWord(%vec1, 2);

    %vec2X = getWord(%vec2, 0);
    %vec2Y = getWord(%vec2, 1);
    %vec2Z = getWord(%vec2, 2);

    %vec3X = %vec1X * %vec2X;
    %vec3Y = %vec1Y * %vec2Y;
    %vec3Z = %vec1Z * %vec2Z;

    return %vec3X @ " " @ %vec3Y @ " " @ %vec3Z;
}

// Gate Gun
// By Plasamtic
// www.annihilation.info
//ICQ 77161332


$AutoUse[GateGun] = True;

//addWeapon(GateGun);
// new test weap for 3.x -plasmatic
//PopulateItemMax(GateGun,         1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);

ItemImageData GateGunImage
{
   shapeFile = "paintgun";   //shapeFile = "shotgun";
   mountPoint = 0;
   weaponType = 0;
//   ammoType = ShotgunShells;
   reloadTime = 0.38;
   accuFire = false;
   fireTime = 0.25;
//   sfxFire = SoundFireShotgun;
   sfxActivate = SoundPickUpWeapon;
};

ItemData GateGun
{
   description = "Heavens Gate";
	className     = "Tool";
   shapeFile = "paintgun";
   hudIcon = "targetlaser";
   heading = bWeapons;   //$InvHead[ihWea];   //3.0   //
   shadowDetailMask = 4;
   imageType = GateGunImage;
   price = 50;
   showWeaponBar = false;
};

function GateGun::MountExtras(%player,%weapon)
{
   %clientId = Player::getclient(%player);
   if(%clientId.weaponHelp)
      bottomprint(%clientId, "<jc>Heavens Gate: <f2>Open up a portal through Heaven.");
}

function GateGun::onUse(%player)
{
   Player::mountItem(%player,GateGun,0);
}


TriggerData PortalTrigger
{
   className = "portal";
   rate = 0.001;   //1.0;
};

function GateGunImage::onFire(%player, %slot)
{
   if($debug)
      echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));

   %client = GameBase::getControlClient(%player);

   if(GameBase::getLOSInfo(%player,1000))
   {
      // GetLOSInfo sets the following globals:
      //    los::position
      //    los::normal
      //    los::object
      %type = getObjectType($los::object);
//      messageall(1,%type);

      if(%type != "SimTerrain" && %type != "InteriorShape" && GameBase::getDataName($los::object) != "DeployablePlatform")
      {
      //   Client::sendMessage(%client,0,"Can only gate through terrain or buildings");
         return false;
      }
      else
      {

         //set us up the bomb 9/2/2007 12:17AM - Plasmatic
         %portalnum = %client.pcount + 1;
         //messageall(1,"pnum "@%portalnum);
         if(%portalnum>1)
            %portalnum = 0;
         %client.pcount = %portalnum;

         %p = %client.portal[%portalNum];
         if(GameBase::getDataName(%p) == portal)
         {
            %t = %p.trigger;
            deleteObject(%t);
            deleteObject(%p);
         }

         %trans = GameBase::getMuzzleTransform(%player);
         GameBase::playSound(%player, SoundEnergyTurretOff, 0);

            %d1= getWord(%trans,3);
            %d2= getWord(%trans,4);
            %d3= getWord(%trans,5);      //3,4,5 are dir vec -plas
            %GunRotVec = %d1 @" " @ %d2 @" " @ %d3;   //%d3 is up/ down

         %rot = Vector::getRotation($los::normal);
         %adj = $los::normal;
         %pos = vector::add($los::position,%adj);

         %exitVec = vector::normalize(vector::sub(%pos,$los::position));

         %Portal = newObject("", "StaticShape", "portal", true);
         addToSet("MissionCleanup", %Portal);
         GameBase::setTeam(%Portal,GameBase::getTeam(%player));
         GameBase::setRotation(%Portal,%rot);
         GameBase::setPosition(%Portal,%pos);

         GameBase::activateShield(%Portal,%GunRotVec,0);
         %Portal.vec = %adj;
         portal::animate(%Portal);

         %Trigger = newObject("","Trigger",PortalTrigger,true,"");
         addToSet("MissionCleanup", %Trigger);
         GameBase::setTeam(%Trigger,GameBase::getTeam(%player));
         GameBase::setRotation(%Trigger,%rot);
         GameBase::setPosition(%Trigger,%pos);

         %client.portal[%portalNum] = %Portal;
         %trigger.portal = %portal;
         %trigger.num = %portalNum;
         %trigger.client = %client;
         %trigger.exitVec = %exitVec;

         %portal.trigger = %trigger;

      }
   }
}

TriggerData WaypointTrigger
{

   className = "WP";
   rate = 0.001;   //1.0;
   boundingBox = "-10 -14 -4 10 14 4";
};

TriggerData NexusTrigger
{
   className = "Nexus";
   rate = 0.001;   //1.0;
};
// We may need some vector maths here... -Plasmatic
function PortalTrigger::onEnter(%trigger,%object)
{
   %type = getObjectType(%object);
   %lastportal = %object.lastportal;
   if((%type == "Player" || %type == "Grenade") && %lastportal != %trigger)
   {
      %object.wait = true;
      %rot = Vector::getRotation(%object);
      %vel = Item::getVelocity(%object);
      %speed = vector::getdistance("0 0 0",%vel);

      %client = %trigger.client;
      %portalNum = %trigger.num;
      %portal = %client.portal[%portalNum];

      %TriggerNumIn = %portalNum;
      %portalNum++;
      if(%portalNum >1)
         %portalNum = 0;

      %TriggerNumOut = %portalNum;
      %targetPortal = %client.portal[%portalNum];
      if(%targetPortal)
      {
         %targetTrigger = %targetportal.trigger;
         %object.lastportal = %targettrigger;
         schedule(%object@".lastportal = false;",0.5);

         %targetPos = gamebase::getposition(%targetTrigger);
         gamebase::setposition(%object,%targetPos);
         GameBase::playSound(%object, SoundMortarTurretOff, 0);
      //   playSound(SoundFireGrenade,GameBase::getPosition(%targetTrigger));

         %exitVec = %targettrigger.exitVec;
               %d1= getWord(%exitVec,0) * %speed;
               %d2= getWord(%exitVec,1) * %speed;
               %d3= getWord(%exitVec,2) * %speed;
               %exitVel =  %d1 @" " @ %d2 @" " @ %d3;

         Item::setVelocity(%object, %exitVel);
         %slope = getword(%exitvec,2);
         if(%slope > -0.6 && %slope < 0.6)
         {
            %exitrot = vector::getrotation(%exitvec);
            gamebase::setrotation(%object,"0 0 "@getword(%exitrot,2));
         }
      }
   }
}


function portal::animate(%this)
{
   %vec = %this.vec;
   if(%this.vec != "")
   {
      GameBase::activateShield(%this,%vec,0);
      schedule("portal::animate("@%this@");",0.5);
   }

}






// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------

$MovementMode::[0] = "Free Move";
$MovementMode::[1] = "Rotate X";
$MovementMode::[2] = "Rotate -X";
$MovementMode::[3] = "Rotate Y";
$MovementMode::[4] = "Rotate -Y";
$MovementMode::[5] = "Rotate Z";
$MovementMode::[6] = "Rotate -Z";
$MovementMode::[7] = "Move Forward";
$MovementMode::[8] = "Move Backward";
$MovementMode::[9] = "Move Left";
$MovementMode::[10] = "Move Right";
$MovementMode::[11] = "Move Up";
$MovementMode::[12] = "Move Down";
$MovementMode::[13] = "Flip X";
$MovementMode::[14] = "Flip Y";
$MovementMode::[15] = "Flip Z";
$MovementMode::[16] = "Radius Rotate X";
$MovementMode::[17] = "Radius Rotate -X";
$MovementMode::[18] = "Radius Rotate Y";
$MovementMode::[19] = "Radius Rotate -Y";
$MovementMode::[20] = "Radius Rotate Z";
$MovementMode::[21] = "Radius Rotate -Z";
$MovementMode::[22] = "Radius Move Forward";
$MovementMode::[23] = "Radius Move Backward";
$MovementMode::[24] = "Radius Move Left";
$MovementMode::[25] = "Radius Move Right";
$MovementMode::[26] = "Radius Move Up";
$MovementMode::[27] = "Radius Move Down";
$MovementMode::[28] = "Radius Flip X";
$MovementMode::[29] = "Radius Flip Y";
$MovementMode::[30] = "Radius Flip Z";
ItemImageData GrabblerImage
{
	shapeFile = "paintgun"; //"mortargun";
	mountPoint		= 0;
	mountOffset		= { -0.1, 0, 0 };
	mountRotation	= { 0, -2.75, 0};
    weaponType = 1;

    spinUpTime = 0.0;
    spinDownTime = 0.0;
    fireTime = 0.1;
    accuFire = true;

    minEnergy = 0;
	maxEnergy = 0; //Energy used/sec for sustained weapons
	reloadTime = 0.0;
	//lightType = 3; //Weapon Fire
	//lightRadius = 2;
	//lightTime = 1;
	//lightColor = { 0.25, 0.25, 0.85 };
    sfxFire     = SoundSensorPower;
    sfxActivate		= SoundPickUpWeapon;
};

ItemData Grabbler
{
	description   = "Object Manipulator";
	className     = "Tool";
	shapeFile     = "paintgun";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = GrabblerImage;
	price         = 50;
	showWeaponBar = false;
     validateShape = false;
    validateMaterials = false;
};

function GrabblerImage::onFire(%player)
{
	%clientId = Player::getClient(%player);

    if(%clientId.CannotDeploy == true)
    {
        Client::sendMessage(%clientId,1,"ERROR: Your tool-usage priviliges have been disabled.~waccess_denied.wav");
        return;
    }

    if(%clientid.MovementType == "Free Move")
        Grabbler::ModXMover(%player, %clientId.ToolRadius);
    else
        Grabbler::ModXGrab(%player, %clientId.ToolRadius);
}

function Grabbler::ModXGrab(%player, %radius)
{
   %ClientId = player::getclient(%player);

   if(getWord(%clientId.MovementType, 0) != "Radius")
   {
   if(GameBase::getLOSInfo(%player,$MoverGunRange))
   {

    %set = newObject("set",SimSet);
    %radius = 30;
    %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, $los::position, %radius, %radius, %radius, 0);
    for(%i = %numItems - 1 ; %i>=0; %i--)
    {
        %obj = Group::getObject(%set, %i);
        if(%obj.DontBuildAroundMe == true && %clientId.isSuperAdmin != true)
        {
            Client::sendMessage(%clientId,0,"ERROR: Move position in no-tool zone.");
            return;
        }
    }

      %TempObj = $los::object;
      if(isObject(%TempObj) == false || %TempObj == "" && %clientId.isSuperAdmin != true)
          return;
      %type = getObjectType(%TempObj);

        if (%type == "SimTerrain"  && %clientId.isSuperAdmin != true || %type == "Flier" && %clientId.isSuperAdmin != true)
        {
           bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
           if(!%TempObj.depindex && %clientId.isSuperAdmin != true)
           {
               if(!Player::isAiControlled(%TempObj) && %clientId.isSuperAdmin != true)
                  return;
           }
        }
        if (%type == "Player" && %clientId.isSuperAdmin != true)
        {
           bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
           if(!%TempObj.depindex && %clientId.isSuperAdmin != true)
           {
               if(!Player::isAiControlled(%TempObj) && %clientId.isSuperAdmin != true)
                  return;
           }
        }
      if (%TempObj.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
      {
         if (%TempObj.Owner != "" || GroupSystem::IsInGroup(%clientId, %TempObj.Owner.buildgroup)) // If its not a mission obj or in same group, it's someone elses
            return;
      }

    if(%TempObj.weld || %target.project!= "" && %clientid.projectname!=%target.project)
    {
        if(%TempObj.weld == true || %target.project!= "" && %clientid.projectname!=%target.project)
        {
            bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object welded into place");
            return;
        }
    }

    if(%TempObj.DontMove)
    {
        return;
    }

      %TempObj.DontWeld = true;
      %TempObj.DontDel = true;

      %TempObj.Move = true;
      GameBase::setActive(%TempObj, false);

      %TempObjRot = GameBase::getRotation(%TempObj);
      %TempObjPos = GameBase::getPosition(%TempObj);

      %plrot = GameBase::getRotation(%player);

      %rotX = getword(%tempObjRot,0);
      %rotY = getword(%tempObjRot,1);
      %rotZ = getword(%tempObjRot,2);

      %posX = getword(%tempObjPos,0);
      %posY = getword(%tempObjPos,1);
      %posZ = getword(%tempObjPos,2);

      %rotval = %clientid.rotval;
      %posval = %clientid.posval;

      if(%clientid.MovementType == "Rotate X")
      {
         if(!%TempObj.DontRot)
            %rotX = %rotX + %rotval;
      }
      else if(%clientid.MovementType == "Rotate -X")
      {
         if(!%TempObj.DontRot)
            %rotX = %rotX - %rotval;
      }
      else if(%clientid.MovementType == "Rotate Y")
      {
         if(!%TempObj.DontRot)
            %rotY = %rotY + %rotval;
      }
      else if(%clientid.MovementType == "Rotate -Y")
      {
         if(!%TempObj.DontRot)
            %rotY = %rotY - %rotval;
      }
      else if(%clientid.MovementType == "Rotate Z")
      {
         if(!%TempObj.DontRot)
            %rotZ = %rotZ + %rotval;
      }
      else if(%clientid.MovementType == "Rotate -Z")
      {
         if(!%TempObj.DontRot)
            %rotZ = %rotZ - %rotval;
      }
      else if(%clientid.MovementType == "Move Right")
      {
         %posX = %posX + 0.2;
         %oldpos = %TempObjPos;
         %oldrot = %TempObjRot;
         %newpos = vector::add(Vector::Rotate(""@%posval@" 0 0",vector::add(%plrot,"0 0 0")),%oldpos);
         %posX = getWord(%newpos, 0);
         %posY = getWord(%newpos, 1);
         %posZ = getWord(%newpos, 2);
      }
      else if(%clientid.MovementType == "Move Left")
      {
         //%posX = %posX - 0.2;
         %oldpos = %TempObjPos;
         %oldrot = %TempObjRot;
         %newpos = vector::add(Vector::Rotate("-"@%posval@" 0 0",vector::add(%plrot,"0 0 0")),%oldpos);
         %posX = getWord(%newpos, 0);
         %posY = getWord(%newpos, 1);
         %posZ = getWord(%newpos, 2);
      }
      else if(%clientid.MovementType == "Move Forward")
      {
         //%posY = %posY + 0.2;
         %oldpos = %TempObjPos;
         %oldrot = %TempObjRot;
         %newpos = vector::add(Vector::Rotate("0 "@%posval@" 0",vector::add(%plrot,"0 0 0")),%oldpos);
         %posX = getWord(%newpos, 0);
         %posY = getWord(%newpos, 1);
         %posZ = getWord(%newpos, 2);
      }
      else if(%clientid.MovementType == "Move Backward")
      {
         //%posY = %posY - 0.2;
         %oldpos = %TempObjPos;
         %oldrot = %TempObjRot;
         %newpos = vector::add(Vector::Rotate("0 -"@%posval@" 0",vector::add(%plrot,"0 0 0")),%oldpos);
         %posX = getWord(%newpos, 0);
         %posY = getWord(%newpos, 1);
         %posZ = getWord(%newpos, 2);
      }
      else if(%clientid.MovementType == "Move Up")
      {
         %posZ = %posZ + %posval;
      }
      else if(%clientid.MovementType == "Move Down")
      {
         %posZ = %posZ - %posval;
      }
      else if(%clientid.MovementType == "Flip X")
      {
         if(!%TempObj.DontRot)
            %rotX = %rotX + 3.14;
      }
      else if(%clientid.MovementType == "Flip Y")
      {
         if(!%TempObj.DontRot)
            %rotY = %rotY + 3.14;
      }
      else if(%clientid.MovementType == "Flip Z")
      {
         if(!%TempObj.DontRot)
            %rotZ = %rotZ + 3.14;
      }

      if(!%TempObj.DontRot)
         GameBase::SetRotation(%TempObj, %rotX @ " " @ %rotY @ " " @ %rotZ);
      GameBase::SetPosition(%TempObj, %posX @ " " @ %posY @ " " @ %posZ);
      //bottomprint(%clientid,"Targetted: " @ %TempObj @ "\nType: " @ getObjectType(%TempObj) @ "\nRotation: " @ %TempObjRot @ "\nLocation: " @ %TempObjPos @ "\nMovement type: " @ %clientId.MovementType);
      GameBase::setActive(%TempObj, true);
      %TempObj.Move = false;
      %TempObj.DontWeld = false;
      %TempObj.DontDel = false;
      %TempObj.PositionalCoord = GameBase::getPosition(%TempObj);
      %TempObj.RotationalCoord = GameBase::getRotation(%TempObj);
      return;
   }
   bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
   }
   else
   {
        if(GameBase::getLOSInfo(%player,$MoverGunRange))
        {
            %set = newObject("set",SimSet);
            %radius = 30;
            %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, $los::position, %radius, %radius, %radius, 0);
            for(%i = %numItems - 1 ; %i>=0; %i--)
            {
                %obj = Group::getObject(%set, %i);
                if(%obj.DontBuildAroundMe == true && %clientId.isSuperAdmin != true)
                {
                    Client::sendMessage(%clientId,0,"ERROR: Move position in no-tool zone.");
                    return;
                }
            }

            %set = newObject("set",SimSet);
            %radius = %clientId.ToolRadius;
            %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, $los::position, %radius, %radius, %radius, 0);
            bottomprint(%clientid,"<jc>Object Manipulator: <f1>Radius:<f2> " @ %radius @ "m <f1># Objects:<f2> " @ %numItems);
            for(%i = %numItems - 1 ; %i>=0; %i--)
            {
                  %TempObj = Group::getObject(%set, %i);

                  //if(%TempObj == -1)
                  //  return;

                  %type = getObjectType(%TempObj);

                  %name = %TempObj.desc;

                  if (%TempObj.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
                  {
                     if (%TempObj.Owner != "" && %clientId.isSuperAdmin != true) // If its not a mission obj, it's someone elses
                        continue;
                  }

                %type = getObjectType(%TempObj);

                if (%type == "SimTerrain" || %type == "Player" || %type == "Flier" && %clientId.isSuperAdmin != true)
                {
                   bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
                   if(!%TempObj.depindex && %clientId.isSuperAdmin != true)
                   {
                       if(!Player::isAiControlled(%TempObj) && %clientId.isSuperAdmin != true)
                          return;
                   }
                }

                if(LayerSystem::isInLayerScope(%clientId, %TempObj) == false && %clientId.isSuperAdmin != true)
                {
                    bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object '"@%name@"' in non-active layer");
                    continue;
                }
                if (%TempObj.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
                {
                    return;
                }
                if(%TempObj.weld || %target.project!= "" && %clientid.projectname!=%target.project)
                {
                    if(%TempObj.weld == true || %target.project!= "" && %clientid.projectname!=%target.project)
                    {
                        bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object '"@%name@"' welded into place");
                        continue;
                    }
                }

                if(%TempObj.DontMove)
                {
                    continue;
                }

                %TempObj.Move = true;
                %TempObj.DontWeld = true;
                %TempObj.DontDel = true;
                GameBase::setActive(%TempObj, false);

                  %TempObjRot = GameBase::getRotation(%TempObj);
                  %TempObjPos = GameBase::getPosition(%TempObj);

                  %rotX = getword(%tempObjRot,0);
                  %rotY = getword(%tempObjRot,1);
                  %rotZ = getword(%tempObjRot,2);

                  %posX = getword(%tempObjPos,0);
                  %posY = getword(%tempObjPos,1);
                  %posZ = getword(%tempObjPos,2);

                  %plrot = GameBase::getRotation(%player);

                 %rotval = %clientid.rotval + 0.023984375;
                 %posval = %clientid.posval + 0.2;

                  if(%clientid.MovementType == "Radius Rotate X")
                  {
                     if(!%TempObj.DontRot)
                        %rotX = %rotX + %rotval;
                  }
                  else if(%clientid.MovementType == "Radius Rotate -X")
                  {
                     if(!%TempObj.DontRot)
                        %rotX = %rotX - %rotval;
                  }
                  else if(%clientid.MovementType == "Radius Rotate Y")
                  {
                     if(!%TempObj.DontRot)
                        %rotY = %rotY + %rotval;
                  }
                  else if(%clientid.MovementType == "Radius Rotate -Y")
                  {
                     if(!%TempObj.DontRot)
                        %rotY = %rotY - %rotval;
                  }
                  else if(%clientid.MovementType == "Radius Rotate Z")
                  {
                     if(!%TempObj.DontRot)
                        %rotZ = %rotZ + %rotval;
                  }
                  else if(%clientid.MovementType == "Radius Rotate -Z")
                  {
                     if(!%TempObj.DontRot)
                        %rotZ = %rotZ - %rotval;
                  }
                  else if(%clientid.MovementType == "Radius Flip X")
                  {
                     if(!%TempObj.DontRot)
                        %rotX = %rotX + 3.14;
                  }
                  else if(%clientid.MovementType == "Radius Flip Y")
                  {
                     if(!%TempObj.DontRot)
                        %rotY = %rotY + 3.14;
                  }
                  else if(%clientid.MovementType == "Radius Flip Z")
                  {
                     if(!%TempObj.DontRot)
                        %rotZ = %rotZ + 3.14;
                  }
                  else if(%clientid.MovementType == "Radius Move Right")
                  {
                     //%posX = %posX + 0.2;
                     %oldpos = %TempObjPos;
                     %oldrot = %TempObjRot;
                     %newpos = vector::add(Vector::Rotate(""@%posval@" 0 0",vector::add(%plrot,"0 0 0")),%oldpos);
                     %posX = getWord(%newpos, 0);
                     %posY = getWord(%newpos, 1);
                     %posZ = getWord(%newpos, 2);
                  }
                  else if(%clientid.MovementType == "Radius Move Left")
                  {
                     //%posX = %posX - 0.2;
                     %oldpos = %TempObjPos;
                     %oldrot = %TempObjRot;
                     %newpos = vector::add(Vector::Rotate("-"@%posval@" 0 0",vector::add(%plrot,"0 0 0")),%oldpos);
                     %posX = getWord(%newpos, 0);
                     %posY = getWord(%newpos, 1);
                     %posZ = getWord(%newpos, 2);
                  }
                  else if(%clientid.MovementType == "Radius Move Forward")
                  {
                     //%posY = %posY + 0.2;
                     %oldpos = %TempObjPos;
                     %oldrot = %TempObjRot;
                     %newpos = vector::add(Vector::Rotate("0 "@%posval@" 0",vector::add(%plrot,"0 0 0")),%oldpos);
                     %posX = getWord(%newpos, 0);
                     %posY = getWord(%newpos, 1);
                     %posZ = getWord(%newpos, 2);
                  }
                  else if(%clientid.MovementType == "Radius Move Backward")
                  {
                     //%posY = %posY - 0.2;
                     %oldpos = %TempObjPos;
                     %oldrot = %TempObjRot;
                     %newpos = vector::add(Vector::Rotate("0 -"@%posval@" 0",vector::add(%plrot,"0 0 0")),%oldpos);
                     %posX = getWord(%newpos, 0);
                     %posY = getWord(%newpos, 1);
                     %posZ = getWord(%newpos, 2);
                  }
                  else if(%clientid.MovementType == "Radius Move Up")
                  {
                     %posZ = %posZ + %posval;
                  }
                  else if(%clientid.MovementType == "Radius Move Down")
                  {
                     %posZ = %posZ - %posval;
                  }

                  if(!%TempObj.DontRot)
                     GameBase::SetRotation(%TempObj, %rotX @ " " @ %rotY @ " " @ %rotZ);
                  GameBase::SetPosition(%TempObj, %posX @ " " @ %posY @ " " @ %posZ);

                GameBase::setActive(%TempObj, true);
                %TempObj.Move = false;
                %TempObj.DontWeld = false;
                %TempObj.DontDel = false;
                %TempObj.PositionalCoord = GameBase::getPosition(%TempObj);
                %TempObj.RotationalCoord = GameBase::getRotation(%TempObj);
			}
            return;
        }
        bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
   }
}

function Grabbler::ModXMover(%player, %radius)
{
        %clientId = Player::getClient(%player);
       if(GameBase::getLOSInfo(%player, 1000))
       {
            %set = newObject("set",SimSet);
            %radius = 30;
            %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, $los::position, %radius, %radius, %radius, 0);
            for(%i = %numItems - 1 ; %i>=0; %i--)
            {
                %obj = Group::getObject(%set, %i);
                if(%obj.DontBuildAroundMe == true && %clientId.isSuperAdmin != true)
                {
                    Client::sendMessage(%clientId,0,"ERROR: Move position in no-tool zone.");
                    %clientId.endMove = true;
                    return;
                }
            }
        %TempObj = $los::object;
        if (isObject(%TempObj) == false || %TempObj == "" && %clientId.isSuperAdmin != true)
           return;

        %target = %TempObj;
        %type = getObjectType(%target);

    if(LayerSystem::isInLayerScope(%clientId, %TempObj) == false && %clientId.isSuperAdmin != true)
    {
        bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object in non-active layer");
        return;
    }
          if (%target.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
          {
             if (%target.Owner != "" && %clientId.isSuperAdmin != true) // If its not a mission obj, it's someone elses
                return;
          }
          //both(%clientid.projectname@" "@%target.project);

        if(%target.weld || %target.project!= "" && %clientid.projectname!=%target.project)
        {
            if(%target.weld == true || %target.project!= "" && %clientid.projectname!=%target.project)
            {
                bottomprint(%clientid,"<jc>Object Manipulator: <f2>Object welded into place");
                return;
            }
        }
        if(%TempObj.DontMove)
        {
            return;
        }

        %type = getObjectType(%TempObj);

        if (%type == "SimTerrain" || %type == "Player" || %type == "Flier" && %clientId.isSuperAdmin != true)
        {
           bottomprint(%clientid,"<jc>Object Manipulator: <f2>Nothing in range");
           if(!%TempObj.depindex && %clientId.isSuperAdmin != true)
           {
               if(!Player::isAiControlled(%TempObj) && %clientId.isSuperAdmin != true)
                  return;
           }
        }

        %TempObj.Move = true;
        %TempObj.DontWeld = true;
        %TempObj.DontDel = true;
        GameBase::setActive(%target, false);

        %player.GrabObject = "";
    	%player.Grabdist = "";
    	%player.GrabRoty = "";
    	%player.GrabOffsetVec = "";

    	%player.GrabObject = %target;

    	if(%target == %player)
    	{
    		return;
    	}
    	else
    	{
			//come here
            GameBase::setActive(%target, false);
    		%client = Player::getClient(%player);
    		%player.GrabObject = %target;
    		%dataName = GameBase::getDataName(%target);
    		%shape = %dataName.shapeFile;

    		%trans = GameBase::getMuzzleTransform(%player);	//position of tip
    			%posX = getWord(%trans,9);		//x
    			%posY = getWord(%trans,10);		//y
    			%posZ = getWord(%trans,11); 		//z
    		%GunTipPos = %posX@" "@%posY@" "@%posZ;

    		//figure out general relativity, Einstein..
    			%d1= getWord(%trans,3);
    			%d2= getWord(%trans,4);
    			%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas

    			%TargetPos = GameBase::getPosition(%target);

    		//simplified for these -player and flier pos is at at bottom center -plasmatic
    		if(%type == "Player" || %type == "Flier" && %clientId.isSuperAdmin != true)// || %type == "Mine")
    		{
    			%player.Grabdist = vector::getdistance(%TargetPos,%GunTipPos);
    			%player.GrabOffsetVec = "";
    			%player.GrabRoty = "";
    			%target.forker = %player;	// for release code, plasmatic 2.3
    		}

    		else
    		{
    		// This works ok for now. When beam attach point changes
    		// while rotating, movement is still funky...
    		// hack to move static objects correctly -plasmatic
    			GameBase::getLOSInfo(%player,1000);
    				// GetLOSInfo sets the following globals:
    				// 	los::position
    				// 	los::normal
    				// 	los::object

    			%RealDist = vector::getdistance($los::position,%GunTipPos);
    			%player.Grabdist = %RealDist;

    			%TargetRot = GameBase::getRotation(%target);
    			%playerRot = GameBase::getRotation(%player);
    			%targetRelative = vector::add(%TargetRot ,vector::multiply("0 0 -1",%playerRot));// hacking for screwy spawn pts -players only rotate around z -plas

    			%player.GrabRoty = %targetRelative;

    		//%GunExtPos is like the end of a broom handle shoved down gun barrel.
    			%GunExtPos = %posX + %d1 * %RealDist@" "@%posY + %d2 * %RealDist@" "@%posZ + %d3 * %RealDist;

    		// offsetvec is vec from where we're grabbing to the actual obj position 'handle'
    		// position on object we're grabbing may change, but this works good. -plasmatic
    			%OffsetVec = vector::add(vector::multiply("-1 -1 -1",%GunExtPos),%TargetPos);	//dist from gun tip to where beam is hitting, more or less...
    	//		%Nrot = vector::add(vector::multiply("-1 -1 -1",%targetRot),%playerRot);
    	//		%OffsetVecNew = Vector::Rotate(%OffsetVec,%Nrot);	//normalizing vector relative to player
    			%player.GrabOffsetVec = %OffsetVec;


    		}
          Grabler::move(%player,%target);
        }
       }
        %TempObj.PositionalCoord = GameBase::getPosition(%TempObj);
        %TempObj.RotationalCoord = GameBase::getRotation(%TempObj);
    	//%target.forker = "";
        GameBase::setActive(%target, true);
        %TempObj.Move = false;
        %TempObj.DontWeld = false;
        %TempObj.DontDel = false;
}

function Grabler::move(%player,%target)
{
    %clientId = Player::getClient(%player);
    if(%clientId.endMove == true)
    {
        %clientId.endMove = "";
        %player.GrabObject = "";
    }
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(Player::isTriggered(%player,$WeaponSlot) && %weapon == Grabbler)
	{
		if(%player.GrabObject != %target || %player.GrabObject == "")
		{
			%player.GrabObject = "";
			%player.Grabdist = "";
			%player.GrabRoty = "";
			%player.GrabOffsetVec = "";
			return;
		}
		%type = getObjectType(%target);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);

		//position of tip
			%posX = getWord(%trans,9);		//x
			%posY = getWord(%trans,10);		//y
			%posZ = getWord(%trans,11); 		//z
			%GunTipPos = %posX@" "@%posY@" "@%posZ;
		//direction gun is pointed foo.
		%d1= getWord(%trans,3);
			%d2= getWord(%trans,4);
			%d3= getWord(%trans,5);		//3,4,5 are dir vec -plas
			%GunRotVec = %d1 @" " @ %d2 @" " @ %d3;

		%dist = %player.Grabdist;

		if(%type == "Player" || %type == "Flier")
		{
			Item::setVelocity(%target, 0);
			%position = %posX + %d1 * %dist@" "@%posY + %d2 * %dist@" "@%posZ + %d3 * %dist;
			if(GameBase::testPosition(%target, %position))
			{
				GameBase::setPosition(%target,%position);
			}
			else
			{
				%TargetPos = GameBase::getPosition(%target);
				%oldheight = getword(%TargetPos,2);
				%newHeight = getword(%position,2);

				//player aiming down, pushing player through ground?
				if(%newHeight < %oldheight)		//%d3 < -0.5)
				{
					//Player::trigger(%player,$WeaponSlot,false);
					GameBase::setPosition(%target,vector::add(%TargetPos,"0 0 0.2"));
					return;
				}
				else
				{

					%player.Grabdist = vector::getdistance(%TargetPos,%GunTipPos);
				}

			}
			schedule("Grabler::move("@%player@","@%target@");",0.037);
		}
		else
		{
			%targetRelative = %player.GrabRoty;
			%playerRot = GameBase::getRotation(%player);
			%newrot = vector::add(%playerRot,%targetRelative);
			%GunExtPos = vector::add(vector::multiply(%GunRotVec,%dist@" "@%dist@" "@%dist),%GunTipPos);

			%OffsetVec = %player.GrabOffsetVec;
	//	bottomprint(Player::getClient(%player),%OffsetVec@" "@%playerRot);
	//		%OffsetVecNew = Vector::Rotate(%OffsetVec,%targetRot);	//%newrot);	//ah the joys of rotation...
			%position = vector::add(%GunExtPos,%OffsetVec);	//%OffsetVecNew
			GameBase::setPosition(%target,%position);
            if(!%target.DontRot)
                GameBase::setRotation(%target,%newrot);

			schedule("Grabler::move("@%player@","@%target@");",0.025);
		}


	}

}









$InvList[Orbital1] = 0;
//$InvList[doppelammo] = 1;
$RemoteInvList[Orbital1] = 0;
//$RemoteInvList[doppelammo] = 1;
$AutoUse[Orbital1] = true;
//$WeaponAmmo[doppel] = doppelammo;
//$SellAmmo[doppelammo] = 1;




RocketData OrbitalBolt2
{
   bulletShapeName  = "plasmaex.dts";
   explosionTag     = nothingExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.1;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 1.0;
   kickBackStrength = 2.0;
   muzzleVelocity   = 0.000000000001;
   terminalVelocity = 0.000000000001;
   acceleration     = 3.0;
   totalTime        = 30.0;
   liveTime         = 30.0;
   lightRange       = 0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific


   soundId = SoundJetHeavy;
};



RocketData OrbitalBolt1
{
   bulletShapeName  = "plasmaex.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.1;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 20.0;
   muzzleVelocity   = 20.0;
   terminalVelocity = 20.0;
   acceleration     = 3.0;
   totalTime        = 5.0;
   liveTime         = 5.0;
   lightRange       = 0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific


   soundId = SoundJetHeavy;
};



RocketData OrbitalLauncherBolt
{
   bulletShapeName  = "plasmaex.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.1;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 20.0;
   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   acceleration     = 3.0;
   totalTime        = 5.0;
   liveTime         = 5.0;
   lightRange       = 0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific


   soundId = SoundJetHeavy;
};

//---------------------------------ORBITAL 3---------------------------
//----------------------------------------------------------------------------

ItemImageData Orbital3Image
{
   shapeFile  = "grenadeL";   //paintgun
   mountPoint = 0;
   mountOffset = {0.1, 0, 0};
   mountRotation = {0, 0, 0};
   //ammoType = doppelammo;
   weaponType = 0; // Spinning
   reloadTime = 0;
   //spinUpTime = 0.1;
   //spinDownTime = 3;
   fireTime = 1;

   minEnergy = 1;
   maxEnergy = 2;
   accuFire = true;
};

ItemData Orbital3
{
   heading = "bWeapons";
   description = "ORBITAL-KANONE";
   className = "Weapon";
   shapeFile  = "plasma";
   hudIcon = "plasma";
   shadowDetailMask = 4;
   imageType = Orbital3Image;
   price = "UNBEZAHLBAR";
   showWeaponBar = true;
};

//---------------------------------ORBITAL 2---------------------------
//----------------------------------------------------------------------------

ItemImageData Orbital2Image
{
   shapeFile  = "grenadeL";   //paintgun
   mountPoint = 0;
   mountOffset = {-0.1, 0, 0};
   mountRotation = {0, 0, 0};
   //ammoType = doppelammo;
   weaponType = 0; // Spinning
   reloadTime = 0;
   //spinUpTime = 0.1;
   //spinDownTime = 3;
   fireTime = 1;

   minEnergy = 1;
   maxEnergy = 2;
   accuFire = true;
};

ItemData Orbital2
{
   heading = "bWeapons";
   description = "ORBITAL-KANONE";
   className = "Weapon";
   shapeFile  = "plasma";
   hudIcon = "plasma";
   shadowDetailMask = 4;
   imageType = Orbital2Image;
   price = "UNBEZAHLBAR";
   showWeaponBar = true;
};

//---------------------------------ORBITAL 1---------------------------
//----------------------------------------------------------------------------

ItemImageData Orbital1Image
{
   shapeFile  = "grenadeL";   //paintgun
   mountPoint = 0;
   mountOffset = {0, 0, 0.1};
   mountRotation = {0, 0, 0};
   //ammoType = doppelammo;
   weaponType = 0; // Spinning
   reloadTime = 0;
   //spinUpTime = 0.1;
   //spinDownTime = 3;
   fireTime = 1;

   minEnergy = 1;
   maxEnergy = 2;
   accuFire = true;
};

ItemData Orbital1
{
   heading = "bWeapons";
   description = "V E R B O T E N";               //ORBITAL-KANONE
   className = "Tool";
   shapeFile  = "plasma";
   hudIcon = "plasma";
   shadowDetailMask = 4;
   imageType = Orbital1Image;
   price = 100000;
   showWeaponBar = true;
};


function Orbital1::onMount(%player,%imageSlot,%item)
{
   Player::mountItem(%player,Orbital2,5);
   Player::mountItem(%player,Orbital3,6);

   %client = Player::getClient(%player);
   Bottomprint(%client, "<jc><f2>ORBITAL-KANONE <f0> WARNUNG GEBRAUCH GUT ÜBERLEGEN");
}

function Orbital1::onUnmount(%player,%imageSlot)
{
   Player::unmountItem(%player,5);
   Player::unmountItem(%player,6);
}




function Orbital1Image::onFire(%player, %slot)
{

%client = Player::getClient(%player);
Player::setDamageFlash(%client, 1);



$OrbitCountA = 0;
$OrbitCountB = 0;
$OrbitCountC = 0;
$OrbitCountD = 0;

%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%OPO = Projectile::spawnProjectile("OrbitalLauncherBolt",%trans,%player,%vel);

Player::trigger(%player,5,true);
Player::trigger(%player,5,false);
Player::trigger(%player,6,true);
Player::trigger(%player,6,false);

schedule("OrbitalProjectileOne("@%player@","@%OPO@");",0.95,%OPO);
}




function OrbitalProjectileOne(%player,%OPO)
{

%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);

%posObtO = GameBase::getPosition(%OPO);

%obt1 = getWord(%trans, 0);
%obt2 = getWord(%trans, 1);
%obt3 = getWord(%trans, 2);
%obt4 = getWord(%trans, 3);
%obt5 = getWord(%trans, 4);
%obt6 = getWord(%trans, 5);
%obt7 = getWord(%trans, 6);
%obt8 = getWord(%trans, 7);
%obt9 = getWord(%trans, 8);
%obt10 = getWord(%trans, 9);
%obt11 = getWord(%trans, 10);
%obt12 = getWord(%trans, 11);

%PosTransOrbitalTwo = %obt1@" "@%obt2@" "@%obt3@" "@%obt4@" "@%obt5@" "@%obt6@" "@%obt7@" "@%obt8@" "@%obt9@" "@%posObtO;

%OPT = Projectile::spawnProjectile("OrbitalBolt2",%PosTransOrbitalTwo,%player,%vel);



schedule("OrbitalProjectileTwo("@%player@","@%OPT@");",4,%OPT);
schedule("OrbitalProjectileTwo2("@%player@","@%OPT@");",4,%OPT);
schedule("OrbitalProjectileTwo3("@%player@","@%OPT@");",4,%OPT);
schedule("OrbitalProjectileTwo4("@%player@","@%OPT@");",4,%OPT);
}









function OrbitalProjectileTwo(%player,%OPT)
{
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%posObtT = GameBase::getPosition(%OPT);
      %xrnd = (floor(getRandom() *21)-10)/10;      //*21 -10)/100
      %yrnd = (floor(getRandom() *21)-10)/10;
      %zrnd = (floor(getRandom() *21)-10)/10;
      %obf1 = getWord(%trans, 0);
      %obf2 = getWord(%trans, 1);
      %obf3 = getWord(%trans, 2);
      %obf4 = %xrnd;
      %obf5 = %yrnd;
      %obf6 = 0;
      %obf7 = getWord(%trans, 6);
      %obf8 = getWord(%trans, 7);
      %obf9 = getWord(%trans, 8);
      %obf10 = getWord(%trans, 9);
      %obf11 = getWord(%trans, 10);
      %obf12 = getWord(%trans, 11);
      %PosTransObitalFour = %obf1@" "@%obf2@" "@%obf3@" "@%obf4@" "@%obf5@" "@%obf6@" "@%obf7@" "@%obf8@" "@%obf9@" "@%posObtT;
      %OPF = Projectile::spawnProjectile("OrbitalBolt1",%PosTransObitalFour,%player,%vel);
schedule("OPFFFA("@%player@","@%OPF@");",4.9,%OPF);
}

function OrbitalProjectileTwo2(%player,%OPT)
{
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%posObtT = GameBase::getPosition(%OPT);
      %xrnd = (floor(getRandom() *21)-10)/10;      //*21 -10)/100
      %yrnd = (floor(getRandom() *21)-10)/10;
      %zrnd = (floor(getRandom() *21)-10)/10;
      %obf1 = getWord(%trans, 0);
      %obf2 = getWord(%trans, 1);
      %obf3 = getWord(%trans, 2);
      %obf4 = %xrnd;
      %obf5 = %yrnd;
      %obf6 = 0;
      %obf7 = getWord(%trans, 6);
      %obf8 = getWord(%trans, 7);
      %obf9 = getWord(%trans, 8);
      %obf10 = getWord(%trans, 9);
      %obf11 = getWord(%trans, 10);
      %obf12 = getWord(%trans, 11);
      %PosTransObitalFour = %obf1@" "@%obf2@" "@%obf3@" "@%obf4@" "@%obf5@" "@%obf6@" "@%obf7@" "@%obf8@" "@%obf9@" "@%posObtT;
      %OPF = Projectile::spawnProjectile("OrbitalBolt1",%PosTransObitalFour,%player,%vel);
schedule("OPFFFB("@%player@","@%OPF@");",4.9,%OPF);
}

function OrbitalProjectileTwo3(%player,%OPT)
{
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%posObtT = GameBase::getPosition(%OPT);
      %xrnd = (floor(getRandom() *21)-10)/10;      //*21 -10)/100
      %yrnd = (floor(getRandom() *21)-10)/10;
      %zrnd = (floor(getRandom() *21)-10)/10;
      %obf1 = getWord(%trans, 0);
      %obf2 = getWord(%trans, 1);
      %obf3 = getWord(%trans, 2);
      %obf4 = %xrnd;
      %obf5 = %yrnd;
      %obf6 = 0;
      %obf7 = getWord(%trans, 6);
      %obf8 = getWord(%trans, 7);
      %obf9 = getWord(%trans, 8);
      %obf10 = getWord(%trans, 9);
      %obf11 = getWord(%trans, 10);
      %obf12 = getWord(%trans, 11);
      %PosTransObitalFour = %obf1@" "@%obf2@" "@%obf3@" "@%obf4@" "@%obf5@" "@%obf6@" "@%obf7@" "@%obf8@" "@%obf9@" "@%posObtT;
      %OPF = Projectile::spawnProjectile("OrbitalBolt1",%PosTransObitalFour,%player,%vel);
schedule("OPFFFC("@%player@","@%OPF@");",4.9,%OPF);
}

function OrbitalProjectileTwo4(%player,%OPT)
{
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%posObtT = GameBase::getPosition(%OPT);
      %xrnd = (floor(getRandom() *21)-10)/10;      //*21 -10)/100
      %yrnd = (floor(getRandom() *21)-10)/10;
      %zrnd = (floor(getRandom() *21)-10)/10;
      %obf1 = getWord(%trans, 0);
      %obf2 = getWord(%trans, 1);
      %obf3 = getWord(%trans, 2);
      %obf4 = %xrnd;
      %obf5 = %yrnd;
      %obf6 = 0;
      %obf7 = getWord(%trans, 6);
      %obf8 = getWord(%trans, 7);
      %obf9 = getWord(%trans, 8);
      %obf10 = getWord(%trans, 9);
      %obf11 = getWord(%trans, 10);
      %obf12 = getWord(%trans, 11);
      %PosTransObitalFour = %obf1@" "@%obf2@" "@%obf3@" "@%obf4@" "@%obf5@" "@%obf6@" "@%obf7@" "@%obf8@" "@%obf9@" "@%posObtT;
      %OPF = Projectile::spawnProjectile("OrbitalBolt1",%PosTransObitalFour,%player,%vel);
schedule("OPFFFD("@%player@","@%OPF@");",4.9,%OPF);
}




function OPFFFA(%player,%OPF)
{
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%OrbitalPos = GameBase::getPosition(%OPF);
      %obf1 = getWord(%trans, 0);
      %obf2 = getWord(%trans, 1);
      %obf3 = getWord(%trans, 2);
      %obf4 = getWord(%trans, 3);
      %obf5 = getWord(%trans, 4);
      %obf6 = getWord(%trans, 5);
      %obf7 = getWord(%trans, 6);
      %obf8 = getWord(%trans, 7);
      %obf9 = getWord(%trans, 8);
      %obf10 = getWord(%trans, 9);
      %obf11 = getWord(%trans, 10);
      %obf12 = getWord(%trans, 11);
      %PosTransObitalFive1 = %obf1@" "@%obf2@" "@%obf3@" "@%obf4@" "@%obf5@" "@%obf6@" "@%obf7@" "@%obf8@" "@%obf9@" "@%OrbitalPos;
%Orbit = Projectile::spawnProjectile("OrbitalBolt2",%PosTransObitalFive1,%player,%vel);
schedule("OrbitalGetTargetandFireA("@%player@","@%Orbit@");", 5,%Orbit);
}

function OPFFFB(%player,%OPF)
{
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%OrbitalPos = GameBase::getPosition(%OPF);
      %obf1 = getWord(%trans, 0);
      %obf2 = getWord(%trans, 1);
      %obf3 = getWord(%trans, 2);
      %obf4 = getWord(%trans, 3);
      %obf5 = getWord(%trans, 4);
      %obf6 = getWord(%trans, 5);
      %obf7 = getWord(%trans, 6);
      %obf8 = getWord(%trans, 7);
      %obf9 = getWord(%trans, 8);
      %obf10 = getWord(%trans, 9);
      %obf11 = getWord(%trans, 10);
      %obf12 = getWord(%trans, 11);
      %PosTransObitalFive1 = %obf1@" "@%obf2@" "@%obf3@" "@%obf4@" "@%obf5@" "@%obf6@" "@%obf7@" "@%obf8@" "@%obf9@" "@%OrbitalPos;
%Orbit = Projectile::spawnProjectile("OrbitalBolt2",%PosTransObitalFive1,%player,%vel);
schedule("OrbitalGetTargetandFireB("@%player@","@%Orbit@");", 5,%Orbit);
}

function OPFFFC(%player,%OPF)
{
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%OrbitalPos = GameBase::getPosition(%OPF);
      %obf1 = getWord(%trans, 0);
      %obf2 = getWord(%trans, 1);
      %obf3 = getWord(%trans, 2);
      %obf4 = getWord(%trans, 3);
      %obf5 = getWord(%trans, 4);
      %obf6 = getWord(%trans, 5);
      %obf7 = getWord(%trans, 6);
      %obf8 = getWord(%trans, 7);
      %obf9 = getWord(%trans, 8);
      %obf10 = getWord(%trans, 9);
      %obf11 = getWord(%trans, 10);
      %obf12 = getWord(%trans, 11);
      %PosTransObitalFive1 = %obf1@" "@%obf2@" "@%obf3@" "@%obf4@" "@%obf5@" "@%obf6@" "@%obf7@" "@%obf8@" "@%obf9@" "@%OrbitalPos;
%Orbit = Projectile::spawnProjectile("OrbitalBolt2",%PosTransObitalFive1,%player,%vel);
schedule("OrbitalGetTargetandFireC("@%player@","@%Orbit@");", 5,%Orbit);
}

function OPFFFD(%player,%OPF)
{
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%OrbitalPos = GameBase::getPosition(%OPF);
      %obf1 = getWord(%trans, 0);
      %obf2 = getWord(%trans, 1);
      %obf3 = getWord(%trans, 2);
      %obf4 = getWord(%trans, 3);
      %obf5 = getWord(%trans, 4);
      %obf6 = getWord(%trans, 5);
      %obf7 = getWord(%trans, 6);
      %obf8 = getWord(%trans, 7);
      %obf9 = getWord(%trans, 8);
      %obf10 = getWord(%trans, 9);
      %obf11 = getWord(%trans, 10);
      %obf12 = getWord(%trans, 11);
      %PosTransObitalFive1 = %obf1@" "@%obf2@" "@%obf3@" "@%obf4@" "@%obf5@" "@%obf6@" "@%obf7@" "@%obf8@" "@%obf9@" "@%OrbitalPos;
%Orbit = Projectile::spawnProjectile("OrbitalBolt2",%PosTransObitalFive1,%player,%vel);
schedule("OrbitalGetTargetandFireD("@%player@","@%Orbit@");", 5,%Orbit);
}







function OrbitalGetTargetandFireA(%player,%Orbit)
{
%vel = Item::getVelocity(%player);
$OrbitCountA = $OrbitCountA + 1;
%TargetSatTrans = GameBase::getMuzzleTransform(%player);
%OrbitPos = GameBase::getPosition(%Orbit);
%client = Player::getClient(%player);

      %xrnd = (floor(getRandom() *21)-10)/70;      //*21 -10)/100
         %yrnd = (floor(getRandom() *21)-10)/70;
         %zrnd = (floor(getRandom() *21)-10)/50;

      %Strans1= getWord(%TargetSatTrans,0);
         %Strans2= getWord(%TargetSatTrans,1);
         %Strans3= getWord(%TargetSatTrans,2);
         %Strans4= %xrnd;      //(getWord(%TargetSatTrans,3)/8);
         %Strans5= %yrnd;      //(getWord(%TargetSatTrans,4)/8);
         %Strans6= -0.7+%zrnd;      //(getWord(%TargetSatTrans,5)/8);
         %Strans7= getWord(%TargetSatTrans,6);
         %Strans8= getWord(%TargetSatTrans,7);
         %Strans9= getWord(%TargetSatTrans,8);
         %Strans10=getWord(%TargetSatTrans,9);
         %Strans11=getWord(%TargetSatTrans,10);
         %Strans12=getWord(%TargetSatTrans,11);
%OrbitShootTrans =  %Strans1 @" "@ %Strans2 @" "@ %Strans3 @" "@ %Strans4 @" "@ %Strans5 @" "@ %Strans6 @" "@ %Strans7 @" "@ %Strans8 @" "@ %Strans9 @" "@ %OrbitPos;
Projectile::spawnProjectile(DiscShell,%OrbitShootTrans,%player,%vel);

   if($OrbitCountA < 150)
   {
   schedule("OrbitalGetTargetandFireA("@%player@","@%Orbit@");", 0.3,%Orbit);
   }
}

function OrbitalGetTargetandFireB(%player,%Orbit)
{
%vel = Item::getVelocity(%player);
$OrbitCountB = $OrbitCountB + 1;
%TargetSatTrans = GameBase::getMuzzleTransform(%player);
%OrbitPos = GameBase::getPosition(%Orbit);
%client = Player::getClient(%player);

      %xrnd = (floor(getRandom() *21)-10)/70;      //*21 -10)/100
         %yrnd = (floor(getRandom() *21)-10)/70;
         %zrnd = (floor(getRandom() *21)-10)/50;

      %Strans1= getWord(%TargetSatTrans,0);
         %Strans2= getWord(%TargetSatTrans,1);
         %Strans3= getWord(%TargetSatTrans,2);
         %Strans4= %xrnd;      //(getWord(%TargetSatTrans,3)/8);
         %Strans5= %yrnd;      //(getWord(%TargetSatTrans,4)/8);
         %Strans6= -0.7+%zrnd;      //(getWord(%TargetSatTrans,5)/8);
         %Strans7= getWord(%TargetSatTrans,6);
         %Strans8= getWord(%TargetSatTrans,7);
         %Strans9= getWord(%TargetSatTrans,8);
         %Strans10=getWord(%TargetSatTrans,9);
         %Strans11=getWord(%TargetSatTrans,10);
         %Strans12=getWord(%TargetSatTrans,11);
%OrbitShootTrans =  %Strans1 @" "@ %Strans2 @" "@ %Strans3 @" "@ %Strans4 @" "@ %Strans5 @" "@ %Strans6 @" "@ %Strans7 @" "@ %Strans8 @" "@ %Strans9 @" "@ %OrbitPos;
Projectile::spawnProjectile(DiscShell,%OrbitShootTrans,%player,%vel);

   if($OrbitCountB < 150)
   {
   schedule("OrbitalGetTargetandFireB("@%player@","@%Orbit@");", 0.3,%Orbit);
   }
}


function OrbitalGetTargetandFireC(%player,%Orbit)
{
%vel = Item::getVelocity(%player);
$OrbitCountC = $OrbitCountC + 1;
%TargetSatTrans = GameBase::getMuzzleTransform(%player);
%OrbitPos = GameBase::getPosition(%Orbit);
%client = Player::getClient(%player);

      %xrnd = (floor(getRandom() *21)-10)/70;      //*21 -10)/100
         %yrnd = (floor(getRandom() *21)-10)/70;
         %zrnd = (floor(getRandom() *21)-10)/50;

      %Strans1= getWord(%TargetSatTrans,0);
         %Strans2= getWord(%TargetSatTrans,1);
         %Strans3= getWord(%TargetSatTrans,2);
         %Strans4= %xrnd;      //(getWord(%TargetSatTrans,3)/8);
         %Strans5= %yrnd;      //(getWord(%TargetSatTrans,4)/8);
         %Strans6= -0.7+%zrnd;      //(getWord(%TargetSatTrans,5)/8);
         %Strans7= getWord(%TargetSatTrans,6);
         %Strans8= getWord(%TargetSatTrans,7);
         %Strans9= getWord(%TargetSatTrans,8);
         %Strans10=getWord(%TargetSatTrans,9);
         %Strans11=getWord(%TargetSatTrans,10);
         %Strans12=getWord(%TargetSatTrans,11);
%OrbitShootTrans =  %Strans1 @" "@ %Strans2 @" "@ %Strans3 @" "@ %Strans4 @" "@ %Strans5 @" "@ %Strans6 @" "@ %Strans7 @" "@ %Strans8 @" "@ %Strans9 @" "@ %OrbitPos;
Projectile::spawnProjectile(DiscShell,%OrbitShootTrans,%player,%vel);

   if($OrbitCountC < 150)
   {
   schedule("OrbitalGetTargetandFireC("@%player@","@%Orbit@");", 0.3,%Orbit);
   }
}


function OrbitalGetTargetandFireD(%player,%Orbit)
{
%vel = Item::getVelocity(%player);
$OrbitCountD = $OrbitCountD + 1;
%TargetSatTrans = GameBase::getMuzzleTransform(%player);
%OrbitPos = GameBase::getPosition(%Orbit);
%client = Player::getClient(%player);

      %xrnd = (floor(getRandom() *21)-10)/70;      //*21 -10)/100
         %yrnd = (floor(getRandom() *21)-10)/70;
         %zrnd = (floor(getRandom() *21)-10)/50;

      %Strans1= getWord(%TargetSatTrans,0);
         %Strans2= getWord(%TargetSatTrans,1);
         %Strans3= getWord(%TargetSatTrans,2);
         %Strans4= %xrnd;      //(getWord(%TargetSatTrans,3)/8);
         %Strans5= %yrnd;      //(getWord(%TargetSatTrans,4)/8);
         %Strans6= -0.7+%zrnd;      //(getWord(%TargetSatTrans,5)/8);
         %Strans7= getWord(%TargetSatTrans,6);
         %Strans8= getWord(%TargetSatTrans,7);
         %Strans9= getWord(%TargetSatTrans,8);
         %Strans10=getWord(%TargetSatTrans,9);
         %Strans11=getWord(%TargetSatTrans,10);
         %Strans12=getWord(%TargetSatTrans,11);
%OrbitShootTrans =  %Strans1 @" "@ %Strans2 @" "@ %Strans3 @" "@ %Strans4 @" "@ %Strans5 @" "@ %Strans6 @" "@ %Strans7 @" "@ %Strans8 @" "@ %Strans9 @" "@ %OrbitPos;
Projectile::spawnProjectile(DiscShell,%OrbitShootTrans,%player,%vel);

   if($OrbitCountD < 150)
   {
   schedule("OrbitalGetTargetandFireD("@%player@","@%Orbit@");", 0.3,%Orbit);
   }
}


//****************************************************************************
//Flaggy
//****************************************************************************
ItemImageData FlaggyImage
{
   shapeFile  = "flag";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.15;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Flaggy
{
   heading = "bWeapons";
	description = "Flaggy";
	className     = "Tool";
   shapeFile  = "plasma";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = FlaggyImage;
	showWeaponBar = true;


};
function FlaggyImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
//	if(%client.thrown)
//	{
//		Flaggy::Detonate(%client);
//		%client.thrown=false;
//		%client.flaggies=0;
//	}
	if(isobject(%client.flaggy[0]) == "false" || GameBase::getDataName(%client.flaggy[0]) != "MeFlag")
	{
		%client.flaggies = 0;
		//%client.thrown=false;
	}
	else {
		%client.flaggies++;
	}
		%client.thrown=true;
		//%trans = GameBase::getMuzzleTransform(%player);
		//%vel = Item::getVelocity(%player);
		//Projectile::spawnProjectile("PlasmaShell", %trans, %player, %vel);

		%flag = newObject("", Item, MeFlag, 1, false, false, true);

		addToSet("MissionCleanup", %flag);
		%client.flaggy[%client.flaggies] = %flag;
		GameBase::setTeam(%flag, -1);
		%flag.owner = %client;
			%flag.carrier = -1;
			%flag.value = floor(getrandom()*50);
		GameBase::throw(%flag, %player, 20, false);
  //}
}
function Flaggy::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	%pack = Player::getMountedItem(%player,$BackpackSlot);
	if (%pack != -1) {
		Player::decItemCount(%player,%pack);
	}
		Player::incItemCount(%player,repairpack);
		Player::useItem(%player,repairpack);
}

function Flaggy::Detonate(%cl)
{
	//return;

	echo("det..");
	//%flag = %cl.flaggy;
	for(%x = 0; %cl.flaggy[%x] != ""; %x++)
	{
		if(cl.flaggy[%x] == "False" && %x > 200)
		{
			break;
		}
		echo("flag count: "@%x@" "@%cl.flaggy[%x]);
		%flag = %cl.flaggy[%x];
	//messageall(1, "count: "@%x@" isobject?: "@isobject(%flag)@" type?:"@getObjectType(%flag)@" data? "@GameBase::getDataName(%flag));
		if(isobject(%flag) && GameBase::getDataName(%flag) == "MeFlag")
		{
			%newflag = newObject("Static",StaticShape,StaticMeFlag,true);

			addToSet("MissionCleanup", %newflag);

			GameBase::setTeam(%newflag,GameBase::getTeam(%player));
			GameBase::setRotation(%newflag,gamebase::getrotation(%flag));
			GameBase::setPosition(%newflag,gamebase::getposition(%flag));
			deleteobject(%flag);
			//GameBase::setDamageLevel(%newflag, 0.1);
			schedule("GameBase::setDamageLevel("@%newflag@", 0.1);", 0.08+(%x/10));
			%cl.flaggy[%x] = "";
		}

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.meflagcount  > 0)
			{

			}

		}
		//else {
			//messageall(1, "target name: "@Client::getName(%cl.target));
		//	%targetplayer = client::getownedobject(%cl.target);
//
//
		//	%newflag = newObject("Static",StaticShape,StaticMeFlag,true);
		//	addToSet("MissionCleanup", %newflag);
//
		//	GameBase::setTeam(%newflag,GameBase::getTeam(%targetplayer));
		//	GameBase::setRotation(%newflag,gamebase::getrotation(%targetplayer));
		//	GameBase::setPosition(%newflag,gamebase::getposition(%targetplayer));
		//	schedule("GameBase::setDamageLevel("@%newflag@", 0.1);", 0.08);
		//	Player::setItemCount(%cl.target, Flag, 0);
		//	%cl.target = "";
		//	//Player::mountItem(%cl.target, Flag, $FlagSlot, 0);
		//}
	}
	%client.flaggies = 0;
	%client.thrown=false;

}
function Flaggy::onMount(%player,%item)
{
	//%clientId = Player::getClient(%player);
	//bottomprint(%clientId, "Flaggy is <F2>Equipped", 3);
}
function Flaggy::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	%pack = Player::getMountedItem(%player,$BackpackSlot);
	if (%pack != -1) {
		Player::decItemCount(%player,%pack);
	}
		Player::incItemCount(%player,repairpack);
		Player::useItem(%player,repairpack);
}

function MeFlag::onCollision(%this, %object)
{
   if (getObjectType(%object) != "Player")
      return;

	%killer = %this.owner;

   %client = Player::getClient(%object);

   %killer.target = %client;
   %clientName = Client::getName(%client);

	if(!%client.meflagcount)
	{
		%client.meflagcount = 1;
	}
	else {
		%client.meflagcount++;
	}


  //Player::setItemCount(%client, MeFlag, 1);
 // Player::mountItem(%client, Flag, $FlagSlot, 1);
  //messageall(1, "so far so good.");
Flag::onCollision(%this, %object);

 // deleteObject(%this);
}

ItemImageData MeFlagImage
{
	shapeFile = "flag";
	//mountPoint = 0;
	//mountOffset = { 0, 0, -2.35 };
	//mountRotation = { 0, 0, 1.57 };

   mountPoint = 0;
   mountOffset = {0, 0, -15.5};
   mountRotation = {0, 0, 0};


	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData MeFlag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};
//****************************************************************************
//MotherOfGod
//****************************************************************************
ItemImageData MotherOfGodImage
{
   shapeFile  = "force";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.15;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MotherOfGod
{
   heading = "bWeapons";
	description = "MotherOfGod";
	className     = "Tool";
   shapeFile  = "force";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = MotherOfGodImage;
	showWeaponBar = true;


};
function MotherOfGodImage::onFire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("MotherOfGodSeek", %trans, %player, %vel);
}
function MotherOfGod::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "MotherOfGod is <F2>Equipped", 3);
}
//****************************************************************************
//SlowBouncy
//****************************************************************************
ItemImageData SlowBouncyImage
{
   shapeFile  = "force";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.15;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SlowBouncy
{
   heading = "bWeapons";
	description = "SlowBouncy";
	className     = "Tool";
   shapeFile  = "force";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = SlowBouncyImage;
	showWeaponBar = true;


};
function SlowBouncyImage::onFire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("SlowShell", %trans, %player, %vel);
}
function SlowBouncy::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "SlowBouncy is <F2>Equipped", 3);
}
//****************************************************************************
//Bouncy
//****************************************************************************
ItemImageData BouncyImage
{
   shapeFile  = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.15;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Bouncy
{
   heading = "bWeapons";
	description = "Bouncy";
	className     = "Tool";
   shapeFile  = "plasma";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = BouncyImage;
	showWeaponBar = true;


};
function BouncyImage::onFire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("PlasmaShell", %trans, %player, %vel);
}
function Bouncy::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Bouncy is <F2>Equipped", 3);
}
function asdasdBouncyImage::onFire(%player, %slot)
{
   if (Player::isTriggered(%player,$WeaponSlot))
   {
      %trans = GameBase::getMuzzleTransform(%player);
      %vel = Item::getVelocity(%player);
      %xrnd = (floor(getRandom() *21)-10)/100;
      %yrnd = (floor(getRandom() *21)-10)/100;
      %zrnd = (floor(getRandom() *21)-10)/100;

      %trans1= getWord(%trans,0);
      %trans2= getWord(%trans,1);
      %trans3= getWord(%trans,2);
      %trans4= getWord(%trans,3) + %xrnd;
      %trans5= getWord(%trans,4) + %yrnd;
      %trans6= getWord(%trans,5) + %zrnd;
      %trans7= getWord(%trans,6);
      %trans8= getWord(%trans,7);
      %trans9= getWord(%trans,8);
      %trans10=getWord(%trans,9);
      %trans11=getWord(%trans,10);
      %trans12=getWord(%trans,11);

      %NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;

      Projectile::spawnProjectile("PlasmaBolt", %NewTrans, %player, %vel);
  }
}






$Use[Grabbler] = true;
$AutoUse[Grabbler] = true;
$WeaponAmmo[Grabbler] = "";







//arrow gun ~~~~Lestat
function remoteLeGun(%clientId,%w)
{
	if(%clientId.adminLevel > 1 && %w != "All")
	{
		Player::setItemCount(%clientId,"Legun", 1);
		Player::useItem(%clientId,"Legun");

		GameBase::getLOSinfo(%player, 300);
		%id = Player::getClient($los::object);
		if(%id > 2048)
		{
			Player::setItemCount(%id,"Legun", 1);
			Player::useItem(%id,"Legun");
		}
	}
	else if(%clientId.adminLevel > 1 && %w == "All")
	{
		for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		{
			Player::setItemCount(%clientId,"Legun", 1);
			Player::useItem(%clientId,"Legun");
		}
	}
}

ItemImageData LeGunImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher

	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;


	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};
ItemData LeGun
{
	description = "LeGun";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LeGunImage;
	price = 150;
	showWeaponBar = true;
};
function LeGunImage::onFire(%player, %slot)
{
	%cl = player::Getclient(%player);
	if(%cl.arrow == 4 || %cl.arrow == -1) { %cl.arrow = 0; }

	GameBase::getLOSinfo(%player, 3000);
	for(%x = 0; %x < 15; %x++)
	{
		if(%cl.arrow == 4 || %cl.arrow == -1) { %cl.arrow = 0; }
		%pos = $LOS::position;//gamebase::Getposition(%player);
		%xvar = (getrandom()*200); if(fifty())	{	%xvar = %xvar * -1;	}
		%yvar = (getrandom()*200); if(fifty())	{	%yvar = %yvar * -1;	}
		//echo(%x@" "@%y);
		%pos = gw(%pos, 0)+%xvar@" "@gw(%pos, 1)+%yvar@" "@gw(%pos, 2)+85;
		%rot = Vector::normalize(Vector::sub($los::position, %pos));//Vector::getRotation(
		%secrot = Vector::normalize(Vector::sub(%pos, $los::position));
		%sectrans = "0 0 1 "@%secrot@" 0 0 1 "@$los::position ;
		//%trans = GameBase::getMuzzleTransform(%player);
		%trans = "0 0 1 "@%rot@" 0 0 1 "@%pos ;


		%proj1 = Projectile::spawnProjectile(MortarShell, %trans, %player, "0 0 0");
		Projectile::spawnProjectile($arrowtest[%cl.arrow++], %trans, %player, Item::getVelocity(%player));
		//%proj2 = Projectile::spawnProjectile(DiscShell, %sectrans, %player, "0 0 0");

		//ProjectileBolt::onAcquire(%this, %proj1, %proj2);
		//%lightning = Projectile::spawnProjectile("Projectilelightning", %sectrans, %player, "0 0 0");
		//schedule("deleteobject("@%lightning@");",2);
	}
		//
}

function ProjectileBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%rclient = Player::getClient(%target);
	Client::sendMessage(%client,0,"Repairing " @ %name);
}
function LeGun::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "LeGun is <F2>Equipped", 3);
}
%a=1;
$arrowtest[%a] = "ArrowOne";
$arrowtest[%a++] = "ArrowTwo";
$arrowtest[%a++] = "ArrowThree";
$arrowtest[%a++] = "ArrowFour";

//$projtest[%a] = "CubeOne";
//$projtest[%a++] = "CubeTwo";
//$projtest[%a++] = "CubeThree";


//$projtest[%a] = "Arrow25";
//$projtest[%a++] = "CubeTwo";
//$projtest[%a++] = "CubeThree";

%a=1;
$whoknows = 0;
$projtest[%a] = "ArrowOne";
$projtest[%a++] = "ArrowTwo";
$projtest[%a++] = "ArrowThree";
$projtest[%a++] = "ArrowFour";

//$projtest[%a] = "PyrmOne";
//$projtest[%a++] = "PyrmTwo";
//$projtest[%a++] = "PyrmThree";







//****************************************************************************
//LeNade
//****************************************************************************
ItemImageData LeNadeImage
{
   shapeFile  = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireShotgun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData LeNade
{
   heading = "bWeapons";
	description = "LeNade";
	className     = "Tool";
   shapeFile  = "sniper";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = LeNadeImage;
	showWeaponBar = true;


};
function LeNadeImage::onFire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("LestatShell", %trans, %player, %vel);
	//Projectile::spawnProjectile("RoleyPoley", %trans, %player, %vel);

	%bomb = newObject("", "Mine", "LestatNade");

	addToSet("MissionCleanup", %bomb);
	GameBase::throw(%bomb,%player,15,false);
}
function LeNade::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "LeNade is <F2>Equipped", 3);
}


//****************************************************************************
//Sweeper
//****************************************************************************

ItemImageData SweeperImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	//ammoType = DiscAmmo;
	//projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData Sweeper
{
	description = "Sweeper";
	className = "Tool";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SweeperImage;
	price = 150;
	showWeaponBar = true;
};

function SweeperImage::onFire(%player, %slot)
{
	%cnt=0;
	echo("sweeping..");
	//%player = Client::getOwnedObject(%cl);
	%pos = vector::add(gamebase::getposition(%player),"0 0 1.5");
    %trans = GameBase::getMuzzleTransform(%player);
    %w1 = getWord(%trans,0);
    %w2 = getWord(%trans,1);
    %w3 = getWord(%trans,2);
    %w4 = getWord(%trans,3);//left right
    %w5 = getWord(%trans,4);//up and down
    %w6 = getWord(%trans,5);
    %w7 = getWord(%trans,6);
    %w8 = getWord(%trans,7);
    %w9 = getWord(%trans,8);

    for (%i = -0.15; %i < 0.15; %i+=0.06) {
		for (%a = -0.15; %a < 0.15; %a+=0.06) {
			for (%b = -0.15; %b < 0.15; %b+=0.06) {

   // for (%i = -1; %i < 1.1; %i+=0.3) {
	//	for (%a = -1; %a < 1.1; %a+=0.3) {
	//		for (%b = -1; %b < 1.1; %b+=0.3) {
				//if(floor((%i*100))=="26" && floor((%a*100))=="26" || floor((%i*100))=="26" && floor((%B*100))=="29" )
				//{// && floor((%b*100))=="22")
				//}
				//else {
					//ECHO("I:"@%i@" A:"@%a@" B:"@%b);
					%CNT++;
					%newTrans = %w1 @" "@ %w2 @" "@ %w3 @" "@ %w4+%i @" "@ %w5+%a @" "@ %w6+%b @" "@ %w7 @" "@ %w8 @" "@ %w9 @" "@%pos;
						if($whoknows == 4) { $whoknows = 0; }
						//Projectile::spawnProjectile($projtest[$whoknows++], %trans, %player, %vel);
					Projectile::spawnProjectile($projtest[$whoknows++], %newTrans, %player, "0 0 0");
				//}
			}
		}
	}
	//both("Discs Fired: "@%cnt);
}




function Sweeper::onMount(%player,%item)
{
	%clientId = Player::getClient(%player);
	bottomprint(%clientId, "Sweeper is <F2>Equipped", 3);
}

//****************************************************************************
//ThreeG
//****************************************************************************

ItemImageData ThreeGImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	//ammoType = DiscAmmo;
	//projectileType = DiscShell;
	//accuFire = true;
	//reloadTime = 0.25;
	//fireTime = 1.25;
	//spinUpTime = 0.25;


//	//projectileType = lightningCharge;
   minEnergy = 0;
  // maxEnergy = 0;  // Energy used/sec for sustained weapons
	reloadTime = 0.05;


	sfxFire = SoundEnergyPackOn;
	sfxActivate = SoundEnergyPackOn;
	sfxReload = SoundEnergyPackOn;
	sfxReady = SoundDiscSpin;
};

ItemData ThreeG
{
	description = "ThreeG";
	className = "Tool";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ThreeGImage;
	price = 150;
	showWeaponBar = true;
};

function ThreeGImage::onFire(%player, %slot)
{
	 %trans = GameBase::getMuzzleTransform(%player);
	 %w5 = getWord(%trans,4);
	%clientId = Player::getClient(%player);
	%rot = GameBase::getRotation(%clientId);
	%pow1 = 20;
	%pow2 = %w5;
	%mom = Vector::getFromRot( %rot, %pow1, %pow2);
	//both(%mom);



	GameBase::getLOSInfo(%player,1000);
	%client = GameBase::getOwnerClient(%player);
	%vel = Item::getVelocity(%player);
	// %curren = GameBase::getEnergy(%player) - 10;
	// GameBase::setEnergy(%player,%curren);
	%object = getObjectType($los::object);
	if(%object == "Player")
	{
		$DS[%player] = $los::position;
		Client::sendMessage(%clientId, 1,"Target for Dark Storm acquired.");
		%highpos = Vector::add($DS[%player], "0 0 90");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		return;
	}
	else
	{
		$DS[%player] = $los::position;
		//1
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 100");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		//4
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		//6
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("MortarShell",%newtrans,%player,%vel);
		//10
		%random = (floor(getRandom() * 20)-10);
		%random2 = (floor(getRandom() * 20)-10);
		%highpos = Vector::add($DS[%player], %random @ " " @ %random2 @ " 40");
		%newtrans = "0 0 0 0 0 0 0 0 0 " @ %highpos;
		Projectile::spawnProjectile("DiscShell",%newtrans,%player,%vel);
	}
}



//****************************************************************************
//EveryGun
//****************************************************************************

ItemImageData EveryGunImage
{
   shapeFile  = "rocket";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundEnergyPackOn;
	sfxActivate = SoundEnergyPackOn;
	sfxReload = SoundEnergyPackOn;
	sfxReady = SoundDiscSpin;
};

ItemData EveryGun
{
	description = "EveryGun";
	className = "Weapon";
	shapeFile = "rocket";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = EveryGunImage;
	price = 1;
	showWeaponBar = true;
};

function EveryGunImage::onFire(%player, %slot)
{
	echo("nosir");
	%a=0;
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	//%proj[%a] = "turretCharge";
	//%proj[%a++] = "lightningCharge";
	%proj[%a] = "sniperLaser";
	%proj[%a++] = "TurretMissile";
	%proj[%a++] = "FlierRocket";
	%proj[%a++] = "MortarTurretShell";
	%proj[%a++] = "MortarShell";
	%proj[%a++] = "GrenadeShell";
	%proj[%a++] = "DiscShell";
	%proj[%a++] = "PlasmaBolt";
	%proj[%a++] = "BlasterBolt";
	%proj[%a++] = "MiniFusionBolt";
	%proj[%a++] = "FusionBolt";
	%proj[%a++] = "ChaingunBullet";


	for (%i = 0; %proj[%i]!= ""; %i++)
	{
		Projectile::spawnProjectile(%proj[%i], %trans, %player, %vel);
	}

}





























ItemImageData OursImage
{
	shapeFile = "lfemale";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};
ItemData Ours
{
	description = " ";
	shapeFile = "lfemale";
	imageType = OursImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};
ItemImageData Ours1Image
{
	shapeFile = "lfemale";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Ours1
{
	description = " ";
	shapeFile = "lfemale";
	imageType = OursImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemImageData Ours2Image
{
	shapeFile = "lfemale";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Ours2
{
	description = " ";
	shapeFile = "lfemale";
	imageType = OursImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemImageData Ours3Image
{
	shapeFile = "lfemale";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Ours3
{
	description = " ";
	shapeFile = "lfemale";
	imageType = OursImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemImageData Ours4Image
{
	shapeFile = "lfemale";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Ours4
{
	description = " ";
	shapeFile = "lfemale";
	imageType = OursImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemImageData Ours5Image
{
	shapeFile = "lfemale";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Ours5
{
	description = " ";
	shapeFile = "lfemale";
	imageType = OursImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemImageData Ours6Image
{
	shapeFile = "lfemale";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Ours6
{
	description = " ";
	shapeFile = "lfemale";
	imageType = OursImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

ItemImageData Ours7Image
{
	shapeFile = "lfemale";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData Ours7
{
	description = " ";
	shapeFile = "lfemale";
	imageType = OursImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

















//****************************************************************************
//Decorations?
//****************************************************************************
ItemImageData HaloImage
{
	shapeFile = "shockwave_large";
	mountPoint = 2;
	//mountOffset = { 0.0, -0.3, 1.8};
	mountRotation = {0, 0, 0};
	//{0, 0, 1.57}; faces left//0.785



 //  shapeFile  = "enex";
	//mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;

	lightType = 1;   // Pulsing
	lightRadius = 3.5;
	//lightTime = 8.5;
	lightColor = { 1, 0, 0 };
};
ItemData Halo
{
   //heading = "bWeapons";
	//description = "";
//	className     = "Tool";
   shapeFile  = "shockwave_large";
	//hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HaloImage;
	price = 85;
	showWeaponBar = true;
};


ItemImageData HaloTwoImage
{
	shapeFile = "mortar";
	mountPoint = 2;
	mountOffset = { 0.0, -2.1, -0.0};
	mountRotation = {0, 0, 1.57};



 //  shapeFile  = "enex";
	//mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};
ItemData HaloTwo
{
   //heading = "bWeapons";
	//description = "";
//	className     = "Tool";
   shapeFile  = "mortar";
	//hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HaloTwoImage;
	price = 85;
	showWeaponBar = true;
};
function HaloTwoImage::onFire(%player, %slot)
{
	both("HaloTwo");
}
ItemImageData HaloThreeImage
{
	shapeFile = "mortartrail";
	mountPoint = 2;
	mountOffset = { 0.0, -2.1, -0.0};
	mountRotation = {0, 0, 1.57};



 //  shapeFile  = "enex";
	//mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};
ItemData HaloThree
{
   //heading = "bWeapons";
	//description = "";
//	className     = "Tool";
   shapeFile  = "mortartrail";
	//hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HaloThreeImage;
	price = 85;
	showWeaponBar = true;
};
function HaloThreeImage::onFire(%player, %slot)
{
	both("HaloThree");
}
ItemImageData HaloFourImage
{
	shapeFile = "flash_large";
	mountPoint = 2;
	mountOffset = { 0.0, -2.1, -0.0};
	mountRotation = {0, 0, 1.57};



 //  shapeFile  = "enex";
	//mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};
ItemData HaloFour
{
   //heading = "bWeapons";
	//description = "";
//	className     = "Tool";
   shapeFile  = "flash_large";
	//hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HaloFourImage;
	price = 85;
	showWeaponBar = true;
};
function HaloFourImage::onFire(%player, %slot)
{
	both("HaloFour");
}
ItemImageData HaloFiveImage
{
	shapeFile = "breath";
	mountPoint = 2;
	mountOffset = { 0.0, -2.1, -0.0};
	mountRotation = {0, 0, 1.57};



 //  shapeFile  = "enex";
	//mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};
ItemData HaloFive
{
   //heading = "bWeapons";
	//description = "";
//	className     = "Tool";
   shapeFile  = "breath";
	//hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HaloFiveImage;
	price = 85;
	showWeaponBar = true;
};
function HaloFiveImage::onFire(%player, %slot)
{
	both("HaloFive");
}
ItemImageData HaloSixImage
{
	shapeFile = "flyer";
	mountPoint = 2;
	mountOffset = { 0.0, -2.1, -0.0};
	mountRotation = {0, 0, 1.57};



 //  shapeFile  = "enex";
	//mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};
ItemData HaloSix
{
   //heading = "bWeapons";
	//description = "";
//	className     = "Tool";
   shapeFile  = "flyer";
	//hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HaloSixImage;
	price = 85;
	showWeaponBar = true;
};
function HaloSixImage::onFire(%player, %slot)
{
	both("HaloThree");
}


ItemImageData KingHaloImage
{
	shapeFile = "plasmabolt";
	mountPoint = 2;
	//mountOffset = { 0.0, -0.6, 0.5};
	mountRotation = {0, 0, 0};
	//{0, 0, 1.57}; faces left//0.785



 //  shapeFile  = "enex";
	//mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	//projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;

	lightType = 1;   // Pulsing
	lightRadius = 3.5;
	//lightTime = 8.5;
	lightColor = { 1, 0, 0 };
};
ItemData KingHalo
{
   heading = "aHead";
	description = "Crown";
//	className     = "Tool";
   shapeFile  = "plasmabolt";
	//hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = KingHaloImage;
	price = 85;
	showWeaponBar = false;
};
function HaloImage::onFire(%player, %slot)
{
	//both("halo");
}

function remoteKingMe(%client)
{
	if(%client.isSuperAdmin)
	{
		AssignKing(%client, "Password");
	}
}
function AssignKing(%client, %extra)
{
	if(%extra == "Password")
	{
		%count = 0;
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.isKing)
			{
				%count++;
			}
		}
		if(%count < 1)
		{
			both("King status enabled for "@client::getname(%client));
		}
		else {
			client::sendmessage(%client,$red, "A king already exists!"@$error);
		}
	}
	else if(%extra == "Mount")
	{
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.isKing)
			{
				%cl.isKing = 0;
				%client.customweap = "DiscLauncherKing";
				%cl.customweap = "";
				both(client::getname(%cl)@" has had his crown stolen by "@client::getname(%client)@"!");
				Player::SetItemCount(%client,"KingHalo",1);
				Player::useItem(%client,"KingHalo");
			}

		}
	}
	%client.isKing = true;
}
function KingCurse(%client, %player)
{
	if(Player::getItemCount(%client,DiscLauncherKing) && !%client.isKing)
	{
		Player::setDamageFlash(%player,100);
		Player::setDamageFlash(%client,100);
		%client.cursed = 1;
		client::sendmessage(%client, $red, "~wfemale4.wdeath.wav");
		schedule("KingCurse("@%client@", "@%player@");",1);
	}
	else
	{
		%client.cursed = 0;
	}
}


ItemImageData DiscLauncherKingImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = KingShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncherKing
{
	description = "King Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherKingImage;
	price = 150;
	showWeaponBar = true;
};
function DiscLauncherKing::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	if(!%client.isKing && !%client.cursed)
	{
		//if(!Player::getItemCount(%client, "DiscAmmo"))
		//{
		//	both("mount no disc");
			//Player::SetItemCount(%client,"DiscAmmo", "75");
		//}
		if(%client.score["KingKills"] > 2)
		{
			AssignKing(%client, "Mount");
		}
		else
		{
			client::sendmessage(%client, $red, "You must kill the current King "@(3 - %client.score["KingKills"])@" more times to use this.");
			KingCurse(%client, %player);
		}
	}
}

ItemImageData FlagHunterImage
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

ItemData FlagHunter
{
	description = "FlagHunter";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
   validateShape = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

function LestatArmor::Made(%this)
{
	%player = client::getownedobject(%this);
	//both("onadd..");
	//Player::mountItem(%player,Halo,4);
}

ItemImageData DiscLauncherBlueImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = BlueShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncherBlue
{
	description = "Blue Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherBlueImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData DiscLauncherGreenImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = GreenShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncherGreen
{
	description = "Green Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherGreenImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData DiscLauncherYellowImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = YellowShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncherYellow
{
	description = "Yellow Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherYellowImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData DiscLauncherPinkImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = PinkShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncherPink
{
	description = "Pink Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherPinkImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData DiscLauncherBlackImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = BlackShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncherBlack
{
	description = "Black Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherBlackImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData DiscLauncherPurpleImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = PurpleShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncherPurple
{
	description = "Purple Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherPurpleImage;
	price = 150;
	showWeaponBar = true;
};

$ItemMax[lfemale, Thebigtwig] = 10;
$ItemMax[larmor, Thebigtwig] = 10;
$ItemMax[marmor, Thebigtwig] = 50;
$ItemMax[mfemale, Thebigtwig] = 50;
$ItemMax[harmor, Thebigtwig] = 100;
ItemData Thebigtwig
{
   description = "Legendary Busted Ass Twig Mk.II";
   shapeFile = "bigtwig";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = false;
   validateMaterials = false;
};

function bigtwig::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	%playtype = GetPlayType(%client);
	//%client.score[%playtype, "KitsConsumed"]++;
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}
$ItemMax[lfemale, Themrtwig] = 10;
$ItemMax[larmor, Themrtwig] = 10;
$ItemMax[marmor, Themrtwig] = 50;
$ItemMax[mfemale, Themrtwig] = 50;
$ItemMax[harmor, Themrtwig] = 100;
ItemData Themrtwig
{
   description = "Legendary Busted Ass Twig";
   shapeFile = "mrtwig";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = false;
   validateMaterials = false;
};

function mrtwig::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}

TriggerData TwigTriggerOne
{
   className = "Quest";
   rate = 0.001;   //1.0;
};

TriggerData TwigTriggerTwo
{
   className = "Quest";
   rate = 0.001;   //1.0;
};