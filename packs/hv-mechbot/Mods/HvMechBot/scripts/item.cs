//----------------------------------------------------------------------------
$ItemFavoritesKey = "hvMechwarrior2";  // Change this if you add new items
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
$MedLasSlot=4;//+++++++++
//----------------------------------
$AutoUse[Blaster] = True; //AI PPC
$AutoUse[PPC] = True; //PPC
$AutoUse[GaussRifle] = True; //gauss gun
$AutoUse[SniperCannon] = True; //sniper gun
//=======
$AutoUse[MachineGun] = True; //machine gun
$AutoUse[Flamer] = True; //flamer
$AutoUse[SmokeLauncher] = True; //SmokeLauncher
//=========
$AutoUse[TargetingLaser] = False;
//========
$AutoUse[LRM5] = True;//+++++++++++++++++++++++++++
$AutoUse[LRM10] = True;//+++++++++++++++++++++++++++
$AutoUse[LRM20] = True;//+++++++++++++++++++++++++++
//=======
$AutoUse[STR2] = True;//+++++++++++++++++++++++++++
$AutoUse[STR6] = True;//+++++++++++++++++++++++++++
//========
$AutoUse[ArrowIV] = True; //Arrow IV
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
//-----------------------------------------
$Use[PPC] = False; //++++++++
//----------------------------------------------------------------------------------------------------------------
$ArmorType[Male, CommandoArmor] = larmor;
$ArmorType[Male, DriverArmor] = driver;
$ArmorType[Male, PantherArmor] = parmor;
$ArmorType[Male, DeathMatchArmor] = dmarmor;//++++++++++++++
$ArmorType[Male, CenturionArmor] = carmor;//++++++++++++++

$ArmorType[Male, HunchbackArmor] = marmor;//++++++++++++++
$ArmorType[Male, HellBringerArmor] = hbarmor;//++++++++++++++
$ArmorType[Male, ArcherArmor] = aarmor;//++++++++++++++

$ArmorType[Male, BattleMasterArmor] = barmor;
$ArmorType[Male, AtlasArmor] = harmor;//++++++++++++++
//-----------------------------------++++++++++++++++++++++++++
$ArmorType[female, CommandoArmor] = larmor;
$ArmorType[female, DriverArmor] = driver;
$ArmorType[female, PantherArmor] = parmor;
$ArmorType[female, DeathMatchArmor] = dmarmor;//++++++++++++++
$ArmorType[female, CenturionArmor] = carmor;//++++++++++++++

$ArmorType[female, HunchbackArmor] = marmor;//++++++++++++++
$ArmorType[female, HellBringerArmor] = hbarmor;//++++++++++++++
$ArmorType[female, ArcherArmor] = aarmor;//++++++++++++++

$ArmorType[female, BattleMasterArmor] = barmor;
$ArmorType[female, AtlasArmor] = harmor;//++++++++++++++
//------------------------------------++++++++++++++++++++++++
$ArmorName[larmor] = CommandoArmor;
$ArmorName[driver] = DriverArmor;
$ArmorName[parmor] = PantherArmor;
$ArmorName[dmarmor] = DeathMatchArmor;
$ArmorName[carmor] = CenturionArmor;

$ArmorName[marmor] = HunchbackArmor;
$ArmorName[hbarmor] = HellBringerArmor;
$ArmorName[aarmor] = ArcherArmor;

$ArmorName[barmor] = BattleMasterArmor;
$ArmorName[harmor] = AtlasArmor;
//---------------------------------------------------------------------------------------------------------------
// Amount to remove when selling or dropping ammo
//+++++++++++++++++++++++
$SellAmmo[MachineGunAmmo] = 20;
$SellAmmo[LRMAmmo] = 5;
$SellAmmo[Ultra10Ammo] = 10;
$SellAmmo[Ultra20Ammo] = 10;
$SellAmmo[Ultra5Ammo] = 10;
$SellAmmo[STRAmmo] = 5;
$SellAmmo[ArrowIVAmmo] = 2;
$SellAmmo[AC5Ammo] = 12;
$SellAmmo[AC10Ammo] = 10;
$SellAmmo[AC20Ammo] = 8;
$SellAmmo[GaussGunAmmo] = 2;
$SellAmmo[SniperGunAmmo] = 2;
$SellAmmo[SmokeAmmo] = 2;
//++++++++++++++++++++++
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
//$SellAmmo[NukeGrenade] = 5;
//$SellAmmo[InfernoGrenade] = 5;
//$SellAmmo[SmokeHandGrenade] = 5;

// Max Amount of ammo the Ammo Pack can carry
//++++++++++++++++
$MunitionsPackMax[MachineGunAmmo] = 250;
$MunitionsPackMax[LRMAmmo] = 100;
$MunitionsPackMax[Ultra10Ammo] = 100;
$MunitionsPackMax[Ultra20Ammo] = 50;
$MunitionsPackMax[Ultra5Ammo] = 200;
$MunitionsPackMax[STRAmmo] = 30;
$MunitionsPackMax[ArrowIVAmmo] = 4;
$MunitionsPackMax[AC5Ammo] = 72;
$MunitionsPackMax[AC10Ammo] = 40;
$MunitionsPackMax[AC20Ammo] = 24;
$MunitionsPackMax[Ultra5Ammo] = 100;
$MunitionsPackMax[ULtra10Ammo] = 65;
$MunitionsPackMax[Ultra20Ammo] = 35;
$MunitionsPackMax[GaussGunAmmo] = 4;
$MunitionsPackMax[SniperGunAmmo] = 10;
$MunitionsPackMax[SmokeAmmo] = 10;
//+++++++++++++++++++++++++
$MunitionsPackMax[MineAmmo] = 5;
$MunitionsPackMax[Grenade] = 5;
//$MunitionsPackMax[VibroMine] = 5;
//$MunitionsPackMax[NukeGrenade] = 5;
//$MunitionsPackMax[InfernoMine] = 5;
//$MunitionsPackMax[InfernoGrenade] = 5;
//$MunitionsPackMax[SmokeHandGrenade] = 5;

// Items in the MunitionsPack+++++++++++++++++++++++++
$MunitionsPackItems[0] = MachineGunAmmo;
$MunitionsPackItems[1] = LRMAmmo;
$MunitionsPackItems[2] = Ultra10Ammo;
$MunitionsPackItems[3] = Ultra20Ammo;
$MunitionsPackItems[4] = Grenade;
$MunitionsPackItems[5] = MineAmmo;
$MunitionsPackItems[6] = Ultra5Ammo;
$MunitionsPackItems[7] = STRAmmo;
$MunitionsPackItems[8] = ArrowIVAmmo;
$MunitionsPackItems[9] = AC5Ammo;
$MunitionsPackItems[10] = AC10Ammo;
$MunitionsPackItems[11] = AC20Ammo;
$MunitionsPackItems[12] = GaussGunAmmo;
$MunitionsPackItems[13] = SniperGunAmmo;
$MunitionsPackItems[14] = SmokeAmmo;

//-------------------------------------------------------------------------------------------------------
// Limit on number of special Items you can buy+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
$TeamItemMax[DeployableMunitionsPack] = 5;
$TeamItemMax[DeployableMechBay] = 5;

$TeamItemMax[Ultra20Pack] = 2;
//$TeamItemMax[MedPLasPack] = 3;
$TeamItemMax[MedLasPack] = 4;
$TeamItemMax[LongTomPack] = 1;
$TeamItemMax[PPCPack] = 2;
$TeamItemMax[LRM5Pack] = 2;
//$TeamItemMax[Str2Pack] = 2;
$TeamItemMax[FlamerPack] = 4;

$TeamItemMax[CameraPack] = 25;
$TeamItemMax[DeployableECMPod] = 10;
$TeamItemMax[RadarPack] = 10;
$TeamItemMax[BeagleActiveProbe] = 20;

