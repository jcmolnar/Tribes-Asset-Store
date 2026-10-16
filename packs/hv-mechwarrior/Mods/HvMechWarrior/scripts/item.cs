//----------------------------------------------------------------------------
$ItemFavoritesKey = "hvMechwarrior14";  // Change this if you add new items
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
$FourSlot = 4;
$FiveSlot = 5;
$SixSlot = 6;
$HVAC10Slot=7;//+++++++++
$MachineGun2Slot=7;//+++++++++
$HMechMortar1Slot=7;//+++++++++
$LMechMortar1Slot=7;//+++++++++

//----------------------------------
$AutoUse[PPC] = True;
$AutoUse[GaussRifle] = True;
$AutoUse[GJ] = True; 
$AutoUse[ThumperGun] = True; 
$AutoUse[SniperCannon] = True;
//=======
$AutoUse[MachineGun] = True;
$AutoUse[Flamer] = True;
$AutoUse[SmokeLauncher] = True;
$AutoUse[HMechMortar] = True;//+++++
$AutoUse[LMechMortar] = True;//+++++
//=========
$AutoUse[TargetingLaser] = False;
//========
$AutoUse[LRM5] = True;//+++++++++++++++++++++++++++
$AutoUse[LRM10] = True;//+++++++++++++++++++++++++++
$AutoUse[LRM20] = True;//+++++++++++++++++++++++++++
//=======
$AutoUse[STR2] = True;//+++++++++++++++++++++++++++
$AutoUse[STR4] = True;//+++++++++++++++++++++++++++
$AutoUse[STR6] = True;//+++++++++++++++++++++++++++
//========
$AutoUse[ArrowIV] = True;
$AutoUse[Thunderbolt] = True;//++++++++++
$AutoUse[Thunderbolt5] = True;//++++++++++
$AutoUse[ThunderLRM] = True;//++++++++++
//========
$AutoUse[SmlLas] = True;//+++++++++++++++++++++++++++
$AutoUse[MedLas] = True;//+++++++++++++++++++++++++++
$AutoUse[LrgLas] = True;//+++++++++++++++++++++++++++
$AutoUse[SmlPLas] = True;//+++++++++++++++++++++++++++
$AutoUse[MedPLas] = True;//+++++++++++++++++++++++++++
$AutoUse[LrgPLas] = True;//+++++++++++++++++++++++++++
//=======
$AutoUse[AC5] = True;//+++++++++++++++++++++++++++
$AutoUse[AC10] = True;//+++++++++++++++++++++++++++
$AutoUse[AC20] = True;//+++++++++++++++++++++++++++
//======
$AutoUse[Ultra5] = True;//+++++++++++++++++++++++++++
$AutoUse[Ultra10] = True; //Ultra10
$AutoUse[Ultra20] = True;//+++++++++++++++++++++++++++
//======
$AutoUse[HVAC10] = True;//+++++++++++++++++++++++++++
//-----------------------------------------
$Use[PPC] = False; //++++++++
//----------------------------------------------------------------------------------------------------------------
$ArmorType[Male, CommandoArmor] = larmor;
$ArmorType[Male, WaspArmor] = xarmor;//++++++
$ArmorType[Male, PantherArmor] = parmor;
$ArmorType[Male, DriverArmor] = driver;//++++++PhoenixHawk+++++++
$ArmorType[Male, DeathMatchArmor] = dmarmor;//++++++++++++++
$ArmorType[Male, CenturionArmor] = carmor;//++++++++++++++

$ArmorType[Male, HunchbackArmor] = marmor;//++++++++++++++
$ArmorType[Male, HellBringerArmor] = hbarmor;//++++++++++++++
$ArmorType[Male, ArcherArmor] = aarmor;//++++++++++++++
$ArmorType[Male, WarhammerArmor] = warmor;//++++++++++++++

$ArmorType[Male, BattleMasterArmor] = barmor;
$ArmorType[Male, ChargerArmor] = rarmor;//+++++++++
$ArmorType[Male, CyclopsArmor] = yarmor;//+++++++++
$ArmorType[Male, AtlasArmor] = harmor;
//-----------------------------------++++++++++++++++++++++++++
$ArmorType[female, CommandoArmor] = larmor;
$ArmorType[female, WaspArmor] = xarmor;//++++++++
$ArmorType[female, PantherArmor] = parmor;
$ArmorType[female, DriverArmor] = driver;
$ArmorType[female, DeathMatchArmor] = dmarmor;//++++++++++++++
$ArmorType[female, CenturionArmor] = carmor;//++++++++++++++

$ArmorType[female, HunchbackArmor] = marmor;//++++++++++++++
$ArmorType[female, HellBringerArmor] = hbarmor;//++++++++++++++
$ArmorType[female, ArcherArmor] = aarmor;//++++++++++++++
$ArmorType[female, WarhammerArmor] = warmor;//++++++++++++++

$ArmorType[female, BattleMasterArmor] = barmor;
$ArmorType[female, ChargerArmor] = rarmor;//+++++++++
$ArmorType[female, CyclopsArmor] = yarmor;//+++++++++
$ArmorType[female, AtlasArmor] = harmor;//++++++++++++++
//------------------------------------++++++++++++++++++++++++
$ArmorName[larmor] = CommandoArmor;
$ArmorName[xarmor] = WaspArmor;//+++++++
$ArmorName[driver] = DriverArmor;
$ArmorName[parmor] = PantherArmor;
$ArmorName[dmarmor] = DeathMatchArmor;
$ArmorName[carmor] = CenturionArmor;

$ArmorName[marmor] = HunchbackArmor;
$ArmorName[hbarmor] = HellBringerArmor;
$ArmorName[aarmor] = ArcherArmor;
$ArmorName[warmor] = WarhammerArmor;

$ArmorName[rarmor] = ChargerArmor;//+++++++
$ArmorName[barmor] = BattleMasterArmor;
$ArmorName[yarmor] = CyclopsArmor;//+++++++
$ArmorName[harmor] = AtlasArmor;
//---------------------------------------------------------------------------------------------------------------
// Amount to remove when selling or dropping ammo
//+++++++++++++++++++++++
$SellAmmo[MachineGunAmmo] = 30;
$SellAmmo[LRMAmmo] = 10;
$SellAmmo[Ultra10Ammo] = 25;
$SellAmmo[Ultra20Ammo] = 20;
$SellAmmo[Ultra5Ammo] = 30;
$SellAmmo[HVAC10Ammo] = 10;//+++++++++
$SellAmmo[STRAmmo] = 5;
$SellAmmo[ArrowIVAmmo] = 2;
$SellAmmo[ThunderboltAmmo] = 2;//++++++++
$SellAmmo[Thunderbolt5Ammo] = 4;//++++++++
$SellAmmo[ThunderLRMAmmo] = 2;//++++++++
$SellAmmo[AC5Ammo] = 32;
$SellAmmo[AC10Ammo] = 25;
$SellAmmo[AC20Ammo] = 20;
$SellAmmo[GaussGunAmmo] = 2;
$SellAmmo[ThumperGunAmmo] = 2;
$SellAmmo[GJAmmo] = 10;
$SellAmmo[SniperGunAmmo] = 4;
$SellAmmo[SmokeAmmo] = 4;
$SellAmmo[HMechMortarAmmo] = 2;
$SellAmmo[LMechMortarAmmo] = 4;
$SellAmmo[ScoutDroneAmmo] = 1;
//++++++++++++++++++++++
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
//$SellAmmo[VibroMine] = 5;//++++++
//$SellAmmo[InfernoMine] = 5;//++++++++
$SellAmmo[Grenade] = 5;
//$SellAmmo[NukeGrenade] = 5;//++++
//$SellAmmo[InfernoGrenade] = 5;//++++
//$SellAmmo[SmokeHandGrenade] = 5;//++++

// Max Amount of ammo the Ammo Pack can carry
//++++++++++++++++
$MunitionsPackMax[MachineGunAmmo] = 180;
$MunitionsPackMax[LRMAmmo] = 75;
$MunitionsPackMax[STRAmmo] = 36;
$MunitionsPackMax[ArrowIVAmmo] = 2;
$MunitionsPackMax[ThunderboltAmmo] = 4;
$MunitionsPackMax[Thunderbolt5Ammo] = 10;
$MunitionsPackMax[ThunderLRMAmmo] = 2;
$MunitionsPackMax[Ultra5Ammo] = 192;//++++++
$MunitionsPackMax[Ultra10Ammo] = 128;//++++++
$MunitionsPackMax[Ultra20Ammo] = 64;//++++++
$MunitionsPackMax[AC5Ammo] = 144;//++++++
$MunitionsPackMax[AC10Ammo] = 80;//++++++
$MunitionsPackMax[AC20Ammo] = 32;//++++++
$MunitionsPackMax[HVAC10Ammo] = 40;//++++++
$MunitionsPackMax[GaussGunAmmo] = 4;
$MunitionsPackMax[ThumperGunAmmo] = 4;
$MunitionsPackMax[GJAmmo] = 40;
$MunitionsPackMax[SniperGunAmmo] = 10;
$MunitionsPackMax[SmokeAmmo] = 10;
$MunitionsPackMax[HMechMortarAmmo] = 4;
$MunitionsPackMax[LMechMortarAmmo] = 6;
//+++++++++++++++++++++++++
$MunitionsPackMax[MineAmmo] = 5;
//$MunitionsPackMax[InfernoMine] = 5;//++++
//$MunitionsPackMax[VibroMine] = 5;//+++++
$MunitionsPackMax[Grenade] = 5;
//$MunitionsPackMax[NukeGrenade] = 5;//++++
//$MunitionsPackMax[InfernoGrenade] = 5;//++++
//$MunitionsPackMax[SmokeHandGrenade] = 5;//++++

// Items in the MunitionsPack+++++++++++++++++++++++++
$MunitionsPackItems[1] = Grenade;
$MunitionsPackItems[2] = LRMAmmo;
$MunitionsPackItems[3] = STRAmmo;
$MunitionsPackItems[4] = ArrowIVAmmo;
$MunitionsPackItems[5] = AC5Ammo;
$MunitionsPackItems[6] = AC10Ammo;
$MunitionsPackItems[7] = AC20Ammo;
$MunitionsPackItems[8] = Ultra5Ammo;
$MunitionsPackItems[9] = Ultra10Ammo;
$MunitionsPackItems[10] = Ultra20Ammo;
$MunitionsPackItems[11] = MachineGunAmmo;
$MunitionsPackItems[12] = GaussGunAmmo;
$MunitionsPackItems[13] = SniperGunAmmo;
$MunitionsPackItems[14] = SmokeAmmo;
$MunitionsPackItems[15] = HVAC10Ammo;
$MunitionsPackItems[16] = HMechMortarAmmo;
$MunitionsPackItems[17] = LMechMortarAmmo;
$MunitionsPackItems[18] = ThunderboltAmmo;
$MunitionsPackItems[19] = ThunderLRMAmmo;
$MunitionsPackItems[20] = Thunderbolt5Ammo;
$MunitionsPackItems[21] = ThumperGunAmmo;
$MunitionsPackItems[22] = GJAmmo;
//$MunitionsPackItems[20] = VibroMine;
//$MunitionsPackItems[21] = InfernoMine;
//$MunitionsPackItems[22] = NukeGrenade;
//$MunitionsPackItems[23] = InfernoGrenade;
//$MunitionsPackItems[24] = SmokeHandGrenade;
$MunitionsPackItems[0] = MineAmmo;

//-------------------------------------------------------------------------------------------------------
// Limit on number of special Items you can buy+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
$TeamItemMax[DeployableMunitionsPack] = 5;
$TeamItemMax[DeployableMechBay] = 5;

$TeamItemMax[Ultra20Pack] = 2;
//$TeamItemMax[MedPLasPack] = 2;
$TeamItemMax[MedLasPack] = 4;
$TeamItemMax[LongTomPack] = 1;
$TeamItemMax[PPCPack] = 2;
$TeamItemMax[LRM5Pack] = 2;
$TeamItemMax[Str2Pack] = 2;
$TeamItemMax[FlamerPack] = 4;

$TeamItemMax[CameraPack] = 25;
$TeamItemMax[DeployableECMPod] = 10;
$TeamItemMax[RadarPack] = 10;
$TeamItemMax[BeagleActiveProbe] = 20;

$TeamItemMax[RieverVehicle] = 2;
$TeamItemMax[PHVehicle] = 100;
$TeamItemMax[CorsairVehicle] = 2;
$TeamItemMax[StingrayVehicle] = 2;
$TeamItemMax[LeopardVehicle] = 2;
$TeamItemMax[UnionVehicle] = 1;

$TeamItemMax[ArtyShell] = 2;

$TeamItemMax[Beacon] = 80;
$TeamItemMax[mineammo] = 95;//++++++++++++++++++++++++++++++++++++++++++++++
//--------------------------------------------------------------

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
$WeaponAmmo[PPC] = "";
$WeaponAmmo[GaussRifle] = GaussGunAmmo;//++++++
$WeaponAmmo[ThumperGun] = ThumperGunAmmo;//++++++
$WeaponAmmo[GJ] = GJAmmo;//++++++
$WeaponAmmo[Ultra10] = Ultra10Ammo;//++++++++
$WeaponAmmo[ArrowIV] = ArrowIVAmmo;//+++++
$WeaponAmmo[Flamer] = "";//+++++++
$WeaponAmmo[SmokeLauncher] = "SmokeAmmo";//+++++
$WeaponAmmo[SniperCannon] = SniperGunAmmo;//+++++
$WeaponAmmo[MachineGun] = MachineGunAmmo;//++++++++
$WeaponAmmo[LRM5] = LRMAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[LRM10] = LRMAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[LRM20] = LRMAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[STR2] = STRAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[STR4] = STRAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[STR6] = STRAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[SmlLas] = "";//+++++++++++++++++++++++++++
$WeaponAmmo[MedLas] = "";//+++++++++++++++++++++++++++
$WeaponAmmo[LrgLas] = "";//+++++++++++++++++++++++++++
$WeaponAmmo[SmlPLas] = "";//+++++++++++++++++++++++++++
$WeaponAmmo[MedPLas] = "";//+++++++++++++++++++++++++++
$WeaponAmmo[LrgPLas] = "";//+++++++++++++++++++++++++++
$WeaponAmmo[AC5] = AC5Ammo;//+++++++++++++++++++++++++++
$WeaponAmmo[AC10] = AC10Ammo;//+++++++++++++++++++++++++++
$WeaponAmmo[AC20] = AC20Ammo;//+++++++++++++++++++++++++++
$WeaponAmmo[Ultra5] = Ultra5Ammo;//+++++++++++++++++++++++++++
$WeaponAmmo[Ultra20] = Ultra20Ammo;//+++++++++++++++++++++++++++
$WeaponAmmo[HVAC10] = HVAC10Ammo;//+++++++++++++++++++++++++++
$WeaponAmmo[Thunderbolt5] = Thunderbolt5Ammo;//+++++++++++++++++++++++++++
$WeaponAmmo[Thunderbolt] = ThunderboltAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[ThunderLRM] = ThunderLRMAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[HMechMortar] = HMechMortarAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[LMechMortar] = LMechMortarAmmo;//+++++++++++++++++++++++++++
$WeaponAmmo[ScoutDrone] = ScoutDroneAmmo;//+++++++++++++++++++++++++++

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

//+++++++++++++changed favs from 19 to 50+++++++++++++++
function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%favItem20,%favItem21,%favItem22,%favItem23,%favItem24,%favItem25,%favItem26,%favItem27,%favItem28,%favItem29,%favItem30,%favItem31,%favItem32,%favItem33,%favItem34,%favItem35,%favItem36,%favItem37,%favItem38,%favItem39,%favItem40,%favItem41,%favItem42,%favItem43,%favItem44,%favItem45,%favItem46,%favItem47,%favItem48,%favItem49,%favItem50)
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
			for (%i = 0; %i < 51; %i++) { 
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
	if (Player::getMountedItem(%client,$BackpackSlot) == MunitionsPack && $MunitionsPackMax[%item] != "") {
		%extraAmmo = $MunitionsPackMax[%item];
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
	else if(%item.className == Grenade) {//+++++++++++
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Grenade");
		if (Player::getItemClassCount(%client,"Grenade") >= $MaxGrenades[%armor]) {
			Client::sendMessage(%client,0,"To many grenades for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}//+++++++++++
	else if(%item.className == Mine) {//+++++++++++
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Mine");
		if (Player::getItemClassCount(%client,"Mine") >= $MaxMines[%armor]) {
			Client::sendMessage(%client,0,"To many mines for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}//+++++++++++
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
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) 
		{
		if (%item.className == Armor) 	
			{
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0) 
				{
				if ($poisonTime[%client] < 1 && %client.permap != true) 
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
							if(%buyarmor == "harmor")//++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Atlas: 100 ton, fire support Mech\n-Speed: Poor  -Durability: Superior  -Jump Jets: Fair\n-Perks: Can carry nearly all weapon and turret types  -Flaws: Poor manuverability", 10);
								Player::setItemCount(%client, LRMPackH,1);
								Player::mountItem(%client, LRMPackH, 4);
								Player::setItemCount(%client, GaussPackH,1);
								Player::mountItem(%client, GaussPackH, 5);
								Player::setItemCount(%client, RadarPackH,1);
								Player::mountItem(%client, RadarPackH, 6);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == LRMPackH) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, LRMPackH,0);
								}
									if(Player::getMountedItem(%player, 5) == GaussPackH)
									{
										Player::unmountItem(%player, 5);
										Player::setItemCount(%player, GaussPackH,0);
									}
									if(Player::getMountedItem(%player, 6) == RadarPackH)
									{
										Player::unmountItem(%player, 6);
										Player::setItemCount(%player, RadarPackH,0);
									}
								}
							if(%buyarmor == "yarmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Cyclops: 90 ton, command and control Mech\n-Speed: Fair  -Durability: Excellent  -Jump Jets: Good\n-Perks: Can deploy and control all turret types  -Flaws: Limited weapon variety", 10);
								Player::setItemCount(%client, RadarPackH,1);
								Player::mountItem(%client, RadarPackH, $FourSlot);
								Player::setItemCount(%client, RadarPackH2,1);
								Player::mountItem(%client, RadarPackH2, $FiveSlot);
								Player::setItemCount(%client, FCC,2);
							}
							else
							{
							if(Player::getMountedItem(%player, $FourSlot) == RadarPackH) 
								{
								Player::unmountItem(%player, $FourSlot);
								Player::setItemCount(%player, RadarPackH,0);
								}
									if(Player::getMountedItem(%player, $FiveSlot) == RadarPackH2)
									{
										Player::unmountItem(%player, $FiveSlot);
										Player::setItemCount(%player, RadarPackH2,0);
										Player::setItemCount(%player, FCC,0);
									}
								}//+++++++++++++++
							if(%buyarmor == "barmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>BattleMaster: 85 ton, versatile combat Mech\n-Speed: Fair  -Durability: Excellent  -Jump Jets: Very Good\n-Perks: Large weapon variety  -Flaws: None", 10);
								Player::setItemCount(%client, LRMPackB,1);
								Player::mountItem(%client, LRMPackB, 4);
								Player::setItemCount(%client, MLPackB,1);
								Player::mountItem(%client, MLPackB, 5);
								Player::setItemCount(%client, MLPackB2,1);
								Player::mountItem(%client, MLPackB2, 6);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == LRMPackB) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, LRMPackB,0);
								}
									if(Player::getMountedItem(%player, 5) == MLPackB)
									{
										Player::unmountItem(%player, 5);
										Player::setItemCount(%player, MLPackB,0);
									}
									if(Player::getMountedItem(%player, 6) == MLPackB2)
									{
										Player::unmountItem(%player, 6);
										Player::setItemCount(%player, MLPackB2,0);
									}
								}//+++++++++++++++
							if(%buyarmor == "rarmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Charger: 80 ton, close combat Mech\n-Speed: Very Good  -Durability: Very Good  -Jump Jets: Very Good\n-Perks: High speed  -Flaws: Poor weapon variety", 10);
							}
							if(%buyarmor == "warmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>WarHammer: 75 ton, versatile combat Mech\n-Speed: Good  -Durability: Very Good  -Jump Jets: fair\n-Perks: Large weapon variety  -Flaws: Mediocre Jump Jets", 10);
								Player::setItemCount(%client, LRMPackW,1);
								Player::mountItem(%client, LRMPackW, 4);
								Player::setItemCount(%client, LRMPackW2,1);
								Player::mountItem(%client, LRMPackW2, 5);
							}
							else
							{
									if(Player::getMountedItem(%player, 4) == LRMPackW)
									{
										Player::unmountItem(%player, 4);
										Player::setItemCount(%player, LRMPackW,0);
									}
									if(Player::getMountedItem(%player, 5) == LRMPackW2)
									{
										Player::unmountItem(%player, 5);
										Player::setItemCount(%player, LRMPackW2,0);
									}
								}//+++++++++++++++
							if(%buyarmor == "aarmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Archer: 70 ton, fire support Mech\n-Speed: Good  -Durability: Very Good  -Jump Jets: Fair\n-Perks: Can carry all missile-type Weapons  -Flaws: Limited AC-type weapons", 10);
								Player::setItemCount(%client, MLPackA,1);
								Player::mountItem(%client, MLPackA, 4);
								Player::setItemCount(%client, LRMPackA,1);
								Player::mountItem(%client, LRMPackA, 5);
								Player::setItemCount(%client, LRMPackA2,1);
								Player::mountItem(%client, LRMPackA2, 6);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == MLPackA) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, MLPackA,0);
								}
									if(Player::getMountedItem(%player, 5) == LRMPackA)
									{
										Player::unmountItem(%player, 5);
										Player::setItemCount(%player, LRMPackA,0);
									}
									if(Player::getMountedItem(%player, 6) == LRMPackA2)
									{
										Player::unmountItem(%player, 6);
										Player::setItemCount(%player, LRMPackA2,0);
									}
								}//+++++++++++++++
							if(%buyarmor == "hbarmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>HellBringer: 65 ton, versatile combat Mech\n-Speed: Very Good  -Durability: Good  -Jump Jets: Very Good\n-Perks: Large weapon variety  -Flaws: None", 10);
								Player::setItemCount(%client, GaussPackHB,1);
								Player::mountItem(%client, GaussPackHB, 4);
								Player::setItemCount(%client, MLPackHB,1);
								Player::mountItem(%client, MLPackHB, 5);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == GaussPackHB) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, GaussPackHB,0);
								}
									if(Player::getMountedItem(%player, 5) == MLPackHB)
									{
										Player::unmountItem(%player, 5);
										Player::setItemCount(%player, MLPackHB,0);
									}
								}//++++++++++++++
								if(%buyarmor == "marmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>HunchBack: 50 ton, Close-combat Mech\n-Speed: Good  -Durability: Good  -Jump Jets: Fair\n-Perks: Can carry the Ultra-AC20  -Flaws: Limited to close range weapons", 10);
								Player::setItemCount(%client, UltraPackM,1);
								Player::mountItem(%client, UltraPackM, 4);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == UltraPackM) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, UltraPackM,0);
								}
							}//++++++++++++++
							if(%buyarmor == "carmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Centurion: 45 ton, hunter-killer Mech\n-Speed: Very Good  -Durability: Fair  -Jump Jets: Good\n-Perks: Large weapon variety  -Flaws: Limited payload", 10);
								Player::setItemCount(%client, MLPackC,1);
								Player::mountItem(%client, MLPackC, 4);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == MLPackC) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, MLPackC,0);
								}
							}//++++++++++++++
							if(%buyarmor == "parmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Panther: 35 ton, hunter-killer Mech\n-Speed: Excellent  -Durability: Fair  -Jump Jets: Superior\n-Perks: Large weapon variety, great Jump Jets  -Flaws: Limited durability and payload", 10);
								Player::setItemCount(%client, STRPackP,1);
								Player::mountItem(%client, STRPackP, 4);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == STRPackP) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, STRPackP,0);
								}
							}//++++++++++++++
							if(%buyarmor == "driver")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Phoenix Hawk LAM: 35 ton, Land-Air-Mech\n-Speed: Excellent  -Durability: Fair  -Jump Jets: None\n-Perks: Transformation to 'Flight Mode'  -Flaws: Limited durability and payload", 10);
								Player::setItemCount(%client, DRgunA,1);
								Player::mountItem(%client, DRgunA, 4);
								Player::setItemCount(%client, DRgunB,1);
								Player::mountItem(%client, DRgunB, 5);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == DRgunA) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, DRgunA,0);
								}
									if(Player::getMountedItem(%player, 5) == DRgunB)
									{
										Player::unmountItem(%player, 5);
										Player::setItemCount(%player, DRgunB,0);
									}
								}//++++++++++++++
							if(%buyarmor == "xarmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Wasp: 20 ton, Recon Mech\n-Speed: Superior  -Durability: Very Poor  -Jump Jets: Very Good\n-Perks: Best all-around mobility  -Flaws: Very limited durability and payload", 10);
								Player::setItemCount(%client, XgunA,1);
								Player::mountItem(%client, XgunA, 4);
								Player::setItemCount(%client, XgunB,1);
								Player::mountItem(%client, XgunB, 5);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == XgunA) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, XgunA,0);
								}
									if(Player::getMountedItem(%player, 5) == XgunB)
									{
										Player::unmountItem(%player, 5);
										Player::setItemCount(%player, XgunB,0);
									}
								}//++++++++++++++
							if(%buyarmor == "larmor")//++++++++++++++++++
							{
							bottomprint(Player::getClient(%player), "<jc><f2>Commando: 25 ton, scout Mech\n-Speed: Superior  -Durability: Poor  -Jump Jets: Fair\n-Perks: Speed and Manuverability  -Flaws: Limited durability, weapon variety, and payload", 10);
								Player::setItemCount(%client, STRPackL,1);
								Player::mountItem(%client, STRPackL, 4);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == STRPackL) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, STRPackL,0);
								}
							}//++++++++++++++
							if (Player::getMountedItem(%client,$BackpackSlot) == MunitionsPack) 
							fillMunitionsPack(%client);
							return 1;
						}
				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
	}
	 else if (%item.className == Backpack) {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) 
				{
				if(%pack == MunitionsPack)
//					{//++++
//					bottomprint(Player::getClient(%player), "<jc><f2>The Munitions Pod allows a Mech to carry more ammunition.", 5);//++++++++
					checkMax(%client,%armor);
//					}//++++
//				else 
//				if(%pack == DoubleHeatSink)
//					{//++++
//					bottomprint(Player::getClient(%player), "<jc><f2>Double Heat Sinks cool off your Mech faster.", 5);//++++++++
//					checkMax(%client,%armor);
//					}//++++
				else 
				if(%pack == FCCPod) 
					{//+++++++
					if(Player::getItemCount(%client,"ArrowIV") > 0) {
						Client::sendMessage(%client,0,"Removed 'Fire-Control Computer' - Auto Selling ArrowIV");
						remoteSellItem(%client,62);//61 correct item #, won't sell++++
					}
				}//++++++
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == MunitionsPack) 
					fillMunitionsPack(%client);
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
				if(%pack == MunitionsPack) 
					fillMunitionsPack(%client);
			}				 
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
				if(%item == ArrowIV && Player::getItemCount(%client,"FCCPod") == 0) {
//					bottomprint(Player::getClient(%player), "<jc><f2>The ArrowIV can be manually controlled by activating your FCC Pod and pointing at the sky.", 7);//++++++++
					buyItem(%client,"FCCPod");
					Client::sendMessage(%client,0,"ArrowIV Equipped - Auto buying 'Fire-Control Computer'");
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
	 	else if(%item.className == Grenade) {//++++++++++++++++++++++++++++++++++
	if($TeamItemMax[%item] != "") 
		{						
		if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
		return 0;
		}
		%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
		if(%delta || $testCheats) 
			{
			teamEnergyBuySell(%player,(%item.price * -1 * %delta));
			%G[0] = "NukeGrenade";
			%G[1] = "InfernoGrenade";
			%G[2] = "SmokeHandGrenade";
//			%G[3] = "???";
			%numSpecial1 = 3;
			for(%i=0;%i<%numSpecial1;%i++) 
				{
				if (%item == %G[%i]) 
					{
					%yesflag = true;
					}
				}
				if (%yesflag == true) 
					{
					for(%i=0;%i<%numSpecial1;%i++) 
						{
						if(%item != %G[%i]) 
							{
							if(Player::getItemCount(%client,%G[%i]) > 0) 
								{
								Client::sendMessage(%client,0,"Bought "@%item.description@" - Auto Selling "@%G[%i].description@".");
								remoteSellItemData(%client,%G[%i]);
								%GT = %G[%i];
								$GTD[%client] = %GT;
								}
							}			
						}
					}
					%GT = %G[%i];
					$GTD[%client] = %GT;
					Player::incItemCount(%client,%item,%delta);
					return 1;
					}
			 }//++++++++++++++++++++++++++++++
	 	else if(%item.className == Mine) {//+++++++++++++++++++++++++++++
	if($TeamItemMax[%item] != "") 
		{						
		if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
		return 0;
		}
		%delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
		if(%delta || $testCheats) 
			{
			teamEnergyBuySell(%player,(%item.price * -1 * %delta));
			%M[0] = "VibroMine";
			%M[1] = "InfernoMine";
//			%M[2] = "???";
//			%M[3] = "???";
			%numSpecial2 = 2;
			for(%i=0;%i<%numSpecial2;%i++) {
			if (%item == %M[%i]) 
				{
				%yesflag = true;
				}
			}
			if (%yesflag == true) 
				{
				for(%i=0;%i<%numSpecial2;%i++) 
					{
					if(%item != %M[%i]) 
						{
						if(Player::getItemCount(%client,%M[%i]) > 0) 
							{
							Client::sendMessage(%client,0,"Bought "@%item.description@" - Auto Selling "@%M[%i].description@".");
							remoteSellItemData(%client,%M[%i]);
							}
						}			
					}
				}
				Player::incItemCount(%client,%item,%delta);
				return 1;
				}
			 }//++++++++++++++++++++++++++++++
		else {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
		    %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			 if(%delta || $testCheats) {
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				%S[0] = "NARC";
				%S[1] = "RangeFinder";
				%S[2] = "ScoutDrone";
				%S[3] = "TAG";
				%numSpecial3 = 4;
				for(%i=0;%i<%numSpecial3;%i++) {
					if (%item == %S[%i]) {
						%yesflag = true;
					}
				}
				if (%yesflag == true) {
					for(%i=0;%i<%numSpecial3;%i++) {
						if(%item != %S[%i]) {
							if(Player::getItemCount(%client,%S[%i]) > 0) {
								Client::sendMessage(%client,0,"Bought "@%item.description@" - Auto Selling "@%S[%i].description@"."); 
								remoteSellItemData(%client,%S[%i]);
							}
						}			
					}
				}
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
			else if (%item == MunitionsPack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == FCCPod) { //+++++++
				if(Player::getItemCount(%client,"ArrowIV") > 0) {
					Client::sendMessage(%client,0,"Removed 'Fire-Control Computer' - Auto Selling ArrowIV");
					remoteSellItem(%client,62);				
				}
			}//++++++++
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}

function remoteSellItemData(%client,%item) //++++++++++
{ 
if (isPlayerBusy(%client)) 
return; 
%item = getItemData(%type);//++++++++
%player = Client::getOwnedObject(%client); 
if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) 
{ 
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
else 
if (%item == ammopack) 
checkMax(%client,Player::getArmor(%client)); 
else if($TeamItemMax[%item] != "") 
{ 
if(%item.className == Vehicle) 
$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
 } 
//else if(%item == EnergyPack) 
//{ 
//if(Player::getItemCount(%client,"LaserRifle") > 0) 
//{ 
//Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle"); 
//remoteSellItemData(%client,LaserRifle); 
//} 
//} 
teamEnergyBuySell(%player,%item.price * %numsell); 
Player::setItemCount(%player,%item,(%count-%numsell)); 
updateBuyingList(%client); 
Client::SendMessage(%client,0,"~wbuysellsound.wav"); 
return 1; 
} 
} 
Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav"); 
} //+++++++++++++++++

