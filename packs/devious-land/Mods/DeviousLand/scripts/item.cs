//----------------------------------------------------------------------------


$ItemFavoritesKey = "DeviousLand";
				  // Change this if you add new items
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
$AutoUse[ChargeGun] = True;
$AutoUse[Doomcannon] = True;
$AutoUse[Sluggard] = True;
$AutoUse[Hypercannon] = True;
$AutoUse[EmpireLaser] = True;
$AutoUse[VandalSniper] = True;
$AutoUse[ArbiterFusionGun] = True;
$AutoUse[ArbiterHeavyFusion] = True;
$AutoUse[ChosenRifle] = True;
$AutoUse[Immol] = True;
$AutoUse[LifeDrain] = True;
$AutoUse[Flechette] = True;
$AutoUse[PlasmaThrower] = True;
$AutoUse[BlessingWand] = True;
$AutoUse[Spore] = True;
$AutoUse[SporeMine] = True;


$Use[Blaster] = True;

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Male, KineticArmor] = karmor;
$ArmorType[Female, KineticArmor] = karmor;
$ArmorType[Male, SniperArmor] = sarmor;
$ArmorType[Female, SniperArmor] = sarmor;
$ArmorType[Male, DoomArmor] = darmor;
$ArmorType[Female, DoomArmor] = darmor;
$ArmorType[Male, ErectorArmor] = earmor;
$ArmorType[Female, ErectorArmor] = earmor;
$ArmorType[Male, ArbiterArmor] = aarmor;
$ArmorType[Female, ArbiterArmor] = aarmor;
$ArmorType[Male, GrandArbiterArmor] = gaarmor;
$ArmorType[Female, GrandArbiterArmor] = gaarmor;
$ArmorType[Male, ChosenArmor] = carmor;
$ArmorType[Female, ChosenArmor] = carmor;
$ArmorType[Male, LarvalArmor] = iarmor;
$ArmorType[Female, LarvalArmor] = iarmor;
$ArmorType[Male, IAdultArmor] = iaarmor;
$ArmorType[Female, IAdultArmor] = iaarmor;
$ArmorType[Male, QueenArmor] = qarmor;
$ArmorType[Female, QueenArmor] = qarmor;

$TeamTag[DoomArmor] = Empire;
$TeamTag[KineticArmor] = Vandals;
$TeamTag[ErectorArmor] = Empire;
$TeamTag[SniperArmor] = Vandals;
$TeamTag[ArbiterArmor] = Arbiters; 
$TeamTag[GrandArbiterArmor] = X; //empty slot
$TeamTag[ChosenArmor] = X;	   //to prevent anyone from buying	
$TeamTag[LarvalArmor] = X;
$TeamTag[IAdultArmor] = X;
$TeamTag[QueenArmor] = X;

$TeamTag[Doomcannon] = Empire;
$TeamTag[Sluggard] = Empire;
$TeamTag[DeathTouch] = Vandals;
$TeamTag[EmpireLaser] = Empire;
$TeamTag[Hypercannon] = Vandals;
$TeamTag[EmpireTank] = Empire;
$TeamTag[DeployableTree] = Vandals;
$TeamTag[DeployableWall] = Empire;
$TeamTag[PortaGen] = Empire;
$TeamTag[VandalInterceptor] = Vandals;
$TeamTag[VandalSniper] = Vandals;
$TeamTag[ArbiterPod] = Arbiters;
$TeamTag[ArbiterFusionGun] = Arbiters;
$TeamTag[ArbiterHeavyFusion] = Arbiters;
$TeamTag[GrandMantle] = Arbiters;
$TeamTag[ChosenRifle] = Arbiters;
$TeamTag[LifeDrain] = X;
$TeamTag[Larva] = Insatiable;
//$TeamTag[Immol] = X;
$TeamTag[Flechette] = X;
$TeamTag[PlasmaThrower] = Insatiable;
$TeamTag[Spore] = Insatiable;
$TeamTag[SporeMine] = Insatiable;
$TeamTag[Satellite] = Arbiters;
$TeamTag[DeployableNest] = Insatiable;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorName[karmor] = KineticArmor;
$ArmorName[sarmor] = SniperArmor;
$ArmorName[darmor] = DoomArmor;
$ArmorName[earmor] = ErectorArmor;
$ArmorName[aarmor] = ArbiterArmor;
$ArmorName[gaarmor] = GrandArbiterArmor;
$ArmorName[carmor] = ChosenArmor;
$ArmorName[iarmor] = LarvalArmor;
$ArmorName[iaarmor] = IAdultArmor;
$ArmorName[qarmor] = QueenArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[DoomAmmo] = 25;
$SellAmmo[SluggardAmmo] = 1;
$SellAmmo[SniperRounds] = 25;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;
$AmmoPackMax[DoomAmmo] = 100;
$AmmoPackMax[SluggardAmmo] = 2;
$AmmoPackMax[SniperRounds] = 12;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[10] = Beacon;
$AmmoPackItems[7] = DoomAmmo;
$AmmoPackItems[8] = SluggardAmmo;
$AmmoPackItems[9] = SniperRounds;

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
$TeamItemMax[DeployableTree] = 20;
$TeamItemMax[DeployableWall] = 15;
$TeamItemMax[PortaGen] = 3;
$TeamItemMax[DeathTouch] = 32;
$TeamItemMax[VandalInterceptor] = 2;
$TeamItemMax[EmpireTank] = 2;
$TeamItemMax[GrandMantle] = 999;
$TeamItemMax[ArbiterPod] = 2;
$TeamItemMax[DeployableNest] = 999;
$TeamItemMax[Larva] = 999;
$TeamItemMax[Satellite] = 6;
$TeamItemMax[Cloak] = 3;

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
$WeaponAmmo[Doomcannon] = DoomAmmo;
$WeaponAmmo[Sluggard] = SluggardAmmo;
$WeaponAmmo[Hypercannon] = "";
$WeaponAmmo[EmpireLaser] = "";
$WeaponAmmo[VandalSniper] = SniperRounds;
$WeaponAmmo[ArbiterFusionGun] = "";
$WeaponAmmo[ArbiterHeavyFusion] = "";
$WeaponAmmo[ChosenRifle] = "";
$WeaponAmmo[Immol] = "";
$WeaponAmmo[LifeDrain] = "";
$WeaponAmmo[Flechette] = BulletAmmo;
$WeaponAmmo[PlasmaThrower] = "";
$WeaponAmmo[BlessingWand] = "";
$WeaponAmmo[Spore] = "";
$WeaponAmmo[SporeMine] = "";

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