$TeamItemMax[RieverVehicle] = 2;
$TeamItemMax[CorsairVehicle] = 2;
$TeamItemMax[StingrayVehicle] = 2;
$TeamItemMax[LeopardVehicle] = 2;
$TeamItemMax[UnionVehicle] = 1;

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
								Player::setItemCount(%client, LRMPackH,1);
								Player::mountItem(%client, LRMPackH, 4);
								Player::setItemCount(%client, GaussPackH,1);
								Player::mountItem(%client, GaussPackH, 5);
								Player::setItemCount(%client, RadarPackH,1);
								Player::mountItem(%client, RadarPackH, 6);
								Player::setItemCount(%client, MLPackH,1);
								Player::mountItem(%client, MLPackH, 7);
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
									if(Player::getMountedItem(%player, 7) == MLPackH)
									{
										Player::unmountItem(%player, 7);
										Player::setItemCount(%player, MLPackH,0);
									}
								}
							if(%buyarmor == "barmor")//++++++++++++++++++
							{
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
							if(%buyarmor == "aarmor")//++++++++++++++++++
							{
								Player::setItemCount(%client, MLPackA,1);
								Player::mountItem(%client, MLPackA, 4);
								Player::setItemCount(%client, LRMPackA,1);
								Player::mountItem(%client, LRMPackA, 5);
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
								}//+++++++++++++++
							if(%buyarmor == "hbarmor")//++++++++++++++++++
							{
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
								Player::setItemCount(%client, MLPackC,1);
								Player::mountItem(%client, MLPackC, 4);
								Player::setItemCount(%client, MLPackC2,1);
								Player::mountItem(%client, MLPackC2, 5);
							}
							else
							{
							if(Player::getMountedItem(%player, 4) == MLPackC) 
								{
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, MLPackC,0);
								}
									if(Player::getMountedItem(%player, 5) == MLPackC2)
									{
										Player::unmountItem(%player, 5);
										Player::setItemCount(%player, MLPackC2,0);
									}
								}//++++++++++++++
							if(%buyarmor == "parmor")//++++++++++++++++++
							{
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
							if(%buyarmor == "larmor")//++++++++++++++++++
							{
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
			if (%pack != -1) {
				if(%pack == MunitionsPack) 
					checkMax(%client,%armor);
				else if(%pack == FCCPod) {//+++++++
					if(Player::getItemCount(%client,"ArrowIV") > 0) {
						Client::sendMessage(%client,0,"Removed 'Fire-Control Computer' - Auto Selling ArrowIV");
						remoteSellItem(%client,43);//22+++						
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
				if(%item == ArrowIV && Player::getItemCount(%client,"FCCPod") == 0) {//+++++++
					buyItem(%client,"FCCPod");
					Client::sendMessage(%client,0,"ArrowIV Equipped - Auto buying 'Fire-Control Computer'");
				}//++++++++++
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
			else if (%item == MunitionsPack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == FCCPod) { //+++++++
				if(Player::getItemCount(%client,"ArrowIV") > 0) {
					Client::sendMessage(%client,0,"Removed 'Fire-Control Computer' - Auto Selling ArrowIV");
					remoteSellItem(%client,43);//22++++					
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

$NextWeapon[SmokeLauncher] = MachineGun;
$NextWeapon[MachineGun] = Flamer;
$NextWeapon[Flamer] = MedLas;
$NextWeapon[MedLas] = LrgLas;
$NextWeapon[LrgLas] = MedPLas;
$NextWeapon[MedPLas] = LrgPLas;
$NextWeapon[LrgPLas] = LRM5;
$NextWeapon[LRM5] = LRM10;
$NextWeapon[LRM10] = LRM20;
$NextWeapon[LRM20] = STR2;
$NextWeapon[STR2] = STR6;
$NextWeapon[STR6] = ArrowIV;
$NextWeapon[ArrowIV] = PPC;
$NextWeapon[PPC] = GaussRifle;
$NextWeapon[GaussRifle] = SniperCannon;
$NextWeapon[SniperCannon] = AC5;
$NextWeapon[AC5] = AC10;
$NextWeapon[AC10] = AC20;
$NextWeapon[AC20] = Ultra5;
$NextWeapon[Ultra5] = Ultra10;
$NextWeapon[Ultra10] = Ultra20;
$NextWeapon[Ultra20] = SmokeLauncher;

$PrevWeapon[SmokeLauncher] = MachineGun;
$PrevWeapon[MachineGun] = Flamer;
$PrevWeapon[Flamer] = MedLas;
$PrevWeapon[MedLas] = LrgLas;
$PrevWeapon[LrgLas] = MedPLas;
$PrevWeapon[MedPLas] = LrgPLas;
$PrevWeapon[LrgPLas] = LRM5;
$PrevWeapon[LRM5] = LRM10;
$PrevWeapon[LRM10] = LRM20;
$PrevWeapon[LRM20] = STR2;
$PrevWeapon[STR2] = STR6;
$PrevWeapon[STR6] = ArrowIV;
$PrevWeapon[ArrowIV] = PPC;
$PrevWeapon[PPC] = GaussRifle;
$PrevWeapon[GaussRifle] = SniperCannon;
$PrevWeapon[SniperCannon] = AC5;
$PrevWeapon[AC5] = AC10;
$PrevWeapon[AC10] = AC20;
$PrevWeapon[AC20] = Ultra5;
$PrevWeapon[Ultra5] = Ultra10;
$PrevWeapon[Ultra10] = Ultra20;
$PrevWeapon[Ultra20] = SmokeLauncher;

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

ItemData CommandoArmor
{
   heading = "aMechs";
	description = "Commando";
	shapeFile = "lfemale";
	className = "Armor";
	price = 1000;
};

ItemData DriverArmor
{
   heading = "aMechs";
	description = "Driver";
	shapeFile = "lfemale";
	showInventory = false;//++++++++++++++++++++
	className = "Armor";
	price = 1000;
};

ItemData DeathMatchArmor
{
   heading = "aMechs";
	shapeFile = "larmor";
	description = "DM Panther Armor";
	showInventory = false;//++++++++++++++++++++
	className = "Armor";
	price = 1200;
};

ItemData PantherArmor
{
   heading = "aMechs";
	shapeFile = "larmor";
	description = "Panther";
	className = "Armor";
	price = 1200;
};

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

ItemData BattleMasterArmor
{
   heading = "aMechs";
	shapeFile = "harmor";
	description = "BattleMaster";
	className = "Armor";
	price = 2000;
};

ItemData AtlasArmor
{
   heading = "aMechs";
	shapeFile = "harmor";
	description = "Atlas";
	className = "Armor";
	price = 2100;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData CorsairVehicle
{
	description = "Corsair";
	className = "Vehicle";
	shapeFile = "flyer";
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

//----------------------------------------------------------------------------
ItemImageData PPCImage
{
   shapeFile  = "shotgun"; //"grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.75;

//	projectileType = PPCBolt;
	accuFire = true;

	sfxReady = SoundLaserIdle;
	sfxActivate = SoundItemArm; //SoundPickUpWeapon;
};

ItemData PPC
{
   heading = "eOther Weapons";
	description = "PPC";
	className = "Weapon";
   shapeFile  = "shotgun"; //"mortarPack";++++++++++++++++++++++++++
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PPCImage;
	price = 350;
	showWeaponBar = true;
};
function PPC::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using PPC \nSlow rate of fire, with high heat buildup \nVery Heavy damage, with small blast radius \nVery long range - 450m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function PPCImage::onFire(%player, %slot)
 {
   %enVal  = 30.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 5.0)
	{
	if(Player::getItemCount(%player, FCC))
		{
		if (%energy > 50.0)
			{
			for(%i = 3;  %i > 0; %i--) 
				{
				%enVal  = 35.0;//+++++++
				%energy = GameBase::getEnergy(%player);
				%energy = %energy - %enVal;
				 GameBase::setEnergy(%player,%energy);
				 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
				 %trans = GameBase::getMuzzleTransform(%player);
				 %vel = Item::getVelocity(%player);
				 schedule("PPCImage::OnShoot(" @ %player @ ");", %timedelay);
				 %timedelay = %timedelay + 0.2; //0.125;
				}
			}
			 else
			{
			 playSound(SoundPackFail,GameBase::getPosition(%player));
			 Player::trigger(%player,$WeaponSlot,false);
			 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire-");
			}
		}
		else
		{
   		 GameBase::setEnergy(%player,%energy);
		 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("PPCBolt",%trans,%player,%vel);
		}
	}
	else
	{
	 playSound(SoundPackFail,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire-");
	} 
}
function PPCImage::OnShoot(%player, %slot)
{
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	 Projectile::spawnProjectile("PPCBolt2",%trans,%player,%vel);
	 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
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
	reloadTime = 0.32; //.4;
	fireTime = 0.0;

	ammoType = Ultra5Ammo;
//	projectileType = Ultra5Bullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.15;
	lightColor = { 0.6, 1, 1 };

//	sfxFire = debrisSmallExplosion;
	sfxActivate = SoundItemArm;
	sfxReady = SoundSensorPower; 

};

ItemData Ultra5
{
	description = "Ultra-AC5";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cAutoCannons";
	shadowDetailMask = 4;
	imageType = Ultra5Image;
	price = 225;
	showWeaponBar = true;
};
function Ultra5::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Ultra-AC5 \nVery fast rate of fire, minimal heat buildup \nModerate damage \nEffective range - 175m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function Ultra5Image::onFire(%player, %slot)
 {
   %enVal  = 6.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 8.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Ultra5]);
	 if(%AmmoCount > 0)
		{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra5Tracer",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra5],1);
		 for(%i = 4;  %i > 0; %i--) 
	if(Player::getItemCount(%player, FCC))
		{
			%velocity = -2.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
			 schedule("Ultra5Image::OnShoot2(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.08;
		}
		else
			{
			%velocity = -2.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
			 schedule("Ultra5Image::OnShoot(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.08;
			}
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	}
	 else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		} 
	}

function Ultra5Image::OnShoot(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra5Bullet",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra5],1);
		 playSound(SoundFiremortar,GameBase::getPosition(%player));
//		 playSound(debrisSmallExplosion,GameBase::getPosition(%player));
	}
function Ultra5Image::OnShoot2(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra5Bullet2",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra5],1);
		 playSound(SoundFiremortar,GameBase::getPosition(%player));
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
	reloadTime = 0.4;
	fireTime = 0.0;

	ammoType = Ultra10Ammo;
//	projectileType = Ultra10Bullet;
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
   heading = "cAutoCannons";
	shadowDetailMask = 4;
	imageType = Ultra10Image;
	price = 300;
	showWeaponBar = true;
};
function Ultra10::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Ultra-AC10 \nFast rate of fire, moderate heat buildup\nHeavy damage \nEffective range - 125m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function Ultra10Image::onFire(%player, %slot)
 {
   %enVal  = 8.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 10.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Ultra10]);
	 if(%AmmoCount > 0)
		{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra10Tracer",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra10],1);
//		 playSound(debrisMediumExplosion,GameBase::getPosition(%player));
		  for(%i = 4;  %i > 0; %i--) 
	if(Player::getItemCount(%player, FCC))
		{
			%velocity = -6.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
			 schedule("Ultra10Image::OnShoot2(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.1;
		}
		else
			{
			%velocity = -6.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
			 schedule("Ultra10Image::OnShoot(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.1;
			}
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	}
	 else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		} 
	}
function Ultra10Image::OnShoot(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra10Bullet",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra10],1);
		 playSound(SoundmortarTurretFire,GameBase::getPosition(%player));
//		 playSound(debrisMediumExplosion,GameBase::getPosition(%player));
	}
function Ultra10Image::OnShoot2(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra10Bullet2",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra10],1);
		 playSound(SoundmortarTurretFire,GameBase::getPosition(%player));
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
	reloadTime = 0.48; //0.6;
	fireTime = 0.0;

	ammoType = Ultra20Ammo;
//	projectileType = Ultra20Bullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.2;
	lightColor = { 0.6, 1, 1 };

	sfxActivate = SoundItemArm;
	sfxReady = SoundSensorPower; 

};

ItemData Ultra20
{
	description = "Ultra-AC20";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cAutoCannons";
	shadowDetailMask = 4;
	imageType = Ultra20Image;
	price = 425;
	showWeaponBar = true;
};
function Ultra20::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Ultra-AC20 \nVery fast rate of fire, high heat buildup \nExtreme damage \nEffective range - 80m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function Ultra20Image::onFire(%player, %slot)
 {
   %enVal  = 10.0; //1.10;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 12.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Ultra20]);
	 if(%AmmoCount > 0)
		{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra20Tracer",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra20],1);
		 for(%i = 4;  %i > 0; %i--) 
if(Player::getItemCount(%player, FCC))
		{
			%velocity = -10.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
			 schedule("Ultra20Image::OnShoot2(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.12;
		}
		else
			{
			%velocity = -10.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
			 schedule("Ultra20Image::OnShoot(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.12;
			}
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	}
	 else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		} 
	}

function Ultra20Image::OnShoot(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra20Bullet",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra20],1);
		 playSound(mineExpS,GameBase::getPosition(%player));
//		 playSound(debrisLargeExplosion,GameBase::getPosition(%player));
	}
function Ultra20Image::OnShoot2(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("Ultra20Bullet2",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra20],1);
		 playSound(mineExpS,GameBase::getPosition(%player));
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
	reloadTime = 0.8;
	fireTime = 0.01;

	ammoType = AC5Ammo;
//	projectileType = Ultra5Bullet;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 4;
	lightTime = 0.12;
	lightColor = { 0.6, 1, 1 };
//	lightColor = { 0.75, 0.25, 0.65  };

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
   heading = "cAutoCannons";
	shadowDetailMask = 4;
	imageType = AC5Image;
	price = 175;
	showWeaponBar = true;
};
function AC5::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LBX-AC5 \nFires six-round bursts, minimal heat buildup \nModerate damage \nEffective range - 215m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function AC5Image::onFire(%player, %slot)
 {
   %enVal  = 5.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 5.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AC5]);
	 if(%AmmoCount > 0)
		{
		if(Player::getItemCount(%player, FCC))
		{
		%velocity = -30.0;
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC5Tracer",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[AC5],12);
		 playSound(SoundFiremortar,GameBase::getPosition(%player));
		 schedule("AC5Image::OnShoot2(" @ %player @ ");", %timedelay);
		}
		else
		{
   		 GameBase::setEnergy(%player,%energy);
			 %trans = GameBase::getMuzzleTransform(%player);
			 %vel = Item::getVelocity(%player);
			 Projectile::spawnProjectile("AC5Tracer",%trans,%player,%vel);
			 Player::decItemCount(%player,$WeaponAmmo[AC5],1);
			 playSound(SoundFiremortar,GameBase::getPosition(%player));
		 for(%i = 5;  %i > 0; %i--) 
		{
			%velocity = -2.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
		 schedule("AC5Image::OnShoot(" @ %player @ ");", %timedelay);
		 %timedelay = %timedelay + 0.09;
		}
		}
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	}
	 else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		} 
	}

function AC5Image::OnShoot(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC5Bullet",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[AC5],1);
		 playSound(SoundFiremortar,GameBase::getPosition(%player));
	}
function AC5Image::OnShoot2(%player, %slot)
	{
   %enVal  = 35.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC5Bullet2",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra5],10);
		 playSound(SoundFireMortar,GameBase::getPosition(%player));
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
	reloadTime = 0.95; //1.0;+++++++++
	fireTime = 0.01;

	ammoType = AC10Ammo;
//	projectileType = Ultra10Bullet;
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
   heading = "cAutoCannons";
	shadowDetailMask = 4;
	imageType = AC10Image;
	price = 250;
	showWeaponBar = true;
};
function AC10::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LBX-AC10 \nFires five-round bursts, minimal heat buildup \nHeavy damage \nEffective range - 165m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function AC10Image::onFire(%player, %slot)

 {
   %enVal  = 10.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 8.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AC10]);
	 if(%AmmoCount > 0)
		{
		if(Player::getItemCount(%player, FCC))
		{
		%velocity = -40.0;
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC10Tracer",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[AC10],10);
		 playSound(SoundFiremortar,GameBase::getPosition(%player));
		 schedule("AC10Image::OnShoot2(" @ %player @ ");", %timedelay);
		}
		else
		{
   		 GameBase::setEnergy(%player,%energy);
			 %trans = GameBase::getMuzzleTransform(%player);
			 %vel = Item::getVelocity(%player);
			 Projectile::spawnProjectile("AC10Tracer",%trans,%player,%vel);
			 Player::decItemCount(%player,$WeaponAmmo[AC10],1);
			 playSound(SoundmortarTurretFire,GameBase::getPosition(%player));
		 for(%i = 4;  %i > 0; %i--)
		{
			%velocity = -5.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
		 schedule("AC10Image::OnShoot(" @ %player @ ");", %timedelay);
		 %timedelay = %timedelay + 0.12;
		}
		}
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
		}
	 else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		} 
	}

function AC10Image::OnShoot(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC10Bullet",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[AC10],1);
		 playSound(SoundmortarTurretFire,GameBase::getPosition(%player));
	}
function AC10Image::OnShoot2(%player, %slot)
	{
   %enVal  = 40.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC10Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC10Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC10Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC10Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC10Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC10Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC10Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC10Bullet2",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra10],8);
		 playSound(SoundmortarTurretFire,GameBase::getPosition(%player));
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
	reloadTime = 1.1;
	fireTime = 0.01;

	ammoType = AC20Ammo;
//	projectileType = AC20Bullet;
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
   heading = "cAutoCannons";
	shadowDetailMask = 4;
	imageType = AC20Image;
	price = 375;
	showWeaponBar = true;
};
function AC20::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LBX-AC20 \nFires four-round bursts, moderate heat buildup \nExtreme damage \nEffective range - 115m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function AC20Image::onFire(%player, %slot)
 {
   %enVal  = 15.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 12.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AC20]);
	 if(%AmmoCount > 0)
		{
		if(Player::getItemCount(%player, FCC))
		{
		%velocity = -60.0;
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC20Tracer",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[AC20],8);
		 playSound(SoundFiremortar,GameBase::getPosition(%player));
		 schedule("AC20Image::OnShoot2(" @ %player @ ");", %timedelay);
		}
		else
		{
   		 GameBase::setEnergy(%player,%energy);
			 %trans = GameBase::getMuzzleTransform(%player);
			 %vel = Item::getVelocity(%player);
			 Projectile::spawnProjectile("AC20Tracer",%trans,%player,%vel);
			 Player::decItemCount(%player,$WeaponAmmo[AC20],1);
			 playSound(mineExpS,GameBase::getPosition(%player));
		 for(%i = 3;  %i > 0; %i--)
		{
			%velocity = -10.0;
			%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
			Player::applyImpulse(%player,%sniperPower);
		 schedule("AC20Image::OnShoot(" @ %player @ ");", %timedelay);
		 %timedelay = %timedelay + 0.18;
		}
		}
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	}
	 else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		} 
	}

