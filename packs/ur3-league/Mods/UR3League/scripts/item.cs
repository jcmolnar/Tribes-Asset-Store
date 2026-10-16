//----------------------------------------------------------------------------

$ItemFavoritesKey = "UR3L17";  // Change this if you add new items
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

$AutoUse[Blaster] = False;
$AutoUse[Chaingun] = False;
$AutoUse[PlasmaGun] = False;
$AutoUse[Mortar] = False;
$AutoUse[GrenadeLauncher] = False;
$AutoUse[LaserRifle] = False;
$AutoUse[EnergyRifle] = False;
$AutoUse[AssaultRifle] = False;
$AutoUse[Railgun] = False;
$AutoUse[FFBLauncher] = False;
$AutoUse[RocketLauncher] = False; 
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = False;
$AutoUse[CloakGun] = False;

$Use[Blaster] = True;

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
$SellAmmo[BulletAmmo] = 500;
$SellAmmo[PlasmaAmmo] = 50;
$SellAmmo[DiscAmmo] = 199;
$SellAmmo[GrenadeAmmo] = 50;
$SellAmmo[MortarAmmo] = 50;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[RifleAmmo] = 500;
$SellAmmo[MayhemAmmo] = 500;
$SellAmmo[RailAmmo] = 250;
$SellAmmo[FFBAmmo] = 10;
$SellAmmo[RocketAmmo] = 10;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 50;
$AmmoPackMax[DiscAmmo] = 50;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 0;
$AmmoPackMax[Beacon] = 5;
$AmmoPackMax[RifleAmmo] = 250;
$AmmoPackMax[MayhemAmmo] = 250;
$AmmoPackMax[RailAmmo] = 250;
$AmmoPackMax[FFBAmmo] = 10;
$AmmoPackMax[RocketAmmo] = 10;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = RifleAmmo;
$AmmoPackItems[9] = Mayhem;
$AmmoPackItems[10] = RailAmmo;
$AmmoPackItems[11] = FFBAmmo;
$AmmoPackItems[12] = RocketAmmo; 


// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 0;
$TeamItemMax[DeployableInvPack] = 10;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[ForceFieldPack]= 3;
$TeamItemMax[LargeFieldPack] = 2;
$TeamItemMax[RocketPack] = 0; 
$TeamItemMax[CameraPack] = 12;
$TeamItemMax[SpySatellitePack] = 1;
$TeamItemMax[DeployableSensorJammerPack] = 12;
$TeamItemMax[PulseSensorPack] = 6;
$TeamItemMax[MotionSensorPack] = 12;
$TeamItemMax[ScoutVehicle] = 10;
$TeamItemMax[HAPCVehicle] = 10;
$TeamItemMax[LAPCVehicle] = 10;
$TeamItemMax[Beacon] = 100;
$TeamItemMax[mineammo] = 100;
$TeamItemMax[RocketPack] = 4;
$TeamItemMax[TaserTrtCPack] = 2;
$TeamItemMax[HellPack] = 2;
$TeamItemMax[DeployableTeleport] = 3;

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
$WeaponAmmo[AssaultRifle] = MayhemAmmo;
$WeaponAmmo[Railgun] = RailAmmo;
$WeaponAmmo[FFBLauncher] = FFBAmmo;
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[CloakGun] = ""; 


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
// gwDropFlood by {187}George W.
// flood protection on dropping items
// lag/vulnerability fix
	%item = getItemData(%type);
	if((Client::getOwnedObject(%client)).driver != 1) {
		if(%item!="flag")
		{
				if(%client.dropflooded) 
				{
					if(%client.dropwarn)
					{
						client::sendmessage(%client, 1, "No more dropping for a while.~wmale3.wno.wav");
						%client.dropwarn = false;
						schedule(%client@".dropwarn=true;",1,%client);
					}
					return;
				}
				%client.dropfloodcount++;
				schedule(%client@".dropfloodcount=0;",5,%client);
				if(%client.dropfloodcount>200) {
					%client.dropflooded = true;
					%client.dropwarn = true;
					schedule(%client@".dropflooded=false;",20,%client);
					client::sendmessage(%client, 1, "No dropping for 20 seconds.~wmale3.wno.wav");
				}
		}
			 
		//echo("Drop item: ",%type);
		%client.throwStrength = 1;


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
$NextWeapon[GrenadeLauncher] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = AssaultRifle;
$NextWeapon[AssaultRifle] = LiLPOOmkii;
$NextWeapon[LiLPOOmkii] = m16;
$NextWeapon[m16] = Railgun;
$NextWeapon[Railgun] = CloakGun;
$NextWeapon[CloakGun] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = RocketLauncher; 
$NextWeapon[RocketLauncher] = FFBLauncher;
$NextWeapon[FFBLauncher] = EnergyRifle;
$NextWeapon[EnergyRifle] = TaserRifle;
$NextWeapon[TaserRifle] = GrenadeLauncher;

$PrevWeapon[Blaster] = GrenadeLauncher;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[AssaultRifle] = DiscLauncher;
$PrevWeapon[LiLPOOmkii] = AssaultRifle;
$PrevWeapon[m16] = LiLPOOmkii;
$PrevWeapon[Railgun] = m16;
$PrevWeapon[CloakGun] = Railgun;
$PrevWeapon[Mortar] = CloakGun;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[RocketLauncher] = LaserRifle; 
$PrevWeapon[FFBLauncher] = RocketLauncher;
$PrevWeapon[EnergyRifle] = FFBLauncher;
$PrevWeapon[TaserRifle] = EnergyRifle;
$PrevWeapon[GrenadeLauncher] = TaserRifle;

function remoteNextWeapon(%client)
{
	if(!(%client.observerMode == "" || %client.observerMode == "pregame")){
		return;
		}
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
	if(!(%client.observerMode != "" || %client.observerMode != "pregame")){
		return;
		}
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
        reloadTime = 0.01;
        fireTime = 0.01;
        minEnergy = 1;
        maxEnergy = 1;

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
   	validateShape      = true;
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
	spinUpTime = 0.2;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	projectileType = LeaveThisAlone;
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
	description = "Verminator";
	className = "Weapon";
	shapeFile = "chaingun";
   	validateShape      = true;
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};
function ChaingunImage::onFire(%player, %slot) 
{
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Chaingun]);
   if(%AmmoCount) 
      { 
	   Player::decItemCount(%player,$WeaponAmmo[Chaingun],1); 
	   %trans = GameBase::getMuzzleTransform(%player); 
	   %vel = Item::getVelocity(%player);
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
 	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
	} 
   else Client::sendMessage(Player::getClient(%player), 0,"Verminator has no ammo."); 
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
        reloadTime = 0.05;
        fireTime = 0.05;

        lightType = 3;  // Weapon Fire
        lightRadius = 1.5;
        lightTime = 0.05;
        lightColor = { 1, 1, 0 };

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
   	validateShape      = true;
};


//----------------------------------------------------------------------------

ItemData GrenadeAmmo
{
        description = "GrenadeAmmo";
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
        reloadTime = 0.075;
        fireTime = 0.05;

        lightType = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime = 0.1;
        lightColor = { 1, 1, 1 };

        sfxFire = SoundFireGrenade;
        sfxActivate = SoundPickUpWeapon;
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
   	validateShape      = true;
};

//----------------------------------------------------------------------------

ItemData MortarAmmo
{
        description = "MortarAmmo";
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
        fireTime = 0.1;

        lightType = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime = 0.05;
        lightColor = { 0, 1, 1 };

        sfxFire = SoundFireMortar;
        sfxActivate = SoundPickUpWeapon;
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
        reloadTime = 0.02;
        fireTime = 0.01;
        spinUpTime = 0.05;

        sfxFire = SoundFireDisc;
        sfxActivate = SoundPickUpWeapon;
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
   validateShape = false;
};


