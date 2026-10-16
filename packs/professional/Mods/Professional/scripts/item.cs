//----------------------------------------------------------------------------

$ItemFavoritesKey = "Professional";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

$ItemPopTime = 15;

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
$AutoUse[FusionGun] = True;
$AutoUse[Marlin] = True;
$AutoUse[MineLauncher] = True;
$AutoUse[ClusterBomb] = True;
$AutoUse[PlasmaCannon] = True;
$AutoUse[RepairRifle] = True;
$AutoUse[Shotgun] = True;
$AutoUse[EMPGrenadeLauncher] = True;



$Use[Blaster] = True;

$ArmorType[Male, HyperArmor] = hlarmor;
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, HyperArmor] = hlfemale;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Male, EngArmor] = earmor;
$ArmorType[Female, EngArmor] = efemale;


$ArmorName[hlarmor] = HyperArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[hlfemale] = HyperArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorName[earmor] = EngArmor;
$ArmorName[efemale] = EngArmor;


// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 10;
$SellAmmo[Grenade] = 10;
$SellAmmo[RocketAmmo] = 5;
$SellAmmo[EMPGrenadeAmmo] = 1;
$SellAmmo[ShotgunShells] = 80; 
$SellAmmo[MinelAmmo] = 5;
$SellAmmo[MarlinAmmo] = 8;


// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 200;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[RocketAmmo] = 10;
$AmmoPackMax[RepairKit] = 2;
$AmmoPackMax[MineAmmo] = 3;
$AmmoPackMax[OriginalGrenade] = 5;
$AmmoPackMax[Beacon] = 3;
$AmmoPackMax[EMPGrenadeAmmo] = 2;
$AmmoPackMax[ShotgunShells] = 20;
$AmmoPackMax[MarlinAmmo] = 16;
$AmmoPackMax[MinelAmmo] = 8;
$AmmoPackMax[Plastique] = 3;
$AmmoPackMax[EMPGrenade] = 5;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
//$AmmoPackItems[4] = OriginalGrenade;
$AmmoPackItems[4] = MortarAmmo;
$AmmoPackItems[5] = RocketAmmo;
$AmmoPackItems[6] = RepairKit;
$AmmoPackItems[7] = MineAmmo;
$AmmoPackItems[8] = Beacon;
$AmmoPackItems[9] = EMPGrenadeAmmo;
$AmmoPackItems[10] = ShotgunShells; 
$AmmoPackItems[11] = MarlinAmmo;
$AmmoPackItems[12] = MinelAmmo;



// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 4;
$TeamItemMax[DeployableInvPack] = 2;
$TeamItemMax[TurretPack] = 6;
$TeamItemMax[CameraPack] = 5;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 20;
$TeamItemMax[mineammo] = 20;
$TeamItemMax[DeployableForceField] = 4;
$TeamItemMax[RocketPack] = 2;
$TeamItemMax[DeployableELFTurretPack] = 4;

$TeamItemMax[BaseAlarm] = 10;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[SuicidePack] = 2;
$TeamItemMax[Springboard] = 6;
$TeamItemMax[DShield] = 2;
$TeamItemMax[SeekerPack] = 1;
$TeamItemMax[DeployableSeeker] = 1;
$TeamItemMax[TreePack] = 40;
$TeamItemMax[RailTurret] = 3;
$TeamItemMax[PlasmaPack] = 3;
$TeamItemMax[ShockPack] = 4;
$TeamItemMax[hologram] = 15;
$TeamItemMax[LaserPack] = 3;
$TeamItemMax[DeployableLRMotionSensorPack] = 2;
$TeamItemMax[ConPack] = 2;
$TeamItemMax[BlastWall] = 8;
$TeamItemMax[ChaingunTurretPack] = 3;
$TeamItemMax[DoBPack] = 1;
$TeamItemMax[doorthreebyfourForceFieldPack] = 10;
$TeamItemMax[doorfourbyfourteenForceFieldPack] = 10;
$TeamItemMax[doorfourbyseventeenForceFieldPack] = 10;
$TeamItemMax[doorfourbyeightForceFieldPack] = 10;
$TeamItemMax[doorfivebyfiveForceFieldPack] = 10;
$TeamItemMax[FlakPack] = 3;
$TeamItemMax[FlameTurretPack] = 2;


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
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[EMPGrenadeLauncher] = EMPGrenadeAmmo;
$WeaponAmmo[Shotgun] = ShotgunShells;
$WeaponAmmo[ClusterBomb] = "";
$WeaponAmmo[MineLauncher] = MinelAmmo;
$WeaponAmmo[Marlin] = MarlinAmmo;
//$WeaponAmmo[ChargeGun] = True;
$WeaponAmmo[FusionGun] = "";
$WeaponAmmo[PlasmaCannon] = "";
$WeaponAmmo[RepairRifle] = "";



$KamikazeIsActive[0] = "false";
$ForceFieldPack::RechargeRate=0.15;

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
					//echo("Item.cs line 256 " @ %count);
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
					//echo("Item.cs line 267");
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
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
	{
		%extraAmmo = $AmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
		%delta = %delta + %extraAmmo;
	}
	if($TestCheats == 0 && %client.spawn == "") 
	{
		%energy = $TeamEnergy[%team];
    		%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation)
		{
			%energy = %station.Energy;
		}
		if(%energy != "Infinite") 
		{
			if (%item.price * %delta > %energy) %delta = %energy / %item.price; 
			if(%delta < 1 ) 
			{
				if(%noMessage == "") Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
				return 0;
			}
		}
	}
	if(%item.className == Weapon) 
	{
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Weapon");
		if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) 
		{
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}
	else if(%item == RepairPatch) 
	{
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) return 1;
		return 0;
   }
   else if($TeamItemMax[%item] != "" && !$TestCheats) 
   {
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) 
		{
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
			return 0;
		}
	}
	if(%item.className != Armor && %item.className != Vehicle) 
	{
	   //if (%item.className != Grenade)
	   //{
	   	%count = Player::getItemCount(%client,%item);
	   	//echo("Item.cs line 345 classname " @ %item.classname @ " Item " @ %item @ " count " @ %count);
	   	%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
	   	if(%delta + %count >= %max) %delta = %max - %count;
	   //}
	   //else
	   //{
	   //	//%count = Player::getItemCount(%client,%item);
	   //	////echo("Item.cs line 361 classname " @ %item.classname @ " Item " @ %item @ " count " @ %count);
	   //	%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
	   //	if(%delta + %count >= %max) %delta = %max - %count;
	   //}
	}
	return %delta;
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) 
	{
		if (%item.className == Armor) 
		{
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			////echo("Item.cs line 369");
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
					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) fillAmmoPack(%client);	
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
			//echo("Item.cs line 387");
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack) 
				{
					if(Player::getItemCount(%client,"LaserRifle") > 0) 
					{
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
				echo("%item " @ %item);
				if(Player::getItemClassCount(%player, "Grenade") > 0) 
				{
					//%max = getNumItems();
					//for (%i = 0; %i < %max; %i = %i + 1) 
					//{
					//	//%count = Player::getItemCount(%this,%i);
					//	%name = getItemType(%i);
					//	if (%name.className == Grenade && %name != %item)
					//	{
					//		Player::setItemCount(%player, %name, 0);
					//	}
					//
					//}
					if(%item == OriginalGrenade)
					{
						//teamEnergyBuySell(%player,%g.price * Player::getItemCount(%player, OriginalGrenade));
						Player::setItemCount(%player, Plastique, 0);
						Player::setItemCount(%player, EMPGrenade, 0);
						echo("replacing old grenades with grenades");
					}
					else if(%item == EMPGrenade)
					{
						//teamEnergyBuySell(%player,%g.price * Player::getItemCount(%player, OriginalGrenade));
						Player::setItemCount(%player, OriginalGrenade, 0);
						Player::setItemCount(%player, Plastique, 0);
						echo("replacing old grenades with EMPGrenades");
					}
					else if(%item == Plastique)
					{
						//teamEnergyBuySell(%player,%g.price * Player::getItemCount(%player, OriginalGrenade));
						Player::setItemCount(%player, OriginalGrenade, 0);
						Player::setItemCount(%player, EMPGrenade, 0);
						echo("replacing old grenades with Plastique");
					}
				}
				%max = $ItemMax[%armor, %item];
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack) %max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				//echo("Item.cs line 463");
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,Grenade, Player::getItemCount(%client, %item));
				//echo("Item.cs line 467");
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}
		}
	 	else if(%item.className == Vehicle) 
	 	{
			if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) 
			{
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) 
				{
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2) return 1;
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
	if(%client.respawn == "" && %player.Station != "") 
	{
		%sPos = GameBase::getPosition(%player.Station);
		%pPos	= GameBase::getPosition(%client);
		%posX = getWord(%sPos,0);
		%posY = getWord(%sPos,1);
		%posZ = getWord(%pPos,2);
		%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1);	
	  	%newPosX = (getWord(%vec,0) * 1) + %posX;		 
		%newPosY = (getWord(%vec,1) * 1) + %posY;
		GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ);
		%armor = Player::getArmor(%player);
		if(%armor == "earmor" || %armor == "efemale") 
		{ 
			Bottomprint(%client, "Only the Engineer has access to all deployables.  In addition, only the Engineer can disarm DetPacks and crack the locking codes on forcefields.");
			GameBase::setAutoRepairRate(%player, 0);
		}
		else if(%armor == "larmor" || %armor == "lfemale") 
		{ 
			Bottomprint(%client, "The Light is quick and maneuverable, but can carry few deployables.");
			GameBase::setAutoRepairRate(%player, 0);
		}
		else if(%armor == "marmor" || %armor == "mfemale") 
		{ 
			Bottomprint(%client, "Jack of all trades, and master of none:  The Medium is the workhorse of the clans.");
			GameBase::setAutoRepairRate(%player, 0);
		}
		else if(%armor == "hlarmor" || %armor == "hlfemale") 
		{ 
			Bottomprint(%client, "The Hyperlight is a prototype armor representing the future of the clans.  Small and fast, it is the only armor with nanorepair functionality.");
			GameBase::setAutoRepairRate(%player, 0.015);
		}
		else 
		{ 
			Bottomprint(%client, "The Heavy is the closest thing to Herc that the clans have to offer.  Heavy's offer the most destructive power available in an armor.");
			GameBase::setAutoRepairRate(%player, 0);
		}

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
	//echo("Item.cs line 566");
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
			else if(%item == EnergyPack) 
			{ 
				if(Player::getItemCount(%client,"LaserRifle") > 0) 
				{
				}
			}
			else if(%item.className == Grenade)
			{
				%numsell = Player::getItemCount(%client, %item);
				//echo("Item.cs line 592");
				Player::decItemCount(%client, Grenade, %numsell);
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
	if (%item.className == "Grenade" || %item.className == "HandAmmo" || %item.className == "Mine") {
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
		else if(%item.className == Grenade)
		{
			Player::dropItem(%client,%item);
			Player::decItemCount(%client, Grenade, $SellAmmo[%item]);
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
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = RocketLauncher;
$NextWeapon[RocketLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
//$NextWeapon[LaserRifle] = EnergyRifle;
$NextWeapon[LaserRifle] = FusionGun;
$NextWeapon[FusionGun] = Marlin;
$NextWeapon[Marlin] = MineLauncher;
$NextWeapon[MineLauncher] = ClusterBomb;
$NextWeapon[ClusterBomb] = PlasmaCannon;
$NextWeapon[PlasmaCannon] = RepairRifle;
$NextWeapon[RepairRifle] = Shotgun;
$NextWeapon[Shotgun] = EMPGrenadeLauncher;

$NextWeapon[EMPGrenadeLauncher] = EnergyRifle;


$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[RocketLauncher] = GrenadeLauncher;
$PrevWeapon[Mortar] = RocketLauncher;
$PrevWeapon[LaserRifle] = Mortar;
//$PrevWeapon[EnergyRifle] = LaserRifle;
$PrevWeapon[FusionGun] = LaserRifle;
$PrevWeapon[Marlin] = FusionGun;
$PrevWeapon[MineLauncher] = Marlin;
$PrevWeapon[ClusterBomb] = MineLauncher;
$PrevWeapon[PlasmaCannon] = ClusterBomb;
$PrevWeapon[RepairRifle] = PlasmaCannon;
$PrevWeapon[Shotgun] = RepairRifle;
$PrevWeapon[EMPGrenadeLauncher] = Shotgun;

$PrevWeapon[EnergyRifle] = EMPGrenadeLauncher;


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
	//echo("Item.cs line 780");
	if (Player::getItemCount(%client,%weapon)) 
	{
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0) return true;
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
		else if(%item.className == Grenade)
		{
			%carrying = checkResources(%player,%item,1);
			//echo("Item.cs line 810");
			%ObjCount = Player::getItemCount(%player, %item);
			%ObjGrenadeCount = Player::getItemClassCount(%player,Grenade);
			//if(Player::getItemCount(%player, %item) == Player::getItemCount(%player, %carrying))
			if(%ObjCount >0 || %ObjGrenadeCount == 0)
			{
				%count = Player::getItemCount(%player, %item);
				//echo("Item.cs line 814");
				%total = $ItemMax[%armor, %item];
				%extra = %total - %count;
				if(%delta > %extra)
				%delta = %extra;
				if(%delta > 0)
				{
					Player::incItemCount(%player, %item, %delta);
					Player::incItemCount(%player, %carrying, %delta);
					Client::sendMessage(%client, 0, "You received " @ %delta @ " " @ %item.description);
					return %delta;
				}
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
			//echo("Item.cs line 837");
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
	if (getObjectType(%object) == "Player") 
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		//echo("Item.cs line 894");
		if (%this.className != Grenade)
		{
			if (Item::giveItem(%object,%item,Item::getCount(%this))) 
			{
				Item::playPickupSound(%this);
				Item::respawn(%this);
			}
		}
		else 
		{
			%ObjGrenadeCount = Player::getItemClassCount(%object,"Grenade");
			//%ObjCount = Player::getItemCount(%object,%item);
			if(%count > 0 || %ObjGrenadeCount == 0)
			{
				if (Item::giveItem(%object,%item,Item::getCount(%this))) 
				{
					Player::setItemCount(%object,Grenade, Player::getItemCount(%object, %this));
					Item::playPickupSound(%this);
					Item::respawn(%this);
				}
			}
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
	lightRadius = 5;
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
	lightRadius = 5;
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
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData HyperArmor
{
   heading = "aArmor";
	description = "Hyperlight Armor";
	className = "Armor";
	price = 100;
};

ItemData LightArmor
{
   heading = "aArmor";
	description = "Light Armor";
	className = "Armor";
	price = 150;
};

ItemData MediumArmor
{
   heading = "aArmor";
	description = "Medium Armor";
	className = "Armor";
	price = 200;
};

ItemData HeavyArmor
{
   heading = "aArmor";
	description = "Heavy Armor";
	className = "Armor";
	price = 300;
};

ItemData EngArmor
{
   heading = "aArmor";
        description = "Engineer";
        className = "Armor";
        price = 250;
};

function Armor::onRemoteSet(%player)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	Bottomprint(%client, "Only the Engineer has access to all deployables.  In addition, only the Engineer can disarm DetPacks and crack the locking codes on forcefields.");

}


//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 300;
};

ItemData LAPCVehicle
{
	description = "LPC";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 450;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 600;
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
	%ammo = %item.imageType.ammoType;
	if (%ammo == "") {
		// Energy weapons dont have ammo types
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else {
		//echo("Item.cs line 1113");
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
	if($matchStarted) 
	{
		%count = Player::getItemCount(%player,%item);
		//echo("Item.cs line 1150");
		%delta = $SellAmmo[%item];
		if(%count <= %delta) 
		{ 
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) %delta = %count;
			else %delta = %count - 1;
		}
		if(%delta > 0) 
		{
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
	fireTime = 0.5;
	minEnergy = 17;
	maxEnergy = 18;

	//projectileType = BlasterBolt;
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
	price = 50;
	showWeaponBar = true;
};

function BlasterImage::onFire(%player, %slot) 
{
	//%Ammo = Player::getItemCount(%player, $WeaponAmmo[Blaster]);
	%Ammo=GameBase::getEnergy(%player);
	%armor = Player::getArmor(%player);

	%enVal  = 12.0;
	%energy = GameBase::getEnergy(%player);
	%energy = %energy - %enVal;
	
    	if (%energy > 8.0)
	{
		GameBase::setEnergy(%player,%energy);
		
		%client = GameBase::getOwnerClient(%player);
		//Player::decItemCount(%player,$WeaponAmmo[Blaster],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		//%newEnergy = %Ammo - 18;
		//GameBase::setEnergy(%player,%newEnergy);
		if(GameBase::getLOSInfo(%player,1000)) 
		{
			%object = getObjectType($los::object);
			%targetId = GameBase::getOwnerClient($los::object);
			
	
			if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "Sensor")
			{			 
					
				%armor = Player::getArmor(%object);
				%name = Client::getName(%targetId);
				//Tracker(%client,%targetId);
				if(%targetId) 
				{
					//%name = Client::getName(%clientId);
					Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " has a Blaster Lock!~waccess_denied.wav");
					schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
					schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
					schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
				}
				Client::sendMessage(%client,0,"~wmine_act.wav");
				$WeapTarget[%player] = $los::object;
				Projectile::spawnProjectile("BlasterTracker",%trans,%player,%vel,$los::object);
			}
			else
			{
				//Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...Reinitializing Tracking System");
				if ($WeapTarget[%player] >0)
				{
					%object = $WeapTarget[%player];
					Projectile::spawnProjectile("BlasterTracker",%trans,%player,%vel,%object);
				}
				else 
				{
					Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel,%player);
				}
			}
		}
		else
		{
			if ($WeapTarget[%player] >0)
			{
				%object = $WeapTarget[%player];
				Projectile::spawnProjectile("BlasterTracker",%trans,%player,%vel,%object);
			}
			//Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...Reinitializing Tracking System");
			else 
			{
				Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel,%player);
			}
		}
	}
	else
	{
		playSound(SoundPackFail,GameBase::getPosition(%player));
		Player::trigger(%player,$WeaponSlot,false);
	}
	//return false;
} //=== End standard missile fire.




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
   price = 75;
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
	spinUpTime = 0.4;
	spinDownTime = 3;
	fireTime = 0.1;

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
	price = 100;
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
	price = 125;
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
	price = 175;
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
	price = 300;
	showWeaponBar = true;
};

//======================================================================== Rocket Launcher

ItemData RocketAmmo 
{
	description = "Rocket Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RocketImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0;
	ammoType = RocketAmmo;
	//projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RocketImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	 %armor = Player::getArmor(%player);

		 if(%Ammo) 
		 {
			 %client = GameBase::getOwnerClient(%player);
			 Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);
		
			 if(GameBase::getLOSInfo(%player,1000)) 
			 {
				 %object = getObjectType($los::object);
				 %targetId = GameBase::getOwnerClient($los::object);
	
				if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "Sensor")
				 {			 
					
					%armor = Player::getArmor(%object);
					
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker(%client,%targetId);
						Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("StingerMissileTracker",%trans,%player,%vel,$los::object);
					}
					else
					{
						Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...Reinitializing Tracking System");
						Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
					}
				 }
				 else
				 {
					 Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...Reinitializing Tracking System");
					 Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				 }
		 	}
			else
			{
				Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...Reinitializing Tracking System");
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
			}
		}
		else
			Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Rocket Launcher");
	} //=== End standard missile fire.

