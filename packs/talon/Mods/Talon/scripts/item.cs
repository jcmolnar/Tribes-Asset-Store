

$ItemFavoritesKey = "Talon3";  	// Change this if you add new items
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
$ExtraWeaponSlotA=3;
$ExtraWeaponSlotB=4;
$ExtraWeaponSlotC=5;
$ExtraWeaponSlotD=6;
$ArmorDetailSlot=7;
$SpecializeSlot=7;

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
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 20;
$AmmoPackMax[GrenadeAmmo] = 45;
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
$TeamItemMax[ScoutVehicle] = 6;
$TeamItemMax[HAPCVehicle] = 2;
$TeamItemMax[LAPCVehicle] = 3;
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

// New Listings for -=TalonRules=-
// Armor:
$ArmorType[Male, TrooperArmor] = tarmor;
$ArmorType[Female, TrooperArmor] = tarmor;
$ArmorType[Male, FighterArmor] = fgarmor;
$ArmorType[Female, FighterArmor] = fgfemale;
$ArmorType[Male, ScoutArmor] = sctarmor;
$ArmorType[Female, ScoutArmor] = sctfemale;
$ArmorType[Male, KamikazeArmor] = karmor;
$ArmorType[Female, KamikazeArmor] = karmor;

$ArmorName[tarmor] = TrooperArmor;
$ArmorName[fgarmor] = FighterArmor;
$ArmorName[fgfemale] = FighterArmor;
$ArmorName[sctarmor] = ScoutArmor;
$ArmorName[sctfemale] = ScoutArmor;
$ArmorName[karmor] = KamikazeArmor;

$ArmorNumToName[sctarmor] = 1;
$ArmorNumToName[sctfemale] = 1;
$ArmorNumToName[larmor] = 2;
$ArmorNumToName[lfemale] = 2;
$ArmorNumToName[fgarmor] = 3;
$ArmorNumToName[fgfemale] = 3;
$ArmorNumToName[marmor] = 4;
$ArmorNumToName[mfemale] = 4;
$ArmorNumToName[harmor] = 5;
$ArmorNumToName[tarmor] = 6;

$ArmorNameToNum[1] = sctarmor;
$ArmorNameToNum[1] = sctfemale;
$ArmorNameToNum[2] = larmor;
$ArmorNameToNum[2] = lfemale;
$ArmorNameToNum[3] = fgarmor;
$ArmorNameToNum[3] = fgfemale;
$ArmorNameToNum[4] = marmor;
$ArmorNameToNum[4] = mfemale;
$ArmorNameToNum[5] = harmor;
$ArmorNameToNum[6] = tarmor;

//Vehicles:

//Ammo stuff:

$SellAmmo[AssaultAmmo] = 10;
$SellAmmo[SniperAmmo] = 5;
$SellAmmo[RPGAmmo] = 5;
$SellAmmo[NMLAmmo] = 1;
$SellAmmo[SMLAmmo] = 5;
$SellAmmo[GasAmmo] = 1;
$SellAmmo[SwarmerAmmo] = 1;
$SellAmmo[ReasonAmmo] = 50;
$SellAmmo[BlastAmmo] = 4;
$SellAmmo[SMAmmo] = 2;
$SellAmmo[MineGrenadeAmmo] = 5;
$SellAmmo[BoreAmmo] = 1;
$AmmoPackMax[SuperGaussAmmo] = 2;

$AmmoPackMax[AssaultAmmo] = 40;
$AmmoPackMax[SniperAmmo] = 15;
$AmmoPackMax[RPGAmmo] = 8;
$AmmoPackMax[NMLAmmo] = 1;
$AmmoPackMax[SMLAmmo] = 5;
$AmmoPackMax[GasAmmo] = 5;
$AmmoPackMax[SwarmerAmmo] = 4;
$AmmoPackMax[ReasonAmmo] = 100;
$AmmoPackMax[BlastAmmo] = 8;
$AmmoPackMax[SMAmmo] = 15;
$AmmoPackMax[MineGrenadeAmmo] = 20;
$AmmoPackMax[BoreAmmo] = 1;
$AmmoPackMax[SuperGaussAmmo] = 4;

$AmmoPackItems[8] = AssaultAmmo;
$AmmoPackItems[9] = SniperAmmo;
$AmmoPackItems[10] = RPGAmmo;
$AmmoPackItems[11] = NMLAmmo;
$AmmoPackItems[12] = SMLAmmo;
$AmmoPackItems[14] = MineGrenadeAmmo;
$AmmoPackItems[15] = GasAmmo;
$AmmoPackItems[16] = SwarmerAmmo;
$AmmoPackItems[17] = SMAmmo;
$AmmoPackItems[18] = ReasonAmmo;
$AmmoPackItems[19] = BlastAmmo;
$AmmoPackItems[20] = BoreAmmo;
$AmmoPackItems[21] = SuperGaussAmmo;

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
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation)
	{
		%station.Energy += %cost;			//Remote StationEnergy
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite")
	{
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
	if(%station != "" )
	{
		%stationName = GameBase::getDataName(%station); 
		if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation)
			%energy = %station.Energy;
		else
			%energy = $TeamEnergy[Client::getTeam(%client)];
		if(%energy == "Infinite" || %energy > 0)
		{
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%item = getItemData(%i);
				if ($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats)
				{
					%count = Player::getItemCount(%client,%item);
					if(%count)
					{
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}

			%numsi = 0;
			%numsig = 0;
			%nsib = 0;
			%nsigb = 0;

			for (%i = 0; %i < 20; %i++)
			{
				if(%favItem[%i] != "")
				{
					%item = getItemData(%favItem[%i]);
					if((Client::isItemShoppingOn(%client,%item) && $ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item)) || %item.className == Armor)
					{
						if(!buyItem(%client,%item))
							%error = 1;
						else
							%bought++;
					}
					if(%item.className == SpecialIcon)
					{
						$FavSpecialIcon[%client,%numsi] = %item;
						%numsi++;
					}
					if(%item.className == SpecialIconG)
					{
						$FavSpecialIconGrenade[%client,%numsig] = %item;
						%numsig++;
					}
				}
		  	}
			if(%numsi)
			{
				%maxsi = $ItemMax[Player::getArmor(%client),  Beacon];
				if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
					%maxsi += $AmmoPackMax[Beacon];
				echo(%maxsi);
				%maxoet = %maxsi / %numsi;
				echo(%maxoet);
				for (%i = 0; %i < %numsi; %i++)
				{
					for (%j = 1; %j < %maxoet; %j++)
					{
						%nsib++;
						buyItem(%client,$FavSpecialIcon[%client,%i]);
					}
				}
				%sidiff = %maxsi - %nsib;
				if(%sidiff == 1)
					buyItem(%client,$FavSpecialIcon[%client,0]);
			}
			if(%numsig)
			{
				%maxsig= $ItemMax[Player::getArmor(%client),  Grenade];
				if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
					%maxsig += $AmmoPackMax[Grenade];
				%maxoet = %maxsig / %numsig;
				for (%i = 0; %i < %numsig; %i++)
				{
					for (%j = 1; %j < %maxoet; %j++)
					{
						%nsigb++;
						buyItem(%client,$FavSpecialIconGrenade[%client,%i]);
					}
				}
				%sigdiff = %maxsig - %nsigb;
				if(%sigdiff == 1)
					buyItem(%client,$FavSpecialIconGrenade[%client,0]);
			}

			if(%bought)
			{
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
			if (%item.price * %delta > %energy)	
				%delta = %energy / %item.price; 
			if(%delta < 1 )
			{
				if(%noMessage == "")
					Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
				return 0;
			}
		}
	}
	if(%item.className == Weapon)
	{
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Weapon");
		if(%item == NML || %item == Pheonix)
			%ciw = true;
		
		if(%item == Reason)
			%eslots = 1;
		else
			%eslots = 0;
		if(%ciw == true && %wcount > 0)
		{
			Client::sendMessage(%client,0,"You cannot carry ANY weapons along with an apocalyptic weapon - Sell all of your weapons and repurhcase.~waccess_denied.wav");
			return 0;
		}
		if(%wcount >= $MaxWeapons[%armor] - %eslots)
		{
			if(%item == Reason)
				Client::sendMessage(%client,0,"Reason requires 2 weapon slots to carry.");
			else
				Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}
	else if(%item == RepairPatch)
	{
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) 
			return 1;
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
		%count = Player::getItemCount(%client,%item);
		%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
		if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	if(%item.className == SpecialIcon || %item.className == SpecialIconG)
		return 1;
	return %delta;
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);

		if(%item.className == SpecialIcon || %item.className == SpecialIconG)
		{
			echo("runnin check on special icon");
			%an = $ArmorName[%armor];
			if(%item.className == SpecialIconG)
			{
				%max = $ItemMax[%armor, Grenade];
				if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
					%max += $AmmoPackMax[Grenade];

				if($UsableGrenade[%an,%item] == 1)
				{
					echo(Player::getTotalGrenades(%client) @" -||- "@ %max);
					if(Player::getTotalGrenades(%client) < %max)
					{
						Player::incItemCount(%client,%item,1);
						Player::useItem(%client,%item);
						return 1;
					}
					else Client::sendMessage(%client,0,"Your armor can only carry "@ %max @" Grenades");
				}
				else Client::sendMessage(%client,0,"Your armor is not equipped to use those.");
			}
			else if(%item.className == SpecialIcon)
			{
				%max = $ItemMax[%armor,Beacon];
				if(Player::getMountedItem(%client,$BackpackSlot) == ammopack)
					%max += $AmmoPackMax[Beacon];

				if($UsableBeacon[%an,%item] == 1)
				{
					echo(Player::getTotalBeacons(%client) @" -||- "@ %max);
					if(Player::getTotalBeacons(%client) < %max)
					{
						Player::incItemCount(%client,%item,1);
						Player::useItem(%client,%item);
						return 1;
					}
					else Client::sendMessage(%client,0,"Your armor can only carry "@ %max @" Beacons");
				}
				else Client::sendMessage(%client,0,"Your armor is not equipped to use those.");
			}
		}

	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats))
	{
		if (%item.className == Armor)
		{
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
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack)
		{
			if($TeamItemMax[%item] != "")
			{
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			}
			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1)
			{
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack)
				{
					if(Player::getItemCount(%client,"LaserRifle") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						%gun = "LaserRifle";
						teamEnergyBuySell(%player,%gun.price);
						Player::decItemCount(%client,%gun);
					}
				}
				else if(%pack == NMLPack)
				{
					if(Player::getItemCount(%client,"NML") > 0)
					{
						Client::sendMessage(%client,0,"Sold Heavy Weapons Support - Auto Selling NML");
						%gun = "NML";
						teamEnergyBuySell(%player,%gun.price);
						Player::decItemCount(%client,%gun);
					}
					if(Player::getItemCount(%client,"Pheonix") > 0)
					{
						Client::sendMessage(%client,0,"Sold Heavy Weapons Support - Auto Selling Pheonix");
						%gun = "Pheonix";
						teamEnergyBuySell(%player,%gun.price);
						Player::decItemCount(%client,%gun);
					}
				}
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats)
			{
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				if(%item == C4Pack)
				{
					Client::sendMessage(%client,0,"Purchased Antimatter Explosive - Auto Buying Detonator");
					buyItem(%client,"Detonator");
				}
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
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				if(%item == NML && Player::getItemCount(%client,"NMLPack") == 0)
				{
					buyItem(%client,"NMLPack");
					Client::sendMessage(%client,0,"Bought Nuke Launcher - Auto buying Support Pack");
				}
				if(%item == Pheonix && Player::getItemCount(%client,"NMLPack") == 0)
				{
					buyItem(%client,"NMLPack");
					Client::sendMessage(%client,0,"Bought Pheonix - Auto buying Support Pack");
				}
				if(%item == Reason)
				{
					player::setItemCount(%client,ReasonExtra,1);
					player::setItemCount(%client,ReasonExtra2,1);
				}
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "")
				{
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats)
					{
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
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
 				else if(%shouldBuy == 2)
					return 1;
			}
		}
		else
		{
			if($TeamItemMax[%item] != "")
			{
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
	}
	%client.cloacked = 0;
	%client.nanodone = 0;
	%armor = Player::getArmor(%player);

	// Reset ALL armor specializations
	Player::setItemCount(%player,"ConstrBuff",0);
	Player::setItemCount(%player,"ArmorBuff",0);
	Player::unMountItem(%player,$SpecializeSlot);
	GameBase::setRechargeRate(%player,8);
	GameBase::setAutoRepairRate(%player,0);
	if(Player::getSensorSupression(%player) > 0)
	{
		%rate = Player::getSensorSupression(%player) - Player::getSensorSupression(%player);
		Player::setSensorSupression(%player,%rate);
	}
	// If the armor is the one you picked, just select the spec you picked, otherwise, select the armor's default spec, then redo ALL specs
	%numarmor = $ArmorNumToName[%armor];
	if(%numarmor == $ArmorMode[%client])
	{
		$ArmorSpec[%client] = $RealSpec[%client];
		RedoSpec(%player,%client,%numarmor);
	}
	else
	{
		$ArmorSpec[%client] = $ArmorDefault[%numarmor];
		RedoSpec(%player,%client,%numarmor);
	}

	if(%armor == sctarmor || %armor == sctfemale)
	{
		if($matchStarted)
			bottomprint(%client, "TalonRules Help: FAST. That's all I can say. He also gets te scout laser which is a good sniper weapon. Great for flag capping.\nDefaultSpec:"@ $ArmorDefault[%numarmor] @".");
		Player::trigger(%player,$ArmorDetailSlot,false);
		Player::unMountItem(%player,$ArmorDetailSlot);
	}
	if(%armor == larmor || %armor == lfemale)
	{
		if($matchStarted)
			bottomprint(%client, "TalonRules Help: Assassin is a weak armor but very deadly. He can cloack or use his shoulder-mounted targeter to help him snipe.\nDefaultSpec:"@ $ArmorDefault[%numarmor] @".");
		Player::trigger(%player,$ArmorDetailSlot,false);
		Player::unMountItem(%player,$ArmorDetailSlot);
		if(%armor == larmor)
			Player::mountItem(%player,AssasScope,$ArmorDetailSlot);
		else
			Player::mountItem(%player,AssasScopeFemale,$ArmorDetailSlot);
	}
	if(%armor == marmor || %armor == mfemale)
	{
		if($matchStarted)
			bottomprint(%client, "TalonRules Help: Engineer can carry almost every type of deployable, and is almost immune to snipers. He is also the only one who can use the Nano Builder Pack.\nDefaultSpec:"@ $ArmorDefault[%numarmor] @".");
		Player::trigger(%player,$ArmorDetailSlot,false);
		Player::unMountItem(%player,$ArmorDetailSlot);
		Player::mountItem(%player,EngBeaconA,$ArmorDetailSlot);
	}
	if(%armor == fgarmor || %armor == fgfemale)
	{
		if($matchStarted)
			bottomprint(%client, "TalonRules Help: For general use, fighter is great. He can fly like a light, and has almost the armor and punch of a conventional medium. Great for outdoor duels.\nDefaultSpec:"@ $ArmorDefault[%numarmor] @".");
		Player::trigger(%player,$ArmorDetailSlot,false);
		Player::unMountItem(%player,$ArmorDetailSlot);
	}
	if(%armor == harmor)
	{
		if($matchStarted)
			bottomprint(%client, "TalonRules Help: Name says it all! Only one who can use the mortar, warp a beacon where he is looking for a time, and recharge his ammo.\nDefaultSpec:"@ $ArmorDefault[%numarmor] @".");
		Player::trigger(%player,$ArmorDetailSlot,false);
		Player::unMountItem(%player,$ArmorDetailSlot);
	}
	if(%armor == tarmor)
	{
		if($matchStarted)
			bottomprint(%client, "TalonRules Help: Energon uses an advanced fusion reactor and has a built in shield. This is a great combat armor, but he is touchy around Thunderbolts and Cerebral Bores.\nDefaultSpec:"@ $ArmorDefault[%numarmor] @".");
		if($ArmorSpec[%client] == Shielding)
			%player.shieldStrength = 0.012;
		else
			%player.shieldStrength = 0.004;
		Player::trigger(%player,$ArmorDetailSlot,false);
		Player::unMountItem(%player,$ArmorDetailSlot);
		Player::mountItem(%player,EnerBattery,$ArmorDetailSlot);
		Player::trigger(%player,$ArmorDetailSlot,true);
	}
	if(%armor != tarmor)
		%player.shieldStrength = 0.0;

	if(Player::getItemCount(%client,Reason) == 0)
	{
		Player::setItemCount(%client, ReasonExtra,0);
		Player::setItemCount(%client, ReasonExtra2,0);
	}

	if(%player.station)
	{
		setupShoppingList(%client,%player.station,"InvList");
		updateBuyingList(%client);
	}
}

function remoteBuyItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	if(buyItem(%client,%item))
	{
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else 
  		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

echo("TALON:ITEM:A");
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
			else if(%pack == EnergyPack)
			{
				if(Player::getItemCount(%client,"LaserRifle") > 0)
				{
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					%gun = "LaserRifle";
					teamEnergyBuySell(%player,%gun.price);
					Player::decItemCount(%client,%gun);
				}
			}
			else if(%pack == NMLPack)
			{
				if(Player::getItemCount(%client,"NML") > 0)
				{
					Client::sendMessage(%client,0,"Sold NML Support - Auto Selling Nuke Launcher");
					%gun = "NML";
					teamEnergyBuySell(%player,%gun.price);
					Player::decItemCount(%client,%gun);
				}
			}
			else if(%item == Reason)
			{
				Player::setItemCount(%client,ReasonExtra,0);
				Player::setItemCount(%client,ReasonExtra2,0);
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
			if (%item == Grenade || %item == MineAmmo)
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
	}
}
echo("TALON:ITEM:B");
function remoteDropItem(%client,%type)
{
	if((Client::getOwnedObject(%client)).driver != 1)
	{
		//echo("Drop item: ",%type);
		%client.throwStrength = 1;

		%item = getItemData(%type);
		if (%item == Backpack)
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Weapon)
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
			if(%item == Reason)
			{
				Player::setItemCount(%client,ReasonExtra,0);
				Player::setItemCount(%client,ReasonExtra2,0);
			}
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

//Weapon switching table - My weapons: -=TalonHawk=-
$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = SupportMortar;
$NextWeapon[SupportMortar] = Artemis;
$NextWeapon[Artemis] = MineLauncher;
$NextWeapon[MineLauncher] = LaserRifle;
$NextWeapon[LaserRifle] = Reason;
$NextWeapon[Reason] = SuperGauss;
$NextWeapon[SuperGauss] = SR100;
$NextWeapon[SR100] = AR900;
$NextWeapon[AR900] = HyperLaser;
$NextWeapon[HyperLaser] = Flamer;
$NextWeapon[Flamer] = RPG;
$NextWeapon[RPG] = Pheonix;
$NextWeapon[Pheonix] = Swarmer;
$NextWeapon[Swarmer] = SML;
$NextWeapon[SML] = GasMortar;
$NextWeapon[GasMortar] = EnGun;
$NextWeapon[EnGun] = Thunderbolt;
$NextWeapon[Thunderbolt] = BlastRifle;
$NextWeapon[BlastRifle] = Disarmer;
$NextWeapon[Disarmer] = BoreGun;
$NextWeapon[BoreGun] = HealRifle;
$NextWeapon[HealRifle] = Detonator;
$NextWeapon[Detonator] = RepairGun;
$NextWeapon[RepairGun] = EnergyRifle;

$PrevWeapon[EnergyRifle] = RepairGun;
$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[SupportMortar] = Mortar;
$PrevWeapon[Artemis] = SupportMortar;
$PrevWeapon[MineLauncher] = Artemis;
$PrevWeapon[LaserRifle] = MineLauncher;
$PrevWeapon[Reason] = LaserRifle;
$PrevWeapon[SuperGauss] = Reason;
$PrevWeapon[SR100] = SuperGauss;
$PrevWeapon[AR900] = SR100;
$PrevWeapon[HyperLaser] = AR900;
$PrevWeapon[Flamer] = HyperLaser;
$PrevWeapon[RPG] = Flamer;
$PrevWeapon[Pheonix] = RPG;
$PrevWeapon[Swarmer] = Pheonix;
$PrevWeapon[SML] = Swarmer;
$PrevWeapon[GasMortar] = SML;
$PrevWeapon[EnGun] = GasMortar;
$PrevWeapon[Thunderbolt] = EnGun;
$PrevWeapon[BlastRifle] = Thunderbolt;
$PrevWeapon[Disarmer] = BlastRifle;
$PrevWeapon[BoreGun] = Disarmer;
$PrevWeapon[HealRifle] = BoreGun;
$PrevWeapon[Detonator] = HealRifle;
$PrevWeapon[RepairGun] = Detonator;

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
	if(%client.DontSwitch != true)
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
}

