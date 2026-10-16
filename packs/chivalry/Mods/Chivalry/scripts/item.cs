//----------------------------------------------------------------------------

$ItemFavoritesKey = "ChivalryV20";  // Change this if you add new items
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
$CrownSlot = 4;
$Crown2Slot = 5;
$Crown3Slot = 6;

$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = True;
$AutoUse[Reincarnation] = True;
$AutoUse[DaHammer] = True;
$AutoUse[StormLauncher] = True;
$AutoUse[Predator] = True;
$AutoUse[Shredder] = True;
$AutoUse[Volcano] = True;
$AutoUse[Inferno] = True;
$AutoUse[HealSpell] = True;
$AutoUse[ShockwaveGun] = True;
$AutoUse[Stubber] = True;
$AutoUse[Viper] = True;
$AutoUse[Scattergun] = True;
$AutoUse[HvyPlasma] = True;
$AutoUse[Stasis] = True;
$AutoUse[CrafterGun] = True;
$AutoUse[Fingers] = True;
$AutoUse[ShieldSpell] = True;
$AutoUse[EmpSpell] = True;
$AutoUse[PaladinHeal] = false;
$AutoUse[WarlordShield] = false;
$AutoUse[WarlordCharge] = false;
$AutoUse[WarlordRite] = false;
$AutoUse[PaladinRite] = false;
$AutoUse[UndeadSpell] = false;
$AutoUse[Disarmer] = true;
$AutoUse[Turn] = true;
$AutoUse[Summon] = true;
$AutoUse[Slingshot] = true;
$AutoUse[MIRV] = true;
$AutoUse[Life] = false;
$AutoUse[Brim] = false;
$AutoUse[HolyWeapon] = true;
$AutoUse[GiveHoly] = true;

$Use[Blaster] = True;

$ArmorType[Male, MageArmor] = magarmor;
$ArmorType[Male, ScoutArmor] = scarmor;
$ArmorType[Male, WarriorArmor] = worarmor;
$ArmorType[Male, CrafterArmor] = cftarmor;
$ArmorType[Male, PaladinArmor] = palarmor;
$ArmorType[Male, LeviathanArmor] = lavarmor;
$ArmorType[Male, ClericArmor] = clrarmor;
$ArmorType[Female, MageArmor] = magfemale;
$ArmorType[Female, ScoutArmor] = scfemale;
$ArmorType[Female, WarriorArmor] = worfemale;
$ArmorType[Female, CrafterArmor] = cftfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Female, PaladinArmor] = palarmor;
$ArmorType[Female, LeviathanArmor] = lavarmor;
$ArmorType[Female, ClericArmor] = clrfemale;

$ArmorName[magarmor] = MageArmor;
$ArmorName[scarmor] = ScoutArmor;
$ArmorName[worarmor] = WarriorArmor;
$ArmorName[cftarmor] = CrafterArmor;
$ArmorName[palarmor] = PaladinArmor;
$ArmorName[lavarmor] = LeviathanArmor;
$ArmorName[clrarmor] = ClericArmor;
$ArmorName[magfemale] = MageArmor;
$ArmorName[scfemale] = ScoutArmor;
$ArmorName[worfemale] = WarriorArmor;
$ArmorName[cftfemale] = CrafterArmor;
$ArmorName[clrfemale] = ClericArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[DaHammerAmmo] = 1;
$SellAmmo[StormLauncherAmmo] = 25;
$SellAmmo[PredatorAmmo] = 10;
$SellAmmo[ShredderAmmo] = 20;
$SellAmmo[VolcanoAmmo] = 5;
$SellAmmo[StubberAmmo] = 20;
$SellAmmo[ViperAmmo] = 5;
$SellAmmo[ScattergunAmmo] = 5;
$SellAmmo[HvyPlasmaAmmo] = 15;
$SellAmmo[StasisMine] = 20;
$SellAmmo[ShockwaveMine] = 15;
$SellAmmo[ProxMine] = 10;
$SellAmmo[SmokeGren] = 4;
$SellAmmo[EmpMine] = 5;
$SellAmmo[DisarmerShell] = 5;
$SellAmmo[SlingshotAmmo] = 8;
$SellAmmo[HeMIRVAmmo] = 5;
$SellAmmo[EmpMIRVAmmo] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[Beacon] = 10;
$AmmoPackMax[DaHammerAmmo] = 10;
$AmmoPackMax[StormLauncherAmmo] = 100;
$AmmoPackMax[PredatorAmmo] = 30;
$AmmoPackMax[ShredderAmmo] = 40;
$AmmoPackMax[StubberAmmo] = 100;
$AmmoPackMax[ViperAmmo] = 5;
$AmmoPackMax[ScattergunAmmo] = 10;
$AmmoPackMax[SlingshotAmmo] = 8;
$AmmoPackMax[HvyPlasmaAmmo] = 60;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = ScattergunAmmo;
$AmmoPackItems[5] = HvyPlasmaAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = DaHammerAmmo;
$AmmoPackItems[9] = StormLauncherAmmo;
$AmmoPackItems[10] = PredatorAmmo;
$AmmoPackItems[11] = ShredderAmmo;
$AmmoPackItems[12] = StubberAmmo;
$AmmoPackItems[13] = ViperAmmo;
$AmmoPackItems[14] = SlingshotAmmo;


// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 5;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 2;
$TeamItemMax[GunshipVehicle] = 2;
$TeamItemMax[CrawlerVehicle] = 1;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;
$TeamItemMax[Volcano] = 2;
$TeamItemMax[LaserRifle] = 2;
$TeamItemMax[Viper] = 2;
$TeamItemMax[ShockwvPack] = 2;
$TeamItemMax[BugPack] = 2;
$TeamItemMax[LaserPack] = 5;
$TeamItemMax[DepRocketPack] = 2;
$TeamItemMax[AhnPack] = 1;
$TeamItemMax[VulcPack] = 2;
$TeamItemMax[StutPack] = 4;
$TeamItemMax[PlasPack] = 2;
$TeamItemMax[DepSmFFPack] = 6;
$TeamItemMax[StasisMine] = 15;
$TeamItemMax[ShockwaveMine] = 15;
$TeamItemMax[DepFFDoorPack] = 2;
$TeamItemMax[ProxMine] = 10;
$TeamItemMax[ForceShieldPack] = 2;
$TeamItemMax[BunkerPack] = 4;
$TeamItemMax[DepLgFFPack] = 2;
$TeamItemMax[WallPack] = 2;
$TeamItemMax[FalconVehicle] = 2;
$TeamItemMax[MinelayerVehicle] = 1;
$TeamItemMax[PhoenixVehicle] = 1;
$TeamItemMax[BomberVehicle] = 1;
$TeamItemMax[ComJamPack] = 2;
$TeamItemMax[SatComPack] = 2;
$TeamItemMax[EmpMine] = 15;
$TeamItemMax[Disarmer] = 1;
$TeamItemMax[MIRV] = 1;
$TeamItemMax[LifeAltar] = 1;
$TeamItemMax[BrimstoneAltar] = 1;

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
$WeaponAmmo[Reincarnation] = ""; //ReincarnationAmmo;
$WeaponAmmo[DaHammer] = DaHammerAmmo;
$WeaponAmmo[StormLauncher] = StormLauncherAmmo;
$WeaponAmmo[Predator] = PredatorAmmo;
$WeaponAmmo[Shredder] = ShredderAmmo;
$WeaponAmmo[Volcano] = VolcanoAmmo;
$WeaponAmmo[Inferno] = "";
$WeaponAmmo[ShockwaveGun] = "";
$WeaponAmmo[Stubber] = StubberAmmo;
$WeaponAmmo[Viper] = ViperAmmo;
$WeaponAmmo[Scattergun] = ScattergunAmmo;
$WeaponAmmo[HvyPlasma] = HvyPlasmaAmmo;
$WeaponAmmo[Stasis] = "";
$WeaponAmmo[CrafterGun] = "";
$WeaponAmmo[Fingers] = "";
$WeaponAmmo[ShieldSpell] = "";
$WeaponAmmo[EmpSpell] = "";
$WeaponAmmo[UndeadSpell] = "";
$WeaponAmmo[Disarmer] = DisarmerShell;
$WeaponAmmo[HealSpell] = "";
$WeaponAmmo[Turn] = "";
$WeaponAmmo[Summon] = "";
$WeaponAmmo[Slingshot] = SlingshotAmmo;
//$WeaponAmmo[MIRV] = "";
$WeaponAmmo[Life] = "";
$WeaponAmmo[Brim] = "";
$WeaponAmmo[HolyWeapon] = "";
$WeaponAmmo[GiveHoly] = "";
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

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%count)
{
	if (isPlayerBusy(%client))
		return;
if(!%count)
EchoBuy(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%count);
%armor = Player::getArmor(%client);
%cl = Client::getOwnedObject(%client);
if(%armor == "harmor")
{
Client::sendMessage(%client,0,"Cannot use Inventory Stations wile in Stasis.");
return;
}
   // only can buy fav every 1/2 second
   %time = getIntegerTime(true) >> 4; // int half seconds 
   if(%time <= %client.lastBuyFavTime)
      return;

   %client.lastBuyFavTime = %time;

	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" ) {
		if(%armor == "harmor")
		{
		Client::sendMessage(%client,0,"Cannot use Inventory Stations while in Stasis.");
		//ixStationEjectPlayer(%station,%cl);
		return;
		}
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

function EchoBuy(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%count)
{
%count = 1;
schedule("remoteBuyFavorites("@%client@","@floor(%favItem0)@","@floor(%favItem1)@","@floor(%favItem2)@","@floor(%favItem3)@","@floor(%favItem4)@","@floor(%favItem5)@","@floor(%favItem6)@","@floor(%favItem7)@","@floor(%favItem8)@","@floor(%favItem9)@","@floor(%favItem10)@","@floor(%favItem11)@","@floor(%favItem12)@","@floor(%favItem13)@","@floor(%favItem14)@","@floor(%favItem15)@","@floor(%favItem16)@","@floor(%favItem17)@","@floor(%favItem18)@","@floor(%favItem19)@","@%count@");",0.5,%clientId);
}

function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}