function remoteUseItem(%client,%type)
{
	//echo("Use item: " @ %type @ " " @ %item);
	%client.throwStrength = 1;

	%item = getItemData(%type);
	if (%item == Backpack) 
		%item = Player::getMountedItem(%client,$BackpackSlot);
	else
	{
	if (%item == Weapon)
	%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	Player::useItem(%client,%item);
}

function remoteUseItemIX(%client,%type) 
{ 
%client.throwStrength = 1; 
%item = getItemData(%type); 
if (%item == Backpack) 
	{ 
	%item = Player::getMountedItem(%client,$BackpackSlot); 
	if(%item == "-1") 
		ixCheckPickup(%client); 
	} 
else 
	{ 
if (%item == Weapon) 
	%item = Player::getMountedItem(%client,$WeaponSlot); 
	} 
if(((%item == SniperRifle) || (%item == Mortar) || (%item == EMPGrenadeLauncher)) && (isPlayerBusy(%client))) 
	{ 
	Client::sendMessage(%client,0,"Cannot Change weapons until this one has reloaded"); 
	return; 
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

$NextWeapon[SmokeLauncher] = LMechMortar;
$NextWeapon[LMechMortar] = HMechMortar;
$NextWeapon[HMechMortar] = MachineGun;
$NextWeapon[MachineGun] = Flamer;
$NextWeapon[Flamer] = MedLas;
$NextWeapon[MedLas] = LrgLas;
$NextWeapon[LrgLas] = MedPLas;
$NextWeapon[MedPLas] = LrgPLas;
$NextWeapon[LrgPLas] = LRM5;
$NextWeapon[LRM5] = LRM10;
$NextWeapon[LRM10] = LRM20;
$NextWeapon[LRM20] = ThunderLRM;
$NextWeapon[ThunderLRM] = STR2;
$NextWeapon[STR2] = STR4;
$NextWeapon[STR4] = STR6;
$NextWeapon[STR6] = Thunderbolt5;
$NextWeapon[Thunderbolt5] = Thunderbolt;
$NextWeapon[Thunderbolt] = ArrowIV;
$NextWeapon[ArrowIV] = PPC;
$NextWeapon[PPC] = GaussRifle;
$NextWeapon[GaussRifle] = GJ;
$NextWeapon[GJ] = ThumperGun;
$NextWeapon[ThumperGun] = SniperCannon;
$NextWeapon[SniperCannon] = AC5;
$NextWeapon[AC5] = AC10;
$NextWeapon[AC10] = AC20;
$NextWeapon[AC20] = Ultra5;
$NextWeapon[Ultra5] = Ultra10;
$NextWeapon[Ultra10] = Ultra20;
$NextWeapon[Ultra20] = HVAC10;
$NextWeapon[HVAC10] = SmokeLauncher;

$PrevWeapon[SmokeLauncher] = HVAC10;
$PrevWeapon[LMechMortar] = SmokeLauncher;
$PrevWeapon[HMechMortar] = LMechMortar;
$PrevWeapon[MachineGun] = HMechMortar;
$PrevWeapon[Flamer] = MachineGun;
$PrevWeapon[MedLas] = Flamer;
$PrevWeapon[LrgLas] = MedLas;
$PrevWeapon[MedPLas] = LrgLas;
$PrevWeapon[LrgPLas] = MedPLas;
$PrevWeapon[LRM5] = LrgPLas;
$PrevWeapon[LRM10] = LRM5;
$PrevWeapon[LRM20] = LRM10;
$PrevWeapon[ThunderLRM] = LRM20;
$PrevWeapon[STR2] = ThunderLRM;
$PrevWeapon[STR4] = STR2;
$PrevWeapon[STR6] = STR4;
$PrevWeapon[Thunderbolt5] = STR6;
$PrevWeapon[Thunderbolt] = Thunderbolt5;
$PrevWeapon[ArrowIV] = Thunderbolt;
$PrevWeapon[PPC] = ArrowIV;
$PrevWeapon[GaussRifle] = PPC;
$PrevWeapon[GJ] = GaussRifle;
$PrevWeapon[ThumperGun] = GJ;
$PrevWeapon[SniperCannon] = ThumperGun;
$PrevWeapon[AC5] = SniperCannon;
$PrevWeapon[AC10] = AC5;
$PrevWeapon[AC20] = AC10;
$PrevWeapon[Ultra5] = AC20;
$PrevWeapon[Ultra10] = Ultra5;
$PrevWeapon[Ultra20] = Ultra10;
$PrevWeapon[HVAC10] = Ultra20;

function remoteNextWeapon(%client)
{
if(CheckClient(%client)) return;//+++++++++++++++
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
if(CheckClient(%client)) return;//++++++++++++++++
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
	%item = MachineGun;
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
				Client::sendMessage(%client,0,"You received a " @ %item @ ""); //" backpack");+++++++++
		 		return 1;
			}
		}
  		else {
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}
//			else if (%item.className == Grenade) {
//				if (Player::getItemClassCount(%player,"Grenade") >= $MaxGrenades[%armor]) 
//					return 0;//++++++++++++++++++++++++++++++++++
//			}
//			else if (%item.className == Mine) {
//				if (Player::getItemClassCount(%player,"Mine") >= $MaxMines[%armor]) 
//					return 0;//++++++++++++++++++++++++++++++++++
//			}
//			else//+++++++++  
//			%dname = GameBase::getDataName(%item);
//			if (%dname != "InfernoMine" || %dname != "VibroMine" || %dname != "NukeGrenade" || %dname != "SmokeHandGrenade" || %dname != "InfernoGrenade")
//				{
//				return 0;
//				}//++++++++++++++picks up nothing+++++++++
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == MunitionsPack && $MunitionsPackMax[%item] != "") 
				%extraAmmo = $MunitionsPackMax[%item];
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
	if($matchStarted)
	 {
		if(%item.className != Armor)
		 {
			//echo("Item dropped: ",%player," ",%item);
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			 else
			 {
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
	lightTime = 0.25; //1.5;+++++++++++++++++++++++++
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------
ItemData LightMech//+++++++++++++
{
   heading = "aMechs";
	description = "1---------Light Mechs---------";
	className = "Weapon";
	price = 1;
};

ItemData WaspArmor
{
   heading = "aMechs";
	description = "Wasp";
	shapeFile = "lfemale";
	className = "Armor";
	price = 800;
};

ItemData CommandoArmor
{
   heading = "aMechs";
	description = "Commando";
	shapeFile = "lfemale";
	className = "Armor";
	price = 1000;
};

ItemData DeathMatchArmor
{
   heading = "aMechs";
	shapeFile = "larmor";
	description = "Panther"; //"DM Panther Armor";++++
	showInventory = false;//++++++++++++++++++++
	className = "Armor";
	price = 1200;
	DisplayName = "Panther";//++++
};

ItemData PantherArmor
{
   heading = "aMechs";
	shapeFile = "larmor";
	description = "Panther";
	className = "Armor";
	price = 1200;
	DisplayName = "Panther";//++++
};

ItemData MediumMech//+++++++++++++
{
   heading = "aMechs";
	description = "1-------Medium Mechs-------";
	className = "Weapon";
	price = 1;
};

//ItemData DriverArmor//+++++++++++++
//{
//	heading = "aMechs";
//	shapeFile = "larmor";
//	description = "Phoenix Hawk LAM";
//	className = "Armor";
//	price = 1300;
//};

ItemData CenturionArmor
{
   heading = "aMechs";
	shapeFile = "mfemale";
	description = "Centurion";
	className = "Armor";
	price = 1400;
};

ItemData HunchbackArmor
{
   heading = "aMechs";
	shapeFile = "marmor";
	description = "Hunchback";
	className = "Armor";
	price = 1500;
};

ItemData HeavyMech//+++++++++++++
{
   heading = "aMechs";
	description = "1--------Heavy Mechs--------";
	className = "Weapon";
	price = 1;
};

ItemData HellBringerArmor
{
   heading = "aMechs";
	shapeFile = "marmor";
	description = "HellBringer";
	className = "Armor";
	price = 1700;
};

ItemData ArcherArmor
{
   heading = "aMechs";
	shapeFile = "marmor";
	description = "Archer";
	className = "Armor";
	price = 1900;
};

ItemData WarhammerArmor
{
   heading = "aMechs";
	shapeFile = "marmor";
	description = "Warhammer";
	className = "Armor";
	price = 2000;
};

ItemData AssaultMech//+++++++++++++
{
   heading = "aMechs";
	description = "1-------Assault Mechs-------";
	className = "Weapon";
	price = 1;
};

ItemData ChargerArmor
{
   heading = "aMechs";
	shapeFile = "harmor";
	description = "Charger";
	className = "Armor";
	price = 2100;
};

ItemData BattleMasterArmor
{
   heading = "aMechs";
	shapeFile = "harmor";
	description = "BattleMaster";
	className = "Armor";
	price = 2200;
};

ItemData CyclopsArmor
{
   heading = "aMechs";
	shapeFile = "harmor";
	description = "Cyclops";
	className = "Armor";
	price = 2400;
};

ItemData AtlasArmor
{
   heading = "aMechs";
	shapeFile = "harmor";
	description = "Atlas";
	className = "Armor";
	price = 2500;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------
ItemData PHVehicle//+++++++++
{
	description = "Phoenix Hawk";
	className = "Vehicle";
	shapeFile = "flyer";
   showInventory = false;//++++++++++++++++++++
   heading = "aAerotech Fighters";
	price = 2200;
};

ItemData StingrayVehicle
{
	description = "Stingray";
	className = "Vehicle";
	shapeFile = "flyer";
   heading = "aAerotech Fighters";
	price = 1900;
};

ItemData CorsairVehicle
{
	description = "Corsair";
	className = "Vehicle";
	shapeFile = "flyer";
   heading = "aAerotech Fighters";
	price = 2200;
};

ItemData RieverVehicle
{
	description = "Riever";
	className = "Vehicle";
	shapeFile = "flyer";
   heading = "aAerotech Fighters";
	price = 2500;
};

ItemData LeopardVehicle
{
	description = "Leopard Class";
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
   heading = "bDropships";
	price = 3500;
};

ItemData UnionVehicle
{
	description = "Union Class";
	className = "Vehicle";
	shapeFile = "hover_apc";
   heading = "bDropships";
	price = 5000;
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

//------------------------------------------------------------------------------
ItemData MachineGunAmmo
 {
	 description = "Machine Gun Ammo";
	 className = "Ammo";
	 shapeFile = "ammo2";
	 heading = "xAmmunition";
	 shadowDetailMask = 4;
	 price = 1;
 };
ItemImageData MachineGunImage
{
	shapeFile = "grenammo";
      mountPoint = 0;
mountOffset = {0, 0, 0};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0, 1.607, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
      weaponType = 0;
	ammoType = MachineGunAmmo;
	reloadTime = 0.0; //0.1;+++++++++++++++++++++++++
	fireTime = 0.375; //0.75;+++++++++++++
	accuFire = true;
   lightType = 3;  // Weapon Fire
   lightRadius = 4;
   lightTime = 0.05;
	lightColor = { 0.75, 0.75, 0.35 };
	sfxActivate = SoundItemArm;
};
ItemData MachineGun
{
   description = "Heavy Machine Gun";
	shapeFile = "grenammo";
	hudIcon = "chain";
   className = "Weapon";
   heading = "bBallistic Weapons";
   shadowDetailMask = 4;
   imageType = MachineGunImage;
	showWeaponBar = true;
   price = 50;
};
ItemImageData MachineGun2Image
{
	shapeFile = "grenammo";
      mountPoint = 0;
mountOffset = {0, 0, 0};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0, -1.607, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
      weaponType = 0;
	ammoType = MachineGunAmmo;
	reloadTime = 0.0; //0.1;+++++++++++++++++++++++++
	fireTime = 0.375; //0.75;+++++++++++++
	accuFire = true;
   lightType = 3;  // Weapon Fire
   lightRadius = 4;
   lightTime = 0.05;
	lightColor = { 0.75, 0.75, 0.35 };
};
ItemData MachineGun2
{
   description = "Machine Gun";
	shapeFile = "grenammo";
	hudIcon = "chain";
   className = "Weapon";
   heading = "eOther Weapons";
   shadowDetailMask = 4;
   imageType = MachineGun2Image;
	showWeaponBar = true;
   price = 50;
};
function MachineGun::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,MachineGun2,$MachineGun2Slot);
} 
function MachineGun::onUnmount(%player,%imageSlot) 
{ 
Player::unmountItem(%player,$MachineGun2Slot);
} 
function MachineGun::onUse(%player,%item)//++++++++++++++++++++++++++++++
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Heavy Machine Gun\n-Extremely fast rate of fire  -No heat buildup\n-Low damage  -Effective range: 125m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function MachineGunImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "bigExplosion4";	//fire sound
$HVfiresound2[%new] = "bigExplosion4"; //"SoundChainTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 200;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "MachineGunBullet";		//tracer projectile
$HVsmart[%new] = "MachineGunBullet"; 		//normal fire, guided
$HVsmart2[%new] = "MachineGunBullet2";  		//FCC on, guided
$HVdumb[%new] = "MachineGunBullet";   		//normal fire, dumb
$HVdumb2[%new] = "MachineGunBullet2"; 		//FCC on, dumb
$HVdumb3[%new] = "MachineGunBullet";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "MachineGunBullet2";  		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 10;    				//number of bursts
$HVrounds[%new] = 2;    				//number of missiles per burst
$HVtime1[%new] = 0.0375;           			//delay for bursts
$HVtime2[%new] = 0.0215; //0.0188; 			//delay for individual missiles
$HVknockback1[%new] = -1;       			//kick for bursts
$HVknockback2[%new] = -1;        			//kick for individual missiles
$HVknockback3[%new] = -1;				//kick for tracer rounds
$HVenVal1[%new] = 0;					//heat generated per round, FCC off
$HVenVal2[%new] = 0;					//heat generated per round, FCC on
$HVenergy1[%new] = 0;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = 0;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "MachineGun"; 			//weapon to subtract ammo from
$HVammocount1[%new] = 10;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 20; //10;			//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 2; //1;          			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "MachineGun";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData Ultra5Ammo
{
	description = "Ultra-AC5 Shells";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};
ItemImageData Ultra5Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; //1; Spinning, now Single Shot
	reloadTime = 0.16; //0.32;++++++++++++
	fireTime = 0.0;
	ammoType = Ultra5Ammo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.15;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundItemArm;
	sfxReady = SoundSensorPower; 
};
ItemData Ultra5
{
	description = "Ultra-AC5";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = Ultra5Image;
	price = 225;
	showWeaponBar = true;
};
function Ultra5::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Ultra-AC5\n-Very fast rate of fire  -Minimal heat buildup\n-Moderate damage  -Effective range: 225m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function Ultra5Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFiremortar";		//fire sound
$HVfiresound2[%new] = "SoundFiremortar";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 1;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "Ultra5Tracer";	    		//tracer projectile
$HVroundsBurst1[%new] = 4; //1:++++			//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 9; //1:++++			//rounds per missile per burst, FCC on
$HVsmart[%new] = "Ultra5Bullet";  			//normal fire, guided
$HVsmart2[%new] = "Ultra5Bullet";  			//FCC on, guided
$HVdumb[%new] = "Ultra5Bullet";    			//normal fire, dumb
$HVdumb2[%new] = "Ultra5Bullet";  			//FCC on, dumb
$HVdumb3[%new] = "Ultra5Bullet";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "Ultra5Bullet"; 	 		//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 1; //4;++++				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.04;            			//delay for bursts
$HVtime2[%new] = 0.02; //0.04;++++			//delay for individual missiles
$HVknockback1[%new] = 0; //-4;++++ 			//kick for bursts
$HVknockback2[%new] = -4; //-4;++++			//kick for individual missiles
$HVknockback3[%new] = -4; //-4;++++			//kick for tracer rounds
$HVenVal1[%new] = 5; //1.2;++++ 			//heat generated per round, FCC off
$HVenVal2[%new] = 10; //1.2;++++ 			//heat generated per round, FCC on
$HVenergy1[%new] = 4;			//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 8; //4;++++	//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "Ultra5";   				//weapon to subtract ammo from
$HVammocount1[%new] = 5;				//minimum ammo required for a full burst
$HVammocount2[%new] = 10;				//minimum ammo required for a full burst
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "Ultra5";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData Ultra10Ammo
{
	description = "Ultra-AC10 Shells";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};
ItemImageData Ultra10Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; //1; Spinning, now Single Shot
	reloadTime = 0.2; //0.4;++++++++++++++++
	fireTime = 0.0;
	ammoType = Ultra10Ammo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 0.2;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundItemArm;
	sfxReady = SoundSensorPower; 
};
ItemData Ultra10
{
	description = "Ultra-AC10";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = Ultra10Image;
	price = 300;
	showWeaponBar = true;
};
function Ultra10::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Ultra-AC10\nFast rate of fire  -Moderate heat buildup\n-Heavy damage  -Effective range: 150m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function Ultra10Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundmortarTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundmortarTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 1;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "Ultra10Tracer";	    		//tracer projectile
$HVroundsBurst1[%new] = 4;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 9;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "Ultra10Bullet";  			//normal fire, guided
$HVsmart2[%new] = "Ultra10Bullet";  		//FCC on, guided
$HVdumb[%new] = "Ultra10Bullet";   			//normal fire, dumb
$HVdumb2[%new] = "Ultra10Bullet"; 			//FCC on, dumb
$HVdumb3[%new] = "Ultra10Bullet";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "Ultra10Bullet";	  		//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.05;            			//delay for bursts
$HVtime2[%new] = 0.025;           			//delay for individual missiles
$HVknockback1[%new] = 0;       			//kick for bursts
$HVknockback2[%new] = -8;        			//kick for individual missiles
$HVknockback3[%new] = -8;				//kick for tracer rounds
$HVenVal1[%new] = 8.5;					//heat generated per round, FCC off
$HVenVal2[%new] = 17;					//heat generated per round, FCC on
$HVenergy1[%new] = 7;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 15;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "Ultra10";  				//weapon to subtract ammo from
$HVammocount1[%new] = 5;				//minimum ammo required for a full burst
$HVammocount2[%new] = 10;				//minimum ammo required for a full burst
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "Ultra10";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData Ultra20Ammo
{
	description = "Ultra-AC20 Shells";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 3;
};
ItemImageData Ultra20Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 0; //1; Spinning, now Single Shot
	reloadTime = 0.24; //0.48;+++++++++++++++
	fireTime = 0.0;
	ammoType = Ultra20Ammo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.2;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundItemArm;
	sfxReady = SoundSensorPower; //SoundUltraACTurn; use for other spinning weapon?++++ 
};
ItemData Ultra20
{
	description = "Ultra-AC20";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = Ultra20Image;
	price = 425;
	showWeaponBar = true;
};
function Ultra20::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Ultra-AC20\n-Very fast rate of fire  -High heat buildup\n-Extreme damage  -Effective range: 100m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function Ultra20Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "mineExpS";			//fire sound
$HVfiresound2[%new] = "mineExpS";			//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 1;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "Ultra20Tracer";	    		//tracer projectile
$HVroundsBurst1[%new] = 4;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 9;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "Ultra20Bullet";  			//normal fire, guided
$HVsmart2[%new] = "Ultra20Bullet";  		//FCC on, guided
$HVdumb[%new] = "Ultra20Bullet";   			//normal fire, dumb
$HVdumb2[%new] = "Ultra20Bullet"; 			//FCC on, dumb
$HVdumb3[%new] = "Ultra20Bullet";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "Ultra20Bullet";  		//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.06;            			//delay for bursts
$HVtime2[%new] = 0.03;           			//delay for individual missiles
$HVknockback1[%new] = 0;       			//kick for bursts
$HVknockback2[%new] = -16;        			//kick for individual missiles
$HVknockback3[%new] = -16;				//kick for tracer rounds
$HVenVal1[%new] = 12;					//heat generated per round, FCC off
$HVenVal2[%new] = 24;					//heat generated per round, FCC on
$HVenergy1[%new] = 10;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 20;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "Ultra20";  				//weapon to subtract ammo from
$HVammocount1[%new] = 5;				//minimum ammo required for a full burst
$HVammocount2[%new] = 10;				//minimum ammo required for a full burst
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "Ultra20";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData AC5Ammo
{
	description = "LBX-AC5 Clip";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};
ItemImageData AC5Image
{
	shapeFile = "energygun"; //"sniper";
	mountPoint = 0;
	weaponType = 0; 
	accuFire = true;
	reloadTime = 0.4; //0.8;++++++++
	fireTime = 0.0;
	ammoType = AC5Ammo;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 0.12;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundItemArm;
	sfxReady = SoundmortarIdle; 
	sfxReload = SoundDryFire; 
};
ItemData AC5
{
	description = "LBX-AC5";
	className = "Weapon";
	shapeFile = "energygun"; //"sniper";
	hudIcon = "chaingun";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = AC5Image;
	price = 175;
	showWeaponBar = true;
};
function AC5::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LBX-AC5\n-Fires six-round bursts  -Minimal heat buildup\n-Moderate damage  -Effective range: 250m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function AC5Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFiremortar";		//fire sound
$HVfiresound2[%new] = "SoundFiremortar";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 1;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "AC5Tracer";	    		//tracer projectile
$HVsmart[%new] = "AC5Bullet";  			//normal fire, guided
$HVsmart2[%new] = "AC5Bullet2";  			//FCC on, guided
$HVdumb[%new] = "AC5Bullet";   			//normal fire, dumb
$HVdumb2[%new] = "AC5Bullet2"; 			//FCC on, dumb
$HVdumb3[%new] = "AC5Bullet";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "AC5Bullet2";  	 		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 5;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 11;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;	   				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.045;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -4;       			//kick for bursts
$HVknockback2[%new] = -4;        			//kick for individual missiles
$HVknockback3[%new] = -4;				//kick for tracer rounds
$HVenVal1[%new] = 7.2;					//heat generated per round, FCC off
$HVenVal2[%new] = 14.4;					//heat generated per round, FCC on
$HVenergy1[%new] = 4;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = 4;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "AC5";  				//weapon to subtract ammo from
$HVammocount1[%new] = 6;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 12;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "AC5";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData AC10Ammo
{
	description = "LBX-AC10 Clip";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 3;
};
ItemImageData AC10Image
{
	shapeFile = "energygun";
	mountPoint = 0;
	weaponType = 0; //1; Spinning, now Single Shot
	accuFire = true;
	reloadTime = 0.475; //0.95;+++++++++
	fireTime = 0.01;
	ammoType = AC10Ammo;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.18;
	lightColor = { 0.75, 0.25, 0.65  };
	sfxActivate = SoundItemArm;
	sfxReady = SoundmortarIdle; 
	sfxReload = SoundDryFire;
};
ItemData AC10
{
	description = "LBX-AC10";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "chaingun";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = AC10Image;
	price = 250;
	showWeaponBar = true;
};
function AC10::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LBX-AC10\n-Fires five-round bursts  -Minimal heat buildup\n-Heavy damage  -Effective range: 175m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function AC10Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundmortarTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundmortarTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 1;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "AC10Tracer";	    		//tracer projectile
$HVsmart[%new] = "AC10Bullet";  			//normal fire, guided
$HVsmart2[%new] = "AC10Bullet2";  			//FCC on, guided
$HVdumb[%new] = "AC10Bullet";   			//normal fire, dumb
$HVdumb2[%new] = "AC10Bullet2"; 			//FCC on, dumb
$HVdumb3[%new] = "AC10Bullet";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "AC10Bullet2";  	 		//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVroundsBurst1[%new] = 4;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 9;				//rounds per missile per burst, FCC on
$HVtime1[%new] = 0.045;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -8;       			//kick for bursts
$HVknockback2[%new] = -8;        			//kick for individual missiles
$HVknockback3[%new] = -8;				//kick for tracer rounds
$HVenVal1[%new] = 12;					//heat generated per round, FCC off
$HVenVal2[%new] = 24;					//heat generated per round, FCC on
$HVenergy1[%new] = 4;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 4;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "AC10";  				//weapon to subtract ammo from
$HVammocount1[%new] = 5;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 10;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "AC10";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData AC20Ammo
{
	description = "LBX-AC20 Clip";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 4;
};
ItemImageData AC20Image
{
	shapeFile = "energygun";
	mountPoint = 0;
	weaponType = 0; //1; Spinning, now Single Shot
	accuFire = true;
	reloadTime = 0.55; //1.1;++++++++++++
	fireTime = 0.01;
	ammoType = AC20Ammo;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 0.25;
	lightColor = { 0.75, 0.25, 0.65  };
	sfxActivate = SoundItemArm;
	sfxReady = SoundmortarIdle; 
	sfxReload = SoundDryFire; 
};
ItemData AC20
{
	description = "LBX-AC20";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "chaingun";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = AC20Image;
	price = 375;
	showWeaponBar = true;
};
function AC20::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LBX-AC20\n-Fires four-round bursts  -Moderate heat buildup\n-Extreme damage  -Effective range: 125m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function AC20Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "mineExpS";			//fire sound
$HVfiresound2[%new] = "mineExpS";			//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 1;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "AC20Tracer";	    		//tracer projectile
$HVsmart[%new] = "AC20Bullet";  			//normal fire, guided
$HVsmart2[%new] = "AC20Bullet2";  			//FCC on, guided
$HVdumb[%new] = "AC20Bullet";   			//normal fire, dumb
$HVdumb2[%new] = "AC20Bullet2"; 			//FCC on, dumb
$HVdumb3[%new] = "AC20Bullet";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "AC20Bullet2";  	 		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 3;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 7;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.045;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -16;       			//kick for bursts
$HVknockback2[%new] = -16;        			//kick for individual missiles
$HVknockback3[%new] = -16;				//kick for tracer rounds
$HVenVal1[%new] = 19.2;					//heat generated per round, FCC off
$HVenVal2[%new] = 38.2;					//heat generated per round, FCC on
$HVenergy1[%new] = 4;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 4;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "AC20";  				//weapon to subtract ammo from
$HVammocount1[%new] = 4;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 8;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "AC20";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData HVAC10Ammo
{
	description = "HV-AC10 Clip";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 4;
};
ItemImageData HVAC10Image
{
	shapeFile = "sniper";//"energygun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
	mountRotation = { 0, 3.214, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.00;
	ammoType = HVAC10Ammo;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 0.25;
	lightColor = { 0.75, 0.25, 0.65  };
	sfxActivate = SoundItemArm;
	sfxReady = SoundmortarIdle; 
	sfxReload = SoundDryFire; 
};
ItemData HVAC10
{
	description = "HV-AC10";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chaingun";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = HVAC10Image;
	price = 350;
	showWeaponBar = true;
};
ItemImageData HVACGunImage
 { 
shapeFile = "energygun"; 
mountPoint = 0; 
mountOffset = {0, -0.25, 0};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0, 3.214, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
}; 
ItemData HVACGun
{ 
description = "HV-AC10"; 
shapeFile = "energygun"; 
heading = "gAttachments"; 
shadowDetailMask = 4; 
imageType = HVACGunImage; 
price = 1;
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = false; 
showInventory = false; 
};
function HVAC10::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using HV-AC10\n-Fires one and two-round bursts  -Moderate heat buildup\n-Moderate to Heavy damage  -Effective range: 300m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
	Player::setItemCount(%player, HVACGun,1);
//	Player::mountItem(%player, HVACGun, MachineGun2Slot); //10++++
}
function HVAC10::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,HVACGun,$MachineGun2Slot);
} 
function HVAC10::onUnmount(%player,%imageSlot) 
{ 
Player::unmountItem(%player,$MachineGun2Slot);
} 
function HVAC10Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "bigExplosion4";		//fire sound
$HVfiresound2[%new] = "bigExplosion4";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "HVAC10Bullet";	    		//tracer projectile
$HVsmart[%new] = "HVAC10Bullet";  			//normal fire, guided
$HVsmart2[%new] = "HVAC10Bullet2";  			//FCC on, guided
$HVdumb[%new] = "HVAC10Bullet";   			//normal fire, dumb
$HVdumb2[%new] = "HVAC10Bullet2"; 			//FCC on, dumb
$HVdumb3[%new] = "HVAC10Bullet";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "HVAC10Bullet2";  	 		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 2;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.125;            			//delay for bursts
$HVtime2[%new] = 0.125;           			//delay for individual missiles
$HVknockback1[%new] = -40;       			//kick for bursts
$HVknockback2[%new] = -40;        			//kick for individual missiles
$HVknockback3[%new] = -40;				//kick for tracer rounds
$HVenVal1[%new] = 7.2;					//heat generated per round, FCC off
$HVenVal2[%new] = 14.4;					//heat generated per round, FCC on
$HVenergy1[%new] = 5;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 10;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "HVAC10";  				//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 2;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "HVAC10";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//----------------------------------------------------------------------------
ItemData SniperGunAmmo
{
	description = "Light Gauss Rifle Slug"; //"Sniper Cannon Bullet";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 4;
};
ItemImageData SniperCannonImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = SniperGunAmmo;
	accuFire = true;
	reloadTime = 2; //2.5;+++++
	fireTime = 0.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 0.5;
	lightColor = { 1, 0, 0 };
	sfxReady = SoundmortarIdle;
