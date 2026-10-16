//----------------------------------------------------------------------------

$ItemFavoritesKey = "Ideal";  // Change this if you add new items
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

//Modified Stuff:

$ArmorType[Male, BuildingArmor] = scvarmor;
$ArmorType[Female, BuildingArmor] = scvarmor;
$ArmorName[scvarmor] = BuildingArmor;



$ArmorType[Male, TransformerArmor] = tarmor;
$ArmorType[Female, TransformerArmor] = tarmor;
$ArmorName[tarmor] = TransformerArmor;


//$ArmorType[Male, SecretAgentManArmor] = aarmor;
//$ArmorType[Female, SecretAgentManArmor] = aarmor;
//$ArmorName[aarmor] = SecretAgentManArmor;

$AutoUse[LaserChaingun] = True;
$WeaponAmmo[LaserChaingun] = "";

$AutoUse[SlowGun] = True;
$WeaponAmmo[SlowGun] = "SlowGunAmmo";
$AmmoPackMax[SlowGunAmmo] = 15;
$SellAmmo[SlowGunAmmo] = 5;
$AmmoPackItems[8] = SlowGunAmmo;

$AutoUse[Concuss] = True;
$WeaponAmmo[Concuss] = "ConcussAmmo";
$AmmoPackMax[ConcussAmmo] = 15;
$SellAmmo[ConcussAmmo] = 5;
$AmmoPackItems[9] = ConcussAmmo;

$ArmorType[Male, SpecialistArmor] = sarmor;
$ArmorType[Female, SpecialistArmor] = sarmor;
$ArmorName[sarmor] = SpecialistArmor;

$AutoUse[Cloaker] = True;
$WeaponAmmo[Cloaker] = "";

$TeamItemMax[NuclearTurretPack] = 1;

$TeamItemMax[ArbitorBoxPack] = 1;

$TeamItemMax[FlameTurretPack] = 2;

$TeamItemMax[ObeliskPack] = 2;

$TeamItemMax[ObeliskPowerPack] = 2;

$TeamItemMax[SuperSensorPack] = 2;

$AmmoPackMax[HandgrenadeAmmo] = 10;
$AmmoPackItems[10] = HandgrenadeAmmo;

$AmmoPackMax[C4Ammo] = 5;
$AmmoPackItems[11] = C4Ammo;

$AutoUse[Marlin] = True;
$WeaponAmmo[Marlin] = "MarlinAmmo";
$AmmoPackMax[MarlinAmmo] = 30;
$SellAmmo[MarlinAmmo] = 8;
$AmmoPackItems[12] = ConcussAmmo;

$AmmoPackMax[FlashgrenadeAmmo] = 18;
$AmmoPackItems[13] = FlashgrenadeAmmo;

$AmmoPackMax[StungrenadeAmmo] = 6;
$AmmoPackItems[14] = StungrenadeAmmo;

$Grenade[0] = 5;
$Grenade[1] = C4Ammo;
$Grenade[2] = HandgrenadeAmmo;
$Grenade[3] = FlashgrenadeAmmo;
$Grenade[4] = StungrenadeAmmo;
$Grenade[5] = SuicideAmmo;


$AmmoPackMax[OriginalMine] = 6;
$AmmoPackItems[15] = OriginalMine;
$TeamItemMax[OriginalMine] = 35;

$TeamItemMax[ReplicatingMine] = 35;

$TeamItemMax[FlagMine] = 5;

$Mine[0] = 3;
$Mine[1] = OriginalMine;
$Mine[2] = ReplicatingMine;
$Mine[3] = FlagMine;

//End Mod



$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;


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
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
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

//mod:
$TeamItemMax[JetFireVechicle] = 4;


