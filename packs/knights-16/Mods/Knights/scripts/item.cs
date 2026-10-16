//----------------------------------------------------------------------------

$ItemFavoritesKey = "Knights15PUB";  // Change this if you add new items
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
$ExtraWeaponSlotA=4;
$ExtraWeaponSlotB=5;
$ExtraWeaponSlotC=6;
$ExtraWeaponSlotD=7;

$AutoUse[Blaster] = True;
$AutoUse[Dart] = True;
$AutoUse[Bite] = True;
$AutoUse[Sword] = True;
$AutoUse[Soul] = True;
$AutoUse[ScoutLaser] = True;
$AutoUse[KRGun] = True;
$AutoUse[Dinky1] = True;
$AutoUse[Dinky2] = True;
$AutoUse[Stinger] = True;
$AutoUse[EShotgun] = True;
$AutoUse[KShotgun] = True;
$AutoUse[TankRPGLauncher] = True;
$AutoUse[TRocketLauncher] = True;
$AutoUse[Pistols] = True;
$AutoUse[TankShredder] = True;
$AutoUse[Anti] = True;
$AutoUse[FlameL] = True;
$AutoUse[AlienL] = True;
$AutoUse[ScoutM] = True;
$AutoUse[Arifle] = True;
$AutoUse[BAR] = True;
$AutoUse[RocketL] = True;
$AutoUse[BGun] = True;
$AutoUse[MortarR] = True;
$AutoUse[FlameThrower] = True;
$AutoUse[EMP] = True;
$AutoUse[AlienGat] = True;
$AutoUse[Sniper] = True;
$AutoUse[Dark] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[Mortar] = True;
$AutoUse[ConRocketl] = True; 
$AutoUse[Blade] = True;
$AutoUse[Gas] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[KnightLaser] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[ChronoLaser] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = True;

$Use[Blaster] = True;

$ArmorType[Male, ScoutArmor] = sarmor;
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, SorcererArmor] = oarmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, AlienArmor] = carmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Male, UltraArmor] = uarmor;
$ArmorType[Female, ScoutArmor] = sfemale;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, SorcererArmor] = ofemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, AlienArmor] = cfemale;
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Female, UltraArmor] = uarmor;

$ArmorName[sarmor] = ScoutArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[oarmor] = SorcererArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[carmor] = AlienArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[uarmor] = UltraArmor;
$ArmorName[sfemale] = ScoutArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[ofemale] = SorcererArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorName[cfemale] = AlienArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[DartAmmo] = 5;
$SellAmmo[BARAmmo] = 20;
$SellAmmo[Dinky1Ammo] = 50;
$SellAmmo[Dinky2Ammo] = 5;
$SellAmmo[AntiAmmo] = 100;
$SellAmmo[RocketLAmmo] = 5;
$SellAmmo[ScoutMAmmo] = 5;
$SellAmmo[SniperAmmo] = 5;
$SellAmmo[FlameThrowerAmmo] = 100;
$SellAmmo[TankRPGAmmo] = 10;
$SellAmmo[TRocketLauncherAmmo] = 10;
$SellAmmo[TankShredderAmmo] = 100;
$SellAmmo[KShotgunAmmo] = 5;
$SellAmmo[KRAmmo] = 2;
$SellAmmo[StingerAmmo] = 5;
$SellAmmo[PistolsAmmo] = 10;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[BiteAmmo] = 1;
$SellAmmo[EMPAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GasAmmo] = 10;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[AlienGatAmmo] = 25;
$SellAmmo[MortarRAmmo] = 5;
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

$AmmoPackMax[SniperAmmo] = 10;
$AmmoPackMax[DartAmmo] = 5;
$AmmoPackMax[BARAmmo] = 100;
$AmmoPackMax[AntiAmmo] = 75;
$AmmoPackMax[AlienGatAmmo] = 100;
$AmmoPackMax[Dinky1Ammo] = 50;
$AmmoPackMax[Dinky2Ammo] = 5;
$AmmoPackMax[StingerAmmo] = 5;
$AmmoPackMax[EMPAmmo] = 5;
$AmmoPackMax[FlameThrowerAmmo] = 50;
$AmmoPackMax[ScoutMAmmo] = 10;
$AmmoPackMax[KShotgunAmmo] = 10;
$AmmoPackMax[TankRPGAmmo] = 10;
$AmmoPackMax[TankShredderAmmo] = 50;
$AmmoPackMax[TRocketLauncherAmmo] = 10;
$AmmoPackMax[PistolsAmmo] = 20;
$AmmoPackMax[KRAmmo] = 10;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;

