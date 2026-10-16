//----------------------------------------------------------------------------

$ItemFavoritesKey = "DeltaForce";  // Change this if you add new items
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

// DELTA FORCE
$AutoUse[SOCOM] = True;
$AutoUse[OICW] = True;
// END DELTA FORCE

$Use[SOCOM] = True;

// DELTA FORCE
$ArmorType[Male, SpecOpsArmor] = carmor;
$ArmorType[Male, PilotArmor] = larmor;
$ArmorType[Male, ArtilleryArmor] = aarmor;
$ArmorType[Female, SpecOpsArmor] = cfemale;
$ArmorType[Female, PilotArmor] = lfemale;
$ArmorType[Female, ArtilleryArmor] = afemale;
// END DELTA FORCE

// DELTA FORCE
$ArmorName[carmor] = SpecOpsArmor;
$ArmorName[larmor] = PilotArmor;
$ArmorName[aarmor] = ArtilleryArmor;
$ArmorName[cfemale] = SpecOpsArmor;
$ArmorName[lfemale] = PilotArmor;
$ArmorName[afemale] = ArtilleryArmor;
// END DELTA FORCE

// Amount to remove when selling or dropping ammo
// DELTA FORCE
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[SOCOMAmmo] = 10;
$SellAmmo[OICWAmmo] = 25;
// END DELTA FORCE

// Max Amount of ammo the Ammo Pack can carry
// DELTA FORCE
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 2;
$AmmoPackMax[Beacon] = 10;
$AmmoPackMax[PSG1Ammo] = 5;
$AmmoPackMax[FiftyCalAmmo] = 3;
$AmmoPackMax[SOCOMAmmo] = 20;
$AmmoPackMax[OICWAmmo] = 50;
$AmmoPackMax[AutoShotgunAmmo] = 50;
$AmmoPackMax[SAWAmmo] = 50;
$AmmoPackMax[StingerAmmo] = 1;
$AmmoPackMax[MP5Ammo] = 50;
$AmmoPackMax[LAWAmmo] = 1;
$AmmoPackMax[FlameAmmo] = 50;
$AmmoPackMax[HowitzerAmmo] = 2;
// END DELTA FORCE

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
// DELTA FORCE
$AmmoPackItems[8] = SOCOMAmmo;
$AmmoPackItems[9] = OICWAmmo;
$AmmoPackItems[10] = SAWAmmo;
$AmmoPackItems[11] = MP5Ammo;
$AmmoPackItems[12] = PSG1Ammo;
$AmmoPackItems[13] = LAWAmmo;
$AmmoPackItems[14] = HowitzerAmmo;
$AmmoPackItems[15] = FiftyCalAmmo;
$AmmoPackItems[16] = AutoShotgunAmmo;
$AmmoPackItems[17] = StingerAmmo;
$AmmoPackItems[18] = FlameAmmo;
$AmmoPackItems[19] = Grenade;
$AmmoPackItems[20] = MineAmmo;

$NumAPackItems = 20;

$SmallAmmoPackItems[0] = SOCOMAmmo;
$SmallAmmoPackItems[1] = OICWAmmo;
$SmallAmmoPackItems[2] = MP5Ammo;
$SmallAmmoPackItems[3] = PSG1Ammo;
$SmallAmmoPackItems[4] = Beacon;

$SmallAmmoPackMax[SOCOMAmmo] = 20;
$SmallAmmoPackMax[OICWAmmo] = 50;
$SmallAmmoPackMax[MP5Ammo] = 50;
$SmallAmmoPackMax[PSG1Ammo] = 5;
$SmallAmmoPackMax[Beacon] = 5;

$NumSAPackItems = 5;

$HeavyAmmoPackItems[0] = SAWAmmo;
$HeavyAmmoPackItems[1] = FiftyCalAmmo;
$HeavyAmmoPackItems[2] = AutoShotgunAmmo;
$HeavyAmmoPackItems[3] = FlameAmmo;

$HeavyAmmoPackMax[SAWAmmo] = 50;
$HeavyAmmoPackMax[FiftyCalAmmo] = 3;
$HeavyAmmoPackMax[AutoShotgunAmmo] = 50;
$HeavyAmmoPackMax[FlameAmmo] = 50;

$NumHAPackItems = 4;

$ExpAmmoPackItems[0] = LAWAmmo;
$ExpAmmoPackItems[1] = StingerAmmo;
$ExpAmmoPackItems[2] = Grenade;
$ExpAmmoPackItems[3] = MineAmmo;

$ExpAmmoPackMax[LAWAmmo] = 1;
$ExpAmmoPackMax[StingerAmmo] = 1;
$ExpAmmoPackMax[Grenade] = 2;
$ExpAmmoPackMax[MineAmmo] = 5;

$NumEAPackItems = 4;
// END DELTA FORCE

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
// DELTA FORCE
$TeamItemMax[DeployableHealthPack] = 5;
$TeamItemMax[ReloaderPack] = 5;
$TeamItemMax[PortGenPack] = 3;
$TeamItemMax[AirstrikePack] = 4;
$TeamItemMax[GrapplePack] = 5;
$TeamItemMax[SAMPack] = 4;
$TeamItemMax[HowitzerPack] = 3;
$TeamItemMax[AAPack] = 2;
$TeamItemMax[TwentyPack] = 3;
$TeamItemMax[HornetVehicle] = 30;
$TeamItemMax[TomcatVehicle] = 20;
$TeamItemMax[FalconVehicle] = 20;
$TeamItemMax[EagleVehicle] = 30;
$TeamItemMax[WarthogVehicle] = 30;
$TeamItemMax[BomberVehicle] = 30;
$TeamItemMax[HerculesVehicle] = 30;
$TeamItemMax[Charge] = 3;
// END DELTA FORCE


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
// DELTA FORCE
$WeaponAmmo[SOCOM] = SOCOMAmmo;
$WeaponAmmo[OICW] = OICWAmmo;
$WeaponAmmo[Stinger] = StingerAmmo;
$WeaponAmmo[Minigun] = MinigunAmmo;
$WeaponAmmo[AbramsGun] = AbramsAmmo;
$WeaponAmmo[TOW] = TOWAmmo;