$TeamItemMax[Beacon] = 40;

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
$WeaponAmmo[Mortar] = MortarAmmo;
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
			%max = getNumItems2();
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
		if (%item.className == Armor)
		{
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)
			{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1))
				{
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
     					Player::setItemCount(%client, $ArmorName[%armor], 0);  
	     				Player::setItemCount(%client, %item, 1);  
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						fillAmmoPack(%client);

					if(%buyarmor == SCVArmor)
					{
						Player::setItemCount(%client, SCVPack, 1);
						Player::mountItem(%client, SCVPack, $BackpackSlot);
						Player::setItemCount(%client, SCVGun, 1);
						Player::mountItem(%client, SCVGun, $WeaponSlot);
					}
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack)
		{
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack)
				{
					if(Player::getItemCount(%client,"LaserRifle") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						Player::decItemCount(%client,"LaserRifle");
						%gun=LaserRifle;
						teamEnergyBuySell(%player, %gun.price);
					}
//mod:
					if(Player::getItemCount(%client,"LaserChaingun") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Chaingun");
						Player::decItemCount(%client,"LaserChaingun");
						%gun=LaserChaingun;
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
		else if(%item.className == Weapon)
		{
			if(checkResources(%player,%item,1))
			{
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					if(Player::getArmor(%client) != tarmor)
						Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
//mod:
				if(%item == LaserChaingun && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Chaingun - Auto buying Energy Pack");
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
	 	else if(%item.className == Vehicle)
		{
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
//mod:
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
		else if(%item.className == Tool)
		{
			if(checkResources(%player,%item,1))
			{
				if(%item == RealTargetingLaser)
				{
					teamEnergyBuySell(%player, TractorBeam.price * Player::getItemCount(%player, TractorBeam));
					Player::setItemCount(%player, TractorBeam, 0);
				}
				else if(%item == TractorBeam)
				{
					teamEnergyBuySell(%player, RealTargetingLaser.price * Player::getItemCount(%player, TargetingLaser));
					Player::setItemCount(%player, RealTargetingLaser, 0);
				}
				Player::incItemCount(%client, %item);
				teamEnergyBuySell(%player, (%item.price * -1));
				Player::setItemCount(%client, TargetingLaser, 1);
				return 1;
			}
		}
		else
		{
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
		    %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			 if(%delta || $testCheats)
			{
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

	if(%item == EnergyRifle || %item == shortEnergyRifle || %item == longEnergyRifle)
	{
		%player.justUsedELF = 0; //otherwise you get a new elf if you go to the inv with it mounted
		Player::unMountItem(%client, $WeaponSlot);

		if(%item != EnergyRifle)
		{
			Player::setItemCount(%client, %item, 0);
			Player::setItemCount(%client, EnergyRifle, 1);
			%item = EnergyRifle;
		}
	}


	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats)
	{
		if(%item == FlagMovePack)
		{
			if(%client.moveFlag)
				%client.moveFlag = 0; //can't move flag after dropping it

			if(Player::getMountedItem(%player, $FlagSlot) == Flag)
			{
				Client::sendMessage(%client, 0, "You cannot sell the Flag Movement Pack while moving your flag.");
				return;
			}
		}

		if(Player::getItemCount(%client,%item) && %item.className != Armor)
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
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "")
			{
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == EnergyPack)
			{
				if(Player::getItemCount(%client,"LaserRifle") > 0)
				{
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					Player::decItemCount(%client,"LaserRifle");
					%gun=LaserRifle;
					teamEnergyBuySell(%player, %gun.price);
				}
//mod:
				if(Player::getItemCount(%client,"LaserChaingun") > 0)
				{
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Chaingun");
					Player::decItemCount(%client,"LaserChaingun");
					%gun=LaserChaingun;
					teamEnergyBuySell(%player, %gun.price);
				}

			}
			else if(%item.className == Grenade)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, Grenade, %numsell);
			}
			else if(%item.className == Mine)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, MineAmmo, %numsell);
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
//mod:

	if(%item == SuicideAmmo || %item == C4Ammo )
	{
		%client.throwStrength = 0;
		Player::useItem(%client, %item);
	}
	else if (%item.className == "Grenade" || %item.className == "HandAmmo" || %item.className == "Mine")
	{
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
		else if (%item == Ammo)
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon)
			{
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
		}
		else if(%item.className == Grenade)
		{
			Player::dropItem(%client,%item);
			Player::decItemCount(%client, Grenade, $SellAmmo[%item]);
		}
		else if(%item.className == Mine)
		{
			Player::dropItem(%client,%item);
			Player::decItemCount(%client, MineAmmo, $SellAmmo[%item]);
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

//mod:
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = EnergyRifle;
$NextWeapon[shortEnergyRifle] = LaserChaingun;
$NextWeapon[EnergyRifle] = LaserChaingun;
$NextWeapon[longEnergyRifle] = LaserChaingun;
$NextWeapon[LaserChaingun] = "Marlin";
$NextWeapon["Marlin"] = SlowGun;
$NextWeapon[SlowGun] = Concuss;
$NextWeapon[Concuss] = Cloaker;
$NextWeapon[Cloaker] = Blaster;


$PrevWeapon[Blaster] = Cloaker;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[shortEnergyRifle] = LaserRifle;
$PrevWeapon[EnergyRifle] = LaserRifle;
$PrevWeapon[longEnergyRifle] = LaserRifle;
$PrevWeapon[LaserChaingun] = EnergyRifle;
$PrevWeapon["Marlin"] = LaserChaingun;
$PrevWeapon[SlowGun] = "Marlin";
$PrevWeapon[Concuss] = SlowGun;
$PrevWeapon[Cloaker] = Concuss;


function remoteNextWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
		selectValidWeapon(%client);
	else
	{
		for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				if (%weapon == EnergyRifle && (Player::getMountedItem(%client,$WeaponSlot) == shortEnergyRifle || Player::getMountedItem(%client, $WeaponSlot) == longEnergyRifle))
					break; //mounting ELF will not have EnergyRifle mounted if using long/short range versions
echo("Did not mount... Mounted Item is: " @ Player::getMountedItem(%client, $WeaponSlot) @ " but wanted it to be " @ %weapon);
			}
		}
	}
	Client::centerPrint(%weapon, 1);
	$guns++;
	schedule("clearPrint();", 2);
}

function clearPrint()
{
	$guns--;
	if($guns==0)
		Client::centerPrint("", 1);
}

function remotePrevWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $PrevWeapon[%item] == "")
		selectValidWeapon(%client);
	else
	{
		for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				if (%weapon == EnergyRifle && (Player::getMountedItem(%client,$WeaponSlot) == shortEnergyRifle || Player::getMountedItem(%client, $WeaponSlot) == longEnergyRifle))
					break; //mounting ELF will not have EnergyRifle mounted if using long/short range versions
echo("Did not mount... Mounted Item is: " @ Player::getMountedItem(%client, $WeaponSlot) @ " but wanted it to be " @ %weapon);
			}
		}
	}
	Client::centerPrint(%weapon, 1);
	$guns++;
	schedule("clearPrint();", 2);
}