function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%favItem20,%favItem21,%favItem22,%favItem23,%favItem24,%favItem25,%favItem26,%favItem27,%favItem28,%favItem29,%favItem30,%favItem31)
{
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
// instance 1
//					messageall(0, "using test instance 1");
//echo("MSG: using instance1");

					%count = Player::getItemCount(%client,%item);
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}
			for (%i = 0; %i < 32; %i++) { 
				if(%favItem[%i] != "") {
					%item = getItemData(%favItem[%i]);
//instance 2
//	messageall(0, "using test instance //2");							
//echo("MSG: using instance2");
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
	if(%item.className == Armor) 
//		{if(%team == $TeamTag[%item] || $TeamTag[%item] == "") return 1; //else return 0;}	
		{if(getteamname(%team) == $TeamTag[%item] || $TeamTag[%item] == "") return 1; else 
	{Client::sendMessage(%client, 0, "Your Team doesn't have that Tech.");
return 0;
	 
	}}	


//
//	if(%team != $TeamTag[%item] || $TeamTag[%item] != "") return 0; 


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
//			if(%team == $TeamTag[%item] || $TeamTag[%item] == "") //return 1; else return 0;	
		if(getteamname(%team) == $TeamTag[%item] || $TeamTag[%item] == "") return 1; else 
{Client::sendMessage(%client, 0, "Your Team doesn't have that Tech.");
return 0;}



// 	if(%team != $TeamTag[%item] || $TeamTag[%item] != "") return 0; 

 
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
		
//		if(%team == $TeamTag[%item] || $TeamTag[%item] == "") return 1; //else return 0;	

		if(getteamname(%team) == $TeamTag[%item] || $TeamTag[%item] == "") return 1; else
{Client::sendMessage(%client, 0, "Your Team doesn't have that Tech.");
	return 0;}
	

		
//		if(%team != $TeamTag[%item] || $TeamTag[%item] != "") return 0; 

	}
	if(%item.className != Armor && %item.className != Vehicle) {
//instance 3
//        messageall(0, "using test instance 3");
//echo("MSG: using instance3");
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
//instance 4
//messageall(0, "using test instance 4");
//echo("MSG: using instance4");
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) {
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
	//				armorChange(%client);
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
			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack) {
//instance 5
//					message(0, "using test instance 5");
//echo("MSG: using instance5");
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
//instance6
//messageall(0, "using test instance 6");
//echo("MSG: using instance6");
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
	%player = Client::getOwnedObject(%client);
	if (%item == InsatiableArmor || %item == Larva  || %item == Parasite)
		{
	client::sendmessage(%client, 0, "You cannot separate from your symbiot!");
//		player::mountitem(%client, Larva);
 		return 0;
		}

	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) {
//instance 7
//messageall(0, "using test instance 7");	
//echo("MSG: using instance7");
	if(Player::getItemCount(%client,%item) && %item.className != Armor) {
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo) {
//instance  8
//messageall(0, "using test instance 8");
//echo("MSG: using instance8");
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
//instance 9
//messageall(0, "using test instance 9");
//echo("MSG: using instance9");
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
$NextWeapon[Chaingun] = Doomcannon;
$NextWeapon[Doomcannon] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = Sluggard;
$NextWeapon[Sluggard] = Hypercannon;
$NextWeapon[Hypercannon] =LaserRifle;
$NextWeapon[LaserRifle] = EmpireLaser;
$NextWeapon[EmpireLaser] = VandalSniper;
//$NextWeapon[VandalSniper] = EnergyRifle;
$NextWeapon[VandalSniper] = ArbiterFusionGun;
$NextWeapon[ArbiterFusionGun] = ArbiterHeavyFusion;
$NextWeapon[ArbiterHeavyFusion] = ChosenRifle;
$NextWeapon[ChosenRifle] = Immol;
$NextWeapon[Immol] = LifeDrain;
$NextWeapon[LifeDrain] = Flechette;
$NextWeapon[Flechette] = PlasmaThrower;
$NextWeapon[PlasmaThrower] = BlessingWand;
$NextWeapon[BlessingWand] = Spore;
$NextWeapon[Spore] = SporeMine;
$NextWeapon[SporeMine] = EnergyRifle;


$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[Doomcannon] = Chaingun;
$PrevWeapon[DiscLauncher] = Doomcannon;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[Sluggard] = Mortar;
$PrevWeapon[Hypercannon] = Sluggard;
$PrevWeapon[LaserRifle] = Hypercannon;
$PrevWeapon[EmpireLaser] = LaserRifle;
$PrevWeapon[VandalSniper] = EmpireLaser;
$PrevWeapon[ArbiterFusionGun] = VandalSniper;
$PrevWeapon[ArbiterHeavyFusion] = ArbiterFusionGun;
$PrevWeapon[ChosenRifle] = ArbiterHeavyFusion;
$PrevWeapon[Immol] = ChosenRifle;
$PrevWeapon[LifeDrain] = Immol;
$PrevWeapon[Flechette] = LifeDrain;
$PrevWeapon[PlasmaThrower] = Flechette;
$PrevWeapon[BlessingWand] = PlasmaThrower;
$PrevWeapon[Spore] = BlessingWand;
$PrevWeapon[SporeMine] = Spore;
$PrevWeapon[EnergyRifle] = SporeMine;

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
	//instance10
//messageall(0, "using test instance 10");
//echo("MSG: using instance10");
	if (Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
//instance 11
//messageall(0, "using test instance 11");		
//echo("MSG: using instance11");
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
//instance 12
//messageall(0, "using test instance 12");
//echo("MSG: using instance12");
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
//instance 13
//messageall(0, "using test instance 13");
//echo("MSG: using instance13");
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
	%client = Player::getclient(%player);
	if($matchStarted) {
		if(%item.className != Armor) {
		if(%item == Larva)
			{client::sendmessage(%client, 0, "You cannot abandon your symbiot Larva! ~wDeath");
return;
}
			if(%item == Parasite)	{return;}
			if(%item == DeployableNest)
				{if (Player::isDead(%player)) 
					{
Player::unmountItem(%player,$BackPackSlot);
					Player::decItemCount(%player,%item,1);
	%marker = newObject("","Item","nestdeathtracker",1,false);
		 	addToSet("MissionCleanup", %marker);
			GameBase::throw(%marker,%player,5,true);
			%player.throwTime = getSimTime() + 0.5;
                      schedule("nestdeath(" @ %marker @ ");", 5, %marker);
//                        %growlevel = 1;
//                        schedule("nestdeath(" @ %marker @ "," @ %growlevel @");", 5, %marker);
							return;
					}
		else
			{
bottomprint(%client, "You must deploy your Nest using P.");	
		return; 
			}
		}


			//echo("Item dropped: ",%player," ",%item);
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
	
			else {
		//		if (%item == DeployableTree)
		//		%rate = Player::getSensorSupression(%player) - 15;
 		//		Player::setSensorSupression(%player,%rate); 
	
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

function nestdeath(%marker)
{
	
						%nest = newObject("DeployableNest","StaticShape",TheNest,true);
	                     addToSet("MissionCleanup", %nest);
				%spawnMarker = GameBase::getPosition(%marker);
				%rotMarker = GameBase::getRotation(%marker);
GameBase::setPosition(%nest,%spawnMarker);
GameBase::setRotation(%nest,%rotMarker);

	Client::sendMessage(%client,0,"Nest Spawned.");
	playSound(SoundPickupHealth,%spawnMarker);
//	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableNest"]++;
//	echo("MSG: ",%client," dropped a nest in death");
	deleteObject(%marker);
	GameBase::setAutoRepairRate(%nest,0.1);
	Gamebase::setMapName(%nest,"Nest");
//        if (%growlevel < 5)
//        {
%continuance = (getRandom() * 100);
        if(%continuance >= 20)
        {
      schedule("nestduplicate(" @ %nest @ ");", 5, %nest);
//        schedule("nestduplicate(" @ %nest @ "," @ %growlevel @ ");", 5, %nest);
//        %growlevel++;
//        }
         }       
}


function nestgrow(%marker)
{
	
                   %nest = newObject("DeployableNest","StaticShape",TheNest,true);
                   addToSet("MissionCleanup", %nest);
                   %spawnMarker = GameBase::getPosition(%marker);
                   %rotMarker = GameBase::getRotation(%marker);
%spinstart = (getRandom() * 6);
%spinner = (%spinstart * 0.5);
%xRot = (getWord(%rotMarker, 0) * spinner); 
%zRot = (getword(%rotMarker, 2) * spinner);
%yRot = (getword(%rotMarker, 1) * %spinner); 
GameBase::setPosition(%nest,%spawnMarker);
GameBase::setRotation(%nest,%xRot @ " " @ %yRot @ " " @ %zRot);


//GameBase::setRotation(%nest,%rotMarker);

//	Client::sendMessage(%client,0,"Nest Spawned.");
	playSound(SoundPickupHealth,%spawnMarker);
//	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableNest"]++;
//	echo("MSG: ",%client," dropped a nest in death");
	deleteObject(%marker);
	GameBase::setAutoRepairRate(%nest,0.1);
	Gamebase::setMapName(%nest,"Nest");
//	schedule("nestduplicate(" @ %nest @ ");", 10, %nest);
//if (%growlevel < 5)
//        {
%continuance = (getRandom() * 100);
        if(%continuance >= 20)
          {                       
      schedule("nestduplicate(" @ %nest @ ");", 5, %nest);
//        schedule("nestduplicate(" @ %nest @ "," @ %growlevel @ ");", 5, %nest);
//        %growlevel++;
//        }
          }

}


function nestduplicate(%nest)
{
%marker = newObject("","Item","nestdeathtracker",1,false);
		 	addToSet("MissionCleanup", %marker);
//			GameBase::throw(%marker,%nest,25,true);
			GameBase::throw(%marker,%nest,1, true);
//			%player.throwTime = getSimTime() + 0.5;
                        schedule("nestgrow(" @ %marker @ ");", 0.001, %marker);
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


ItemData KineticArmor
{
   heading = "aArmor";
	description = "Vandal KineticArmor";
	className = "Armor";
	price = 400;
};

ItemData SniperArmor
{
   heading = "aArmor";
	description = "Vandal SniperSuit";
	className = "Armor";
	price = 400;
};


ItemData DoomArmor
{
   heading = "aArmor";
	description = "Empire DoomArmor";
	className = "Armor";
	price = 400;
};



ItemData ErectorArmor
{
   heading = "aArmor";
	description = "Empire ErectorArmor";
	className = "Armor";
	price = 300;
};


ItemData ArbiterArmor
{
   heading = "aArmor";
	description = "ArbiterArmor";
	className = "Armor";
	price = 1;
};

ItemImageData BlessingWandImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 2;  // Sustained
	projectileType = Regulation;
minEnergy = 3;
maxEnergy = 10;
	lightType   = 2;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData BlessingWand
{
	description = "Blessing Wand";
	shapeFile = "shotgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = BlessingWandImage;
	showInventory = false;
	price = 1;
};

function BlessingWand::onMount(%player,%imageSlot)
{
      Client::sendMessage(Player::getClient(%player),0, "Arbiter Blessing Wand Selected.  Bless someone 4 times to grant them Chosen Armor");
	Player::trigger(%player,$BackpackSlot,true);	

}

function BlessingWand::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Regulator1Image
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;  // Sustained
	projectileType = Repairbolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData Regulator1
{
	description = "Repair Activator";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = Regulator1Image;
	showInventory = false;
	price = 1;
};

function Regulator1::onMount(%player,%imageSlot)
{
      Client::sendMessage(Player::getClient(%player),0, "Repair Activator Selected.");
	Player::trigger(%player,$BackpackSlot,true);
}


function Regulator1::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
	
}

ItemImageData GrandMantleImage
{
	shapeFile = "armorpack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData GrandMantle
{
	description = "GrandArbiter Mantle";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "aArmor";
	shadowDetailMask = 4;
	imageType = GrandMantleImage;
	price = 1;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
sfxAmbient = SoundGeneratorPower;
};

function GrandMantle::onMount(%player, %item)
{
	%client = Player::getclient(%player);
		bottomprint(%client, "You have gained the title of Grand Arbiter " @ Client::getName(%client) @ ".\nYour GrandMantle pack contains a BlessingWand and RepairActivator.\nYou can use captured Technology and are immune to poisons & diseases.");
$TeamItemCount[GameBase::getTeam(%player) @ "GrandMantle"]++;
 
}
//--{}

function GrandMantle::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == BlessingWand || Regulator1) {
		Player::unmountItem(%player,$WeaponSlot);
	}
$TeamItemCount[GameBase::getTeam(%player) @ "GrandMantle"]--;
	
}

function GrandMantle::onUse(%player,%item)
{
		%client = Player::getclient(%player);
		bottomprint(%client, "You have gained the title of Grand Arbiter " @ Client::getName(%client) @ ".\nYour GrandMantle pack contains a BlessingWand and RepairActivator.\nYou can use captured Technology and are immune to poisons & diseases.");
				%player.shieldStrength = 0.0;
%newarmor = $ArmorType[Client::getGender(%client), GrandArbiterArmor];
	%oldarmor = Player::getArmor(%client);
			Player::setArmor(%client,%newarmor);
					checkMax(%client,%newarmor);
//--					armorChange(%client);
                              Player::setItemCount(%player, $ArmorName[%oldarmor], 0);  
                               Player::setItemCount(%player, GrandArbiterArmor, 1);
// Player::setItemCount(%player, BlessingWand, 1);

if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
              if (Player::getMountedItem(%player, $WeaponSlot) == BlessingWand)
                {       Player::mountItem(%player,Regulator1,$WeaponSlot);
//--                        Player::mountItem(%player,Regulator1,$WeaponSlot);
              }
                      else
                                      Player::mountItem(%player,BlessingWand,$WeaponSlot);
	     }
//	$TeamItemCount[GameBase::getTeam(%player) @ "GrandMantle"]++;

}

function GrandMantle::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == BlessingWand) {
			Player::unmountItem(%player,$WeaponSlot);
		}
                if (%mounted == Regulator1) {
                        Player::unmountItem(%player,$WeaponSlot);
                }
		else {
		// Remount the existing weapon to make sure the Regulator
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	


ItemData GrandArbiterArmor
{
   heading = "aArmor";
	description = "(GrandArbiter Armor)";
	className = "Armor";
	price = 0;
};

ItemData ChosenArmor
{
   heading = "aArmor";
	description = "(Arbiter ChosenArmor)";
	className = "Armor";
	price = 0;
};


ItemImageData LarvaImage
{
	shapeFile = "";
	mountPoint = 2;
	weaponType = 2;  // Sustained
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData Larva
{
	description = "Insatiable Larva";
	shapeFile = "";
	className = "Backpack";
   heading = "aArmor";
	shadowDetailMask = 4;
	imageType = LarvaImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = false;
sfxAmbient = SoundGeneratorPower;
};

function Larva::onMount(%player, %item)
{
	%this.larvai = getSimTime();
	%player.fed = 0;
        for(%feed = 1; %feed < 5; %feed = %feed * 1.5)
                {       %feedingtime = %feed * 12;
		schedule("Larvafeed(" @ %player @ ");",%feedingtime,%player);
		}
        $TeamItemCount[GameBase::getTeam(%player) @ "Larva"]++;
Player::setItemCount(%player, LifeDrain, 1);
//	bottomprint(%client, "You are host to an Insatiable Larva\nYou can //drain life from others to heal yourself using LifeDrain.\nYou will //automatically mature into either a Drone or PainMistress");
Player::useItem(%player,%item);
}


function Larva::onUnmount(%player,%item)
{
			%client = Player::getclient(%player);
//if (Player::getMountedItem(%player,$WeaponSlot) == LifeDrain) {
//		Player::unmountItem(%player,$WeaponSlot);
//	}	
if(player::getitemcount(%player, LifeDrain) != 1) {
	client::sendmessage(%client, 0, "You cannot abandon your symbiot Larva!");

Player::mountItem(%player,%item,$BackpackSlot);
return 0;
}
}

function Larva::onUse(%player,%item)
{
%client = Player::getclient(%player);
			bottomprint(%client, "You are host to an Insatiable Larva\nYou can drain life from others to heal yourself using LifeDrain.\nYou will automatically mature into either a Drone or PainMistress");
%team = Client::getTeam(%client);
%tname = getteamname(%team); 
if (%tname == "Insatiable")
{
%newarmor = $ArmorType[Client::getGender(%client), LarvalArmor];
	%oldarmor = Player::getArmor(%client);
			Player::setArmor(%client,%newarmor);
					checkMax(%client,%newarmor);
                              Player::setItemCount(%player, $ArmorName[%oldarmor], 0);  
                               Player::setItemCount(%player, LarvalArmor, 1);
if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
	
					Player::mountItem(%player,LifeDrain,$WeaponSlot);
	     }
//end if team is correct
}

	}

function Larvafeed(%player)
{
if (Player::getItemCount(%player, Parasite) == 1)
	{
	%player.fed++;
 %client = Player::getclient(%player);
%team = Client::getTeam(%client);
%tname = getteamname(%team); 
%player.Larvarate = 0.15;
	%LarvaDamage = GameBase::getDamageLevel(%player) + %player.Larvarate;
	GameBase::setDamageLevel(%player, %LarvaDamage);
	client::sendMessage(%client, 0, "A parasite is eating your insides. ~wError_Message.wav");
if(%player.fed > 3)	{
	 client::sendMessage(%client, 0, "The Parasite in you has burst!");
	GameBase::setDamageLevel(%player, 20);
	}  	
	}
if(player::getitemcount(%player, Larva) == 1)
{	 
	%player.fed++;
 %client = Player::getclient(%player);
%team = Client::getTeam(%client);
%tname = getteamname(%team); 
%player.Larvarate = 0.15;
	%LarvaDamage = GameBase::getDamageLevel(%player) + %player.Larvarate;
if (%tname == "Insatiable")
	{
	GameBase::setDamageLevel(%player, %LarvaDamage);
	client::sendMessage(%client, 0, "Your Larva is feeding. ~wError_Message.wav");
if(%player.fed > 3) {
	 client::sendMessage(%client, 0, "Your Larva has reached maturity!");
	GameBase::setAutoRepairRate(%player, 0.033);	
	Player::setItemCount(%player, LifeDrain, 1);
%spawnchance = (getRandom() * 50);
if (%spawnchance > 30) {
        %newarmor = $ArmorType[Client::getGender(%client), QueenArmor];
        %oldarmor = Player::getArmor(%client);
                        Player::setArmor(%client,%newarmor);
                                        checkMax(%client,%newarmor);
                              Player::setItemCount(%player, $ArmorName[%oldarmor], 0);  
                               Player::setItemCount(%player, QueenArmor, 1);
 Player::setItemCount(%player, LifeDrain, 1);
 Player::setItemCount(%player, Spore, 1);
Player::setItemCount(%player, SporeMine, 1);
Player::setItemCount(%player, DeployableNest, 1);
Player::mountItem(%player, DeployableNest, $BackpackSlot);
bottomprint(%client, "You have become a PainMistress!\n You have the powers: LifeDrain, SporeThrower, Spore Mines, Nest Laying and Regeneration.");
GameBase::setAutoRepairRate(%player, 0.075);	
}
	
if (%spawnchance < 31) {
%newarmor = $ArmorType[Client::getGender(%client), IAdultArmor];
	%oldarmor = Player::getArmor(%client);
			Player::setArmor(%client,%newarmor);
					checkMax(%client,%newarmor);
                              Player::setItemCount(%player, $ArmorName[%oldarmor], 0);  
                               Player::setItemCount(%player, IAdultArmor, 1);
 Player::setItemCount(%player, LifeDrain, 1);
Player::setItemCount(%player, Spore, 1);
bottomprint(%client, "You have become a Drone for the Insatiable!\nYou have LifeDrain, SporeThrowing, and Regeneration.");
}
	}
}
else
			{
GameBase::setDamageLevel(%player, %LarvaDamage);
	client::sendMessage(%client, 0, "A parasite is eating your insides. ~wError_Message.wav");
if(%player.fed > 3)	{
	 client::sendMessage(%client, 0, "The Larva in you has burst!");
	GameBase::setDamageLevel(%player, 20);
//GameBase::applyDamage(%client, $MissileDamageType, 20, 1, 1, 1, 1);
				}
			}
}
}

ItemData Parasite
{
   description = "Insatiallis Tripanosoma";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 0;
};


ItemData LarvalArmor
{
   heading = "aArmor";
	description = "(Larval Armor)";
	className = "Armor";
	price = 0;
};


ItemData IAdultArmor
{
   heading = "aArmor";
	description = "(Drone Armor)";
	className = "Armor";
	price = 0;
};

ItemData QueenArmor
{
   heading = "aArmor";
	description = "(PainMistress)";
	className = "Armor";
	price = 0;
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

ItemData EmpireTank
{
	description = "Empire Flying Tank";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1000;
};

ItemData VandalInterceptor
{
	description = "Vandal Interceptor";
	className = "Vehicle";
   heading = "aVehicle";
	price = 750;
};

ItemData ArbiterPod
{
	description = "Arbiter Pod";
	className = "Vehicle";
	heading = "aVehicle";
		price = 1;
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
//instance 14
//messageall(0, "using test instance 14");
//echo("MSG: using instance14");	
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
//instance 15
//messageall(0, "using test instance 15");
//echo("MSG: using instance15");
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
//-------

ItemImageData SporeImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
//	ammoType = GrenadeAmmo;
	projectileType = SporePod;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 25;
	maxEnergy = 26;
muzzlevelocity = 20;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Spore
{
	description = "Insatiable Sporethrower";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SporeImage;
	price = 0;
	showWeaponBar = true;
};

function Spore::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The SporeThrower shoots an explosive SporePod.\nSpores will get thru personal shields, but will not affect shielded electronics.");
	
}

//------

ItemImageData SporeMineImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
//	ammoType = GrenadeAmmo;
	projectileType = SporeMinePod;
	accuFire = true;
	reloadTime = 0.75;
	fireTime = 5.0;
	minEnergy = 5;
	maxEnergy = 7;
//muzzlevelocity = 20;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SporeMine
{
	description = "Insatiable Sporemines";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SporeMineImage;
	price = 0;
	showWeaponBar = true;
};

function SporeMine::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The Spore Mines are explosive SporePods. The mines will fade after 5 minutes.\n  Larval, Insatiable, and PainMistress are immune to sporedamage.");
	
}

//-------

ItemImageData ImmolImage
{
   shapeFile  = "plasma";
	mountPoint = 0;

	weaponType = 2; // Single Shot
	reloadTime = 0;
	fireTime = 0.5;
//fireTime = 0.02;
	minEnergy = -1;
	maxEnergy = 1;

	projectileType = ImmolMissile;
	accuFire = false;
	isvisible = false;
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Immol
{
   heading = "bWeapons";
	description = "Immolator Missile";
	className = "Weapon";
   shapeFile  = "plasma";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = ImmolImage;
	price = 2000;
	showWeaponBar = true;
};

//function Immol::verifyTarget(%target)
//{
//   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
//      return "True";
//   else
//      return "False";
//}


//-------------


//---------------


//-----


//--------

ItemData SniperRounds
{
	description = "Sniper Rounds";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 25;
};


ItemImageData VandalSniperImage
{
	shapeFile = "sniper";
	mountPoint = 0;
//      mountOffset = { 0, 0., 0.5 };
//	mountRotation = { 0, 0, 0 };

	weaponType = 0; 
	reloadTime = 10;
//	spinUpTime = 0.5;
//	spinDownTime = 3;
	fireTime = 0.1;

	ammoType = SniperRounds;
	projectileType = SniperBullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
     
      
	sfxFire = SoundEnergyTurretFire;
	sfxActivate = SoundPickUpWeapon;
//	sfxSpinUp = SoundSpinUp;
//	sfxSpinDown = SoundSpinDown;
};

ItemData VandalSniper
{
	description = "Vandal Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = VandalSniperImage;
	price = 750;
	showWeaponBar = true;
};

function VandalSniper::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The Vandal SniperRifle fires high power rounds.  One shot will kill a light armor.");
	
}


//------
ItemImageData HypercannonImage
{
   shapeFile  = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.09;
//fireTime = 0.03;
	minEnergy = 3;
	maxEnergy = 4;

	projectileType = HyperShot;
	accuFire = false;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Hypercannon
{
   heading = "bWeapons";
	description = "Vandal HyperBlaster";
	className = "Weapon";
   shapeFile  = "plasma";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = HypercannonImage;
	price = 300;
	showWeaponBar = true;
};

function Hypercannon::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The Hypercannon fires superfast, low-energy plasma shots.");
	
}

//------------------------------

//------------------

ItemData DoomAmmo
{
	description = "Doom Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 25;
};


ItemImageData DoomcannonImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = DoomAmmo;
	projectileType = DoomBullet;
	accuFire = false;

//	lightType = 3;  // Weapon Fire
//	lightRadius = 3;
//	lightTime = 1;
//	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Doomcannon
{
	description = "Doom Cannon";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DoomcannonImage;
	price = 750;
	showWeaponBar = true;
};

function Doomcannon::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The Doomcannon fires explosive rounds at high speed.");
	
}

//------------


ItemData SluggardAmmo
{
	description = "Sluggard Shots";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData SluggardImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SluggardAmmo;
	projectileType = SluggardMissile;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Sluggard
{
	description = "Doom Sluggard";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SluggardImage;
	price = 500;
	showWeaponBar = true;
};

function Sluggard::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The Sluggard fires slow speed, nuclear warheads.  Anything in Line-of-Sight will be destroyed.\nUse CAUTION firing this weapon near your own base!");
	
}


//-------

ItemImageData EmpireLaserImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; 
	projectileType = EmpireSniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EmpireLaser
{
	description = "Empire Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = EmpireLaserImage;
	price = 300;
	showWeaponBar = true;
};

function EmpireLaser::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The Empire Laser is like the normal Laser Rifle, except any Empire soldier can carry it.");
	
}



//------------------
ItemImageData TheTouchImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = TouchCharge;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	
 lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData TheTouch
{
	description = "The Touch";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = TheTouchImage;
	showInventory = false;
	price = 125;
};

function TheTouch::onMount(%player,%imageSlot)
{
	function TheTouch::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The DeathTouch delivers a lethal electrical surge, but the range is extremely short.");
	
}

	Player::trigger(%player,$BackpackSlot,true);
}

function TheTouch::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}



//----
ItemImageData DeathTouchImage
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

ItemData DeathTouch
{
	description = "Kinetic Death-Touch";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = DeathTouchImage;
	price = 300;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeathTouch::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == TheTouch) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function DeathTouch::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,TheTouch,$WeaponSlot);
	}
}

