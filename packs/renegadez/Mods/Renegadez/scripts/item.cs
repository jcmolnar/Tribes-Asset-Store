$WaitThrowTime = 2; 
$ItemFavoritesKey = "Renegadez"; 
$ItemPopTime = 30; $ToolSlot=0; 
$WeaponSlot=0; $BackpackSlot=1; 
$FlagSlot=2; $DefaultSlot=3; 
$AutoUse[Blaster] = True; 
$AutoUse[Chaingun] = True; 
$AutoUse[PlasmaGun] = True; 
$AutoUse[Mortar] = True; 
$AutoUse[GrenadeLauncher] = True; 
$AutoUse[LaserRifle] = True; 
$AutoUse[EnergyRifle] = True; 
$AutoUse[TargetingLaser] = False; 
$AutoUse[Fixit] = False; 
$AutoUse[VehFixit] = False; 
$AutoUse[ChargeGun] = True; 
$Use[Blaster] = True; 

$SellAmmo[BulletAmmo] = 25; 
$SellAmmo[PlasmaAmmo] = 5; 
$SellAmmo[DiscAmmo] = 5; 
$SellAmmo[GrenadeAmmo] = 5; 
$SellAmmo[MortarAmmo] = 5; 
$SellAmmo[Beacon] = 5; 
$SellAmmo[Boost] = 5; 
$SellAmmo[MineAmmo] = 5; 
$SellAmmo[Grenade] = 5; 
$AmmoPackMax[BulletAmmo] = 150; 
$AmmoPackMax[PlasmaAmmo] = 30; 
$AmmoPackMax[DiscAmmo] = 15; 
$AmmoPackMax[GrenadeAmmo] = 15; 
$AmmoPackMax[MortarAmmo] = 10; 
$AmmoPackMax[MineAmmo] = 5; 
$AmmoPackMax[Grenade] = 5; 
$AmmoPackMax[Beacon] = 3; 
$AmmoPackItems[0] = BulletAmmo; 
$AmmoPackItems[1] = PlasmaAmmo; 
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo; 
$AmmoPackItems[4] = Grenade; 
$AmmoPackItems[5] = MineAmmo; 
$AmmoPackItems[6] = MortarAmmo; 
$AmmoPackItems[7] = Beacon; 
$TeamItemMax[DeployableAmmoPack] = 10; 
$TeamItemMax[DeployableInvPack] = 15; 
$TeamItemMax[DeathStarPack] = 3; 
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
$TeamItemMax[DoorfourbyeightForceFieldPack] = 3; 
$TeamItemMax[DoorfivebyfiveForceFieldPack] = 3; 
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

$WeaponAmmo[Blaster] = ""; 
$WeaponAmmo[PlasmaGun] = PlasmaAmmo; 
$WeaponAmmo[Chaingun] = BulletAmmo; 
$WeaponAmmo[DiscLauncher] = DiscAmmo; 
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo; 
$WeaponAmmo[Mortar] = Mortar; 
$WeaponAmmo[LaserRifle] = ""; 
$WeaponAmmo[EnergyRifle] = ""; 
$AutoUse[RocketLauncher] = True; 
$AutoUse[Stinger] = True; 
$AutoUse[SniperRifle] = True; 
$AutoUse[WaveGun] = True; 
$AutoUse[Railgun] = True; 
$AutoUse[Vulcan] = True; 
$AutoUse[Silencer] = True; 
$AutoUse[IonGun] = True; 
$AutoUse[TranqGun] = True; 
$AutoUse[HyperB] = True; 
$AutoUse[Omega] = True; 

///////////////////////////////////////////////////////////////////
////////                 Static Armors                /////////////
///////////////////////////////////////////////////////////////////
$ArmorType[Male, ScoutArmor] = sarmor;
$ArmorType[Female, ScoutArmor] = sfemale; 
$ArmorType[Male, DragArmor] = darmor;
$ArmorType[Female, DragArmor] = darmor;
$ArmorType[Male, AlArmor] = aarmor; 
$ArmorType[Female, AlArmor] = afemale; 
$ArmorType[Male, EngArmor] = earmor; 
$ArmorType[Female, EngArmor] = efemale;
$ArmorType[Male, MediumArmor] = marmor; 
$ArmorType[Female, MediumArmor] = mfemale; 

$ArmorName[mfemale] = MediumArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[earmor] = EngArmor; 
$ArmorName[efemale] = EngArmor; 
$ArmorName[darmor] = DragArmor; 
$ArmorName[aarmor] = AlArmor; 
$ArmorName[afemale] = AlArmor;
$ArmorName[sfemale] = ScoutArmor; 
$ArmorName[sarmor] = ScoutArmor; 

////////////////////////////////////////////////////////////////////
////////                Renegadez Armors              //////////////
////////////////////////////////////////////////////////////////////
//if($BaseAddons && $ArmorName[larmor] == LightArmor)
if($BaseAddons)
{
$ArmorName[larmor] = LightArmor;
$ArmorName[lfemale] = LightArmor; 

$ArmorName[harmor] = HeavyArmor; 

$ArmorName[bfemale] = BusterArmor;
$ArmorName[barmor] = BusterArmor; 

$ArmorName[spyarmor] = SpArmor; 
$ArmorName[spyfemale] = SpArmor;
 
$ArmorName[dmarmor] = DHMArmor; 
$ArmorName[dmfemale] = DHMArmor; 

$ArmorType[Male, SpArmor] = spyarmor; 
$ArmorType[Female, SpArmor] = spyfemale;
 
$ArmorType[Male, BusterArmor] = barmor; 
$ArmorType[Female, BusterArmor] = bfemale;

$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Male, LightArmor] = larmor; 

$ArmorType[Male, HeavyArmor] = harmor; 
$ArmorType[Female, HeavyArmor] = harmor; 

$ArmorType[Male, DHMArmor] = dmarmor; 
$ArmorType[Female, DHMArmor] = dmfemale;
}
 
////////////////////////////////////////////////////////////////////
/////////               Renegades Armors              //////////////
////////////////////////////////////////////////////////////////////
//if(!$BaseAddons && $ArmorName[larmor] != LightArmor1)
if(!$BaseAddons)
{
$ArmorName[larmor] = LightArmor1;
$ArmorName[lfemale] = LightArmor1; 

$ArmorName[harmor] = HeavyArmor1; 

$ArmorName[bfemale] = BursterArmor;
$ArmorName[barmor] = BursterArmor; 

$ArmorName[spyarmor] = SpArmor1; 
$ArmorName[spyfemale] = SpArmor1;


$ArmorType[Male, SpArmor1] = spyarmor; 
$ArmorType[Female, SpArmor1] = spyfemale;
 
$ArmorType[Male, BursterArmor] = barmor; 
$ArmorType[Female, BursterArmor] = bfemale;

$ArmorType[Female, LightArmor1] = lfemale;
$ArmorType[Male, LightArmor1] = larmor; 

$ArmorType[Male, HeavyArmor1] = harmor; 
$ArmorType[Female, HeavyArmor1] = harmor; 
}




$SellAmmo[RocketAmmo] = 3; 
$SellAmmo[StingerAmmo] = 1; 
$SellAmmo[SniperAmmo] = 20; 
$SellAmmo[RailAmmo] = 25; 
$SellAmmo[SilencerAmmo] = 25;
$SellAmmo[VulcanAmmo] = 100; 
$SellAmmo[TranqAmmo] = 2;
$AmmoPackMax[StingerAmmo] = 1; 
$AmmoPackMax[RocketAmmo] = 10; 
$AmmoPackMax[SniperAmmo] = 10; 
$AmmoPackMax[RailAmmo] = 5; 
$AmmoPackMax[VulcanAmmo] = 100; 
$AmmoPackMax[TranqAmmo] = 20; 
$AmmoPackMax[SilencerAmmo] = 25;
$AmmoPackItems[17] = StingerAmmo; 
$AmmoPackItems[8] = RocketAmmo; 
$AmmoPackItems[9] = SniperAmmo; 
$AmmoPackItems[10] = RailAmmo; 
$AmmoPackItems[11] = VulcanAmmo; 
$AmmoPackItems[12] = SilencerAmmo; 
$AmmoPackItems[13] = TranqAmmo;
$TeamItemMax[FloorDoorPack] = 10; 
$TeamItemMax[ProbeDroidPack] = 5; 
$TeamItemMax[HAPCAssaultVehicle] = 1;
$TeamItemMax[BaseCloakPack] = 1; 
$TeamItemMax[Hider] = 5;
$TeamItemMax[RegenGenPack] = 1;
$TeamItemMax[CommandShipPack] = 1; 
$TeamItemMax[JailPack] = 1;
$TeamItemMax[LaserTurret] = 6; 
$TeamItemMax[RailTurret] = 2; 
$TeamItemMax[VulcanTurret] = 2; 
$TeamItemMax[RocketPack] = 3; 
$TeamItemMax[DeployableComPack] = 5; 
$TeamItemMax[ForceFieldPack] = 10; 
$TeamItemMax[LargeForceFieldPack] = 4; 
$TeamItemMax[BarragePack] = 5; 
$TeamItemMax[TrackingTurretPack] = 2; 
$TeamItemMax[LaserPack] = 6; 
$TeamItemMax[TripwirePack] = 20; 
$TeamItemMax[DeployableTeleport] = 2; 
$TeamItemMax[PlatformPack] = 25; 
$TeamItemMax[TreePack] = 25; 
$TeamItemMax[WraithVehicle] = 2; 
$TeamItemMax[JetVehicle] = 5; 
$TeamItemMax[SpringPack] = 15; 
$TeamItemMax[DefenseAlarm] = 3; 
$TeamItemMax[hologram] = 15; 
$TeamItemMax[holomine] = 15; 
$TeamItemMax[SatchelPack] = 25; 
$TeamItemMax[ShockPack] = 4; 
$TeamItemMax[TargetPack] = 2; 
$WeaponAmmo[RocketLauncher] = RocketAmmo; 
$WeaponAmmo[Stinger] = StingerAmmo; 
$WeaponAmmo[SniperRifle] = SniperAmmo; 
$WeaponAmmo[Railgun] = RailAmmo; 
$WeaponAmmo[WaveGun] = ""; 
$WeaponAmmo[IonGun] = ""; 
$WeaponAmmo[Flamer] = ""; 
$WeaponAmmo[Omega] = ""; 
$WeaponAmmo[Silencer] = SilencerAmmo; 
$WeaponAmmo[Vulcan] = VulcanAmmo; 
$WeaponAmmo[TranqGun] = TranqAmmo; 

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
	else return 1; 
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
						if(%item.className != Armor && %item.className != Armor1 && %item.className != Armor2) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count)); 
							Player::setItemCount(%client, %item, 0); 
					} 
				} 
			} 
			for (%i = 0; %i < 20; %i++) 
			{ 
				if(%favItem[%i] != "") 
				{ 
					%item = getItemData(%favItem[%i]); 
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client), %item] > Player::getItemCount(%client,%item) || %item.className == Armor || %item.className == Armor1 || %item.className == Armor2)) 
					{ 
						if(!buyItem(%client,%item)) 
							%error = 1; else %bought++; 
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
	if($TestCheats == 0 && %client.spawn == "") 
	{ 
		%energy = $TeamEnergy[%team]; 
		%station = %player.Station; 
		%sName = GameBase::getDataName(%station); 
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation)
		{ 
			%energy = %station.Energy; 
		} 
		if($Reneg::Cash)
		{
			if (%item.price * %delta > %client.cash) 
				%delta = %client.cash / %item.price;
			if(%delta < 1 ) 
			{ 
				if(%noMessage == "") 
					Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - $"@ %client.cash @ " left"); 
				return 0; 
			} 
		}
		else
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
	else if($TeamItemMax[%item] != "" && !$TestCheats) 
	{ 
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) 
		{ 
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
			return 0; 
		} 
	} 
	if(%item.className != Armor1 && %item.className != Armor2 && %item.className != Armor && %item.className != Vehicle) 
	{ 
		%count = Player::getItemCount(%client,%item); 
		%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ; 
		if(%delta + %count >= %max) %delta = %max - %count; 
	} 
	return %delta; 
} 

function buyItem(%client,%item) 
{ 
	%player = Client::getOwnedObject(%client); 
	%armor = Player::getArmor(%client); 
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Armor1 || %item.className == Armor2 || %item.className == Vehicle || $TestCheats)) 
	{ 
		if (%item.className == Armor || %item.className == Armor1 || %item.className == Armor2)
		{ 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0) 
			{ 
				teamEnergyBuySell(%player,$ArmorName[%armor].price); 
				if(checkResources(%player,%item,1)) 
				{ 
					if($Reneg::Cash && %client.spawn != 1)
					{
						%client.cash -= %item.price;
						Game::refreshClientScore(%Client);
					}
					else
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
						remoteSellItem(%client,30); 
					} 
				} 
				if($Reneg::Cash && %client.spawn != 1)
					%client.cash -= %item.price;
				else
					teamEnergyBuySell(%player,%pack.price); 
				Player::decItemCount(%client,%pack); 
			} 
			if (checkResources(%player,%item,1) || $testCheats) 
			{ 
				teamEnergyBuySell(%player,%item.price * -1); 
				Player::incItemCount(%client,%item); 
				Player::useItem(%client,%item); 
				if(%item == ammopack) fillAmmoPack(%client); 
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
				if($Reneg::Cash && %client.spawn != 1)
					%client.cash -= %item.price;
				else
					teamEnergyBuySell(%player,(%item.price * -1)); 
				%ammoItem = %item.imageType.ammoType; 
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
					if($Reneg::Cash && %client.spawn != 1)
						%client.cash -= %item.price;
					else
						teamEnergyBuySell(%player,(%item.price * -1)); 
					return 1; 
				} 
				else if(%shouldBuy == 2) return 1; 
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
				if($Reneg::Cash && %client.spawn != 1)
					%client.cash -= %item.price;
				else
					teamEnergyBuySell(%player,(%item.price * -1 * %delta)); 
				Player::incItemCount(%client,%item,%delta); return 1; 
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
	else Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav"); 
} 

function remoteSellItem(%client,%type) 
{ 
	if (isPlayerBusy(%client) || !testPlayerStat(%client)) 
		return; 
	%item = getItemData(%type); 
	%player = Client::getOwnedObject(%client); 
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) 
	{ 
		if(Player::getItemCount(%client,%item) && %item.className != Armor && %item.className != Armor1 && %item.className != Armor2) 
		{ 
			%numsell = 1; 
			if(%item.className == Ammo || %item.className == HandAmmo) 
			{ 
				%count = Player::getItemCount(%client, %item); 
				if(%count < $SellAmmo[%item]) %numsell = %count; else %numsell = $SellAmmo[%item]; } else if (%item == ammopack) checkMax(%client,Player::getArmor(%client)); else if($TeamItemMax[%item] != "") { if(%item.className == Vehicle) $TeamItemCount[(Client::getTeam(%client)) @ %item]--; } else if(%item == EnergyPack) { if(Player::getItemCount(%client,"LaserRifle") > 0) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle"); remoteSellItem(%client,30); } } teamEnergyBuySell(%player,%item.price * %numsell); Player::setItemCount(%player,%item,(%count-%numsell)); updateBuyingList(%client); Client::SendMessage(%client,0,"~wbuysellsound.wav"); return 1; } } Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav"); } function remoteUseItem(%client,%type) { %plyr = Client::getOwnedObject(%client); if (testPlayerStat(%client) && !%plyr.station) { %client.throwStrength = 1; %item = getItemData(%type); if (%item == Backpack) %item = Player::getMountedItem(%client,$BackpackSlot); else { if (%item == Weapon) %item = Player::getMountedItem(%client,$WeaponSlot); } Player::useItem(%client,%item); } } function remoteThrowItem(%client,%type,%strength) { %player = Client::getOwnedObject(%client); if(testPlayerStat(%client) && !%player.station && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) { if(GameBase::getControlClient(%player) != -1) { %item = getItemData(%type); if (%item == Grenade || %item == MineAmmo) { if (%strength < 0) %strength = 0; else if (%strength > 100) %strength = 100; %client.throwStrength = 0.3 + 0.7 * (%strength / 100); Player::useItem(%client,%item); } } } } function remoteDropItem(%client,%type) { %plyr = Client::getOwnedObject(%client); 
if (Player::isExposed(%client) && $matchStarted && $loadingMission == false) { 
if (%plyr.driver != 1) 
{ %client.throwStrength = 1; %item = getItemData(%type); if (%item == Backpack) { %item = Player::getMountedItem(%client,$BackpackSlot); if(%plyr.station && %item == SuicidePack) return; else Player::dropItem(%client,%item); } else if (%item == Weapon) { %item = Player::getMountedItem(%client,$WeaponSlot); Player::dropItem(%client,%item); } else if (%item == Ammo) { %item = Player::getMountedItem(%client,$WeaponSlot); if(%item.className == Weapon) { %item = %item.imageType.ammoType; Player::dropItem(%client,%item); } } else { if(%plyr.station && %item == SuicidePack) return; else Player::dropItem(%client,%item); } } } } function remoteDeployItem(%client,%type) { %plyr = Client::getOwnedObject(%client); if (testPlayerStat(%client) && !%plyr.station) { %item = getItemData(%type); Player::deployItem(%client,%item); } } 
 
 $NextWeapon[Fixit] = Blaster; 
 $NextWeapon[Blaster] = PlasmaGun; 
 $NextWeapon[PlasmaGun] = Chaingun; 
 $NextWeapon[Chaingun] = HDiscLauncher; 
 $NextWeapon[HDiscLauncher] = DiscLauncher;
 $NextWeapon[DiscLauncher] = GrenadeLauncher; 
 $NextWeapon[GrenadeLauncher] = VehFixit; 
 $NextWeapon[VehFixit] = Mortar; 
 $NextWeapon[Mortar] = LaserRifle; 
 $NextWeapon[LaserRifle] = RocketLauncher; 
 $NextWeapon[RocketLauncher] = Stinger; 
 $NextWeapon[Stinger] = SniperRifle; 
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
 $NextWeapon[Omega] = JailGun; 
 $NextWeapon[JailGun] = Fixit; 

 $PrevWeapon[Blaster] = JailGun; 
 $PrevWeapon[PlasmaGun] = Blaster; 
 $PrevWeapon[Chaingun] = PlasmaGun; 
 $PrevWeapon[DiscLauncher] = Chaingun;
 $PrevWeapon[HDiscLauncher] = DiscLauncher;
 $PrevWeapon[GrenadeLauncher] = HDiscLauncher; 
 $PrevWeapon[VehFixit] = GrenadeLauncher; 
 $PrevWeapon[Mortar] = VehFixit; 
 $PrevWeapon[LaserRifle] = Mortar; 
 $PrevWeapon[RocketLauncher] = LaserRifle; 
 $PrevWeapon[SniperRifle] = Stinger; 
 $PrevWeapon[Stinger] = RocketLauncher;
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
 $PrevWeapon[JailGun] = Fixit; 
 
 function remoteNextWeapon(%client) 
 { 
	if(!testPlayerStat(%client)) { return; } 
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
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) 
				break; 
			} 
		} 
	} 
} 
function remotePrevWeapon(%client) 
{ 
	if(!testPlayerStat(%client)) { return; } 
	%item = Player::getMountedItem(%client,$WeaponSlot); 
	if (%item == -1 || $PrevWeapon[%item] == "") 
		selectValidWeapon(%client); 
	else { for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon]) 
	{ 
		if (isSelectableWeapon(%client,%weapon)) 
		{ Player::useItem(%client,%weapon); if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break; } } } } function selectValidWeapon(%client) { %armor = Player::getarmor(Client::getOwnedObject(%client)); if(%armor == sarmor || %armor == sfemale) %item = Mortar;  else if(%armor == larmor || %armor == lfemale) %item = RocketLauncher; else %item = EnergyRifle; for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) { if (isSelectableWeapon(%client,%weapon)) { Player::useItem(%client,%weapon); break; } } } 
		