function selectValidWeapon(%client)
{
	%item = cloaker; //changed to allow multiple energy rifle types
	for (%weapon = $NextWeapon[%item]; %cycle != 2; %weapon = $NextWeapon[%weapon])//made %cycle so that it selects elf as first gun too
	{
		if (isSelectableWeapon(%client,%weapon))
		{
			Player::useItem(%client,%weapon);
			break;
		}
		if(%weapon == %item)
			%cycle++;
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if (Player::getItemCount(%client,%weapon))
	{
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
	if($ItemMax[%armor, %item])
	{		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack)
		{
			// Only one backpack per armor, and it's always mounted
			if (Player::getMountedItem(%player,$BackpackSlot) == -1)
			{
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item.description);
		 		return 1;
			}
		}
//mod:
		else if(%item.className == Grenade)
		{
			if(Player::getItemCount(%player, Grenade) == Player::getItemCount(%player, %item))
			{
				%count = Player::getItemCount(%player, %item);
				%total = $ItemMax[%armor, %item];
				%extra = %total - %count;
				if(%delta > %extra)
					%delta = %extra;
				if(%delta > 0)
				{
					Player::incItemCount(%player, %item, %delta);
					Player::incItemCount(%player, Grenade, %delta);
					Client::sendMessage(%client, 0, "You received " @ %delta @ " " @ %item.description);
					return %delta;
				}
			}
		}
		else if(%item.className == Mine)
		{
			if(Player::getItemCount(%player, MineAmmo) == Player::getItemCount(%player, %item))
			{
				%count = Player::getItemCount(%player, %item);
				%total = $ItemMax[%armor, %item];
				%extra = %total - %count;
				if(%delta > %extra)
					%delta = %extra;
				if(%delta > 0)
				{
					Player::incItemCount(%player, %item, %delta);
					Player::incItemCount(%player, MineAmmo, %delta);
					Client::sendMessage(%client, 0, "You received " @ %delta @ " " @ %item.description);
					return %delta;
				}
			}
		}
		else if(%item.className == Tool)
		{
			if(%item == RealTargetingLaser && Player::getItemCount(%player, TractorBeam))
				return 0;
			if(%item == TractorBeam && Player::getItemCount(%player, RealTargetingLaser))
				return 0;
			if(Player::getItemCount(%item))
				return 0;

			Player::setItemCount(%player, %item, 1);
			Client::sendMessage(%client, 0, "You received a " @ %item.description @ ".");
			return 1;
		}
  		else
		{
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon)
			{
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
			if (%delta > 0)
			{
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
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
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

//mod stuff

ItemData SpecialistArmor
{
   heading = "aArmor";
	description = "Specialist Armor";
	className = "Armor";
	price = 600;
};

//ItemData SecretAgentManArmor
//{
//   heading = "aArmor";
//	description = "Secret Agent Man";
//	className = "Armor";
//	price = 1000;
//};


//end mod


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

//more mod
ItemData TransformerArmor
{
   heading = "aArmor";
	description = "Transformer Armor";
	className = "Armor";
	price = 1000;
};

ItemData BuildingArmor
{
   heading = "aArmor";
	description = "SCV Armor";
	className = "Armor";
	price = 1500;
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

ItemData JetFireVehicle
{
	description = "JetFire";
	className = "Vehicle";
//   heading = "aVehicle";
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
	%client = Player::getClient(%player);

	if(%player.justUsedELF == 1 && %item != %client.elfVersion) //just used elf & not using it now
	{
		Player::setItemCount(%client, shortEnergyRifle, 0);
		Player::setItemCount(%client, longEnergyRifle, 0);
		Player::setItemCount(%client, EnergyRifle, 1);
		%player.justUsedELF = 0;
	}

	%ammo = %item.imageType.ammoType;
	if (%ammo == "") {
		// Energy weapons dont have ammo types
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else {
		if (Player::getItemCount(%player,%ammo) > 0) 
			Player::mountItem(%player,%item,$WeaponSlot);
		else {
			Client::sendMessage(%client,0, strcat(%item.description," has no ammo"));
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
	if(%player.justUsedELF == 1 && %item != %client.elfVersion) //just used elf & not using it now
	{
		Player::setItemCount(%client, shortEnergyRifle, 0);
		Player::setItemCount(%client, longEnergyRifle, 0);
		Player::setItemCount(%client, EnergyRifle, 1);
		%player.justUsedELF = 0;
	}

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

	//projectileType = BlasterBolt;
	accuFire = true;

	//sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

//mod:

function BlasterImage::onFire(%this,%slot)
{
	%client = GameBase::getOwnerClient(%this);
	if(%client.overloadblaster == 4) //in between modes
	{
		Client::sendMessage(%client, 0, "Please wait...");
		playSound(SoundAccessDenied,GameBase::getPosition(%this));
		return;
	}

	if(%client.overloadblaster == 0)
	{
		if(GameBase::getEnergy(%this) > BlasterImage.maxEnergy)
		{
			playSound(SoundFireBlaster,GameBase::getPosition(%this));

			GameBase::setEnergy(%this, GameBase::getEnergy(%this) - BlasterImage.minEnergy);
			%Trans = GameBase::getMuzzleTransform(%this);
			%ShootVel = Item::getVelocity(%this);

			Projectile::spawnProjectile("BlasterBolt", %Trans, %this, %ShootVel);
		}
		else
			playSound(SoundGunEmpty,GameBase::getPosition(%this));
	}
	else
	{
		%armor = Player::getArmor(%this);
		if(GameBase::getEnergy(%this) == %armor.maxEnergy) //must have full energy to fire
		{
			playSound(SoundPlasmaTurretFire,GameBase::getPosition(%this));

			GameBase::setEnergy(%this, 0);
			%Trans = GameBase::getMuzzleTransform(%this);
			%ShootVel = Item::getVelocity(%this);

			Projectile::spawnProjectile("SuperBlasterBolt", %Trans, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) @ " " @ getWord(%Trans, 4) @ " " @ getWord(%Trans, 5) - 0.1 @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8) ;
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) @ " " @ getWord(%Trans, 4) @ " " @ getWord(%Trans, 5) + 0.1 @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8) ;
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) @ " " @ getWord(%Trans, 4) - 0.1 @ " " @ getWord(%Trans, 5) @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8);
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) @ " " @ getWord(%Trans, 4) + 0.1 @ " " @ getWord(%Trans, 5) @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8);
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) - 0.1 @ " " @ getWord(%Trans, 4) @ " " @ getWord(%Trans, 5) @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8);
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) + 0.1 @ " " @ getWord(%Trans, 4) @ " " @ getWord(%Trans, 5) @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8);
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);



			%rand = floor(getRandom() * 5);

			if(%rand)
			{
				schedule("BlasterImage::melt(" @ %client @ ");", 0.4, %this);
			}
		%client.overloadblaster = 0;
		}
		else
			playSound(SoundGunEmpty,GameBase::getPosition(%this));

	}
}

function BlasterImage::melt(%client)
{
	Player::decItemCount(%client, Blaster);
	Client::sendMessage(%client, 1, "The Blaster melted when firing.");
}

//end mod
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
//	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.005;
	fireTime = 0.05;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

//	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundDryFire;
};

function PlasmaGunImage::onFire(%this,%slot)
{
	%ammo = Player::getItemCount(%this, PlasmaAmmo);
	%client = GameBase::getOwnerClient(%this);

	%client.thisFireTime = getSimTime();
	if(%client.plasmaType == "PlasmaBolt" && %client.thisFireTime < %client.lastFireTime + 1.0)
		return;

	if(%ammo > 0)
	{
		Player::decItemCount(%this, PlasmaAmmo);
		%Trans = GameBase::getMuzzleTransform(%this);
		%ShootVel = Item::getVelocity(%this);
		if(%client.plasmaType == "")
			%client.plasmaType = "PlasmaBolt";

		Projectile::spawnProjectile(%client.plasmaType, %Trans, %this, %ShootVel);
		%client.lastFireTime = %client.thisFireTime;
		playSound(SoundFirePlasma,GameBase::getPosition(%this));
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
}


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
//	projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

//	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function GrenadeLauncherImage::onFire(%this,%slot)
{
	%ammo = Player::getItemCount(%this, GrenadeAmmo);
	%client = GameBase::getOwnerClient(%this);
	if(%ammo > 0)
	{
		Player::decItemCount(%this, GrenadeAmmo);
		%Trans = GameBase::getMuzzleTransform(%this);
		%ShootVel = Item::getVelocity(%this);
		if(%client.grenType == "")
			%client.grenType = "GrenadeShell";
		Projectile::spawnProjectile(%client.grenType, %Trans, %this, %ShootVel);
		playSound(SoundFireGrenade,GameBase::getPosition(%this));
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
}


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
	//projectileType = MortarShell;
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

//mod:

function MortarImage::onFire(%this,%slot)
{
	%ammo = Player::getItemCount(%this, MortarAmmo);
	if(%ammo > 0)
	{
		Player::decItemCount(%this, MortarAmmo);
		%client = GameBase::getOwnerClient(%this);
		%Trans = GameBase::getMuzzleTransform(%this);
		%ShootVel = Item::getVelocity(%this);
		if(%client.mortarShell == "")
			%client.mortarShell = "mortarshell";

		Projectile::spawnProjectile(%client.mortarShell, %Trans, %this, %ShootVel);
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
}


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
	//projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	//sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

function DiscLauncherImage::onFire(%this,%slot)
{
	%ammo = Player::getItemCount(%this, DiscAmmo);
	%client = GameBase::getOwnerClient(%this);
	if(%ammo > 0)
	{
		Player::decItemCount(%this, DiscAmmo);
		%Trans = GameBase::getMuzzleTransform(%this);
		%ShootVel = Item::getVelocity(%this);
		GameBase::getLOSInfo(%this, 20);
		if(%client.discType == "Homing")
			Projectile::spawnProjectile("HomingDiscShell", %Trans, %this, %ShootVel, $los::object);
		else
			Projectile::spawnProjectile("DiscShell", %Trans, %this, %ShootVel);
		playSound(SoundFireDisc,GameBase::getPosition(%this));
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
	
}

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
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack || Player::getArmor(%player) == tarmor)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Laser Rifle."); 
}

//----------------------------------------------------------------------------
//Mod:




ItemImageData DeadWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = 50.0;
};

ItemData DeadWeight
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
   heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = DeadWeightImage;
	price = 0;
	showWeaponBar = false;
	mass = 50.0;
	showInventory = false;
};