function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	%team = Client::getTeam(%client);
	if(%armor == "harmor")
	{
	Client::sendMessage(%client,0,"Cannot use Inventory Stations while in Stasis.");
	return 0;
	}
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
		if(%item == LaserRifle || %item == Disarmer)
		{
			if(%item != "LaserRifle" && Player::getItemCount(%client,"LaserRifle") > 0)
			{
			Client::sendMessage(%client,0,"Only one Sniper Weapon per Ranger allowed.");
			return 0;
			}
			else if(%item != "Disarmer" && Player::getItemCount(%client,"Disarmer") > 0)
			{
			Client::sendMessage(%client,0,"Only one Sniper Weapon per Ranger allowed.");
			return 0;
			}
		}
  	}
	else if(%item.className == HandAmmo)
	{
			if(%item != Grenade && %item != Beacon && %item != SmokeGren)
			{
			if(%item != "MineAmmo" && Player::getItemCount(%client,"MineAmmo") > 0)
				{
			Client::sendMessage(%client,0,"Only one type of Mine may be carried at a time.");
			return 0;
				}
			else if(%item != "ShockwaveMine" && Player::getItemCount(%client, "ShockwaveMine") > 0)
				{
			Client::sendMessage(%client,0,"Only one type of Mine may be carried at a time.");
			return 0;
				}
			else if(%item != "ProxMine" && Player::getItemCount(%client, "ProxMine") > 0)
				{
			Client::sendMessage(%client,0,"Only one type of Mine may be carried at a time.");
			return 0;
				}
			else if(%item != "EmpMine" && Player::getItemCount(%client, "EmpMine") > 0)
				{
			Client::sendMessage(%client,0,"Only one type of Mine may be carried at a time.");
			return 0;
				}
			else if(%item != "StasisMine" && Player::getItemCount(%client, "StasisMine") > 0)
				{
			Client::sendMessage(%client,0,"Only one type of Mine may be carried at a time.");
			return 0;
				}
			}
		else if(%item == Grenade || %item == SmokeGren)
			{
			if(%item != "Grenade" && Player::getItemCount(%client, "Grenade") > 0)
				{
			Client::sendMessage(%client,0,"Only one type of Grenade carried at a time.");
			return 0;
				}
			else if(%item != "SmokeGren" && Player::getItemCount(%client, "SmokeGren") > 0)
				{
			Client::sendMessage(%client,0,"Only one type of Grenade carried at a time.");
			return 0;
				}
			}
	}
	else if(%item.className == Ammo)
	{
		if(%item == HeMIRVAmmo || %item == EmpMIRVAmmo)
		{
			if(%item != HeMIRVAmmo && Player::getItemCount(%client, HeMIRVAmmo) > 0)
			{
			Client::sendMessage(%client,0,"Only one type of MIRV ammunition may be carried at a time.");
			return 0;
			}
			else if(%item != EmpMIRVAmmo && Player::getItemCount(%client, EmpMIRVAmmo) > 0)
			{
			Client::sendMessage(%client,0,"Only one type of MIRV ammunition may be carried at a time.");
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
	if(%armor == "harmor")
	{
	Client::sendMessage(%client,0,"Cannot use Inventory Stations while in Statis.");
	return 0;
	}
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
		else if(%item.className == HandAmmo)
		{
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			if(%delta || $testCheats)
			{
			Player::incItemCount(%client,%item, %delta);
			return 1;
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
	%armor = Player::getArmor(%client);
	if(%armor == "harmor")
	{
	Client::sendMessage(%client,0,"Cannot use Inventory Stations while in Statis.");
	return;
	}
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
	%armor = Player::getArmor(%client);
	if(%armor == "harmor")
	{
	Client::sendMessage(%client,0,"Cannot use Inventory Stations while in Statis.");
	return;
	}

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
			else if (%item == PaladinHeal || %item == NoUndead || %item == PaladinRite)
				Client::sendMessage(%client,0,"Cannot sell Paladin Ability. ~wC_BuySell.wav");
			else if (%item == WarlordShield || %item == WarlordCharge || %item == WarlordRite)
				Client::sendMessage(%client,0,"Cannot sell Warlord Ability. ~wC_BuySell.wav");
			else if (%item == UndeadSpell)
				Client::sendMessage(%client,0,"Cannot sell Litch King Ability. ~wC_BuySell.wav");
			else if (%item == Brimstone)
				Client::sendMessage(%client,0,"Cannot sell Brimstone Rite. ~wC_BuySell.wav");
			else if (%item == HolyWeapon)
				Client::sendMessage(%client,0,"Cannot sell Holy Weapon. ~wC_BuySell.wav");
			
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
	{
		%item = Player::getMountedItem(%client,$BackpackSlot);
		if(%item == -1)
		{
		//messageall(0,"remoteUse called."); //<--Obtained from HaVoC - no code was copied, I just wanted to see how 
		CheckUnDeploy(%client);            //<--he called his Packup Function.  Everything else is written by me.  Clu
		}
	}
	else {
		if (%item == Weapon) 
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}								

	Player::useItem(%client,%item);
}

function CheckUnDeploy(%client)
{
	//messageall(0,"CheckUndeploy Called.");
	GameBase::getLOSInfo(%client,3);
	%object = $los::object;
	%name = GameBase::getDataName(%object);
	//messageall(0,"LOS Object is "@%object@" Client is "@%client);
	if(%name.className == "Turret" || %name == "DeployableSatCom" && !%object.UnDeployed)
		schedule(%name@"::UnDeploy("@%object@","@%client@");",0.2);
}
function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
		//if(GameBase::getControlClient(%player) != -1) {
	  		echo("Throw item: " @ %type @ " " @ %strength);
			%item = getItemData(%type);
			if (%item == MineAmmo){
				if (%strength < 0)
					%strength = 0;
				else
					if (%strength > 100)
						%strength = 100;
			
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client, "ShockwaveMine");
				Player::useItem(%client, "StasisMine");
				Player::useItem(%client, "ProxMine");
				Player::useItem(%client, "EmpMine");
				}
			if (%item == Grenade){
				if (%strength < 0)
					%strength = 0;
				else
					if (%strength > 100)
						%strength = 100;
			
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client, "SmokeGren");
				}
			if (%item == Grenade || %item == MineAmmo){ 
			
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
		else if(%item == PaladinHeal || %item == NoUndead || %item == PaladinRite)
			Client::sendMessage(%client,0,"Cannot drop Paladin ability. ~wC_BuySell.wav");
		else if(%item == WarlordShield || %item == WarlordCharge || %item == WarlordRite)
			Client::sendMessage(%client,0,"Cannot drop Warlord ability. ~wC_BuySell.wav");
		else if(%item == UndeadSpell)
			Client::sendMessage(%client,0,"Cannot drop Litch King ability. ~wC_BuySell.wav");
		else if(%item == Brimstone)
			Client::sendMessage(%client,0,"Cannot drop Brimstone Rite. ~wC_BuySell.wav");
		else if(%item == HolyWeapon)
			Client::sendMessage(%client,0,"Cannot drop Holy Weapon. ~wC_BuySell.wav");
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
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = Reincarnation;
$NextWeapon[Reincarnation] = DaHammer;
$NextWeapon[DaHammer] = StormLauncher;
$NextWeapon[StormLauncher] = Predator;
$NextWeapon[Predator] = Shredder;
$NextWeapon[Shredder] = Volcano;
$NextWeapon[Volcano] = Inferno;
$NextWeapon[Inferno] = ShockwaveGun;
$NextWeapon[ShockwaveGun] = Stubber;
$NextWeapon[Stubber] = Viper;
$NextWeapon[Viper] = Scattergun;
$NextWeapon[Scattergun] = HvyPlasma;
$NextWeapon[HvyPlasma] = Stasis;
$NextWeapon[Stasis] = CrafterGun;
$NextWeapon[CrafterGun] = Fingers;
$NextWeapon[Fingers] = ShieldSpell;
$NextWeapon[ShieldSpell] = EmpSpell;
$NextWeapon[EmpSpell] = Disarmer;
$NextWeapon[Disarmer] = HealSpell;
$NextWeapon[HealSpell] = Turn;
$NextWeapon[Turn] = Summon;
$NextWeapon[Summon] = Slingshot;
$NextWeapon[Slingshot] = MIRV;
$NextWeapon[MIRV] = HolyWeapon;
$NextWeapon[HolyWeapon] = GiveHoly;
$NextWeapon[GiveHoly] = EnergyRifle;

$PrevWeapon[Blaster] = GiveHoly;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[Reincarnation] = LaserRifle;
$PrevWeapon[EnergyRifle] = Reincarnation;
$PrevWeapon[DaHammer] = EnergyRifle;
$PrevWeapon[StormLauncher] = DaHammer;
$PrevWeapon[Predator] = StormLauncher;
$PrevWeapon[Shredder] = Predator;
$PrevWeapon[Volcano] = Shredder;
$PrevWeapon[Inferno] = Volcano;
$PrevWeapon[ShockwaveGun] = Inferno;
$PrevWeapon[Stubber] = ShockwaveGun;
$PrevWeapon[Viper] = Stubber;
$PrevWeapon[Scattergun] = Viper;
$PrevWeapon[HvyPlasma] = Scattergun;
$PrevWeapon[Stasis] = HvyPlasma;
$PrevWeapon[CrafterGun] = Stasis;
$PrevWeapon[Fingers] = CrafterGun;
$PrevWeapon[ShieldSpell] = Fingers;
$PrevWeapon[EmpSpell] = ShieldSpell;
$PrevWeapon[Disarmer] = EmpSpell;
$PrevWeapon[HealSpell] = Disarmer;
$PrevWeapon[Turn] = HealSpell;
$PrevWeapon[Summon] = Turn;
$PrevWeapon[Slingshot] = Summon;
$PrevWeapon[MIRV] = Slingshot;
$PrevWeapon[HolyWeapon] = MIRV;
$PrevWeapon[GiveHoly] = HolyWeapon;

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
	%mine = Player::getItemCount(%player,MineAmmo);
	%stasis = Player::getItemCount(%player,StasisMine);
	%shock = Player::getItemCount(%player,ShockwaveMine);
	%proxy = Player::getItemCount(%player,ProxMine);
	%armor = Player::getArmor(%player);
	%gren = Player::getItemCount(%player,Grenade);
	%smk = Player::getItemCount(%player,SmokeGren);
	%emp = Player::getItemCount(%player,EmpMine);
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
		else if((%item == MineAmmo) && (%stasis > 0 || %shock > 0 || %proxy > 0 || %emp > 0))
				return 0;
		else if((%item == StasisMine) && (%mine > 0 || %shock > 0 || %proxy > 0 || %emp > 0))
				return 0;
		else if((%item == ShockwaveMine) && (%mine > 0 || %stasis > 0 || %proxy > 0 || %emp > 0))
				return 0;
		else if((%item == EmpMine) && (%mine > 0 || %stasis > 0 || %proxy > 0 || %shock > 0))
				return 0;
		else if((%item == ProxMine) && (%mine > 0 || %stasis > 0 || %shock > 0))
				return 0;	
		else if(%item == Grenade && %smk > 0)
				return 0;
		else if(%item == SmokeGren && %gren > 0)
				return 0;
		else if(%item == HeMIRVAmmo && Player::getItemCount(%player,EmpMIRVAmmo) > 0)
				return 0;
		else if(%item == EmpMIRVAmmo && Player::getItemCount(%player,HeMIRVAmmo) > 0)
				return 0;
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

ItemData MageArmor
{
   heading = "aArmor";
	description = "Mage";
	className = "Armor";
	price = 175;
};

ItemData ScoutArmor
{
   heading = "aArmor";
	description = "Ranger";
	className = "Armor";
	price = 175;
};

ItemData WarriorArmor
{
   heading = "aArmor";
	description = "Warrior";
	className = "Armor";
	price = 250;
};

ItemData CrafterArmor
{
   heading = "aArmor";
	description = "Crafter";
	className = "Armor";
	price = 250;
};

ItemData ClericArmor
{
   heading = "aArmor";
	description = "Cleric";
	className = "Armor";
	price = 300;
};

ItemData PaladinArmor
{
   heading = "aArmor";
	description = "Crusader";
	className = "Armor";
	price = 400;
};

ItemData LeviathanArmor
{
   heading = "aArmor";
	description = "Leviathan";
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

ItemData BomberVehicle
{
	description = "Heavy Bomber";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1500;
};

ItemData MinelayerVehicle
{
	description = "MineLayer HAPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1000;
};


ItemData GunshipVehicle
{
	description = "Gunship";
	className = "Vehicle";
   heading = "aVehicle";
	price = 700;
};

ItemData PhoenixVehicle
{
	description = "Phoenix";
	className = "Vehicle";
   heading = "aVehicle";
	price = 850;
};

ItemData FalconVehicle
{
	description = "Falcon";
	className = "Vehicle";
   heading = "aVehicle";
	price = 750;
};

ItemData CrawlerVehicle
{
	description = "Creeper LAPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 800;
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
	fireTime = 0.2;
	minEnergy = 2;
	maxEnergy = 4;

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

function Blaster::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Blaster - The standard energy pistol",4);
}

ItemImageData CrownImage
{
	shapeFile = "enbolt";
	mountPoint = 2;
	mountOffset = {0, 0, 0.7};
	lightType   = 2;  // Pulse
	lightRadius = 2;
	lightTime   = 1;
	lightColor  = { 0, 0, 1.0 };

};

ItemData Crown
{
	description   = "Crown";
	shapeFile     = "enbolt";
   	heading = "yMark of Honor";
	shadowDetailMask = 4;
	imageType     = CrownImage;
};

function Crown::onMount(%player, %item)
{
	Player::mountItem(%player, Crown2, $CrownSlot);
	Player::mountItem(%player, Crown3, $Crown2Slot);
	Player::mountItem(%player, Crown4, $Crown3Slot);
	%name = Client::getName(%player);
	if($Chivalry::Paladin == %name)
	Player::incItemCount(%player,"PaladinHeal",1);
	}
 
ItemImageData Crown2Image
{
	shapeFile = "enbolt";
	mountPoint = 2;
	mountOffset = {0, 0, 0.7};
	mountRotation = {0, 0, 1.5};
};

ItemData Crown2
{
	description   = "Crown";
	shapeFile     = "enbolt";
	heading = "yMark of Honor";
	shadowDetailMask = 4;
	imageType     = Crown2Image;
};

ItemImageData Crown3Image
{
	shapeFile = "enbolt";
	mountPoint = 2;
	mountOffset = {0, 0, 0.7};
	mountRotation = {0, 0, -1};

};

ItemData Crown3
{
	description   = "Crown";
	shapeFile     = "enbolt";
	heading = "yMark of Honor";
	shadowDetailMask = 4;
	imageType     = Crown3Image;
};

ItemImageData Crown4Image
{
	shapeFile = "enbolt";
	mountPoint = 2;
	mountOffset = {0, 0, 0.7};
	mountRotation = {0, 0, -3};
	
};

ItemData Crown4
{
	description   = "Crown";
	shapeFile     = "enbolt";
   heading = "yMark of Honor";
	shadowDetailMask = 4;
	imageType     = Crown4Image;
};


//----------------------------------------------------------------------------

ItemData PredatorAmmo
{
	description = "Predator Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 30;
};

ItemImageData PredatorImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;

	ammoType = PredatorAmmo;
	projectileType = PredatorBullet;
	accuFire = True;

	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 3;
	lightColor = { 1, 2, 4 };

	sfxFire = shockExplosion;
	sfxActivate = SoundWeaponSelect;
};

ItemData Predator
{
	description = "Predator";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PredatorImage;
	price = 300;
	showWeaponBar = true;
};

function Predator::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Predator Pistol - Fires short range Armor Piercing rounds.", 4);
	
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
	price = 125;
	showWeaponBar = true;
};

function Chaingun::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Chaingun - The mainstay assault weapon with a higher rate of fire.", 4);
}

//----------------------------------------------------------------------------

ItemData StubberAmmo
{
	description = "Stubber Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData StubberImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.2;

	ammoType = StubberAmmo;
	projectileType = StubberShell;
	accuFire = True;

	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 1;
	lightColor = { 1, 1, 1 };

	sfxFire = bigExplosion4;
	sfxActivate = SoundWeaponSelect;
};

ItemData Stubber
{
	description = "Stubber";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = StubberImage;
	price = 320;
	showWeaponBar = true;
};

function Stubber::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Stubber - Fires medium ranged incendiary rounds.", 4);
	
}