function isSelectableWeapon(%client,%weapon) { if (Player::getItemCount(%client,%weapon)) { %ammo = $WeaponAmmo[%weapon]; if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0) return true; } return false; } 
  
function Item::giveItem(%player,%item,%delta) 
{ 
	%armor = Player::getArmor(%player); 
	if(%item == EspPack) return; if($ItemMax[%armor, %item]) 
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
	if (Item::isRotating(%this)) 
	{ 
		Item::hide(%this,True); 
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this); 
	} 
	else 
	{ 
		deleteObject(%this); 
	} 
} 
function Item::onAdd(%this) 
{ } 

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

function Item::onMount(%player,%item) 
{ }

function Item::onUnmount(%player,%item) 
{ } 

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
		if(%item.className != Armor && %item.className != Armor1 && %item.className != Armor2) 
		{ 
			%obj = newObject("","Item",%item,1,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); 
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
{ } 

function Flag::onUse(%player,%item) 
{ Player::mountItem(%player,%item,$FlagSlot); }

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
	lightType = 2; 
	lightRadius = 4; 
	lightTime = 1.5; 
	lightColor = { 1, 1, 1 }; 
}; 

ItemData ScoutArmor 
{ 
	heading = "aArmor"; 
	description = "Scout"; 
	className = "Armor2"; 
	price = 175;
}; 

ItemData SpArmor 
{
	
	heading = "aArmor";
	description = "Infiltrator"; 
	className = "Armor"; 
	price = 175;
}; 

ItemData SpArmor1 
{
	heading = "aArmor";
	description = "Spy"; 
	className = "Armor1"; 
	price = 175;
}; 

ItemData LightArmor 
{ 
	heading = "aArmor"; 
	description = "Assassin"; 
	className = "Armor"; 
	price = 175;
}; 

ItemData LightArmor1 
{ 
	heading = "aArmor"; 
	description = "Sniper"; 
	className = "Armor1"; 
	price = 175;
}; 

ItemData MediumArmor 
{ 
	heading = "aArmor"; 
	description = "Mercenary"; 
	className = "Armor2"; 
	price = 250;
}; 

ItemData BusterArmor 
{ 
	heading = "aArmor"; 
	description = "Buster"; 
	className = "Armor"; 
	price = 250; 
}; 

ItemData BursterArmor 
{ 
	heading = "aArmor"; 
	description = "Burster"; 
	className = "Armor1"; 
	price = 250;
}; 

ItemData EngArmor 
{ 
	heading = "aArmor"; 
	description = "Engineer"; 
	className = "Armor2"; 
	price = 250;
}; 

ItemData AlArmor 
{ 
	heading = "aArmor"; 
	description = "Alien"; 
	className = "Armor2";
	price = 250;
}; 

ItemData DragArmor 
{ 
	heading = "aArmor"; 
	description = "Cyborg"; 
	className = "Armor2"; 
	price = 400;
}; 

ItemData HeavyArmor 
{ 
	heading = "aArmor"; 
	description = "Guardian"; 
	className = "Armor"; 
	price = 700;
}; 

ItemData HeavyArmor1 
{ 
	heading = "aArmor"; 
	description = "Defender"; 
	className = "Armor1"; 
	price = 700;
};

ItemData ScoutVehicle { description = "Scout"; className = "Vehicle"; heading = "aVehicle"; price = 600; }; 

ItemData WraithVehicle { description = "Wraith"; className = "Vehicle"; heading = "aVehicle"; price = 600; }; 

ItemData JetVehicle { description = "Interceptor"; className = "Vehicle"; heading = "aVehicle"; price = 600; }; 

ItemData LAPCVehicle { description = "BomberLPC"; className = "Vehicle"; heading = "aVehicle"; price = 675; }; 

ItemData HAPCVehicle { description = "StealthHPC"; className = "Vehicle"; heading = "aVehicle"; price = 875; };

ItemData HAPCAssaultVehicle 
{ 
	description = "Assault HPC"; 
	className = "Vehicle"; 
	heading = "aVehicle"; 
	price = 975; 
};  

ItemData Weapon { description = "Weapon"; showInventory = false; }; function Weapon::onDrop(%player,%item) { %state = Player::getItemState(%player,$WeaponSlot); if (%state != "Fire" && %state != "Reload") Item::onDrop(%player,%item); } function Weapon::onUse(%player,%item) { if(%player.Station==""){ %ammo = %item.imageType.ammoType; if (%ammo == "") { Player::mountItem(%player,%item,$WeaponSlot); } else { if (Player::getItemCount(%player,%ammo) > 0) Player::mountItem(%player,%item,$WeaponSlot); else { Client::sendMessage(Player::getClient(%player),0, strcat(%item.description," has no ammo")); } } } } 

ItemData Tool { description = "Tool"; showInventory = false; }; function Tool::onUse(%player,%item) { Player::mountItem(%player,%item,$ToolSlot); } 

ItemData Ammo { description = "Ammo"; showInventory = false; }; function Ammo::onDrop(%player,%item) { if($matchStarted) { %count = Player::getItemCount(%player,%item); %delta = $SellAmmo[%item]; if(%count <= %delta) { if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) %delta = %count; else %delta = %count - 1; } if(%delta > 0) { %obj = newObject("","Item",%item,%delta,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,20,false); Item::playPickupSound(%obj); Player::decItemCount(%player,%item,%delta); } } } 

ItemImageData BlasterImage { shapeFile = "energygun"; mountPoint = 0; weaponType = 0; reloadTime = 0; fireTime = 0.3; minEnergy = 5; maxEnergy = 6; projectileType = BlasterBolt; accuFire = true; sfxFire = SoundFireBlaster; sfxActivate = SoundPickUpWeapon; }; 

ItemData Blaster { heading = "bWeapons"; description = "Blaster"; className = "Weapon"; shapeFile = "energygun"; hudIcon = "blaster"; shadowDetailMask = 4; imageType = BlasterImage; price = 85; showWeaponBar = true; }; 

ItemData BulletAmmo { description = "Bullet"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; }; 

ItemImageData ChaingunImage { shapeFile = "chaingun"; mountPoint = 0; weaponType = 1; reloadTime = 0; spinUpTime = 0.5; spinDownTime = 3; fireTime = 0.2; ammoType = BulletAmmo; projectileType = ChaingunBullet; accuFire = false; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1 }; sfxFire = SoundFireChaingun; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; }; 

ItemData Chaingun { description = "Chaingun"; className = "Weapon"; shapeFile = "chaingun"; validateShape = true; hudIcon = "chain"; heading = "bWeapons"; shadowDetailMask = 4; imageType = ChaingunImage; price = 125; showWeaponBar = true; }; 

ItemData PlasmaAmmo { description = "Plasma Bolt"; heading = "xAmmunition"; className = "Ammo"; shapeFile = "plasammo"; shadowDetailMask = 4; price = 2; }; 

ItemImageData PlasmaGunImage { shapeFile = "plasma"; mountPoint = 0; weaponType = 0; ammoType = PlasmaAmmo; projectileType = PlasmaBolt; accuFire = true; reloadTime = 0.1; fireTime = 0.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 1, 1, 0.2 }; sfxFire = SoundFirePlasma; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; }; 

ItemData PlasmaGun { description = "Plasma Gun"; className = "Weapon"; shapeFile = "plasma"; hudIcon = "plasma"; heading = "bWeapons"; shadowDetailMask = 4; imageType = PlasmaGunImage; price = 175; showWeaponBar = true; validateShape = true; }; 

ItemData GrenadeAmmo { description = "Grenade Ammo"; className = "Ammo"; shapeFile = "grenammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; }; 

ItemImageData GrenadeLauncherImage { shapeFile = "grenadeL"; mountPoint = 0; weaponType = 0; ammoType = GrenadeAmmo; projectileType = GrenadeShell; accuFire = false; reloadTime = 0.5; fireTime = 0.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundFireGrenade; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; }; 

ItemData GrenadeLauncher { description = "Grenade Launcher"; className = "Weapon"; shapeFile = "grenadeL"; hudIcon = "grenade"; heading = "bWeapons"; shadowDetailMask = 4; imageType = GrenadeLauncherImage; price = 150; showWeaponBar = true; validateShape = true; }; 

ItemData MortarAmmo { description = "Mortar Ammo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "mortarammo"; shadowDetailMask = 4; price = 5; }; 

ItemImageData MortarImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = MortarAmmo; projectileType = MortarShell; accuFire = false; reloadTime = 0.5; fireTime = 2.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundMortarIdle; }; 

ItemData Mortar { description = "Mortar"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "mortar"; heading = "bWeapons"; shadowDetailMask = 4; imageType = MortarImage; price = 375; showWeaponBar = true; validateShape = true; }; 

ItemData DiscAmmo { description = "Disc"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; }; 

ItemImageData DiscLauncherImage { shapeFile = "disc"; mountPoint = 0; weaponType = 3; ammoType = DiscAmmo; projectileType = DiscShell; accuFire = true; reloadTime = 0.25; fireTime = 1.25; spinUpTime = 0.25; sfxFire = SoundFireDisc; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDiscReload; sfxReady = SoundDiscSpin; }; 

ItemData DiscLauncher { description = "Disc Launcher"; className = "Weapon"; shapeFile = "disc"; hudIcon = "disk"; heading = "bWeapons"; shadowDetailMask = 4; imageType = DiscLauncherImage; price = 150; showWeaponBar = true; validateShape = true; }; 

ItemImageData LaserRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; projectileType = SniperLaser2; accuFire = true; reloadTime = 0.1; fireTime = 0.5; minEnergy = 10; maxEnergy = 60; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 1, 0, 0 }; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; }; 

ItemData LaserRifle { description = "Laser Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "sniper"; heading = "bWeapons"; shadowDetailMask = 4; imageType = LaserRifleImage; price = 200; showWeaponBar = true; validateShape = true; }; function LaserRifle::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Laser Rifle."); } 

ItemImageData RepairGunImage { shapeFile = "repairgun"; mountPoint = 0; weaponType = 2; projectileType = RepairBolt; minEnergy = 3; maxEnergy = 10; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundRepairItem; }; 

ItemData RepairGun { description = "Repair Gun"; shapeFile = "repairgun"; className = "Weapon"; shadowDetailMask = 4; imageType = RepairGunImage; showInventory = false; price = 125; validateShape = true; }; function RepairGun::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); } function RepairGun::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData HyperBImage { shapeFile = "plasma"; mountPoint = 0; weaponType = 0; reloadTime = 0; fireTime = 0.1; minEnergy = 5; maxEnergy = 6; projectileType = HyperBolt; accuFire = true; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; }; 

ItemData HyperB { heading = "bWeapons"; description = "Hyper Blaster"; className = "Weapon"; shapeFile = "plasma"; hudIcon = "blaster"; shadowDetailMask = 4; imageType = HyperBImage; price = 285; showWeaponBar = true; }; 

ItemData RocketAmmo { description = "Rockets"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "rocket"; shadowDetailMask = 4; price = 50; }; 

ItemImageData RocketImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = RocketAmmo; projectileType = StingerMissile; accuFire = true; reloadTime = 0.5; fireTime = 2.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundMortarIdle; }; 

ItemData RocketLauncher { description = "Rocket Launcher"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "mortar"; heading = "bWeapons"; shadowDetailMask = 4; imageType = RocketImage; price = 375; showWeaponBar = true; }; 

ItemData StingerAmmo { description = "Plane Killer Missiles"; className = "Ammo"; shapeFile = "grenammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 10; };

ItemImageData StingerImage { shapeFile = "grenadeL"; mountPoint = 0; mountRotation = { 0, -1.6, 0 }; weaponType = 0; ammoType = StingerAmmo; accuFire = true; reloadTime = 4.0; fireTime = 1.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundJetHeavy; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; };

ItemData Stinger { description = "Plane Killer"; className = "Weapon"; shapeFile = "grenadeL"; hudIcon = "grenade"; heading = "bWeapons"; shadowDetailMask = 4; imageType = StingerImage; price = 300; showWeaponBar = true; }; function StingerLoading(%player) { Player::unmountItem(%player,$WeaponSlot); Player::mountItem(%player,Stinger,$WeaponSlot); } function StingerImage::onFire(%player, %slot) { GameBase::getLOSInfo(%player, 1000); if (GameBase::getDataName($los::object) == Scout || GameBase::getDataName($los::object) == Jet || GameBase::getDataName($los::object) == Wraith || GameBase::getDataName($los::object) == LAPC || GameBase::getDataName($los::object) == HAPC) { remoteEval(Player::getClient(%player), BP, "<f0><jc>Target Lock Achieved", 3); %trans = GameBase::getMuzzleTransform(%player); Projectile::spawnProjectile("StingerMissile2", %trans, %player, Item::getVelocity(%player), $los::object); Player::decItemCount(%player, StingerAmmo); } else { remoteEval(Player::getClient(%player), BP, "<f0><jc>Invalid Target", 2); Client::sendMessage(Player::getClient(%player), 0, "~wError_Message.wav"); StingerLoading(%player); } }

ItemData SniperAmmo { description = "Sniper Bullet"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; 

ItemImageData SniperRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = SniperAmmo; projectileType = SniperRound; accuFire = true; reloadTime = 1.2; fireTime = 0; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 1.0, 0, 0 }; sfxFire = SoundFireChainGun; sfxActivate = SoundPickUpWeapon; }; 

ItemData SniperRifle { description = "Sniper Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = SniperRifleImage; price = 375; showWeaponBar = true; }; 

ItemData TranqAmmo { description = "Poison Dart"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; 

ItemImageData TranqGunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = TranqAmmo; projectileType = TranqDart; accuFire = true; reloadTime = 1.3; fireTime = 0; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 1.0, 0, 0 }; sfxFire = SoundFireChainGun; sfxActivate = SoundPickUpWeapon; }; 

ItemData TranqGun { description = "Dart Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "blaster"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TranqGunImage; price = 475; showWeaponBar = true; }; 

ItemData SilencerAmmo { description = "Magnum Bullets"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; 

ItemImageData SilencerImage { shapeFile = "energygun"; mountPoint = 0; weaponType = 0; ammoType = SilencerAmmo; projectileType = SilencerBullet; accuFire = true; reloadTime = 0.0; fireTime = 0.5; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 0, 0, 0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; }; 

ItemData Silencer { description = "Magnum"; className = "Weapon"; shapeFile = "energygun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = SilencerImage; price = 375; showWeaponBar = true; validateShape = true; }; 

ItemImageData WaveGunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; minEnergy = 40; maxEnergy = 45; projectileType = Shock; accuFire = true; fireTime = 0.9; sfxFire = SoundPlasmaTurretFire; sfxActivate = SoundPickUpWeapon; }; 

ItemData WaveGun { description = "Shockwave Cannon"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "disk"; heading = "bWeapons"; shadowDetailMask = 4; imageType = WaveGunImage; price = 250; showWeaponBar = true; }; 

ItemData RailAmmo { description = "Railgun Bolt"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; 

ItemImageData RailgunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = RailAmmo; projectileType = RailRound; accuFire = true; reloadTime = 0.2; fireTime = 2.0; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 1.0, 0, 0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; }; 

ItemData Railgun { description = "Railgun"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = RailgunImage; price = 375; showWeaponBar = true; }; 

ItemData VulcanAmmo { description = "Vulcan Bullet"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; }; 

ItemImageData VulcanImage { shapeFile = "chaingun"; mountPoint = 0; weaponType = 1; reloadTime = 0.1; spinUpTime = 0.5; spinDownTime = 3; fireTime = 0.09; ammoType = VulcanAmmo; projectileType = VulcanBullet; accuFire = true; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1 }; sfxFire = SoundFireChaingun; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; }; 

ItemData Vulcan { description = "Vulcan"; className = "Weapon"; shapeFile = "chaingun"; hudIcon = "chain"; heading = "bWeapons"; shadowDetailMask = 4; imageType = VulcanImage; price = 125; showWeaponBar = true; }; 

ItemImageData FlamerImage { shapeFile = "GrenadeL"; mountPoint = 0; weaponType = 0; reloadTime = 0.05; fireTime = 0; minEnergy = 5; maxEnergy = 6; projectileType = FlamerBolt; accuFire = true; sfxFire = SoundJetHeavy; sfxActivate = SoundPickUpWeapon; }; 

ItemData Flamer { heading = "bWeapons"; description = "Flame Thrower"; className = "Weapon"; shapeFile = "GrenadeL"; hudIcon = "plasma"; shadowDetailMask = 4; imageType = FlamerImage; price = 385; showWeaponBar = true; }; 

ItemImageData IonGunImage { shapeFile = "GrenadeL"; mountPoint = 0; weaponType = 0; reloadTime = 0; fireTime = 0.3; minEnergy = 19; maxEnergy = 20; projectileType = IonBolt; accuFire = true; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; }; 

ItemData IonGun { heading = "bWeapons"; description = "Ion Rifle"; className = "Weapon"; shapeFile = "GrenadeL"; hudIcon = "targetlaser"; shadowDetailMask = 4; imageType = IonGunImage; price = 250; showWeaponBar = true; }; 

ItemImageData OmegaImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; reloadTime = 0.05; fireTime = 0; minEnergy = 5; maxEnergy = 4; projectileType = OmegaBolt; accuFire = false; sfxFire = SoundJetHeavy; sfxActivate = SoundPickUpWeapon; }; 

ItemData Omega { heading = "bWeapons"; description = "Omega Cannon"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "plasma"; shadowDetailMask = 4; imageType = OmegaImage; price = 385; showWeaponBar = true; }; 

ItemImageData EnergyRifleImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 2; projectileType = boltCharge; minEnergy = 3; maxEnergy = 15; reloadTime = 0.2; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 0.25, 0.25, 0.85 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundELFIdle; }; 

ItemData EnergyRifle { description = "Thunderbolt"; shapeFile = "shotgun"; hudIcon = "energyRifle"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = EnergyRifleImage; showWeaponBar = true; price = 500; validateShape = true; }; 

ItemImageData TargetingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = targetLaser; accuFire = true; minEnergy = 5; maxEnergy = 15; reloadTime = 1.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; }; 

ItemData TargetingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TargetingLaserImage; price = 50; showWeaponBar = false; }; 

ItemImageData FixitImage { shapeFile = "repairgun"; mountPoint = 0; weaponType = 2; projectileType = RepairBolt; minEnergy = 5; maxEnergy = 15; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxFire = SoundRepairItem; sfxActivate = SoundPickUpWeapon; }; 

ItemData Fixit { description = "Engineer Repair-Gun"; className = "Tool"; shapeFile = "repairgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = FixitImage; price = 50; showWeaponBar = false; }; 

ItemImageData VehFixitImage { shapeFile = "repairgun"; mountPoint = 0; weaponType = 2; projectileType = VehRepairBolt; minEnergy = 5; maxEnergy = 15; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxFire = SoundRepairItem; sfxActivate = SoundPickUpWeapon; }; 

ItemData VehFixit { description = "Vehicle Repair-Gun"; className = "Tool"; shapeFile = "repairgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = VehFixitImage; price = 50; showWeaponBar = false; }; 

ItemData Backpack { description = "Backpack"; showInventory = false; }; function Backpack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::trigger(%player,$BackpackSlot); } } 