$AmmoPackItems[8] = SniperAmmo;
$AmmoPackItems[9] = DartAmmo;
$AmmoPackItems[10] = BARAmmo;
$AmmoPackItems[11] = AntiAmmo;
$AmmoPackItems[12] = AlienGatAmmo;
$AmmoPackItems[13] = Dinky1Ammo;
$AmmoPackItems[14] = Dinky2Ammo;
$AmmoPackItems[15] = StingerAmmo;
$AmmoPackItems[16] = EMPAmmo;
$AmmoPackItems[17] = FlameThrowerAmmo;
$AmmoPackItems[18] = ScoutMAmmo;
$AmmoPackItems[19] = KShotgunAmmo;
$AmmoPackItems[20] = TankRPGAmmo;
$AmmoPackItems[21] = TankShredderAmmo;
$AmmoPackItems[22] = TRocketLauncherAmmo;
$AmmoPackItems[23] = PistolsAmmo;
$AmmoPackItems[24] = KRAmmo;

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[SlashPack] = 5;
$TeamItemMax[DefenderPack] = 15;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[FFieldPack] = 15;
$TeamItemMax[TargetPack] = 10;
$TeamItemMax[PlatformPack] = 15;
$TeamItemMax[DepFFDoorPack] = 15;
$TeamItemMax[NukePack] = 2;
$TeamItemMax[HealPack] = 4;
$TeamItemMax[GeneratorPack] = 3;
$TeamItemMax[LgFFDoorPack] = 10;
$TeamItemMax[DoorPack] = 5;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 15;
$TeamItemMax[SpeederVehicle] = 8;
$TeamItemMax[MistVehicle] = 4;
$TeamItemMax[HAPCVehicle] = 5;
$TeamItemMax[LAPCVehicle] = 6;
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
$WeaponAmmo[ScoutLaser] = "";
$WeaponAmmo[Dart] = DartAmmo;
$WeaponAmmo[BAR] = BARAmmo;
$WeaponAmmo[Anti] = AntiAmmo;
$WeaponAmmo[Sniper] = SniperAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[Dinky1] = Dinky1Ammo;
$WeaponAmmo[Dinky2] = Dinky2Ammo;
$WeaponAmmo[AlienGat] = AlienGatAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[Stinger] = StingerAmmo;
$WeaponAmmo[TankRPGLauncher] = TankRPGAmmo;
$WeaponAmmo[TRocketLauncher] = TRocketLauncherAmmo;
$WeaponAmmo[TankShredder] = TankShredderAmmo;
$WeaponAmmo[EMP] = EMPAmmo;
$WeaponAmmo[ScoutM] = ScoutMAmmo;
$WeaponAmmo[Gas] = GasAmmo;
$WeaponAmmo[Pistols] = PistolsAmmo;
$WeaponAmmo[KShotgun] = KShotgunAmmo;
$WeaponAmmo[KRGun] = KRAmmo;
$WeaponAmmo[Bite] = BiteAmmo;
$WeaponAmmo[RocketL] = RocketLAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[FlameThrower] = FlameThrowerAmmo;
$WeaponAmmo[MortarR] = MortarRAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[Dark] = "";
$WeaponAmmo[EShotgun] = "";
$WeaponAmmo[Sword] = "";
$WeaponAmmo[BGun] = "";
$WeaponAmmo[AlienL] = "";
$WeaponAmmo[FlameL] = "";
$WeaponAmmo[ConRocketl] = "";
$WeaponAmmo[ARifle] = "";
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[Soul] = "";
$WeaponAmmo[Blade] = "";
$WeaponAmmo[ChronoLaser] = "";
$WeaponAmmo[KnightLaser] = "";
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
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || $RavensCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $RavensCheats || $TestCheats)) {
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

function remoteDeployItem(%client,%type)
{
    //echo("Deploy item: ",%type);
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

//
$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Sniper;
$NextWeapon[Sniper] = BAR;
$NextWeapon[BAR] = ScoutLaser;
$NextWeapon[ScoutLaser] = Dart;
$NextWeapon[Dart] = Anti;
$NextWeapon[Anti] = Chaingun;
$NextWeapon[Chaingun] = Sword;
$NextWeapon[Sword] = Dinky1;
$NextWeapon[Dinky1] = Dinky2;
$NextWeapon[Dinky2] = AlienGat;
$NextWeapon[AlienGat] = DiscLauncher;
$NextWeapon[DiscLauncher] = Bite;
$NextWeapon[Bite] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = FlameThrower;
$NextWeapon[FlameThrower] = Dark;
$NextWeapon[Dark] = EShotgun;
$NextWeapon[EShotgun] = TankShredder;
$NextWeapon[TankShredder] = TRocketLauncher;
$NextWeapon[TRocketLauncher] = TankRPGLauncher;
$NextWeapon[TankRPGLauncher] = ScoutM;
$NextWeapon[ScoutM] = Pistols;
$NextWeapon[Pistols] = KRGun;
$NextWeapon[KRGun] = EMP;
$NextWeapon[EMP] = RocketL;
$NextWeapon[RocketL] = Stinger;
$NextWeapon[Stinger] = Soul;
$NextWeapon[Soul] = Arifle;
$NextWeapon[Arifle] = AlienL;
$NextWeapon[AlienL] = Blade;
$NextWeapon[Blade] = FlameL;
$NextWeapon[FlameL] = BGun;
$NextWeapon[BGun] = KShotgun;
$NextWeapon[KShotgun] = Gas;
$NextWeapon[Gas] = ConRocketl;
$NextWeapon[ConRocketl] = MortarR;
$NextWeapon[MortarR] = Mortar;
$NextWeapon[Mortar] = ChronoLaser;
$NextWeapon[ChronoLaser] = LaserRifle;
$NextWeapon[LaserRifle] = KnightLaser;
$NextWeapon[KnightLaser] = EnergyRifle;

$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Sniper] = PlasmaGun;
$PrevWeapon[BAR] = Sniper;
$PrevWeapon[ScoutLaser] = BAR;
$PrevWeapon[Dart] = ScoutLaser;
$PrevWeapon[Anti] = Dart;
$PrevWeapon[Chaingun] = Anti;
$PrevWeapon[Sword] = Chaingun;
$PrevWeapon[Dinky1] = Sword;
$PrevWeapon[Dinky2] = Dinky1;
$PrevWeapon[AlienGat] = Dinky2;
$PrevWeapon[DiscLauncher] = AlienGat;
$PrevWeapon[Bite] = DiscLauncher;
$PrevWeapon[GrenadeLauncher] = Bite;
$PrevWeapon[FlameThrower] = GrenadeLauncher;
$PrevWeapon[Dark] = FlameThrower;
$PrevWeapon[EShotgun] = Dark;
$PrevWeapon[TankShredder] = EShotgun;
$PrevWeapon[TRocketLauncher] = TankShredder;
$PrevWeapon[TankRPGLauncher] = TRocketLauncher;
$PrevWeapon[ScoutM] = TankRPGLauncher;
$PrevWeapon[Pistols] = ScoutM;
$PrevWeapon[KRGun] = Pistols;
$PrevWeapon[EMP] = KRGun;
$PrevWeapon[RocketL] = EMP;
$PrevWeapon[Stinger] = RocketL;
$PrevWeapon[Soul] = Stinger;
$PrevWeapon[Arifle] = Soul;
$PrevWeapon[AlienL] = Arifle;
$PrevWeapon[Blade] = AlienL;
$PrevWeapon[FlameL] = Blade;
$PrevWeapon[BGun] = FlameL;
$PrevWeapon[KShotgun] = BGun;
$PrevWeapon[Gas] = KShotgun;
$PrevWeapon[ConRocketl] = Gas;
$PrevWeapon[MortarR] = ConRocketl;
$PrevWeapon[Mortar] = MortarR;
$PrevWeapon[ChronoLaser] = Mortar;
$PrevWeapon[LaserRifle] = ChronoLaser;
$PrevWeapon[KnightLaser] = LaserRifle;
$PrevWeapon[EnergyRifle] = KnightLaser;

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
ItemData ScoutArmor
{
   heading = "aArmor";
	description = "Scout";
	className = "Armor";
	price = 125;
};


ItemData LightArmor
{
   heading = "aArmor";
	description = "Assassin";
	className = "Armor";
	price = 275;
};

ItemData SorcererArmor
{
   heading = "aArmor";
	description = "Sorceror";
	className = "Armor";
	price = 350;
};


ItemData MediumArmor
{
   heading = "aArmor";
	description = "Worker";
	className = "Armor";
	price = 637;
};

ItemData AlienArmor
{
   heading = "aArmor";
	description = "Clytranium";
	className = "Armor";
	price = 425;
};

ItemData HeavyArmor
{
   heading = "aArmor";
	description = "Knight";
	className = "Armor";
	price = 1000;
};

ItemData UltraArmor
{
   heading = "aArmor";
	description = "Base Defender";
	className = "Armor";
	price = 1600;
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


ItemData SpeederVehicle
{
	description = "Speeder";
	className = "Vehicle";
   heading = "aVehicle";
	price = 500;
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

ItemData MistVehicle
{
	description = "Shadows";
	className = "Vehicle";
   heading = "aVehicle";
	price = 100;
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
	fireTime = 1.0;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "hAlien";
	description = "Alien Rifle";
	className = "Weapon";
   shapeFile  = "plasma";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 95;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Alien Rifle: <f2>Standard Clytranium weapon. Has a medium rate of fire, a moderate energy usage, and does a good amount of damage.");
}
//----------------------------------------------------------------------------

$TRocketLauncherSlotA=4;
$TRocketLauncherSlotB=7;
$TRocketLauncherSlotC=6; 

ItemData TRocketLauncherAmmo
{	description = "Knight Missiles";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData TRocketLauncherImage 
{	shapeFile = "disc"; 
	mountPoint = 0; 
	mountOffset = { -1.346, 0.1, 0.2 }; 
	mountRotation = { 0, 1.575, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData TRocketLauncher 
{	description = "Knight Missile Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.346, 0.1, 0.1 }; 
	mountRotation = { 0, 1.575, 0 }; 
	hudIcon = "mortar"; 
	heading = "eExplosion";
	shadowDetailMask = 4; 
	imageType = TRocketLauncherImage; 
	price = 2500; 
	showWeaponBar = true; 
}; 

ItemImageData TRocketLauncher2Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
};	

ItemData TRocketLauncher2 
{	description = "Knight Missile Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = TRocketLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData TRocketLauncher3Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
}; 

ItemData TRocketLauncher3 
{	description = "Knight Missile Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = TRocketLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData TRocketLauncher4Image 
{	shapeFile = "disc";
	mountPoint = 0; 
	mountOffset = { 0.15, 0.1, 0.2 };
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
}; 

ItemData TRocketLauncher4 
{	description = "Knight Missile Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	shadowDetailMask = 4; 
	imageType = TRocketLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

//  Begin TRocketLauncher New Fire Function By: Dark Knight
                     
function TRocketLauncherImage::onFire(%player, %slot) 
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[TRocketLauncher]);
	if(%AmmoCount)
	{
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		
		// ------- Second Projectile Placement --------
		
		%pos=gamebase::getposition(%player);
		%rot=gamebase::getrotation(%player);
		%vec=Vector::getFromRot(%rot);
		
		%vec1=getWord(%vec,0);
		%vec2=getWord(%vec,1);
		
		%pos1=getWord(%trans,0);
		%pos2=getWord(%trans,1);
		%pos3=getWord(%trans,2);
		%pos4=getWord(%trans,3);
		%pos5=getWord(%trans,4);
		%pos6=getWord(%trans,5);
		%pos7=getWord(%trans,6);
		%pos8=getWord(%trans,7);
		%pos9=getWord(%trans,8);
		%pos10=getWord(%trans,9) + %vec2;
		%pos11=getWord(%trans,10) - %vec1;
		%pos12=getWord(%trans,11);
		
		%trans2=%pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@" "@%pos12;
		
		// ----- End of Second Projectile Placement -----
		
		if(GameBase::getLOSInfo(%player,1500))
		{	
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Projectile::spawnProjectile("TankMissile",%trans,%player,%vel,$los::object);
				Projectile::spawnProjectile("TankMissile",%trans2,%player,%vel,$los::object);
				Client::sendMessage(%client,3,"Missile lock acquired - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"**WARNING** Missile lock detected - " @ %clientId @ "~waccess_denied.wav");
				if(!$MDFiringTRocketLauncher[%client]) 
					MDCheckTRocketLauncher(%client, %player);
				//GiveKickBack(%player, 125, 1);
				Player::decItemCount(%player,$WeaponAmmo[TRocketLauncher],2);
			}
			else
			{
				Projectile::spawnProjectile("TankRocket",%trans,%player,%vel,%target);
				Projectile::spawnProjectile("TankRocket",%trans2,%player,%vel,%target);
				if(!$MDFiringTRocketLauncher[%client]) 
					MDCheckTRocketLauncher(%client, %player); 
				//GiveKickBack(%player, 125, 1);
				Player::decItemCount(%player,$WeaponAmmo[TRocketLauncher],2);
			}
		}
		else
		{
			Projectile::spawnProjectile("TankRocket",%trans,%player,%vel,%target);
			Projectile::spawnProjectile("TankRocket",%trans2,%player,%vel,%target);
			if(!$MDFiringTRocketLauncher[%client]) 
				MDCheckTRocketLauncher(%client, %player); 
			//GiveKickBack(%player, 125, 1);
			Player::decItemCount(%player,$WeaponAmmo[TRocketLauncher],2);
		}
	}
	else
		Client::sendMessage(%client,0,"Knight Missile Launcher is out of ammo.~waccess_denied.wav");
}

function TRocketLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TRocketLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function TRocketLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,TRocketLauncher2,$TRocketLauncherSlotA); 
	Player::mountItem(%player,TRocketLauncher3,$TRocketLauncherSlotB); 
	Player::mountItem(%player,TRocketLauncher4,$TRocketLauncherSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Knight Missile Launcher: <f2>A dual missile launcher with a lock. What more can I say?");  
}

function TRocketLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TRocketLauncherSlotA);
	Player::unmountItem(%player,$TRocketLauncherSlotB);	 
	Player::unmountItem(%player,$TRocketLauncherSlotC);
}

function MDCheckTRocketLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TRocketLauncher")) 
	{	Player::trigger(%player,$TRocketLauncherSlotA,true);
		Player::trigger(%player,$TRocketLauncherSlotB,true);
		Player::trigger(%player,$TRocketLauncherSlotC,true);
		schedule("MDCheckTRocketLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringTRocketLauncher[%client] = true;
	} 
	else 
	{	Player::trigger(%player,$TRocketLauncherSlotA,false); 
		Player::trigger(%player,$TRocketLauncherSlotB,false); 
		Player::trigger(%player,$TRocketLauncherSlotC,false); 
		$MDFiringTRocketLauncher[%client] = false; 
	} 
}

//----------------------------------------------------------------------------

ItemData TankShredderAmmo 
{	description = "Knight-Chain Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 12;
};

ItemImageData TankShredderImage 
{	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, -3, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickupWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData TankShredder 
{	description = "Knight Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "sniper";
	heading = "bBullet";
	shadowDetailMask = 4;
	imageType = TankShredderImage;
	price = 7500;
	showWeaponBar = true;
};


ItemImageData TankShredder2Image 
{	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { -1.21, 0, 0 };
	mountRotation = { 0, -3, 0};
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder2 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData TankShredder3Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.3051, 0, 0.251 };
	mountRotation = { 0, -3, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder3 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder3Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};
ItemImageData TankShredder4Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = {0.101, 0, 0.251 };
	mountRotation = { 0, -3, 0}; 
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData TankShredder4 
{	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder4Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

$TankShredderSlotA=4;
$TankShredderSlotB=7;
$TankShredderSlotC=6;

function TankShredder::onMount(%player,%imageSlot, %item, $WeaponSlot) 
{	Player::mountItem(%player,TankShredder2,$TankShredderSlotA);
	Player::mountItem(%player,TankShredder3,$TankShredderSlotB);
	Player::mountItem(%player,TankShredder4,$TankShredderSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Knight Chaingun: <f2> Quad chaingun of the Knights. Just run when you see this gun!");
}

function TankShredder::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TankShredderSlotA);
	Player::unmountItem(%player,$TankShredderSlotB);	 
	Player::unmountItem(%player,$TankShredderSlotC);
}

function MDCheckTankShredder(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankShredder")) 
	{	Player::trigger(%player,$TankShredderSlot,true);
		schedule("MDCheckTankShredder(" @ %client @ "," @ %player @ ");",0.05);
		$MDFiringTankShredder[%client] = true;
	}
	else
	{	Player::trigger(%player,$TankShredderSlot,false);
		$MDFiringTankShredder[%client] = false;
	}
}

function TankShredderImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player);
	Player::decItemCount(%player,$WeaponAmmo[TankShredder],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ShredderBullet",%trans,%player,%vel,%player);
	if(!$MDFiringTankShredder[%client]) 
		MDCheckTankShredder(%client, %player);
}

function TankShredder::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TankShredder2, 0);
		Item::onDrop(%player,%item);
	}
}

function MDCheckTankShredder(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankShredder")) 
	{	Player::trigger(%player,$TankShredderSlotA,true);
		Player::trigger(%player,$TankShredderSlotB,true);
		Player::trigger(%player,$TankShredderSlotC,true);
		schedule("MDCheckTankShredder(" @ %client @ "," @ %player @ ");",0.1);
		$MDFiringTankShredder[%client] = true;
	}
	else 
	{	Player::trigger(%player,$TankShredderSlotA,false);
		Player::trigger(%player,$TankShredderSlotB,false);
		Player::trigger(%player,$TankShredderSlotC,false);
		$MDFiringTankShredder[%client] = false;
	}
}

//----------------------------------------------------------------------------
$TankRPGSlotA=4;
$TankRPGSlotB=7;
$TankRPGSlotC=6; 

ItemData TankRPGAmmo 
{	description = "Knight RPG shells"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "xAmmunition";
	shadowDetailMask = 4; 
	price = 12; 
}; 

ItemImageData TankRPGLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.25 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = TankRPGAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData TankRPGLauncher 
{	description = "Knight Quad RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, 0, 0}; 
	hudIcon = "grenade"; 
	heading = "eExplosion";
	shadowDetailMask = 4; 
	imageType = TankRPGLauncherImage; 
	price = 5500; 
	showWeaponBar = true; 
};

ItemImageData TankRPGLauncher2Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher2 
{	description = "Knight RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "grenade"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData TankRPGLauncher3Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher3 
{	description = "Knight RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "grenade"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData TankRPGLauncher4Image 
{	ammoType = TankRPGAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData TankRPGLauncher4 
{	description = "Knight RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "grenade"; 
	shadowDetailMask = 4; 
	imageType = TankRPGLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$TankRPGSlotA=4;
$TankRPGSlotB=7;
$TankRPGSlotC=6;

function TankRPGLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,TankRPGLauncher2,$TankRPGSlotA); 
	Player::mountItem(%player,TankRPGLauncher3,$TankRPGSlotB); 
	Player::mountItem(%player,TankRPGLauncher4,$TankRPGSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Knight Quad RPG: <f2>Fire 4 RPG Missiles at once. This is the ultimate Knight weapon.");
}

function TankRPGLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$TankRPGSlotA);
	Player::unmountItem(%player,$TankRPGSlotB);	 
	Player::unmountItem(%player,$TankRPGSlotC);
}

function TankRPGLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,TankRPGammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("RPG",%trans,%player,%vel,%player); 
	if(!$FiringTankRPGLauncher[%client]) 
		CheckTankRPGLauncher(%client, %player); 
}

function TankRPGLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, TankRPGLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckTankRPGLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TankRPGLauncher")) 
	{	Player::trigger(%player,$TankRPGSlotA,true);
		Player::trigger(%player,$TankRPGSlotB,true);
		Player::trigger(%player,$TankRPGSlotC,true); 
		schedule("CheckTankRPGLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringTankRPGLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$TankRPGSlotA,false); 
		Player::trigger(%player,$TankRPGSlotB,false); 
		Player::trigger(%player,$TankRPGSlotC,false); 
		$FiringTankRPGLauncher[%client] = false; 
	} 
}