//	sfxReady = SoundFloatMineLoop;//++++
	sfxActivate = SoundItemArm;
	sfxReload = SniperReload; //SoundDryFire;//++++++
};
ItemData SniperCannon
{
	description = "Light Gauss Rifle"; //"Sniper Cannon";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = SniperCannonImage;
	price = 350;
	showWeaponBar = true;
};
function SniperCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Light Gauss Rifle\n-Slow rate of fire  -Little heat buildup\n-Heavy damage  -Extremely long range: over 2000m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function SniperCannonImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "turretExplosion"; //"bigExplosion4";		//fire sound
$HVfiresound2[%new] = "turretExplosion"; //"bigExplosion4";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 2000;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "SniperGunShell"; 		//tracer projectile
$HVsmart[%new] = "SniperGunShell"; 			//normal fire, guided
$HVsmart2[%new] = "SniperGunShell2";  		//FCC on, guided
$HVdumb[%new] = "SniperGunShell";   		//normal fire, dumb
$HVdumb2[%new] = "SniperGunShell2"; 		//FCC on, dumb
$HVdumb3[%new] = "SniperGunShell";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "SniperGunShell2";  		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 3;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.25;            			//delay for bursts
$HVtime2[%new] = 0.25;           			//delay for individual missiles
$HVknockback1[%new] = -50;       			//kick for bursts
$HVknockback2[%new] = -50;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 18;					//heat generated per round, FCC off
$HVenVal2[%new] = 42;					//heat generated per round, FCC on
$HVenergy1[%new] = -15; //0;++++			//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = -15;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "SniperCannon";  			//weapon to subtract ammo from
$HVammocount1 = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 3;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "SniperCannon";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//----------------------------------------------------------------------------
ItemData GaussGunAmmo
{
	description = "Gauss Rifle Slug";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData GaussRifleImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = GaussGunAmmo;
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 0.5;
	sfxActivate = SoundItemArm;
	sfxReload = SoundTurretDeploy; 
	sfxReady = SoundFloatMineLoop;
};
ItemData GaussRifle
{
	description = "Gauss Rifle";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = GaussRifleImage;
	price = 400;
	showWeaponBar = true;
};
function GaussRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Gauss Rifle\n-Very slow rate of fire  -No heat buildup \nExtreme damage  -Extremely long range: over 2000m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function GaussRifleImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "turretExplosion";		//fire sound
$HVfiresound2[%new] = "turretExplosion";		//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GaussGunShell";	    		//tracer projectile
$HVsmart[%new] = "GaussGunShell";  			//normal fire, guided
$HVsmart2[%new] = "GaussGunShell3";  		//FCC on, guided
$HVdumb[%new] = "GaussGunShell";   			//normal fire, dumb
$HVdumb2[%new] = "GaussGunShell3"; 			//FCC on, dumb
$HVdumb3[%new] = "GaussGunShell";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "GaussGunShell3";  		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1; //9;			//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -50;       			//kick for bursts
$HVknockback2[%new] = 0;        			//kick for individual missiles
$HVknockback3[%new] = 0; //-50;			//kick for tracer rounds
$HVenVal1[%new] = 0;					//heat generated per round, FCC off
$HVenVal2[%new] = 0;					//heat generated per round, FCC on
$HVenergy1[%new] = 0;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 0;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "GaussRifle";  			//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "GaussRifle";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData GJAmmo
{
	description = "Gyrojet Shell";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData GJImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
	mountRotation = { 0, 3.214, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.00;
	ammoType = GJAmmo;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.25;
	lightColor = { 0.75, 0.85, 0.95  };
	sfxActivate = SoundItemArm;
	sfxReady = SoundSensorPower; 
	sfxReload = SoundDryFire; 
};
ItemData GJ
{
	description = "Gyrojet Cannon";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = GJImage;
	price = 365;
	showWeaponBar = true;
};
function GJ::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Gyrojet Cannon\n-Fast rate of fire  -Minimal heat buildup\n-Moderate damage  -Effective range: 300m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function GJImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundmortarTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundmortarTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 300;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GJBullet";	  	  		//tracer projectile
$HVsmart[%new] = "GJBullet";  			//normal fire, guided
$HVsmart2[%new] = "GJBullet2";  			//FCC on, guided
$HVdumb[%new] = "GJBullet";   			//normal fire, dumb
$HVdumb2[%new] = "GJBullet2"; 			//FCC on, dumb
$HVdumb3[%new] = "GJBullet";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "GJBullet2";  	 		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.125;            			//delay for bursts
$HVtime2[%new] = 0.125;           			//delay for individual missiles
$HVknockback1[%new] = -20;       			//kick for bursts
$HVknockback2[%new] = -20;        			//kick for individual missiles
$HVknockback3[%new] = -20;				//kick for tracer rounds
$HVenVal1[%new] = 6;					//heat generated per round, FCC off
$HVenVal2[%new] = 6;					//heat generated per round, FCC on
$HVenergy1[%new] = 4;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 4;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "GJ";  				//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "GJ"; 				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//----------------------------------------------------------------------------
ItemData ThumperGunAmmo
{
	description = "Thumper Shell";
	className = "Ammo";
	shapeFile = "mortarammo";//+++??????????
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 8;
};
ItemImageData ThumperGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
mountOffset = {0, 0, 0}; 
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0, 3.1, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0;
	ammoType = ThumperGunAmmo;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 10;
	lightTime = 0.25;
	lightColor = { 0.6, 1, 1  };
	reloadTime = 1.2;
	fireTime = 0;
	sfxActivate = SoundItemArm;
	sfxReload = SoundTurretDeploy; 
	sfxReady = SoundFloatMineLoop;
};
ItemData ThumperGun
{
	description = "Thumper";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = ThumperGunImage;
	price = 600;
	showWeaponBar = true;
};
ItemImageData ThumperGunImage2
{
	shapeFile = "grenadeL";
	mountPoint = 0;
mountOffset = {0, 0.45, -0.1}; 
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0, 3.1, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0;
	ammoType = ThumperGunAmmo;
	accuFire = true;
	reloadTime = 1.2;
	fireTime = 0;
	sfxActivate = SoundItemArm;
	sfxReload = SoundTurretDeploy; 
	sfxReady = SoundFloatMineLoop;
};
ItemData ThumperGun2
{
	description = "Thumper";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bBallistic Weapons";
	shadowDetailMask = 4;
	imageType = ThumperGunImage2;
	price = 600;
	showWeaponBar = true;
};
function ThumperGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Thumper\n-Fast rate of fire  -High heat buildup \nModerate damage  -Long range: over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
//function ThumperGun::onMount(%player,%imageSlot)
//{
//	Player::mountItem(%player,ThumperGun2,$LMechMortar1Slot);
//} 
//function ThumperGun::onUnmount(%player,%imageSlot) 
//{ 
//Player::unmountItem(%player,$LMechMortar1Slot);
//} 
}
function ThumperGunImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundPlasmaTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundPlasmaTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "FlakShell";	    		//tracer projectile
$HVsmart[%new] = "FlakShell";  			//normal fire, guided
$HVsmart2[%new] = "FlakShell";  			//FCC on, guided
$HVdumb[%new] = "FlakShell";   			//normal fire, dumb
$HVdumb2[%new] = "FlakShell"; 			//FCC on, dumb
$HVdumb3[%new] = "FlakShell";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "FlakShell";  			//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 2; 				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.6;            			//delay for bursts
$HVtime2[%new] = 0.6;           			//delay for individual missiles
$HVknockback1[%new] = -50;       			//kick for bursts
$HVknockback2[%new] = -50;        			//kick for individual missiles
$HVknockback3[%new] = 0; 				//kick for tracer rounds
$HVenVal1[%new] = 20;					//heat generated per round, FCC off
$HVenVal2[%new] = 40;					//heat generated per round, FCC on
$HVenergy1[%new] = 5;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 5;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "ThumperGun";  			//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 2;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "ThumperGun";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData STRAmmo
{
	description = "Streak Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData STR2Image
{
	shapeFile = "ammo2";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = STRAmmo;
//	projectileType = STR2Rocket;
	accuFire = false;
	reloadTime = 1.5;
	fireTime = 0.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxActivate = SoundItemArm;
	sfxReload = SoundmortarReload;
	sfxReady = SoundShieldOn;
};

ItemData STR2
{
	description = "Streak SRM-2";
	className = "Weapon";
	shapeFile = "ammo2";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = STR2Image;
	price = 150;
	showWeaponBar = true;
};

function STR2::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Streak SRM-2\n-Fires two-missile salvos  -Minimal heat buildup\n-Moderate damage per missile, with a small blast radius  -Effective range: 175m", 5);
	Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function STR2Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundMissileTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundMissileTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire
$HVLOSrange[%new] = 300;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GaussGunShell";    		//tracer projectile
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "STR2Missile";  			//normal fire, guided
$HVsmart2[%new] = "STR2Missile2";  			//alt-fire, guided
$HVdumb[%new] = "STR2Rocket";    			//normal fire, dumb
$HVdumb2[%new] = "STR2Rocket2";  			//alt-fire, dumb
$HVdumb3[%new] = "STR2Rocket";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "STR2Rocket2";  			//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 2;    				//number of missiles per burst
$HVtime1[%new] = 0.15;            			//delay for bursts
$HVtime2[%new] = 0.075;           			//delay for individual missiles
$HVknockback1[%new] = -12;       			//kick for bursts
$HVknockback2[%new] = -6;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 18.0;					//heat generated by volley, FCC off
$HVenVal2[%new] = 18.0;					//heat generated by volley, FCC on
$HVenergy1[%new] = 0;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 0;						//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "STR2";	     			//weapon to subtract ammo from
$HVammocount1[%new] = 2;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 2;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 2;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "Streak";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData STR4Image
{
	shapeFile = "ammo2";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = STRAmmo;
//	projectileType = STR2Missile;
	accuFire = false;
	reloadTime = 2.25;
	fireTime = 0.01;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxActivate = SoundItemArm;
	sfxReload = SoundmortarReload;
	sfxReady = SoundShieldOn;
};

ItemData STR4
{
	description = "Streak SRM-4";
	className = "Weapon";
	shapeFile = "ammo2";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = STR4Image;
	price = 200;
	showWeaponBar = true;
};

function STR4::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Streak SRM-4\n-Fires four-missile salvos  -Minimal heat buildup\n-Moderate damage per missile, with a small blast radius  -Effective range: 175m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function STR4Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundMissileTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundMissileTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire
$HVLOSrange[%new] = 300;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GaussGunShell";    		//tracer projectile
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "STR2Missile";  			//normal fire, guided
$HVsmart2[%new] = "STR2Missile2";  			//alt-fire, guided
$HVdumb[%new] = "STR2Rocket";    			//normal fire, dumb
$HVdumb2[%new] = "STR2Rocket2";  			//alt-fire, dumb
$HVdumb3[%new] = "STR2Rocket";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "STR2Rocket2";  			//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 2;    				//number of bursts
$HVrounds[%new] = 2;    				//number of missiles per burst
$HVtime1[%new] = 0.2;            			//delay for bursts
$HVtime2[%new] = 0.075;           			//delay for individual missiles
$HVknockback1[%new] = -24;       			//kick for bursts
$HVknockback2[%new] = -6;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 18.0;					//heat generated by volley, FCC off
$HVenVal2[%new] = 18.0;					//heat generated by volley, FCC on
$HVenergy1[%new] = 5;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 5;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "STR4";	     			//weapon to subtract ammo from
$HVammocount1[%new] = 4;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 4;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 2;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "Streak";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData STR6Image
{
	shapeFile = "ammo2";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = STRAmmo;
//	projectileType = STR2Missile;
	accuFire = false;
	reloadTime = 3.0; //4.0;++++++++++++++
	fireTime = 0.01;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxActivate = SoundItemArm;
	sfxReload = SoundmortarReload;
	sfxReady = SoundShieldOn;
};

ItemData STR6
{
	description = "Streak SRM-6";
	className = "Weapon";
	shapeFile = "ammo2";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = STR6Image;
	price = 250;
	showWeaponBar = true;
};

function STR6::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Streak SRM-6\n-Fires six-missile salvos  -Minimal heat buildup\n-Moderate damage per missile, with a small blast radius  -Effective range: 175m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function STR6Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundMissileTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundMissileTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire
$HVLOSrange[%new] = 300;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GaussGunShell";    		//tracer projectile
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "STR2Missile";  			//normal fire, guided
$HVsmart2[%new] = "STR2Missile2";  			//alt-fire, guided
$HVdumb[%new] = "STR2Rocket";    			//normal fire, dumb
$HVdumb2[%new] = "STR2Rocket2";  			//alt-fire, dumb
$HVdumb3[%new] = "STR2Rocket";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "STR2Rocket2";  			//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 3;    				//number of bursts
$HVrounds[%new] = 2;    				//number of missiles per burst
$HVtime1[%new] = 0.2;            			//delay for bursts
$HVtime2[%new] = 0.075;           			//delay for individual missiles
$HVknockback1[%new] = -36;       			//kick for bursts
$HVknockback2[%new] = -6;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 18.0;					//heat generated by volley, FCC off
$HVenVal2[%new] = 18.0;					//heat generated by volley, FCC on
$HVenergy1[%new] = 10;						//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 10;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "STR6";	     			//weapon to subtract ammo from
$HVammocount1[%new] = 6;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 6;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 2;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "Streak";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData LRMAmmo
{
	description = "LRM Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData LRM5Image
{
	shapeFile = "ammo1";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = LRMAmmo;
	accuFire = false;
	reloadTime = 2.0;
	fireTime = 0.01;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundItemArm;
	sfxReload = SoundmortarReload;
	sfxReady = SoundShieldOn; //SoundDoubleHeatSinkOn;
};
ItemData LRM5
{
	description = "LRM-5 Missile Rack";
	className = "Weapon";
	shapeFile = "ammo1";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = LRM5Image;
	price = 150;
	showWeaponBar = true;
};
function LRM5::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LRM-5 Missile Rack\n-Fires five-missile salvos  -Minimal heat buildup\n-Minimal damage per missile, with blast radius  -Effective range: 425m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function LRM5Image::onFire(%player, %slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundMissileTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundMissileTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GaussGunShell";    		//tracer projectile
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "LRM5Missile";    			//normal fire, guided
$HVsmart2[%new] = "LRM5Missile2";    		//alt-fire, guided
$HVdumb[%new] = "LRM5Rocket";    			//normal fire, dumb
$HVdumb2[%new] = "LRM5Rocket";  			//alt-fire, dumb
$HVdumb3[%new] = "LRM5Rocket";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "LRM5Rocket";  			//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 5;    				//number of missiles per burst
$HVtime1[%new] = 0.4;            			//delay for bursts
$HVtime2[%new] = 0.075;           			//delay for individual missiles
$HVknockback1[%new] = -15;       			//kick for bursts
$HVknockback2[%new] = -8;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 24.0;					//heat generated by volley, FCC off
$HVenVal2[%new] = 24.0;					//heat generated by volley, FCC on
$HVenergy1[%new] = 5;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 5;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "LRM5";          			//weapon to subtract ammo from
$HVammocount1[%new] = 5;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 5;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 5;             			//ammo reduction for bursts
$HVammoD2[%new] = 5;             			//ammo reduction for individual missiles
$HVwarning[%new] = "LRM";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LRM10Image
{
	shapeFile = "ammo1";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = LRMAmmo;
	accuFire = false;
	reloadTime = 3.0; //4.0;++++++++
	fireTime = 0.01;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundItemArm;
	sfxReload = SoundmortarReload;
	sfxReady = SoundShieldOn;
};
ItemData LRM10
{
	description = "LRM-10 Missile Rack";
	className = "Weapon";
	shapeFile = "ammo1";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = LRM10Image;
	price = 200;
	showWeaponBar = true;
};
function LRM10::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LRM-10 Missile Rack\n-Fires ten-missile salvos  -Moderate heat buildup\n-Minimal damage per missile, with blast radius  -Effective range: 425m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function LRM10Image::onFire(%player, %slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundMissileTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundMissileTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GaussGunShell";    		//tracer projectile
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "LRM5Missile";    			//normal fire, guided
$HVsmart2[%new] = "LRM5Missile2";    		//alt-fire, guided
$HVdumb[%new] = "LRM5Rocket";    			//normal fire, dumb
$HVdumb2[%new] = "LRM5Rocket";  			//alt-fire, dumb
$HVdumb3[%new] = "LRM5Rocket";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "LRM5Rocket";  			//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 2;    				//number of bursts
$HVrounds[%new] = 5;    				//number of missiles per burst
$HVtime1[%new] = 0.4;            			//delay for bursts
$HVtime2[%new] = 0.075;           			//delay for individual missiles
$HVknockback1[%new] = -20;       			//kick for bursts
$HVknockback2[%new] = -8;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 24.0;						//heat generated by volley, FCC off
$HVenVal2[%new] = 24.0;					//heat generated by volley, FCC on
$HVenergy1[%new] = 10;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 10;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "LRM10";          			//weapon to subtract ammo from
$HVammocount1[%new] = 10;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 10;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 5;             			//ammo reduction for bursts
$HVammoD2[%new] = 5;             			//ammo reduction for individual missiles
$HVwarning[%new] = "LRM";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LRM20Image
{
	shapeFile = "ammo1";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = LRMAmmo;
	accuFire = false;
	reloadTime = 4.0; //6.0;+++++++
	fireTime = 0.01;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundItemArm;
	sfxReload = SoundmortarReload;
	sfxReady = SoundShieldOn;
};
ItemData LRM20
{
	description = "LRM-15 Missile Rack";
	className = "Weapon";
	shapeFile = "ammo1";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = LRM20Image;
	price = 275;
	showWeaponBar = true;
};
function LRM20::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LRM-15 Missile Rack\n-Fires fifteen-missile salvos  -High heat buildup\n-Minimal damage per missile, with blast radius  -Effective range: 425m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function LRM20Image::onFire(%player, %slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundMissileTurretFire";	//fire sound
$HVfiresound2[%new] = "SoundMissileTurretFire";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GaussGunShell";    		//tracer projectile
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "LRM5Missile";    			//normal fire, guided
$HVsmart2[%new] = "LRM5Missile2";    		//alt-fire, guided
$HVdumb[%new] = "LRM5Rocket";    			//normal fire, dumb
$HVdumb2[%new] = "LRM5Rocket";  			//alt-fire, dumb
$HVdumb3[%new] = "LRM5Rocket";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "LRM5Rocket";  			//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 3;    				//number of bursts
$HVrounds[%new] = 5;    				//number of missiles per burst
$HVtime1[%new] = 0.4;            			//delay for bursts
$HVtime2[%new] = 0.075;           			//delay for individual missiles
$HVknockback1[%new] = -25;       			//kick for bursts
$HVknockback2[%new] = -8;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 24.0;					//heat generated by volley, FCC off
$HVenVal2[%new] = 24.0;					//heat generated by volley, FCC on
$HVenergy1[%new] = 15;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 15;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "LRM20";          			//weapon to subtract ammo from
$HVammocount1[%new] = 15;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 15;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 5;             			//ammo reduction for bursts
$HVammoD2[%new] = 5;             			//ammo reduction for individual missiles
$HVwarning[%new] = "LRM";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData Thunderbolt5Ammo
{
	description = "Lt. Thunderbolt Missile";
	className = "Ammo";
	shapeFile = "rocket";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 7;
};
ItemImageData Thunderbolt5Image
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
	mountRotation = { 0, 1.6, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; 
	ammoType = Thunderbolt5Ammo;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.0;
	sfxActivate = SoundItemArm; //SoundTeleportIdle;
	sfxReload = SoundActivatePDA;
	sfxReady = SoundShieldOn;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.75;
	lightColor = { 1.0, 0.7, 0.5 };
};
ItemData Thunderbolt5
{
	description = "Light Thunderbolt";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = Thunderbolt5Image;
	price = 285;
	showWeaponBar = true;
};
function Thunderbolt5::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Light Thunderbolt\n-Slow rate of fire  -Low heat buildup\n-Moderate damage, with large blast radius  -Long range: over 1000m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wSensor_Deploy.wav");
}
function Thunderbolt5::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,ThunderLRMMissile,$MachineGun2Slot);
} 
function Thunderbolt5::onUnmount(%player,%imageSlot) 
{ 
Player::unmountItem(%player,$MachineGun2Slot);
}
function Thunderbolt5Image::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFireFlierRocket";	//fire sound
$HVfiresound2[%new] = "SoundFireFlierRocket";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 1100;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "Thunderbolt5Rocket"; 		//tracer projectile
$HVsmart[%new] = "Thunderbolt5Missile"; 		//normal fire, guided
$HVsmart2[%new] = "Thunderbolt5Missile2";  	//FCC on, guided
$HVdumb[%new] = "Thunderbolt5Rocket";   		//normal fire, dumb
$HVdumb2[%new] = "Thunderbolt5Rocket2"; 		//FCC on, dumb
$HVdumb3[%new] = "Thunderbolt5Rocket";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "Thunderbolt5Rocket2";  		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -20;       			//kick for bursts
$HVknockback2[%new] = -20;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 20.4;					//heat generated per round, FCC off
$HVenVal2[%new] = 20.4;					//heat generated per round, FCC on
$HVenergy1[%new] = 0;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 0;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "Thunderbolt5";  			//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "Thunderbolt5";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData ThunderboltAmmo
{
	description = "Thunderbolt Missile";
	className = "Ammo";
	shapeFile = "rocket";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};
ItemImageData ThunderboltImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
	mountRotation = { 0, 1.6, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; 
	ammoType = ThunderboltAmmo;
	accuFire = true;
	reloadTime = 3.0; //2.5;++++
	fireTime = 0.0;
	sfxActivate = SoundItemArm; //SoundTeleportIdle;
	sfxReload = SoundActivatePDA;
	sfxReady = SoundShieldOn;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.75;
	lightColor = { 1.0, 0.7, 0.5 };
};
ItemData Thunderbolt
{
	description = "Thunderbolt";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = ThunderboltImage;
	price = 385;
	showWeaponBar = true;
};
function Thunderbolt::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Thunderbolt\n-Slow rate of fire  -Low heat buildup\n-Moderate damage, with large blast radius  -Long range: over 1000m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wSensor_Deploy.wav");
}
function Thunderbolt::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,ThunderLRMMissile,$MachineGun2Slot);
} 
function Thunderbolt::onUnmount(%player,%imageSlot) 
{ 
Player::unmountItem(%player,$MachineGun2Slot);
}
function ThunderboltImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFireFlierRocket";	//fire sound
$HVfiresound2[%new] = "SoundFireFlierRocket";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 1100;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "ThunderboltRocket"; 		//tracer projectile
$HVsmart[%new] = "ThunderboltMissile"; 		//normal fire, guided
$HVsmart2[%new] = "ThunderboltMissile2";  	//FCC on, guided
$HVdumb[%new] = "ThunderboltRocket";   		//normal fire, dumb
$HVdumb2[%new] = "ThunderboltRocket2"; 		//FCC on, dumb
$HVdumb3[%new] = "ThunderboltRocket";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "ThunderboltRocket2";  		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -30;       			//kick for bursts
$HVknockback2[%new] = -30;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 20.4;					//heat generated per round, FCC off
$HVenVal2[%new] = 20.4;					//heat generated per round, FCC on
$HVenergy1[%new] = 0;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 0;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "Thunderbolt";  			//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "Thunderbolt";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//----------------------------------------------------------------------------
ItemData ArrowIVAmmo
{
	description = "ArrowIV Missile";
	className = "Ammo";
	shapeFile = "rocket";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};