ItemImageData DeployableInvPackImage { shapeFile = "invent_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData DeployableInvPack { description = "Inventory Station"; shapeFile = "invent_remote"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4 ; imageType = DeployableInvPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteInvEnergy + 200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableInvPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableInvPack::onDeploy(%player,%item,%pos) { if (DeployableInvPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableInvPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Inventory Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed an Inventory Station"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData DeployableAmmoPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 1.0; firstPerson = false; }; 

ItemData DeployableAmmoPack { description = "Ammo Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4; imageType = DeployableAmmoPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteAmmoEnergy; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableAmmoPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableAmmoPack::onDeploy(%player,%item,%pos) { if (DeployableAmmoPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableAmmoPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Ammo Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed an Ammo Station"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData HoverPackImage 
{ 
	shapeFile = "jetPack"; 
	weaponType = 2; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, 0 }; 
	minEnergy = 0; 
	maxEnergy = 0; 
	firstPerson = false; 
}; 

ItemData HoverPack 
{ 
	description = "Hover Pack"; 
	shapeFile = "jetPack"; 
	className = "Backpack"; 
	heading = "cBackpacks"; 
	shadowDetailMask = 4; 
	imageType = HoverPackImage; 
	price = 150; 
	hudIcon = "energypack"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	validateShape = true; 
	validateMaterials = true; 
};

StaticShapeData HoverPad
{
	className = "Platforms";
	damageSkinData = "objectDamageSkins";
	shapeFile = "elevator_6x6_octagon";
	maxDamage = 50;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = false;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Hover Pad";
};

function HoverPackImage::onActivate(%player,%imageSlot) 
{ 
	%hpos = Vector::add(GameBase::getPosition(%player), "0 0 -1");
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$InteriorShape | $StaticObjectType,%hpos,25,25,25,0);
	if(%num)
	{
		%clientId = Player::getClient(%player); 
		Client::sendMessage(%clientId,1,"Can't deploy near buildings.");
		%player.pad = 1;
		Player::trigger(%player,$BackpackSlot,false);
		return;
	}
    %team = GameBase::getTeam(%this);
	%teleset = nameToID("MissionCleanup//HoverPad"@%player);
	if(%teleset == -1)
	{	
		%group = newObject("HoverPad"@%player,SimGroup);
		addToSet("MissionCleanup",%group);
	}
	%obj = newObject("Hover Pad","Staticshape",HoverPad,true);
	addToSet("MissionCleanup\\HoverPad"@%player, %obj);
	GameBase::setRotation(%obj,"0 0 0");
	GameBase::setPosition(%obj,%hpos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);
}

function HoverPackImage::onDeactivate(%player,%imageSlot) 
{ 
	if(%player.pad != 1)
	{
		%team = GameBase::getTeam(%this);
		deleteobject("MissionCleanup\\HoverPad"@%player);
	}
	%player.pad = 0;
}

ItemData HDiscAmmo { description = "Razor II Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 6; }; 

ItemData HDisc1Ammo { description = "Razor II Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 6; showInventory = false; }; 

ItemData HDisc2Ammo { description = "Razor II Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 6; showInventory = false; }; 

ItemData HDisc3Ammo { description = "Razor II Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 6; showInventory = false; }; 


ItemImageData HDisc1Image 
{ 
	shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0,-1.00, 0 }; 
	ammoType = HDisc1Ammo; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = HDiscShell; 
}; 

ItemData HDisc1 
{ 
	description = "Razor II"; 
	className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "bWeapons";
	shadowDetailMask = 4; 
	imageType = HDisc1Image; 
	price = 250; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HDisc2Image 
{ 
	shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0,1.00, 0 }; 
	ammoType = HDisc2Ammo; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = HDiscShell; 
}; 

ItemData HDisc2 
{ 
	description = "Razor II"; 
	className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "bWeapons";
	shadowDetailMask = 4; 
	imageType = HDisc2Image; 
	price = 250; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HDisc3Image 
{ 
	shapeFile = "disc"; 
	mountPoint = 0; 
	mountoffset = { 0, -1, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	ammoType = HDisc3Ammo; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = HDiscShell; 
}; 

ItemData HDisc3 
{ 
	description = "Razor II"; 
	className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "bWeapons";
	shadowDetailMask = 4; 
	imageType = HDisc2Image; 
	price = 250; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HDiscLauncherImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 3; 
	ammoType = HDiscAmmo; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	sfxFire = SoundFireDisc; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundDiscReload; 
	sfxReady = SoundSpinIdle; 
}; 

ItemData HDiscLauncher 
{ 
	description = "Razor II"; 
	className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "bWeapons";
	shadowDetailMask = 4; 
	imageType = HDiscLauncherImage; 
	price = 250; 
	showWeaponBar = true; 
}; 

function HDiscLauncherImage::onFire(%player, %slot) { 
	%state1 = Player::getItemState(%player,6);
	%state2 = Player::getItemState(%player,7);
	%state3 = Player::getItemState(%player,4);
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload" && %state3 != "Fire" && %state3 != "Reload") {
		%client = GameBase::getOwnerClient(%player); 
		Player::decItemCount(%player, "HDiscAmmo", 1);
		%num = Player::getItemCount(%player, "HDiscAmmo");
		if(%client.hd == 0) {
			%client.hd = 1;
			if(%num == 1)
				Player::setItemCount(%player, "HDisc1Ammo", 0);
			else
				Player::setItemCount(%player, "HDisc1Ammo", %num);
			Player::trigger(%player,6,true);
			Player::trigger(%player,6,false);
		} else if(%client.hd == 1){
			%client.hd = 2;
			if(%num == 1)
				Player::setItemCount(%player, "HDisc2Ammo", 0);
			else
				Player::setItemCount(%player, "HDisc2Ammo", %num);
			Player::trigger(%player,7,true);
			Player::trigger(%player,7,false);
		} else {
			%client.hd = 0;
			if(%num == 1)
				Player::setItemCount(%player, "HDisc3Ammo", 0);
			else
				Player::setItemCount(%player, "HDisc3Ammo", %num);
			Player::trigger(%player,4,true);
			Player::trigger(%player,4,false);
		}
	}
}

function HDiscLauncher::onMount(%player,%imageSlot)
{
	%num = Player::getItemCount(%player, "HDiscAmmo");
	Player::setItemCount(%player, "HDisc1Ammo", %num);
	Player::mountItem(%player,HDisc1,6); 
	Player::setItemCount(%player, "HDisc2Ammo", %num);
	Player::mountItem(%player,HDisc2,7); 
	Player::setItemCount(%player, "HDisc3Ammo", %num);
	Player::mountItem(%player,HDisc3,4); 
}

function HDiscLauncher::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,6); 
	Player::unmountItem(%player,7);
	Player::unmountItem(%player,4); 
}

ItemImageData HPCWeap1Image 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountRotation = { 0,0, 0 }; 
	mountoffset = {-1,0,0};

	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = shock1; 
}; 

ItemData HPCWeap1
{ 
	description = "Razor II"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "disk"; 
	heading = "bWeapons";
	shadowDetailMask = 4; 
	imageType = HPCWeap1Image; 
	price = 250; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HPCWeap2Image 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountRotation = { 0 ,0, 0 };  
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = shock1; 
}; 

ItemData HPCWeap2 
{ 
	description = "Razor II"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "disk"; 
	heading = "bWeapons";
	shadowDetailMask = 4; 
	imageType = HPCWeap2Image; 
	price = 250; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HPCWeapLauncherImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0.1; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundSpinIdle; 
}; 

ItemData HPCWeapLauncher 
{ 
	description = "HPC Weapon"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "disk"; 
	heading = "bWeapons";
	shadowDetailMask = 4; 
	imageType = HPCWeapLauncherImage; 
	price = 250; 
	showWeaponBar = true; 
}; 

function HPCWeapLauncherImage::onFire(%player, %slot) { 
	%state1 = Player::getItemState(%player,6);
	%state2 = Player::getItemState(%player,7);
	%state3 = Player::getItemState(%player,4);
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") {
		%client = GameBase::getOwnerClient(%player); 
		Player::decItemCount(%player, "HDiscAmmo", 1);
		if(%client.hd == 0) {
			%client.hd = 1;
			Player::trigger(%player,6,true);
			Player::trigger(%player,6,false);
		} else if(%client.hd == 1){
			%client.hd = 0;
			Player::trigger(%player,7,true);
			Player::trigger(%player,7,false);
		}
	}
}

function HPCWeapLauncher::onMount(%player,%imageSlot)
{
	%num = Player::getItemCount(%player, "HDiscAmmo");
	Player::mountItem(%player,HPCWeap1,6); 
	Player::mountItem(%player,HPCWeap2,7);  
}

function HPCWeapLauncher::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,6); 
	Player::unmountItem(%player,7);
}

ItemImageData JailPackImage
{	
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData JailPack
{	
	description = "Jail Cell";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = dDeployables;
	imageType = jailPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 9000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData JailDoor
{
	className = "LargeForceField";
	damageSkinData = "objectDamageSkins";
	shapeFile = "ForceField";
	maxDamage = 50;
	maxEnergy = 200;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = mortarExp;
	debrisId = flashDebrisLarge;
	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
	side = "single";
	isTranslucent = true;
	description = "Jail Cell Door";
};

StaticShapeData JailSide
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 50;
	visibleToSensor = true;
	isTranslucent = true;
};

StaticShapeData JailStand
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 50;
	description = "Jail Stand";
};

StaticShapeData JailReleasePad
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	maxDamage = 50;
	description = "Jail Release Pad";
};

StaticShapeData JailSwitchOpen
{
	description = "The Jail";
	className = "towerSwitch";
	shapeFile = "tower";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	maxDamage = 50;
};

StaticShapeData JailSwitchClose
{
	description = " The Jail";
	className = "towerSwitch";
	shapeFile = "tower";
	showInventory = "false";
	visibleToSensor = true;
	mapFilter = 4;
	mapIcon = "M_generator";
	maxDamage = 50;
};

function JailPack::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function JailPack::onDeploy(%player,%item,%pos)
{	if(jailPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CreateJailSimSet(%team)
{
	%teleset = nameToID("MissionCleanup/JailCell" @ %team);
	if(%teleset == -1)
	{	newObject("JailCell" @ %team,SimSet);
		addToSet("MissionCleanup","JailCell" @ %team);
	}
	%teleset = nameToID("MissionCleanup/JailPorts" @ %team);
	if(%teleset == -1)
	{
		newObject("Jailports" @ %team,SimSet);
		addToSet("MissionCleanup","JailPorts" @ %team);
	}
	%teleset = nameToID("MissionCleanup/JailRelease" @ %team);
	if(%teleset == -1)
	{
		newObject("JailRelease" @ %team,SimSet);
		addToSet("MissionCleanup","JailRelease" @ %team);
	}
}

function JailPack::deployshape(%player,%item)
{
	%name = "Jail Cell";
	%team = GameBase::getTeam(%player);
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Can Not Deploy Jail Cell Already In Place");
		return false;
	}
	%playerPos = GameBase::getPosition(%player);
	%flag = $teamFlag[GameBase::getTeam(%player)];
	%flagpos = gamebase::getPosition(%flag);

	if(Vector::getDistance(%flagpos, %playerpos) < 100)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return ;
	}

	CreateJailSimSet(%team);

	%obj = newObject("Jail Back Wall","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 .6 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "-5.5 6.5 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 4.71339");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "5.5 6.5 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 4.71339");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail Roof","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 86");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"-4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);
	
	%obj = newObject("Jail Roof","Staticshape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 86");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 12.5 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"-4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 .5 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSide,true);
	%pos = Vector::add(GameBase::getPosition(%player), "0 18 80");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"-4.71339 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSwitchOpen,true);
	%pos = Vector::add(GameBase::getPosition(%player), "-5 13 80.00");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail","StaticShape",JailSwitchClose,true);
	%pos = Vector::add(GameBase::getPosition(%player), "5 13 80.00");
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setRotation(%obj,"0 0 0");
	GameBase::setPosition(%obj,%pos);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	Gamebase::setMapName(%obj,%name);

	%obj = newObject("Jail Door","StaticShape",JailDoor,true);
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 12 80");
	GameBase::setPosition(%obj,%pos);
	GameBase::setRotation(%obj,"0 0 0");

	%obj = newObject("Teleport Pad","StaticShape","JailStand",true);
	addToSet("MissionCleanup/JailPorts" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 81");
	GameBase::setPosition(%obj,%pos);
	Gamebase::setMapName(%obj,"Entry Pad");

	%obj = newObject("","StaticShape",ElectricalBeamBig,true);
	addToSet("MissionCleanup/JailCell" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("Jail Release Pad","StaticShape","JailReleasePad",true);
	addToSet("MissionCleanup/JailRelease" @ %team, %obj);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 86.30");
	GameBase::setPosition(%obj,%pos);
	Gamebase::setMapName(%obj,"Release Pad");

	$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
	echo("MSG: ",%client," deployed a Jail Cell");
	Client::sendMessage(%client,0,%item.description @ " summoned 250' Up");
	playSound(SoundPickupBackpack,$los::position);
	return true;
}

function JailSide::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);
	
	%set1 = nameToID("MissionCleanup/JailCell" @ %team);
	%set2 = nameToID("MissionCleanup/JailPorts" @ %team);
	%set3 = nameToID("MissionCleanup/JailRelease" @ %team);
	
	if(%set1 != -1 && %set2 != -1 && %set3 != -1)
	{
		if(%this == Group::getObject(%set1,0)) 
		{	
			%objs = group::objectcount(%set1);
			for(%x=0; %x<%objs; %x++) 
			{	
				%obj = Group::getObject(%set1,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*10)));
			} 
			deleteObject(%set1);
			%objs=group::objectcount(%set2);
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%set2,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*10)));
			} 
			deleteObject(%set2);
			%objs=group::objectcount(%set3);
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%set3,%x);
				schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*10)));
			} 
			deleteObject(%set3);
		} 
		else 
		{	
			GameBase::setDamageLevel(Group::getObject(%set1,0),100);
		}
	}
	$TeamItemCount[GameBase::getTeam(%this) @ "JailPack"]=0;
}

function JailSwitchOpen::onCollision(%this,%obj)
{
}

function JailSwitchClose::onCollision(%this,%obj)
{
}

function JailDoor::onDestroyed(%this)
{
	JailSide::onDestroyed(%this);
}

function JailDoor::onCollision(%this,%obj)
{
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) 
		return;

	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%fieldTeam = GameBase::getTeam(%this);
	if(%fieldTeam != %playerTeam)
		return;

	JailDoor::openSesame(%this);
	return;
}

function JailDoor::openSesame(%this) 
{
	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 6");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.15);
	schedule("JailDoor::closeSesame("@%this@");",2);
}

function JailDoor::closeSesame(%this) 
{
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -6");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.15);
}

function JailBreak(%this, %team)
{
	%clientId = Player::getClient(%this);
	%teleset = nameToID("MissionCleanup/JailRelease" @ %team);
	for(%i = 0; (%obj = Group::getObject(%teleset, %i)) != -1; %i++)
	{
		if(%team != GameBase::getTeam(%this))
		{
			%this.jaildamage=false;
			GameBase::SetPosition(%this,GameBase::GetPosition(%obj));
			Client::SendMessage(%clientId, 0, "You Have Been Released. Run Forrest Run!!!!");
		}
	}
}



function deployCommandShip::Initialize()
{	$TeamItemCount[0 @ CommandShipPack] = 0;
	$TeamItemCount[1 @ CommandShipPack] = 0;
	$TeamItemCount[2 @ CommandShipPack] = 0;
	$TeamItemCount[3 @ CommandShipPack] = 0;
	$TeamItemCount[4 @ CommandShipPack] = 0;
	$TeamItemCount[5 @ CommandShipPack] = 0;
	$TeamItemCount[6 @ CommandShipPack] = 0;
	$TeamItemCount[7 @ CommandShipPack] = 0;
}

ItemImageData CommandShipPackImage
{	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.25 };
	mountRotation = { 0, 0, 0 };
	mass = 3.5;
	firstPerson = false;
};

ItemData CommandShipPack
{	description = "Mini Base";
	shapeFile = "generator_p";
	className = "Backpack";
   	heading = dDeployables;
	shadowDetailMask = 4;
	imageType = CommandShipPackImage;
	mass = 0.2;
	elasticity = 0.2;
	price = 5000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CommandShipPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::deployItem(%player,%item);
	}
}

function CommandShipPack::onDeploy(%player,%item,%pos)
{	if (CommandShipPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
	
StaticShapeData CommandShipGen
{	
	description = "Generator";
	shapeFile = "generator";
	classname = "CommandShipGen";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 2.0;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "shield";
};


StaticShapeData MiniBaseSwitch
{	
	description = "MiniBaseSwitch";
	shapeFile = "generator_p";
	classname = "StaticShape";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 30.0;
	mapIcon = "";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "";
};

function MiniBaseSwitch::onDestroyed(%this)
{
	CommandShip::onDestroyed(%this);
}

function CommandShip::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);
	
	GameBase::setDamage(%this,1000);
	GameBase::setDamageLevel(%this,1000);
	deleteobject("MissionCleanup\\MiniBase"@%team);
	$TeamItemCount[GameBase::getTeam(%player) @ "CommandShipPack"]--; 

	calcRadiusDamage(%this, $DebrisDamageType, 5, 0.05, 40, 18, 7, 0.55, 0.30, 300, 200);
}

function CommandShipGen::onDestroyed(%this)
{
	if($trace) echo($ver,"| CommandShipGen::onDestroyed");
	CommandShipGen::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
}

function CommandShipGen::onEnabled(%this)
{
	if($trace) echo($ver,"| CommandShipGen::onEnabled ",%this);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
	CommandShip::setPower(GameBase::getTeam(%this),1);
}

function CommandShipGen::onActivate(%this)
{
	if($trace) echo($ver,"| CommandShipGen::onActivate ",%this);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
	CommandShip::setPower(GameBase::getTeam(%this),1);
}

function CommandShipGen::setActive(%this)
{
	if($trace) echo($ver,"| CommandShipGen::setActive ",%this);
	GameBase::playSequence(%this,0,"power");
	GameBase::generatePower(%this, true);
	GameBase::isPowerGenerator(%this);
	CommandShip::setPower(GameBase::getTeam(%this),1);
}

function CommandShipGen::onDisabled(%this)
{
	if($trace) echo($ver,"| CommandShipGen::onDisabled ",%this);
	GameBase::stopSequence(%this,0);
 	GameBase::generatePower(%this, false);
 	CommandShip::setPower(GameBase::getTeam(%this),0);
}

function CreateCommandShipsimSet(%team)
{	
	%teleset = nameToID("MissionCleanup//MiniBase"@%team);
	if(%teleset == -1)
	{	
		%group=newObject("MiniBase"@%team,SimGroup);
		addToSet("MissionCleanup",%group);
	}
	%teleset = nameToID("MissionCleanup//MiniBaseDoor"@%team);
	if(%teleset == -1)
	{	
		%group=newObject("MiniBaseDoor"@%team,SimGroup);
		addToSet("MissionCleanup",%group);
	}
}