function DeadWeight::onDrop(%player, %item)
{}

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
	mass = -7.0;
	showInventory = false;
};

function LessWeight2::onDrop(%player, %item)
{}

ItemImageData LessWeight3Image
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -11.0;
};

ItemData LessWeight3
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
   heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = LessWeight3Image;
	price = 0;
	showWeaponBar = false;
	mass = -11.0;
	showInventory = false;
};

function LessWeight3::onDrop(%player, %item)
{}

ItemImageData SCVGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = SCVProjectile;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.5;
	lightColor = { 0, 0, 0 };

	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SCVGun
{
	description = "Nanite Assembler";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SCVGunImage;
	price = 0;
	showWeaponBar = true;
};

function SCVGun::onDrop(%player, %item)
{
//do nothing
}

ItemData MarlinAmmo
{
	description = "Marlin Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};


ItemImageData MarlinImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//projectileType = Marlinshot;
	accuFire = true;
	ammoType = MarlinAmmo;
	reloadTime = 8;
	fireTime = 2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.5;
	lightColor = { 0, 0, 0 };

//	sfxFire = ricochet2;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Marlin
{
	description = "Marlin Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MarlinImage;
	price = 750;
	showWeaponBar = true;
};


function MarlinImage::onFire(%this,%slot)
{
	%ammo = Player::getItemCount(%this, MarlinAmmo);
	if(%ammo > 0)
	{
		if(%this.outArea==0)
		{
			Player::decItemCount(%this, MarlinAmmo);
			%client = GameBase::getOwnerClient(%this);
			%Trans = GameBase::getMuzzleTransform(%this);
			%ShootVel = Item::getVelocity(%this);
			Projectile::spawnProjectile("Marlinshot", %Trans, %this, %ShootVel);
			%obj = newObject("","Mine","SmokeGrenade");
	 		addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%this,"0 0 0",0);
			%gunPos = getWord(%trans, 9) @ " " @ getWord(%trans, 10) @ " " @ getWord(%trans, 11);
			GameBase::setPosition(%obj, %gunPos);
			playSound(ricochet2,GameBase::getPosition(%this));
		}
		else
			Client::sendMessage(Player::getClient(%this),0,"You have to be inside the mission area to fire the Marlin." @ "~wbutton1.wav"); 
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
}

ItemImageData LaserChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	projectileType = LaserChain;
	spinUpTime = 0.9;
	spinDownTime = 3;

	accuFire = false;
	reloadTime = 0;
	fireTime = 0.2;
	minEnergy = 5.0;
	maxEnergy = 5.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;

};

ItemData LaserChaingun
{
	description = "Laser Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserChaingunImage;
	price = 300;
	showWeaponBar = true;
};

function LaserChaingun::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have an Energy Pack to use a Laser Chaingun."); 
}

ItemData SlowGunAmmo
{
	description = "Mass Gun Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData SlowGunImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SlowGunAmmo;
	projectileType = SlowPod;
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

ItemData SlowGun
{
	description = "Mass Gun";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SlowGunImage;
	price = 250;
	showWeaponBar = true;
};

ItemData concussAmmo
{
	description = "Chaos Shots";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData concussImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = concussAmmo;
	//projectileType = concussShot;
	accuFire = false;
	reloadTime = 0.3;
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

function concussImage::onFire(%this, %slot)
{
	%ammo = Player::getItemCount(%this, concussAmmo);
	if(%ammo > 0)
	{
		Player::decItemCount(%this, concussAmmo);
		%client = GameBase::getOwnerClient(%this);
		%Trans = GameBase::getMuzzleTransform(%this);
		%ShootVel = Item::getVelocity(%this);
		if(%client.chaosShot == "") //first shot
			%client.chaosShot = "Concussshot";
		Projectile::spawnProjectile(%client.chaosShot, %Trans, %this, %ShootVel);
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
}

ItemData concuss
{
	description = "Chaos Gun";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = concussImage;
	price = 300;
	showWeaponBar = true;
};

ItemImageData CloakerImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained

	projectileType = cloakerbolt;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 1, 0 };

//	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;

};

ItemData Cloaker
{
	description = "Handheld Cloak";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "deployable";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = CloakerImage;
	price = 0;
	showWeaponBar = true;
};



//End Mod

ItemImageData TractorBeamImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetPull;
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



ItemData TractorBeam
{
	description   = "Tractor Beam";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "cTools";
	shadowDetailMask = 4;
	imageType     = TractorBeamImage;
	price         = 50;
	showWeaponBar = false;
};

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
   heading = "cTools";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
	showInventory = false;
};

function TargetingLaser::onUse(%player,%item)
{
	if(Player::getItemCount(%player, RealTargetingLaser))
		Tool::onUse(%player, RealTargetingLaser);
	else if(Player::getItemCount(%player, TractorBeam))
		Tool::onUse(%player, TractorBeam);
}



ItemImageData RealTargetingLaserImage
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



ItemData RealTargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "cTools";
	shadowDetailMask = 4;
	imageType     = RealTargetingLaserImage;
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

function EnergyRifle::onUse(%player, %item)
{
	%client = Player::getClient(%player);
	if(%client.elfVersion == "")
		%client.elfVersion = "EnergyRifle";

	if(%client.elfVersion == "EnergyRifle")
		Weapon::onUse(%player, %item);
	else
	{
		Player::setItemCount(%client, %client.elfVersion, 1);
		Player::setItemCount(%client, EnergyRifle, 0);
		%player.justUsedElf = 1;
		Weapon::onUse(%player, %client.elfVersion);
	}
}