$AmmoWeapon[MinigunAmmo] = Minigun;
$AmmoWeapon[AbramsAmmo] = AbramsGun;
$AmmoWeapon[TOWAmmo] = TOW;
$AmmoWeapon[AutoGrenAmmo] = AutoGrenLauncher;
// END DELTA FORCE


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
	%extraAmmo = 0;
	%mountItem = Player::getMountedItem(%client,$BackpackSlot);
	if (%mountItem == ammopacksmall && $SmallAmmoPackMax[%item] != "")
	{
		%extraAmmo = $SmallAmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	} else if(%mountItem == ammopackheavy && $HeavyAmmoPackMax[%item] != "")
	{
		%extraAmmo = $HeavyAmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	} else if(%mountItem == ammopackexp && $ExpAmmoPackMax[%item] != "")
	{
		%extraAmmo = $ExpAmmoPackMax[%item];
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
	%team = GameBase::getTeam(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if (%item.className == Armor) {
			// Assign armor by requested type & gender
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) {
					// DELTA FORCE
					// Sniper limitations
					if(%item == "SniperArmor")
					{
						if($SniperCount[%team] >= ($Server::SniperLimit * getTeamNumPlayers(%team)))
						{
							Client::sendMessage(%client,0,"Your team has too many snipers");

							// Bug fix - make sure the player is actually wearing something...
							%buyarmor = $ArmorType[Client::getGender(%client), "InfantryArmor"];
							Player::setArmor(%client,%buyarmor);
							teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
							Player::setArmor(%client,%buyarmor);
							checkMax(%client,%buyarmor);
							armorChange(%client);
     						Player::setItemCount(%client, $ArmorName[%armor], 0);  
     						Player::setItemCount(%client, "InfantryArmor", 1);

							return 0;
						} else
						{
							$SniperCount[%team]++;
						}
					} else if(%armor == "sarmor" || %armor == "sfemale")
					{
						$SniperCount[%team]--;
					}
					// END DELTA FORCE
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
     				Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				Player::setItemCount(%client, %item, 1);    
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopacksmall) 
						fillSmallAmmoPack(%client);
					else if (Player::getMountedItem(%client,$BackpackSlot) == ammopackheavy) 
						fillHeavyAmmoPack(%client);
					else if (Player::getMountedItem(%client,$BackpackSlot) == ammopackexp) 
						fillExpAmmoPack(%client);	
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
				if(%pack == ammopacksmall || %pack == ammopackheavy || %pack == ammopackexp) 
					checkMax(%client,%armor);
				// DELTA FORCE
				if(%item == sampack) Bottomprint(%client, "The SAM Launcher is a powerful anti-aircraft weapon which fires automatically.", 6);
				if(%item == parachute) Bottomprint(%client, "The essential device of a Paratrooper, the Parachute is the only thing that turns a terrifying plunge to earth into a gentle gliding descent.", 6);
				// END DELTA FORCE	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == ammopacksmall) 
					fillSmallAmmoPack(%client);
				else if(%item == ammopackheavy) 
					fillHeavyAmmoPack(%client);
				else if(%item == ammopackexp) 
					fillExpAmmoPack(%client);
				else if(%item == reloaderpack)
					$ReloaderPackLeft[%client] = 100;
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%item == ammopacksmall) 
					fillSmallAmmoPack(%client);
				else if(%item == ammopackheavy) 
					fillHeavyAmmoPack(%client);
				else if(%item == ammopackexp) 
					fillExpAmmoPack(%client);
				else if(%item == reloaderpack)
					$ReloaderPackLeft[%client] = 100;
			}				 
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
				// DELTA FORCE
				if(%item == Flamethrower && Player::getItemCount(%client,"FuelPack") == 0) {
					buyItem(%client,"FuelPack");
					Client::sendMessage(%client,0,"Bought Flamethrower - Auto buying Fuel Pack");
				}
				if(%item == SOCOM) Bottomprint(%client, "The Colt 45 Pistol is the preferred sidearm of many armed forces units. It has high stopping power, but a low fire rate and ammo capacity, making it more of a weapon of last resort.", 6);
				if(%item == OICW) Bottomprint(%client, "The M-16 is a standard assault rifle. It has good stopping power and a fairly high fire rate, combined with good accuracy at both medium and short ranges.", 6);
				if(%item == Stinger) Bottomprint(%client, "The Stinger is a man-portable SAM (Surface-to-Air Missile) Launcher that fires a small yet powerful heat-seeking warhead. It will not fire unless it is locked on to a valid target, so it is useless against all other targets besides aircraft.", 6);
				// END DELTA FORCE
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
				// DELTA FORCE
				if(%item == HornetVehicle) Bottomprint(%client, "The F/A-18 Hornet is the future of naval aviation and nice utility jet. Armed with an M61 Vulcan Cannon, AIM-9 Sidewinders, AGM-88A HARMs, and one Mk28 Bomb.", 6);
				if(%item == TomcatVehicle) Bottomprint(%client, "The F-14 Tomcat is the poster jet for the Top Gun. The Tomcat is a naval based aircraft designed for dogfighting.", 6);
				if(%item == FalconVehicle) Bottomprint(%client, "The F-16 Falcon is a widely used Air Force Jet known for it's fighting capabilities. It's armed with Air-to-Air Missiles and Air-to-Ground Missiles.", 6);
				if(%item == EagleVehicle) Bottomprint(%client, "The F-15 Eagle is fast fighter jet built for the best dogfighters in the world. It is armed with a M61 Vulcan Cannon and all Air-to-Air Missiles.", 6);
				if(%item == WarthogVehicle) Bottomprint(%client, "The A-10 Warthog is known for it's tank killing abilities. The A-10 is built similar to a WWII fighter and is excellent for Attack missions.", 6);
				if(%item == BomberVehicle) Bottomprint(%client, "The B-52 Stratofortress is a giant bomber full with 15 mk82 bombs and 5 CBU-87s. It also hase CALCM Cruise Missiles mounted on the sides.", 6);
				if(%item == HerculesVehicle) Bottomprint(%client, "The C-130A Hercules is a transport carrier for and kind of personel and troops.", 6);
				// END DELTA FORCE
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
			else if (%item == ammopacksmall || %item == ammopackheavy || %item == ammopackexp) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
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

				%client.throwStrength = 0.3 + 0.35 * (%strength / 100);
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

// DELTA FORCE
$NextWeapon[SOCOM] = OICW;
$NextWeapon[OICW] = SAW;
$NextWeapon[SAW] = MP5;
$NextWeapon[MP5] = PSG1;
$NextWeapon[PSG1] = FiftyCal;
$NextWeapon[FiftyCal] = LAW;
$NextWeapon[LAW] = Howitzer;
$NextWeapon[Howitzer] = Airstrike;
$NextWeapon[Airstrike] = Minigun;
$NextWeapon[Minigun] = AbramsGun;
$NextWeapon[AbramsGun] = TOW;
$NextWeapon[TOW] = AutoGrenLauncher;
$NextWeapon[AutoGrenLauncher] = AutoShotgun;
$NextWeapon[AutoShotgun] = Stinger;
$NextWeapon[Stinger] = Flamethrower;
$NextWeapon[Flamethrower] = RepairGun;
$NextWeapon[RepairGun] = MedicGun;
$NextWeapon[MedicGun] = GrappleHook;
$NextWeapon[GrappleHook] = SOCOM;

$PrevWeapon[OICW] = SOCOM;
$PrevWeapon[SOCOM] = GrappleHook;
$PrevWeapon[Airstrike] = Howitzer;
$PrevWeapon[Howitzer] = LAW;
$PrevWeapon[LAW] = FiftyCal;
$PrevWeapon[FiftyCal] = PSG1;
$PrevWeapon[PSG1] = MP5;
$PrevWeapon[MP5] = SAW;
$PrevWeapon[SAW] = OICW;
$PrevWeapon[Minigun] = Airstrike;
$PrevWeapon[AbramsGun] = Minigun;
$PrevWeapon[TOW] = AbramsGun;
$PrevWeapon[AutoGrenLauncher] = TOW;
$PrevWeapon[AutoShotgun] = AutoGrenLauncher;
$PrevWeapon[Stinger] = AutoShotgun;
$PrevWeapon[Flamethrower] = Stinger;
$PrevWeapon[RepairGun] = Flamethrower;
$PrevWeapon[MedicGun] = RepairGun;
$PrevWeapon[GrappleHook] = MedicGun;
// END DELTA FORCE