//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
        shapeFile = "sniper";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        projectileType = ThisShouldBeUndefined;
        accuFire = true;
        reloadTime = 0.05;
        fireTime = 0.05;
        minEnergy = 1;
        maxEnergy = 100;

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
   	validateShape      = true;
   validateMaterials = false;
};
function LaserRifleImage::onFire(%player, %slot) 
{ 
	   Player::decItemCount(%player,$WeaponAmmo[Chaingun],1); 
	   %trans = GameBase::getMuzzleTransform(%player); 
	   %vel = Item::getVelocity(%player);
	   %energy = GameBase::getEnergy(%player);
	   Projectile::spawnProjectile("SniperLaser",%trans,%player,%vel);
 	   GameBase::setEnergy(%player, %energy - 10);
}

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
        shapeFile = "paintgun";
        mountPoint = 0;

        weaponType = 2; // Sustained
        projectileType = targetLaser;
        accuFire = true;
        minEnergy = 1;
        maxEnergy = 2;
        reloadTime = 0.1;

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
	%clientId = Player::getClient(%player);
	%playerteam = GameBase::getTeam(%player);
	%playerpos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%pos = %flag.originalposition;
	%playerposX = getWord(%playerpos,0);
	%playerposY = getWord(%playerpos,1);
	%playerposZ = getWord(%playerpos,2)*1;
	%posX = getWord(%pos,0);
	%posY = getWord(%pos,1);
	%posZ = getWord(%pos,2)*1;
	%distance = (%playerposZ - %posZ)*1;
	if(%playerposZ > %posZ)
		{
		bottomprint(%clientId, "<jc><f0>You are <f1>" @ %distance @ " <f0>meters <f1>ABOVE <f0>your flag.", 3);
		}
	else
		{
		bottomprint(%clientId, "<jc><f1>You are <f0>" @ %distance * -1 @ " <f1>meters <f0>BELOW <f1>your flag.", 3);
		}
}



//------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 1;
   maxEnergy = 3;  // Energy used/sec for sustained weapons
	reloadTime = 0.01;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 1;
   lightTime = 0.1;
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
   	validateShape      = true;
};

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 1;
	maxEnergy = 1;  // Energy used/sec for sustained weapons

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
   	validateShape      = true;
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

ItemData RifleAmmo { description = "IX-2000 Ammo"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 5; };
//----------------------------------------------------------------------------

ItemData MayhemAmmo { description = "IX-2000 Ammo Mayhem"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; };

ItemImageData AssaultRifleImage { shapeFile = "sniper"; mountPoint = 0;  weaponType = 0; ammoType = MayhemAmmo; projectileType = AssaultBullet; accuFire = true; reloadTime = 0.01; fireTime = 0.1; lightType = 3; lightRadius = 2; lightTime = 0.01; lightColor = { 1, 0, 0 }; sfxFire = SoundDryFire; sfxActivate = SoundPickUpWeapon; };