//-------------------------------------------------

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

function PlasmaGun::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Plasma Gun - Standard plasma launching weapon..", 4);
}

//----------------------------------------------------------------------------

ItemData HvyPlasmaAmmo
{
	description = "Heavy Plasma Bolt";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData HvyPlasmaImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = HvyPlasmaAmmo;
	projectileType = HvyPlasmaBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.4;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData HvyPlasma
{
	description = "Heavy Plasma";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HvyPlasmaImage;
	price = 175;
	showWeaponBar = true;
};
function HvyPlasma::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Heavy Plasma - Increased Plasma damage with moderate firing rate and medium range.", 4);
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
};

function GrenadeLauncher::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Grenade Launcher - Medium ranged indirect fire weapon.", 4);
}

//----------------------------------------------------------------------------
ItemData VolcanoAmmo
{
	description = "Volcano Mine Pack";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};


ItemImageData VolcanoImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = VolcanoAmmo;
	projectileType = VolcanoShell;
	accuFire = false;
	reloadTime = 1;
	fireTime = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Volcano
{
	description = "Volcano Mine Dispenser";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = VolcanoImage;
	price = 200;
	showWeaponBar = true;
};

function Volcano::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Volcano Mine Dispenser - Expediant minelaying tool.", 4);
}

//--------------------------------------------------------
ItemData ViperAmmo
{
description = "Viper Rockets";
className = "Ammo";
heading = "xAmmunition";
shapeFile = "mortarammo";
shadowDetailMask = 4;
price = 150;
};

ItemImageData ViperImage
{
shapeFile = "mortargun";
mountPoint = 0;
//mountOffset = { 0.56, 0.1, 0.575 };
//mountRotation = { 0, 1.57, 0 };
weaponType = 0; // Sustained
ammoType = ViperAmmo;
//projectileType = ViperRocket;
accuFire = true;
fireTime = 0.1;
reloadTime = 2.0;
lightType = 3; // Weapon Fire
lightRadius = 3;
lightTime = 1;
lightColor = { 1.0, 1.0, 1.0 };
sfxActivate = SoundPickUpWeapon;
//sfxReady = SoundRocketTurretTurn;
};

ItemData Viper
{
description = "Viper";
className = "Weapon";
shapeFile = "mortargun";
hudIcon = "mortar";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = ViperImage;
price = 500;
showWeaponBar = true;
};

function Viper::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Viper - Guided missile launcher.", 4);
}

function ViperImage::OnFire(%player, %slot) 
{
%client = Player::getClient(%player);
%client.targetLock = 0;
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
%newObj = Projectile::spawnProjectile("ViperPrep",%trans,%player,%vel);
schedule("deleteobject(" @ %newObj @ ");",0.1,%newObj);
schedule("Viper::fireRockets(" @ %player @ ",3);",0.05,%player);
}
function Viper::fireRockets(%player,%count)
{
%client = GameBase::getControlClient(%player);
if(Player::getItemCount(%player,ViperAmmo)) {
Player::decItemCount(%player,ViperAmmo, 1);
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);
//GameBase::PlaySound(%player, SoundRocketTurretFire, 2);
if(%client.targetLock)
Projectile::spawnProjectile("ViperMissile",%trans,%player,%vel,%client.targetLock);
else
Projectile::spawnProjectile("ViperRocket",%trans,%player,%vel);
%count--;
}
if(%count && Player::getItemCount(%player,ViperAmmo))
schedule("Nothing::fireRockets(" @ %player @ "," @ %count @ ");",0.2,%player);
else {
if(Player::getItemCount(%player,ViperAmmo))
GameBase::PlaySound(%player, SoundRocketTurretOn, 3);
else
GameBase::PlaySound(%player, SoundRocketTurretOff, 3);
}
}
//----------------------------------------------------------------------------
ItemData DisarmerShell
{
	description = "Disarmer Battery";
	className = "Ammo";
	shapeFile = "plasammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData DisarmerImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 3;
	fireTime = 1;

	ammoType = DisarmerShell;
	accuFire = True;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0.5, 1 };

	sfxFire = SoundBigElec;
	sfxActivate = SoundWeaponSelect;
};

ItemData Disarmer
{
	description = "Disarmer Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DisarmerImage;
	price = 420;
	showWeaponBar = true;
};

function Disarmer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Disarmer Rifle - Electrical Sniper weapon which may cause its victims to drop their weapon.", 4);
	
}

function DisarmerImage::onFire(%player, %slot)
{
	%ammo = Player::getItemCount(%player, $WeaponAmmo[Disarmer]);
	if(%ammo)
	{
		%client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	    	 %vel = Item::getVelocity(%player);
		%newObj = Projectile::spawnProjectile("DisarmerJolt",%trans,%player,%vel);
		Projectile::spawnProjectile("DropShell",%trans,%player,%vel);
		schedule("deleteobject(" @ %newObj @ ");",1,%newObj);
		Player::decItemCount(%player,DisarmerShell,1);
	}
else
	Client::sendMessage(Player::getClient(%player), 0,"No Batteries Remain!");
}

//---------------------------------------------------------
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

function Mortar::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Mortar - Long ranged indirect fire weapon.", 4);
}

//---------------------------------------------------------
ItemData HeMIRVAmmo
{
	description = "HE MIRV Shell";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemData EmpMIRVAmmo
{
	description = "EMP MIRV Shell";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};


ItemImageData MIRVImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//ammoType = MIRVAmmo;
	//projectileType = MIRVShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	//sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundMortarReload;
	//sfxReady = SoundMortarIdle;
};

ItemData MIRV
{
	description = "MIRV";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MIRVImage;
	price = 375;
	showWeaponBar = true;
};

function MIRV::onMount(%player, %item)
{
if(Player::getItemCount(%player, EmpMIRVAmmo) > 0)
		{
		GameBase::playSound(%player, SoundTurretDeploy, 2);
		//$WeaponAmmo[MIRV] = EmpMIRVAmmo;
		//%item.ammoType = EmpMIRVAmmo;
		}
else if(Player::getItemCount(%player, HeMIRVAmmo) > 0)
		{
		GameBase::playSound(%player, SoundTurretDeploy, 2);
		//$WeaponAmmo[MIRV] = HeMIRVAmmo;
		//%item.ammoType = HeMIRVAmmo;
		}
else 
	{
	Player::unmountItem(%player, $WeaponSlot);
	//Client::SendMessage(Player::getClient(%player),0,"MIRV out of Ammo.");
	}

}

function MIRV::onUse(%player,%item)
{
		if(Player::getItemCount(%player,EmpMIRVAmmo))
		{
		%count = Player::getItemCount(%player,EmpMIRVAmmo);
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>MIRV - Fires a projectile with Sub-Munitions.  It is loaded with "@%count@" EMP rounds.", 4);
		}
		else
		{
		%count = Player::getItemCount(%player,HeMIRVAmmo);
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>MIRV - Fires a projectile with Sub-Munitions.  It is loaded with "@%count@" HE rounds.", 4);
		}
}

function MIRVImage::onFire(%player, %slot)
{
	%EmpCount = Player::getItemCount(%player, EmpMIRVAmmo);
	%HeCount = Player::getItemCount(%player, HeMIRVAmmo);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	 if(%EmpCount) 
	{
		GameBase::playSound(%player, SoundFireMortar, 2);
		Projectile::spawnProjectile("EmpMIRVShell",%trans,%player,%vel);
		Player::decItemCount(%player,EmpMIRVAmmo,1);
	}
	else if(%HeCount)
	{
		GameBase::playSound(%player, SoundFireMortar, 2);
		Projectile::spawnProjectile("HeMIRVShell",%trans,%player,%vel);
		Player::decItemCount(%player,HeMIRVAmmo,1);
	}
	else
	Client::sendMessage(Player::getClient(%player),0,"MIRV out of Ammo.");
}
//----------------------------------------------------------------------------
ItemData DaHammerAmmo
{
	description = "DaHammer Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData DaHammerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, -3.0, 0 };

	weaponType = 0; // Single Shot
	ammoType = DaHammerAmmo;
	projectileType = DaHammerRocket;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 3;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundGeneratorPower;
};

ItemData DaHammer
{
	description = "DaHammer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DaHammerImage;
	price = 380;
	showWeaponBar = true;
};

function DaHammer::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Da Hammer - Direct fire High Explosive assault weapon.", 4);
}

//----------------------------------------------------------------------------
ItemData SlingshotAmmo
{
	description = "Trident Rocket";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 8;
};

ItemImageData SlingshotImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, -3.0, 0 };

	weaponType = 0; // Single Shot
	ammoType = SlingshotAmmo;
	//projectileType = DaHammerRocket;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 2;
	lightColor = { 1, 0.5, 0.5 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	//sfxReady = SoundMortarIdle;
};

ItemData Slingshot
{
	description = "Trident Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "blaster";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SlingshotImage;
	price = 250;
	showWeaponBar = true;
};

function Slingshot::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Trident Launcher - Fires a triple rocket volley.", 4);
}

function SlingshotImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Slingshot]);
	 if(%AmmoCount) 
	{

		%client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[Slingshot],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("SlingBullet",%trans,%player,%vel);
                        Projectile::spawnProjectile("SlingBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("SlingBullet",%trans,%player,%vel);
	}
	else
	Client::sendMessage(Player::getClient(%player),"Trident Launcher out of Ammo.");
}
//----------------------------------------------------------------------------

//Thanks Mathias!!
ItemData StormLauncherAmmo
{
	description = "Storm Rocket";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 30;
};

ItemImageData StormLauncherImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 3.0, 0 };

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = StormLauncherAmmo;
	projectileType = StormRocket;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1, 2, 5 };

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData StormLauncher
{
	description = "Storm Launcher";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = StormLauncherImage;
	price = 475;
	showWeaponBar = true;
};