function DeathTouch::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == TheTouch) {
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

//------------------
ItemImageData ChosenRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = chosenCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
//   lightType = 3;  // Weapon Fire
//   lightRadius = 2;
//   lightTime = 1;
//   lightColor = { 0.25, 0.25, 0.85 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData ChosenRifle
{
   description = "Arbiter ChosenRifle";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = ChosenRifleImage;
	showWeaponBar = true;
   price = 1;
};

function ChosenRifle::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The ChosenRifle fires a long, destructive electrical beam.");
	
}




//------
ItemImageData ArbiterHeavyFusionImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = ArbiterHeavyFusionBolt;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.4;
	minEnergy = 10;
	maxEnergy = 11;

//	lightType = 3;  // Weapon Fire
//	lightRadius = 3;
//	lightTime = 1;
//	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
};

ItemData ArbiterHeavyFusion
{
	description = "Arbiter HeavyFusion";
      className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
 heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ArbiterHeavyFusionImage;
	price = 1;
	showWeaponBar = true;
};

function ArbiterHeavyFusion::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The HeavyFusion Cannon fires destructive PlasmaBolts.");
	
}


//---------

ItemImageData ArbiterFusionGunImage
{
	shapeFile  = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
//fireTime = 0.2;
	fireTime = 0.1;
	minEnergy = 10;
	maxEnergy = 11;

	projectileType = ArbiterFusionBolt;
	accuFire = true;


sfxFire = SoundEnergyTurretFire;

	sfxActivate = SoundPickUpWeapon;


//lightType = 3;  // Weapon Fire
//	lightRadius = 3;
//	lightTime = 1;
//	lightColor = { 0.6, 1, 1 };

};