//----------------------------------------------------------------------------
ItemData PistolsAmmo
{	description = "Knight Pistol Rounds";
	className = "Ammo";
	shapeFile = "discammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
}; 

ItemData Pistols1Ammo
{	description = "Knight Pistol Rounds";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 20;
	showInventory = false;
};

ItemData Pistols2Ammo
{	description = "Knight Pistol Rounds";
	className = "Ammo";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	price = 20;
	showInventory = false;
}; 

ItemImageData Pistols1Image 
{	shapeFile = "energygun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	ammoType = Pistols1Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	spinUpTime = 0.2;
	projectileType = PistolBullet;
};

ItemData Pistols1
{	description = "Knight Pistols";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "disk";
	heading = "bBullet";
	shadowDetailMask = 4;
	imageType = Pistols1Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData Pistols2Image
{	shapeFile = "energygun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { -1.21, 0, 0 };
	ammoType = Pistols2Ammo;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	spinUpTime = 0.2;
	projectileType = PistolBullet;
};

ItemData Pistols2
{	description = "Knight Pistols";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "disk";
	heading = "bBullet";
	shadowDetailMask = 4;
	imageType = Pistols2Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData PistolsImage
{	shapeFile = "breath";
	mountPoint = 3;
	weaponType = 3;
	ammoType = PistolsAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	spinUpTime = 0.2;
	sfxFire = ShockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Pistols 
{	description = "Knight Pistols";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = "bBullet";
	shadowDetailMask = 4;
	imageType = PistolsImage;
	price = 250;
	showWeaponBar = true;
};

function Pistols::onMount(%player,%imageSlot,%item)
{	
	%num = Player::getItemCount(%player, "PistolsAmmo");
	Player::setItemCount(%player, "Pistols1Ammo", %num);
	Player::mountItem(%player,Pistols1,6);
 	Player::setItemCount(%player, "Pistols2Ammo", %num);
 	Player::mountItem(%player,Pistols2,7);
	%client = Player::getClient(%player);
	Bottomprint(%client, "Knight Pistol: <f2>Dual Pistols with the power of the Knight.");
}

function Pistols::onUnmount(%player,%imageSlot)
{	
	Player::unmountItem(%player,6);
 	Player::unmountItem(%player,7);
}

function PistolsImage::onFire(%player, %slot)
{ 	
	%state1 = Player::getItemState(%player,6);
 	%state2 = Player::getItemState(%player,7);
 	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload")
	{	%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player, "PistolsAmmo", 1);
		%num = Player::getItemCount(%player, "PistolsAmmo");
		if(%client.hd == 0)
		{	%client.hd = 1;
			if(%num == 1)
				Player::setItemCount(%player, "Pistols1Ammo", 0);
			else 
				Player::setItemCount(%player, "Pistols1Ammo", %num);
 			Player::trigger(%player,6,true);
 			Player::trigger(%player,6,false);
	 	}
		else
		{	%client.hd = 0;
 			if(%num == 1)
 				Player::setItemCount(%player, "Pistols2Ammo", 0);
 			else
				Player::setItemCount(%player, "Pistols2Ammo", %num);
 			Player::trigger(%player,7,true);
 			Player::trigger(%player,7,false);
 		}
 	} 
}

//----------------------------------------------------------------------------

ItemImageData ArifleImage
{
   shapeFile  = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.0;
	minEnergy = 10;
	maxEnergy = 20;

	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Arifle
{
   heading = "cEnergy";
	description = "Energy Assault Rifle";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ArifleImage;
	price = 195;
	showWeaponBar = true;
};

function Arifle::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Energy Assault Rifle: <f2>Assault rifle that fires 3 consecutive shots made from energy.");
}

function ArifleImage::onFire(%player, %slot)
{
	%oldenergy = Gamebase::getEnergy(%player);
	%oldenergy -= 30;
	Gamebase::setEnergy(%player, %oldenergy);
	projectile::spawnprojectile("AssaultBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("AssaultBullet1",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("AssaultBullet2",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
}
//----------------------------------------------------------------------------

ItemData BiteAmmo
{
	description = "Lightning charge";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData BiteImage
{
	shapeFile = "fusionbolt";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = BiteAmmo;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Bite
{
	description = "Bite of Lightning";
	className = "Weapon";
	shapeFile = "fusionbolt";
	hudIcon = "plasma";
   heading = "gSpells";
	shadowDetailMask = 4;
	imageType = BiteImage;
	price = 1250;
	showWeaponBar = true;
};

function RechargeBiteAmmo(%player)
{
	if(Player::getItemCount(%player,Bite) > 0 && $FiringBite[%player] == False && $ChargingBite[%player] == True)
	{
		if(Player::getItemCount(%player,BiteAmmo) < 6)
		{
			Player::incItemCount(%player,BiteAmmo,1);

			schedule("RechargeBiteAmmo(" @ %player @ ");", 2);
		}
		else
			$BiteRecharging[%player] = False;
	}
}

function FireBite(%player)
{
	if($FiringBite[%player] == True && $BiteFired[%player] < $BiteToFire[%player])
	{
		if(Player::getItemCount(%player,BiteAmmo) == 2)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("BiteBullet1",%trans,%player,%vel);
		}
		else if(Player::getItemCount(%player,BiteAmmo) == 3)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("BiteBullet2",%trans,%player,%vel);
		}
		else if(Player::getItemCount(%player,BiteAmmo) == 4)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("BiteBullet3",%trans,%player,%vel);
		}
		else if(Player::getItemCount(%player,BiteAmmo) == 5)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("BiteBullet4",%trans,%player,%vel);
		}
		else if(Player::getItemCount(%player,BiteAmmo) == 6)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("BiteBullet5",%trans,%player,%vel);
		}
	}
	
	if($BiteFired[%player] < $BiteToFire[%player])
	{
		$BiteFired[%player]++;
		schedule("FireBite(" @ %player @ ");", 1/$BiteToFire[%player]);
	}
	else
	{
		Player::setItemCount(%player,$WeaponAmmo[Bite],1);
		$FiringBite[%player] = False;
	}
}

function BiteImage::onFire(%player,%slot)
{
	if($ChargingBite[%player] == True)
	{
		$ChargingBite[%player] = False;

		$FiringBite[%player] = True;
		$BiteFired[%player] = 0;

		if(Player::getItemCount(%player, BiteAmmo) == 2)
		{
			$BiteToFire[%player] = 3;
		}
		else if(Player::getItemCount(%player, BiteAmmo) == 3)
		{
			$BiteToFire[%player] = 5;
		}
		else if(Player::getItemCount(%player, BiteAmmo) == 4)
		{
			$BiteToFire[%player] = 6;
		}
		else if(Player::getItemCount(%player, BiteAmmo) == 5)
		{
			$BiteToFire[%player] = 10;
		}
		else if(Player::getItemCount(%player, BiteAmmo) == 6)
		{
			$BiteToFire[%player] = 1;
		}

		FireBite(%player);
	}
	else if($FiringBite[%player] == False)
	{
		$ChargingBite[%player] = True;

		schedule("RechargeBiteAmmo(" @ %player @ ");", 2);
	}
}

function Bite::onMount(%player,%item) 
{	%client = Player::getClient(%player);

	Player::setItemCount(%player,$WeaponAmmo[Bite],1);
	$FiringBite[%player] = False;
	$ChargingBite[%player] = False;

	Bottomprint(%client, "Bite of Lightning: <f2>A spell that can be charged up with magic. Level 1 does nothing, but the higher the level, the more spells are released. Level six releases the summon.");
}

//------------------------------------------------
ItemImageData K1Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.2 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 6.30, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData K1
{
	description = "Knights Shotgun2";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = K1Image;
	showWeaponBar = false;
};

ItemImageData K2Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { 0, 0, -0.2 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3.15, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData K2
{
	description = "Knights Shotgun3";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = K2Image;
	showWeaponBar = false;
};


ItemImageData K3Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { -0.2, 0, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.575, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData K3
{
	description = "Knights Shotgun5";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = K3Image;
	showWeaponBar = false;
};

ItemImageData K4Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { 0.2, 0, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.575, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData K4
{
	description = "Knights Shotgun4";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = K4Image;
	showWeaponBar = false;
};

ItemData KShotgunAmmo
{	description = "Knights Shotgun Shell";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData KShotgunImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = KShotgunAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireFlierRocket; //SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundEnergyTurretTurn;
	sfxReady = SoundMortarIdle;
};

ItemData KShotgun  
{	description = "Knights Shotgun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
  	heading = "eExplosion";
	shadowDetailMask = 4;
	imageType = KShotgunImage; 
	price = 2000;
	showWeaponBar = true;
};

function KShotgun::onMount(%player,%item)
{
	Player::mountItem(%player,K1,7);
	Player::mountItem(%player,K2,6);
	Player::mountItem(%player,K3,5);
	Player::mountItem(%player,K4,4);
}

function KShotgun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function K1::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Knights Shotgun: <f2>The shotgun of a Knight, watch your back.");
}
function KShotgunImage::onFire(%player,%slot) 
{	
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[KShotgun]);
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%weapon = Player::getMountedItem(%client,$WeaponSlot);
	if(%Ammo > 0)
	{	//PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));
		Player::decItemCount(%player,$WeaponAmmo[KShotgun],1);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
            Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
		Projectile::spawnProjectile("KShotgun1Bullet",%trans,%player,%vel);
	}
	else
	{	Client::sendMessage(Player::getClient(%player), 0,"You have no ammo for the Knights Shotgun");
	}
}

//----------------------------------------------------------------------------

ItemImageData SoulImage
{
   shapeFile  = "fusionbolt";
	mountPoint = 0;
	mountOffset = { -0.5, 1, 2 }; 
	mountRotation = { 0, 0, 0 }; 

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.9;
	minEnergy = 9;
	maxEnergy = 10;

	projectileType = SoulShell;
	accuFire = true;

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Soul
{
   heading = "gSpells";
	description = "Evil Soul";
	className = "Weapon";
   shapeFile  = "fusionbolt";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = SoulImage;
	price = 395;
	showWeaponBar = true;
};

function Soul::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Evil Soul: <f2>An evil soul that floats above your character and launches powerful blasts.");
}

//----------------------------------------------------------------------------

ItemImageData BladeImage
{
   shapeFile  = "discb";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.5;
	minEnergy = 9;
	maxEnergy = 20;

	projectileType = BladeShell;
	accuFire = true;

	sfxFire = bigExplosion3;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blade
{
   heading = "gSpells";
	description = "Energy Blade";
	className = "Weapon";
   shapeFile  = "discb";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = BladeImage;
	price = 595;
	showWeaponBar = true;
};

function Blade::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Energy Blade: <f2>An energy blade that if fire very quickly that can be used as a sniper bullet.");
}

//----------------------------------------------------------------------------

$BGunSlotA=4;

ItemImageData BGunImage 
{	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	mountOffset = { 0, 0.03, 0.2 };
	mountRotation = { 0, 0, 0 };
	projectileType = URepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BGun 
{	description = "Worker Repair-Gun";
	className = "Tool";
	shapeFile = "repairgun";
	hudIcon = "targetlaser";
	heading = "mSpecial";
	shadowDetailMask = 4;
	imageType = BGunImage;
	price = 50;
	showWeaponBar = false;
};

ItemImageData BGunImage2 
{	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0.03, 0.1 };
	mountRotation = { 0, -3.15, 0};
	weaponType = 2;
	projectileType = URepairBolt;
	minEnergy = 5;
	maxEnergy = 15;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BGun2
{	description = "Worker Repair-Gun";
	className = "Tool";
	shapeFile = "repairgun";
	hudIcon = "targetlaser";
	heading = "cEnergy";
	shadowDetailMask = 4;
	imageType = BGunImage2;
	showWeaponBar = true;
	showInventory = false;
	Price = 0;
};

//function BgunImage::onFire(%player, %slot) 
//{	%client = GameBase::getOwnerClient(%player);
//	%trans = GameBase::getMuzzleTransform(%player); 
//	%vel = Item::getVelocity(%player); 
//	Player::trigger(%player,$BGunSlotA,true);
//	if(!$FiringBGun[%client]) CheckBgun(%client, %player); 
//} 

function BGun::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, BGun2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function BGun::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,BGun2,$BGunSlotA); 
	%client = Player::getclient(%player);
	bottomprint(%client, "Worker Repair Gun: <f2>Quickly repairs people, objects, and even you!");
} 