ItemData RocketLauncher
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 350;
	showWeaponBar = true;
};

function Tracker(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " has a Missile Lock!~waccess_denied.wav");
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
} 

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 9;  // Energy used/sec for sustained weapons

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
	price = 100;
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
	price = $RemoteInvEnergy;
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

//------------------------------------------------

ItemImageData FakeFlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};
};

ItemData FakeFlag
{
        description = "Flag Decoy";
	shapeFile = "flag";
        imageType = FakeFlagImage;
	className = "Backpack";
        heading = "cBackpacks";
        showInventory = true;
	shadowDetailMask = 4;
        price = 75;

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

function FakeFlag::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
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
	price = 100;
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
	price = 125;
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
}

//----------------------------------------------------------------------------	
ItemImageData LaptopImage
{
	shapeFile = "grenammo";
	weaponType = 2;  // Sustained

	mountPoint = 2;
  	mountOffset = { 0, 0.08, 0.2 };
  	mountRotation = { 1.5, 0, 0 };
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData Laptop
{
	description = "Command Laptop";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LaptopImage;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Laptop::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function Laptop::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Laptop::onUnmount(%player,%item)
{
//	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
//		Player::unmountItem(%player,$WeaponSlot);
}

//----------------------------------------------------------------------------

ItemImageData HeatSinkImage
{
	shapeFile = "jetPack"; 
	weaponType = 2; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, 0.15 }; 
	mountRotation = { 0, 3.14159, 0 }; 
	minEnergy = 0; 
	maxEnergy = 0; 
	firstPerson = false; 
}; 

ItemData HeatSink 
{ 
	description = "Heat Sink"; 
	shapeFile = "jetPack"; 
	className = "Backpack"; 
	heading = "cBackpacks"; 
	shadowDetailMask = 4; 
	imageType = HeatSinkImage; 
	price = 175; 
	hudIcon = "targetlaser"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function HeatSink::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
} 

function HeatSink::onMount(%player,%item) 
{ 
	Player::trigger(%player,$BackpackSlot,true); 
} 

//----------------------------------------------------------------------------

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = -1;
 	maxEnergy = -3;
	
   	mountOffset = { 0, -0.03, 0 };
//   	mountRotation = { 1.57, 0, 0 };
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
	price = 200;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function AmmoPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Ammo pack allows you to carry more ammo, as well as providing an auxilliary power supply for your energy weapons.");
}

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 13 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			//echo("Item.cs line 2227");
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) 
			{
	 	    		%item.BulletAmmo = %numPack;
			}
			else if(%i == 1) 
			{
	 	    		%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 2) 
			{
	 	    		%item.DiscAmmo = %numPack;
			}
			else if(%i == 3) 
			{
	 	    		%item.GrenadeAmmo = %numPack;
			}
			//else if(%i == 4) {
	 	    	//%item.Grenade = %numPack;
			//}
			else if(%i == 4) 
			{
	 	    		%item.MortarAmmo = %numPack;
			}
			else if(%i == 5) 
			{
	 	    		%item.RocketAmmo = %numPack;
			}
			else if(%i == 6) 
			{
	 	    		%item.RepairKit = %numPack;
			}
			else if(%i == 7)
			{
	 	    		%item.MineAmmo = %numPack;
			}
			//else if(%i == 8)
			//{
			//	%item.Beacon = %numPack;
			//}
			else if(%i == 9)
			{
				%item.EMPGrenadeAmmo = %numPack;
			}
			else if(%i == 10)
			{
				%item.ShotgunShells = %numPack;
			}
			else if(%i == 11)
			{
				%item.MarlinAmmo = %numPack;
			}
			else
			{
				%item.MinelAmmo = %numPack;
			}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		//echo("Item.cs line 2296");
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
		if(%i == 0) 
		{
	        	%numAdd = %item.BulletAmmo;
		}
		else if(%i == 1) 
		{
	    		%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 2) 
		{
	    		%numAdd = %item.DiscAmmo;
		}
		else if(%i == 3) 
		{
	    		%numAdd = %item.GrenadeAmmo;
		}
		//else if(%i == 4) 
		//{
	    	//%numAdd = %item.Grenade;
		//}
		else if(%i == 4) 
		{
 	    		%numAdd = %item.RocketAmmo;
		}
		else if(%i == 5) 
		{
 	    		%numAdd = %item.MortarAmmo;
		}
		else if(%i == 6) 
		{
 	    		%numAdd = %item.RepairKit;
		}
		else if(%i == 7)
		{
			%numAdd = %item.MineAmmo;
		}
		//else if(%i == 8)
		//{
		//	%numAdd = %item.MineAmmo;
		//}
		else if(%i == 9)
		{
			%numAdd = %item.EMPGrenadeAmmo;
		}
		else if(%i == 10)
		{
			%numAdd = %item.ShotgunShells;
		}
		else if(%i == 11)
		{
			%numAdd = %item.MarlinAmmo;
		}
		else
		{
			%numAdd = %item.MinelAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 13 ; %i = %i +1) 
	{
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) 
		{
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
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
	price = 225;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 25;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 25;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
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
	price = 75;
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

function getammo(%obj)
{
	%ammo = 2;
	%armor = player::GetArmor(%obj);
	if(%armor==hlarmor) %ammo =2;
	if(%armor==hlfemale) %ammo =2;
	if(%armor==larmor) %ammo =3;
	if(%armor==lfemale) %ammo =3;
	if(%armor==marmor) %ammo =4;
	if(%armor==mfemale) %ammo =4;
	if(%armor==harmor) %ammo =5;
	if(%armor==earmor) %ammo =6;
	if(%armor==efemale) %ammo =6;
	return %ammo;
}


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
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	$Ammo[%item] = getAmmo(%player);
	Bottomprint(%client, "The Motion Sensor pack allows deployment of up to 6 motion sensors (depending on your Armour) which will detect any moving enemy Armour.");
}

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
	if (MotionSensorPack::deployShape(%player,%item)) 
	{
		$Ammo[%item] = $Ammo[%item] - 1;
		if ($Ammo[%item] == 0) Player::decItemCount(%player,%item);
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


function PulseSensorPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	$Ammo[%item] = getAmmo(%player);
	Bottomprint(%client, "The Pulse Sensor pack allows deployment of up to 6 pulse sensors (depending on your Armour) which will detect Armour not protected by sensor jammers.");
}


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
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) 
	{
		$Ammo[%item] = $Ammo[%item] - 1;
		if ($Ammo[%item] == 0) Player::decItemCount(%player,%item);
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
  	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	$Ammo[%item] = getAmmo(%player);
	Bottomprint(%client, "The Sensor Jammer pack allows deployment of up to 6 sensor jammers (depending on your Armour) which will defeat any pulse sensors within the jammer area.");
}


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
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) 
	{
		$Ammo[%item] = $Ammo[%item] - 1;
		if ($Ammo[%item] == 0) Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}

//----------------------------------------------------------------------------

ItemImageData ForceFieldPackImage
{
shapeFile = "shieldPack";
mountPoint = 2;
firstPerson = false;
};
ItemData ForceFieldPack
{
description = "Light Field Door 5x5";
shapeFile = "shieldpack";
className = "Backpack";
heading = "pDoors";
imageType = ForceFieldPackImage;
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 250;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function ForceFieldPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}

function ForceFieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "A smaller, lighter version of the field doors, this forcefield may be placed in vertical or horizontal configurations.  Much weaker than the other door, it does regenerate slowly.");
}



function ForceFieldPack::onDeploy(%player,%item,%pos)
{
if (ForceFieldPack::deployShape(%player,"Force Field",DeployableForceField,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployableForceField"]++;
}
}
function CreateForceFieldSimSet()
{
%teleset = nameToID("MissionCleanup/ForceFields");
if(%teleset == -1)
{
newObject("ForceFields",SimSet);
addToSet("MissionCleanup","ForceFields");
}
}
function ForceFieldPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableForceField"] < $TeamItemMax[DeployableForceField]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
echo("::"@GameBase::getDataName($los::object)@"::");
if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object)=="DeployableLargeForceField" 
||GameBase::getDataName($los::object)=="DeployableForceField") {
					if(0 == %num) 
					{
						%prot = GameBase::getRotation(%player);
						%zRot = getWord(%prot,2);
						if (Vector::dot($los::normal,"0 0 1") > 0.6) 
						{
							%rot = "0 0 " @ %zRot;
						}
						else 	
						{
							if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
							{
								%rot = "3.14159 0 " @ %zRot;
							}
							else 
							{
								%rot = Vector::getRotation($los::normal);
							}
						}
if(checkForceFieldDeployArea(%client,$los::position)) 
{
	%obj = getObjectType($los::object);
	%num=FieldDoorCheck($los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight);
	if($MaxNumTurretsInBox > %num) {
		%num=FieldDoorCheck($los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight);
		if(0 == %num) 
		{
			%sensor = newObject("Force Field","StaticShape",%shape,true);
			CreateForceFieldSimSet();
			addToSet("MissionCleanup/ForceFields", %sensor);
			addToSet("MissionCleanup", %sensor);
			GameBase::setTeam(%sensor,GameBase::getTeam(%player));
			GameBase::setPosition(%sensor,$los::position);
			GameBase::setRotation(%sensor,%rot);
			Gamebase::setMapName(%sensor,%name);
			Client::sendMessage(%client,0,%item.description @ " deployed");
			%sensor.disabled = false;
			%sensor.activated=false;
			GameBase::setAutoRepairRate(%sensor,$ForceFieldPack::RechargeRate);
			echo("Force Field Deployed ("@%sensor@")");
			playSound(SoundPickupBackpack,$los::position);
			GameBase::startfadein(%sensor);
			return true;
		} 
		else
		Client::sendMessage(%client,0,"Flux Instability - Too close to other forcefields");
	}
	else 
	Client::sendMessage(%client,0,"Quantum destabilization caused by other forcefields in the area");
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
	description = "Sentry Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TurretPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Sentry turret is the basic deployable turret.");
}


function TurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
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

function TurretPack::onDeploy(%player,%item,%pos)
{
	if (TurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableElfTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableElfTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num) 
					{
						%prot = GameBase::getRotation(%player);
						%zRot = getWord(%prot,2);
						if (Vector::dot($los::normal,"0 0 1") > 0.6) 
						{
							%rot = "0 0 " @ %zRot;
						}
						else 	
						{
							if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
							{
								%rot = "3.14159 0 " @ %zRot;
							}
							else 
							{
								%rot = Vector::getRotation($los::normal);
							}
						}
						if(checkDeployArea(%client,$los::position)) 
						{
							
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
						        if ($TurretScore == "True")
						        {
						        	Client::setOwnedObject(%client, %turret);
						        	Client::setOwnedObject(%client, %player);
						        }
							return true;
						}
					}	 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other turrets");
				}
				else 
					Client::sendMessage(%client,0,"Interference from other turrets in the area");
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
// Deployable ELF Turret
//-----------------------------------

ItemImageData DeployableELFTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData DeployableELFTurretPack
{
	description = "Heavy Elf Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = DeployableELFTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableElfTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableElfTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num) 
					{
						%prot = GameBase::getRotation(%player);
						%zRot = getWord(%prot,2);
						if (Vector::dot($los::normal,"0 0 1") > 0.6) 
						{
							%rot = "0 0 " @ %zRot;
						}
						else 	
						{
							if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
							{
								%rot = "3.14159 0 " @ %zRot;
							}
							else 
							{
								%rot = Vector::getRotation($los::normal);
							}
						}
						if(checkDeployArea(%client,$los::position)) 
						{
							
							%turret = newObject("remoteTurret","Turret",DeployableElfTurret,true);
	                     					addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"Shock Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"ELF Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "DeployableELFTurretPack"]++;
							echo("MSG: ",%client," deployed an ELF Turret");
							//	Remote turrets - kill points to player that deploy them
						        if ($TurretScore == "True")
						        {
						        	Client::setOwnedObject(%client, %turret);
							       	Client::setOwnedObject(%client, %player);
						        }
							return true;
						}
					}	 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other turrets");
				}
				else 
					Client::sendMessage(%client,0,"Interference from other turrets in the area");
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