function isSelectableWeapon(%client,%weapon)
{
	%player = Client::getOwnedObject(%client);
	if(%player.NukeDeployMode == true)
		return;
	if (Player::getItemCount(%client,%weapon))
	{
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
	}
	return false;
}

echo("TALON:ITEM:C");
// Player
function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if (%numweapon > $MaxWeapons[%armor])
	{
	   %weaponflag = %numweapon - $MaxWeapons[%armor];
	}
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1)
	{
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "")
		{
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
			if(%numsell > 0) {
		    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item);
			teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
			Player::setItemCount(%client, %item, %count - %numsell);  
			if(%item == Reason)
			{
				Player::setItemCount(%client, ReasonExtra,0);
				Player::setItemCount(%client, ReasonExtra2,0);
			}
			updateBuyingList(%client);
			} 
		}
	}
}

function checkPlayerCash(%client)
{
	%team = Client::getTeam(%client);	
	if($TeamEnergy[%team] != "Infinite")
	{
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1))
		{
			if(%client.teamEnergy >= 0)
				%diff = $InitialPlayerEnergy;
			else 
				%diff = $InitialPlayerEnergy + %client.teamEnergy;
			$TeamEnergy[%team] -= %diff;
		}
	}
}

//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------
echo("TALON:ITEM:D");
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
				Client::sendMessage(%client,0,"You received a " @ %item.description @ " backpack");
		 		return 1;
			}
		}
  		else
		{
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon)
			{
				%wcount = Player::getItemClassCount(%client,"Weapon");
				if(%item == NML || %item == Pheonix)
					%ciw = true;
				else if(%item == Reason)
					%eslots = 1;
				else
					%eslots = 0;
				if(%ciw == true && %wcount > 0)
					return 0;
				if(%wcount >= $MaxWeapons[%armor] - %eslots)
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
				if(%item == Reason)
				{
					Player::setItemCount(%player,ReasonExtra,1);
					Player::setItemCount(%player,ReasonExtra2,1);
				}
				return %delta;
			}
		}
   }
	return 0;
}

echo("TALON:ITEM:E");
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
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

// Scout Armor
ItemData ScoutArmor
{
   heading = "aArmor";
	description = "Infiltrator";
	className = "Armor";
	price = 100;
};

// Assassin Armor
ItemData LightArmor
{
   heading = "aArmor";
	description = "Assassin";
	className = "Armor";
	price = 200;
};

// Engineer Armor
ItemData MediumArmor
{
   heading = "aArmor";
	description = "Artificer";
	className = "Armor";
	price = 250;
};

// Kamikaze Armor: -=TalonHawk=-
ItemData KamikazeArmor
{
   heading = "aArmor";
	description = "Kamikaze Armor";
	className = "Armor";
	price = 295;
	showInventory = false;
};

// Fighter Armor: -=TalonHawk=-
ItemData FighterArmor
{
   heading = "aArmor";
	description = "Warrior";
	className = "Armor";
	price = 350;
};

// Destroyer Armor
ItemData HeavyArmor
{
   heading = "aArmor";
	description = "Marauder";
	className = "Armor";
	price = 430;
};

// Trooper (ENERGON) Armor: -=TalonHawk=-
ItemData TrooperArmor
{
   heading = "aArmor";
	description = "Titan";
	className = "Armor";
	price = 500;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------
//Plane item maxes for TalonRules: -=TalonHawk=-
$TeamItemMax[KamikazeVehicle] = 2;
$TeamItemMax[BomberVehicle] = 2;
$TeamItemMax[InterceptorVehicle] = 3;
$TeamItemMax[StealthVehicle] = 2;


ItemData ScoutVehicle
{
	description = "("@$TeamItemMax[ScoutVehicle]@")'Hawk' Light Scout";
	className = "Vehicle";
   heading = "aVehicle";
	price = 500;
};

// Interceptor
ItemData InterceptorVehicle
{
	description = "("@$TeamItemMax[InterceptorVehicle]@")VK-5 'Zero' Interceptor";
	className = "Vehicle";
   heading = "aVehicle";
	price = 700;
};

// Bomber & Other vehics. : -=TalonHawk=-
ItemData BomberVehicle
{
	description = "("@$TeamItemMax[BomberVehicle]@")ADB-90 'Behemoth'";
	className = "Vehicle";
   heading = "aVehicle";
	price = 750;
};

// V-48 Stealth Plane
ItemData StealthVehicle
{
	description = "("@$TeamItemMax[StealthVehicle]@")V-48 'Spirit' Stealth";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1000;
};

ItemData LAPCVehicle
{
	description = "("@$TeamItemMax[LAPCVehicle]@")'Wyvren' LPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "("@$TeamItemMax[HAPCVehicle]@")'Dragon' HPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
};

// Kamikaze
ItemData KamikazeVehicle
{
	description = "("@$TeamItemMax[KamikazeVehicle]@")DB-29 'Kamikaze' BombPlane";
	className = "Vehicle";
   heading = "aVehicle";
	price = 900;
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

	if(%player.NukeDeployMode == true && (%item != NML || %item != Pheonix))
		return;

	if(%player.LockWep == true)
		return;

	if(%player.Station=="")
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
	reloadTime = 0.1;
	fireTime = 0.4;
	minEnergy = 9;
	maxEnergy = 9;

	accuFire = true;

	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bLight-Class Weapons";
	description = "Plasma Pistol";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 125;
	showWeaponBar = true;
};

function Blaster::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: The Plasma Pistol has 2 fire modes: A single-shot for sniping, and a quad mode for dealing heavy damage. Beware quad shots have trajectories.");
}

function BlasterImage::onFire(%player,%slot)
{
	%clientId = Player::getClient(%player);
	if (%clientId.Blastermode == "Four")
	{
		%energy = GameBase::getEnergy(%player);
		if(%energy > 8)
		{
			%newEnergy = (%energy - 16);
			GameBase::setEnergy(%player,%newEnergy);
			%vel = Item::getVelocity(%player);
			%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),1000);
			Projectile::spawnProjectile("PlasmaBullet",%trans,%player,%vel);
			%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),1250);
			Projectile::spawnProjectile("PlasmaBullet",%trans,%player,%vel);
			%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),1500);
			Projectile::spawnProjectile("PlasmaBullet",%trans,%player,%vel);
			%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),1750);
			Projectile::spawnProjectile("PlasmaBullet",%trans,%player,%vel);
			playSound(SoundFireBlaster,GameBase::getPosition(%player));
			playSound(SoundFireBlaster,GameBase::getPosition(%player));
		}
	}
	else
	{
		%energy = GameBase::getEnergy(%player);
		if(%energy > 1)
		{
			%newEnergy = (%energy - 9);
			GameBase::setEnergy(%player,%newEnergy);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("PlasmaSniper",%trans,%player,%vel);
			playSound(SoundFireBlaster,GameBase::getPosition(%player));
		}
	}
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
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.2;

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
	description = "Plasma Rifle";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};

function PlasmaGun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: The Plasma Rifle is an automatic weapon system that can deliver deadly plasma bursts at a rapid fire rate, but it loses accuracy quickly. It can also recharge its ammo.");
}

function PlasmaGunImage::onFire(%player, %slot)
{
	echo(%player @" fires a plasma gun");
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]);
	if(%AmmoCount > 0)
	{
		if(%player.inac < 2000)
		{
			%player.inac += 400;
			schedule(%player @".inac -= 400;",0.75,%player);
			echo(%player.inac);
		}

		%flash = %player.inac / 2600;
		Player::setDamageFlash(%player,%flash);

		Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),(%player.inac - 400));
		Projectile::spawnProjectile("AutoPlasmaBolt",%trans,%player,%vel,%player);

		if(%player.PlasmaGunRecharging != True)
		{
			%player.PlasmaGunRecharging = True;
			%guntype = PlasmaGun;
			schedule("RechargeAmmo(" @ %player @ ", " @ %guntype @ ");",2,%player);
		}

	}
	else Client::sendMessage(Player::getClient(%player), 0,"Plasma Rifle out of ammo.");
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
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
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

function DiscAmmo::onUse(%player,%item)
{
	SpawnMeAnAI(%player);
}

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
	spinUpTime = 0.15;

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

function DiscLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help:  New weapons made even the disclauncher need to be revamped. Adding better maglev magnets made the bullet shoot and wind-up at a higher speed.");
}

//----------------------------------------------------------------------------
// Grenade Launcher
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
	fireTime = 0.2;

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

function GrenadeLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	if($matchStarted)
	      bottomprint(%client, "TalonRules Help: Improved reload rate helps you wreck more havoc with base defenders and deployed defenses.");
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
	reloadTime = 0.4;
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
   heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 475;
	showWeaponBar = true;
};

function Mortar::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: Packs more punch that the old mortar and reloads faster. Still the best for all-purpose death & destruction.");
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
	maxEnergy = 50;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Scout Laser";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
};

function LaserRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help:  The scout laser is a sniper weapon for scouts. It does a good amount of damage to all armor types and reloads quickly. Let your energy charge up before you fire for maximum damage.");
}

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
	minEnergy = 2;
	maxEnergy = 12;
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
   heading = "dSpecialWeapons";
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
   minEnergy = 2;
   maxEnergy = 8;  // Energy used/sec for sustained weapons
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

function EnergyRifle::onMount(%player,%imageSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "For its purpose of keeping turrets at bay, the ELF gun was revamped to have a super low energy consumption rate.");
}

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 5;
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
	price = 125;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help:  The repair gun now heals quicker than ever, making repairing less time consuming!");
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//---------------------------------------\
// My mod's weapon data : -=TalonHawk=-  |>
//---------------------------------------/

$WeaponAmmo[SR100] = SniperAmmo;
$WeaponAmmo[AR900] = AssaultAmmo;
$WeaponAmmo[GasMortar] = GasAmmo;
$WeaponAmmo[Swarmer] = SwarmerAmmo;
$WeaponAmmo[Reason] = ReasonAmmo;
$WeaponAmmo[RPG] = RPGAmmo;
$WeaponAmmo[NML] = NMLAmmo;
$WeaponAmmo[SML] = SMLAmmo;
$WeaponAmmo[BlastRifle] = BlastAmmo;
$WeaponAmmo[HyperLaser] = "";
$WeaponAmmo[Flamer] = "";
$WeaponAmmo[Thunderbolt] = "";
$WeaponAmmo[JumpGun] = "";
$WeaponAmmo[NanoGun] = "";
$WeaponAmmo[HealRifle] = "";
$WeaponAmmo[EnGun] = "";
$WeaponAmmo[Disarmer] = "";
$WeaponAmmo[SupportMortar] = SMAmmo;
$WeaponAmmo[MineLancher] = MineGrenadeAmmo;
$WeaponAmmo[BoreGun] = BoreAmmo;
$WeaponAmmo[Pheonix] = PheonixAmmo;
$WeaponAmmo[SuperGauss] = SuperGaussAmmo;

//----------------------------------------------------------------------------
//Station.cs first
$InvList[AR900] = 1;
$InvList[Thunderbolt] = 1;
$InvList[SR100] = 1;
$InvList[HyperLaser] = 1;
$InvList[Flamer] = 1;
$InvList[NML] = 0;
$InvList[Chaingun] = 1;
$InvList[RPG] = 1;
$InvList[GasMortar] = 1;
$InvList[SML] = 1;
$InvList[HealRifle] = 1;
$InvList[Swarmer] = 1;
$InvList[Reason] = 1;
$InvList[EnGun] = 1;
$InvList[BlastRifle] = 1;
$InvList[Disarmer] = 1;
$InvList[SupportMortar] = 1;
$InvList[MineLauncher] = 1;
$InvList[BoreGun] = 1;
$InvList[Pheonix] = 1;
$InvList[SuperGauss] = 1;
$InvList[SuperGaussAmmo] = 1;

$RemoteInvList[AR900] = 1;
$RemoteInvList[Thunderbolt] = 1;
$RemoteInvList[SR100] = 1;
$RemoteInvList[HyperLaser] = 1;
$RemoteInvList[Flamer] = 1;
$RemoteInvList[RPG] = 1;
$RemoteInvList[Gatling] = 1;
$RemoteInvList[NML] = 0;
$RemoteInvList[GasMortar] = 1;
$RemoteInvList[SML] = 1;
$RemoteInvList[HealRifle] = 1;
$RemoteInvList[Swarmer] = 1;
$RemoteInvList[Reason] = 1;
$RemoteInvList[EnGun] = 1;
$RemoteInvList[BlastRifle] = 1;
$RemoteInvList[Disarmer] = 1;
$RemoteInvList[SupportMortar] = 1;
$RemoteInvList[MineLauncher] = 1;
$RemoteInvList[Pheonix] = 1;
$RemoteInvList[SuperGauss] = 1;
$RemoteInvList[SuperGaussAmmo] = 1;

//----------------------------------------------------------------------------

$InvList[AssaultAmmo] = 1;
$InvList[SniperAmmo] = 1;
$InvList[RPGAmmo] = 1;
$InvList[NMLAmmo] = 1;
$InvList[SMLAmmo] = 1;
$InvList[SwarmerAmmo] = 1;
$InvList[EMPAmmo] = 1;
$InvList[ReasonAmmo] = 1;
$InvList[GasAmmo] = 1;
$InvList[BlastAmmo] = 1;
$InvList[MineGrenadeAmmo] = 1;
$InvList[SMAmmo] = 1;
$InvList[BoreAmmo] = 1;
$InvList[PheonixAmmo] = 1;

$RemoteInvList[AssaultAmmo] = 1;
$RemoteInvList[SniperAmmo] = 1;
$RemoteInvList[RPGAmmo] = 1;
$RemoteInvList[NMLAmmo] = 1;
$RemoteInvList[SMLAmmo] = 1;
$RemoteInvList[SwarmerAmmo] = 1;
$RemoteInvList[EMPAmmo] = 1;
$RemoteInvList[ReasonAmmo] = 1;
$RemoteInvList[GasAmmo] = 1;
$RemoteInvList[BlastAmmo] = 1;
$RemoteInvList[MineGrenadeAmmo] = 1;
$RemoteInvList[SMAmmo] = 1;
$RemoteInvList[PheonixAmmo] = 1;

//----------------------------------------------------------------------------
ItemImageData SomethingImage
{
	shapeFile = "paintgun";
   mountPoint = 0;

   weaponType = 0;  // Sustained
	projectileType = SmiteRay;
   minEnergy = 0;
   maxEnergy = 0;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
	fireTime = 0.0;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

// Support Mortar (All the cool stuff)
ItemData SMAmmo
{
	description = "Support Mortar Ammo";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData SupportMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SMAmmo;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundGeneratorPower;
};

function SupportMortarImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SupportMortar]);
	if(%AmmoCount > 0)
	{
		Player::decItemCount(%player,"SMAmmo",1);
		%clientId = Player::getClient(%player);
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if (%clientId.Mortarmode == "EMP")
			Projectile::spawnProjectile("EMPMortar",%trans,%player,%vel,%player);
		else
			Projectile::spawnProjectile("FlameMortarShell",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("SmokeRelease",%trans,%player,%vel,%player);
	}
	else Client::sendMessage(Player::getClient(%player), 0,"Support Mortar out of ammo.");
}

ItemData SupportMortar
{
	description = "Support Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "dSpecial Weapons";
	shadowDetailMask = 4;
	imageType = SupportMortarImage;
	price = 475;
	showWeaponBar = true;
};

function SupportMortar::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: While packing less punch than a mortar, it's high-damage incendiary shells and crippling EMP rounds can be very usefull.");
}

//Artemis
ItemData ArtemisAmmo
{
	description = "Artemis Missile";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData ArtemisImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	mountOffset = { 0, 0.12, 0 };

	weaponType = 0; // Single Shot
	ammoType = ArtemisAmmo;
	accuFire = false;
	reloadTime = 0.4;
	fireTime = 1.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Artemis
{
	description = "Artemis Artillery";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = ArtemisImage;
	price = 475;
	showWeaponBar = true;
};

ItemImageData ArtemisAImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	mountRotation = {0, 3.14, -0.03};
	mountOffset = { -0.1, 0, 0 };

	weaponType = 0; // Single Shot
	ammoType = ArtemisAmmo;
	accuFire = false;
	reloadTime = 0.4;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData ArtemisA
{
	description = "Artemis Artillery";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ArtemisAImage;
	price = 475;
	showWeaponBar = true;
};

ItemImageData ArtemisBImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	mountRotation = {0, 3.14, 0.03};
	mountOffset = { 0.1, 0, 0 };

	weaponType = 0; // Single Shot
	ammoType = ArtemisAmmo;
	accuFire = false;
	reloadTime = 0.4;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData ArtemisB
{
	description = "Artemis Artillery";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = ArtemisBImage;
	price = 475;
	showWeaponBar = false;
	showInventory = false;
};

function Artemis::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: The artemis artillery launches heavy ballistic missiles from it's dual oscilating barrels. Once you get used to it, it is a very powerful weapon.");
	Player::mountItem(%player,ArtemisA,$ExtraWeaponSlotA);
	Player::mountItem(%player,ArtemisB,$ExtraWeaponSlotB);
}

function Artemis::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unmountItem(%player,$ExtraWeaponSlotA);
	Player::unmountItem(%player,$ExtraWeaponSlotB);
}

function ArtemisImage::onFire(%player,%slot)
{
	if(Player::getItemCount(%player, ArtemisAmmo) > 0)
	{
		%ft = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
		addToSet("MissionCleanup", %ft);
		GameBase::setPosition(%ft,Vector::Add(GameBase::GetPosition(%player),-1000));
		%player.ft = %ft;
		schedule("deleteObject("@%player.ft@");",20);

		if($ArtBarrel[%player] == "")
			$ArtBarrel[%player] = A;

		FireArtemis(%player,$ArtBarrel[%player]);
	}
}

function ArtemisAImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ArtemisRocket",%trans,%player,%vel,$beaconTarget);
	Player::decItemCount(%player,ArtemisAmmo,1);
}

function ArtemisBImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ArtemisRocket",%trans,%player,%vel,$beaconTarget);
	Player::decItemCount(%player,ArtemisAmmo,1);
}

function FireArtemis(%player,%barrel)
{
	TalonJump(%player,-90,2);
	if(%barrel == A)
	{
		Player::trigger(%player,$ExtraWeaponSlotA,true);
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotA@",false);",0.1);
		$ArtBarrel[%player] = B;
	}
	else
	{
		Player::trigger(%player,$ExtraWeaponSlotB,true);
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotB@",false);",0.1);
		$ArtBarrel[%player] = A;
	}
}

// Grenade Launcher
ItemData MineGrenadeAmmo
{
	description = "Mine Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData MineLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MineGrenadeAmmo;
	projectileType = MineDeployer;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.2;

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
	shapeFile = "grenadel";
	hudIcon = "grenade";
   heading = "dSpecial Weapons";
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function MineLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: This weapon fires small canisters that explode and release a mine. Note: Mines will injure teammates, and do not give credit to you for the kill.");
}