function CommandShip::setPower(%team,%power) 
{	
	%teleset = nameToID("MissionCleanup/CommandShip"@%team);
	if(%teleset != -1)
	{	
		%objs=Group::objectCount(%teleset);
		if(%objs) 
		{	
			for(%x=0;%x<%objs;%x++) 
			{	
				%obj=Group::getObject(%teleset,%x);
				if(GameBase::getMapName(%obj)=="Command Ship Inventory Station" || GameBase::getMapName(%obj)=="Command Ship Ammo Station" || GameBase::getMapName(%obj)=="Command Ship Command Station") 
				{	
					if(GameBase::getDamageState(%obj)!="Disabled") 
					{	
						Station::onPower(%obj,%power,0);
					}
					else 
					{	
						Station::onPower(%obj,0,0);
					}
				}
				else if(GameBase::getMapName(%obj)=="Command Ship Indoor Turret" || GameBase::getMapName(%obj)=="Command Ship Plasma Turret")
				{	
					GameBase::setActive(%obj,%power);
					if(GameBase::getDamageState(%obj)!="Disabled") 
					{	
						if (%power) 
						{	
							%obj.shieldStrength = 0.03;
							GameBase::setRechargeRate(%obj,10);
							GameBase::playSequence(%obj,0,"power");
						}
						else 
						{	
							%this.shieldStrength = 0;
							GameBase::setRechargeRate(%obj,0);
							GameBase::StopSequence(%obj,0);
						}
						GameBase::setActive(%this,%power);
					}
					else 
					{	
						GameBase::StopSequence(%obj,0); 
					}
				}
			}
		}
	}
}

function checkDeployAreaCommandShip(%client,%pos) 
{
	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType,%pos,65,65,65,1);
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
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	deleteObject(%set);
	return 0;
}

function CommandShipPack::deployShape(%player,%item)
{	
	%name = "Command Ship";
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{	
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
		return false; 
	}

	if (!GameBase::getLOSInfo(%player,3)) 
	{	
		Client::sendMessage(%client,0,"Deploy position out of range"); 
		return false; 
	}

	if(getNumTeams() == 2)
	{
		%playerTeam = Client::getTeam(%client);
		if(%playerTeam == 0)
			%enemyTeam = 1;
		else if (%playerTeam == 1)
			%enemyTeam = 0;
		if(((Vector::getDistance($teamFlag[%enemyTeam].originalPosition, $los::position)) < ($FlagDistance * 0.4)) && ($FlagDistance != 0)) 
		{
			Client::sendMessage(%client,0,"You are too close to the enemy flag~waccess_denied.wav");
			return false;
		}
	}

	%obj = getObjectType($los::object); 
	if (%obj != "SimTerrain") 
	{	
		Client::sendMessage(%client,0,"Can only deploy on terrain"); 
		return false; 
	}

	if (!checkDeployAreaCommandShip(%client,$los::position)) 
		return false;

	%team=GameBase::getTeam(%player);
	CreateCommandShipsimSet(%team);
	
	%rot="0 0 0";
	%opos=Vector::add($los::position,"0 0 75");
	
	%rtime = 3;
								
	%objShip = newObject("MiniBase","InteriorShape", "apipecon.dis"); 
	%pos=Vector::add(%opos,"0 0 0");
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objShip,%pos); 
	GameBase::setDamageLevel(%objship,1);
	GameBase::setRotation(%objShip,%rot); 
	Gamebase::setMapName(%objShip,"MiniBase"); 
	Client::sendMessage(%client,0,"MiniBase Deployed"); 
	GameBase::startFadeIn(%objShip); 

	%objShip = newObject("MiniBaseSwitch","StaticShape",MiniBaseSwitch,false);
	%pos=Vector::add(%opos,"0 0 0");
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);	
	//addToSet("MissionCleanup", %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 3.14 0");
	Gamebase::setMapName(%objShip,%name @ " Mini Base");
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

//	%objShip = newObject("Force Field Door","StaticShape",DoorfivebyfiveForceField,false);
//	%pos=Vector::add(%opos,"0.526 -8.438 0");
//	addToSet("MissionCleanup\\MiniBaseDoor"@%team, %objShip);	
//	//addToSet("MissionCleanup", %objShip);
//	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
//	GameBase::setRotation(%objShip,"0 1.57 0");
//	Gamebase::setMapName(%objShip,%name @ " Mini Base");
//	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
//	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);
//
//	%objShip = newObject("Force Field Door","StaticShape",DoorfivebyfiveForceField,false);
//	%pos=Vector::add(%opos,"0.525 -3.343 10.338");
//	addToSet("MissionCleanup\\MiniBaseDoor"@%team@"\\Door", %objShip);	
//	//addToSet("MissionCleanup", %objShip);
//	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
//	GameBase::setRotation(%objShip,"0 0 0");
//	Gamebase::setMapName(%objShip,%name @ " Mini Base");
//	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
//	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);
//
//	%objShip = newObject("MiniBaseSolarGen","StaticShape",MiniBaseSolarGen,false);
//	%pos=Vector::add(%opos,"0.971 -10.111 15.946");
//	addToSet("MissionCleanup\\MiniBaseDoor"@%team, %objShip);	
//	//addToSet("MissionCleanup", %objShip);
//	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
//	GameBase::setRotation(%objShip,"0 0 0");
//	Gamebase::setMapName(%objShip,%name @ " Mini Base");
//	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
//	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("Inventory1","StaticShape",InventoryStation,false);
	%pos=Vector::add(%opos,"0.023 5.052 2");
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);	
	//addToSet("MissionCleanup", %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Inventory Station");
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);
	
	%objShip = newObject("CommandStation","StaticShape",CommandStation,false);
	%pos=Vector::add(%opos,"0.066 8.029 12.017");
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);	
	//addToSet("MissionCleanup", %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Command Station");
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("Sensor","StaticShape",radar_medium,false);
	%pos=Vector::add(%opos,"8.029 0.326 15.285");
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);	
	//addToSet("MissionCleanup", %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Inventory Station");
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("remoteturret","turret",IndoorTurret,false);
	%pos = Vector::add(%opos,"-14.551 -14.537 2");	
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);	
	//addToSet("MissionCleanup", %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 0 0");
	Gamebase::setMapName(%objShip,%name @ " Indoor Turret");
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	%objShip = newObject("remoteturret","turret",IndoorTurret,false);
	%pos = Vector::add(%opos,"14.589 -14.578 2");	
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);	
	//addToSet("MissionCleanup", %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 0 0");
	Gamebase::setMapName(%objShip,%name @ " Indoor Turret");
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);
	
	%objShip = newObject("PortGenerator1","staticshape",PortGenerator,false);
	%pos=Vector::add(%opos,"5.607 0.977 12"); 
	//addToSet("MissionCleanup", %objShip);
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,%rot);
	Gamebase::setMapName(%objShip,%name @ " Portable Generator");
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime+2);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime+2);
	GameBase::setActive(%objShip,True);

	%objShip = newObject("Sensor1","StaticShape",anten_med.dts,false);
	%pos = Vector::add(%opos,"0.036 0.326 12");	
	addToSet("MissionCleanup\\MiniBase"@%team, %objShip);	
	//addToSet("MissionCleanup", %objShip);
	GameBase::setTeam(%objShip,GameBase::getTeam(%player));
	GameBase::setRotation(%objShip,"0 -1.5999");
	Gamebase::setMapName(%objShip,%name @ " Sensor");
	schedule("GameBase::setPosition("@%objShip@",\""@%pos@"\");",%rtime);
	schedule("GameBase::startFadeIn("@%objShip@");",%rtime);

	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "CommandShipPack"]++; 
	echo("MSG: ",%client," deployed a MiniBase");
	return true; 

} 

ItemImageData CloakDisrupterPackImage 
{ 
	shapeFile = "jetPack"; 
	mountPoint = 2; 
	weaponType = 2; 
	minEnergy = 5; 
	maxEnergy = 6; 
	sfxFire = SoundShieldOn; 
	firstPerson = false; 
}; 