//-----------------------------------------------------
//-=-=-=-=-=-=-=-=- Deployable Rocket Turret -=-=-=-=-
//-----------------------------------------------------
						
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
	description = "Missile Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = RocketPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Missile Turret is a deployable version of it's big brother.  Great for aerial defense.");
}


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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableElfTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableElfTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num) 
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							%prot = GameBase::getRotation(%player);
							%zRot = getWord(%prot,2);
							if (Vector::dot($los::normal,"0 0 1") > 0.6) 
							{
								%rot = "0 0 " @ %zRot;
							}
							else 	
							{
								if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
								{
									%rot = "3.14159 0 " @ %zRot;
								}
								else 
								{
									%rot = Vector::getRotation($los::normal);
								}
							}
							if(checkDeployArea(%client,$los::position)) 
							{
								
								%turret = newObject("remoteTurret","Turret",DeployableRocket,true);
	                     						addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Missile Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Missile Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
								echo("MSG: ",%client," deployed a Missile Turret");
								//	Remote turrets - kill points to player that deploy them
							        if ($TurretScore == "True")
							        {
							        	Client::setOwnedObject(%client, %turret);
							        	Client::setOwnedObject(%client, %player);
						        	}
								return true;
							}
						}
						else
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					}	 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other turrets");
				}
				else 
					Client::sendMessage(%client,0,"Interference from other turrets in the area");
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

function checkForceFieldDeployArea(%client,%pos)
{
%set=newObject("set",SimSet);
%tpos=Vector::add(%pos,"0 0 -5000");
%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%tpos,1,1,1,1);
if(%num) {
Client::sendMessage(%client,0,"Unable to deploy - Moving object already present here.");
deleteObject(%set);
return(0);
}
deleteObject(%set);
%set=newObject("set",SimSet);
%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
if(!%num) {
deleteObject(%set);
return 1;
}
if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "StaticShape" && (GameBase::getDataName(Group::getObject(%set,0)) == "DeployableForceField"
|| GameBase::getDataName(Group::getObject(%set,0)) == "DeployableLargeForceField"
||GameBase::getDataName(Group::getObject(%set,0)) == "DeployableBlastDoor")) { 
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
   	heading = "tTools";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 25;
	showWeaponBar = false;
};

//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "tTools";
   shadowDetailMask = 4;
   price = 15;
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
	showInventory = false;
	description = "Grenade";
	shapeFile = "grenade";
//	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

ItemData OriginalGrenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
   className = "Grenade";
};

ItemData Plastique
{
   description = "Plastique";
   shapeFile = "armorPack";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
   className = "Grenade";
};

ItemData EMPGrenade
{
   description = "EMPGrenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
   className = "Grenade";
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) 
	{
		if(%player.throwTime < getSimTime() ) 
		{
			%clientId = Player::getClient(%player);
			//echo("Item.cs line 3540");
			if(Player::getItemCount(%player, OriginalGrenade) > 0)
			{
				%item = OriginalGrenade;
				%name = "Handgrenade";
				%chuckmod = 1;
			}
			else if(Player::getItemCount(%player, Plastique) > 0)
			{
				%item = Plastique;
				%name = "Nukebomb";
				%chuckmod = 0.5;
			}
			else if(Player::getItemCount(%player, EMPGrenade) > 0)
			{
				%item = EMPGrenade;
				%name = "EMPHandGrenade";
				%chuckmod = 1;
			}
			else return;
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
			%obj = newObject("","Mine",%name);
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength * %chuckmod,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}



//----------------------------------------------------------------------------
//------------------------------------------------
//Attempt at modifying the beacon
//------------------------------------------------

ItemImageData BeaconImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

//ItemData Beacon
//{
//	description = "Beacon";
//	shapeFile = "sensor_small";
//	className = "HandAmmo";
//   	heading = "eMiscellany";
//	imageType = RocketPackImage;
//	shadowDetailMask = 4;
//	mass = 3.0;
//	elasticity = 0.2;
//	price = 400;
//	hudIcon = "deployable";
//	showWeaponBar = true;
//	hiliteOnActive = true;
//};

//function Beacon::onMount(%player,%item)
//{
//	%client = Player::getClient(%player);
//	Bottomprint(%client, "The HunterSeeker is a deployable version of it's big brother.  Great for aerial defense.");
//}


//function Beacon::onUse(%player,%item)
///{
//	//if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
//	//	Player::mountItem(%player,%item,$BackpackSlot);
//	//}
//	//else {
//		Player::deployItem(%player,%item);
//	//}
//}

function Beacon::onDeploy(%player,%item,%pos)
{
	if (Beacon::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

//function Beacon::deployShape(%player,%item)
//{
//	%client = Player::getClient(%player);
//	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
//	{
//		if (GameBase::getLOSInfo(%player,3)) 
//		{
//			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
//			{
//	    			%set = newObject("set",SimSet);
//				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
//					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableElfTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
//				deleteObject(%set);
//				if($MaxNumTurretsInBox > %num)
//				{
//		    			%set = newObject("set",SimSet);
//					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
//					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableElfTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
//					deleteObject(%set);
//					if(0 == %num) 
//					{
//						%prot = GameBase::getRotation(%player);
//						%zRot = getWord(%prot,2);
//						if (Vector::dot($los::normal,"0 0 1") > 0.6) 
//						{
//							%rot = "0 0 " @ %zRot;
//						}
//						else 	
//						{
//							if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
//							{
//								%rot = "3.14159 0 " @ %zRot;
//							}
//							else 
//							{
//								%rot = Vector::getRotation($los::normal);
//							}
//						}
//						if(checkDeployArea(%client,$los::position)) 
//						{
//							
//							%turret = newObject("remoteTurret","Turret","DefaultBeacon",true);
//	                     					addToSet("MissionCleanup", %turret);
//							GameBase::setTeam(%turret,GameBase::getTeam(%player));
//							GameBase::setPosition(%turret,$los::position);
//							GameBase::setRotation(%turret,%rot);
//							Gamebase::setMapName(%turret,"HunterSeeker#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
//							Client::sendMessage(%client,0,"HunterSeeker deployed");
//							playSound(SoundPickupBackpack,$los::position);
//							$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
//							echo("MSG: ",%client," deployed a Missile Turret");
//							//	Remote turrets - kill points to player that deploy them
//						        if ($TurretScore == "True")
//						        {
//						        	Client::setOwnedObject(%client, %turret);
//						        	Client::setOwnedObject(%client, %player);
//						        }
//						        $lbot=0;
//						        //lbot(%client);
//							return true;
//						}
//					}	 
//					else
//						Client::sendMessage(%client,0,"Frequency Overload - Too close to other turrets");
//				}
//				else 
//					Client::sendMessage(%client,0,"Interference from other turrets in the area");
//			}
//			else 
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
//		}
//		else 
//			Client::sendMessage(%client,0,"Deploy position out of range");
//	}
//	else																						  
//	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
//		return false;
//}

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
   	heading = "tTools";
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
// Cloaking Device - 
//----------------------------------------------------------------------------

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 13;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

function CloakingDevice::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "While in operation, you will be invisible to other players, and to pulse sensors, but not to motion sensors.");
}

ItemData CloakingDevice
{
	description = "Cloaking Device";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 250;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	%radius = Player::getSensorSupression(%player) + 1;
	Player::setSensorSupression(%player,%radius);
	GameBase::playSound(%player,ForceFieldOpen,0);
 	GameBase::startFadeout(%player);
 	$cloaked[%player] = 1;
 	Cloaker(%player);
 	%ClientId = Player::getClient(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
	Player::trigger(%player,$BackpackSlot,true);
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{
	%radius = Player::getSensorSupression(%player) - 1;
	Player::setSensorSupression(%player,%radius);
	GameBase::playSound(%player,ForceFieldOpen,0);
 	GameBase::startFadein(%player);
 	$cloaked[%player] = 0;
 	Cloaker(%player);
 	//GameBase::setIsTarget(%player, True);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------
// Teleport Pack
//----------------------------------------------------------------------------

ItemImageData TeleportPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, 0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	
	sfxReady = SoundShieldOn;
	sfxFire = ForceFieldOpen;
	//explosionTag     = LargeShockwave;
};

ItemData TeleportPack
{
	description = "Teleport Pack";
	className = "Backpack";
	shapeFile = "sensor_small";
	hudIcon = "energypack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = TeleportPackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = true;
	
};

function TeleportPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	//gamebase::playsound(%item,SoundTeleportPower);
	Bottomprint(%client, "Upon activation, the Teleport Pack will instantly transport you and any nearby teammates to your current waypoint.  Use at your own risk, the Teleport Pack is still in the experimental stage.");
}


function TeleportPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	//%waypoint= $WayX @ " " @ $WayY;
	%waypoint= $point[%client];
	if (%waypoint== " 0 0" || !%waypoint)
	{
		Client::sendMessage(%client,1,"The Teleport Pack has no waypoint to lockon to.  Transport aborted.");
		Player::trigger(%player,$BackpackSlot,false);
	}
	else
	{
		%teamspot = WaypointToWorld(%waypoint);
		%vertical = "0 0 400";
 		%teamspot = Vector::add(%teamspot,%vertical);
 		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$ItemObjectType,%teamspot,100,100,800,0);
		%num2 = CountObjects(%set,"flag",%num);
		//Client::sendMessage(%client,1,"Waypoint: "@ %waypoint);
		%totalnum = Group::objectCount(%set);
		%enemyflag=0;
		for(%i = 0; %i < %totalnum; %i++)
		{
			%obj = Group::getObject(%set, %i);
			%name = Item::getItemData(%obj);
			//client::sendMessage(Player::getClient(%player),1,"Itemdata: "@ %i @ " " @ %name);
			if(%name == "flag")
			{
				if(GameBase::getTeam(%obj) != Gamebase::getTeam(%player)) %enemyflag = %enemyflag+1;
			}
		}
		deleteObject(%set);
		if (%enemyflag == 0)
		{
			if(!$TeleUsed[%player]) 
			{
				GameBase::playSound(%player,ForceFieldOpen,0);
				//Client::sendMessage(Player::getClient(%player),3,"You successfully teleported!");
				Client::sendMessage(Player::getClient(%player),3,"Your armor's teleport module is now recharging.");
				%client = Player::getClient(%player);
				%object = Client::getOwnedObject(%client);
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$SimPlayerObjectType,GameBase::getPosition(%player),5,5,5,0);
				%totalnum = Group::objectCount(%set);
				//Client::sendMessage(Player::getClient(%player),1,"There are "@ %totalnum @ " players near your jump point");
				%destinationspot[%player]=%teamspot;
				%mass=0;
				$point[%client]=" 0 0";
				for(%i = 0; %i < %totalnum; %i++)
				{
				 	%obj = Group::getObject(%set, %i);
				 	if(GameBase::GetTeam(%obj) == GameBase::GetTeam(%player))
					{
				 		%mass=%mass+getmass(%obj);
				 		if (%obj != %player)
				 		{
				 			%posobj = GameBase::getPosition(%obj);
				 			%posplayer = GameBase::getPosition(%player);
				 			%resultant = Vector::sub(%posplayer, %posobj);
				 			//Client::sendMessage(Player::getClient(%player),1,"vector to object: "@ %resultant @ " Dist: " @ %dist);
				 			%destinationspot[%obj]=Vector::add(%teamspot,%resultant);
				 		}
				 	}
				}
				%rnd = floor(getRandom() * 55);
				for(%i = 0; %i < %totalnum; %i++)
				{
				 	
				 	%obj = Group::getObject(%set, %i);
				 	if(GameBase::GetTeam(%obj) == GameBase::GetTeam(%player))
					{
				 		%hasflag = Player::getMountedItem(%obj, 2);
				 		%armor = player::GetArmor(%obj);
				 		%PackClient = Player::getClient(%player);
				 		if(%hasflag!=-1 && %hasflag!="DeadWeight")
						{
							Player::dropItem(%obj, %hasflag);
							Client::sendMessage(Player::getClient(%obj),1,"While teleporting, you dropped the flag...");
						}
						if (%rnd > %mass)
						{
							if (%armor !=harmor || %armor != earmor || %armor != efemale || %armor != botarmor)
							{
				 				TeleportPlayer(%obj,%destinationspot[%obj]);
				 				Client::sendMessage(Player::getClient(%obj),3,"You successfully teleported!");
				 				//Client::sendMessage(Player::getClient(%player),1,"Total Mass: "@ %mass @ " Rnd: " @ %rnd);
				 				GameBase::playSound(%obj,ForceFieldOpen,0);
				 			}
				 		}
				 		else
				 		{
				 			TeleportPlayer(%obj,%destinationspot[%obj]);
				 			%damagedClient = Player::getClient(%obj);
				 			Client::sendMessage(Player::getClient(%obj),1,"Malfunction in transport subsystem!");
				 			GameBase::applyDamage(%obj,$ExplosionDamageType,40,%destinationspot[%obj],"0 0 0","0 0 0",%damagedClient);
				 			//Player::kill(%obj);
				 			if(%damagedClient.lastDamage < getSimTime()) 
							{
								%sound = radnomItems(3,injure1,injure2,injure3);
								playVoice(%damagedClient,%sound);
								%damagedClient.lastdamage = getSimTime() + 1.5;
							}
				 			Player::blowUp(%obj);
				 		}
					}
				}
				//bottomprintall("Total Mass: " @ %mass,0)
				deleteObject(%set);
				setCommandStatus(%client, 0, "Objective completed.~wobjcomp");
				//Client::sendMessage(Player::getClient(%player),1,"Position" @ GameBase::getPosition(%player));
				Player::trigger(%player,$BackpackSlot,false);
				$TeleUsed[%player] = true;
			        %time = 45; //30
				schedule("TelePackCooling(" @ %time @ ", " @ %player @ ");", 1, %player);
			}
			else 
			{
				Client::sendMessage(Player::getClient(%player),1,"Your armor's teleport module is still recharging.");
				Player::trigger(%player,$BackpackSlot,false);
			}
	
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Your waypoint is too near an enemy flag.  Teleport not possible.");
			Player::trigger(%player,$BackpackSlot,false);
		}
	}
	
}

function TeleportPackImage::onDeactivate(%player, %imageSlot)
{
	//TeleportPackImage::onActivate(%player, %imageSlot);
}

