//----------------------------------------------------------------------------

$ItemFavoritesKey = "RedneckSlag118";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

//RSP Globals
$KamikazeIsActive[0] = "false";

$MPCIsActive[0] = "false";
$MPCUseTime[0] = 0;
$RSP::MPCOldRate[0] = 0;

$RSP::NukeActive[0] = False;

$RSP::AntiMatterPoleID[0] = 0;
$RSP::AntiMatterTurretID[0] = 0;

$RSP::TeleportPadID[0 @ " " @ 0] = 0;
//The following go into the config file
$RSP::GolRepairRate = 0.01;
// End

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
$AutoUse[ChargeGun] = True;


$Use[Blaster] = True;

//$ArmorType[Male, LightArmor] = larmor;
//$ArmorType[Male, MediumArmor] = marmor;
//$ArmorType[Male, HeavyArmor] = harmor;
//$ArmorType[Female, LightArmor] = lfemale;
//$ArmorType[Female, MediumArmor] = mfemale;	   
//$ArmorType[Female, HeavyArmor] = harmor;

//$ArmorName[larmor] = LightArmor;
//$ArmorName[marmor] = MediumArmor;
//$ArmorName[harmor] = HeavyArmor;
//$ArmorName[lfemale] = LightArmor;
//$ArmorName[mfemale] = MediumArmor;

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

//------------------------
//Redneck Slag Additions
//------------------------
$ArmorType[Male, ScoutArmor] = SCarmor;
$ArmorType[Male, SniperArmor] = SNarmor;
$ArmorType[Male, EngineerArmor] = EngArmor;
$ArmorType[Male, InfiltratorArmor] = INFarmor;
$ArmorType[Male, DemoExpertArmor] = DEarmor;
$ArmorType[Male, GoliathArmor] = GOLarmor;
$ArmorType[Male, HackerArmor] = HACKarmor;

$ArmorType[Female, ScoutArmor] = FSCarmor;
$ArmorType[Female, SniperArmor] = FSNarmor;
$ArmorType[Female, EngineerArmor] = FEngArmor;
$ArmorType[Female, InfiltratorArmor] = FINFarmor;
$ArmorType[Female, DemoExpertArmor] = FDEarmor;
$ArmorType[Female, GoliathArmor] = FGOLarmor;
$ArmorType[Female, HackerArmor] = FHACKarmor;

$ArmorName[SCarmor] = ScoutArmor;
$ArmorName[SNarmor] = SniperArmor;
$ArmorName[EngArmor] = EngineerArmor;
$ArmorName[INFarmor] = InfiltratorArmor;
$ArmorName[DEarmor] = DemoExpertArmor;
$ArmorName[GOLarmor] = GoliathArmor;
$ArmorName[HACKarmor] = HackerArmor;

$ArmorName[FSCarmor] = ScoutArmor;
$ArmorName[FSNarmor] = SniperArmor;
$ArmorName[FEngArmor] = EngineerArmor;
$ArmorName[FINFarmor] = InfiltratorArmor;
$ArmorName[FDEarmor] = DemoExpertArmor;
$ArmorName[FGOLarmor] = GoliathArmor;
$ArmorName[FHACKarmor] = HackerArmor;

$AutoUse[PulseMortar] = True;
$AutoUse[GatBlaster] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[PlasmaCannon] = True;
$AutoUse[HellfireGun] = True;
$AutoUse[FlakGun] = True;

$SellAmmo[JumpMineAmmo] = 10;
$SellAmmo[PulseMortarAmmo] = 25;
$SellAmmo[PowerCellAmmo] = 5;
$SellAmmo[ConGrenade] = 3;
$SellAmmo[SniperShell] = 5;
$SellAmmo[FlashGrenade] = 3;
$SellAmmo[NukeGrenade] = 500;
$SellAmmo[HellfireAmmo] = 100;
$SellAmmo[FlakAmmo] = 5;

$AmmoPackMax[JumpMineAmmo] = 10;
$AmmoPackMax[PulseMortarAmmo] = 5;
$AmmoPackMax[PowerCellAmmo] = 50;
$AmmoPackMax[ConGrenade] = 10;
$AmmoPackMax[SniperShell] = 10;
$AmmoPackMax[FlashGrenade] = 0;
$AmmoPackMax[NukeGrenade] = 0;
$AmmoPackMax[HellfireAmmo] = 50;
$AmmoPackMax[FlakAmmo] = 5;

$AmmoPackItems[8] = JumpMineAmmo; //Dynamix left of at index 7
$AmmoPackItems[9] = PulseMortarAmmo;
$AmmoPackItems[10] = PowerCellAmmo;
$AmmoPackItems[11] = ConGrenade;
$AmmoPackItems[12] = SniperShell;
$AmmoPackItems[13] = FlashGrenade;
$AmmoPackItems[14] = NukeGrenade;
$AmmoPackItems[15] = HellfireAmmo;
$AmmoPackItems[16] = FlakAmmo;

$TeamItemMax[CHAPCVehicle] = 1;
$TeamItemMax[FighterVehicle] = 2;
$TeamItemMax[BLAPCVehicle] = 2;

$TeamItemMax[DeployableDecoyPack] = 5;
$TeamItemMax[DeployableForceFieldPack] = 15;
$TeamItemMax[ChainTurretPack] = 10;
$TeamItemMax[BaseAlarm] = 10;
$TeamItemMax[BigInvPack] = 2;
$TeamItemMax[AARocketPack] = 3;
$TeamItemMax[DeployableJumpPadPack] = 3;
$TeamItemMax[AntiMatterTurretPack] = 2;
$TeamItemMax[SniperPadPack] = 5;
$TeamItemMax[DeployableTelePadPack] = 2;
$TeamItemMax[DeployableELFTurretPack] = 4;
$TeamItemMax[DeployableLForceFieldPack] = 4;
$TeamItemMax[DeployableLRMotionSensorPack] = 2;

$WeaponAmmo[PulseMortar] = PulseMortarAmmo;
$WeaponAmmo[GatBlaster] = PowerCellAmmo;
$WeaponAmmo[SniperRifle] = SniperShell;
$WeaponAmmo[HellfireGun] = HellfireAmmo;
$WeaponAmmo[FlakGun] = FlakAmmo;