ItemData ArbiterFusionGun
{
	description = "Arbiter FusionGun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ArbiterFusionGunImage;
	price = 1;
	showWeaponBar = true;
};

function ArbiterFusionGun::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "The Arbiter FusionGun fires rapid, low-energy PlasmaBolts.");
	
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
   price = 500;
};

//--------------------------------------------------------------------------

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


ItemImageData FlechetteImage
{
   shapeFile  = "energygun";
	mountPoint = 0;
	ammoType = BulletAmmo;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.03;
//fireTime = 0.02
//	minEnergy = 3;
//	maxEnergy = 4;

	projectileType = FlechetteShot;
	accuFire = false;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Flechette
{
   heading = "bWeapons";
	description = "Flechette Gun";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FlechetteImage;
	price = 300;
	showWeaponBar = true;
};

ItemImageData LifeDrainImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = LifeDrainCharge;
   minEnergy = 10;
   maxEnergy = 100;  // Energy used/sec for sustained weapons
	reloadTime = 1;
                        
//   lightType = 3;  // Weapon Fire
//   lightRadius = 2;
//   lightTime = 1;
//   lightColor = { 0.25, 0.25, 0.85 };
   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData LifeDrain
{
   description = "LifeDrain";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = LifeDrainImage;
	showWeaponBar = true;
   price = 0;
};


function LifeDrain::onMount(%player,%item,$WeaponSlot)
{
%client = Player::getclient(%player);

      Bottomprint(%client, "LifeDrain takes a portion of the target's life energy and adds it to your own.  Very short range.");
	
}


//------------

ItemImageData PlasmaThrowerImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = PlasmaStream;
	accuFire = true;
	reloadTime = 0.01;
	fireTime = 0.02;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaThrower
{
	description = "PlasmaStream";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaThrowerImage;
	price = 300;
	showWeaponBar = true;
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
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Repairgun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,Repairgun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == Repairgun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the Repairgun
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
		for(%i = 0; %i < 10 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
//instance16
//messageall(0, "using test instance 16");
//echo("MSG: using instance16");
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
	 	    	%item.MineAmmo = %numPack;
			}
			else if(%i == 6) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else if(%i == 7) {
			%item.Doomammo = %numPack;		
			}
			else if(%i == 8) {
			%item.SluggardAmmo = %numPack;		
			}
	else {
	 	    	%item.SniperRounds = %numPack;
			}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
//instance17
//messageall(0, "using test instance 17");
//echo("MSG: using instance17");
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
	for(%i = 0; %i < 10 ; %i = %i +1) {
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
	 	    	%item.MineAmmo = %numPack;
			}
			else if(%i == 6) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else if(%i == 7) {
			%item.Doomammo = %numPack;		
			}
			else if(%i == 8) {
			%item.SluggardAmmo = %numPack;		
			}
	else {
	 	    	%item.SniperRounds = %numPack;
			}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 10 ; %i = %i +1) {
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
//-------------------------

ItemImageData PortaGenImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = true;
};

ItemData PortaGen
{
	description = "Erector Generator";
	shapeFile = "generator_p";
	className = "Backpack";
 heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = PortaGenImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function PortaGen::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PortaGen::onDeploy(%player,%item,%pos)
{
	if (PortaGen::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function PortaGen::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%pteam = GameBase::getTeam(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%pgen = 
newObject("PortaGen","StaticShape","PortGenerator",true);
                               addToSet("MissionGroup\\Teams\\team" @ %pteam, %pgen);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%pgen,GameBase::getTeam(%player));
						GameBase::setPosition(%pgen,$los::position);
						GameBase::setRotation(%pgen,%rot);
						Gamebase::setMapName(%pgen,%name);
						Client::sendMessage(%client,0,"Empire Portable Generator deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%pgen) @ "PortaGen"]++;
						echo("MSG: ",%client," deployed a Portable Generator");
						GameBase::setActive(%pgen,true);

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
//-------------------------

ItemImageData DeployableWallImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableWall
{
	description = "Erector Wall";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableWallImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableWall::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableWall::onDeploy(%player,%item,%pos)
{
	if (DeployableWall::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableWall::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%wall = 
newObject("DeployableWall","StaticShape","TheWall",true);
	 		         addToSet("MissionCleanup", %wall);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%wall,GameBase::getTeam(%player));
						GameBase::setPosition(%wall,$los::position);
						GameBase::setRotation(%wall,%rot);
						Gamebase::setMapName(%wall,%name);
						Client::sendMessage(%client,0,"Empire Wall deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%wall) @ "DeployableWall"]++;
						echo("MSG: ",%client," deployed a Wall");
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

function DeployableWall::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableWall"]--;
}	

function PortaGen::onDestroyed(%this)
{
	Generator::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "PortaGen"]--;
}	

//----------------------------------------------------------------------------

ItemImageData DeployableTreeImage
{
	shapeFile = "tree1";
 	mountPoint = 2;
  	mountOffset = { 0, 0.15, -1 };
        mountRotation = { 0.1, 0, 0 };
	firstPerson = true;
};

ItemData DeployableTree
{
	description = "Vandal Hologram";
  	shapeFile = "tree1";
  	className = "Backpack";
   heading = "dDeployables";
	imageType = DeployableTreeImage;
  	shadowDetailMask = 4;
        mass = 1;
	elasticity = 0.2;
  	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = false;
};

function DeployableTree::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	%rate = Player::getSensorSupression(%player) + 15;
	Player::setSensorSupression(%player,%rate);
}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableTree::onDeploy(%client,%item)
{	%player = Client::getOwnedObject(%client);
	Player::dropItem(%client,%item);
	%rate = Player::getSensorSupression(%player) - 15;
	if	(%rate << 0) 
	{Player::setSensorSupression(%player, 0);}
	else 
	Player::setSensorSupression(%player,%rate);
}
//--------
//function DeployableTree::onDrop(%client, %item)
//{
//%player = Client::getOwnedObject(%client);
//%rate = Player::getSensorSupression(%player) - 15;
// Player::setSensorSupression(%player,%rate); 
//return %obj;
//}

function DeployableTree::onUnmount(%player,%item)
{
	%rate = Player::getSensorSupression(%player) - 15;
 				Player::setSensorSupression(%player,%rate); 
}
//---------

//puppy
							
ItemImageData SatelliteImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};


ItemData Satellite
{
	description = "Arbiter Satellite";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = SatelliteImage;
	shadowDetailMask = 4;
	mass = 0.0;
	elasticity = 0.2;
	price = 1;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Satellite::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
		}
}


function Satellite::onDeploy(%player,%item,%pos)
{
//GameBase::playSequence(%this,1,"deploy");
//GameBase::setActive(%this,true);
//GameBase::setRechargeRate(%this,5);
//GameBase::setActive(%this,true);

	if (Satellite::deployShape(%player,%item)) {
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

function Satellite::deployShape(%player,%item)
{
	%player.hasapuppy = 1;	
%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
							%turret = newObject("SatTurret","Turret",SatTurret,true);
	                     addToSet("MissionCleanup", %turret);
				%spawnMarker = GameBase::getPosition(%player);
				%rotMarker = GameBase::getRotation(%player);
   %xPos = getWord(%spawnMarker, 0) + floor(getRandom() * 5);
   %yPos = getword(%spawnMarker, 1) + floor(getRandom() * 2);
   %zPos = getWord(%spawnMarker, 2) + 290;
//   %rPos = GameBase::getRotation(%player);
	%xRot = getWord(%rotMarker, 0);
   %zRot = getword(%rotMarker, 2);
   %yRot = -3.13;
	%panelzPos = getWord(%spawnMarker, 2) + 291.5;
	%panelyRot = (-1 * getWord(%rotMarker, 0));
	%panelxRot = -1.5;
	%commzPos = getWord(%spawnMarker, 2) + 290.5;
	%pteam = GameBase::getTeam(%player);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
GameBase::setPosition(%turret,%xPos @ " " @ %yPos @ " " @ %zPos);

//					GameBase::setRotation(%turret,%rPos);
GameBase::setRotation(%turret,%xRot @ " " @ %yRot @ " " @ %zRot);
								Gamebase::setMapName(%turret,"Satellite#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Satellite launched.");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "Satellite"]++;
								echo("MSG: ",%client," launched a Remote Satellite");
						      Client::setOwnedObject(%client, %turret);
						      Client::setOwnedObject(%client, %player);
GameBase::setActive(%turret,true);

						%comm = 
newObject("CommandStation","StaticShape","CommandStation",true);
                               addToSet("MissionGroup\\Teams\\team" @ %pteam, %comm);
//						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%comm,GameBase::getTeam(%player));
						GameBase::setPosition(%comm,%xPos @ " " @ %yPos @ " " @ %commzPos);
						GameBase::setRotation(%comm,%xRot @ " " @ %PanelyRot @ " " @ %zRot);
//						Gamebase::setMapName(%comm,%name);
					GameBase::setActive(%comm,true);
						%spanel = 
newObject("SolarPanel","StaticShape","SolarPanel",true);
                               addToSet("MissionGroup\\Teams\\team" @ %pteam, %spanel);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%spanel,GameBase::getTeam(%player));
						GameBase::setPosition(%spanel,%xPos @ " " @ %yPos @ " " @ %panelzPos);
						GameBase::setRotation(%spanel,%panelxRot @ " " @ %PanelyRot @ " " @ %zRot);
//						Gamebase::setMapName(%spanel,%name);
						Client::sendMessage(%client,0,"Arbiter Satellite deployed overhead.");
//			playSound(SoundPickupBackpack,$los::position);
		
						echo("MSG: ",%client," deployed a Satellite");
						GameBase::setActive(%spanel,true);


								return true;
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


//------------------------

ItemImageData DeployableNestImage
{
	shapeFile = "cactus3";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.3 };
	mountRotation = { 0, 1.8, -1.5};
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableNest
{
	description = "Nest";
	shapeFile = "cactus3";
	className = "Backpack";
   heading = "dDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableNestImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableNest::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableNest::onDeploy(%player,%item,%pos)
{
	if (DeployableNest::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function newnest(%client)
{
%player = Client::getOwnedObject(%client);
%item = DeployableNest;
%armor = Player::getArmor(%client);
%mounted = Player::getMountedItem(%player,$BackpackSlot);
if(%armor == "qarmor")	
{
	Player::setItemCount(%player,%item,1);
	Player::mountItem(%player,%item,$BackpackSlot);
	client::sendMessage(%client, 0, "You have grown a new Nest. ~wError_Message.wav");
}
}

function Nest::onDrop(%player,%item)
{
	if($matchStarted) {
//		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (Player::isDead(%player)) 
			{
					%nest = newObject("DeployableNest","StaticShape",TheNest,true);
	                     addToSet("MissionCleanup", %nest);
				%spawnMarker = GameBase::getPosition(%player);
				%rotMarker = GameBase::getRotation(%player);
   %xPos = getWord(%spawnMarker, 0) + floor(getRandom() * 2);
   %yPos = getword(%spawnMarker, 1) + floor(getRandom() * 1);
   %zPos = getWord(%spawnMarker, 2) + floor(getRandom() * 1);
   %rPos = GameBase::getRotation(%player);
	%xRot = getWord(%rotMarker, 0);
	%yRot = getWord(%rotMarker, 1);
	%zRot = getWord(%rotMarker, 1);
%pteam = GameBase::getTeam(%player);
GameBase::setTeam(%nest,GameBase::getTeam(%player));
GameBase::setPosition(%nest,%xPos @ " " @ %yPos @ " " @ %zPos);
GameBase::setRotation(%nest,%xRot @ " " @ %yRot @ " " @ %zRot);
Gamebase::setMapName(%nest,%name);
	Client::sendMessage(%client,0,"Nest Spawned.");
	playSound(SoundPickupHealth,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "DeployableNest"]++;
	echo("MSG: ",%client," dropped a nest in death");
	schedule("nestduplicate(" @ %nest @ ");", 5, %nest);
	schedule("newnest(" @ %client @ ");", 30, %client);

	}
		else
			{
			bottomprint(%client, "You must deploy your Nest using P.");
			}
//	Item::onDrop(%player,%item);
	}
}	


function DeployableNest::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,8)) {
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
				%spawnMarker = $los::position;
   %xPos = getWord(%spawnMarker, 0);
   %yPos = getword(%spawnMarker, 1);
   %zPos = getWord(%spawnMarker, 2);
GameBase::setPosition(%turret,%xPos @ " " @ %yPos @ " " @ %zPos);
				if(NestcheckDeployArea(%client,%xPos @ " " @ %yPos @ " " @ %zPos)) {
					%nest = newObject("DeployableNest","StaticShape",TheNest,true);
	   	      addToSet("MissionCleanup", %nest);
					GameBase::setTeam(%nest,GameBase::getTeam(%player));
					GameBase::setRotation(%nest,%rot);
					GameBase::setPosition(%nest,%xPos @ " " @ %yPos @ " " @ %zPos);
					Client::sendMessage(%client,0,"Nest spawned");
					playSound(SoundPickupHealth,$los::position);
					$TeamItemCount[GameBase::getTeam(%nest) @ "DeployableNest"]++;
						bottomprint(%client, "The Nest will give Larvae and Health to Insatiables and will infect enemies with parasites.\nIt is destroyable, but very tough.");
GameBase::setAutoRepairRate(%nest,0.1);
Gamebase::setMapName(%nest,"Nest");
schedule("newnest(" @ %client @ ");", 30, %client);

					echo("MSG: ",%client," spawned a Nest");
	schedule("nestduplicate(" @ %nest @ ");", 5, %nest);

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


function NestcheckDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,5,5,5,5);
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




function DeployableNest::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "DeployableNest"]--;
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



//cloak

ItemImageData CloakImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 9;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData Cloak
{
	description = "Cloaking Pack";
	shapeFile = "shieldpack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakImage;
	price = 750;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakImage::onActivate(%player,%imageSlot)
{
%client = Player::getclient(%player);

	Client::sendMessage(Player::getClient(%player),0,"Cloaking On");
//	%player.shieldStrength = 0.012;
//        schedule("Item::hide(" @ %this @ ",true); 
		  GameBase::startFadeOut(%player);
// startGhosting(%client);  
//%client.noghost = false;	
}

function CloakImage::onDeactivate(%player,%imageSlot)
{
%client = Player::getclient(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Off");
	Player::trigger(%player,$BackpackSlot,false);
//	%player.shieldStrength = 0;
//        schedule("Item::hide(" @ %this @ ",false); 
	  GameBase::startFadeIn(%player);
//	   %client.noghost = true;

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
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//----------------------------------------------------------------------------
ItemData nestdeathtracker
{
	className = "HandAmmo";
   mass = 25;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.0;
	friction = 1.0;

   description = "NestDeath marker";
   shapeFile = "grenade";
   shadowDetailMask = 4;
};


//-----
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
//instance 18
//messageall(0, "using test instance 18");
//echo("MSG: using instance18");
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
	$TeamItemCount[0 @ EmpireTank] = 0;
	$TeamItemCount[0 @ VandalInterceptor] = 0;
	$TeamItemCount[0 @ DeployableWall] = 0;
	$TeamItemCount[0 @ PortaGen] = 0;
	$TeamItemCount[0 @ ArbiterPod] = 0;
	$TeamItemCount[0 @ DeployableTree] = 0;
	$TeamItemCount[0 @ GrandMantle] = 0;
	$TeamItemCount[0 @ DeathTouch] = 0;
	$TeamItemCount[0 @ DeployableNest] = 0;
      $TeamItemCount[0 @ Larva] = 0;
	$TeamItemCount[0 @ Satellite] = 0;	
	$TeamItemCount[0 @ Buddy] = 0;

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
	$TeamItemCount[1 @ EmpireTank] = 0;
	$TeamItemCount[1 @ VandalInterceptor] = 0;
	$TeamItemCount[1 @ DeployableWall] = 0;
	$TeamItemCount[1 @ PortaGen] = 0;
	$TeamItemCount[1 @ ArbiterPod] = 0;
	$TeamItemCount[1 @ DeployableTree] = 0;
	$TeamItemCount[1 @ GrandMantle] = 0;
	$TeamItemCount[1 @ DeathTouch] = 0;
	$TeamItemCount[1 @ DeployableNest] = 0;
      $TeamItemCount[1 @ Larva] = 0;
      $TeamItemCount[1 @ Satellite] = 0;	
	$TeamItemCount[1 @ Buddy] = 0;


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
	$TeamItemCount[2 @ EmpireTank] = 0;
	$TeamItemCount[2 @ VandalInterceptor] = 0;
	$TeamItemCount[2 @ DeployableWall] = 0;
	$TeamItemCount[2 @ PortaGen] = 0;
	$TeamItemCount[2 @ ArbiterPod] = 0;
	$TeamItemCount[2 @ DeployableTree] = 0;
	$TeamItemCount[2 @ GrandMantle] = 0;
	$TeamItemCount[2 @ DeathTouch] = 0;
	$TeamItemCount[2 @ DeployableNest] = 0;
      $TeamItemCount[2 @ Larva] = 0;
      $TeamItemCount[2 @ Satellite] = 0;	
	$TeamItemCount[2 @ Buddy] = 0;


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
	$TeamItemCount[3 @ EmpireTank] = 0;
	$TeamItemCount[3 @ VandalInterceptor] = 0;
	$TeamItemCount[3 @ DeployableWall] = 0;
	$TeamItemCount[3 @ PortaGen] = 0;
	$TeamItemCount[3 @ ArbiterPod] = 0;
	$TeamItemCount[3 @ DeployableTree] = 0;
	$TeamItemCount[3 @ GrandMantle] = 0;
	$TeamItemCount[3 @ DeathTouch] = 0;
	$TeamItemCount[3 @ DeployableNest] = 0;
      $TeamItemCount[3 @ Larva] = 0;
	$TeamItemCount[3 @ Satellite] = 0;	
	$TeamItemCount[3 @ Buddy] = 0;


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
	$TeamItemCount[4 @ EmpireTank] = 0;
	$TeamItemCount[4 @ VandalInterceptor] = 0;
	$TeamItemCount[4 @ DeployableWall] = 0;
	$TeamItemCount[4 @ PortaGen] = 0;
	$TeamItemCount[4 @ ArbiterPod] = 0;
	$TeamItemCount[4 @ DeployableTree] = 0;
	$TeamItemCount[4 @ GrandMantle] = 0;
	$TeamItemCount[4 @ DeathTouch] = 0;
	$TeamItemCount[4 @ DeployableNest] = 0;
      $TeamItemCount[4 @ Larva] = 0;
	$TeamItemCount[4 @ Satellite] = 0;	
	$TeamItemCount[4 @ Buddy] = 0;


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
	$TeamItemCount[5 @ EmpireTank] = 0;
	$TeamItemCount[5 @ VandalInterceptor] = 0;
	$TeamItemCount[5 @ DeployableWall] = 0;
	$TeamItemCount[5 @ PortaGen] = 0;
	$TeamItemCount[5 @ ArbiterPod] = 0;
	$TeamItemCount[5 @ DeployableTree] = 0;
	$TeamItemCount[5 @ GrandMantle] = 0;
	$TeamItemCount[5 @ DeathTouch] = 0;
	$TeamItemCount[5 @ DeployableNest] = 0;
      $TeamItemCount[5 @ Larva] = 0;
	$TeamItemCount[5 @ Satellite] = 0;	
	$TeamItemCount[5 @ Buddy] = 0;


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
	$TeamItemCount[6 @ EmpireTank] = 0;
	$TeamItemCount[6 @ VandalInterceptor] = 0;
	$TeamItemCount[6 @ DeployableWall] = 0;
	$TeamItemCount[6 @ PortaGen] = 0;
	$TeamItemCount[6 @ ArbiterPod] = 0;
	$TeamItemCount[6 @ DeployableTree] = 0;
	$TeamItemCount[6 @ GrandMantle] = 0;
	$TeamItemCount[6 @ DeathTouch] = 0;
	$TeamItemCount[6 @ DeployableNest] = 0;
      $TeamItemCount[6 @ Larva] = 0;
	$TeamItemCount[6 @ Satellite] = 0;	
	$TeamItemCount[6 @ Buddy] = 0;


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
	$TeamItemCount[7 @ EmpireTank] = 0;
	$TeamItemCount[7 @ VandalInterceptor] = 0;
	$TeamItemCount[7 @ DeployableWall] = 0;
	$TeamItemCount[7 @ PortaGen] = 0;
	$TeamItemCount[7 @ ArbiterPod] = 0;
	$TeamItemCount[7 @ DeployableTree] = 0;
	$TeamItemCount[7 @ GrandMantle] = 0;
	$TeamItemCount[7 @ DeathTouch] = 0;
	$TeamItemCount[7 @ DeployableNest] = 0;
      $TeamItemCount[7 @ Larva] = 0;
	$TeamItemCount[7 @ Satellite] = 0;	
	$TeamItemCount[7 @ Buddy] = 0;


	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}


//function itemhelper()
//{	%max = getnumitems();
//	for (%c = 2049; %c < 2066; %c = %c + 1)
//	{
//		for (%i = 0; %i < %max; %i = %i + 1)
//	 	{	%item = getItemData(%i);
//			messageall(0, "the " @ %item @ " is #" @ %i @ " and the p //has " @ Player::getitemcount(%c, %item));
//		
//		}
//	}
//}