function getmass(%obj)
{
	%mass = 13;
	%armor = player::GetArmor(%obj);
	if(%armor==hlarmor) %mass =7;
	if(%armor==hlfemale) %mass =7;
	if(%armor==larmor) %mass =9;
	if(%armor==lfemale) %mass =9;
	if(%armor==marmor) %mass =13;
	if(%armor==mfemale) %mass =13;
	//if(%armor==harmor) %mass =18;
	//if(%armor==earmor) %mass =13;
	//if(%armor==efemale) %mass =13;
	return %mass;
}


function TeleportPlayer(%player,%tportspot)
{
	%vel = Item::getVelocity(%player);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
 	Projectile::spawnProjectile("TeleportShock",%trans,%player,%vel,%player);
	Player::setDamageFlash(%player, 0.4);
	GameBase::startFadein(%player);
	%camera = newObject("Camera","Turret",cameraturret,true);
	GameBase::setPosition(%camera,%tportspot);
	GameBase::getLOSInfo(%camera,600,"-1.5708 0 0");
	DeleteObject(%camera);
	GameBase::setPosition(%player, $los::position);
	%vel = Item::getVelocity(%player);
	%trans = "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%player);
 	Projectile::spawnProjectile("TeleportShock",%trans,%player,%vel,%player);
}



function TelePackCooling(%time, %player)
{
	if(%time > 0)
	{
		schedule("TelePackCooling( " @ %time - 1 @ ", " @ %player @ ");", 1, %player);
	}
	else if(%time == 0)
	{
		TeleReset(%player);
	}
}

function TeleReset(%player)
{
	$TeleUsed[%player] = false;
	Client::sendMessage(Player::getClient(%player),3,"Teleport module is now available...");
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
	price = 325;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Shield Pack converts your energy supply into a protective shield.  You aren't damaged as long as the shield holds out.");
}


function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.012;
	Player::trigger(%player,$BackpackSlot,true);
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%FoundOne = 0;
	for (%i = 1; %i < $ShieldGen+1; %i++)
	{
	  	%object = $ShieldGenObject[%i];
	  	%matrix = %this @ %player;
	  	if ($oldShieldGen[%matrix] == 1) %FoundOne = 1;
	  	//echo("$oldshieldgen[" @ %matrix @ "] = 0");
   	}
	if (%FoundOne == 0) %player.shieldStrength = 0;
	else %player.shieldStrength = 0.005;
}

//-------------------------------------
// Kamikaze Pack
//-------------------------------------
ItemImageData KamikazePackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, 0, 0 };
  	mountRotation = { -1.5, 0, 0 };
	firstPerson = false;
	weaponType = 2;  // Sustained
    	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
};

ItemData KamikazePack
{
	description = "Kamikaze Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = KamikazePackImage;
	price = 350;
	hudIcon = "grenade";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function KamikazePack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Be the divine wind.");
}


function KamikazePackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"Kamikaze Pack Initialized!!!");
	$KamikazeIsActive[%player] = "true";
	KamikazePackCount(%player);
	Player::trigger(%player,$BackpackSlot,false);
}

function KamikazePackImage::onDeactivate(%player,%imageSlot)
{
}

function KamikazePackCount(%player)
{
	///echo(%player);
		if($KamikazeIsActive[%player]) {
			%obj = newObject("","Mine","KamikazeBomb");
 			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj, GameBase::getTeam(%player));
			GameBase::throw(%obj,%player,-1,false);
		}
		$KamikazeIsActive[%player] = "false";
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
			//echo("Item.cs line 4273");
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
	$TeamItemCount[0 @ DeployableForceField] = 0;
	$TeamItemCount[0 @ RocketPack] = 0;
	$TeamItemCount[0 @ DeployableELFTurretPack] = 0;

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
	$TeamItemCount[1 @ DeployableForceField] = 0;
	$TeamItemCount[1 @ RocketPack] = 0;
	$TeamItemCount[1 @ DeployableELFTurretPack] = 0;

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
	$TeamItemCount[2 @ DeployableForceField] = 0;
	$TeamItemCount[2 @ RocketPack] = 0;
	$TeamItemCount[2 @ DeployableELFTurretPack] = 0;

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
	$TeamItemCount[3 @ DeployableForceField] = 0;
	$TeamItemCount[3 @ RocketPack] = 0;
	$TeamItemCount[3 @ DeployableELFTurretPack] = 0;

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
	$TeamItemCount[4 @ DeployableForceField] = 0;
	$TeamItemCount[4 @ RocketPack] = 0;
	$TeamItemCount[4 @ DeployableELFTurretPack] = 0;

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
	$TeamItemCount[5 @ DeployableForceField] = 0;
	$TeamItemCount[5 @ RocketPack] = 0;
	$TeamItemCount[5 @ DeployableELFTurretPack] = 0;

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
	$TeamItemCount[6 @ DeployableForceField] = 0;
	$TeamItemCount[6 @ RocketPack] = 0;
	$TeamItemCount[6 @ DeployableELFTurretPack] = 0;

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
	$TeamItemCount[7 @ DeployableForceField] = 0;
	$TeamItemCount[7 @ RocketPack] = 0;
	$TeamItemCount[7 @ DeployableELFTurretPack] = 0;

	for(%i = 0; %i < 8; %i++)
	{
		$TeamItemCount[%i @ ChaingunTurretPack] = 0;
		$TeamItemCount[%i @ DShieldPack] = 0;
		$TeamItemCount[%i @ DShield] = 0;
		$TeamItemCount[%i @ DeployableTeleport] = 0;
		$TeamItemCount[%i @ DeployableTeleportPack] = 0;
		$TeamItemCount[%i @ FlakPack] = 0;
		$TeamItemCount[%i @ ConPack] = 0;
		//$TeamItemCount[%i @ DeployableConTurret] = 0;
		$TeamItemCount[%i @ SeekerPack] = 0;
		$TeamItemCount[%i @ DeployableSeeker] = 0;
		$TeamItemCount[%i @ FlameTurretPack] = 0;
		//$TeamItemCount[%i @ FlameTurret] = 0;
		//$TeamEnergy[%i] = $DefaultTeamEnergy;
		$TeamItemCount[%i @ TreePack] = 0;
		$TeamItemCount[%i @ DoBPack] = 0;
		$TeamItemCount[%i @ PlasmaPack] = 0;
		$TeamItemCount[%i @ BaseAlarm] = 0;
		$totalNumAlarms[%i] = 0;
		$TeamItemCount[%i @ DeployableLRMotionSensorPack] = 0;
		$TeamItemCount[%i @ LaserPack] = 0;
		//$TeamItemCount[%i @ DeployableLaser] = 0;
		$TeamItemCount[%i @ ShockPack] = 0;
		//$TeamItemCount[%i @ DeployableShock] = 0;
		$TeamItemCount[%i @ BlastWall] = 0;
		$TeamItemCount[%i @ HoloPack] = 0;
                	//$TeamEnergy[%i] = $DefaultTeamEnergy;
		$TeamItemCount[%i @ Springboard] = 0;
		$TeamItemCount[%i @ SuicidePack] = 0;
		$TeamItemCount[%i @ RailTurret] = 0;
		$TeamItemCount[%i @ doorthreebyfourForceFieldPack] = 0;
		$TeamItemCount[%i @ doorfourbyfourteenForceFieldPack] = 0;
		$TeamItemCount[%i @ doorfourbyseventeenForceFieldPack] = 0;
		$TeamItemCount[%i @ doorfourbyeightForceFieldPack] = 0;
		$TeamItemCount[%i @ doorfivebyfiveForceFieldPack] = 0;
	}





	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}


//Minimod plugins

// This is a MiniMod Plugin.
// This is the Base Alarm from the Redneck Slag Pack mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    BaseAlarm.ArmorData.cs
//    BaseAlarm.item.cs
//    BaseAlarm.reinitData.cs
//    BaseAlarm.staticshape.cs
//    BaseAlarm.station.cs
//
// to your MiniMod/plugins directory.

$totalNumAlarms[-1] = 0;
$totalNumAlarms[0] = 0;
$totalNumAlarms[1] = 0;
$totalNumAlarms[2] = 0;
$totalNumAlarms[3] = 0;
$totalNumAlarms[4] = 0;
$totalNumAlarms[5] = 0;
$totalNumAlarms[6] = 0;
$totalNumAlarms[7] = 0;

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

function BaseAlarm::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Similar to a turret, but instead of firing at an intruder, it sends team messages to alert players of the intruder's presence.");
}


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
				//%alarm = newObject("","StaticShape", "AlarmKit",true);
				%alarm = newObject("","Turret", "DeployableAlarm",true);
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

	$TeamItemCount[0 @ BaseAlarm] = 0;
	$TeamItemCount[1 @ BaseAlarm] = 0;
	$TeamItemCount[2 @ BaseAlarm] = 0;
	$TeamItemCount[3 @ BaseAlarm] = 0;
	$TeamItemCount[4 @ BaseAlarm] = 0;
	$TeamItemCount[5 @ BaseAlarm] = 0;
	$TeamItemCount[6 @ BaseAlarm] = 0;
	$TeamItemCount[7 @ BaseAlarm] = 0;


///-----------------------------------------------
/// Description - "Blast Wall";
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------



