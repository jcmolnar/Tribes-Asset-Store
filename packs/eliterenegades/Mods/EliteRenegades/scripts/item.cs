
$ItemFavoritesKey = "RElite";
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
$AutoUse[Fixit] = False;
$AutoUse[ChargeGun] = True;
$AutoUse[RocketLauncher] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[WaveGun] = True;
$AutoUse[Railgun] = True;
$AutoUse[Vulcan] = True;
$AutoUse[Silencer] = True;
$AutoUse[IonGun] = True;
$AutoUse[TranqGun] = True;
$AutoUse[HyperB] = True;
$AutoUse[Omega] = True;
$Use[Blaster] = True;
$AutoUse[RepairKit] = false;

$ArmorType[Male, AlArmor] = aarmor;
$ArmorType[Female, AlArmor] = afemale;
$ArmorName[aarmor] = AlArmor;
$ArmorName[afemale] = AlArmor;
$ArmorType[Male, BursterArmor] = barmor;
$ArmorType[Female, BursterArmor] = bfemale;
$ArmorName[barmor] = BursterArmor;
$ArmorName[bfemale] = BursterArmor;
$ArmorType[Male, DragArmor] = darmor;
$ArmorType[Female, DragArmor] = darmor;
$ArmorName[darmor] = DragArmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorType[Male, DHMArmor] = dmarmor;
$ArmorType[Female, DHMArmor] = dmfemale;
$ArmorName[dmarmor] = DHMArmor;
$ArmorName[dmfemale] = DHMArmor;
$ArmorType[Male, EngArmor] = earmor;
$ArmorType[Female, EngArmor] = efemale;
$ArmorName[earmor] = EngArmor;
$ArmorName[efemale] = EngArmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Female, MediumArmor] = mfemale;
$ArmorName[marmor] = MediumArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorType[Male, ScoutArmor] = sarmor;
$ArmorType[Female, ScoutArmor] = sfemale;
$ArmorName[sarmor] = ScoutArmor;
$ArmorName[sfemale] = ScoutArmor;
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorName[larmor] = LightArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorType[Male, SpArmor] = spyarmor;
$ArmorType[Female, SpArmor] = spyfemale;
$ArmorName[spyarmor] = SpArmor;
$ArmorName[spyfemale] = SpArmor;

$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[SniperRifle] = SniperAmmo;
$WeaponAmmo[Railgun] = RailAmmo;
$WeaponAmmo[WaveGun] = "";
$WeaponAmmo[IonGun] = "";
$WeaponAmmo[Flamer] = "";
$WeaponAmmo[Omega] = "";
$WeaponAmmo[Silencer] = SilencerAmmo;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$WeaponAmmo[TranqGun] = TranqAmmo;

$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[Boost] = 5;
$SellAmmo[Plastique] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[RocketAmmo] = 3;
$SellAmmo[SniperAmmo] = 15;
$SellAmmo[RailAmmo] = 25;
$SellAmmo[SilencerAmmo] = 25;
$SellAmmo[VulcanAmmo] = 100;
$SellAmmo[TranqAmmo] = 2;

$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = RocketAmmo;
$AmmoPackItems[9] = SniperAmmo;
$AmmoPackItems[10] = RailAmmo;
$AmmoPackItems[11] = VulcanAmmo;
$AmmoPackItems[12] = SilencerAmmo; 
$AmmoPackItems[13] = TranqAmmo;

$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 5;
$AmmoPackMax[Beacon] = 3;
$AmmoPackMax[Plastique] = 5;
$AmmoPackMax[RocketAmmo] = 10;
$AmmoPackMax[SniperAmmo] = 15;
$AmmoPackMax[RailAmmo] = 5;
$AmmoPackMax[VulcanAmmo] = 100;
$AmmoPackMax[TranqAmmo] = 20;
$AmmoPackMax[SilencerAmmo] = 25;

$TeamItemMax[DeployableAmmoPack] = 10;
$TeamItemMax[DeployableInvPack] = 15;
$TeamItemMax[TurretPack] = 5;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;
$TeamItemMax[LaserTurret] = 4;
$TeamItemMax[RailTurret] = 3;
$TeamItemMax[VulcanTurret] = 3;
$TeamItemMax[RocketPack] = 3;
$TeamItemMax[DeployableComPack] = 5;
$TeamItemMax[LaserPack] = 5;
$TeamItemMax[TreePack] = 25;
$TeamItemMax[WraithVehicle] = 2;
$TeamItemMax[JetVehicle] = 5;
$TeamItemMax[holomine] = 15;
$TeamItemMax[SatchelPack] = 25;
$TeamItemMax[ShockPack] = 4;
$TeamItemMax[TargetPack] = 2;
$TeamItemMax[ForceFieldPack] = 10; 
$TeamItemMax[LargeForceFieldPack] = 4;
$TeamItemMax[TripwirePack] = 20;
$TeamItemMax[hologram] = 15;
$TeamItemMax[PlatformPack] = 25;
$TeamItemMax[SpringPack] = 15;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[TreePack] = 25;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[WraithVehicle] = 2;
$TeamItemMax[JetVehicle] = 5;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;

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

function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station);
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation)
	{
		%station.Energy += %cost;
		if(%station.Energy < 1)
		%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite")
	{
		$TeamEnergy[%team] += %cost;
		%client.teamEnergy += %cost;
	}
}

function isPlayerBusy(%client)
{
	%state = Player::getItemState(%client,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
}

function testPlayerStat(%cl)
{
	%pl = Client::getOwnedObject(%cl);
	if (!Player::isExposed(%cl) || !$matchStarted || $loadingMission || %pl.driver || $missionComplete)
	return 0;
	else
	return 1;
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	if (isPlayerBusy(%client) || !testPlayerStat(%client))
		return;
	%time = getIntegerTime(true) >> 4;
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
			%error = 0; %bought = 0;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%item = getItemData(%i);
				if ($ServerCheats || Client::isItemShoppingOn(%client,%item))
				{
					%count = Player::getItemCount(%client,%item);
					if(%count)
					{
						if(%item.className != Armor) teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);
					}
				}
			}
			for (%i = 0; %i < 20; %i++)
			{
				if(%favItem[%i] != "")
				{
					%item = getItemData(%favItem[%i]);
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client), %item] > Player::getItemCount(%client,%item) || %item.className == Armor))
					{
						if(!buyItem(%client,%item))
						%error = 1;
						else
						%bought++;
					}
				}
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
	if(%client.spawn == "")
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
		if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor])
		{
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
	else if($TeamItemMax[%item] != "")
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
		%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo;
		if(%delta + %count >= %max)
		%delta = %max - %count;
	}
	return %delta;
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle))
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
						remoteSellItem(%client,29);
					}
				}
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}
			if (checkResources(%player,%item,1))
			{
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);
				if(%item == ammopack)
				fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1)
			{
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
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem = %item.imageType.ammoType;
				if(%ammoItem != "")
				{
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta)
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
			if(%delta)
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
		%pPos = GameBase::getPosition(%client);
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
	if (isPlayerBusy(%client) || !testPlayerStat(%client))
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

function remoteSellItem(%client,%type)
{
	if (isPlayerBusy(%client) || !testPlayerStat(%client))
		return;
	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item))
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
					remoteSellItem(%client,29);
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
	%player = Client::getOwnedObject(%client);
	if (testPlayerStat(%client) && !%player.station)
	{
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
}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(testPlayerStat(%client) && !%player.station && %player.waitThrowTime + $WaitThrowTime <= getSimTime())
	{
		if(GameBase::getControlClient(%player) != -1)
		{
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo)
			{
				if (%strength < 0)
				%strength = 0;
				else if (%strength > 100)
				%strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100); 
				Player::useItem(%client,%item);
			}
		}
	}
}

function remoteDropItem(%client,%type)
{
	%player = Client::getOwnedObject(%client);
	//- sal9k - DROP MODE -----
	%item = Player::getMountedItem(%client,$FlagSlot);
	if((Client::getOwnedObject(%client)).vehicle != "" && %item == Flag) {
		Client::sendMessage(%client, 1, "Cannot drop flag while in a vehicle~waccess_denied.wav");
		return;
	}
	if(%player.station != "" && $Reneg::noDrop == True) {
		if(%client.numDrop >= 10) {
			if(!%client.sentWarning)
				Client::sendMessage(%client,1, "Reached item drop limit.~waccess_denied.wav");
				%client.sentWarning = TRUE;
				return;
		}
		%client.numDrop++;
	}
	//- sal9k - DROP MODE -----
	if (Player::isExposed(%client) && $matchStarted && $loadingMission == false)
	{
		if (%player.driver != 1)
		{
			%client.throwStrength = 1;
			%item = getItemData(%type);
			if (%item == Backpack)
			{
				%item = Player::getMountedItem(%client,$BackpackSlot);
				if(%player.station && %item == SuicidePack)
					return;
				else
					Player::dropItem(%client,%item);
			}
			else if (%item == Weapon)
			{
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
			else
			{
				if(%player.station && %item == SuicidePack)
				return;
				else
				Player::dropItem(%client,%item); 
			}
		}
	}
}

function remoteDeployItem(%client,%type)
{
	%player = Client::getOwnedObject(%client);
	if (testPlayerStat(%client) && !%player.station)
	{
		%item = getItemData(%type);
		Player::deployItem(%client,%item); 
	}
}

$NextWeapon[Fixit] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = RocketLauncher;
$NextWeapon[RocketLauncher] = SniperRifle;
$NextWeapon[SniperRifle] = WaveGun;
$NextWeapon[WaveGun] = EnergyRifle;
$NextWeapon[EnergyRifle] = Railgun;
$NextWeapon[Railgun] = Silencer;
$NextWeapon[Silencer] = Vulcan;
$NextWeapon[Vulcan] = IonGun;
$NextWeapon[IonGun] = Flamer;
$NextWeapon[Flamer] = TranqGun; 
$NextWeapon[TranqGun] = HyperB;
$NextWeapon[HyperB] = Omega;
$NextWeapon[Omega] = Fixit;

$PrevWeapon[Blaster] = Fixit;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[RocketLauncher] = LaserRifle;
$PrevWeapon[SniperRifle] = RocketLauncher;
$PrevWeapon[WaveGun] = SniperRifle;
$PrevWeapon[EnergyRifle] = WaveGun;
$PrevWeapon[Railgun] = EnergyRifle;
$PrevWeapon[Silencer] = Railgun;
$PrevWeapon[Vulcan] = Silencer;
$PrevWeapon[IonGun] = Vulcan;
$PrevWeapon[Flamer] = IonGun;
$PrevWeapon[TranqGun] = Flamer;
$PrevWeapon[HyperB] = TranqGun;
$PrevWeapon[Omega] = HyperB;
$PrevWeapon[Fixit] = Omega;

function remoteNextWeapon(%client)
{
	if(!testPlayerStat(%client))
	{
		return;
	}
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
	selectValidWeapon(%client);
	else
	{
		for (%weapon = $NextWeapon[%item];
		%weapon != %item;
		%weapon = $NextWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
				break;
			}
		}
	}
}