function remoteNextWeapon(%client)
{
	%vehicle = Client::getControlObject(%client);
	%name = GameBase::getDataName(%vehicle);
	// If the player is flying something...
	if(%name == Hornet || %name == Tomcat || %name == Falcon || %name == Eagle || %name == Bomber || %name == Hercules || %name == Warthog || %name == MoveWarthog)
	{
		%weaponNum = $VehiclePrimaryGuns[%name];
		if(%weaponNum > 0) {
			if($VehicleCurWeapon[%vehicle] < (%weaponNum-1))
				$VehicleCurWeapon[%vehicle]++;
			else
				$VehicleCurWeapon[%vehicle] = 0;
			
			%weapPName = $WeaponDesc[$VehicleWeapon[%name,$VehicleCurWeapon[%vehicle]]];
			%weapName = $VehicleWeapon[%name,$VehicleCurWeapon[%vehicle]];

			Bottomprint(%client, "<jc>" @ %weapPName @ " selected", 3);

			%enerLevel = $VehicleWeaponAmmo[%vehicle, %weapName] / $VehicleWeaponAmmoMax[%name, %weapName] * 100;
			GameBase::setEnergy(%vehicle, %enerLevel);
		}		
	} else { // Just a standard weapon change
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
}

function remotePrevWeapon(%client)
{
	%vehicle = Client::getControlObject(%client);
	%name = GameBase::getDataName(%vehicle);
	// If the player is flying something...
	if(%name == Hornet || %name == Tomcat || %name == Falcon || %name == Eagle || %name == Bomber || %name == Hercules || %name == Warthog || %name == MoveWarthog)
	{
		%weaponNum = $VehiclePrimaryGuns[%name];
		if(%weaponNum > 0) {
			if($VehicleCurWeapon[%vehicle] == 0)
				$VehicleCurWeapon[%vehicle] = %weaponNum-1;
			else
				$VehicleCurWeapon[%vehicle]--;

			%weapPName = $WeaponDesc[$VehicleWeapon[%name,$VehicleCurWeapon[%vehicle]]];
			%weapName = $VehicleWeapon[%name,$VehicleCurWeapon[%vehicle]];

			Bottomprint(%client, "<jc>" @ %weapPName @ " selected", 3);

			%enerLevel = $VehicleWeaponAmmo[%vehicle, %weapName] / $VehicleWeaponAmmoMax[%name, %weapName] * 100;
			GameBase::setEnergy(%vehicle, %enerLevel);
		}
	} else {  // Just a standard weapon change
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
	%item = Flamethrower;
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
			%extraAmmo = 0;
			%mountItem = Player::getMountedItem(%client,$BackpackSlot);
			if ((%mountItem == ammopacksmall || %mountItem == ammopackheavy || %mountItem == ammopackexp) && $AmmoPackMax[%item] != "") 
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
// DELTA FORCE ARMOR
// ------------------------------------

ItemData SpecOpsArmor
{
   heading = "aArmor";
	description = "Paratrooper";
	className = "Armor";
	price = 350;
};

ItemData PilotArmor
{
   heading = "aArmor";
	description = "Pilot";
	className = "Armor";
	price = 200;
};

ItemData ArtilleryArmor
{
   heading = "aArmor";
	description = "Engineer";
	className = "Armor";
	price = 400;
};

// END DELTA FORCE ARMOR
// -------------------------------------------------

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

// DELTA FORCE VEHICLES
// --------------------------------------------

ItemData HornetVehicle
{
	description = "F/A-18 Hornet";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1100;
};

ItemData TomcatVehicle
{
	description = "F-14 Tomcat";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1500;
};

ItemData FalconVehicle
{
	description = "F-16 Falcon";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1000;
};

ItemData EagleVehicle
{
	description = "F-15 Eagle";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1100;
};

ItemData WarthogVehicle
{
	description = "A-10 Warthog";
	className = "Vehicle";
   heading = "aVehicle";
	price = 2000;
};

ItemData BomberVehicle
{
	description = "B-52 Stratofortress";
	className = "Vehicle";
   heading = "aVehicle";
	price = 20000;
};

ItemData HerculesVehicle
{
	description = "C-130A Hercules";
	className = "Vehicle";
	heading = "aVehicle";
	price = 15000;
};

// ---------------------------------------------
//END DELTA FORCE VEHICLES

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

// DELTA FORCE WEAPONS
// ------------------------------------------

ItemData SOCOMAmmo
{
	description = "Colt 45 Clip";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SOCOMImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.5;

	ammoType = SOCOMAmmo;
	projectileType = SAWBullet;
	accuFire = true;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SOCOM
{
   heading = "bWeapons";
	description = "Colt 45 Pistol";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = SOCOMImage;
	price = 85;
	showWeaponBar = true;
};

// -------------------------------------------

ItemData OICWAmmo
{
	description = "M-16 Clip";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData OICWImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = OICWAmmo;
	projectileType = NATOBullet;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.25;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData OICW
{
	description = "M-16 Assault Rifle";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = OICWImage;
	price = 175;
	showWeaponBar = true;
};

// ------------------------------------------

ItemData SAWAmmo
{
	description = "M249 Belt";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SAWImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;

	ammoType = SAWAmmo;
	projectileType = SAWBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData SAW
{
	description = "M249 SAW";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SAWImage;
	price = 125;
	showWeaponBar = true;
};

// ----------------------------------------

ItemData MP5Ammo
{
	description = "MP5 Clip";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MP5Image
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MP5Ammo;
	//projectileType = SAWBullet;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.2;

	sfxActivate = SoundPickUpWeapon;
};

ItemData MP5
{
	description = "Silenced MP5";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MP5Image;
	price = 175;
	showWeaponBar = true;
};

function MP5Loading(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,MP5,$WeaponSlot);	
}

function MP5Image::onFire(%player, %slot) {
	%cl = Player::getClient(%player);
	if ($MP5NotReady[%cl] == 0) {
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		if($MP5Mode[%cl] == 1) { // Three-shot Burst
			%ammoRemaining = Player::getItemCount(%player, MP5Ammo);
			if(%ammoRemaining > 3)
				%ammoRemaining = 3;
			for (%i = 0; %i < %ammoRemaining; %i++) 
			{
				schedule("Projectile::spawnProjectile(\"SAWBullet\", GameBase::getMuzzleTransform("@%player@"), "@%player@", Item::getVelocity("@%player@"));", %i * 0.1);
				schedule("Player::decItemCount("@%player@", MP5Ammo);", %i * 0.1);
			}
			$MP5NotReady[%cl] = 1;
			schedule("$MP5NotReady["@%cl@"] = 0;", 0.7);
		} else
		{
			Projectile::spawnProjectile("SAWBullet", %trans, %player, %vel);
			Player::decItemCount(%player, MP5Ammo);
		}
	} else MP5Loading(%player);
}

// ----------------------------------------

ItemData PSG1Ammo
{
	description = "PSG-1 Clip";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData PSG1Image
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PSG1Ammo;
	projectileType = PSG1Bullet;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PSG1
{
	description = "PSG-1 Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PSG1Image;
	price = 200;
	showWeaponBar = true;
};

// ----------------------------------------

ItemData FiftyCalAmmo
{
	description = "Robar Clip";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FiftyCalImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FiftyCalAmmo;
	projectileType = FiftyCalBullet;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0.5;

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData FiftyCal
{
	description = "Robar Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FiftyCalImage;
	price = 250;
	showWeaponBar = true;
};

// ----------------------------------------

ItemData AutoShotgunAmmo
{
	description = "Shotgun Shells";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AutoShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = AutoShotgunAmmo;
	//projectileType = AutoShotgunFlechette;
	accuFire = true;
	reloadTime = 0.3;
	fireTime = 0.2;

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData AutoShotgun
{
	description = "SPAS-12 Auto Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AutoShotgunImage;
	price = 300;
	showWeaponBar = true;
};

function AutoShotgunImage::onFire(%player, %slot) 
{
	%cl = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%cl);
	if ($ShotgunMode[%cl] == 0) {   // Flechette Mode
		for (%i = 0; %i < 8; %i++) {
			Projectile::spawnProjectile("AutoShotgunFlechette", %trans, %player, Item::getVelocity(%player));
		}
	} else {				  // Slug Mode
		Projectile::spawnProjectile("AutoShotgunSlug", %trans, %player, Item::getVelocity(%player));
	}
	Player::decItemCount(%player, AutoShotgunAmmo);
}

// ----------------------------------------

ItemData LAWAmmo
{
	description = "LAW Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData LAWImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountRotation = { 0, 0, 3.14 };

	weaponType = 0; // Single Shot
	ammoType = LAWAmmo;
	projectileType = LAWRocket;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData LAW
{
	description = "LAW";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LAWImage;
	price = 200;
	showWeaponBar = true;
};

// ---------------------------------------------

ItemData FlameAmmo
{
	description = "Flamethrower Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 8;
};

ItemImageData FlamethrowerImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = FlameAmmo;
	projectileType = Flame;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Flamethrower
{
	description = "Flamethrower";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlamethrowerImage;
	price = 300;
	showWeaponBar = true;
};

function Flamethrower::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == FuelPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have a Fuel Pack to use the Flamethrower."); 
}

// ---------------------------------------------

ItemData StingerAmmo
{
	description = "Stinger Missiles";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData StingerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, -1.57, 0 };
	mountOffset = { 0, -0.5, 0.2 };

	weaponType = 0; // Single Shot
	ammoType = StingerAmmo;
	//projectileType = StingerMissile;
	accuFire = true;
	reloadTime = 4.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Stinger
{
	description = "Stinger SAM Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = StingerImage;
	price = 300;
	showWeaponBar = true;
};

function StingerLoading(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,Stinger,$WeaponSlot);
}

function StingerImage::onFire(%player, %slot)
{
	GameBase::getLOSInfo(%player, 1000);
	if (GameBase::getDataName($los::object) == Hornet || GameBase::getDataName($los::object) == Tomcat || GameBase::getDataName($los::object) == Falcon || GameBase::getDataName($los::object) == Eagle|| GameBase::getDataName($los::object) == Bomber || GameBase::getDataName($los::object) == Hercules) {
		remoteEval(Player::getClient(%player), BP, "<f0><jc>Target Lock Achieved", 3);
		%trans = GameBase::getMuzzleTransform(%player);
		Projectile::spawnProjectile("StingerMissile", %trans, %player, Item::getVelocity(%player), $los::object);
		Player::decItemCount(%player, StingerAmmo);
	} else {
		remoteEval(Player::getClient(%player), BP, "<f0><jc>Invalid Target", 2);
		Client::sendMessage(Player::getClient(%player), 0, "~wError_Message.wav");
		StingerLoading(%player);
	}
}


// ---------------------------------------------

ItemData HowitzerAmmo
{
	description = "Howitzer Shells";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData HowitzerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = HowitzerAmmo;
	projectileType = HowitzerShell;
	accuFire = false;
	reloadTime = 1.0;
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

ItemData Howitzer
{
	description = "Howitzer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HowitzerImage;
	price = 375;
	showWeaponBar = true;
};

// -------------------------------------

ItemData AbramsAmmo
{
	description = "105mm Shells";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AbramsGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.5, 0, -0.05 };

	weaponType = 0; // Single Shot
	ammoType = AbramsAmmo;
	reloadTime = 1.5;
	fireTime = 0.5;

	projectileType = AbramsShell;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData AbramsGun
{
	description = "Abrams Gun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AbramsGunImage;
	price = 999;
	showWeaponBar = true;
};

// ----------------------------------

function sendGameTeamMessage(%teamNum, %msg) {
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId)) {
		%tNum = Client::getTeam(%clientId);
		if (%tNum == %teamNum) Client::sendMessage(%clientId, 1, %msg);
	}
}

ItemImageData AirstrikeImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 1; // Single (Sustained)
	// projectileType = FakeStuff;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;
	reloadTime = 0.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Airstrike
{
	description   = "Airstrike";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = AirstrikeImage;
	price         = 999;
	showWeaponBar = false;
};

// HACK!
$AirTime[0] = 0.1;
$AirTime[1] = 0.2;
$AirTime[2] = 0.3;
$AirTime[3] = 0.4;
$AirTime[4] = 0.5;

function AirstrikeImage::onFire(%player, %slot) {
	//%tform = Gamebase::getMuzzleTransform(%player);
	%clientId = Gamebase::getOwnerClient(%player);
	
	$tempCount[%player]++;

	// If the player is activating the airstrike for the first time, start the count
	if($airstrikeIn[%player] == 0) {
		$airstrikeIn[%player] = 16;
		Client::sendMessage(%clientId, 1, "Airstrike called in - designate target for 15 seconds");
		$AirstrikePos[%player] = GameBase::getPosition(%player);
		if(Client::getTeam(%clientId) == 0) {
			%numOtherTeam = 1;
		} else %numOtherTeam = 0;
		sendGameTeamMessage(%numOtherTeam, "Beware - the enemy is calling in an airstrike.~wsniper.wav");
		schedule("decAirstrike(" @ %player @ "," @ %clientId @ ");", 1);
	}

	// If the count has run out, "call in" the airstrike and remove the pack 
	if($airstrikeIn[%player] == 1) {
		//Projectile::spawnProjectile("AirstrikeShot", %transform, %player, Item::getVelocity(%player));
		GameBase::getLOSInfo(%player, 5000);
		%tx = getWord($los::position, 0);
		%ty = getWord($los::position, 1);
		%tz = getWord($los::position, 2);
		%tz += 200;
		//echo("Transform: " @ %transform);
		if($ASMode[%clientId] == 0) {
			%transform = "0 0 0 0 0 0 0 0 0 "@%tx@" "@%ty@" "@%tz@"";
			Projectile::spawnProjectile("AirstrikeShell", %transform, %player, "0 0 0");
		} else {
			%vec = Vector::normalize(Vector::sub($los::position, GameBase::getPosition(%player)));
			%nx = getWord(%vec, 0) * 10;
			%ny = getWord(%vec, 1) * 10;
			for(%i = -2.0; %i < 3.0; %i++) {
				%transform = "0 0 0 0 0 0 0 0 0 "@%tx+(%nx*%i)@" "@%ty+(%ny*%i)@" "@%tz@"";
				Projectile::spawnProjectile("AirFlame", %transform, %player, "0 0 0");
				//schedule("Projectile::spawnProjectile(\"AirFlame\", " @ %transform @ ", " @ %player @ ", \"0 0 0\");", $AirTime[%i+2]);
			}
		}
		$airstrikeIn[%player]--;
		Player::setItemCount(%clientId,Airstrike,0);
		Player::setItemCount(%clientId,AirstrikePack,0);
		Client::sendMessage(%clientId, 1, "Airstrike successful.");
		$successAS[%player] = 1;
		$tempCount[%player] = 0;
		%quitFlag[%player] = 1;
		return;
	}
}

function decAirstrike(%player, %clientId) {
	if ($quitFlag[%player] == 1) {
		$quitFlag[%player] = 0;
		$countRef[%player] = 0;
		$tempCount[$player] = 0;
		$airstrikeIn[%player] = 0;
		return;
	}
	%diff = $tempCount[%player] - $countRef[%player];
	if (%diff < 3 || GameBase::getPosition(%player) != $AirstrikePos[%player]) {
		if ($successAS[%player] == 1) {
			$successAS[%player] = 0;
			return;
		}
		client::sendMessage(%clientId, 1, "Airstrike cancelled.");
		if(Client::getTeam(%clientId) == 0) {
			%numOtherTeam = 1;
		} else %numOtherTeam = 0;
		sendGameTeamMessage(%numOtherTeam, "The enemy has cancelled their airstrike.");
		$airstrikeIn[%player] = 0;
		$tempCount[%player] = 0;
		$countRef[%player] = 0;
		return;
	}	
	$countRef[%player] = $tempCount[%player];	
	$airstrikeIn[%player]--;
	schedule("decAirstrike(" @ %player @ ", " @ %clientId @ ");", 1);
}
			
// -----------------------------------------------

ItemData TOWAmmo
{
	description = "Cruise Missile Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData TOWImage
{
	shapeFile = "magcargo";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = TOWAmmo;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0.15;
	minEnergy = 5;
	maxEnergy = 5;

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData TOW
{
	description = "CALCM Cruise Missile";
	className = "Weapon";
	shapeFile = "magcargo";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TOWImage;
	price = 999;
	showWeaponBar = true;
};

function TOWImage::onFire(%player, %slot)
{
	%cl = Player::getClient(%player);
	if ($FiringTOW[%cl] == 0) {
		//GameBase::playSound(%player,SoundJetHeavy);
		%rot = GameBase::getRotation(%player);
		%pos = GameBase::getPosition(%player);
		%vec = Vector::getFromRot(%rot, 8);
		%pos = ""@getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord(%pos,2)+5@"";
		%newvec = ""@getWord(%vec, 0)+getWord(%pos, 0)@" "@getWord(%vec, 1)+getWord(%pos, 1)@" "@getWord(%vec, 2)+getWord(%pos, 2)@"";
		%tow = newObject("","Flier","TOWMissile", true);
		addToSet("MissionCleanup", %tow);
		GameBase::setTeam(%tow, GameBase::getTeam(%cl));
		GameBase::setPosition(%tow, %newvec);
		GameBase::setRotation(%tow, %rot);
		schedule("Client::setControlObject("@%cl@","@%tow@");", 0.25, %tow);
		Player::decItemCount(%player, TOWAmmo);
		$FiringTOW[%cl] = 1;
		schedule("$FiringTOW["@%cl@"] = 0;", 1);
	}
}

// -----------------------------------------------

ItemData AutoGrenAmmo
{
	description = "Grenades";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData AutoGrenLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = AutoGrenAmmo;
	projectileType = AutoGrenShell;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData AutoGrenLauncher
{
	description = "MK-19-3 Auto Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AutoGrenLauncherImage;
	price = 999;
	showWeaponBar = true;
};

// -----------------------------------------------

ItemData MinigunAmmo
{
	description = "Minigun Rounds";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MinigunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	ammoType = MinigunAmmo;
	reloadTime = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;

	projectileType = NATOBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Minigun
{
	description = "Minigun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MinigunImage;
	price = 999;
	showWeaponBar = true;
};

// -----------------------------------------

ItemImageData ReloaderImage
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

ItemData Reloader
{
   description = "Reloader";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = ReloaderImage;
	showWeaponBar = true;
   price = 300;
};

ItemImageData ReloaderPackImage
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

ItemData ReloaderPack
{
	description = "Reloader";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ReloaderPackImage;
	price = 400;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ReloaderPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Reloader) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function ReloaderPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,Reloader,$WeaponSlot);
	}
}

function ReloaderPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == Reloader) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the Reloader
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

// -------------------------------------------------

ItemImageData FuelPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData FuelPack
{
	description = "Fuel Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FuelPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FuelPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FuelPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FuelPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Flamethrower) 
		Player::unmountItem(%player,$WeaponSlot);
}

// -------------------------------------------------

ItemImageData ParachuteImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        weaponType = 2;  // Sustained
        maxEnergy = 0;  // Energy used/sec for sustained weapons
        minEnergy = 0;
        sfxFire = SoundJammerOn;
        mountOffset = { 0, -0.03, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};

ItemData Parachute
{
        description = "Parachute";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = ParachuteImage;
        price = 100;
        hudIcon = "sensorjamerpack";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function doPara(%player) 
{
	//echo("doPara() called");
      Player::applyImpulse(%player, "0 0 75");
      if ($ParaActivated[%player] == 1) {
	  	if (Player::getLastContactCount(%player) > 5) {
                	schedule("doPara("@%player@");", 0.488);
		//} else ParachuteImage::onDeactivate(%player, $BackpackSlot);
		} else hitGround(%player);
	  }
}

function ParachuteImage::onActivate(%player,%imageSlot)
{
	if($ParaActivated[%player] == 0) {
		%contact = Player::getLastContactCount(%player);
		if(%contact > 11 )
		{
			remoteEval(Player::getClient(%player), BP, "<f0><jc>Parachute Deployed", 4);
			$ParaActivated[%player] = 1;
			doPara(%player);
		}
		else
		{
			Player::trigger(%player, $BackpackSlot, false);
			remoteEval(Player::getClient(%player), BP, "<f0><jc>You must be falling to deploy the Parachute", 4);
		}
	}
}

function ParachuteImage::onDeactivate(%player,%imageSlot)
{}

function hitGround(%player) {
	$ParaActivated[%player] = 0;
    remoteEval(Player::getClient(%player), BP, "<f0><jc>Parachute Discarded", 4);
    Player::trigger(%player,$BackpackSlot,false);
	Player::decItemCount(%player, Parachute);
}

// ------------------------------------------------------------------

ItemImageData GrappleHookImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 1; // Sustained
	//projectileType = Grapple;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	spinUpTime = 0.0;
	spinDownTime = 0;
	fireTime = 0.1;
	reloadTime = 0.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime   = 1;
	lightColor  = { 0, 0, 0 };

	//sfxFire     = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

function GrappleHookImage::onFire(%player, %slot)
{
	%clientPos = GameBase::getPosition(%player);

	if((getSimTime() - $HookTime[%player]) < 0.3)
	{
		// Spawn the rope
		%transform = GameBase::getMuzzleTransform(%player);
		Projectile::spawnProjectile("Grapple", %transform, %player, "0 0 0");

		// Climb it
		%dir = Vector::sub($HookPos[%player], %clientPos);
		%dir = Vector::normalize(%dir);
		%dir = Vector::scale(%dir, 30);
					
		// If the player has grabbed a moving object, inherit its velocity
		if($HookObject[%player])
			%dir = Vector::add(%dir, Item::getVelocity($HookObject[%player]));
					
		Player::applyImpulse(%player, %dir);
		
		$HookTime[%player] = getSimTime();		
	} else
	{
		if(GameBase::getLOSInfo(%player, 1000))
		{
			if(Vector::getDistance(%clientPos, $los::position) <= 50)
			{
				%zDist = getWord($los::position, 2) - getWord(%clientPos, 2);
				if(%zDist >= 5)
				{
					if(getObjectType($los::object) != "Player")
					{
						$HookObject[%player] = 0;
						$HookPos[%player] = $los::position;
						$UsingHook[%player] = 1;
						
						// Spawn the rope
						%transform = GameBase::getMuzzleTransform(%player);
						Projectile::spawnProjectile("Grapple", %transform, %player, "0 0 0");

						// Climb it
						%dir = Vector::sub($los::position, %clientPos);
						%dir = Vector::normalize(%dir);
						%dir = Vector::scale(%dir, 30);
					
						// If the player has grabbed a moving object, inherit its velocity
						if($los::object > 1000)
						{
							$HookObject[%player] = $los::object;
							%dir = Vector::add(%dir, Item::getVelocity($HookObject[%player]));
						}

						Player::applyImpulse(%player, %dir);
					
						$HookTime[%player] = getSimTime();
					}
				}
			}
		}
	}
}

ItemData GrappleHook
{
	description   = "Grappling Hook";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = GrappleHookImage;
	price         = 50;
	showWeaponBar = false;
};

ItemImageData GrapplePackImage
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

ItemData GrapplePack
{
	description = "Grappling Hook";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = GrapplePackImage;
	price = 600;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GrapplePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == GrappleHook) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function GrapplePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,GrappleHook,$WeaponSlot);
	}
}

function GrapplePack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == GrappleHook) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the Grappling Hook
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	


// ------------------------------------------------------------

// END DELTA FORCE WEAPONS

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

ItemImageData MedicGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = MedicBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.0, 0.0, 1.0 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Toolkit";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
};

ItemData MedicGun
{
	description = "Medikit";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = MedicGunImage;
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

function MedicGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function MedicGun::onUnmount(%player,%imageSlot)
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

ItemImageData DeployableHealthPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableHealthPack
{
	description = "Medical Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4;
	imageType = DeployableHealthPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableHealthPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableHealthPack::onDeploy(%player,%item,%pos)
{
	if (DeployableHealthPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableHealthPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape","DeployableHealthStation",true);
	         	   addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Medical Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableHealthPack"]++;
						echo("MSG: ",%client," deployed a Medical Station");
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
	description = "Repair Toolkit";
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

ItemData MedicPack
{
	description = "Medikit";
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

function MedicPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == MedicGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function MedicPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,MedicGun,$WeaponSlot);
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

function MedicPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == MedicGun) {
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
	description = "Radar Jammer Pack";
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

ItemData AmmoPackSmall
{
	description = "Light Ammo Pack";
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

ItemData AmmoPackHeavy
{
	description = "Heavy Ammo Pack";
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

ItemData AmmoPackExp
{
	description = "Explosive Ammo Pack";
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

function AmmoPackSmall::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < $NumSAPackItems ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $SmallAmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}
			schedule("%item."@%ammoItem@" = "@%numPack@";", 0.1);
		}
	}
}

function AmmoPackHeavy::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < $NumHAPackItems ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $HeavyAmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}
			schedule("%item."@%ammoItem@" = "@%numPack@";", 0.1);
		}
	}
}