ItemImageData ArrowIVImage
{
	shapeFile = "rocket";
	mountPoint = 0;
	weaponType = 0; 
	ammoType = ArrowIVAmmo;
	accuFire = true;
	reloadTime = 4.5;
	fireTime = 0.0;
	sfxActivate = SoundItemArm; //SoundTeleportIdle;
	sfxReload = SoundActivatePDA;
	sfxReady = SoundShieldOn;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.75;
	lightColor = { 1.0, 0.7, 0.5 };
};
ItemData ArrowIV
{
	description = "ArrowIV";
	className = "Weapon";
	shapeFile = "rocket";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = ArrowIVImage;
	price = 450;
	showWeaponBar = true;
};
function ArrowIV::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == FCCPod)
		Weapon::onUse(%player,%item);
	else
	Client::sendMessage(Player::getClient(%player),1,"-You must have a 'Fire-Control Computer' to control the ArrowIV-~wC_BuySell.wav"); 
	bottomprint(Player::getClient(%player), "<jc><f2>Using ArrowIV\n-Extremely slow rate of fire  -Moderate heat buildup\n-Extreme damage, with large blast radius  -Extremely long range: over 2000m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wSensor_Deploy.wav");
}
function ArrowIVImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFireFlierRocket";	//fire sound
$HVfiresound2[%new] = "SoundFireFlierRocket";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 1;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 1100;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "ArrowIVRocket"; 			//tracer projectile
$HVsmart[%new] = "ArrowIVMissile"; 			//normal fire, guided
$HVsmart2[%new] = "ArrowIVMissile2";  		//FCC on, guided
$HVdumb[%new] = "ArrowIVRocket";   			//normal fire, dumb
$HVdumb2[%new] = "ArrowIVRocket2"; 			//FCC on, dumb
$HVdumb3[%new] = "ArrowIVRocket"; //"F1aker1"; 	//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "ArrowIVRocket2"; //"F1aker2";	//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -50;       			//kick for bursts
$HVknockback2[%new] = -50;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 30;					//heat generated per round, FCC off
$HVenVal2[%new] = 30;					//heat generated per round, FCC on
$HVenergy1[%new] = 0;					//HVenVal1 + HVenergy1 = minimum energy to fire, FCC off
$HVenergy2[%new] = 0;					//HVenVal2 + HVenergy2 = minimum energy to fire, FCC on
$HVammoT[%new] = "ArrowIV";  				//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "ArrowIV";				//warning type recieved by target
$F1aky = %player;
$F1aky2 = GameBase::getPosition(%player);
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData ThunderLRMAmmo
{
	description = "Thunder LRM Rocket";
	className = "Ammo";
	shapeFile = "rocket";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 15;
};
ItemImageData ThunderLRMImage
{
	shapeFile = "mortar";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
	mountRotation = { 0, 1.6, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; 
	ammoType = ThunderLRMAmmo;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0.0;
	sfxActivate = SoundItemArm;
	sfxReload = SoundActivatePDA;
	sfxReady = SoundShieldOn;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.75;
	lightColor = { 1.0, 0.7, 0.5 };
};
ItemData ThunderLRM
{
	description = "Thunder LRM";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "blaster";
   heading = "dMissile Weapons";
	shadowDetailMask = 4;
	imageType = ThunderLRMImage;
	price = 275;
	showWeaponBar = true;
};
ItemImageData ThunderLRMMissileImage
{
	shapeFile = "rocket";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
	mountRotation = { 0, 1.6, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; 
	ammoType = ThunderLRMAmmo;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0.0;
	sfxActivate = SoundItemArm; //SoundTeleportIdle;
	sfxReload = SoundActivatePDA;
	sfxReady = SoundShieldOn;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.75;
	lightColor = { 1.0, 0.7, 0.5 };
};
ItemData ThunderLRMMissile
{
	description = "Thunder LRM";
	className = "Weapon";
	shapeFile = "rocket";
	hudIcon = "blaster";
   heading = "dMissile Systems";
	shadowDetailMask = 4;
	imageType = ThunderLRMMissileImage;
	price = 1;
	showWeaponBar = true;
};
function ThunderLRM::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Thunder LRM\n-Slow rate of fire  -Low heat buildup \n-Deploys Mines or fires cluster rounds  -Effective range: 250m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function ThunderLRM::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,ThunderLRMMissile,$MachineGun2Slot);
} 
function ThunderLRM::onUnmount(%player,%imageSlot) 
{ 
Player::unmountItem(%player,$MachineGun2Slot);
}
function ThunderLRMImage::onFire(%player, %slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFireFlierRocket";	//fire sound
$HVfiresound2[%new] = "SoundFireFlierRocket";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire
$HVLOSrange[%new] = 600;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "GaussGunShell";    		//tracer projectile
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVsmart[%new] = "ThunderLRMRocket";  		//normal fire, guided
$HVsmart2[%new] = "ThunderLRMRocket2";  		//alt-fire, guided
$HVdumb[%new] = "ThunderLRMRocket";    		//normal fire, dumb
$HVdumb2[%new] = "ThunderLRMRocket2";  		//alt-fire, dumb
$HVdumb3[%new] = "ThunderLRMRocket";  		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "ThunderLRMRocket2"; 		//pointed at sky, alt-fire, dumb
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.4;            			//delay for bursts
$HVtime2[%new] = 0.075;           			//delay for individual missiles
$HVknockback1[%new] = -20;       			//kick for bursts
$HVknockback2[%new] = -20;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 18.0;					//heat generated by volley, FCC off
$HVenVal2[%new] = 18.0;					//heat generated by volley, FCC on
$HVenergy1[%new] = 5;					//minimum heat# allowable by volley, FCC off
$HVenergy2[%new] = 5;					//minimum heat# allowable by volley, FCC on
$HVammoT[%new] = "ThunderLRM";     			//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles
$HVwarning[%new] = "Thunder LRM";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
$HVteam = GameBase::getTeam(%player);//++++++++++++++++++
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData MedLasImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 1.2; //1.5;++++++++++++
	fireTime = 0.0;
	minEnergy = 20;
	maxEnergy = 17;
	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundItemArm;
};
ItemData MedLas
{
	description = "Medium ER Laser";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
   heading = "cEnergy Weapons";
	shadowDetailMask = 4;
	imageType = MedLasImage;
	price = 100;
	showWeaponBar = true;
};
function MedLas::onUse(%player,%item)//++++++++++++++++++++++++++++++
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Medium ER Laser\n-Fast rate of fire  -Moderate heat buildup\n-Moderate damage  -Long range: over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function MedLasImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFireLaser";		//fire sound
$HVfiresound2[%new] = "SoundFireLaser";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 2000;				//range of LOS feedback
$HVtracerToggle[%new] = 1;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "MedLaser";		 		//tracer projectile
$HVsmart[%new] = "MedLaserShell"; 			//normal fire, guided
$HVsmart2[%new] = "MedLaserShell";  		//FCC on, guided
$HVdumb[%new] = "MedLaserShell";   			//normal fire, dumb
$HVdumb2[%new] = "MedLaserShell"; 			//FCC on, dumb
$HVdumb3[%new] = "MedLaserShell";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "MedLaserShell";  			//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = 0;       			//kick for bursts
$HVknockback2[%new] = 0;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 20.4;					//heat generated per round, FCC off
$HVenVal2[%new] = 20.4;					//heat generated per round, FCC on
$HVenergy1[%new] = -5;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = -5;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "MedLas";  				//weapon to subtract ammo from
$HVammocount1[%new] = 0;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 0;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 0;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 0;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "MedLas";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LrgLasImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 2.0; //3.0;+++++++
	fireTime = 0.0;
	minEnergy = 15;
	maxEnergy = 25;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundItemArm;
};
ItemData LrgLas
{
	description = "Large ER Laser";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
   heading = "cEnergy Weapons";
	shadowDetailMask = 4;
	imageType = LrgLasImage;
	price = 200;
	showWeaponBar = true;
};
function LrgLas::onUse(%player,%item)//++++++++++++++++++++++++++++++
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Large ER Laser\n-Moderate rate of fire  -High heat buildup\n-Heavy damage  -Long range: over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function LrgLasImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFireBlaster";		//fire sound
$HVfiresound2[%new] = "SoundFireBlaster";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 2000;				//range of LOS feedback
$HVtracerToggle[%new] = 1;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "LrgLaser";		 		//tracer projectile
$HVsmart[%new] = "LrgLaserShell"; 			//normal fire, guided
$HVsmart2[%new] = "LrgLaserShell";  		//FCC on, guided
$HVdumb[%new] = "LrgLaserShell";   			//normal fire, dumb
$HVdumb2[%new] = "LrgLaserShell"; 			//FCC on, dumb
$HVdumb3[%new] = "LrgLaserShell";    		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "LrgLaserShell";  			//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = 0;       			//kick for bursts
$HVknockback2[%new] = 0;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 42;					//heat generated per round, FCC off
$HVenVal2[%new] = 42;					//heat generated per round, FCC on
$HVenergy1[%new] = -10;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = -10;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "LrgLas";  				//weapon to subtract ammo from
$HVammocount1[%new] = 0;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 0;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 0;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 0;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "LrgLas";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData MedPLasImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 1;
	spinUpTime = 0.3;
	spinDownTime = 3;
      minEnergy = 25;
      maxEnergy = 7.2;
	projectileType = MediumPulseLaser;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundItemArm;
	sfxFire = SoundFirePulseLaser;
};
ItemData MedPLas
{
	description = "Medium Pulse Laser";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
   heading = "cEnergy Weapons";
	shadowDetailMask = 4;
	imageType = MedPLasImage;
	price = 125;
	showWeaponBar = true;
};
function MedPLas::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Medium Pulse Laser\n-Constant fire  -Moderate heat buildup\n-Moderate damage  -Long range: over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LrgPLasImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 1;
	spinUpTime = 0.3;
	spinDownTime = 3;
      minEnergy = 35;
      maxEnergy = 14.4;
	projectileType = LargePulseLaser;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 1;
   lightColor        = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundItemArm;
	sfxFire = SoundFireTargetingLaser;
};
ItemData LrgPLas
{
	description = "Large Pulse Laser";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
  heading = "cEnergy Weapons";
	shadowDetailMask = 4;
	imageType = LrgPLasImage;
	price = 225;
	showWeaponBar = true;
};
function LrgPLas::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Large Pulse Laser\n-Constant fire  -High heat buildup\n-Heavy damage  -Long range: over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

//----------------------------------------------------------------------------
ItemImageData PPCImage
{
   shapeFile  = "shotgun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.75;
	accuFire = true;
	sfxReady = SoundLaserIdle;
	sfxActivate = SoundItemArm; //SoundPickUpWeapon;
};
ItemData PPC
{
   heading = "cEnergy Weapons";
	description = "PPC";
	className = "Weapon";
   shapeFile  = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PPCImage;
	price = 350;
	showWeaponBar = true;
};
function PPC::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using PPC\n-Slow rate of fire  -High heat buildup\n-Heavy damage, small blast radius  -Effective Range: 450m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function PPCImage::onFire(%player,%slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFireFlierRocket";	//FCC off fire sound, and tracer fire sound
$HVfiresound2[%new] = "SoundFireFlierRocket";	//FCC on, fire sound
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVLOSrange[%new] = 600;				//range of LOS feedback, needed for lock range
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVwarning[%new] = "PPC";				//warning type recieved by target
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "PPCBolt";		    		//tracer projectile
$HVsmart[%new] = "PPCBolt";  				//FCC off, guided
$HVsmart2[%new] = "PPCBolt2";  			//FCC on, guided
$HVdumb[%new] = "PPCBolt";    			//FCC off, dumb
$HVdumb2[%new] = "PPCBolt2";  			//FCC on, dumb
$HVdumb3[%new] = "PPCBolt";    			//FCC off, pointed at sky, dumb
$HVdumb4[%new] = "PPCBolt2";  			//FCC on, pointed at sky, dumb
$HVbursts[%new] = 1;	 				//number of bursts
$HVrounds[%new] = 1;    				//number of shells per burst
$HVroundsBurst1[%new] = 1;				//rounds per shell per burst, FCC off
$HVroundsBurst2[%new] = 3;				//rounds per shell per burst, FCC on
$HVtime1[%new] = 0.2;            			//delay for bursts
$HVtime2[%new] = 0.2;           			//delay for individual shells
$HVknockback1[%new] = -10;       			//kick for bursts
$HVknockback2[%new] = -5;        			//kick for individual shells
$HVknockback3[%new] = 0;				//kick for tracers
$HVenVal1[%new] = 36.0;					//heat generated by burst, FCC off
$HVenVal2[%new] = 96.0;					//heat generated by burst, FCC on
$HVenergy1[%new] = -10;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = -30;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "PPC";	     				//weapon to subtract ammo from
$HVammocount1[%new] = 0;				//FCC off, minimum ammo required for a full burst
$HVammocount2[%new] = 0;				//FCC on, minimum ammo required for a full burst
$HVammoD1[%new] = 0;             			//ammo reduction for bursts
$HVammoD2[%new] = 0;             			//ammo reduction for individual shells
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//----------------------------------------------------------------------------
ItemImageData TargetingLaserImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2; // Sustained
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 10;
	reloadTime = 1.0;
	lightType   = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime   = 0.4;
   lightColor        = { 1, 0, 0 };
	sfxFire     = SoundFirePulseLaser;
	sfxActivate = SoundItemArm;
};
ItemData TargetingLaser
{
	description   = "Targeting Laser"; //"TAG";+++++
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
   heading = "fTargeting Systems";
	shadowDetailMask = 4;
//	imageType     = TargetingLaserImage;
	price         = 25;
	showWeaponBar = false;
	showInventory = false; //+++++++++++++++
};
function TargetingLaser::onUse(%player,%item)
{
	if(Player::getItemCount(%player, TAG))
	{
	if($matchStarted)
		{
		Player::mountItem(%player, TAG, 0);
		bottomprint(Player::getClient(%player), "<jc><f2>Using TAG\n-Low heat buildup  \n-No damage, targets an object for Artillery Strike", 5);
		Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
		}
	}
	else if(Player::getItemCount(%player, ScoutDrone))
	{
	if($matchStarted)
		{
		Player::mountItem(%player, ScoutDrone, 0);
		bottomprint(Player::getClient(%player), "<jc><f2>Mounting Scout Drone\n-Press 'fire' to launch  -Press 'jump' to abandon\n-Press 'fire' while flying to zap enemies with its Arc-Welder", 5);
		Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
		}
	}
	else if(Player::getItemCount(%player, NARC))
	{
	if($matchStarted)
		{
		Player::mountItem(%player, NARC, 0);
		bottomprint(Player::getClient(%player), "<jc><f2>NARC armed, press fire to target", 5);
		Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
		}
	}
	else if(Player::getItemCount(%player, RangeFinder))
	{
	if($matchStarted)
		{
		Player::mountItem(%player, RangeFinder, 0);
		bottomprint(Player::getClient(%player), "<jc><f2>Using Range Finder\n-Low heat buildup\n-No damage, displays range to target", 5);
		Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
		}
	}
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++=
ItemImageData RangeFinderImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2; // Sustained
	projectileType = targetLaser2;
	mountOffset = { 0, 0, 0 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
	mountRotation = { 0, 1.6, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 10;
	reloadTime = 1.0;
	lightType   = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime   = 0.4;
   lightColor        = { 1, 0, 0 };
	sfxFire     = SoundFirePulseLaser;
	sfxActivate = SoundItemArm;
};
ItemData RangeFinder
{
	description   = "Range Finder";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
   heading = "fTargeting Systems";
	shadowDetailMask = 4;
	imageType     = RangeFinderImage;
	price         = 25;
	showWeaponBar = false;
};

//++++++++++++++++++++++++++++++++++++++++
ItemImageData TAGImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; //Sustained
	projectileType = missileTAG;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 10;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime   = 0.4;
   lightColor        = { 1, 0, 0 };

	sfxFire     = SoundFirePulseLaser;
	sfxActivate = SoundItemArm;
};

ItemData TAG
{
	description   = "TAG";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
   heading = "fTargeting Systems";
	shadowDetailMask = 4;
	imageType     = TAGImage;
	price         = 125;
	showWeaponBar = false;
};

function TAG::onUse(%player,%item)
{
//	if(Player::getMountedItem(%player,$BackpackSlot) == FCCPod)
//		Weapon::onUse(%player,%item);
//	else
//		Client::sendMessage(Player::getClient(%player),1,"-You must have a 'Fire-Control Computer' to control TAG-~wC_BuySell.wav"); 
	Weapon::onUse(%player,%item);
}
function TAG2Image::onFire(%player, %slot)
 {
   %enVal  = 10.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 5.0)
	{
	if(Player::getItemCount(%player, FCC) == 1)
		{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
//		 Projectile::spawnProjectile("targetLaser",%trans,%player,%vel);
		}
	else
		{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
//		 Projectile::spawnProjectile("targetLaser2",%trans,%player,%vel);
		}
	}
	else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}

