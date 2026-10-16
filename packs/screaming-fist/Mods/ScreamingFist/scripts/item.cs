echo("Loading Screaming Fist Version");
//----------------------------------------------------------------------------

$ItemFavoritesKey = "SF";  // Change this if you add new items
// and don't want to mess up everyone's
// favorites - just put in something
// that uniquely describes your new stuff.

//----------------------------------------------------------------------------

$ItemPopTime = 30;
$HackEffectTimeLimit = 20;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

//*************************************************************************************************************
// SF Addition - Begin - 8/3/99 - 11:30AM
//*************************************************************************************************************

$AutoUse[TargetingLaser] = False;
$AutoUse[Detonator] = False;

$Use[Glock] = True;

$ArmorType[Male, ConsoleMan] = cmmale;
$ArmorType[Male, SpecialOps] = somale;
$ArmorType[Male, Infantry] = imale;
$ArmorType[Male, HeavyInfantry] = himale;
$ArmorType[Male, Dm] = dmale;


$ArmorType[Female, ConsoleMan] = cmfemale;
$ArmorType[Female, SpecialOps] = sofemale;
$ArmorType[Female, Infantry] = ifemale;
$ArmorType[Female, HeavyInfantry] = hifemale;
$ArmorType[Female, Dm] = dfmale;

$ArmorName[cmmale] = ConsoleMan;
$ArmorName[somale] = SpecialOps;
$ArmorName[imale] = Infantry;
$ArmorName[himale] = HeavyInfantry;
$ArmorName[dmale] = Dm;

$ArmorName[cmfemale] = ConsoleMan;
$ArmorName[sofemale] = SpecialOps;
$ArmorName[ifemale] = Infantry;
$ArmorName[hifemale] = HeavyInfantry;
$ArmorName[dfmale] = Dm;

$TeamItemMax[Detpack] = 4;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[RemMineAmmo] = 35;
$TeamItemMax[DeployableMedicPack] = 7;
$TeamItemMax[FBW] = 4;
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[OspreyVehicle] = 1;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 12;
$TeamItemMax[MineAmmo] = 35;
$TeamItemMax[GRoCCannonPack] = 4;

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

//*************************************************************************************************************
// SF Addition - Begin - 8/3/99 - 2:00PM
//*************************************************************************************************************

// Global object damage skins (staticShapes Turrets Stations Sensors)
DamageSkinData bridgeDamageSkins
{
	bmpName[0] = "dobj1_bridge";
	bmpName[1] = "dobj2_bridge";
	bmpName[2] = "dobj3_bridge";
	bmpName[3] = "dobj4_bridge";
	bmpName[4] = "dobj5_bridge";
	bmpName[5] = "dobj6_bridge";
	bmpName[6] = "dobj7_bridge";
	bmpName[7] = "dobj8_bridge";
	bmpName[8] = "dobj9_bridge";
	bmpName[9] = "dobj10_bridge";
};

$AutoUse[Minigun] = True;
$AutoUse[AssRifle] = True;
$AutoUse[Shotgun] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[Glock] = True;
$AutoUse[RocketLauncher] = True;
$AutoUse[FBWRocketLauncher] = True;
$AutoUse[SilencedGlock] = True;
$AutoUse[SilencedAssRifle] = True;
$AutoUse[MAWAssRifle] = True;
$AutoUse[MAWIncendiaryRifle] = True;
$AutoUse[MAWGrenadeLauncher] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[HomingFlaregun] = True;

$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[RemMineAmmo] = 5;
$SellAmmo[FlashGrenade] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[MinigunAmmo] = 500;
$SellAmmo[AssRifleAmmo] = 30;
$SellAmmo[ShotgunAmmo] = 12;
$SellAmmo[SniperRifleAmmo] = 5;
$SellAmmo[GlockAmmo] = 50;
$SellAmmo[RocketLauncherAmmo] = 1;
$SellAmmo[FBWRocketAmmo] = 1;
$SellAmmo[MAWGrenadeAmmo] = 12;
$SellAmmo[MAWIncendiaryRifleAmmo] = 15;
$SellAmmo[HomingFlareAmmo] = 10;

//AmmoPack Tables
$AmmoPackMax[AssRifleAmmo] = 120;
$AmmoPackMax[ShotgunAmmo] = 24;
$AmmoPackMax[SniperRifleAmmo] = 5;
$AmmoPackMax[GlockAmmo] = 150;
$AmmoPackMax[MinigunAmmo] = 0;
$AmmoPackMax[MAWIncendiaryRifleAmmo] = 10;
$AmmoPackMax[MAWGrenadeAmmo] = 12;
$AmmoPackMax[RocketLauncherAmmo] = 2;
$AmmoPackMax[FBWRocketAmmo] = 1;
$AmmoPackMax[MineAmmo] = 3;
$AmmoPackMax[RemMineAmmo] = 3;
$AmmoPackMax[Grenade] = 5;
$AmmoPackMax[FlashGrenade] = 5;
$AmmoPackMax[Beacon] = 0;

$AmmoPackItems[0] = GlockAmmo;
$AmmoPackItems[1] = AssRifleAmmo;
$AmmoPackItems[2] = ShotgunAmmo;
$AmmoPackItems[3] = SniperRifleAmmo;
$AmmoPackItems[5] = MAWIncendiaryRifleAmmo;
$AmmoPackItems[6] = MAWGrenadeAmmo;
$AmmoPackItems[7] = RocketLauncherAmmo;
$AmmoPackItems[8] = FBWRocketAmmo;
$AmmoPackItems[9] = MinigunAmmo;
$AmmoPackItems[10] = Grenade;
$AmmoPackItems[11] = MineAmmo;
$AmmoPackItems[12] = RemMineAmmo;
$AmmoPackItems[13] = FlashGrenade;
$AmmoPackItems[14] = Beacon;


//FuelPack Tables
$FuelPackMax[FlamerAmmo] = 350;
$FuelPackItems[0] = FlamerAmmo;

//MinigunPack Tables
$MinigunAmmoPackMax[MinigunAmmo] = 500;
$MinigunAmmoPackItems[0] = MinigunAmmo;