$totalNumAlarms[-1] = 0;
$totalNumAlarms[0] = 0;
$totalNumAlarms[1] = 0;
$totalNumAlarms[2] = 0;
$totalNumAlarms[3] = 0;
$totalNumAlarms[4] = 0;
$totalNumAlarms[5] = 0;
$totalNumAlarms[6] = 0;
$totalNumAlarms[7] = 0;

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
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation || %stationName == DepInventoryStation) {
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
   // only can buy fav every 1/2 second
   %time = getIntegerTime(true) >> 4; // int half seconds
   if(%time <= %client.lastBuyFavTime)
      return;

   %client.lastBuyFavTime = %time;

	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" ) {
		%stationName = GameBase::getDataName(%station); 
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation || %stationName == DepInventoryStation) 
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
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation || %sName == DepInventoryStation){
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
						
					//Gol Internal Repair RSP - HTR
					if(Player::getArmor(%client) == "GOLarmor" || Player::getArmor(%client) == "FGOLarmor")
					{
						GameBase::setAutoRepairRate(%player, $RSP::GolRepairRate);
					}
					else
					{
						GameBase::setAutoRepairRate(%player, 0);
					}

					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack) {
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
					if(Player::getItemCount(%client,"PlasmaCannon") > 0) {
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Plasma Cannon");
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
				if(%item == PlasmaCannon && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Plasma Cannon - Auto buying Energy Pack");
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
			%shouldBuy = VehicleStation::checkBuying(%client,%item);
			if(%shouldBuy == 1) {
				teamEnergyBuySell(%player,(%item.price * -1));
				return 1;
			}			
 			else if(%shouldBuy == 2)
				return 1;
		}
		else {
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
	%item = getItemData(%type);

	if($debugSell)
		echo(%type @ "  "  @ %item.description); //Added to help debug sell problems
	
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
					remoteSellItem(%client,29);						
				}
				if(Player::getItemCount(%client,"PlasmaCannon") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Plasma Cannon");
					remoteSellItem(%client,43);						
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
	echo("Throw item: " @ %type @ " " @ %strength);
	%item = getItemData(%type);
	if (%item == Grenade || %item == MineAmmo || %item == JumpMineAmmo || %item == ConGrenade || %item == FlashGrenade || %item == NukeGrenade) { //Edited to include jump mines & ConGrenades
		if (%strength < 0)
			%strength = 0;
		else
			if (%strength > 100)
				%strength = 100;
		%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
		Player::useItem(%client,%item);
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
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = GatBlaster;
$NextWeapon[GatBlaster] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = SniperRifle;
$NextWeapon[SniperRifle] = PulseMortar;
$NextWeapon[PulseMortar] = PlasmaCannon;
$NextWeapon[PlasmaCannon] = HellfireGun;
$NextWeapon[HellfireGun] = FlakGun;
$NextWeapon[FlakGun] = EnergyRifle;

$PrevWeapon[Blaster] = FlakGun;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[GatBlaster] = Chaingun;
$PrevWeapon[DiscLauncher] = GatBlaster;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[SniperRifle] = LaserRifle;
$PrevWeapon[EnergyRifle] = SniperRifle;
$PrevWeapon[PulseMortar] = EnergyRifle;
$PrevWeapon[PlasmaCannon] = PulseMortar;
$PrevWeapon[HellfireGun] = PlasmaCannon;
$PrevWeapon[FlakGun] = HellfireGun;

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
	//RSP
	if(%player.outArea && RSP::AntiOOB) {
		
	}
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
	mass = 1.5;

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

ItemData ScoutArmor
{
   heading = "aArmor";
	description = "Scout Armor";
	className = "Armor";
	price = 75;
};

ItemData SniperArmor
{
   heading = "aArmor";
	description = "Sniper Armor";
	className = "Armor";
	price = 175;
};

ItemData EngineerArmor
{
   heading = "aArmor";
	description = "Engineer Armor";
	className = "Armor";
	price = 500;
};

ItemData InfiltratorArmor
{
   heading = "aArmor";
	description = "Infiltrator Armor";
	className = "Armor";
	price = 250;
};

ItemData DemoExpertArmor
{
   heading = "aArmor";
	description = "Demo. Expert Armor";
	className = "Armor";
	price = 350;
};

ItemData GoliathArmor
{
   heading = "aArmor";
	description = "Goliath Armor";
	className = "Armor";
	price = 500;
};

ItemData HackerArmor
{
   heading = "aArmor";
	description = "Hacker Armor";
	className = "Armor";
	price = 650;
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

//---------------------------
//Cloaking HPC - HightechRedneck
//---------------------------
ItemData CHAPCVehicle
{
	description = "Cloaking HPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1000;
};

ItemData FighterVehicle
{
	description = "Fighter";
	className = "Vehicle";
   heading = "aVehicle";
	price = 850;
};

ItemData BLAPCVehicle
{
	description = "Bomber LPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 925;
};

//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onUse(%player,%item)
{
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
   price = 500;
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
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//---------------------------------------
//Redneck Slag Pack
//---------------------------------------

//----------------------------
// Jump Mines
//----------------------------
ItemData JumpMineAmmo
{
   description = "Jump Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function JumpMineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","BoosterMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}	

//----------------------------------------------
// Pulse Mortar <HightechRedneck>
//----------------------------------------------

ItemData PulseMortarAmmo
{
	description = "Pulse Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData PulseMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PulseMortarAmmo;
	projectileType = PulseMortarShell;
	accuFire = false;
	reloadTime = 2.0;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 2;
	lightColor = { 0, 0.3, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData PulseMortar
{
	description = "Pulse Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PulseMortarImage;
	price = 300;
	showWeaponBar = true;
};

//----------------------------------------------------
//Gat. Blaster
//----------------------------------------------------
ItemData PowerCellAmmo
{
	description = "Power Cell";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData GatBlasterImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.15;

	ammoType = PowerCellAmmo;
	projectileType = GatBlasterShot;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 0, 0.2 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData GatBlaster
{
	description = "Gat. Blaster";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "energypack";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GatBlasterImage;
	price = 245;
	showWeaponBar = true;
};

//-----------------------------------------
// Con Grenade
//-----------------------------------------

ItemData ConGrenade
{
   description = "Concussion Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function ConGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","PushGrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------
//Sniper Rifle
//----------------------------------------------------
ItemData SniperShell
{
	description = "Sniper Rounds";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 6.0;
	fireTime = 0.0;

	ammoType = SniperShell;
	projectileType = SniperRifleShot;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 2;
    lightColor = { 0.85, 0.75, 0.0 };

	sfxFire = SniperFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 250;
	showWeaponBar = true;
};

//-----------------------------------------
// Flash Grenade
//-----------------------------------------

ItemData FlashGrenade
{
   description = "Flash Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function FlashGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","BlindGrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//-----------------------------------------
// Nuke Pack
//-----------------------------------------

ItemData NukeGrenade
{
   description = "Nuke Pack";
   shapeFile = "grenammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 1000;
	className = "HandAmmo";
};

function NukeGrenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			if(!$RSP::NukeActive[GameBase::getTeam(%player)])
			{
				Player::decItemCount(%player,%item);			

				%obj = newObject("","Mine","AtomGrenade");
 	 	 		addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
				GameBase::setTeam(%obj, Client::getTeam(%client));
			
				%team = GameBase::getTeam(%player);
				%tName = getTeamName(%team);
				messageall(1,"The " @ %tName @ " have deployed a nuke!~wLeftMissionArea.wav");
				
				%player.throwTime = getSimTime() + 0.5;
				
				$RSP::NukeActive[%team] = True;
			}
			else
			{
				Client::sendMessage(Player::getClient(%player), 1, "Your team has a nuke deployed already!");
			}				
		}
	}
}

//----------------------------------------------
// Plasma Cannon <HightechRedneck>
//----------------------------------------------

ItemImageData PlasmaCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = PlasmaCannonBlast;
	accuFire = True;
	reloadTime = 0.5;
	fireTime = 0.2;
	minEnergy = 15;
	maxEnergy = 50;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundGeneratorPower;
};

ItemData PlasmaCannon
{
	description = "Plas Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 250;
	showWeaponBar = true;
};

function PlasmaCannon::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Energy Pack to use Plasma Cannon."); 
}

//-----------------------------------------------
// Hellfire Gun - HightechRedneck
//-----------------------------------------------
ItemData HellfireAmmo
{
	description = "Hellfire Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 75;
};

ItemImageData HellfireGunImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = HellfireAmmo;
	projectileType = HellfireShot;
	accuFire = false;
	reloadTime = 1.5;
	fireTime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData HellfireGun
{
	description = "Hellfire Gun";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HellfireGunImage;
	price = 500;
	showWeaponBar = true;
};

//-----------------------------------------------
// Hellfire Gun - HightechRedneck
//-----------------------------------------------
ItemData FlakAmmo
{
	description = "Flak Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 15;
};

ItemImageData FlakGunGunImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FlakAmmo;
	projectileType = FlakShell;
	accuFire = false;
	reloadTime = 5.0;
	fireTime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData FlakGun
{
	description = "Flak Gun";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlakGunGunImage;
	price = 150;
	showWeaponBar = true;
};

//--------------------------------------------------
// Hacking Tool - RSP - HR
//--------------------------------------------------
ItemImageData HackGunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = HackBolt;
	minEnergy  = 3;
	maxEnergy = 15;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0, 1, 1 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData HackGun
{
	description = "Hack Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = HackGunImage;
	showInventory = false;
	price = 350;
};

function HackGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function HackGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//Part 2 of Hack Gun

ItemImageData HackPackImage
{
	shapeFile = "jetPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData HackPack
{
	description = "Hack Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = HackPackImage;
	price = 350;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HackPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == HackGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function HackPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,HackGun,$WeaponSlot);
	}
}

function HackPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == HackGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the HackGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}

//--------------------------------------------------
// Viral Tool - RSP - HR
//--------------------------------------------------
ItemImageData ViralGunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = ViralBolt;
	minEnergy  = 3;
	maxEnergy = 15;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0, 1, 1 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData ViralGun
{
	description = "Viral Gun";
	shapeFile = "shotgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = ViralGunImage;
	showInventory = false;
	price = 300;
};

function ViralGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function ViralGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//Part 2 of Viral Gun

ItemImageData ViralPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ViralPack
{
	description = "Viral Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ViralPackImage;
	price = 350;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ViralPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == ViralGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function ViralPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,ViralGun,$WeaponSlot);
	}
}

function ViralPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == ViralGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the ViralGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}

// RSP Engineer repair pack
ItemImageData EngRepairGunImage
{
	shapeFile = "RepairGun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = EngRepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData EngRepairGun
{
	description = "Repair Gun";
	shapeFile = "RepairGun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = EngRepairGunImage;
	showInventory = false;
	price = 125;
};

function EngRepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EngRepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

// Part 2 of Repair pack

ItemImageData EngRepairPackImage
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

ItemData EngRepairPack
{
	description = "Engineer Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EngRepairPackImage;
	price = 300;
	hudIcon = "RepairPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EngRepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == EngRepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function EngRepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,EngRepairGun,$WeaponSlot);
	}
}

function EngRepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == EngRepairGun) {
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

//-------------------------------------
// Kamikaze Pack - RSP - HR
//-------------------------------------
ItemImageData KamikazePackImage
{
	shapeFile = "rocket";
	mountPoint = 2;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.1, 0 };
  	mountRotation = { -1.5, 0, 0 };
	firstPerson = false;
	weaponType = 2;  // Sustained
    minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons

	lightType = 2;   // Pulsing
	lightRadius = 6;
	lightTime = 1.5;
	lightColor = { 0.75, 0.15, 0.15 };
};

ItemData KamikazePack
{
	description = "Kamikaze Pack";
	shapeFile = "rocket";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = KamikazePackImage;
	price = 300;
	hudIcon = "grenade";
	showWeaponBar = true;
	hiliteOnActive = true;

	//lightType = 2;   // Pulsing
	//lightRadius = 8;
	//lightTime = 1.5;
	//lightColor = { 0.75, 0.15, 0.15 };
};

function KamikazePackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"Kamikaze Pack Initialized. 30 seconds till detonation!");
	$KamikazeIsActive[%player] = "true";
	KamikazePackCount(30, %player);
}

function KamikazePackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
	$KamikazeIsActive[%player] = "false";
}

function KamikazePack::onDrop(%player,%item)
{
	if($matchStarted) {
		if($KamikazeIsActive[%player]) {
			$KamikazeIsActive[%player] = "false";
		
			Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack dropped. Countdown terminated!");
		}

		Item::onDrop(%player,%item);
	}
}

function KamikazePackCount(%count, %player)
{
	if(!$matchStarted) return;

	%mounted = Player::getMountedItem(%player,$BackpackSlot);
	if (%mounted != KamikazePack){
		Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack not located. Countdown terminated!");
		$KamikazeIsActive[%player] = false;
		return;
	}
		
	if(%count && $KamikazeIsActive[%player]) {
		if(%count == 15)
			Client::sendMessage(Player::getClient(%player),1,"15");
		if(%count == 5)
			Client::sendMessage(Player::getClient(%player),1,"5");
		if(%count == 4)
			Client::sendMessage(Player::getClient(%player),1,"4");
		if(%count == 3)
			Client::sendMessage(Player::getClient(%player),1,"3");
		if(%count == 2)
			Client::sendMessage(Player::getClient(%player),1,"2");
		if(%count == 1)
			Client::sendMessage(Player::getClient(%player),1,"1");

		%count -= 1;
		schedule("KamikazePackCount('" @ %count @ "','" @ %player @ "');", 1);
	}
	else if($KamikazeIsActive[%player])
	{
		if($KamikazeIsActive[%player]) {
			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,1,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,-1,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,5,false);

			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,-5,false);
		}
		$KamikazeIsActive[%player] = "false";
	}
	else
	{
		Client::sendMessage(Player::getClient(%player),0,"Kamikaze pack deactivated. Countdown terminated!");
	}
}

// RSP Magnetic Pulse Capacitor Pack

ItemImageData MPCPackImage
{
	shapeFile = "shieldPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;

	sfxFire = SoundShieldOn;
	firstPerson = false;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 0, 0.25, 1 };
};