//++++++++++++++++++++++++++++++++++++++++
ItemData ScoutDroneAmmo
{
	description = "Scout Drone";
	className = "Ammo";
	shapeFile = "camera";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 150;
};
ItemImageData ScoutDroneImage
{
	shapeFile = "camera";
	mountPoint = 0;
	weaponType = 0; //+++++++++++++ (2)
//	projectileType = F1ScoutDrone;
	ammoType = ScoutDroneAmmo;
	accuFire = true;
	minEnergy = 10;
	maxEnergy = 15;
	reloadTime = 1.0;
	fireTime = 0;
	lightType   = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime   = 0.4;
	lightColor  = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundItemArm;
};
ItemData ScoutDrone
{
	description   = "Scout Drone";
	className     = "Tool";
	shapeFile     = "camera";
	hudIcon       = "targetlaser";
	heading	  = "fTargeting Systems";
	shadowDetailMask = 4;
	imageType     = ScoutDroneImage;
	price         = 275;
	showWeaponBar = false;
};
function ScoutDrone::onUse(%player,%item)
{
if(Player::getItemCount(%player, ScoutDroneAmmo) == 1)
	{
	bottomprint(Player::getClient(%player), "<jc><f2>Scout Drone armed, press fire to deploy", 5);
	Client::sendMessage(Player::getClient(%player), 1, Player::getItemCount(%player, ScoutDroneAmmo)@""); 
	Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
	Weapon::onUse(%player,%item);
	}
else
	{
	Player::trigger(%player,$WeaponSlot,false); 
	Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav"); 
	playSound(SoundDryFire,GameBase::getPosition(%player)); 
	Player::unmountItem(%player,$WeaponSlot);
	}
}
function ScoutDroneImage::onFire(%player,%slot)
{
//Client::sendMessage(Player::getClient(%player), 1, Player::getItemCount(%player, ScoutDroneAmmo)@" when fired"); 
if(Player::getItemCount(%player, ScoutDroneAmmo) == 1)
	{
	%velPlayer = Item::getVelocity(%player);
	if((Player::getLastContactCount(%player) != 0) || (%velplayer != 0))//++++
		{
		Client::sendMessage(Player::getClient(%player), 1,"-Gyros Destabilized- Remain motionless to fire~wError_Message.wav");
		Player::trigger(%player,$WeaponSlot,false);
		return;
		}
	else
		{
%new = Player::getClient(%player);
$hvWhat[%new] = %new;
$HVfiresound1[%new] = "SoundFireFlierRocket";	//fire sound
$HVfiresound2[%new] = "SoundFireFlierRocket";	//fire sound, FCC on
$HVtriggerToggle[%new] = "false";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 200;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "F1ScoutDrone";	 		//tracer projectile
$HVsmart[%new] = "F1ScoutDrone"; 			//normal fire, guided
$HVsmart2[%new] = "F1ScoutDrone";	  		//FCC on, guided
$HVdumb[%new] = "F1ScoutDrone";   			//normal fire, dumb
$HVdumb2[%new] = "F1ScoutDrone"; 			//FCC on, dumb
$HVdumb3[%new] = "F1ScoutDrone";	   		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "F1ScoutDrone";  			//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;            			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = 0;       			//kick for bursts
$HVknockback2[%new] = 0;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 15;					//heat generated per round, FCC off
$HVenVal2[%new] = 15;					//heat generated per round, FCC on
$HVenergy1[%new] = -5;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = -5;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "ScoutDrone";  			//weapon to subtract ammo from
$HVammocount1[%new] = 0;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 0;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 0;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 0;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "ScoutDrone";			//warning type recieved by target
$F1aky = %player;
$F1aky2 = GameBase::getPosition(%player);
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
	Player::setItemCount(%player, ScoutDroneAmmo,0);
//Client::sendMessage(Player::getClient(%player), 1, Player::getItemCount(%player, ScoutDroneAmmo)@" after fired"); 
		}
	}
else
	{
	Player::trigger(%player,$WeaponSlot,false); 
	Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav"); 
	playSound(SoundDryFire,GameBase::getPosition(%player)); 
	Player::unmountItem(%player,$WeaponSlot);
	}
}

//++++++++++++++++++++++++++++++++++++++++
ItemImageData NARCImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 0; //2; //Sustained
//	projectileType = missileNARC;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 10;
	reloadTime = 1.5;

	lightType   = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime   = 0.4;
   lightColor        = { 1, 0, 0 };

	sfxFire     = SoundFirePulseLaser;
	sfxActivate = SoundItemArm;
};
ItemData NARC
{
	description   = "NARC";
	className     = "Tool";
	shapeFile     = "camera";
	hudIcon       = "targetlaser";
	heading	  = "fTargeting Systems";
	shadowDetailMask = 4;
	imageType     = NARCImage;
	price         = 175;
};
function NARC::onUse(%player,%item)
{
	bottomprint(Player::getClient(%player), "<jc><f2>NARC armed, press fire to target", 5);
	Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
	Weapon::onUse(%player,%item);
}
function NARCImage::onFire(%player, %slot)//++++ won't work on non-team objects ++++
{
if(GameBase::getLOSInfo(%player,5000)) 
	{
	%cl = Player::getClient(%player); 
	%object = getObjectType($los::object); 
	%targetId = GameBase::getOwnerClient($los::object);
	if($hvMarkedTarget[%cl])
		{
		GameBase::setIsTarget($hvMarkedTarget[%cl],false);
		$hvMarkedTarget[%cl] = 0;
	$hvMarkedTarget.isMarked = false;
//		$los::object.isMarked = false;
		}
//	if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor")
	if(%object == "Player")
		{ 

//		%team2 = GameBase::getTeam(%object);
//		%team1 = GameBase::getTeam(%player);
//		%pos = GameBase::GetPosition(%this);
//		%mark = newObject("","Item",UnBeacon,1,true); //thanks AAOD mod++++
//		addToSet("MissionCleanup", %mark);
//		GameBase::setTeam(%mark,%team1);
//		GameBase::setPosition(%mark,%pos);
//		%res1 = GameBase::setIsTarget(%mark,true);

	%beacon = newObject("","Item",UnBeacon,1,true); //thanks AAOD mod++++
//	%OName = GameBase::getDataName(%object);
//	Player::setItemCount(%cl, RadarPackH,1);
	Player::mountItem(%targetId,%beacon,$WeaponSlot);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setIsTarget(%beacon,true);
		$hvMarkedTarget[%cl] = %beacon;
		%beacon.isMarked = true;

//		GameBase::setIsTarget($los::object,true);
//		$los::object.isMarked = true;
//		$hvMarkedTarget[%cl] = $los::object;
	Client::sendMessage(Player::getClient(%player), 0,"los::object" @ $los::object @ " targetId" @ %targetId @ " beacon:" @ %beacon @ "");
		Client::sendMessage(%cl, 0,"Target marked ~wMine_Act.wav");
		}
	else
		{
		Client::sendMessage(%cl, 0,"Invalid Target ~wMine_Act.wav");		
		}
	}
else
	{
	Client::sendMessage(%cl, 0,"No target in LOS ~wMine_Act.wav");
	}
}

//----------------------------------------------------------------------------
ItemImageData FlamerImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 1;
	accuFire = true;
	reloadTime = 0.5;
	spinUpTime = 0.5;
	spinDownTime = 0.1;
	fireTime = 1.0; //0.01;
	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxActivate = SoundItemArm;
	sfxSpinUp = SoundFlameIgnite;
};
ItemData Flamer
{
	description = "Heavy Flamer";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "energyRifle";
   heading = "cEnergy Weapons";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 75;
	showWeaponBar = true;
};
function Flamer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Heavy Flamer\n-Moderate rate of fire  -Moderate heat buildup\n-Minimal damage, overheats the target  -Effective range: 40m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function FlamerImage::onFire(%player, %slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "FlamerFire";			//fire sound, FCC off
$HVfiresound2[%new] = "SoundFireFlierRocket";	//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 100;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "FlamerShell";			//tracer projectile
$HVsmart[%new] = "FlamerShell"; 			//normal fire, guided
$HVsmart2[%new] = "FlamerShell2";  			//FCC on, guided
$HVdumb[%new] = "FlamerShell";   			//normal fire, dumb
$HVdumb2[%new] = "FlamerShell2"; 			//FCC on, dumb
$HVdumb3[%new] = "FlamerShell";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "FlamerShell2";  			//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 9;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0.1;           			//delay for bursts
$HVtime2[%new] = 0.1;           			//delay for individual missiles
$HVknockback1[%new] = 0;       			//kick for bursts
$HVknockback2[%new] = 0;        			//kick for individual missiles
$HVknockback3[%new] = 0;				//kick for tracer rounds
$HVenVal1[%new] = 20;					//heat generated per round, FCC off
$HVenVal2[%new] = 24;					//heat generated per round, FCC on
$HVenergy1[%new] = 2;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = -5;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "Flamer"; 				//weapon to subtract ammo from
$HVammocount1[%new] = 0;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 0;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 0;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 0;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "Flamer";				//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//----------------------------------------------------------------------------
ItemData SmokeAmmo
{
	description = "Smoke Cannister";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	price = 2;
};
ItemImageData SmokeLauncherImage
{
	shapeFile = "grenadeL"; //"grenade";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = SmokeAmmo;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.0; //0.1;+++++++++
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.5, 0.16 };
	sfxActivate = SoundItemArm;
	sfxReload = SoundDryFire;
	sfxReady = SoundmortarIdle;
};
ItemData SmokeLauncher
{
	description = "Smoke Launcher";
	className = "Weapon";
	shapeFile = "grenadeL"; //"grenade";
	hudIcon = "grenade";
   heading = "eMortar Weapons";
	shadowDetailMask = 4;
	imageType = SmokeLauncherImage;
	price = 95;
	showWeaponBar = true;
};
function SmokeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Smoke Launcher\n-Fires 'smoke' or 'flash-bang' Cannisters\n-Low heat buildup  -Minimal damage  -Effective range: 80m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function SmokeLauncherImage::onFire(%player, %slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "SoundFireGrenade";		//fire sound, FCC off
$HVfiresound2[%new] = "SoundFireGrenade";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 200;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "SmokeShell";			//tracer projectile
$HVsmart[%new] = "SmokeShell"; 			//normal fire, guided
$HVsmart2[%new] = "SmokeShell2";  			//FCC on, guided
$HVdumb[%new] = "SmokeShell";   			//normal fire, dumb
$HVdumb2[%new] = "SmokeShell2"; 			//FCC on, dumb
$HVdumb3[%new] = "SmokeShell";    			//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "SmokeShell2";  			//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;           			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -40;       			//kick for bursts
$HVknockback2[%new] = -40;        			//kick for individual missiles
$HVknockback3[%new] = -40;				//kick for tracer rounds
$HVenVal1[%new] = 6;					//heat generated per round, FCC off
$HVenVal2[%new] = 6;					//heat generated per round, FCC on
$HVenergy1[%new] = 5;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = 5;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "SmokeLauncher"; 			//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "SmokeLauncher";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData LMechMortarAmmo
{
	description = "Light Mortar Shell";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData LMechMortarImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
mountOffset = {0, 0, 0};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0, 3.114, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	ammoType = LMechMortarAmmo;
	accuFire = false;
	reloadTime = 1.5;
	fireTime = 0.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundItemArm;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};
ItemData LMechMortar
{
	description = "Light Mech Mortar";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
   heading = "eMortar Weapons";
	shadowDetailMask = 4;
	imageType = LMechMortarImage;
	price = 325;
	showWeaponBar = true;
};
ItemImageData LMechMortar2Image
{
	shapeFile = "radar_small"; 
	mountPoint = 0;
mountOffset = {0.03, -0.4, -0.02}; 
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.6, 3.1, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	ammoType = LMechMortarAmmo;
	accuFire = false;
	reloadTime = 1.5;
	fireTime = 0.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundItemArm;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};
ItemData LMechMortar2
{
	description = "Light Mech Mortar";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "mortar";
   heading = "eMortars";
	shadowDetailMask = 4;
	imageType = LMechMortar2Image;
	price = 425;
	showWeaponBar = true;
};
function LMechMortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Light Mech Mortar\n-Fires explosive warheads  -Low heat buildup\n-Moderate damage  -Effective range: 150m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function LMechMortar::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,LMechMortar2,$LMechMortar1Slot);
} 
function LMechMortar::onUnmount(%player,%imageSlot) 
{ 
Player::unmountItem(%player,$LMechMortar1Slot);
} 
function LMechMortarImage::onFire(%player, %slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "turretExplosion";		//fire sound, FCC off
$HVfiresound2[%new] = "turretExplosion";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 200;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "LMechMortarShell";		//tracer projectile
$HVsmart[%new] = "LMechMortarShell"; 		//normal fire, guided
$HVsmart2[%new] = "LMechMortarShell2";  		//FCC on, guided
$HVdumb[%new] = "LMechMortarShell";  		//normal fire, dumb
$HVdumb2[%new] = "LMechMortarShell2";		//FCC on, dumb
$HVdumb3[%new] = "LMechMortarShell"; 		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "LMechMortarShell2";		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;           			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -60;       			//kick for bursts
$HVknockback2[%new] = -60;        			//kick for individual missiles
$HVknockback3[%new] = -60;				//kick for tracer rounds
$HVenVal1[%new] = 18;					//heat generated per round, FCC off
$HVenVal2[%new] = 18;					//heat generated per round, FCC on
$HVenergy1[%new] = 0;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = 0;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "LMechMortar"; 			//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "LMechMortar";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemData HMechMortarAmmo
{
	description = "Heavy Mortar Shell";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 10;
};
ItemImageData HMechMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
mountOffset = {0, 0, 0};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0, 3.114, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	ammoType = HMechMortarAmmo;
	accuFire = false;
	reloadTime = 2.0;
	fireTime = 0.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundItemArm;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};
ItemData HMechMortar
{
	description = "Heavy Mech Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eMortar Weapons";
	shadowDetailMask = 4;
	imageType = HMechMortarImage;
	price = 425;
	showWeaponBar = true;
};
ItemImageData HMechMortar2Image
{
	shapeFile = "radar_small";
	mountPoint = 0;
mountOffset = {0.03, 0.25, -0.075};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.6 , 3.1, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	weaponType = 0; // Single Shot
	ammoType = HMechMortarAmmo;
	accuFire = false;
	reloadTime = 3.0;
	fireTime = 0.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundItemArm;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};
ItemData HMechMortar2
{
	description = "Heavy Mech Mortar";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "mortar";
   heading = "eMortars";
	shadowDetailMask = 4;
	imageType = HMechMortar2Image;
	price = 425;
	showWeaponBar = true;
};
function HMechMortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Heavy Mech Mortar\n-Fires explosive warheads  -Moderate heat buildup\n-Heavy damage  -Effective range: 250m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function HMechMortar::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,HMechMortar2,$HMechMortar1Slot);
} 
function HMechMortar::onUnmount(%player,%imageSlot) 
{ 
Player::unmountItem(%player,$HMechMortar1Slot);
} 
function HMechMortarImage::onFire(%player, %slot)
{
%new = Player::getClient(%player);
$HVfiresound1[%new] = "turretExplosion";		//fire sound, FCC off
$HVfiresound2[%new] = "turretExplosion";		//fire sound, FCC on
$HVtriggerToggle[%new] = "true";			//toggle weapon trigger, "true" or "false"
$HVlockToggle[%new] = 0;				// 1 = locking, 0 = dumbfire, controls lock messaging
$HVLOSrange[%new] = 400;				//range of LOS feedback
$HVtracerToggle[%new] = 0;	    			// 1 = tracer on, 0 = tracer off
$HVtracer[%new] = "HMechMortarShell";		//tracer projectile
$HVsmart[%new] = "HMechMortarShell"; 		//normal fire, guided
$HVsmart2[%new] = "HMechMortarShell3";  		//FCC on, guided
$HVdumb[%new] = "HMechMortarShell";  		//normal fire, dumb
$HVdumb2[%new] = "HMechMortarShell3";		//FCC on, dumb
$HVdumb3[%new] = "HMechMortarShell"; 		//pointed at sky, normal fire, dumb
$HVdumb4[%new] = "HMechMortarShell3";		//pointed at sky, alt-fire, dumb
$HVroundsBurst1[%new] = 1;				//rounds per missile per burst, FCC off
$HVroundsBurst2[%new] = 1;				//rounds per missile per burst, FCC on
$HVbursts[%new] = 1;    				//number of bursts
$HVrounds[%new] = 1;    				//number of missiles per burst
$HVtime1[%new] = 0;           			//delay for bursts
$HVtime2[%new] = 0;           			//delay for individual missiles
$HVknockback1[%new] = -100;       			//kick for bursts
$HVknockback2[%new] = -100;        			//kick for individual missiles
$HVknockback3[%new] = -100;				//kick for tracer rounds
$HVenVal1[%new] = 42;					//heat generated per round, FCC off
$HVenVal2[%new] = 42;					//heat generated per round, FCC on
$HVenergy1[%new] = 0;					//HVenVal1 + HVenergy1 = min energy to fire, FCC off
$HVenergy2[%new] = 0;					//HVenVal2 + HVenergy2 = min energy to fire, FCC on
$HVammoT[%new] = "HMechMortar"; 			//weapon to subtract ammo from
$HVammocount1[%new] = 1;				//minimum ammo required for a full burst, FCC off
$HVammocount2[%new] = 1;				//minimum ammo required for a full burst, FCC on
$HVammoD1[%new] = 1;             			//ammo reduction for bursts, FCC off
$HVammoD2[%new] = 1;             			//ammo reduction for individual missiles, FCC on
$HVwarning[%new] = "HMechMortar";			//warning type recieved by target
$F1aky[%new] = "";
$F1aky2[%new] = "";
	schedule("MissileImage::Fire(" @ %player @ ");", %timedelay); 
}

//----------------------------------------------------------------------------
ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 16;  //++++12++++
   lightType = 2;  // Weapon Fire
   lightRadius = 2;
   lightTime = 0.1;
   lightColor = { 0.85, 0.25, 0.25 };
	sfxActivate = SoundItemArm;
	sfxFire = SoundELFFire;
	sfxReady = SoundELFIdle;
};
ItemData RepairGun
{
	description = "Welding Torch";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
};
function RepairGun::onMount(%player,%imageSlot)
	//%item++++erases "False has no ammo", makes crash if previous weapon still recharging++++
{
//	Weapon::onUse(%player,%item);//+++++++Caused "False has no ammo" glitch++++
//	bottomprint(Player::getClient(%player), "<jc><f2>Using Welding Torch", 2);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Welding Torch\n-Repairs friendly targets and damages enemies  -Range: 8m", 5);
	Player::trigger(%player,$BackpackSlot,true);
}
function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------
// Backpacks==================================================================
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
ItemImageData DeployableMechBayImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableMechBay
{
	description = "Mobile Mech Bay";
	shapeFile = "invent_remote";
	className = "Backpack";
   heading = "jDeployable Stations";
	shadowDetailMask = 4	;
	imageType = DeployableMechBayImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableMechBay::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableMechBay::onDeploy(%player,%item,%pos)
{
	if (DeployableMechBay::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableMechBay::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

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
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableMechBay"]++;
//						Client::sendMessage(Player::getClient(%client), 3,"Mech Bay deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
						%points = 3;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%inv)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
						return true;
					}
				}
				else {
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");
	return false;
}

//----------------------------------------------------------------------------
ItemImageData DeployableMunitionsPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableMunitionsPack
{
	description = "Mobile Munitions Bay";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "jDeployable Stations";
	shadowDetailMask = 4;
	imageType = DeployableMunitionsPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableMunitionsPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableMunitionsPack::onDeploy(%player,%item,%pos)
{
	if (DeployableMunitionsPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableMunitionsPack::deployShape(%player,%item)
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
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableMunitionsPack"]++;
//						Client::sendMessage(Player::getClient(%client), 3,"Munitions Bay deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
						%points = 2;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%inv)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
						return true;
					}
				}
				else {
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");
	return false;
}

//----------------------------------------------------------------------------
ItemImageData DoubleHeatSinkImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = -1;
 	maxEnergy = -6; //-5;++++++
	firstPerson = false;
};

ItemData DoubleHeatSink
{
	description = "Double Heat Sinks";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "iAttachments";
	shadowDetailMask = 4;
	imageType = DoubleHeatSinkImage;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DoubleHeatSink::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Client::sendMessage(Player::getClient(%player),0,"Double Heat-Sinks equipped ~wpda_on.wav");
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}
function DoubleHeatSink::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData MASCPackImage
{
//	mass = 10.0;
	shapeFile = "mortarpack";
	mountPoint = 2;
	weaponType = 2;
	reloadTime = 0.01;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 15; //20;++++
	firstPerson = false;

	sfxFire = SoundGeneratorPower;
	sfxActivate = SoundItemArm;
};