// Reason - Rapid Fire Machine Railgun (RFMR)
ItemData ReasonAmmo
{
	description = "Reason Rail Dart";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ReasonImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 0.5, 0 };

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.15;

	ammoType = ReasonAmmo;
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

ItemData Reason
{
	description = "Reason Mchn-Railgun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "weapon";
   heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = ReasonImage;
	price = 625;
	showWeaponBar = true;
};

function Reason::onDrop(%player,%item)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload")
	{
		Player::setItemCount(%player,ReasonExtra,0);
		Player::setItemCount(%player,ReasonExtra2,0);
		Item::onDrop(%player,%item);
	}
}	

function Reason::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getClient(%player);
      Bottomprint(%client, "TalonRules Help:<f2> They will listen to Reason!<f0> This powerful gun chuns out supersonic metal darts that tears up anything, even turrets. It's ammo wont last too long, so use only when needed.");
	Player::mountItem(%player,ReasonExtra,$ExtraWeaponSlotA);
	Player::mountItem(%player,ReasonExtra2,$ExtraWeaponSlotB);
}

function Reason::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unMountItem(%player,$ExtraWeaponSlotA);
	Player::unMountItem(%player,$ExtraWeaponSlotB);
}

function ReasonImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Reason]);
	if(%AmmoCount > 0)
	{
		Player::decItemCount(%player,$WeaponAmmo[Reason],1);
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("RailDart",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("SmokeRelease",%trans,%player,%vel,%player);
		if(!$ERSlotsFiring[%client])
			FireReasonSlots(%player,%client);
	}
	else Client::sendMessage(Player::getClient(%player), 0,"Reason Machine-Railgun out of ammo.");
}

function FireReasonSlots(%player,%client)
{
	if((Player::isTriggered(%player,$WeaponSlot)) && (Player::getMountedItem(%player,$WeaponSlot) == "Reason"))
	{
		Player::trigger(%player,$ExtraWeaponSlotA,true);
		Player::trigger(%player,$ExtraWeaponSlotB,true);
		$ERSlotsFiring[%client] = true;
		schedule("FireReasonSlots(" @ %player @ "," @ %client @ ");",0.05);
	}
	else
	{
		Player::trigger(%player,$ExtraWeaponSlotA,false);
		Player::trigger(%player,$ExtraWeaponSlotB,false);
		$ERSlotsFiring[%client] = false;
	}
}

ItemImageData ReasonExtraImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -0.15, 0, 0.035 };
	mountRotation = { 0, -0.5, 0 };

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 3;
	fireTime = 0.15;

	ammoType = ReasonAmmo;
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

ItemData ReasonExtra
{
	description = "Reason Extra Barrel";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ReasonExtraImage;
	price = 0;
	showInventory = false;
	showWeaponBar = true;
};

function ReasonExtraImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Reason]);
	if(%AmmoCount > 0)
	{
		Player::decItemCount(%player,$WeaponAmmo[Reason],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("RailDart",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("SmokeRelease",%trans,%player,%vel,%player);
	}
}

ItemImageData ReasonExtra2Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -0.15, 0, -0.055 };

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 3;
	fireTime = 0.15;

	ammoType = ReasonAmmo;
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

ItemData ReasonExtra2
{
	description = "Reason Extra Barrel 2";
	className = "Tool";
	shapeFile = "chaingun";
	hudIcon = "weapon";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ReasonExtra2Image;
	price = 0;
	showInventory = false;
	showWeaponBar = false;
};

function ReasonExtra2Image::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Reason]);
	if(%AmmoCount > 0)
	{
		Player::decItemCount(%player,$WeaponAmmo[Reason],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("RailDart",%trans,%player,%vel,%player);
		Projectile::spawnProjectile("SmokeRelease",%trans,%player,%vel,%player);
	}
}

//----------------------------------------------------------------------------

ItemData SuperGaussAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SuperGaussImage
{
	shapeFile = "disc";
	mountPoint = 0;

	mountRotation = {0, 1.57, 0};

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 5;
	spinDownTime = 0.5;
	fireTime = 0.2;
	ammoType = SuperGaussAmmo;
	accuFire = true;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundDiscSpin;
	sfxSpinDown = SoundDiscSpin;
};

ItemData SuperGauss
{
	description = "Gauss Rifle";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = SuperGaussImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData SuperGaussSecImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	mountRotation = {0, 3.14, 0};
	mountPosition = {-0.5, -1, 0};

	weaponType = 0; // Spinning
	reloadTime = 0;
	projectileType = GaussSniperShot;
	fireTime = 0.2;
	accuFire = true;

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SuperGaussSec
{
	description = "Gauss Rifle PT2";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SuperGaussSecImage;
	price = 150;
	showWeaponBar = true;
};

function SuperGauss::onMount(%player,%item,$WeaponSlot)
{
	Player::mountItem(%player,SuperGaussSec,$ExtraWeaponSlotA);
	if(%player.SupressHelp == True)
	{
		%player.SupressHelp = false;
		return;
	}
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: The Gauss Rifle is a powerful sniper weapon. It can do insane damage, but requires you to charge it up before firing.");
}

function SuperGauss::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unMountItem(%player,$ExtraWeaponSlotA);
}

function SuperGaussImage::onFire(%player, %slot)
{
	%ac = Player::getItemCount(%player,SuperGaussAmmo);
	if(%ac > 0)
	{
		Player::decItemCount(%player,SuperGaussAmmo,1);

		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);

		Player::trigger(%player,$ExtraWeaponSlotA,true);
		Player::trigger(%player,$ExtraWeaponSlotA,false);

		%player.SupressHelp = true;
		Player::unmountItem(%player,$WeaponSlot);
		Player::mountItem(%player,SuperGauss,$WeaponSlot);

		playSound(SoundFireSeeking,GameBase::getPosition(%player));
	}
	else Client::sendMessage(%clientId, 0,"Gauss Rifle out of ammo.");
}

// SR-100 Rifle
ItemData SniperAmmo
{
	description = "Sniper Rounds";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData SR100Image
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SniperAmmo;
	accuFire = true;
	reloadTime = 2.5;
	fireTime = 0.8;

	lightType = 3;  // Weapon Fire
	lightRadius = 8;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };

	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundSrReload;
};

ItemData SR100
{
	description = "SR-100 Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SR100Image;
	price = 400;
	showWeaponBar = true;
};

function SR100::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help: The SR-100 Sniper Rifle is the ultimate in sniper weapon technology. It has 3 types of ammo, AP, EMP, and Poison. Notes: AP does little to Engineers and Poison cannot penetrate shields.");
}

function SR100Image::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SR100]);
	if(%AmmoCount > 0)
	{
		Player::decItemCount(%player,$WeaponAmmo[SR100],1);
		%clientId = Player::getClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if (%clientId.SR100mode == "EMP")
		{
			Projectile::spawnProjectile("EMPSniper",%trans,%player,%vel);
		}
		else if (%clientId.SR100mode == "Poison")
		{
			Projectile::spawnProjectile("PoisonSniper",%trans,%player,%vel);
		}
		else if (%clientId.SR100mode == "AP" || %clientId.SR100mode == "")
		{
			Projectile::spawnProjectile("SniperShell",%trans,%player,%vel);
		}
	}
	else Client::sendMessage(%clientId, 0,"SR-100 Sniper Rifle out of ammo.");
}

// AR-900 Rifle
ItemData AssaultAmmo
{
	description = "AR-900 Shell";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData AR900Image
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.2;
	spinuptime = 0.001;
	spindowntime = 0.03;
	fireTime = 0.6;

	ammoType = AssaultAmmo;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = GunEquip;
};

function AR900Image::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AR900]);
	if(%AmmoCount > 0)
	{
		%player.ARInac += 1;
		if(%player.ReloadChecking != true)
			schedule("AR900::inacCheck("@ %player @");",0.5,%player);


		FireAR900(%player);
		if(%AmmoCount > 1)
			schedule("FireAR900("@ %player @");",0.125,%player);
		if(%AmmoCount > 2)
			schedule("FireAR900("@ %player @");",0.25,%player);
	}
	else Client::sendMessage(Player::getClient(%player),0,"AR-900 is out of ammo.");
}

function AR900::inacCheck(%player)
{
	%state = Player::getItemState(%player,$WeaponSlot);
	if(%player.ARInac == 0)
		%player.ReloadChecking = false;
	else if(%player.ARInac > 0)
	{
		%player.ReloadChecking = true;
		if(%state != "Fire" && %state != "Reload")
			%player.ARInac--;
		schedule("AR900::inacCheck("@ %player @");",0.25,%player);
	}
}

function FireAR900(%player)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);

	if(%player.ARInac > 3)
		%inac = 3;
	else
		%inac = %player.ARInac -1;


	%shell = "AssaultShellLevel"@ %inac;
	Projectile::spawnProjectile(%shell,%trans,%player,%vel);
      Projectile::spawnProjectile("SmokeRelease2",%trans,%player,%vel,%player);	
	Player::decItemCount(%player,$WeaponAmmo[AR900],1);
	%playerpos = GameBase::getPosition(%player);
	playSound(shockExplosion,%playerpos);
}

ItemData AR900
{
	description = "AR-900 Assault Rifle";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "rifle";
	heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = AR900Image;
	price = 850;
	showWeaponBar = true;
};

function AR900::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	Bottomprint(%client, "TalonRules Help:  The AR-900 Assault Rifle fires 3-shot bursts of high-powered armor-piercing explosive shells that do enormous amounts of damage to Energons and Destroyers. It is best to time out your shots as ammo and accuracy can become problems with the AR-900.");
}

ItemImageData HyperLaserImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = turboLaser;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.2;
	minEnergy = 5;
	maxEnergy = 5;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HyperLaser
{
	description = "Implosion Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = HyperLaserImage;
	price = 650;
	showWeaponBar = true;
};

function HyperLaser::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help: This gun will make you laugh. Although it does no physical damage, it 'pulls' players into the shockwave. You can use it to get a boost if your careful, or ram wounded players into walls or back into your range.");
}

// Devastator Flamethrower
ItemImageData FlamerImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0.0;
	spinuptime = 0.06;
	spindowntime = 0.06;
	fireTime = 0.2;

	minEnergy = 2;
	maxEnergy = 5;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFlyerActive;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundFlamerDown;
	sfxSpinDown = SoundFlamerDown;
};

ItemData Flamer
{
	description = "Devestator FlameThrower";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 850;
	showWeaponBar = true;
};

function Flamer::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help:  The Devestator can torch people, burn up stations, and destroy turrets in just a matter of seconds. The serious draw back is it's range though. Try it and you'll see.");
}

function FlamerImage::onFire(%player,%slot)
{
	%energy = GameBase::getEnergy(%player);
	if(%energy > 2)
	{
		%newEnergy = (%energy - 6);
		GameBase::setEnergy(%player,%newEnergy);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("Fireball",%trans,%player,%vel);
		Projectile::spawnProjectile("SmokeRelease",%trans,%player,%vel);
		%flash = 0.50;
		Player::setDamageFlash(%player,%flash);
	}
}

// RPG Launcher
ItemData RPGAmmo
{
	description = "Rckt Prpld Grenade";
	className = "Ammo";
	shapeFile = "mortar";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData RPGImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = RPGAmmo;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0.8;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData RPG
{
	description = "RPG";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "blaster";
   heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = RPGImage;
	price = 1050;
	showWeaponBar = true;
};

function RPG::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help:  This advanced weapon system fires Rocket Propelled Grenades. It can fire Explosive, EMP, and Seeking grenades.");
}

function RPGImage::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RPG]);
	if(%AmmoCount > 0)
		{
		%playerpos = GameBase::getPosition(%player);
		%clientId = Player::getClient(%player);
		%clientName = Client::getName(%clientId);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if (%clientId.RPGmode == "Seeking")
		{
			%clientName = Client::getName(%client);
			if(GameBase::getLOSInfo(%player,1000))
			{
				%object = getObjectType($los::object);
				%targeted = GameBase::getOwnerClient($los::object);
				if(%object == "Player" || %object == "Flier")
				{
					%targetP = Client::getName(%targeted);
					Client::sendMessage(%clientId,0,"RPG-CPU: Seeker RPG lock acquired "@ %targetP @"~wpda_on.wav");
					Client::sendMessage(%targeted,0,"ALERT: Seeking RPG lock detected - " @ %clientName @ "~waccess_denied.wav");
					Projectile::spawnProjectile("RPGSeeker",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RPG],1);
					playSound(SoundFireSeeking,%playerpos);
				}
				else {
					Client::sendMessage(Player::getClient(%player),1,"Target has no signature - cancelling fire.~waccess_denied.wav");
					Player::unmountItem(%player,$WeaponSlot);
					Player::mountItem(%player,RPG,$WeaponSlot);
				}
			}
			else {
				Client::sendMessage(Player::getClient(%player),1,"Target is out of range - cancelling fire.~waccess_denied.wav");
				Player::unmountItem(%player,$WeaponSlot);
				Player::mountItem(%player,RPG,$WeaponSlot);
			}
		}
		else if (%clientId.RPGmode == "EMP")
		{
			Projectile::spawnProjectile("EMPMissile",%trans,%player,%vel,%player);
			Player::decItemCount(%player,$WeaponAmmo[RPG],1);
			playSound(SoundFireSeeking,%playerpos);
		}
		else
		{
			Player::decItemCount(%player,$WeaponAmmo[RPG],1);
			Projectile::spawnProjectile("RPGMissile",%trans,%player,%vel,%player);
			playSound(SoundFireSeeking,%playerpos);
		}
	}
	else Client::sendMessage(Player::getClient(%player), 0,"RPGL out of ammo.");
}

// P H E O N I X - Weapon of Mass Destruction
ItemData PheonixAmmo
{
	description = "Pheonix Charge Packs";
	className = "Ammo";
	shapeFile = "mortar";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1000;
};

ItemImageData PheonixImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PheonixAmmo;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 4.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Pheonix
{
	description = "The Pheonix SSDG";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "blaster";
   heading = "eApocalyptic Weapons";
	shadowDetailMask = 4;
	imageType = PheonixImage;
	price = 2000;
	showWeaponBar = true;
};

function Pheonix::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help: The Pheonix creates a linear spacial distortion causing all space between the player and the target to collapse momentarily causing pure chaos.");
	Player::mountItem(%player,SlotTaker2,$ExtraWeaponSlotA);
}

function Pheonix::onUnmount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	%msg = "***FNX-OBC: Pheonix SSDG De-Activated***";
	schedule("Bottomprint("@ %client @",\""@ %msg @"\");",3); // PORT: the text was not quoted
	Player::trigger(%player,$ExtraWeaponSlotA,false);
	Player::unmountItem(%player,$ExtraWeaponSlotA);
}

function PheonixImage::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Pheonix]);
	%client = Player::getClient(%player);
	%name = Client::getName(%client);
	if(%AmmoCount > 0)
	{
		if($FNXClear[GameBase::getTeam(%client)] == true || $FNXClear[GameBase::getTeam(%client)] == "")
		{
			echo("TALON:Player firing pheonix");
			//Ammo/clearance
			Player::decItemCount(%player,$WeaponAmmo[Pheonix],1);
			$FNXClear[GameBase::getTeam(%client)] = false;

			BuildUpFlash(%player,20,"",1);
			Schedule("LaunchFNXBolt("@ %client @","@ %player @");",10,%player);

			//Fire Proj.
			//Make laser
			Player::trigger(%player,$ExtraWeaponSlotA,true);
			Player::trigger(%player,$ExtraWeaponSlotA,false);
		}
		else
		{
			Player::unmountItem(%player, $WeaponSlot);
			Player::mountItem(%player,Pheonix,$WeaponSlot);
			Client::sendMessage(%client,0,"Error: Pheonix Reactor is still recharging.~waccess_denied.wav");
		}
	}
	else Client::sendMessage(%client, 0,"Pheonix out of ammo.");
}

function LaunchFNXBolt(%client,%player)
{
	Client::sendMessage(%client, 1,"***FNX-CPU: Creating distortion***~wenergypackon.wav");
	$FNXLauncher = %client;
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("FNXDistortion",%trans,%player,%vel,%player);
	schedule("$FNXClear[" @ GameBase::getTeam(%client) @ "] = true;",10);
	// Casting FX
	$FNXCastPos = GameBase::getPosition(%player);
	schedule("DoFNXEffects(1);",0.2);
	schedule("DoFNXEffects(2);",0.3);
	schedule("DoFNXEffects(3);",0.4);
	schedule("DoFNXEffects(4);",0.5);
	schedule("DoFNXEffects(5);",0.6);
	schedule("DoFNXEffects(6);",0.7);
	schedule("DoFNXEffects(7);",0.8);
	schedule("DoFNXEffects(8);",0.9);
	schedule("DoFNXEffects(9);",1.0);
}

function DoFNXEffects(%step)
{
	%pos = $FNXCastPos;
	if(%step == 1)
		%vec = "1 1 0";
	if(%step == 2)
		%vec = "0.7 0.7 0.4";
	if(%step == 3)
		%vec = "0.6 0.6 0.8";
	if(%step == 4)
		%vec = "0.4 0.4 1.2";
	if(%step == 5)
		%vec = "0.2 0.2 1.6";
	if(%step == 6)
		%vec = "-0.2 -0.2 1.2";
	if(%step == 7)
		%vec = "-0.4 -0.4 0.8";
	if(%step == 8)
		%vec = "-0.7 -0.7 0.4";
	if(%step == 9)
		%vec = "-1 -1 0";

	%newpos = Vector::Add(%pos,%vec);
	%obj = newObject("","Mine","FNXChargeUpBlue");
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%newpos);
}

function Pheonix::onUse(%player,%item)
{
	if(%player.NukeDeployMode == true)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"You must be deployed on a heavy weapons pad to use the Pheonix.");
}

//	%playerpos = GameBase::getPosition(%player);
//	%clientId = Player::getClient(%player);
//	if(%clientId.FNXmode == "Detonate")
//	{
//	}
//	else
//	{
//		%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Pheonix]);
//		if(%AmmoCount > 0)
//		{
//			if($FNXCharges[%clientId] < 10)
//			{
//				if($FNXCharges[%clientId] == "")
//				$FNXCharges[%clientId] = 0;
//				Client::sendMessage(Player::getClient(%player), 0,"FNX-CPU: Charge Launched - "@ $FNXCharges[%clientId] @" already out");
//				%trans = GameBase::getMuzzleTransform(%player);
//				%vel = Item::getVelocity(%player);
//				Projectile::spawnProjectile("FnxMissile",%trans,%player,%vel,%player);
//				Player::decItemCount(%player,$WeaponAmmo[Pheonix],1);
//				playSound(SoundFireSeeking,%playerpos);
//				$LastPheonix = %client;
//			}
//			else
//			{
//				Player::unmountItem(%player, $WeaponSlot);
//				Player::mountItem(%player,Pheonix,$WeaponSlot);
//				Client::sendMessage(%clientId,0,"Frequency Overload - Only 10 charges allowed per player");
//			}
//		}
//		else Client::sendMessage(Player::getClient(%player), 0,"Pheonix out of ammo.");
//	}

// D O O M S  D A Y - Guided Nuclear Missile Launcher
ItemData NMLAmmo
{
	description = "Nuclear Missile";
	className = "Nuke";
	shapeFile = "rocket";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 500;
};

ItemImageData NMLImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = NMLAmmo;
	accuFire = false;
	reloadTime = 6.0;
	fireTime = 4.0;
	spinUpTime = 0.25;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireNuke;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundNMLIdle;
};

ItemData NML
{
	description = "DOOMSDAY NukeLnchr";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "eApocalyptic Weapons";
	shadowDetailMask = 4;
	imageType = NMLImage;
	price = 2000;
	showWeaponBar = true;
};