function BGun::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$BGunSlotA);
} 

//function CheckBGun(%client, %player) 
//{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "BGun")) 
//	{	Player::trigger(%player,$BGunSlotA,true);
//		schedule("CheckBGun(" @ %client @ "," @ %player @ ");",0.1); 
//		$FiringBGun[%client] = true; 
//	} 
//	else 
//	{	Player::trigger(%player,$BGunSlotA,false); 
//		$FiringBGun[%client] = false; 
//	} 
//}

//function ixCheckBGun(%client, %player)
//{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "BGun"))
//	{	Player::trigger(%player,$BGunSlot,true);
//		Player::trigger(%player,$BGun2SlotA,true);
//		schedule("ixCheckBGun(" @ %client @ "," @ %player @ ");",0.1);
//		$ixFiringBGun[%client] = true;
//		$ixFiringBGun2[%client] = true;
//	}
//	else
//	{	Player::trigger(%player,$BGunSlot,false);
//		$ixFiringBGun[%client] = false;
//		$ixFiringBGun2[%client] = false;
//	}
//}

//----------------------------------------------------------------------------

ItemImageData EShotgunImage
{
   shapeFile  = "enex";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.0;
	minEnergy = 9;
	maxEnergy = 15;

	accuFire = true;

	sfxFire = explosion4;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EShotgun
{
   heading = "gSpells";
	description = "Energy Shotgun";
	className = "Weapon";
   shapeFile  = "enex";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = EShotgunImage;
	price = 395;
	showWeaponBar = true;
};

function EShotgun::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Energy Shotgun: <f2>A shotgun composed of Dark Energy.");
}

function EShotgunImage::onFire(%player, %slot)
{
	%oldenergy = Gamebase::getEnergy(%player);
	%oldenergy -= 30;
	Gamebase::setEnergy(%player, %oldenergy);
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
	projectile::spawnprojectile("EShotgunBullet",GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
}

//----------------------------------------------------------------------------

ItemImageData SwordImage
{
   shapeFile  = "rocket";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.2 }; 
	mountRotation = { -20.42, 0, 0 }; 

	weaponType = 0; // Single Shot
	reloadTime = 0.015;
	fireTime = 0.015;
	minEnergy = 0.5;
	maxEnergy = 1;

	projectileType = SwordBolt;
	accuFire = true;

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Sword
{
   heading = "gSpells";
	description = "Sword of the Fallen Devil";
	className = "Weapon";
   shapeFile  = "rocket";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = SwordImage;
	price = 725;
	showWeaponBar = true;
};

function Sword::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Sword of the Fallen Devil: <f2>Dangerous sword that can slice through anything.");
}

//----------------------------------------------------------------------------

ItemImageData ConRocketlImage
{
   shapeFile  = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 5;
	maxEnergy = 8;

	projectileType = ConRocket;
	accuFire = true;

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundMissileTurretOn;
	sfxReload = SoundMortarReload;
	sfxReady = SoundRepairItem;

};

ItemData ConRocketl
{
   heading = "cEnergy";
	description = "Concussion Rocket Launcher";
	className = "Weapon";
   shapeFile  = "mortargun";
	hudIcon = "mortar";
	shadowDetailMask = 4;
	imageType = ConRocketlImage;
	price = 65;
	showWeaponBar = true;
};

function ConRocketl::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Concussion Rocket Launcher: <f2>Great for moving troops or throwing enemies into disarray.");
}

//----------------------------------------------------------------------------

ItemImageData DarkImage
{
   shapeFile  = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.1;
	fireTime = 1.0;
	minEnergy = 5;
	maxEnergy = 15;

	accuFire = false;

	sfxFire = SoundWindGust;
	sfxActivate = SoundMissileTurretOn;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;

};

ItemData Dark
{
   heading = "mSpecial";
	description = "Darkness";
	className = "Tool";
   shapeFile  = "mortargun";
	hudIcon = "mortar";
	shadowDetailMask = 4;
	imageType = DarkImage;
	price = 15;
	showWeaponBar = true;
};

function Dark::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Darkness: <f2>This weapon has failed to activate. It might just activate for the chosen one.");
}

function DarkImage::onFire(%player,%slot)
{
	if(Client::getName(Player::getclient(%player)) == "}KR{Dark Knight")
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("DarkRocket1",%trans,%player,%vel);
		Projectile::spawnProjectile("DarkRocket2",%trans,%player,%vel);
		Projectile::spawnProjectile("DarkRocket",%trans,%player,%vel);

	}

	else if(Client::getName(Player::getclient(%player)) == "}KR{ShadowKnight")
       {
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("DarkRocket1",%trans,%player,%vel);
		Projectile::spawnProjectile("DarkRocket2",%trans,%player,%vel);
		Projectile::spawnProjectile("DarkRocket",%trans,%player,%vel);

       }
}

//----------------------------------------------------------------------------

ItemImageData BrimstoneImage
{
	shapeFile = "mortar";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	weaponType = 0; // Single Shot
	//projectileType = ReincarnationBolt;
	accuFire = true;
	reloadTime = 5.0;
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;


	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 3;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Brimstone
{
	description = "ravenscheater1";
	className = "Tool";
	shapeFile = "mortar";
      heading = "mSpecial";
	shadowDetailMask = 4;
	imageType = BrimstoneImage;
};

function Brimstone::onUse(%player, %item)
{
		Weapon::onUse(%player, %item);
		bottomprint(Player::getClient(%player), "<jc><f2>Wrath of }KR{ - The ultimate weapon for }KR{.", 4);
}

function BrimstoneImage::onFire(%player, %slot)
{
	if(Client::getName(Player::getclient(%player)) == "}KR{Dark Knight")
      {
%count = 0;
if(GameBase::getLOSInfo(%player,300))
	 {
	%pos = $los::position;
	playsound(bigExplosion1,%pos);
	playsound(bigExplosion1,GameBase::getPosition(%player));
	%Xpos = getword(%pos, 0);
	%Ypos = getword(%pos, 1);
	%Zpos = getword(%pos, 2);
	%Zpos += 50;
Brimstone::Bombs(%player,%count, %Xpos, %Ypos, %Zpos);
	 }
	else
Client::SendMessage(Player::getClient(%player),0,"Out of range for the Wrath of }KR{.");
	}
}

function Brimstone::Bombs(%player, %count, %Xpos, %Ypos, %Zpos)
{
if(%count < 100)
{

%count++;
	for(%cnt = 0;%cnt < 2;%cnt++)
	{
	%posneg = floor(getRandom() * (2 - 0.01));
		if(%posneg == 0)
		{
		%coord = floor(getRandom() * (100 - 0.01));
		if(%cnt == 0)
		%newXpos = %Xpos + %coord;
		else
		%newYpos = %Ypos + %coord;
		//messageall(0,"Positive Num");
		}
		else
		{
		%coord = floor(getRandom() * (100 - 0.01));
		if(%cnt == 0)
		%newXpos = %Xpos - %coord;
		else
		%newYpos = %Ypos - %coord;
		//messageall(0,"Negative Num");
		}
	}
	%newPos = %newXpos@" "@%newYpos@" "@%Zpos;
	%obj = newObject("","Mine","BrimstoneGren");
	GameBase::setPosition(%obj, %newPos);
	Player::setItemCount(%player, Brimstone, 1);
	schedule("Brimstone::Bombs("@%player@","@%count@","@%Xpos@","@%Ypos@","@%Zpos@");",0.1);
}
}

//----------------------------------------------------------------------------

ItemImageData WeakImage
{
	shapeFile = "grenade";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	weaponType = 0; // Single Shot
	//projectileType = ReincarnationBolt;
	accuFire = true;
	reloadTime = 8.0;
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;


	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 3;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Weak
{
	description = "Sewage hole";
	className = "Tool";
	shapeFile = "grenade";
      heading = "mSpecial";
	shadowDetailMask = 4;
	imageType = WeakImage;
};

function Weak::onUse(%player, %item)
{
		Weapon::onUse(%player, %item);
		bottomprint(Player::getClient(%player), "<jc><f2>Wrath of }KR{ (Shadow's Version) - The ultimate weapon for }KR{ (With ShadowKnight's touch).", 4);
}

function WeakImage::onFire(%player, %slot)
{
	if(Client::getName(Player::getclient(%player)) == "}KR{ShadowKnight")
      {
%count = 0;
if(GameBase::getLOSInfo(%player,300))
	 {
	%pos = $los::position;
	playsound(bigExplosion1,%pos);
	playsound(bigExplosion1,GameBase::getPosition(%player));
	%Xpos = getword(%pos, 0);
	%Ypos = getword(%pos, 1);
	%Zpos = getword(%pos, 2);
	%Zpos += 50;
Weak::Bombs(%player,%count, %Xpos, %Ypos, %Zpos);
	 }
	else
Client::SendMessage(Player::getClient(%player),0,"Out of range for the Wrath of }KR{ (Shadow's Version).");
	}
}

function Weak::Bombs(%player, %count, %Xpos, %Ypos, %Zpos)
{
if(%count < 50)
{

%count++;
	for(%cnt = 0;%cnt < 2;%cnt++)
	{
	%posneg = floor(getRandom() * (2 - 0.01));
		if(%posneg == 0)
		{
		%coord = floor(getRandom() * (100 - 0.01));
		if(%cnt == 0)
		%newXpos = %Xpos + %coord;
		else
		%newYpos = %Ypos + %coord;
		//messageall(0,"Positive Num");
		}
		else
		{
		%coord = floor(getRandom() * (100 - 0.01));
		if(%cnt == 0)
		%newXpos = %Xpos - %coord;
		else
		%newYpos = %Ypos - %coord;
		//messageall(0,"Negative Num");
		}
	}
	%newPos = %newXpos@" "@%newYpos@" "@%Zpos;
	%obj = newObject("","Mine","WeakGren");
	GameBase::setPosition(%obj, %newPos);
	Player::setItemCount(%player, Brimstone, 1);
	schedule("Weak::Bombs("@%player@","@%count@","@%Xpos@","@%Ypos@","@%Zpos@");",0.1);
}
}

//----------------------------------------------------------------------------

ItemImageData DropMineImage
{
	shapeFile = "mine";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	weaponType = 0; // Single Shot
	//projectileType = ReincarnationBolt;
	accuFire = true;
	reloadTime = 5.0;
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;


	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 3;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData DropMine
{
	description = "Ravenscheater";
	className = "Tool";
	shapeFile = "mine";
      heading = "mSpecial";
	shadowDetailMask = 4;
	imageType = DropMineImage;
};

function DropMine::onUse(%player, %item)
{
		Weapon::onUse(%player, %item);
		bottomprint(Player::getClient(%player), "<jc><f1>Hell of }KR{ - Drops mines all over the field.", 4);
}

function DropMineImage::onFire(%player, %slot)
{
	if(Client::getName(Player::getclient(%player)) == "}KR{Dark Knight")
      {
%count = 0;
if(GameBase::getLOSInfo(%player,300))
	 {
	%pos = $los::position;
	playsound(bigExplosion1,%pos);
	playsound(bigExplosion1,GameBase::getPosition(%player));
	%Xpos = getword(%pos, 0);
	%Ypos = getword(%pos, 1);
	%Zpos = getword(%pos, 2);
	%Zpos += 50;
DropMine::Bombs(%player,%count, %Xpos, %Ypos, %Zpos);
	 }
	else
Client::SendMessage(Player::getClient(%player),0,"Out of range for the Hell of }KR{.");
	}
}

function DropMine::Bombs(%player, %count, %Xpos, %Ypos, %Zpos)
{
if(%count < 100)
{

%count++;
	for(%cnt = 0;%cnt < 2;%cnt++)
	{
	%posneg = floor(getRandom() * (2 - 0.01));
		if(%posneg == 0)
		{
		%coord = floor(getRandom() * (100 - 0.01));
		if(%cnt == 0)
		%newXpos = %Xpos + %coord;
		else
		%newYpos = %Ypos + %coord;
		//messageall(0,"Positive Num");
		}
		else
		{
		%coord = floor(getRandom() * (100 - 0.01));
		if(%cnt == 0)
		%newXpos = %Xpos - %coord;
		else
		%newYpos = %Ypos - %coord;
		//messageall(0,"Negative Num");
		}
	}
	%newPos = %newXpos@" "@%newYpos@" "@%Zpos;
	%obj = newObject("","Mine","DropMines");
	GameBase::setPosition(%obj, %newPos);
	Player::setItemCount(%player, DropMine, 1);
	schedule("DropMine::Bombs("@%player@","@%count@","@%Xpos@","@%Ypos@","@%Zpos@");",0.1);
}
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
   heading = "bBullet";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

function Chaingun::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Chaingun: <f2>Great for gunning down light armors, accuracy is greatly reduced at long ranges.");
}

//----------------------------------------------------------------------------

ItemData Dinky1Ammo
{
	description = "Dinky 1 Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData Dinky1Image
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = Dinky1Ammo;
	projectileType = DinkyBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundEnergyTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundEnergyTurretOn;
	sfxSpinDown = SoundEnergyTurretOff;
};

ItemData Dinky1
{
	description = "Dinky 1";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "bBullet";
	shadowDetailMask = 4;
	imageType = Dinky1Image;
	price = 145;
	showWeaponBar = true;
};

function Dinky1::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Dinky 1: <f2>A dinky little gun. Looks can be deceiving.");
}

//----------------------------------------------------------------------------

ItemData AlienGatAmmo
{
	description = "Energy Bolt";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 13;
};

ItemImageData AlienGatImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 5;
	fireTime = 0.1;

	ammoType = AlienGatAmmo;
	projectileType = AlienBolt;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 30, 0 };

	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPlasmaTurretTurn;
	sfxSpinUp = SoundPlasmaTurretOn;
	sfxSpinDown = SoundPlasmaTurretOff;
};