function AC20Image::OnShoot(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC20Bullet",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[AC20],1);
		 playSound(mineExpS,GameBase::getPosition(%player));
	}
function AC20Image::OnShoot2(%player, %slot)
{
   %enVal  = 45.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("AC20Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC20Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC20Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC20Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC20Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC20Bullet2",%trans,%player,%vel);
		 Projectile::spawnProjectile("AC20Bullet2",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[Ultra20],7);
		 playSound(mineExpS,GameBase::getPosition(%player));
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
//	projectileType = GaussGunShell;
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
   heading = "eOther Weapons";
	shadowDetailMask = 4;
	imageType = GaussRifleImage;
	price = 400;
	showWeaponBar = true;
};

function GaussRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Gauss Rifle \nVery slow rate of fire, but no heat buildup \nExtreme damage \nExtremely long range - over 2000m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function GaussRifleImage::onFire(%player, %slot)
 {
   %enVal  = 10.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 10.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[GaussRifle]);
	 if(%AmmoCount > 0)
		{
		if(Player::getItemCount(%player, FCC))
		{
   		 GameBase::setEnergy(%player,%energy);
		 Player::decItemCount(%player,$WeaponAmmo[GaussRifle],1);
		%velocity = -100.0;
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
		 schedule("GaussRifleImage::OnShoot2(" @ %player @ ");", %timedelay);
		}
		else
		{
		%velocity = -100.0;
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
   		 GameBase::setEnergy(%player,%energy);
		 Player::decItemCount(%player,$WeaponAmmo[GaussRifle],1);
		 schedule("GaussRifleImage::OnShoot(" @ %player @ ");", %timedelay);
		}
	}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	 }
	 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}