function NML::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help:  The Doomsday fires nuclear missles that incinerate players but not turrets. It can fire either player-guided (by you) or general dumb-fire missles. <f2>The missile takes 50 meters to deploy<f0> so it is more of an artillery missile.");
//	schedule("HeavyWeapons::DeployCheck("@ %player @");",5);
	Player::mountItem(%player,SlotTaker,$ExtraWeaponSlotA);
}

function NML::onUnmount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	%msg = "***NML-OBC: Doomsday NML De-Activated***";
	schedule("Bottomprint("@ %client @",\""@ %msg @"\");",3); // PORT: the text was not quoted
	Player::unmountItem(%player,$ExtraWeaponSlotA);
}

function NMLImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[NML]);
	%client = Player::getClient(%player);
	%name = Client::getName(%client);
	if(%AmmoCount > 0)
	{
		if(!GameBase::getLOSInfo(%player,50))
		{
			if($NukeClear[GameBase::getTeam(%client)] == true || $NukeClear[GameBase::getTeam(%client)] == "")
			{
				Player::decItemCount(%player,$WeaponAmmo[NML],1);
				$NukeClear[GameBase::getTeam(%client)] = false;
				//Announce launch
				MessageAllExcept(%client,1,"ALERT: "@ %name @" launched a Nuclear Missile!");
				Client::sendMessage(%client, 1,"NML-CPU: Launching Nuclear Warhead.");
				//Spawn missile
				%rot = GameBase::getRotation(%player); 
				%pos = GameBase::getPosition(%player);
				%posX = getWord(%pos,0);
				%posY = getWord(%pos,1);
				%posZ = getWord(%pos,2);
				%vec = Vector::getFromRot(%rot,5);
  				%newPosX = (getWord(%vec,0) * 1) + %posX;
				%newPosY = (getWord(%vec,1) * 1) + %posY;
				%nuke = newObject("rocket",Flier,GuidedNuke,true);
				addToSet("MissionCleanup", %nuke);
				GameBase::setTeam(%nuke,GameBase::getTeam(%player));
				GameBase::setPosition(%nuke, %newPosX @ " " @ %newPosY @ " " @ %posZ);
				GameBase::setRotation(%nuke,%rot);
				GameBase::setMapName(%nuke,"Nuclear Missile");
				playSound(SoundFireNuke,%playerpos);
				Client::setControlObject(%client,%nuke);
				GameBase::startFadeIn(%nuke);
				Player::unmountItem(%player,$WeaponSlot);
				bottomprint(%client,"<c><f2>MISSILE CAM - <f0>***ARMING WARHEAD***",1000);
				// Shell fx
				%shell = newObject("","Mine","ShellLarge");
			 	addToSet("MissionCleanup", %shell);
				GameBase::throw(%shell,%player,-1,false);
			}
			else
			{
				Player::unmountItem(%player, $WeaponSlot);
				Player::mountItem(%player,NML,$WeaponSlot);
				Client::sendMessage(%client,0,"Frequency Overload - Each team can only mantain control of 1 nuke at a time.~waccess_denied.wave");
			}
		}
		else
		{
			Player::unmountItem(%player, $WeaponSlot);
			Player::mountItem(%player,NML,$WeaponSlot);
			Client::sendMessage(%client, 1,"Target must be at least 50 meters away to deploy.~waccess_denied.wave");
		}
	}
	else Client::sendMessage(%client, 0,"Doomsday NML out of ammo.");
}

function NML::onUse(%player,%item)
{
	if(%player.NukeDeployMode == true)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"You must be deployed on a heavy weapons pad to use the NML.");
}

ItemImageData SlotTakerImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	mountOffset = { -0.1, 0, 0.175 };
	mountRotation = {0, -0.7865, 0};

	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 6.0;
	fireTime = 4.0;
	spinUpTime = 0.25;

	lightType = 2;   // Pulsing
	lightRadius = 6;
	lightTime = 1.5;
	lightColor = { 1.0, 0.25, 0.25 };
};

ItemData SlotTaker
{
	description   = "Weapon Slot Taker";
	className     = "Weapon";
	shapeFile     = "paintgun";
	hudIcon       = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = SlotTakerImage;
	price         = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData SlotTaker2Image
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	mountRotation = {0, 1.573, 0};
	mountOffset = { -0.1, 0, 0 };

	weaponType = 0; // Sustained
	projectileType = PheonixLine;
	accuFire = true;
//	minEnergy = 0;
//	maxEnergy = 0;
	reloadTime = 1.0;

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 0.4, 0.4, 1.0 };
};


ItemData SlotTaker2
{
	description   = "Pheonix Extra Weapon image";
	className     = "Weapon";
	shapeFile     = "plasma";
	hudIcon       = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = SlotTaker2Image;
	price         = 0;
	showWeaponBar = true;
	showInventory = false;
};

//Honing Swarmer Launcher
ItemData SwarmerAmmo
{
	description = "Swarmer Rack";
	className = "Ammo";
	shapeFile = "mortarammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData SwarmerImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { -0.05, 0, 0 };

	weaponType = 0; // Sustained
//	weaponType = 0; // Single-shot
	ammoType = SwarmerAmmo;
//	projectileType = NULL;
//	projectileType = sniperLaser;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 1;
	reloadTime = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundRepairItem;
};


ItemData Swarmer
{
	description = "Swarmer";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "dSpecialWeapons";
	shadowDetailMask = 4;
	imageType = SwarmerImage;
	price = 700;
	showWeaponBar = true;
};


function SwarmerImage::onFire(%player,%slot)
{
	if(Player::getItemCount(%player,SwarmerAmmo) > 0 && %player.dontFireLock != true)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("PaintLaser",%trans,%player,%vel);
	}
	else Client::sendMessage(%clientId, 0,"No ammo");
}



function Swarmer::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help:  The Swarmer is a powerful rocket launcher that can fire up to 4 seeking missiles at a time.");
	Player::mountItem(%player,ExtraSwarmerA,$ExtraWeaponSlotA);
	Player::mountItem(%player,ExtraSwarmerB,$ExtraWeaponSlotB);
	Player::mountItem(%player,ExtraSwarmerC,$ExtraWeaponSlotC);
	Player::mountItem(%player,ExtraSwarmerD,$ExtraWeaponSlotD);
}

function Swarmer::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unmountItem(%player,$ExtraWeaponSlotA);
	Player::unmountItem(%player,$ExtraWeaponSlotB);
	Player::unmountItem(%player,$ExtraWeaponSlotC);
	Player::unmountItem(%player,$ExtraWeaponSlotD);
}
echo("ASD");
function FireLockOn(%client,%target)
{
	%player = Client::GetOwnedObject(%client);
	%ammocount = Player::getItemCount(%player,SwarmerAmmo);
	if(%AmmoCount > 0)
	{
		%pname = Client::getName(%client);
		%object = getObjectType(%target);
		if(%object == "Player" || %object == "Flier" || %object == "Turret")
		{
			if(%object == "Player")
			{
				%targetCL = GameBase::getOwnerClient(%target);
				%targetName = Client::getName(%targetCL);
			}
			else
			{
				%datatype = GameBase::getDataName(%target);
				%targetName = %datatype.description;
			}
			Client::sendMessage(%client,2,"SWRM-CPU: Missile lock acquired - "@ %targetName @"~wpda_on.wav");
			Client::sendMessage(%targetCL,1,"SNSR-CPU: Missile lock detected - " @ %pname @ "~waccess_denied.wav");

			echo(%target);
			%client.target = %target;

			FireSwarmerSlots(%player,%client);
			Player::decItemCount(%player,SwarmerAmmo,1);
			return;
		}	
	}
}
echo("ASD");
function FireSwarmerSlots(%player,%client)
{
		%player.dontFireLock = true;
		schedule(%player@".dontFireLock = false;",4);


		//Activate/Deactivate other missile tubes
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotA@",true);",0.1);
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotB@",true);",0.2);
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotC@",true);",0.3);
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotD@",true);",0.4);

		schedule("TalonJump("@%player@",-30,2);",0.1);
		schedule("TalonJump("@%player@",-30,2);",0.2);
		schedule("TalonJump("@%player@",-30,2);",0.3);
		schedule("TalonJump("@%player@",-30,2);",0.4);

		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotA@",false);",0.11);
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotB@",false);",0.21);
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotC@",false);",0.31);
		schedule("Player::trigger("@%player@","@$ExtraWeaponSlotD@",false);",0.41);

		//Schedule mounts/unmounts (for effect)
		schedule(%client@".DontSwitch = true;",3.5);
		schedule(%client@".DontSwitch = false;",3.95);

		schedule("Player::unmountItem("@%player@","@$WeaponSlot@");",3.5);
		schedule("Player::mountItem("@%player@",Swarmer,"@$WeaponSlot@");",4);
}

function letmeshoot(%player)
{
	%player.dontFireLock = false;
}

function SwarmerImageA::onFire(%player,%slot)
{
	%client = Player::getClient(%player);
	%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),1500);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("SwarmRocketSeeking",%trans,%player,%vel,%client.target);
	echo(%client.target);
}

function SwarmerImageC::onFire(%player,%slot)
{
	%client = Player::getClient(%player);
	%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),1500);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("SwarmRocketSeeking",%trans,%player,%vel,%client.target);
	echo(%client.target);
}

function SwarmerImageB::onFire(%player,%slot)
{
	%client = Player::getClient(%player);
	%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),1500);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("SwarmRocketSeeking",%trans,%player,%vel,%client.target);
	echo(%client.target);
}

function SwarmerImageD::onFire(%player,%slot)
{
	%client = Player::getClient(%player);
	%trans = TFunc::ArtificialOffset(%player,GameBase::getMuzzleTransform(%player),1500);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("SwarmRocketSeeking",%trans,%player,%vel,%client.target);
	echo(%client.target);
}

ItemImageData SwarmerImageA
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.1 };

	weaponType = 0; // Single Shot
	ammoType = SwarmerAmmo;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 2.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData ExtraSwarmerA
{
	description = "Swarmer Extra Barrel";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = SwarmerImageA;
	price = 0;
	showWeaponBar = true;
};

ItemImageData SwarmerImageB
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { -0.1, 0, 0 };

	weaponType = 0; // Single Shot
	ammoType = SwarmerAmmo;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 2.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData ExtraSwarmerB
{
	description = "Swarmer Extra Barrel";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = SwarmerImageB;
	price = 0;
	showWeaponBar = true;
};

ItemImageData SwarmerImageC
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { -0.1, 0, -0.1 };

	weaponType = 0; // Single Shot
	ammoType = SwarmerAmmo;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 2.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData ExtraSwarmerC
{
	description = "Swarmer Extra Barrel";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = SwarmerImageC;
	price = 0;
	showWeaponBar = true;
};

ItemImageData SwarmerImageD
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SwarmerAmmo;
	accuFire = false;
	reloadTime = 1.5;
	fireTime = 2.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData ExtraSwarmerD
{
	description = "Swarmer Extra Barrel";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = SwarmerImageD;
	price = 0;
	showWeaponBar = false;
};

// Shockwave Missile Launcher
ItemData SMLAmmo
{
	description = "Shockwave Missile";
	className = "Ammo";
	shapeFile = "mineammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 12;
};

ItemImageData SMLImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SMLAmmo;
	projectileType = ShockMissile;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0.8;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData SML
{
	description = "Shockwave Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = "dSpecial Weapons";
	shadowDetailMask = 4;
	imageType = SMLImage;
	price = 670;
	showWeaponBar = true;
};

function SML::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help:  This gun shoots missles that push the target out away from the explosion, which may disrupt snipers long enough to allow you to place a turret or even get into the base");
}

//Pestilence Gas Mortar
ItemData GasAmmo
{
	description = "ZX-2 Shell";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData GasMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GasAmmo;
	projectileType = GasShell;
	accuFire = false;
	reloadTime = 0.8;
	fireTime = 2.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData GasMortar
{
	description = "Pestilence Gas Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "dSpecialWeapons";
	shadowDetailMask = 4;
	imageType = GasMortarImage;
	price = 575;
	showWeaponBar = true;
};

function GasMortar::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: The pestilence is one of the most feared weapons on the field. Once its ZX-2 neurotoxin settles in, they wont live much longer. Shielded targets are immune.");
}

// Energon Cannon
ItemImageData EnGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.05, -0.05, 0 };

	weaponType = 0;  // Single Shot
	minEnergy = 5;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
	lightType = 3;  // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0.25, 0.25, 0.85 };

	sfxReload = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
	sfxFire = SoundPlasmaTurretFire;
};

ItemData EnGun
{
   description = "Energon Cannon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   className = "Tool";
   heading = "dSpecialWeapons";
   shadowDetailMask = 4;
   imageType = EnGunImage;
	showWeaponBar = true;
   price = 650;
};

function EnGun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help: This gun fires high-energy bolts. You can either pick single fire or you can release all your energy in a giant 'Nova' of energy.");
}

function EnGunImage::onFire(%player,%slot)
{
	%client = Player::getClient(%player);
	%olden = GameBase::getEnergy(%player);
	if(%client.Energunmode == "Nova")
	{
		%rawCharge = GameBase::getEnergy(%player);
		%charge = %rawCharge *= 0.6;
		for(%i=1; %i<%charge; %i++)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("NovaBurst",%trans,%player,%vel);
			%cost = GameBase::getEnergy(%player);
		}
	}
	else if(%olden > 9)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("EnGunBlast",%trans,%player,%vel);
		%cost = 9;
	}
	%newen = %olden - %cost;
	GameBase::setEnergy(%player,%newen);
	
}

// Thunderbolt
ItemImageData ThunderboltImage
{
	shapeFile = "mortarpack";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };

	weaponType = 0;  // Single Shot
	projectileType = thunderZap;
	minEnergy = 15;
	maxEnergy = 25;  // Energy used/sec for sustained weapons
	reloadTime = 0.09;
                        
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };

	sfxReload = SoundDryFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundThunderIdle;
	sfxFire = SoundPlasmaTurretFire;
};

ItemData Thunderbolt
{
   description = "Thunderbolt";
	shapeFile = "mortarpack";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "dSpecial Weapons";
   shadowDetailMask = 4;
   imageType = ThunderboltImage;
	showWeaponBar = true;
   price = 450;
};

function Thunderbolt::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help:  If Energons become a problem, this is all you need. Although it does only small amount of damage, it overloads them and they have no energy for ten seconds sice the last hit. Each hit will refresh the time.");
}

//Blast Rifle a.k.a BOOM STICK!!!
ItemData BlastAmmo
{
	description = "BlastRifle Charge";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData BlastRifleImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // Single shot
	reloadTime = 0.2;
	fireTime = 1.3;

	ammoType = BlastAmmo;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 7;
	lightTime = 2;
	lightColor = { 1, 0.6, 0.6 };

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BlastRifle
{
	description = "Blast Rifle";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	heading = "cAssault-Class Weapons";
	shadowDetailMask = 4;
	imageType = BlastRifleImage;
	price = 950;
	showWeaponBar = true;
};

function BlastRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	Bottomprint(%client, "TalonRules Help:  The Blast Rifle shoots off a burst of charged energy that relies on a recharging power source. When fired, it will drain the source (Fires 1 bullet for every 5 charge) and begin to regenerate the source. So before firing, you may want to let it charge up.");
}

function BlastRifleImage::onFire(%player,%slot)
{
	%rawCharge = Player::getItemCount(%player,BlastAmmo);
	%charge = %rawCharge *= 0.2;
	if(%charge > 0)
	{
		for(%i=1; %i<%charge; %i++)
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("BlastShell",%trans,%player,%vel);
		}
		Player::setItemCount(%player,BlastAmmo,0);
		if(%player.BlastRifleRecharging != True)
		{
			%player.BlastRifleRecharging = True;
			%guntype = BlastRifle;
			schedule("RechargeAmmo(" @ %player @ ", " @ %guntype @ ");",0.25,%player);
		}
	}
		else Client::sendMessage(Player::getClient(%player),0,"Blast Rifle is out of ammo.");
}

//Disarmer weapon
ItemImageData DisarmerImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = DsrmMortar;
	accuFire = false;
	minEnergy = 6;
	maxEnergy = 10;
	reloadTime = 2.8;
	fireTime = 0.8;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Disarmer
{
	description = "Disarmer Cannon";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "plasma";
   heading = "dSpecial Weapons";
	shadowDetailMask = 4;
	imageType = DisarmerImage;
	price = 200;
	showWeaponBar = true;
};

function Disarmer::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: The Disarmer Cannon makes people drop thier weapon when it hits them. It takes up no ammo and has a large blast radius.");
}

// Cerebral Bore
ItemData BoreAmmo
{
	description = "Cerebral Bore";
	className = "Ammo";
	shapeFile = "mineammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData BoreGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = BoreAmmo;
	accuFire = true;
	reloadTime = 5.0;
	fireTime = 0.8;
	projectileType = BoreUngd;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundBoreGunActivate;
	sfxReady = SoundBoreGunIdle;
	sfxReload = SoundBoreGunDeActivate;
};

ItemData BoreGun
{
	description = "Cerebral Bore Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = "dSpecial Weapons";
	shadowDetailMask = 4;
	imageType = BoreGunImage;
	price = 950;
	showWeaponBar = true;
};

function BoreGun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      	bottomprint(%client, "TalonRules Help:  This gun shoots a single Cerebral Bore that is encased in a shell. When it hits, the tiny pod bores into thier armor and begins electrocuting thier brain. And if you hit an Energon, the bore can tap into thier self-destruct mechanism and set it off.");
}

// HealRifle
ItemImageData HealRifleImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = HealLaser;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire = SoundHealRifleFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HealRifle
{
   description = "Engineer Heal Gun";
   shapeFile = "repairgun";
   hudIcon = "sniper";
   className = "Tool";
   heading = "dSpecialWeapons";
   shadowDetailMask = 4;
   imageType = HealRifleImage;
   showWeaponBar = true;
   price = 45;
};

function HealRifle::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "TalonRules Help:  This useful gun shoots a repairing laser that can repair any object from very far away. Also, it takes up no room in your inventory, so you can still carry three weapons along with this and a targeting laser.");
}

// End of my guns.
//----------------------------------------------------------------------------

//----------------------------------------------\
// My mod's ^ functions : -=TalonHawk=- 		|->
//----------------------------------------------/

function Player::getTotalGrenades(%client)
{
	return (Player::getItemCount(%client,BasicGrenadeIcon) + Player::getItemCount(%client,ShockwaveGrenadeIcon) + Player::getItemCount(%client,DistortionGrenadeIcon) + Player::getItemCount(%client,MineGrenadeIcon) + Player::getItemCount(%client,IncendiaryGrenadeIcon) + Player::getItemCount(%client,HeavyGrenadeIcon) + Player::getItemCount(%client,TripGrenadeIcon) + Player::getItemCount(%client,EnergyGrenadeIcon) + Player::getItemCount(%client,NuclearGrenadeIcon));
}

function Player::getTotalBeacons(%client)
{
	return (Player::getItemCount(%client,HeavyBeaconIcon) + Player::getItemCount(%client,TempFFBeaconIcon) + Player::getItemCount(%client,ECMBeaconIcon) + Player::getItemCount(%client,PlastiqueBeaconIcon) + Player::getItemCount(%client,HackingIcon) + Player::getItemCount(%client,SpRocketBoostIcon) + Player::getItemCount(%client,NanokitBeaconIcon) + Player::getItemCount(%client,AmmoRechargeIcon) + Player::getItemCount(%client,EnergyBoostIcon));
}

function TalonJump(%player,%vel,%vec)
{
	%rotation = GameBase::getRotation(%player);
	%jump = Vector::getFromRot(GameBase::getRotation(%player),%vel,%vec);
	Player::applyImpulse(%player,%jump);
}

function NormalizeEnergy(%player)
{
	%newrate = GameBase::getRechargeRate(%player) - 28;
	GameBase::setRechargeRate(%player,%newrate);
	%clientId = Player::getclient(%player);
	Client::sendMessage(%clientId,2,"Reactor has returned to normal.");
	GameBase::startFadeOut(%player);
	schedule("GameBase::startFadeIn(" @ %player @ ");",1,%player);
	%player.overdrive = 0;
}