ItemData AlienGat
{
	description = "Clytranium Gatling Gun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "hAlien";
	shadowDetailMask = 4;
	imageType = AlienGatImage;
	price = 175;
	showWeaponBar = true;
};

function AlienGat::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Clytranium Gatling Gun: <f2>The Clytraniums decided to make a gatling gun so they could keep up with their enemies' technological advancements. Use this gun to spray energy balls toward your enemy.");
}

//----------------------------------------------------------------------------

ItemData FlameThrowerAmmo
{
	description = "Flame Cartridge";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 15;
};

ItemImageData FlameThrowerImage
{
   shapeFile  = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	ammoType = FlameThrowerAmmo;
	projectileType = Flame;
	accuFire = true;

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlameThrower
{
   heading = "fFlame";
	description = "Flame Thrower";
	className = "Weapon";
   shapeFile  = "grenadeL";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = FlameThrowerImage;
	price = 105;
	showWeaponBar = true;
};

function FlameThrower::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Flame Thrower: <f2> Light those enemies on fire with this fun weapon.");
}

//----------------------------------------------------------------------------

ItemData AntiAmmo
{
	description = "Anti-Aircraft Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData AntiImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.8;
	spinDownTime = 3;
	fireTime = 0.01;

	ammoType = AntiAmmo;
	projectileType = AntiBullet;
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

ItemData Anti
{
	description = "Anti-Aircraft Machinegun";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = "bBullet";
	shadowDetailMask = 4;
	imageType = AntiImage;
	price = 925;
	showWeaponBar = true;
};

function Anti::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Anti-Aircraft Machinegun: <f2>This weapon was used to knock out airplanes in the second World War. Gun down enemies with it or just mow down a bunch of slow heavies!");
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

ItemData Plasmagun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "fFlame";
	shadowDetailMask = 4;
	imageType = PlasmagunImage;
	price = 175;
	showWeaponBar = true;
   validateShape = true;
};

function Plasmagun::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Plasma Gun: <f2>Fires flaming balls of energy to set your enemies aflame.");
}

//----------------------------------------------------------------------------

ItemData BARAmmo
{
	description = "BAR Bullet";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData BARImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = BARAmmo;
	projectileType = BARBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BAR
{
	description = "BAR";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "bBullet";
	shadowDetailMask = 4;
	imageType = BARImage;
	price = 223;
	showWeaponBar = true;
   validateShape = true;
};

function BAR::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "BAR: <f2>(Browning Automatic Rifle)A heavier gun mainly used to lay down cover fire.");
}

//----------------------------------------------------------------------------

ItemData SniperAmmo
{
	description = "Sniper Round";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SniperImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SniperAmmo;
	projectileType = SniperBullet;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.8;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData Sniper
{
	description = "Silent Sniper";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
   heading = "dSniper";
	shadowDetailMask = 4;
	imageType = SniperImage;
	price = 575;
	showWeaponBar = true;
   validateShape = true;
};

function Sniper::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Silent Sniper: <f2> A quiet sniper rifle. Your enemy will only hear the ping when the bullet hits, and will see no shot.");
}

//----------------------------------------------------------------------------

ItemData DartAmmo
{
	description = "Poison Darts";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData DartImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = DartAmmo;
	projectileType = PoisonDart;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 7;
	lightTime = 3;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData Dart
{
	description = "Poison Dart Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "dSniper";
	shadowDetailMask = 4;
	imageType = DartImage;
	price = 373;
	showWeaponBar = true;
   validateShape = true;
};

function Dart::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Poison Dart Rifle: <f2>Dart rifle that fires poisonous darts to stop the enemy in their tracks.");
}

//----------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Canister";
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
   heading = "eExplosion";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   validateShape = true;
};

function GrenadeLauncher::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Grenade Launcher: <f2>Fires out a long range grenade that will blow up your enemy.");
}

//----------------------------------------------------------------------------

ItemData ScoutMAmmo
{
	description = "Scout Mortars";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ScoutMImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ScoutMAmmo;
	projectileType = Scout;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundFireGrenade;
};

ItemData ScoutM
{
	description = "Scout Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "eExplosion";
	shadowDetailMask = 4;
	imageType = ScoutMImage;
	price = 169;
	showWeaponBar = true;
   validateShape = true;
};

function ScoutM::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Scout Mortar: <f2> A mortar launcher just for the scout armor, it lobs tons of those little time bombs that we all love.");
}

//----------------------------------------------------------------------------

ItemData MortarRAmmo
{
	description = "Mortar Round";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MortarRImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarRAmmo;
	projectileType = MRocket;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundELFIdle;
};

ItemData MortarR
{
	description = "Mortar Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
   heading = "eExplosion";
	shadowDetailMask = 4;
	imageType = MortarRImage;
	price = 735;
	showWeaponBar = true;
   validateShape = true;
};

function MortarR::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Mortar Rocket Launcher: <f2>A deadly straight shot mortar.");
}

//----------------------------------------------------------------------------

ItemData RocketLAmmo
{
	description = "Rocket";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData RocketLImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RocketLAmmo;
	projectileType = FlierRocket;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundELFIdle;
};

ItemData RocketL
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
   heading = "eExplosion";
	shadowDetailMask = 4;
	imageType = RocketLImage;
	price = 240;
	showWeaponBar = true;
   validateShape = true;
};

function RocketL::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Rocket Launcher: <f2>Fires a deadly rocket toward your enemy.");
}

//----------------------------------------------------------------------------

ItemData GasAmmo
{
	description = "Gas Bomb";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 15;
};

ItemImageData GasImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GasAmmo;
	projectileType = GasShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Gas
{
	description = "Gas Bomb Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "eExplosion";
	shadowDetailMask = 4;
	imageType = GasImage;
	price = 475;
	showWeaponBar = true;
   validateShape = true;
};

function Gas::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Gas Bomb Launcher: <f2>Fires wads of gas to poison your opponent.");
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
   heading = "eExplosion";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
   validateShape = true;
};

function Mortar::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Mortar: <f2>When this gun is fired, you had better run. Very powerful bomb that is mainly used to blow up base doors.");
}

//----------------------------------------------------------------------------

ItemData Dinky2Ammo
{
	description = "Dinky 2 Bomb";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData Dinky2Image
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Dinky2Ammo;
	projectileType = DinkyShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Dinky2
{
	description = "Dinky 2";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eExplosion";
	shadowDetailMask = 4;
	imageType = Dinky2Image;
	price = 675;
	showWeaponBar = true;
   validateShape = true;
};

function Dinky2::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Dinky 2: <f2>The second gun in the 'dinky' series. Very powerful bomb that can easily blow holes in walls.");
}

//----------------------------------------------------------------------------
ItemImageData S1Image
{
	shapeFile = "grenadeL";
	mountPoint = 0; 
	mountOffset = { 0, 0.4, 0.4 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -0.1, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData S1
{
	description = "Missile Launcher2";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = S1Image;
	showWeaponBar = false;
};


ItemData StingerAmmo
{	description = "Stinger Missiles";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData StingerImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0.4 }; 
	mountRotation = { 0, 0.8, 0 };  
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.5;
	ammoType = StingerAmmo;
	accuFire = true;

	sfxFire	= SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Stinger
{	heading = "eExplosion";
	description = "Missile Launcher";
	classname = "Weapon";
	shapeFile = "mortargun";
	hudIcon	= "mortar";
	shadowDetailMask = 4;
	imageType = StingerImage;
	price = 350;
	showWeaponBar = true;
};

function Stinger::onMount(%player,%item)
{
	Player::mountItem(%player,S1,7);
}

function Stinger::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function S1::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Missile Launcher: <f2>Locking missile launcher used to send your enemies to hell.");
}

function StingerImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Stinger]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1500))
		{
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Client::sendMessage(%client,3,"Lock Aquired - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"**WARNING** lock detected - " @ %clientId @ "~waccess_denied.wav");
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
			}
			else
			{
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,%player);
				Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
			}
		}
		else
		{
			Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
			Player::decItemCount(%player,$WeaponAmmo[Stinger],1);
		}
	}
	else 
		Client::sendMessage(Player::getClient(%player),0,"Missile Launcher out of ammo.~waccess_denied.wav");
}

//----------------------------------------------------------------------------
ItemImageData KR1Image
{
	shapeFile = "grenadeL";
	mountPoint = 0; 
	mountOffset = { 0, 0.4, 0.4 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData KR1
{
	description = "KRCannon2";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = KR1Image;
	showWeaponBar = false;
};

ItemImageData KR2Image
{
	shapeFile = "radar_small";
	mountPoint = 0; 
	mountOffset = { -1.21, -0.4, 0.4 }; //-  left-right, back-front, up-down
	mountRotation = { -90, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData KR2
{
	description = "KRCannon2";
	className = "Weapon";
	shapeFile = "radar_small";
	shadowDetailMask = 4;
	imageType = KR2Image;
	showWeaponBar = false;
};

ItemImageData KR4Image
{
	shapeFile = "grenadeL";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0.4 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData KR4
{
	description = "KRCannon2";
	className = "Weapon";
	shapeFile = "chaingun";
	shadowDetailMask = 4;
	imageType = KR4Image;
	showWeaponBar = false;
};

ItemData KRAmmo
{	description = "}KR{ Linear Charges";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData KRGunImage
{	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0, -0.2, 0.4 }; 
	mountRotation = { 0, 0, 0 };  
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.5;
	projectileType = LinearRocket;
	ammoType = KRAmmo;
	accuFire = true;

	sfxFire	= SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundActivateInventoryStation;
	sfxReady = SoundMortarIdle;
};

ItemData KRGun
{	heading = "eExplosion";
	description = "}KR{ Linear Cannon";
	classname = "Weapon";
	shapeFile = "grenadeL";
	hudIcon	= "mortar";
	shadowDetailMask = 4;
	imageType = KRGunImage;
	price = 350;
	showWeaponBar = true;
};

function KRGun::onMount(%player,%item)
{
	Player::mountItem(%player,KR1,7);
      Player::mountItem(%player,KR4,6);
      Player::mountItem(%player,KR2,5);
}

function KRGun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function KR1::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "}KR{ Linear Cannon: <f2>Developed by the }KR{ Clan, a deadly cannon thats full potential is unknown.");
}

//----------------------------------------------------------------------------
ItemImageData E1Image
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountOffset = { 0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 90.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData E1
{
	description = "EMP Missile Launcher2";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = E1Image;
	showWeaponBar = false;
};

ItemImageData E2Image
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountOffset = { -0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -90.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData E2
{
	description = "EMP Missile Launcher3";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = E2Image;
	showWeaponBar = false;
};

ItemData EMPAmmo
{	description = "EMP Missiles";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 40;
};

ItemImageData EMPImage
{	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0 }; 
	mountRotation = { 0, 0, 0 };  
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.5;
	ammoType = EMPAmmo;
	accuFire = true;

	sfxFire	= SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData EMP
{	heading = "eExplosion";
	description = "EMP Missile Launcher";
	classname = "Weapon";
	shapeFile = "grenadeL";
	hudIcon	= "mortar";
	shadowDetailMask = 4;
	imageType = EMPImage;
	price = 350;
	showWeaponBar = true;
};

function EMP::onMount(%player,%item)
{
	Player::mountItem(%player,E1,6);
      Player::mountItem(%player,E2,7);
}

function EMP::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
}



function E1::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "EMP Missile Launcher: <f2>Locking, Jams energy, the gun I have always wanted for my birthday! ;)");
}

function EMPImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[EMP]);
	if(%AmmoCount)
	{	
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1500))
		{
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Client::sendMessage(%client,3,"Lock Aquired - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"**WARNING** EMP lock detected - " @ %clientId @ "~waccess_denied.wav");
				Projectile::spawnProjectile("EMPMissile",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[EMP],1);
			}
			else
			{
				Projectile::spawnProjectile("EMPRocket",%trans,%player,%vel,%player);
				Player::decItemCount(%player,$WeaponAmmo[EMP],1);
			}
		}
		else
		{
			Projectile::spawnProjectile("EMPRocket",%trans,%player,%vel,$los::object);
			Player::decItemCount(%player,$WeaponAmmo[EMP],1);
		}
	}
	else 
		Client::sendMessage(Player::getClient(%player),0,"EMP Missile Launcher out of ammo.~waccess_denied.wav");
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
	fireTime = 1.0;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Particle Blade Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "hAlien";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function DiscLauncher::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Particle Blade Launcher: <f2>Another Clytranium weapon. This is carried by most ranks and fires spinning blades toward enemies.");
}