function GaussRifleImage::OnShoot(%player, %slot)
{
	 playSound(turretExplosion,GameBase::getPosition(%player));
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	 Projectile::spawnProjectile("GaussGunShell",%trans,%player,%vel);
	 Player::trigger(%player,$WeaponSlot,false);
}
function GaussRifleImage::OnShoot2(%player, %slot)
{
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 Projectile::spawnProjectile("GaussGunShell2",%trans,%player,%vel);
	 playSound(turretExplosion,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
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
//	projectileType = LRM5Missile;
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
	description = "LRM-5 Missile Launcher";
	className = "Weapon";
	shapeFile = "ammo1";
	hudIcon = "blaster";
   heading = "dMissile Systems";
	shadowDetailMask = 4;
	imageType = LRM5Image;
	price = 150;
	showWeaponBar = true;
};

function LRM5::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LRM-5, guided-missile launcher \nFires five-missile salvos, minimal heat buildup \nMinimal damage per missile, with blast radius \nEffective range - 425m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function LRM5Image::onFire(%player, %slot)
 {
   %enVal  = 15.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   %client = GameBase::getOwnerClient(%player);
   %trans = GameBase::getMuzzleTransform(%player);
   %vel = Item::getVelocity(%player);
     if(%energy > 10.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[LRM5]);
	 if(%AmmoCount > 4)
		{
   		 GameBase::setEnergy(%player,%energy);
		  if(GameBase::getLOSInfo(%player,500)) 
			{
			%object = getObjectType($los::object); 
			%targetId = GameBase::getOwnerClient($los::object); 
			 if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor") 
				{
				 schedule("LRM5Image::OnShootSmart(" @ %player @ ");", %timedelay);
				}	
				else
			 schedule("LRM5Image::OnShootDumb(" @ %player @ ");", %timedelay);
			}
			else
		 schedule("LRM5Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
		 else
	{	
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav");
	 playSound(SoundDryFire,GameBase::getPosition(%player));
	}
}
 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}

function LRM5Image::OnShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%targetId = GameBase::getOwnerClient($los::object); 
	%name = Client::getName(%targetId); 
	%supression = Player::getSensorSupression(%targetId);
	if(%supression >= 1)
		{
		 Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav");
		 schedule("LRM5Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
	else
	{
	if(Player::getItemCount(%player, FCC))
		{
  		Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  		Client::sendMessage(%targetId,1,"-WARNING- LRM lock detected~wAccess_Denied.wav");
		for(%i = 5;  %i > 0; %i--)
			{
			schedule("LRM5Image::ShootSmart2(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.2;
			}
		}
	else
	{
  	Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  	Client::sendMessage(%targetId,1,"-WARNING- LRM lock detected~wAccess_Denied.wav");
	for(%i = 5;  %i > 0; %i--)
		{
		schedule("LRM5Image::ShootSmart(" @ %player @ ");", %timedelay);
		%timedelay = %timedelay + 0.2;
		}
	}
}
}

function LRM5Image::ShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[LRM5],1);
	 Projectile::spawnProjectile("LRM5Missile",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function LRM5Image::ShootSmart2(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[LRM5],1);
	 Projectile::spawnProjectile("LRM5Missile2",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function LRM5Image::OnShootDumb(%player,%slot)
{
	for(%i = 1;  %i > 0; %i--)
	{
		schedule("LRM5Image::ShootDumb(" @ %player @ ");", %timedelay);
		%timedelay = %timedelay + 0.4;
	}
}

function LRM5Image::ShootDumb(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[LRM5],5);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LRM10Image
{
	shapeFile = "ammo1";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = LRMAmmo;
//	projectileType = LRM5Missile;
	accuFire = false;
	reloadTime = 4.0;
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
	description = "LRM-10 Missile Launcher";
	className = "Weapon";
	shapeFile = "ammo1";
	hudIcon = "blaster";
   heading = "dMissile Systems";
	shadowDetailMask = 4;
	imageType = LRM10Image;
	price = 200;
	showWeaponBar = true;
};

function LRM10::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LRM-10, guided-missile launcher \nFires ten-missile salvos, moderate heat buildup \nMinimal damage per missile, with blast radius \nEffective range - 425m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function LRM10Image::onFire(%player, %slot)
 {
   %enVal  = 25.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
     if(%energy > 20.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[LRM10]);
	 if(%AmmoCount > 9)
		{
   		 GameBase::setEnergy(%player,%energy);
		  if(GameBase::getLOSInfo(%player,500)) 
			{
			%object = getObjectType($los::object); 
			%targetId = GameBase::getOwnerClient($los::object); 
		  	Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
			 if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor") 
				{			
				 %name = Client::getName(%targetId); 
			  	 Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
				 schedule("LRM10Image::OnShootSmart(" @ %player @ ");", %timedelay);
				 %timedelay = %timedelay + 0.4;
				}	
				else
			 schedule("LRM10Image::OnShootDumb(" @ %player @ ");", %timedelay);
			}
			else
		 schedule("LRM10Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
		 else
	{	
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav");
	 playSound(SoundDryFire,GameBase::getPosition(%player));
	}
}
 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}

function LRM10Image::OnShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%targetId = GameBase::getOwnerClient($los::object); 
	%name = Client::getName(%targetId); 
	%supression = Player::getSensorSupression(%targetId);
	if(%supression >= 1)
		{
		 Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav");
		 schedule("LRM10Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
	else
	{
	if(Player::getItemCount(%player, FCC))
		{
  		Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  		Client::sendMessage(%targetId,1,"-WARNING- LRM lock detected~wAccess_Denied.wav");
		for(%i = 5;  %i > 0; %i--)
			{
			schedule("LRM10Image::ShootSmart2(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.25;
			}
		}
	else
	{
  	Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  	Client::sendMessage(%targetId,1,"-WARNING- LRM lock detected~wAccess_Denied.wav");
	for(%i = 5;  %i > 0; %i--)
		{
			schedule("LRM10Image::ShootSmart(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.25;
		}
	}
}
}

function LRM10Image::ShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[LRM10],2);
	 Projectile::spawnProjectile("LRM5Missile",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Missile",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function LRM10Image::ShootSmart2(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[LRM10],2);
	 Projectile::spawnProjectile("LRM5Missile2",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Missile2",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function LRM10Image::OnShootDumb(%player,%slot)
{
	for(%i = 2;  %i > 0; %i--)
	{
		schedule("LRM10Image::ShootDumb(" @ %player @ ");", %timedelay);
		%timedelay = %timedelay + 0.4;
	}
}

function LRM10Image::ShootDumb(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[LRM10],5);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LRM20Image
{
	shapeFile = "ammo1";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = LRMAmmo;
//	projectileType = LRM5Missile;
	accuFire = false;
	reloadTime = 8.0;
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
	description = "LRM-15 Missile Launcher";
	className = "Weapon";
	shapeFile = "ammo1";
	hudIcon = "blaster";
   heading = "dMissile Systems";
	shadowDetailMask = 4;
	imageType = LRM20Image;
	price = 275;
	showWeaponBar = true;
};

function LRM20::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using LRM-15, guided-missile launcher \nFires fifteen-missile salvos, high heat buildup \nMinimal damage per missile, with blast radius \nEffective range - 425m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function LRM20Image::onFire(%player, %slot)
 {
   %enVal  = 30.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
     if(%energy > 25.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[LRM20]);
	 if(%AmmoCount > 14)
		{
   		 GameBase::setEnergy(%player,%energy);
		  if(GameBase::getLOSInfo(%player,500)) 
			{
			%object = getObjectType($los::object); 
			%targetId = GameBase::getOwnerClient($los::object); 
			 if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor") 
				{			
				 %name = Client::getName(%targetId); 
			  	 Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
				 schedule("LRM20Image::OnShootSmart(" @ %player @ ");", %timedelay);
				 %timedelay = %timedelay + 0.4;
				}	
				else
			 schedule("LRM20Image::OnShootDumb(" @ %player @ ");", %timedelay);
			}
			else
		 schedule("LRM20Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
		 else
	{	
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav");
	 playSound(SoundDryFire,GameBase::getPosition(%player));
	}
}
 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}

function LRM20Image::OnShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%targetId = GameBase::getOwnerClient($los::object); 
	%name = Client::getName(%targetId);
	%supression = Player::getSensorSupression(%targetId);
	if(%supression >= 1)
		{
		 Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav");
		 schedule("LRM20Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
	else
	{
	if(Player::getItemCount(%player, FCC))
		{
  		Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  		Client::sendMessage(%targetId,1,"-WARNING- LRM lock detected~wAccess_Denied.wav");
		for(%i = 5;  %i > 0; %i--)
			{
			schedule("LRM20Image::ShootSmart2(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.3;
			}
		}
	else
	{ 
  	Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  	Client::sendMessage(%targetId,1,"-WARNING- LRM lock detected~wAccess_Denied.wav");
	for(%i = 5;  %i > 0; %i--)
		{
			schedule("LRM20Image::ShootSmart(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.3;
		}
	}
}
}

function LRM20Image::ShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[LRM20],3);
	 Projectile::spawnProjectile("LRM5Missile",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Missile",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Missile",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function LRM20Image::ShootSmart2(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[LRM20],3);
	 Projectile::spawnProjectile("LRM5Missile2",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Missile2",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Missile2",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function LRM20Image::OnShootDumb(%player,%slot)
{
	for(%i = 3;  %i > 0; %i--)
	{
		schedule("LRM20Image::ShootDumb(" @ %player @ ");", %timedelay);
		%timedelay = %timedelay + 0.4;
	}
}

function LRM20Image::ShootDumb(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -8.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[LRM20],5);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("LRM5Rocket",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
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
//	projectileType = STRMissile;
	accuFire = false;
	reloadTime = 1.5;
	fireTime = 0.01;

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
	description = "STR-2 Missile Launcher";
	className = "Weapon";
	shapeFile = "ammo2";
	hudIcon = "blaster";
   heading = "dMissile Systems";
	shadowDetailMask = 4;
	imageType = STR2Image;
	price = 150;
	showWeaponBar = true;
};

function STR2::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Streak-2, guided-missile launcher \nFires two-missile salvos, minimal heat buildup \nModerate damage per missile, with a small blast radius \nEffective range - 175m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function STR2Image::onFire(%player, %slot)
 {
   %enVal  = 10.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
     if(%energy > 10.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[STR2]);
	 if(%AmmoCount > 1)
		{
   		 GameBase::setEnergy(%player,%energy);
		  if(GameBase::getLOSInfo(%player,500)) 
			{
			%object = getObjectType($los::object); 
			%targetId = GameBase::getOwnerClient($los::object); 
			 if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor") 
				{			
				 %name = Client::getName(%targetId); 
			  	 Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
				 schedule("STR2Image::OnShootSmart(" @ %player @ ");", %timedelay);
				 %timedelay = %timedelay + 0.2;
				}	
				else
			 schedule("STR2Image::OnShootDumb(" @ %player @ ");", %timedelay);
			}
			else
		 schedule("STR2Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
		 else
	{	
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav");
	 playSound(SoundDryFire,GameBase::getPosition(%player));
	}
}
 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}

function STR2Image::OnShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%targetId = GameBase::getOwnerClient($los::object); 
	%name = Client::getName(%targetId);
	%supression = Player::getSensorSupression(%targetId);
	if(%supression >= 1)
		{
		 Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav");
		 schedule("STR2Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
	else
	{
	if(Player::getItemCount(%player, FCC))
		{
  		Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  		Client::sendMessage(%targetId,1,"-WARNING- Streak missile lock detected~wAccess_Denied.wav");
		for(%i = 2;  %i > 0; %i--)
			{
			schedule("STR2Image::ShootSmart2(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.15;
			}
		}
	else
	{ 
  	Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  	Client::sendMessage(%targetId,1,"-WARNING- Streak missile lock detected~wAccess_Denied.wav");
	for(%i = 2;  %i > 0; %i--)
	{
		schedule("STR2Image::ShootSmart(" @ %player @ ");", %timedelay);
		%timedelay = %timedelay + 0.15;
	}
}
}
}

function STR2Image::ShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%velocity = -12.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[STR2],1);
	 Projectile::spawnProjectile("STR2Missile",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function STR2Image::ShootSmart2(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%velocity = -12.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[STR2],1);
	 Projectile::spawnProjectile("STR2Missile2",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function STR2Image::OnShootDumb(%player,%slot)
{
	if(Player::getItemCount(%player, FCC))
		{
		for(%i = 1;  %i > 0; %i--)
			{
			schedule("STR2Image::ShootDumb2(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.25;
			}
		}
	else
	{
		for(%i = 1;  %i > 0; %i--)
		{
			schedule("STR2Image::ShootDumb(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.25;
		}
	}
}

function STR2Image::ShootDumb(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -12.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[STR2],2);
	 Projectile::spawnProjectile("STR2Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("STR2Rocket",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function STR2Image::ShootDumb2(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -12.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[STR2],2);
	 Projectile::spawnProjectile("STR2Rocket2",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("STR2Rocket2",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
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
	reloadTime = 4.0;
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
	description = "STR-6 Missile Launcher";
	className = "Weapon";
	shapeFile = "ammo2";
	hudIcon = "blaster";
   heading = "dMissile Systems";
	shadowDetailMask = 4;
	imageType = STR6Image;
	price = 250;
	showWeaponBar = true;
};

function STR6::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Streak-6, guided-missile launcher \nFires six-missile salvos, minimal heat buildup \nModerate damage per missile, with a small blast radius \nEffective range - 175m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function STR6Image::onFire(%player, %slot)
 {
   %enVal  = 20.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
     if(%energy > 15.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[STR6]);
	 if(%AmmoCount > 5)
		{
   		 GameBase::setEnergy(%player,%energy);
		  if(GameBase::getLOSInfo(%player,500)) 
			{
			%object = getObjectType($los::object); 
			%targetId = GameBase::getOwnerClient($los::object); 
			 if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor") 
				{			
				 %name = Client::getName(%targetId); 
				 schedule("STR6Image::OnShootSmart(" @ %player @ ");", %timedelay);
			  	 Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
				 %timedelay = %timedelay + 0.2;
				}	
				else
			 schedule("STR6Image::OnShootDumb(" @ %player @ ");", %timedelay);
			}
			else
		 schedule("STR6Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
		 else
	{	
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav");
	 playSound(SoundDryFire,GameBase::getPosition(%player));
	}
}
 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}

function STR6Image::OnShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%targetId = GameBase::getOwnerClient($los::object); 
	%name = Client::getName(%targetId);
	%supression = Player::getSensorSupression(%targetId);
	if(%supression >= 1)
		{
		 Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav");
		 schedule("STR6Image::OnShootDumb(" @ %player @ ");", %timedelay);
		}
	else
	{
	if(Player::getItemCount(%player, FCC))
		{
  		Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  		Client::sendMessage(%targetId,1,"-WARNING- Streak missile lock detected~wAccess_Denied.wav");
		for(%i = 6;  %i > 0; %i--)
			{
			schedule("STR6Image::ShootSmart2(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.15;
			}
		}
	else
		{ 
  		Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  		Client::sendMessage(%targetId,1,"-WARNING- Streak Missile lock detected~wAccess_Denied.wav");
		for(%i = 6;  %i > 0; %i--)
		{
			schedule("STR6Image::ShootSmart(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.15;
		}
	}
}
}

function STR6Image::ShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -12.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[STR6],1);
	 Projectile::spawnProjectile("STR2Missile",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function STR6Image::ShootSmart2(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -12.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[STR6],1);
	 Projectile::spawnProjectile("STR2Missile2",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function STR6Image::OnShootDumb(%player,%slot)
{
	if(Player::getItemCount(%player, FCC))
		{
		for(%i = 3;  %i > 0; %i--)
			{
			schedule("STR6Image::ShootDumb2(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.25;
			}
		}
	else
	{
		for(%i = 3;  %i > 0; %i--)
		{
			schedule("STR6Image::ShootDumb(" @ %player @ ");", %timedelay);
			%timedelay = %timedelay + 0.25;
		}
	}
}

function STR6Image::ShootDumb(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -12.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[STR6],2);
	 Projectile::spawnProjectile("STR2Rocket",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("STR2Rocket",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function STR6Image::ShootDumb2(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -12.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[STR6],2);
	 Projectile::spawnProjectile("STR2Rocket2",%trans,%player,%vel,$los::object);
	 Projectile::spawnProjectile("STR2Rocket2",%trans,%player,%vel,$los::object);
	 playSound(SoundMissileTurretFire,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}

//----------------------------------------------------------------------------
ItemData ArrowIVAmmo
{
	description = "Arrow IV Missile";
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
//	projectileType = ArrowIVRocket;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 4.0;

	sfxActivate = SoundItemArm; //SoundTeleportIdle;
	sfxReload = SoundActivatePDA;
	sfxReady = SoundShieldOn;
//	sfxReady = SoundDoubleHeatSinkOn;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 0.75;
	lightColor = { 1.0, 0.7, 0.5 };
};

ItemData ArrowIV
{
	description = "Arrow IV";
	className = "Weapon";
	shapeFile = "rocket";
	hudIcon = "blaster";
   heading = "dMissile Systems";
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
//	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Arrow IV \nExtremely slow rate of fire, moderate heat buildup \nExtreme damage, with large blast radius \nExtremely long range - over 2000m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wSensor_Deploy.wav");
}

function ArrowIVImage::onFire(%player, %slot)
 {
	if(Player::getMountedItem(%player,$BackpackSlot) == FCCPod)
	{
   %enVal  = 17.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
     if(%energy > 15.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[ArrowIV]);
	 if(%AmmoCount > 0)
		{
   		 GameBase::setEnergy(%player,%energy);
		  if(GameBase::getLOSInfo(%player,500)) 
			{
			%object = getObjectType($los::object); 
			%targetId = GameBase::getOwnerClient($los::object); 
			 if(%object == "Player" || %object == "Flier" || %object == "StaticShape" || %object == "Turret" || %object == "Sensor") 
				{			
				 %name = Client::getName(%targetId); 
				 schedule("ArrowIVImage::OnShootSmart(" @ %player @ ");", %timedelay);
			  	 Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
				 %timedelay = %timedelay + 0.2;
				}	
				else
			 schedule("ArrowIVImage::OnShootDumb(" @ %player @ ");", %timedelay);
			}
			else
		 schedule("ArrowIVImage::OnShootDumb(" @ %player @ ");", %timedelay);
		}
		 else
	{	
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-Insufficient Ammo-~wError_Message.wav");
	 playSound(SoundDryFire,GameBase::getPosition(%player));
	}
}
 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}
}
function ArrowIVImage::OnShootSmart(%player,%slot)
{
	if(Player::getItemCount(%player, FCC))//++++++++++++
	{//+++++++++++++
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%targetId = GameBase::getOwnerClient($los::object); 
	%name = Client::getName(%targetId);
	%supression = Player::getSensorSupression(%targetId);
	if(%supression >= 1)
		{
		 Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav");
		 schedule("ArrowIVImage::OnShootDumb(" @ %player @ ");", %timedelay);
		}
	else
	{ 
  	Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  	Client::sendMessage(%targetId,1,"-WARNING- Arrow IV Missile lock detected~wAccess_Denied.wav");
	for(%i = 1;  %i > 0; %i--)
		{
		schedule("ArrowIVImage::ShootHighYeild1(" @ %player @ ");", %timedelay);
		%timedelay = %timedelay + 0.15;
		}
	}
}//++++++++++++++
	else
	{
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%targetId = GameBase::getOwnerClient($los::object); 
	%name = Client::getName(%targetId);
	%supression = Player::getSensorSupression(%targetId);
	if(%supression >= 1)
		{
		 Client::sendMessage(Player::getClient(%player), 1,"-Target Jammed by ECM Pod, Lock Failed-~wError_Message.wav");
		 schedule("ArrowIVImage::OnShootDumb(" @ %player @ ");", %timedelay);
		}
	else
	{ 
  	Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
  	Client::sendMessage(%targetId,1,"-WARNING- Arrow IV Missile lock detected~wAccess_Denied.wav");
	for(%i = 1;  %i > 0; %i--)
		{
		schedule("ArrowIVImage::ShootSmart(" @ %player @ ");", %timedelay);
		%timedelay = %timedelay + 0.15;
		}
	}
}
}
function ArrowIVImage::ShootSmart(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -30.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[ArrowIV],1);
	 Projectile::spawnProjectile("ArrowIVMissile",%trans,%player,%vel,$los::object);
	 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function ArrowIVImage::ShootHighYeild1(%player,%slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -30.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 Player::decItemCount(%player,$WeaponAmmo[ArrowIV],1);
 	Client::sendMessage(%client,0,"-Lock Aquired- " @ %name @ "~wmine_act.wav");
	Client::sendMessage(%targetId,1,"-WARNING- Arrow IV Missile lock detected~wAccess_Denied.wav");
	 Projectile::spawnProjectile("ArrowIVMissile2",%trans,%player,%vel,$los::object);
	 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}

function ArrowIVImage::OnShootDumb(%player,%slot)
{
	if(Player::getItemCount(%player, FCC))//++++++++++++
		{
		schedule("ArrowIVImage::ShootHighYield2(" @ %player @ ");", %timedelay);
		Player::trigger(%player,$WeaponSlot,false);
		}
	else
	{
	for(%i = 1;  %i > 0; %i--)
	{
		schedule("ArrowIVImage::ShootDumb(" @ %player @ ");", %timedelay);
		%timedelay = %timedelay + 0.25;
	}
}
}
function ArrowIVImage::ShootDumb(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -30.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[ArrowIV],1);
	 Projectile::spawnProjectile("ArrowIVRocket",%trans,%player,%vel,$los::object);
	 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}
function ArrowIVImage::ShootHighYield2(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	%velocity = -30.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	 %name = Client::getName(%targetId); 
	 Player::decItemCount(%player,$WeaponAmmo[ArrowIV],1);
	 Projectile::spawnProjectile("ArrowIVRocket2",%trans,%player,%vel,$los::object);
	 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
}

function ArrowIVImage::ShootGuided(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player); 
	 %trans = GameBase::getMuzzleTransform(%player);
	 %vel = Item::getVelocity(%player);
	 %name = Client::getName(%targetId); 
	$F1aky = %player;//++++++++
	$F1aky2 = GameBase::getPosition(%player);//+++++
	 Projectile::spawnProjectile("F1aker",%trans,%player,%vel);
	 Player::decItemCount(%player,$WeaponAmmo[ArrowIV],1);
	 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
}

//----------------------------------------------------------------------------
ItemData SniperGunAmmo
{
	description = "Sniper Cannon Bullet";
	className = "Ammo";
	shapeFile = "mortar";
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
//	projectileType = SniperGunBullet;
	accuFire = true;
	reloadTime = 2.5; //1.5;
	fireTime = 0.01;

	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 0.5;
	lightColor = { 1, 0, 0 };

	sfxReady = SoundmortarIdle;
	sfxActivate = SoundItemArm;
	sfxReload = SoundDryFire;//++++++
};

ItemData SniperCannon
{
	description = "Sniper Cannon";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = "eOther Weapons";
	shadowDetailMask = 4;
	imageType = SniperCannonImage;
	price = 350;
	showWeaponBar = true;
};
function SniperCannon::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Sniper Cannon \nSlow rate of fire, little heat buildup \nHeavy damage \nExtremely long range - over 2000m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function SniperCannonImage::onFire(%player, %slot)
 {
   %enVal  = 15.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 10.0)
	{
	if(Player::getItemCount(%player, FCC))//++++start
		{
		if (%energy > 25.0)
			{
			%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SniperCannon]);
			if(%AmmoCount > 2)
				{
				for(%i = 3;  %i > 0; %i--) 
					{
					%enVal  = 15.0; //8.0;
					%energy = GameBase::getEnergy(%player);
					%energy = %energy - %enVal;
					GameBase::setEnergy(%player,%energy);
					schedule("SniperImage::OnShoot(" @ %player @ ");", %timedelay);
					%timedelay = %timedelay + 0.25;
					}
				}
			else
			{	
			 Player::trigger(%player,$WeaponSlot,false);
			 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
			 playSound(SoundDryFire,GameBase::getPosition(%player));
			}
		}
		 else
		{
		 playSound(SoundPackFail,GameBase::getPosition(%player));
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire-");
		}
	}
	else//+++++end
	{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SniperCannon]);
	if(%AmmoCount > 0)
		{
		%velocity = -50.0;
		%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
		Player::applyImpulse(%player,%sniperPower);
   		 GameBase::setEnergy(%player,%energy);
		 Player::decItemCount(%player,$WeaponAmmo[SniperCannon],1);
		 playSound(bigExplosion4,GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("SniperGunShell",%trans,%player,%vel);
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	 }
	}
	 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}
function SniperImage::OnShoot(%player,%slot)
{ 
	%velocity = -50.0;
	%sniperPower = Vector::getFromRot(GameBase::getRotation(%player),%velocity);
	Player::applyImpulse(%player,%sniperPower);
	Player::decItemCount(%player,$WeaponAmmo[SniperCannon],1);
	playSound(bigExplosion4,GameBase::getPosition(%player));
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("SniperGunShell2",%trans,%player,%vel);
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData BlasterImage
{
   shapeFile  = "shotgun"; //"grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 1.75;

//	projectileType = PPCBolt;
	accuFire = true;

	sfxReady = SoundLaserIdle;
	sfxActivate = SoundItemArm; //SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "eOther Weapons";
	description = "PPC";
	className = "Weapon";
   shapeFile  = "shotgun"; //"mortarPack";++++++++++++++++++++++++++
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PPCImage;
	price = 350;
	showWeaponBar = true;
};
function Blaster::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using PPC \nSlow rate of fire, with high heat buildup \nVery Heavy damage, with small blast radius \nVery long range - 450m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function BlasterImage::onFire(%player, %slot)
 {
   %enVal  = 30.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 5.0)
	{
   		 GameBase::setEnergy(%player,%energy);
		 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("PPCBolt",%trans,%player,%vel);
	 }
	 else
	{
	 playSound(SoundPackFail,GameBase::getPosition(%player));
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire-");
	} 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData MedLasImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
//	projectileType = MedLaser;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0.01;
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
   heading = "bLaser Systems";
	shadowDetailMask = 4;
	imageType = MedLasImage;
	price = 100;
	showWeaponBar = true;
};
function MedLas::onUse(%player,%item)//++++++++++++++++++++++++++++++
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Medium ER Laser \nModerate rate of fire, moderate heat buildup \nModerate damage \nLong range - over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function MedLasImage::onFire(%player, %slot)
 {
   %enVal  = 17.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 12.0)
	{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 playSound(SoundFireLaser,GameBase::getPosition(%player));
		 Projectile::spawnProjectile("MedLaser",%trans,%player,%vel);
		 Projectile::spawnProjectile("MedLaserShell",%trans,%player,%vel);
	 }
	 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData LrgLasImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
//	projectileType = LrgLaser;
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 0.01;
	minEnergy = 15;
	maxEnergy = 25;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };

//	sfxFire = SoundFireLaser;
	sfxActivate = SoundItemArm;
};

ItemData LrgLas
{
	description = "Large ER Laser";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
   heading = "bLaser Systems";
	shadowDetailMask = 4;
	imageType = LrgLasImage;
	price = 200;
	showWeaponBar = true;
};
function LrgLas::onUse(%player,%item)//++++++++++++++++++++++++++++++
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Large ER Laser \nSlow rate of fire, high heat buildup \nHeavy damage \nLong range - over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function LrgLasImage::onFire(%player, %slot)
 {
   %enVal  = 25.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;

   if (%energy > 20.0)
	{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 playSound(SoundFireBlaster,GameBase::getPosition(%player));
		 Projectile::spawnProjectile("LrgLaser",%trans,%player,%vel);
		 Projectile::spawnProjectile("LrgLaserShell",%trans,%player,%vel);
	 }
	 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
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
      maxEnergy = 6;
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
   heading = "bLaser Systems";
	shadowDetailMask = 4;
	imageType = MedPLasImage;
	price = 125;
	showWeaponBar = true;
};

function MedPLas::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Medium Pulse Laser \nModerate heat buildup \nModerate damage \nLong range - over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function MedPLasImage::onFire(%player, %slot)
 {
   %enVal  = 6;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 25.0)
	{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("MediumPulseLaser",%trans,%player,%vel);
	}
	 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
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
      maxEnergy = 12;
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
  heading = "bLaser Systems";
	shadowDetailMask = 4;
	imageType = LrgPLasImage;
	price = 225;
	showWeaponBar = true;
};

function LrgPLas::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Large Pulse Laser \nHigh heat buildup \nHeavy damage \nLong range - over 500m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function LrgPLasImage::onFire(%player, %slot)
 {
   %enVal  = 12;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 35.0)
	{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("LargePulseLaser",%trans,%player,%vel);
	}
	 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}


//----------------------------------------------------------------------------
ItemImageData TargetingLaserImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
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
   heading = "bLaser Systems";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 25;
	showWeaponBar = false;
};

function TargetingLaser::onUse(%player,%item)//++++++++++++++++++++++++++++++
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using TAG \nLow heat buildup \nNo damage, displays range to target", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
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

      weaponType = 0;
	ammoType = MachineGunAmmo;
//	projectileType = MachineGunBullet;
	reloadTime = 0.1;
	fireTime = 0.75;
	accuFire = true;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 4;
   lightTime = 0.05;
	lightColor = { 0.75, 0.75, 0.35 };

//	sfxFire = SoundChainTurretFire;
	sfxActivate = SoundItemArm;

};

ItemData MachineGun
{
   description = "Machine Gun";
	shapeFile = "grenammo";
	hudIcon = "chain";
   className = "Weapon";
   heading = "eOther Weapons";
   shadowDetailMask = 4;
   imageType = MachineGunImage;
	showWeaponBar = true;
   price = 50;
};

function MachineGun::onUse(%player,%item)//++++++++++++++++++++++++++++++
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Machine Gun \nExtremely fast rate of fire, with no heat buildup. \nVery low damage \nVery short range - 125m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function MachineGunImage::onFire(%player, %slot)
 {
   %enVal  = 00;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 0.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[MachineGun]);
	 if(%AmmoCount > 0)
		{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 playSound(SoundChainTurretFire,GameBase::getPosition(%player));
		 for(%i = 10;  %i > 0; %i--)
	if(Player::getItemCount(%player, FCC))
		{
			 schedule("MachineGunImage::OnShoot2(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.075;
		}
		else
			{
			 schedule("MachineGunImage::OnShoot(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.075;
			}
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	}
	 else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		} 
	}


function MachineGunImage::OnShoot(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("MachineGunBullet",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[MachineGun],1);
	}
function MachineGunImage::OnShoot2(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("MachineGunBullet2",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[MachineGun],1);
	}

//----------------------------------------------------------------------------
ItemImageData FlamerImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 1;
//	projectileType = GrenadeShell;
	accuFire = true;
	reloadTime = 0.5;
	spinUpTime = 0.5;
	spinDownTime = 0.1;
	fireTime = 1.0; //0.01;

	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundItemArm;
	sfxSpinUp = SoundFlameIgnite;
	sfxSpinDown = SoundJetHeavy;
};

ItemData Flamer
{
	description = "Flamer";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "energyRifle";
   heading = "eOther Weapons";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 75;
	showWeaponBar = true;
};
function Flamer::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Flamer \nModerate rate of fire, with moderate heat buildup \nLittle damage, but overheats the target \nVery short range - 40m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}
function FlamerImage::onFire(%player, %slot)
 {
   %enVal  = 20.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 15.0)
	{
	if(Player::getItemCount(%player, FCC))
		{
   		 GameBase::setEnergy(%player,%energy);
		 playSound(SoundFireFlierRocket,GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("FlamerShell2",%trans,%player,%vel);
		}
	else
		{
		for(%i = 9;  %i > 0; %i--) 
		{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 schedule("FlamerImage::OnShoot(" @ %player @ ");", %timedelay);
		 %timedelay = %timedelay + 0.1;
		}
		}
	}
	 else
	{
	 Player::trigger(%player,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
	} 
}
function FlamerImage::OnShoot(%player, %slot)
{
   %enVal  = 3.0;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 5.0)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("FlamerShell",%trans,%player,%vel);
		 GameBase::setEnergy(%player,%energy);
	}
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
//	projectileType = SmokeShell;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.5, 0.16 };

//	sfxFire = SoundFireGrenade;
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
   heading = "eOther Weapons";
	shadowDetailMask = 4;
	imageType = SmokeLauncherImage;
	price = 95;
	showWeaponBar = true;
};

function SmokeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Using Smoke Launcher \nFires Smoke Cannisters \nVirtually no damage, used to impair enemy's vision \nEffective range - 80m", 5);
	 Client::sendMessage(Player::getClient(%player), 1,"~wMine_Act.wav");
}

function SmokeLauncherImage::onFire(%player, %slot)
 {
   %enVal  = 5;
   %energy = GameBase::getEnergy(%player);
   %energy = %energy - %enVal;
   if (%energy > 5.0)
	{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SmokeLauncher]);
	 if(%AmmoCount > 0)
		{
   		 GameBase::setEnergy(%player,%energy);
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 playSound(SoundFireGrenade,GameBase::getPosition(%player));
		 for(%i = 1;  %i > 0; %i--)
	if(Player::getItemCount(%player, FCC))
		{
			 schedule("SmokeLauncherImage::OnShoot2(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.075;
		}
		else
			{
			 schedule("SmokeLauncherImage::OnShoot(" @ %player @ ");", %timedelay);
			 %timedelay = %timedelay + 0.075;
			}
		}
	 else
		{	
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-Out of Ammo-~wError_Message.wav");
		 playSound(SoundDryFire,GameBase::getPosition(%player));
		}
	}
	 else
		{
		 Player::trigger(%player,$WeaponSlot,false);
		 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire- ~wC_BuySell.wav");
		} 
	}


function SmokeLauncherImage::OnShoot(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("SmokeShell",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[SmokeLauncher],1);
	}
function SmokeLauncherImage::OnShoot2(%player, %slot)
	{
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("SmokeShell2",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[SmokeLauncher],1);
	}


//----------------------------------------------------------------------------
ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 12;  // Energy used/sec for sustained weapons

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
{
	Weapon::onUse(%player,%item);//+++++++
	bottomprint(Player::getClient(%player), "<jc><f2>Using Welding Torch", 2);
//	bottomprint(Player::getClient(%player), "<jc><f2>Using Welding Torch/nIt will repair friendly targets or damage enemies/nRange - 8m", 5);
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
   heading = "hDeployable Stations";
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
   heading = "hDeployable Stations";
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
 	maxEnergy = -5; //-3;
	firstPerson = false;
};

ItemData DoubleHeatSink
{
	description = "Double Heat Sinks";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "gAttachments";
	shadowDetailMask = 4;
	imageType = DoubleHeatSinkImage;
	price = 150;
	hudIcon = "DoubleHeatSink";
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

//function DoubleHeatSink::onDrop(%player,%item)
//{
//	Client::sendMessage(Player::getClient(%player), 1,"-Double Heat Sinks can only be removed at a Mech Bay-~wError_Message.wav");
//	Player::mountItem(%player,%item,$BackpackSlot);
//}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
ItemImageData MASCPackImage
{
	mass = 10.0;
	shapeFile = "hover_apc_sml";
	mountPoint = 1;
	weaponType = 2;
	reloadTime = 0.01;
	fireTime = 0;
	minEnergy = 0;
	maxEnergy = 0;
	firstPerson = false;

	sfxFire = SoundGeneratorPower;
	sfxActivate = SoundItemArm;
};

ItemData MASCPack
{
	description = "Hunter Light Tank";
	shapeFile = "hover_apc_sml";
	className = "Backpack";
   heading = "gAttachments";
	shadowDetailMask = 4;
	imageType = MASCPackImage;
	price = 675;
	hudIcon = "DoubleHeatSink";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MASCPackImage::onMount(%player,%item)
{
 Player::trigger(%player,$BackpackSlot,true);
 %client = player::getClient(%player);
 %armor = player::getArmor(%player);
 %clientname:: = client::getName(%client);
 Item::onMount(%player,%item);
   if(%armor == "larmor")
	{
	Player::SetArmor(%clientId, driver);
      Player::setItemCount(%clientId,LRM15,1);
      Player::setItemCount(%clientId,MedLas,1);
      Player::setItemCount(%clientId,Flamer,1);
      Player::setItemCount(%clientId,LRMAmmo,60);
      Player::setItemCount(%clientId,RepairKit,1);
      Player::setItemCount(%clientId,Grenade,0);
      Player::setItemCount(%clientId,MineAmmo,0);
      Player::setItemCount(%clientId,Beacon,0);
	}
}

function MASCPackImage::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Client::sendMessage(Player::getClient(%player),0,"-Piloting a Hunter Light Tank- ~wpda_on.wav");
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function MASCPackImage::onDrop(%player,%item)
{
 Player::trigger(%player,$BackpackSlot,true);
 %client = player::getClient(%player);
 %armor = player::getArmor(%player);
 %clientname:: = client::getName(%client);
 Item::onMount(%player,%item);
   if(%armor == "driver")
	{
	Player::SetArmor(%client, larmor);
      Player::setItemCount(%clientId,MedLas,1);
      Player::setItemCount(%clientId,STR2,1);
      Player::setItemCount(%clientId,Flamer,1);
      Player::setItemCount(%clientId,STRAmmo,20);
      Player::setItemCount(%clientId,RepairKit,1);
      Player::setItemCount(%clientId,Grenade,3);
      Player::setItemCount(%clientId,MineAmmo,3);
      Player::setItemCount(%clientId,Beacon,1);
	Player::useItem(%pl,MedLas);
	}
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
   heading = "gAttachments";
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
   heading = "gAttachments";
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
   heading = "gAttachments";
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
		for(%i = 0; %i < 15 ; %i = %i +1) {
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
	for(%i = 0; %i < 15 ; %i = %i +1) {
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
		else {
			%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillMunitionsPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 15 ; %i = %i +1) {
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
	maxEnergy = 12;  // Energy used/sec for sustained weapons
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
   heading = "gAttachments";
	shadowDetailMask = 4;
	imageType = ECMPodImage;
	price = 185;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ECMPod::onMount(%player,%item)
{
	Client::sendMessage(Player::getClient(%player),0,"ECM Pod equipped ~wpda_on.wav");
}
function ECMPodImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"ECM Pod activated ~wsensor_deploy.wav");
	%rate = Player::getSensorSupression(%player) + 25;
	Player::setSensorSupression(%player,%rate);
}

function ECMPodImage::onDeactivate(%player,%imageSlot)
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

	minEnergy = 4;
 	maxEnergy = 2;
	firstPerson = false;
};

ItemData FCCPod
{
	description = "Fire-Control Computer";
	shapeFile = "ammopack";
	className = "Backpack";
   heading = "gAttachments";
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
   heading = "iDeployable Sensors";
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
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "RadarPack"]++;
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
   heading = "iDeployable Sensors";
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
   heading = "iDeployable Sensors";
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
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableECMPod"]++;
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
   heading = "iDeployable Sensors";
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
	description = "ER Laser Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "jDeployable Turrets";
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
					Gamebase::setMapName(%camera,"ER Laser Turret #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"ER Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "MedLasPack"]++;
//						Client::sendMessage(Player::getClient(%client), 3,"ER Laser Turret deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
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
	description = "Pulse Laser Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "jDeployable Turrets";
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
								Gamebase::setMapName(%turret,"PulseLaser Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Medium Pulse Laser Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "MedPLasPack"]++;
//								echo("MSG: ",%client," deployed a Medium Pulse Laser Turret");
								//	Remote turrets - kill points to player that deploy them
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
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
	description = "Streak Turret";
	shapeFile = "missileturret";
	className = "Backpack";
   heading = "jDeployable Turrets";
	imageType = LRM5PackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 200;
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
								Gamebase::setMapName(%turret,"Streak Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Streak Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "LRM5Pack"]++;
//						Client::sendMessage(Player::getClient(%client), 3,"Streak Turret deployed by "@Client::getName(%client)@"~wMine_Act.wav");//++++
								//	Remote turrets - kill points to player that deploy them
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
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
	shapeFile = "chainturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData STR2Pack
{
	description = "Streak Turret";
	shapeFile = "chainturret";
	className = "Backpack";
   heading = "jDeployable Turrets";
	imageType = STR2PackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 200;
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
								%turret = newObject("remoteTurret","Turret",STR2Turret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"STR Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Streak Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "STR2Pack"]++;
//								echo("MSG: ",%client," deployed a Streak Turret");
								//	Remote turrets - kill points to player that deploy them
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
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
   heading = "jDeployable Turrets";
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
   heading = "jDeployable Turrets";
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
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
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
   heading = "jDeployable Turrets";
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
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
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
   heading = "jDeployable Turrets";
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
								 Client::setOwnedObject(%client, %turret); 
								 Client::setOwnedObject(%client, %player);
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
   heading = "fSundries";
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
   heading = "fSundries";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
				%armor = Player::getArmor(%player);//+++++++++++
		     		if (%armor == "larmor" || %armor == "lfemale")//+++++
                            %obj = newObject("","Mine","antipersonelMine"); //+++
		     		if (%armor == "parmor" || %armor == "pfemale")//+++++
                            %obj = newObject("","Mine","antipersonelMine"); //+++
		     		if (%armor == "carmor" || %armor == "cfemale")//+++++
                            %obj = newObject("","Mine","antipersonelMine"); //+++
				if (%armor == "dmarmor" || %armor == "dmfemale")//+++++
                            %obj = newObject("","Mine","DmMine");//++++++++ 
				if (%armor == "marmor" || %armor == "mfemale")//+++++
                            %obj = newObject("","Mine","antipersonelMine");//++++++++ 
				if (%armor == "hbarmor" || %armor == "hbfemale")//+++++
                            %obj = newObject("","Mine","antipersonelMine");//++++++++ 
				if (%armor == "aarmor" || %armor == "afemale")//+++++
                            %obj = newObject("","Mine","antipersonelMine");//++++++++ 
				if (%armor == "barmor")//+++++
                            %obj = newObject("","Mine","antipersonelMine");//++++++++ 
				if (%armor == "harmor")//+++++
                            %obj = newObject("","Mine","antipersonelMine");//++++++++ 
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,20 * %client.throwStrength,false);//15+++
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));//+++++++++++++
		}
	}
}

//----------------------------------------------------------------------------
ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "fSundries";
   shadowDetailMask = 4;
//   showInventory = false;//++++++++++++++++++++
   price = 15;
	className = "HandAmmo";
};

ItemData NukeGrenade
{
   description = "Pentaglycerine";
   shapeFile = "grenade";
   heading = "fSundries";
   shadowDetailMask = 4;
   price = 15;
	className = "HandAmmo";
};

ItemData InfernoGrenade
{
   description = "Inferno Grenade";
   shapeFile = "grenade";
   heading = "fSundries";
   shadowDetailMask = 4;
   price = 15;
	className = "HandAmmo";
};

ItemData SmokeHandGrenade
{
   description = "Smoke Grenade";
   shapeFile = "grenade";
   heading = "fSundries";
   shadowDetailMask = 4;
   price = 15;
	className = "HandAmmo";
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
			%obj2 = newObject("","Mine","Handgrenade2");
 	 	 	addToSet("MissionCleanup", %obj);
 	 	 	addToSet("MissionCleanup", %obj2); 
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			GameBase::throw(%obj2,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
function GrenadeNew::onUse(%player,%item)
{
	Player::decItemCount(%player,%item,1);
	if(Player::getItemCount(%player, NukeGrenade))
{
	if($matchStarted)
	 {
		if(%player.throwTime < getSimTime())
		 {
			Player::decItemCount(%player,$HandAmmo[NapalmGrenade],1);
			%obj = newObject("","Mine","Handgrenade");
			%obj2 = newObject("","Mine","Handgrenade2");//+++++++
 	 	 	addToSet("MissionCleanup", %obj);
 	 	 	addToSet("MissionCleanup", %obj2); //+++++++
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			GameBase::throw(%obj2,%player,9 * %client.throwStrength,false);//+++++++++
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
	else if(Player::getItemCount(%player, InfernoGrenade))
{
	if($matchStarted)
	 {
		if(%player.throwTime < getSimTime())
		 {
			Player::decItemCount(%player,$HandAmmo[InfernoGrenade],1);
			%obj = newObject("","Mine","Napalmgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
	else if(Player::getItemCount(%player, SmokeHandGrenade))
{
	if($matchStarted)
	 {
		if(%player.throwTime < getSimTime())
		 {
			Player::decItemCount(%player,$HandAmmo[SmokeHandGrenade],1);
			%obj = newObject("","Mine","SmokerGrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
}
ItemData a
{
   description = "a";
   shapeFile = "grenade";
   showInventory = false;
   heading = "fSundries";
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
   heading = "fSundries";
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
   heading = "fSundries";
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
   heading = "fSundries";
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
   heading = "fSundries";
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
   heading = "fSundries";
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
   heading = "fSundries";
   shadowDetailMask = 4;
   price = 50;
	className = "HandAmmo";
};

function Beacon::onUse(%player,%item, %clientId)
{
	%armor = Player::getArmor(%player);
	%energy = GameBase::getEnergy(%player);
	if (%armor == "larmor")
	{
	   %enVal  = 50.0;
	   %vertical = 170.0;
	   %velocity = 210.0;
	}
	else if (%armor == "parmor")
	{
	   %enVal  = 50.0;
	   %vertical = 225.0;
	   %velocity = 225.0;
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
	   %vertical = 450.0;
	   %velocity = 400.0;
	}
	else if (%armor == "aarmor")
	{
	   %enVal  = 90.0;
	   %vertical = 400.0;
	   %velocity = 400.0;
	}
	else if (%armor == "barmor")
	{
	   %enVal  = 90.0;
	   %vertical = 550.0;
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
   heading = "fSundries";
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
		Player::setItemCount(%clientId,Blaster,1); //AI PPC +++++
		Player::setItemCount(%clientId,PPC,1);
		Player::setItemCount(%clientId,Ultra10,1);
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
		Player::setItemCount(%clientId,STR6,1);

		Player::setItemCount(%clientId,SmokeAmmo,200);
		Player::setItemCount(%clientId,LRMAmmo,200);
		Player::setItemCount(%clientId,STRAmmo,200);
		Player::setItemCount(%clientId,ArrowIVAmmo,200);
		Player::setItemCount(%clientId,AC5Ammo,200);
		Player::setItemCount(%clientId,AC10Ammo,200);
		Player::setItemCount(%clientId,AC20Ammo,200);
		Player::setItemCount(%clientId,Ultra5Ammo,200);
		Player::setItemCount(%clientId,Ultra10Ammo,200);
		Player::setItemCount(%clientId,Ultra20Ammo,200);
		Player::setItemCount(%clientId,MachineGunAmmo,200);
		Player::setItemCount(%clientId,GaussGunAmmo,200);
		Player::setItemCount(%clientId,SniperGunAmmo,200);

 	   	Player::setItemCount(%clientId,NukeGrenade, 200);//++++
 	   	Player::setItemCount(%clientId,InfernoGrenade, 200);//+++++++
 	   	Player::setItemCount(%clientId,SmokeHandGrenade, 200);//++++
 	   	Player::setItemCount(%clientId,Grenade, 200);
	      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,SmokeAmmo,$ItemMax[%armor, SmokeAmmo]);
		Player::setItemCount(%clientId,LRMAmmo,$ItemMax[%armor, LRMAmmo]);
		Player::setItemCount(%clientId,STRAmmo,$ItemMax[%armor, STRAmmo]);
		Player::setItemCount(%clientId,ArrowIVAmmo,$ItemMax[%armor, ArrowIVAmmo]);
		Player::setItemCount(%clientId,AC5Ammo,$ItemMax[%armor, AC5Ammo]);
		Player::setItemCount(%clientId,AC10Ammo,$ItemMax[%armor, AC10Ammo]);
		Player::setItemCount(%clientId,AC20Ammo,$ItemMax[%armor, AC20Ammo]);
		Player::setItemCount(%clientId,Ultra5Ammo,$ItemMax[%armor, Ultra5Ammo]);
		Player::setItemCount(%clientId,Ultra10Ammo,$ItemMax[%armor, Ultra10Ammo]);
		Player::setItemCount(%clientId,Ultra20Ammo,$ItemMax[%armor, Ultra20Ammo]);
		Player::setItemCount(%clientId,MachineGunAmmo,$ItemMax[%armor, MachineGunAmmo]);
		Player::setItemCount(%clientId,GaussGunAmmo,$ItemMax[%armor, GaussGunAmmo]);
		Player::setItemCount(%clientId,SniperGunAmmo,$ItemMax[%armor, SniperGunAmmo]);

	      Player::setItemCount(%clientId,NukeGrenade, $ItemMax[%armor, NukeGrenade]);//++++
	      Player::setItemCount(%clientId,InfernoGrenade, $ItemMax[%armor, InfernoGrenade]);//++++
	      Player::setItemCount(%clientId,SmokeHandGrenade, $ItemMax[%armor, SmokeHandGrenade]);//+++++
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
shadowDetailMask = 4; 
imageType = STRPackPImage; 
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
mountOffset = {0.13, 0.3, -0.1};
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
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
mountOffset = { 0.3, 0.11, 0.6 };
//{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}++++
mountRotation = { 0.2, 3.1, 0 }; //{ 0.2, 0, 0 };
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
heading = "gAttachments"; 
shadowDetailMask = 4;
 imageType = LRMPackAImage; 
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
heading = "gAttachments"; 
shadowDetailMask = 4; 
imageType = MLPackAImage; 
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
shadowDetailMask = 4;
 imageType = RadarPackHImage; 
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
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
heading = "gAttachments"; 
shadowDetailMask = 4; 
imageType = GaussPackHImage; 
price = 1; 
hudIcon = "mortar"; 
showWeaponBar = false; 
hiliteOnActive = true; 
showInventory = false; 
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

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