function RechargeAmmo(%player,%gunType)
{
	echo(%player @" requests RechargeAmmo to be run");
	%armor = Player::GetArmor(%player);

	if(%gunType == BlastRifle && (Player::getItemCount(%player,BlastRifle) > 0))
	{
		if(Player::getItemCount(%player,BlastAmmo) < $ItemMax[%armor,BlastAmmo])
		{
			echo("raising blast ammo count for player "@ %player);
			Player::incItemCount(%player,BlastAmmo,1);
			schedule("RechargeAmmo(" @ %player @ ", " @ %gunType @ ");",0.25,%player);
		}
		else
			%player.BlastRifleRecharging = False;
	}
	else if(%gunType == PlasmaGun && (Player::getItemCount(%player,PlasmaGun) > 0))
	{
		%max = $ItemMax[%armor,PlasmaAmmo];
		if(Player::getMountedItem(%player,$BackpackSlot) == AmmoPack)
			%max += $AmmoPackMax[PlasmaAmmo];

		if(Player::getItemCount(%player,PlasmaAmmo) < %max)
		{
			echo("raising plasma ammo count for player "@ %player);
			Player::incItemCount(%player,PlasmaAmmo,1);
			schedule("RechargeAmmo(" @ %player @ ", " @ %gunType @ ");",1,%player);
		}
		else
			%player.PlasmaGunRecharging = False;
	}
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
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
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
   heading = "hStations";
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
   heading = "hStations";
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

	minEnergy = -3;
 	maxEnergy = -5;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
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
	description = "Heavy Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "fBackpacks";
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
   heading = "fBackpacks";
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
   heading = "fBackpacks";
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
   heading = "iDeployables";
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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
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
					if(%client.nanodone == 1)
						%client.nanodone = 0;
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
   heading = "fBackpacks";
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
	if($matchStarted)
	{
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 19 ; %i = %i +1)
		{
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum)
			{
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
			else if(%i == 7) {
	 	    	%item.AssaultAmmo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.SniperAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.RPGAmmo = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.NMLAmmo = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.SMLAmmo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.FlameMortarAmmo = %numPack;
			}
			else if(%i == 13) {
	 	    	%item.SwarmerAmmo = %numPack;
			}
			else if(%i == 14) {
	 	    	%item.EMPAmmo = %numPack;
			}
			else if(%i == 15) {
	 	    	%item.ReasonAmmo = %numPack;
			}
			else if(%i == 16) {
	 	    	%item.BlastAmmo = %numPack;
			}
			else if(%i == 21) {
	 	    	%item.SuperGaussAmmo = %numPack;
			}
			else
			{
	 	    		%item.SmokeGrenadeAmmo = %numPack;
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
	for(%i = 0; %i < 19 ; %i = %i +1) {
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
		else if(%i == 4)
		{
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 5)
		{
 	    	%numAdd = %item.MortarAmmo;
		}
		else if(%i == 6)
		{
 	    	%numAdd = %item.MineAmmo;
		}
		else if(%i == 7)
		{
 	    	%numAdd = %item.AssaultAmmo;
		}
		else if(%i == 8)
		{
 	    	%numAdd = %item.SniperAmmo;
		}
		else if(%i == 9)
		{
 	    	%numAdd = %item.RPGAmmo;
		}
		else if(%i == 10)
		{
 	    	%numAdd = %item.NMLAmmo;
		}
		else if(%i == 11)
		{
 	    	%numAdd = %item.SMLAmmo;
		}
		else if(%i == 12)
		{
 	    	%numAdd = %item.FlameMortarAmmo;
		}
		else if(%i == 13)
		{
 	    	%numAdd = %item.SwarmerAmmo;
		}
		else if(%i == 14)
		{
 	    	%numAdd = %item.EMPAmmo;
		}
		else if(%i == 15)
		{
 	    	%item.ReasonAmmo = %numPack;
		}
		else if(%i == 16)
		{
 	    	%item.BlastAmmo = %numPack;
		}
		else if(%i == 21)
		{
 	    	%item.SuperGaussAmmo = %numPack;
		}
		else
		{
		%numAdd = %item.SmokeGrenadeAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 19 ; %i = %i +1) {
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
   heading = "iDeployables";
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
   heading = "iDeployables";
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
   heading = "iDeployables";
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
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
					if(%client.nanodone == 1)
						%client.nanodone = 0;
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
	description = "Hanging Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "iDeployables";
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
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "StaticShape") {
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
					%htur = newObject("remoteturret","Turret",DeployableTurret,true);
			   	      addToSet("MissionCleanup", %htur);
					GameBase::setTeam(%htur,GameBase::getTeam(%player));
					GameBase::setRotation(%htur,%rot);
					GameBase::setPosition(%htur,$los::position);
					Gamebase::setMapName(%htur,"RMT Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Hanging Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%htur) @ "TurretPack"]++;
					echo("MSG: ",%client," deployed a Hanging Turret");
					if(%client.nanodone == 1)
						%client.nanodone = 0;
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on buildings, terrain, or deployed objects");
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
						if(%client.nanodone == 1)
							%client.nanodone = 0;
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

//Station Listings:
$InvList[JumpPack] = 1;
$InvList[ReasonPack] = 1;
$InvList[NukeShieldPack] = 1;
$InvList[TargetPack] = 1;
$InvList[PlasWallPack] = 1;
$InvList[BunkerPack] = 1;
$InvList[ForceWallPack] = 1;
$InvList[MassWallPack] = 1;
$InvList[StingerPack] = 1;
$InvList[Laptop] = 1;
$InvList[DTreePack] = 1;
$InvList[NukePack] = 1;
$InvList[C4Pack] = 1;
$InvList[LaserTurretPack] = 1;
$InvList[NMLPack] = 1;
$InvList[NukePlatformPack] = 1;
$InvList[GasMinePack] = 1;
$InvList[TeleporterPack] = 1;
$InvList[NanoBasePack] = 1;
$InvList[DecoyPack] = 1;
$InvList[PlasmaTurretPack] = 1;
$InvList[ChainTurretPack] = 1;
$InvList[ShellTurretPack] = 1;
$InvList[NegPack] = 1;
$InvList[HDecoyPack] = 1;
$InvList[ASensorPack] = 1;
$InvList[RunePack] = 1;
$InvList[ALaserPack] = 1;
$InvList[NanoPack] = 1;
$InvList[MiniPlanePack] = 1;
$InvList[Detonator] = 1;
$InvList[AFIDPack] = 1;

$RemoteInvList[JumpPack] = 1;
$RemoteInvList[ReasonPack] = 1;
$RemoteInvList[NukeShieldPack] = 1;
$RemoteInvList[TargetPack] = 1;
$RemoteInvList[PlasWallPack] = 1;
$RemoteInvList[StingerPack] = 1;
$RemoteInvList[BunkerPack] = 1;
$RemoteInvList[ForceWallPack] = 1;
$RemoteInvList[Laptop] = 1;
$RemoteInvList[MassWallPack] = 1;
$RemoteInvList[DTreePack] = 1;
$RemoteInvList[C4Pack] = 1;
$RemoteInvList[LaserTurretPack] = 1;
$RemoteInvList[NukePack] = 1;
$RemoteInvList[NMLPack] = 1;
$RemoteInvList[NukePlatformPack] = 1;
$RemoteInvList[GasMinePack] = 1;
$RemoteInvList[TeleporterPack] = 1;
$RemoteInvList[DecoyPack] = 1;
$RemoteInvList[PlasmaTurretPack] = 1;
$RemoteInvList[ChainTurretPack] = 1;
$RemoteInvList[ShellTurretPack] = 1;
$RemoteInvList[NegPack] = 1;
$RemoteInvList[HDecoyPack] = 1;
$RemoteInvList[ASensorPack] = 1;
$RemoteInvList[RunePack] = 1;
$RemoteInvList[ALaserPack] = 1;
$RemoteInvList[NanoPack] = 1;
$RemoteInvList[Detonator] = 1;
//Item maxes
$TeamItemMax[PlasWallPack] = 90;
$TeamItemMax[ForceWallPack] = 15;
$TeamItemMax[MassWallPack] = 5;
$TeamItemMax[PlasmaTurretPack] = 4;
$TeamItemMax[ChainTurretPack] = 5;
$TeamItemMax[LaserTurretPack] = 15;
$TeamItemMax[StingerPack] = 1;
$TeamItemMax[ShellTurretPack] = 1;
$TeamItemMax[TeleporterPack] = 2;
$TeamItemMax[NanoBasePack] = 2;
$TeamItemMax[ASensorPack] = 1;
$TeamItemMax[RunePack] = 1;
$TeamItemMax[ALaserPack] = 1;

//Items:
ItemImageData MiniPlanePackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniPlanePack
{
	description = "Gargoyle MiniPlane";
	shapeFile = "invent_remote";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = MiniPlanePackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function MiniPlanePack::onUse(%player,%item)
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

function MiniPlanePack::onDeploy(%player,%item,%pos)
{
	if (MiniPlanePack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function MiniPlanePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%newpos = Vector::add(GameBase::getPosition(%player), "3 0 0");
	if(GameBase::testPosition(%player,%newpos))
	{
		%mini = newObject("staff",Flier,Cinni,true);
		addToSet("MissionCleanup", %mini);
		%rot = GameBase::getRotation(%player); 
		GameBase::setTeam(%mini,GameBase::getTeam(%player));
		GameBase::setPosition(%mini,%newpos);
		GameBase::setRotation(%mini,%rot);
		GameBase::setMapName(%mini,"Gargoyle MiniShip");
		Client::sendMessage(%client,0,"***MiniPlane Launched*** - Establishing Link-Up");
		playSound(SoundTeleportDailup,%newpos);
		echo("MSG: ",%client," deployed a Mini-Plane");
		%client.oldBody = %player;
		Client::setControlObject(%client,%mini);
		GameBase::startFadeIn(%mini);
		return true;
	}
}

//Items:

// The AFID packs
ItemImageData AFIDPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mass = 2.5;
	firstPerson = false;
};

ItemData AFIDPack
{
	description = "AFID";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = AFIDPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function AFIDPack::onUse(%player,%item)
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

function AFIDPack::onDeploy(%player,%item,%pos)
{
	if(AFIDPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function AFIDPack::deployShape(%player,%item)
{

	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3))
	{
		%newpos = Vector::add($los::position, "0 0 3");
		if($TeamItemCount[GameBase::getTeam(%player) @ "AFID"] < 4)
		{
			%mini = newObject("ammounit_remote",Flier,Afid,true);
			addToSet("MissionCleanup", %mini);
			%rot = GameBase::getRotation(%player); 
			GameBase::setTeam(%mini,GameBase::getTeam(%player));
			GameBase::setPosition(%mini,%newpos);
			GameBase::setRotation(%mini,%rot);
			GameBase::setMapName(%mini,"AFID-"@ CLient::getName(%client));
			Client::sendMessage(%client,2,"AFID-OBC: Launched and awaiting command.");
			playSound(SoundTeleportDailup,%newpos);
			echo("MSG: ",%client," deployed an AFID");
			GameBase::startFadeIn(%mini);
			$TeamItemCount[GameBase::getTeam(%player) @ "AFID"]++;
			return true;
		}
		else
			Client::sendMessage(%client,0,"Frequency overload - Too many AFIDs deployed.");
	}
	else
		Client::sendMessage(%client,0,"Launch position out of range.");
	return false;
}

// Nuclear Shield
ItemImageData NukeShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 10;
	maxEnergy = 19;   // Energy/sec for sustained weapons
	sfxFire = SoundELFFire;
	firstPerson = false;
};

ItemData NukeShieldPack
{
	description = "Nuclear Shield";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = NukeShieldPackImage;
	price = 375;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NukeShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"NUCLEAR SHIELD ONLINE");
	%player.NukeShieldStrength = 1;
}

function NukeShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),1,"NUCLEAR SHIELD OFFLINE");
	Player::trigger(%player,$BackpackSlot,false);
	%player.NukeShieldStrength = 0;
}

// The Super Jump Pack
// The gun part
ItemImageData JumpGunImage
{
	shapeFile = "smoke";
	mountPoint = 0;

	weaponType = 0; // Sustained
	mountOffset = { 0, 0, -50 };
	mountRotation = { 0, 0, 0 };
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 0.0;

	sfxFire     = bigExplosion1;
	sfxActivate = SoundSwarmAcquire;
};

function JumpGunImage::onFire(%player, %slot)
{
	%client = Player::getclient(%player);

	%vel = $OOPVel[%client];
	%vec = $OOPVec[%client];
	
	%rot = GameBase::getRotation(%player);
	%jump = Vector::getFromRot(%rot,%vel,%vec);
	Player::applyImpulse(%player,%jump);
	GameBase::setEnergy(%player,0);
	JumpGunEmitFire(%player,0,Large);
	JumpGunEmitFire(%player,-3,Large);
	JumpGunEmitFire(%player,-5,Large);

	schedule("JumpGunEmitFire(" @ %player @ ",0,Large);",0.5,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-3,Large);",0.75,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",1.0,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",-3,Large);",1.25,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",1.5,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",1.75,%player);
	schedule("JumpGunEmitFire(" @ %player @ ",0,Small);",2.0,%player);
}

ItemData JumpGun
{
	description = "Jump Shot";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = JumpGunImage;
	showInventory = false;
	price = 125;
};

function JumpGun::onMount(%player,%imageSlot)
{
	%client = Player::getclient(%player);

	if($OOPVel[%client] == "")
		$OOPVel[%client] = 400;
	if($OOPVec[%client] == "")
		$OOPVec[%client] = 900;

      Bottomprint(%client, "<jc><f3>Jump pack activated - Fire to initiate burst");
}

function JumpGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

// The pack part of the Jump pack
ItemImageData JumpPackImage
{
	shapeFile = "mortargun";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 5, 0, 3 };
	firstPerson = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 15;
	lightTime = 2;
	lightColor = { 1, 1, 0.2 };
};

ItemData JumpPack
{
	description = "Orbital Insertion Pack";
	shapeFile = "mortargun";
	className = "Backpack";
      heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = JumpPackImage;
	price = 475;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JumpPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == JumpGun)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function JumpPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::trigger(%player,$BackpackSlot,true);
		Player::mountItem(%player,JumpGun,$WeaponSlot);
	}
}

function JumpPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == JumpGun)
		{
			Player::unmountItem(%player,$WeaponSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}

//Command Laptop
ItemImageData LaptopImage
{
	shapeFile = "ammounit_remote";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
	mass = 0.5;
};

ItemData Laptop
{
	description = "Command Control Pack";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = LaptopImage;
	price = 350;
	hudIcon = "sensorjamerpack";
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
	Client::sendMessage(%shooterClient,0,"Connecting Control Pack");
}

function Laptop::onUnmount(%player,%item)
{
	Client::sendMessage(%shooterClient,0,"Disconnecting Control Pack");
}


//Plastic Explosive Pack
ItemImageData C4PackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData C4Pack
{
	description = "Antimatter Explosive";
	shapeFile = "camera";
	className = "Backpack";
   heading = "iDeployables";
	imageType = C4PackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 980;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function C4Pack::onUse(%player,%item)
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

function C4Pack::onDeploy(%player,%item,%pos)
{
	if (C4Pack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}


function C4Pack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3))
	{
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape")
		{
	    		%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
			%num = CountObjects(%set,"PlasticExplosive",%num);
			deleteObject(%set);
			if(0 == %num)
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 
						%plastic = newObject("","StaticShape",AntimatterBomb,true);
						// Quick check to manage the groups the bombs go in
							%checkset = nameToID("MissionCleanup/Bombs");
							if(%checkset == -1)
							{
								newObject("Bombs",SimSet);
								addToSet("MissionCleanup","Bombs");
							}
							addToSet("MissionCleanup/Bombs", %plastic);
							addToSet("MissionCleanup", %plastic);
						GameBase::setTeam(%plastic,GameBase::getTeam(%player));
						GameBase::setPosition(%plastic,$los::position);
						GameBase::setRotation(%plastic,%rot);
						Gamebase::setMapName(%plastic,"Plastic Explosive " @ Client::getName(%client));
						GameBase::startFadeIn(%plastic);
						bottomprint(%client,"<f2>Antimatter Bomb deployed! <f5>Use a detonator to activate the charge.");
						%client.plastic = Yes;
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a Plastic Explosive");
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} 
			else
				Client::sendMessage(%client,0,"Connection Scrambling - Too close to other explosives");
		}
		else 
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
	}
	else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}

// The gun part
ItemImageData DetonatorImage
{
	shapeFile = "smoke";
	mountPoint = 0;

	weaponType = 0; // Sustained
	mountOffset = { 0, 0, -10 };
	mountRotation = { 0, 0, 0 };
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 0.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundSwarmAcquire;
};

function DetonatorImage::onFire(%player, %slot)
{
	%client = Player::getclient(%player);
	if($BombFocus[%client] != -1)
	{
		%bomb = $BombFocus[%client];
		%pos = GameBase::getPosition(%bomb);

		THNuke::Mushroom(%pos,%client);
		calcOwnedRadiusDamage(%bomb,$ShrapnelDamageType,20.5,1.9,5,20,5,999,0.1,30,1,%client);
		GameBase::applyDamage(%bomb,$DebrisDamageType,8,%pos,"0 0 0","0 0 0",%bomb);
	      Bottomprint(%client, "<jc><f2>AME Detonation Sucsessful.");
	}
 }

ItemData Detonator
{
	description = "AME Detonator";
	shapeFile = "repairgun";
	className = "Tool";
	shadowDetailMask = 4;
	imageType = DetonatorImage;
	heading = "cSpecialWeapons";
	showInventory = True;
	showWeaponBar = False;
	price = 25;
};

function Detonator::onMount(%player,%imageSlot)
{
	%client = Player::getclient(%player);
	%cl = GameBase::getOwnerClient(%player);
	%set = nameToID("MissionCleanup/Bombs");
	for(%i = 0; (%bomb = Group::getObject(%set, %i)) != -1; %i++)
	{
		%bteam = GameBase::getTeam(%bomb);
		%pteam = GameBase::getTeam(%player);
		if(%pteam == %bteam)
		{
			Observer::setOrbitObject(%cl, %bomb, 15, 15, 5);
		      Bottomprint(%client, "<jc><f2>Link established with AME.");
			playSound(SoundPlasticDailUp,GameBase::getPosition(%player));
			if(%bomb != %player)
				$BombFocus[%client] = %bomb;
		}
		else
		      Bottomprint(%client, "<jc><f3>Unable to establish link-up with charge.");
	}
}

function Detonator::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//Something Heavy - weigh down when your armor is powered down by the EMP
ItemImageData WeightImage
{
	shapeFile = "tracer";
	mountPoint = 5;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundEnergyPackOn;
  	mountOffset = { 0, 0, 30 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.75;
};

ItemData Weight
{
	description = "something heavy";
	shapeFile = "sensorjampack";
	className = "Specialty";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = WeightImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = false;
	showInventory = false;
	hiliteOnActive = false;
};

function Weight::onUse(%player,%item)
{ }

function WeightImage::onActivate(%player,%imageSlot)
{ }

function WeightImage::onDeactivate(%player,%imageSlot)
{ }

//NML Support Pack
ItemImageData NMLPackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { -1, 0, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
	mass = 1.0;
};

ItemData NMLPack
{
	description = "Heavy Weapons Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
   heading = "eApocalyptic Weapons";
	shadowDetailMask = 4;
	imageType = NMLPackImage;
	price = 450;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NMLPack::onUse(%player,%item)
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

function NMLPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == NML)
		Player::unmountItem(%player,$WeaponSlot);
}

function NMLPack::onDeploy(%player,%item,%pos)
{
	NMLPack::deployShape(%player,%item);
}

function NMLPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%ppos = GameBase::getPosition(%player);
	if(%player.NukeDeployMode == true)
	{
		bottomprint(%client,"<f2><c>HWP-CPU:<f1> Undeployment in 5 seconds");
		schedule("HeavyDeploy::Nuke("@ %player @",6);",5);
		return true;
	}
	else
	{
		if(GameBase::getLOSInfo(%player,20))
		{
			if (GameBase::getDataName($los::object) == HDeployPlatform)
			{
				%obj = $los::object;
				if(%obj.THHDMounter == "")
				{
					bottomprint(%client,"<f2><c>HWP-CPU:<f1> Deploying.....");
					playSound(SoundDoorClose,$los::position);
					%lospos = $los::position;
					$DeployPosition[%client] = GameBase::getPosition(%player);
					$DeployPlatform[%client] = $los::object;
					schedule("HeavyDeploy::Nuke("@ %player @",1);",1);
					return true;
				}
			}
			else 
				bottomprint(%client,"<f2><c>HWP-CPU:<f1>Can only deploy on heavy weapons pads");
		}
		else 
			bottomprint(%client,"<f2><c>HWP-CPU:<f1>Must aim straight down and stay still to deploy.");
	}
	return false;
}

function HeavyDeploy::Nuke(%player,%step)
{
	%client = Player::getClient(%player);
	%pos = $DeployPosition[%client];
	%newpos = GameBase::getPosition(%player);
	%plat = $DeployPlatform[%client];
	if(%step == 1)
	{
		if(%newpos == %pos)
		{
			bottomprint(%client,"<f2><c>HWP-CPU:<f1> Deploying....");
			%marker = newObject("","StaticShape",HDeployBeacon,true);
			%newpos = %plat.beaconspotA;
			GameBase::setPosition(%marker,%newpos);
			addToSet("MissionCleanup", %marker);
			%player.markerA = %marker;
			schedule("HeavyDeploy::Nuke("@ %player @",2);",1);
		}
		else
		{
			bottomprint(%client,"<c><f2>HWP-CPU:<f0> You moved! Aborting.");
			%plat.THHDMounter = "";
		}
	}
	if(%step == 2)
	{
		if(%newpos == %pos)
		{
			bottomprint(%client,"<f2><c>HWP-CPU:<f1> Deploying...");
			%marker = newObject("","StaticShape",HDeployBeacon,true);
			%newpos = %plat.beaconspotB;
			GameBase::setPosition(%marker,%newpos);
			addToSet("MissionCleanup", %marker);
			%player.markerB = %marker;
			schedule("HeavyDeploy::Nuke("@ %player @",3);",1);
		}
		else
		{
			bottomprint(%client,"<c><f2>HWP-CPU:<f0> You moved! Aborting.");
			%plat.THHDMounter = "";
			deleteObject(%player.markerA);
		}
	}
	if(%step == 3)
	{
		if(%newpos == %pos)
		{
			bottomprint(%client,"<f2><c>HWP-CPU:<f1> Deploying..");
			%marker = newObject("","StaticShape",HDeployBeacon,true);
			%newpos = %plat.beaconspotC;
			GameBase::setPosition(%marker,%newpos);
			addToSet("MissionCleanup", %marker);
			%player.markerC = %marker;
			schedule("HeavyDeploy::Nuke("@ %player @",4);",1);
		}
		else
		{
			bottomprint(%client,"<c><f2>HWP-CPU:<f0> You moved! Aborting.");
			%plat.THHDMounter = "";
			deleteObject(%player.markerA);
			deleteObject(%player.markerB);
		}
	}
	if(%step == 4)
	{
		if(%newpos == %pos)
		{
			bottomprint(%client,"<f2><c>HWP-CPU:<f1> Deploying.");
			%marker = newObject("","StaticShape",HDeployBeacon,true);
			%newpos = %plat.beaconspotD;
			GameBase::setPosition(%marker,%newpos);
			addToSet("MissionCleanup", %marker);
			%player.markerD = %marker;
			schedule("HeavyDeploy::Nuke("@ %player @",5);",1);
		}
		else
		{
			bottomprint(%client,"<c><f2>HWP-CPU:<f0> You moved! Aborting.");
			%plat.THHDMounter = "";
			deleteObject(%player.markerA);
			deleteObject(%player.markerB);
			deleteObject(%player.markerC);
		}
	}
	if(%step == 5)
	{
		if(%newpos == %pos)
		{
			if(Player::getItemCount(%player,Pheonix) == 1 && Player::getItemCount(%player,NML) == 0)
			{
				%wep = "Pheonix";
				%twep = Pheonix;
			}
			else if(Player::getItemCount(%player,Pheonix) == 0 && Player::getItemCount(%player,NML) == 1)
			{
				%wep = "Doomsday NML";
				%twep = NML;
			}
			bottomprint(%client,"<f2><c>HWP-CPU:<f1> Deployment complete - Arming "@ %wep @" in 2 secs*");
			Player::setArmor(%player,"tdeployedarmor");
			%player.NukeDeployMode = true;
			%player.AttachedPad = %plat;
			%plat.THHDMounter = %player;
			Player::unmountItem(%player, $WeaponSlot);
			schedule("Player::mountItem("@ %player @","@ %twep @",$WeaponSlot);",2);
			GameBase::setPosition(%player,GameBase::getPosition(%plat));
		}
		else
		{
			bottomprint(%client,"<c><f2>HWP-CPU:<f0> You moved! Aborting.");
			%plat.THHDMounter = "";
			deleteObject(%player.markerA);
			deleteObject(%player.markerB);
			deleteObject(%player.markerC);
			deleteObject(%player.markerD);
		}
	}
	if(%step == 6)
	{
		bottomprint(%client,"<f2><c>HWP-CPU:<f1> You are now undeployed");
		deleteObject(%player.markerA);
		deleteObject(%player.markerB);
		deleteObject(%player.markerC);
		deleteObject(%player.markerD);
		Player::setArmor(%player,"tarmor");
		%player.NukeDeployMode = false;
		%player.AttachedPad = "";
		%plat.THHDMounter = "";
		Player::unmountItem(%player, $WeaponSlot);
	}
}

ItemImageData NukePlatformPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData NukePlatformPack
{
	description = "Heavy Weapons Pad";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "eApocalyptic Weapons";
	imageType = NukePlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NukePlatformPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function NukePlatformPack::onDeploy(%player,%item,%pos)
{
	if (NukePlatformPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function NukePlatformPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if(!$NukePlatOut[GameBase::getTeam(%player)])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%fWall= newObject("","StaticShape",HDeployPlatform,true);
						addToSet("MissionCleanup", %fWall);
						GameBase::setTeam(%fWall,GameBase::getTeam(%player));
						GameBase::setPosition(%fWall,$los::position);
						GameBase::setRotation(%fWall,%rot);
						Gamebase::setMapName(%fWall,"Doomsday Launch Pad");
					      TeamMessages(3, GameBase::getTeam(%player), "**Heavy Weapons Pad Online at POS:"@ $los::position @"**");
						GameBase::startFadeIn(%fWall);
						%fWall.beaconspotA = Vector::Add(GameBase::getPosition(%fwall),"0.82 0.82 0");
						%fWall.beaconspotB = Vector::Add(GameBase::getPosition(%fwall),"0.82 -0.82 0");
						%fWall.beaconspotC = Vector::Add(GameBase::getPosition(%fwall),"-0.82 -0.82 0");
						%fWall.beaconspotD = Vector::Add(GameBase::getPosition(%fwall),"-0.82 0.82 0");
						playSound(SoundPickupBackpack,$los::position);
						$NukePlatOut[GameBase::getTeam(%player)] = true;
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings or objects.");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Only 1 nuke pad can be out at a time");

	return false;
}

//Negative mass pack
ItemImageData NegPackImage
{
	shapeFile = "grenammo";
	weaponType = 2;  // Sustained
	mass = -2.5;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mountRotation = { 0.9, 0, 0 };

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData NegPack
{
	description = "Negative Mass Pack";
	shapeFile = "grenammo";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = NegPackImage;
	price = 250;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NegPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function NegPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function NegPack::onUnmount(%player,%item)
{
//		Do nothing
}

// Bunker Pack
ItemImageData BunkerPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.25, 0 };
	mountRotation = { -3, 0, 0 };
	mass = 10.5;
	firstPerson = false;
};

ItemData BunkerPack
{
	description = "Deployable Bunker";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = "iDeployables";
	imageType = BunkerPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 2800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BunkerPack::onUse(%player,%item)
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

function BunkerPack::onDeploy(%player,%item,%pos)
{
	if (BunkerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BunkerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < 3)
	{
		if (GameBase::getLOSInfo(%player,7))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain")
			{
				if (Vector::dot($los::normal,"0 0 3") > 0.7)
				{
					if(largeDeployArea(%client,$los::position,6))
					{
						%rot = GameBase::getRotation(%player);
						%bunker = newObject("bunker", "InteriorShape", "ebunker.dis");
						addToSet("MissionCleanup", %bunker);
						GameBase::setTeam(%bunker,GameBase::getTeam(%player));
						GameBase::setPosition(%bunker,$los::position);
						GameBase::setRotation(%bunker,%rot);
						Gamebase::setMapName(%bunker,"Bunker");
					      TeamMessages(3, GameBase::getTeam(%player), "**Bunker Deployed at POS:"@ $los::position @"**");
						GameBase::startFadeIn(%bunker);
						playSound(SoundPickupBackpack,$los::position);
						playSound(SoundDoorClose,$los::position);
						playSound(shockExplosion,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "BunkerPack"]++;
						echo("MSG: ",%client," deployed a bunker.");
						%bunker.isBunker = 1;
						%bunker.bunkerTeam = GameBase::getTeam(%player);
						return true;
						}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
		Client::sendMessage(%client,0,"You can only have 3 bunkers!");

	return false;
}

// Aerial Sensor Deployable
ItemData ASensorPack
{
	description = "Aerial Spy Base";
	shapeFile = "radar_small";
	className = "Backpack";
	heading = "jAerialDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 0.4;
	elasticity = 0.2;
	price = 1250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ASensorPack::onMount(%player,%item,$BackpackSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: TO PROPERLY DEPLOY A SPY BASE: FLY UP TO THE HEIGHT YOU WANT TO DEPLOY IT AT, IT SHOULD DEPLOY RIGHT ABOVE YOUR HEAD..");
}

function ASensorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ASensorPack::onDeploy(%player,%item,%pos)
{
	if (ASensorPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ASensorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "ASensorPack"] == 0)
	{
			%playerPos = GameBase::getPosition(%player);
			%rot = GameBase::getRotation(%player);
			%newpos = Vector::add(GameBase::getPosition(%player), "0 0 2.8");
		//------------------------------------------------------------------
		//RADAR DISH									||
		//------------------------------------------------------------------
		%obj= newObject("","Sensor",ADish,true);
		addToSet("MissionCleanup", %obj);
		GameBase::setTeam(%obj,GameBase::getTeam(%player));
		GameBase::setPosition(%obj,%newpos);
		GameBase::setRotation(%obj,%rot);
		Gamebase::setMapName(%obj,"SpyBase Radar");
			//------------------------------------------------------------------
			//CAMERA NUMBER 1									||
			//------------------------------------------------------------------
			%objb = newObject("Camera","Turret",ACameraTurret,true);
			%urota = getword(%rot, 1) + 89;
			addToSet("MissionCleanup", %objb);
			GameBase::setTeam(%objb,GameBase::getTeam(%player));
			GameBase::setPosition(%objb,%newpos);
			GameBase::setRotation(%objb,%urota);
			Gamebase::setMapName(%objb,"SpyBase Camera #1");
		//------------------------------------------------------------------
		//CAMERA NUMBER 2									||
		//------------------------------------------------------------------
		%objc = newObject("Camera","Turret",ACameraTurret,true);
		%urotb = getword(%rot, 1) + 10;
		addToSet("MissionCleanup", %objc);
		GameBase::setTeam(%objc,GameBase::getTeam(%player));
		GameBase::setPosition(%objc,%newpos);
		GameBase::setRotation(%objc,%urotb);
		Gamebase::setMapName(%objc,"SpyBase Camera #2");
			//------------------------------------------------------------------
			//REST OF THE STUFF THAT NORMALLY HAPPENS					||
			//------------------------------------------------------------------
			Client::sendMessage(%client,3,"Aerial Spy Base Deployed");
			playSound(SoundPickupBackpack,$los::position);
			playSound(SoundDoorClose,%newpos);
			playSound(shockExplosion,%newpos);
			$TeamItemCount[GameBase::getTeam(%player) @ "ASensorPack"]++;
			echo("MSG: ",%client," deployed a spy base.");
			return true;
	}
	else																						  
		Client::sendMessage(%client,0,"You can only have 1 Spy Base!");
    return false;
}

// Aerial Laser Deployable
ItemData ALaserPack
{
	description = "Aerial Laser Base";
	shapeFile = "radar_small";
	className = "Backpack";
	heading = "jAerialDeployables";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 0.4;
	elasticity = 0.2;
	price = 1250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ALaserPack::onMount(%player,%item,$BackpackSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "TalonRules Help: TO PROPERLY DEPLOY A LASER BASE: FLY UP TO THE HEIGHT YOU WANT TO DEPLOY IT AT, IT SHOULD DEPLOY RIGHT ABOVE YOUR HEAD..");
}

function ALaserPack::onUse(%player,%item)
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

function ALaserPack::onDeploy(%player,%item,%pos)
{
	if (ALaserPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ALaserPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "ALaserPack"] == 0)
	{
		%playerPos = GameBase::getPosition(%player);
		%rot = GameBase::getRotation(%player);
		%newpos = Vector::add(GameBase::getPosition(%player), "0 0 2");
			//------------------------------------------------------------------
			//RADAR DISH									||
			//------------------------------------------------------------------
			%obj= newObject("","Sensor",LDish,true);
			addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			GameBase::setPosition(%obj,%newpos);
			GameBase::setRotation(%obj,%rot);
			Gamebase::setMapName(%obj,"Laser Base Radar");
		//------------------------------------------------------------------
		//LASER TURRET									||
		//------------------------------------------------------------------
		%objb = newObject("Camera","Turret",ALaserTurret,true);
		%urota = getword(%rot, 1) + 89;
		addToSet("MissionCleanup", %objb);
		GameBase::setTeam(%objb,GameBase::getTeam(%player));
		GameBase::setPosition(%objb,%newpos);
		GameBase::setRotation(%objb,%urota);
		Gamebase::setMapName(%objb,"Laser Base Sniper");
			//------------------------------------------------------------------
			//SCRAPER LASER	 #1								||
			//------------------------------------------------------------------
			%objc = newObject("Camera","Turret",ATLaser,true);
			%rotb = getword(%rot, 0) + 10;
			%urotb = getword(%rotb, 1) + 10;
			addToSet("MissionCleanup", %objc);
			GameBase::setTeam(%objc,GameBase::getTeam(%player));
			GameBase::setPosition(%objc,%newpos);
			GameBase::setRotation(%objc,%urotb);
			Gamebase::setMapName(%objc,"Laser Base SkyScraper #1");
		//------------------------------------------------------------------
		//SCRAPER LASER	#2								||
		//------------------------------------------------------------------
		%objc = newObject("Camera","Turret",ATLaser,true);
		%rotb = getword(%rot, 0) + 20;
		%urotb = getword(%rotb, 1) + 15;
		addToSet("MissionCleanup", %objc);
		GameBase::setTeam(%objc,GameBase::getTeam(%player));
		GameBase::setPosition(%objc,%newpos);
		GameBase::setRotation(%objc,%urotb);
		Gamebase::setMapName(%objc,"Laser Base SkyScraper #2");
			//------------------------------------------------------------------
			//ALL OF THE OTHER STUFF...							||
			//------------------------------------------------------------------
			Client::sendMessage(%client,3,"Aerial Laser Base Deployed");
			playSound(SoundPickupBackpack,%newpos);
			playSound(SoundDoorClose,%newpos);
			playSound(shockExplosion,%newpos);
			$TeamItemCount[GameBase::getTeam(%player) @ "ALaserPack"]++;
			echo("MSG: ",%client," deployed a spy base.");
			return true;
	}
	else																						  
		Client::sendMessage(%client,0,"You can only have 1 Laser Base!");
    return false;
}

//Deployable Plasma Turret
ItemImageData PTurretPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.5;
	firstPerson = false;
};

ItemData PlasmaTurretPack
{
	description = "Plasma Turret";
	shapeFile = "magcargo";
	className = "Backpack";
   heading = "iDeployables";
	imageType = PTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 700;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmaTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlasmaTurretPack::onDeploy(%player,%item,%pos)
{
	if (PlasmaTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlasmaTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,4)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"RemotePlasma",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"RemotePlasma",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(largeDeployArea(%client,$los::position,2)) {
								%rot = GameBase::getRotation(%player); 
								%pturret = newObject("hellfiregun","Turret",RemotePlasma,true);
								addToSet("MissionCleanup", %pturret);
								GameBase::setTeam(%pturret,GameBase::getTeam(%player));
								%playerPos = GameBase::getPosition(%player);
								GameBase::setPosition(%pturret,$los::position);
								GameBase::setRotation(%pturret,%rot);
								Gamebase::setMapName(%pturret,"RMT Plasma#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Plasma Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "PlasmaTurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Plasma Turret");
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

//Deployable Teleporter Marker Rune
ItemImageData RunePackImage
{
	shapeFile = "grenade";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.5;
	firstPerson = false;
};

ItemData RunePack
{
	description = "Teleport Marker";
	shapeFile = "mineammo";
	className = "Backpack";
   heading = "iDeployables";
	imageType = RunePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RunePack::onUse(%player,%item)
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

function RunePack::onDeploy(%player,%item,%pos)
{
	if (RunePack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function RunePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,4))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
	    			%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TeleBoxMinLength,$TeleBoxMinLength,$TeleBoxMinLength,0);
				%num = CountObjects(%set,"Rift",%num);
				deleteObject(%set);
				if(0 == %num)
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player); 
							%rune = newObject("","StaticShape",Rune,true);
							%pteam = GameBase::getTeam(%player);
							addToSet("MissionCleanup", %rune);
							GameBase::setTeam(%rune,%pteam);
							GameBase::setPosition(%rune,$los::position);
							GameBase::setRotation(%rune,%rot);
							Gamebase::setMapName(%rune,"Rift Exit");
							GameBase::startFadeIn(%rune);
						      TeamMessages(3, GameBase::getTeam(%player), "**Teleportation Rift Exit Online at POS:"@ $los::position @"**");
							playSound(SoundPickupBackpack,$los::position);
							playSound(SoundTeleporterDeploy,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "RunePack"]++;
							$RuneLoc[%pteam] = $los::position;
							echo("MSG: ",%client," deployed a Rune.");
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
			   else 
					Client::sendMessage(%client,0,"Too close to a rift to deploy");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Only 1 marker is allowed per team!");

	return false;
}

//NanoBase pack
ItemImageData NanoBasePackImage
{
	shapeFile = "liqcyl";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 9;
	firstPerson = false;
};

ItemData NanoBasePack
{
	description = "NanoBuilder Node";
	shapeFile = "liqcyl";
	className = "Backpack";
   heading = "iDeployables";
	imageType = NanoBasePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 3800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NanoBasePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function NanoBasePack::onDeploy(%player,%item,%pos)
{
	if (NanoBasePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function NanoBasePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,5))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player); 
						%nbase = newObject("","StaticShape",NanoBase,true);
							// Set stuff for 
							%checkset = nameToID("MissionCleanup/Nanobase");
							if(%checkset == -1)
							{
								newObject("Nanobase",SimSet);
								addToSet("MissionCleanup","Nanobase");
							}
							addToSet("MissionCleanup/Nanobase", %nbase);
							addToSet("MissionCleanup", %nbase);
						GameBase::setTeam(%nbase,GameBase::getTeam(%player));
						GameBase::setPosition(%nbase,$los::position);
						GameBase::setRotation(%nbase,%rot);
						Gamebase::setMapName(%nbase,"Nanobuiler Base");
						GameBase::startFadeIn(%nbase);
					      TeamMessages(3, GameBase::getTeam(%player), "**NanoBuiler Node Online at POS:"@ $los::position @"**");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "NanoBasePack"]++;
						echo("MSG: ",%client," deployed a Nanbuilder Base");
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
	 	Client::sendMessage(%client,0,"Only 2 Nanobases can be deployed at one time");
	return false;
}

//Deployable Teleport
ItemImageData TeleporterPackImage
{
	shapeFile = "liqcyl";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.5;
	firstPerson = false;
};

ItemData TeleporterPack
{
	description = "Teleport Rift";
	shapeFile = "liqcyl";
	className = "Backpack";
   heading = "iDeployables";
	imageType = TeleporterPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 3800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleporterPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TeleporterPack::onDeploy(%player,%item,%pos)
{
	if (TeleporterPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TeleporterPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,4))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TeleBoxMinLength,$TeleBoxMinWidth,$TeleBoxMinHeight,0);
				%num = CountObjects(%set,"Rift",%num);
				deleteObject(%set);
				if(0 == %num)
				{
			    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TeleBoxMinLength,$TeleBoxMinWidth,$TeleBoxMinHeight,0);
					%num = CountObjects(%set,"Rune",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position))
							{
								%rot = GameBase::getRotation(%player); 
							%tele = newObject("","StaticShape",Rift,true);
							addToSet("MissionCleanup", %Tele);
							GameBase::setTeam(%tele,GameBase::getTeam(%player));
							GameBase::setPosition(%tele,$los::position);
							GameBase::setRotation(%tele,%rot);
							Gamebase::setMapName(%tele,"Rift Entrance");
							GameBase::startFadeIn(%tele);
								%zap = newObject("","StaticShape",ElectricalBeam,true);
								addToSet("MissionCleanup", %zap);
								GameBase::setTeam(%zap,GameBase::getTeam(%player));
								GameBase::setPosition(%zap,$los::position);
								GameBase::setRotation(%zap,%rot);
								GameBase::startFadeIn(%zap);
								%tele.beam = %zap;
							%telboom = newObject("","Mine","Telebomb"); 
							addToSet("MissionCleanup", %telboom);
							GameBase::setPosition(%telboom,$los::position);
							      TeamMessages(3, GameBase::getTeam(%player), "**Teleportation Rift Entrance Online at POS:"@ $los::position @"**");
								playSound(SoundPickupBackpack,$los::position);
								playSound(SoundTeleporterDeploy,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TeleporterPack"]++;
								echo("MSG: ",%client," deployed a Teleporter");
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Space/Time destabalization - too close to the marker");
				} 
				else
					Client::sendMessage(%client,0,"Space/Time destabalization - too close to the other rift");
			}
			else 
				Client::sendMessage(%client,0,"Can only create on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Only 2 rifts allowed per team!");

	return false;
}

//Laser Turret Pack
ItemImageData LaserTurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LaserTurretPack
{
	description = "Proximity Laser";
	shapeFile = "camera";
	className = "Backpack";
   heading = "iDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function LaserTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "LaserTurretPack"] < $TeamItemMax[LaserTurretPack])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
			}
			else
			{
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
					%rot = "3.14159 0 " @ %zRot;
			}
			else
			{
				%rot = Vector::getRotation($los::normal);
			}
		}
		if(checkDeployArea(%client,$los::position))
		{
					%laser = newObject("camera","Turret",LaserTurret,true);
				      addToSet("MissionCleanup", %laser);
					GameBase::setTeam(%laser,GameBase::getTeam(%player));
					GameBase::setRotation(%laser,%rot);
					GameBase::setPosition(%laser,$los::position);
					Gamebase::setMapName(%laser,"Laser Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%laser,0,"Proximity Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%laser) @ "LaserTurretPack"]++;
					echo("MSG: ",%client," deployed a Laser Turret");
					if(%client.nanodone == 1)
						%client.nanodone = 0;
					return true;
				}
			}
			else
			{
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else
		{
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for Laser Turrets");
	
	return false;
}

//Deployable Chaingun Turret
ItemImageData ChainPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.5;
	firstPerson = false;
};