//mod: allow for long/short range elf's

ItemImageData LongEnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = longlightningCharge;
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

ItemData LongEnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = longEnergyRifleImage;
	showWeaponBar = true;
   price = 125;
};

function LongEnergyRifle::onDrop(%player, %item)
{
	%player.justUsedELF = 0; //otherwise you get a new elf when changing weapons
	Player::unMountItem(%player, $WeaponSlot);

	Player::setItemCount(%player, %item, 0);
	Player::setItemCount(%player, EnergyRifle, 1);

	Weapon::onDrop(%player, EnergyRifle);
}


ItemImageData shortEnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = shortlightningCharge;
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

ItemData shortEnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = shortEnergyRifleImage;
	showWeaponBar = true;
   price = 125;
};

function shortEnergyRifle::onDrop(%player, %item)
{
	%player.justUsedELF = 0; //otherwise you get a new elf when changing weapons
	Player::unMountItem(%player, $WeaponSlot);

	Player::setItemCount(%player, %item, 0);
	Player::setItemCount(%player, EnergyRifle, 1);

	Weapon::onDrop(%player, EnergyRifle);
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
   heading = "eDeployables";
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
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%inv, 0.7 * DeployableInvStation.maxDamage);
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
   heading = "eDeployables";
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
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%inv, 0.7 * DeployableAmmoStation.maxDamage);
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
   heading = "dBackpacks";
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
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle || Player::getMountedItem(%player,$WeaponSlot) == LaserChaingun) 
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
   heading = "dBackpacks";
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
   heading = "dBackpacks";
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
   heading = "dBackpacks";
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

//begin mod
ItemImageData SCVPackImage
{
	shapeFile = "mortarammo";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData SCVPack
{
	description = "SCV Building Pack";
	shapeFile = "mortarammo";
	className = "Backpack";
   heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = SCVPackImage;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SCVPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		%client = Player::getClient(%player);
		schedule(%client.deployable @ "::deployShape(" @ %player @ ", " @ %client.deployable @ ");", 0.1, %player);
	}
}

function SCVPack::onDrop(%player, %item)
{
//do nothing
}


ItemImageData SpecialistPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;

	weaponType = 2; // Sustained
	maxEnergy = 0;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SpecialistPack
{
	description = "Specialist Pack";
	className = "Backpack";
	shapeFile = "sensorjampack";
	hudIcon = "deployable";
	heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = SpecialistPackImage;
	price = 0;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function SpecialistPackImage::onActivate(%player, %imageSlot)
{
	if(%player.cloakPack != 1 && %player.cloakGun != 1)
		GameBase::startFadeOut(%player);
	%player.cloakPack = 1;
	%rate = Player::getSensorSupression(%player) + 20;
	if(%rate < 20)
		%rate = 20;
	Player::setSensorSupression(%player,%rate);
	%player.shieldStrength += 0.01;
	Client::sendMessage(Player::getClient(%player), 0, "Specialist Pack activated.");
}

function SpecialistPackImage::onDeactivate(%player, %imageSlot)
{
	if(%player.cloakPack == 1 && %player.cloakGun != 1)
		GameBase::startFadeIn(%player);
	%player.cloakPack = 0;
	%rate = Player::getSensorSupression(%player) - 20;
	if(%rate < 0)
		%rate = 0;
	Player::setSensorSupression(%player,%rate);
	%player.shieldStrength -= 0.01;
	Player::trigger(%player,$BackpackSlot,false);
	Client::sendMessage(Player::getClient(%player), 0, "Specialist Pack deactivated.");
}

ItemImageData ChangelingNetImage
{
	shapeFile = "jetpack";
	mountPoint = 2;

	weaponType = 2; // Sustained
	maxEnergy = 0;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ChangelingNet
{
	description = "Changeling Net";
	className = "Backpack";
	shapeFile = "jetpack";
	hudIcon = "deployable";
	heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = ChangelingNetImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function ChangelingNetImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%client);
	%client.realteam = %team;
	%client.traitor = 1;
	if(%team == 0)
		%newTeam = 1;
	else
		%newTeam = 0;
	GameBase::setTeam(%client, %newTeam);
	Client::sendMessage(%client, 1, "You appear to have changed teams...");
}

function ChangelingNetImage::onDeactivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	GameBase::setTeam(%client, %client.realteam);
	%client.traitor = 0;
	Client::sendMessage(%client, 1, "You have returned to your original team.");
}



ItemImageData TeleportPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData TeleportPack
{
	description = "Teleportation Pack";
	className = "Backpack";
	shapeFile = "sensor_small";
	hudIcon = "shieldpack";
	heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = TeleportPackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function TeleportPackImage::onActivate(%player, %imageSlot)
{
	%obj = newObject("","Mine","TeleFX");
 	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj, Vector::add(GameBase::getPosition(2049), "0 0 1"));

	%obj = newObject("","Mine","TeleFX");
 	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj, Vector::add(GameBase::getPosition(2049), "0 0 2"));

	%obj = newObject("","Mine","TeleFX");
 	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj, Vector::add(GameBase::getPosition(2049), "0 0 3"));


	Client::sendMessage(%client, 0, "You successfully teleported!");
	%hasflag = Player::getMountedItem(%player, 2);
	if(%hasflag!=-1 && %hasflag!="DeadWeight")
	{
		Player::dropItem(%player, %hasflag);
		Client::sendMessage(%client, "While teleporting, you dropped the flag...");
	}
	%client = Player::getClient(%player);
	%object = Client::getOwnedObject(%client);
	Player::setDamageFlash(%player, 0.4);
	GameBase::setEnergy(%object, 0);
	GameBase::setPosition(%player, $TeleSpot[Client::getTeam(%client)]);
	Player::decItemCount(%player, TeleportPack);

	%obj = newObject("","Mine","TeleFX");
 	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj, Vector::add(GameBase::getPosition(2049), "0 0 1"));

	%obj = newObject("","Mine","TeleFX");
 	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj, Vector::add(GameBase::getPosition(2049), "0 0 2"));

	%obj = newObject("","Mine","TeleFX");
 	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj, Vector::add(GameBase::getPosition(2049), "0 0 3"));
}

function TeleportPackImage::onDeactivate(%player, %imageSlot)
{
//do nothing
}

ItemImageData FlagMovePackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;

	//maxEnergy = -1;
	//weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.01;
	firstPerson = false;
};