ItemData MASCPack
{
	description = "MASC Overdrive";
	shapeFile = "mortarpack";
	className = "Backpack";
   heading = "iAttachments";
	shadowDetailMask = 4;
	imageType = MASCPackImage;
	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function MASCPackCheck(%player)
{
%armor = Player::getArmor(%player);
%client = player::getClient(%player);
if (%armor == "larmor")
	{
	   $mov[%client] = 12.5;
	   $jb[%client] = 60.0;
	}
	else if (%armor == "xarmor")
	{
	   $mov[%client] = 12.5;
	   $jb[%client] = 60.0;
	}
	else if (%armor == "parmor")
	{
	   $mov[%client] = 10.0;
	   $jb[%client] = 75.0;
	}
	else if (%armor == "driver")
	{
	   $mov[%client] = 9.0;
	   $jb[%client] = 84.0;
	}
	else if (%armor == "carmor")
	{
	   $mov[%client] = 9.0;
	   $jb[%client] = 96.0;
	}
	else if (%armor == "dmarmor")
	{
	   $mov[%client] = 10.0;
	   $jb[%client] = 75.0;
	}
	else if (%armor == "marmor")
	{
	   $mov[%client] = 8.0;
	   $jb[%client] = 107.0;
	}
	else if (%armor == "hbarmor")
	{
	   $mov[%client] = 7.5;
	   $jb[%client] = 139.0;
	}
	else if (%armor == "aarmor")
	{
	   $mov[%client] = 7.0;
	   $jb[%client] = 150.0;
	}
	else if (%armor == "warmor")
	{
	   $mov[%client] = 7.5;
	   $jb[%client] = 162.0;
	}
	else if (%armor == "rarmor")
	{
	   $mov[%client] = 9.5;
	   $jb[%client] = 200.0;
	}
	else if (%armor == "barmor")
	{
	   $mov[%client] = 6.0;
	   $jb[%client] = 182.0;
	}
	else if (%armor == "yarmor")
	{
	   $mov[%client] = 6.0;
	   $jb[%client] = 200.0;
	}
	else if (%armor == "harmor")
	{
	   $mov[%client] = 5.0;
	   $jb[%client] = 213.0;
	}
}
function MASCPack::onMount(%player,%item)
{
//	%client = player::getClient(%player);
//	%armor = Player::getArmor(%player);
//	$hvArmorBK[%client] = %armor.maxForwardSpeed;//++++moved below++++
	Client::sendMessage(Player::getClient(%player),0,"'MASC Overdrive' equipped ~wpda_on.wav");
}
function MASCPackImage::onActivate(%player,%imageSlot)
{
MASCPackCheck(%player);//++++
if(%player.Station)
	{
	Player::trigger(%object,$BackpackSlot,false);
//	Client::sendMessage(Player::getClient(%player), 1,"-MASC deactivated- " @ %armor.maxForwardSpeed @ "~wC_BuySell.wav");
	return;
	}
else
	{
	%client = player::getClient(%player);
	%armor = Player::getArmor(%player);
//	$hvArmorBK[%client] = %armor.maxForwardSpeed;//+++moved here to avoid INV cheat++++
//	%armor.maxForwardSpeed = %armor.maxForwardSpeed * 2;
	%armor.maxForwardSpeed = $mov[%client] * 2;
	%armor.jumpImpulse = $jb[%client] * 3;//++++
	Client::sendMessage(%client,0,"MASC activated ~wmine_act.wav");
	playSound(ForceFieldOpen,GameBase::getPosition(%player));
	}
}
function MASCPackImage::onDeactivate(%player,%imageSlot)
{
MASCPackCheck(%player);//++++
if(%player.Station)
	{
	%client = player::getClient(%player);
	%armor = Player::getArmor(%player);
	Player::trigger(%object,$BackpackSlot,false);
//	$hvArmorBK[%client] = %armor.maxForwardSpeed;
	Client::sendMessage(Player::getClient(%player), 1,"-Pack deactivated- " @ %armor.maxForwardSpeed @ "~wC_BuySell.wav");
	Client::sendMessage(%client,0,"MASC deactivated ~wmotion_activate.wav");
	return;
	}
else
	{
	%armor = Player::getArmor(%player);
	%energy = GameBase::getEnergy(%player); 
	%client = player::getClient(%player);
	if(%energy < 6)
		{
//		%armor.maxForwardSpeed = %armor.maxForwardSpeed / 2;
		%armor.maxForwardSpeed = $mov[%client];
		%armor.jumpImpulse = $jb[%client];//++++
//		%armor.maxForwardSpeed = $hvArmorBK[%client];
		Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, MASC deactivated- ~wC_BuySell.wav");
		playSound(ForceFieldClose,GameBase::getPosition(%player));
		Player::trigger(%player,$BackpackSlot,false);
		}
	else
		{
//		%armor.maxForwardSpeed = %armor.maxForwardSpeed / 2;
//		%armor.maxForwardSpeed = $hvArmorBK[%client];
		%armor.maxForwardSpeed = $mov[%client];
		%armor.jumpImpulse = $jb[%client];//++++
		Client::sendMessage(%client,0,"MASC deactivated ~wmotion_activate.wav");
		playSound(ForceFieldClose,GameBase::getPosition(%player));
		Player::trigger(%player,$BackpackSlot,false);
		}
	}
}
function MASCPack::onUnmount(%player,%item)
{
MASCPackCheck(%player);//++++
	%client = player::getClient(%player);
	%armor = Player::getArmor(%player);
//	%armor.maxForwardSpeed = $hvArmorBK[%client];
	%armor.maxForwardSpeed = $mov[%client];
	%armor.jumpImpulse = $jb[%client];//++++
	playSound(ForceFieldClose,GameBase::getPosition(%player));
	Player::trigger(%player,$BackpackSlot,false);
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData JumpBoosterImage
{
//	mass = 10.0;
	shapeFile = "mortarpack";
	mountPoint = 2;
	weaponType = 2;
	reloadTime = 0.01;
	fireTime = 0;
	minEnergy = 2;
	maxEnergy = 8;
	firstPerson = false;

	sfxFire = SoundGeneratorPower;
	sfxActivate = SoundItemArm;
};

ItemData JumpBooster
{
	description = "Jump Booster";
	shapeFile = "mortarpack";
	className = "Backpack";
   heading = "iAttachments";
	shadowDetailMask = 4;
	imageType = JumpBoosterImage;
	price = 210;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JumpBooster::onMount(%player,%item)
{
	Client::sendMessage(Player::getClient(%player),0,"'MASC Overdrive' equipped ~wpda_on.wav");
}
function JumpBoosterImage::onActivate(%player,%imageSlot)
{
if(%player.Station)
	{
	Player::trigger(%object,$BackpackSlot,false);
	return;
	}
else
	{
	%client = player::getClient(%player);
	%armor = Player::getArmor(%player);
	%armor.jumpImpulse = $jb[%client] * 3;
	Client::sendMessage(%client,0,"Jump Booster activated ~wmine_act.wav");
	playSound(ForceFieldOpen,GameBase::getPosition(%player));
	}
}
function JumpBoosterImage::onDeactivate(%player,%imageSlot)
{
MASCPackCheck(%player);//++++
if(%player.Station)
	{
	%client = player::getClient(%player);
	%armor = Player::getArmor(%player);
	Player::trigger(%object,$BackpackSlot,false);
	Client::sendMessage(%client,0,"Jump Booster deactivated ~wmotion_activate.wav");
	return;
	}
else
	{
	%armor = Player::getArmor(%player);
	%energy = GameBase::getEnergy(%player); 
	%client = player::getClient(%player);
	if(%energy < 6)
		{
		%armor.jumpImpulse = $jb[%client];
		Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Jump Booster deactivated- ~wC_BuySell.wav");
		playSound(ForceFieldClose,GameBase::getPosition(%player));
		Player::trigger(%player,$BackpackSlot,false);
		}
	else
		{
		%armor.jumpImpulse = $jb[%client];
		Client::sendMessage(%client,0,"Jump Booster deactivated ~wmotion_activate.wav");
		playSound(ForceFieldClose,GameBase::getPosition(%player));
		Player::trigger(%player,$BackpackSlot,false);
		}
	}
}
function JumpBooster::onUnmount(%player,%item)
{
MASCPackCheck(%player);//++++
	%client = player::getClient(%player);
	%armor = Player::getArmor(%player);
	%armor.jumpImpulse = $jb[%client];
	playSound(ForceFieldClose,GameBase::getPosition(%player));
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------
ItemImageData RepairPackImage
{
	mass = 0.5;
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
	description = "Welding Torch";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "iAttachments";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 175;
	hudIcon = "RepairPack";
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
		Client::sendMessage(Player::getClient(%player),0,"Welding Torch equipped ~wpda_on.wav");
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
ItemImageData FerroFibrousArmorImage
{
	mass = -0.5;
	shapeFile = "shieldpack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy/sec for sustained weapons
	firstPerson = false;
};

ItemData FerroFibrousArmor
{
	description = "Ferro-Fibrous Armor";
	shapeFile = "shieldpack";
	className = "Backpack";
   heading = "iAttachments";
	shadowDetailMask = 4;
	imageType = FerroFibrousArmorImage;
	price = 225;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FerroFibrousArmor::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Client::sendMessage(Player::getClient(%player),0,"Ferros-Fibrous Armor equipped ~wpda_on.wav");
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}
function FerroFibrousArmor::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}
function FerroFibrousArmorImage::onActivate(%player,%imageSlot)//+++++++
{
	%player.shieldStrength = 0.125; //0.025;
}
function FerroFibrousArmorImage::onDeactivate(%player,%imageSlot)//++++++
{
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}

//----------------------------------------------------------------------------
ItemImageData MunitionsPackImage
{
	mass = 0.8;
	shapeFile = "ammo1";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
   mountRotation = {1.5,0,0};
	firstPerson = false;

   explosionId = BombExp; //+++++++
	explosionRadius = 25.0;
	damageValue = 1.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 150;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

ItemData MunitionsPack
{
   explosionId = BombExp; //++++++++++++++++
	explosionRadius = 25.0;
	damageValue = 1.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 150;
	maxDamage = 0.5;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

	description = "Munitions Pod";
	shapeFile = "ammo1";
	className = "Backpack";
   heading = "iAttachments";
	imageType = MunitionsPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 250;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MunitionsPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 23 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $MunitionsPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 1) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.LRMAmmo = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.STRAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.ArrowIVAmmo = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.AC5Ammo = %numPack;
			}
			else if(%i == 6) {
	 	    	%item.AC10Ammo = %numPack;
			}
			else if(%i == 7) {
	 	    	%item.AC20Ammo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.Ultra5Ammo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.Ultra10Ammo = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.Ultra20Ammo = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.MachineGunAmmo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.GaussGunAmmo = %numPack;
			}
			else if(%i == 13) {
	 	    	%item.SniperGunAmmo = %numPack;
			}
			else if(%i == 14) {
	 	    	%item.SmokeAmmo = %numPack;
			}
			else if(%i == 15) {
	 	    	%item.HVAC10Ammo = %numPack;
			}
			else if(%i == 16) {
	 	    	%item.HMechMortarAmmo = %numPack;
			}
			else if(%i == 17) {
	 	    	%item.LMechMortarAmmo = %numPack;
			}
			else if(%i == 18) {
	 	    	%item.ThunderboltAmmo = %numPack;
			}
			else if(%i == 19) {
	 	    	%item.ThunderLRMAmmo = %numPack;
			}
//			else if(%i == 20) {
//	 	    	%item.VibroMine = %numPack;
//			}
//			else if(%i == 21) {
//	 	    	%item.InfernoMine = %numPack;
//			}
//			else if(%i == 22) {
//	 	    	%item.NukeGrenade = %numPack;
//			}
//			else if(%i == 23) {
//	 	    	%item.InfernoGrenade = %numPack;
//			}
//			else if(%i == 24) {
//	 	    	%item.SmokeHandGrenade = %numPack;
//			}
			else if(%i == 20) {
	 	    	%item.Thunderbolt5Ammo = %numPack;
			}
			else if(%i == 21) {
	 	    	%item.ThumperGunAmmo = %numPack;
			}
			else {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function MunitionsPack::onCollision(%this,%object)
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
	for(%i = 0; %i < 23 ; %i = %i +1) {
		%ammoItem = $MunitionsPackItems[%i];
		if(%i == 1) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 2) {
 	    	%numAdd = %item.LRMAmmo;
		}
		else if(%i == 3) {
 	    	%numAdd = %item.STRAmmo;
		}
		else if(%i == 4) {
 	    	%numAdd = %item.ArrowIVAmmo;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.AC5Ammo;
		}
		else if(%i == 6) {
 	    	%numAdd = %item.AC10Ammo;
		}
		else if(%i == 7) {
 	    	%numAdd = %item.AC20Ammo;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.Ultra5Ammo;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.Ultra10Ammo;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.Ultra20Ammo;
		}
		else if(%i == 11) {
 	    	%numAdd = %item.MachineGunAmmo;
		}
		else if(%i == 12) {
 	    	%numAdd = %item.GaussGunAmmo;
		}
		else if(%i == 13) {
 	    	%numAdd = %item.SniperGunAmmo;
		}
		else if(%i == 14) {
 	    	%numAdd = %item.SmokeAmmo;
		}
		else if(%i == 15) {
 	    	%numAdd = %item.HVAC10Ammo;
		}
		else if(%i == 16) {
 	    	%numAdd = %item.HMechMortarAmmo;
		}
		else if(%i == 17) {
 	    	%numAdd = %item.LMechMortarAmmo;
		}
		else if(%i == 18) {
 	    	%numAdd = %item.ThunderboltAmmo;
		}
		else if(%i == 19) {
 	    	%numAdd = %item.ThunderLRMAmmo;
		}
		else if(%i == 20) {
 	    	%numAdd = %item.Thunderbolt5Ammo;
		}
		else if(%i == 21) {
 	    	%numAdd = %item.ThumperGunAmmo;
		}
//		else if(%i == 20) {
 //	    	%numAdd = %item.VibroMine;
//		}
//		else if(%i == 21) {
 //	    	%numAdd = %item.InfernoMine;
//		}
//		else if(%i == 22) {
 //	    	%numAdd = %item.NukeGrenade;
//		}
//		else if(%i == 23) {
 //	    	%numAdd = %item.InfernoGrenade;
//		}
//		else if(%i == 24) {
 //	    	%numAdd = %item.SmokeHandGrenade;
//		}
		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillMunitionsPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 23 ; %i = %i +1) {
		%item = $MunitionsPackItems[%i];
		%maxnum = $MunitionsPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

function MunitionsPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Client::sendMessage(Player::getClient(%player),0,"Munitions Pack equipped ~wpda_on.wav");
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//----------------------------------------------------------------------------
ItemImageData ECMPodImage
{
	mass = 0.2;
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = -25;
	maxEnergy = 0;  //12+++++++++++ Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ECMPod
{
	description = "ECM Pod";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "iAttachments";
	shadowDetailMask = 4;
	imageType = ECMPodImage;
	price = 185;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function ECMPod::onUse(%player,%item)//+++++++++++
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	Client::sendMessage(Player::getClient(%player),0,"ECM Pod equipped ~wpda_on.wav");
	Player::mountItem(%player,%item,$BackpackSlot);
	}
}
function ECMPod::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	Client::sendMessage(Player::getClient(%player),0,"ECM Pod activated ~wsensor_deploy.wav");
	%rate = Player::getSensorSupression(%player) + 25;
	Player::setSensorSupression(%player,%rate);
}
function ECMPodImage::onActivate(%player,%imageSlot)
{

}
function ECMPodImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}
function ECMPod::onUnmount(%player,%item)
{
	Client::sendMessage(Player::getClient(%player),0,"ECM Pod deactivated ~wForceClose.wav");
	%rate = Player::getSensorSupression(%player) - 25;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData FCCPodImage
{
	mass = 0.5;
	shapeFile = "ammopack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -25;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData FCCPod
{
	description = "Fire-Control Computer";
	shapeFile = "ammopack";
	className = "Backpack";
   heading = "iAttachments";
	shadowDetailMask = 4;
	imageType = FCCPodImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FCCPod::onMount(%player,%item)
{
	Client::sendMessage(Player::getClient(%player),0,"'Fire-Control Computer' equipped ~wpda_on.wav");
}
function FCCPodImage::onActivate(%player,%imageSlot)//+++++++
{
	Client::sendMessage(Player::getClient(%player),0,"'Fire-Control Computer' activated ~wmine_act.wav");
	Player::setItemCount(%player, FCC,1);
}
function FCCPodImage::onDeactivate(%player,%imageSlot)//++++++
{
	Client::sendMessage(Player::getClient(%player),0,"'Fire-Control Computer' deactivated ~wmotion_activate.wav");
	Player::setItemCount(%player, FCC,0);
	Player::trigger(%player,$BackpackSlot,false);
}
ItemData FCC
{
   description = "FCC";
   showInventory = false;//++++++++++++++++++++
   shapeFile = "sensor_small";
   heading = "fSundries";
   shadowDetailMask = 4;
   price = 50;
	className = "HandAmmo";
};

//----------------------------------------------------------------------------
ItemImageData RadarPackImage
{
	mass = 0.5;
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData RadarPack
{
	description = "Portable Radar Dish";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = "kDeployable Sensors";
	imageType = RadarPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RadarPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function RadarPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) 
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "RadarPack"]++;
	 	%client = Player::getClient(%player);
		%points = 2;
		%client.score = %client.score + %points;
		$hvGood[%client] = $hvGood[%client] + %points; 
		%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
		bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ %item.description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		Game::refreshClientScore(%client);
	}
}

//----------------------------------------------------------------------------
ItemImageData BeagleActiveProbeImage
{
	mass = 0.5;
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData BeagleActiveProbe
{
	description = "Beagle Active Probe";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "kDeployable Sensors";
	imageType = BeagleActiveProbeImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BeagleActiveProbe::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function BeagleActiveProbe::onDeploy(%player,%item,%pos)
{
	if (BeagleActiveProbe::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "BeagleActiveProbe"]++;
	}
}

//	if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) {
function BeagleActiveProbe::deployShape(%player,%item)
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
					Gamebase::setMapName(%mSensor,"BeagleActiveProbe");
					Client::sendMessage(%client,0,"BeagleActiveProbe deployed");
					playSound(SoundPickupBackpack,$los::position);
//					echo("MSG: ",%client," deployed a Motion Sensor");
						%points = 2;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%mSensor)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");
	return false;
}

//----------------------------------------------------------------------------
ItemImageData DeployableSensorJamPackImage
{
	mass = 0.5;
	shapeFile = "sensor_jammer";
 	mountPoint = 2;
  	mountOffset = { 0, 0.03, 0.1 };
  	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData DeployableECMPod
{
	description = "Portable ECM Pod";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = "kDeployable Sensors";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	elasticity = 0.2;
  	price = 250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableECMPod::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableECMPod::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableECMPod"]++;
	 	%client = Player::getClient(%player);
		%points = 2;
		%client.score = %client.score + %points;
		$hvGood[%client] = $hvGood[%client] + %points; 
		%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
		bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ %item.description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		Game::refreshClientScore(%client);
	}
}

//----------------------------------------------------------------------------
ItemImageData CameraPackImage
{
	mass = 0.3;
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
   heading = "kDeployable Sensors";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 50;
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
					Client::sendMessage(%client,0,"Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
//						Client::sendMessage(Player::getClient(%client), 1,"Camera deployed~wMine_Act.wav");//++++
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
		}
	}
	else																		  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");
	return false;
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData MedLasPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData MedLasPack
{
	description = "Medium Laser Turret"; //"ER Laser Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "lDeployable Turrets";
	imageType = MedLasPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 150;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MedLasPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MedLasPack::onDeploy(%player,%item,%pos)
{
	if (MedLasPack::deployShape(%player,%item)) {
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

function MedLasPack::deployShape(%player,%item)
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
					%camera = newObject("remoteTurret","Turret",MedLasTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Medium Laser Turret #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
//					%new = Player::getClient(%player);//++++++++
//					$HVturretName[%new] = "Medium Laser Turret";//++++++++
					Client::sendMessage(%client,0,"Medium Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "MedLasPack"]++;
//						Client::sendMessage(Player::getClient(%client), 3,"Medium Laser Turret deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
								 Client::setOwnedObject(%client, %player);
						%points = 2;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%camera)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
		}
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");
	return false;
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData MedPLasPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData MedPLasPack
{
	description = "Large Laser Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "lDeployable Turrets";
	imageType = MedPLasPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 175;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MedPLasPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MedPLasPack::onDeploy(%player,%item,%pos)
{
	if (MedPLasPack::deployShape(%player,%item)) {
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

function MedPLasPack::deployShape(%player,%item)
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
								%turret = newObject("remoteTurret","Turret",MedPLasTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Large Laser Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Large Laser Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "MedPLasPack"]++;
//								echo("MSG: ",%client," deployed a Large Laser Turret");
								//	Remote turrets - kill points to player that deploy them
//								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
						%points = 2;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%turret)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
								return true;
							}
						}
						else 
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets~wAccess_Denied.wav");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area~wAccess_Denied.wav");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");

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
			Client::sendMessage(%client,0,"Unable to deploy - You are in the way~wAccess_Denied.wav");
		else
			Client::sendMessage(%client,0,"Unable to deploy - A Player is in the way~wAccess_Denied.wav");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - An Item in the way~wAccess_Denied.wav");

	deleteObject(%set);
	return 0;	
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LRM5PackImage
{
	shapeFile = "missileturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LRM5Pack
{
	description = "ArrowIV Turret";
	shapeFile = "missileturret";
	className = "Backpack";
   heading = "lDeployable Turrets";
	imageType = LRM5PackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LRM5Pack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LRM5Pack::onDeploy(%player,%item,%pos)
{
	if (LRM5Pack::deployShape(%player,%item)) {
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

function LRM5Pack::deployShape(%player,%item)
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
								%turret = newObject("remoteTurret","Turret",LRM5Turret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"ArrowIV Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"ArrowIV Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "LRM5Pack"]++;
//						Client::sendMessage(Player::getClient(%client), 3,"ArrowIV Turret deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
								//	Remote turrets - kill points to player that deploy them
//								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
						%points = 3;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%turret)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
								return true;
							}
						}
						else 
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets~wAccess_Denied.wav");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area~wAccess_Denied.wav");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");

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
			Client::sendMessage(%client,0,"Unable to deploy - You are in the way~wAccess_Denied.wav");
		else
			Client::sendMessage(%client,0,"Unable to deploy - A Player is in the way~wAccess_Denied.wav");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - An Item in the way~wAccess_Denied.wav");

	deleteObject(%set);
	return 0;	
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData STR2PackImage
{
	shapeFile = "hellfiregun";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData STR2Pack
{
	description = "Thumper AAA";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "lDeployable Turrets";
	imageType = STR2PackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 325;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function STR2Pack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function STR2Pack::onDeploy(%player,%item,%pos)
{
	if (STR2Pack::deployShape(%player,%item)) {
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

function STR2Pack::deployShape(%player,%item)
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
								%turret = newObject("remoteTurret","Turret",DeployableFlak,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Thumper AAA #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Thumper AAA deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "STR2Pack"]++;
//								echo("MSG: ",%client," deployed a Thumper AAA Turret");
								//	Remote turrets - kill points to player that deploy them
//								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
						%points = 4;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%turret)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
								return true;
							}
						}
						else 
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets~wAccess_Denied.wav");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area~wAccess_Denied.wav");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");

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
			Client::sendMessage(%client,0,"Unable to deploy - You are in the way~wAccess_Denied.wav");
		else
			Client::sendMessage(%client,0,"Unable to deploy - A Player is in the way~wAccess_Denied.wav");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - An Item in the way~wAccess_Denied.wav");

	deleteObject(%set);
	return 0;	
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData FlamerPackImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData FlamerPack
{
	description = "Flamer Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
   heading = "lDeployable Turrets";
	imageType = FlamerPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 75;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlamerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function FlamerPack::onDeploy(%player,%item,%pos)
{
	if (FlamerPack::deployShape(%player,%item)) {
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

function FlamerPack::deployShape(%player,%item)
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
					%camera = newObject("remoteTurret","Turret",FlamerTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Flamer Turret #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Flamer Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "FlamerPack"]++;
//						Client::sendMessage(Player::getClient(%client), 3,"Flamer Turret deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
								 Client::setOwnedObject(%client, %player);
						%points = 2;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%camera)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
		}
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");
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
			Client::sendMessage(%client,0,"Unable to deploy - You are in the way~wAccess_Denied.wav");
		else
			Client::sendMessage(%client,0,"Unable to deploy - A Player is in the way~wAccess_Denied.wav");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - An Item in the way~wAccess_Denied.wav");

	deleteObject(%set);
	return 0;	
}

//----------------------------------------------------------------------------
ItemImageData Ultra20PackImage
{
	shapeFile = "chainturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData Ultra20Pack
{
	description = "Ultra-AC20 Turret";
	shapeFile = "chainturret";
	className = "Backpack";
   heading = "lDeployable Turrets";
	imageType = Ultra20PackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Ultra20Pack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function Ultra20Pack::onDeploy(%player,%item,%pos)
{
	if (Ultra20Pack::deployShape(%player,%item)) {
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

function Ultra20Pack::deployShape(%player,%item)
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
								Gamebase::setMapName(%turret,"Ultra20 Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Ultra-AC20 Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "Ultra20Pack"]++;
//								Client::sendMessage(Player::getClient(%client), 3,"Ultra-AC20 Turret deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
								//	Remote turrets - kill points to player that deploy them
//								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
						%points = 3;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%turret)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
								return true;
							}
						}
						else 
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets~wAccess_Denied.wav");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area~wAccess_Denied.wav");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");

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
			Client::sendMessage(%client,0,"Unable to deploy - You are in the way~wAccess_Denied.wav");
		else
			Client::sendMessage(%client,0,"Unable to deploy - A Player is in the way~wAccess_Denied.wav");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - An Item in the way~wAccess_Denied.wav");

	deleteObject(%set);
	return 0;	
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData PPCPackImage
{
	shapeFile = "hellfiregun";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PPCPack
{
	description = "PPC Turret";
	shapeFile = "hellfiregun";
	className = "Backpack";
   heading = "lDeployable Turrets";
	imageType = PPCPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PPCPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PPCPack::onDeploy(%player,%item,%pos)
{
	if (PPCPack::deployShape(%player,%item)) {
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

function PPCPack::deployShape(%player,%item)
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
								%turret = newObject("remoteTurret","Turret",PPCTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"PPC Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"PPC Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "PPCPack"]++;
//						Client::sendMessage(Player::getClient(%client), 3,"PPC Turret deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
								//	Remote turrets - kill points to player that deploy them
//								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
						%points = 4;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%turret)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
								return true;
							}
						}
						else 
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets~wAccess_Denied.wav");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area~wAccess_Denied.wav");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");

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
			Client::sendMessage(%client,0,"Unable to deploy - You are in the way~wAccess_Denied.wav");
		else
			Client::sendMessage(%client,0,"Unable to deploy - A Player is in the way~wAccess_Denied.wav");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - An Item in the way~wAccess_Denied.wav");

	deleteObject(%set);
	return 0;	
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LongTomPackImage
{
	shapeFile = "mortar_turret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.5;
	firstPerson = false;
};

ItemData LongTomPack
{
	description = "Long Tom Artillery";
	shapeFile = "mortar_turret";
	className = "Backpack";
   heading = "lDeployable Turrets";
	imageType = LongTomPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LongTomPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LongTomPack::onDeploy(%player,%item,%pos)
{
	if (LongTomPack::deployShape(%player,%item)) {
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

function LongTomPack::deployShape(%player,%item)
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
								%turret = newObject("remoteTurret","Turret",LongTom,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"LongTom Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Long Tom Artillery deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "LongTomPack"]++;
//								Client::sendMessage(Player::getClient(%client), 3,"Long Tom deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
								//	Remote turrets - kill points to player that deploy them
//								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
						%points = 4;
						%client.score = %client.score + %points;
						$hvGood[%client] = $hvGood[%client] + %points; 
						%hvRatio = floor(($hvGood[%client]/($hvGood[%client] + $hvBad[%client]))*100);
						bottomprint(%client,"<jc><f0>You gain <f1>" @ %points @ "<f0> points for deploying a <f1>" @ (GameBase::getDataName(%turret)).description @ "<f0>.\nYour current efficiency percentage is <f2>" @ %hvRatio @ "",5);
		   				Game::refreshClientScore(%client);
								return true;
							}
						}
						else 
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets~wAccess_Denied.wav");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area~wAccess_Denied.wav");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");

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
			Client::sendMessage(%client,0,"Unable to deploy - You are in the way~wAccess_Denied.wav");
		else
			Client::sendMessage(%client,0,"Unable to deploy - A Player is in the way~wAccess_Denied.wav");
	}
	else
		Client::sendMessage(%client,0,"Unable to deploy - An Item in the way~wAccess_Denied.wav");

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
				else {
					Client::sendMessage(%client,0,"Deploy surface is too steep~wAccess_Denied.wav");
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or structures~wAccess_Denied.wav");
			}
		}
		else {
			Client::sendMessage(%client,0,"Deploy position out of range ~wAccess_Denied.wav");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s~wAccess_Denied.wav");
	return false;
}

//----------------------------------------------------------------------------
$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "iAttatchments";
   shadowDetailMask = 4;
   price = 15;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}

//----------------------------------------------------------------------------
ItemData GrenadeEQ
{
   description = "1----------Grenades------------";
   shapeFile = "grenade";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 1;
	className = "HandAmmo";
};

ItemData NukeGrenade
{
   description = "Pentaglyceride Grenade";
   shapeFile = "mortar";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 15;
	className = "Grenade";
};

ItemData InfernoGrenade
{
   description = "Inferno Grenade";
   shapeFile = "grenade";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 12;
	className = "Grenade";
};

ItemData SmokeHandGrenade
{
   description = "Smoke Grenade";
   shapeFile = "grenade";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 10;
	className = "Grenade";
};

ItemData Grenade
{
//	showInventory = false;//++++++
   description = "Grenade";
   shapeFile = "grenade";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 15;
	className = "HandAmmo";
};

function Grenade::onUse(%player,%item)
{
if($matchStarted) 
	{
	if(%player.throwTime < getSimTime()) 
		{
		if(Player::getItemCount(%player, FCC) == 1)
			{
			%obj = newObject("","Mine","Napalmgrenade");
	 		addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			Player::decItemCount(%player, Grenade);
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			}
		else
			{
			%obj = newObject("","Mine","Handgrenade");
	 		addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			Player::decItemCount(%player, Grenade);
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			}
		}
	}
}

function Grenade2::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime())
		{
			%client = Player::getClient(%player);
			if($GDT[%client] = 1)
			{
				%item = NukeGrenade;
				%name1 = "Handgrenade";
//				%name2 = "Blank"; //"Handgrenade2";
				%name3 = "Handgrenade3";
//				%name4 = "Blank";
			}
			else if($GDT[%client] = 2)
			{
				%item = InfernoGrenade;
				%name1 = "Napalmgrenade";
//				%name2 = "Blank";
				%name3 = "Napalmgrenade2";
//				%name4 = "Blank";
			}
			else if($GDT[%client] = 3)
			{
				%item = SmokeHandGrenade;
				%name1 = "SmokerGrenade";
//				%name2 = "Blank";
				%name3 = "SmokerGrenade2";
//				%name4 = "Blank";
			}
			else
				return;
			if(Player::getItemCount(%player, FCC) == 1)
				{
				%obj3 = newObject("","Mine",%name3);
//				%obj4 = newObject("","Mine",%name4);
 	 	 		addToSet("MissionCleanup", %obj3);
 	 	 		addToSet("MissionCleanup", %obj4);
				GameBase::throw(%obj3,%player,9 * %client.throwStrength,false);
				GameBase::throw(%obj4,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
			else
				{
				%obj1 = newObject("","Mine",%name1);
//				%obj2 = newObject("","Mine",%name2);
 	 	 		addToSet("MissionCleanup", %obj1);
 	 	 		addToSet("MissionCleanup", %obj2);
				GameBase::throw(%obj1,%player,9 * %client.throwStrength,false);
				GameBase::throw(%obj2,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
//			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
		}
	}
}

function Grenade3::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime())
		{
			%client = Player::getClient(%player);
			if(Player::getItemCount(%player, NukeGrenade) > 0)
			{
				%item = NukeGrenade;
				%name1 = "Handgrenade";
				%name2 = "Blank"; //"Handgrenade2";
				%name3 = "Handgrenade3";
				%name4 = "Blank";
			}
			else if(Player::getItemCount(%player, InfernoGrenade) > 0)
			{
				%item = InfernoGrenade;
				%name1 = "Napalmgrenade";
				%name2 = "Blank";
				%name3 = "Napalmgrenade2";
				%name4 = "Blank";
			}
			else if(Player::getItemCount(%player, SmokeHandGrenade) > 0)
			{
				%item = SmokeHandGrenade;
				%name1 = "SmokerGrenade";
				%name2 = "Blank";
				%name3 = "SmokerGrenade2";
				%name4 = "Blank";
			}
			else
				return;
			if(Player::getItemCount(%player, FCC) == 1)
				{
				%obj3 = newObject("","Mine",%name3);
				%obj4 = newObject("","Mine",%name4);
 	 	 		addToSet("MissionCleanup", %obj3);
 	 	 		addToSet("MissionCleanup", %obj4);
				GameBase::throw(%obj3,%player,9 * %client.throwStrength,false);
				GameBase::throw(%obj4,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
			else
				{
				%obj1 = newObject("","Mine",%name1);
				%obj2 = newObject("","Mine",%name2);
 	 	 		addToSet("MissionCleanup", %obj1);
 	 	 		addToSet("MissionCleanup", %obj2);
				GameBase::throw(%obj1,%player,9 * %client.throwStrength,false);
				GameBase::throw(%obj2,%player,9 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				}
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
		}
	}
}

//----------------------------------------------------------------------------
ItemData MineEQ
{
   description = "1-------------Mines--------------";
   shapeFile = "mineammo";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 1;
	className = "Mine";
};

ItemData VibroMine
{
   description = "Vibro Mine";
   shapeFile = "discammo";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 20;
	className = "Mine";
};

ItemData InfernoMine
{
   description = "Inferno Mine";
   shapeFile = "discammo";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 15;
	className = "Mine";
};

ItemData MineAmmo
{
//	showInventory = false;//++++++
   description = "Mine";
   shapeFile = "mineammo";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
if($matchStarted) 
	{
	if(%player.throwTime < getSimTime()) 
		{
		if(Player::getItemCount(%player, FCC) == 1)
			{
			%obj = newObject("","Mine","antipersonelMine");//++++++++
//			%obj = newObject("","Mine","IMine");
 			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,20 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			Player::decItemCount(%player, MineAmmo);
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			}
		else
			{
			%obj = newObject("","Mine","antipersonelMine");
 			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,20 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			Player::decItemCount(%player, MineAmmo);
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			}
		}
	}
}

function MineAmmo3::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime())
		{
			%client = Player::getClient(%player);
			if(Player::getItemCount(%player, VibroMine) > 0)
			{
				%item = VibroMine;
				%name1 = "antipersonelMine";
				%name3 = "DmMine";
			}
			else if(Player::getItemCount(%player, InfernoMine) > 0)
			{
				%item = InfernoMine;
				%name1 = "IMine";
				%name3 = "DmIMine";
			}
			else
				return;
			%armor = Player::getArmor(%player);
			if(%armor == "dmarmor")
				{
				%obj3 = newObject("","Mine",%name3);
 	 	 		addToSet("MissionCleanup", %obj3);
				GameBase::throw(%obj3,%player,20 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				%client = Player::getClient(%player);
				GameBase::setTeam (%obj3,GameBase::getTeam (%client));
				}
			else
				{
				%obj1 = newObject("","Mine",%name1);
 	 	 		addToSet("MissionCleanup", %obj1);
				GameBase::throw(%obj1,%player,20 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				%client = Player::getClient(%player);
				GameBase::setTeam (%obj1,GameBase::getTeam (%client));
				}
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, MineAmmo);
		}
	}
}

//---------
ItemData a
{
   description = "a";
   shapeFile = "grenade";
   showInventory = false;
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 0;
   className = "HandAmmo";
};
function a::onUse(%player,%item)
{
	 schedule("Player::1(" @ %player @ ");", %timedelay);
}
ItemData b
{
   description = "b";
   shapeFile = "grenade";
   showInventory = false;
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 0;
   className = "HandAmmo";
};
function b::onUse(%player,%item)
{
	 schedule("Player::2(" @ %player @ ");", %timedelay);
}
ItemData c
{
   description = "c";
   shapeFile = "grenade";
   showInventory = false;
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 0;
   className = "HandAmmo";
};
function c::onUse(%player,%item)
{
	 schedule("Player::3(" @ %player @ ");", %timedelay);
}
ItemData d
{
   description = "d";
   shapeFile = "grenade";
   showInventory = false;
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 0;
   className = "HandAmmo";
};
function d::onUse(%player,%item)
{
	 schedule("Player::4(" @ %player @ ");", %timedelay);
}
ItemData e
{
   description = "e";
   shapeFile = "grenade";
   showInventory = false;
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 0;
   className = "HandAmmo";
};
function e::onUse(%player,%item)
{
	 schedule("Player::5(" @ %player @ ");", %timedelay);
}
ItemData f
{
   description = "f";
   shapeFile = "grenade";
   showInventory = false;
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 0;
   className = "HandAmmo";
};
function f::onUse(%player,%item)
{
	 schedule("Player::6(" @ %player @ ");", %timedelay);
}

//----------------------------------------------------------------------------
ItemData Beacon
{
   description = "Beacon";
   showInventory = false;//++++++++++++++++
   shapeFile = "sensor_small";
   heading = "hExplosives";
   shadowDetailMask = 4;
   price = 50;
	className = "HandAmmo";
};

function Beacon::onUse(%player,%item, %client) //%clientID++++++
{
	%armor = Player::getArmor(%player);
	%energy = GameBase::getEnergy(%player);
	if (%armor == "larmor")
	{
	   %enVal  = 50.0;
	   %vertical = 170.0;
	   %velocity = 210.0;
	}
	else if (%armor == "xarmor")
	{
	   %enVal  = 45.0;
	   %vertical = 136.0;
	   %velocity = 168.0;
	}
	else if (%armor == "parmor")
	{
	   %enVal  = 50.0;
	   %vertical = 225.0;
	   %velocity = 225.0;
	}
	else if (%armor == "driver")
	{
%velPlayer = Item::getVelocity(%player);
if((Player::getLastContactCount(%player) != 0) || (%velplayer != 0))//++++
	{
	Client::sendMessage(Player::getClient(%player), 1,"-Gyros Destabilized- Remain motionless to Transform~wError_Message.wav");
	return;
	}
else
	{//++++
	%client = Player::getClient(%player); 
	if (GameBase::getLOSInfo(%player,500))
		{ 
		%obj = getObjectType($los::object); 
		if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj != "SimTerrain") 
			{ 
			%set = newObject("set",SimSet);
			deleteObject(%set); 
			if(checkDeployArea(%client,$los::position)) 
				{ 
				%rot = GameBase::getRotation(%player); 
				%phase = newObject("",flier,PH,true); 
				addToSet("MissionCleanup", %phase); 
				GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
				%markerPos = GameBase::getPosition(%client);//+++++
				GameBase::setPosition(%phase,%markerPos);//+++++
				GameBase::setRotation(%phase,%rot); 
				GameBase::startFadeIn(%phase); playSound(SoundElevatorStop,$los::position); 
				$TeamItemCount[GameBase::getTeam(%player) @ "PHVehicle"]++; return true; 
				} 
			else
			return;
			}
		else
		return;
		}
	else
	%rot = GameBase::getRotation(%player); 
	%phase = newObject("",flier,PH,true); 
	addToSet("MissionCleanup", %phase); 
	GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
	%markerPos = GameBase::getPosition(%client);
	GameBase::setPosition(%phase,%markerPos);
	GameBase::setRotation(%phase,%rot); 
	$TeamItemCount[GameBase::getTeam(%player) @ "PHVehicle"]++; return true; 
	}//++++
	}
	else if (%armor == "carmor")
	{
	   %enVal  = 90.0;
	   %vertical = 220.0;
	   %velocity = 300.0;
	}
	else if (%armor == "dmarmor")
	{
	   %enVal  = 50.0;
	   %vertical = 225.0;
	   %velocity = 225.0;
	}
	else if (%armor == "marmor")
	{
	   %enVal  = 90.0;
	   %vertical = 275.0;
	   %velocity = 300.0;
	}
	else if (%armor == "hbarmor")
	{
	   %enVal  = 70.0;
	   %vertical = 400.0; //450.0;+++++++
	   %velocity = 350.0; //400.0;+++++++
	}
	else if (%armor == "aarmor")
	{
	   %enVal  = 70.0;
	   %vertical = 400.0;
	   %velocity = 400.0;
	}
	else if (%armor == "warmor")
	{
	   %enVal  = 70.0;
	   %vertical = 425.0;
	   %velocity = 425.0;
	}
	else if (%armor == "rarmor")
	{
	   %enVal  = 80.0;
	   %vertical = 550.0;
	   %velocity = 500.0;
	}
	else if (%armor == "barmor")
	{
	   %enVal  = 90.0;
	   %vertical = 490.0; //550.0;+++++++
	   %velocity = 425.0; //500.0;+++++++
	}
	else if (%armor == "yarmor")
	{
	   %enVal  = 90.0;
	   %vertical = 600.0;
	   %velocity = 500.0;
	}
	else if (%armor == "harmor")
	{
	   %enVal  = 130.0;
	   %vertical = 600.0;
	   %velocity = 500.0;
	}
   %energy = %energy - %enVal;
   if($matchStarted)
	{
	if(%player.throwTime < getSimTime())
	 {
		if(%energy > 35)
		 {
			Client::sendMessage(Player::getClient(%player),0,"-Jump Jet Booster ENGAGED-~wflierrocket.wav");
			GameBase::setEnergy(%player,%energy);
			%velPlayer = Item::getVelocity(%player);
			if(%velPlayer == 0)
				{
				%Power1 = Vector::getFromRot(GameBase::getRotation(%player),0, %vertical);
				Player::applyImpulse(%player,%Power1);
				}
				else
				{
				%Power2 = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
				Player::applyImpulse(%player,%Power2);
				}
		 }
		 else	
		{
		 Client::sendMessage(Player::getClient(%player), 1,"-Mech heat level too high, Jump Jet Booster OFFLINE- ~wC_BuySell.wav");
		} 
		}
	}
}

//----------------------------------------------------------------------------
ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "iAttatchments";
	shadowDetailMask = 4;
  	price = 1;
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
		Player::setItemCount(%clientId,PPC,1);
		Player::setItemCount(%clientId,Ultra10,1);
		Player::setItemCount(%clientId,HVAC10,1);//+++++++++++++
		Player::setItemCount(%clientId,GaussRifle,1);
		Player::setItemCount(%clientId,Flamer,1);
		Player::setItemCount(%clientId,ArrowIV,1);
		Player::setItemCount(%clientId,SniperCannon,1);
		Player::setItemCount(%clientId,MachineGun,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,SmokeLauncher,1);
		Player::setItemCount(%clientId,LRM5,1);
		Player::setItemCount(%clientId,LRM10,1);
		Player::setItemCount(%clientId,LRM20,1);
		Player::setItemCount(%clientId,AC5,1);
		Player::setItemCount(%clientId,AC10,1);
		Player::setItemCount(%clientId,AC20,1);
		Player::setItemCount(%clientId,Ultra5,1);
		Player::setItemCount(%clientId,Ultra20,1);
		Player::setItemCount(%clientId,MedLas,1);
		Player::setItemCount(%clientId,MedPLas,1);
		Player::setItemCount(%clientId,LrgLas,1);
		Player::setItemCount(%clientId,LrgPLas,1);
		Player::setItemCount(%clientId,STR2,1);
		Player::setItemCount(%clientId,STR4,1);
		Player::setItemCount(%clientId,STR6,1);

		Player::setItemCount(%clientId,SmokeAmmo,200);
		Player::setItemCount(%clientId,HMechMortarAmmo,200);
		Player::setItemCount(%clientId,LMechMortarAmmo,200);
		Player::setItemCount(%clientId,LRMAmmo,200);
		Player::setItemCount(%clientId,STRAmmo,200);
		Player::setItemCount(%clientId,ArrowIVAmmo,200);
		Player::setItemCount(%clientId,AC5Ammo,200);
		Player::setItemCount(%clientId,AC10Ammo,200);
		Player::setItemCount(%clientId,AC20Ammo,200);
		Player::setItemCount(%clientId,Ultra5Ammo,200);
		Player::setItemCount(%clientId,Ultra10Ammo,200);
		Player::setItemCount(%clientId,HVAC10Ammo,200);//++++++++
		Player::setItemCount(%clientId,Ultra20Ammo,200);
		Player::setItemCount(%clientId,MachineGunAmmo,200);
		Player::setItemCount(%clientId,GaussGunAmmo,200);
		Player::setItemCount(%clientId,SniperGunAmmo,200);

// 	   	Player::setItemCount(%clientId,NukeGrenade, 200);//++++
 //	   	Player::setItemCount(%clientId,InfernoGrenade, 200);//+++++++
 //	   	Player::setItemCount(%clientId,SmokeHandGrenade, 200);//++++
 	   	Player::setItemCount(%clientId,Grenade, 200);
	      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,SmokeAmmo,$ItemMax[%armor, SmokeAmmo]);
		Player::setItemCount(%clientId,HMechMortarAmmo,$ItemMax[%armor, HMechMortarAmmo]);
		Player::setItemCount(%clientId,LMechMortarAmmo,$ItemMax[%armor, LMechMortarAmmo]);
		Player::setItemCount(%clientId,LRMAmmo,$ItemMax[%armor, LRMAmmo]);
		Player::setItemCount(%clientId,STRAmmo,$ItemMax[%armor, STRAmmo]);
		Player::setItemCount(%clientId,ArrowIVAmmo,$ItemMax[%armor, ArrowIVAmmo]);
		Player::setItemCount(%clientId,AC5Ammo,$ItemMax[%armor, AC5Ammo]);
		Player::setItemCount(%clientId,AC10Ammo,$ItemMax[%armor, AC10Ammo]);
		Player::setItemCount(%clientId,AC20Ammo,$ItemMax[%armor, AC20Ammo]);
		Player::setItemCount(%clientId,Ultra5Ammo,$ItemMax[%armor, Ultra5Ammo]);
		Player::setItemCount(%clientId,Ultra10Ammo,$ItemMax[%armor, Ultra10Ammo]);
		Player::setItemCount(%clientId,Ultra20Ammo,$ItemMax[%armor, Ultra20Ammo]);
		Player::setItemCount(%clientId,HVAC10Ammo,$ItemMax[%armor, HVAC10Ammo]);//++++++++
		Player::setItemCount(%clientId,MachineGunAmmo,$ItemMax[%armor, MachineGunAmmo]);
		Player::setItemCount(%clientId,GaussGunAmmo,$ItemMax[%armor, GaussGunAmmo]);
		Player::setItemCount(%clientId,SniperGunAmmo,$ItemMax[%armor, SniperGunAmmo]);

//	      Player::setItemCount(%clientId,NukeGrenade, $ItemMax[%armor, NukeGrenade]);//++++
//	      Player::setItemCount(%clientId,InfernoGrenade, $ItemMax[%armor, InfernoGrenade]);//++++
//	      Player::setItemCount(%clientId,SmokeHandGrenade, $ItemMax[%armor, SmokeHandGrenade]);//+++++
	      Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]);
	      Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);
		Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);

		Player::setItemCount(%clientId,RepairKit,1);
	}
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData STRPackLImage
 { 
shapeFile = "paintgun"; 
mountPoint = 2; 
mountOffset = {0.17, 0.35, 0.3};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData STRPackL
{ 
description = "Med Las"; 
shapeFile = "paintgun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = STRPackLImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++
ItemImageData STRPackPImage
 { 
shapeFile = "paintgun"; 
mountPoint = 2; 
mountOffset = {0.31, 0.35, 0.4};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
};
ItemData STRPackP
{ 
description = "Med Las"; 
shapeFile = "paintgun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = STRPackPImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData XgunAImage
 { 
shapeFile = "energygun"; 
mountPoint = 2; 
mountOffset = {0.15, 0, 0};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.571, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData XgunA
{ 
description = "Med Las"; 
shapeFile = "energygun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = XgunAImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
ItemImageData XgunBImage
 { 
shapeFile = "energygun"; 
mountPoint = 2; 
mountOffset = {-0.15, 0, 0};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.571, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData XgunB
{ 
description = "Med Las"; 
shapeFile = "energygun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = XgunBImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//+++++++++++++++++++++++
ItemImageData DRgunAImage
 { 
shapeFile = "energygun"; 
mountPoint = 2; 
mountOffset = {0.2, 0, 0.1};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.571, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData DRgunA
{ 
description = "Med Las"; 
shapeFile = "energygun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = DRgunAImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
ItemImageData DRgunBImage
 { 
shapeFile = "energygun"; 
mountPoint = 2; 
mountOffset = {-0.2, 0, 0.1};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.571, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData DRgunB
{ 
description = "Med Las"; 
shapeFile = "energygun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = DRgunBImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++
ItemImageData MLPackC2Image
 { 
shapeFile = "energygun"; 
mountPoint = 2; 
mountOffset = {0.13, 0.3, -0.3};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.0, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData MLPackC2
{ 
description = "Med Las"; 
shapeFile = "paintgun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = MLPackC2Image; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++
ItemImageData MLPackCImage
 { 
shapeFile = "paintgun"; 
mountPoint = 2; 
mountOffset = {0.16, 0.4, 0.2};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData MLPackC
{ 
description = "Med Las"; 
shapeFile = "paintgun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = MLPackCImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++
ItemImageData UltraPackMImage
 { 
shapeFile = "chaingun"; 
mountPoint = 2; 
mountOffset = {0.25, 0.1, 0.4};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, -0.0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData UltraPackM
{ 
description = "Ultra-AC20"; 
shapeFile = "chaingun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = UltraPackMImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//+++++++++++++++++++++++++
ItemImageData MLPackHBImage
 { 
shapeFile = "paintgun"; 
mountPoint = 2; 
mountOffset = {0.25, 0.55, 0.2};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData MLPackHB
{ 
description = "Med Las"; 
shapeFile = "paintgun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = MLPackHBImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++
ItemImageData GaussPackHBImage
 { 
shapeFile = "mortargun"; 
mountPoint = 2; 
mountOffset = {0.35, 0.0, 0.4};
mountRotation = { 0.2, 0, 0.15 }; 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData GaussPackHB
{ 
description = "GaussRifle"; 
shapeFile = "mortargun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = GaussPackHBImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//+++++++++++++++++++++++++
ItemImageData LRMPackAImage 
{ 
shapeFile = "ammo2"; 
mountPoint = 2;
mountOffset = { 0.35, -0.3, 0.6 }; //{ 0.3, 0.11, 0.6 };+++++++++
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.9, 3.1, 0 }; //{ 0.2, 3.1, 0 };++++++++++
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData LRMPackA
{ 
description = "LRM-15"; 
shapeFile = "ammo2"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = LRMPackAImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++
ItemImageData LRMPackA2Image 
{ 
shapeFile = "ammo2"; 
mountPoint = 2;
mountOffset = { -0.35, -0.3, 0.6 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.9, 3.1, 0 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData LRMPackA2
{ 
description = "LRM-15"; 
shapeFile = "ammo2"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = LRMPackA2Image; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++
ItemImageData MLPackAImage
 { 
shapeFile = "paintgun"; 
mountPoint = 2; 
mountOffset = {0.0, 0.5, -0.1};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData MLPackA
{ 
description = "Med Las"; 
shapeFile = "paintgun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = MLPackAImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//+++++++++++++++++++++++++
ItemImageData LRMPackWImage 
{ 
shapeFile = "ammo2"; 
mountPoint = 2;
mountOffset = { 0.4, 0.11, 0.75 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 3.1, 0 }; //{ 0.2, 3.1, 0 };++++++++++
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData LRMPackW
{ 
description = "LRM-15"; 
shapeFile = "ammo2"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = LRMPackWImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//+++++++++++++++++++++++++
ItemImageData LRMPackW2Image 
{ 
shapeFile = "radar_small"; 
mountPoint = 2;
mountOffset = { -0.4, -0.1, 0.45 }; //{ 0.3, 0.11, 0.6 };+++++++++
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.8, 3.1, 0 }; //{ 0.2, 3.1, 0 };++++++++++
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData LRMPackW2
{ 
description = "radar"; 
shapeFile = "radar_small"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = LRMPackW2Image; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//+++++++++++++++++++++++++
ItemImageData LRMPackBImage 
{ 
shapeFile = "ammo2"; 
mountPoint = 2;
mountOffset = { 0.4, 0.25, 0.85 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 3.3, 0 }; //{ 0.2, 0, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData LRMPackB
{ 
description = "LRM-15"; 
shapeFile = "ammo1"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = LRMPackBImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
}; 
//++++++++++++++++++++++++++
ItemImageData MLPackBImage
 { 
shapeFile = "paintgun"; 
mountPoint = 2; 
mountOffset = {-0.35, 0.6, 0.4};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData MLPackB
{ 
description = "Med Las"; 
shapeFile = "paintgun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = MLPackBImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++
ItemImageData MLPackB2Image
 { 
shapeFile = "paintgun"; 
mountPoint = 2; 
mountOffset = {0.3, 0.65, 0.35};
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, 0.15 }; 
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData MLPackB2
{ 
description = "Med Las"; 
shapeFile = "paintgun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = MLPackB2Image; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++
ItemImageData RadarPackHImage 
{ 
shapeFile = "radar_small"; 
mountPoint = 2;
mountOffset = { 0.42, 0.25, 0.7 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.6, 3.1, 0 }; //{ 0.2, 0, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData RadarPackH
{ 
description = "Radar"; 
shapeFile = "radar_small"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = RadarPackHImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};
//++++++++++++++++++++++++++
ItemImageData RadarPackH2Image 
{ 
shapeFile = "radar_small"; 
mountPoint = 2;
mountOffset = { -0.42, 0.25, 0.7 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 1.6, 3.1, 0 }; //{ 0.2, 0, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData RadarPackH2
{ 
description = "Radar"; 
shapeFile = "radar_small"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = RadarPackH2Image; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
}; 
//+++++++++++++++++++++++++
ItemImageData MLPackHImage 
{
shapeFile = "paintgun"; 
mountPoint = 2; 
mountOffset = { 0.3, 0.65, 0.4 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 3.3, 0 }; //{ 0.2, 0, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData MLPackH
{ 
description = "LRM-15"; 
shapeFile = "ammo1"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = MLPackHImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
}; 
//++++++++++++++++++++++++++
ItemImageData LRMPackHImage 
{
shapeFile = "chaingun"; 
mountPoint = 2; 
mountOffset = { 0.25, 0.5, 0.1 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 3.3, 0 }; //{ 0.2, 0, 0 };
//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData LRMPackH
{ 
description = "LRM-15"; 
shapeFile = "ammo1"; 
heading = "hExplosives"; 
shadowDetailMask = 4;
 imageType = LRMPackHImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
}; 
//++++++++++++++++++++++++++
ItemImageData GaussPackHImage
 { 
shapeFile = "mortargun"; 
mountPoint = 2; 
mountOffset = {-0.25, 0.2, 0.0};//{ -0.4, 0.1, 0.4 }; +++++ {Side-Side(+=center),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 0, 0.15 }; 
weaponType = 0; 
accuFire = true; 
reloadTime = 3.0; 
fireTime = 0.0; 
lightType = 3; 
lightRadius = 3; 
lightTime = 1; 
lightColor = { 0.6, 1, 1.0 }; 
}; 
ItemData GaussPackH
{ 
description = "GaussRifle"; 
shapeFile = "mortargun"; 
heading = "hExplosives"; 
shadowDetailMask = 4; 
imageType = GaussPackHImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
};

ItemImageData UnBeaconImage
{  	shapeFile		= "sensor_small";
	mountPoint		= 3;
	lightType		= 2;   // Pulsing
	lightRadius		= 5;
	lightTime		= 0.1;
	lightColor		= { 0.5, 1, 0.5 };
//	sfxambient		= SoundUnBeacon;
};
ItemData UnBeacon
{	description		= "UnBeacon";
	shapeFile		= "sensor_small";
	classname		= "Item"; //"Marker";
	imageType		= UnBeaconImage;
	shadowDetailMask = 4;
	price			= 1;
	hudIcon		= "deployable";
	showWeaponBar	= false;
	hiliteOnActive	= false;
};

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

//+++++++++++++++++++++++++++++++++++++++++++++++++++
function MissileImage::Fire(%player, %slot)
{
%new = Player::getClient(%player);
if(Player::getMountedItem(%player,$WeaponSlot) == ArrowIV)//++++code for ArrowIV/FCC Pod requirement++++
	{
	if(Player::getMountedItem(%player,$BackpackSlot) != FCCPod)
		{
		Client::sendMessage(Player::getClient(%player), 1,"-FCC Pod required to fire-~wError_Message.wav");
		Player::trigger(%player,$WeaponSlot,false);
		return;
		}
	%velPlayer = Item::getVelocity(%player);
	if(GameBase::getLOSInfo(%player,$HVLOSrange[%new]))
		{
		}
	else
		{ 
		//++++hack to prevent crash-on-spawn of ArrowIV++++
		if((Player::getLastContactCount(%player) != 0) || (%velplayer != 0))//++++
			{
			Client::sendMessage(Player::getClient(%player), 1,"-Gyros Destabilized- Remain motionless to fire~wError_Message.wav");
			Player::trigger(%player,$WeaponSlot,false);
			return;
			}
		}
	}//++++end ArrowIV++++
	if(Player::getItemCount(%player, FCC))//++++used for LBX-ACs due to shotgun mode ammo consumption++++
		{
		%HVammoMin[%new] = $HVammocount2[%new];
		}
		else
		{
		%HVammoMin[%new] = $HVammocount1[%new];
		}//++++end LBX ammo code++++
		if($WeaponAmmo[$HVammoT[%new]] == "")//++++hack to avoid error message for non-ammo weapons++++
			{
			%AmmoCount = 100;
			}
		else
			{
			%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[$HVammoT[%new]]);
			} 
		if(%AmmoCount >= %HVammoMin[%new]) 
			{
			if($HVtracerToggle[%new] == 1)//++++start section HVtracer++++
				{ 
				%enVal = $HVenVal1[%new]; 
				%energy = GameBase::getEnergy(%player); 
				%energy = %energy - %enVal; 
				if(%energy > $HVenergy1[%new])
					{ 
					%velocity = $HVknockback3[%new];
					%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
					Player::applyImpulse(%player,%sniperPower);
					 %trans = GameBase::getMuzzleTransform(%player);
					 %vel = Item::getVelocity(%player);
					 Projectile::spawnProjectile($HVtracer[%new],%trans,%player,%vel);
					if($WeaponAmmo[$HVammoT[%new]] != "")
						{
						 Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],1);
						} 
					 playSound($HVfiresound1[%new],GameBase::getPosition(%player));
					}//++++end section HVtracer++++
				else
					{
					Player::trigger(%player,$WeaponSlot,false);
					Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
					return;
					}
				}
			if(GameBase::getLOSInfo(%player,$HVLOSrange[%new])) 
				{ 
				%object = getObjectType($los::object); 
				%targetId = GameBase::getOwnerClient($los::object);
				%name = Client::getName(%targetId);
				%client = GameBase::getOwnerClient(%player);
				if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor") 
					{//++++start section HVlockToggle++++
					if($HVlockToggle[%new] < 1)
						{ 
						for(%i = $HVbursts[%new]; %i > 0; %i--) 
							{ 
							schedule("MissileImage::OnShootSmart(" @ %player @ ");", %timedelay); 
							%timedelay = %timedelay + $HVtime1[%new]; 
							} 
						}
					else//++++end section HVlockToggle++++
						{//++++start suppression section++++
						%supression = Player::getSensorSupression(%targetId);
						if(%supression >= 1) 
							{
							Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav"); 
							for(%i = $HVbursts[%new]; %i > 0; %i--) 
								{ 
								schedule("MissileImage::OnShootDumb(" @ %player @ ");", %timedelay); 
								%timedelay = %timedelay + $HVtime1[%new]; 
								} 
							}
						else//++++end suppression section++++
							{
							Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
							Client::sendMessage(%targetId,1,"-WARNING- "@$HVwarning[%new]@" lock detected~wAccess_Denied.wav");
							for(%i = $HVbursts[%new]; %i > 0; %i--) 
								{ 
								schedule("MissileImage::OnShootSmart(" @ %player @ ");", %timedelay); 
								%timedelay = %timedelay + $HVtime1[%new]; 
								} 
							}
						}//++++add due to HVlockToggle++++
					}//++++add due to suppression++++
				else 
					{ 
					for(%i = $HVbursts[%new]; %i > 0; %i--) 
						{ 
						schedule("MissileImage::OnShootDumb(" @ %player @ ");", %timedelay); 
						%timedelay = %timedelay + $HVtime1[%new]; 
						} 
					} 
				} 
			else
				{ 
				for(%i = $HVbursts[%new]; %i > 0; %i--) 
					{ 
					schedule("MissileImage::OnShootDumb2(" @ %player @ ");", %timedelay); 
					%timedelay = %timedelay + $HVtime1[%new]; 
					}
				} 
			Player::trigger(%player,$WeaponSlot,$HVtriggerToggle[%new]); //++++++
			} 
		else
			{
			if((%AmmoCount > 0) && (%AmmoCount < %HVammoMin[%new])) 
				{ 
				Client::sendMessage(Player::getClient(%player), 1,"-Emptying Magazine- ~wError_Message.wav"); 
				schedule("MissileImage::OnEmpty(" @ %player @ ");", %timedelay);
				%timedelay = %timedelay + $HVtime1[%new]; 
				} 
			else 
				{ 
				Player::trigger(%player,$WeaponSlot,false); 
				Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav"); 
				playSound(SoundDryFire,GameBase::getPosition(%player)); 
				}
			}
		}
function MissileImage::OnShootSmart(%player,%slot)
{
%new = Player::getClient(%player);
if(Player::getItemCount(%player, FCC) == 1)//++++ 
	{
	%enVal = $HVenVal2[%new]; 
	%energy = GameBase::getEnergy(%player); 
	%energy = %energy - %enVal; 
	if(%energy > $HVenergy2[%new])
		{ 
		for(%i = $HVroundsBurst2[%new]; %i > 0; %i--) //++++FCC burst multiplier++++
			{//++++added due to burst multiplier++++
			schedule("MissileImage::ShootSmart2(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + $HVtime2[%new];  
			GameBase::setEnergy(%player,%energy);
			}//++++added due to burst multiplier++++
		} 
 	else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		return;
		} 
	}
	else 
	{
	%enVal = $HVenVal1[%new]; 
	%energy = GameBase::getEnergy(%player); 
	%energy = %energy - %enVal; 
	if(%energy > $HVenergy1[%new])
		{ 
		for(%i = $HVroundsBurst1[%new]; %i > 0; %i--) //++++Non-FCC burst multiplier++++
			{//++++added due to burst multiplier++++
			schedule("MissileImage::ShootSmart(" @ %player @ ");", %timedelay); 
			%timedelay = %timedelay + $HVtime2[%new];  
			GameBase::setEnergy(%player,%energy);
			}//++++added due to burst multiplier++++
		}
 	else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		return;
		} 
	}
} 
function MissileImage::ShootSmart(%player,%slot)
{
%new = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	%velocity = $HVknockback1[%new]; 
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity); 
	Player::applyImpulse(%player,%sniperPower); 
	if($WeaponAmmo[$HVammoT[%new]] != "")
		{
		Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD1[%new]);
		} 
	playSound($HVfiresound1[%new],GameBase::getPosition(%player));  
	for(%i = $HVrounds[%new]; %i > 0; %i--) 
		{ 
		Projectile::spawnProjectile($HVsmart[%new],%trans,%player,%vel,$los::object); 
		}
}
function MissileImage::ShootSmart2(%player,%slot)
{
%new = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%velocity = $HVknockback1[%new];
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	if($WeaponAmmo[$HVammoT[%new]] != "")
		{
		Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD2[%new]);
		} 
	playSound($HVfiresound2[%new],GameBase::getPosition(%player));  
	for(%i = $HVrounds[%new]; %i > 0; %i--) 
		{ 
		Projectile::spawnProjectile($HVsmart2[%new],%trans,%player,%vel,$los::object); 
		}
}
function MissileImage::OnShootDumb(%player,%slot)
{
%new = Player::getClient(%player);
if(Player::getItemCount(%player, FCC) == 1)//++++ 
	{
	%enVal = $HVenVal2[%new]; 
	%energy = GameBase::getEnergy(%player); 
	%energy = %energy - %enVal; 
	if(%energy > $HVenergy2[%new])
		{
		for(%i = $HVroundsBurst2[%new]; %i > 0; %i--) //++++FCC burst multiplier++++
			{//++++added due to burst multiplier++++
			schedule("MissileImage::ShootDumb2(" @ %player @ ");", %timedelay); 
			%timedelay = %timedelay + $HVtime2[%new];  
			GameBase::setEnergy(%player,%energy);
			}//++++added due to burst multiplier++++
		} 
 	else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		return;
		} 
	}
	else 
	{
	%enVal = $HVenVal1[%new]; 
	%energy = GameBase::getEnergy(%player); 
	%energy = %energy - %enVal; 
	if(%energy > $HVenergy1[%new])
		{ 
		for(%i = $HVroundsBurst1[%new]; %i > 0; %i--) //++++Non-FCC burst multiplier++++
			{//++++added due to burst multiplier++++
			schedule("MissileImage::ShootDumb(" @ %player @ ");", %timedelay); 
			%timedelay = %timedelay + $HVtime2[%new];  
			GameBase::setEnergy(%player,%energy);
			}//++++added due to burst multiplier++++
		}
 	else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		return;
		} 
	}
} 
function MissileImage::ShootDumb(%player,%slot)
{
%new = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%velocity = $HVknockback1[%new];
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	%name = Client::getName(%targetId); 
	if($WeaponAmmo[$HVammoT[%new]] != "")
		{
		Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD1[%new]);
		} 
	playSound($HVfiresound1[%new],GameBase::getPosition(%player));  
	for(%i = $HVrounds[%new]; %i > 0; %i--) 
		{ 
		Projectile::spawnProjectile($HVdumb[%new],%trans,%player,%vel,$los::object); 
		}
}
function MissileImage::ShootDumb2(%player,%slot)
{
%new = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%velocity = $HVknockback1[%new];
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	%name = Client::getName(%targetId); 
	if($WeaponAmmo[$HVammoT[%new]] != "")
		{
		Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD2[%new]);
		} 
	playSound($HVfiresound2[%new],GameBase::getPosition(%player));  
	for(%i = $HVrounds[%new]; %i > 0; %i--) 
		{ 
		Projectile::spawnProjectile($HVdumb2[%new],%trans,%player,%vel,$los::object); 
		}
}
function MissileImage::OnShootDumb2(%player,%slot)
{
%new = Player::getClient(%player);
if(Player::getItemCount(%player, FCC) == 1)//++++ 
	{
	%enVal = $HVenVal2[%new]; 
	%energy = GameBase::getEnergy(%player); 
	%energy = %energy - %enVal; 
	if(%energy > $HVenergy2[%new])
		{
		for(%i = $HVroundsBurst2[%new]; %i > 0; %i--) //++++FCC burst multiplier++++
			{//++++added due to burst multiplier++++
			schedule("MissileImage::ShootDumb4(" @ %player @ ");", %timedelay); 
			%timedelay = %timedelay + $HVtime2[%new];  
			GameBase::setEnergy(%player,%energy);
			}//++++added due to burst multiplier++++
		} 
 	else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		return;
		} 
	}
	else 
	{
	%enVal = $HVenVal1[%new]; 
	%energy = GameBase::getEnergy(%player); 
	%energy = %energy - %enVal; 
	if(%energy > $HVenergy1[%new])
		{ 
		for(%i = $HVroundsBurst1[%new]; %i > 0; %i--) //++++Non-FCC burst multiplier++++
			{//++++added due to burst multiplier++++
			schedule("MissileImage::ShootDumb3(" @ %player @ ");", %timedelay); 
			%timedelay = %timedelay + $HVtime2[%new];  
			GameBase::setEnergy(%player,%energy);
			}//++++added due to burst multiplier++++
		}
 	else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		return;
		} 
	}
} 
function MissileImage::ShootDumb3(%player,%slot)
{
%new = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%velocity = $HVknockback1[%new];
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	%name = Client::getName(%targetId); 
	if($WeaponAmmo[$HVammoT[%new]] != "")
		{
		Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD1[%new]);
		} 
	playSound($HVfiresound1[%new],GameBase::getPosition(%player));  
	for(%i = $HVrounds[%new]; %i > 0; %i--) 
		{ 
		Projectile::spawnProjectile($HVdumb3[%new],%trans,%player,%vel,$los::object); 
		}
}
function MissileImage::ShootDumb4(%player,%slot)
{
%new = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%velocity = $HVknockback1[%new];
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	%name = Client::getName(%targetId); 
	if($WeaponAmmo[$HVammoT[%new]] != "")
		{
		Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD2[%new]);
		} 
	playSound($HVfiresound2[%new],GameBase::getPosition(%player));  
	for(%i = $HVrounds[%new]; %i > 0; %i--) 
		{ 
		Projectile::spawnProjectile($HVdumb4[%new],%trans,%player,%vel,$los::object); 
		}
}
function MissileImage::OnEmpty(%player,%slot) 
{ 
%new = Player::getClient(%player);
	%AmmoCount = player::getitemcount(%player, $WeaponAmmo[$HVammoT[%new]]); 
	if(GameBase::getLOSInfo(%player,$HVLOSrange[%new])) 
		{ 
		%object = getObjectType($los::object); 
		%targetId = GameBase::getOwnerClient($los::object);
		%name = Client::getName(%targetId);
		%client = GameBase::getOwnerClient(%player);
		if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor") 
			{ 
			Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
			Client::sendMessage(%targetId,1,"-WARNING- "@$HVwarning[%new]@" lock detected~wAccess_Denied.wav");
			for(%i = %AmmoCount; %i > 0; %i--) 
				{ 
				schedule("MissileImage::OnEmptySmart(" @ %player @ ");", %timedelay); 
				%timedelay = %timedelay + $HVtime2[%new]; 
				} 
			}
		else 
			{ 
			for(%i = %AmmoCount; %i > 0; %i--) 
				{ 
				schedule("MissileImage::OnEmptyDumb(" @ %player @ ");", %timedelay); 
				%timedelay = %timedelay + $HVtime2[%new]; 
				} 
			} 
		} 
	else
		{ 
		for(%i = %AmmoCount; %i > 0; %i--) 
			{ 
			schedule("MissileImage::OnEmptyDumb(" @ %player @ ");", %timedelay); 
			%timedelay = %timedelay + $HVtime2[%new]; 
			}
		} 
	Player::trigger(%player,$WeaponSlot,false);
}
function MissileImage::OnEmptySmart(%player,%slot)
{
%new = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player); 
	%targetId = GameBase::getOwnerClient($los::object); 
	%name = Client::getName(%targetId); 
	%supression = Player::getSensorSupression(%targetId);
	if(%supression >= 1) 
	{
		Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav"); 
		schedule("MissileImage::OnEmptyDumb(" @ %player @ ");", %timedelay);
	}
	else
	{
	if(Player::getItemCount(%player, FCC) == 1)//++++ 
		{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%velocity = $HVknockback2[%new];
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
		Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD2[%new]);
		Projectile::spawnProjectile($HVsmart2[%new],%trans,%player,%vel,$los::object); 
		playSound($HVfiresound1[%new],GameBase::getPosition(%player));
		} 
	else 
		{ 
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%velocity = $HVknockback2[%new];
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
		Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD2[%new]);
		Projectile::spawnProjectile($HVsmart[%new],%trans,%player,%vel,$los::object); 
		playSound($HVfiresound2[%new],GameBase::getPosition(%player));
		}
	} 
} 
function MissileImage::OnEmptyDumb(%player,%slot)
{
%new = Player::getClient(%player);
	if(Player::getItemCount(%player, FCC) == 1)//++++ 
		{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%velocity = $HVknockback2[%new];
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
		%name = Client::getName(%targetId); 
		if($WeaponAmmo[$HVammoT[%new]] != "")
			{
			Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD2[%new]);
			} 
		Projectile::spawnProjectile($HVdumb2[%new],%trans,%player,%vel,$los::object); 
		playSound($HVfiresound1[%new],GameBase::getPosition(%player));
		} 
	else 
		{ 
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%velocity = $HVknockback2[%new];
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
		%name = Client::getName(%targetId); 
		if($WeaponAmmo[$HVammoT[%new]] != "")
			{
			Player::decItemCount(%player,$WeaponAmmo[$HVammoT[%new]],$HVammoD2[%new]);
			} 
		Projectile::spawnProjectile($HVdumb[%new],%trans,%player,%vel,$los::object); 
		playSound($HVfiresound2[%new],GameBase::getPosition(%player));
	}
} 
//+++++++++++++++++++++++++++++++++++++++++++++++++++

function Mission::reinitData()
{
	$TeamItemCount[0 @ DeployableMunitionsPack] = 0;
	$TeamItemCount[0 @ DeployableMechBay] = 0;
	$TeamItemCount[0 @ Ultra20Pack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
	$TeamItemCount[0 @ DeployableECMPod] = 0;
	$TeamItemCount[0 @ RadarPack] = 0;
	$TeamItemCount[0 @ BeagleActiveProbe] = 0;
	$TeamItemCount[0 @ ScoutVehicle] = 0;
	$TeamItemCount[0 @ Leopardehicle] = 0;
	$TeamItemCount[0 @ UnionVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;
	$TeamItemCount[0 @ RieverVehicle] = 0;//+++++++
	$TeamItemCount[0 @ CorsairVehicle] = 0;//+++++++
	$TeamItemCount[0 @ StingrayVehicle] = 0;//+++++++
	$TeamItemCount[0 @ LongTomPack] = 0;//+++++++
	$TeamItemCount[0 @ LRM5Pack] = 0;//+++++++
	$TeamItemCount[0 @ PPCPack] = 0;//+++++++
	$TeamItemCount[0 @ MedLasPack] = 0;//+++++++
	$TeamItemCount[0 @ FlamerPack] = 0;//+++++++
	$TeamItemCount[0 @ FCCPack] = 0;//+++++++
	$TeamItemCount[0 @ PhasePack] = 0;//+++++++
	$TeamItemCount[0 @ STR2Pack] = 0;//+++++++

	$TeamItemCount[1 @ DeployableMunitionsPack] = 0;
	$TeamItemCount[1 @ DeployableMechBay] = 0;
	$TeamItemCount[1 @ Ultra20Pack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableECMPod] = 0;
	$TeamItemCount[1 @ RadarPack] = 0;
	$TeamItemCount[1 @ BeagleActiveProbe] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ LeopardVehicle] = 0;
	$TeamItemCount[1 @ UnionVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;
	$TeamItemCount[1 @ RieverVehicle] = 0;//+++++++
	$TeamItemCount[1 @ CorsairVehicle] = 0;//+++++++
	$TeamItemCount[1 @ StingrayVehicle] = 0;//+++++++
	$TeamItemCount[1 @ LongTomPack] = 0;//+++++++
	$TeamItemCount[1 @ LRM5Pack] = 0;//+++++++
	$TeamItemCount[1 @ PPCPack] = 0;//+++++++
	$TeamItemCount[1 @ MedLasPack] = 0;//+++++++
	$TeamItemCount[1 @ FlamerPack] = 0;//+++++++
	$TeamItemCount[1 @ FCCPack] = 0;//+++++++
	$TeamItemCount[1 @ PhasePack] = 0;//+++++++
	$TeamItemCount[1 @ STR2Pack] = 0;//+++++++

	$TeamItemCount[2 @ DeployableMunitionsPack] = 0;
	$TeamItemCount[2 @ DeployableMechBay] = 0;
	$TeamItemCount[2 @ Ultra20Pack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ DeployableECMPod] = 0;
	$TeamItemCount[2 @ RadarPack] = 0;
	$TeamItemCount[2 @ BeagleActiveProbe] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ LeopardVehicle] = 0;
	$TeamItemCount[2 @ UnionVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;
	$TeamItemCount[2 @ RieverVehicle] = 0;//+++++++
	$TeamItemCount[2 @ CorsairVehicle] = 0;//+++++++
	$TeamItemCount[2 @ StingrayVehicle] = 0;//+++++++
	$TeamItemCount[2 @ LongTomPack] = 0;//+++++++
	$TeamItemCount[2 @ LRM5Pack] = 0;//+++++++
	$TeamItemCount[2 @ PPCPack] = 0;//+++++++
	$TeamItemCount[2 @ MedLasPack] = 0;//+++++++
	$TeamItemCount[2 @ FlamerPack] = 0;//+++++++
	$TeamItemCount[2 @ FCCPack] = 0;//+++++++
	$TeamItemCount[2 @ PhasePack] = 0;//+++++++
	$TeamItemCount[2 @ STR2Pack] = 0;//+++++++

	$TeamItemCount[3 @ DeployableMunitionsPack] = 0;
	$TeamItemCount[3 @ DeployableMechBay] = 0;
	$TeamItemCount[3 @ Ultra20Pack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableECMPod]= 0;
	$TeamItemCount[3 @ RadarPack] = 0;
	$TeamItemCount[3 @ BeagleActiveProbe] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ LeopardVehicle] = 0;
	$TeamItemCount[3 @ UnionVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;
	$TeamItemCount[3 @ RieverVehicle] = 0;//+++++++
	$TeamItemCount[3 @ CorsairVehicle] = 0;//+++++++
	$TeamItemCount[3 @ StingrayVehicle] = 0;//+++++++
	$TeamItemCount[3 @ LongTomPack] = 0;//+++++++
	$TeamItemCount[3 @ LRM5Pack] = 0;//+++++++
	$TeamItemCount[3 @ PPCPack] = 0;//+++++++
	$TeamItemCount[3 @ MedLasPack] = 0;//+++++++
	$TeamItemCount[3 @ FlamerPack] = 0;//+++++++
	$TeamItemCount[3 @ FCCPack] = 0;//+++++++
	$TeamItemCount[3 @ PhasePack] = 0;//+++++++
	$TeamItemCount[3 @ STR2Pack] = 0;//+++++++

	$TeamItemCount[4 @ DeployableMunitionsPack] = 0;
	$TeamItemCount[4 @ DeployableMechBay] = 0;
	$TeamItemCount[4 @ Ultra20Pack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableECMPod]= 0;
	$TeamItemCount[4 @ RadarPack] = 0;
	$TeamItemCount[4 @ BeagleActiveProbe] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ LeopardVehicle] = 0;
	$TeamItemCount[4 @ UnionVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;
	$TeamItemCount[4 @ RieverVehicle] = 0;//+++++++
	$TeamItemCount[4 @ CorsairVehicle] = 0;//+++++++
	$TeamItemCount[4 @ StingrayVehicle] = 0;//+++++++
	$TeamItemCount[4 @ LongTomPack] = 0;//+++++++
	$TeamItemCount[4 @ LRM5Pack] = 0;//+++++++
	$TeamItemCount[4 @ PPCPack] = 0;//+++++++
	$TeamItemCount[4 @ MedLasPack] = 0;//+++++++
	$TeamItemCount[4 @ FlamerPack] = 0;//+++++++
	$TeamItemCount[4 @ FCCPack] = 0;//+++++++
	$TeamItemCount[4 @ PhasePack] = 0;//+++++++
	$TeamItemCount[4 @ STR2Pack] = 0;//+++++++

	$TeamItemCount[5 @ DeployableMunitionsPack] = 0;
	$TeamItemCount[5 @ DeployableMechBay] = 0;
	$TeamItemCount[5 @ Ultra20Pack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableECMPod]= 0;
	$TeamItemCount[5 @ RadarPack] = 0;
	$TeamItemCount[5 @ BeagleActiveProbe] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ LeopardVehicle] = 0;
	$TeamItemCount[5 @ UnionVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;
	$TeamItemCount[5 @ RieverVehicle] = 0;//+++++++
	$TeamItemCount[5 @ CorsairVehicle] = 0;//+++++++
	$TeamItemCount[5 @ StingrayVehicle] = 0;//+++++++
	$TeamItemCount[5 @ LongTomPack] = 0;//+++++++
	$TeamItemCount[5 @ LRM5Pack] = 0;//+++++++
	$TeamItemCount[5 @ PPCPack] = 0;//+++++++
	$TeamItemCount[5 @ MedLasPack] = 0;//+++++++
	$TeamItemCount[5 @ FlamerPack] = 0;//+++++++
	$TeamItemCount[5 @ FCCPack] = 0;//+++++++
	$TeamItemCount[5 @ PhasePack] = 0;//+++++++
	$TeamItemCount[5 @ STR2Pack] = 0;//+++++++

	$TeamItemCount[6 @ DeployableMunitionsPack] = 0;
	$TeamItemCount[6 @ DeployableMechBay] = 0;
	$TeamItemCount[6 @ Ultra20Pack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableECMPod]= 0;
	$TeamItemCount[6 @ RadarPack] = 0;
	$TeamItemCount[6 @ BeagleActiveProbe] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ LeopardVehicle] = 0;
	$TeamItemCount[6 @ UnionVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;
	$TeamItemCount[6 @ RieverVehicle] = 0;//+++++++
	$TeamItemCount[6 @ CorsairVehicle] = 0;//+++++++
	$TeamItemCount[6 @ StingrayVehicle] = 0;//+++++++
	$TeamItemCount[6 @ LongTomPack] = 0;//+++++++
	$TeamItemCount[6 @ LRM5Pack] = 0;//+++++++
	$TeamItemCount[6 @ PPCPack] = 0;//+++++++
	$TeamItemCount[6 @ MedLasPack] = 0;//+++++++
	$TeamItemCount[6 @ FlamerPack] = 0;//+++++++
	$TeamItemCount[6 @ FCCPack] = 0;//+++++++
	$TeamItemCount[6 @ PhasePack] = 0;//+++++++
	$TeamItemCount[6 @ STR2Pack] = 0;//+++++++

	$TeamItemCount[7 @ DeployableMunitionsPack] = 0;
	$TeamItemCount[7 @ DeployableMechBay] = 0;
	$TeamItemCount[7 @ Ultra20Pack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableECMPod]= 0;
	$TeamItemCount[7 @ RadarPack] = 0;
	$TeamItemCount[7 @ BeagleActiveProbe] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LeopardVehicle] = 0;
	$TeamItemCount[7 @ UnionVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;
	$TeamItemCount[7 @ RieverVehicle] = 0;//+++++++
	$TeamItemCount[7 @ CorsairVehicle] = 0;//+++++++
	$TeamItemCount[7 @ StingrayVehicle] = 0;//+++++++
	$TeamItemCount[7 @ LongTomPack] = 0;//+++++++
	$TeamItemCount[7 @ LRM5Pack] = 0;//+++++++
	$TeamItemCount[7 @ PPCPack] = 0;//+++++++
	$TeamItemCount[7 @ MedLasPack] = 0;//+++++++
	$TeamItemCount[7 @ FlamerPack] = 0;//+++++++
	$TeamItemCount[7 @ FCCPack] = 0;//+++++++
	$TeamItemCount[7 @ PhasePack] = 0;//+++++++
	$TeamItemCount[7 @ STR2Pack] = 0;//+++++++

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}