ItemData ChainTurretPack
{
	description = "Chaingun Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "iDeployables";
	imageType = ChainPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 650;
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
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"RemoteChain",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"RemoteChain",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%cturret = newObject("remoteturret","Turret",RemoteChain,true);
								addToSet("MissionCleanup", %cturret);
								GameBase::setTeam(%cturret,GameBase::getTeam(%player));
								GameBase::setPosition(%cturret,$los::position);
								GameBase::setRotation(%cturret,%rot);
								Gamebase::setMapName(%cturret,"RMT Chain#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Chaingun Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ChainTurretPack"]++;
								echo("MSG: ",%client," deployed a Chaingun Turret");
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other Chaingun turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other Chaingun turrets in the area");
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

//Deployable Triple-A Stinger Missile Turret
ItemImageData StingerPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.5;
	firstPerson = false;
};

ItemData StingerPack
{
	description = "Stinger AAA Missile";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "iDeployables";
	imageType = StingerPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StingerPack::onUse(%player,%item)
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

function StingerPack::onDeploy(%player,%item,%pos)
{
	if (StingerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function StingerPack::deployShape(%player,%item)
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
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						if($StingerTime[GameBase::getTeam(%player)] == 0)
						{
							%rot = GameBase::getRotation(%player); 
							%stinga = newObject("mortar_turret","Turret",Stinger,true);
							addToSet("MissionCleanup", %stinga);
							GameBase::setTeam(%stinga,GameBase::getTeam(%player));
							GameBase::setPosition(%stinga,$los::position);
							GameBase::setRotation(%stinga,%rot);
							Gamebase::setMapName(%stinga,"Stinger Batterry - "@ Client::getName(%client));
							Client::sendMessage(%client,0,"Stinger Battery deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "StingerPack"]++;
							return true;
						}
						else 
							Client::sendMessage(%client,0,"You have to wait 5 minutes before placing another stinger after one was destroyed.");
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else 
				Client::sendMessage(%client,0,"Must be deployed on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for Stinger Batteries");

	return false;
}

// Tank Turret
ItemImageData ShellTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.5;
	firstPerson = false;
};

ItemData ShellTurretPack
{
	description = "RPG Seige Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "iDeployables";
	imageType = ShellTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1050;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShellTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ShellTurretPack::onDeploy(%player,%item,%pos)
{
	if (ShellTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ShellTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"TankGun",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"TankGun",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(largeDeployArea(%client,$los::position,2)) {
								%rot = GameBase::getRotation(%player);
								%sturret = newObject("mortar_turret","Turret",TankGun,true);
								addToSet("MissionCleanup", %sturret);
								GameBase::setTeam(%sturret,GameBase::getTeam(%player));
								GameBase::setPosition(%sturret,$los::position);
								GameBase::setRotation(%sturret,%rot);
								Gamebase::setMapName(%sturret,"RPG Turret#1 " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Siege Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "ShellTurretPack"]++;
								echo("MSG: ",%client," deployed a RPG Turret");
								return true;
							}
						}
						else 
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other RPG turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other RPG turrets in the area");
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

// Platform Pack
ItemImageData PlasWallPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 0.25;
	firstPerson = false;
};

ItemData PlasWallPack
{
	description = "Platform";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "gWalls&Platforms";
	imageType = PlasWallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasWallPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlasWallPack::onDeploy(%player,%item,%pos)
{
	if (PlasWallPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlasWallPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3))
	{
		%obj = getObjectType($los::object);
		if (%obj != "Player")
		{
			%rot = GameBase::getRotation(%player);
			%pWall= newObject("","StaticShape",PlasWall,true);
			addToSet("MissionCleanup", %pWall);
			GameBase::setTeam(%pWall,GameBase::getTeam(%player));
			GameBase::setPosition(%pWall,$los::position);
			GameBase::setRotation(%pWall,%rot);
			Gamebase::setMapName(%pWall,"Platform");
			Client::sendMessage(%client,0,"Platform Deployed");
			GameBase::startFadeIn(%pWall);
			playSound(SoundPickupBackpack,$los::position);
			playSound(SoundBeaconUse,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "PlasWallPack"]++;
			echo("MSG: ",%client," deployed a Platform");
			return true;
			if(%client.nanodone == 1)
				%client.nanodone = 0;
		}
		else 
			Client::sendMessage(%client,0,"Can only deploy on terrain, buildings, or objects.");
	}
	else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}

// Forcefield Pack
ItemImageData ForceWallPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
//	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceWallPack
{
	description = "Basic Forcefield (4x8)";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "gWalls&Platforms";
	imageType = ForceWallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceWallPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ForceWallPack::onDeploy(%player,%item,%pos)
{
	if (ForceWallPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ForceWallPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] || $TeamItemCount[GameBase::getTeam(%player) @ %item] > $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceWallBoxMinLength,$ForceWallBoxMinWidth,$ForceWallBoxMinHeight,0);
				%num = CountObjects(%set,"ForceWall",%num);
				deleteObject(%set);
				if(0 == %num || 0 != %num) {
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(checkDeployArea(%client,$los::position)) {
							%rot = GameBase::getRotation(%player);
							%fWall= newObject("","StaticShape",ForceWall,true);
							addToSet("MissionCleanup", %fWall);
							GameBase::setTeam(%fWall,GameBase::getTeam(%player));
							GameBase::setPosition(%fWall,$los::position);
							GameBase::setRotation(%fWall,%rot);
							Gamebase::setMapName(%fWall,"Forcefield");
							Client::sendMessage(%client,0,"Forcefield Deployed");
							GameBase::startFadeIn(%fWall);
							playSound(SoundPickupBackpack,$los::position);
							playSound(SoundDoorClose,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "ForceWallPack"]++;
							echo("MSG: ",%client," deployed a Forcefield");
							if(%client.nanodone == 1)
								%client.nanodone = 0;
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				} 
				else
					Client::sendMessage(%client,0,"Frequency Overload - Too close to other Forcefields.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings or objects.");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

// Big Forcefield Pack
ItemImageData MassWallPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
	mass = 4.5;
	firstPerson = false;
};

ItemData MassWallPack
{
	description = "Large Forcefield (4x17)";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "gWalls&Platforms";
	imageType = MassWallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MassWallPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MassWallPack::onDeploy(%player,%item,%pos)
{
	if (MassWallPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function MassWallPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] || $TeamItemCount[GameBase::getTeam(%player) @ %item] > $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,4)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceWallBoxMinLength,$ForceWallBoxMinWidth,$ForceWallBoxMinHeight,0);
				%num = CountObjects(%set,"MassForceWall",%num);
				deleteObject(%set);
				if(0 == %num || 0 != %num) {
					if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						if(largeDeployArea(%client,$los::position,3)) {
							%rot = GameBase::getRotation(%player);
							%bWall= newObject("","StaticShape",MassForceWall,true);
							addToSet("MissionCleanup", %bWall);
							GameBase::setTeam(%bWall,GameBase::getTeam(%player));
							GameBase::setPosition(%bWall,$los::position);
							GameBase::setRotation(%bWall,%rot);
							Gamebase::setMapName(%bWall,"Big Forcefield");
							Client::sendMessage(%client,0,"Forcefield Deployed");
							GameBase::startFadeIn(%bWall);
							playSound(SoundPickupBackpack,$los::position);
							playSound(SoundDoorClose,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "MassWallPack"]++;
							echo("MSG: ",%client," deployed a Large Forcefield");
							return true;
						}
					}
					else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				} 
				else
					Client::sendMessage(%client,0,"Frequency Overload - Too close to other Large Forcefields.");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings or objects.");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

// Tree Pack
ItemImageData DTreePackImage
{
	shapeFile = "tree2";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 1.5;
	firstPerson = false;
};

ItemData DTreePack
{
	description = "Deployable Tree";
	shapeFile = "tree2";
	className = "Backpack";
   heading = "iDeployables";
	imageType = DTreePackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DTreePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DTreePack::onDeploy(%player,%item,%pos)
{
	if (DTreePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DTreePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player);
						%dTre= newObject("","StaticShape",DTree,true);
						addToSet("MissionCleanup", %dTre);
						GameBase::setTeam(%dTre,GameBase::getTeam(%player));
						GameBase::setPosition(%dTre,$los::position);
						GameBase::setRotation(%dTre,%rot);
						Gamebase::setMapName(%dTre,"Tree");
						Client::sendMessage(%client,0,"Tree Deployed");
						GameBase::startFadeIn(%dTre);
						playSound(SoundPickupBackpack,$los::position);
						playSound(SoundDoorClose,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "DTreePack"]++;
						echo("MSG: ",%client," deployed a Tree");
						return true;
					}
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else 
			Client::sendMessage(%client,0,"Can only deploy on terrain");
	}
	else 
		Client::sendMessage(%client,0,"Deploy position out of range");

	return false;
}

//Decoy dude
ItemImageData DecoyPackImage
{
	shapeFile = "armorpack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData DecoyPack
{
	description = "Hunting Decoy";
	shapeFile = "armorpack";
	className = "Backpack";
   heading = "iDeployables";
	imageType = DecoyPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DecoyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DecoyPack::onDeploy(%player,%item,%pos)
{
	if (DecoyPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DecoyPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player);
						%dman= newObject("","StaticShape",DMan,true);
						addToSet("MissionCleanup", %dman);
						GameBase::setTeam(%dman,GameBase::getTeam(%player));
						GameBase::setPosition(%dman,$los::position);
						GameBase::setRotation(%dman,%rot);
						Gamebase::setMapName(%dman,Client::getName(%client));
						Client::sendMessage(%client,0,"Decoy deployed.");
						GameBase::startFadeIn(%dman);
						playSound(SoundPickupBackpack,$los::position);
						playSound(SoundDoorClose,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "DecoyPack"]++;
						echo("MSG: ",%client," deployed a Decoy");
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
	return false;
}

//Heavy Decoy dude
ItemImageData HDecoyPackImage
{
	shapeFile = "armorpack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData HDecoyPack
{
	description = "Heavy Armor Decoy";
	shapeFile = "armorpack";
	className = "Backpack";
   heading = "iDeployables";
	imageType = DecoyPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HDecoyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function HDecoyPack::onDeploy(%player,%item,%pos)
{
	if (HDecoyPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function HDecoyPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%rot = GameBase::getRotation(%player);
						%dman= newObject("","StaticShape",DHMan,true);
						addToSet("MissionCleanup", %dman);
						GameBase::setTeam(%dman,GameBase::getTeam(%player));
						GameBase::setPosition(%dman,$los::position);
						GameBase::setRotation(%dman,%rot);
						Gamebase::setMapName(%dman,Client::getName(%client));
						Client::sendMessage(%client,0,"Decoy deployed.");
						GameBase::startFadeIn(%dman);
						playSound(SoundPickupBackpack,$los::position);
						playSound(SoundDoorClose,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "HDecoyPack"]++;
						echo("MSG: ",%client," deployed a Decoy");
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
	return false;
}

// The NANOLATHE!
// The pack part of the Jump pack
ItemImageData NanoPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	sfxFire = SoundNanoPackCompile;
};

ItemData NanoPack
{
	description = "NanoPack Builder";
	shapeFile = "armorpack";
	className = "Backpack";
      heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = NanoPackImage;
	price = 7000;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NanoPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Lathe)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function NanoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::mountItem(%player,Lathe,$WeaponSlot);
	}
}

function NanoPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == Lathe)
		{
			Player::unmountItem(%player,$WeaponSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
		%client = Player::getClient(%player);
		%client.nanodone = 0;
	}
}

// The gun part
ItemImageData LatheImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0, 0.5, 0 };

	weaponType = 0;  // Single Shot
	minEnergy  = 20;
	maxEnergy = 20;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime   = 3;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundActivateCommandStation;
};

ItemData Lathe
{
	description = "Nano-Lathe Constructor";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = LatheImage;
	showInventory = false;
	price = 125;
};

function Lathe::onMount(%player,%imageSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "<jc><f2>Nano-Lathe activated!");
}

function Lathe::onUnmount(%player,%imageSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "<jc><f6>Nano-Lathe deactivated!");
}

function LatheImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	%set = nameToID("MissionCleanup/Nanobase");
	for(%i = 0; (%node = Group::getObject(%set, %i)) != -1; %i++)
	{
		%bteam = GameBase::getTeam(%node);
		%pteam = GameBase::getTeam(%player);
		if(%pteam == %bteam)
		{
			if(Vector::getDistance(GameBase::getPosition(%player),GameBase::getPosition(%node)) < 100)
				%nanook = 1;
			else
				%nanook = 2;
		}
		else
			%nanook = 0;
	}
	if(%nanook == 1)
	{
		if(%client.nanodone == 1)
		{
			if(%client.nano == HangingTurret)
			{
				TurretPack::deployShape(%player,TurretPack);
			}
			if(%client.nano == SensorJammer)
			{
				Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,DeployableSensorJammerPack);
			}
			if(%client.nano == MotionSensor)
			{
				MotionSensorPack::deployShape(%player,MotionSensorPack);
			}
			if(%client.nano == PulseSensor)
			{
				Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,PulseSensorPack);
			}
			if(%client.nano == Camera)
			{
				CameraPack::deployShape(%player,CameraPack);
			}
			if(%client.nano == ProxLaser)
			{
				LaserTurretPack::deployShape(%player,LaserTurretPack);
			}
			if(%client.nano == Forcefield)
			{
				ForceWallPack::deployShape(%player,ForceWallPack);
			}
			if(%client.nano == Platform)
			{
				PlasWallPack::deployShape(%player,PlasWallPack);
			}
		}
		else
			Bottomprint(%client, "<jc><f5>Item must be compiled first!");
	}
	else if(%nanook == 2)
		Bottomprint(%client, "<jc><f3>Must be within 100 meters of your team's Nanobuilder Node - Aborting deployment");
	else
		Bottomprint(%client, "<jc><f3>No Nanobuilder Node detected - Aborting deployment");
}