ItemImageData BlastWallImage
{
        shapeFile = "newdoor5";
        mountPoint = 2;
        mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData BlastWall
{
        description = "Blast Wall";
        shapeFile = "newdoor5";
        className = "Backpack";
        heading = "nDeployable Walls";
        imageType = BlastWallImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BlastWall::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Blast Wall is a nearly indestructable wall.  Use it to protect vital equipment.");
}



function BlastWall::onUse(%player,%item)
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

function BlastWall::onDeploy(%player,%item,%pos)
{
        if (BlastWall::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function BlastWall::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
        	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
                	if (GameBase::getLOSInfo(%player,3)) 
		{
			if(checkDeployArea(%client,$los::position))
			{	
				//%obj = getObjectType($los::object);
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,3,3,6,0);
				%num = CountObjects(%set,"BlastWallShape",%num);
				deleteObject(%set);
				if(0 == %num)
				{
					if (checkbase($los::position,$los::object,%player) == true)
					{
                    				%obj = getObjectType($los::object);
                                		%rot = GameBase::getRotation(%player);
						%rotchange = "1.57 0 0";
						%rot = Vector::add(%rot, %rotchange);
                                        	%camera = newObject("BlastWall","StaticShape",BlastWallShape,true);
                                        	addToSet("MissionCleanup", %camera);
                                       		GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                      		GameBase::setRotation(%camera,%rot);
						%deploypos=Vector::add($los::position, "0 0 3");
                                        	GameBase::setPosition(%camera,%deploypos);
                                       		Gamebase::setMapName(%camera,"Wall#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                      		Client::sendMessage(%client,0,"Wall deployed");
                                      		playSound(SoundPickupBackpack,$los::position);
                                       		$TeamItemCount[GameBase::getTeam(%camera) @ "BlastWall"]++;
                                        	echo("MSG: ",%client," deployed a Blast Wall");
                                        	return true;
                                        }
                                        else Client::sendMessage(%client, 0, "Cannot deploy, on enemy or neutral structure.");
				}
				else Client::sendMessage(%client, 0, "Cannot deploy. Too near other BlastWalls");	
			}
			else Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
        	}
                else Client::sendMessage(%client,0,"Cannot deploy here.");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

// This is a MiniMod Plugin.
// This plugin is the Chaingun Turret from the Bitchin mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    ChainTurret.ArmorData.cs
//    ChainTurret.baseProjData.cs
//    ChainTurret.item.cs
//    ChainTurret.reinitData.cs
//    ChainTurret.station.cs
//    ChainTurret.turret.cs
//
// to your MiniMod/plugins directory.



ItemImageData ChaingunTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ChaingunTurretPack
{
        description = "Chaingun Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "dDeployables";
        imageType = ChaingunTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
        price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ChaingunTurretPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Portable turret mounted with a chaingun.");
}


function ChaingunTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ChaingunTurretPack::onDeploy(%player,%item,%pos)
{
        if (ChaingunTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function ChaingunTurretPack::deployShape(%player,%item)
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

                              %turret = newObject("remoteTurret","Turret",DeployableChaingun,true);
                              addToSet("MissionCleanup", %turret);
		  	      GameBase::setTeam(%turret,GameBase::getTeam(%player));
		  	      GameBase::setPosition(%turret,$los::position);
		  	      GameBase::setRotation(%turret,%rot);
                              Gamebase::setMapName(%turret,"RMT Chaingun#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                              Client::sendMessage(%client,0,"Remote Chaingun Turret deployed");
		  	      playSound(SoundPickupBackpack,$los::position);
                              $TeamItemCount[GameBase::getTeam(%player) @ "ChaingunTurretPack"]++;
                              echo("MSG: ",%client," deployed a Remote Chaingun Turret");
					//	Remote turrets - kill points to player that deploy them
					if ($TurretScore == "True")
				        {
				        	Client::setOwnedObject(%client, %turret);
				        	Client::setOwnedObject(%client, %player);
				        }
					return true;
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



	$TeamItemCount[0 @ ChaingunTurretPack] = 0;
	$TeamItemCount[1 @ ChaingunTurretPack] = 0;
	$TeamItemCount[2 @ ChaingunTurretPack] = 0;
	$TeamItemCount[3 @ ChaingunTurretPack] = 0;
	$TeamItemCount[4 @ ChaingunTurretPack] = 0;
	$TeamItemCount[5 @ ChaingunTurretPack] = 0;
	$TeamItemCount[6 @ ChaingunTurretPack] = 0;
	$TeamItemCount[7 @ ChaingunTurretPack] = 0;

// This is a MiniMod Plugin.
// This plugin is the Death of Bots.
// Note: Code is based off of PeterT's Watchdog Turret plugin.
// Ported by Dewy then modified further by PeterT.



ItemImageData DoBImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DoBPack
{
	description = "Pulse Laser";
	shapeFile = "indoorgun";
	className = "Backpack";
   heading = "dDeployables";
	imageType = DoBImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DoBPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Long range motion based motion sensing turret with a rapid rate of fire.");
}


function DoBPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DoBPack::onDeploy(%player,%item,%pos)
{
	if (DoBPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DoBPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

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
					%camera = newObject("Camera","Turret",DeployableDoB,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Pulse Laser#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Pulse Laser deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "DoBPack"]++;
					if ($TurretScore == "True")
				        {
						Client::setOwnedObject(%client, %camera);
						Client::setOwnedObject(%client, %player);
					}
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

///-----------------------------------------------
/// description = "3x4 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------



ItemImageData doorthreebyfourForceFieldPackImage
{
        //shapeFile = "forcefield_3x4";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        //mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData doorthreebyfourForceFieldPack
{
        description = "3x4 Field Door";
        //shapeFile = "forcefield_3x4";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "pDoors";
        imageType = doorthreebyfourForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorthreebyfourForceFieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This door provides an extremely durable barrier to keep opposing teams out, but can only be deployed in a vertical configuration.");
}


function doorthreebyfourForceFieldPack::onUse(%player,%item)
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

function doorthreebyfourForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorthreebyfourForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorthreebyfourForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
			%num=FieldDoorCheck($los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight);
			if($MaxNumTurretsInBox > %num) {
				%num=FieldDoorCheck($los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight);
				if(0 == %num) {
					if(checkDeployArea(%client,$los::position))
					{
                                		if (checkbase($los::position,$los::object,%player) == true)
						{
                                			%rot = GameBase::getRotation(%player);
                                        		%camera = newObject("doorthreebyfourForceFieldPack","StaticShape",doorthreebyfourForceFieldShape,true);
                                        		addToSet("MissionCleanup", %camera);
                                        		GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        		GameBase::setRotation(%camera,%rot);
                                        		GameBase::setPosition(%camera,$los::position);
                                        		Gamebase::setMapName(%camera,"3x4 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        		Client::sendMessage(%client,0,"3x4 Force Field Door deployed");
                                        		playSound(SoundPickupBackpack,$los::position);
                                        		$TeamItemCount[GameBase::getTeam(%camera) @ "doorthreebyfourForceFieldPack"]++;
                                        		echo("MSG: ",%client," deployed a 3x4 Force Field Door ");
                                        		return true;
                                        	}
                                        	else Client::sendMessage(%client, 0, "Cannot deploy, On enemy or neutral structure.");
                                        }
                                        else Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
				} 
				else
				Client::sendMessage(%client,0,"Flux Instability - Too close to other forcefields");
			}
			else 
			Client::sendMessage(%client,0,"Quantum destabilization caused by other forcefields in the area");

		}
                else 
                Client::sendMessage(%client,0,"Cannot deploy here.");
        }
        else
        Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

///-----------------------------------------------
/// description = "4x14 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------



ItemImageData doorfourbyfourteenForceFieldPackImage
{
        //shapeFile = "forcefield_4x14";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        //mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData doorfourbyfourteenForceFieldPack
{
        description = "4x14 Field Door";
        //shapeFile = "forcefield_4x14";
        shapeFile = "AmmoPack";
        className = "Backpack";
          heading = "pDoors";
        imageType = doorfourbyfourteenForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfourbyfourteenForceFieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This door provides an extremely durable barrier to keep opposing teams out, but can only be deployed in a vertical configuration.");
}


function doorfourbyfourteenForceFieldPack::onUse(%player,%item)
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

function doorfourbyfourteenForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfourbyfourteenForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfourbyfourteenForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%num=FieldDoorCheck($los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight);
			if($MaxNumTurretsInBox > %num) {
				%num=FieldDoorCheck($los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight);
				if(0 == %num) {
					if(checkDeployArea(%client,$los::position))
					{
                                		if (checkbase($los::position,$los::object,%player) == true)
						{
                                			%rot = GameBase::getRotation(%player);
                                        		%camera = newObject("doorfourbyfourteenForceFieldPack","StaticShape",doorfourbyfourteenForceFieldShape,true);
                                        		addToSet("MissionCleanup", %camera);
                                        		GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        		GameBase::setRotation(%camera,%rot);
                                        		GameBase::setPosition(%camera,$los::position);
                                        		Gamebase::setMapName(%camera,"4x14 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        		Client::sendMessage(%client,0,"4x14 Force Field Door deployed");
                                        		playSound(SoundPickupBackpack,$los::position);
                                        		$TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyfourteenForceFieldPack"]++;
                                        		echo("MSG: ",%client," deployed a 4x14 Force Field Door ");
                                        		return true;
                                        	}
                                        	else Client::sendMessage(%client, 0, "Cannot deploy, On enemy or neutral structure.");
                                        }
                                        else Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
				} 
				else
				Client::sendMessage(%client,0,"Flux Instability - Too close to other forcefields");
			}
			else 
			Client::sendMessage(%client,0,"Quantum destabilization caused by other forcefields in the area");
		}
                else
                Client::sendMessage(%client,0,"Cannot deploy here.");
        }
        else
        Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

///-----------------------------------------------
/// description = "4x17 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------



ItemImageData doorfourbyseventeenForceFieldPackImage
{
        //shapeFile = "forcefield_4x17";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        //mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData doorfourbyseventeenForceFieldPack
{
        description = "4x17 Field Door";
        //shapeFile = "forcefield_4x17";
        shapeFile = "AmmoPack";
        className = "Backpack";
         heading = "pDoors";
        imageType = doorfourbyseventeenForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfourbyseventeenForceFieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This door provides an extremely durable barrier to keep opposing teams out, but can only be deployed in a vertical configuration.");
}


function doorfourbyseventeenForceFieldPack::onUse(%player,%item)
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

function doorfourbyseventeenForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfourbyseventeenForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfourbyseventeenForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%num=FieldDoorCheck($los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight);
			if($MaxNumTurretsInBox > %num) {
				%num=FieldDoorCheck($los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight);
				if(0 == %num) {
					if(checkDeployArea(%client,$los::position))
					{
                                		if (checkbase($los::position,$los::object,%player) == true)
						{
                                			%rot = GameBase::getRotation(%player);
                                        		%camera = newObject("doorfourbyseventeenForceFieldPack","StaticShape",doorfourbyseventeenForceFieldShape,true);
                                        		addToSet("MissionCleanup", %camera);
                                        		GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        		GameBase::setRotation(%camera,%rot);
                                        		GameBase::setPosition(%camera,$los::position);
                                        		Gamebase::setMapName(%camera,"4x17 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        		Client::sendMessage(%client,0,"4x17 Force Field Door deployed");
                                        		playSound(SoundPickupBackpack,$los::position);
                                        		$TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyseventeenForceFieldPack"]++;
                                        		echo("MSG: ",%client," deployed a 4x17 Force Field Door ");
                                        		return true;
                                        	}
                                        	else Client::sendMessage(%client, 0, "Cannot deploy, On enemy or neutral structure.");
                                        }
                                        else Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
				} 
				else
				Client::sendMessage(%client,0,"Flux Instability - Too close to other forcefields");
			}
			else 
			Client::sendMessage(%client,0,"Quantum destabilization caused by other forcefields in the area");
		}
                else
                Client::sendMessage(%client,0,"Cannot deploy here.");
        }
        else
        Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

///-----------------------------------------------
/// description = "4x8 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------



ItemImageData doorfourbyeightForceFieldPackImage
{
        //shapeFile = "forcefield_4x8";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        //mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData doorfourbyeightForceFieldPack
{
        description = "4x8 Field Door";
        //shapeFile = "forcefield_4x8";
        shapeFile = "AmmoPack";
        className = "Backpack";
          heading = "pDoors";
        imageType = doorfourbyeightForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfourbyeightForceFieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This door provides an extremely durable barrier to keep opposing teams out, but can only be deployed in a vertical configuration.");
}


function doorfourbyeightForceFieldPack::onUse(%player,%item)
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

function doorfourbyeightForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfourbyeightForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfourbyeightForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%num=FieldDoorCheck($los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight);
			if($MaxNumTurretsInBox > %num) {
				%num=FieldDoorCheck($los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight);
				if(0 == %num) {
					if(checkDeployArea(%client,$los::position))
					{
                                		if (checkbase($los::position,$los::object,%player) == true)
						{
                                			%rot = GameBase::getRotation(%player);
                                        		%camera = newObject("doorfourbyeightForceFieldPack","StaticShape",doorfourbyeightForceFieldShape,true);
                                        		addToSet("MissionCleanup", %camera);
                                        		GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        		GameBase::setRotation(%camera,%rot);
                                        		GameBase::setPosition(%camera,$los::position);
                                        		Gamebase::setMapName(%camera,"4x8 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        		Client::sendMessage(%client,0,"4x8 Force Field Door deployed");
                                        		playSound(SoundPickupBackpack,$los::position);
                                        		$TeamItemCount[GameBase::getTeam(%camera) @ "doorfourbyeightForceFieldPack"]++;
                                        		echo("MSG: ",%client," deployed a 4x8 Force Field Door ");
                                        		return true;
                                        	}
                                        	else Client::sendMessage(%client, 0, "Cannot deploy, On enemy or neutral structure.");
                                        }
                                        else Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
				} 
				else
				Client::sendMessage(%client,0,"Flux Instability - Too close to other forcefields");
			}
			else 
			Client::sendMessage(%client,0,"Quantum destabilization caused by other forcefields in the area");
		}
                else
                Client::sendMessage(%client,0,"Cannot deploy here.");
        }
        else
        Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

///-----------------------------------------------
/// description = "5x5 Force Field Door";
/// Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------



ItemImageData doorfivebyfiveForceFieldPackImage
{
        //shapeFile = "forcefield_5x5";
        shapeFile = "AmmoPack";
        mountPoint = 2;
        //mountOffset = { 0, -0.12, 3.0 };
        mountRotation = { 90, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData doorfivebyfiveForceFieldPack
{
        description = "5x5 Field Door";
        //shapeFile = "forcefield_5x5";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "pDoors";
        imageType = doorfivebyfiveForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfivebyfiveForceFieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This door provides an extremely durable barrier to keep opposing teams out, but can only be deployed in a vertical configuration.");
}

function doorfivebyfiveForceFieldPack::onUse(%player,%item)
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

function doorfivebyfiveForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (doorfivebyfiveForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfivebyfiveForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%num=FieldDoorCheck($los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight);
			if($MaxNumTurretsInBox > %num) {
				%num=FieldDoorCheck($los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight);
				if(0 == %num) {
                                	if(checkDeployArea(%client,$los::position))
                                	{
                                		if (checkbase($los::position,$los::object,%player) == true)
						{
                                			%rot = GameBase::getRotation(%player);
                                        		%camera = newObject("doorfivebyfiveForceFieldPack","StaticShape",doorfivebyfiveForceFieldShape,true);
                                        		addToSet("MissionCleanup", %camera);
                                        		GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        		GameBase::setRotation(%camera,%rot);
                                        		GameBase::setPosition(%camera,$los::position);
                                        		Gamebase::setMapName(%camera,"5x5 Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        		Client::sendMessage(%client,0,"5x5 Force Field Door deployed");
                                        		playSound(SoundPickupBackpack,$los::position);
                                        		$TeamItemCount[GameBase::getTeam(%camera) @ "doorfivebyfiveForceFieldPack"]++;
                                        		echo("MSG: ",%client," deployed a 5x5 Force Field Door ");
                                        		return true;
                                        	}
                                        	else Client::sendMessage(%client, 0, "Cannot deploy, On enemy or neutral structure.");
                                        }
                                        else Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
				} 
				else
				Client::sendMessage(%client,0,"Flux Instability - Too close to other forcefields");
			}
			else 
			Client::sendMessage(%client,0,"Quantum destabilization caused by other forcefields in the area");
                }
		else
                Client::sendMessage(%client,0,"Cannot deploy here.");
        }
        else
        Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


function FieldDoorCheck(%pos,%boxlength,%boxwidth,%boxheight)
{
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,%pos,%boxlength,%boxwidth,%boxheight,0);
	%num2 = CountObjects(%set,"doorfivebyfiveForceFieldShape",%num);
	%num2 = %num2 + CountObjects(%set,"doorthreebyfourForceFieldShape",%num);
	%num2 = %num2 + CountObjects(%set,"doorfourbyfourteenForceFieldShape",%num);
	%num2 = %num2 + CountObjects(%set,"doorfourbyseventeenForceFieldShape",%num);
	%num2 = %num2 + CountObjects(%set,"doorfourbyeightForceFieldShape",%num);
	%num2=%num2 +  CountObjects(%set,"DeployableForceField",%num);
	%num = %num2;
	deleteObject(%set);
	
	
	
	return (%num);
}



// This is a MiniMod Plugin.
// This plugin is the Energizer Pack. Created/Ported by Dewy.

ItemImageData EnergizerPackImage
{
	shapeFile = "mortarpack"; // Changed to make it look better. :)
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -15; // This is where it negates the armors jet drain. By in creasing its recharge rate.
 	maxEnergy = -20; // This is where it negates the armors jet drain. By in creasing its recharge rate.
	firstPerson = false;
};

ItemData EnergizerPack
{
	description = "Energizer Pack";
	shapeFile = "mortarpack"; // Changed to make it look better. :)
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = EnergizerPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergizerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergizerPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	%client = Player::getClient(%player);
	Bottomprint(%client, "Provides an extremely fast rate of energy recharge.  Use this to jet longer.");
}

function EnergizerPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairRifle) // Ok this I added in case I later feel like making a Sniper Style repaiar gun.
		Player::unmountItem(%player,$WeaponSlot);
}

// This is a MiniMod Plugin.
// This plugin is the Flak Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    FlakTurret.ArmorData.cs
//    FlakTurret.baseProjData.cs
//    FlakTurret.item.cs
//    FlakTurret.reinitData.cs
//    FlakTurret.station.cs
//    FlakTurret.turret.cs
//
// to your MiniMod/plugins directory.



ItemImageData FlakPackImage //image name while a pack
{
	shapeFile = "remoteturret";//name of shape file, same as in turret.cs
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData FlakPack
{
	description = "Flak Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = FlakPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlakPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function FlakPack::onDeploy(%player,%item,%pos)
{
	if (FlakPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function FlakPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This turret is used primarily for anti-air defense.  Fires a high powered rocket");
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

function FlakPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableFlak",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableFlak",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("FlakTurret","Turret",DeployableFlak,true);
	                     					addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Flak Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Flak Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "FlakPack"]++;
								echo("MSG: ",%client," deployed a Flak Turret");
						      		if ($TurretScore == "True")
							        {
							        	Client::setOwnedObject(%client, %turret);
							        	Client::setOwnedObject(%client, %player);
						        	}
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

	$TeamItemCount[0 @ FlakPack] = 0;
	$TeamItemCount[1 @ FlakPack] = 0;
	$TeamItemCount[2 @ FlakPack] = 0;
	$TeamItemCount[3 @ FlakPack] = 0;
	$TeamItemCount[4 @ FlakPack] = 0;
	$TeamItemCount[5 @ FlakPack] = 0;
	$TeamItemCount[6 @ FlakPack] = 0;
	$TeamItemCount[7 @ FlakPack] = 0;

// This is a MiniMod Plugin.
// This plugin is the Flame Turret from the Ideal mod.
// Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Flame Turret.ArmorData.cs
//    Flame Turret.baseExpData.cs
//    Flame Turret.baseProjData.cs
//    Flame Turret.item.cs
//    Flame Turret.Nsound.cs
//    Flame Turret.reinitData.cs
//    Flame Turret.staticshape.cs
//    Flame Turret.station.cs
//    Flame Turret.turret.cs
//
// to your MiniMod/plugins directory.



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
   	heading = "dDeployables";
	imageType = FlameTurretPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlameTurretPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Very short range, but high powered turret.  Fried chicken anyone?");
}



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
							if ($TurretScore == "True")
						        {
						        	Client::setOwnedObject(%client, %turret);
						        	Client::setOwnedObject(%client, %player);
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

$TeamItemCount[0 @ FlameTurretPack] = 0;
$TeamItemCount[1 @ FlameTurretPack] = 0;
$TeamItemCount[2 @ FlameTurretPack] = 0;
$TeamItemCount[3 @ FlameTurretPack] = 0;
$TeamItemCount[4 @ FlameTurretPack] = 0;
$TeamItemCount[5 @ FlameTurretPack] = 0;
$TeamItemCount[6 @ FlameTurretPack] = 0;
$TeamItemCount[7 @ FlameTurretPack] = 0;

// MiniMod plugin
// Fusion Blaster created/ported By, Dewy.

//addPluginWeapon(Mortar, FusionGun);
// Use the above line instead of all the $NextWeapon/$PrevWeapon garbage.
//
// Infact, DO NOT ENTER ANY $NextWeapon/$PrevWeapon variables they WILL cause conflicts!!!
//
// Note: "Mortar" is used to tell MiniMod what weapon the plugin will be loaded after,
//	 and before the next base weapon.(MiniMod opens a slot for plugins to fit between weapons. :)
//
// It does not need to be changed to avoid conficts. Its just there for you to set as a prefference.
//
// If you alter "Mortar" with something else, please only change it with other Base Weapons,
//	 for compatiblity's sake.

//$AutoUse[FusionGun] = True; 

ItemImageData FusionGunImage
{
        shapeFile  = "energygun";
	mountPoint = 0;

        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.4;
        minEnergy = 12;
        maxEnergy = 14;

        projectileType = FusionShell;
	accuFire = true;

	sfxFire = SoundRemoteTurretFire;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundMortarReload;
	sfxReady = SoundUseAmmoStation ;
};

ItemData FusionGun
{
   	heading = "bWeapons";
        description = "Fusion Blaster";
	className = "Weapon";
        shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
        imageType = FusionGunImage;
        price = 115;
	showWeaponBar = true;
};

// This is a MiniMod Plugin.
// This plugin is the GuardDog (Shockwave) Turret from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    GuardDogTurret.ArmorData.cs
//    GuardDogTurret.baseProjData.cs
//    GuardDogTurret.item.cs
//    GuardDogTurret.reinitData.cs
//    GuardDogTurret.station.cs
//    GuardDogTurret.turret.cs
//
// to your MiniMod/plugins directory.



ItemImageData GuardDogImage //image name while a pack
{
	shapeFile = "remoteturret";//name of shape file, same as in turret.cs
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ConPack //ItemData name, used below in item.cs
{
	description = "Guard Dog";
	shapeFile = "remoteturret";//"chainturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = GuardDogImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 425;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ConPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ConPack::onDeploy(%player,%item,%pos)
{
	if (ConPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ConPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This turret fires a high mass projectile which knocks players out of the area.  Somewhat slow projectile");
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

function ConPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
			{
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableConTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) 
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableConTurret",%num);
					deleteObject(%set);
					if(0 == %num) 
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7) 
						{
							if(checkDeployArea(%client,$los::position)) 
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableConTurret,true);
	                     					addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Guard Dog#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Guard Dog deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ConPack"]++;
								echo("MSG: ",%client," deployed a Guard Dog");
						      		if ($TurretScore == "True")
							        {
							        	Client::setOwnedObject(%client, %turret);
							        	Client::setOwnedObject(%client, %player);
						        	}
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

	$TeamItemCount[0 @ ConPack] = 0;
	$TeamItemCount[1 @ ConPack] = 0;
	$TeamItemCount[2 @ ConPack] = 0;
	$TeamItemCount[3 @ ConPack] = 0;
	$TeamItemCount[4 @ ConPack] = 0;
	$TeamItemCount[5 @ ConPack] = 0;
	$TeamItemCount[6 @ ConPack] = 0;
	$TeamItemCount[7 @ ConPack] = 0;

///-----------------------------------------------
/// description = "Hologram";
/// MiniMod Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------


ItemImageData HoloPackImage
{
        shapeFile = "ShieldPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 1.0;
        firstPerson = false;
};

ItemData HoloPack
{
        description = "Hologram";
        shapeFile = "larmor";
        className = "Backpack";
        heading = "dDeployables";
        imageType = HoloPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 900;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function HoloPack::onMount(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Not enough teammates?  Well, get your safety buddy aka the Hologram, only these guys blow up nicely when fired upon.");
}


function HoloPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function HoloPack::onDeploy(%player,%item,%pos)
{
        if (HoloPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function HoloPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) 
        {
                if (GameBase::getLOSInfo(%player,3)) 
                {
                        %obj = getObjectType($los::object);

                                    %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                                %num = CountObjects(%set,"Hologram",%num);
                                deleteObject(%set);

                                        if (Vector::dot($los::normal,"0 0 1") > 0.7) 
                                        {
                                                if(checkDeployArea(%client,$los::position)) 
                                                {
                                                        %rot = GameBase::getRotation(%player);
                                                        %rnd = floor(getRandom() * 10);
                                                        Client::sendMessage(%client,0,"Hologram Deployed");
                                                        echo("MSG: ",%client," deployed a Hologram");
                                                        playSound(ForceFieldOpen,$los::position);
							lbot(%player,%player,$los::position);
                                                        $TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
                                                        return true;
                                                }
                                        }
                                        else
                                                Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

//This is a MiniMod plugin...
//This is a modified Laser Turret from the ol' Renegades 1.2 mod. Ported and reworked by Dewy



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

function LaserPack::onMount(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The laser turret's primary attraction is it's beam projectile.  The laser turret doesn't miss often.");
}



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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,10)) 
		{
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"DeployableLaser",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num) 
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,"DeployableLaser",%num);
				deleteObject(%set);
				if(0 == %num) 
				{
					%obj = getObjectType($los::object);
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					if (Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot;
					else if (Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot;
					else %rot = Vector::getRotation($los::normal);
					%camera = newObject("Camera","Turret",DeployableLaser,true);
	   				addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                        		if ($TurretScore == "True")
					{
						Client::setOwnedObject(%client, %camera);
						Client::setOwnedObject(%client, %player);
					}
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;
					return true;
				}
				else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
			}
			else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

// This is a MiniMod Plugin.
// This is the Long Range Motion Sensor from the Redneck Slag Pack mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    LRMotionSensor.ArmorData.cs
//    LRMotionSensor.item.cs
//    LRMotionSensor.reinitData.cs
//    LRMotionSensor.sensor.cs
//    LRMotionSensor.station.cs
//
// to your MiniMod/plugins directory.



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

function DeployableLRMotionSensorPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Long Range Motion Sensor");
}


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

// MiniMod plugin
// Marlin ported By, Desertfox.

//addPluginWeapon(Mortar, Marlin);
// Use the above line instead of all the $NextWeapon/$PrevWeapon garbage.
//
// Infact, DO NOT ENTER ANY $NextWeapon/$PrevWeapon variables they WILL cause conflicts!!!
//
// Note: "Mortar" is used to tell MiniMod what weapon the plugin will be loaded after,
//	 and before the next base weapon.(MiniMod opens a slot for plugins to fit between weapons. :)
//
// It does not need to be changed to avoid conficts. Its just there for you to set as a prefference.
//
// If you alter "Mortar" with something else, please only change it with other Base Weapons,
//	 for compatiblity's sake.

//$AutoUse[Marlin] = True;


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
	reloadTime = 2;
	fireTime = 1;

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
			//%obj = newObject("","Mine","SmokeGrenade");
	 		//addToSet("MissionCleanup", %obj);
			//GameBase::throw(%obj,%this,"0 0 0",0);
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

// This is a MiniMod Plugin.
// This plugin is the Weapon use messages from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    messages.item.cs
//
// to your MiniMod/plugins directory.

function Blaster::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	$WeapTarget[%player] = 0;
	bottomprint(Player::getClient(%player), "<jc><f2>Using Blaster\nLong range seeking round, low damage", 2);
}

function PlasmaGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Plasma Gun\nAmmo based energy pistol", 2);
}


function Chaingun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Chaingun \nMedium range spray weapon", 2);
}

function DiscLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Disc Launcher\nMedium range and rate of fire, does area damage", 2);
}


function GrenadeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Grenade Launcher\n Medium strength area saturation and bombardment", 2);
}

function LaserRifle::onUse(%player,%item)
{	
//	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
//		Weapon::onUse(%player,%item);
//	else
//		Client::sendMessage(Player::getClient(%player),0,
//			"Must have an Energy Pack to use Laser Rifle."); 
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Laser Rifle\nStandard energy based sniper weapon", 2);
}

function EnergyRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using ELF Gun\nDoes only small amounts of damage, but will sap energy sources quickly.", 2);
}

function Mortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Mortar\nHeavy area saturation and bombardment", 2);
}

function TargetingLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Targeting Laser\nRange indicating tool, helps teammates with mortars", 2);
}

function HyperB::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Hyper Blaster", 2);
}

function RocketLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Rocket Launcher\nPress fire with a target in your crosshairs to lock-on.  Projectiles do medium damage and have a long range.", 2);
}

function SniperRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Sniper Rifle", 2);
}

function BoomStick::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Boom Stick", 2);
}

function TranqGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Dart Rifle", 2);
}

function Silencer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Magnum", 2);
}

function ConCun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Shockwave Cannon", 2);
}

function Railgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Railgun", 2);
}

function Vulcan::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Vulcan", 2);
}

function Mfgl::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Tactical Nuke", 2);
}

function Flamer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Flame Thrower", 2);
}

function IonGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Ion Rifle", 2);
}

function Omega::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Volter", 2);
}

function GravGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Grav Gun", 2);
}

function FixIt::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer Repair-Gun", 2);
}

function Hackit::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Engineer Hack-Gun", 2);
}

function EMPGrenadelauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using EMP Grenade Launcher\nShort range weapon, but will short circuit any effected players energy systems for several seconds.", 2);
}

function PlasmaCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Plasma Cannon\n Long range energy based assault weapon.  Must have an energizer pack to use", 2);
}

function Shotgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Shotgun\nHeavy damage short ranged ammo based weapon", 2);
}

function Marlin::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Marlin Rifle\nAmmo based sniper rifle, 3 second reload duration", 2);
}

function FusionGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Fusion Blaster\nPrimarily used to destroy forcefields, blastwalls and other base installations.  Short range only", 2);
}

function ClusterBomb::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Particle Accelerator\nEnergy based Flak gun, medium to high damage", 2);
}

function MineLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Mine Launcher\nUse a high arc to lay a strip of mines along the projectile path", 2);
}

function PlasmaCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Plasma Cannon\nMedium to high damage Energy based weapon similar to Plasma turrets", 2);
}

function RepairRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Repair Rifle\nLong range repair gun, much less energy efficient than a repair pack", 2);
}



// This is a MiniMod Plugin.
// This plugin is the Mine Launcher from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    MineLauncher.ArmorData.cs
//    MineLauncher.baseProjData.cs
//    MineLauncher.item.cs
//    MineLauncher.station.cs
//
// to your MiniMod/plugins directory.


//addPluginWeapon(Mortar, MineLauncher);
// Use the above line instead of all the $NextWeapon/$PrevWeapon garbage.
//
// Infact, DO NOT ENTER ANY $NextWeapon/$PrevWeapon variables they WILL cause conflicts!!!
//
// Note: "Mortar" is used to tell MiniMod what weapon the plugin will be loaded after,
//	 and before the next base weapon.(MiniMod opens a slot for plugins to fit between weapons. :)
//
// It does not need to be changed to avoid conficts. Its just there for you to set as a prefference.
//
// If you alter "Mortar" with something else, please only change it with other Base Weapons,
//	 for compatiblity's sake.

ItemData MinelAmmo
{
	description = "Mine Launcher Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MineLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MinelAmmo;
	projectileType = MineShell; 
	accuFire = false;
	reloadTime = 1.4;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MineLauncher
{
	description = "Mine Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
    heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 175;
	showWeaponBar = true;
};

//This is a MiniMod Plugin...
//This is the ELF turret from the ol' Renegades1.2 mod. Ported&Modified by Dewy.



ItemImageData ShockPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ShockPack
{
	description = "Mini-ELF Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dDeployables";
	imageType = ShockPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShockPack::onMount(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Mini-Elf turret is a deployable version of it's big brother.  Short range, low damage, but high energy drain.");
}


function ShockPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ShockPack::onDeploy(%player,%item,%pos)
{
	if (ShockPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ShockPack::deployShape(%player,%item)
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
					%camera = newObject("Camera","Turret",DeployableShock,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Shock Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Shock Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "ShockPack"]++;
                              		if ($TurretScore == "True")
					{
					    	Client::setOwnedObject(%client, %camera);
						Client::setOwnedObject(%client, %player);
					}
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else																						  
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}

// This is a MiniMod Plugin.
// This is the Mini-Plasma turret created/ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    Mini-PlasmaTurret.ArmorData.cs
//    Mini-PlasmaTurret.baseProjData.cs
//    Mini-PlasmaTurret.item.cs
//    Mini-PlasmaTurret.reinitData.cs
//    Mini-PlasmaTurret.station.cs
//    Mini-PlasmaTurret.turret.cs
//
// to your MiniMod/plugins directory.



ItemImageData PlasmaPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlasmaPack
{
	description = "Mini-Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dDeployables";
	imageType = PlasmaPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmaPack::onUse(%player,%item)
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

function PlasmaPack::onMount(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This turret fires the same projectiles as the Plasma Gun.  Medium damage and high rate of fire.");
}

function PlasmaPack::onDeploy(%player,%item,%pos)
{
	if (PlasmaPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
			%count++;
	}
	return %count;
}

function PlasmaPack::deployShape(%player,%item)
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

							%turret = newObject("remoteTurret","Turret",DeployableMiniPlasma,true);
	           					          addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"RMT Mini-Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Remote Mini-Plasma Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "PlasmaPack"]++;
							echo("MSG: ",%client," deployed a Remote Turret");
						      if ($TurretScore == "True")
						      {
						      	   Client::setOwnedObject(%client, %turret);
						      	   Client::setOwnedObject(%client, %player);
						      }
					return true;
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


	$TeamItemCount[0 @ PlasmaPack] = 0;
	$TeamItemCount[1 @ PlasmaPack] = 0;
	$TeamItemCount[2 @ PlasmaPack] = 0;
	$TeamItemCount[3 @ PlasmaPack] = 0;
	$TeamItemCount[4 @ PlasmaPack] = 0;
	$TeamItemCount[5 @ PlasmaPack] = 0;
	$TeamItemCount[6 @ PlasmaPack] = 0;
	$TeamItemCount[7 @ PlasmaPack] = 0;

// This is a MiniMod Plugin.
// This plugin is the Particle Accelerator from the hvTactical mod.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    ParticleAccelerator.ArmorData.cs
//    ParticleAccelerator.baseProjData.cs
//    ParticleAccelerator.item.cs
//    ParticleAccelerator.station.cs
//
// to your MiniMod/plugins directory.

//$AutoUse[ClusterBomb] = True;//+++++++++++++++++++++++++++++++++++++++++++++++


//addPluginWeapon(Mortar, ClusterBomb);
// Use the above line instead of all the $NextWeapon/$PrevWeapon garbage.
//
// Infact, DO NOT ENTER ANY $NextWeapon/$PrevWeapon variables they WILL cause conflicts!!!
//
// Note: "Mortar" is used to tell MiniMod what weapon the plugin will be loaded after,
//	 and before the next base weapon.(MiniMod opens a slot for plugins to fit between weapons. :)
//
// It does not need to be changed to avoid conficts. Its just there for you to set as a prefference.
//
// If you alter "Mortar" with something else, please only change it with other Base Weapons,
//	 for compatiblity's sake.

ItemImageData ClusterBombImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; 
      	minEnergy = 30;
	maxEnergy = 50;//26;++++++++++++++++++++++++++++
//	projectileType = ThisShouldBeUndefined;
	accuFire = false;
	reloadTime = 0;
	fireTime = 0.25;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };	

//	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundTeleportPower; //+++++++++++++++++++++++++++++++++++
};

ItemData ClusterBomb
{
	description = "Particle Accelerator";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ClusterBombImage;
	price = 475;
	showWeaponBar = true;
};

function ClusterBombImage::onFire(%player, %slot)
 {
   %enVal  = 30.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 20.0)
	{
   		 GameBase::setEnergy(%player,%energy);
		 playSound(turretExplosion,GameBase::getPosition(%player));//+++++
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClusterBombShell",%trans,%player,%vel);
	 }
	 else
	{
	 playSound(SoundPackFail,GameBase::getPosition(%player));//++++
	 Player::trigger(%player,$WeaponSlot,false);//+++++
	 //Client::sendMessage(Player::getClient(%player), 0,"Not enough energy to fire the Particle Accelerator");
	} 
}

// This is a MiniMod Plugin.
// This plugin is the Plasma Cannon from the Redneck Slag Pack.
// Ported by PeterT.
//
// To install this plugin just...
// Add:
//
//    PlasmaCannon.ArmorData.cs
//    PlasmaCannon.baseProjData.cs
//    PlasmaCannon.item.cs
//    PlasmaCannon.station.cs
//
// to your MiniMod/plugins directory.

//$AutoUse[PlasmaCannon] = True;

//addPluginWeapon(Mortar, PlasmaCannon);
// Use the above line instead of all the $NextWeapon/$PrevWeapon garbage.
//
// Infact, DO NOT ENTER ANY $NextWeapon/$PrevWeapon variables they WILL cause conflicts!!!
//
// Note: "Mortar" is used to tell MiniMod what weapon the plugin will be loaded after,
//	 and before the next base weapon.(MiniMod opens a slot for plugins to fit between weapons. :)
//
// It does not need to be changed to avoid conficts. Its just there for you to set as a prefference.
//
// If you alter "Mortar" with something else, please only change it with other Base Weapons,
//	 for compatiblity's sake.

ItemImageData PlasmaCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = PlasmaCannonBlast;
	accuFire = True;
	reloadTime = 0.4;
	fireTime = 0.2;
	minEnergy = 15;
	maxEnergy = 30;
	
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
	description = "Plasma Cannon";
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
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergizerPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
		"Must have an Energizer Pack to use Plasma Cannon.");
		bottomprint(Player::getClient(%player), "<jc><f2>Using Plasma Cannon\n Long range energy based assault weapon.  Must have an energizer pack to use", 2); 
}