ItemData AssaultRifle { description = "IX-2000 Mayhem Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "sniper"; heading = "bWeapons"; shadowDetailMask = 4; imageType = AssaultRifleImage; price = 300; showWeaponBar = true;    validateShape = false;   validateMaterials = false; };

//----------------------------------------------------------------------------
//--------------------------

ItemData RailAmmo { description = "Railgun Bolt"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; };

ItemImageData RailgunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = RailAmmo; projectileType = RailRound; accuFire = true; reloadTime = 0.03; fireTime = 0.02; lightType = 3; lightRadius = 0.5; lightTime = 0.01; lightColor = { 1, 0, 0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; };

//----------------------------------------------------------------------------

ItemData Railgun { description = "Railgun"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = RailgunImage; price = 375; showWeaponBar = true;    validateShape = false;   validateMaterials = false; };

//----------------------------------------------------------------------------

ItemData FFBAmmo { description = "FFB Ammo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "grenammo"; shadowDetailMask = 4; price = 50; }; ItemImageData FFBImage { shapeFile = "mortargun"; mountPoint = 0;   mountRotation = { 0, 0.785, 0 }; weaponType = 0; ammoType = FFBAmmo; projectileType = FFBShell; accuFire = false; reloadTime = 2; fireTime = 0; lightType = 3; lightRadius = 4; lightTime = 1; lightColor = { 0, 0, 1 }; sfxFire = SoundFireGrenade; sfxActivate = SoundPickUpWeapon; sfxReady = SoundMortarIdle; };

//----------------------------------------------------------------------------

ItemData FFBLauncher { description = "Force Field Buster"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "plasma"; heading = "bWeapons"; shadowDetailMask = 4; imageType = FFBImage; price = 475; showWeaponBar = true;    validateShape = false; };

//----------------------------------------------------------------------------

ItemData RocketAmmo 
{ 
   description = "Rockets"; 
   className = "Ammo"; 
   heading = "xAmmunition"; 
   shapeFile = "rocket"; 
   shadowDetailMask = 4; 
   price = 50; 
}; 

ItemImageData RocketImage 
{ 
   shapeFile = "grenadeL"; 
   mountPoint = 0;   
   mountRotation = { 0, 0.785, 0 }; 
   weaponType = 0; 
   ammoType = RocketAmmo; 
   projectileType = ThisShouldBeUndefined; 
   accuFire = true; 
   reloadTime = 1.5; 
   fireTime = 0.8; 
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 1; 
   lightColor = { 1, 1, 1 }; 
   //sfxFire = SoundSalvoLaunch; 
   sfxActivate = SoundMortarTurretTurn; 
   sfxReload = SoundMortarTurretOn;
   sfxReady = SoundMineActivate; 
};

ItemData RocketLauncher 
{ 
   description = "Rocket Launcher"; 
   className = "Weapon"; 
   shapeFile = "grenadeL"; 
   hudIcon = "energypack"; 
   heading = "bWeapons"; 
   shadowDetailMask = 4; 
   imageType = RocketImage; 
   price = 375; 
   showWeaponBar = true;   
   	validateShape      = true; 
}; 
function RocketImage::onFire(%player, %slot) 
{ 
	GameBase::playSound(%player, SoundSalvoLaunch, 0);
	schedule("RocketLauncher::fireRockets(" @ %player @ ",3);",0.05,%player);
	schedule("GameBase::playSound(%player, SoundSalvoLaunch, 0);",0.05);
	schedule("GameBase::playSound(%player, SoundSalvoLaunch, 0);",0.10);
}

function RocketLauncher::fireRockets(%player,%count)
{
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
   if(%AmmoCount) 
	{
   	   %client = GameBase::getControlClient(%player);
   	   if(Player::getItemCount(%player,RocketAmmo)) 
		{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("Rocket",%trans,%player,%vel);  
		%count--;
		}
	   if(%count && Player::getItemCount(%player,RocketAmmo))
	   schedule("RocketLauncher::fireRockets(" @ %player @ "," @ %count @ ");",0.2,%player);
	   Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
	} 
   else Client::sendMessage(Player::getClient(%player), 0,"***Out of Rockets***.~wAccess_Denied.wav");
}
//----------------------------------------------------------------------------

ItemImageData CloakGunImage
{
   shapeFile = "shotgun";
   mountPoint = 0;
   mountRotation = { 0, 0.785, 0 };

   weaponType = 2;  // Sustained
   projectileType = cloakingCharge;
   minEnergy = 3;
   maxEnergy = 3;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 3;
   lightTime = 1;
   lightColor = { 0.15, 0.85, 0.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData CloakGun
{
   description = "Cloaking Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = CloakGunImage;
	showWeaponBar = true;
   price = 900;
   	validateShape      = true;
};

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
	validateShape      = true;
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
	validateShape      = true;
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
ItemImageData ForceFieldPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ForceFieldPack
{	
	description = "Small Force Field";
	shapefile = "ammopack";
	validateShape      = true;
	classname = "Backpack";
	heading = "kForce Fields";
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function ForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (ForceFieldPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function ForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						// if player is within 30 yards of flag cannot deploy
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = gamebase::getPosition(%flag);
						echo("%flagpos " @ %flagpos);
						echo("%playerpos " @ %playerpos);
						if(Vector::getDistance(%flagpos, %playerpos) > 3)
						{
							%inv = newObject("","StaticShape","SmallForceField",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"Small Force Field  deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "ForceFieldPack"]++;
							echo("MSG: ",%client," deployed a Small Force Fieldl");
							return true;
						}
						else
							Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag.");
							return false;
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

// ****

ItemImageData LargeFieldPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LargeFieldPack
{	
	description = "Large Force Field";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "kForce Fields";
	imageType = LargeFieldPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function LargeFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeFieldPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function LargeFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
					if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						// if player is within 30 yards of flag cannot deploy
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = gamebase::getPosition(%flag);
						echo("%flagpos " @ %flagpos);
						echo("%playerpos " @ %playerpos);
						if(Vector::getDistance(%flagpos, %playerpos) > 5)
						{
							%inv = newObject("","StaticShape","LargeForceField",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"Large Force Field deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "LargeFieldPack"]++;
							echo("MSG: ",%client," deployed a Large Force Field");
							return true;
						}
						else
							Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag.");
							return false;
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
//------------------------------------------------------------------------------------------------------------------

ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -5;
 	maxEnergy = -10;
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
   	validateShape      = true;
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
   	validateShape      = true;
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
	minEnergy = 1;
	maxEnergy = 7;   // Energy/sec for sustained weapons
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
   	validateShape      = true;
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
ItemImageData ResupplyPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 1;
	maxEnergy = 1;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ResupplyPack
{
	description = "Resupply Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ResupplyPackImage;
	price = 666;
	hudIcon = "sniper";
	showWeaponBar = true;
	hiliteOnActive = true;
   	validateShape      = true;
   validateMaterials = false;
};

function ResupplyPackImage::onActivate(%clientId,%player,%imageSlot)
{
	%armor = Player::getArmor(%clientId);
	Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
	Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
	Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
	Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
	Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);
	Player::setItemCount(%clientId,MayhemAmmo,$ItemMax[%armor, MayhemAmmo]);
	Player::setItemCount(%clientId,RailAmmo,$ItemMax[%armor, RailAmmo]);
	Player::setItemCount(%clientId,FFBAmmo,$ItemMax[%armor, FFBAmmo]);
	Player::setItemCount(%clientId,RocketAmmo,$ItemMax[%armor, RocketAmmo]);
	Player::setItemCount(%clientId,RepairKit,$ItemMax[%armor, RepairKit]);
	Player::setItemCount(%clientId,m16ammo,$ItemMax[%armor, m16ammo]);
	Player::setItemCount(%clientId,LiLPOOmkiiAmmo,$ItemMax[%armor, LiLPOOmkiiAmmo]);
	Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);
	Player::setItemCount(%clientId,Grenade,$ItemMax[%armor, Grenade]);
	Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);

Player::setItemCount(%clientId,ResupplyPack,0);

}

function ResupplyPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}


//----------------------------------------------------------------------------

ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 3;  // Energy used/sec for sustained weapons
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
   	validateShape      = true;
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
		validateShape      = true;
};

function AmmoPack::onDrop(%player, %item)
{
        if($matchStarted) {
                %item = Item::onDrop(%player,%item);
                for(%i = 0; %i < 11 ; %i = %i +1) {
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
                        else if(%i == 6) {
                             %item.Beacons = %numPack;
                        }
                        else if(%i == 7) {
                             %item.FFBAmmo = %numPack;
                        }
                        else if(%i == 8) {
                             %item.RocketAmmo = %numPack;
                        }
                        else if(%i == 9) {
                             %item.PulseSensorPack = %numPack;
                        }
                        else if(%i == 10) {
                             %item.RifleAmmo = %numPack;
                        }
                        else if(%i == 11) {
                             %item.MayhemAmmo = %numPack;
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
        for(%i = 0; %i < 11 ; %i = %i +1) {
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
            else if(%i == 6) {
            %numAdd = %item.Beacons;
            }
            else if(%i == 7) {
            %numpack = %item.FFBAmmo;
            }
            else if(%i == 8) {
            %numpack = %item.RocketAmmo;
            }

            else if(%i == 9) {
            %numpack = %item.RifleAmmo;
            }
            else if(%i == 10) {
            %numpack = %item.MayhemAmmo;
            }
            else if(%i == 11) {
            %numpack = %item.PulseSensorPack;
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
        for(%i = 0; %i < 11 ; %i = %i +1) {
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
//----------------------------------------------------------------------------
// Fake Flag Pack- 
//----------------------------------------------------------------------------

ItemData FakeFlag
{
	description = "FakeFlag";
	shapeFile = "flag";
	imageType = FakeFlagImage;
	showInventory = false;
	shadowDetailMask = 4;
};
ItemImageData FakeFlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };
};

ItemImageData FakeFlagPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 1;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData FakeFlagPack
{
	description = "Fake Flag Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FakeFlagImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   	validateShape      = true;
   validateMaterials = false;
};

function FakeFlagPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Flag Decoy On");
		GameBase::startFadeIn(FakeFlag);
}

function FakeFlagPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Flag Decoy Off");
		GameBase::startFadeOut(FakeFlag);
	Player::trigger(%player,$BackpackSlot,false);
}
//--------------------------------------------------------------------------------
ItemImageData StealthShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 1;
	maxEnergy = 7;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData StealthShieldPack
{
	description = "StealthShield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = StealthShieldPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StealthShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
	%player.shieldStrength = 0.005;
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);

}

function StealthShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
	%rate = Player::getSensorSupression(%player) - 3;
	Player::setSensorSupression(%player,%rate);

}
//------------------------------------------------------------------------------------

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

ItemImageData SpySatellitePackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData SpySatellitePack
{
	description = "Spy Satellite";
	shapeFile = "sat_big";
	className = "Backpack";
   heading = "dDeployables";
	imageType = SpySatellitePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 425;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpySatellitePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}
function SpySatellitePack::onDeploy(%player,%item,%pos)
{
	if (SpySatellitePack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "SpySatellitePack"]++;
		$TeamSpying[GameBase::getTeam(%player)] = true;
	}
}

function SpySatellitePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") 
			{
					if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
							%inv = newObject("","StaticShape","SpySatellite",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"Spy Satellite deployed");
							playSound(SoundPickupBackpack,$los::position);
							echo("MSG: ",%client," deployed a Spy Satellite");
							return true;
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on terrain");			
		}		
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
}

//----------------------------------------------------------------------------
//------------------------------------------------------------------------------------
//------------------DeployableTurret----------------Sentry Turret---------------------
//------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------

ItemImageData TurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData TurretPack
{
        description = "Sentry Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
      heading = "LTurrets";
        imageType = TurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function TurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function TurretPack::onDeploy(%player,%item,%pos)
{
        if (TurretPack::deployShape(%player,%item))
        {
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
				%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
							    %playerPos = GameBase::getPosition(%player);
							    %flag = $teamFlag[GameBase::getTeam(%player)];
							    %flagpos = %flag.originalposition;
							    if(Vector::getDistance(%flagpos, %playerpos) < 200)
							    {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Sentry Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Sentry Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Sentry Turret");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							    }	
							    else
							    {
							          Client::sendMessage(%client,1,"You may only deploy this near your base.~wError_Message.wav");
								    return false;
							    }
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
//------------------------------------------------------------------------------------
//------------------DeployableRocket----------------Rocket Turret---------------------
//------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------
						
ItemImageData RocketPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData RocketPack
{
	description = "Rocket Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "LTurrets";
	imageType = RocketPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function RocketPack::onDeploy(%player,%item,%pos)
{
	if (RocketPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function RocketPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
							    %playerPos = GameBase::getPosition(%player);
							    %flag = $teamFlag[GameBase::getTeam(%player)];
							    %flagpos = %flag.originalposition;
							    if(Vector::getDistance(%flagpos, %playerpos) < 175)
							    {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableRocket,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Rocket#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Rocket Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								echo("MSG: ",%client," deployed a Remote Rocket Turret");
								$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
								return true;
							    }	
							    else
							    {
							          Client::sendMessage(%client,1,"You may only deploy this near your base.~wError_Message.wav");
								    return false;
							    }
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

ItemImageData HellPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData HellPack
{
        description = "Wall Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
      heading = "LTurrets";
        imageType = HellPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function HellPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}

function HellPack::onDeploy(%player,%item,%pos)
{
        if (HellPack::deployShape(%player,%item))
        {
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


function HellPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableHellPack",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num) + CountObjects(%set,"DeployableHellPack",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7 || 1==1) {
							if(checkDeployArea(%client,$los::position)) {
							    %playerPos = GameBase::getPosition(%player);
							    %flag = $teamFlag[GameBase::getTeam(%player)];
							    %flagpos = %flag.originalposition;
							    if(Vector::getDistance(%flagpos, %playerpos) < 200)
							    {
								
								%turret = newObject("remoteTurret","Turret",DeployableHellPack,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Wall Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Wall Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "HellPack"]++;
								echo("MSG: ",%client," deployed a Wall Turret");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							    }	
							    else
							    {
							          Client::sendMessage(%client,1,"You may only deploy this near your base.~wError_Message.wav");
								    return false;
							    }
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
		

}//----------------------------------------------------------------------------

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
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.99);
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
            GameBase::setTeam (%obj,GameBase::getTeam (%client));//
                }
        }
}


//----------------------------------------------------------------------------

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

//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
        className = "HandAmmo";
};



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
			GameBase::repairDamage(%object,0.45);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.25);
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

function Item::deployShape(%player,%name,%shape,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        // GetLOSInfo sets the following globals:
                        //         los::position
                        //         los::normal
                        //         los::object
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
		    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item.description);
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
        $TeamItemCount[0 @ SpySatellitePack] = 0;
        $TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
        $TeamItemCount[0 @ PulseSensorPack] = 0;
        $TeamItemCount[0 @ MotionSensorPack] = 0;
        $TeamItemCount[0 @ ScoutVehicle] = 0;
        $TeamItemCount[0 @ LAPCVehicle] = 0;
        $TeamItemCount[0 @ HAPCVehicle] = 0;
        $TeamItemCount[0 @ Beacon] = 0;
        $TeamItemCount[0 @ mineammo] = 0;
	  $TeamItemCount[0 @ ForceFieldPack] = 0;
	  $TeamItemCount[0 @ LargeFieldPack] = 0;


        $TeamItemCount[1 @ DeployableAmmoPack] = 0;
        $TeamItemCount[1 @ DeployableInvPack] = 0;
        $TeamItemCount[1 @ TurretPack] = 0;
        $TeamItemCount[1 @ CameraPack] = 0;
        $TeamItemCount[1 @ SpySatellitePack] = 0;
        $TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
        $TeamItemCount[1 @ PulseSensorPack] = 0;
        $TeamItemCount[1 @ MotionSensorPack] = 0;
        $TeamItemCount[1 @ ScoutVehicle] = 0;
        $TeamItemCount[1 @ LAPCVehicle] = 0;
        $TeamItemCount[1 @ HAPCVehicle] = 0;
        $TeamItemCount[1 @ Beacon] = 0;
        $TeamItemCount[1 @ mineammo] = 0;
        $TeamItemCount[1 @ ForceFieldPack] = 0;
	  $TeamItemCount[1 @ LargeFieldPack] = 0;

        $TeamItemCount[2 @ DeployableAmmoPack] = 0;
        $TeamItemCount[2 @ DeployableInvPack] = 0;
        $TeamItemCount[2 @ TurretPack] = 0;
        $TeamItemCount[2 @ CameraPack] = 0;
        $TeamItemCount[2 @ SpySatellitePack] = 0;
        $TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
        $TeamItemCount[2 @ PulseSensorPack] = 0;
        $TeamItemCount[2 @ MotionSensorPack] = 0;
        $TeamItemCount[2 @ ScoutVehicle] = 0;
        $TeamItemCount[2 @ LAPCVehicle] = 0;
        $TeamItemCount[2 @ HAPCVehicle] = 0;
        $TeamItemCount[2 @ Beacon] = 0;
        $TeamItemCount[2 @ mineammo] = 0;
        $TeamItemCount[2 @ ForceFieldPack] = 0;
	  $TeamItemCount[2 @ LargeFieldPack] = 0; 


        $TeamItemCount[3 @ DeployableAmmoPack] = 0;
        $TeamItemCount[3 @ DeployableInvPack] = 0;
        $TeamItemCount[3 @ TurretPack] = 0;
        $TeamItemCount[3 @ CameraPack] = 0;
        $TeamItemCount[3 @ SpySatellitePack] = 0;
        $TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[3 @ PulseSensorPack] = 0;
        $TeamItemCount[3 @ MotionSensorPack] = 0;
        $TeamItemCount[3 @ ScoutVehicle] = 0;
        $TeamItemCount[3 @ LAPCVehicle] = 0;
        $TeamItemCount[3 @ HAPCVehicle] = 0;
        $TeamItemCount[3 @ Beacon] = 0;
        $TeamItemCount[3 @ mineammo] = 0;
        $TeamItemCount[3 @ ForceFieldPack] = 0;
	  $TeamItemCount[3 @ LargeFieldPack] = 0;


        $TeamItemCount[4 @ DeployableAmmoPack] = 0;
        $TeamItemCount[4 @ DeployableInvPack] = 0;
        $TeamItemCount[4 @ TurretPack] = 0;
        $TeamItemCount[4 @ CameraPack] = 0;
        $TeamItemCount[4 @ SpySatellitePack] = 0;
        $TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[4 @ PulseSensorPack] = 0;
        $TeamItemCount[4 @ MotionSensorPack] = 0;
        $TeamItemCount[4 @ ScoutVehicle] = 0;
        $TeamItemCount[4 @ LAPCVehicle] = 0;
        $TeamItemCount[4 @ HAPCVehicle] = 0;
        $TeamItemCount[4 @ Beacon] = 0;
        $TeamItemCount[4 @ mineammo] = 0;
        $TeamItemCount[4 @ ForceFieldPack] = 0;
	  $TeamItemCount[4 @ LargeFieldPack] = 0; 


        $TeamItemCount[5 @ DeployableAmmoPack] = 0;
        $TeamItemCount[5 @ DeployableInvPack] = 0;
        $TeamItemCount[5 @ TurretPack] = 0;
        $TeamItemCount[5 @ CameraPack] = 0;
        $TeamItemCount[5 @ SpySatellitePack] = 0;
        $TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[5 @ PulseSensorPack] = 0;
        $TeamItemCount[5 @ MotionSensorPack] = 0;
        $TeamItemCount[5 @ ScoutVehicle] = 0;
        $TeamItemCount[5 @ LAPCVehicle] = 0;
        $TeamItemCount[5 @ HAPCVehicle] = 0;
        $TeamItemCount[5 @ Beacon] = 0;
        $TeamItemCount[5 @ mineammo] = 0;
        $TeamItemCount[5 @ ForceFieldPack] = 0;
	  $TeamItemCount[5 @ LargeFieldPack] = 0;


        $TeamItemCount[6 @ DeployableAmmoPack] = 0;
        $TeamItemCount[6 @ DeployableInvPack] = 0;
        $TeamItemCount[6 @ TurretPack] = 0;
        $TeamItemCount[6 @ CameraPack] = 0;
        $TeamItemCount[6 @ SpySatellitePack] = 0;
        $TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[6 @ PulseSensorPack] = 0;
        $TeamItemCount[6 @ MotionSensorPack] = 0;
        $TeamItemCount[6 @ ScoutVehicle] = 0;
        $TeamItemCount[6 @ LAPCVehicle] = 0;
        $TeamItemCount[6 @ HAPCVehicle] = 0;
        $TeamItemCount[6 @ Beacon] = 0;
        $TeamItemCount[6 @ mineammo] = 0;
        $TeamItemCount[6 @ ForceFieldPack] = 0;
	  $TeamItemCount[6 @ LargeFieldPack] = 0;


        $TeamItemCount[7 @ DeployableAmmoPack] = 0;
        $TeamItemCount[7 @ DeployableInvPack] = 0;
        $TeamItemCount[7 @ TurretPack] = 0;
        $TeamItemCount[7 @ CameraPack] = 0;
        $TeamItemCount[7 @ SpySatellitePack] = 0;
        $TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[7 @ PulseSensorPack] = 0;
        $TeamItemCount[7 @ MotionSensorPack] = 0;
        $TeamItemCount[7 @ ScoutVehicle] = 0;
        $TeamItemCount[7 @ LAPCVehicle] = 0;
        $TeamItemCount[7 @ HAPCVehicle] = 0;
        $TeamItemCount[7 @ Beacon] = 0;
        $TeamItemCount[7 @ mineammo] = 0;
        $TeamItemCount[7 @ ForceFieldPack] = 0;
        $TeamItemCount[7 @ LargeFieldPack] = 0;
        
                $TeamItemCount[0 @ RocketPack] = 0;
	        $TeamItemCount[1 @ RocketPack] = 0;
	        $TeamItemCount[2 @ RocketPack] = 0;
	        $TeamItemCount[3 @ RocketPack] = 0;
	        $TeamItemCount[4 @ RocketPack] = 0;
	        $TeamItemCount[5 @ RocketPack] = 0;
	        $TeamItemCount[6 @ RocketPack] = 0;
        $TeamItemCount[7 @ RocketPack] = 0; 

		  $TeamItemCount[0 @ HellPack] = 0;
	        $TeamItemCount[1 @ HellPack] = 0;
	        $TeamItemCount[2 @ HellPack] = 0;
	        $TeamItemCount[3 @ HellPack] = 0;
	        $TeamItemCount[4 @ HellPack] = 0;
	        $TeamItemCount[5 @ HellPack] = 0;
	        $TeamItemCount[6 @ HellPack] = 0;
              $TeamItemCount[7 @ HellPack] = 0;
        
        $TeamItemCount[0 @ TeleportPack] = 0;
			        $TeamItemCount[1 @ TeleportPack] = 0;
			        $TeamItemCount[2 @ TeleportPack] = 0;
			        $TeamItemCount[3 @ TeleportPack] = 0;
			        $TeamItemCount[4 @ TeleportPack] = 0;
			        $TeamItemCount[5 @ TeleportPack] = 0;
			        $TeamItemCount[6 @ TeleportPack] = 0;
	        $TeamItemCount[7 @ TeleportPack] = 0; 
        $TeamSpying[0]=false;
        $TeamSpying[1]=false;
        $TeamSpying[2]=false;
        $TeamSpying[3]=false;
        $TeamSpying[4]=false;
        $TeamSpying[5]=false;
        $TeamSpying[6]=false;
        $TeamSpying[7]=false;


        $totalNumCameras = 0;
        $totalNumTurrets = 0;

        for(%i = -1; %i < 8 ; %i++)
                $TeamEnergy[%i] = $DefaultTeamEnergy;
}