//End of my Packs
//----------------------------------------------------------------------------
// miscellany options (gren/beacon)--
// greandes
ItemData BasicGrenadeIcon
{
   description = "Basic Grenades";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData ShockwaveGrenadeIcon
{
   description = "Shockwave Grenades";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData DistortionGrenadeIcon
{
   description = "Distortion Grenades";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData IncendiaryGrenadeIcon
{
   description = "Incendiary Grenades";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData MineGrenadeIcon
{
   description = "Use Mines";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData HeavyGrenadeIcon
{
   description = "Heavy Grenades";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData TripGrenadeIcon
{
   description = "Trip Bombs";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData EnergyGrenadeIcon
{
   description = "Energy Grenades";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData NuclearGrenadeIcon
{
   description = "Fission Grenades";
   shapeFile = "armorKit";
   heading = "kGrenade Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIconG";
};

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "mMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
	showInventory = false;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			%client = Player::getClient(%player);
			if(Player::getItemCount(%player,%client.grenadeType) > 0)
			{
				Player::decItemCount(%player,%client.grenadeType);
				%armor = Player::getArmor(%player);

	     			if(%client.grenadeType == "BasicGrenadeIcon")
					%obj = newObject("","Mine","Handgrenade");
		     		if(%client.grenadeType == "ShockwaveGrenadeIcon")
					%obj = newObject("","Mine","WaveBomb");
		     		if(%client.grenadeType == "DistortionGrenadeIcon")
					%obj = newObject("","Mine","DistorterBomb");
	     			if(%client.grenadeType == "IncendiaryGrenadeIcon")
					%obj = newObject("","Mine","IncenHandgrenade");
		     		if(%client.grenadeType == "MineGrenadeIcon")
					%obj = newObject("","Mine","antipersonelMine"); 
		     		if(%client.grenadeType == "TripGrenadeIcon")
					%obj = newObject("","Mine","TripBomb"); 
	     			if(%client.grenadeType == "HeavyGrenadeIcon")
					%obj = newObject("","Mine","HeavyBomb"); 
		     		if(%client.grenadeType == "EnergyGrenadeIcon")
					%obj = newObject("","Mine","EnergyBomb"); 
	     			if(%client.grenadeType == "NuclearGrenadeIcon")
					%obj = newObject("","Mine","ShockBomb"); 

	 	 	 	addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
				%player.throwTime = getSimTime() + 0.5;
				GameBase::setTeam (%obj,GameBase::getTeam (%client));
				playSound(SoundThrowItem,GameBase::getPosition(%obj));
			}
		}
	}
}

// beacons
ItemData HeavyBeaconIcon
{
   description = "Heavy Beacons";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData TempFFBeaconIcon
{
   description = "Temporary FFs";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData ECMBeaconIcon
{
   description = "ECM Emitters";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData PlastiqueBeaconIcon
{
   description = "Plastique Charges";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData NanokitBeaconIcon
{
   description = "NanoRepair Modules";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData SpRocketBoostIcon
{
   description = "Rocket Packs";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData AmmoRechargeIcon
{
   description = "NanoRecharge Modules";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData HackingIcon
{
   description = "Infiltration Modules";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData EnergyBoostIcon
{
   description = "Overdrive Charges";
   shapeFile = "armorKit";
   heading = "lBeacon Types";
   shadowDetailMask = 4;
   price = 0;
	className = "SpecialIcon";
};

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "mMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
	showinventory = false;
};

// Multi-use beacons
function Beacon::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%player); 
	if(Player::getItemCount(%player,%client.beaconType) > 0)
	{
		if(%client.beaconType == "HeavyBeaconIcon")
		{
			if (Beacon::deployShape(%player,%item))
			{
				Player::decItemCount(%player,%client.beaconType);
			}
		}
		if(%client.beaconType == "TempFFBeaconIcon")
		{
			ShieldStart(%player,%client);
			Player::decItemCount(%player,%client.beaconType);
		}
		if(%client.beaconType == "ECMBeaconIcon")
		{
			if(ECMBeacon::deployShape(%player,%item))
			{
				Player::decItemCount(%player,%client.beaconType);
			}
		}
		if(%client.beaconType == "PlastiqueBeaconIcon")
		{
			if (PlastiqueBeacon::deployShape(%player,%item))
			{
				Player::decItemCount(%player,%client.beaconType);
			}
		}
		if(%client.beaconType == "NanokitBeaconIcon")
		{
			%cr = GameBase::getAutoRepairRate(%player);
			GameBase::setAutoRepairRate(%player,%cr + 0.05);
			schedule("Beacon::decreaseAutoRepairRate("@ %player @");",10);
			Player::decItemCount(%player,%client.beaconType);
		}
		if(%client.beaconType == "SpRocketBoostIcon")
		{
			%pp = GameBase::getPosition(%player);
			Tfunc::SpawnFX(%pp,-1,"NapalmP");
			schedule("Tfunc::SpawnFX("@ %pp @",-1,NapalmP);",0.1,%player);
			schedule("Tfunc::SpawnFX("@ %pp @",-1,NapalmP);",0.2,%player);
			schedule("Tfunc::SpawnFX("@ %pp @",-1,NapalmP);",0.3,%player);
			schedule("Tfunc::SpawnFX("@ %pp @",-1,NapalmP);",0.4,%player);
			schedule("Tfunc::SpawnFX("@ %pp @",-1,NapalmP);",0.5,%player);

			%vel = 200;
			%vec = 1100;
			%rotation = GameBase::getRotation(%player);
			%jump = Vector::getFromRot(GameBase::getRotation(%player),%vel,%vec);
			Player::applyImpulse(%player,%jump);
			Client::sendMessage(%client,2,"Rocket booster initialized.~wBXplo1.wav");
			Player::decItemCount(%player,%client.beaconType);
		}
		if(%client.beaconType == "AmmoRechargeIcon")
		{
			Client::sendMessage(%client,2,"Resupplying...");
			nanoresupply(%player);
			Player::decItemCount(%player,%client.beaconType);
		}
		if(%client.beaconType == "HackingIcon")
		{
			if(GameBase::getLOSInfo(%player,3))
			{
				%target = $los::object;
				%datatype = GameBase::getDataName(%target);
				if((%datatype == "InventoryStation" || %dataType == "DeployableStation") && GameBase::getTeam(%target) != GameBase::getTeam(%player))
				{
					Client::sendMessage(%client,2,"Infiltrating...");
					%succsess = TFunc::Rand(1000);
					echo(%succsess @"::S/\R::"@ %target.readiness);
					%succsess -= %target.readiness;
					if(%succsess > 800)
					{
						Client::sendMessage(%client,2,"Operation Sucsess - 20 seconds until security systems reclaim target.");
						%ct = GameBase::getTeam(%target);
						schedule("GameBase::setTeam("@ %target @","@ %ct @");",20,%target);
						GameBase::setTeam(%target,GameBase::getTeam(%player));
						schedule("Beacon::StationBoot("@%player@","@ %target@");",20.1);
						%target.readiness += 200;
						schedule(%target@".readiness -= 200;",10,%target);
					}
					if(%succsess > 300 && %succsess < 801)
					{
						Client::sendMessage(%client,2,"Operation Sucsess - 10 seconds until security systems reclaim target.");
						%ct = GameBase::getTeam(%target);
						schedule("GameBase::setTeam("@ %target @","@ %ct @");",10,%target);
						GameBase::setTeam(%target,GameBase::getTeam(%player));
						schedule("Beacon::StationBoot("@%player@","@ %target@");",10.1);
						%target.readiness += 350;
						schedule(%target@".readiness -= 350;",10,%target);
					}
					if(%succsess < 301)
					{
						Client::sendMessage(%client,2,"Operation Failed! Target readiness increased breifly.");
						%target.readiness += 500;
						schedule(%target@".readiness -= 500;",10,%target);
					}
					Player::decItemCount(%player,%client.beaconType);
				}
				else Client::sendMessage(%client,0,"Invalid target");
			}
			else Client::sendMessage(%client,0,"Nothing in range");
		}
		if(%client.beaconType == "EnergyBoostIcon")
		{
			if(%player.overload == 0)
			{
				if(%player.overdrive == 0)
				{
					%newrate = GameBase::getRechargeRate(%player) + 28;
					GameBase::setRechargeRate(%player,%newrate);
					schedule("NormalizeEnergy(" @ %player @ ");",10,%player);
					Client::sendMessage(%client,2,"**Fusion reactor set to overdrive** - Expect normalization in 10 seconds.~wshieldhit.wav");
					Player::decItemCount(%player,%client.beaconType);
					%player.overdrive = 1;
				}
				else
					Client::sendMessage(%client,1,"**Already in overdrive**");
			}
			else
				Client::sendMessage(%client,1,"**Reactor is not responding - Low power.**");
		}
	}
}

function Beacon::StationBoot(%player,%station)
{
	%t = Station::getTarget(%station);
	echo(%player @" "@ %t @" "@ %station);
	if(%player == %t)
	{
		Station::onDisabled(%station);
		Station::onEnabled(%station);
	}
}

function Beacon::decreaseAutoRepairRate(%player)
{
	%cr = GameBase::getAutoRepairRate(%player);
	GameBase::setAutoRepairRate(%player,%cr - 0.1);
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

function ECMBeacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3))
	{
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape")
		{
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6)
				%rot = "0 0 0";
			else
			{
				if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					%rot = "3.14159 0 0";
				else
					%rot = Vector::getRotation($los::normal);
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num)
			{
				%beacon = newObject("ECM Beacon", "Sensor", "TJammer", true);
				addToSet("MissionCleanup", %beacon);
				GameBase::setTeam(%beacon,GameBase::getTeam(%player));
				GameBase::setRotation(%beacon,%rot);
				GameBase::setPosition(%beacon,$los::position);
				Gamebase::setMapName(%beacon,"ECM Beacon");
				Client::sendMessage(%client,0,"***ECM deployed - 10 seconds left on power supply.***");
				//playSound(SoundPickupBackpack,$los::position);
				return true;
			}
			else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
	}
	else Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}

function PlastiqueBeacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3))
	{
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain" || %obj == "InteriorShape")
		{
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6)
				%rot = "0 0 0";
			else
			{
				if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					%rot = "3.14159 0 0";
				else
					%rot = Vector::getRotation($los::normal);
			}
		  	%set=newObject("set",SimSet);
			%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
			deleteObject(%set);
			if(!%num)
			{
				%beacon = newObject("Plastique", "StaticShape", "Plastique", true);
				addToSet("MissionCleanup", %beacon);
				GameBase::setTeam(%beacon,GameBase::getTeam(%player));
				GameBase::setRotation(%beacon,%rot);
				GameBase::setPosition(%beacon,$los::position);
				Gamebase::setMapName(%beacon,"Plastique "@ Client::getName(%client));
				Client::sendMessage(%client,1,"***Plastique deployed - 10 seconds untill detonation***");
				//playSound(SoundPickupBackpack,$los::position);
				return true;
			}
			else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
		}
		else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
	}
	else Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}

function DeployRemoteBeacon(%player,%lospos)
{
	%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setPosition(%beacon,%lospos);
	Gamebase::setMapName(%beacon,"Remote Beacon");
	Beacon::onEnabled(%beacon);
	Client::sendMessage(%client,0,"Beacon deployed");
	schedule("deleteObject("@ %beacon @");",10,%player);
}


function SpecialIconG::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	if(%client.grenadetype != %item)
	{
		Client::sendMessage(%client,0,"Using "@ %item.description @".");
		%client.grenadetype = %item;
	}
}

function SpecialIcon::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	if(%client.beacontype != %item)
	{
		Client::sendMessage(%client,0,"Using "@ %item.description @".");
		%client.beacontype = %item;
	}
}


//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "mMiscellany";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	if(%player.PStep > 0)
		%player.PStep = 1;
	%armor = Player::getArmor(%player);
	%amt = %armor.maxDamage / 3;
	GameBase::repairDamage(%player,%amt);
	playSound(SoundThrowItem,GameBase::getPosition(%obj));
	if(%player.PStep > 0)
		%player.PStep = 1;
	Player::decItemCount(%player,%item);
}



//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "mMiscellany";
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
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			playSound(SoundThrowItem,GameBase::getPosition(%obj));
		}
	}
}

//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "mMiscellany";
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
	else if($ServerCheats)
	{
		Player::setItemCount(%clientId,Blaster,1);
		Player::setItemCount(%clientId,Chaingun,1);
		Player::setItemCount(%clientId,PlasmaGun,1);
		Player::setItemCount(%clientId,GrenadeLauncher,1);
		Player::setItemCount(%clientId,DiscLauncher,1);
		Player::setItemCount(%clientId,LaserRifle,1);
		Player::setItemCount(%clientId,EnergyRifle,1);
		Player::setItemCount(%clientId,TargetingLaser,1);
		Player::setItemCount(%clientId,Mortar,1);
		Player::setItemCount(%clientId,NML,1);
		Player::setItemCount(%clientId,RPG,1);
		Player::setItemCount(%clientId,Reason,1);
		Player::setItemCount(%clientId,SR100,1);
		Player::setItemCount(%clientId,AR900,1);

		Player::setItemCount(%clientId,BulletAmmo,500);
		Player::setItemCount(%clientId,PlasmaAmmo,180);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DiscAmmo,200);
		Player::setItemCount(%clientId,MortarAmmo,150);
		Player::setItemCount(%clientId,NMLAmmo,100);
		Player::setItemCount(%clientId,RPGAmmo,300);
		Player::setItemCount(%clientId,ReasonAmmo,550);
		Player::setItemCount(%clientId,SniperAmmo,250);
		Player::setItemCount(%clientId,AssaultAmmo,200);

	      Player::setItemCount(%clientId,Grenade, 200);
      	Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);
		Player::setItemCount(%clientId,RepairKit,200);
	}
}


//----------------------------------------------------------------------------

function Mission::reinitData()
{
	for(%i=0; %i<8; %i++)
	{
		//Thier stuff
		$TeamItemCount[%i @ DeployableAmmoPack] = 0;
		$TeamItemCount[%i @ DeployableInvPack] = 0;
		$TeamItemCount[%i @ TurretPack] = 0;
		$TeamItemCount[%i @ CameraPack] = 0;
		$TeamItemCount[%i @ DeployableSensorJammerPack]= 0;
		$TeamItemCount[%i @ PulseSensorPack] = 0;
		$TeamItemCount[%i @ MotionSensorPack] = 0;
		$TeamItemCount[%i @ ScoutVehicle] = 0;
		$TeamItemCount[%i @ LAPCVehicle] = 0;
		$TeamItemCount[%i @ HAPCVehicle] = 0;
		$TeamItemCount[%i @ Beacon] = 0;
		$TeamItemCount[%i @ mineammo] = 0;
		//My stuff
		$RuneLoc[%i] = 0;
//		$PlasticID[%i] = 0;
		$TeamItemCount[%i @ RunePack] = 0;
		$TeamItemCount[%i @ TeleporterPack] = 0;
		$TeamItemCount[%i @ ASensorPack] = 0;
		$TeamItemCount[%i @ BunkerPack] = 0;
		$TeamItemCount[%i @ LaserTurretPack] = 0;
		$TeamItemCount[%i @ StingerPack] = 0;
		$TeamItemCount[%i @ MassWallPack] = 0;
		$TeamItemCount[%i @ ForceWallPack] = 0;
		$TeamItemCount[%i @ PlasWallPack] = 0;
		$TeamItemCount[%i @ ShellTurretPack] = 0;
		$TeamItemCount[%i @ RocketTurretPack] = 0;
		$TeamItemCount[%i @ ChainTurretPack] = 0;
		$TeamItemCount[%i @ PlasmaTurretPack] = 0;
		$TeamItemCount[%i @ BomberVehicle] = 0;
		$TeamItemCount[%i @ KamikazeVehicle] = 0;
		$TeamItemCount[%i @ StealthVehicle] = 0;
		$TeamItemCount[%i @ InterceptorVehicle] = 0;
		$TeamItemCount[%i @ ALaserPack] = 0;

		$StingerTime[%i] = 0;
	}
	$totalNumCameras = 0;
	$totalNumTurrets = 0;
	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

function JumpGunEmitFire(%player,%distance,%type)
{
//	if(%type == Smoke)
//	{
//		%obj = newObject("","Mine","ExhaustBig");
//		addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%player,%distance,true);
//		if(Player::getLastContactCount(%player) > 0)
//			schedule("JumpGunEmitFire(" @ %player @ ",0,Smoke);",0.15,%player);
//		return;
//	}

	if(%type == Small)
		%obj = newObject("","Mine","Exhaust");
	if(%type == Large)
		%obj = newObject("","Mine","ExhaustBig");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,%distance,true);
	GameBase::setTeam (%obj,GameBase::getTeam(%player));
}

ItemImageData FunkyImage
{
   shapeFile  = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single
	reloadTime = 0.1;
	minEnergy = 0;
	maxEnergy = 0;

	accuFire = true;

	sfxActivate = SoundPickUpWeapon;
};

ItemData Funky
{
   heading = "bWeapons";
	description = "Test Gun";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FunkyImage;
	price = 125;
	showWeaponBar = true;
};

function FunkyImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	$LastFlare = %this;
	Projectile::spawnProjectile("Flare",%trans,%player,%vel);
}

// ARMOR DETAILS SECTION - These are small identifying items that pop up on certain armors.

// Assassin Targeting Scope (Goes on shoulder)
ItemImageData AssasScopeImage
{
	shapeFile = "paintgun";
	mountPoint = 2;
	mountOffset = { 0.36, 0.3, 0.38 };
	mountRotation = { 0.1, 0, 0 };

	weaponType = 0; // Single Shot
	projectileType = ShoulderLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 50;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
};

ItemData AssasScope
{
	description   = "Targeting Laser";
	className     = "Backpack";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "iMiscellany";
	shadowDetailMask = 4;
	imageType     = AssasScopeImage;
	price         = 50;
	showWeaponBar = false;
};

// Engineer Beacons (Go on either side of back near shoulders)
ItemImageData EngBeaconAImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.28 };
	mountRotation = { 0, 0, 0.5 };

	weaponType = 2; // Sustained
	accuFire = true;
	minEnergy = 2;
	maxEnergy = 12;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
};

ItemData EngBeaconA
{
	description   = "Armor Detail";
	className     = "Backpack";
	shapeFile     = "sensor_small";
	hudIcon       = "targetlaser";
   heading = "iMiscellany";
	shadowDetailMask = 4;
	imageType     = EngBeaconAImage;
	price         = 50;
	showWeaponBar = false;
};

// Energon Chest Battery
ItemImageData EnerBatteryImage
{
	shapeFile = "jetpack";
	mountPoint = 2;
	mountOffset = { 0.048, 0, 0.32 };
	mountRotation = { 0, 0, 0 };

	weaponType = 2; // Sustained
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundEnergyPackOn;
};

ItemData EnerBattery
{
	description   = "Armor Detail";
	className     = "Backpack";
	shapeFile     = "jetpack";
	hudIcon       = "targetlaser";
   heading = "iMiscellany";
	shadowDetailMask = 4;
	imageType     = EnerBatteryImage;
	price         = 50;
	showWeaponBar = false;
};

// Assassin Targeting Scope (Goes on shoulder) - Female version
ItemImageData AssasScopeFemaleImage
{
	shapeFile = "paintgun";
	mountPoint = 2;
	mountOffset = { 0.36, 0.3, 0.3 };
	mountRotation = { 0.1, 0, 0 };

	weaponType = 0; // Single Shot
	projectileType = ShoulderLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 50;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
};

ItemData AssasScopeFemale
{
	description   = "Targeting Laser";
	className     = "Backpack";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "iMiscellany";
	shadowDetailMask = 4;
	imageType     = AssasScopeFemaleImage;
	price         = 50;
	showWeaponBar = false;
};

ItemData ArmorBuff
{
	description   = "Armor Marker";
	className     = "Backpack";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
	heading = "iMiscellany";
	shadowDetailMask = 4;
	imageType     = AssasScopeFemaleImage;
	price         = 50;
	showWeaponBar = false;
	showInventory = false;
};

ItemData ConstrBuff
{
	description   = "NanoPack Marker";
	className     = "Backpack";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
	heading = "iMiscellany";
	shadowDetailMask = 4;
	imageType     = AssasScopeFemaleImage;
	price         = 50;
	showWeaponBar = false;
	showInventory = false;
};

function RedoSpec(%player,%clientId,%armor)
{
	if($ArmorSpec[%clientId] == Energy)
		GameBase::setRechargeRate(%player,14);
	if($ArmorSpec[%clientId] == Health)
		Player::setItemCount(%player,"ArmorBuff",1);
	if($ArmorSpec[%clientId] == Construction)
		Player::setItemCount(%player,"ConstrBuff",1);
	if($ArmorSpec[%clientId] == Autoheal)
	{
		%rate = 0.01;
		GameBase::setAutoRepairRate(%player,%rate);
	}
	if($ArmorSpec[%clientId] == Jamming)
	{
		%rate = Player::getSensorSupression(%player) + 20;
		Player::setSensorSupression(%player,%rate);
	}
}

function checkver()
{
	echo("TALON RULES ::: VERSION: "@ $ModVersion);
}

function SpawnMeAnAI(%player)
{
	%client = PLayer::getClient(%player);

//	%checkset = nameToID("MissionCleanup/Bombs");
//	if(%checkset == -1)
//	{
//	}

		newObject("AIPath",SimSet);
		addToSet("MissionCleanup","THAIPath");
		%marker = newObject("Marker1",MarkerData,"DropPointMarker");
		addToSet("MissionCleanup/THAIPath",%marker);
		GameBase::setPosition(%marker,GameBase::getPosition(%player));
//	createAI( guardNumberOne, "MissionGroup\\Teams\\team0\\guardPath", larmor );
}