// This is a MiniMod plugin
// This is the Rail Turret From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.



ItemImageData RailTurretImage
{
shapeFile = "remoteturret";
mountPoint = 2;
mountOffset = { 0, -0.12, -0.1 };
mountRotation = { 0, 0, 0 };
mass = 2.5;
firstPerson = false;
}; 

ItemData RailTurret
{
description = "Rail Turret";
shapeFile = "remoteturret";
className = "Backpack";
heading = "dDeployables";
imageType = RailTurretImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 850;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
}; 

function RailTurret::onUse(%player,%item)
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

function RailTurret::onDeploy(%player,%item,%pos)
{
	if (RailTurret::deployShape(%player,%item))
		{
		Player::decItemCount(%player,%item);
		}
}

function RailTurret::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Rail Turret has been modfied to fire automatically.\nThis turret fires a near-light-speed projectile to a medium range before vaporizing.  Great for area defense");
}

function CountObjects(%set,%name,%num)
{
%count = 0; for(%i=0;%i<%num;%i++)
	{
	%obj=Group::getObject(%set,%i);
	if(GameBase::getDataName(Group::getObject(%set,%i)) == %name)
	%count++;
	}
return %count;
}

function RailTurret::deployShape(%player,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
	if (GameBase::getLOSInfo(%player,3))
		{
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
			{
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"DeployableVulcan",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num)
				{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,"DeployablePlasma",%num);
				deleteObject(%set); 
				if(0 == %num)
					{
					if(checkDeployArea(%client,$los::position))
						{	
						%set = newObject("set",SimSet);
						%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,5,5,$TurretBoxMinHeight,0);
						%num2 = CountObjects(%set,"doorfivebyfiveForceFieldShape",%num);
						%num2 = %num2 + CountObjects(%set,"doorthreebyfourForceFieldShape",%num);
						%num2 = %num2 + CountObjects(%set,"doorfourbyfourteenForceFieldShape",%num);
						%num2 = %num2 + CountObjects(%set,"doorfourbyseventeenForceFieldShape",%num);
						%num2 = %num2 + CountObjects(%set,"doorfourbyeightForceFieldShape",%num);
						%num3 = CountObjects(%set,"BlastWallShape",%num);
						%num = %num2 + %num3;
						deleteObject(%set);
						if(0 == %num)
							{
							if (Vector::dot($los::normal,"0 0 1") > 0.7)
								{
								if(checkDeployArea(%client,$los::position))
									{
									%rot = GameBase::getRotation(%player);
									%turret = newObject("hellfiregun","Turret",DeployableRail,true);
									addToSet("MissionCleanup", %turret);
									GameBase::setTeam(%turret,GameBase::getTeam(%player));
									GameBase::setPosition(%turret,$los::position);
									GameBase::setRotation(%turret,%rot);
									Gamebase::setMapName(%turret,"Rail Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
									Client::sendMessage(%client,0,"Rail Turret deployed");
									playSound(SoundPickupBackpack,$los::position);
									$TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++; return true;
									if ($TurretScore == "True")
								        {
								        	Client::setOwnedObject(%client, %turret);
								        	Client::setOwnedObject(%client, %player);
						        		}
									}
		
								}
								else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
							}
							else 
								{
								if(0 == %num2) Client::sendMessage(%client, 0, "Cannot deploy. Blastwall is interfering with guidance system.");
								else Client::sendMessage(%client, 0, "Cannot deploy. Forcefield destabilizing electric field.");
								}
						}
						else Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
					}
					else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
				else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

// This is a MiniMod Plugin.
// This Plugin is the Repair Rifle.
// Requirements: MiniMod v.07 or later
//   and the Energizer Pack Plugin.

//MiniMod::WeaponCycle(Blaster, RepairRifle, PlasmaGun);

ItemImageData RepairRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = RepairRifleBolt;
	accuFire = true;
//	reloadTime = 0.1;
//	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 30;  // Energy used/sec for sustained weapons

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepairRifle
{
	description = "Repair Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "repairpack";
   	heading = "tTools";
	shadowDetailMask = 4;
	imageType = RepairRifleImage;
	price = 500;
	showWeaponBar = true;
};

function RepairRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Repair Rifle\nLong range repair gun, much less energy efficient than a repair pack", 2);
	//if(Player::getMountedItem(%player,$BackpackSlot) == EnergizerPack)
		//Weapon::onUse(%player,%item);
	//else
		//Client::sendMessage(Player::getClient(%player),0,
		//"Must have an Energizer Pack to use Repair Rifle."); 
}

// This is a MiniMod Plugin.
// This plugin is the Seed Pack from the Ideal mod. Ported by Dewy.
//
// To install this plugin just...
// Add:
//
//    SeedPack.ArmorData.cs
//    SeedPack.item.cs
//    SeedPack.reinitData.cs
//    SeedPack.station.cs
//
// to your MiniMod/plugins directory.



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
   	heading = "dDeployables";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TreePack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Allows multiple plants to be grown, providing instant cover.  Good for snipers.");
}


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


$TeamItemCount[0 @ TreePack] = 0;
$TeamItemCount[1 @ TreePack] = 0;
$TeamItemCount[2 @ TreePack] = 0;
$TeamItemCount[3 @ TreePack] = 0;
$TeamItemCount[4 @ TreePack] = 0;
$TeamItemCount[5 @ TreePack] = 0;
$TeamItemCount[6 @ TreePack] = 0;
$TeamItemCount[7 @ TreePack] = 0;

// This is a MiniMod Plugin.
// This plugin is based on the Watchdog (Spotter) Turret from
// the hvTactical mod. It was initially ported by PeterT and
// then adapted by Epsilon into something quite different.
//
// To install this plugin just...
// Add:
//
//    SeekerTurret.ArmorData.cs
//    SeekerTurret.baseProjData.cs
//    SeekerTurret.item.cs
//    SeekerTurret.reinitData.cs
//    SeekerTurret.station.cs
//    SeekerTurret.turret.cs
//
// to your MiniMod/plugins directory.



ItemImageData SeekerImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SeekerPack
{
	description = "Seeker";
	shapeFile = "camera";
	className = "Backpack";
   	heading = "dDeployables";
	imageType = SeekerImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SeekerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SeekerPack::onDeploy(%player,%item,%pos)
{
	if (SeekerPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function SeekerPack::onMount(%player,%item,%pos)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Seeker is an extremely long ranged laser based turret.  Low damage and rate of fire.");
}



function SeekerPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

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
					%camera = newObject("Camera","Turret",DeployableSeeker,true);
	   	      			addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Seeker#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Seeker deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "SeekerPack"]++;
					if ($TurretScore == "True")
				        {
				        	Client::setOwnedObject(%client, %camera);
				        	Client::setOwnedObject(%client, %player);
					}
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

	$TeamItemCount[0 @ SeekerPack] = 0;
	$TeamItemCount[1 @ SeekerPack] = 0;
	$TeamItemCount[2 @ SeekerPack] = 0;
	$TeamItemCount[3 @ SeekerPack] = 0;
	$TeamItemCount[4 @ SeekerPack] = 0;
	$TeamItemCount[5 @ SeekerPack] = 0;
	$TeamItemCount[6 @ SeekerPack] = 0;
	$TeamItemCount[7 @ SeekerPack] = 0;

// This is a MiniMod plugin.
// SheildGens Pack from the Z-Tek mod. Ported/Modified by Dewy.



$DShield::MaxCapCharge=4.0;
$DShield::TimerTick=0.25;
$DShield::ShieldEnhance=0.05;
$DShield::ProtectArea=150; 
$DShield::OverlapValue=0; 

StaticShapeData DShield
{
	className = "DShield";
	damageSkinData = "objectDamageSkins";
	shapeFile = "generator_p"; 
	maxDamage = 1.4;
	maxEnergy = 500;
	sfxAmbient = SoundGeneratorPower;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	mass=2.5;
};

ItemImageData DShieldPackImage
{
	shapeFile = "generator_p"; 
	mountPoint = 2;
	mountOffset = { 0, -0.5, -1 }; 
	mountRotation = { 0.2, 0, 0 }; 
	firstPerson = false;
};

ItemData DShieldPack
{
	description = "Shield Generator";
	shapeFile = "generator_p"; 
	className = "Backpack";
	heading = "dDeployables"; 
	imageType = "DShieldPackImage";
	sequenceSound[0] = { "power", SoundSensorPower };
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DShieldPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Any team member within 60m will have their energy regeneration boosted significantly.  Great for base defense, Also adds shields to any team member in the radius.");
}


function CheckDeployTerrain (%this) 
{
	%obj=getObjectType(%this);
	if( %obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName(%this) == "DeployableBaseOps" || GameBase::getDataName(%this)=="DeployablePlatform") 
	{
		return 1;
	}
	return 0;
}

function ZTekDebug() 
{
	%DebugClient=2049;
	%DebugObject=Client::getOwnedObject(2049);
	echo("Player Data:");
	echo("Client: 2049");
	echo("Player Object:"@%DebugObject);
	echo("Shields: "@%DebugObject.shieldStrength);
}


function DShield::onDestroyed(%this)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onDestroyed: (%this)=" @ %this);
	//DShield::onDisabled(%this);
	CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
	$TeamItemCount[GameBase::getTeam(%this) @ "DShield"]--;
	%teleset = nameToID("MissionCleanup/Teleports");
	//echo("shield destroyed");
	if ($functioning[%this]==1)
	{
		GameBase::stopSequence(%this,0);
		%pos=GameBase::getPosition(%this);
		echo("shield disabled");
		for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		{
			%matrix = %clientId @ %this;
			%obj = Client::getOwnedObject(%clientId);
			//%matrix = %obj @ %this;
			if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
			%clientpos=gamebase::getPosition(%clientId);
			%dist = Vector::getDistance(%pos, %clientpos);
			//%obj = Client::getOwnedObject(%clientId);
			if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
			{
				if ($oldShieldGen[%matrix] == 1)
				{
					//%obj = Client::getOwnedObject(%clientId);
					%recharge=GameBase::getRechargerate(%obj)-15;
					if (%recharge > 7 || $empTime[%clientId] > 0)
					{
						//echo("Rcharge rate client " @ %clientId @ " is " @ %recharge);
						GameBase::setRechargeRate(%obj,%recharge);
						client::sendMessage(%clientId,1,"WARNING:  Shield flux failure in Shield Generator ID#" @ %this @"!");
					}
					if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
					{
						if(Player::isTriggered(%obj, $BackpackSlot) == true)
						{
						}
					}
					else %obj.shieldStrength = 0.0;
					$oldShieldGen[%matrix]=0;
					//echo("$oldshieldgen[" @ %matrix @ "] = 0");
					//$shieldEnhanced[%obj]=0;
					//$Enhanced[%clientId]--;
				}
			}
			//$oldShieldGen[%matrix]=0;
		}	
	}
	$functioning[%this]=0;
}

function DShieldPack::onUse(%player,%item)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onUse: (%player)=" @ %player @ " (%item)=" @ %item);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function DShieldPack::onDeploy(%player,%item,%pos)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onDeploy: (%player)=" @ %player @ " (%item)=" @ %item @ "(%pos)=" @ %pos);
	if (DShieldPack::deployShape(%player,"Shield Generator",DShield,%item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DShield"]++;
	}
}

function CreateDShieldSimSet(%this)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::CreateDShieldSimSet");
	%dset = nameToID("MissionCleanup/DShield");
	if(%dset == -1)
	{
		newObject("DShield",SimSet);
		addToSet("MissionCleanup","DShield");
	}
	%dset = nameToID("MissionCleanup/DShield/DShield"@%this);
	if(%dset == -1)
	{
		newObject("DShield"@%this,SimSet);
		addToSet("MissionCleanup/DShield","DShield"@%this);
	}
}

function DShieldPack::deployShape(%player,%name,%shape,%item)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::deployShape: (%player)=" @ %player @ "(%name)=" @ %name @ "(%shape)=" @ %shape @ "(%item)=" @ %item);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DShield"] < $TeamItemMax[DShield]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (CheckDeployTerrain($los::object)) 
			{
				%set = newObject("set",SimSet);
				%ovr = ($DShield::ProtectArea-$DShield::OverlapValue)/2;
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,%ovr,%ovr,%ovr,0);
				%num = CountObjects(%set,"DShield",%num);
				deleteObject(%set);
				if(!%num) 
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						if (checkenemybase($los::position,$los::object,%player) != true)
						{
							if(checkDeployArea(%client,$los::position)) 
							{
								%sensor = newObject("Shield Generator","StaticShape",%shape,true);
								$TeamItemCount[GameBase::getTeam(%this) @ "DShield"]++;
								%team = GameBase::getTeam(%this);
								%index = $TeamItemCount[GameBase::getTeam(%this) @ "DShield"];
								$ShieldGen++;
								$ShieldGenObject[$ShieldGen]=%sensor;
								//echo("$ShieldGen[" @ $ShieldGen @ "] = " @ %sensor);
								CreateDShieldSimSet(%sensor);
								addToSet("MissionCleanup/DShield", %sensor);
								addToSet("MissionCleanup", %sensor);
								GameBase::setTeam(%sensor,GameBase::getTeam(%player));
								%pos = Vector::add($los::position,"0 0 0");
								GameBase::setRotation(%sensor,GameBase::getRotation(%player));
								GameBase::setPosition(%sensor,%pos);
								Gamebase::setMapName(%sensor,%name);
								GameBase::setRechargeRate(%sensor,1);
								GameBase::setActive(%sensor,True);
								Client::sendMessage(%client,0,%item.description @ " deployed!");
								playSound(SoundPickupBackpack,$los::position);
								//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::deployShape: (%sensor)=" @ %sensor);
								Client::sendMessage(%client,0,%item.description @ " initializing flux.");
								schedule("DShield::checkAreaDfox("@%sensor@");",5, %sensor);
								//%set = newObject("set",SimSet);
								//schedule("DShield::checkAreaRecur("@%sensor@","@%set@");",5);
								//deleteObject(%set);
								return true;
							}
						}
						else 
						Client::sendMessage(%client,0,"Cannot deploy the Shield Generator on an enemy base.");
					}
					else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
				else
				Client::sendMessage(%client,0,"Too close to other shield generators");
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