ItemData CloakDisrupterPack 
{ 
	description = "CloakDisrupter Pack"; 
	shapeFile = "jetPack";
	className = "Backpack"; 
	heading = "cBackpacks"; 
	shadowDetailMask = 4; 
	imageType = CloakDisrupterPackImage;
	price = 275; 
	hudIcon = "energypack"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function CloakDisrupterPackImage::onActivate(%player,%imageSlot) 
{
		$cloakdisTime[%clientId] = 1; 
		checkPlayerCloakDis(%player);
		Client::sendMessage(Player::getClient(%player),0,"CloakDisrupter On"); 
}
	
function checkPlayerCloakDis(%player)
{	
	if($cloakdisTime[%clientId] == 1) 
	{ 
				%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets

				%Set = newObject("set",SimSet); 
				addToSet("MissionCleanup", %Set);
				%Pos = GameBase::getPosition(%player); 
				%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
				containerBoxFillSet(%Set, %Mask, %Pos, 50, 50, 20,0);
				%num = Group::objectCount(%Set);
				for(%i; %i < %num; %i++)
				{	
					%obj = Group::getObject(%Set, %i);
					if(GameBase::getTeam(%obj) == GameBase::getTeam(%player))
					{	//don't cloak enemies or the box itself
					}
					else
					{	
						GameBase::startFadeIn(%obj);
//						%obj.cloaked = 1 - %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
					}
				}

		schedule("checkPlayerCloakDis(" @ %player @ ");",6,%player);
	}
	else
	{
	}
	
} 

function CloakDisrupterPackImage::onDeactivate(%player,%imageSlot) 
{ 
	
	Client::sendMessage(Player::getClient(%player),0,"CloakDisrupter Off"); 
	Player::trigger(%player,$BackpackSlot,false); 
	$cloakdisTime[%clientId] = -1;
}


ItemImageData BaseCloakPackImage
{	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BaseCloakPack
{	description = "Base Cloaking Device";
	shapeFile = "generator_p";
	className = "Backpack";
  	heading = dDeployables;
	imageType = BaseCloakPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData BaseCloak
{	description = "Base Cloaking Generator";
	shapeFile = "generator_p";
	classname = "pGen";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 1.8;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "shield";
};

function BaseCloakPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function BaseCloakPack::onDeploy(%player,%item,%pos)
{	if (BaseCloakPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
	}
}

function BaseCloakPack::deployShape(%player,%item)
{	
	if(($server::TourneyMode && !$BC::TourneyOn) || $Reneg::BCdisable) 
	{ 
		bottomprint(%client, "<f1><jc>Base Cloaks have been disabled",3); 
		return false; 
	}
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{	if (GameBase::getLOSInfo(%player,3))
		{	%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{	if (Vector::dot($los::normal,"0 0 1") > 0.3)
				{	if(checkDeployArea(%client,Vector::add($los::position, "0.2 0.2 0")))
					{	%rot = GameBase::getRotation(%player); 
						%generator = newObject("BaseCloak","StaticShape",BaseCloak,true);
                 				addToSet("MissionCleanup", %generator);
						GameBase::setTeam(%generator,GameBase::getTeam(%player));
						GameBase::setPosition(%generator,$los::position);
						GameBase::setRotation(%generator,%rot);
						Gamebase::setMapName(%generator,"Base Cloaking Device");
						Client::sendMessage(%client,0,"Base Cloaking Device deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "BaseCloakPack"]++;
						echo("MSG: ",%client," deployed an Base Cloaking Device");
						//GameBase::setDamageLevel(%turret, 0.3 * BaseCloak.maxDamage);
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

function BaseCloak::onDisabled(%this)
{	Turret::onDisabled(%this);
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{	%obj = Group::getObject(%this.set, %i);
		GameBase::startFadeIn(%obj);
		%obj.cloaked = 0;
	}
	deleteObject(%this.set);
}
function BaseCloak::onDestroyed(%this)
{	BaseCloak::onDisabled(%this);
	StaticShape::objectiveDestroyed(%this);
  	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
	$TeamItemCount[GameBase::getTeam(%this) @ "BaseCloakPack"]--;
}

// Override base class just in case.

function BaseCloak::onPower(%this,%power,%generator) 
{
}

function BaseCloak::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);

	%Set = newObject("set",SimSet); 
	addToSet("MissionCleanup", %Set);
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 100, 10, 40,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
		{
			//don't cloak enemies or the box itself
		}
		else
		{
			GameBase::startFadeOut(%obj);
			%obj.cloaked = 1;
		}
	}

	%this.set = %Set;

	schedule("BaseCloak::checkBaseCloak(" @ %this @ ");", 0.1, %this);

}	

function BaseCloak::checkBaseCloak(%this)
{	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets

	%Set = newObject("set",SimSet); 
	addToSet("MissionCleanup", %Set);
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 100, 100, 40,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
		{	%obj = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
			{	//don't cloak enemies or the box itself
			}
			else
			{	GameBase::startFadeOut(%obj);
				%obj.cloaked = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
		}
	}

	%num = Group::objectCount(%this.set);

	for(%j; %j < %num; %j++)
	{	%obj = Group::getObject(%this.set, %j);
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			//don't bother checking the other team or the box itself; they're not cloaked
		}
		else if(%obj.cloaked != (%this.evenodd + 1)) //if different then new set
		{
			%obj.cloaked = 0;
			if(%obj.cloakPack == 0 && %obj.cloakGun == 0) GameBase::startFadeIn(%obj); //then decloak it
		}
	}

	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set

	schedule("BaseCloak::checkBaseCloak(" @ %this @ ");", 5.0, %this); //then recheck in 5 seconds
}

ItemImageData HyperPackImage
{
        shapeFile = "mortarAmmo";
        mountPoint = 2;
        weaponType = 2;
        minEnergy = 1;
        maxEnergy = 1;
        lightType = 3;
        lightRadius = 10;
        lightTime = 10;
        lightColor = { 0.3, 0.1, 0.6 };
        firstPerson = false;
};

ItemData HyperPack
{
        description = "Teleportation Pack";
        shapeFile = "mortarAmmo";
        className = "Backpack";
        heading = cBackpacks;
        shadowDetailMask = 4;
        imageType = HyperPackImage;
        price = 150;
        hudIcon = "compass";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function HyperPackImage::onActivate(%player,%imageSlot)
{
	%energy = GameBase::getEnergy(%player);
	%pos = GameBase::getPosition(%player);
	%client = Player::getClient(%player);
	//%dist = Vector::getDistance(%pos,$los::position);
//	if(%dist < 0)
//		%dist *= -1;
//	%energyUse = %dist/4;
//	Client::sendMessage(%client, 1, " " @ %dist @ " " @ %energyUse );


	if(%energy > 55)
	{
		%client = Player::getClient(%player);
//		%pos = GameBase::getPosition(%player);
		

		if(GameBase::getLOSInfo(%player, 302))
		{
			if(Player::hasFlag(%player))
			{
				Player::dropItem(%player, $theFlag);	// pun city :)
				Client::sendMessage(%client, 1, "Cannot carry flag on Teleportation; dropping flag.~werror_message.wav");
			}

			if(FindFlag($los::position,50,50,1024))	// making sure
			{
				Client::sendMessage(%client, 1, "Cannot teleport within 50m of the flag.");
				Player::trigger(%player, $BackpackSlot,false);	
			}

			GameBase::setPosition(%player,$los::position);
			playSound(ForceFieldOpen,$los::position);
			%energy -= 55;
			GameBase::setEnergy(%player,%energy);
			Player::trigger(%player,$BackPackSlot,false);
		}
		else
		{
			Bottomprint(%client, "<jc>Teleportation Pack destination position out of range -- get within 300m");
			Player::trigger(%player,$BackPackSlot,false);
		}	
	}
	else
	{
		playSound(SoundPackFail,%pos);
		Player::trigger(%player,$BackPackSlot,false);
		Client::sendMessage(%client, 1, "Not enough energy to teleport.");
	}
}

function useEnergy(%object, %energyUse) // Energy Usage
{
	%energy = GameBase::getEnergy(%object); 
 	%energy -= %energyUse;
	GameBase::setEnergy(%object,%energy);
}

function HyperPackImage::onDeactivate(%player,%imageSlot)
{
	%dist = 0;
	%energyUse = 0;
	%pos = 0;
	Player::trigger(%player,$BackpackSlot,false);
}

function Player::hasFlag(%player)
{
	%flag = Player::getMountedItem(%player, $FlagSlot);
	$theFlag = %flag;

	if(%flag == Flag)	
		return true;
	else 
		return false;
}

function FindFlag(%pos,%xdist,%ydist,%zdist)
{
 	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,%pos,%xDist,%yDist,%zDist,0);
	%flag = CountObjects(%set,"FlagStand",%num);

	deleteObject(%set);

	if(%flag)
		return true;
	else
		FindActualFlag(%pos,%xdist,%ydist,%zdist);
}

function findActualFlag(%pos,%xdist,%ydist,%zdist)
{
 	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$ItemObjectType,%pos,%xDist,%yDist,%zDist,0);
	%flag = CountObjects(%set,"Flag",%num);

	deleteObject(%set);

	if(%flag)
		return true;
	else 
		return false;
}

ItemImageData RegenGenPackImage
{	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData RegenGenPack
{	description = "Regeneration Gen.";
	shapeFile = "generator_p";
	className = "Backpack";
  	heading = dDeployables;
	imageType = RegenGenPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData RegenGen
{	description = "Regeneration Generator";
	shapeFile = "generator_p";
	classname = "pGen";
	debrisId = flashDebrisSmall;
	sfxAmbient = SoundGeneratorPower;
	maxDamage = 1.8;
	mapIcon = "M_generator";
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	explosionId = flashExpMedium;
	visibleToSensor = true;
	mapFilter = 4;
	shieldShapeName = "shield";
};


function RegenGenPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{	Player::deployItem(%player,%item);
	}
}

function RegenGenPack::onDeploy(%player,%item,%pos)
{	if (RegenGenPack::deployShape(%player,%item))
	{	Player::decItemCount(%player,%item);
	}
}

function RegenGenPack::deployShape(%player,%item)
{	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{	if (GameBase::getLOSInfo(%player,3))
		{	%obj = getObjectType($los::object);
			if (%obj == "InteriorShape")
			{	if (Vector::dot($los::normal,"0 0 1") > 0.3)
				{	if(checkDeployArea(%client,Vector::add($los::position, "0.2 0.2 0")))
					{	
						%group=newObject("Regen" @ GameBase::getTeam(%player),SimGroup);
						addToSet("MissionCleanup",%group);
						%rot = GameBase::getRotation(%player); 
						%generator = newObject("RegenGen","StaticShape",RegenGen,true);
                 				addToSet("MissionCleanup\\Regen" @ GameBase::getTeam(%player), %generator);
						GameBase::setTeam(%generator,GameBase::getTeam(%player));
						GameBase::setPosition(%generator,$los::position);
						GameBase::setRotation(%generator,%rot);
						Gamebase::setMapName(%generator,"Regeneration Generator Device");
						Client::sendMessage(%client,0,"Regeneration Generator deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "RegenGenPack"]++;
						echo("MSG: ",%client," deployed an Regeneration Generator");
						//GameBase::setDamageLevel(%turret, 0.3 * RegenGen.maxDamage);
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

function RegenGen::onAdd(%this)
{	schedule("RegenGen::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	{	GameBase::setMapName (%this, "Regeneration Generator Device");
	}
}

function RegenGen::deploy(%this)
{	GameBase::playSequence(%this,1,"deploy");
}

function RegenGen::onEndSequence(%this,%thread)
{	GameBase::setActive(%this,true);
}

function RegenGen::onDisabled(%this)
{	
	Turret::onDisabled(%this);
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{	%obj = Group::getObject(%this.set, %i);
		GameBase::repairDamage(%obj,0.00);
		%obj.cloaked = 0;
		if(%obj.told == "1")
		{
			Client::sendMessage(nametoid(%obj), 1, "RepairRate - Normal -");
			%obj.told = "0";
		}
	}
	deleteObject(%this.set);
}
function RegenGen::onDestroyed(%this)
{	
	%team = GameBase::getTeam(%this);
	RegenGen::onDisabled(%this);
	//StaticShape::objectiveDestroyed(%this);
  	deleteobject("MissionCleanup\\Regen"@%team);
	//calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 3, 0.55, 0.30, 250, 170); 
  	$TeamItemCount[GameBase::getTeam(%this) @ "RegenGenPack"]--;
}

// Override base class just in case.

function RegenGen::onPower(%this,%power,%generator) 
{
}

function RegenGen::onEnabled(%this) 
{	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);

	%Set = newObject("set",SimSet); 
	addToSet("MissionCleanup", %Set);
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
		{
			//don't cloak enemies or the box itself
		}
		else
		{
			GameBase::repairDamage(%obj,0.065);
			%obj.regen = 1;
		}
	}

	%this.set = %Set;

	schedule("RegenGen::checkRegenGen(" @ %this @ ");", 0.1, %this);

}	

function RegenGen::checkRegenGen(%this)
{	if(GameBase::getDamageState(%this) != "Enabled")
		return;

	%this.evenodd = !%this.evenodd; //switches from 1 to 0... tells every other check... used to check if in both new & old sets

	%Set = newObject("set",SimSet); 
	addToSet("MissionCleanup", %Set);
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
		{	%obj = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%obj) != GameBase::getTeam(%this) || %obj == %this)
			{	//don't cloak enemies or the box itself
			}
			else
			{	
				if(%obj.told != "1")
				{
					Client::sendMessage(nametoid(%obj), 1, "RepairRate - Enhanced -");
					%obj.told = "1";
				}
				Client::sendMessage(%obj, 1, "RepairRate - Enhanced -");
				GameBase::repairDamage(%obj,0.08);
				%obj.regen = 1 + %this.evenodd; //1 half the time & 2 other half... used to check if in this set while searching the old set
			}
		}

	%num = Group::objectCount(%this.set);

	for(%j; %j < %num; %j++)
	{	%obj = Group::getObject(%this.set, %j);
		if(%obj == %this || GameBase::getTeam(%obj) != GameBase::getTeam(%this))
		{
			//don't bother checking the other team or the box itself; they're not cloaked
		}
		else if(%obj.regen != (%this.evenodd + 1)) //if different then new set
		{
			%obj.regen = 0;
			if(%obj.cloakPack == 0 && %obj.cloakGun == 0) GameBase::repairDamage(%obj,0.08); //then decloak it
		}
	}

	deleteObject(%this.set); //delete the old set
	%this.set = %Set; //and replace with new set

	schedule("RegenGen::checkRegenGen(" @ %this @ ");", 5.0, %this); //then recheck in 5 seconds
}

ItemImageData JailGunImage
{	shapeFile = "shotgun";
	mountPoint = 0;
	//mountRotation = { 0, 3.1416, 0 };
	weaponType = 2;
	projectileType = jailbolt;
	minEnergy = 5;
	maxEnergy = 80;
	reloadTime = 4.0;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundELFIdle;
};

ItemData JailGun
{	heading = "bWeapons";
        description = "Jail Gun";
        className = "Weapon";
        shapeFile  = "repairgun";
        hadowDetailMask = 4;
        imageType = JailGunImage;
        price = 385;
        showWeaponBar = true;
};

//function Jailgun::onMount(%player,%item,$WeaponSlot)
//{	%client = Player::getclient(%player);
//	bottomprint(%client, "Jail Gun: <f2>You are the judge and jury with this little device.  Requires the Jail to be deployed.");
//}

ItemImageData HiderImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData Hider
{
	description = "Cloaking Device";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = "dDeployables";
	imageType = HiderImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Hider::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%data = GameBase::getDataName($los::object);
			if ((%obj == "StaticShape" || %obj == "Turret" || %obj == "Sensor") && %data != "doorthreebyfourForceFieldShape" && %data != "doorfourbyeightForceFieldShape" && %data != "TowerSwitch") {
    				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				} else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					} else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				%csensor = newObject("","Sensor",DeployableMotionSensor,true);
				addToSet("MissionCleanup", %csensor);
				GameBase::setTeam(%turret,GameBase::getTeam(%player));
				GameBase::setPosition(%csensor,$los::position);
				GameBase::setRotation(%csensor,%rot);
				%csensor.ownerName = Client::getName(%client); 
				dotog(%player);
				Gamebase::setMapName(%csensor,"Cloaking Device");
				Client::sendMessage(%client,0,"Cloaking Device deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%player) @ "Hider"]++;
				echo("MSG: ",%client," ",Client::getName(%client)," deployed a Cloaking Device");
				GameBase::startFadeOut($los::object);
				schedule("toggleCloak(" @ %csensor @ ");", 33, %csensor);
				schedule("GameBase::startFadeOut("@%csensor@");", 6, $los::object);
				%csensor.cloaked = $los::object;
				return true;
			} else {
				Client::sendMessage(%client,0,"Cannot cloak this object");
			}
		} else {
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	} else {																				
	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	}
	return false;
}
function Hider::ondestroyed(%this)
{
	GameBase::starFadeIn($los::object);
	$TeamItemCount[GameBase::getTeam(%player) @ "Hider"]--;
}


function dotog(%player) 
{
	ixToggleDeploy(%player); 
	schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
}

function ixToggleDeploy(%this) { 
	if(%this.isDeploying) 
		%this.isDeploying = false; 
	else 
		%this.isDeploying = true; 
} 

function Hider::onUse(%player,%item)
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

function Hider::onDeploy(%player,%item,%pos)
{
	if (Hider::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}


function toggleCloak(%this) {
	GameBase::startFadeIn(%this);
   schedule("GameBase::startFadeIn(" @ %this.cloaked @ ");", 2.5, %this);
   schedule("GameBase::startFadeOut(" @ %this.cloaked @ ");", 5, %this);
   schedule("GameBase::startFadeOut(" @ %this @ ");", 7.5, %this);
   schedule("toggleCloak(" @ %this @ ");", 45, %this);
}

ItemImageData ProbeDroidPackImage
{	shapeFile = "ammopack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 4;
 	maxEnergy = 4.5;
	firstPerson = false;
};

ItemData ProbeDroidPack
{	description = "Spy Drone";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = dDeployables;
	shadowDetailMask = 4;
	imageType = ProbeDroidPackImage;
	mass = 0.5;
	price = 400;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

FlierData ProbeDroid
{	
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
	className = "Vehicle";
	shapeFile = "discb";
	//shieldShapeName = "shield_medium";
	mass = 0.001;
	drag = 1.0;
	density = 1.2;
	maxBank = 5;
	maxPitch = 12.5;
	maxSpeed = 15;
	maxSideSpeed = 10;
	minSpeed = -15;
	lift = 1.0;
	maxAlt = 40;
	maxVertical = 1;
	maxDamage = 0.0125;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 1.0;
	groundDamageScale = 1; //0.001
	//projectileType = DisruptorBolt;
	projectileType = SniperLaser2; 
	accuFire = true;
	reloadDelay = 2;
	repairRate = 0;
	fireSound = SoundLaserHit;
	damageSound = SoundFlierCrash;
	ramDamage = 0.0001; //0.0001
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundDiscSpin;
	visibleDriver = false;
	driverPose = 22;
	description = "Spy Drone";
};

function ProbeDroidPack::onUse(%player,%item)
{	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function ProbeDroidPack::onDeploy(%player,%item,%pos)
{	if(DeployProbeDroid(%player,%item,ProbeDroid,flier,ProbeDroid)) 
		if(!Player::isDead(%player)) 
			Player::decItemCount(%player,%item);
}

function ProbeDroid::onCollision(%this,%object)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	if (getObjectType(%object) == "Player") 
	{
		if(GameBase::getTeam(%object)==GameBase::getTeam(%this))
		{
//			playNextAnim(%client);
//			Player::kill(%client);
//			Client::onKilled(%client,%client);
			ProbeDroid::onDestroyed(%this);
		}
		else
		{
			ProbeDroid::onDestroyed(%this);
		}
	}
}

function ProbeDroid::jump(%this,%mom)
{	
	ProbeDroid::onDestroyed(%this);
	//GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
}

function DeployProbeDroid(%player,%item,%shape,%data,%name)
{	
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "ProbeDroidPack"] < $TeamItemMax["ProbeDroidPack"])
	{
			%trans = GameBase::getMuzzleTransform(%client);
			%posX = getWord(%trans,9);
			%posY = getWord(%trans,10);
			%posZ = getWord(%trans,11) + 1.5; // +3.0
			%position = %posX@" "@%posY@" "@%posZ;
			%rot = GameBase::getRotation(%player);
			%obj = newObject(ProbeDroid,flier,ProbeDroid,true);
			addToSet("MissionCleanup",%obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			GameBase::setPosition(%obj,%position);
			GameBase::setRotation(%obj,%rot);
			Gamebase::setMapName(%obj,"ProbeDroid");
			Client::sendMessage(%client, 0, "Spy Drone Deployed");
			GameBase::startFadeIn(%obj);
			//GameBase::startFadeOut(%obj);
			playSound(SoundPickupBackpack,$los::position);
			Client::setControlObject(%client,%obj);
			%client.droid=true;
			%player.vehicle = %obj;
			$TeamItemCount[GameBase::getTeam(%player) @ "ProbeDroidPack"]++;
			return true;
	}
	else
	{
		Client::sendMessage(%client,0,"Maximum number of ProbeDroids deployed");
		return false;
	}
}

function ProbeDroid::onDestroyed(%this)
{
	%client = GameBase::getControlClient(%this);
	%player = Client::getOwnedObject(%client);
	//Player::setMountObject(%player, -1, 0);
	Client::setControlObject(%client,%player);
	%client.droid=false;
	%player.vehicle = "";
	Client::sendMessage(%client,0,"Connection to ProbeDroid lost");
	$TeamItemCount[GameBase::getTeam(%this) @ "ProbeDroidPack"]--;
	//GameBase::startFadeOut(%this);
	//GameBase::applyDamage(%this,$ImpactDamageType,0.0125,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	GameBase::setDamageLevel(%this,1);
}

ItemImageData DeployableComPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 4.5; firstPerson = false; }; 

ItemData DeployableComPack { description = "Command Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4 ; imageType = DeployableComPackImage; mass = 4.0; elasticity = 0.2; price = $RemoteComEnergy + 200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableComPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableComPack::onDeploy(%player,%item,%pos) { if (DeployableComPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DeployableComPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %inv = newObject("comunit_remote","StaticShape","DeployableComStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,%name); Client::sendMessage(%client,0,"Command Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableComPack"]++; return true; } } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData EnergyPackImage { shapeFile = "jetPack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; minEnergy = -3; maxEnergy = -5; firstPerson = false; }; 

ItemData EnergyPack { description = "Energy Pack"; shapeFile = "jetPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = EnergyPackImage; price = 150; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function EnergyPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } function EnergyPack::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); } function EnergyPack::onUnmount(%player,%item) { if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) Player::unmountItem(%player,$WeaponSlot); } 

ItemImageData RepairPackImage { shapeFile = "armorPack"; mountPoint = 2; weaponType = 2; minEnergy = 0; maxEnergy = 0; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData RepairPack { description = "Repair Pack"; shapeFile = "armorPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = RepairPackImage; price = 125; hudIcon = "repairpack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function RepairPack::onUnmount(%player,%item) { if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) { Player::unmountItem(%player,$WeaponSlot); } } function RepairPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::mountItem(%player,RepairGun,$WeaponSlot); } } function RepairPack::onDrop(%player,%item) { if($matchStarted) { %mounted = Player::getMountedItem(%player,$WeaponSlot); if (%mounted == RepairGun) { Player::unmountItem(%player,$WeaponSlot); } else { Player::mountItem(%player,%mounted,$WeaponSlot); } Item::onDrop(%player,%item); } } 

ItemImageData ShieldPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; minEnergy = 4; maxEnergy = 9; sfxFire = SoundShieldOn; firstPerson = false; }; 

ItemData ShieldPack { description = "Shield Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = ShieldPackImage; price = 175; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function ShieldPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Shield On"); %player.shieldStrength = 0.012; } function ShieldPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Shield Off"); Player::trigger(%player,$BackpackSlot,false); %player.shieldStrength = 0; } 

ItemImageData SensorJammerPackImage { shapeFile = "sensorjampack"; mountPoint = 2; weaponType = 2; maxEnergy = 10; sfxFire = SoundJammerOn; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData SensorJammerPack { description = "Sensor Jammer Pack"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = SensorJammerPackImage; price = 200; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function SensorJammerPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On"); %rate = Player::getSensorSupression(%player) + 20; Player::setSensorSupression(%player,%rate); } function SensorJammerPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off"); %rate = Player::getSensorSupression(%player) - 20; Player::setSensorSupression(%player,%rate); Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData CloakingDeviceImage { shapeFile = "sensorjampack"; mountPoint = 2; weaponType = 2; maxEnergy = 10; sfxFire = SoundJammerOn; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData CloakingDevice { description = "Cloaking Device"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = CloakingDeviceimage; price = 600; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; }; function CloakingDeviceImage::onActivate(%player,%imageSlot) { GameBase::startFadeout(%player); Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On"); %rate = Player::getSensorSupression(%player) + 5; Player::setSensorSupression(%player,%rate); %player.guiLock = true; %c = Player::getClient(%player); %c.guiLock = true; %clientId.ghostDoneFlag = true; startGhosting(%cl); } function CloakingDeviceImage::onDeactivate(%player,%imageSlot) { GameBase::startFadein(%player); Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off"); %rate = Player::getSensorSupression(%player) - 5; Player::setSensorSupression(%player,%rate); Player::trigger(%player,$BackpackSlot,false); %player.guiLock = ""; %c = Player::getClient(%player); %c.guiLock = ""; } 

ItemImageData StealthShieldPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; minEnergy = 6; maxEnergy = 9; sfxFire = SoundShieldOn; firstPerson = false; }; 

ItemData StealthShieldPack { description = "StealthShield Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = StealthShieldPackImage; price = 275; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; }; function StealthShieldPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"StealthShield On"); %player.shieldStrength = 0.012; %rate = Player::getSensorSupression(%player) + 20; Player::setSensorSupression(%player,%rate); } function StealthShieldPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"StealthShield Off"); Player::trigger(%player,$BackpackSlot,false); %player.shieldStrength = 0; %rate = Player::getSensorSupression(%player) - 20; Player::setSensorSupression(%player,%rate); } 

ItemImageData RegenerationPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; minEnergy = 8; maxEnergy = 14; sfxFire = SoundRepairItem; projectileType = AutoBolt; }; 

ItemData RegenerationPack { description = "Regeneration Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = RegenerationPackImage; price = 275; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; }; function RegenerationPackImage::onActivate(%player,%imageSlot) { %clientId = Player::getClient(%player); } function RegenerationPackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } function TransferHealth(%clientId, %player) { Client::sendMessage(%clientId,1,"Regeneration On"); Player::unmountItem(%player,$WeaponSlot); if($regTime[%clientId] == 0) { GameBase::setEnergy(%player,0); GameBase::setRechargeRate(%player,0); $regTime[%clientId] = 10; checkPlayerDrain(%clientId, %player); } else $regTime[%clientId] = 10; } function checkPlayerDrain(%clientId, %player) { if($regTime[%clientId] > 0) { $regTime[%clientId] -= 2; if(GameBase::getDamageLevel(%player)) { GameBase::repairDamage(%player,0.04); GameBase::playSound(%player,ForceFieldOpen,0); } schedule("checkPlayerDrain(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,1,"Regeneration Off"); GameBase::setRechargeRate(%player,8); } } 

ItemImageData LightningPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; projectileType = boltCharge; minEnergy = 9; maxEnergy = 10; reloadTime = 0.2; sfxFire = SoundELFIdle; }; 

ItemData LightningPack { description = "Lightning Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = LightningPackImage; price = 275; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; }; function LightningPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Lightning Field On"); } function LightningPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Lightning Field Off"); Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData OpticPackImage { shapeFile = "repairgun"; mountPoint = 2; mountOffset = { 0.2, 0.4, 0.45 }; mountRotation = { 0, 0, 0 }; weaponType = 0; projectileType = SniperLaser; accuFire = true; reloadTime = 6.5; fireTime = 0.0; minEnergy = 10; maxEnergy = 60; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 1, 0, 0 }; sfxFire = SoundFireLaser; }; 

ItemData OpticPack { description = "Cybernetic Laser"; shapeFile = "repairgun"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = OpticPackImage; price = 275; hudIcon = "sniper"; showWeaponBar = true; hiliteOnActive = true; }; function OpticPackImage::onActivate(%player,%imageSlot) { schedule("use(\"backpack\");", 0.5); } function OpticPackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData SMRPackImage { shapeFile = "mortargun"; mountPoint = 2; mountOffset = { -0.4, 0.1, 0.4 }; mountRotation = { 0.2, 0, 0 }; weaponType = 0; ammoType = RocketAmmo; projectileType = StingerMissile; accuFire = true; reloadTime = 5.0; fireTime = 0.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxReload = SoundMortarReload; }; 

ItemData SMRPack { description = "Auto-Rocket Cannon"; shapeFile = "mortargun"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = SMRPackImage; price = 350; hudIcon = "mortar"; showWeaponBar = true; hiliteOnActive = true; }; function SMRPackImage::onActivate(%player,%imageSlot) { schedule("use(\"backpack\");", 0.5); } function SMRPackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData LaptopImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; weaponType = 2; minEnergy = -1; maxEnergy = -3; mass = 0.5; firstPerson = false; }; 

ItemData Laptop { description = "Command Laptop"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = LaptopImage; price = 650; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; }; function Laptop::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } function Laptop::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); } function Laptop::onUnmount(%player,%item) { } 