//Ammo Tables
$WeaponAmmo[Minigun] = MinigunAmmo;
$WeaponAmmo[AssRifle] = AssRifleAmmo;
$WeaponAmmo[SilencedAssRifle] = AssRifleAmmo;
$WeaponAmmo[SniperRifle] = SniperRifleAmmo;
$WeaponAmmo[Glock] = GlockAmmo;
$WeaponAmmo[Shotgun] = ShotgunAmmo;
$WeaponAmmo[SilencedGlock] = GlockAmmo;
$WeaponAmmo[RocketLauncher] = RocketLauncherAmmo;
$WeaponAmmo[FBWRocketLauncher] = FBWRocketAmmo;
$WeaponAmmo[MAWGrenadeLauncher] = MAWGrenadeAmmo;
$WeaponAmmo[MAWAssRifle] = AssRifleAmmo;
$WeaponAmmo[MAWIncendiaryRifle] = MAWIncendiaryRifleAmmo;
$WeaponAmmo[GrenadeLauncher] = MAWGrenadeAmmo;
$WeaponAmmo[OspreyTurret] = OspreyTurretAmmo;
$WeaponAmmo[HomingFlaregun] = HomingFlareAmmo;
//*************************************************************************************************************
// SF Addition - end
//*************************************************************************************************************

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
							//*************************************************************************************************************
							// SF Addition - Begin - 8/3/99 - 11:30AM
							//*************************************************************************************************************
						{
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
							if( %item == MAWAssRifle)
							{
								Player::decItemCount(%client, MAWIncendiaryRifle, 1);
								Player::decItemCount(%client, MAWGrenadeLauncher, 1);
							}
							else if (%item == RocketLauncher )
								Player::decItemCount(%client, FBWRocketLauncher, 1);
						}
						//*************************************************************************************************************
						// SF Addition - End
						//*************************************************************************************************************
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
	//*******************************************************************
	//   SF ADDITION - 5/30/99 - 1:00PM
	//*******************************************************************
	// Fuel pack 
	else if (Player::getMountedItem(%client,$BackpackSlot) == FuelPack && $FuelPackMax[%item] != "") {
		%extraAmmo = $FuelPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	// Minigun Pack
	else if (Player::getMountedItem(%client,$BackpackSlot) == MinigunAmmoPack && $MinigunAmmoPackMax[%item] != "") {
		%extraAmmo = $MinigunAmmoPackMax[%item];
		if(%delta == $ItemMax[Player::getArmor(%client), %item]) 
			%delta = %delta + %extraAmmo;
	}
	//*******************************************************************
	// SF END
	//*******************************************************************
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
		//*************************************************************************************************************
		// SF Addition - Begin - 8/3/99 - 9:30PM
		//*************************************************************************************************************
		if (Player::getItemClassCount(%client,"Weapon") > 0 && %item == MAWAssRifle) {
			Client::sendMessage(%client,0,"Can not carry MAW while carrying other weapons.");
			return 0;
		}
		if (Player::getItemClassCount(%client,"Weapon") > 1 && %item == RocketLauncher) {
			if( %armor != "dmale" && %armor != "dfmale" )
			{
				Client::sendMessage(%client,0,"Must have 2 weapon slots open to carry the Rocket Launcher.");
				return 0;
			}
		}
		//*************************************************************************************************************
		// SF Addition - End
		//*************************************************************************************************************
	}
	else if(%item == RepairPatch) {
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) 
			return 1;
		return 0;
	}
	else if($TeamItemMax[%item] != "" && !$TestCheats) {
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) {
			Client::sendMessage(%client,0,"Item limit reached for " @ %item.description @ "s");
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
					//*************************************************************************************************************
					// SF Addition - Begin - 5/30/99 - 4:00PM
					//*************************************************************************************************************
					if (Player::getMountedItem(%client,$BackpackSlot) == FuelPack) 
						fillPackFuel(%client);
					if (Player::getMountedItem(%client,$BackpackSlot) == MinigunAmmoPack) 
						fillMinigunAmmoPack(%client);	
					//*************************************************************************************************************
					// SF Addition - End
					//*************************************************************************************************************
					return 1;
				}
				
				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else
			if (%item.className == Backpack) {
				if($TeamItemMax[%item] != "") {						
					if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
						return 0;
				}
				
				// Only one backpack per armor.
				%pack = Player::getMountedItem(%client,$BackpackSlot);
				if (%pack != -1) {
					if(%pack == ammopack) 
						checkMax(%client,%armor);
					//**********************************************************************
					// SF Addition - 5/30/99 - 1:00PM
					//**********************************************************************
					//FIX ME
					// Fuel Pack sold, sell Flamer
					if(%pack == FuelPack) {					
						if(Player::getItemCount(%client,"Flamethrower") > 0) {
							Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Flamethrower");
							remoteSellItem(%client,16);						
						}
					}
					// Ammo Pack Sold, sell Minigun
					else
						if(%pack == MinigunAmmoPack) {					
							if(Player::getItemCount(%client,"Minigun") > 0) {
								checkMax(%client,%armor);
								Client::sendMessage(%client,0,"Sold Minigun Ammo Pack - Auto Selling Minigun");
								remoteSellItem(%client,28);						
							}
						}
						// Deck Sold, sell Console Jack
						else
						{
							if(%pack == DeckPack) {					
								if(Player::getItemCount(%client,"ConsoleJack") > 0) {
									checkMax(%client,%armor);
									Client::sendMessage(%client,0,"Sold the Deck - Auto Selling Console Jack");
									remoteSellItem(%client,37);						
								}
								// Deck Sold, sell GRoC Gun					
								if(Player::getItemCount(%client,"HomingFlaregun") > 0) {
									checkMax(%client,%armor);
									Client::sendMessage(%client,0,"Sold the Deck - Auto Selling GRoC Gun");
									remoteSellItem(%client,36);						
								}
							}
						}
						//**********************************************************************
						// SF END
						//**********************************************************************
						teamEnergyBuySell(%player,%pack.price);
						Player::decItemCount(%client,%pack);
				}			   
				if (checkResources(%player,%item,1) || $testCheats) {
					teamEnergyBuySell(%player,%item.price * -1);
					Player::incItemCount(%client,%item);
					Player::useItem(%client,%item);
					if(%item == ammopack) 
						fillAmmoPack(%client);
					//*************************************************************************************************************
					// SF Addition - Begin - 5/30/99 - 4:30PM
					//*************************************************************************************************************
					if(%item == FuelPack) 
						fillPackFuel(%client);
					if(%item == MinigunAmmoPack) 
						fillMinigunAmmoPack(%client);
					//*************************************************************************************************************
					// SF Addition - End
					//*************************************************************************************************************
					return 1;
				}
				else
					if(%pack != -1) {
						teamEnergyBuySell(%player,%pack.price * -1);
						Player::incItemCount(%client,%pack);
						Player::useItem(%client,%pack);
						if(%pack == ammopack) 
							fillAmmoPack(%client);
						//*************************************************************************************************************
						// SF Addition - Begin - 5/30/99 - 4:30PM
						//*************************************************************************************************************
						else
							if(%pack == FuelPack) 
								fillPackFuel(%client);
							else
								if(%pack == MinigunAmmoPack) 
									fillMinigunAmmoPack(%client);
								//*************************************************************************************************************
								// SF Addition - End
								//*************************************************************************************************************
					}				 
			}
			else
				if(%item.className == Weapon) {
					if(checkResources(%player,%item,1)) {
						//*************************************************************************************************************
						// SF Addition - Begin - 8/3/99 - 10:30PM
						//*************************************************************************************************************
						// Minigun baught, autobuy pack
						if(%item == Minigun && Player::getItemCount(%client,"MinigunAmmoPack") == 0)
						{
							buyItem(%client,"MinigunAmmoPack");
							Client::sendMessage(%client,0,"Bought Minigun - Auto buying Minigun Ammo Pack");
						}
						// Flamer baught, autobuy pack
						else
							if(%item == FlamerGun && Player::getItemCount(%client,"FuelPack") == 0)
							{
								buyItem(%client,"FuelPack");
								Client::sendMessage(%client,0,"Bought Flamethrower - Auto buying Fuel Pack");
							}
							// Console Jack baught, autobuy pack
							else
								if(%item == ConsoleJack && Player::getItemCount(%client,"DeckPack") == 0)
								{
									buyItem(%client,"DeckPack");
									Client::sendMessage(%client,0,"Bought Console Jack - Auto buying the Deck");
								}
								// GRoC Gun baught, autobuy pack
								else
									if(%item == HomingFlaregun && Player::getItemCount(%client,"DeckPack") == 0)
									{
										buyItem(%client,"DeckPack");
										Client::sendMessage(%client,0,"Bought GRoC Gun - Auto buying the Deck");
									}
									Player::incItemCount(%client,%item);
									// MAW Baught, autobuy the rest of it
									if(%item == MAWAssRifle)
									{
										%ammoItem =  %item.imageType.ammoType; 
										if(%ammoItem != "") {
											%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
											if(%delta) {
												teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
												Player::incItemCount(%client,%ammoitem,%delta);
											}
										}
										Player::incItemCount(%client, MAWIncendiaryRifle, 1);
										Player::incItemCount(%client, MAWGrenadeLauncher, 1);
										Client::sendMessage(%client,0,"Bought the MAW");
										%item = MAWIncendiaryRifle;
										%ammoItem =  %item.imageType.ammoType; 
										if(%ammoItem != "") {
											%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
											if(%delta) {
												teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
												Player::incItemCount(%client,%ammoitem,%delta);
											}
										}
										%item = MAWGrenadeLauncher;
									}
									// Rocket Baught, autobuy the rest of it
									if(%item == RocketLauncher)
									{
										%ammoItem =  %item.imageType.ammoType; 
										if(%ammoItem != "") {
											%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
											if(%delta) {
												teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
												Player::incItemCount(%client,%ammoitem,%delta);
											}
										}
										Player::incItemCount(%client, FBWRocketLauncher, 1);
										Client::sendMessage(%client,0,"Bought the Rocket Launcher");
										%item = FBWRocketLauncher;
									}
									//*************************************************************************************************************
									// SF Addition - end
									//*************************************************************************************************************
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
			//*************************************************************************************************************
			// SF Addition - Begin - 8/3/99 - 11:30PM
			//*************************************************************************************************************
			//FIX ME!!!
			// Minigun Ammo Pack sold, sell Minigun
			else if(%item == MinigunAmmoPack) {
				if(Player::getItemCount(%client,"Minigun") > 0) {
					Client::sendMessage(%client,0,"Sold Minigun Ammo Pack - Auto Selling Minigun");
					remoteSellItem(%client,28);
				}
				checkMax(%client,Player::getArmor(%client));
			}
			// Deck sold, sell Console Jack
			else if(%item == DeckPack) {
				if(Player::getItemCount(%client,"ConsoleJack") > 0) {
					Client::sendMessage(%client,0,"Sold the Deck - Auto Selling Console Jack");
					remoteSellItem(%client,37);
				}
				// Deck sold, sell GRoC Gun
				if(Player::getItemCount(%client,"HomingFlaregun") > 0) {
					Client::sendMessage(%client,0,"Sold the Deck - Auto Selling GRoC Gun");
					remoteSellItem(%client,36);
				}
				checkMax(%client,Player::getArmor(%client));
			}
			// Fuel Pack sold, sell Flamer
			else if (%item == FuelPack) {
				if(Player::getItemCount(%client,"Flamergun") > 0) {
					Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Flamethrower");
					remoteSellItem(%client,18);
				}
				checkMax(%client,Player::getArmor(%client));
			}
			// The MAW sold, selling all three modes
			else if (%item == MAWAssRifle) {
				Player::decItemCount(%client, MAWIncendiaryRifle, 1);
				Player::decItemCount(%client, MAWGrenadeLauncher, 1);
				checkMax(%client,Player::getArmor(%client));
			}
			// The Rocket Launcher sold, selling all modes
			else if (%item == RocketLauncher) {
				Player::decItemCount(%client, FBWRocketLauncher, 1);
				checkMax(%client,Player::getArmor(%client));
			}
			//*************************************************************************************************************
			// SF Addition - end
			//*************************************************************************************************************
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

//*************************************************************************************************************
// SF Addition - Begin - 12/22/99 - 11:30AM
//*************************************************************************************************************
function remoteThrowItem(%client,%type,%strength)
{
	%item = getItemData(%type);
	if (%item == Grenade || %item == FlashGrenade || %item == MineAmmo || %item == RemMineAmmo) {
		if (%strength < 0)
			%strength = 0;
		else
			if (%strength > 100)
				%strength = 100;
			%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
			
			if( $TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]
				|| %item == Grenade || %item == FlashGrenade )
				Player::useItem(%client,%item);
			else
				Client::sendMessage(%client,0,"Item Limit Of "@$TeamItemMax[%item]@" For "@%item@" Reached");
	}
}
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************
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
			//*************************************************************************************************************
			// SF Addition - 8/4/99 - 10:30AM
			//*************************************************************************************************************
			if( %item == MAWAssRifle || %item == MAWGrenadeLauncher || %item == MAWIncendiaryRifle )
			{
				Player::setItemCount(%client, MAWIncendiaryRifle, 0);
				Player::setItemCount(%client, MAWGrenadeLauncher, 0);
				%item = MAWAssRifle;
			}
			else if(%item == RocketLauncher || %item == FBWRocketLauncher )
			{
				Player::setItemCount(%client, FBWRocketLauncher, 0);
				%item = RocketLauncher;
			}
			Player::dropItem(%client,%item);
			//*************************************************************************************************************
			// SF Addition - End
			//*************************************************************************************************************
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

//*************************************************************************************************************
// SF Addition - Begin - 8/11/99 - 8:30PM
//*************************************************************************************************************
//
$NextWeapon[Glock] = SilencedGlock;
$NextWeapon[SilencedGlock] = AssRifle;
$NextWeapon[AssRifle] = SilencedAssRifle;
$NextWeapon[SilencedAssRifle] = Shotgun;
$NextWeapon[Shotgun] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = SniperRifle;
$NextWeapon[SniperRifle] = MAWAssRifle;
$NextWeapon[MAWAssRifle] = MAWIncendiaryRifle;
$NextWeapon[MAWIncendiaryRifle] = MAWGrenadeLauncher;
$NextWeapon[MAWGrenadeLauncher] = MiniGun;
$NextWeapon[MiniGun] = HomingFlaregun;
$NextWeapon[HomingFlaregun] = RocketLauncher;
$NextWeapon[RocketLauncher] = FBWRocketLauncher;
$NextWeapon[FBWRocketLauncher] = Detonator;
$NextWeapon[Detonator] = OspreyTurret;
$NextWeapon[OspreyTurret] = ConsoleJack;
$NextWeapon[ConsoleJack] = Glock;

$PrevWeapon[SilencedGlock] = Glock;
$PrevWeapon[AssRifle] = SilencedGlock;
$PrevWeapon[SilencedAssRifle] = AssRifle;
$PrevWeapon[Shotgun] = SilencedAssRifle;
$PrevWeapon[GrenadeLauncher]= Shotgun;
$PrevWeapon[SniperRifle] = GrenadeLauncher;
$PrevWeapon[MAWAssRifle] = SniperRifle;
$PrevWeapon[Minigun] = MAWAssRifle;
$PrevWeapon[HomingFlaregun] = Minigun;
$PrevWeapon[RocketLauncher] = HomingFlaregun;
$PrevWeapon[Detonator] = RocketLauncher;
$PrevWeapon[OspreyTurret] = Detonator;
$PrevWeapon[ConsoleJack] =  OspreyTurret;
$PrevWeapon[Glock] =  ConsoleJack;

//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

function remoteNextWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
		selectValidWeapon(%client);
	else {
		for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) {
			if (isSelectableWeapon(%client,%weapon)) {
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
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
		for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon]) {
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
	%item = FBWRocketLauncher;
	for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) {
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
				//*************************************************************************************************************
				// SF Addition - Begin - 8/16/99 - 10:30AM
				//*************************************************************************************************************
				if(%item == MAWIncendiaryRifle)
					return 0;
				if(%item == MAWGrenadeLauncher)
					return 0;
				if(%item == FBWRocketLauncher)
					return 0;
				if(%item == MAWAssRifle)
				{
					if (Player::getItemClassCount(%player,"Weapon") == 0)
					{
						Player::incItemCount(%client, MAWIncendiaryRifle, 1);
						Player::incItemCount(%client, MAWGrenadeLauncher, 1);
					}
					else
						return 0;
				}
				if(%item == RocketLauncher)
				{
					if (Player::getItemClassCount(%player,"Weapon") <= 1)
						Player::incItemCount(%client, FBWRocketLauncher, 1);
					else
						if( %armor == "dmale" || %armor == "dfmale" )
							Player::incItemCount(%client, FBWRocketLauncher, 1);
						else
							return 0;
				}
				//*************************************************************************************************************
				// SF Addition - Begin - End
				//*************************************************************************************************************
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
				%extraAmmo = $AmmoPackMax[%item];
			//*************************************************************************************************************
			// SF Addition - Begin - 5/30/99 - 5:00PM
			//*************************************************************************************************************
			else if (Player::getMountedItem(%client,$BackpackSlot) == FuelPack && $FuelPackMax[%item] != "") 
				%extraAmmo = $FuelPackMax[%item];
			else if (Player::getMountedItem(%client,$BackpackSlot) == MinigunAmmoPack && $MinigunAmmoPackMax[%item] != "") 
				%extraAmmo = $MinigunAmmoPackMax[%item];
			//*************************************************************************************************************
			// SF Addition - End
			//*************************************************************************************************************
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
			//*************************************************************************************************************
			// SF Addition - Begin - 5/7/99 - 10:30PM
			//*************************************************************************************************************
			//Drops Minigun Ammo Pack when trying to Drop Minigun Ammo and same with Fuel Pack and Flamer Fuel
			if(%item != MinigunAmmo && %item != FlamerAmmo)
			{
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
			else
			{
				remoteEval(Player::getClient(%player), BP, "<jc><f0>Minigun Ammo Pack Dropped", 3);
				%item = Player::getMountedItem(%player,$BackpackSlot);
				Player::dropItem(%player,%item);
			}
			//*************************************************************************************************************
			// SF Addition - End
			//*************************************************************************************************************
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
	remoteEval(2048,deployItem,%type);
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

//*************************************************************************************************************
// SF Addition - Begin - 5/3/99 - 3:30PM
//*************************************************************************************************************
//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData Infantry
{
	heading = "aArmor";
	description = "Infantry";
	className = "Armor";
	price = 250;
};

ItemData ConsoleMan
{
	heading = "aArmor";
	description = "Technician";
	className = "Armor";
	price = 300;
};

ItemData SpecialOps
{
	heading = "aArmor";
	description = "Special Ops";
	className = "Armor";
	price = 300;
};

ItemData HeavyInfantry
{
	heading = "aArmor";
	description = "Heavy Infantry";
	className = "Armor";
	price = 400;
};

//*************************************************************************************************************
// SF Additions - End
//*************************************************************************************************************

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Attack Comanche";
	className = "Vehicle";
	heading = "aVehicle";
	price = 600;
};

ItemData OspreyVehicle
{
	description = "Osprey Transport";
	className = "Vehicle";
	heading = "aVehicle";
	price = 1200;
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
		//*************************************************************************************************************
		// SF Addition - Begin - 5/30/99 - 1:30PM
		//*************************************************************************************************************
		//Can't drop Minigun Ammo
		if(%item != MinigunAmmo && %item != FlamerAmmo)
		{
			%count = Player::getItemCount(%player,%item);
			%delta = $SellAmmo[%item];
			if(%count <= %delta)
			{ 
				if( %item == AssRifleAmmo || GlockAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
					%delta = %count;
				else 
					%delta = %count - 1;
			}
			if(%delta > 0)
			{
				%obj = newObject("","Item",%item,%delta,false);
				schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
				
				addToSet("MissionCleanup", %obj);
				GameBase::throw(%obj,%player,5,false);
				Item::playPickupSound(%obj);
				Player::decItemCount(%player,%item,%delta);
			}
		}
		else
		{
			remoteEval(Player::getClient(%player), BP, "<jc><f0>Minigun Ammo Pack Dropped", 3);
			%item = Player::getMountedItem(%player,$BackpackSlot);
			Player::dropItem(%player,%item);
		}
		//*************************************************************************************************************
		// SF Addition - End
		//*************************************************************************************************************
	}
}	

//*************************************************************************************************************
// SF Addition - Begin - 8/23/99 - 11:30AM
//*************************************************************************************************************

ItemData GlockAmmo
{
	description = "9mm Handgun Shells";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo-calico";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GlockImage
{
	shapeFile = "calico";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = GlockAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.05;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	
	sfxFire = SoundFireGlock;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundGlockReload;
};

ItemData Glock
{
	description = "Handgun";
	className = "Weapon";
	shapeFile = "calico";
	hudIcon = "handgun";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GlockImage;
	price = 175;
	showWeaponBar = true;
};

function GlockImage::onFire(%player, %slot) 
{
	%trans = LabRat::GetMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rand = getRandom();
	if (%rand <= 0.2)
		%proj = Projectile::spawnProjectile("GlockBullet",%trans,%player,%vel);
	else
		%proj = Projectile::spawnProjectile("InvisGlockBullet",%trans,%player,%vel);
	
	//ShellEject(%proj);
	Player::decItemCount(%player, GlockAmmo, 1);

	//Desguise Pack Deactivate
	//%client = Player::getClient(%player);
	//if($DisguiseOrig[%client] != "")
	//	Player::trigger(%player,$BackpackSlot,false);
}

//-----------------------------------------------------------------------

ItemData AssRifleAmmo
{
	description = "9mm Rifle Shells";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo-assrifle";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData AssRifleImage
{
	shapeFile = "assaultrifle";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = AssRifleAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	
	sfxFire = SoundFireAssRifle;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData AssRifle
{
	description = "Assault Rifle";
	className = "Weapon";
	shapeFile = "assaultrifle";
	hudIcon = "assault";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = AssRifleImage;
	price = 175;
	showWeaponBar = true;
	
	
};

function AssRifleImage::onFire(%player, %slot) 
{
	%trans = LabRat::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rand = getRandom();
	if (%rand <= 0.2)
		%proj = Projectile::spawnProjectile("AssRifleBullet",%trans,%player,%vel);
	else
		%proj = Projectile::spawnProjectile("InvisAssRifleBullet",%trans,%player,%vel);

	//AssRifleShellEject(%proj);
	Player::decItemCount(%player, AssRifleAmmo, 1);

	//Desguise Pack Deactivate
	//%client = Player::getClient(%player);
	//if($DisguiseOrig[%client] != "")
	//	Player::trigger(%player,$BackpackSlot,false);
}

//------------------------------------------------------

ItemData ShotgunAmmo
{
	description = "Shotgun Shells";
	className = "Ammo";
	shapeFile = "ammo-shotgun";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;  // Single Shot
	ammoType = ShotgunAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 0.20;
	fireTime = 0.50;
	
	sfxFire = SoundShotgunFire;
	sfxReload = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Shotgun
{
	description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "shotgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	showWeaponBar = true;
	price = 125;
	showWeaponBar = true;
};

function ShotgunImage::onFire(%player, %slot) 
{
	Player::decItemCount(%player, ShotgunAmmo, 1);
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	
	for(%i=0; %i<12; %i++)
		%proj = Projectile::spawnProjectile("ShotGunBullet",%trans,%player,%vel);
	
	ShotgunShellEject(%proj);
	%rot = GameBase::getRotation(%proj);
	ApplyKickback(%player, %rot, 25);

	//Desguise Pack Deactivate
	//%client = Player::getClient(%player);
	//if($DisguiseOrig[%client] != "")
	//	Player::trigger(%player,$BackpackSlot,false);
}

function ApplyKickback(%player, %rot, %kick)
{
	%vel = item::getVelocity(%player);
	%x = getWord(%vel, 0);
	%y = getWord(%vel, 1);
	%z = getWord(%vel, 2);
	//echo(%vel);
	if( %x <= 30 && %y <= 30 && %z <= 30 )
	{
		%vec = Vector::getFromRot(%rot, %kick);
		%vec = Vector::neg(%vec);
		Player::applyImpulse(%player,%vec);
	}
}
//------------------------------------------------------

ItemImageData SilencedGlockImage
{
	shapeFile = "calico_s";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = GlockAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.05;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 0, 0, 0 };
	
	sfxFire = SoundFireSilencedGlock;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundGlockReload;
};

ItemData SilencedGlock
{
	description = "Silenced Handgun";
	className = "Weapon";
	shapeFile = "calico_s";
	hudIcon = "shandgun";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SilencedGlockImage;
	price = 175;
	showWeaponBar = true;
};

function SilencedGlockImage::onFire(%player, %slot) 
{
	%trans = LabRat::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rand = getRandom();
	if (%rand <= 0.2)
		%proj = Projectile::spawnProjectile("SilencedGlockBullet",%trans,%player,%vel);
	else
		%proj = Projectile::spawnProjectile("InvisSilencedGlockBullet",%trans,%player,%vel);

	//ShellEject(%proj);
	Player::decItemCount(%player, GlockAmmo, 1);

	//Desguise Pack Deactivate
	//%client = Player::getClient(%player);
	//if($DisguiseOrig[%client] != "")
	//	Player::trigger(%player,$BackpackSlot,false);
}

//-----------------------------------------------------------------------
ItemImageData SilencedAssRifleImage
{
	shapeFile = "assrifle_s";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = AssRifleAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 0, 0, 0 };
	
	sfxFire = SoundFireSilencedAssRifle;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData SilencedAssRifle
{
	description = "Silenced Ass. Rifle";
	className = "Weapon";
	shapeFile = "assrifle_s";
	hudIcon = "sassault";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SilencedAssRifleImage;
	price = 175;
	showWeaponBar = true;
};

function SilencedAssRifleImage::onFire(%player, %slot) 
{
	%trans = LabRat::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rand = getRandom();
	if (%rand <= 0.2)
		%proj = Projectile::spawnProjectile("SilencedAssRifleBullet",%trans,%player,%vel);
	else
		%proj = Projectile::spawnProjectile("InvisSilencedAssRifleBullet",%trans,%player,%vel);

	//AssRifleShellEject(%proj);
	Player::decItemCount(%player, AssRifleAmmo, 1);

	//Desguise Pack Deactivate
	//%client = Player::getClient(%player);
	//if($DisguiseOrig[%client] != "")
	//	Player::trigger(%player,$BackpackSlot,false);
}

//------------------------------------------------------
ItemData FlamerAmmo
{
	description = "Butane";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData FlamerImage
{
	shapeFile = "FlameThrower";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = FlamerAmmo;
	projectileType = FlamerBolt;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.0;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	
	sfxFire = SoundJetLight;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundJetLight;
};

ItemData FlamerGun
{
	description = "Flamethrower";
	className = "Weapon";
	shapeFile = "FlameThrower";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 400;
	showWeaponBar = true;
};

function FlamerGun::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == FuelPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have an Fuel Pack to use the Flamethrower.");
}

//-----------------------------------------------------------------------

ItemImageData MAWAssRifleImage
{
	shapeFile = "MAWAssRifle";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = AssRifleAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	
	sfxFire = SoundFireAssRifle;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MAWAssRifle
{
	description = "The MAW";
	className = "Weapon";
	shapeFile = "MAWAssRifle";
	hudIcon = "MAWa";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MAWAssRifleImage;
	price = 175;
	showWeaponBar = true;
};

function MAWAssRifleImage::onFire(%player, %slot) 
{
	%trans = LabRat::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rand = getRandom();
	if (%rand <= 0.2)
		%proj = Projectile::spawnProjectile("MAWAssRifleBullet",%trans,%player,%vel);
	else
		%proj = Projectile::spawnProjectile("InvisMAWAssRifleBullet",%trans,%player,%vel);

	//AssRifleShellEject(%proj);
	Player::decItemCount(%player, AssRifleAmmo, 1);
}

//----------------------------------------------------------------

ItemData MAWIncendiaryRifleAmmo
{
	description = "MAW Napalm Shells";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo-incen";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MAWIncendiaryRifleImage
{
	shapeFile = "MAWIncen";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = MAWIncendiaryRifleAmmo;
	projectileType = NoProjectile;
	accuFire = false;
	reloadTime = 2.0;
	fireTime = 0.5;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	
	sfxFire = SoundIncendFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundIncendReload;
};

ItemData MAWIncendiaryRifle
{
	description = "The MAW - Incendiary Rifle";
	className = "Weapon";
	shapeFile = "MAWIncen";
	hudIcon = "MAWi";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MAWIncendiaryRifleImage;
	price = 175;
	showWeaponBar = true;
	showInventory = false;
};

function MAWIncendiaryRifleImage::onFire(%player, %slot) 
{
	GameBase::getLOSInfo(%player, 9000);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%proj = Projectile::spawnProjectile("MAWIncendiaryRifleShell",%trans,%player,%vel);
	
	//Proj effects
	BigShellEject(%proj);
	$IncenClient[%proj] = GameBase::getOwnerClient(%player);
	schedule("MAWExplode("@%proj@");", 0.6, %proj);
	Player::decItemCount(%player, MAWIncendiaryRifleAmmo, 1);
}

//----------------------------------------------------------------------------

ItemData MAWGrenadeAmmo
{
	description = "Grenades";
	className = "Ammo";
	shapeFile = "ammo-gren";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MAWGrenadeLauncherImage
{
	shapeFile = "MAWGren";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = MAWGrenadeAmmo;
	projectileType = MAWGrenadeShell;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.1;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MAWGrenadeLauncher
{
	description = "MAW - Gren. Launcher";
	className = "Weapon";
	shapeFile = "MAWGren";
	hudIcon = "MAWg";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MAWGrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
	showInventory = false;
};
//-------------------------------------------------------------
//-------------------------------------------------------------

ItemImageData GrenadeLauncherImage
{
	shapeFile = "GrenLaunch";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = MAWGrenadeAmmo;
	projectileType = MAWGrenadeShell;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.1;
	
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
	shapeFile = "GrenLaunch";
	hudIcon = "grenade";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
	showInventory = true;
	
};



//-------------------------------------------------------------
//-------------------------------------------------------------
//Minigun

ItemData MinigunAmmo
{
	description = "Minigun Shells";
	className = "Ammo";
	shapeFile = "ammo-mini";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData MinigunImage
{
	shapeFile = "minigun";
	mountPoint = 0;
	
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 1.0;
	spinDownTime = 1.0;
	fireTime = 0.04;
	
	ammoType = MinigunAmmo;
	projectileType = NoProjectile;
	accuFire = false;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	
	sfxFire = SoundFireMinigun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUpMinigun;
	sfxSpinDown = SoundSpinDownMinigun;
};

ItemData Minigun
{
	description = "Minigun";
	className = "Weapon";
	shapeFile = "minigun";
	hudIcon = "minigun";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MinigunImage;
	price = 300;
	showWeaponBar = true;
};

function Minigun::onUse(%player,%item)
{
	//Checks for Minigun Ammo Pack
	if(Player::getMountedItem(%player,$BackpackSlot) == MinigunAmmoPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Minigun Ammo Pack to use the Minigun.");
}

function MinigunImage::onFire(%player, %slot) 
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rand = getRandom();
	if (%rand <= 0.1)
	{
		Projectile::spawnProjectile("MinigunClip",%trans,%player,%vel);
		Projectile::spawnProjectile("MinigunClip",%trans,%player,%vel);
	}
	else
	{
		Projectile::spawnProjectile("InvisMinigunClip",%trans,%player,%vel);
		Projectile::spawnProjectile("InvisMinigunClip",%trans,%player,%vel);
	}
	Player::decItemCount(%player, MinigunAmmo, 1);
}

//-----------------
// 7/2/99 - 1:30PM
//-----------------
//Sniper Rifle

ItemData SniperRifleAmmo
{
	description = "50cal. Rifle Shells";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo-sniper";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniperrifle";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = SniperRifleAmmo;
	projectileType = SniperRifleBullet;
	accuFire = true;
	reloadTime = 1.75;
	fireTime = 1.25;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	
	sfxFire = SoundFireSniperRifle;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundSniperReload;
};

ItemData SniperRifle
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniperrifle";
	hudIcon = "sniper";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 400;
	showWeaponBar = true;
};

//-----------------
// 5/31/99 - 2:30AM
//-----------------
//Rocket Launcher

ItemData RocketLauncherAmmo
{
	description = "Rockets";
	className = "Ammo";
	shapeFile = "ammo-launcher";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData RocketLauncherImage
{
	shapeFile = "rlauncher";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = RocketLauncherAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.5;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	
	sfxFire = NoSound;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData RocketLauncher
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "rlauncher";
	hudIcon = "rocket";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function RocketLauncherImage::onFire(%player, %slot) 
{
	%client = Player::getClient(%player);
	if ( $RocketReload[%player] == TRUE )
	{
		remoteEval(%client, BP, "<jc><f0>Reloading...", 1);
		RocketNoFireAnim(%player);
	}
	else
	{
		if ( !Player::isCrouching(%player)|| Player::getLastContactCount(%player) > 0 )
		{
			remoteEval(%client, BP, "<jc><f0>Must Be Crouched to Fire The Rocket Launcher", 3);
			RocketNoFireAnim(%player);
		}
		else
		{
			%trans = LabRat::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("StandardRocket",%trans,%player,%vel);
			Player::decItemCount(%player, RocketLauncherAmmo, 1);
			GameBase::playSound(%player , SoundFireFlierRocket, 0);
			$RocketReload[%player] = TRUE;
			schedule("$RocketReload["@%player@"] = FALSE;", 2.5);
			schedule("RocketNoFireAnim(" @%player@ ");", 0.05);
		}
	}
}

function RocketNoFireAnim(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,RocketLauncher,$WeaponSlot);
}

//-----------------
// 6/16/99 - 6:30PM
//-----------------
//FBW Rocket Launcher

ItemData FBWRocketAmmo
{
	description = "FBW Rockets";
	className = "Ammo";
	shapeFile = "ammo-fbw";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData FBWRocketLauncherImage
{
	shapeFile = "fbwlauncher";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = FBWRocketAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 1.5;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	
	sfxFire = NoSound;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData FBWRocketLauncher
{
	description = "FBW Rocket Launcher";
	className = "Weapon";
	shapeFile = "fbwlauncher";
	hudIcon = "FBW";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FBWRocketLauncherImage;
	price = 1000;
	showWeaponBar = true;
	showInventory = false;
};

function FBWRocketLauncherImage::onFire(%player, %slot) 
{
	%client = Player::getClient(%player);
	
	if ( $FBWRocketReload[%player] == TRUE )
	{
		remoteEval(%client, BP, "<jc><f0>Reloading...", 1);
		FBWRocketNoFireAnim(%player);
	}
	else
	{
		if ( !Player::isCrouching(%player) || Player::getLastContactCount(%player) > 0 )
		{
			remoteEval(%client, BP, "<jc><f0>Must Be Crouched to Fire FBW Rockets", 3);
			FBWRocketNoFireAnim(%player);
		}
		else
		{
			%item = "FBW";
			//echo("My Above Check ", CheckAboveMe(%player));
			if( CheckAboveMe(%player) == FALSE )
			{
				if( $TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item] )
				{
					%trans = LabRat::getMuzzleTransform(%player);
					%vel = Item::getVelocity(%player);
					$clientID = GameBase::getOwnerClient(%player);
					Projectile::spawnProjectile("InvisFBWRocket",%trans,%player,%vel);
					
					//Misc
					Player::decItemCount(%player, FBWRocketAmmo, 1);
					GameBase::playSound(%player , SoundFireFlierRocket, 0);
					$TeamItemCount[GameBase::getTeam(%client) @ %item]++;
					$FBWRocketReload[%player] = TRUE;
					schedule("$FBWRocketReload["@%player@"] = FALSE;", 2.5);
					schedule("FBWRocketNoFireAnim(" @%player@ ");", 0.05);
				}
				else
				{
					remoteEval(%client, BP, "<jc><f1>FREQUENCY OVERLOAD: <f0>To Many Rockets in Flight", 3);
					FBWRocketNoFireAnim(%player);
				}
			}
			else
			{
				remoteEval(%client, BP, "<jc><f1>LAUNCH ABORTED: <f0>Satellite Contact Blocked", 3);
				FBWRocketNoFireAnim(%player);
			}
		}
	}
}

function CheckAboveMe(%player)
{
	%rot = "1.570796 0 0";
	//Do LOS directly above player to see if building is found
	if(GameBase::getLOSInfo(%player,10000,%rot))
	{
		if( $los::object )
			return TRUE;
		else
			return FALSE;
	}
	else
		return FALSE;
}

function FBWRocketNoFireAnim(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,FBWRocketLauncher,$WeaponSlot);
}

//----------------------------------------------------------
//Homing Flaregun

ItemData HomingFlareAmmo
{
	description = "GRoC";
	className = "Ammo";
	shapeFile = "ammo-groc";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData HomingFlaregunImage
{
	shapeFile = "GRoCGun";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = HomingFlareAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	
	sfxFire = NoSound;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData HomingFlaregun
{
	description = "GRoC Gun";
	className = "Weapon";
	shapeFile = "GRoCGun";
	hudIcon = "GRoC";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HomingFlaregunImage;
	price = 150;
	showWeaponBar = true;
};

function HomingFlaregun::onUse(%player,%item)
{
	//Checks for Deck Pack
	if(Player::getMountedItem(%player,$BackpackSlot) == DeckPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Deck to use the GRoC Gun.");
}

function HomingFlaregunImage::onFire(%player, %slot)
{
	%set = newObject("set",SimSet);
	%number = containerBoxFillSet(%set, $VehicleObjectType, GameBase::getPosition(%player), 400, 400, 400, 0);
	%client = Player::getClient(%player);
	//echo("%number ",%number);
	
	if( $FlareReload[%player] != TRUE )
	{
		if( %number > 0 )
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			
			//The function to get the Missile from Set
			
			for( %i = 0; %i < %number; %i++ )
			{
				%object = Group::getObject(%set, %i);
				//echo("%object ",%object);
				%name = GameBase::getDataName(%object);
				//echo("%name ",%name);
				if( %name == "FBWRocket" )
				{
					echo("I'm tracking!");
					%target = %object;
					break;
				}
				else
					%target = 0;
			}
			//echo("%target ",%target);
			if( %target != 0 )
			{
				GameBase::playSound(%player , SoundFireFlierRocket, 0);
				Projectile::spawnProjectile("HomingFlare",%trans,%player,%vel,%target);
				Player::decItemCount(%player, HomingFlareAmmo, 1);
				remoteEval(%client , BP, "<jc><f0>Lock <f1> Aquired", 1);
				$FlareReload[%player] = TRUE;
				schedule("$FlareReload["@%player@"] = FALSE;", 1.0);
				schedule("HomingFlaregunNoFireAnim(" @%player@ ");", 0.06);
			}
			else
			{
				HomingFlaregunNoFireAnim(%player);
				remoteEval(%client , BP, "<jc><f0>Missile Lock:<f1> Not Aquired", 1);
			}
		}
		else
		{
			HomingFlaregunNoFireAnim(%player);
			remoteEval(%client , BP, "<jc><f0>Missile Lock:<f1> Not Aquired", 1);
		}
	}
	else
	{
		HomingFlaregunNoFireAnim(%player);
		remoteEval(%client , BP, "<jc><f0>Reloading...", 1);
	}
	deleteObject(%set);
	
}

function HomingFlaregunNoFireAnim(%player)
{
	Player::unmountItem(%player,$WeaponSlot);
	Player::mountItem(%player,HomingFlaregun,$WeaponSlot);
}

//------------------------------------------------------------------------------
ItemImageData ConsoleJackImage
{
	shapeFile = "consolejack";
	mountPoint = 0;
	
	weaponType = 2;  // Sustained
	projectileType = ConsoleJackBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime   = 1;
	lightColor  = { 0.0, 1.0, 1.0 };
	
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundConsoleJackFire;
};

ItemData ConsoleJack
{
	description = "Console Jack";
	shapeFile = "consolejack";
	className = "Weapon";
   	heading = "bWeapons";
	hudIcon = "console";
	shadowDetailMask = 4;
	imageType = ConsoleJackImage;
	showInventory = True;
	showWeaponBar = true;
	price = 125;
};

function ConsoleJack::onUse(%player,%item)
{
	//Checks for Deck Pack
	if(Player::getMountedItem(%player,$BackpackSlot) == DeckPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Deck to use the Console Jack.");
}

//------------------------------------------------------
// Detonator - 8/1/99
//------------------------------------------------------

ItemImageData DetonatorImage
{
	shapeFile = "detonator";
	mountPoint = 0;
	
	weaponType = 0;
   	minEnergy = 0;
   	maxEnergy = 0;
	projectileType = NoProjectile;
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 0.5;
	lightColor  = { 1.0, 0, 0};
	
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundDetpackActivate;
};

ItemData Detonator
{
	description = "Remote Detonator";
	shapeFile = "detonator";
	className = "Tool";
	shadowDetailMask = 4;
	hudIcon = "RMTDET";
   	heading = "bWeapons";
	imageType = DetonatorImage;
	showInventory = true;
	price = 125;
	showWeaponBar = true;
	reloadTime = 1.0;
	fireTime = 0.2;
};

function DetonatorImage::onFire(%player, %slot)
{
	%cl = Player::getClient(%player);
	remoteEval(%cl, BP, "<jc><f0>WARNING: <f1>Remotely Detonating Mines", 3);
	$RemDet[%cl] = TRUE;
	schedule("$RemDet["@%cl@"] = FALSE;",1.1);
}

//------------------------------------------------------------------------------

ItemImageData ReloaderImage
{
	shapeFile = "reloader";
	mountPoint = 0;
	
	weaponType = 2;  // Sustained
	projectileType = ReloadBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	
	lightType   = 3;  // Weapon Fire
	lightRadius = 0;
	lightTime   = 0;
	lightColor  = { 0.0, 0.0, 0.0 };
	
	sfxActivate = SoundPickUpWeapon;
	sfxFire = NoSound;
};

ItemData Reloader
{
	description = "Ammo Reloader";
	shapeFile = "reloader";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = ReloaderImage;
	showInventory = false;
	price = 125;
};

function Reloader::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function Reloader::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//--------------------------------------------------------------------------

ItemData OspreyTurretAmmo
{
	description = "Turret Shells";
	className = "Ammo";
	shapeFile = "ammo-osprey";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData OspreyTurretImage
{
	shapeFile = "osprey-turret";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	ammoType = OspreyTurretAmmo;
	projectileType = NoProjectile;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.05;
	
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	
	sfxFire = SoundFireAssRifle;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData OspreyTurret
{
	description = "Osprey Turret";
	className = "Weapon";
	shapeFile = "osprey-turret";
	hudIcon = "chain";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = OspreyTurretImage;
	price = 175;
	showWeaponBar = true;
};

function OspreyTurretImage::onFire(%player, %slot) 
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%rand = getRandom();
	if (%rand <= 0.2)
		Projectile::spawnProjectile("OspreyTurretBullet",%trans,%player,%vel);
	else
		Projectile::spawnProjectile("InvisOspreyTurretBullet",%trans,%player,%vel);
	Player::decItemCount(%player, OspreyTurretAmmo, 1);
}

//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//------------------------------------------------------------------------------

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

//*************************************************************************************************************
// SF Addition - Begin - 8/3/99 - 12:00PM
//*************************************************************************************************************

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
	
	mass = 2.5;
	
	elasticity = 0.2;
	price = 325;
	hudIcon = "AMMO";
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
				%item.GlockAmmo = %numPack;
			}
			else if(%i == 1) {
				%item.AssRifleAmmo = %numPack;
			}
			else if(%i == 2) {
				%item.ShotgunAmmo = %numPack;
			}
			else if(%i == 3) {
				%item.SniperRifleAmmo = %numPack;
			}
			else if(%i == 4) {
			}
			else if(%i == 5) {
				%item.MAWIncendiaryRifleAmmo = %numPack;
			}
			else if(%i == 6) {
				%item.MAWGrenadeAmmo = %numPack;
			}
			else if(%i == 7) {
				%item.RocketLauncherAmmo = %numPack;
			}
			else if(%i == 8) {
				%item.FBWRocketAmmo = %numPack;
			}
			else if(%i == 9) {
				%item.MinigunAmmo = %numPack;
			}
			else if(%i == 10) {
				%item.Grenade = %numPack;
			}
			else if(%i == 11) {
				%item.MineAmmo = %numPack;
			}
			else if(%i == 12) {
				%item.RemMineAmmo = %numPack;
			}
			else if(%i == 13) {
				%item.FlashGrenade = %numPack;
			}
			else {
				%item.Beacon = %numPack;
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
			%numAdd = %item.GlockAmmo;
		}
		else if(%i == 1) {
			%numAdd = %item.AssRifleAmmo;
		}
		else if(%i == 2) {
			%numAdd = %item.ShotgunAmmo;
		}
		else if(%i == 3) {
			%numAdd = %item.SniperRifleAmmo;
		}
		else if(%i == 4) {
		}
		else if(%i == 5) {
			%numAdd = %item.MAWIncendiaryRifleAmmo;
		}
		else if(%i == 6) {
			%numAdd = %item.MAWGrenadeAmmo;
		}
		else if(%i == 7) {
			%numAdd = %item.RocketLauncherAmmo;
		}
		else if(%i == 8) {
			%numAdd = %item.FBWRocketAmmo;
		}
		else if(%i == 9) {
			%numAdd = %item.MinigunAmmo;
		}
		else if(%i == 10) {
			%numAdd = %item.Grenade;
		}
		else if(%i == 11) {
			%numAdd = %item.MineAmmo;
		}
		else if(%i == 12) {
			%numAdd = %item.RemMineAmmo;
		}
		else if(%i == 13) {
			%numAdd = %item.FlashGrenade;
		}
		else {
			%numAdd = %item.Beacon;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	//Be sure to increase Max %i when adding a new weapon
	for(%i = 0; %i < 13 ; %i = %i +1)
	{
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

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
	hudIcon = "deployINV";
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
	hudIcon = "deployAMO";
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

//*************************************************************************
// SF Addition - 8/7/99 - 5:30PM
//*************************************************************************
// Medic Station

//----------------------------------------------------------------------------

ItemImageData DeployableMedicPackImage
{
	shapeFile = "medicunit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DeployableMedicPack
{
	description = "Medic Station";
	shapeFile = "medicunit_remote";
	className = "Backpack";
	heading = "dDeployables";
	shadowDetailMask = 4;
	imageType = DeployableMedicPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployREP";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableMedicPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableMedicPack::onDeploy(%player,%item,%pos)
{
	if (DeployableMedicPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}	

function DeployableMedicPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%inv = newObject("ammounit_remote","StaticShape","MedicStation",true);
						addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Medic Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableMedicPack"]++;
						echo("MSG: ",%client," deployed a Medic Station");
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

// Fuel Pack
ItemImageData FuelPackImage
{
	shapeFile = "fuelPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData FuelPack
{
	description = "Fuel Pack";
	shapeFile = "fuelPack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = FuelPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FuelPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		%i = 0;
		%numPack = 0;
		%ammoItem = $FuelPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) {
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
		}	
		%item.FlamerAmmo = %numPack;		
	}
}

function FuelPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
			Item::playPickupSound(%this);
			checkPacksFuel(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksFuel(%player, %item)
{
	%i = 0;
	%ammoItem = $FuelPackItems[%i];
	%numAdd = %item.FlamerAmmo;
	Player::incItemCount(%player,%ammoItem,%numAdd);
}

function fillFuelPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%i = 0;
	%item = $FuelPackItems[%i];
	%maxnum = $FuelPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) {
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
	}
}

//-----------------------------------------
// Minigun Ammo Pack

ItemImageData MinigunAmmoPackImage
{
	shapeFile = "gatamoback";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MinigunAmmoPack
{
	description = "Minigun Ammo Pack";
	shapeFile = "gatamoback";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = MinigunAmmoPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MinigunAmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		%i = 0;
		%numPack = 0;
		%ammoItem = $MinigunAmmoPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) {
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
		}	
		%item.MinigunAmmo = %numPack;		
	}
}

function MinigunAmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkMinigunPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkMinigunPacksAmmo(%player, %item)
{
	%i = 0;
	%ammoItem = $MinigunAmmoPackItems[%i];
	%numAdd = %item.MinigunAmmo;
	Player::incItemCount(%player,%ammoItem,%numAdd);						 
}


function fillMinigunAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%i = 0;
	%item = $MinigunAmmoPackItems[%i];
	%maxnum = $MinigunAmmoPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) {
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
	}
}

//----------------------------------------------------------------------------
//ItemImageData DisguisePackImage
//{
//	shapeFile = "disguisepack";
//	mountPoint = 2;
//	weaponType = 2;  // Sustained
//	maxEnergy = 8;  // Energy used/sec for sustained weapons
//	sfxFire = SoundDisguiseOn;
//	mountOffset = { 0, -0.05, 0 };
//	mountRotation = { 0, 0, 0 };
//	firstPerson = false;
//};

//ItemData DisguisePack
//{
//	description = "Disguise Pack";
//	shapeFile = "disguisepack";
//	className = "Backpack";
//	heading = "cBackpacks";
//	shadowDetailMask = 4;
//	imageType = DisguisePackImage;
//	price = 200;
//	hudIcon = "sensorjamerpack";
//	showWeaponBar = true;
//	hiliteOnActive = true;
//};

//function DisguisePackImage::onActivate(%player,%imageSlot)
//{
//	%client = Player::getClient(%player);
	
//	if( $DisguiseSkin[%client] == "" )
//		$DisguiseSkin[%client] = "feign";
	
//	if( $DisguiseSkin[%client] == "feign" )
//	{
//		%anim = $PlayerAnim::DieForward;
//		Player::setAnimation(%client, %anim);
//		schedule("Player::trigger("@%player@","@$BackpackSlot@",false);", 0.2, %player);
//	}
//	else
//	{
//		$DisguiseOrig[%client] = GameBase::getTeam(%client);
//		GameBase::setTeam(%client, $DisguiseSkin[%client]);
//	}
//	remoteEval(%client, BP, "<jc><f0>Donning Disguise...", 2);
//}

//function DisguisePackImage::onDeactivate(%player,%imageSlot)
//{
//	%client = Player::getClient(%player);
//	remoteEval(%client, BP, "<jc><f0>Removing Disguise...", 2);
//	playSound(SoundDisguiseOff, GameBase::getPosition(%client));
//	if( $DisguiseOrig[%client] != "" )
//	{
		//Change teams back and reset the value
//		GameBase::setTeam(%client, $DisguiseOrig[%client]);
//		$DisguiseOrig[%client] = "";
//	}
//	Player::trigger(%player,$BackpackSlot,false);
//}

//----------------------------------------------------------------------------
ItemImageData DeckPackImage
{
	shapeFile = "sfcomputbck";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 1;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundDeckOn;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DeckPack
{
	description = "Deck";
	shapeFile = "sfcomputbck";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = DeckPackImage;
	price = 200;
	hudIcon = "deck";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeckPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Deck Activated");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function DeckPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Deck Deactivated");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

function DeckPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == ConsoleJack) 
		Player::unmountItem(%player,$WeaponSlot);
	else if (Player::getMountedItem(%player,$WeaponSlot) == HomingFlaregun) 
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
	hudIcon = "repair";
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

ItemImageData ReloaderPackImage
{
	shapeFile = "reloaderpack";
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
	description = "Ammo Loader";
	shapeFile = "reloaderpack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ReloaderPackImage;
	price = 125;
	hudIcon = "reloader";
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
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

//----------------------------------------------------------------------------

ItemImageData BugPackImage
{
	shapeFile = "bugcamerapack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData BugPack
{
	description = "Bug Pack";
	shapeFile = "bugcamerapack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = BugPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployBUG";
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

function BugPack::onDeploy(%player,%item, %pos)
{
	%client = Player::getClient(%player);
	%item = "CameraPack";
	
	if( $TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item] )
	{
		if( CheckAboveMe(%player) == FALSE )
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			$FlyClientID = %client;
			Projectile::spawnProjectile("InvisFlyingBug",%trans,%player,%vel);
			
			Client::sendMessage(%client,0,"Fly Launched");
			Player::trigger(%player,$BackpackSlot,false);
			
			%item = "BugPack";
			Player::decItemCount(%player,%item);
		}
		else
		{
			remoteEval(%client, BP, "<jc><f1>DEPLOY ABORTED: <f0>Satellite Contact Blocked", 3);
		}
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
}

function BugPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == BugPackLauncher) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function BugPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == BugPackLauncher) {
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

function BugPackImage::onActivate(%player,%imageSlot)
{
	%client = Player::getClient(%player);
	%item = "CameraPack";
	
	if( $TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item] )
	{
		if( CheckAboveMe(%player) == FALSE )
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			$FlyClientID = %client;
			Projectile::spawnProjectile("InvisFlyingBug",%trans,%player,%vel);
			
			Client::sendMessage(%client,0,"Fly Launched");
			Player::trigger(%player,$BackpackSlot,false);
			
			%item = "BugPack";
			Player::decItemCount(%player,%item);
		}
		else
		{
			remoteEval(%client, BP, "<jc><f1>DEPLOY ABORTED: <f0>Satellite Contact Blocked", 3);
		}
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
}

//----------------------------------------------------------------------------

//*****************************************************************
// SF Addition END
//*****************************************************************

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
	hudIcon = "deployBUG";
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
	shapeFile = "sentrybackpack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData TurretPack
{
	description = "Turret";
	shapeFile = "sentrybackpack";
	className = "Backpack";
	heading = "dDeployables";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployTUR";
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

//----------------------------------------------------------------------------

ItemImageData GRoCCannonPackImage
{
	shapeFile = "flakpack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData GRoCCannonPack
{
	description = "GRoC Cannon";
	shapeFile = "flakpack";
	className = "Backpack";
	heading = "dDeployables";
	imageType = GRoCCannonPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployTUR";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GRoCCannonPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function GRoCCannonPack::onDeploy(%player,%item,%pos)
{
	if (GRoCCannonPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function GRoCCannonPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"GRoCTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
					%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"GRoCTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("GRoCCannon","Turret",GRoCTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"GRoC Cannon#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"GRoC Cannon deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "GRoCCannon"]++;
								echo("MSG: ",%client," deployed a GRoC Cannon");
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

//*************************************************************************************************************
// SF Addition - Begin - 8/1/99 - 11:00PM
//*************************************************************************************************************

ItemData RemMineAmmo
{
	description = "Remote Mine";
	shapeFile = "mineammo";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function RemMineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			
			%obj = newObject("","Mine","RemoteMine");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			
			$MineClient[%obj] = %client;
			%team = GameBase::getTeam(%client);
			GameBase::setTeam(%obj, %team);
			
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			
			$TeamItemCount[GameBase::getTeam(%player) @ "RemMineAmmo"]++;
		}
	}
}

ItemData FlashGrenade
{
	description = "Concussion Grenade";
	shapeFile = "concus-grenade";
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
			%obj = newObject("","Mine","ConcGrenade");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//----------------------------------------------------------------------------

ItemData MineAmmo
{
	description = "Proximity Mine";
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
			
			%team = GameBase::getTeam(%client );
			GameBase::setTeam(%obj, %team);
			
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			
			$TeamItemCount[GameBase::getTeam(%player) @ "MineAmmo"]++;
		}
	}
}


//----------------------------------------------------------------------------

ItemData Grenade
{
	description = "Grenade";
	shapeFile = "hand-grenade";
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

//*************************************************************************************************************
// SF Addition - Begin - 7/12/99 - 10:00PM
//*************************************************************************************************************
ItemData Detpack
{
	description = "Detpack";
	shapeFile = "detpack";
	heading = "eMiscellany";
	shadowDetailMask = 4;
	price = 200;
	className = "HandAmmo";
};

function Detpack::onUse(%player,%item)
{
	if(Detpack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function Detpack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "StaticShape") {
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
			%num=containerBoxFillSet(%set, $ItemObjectType | $SimPlayerObjectType,$los::position,0.5,0.5,0.5,1);
			deleteObject(%set);
			if(!%num) {
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
					%detpack = newObject("", "StaticShape", defaultDetpack, true);
					addToSet("MissionCleanup", %detpack);
					GameBase::setTeam(%detpack,GameBase::getTeam(%player));
					GameBase::setRotation(%detpack,%rot);
					GameBase::setPosition(%detpack,$los::position);
					Gamebase::setMapName(%detpack,"Active Detpack");
					Client::sendMessage(%client,0,"Detpack deployed");
					playSound(SoundDetpackDeploy,$los::position);
					$DetpackTeam[%detpack] = GameBase::getTeam(%detpack);
					$TeamItemCount[ $DetpackTeam[%detpack] @ "Detpack"]++;
					//*************************************************************************************************************
					// SF Addition - Menu Spawn
					//*************************************************************************************************************
					%cl = Player::getClient(%player);
					$DetpackCenter[%detpack] = getBoxCenter(%detpack);
					%team = GameBase::getTeam(%detpack);
					$playerID[%detpack] = %cl;
					$status[%detpack] = "explode";
					echo("Det Pack Team ", %team);
					DetpackDeployed(%detpack,%cl, $DetTimer[%cl]);
					//echo("%detpack ",%detpack);
					//echo("%player ",%player);
					//*************************************************************************************************************
					// SF Addition - Menu Spawn End
					//*************************************************************************************************************
					
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else {
			Client::sendMessage(%client,0,"Can't deploy on moving objects.");
		}
	}
	else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}

function DetpackDeployed(%detpack, %cl, %timer)
{
	if(%timer == "")
		%timer = 10;
	CheckTime(%timer, %detpack, %cl);
}

function CheckTime(%time, %detpack, %cl)
{
	%pos = GameBase::getPosition(%detpack);
	GameBase::playSequence(%detpack,1,deploy);
	%sound = playSound(SoundDetpackCharge,%pos);
	DetpackTimer(%time,%detpack,%cl);
}

function DetpackTimer(%time, %detpack, %cl)
{
	remoteEval(%cl, BP, "<jc><f0>Detonation in T-minus <f1>"@%time@" <f0>Seconds", 1);
	decTimer(%time, %detpack, %cl);
}

function decTimer(%time, %detpack, %cl)
{
	if(%time < 11 && %time > 1)
	{
		//echo("%time ",%time);
		remoteEval(%cl, BP, "<jc><f0>Detonation in T-minus <f1>"@%time@" <f0>Seconds", 1);
	}
	if(%time == 1)
	{
		remoteEval(%cl, BP, "<jc><f0>Detonation in T-minus <f1>"@%time@" <f0>Seconds", 1);
		%pos = GameBase::getPosition(%detpack);
		%sound = playSound(SoundDetpackActivate,%pos);
	}
	if(%time == 0)
	{
		if( GameBase::getTeam(%cl) != GameBase::getTeam(%detpack) )
		{
			$status[%detpack] = "disarmed";
			echo("Client and Detpack not same team");
			deleteObject(%detpack);
			return;
		}
		else
		{
			remoteEval(%cl, BP, "<jc><f0>Detonation <f1>Successful", 3);
			//Explode the Detpack
			GameBase::setDamageLevel(%detpack, 2.0);
		}
	}
	else
	{
		%time--;
		schedule("decTimer("@%time@", "@%detpack@", "@%cl@");", 1, %detpack);
	}
}

//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

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
	}
	else if($ServerCheats) {
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

//*************************************************************************************************************
// SF Addition - Begin - 8/3/99 - 11:30PM
//*************************************************************************************************************
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
	$TeamItemCount[0 @ OspreyVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ MineAmmo] = 0;
	$TeamItemCount[0 @ casing] = 0;
	$TeamItemCount[0 @ Detpack] = 0;
	$TeamItemCount[0 @ RemMineAmmo] = 0;
	$TeamItemCount[0 @ DeployableMedicPack] = 0;
	$TeamItemCount[0 @ FBW] = 0;
	$TeamItemCount[0 @ GRoCCannonPack] = 0;
	
	$TeamItemCount[1 @ DeployableAmmoPack] = 0;
	$TeamItemCount[1 @ DeployableInvPack] = 0;
	$TeamItemCount[1 @ TurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[1 @ PulseSensorPack] = 0;
	$TeamItemCount[1 @ MotionSensorPack] = 0;
	$TeamItemCount[1 @ ScoutVehicle] = 0;
	$TeamItemCount[1 @ OspreyVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ MineAmmo] = 0;
	$TeamItemCount[1 @ casing] = 0;
	$TeamItemCount[1 @ Detpack] = 0;
	$TeamItemCount[1 @ RemMineAmmo] = 0;
	$TeamItemCount[1 @ DeployableMedicPack] = 0;
	$TeamItemCount[1 @ FBW] = 0;
	$TeamItemCount[1 @ GRoCCannonPack] = 0;
	
	$TeamItemCount[2 @ DeployableAmmoPack] = 0;
	$TeamItemCount[2 @ DeployableInvPack] = 0;
	$TeamItemCount[2 @ TurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
	$TeamItemCount[2 @ PulseSensorPack] = 0;
	$TeamItemCount[2 @ MotionSensorPack] = 0;
	$TeamItemCount[2 @ ScoutVehicle] = 0;
	$TeamItemCount[2 @ OspreyVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ MineAmmo] = 0;
	$TeamItemCount[2 @ casing] = 0;
	$TeamItemCount[2 @ Detpack] = 0;
	$TeamItemCount[2 @ RemMineAmmo] = 0;
	$TeamItemCount[2 @ DeployableMedicPack] = 0;
	$TeamItemCount[2 @ FBW] = 0;
	$TeamItemCount[2 @ GRoCCannonPack] = 0;
	
	$TeamItemCount[3 @ DeployableAmmoPack] = 0;
	$TeamItemCount[3 @ DeployableInvPack] = 0;
	$TeamItemCount[3 @ TurretPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[3 @ PulseSensorPack] = 0;
	$TeamItemCount[3 @ MotionSensorPack] = 0;
	$TeamItemCount[3 @ ScoutVehicle] = 0;
	$TeamItemCount[3 @ OspreyVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ MineAmmo] = 0;
	$TeamItemCount[3 @ casing] = 0;
	$TeamItemCount[3 @ Detpack] = 0;
	$TeamItemCount[3 @ RemMineAmmo] = 0;
	$TeamItemCount[3 @ DeployableMedicPack] = 0;
	$TeamItemCount[3 @ FBW] = 0;
	$TeamItemCount[3 @ GRoCCannonPack] = 0;
	
	$TeamItemCount[4 @ DeployableAmmoPack] = 0;
	$TeamItemCount[4 @ DeployableInvPack] = 0;
	$TeamItemCount[4 @ TurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[4 @ PulseSensorPack] = 0;
	$TeamItemCount[4 @ MotionSensorPack] = 0;
	$TeamItemCount[4 @ ScoutVehicle] = 0;
	$TeamItemCount[4 @ OspreyVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ MineAmmo] = 0;
	$TeamItemCount[4 @ casing] = 0;
	$TeamItemCount[4 @ Detpack] = 0;
	$TeamItemCount[4 @ RemMineAmmo] = 0;
	$TeamItemCount[4 @ DeployableMedicPack] = 0;
	$TeamItemCount[4 @ FBW] = 0;
	$TeamItemCount[4 @ GRoCCannonPack] = 0;
	
	$TeamItemCount[5 @ DeployableAmmoPack] = 0;
	$TeamItemCount[5 @ DeployableInvPack] = 0;
	$TeamItemCount[5 @ TurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[5 @ PulseSensorPack] = 0;
	$TeamItemCount[5 @ MotionSensorPack] = 0;
	$TeamItemCount[5 @ ScoutVehicle] = 0;
	$TeamItemCount[5 @ OspreyVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ MineAmmo] = 0;
	$TeamItemCount[5 @ casing] = 0;
	$TeamItemCount[5 @ Detpack] = 0;
	$TeamItemCount[5 @ RemMineAmmo] = 0;
	$TeamItemCount[5 @ DeployableMedicPack] = 0;
	$TeamItemCount[5 @ FBW] = 0;
	$TeamItemCount[5 @ GRoCCannonPack] = 0;
	
	$TeamItemCount[6 @ DeployableAmmoPack] = 0;
	$TeamItemCount[6 @ DeployableInvPack] = 0;
	$TeamItemCount[6 @ TurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[6 @ PulseSensorPack] = 0;
	$TeamItemCount[6 @ MotionSensorPack] = 0;
	$TeamItemCount[6 @ ScoutVehicle] = 0;
	$TeamItemCount[6 @ OspreyVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ MineAmmo] = 0;
	$TeamItemCount[6 @ casing] = 0;
	$TeamItemCount[6 @ Detpack] = 0;
	$TeamItemCount[6 @ RemMineAmmo] = 0;
	$TeamItemCount[6 @ DeployableMedicPack] = 0;
	$TeamItemCount[6 @ FBW] = 0;
	$TeamItemCount[6 @ GRoCCannonPack] = 0;
	
	$TeamItemCount[7 @ DeployableAmmoPack] = 0;
	$TeamItemCount[7 @ DeployableInvPack] = 0;
	$TeamItemCount[7 @ TurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ OspreyVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ MineAmmo] = 0;
	$TeamItemCount[7 @ casing] = 0;
	$TeamItemCount[7 @ Detpack] = 0;
	$TeamItemCount[7 @ RemMineAmmo] = 0;
	$TeamItemCount[7 @ DeployableMedicPack] = 0;
	$TeamItemCount[7 @ FBW] = 0;
	$TeamItemCount[7 @ GRoCCannonPack] = 0;
	
	$totalNumCameras = 0;
	$totalNumTurrets = 0;
	$totalNumDetpacks = 0;
	
	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy;
}