function StormLauncher::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Storm Launcher - Rapid fire medium yield rocket launcher.", 4);
}

//======================================================================== Boom Stick
//Thanks again, Mathias!!

ItemData ScattergunAmmo
{
	description = "Scattergun Shells";
	className = "Ammo";
    heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ScattergunImage 
{
	shapeFile = "shotgun";
    mountPoint = 0;

	ammoType = ScattergunAmmo;
	//projectileType = "Undefined";
	weaponType = 0; // Single Shot
	reloadTime = 2.0;
	fireTime = 1.0;
	minEnergy = 5;
	maxEnergy = 6;
                        
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireDisc;
	sfxReload   = SoundMortarReload;
   
};

ItemData Scattergun
{
    description = "Scattergun";
	shapeFile = "shotgun";
	hudIcon = "blaster";
	heading = "bWeapons";
    className = "Weapon";
    shadowDetailMask = 4;
    imageType = ScattergunImage;
	showWeaponBar = true;
    price = 350;
};

function Scattergun::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Scattergun - Launches a volley of high explosive shells.", 4);
}

function ScattergunImage::onFire(%player, %slot) 
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Scattergun]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[Scattergun],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);
	
                        Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
                        Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
                        Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
                        Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
                        Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
                        Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
			Projectile::spawnProjectile("ScattergunBullet",%trans,%player,%vel);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}


//--------------------------------------------------------------------------------

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

function DiscLauncher::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Disc Launcher - Traditional Tribal weapon.", 4);
}

//----------------------------------------------------------------------------

ItemData ShredderAmmo
{
	description = "Shredder Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ShredderImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0; // 3=DiscLauncher 0=Single
	ammoType = ShredderAmmo;
	projectileType = ShredderDiscShell;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.3;
	//spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData Shredder
{
	description = "Shredder";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ShredderImage;
	price = 150;
	showWeaponBar = true;
};

function Shredder::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Shredder - Rapid fire energy based disc launcher.", 4);
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
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack){
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Laser Rifle - Extreme long range sniper weapon..", 4);

}

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
	lightColor  = { 0.0, 0.0, 0.0 };

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
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Targeting Laser - Target designation tool for indirect fire.", 4);
	
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
};

function EnergyRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>ELF Gun - Fires streams of electricity that damages shielding.", 4);
	
}

//------------------------------------------------------------------------------

//----------------------------------------------------------------------------
ItemImageData ReincarnationImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	//mountRotation = { 0, 0 ,0 };
	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	projectileType = ReincarnationBolt;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0;
	minEnergy = 40;
	maxEnergy = 60;


	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Reincarnation
{
	description = "Respawn Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "mortar";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = ReincarnationImage;
	price = 275;
	showWeaponBar = true;
};

function Reincarnation::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Respawn Spell - Instantly respawns any target to the team with least players - DO NOT USE ON TEAMMATES!", 4);
}

//----------------------------------------------------------------------------
ItemImageData EmpSpellImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	//mountRotation = { 0, 0 ,0 };
	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	projectileType = EmpRocket;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;
	minEnergy = 10;
	maxEnergy = 40;


	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0, 1, 1 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData EmpSpell
{
	description = "Electron Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "mortar";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = EmpSpellImage;
	price = 280;
	showWeaponBar = true;
};

function EmpSpell::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Electron Spell - Discharges victims energy.", 4);
}

//----------------------------------------------------------------------------
ItemImageData HealSpellImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	//mountRotation = { 0, 0 ,0 };
	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	projectileType = HealRocket;
	accuFire = true;
	reloadTime = 5;
	fireTime = 0;
	minEnergy = 70;
	maxEnergy = 70;


	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	//sfxReload = SoundDryFire;
};

ItemData HealSpell
{
	description = "Heal Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "mortar";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = HealSpellImage;
	price = 280;
	showWeaponBar = true;
};

function HealSpell::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Heal Spell - Heals any person who it is cast upon.", 4);
}

//---------------------------------------
ItemImageData UndeadSpellImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	//mountRotation = { 0, 0 ,0 };
	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	//projectileType = EvilRocket;
	accuFire = true;
	reloadTime = 4;
	fireTime = 4;
	minEnergy = 60;
	maxEnergy = 60;


	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 3;
	lightColor = { 0, 1, 0 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData UndeadSpell
{
	description = "Undead Curse";
	className = "Tool";
	shapeFile = "chainspk";
	//hudIcon = "mortar";
   heading = "lLitch Power";
	shadowDetailMask = 4;
	imageType = UndeadSpellImage;
	price = 0;
	showWeaponBar = false;
};

function UndeadSpell::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Undead Curse - An infernal spell that transforms its victim into a walking corpse and enemy to the living.", 6);
}

function UndeadSpellImage::onFire(%player, %slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("EvilRocket",%trans,%player,%vel);
	Player::decItemCount(%player,UndeadSpell,1);
}
//---------------------------------------
ItemData StasisAmmo
{
	description = "Stasis Ammo";
   	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData StasisImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	//mountRotation = { 0, 0 ,0 };
	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	projectileType = StasisBolt;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 30;


	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData Stasis
{
	description = "Stasis Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "plasma";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = StasisImage;
	price = 155;
	showWeaponBar = true;
};

function Stasis::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Stasis Spell - Used to subdue your opponent.", 4);
}

//------------------------------------------------------------------

ItemImageData InfernoImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	projectileType = InfernoBolt;
	accuFire = true;
	reloadTime = 0.7;
	fireTime = 0.1;
	minEnergy = 3;
	maxEnergy = 3;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 3;
	lightColor = { 1, 0, 0 };

	sfxFire = bigExplosion2;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Inferno
{
	description = "Inferno Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "blaster";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = InfernoImage;
	price = 230;
	showWeaponBar = true;
};

function Inferno::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Inferno Spell - Searing magical plasma with greater effect radius.", 4);
}

//------------------------------------------------------------------

ItemImageData TurnImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	//projectileType = "";
	//accuFire = true;
	reloadTime = 4;
	fireTime = 4;
	minEnergy = 75;
	maxEnergy = 75;

	lightType = 3;  // Weapon Fire
	lightRadius = 15;
	lightTime = 3;
	lightColor = { 1, 0, 1 };

	sfxFire = bigExplosion2;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Turn
{
	description = "Turn Undead Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "blaster";
   	heading = "cSpells";
	shadowDetailMask = 4;
	imageType = TurnImage;
	price = 230;
	showWeaponBar = true;
};

function Turn::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Turn Undead Spell - Damages or Slays any Undead near the caster.", 4);
}

function TurnImage::onFire(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player);
	%addvec = "0 0 1";
	%pos = Vector::add(GameBase::getPosition(%player),%addvec);
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$SimPlayerObjectType,%pos,30,30,0,0);
	if(%num > 0)
	{
	//messageall(0,"Found a player");
		for(%count = 0; %index != -1; %count++)
		{
			%index = Group::getObject(%set, %count);
			%cl = GameBase::getOwnerClient(%index);
			if(%cl.Undead || %cl.Litch)
			{
			//messageall(0,"Player "@%index@ " is Undead or Litch.");
			Player::setDamageFlash(%cl,1);
			GameBase::setDamageLevel(%index,GameBase::getDamageLevel(%index) + 0.33);
			GameBase::setDamageLevel(%index,GameBase::getDamageLevel(%index) + 0.33);
			GameBase::setDamageLevel(%index,GameBase::getDamageLevel(%index) + 0.33);
				if(Player::isDead(%index))
				{
				playNextAnim(%index);
				//messageall(0,"Client.Is Killed called");
				Player::blowUp(%index);
				Client::onKilled(%cl, %client, $TurnDamageType);
				}
			}
		}
	}
	deleteObject(%set);
}
//-------------------------------------------------------------------

ItemImageData ShockwaveGunImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	projectileType = ShockwaveGunBolt;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 20;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 3;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundActivateMotionSensor;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ShockwaveGun
{
	description = "Shockwave Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "sniper";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = ShockwaveGunImage;
	price = 230;
	showWeaponBar = true;
};

function ShockwaveGun::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Shockwave Spell - Creates a blast wave to topple the enemy.", 4);
}

//-------------------------------------------------------------------

ItemImageData LifeImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 2; // Sustained
	projectileType = LifeBolt;
	minEnergy = 0;
	maxEnergy = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 1, 1, 1 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData Life
{
	description = "Ritual of Life";
	className = "Tool";
	shapeFile = "enbolt";
	hudIcon = "repairpack";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = LifeImage;
	price = 600;
	showWeaponBar = true;
};

function Life::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Ritual of Life - When used upon the Altar of Life, it will purge all Undead and Litch from the lands.", 4);
}

//-------------------------------------------------------------------

ItemImageData SummonImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	//projectileType = SummonBolt;
	accuFire = true;
	reloadTime = 4.0;
	fireTime = 4.0;
	minEnergy = 75;
	maxEnergy = 75;

	lightType = 3;  // Weapon Fire
	lightRadius = 10;
	lightTime = 3;
	lightColor = { 1, 1, 0 };

	//sfxFire = SoundActivateMotionSensor;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Summon
{
	description = "Resurrection Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "sniper";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = SummonImage;
	price = 230;
	showWeaponBar = true;
};

function Summon::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Resurrection Spell - Summons forth the body and soul of a past Warrior.", 4);
}

function SummonImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,3)) 
			{
			if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
				if(Summon::checkDeployArea(%client,$los::position)) 
					{
						%team = GameBase::getTeam(%player);
						%bot = Summon::SpawnBot(%player, %team);
						if(%bot != -1)
						{
						%rot = GameBase::getRotation(%player);
						%xrot = getword(%rot, 0);
						%yrot = getword(%rot, 1);
						%zrot = getword(%rot, 2);
						%zrot += 3.14;
						%rot = %xrot@" "@%yrot@" "@%zrot;
						%trans = GameBase::getMuzzleTransform(%player);
						%vel = Item::getVelocity(%player);
						Projectile::spawnProjectile("SummonBolt",%trans,%player,%vel);
						GameBase::setPosition(%bot,$los::position);
						GameBase::setRotation(%bot,%rot);
						GameBase::startFadeIn(%bot);
						Client::sendMessage(%client,0,"Warrior successfuly summoned!");
						playSound(ForceFieldClose,$los::position);
						echo("MSG: ",%client," summoned a Bot.");
						return true;
						}
					}
					}
				else {
					Client::sendMessage(%client,0,"Must summon on flat ground.");
					}
			}
			else {
			Client::sendMessage(%client,0,"Must summon in close proximity to yourself.");
				}
	return false;
	
}

function Summon::checkDeployArea(%client,%pos)
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
			Client::sendMessage(%client,0,"Unable to summon - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to summon - Player in the way");
	}
	else
		Client::sendMessage(%client,0,"Unable to summon - Item in the way");

	deleteObject(%set);
	return 0;	
		

}

//------------------------------------------

//-------------------------------------------------------------------

ItemImageData ShieldSpellImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	projectileType = ShieldRocket;
	accuFire = true;
	reloadTime = 0.3;
	fireTime = 1.0;
	minEnergy = 10;
	maxEnergy = 20;

	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 3;
	lightColor = { 0, 0.5, 1 };

	sfxFire = SoundActivateMotionSensor;
	sfxActivate = SoundPickUpWeapon;
};

ItemData ShieldSpell
{
	description = "Shield Spell";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "shieldpack";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = ShieldSpellImage;
	price = 300;
	showWeaponBar = true;
};

function ShieldSpell::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Shield Spell - Protects friends with a shield for several moments.", 4);
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

//-------------------------

ItemImageData CrafterGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = CrafterBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData CrafterGun
{
	description = "Crafter Repair Beam";
	shapeFile = "repairgun";
	className = "Tool";
	hudIcon = "repairpack";
      heading = "bWeapons";

hudIcon = "repairpack";
	showWeaponBar = true;
	

	shadowDetailMask = 4;
	imageType = CrafterGunImage;
	showInventory = true;
	price = 130;
};

function CrafterGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Crafter Repair Beam - Longer range and better repair tool to aid the Crafter.", 4);
	
}
//-----------------------------------------