//----------------------------------------------------------------------------

ItemImageData ChronoLaserImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = ChronLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 15.0;
	minEnergy = 70;
	maxEnergy = 80;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundLaserHit;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ChronoLaser
{
	description = "Chronosceptor";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "dSniper";
	shadowDetailMask = 4;
	imageType = ChronoLaserImage;
	price = 2500;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function ChronoLaser::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Chronosceptor: <f2>The apparatus of ultimate distruction. The Chronosceptor is capable of creating micro-tears in the fabric of space time, thus disrupting matter at a focus point.");
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
   heading = "dSniper";
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
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Laser Rifle: <f2>Heated atoms are concentrated into and accurate beam.");
}

//----------------------------------------------------------------------------
ItemImageData F1Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, 0.1 };
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData F1
{
	description = "Flaming Laser";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = F1Image;
	showWeaponBar = false;
};

ItemImageData F2Image
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, 0.1 };
	mountRotation = { 0, -3.15, 0}; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData F2
{
	description = "Flaming Laser";
	className = "Weapon";
	shapeFile = "repairgun";
	shadowDetailMask = 4;
	imageType = F2Image;
	showWeaponBar = false;
};

ItemImageData FlameLImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = FlameLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	minEnergy = 10;
	maxEnergy = 20;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlameL
{
	description = "Flaming Laser";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
   heading = "fFlame";
	shadowDetailMask = 4;
	imageType = FlameLImage;
	price = 400;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};


function FlameL::onMount(%player,%item)
{
	Player::mountItem(%player,F1,6);
      Player::mountItem(%player,F2,7);
}

function FlameL::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
}

function F1::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Flaming Laser: <f2>A burning laser that is so hot that only a Defender can keep from getting burned.");
}

//----------------------------------------------------------------------------

ItemImageData AlienLImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = ALaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 1.0;
	minEnergy = 10;
	maxEnergy = 40;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AlienL
{
	description = "Clytranium Laser Rifle";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "sniper";
   heading = "hAlien";
	shadowDetailMask = 4;
	imageType = AlienLImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function AlienL::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Clytranium Laser Rifle: <f2>Clytranium sniper weapon.");
}

//----------------------------------------------------------------------------
ItemImageData Sc1Image
{
	shapeFile = "mine";
	mountPoint = 0; 
      mountOffset = { 0, 0.3, 0 }; 
	mountRotation = { -80, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Sc1
{
	description = "Scout Laser2";
	className = "Weapon";
	shapeFile = "mine";
	shadowDetailMask = 4;
	imageType = Sc1Image;
	showWeaponBar = false;
};

ItemImageData ScoutLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = ScLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 3.0;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundMortarTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ScoutLaser
{
	description = "Scout Laser";
	className = "Weapon";
	shapeFile = "mine";
	hudIcon = "sniper";
   heading = "dSniper";
	shadowDetailMask = 4;
	imageType = ScoutLaserImage;
	price = 100;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function ScoutLaser::onMount(%player,%item)
{
	Player::mountItem(%player,Sc1,6);
}

function ScoutLaser::onUnMount(%player,%item)
{
	Player::unmountItem(%player,6);
}

function Sc1::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Scout Laser: <f2>A laser made just for the scout armor.");
}

//----------------------------------------------------------------------------
ItemImageData KL1Image
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountOffset = { 0, 0.03, 0.5 };
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData KL1
{
	description = "Knight Laser";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = KL1Image;
	showWeaponBar = false;
};

ItemImageData KL2Image
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountOffset = { 0, 0.03, 0.5 };
	mountRotation = { 0, -3.15, 0}; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData KL2
{
	description = "Knight Laser";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = KL2Image;
	showWeaponBar = false;
};

ItemImageData KnightLaserImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.5 }; 
	mountRotation = { 0, 0.7, 0 }; 

	weaponType = 0; // Single Shot
	projectileType = KLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 5.0;
	minEnergy = 10;
	maxEnergy = 90;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = ShockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData KnightLaser
{
	description = "Knight Laser";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "sniper";
   heading = "dSniper";
	shadowDetailMask = 4;
	imageType = KnightLaserImage;
	price = 1700;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function KnightLaser::onMount(%player,%item)
{
	Player::mountItem(%player,KL1,6);
      Player::mountItem(%player,KL2,7);
}

function KnightLaser::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,6);
}

function KL1::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Knight Laser: <f2>A laser so strong that only the strength of a Knight could handle it.");
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
      heading = "mSpecial";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

function TargetingLaser::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Targeting Laser: <f2>This is for all you idiots that don't know what to do with this gun. Shoot it at a turret when a heavy armor is near. It puts up long lines which help the heavy with a mortar to aim. SO USE IT YOU FOOLS.");
}

//------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "sniper";
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
   description = "Worker Power Beam";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
   className = "Tool";
   heading = "mSpecial";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

function EnergyRifle::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Power Beam: <f2>A beam made to gives max energy to any turret or person it touches.");
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
   heading = "oDeployables";
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
   heading = "oDeployables";
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
   heading = "nBackpacks";
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
   heading = "nBackpacks";
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
ItemImageData MistPackImage
{
	shapeFile = "smoke";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData MistPack
{
	description = "Shadow Pack";
	className = "Backpack";
	shapeFile = "smoke";
	hudIcon = "shieldpack";
	heading = "nBackpacks";
	shadowDetailMask = 4;
	imageType = MistPackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function MistPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%vel = Item::getVelocity(%client);

	if(Player::getMountedItem(%client, $FlagSlot) == "flag")
	{
		Player::dropItem(%client, Player::getMountedItem(%client, $FlagSlot));
		Client::sendMessage(%client, 1, "You lost flag while becoming one with the shadows!");
	}

	%item = MistVehicle;

	%markerPos = GameBase::getPosition(%client);
	%set = newObject("",Flier, Mist, true);
	%damage = GameBase::getDamageLevel(%player);


	%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;

	%vehicle = newObject("",flier,$DataBlockName[%item],true);
	Gamebase::setMapName(%vehicle,%item.description);
      %vehicle.clLastMount = %client;
	addToSet("MissionCleanup", %vehicle);
  	%vehicle.fading = 1;
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::setPosition(%vehicle,%markerPos);
	GameBase::setRotation(%vehicle,GameBase::getRotation(%client));
	deleteObject(%set);
	$TeamItemCount[Client::getTeam(%client) @ %item]++;

	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(%weapon != -1)
	{
		%player.lastWeapon = %weapon;
		Player::unMountItem(%player,$WeaponSlot);
	}

	Player::setMountObject(%player, %vehicle, 1);
	Client::setControlObject(%client, %vehicle);
	%player.driver = 1;
	%player.vehicle = %vehicle;
	%vehicle.clLastMount = %client;
	GameBase::setDamageLevel(%vehicle, %damage);

	Item::setVelocity(%client, %vel);
}

function MistPackImage::onDeactivate(%player, %imageSlot)
{
// doesnt do much, they just dismount.
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
   heading = "nBackpacks";
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
   heading = "nBackpacks";
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
	Client::sendMessage(Player::getClient(%player),0,"Jamming On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jamming Off");
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
   heading = "oDeployables";
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
   heading = "nBackpacks";
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
			else if(%i == 6) {
	 	    	%item.SniperAmmo = %numPack;
			}
			else if(%i == 7) {
	 	    	%item.DartAmmo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.BARAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.AntiAmmo = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.AlienGatAmmo = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.Dinky1Ammo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.Dinky2Ammo = %numPack;
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
		else if(%i == 6) {
 	    	%numAdd = %item.SniperAmmo;
		}
		else if(%i == 7) {
 	    	%numAdd = %item.DartAmmo;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.BARAmmo;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.AntiAmmo;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.AlienGatAmmo;
		}
		else if(%i == 11) {
 	    	%numAdd = %item.Dinky1Ammo;
		}
		else if(%i == 12) {
 	    	%numAdd = %item.Dinky2Ammo;
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
   heading = "oDeployables";
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

function RemoveBeam(%b)
{
	//echo("Deleting beam " @ %b);
	deleteObject(%b);
}				

function DeployableTeleport::Destruct(%this)
{
    CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
}
														 
function DeployableTeleport::onDestroyed(%this)
{
      schedule("RemoveBeam("@%this.beam1@");",1);
      schedule("RemoveBeam("@%this.beam2@");",1);
      schedule("RemoveBeam("@%this.beam3@");",1);
      schedule("RemoveBeam("@%this.beam4@");",1);

    CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);

    $TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
        if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
        {
//        echo("Applying damage to mate");
        GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		return;
        }
    }
}

function DeployableTeleport::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
	{
        return;
	}

    if(Player::isDead(%obj))
	{
        return;
	}

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	
    if(%teleTeam != %playerTeam)
	{
        Client::SendMessage(%c,0,"Wrong team");
        return;
	}

    if(%this.disabled == true)
	{
        Client::SendMessage(%c,0,"Teleport Pad is recharging");

        return;
	}

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
	  if(GameBase::getTeam(%o) == %playerteam && %o != %this)
        {
		if(Player::getArmor(%obj) == "harmor")
		{
            Client::SendMessage(%c,0,"Cannot teleport in heavy armor");
			return;
		}
		else
		{
			GameBase::playSound(%o,ForceFieldOpen,0);
			GameBase::playSound(%this,ForceFieldOpen,0);
            	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
	            %o.Disabled = true;
      	      %this.Disabled = true;
			GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			if(floor(getRandom() * 25) == 0)
			{
                Client::SendMessage(%c,0,"Teleport malfunctions and self destructs.");
		        GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			}
			else
			{
		            schedule("DeployableTeleport::Reenable("@%o@");",5);
      		      schedule("DeployableTeleport::Reenable("@%this@");",5);
			}
			return;
		}
        }
    }
    Client::SendMessage(%c,0,"No other pad to teleport to");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}


ItemImageData TeleportPackImage
{
	shapeFile = "mortar";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TeleportPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
    heading = "oDeployables";
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleportPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TeleportPack::onDeploy(%player,%item,%pos)
{
	if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++;
	}
}

function CreateteleportSimSet()
{
    %teleset = nameToID("MissionCleanup/Teleports");
	if(%teleset == -1)
	{
		newObject("Teleports",SimSet);
		addToSet("MissionCleanup","Teleports");
	}
}

function TeleportPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("Teleport Pad","StaticShape",%shape,true);
						CreateteleportSimSet();
                        addToSet("MissionCleanup/Teleports", %sensor);
				addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						%pos = Vector::add($los::position,"0 0 1");
						echo("LOS pos " @ $los::position @ " " @ %pos);
						GameBase::setPosition(%sensor,%pos);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						%sensor.disabled = false;
						playSound(SoundPickupBackpack,$los::position);

						%beam = newObject("","StaticShape",ElectricalBeamBig,true);
                        		addToSet("MissionCleanup", %beam);
						GameBase::setTeam(%beam,GameBase::getTeam(%player));
						GameBase::setPosition(%beam,%pos);
						%sensor.beam1 = %beam;

						%beam = newObject("","StaticShape",ElectricalBeamBig,true);
                        		addToSet("MissionCleanup", %beam);
						GameBase::setTeam(%beam,GameBase::getTeam(%player));
						%pos = Vector::add(%pos,"0 0 5");
						GameBase::setPosition(%beam,%pos);
						%sensor.beam2 = %beam;

						%beam = newObject("","StaticShape",ElectricalBeamBig,true);
                        		addToSet("MissionCleanup", %beam);
						GameBase::setTeam(%beam,GameBase::getTeam(%player));
						%pos = Vector::add(%pos,"0 0 5");
						GameBase::setPosition(%beam,%pos);
						%sensor.beam3 = %beam;

						%beam = newObject("","StaticShape",ElectricalBeamBig,true);
                        		addToSet("MissionCleanup", %beam);
						GameBase::setTeam(%beam,GameBase::getTeam(%player));
						%pos = Vector::add(%pos,"0 0 5");
						GameBase::setPosition(%beam,%pos);
						%sensor.beam4 = %beam;

//				            schedule("DeployableTeleport::Destruct("@%sensor@");",600);
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
   heading = "oDeployables";
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
   heading = "pTurret";
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
	description = "Laser Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "pTurret";
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
					%camera = newObject("Camera","Turret",DeployableTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "TurretPack"]++;
					echo("MSG: ",%client," deployed a laser turret");
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
																			