ItemData MPCPack
{
	description = "MPC Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = MPCPackImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MPCPackImage::onDrop(%player,%item)
{
	if($matchStarted) {
		$MPCIsActive[%player] = false;
		$MPCUsed[%player] = false;
		
		if($RSP::MPCOldRate[%player] > 0)
		{
			GameBase::setRechargeRate(%player,$RSP::MPCOldRate[%player]);
		}

		Client::sendMessage(Player::getClient(%player),0,"MPC Dropped...");

		Item::onDrop(%player,%item);
	}
}

function MPCPackImage::onActivate(%player,%imageSlot)
{
	if(!$MPCUsed[%player]) {
		Client::sendMessage(Player::getClient(%player),0,"MPC On...");
		$MPCIsActive[%player] = true;

		$MPCUseTime[%player] = 0;
		$RSP::MPCOldRate[%player] = GameBase::getRechargeRate(%player);
		GameBase::setRechargeRate(%player,200);

		schedule("MPCPackCount(" @ $RSP::MPCPackChargeTime @ ", " @ %player @ ");", 1, %player);
	//}
	//else {
		//Player::trigger(%player,$BackpackSlot,false);
		//Client::sendMessage(Player::getClient(%player),0,"MPC Pack must cool down first");
		//$MPCUsed[%player] = true;
		//$MPCIsActive[%player] = false;
	}
}

function MPCPackImage::onDeactivate(%player,%imageSlot)
{
	
	%client = Player::getClient(%player);

	if(!$MPCUsed[%player] && !%client.dead && Player::getMountedItem(%player,$BackpackSlot) == MPCPack) {
		GameBase::setRechargeRate(%player,$RSP::MPCOldRate[%player]);
		Client::sendMessage(Player::getClient(%player),0,"MPC Off... Cooling Down...");
		Player::trigger(%player,$BackpackSlot,false);
	
		$MPCIsActive[%player] = false;
		$MPCUsed[%player] = true;

		if($RSP::MPCCoolAccordingToUse)
		{
			%time = floor($MPCUseTime[%player] * 2);
			if(%time < 10)
				%time = 10;
			
			schedule("MPCPackCooling(" @ %time @ ", " @ %player @ ");", 1, %player);
		}
		else{
			schedule("MPCPackCooling(" @ $RSP::MPCPackCoolingTime @ ", "  @ %player @ ");", 1, %player);
		}
	}
	else {
		GameBase::setEnergy(%player, 0);
		Client::sendMessage(Player::getClient(%player),0,"MPC is not ready.");
		Player::trigger(%player,$BackpackSlot,false);
	}
}

function MPCPackCount(%count, %player)
{
	if(!$matchStarted) return;

	%mounted = Player::getMountedItem(%player,$BackpackSlot);
	if (%mounted != MPCPack) {
		$MPCIsActive[%player] = false;
		$MPCUsed[%player] = false;
		return;
	}
	
	if($MPCIsActive[%player] && !$MPCUsed[%player]) {
		if(%count == floor(($RSP::MPCPackChargeTime / 3) * 2))
			Client::sendMessage(Player::getClient(%player),1,"MPC pack heat normal...~wLeftMissionArea.wav");
		else if(%count == floor($RSP::MPCPackChargeTime / 3))
			Client::sendMessage(Player::getClient(%player),1,"MPC pack heat nearing critical...~wLeftMissionArea.wav");
		else if(%count == floor($RSP::MPCPackChargeTime / 6)) {
			Client::sendMessage(Player::getClient(%player),1,"MPC pack heat containment field shutdown...~wLeftMissionArea.wav");
			leaveMissionAreaDamage(Player::getClient(%player)); //Using this function instead of creating a new one to do the same thing
											 //Damages player due to heat from pack.
		}
		else if(%count < floor($RSP::MPCPackChargeTime / 6) && %count > 0)
			leaveMissionAreaDamage(Player::getClient(%player));
		else if(%count == 0 || %count < 0)
			Player::trigger(%player,$BackpackSlot,false);
		
		$MPCUseTime[%player]++;
		schedule("MPCPackCount( " @ %count - 1 @ ", " @ %player @ ");", 1, %player);
	}
}

function MPCPackCooling(%time, %player)
{
	%mounted = Player::getMountedItem(%player,$BackpackSlot);
	if (%mounted == MPCPack)
	{
		if(%time > 0)
		{
			GameBase::setRechargeRate(%player,$RSP::MPCOldRate[%player]);
			Player::trigger(%player,$BackpackSlot,false);
			schedule("MPCPackCooling( " @ %time - 1 @ ", " @ %player @ ");", 1, %player);
		}
		else if(%time == 0)
		{
			MPCReset(%player);
		}
	}
}

function MPCReset(%player)
{
	$MPCUsed[%player] = false;
	Client::sendMessage(Player::getClient(%player),1,"MPC pack has cooled...");
}

// RSP TK Bolt Pack

ItemImageData TKPackImage
{
	shapeFile = "zap_5";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, 0.25, 0 };
  	mountRotation = { 0, 0, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;

	sfxFire = SoundShieldOn;
	firstPerson = false;

	lightType = 2;   // Pulsing
	lightRadius = 8;
	lightTime = 0.2;
	lightColor = { 0, 0, 1 };
};

ItemData TKPack
{
	description = "TK Pack";
	shapeFile = "zap_5";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = TKPackImage;
	price = 10000;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TKPackImage::onDrop(%player,%item)
{
	Player::Kill(%player);
	Player::blowUp(%player);
}

function TKPackImage::onActivate(%player,%imageSlot)
{
	
}

function TKPackImage::onDeactivate(%player,%imageSlot)
{
	
}

// Cloak Pack

ItemImageData CloakPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 5;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CloakPack
{
	description = "Cloaking Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakPackImage;
	price = 325;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Cloaker On");
	%rate = Player::getSensorSupression(%player) + 5;
	Player::setSensorSupression(%player,%rate);
	GameBase::startFadeOut(%player);
}

function CloakPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Cloaker Off");
	%rate = Player::getSensorSupression(%player) - 5;
	Player::setSensorSupression(%player,%rate);
	GameBase::startFadeIn(%player);
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
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "StaticShape") {
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
	if (Player::getMountedItem(%player,$WeaponSlot) == PlasmaCannon) 
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
		for(%i = 0; %i < 13 ; %i = %i +1) {
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
	 	    	%item.MineAmmo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.JumpMineAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.PulseMortarAmmo = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.PowerCellAmmo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.SniperShell = %numPack;
			}
			else if(%i == 13) {
	 	    	%item.FlashGrenade = %numPack;
			}
			else if(%i == 15) {
	 	    	%item.HellfireAmmo = %numPack;
			}
			else if(%i == 16) {
				%item.FlakAmmo = %numPack;
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
	for(%i = 0; %i < 13 ; %i = %i +1) {
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
 	    	%numAdd = %item.MortarAmmo;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.JumpMineAmmo;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.PulseMortarAmmo;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.PowerCellAmmo;
		}
		else if(%i == 12) {
 	    	%numAdd = %item.SniperShell;
		}
		else if(%i == 13) {
 	    	%numAdd = %item.FlashGrenade;
		}
		else if(%i == 15) {
 	    	%numAdd = %item.HellfireAmmo;
		}
		else if(%i == 16) {
			%numAdd = %item.FlakAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 13 ; %i = %i +1) {
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
						      Client::setOwnedObject(%client, %turret);
						      Client::setOwnedObject(%client, %player);
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

	for(%i = 0; %i <= Group::objectCount(%set); %i++)
	{
		%objType = GameBase::getDataName(Group::getObject(%set, %i));
		
		if(%objType == SniperPad && Group::objectCount(%set) == 1)
		{
			deleteObject(%set);
			return 1;
		}
	}

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

//---------------------------------
// Redneck Slag Additions
//--------------------------------
//Decoy
//--------------------------------
ItemImageData DeployableDecoyPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData DeployableDecoyPack
{
	description = "Sniper Decoy";
	shapeFile = "larmor";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableDecoyPackImage;
	mass = 1.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableDecoyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableDecoyPack::onDeploy(%player,%item,%pos)
{
	if (DeployableDecoyPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableDecoyPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%Decoy = newObject("","StaticShape",DecoyPack,true);
 	 					addToSet("MissionCleanup", %Decoy);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%Decoy,GameBase::getTeam(%player));
						GameBase::setPosition(%Decoy,$los::position);
						GameBase::setRotation(%Decoy,%rot);
						Gamebase::setMapName(%Decoy,%name);
						Client::sendMessage(%client,0,"Decoy deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%Decoy) @ "DeployableDecoyPack"]++;
						echo("MSG: ",%client," deployed a Decoy");
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

//--------------------------------
//Force Field
//--------------------------------
ItemImageData DeployableForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
  	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData DeployableForceFieldPack
{
	description = "Force Field";
	shapeFile = "forcefield_5x5";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableForceFieldPackImage;
	mass = 5.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (DeployableForceFieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$FFieldBoxMaxLength,$FFieldBoxMaxWidth,$FFieldBoxMaxHeight,0);
				%num = CountObjects(%set,"ForceFieldPack",%num);
				deleteObject(%set);
				if($MaxNumFFieldInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$FFieldBoxMinLength,$FFieldBoxMinWidth,$FFieldBoxMinHeight,0);
					%num = CountObjects(%set,"ForceFieldPack",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%DFField = newObject("","StaticShape",ForceFieldPack,true);
								addToSet("MissionCleanup", %DFField);
								GameBase::setTeam(%DFField,GameBase::getTeam(%player));
								GameBase::setPosition(%DFField,$los::position);
								GameBase::setRotation(%DFField,%rot);
								Gamebase::setMapName(%DFField,"Force Field");
								Client::sendMessage(%client,0,"Force Field deployed");
								playSound(ForceFieldClose,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "DeployableForceFieldPack"]++;
								echo("MSG: ",%client," deployed a Force Field");
								Client::setOwnedObject(%client, %DFField);
								Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other force fields");
				}
			   else 
					Client::sendMessage(%client,0,"Can not build a force field this close to another one");
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

//--------------------------------
//Large Force Field
//--------------------------------
ItemImageData DeployableLForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
  	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableLForceFieldPack
{
	description = "Large Force Field";
	shapeFile = "forcefield_4x8";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableLForceFieldPackImage;
	mass = 5.0;
	elasticity = 0.2;
	price = 700;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableLForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableLForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (DeployableLForceFieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableLForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$FFieldBoxMaxLength,$FFieldBoxMaxWidth,$FFieldBoxMaxHeight,0);
				%num = CountObjects(%set,"LForceFieldPack",%num);
				deleteObject(%set);
				if($MaxNumFFieldInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$FFieldBoxMinLength,$FFieldBoxMinWidth,$FFieldBoxMinHeight,0);
					%num = CountObjects(%set,"LForceFieldPack",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%DFField = newObject("","StaticShape",LForceFieldPack,true);
								addToSet("MissionCleanup", %DFField);
								GameBase::setTeam(%DFField,GameBase::getTeam(%player));
								GameBase::setPosition(%DFField,$los::position);
								GameBase::setRotation(%DFField,%rot);
								Gamebase::setMapName(%DFField,"Large Force Field");
								Client::sendMessage(%client,0,"Large Force Field deployed");
								playSound(LForceFieldClose,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "DeployableLForceFieldPack"]++;
								echo("MSG: ",%client," deployed a Large Force Field");
								Client::setOwnedObject(%client, %DFField);
								Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other force fields");
				}
			   else 
					Client::sendMessage(%client,0,"Can not build a force field this close to another one");
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

//-----------------------------------
// Chaingun Turret
//-----------------------------------

ItemImageData ChainTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ChainTurretPack
{
	description = "Chain Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = ChainTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ChainTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ChainTurretPack::onDeploy(%player,%item,%pos)
{
	if (ChainTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ChainTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ChainTurretBoxMaxLength,$ChainTurretBoxMaxWidth,$ChainTurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableChainTurret",%num);
				deleteObject(%set);
				if($MaxNumChainTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ChainTurretBoxMinLength,$ChainTurretBoxMinWidth,$ChainTurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableChainTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						//if (Vector::dot($los::normal,"0 0 1") > 0.7) {

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
							if(checkDeployArea(%client,$los::position)) {
								//%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableChainTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Chain Turret#" @ $totalNumChainTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Chain Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ChainTurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Chain Turret");
								Client::setOwnedObject(%client, %turret);
								Client::setOwnedObject(%client, %player);
								return true;
							}
						//}
						//else 
						//	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
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

//------------------------------------
// Base Alarms - HightechRedneck
//------------------------------------
ItemImageData BaseAlarmImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData BaseAlarm
{
   description = "Base Alarm";
   shapeFile = "sensor_small";
   className = "Backpack";
   heading = "dDeployables";
   shadowDetailMask = 4;
   imageType = BaseAlarmImage;
   mass = 2.0;
   elasticity = 0.2;
   price = 50;
   hudIcon = "deployable";
   showWeaponBar = true;
   hiliteOnActive = true;
};

function BaseAlarm::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BaseAlarm::onDeploy(%player,%item,%pos)
{
	if (BaseAlarm::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function BaseAlarm::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if (GameBase::getLOSInfo(%player,3)) {
		%obj = getObjectType($los::object);
		if (%obj == "InteriorShape") {
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
			if(checkDeployArea(%client,$los::position)) {
				%alarm = newObject("","StaticShape", "AlarmKit",true);
 	 			addToSet("MissionCleanup", %alarm);
				GameBase::setTeam(%alarm,GameBase::getTeam(%player));
				GameBase::setRotation(%alarm,%rot);
				GameBase::setPosition(%alarm,$los::position);
				Gamebase::setMapName(%alarm,%name);
				Gamebase::setMapName(%alarm,"Base Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)]++);
				Client::sendMessage(%client,0,"Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)] @ " deployed");
				$TeamItemCount[GameBase::getTeam(%SGen) @ "BaseAlarm"]++;
				return true;
			}
		}
		else {
			Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}

	return false;
}

//--------------------------------
// Full Inv 
//--------------------------------
ItemImageData BigInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 5;
	firstPerson = false;
};

ItemData BigInvPack
{
	description = "Full Size Inv";
	shapeFile = "invent_remote";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = BigInvPackImage;
	mass = 75.0;
	elasticity = 0.2;
	price = 100000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function BigInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BigInvPack::onDeploy(%player,%item,%pos)
{
	if (BigInvPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function BigInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape",DepInventoryStation,true);
 	 					addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Inventory Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "BigInvPack"]++;
						return true;
					}
				}
				else
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//-----------------------------------
// AA Rocket Turret
//-----------------------------------

ItemImageData AARocketPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData AARocketPack
{
	description = "AA Rocket Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = AARocketPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AARocketPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AARocketPack::onDeploy(%player,%item,%pos)
{
	if (AARocketPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AARocketPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$AARocketBoxMaxLength,$AARocketBoxMaxWidth,$AARocketBoxMaxHeight,0);
				%num = CountObjects(%set,"AARocketTurret",%num);
				deleteObject(%set);
				if($MaxNumAARocketsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$AARocketBoxMinLength,$AARocketBoxMinWidth,$AARocketBoxMinHeight,0);
					%num = CountObjects(%set,"AARocketTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						//if (Vector::dot($los::normal,"0 0 1") > 0.7) {

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
							if(checkDeployArea(%client,$los::position)) {
								//%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",AARocketTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT AA Rocket Turret#" @ $totalNumAARockets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote AA Rocket Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "AARocketPack"]++;
								echo("MSG: ",%client," deployed a Remote AA Turret");
						      Client::setOwnedObject(%client, %turret);
						      Client::setOwnedObject(%client, %player);
								return true;
							}
						//}
						//else 
						//	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
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

// Anti Matter Turret

ItemImageData AntiMatterTurretPackImage
{
	shapeFile = "liqcyl";
	mountPoint = 2;
	mountOffset = { 0, -0.3, -0.45 };
	mountRotation = { 0, 0, 0 };
	mass = 4.0;
	firstPerson = false;
};

ItemData AntiMatterTurretPack
{
	description = "Anti Matter Turret";
	shapeFile = "liqcyl";
	className = "Backpack";
   heading = "dDeployables";
	imageType = AntiMatterTurretPackImage;
	shadowDetailMask = 4;
	mass = 4.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AntiMatterTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AntiMatterTurretPack::onDeploy(%player,%item,%pos)
{
	if (AntiMatterTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AntiMatterTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$AntiMatterTurretBoxMaxLength,$AntiMatterTurretBoxMaxWidth,$AntiMatterTurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableAntiMatterTurret",%num);
				deleteObject(%set);
				if($MaxNumAntiMatterTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$AntiMatterTurretBoxMinLength,$AntiMatterTurretBoxMinWidth,$AntiMatterTurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableAntiMatterTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player);
								%turret = newObject("DeployableAntiMatterTurret","Turret",DeployableAntiMatterTurret,true);
								%stand = newObject("AntiMatterStand","StaticShape",AntiMatterStand,true);

								$RSP::AntiMatterPoleID[%turret] = %stand;
								$RSP::AntiMatterTurretID[%stand] = %turret;

								addToSet("MissionCleanup", %turret);
								addToSet("MissionCleanup", %stand);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setTeam(%stand,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,Vector::add($los::position, "0 0 14.75"));
								GameBase::setPosition(%stand,$los::position);
								GameBase::setRotation(%turret,%rot);
								GameBase::setRotation(%stand,%rot);
								Gamebase::setMapName(%turret,"Anti Matter Turret");
								Client::sendMessage(%client,0,"Anti Matter Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "AntiMatterTurretPack"]++;
								echo("MSG: ",%client," deployed a Anti Matter Turret");
								Client::setOwnedObject(%client, %turret);
								Client::setOwnedObject(%client, %stand);
								Client::setOwnedObject(%client, %player);
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
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//-----------------------------------
// Chaingun Turret
//-----------------------------------

ItemImageData DeployableELFTurretPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
  	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData DeployableELFTurretPack
{
	description = "ELF Turret";
	shapeFile = "chainturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = DeployableELFTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableELFTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableELFTurretPack::onDeploy(%player,%item,%pos)
{
	if (DeployableELFTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DeployableELFTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$DeployableELFTurretBoxMaxLength,$DeployableELFTurretBoxMaxWidth,$DeployableELFTurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableElfTurret",%num);
				deleteObject(%set);
				if($MaxNumDeployableELFTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$DeployableELFTurretBoxMinLength,$DeployableELFTurretBoxMinWidth,$DeployableELFTurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableElfTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						//if (Vector::dot($los::normal,"0 0 1") > 0.7) {

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
							if(checkDeployArea(%client,$los::position)) {
								//%rot = GameBase::getRotation(%player); 
								%turret = newObject("DeployableELFTurret","Turret",DeployableELFTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Remote ELF Turret");
								Client::sendMessage(%client,0,"Remote ELF Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "DeployableELFTurretPack"]++;
								echo("MSG: ",%client," deployed a Remote ELF Turret");
								Client::setOwnedObject(%client, %turret);
								Client::setOwnedObject(%client, %player);
								return true;
							}
						//}
						//else 
						//	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//--------------------------------
//Jump Pad - HTR
//--------------------------------
ItemImageData DeployableJumpPadPackImage
{
	shapeFile = "elevator_4x4";
	mountPoint = 2;
  	mountOffset = { 0, -0.07, 0 };
	mountRotation = { 1.5, 0, 0 };
	mass = 5.0;
	firstPerson = false;
};

ItemData DeployableJumpPadPack
{
	description = "Jump Pad";
	shapeFile = "elevator_4x4";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableJumpPadPackImage;
	mass = 5.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableJumpPadPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableJumpPadPack::onDeploy(%player,%item,%pos)
{
	if (DeployableJumpPadPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableJumpPadPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player); 
						%DJPad = newObject("","StaticShape",DeployableJumpPad,true);
						addToSet("MissionCleanup", %DJPad);
						GameBase::setTeam(%DJPad,GameBase::getTeam(%player));
						GameBase::setPosition(%DJPad,Vector::add($los::position, "0 0 3"));
						GameBase::setRotation(%DJPad,%rot);
						Gamebase::setMapName(%DJPad,"Jump Pad");
						Client::sendMessage(%client,0,"Jump Pad deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "DeployableJumpPadPack"]++;
						echo("MSG: ",%client," deployed a Jump Pad");
						Client::setOwnedObject(%client, %DJPad);
						Client::setOwnedObject(%client, %player);
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

// Teleport Pad
ItemImageData DeployableTelePadPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
  	mountOffset = { 0, -0.07, 0 };
	mountRotation = { 1.5, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableTelePadPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableTelePadPackImage;
	mass = 2.5;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableTelePadPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableTelePadPack::onDeploy(%player,%item,%pos)
{
	if (DeployableTelePadPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableTelePadPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {

				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$ItemObjectType,$los::position,40,40,20,0);

				if(%num)
				{
					for(%i = 0; %i <= Group::objectCount(%set); %i++)
					{
						%objType = GameBase::getDataName(Group::getObject(%set, %i));
		
						if(%objType == Flag)
						{
							Client::sendMessage(%client,0,"Teleports are not placeable this close to a flag");
							deleteObject(%set);
							return;
						}
					}					
				}

				deleteObject(%set);

	    		if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player); 
						%DTPad = newObject("","StaticShape",TelePad,true);
						addToSet("MissionCleanup", %DTPad);
						GameBase::setTeam(%DTPad,GameBase::getTeam(%player));
						GameBase::setPosition(%DTPad,Vector::add($los::position, "0 0 -0.05"));
						GameBase::setRotation(%DTPad, %rot);
						Gamebase::setMapName(%DTPad,"Teleport Pad");
						Client::sendMessage(%client,0,"Teleport Pad deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTelePadPack"]++;
						echo("MSG: ",%client," deployed a Teleport Pad");

						if(!$RSP::TeleportPadID[GameBase::getTeam(%player) @ " " @ 0])
						{
							$RSP::TeleportPadID[GameBase::getTeam(%player) @ " " @ 0] = %DTPad;
						}
						else
						{
							$RSP::TeleportPadID[GameBase::getTeam(%player) @ " " @ 1] = %DTPad;
							TeamMessages(0, GameBase::getTeam(%player), "Teleports linked.");
						}

						Client::setOwnedObject(%client, %DTPad);
						Client::setOwnedObject(%client, %player);
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

// Long Range Motion Sensor
ItemImageData DeployableLRMotionSensorPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.07, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableLRMotionSensorPack
{
	description = "LR Motion Sensor";
	shapeFile = "sensor_pulse_med";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableLRMotionSensorPackImage;
	mass = 2.5;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableLRMotionSensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableLRMotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (DeployableLRMotionSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableLRMotionSensorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player); 
						%DTPad = newObject("","Sensor",DeployableLongRangeMotionSensor,true);
						addToSet("MissionCleanup", %DTPad);
						GameBase::setTeam(%DTPad,GameBase::getTeam(%player));
						GameBase::setPosition(%DTPad,Vector::add($los::position, "0 0 -0.05"));
						GameBase::setRotation(%DTPad, %rot);
						Gamebase::setMapName(%DTPad,"Long Range Motion Sensor");
						Client::sendMessage(%client,0,"Long Range Motion Sensor deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "DeployableLRMotionSensorPack"]++;
						echo("MSG: ",%client," deployed a Long Range Motion Sensor");
						Client::setOwnedObject(%client, %DTPad);
						Client::setOwnedObject(%client, %player);
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
// Sniper Pad -- Mystere
//----------------------------------------------------------------------------

ItemImageData SniperPadPackImage
{
    shapeFile = "AmmoPack";
	mountPoint = 2;
  	mountOffset = { 0, -0.03, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData SniperPadPack
{
    description = "Sniper Pad";
    shapeFile = "elevator16x16_octo";
	className = "Backpack";
	heading = "dDeployables";
    shadowDetailMask = 4;
    imageType = SniperPadPackImage;
	mass = 0.5;
	elasticity = 0.2;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function SniperPadPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SniperPadPack::onDeploy(%player,%item,%pos)
{
        if (SniperPadPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function SniperPadPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player); 
						%SPPad = newObject("","StaticShape",SniperPad,true);
                        addToSet("MissionCleanup", %SPPad);
                        GameBase::setTeam(%SPPad,GameBase::getTeam(%player));
                        GameBase::setRotation(%SPPad,%rot);
                        GameBase::setPosition(%SPPad,$los::position);
                        GameBase::setPosition(%SPPad,Vector::add($los::position, "0 0 80"));
                        Gamebase::setMapName(%SPPad,"Sniper Pad");
                        Client::sendMessage(%client,0,"Sniper Pad deployed");
						playSound(SoundPickupBackpack,$los::position);
                        $TeamItemCount[GameBase::getTeam(%player) @ "SniperPadPack"]++;
                        echo("MSG: ",%client," deployed a Sniper Pad");
                        Client::setOwnedObject(%client, %SPPad);
						Client::setOwnedObject(%client, %player);
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
};

function RepairKit::onUse(%player,%item)
{
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

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::setTeam(%obj,GameBase::getTeam(%player)); //RSP
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
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
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
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
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
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
   heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
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

//-----------------------------------------------------------------------------
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

	//------------------------------------
	//Redneck Slag Additions
	//------------------------------------
	$TeamItemCount[0 @ JumpMineAmmo] = 0;
	$TeamItemCount[1 @ JumpMineAmmo] = 0;
	$TeamItemCount[2 @ JumpMineAmmo] = 0;
	$TeamItemCount[3 @ JumpMineAmmo] = 0;
	$TeamItemCount[4 @ JumpMineAmmo] = 0;
	$TeamItemCount[5 @ JumpMineAmmo] = 0;
	$TeamItemCount[6 @ JumpMineAmmo] = 0;
	$TeamItemCount[7 @ JumpMineAmmo] = 0;

	$TeamItemCount[0 @ CHAPCVehicle] = 0;
	$TeamItemCount[1 @ CHAPCVehicle] = 0;
	$TeamItemCount[2 @ CHAPCVehicle] = 0;
	$TeamItemCount[3 @ CHAPCVehicle] = 0;
	$TeamItemCount[4 @ CHAPCVehicle] = 0;
	$TeamItemCount[5 @ CHAPCVehicle] = 0;
	$TeamItemCount[6 @ CHAPCVehicle] = 0;
	$TeamItemCount[7 @ CHAPCVehicle] = 0;

	$TeamItemCount[0 @ FighterVehicle] = 0;
	$TeamItemCount[1 @ FighterVehicle] = 0;
	$TeamItemCount[2 @ FighterVehicle] = 0;
	$TeamItemCount[3 @ FighterVehicle] = 0;
	$TeamItemCount[4 @ FighterVehicle] = 0;
	$TeamItemCount[5 @ FighterVehicle] = 0;
	$TeamItemCount[6 @ FighterVehicle] = 0;
	$TeamItemCount[7 @ FighterVehicle] = 0;

	$TeamItemCount[0 @ BLAPCVehicle] = 0;
	$TeamItemCount[1 @ BLAPCVehicle] = 0;
	$TeamItemCount[2 @ BLAPCVehicle] = 0;
	$TeamItemCount[3 @ BLAPCVehicle] = 0;
	$TeamItemCount[4 @ BLAPCVehicle] = 0;
	$TeamItemCount[5 @ BLAPCVehicle] = 0;
	$TeamItemCount[6 @ BLAPCVehicle] = 0;
	$TeamItemCount[7 @ BLAPCVehicle] = 0;

	$TeamItemCount[0 @ DeployableDecoyPack] = 0;
	$TeamItemCount[1 @ DeployableDecoyPack] = 0;
	$TeamItemCount[2 @ DeployableDecoyPack] = 0;
	$TeamItemCount[3 @ DeployableDecoyPack] = 0;
	$TeamItemCount[4 @ DeployableDecoyPack] = 0;
	$TeamItemCount[5 @ DeployableDecoyPack] = 0;
	$TeamItemCount[6 @ DeployableDecoyPack] = 0;
	$TeamItemCount[7 @ DeployableDecoyPack] = 0;

	$TeamItemCount[0 @ DeployableForceFieldPack] = 0;
	$TeamItemCount[1 @ DeployableForceFieldPack] = 0;
	$TeamItemCount[2 @ DeployableForceFieldPack] = 0;
	$TeamItemCount[3 @ DeployableForceFieldPack] = 0;
	$TeamItemCount[4 @ DeployableForceFieldPack] = 0;
	$TeamItemCount[5 @ DeployableForceFieldPack] = 0;
	$TeamItemCount[6 @ DeployableForceFieldPack] = 0;
	$TeamItemCount[7 @ DeployableForceFieldPack] = 0;

	$TeamItemCount[0 @ DeployableLForceFieldPack] = 0;
	$TeamItemCount[1 @ DeployableLForceFieldPack] = 0;
	$TeamItemCount[2 @ DeployableLForceFieldPack] = 0;
	$TeamItemCount[3 @ DeployableLForceFieldPack] = 0;
	$TeamItemCount[4 @ DeployableLForceFieldPack] = 0;
	$TeamItemCount[5 @ DeployableLForceFieldPack] = 0;
	$TeamItemCount[6 @ DeployableLForceFieldPack] = 0;
	$TeamItemCount[7 @ DeployableLForceFieldPack] = 0;

	$TeamItemCount[0 @ ChainTurretPack] = 0;
	$TeamItemCount[1 @ ChainTurretPack] = 0;
	$TeamItemCount[2 @ ChainTurretPack] = 0;
	$TeamItemCount[3 @ ChainTurretPack] = 0;
	$TeamItemCount[4 @ ChainTurretPack] = 0;
	$TeamItemCount[5 @ ChainTurretPack] = 0;
	$TeamItemCount[6 @ ChainTurretPack] = 0;
	$TeamItemCount[7 @ ChainTurretPack] = 0;

	$TeamItemCount[0 @ BaseAlarm] = 0;
	$TeamItemCount[1 @ BaseAlarm] = 0;
	$TeamItemCount[2 @ BaseAlarm] = 0;
	$TeamItemCount[3 @ BaseAlarm] = 0;
	$TeamItemCount[4 @ BaseAlarm] = 0;
	$TeamItemCount[5 @ BaseAlarm] = 0;
	$TeamItemCount[6 @ BaseAlarm] = 0;
	$TeamItemCount[7 @ BaseAlarm] = 0;

	$TeamItemCount[0 @ BigInvPack] = 0;
	$TeamItemCount[1 @ BigInvPack] = 0;
	$TeamItemCount[2 @ BigInvPack] = 0;
	$TeamItemCount[3 @ BigInvPack] = 0;
	$TeamItemCount[4 @ BigInvPack] = 0;
	$TeamItemCount[5 @ BigInvPack] = 0;
	$TeamItemCount[6 @ BigInvPack] = 0;
	$TeamItemCount[7 @ BigInvPack] = 0;

	$TeamItemCount[0 @ AARocketPack] = 0;
	$TeamItemCount[1 @ AARocketPack] = 0;
	$TeamItemCount[2 @ AARocketPack] = 0;
	$TeamItemCount[3 @ AARocketPack] = 0;
	$TeamItemCount[4 @ AARocketPack] = 0;
	$TeamItemCount[5 @ AARocketPack] = 0;
	$TeamItemCount[6 @ AARocketPack] = 0;
	$TeamItemCount[7 @ AARocketPack] = 0;

	$TeamItemCount[0 @ DeployableJumpPadPack] = 0;
	$TeamItemCount[1 @ DeployableJumpPadPack] = 0;
	$TeamItemCount[2 @ DeployableJumpPadPack] = 0;
	$TeamItemCount[3 @ DeployableJumpPadPack] = 0;
	$TeamItemCount[4 @ DeployableJumpPadPack] = 0;
	$TeamItemCount[5 @ DeployableJumpPadPack] = 0;
	$TeamItemCount[6 @ DeployableJumpPadPack] = 0;
	$TeamItemCount[7 @ DeployableJumpPadPack] = 0;

	$TeamItemCount[0 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[1 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[2 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[3 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[4 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[5 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[6 @ AntiMatterTurretPack] = 0;
	$TeamItemCount[7 @ AntiMatterTurretPack] = 0;

	$TeamItemCount[0 @ SniperPadPack] = 0;
	$TeamItemCount[1 @ SniperPadPack] = 0;
	$TeamItemCount[2 @ SniperPadPack] = 0;
	$TeamItemCount[3 @ SniperPadPack] = 0;
	$TeamItemCount[4 @ SniperPadPack] = 0;
	$TeamItemCount[5 @ SniperPadPack] = 0;
	$TeamItemCount[6 @ SniperPadPack] = 0;
	$TeamItemCount[7 @ SniperPadPack] = 0;

	$TeamItemCount[0 @ DeployableTelePadPack] = 0;
	$TeamItemCount[1 @ DeployableTelePadPack] = 0;
	$TeamItemCount[2 @ DeployableTelePadPack] = 0;
	$TeamItemCount[3 @ DeployableTelePadPack] = 0;
	$TeamItemCount[4 @ DeployableTelePadPack] = 0;
	$TeamItemCount[5 @ DeployableTelePadPack] = 0;
	$TeamItemCount[6 @ DeployableTelePadPack] = 0;
	$TeamItemCount[7 @ DeployableTelePadPack] = 0;

	$TeamItemCount[0 @ DeployableELFTurretPack] = 0;
	$TeamItemCount[1 @ DeployableELFTurretPack] = 0;
	$TeamItemCount[2 @ DeployableELFTurretPack] = 0;
	$TeamItemCount[3 @ DeployableELFTurretPack] = 0;
	$TeamItemCount[4 @ DeployableELFTurretPack] = 0;
	$TeamItemCount[5 @ DeployableELFTurretPack] = 0;
	$TeamItemCount[6 @ DeployableELFTurretPack] = 0;
	$TeamItemCount[7 @ DeployableELFTurretPack] = 0;

	$TeamItemCount[0 @ DeployableLRMotionSensorPack] = 0;
	$TeamItemCount[1 @ DeployableLRMotionSensorPack] = 0;
	$TeamItemCount[2 @ DeployableLRMotionSensorPack] = 0;
	$TeamItemCount[3 @ DeployableLRMotionSensorPack] = 0;
	$TeamItemCount[4 @ DeployableLRMotionSensorPack] = 0;
	$TeamItemCount[5 @ DeployableLRMotionSensorPack] = 0;
	$TeamItemCount[6 @ DeployableLRMotionSensorPack] = 0;
	$TeamItemCount[7 @ DeployableLRMotionSensorPack] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;
	$totalNumChainTurrets = 0;

	cleanUpHacks(); //RSP

	for(%i = -1; %i < 8 ; %i++) { // RSP
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
		$totalNumAlarms[%i] = 0;
		$RSP::NukeActive[%i] = False;

		$RSP::TeleportPadID[%i @ " " @ 0] = 0;
		$RSP::TeleportPadID[%i @ " " @ 1] = 0;
	}
}