ItemImageData FingersImage
{
	shapeFile = "chainspk";
   mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
   weaponType = 2;  // Sustained
	projectileType = FingersCharge;
   minEnergy = 3;
   maxEnergy = 7;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 3;
   lightTime = 1;
   lightColor = { 1, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Fingers
{
   description = "Flaming Fingers Spell";
	shapeFile = "enbolt";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "cSpells";
   shadowDetailMask = 4;
   imageType = FingersImage;
	showWeaponBar = true;
   price = 200;
};

function Fingers::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Flaming Fingers - Burning energy cast forth from the mages hands!.", 4);
	
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

ItemImageData DepSmFFPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	//mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData DepSmFFPack
{
	description = "Small Force Field";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = DepSmFFPackImage;
	mass = 1.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};

function DepSmFFPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DepSmFFPack::onDeploy(%player,%item,%pos)
{
	if (DepSmFFPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DepSmFFPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%rot = GameBase::getRotation(%player);
			%zRot = getWord(%rot, 2);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{			
					%rot = "0 0 " @ %zRot;	
				}
				else if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
				{
					%rot = "3.14159 0 " @ %zRot;	
				}
					else
					%rot = Vector::getRotation($los::normal);
					//%rot = GameBase::getRotation(%player); 
						if(SmFFPackDeployArea(%client,$los::position))
						{ 
						%inv = newObject("forcefield_5x5","StaticShape","ForceField5x5",true);
			         	   addToSet("MissionCleanup", %inv);
						//%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						GameBase::startFadeIn(%inv);
						Client::sendMessage(%client,0,"Force Field deployed");
						playSound(SoundEnergyPackOn,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DepSmFFPack"]++;
						echo("MSG: ",%client," deployed small force field");
						return true;
						}
				}
				//else 
					//Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			//}
			//else 
				//Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function SmFFPackDeployArea(%client,%pos)
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

//--------------------------------------------

ItemImageData DepFFDoorPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	//mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1;
	firstPerson = false;
};


ItemData DepFFDoorPack
{         

	description = "Force Field Door";
	shapeFile = "AmmoPack";
        className = "Backpack";
         heading = "eDeployables";
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
						Client::sendMessage(%client,0,"Force Field Door deployed");
						playSound(SoundEnergyPackOn,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DepFFDoorPack"]++;
						echo("MSG: ",%client," deployed force field door");
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
//--------------------------------------------

ItemImageData DepLgFFPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	//mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData DepLgFFPack
{
	description = "Large Force Field";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = DepSmFFPackImage;
	mass = 1.0;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};

function DepLgFFPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DepLgFFPack::onDeploy(%player,%item,%pos)
{
	if (DepLgFFPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DepLgFFPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(LgFFPackDeployArea(%client,$los::position)) {
						%inv = newObject("forcefield",StaticShape,"LgForceField",true);
	         	   addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						GameBase::startFadeIn(%inv);
						Client::sendMessage(%client,0,"Large Force Field deployed");
						playSound(SoundEnergyPackOn,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DepLgFFPack"]++;
						echo("MSG: ",%client," deployed large force field");
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

function LgFFPackDeployArea(%client,%pos)
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
	maxEnergy = 7.3;   // Energy/sec for sustained weapons
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

//-------------------------------------------

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
   heading = "hSensors";
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
//---------------------------------------------------------
ItemImageData BugPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData BugPack
{
	description = "Coyote-Ear Bug";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "hSensors";
	imageType = BugPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BugPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BugPack::onDeploy(%player,%item,%pos)
{
	if (BugPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "BugPack"]++;
	}
}

//	if (Item::deployShape(%player,"Coyote-Ear Bug",MotionSensor,%item)) {
function BugPack::deployShape(%player,%item)
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
					%mSensor = newObject("","Sensor",DeployableBug,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Coyote-Ear Bug");
					Client::sendMessage(%client,0,"Coyote-Ear Bug deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Coyote-Ear Bug");
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
//----------------------------------------------------------
ItemImageData ComJamPackImage
{
	shapeFile = "sensor_jammer";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData ComJamPack
{
	description = "Commo Jammer";
	shapeFile = "sensor_jammer";
	className = "Backpack";
   heading = "hSensors";
	imageType = ComJamPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 425;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ComJamPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ComJamPack::onDeploy(%player,%item,%pos)
{
	if (ComJamPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "ComJamPack"]++;
	}
}

//	if (Item::deployShape(%player,"Coyote-Ear Bug",MotionSensor,%item)) {
function ComJamPack::deployShape(%player,%item)
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
					%mSensor = newObject("","Sensor",DeployableComJam,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Commo Jammer");
					Client::sendMessage(%client,0,"Commo Jammer deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Commo Jammer Bug");
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
		for(%i = 0; %i < 15 ; %i = %i +1) {
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
	 	    	%item.ScattergunAmmo = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else if(%i == 6){
			%item.DaHammerAmmo = %numPack;
			}
			else if(%i == 7){
			%item.StormLauncherAmmo = %numPack;
			}
			else if(%i == 8){
			%item.PredatorAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.ShredderAmmo = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.StubberAmmo = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.ViperAmmo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.SlingshotAmmo = %numPack;
			}
			else {
	 	    	%item.HvyPlasmaAmmo = %numPack;
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
	for(%i = 0; %i < 15 ; %i = %i +1) {
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
	    	%numAdd = %item.ScattergunAmmo;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else if(%i == 6){
		%numAdd = %item.DaHammerAmmo;
		}
		else if(%i == 7){
		%numAdd = %item.StormLauncherAmmo;
		}
		else if(%i == 8) {
	    	%numAdd = %item.PredatorAmmo;
		}
		else if(%i == 9) {
	    	%numAdd = %item.ShredderAmmo;
		}
		else if(%i == 10) {
	    	%numAdd = %item.StubberAmmo;
		}
		else if(%i == 11) {
	    	%numAdd = %item.ViperAmmo;
		}
		else if(%i == 12) {
	    	%numAdd = %item.SlingshotAmmo;
		}
		else {
			%numAdd = %item.HvyPlasmaAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 15 ; %i = %i +1) {
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
   heading = "hSensors";
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
	if (PulseSensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}

function PulseSensorPack::deployShape(%player,%item)
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
					%sensor = newObject("","Sensor",DeployablePulseSensor,true);
	   	      addToSet("MissionCleanup", %sensor);
					GameBase::setTeam(%sensor,GameBase::getTeam(%player));
					GameBase::setRotation(%sensor,%rot);
					GameBase::setPosition(%sensor,$los::position);
					Gamebase::setMapName(%sensor,"Pulse Sensor#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Pulse Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					//$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Pulse Sensor");
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

ItemImageData SatComPackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData SatComPack
{
	description = "SatCom Unit";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "eDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SatComPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SatComPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"SatCom Unit",DeployableSatCom,%item)) 
	{
		Player::decItemCount(%player,%item);
		%team = GameBase::getTeam(%player);
		GameBase::setTeam(%item,%team);
		$TeamItemCount[GameBase::getTeam(%player) @ "SatComPack"]++;
	}	

	
}
//----------------------------------------------------------------------------

ItemImageData LifeAltarImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LifeAltar
{
	description = "Altar of Life";
	shapeFile = "ammopack";
	className = "Backpack";
   heading = "eDeployables";
	imageType = LifeAltarImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LifeAltar::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LifeAltar::onDeploy(%player,%item,%pos)
{
	if (LifeAltar::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
		%team = GameBase::getTeam(%player);
		GameBase::setTeam(%item,%team);
		$TeamItemCount[GameBase::getTeam(%player) @ "LifeAltar"]++;
	}	
}

function LifeAltar::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,5,5,5,0);
				deleteObject(%set);
				if(0 == %num) {
		  			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						if(checkDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%altar = newObject("LifeAltar","StaticShape","LifeAlt",true);
				                     addToSet("MissionCleanup", %altar);
								GameBase::setTeam(%altar,GameBase::getTeam(%player));
								GameBase::setPosition(%altar,$los::position);
								GameBase::setRotation(%altar,%rot);
								Client::sendMessage(%client,0,"Altar of Life erected");
								echo("MSG: ",%client," deployed Altar of Life");
								GameBase::setDamageLevel(%altar, 25.0);
								for(%cl = Client::getFirst();%cl != -1;%cl = Client::getNext(%cl))
								{
								if(%cl.Undead || %cl.Litch)
								Client::SendMessage(%cl,2,"An Altar of Life has been erected!");
								}

								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					//} 
					//else
					//	Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from man-made objects.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain.");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//----------------------------------------------------------------------------

ItemImageData BrimstoneImage
{
	shapeFile = "chainspk";
	mountPoint = 0;
	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Single Shot
	//projectileType = ReincarnationBolt;
	accuFire = true;
	reloadTime = 2.5;
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
	description = "Brimstone Spell";
	className = "Weapon";
	shapeFile = "enbolt";
      heading = "cSpells";
	shadowDetailMask = 4;
	imageType = BrimstoneImage;
};

function Brimstone::onUse(%player, %item)
{
		Weapon::onUse(%player, %item);
		bottomprint(Player::getClient(%player), "<jc><f2>Brimstone Ritual - Summons firey rain upon a large area.", 4);
}

function BrimstoneImage::onFire(%player, %slot)
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
Client::SendMessage(Player::getClient(%player),0,"Out of range for Brimstone Rite.");
	
}

function Brimstone::Bombs(%player, %count, %Xpos, %Ypos, %Zpos)
{
if(%count < 70)
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
	Player::setItemCount(%player, Brimstone, 0);
	schedule("Brimstone::Bombs("@%player@","@%count@","@%Xpos@","@%Ypos@","@%Zpos@");",0.1);
}
}

//-------------------------------------------

ItemImageData BrimstoneAltarImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData BrimstoneAltar
{
	description = "Altar of Brimstone";
	shapeFile = "ammopack";
	className = "Backpack";
   heading = "eDeployables";
	imageType = BrimstoneAltarImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BrimstoneAltar::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BrimstoneAltar::onDeploy(%player,%item,%pos)
{
	if (BrimstoneAltar::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
		%team = GameBase::getTeam(%player);
		GameBase::setTeam(%item,%team);
		$TeamItemCount[GameBase::getTeam(%player) @ "BrimstoneAltar"]++;
	}	
}

function BrimstoneAltar::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,5,5,5,0);
				deleteObject(%set);
				if(0 == %num) {
		  			if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						if(checkDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%altar = newObject("BrimstoneAltar","StaticShape","BrimAlt",true);
				                     addToSet("MissionCleanup", %altar);
								GameBase::setTeam(%altar,GameBase::getTeam(%player));
								GameBase::setPosition(%altar,$los::position);
								GameBase::setRotation(%altar,%rot);
								Client::sendMessage(%client,0,"Altar of Brimstone erected");
								echo("MSG: ",%client," deployed Altar of Brimstone");
								GameBase::setDamageLevel(%altar, 25.0);
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					//} 
					//else
					//	Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from man-made objects.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain.");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}
//-------------------------------------------------------------------

ItemImageData BrimImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 2; // Sustained
	projectileType = BrimBolt;
	minEnergy = 0;
	maxEnergy = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData Brim
{
	description = "Ritual of Brimstone";
	className = "Tool";
	shapeFile = "enbolt";
	hudIcon = "repairpack";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = BrimImage;
	price = 600;
	showWeaponBar = true;
};

function Brim::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Ritual of Brimstone - When used upon the Altar of Brimstone, it will give all Mages the ability to cast fire from the sky.", 4);
}

//--------------------------------------

ItemImageData GiveHolyImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Singleshot
	projectileType = blessBolt;
	minEnergy = 50;
	maxEnergy = 50;

	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 1 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundWindGust;
};

ItemData GiveHoly
{
	description = "Bless";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "repairpack";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = GiveHolyImage;
	price = 650;
	showWeaponBar = true;
};

function GiveHoly::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Bless - Equips the receipiant with a Holy Weapon.", 4);
}

//-------------------------------------------------------------------

ItemImageData HolyWeaponImage
{
	shapeFile = "chainspk";
	mountPoint = 0;

	mountOffset = { -0.4, -0.4, 0 };
	weaponType = 0; // Singleshot
	//projectileType = holyCharge;
	minEnergy = 0;
	maxEnergy = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 1 };

	sfxActivate = SoundPickUpWeapon;
	//sfxFire = SoundRepairItem;
};

ItemData HolyWeapon
{
	description = "Holy Bolt";
	className = "Tool";
	shapeFile = "enbolt";
	hudIcon = "repairpack";
   heading = "cSpells";
	shadowDetailMask = 4;
	imageType = HolyWeaponImage;
	price = 600;
	showWeaponBar = true;
};

function HolyWeapon::onUse(%player,%item)
{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Holy Bolt - Summons Divine Lightning to strike your enemy.", 4);
}
//hhuhiu  5172
function HolyWeaponImage::onFire(%player, %slot)
{
	%cl = Player::getClient(%player);
	if(GameBase::getLOSInfo(%player,250))
	{
	%object = $los::object;
	%type = getObjectType(%object);
		if(%type == "Player")
		{
		%playteam = Client::getTeam(%cl);
		%obteam = GameBase::getTeam(%object);
			if(%playteam != %obteam)
			{
			%pos = GameBase::GetPosition(%object);
			playsound(bigExplosion1,%pos);
			playsound(bigExplosion1,GameBase::getPosition(%player));
			playsound(SoundWindGust,GameBase::getPosition(%player));
			playsound(SoundWindGust,%pos);
			%Xpos = getword(%pos, 0);
			%Ypos = getword(%pos, 1);
			%Zpos = getword(%pos, 2);
			%Zpos += 200;
			%Xpos += 3;
			%pos = %Xpos@" "@%Ypos@" "@%Zpos;
			%rot = "3.1415 0 0";
			%new = newObject("HolyBolt",Turret,"HolyBolt");
			addToSet("MissionCleanup", %new);
			GameBase::setTeam(%new, %playteam);
			GameBase::setPosition(%new, %pos);
			GameBase::setRotation(%new,%rot);
			schedule("deleteObject("@%new@");",2);
			Player::setItemCount(%player,HolyWeapon,0);
			}
			else
			Client::SendMessage(%cl,0,"Cannot cast on Teammates.");
		}
		else
		Client::SendMessage(%cl,0,"Can only cast on players.");
	}
	else
	Client::SendMessage(%cl,0,"Out of range.");
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
   heading = "hSensors";
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
	if (DeployableSensorJammerPack::deployShape(%player,%item))
	 {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}

function DeployableSensorJammerPack::deployShape(%player,%item)
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
					%sensor = newObject("","Sensor",DeployableSensorJammer,true);
	   	      addToSet("MissionCleanup", %sensor);
					GameBase::setTeam(%sensor,GameBase::getTeam(%player));
					GameBase::setRotation(%sensor,%rot);
					GameBase::setPosition(%sensor,$los::position);
					Gamebase::setMapName(%sensor,"Sensor Jammer#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Sensor Jammer deployed");
					playSound(SoundPickupBackpack,$los::position);
					//$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Sensor Jammer");
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
   heading = "hSensors";
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
	mass = 1.0;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "fTurrets";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
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
				%rot = GameBase::getRotation(%player);
				%zRot = getWord(%rot, 2);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else
						%rot = Vector::getRotation($los::normal);
					
				
				if(checkDeployArea(%client,$los::position)){
								//%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundTurretDeploy,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						//else 
							//Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					//} 
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
ItemImageData DepRocketPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData DepRocketPack
{
	description = "Rocket Turret";
	shapeFile = "missileturret";
	className = "Backpack";
   heading = "fTurrets";
	imageType = DepRocketPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};

function DepRocketPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DepRocketPack::onDeploy(%player,%item,%pos)
{
	if (DepRocketPack::deployShape(%player,%item)) {
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

function DepRocketPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableRocTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableRocTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
									if(checkDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableRocTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Rocket Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Rocket Turret deployed");
								playSound(SoundMortarTurretOn,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "DepRocketPack"]++;
								echo("MSG: ",%client," deployed a Rocket Turret");
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


//----------------------------------------------------------------------------
																			
ItemImageData StutPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData StutPack
{
	description = "Stutter Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "fTurrets";
	imageType = StutPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StutPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function StutPack::onDeploy(%player,%item,%pos)
{
	if (StutPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}
	
function StutPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DepStutterTurret",%num);
				deleteObject(%set);
				%rot = GameBase::getRotation(%player);
				%zRot = getWord(%rot, 2);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DepStutterTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else
						%rot = Vector::getRotation($los::normal);
					
				
				if(checkDeployArea(%client,$los::position)){
								//%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DepStutterTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Stutter Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Stutter Turret deployed");
								playSound(SoundTurretDeploy,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "StutPack"]++;
								echo("MSG: ",%client," deployed a Stutter Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						//else 
							//Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					//} 
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


//----------------------------------------------------------------------------
ItemImageData AhnPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData AhnPack
{
	description = "Annihilator Turret";
	shapeFile = "mortar_turret";
	className = "Backpack";
   heading = "fTurrets";
	imageType = AhnPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};

function AhnPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AhnPack::onDeploy(%player,%item,%pos)
{
	if (AhnPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AhnPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DaHammerTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DaHammerTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
									if(checkDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DaHammerTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Annihilator Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Annihilator Turret deployed");
								playSound(SoundMortarTurretOn,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "AhnPack"]++;
								echo("MSG: ",%client," deployed a Rocket Turret");
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

//----------------------------------------------------------------------------
ItemImageData PlasPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData PlasPack
{
	description = "Plasma Turret";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "fTurrets";
	imageType = PlasPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};

function PlasPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlasPack::onDeploy(%player,%item,%pos)
{
	if (PlasPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlasPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DepPlasmaTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DepPlasmaTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
									if(checkDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DepPlasmaTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Plasma Turret deployed");
								playSound(SoundMortarTurretOn,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "PlasPack"]++;
								echo("MSG: ",%client," deployed a Plasma Turret");
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


//----------------------------------------------------------------------------
ItemImageData VulcPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData VulcPack
{
	description = "Vulcan Turret";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "fTurrets";
	imageType = VulcPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};

function VulcPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function VulcPack::onDeploy(%player,%item,%pos)
{
	if (VulcPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function VulcPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableVulcTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableVulcTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
									if(checkDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableVulcTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Vulcan Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Vulcan Turret deployed");
								playSound(SoundMortarTurretOn,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "VulcPack"]++;
								echo("MSG: ",%client," deployed a Vulcan Turret");
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


//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

ItemImageData ShockwvPackImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData ShockwvPack
{
	description = "Shockwave Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
   heading = "fTurrets";
	imageType = ShockwvPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar =false;
	hiliteOnActive = false;
};

function ShockwvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ShockwvPack::onDeploy(%player,%item,%pos)
{
	if (ShockwvPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ShockwvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableShockwv",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableShockwv",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else
						%rot = Vector::getRotation($los::normal);
					
				
				if(checkDeployArea(%client,$los::position)){
								//%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableShockwv,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Shockwave Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ShockwvPack"]++;
								echo("MSG: ",%client," deployed a Shockwave Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						//else 
							//Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					//} 
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

//----------------------------------------------------------------------------

ItemImageData LaserPackImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData LaserPack
{
	description = "Laser Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
   heading = "fTurrets";
	imageType = LaserPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 245;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
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
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSLaser",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSLaser",%num);
					deleteObject(%set);
					%rot = GameBase::getRotation(%player);
					%zRot = getWord(%rot, 2);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				}
				else if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					}
					else
						%rot = Vector::getRotation($los::normal);
					
				
				if(checkDeployArea(%client,$los::position)){
								//%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableSLaser,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Laser Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Laser Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "LaserPack"]++;
								echo("MSG: ",%client," deployed a Laser Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						//else 
							//Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					//} 
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

//----------------------------------------------------------------------------
ItemImageData BunkerPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData BunkerPack
{
	description = "Deployable Bunker";
	shapeFile = "ammopack";
	className = "Backpack";
   heading = "eDeployables";
	imageType = BunkerPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};
function BunkerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BunkerPack::onDeploy(%player,%item,%pos)
{
	if (BunkerPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}


function BunkerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
				%num = CountObjects(%set,"eround1",%num);
				deleteObject(%set);
				if(20 > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$SimInteriorObjectType,$los::position,20,20,20,0);
					%num = CountObjects(%set,"eround1",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
									if(BnkrDeployArea(%client,$los::position)){
								%rot = GameBase::getRotation(%player); 
								%vctr = "0 0 3.3";
								%rot = Vector::add(%rot,%vctr);
								%bunker = newObject("eround1",InteriorShape,"eround.dis",false);
				                     addToSet("MissionCleanup", %bunker);
								GameBase::setTeam(%bunker,GameBase::getTeam(%player));
								GameBase::setPosition(%bunker,$los::position);
								GameBase::setRotation(%bunker,%rot);
								Client::sendMessage(%client,0,"Bunker Deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "BunkerPack"]++;
								echo("MSG: ",%client," deployed a bunker.");
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
						Client::sendMessage(%client,0,"Too close to other objects.");
				}
			   else 
					Client::sendMessage(%client,0,"Too close to other objects.");
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

function BnkrDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.5,0.5,0.5,0.5);
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
ItemImageData WallPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData WallPack
{
	description = "Barricade";
	shapeFile = "elevator6x6thin";
	className = "Backpack";
   heading = "eDeployables";
	imageType = WallPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	price = 480;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = false;
};

function WallPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function WallPack::onDeploy(%player,%item,%pos)
{
	if (WallPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function WallPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(WallPackDeployArea(%client,$los::position)) {
						%inv = newObject("DeployableWall",StaticShape,"DepWall",true);
	         	   addToSet("MissionCleanup", %inv);
						%Rvectr = "1.55 0 0";
						%Pvectr = "0 0 3";
						%LOSVectr = $los::position;
						%NEWVectr = Vector::add(%LOSVectr,%Pvectr);
						%rot = Vector::add(GameBase::getRotation(%player),%Rvectr); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,%NEWVectr);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Barricade deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "WallPack"]++;
						echo("MSG: ",%client," deployed barricade");
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

function WallPackDeployArea(%client,%pos)
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

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "iMiscellany";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


//----------------------------------------------------------------------------

ItemData NoUndead
{
   description = "Life Shield";
   shapeFile = "enbolt";
   heading = "jPaladin Power";
   shadowDetailMask = 4;
   price = 0;
};

function NoUndead::onUse(%player,%item)
{
	%cl = Player::getClient(%player);
	%name = Client::getName(%cl);
	Player::decItemCount(%player, %item);
	$UsedShield = true;
	for(%cl = Client::getFirst();%cl != -1;%cl = Client::getNext(%cl))
	{
		if(%cl.Litch)
		{
		%cl.Litch = false;
		Player::SetItemCount(%cl,UndeadSpell,0);
		Client::SendMessage(%cl,0,"Paladin "@%name@" has temporarily nullified your ability to create Undead!");
		schedule(%cl@".Litch = true;",600);  //600 is ten minutes
		schedule("Player::setItemCount("@%cl@",UndeadSpell,3);",600);  //600 is Ten Minutes
		}
	}
		
}
//----------------------------------------------------------------------------

ItemData PaladinHeal
{
   description = "Hands of Healing";
   shapeFile = "enbolt";
   heading = "jPaladin Power";
   shadowDetailMask = 4;
   price = 0;
};

function PaladinHeal::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	%pl = Player::getClient(%player);
	%name = Client::getName(%pl);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == Client::getTeam(%pl))
		{
            Client::sendMessage(%cl,0,"Paladin "@ %name @" has healed you!~wforceopen.wav");
		HealPlayer(%cl);
		}
	
}

function HealPlayer(%client)
{
%pl = Client::getOwnedObject(%client);
//messageall(0,"Paladin function passed okay");
GameBase::repairDamage(%pl,0.4);
}

//----------------------------------------------------------------------------

ItemData WarlordShield
{
   description = "Blessing of War";
   shapeFile = "enbolt";
   heading = "kWarlord Power";
   shadowDetailMask = 4;
   price = 0;
};

function WarlordShield::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	%pl = Player::getClient(%player);
	%name = Client::getName(%pl);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == Client::getTeam(%pl))
		{
            Client::sendMessage(%cl,0,"Warlord "@ %name @" has shielded you!~wteleport2.wav");
		ShieldPlayer(%cl);
		}
	
}

function ShieldPlayer(%cl)
{
%pl = Client::getOwnedObject(%cl);
%pl.shieldStrength = 0.012;
schedule("ShieldStop("@%pl@","@%cl@");",30,%pl);
}

function ShieldStop(%pl,%cl)
{
	%pl.shieldStrength = 0;
	Client::sendMessage(%cl,0,"You are no longer shielded.");
}
//-----------------------------------
ItemData WarlordCharge
{
   description = "Power Boost";
   shapeFile = "enbolt";
   heading = "kWarlord Power";
   shadowDetailMask = 4;
   price = 0;
};

function WarlordCharge::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	%pl = Player::getClient(%player);
	%name = Client::getName(%pl);
	$UsedCharge = true;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
         if(Client::getTeam(%cl) == Client::getTeam(%pl))
		{
            Client::sendMessage(%cl,0,"Warlord "@ %name @" has charged you!~wteleport2.wav");
		ChargePlayer(%cl);
		}
	
}

function ChargePlayer(%cl)
{
%pl = Client::getOwnedObject(%cl);
%cl.charged = true;
schedule("ChargeStop("@%pl@","@%cl@");",30,%cl);
}

function ChargeStop(%pl,%cl)
{
	%cl.charged = false;
	Client::sendMessage(%cl,0,"You are no longer charged.");
}

//-------------------------------------------------------
ItemData WarlordRite
{
   description = "Warlords Ritual";
   shapeFile = "enbolt";
   heading = "kWarlord Power";
   shadowDetailMask = 4;
   price = 0;
};

function WarlordRite::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	%pl = Player::getClient(%player);
	%name = Client::getName(%pl);
	$WarlordRite = true;
	if(!$PaladinRite && !$RiteTimeExpire)
		for(%cl = Client::getFirst();%cl != -1;%cl = Client::getNext(%cl))
		{
			%name = Client::GetName(%cl);
			if(%name == $Chivalry::Paladin)
			{
			Client::sendMessage(%cl,1,"Warlord "@$Chivalry::Warlord@" has initiated the Ritual of Equality!  You have 3 minutes to complete the Paladin Rite!~wteleport2.wav");
			Client::sendMessage(%pl,1,"You have begun the Ritual of Equality!  Paladin "@$Chivalry::Paladin@" has 3 minutes to complete the Rite!~wteleport2.wav");
			schedule("RiteExpire("@%pl@","@%cl@");",180);
			}
		}
	else if($RiteTimeExpire)
		Client::sendMessage(%pl,1,"Paladin "@$Chivalry::Paladin@" has already initiated the Ritual of Equality and the time has already expired!~wC_BuySell.wav");
	else if($PaladinRite && !$RiteTimeExpire)
		EqualityRite(%pl);
	else
	messageall(0,"Ritual Exception Error!");
	
}
//-------------------------------------------------------
ItemData PaladinRite
{
   description = "Paladins Ritual";
   shapeFile = "enbolt";
   heading = "jPaladin Power";
   shadowDetailMask = 4;
   price = 0;
};

function PaladinRite::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	%pl = Player::getClient(%player);
	%name = Client::getName(%pl);
	$PaladinRite = true;
	if(!$WarlordRite && !$RiteTimeExpire)
		for(%cl = Client::getFirst();%cl != -1;%cl = Client::getNext(%cl))
		{
			%name = Client::GetName(%cl);
			if(%name == $Chivalry::Warlord)
			{
			Client::sendMessage(%cl,1,"Paladin "@$Chivalry::Paladin@" has initiated the Ritual of Equality!  You have 3 minutes to complete the Warlord Rite!~wteleport2.wav");
			Client::sendMessage(%pl,1,"You have begun the Ritual of Equality!  Warlord "@$Chivalry::Warlord@" has 3 minutes to complete the Rite!~wteleport2.wav");
			schedule("RiteExpire("@%pl@","@%cl@");",180);
			}
		}
	else if($RiteTimeExpire)
		Client::sendMessage(%pl,1,"Warlord "@$Chivalry::Warlord@" has already initiated the Ritual of Equality and the time has already expired!~wC_BuySell.wav");
	else if($WarlordRite && !$RiteTimeExpire)
		EqualityRite(%pl);
	else
	messageall(0,"Ritual Exception Error!");
	
}
//----------------------------------------------------------
function RiteExpire(%first,%last)
{
	if(!$WarlordRite || !$PaladinRite)
	{
	Client::sendMessage(%first,1,"The Ritual was not completed!~wC_BuySell.wav");
	Client::sendMessage(%last,1,"You failed to complete the Ritual of Equality in time!~wC_BuySell.wav");
	$RiteTimeExpire = true;
	}
	else
	$RiteTimeExpire = true;
}
//-----------------------------------------------------------
	
function EqualityRite(%clientId)
{
	messageall(1,"Warlord "@$Chivalry::Warlord@" and Paladin "@$Chivalry::Paladin@" have completed the Ritual of Equality!  Spawn Armor for ten minutes!~wteleport2.wav");
	for(%cl = Client::getFirst();%cl != -1;%cl = Client::getNext(%cl))
	{
		%pl = Client::getOwnedObject(%cl);
		%trans = GameBase::getMuzzleTransform(%pl);
		%vel = Item::getVelocity(%cl);
		Projectile::spawnProjectile("ShockwvShell",%trans,%pl,%vel);
		Player::trigger(%cl, $WeaponSlot, false);
		%weaponType = Player::getMountedItem(%cl,$WeaponSlot);
			if(%weaponType != -1)
			Player::dropItem(%cl,%weaponType);
            Player::blowUp(%cl);
		Player::kill(%cl);
	}
$Station::Equal = true;
schedule("EqualExpire();",600);
}
//----------------------------------------------------------------------------
function EqualExpire()
{
	$Station::Equal = false;
	messageall(1,"Ritual of Equality has expired!  Inventory Stations are now accessible!~waccessdenied.wav");
}

//------------------------------------------------------------------------------
ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "gMines";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine"); 			GameBase::setTeam (%obj,GameBase::getTeam (%player));
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//----------------------------------------------------------------------------

ItemData ShockwaveMine
{
   description = "Shockwave Mine";
   shapeFile = "mineammo";
   heading = "gMines";
   shadowDetailMask = 4;
   price = 30;
	className = "HandAmmo";
};

function ShockwaveMine::onUse(%player, %item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","ShkwvMine");
			GameBase::setTeam (%obj,GameBase::getTeam (%player));

		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//----------------------------------------------------------------------------

ItemData EmpMine
{
   description = "Emp Mine";
   shapeFile = "mineammo";
   heading = "gMines";
   shadowDetailMask = 4;
   price = 30;
	className = "HandAmmo";
};

function EmpMine::onUse(%player, %item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","engMine");
			GameBase::setTeam (%obj,GameBase::getTeam (%player));

		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//----------------------------------------------------------------------------
ItemData StasisMine
{
   description = "Stasis Mine";
   shapeFile = "mineammo";
   heading = "gMines";
   shadowDetailMask = 4;
   price = 50;
	className = "HandAmmo";
};

function StasisMine::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","stsMine");
			GameBase::setTeam (%obj,GameBase::getTeam (%player));

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
   heading = "iMiscellany";
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

ItemData SmokeGren
{
   description = "Smoke Grenade";
   shapeFile = "armorPatch";
   heading = "iMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function SmokeGren::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) 
		{
			Player::decItemCount(%player,%item);
			//%client = Player::getClient(%player);
			%vel = Item::getVelocity(%player);
			%trans = GameBase::getMuzzleTransform(%player);
			Projectile::spawnProjectile("SmokeShell",%trans,%player,%vel);
		}

}
}

//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "iMiscellany";
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

ItemData ProxMine
{
   description = "Proximity Mine";
   shapeFile = "sensor_small";
   heading = "gMines";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function ProxMine::onUse(%player,%item)
{
	if (ProxMine::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}
function ProxMine::deployShape(%player,%item)
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
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,1,1,1,0);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%beacon = newObject("", "StaticShape", "ProxyMine");
		GameBase::setTeam(%beacon,%team);

				   addToSet("MissionCleanup", %beacon);
					//, CameraTurret, true);
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Proximity Mine");
   			   //schedule("proxymine::onEnabled("@ %item @");",3,%item);
					Client::sendMessage(%client,0,"Proximity Mine deployed");
					//playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "ProxMine"]++;
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
   heading = "iMiscellany";
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
	//Client::clearItemShopping(%client);
	//Client::clearItemBuying(%client);
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
	$numAI[0] = 0;
	$numAI[1] = 0;
	$numAI[2] = 0;
	$numAI[3] = 0;
	$numAI[4] = 0;
	$numAI[5] = 0;
	$numAI[6] = 0;
	$numAI[7] = 0;

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
	
$TeamItemCount[0 @ Volcano] = 0;
$TeamItemCount[0 @ LaserRifle] = 0;
$TeamItemCount[0 @ Viper] = 0;
$TeamItemCount[0 @ ShockwvPack] = 0;
$TeamItemCount[0 @ BugPack] = 0;
$TeamItemCount[0 @ LaserPack] = 0;
$TeamItemCount[0 @ DepRocketPack] = 0;
$TeamItemCount[0 @ AhnPack] = 0;
$TeamItemCount[0 @ VulcPack] = 0;
$TeamItemCount[0 @ StutPack] = 0;
$TeamItemCount[0 @ PlasPack] = 0;
$TeamItemCount[0 @ DepSmFFPack] = 0;
$TeamItemCount[0 @ StasisMine] = 0;
$TeamItemCount[0 @ ShockwaveMine] = 0;
$TeamItemCount[0 @ DepFFDoorPack] = 0;
$TeamItemCount[0 @ ProxMine] = 0;
$TeamItemCount[0 @ GunshipVehicle] = 0;
$TeamItemCount[0 @ CrawlerVehicle] = 0;
$TeamItemCount[0 @ BunkerPack] = 0;
$TeamItemCount[0 @ DepLgFFPack] = 0;
$TeamItemCount[0 @ WallPack] = 0;
$TeamItemCount[0 @ FalconVehicle] = 0;
$TeamItemCount[0 @ MinelayerVehicle] = 0;
$TeamItemCount[0 @ PhoenixVehicle] = 0;
$TeamItemCount[0 @ BomberVehicle] = 0;
$TeamItemCount[0 @ ComJamPack] = 0;
$TeamItemCount[0 @ SatComPack] = 0;
$TeamItemCount[0 @ EmpMine] = 0;
$TeamItemCount[0 @ MIRV] = 0;
$TeamItemCount[0 @ LifeAltar] = 0;
$TeamItemCount[0 @ BrimstoneAltar] = 0;

$TeamItemCount[1 @ Volcano] = 0;
$TeamItemCount[1 @ LaserRifle] = 0;
$TeamItemCount[1 @ Viper] = 0;
$TeamItemCount[1 @ ShockwvPack] = 0;
$TeamItemCount[1 @ BugPack] = 0;
$TeamItemCount[1 @ LaserPack] = 0;
$TeamItemCount[1 @ DepRocketPack] = 0;
$TeamItemCount[1 @ AhnPack] = 0;
$TeamItemCount[1 @ VulcPack] = 0;
$TeamItemCount[1 @ StutPack] = 0;
$TeamItemCount[1 @ PlasPack] = 0;
$TeamItemCount[1 @ DepSmFFPack] = 0;
$TeamItemCount[1 @ StasisMine] = 0;
$TeamItemCount[1 @ ShockwaveMine] = 0;
$TeamItemCount[1 @ DepFFDoorPack] = 0;
$TeamItemCount[1 @ ProxMine] = 0;
$TeamItemCount[1 @ GunshipVehicle] = 0;
$TeamItemCount[1 @ CrawlerVehicle] = 0;
$TeamItemCount[1 @ BunkerPack] = 0;
$TeamItemCount[1 @ DepLgFFPack] = 0;
$TeamItemCount[1 @ WallPack] = 0;
$TeamItemCount[1 @ FalconVehicle] = 0;
$TeamItemCount[1 @ MinelayerVehicle] = 0;
$TeamItemCount[1 @ PhoenixVehicle] = 0;
$TeamItemCount[1 @ BomberVehicle] = 0;
$TeamItemCount[1 @ ComJamPack] = 0;
$TeamItemCount[1 @ SatComPack] = 0;
$TeamItemCount[1 @ EmpMine] = 0;
$TeamItemCount[1 @ MIRV] = 0;
$TeamItemCount[1 @ LifeAltar] = 0;
$TeamItemCount[1 @ BrimstoneAltar] = 0;

$TeamItemCount[2 @ Volcano] = 0;
$TeamItemCount[2 @ LaserRifle] = 0;
$TeamItemCount[2 @ Viper] = 0;
$TeamItemCount[2 @ ShockwvPack] = 0;
$TeamItemCount[2 @ BugPack] = 0;
$TeamItemCount[2 @ LaserPack] = 0;
$TeamItemCount[2 @ DepRocketPack] = 0;
$TeamItemCount[2 @ AhnPack] = 0;
$TeamItemCount[2 @ VulcPack] = 0;
$TeamItemCount[2 @ StutPack] = 0;
$TeamItemCount[2 @ PlasPack] = 0;
$TeamItemCount[2 @ DepSmFFPack] = 0;
$TeamItemCount[2 @ StasisMine] = 0;
$TeamItemCount[2 @ ShockwaveMine] = 0;
$TeamItemCount[2 @ DepFFDoorPack] = 0;
$TeamItemCount[2 @ ProxMine] = 0;
$TeamItemCount[2 @ GunshipVehicle] = 0;
$TeamItemCount[2 @ CrawlerVehicle] = 0;
$TeamItemCount[2 @ BunkerPack] = 0;
$TeamItemCount[2 @ DepLgFFPack] = 0;
$TeamItemCount[2 @ WallPack] = 0;
$TeamItemCount[2 @ FalconVehicle] = 0;
$TeamItemCount[2 @ MinelayerVehicle] = 0;
$TeamItemCount[2 @ PhoenixVehicle] = 0;
$TeamItemCount[2 @ BomberVehicle] = 0;
$TeamItemCount[2 @ ComJamPack] = 0;
$TeamItemCount[2 @ SatComPack] = 0;
$TeamItemCount[2 @ EmpMine] = 0;
$TeamItemCount[2 @ MIRV] = 0;
$TeamItemCount[2 @ LifeAltar] = 0;
$TeamItemCount[2 @ BrimstoneAltar] = 0;

$TeamItemCount[3 @ Volcano] = 0;
$TeamItemCount[3 @ LaserRifle] = 0;
$TeamItemCount[3 @ Viper] = 0;
$TeamItemCount[3 @ ShockwvPack] = 0;
$TeamItemCount[3 @ BugPack] = 0;
$TeamItemCount[3 @ LaserPack] = 0;
$TeamItemCount[3 @ DepRocketPack] = 0;
$TeamItemCount[3 @ AhnPack] = 0;
$TeamItemCount[3 @ VulcPack] = 0;
$TeamItemCount[3 @ StutPack] = 0;
$TeamItemCount[3 @ PlasPack] = 0;
$TeamItemCount[3 @ DepSmFFPack] = 0;
$TeamItemCount[3 @ StasisMine] = 0;
$TeamItemCount[3 @ ShockwaveMine] = 0;
$TeamItemCount[3 @ DepFFDoorPack] = 0;
$TeamItemCount[3 @ ProxMine] = 0;
$TeamItemCount[3 @ GunshipVehicle] = 0;
$TeamItemCount[3 @ CrawlerVehicle] = 0;
$TeamItemCount[3 @ BunkerPack] = 0;
$TeamItemCount[3 @ DepLgFFPack] = 0;
$TeamItemCount[3 @ WallPack] = 0;
$TeamItemCount[3 @ FalconVehicle] = 0;
$TeamItemCount[3 @ MinelayerVehicle] = 0;
$TeamItemCount[3 @ PhoenixVehicle] = 0;
$TeamItemCount[3 @ BomberVehicle] = 0;
$TeamItemCount[3 @ ComJamPack] = 0;
$TeamItemCount[3 @ SatComPack] = 0;
$TeamItemCount[3 @ EmpMine] = 0;
$TeamItemCount[3 @ MIRV] = 0;
$TeamItemCount[3 @ LifeAltar] = 0;
$TeamItemCount[3 @ BrimstoneAltar] = 0;

$TeamItemCount[4 @ Volcano] = 0;
$TeamItemCount[4 @ LaserRifle] = 0;
$TeamItemCount[4 @ Viper] = 0;
$TeamItemCount[4 @ ShockwvPack] = 0;
$TeamItemCount[4 @ BugPack] = 0;
$TeamItemCount[4 @ LaserPack] = 0;
$TeamItemCount[4 @ DepRocketPack] = 0;
$TeamItemCount[4 @ AhnPack] = 0;
$TeamItemCount[4 @ VulcPack] = 0;
$TeamItemCount[4 @ StutPack] = 0;
$TeamItemCount[4 @ PlasPack] = 0;
$TeamItemCount[4 @ DepSmFFPack] = 0;
$TeamItemCount[4 @ StasisMine] = 0;
$TeamItemCount[4 @ ShockwaveMine] = 0;
$TeamItemCount[4 @ DepFFDoorPack] = 0;
$TeamItemCount[4 @ ProxMine] = 0;
$TeamItemCount[4 @ GunshipVehicle] = 0;
$TeamItemCount[4 @ CrawlerVehicle] = 0;
$TeamItemCount[4 @ BunkerPack] = 0;
$TeamItemCount[4 @ DepLgFFPack] = 0;
$TeamItemCount[4 @ WallPack] = 0;
$TeamItemCount[4 @ FalconVehicle] = 0;
$TeamItemCount[4 @ MinelayerVehicle] = 0;
$TeamItemCount[4 @ PhoenixVehicle] = 0;
$TeamItemCount[4 @ BomberVehicle] = 0;
$TeamItemCount[4 @ ComJamPack] = 0;
$TeamItemCount[4 @ SatComPack] = 0;
$TeamItemCount[4 @ EmpMine] = 0;
$TeamItemCount[4 @ MIRV] = 0;
$TeamItemCount[4 @ LifeAltar] = 0;
$TeamItemCount[4 @ BrimstoneAltar] = 0;

$TeamItemCount[5 @ Volcano] = 0;
$TeamItemCount[5 @ LaserRifle] = 0;
$TeamItemCount[5 @ Viper] = 0;
$TeamItemCount[5 @ ShockwvPack] = 0;
$TeamItemCount[5 @ BugPack] = 0;
$TeamItemCount[5 @ LaserPack] = 0;
$TeamItemCount[5 @ DepRocketPack] = 0;
$TeamItemCount[5 @ AhnPack] = 0;
$TeamItemCount[5 @ VulcPack] = 0;
$TeamItemCount[5 @ StutPack] = 0;
$TeamItemCount[5 @ PlasPack] = 0;
$TeamItemCount[5 @ DepSmFFPack] = 0;
$TeamItemCount[5 @ StasisMine] = 0;
$TeamItemCount[5 @ ShockwaveMine] = 0;
$TeamItemCount[5 @ DepFFDoorPack] = 0;
$TeamItemCount[5 @ ProxMine] = 0;
$TeamItemCount[5 @ GunshipVehicle] = 0;
$TeamItemCount[5 @ CrawlerVehicle] = 0;
$TeamItemCount[5 @ BunkerPack] = 0;
$TeamItemCount[5 @ DepLgFFPack] = 0;
$TeamItemCount[5 @ WallPack] = 0;
$TeamItemCount[5 @ FalconVehicle] = 0;
$TeamItemCount[5 @ MinelayerVehicle] = 0;
$TeamItemCount[5 @ PhoenixVehicle] = 0;
$TeamItemCount[5 @ BomberVehicle] = 0;
$TeamItemCount[5 @ ComJamPack] = 0;
$TeamItemCount[5 @ SatComPack] = 0;
$TeamItemCount[5 @ EmpMine] = 0;
$TeamItemCount[5 @ MIRV] = 0;
$TeamItemCount[5 @ LifeAltar] = 0;
$TeamItemCount[5 @ BrimstoneAltar] = 0;

$TeamItemCount[6 @ Volcano] = 0;
$TeamItemCount[6 @ LaserRifle] = 0;
$TeamItemCount[6 @ Viper] = 0;
$TeamItemCount[6 @ ShockwvPack] = 0;
$TeamItemCount[6 @ BugPack] = 0;
$TeamItemCount[6 @ LaserPack] = 0;
$TeamItemCount[6 @ DepRocketPack] = 0;
$TeamItemCount[6 @ AhnPack] = 0;
$TeamItemCount[6 @ VulcPack] = 0;
$TeamItemCount[6 @ StutPack] = 0;
$TeamItemCount[6 @ PlasPack] = 0;
$TeamItemCount[6 @ DepSmFFPack] = 0;
$TeamItemCount[6 @ StasisMine] = 0;
$TeamItemCount[6 @ ShockwaveMine] = 0;
$TeamItemCount[6 @ DepFFDoorPack] = 0;
$TeamItemCount[6 @ ProxMine] = 0;
$TeamItemCount[6 @ GunshipVehicle] = 0;
$TeamItemCount[6 @ CrawlerVehicle] = 0;
$TeamItemCount[6 @ BunkerPack] = 0;
$TeamItemCount[6 @ DepLgFFPack] = 0;
$TeamItemCount[6 @ WallPack] = 0;
$TeamItemCount[6 @ FalconVehicle] = 0;
$TeamItemCount[6 @ MinelayerVehicle] = 0;
$TeamItemCount[6 @ PhoenixVehicle] = 0;
$TeamItemCount[6 @ BomberVehicle] = 0;
$TeamItemCount[6 @ ComJamPack] = 0;
$TeamItemCount[6 @ SatComPack] = 0;
$TeamItemCount[6 @ EmpMine] = 0;
$TeamItemCount[6 @ MIRV] = 0;
$TeamItemCount[6 @ LifeAltar] = 0;
$TeamItemCount[6 @ BrimstoneAltar] = 0;

$TeamItemCount[7 @ Volcano] = 0;
$TeamItemCount[7 @ LaserRifle] = 0;
$TeamItemCount[7 @ Viper] = 0;
$TeamItemCount[7 @ ShockwvPack] = 0;
$TeamItemCount[7 @ BugPack] = 0;
$TeamItemCount[7 @ LaserPack] = 0;
$TeamItemCount[7 @ DepRocketPack] = 0;
$TeamItemCount[7 @ AhnPack] = 0;
$TeamItemCount[7 @ VulcPack] = 0;
$TeamItemCount[7 @ StutPack] = 0;
$TeamItemCount[7 @ PlasPack] = 0;
$TeamItemCount[7 @ DepSmFFPack] = 0;
$TeamItemCount[7 @ StasisMine] = 0;
$TeamItemCount[7 @ ShockwaveMine] = 0;
$TeamItemCount[7 @ DepFFDoorPack] = 0;
$TeamItemCount[7 @ ProxMine] = 0;
$TeamItemCount[7 @ GunshipVehicle] = 0;
$TeamItemCount[7 @ CrawlerVehicle] = 0;
$TeamItemCount[7 @ BunkerPack] = 0;
$TeamItemCount[7 @ DepLgFFPack] = 0;
$TeamItemCount[7 @ WallPack] = 0;
$TeamItemCount[7 @ FalconVehicle] = 0;
$TeamItemCount[7 @ MinelayerVehicle] = 0;
$TeamItemCount[7 @ PhoenixVehicle] = 0;
$TeamItemCount[7 @ BomberVehicle] = 0;
$TeamItemCount[7 @ ComJamPack] = 0;
$TeamItemCount[7 @ SatComPack] = 0;
$TeamItemCount[7 @ EmpMine] = 0;
$TeamItemCount[7 @ MIRV] = 0;
$TeamItemCount[7 @ LifeAltar] = 0;
$TeamItemCount[7 @ BrimstoneAltar] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