function DShield::onEnabled(%this)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onEnabled (%this)="@%this);
	DShield::setActive(%this,true);
}


function DShield::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	%pos=GameBase::getPosition(%this);
	//echo("shield disabled");
	$functioning[%this]=0;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%matrix = %clientId @ %this;
		//%obj = Client::getOwnedObject(%clientId);
		//%matrix = %obj @ %this;
		if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
		%obj = Client::getOwnedObject(%clientId);
		%clientpos=gamebase::getPosition(%clientId);
		%dist = Vector::getDistance(%pos, %clientpos);
		if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
		{
			if ($oldShieldGen[%matrix] == 1)
			{
				//%obj = Client::getOwnedObject(%clientId);
				%recharge=GameBase::getRechargerate(%obj)-15;
				if (%recharge > 7 || $empTime[%clientId] > 0)
				{
					//echo("Recharge rate client " @ %clientId @ " is " @ %recharge);
					GameBase::setRechargeRate(%obj,%recharge);
					client::sendMessage(%clientId,1,"WARNING:  Shield flux failure in Shield Generator ID#" @ %this @"!");
				}
				if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
				{
					if(Player::isTriggered(%obj, $BackpackSlot) == true)
					{
					}
				}
				else %obj.shieldStrength = 0.0;
				$oldShieldGen[%matrix]=0;
				//echo("$oldshieldgen[" @ %matrix @ "] = 0");
				//$shieldEnhanced[%obj]=0;
				//$Enhanced[%clientId]--;
			}
		}
		//$oldShieldGen[%matrix]=0;
	}	
	GameBase::applyDamage(%objt1,$CrushDamageType,0.15,GameBase::getPosition(%objt1),"0 0 0","0 0 0",%this);
}

function DShield::onActivate(%this)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onActivate (%this)="@%this);
	GameBase::playSequence(%this,0,"power");
}

function DShield::setActive(%this)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onActivate (%this)="@%this);
	GameBase::playSequence(%this,0,"power");
}

function DShield::onDeactivate(%this)
{
	//if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onDeactivate (%this)="@%this);
	GameBase::stopSequence(%this,0);
	echo("shield deactivated");
	playSound(SoundGeneratorPower,GameBase::getposition(%this));
}


function Dshield::CheckAreaDfox(%this)
{
	if(GameBase::getDamageState(%this) =="Enabled") 
	{
		$functioning[%this]=1;
		%pos=GameBase::getPosition(%this);
		for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		{
			%obj = Client::getOwnedObject(%clientId);
			%matrix = %clientId @ %this;
			//%matrix = %obj @ %this;
			if (!$oldShieldGen[%matrix]) $oldShieldGen[%matrix] = 0;
			%clientpos=gamebase::getPosition(%clientId);
			%dist = Vector::getDistance(%pos, %clientpos);
			//%obj = Client::getOwnedObject(%clientId);
			if(!Player::isDead(%obj) && GameBase::GetTeam(%clientId) == GameBase::GetTeam(%this))
			{
				if (%dist<60)
				{
					if ($oldShieldGen[%matrix]==0)
					//if ($shieldEnhanced[%clientId] == 0)
					{
						//%obj = Client::getOwnedObject(%clientId);
						%recharge=GameBase::getRechargerate(%obj)+15;
						//echo("Rcharge rate client " @ %clientId @ " is " @ %recharge);
						GameBase::setRechargeRate(%obj,%recharge);
						client::sendMessage(%clientId,1,"Shield Generator #" @ %this @ " active and enhancing.");
						if(%obj.shieldStrength < 0.005) %obj.shieldStrength = 0.005;
						$oldShieldGen[%matrix]=1;
						//echo("$oldshieldgen[" @ %matrix @ "] = 1");
						//$shieldEnhanced[%obj]=1;
						//$died[%clientId]=0;
						//$Enhanced[%ClientId]++;
					}
				}
				else if($oldShieldGen[%matrix]==1)
				//else if ($shieldEnhanced[%clientId] == 1)
				{
					//%obj = Client::getOwnedObject(%clientId);
					//if ($died[%clientId] != 1)
					//{
						%recharge=GameBase::getRechargerate(%obj)-15;
						if (%recharge > 7 || $empTime[%clientId] > 0)
						{
							//echo("Recharge rate client " @ %clientId @ " is " @ %recharge);
							GameBase::setRechargeRate(%obj,%recharge);
							client::sendMessage(%clientId,1,"Left generator #" @ %this @ "'s enhancing range. ");
						}
					//}
					//$died[%obj]=0;
					
					if(Player::getMountedItem(%obj,$BackpackSlot) == "shieldpack")
					{
						if(Player::isTriggered(%obj, $BackpackSlot) == true)
						{
						}
					}
					else %obj.shieldStrength = 0.0;
					$oldShieldGen[%matrix]=0;
					//echo("$oldshieldgen[" @ %matrix @ "] = 0");
					//$shieldEnhanced[%clientId]=0;
					//$Enhanced[%ClientId]--;
				}
			}
		}
	}
	schedule("DShield::checkAreaDfox("@%this@");",5, %this);
}

// This is a MiniMod plugin
// This is the Shotgun From Ultra-Renegades.
// Code donated by URG_thrash, decompressed/ported by Dewy.

//$AutoUse[Shotgun] = True; 


//MiniMod::WeaponCycle(Blaster, Shotgun, PlasmaGun);

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

ItemData ShotgunShells
{
description = "Shotgun Shells";
className = "Ammo";
shapeFile = "ammo2";
heading = "xAmmunition";
shadowDetailMask = 4;
price = 2;
}; 

function ShotgunImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
	Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
	if(%AmmoCount != 1)
		{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player); 
                Shotgun::Fire::Volley(%trans,%player,%vel);
                return;
		}
	else
	{
        Shotgun::Fire::Volley(%trans,%player,%vel);
        if(%AmmoCount == 1)
             {
             Shotgun::Fire::Volley(%trans,%player,%vel);
             remoteNextWeapon(%player);
             }
        }
}

SoundData SoundFireShotgun
{
wavFileName = "mine_exp.wav"; profile = Profile3dNear;
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

///-----------------------------------------------
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------



ItemImageData SpringPackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0.1 };
        mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
};

ItemData SpringPack
{
        description = "Springboard";
        shapeFile = "ammopack";
        className = "Backpack";
        heading = "sPersonnel Movers";
        imageType = SpringPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function SpringPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function SpringPack::onDeploy(%player,%item,%pos)
{
        if (SpringPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function SpringPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "Springboard"] < $TeamItemMax[Springboard]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                            %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set, Springboard, %num);
                        deleteObject(%set);


                        %rot = GameBase::getRotation(%player);
                        %objSpringboard = newObject("Springboard", "StaticShape", Springboard, true);


                        addToSet("MissionCleanup", %objSpringboard);
                        GameBase::setTeam(%objSpringboard, GameBase::getTeam(%player));
                        GameBase::setPosition(%objSpringboard, $los::position);
                        GameBase::setRotation(%objSpringboard, %rot);
                        Gamebase::setMapName(%objSpringboard, "Springboard");
                        Client::sendMessage(%client,0,"Springboard Deployed");
                         echo("MSG: ",%client," deployed a SpringBoard");
                        GameBase::startFadeIn(%objSpringboard);
                        playSound(SoundPickupBackpack, $los::position);
                        $TeamItemCount[GameBase::getTeam(%player) @ "Springboard"]++;
                        return true;
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

///-----------------------------------------------
/// description = "Suicide DetPack";
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
///-----------------------------------------------



ItemImageData SuicidePackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.5, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;

};

ItemData SuicidePack
{
        description = "Demolition Pack";
        shapeFile = "magcargo";
        className = "Backpack";
   	heading = "cBackpacks";
        imageType = SuicidePackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 450;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function SuicidePack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function SuicidePack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "This pack once deployed has a 20 sec. fuse and will destroy anything within a 50m blast radius.  Use this on forcefields.  The Demolition Pack can be disarmed by the engineer.");
}

function SuicidePack::onUnmount(%player,%item)
{
        deleteObject(%item);	
}

function SuicidePack::onDeploy(%player,%item,%pos)
{
        if (SuicidePack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function SuicidePack::deployShape(%player,%item)
{
        Player::unmountItem(%player,$BackpackSlot);

                        %obj = newObject("","Mine","Suicidebomb2");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
                        Client::sendMessage(%client,1,"Demolition Pack will destruct in 20 seconds");
                         echo("MSG: ",%client," deployed a Demolition Pack");



}

//This is a MiniMod Plugin...
//This is the Teleport Pad from the ol' Renegades1.2 mod. Ported&Modified by Dewy.



ItemImageData DeployableTeleportPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableTeleportPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
    	heading = "sPersonnel Movers";
	imageType = DeployableTeleportPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableTeleportPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "Creates a Point-Point link between two Teleport Platforms once both are deployed");
}


function DeployableTeleportPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableTeleportPack::onDeploy(%player,%item,%pos)
{
	if (DeployableTeleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) {
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

function DeployableTeleportPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) {
		if (GameBase::getLOSInfo(%player,10)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

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

//EMP Grenade Launcher from Havoc

ItemData EMPGrenadeAmmo 
{ 
	description = "EMPGrenadeAmmo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData EMPGrenadeLauncherImage 
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = EMPGrenadeAmmo;
	projectileType = EMPGrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundLaserIdle;
};
 
ItemData EMPGrenadeLauncher 
{ 
	description = "EMP Grenade Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sensorjamerpack";
	heading = "bProjectile Weapons";
	shadowDetailMask = 4;
	imageType = EMPGrenadeLauncherImage;
	price = 475;
	showWeaponBar = true;
};
 
ItemImageData BotGunImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 5;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BotGun
{
	description   = "BotGun";
	className     = "Weapon";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   	heading = "tTools";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 25;
	showWeaponBar = false;
};

function checkbase(%loc,%obj,%player)
{
	%obj = getObjectType(%obj);
	%inbase = true;
	if (%obj == "InteriorShape")
	{
		%inbase = false;
		%Set = newObject("set",SimSet); 
		%Mask = $StaticObjectType; 
		%num =containerBoxFillSet(%Set, %Mask, %loc, 70, 70, 50,0);
		for(%i; %i < %num; %i++)
		{
			%thing = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
			{
				
				%itemname = gamebase::getDataName(%thing);
				//echo(%itemname);
				if (%itemname == "PlasmaTurret" || %itemname == "AmmoStation" || %itemname == "CommandStation" || %itemname == "Generator" || %itemname == "ELFTurret" || %itemname == "RocketTurret" || %itemname == "MortarTurret" || %itemname == "IndoorTurret" || %itemname == "SolarPanel" || %itemname == "VehicleStation")
				{
					%inbase= true;
				}
				//return true;
				//break;
			}
		}
		//return false;
	}
	//else return true;
	//if (%inbase == true) return true;
	//else return false;
	return %inbase;
	
}

function checkenemybase(%loc,%obj,%player)
{
	%obj = getObjectType(%obj);
	%inenemybase = false;
	if (%obj == "InteriorShape")
	{
		//%inenemybase = false;
		%Set = newObject("set",SimSet); 
		%Mask = $StaticObjectType; 
		%num =containerBoxFillSet(%Set, %Mask, %loc, 70, 70, 50,0);
		for(%i; %i < %num; %i++)
		{
			%thing = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%thing) != GameBase::getTeam(%player))
			{
				
				%itemname = gamebase::getDataName(%thing);
				//echo(%itemname);
				if (%itemname == "PlasmaTurret" || %itemname == "AmmoStation" || %itemname == "CommandStation" || %itemname == "Generator" || %itemname == "ELFTurret" || %itemname == "RocketTurret" || %itemname == "MortarTurret" || %itemname == "IndoorTurret" || %itemname == "SolarPanel" || %itemname == "VehicleStation")
				{
					%inenemybase= true;
				}
			}
		}
		//return false;
	}
	//else return true;
	//if (%inbase == true) return true;
	//else return false;
	return %inenemybase;
	
}

function Cloaker(%player)
{
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
	{
		%TargetPlayer = Client::getOwnedObject(%clientId);
		if(GameBase::GetTeam(%clientId) != GameBase::GetTeam(%player))
		{
			echo("running checkdistance routine");
			%UserPos=gamebase::getPosition(%player);
			%TargetPos=gamebase::getPosition(%TargetPlayer);
			%dist = Vector::getDistance(%UserPos, %TargetPos);
			%matrix = %clientId @ %player;
			if(%dist < 90 && $cloaked[%player] == 1)
			{
				if($cloakEffected[%matrix] != 1)
				{
					echo("running detriangle routine");
					Player::setDetectParameters(%Targetplayer, 50, 150);
					//$cloakEffected[%matrix] = 1;
					$TotalCloaks[%ClientId]++;
					$cloakEffected[%matrix] = 1;
					echo("Cloaker[" @ %ClientId @ "] " @ $TotalCloaks[%ClientId]);
				}
			}
			else
			{
				if($cloakEffected[%matrix] == 1) $TotalCloaks[%ClientId]--;
				if($TotalCloaks[%ClientId] < 1)
				{
					echo("running retriangle routine");
					Player::setDetectParameters(%Targetplayer, 0.027, 0);
					$cloakEffected[%matrix] = 0;
					echo("Cloaker[" @ %ClientId @ "] " @ $TotalCloaks[%ClientId]);
				}
			}
		}
	}
	if(Player::isTriggered(%player, $BackPackSlot) && Player::getMountedItem(%player, $BackPackSlot) == "CloakingDevice") 
	{
		schedule("Cloaker(" @ %player @ ");", 1.0, %player);
	}
	//else if(Player::getMountedItem(%player, $BackPackSlot) == "CloakingDevice" && $TotalCloaks[%ClientId] < 1)
	//{
	//	echo("running secondary retriangle routine");
	//	Player::setDetectParameters(%Targetplayer, 0.027, 0);
	//	%matrix = %clientId @ %player;
	//	$cloakEffected[%matrix] = 0;
	//	echo("Cloaker[" @ %ClientId @ "] " @ $TotalCloaks[%ClientId]);
	//}
}