ItemData FlagMovePack
{
	description = "Flag Movement Pack";
	className = "Backpack";
	shapeFile = "AmmoPack";
	hudIcon = "ammopack";
	heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = FlagMovePackImage;
	price = 50;
	showWeaponBar = true;
	hiliteOnActive = false;

	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
};

function FlagMovePack::onDrop(%player, %item)
{
	%client = Player::getClient(%player);
	if(Player::getMountedItem(%player, $FlagSlot) == Flag)
		Client::sendMessage(%client, 0, "You cannot drop the Flag Movement pack while still holding your flag");
	else
	{
		if(%client.moveFlag)
			%client.moveFlag = 0; //can't move flag after dropping it
		Item::onDrop(%player, %item);	
	}
}

function FlagMovePack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player, $BackpackSlot) != %item)
	{
		Player::mountItem(%player, %item, $BackpackSlot);
	}

	%client = Player::getClient(%player);

	if (Player::getMountedItem(%client, $FlagSlot) != Flag) //have no flag
	{
		if(%client.moveFlag) //was in move mode
		{
			Client::sendMessage(%client, 0, "You may return your flag to your base.");
			%client.moveFlag = 0;
		}
		else //was in return mode
		{
			Client::sendMessage(%client, 0, "You may now move your flag.");
			%client.moveFlag = 1;
		}
	}
	else //you have a flag
	{
		if(%client.moveFlag) //you are moving your flag
		{
			%this = Client::getOwnedObject(%client);

			if(GameBase::getLOSInfo(%this, 6))
			{
				%obj = getObjectType($LOS::object);
				if(%obj == "InteriorShape")
				{
					Player::dropItem(%player, Flag);
					%client.moveFlag = 0;
				}
				else
					Client::sendMessage(%client, 1, "You may only reposition the flag inside.");
			}
			else
				Client::sendMessage(%client, 1, "Deploy position out of range.");
		}
		else //it must be the enemy flag
			Client::sendMessage(%client, 1, "You are already holding a flag.");
	}
}

ItemImageData ArbitorBoxPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ArbitorBoxPack
{
	description = "Arbitor Device";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = "eDeployables";
	imageType = ArbitorBoxPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ArbitorBoxPack::onUse(%player,%item)
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

function ArbitorBoxPack::onDeploy(%player,%item,%pos)
{
	if (ArbitorBoxPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ArbitorBoxPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,Vector::add($los::position, "0.2 0.2 0")))
					{
						%rot = GameBase::getRotation(%player); 
						%turret = newObject("ArbitorBox","Turret",ArbitorBox,true);
                 				addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Arbitor Device " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Arbitor Device deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ArbitorBoxPack"]++;
						echo("MSG: ",%client," deployed an Arbitor Box");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %turret); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%turret, 0.7 * ArbitorBox.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "es");

	return false;
}


$TeamItemMax[TreePack] = 40;

ItemImageData TreePackImage
{
	shapeFile = "jetpack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TreePack
{
	description = "Seed Pack";
	shapeFile = "jetpack";
	className = "Backpack";
   heading = "eDeployables";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TreePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TreePack::onDeploy(%player,%item,%pos)
{
	if (TreePack::deployShape(%player,%item))
	{
		//Player::decItemCount(%player,%item); //thus infinite trees to plant
	}
}

function TreePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj != "InteriorShape")
			{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player);
						%rand = floor(getRandom() * 6);
						if(%rand == 0) %type = "TreeShapeTwo";
						else if(%rand == 1) %type = "TreeShape"; 
						//else if(%rand == 3) %type = "PlantOne"; 
						else if(%rand == 2) %type = "PlantTwo";
						else if(%rand == 3) %type = "Cactus1"; 
						else if(%rand == 4) %type = "Cactus2"; 
						else %type = "Cactus3"; 

						%tree = newObject("A Tree","StaticShape",%type,true);
                 				addToSet("MissionCleanup", %tree);
						GameBase::setTeam(%tree,GameBase::getTeam(%player));
						GameBase::setPosition(%tree,$los::position);
						GameBase::setRotation(%tree,%rot);
						Gamebase::setMapName(%tree,"Tree " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Seed Planted");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
						echo("MSG: ",%client," planted a seed");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %tree); 
						// Client::setOwnedObject(%client, %player);
						return true;
					}
			}
			else 
				Client::sendMessage(%client,0,"Cannot deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description);

	return false;
}