ItemImageData TargetPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TargetPack
{
	description = "Striker Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "pTurret";
	imageType = TargetPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TargetPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TargetPack::onDeploy(%player,%item,%pos)
{
	if (TargetPack::deployShape(%player,%item)) {
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

function TargetPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",TargetTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Striker Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Striker Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "TargetPack"]++;
					echo("MSG: ",%client," deployed a striker turret");
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
																			
ItemImageData DefenderPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DefenderPack
{
	description = "Defender Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "pTurret";
	imageType = DefenderPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 850;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DefenderPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DefenderPack::onDeploy(%player,%item,%pos)
{
	if (DefenderPack::deployShape(%player,%item)) {
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

function DefenderPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",DefenderTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Defender Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Defender Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "DefenderPack"]++;
					echo("MSG: ",%client," deployed a defender turret");
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
																			
ItemImageData SlashPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SlashPack
{
	description = "Slash Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "pTurret";
	imageType = SlashPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 745;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SlashPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SlashPack::onDeploy(%player,%item,%pos)
{
	if (SlashPack::deployShape(%player,%item)) {
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

function SlashPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",SlashTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Slash Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Slash Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "SlashPack"]++;
					echo("MSG: ",%client," deployed a slash turret");
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
																			
ItemImageData NukePackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData NukePack
{
	description = "Nuke Turret";
	shapeFile = "chainturret";
	className = "Backpack";
   heading = "pTurret";
	imageType = NukePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NukePack::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Nuke turret must be controlled manually to fire.");
}

function NukePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function NukePack::onDeploy(%player,%item,%pos)
{
	if (NukePack::deployShape(%player,%item)) {
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

function NukePack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",NukeTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Nuke Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Nuke Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "NukePack"]++;
					echo("MSG: ",%client," deployed a nuke turret");
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

//----------------------------------------------

ItemImageData FFieldPackImage 
{ 
	shapeFile = "mortar"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 };
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData FFieldPack 
{ 
	description = "Small Force Field"; 
	shapeFile = "forcefield_5x5"; 
	className = "Backpack"; 
	heading = "qDefense"; 
	imageType = FFieldPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 100; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FFieldPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FFieldPack::onDeploy(%player,%item,%pos) 
{ 
	if (FFieldPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FFieldPack::deployShape(%player,%item) 
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

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else {
			%rot =  "0 1.578 " @ getWord(Vector::getRotation($los::normal),2) + 1.578;
		}
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%shape = newObject("","StaticShape",FField,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Force Field deployed");
	playSound(SoundPickupBackpack,$los::position);
	GameBase::startFadeIn(%shape);
	schedule("playSound(ForceFieldOpen,"@$los::position @");",2,%shape);
	$TeamItemCount[GameBase::getTeam(%player) @ "FFieldPack"]++;
	echo("MSG: ",%client," deployed a Force Field");
	return true;
}


function FField::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "FFieldPack"]--;
}

//----------------------------------------------

ItemImageData FFieldPackImage 
{ 
	shapeFile = "mortar"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 };
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData FFieldPack 
{ 
	description = "Small Force Field"; 
	shapeFile = "forcefield_5x5"; 
	className = "Backpack"; 
	heading = "qDefense"; 
	imageType = FFieldPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 100; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function FFieldPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function FFieldPack::onDeploy(%player,%item,%pos) 
{ 
	if (FFieldPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function FFieldPack::deployShape(%player,%item) 
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

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else {
			%rot =  "0 1.578 " @ getWord(Vector::getRotation($los::normal),2) + 1.578;
		}
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%shape = newObject("","StaticShape",FField,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Force Field deployed");
	playSound(SoundPickupBackpack,$los::position);
	GameBase::startFadeIn(%shape);
	schedule("playSound(ForceFieldOpen,"@$los::position @");",2,%shape);
	$TeamItemCount[GameBase::getTeam(%player) @ "FFieldPack"]++;
	echo("MSG: ",%client," deployed a Force Field");
	return true;
}


function FField::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "FFieldPack"]--;
}

//----------------------------------------------

ItemImageData HealPackImage
{
	shapeFile = "mortar"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData HealPack
{
	description = "Healing Antenna";
	shapeFile = "anten_lava";
	className = "Backpack";
   	heading = "qDefense";
	imageType = HealPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HealPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function HealPack::onDeploy(%player,%item,%pos)
{
	if (HealPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function HealPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
		    		%set = newObject("plantset",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableCactus",%num);
				deleteObject(%set);
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player);
							%rnd = floor(getRandom() * 10);
							if(%rnd > 5)
								%fField = newObject("","StaticShape",DeployableCactus1,true);
							else  
								%fField = newObject("","StaticShape",DeployableCactus2,true);

							addToSet("MissionCleanup", %fField);
							GameBase::setTeam(%fField,GameBase::getTeam(%player));
							GameBase::setPosition(%fField,$los::position);
							GameBase::setRotation(%fField,%rot);
							Gamebase::setMapName(%fField,"Healing Antenna");
							Client::sendMessage(%client,0,"Healing Antenna Deployed");
							GameBase::startFadeIn(%fField);
							playSound(SoundPickupBackpack,$los::position);
							playSound(ForceFieldOpen,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "HealPack"]++;
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

//----------------------------------------------
ItemImageData GeneratorPackImage
{
	shapeFile = "mortar"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData GeneratorPack
{
	description = "Backup Generator";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "qDefense";
	imageType = GeneratorPackImage;
	shadowDetailMask = 4;
	mass = 10.0;
	elasticity = 0.2;
	price = 2750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GeneratorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function GeneratorPack::onMount(%player,%item) {
	%client = Player::getClient(%player);  
} 

function GeneratorPack::onDeploy(%player,%item,%pos)
{
	if (GeneratorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function checkPower(%this) {
	%num = Group::objectCount($PowerSet[%this]);
	for(%i = 0; %i < %num; %i++) {
		%obj = Group::getObject($PowerSet[%this], %i);
		%objName = GameBase::getDataName(%obj);
		if (%objName == InventoryStation || %objName == AmmoStation || %objName == VehicleStation || %objName == CommandStation || %objName == VehiclePad) {
			if(!GameBase::isPowered(%obj) && $GeneratorPackPower[%obj] == 0) {
				//if (%objName != VehiclePad) {
					GameBase::playSequence(%obj,0,"power");
					GameBase::playSequence(%obj,1);
				//}
				GameBase::setActive(%obj, true);
				$GeneratorPackPower[%obj] = 1;
			}
		}
		else if(GameBase::getClassName(%obj) == "Elevator") {
			echo(%objName @ " detected!");
			if(!GameBase::isPowered(%obj) && $GeneratorPackPower[%obj] == 0) {
				echo(%objName @ " being powered!");
				Elevator::onPower(%obj,true);
				$GeneratorPackPower[%obj] = 1;
			} 
		}
		else if(GameBase::getClassName(%obj) == "Door") {
			echo(%objName @ " detected!");
			if(!GameBase::isPowered(%obj) && $GeneratorPackPower[%obj] == 0) {
				echo(%objName @ " being powered!");
				Door::onPower(%obj,true);
				$GeneratorPackPower[%obj] = 1;
			}
		}
	}
	schedule("checkPower("@%this@");", 5, %this); 
}

function GeneratorPack::deployShape(%player,%item) { 
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
						Gamebase::setMapName(%turret,"Backup Generator#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); 
						Client::sendMessage(%client,0,"Backup Generator deployed"); 
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "GeneratorPack"]++;
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

//----------------------------------------------
ItemImageData DepFFDoorPackImage
{
	shapeFile = "mortar";
	mountPoint = 2;
	//mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 1;
	firstPerson = false;
};


ItemData DepFFDoorPack
{         

	description = "Blast Floor";
	shapeFile = "elevator6x6thin";
        className = "Backpack";
         heading = "qDefense";
         imageType = DepFFDoorPackImage;
         shadowDetailMask = 4;
         mass = 2;
         elasticity = 0.2;
         price = 500;
         hudIcon = "deployable";
         showWeaponBar = true;
         hiliteOnActive = true;
 };

 function DepFFDoorPack::onUse(%player,%item)
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

function DepFFDoorPack::onDeploy(%player,%item,%pos)
{
	if (DepFFDoorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
	
function DepFFDoorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(DepFFDoorPackDeployArea(%client,$los::position)) {
						%inv = newObject("forcefield",StaticShape,"DepFFDoor",true);
	         	   addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						GameBase::startFadeIn(%inv);
						Client::sendMessage(%client,0,"Blast Floor deployed");
						playSound(SoundEnergyPackOn,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DepFFDoorPack"]++;
						echo("MSG: ",%client," deployed blast floor");
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

function DepFFDoorPackDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0);
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

//----------------------------------------------
ItemImageData DoorPackImage
{
	shapeFile = "mortar";
	mountPoint = 2;
	//mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 1;
	firstPerson = false;
};


ItemData DoorPack
{         

	description = "Defensive Door";
	shapeFile = "newdoor5";
        className = "Backpack";
         heading = "qDefense";
         imageType = DoorPackImage;
         shadowDetailMask = 4;
         mass = 2;
         elasticity = 0.2;
         price = 500;
         hudIcon = "deployable";
         showWeaponBar = true;
         hiliteOnActive = true;
 };

 function DoorPack::onUse(%player,%item)
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

function DoorPack::onDeploy(%player,%item,%pos)
{
	if (DoorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
	
function DoorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(DoorPackDeployArea(%client,$los::position)) {
						%inv = newObject("forcefield",StaticShape,"DepDoor",true);
	         	   addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						GameBase::startFadeIn(%inv);
						Client::sendMessage(%client,0,"Defensive Door deployed");
						playSound(SoundEnergyPackOn,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DoorPack"]++;
						echo("MSG: ",%client," deployed defensive door");
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

function DoorPackDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0);
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

//----------------------------------------------
ItemImageData LgFFDoorPackImage
{
	shapeFile = "mortar";
	mountPoint = 2;
	//mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 1;
	firstPerson = false;
};


ItemData LgFFDoorPack
{         

	description = "Large Force Field Door";
	shapeFile = "forcefield";
        className = "Backpack";
         heading = "qDefense";
         imageType = LgFFDoorPackImage;
         shadowDetailMask = 4;
         mass = 2;
         elasticity = 0.2;
         price = 500;
         hudIcon = "deployable";
         showWeaponBar = true;
         hiliteOnActive = true;
 };

 function LgFFDoorPack::onUse(%player,%item)
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

function LgFFDoorPack::onDeploy(%player,%item,%pos)
{
	if (LgFFDoorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
	
function LgFFDoorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(LgFFDoorPackDeployArea(%client,$los::position)) {
						%inv = newObject("forcefield",StaticShape,"LgFFDoor",true);
	         	   addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						GameBase::startFadeIn(%inv);
						Client::sendMessage(%client,0,"Large Force Field Door deployed");
						playSound(SoundEnergyPackOn,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "LgFFDoorPack"]++;
						echo("MSG: ",%client," deployed large force field door");
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

function LgFFDoorPackDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0);
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

//----------------------------------------------

ItemImageData PlatformPackImage 
{ 
	shapeFile = "mortar"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.1 }; 
	mountRotation = { 1.57, 0, 0 };
	mass = 2.0; 
	firstPerson = false; 
}; 

ItemData PlatformPack 
{ 
	description = "Deployable Hologram"; 
	shapeFile = "larmor"; 
	className = "Backpack"; 
	heading = "oDeployables"; 
	imageType = PlatformPackImage; 
	shadowDetailMask = 4; 
	mass = 2.0; 
	elasticity = 0.2; 
	price = 100; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function PlatformPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function PlatformPack::onDeploy(%player,%item,%pos) 
{ 
	if (PlatformPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function PlatformPack::deployShape(%player,%item) 
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

	%prot = GameBase::getRotation(%player);
	%zRot = getWord(%prot,2);
	if (Vector::dot($los::normal,"0 0 1") > 0.6)
		%rot = "0 0 " @ %zRot;
	else {
		if (Vector::dot($los::normal,"0 0 -1") > 0.6)
			%rot = "3.14159 0 " @ %zRot;
		else {
			%rot =  "0 1.578 " @ getWord(Vector::getRotation($los::normal),2) + 1.578;
		}
	}

	if(checkDeployArea(%client,$los::position) != true) 
		return false;

	%shape = newObject("","StaticShape",Platform,true);
	addToSet("MissionCleanup", %shape);
	GameBase::setTeam(%shape,GameBase::getTeam(%player));
	GameBase::setPosition(%shape,$los::position);
	GameBase::setRotation(%shape,%rot);
	Client::sendMessage(%client,0,"Hologram deployed");
	playSound(SoundPickupBackpack,$los::position);
	GameBase::startFadeIn(%shape);
	schedule("playSound(ForceFieldOpen,"@$los::position @");",2,%shape);
	$TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
	echo("MSG: ",%client," deployed a Platform");
	return true;
}


function Platform::onDestroyed(%this) 
{ 
	StaticShape::onDestroyed(%this); 
	$TeamItemCount[GameBase::getTeam(%this) @ "PlatformPack"]--;
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
   heading = "rMiscellany";
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
   description = "Mine";
   shapeFile = "mineammo";
   heading = "rMiscellany";
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


//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "rMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
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
   heading = "rMiscellany";
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
   heading = "rMiscellany";
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
            Player::setItemCount(%clientId,RocketF,1);
            Player::setItemCount(%clientId,Repairs,1);
            Player::setItemCount(%clientId,Dinky1,1);
            Player::setItemCount(%clientId,MortarR,1);
            Player::setItemCount(%clientId,AlienGat,1);		
            Player::setItemCount(%clientId,LaserRifle,1);
            Player::setItemCount(%clientId,Gas,1);
            Player::setItemCount(%clientId,RocketL,1);
            Player::setItemCount(%clientId,Dinky2,1);
            Player::setItemCount(%clientId,BAR,1);
            Player::setItemCount(%clientId,Anti,1);
            Player::setItemCount(%clientId,ScoutLaser,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
            Player::setItemCount(%clientId,Sniper,1);
            Player::setItemCount(%clientId,ConRocketl,1);
            Player::setItemCount(%clientId,KnightLaser,1);
            Player::setItemCount(%clientId,Dart,1);
		Player::setItemCount(%clientId,Mortar,1);

		Player::setItemCount(%clientId,BulletAmmo,200);
            Player::setItemCount(%clientId,MortarRAmmo,200);
            Player::setItemCount(%clientId,RocketLAmmo,200);
            Player::setItemCount(%clientId,Dinky1Ammo,200);
            Player::setItemCount(%clientId,AlienGatAmmo,200);
            Player::setItemCount(%clientId,GasAmmo,200);
            Player::setItemCount(%clientId,Dinky2Ammo,200);
            Player::setItemCount(%clientId,RocketFAmmo,200);
            Player::setItemCount(%clientId,SniperAmmo,200);
            Player::setItemCount(%clientId,AntiAmmo,200);
		Player::setItemCount(%clientId,BARAmmo,200);
            Player::setItemCount(%clientId,PlasmaAmmo,200);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DartAmmo, 200);
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
      $TeamItemCount[0 @ SlashPack] = 0;
      $TeamItemCount[0 @ DeployableTeleport] = 0;
	$TeamItemCount[0 @ TurretPack] = 0;
      $TeamItemCount[0 @ DefenderPack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
      $TeamItemCount[0 @ DepFFDoorPack] = 0;
      $TeamItemCount[0 @ DoorPack] = 0;
      $TeamItemCount[0 @ TargetPack] = 0;
      $TeamItemCount[0 @ LgFFDoorPack] = 0;
      $TeamItemCount[0 @ HealPack] = 0;
      $TeamItemCount[0 @ GeneratorPack] = 0;
      $TeamItemCount[0 @ FFieldPack] = 0;
      $TeamItemCount[0 @ NukePack] = 0;
	$TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[0 @ PulseSensorPack] = 0;
      $TeamItemCount[0 @ PlatformPack] = 0;
	$TeamItemCount[0 @ MotionSensorPack] = 0;
	$TeamItemCount[0 @ SpeederVehicle] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ LAPCVehicle] = 0;
	$TeamItemCount[0 @ MistVehicle] = 0;
	$TeamItemCount[0 @ HAPCVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;

	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableInvPack] = 0;
      $TeamItemCount[1 @ DeployableTeleport] = 0;
      $TeamItemCount[1 @ DefenderPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
      $TeamItemCount[1 @ NukePack] = 0;
      $TeamItemCount[1 @ LgFFDoorPack] = 0;
      $TeamItemCount[1 @ DepFFDoorPack] = 0;
      $TeamItemCount[1 @ GeneratorPack] = 0;
      $TeamItemCount[1 @ HealPack] = 0;
      $TeamItemCount[1 @ FFieldPack] = 0;
      $TeamItemCount[1 @ TargetPack] = 0;
      $TeamItemCount[1 @ DoorPack] = 0;
      $TeamItemCount[1 @ SlashPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
      $TeamItemCount[1 @ PlatformPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ SpeederVehicle] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ MistVehicle] = 0;
	$TeamItemCount[1 @ LAPCVehicle] = 0;
	$TeamItemCount[1 @ HAPCVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;

	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableInvPack] = 0;
      $TeamItemCount[2 @ DefenderPack] = 0;
      $TeamItemCount[2 @ SlashPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
      $TeamItemCount[2 @ FFieldPack] = 0;
      $TeamItemCount[2 @ LgFFDoorPack] = 0;
      $TeamItemCount[2 @ TargetPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
      $TeamItemCount[2 @ NukePack] = 0;
      $TeamItemCount[2 @ DepFFDoorPack] = 0;
      $TeamItemCount[2 @ HealPack] = 0;
      $TeamItemCount[2 @ GeneratorPack] = 0;
      $TeamItemCount[2 @ DoorPack] = 0;
      $TeamItemCount[2 @ PlatformPack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
      $TeamItemCount[2 @ DeployableTeleport] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ MistVehicle] = 0;
	$TeamItemCount[2 @ SpeederVehicle] = 0;
	$TeamItemCount[2 @ LAPCVehicle] = 0;
	$TeamItemCount[2 @ HAPCVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;

	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableInvPack] = 0;
      $TeamItemCount[3 @ DefenderPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
      $TeamItemCount[3 @ SlashPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
      $TeamItemCount[3 @ FFieldPack] = 0;
      $TeamItemCount[3 @ DoorPack] = 0;
      $TeamItemCount[3 @ GeneratorPack] = 0;
      $TeamItemCount[3 @ HealPack] = 0;
      $TeamItemCount[3 @ DepFFDoorPack] = 0;
      $TeamItemCount[3 @ LgFFDoorPack] = 0;
      $TeamItemCount[3 @ TargetPack] = 0;
      $TeamItemCount[3 @ PlatformPack] = 0;
      $TeamItemCount[3 @ NukePack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
      $TeamItemCount[3 @ DeployableTeleport] = 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ SpeederVehicle] = 0;
	$TeamItemCount[3 @ LAPCVehicle] = 0;
	$TeamItemCount[3 @ MistVehicle] = 0;
	$TeamItemCount[3 @ HAPCVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;

	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableInvPack] = 0;
      $TeamItemCount[4 @ DefenderPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
      $TeamItemCount[4 @ DeployableTeleport] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
      $TeamItemCount[4 @ FFieldPack] = 0;
      $TeamItemCount[4 @ LgFFDoorPack] = 0;
      $TeamItemCount[4 @ TargetPack] = 0;
      $TeamItemCount[4 @ DoorPack] = 0;
      $TeamItemCount[4 @ GeneratorPack] = 0;
      $TeamItemCount[4 @ HealPack] = 0;
      $TeamItemCount[4 @ DepFFDoorPack] = 0;
      $TeamItemCount[4 @ PlatformPack] = 0;
      $TeamItemCount[4 @ NukePack] = 0;
      $TeamItemCount[4 @ SlashPack] = 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ SpeederVehicle] = 0;
	$TeamItemCount[4 @ LAPCVehicle] = 0;
	$TeamItemCount[4 @ MistVehicle] = 0;
	$TeamItemCount[4 @ HAPCVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;

	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableInvPack] = 0;
      $TeamItemCount[5 @ DefenderPack] = 0;
      $TeamItemCount[5 @ SlashPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
      $TeamItemCount[5 @ DepFFDoorPack] = 0;
      $TeamItemCount[5 @ PlatformPack] = 0;
      $TeamItemCount[5 @ TargetPack] = 0;
      $TeamItemCount[5 @ LgFFDoorPack] = 0;
      $TeamItemCount[5 @ HealPack] = 0;
      $TeamItemCount[5 @ GeneratorPack] = 0;
      $TeamItemCount[5 @ DoorPack] = 0;
      $TeamItemCount[5 @ NukePack] = 0;
      $TeamItemCount[5 @ FFieldPack] = 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
      $TeamItemCount[5 @ DeployableTeleport] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ SpeederVehicle] = 0;
	$TeamItemCount[5 @ LAPCVehicle] = 0;
	$TeamItemCount[5 @ MistVehicle] = 0;
	$TeamItemCount[5 @ HAPCVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;

	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableInvPack] = 0;
      $TeamItemCount[6 @ DefenderPack] = 0;
      $TeamItemCount[6 @ SlashPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
      $TeamItemCount[6 @ DepFFDoorPack] = 0;
      $TeamItemCount[6 @ DoorPack] = 0;
      $TeamItemCount[6 @ LgFFDoorPack] = 0;
      $TeamItemCount[6 @ TargetPack] = 0;
      $TeamItemCount[6 @ NukePack] = 0;
      $TeamItemCount[6 @ FFieldPack] = 0;
      $TeamItemCount[6 @ GeneratorPack] = 0;
      $TeamItemCount[6 @ HealPack] = 0;
      $TeamItemCount[6 @ PlatformPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
      $TeamItemCount[6 @ DeployableTeleport] = 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ SpeederVehicle] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ LAPCVehicle] = 0;
	$TeamItemCount[6 @ MistVehicle] = 0;
	$TeamItemCount[6 @ HAPCVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;

	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableInvPack] = 0;
      $TeamItemCount[7 @ DefenderPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
      $TeamItemCount[7 @ SlashPack] = 0;
      $TeamItemCount[7 @ DepFFDoorPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
      $TeamItemCount[7 @ LgFFDoorPack] = 0;
      $TeamItemCount[7 @ GeneratorPack] = 0;
      $TeamItemCount[7 @ HealPack] = 0;
      $TeamItemCount[7 @ DoorPack] = 0;
      $TeamItemCount[7 @ TargetPack] = 0;
      $TeamItemCount[7 @ PlatformPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
      $TeamItemCount[7 @ NukePack] = 0;
      $TeamItemCount[7 @ DeployableTeleport] = 0;
      $TeamItemCount[7 @ FFieldPack] = 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ SpeederVehicle] = 0;
	$TeamItemCount[7 @ MistVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