function remotePrevWeapon(%client)
{
	if(!testPlayerStat(%client))
	{
		return;
	}
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $PrevWeapon[%item] == "")
	selectValidWeapon(%client);
	else
	{
		for (%weapon = $PrevWeapon[%item];
		%weapon != %item;
		%weapon = $PrevWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
				break;
			}
		}
	}
}

function selectValidWeapon(%client)
{
	%armor = Player::getarmor(Client::getOwnedObject(%client));
	if(%armor == sarmor || %armor == sfemale)
	%item = Mortar;
	else
	if(%armor == larmor || %armor == lfemale)
	%item = RocketLauncher;
	else
	%item = EnergyRifle;
	for (%weapon = $NextWeapon[%item];
	%weapon != %item;
	%weapon = $NextWeapon[%weapon]) 
	{
		if (isSelectableWeapon(%client,%weapon))
		{
			Player::useItem(%client,%weapon);
			break; 
		}
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

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item])
	{
		%client = Player::getClient(%player);
		if (%item.className == Backpack)
		{
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
			if (%item.className == Weapon)
			{
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor])
				return 0;
			}
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "")
			%extraAmmo = $AmmoPackMax[%item];
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
	else
	{
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
	// Do nothing
}

function Item::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player" && Player::isExposed(%object))
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

// Added message when mounting weapon\tool *ZOD
function Item::onMount(%player,%item)
{
	if (($Reneg::HMessage == "true" && !$Server::TourneyMode) && (%item.classname == "Weapon" || %item.classname == "Tool"))
	{
		%client = Player::getClient(%player);
		Bottomprint(%client,"<jc>Now using: <f2>" @ %item.description);
	}
}

function Item::onUnmount(%player,%item)
{
	// Do nothing
}

function Item::onUse(%player,%item)
{
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
	// Do nothing
}

function checkDeployArea(%client,%pos)
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num)
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player")
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %client)
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
	}
	else
	Client::sendMessage(%client,0,"Unable to deploy - Item in the way.~waccess_denied.wav");
	deleteObject(%set);
	return 0;
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

function checkFlierArea(%cl, %pos)
{
	%set = newObject("set", SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType | $SimPlayerObjectType | $SimInteriorObjectType, %pos, 8, 8, 8, 0);
	if(%num < 2 && Player::getClient(Group::getObject(%set, 0)) == %cl)
	return true;
	else
	{
		Client::sendMessage(%cl,0,"Too close to other objects in the area.~waccess_denied.wav");
		return false;
	}
	deleteObject(%set);
}

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//--------------------------------------------------------------------------------------------------------------------
//	Flags, Armors, Vehicles, Tools, Weapons and Deployables
//--------------------------------------------------------------------------------------------------------------------

function Flag::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$FlagSlot);
}

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };
	lightType = 2;
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
//	mass = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	validateShape = true;
	lightType = 2;
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
//	mass = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	lightType = 2;
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//--------------------------------------------------------------------------------------------------------------------

ItemData ScoutArmor 
{
	heading = "aArmor";
	description = "Scout";
	className = "Armor";
	price = 175;
};

ItemData SpArmor 
{
	heading = "aArmor";
	description = "Spy";
	className = "Armor";
	price = 175;
};

ItemData LightArmor 
{
	heading = "aArmor";
	description = "Sniper";
	className = "Armor";
	price = 175;
};

ItemData MediumArmor 
{
	heading = "aArmor";
	description = "Mercenary";
	className = "Armor";
	price = 250;
};

ItemData BursterArmor 
{
	heading = "aArmor";
	description = "Burster";
	className = "Armor";
	price = 250;
};

ItemData EngArmor 
{
	heading = "aArmor";
	description = "Engineer";
	className = "Armor";
	price = 250;
};

ItemData AlArmor 
{
	heading = "aArmor";
	description = "Alien";
	className = "Armor";
	price = 250;
};

ItemData DragArmor 
{
	heading = "aArmor";
	description = "Cyborg";
	className = "Armor";
	price = 400;
};

//--------------------------------------------------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
	heading = "aVehicle";
	price = 600;
};

ItemData WraithVehicle
{
	description = "Wraith";
	className = "Vehicle";
	heading = "aVehicle";
	price = 600;
};

ItemData JetVehicle
{
	description = "Interceptor";
	className = "Vehicle";
	heading = "aVehicle";
	price = 600;
};

ItemData LAPCVehicle
{
	description = "BomberLPC";
	className = "Vehicle";
	heading = "aVehicle";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "StealthHPC";
	className = "Vehicle";
	heading = "aVehicle";
	price = 875;
};

//-------------------------------------------------------------------------------------------------------------------------