function AmmoPackExp::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < $NumEAPackItems ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $ExpAmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}
			schedule("%item."@%ammoItem@" = "@%numPack@";", 0.1);
		}
	}
}

function AmmoPackSmall::onCollision(%this, %item)
{
	APonCollision(%this,%object);
}

function AmmoPackHeavy::onCollision(%this, %item)
{
	APonCollision(%this,%object);
}

function AmmoPackExp::onCollision(%this, %item)
{
	APonCollision(%this,%object);
}

function APonDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 8; %i < $NumAPackItems ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 8) {
	 	    	%item.SOCOMAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.OICWAmmo = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.SAWAmmo = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.MP5Ammo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.PSG1Ammo = %numPack;
			}
			else if(%i == 13) {
	 	    	%item.LAWAmmo = %numPack;
			}
			else if(%i == 14) {
			%item.HowitzerAmmo = %numPack;
			}
			else if(%i == 15) {
			%item.FiftyCalAmmo = %numPack;
			}
			else if(%i == 16) {
			%item.AutoShotgunAmmo = %numPack;
			}
			else if(%i == 17) {
			%item.StingerAmmo = %numPack;
			}
			else if(%i == 18) {
			%item.FlameAmmo = %numPack;
			}
			else if(%i == 19) {
			%item.Grenade = %numPack;
			}
			else {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function APonCollision(%this,%object)
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
	for(%i = 8; %i < $NumAPackItems ; %i = %i +1) {
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 8) {
	      %numAdd = %item.SOCOMAmmo;
		}
		else if(%i == 9) {
	    	%numAdd = %item.OICWAmmo;
		}
		else if(%i == 10) {
	    	%numAdd = %item.SAWAmmo;
		}
		else if(%i == 11) {
	    	%numAdd = %item.MP5Ammo;
		}
		else if(%i == 12) {
	    	%numAdd = %item.PSG1Ammo;
		}
		else if(%i == 13) {
 	    	%numAdd = %item.LAWAmmo;
		}
		else if(%i == 14) {
 	    	%numAdd = %item.HowitzerAmmo;
		}
		else if(%i == 15) {
 	    	%numAdd = %item.FiftyCalAmmo;
		}
		else if(%i == 16) {
		%numAdd = %item.AutoShotgunAmmo;
		}
		else if(%i == 17) {
		%numAdd = %item.StingerAmmo;
		}
		else if(%i == 18) {
		%numAdd = %item.FlameAmmo;
		}
		else if(%i == 19) {
 	    	%numAdd = %item.Grenade;
		}
		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillSmallAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $NumSAPackItems ; %i = %i +1) {
		%item = $SmallAmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}
	}
}

function fillHeavyAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $NumHAPackItems ; %i = %i +1) { 
		%item = $HeavyAmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}
	}
}

function fillExpAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < $NumEAPackItems ; %i = %i +1) {
		%item = $ExpAmmoPackItems[%i];
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
	description = "Radar Sensor";
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
	description = "Radar Jammer";
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
	description = "Remote Machine Gun";
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

// DELTA FORCE DEPLOYABLES
// ---------------------------------------------------------

ItemImageData AirstrikePackImage
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

ItemData AirstrikePack
{
	description = "Airstrike";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = AirstrikePackImage;
	price = 1000;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AirstrikePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Airstrike) {
		Player::unmountItem(%player,$WeaponSlot);
	}

	$airstrikeIn[%player] = 0;
}

function AirstrikePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,Airstrike,$WeaponSlot);
	}
}

function AirstrikePack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == Airstrike) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the Airstrike
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

// ---------------------------------------------------------

ItemImageData TwentyPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TwentyPack
{
	description = "20mm Cannon Turret";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TwentyPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TwentyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TwentyPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function TwentyPack::onDeploy(%player,%item,%pos)
{
	if (TwentyPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TwentyPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"DeployablePlasma",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num) { 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"DeployablePlasma",%num); 
					deleteObject(%set); 
					if(0 == %num) { 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
							if(checkDeployArea(%client,$los::position)) { 
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",DeployablePlasma,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"20mm Cannon Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
								Client::sendMessage(%client,0,"20mm Cannon Turret deployed"); 
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TwentyPack"]++;
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true; 
							} 
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); 
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

// --------------------------------------

ItemImageData AAPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData AAPack
{
	description = "AA Flak Gun";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TwentyPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AAPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AAPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function AAPack::onDeploy(%player,%item,%pos)
{
	if (AAPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AAPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"DeployableAA",%num); 
				deleteObject(%set); 
				if($MaxNumTurretsInBox > %num) { 
					%set = newObject("set",SimSet); 
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); 
					%num = CountObjects(%set,"DeployableAA",%num); 
					deleteObject(%set); 
					if(0 == %num) { 
						if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
							if(checkDeployArea(%client,$los::position)) { 
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",DeployableAA,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"AA Flak Gun#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
								Client::sendMessage(%client,0,"AA Flak Gun deployed"); 
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "AAPack"]++;
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true; 
							} 
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); 
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

// --------------------------------------

ItemImageData PortGenImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.15, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PortGenPack
{
	description = "Deployable Generator";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "dDeployables";
	imageType = PortGenImage;
	shadowDetailMask = 4;
	mass = 10.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PortGenPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PortGenPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function PortGenPack::onDeploy(%player,%item,%pos)
{
	if (PortGenPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function checkPower(%this) {
	%num = Group::objectCount($PowerSet[%this]);
	for(%i = 0; %i < %num; %i++) {
		%obj = Group::getObject($PowerSet[%this], %i);
		%objName = GameBase::getDataName(%obj);
		if (%objName == InventoryStation || %objName == AmmoStation || %objName == VehicleStation || %objName == CommandStation || %objName == VehiclePad) {
			if(!GameBase::isPowered(%obj) && $PortGenPower[%obj] == 0) {
				//if (%objName != VehiclePad) {
					GameBase::playSequence(%obj,0,"power");
					GameBase::playSequence(%obj,1);
				//}
				GameBase::setActive(%obj, true);
				$PortGenPower[%obj] = 1;
			}
		}
		else if(GameBase::getClassName(%obj) == "Elevator") {
			echo(%objName @ " detected!");
			if(!GameBase::isPowered(%obj) && $PortGenPower[%obj] == 0) {
				echo(%objName @ " being powered!");
				Elevator::onPower(%obj,true);
				$PortGenPower[%obj] = 1;
			} 
		}
		else if(GameBase::getClassName(%obj) == "Door") {
			echo(%objName @ " detected!");
			if(!GameBase::isPowered(%obj) && $PortGenPower[%obj] == 0) {
				echo(%objName @ " being powered!");
				Door::onPower(%obj,true);
				$PortGenPower[%obj] = 1;
			}
		}
	}
	schedule("checkPower("@%this@");", 5, %this); 
}

function PortGenPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
					if(checkDeployArea(%client,$los::position)) { 
						%rot = GameBase::getRotation(%player); 
						%turret = newObject("generator_p","StaticShape",DeployablePortGen,true); 
						addToSet("MissionCleanup", %turret); 
						GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
						GameBase::setPosition(%turret,$los::position); 
						GameBase::setRotation(%turret,%rot); 
						Gamebase::setMapName(%turret,"Portable Generator#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
						Client::sendMessage(%client,0,"Portable Generator deployed"); 
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "PortGenPack"]++;
						$PowerSet[%turret] = newObject("PowerSet" @ %turret,SimSet);
						%mask = $StaticObjectType | MoveableObjectType;
						%num = containerBoxFillSet($PowerSet[%turret],%mask,$los::position,20,20,20,0);
						if (%num > 0) checkPower(%turret); 
						return true; 
					} 
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

// --------------------------------------

ItemImageData HowitzerPackImage { 
	shapeFile = "ammounit_remote"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, -0.06 }; 
	mountRotation = { 0, 0, 0 }; 
	firstPerson = false; 
}; 

ItemData HowitzerPack { 
	description = "Howitzer"; 
	shapeFile = "mortar_turret"; 
	className = "Backpack"; 
	heading = "dDeployables"; 
	imageType = HowitzerPackImage; 
	shadowDetailMask = 4; 
	mass = 3.0; 
	elasticity = 0.2; 
	price = 800; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function HowitzerPack::onUse(%player,%item) { 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) { 
		Player::mountItem(%player,%item,$BackpackSlot); 
	} else { 
		Player::deployItem(%player,%item); 
	} 
} 

function HowitzerPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function HowitzerPack::onDeploy(%player,%item,%pos) { 
	if (HowitzerPack::deployShape(%player,%item)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function HowitzerPack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); 
				%num = CountObjects(%set,"DeployableMortar",%num); 
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
								%turret = newObject("remoteTurret","Turret",DeployableMortar,true); 
								addToSet("MissionCleanup", %turret); 
								GameBase::setTeam(%turret,GameBase::getTeam(%player)); 
								GameBase::setPosition(%turret,$los::position); 
								GameBase::setRotation(%turret,%rot); 
								Gamebase::setMapName(%turret,"Howitzer#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Howitzer deployed"); 
								playSound(SoundPickupBackpack,$los::position); 
								$TeamItemCount[GameBase::getTeam(%player) @ "HowitzerPack"]++; 
								echo("MSG: ",%client," deployed a Howitzer"); 
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player); 
								return true; 
							} 
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); 
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
} 


// --------------------------------------------------------------------

ItemImageData SAMPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SAMPack
{
	description = "SAM Launcher";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = SAMPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SAMPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SAMPack::onDeploy(%player,%item,%pos)
{
	if (SAMPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function SAMPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSAM",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSAM",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableSAM,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"SAM Launcher#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"SAM Launcher deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "SAMPack"]++;
								echo("MSG: ",%client," deployed a SAM Launcher");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other SAM Launchers");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other launchers in the area");
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
			// DELTA FORCE
			%teamnum = Gamebase::getTeam(%client);
			Gamebase::setTeam(%obj, %teamnum);
			// END DELTA FORCE
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
			GameBase::throw(%obj,%player,9 * %client.throwStrength * 2,false);
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
// DELTA FORCE

ItemImageData ChargeImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData Charge
{
	description = "Explosive Charge";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4;
	imageType = ChargeImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function Charge::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	} else {
		Player::deployItem(%player,%item);
	}
}

function Charge::onDeploy(%player,%item,%pos)
{
	if (Charge::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function Charge::deployShape(%player,%item)
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
					%camera = newObject("Explosive Charge","StaticShape","DefaultCharge",true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Charge::onEnabled(%camera);
					Client::sendMessage(%client,0,"Explosive Charge placed - 15 seconds until detonation");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "Charge"]++;
					echo("MSG: ",%client," placed an Explosive Charge");
					Client::setOwnedObject(%client, %camera); 
					Client::setOwnedObject(%client, %player);
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

// END DELTA FORCE
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Stimulants";
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
	// DELTA FORCE
	$TeamItemCount[0 @ DeployableHealthPack] = 0;
	$TeamItemCount[0 @ TwentyPack] = 0;
	$TeamItemCount[0 @ HowitzerPack] = 0;
	$TeamItemCount[0 @ SAMPack] = 0;
	$TeamItemCount[0 @ GrapplePack] = 0;
	$TeamItemCount[0 @ ApacheVehicle] = 0;
	$TeamItemCount[0 @ WarthogVehicle] = 0;
	$TeamItemCount[0 @ BlackhawkVehicle] = 0;
	$TeamItemCount[0 @ HumveeVehicle] = 0;
	$TeamItemCount[0 @ AbramsVehicle] = 0;
	$TeamItemCount[0 @ BradleyVehicle] = 0;
	$TeamItemCount[0 @ Charge] = 0;
	$TeamItemCount[0 @ AirstrikePack] = 0;
	$TeamItemCount[0 @ ReloaderPack] = 0;
	$TeamItemCount[0 @ PortGenPack] = 0;
	$TeamItemCount[0 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[0] = 0;
	// END DELTA FORCE

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
	// DELTA FORCE
	$TeamItemCount[1 @ DeployableHealthPack] = 0;
	$TeamItemCount[1 @ TwentyPack] = 0;
	$TeamItemCount[1 @ HowitzerPack] = 0;
	$TeamItemCount[1 @ SAMPack] = 0;
	$TeamItemCount[1 @ GrapplePack] = 0;
	$TeamItemCount[1 @ ApacheVehicle] = 0;
	$TeamItemCount[1 @ WarthogVehicle] = 0;
	$TeamItemCount[1 @ BlackhawkVehicle] = 0;
	$TeamItemCount[1 @ HumveeVehicle] = 0;
	$TeamItemCount[1 @ AbramsVehicle] = 0;
	$TeamItemCount[1 @ BradleyVehicle] = 0;
	$TeamItemCount[1 @ Charge] = 0;
	$TeamItemCount[1 @ AirstrikePack] = 0;
	$TeamItemCount[1 @ ReloaderPack] = 0;
	$TeamItemCount[1 @ PortGenPack] = 0;
	$TeamItemCount[1 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[1] = 0;
	// END DELTA FORCE

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
	// DELTA FORCE
	$TeamItemCount[2 @ DeployableHealthPack] = 0;
	$TeamItemCount[2 @ TwentyPack] = 0;
	$TeamItemCount[2 @ HowitzerPack] = 0;
	$TeamItemCount[2 @ SAMPack] = 0;
	$TeamItemCount[2 @ GrapplePack] = 0;
	$TeamItemCount[2 @ ApacheVehicle] = 0;
	$TeamItemCount[2 @ WarthogVehicle] = 0;
	$TeamItemCount[2 @ BlackhawkVehicle] = 0;
	$TeamItemCount[2 @ HumveeVehicle] = 0;
	$TeamItemCount[2 @ AbramsVehicle] = 0;
	$TeamItemCount[2 @ BradleyVehicle] = 0;
	$TeamItemCount[2 @ Charge] = 0;
	$TeamItemCount[2 @ AirstrikePack] = 0;
	$TeamItemCount[2 @ ReloaderPack] = 0;
	$TeamItemCount[2 @ PortGenPack] = 0;
	$TeamItemCount[2 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[2] = 0;
	// END DELTA FORCE

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
	// DELTA FORCE
	$TeamItemCount[3 @ DeployableHealthPack] = 0;
	$TeamItemCount[3 @ TwentyPack] = 0;
	$TeamItemCount[3 @ HowitzerPack] = 0;
	$TeamItemCount[3 @ SAMPack] = 0;
	$TeamItemCount[3 @ GrapplePack] = 0;
	$TeamItemCount[3 @ ApacheVehicle] = 0;
	$TeamItemCount[3 @ WarthogVehicle] = 0;
	$TeamItemCount[3 @ BlackhawkVehicle] = 0;
	$TeamItemCount[3 @ HumveeVehicle] = 0;
	$TeamItemCount[3 @ AbramsVehicle] = 0;
	$TeamItemCount[3 @ BradleyVehicle] = 0;
	$TeamItemCount[3 @ Charge] = 0;
	$TeamItemCount[3 @ AirstrikePack] = 0;
	$TeamItemCount[3 @ ReloaderPack] = 0;
	$TeamItemCount[3 @ PortGenPack] = 0;
	$TeamItemCount[3 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[3] = 0;
	// END DELTA FORCE

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
	// DELTA FORCE
	$TeamItemCount[4 @ DeployableHealthPack] = 0;
	$TeamItemCount[4 @ TwentyPack] = 0;
	$TeamItemCount[4 @ HowitzerPack] = 0;
	$TeamItemCount[4 @ SAMPack] = 0;
	$TeamItemCount[4 @ GrapplePack] = 0;
	$TeamItemCount[4 @ ApacheVehicle] = 0;
	$TeamItemCount[4 @ WarthogVehicle] = 0;
	$TeamItemCount[4 @ BlackhawkVehicle] = 0;
	$TeamItemCount[4 @ HumveeVehicle] = 0;
	$TeamItemCount[4 @ AbramsVehicle] = 0;
	$TeamItemCount[4 @ BradleyVehicle] = 0;
	$TeamItemCount[4 @ Charge] = 0;
	$TeamItemCount[4 @ AirstrikePack] = 0;
	$TeamItemCount[4 @ ReloaderPack] = 0;
	$TeamItemCount[4 @ PortGenPack] = 0;
	$TeamItemCount[4 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[4] = 0;
	// END DELTA FORCE

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
	// DELTA FORCE
	$TeamItemCount[5 @ DeployableHealthPack] = 0;
	$TeamItemCount[5 @ TwentyPack] = 0;
	$TeamItemCount[5 @ HowitzerPack] = 0;
	$TeamItemCount[5 @ SAMPack] = 0;
	$TeamItemCount[5 @ GrapplePack] = 0;
	$TeamItemCount[5 @ ApacheVehicle] = 0;
	$TeamItemCount[5 @ WarthogVehicle] = 0;
	$TeamItemCount[5 @ BlackhawkVehicle] = 0;
	$TeamItemCount[5 @ HumveeVehicle] = 0;
	$TeamItemCount[5 @ AbramsVehicle] = 0;
	$TeamItemCount[5 @ BradleyVehicle] = 0;
	$TeamItemCount[5 @ Charge] = 0;
	$TeamItemCount[5 @ AirstrikePack] = 0;
	$TeamItemCount[5 @ ReloaderPack] = 0;
	$TeamItemCount[5 @ PortGenPack] = 0;
	$TeamItemCount[5 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[5] = 0;
	// END DELTA FORCE

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
	// DELTA FORCE
	$TeamItemCount[6 @ DeployableHealthPack] = 0;
	$TeamItemCount[6 @ TwentyPack] = 0;
	$TeamItemCount[6 @ HowitzerPack] = 0;
	$TeamItemCount[6 @ SAMPack] = 0;
	$TeamItemCount[6 @ GrapplePack] = 0;
	$TeamItemCount[6 @ ApacheVehicle] = 0;
	$TeamItemCount[6 @ WarthogVehicle] = 0;
	$TeamItemCount[6 @ BlackhawkVehicle] = 0;
	$TeamItemCount[6 @ HumveeVehicle] = 0;
	$TeamItemCount[6 @ AbramsVehicle] = 0;
	$TeamItemCount[6 @ BradleyVehicle] = 0;
	$TeamItemCount[6 @ Charge] = 0;
	$TeamItemCount[6 @ AirstrikePack] = 0;
	$TeamItemCount[6 @ ReloaderPack] = 0;
	$TeamItemCount[6 @ PortGenPack] = 0;
	$TeamItemCount[6 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[6] = 0;
	// END DELTA FORCE

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
	// DELTA FORCE
	$TeamItemCount[7 @ DeployableHealthPack] = 0;
	$TeamItemCount[7 @ TwentyPack] = 0;
	$TeamItemCount[7 @ HowitzerPack] = 0;
	$TeamItemCount[7 @ SAMPack] = 0;
	$TeamItemCount[7 @ GrapplePack] = 0;
	$TeamItemCount[7 @ ApacheVehicle] = 0;
	$TeamItemCount[7 @ WarthogVehicle] = 0;
	$TeamItemCount[7 @ BlackhawkVehicle] = 0;
	$TeamItemCount[7 @ HumveeVehicle] = 0;
	$TeamItemCount[7 @ AbramsVehicle] = 0;
	$TeamItemCount[7 @ BradleyVehicle] = 0;
	$TeamItemCount[7 @ Charge] = 0;
	$TeamItemCount[7 @ AirstrikePack] = 0;
	$TeamItemCount[7 @ ReloaderPack] = 0;
	$TeamItemCount[7 @ PortGenPack] = 0;
	$TeamItemCount[7 @ AAPack] = 0;
	// Sniper Limit
	$SniperCount[7] = 0;
	// END DELTA FORCE

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