ItemImageData NuclearTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData NuclearTurretPack
{
	description = "Nuclear Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "eDeployables";
	imageType = NuclearTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function NuclearTurretPack::onUse(%player,%item)
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

function NuclearTurretPack::onDeploy(%player,%item,%pos)
{
	if (NuclearTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function NuclearTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 
						%turret = newObject("NuclearremoteTurret","Turret",NuclearDeployableTurret,true);
                 				addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Nuclear Turret " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Nuclear Turret deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "NuclearTurretPack"]++;
						echo("MSG: ",%client," deployed a Nuclear Turret");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %turret); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%turret, 0.7 * NuclearDeployableTurret.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

ItemImageData ObeliskPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ObeliskPack
{
	description = "Obelisk of Light";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "eDeployables";
	imageType = ObeliskPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPack::onUse(%player,%item)
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

function ObeliskPack::onDeploy(%player,%item,%pos)
{
	if (ObeliskPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ObeliskPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%Set = newObject("set",SimSet); 
			%Mask = $StaticObjectType; 
			%num =containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50,0);
			for(%i; %i < %num; %i++)
			{
				%gen = Group::getObject(%Set, %i);
				if(%gen.obeliskpower && %gen.obelisk == "")
				{
					%powered = true;
					break;
				}
			}
			deleteObject(%Set);
			if(%powered)
			{
				%obj = getObjectType($los::object);
				if (%obj != "InteriorShape")
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player); 

							%turret2 = newObject("ObeliskBarrel","Turret",RealObeliskOfLight,true);
	                 				addToSet("MissionCleanup", %turret2);
							GameBase::setTeam(%turret2,GameBase::getTeam(%player));
							GameBase::setPosition(%turret2,Vector::add($los::position, "0 0 11.5"));
							GameBase::setRotation(%turret2,%rot);

							%turret = newObject("Obelisk","StaticShape",ObeliskOfLight,true);
      	           				addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);

							%turret.realGun = %turret2; //referencing variables
							%turret.gen = %gen;
							%gen.obelisk = %turret2;

							Gamebase::setMapName(%turret,"Obelisk of Light " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Obelisk of Light deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "ObeliskPack"]++;
							echo("MSG: ",%client," deployed an Obelisk of Light. Turret is:" @ %turret @ " and Turret2 is: " @ %turret2);
							//	Remote turrets - kill points to player that deploy them
							// Client::setOwnedObject(%client, %turret); 
							// Client::setOwnedObject(%client, %player);
							if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
								GameBase::setDamageLevel(%turret, 0.7 * ObeliskOfLight.maxDamage);

							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else 
					Client::sendMessage(%client,0,"Cannot deploy in buildings");
			}
			else
				Client::sendMessage(%client, 0, "Must be within range of an Obelisk Power Source");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

ItemImageData ObeliskPowerPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -1.0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData ObeliskPowerPack
{
	description = "Obelisk Power Souce";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "eDeployables";
	imageType = ObeliskPowerPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPowerPack::onUse(%player,%item)
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

function ObeliskPowerPack::onDeploy(%player,%item,%pos)
{
	if (ObeliskPowerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ObeliskPowerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj != "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 

						%generator = newObject("ObeliskPower","StaticShape",ObeliskPower,true);
                 				addToSet("MissionCleanup", %generator );
						GameBase::setTeam(%generator ,GameBase::getTeam(%player));
						GameBase::setPosition(%generator,$los::position);
						GameBase::setRotation(%generator,%rot);

						%generator.obeliskpower = true;

						Gamebase::setMapName(%turret,"Obelisk Power Source " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Obelisk Power Source deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ObeliskPowerPack"]++;
						echo("MSG: ",%client," deployed an Obelisk Power Source");
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %generator); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%generator, 0.7 * ObeliskPower.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Cannot deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

ItemImageData FlameTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData FlameTurretPack
{
	description = "Flame Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "eDeployables";
	imageType = FlameTurretPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function FlameTurretPack::onUse(%player,%item)
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

function FlameTurretPack::onDeploy(%player,%item,%pos)
{
	if (FlameTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function FlameTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{
				%Set = newObject("set",SimSet); 
				%Mask = $StaticObjectType; 
				%num =containerBoxFillSet(%Set, %Mask, $los::position, 70, 70, 50,0);
				for(%i; %i < %num; %i++)
				{
					%thing = Group::getObject(%Set, %i);
					if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
					{
						%inbase= true;
						break;
					}
				}
				deleteObject(%Set);
				if(%inbase)
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player); 

							%turret = newObject("Flame Turret","Turret",FlameTurret,true);
     		           				addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"Flame Turret " @ Client::getName(%client));

							%cyl = newObject("Flame Turret Fuel","StaticShape",Canister,true);
     		           				addToSet("MissionCleanup", %cyl);
							GameBase::setTeam(%cyl,GameBase::getTeam(%player));
							%backward = Vector::neg(Vector::getFromRot(%rot, 0.8));//meaning backwards a little bit.

							GameBase::setPosition(%cyl,Vector::add($los::position, %backward));
							GameBase::setRotation(%cyl,%rot);
							Gamebase::setMapName(%cyl,"Flame Turret Fuel");

							%turret.cyl = %cyl;
							%cyl.turret = %turret;

							Client::sendMessage(%client,0,"Flame Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "FlameTurretPack"]++;
							echo("MSG: ",%client," deployed an Flame Turret");
							//	Remote turrets - kill points to player that deploy them
							// Client::setOwnedObject(%client, %turret); 
							// Client::setOwnedObject(%client, %player);

							if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							{
								GameBase::setDamageLevel(%turret, 0.7 * FlameTurret.maxDamage);
								GameBase::setDamageLevel(%cyl, 0.7 * Canister.maxDamage);
							}

							return true;
						}
						else
							Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else 
					Client::sendMessage(%client,0,"You must be near your own base");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

ItemImageData SuperSensorPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 4.0;
	firstPerson = false;
};

ItemData SuperSensorPack
{
	description = "Super Sensor";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = "eDeployables";
	imageType = SuperSensorPackImage;
	shadowDetailMask = 4;
	mass = 4.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function SuperSensorPack::onUse(%player,%item)
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

function SuperSensorPack::onDeploy(%player,%item,%pos)
{
	if (SuperSensorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function SuperSensorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 
						%turret = newObject("Super Sensor","Turret",SuperSensor,true);
                 				addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Super Sensor " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Super Sensor deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "SuperSensorPack"]++;
						echo("MSG: ",%client," deployed a Super Sensor. # " @ %turret);
						//	Remote turrets - kill points to player that deploy them
						// Client::setOwnedObject(%client, %turret); 
						// Client::setOwnedObject(%client, %player);
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%turret, 0.7 * SuperSensor.maxDamage);

						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Cannot deploy in buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}



ItemImageData JetfirePackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData JetfirePack
{
	description = "Jetfire Transformation";
	className = "Backpack";
	shapeFile = "mortarpack";
	hudIcon = "shieldpack";
	heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = JetfirePackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function JetfirePackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%vel = Item::getVelocity(%client);

	if(Player::getMountedItem(%client, $FlagSlot) == "flag")
	{
		Player::dropItem(%client, Player::getMountedItem(%client, $FlagSlot));
		Client::sendMessage(%client, 1, "You dropped the flag while transforming!");
	}

	%item = JetfireVehicle;

	%markerPos = GameBase::getPosition(%client);
	%set = newObject("",Flier, Jetfire, true);
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

function JetfirePackImage::onDeactivate(%player, %imageSlot)
{
// do nothing really... all handled by dismounting.
}
//end mod




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
   heading = "eDeployables";
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
					if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
						GameBase::setDamageLevel(%mSensor, 0.7 * DeployableMotionSensor.maxDamage);

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
   heading = "dBackpacks";
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
//mod:
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
	 	    	%item.HandgrenadeAmmo = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else if(%i == 6) {
	 	    	%item.C4Ammo = %numPack;
			}
			else if(%i == 7) {
	 	    	%item.SlowGunAmmo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.ConcussAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.MarlinAmmo = %numPack;
			}
			else if(%i == 10) {
			%item.FlashgrenadeAmmo = %numPack;
			}
			else if(%i == 11) {
			%item.StungrenadeAmmo = %numPack;
			}
			else {
	 	    	%item.originalMine = %numPack;
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
//mod:
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
	    	%numAdd = %item.HandgrenadeAmmo;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else if(%i == 6) {
 	    	%numAdd = %item.C4Ammo;
		}
		else if(%i == 7) {
 	    	%numAdd = %item.SlowGunAmmo;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.ConcussAmmo;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.MarlinAmmo;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.FlashgrenadeAmmo;
		}
		else if(%i == 11) {
 	    	%numAdd = %item.StungrenadeAmmo;
		}
		else
		{
			%numAdd = %item.originalMine;
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
   heading = "eDeployables";
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

function PulseSensorPack::deployShape(%player, %item)
{
	if(Item::deployShape(%player, "Pulse Sensor", DeployablePulseSensor, %item))
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
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
   heading = "eDeployables";
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

function DeployableSensorJammerPack::deployShape(%player, %item)
{
	if(Item::deployShape(%player, "Sensor Jammer", DeployableSensorJammer, %item))
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
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
   heading = "eDeployables";
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
					if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
						GameBase::setDamageLevel(%camera, 0.7 * CameraTurret.maxDamage);

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
   heading = "eDeployables";
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
								if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
									GameBase::setDamageLevel(%turret, 0.7 * DeployableTurret.maxDamage);

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
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%sensor, 0.7 * %shape.maxDamage);
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
   heading = "fMiscellany";
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
	showInventory = false;
   description = "Mine";
   shapeFile = "breath";
   //heading = "fMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

//mod:

ItemData OriginalMine
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "hMine";
   shadowDetailMask = 4;
   price = 10;
	className = "Mine";
};

ItemData ReplicatingMine
{
   description = "Replicating Mine";
   shapeFile = "mineammo";
   heading = "hMine";
   shadowDetailMask = 4;
   price = 20;
	className = "Mine";
};


ItemData FlagMine
{
   description = "Fake Flag Mine";
   shapeFile = "mineammo";
   heading = "hMine";
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

			if(Player::getItemCount(%player, OriginalMine))
			{
				%name = "AntipersonelMine";
				%item = OriginalMine;
			}
			else if(Player::getItemCount(%player, ReplicatingMine))
			{
				%name = "ReplicatorMine";
				%item = ReplicatingMine;
			}
			else if(Player::getItemCount(%player, FlagMine))
			{
				%name = "FakeFlag";
				%item = FlagMine;
			}

			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, MineAmmo);
			%obj = newObject("","Mine",%name);
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam(%obj,GameBase::getTeam(%client));//JR 1/31/99
		}
	}
}

//----------------------------------------------------------------------------

ItemData Grenade
{
	showInventory = false;
   description = "Grenade";
   shapeFile = "breath";
 //  heading = "fMiscellany";
   shadowDetailMask = 4;
   price = 0;
	className = "HandAmmo";
};

//mod:

ItemData C4Ammo
{
   description = "C4";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 15;
	className = "Grenade";
};


ItemData HandgrenadeAmmo
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 5;
	className = "Grenade";
};

ItemData FlashgrenadeAmmo
{
   description = "Flash Grenade";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 1;
	className = "Grenade";
};

ItemData StungrenadeAmmo
{
   description = "Stun Grenade";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 5;
	className = "Grenade";
};

ItemData SuicideAmmo
{
   description = "Suicide Bomb";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 20;
	className = "Grenade";
};


function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			%client = Player::getClient(%player);
			if(Player::getItemCount(%player, C4Ammo) > 0)
			{
				%chance = floor(getRandom() * 100);
				if(%chance < 5)
				{
					%item = C4Ammo;
					%name = "C4Oops";
					Client::sendMessage(Player::getClient(%player), 1, "The C4 went off while setting the charge!");
				}
				else if(%chance > 95)
				{
					%item = C4Ammo;
					%name = "C4Dud";
					Client::sendMessage(Player::getClient(%player), 1, "C4 deployed. 10 seconds until detonation.");
					schedule("Client::sendMessage(Player::getClient(" @ %player @ "), 1, 'The C4 did not explode...');", 10.0);
				}
				else
				{
					%item = C4Ammo;
					%name = "C4";
					Client::sendMessage(Player::getClient(%player), 1, "C4 deployed. 10 seconds until detonation.");
				}
			}
			else if(Player::getItemCount(%player, HandgrenadeAmmo) > 0)
			{
				%item = HandgrenadeAmmo;
				%name = "Handgrenade";
			}
			else if(Player::getItemCount(%player, SuicideAmmo) > 0)
			{
				%item = SuicideAmmo;
				%name = "SuicideBomb";
				%client.score -= 4;
			}
			else if(Player::getItemCount(%player, FlashgrenadeAmmo) > 0)
			{
				%item = FlashgrenadeAmmo;
				%name = "Flashgrenade";
			}
			else if(Player::getItemCount(%player, StungrenadeAmmo) > 0)
			{
				%item = StungrenadeAmmo;
				%name = "Stungrenade";
			}
			else
				return;
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
			%armor = Player::getArmor(%player);
			%obj = newObject("","Mine",%name);
 	 	 	addToSet("MissionCleanup", %obj);
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
   heading = "fMiscellany";
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
   heading = "fMiscellany";
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
	if (%numweapon > $MaxWeapons[%armor])
	{
	   %weaponflag = %numweapon - $MaxWeapons[%armor];
	}
	%max = getNumItems2();
	for (%i = 0; %i < %max; %i = %i + 1)
	{
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
//		if(%maxnum != "") //removed so that I need not say maxnum = 0 for each weapon...


			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum)
			{
				%numsell =  %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon)
			{
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0 && %item != Flag)
			{
				if(%item != Grenade && %item != MineAmmo && %item != shortEnergyRifle && %item != longEnergyRifle && %item != TargetingLaser) //since they are just place holders, don't announce
				    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item.description);
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
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
	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = 0; %i < 8; %i++)
	{
		$TeamItemCount[%i @ DeployableAmmoPack] = 0;
		$TeamItemCount[%i @ DeployableInvPack] = 0;
		$TeamItemCount[%i @ TurretPack] = 0;
		$TeamItemCount[%i @ CameraPack] = 0;
		$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
		$TeamItemCount[%i @ PulseSensorPack] = 0;
		$TeamItemCount[%i @ MotionSensorPack] = 0;
		$TeamItemCount[%i @ ScoutVehicle] = 0;
		$TeamItemCount[%i @ LAPCVehicle] = 0;
		$TeamItemCount[%i @ HAPCVehicle] = 0;
		$TeamItemCount[%i @ Beacon] = 0;
		$TeamItemCount[%i @ originalMine] = 0;
//mod:
		$TeamItemCount[%i @ NuclearTurretPack] = 0;
		$TeamItemCount[%i @ TreePack] = 0;
		$TeamItemCount[%i @ JetFireVechicle] = 0;
		$TeamItemCount[%i @ ObeliskPack] = 0;
		$TeamItemCount[%i @ ObeliskPowerPack] = 0;
		$TeamItemCount[%i @ FlameTurretPack] = 0;
		$TeamItemCount[%i @ ArbitorBoxPack] = 0;
		$TeamItemCount[%i @ ReplicatingMine] = 0;
		$TeamItemCount[%i @ FlagMine] = 0;
		$TeamItemCount[%i @ "originalreplicatingmine"] = 0;

		$TeamEnergy[%i] = $DefaultTeamEnergy;
	}
}

//mod:
function getNumItems2()
{
	return 85;
}