ItemData Weapon { description = "Weapon"; showInventory = false; }; function Weapon::onDrop(%player,%item) { %state = Player::getItemState(%player,$WeaponSlot); if (%state != "Fire" && %state != "Reload") Item::onDrop(%player,%item); } function Weapon::onUse(%player,%item) { if(%player.Station=="") { %ammo = %item.imageType.ammoType; if (%ammo == "") { Player::mountItem(%player,%item,$WeaponSlot); } else { if (Player::getItemCount(%player,%ammo) > 0) Player::mountItem(%player,%item,$WeaponSlot); else { Client::sendMessage(Player::getClient(%player),0, strcat(%item.description," has no ammo")); } } } }
ItemData Tool { description = "Tool"; showInventory = false; }; function Tool::onUse(%player,%item) { Player::mountItem(%player,%item,$ToolSlot); }
ItemData Ammo { description = "Ammo"; showInventory = false; }; function Ammo::onDrop(%player,%item) { if($matchStarted) { %count = Player::getItemCount(%player,%item); %delta = $SellAmmo[%item]; if(%count <= %delta) { if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) %delta = %count; else %delta = %count - 1; } if(%delta > 0) { %obj = newObject("","Item",%item,%delta,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,20,false); Item::playPickupSound(%obj); Player::decItemCount(%player,%item,%delta); } } }
ItemImageData BlasterImage { shapeFile = "energygun"; mountPoint = 0; weaponType = 0; reloadTime = 0; fireTime = 0.3; minEnergy = 5; maxEnergy = 6; projectileType = BlasterBolt; accuFire = true; sfxFire = SoundFireBlaster; sfxActivate = SoundPickUpWeapon; }; ItemData Blaster { heading = "bWeapons"; description = "Blaster"; className = "Weapon"; shapeFile = "energygun"; hudIcon = "blaster"; shadowDetailMask = 4; imageType = BlasterImage; price = 85; showWeaponBar = true; };
ItemData BulletAmmo { description = "Bullet"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; }; ItemImageData ChaingunImage { shapeFile = "chaingun"; mountPoint = 0; weaponType = 1; reloadTime = 0; spinUpTime = 0.5; spinDownTime = 3; fireTime = 0.2; ammoType = BulletAmmo; projectileType = ChaingunBullet; accuFire = false; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1 }; sfxFire = SoundFireChaingun; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; }; ItemData Chaingun { description = "Chaingun"; className = "Weapon"; shapeFile = "chaingun"; validateShape = true; hudIcon = "chain"; heading = "bWeapons"; shadowDetailMask = 4; imageType = ChaingunImage; price = 125; showWeaponBar = true; };
ItemData PlasmaAmmo { description = "Plasma Bolt"; heading = "xAmmunition"; className = "Ammo"; shapeFile = "plasammo"; shadowDetailMask = 4; price = 2; }; ItemImageData PlasmaGunImage { shapeFile = "plasma"; mountPoint = 0; weaponType = 0; ammoType = PlasmaAmmo; projectileType = PlasmaBolt; accuFire = true; reloadTime = 0.1; fireTime = 0.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 1, 1, 0.2 }; sfxFire = SoundFirePlasma; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; }; ItemData PlasmaGun { description = "Plasma Gun"; className = "Weapon"; shapeFile = "plasma"; hudIcon = "plasma"; heading = "bWeapons"; shadowDetailMask = 4; imageType = PlasmaGunImage; price = 175; showWeaponBar = true; validateShape = true; };
ItemData GrenadeAmmo { description = "Grenade Ammo"; className = "Ammo"; shapeFile = "grenammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; }; ItemImageData GrenadeLauncherImage { shapeFile = "grenadeL"; mountPoint = 0; weaponType = 0; ammoType = GrenadeAmmo; projectileType = GrenadeShell; accuFire = false; reloadTime = 0.5; fireTime = 0.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundFireGrenade; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; }; ItemData GrenadeLauncher { description = "Grenade Launcher"; className = "Weapon"; shapeFile = "grenadeL"; hudIcon = "grenade"; heading = "bWeapons"; shadowDetailMask = 4; imageType = GrenadeLauncherImage; price = 150; showWeaponBar = true; validateShape = true; };
ItemData MortarAmmo { description = "Mortar Ammo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "mortarammo"; shadowDetailMask = 4; price = 5; }; ItemImageData MortarImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = MortarAmmo; projectileType = MortarShell; accuFire = false; reloadTime = 0.5; fireTime = 2.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundMortarIdle; }; ItemData Mortar { description = "Mortar"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "mortar"; heading = "bWeapons"; shadowDetailMask = 4; imageType = MortarImage; price = 375; showWeaponBar = true; validateShape = true; };
ItemData DiscAmmo { description = "Disc"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; }; ItemImageData DiscLauncherImage { shapeFile = "disc"; mountPoint = 0; weaponType = 3; ammoType = DiscAmmo; projectileType = DiscShell; accuFire = true; reloadTime = 0.25; fireTime = 1.25; spinUpTime = 0.25; sfxFire = SoundFireDisc; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDiscReload; sfxReady = SoundDiscSpin; }; ItemData DiscLauncher { description = "Disc Launcher"; className = "Weapon"; shapeFile = "disc"; hudIcon = "disk"; heading = "bWeapons"; shadowDetailMask = 4; imageType = DiscLauncherImage; price = 150; showWeaponBar = true; validateShape = true; };
ItemImageData LaserRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; projectileType = SniperLaser2; accuFire = true; reloadTime = 0.1; fireTime = 0.5; minEnergy = 10; maxEnergy = 60; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 1, 0, 0 }; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; }; ItemData LaserRifle { description = "Laser Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "sniper"; heading = "bWeapons"; shadowDetailMask = 4; imageType = LaserRifleImage; price = 200; showWeaponBar = true; validateShape = true; }; function LaserRifle::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Laser Rifle."); }
ItemImageData RepairGunImage { shapeFile = "repairgun"; mountPoint = 0; weaponType = 2; projectileType = RepairBolt; minEnergy = 3; maxEnergy = 10; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundRepairItem; }; ItemData RepairGun { description = "Repair Gun"; shapeFile = "repairgun"; className = "Weapon"; shadowDetailMask = 4; imageType = RepairGunImage; showInventory = false; price = 125; validateShape = true; }; function RepairGun::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); } function RepairGun::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); }
ItemImageData HyperBImage { shapeFile = "plasma"; mountPoint = 0; weaponType = 0; reloadTime = 0; fireTime = 0.1; minEnergy = 5; maxEnergy = 6; projectileType = HyperBolt; accuFire = true; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; }; ItemData HyperB { heading = "bWeapons"; description = "Hyper Blaster"; className = "Weapon"; shapeFile = "plasma"; hudIcon = "blaster"; shadowDetailMask = 4; imageType = HyperBImage; price = 285; showWeaponBar = true; };
ItemData RocketAmmo { description = "Rockets"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "rocket"; shadowDetailMask = 4; price = 50; }; ItemImageData RocketImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = RocketAmmo; projectileType = StingerMissile; accuFire = true; reloadTime = 0.5; fireTime = 2.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundMortarIdle; }; ItemData RocketLauncher { description = "Rocket Launcher"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "mortar"; heading = "bWeapons"; shadowDetailMask = 4; imageType = RocketImage; price = 375; showWeaponBar = true; };
ItemData SniperAmmo { description = "Sniper Bullet"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; ItemImageData SniperRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = SniperAmmo; projectileType = SniperRound; accuFire = true; reloadTime = 1.2; fireTime = 0; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 1.0, 0, 0 }; sfxFire = SoundFireChainGun; sfxActivate = SoundPickUpWeapon; }; ItemData SniperRifle { description = "Sniper Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = SniperRifleImage; price = 375; showWeaponBar = true; };
ItemData TranqAmmo { description = "Poison Dart"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; ItemImageData TranqGunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = TranqAmmo; projectileType = TranqDart; accuFire = true; reloadTime = 1.3; fireTime = 0; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 1.0, 0, 0 }; sfxFire = SoundFireChainGun; sfxActivate = SoundPickUpWeapon; }; ItemData TranqGun { description = "Dart Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "blaster"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TranqGunImage; price = 475; showWeaponBar = true; };
ItemData SilencerAmmo { description = "Magnum Bullets"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; ItemImageData SilencerImage { shapeFile = "energygun"; mountPoint = 0; weaponType = 0; ammoType = SilencerAmmo; projectileType = SilencerBullet; accuFire = true; reloadTime = 0.0; fireTime = 0.5; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 0, 0, 0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; }; ItemData Silencer { description = "Magnum"; className = "Weapon"; shapeFile = "energygun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = SilencerImage; price = 375; showWeaponBar = true; validateShape = true; };
ItemImageData WaveGunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; minEnergy = 40; maxEnergy = 45; projectileType = Shock; accuFire = true; fireTime = 0.9; sfxFire = SoundPlasmaTurretFire; sfxActivate = SoundPickUpWeapon; }; ItemData WaveGun { description = "Shockwave Cannon"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "disk"; heading = "bWeapons"; shadowDetailMask = 4; imageType = WaveGunImage; price = 250; showWeaponBar = true; };
ItemData RailAmmo { description = "Railgun Bolt"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; ItemImageData RailgunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = RailAmmo; projectileType = RailRound; accuFire = true; reloadTime = 0.2; fireTime = 2.0; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 1.0, 0, 0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; }; ItemData Railgun { description = "Railgun"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = RailgunImage; price = 375; showWeaponBar = true; };
ItemData VulcanAmmo { description = "Vulcan Bullet"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; }; ItemImageData VulcanImage { shapeFile = "chaingun"; mountPoint = 0; weaponType = 1; reloadTime = 0.1; spinUpTime = 0.5; spinDownTime = 3; fireTime = 0.09; ammoType = VulcanAmmo; projectileType = VulcanBullet; accuFire = true; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1 }; sfxFire = SoundFireChaingun; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; }; ItemData Vulcan { description = "Vulcan"; className = "Weapon"; shapeFile = "chaingun"; hudIcon = "chain"; heading = "bWeapons"; shadowDetailMask = 4; imageType = VulcanImage; price = 125; showWeaponBar = true; };
ItemImageData FlamerImage { shapeFile = "GrenadeL"; mountPoint = 0; weaponType = 0; reloadTime = 0.2; fireTime = 0.1; minEnergy = 9; maxEnergy = 11; projectileType = FlamerBolt; accuFire = true; sfxFire = SoundJetHeavy; sfxActivate = SoundPickUpWeapon; }; ItemData Flamer { heading = "bWeapons"; description = "Flame Thrower"; className = "Weapon"; shapeFile = "GrenadeL"; hudIcon = "plasma"; shadowDetailMask = 4; imageType = FlamerImage; price = 385; showWeaponBar = true; };
ItemImageData IonGunImage { shapeFile = "GrenadeL"; mountPoint = 0; weaponType = 0; reloadTime = 0; fireTime = 0.3; minEnergy = 19; maxEnergy = 20; projectileType = IonBolt; accuFire = true; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; }; ItemData IonGun { heading = "bWeapons"; description = "Ion Rifle"; className = "Weapon"; shapeFile = "GrenadeL"; hudIcon = "targetlaser"; shadowDetailMask = 4; imageType = IonGunImage; price = 250; showWeaponBar = true; };
ItemImageData OmegaImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; reloadTime = 0.05; fireTime = 0; minEnergy = 5; maxEnergy = 6; projectileType = OmegaBolt; accuFire = false; sfxFire = SoundJetHeavy; sfxActivate = SoundPickUpWeapon; }; ItemData Omega { heading = "bWeapons"; description = "Omega Cannon"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "plasma"; shadowDetailMask = 4; imageType = OmegaImage; price = 385; showWeaponBar = true; };
ItemImageData EnergyRifleImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 2; projectileType = boltCharge; minEnergy = 3; maxEnergy = 15; reloadTime = 0.2; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 0.25, 0.25, 0.85 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundELFIdle; }; ItemData EnergyRifle { description = "Thunderbolt"; shapeFile = "shotgun"; hudIcon = "energyRifle"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = EnergyRifleImage; showWeaponBar = true; price = 500; validateShape = true; };
ItemImageData TargetingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = targetLaser; accuFire = true; minEnergy = 5; maxEnergy = 15; reloadTime = 1.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; }; ItemData TargetingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TargetingLaserImage; price = 50; showWeaponBar = false; };
ItemImageData FixitImage { shapeFile = "repairgun"; mountPoint = 0; weaponType = 2; projectileType = RepairBolt; minEnergy = 5; maxEnergy = 15; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxFire = SoundRepairItem; sfxActivate = SoundPickUpWeapon; }; ItemData Fixit { description = "Engineer Repair-Gun"; className = "Tool"; shapeFile = "repairgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = FixitImage; price = 50; showWeaponBar = false; }; ItemData Backpack { description = "Backpack"; showInventory = false; }; function Backpack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::trigger(%player,$BackpackSlot); } }
ItemImageData DeployableInvPackImage { shapeFile = "invent_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; ItemData DeployableInvPack { description = "Inventory Station"; shapeFile = "invent_remote"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4 ; imageType = DeployableInvPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteInvEnergy + 200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableInvPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableInvPack::onDeploy(%player,%item,%pos) { if (DeployableInvPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableInvPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,"RMT Inv Station#" @ $totalNuminvs++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Inventory Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed an Inventory Station"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData DeployableAmmoPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 1.0; firstPerson = false; }; ItemData DeployableAmmoPack { description = "Ammo Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4; imageType = DeployableAmmoPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteAmmoEnergy; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableAmmoPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableAmmoPack::onDeploy(%player,%item,%pos) { if (DeployableAmmoPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableAmmoPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,"RMT Ammo Station#" @ $totalNuminvs++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Ammo Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed an Ammo Station"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData DeployableComPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 4.5; firstPerson = false; }; ItemData DeployableComPack { description = "Command Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4 ; imageType = DeployableComPackImage; mass = 4.0; elasticity = 0.2; price = $RemoteComEnergy + 200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableComPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableComPack::onDeploy(%player,%item,%pos) { if (DeployableComPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableComPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %inv = newObject("comunit_remote","StaticShape","DeployableComStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Command Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableComPack"]++; return true; } } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData EnergyPackImage { shapeFile = "jetPack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; minEnergy = -3; maxEnergy = -5; firstPerson = false; }; ItemData EnergyPack { description = "Energy Pack"; shapeFile = "jetPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = EnergyPackImage; price = 150; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function EnergyPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } function EnergyPack::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); } function EnergyPack::onUnmount(%player,%item) { if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) Player::unmountItem(%player,$WeaponSlot); }
ItemImageData RepairPackImage { shapeFile = "armorPack"; mountPoint = 2; weaponType = 2; minEnergy = 0; maxEnergy = 0; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; ItemData RepairPack { description = "Repair Pack"; shapeFile = "armorPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = RepairPackImage; price = 125; hudIcon = "repairpack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function RepairPack::onUnmount(%player,%item) { if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) { Player::unmountItem(%player,$WeaponSlot); } } function RepairPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::mountItem(%player,RepairGun,$WeaponSlot); } } function RepairPack::onDrop(%player,%item) { if($matchStarted) { %mounted = Player::getMountedItem(%player,$WeaponSlot); if (%mounted == RepairGun) { Player::unmountItem(%player,$WeaponSlot); } else { Player::mountItem(%player,%mounted,$WeaponSlot); } Item::onDrop(%player,%item); } }
ItemImageData ShieldPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; minEnergy = 4; maxEnergy = 9; sfxFire = SoundShieldOn; firstPerson = false; }; ItemData ShieldPack { description = "Shield Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = ShieldPackImage; price = 175; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function ShieldPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Shield On"); %player.shieldStrength = 0.012; } function ShieldPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Shield Off"); Player::trigger(%player,$BackpackSlot,false); %player.shieldStrength = 0; }
ItemImageData SensorJammerPackImage { shapeFile = "sensorjampack"; mountPoint = 2; weaponType = 2; maxEnergy = 10; sfxFire = SoundJammerOn; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; ItemData SensorJammerPack { description = "Sensor Jammer Pack"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = SensorJammerPackImage; price = 200; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function SensorJammerPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On"); %rate = Player::getSensorSupression(%player) + 20; Player::setSensorSupression(%player,%rate); } function SensorJammerPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off"); %rate = Player::getSensorSupression(%player) - 20; Player::setSensorSupression(%player,%rate); Player::trigger(%player,$BackpackSlot,false); }
ItemImageData CloakingDeviceImage { shapeFile = "sensorjampack"; mountPoint = 2; weaponType = 2; maxEnergy = 10; sfxFire = SoundJammerOn; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; ItemData CloakingDevice { description = "Cloaking Device"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = CloakingDeviceimage; price = 600; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; }; function CloakingDeviceImage::onActivate(%player,%imageSlot) { GameBase::startFadeout(%player); Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On"); %rate = Player::getSensorSupression(%player) + 5; Player::setSensorSupression(%player,%rate); %player.guiLock = true; %c = Player::getClient(%player); %c.guiLock = true; %clientId.ghostDoneFlag = true; startGhosting(%cl); } function CloakingDeviceImage::onDeactivate(%player,%imageSlot) { GameBase::startFadein(%player); Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off"); %rate = Player::getSensorSupression(%player) - 5; Player::setSensorSupression(%player,%rate); Player::trigger(%player,$BackpackSlot,false); %player.guiLock = ""; %c = Player::getClient(%player); %c.guiLock = ""; }
ItemImageData StealthShieldPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; minEnergy = 6; maxEnergy = 9; sfxFire = SoundShieldOn; firstPerson = false; }; ItemData StealthShieldPack { description = "StealthShield Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = StealthShieldPackImage; price = 275; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; }; function StealthShieldPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"StealthShield On"); %player.shieldStrength = 0.012; %rate = Player::getSensorSupression(%player) + 20; Player::setSensorSupression(%player,%rate); } function StealthShieldPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"StealthShield Off"); Player::trigger(%player,$BackpackSlot,false); %player.shieldStrength = 0; %rate = Player::getSensorSupression(%player) - 20; Player::setSensorSupression(%player,%rate); }
ItemImageData RegenerationPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; minEnergy = 8; maxEnergy = 14; sfxFire = SoundRepairItem; projectileType = AutoBolt; }; ItemData RegenerationPack { description = "Regeneration Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = RegenerationPackImage; price = 275; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; }; function RegenerationPackImage::onActivate(%player,%imageSlot) { %clientId = Player::getClient(%player); } function RegenerationPackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } function TransferHealth(%clientId, %player) { Client::sendMessage(%clientId,1,"Regeneration On"); Player::unmountItem(%player,$WeaponSlot); if($regTime[%clientId] == 0) { GameBase::setEnergy(%player,0); GameBase::setRechargeRate(%player,0); $regTime[%clientId] = 10; checkPlayerDrain(%clientId, %player); } else $regTime[%clientId] = 10; } function checkPlayerDrain(%clientId, %player) { if($regTime[%clientId] > 0) { $regTime[%clientId] -= 2; if(GameBase::getDamageLevel(%player)) { GameBase::repairDamage(%player,0.04); GameBase::playSound(%player,ForceFieldOpen,0); } schedule("checkPlayerDrain(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,1,"Regeneration Off"); GameBase::setRechargeRate(%player,8); } }
ItemImageData LightningPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; projectileType = boltCharge; minEnergy = 9; maxEnergy = 10; reloadTime = 0.2; sfxFire = SoundELFIdle; }; ItemData LightningPack { description = "Lightning Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = LightningPackImage; price = 275; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; }; function LightningPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Lightning Field On"); } function LightningPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Lightning Field Off"); Player::trigger(%player,$BackpackSlot,false); }
ItemImageData OpticPackImage { shapeFile = "repairgun"; mountPoint = 2; mountOffset = { 0.2, 0.4, 0.45 }; mountRotation = { 0, 0, 0 }; weaponType = 0; projectileType = SniperLaser; accuFire = true; reloadTime = 6.5; fireTime = 0.0; minEnergy = 10; maxEnergy = 60; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 1, 0, 0 }; sfxFire = SoundFireLaser; }; ItemData OpticPack { description = "Cybernetic Laser"; shapeFile = "repairgun"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = OpticPackImage; price = 275; hudIcon = "sniper"; showWeaponBar = true; hiliteOnActive = true; }; function OpticPackImage::onActivate(%player,%imageSlot) { schedule("use(\"backpack\");", 0.5); } function OpticPackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); }
ItemImageData SMRPackImage { shapeFile = "mortargun"; mountPoint = 2; mountOffset = { -0.4, 0.1, 0.4 }; mountRotation = { 0.2, 0, 0 }; weaponType = 0; ammoType = RocketAmmo; projectileType = StingerMissile; accuFire = true; reloadTime = 5.0; fireTime = 0.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxReload = SoundMortarReload; }; ItemData SMRPack { description = "Auto-Rocket Cannon"; shapeFile = "mortargun"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = SMRPackImage; price = 350; hudIcon = "mortar"; showWeaponBar = true; hiliteOnActive = true; }; function SMRPackImage::onActivate(%player,%imageSlot) { schedule("use(\"backpack\");", 0.5); } function SMRPackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); }
ItemImageData LaptopImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; weaponType = 2; minEnergy = -1; maxEnergy = -3; mass = 0.5; firstPerson = false; }; ItemData Laptop { description = "Command Laptop"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = LaptopImage; price = 650; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; }; function Laptop::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } function Laptop::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); } function Laptop::onUnmount(%player,%item) { }
ItemImageData SuicidePackImage { shapeFile = "magcargo"; mountPoint = 2; mountOffset = { 0, -0.5, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; ItemData SuicidePack { description = "Suicide DetPack"; shapeFile = "magcargo"; className = "Backpack"; heading = "cBackpacks"; imageType = SuicidePackImage; shadowDetailMask = 4; mass = 2.5; elasticity = 0.2; price = 450; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function SuicidePack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else if(%player.station == "") { Player::deployItem(%player,%item); } } function SuicidePack::onUnmount(%player,%item) { } function SuicidePack::onDeploy(%player,%item,%pos) { if (SuicidePack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function SuicidePack::deployShape(%player,%item) { Player::unmountItem(%player,$BackpackSlot); %obj = newObject("","Mine","Suicidebomb2"); addToSet("MissionCleanup", %obj); %client = Player::getClient(%player); GameBase::throw(%obj,%player,4,false); Client::sendMessage(%client,1,"Det Pack will destruct in 20 seconds"); }
ItemImageData MotionSensorPackImage { shapeFile = "sensor_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; ItemData MotionSensorPack { description = "Motion Sensor"; shapeFile = "sensor_small"; className = "Backpack"; heading = "dDeployables"; imageType = MotionSensorPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 125; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function MotionSensorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function MotionSensorPack::onDeploy(%player,%item,%pos) { if (MotionSensorPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++; } } function MotionSensorPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %mSensor = newObject("","Sensor",DeployableMotionSensor,true); addToSet("MissionCleanup", %mSensor); GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); GameBase::setRotation(%mSensor,%rot); GameBase::setPosition(%mSensor,$los::position); Gamebase::setMapName(%mSensor,"Motion Sensor"); Client::sendMessage(%client,0,"Motion Sensor deployed"); playSound(SoundPickupBackpack,$los::position); if($ConOutput != 3) if($ConOutput != 3) echo("MSG: ",%client," deployed a Motion Sensor"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData AmmoPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; firstPerson = false; }; ItemData AmmoPack { description = "Ammo Pack"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "cBackpacks"; imageType = AmmoPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 325; hudIcon = "ammopack"; showWeaponBar = true; hiliteOnActive = true; }; function AmmoPack::onDrop(%player, %item) { if($matchStarted) { %item = Item::onDrop(%player,%item); for(%i = 0; %i < 14 ; %i = %i +1) { %numPack = 0; %ammoItem = $AmmoPackItems[%i]; %maxnum = $ItemMax[Player::getArmor(%player), %ammoItem]; %pCount = Player::getItemCount(%player, %ammoItem); if(%pCount > %maxnum) { %numPack = %pCount - %maxnum; Player::decItemCount(%player,%ammoItem,%numPack); } if(%i == 0) { %item.BulletAmmo = %numPack; } else if(%i == 1) { %item.PlasmaAmmo = %numPack; } else if(%i == 2) { %item.DiscAmmo = %numPack; } else if(%i == 3) { %item.GrenadeAmmo = %numPack; } else if(%i == 4) { %item.Grenade = %numPack; } else if(%i == 5) { %item.MortarAmmo = %numPack; } else if(%i == 6) { %item.RocketAmmo = %numPack; } else if(%i == 7) { %item.SniperAmmo = %numPack; } else if(%i == 8) { %item.RailAmmo = %numPack; } else if(%i == 9) { %item.SilencerAmmo = %numPack; } else if(%i == 10) { %item.VulcanAmmo = %numPack; } else if(%i == 11) { %item.Beacon = %numPack; } else if(%i == 12) { %item.TranqAmmo = %numPack; } else { %item.MineAmmo = %numPack; } } } } function AmmoPack::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { %item = Item::getItemData(%this); %count = Player::getItemCount(%object,%item); if (Item::giveItem(%object,%item,Item::getCount(%this))) { Item::playPickupSound(%this); checkPacksAmmo(%object, %this); Item::respawn(%this); } } } function checkPacksAmmo(%player, %item) { for(%i = 0; %i < 14 ; %i = %i +1) { %ammoItem = $AmmoPackItems[%i]; if(%i == 0) { %numAdd = %item.BulletAmmo; } else if(%i == 1) { %numAdd = %item.PlasmaAmmo; } else if(%i == 2) { %numAdd = %item.DiscAmmo; } else if(%i == 3) { %numAdd = %item.GrenadeAmmo; } else if(%i == 4) { %numAdd = %item.Grenade; } else if(%i == 5) { %numAdd = %item.MortarAmmo; } else if(%i == 6) { %numAdd = %item.RocketAmmo; } else if(%i == 7) { %numAdd = %item.SniperAmmo; } else if(%i == 8) { %numAdd = %item.RailAmmo; } else if(%i == 9) { %numAdd = %item.SilencerAmmo; } else if(%i == 10) { %numAdd = %item.VulcanAmmo; } else if(%i == 11) { %numAdd = %item.Beacon; } else if(%i == 12) { %numAdd = %item.TranqAmmo; } else { %numAdd = %item.MineAmmo; } Player::incItemCount(%player,%ammoItem,%numAdd); } } function fillAmmoPack(%client) { %player = Client::getOwnedObject(%client); for(%i = 0; %i < 14 ; %i = %i +1) { %item = $AmmoPackItems[%i]; %maxnum = $AmmoPackMax[%item]; %maxnum = checkResources(%player,%item,%maxnum); if(%maxnum) { Player::incItemCount(%client,%item,%maxnum); teamEnergyBuySell(%player,%item.price * %maxnum * -1); } } }
ItemImageData PulseSensorPackImage { shapeFile = "radar_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; ItemData PulseSensorPack { description = "Pulse Sensor"; shapeFile = "radar_small"; className = "Backpack"; heading = "dDeployables"; imageType = PulseSensorPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 125; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function PulseSensorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function PulseSensorPack::onDeploy(%player,%item,%pos) { if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++; } }
ItemImageData DeployableSensorJamPackImage { shapeFile = "sensor_jammer"; mountPoint = 2; mountOffset = { 0, 0.03, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; ItemData DeployableSensorJammerPack { description = "Sensor Jammer"; shapeFile = "sensor_jammer"; className = "Backpack"; heading = "dDeployables"; imageType = DeployableSensorJamPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 225; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableSensorJammerPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableSensorJammerPack::onDeploy(%player,%item,%pos) { if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++; } }
ItemImageData CameraPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; ItemData CameraPack { description = "Camera"; shapeFile = "camera"; className = "Backpack"; heading = "dDeployables"; imageType = CameraPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 100; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function CameraPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function CameraPack::onDeploy(%player,%item,%pos) { if (CameraPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function CameraPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",CameraTurret,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Camera deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; echo("MSG: ",%client," deployed a Camera"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData TurretPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; ItemData TurretPack { description = "Ion Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = TurretPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 350; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TurretPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TurretPack::onDeploy(%player,%item,%pos) { if (TurretPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function TurretPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableTurret,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"RMT Ion Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Remote Ion Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Remote Turret"); Client::setOwnedObject(%client,%turret); Client::setOwnedObject(%client,%player); return true; } } else Client::sendMessage(%client, 0, "Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData LaserPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; ItemData LaserPack { description = "Laser Turret"; shapeFile = "camera"; className = "Backpack"; heading = "dDeployables"; imageType = CameraPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 300; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function LaserPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function LaserPack::onDeploy(%player,%item,%pos) { if (LaserPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function LaserPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableLaser",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",DeployableLaser,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Laser Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++; return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else Client::sendMessage(%client,0,"Interference from other laser turrets in the area"); } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData ShockPackImage { shapeFile = "indoorgun"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; ItemData ShockPack { description = "Shock Turret"; shapeFile = "indoorgun"; className = "Backpack"; heading = "dDeployables"; imageType = ShockPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function ShockPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function ShockPack::onDeploy(%player,%item,%pos) { if (ShockPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function ShockPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableShock",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %camera = newObject("Camera","Turret",DeployableShock,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Shock Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Shock Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "ShockPack"]++; return true; } else Client::sendMessage(%client,0,"Interference from other Shock turrets in the area"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData TargetPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; ItemData TargetPack { description = "Mortar Turret"; shapeFile = "mortar_turret"; className = "Backpack"; heading = "dDeployables"; imageType = TargetPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 800; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TargetPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TargetPack::onMount(%player,%item) { %client = Player::getClient(%player); Bottomprint(%client, "<jc>The Mortar Turret has no auto-sensor and must be controlled manually to fire."); } function TargetPack::onDeploy(%player,%item,%pos) { if (TargetPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function TargetPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableMortar",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableMortar,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"Mortar Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Remote Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TargetPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Remote Turret"); Client::setOwnedObject(%client, %turret); Client::setOwnedObject(%client, %player); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData LaserTurretImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; ItemData LaserTurret { description = "Plasma Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = LaserTurretImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 650; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function LaserTurret::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function LaserTurret::onDeploy(%player,%item,%pos) { if (LaserTurret::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function LaserTurret::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("hellfiregun","Turret",DeployablePlasma,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Plasma Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "LaserTurret"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData VulcanTurretImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; ItemData VulcanTurret { description = "Vulcan Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = VulcanTurretImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 750; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function VulcanTurret::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function VulcanTurret::onDeploy(%player,%item,%pos) { if (VulcanTurret::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function VulcanTurret::onMount(%player,%item) { %client = Player::getClient(%player); Bottomprint(%client, "The Vulcan Turret has no auto-sensor and must be controlled manually to fire."); } function VulcanTurret::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableVulcan",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("hellfiregun","Turret",DeployableVulcan,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"Vulcan Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Vulcan Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "VulcanTurret"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData RailTurretImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; ItemData RailTurret { description = "Rail Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = VulcanTurretImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 850; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function RailTurret::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function RailTurret::onDeploy(%player,%item,%pos) { if (RailTurret::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function RailTurret::onMount(%player,%item) { %client = Player::getClient(%player); Bottomprint(%client, "<jc>The Rail Turret has no auto-sensor and must be controlled manually to fire."); } function RailTurret::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableVulcan",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("hellfiregun","Turret",DeployableRail,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"Rail Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Rail Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData RocketPackImage { shapeFile = "logo"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 3.0; firstPerson = false; }; ItemData RocketPack { description = "Missile Turret"; shapeFile = "logo"; className = "Backpack"; heading = "dDeployables"; imageType = RocketPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 950; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function RocketPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function RocketPack::onDeploy(%player,%item,%pos) { if (RocketPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function RocketPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("missileturret","Turret",DeployableRocket,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"Missile#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Missile Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData ForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; ItemData ForceFieldPack { description = "Force Field"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = ForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function ForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function ForceFieldPack::onDeploy(%player,%item,%pos) { if (ForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function ForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %smff = newObject("","StaticShape",DeployableForceField,true); addToSet("MissionCleanup", %smff); GameBase::setTeam(%smff,GameBase::getTeam(%player)); GameBase::setPosition(%smff,$los::position); GameBase::setRotation(%smff,%rot); Gamebase::setMapName(%smff,"Force Field#" @ $totalNumsmffs++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Force Field Deployed"); GameBase::startFadeIn(%smff); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++; return true; } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData LargeForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; ItemData LargeForceFieldPack { description = "Large Force Field"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = LargeForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 1200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function LargeForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function LargeForceFieldPack::onDeploy(%player,%item,%pos) { if (LargeForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function LargeForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %lrgff = newObject("","StaticShape",LargeForceField,true); addToSet("MissionCleanup", %lrgff); GameBase::setTeam(%lrgff,GameBase::getTeam(%player)); GameBase::setPosition(%lrgff,$los::position); GameBase::setRotation(%lrgff,%rot); Gamebase::setMapName(%lrgff,"Large Force Field#"@ $totalNumlrgffs++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Force Field Deployed"); GameBase::startFadeIn(%lrgff); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++; return true; } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData TripwirePackImage { shapeFile = "sensor_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; mass = 2.5; firstPerson = false; }; ItemData TripwirePack { description = "Blast Wall"; shapeFile = "sensor_small"; className = "Backpack"; heading = "dDeployables"; imageType = TripwirePackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TripwirePack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TripwirePack::onDeploy(%player,%item,%pos) { if (TripwirePack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function TripwirePack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %bwall = newObject("","StaticShape",BlastWall,true); addToSet("MissionCleanup", %bwall); GameBase::setTeam(%bwall,GameBase::getTeam(%player)); GameBase::setPosition(%bwall,$los::position); GameBase::setRotation(%bwall,%rot); Gamebase::setMapName(%bwall,"Blast Wall"); Client::sendMessage(%client,0,"Blast Wall Deployed"); GameBase::startFadeIn(%bwall); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TripwirePack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData HoloPackImage { shapeFile = "ShieldPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 1.0; firstPerson = false; }; ItemData HoloPack { description = "Hologram"; shapeFile = "ShieldPack"; className = "Backpack"; heading = "dDeployables"; imageType = HoloPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 900; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function HoloPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function HoloPack::onDeploy(%player,%item,%pos) { if (HoloPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function HoloPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"Hologram",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %rnd = floor(getRandom() * 10); if(%rnd > 6) %holo = newObject("","StaticShape",Hologram1,true); else if((%rnd > 2) && (%rnd < 7)) %holo = newObject("","StaticShape",Hologram2,true); else %holo = newObject("","StaticShape",Hologram3,true); %armor = Player::getArmor(%player); if (%armor == "dmarmor" || %armor == "dmfemale") { %holo = newObject("","StaticShape",Hologram2,true); } addToSet("MissionCleanup", %holo); GameBase::setTeam(%holo,GameBase::getTeam(%player)); GameBase::setPosition(%holo,$los::position); GameBase::setRotation(%holo,%rot); Client::sendMessage(%client,0,"Hologram Deployed"); GameBase::startFadeIn(%holo); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData TreePackImage { shapeFile = "tree1"; mountPoint = 2; mountOffset = { 0, 0.15, -1 }; mass = 2.5; firstPerson = false; }; ItemData TreePack { description = "Mechanical Tree"; shapeFile = "sensor_jammer"; className = "Backpack"; heading = "dDeployables"; imageType = TreePackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TreePack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TreePack::onDeploy(%player,%item,%pos) { if (TreePack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function TreePack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableTree",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %rnd = floor(getRandom() * 10); if(%rnd > 5) %dtree = newObject("","StaticShape",DeployableTree,true); else %dtree = newObject("","StaticShape",DeployableTree2,true); addToSet("MissionCleanup", %dtree); GameBase::setTeam(%dtree,GameBase::getTeam(%player)); GameBase::setPosition(%dtree,$los::position); GameBase::setRotation(%dtree,%rot); Gamebase::setMapName(%dtree,"Mechanical Tree"); Client::sendMessage(%client,0,"Mechanical Tree Deployed"); GameBase::startFadeIn(%dtree); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData SpringPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; ItemData SpringPack { description = "Springboard"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = SpringPackImage; shadowDetailMask = 4; mass = 1.0; elasticity = 0.2; price = 500; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function SpringPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function SpringPack::onDeploy(%player,%item,%pos) { if (SpringPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function SpringPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableSpring",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %spring = newObject("","StaticShape",DeployableSpring,true); addToSet("MissionCleanup", %spring); GameBase::setTeam(%spring,GameBase::getTeam(%player)); GameBase::setPosition(%spring,$los::position); GameBase::setRotation(%spring,%rot); Gamebase::setMapName(%spring,"Springboard"); Client::sendMessage(%client,0,"Springboard Deployed"); GameBase::startFadeIn(%spring); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData PlatformPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; ItemData PlatformPack { description = "Deployable Platform"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = PlatformPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function PlatformPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function PlatformPack::onDeploy(%player,%item,%pos) { if (PlatformPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function PlatformPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %rot = GameBase::getRotation(%player); %plat = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true); addToSet("MissionCleanup", %plat); GameBase::setTeam(%plat,GameBase::getTeam(%player)); GameBase::setPosition(%plat,$los::position); GameBase::setRotation(%plat,%rot); Gamebase::setMapName(%plat,"Deployable Platform"); Client::sendMessage(%client,0,"Platform Deployed"); GameBase::startFadeIn(%plat); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++; return true; } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData TeleportPackImage { shapeFile = "flagstand"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; ItemData TeleportPack { description = "Teleport Pad"; shapeFile = "flagstand"; className = "Backpack"; heading = "dDeployables"; imageType = TeleportPackImage; shadowDetailMask = 4; mass = 5.0; elasticity = 0.2; price = 3200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function NeedTeleportSimSet() { %teleset = nameToID("MissionCleanup/Teleports"); if (%teleset == -1) { newObject(Teleports, SimSet); addToSet(MissionCleanup, Teleports); } } function TeleportPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TeleportPack::onDeploy(%player,%item,%pos) { if (teleportPack::deployShape(%player, "Teleport Pad", DeployableTeleport, %item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++; } } function TeleportPack::deployShape(%player, %name, %shape, %item) { %client = Player::getClient(%player); if ($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] >= $TeamItemMax[DeployableTeleport]) { Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); return false; } if (!GameBase::getLOSInfo(%player,3)) { Client::sendMessage(%client,0,"Deploy position out of range"); return false; } %obj = getObjectType($los::object); if (%obj != "SimTerrain" && %obj != "InteriorShape") { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); return false; } if (!GameBase::testPosition(%player, vector::add($los::position, "0 0 1"))) { Client::sendMessage(%client,0,"Teleport does not fit there"); return; } if (Vector::dot($los::normal,"0 0 1") <= 0.7) { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; } if (!checkDeployArea(%client,$los::position)) { return false; } NeedTeleportSimSet(); %pos = Vector::add($los::position,"0 0 0.8"); %objTeleport = newObject("Teleport Pad", "StaticShape", %shape, true); %objTeleport.Functional = true; GameBase::setPosition(%objTeleport,%pos); GameBase::setTeam(%objTeleport,GameBase::getTeam(%player)); Gamebase::setMapName(%objTeleport,%name); addToSet("MissionCleanup/Teleports", %objTeleport); addToSet("MissionCleanup", %objTeleport); %beam = newObject("", "StaticShape", ElectricalBeamBig, true); GameBase::setPosition(%beam,%pos); GameBase::setTeam(%beam,GameBase::getTeam(%player)); addToSet("MissionCleanup", %beam); %objTeleport.beam1 = %beam; %objTeleport.disabled = false; playSound(SoundPickupBackpack, $los::position); Client::sendMessage(%client, 0, %item.description @ " deployed"); return true; }
ItemImageData MechPackImage { shapeFile = "logo"; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; mass = 2.5; firstPerson = false; }; ItemData MechPack { description = "Interceptor Pack"; shapeFile = "liqcyl"; className = "Backpack"; heading = "dDeployables"; imageType = MechPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function MechPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function MechPack::onDeploy(%player,%item,%pos) { if (MechPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function MechPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"] < $TeamItemMax[JetVehicle]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { if(checkFlierArea(%client, $los::position)) { %rot = GameBase::getRotation(%player); %phase = newObject("",flier,Jet,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Client::sendMessage(%client,0,"Piloting Interceptor"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"]++; return true; } } } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemImageData DetPackImage { shapeFile = "logo"; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; mass = 2.5; firstPerson = false; }; ItemData DetPack { description = "StealthHPC Pack"; shapeFile = "liqcyl"; className = "Backpack"; heading = "dDeployables"; imageType = DetPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 1600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DetPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DetPack::onDeploy(%player,%item,%pos) { if (DetPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DetPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] < $TeamItemMax[HAPCVehicle]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { if(checkFlierArea(%client, $los::position)) { %rot = GameBase::getRotation(%player); %phase = newObject("",flier,HAPC,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"HPC Pack"); Client::sendMessage(%client,0,"Deployed StealthHPC"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++; return true; } } } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
ItemData RepairKit { description = "Repair Kit"; shapeFile = "armorKit"; heading = "eMiscellany"; shadowDetailMask = 4; price = 35; validateShape = true; validateMaterials = true; }; function RepairKit::onUse(%player,%item) { if(!$matchStarted) return; Player::decItemCount(%player,%item); GameBase::repairDamage(%player,0.2); %c = Player::getClient(%player); $poisonTime[%c] = 0; }
ItemData MineAmmo { description = "Mine"; shapeFile = "mineammo"; heading = "eMiscellany"; shadowDetailMask = 4; price = 10; className = "HandAmmo"; }; function MineAmmo::onUse(%player,%item) { if($matchStarted) { if(%player.throwTime < getSimTime() ) { %armor = Player::getArmor(%player); %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%client) @ "mineammo"] < $TeamItemMax["mineammo"]) $TeamItemCount[GameBase::getTeam(%client) @ "mineammo"]++; else { Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return; } Player::decItemCount(%player,%item); eval(%armor @ "::onMine(" @ %player @ ");"); } } } function Armor::ThrowMine(%player, %obj) { addToSet("MissionCleanup", %obj); %client = Player::getClient(%player); GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; GameBase::setTeam (%obj,GameBase::getTeam (%client)); playSound(SoundThrowItem,GameBase::getPosition(%obj)); }
ItemData Grenade { description = "Grenade"; shapeFile = "grenade"; heading = "eMiscellany"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; validateShape = true; }; function Grenade::onUse(%player,%item) { if ($matchStarted && %player.throwTime < getSimTime()) { Player::decItemCount(%player,%item); %armor = Player::getArmor(%player); eval(%armor @ "::onGrenade(" @ %player @ ");"); } } function Armor::ThrowGrenade(%player, %obj) { addToSet("MissionCleanup", %obj); %client = Player::getClient(%player); GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; GameBase::setTeam (%obj,GameBase::getTeam (%client)); }
ItemData Beacon { description = "Beacon"; shapeFile = "sensor_small"; heading = "eMiscellany"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; validateShape = true; validateMaterials = true; }; function Beacon::onUse(%player,%item) { if(%player.station || !$matchStarted) return; %armor = Player::getArmor(%player); eval(%armor @ "::onBeacon(" @ %player @ ", " @ %item @ ");"); }
ItemData Boost { description = "Bot"; shapeFile = "sensor_small"; heading = "eMiscellany"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; }; function Boost::onUse(%player,%item) { %client = Player::getClient(%player); Training::setupAI(%client); }
ItemData RepairPatch { description = "Repair Patch"; className = "Repair"; shapeFile = "armorPatch"; heading = "eMiscellany"; shadowDetailMask = 4; price = 2; validateShape = true; validateMaterials = true; }; function RepairPatch::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { if(GameBase::getDamageLevel(%object)) { GameBase::repairDamage(%object,0.125); %c = Player::getClient(%object); $poisonTime[%c] = 0; %item = Item::getItemData(%this); Item::playPickupSound(%this); Item::respawn(%this); } } } function RepairPatch::onUse(%player,%item) { Player::decItemCount(%player,%item); GameBase::repairDamage(%player,0.1); }

function Renegades_startStim(%clientId, %player) { if($StimTime[%clientId] > 0) return; Client::sendMessage(%clientId,0,"You activated a Haul-Ass beacon!"); %armor = Player::getArmor(%player); %armor.maxForwardSpeed = 20; GameBase::playSound(%player,ForceFieldOpen,0); if($stimTime[%clientId] == 0) { $stimTime[%clientId] = 10; checkPlayerStim(%clientId, %player); } else $StimTime[%clientId] = 10; }
function checkPlayerStim(%clientId, %player) { if($StimTime[%clientId] > 0) { $StimTime[%clientId] -= 2; if (!Player::isDead(%player)) { } else { $StimTime[%clientId] = 0; %armor.maxForwardSpeed = 9; } schedule("checkPlayerStim(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,0,"Haul-Ass beacon depleted."); %armor = Player::getArmor(%player); %armor.maxForwardSpeed = 9; GameBase::playSound(%player,ForceFieldOpen,0); } }
function Renegades_startShield(%clientId, %player) { Client::sendMessage(%clientId,0,"Emergency Force Shields Activated"); GameBase::playSound(%player,ForceFieldOpen,0); %player.shieldStrength = 0.006; if($shieldTime[%clientId] == 0) { $shieldTime[%clientId] = 20; checkPlayerShield(%clientId, %player); } else $shieldTime[%clientId] = 20; }
function checkPlayerShield(%clientId, %player) { %armor = Player::getArmor(%player); if($shieldTime[%clientId] > 0) { $shieldTime[%clientId] -= 2; if ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale")) { if (Player::isDead(%player)) { } } else { $shieldTime[%clientId] = 0; } schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted"); %player.shieldStrength = 0; GameBase::playSound(%player,ForceFieldOpen,0); } }
function Renegades_startCloak(%clientId, %player) { %armor = Player::getArmor(%player); Client::sendMessage(%clientId,0,"Cloaking On"); GameBase::playSound(%player,ForceFieldOpen,0); GameBase::startFadeout(%player); %rate = Player::getSensorSupression(%player) + 3; Player::setSensorSupression(%player,%rate); if($cloakTime[%clientId] == 0) { $cloakTime[%clientId] = 30; checkPlayerCloak(%clientId, %player); } else $cloakTime[%clientId] = 30; }
function checkPlayerCloak(%clientId, %player) { %armor = Player::getArmor(%player); if($cloakTime[%clientId] > 0) { $cloakTime[%clientId] -= 2; if ( (!Player::isDead(%player)) && (%armor == "aarmor" || %armor == "afemale" || %armor == "dmarmor" || %armor == "dmfemale") ) { } else { $cloakTime[%clientId] = 0; } schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,0,"Cloaking Off"); GameBase::playSound(%player,ForceFieldOpen,0); GameBase::startFadein(%player); %rate = Player::getSensorSupression(%player) - 5; Player::setSensorSupression(%player,0); } }
function DeploySatchel(%clientId, %player, %bec) { %item = "SatchelPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",DeployableSatchel,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen."); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++; echo("MSG: ",%client," deployed a Satchel"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
function EngCamera(%clientId, %player, %bec) { %item = "CameraPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",CameraTurret,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Camera deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Camera"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
function SniperJammer(%clientId, %player, %bec) { %item = "DeployableSensorJammerPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("sensor_jammer","Sensor",DeployableSensorJammer,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"SensorJammer"); Client::sendMessage(%client,0,"SensorJammer deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "DeployableSensorJammerPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Sensor Jammer"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
function ScoutSensor(%clientId, %player, %bec) { %item = "PulseSensorPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("radar_small","Sensor",DeployablePulseSensor,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Pulse Sensor"); Client::sendMessage(%client,0,"Pulse Sensor deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "PulseSensorPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Pulse Sensor"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
function MotionSensor(%clientId, %player, %bec) { %item = "MotionSensorPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) %rot = "0 0 " @ %zRot; else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 " @ %zRot; else %rot = Vector::getRotation($los::normal); } if(checkDeployArea(%client,$los::position)) { %mSensor = newObject("","Sensor",DeployableMotionSensor,true); addToSet("MissionCleanup", %mSensor); GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); GameBase::setRotation(%mSensor,%rot); GameBase::setPosition(%mSensor,$los::position); Gamebase::setMapName(%mSensor,"Motion Sensor"); Client::sendMessage(%client,0,"Motion Sensor deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%mSensor) @ "MotionSensorPack"]++; Player::decItemCount(%player,%bec); return true; } } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }
function Armor::SpeedBooster(%player, %item, %power) { %vec = Item::getVelocity(%player); if (%vec == "0 0 0") %vec = "0 10 0"; %vec = Vector::Normalize(%vec); %vec = GetWord(%vec, 0) * %power @ " " @ GetWord(%vec, 1) * %power @ " " @ GetWord(%vec, 2) * %power; Player::applyImpulse(%player, %vec); Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster."); GameBase::playSound(%player, shockExplosion, 0); Player::decItemCount(%player,%item); }
$RepulsePower = 370; function Repulse(%player, %item) { %set = newObject("set",SimSet); %ppos = GameBase::getPosition(%player); %num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 50, 50, 50,0); for (%i=0; %i<%num; %i++) { %oply = Group::getObject(%set,%i); if (%oply != %player) { %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%oply), %ppos)); %vec = (getWord(%vec, 0) * $RepulsePower) @ " " @ (getWord(%vec, 1) * $RepulsePower) @ " " @ (getWord(%vec, 2) * $RepulsePower); Player::applyImpulse(%oply, %vec); } } deleteObject(%set); Client::sendMessage(Player::getClient(%player),0, "You use a Repulsion Beacon"); GameBase::playSound(%player, SoundFireMortar, 0); Player::decItemCount(%player,%item); }
function Armor::Vector(%player, %item) { %client = Player::getClient(%player); if(GameBase::getEnergy(%player) < Player::getArmor(%player).maxEnergy * 0.5) { bottomprint(%client,"<jc>Energy level is too low to Vector."); GameBase::playSound(%player, SoundBeaconUse, 0); return; } if(GameBase::getLOSInfo(%player,245)) { if(Vector::dot($los::normal,"0 0 1") > 0.7) { %type = Player::getMountedItem(%player,$FlagSlot); if(%type != -1) { centerprint(%client,"<jc>Flags can not undergo vector teleportation."); GameBase::playSound(%player, SoundBeaconUse, 0); Player::dropItem(%client,%type); } else bottomprint(%client,"<jc>Energy systems depleted."); GameBase::setPosition(%player,$los::position); playSound(SoundFireLaser,GameBase::getPosition(%player)); GameBase::setEnergy(%player,0); GameBase::setRechargeRate(%player,1); Player::decItemCount(%player,%item); schedule("Vector::Recharge("@%player@");",20,%player); } else bottomprint(%client,"<jc>Could not get a valid lock at the location."); GameBase::playSound(%player, SoundBeaconUse, 0); } else bottomprint(%client,"<jc>Location is out of range."); GameBase::playSound(%player, SoundBeaconUse, 0); }
function Vector::Recharge(%player) { if(%player != -1) { %client = Player::getClient(%player); GameBase::setRechargeRate(%player,8); bottomprint(%client,"<jc>Energy system recharging."); } }


// This ones for sal900 :) *ZOD
function remoteGiveAll(%clientId)
{
	if(!%clientId.isAdmin)
	{
		messageAll(1, "Server: For tryin to use the GiveAll cheat, AutoKicking: " @ Client::getName(%clientId));
		echo("SERVER: For tryin to use the GiveAll cheat, AutoKicking: " @ Client::getName(%clientId));
		BanList::add(Client::getTransportAddress(%clientId), 240);
		centerprint(%clientId, "<jc><f2>Did you really think you could get away with it? \n\nsal9000 is WIN, you are LOSE. Bye idiot!", 8);
		schedule("Net::kick(" @ %clientId @ ");", 8);
		if ($ExportCKicks)
		{
			%ip = Client::getTransportAddress(%clientId);
			$GiveAll = Client::getName(%clientId) @ " " @ %ip;
			export("GiveAll", "config\\KickList.log", true);
			$GiveAll = "";
		}
	}
}

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
				%numsell = %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon)
			{
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0)
			{
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
	if($TeamEnergy[%team] != "Infinite")
	{
		if(%client.teamEnergy > ($InitialPlayerEnergy * -1) )
		{
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

	$TeamItemCount[0 @ RocketPack] = 0;
	$TeamItemCount[1 @ RocketPack] = 0;
	$TeamItemCount[2 @ RocketPack] = 0;
	$TeamItemCount[3 @ RocketPack] = 0;
	$TeamItemCount[4 @ RocketPack] = 0;
	$TeamItemCount[5 @ RocketPack] = 0;
	$TeamItemCount[6 @ RocketPack] = 0;
	$TeamItemCount[7 @ RocketPack] = 0;

	$TeamItemCount[0 @ ForceFieldPack] = 0;
	$TeamItemCount[1 @ ForceFieldPack] = 0;
	$TeamItemCount[2 @ ForceFieldPack] = 0;
	$TeamItemCount[3 @ ForceFieldPack] = 0;
	$TeamItemCount[4 @ ForceFieldPack] = 0;
	$TeamItemCount[5 @ ForceFieldPack] = 0;
	$TeamItemCount[6 @ ForceFieldPack] = 0;
	$TeamItemCount[7 @ ForceFieldPack] = 0;

	$TeamItemCount[0 @ LaserPack] = 0;
	$TeamItemCount[1 @ LaserPack] = 0;
	$TeamItemCount[2 @ LaserPack] = 0;
	$TeamItemCount[3 @ LaserPack] = 0;
	$TeamItemCount[4 @ LaserPack] = 0;
	$TeamItemCount[5 @ LaserPack] = 0;
	$TeamItemCount[6 @ LaserPack] = 0;
	$TeamItemCount[7 @ LaserPack] = 0;

	$TeamItemCount[0 @ DeployableComPack] = 0;
	$TeamItemCount[1 @ DeployableComPack] = 0;
	$TeamItemCount[2 @ DeployableComPack] = 0;
	$TeamItemCount[3 @ DeployableComPack] = 0;
	$TeamItemCount[4 @ DeployableComPack] = 0;
	$TeamItemCount[5 @ DeployableComPack] = 0;
	$TeamItemCount[6 @ DeployableComPack] = 0;
	$TeamItemCount[7 @ DeployableComPack] = 0;

	$TeamItemCount[0 @ LaserTurret] = 0;
	$TeamItemCount[1 @ LaserTurret] = 0;
	$TeamItemCount[2 @ LaserTurret] = 0;
	$TeamItemCount[3 @ LaserTurret] = 0;
	$TeamItemCount[4 @ LaserTurret] = 0;
	$TeamItemCount[5 @ LaserTurret] = 0;
	$TeamItemCount[6 @ LaserTurret] = 0;
	$TeamItemCount[7 @ LaserTurret] = 0;

	$TeamItemCount[0 @ DeployableTeleport] = 0;
	$TeamItemCount[1 @ DeployableTeleport] = 0;
	$TeamItemCount[2 @ DeployableTeleport] = 0;
	$TeamItemCount[3 @ DeployableTeleport] = 0;
	$TeamItemCount[4 @ DeployableTeleport] = 0;
	$TeamItemCount[5 @ DeployableTeleport] = 0;
	$TeamItemCount[6 @ DeployableTeleport] = 0;
	$TeamItemCount[7 @ DeployableTeleport] = 0;

	$TeamItemCount[0 @ WraithVehicle] = 0;
	$TeamItemCount[1 @ WraithVehicle] = 0;
	$TeamItemCount[2 @ WraithVehicle] = 0;
	$TeamItemCount[3 @ WraithVehicle] = 0;
	$TeamItemCount[4 @ WraithVehicle] = 0;
	$TeamItemCount[5 @ WraithVehicle] = 0;
	$TeamItemCount[6 @ WraithVehicle] = 0;
	$TeamItemCount[7 @ WraithVehicle] = 0;

	$TeamItemCount[0 @ JetVehicle] = 0;
	$TeamItemCount[1 @ JetVehicle] = 0;
	$TeamItemCount[2 @ JetVehicle] = 0;
	$TeamItemCount[3 @ JetVehicle] = 0;
	$TeamItemCount[4 @ JetVehicle] = 0;
	$TeamItemCount[5 @ JetVehicle] = 0;
	$TeamItemCount[6 @ JetVehicle] = 0;
	$TeamItemCount[7 @ JetVehicle] = 0;

	$TeamItemCount[0 @ TripwirePack] = 0;
	$TeamItemCount[1 @ TripwirePack] = 0;
	$TeamItemCount[2 @ TripwirePack] = 0;
	$TeamItemCount[3 @ TripwirePack] = 0;
	$TeamItemCount[4 @ TripwirePack] = 0;
	$TeamItemCount[5 @ TripwirePack] = 0;
	$TeamItemCount[6 @ TripwirePack] = 0;
	$TeamItemCount[7 @ TripwirePack] = 0;

	$TeamItemCount[0 @ ShockPack] = 0;
	$TeamItemCount[1 @ ShockPack] = 0;
	$TeamItemCount[2 @ ShockPack] = 0;
	$TeamItemCount[3 @ ShockPack] = 0;
	$TeamItemCount[4 @ ShockPack] = 0;
	$TeamItemCount[5 @ ShockPack] = 0;
	$TeamItemCount[6 @ ShockPack] = 0;
	$TeamItemCount[7 @ ShockPack] = 0;

	$TeamItemCount[0 @ PlatformPack] = 0;
	$TeamItemCount[1 @ PlatformPack] = 0;
	$TeamItemCount[2 @ PlatformPack] = 0;
	$TeamItemCount[3 @ PlatformPack] = 0;
	$TeamItemCount[4 @ PlatformPack] = 0;
	$TeamItemCount[5 @ PlatformPack] = 0;
	$TeamItemCount[6 @ PlatformPack] = 0;
	$TeamItemCount[7 @ PlatformPack] = 0;

	$TeamItemCount[0 @ TreePack] = 0;
	$TeamItemCount[1 @ TreePack] = 0;
	$TeamItemCount[2 @ TreePack] = 0;
	$TeamItemCount[3 @ TreePack] = 0;
	$TeamItemCount[4 @ TreePack] = 0;
	$TeamItemCount[5 @ TreePack] = 0;
	$TeamItemCount[6 @ TreePack] = 0;
	$TeamItemCount[7 @ TreePack] = 0;

	$TeamItemCount[0 @ LargeForceFieldPack] = 0;
	$TeamItemCount[1 @ LargeForceFieldPack] = 0;
	$TeamItemCount[2 @ LargeForceFieldPack] = 0;
	$TeamItemCount[3 @ LargeForceFieldPack] = 0;
	$TeamItemCount[4 @ LargeForceFieldPack] = 0;
	$TeamItemCount[5 @ LargeForceFieldPack] = 0;
	$TeamItemCount[6 @ LargeForceFieldPack] = 0;
	$TeamItemCount[7 @ LargeForceFieldPack] = 0;

	$TeamItemCount[0 @ TargetPack] = 0;
	$TeamItemCount[1 @ TargetPack] = 0;
	$TeamItemCount[2 @ TargetPack] = 0;
	$TeamItemCount[3 @ TargetPack] = 0;
	$TeamItemCount[4 @ TargetPack] = 0;
	$TeamItemCount[5 @ TargetPack] = 0;
	$TeamItemCount[6 @ TargetPack] = 0;
	$TeamItemCount[7 @ TargetPack] = 0;

	$TeamItemCount[0 @ SpringPack] = 0;
	$TeamItemCount[1 @ SpringPack] = 0;
	$TeamItemCount[2 @ SpringPack] = 0;
	$TeamItemCount[3 @ SpringPack] = 0;
	$TeamItemCount[4 @ SpringPack] = 0;
	$TeamItemCount[5 @ SpringPack] = 0;
	$TeamItemCount[6 @ SpringPack] = 0;
	$TeamItemCount[7 @ SpringPack] = 0;

	$TeamItemCount[0 @ hologram] = 0;
	$TeamItemCount[1 @ hologram] = 0;
	$TeamItemCount[2 @ hologram] = 0;
	$TeamItemCount[3 @ hologram] = 0;
	$TeamItemCount[4 @ hologram] = 0;
	$TeamItemCount[5 @ hologram] = 0;
	$TeamItemCount[6 @ hologram] = 0;
	$TeamItemCount[7 @ hologram] = 0;

	$TeamItemCount[0 @ SatchelPack] = 0;
	$TeamItemCount[1 @ SatchelPack] = 0;
	$TeamItemCount[2 @ SatchelPack] = 0;
	$TeamItemCount[3 @ SatchelPack] = 0;
	$TeamItemCount[4 @ SatchelPack] = 0;
	$TeamItemCount[5 @ SatchelPack] = 0;
	$TeamItemCount[6 @ SatchelPack] = 0;
	$TeamItemCount[7 @ SatchelPack] = 0;

	$TeamItemCount[0 @ RailTurret] = 0;
	$TeamItemCount[1 @ RailTurret] = 0;
	$TeamItemCount[2 @ RailTurret] = 0;
	$TeamItemCount[3 @ RailTurret] = 0;
	$TeamItemCount[4 @ RailTurret] = 0;
	$TeamItemCount[5 @ RailTurret] = 0;
	$TeamItemCount[6 @ RailTurret] = 0;
	$TeamItemCount[7 @ RailTurret] = 0;

	$TeamItemCount[0 @ VulcanTurret] = 0;
	$TeamItemCount[1 @ VulcanTurret] = 0;
	$TeamItemCount[2 @ VulcanTurret] = 0;
	$TeamItemCount[3 @ VulcanTurret] = 0;
	$TeamItemCount[4 @ VulcanTurret] = 0;
	$TeamItemCount[5 @ VulcanTurret] = 0;
	$TeamItemCount[6 @ VulcanTurret] = 0;
	$TeamItemCount[7 @ VulcanTurret] = 0;

	$TeamItemCount[0 @ Holomine] = 0;
	$TeamItemCount[1 @ Holomine] = 0;
	$TeamItemCount[2 @ Holomine] = 0;
	$TeamItemCount[3 @ Holomine] = 0;
	$TeamItemCount[4 @ Holomine] = 0;
	$TeamItemCount[5 @ Holomine] = 0;
	$TeamItemCount[6 @ Holomine] = 0;
	$TeamItemCount[7 @ Holomine] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