ItemImageData SuicidePackImage { shapeFile = "magcargo"; mountPoint = 2; mountOffset = { 0, -0.5, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData SuicidePack { description = "Suicide DetPack"; shapeFile = "magcargo"; className = "Backpack"; heading = "cBackpacks"; imageType = SuicidePackImage; shadowDetailMask = 4; mass = 2.5; elasticity = 0.2; price = 450; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function SuicidePack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else if(%player.station == "") { Player::deployItem(%player,%item); } } function SuicidePack::onUnmount(%player,%item) { } function SuicidePack::onDeploy(%player,%item,%pos) { if (SuicidePack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function SuicidePack::deployShape(%player,%item) { Player::unmountItem(%player,$BackpackSlot); %obj = newObject("","Mine","Suicidebomb2"); addToSet("MissionCleanup", %obj); %client = Player::getClient(%player); GameBase::throw(%obj,%player,4,false); Client::sendMessage(%client,1,"Det Pack will destruct in 20 seconds"); } 

ItemImageData EspPackImage { shapeFile = "ammoPack"; mountPoint = 2; weaponType = 2; minEnergy = 2; maxEnergy = 8.5; firstPerson = false; }; 

ItemData EspPack { description = "Espionage Pack"; shapeFile = "ammoPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = EspPackImage; price = 175; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; }; 

function EspPackImage::onActivate(%player,%imageSlot) 
{ 
	%clientId = Player::getClient(%player); 
	if(getNumTeams() > 2 || $UnCvrA || $UnCvrB) 
	{ 
		if(getNumTeams() > 2) 
		{ 
			Client::sendMessage(%clientId,0,"Can't go undercover with more then 2 teams~waccess_denied.wav"); 
			Player::decItemCount(%clientId, Player::getMountedItem(%clientId,$BackpackSlot)); 
			return; 
		} 
		else if(GameBase::getTeam($UnCvrA) == GameBase::getTeam(%clientId)) { Client::sendMessage(%clientId,0,Client::getName($UnCvrA) @ " is undercover now, one at a time~waccess_denied.wav"); Player::trigger(%player, $BackpackSlot, false); return; } else if(GameBase::getTeam($UnCvrB) == GameBase::getTeam(%clientId)) { Client::sendMessage(%clientId,0,Client::getName($UnCvrB) @ " is undercover now, one at a time~waccess_denied.wav"); Player::trigger(%player, $BackpackSlot, false); return; } } Player::dropItem(%clientId, Flag); %clientId.isSpy = true; if (Client::getTeam(%clientId) == 0) { $UnCvrA = %clientId; %clientId.OrigTeam = 5; teamMessages(1, 0, Client::getName(%clientId) @ " Went UNDERCOVER", -2, "", ""); Client::setinitialTeam(%clientId, 1); GameBase::setTeam(%clientId, 1); Client::setinitialTeam(%clientId, 0); Client::setSkin(%clientId, $Server::teamSkin[1]); } else { $UnCvrB = %clientId; %clientId.OrigTeam = 6; teamMessages(1, 1, Client::getName(%clientId) @ " Went UNDERCOVER", -2, "", ""); Client::setinitialTeam(%clientId, 0); GameBase::setTeam(%clientId, 0); Client::setinitialTeam(%clientId, 1); Client::setSkin(%clientId, $Server::teamSkin[0]); } } function EspPackImage::onDeactivate(%player,%imageSlot) { %cl = Player::getClient(%player); if(%cl.OrigTeam != 5 && %cl.OrigTeam != 6) return; if(%cl.OrigTeam == 5) { $UnCvrA = ""; GameBase::setTeam(%cl,0); } else if(%cl.OrigTeam == 6) 
{ $UnCvrB = ""; GameBase::setTeam(%cl,1); } if(%cl.custom) Client::setSkin(%cl, $Client::info[%cl, 0]); else Client::setSkin(%cl, $Server::teamSkin[Client::getTeam(%cl)]); %pack = Player::getMountedItem(%cl,$BackpackSlot); Player::decItemCount(%player, %pack); %cl.isSpy = false; %cl.OrigTeam = ""; Client::sendMessage(%cl,0,"Espionage Pack Off~waccess_denied.wav"); } 

ItemImageData MotionSensorPackImage { shapeFile = "sensor_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; 

ItemData MotionSensorPack { description = "Motion Sensor"; shapeFile = "sensor_small"; className = "Backpack"; heading = "dDeployables"; imageType = MotionSensorPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 125; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function MotionSensorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function MotionSensorPack::onDeploy(%player,%item,%pos) { if (MotionSensorPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++; } } function MotionSensorPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %mSensor = newObject("","Sensor",DeployableMotionSensor,true); addToSet("MissionCleanup", %mSensor); GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); GameBase::setRotation(%mSensor,%rot); GameBase::setPosition(%mSensor,$los::position); Gamebase::setMapName(%mSensor,"Motion Sensor"); Client::sendMessage(%client,0,"Motion Sensor deployed"); playSound(SoundPickupBackpack,$los::position); if($ConOutput != 3) if($ConOutput != 3) echo("MSG: ",%client," deployed a Motion Sensor"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } 
else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData AmmoPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; firstPerson = false; }; 

ItemData AmmoPack { description = "Ammo Pack"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "cBackpacks"; imageType = AmmoPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 325; hudIcon = "ammopack"; showWeaponBar = true; hiliteOnActive = true; }; function AmmoPack::onDrop(%player, %item) { if($matchStarted) { %item = Item::onDrop(%player,%item); for(%i = 0; %i < 14 ; %i = %i +1) { %numPack = 0; %ammoItem = $AmmoPackItems[%i]; %maxnum = $ItemMax[Player::getArmor(%player), %ammoItem]; %pCount = Player::getItemCount(%player, %ammoItem); if(%pCount > %maxnum) { %numPack = %pCount - %maxnum; Player::decItemCount(%player,%ammoItem,%numPack); } if(%i == 0) { %item.BulletAmmo = %numPack; } else if(%i == 1) { %item.PlasmaAmmo = %numPack; } else if(%i == 2) { %item.DiscAmmo = %numPack; } else if(%i == 3) { %item.GrenadeAmmo = %numPack; } else if(%i == 4) { %item.Grenade = %numPack; } else if(%i == 5) { %item.MortarAmmo = %numPack; } else if(%i == 6) { %item.RocketAmmo = %numPack; } else if(%i == 7) { %item.SniperAmmo = %numPack; } else if(%i == 8) { %item.RailAmmo = %numPack; } else if(%i == 9) { %item.SilencerAmmo = %numPack; } else if(%i == 10) { %item.VulcanAmmo = %numPack; } else if(%i == 11) { %item.Beacon = %numPack; } else if(%i == 12) { %item.TranqAmmo = %numPack; } else { %item.MineAmmo = %numPack; } } } } function AmmoPack::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { %item = Item::getItemData(%this); %count = Player::getItemCount(%object,%item); if (Item::giveItem(%object,%item,Item::getCount(%this))) { Item::playPickupSound(%this); checkPacksAmmo(%object, %this); Item::respawn(%this); } } } function checkPacksAmmo(%player, %item) { for(%i = 0; %i < 14 ; %i = %i +1) { %ammoItem = $AmmoPackItems[%i]; if(%i == 0) { %numAdd = %item.BulletAmmo; } else if(%i == 1) { %numAdd = %item.PlasmaAmmo; } else if(%i == 2) { %numAdd = %item.DiscAmmo; } else if(%i == 3) { %numAdd = %item.GrenadeAmmo; } else if(%i == 4) { %numAdd = %item.Grenade; } else if(%i == 5) 
{ %numAdd = %item.MortarAmmo; } else if(%i == 6) { %numAdd = %item.RocketAmmo; } else if(%i == 7) { %numAdd = %item.SniperAmmo; } else if(%i == 8) { %numAdd = %item.RailAmmo; } else if(%i == 9) { %numAdd = %item.SilencerAmmo; } else if(%i == 10) { %numAdd = %item.VulcanAmmo; } else if(%i == 11) { %numAdd = %item.Beacon; } else if(%i == 12) { %numAdd = %item.TranqAmmo; } else { %numAdd = %item.MineAmmo; } Player::incItemCount(%player,%ammoItem,%numAdd); } } function fillAmmoPack(%client) { %player = Client::getOwnedObject(%client); for(%i = 0; %i < 14 ; %i = %i +1) { %item = $AmmoPackItems[%i]; %maxnum = $AmmoPackMax[%item]; %maxnum = checkResources(%player,%item,%maxnum); if(%maxnum) { Player::incItemCount(%client,%item,%maxnum); teamEnergyBuySell(%player,%item.price * %maxnum * -1); } } } 

ItemImageData PulseSensorPackImage { shapeFile = "radar_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; 

ItemData PulseSensorPack { description = "Pulse Sensor"; shapeFile = "radar_small"; className = "Backpack"; heading = "dDeployables"; imageType = PulseSensorPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 125; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function PulseSensorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function PulseSensorPack::onDeploy(%player,%item,%pos) { if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++; } } 

ItemImageData DeployableSensorJamPackImage { shapeFile = "sensor_jammer"; mountPoint = 2; mountOffset = { 0, 0.03, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; 

ItemData DeployableSensorJammerPack { description = "Sensor Jammer"; shapeFile = "sensor_jammer"; className = "Backpack"; heading = "dDeployables"; imageType = DeployableSensorJamPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 225; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeployableSensorJammerPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DeployableSensorJammerPack::onDeploy(%player,%item,%pos) { if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++; } } 

ItemImageData DefenseAlarmImage { shapeFile = "sensor_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; };

ItemData DefenseAlarm { description = "Defense Alarm"; shapeFile = "sensor_small"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4; imageType = DefenseAlarmImage; mass = 2.0; elasticity = 0.2; price = 50; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DefenseAlarm::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DefenseAlarm::onDeploy(%player,%item,%pos) { if ( DefenseAlarm::deployShape(%player,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "DefenseAlarm"]++; } } function DefenseAlarm::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "InteriorShape"){ %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %alarm = newObject("","StaticShape", "AlarmKit",true); addToSet("MissionCleanup", %alarm); GameBase::setTeam(%alarm,GameBase::getTeam(%player)); GameBase::setRotation(%alarm,%rot); GameBase::setPosition(%alarm,$los::position); Gamebase::setMapName(%alarm,%name); Gamebase::setMapName(%alarm,"Defense Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)]++); Client::sendMessage(%client,0,"Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)] @ " deployed"); $TeamItemCount[GameBase::getTeam(%SGen) @ "DefenseAlarm"]++; return true; } } else { Client::sendMessage(%client,0,"Can only deploy on buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

ItemImageData CameraPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData CameraPack { description = "Camera"; shapeFile = "camera"; className = "Backpack"; heading = "dDeployables"; imageType = CameraPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 100; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; validateShape = true; validateMaterials = true; }; function CameraPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function CameraPack::onDeploy(%player,%item,%pos) { if (CameraPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function CameraPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",CameraTurret,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Camera deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Camera"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData TurretPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData TurretPack 
{ 
	description = "Ion Turret"; 
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{ 
		Player::mountItem(%player,%item,$BackpackSlot); 
	} 
	else 
	{ 
		Player::deployItem(%player,%item); 
	} 
} 
function TurretPack::onDeploy(%player,%item,%pos) 
{ 
	if (TurretPack::deployShape(%player,%item)) 
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
function TurretPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if(0 == %num) { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot, 2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal, "0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %turret = newObject("remoteTurret","Turret",DeployableTurret,true); 
addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"RMT Ion Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Remote Ion Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Remote Turret"); Client::setOwnedObject(%client, %turret); Client::setOwnedObject(%client, %player); return true; } } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

function checkDeployArea(%client,%pos) 
{ 
	%set=newObject("set",SimSet); 
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1); 
	if(!%num) 
	{ 
		deleteObject(%set); 
		return 1; 
	} 
	else 
	if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") 
	{ 
		%obj = Group::getObject(%set,0); 
		if(Player::getClient(%obj) == %client) 
			Client::sendMessage(%client,0,"Unable to deploy - You're in the way"); 
		else Client::sendMessage(%client,0,"Unable to deploy - Player in the way"); 
	} 
	else 
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way"); 
	deleteObject(%set); 
	return 0; 
} 

function checkFlierArea(%cl, %pos) { %set = newObject("set", SimSet); %num = containerBoxFillSet(%set, $SimPlayerObjectType, %pos, 8, 8, 8, 0); if(%num < 2 && Player::getClient(Group::getObject(%set, 0)) == %cl) return true; else { Client::sendMessage(%cl,0,"Too many players in area"); return false; } deleteObject(%set); } 

ItemImageData LaserPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData LaserPack { description = "Laser Turret"; shapeFile = "camera"; className = "Backpack"; heading = "dDeployables"; imageType = CameraPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 300; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function LaserPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function LaserPack::onDeploy(%player,%item,%pos) { if (LaserPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function LaserPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableLaser",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",DeployableLaser,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Laser Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++; return true; } } else { 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else Client::sendMessage(%client,0,"Interference from other laser turrets in the area"); } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData ShockPackImage { shapeFile = "indoorgun"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData ShockPack { description = "Shock Turret"; shapeFile = "indoorgun"; className = "Backpack"; heading = "dDeployables"; imageType = ShockPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function ShockPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function ShockPack::onDeploy(%player,%item,%pos) { if (ShockPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function ShockPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableShock",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %camera = newObject("Camera","Turret",DeployableShock,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Shock Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Shock Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "ShockPack"]++; return true; } else 
Client::sendMessage(%client,0,"Interference from other Shock turrets in the area"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData TargetPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData TargetPack { description = "Mortar Turret"; shapeFile = "mortar_turret"; className = "Backpack"; heading = "dDeployables"; imageType = TargetPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 800; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TargetPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TargetPack::onMount(%player,%item) { %client = Player::getClient(%player); Bottomprint(%client, "The Mortar Turret has no auto-sensor and must be controlled manually to fire."); } function TargetPack::onDeploy(%player,%item,%pos) { if (TargetPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function TargetPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableMortar",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableMortar,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); 
Gamebase::setMapName(%turret,"Mortar Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Remote Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TargetPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Remote Turret"); Client::setOwnedObject(%client, %turret); Client::setOwnedObject(%client, %player); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData LaserTurretImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData LaserTurret { description = "Plasma Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = LaserTurretImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 650; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function LaserTurret::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function LaserTurret::onDeploy(%player,%item,%pos) { if (LaserTurret::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function CountObjects(%set,%name,%num) { %count = 0; for(%i=0;%i<%num;%i++) { %obj=Group::getObject(%set,%i); if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; } return %count; } function LaserTurret::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("hellfiregun","Turret",DeployablePlasma,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); 
Gamebase::setMapName(%turret,"Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Plasma Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "LaserTurret"]++;Client::setOwnedObject(%client, %turret); Client::setOwnedObject(%client, %player); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } function checkDeployArea(%client,%pos) { %set=newObject("set",SimSet); %num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1); if(!%num) { deleteObject(%set); return 1; } else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { %obj = Group::getObject(%set,0); if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way"); else Client::sendMessage(%client,0,"Unable to deploy - Player in the way"); } else Client::sendMessage(%client,0,"Unable to deploy - Item in the way"); deleteObject(%set); return 0; } 

ItemImageData VulcanTurretImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData VulcanTurret { description = "Vulcan Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = VulcanTurretImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 750; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function VulcanTurret::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function VulcanTurret::onDeploy(%player,%item,%pos) { if (VulcanTurret::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function VulcanTurret::onMount(%player,%item) { %client = Player::getClient(%player); Bottomprint(%client, "The Vulcan Turret has no auto-sensor and must be controlled manually to fire."); } function CountObjects(%set,%name,%num) { %count = 0; for(%i=0;%i<%num;%i++) { %obj=Group::getObject(%set,%i); if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; } return %count; } function VulcanTurret::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableVulcan",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("hellfiregun","Turret",DeployableVulcan,true);
 addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"Vulcan Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Vulcan Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "VulcanTurret"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData RailTurretImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData RailTurret { description = "Rail Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = VulcanTurretImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 850; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function RailTurret::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function RailTurret::onDeploy(%player,%item,%pos) { if (RailTurret::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function RailTurret::onMount(%player,%item) { %client = Player::getClient(%player); Bottomprint(%client, "The Rail Turret has no auto-sensor and must be controlled manually to fire."); } function CountObjects(%set,%name,%num) { %count = 0; for(%i=0;%i<%num;%i++) { %obj=Group::getObject(%set,%i); if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; } return %count; } function RailTurret::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableVulcan",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployablePlasma",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("hellfiregun","Turret",DeployableRail,true); 
addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"Rail Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Rail Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData TrackingTurretPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; };

ItemData TrackingTurretPack { description = "TrackingTurret"; shapeFile = "camera"; className = "Backpack"; heading = "dDeployables"; imageType = TrackingTurretPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 350; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TrackingTurretPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TrackingTurretPack::onDeploy(%player,%item,%pos) { if (TrackingTurretPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function CountObjects(%set,%name,%num) { %count = 0; for(%i=0;%i<%num;%i++) { %obj=Group::getObject(%set,%i); if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; } return %count; } function TrackingTurretPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"TrackingTurret",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"TrackingTurret",%num); deleteObject(%set); if(0 == %num) { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot, 2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal, "0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { 
%turret = newObject("camera","Turret",TrackingTurret,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); Gamebase::setMapName(%turret,"TrackingTurret##" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"TrackingTurret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TrackingTurretPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a TrackingTurret"); return true; } } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } function checkDeployArea(%client,%pos) { %set=newObject("set",SimSet); %num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1); if(!%num) { deleteObject(%set); return 1; } else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { %obj = Group::getObject(%set,0); if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way"); else Client::sendMessage(%client,0,"Unable to deploy - Player in the way"); } else Client::sendMessage(%client,0,"Unable to deploy - Item in the way"); deleteObject(%set); return 0; } function checkFlierArea(%cl, %pos) { %set = newObject("set", SimSet); %num = containerBoxFillSet(%set, $SimPlayerObjectType, %pos, 8, 8, 8, 0); if(%num < 2 && Player::getClient(Group::getObject(%set, 0)) == %cl) return true; else { Client::sendMessage(%cl,0,"Too many players in area"); return false; } deleteObject(%set); } 

ItemImageData RocketPackImage { shapeFile = "logo"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 3.0; firstPerson = false; };

ItemData RocketPack { description = "MissileTurret"; shapeFile = "missileturret"; className = "Backpack"; heading = "dDeployables"; imageType = RocketPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 950; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function RocketPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function RocketPack::onDeploy(%player,%item,%pos) { if (RocketPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function RocketPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("missileturret","Turret",DeployableRocket,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); 
Gamebase::setMapName(%turret,"Missile#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Missile Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

ItemImageData BarragePackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 3.0; firstPerson = false; }; 

ItemData BarragePack { description = "Anti-Aircraft Turret"; shapeFile = "missileturret"; className = "Backpack"; heading = "dDeployables"; imageType = BarragePackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 950; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function BarragePack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function BarragePack::onDeploy(%player,%item,%pos) { if (BarragePack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function BarragePack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"AntiAirCraftTurret",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"AntiAirCraftTurret",%num); deleteObject(%set); if(0 == %num) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("missileturret","Turret",AntiAirCraftTurret,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); 
Gamebase::setMapName(%turret,"AntiAircraftTurret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Anti-Aircraft Turret deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "BarragePack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData ForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData ForceFieldPack { description = "Force Field"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = ForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function ForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function ForceFieldPack::onDeploy(%player,%item,%pos) { if (ForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function ForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableForceField",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",DeployableForceField,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Force Field"); Client::sendMessage(%client,0,"Force Field Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++; return true; } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData LargeForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData LargeForceFieldPack { description = "Large Force Field"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = LargeForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 1200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function LargeForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function LargeForceFieldPack::onDeploy(%player,%item,%pos) { if (LargeForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function LargeForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %lrgff = newObject("","StaticShape",LargeForceField,true); addToSet("MissionCleanup", %lrgff); GameBase::setTeam(%lrgff,GameBase::getTeam(%player)); GameBase::setPosition(%lrgff,$los::position); GameBase::setRotation(%lrgff,%rot); Gamebase::setMapName(%lrgff,"Large Force Field#"@ $totalNumlrgffs++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Force Field Deployed"); GameBase::startFadeIn(%lrgff); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++; return true; } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData FloorDoorPackImage 
{ 
	shapeFile = "AmmoPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData FloorDoorPack 
{ 
	description = "Force Field Floor Door"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
	heading = "gDoors"; 
	imageType = FloorDoorPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 900; 
	hudIcon = "deployable2"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 
function FloorDoorPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{ Player::mountItem(%player,%item,$BackpackSlot); } 
	else { Player::deployItem(%player,%item); } 
} 
	
function FloorDoorPack::onDeploy(%player,%item,%pos) 
{ 
	if (FloorDoorPack::deployShape(%player,%item)) 
	{ Player::decItemCount(%player,%item); } 
}

function FloorDoorPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
		if (GameBase::getLOSInfo(%player,3)) 
		{ 
			%obj = getObjectType($los::object); 
			%set = newObject("set",SimSet); 
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); 
			%num = CountObjects(%set,"DeployableDoorfivebyfiveForceField",%num); 
			deleteObject(%set); 
			//if (Vector::dot($los::normal,"0 0 1") > 0.7) 
			//{ 
				%rot = Vector::add(GameBase::getRotation(%player),"1.57 0 0");
				%phase = newObject("","StaticShape",DoorfivebyfiveForceField,true); 
				addToSet("MissionCleanup", %phase); 
				GameBase::setTeam(%phase,GameBase::getTeam(%player)); 
				GameBase::setPosition(%phase,$los::position); 
				GameBase::setRotation(%phase,%rot); 
				Gamebase::setMapName(%phase,"Force Field Floor Door"); 
				Client::sendMessage(%client,0,"Force Field Floor Door Deployed"); 
				GameBase::startFadeIn(%phase); 
				playSound(SoundPickupBackpack,$los::position); 
				playSound(ForceFieldOpen,$los::position); 
				$TeamItemCount[GameBase::getTeam(%player) @ "FloorDoorPack"]++; return true; 
			//} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
		} 
		else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }  

ItemImageData TripwirePackImage { shapeFile = "sensor_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData TripwirePack { description = "Blast Wall"; shapeFile = "sensor_small"; className = "Backpack"; heading = "dDeployables"; imageType = TripwirePackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TripwirePack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TripwirePack::onDeploy(%player,%item,%pos) { if (TripwirePack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function TripwirePack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %bwall = newObject("","StaticShape",BlastWall,true); addToSet("MissionCleanup", %bwall); GameBase::setTeam(%bwall,GameBase::getTeam(%player)); GameBase::setPosition(%bwall,$los::position); GameBase::setRotation(%bwall,%rot); Gamebase::setMapName(%bwall,"Blast Wall"); Client::sendMessage(%client,0,"Blast Wall Deployed"); GameBase::startFadeIn(%bwall); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TripwirePack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy " @ %item.description @ "s on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData HoloPackImage { shapeFile = "ShieldPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 1.0; firstPerson = false; }; 

ItemData HoloPack { description = "Hologram"; shapeFile = "larmor"; className = "Backpack"; heading = "dDeployables"; imageType = HoloPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 900; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function HoloPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function HoloPack::onDeploy(%player,%item,%pos) { if (HoloPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function HoloPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["hologram"]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"Hologram",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %rnd = floor(getRandom() * 10); if(%rnd > 6) %phase = newObject("","StaticShape",Hologram1,true); else if((%rnd > 2) && (%rnd < 7)) %phase = newObject("","StaticShape",Hologram2,true); else %phase = newObject("","StaticShape",Hologram3,true); %armor = Player::getArmor(%player); if (%armor == "dmarmor" || %armor == "dmfemale") { %phase = newObject("","StaticShape",Hologram2,true); } addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Client::sendMessage(%client,0,"Hologram Deployed"); GameBase::startFadeIn(%phase); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++; return true; } } else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData TreePackImage { shapeFile = "tree1"; mountPoint = 2; mountOffset = { 0, 0.15, -1 }; mass = 2.5; firstPerson = false; }; 

ItemData TreePack { description = "Mechanical Tree"; shapeFile = "tree1"; className = "Backpack"; heading = "dDeployables"; imageType = TreePackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TreePack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TreePack::onDeploy(%player,%item,%pos) { if (TreePack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function TreePack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableTree",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %rnd = floor(getRandom() * 10); if(%rnd > 5) %phase = newObject("","StaticShape",DeployableTree,true); else %phase = newObject("","StaticShape",DeployableTree2,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Mechanical Tree"); Client::sendMessage(%client,0,"Mechanical Tree Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain"); } 
else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData DeathStarImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, 0.15, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData DeathStarPack { description = "DeathStar"; shapeFile = "remoteturret"; className = "Backpack"; heading = "hRemote Turrets"; imageType = DeathStarImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 5000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DeathStarPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot); else Player::deployItem(%player,%item); } function DeathStarPack::onDeploy(%player,%item,%pos) { if (DeathStarPack::deployShape(%player,%item)) Player::decItemCount(%player,%item); }

function DeathStarPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
    if(($server::TourneyMode && !$DS::TourneyOn) || $Reneg::DSdisable) { bottomprint(%client, "<f1><jc>Deathstars have been disabled",3); return false; }
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
{
if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);

                         %playerPos = GameBase::getPosition(%player);
                         %flag = $teamFlag[GameBase::getTeam(%player)];
                         %flagpos = gamebase::getPosition(%flag);

                         if(Vector::getDistance(%flagpos, %playerpos) > 200)
                          {
                          bottomprintAll("This Dumbass is trying to set an offensive DeathStar!!! This is the guy ====>  "  @    Client::getName(%client) , 30);
                          return;
                          }
%obj = getObjectType($los::object);
if(%obj == "SimTerrain")
{
if(Vector::dot($los::normal,"0 0 1") > 0.7)
{
if(checkDeployArea(%client,$los::position))
{
if(DeathDeployCheck(%player,$los::position))
{
if(floor(getRandom() * 40) != 0)
{
%rot = GameBase::getRotation(%player);
%client = Player::getClient(%player);
%phase = newObject("","StaticShape",DeployableDeathStar,true);
addToSet("MissionCleanup", %phase);
GameBase::setTeam(%phase,GameBase::getTeam(%player));
GameBase::setPosition(%phase,$los::position);
GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"SatAllite Launcher"); Client::sendMessage(%client,0,"DeathStar launcher deployed."); playSound(SoundForceFieldOpen,$los::position); %dposition = $los::position; DeathLaunch(%player,%item,$los::position,3); return true; } else { schedule("DeathstarOpps(" @ %player @ ",\"" @ $los::position @ "\");",0.3); Client::sendMessage(Player::getClient(%player),1,"The launcher was defective"); return true; } } } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } function DeathDeployCheck(%player,%pos) { %client = Player::getClient(%player); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,%pos,4,4,50,0); deleteObject(%set); if(%num == 0) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,%pos,8,8,2,0); %num = CountObjects(%set,"BlastWall",%num); deleteObject(%set); if(%num > 3) { if(%num < 5) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,%pos,8,1,2,0); %num = CountObjects(%set,"BlastWall",%num); deleteObject(%set); if(%num == 2) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,%pos,1,8,2,0); %num = CountObjects(%set,"BlastWall",%num); deleteObject(%set); if(%num == 2) return true; else Client::sendMessage(%client,0,"Only 2 or 3 walls placed correctly"); } else Client::sendMessage(%client,0,"Only 1 wall recognized"); } else Client::sendMessage(%client,0,"Too many Blast Walls"); } else Client::sendMessage(%client,0,"Need 4 Blast Walls to build a launch area"); } else Client::sendMessage(%client,0,"Too close to wall, or object blocking launch path"); return false; } function DeathstarOpps(%this,%position) 
{ %dpos = getWord(%position,0) @ " " @ getWord(%position,1) @ " " @ getWord(%position,2) + 5; GameBase::applyRadiusDamage($DebrisDamageType,%dpos,15,12,200,%this); schedule("GameBase::applyRadiusDamage(" @ $DebrisDamageType @ ",\"" @ %dpos @ "\",15,12,200," @ %this @ ");",0.3); } function DeathLaunch(%player,%item,%position,%time) { %client = Player::getClient(%player); if(%time == 0) { %rot = GameBase::getRotation(%player); %pteam = GameBase::getTeam(%player); %posStart = getWord(%position,0) @ " " @ getWord(%position,1); %posLas = %posStart @ " " @ getWord(%position,2) + 249.6; %posMis = %posStart @ " " @ getWord(%position,2) + 250.4; %posSol = %posStart @ " " @ getWord(%position,2) + 250.5; %lasmisRot = 0 @ " " @ 3.14145 @ " " @ getword(%rot,2); %solRot = -1.5 @ " " @ 3.14145 @ " " @ getword(%rot,2); %laser = newObject("camera","Turret",DeathStarRay,true); addToSet("MissionCleanup", %laser); GameBase::setTeam(%laser,%pteam); GameBase::setPosition(%laser,%posLas); GameBase::setRotation(%laser,%lasmisRot); Gamebase::setMapName(%laser,"Sat Laser " @ $totalNumTurrets++ @ " " @ Client::getName(%client)); %missile = newObject("remoteturret","Turret",DeathStarMissile,true); addToSet("MissionCleanup", %missile); GameBase::setTeam(%missile,%pteam); GameBase::setPosition(%missile,%posMis); GameBase::setRotation(%missile,%lasmisRot); Gamebase::setMapName(%missile,"Sat Missile " @ $totalNumTurrets++ @ " " @ Client::getName(%client)); %solar = newObject("SolarPanel","StaticShape","DeathStarSolar",true); addToSet("MissionCleanup", %solar); GameBase::setTeam(%solar,%pteam); GameBase::setPosition(%solar,%posSol); GameBase::setRotation(%solar,%solRot); GameBase::setActive(%solar,false); if($ConOutput != 3) echo("MSG: ",%client," launched a Remote Satellite"); Client::sendMessage(%client,0,"DeathStar Launched"); $TeamItemCount[GameBase::getTeam(%player) @ "DeathStarPack"]++; DeathstarOpps(%item,%position); return; } else if(%time == 3) Client::sendMessage(%client,1,"3~waccess_denied.wav"); else if(%time == 2) 
Client::sendMessage(%client,1,"2~waccess_denied.wav"); 
else if(%time
 == 1) Client::sendMessage(%client,1,"1~waccess_denied.wav"); schedule("DeathLaunch(" @ %player @ "," @ %item @ ",\"" @ %position @ "\"," @ %time - 1 @ ");",1.5); }


ItemImageData SpringPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData SpringPack { description = "Springboard"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = SpringPackImage; shadowDetailMask = 4; mass = 1.0; elasticity = 0.2; price = 500; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function SpringPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function SpringPack::onDeploy(%player,%item,%pos) { if (SpringPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function SpringPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableCactus",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",DeployableSpring,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Springboard"); Client::sendMessage(%client,0,"Springboard Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } 
else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData PlatformPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData PlatformPack { description = "Deployable Platform"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = PlatformPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function PlatformPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function PlatformPack::onDeploy(%player,%item,%pos) { if (PlatformPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function PlatformPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %rot = GameBase::getRotation(%player); %plat = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true); addToSet("MissionCleanup", %plat); GameBase::setTeam(%plat,GameBase::getTeam(%player)); GameBase::setPosition(%plat,$los::position); GameBase::setRotation(%plat,%rot); Gamebase::setMapName(%plat,"Deployable Platform"); Client::sendMessage(%client,0,"Platform Deployed"); GameBase::startFadeIn(%plat); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++; return true; } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData TeleportPackImage { shapeFile = "flagstand"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; 

ItemData TeleportPack { description = "Teleport Pad"; shapeFile = "flagstand"; className = "Backpack"; heading = "dDeployables"; imageType = TeleportPackImage; shadowDetailMask = 4; mass = 5.0; elasticity = 0.2; price = 3200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TeleportPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function TeleportPack::onDeploy(%player,%item,%pos) { if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++; } } function CreateteleportSimSet() { %teleset = nameToID("MissionCleanup/Teleports"); if(%teleset == -1) { newObject("Teleports",SimSet); addToSet("MissionCleanup","Teleports"); } } function TeleportPack::deployShape(%player,%name,%shape,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %sensor = newObject("Teleport Pad","StaticShape",%shape,true); CreateteleportSimSet(); addToSet("MissionCleanup/Teleports", %sensor); addToSet("MissionCleanup", %sensor); GameBase::setTeam(%sensor,GameBase::getTeam(%player)); %pos = Vector::add($los::position,"0 0 1"); if($ConOutput != 3) echo("LOS pos " @ $los::position @ " " @ %pos); GameBase::setPosition(%sensor,%pos); Gamebase::setMapName(%sensor,%name); Client::sendMessage(%client,0,%item.description @ " deployed"); %sensor.disabled = false; playSound(SoundPickupBackpack,$los::position); %beam = newObject("","StaticShape",ElectricalBeamBig,true); addToSet("MissionCleanup", %beam); 
GameBase::setTeam(%beam,GameBase::getTeam(%player)); GameBase::setPosition(%beam,%pos); %sensor.beam1 = %beam; return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); return false; } 

ItemImageData MechPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData MechPack { description = "Interceptor Pack"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; imageType = MechPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function MechPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function MechPack::onDeploy(%player,%item,%pos) { if (MechPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function MechPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"] < $TeamItemMax[JetVehicle]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { if(checkFlierArea(%client, $los::position)) { %rot = GameBase::getRotation(%player); %phase = newObject("",flier,Jet,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Client::sendMessage(%client,0,"Piloting Interceptor"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"]++; return true; } } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData ScoutPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData ScoutPack { description = "Scout Pack"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; imageType = ScoutPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function ScoutPack::onUse(%player, %item) { if (Player::getMountedItem(%player, $BackpackSlot) != %item) { Player::mountItem(%player, %item, $BackpackSlot); } else { Player::deployItem(%player, %item); } } function ScoutPack::onDeploy(%player, %item, %pos) { if (ScoutPack::deployShape(%player, %item)) { Player::decItemCount(%player, %item); } } function ScoutPack::deployShape(%player, %item) { %client = Player::getClient(%player); if ($TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"] < $TeamItemMax[ScoutVehicle]) { if (GameBase::getLOSInfo(%player, 3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { if (Vector::dot($los::normal, "0 0 1") > 0.7) { if (checkDeployArea(%client, $los::position)) { if(checkFlierArea(%client, $los::position)) { %rot = GameBase::getRotation(%player); %phase = newObject("", flier, Scout, true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase, GameBase::getTeam(%player)); GameBase::setPosition(%phase, $los::position); GameBase::setRotation(%phase, %rot); Client::sendMessage(%client, 0, "Piloting Scout Vehicle"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack, $los::position); $TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++; return true; } } } else Client::sendMessage(%client, 0, "Can only deploy on flat surfaces"); } else Client::sendMessage(%client, 0, "Can only deploy on terrain"); } else Client::sendMessage(%client, 0, "Deploy position out of range"); } else Client::sendMessage(%client, 0, "Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData WraithPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData WraithPack { description = "Wraith Pack"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; imageType = WraithPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function WraithPack::onUse(%player, %item) { if (Player::getMountedItem(%player, $BackpackSlot) != %item) { Player::mountItem(%player, %item, $BackpackSlot); } else { Player::deployItem(%player, %item); } } function WraithPack::onDeploy(%player, %item, %pos) { if (WraithPack::deployShape(%player, %item)) { Player::decItemCount(%player, %item); } } function WraithPack::deployShape(%player, %item) { %client = Player::getClient(%player); if ($TeamItemCount[GameBase::getTeam(%player) @ "WraithVehicle"] < $TeamItemMax[WraithVehicle]) { if (GameBase::getLOSInfo(%player, 3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { if (Vector::dot($los::normal, "0 0 1") > 0.7) { if (checkDeployArea(%client, $los::position)) { if(checkFlierArea(%client, $los::position)) { %rot = GameBase::getRotation(%player); %phase = newObject("", flier, Wraith, true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase, GameBase::getTeam(%player)); GameBase::setPosition(%phase, $los::position); GameBase::setRotation(%phase, %rot); Client::sendMessage(%client, 0, "Piloting Wraith Vehicle"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack, $los::position); $TeamItemCount[GameBase::getTeam(%player) @ "WraithVehicle"]++; return true; } } } else Client::sendMessage(%client, 0, "Can only deploy on flat surfaces"); } else Client::sendMessage(%client, 0, "Can only deploy on terrain"); } else Client::sendMessage(%client, 0, "Deploy position out of range"); } else Client::sendMessage(%client, 0, "Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData DoorfourbyeightForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData DoorfourbyeightForceFieldPack { description = "Large Force Field Door"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "gDoors"; imageType = DoorfourbyeightForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 1500; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DoorfourbyeightForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DoorfourbyeightForceFieldPack::onDeploy(%player,%item,%pos) { if (DoorfourbyeightForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DoorfourbyeightForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableDoorfourbyeightForceField",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",DoorfourbyeightForceField,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Force Field Door"); Client::sendMessage(%client,0,"Large Force Field Door Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "DoorfourbyeightForceFieldPack"]++; return true; } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } 
else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 

ItemImageData DoorfivebyfiveForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData DoorfivebyfiveForceFieldPack { description = "Force Field Door"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "gDoors"; imageType = DoorfivebyfiveForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 900; hudIcon = "deployable2"; showWeaponBar = true; hiliteOnActive = true; }; function DoorfivebyfiveForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DoorfivebyfiveForceFieldPack::onDeploy(%player,%item,%pos) { if (DoorfivebyfiveForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DoorfivebyfiveForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableDoorfivebyfiveForceField",%num); deleteObject(%set); if (Vector::dot($los::normal,"0 0 1") > 0.7) { %rot = GameBase::getRotation(%player); %phase = newObject("","StaticShape",DoorfivebyfiveForceField,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"Force Field Door"); Client::sendMessage(%client,0,"Force Field Door Deployed"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "DoorfivebyfiveForceFieldPack"]++; return true; } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } 
else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }  

ItemImageData DetPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData DetPack { description = "StealthHPC Pack"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; imageType = DetPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 1600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function DetPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } function DetPack::onDeploy(%player,%item,%pos) { if (DetPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } function DetPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] < $TeamItemMax[HAPCVehicle]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { if(checkFlierArea(%client, $los::position)) { %rot = GameBase::getRotation(%player); %phase = newObject("",flier,HAPC,true); addToSet("MissionCleanup", %phase); GameBase::setTeam(%phase,GameBase::getTeam(%player)); GameBase::setPosition(%phase,$los::position); GameBase::setRotation(%phase,%rot); Gamebase::setMapName(%phase,"HPC Pack"); Client::sendMessage(%client,0,"Deployed StealthHPC"); GameBase::startFadeIn(%phase); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++; return true; } } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } function Item::deployShape(%player,%name,%shape,%item) { %client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %sensor = newObject("","Sensor",%shape,true); addToSet("MissionCleanup", %sensor); GameBase::setTeam(%sensor,GameBase::getTeam(%player)); GameBase::setPosition(%sensor,$los::position); Gamebase::setMapName(%sensor,%name); Client::sendMessage(%client,0,%item.description @ " deployed"); playSound(SoundPickupBackpack,$los::position); if($ConOutput != 3) echo("MSG: ",%client," deployed a ",%name); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s"); return false; } $AutoUse[RepairKit] = false; 

ItemData RepairKit { description = "Repair Kit"; shapeFile = "armorKit"; heading = "eMiscellany"; shadowDetailMask = 4; price = 35; validateShape = true; validateMaterials = true; }; function RepairKit::onUse(%player,%item) { if(%player.station || %player.driver) return; Player::decItemCount(%player,%item); GameBase::repairDamage(%player,0.2); %c = Player::getClient(%player); $poisonTime[%c] = 0; } 

ItemData MineAmmo { description = "Mine"; shapeFile = "mineammo"; heading = "eMiscellany"; shadowDetailMask = 4; price = 10; className = "HandAmmo"; }; function MineAmmo::onUse(%player,%item) { if($matchStarted) { if(%player.throwTime < getSimTime() ) { %armor = Player::getArmor(%player); %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%client) @ "mineammo"] < $TeamItemMax["mineammo"]) $TeamItemCount[GameBase::getTeam(%client) @ "mineammo"]++; else { Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return; } Player::decItemCount(%player,%item); if (%armor == "dmarmor" || %armor == "dmfemale") %obj = newObject("","Mine","DMMine"); else { %obj = newObject("","Mine","antipersonelMine"); GameBase::setTeam (%obj,GameBase::getTeam (%client)); } addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; } } } 

ItemData Grenade { description = "Grenade"; shapeFile = "grenade"; heading = "eMiscellany"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; validateShape = true; }; function Grenade::onUse(%player,%item) { if($matchStarted) { if(!Player::getClient(%player).isSpy) { if(%player.throwTime < getSimTime() ) { %armor = Player::getArmor(%player); if (%armor == "larmor" || %armor == "lfemale") { %clTeam = GameBase::getTeam(Player::getClient(%player)); if($TeamItemCount[%clTeam @ "holomine"] < $TeamItemMax["holomine"]) { $TeamItemCount[%clTeam @ "holomine"]++; %obj = newObject("","Mine","HoloMine"); } else { Client::sendMessage(Player::getClient(%player),0,"Deployable Item limit reached for Hologram Mines"); return; } } if(%armor == "earmor" || %armor == "efemale") %obj = newObject("","Mine","Shockgrenade"); if (%armor == "sarmor" || %armor == "sfemale") %obj = newObject("","Mine","Firebomb"); if (%armor == "spyarmor" || %armor == "spyfemale") { Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 10 seconds"); %obj = newObject("","Mine","Nukebomb"); } if (%armor == "marmor" || %armor == "mfemale") %obj = newObject("","Mine","Handgrenade"); if (%armor == "aarmor" || %armor == "afemale") %obj = newObject("","Mine","Tranqgrenade"); if (%armor == "harmor") %obj = newObject("","Mine","Mortarbomb"); if (%armor == "barmor" || %armor == "bfemale") %obj = newObject("","Mine","Concussion"); if (%armor == "darmor") %obj = newObject("","Mine","Mortarbomb"); if (%armor == "dmarmor" || %armor == "dmfemale") %obj = newObject("","Mine","Handgrenade"); Player::decItemCount(%player,%item); addToSet("MissionCleanup", %obj); %client = Player::getClient(%player); GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; GameBase::setTeam (%obj,GameBase::getTeam (%client)); } } else Client::sendMessage(Player::getClient(%player),0,"Can't throw grenades while undercover~waccess_denied.wav"); } } 

function Armor::SpeedBooster(%player, %item, %power) { %vec = Item::getVelocity(%player); if (%vec == "0 0 0") %vec = "0 10 0"; %vec = Vector::Normalize(%vec); %vec = GetWord(%vec, 0) * %power @ " " @ GetWord(%vec, 1) * %power @ " " @ GetWord(%vec, 2) * %power; Player::applyImpulse(%player, %vec); Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster."); GameBase::playSound(%player, SoundMissileTurretFire, 0); Player::decItemCount(%player,%item); }


ItemData Beacon { description = "Beacon"; shapeFile = "sensor_small"; heading = "eMiscellany"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; validateShape = true; validateMaterials = true; }; function Beacon::onUse(%player,%item) { if(%player.station) return; if(Player::getClient(%player).isSpy) { Client::sendMessage(Player::getClient(%player), 0, "Can't deploy beacons while undercover~waccess_denied.wav"); return; } %armor = Player::getArmor(%player); %clientId = Player::getClient(%player); if (%armor == "barmor" || %armor == "bfemale") { %obj = newObject("", "Mine", "GoodBye");addToSet("MissionCleanup", %obj); GameBase::throw(%obj, %player, 1, false); %player.throwTime = getSimTime() + 0.5; GameBase::setTeam(%obj, GameBase::getTeam(%client)); Player::decItemCount(%player, %item); } if (%armor == "larmor" || %armor == "lfemale") { SniperJammer(%clientId, %player, %item); } if(%armor == "earmor" || %armor == "efemale") EngCamera(%clientId, %player, %item); if (%armor == "sarmor" || %armor == "sfemale") { ScoutSensor(%clientId, %player, %item); } if (%armor == "spyarmor" || %armor == "spyfemale") { DeploySatchel(%clientId, %player, %item); } if (%armor == "marmor" || %armor == "mfemale") { Armor::SpeedBooster(%player, %item, 270); } if (%armor == "aarmor" || %armor == "afemale" || %armor == "dmarmor"|| %armor == "dmfemale") { Renegades_startCloak(%clientId, %player); Player::decItemCount(%player,%item); } if (%armor == "harmor") { %obj = newObject("","Mine","ByeBye"); addToSet("MissionCleanup", %obj); GameBase::throw(%obj, %player, 10, false); %player.throwTime = getSimTime() + 0.5; GameBase::setTeam(%obj, GameBase::getTeam(%client)); Player::decItemCount(%player, %item); } if (%armor == "darmor"){ Renegades_startShield(%clientId, %player); Player::decItemCount(%player,%item); } } function Renegades_startStim(%clientId, %player) { if($StimTime[%clientId] > 0) return; Client::sendMessage(%clientId,0,"You activated a Haul-Ass beacon!"); %armor = Player::getArmor(%player); %armor.maxForwardSpeed = 23; 
GameBase::playSound(%player,ForceFieldOpen,0); if($stimTime[%clientId] == 0) { $stimTime[%clientId] = 10; checkPlayerStim(%clientId, %player); } else $StimTime[%clientId] = 10; } function checkPlayerStim(%clientId, %player) { if($StimTime[%clientId] > 0) { $StimTime[%clientId] -= 2; if (!Player::isDead(%player)) { } else { $StimTime[%clientId] = 0; %armor.maxForwardSpeed = 9; } schedule("checkPlayerStim(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,0,"Haul-Ass beacon depleted."); %armor = Player::getArmor(%player); %armor.maxForwardSpeed = 9; GameBase::playSound(%player,ForceFieldOpen,0); } } function Renegades_startShield(%clientId, %player) { Client::sendMessage(%clientId,0,"Emergency Force Shields Activated"); GameBase::playSound(%player,ForceFieldOpen,0); %player.shieldStrength = 0.006; if($shieldTime[%clientId] == 0) { $shieldTime[%clientId] = 20; checkPlayerShield(%clientId, %player); } else $shieldTime[%clientId] = 20; } function checkPlayerShield(%clientId, %player) { %armor = Player::getArmor(%player); if($shieldTime[%clientId] > 0) { $shieldTime[%clientId] -= 2; if ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale")) { if (Player::isDead(%player)) { } } else { $shieldTime[%clientId] = 0; } schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted"); %player.shieldStrength = 0; GameBase::playSound(%player,ForceFieldOpen,0); } } function Renegades_startCloak(%clientId, %player) { %armor = Player::getArmor(%player); Client::sendMessage(%clientId,0,"Cloaking On"); GameBase::playSound(%player,ForceFieldOpen,0); GameBase::startFadeout(%player); %rate = Player::getSensorSupression(%player) + 3; Player::setSensorSupression(%player,%rate); if($cloakTime[%clientId] == 0) { $cloakTime[%clientId] = 30; checkPlayerCloak(%clientId, %player); } else $cloakTime[%clientId] = 30; } function checkPlayerCloak(%clientId, %player) { 
%armor = Player::getArmor(%player); if($cloakTime[%clientId] > 0) { $cloakTime[%clientId] -= 2; if ( (!Player::isDead(%player)) && (%armor == "aarmor" || %armor == "afemale" || %armor == "dmarmor" || %armor == "dmfemale") ) { } else { $cloakTime[%clientId] = 0; } schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player); } else { Client::sendMessage(%clientId,0,"Cloaking Off"); GameBase::playSound(%player,ForceFieldOpen,0); GameBase::startFadein(%player); %rate = Player::getSensorSupression(%player) - 5; Player::setSensorSupression(%player,0); } } function DeploySatchel( %clientId, %player, %bec) { %item = "SatchelPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",DeployableSatchel,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen."); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Satchel Charge."); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for Satchel Charges"); return false; } 
function EngCamera(%clientId, %player, %bec) { %item = "CameraPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",CameraTurret,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client)); Client::sendMessage(%client,0,"Camera deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Camera"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } function SniperJammer(%clientId, %player, %bec) { %item = "DeployableSensorJammerPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
{ %rot = "3.14159 0 " @ %zRot; } 
else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("sensor_jammer","Sensor",DeployableSensorJammer,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"SensorJammer"); Client::sendMessage(%client,0,"SensorJammer deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "DeployableSensorJammerPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Sensor Jammer"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } function ScoutSensor(%clientId, %player, %bec) { %item = "PulseSensorPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("radar_small","Sensor",DeployablePulseSensor,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Pulse Sensor"); Client::sendMessage(%client,0,"Pulse Sensor deployed"); playSound(SoundPickupBackpack,$los::position); 
 $TeamItemCount[GameBase::getTeam(%camera) @ "PulseSensorPack"]++; if($ConOutput != 3) echo("MSG: ",%client," deployed a Pulse Sensor"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; } 


 function Boost::onUse(%player,%item) 
 { 
	%client = Player::getClient(%player);
	Training::setupAI(%client);
 }
 
ItemData RepairPatch 
{ 
	description = "Repair Patch"; 
	className = "Repair";
	shapeFile = "armorPatch"; 
	heading = "eMiscellany"; 
	shadowDetailMask = 4; 
	price = 2; 
	validateShape = true; 
	validateMaterials = true; 
}; 

function RepairPatch::onCollision(%this,%object) 
{ 
	if (getObjectType(%object) == "Player") 
	{ 
		if(GameBase::getDamageLevel(%object)) 
		{ 
			GameBase::repairDamage(%object,0.125); 
			%c = Player::getClient(%object); 
			$poisonTime[%c] = 0; 
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

function remoteGiveAll(%clientId) 
{ 
	if ($TestCheats) 
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
		Player::setItemCount(%clientId,BulletAmmo,200); 
		Player::setItemCount(%clientId,PlasmaAmmo,200); 
		Player::setItemCount(%clientId,GrenadeAmmo,200); 
		Player::setItemCount(%clientId,DiscAmmo,200); 
		Player::setItemCount(%clientId,MortarAmmo,200); 
		Player::setItemCount(%clientId,Grenade, 200); 
		Player::setItemCount(%clientId,MineAmmo, 200); 
		Player::setItemCount(%clientId,Beacon, 200); 
		Player::setItemCount(%clientId,RepairKit,200); 
	} 
	else if($ServerCheats) 
	{ 
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
			if(%count > %maxnum) { %numsell = %count - %maxnum; } 
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
			else %diff = $InitialPlayerEnergy + %client.teamEnergy; 
			$TeamEnergy[%team] -= %diff; 
		} 
	} 
} 

function Mission::reinitData() 
{

$TeamItemCount[0 @ CommandShipPack] = 0;
	$TeamItemCount[1 @ CommandShipPack] = 0;
	$TeamItemCount[2 @ CommandShipPack] = 0;
	$TeamItemCount[3 @ CommandShipPack] = 0;
	$TeamItemCount[4 @ CommandShipPack] = 0;
	$TeamItemCount[5 @ CommandShipPack] = 0;
	$TeamItemCount[6 @ CommandShipPack] = 0;
	$TeamItemCount[7 @ CommandShipPack] = 0;

	$TeamItemCount[0 @ BaseCloakPack] = 0; 
	$TeamItemCount[1 @ BaseCloakPack] = 0; 
	$TeamItemCount[2 @ BaseCloakPack] = 0;
	$TeamItemCount[3 @ BaseCloakPack] = 0;
	$TeamItemCount[4 @ BaseCloakPack] = 0;
	$TeamItemCount[5 @ BaseCloakPack] = 0;
	$TeamItemCount[6 @ BaseCloakPack] = 0;
	$TeamItemCount[7 @ BaseCloakPack] = 0;

	$TeamItemCount[0 @ RegenGenPack] = 0; 
	$TeamItemCount[1 @ RegenGenPack] = 0; 
	$TeamItemCount[2 @ RegenGenPack] = 0;
	$TeamItemCount[3 @ RegenGenPack] = 0;
	$TeamItemCount[4 @ RegenGenPack] = 0;
	$TeamItemCount[5 @ RegenGenPack] = 0;
	$TeamItemCount[6 @ RegenGenPack] = 0;
	$TeamItemCount[7 @ RegenGenPack] = 0;

	$TeamItemCount[0 @ Hider] = 0; 
	$TeamItemCount[1 @ Hider] = 0; 
	$TeamItemCount[2 @ Hider] = 0;
	$TeamItemCount[3 @ Hider] = 0;
	$TeamItemCount[4 @ Hider] = 0;
	$TeamItemCount[5 @ Hider] = 0;
	$TeamItemCount[6 @ Hider] = 0;
	$TeamItemCount[7 @ Hider] = 0;

	$TeamItemCount[0 @ FloorDoorPack] = 0; 
	$TeamItemCount[1 @ FloorDoorPack] = 0; 
	$TeamItemCount[2 @ FloorDoorPack] = 0;
	$TeamItemCount[3 @ FloorDoorPack] = 0;
	$TeamItemCount[4 @ FloorDoorPack] = 0;
	$TeamItemCount[5 @ FloorDoorPack] = 0;
	$TeamItemCount[6 @ FloorDoorPack] = 0;
	$TeamItemCount[7 @ FloorDoorPack] = 0;

	$TeamItemCount[0 @ CloakDisrupterPack] = 0; 
	$TeamItemCount[1 @ CloakDisrupterPack] = 0; 
	$TeamItemCount[2 @ CloakDisrupterPack] = 0;
	$TeamItemCount[3 @ CloakDisrupterPack] = 0;
	$TeamItemCount[4 @ CloakDisrupterPack] = 0;
	$TeamItemCount[5 @ CloakDisrupterPack] = 0;
	$TeamItemCount[6 @ CloakDisrupterPack] = 0;
	$TeamItemCount[7 @ CloakDisrupterPack] = 0;

$TeamItemCount[0 @ HAPCAssaultVehicle] = 0; 
$TeamItemCount[1 @ HAPCAssaultVehicle] = 0; 
$TeamItemCount[2 @ HAPCAssaultVehicle] = 0; 
$TeamItemCount[3 @ HAPCAssaultVehicle] = 0; 
$TeamItemCount[4 @ HAPCAssaultVehicle] = 0; 
$TeamItemCount[5 @ HAPCAssaultVehicle] = 0;

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
 $TeamItemCount[0 @ ScoutPack] = 0;
 $TeamItemCount[1 @ ScoutPack] = 0;
 $TeamItemCount[2 @ ScoutPack] = 0;
 $TeamItemCount[3 @ ScoutPack] = 0;
 $TeamItemCount[4 @ ScoutPack] = 0;
 $TeamItemCount[5 @ ScoutPack] = 0;
 $TeamItemCount[6 @ ScoutPack] = 0;
 $TeamItemCount[7 @ ScoutPack] = 0;
 $TeamItemCount[0 @ WraithPack] = 0;
 $TeamItemCount[1 @ WraithPack] = 0;
 $TeamItemCount[2 @ WraithPack] = 0;
 $TeamItemCount[3 @ WraithPack] = 0;
 $TeamItemCount[4 @ WraithPack] = 0;
 $TeamItemCount[5 @ WraithPack] = 0;
 $TeamItemCount[6 @ WraithPack] = 0;
 $TeamItemCount[7 @ WraithPack] = 0;
 $TeamItemCount[0 @ Holomine] = 0;
 $TeamItemCount[1 @ Holomine] = 0;
 $TeamItemCount[2 @ Holomine] = 0;
 $TeamItemCount[3 @ Holomine] = 0;
 $TeamItemCount[4 @ Holomine] = 0;
 $TeamItemCount[5 @ Holomine] = 0;
 $TeamItemCount[6 @ Holomine] = 0;
 $TeamItemCount[7 @ Holomine] = 0;
 $TeamItemCount[0 @ DeathStarPack] = 0;
 $TeamItemCount[1 @ DeathStarPack] = 0;
 $TeamItemCount[2 @ DeathStarPack] = 0;
 $TeamItemCount[3 @ DeathStarPack] = 0;
 $TeamItemCount[4 @ DeathStarPack] = 0;
 $TeamItemCount[5 @ DeathStarPack] = 0;
 $TeamItemCount[6 @ DeathStarPack] = 0;
 $TeamItemCount[7 @ DeathStarPack] = 0;
 $TeamItemCount[0 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[1 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[2 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[3 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[4 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[5 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[6 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[7 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[0 @ TrackingTurretPack] = 0;
 $TeamItemCount[1 @ TrackingTurretPack] = 0;
 $TeamItemCount[3 @ TrackingTurretPack] = 0;
 $TeamItemCount[4 @ TrackingTurretPack] = 0;
 $TeamItemCount[5 @ TrackingTurretPack] = 0;
 $TeamItemCount[6 @ TrackingTurretPack] = 0;
 $TeamItemCount[7 @ TrackingTurretPack] = 0;
 $TeamItemCount[0 @ BarragePack] = 0;
 $TeamItemCount[1 @ BarragePack] = 0;
 $TeamItemCount[3 @ BarragePack] = 0;
 $TeamItemCount[4 @ BarragePack] = 0;
 $TeamItemCount[5 @ BarragePack] = 0;
 $TeamItemCount[6 @ BarragePack] = 0;
 $TeamItemCount[7 @ BarragePack] = 0;
 $TeamItemCount[0 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[1 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[2 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[3 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[4 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[5 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[6 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[7 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[0 @ DefenseAlarm] = 0;
 $TeamItemCount[1 @ DefenseAlarm] = 0;
 $TeamItemCount[2 @ DefenseAlarm] = 0;
 $TeamItemCount[3 @ DefenseAlarm] = 0;
 $TeamItemCount[4 @ DefenseAlarm] = 0;
 $TeamItemCount[5 @ DefenseAlarm] = 0;
 $TeamItemCount[6 @ DefenseAlarm] = 0;
 $TeamItemCount[7 @ DefenseAlarm] = 0;
 $TeamItemCount[0 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[1 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[2 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[3 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[4 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[5 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[6 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[7 @ DoorfivebyfiveForceFieldPack] = 0;
 $TeamItemCount[0 @ TrackingTurretPack] = 0;
 $TeamItemCount[1 @ TrackingTurretPack] = 0;
 $TeamItemCount[3 @ TrackingTurretPack] = 0;
 $TeamItemCount[4 @ TrackingTurretPack] = 0;
 $TeamItemCount[5 @ TrackingTurretPack] = 0;
 $TeamItemCount[6 @ TrackingTurretPack] = 0;
 $TeamItemCount[7 @ TrackingTurretPack] = 0;
 $TeamItemCount[0 @ BarragePack] = 0;
 $TeamItemCount[1 @ BarragePack] = 0;
 $TeamItemCount[3 @ BarragePack] = 0;
 $TeamItemCount[4 @ BarragePack] = 0;
 $TeamItemCount[5 @ BarragePack] = 0;
 $TeamItemCount[6 @ BarragePack] = 0;
 $TeamItemCount[7 @ BarragePack] = 0;
 $TeamItemCount[0 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[1 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[2 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[3 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[4 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[5 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[6 @ DoorfourbyeightForceFieldPack] = 0;
 $TeamItemCount[7 @ DoorfourbyeightForceFieldPack] = 0;
 $totalNumCameras = 0;
 $totalNumAlarms[0] = 0;
 $totalNumTurrets = 0;
 for(%i = -1; %i < 8 ; %i++)
 { 
	$TeamEnergy[%i] = $DefaultTeamEnergy;
 }
}
