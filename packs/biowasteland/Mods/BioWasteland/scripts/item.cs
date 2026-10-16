//=====================================================================
//=======================BioWasteland Items File
//=======================Mod by Bïohazard
//=======================www.exploratoriums.com
//=======================biohazard@exploratoriums.com
//=====================================================================
//== hyperblaster is scheduled to be deleated
$ItemFavoritesKey = "biov7";
$ItemPopTime = 30;
$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$ArmorType[Male, LightArmor] = larmor;		$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Male, MediumArmor] = marmor;		$ArmorType[Female, MediumArmor] = mfemale;
$ArmorType[Male, HeavyArmor] = harmor;		$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Male, ScoutArmor] = sarmor;		$ArmorType[Female, ScoutArmor] = sfemale;
$ArmorType[Male, BursterArmor] = barmor;	$ArmorType[Female, BursterArmor] = bfemale;
$ArmorType[Male, EngArmor] = earmor;		$ArmorType[Female, EngArmor] = efemale;
$ArmorType[Male, SpArmor] = spyarmor;		$ArmorType[Female, SpArmor] = spyfemale;
$ArmorType[Male, AlArmor] = aarmor;		$ArmorType[Female, AlArmor] = afemale;
$ArmorType[Male, Juggernaught] = jarmor;	$ArmorType[Female, Juggernaught] = jarmor;
$ArmorType[Male, RunnerArmor] = rarmor;	$ArmorType[Female, RunnerArmor] = rarmor;

$ArmorName[sarmor] = ScoutArmor;
$ArmorName[sfemale] = ScoutArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[barmor] = BursterArmor;
$ArmorName[bfemale] = BursterArmor;
$ArmorName[spyarmor] = SpArmor;
$ArmorName[spyfemale] = SpArmor;
$ArmorName[earmor] = EngArmor;
$ArmorName[efemale] = EngArmor;
$ArmorName[aarmor] = AlArmor;
$ArmorName[afemale] = AlArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[jarmor] = Juggernaught;
$ArmorName[rarmor] = RunnerArmor;

// Amount to remove when selling or dropping ammo

$SellAmmo[AutoRocketAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[BoomAmmo] = 5;
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[DetBug] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MfglAmmo] = 1;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[RocketAmmo] = 3;
$SellAmmo[SilencerAmmo] = 25;
$SellAmmo[RifleAmmo] = 5;

// Max Amount of ammo the Ammo Pack can carry

$AmmoPackMax[Beacon] = 5;
$AmmoPackMax[BoomAmmo] = 15;
$AmmoPackMax[BulletAmmo] = 300;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[Grenade] = 8;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MfglAmmo] = 0;
$AmmoPackMax[MineAmmo] = 8;
$AmmoPackMax[MortarAmmo] = 15;
$AmmoPackMax[PlasmaAmmo] = 20;
$AmmoPackMax[RocketAmmo] = 15;
$AmmoPackMax[RifleAmmo] = 20;

// Items in the AmmoPack

$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MortarAmmo;
$AmmoPackItems[6] = Beacon;
$AmmoPackItems[7] = BoomAmmo;
$AmmoPackItems[8] = RocketAmmo;
$AmmoPackItems[9] = RifleAmmo;
$AmmoPackItems[10] = SilencerAmmo;
$AmmoPackItems[11] = MineAmmo;

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

$Use[Blaster] = True;
$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = False;
$AutoUse[PlasmaGun] = False;
$AutoUse[Mortar] = False;
$AutoUse[GrenadeLauncher] = False;
$AutoUse[LaserRifle] = False;
$AutoUse[EnergyRifle] = False;
$AutoUse[TargetingLaser] = False;
$AutoUse[Fixit] = False;
$AutoUse[ChargeGun] = False;
$AutoUse[CloakGun] = False;
$AutoUse[RocketLauncher] = False;
$AutoUse[BoomStick] = False;
$AutoUse[SniperRifle2] = False;
$AutoUse[ConCun] = False;
$AutoUse[Railgun] = False;
$AutoUse[Mfgl] = False;
$AutoUse[Vulcan] = False;
$AutoUse[Silencer] = False;
$AutoUse[SMML] = False;
$AutoUse[TranqGun] = False;
$AutoUse[HyperB] = False;
$AutoUse[Volter] = False;
$AutoUse[MiniPlasmaCannon] = False;
//====================================== Limit on number of special Items you can buy
//==================================================== Dynamic Limits
if ($Wasteland::DetPackLimit == "")
{
	$Wasteland::DetPackLimit = "120";//default time to manufacture a nuke
}
if ($Wasteland::NukeLimit == "")
{
	$Wasteland::NukeLimit = "-1";//==a negative number
}


//========================== Item Limits.
$TeamItemMax[AccelPPack] = 3;
$TeamItemMax[AirAmmoPad] = 3;
$TeamItemMax[AirFuserPad] = $TeamItemMax[AirAmmoPad];
$TeamItemMax[airbase] = 1;
$TeamItemMax[AntennaPack] = 1;
$TeamItemMax[AGravPack] = 2;
$TeamItemMax[ArbitorBeaconPack] = 5;
$TeamItemMax[BarragePack] = 1;
$TeamItemMax[BasePack] = 1;
$TeamItemMax[BlastDoorPack] = 2;
$TeamItemMax[BlastFloorPack] = 3;
$TeamItemMax[BlastWallPack] = 3;
$TeamItemMax[CameraPack] = 2;
$TeamItemMax[ChaingunTurretPack] = 6;
$TeamItemMax[ConPack] = 2;
$TeamItemMax[DeployableAmmoPack] = 5;
$TeamItemMax[DeployableComPack] = 5;
$TeamItemMax[DeployableElf] = 5;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[DeployableSensorJammerPack] = 5;
$TeamItemMax[DetBug] = 30;
$TeamItemMax[EMPBeaconPack] = 2;
$TeamItemMax[ElectricWeb] = 3;
$TeamItemMax[ElectricFloor] = 3;
$TeamItemMax[Elevator] = 1;
$TeamItemMax[EnergyRifle] = 1;
$TeamItemMax[EmergencyInvPack] = 1;
$TeamItemMax[BunkerPack] = 1;
$TeamItemMax[EngBeacons] = 10;
$TeamItemMax[FighterVehicle] = 4;
$TeamItemMax[FlakPack] = 4;
$TeamItemMax[FlameTurretPack] = 4;
$TeamItemMax[ForceFieldPack] = 5;
$TeamItemMax[GAPCVehicle] = 1;
$TeamItemMax[GunTuretPack] = 1;
$TeamItemMax[HAPCVehicle] = 2;
$TeamItemMax[HGravTurretPack] = 2;
$TeamItemMax[HolePack] = 1;
$TeamItemMax[HoloPack] = 5;
$TeamItemMax[InveiglerPack] = 1;
$TeamItemMax[JailCapPack] = 5;
$TeamItemMax[jailpack] = 1;
$TeamItemMax[JammerBeaconPack] = 2;
$TeamItemMax[LAPCVehicle] = 3;
$TeamItemMax[LargeForceFieldPack] = 3;
$TeamItemMax[LargeShockForceFieldPack] = 2;
$TeamItemMax[LaserPack] = 3;
$TeamItemMax[LaunchPack] = 2;
$TeamItemMax[LockOutPack] = 1;
$TeamItemMax[Mfgl] = 1;
$TeamItemMax[MFGLAmmo] = 0; //==Must be manufactured by NukGen
$TeamItemMax[LaserMine] = 10;
$TeamItemMax[MagBridgePack] = 1;
$TeamItemMax[MalicePack] = 2;
$TeamItemMax[mineammo] = 40;
$TeamItemMax[MotionSensorPack] = 5;
$TeamItemMax[MechPack] = 1;
$TeamItemMax[NukGen] = 1;
$TeamItemMax[Pigment] = 50;
$TeamItemMax[PlantPack] = 3;
$TeamItemMax[PlasmaTurretPack] = 4;
$TeamItemMax[PowerGeneratorPack] = 1;
$TeamItemMax[PrismPack] = 1;
$TeamItemMax[ProwlerVehicle] = 2;
$TeamItemMax[ProxMine] = 4;
$TeamItemMax[PulseSensorPack] = 5;
$TeamItemMax[RailTurretPack] = 1;
$TeamItemMax[ReconPack] = 1;
$TeamItemMax[RocketPack] = 4;
$TeamItemMax[SatchelPack] = 5;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[SeedPack] = 6;
$TeamItemMax[Sentry] = 2;
$TeamItemMax[ShieldBeaconPack] = 2;
$TeamItemMax[ShockFloorPack] = 4;
$TeamItemMax[ShockPack] = 4;
$TeamItemMax[SkyEyePack] = 1;
$TeamItemMax[SmartPack] = 1;
$TeamItemMax[SortieGun] = 1;
$TeamItemMax[SwitchPack] = 1;
$TeamItemMax[TargetPack] = 2;
$TeamItemMax[TeleportPack] = 2;
$TeamItemMax[TeleBeacons] = 5;
$TeamItemMax[TrapPack1] = 10;
$TeamItemMax[TrapPack2] = 10;
$TeamItemMax[TrapPack3] = 3;
$TeamItemMax[TrapPack4] = 3;
$TeamItemMax[TrapPack5] = 2;
$TeamItemMax[TrapPack6] = 10;
$TeamItemMax[TreePack] = 5;
$TeamItemMax[TurretPack] = 6;
$TeamItemMax[VulcanTurretPack] = 3;
$TeamItemMax[WarpPack] = 1;
$TeamItemMax[ZepplinPack] = 1;


//======================== Missile Limits

if ($Wasteland::Missile_EMP){$TeamItemMax[EmpM] 		= $Wasteland::Missile_EMP;}else{$TeamItemMax[EmpM] = 10; }
if ($Wasteland::Missile_GAS){$TeamItemMax[GasM] 		= $Wasteland::Missile_GAS;}else{$TeamItemMax[GasM] = 10; }
if ($Wasteland::Missile_PHE){$TeamItemMax[PhoenixM] 	= $Wasteland::Missile_PHE;}else{$TeamItemMax[PhoenixM] = 10; }
if ($Wasteland::Missile_NAP){$TeamItemMax[NapM] 		= $Wasteland::Missile_NAP;}else{$TeamItemMax[NapM] = 10; }
if ($Wasteland::Missile_BOM){$TeamItemMax[BooM] 		= $Wasteland::Missile_BOM;}else{$TeamItemMax[BooM] = 10; }
if ($Wasteland::Missile_SPY){$TeamItemMax[SpyPod] 	= $Wasteland::Missile_SPY;}else{$TeamItemMax[SpyPod] = 10; }
if ($Wasteland::Missile_BALL){$TeamItemMax[BallM] 	= $Wasteland::Missile_BALL;}else{$TeamItemMax[BallM] = 10; }

//=============================== Weapons And Ammo
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[BoomStick] = BoomAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[ConCun] = "";
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[Fists] = "";
$WeaponAmmo[Flamer] = "";
$WeaponAmmo[GravGun] = "";
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mfgl] = MfglAmmo;
$WeaponAmmo[Mortar] = MortarAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[RailGun] = RifleAmmo;
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[SprayCan] = PaintAmmo;
$WeaponAmmo[SMML] = "";
$WeaponAmmo[Silencer] = SilencerAmmo;
$WeaponAmmo[SniperRifle2] = RifleAmmo;
$WeaponAmmo[TranqGun] = RifleAmmo;
$WeaponAmmo[Volter] = "";
$WeaponAmmo[Vulcan] = BulletAmmo;

//----------------------------------------------------------------------------
// Server side methods
// The client side inventory dialogs call buyItem, sellItem,
// useItem and dropItem through remoteEvals.

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
	else if($TeamEnergy[%team] != "Infinite") {
		$TeamEnergy[%team] += %cost;
 		%client.teamEnergy += %cost;
	}
}

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
	$SpawnFavs = "True";
	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead)
	{
		return;
	}

	for (%i = 0; %i <= 19; %i++)
	{
		%client.fav[%i] = "";
		$spawnBuyList[%i, %client] = "";
	}

	if ($SpawnFavs && %client.spawntype == "favs" || %client.spawntype == "saved")
	{
		%client.favsettings = "True";
		%client.spawntype = "favs";

		if (%favItem0)  {%client.fav0 = %favItem0;	  $spawnBuyList[0, %client] = getItemData(%favItem0); }
		if (%favItem1)  {%client.fav1 = %favItem1;	  $spawnBuyList[1, %client] = getItemData(%favItem1); }
	   	if (%favItem2)  {%client.fav2 = %favItem2;	  $spawnBuyList[2, %client] = getItemData(%favItem2); }
	   	if (%favItem3)  {%client.fav3 = %favItem3;	  $spawnBuyList[3, %client] = getItemData(%favItem3); }
	   	if (%favItem4)  {%client.fav4 = %favItem4;	  $spawnBuyList[4, %client] = getItemData(%favItem4); }
	   	if (%favItem5)  {%client.fav5 = %favItem5;	  $spawnBuyList[5, %client] = getItemData(%favItem5); }
	   	if (%favItem6)  {%client.fav6 = %favItem6;	  $spawnBuyList[6, %client] = getItemData(%favItem6); }
	   	if (%favItem7)  {%client.fav7 = %favItem7;	  $spawnBuyList[7, %client] = getItemData(%favItem7); }
	   	if (%favItem8)  {%client.fav8 = %favItem8;	  $spawnBuyList[8, %client] = getItemData(%favItem8); }
	   	if (%favItem9)  {%client.fav9 = %favItem9;	  $spawnBuyList[9, %client] = getItemData(%favItem9); }
	   	if (%favItem10) {%client.fav10 = %favItem10;	  $spawnBuyList[10, %client] = getItemData(%favItem10);}
	   	if (%favItem11) {%client.fav11 = %favItem11;	  $spawnBuyList[11, %client] = getItemData(%favItem11);}
	   	if (%favItem12) {%client.fav12 = %favItem12;	  $spawnBuyList[12, %client] = getItemData(%favItem12);}
	   	if (%favItem13) {%client.fav13 = %favItem13;	  $spawnBuyList[13, %client] = getItemData(%favItem13);}
	   	if (%favItem14) {%client.fav14 = %favItem14;	  $spawnBuyList[14, %client] = getItemData(%favItem14);}
	   	if (%favItem15) {%client.fav15 = %favItem15;	  $spawnBuyList[15, %client] = getItemData(%favItem15);}
	   	if (%favItem16) {%client.fav16 = %favItem16;	  $spawnBuyList[16, %client] = getItemData(%favItem16);}
	   	if (%favItem17) {%client.fav17 = %favItem17;	  $spawnBuyList[17, %client] = getItemData(%favItem17);}
	   	if (%favItem18) {%client.fav18 = %favItem18;	  $spawnBuyList[18, %client] = getItemData(%favItem18);}
	   	if (%favItem19) {%client.fav19 = %favItem19;	  $spawnBuyList[19, %client] = getItemData(%favItem19);}
   	}

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

			for (%i = 1; %i < %max; %i++)
			{
				%item = getItemData(%i);
				if (Client::isItemShoppingOn(%client,%item))
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

			for (%i = 0; %i < 20; %i++)
			{
				if(%favItem[%i] != "")
				{
					%item = getItemData(%favItem[%i]);

					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || %item.className == Armor))
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
					systemMessage(%client,0,"~wC_BuySell.wav");
				else
					systemMessage(%client,0,"~wbuysellsound.wav");
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

//====================================Check Max Drop from Bitchin1.3
function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");

	if (%numweapon > $MaxWeapons[%armor])
	{
		%weaponflag = %numweapon - $MaxWeapons[%armor];
	}

	%max = getNumItems();
	for (%i = 1; %i < %max; %i = %i + 1)
	{
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];

		if(%maxnum != "" && %item.className != Armor)
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

//========================================== Armor Change Drop from Bitchin1.3
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
					systemMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
				return 0;
			}
		}
	}
	if(%item.className == Weapon)
	{
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"Weapon");

		%count = Player::getItemClassCount(%client,"Weapon");
		if (%count >= $MaxWeapons[%armor])
		{
			Client::sendMessage(%client,0,"Too many weapons for " @ $ArmorName[%armor].description @ " to carry");
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
			systemMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
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
	return %delta;
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%client.oldpack = Player::getMountedItem(%client,$BackpackSlot);//==for zepplin
	%armor = Player::getArmor(%client);
	%team = GameBase::GetTeam(%client);

	if (%client.curse == true)
		return;

	if ((Client::isItemShoppingOn(%client,%item) || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle))
	{
		if (($TeamItemCount[%team @ %item] > $TeamItemMax[%item] || $TeamItemCount[%team @ %item] == $TeamItemMax[%item]) && $TeamItemCount[%team @ %item] != "")
		{
		        Client::sendMessage(%client,1,"Could not purchace " @ %item.description @ ", Limit Of " @ $TeamItemMax[%item] @ ".");
			bottomprint(%client, "<jc><f2>Could not purchace " @ %item.description @ ", Limit Of " @ $TeamItemMax[%item] @ ".", 5);
			return;
		}

		//=============== Assign armor by requested type & gender

		if (%item.className == Armor)
		{
			%buyarmor = $ArmorType[Client::getGender(%client), %item];

			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)
			{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);

				if(checkResources(%player,%item,1))
				{
					Player::setItemCount(%client, PlasmaCannon,0);
					Player::setItemCount(%client, LasCannon,0);
					Player::setItemCount(%client, Hammer2Pack,0);
					Player::setItemCount(%client, Hammer1Pack,0);
					Player::setItemCount(%client, Fists,0);

					%client.heatlock = "0";
					%client.plasmacharge = "0";
					%client.charging = "0";
					%client.lascharge = "0";

					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);

     					Player::setItemCount(%client, $ArmorName[%armor], 0);
     					Player::setItemCount(%client, %item, 1);
					if (%buyarmor == "rarmor") 
					{
						checkMax(%client,%armor);
						//================= Set Weapons
						Player::setItemCount(%client, Fists, 1);
					}
					if (%buyarmor == "marmor" || %buyarmor == "mfemale")
					{
						Player::setItemCount	(%client, Booster1Pack,1);
						Player::setItemCount	(%client, Booster2Pack,1);
						schedule ("Player::mountItem( " @ %client @ ", Booster1Pack,4);",0.3);
						schedule ("Player::mountItem( " @ %client @ ", Booster2Pack,5);",0.3);
					}
					else if (%buyarmor != "marmor" || %buyarmor != "mfemale")
					{
						Player::unMountItem(%client,4);
						Player::unMountItem(%client,5);
					}


//============== Check Juggernaught
					if (%buyarmor == "jarmor") 
					{
						checkMax(%client,%armor);
						Player::setItemCount(%client, Juggernaught, 1);
						//================= Set Weapons
						Player::setItemCount(%client, RocketLauncher, 1);
						Player::setItemCount(%client, Mortar,1);
						Player::setItemCount(%client, RocketAmmo,25);
						Player::setItemCount(%client, MortarAmmo,20);
						Player::setItemCount(%client, Hammer1Pack,1);
						Player::setItemCount(%client, Hammer2Pack,1);
						Player::setItemCount(%client, Grenade,1);
						Player::setItemCount(%client, MineAmmo,1);

						//============ Mount Items
						Player::mountItem(%client, Hammer1Pack, 4);
						Player::mountItem(%client, Hammer2Pack, 5);
						Player::mountItem(%client, PlasmaCannon, 0);
						schedule("bottomprint(" @ %client @ ", \"<jc><f1>Cannon: Plasma <f2>press M for Laser\", 3);", 1);
						schedule("bottomprint(" @ %client @ ", \"<jc><f2>Press G for GodHammer\", 3);", 4);
					}
					else
					{
						Player::unMountItem(%client,4);
						Player::unMountItem(%client,5);
					}

					if (Player::getMountedItem(%client,$BackpackSlot) == ammopack)
						fillAmmoPack(%client);

					if ($Wasteland::ItemLimit && %client.invo)
					{
						setupShoppingList(%client,%client.invo,%client.ListType);
					}
					return 1;
				}
				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		//================================= Finish Buy
		else if (%item.className == VModule)
		{
			teamEnergyBuySell(%player,%item.price);
			Player::setItemCount(%client,HellFireModule, 0);
			Player::setItemCount(%client,DetPackModule, 0);
			Player::setItemCount(%client,RamModule, 0);
			Player::setItemCount(%client,WraithModule, 0);

			teamEnergyBuySell(%player,%item.price * -1);
			Player::incItemCount(%client,%item);
			return 1;
		}
		else if (%item.className == Backpack)
		{
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1)
			{
				if(%pack == ammopack)
				{
					checkMax(%client,%armor);
				}

				else if(%item == FgcPack)
				{
					if(Player::getItemCount(%client,"Mfgl") > 0)
					{
						systemMessage(%client,0,"Sold Containment - Auto Selling Tactical Nuke");
						Player::setItemCount(%player,"MfglAmmo",0);
						Player::setItemCount(%player,"Mfgl",0);
					}
				}
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}

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
				//====================== AutoBuy Energy Pack for Laser
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					systemMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}

				//====================== AutoBuy Containment Pack
				if(%item == Mfgl && Player::getItemCount(%client,"FgcPack") == 0)
				{
					buyItem(%client,"FgcPack");
					systemMessage(%client,0,"Bought Tactical Nuke - Auto buying Nuclear Containment Pack");
				}

				if (%armor == jarmor)
				{
					if(%item == "PlasmaCannon")
					{
						Player::setItemCount(%client, LasCannon,0);
					}
					if(%item == "LasCannon")
					{
						Player::setItemCount(%client, PlasmaCannon,0);
					}
				}

				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));

				%ammoItem = %item.imageType.ammoType;

				if ($TeamItemMax[%ammoItem] && $TeamItemMax[%ammoItem] != 0)
				{
					if ($TeamItemCount[GameBase::getTeam(%client) @ %ammoItem] < $TeamItemMax[%ammoItem])
					{
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
					else
					{
						systemMessage(%client,1,"Could Not Purchace Ammo. Limit Exceeded");
					}
				}
				else
				{
					if(%ammoItem != "" && %ammoItem != "MfglAmmo")
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
		}
	 	else if(%item.className == Vehicle)
	 	{
			%shouldBuy = VehicleStation::checkBuying(%client,%item);
			if(%shouldBuy == 1) {
				teamEnergyBuySell(%player,(%item.price * -1));
				return 1;
			}
 			else if(%shouldBuy == 2)
				return 1;
		}
		else
		{
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

function remoteBuyItem(%client,%type)
{
	%player = client::getownedobject(%client);
	%armor = Player::getArmor(%client);
	%team = GameBase::GetTeam(%client);

	if (%client.curse == true)
		return;

	if (!%player.Station){bottomprint(%client, " You must be at an Inventory station to buy items.");return;}

	%item = getItemData(%type);
	%armor = Player::getArmor(%client);
	if(buyItem(%client,%item))
	{
 		systemMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else
  		Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

function remoteSellItem(%client,%type)
{
	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);

	if (%client.curse == true)
		return;
	if (%item.className == "flag")
		return;

	if (Client::isItemShoppingOn(%client,%item))
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
			{
				checkMax(%client,%armor);
			}
			else if($TeamItemMax[%item] != "")
			{
				if(%item.className == Vehicle)
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}

			else if(%item == FgcPack)
			{
				if(Player::getItemCount(%client,"Mfgl") > 0)
				{
					systemMessage(%client,1,"Sold Nuclear Containment - Auto Selling Tactical Nuke");
					Player::setItemCount(%client, MFGLAmmo,0);
					Player::setItemCount(%client, MFGL,0);
				}
			}

			if (%armor == "jarmor")
			{
				if(%item == "Hammer1Pack")
				{
					Player::setItemCount(%client, Hammer2Pack,0);
				}
				if(%item == "Mortar" || %item == "RocketLauncher")
				{
					systemMessage(%client,1,"Juggernaught Can Not Sell These Items.");
					return;
				}
			}

			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			systemMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
	remoteDropItem(%client,%type);
}

function remoteUseItem(%player,%type)
{
	%item = getItemData(%type);
	%player.throwStrength = 1;

 	%client = player::getclient(%player);
 	%armor = Player::getArmor(%client);

 	if (%client.curse==true)
		return;

	if (%item == Backpack)
	{
		%item = Player::getMountedItem(%player,$BackpackSlot);
	}
	else if (%item == Weapon)
	{
		%item = Player::getMountedItem(%player,$WeaponSlot);
		Player::useItem(%player,%item);
	}
	Player::useItem(%player,%item);

}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);

 	if (%client.curse==true)
		return;

	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime())
	{
		if(GameBase::getControlClient(%player) != -1)
		{
			if(GameBase::getControlClient(%player) != -1)
			{
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
}

function showitemnumbers()
{
	for (%k=0; getItemData(%k) != ""; %k++)
	{
		echo ("Item Nunber " @ %k @ " = " @ getItemData(%k) @ " = " @ getItemData(%k).description);
	}
}

function remoteDropItem(%client,%type)
{
	%client.throwStrength = 1;
	%item = getItemData(%type);
	%armor = Player::getArmor(%client);

 	if (%client.curse==true)
		return;

	%player = Client::getOwnedObject(%client);
	%ccp = GameBase::getControlClient(%player);
	if ( (%client != %ccp) && (%ccp != -1) )
	{
		systemMessage(%client,1,"You can't drop what's not yours.  You are in a possessed state.~wAccess_Denied.wav");
		return;
	}

	if((Client::getOwnedObject(%client)).driver != 1)
	{
		if (%armor == "jarmor")
		{
			if(%item == "Mortar" || %item == "RocketLauncher" || %item == "PlasmaCannon" || %item == "LasCannon")
			{
				systemMessage(%client,1,"Juggernaught Can Not Drop These Items.");
				return;
			}

			if (%item == Weapon)
			{
				systemMessage(%client,1,"Juggernaught Can Not Drop These Items.");
				return;
			}
		}
		if (%armor == "tarmor")
		{
			if (%item == BackPack)
			{
				return;
			}
		}

		if (%item == Backpack)
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
			if (%item == "FgcPack")
			{
				Player::dropItem(%client,"Mfgl");
				Player::dropItem(%client,"MfglAmmo");
			}
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
			Player::dropItem(%client,%item);
	}
}

function remoteDeployItem(%client,%type)
{
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

function Item::BuildWeaponArray()
{
	$WeaponAmmt = 30;
	$WeaponList[0] = "Blaster";
	$WeaponList[1] = "PlasmaGun";
	$WeaponList[2] = "Chaingun";
	$WeaponList[3] = "Disclauncher";
	$WeaponList[4] = "GrenadeLauncher";
	$WeaponList[5] = "Mortar";
	$WeaponList[6] = "LaserRifle";
	$WeaponList[7] = "RocketLauncher";
	$WeaponList[8] = "SniperRifle2";
	$WeaponList[9] = "ConCun";
	$WeaponList[10] = "EnergyRifle";
	$WeaponList[11] = "RailGun";
	$WeaponList[12] = "Mfgl";
	$WeaponList[13] = "Silencer";
	$WeaponList[14] = "Vulcan";
	$WeaponList[15] = "SMML";
	$WeaponList[16] = "Flamer";
	$WeaponList[17] = "TranqGun";
	$WeaponList[18] = "HyperB";
	$WeaponList[19] = "Volter";
	$WeaponList[20] = "FixIt";
	$WeaponList[21] = "Hackit";
	$WeaponList[22] = "DisIt";
	$WeaponList[23] = "GravGun";
	$WeaponList[24] = "LasCannon";
	$WeaponList[25] = "BoomStick";
	$WeaponList[26] = "PlasmaCannon";
	$WeaponList[27] = "JailGun";
	$WeaponList[28] = "MiniPlasmaCannon";
	$WeaponList[29] = "Fists";
	$WeaponList[30] = "SortieGun";
	$WeaponList[31] = "FlyerGun";

	for (%i=0; %i <= $WeaponAmmt; %i++) //=== Build Next Array
	{
		%next = $WeaponList[%i+1];
		%curr = $WeaponList[%i];

		if (%i < $WeaponAmmt)
		{
			$NextWeapon[%curr] = %next;
		}
		else if (%i == $WeaponAmmt)
		{
			$NextWeapon[%curr] = $WeaponList[0];
		}
	}

	for (%i = $WeaponAmmt; %i >= 0; %i--)
	{
		%curr = $WeaponList[%i];
		%prev = $WeaponList[%i-1];

		if (%i == 0)
		{
			$PrevWeapon[%curr] = $WeaponList[$WeaponAmmt];
		}
		else if (%i > 0)
		{
			$PrevWeapon[%curr] = %prev;
		}
	}
}

Item::BuildWeaponArray();

function ShowWeaponArray()
{
	for (%i=0; %i <= $WeaponAmmt; %i++)
	{
		%weapon = $WeaponList[%i];
		%next = $NextWeapon[%weapon];

		echo ("Next Weapon For " @ %weapon @ " = " @ %next);
	}

	echo ("*** Previous Weapon List");
	for (%i=0; %i <= $WeaponAmmt; %i++)
	{
		%weapon = $WeaponList[%i];
		%next = $PrevWeapon[%weapon];

		echo ("Prev Weapon For " @ %weapon @ " = " @ %next);
	}

}

function remoteNextWeapon(%client)
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);

 	if (%client.curse==true)
		return;

	%ccp = GameBase::getControlClient(%player);
	if ( (%client != %ccp) && (%ccp != -1) )
	{
		systemMessage(%client,1,"You can't change what's not yours.  You are in a possessed state.~wAccess_Denied.wav");
		return;
	}

	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead)
	{
		return;
	}

	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
	{
		selectValidWeapon(%client);
	}
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
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);

 	if (%client.curse==true)
		return;

	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead)
	{
		return;
	}

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
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
}

function selectValidWeapon(%client)
{
	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead)
	{
		return;
	}

	%item = EnergyRifle;
	for (%weapon = $NextWeapon[%item]; %weapon != %item;%weapon = $NextWeapon[%weapon])
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
	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead)
	{
		return;
	}

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
			if (Player::getMountedItem(%player,$BackpackSlot) == -1)
			{
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				systemMessage(%client,0,"You received a " @ %item @ " backpack");
		 		return 1;
			}
		}
		else if (%item.className == VModule)
		{

		    if (!Player::getItemCount(%player, HellFireModule) && !Player::getItemCount(%player, DetPackModule) && !Player::getItemCount(%player, RamModule) && !Player::getItemCount(%player, WraithModule) )
			{
		 		Player::incItemCount(%player,%item);
				systemMessage(%client,0,"You received a " @ %item,description @ ".");
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
				systemMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
				return %delta;
			}
		}
   	}
   	else
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

function Item::onMount(%player,%item)
{
}

function Item::onUnmount(%player,%item)
{
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
}

//========================
// Flag
//========================

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
	mapIcon = "M_camera";

	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
	validateShape = true;
};

//========================
// Armors
//========================
//xxx
ItemData RunnerArmor
{
	heading = "aArmor";
	description = "Runner";
	className = "Armor";
	price = 100;
};

	ItemData ScoutArmor
	{
	   	heading = "aArmor";
		description = "Recon";
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
		description = "Assassin";
		className = "Armor";
		price = 175;
	};


	ItemData MediumArmor
	{
	   	heading = "aArmor";
		description = "Patriot";
		className = "Armor";
		price = 250;
	};

	ItemData BursterArmor
	{
	   	heading = "aArmor";
		description = "Goliath";
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
		description = "Stealth";
		className = "Armor";
		price = 250;
	};

	ItemData HeavyArmor
	{
	   	heading = "aArmor";
		description = "DreadNaught";
		className = "Armor";
		price = 400;
	};

	ItemData Juggernaught
	{
	   	heading = "aArmor";
		description = "Juggernaught";
		className = "Armor";
		price = 3500;
	};

//========================Patriot Booster Image
ItemImageData Booster1PackImage
{
	shapeFile = "mortargun";
	mountPoint = 3;
	mountOffset = { 0.22, -0.2, 0.35 };
	mountRotation = { -1.57, 2.99, 0 };
	weaponType = 0;
	projectileType = Booster;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 1, 1, 0 };
};

ItemData Booster1Pack
{
	description = "Booster";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Booster1PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
};

function Booster1PackImage::onActivate(%player,%imageSlot){}
function Booster1PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData Booster2PackImage
{
	shapeFile = "mortargun";
	mountPoint = 3;
	mountOffset = { -0.25, -0.2, 0.35 };
	mountRotation = { -1.57, -2.99, 0 };
	weaponType = 0;
	projectileType = Booster;
	minEnergy = 0.1;
	maxEnergy = 0.1;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.0;
	lightType = 3;
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 1, 1, 0 };
};

ItemData Booster2Pack
{
	description = "Booster";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Booster2PackImage;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
};
function Booster2PackImage::onActivate(%player,%imageSlot){}
function Booster2PackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}


//========================
// Vehicles
//========================
//xxx
ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 600;
};

ItemData FighterVehicle
{
	description = "Fighter";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 600;
};

ItemData ProwlerVehicle
{
	description = "Prowler";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 600;
};

ItemData LAPCVehicle
{
	description = "Bomber";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "GunShip";
	className = "Vehicle";
   	heading = "aVehicle";
	price = 875;
};

ItemData GAPCVehicle
{
	description = "Jerico";
	className = "Vehicle";
   	heading = "bHoverCraft";
	price = 875;
};

//========================
//==Tools
//==Weapons
//==Ammo
//========================
//xxx
ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onUse(%player,%item)
{
	%ammo = %item.imageType.ammoType;

	if (%ammo == "")
	{
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else
	{
		if (Player::getItemCount(%player,%ammo) > 0)
			Player::mountItem(%player,%item,$WeaponSlot);
		else
		{
			systemMessage(Player::getClient(%player),0,
			strcat(%item.description," has no ammo"));
		}
	}

}

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}


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
		%delta = $SellAmmo[%item];
		if(%count <= %delta)
		{
			if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else
				%delta = %count - 1;

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

//========================2-in-1 Gun

ItemImageData HackitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;
	projectileType = "HackBolt";
	minEnergy = 5;
	maxEnergy = 12;

	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundDeploySensor;
	sfxActivate = SoundMineActivate;
};

ItemData Hackit
{
	description   = "2-in-1 Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "repairpack";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = HackitImage;
	price         = 350;
	showWeaponBar = true;
};

function Hackit::onMount(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	Bottomprint(%clientId, "<jc><f1>2-in-1 Hack");
}

//========================2-in-1 Gun Dys Option

ItemImageData DisItImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;
	projectileType = "DisaBolt";
	minEnergy = 5;
	maxEnergy = 12;

	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundPDA;
	sfxActivate = SoundMineActivate;
};

ItemData DisIt
{
	description   = "Disassymbler-Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "repairpack";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = DisItImage;
	price         = 350;
	showWeaponBar = true;
};
function DisIt::onMount(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	schedule("bottomprint(" @ %clientId @ ", \"<jc><f1>2-in-1 Disassemble\", 3);", 1);
}

ItemData AirStrike
{
	description = "AirStrike";
	className = "Ammo";
	shapeFile = "breath";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 0;
	triggerRadius = 5;
};

function AirStrike::OnCollision(%this, %object)
{
	%player = %this.DetBugOwner;
	if (%this.tc == %object) %player.tc = %object;
}

ItemImageData SortieGunImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = "SortieBolt";
	minEnergy = 5;
	maxEnergy = 10;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundMineActivate;
};

ItemData SortieGun
{
	description   = "AirStrike Laser";
	className = "Weapon";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = SortieGunImage;
	price         = 500;
	showWeaponBar = true;
};

ItemImageData AlienGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0.2, 3.6, 0.2 };
	weaponType = 0;
	projectileType = LasCannonBolt2;
	accuFire = True;
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	lightType = 3;
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };
	sfxFire = SoundChainTurretOff;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = energyExplosion;
	sfxReady = SoundELFIdle;
};

ItemData AlienGun
{
	description = "Alien GunTurret";
	shapeFile = "GunTuret";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "wMiscellany";
	shadowDetailMask = 4;
	imageType = AlienGunImage;
	showWeaponBar = true;
	price = 500;
};
function AlienGun::onMount(%player,%item)
{
	Player::MountItem(%player,FlyerGunMount,7);
}

function AlienGun::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
}

//========================Base Blaster

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.250;
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

//========================Las-Cannon
ItemImageData LasCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.2, -0.8, 0.4 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 140;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	mass = 2.5;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LasCannon
{
	description = "Cannon: Laser";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LasCannonImage;
	price = 2000;
	showWeaponBar = true;
	showInventory = false;
};
function LasCannon::onMount(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	Bottomprint(%clientId, "<jc><f1>Cannon: Laser");
}
function LasCannonImage::onFire(%player, %slot)
{
	%clientId = player::getclient(%player);

	if (%clientId.lascharge)
	{
		%clientId.charging = "";
		%lc = %clientId.lascharge;
		%armor = Player::getArmor(%player); %client = GameBase::getOwnerClient(%player); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); %pos = (gamebase::getposition(%player));	 %rot = (gamebase::getrotation(%player)); %dir = (Vector::getfromrot(%rot));

		if (%lc > 0)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
		}
		if (%lc > 3)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);
		}
		if (%lc > 5)
		{
			schedule ("Projectile::spawnProjectile(GatlingLaser, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.15);
		}
		if (%lc > 7)
		{
			schedule ("Projectile::spawnProjectile(GatlingLaser, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.4);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.45);
		}
		if (%lc > 9)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.3);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.35);
		}

		if (%lc == 15)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.35);
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.375);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.35);
		}

		%clientId.lascharge = "0";
		return;
	}
	else
	{
		systemMessage(%clientId,1,"** LasCannon Uses Beacons To Charge... ~waccess_denied.wav");
		return;
	}
}

function LasCannoner::Charge(%clientId, %time)
{
	%player = client::getownedobject(%clientId);

	Player::mountItem(%clientId, LasCannon, $WeaponSlot);

	if (!%clientId.charging)
		return;
	if (%time == 5)
	{
		bottomprint (%clientId, "<jc>** LasCannon Done Charging In  " @ %time @ " **",1);
	}
	if (%time > 0)
	{
		%time--;
		schedule("LasCannoner::Charge(" @ %clientId @", " @ %time @ ");",1.0);
		systemMessage(%clientId,0,"~wbuysellsound.wav");
		%clientId.lascharge++;
		return;
	}
	else
	{
		systemMessage(%clientId,1,"** LasCannon Fully Charged~wmine_act.wav");
		BottomPrint (%clientId, "You have 15 seconds to fire the LasCannon before overload..." , 5);
		%clientId.lascharge = 15;
		LasCannoner::Detonate(%clientId, 15);
		return;
	}
}

function LasCannoner::Detonate(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	Player::mountItem(%clientId, LasCannon, $WeaponSlot);

	if (%clientId.lascharge != 15)
		return;

	if (%time > 0)
	{
		%time--;
		schedule("LasCannoner::Detonate(" @ %clientId @", " @ %time @ ");",1.0);
	}
	else //=== Player Detonates On Zero
	{
		%clientId.charging = "";
		%clientId.lascharge = "0";
		%obj = newObject("","Mine","EMPBlast");
		GameBase::throw(%obj,%clientId,0,false);
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 1.5";
		%pos = Vector::add(GameBase::getPosition(%clientId), %padd);
		GameBase::setPosition(%obj, %pos);
		return;
	}
	if (%time > 0 && %time < 6)
	{
		systemMessage(%clientId,1,"~wC_BuySell.wav");
		bottomprint (%clientId, "<jc>** LasCannon OverLoad In " @ %time @ " **");
		if (%time == 3)
		{
			if (Client::getGender(%clientId) == "Female") TeamMessages(3, GameBase::getTeam(%player), Client::getName(%clientId) @ ": My cannon is REd HoT, LoOK OuT!~wfemale5.wtakcovr.wav");
			else TeamMessages(3, GameBase::getTeam(%player), Client::getName(%clientId) @ ": My cannon is REd HoT, LoOK OuT!~wmale4.wtakcovr.wav");
		}
	}
}

//========================Plasma Cannon
ItemImageData PlasmaCannonImage
{
	shapeFile = "mortargun";
	mass = 2;
	mountPoint = 0;
	mountOffset = { 0.2, -0.8, 0.4 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	mass = 2.5;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 140;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData PlasmaCannon
{
	description = "Cannon: Flame";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 2400;
	showWeaponBar = true;
	showInventory = false;
};
function PlasmaCannon::onMount(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	Bottomprint(%clientId, "<jc><f1>Cannon: Flame Plasma");
}

function PlasmaCannonImage::onFire(%player, %slot)
{
	%clientId = player::getclient(%player);

	if (%clientId.plasmacharge)
	{
		%clientId.charging = "";
		%lc = %clientId.plasmacharge;

		%armor = Player::getArmor(%player); %client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pos = (gamebase::getposition(%player));
		%rot = (gamebase::getrotation(%player));
		%dir = (Vector::getfromrot(%rot));

		if (%lc > 0)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
		}
		if (%lc > 3)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.39);
		}
		if (%lc > 5)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.425);
		}
		if (%lc > 7)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.475);
		}
		if (%lc > 9)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.35);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);
		}

		if (%lc == 15)
		{
			schedule ("PlasmaConnonShock2Fire(\"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\", \"" @ %clientId @ "\", \"0\");",0.2);
			schedule ("PlasmaConnonShock2Fire(\"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\", \"" @ %clientId @ "\", \"1\");",0.63);
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.65);
		}
			%fired.deployer = %client;

		%clientId.plasmacharge = "0";
		return;
	}
	else
	{
		systemMessage(%clientId,1,"** PlasmaCannon Uses Beacons To Charge... ~waccess_denied.wav");
		return;
	}
}

function PlasmaCannoner::Charge(%clientId, %time)
{
	%player = client::getownedobject(%clientId);

	Player::mountItem(%clientId, PlasmaCannon, $WeaponSlot);

	if (!%clientId.charging)
		return;
	if (%time == 5)
	{
		bottomprint (%clientId, "<jc>** PlasmaCannon Done Charging In  " @ %time @ " **",1);
	}
	if (%time > 0)
	{
		%time--;
		schedule("PlasmaCannoner::Charge(" @ %clientId @", " @ %time @ ");",1.0);
		systemMessage(%clientId,0,"~wbuysellsound.wav");
		%clientId.plasmacharge++;
		return;
	}
	else
	{
		systemMessage(%clientId,1,"** PlasmaCannon Fully Charged~wmine_act.wav");
		BottomPrint (%clientId, "You have 15 seconds to fire the PlasmaCannon before overload..." , 5);
		%clientId.plasmacharge = 15;
		PlasmaCannoner::Detonate(%clientId, 15);
		return;
	}
}

function PlasmaCannoner::Detonate(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	Player::mountItem(%clientId, PlasmaCannon, $WeaponSlot);

	if (%clientId.plasmacharge != 15)
		return;

	if (%time > 0)
	{
		%time--;
		schedule("PlasmaCannoner::Detonate(" @ %clientId @", " @ %time @ ");",1.0);
	}
	else
	{
		%clientId.charging = "";
		%clientId.plasmacharge = "0";
			%obj = newObject("","Mine","EMPBlast");
			GameBase::throw(%obj,%clientId,0,false);
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 1.5";
			%pos = Vector::add(GameBase::getPosition(%clientId), %padd);
			GameBase::setPosition(%obj, %pos);
  		GameBase::applyDamage(%player, $PlasmaDamageType, 5, "0 0 0", "0 0 0", "0 0 0", %clientId);
		return;
	}
	if (%time > 0 && %time < 6)
	{
		systemMessage(%clientId,1,"~wC_BuySell.wav");
		bottomprint (%clientId, "<jc>** PlasmaCannon OverLoad In " @ %time @ " **");
		if (%time == 3)
		{
			if (Client::getGender(%clientId) == "Female") TeamMessages(3, GameBase::getTeam(%player), Client::getName(%clientId) @ ": My cannon is REd HoT, LoOK OuT!~wfemale5.wtakcovr.wav");
			else TeamMessages(3, GameBase::getTeam(%player), Client::getName(%clientId) @ ": My cannon is REd HoT, LoOK OuT!~wmale4.wtakcovr.wav");
		}
	}
}

function PlasmaConnonShock2Fire(%trans, %player, %vel, %client, %num)
{
	%fired = (Projectile::spawnProjectile(PlasmaCannonShock2, %trans,%player,"0 0 -1"));
	%fired.deployer = %client;

	if (%num == 0)
	{
		$Plasma[0] = %fired;
	}
	if (%num == 1)
	{
		%boom = $Plasma[0];
		$Plasma[%boom] = %fired;
	}

}

function PlasmaCannonShock2::OnRemove(%this)
{
	%boom = $Plasma[%this];
	if (%boom)
	{
		DeployFrags(%boom, 20, %boom.deployer);
	}
}

function PlasmaCannonShock2::Blast(%this)
{
	DeployFrags(%this, 10, %this.deployer);
}

//========================Translocator
ItemImageData EnergyRifleImage
{
	shapeFile = "energygun";
	mountPoint = 0;
	weaponType = 0;
	//projectileType = lightningCharge1;
	minEnergy = 15;
	maxEnergy = 15;
	reloadTime = 0.2;
	fireTime = 0.250;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };
	accuFire = true;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EnergyRifle
{
   	heading = "sPersonnel Movers";
	description = "Translocator";
	className = "Tool";
   	shapeFile  = "energygun";
	hudIcon = "energyRifle";
	shadowDetailMask = 4;
	imageType = EnergyRifleImage;
	price = 500;
	showWeaponBar = true;
};


function EnergyRifleImage::onFire(%player, %slot)
{
	%client = player::getclient(%player);
	%energyLevel = GameBase::getEnergy(%player);
	if (%energyLevel < 80)
	{
		playSound(SoundDryFire,GameBase::getPosition(%player));
		return false;
	}
	%obj = %client.firemortar;
	%pos = GameBase::getPosition(%obj);
	if (%client.firemortar && getObjectType(%obj) == "Grenade")
	{
		GameBase::setPosition(%player, %pos);
		playSound(SoundShieldHit,%pos);
		deleteObject(%obj);
		%client.firemortar = "";
		%enew = (%energyLevel - 79);
		GameBase::setEnergy(%player, %enew);
		return 1;
	}
	else
	{
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%client.firemortar = (Projectile::spawnProjectile("TransShell",%trans,%player,%vel));
		//schedule("if (" @ %client @ ".firemortar == " @ %client.firemortar @ ") " @ %client @ ".firemortar = \"\";", 10);
		playSound(SoundDiscReload,GameBase::getPosition(%player));
	}
}

//========================Equilizer Gun

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
	spinUpTime = 0.2;
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
	description = "Equalizer";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
  	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

//========================Fists
ItemImageData FistsImage
{
	shapeFile = "breath";
	minEnergy = 0.1;
	maxEnergy = 0.1;
	mountPoint = 0;
	weaponType = 0;
	projectileType = Punch;
	accuFire = true;
	reloadTime = 0.3;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0, 0, 0 };
	sfxFire = ThrowPunch;
	sfxActivate = SoundPickUpWeapon;
	mountOffset = { 0, -0.1, 0 };
	firstPerson = false;

};
ItemData Fists
{
	description = "Brass Knuckles";
	className = "Tool";
	shapeFile = "grenade";
	hudIcon = "energygun";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FistsImage;
	price = 375;
	showWeaponBar = False;
	showInventory = false;
};

function Fists::onMount(%player, %item)
{
	$FistsFire[Player::GetClient(%player)] = True;
	CheckFistsFire(%player);
}

function Fists::onUnMount(%player, %item)
{
	$FistsFire[Player::GetClient(%player)] = False;
}

function CheckFistsFire(%player)
{
	%c = Player::GetClient(%player);
	if(Player::isTriggered(%player,$WeaponSlot))
	{
		%armor = Player::getArmor(%c);
		if (%armor == "lfemale" || %armor == "sfemale" || %armor == "spyfemale" || %armor == "stimfemale" || %armor == "mfemale" || %armor == "stimarmor") Player::setAnimation(%player,6);
		else Player::setAnimation(%player,21);
	}
	if($FistsFire[Player::GetClient(%player)] == True)
		schedule("CheckFistsFire(" @ %player @ ");",0.05);
}

//========================Flamer
ItemImageData FlamerImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.1 };
	mountRotation = { 0, 3.14, 0 };
	weaponType = 0;
	reloadTime = 0.1;
	fireTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	minEnergy = 6;
	maxEnergy = 6;
	projectileType = FlamerBolt;
	accuFire = true;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Flamer
{
    	heading = "bWeapons";
	description = "Flame Thrower";
	className = "Weapon";
    	shapeFile  = "plasma";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = FlamerImage;
	price = 385;
	showWeaponBar = true;
};

function Flamer::onMount(%player, %item)
{
	$FlamerFire[Player::GetClient(%player)] = True;
	CheckFlamerFire(%player);
}

function Flamer::onUnMount(%player, %item)
{
	$FlamerFire[Player::GetClient(%player)] = False;
}
function CheckFlamerFire(%player)
{
	if(Player::isTriggered(%player,$WeaponSlot))
	{
		Player::MountItem(%player,Flamerlicks,7);
	}
	else
	{
		Player::UnMountItem(%player,7);
	}
	if($FlamerFire[Player::GetClient(%player)] == True)
		schedule("CheckFlamerFire(" @ %player @ ");",0.05);
}

ItemImageData FlyerGunMountImage
{
	shapeFile = "GunTuret";
	mountPoint = 0;
	mountOffset = { 0.2, 1, -2.3 };
};

ItemData FlyerGunMount
{
	description = "FlyerGunMount";
	className = "Scope";
	shapeFile = "GunTuret";
	shadowDetailMask = 4;
	imageType = FlyerGunMountImage;
	price = 0;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData FlyerGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0.2, 3.6, 0.2 };
	weaponType = 0;
	projectileType = IrradiationBlast;
	accuFire = True;
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	lightType = 3;
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };
	sfxFire = SoundFireMortar2;
	sfxActivate = SoundPickUpWeapon;
};

ItemData FlyerGun
{
	description = "Flyer Gun";
	shapeFile = "GunTuret";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FlyerGunImage;
	showWeaponBar = true;
	price = 500;
};
function FlyerGun::onMount(%player,%item)
{
	Player::MountItem(%player,FlyerGunMount,7);
}

function FlyerGun::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
}

//========================GodHammerCannon
ItemImageData Hammer1PackImage
{
	shapeFile = "mortargun";
	mountPoint = 3;
	mountOffset = { 0.46, 0.1, 2.175 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	projectileType = GodHammer;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.0;
	lightType = 3;
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 1.0, 1, 1.0 };
};

ItemData Hammer1Pack
{
	description = "God Hammer Cannon";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Hammer1PackImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = false;
	showInventory = false;
 	className = "Weapon";
};

function Hammer1PackImage::onActivate(%player,%imageSlot)
{}
function Hammer1PackImage::onDeactivate(%player,%imageSlot)
{ Player::trigger(%player,$BackpackSlot,false); }

ItemImageData Hammer2PackImage
{
	shapeFile = "mortargun";
	mountPoint = 3;
	mountOffset = { -0.27, 0.1, 2.175 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	projectileType = GodHammer;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.0;
	lightType = 3;
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 1, 1, 1.0 };
};

ItemData Hammer2Pack
{
	description = "God Hammer Cannon 2";
	shapeFile = "mortargun";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Hammer2PackImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = false;
	showInventory = false;
 	className = "Weapon";
};

function Hammer2PackImage::onActivate(%player,%imageSlot)
{}
function Hammer2PackImage::onDeactivate(%player,%imageSlot)
{Player::trigger(%player,$BackpackSlot,false);}



//========================Grav Gun
ItemImageData GravGunImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = gravCharge;
	minEnergy = 3;
	maxEnergy = 20;
	reloadTime = 0.2;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.15, 0.85, 0.15 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData GravGun
{
	description = "Grav Gun";
	shapeFile = "paintgun";
	hudIcon = "energyRifle";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = GravGunImage;
	showWeaponBar = true;
	price = 900;
};
//========================Grenade Launcher
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
	weaponType = 0;
	ammoType = GrenadeAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundPickUpWeapon;
	//sfxFire     = SoundELFIdle;
	sfxReload = SoundDryFire;
};

function GrenadeLauncherImage::onFire(%player, %slot)
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[GrenadeLauncher]);
	%playerId = Player::getClient(%player);
	 if(%Ammo || %client.firegrenadelauncher)
	 {
	 	%fired.deployer = %player;
		%client = GameBase::getOwnerClient(%player);
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%armor = Player::getArmor(%player);
		if (%playerId.grenl == 1 || (!%client.grenl && %armor == "harmor") )
		{
			%fired = Projectile::spawnProjectile("EMPgrenshl",%trans,%player,%vel);
			%fired.deployer = %client;
		}
		else if (%playerId.grenl == 2 || (!%client.grenl && (%armor == "barmor" || %armor == "bfemale")) )
		{
			%fired = Projectile::spawnProjectile("Peacegren",%trans,%player,%vel);
			%fired.deployer = %client;
		}
		else if (%playerId.grenl == 3 || (!%client.grenl && (%armor == "larmor" || %armor == "lfemale")) )
		{
			%fired = Projectile::spawnProjectile("Tranqgren",%trans,%player,%vel);
			%fired.deployer = %client;
		}
		else if (%playerId.grenl == 4 || (!%client.grenl && (%armor == "sarmor" || %armor == "sfemale" || %armor == "stimfemale" || %armor == "stimfemale")) )
		{
			%fired = Projectile::spawnProjectile("Concusgren",%trans,%player,%vel);
			%fired.deployer = %client;
		}
		else if (%playerId.grenl == 5 || (!%client.grenl && (%armor == "earmor" || %armor == "efemale")) )
		{
			%obj = newObject("","Mine","AntipersonelMine");
			GameBase::throw(%obj,%player,35,false);
			addToSet("MissionCleanup", %obj);
			%pos = GameBase::getPosition(%player);
			deleteObject(%client.firegrenadelauncher);
			GameBase::setPosition(%obj, %pos);
			%obj.deployer = %client;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
		else if (%playerId.grenl == 6 && (%armor == "spyarmor" || %armor == "spyfemale"))
		{
			%obj = newObject("","Mine","Plastique");
			systemMessage(%client,1, "Plastique Explosive will detonate in 5 seconds");
			%timer = %client.plastic;
			schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", 5);
			GameBase::throw(%obj,%player,9,false);
			addToSet("MissionCleanup", %obj);
			%pos = GameBase::getPosition(%player);
			deleteObject(%client.firegrenadelauncher);
			GameBase::setPosition(%obj, %pos);
			%obj.deployer = %client;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
		else if (%playerId.grenl == 7 || (!%client.grenl && (%armor == "marmor" || %armor == "mfemale")))
		{
			if(GameBase::getLOSInfo(%player,950))
			{
				%type = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				if(%type == "Player" || %type == "Flier" || %type == "Turret" || %type == "StaticShape")
				{
					if(%type == "Player") Tracker(%client,%targetId);
					systemMessage(%client,0,"~wmine_act.wav");
					%fired = Projectile::spawnProjectile("HoverMine",%trans,%player,%vel,$los::object);
					%fired.deployer = %client;
				}
				else
				{
					schedule ("playSound(SoundWeaponSelect,GameBase::getPosition(" @ %player @ "));",0);
					return false;
				}
			}
			else
			{
				schedule ("playSound(SoundWeaponSelect,GameBase::getPosition(" @ %player @ "));",0);
				return false;
			}
		}
		else
		{
			%fired = Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
			%fired.deployer = %client;
		}
		Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
		schedule ("playSound(SoundFireGrenade,GameBase::getPosition(" @ %player @ "));",0);
	}
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
	//validateShape = true;
};


//========================HyperBlaster


ItemImageData HyperBImage
{
   	shapeFile  = "plasma";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = HyperBolt;
	accuFire = true;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HyperB
{
	heading = "bWeapons";
	description = "Hyper Blaster";
	className = "Weapon";
	shapeFile  = "plasma";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = HyperBImage;
	price = 285;
	showWeaponBar = true;
};

//========================Demolition Trigger Gun
ItemImageData DemoGunImage
{
	shapeFile = "force";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.2 };
	weaponType = 0; // Single Shot
	minEnergy  = 3;
	maxEnergy = 10;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
};

ItemData DemoGun
{
	description = "Demolition Trigger";
	shapeFile = "force";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = DemoGunImage;
	price = 125;
	showInventory = false;
};

function DemoGunImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	if(Player::GetItemCount(%player, Beacon) <1)
	{
		systemMessage(%client,0,"You are out of beacons for demolition charges.");
		return;
	}
	for(%i = 0; %i < 10; %i++)
	{
		if ($demomine::var[%client, %i] == "")
		{
			%obj = newObject("","Mine","DemoMine");
			$demomine::var[%client, %i] = %obj;
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,5,false);
			%obj.deployer = %client;
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			systemMessage(%client,0,"Demolition charge dropped.");
			Player::decItemCount(%player,Beacon);
			return;
		}
	}
	systemMessage(%client,0,"Deployable Item limit reached for demolition charges.");
}
function DemoGun::onMount(%player,%imageSlot)
{
	bottomprint(Player::getClient(%player), "<jc><f2>Using Demolition Trigger: fire to lay charges, activate the pack again to detonate.", 2);
}

//========================Laser Rifle
ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 60;

	lightType = 3;
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
	//validateShape = true;
	validateMaterials = true;
};

function LaserRifle::onMount(%player,%imageSlot)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != EnergyPack && Player::getMountedItem(%player,$BackpackSlot) != FlightPack)
	{
		Player::unmountItem(%player, "LaserRifle");
		systemMessage(Player::getClient(%player),0, "Must have an Energy or Flight Pack to use Laser Rifle.~wC_BuySell.wav"); 
	}
	else {}
}

//========================Regeneration Gun
ItemImageData RegenImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = "DrainBolt";
	minEnergy = 5;
	maxEnergy = 12;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundElevatorBlocked;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Regen
{
	description   = "Leech Gun";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "repairpack";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = RegenImage;
	price         = 350;
	showWeaponBar = true;
};

//========================Magnum - Silencer
ItemData SilencerAmmo
{
	description = "Magnum Bullets";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData SilencerImage
{
	shapeFile = "energygun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = SilencerAmmo;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0, 0, 0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	mountRotation = { 0, 0, 0 };

};
ItemData Silencer
{
	description = "Magnum";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "targetlaser";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SilencerImage;
	price = 375;
	showWeaponBar = true;
};

ItemImageData SilencerImage2
{
	shapeFile = "energygun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = SilencerAmmo;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0, 0, 0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	mountRotation = { 0, 0, 0 };
	mountOffset = { -0.9, 0, 0 };

};
ItemData Silencer2
{
	description = "Magnum";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "targetlaser";
  heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SilencerImage2;
	price = 375;
	showWeaponBar = true;
};

function Silencer::OnMount(%player,%slot)
{
	Player::MountItem(%player, Silencer2, 7);
}
function Silencer::OnUnMount(%player,%slot)
{
	Player::UnMountItem(%player, 7);
}

function SilencerImage::onFire(%player, %slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Silencer]);
	if(%AmmoCount)
	{
		Player::decItemCount(%player,$WeaponAmmo[Silencer],1);

		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);

		Projectile::spawnProjectile("SilencerBullet",%trans,%player,%vel);
		schedule("SilencerFire2(" @ %player @ ");", 0.375);
	}
}

function SilencerImage2::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Silencer]);
	if(%AmmoCount)
	{
		Player::decItemCount(%player,$WeaponAmmo[Silencer],1);

		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);

		Projectile::spawnProjectile("SilencerBullet",%trans,%player,%vel);
	}
}

function SilencerFire2(%player)
{
	if(Player::isTriggered(%player,0))
	{
		Player::Trigger(%player,7,true);
		schedule("Player::Trigger(" @ %player @ ",7,false);", 0.05);
	}
}

//========================Mortar
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

	weaponType = 0;
	ammoType = MortarAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	//sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function MortarImage::onFire(%player, %slot)
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);
	%playerId = Player::getClient(%player);

	 if(%Ammo || %client.firemortar)
	 {
	 	%fired.deployer = %player;
		%client = GameBase::getOwnerClient(%player);
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%armor = Player::getArmor(%player);
		if (%armor == "aarmor" || %armor == "afemale" || %playerId.Mortar == 1)//==emp
			%fired = Projectile::spawnProjectile("EMPMortar",%trans,%player,%vel);
		else if (%playerId.Mortar == 2)//==frag
		{
			%fired = Projectile::spawnProjectile("BomberShell",%trans,%player,%vel);
			%fired.deployer = %client;
		}
		else if (%playerId.Mortar == 3)//==mdm
		{
			if (%client.firemortar)
			{
				%obj = newObject("","Mine","MDMBlast");
				GameBase::throw(%obj,%player,0,false);
				addToSet("MissionCleanup", %obj);
				%pos = GameBase::getPosition(%client.firemortar);
				deleteObject(%client.firemortar);
				GameBase::setPosition(%obj, %pos);
				%client.firemortar = 0;
				schedule ("playSound(SoundTAT,GameBase::getPosition(" @ %player @ "));",0);
				return 1;
			}
			else
			{
				%client.firemortar = (Projectile::spawnProjectile("DelayMortarShell",%trans,%player,%vel));
				schedule("if (" @ %client @ ".firemortar == " @ %client.firemortar @ ") " @ %client @ ".firemortar = \"\";", 10);
			}
		}
		else %fired = Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
		schedule ("playSound(SoundFireMortar,GameBase::getPosition(" @ %player @ "));",0);
		Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
	}
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
	validateShape = true;
};

//========================Penis

ItemImageData PenisImage
{
	shapeFile  = "cactus1";

	mountPoint = 2;
	mountOffset = { 0, 0.1, -0.2 };
	mountRotation = { -1.572, 0, 0 };

	weaponType = 0;
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = false;

	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxFire = SoundFlyerActive;
	sfxActivate = SoundPickUpWeapon;
	mass = 20;
};

ItemData Penis
{
	heading = "bWeapons";
	description = "Penis";
	className = "Weapon";
	shapeFile  = "cactus1";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PenisImage;
	price = 0;
	showWeaponBar = true;
};

//========================Mini Plasma Cannon

ItemImageData MiniPlasmaCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = FusionBolt;
	accuFire = True;
	reloadTime = 0.5;
	fireTime = 0.2;
	minEnergy = 15;
	maxEnergy = 50;

	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundGeneratorPower;
};

ItemData MiniPlasmaCannon
{
	description = "MiniTurret Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MiniPlasmaCannonImage;
	price = 250;
	showWeaponBar = true;
};

//========================Plasma Gun

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
	ammoType = "PlasmaAmmo";
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};


function PlasmaGunImage::onFire(%player, %slot)
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]);

	 %playerId = Player::getClient(%player);
	 if(%Ammo)
	 {
		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     	 %vel = Item::getVelocity(%player);

		if (!%playerId.Plasma || %playerId.Plasma == 0)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			Projectile::spawnProjectile("PlasmaBolt",%trans,%player,%vel);
		}
		else if (%playerId.Plasma == 1)
		{
			Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			%vel = EmplacementPack::rotVector( "15 0 -15", GameBase::getRotation(%player));
			Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "-15 0 -15", GameBase::getRotation(%player));
			Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);

			%vel = EmplacementPack::rotVector( "0 2 15", GameBase::getRotation(%player));
			Projectile::spawnProjectile("PlasmaBoltMulti",%trans,%player,%vel);
		}
	}
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
	//validateShape = true;
};
//========================Pneumatic Rifle
ItemData RifleAmmo
{
	description = "Rifle Ammo";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};
ItemImageData TranqGunImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = RifleAmmo;
	//projectileType = TranqDart;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = Soundthrowitem;
	sfxActivate = SoundPickUpWeapon;
};

function TranqGunImage::onFire(%player, %slot)
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[TranqGun]);
	 if(%Ammo)
	 {
	 	%fired.deployer = %player;
		%client = GameBase::getOwnerClient(%player);
		%vel = Item::getVelocity(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%armor = Player::getArmor(%player);
		%sound = SoundFireLaser;
		if (%client.snipe == 1)
		{
			%fired = Projectile::spawnProjectile("HotRound",%trans,%player,%vel);
		}
		else if (%client.snipe == 2)
		{
			%fired = Projectile::spawnProjectile("EMPRound",%trans,%player,%vel);
		}
		else
		{
			%fired = Projectile::spawnProjectile("TranqDart",%trans,%player,%vel);
		}
		Player::decItemCount(%player,$WeaponAmmo[TranqGun],1);
	}
}

ItemData TranqGun
{
	description = "Pneumatic Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = TranqGunImage;
	price = 475;
	showWeaponBar = true;
};

//========================Rail Gun

ItemImageData RailgunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0;
	ammoType = RifleAmmo;
	projectileType = RailRound;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Railgun
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 375;
	showWeaponBar = true;
};

//========================Repair Gun
ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;

	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundMineActivate;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	price = 125;
	showInventory = false;
};

function RepairGun::onMount(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if (%armor != "earmor" && %armor != "efemale")
		Player::trigger(%player,$BackpackSlot,true);

}

function RepairGun::onUnmount(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);

	if (%armor != "earmor" && %armor != "efemale")
		Player::trigger(%player,$BackpackSlot,false);

}

//========================Engineer Repair Gun


ItemImageData FixitImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = "RepairBolt";
	minEnergy = 5;
	maxEnergy = 12;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire     = SoundRepairItem;
	sfxActivate = SoundMineActivate;
};

ItemData Fixit
{
	description   = "Repair Gun";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "repairpack";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = FixitImage;
	price         = 350;
	showWeaponBar = true;
};
//========================Rocket Launcher
ItemData RocketAmmo
{
	description = "RocketAmmo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData StunWtImage
{
	shapeFile = "breath";
	mountPoint = 5;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, 0 };
	mass = 20;
};

ItemData StunWt
{
	description = "Dead Weight";
	className = "Tool";
	shapeFile = "breath";
	shadowDetailMask = 7;
	imageType = StunWtImage;
	heading = "wMiscellany";
	price = 0;
	hudIcon = "energyRifle";
	showWeaponBar = False;
	showInventory = True;
};

ItemImageData RocketImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, -0.87, 0 };
	weaponType = 0;
	ammoType = RocketAmmo;
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 1.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxReload = SoundMortarReload;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
};

ItemData RocketLauncher
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 375;
	showWeaponBar = true;
};

function RocketImage::onFire(%player, %slot)
{
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	%armor = Player::getArmor(%player);
	%client = GameBase::getOwnerClient(%player);

	 if(%Ammo)
	 {
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);

		if (%client.rocket == 1 || %armor == "jarmor") //== Stinger w/ locking.
		{
			if(GameBase::getLOSInfo(%player,950))
			{
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient(%object);

				if(%object == "Player" || %object == "Flier")
				{
					%armor = Player::getArmor(%object);
					if (%armor != "spyarmor" || %armor != "spyfemale")
					{
						%name = Client::getName(%targetId);
						Tracker(%client,%targetId);
						systemMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
						Projectile::spawnProjectile("TurretMissile",%trans,%player,%vel,$los::object);
					}
					else
					{
						systemMessage(Player::getClient(%player), 0,"Target Lock Failed...");
						Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel,%player);
					}
				}
				else
				{
				Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel,%player);
				}
			}
			else
			{
				Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel,%player);
			}
			schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));",0);
		}
		else if (!%client.rocket || %client.rocket == 0)	//== Standard Stinger Rocket
		{
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));",0);
			Projectile::spawnProjectile("FlierRocket",%trans,%player,%vel);
		}
		else if (%client.rocket == 2)			//== Lock-Jaw Rocket
		{
			if (!%client.target || %client.target == "-1" || %client.target == %player)
			{
				%fired = (Projectile::spawnProjectile("LockJaw",%trans,%player,%vel));
				schedule ("deleteobject(" @ %fired @ ");",0.05);
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
			else if (%client.target != "-1")
			{
				%rnd = (getRandom());

				if (%rnd > 0.8)
				{
					schedule("bottomprint(" @ %client @ ", \"<jc><f1>Lock Failed!\", 3);", 0);
					schedule("systemMessage(" @ %client @ ",1,\"Lock Failed!~waccess_denied.wav\");",0);
					return;
				}
				if (gamebase::getteam(%client.target) == gamebase::getteam(%player))
				{
					schedule("bottomprint(" @ %client @ ", \"<jc><f1>Lock Failed, Can Not Target Friendlies!\", 3);", 0);
					%client.target = -1;
					return;
				}
				else
				{
					$targeting = %player;
					LockJawFire(%player, %target);
				}
			}
		}
		else if (%client.rocket == 3)
		{
			Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
			schedule ("playSound(SoundMissileTurretFire,GameBase::getPosition(" @ %player @ "));",0);
			%obj1 = (Projectile::spawnProjectile("GodHammerMortar",%trans,%player,%vel));
			%obj1.deployer = %client;
			GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.10, 2, %client);
		}
	}
	else
		systemMessage(Player::getClient(%player), 0,"You have no Ammo for the Rocket Launcher");
}

function Tracker(%clientId, %targetId, %delay)
{
	if(%targetId)
	{
		%name = Client::getName(%clientId);
		 systemMessage(%targetId,1,"** WARNING ** - " @ %name @ " is locked and loaded!~waccess_denied.wav");
		 schedule("systemMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",0.5);
		 schedule("systemMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.0);
		 schedule("systemMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");",1.5);
	}
}

//========================Runner Sabotage Gun

ItemImageData SabGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = "SabBolt";
	minEnergy = 5;
	maxEnergy = 12;
	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire     = SoundDeploySensor;
	sfxActivate = SoundMineActivate;
};

ItemData SabGun
{
	description   = "Saboteur Tool";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "repairpack";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType     = SabGunImage;
	price         = 0;
	showWeaponBar = false;
};

//========================Shockwave Cannon
ItemImageData ConCunImage
{
	shapeFile = "mortar";
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, -0.15 };
	mountPoint = 0;
	weaponType = 0;
    	minEnergy = 40;
	maxEnergy = 45;
	projectileType = Shock;
	accuFire = true;
	fireTime = 0.9;
	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;

};
ItemData ConCun
{
	description = "Shockwave Cannon";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "disk";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ConCunImage;
	price = 250;
	showWeaponBar = true;
};

//========================Boom Stick
ItemData BoomAmmo
{
	description = "Shotgun Shell";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData BoomStickImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	ammoType = BoomAmmo;
	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 1.1;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireMortar;
	sfxReload   = SoundMortarReload;
};

ItemData BoomStick
{
	description = "Shotgun";
	shapeFile = "shotgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = BoomStickImage;
	showWeaponBar = true;
	price = 500;
};

ItemImageData BoomStickImage2
{
	shapeFile = "shotgun";
	mountPoint = 0;
	ammoType = BoomAmmo;
	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 1.1;
	minEnergy = 5;
	maxEnergy = 6;
	accuFire = fa;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireMortar;
	sfxReload   = SoundMortarReload;
	mountOffset = { 0, 0, -0.07 };
};

ItemData BoomStick2
{
	description = "Shotgun";
	shapeFile = "shotgun";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = BoomStickImage2;
	showWeaponBar = true;
	price = 500;
};

function BoomStick::onMount(%player, %slot)
{
	Player::MountItem(%player, BoomStick2, 7);
}

function BoomStick::onUnMount(%player, %slot)
{
	Player::UnMountItem(%player, 7);
}
function BoomStickImage::onFire(%player, %slot)
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[BoomStick]);
	 if(%AmmoCount)
	 {
		%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player,$WeaponAmmo[BoomStick],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Player::Trigger(%player, 7, true);
		Player::Trigger(%player, 7, false);
		for (%i=0; %i < 29; %i++)
		{
			Projectile::spawnProjectile("BoomStickBlast",%trans,%player,%vel);
		}
	}
	else
		systemMessage(Player::getClient(%player), 0,"Out Of Shells");

}

//========================Sniper Rifle
ItemImageData SniperScopeImage
 {
shapeFile = "force";
mountPoint = 0;
mountRotation = { 1.57, 0, 0 };
mountOffset = { 0, 0, 0.18 };
};
ItemData SniperScope
{
	description = "Sniper Scope";
	className = "Scope";
	shapeFile = "force";
	shadowDetailMask = 4;
	imageType = SniperScopeImage;
	price = 0;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData FlamerlicksImage
{
  	shapeFile  = "rocket";
	mountPoint = 0;
	mountOffset = { 0, 0.3, -0.23 };
	mountRotation = { 0, 0, 3.14 };
	weaponType = 0;
	reloadTime = 0.1;
	fireTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	minEnergy = 6;
	maxEnergy = 6;
	accuFire = true;
	sfxFire = SoundJetHeavy;
};
ItemData Flamerlicks
{
    	heading = "bWeapons";
	description = "Flame Thrower";
	className = "Weapon";
    	shapeFile  = "GrenadeL";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = FlamerlicksImage;
	price = 0;
	showWeaponBar = false;
};

ItemImageData SniperRifle2Image
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	ammoType = RifleAmmo;
	projectileType = SniperRound2;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0.08;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle2
{
	description = "Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SniperRifle2Image;
	price = 375;
	showWeaponBar = true;
};

function SniperRifle2::onMount(%player,%item)
{
	Player::MountItem(%player,SniperScope,7);
}
function SniperRifle2::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,7);
	Player::UnMountItem(%player,6);
}

//========================Nuke Launcher

ItemImageData NukelicksImage
{
  	shapeFile  = "mortarpack";
	mountPoint = 0;
	mountRotation = {-1.57, 0, 0 };
	mountOffset = { 0, 0, 0.1 };
};
ItemData Nukelicks
{
    	heading = "bWeapons";
	description = "Nuke Scope";
	className = "Weapon";
    	shapeFile  = "mortarpack";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = NukelicksImage;
	price = 0;
	showWeaponBar = false;
};

ItemData MfglAmmo
{
	description = "Nuclear Warhead";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 500;
	mass = 0.25;
};

ItemImageData MfglImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MfglAmmo;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 4.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundNukes;
};

ItemData Mfgl
{
	description = "Tactical Nuke";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MfglImage;
	price = 3500;
	showWeaponBar = true;
};

function MfglImage::onFire(%player, %slot)
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Mfgl]);
	%armor = Player::getArmor(%player);
	%client = GameBase::getOwnerClient(%player);
	if(Player::getMountedItem(%player,$BackpackSlot) == FgcPack)
	{
		if(%AmmoCount)
		{
			ixApplyKickback(%player, 500, 70);
			$TeamItemCount[GameBase::getTeam(%player) @ "MFGLAmmo"]++;
			Player::decItemCount(%player,$WeaponAmmo[Mfgl],1);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			%fired = (Projectile::spawnProjectile("FgcShell",%trans,%player,%vel));
			%fired.deployer = %client;
			if (Client::getGender(%client) == "Female") TeamMessages(3, GameBase::getTeam(%player), Client::getName(%client) @ ": FIRE IN THE HOLE!~wfemale5.wtakcovr.wav");
			else TeamMessages(3, GameBase::getTeam(%player), Client::getName(%client) @ ": FIRE IN THE HOLE!~wmale4.wtakcovr.wav");
		}
		else
		{
			systemMessage(%client, 0,"Out Of Shells");
		}
	}
	else
	{
		$TeamItemCount[GameBase::getTeam(%player) @ "MFGLAmmo"]++;
		systemMessage(%client, 1,"Firing A Tactical Nuke With Out A Nuclear Containment Pack Can Be Dangerous.");
		GameBase::applyRadiusDamage($NukeDamageType, getBoxCenter(%player), 3, 15, 500, %player);
		return;
	}
}

function Mfgl::onMount(%player, %item)
{
	Player::MountItem(%player,Nukelicks,7);
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	if ($TeamItemCount[%team @ "MfglAmmo"] <0 )
	{
		Player::setItemCount(%client, MFGLAmmo,1);
		if (Client::getGender(%client) == "Female") TeamMessages(3, GameBase::getTeam(%player), Client::getName(%client) @ ": Nuke in route!~wmale5.wretreat.wav");
		else TeamMessages(3, GameBase::getTeam(%player), Client::getName(%client) @ ": Nuke in Route!~wmale5.wretreat.wav");
	}
	bottomprint(%client, "<jc><f2>Tactical Nuke Launcher.  Your team has " @ 0 - $TeamItemCount[%team @ "MfglAmmo"] @ " Nuclear Warheads available for use.");
	if (%team.nukgen == "") bottomprint(%client,"<jc><f2>Tactical Nuke Launcher.  Your team has no nuclear capability.  Goliath needs to deploy the Nuclear Pack as a Nuclear Generator.");
	else if ($TeamItemCount[%team @ "MfglAmmo"] == "0") bottomprint(%client,"<jc><f2>Tactical Nuke Launcher.  Wait... Nuclear Generator is building warheads.");
}

function Mfgl::onUnMount(%player, %item)
{
	Player::UnMountItem(%player,7);
}

//========================Targetting Laser

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 3;
	maxEnergy = 3;
	reloadTime = 1.0;
	lightType   = 3;
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
//======================== Spray Paint Can

ItemData PaintAmmo
{
	description = "Thorns";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SprayCanImage
{
	shapeFile = "plasammo";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, -0.4 };
	mountRotation = { 0, 0, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.3;
	spinDownTime = 0;
	fireTime = 0.2;
	ammoType = PaintAmmo;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundSprayCan;
	sfxActivate = SoundWeaponSelect;
	sfxSpinUp = SoundSpinDown;
	sfxSpinDown = SoundSpinDown;
};

ItemData SprayCan
{
	description = "Thorn Spreader";
	shapeFile = "plasammo";
	className = "Weapon";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SprayCanImage;
	price = 35;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function SprayCanImage::onFire(%player, %slot)
{
	%cl = Player::getClient(%player);
	if(Player::getItemCount(%player, $WeaponAmmo[SprayCan]) )
	{
		%team = GameBase::getTeam(%player);
		if ($TeamItemCount[%team @ "Pigment"] < $TeamItemMax["Pigment"] )
	 	{
			$TeamItemCount[%team @ "Pigment"]++;
			%obj = newObject("","Mine","Pigment");
			GameBase::setTeam(%obj,%team);
			GameBase::throw(%obj,%player,5,false);
			addToSet("MissionCleanup", %obj);
			%obj.deployer = %cl;
			if (Player::getItemCount(%player, $WeaponAmmo[SprayCan])==1) systemMessage(%cl,1,"You're spreader is empty.");
			Player::decItemCount(%player,$WeaponAmmo[SprayCan],1);
		}
		else systemMessage(%cl,1,"Your team has enough pricks already.");
	}
}
//========================Disc Launcher
ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData HDisc1Image 
{ 
	shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0,-1.57, 0 }; 
	mountOffset = { 0.1, 0, 0 };
	ammoType = DiscAmmo; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0.067; 
	fireTime = 0.067; 
	spinUpTime = 0.067; 
	projectileType = DiscShell;
}; 

ItemData HDisc1 
{ 
	description = "Twin Fuser";
	 className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HDisc1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HDisc2Image 
{
	 shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0,1.57, 0 };
	mountOffset = { 0.03, 0, 0 };
	 ammoType = DiscAmmo; 
	weaponType = 3; 
	accuFire = true; 

	reloadTime = 0.25;
	fireTime = 0.10;
	spinUpTime = 0.25; 
	projectileType = DiscShell; 
}; 

ItemData HDisc2 
{ 
	description = "Twin Fuser";
	 className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HDisc2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData HDiscLauncherImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 3; 
	ammoType = DiscAmmo; 
	accuFire = true; 
	reloadTime = 0.25;
	fireTime = 0.10;
	spinUpTime = 0.25; 
	sfxFire = SoundFireDisc; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundDiscReload; 
	sfxReady =  SoundUseCommandStation; 
}; 

ItemData DiscLauncher 
{ 
	description = "Twin Fuser"; 
	className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
   heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = HDiscLauncherImage; 
	price = 300; 
	showWeaponBar = true; 
}; 

function HDiscLauncherImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,6);  
	%state2 = Player::getItemState(%player,7);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		Player::decItemCount(%player, "DiscAmmo", 0.5);   
		%num = Player::getItemCount(%player, "DiscAmmo");   
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Player::setItemCount(%player, "DiscAmmo", 0);    
			else     
			Player::setItemCount(%player, "DiscAmmo", %num);    
			Player::trigger(%player,7,true);    
			Player::trigger(%player,7,false);   
		} 
		else 
		{    

			%client.hd = 0;    
			if(%num == 1)     
			Player::setItemCount(%player, "DiscAmmo", 0);    
			else     
			Player::setItemCount(%player, "DiscAmmo", %num);    
			Player::trigger(%player,6,true);    
			Player::trigger(%player,6,false);   
		}  
	} 
} 

function DiscLauncher::onMount(%player,%imageSlot) 
{  
	%num = Player::getItemCount(%player, "DiscAmmo");  
	Player::setItemCount(%player, "DiscAmmo", %num);  
	Player::mountItem(%player,HDisc1,7);  
	Player::mountItem(%player,HDisc2,6); 
} 

function DiscLauncher::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,7);  
	Player::unmountItem(%player,6); 
}
function HDisc2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Twin Fuser");
}
//========================Volter

ItemImageData VolterImage
{
	shapeFile  = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = Flameburst;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxFire = SoundFlyerActive;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Volter
{
	heading = "bWeapons";
	description = "Volter";
	className = "Weapon";
	shapeFile  = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = VolterImage;
	price = 385;
	showWeaponBar = true;
};

//========================Vulcan
ItemImageData VulcanImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = BulletAmmo;
	projectileType = VulcanBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
	mountOffset = { 0.1, 0, 0 };
};

ItemData Vulcan
{
	description = "Vulcan";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = VulcanImage;
	price = 125;
	showWeaponBar = true;
};

ItemImageData Vulcan2Image
{
	shapeFile = "chaingun";
	mountPoint = 0;
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = BulletAmmo;
	projectileType = VulcanBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
	mountOffset = { -0.1, 0, 0 };
};
ItemData Vulcan2
{
	description = "Vulcan";
	className = "Weapon";
	shapeFile = "chaingun";
	shadowDetailMask = 4;
	imageType = Vulcan2Image;
	price = 125;
	showWeaponBar = False;
	showInventory = False;
};

function Vulcan::onMount(%player, %item)
{
	Player::MountItem(%player,Vulcan2,7);
	$VulcanFire[Player::GetClient(%player)] = True;
	CheckVulcanFire(%player);
}

function Vulcan::onUnMount(%player, %item)
{
	$VulcanFire[Player::GetClient(%player)] = False;
	Player::UnMountItem(%player,7);
}

function CheckVulcanFire(%player)
{
	if(Player::isTriggered(%player,$WeaponSlot))
	{
		Player::trigger(%player,7,true);
	}
	else
	{
		Player::trigger(%player,7,false);
	}
	if($VulcanFire[Player::GetClient(%player)] == True)
		schedule("CheckVulcanFire(" @ %player @ ");",0.05);
}

//========================
//==BackPacks c
//========================
//xxx
ItemData Backpack
{
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::trigger(%player,$BackpackSlot);
	}
}

//========================Ammo Pack

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
	mass = 1.0;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
  	heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
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
		for(%i = 0; %i < 11 ; %i = %i +1)
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
			if(%i == 0) {%item.BulletAmmo = %numPack;}
			else if(%i == 1) {%item.PlasmaAmmo = %numPack;}
			else if(%i == 2) {%item.DiscAmmo = %numPack;}
			else if(%i == 3) {%item.GrenadeAmmo = %numPack;}
			else if(%i == 4) {%item.Grenade = %numPack;}
			else if(%i == 5) {%item.MortarAmmo = %numPack;}
			else if(%i == 6) {%item.Beacon = %numPack;}
			else if(%i == 7) {%item.BoomAmmo = %numPack;}
			else if(%i == 8) {%item.RocketAmmo = %numPack;} 
			else if(%i == 9) {%item.RifleAmmo = %numPack;}
			else if(%i == 10) {%item.SilencerAmmo = %numPack;}
			else {%item.MineAmmo = %numPack;}
		}
	}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 11 ; %i = %i +1)
	{
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0) {%numAdd = %item.BulletAmmo;}
		else if(%i == 1) {%numAdd = %item.PlasmaAmmo;}
		else if(%i == 2) {%numAdd = %item.DiscAmmo;}
		else if(%i == 3) {%numAdd = %item.GrenadeAmmo;}
		else if(%i == 4) {%numAdd = %item.Grenade;}
		else if(%i == 5) {%numAdd = %item.MortarAmmo;}
		else if(%i == 6) {%numAdd = %item.Beacon;}
		else if(%i == 7) {%numAdd = %item.BoomAmmo;}
		else if(%i == 8) {%numAdd = %item.RocketAmmo;}
		else if(%i == 9) {%numAdd = %item.RifleAmmo;}
		else if(%i == 10) {%numAdd = %item.SilencerAmmo;}
		else {%numAdd = %item.MineAmmo;}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%player);

	for(%i = 0; %i < 11 ; %i = %i +1)
	{
		%item = $AmmoPackItems[%i];
		if ($ItemMax[%armor, %item] > 0)
		{
			%maxnum = $AmmoPackMax[%item];
			%maxnum = checkResources(%player,%item,%maxnum);
		}
		else
			%maxnum = 0;

		if(%maxnum)
		{
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}
	}
}

//========================Demolition kit

ItemImageData StrikePackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
    	minEnergy = 0;
	maxEnergy = 0;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
};

ItemData StrikePack
{
	description = "Demolition Kit";
	shapeFile = "armorPack";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = StrikePackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StrikePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == DemoGun)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function StrikePack::onUse(%player,%item)
{
	%client = player::getclient(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else if (Player::getMountedItem(%player,$WeaponSlot) != DemoGun)
	{
		Player::mountItem(%player,DemoGun,$WeaponSlot);
	}
	else
	{
		for(%i = 0; %i < 10; %i++)
		{
			if ($demomine::var[%client, %i] !="")
			{
				centerprint(%client, "                                <Bitem_damaged.bmp> <f1>B<f1>a<f0>B<f2>o<f2>O<f1>M <f0>b<f1>A<f0>B<f1>Y<f0><Bitem_damaged.bmp>", 1);
				%obj = $demomine::var[%client, %i];
				schedule("GameBase::applyRadiusDamage("@$MineDamageType@", getBoxCenter("@%obj@"), 20, 1, 305, "@%client@");", %i/2);
				schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", %i/2);
				$demomine::var[%client, %i]="";
				playSound(SoundTAT,gamebase::getposition(%player));
				playSound(SoundTAT,gamebase::getposition(%obj));
				%boom=1;
			}
		}
	}
	if (!%boom)
	{
		centerprint(%client, "<jc><f2>Using Demolition Trigger: fire to lay charges, activate the pack again to detonate.", 3);
		systemMessage(%client,0,"~waccess_denied.wav");
	}
}
function StrikePack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == DemoGun)
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

//========================BattlePack

ItemImageData BattlePackImage
{
	shapeFile = "plasmabolt";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.5;
};

ItemData BattlePack
{
	description = "BattlePack";
	shapeFile = "plasmabolt";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = BattlePackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 400;
	hudIcon = "energyRifle";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BattlePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		%client = Player::getClient(%player);
		systemMessage(%client,0,"You don your Battle Gear. ~wflyer_mount.wav");
		playSound(SoundFlagReturned,gamebase::getposition(%player));
		centerprint(%client, "                   <Bflag_atbase.bmp> For The Defense Of Your Countrymen! <Bflag_atbase.bmp>");
		Player::unMountItem(%player,4);
		Player::unMountItem(%player,5);
		Player::setArmor(%player, jarmor);
		Player::decItemCount(%player,%item);
	}
}

//========================Cloacking Device

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 10;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CloakingDevice
{
	description = "Cloaking Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CloakingDeviceimage;
	price = 600;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if ((%armor != "aarmor") && (%armor != "afemale"))
	{
		GameBase::startFadeout(%player);
		cloakfix(%player);
		systemMessage(Player::getClient(%player),0,"Cloaking Device On");
		%rate = Player::getSensorSupression(%player) + 5;
		Player::setSensorSupression(%player,%rate);
	}
	else
	{
		%obj = newObject("","Mine","CloakBlast");
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 3.5";
		%pos = Vector::add(GameBase::getPosition(%player), %padd);
		GameBase::setPosition(%obj, %pos);
		Player::trigger(%player,$BackpackSlot,false);
	}
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{

	%armor = Player::getArmor(%player);

	 if ((%armor != "aarmor") && (%armor != "afemale"))
	 {
		GameBase::startFadein(%player);
		systemMessage(Player::getClient(%player),0,"Cloaking Device Off");
                %player.fixpackoff = true;
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,%rate);
		Player::trigger(%player,$BackpackSlot,false);
	 }
	 else
		Player::trigger(%player,%imageslot,false);

}
function CloakingDevice::onMount(%player,%item) 
{	
	%armor = Player::getArmor(%player);
	if (%armor == "aarmor" || %armor == "afemale")
	{
		Bottomprint(Player::getClient(%player), "Stealth Armor uses the Cloaking Pack to release a Cloak Blast.");
	}
}
function cloakfix(%clientid)
{
	if(%clientid.fixpackoff)
	{
		%clientid.fixpackoff = false;
		return;
	}
	%Set = newObject("Cloakset" @ %clientid,SimSet);
	%Mask = $SimPlayerObjectType;
	containerBoxFillSet(%Set, %Mask, gamebase::getposition(%clientid), 70, 70, 70, 0);
	%num = Group::objectCount(%Set);
	for(%i = 0; %i < %num; %i++)
	{
		%object = group::getobject(%Set, %i);
		if(gamebase::getteam(%object) != gamebase::getteam(%clientid))
		{
			Player::setDetectParameters(%object, 50);
			schedule("revert(" @ %object @ ");", 1);
		}
	}
	deleteobject(%Set);
	schedule("cloakfix(" @ %clientid @ ");", 1);
}

function revert(%playerid)
{
	Player::setDetectParameters(%playerid, 0.027, 0);
}

//========================Command LapTop
ItemImageData LaptopImage
{
	shapeFile = "grenammo";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, 0.1, 0 };
	mountRotation = { 1.57, 0, 0 };
	sfxFire = SoundRecon;
	minEnergy = 1;
 	maxEnergy = 10;
	firstPerson = false;
	mass = 1.0;
};

ItemData Laptop
{
	description = "Command Laptop";
	shapeFile = "panel_set";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LaptopImage;
	price = 650;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function Laptop::onMount(%player,%item)
{
	%armor = Player::getArmor(%player);
	%client = Player::getClient(%player);
	%client.Laptop = "False";
	schedule ("LapTopImage::check(" @ %player @ ");",2);
	if (%armor == sarmor || %armor == sfemale)
	{
		bottomprint(%client, "Recon's LapTop: Activate for long distance recon.", 4);
	}
	else 	bottomprint(%client, "Spy's LapTop: Intercepts enemy chat. Activate to Touch-Hack turrets.", 4);
	schedule("bottomprint(" @ %client @ ", \"LapTop: All Armors: Allows remote use of Command Stations.\", 4);", 0);
}

function LaptopImage::onActivate(%player, %imageSlot)
{
	%armor = Player::getArmor(%player);
	%client = Player::getClient(%player);
	if (%armor == sarmor || %armor == sfemale)
	{
		systemMessage(%client,0,"Recon: Long distance for major strategic items.~wsensor_deploy.wav");
	}
	else  systemMessage(%client,0,"Spy: Turret Touch-Hack enabled.~wsensor_deploy.wav");
	%client.Laptop = "True";
	schedule ("LapTopImage::check(" @ %player @ ");",1);
}

function LaptopImage::onDeactivate(%player,%imageSlot)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	if (%armor == sarmor || %armor == sfemale)
	{
		systemMessage(%client,0,"Recon: Local for all enemy items.");
	}
	else  systemMessage(%client,0,"Spy: Intercepting enemy chat.");
	Player::trigger(%player,$BackpackSlot,false);
	%client.hacking = "false";
	%client.Laptop = "False";
	schedule ("LapTopImage::check(" @ %player @ ");",1);
}

//========================Nuclear Containment and Suicide Pack
ItemImageData FgcPackImage
{
	shapeFile = "liqcyl";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mass = 3.0;
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData FgcPack
{
	description = "Nuclear Pack";
	shapeFile = "liqcyl";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FgcPackImage;
	price = 1150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FgcPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else if (Player::getArmor(%player) == "barmor" || Player::getArmor(%player) == "bfemale")
	{
		Player::deployItem(%player,%item);
	}
	else if (Player::getArmor(%player) == "harmor")
	{
		%team = GameBase::getTeam(%player);
		Player::mountItem(%player,Mfgl,$WeaponSlot);
	}
}

function FgcPack::onMount(%player,%item)
{
	%armor = Player::getArmor(%player);
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	bottomprint(%client, "<jc>Your team has " @ 0 - $TeamItemCount[%team @ "MfglAmmo"] @ " Nuclear Warheads available for use.");
	if (%team.nukgen == "") bottomprint(%client,"<jc>Your team has no nuclear capability.  Goliath needs to deploy the Nuclear Pack as a Nuclear Generator.");
	else if ($TeamItemCount[%team @ "MfglAmmo"] == "0") bottomprint(%client,"<jc>Wait... Nuclear Generator is building warheads.");
	if(%armor == "harmor") bottomprint(%client,"<jc>Activate this Nuclear Containment Pack to ready your Tactical Launcher.");
}

function FgcPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Mfgl)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function FgcPack::onDeploy(%player,%item,%pos)
{
	FgcPack::deployShape(%player,%item);
}

function FgcPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	%client = Player::getClient(%player);
	if ($TeamItemCount[%team @ "NukGen"] <1) %object = ( deployable(%player,"NukGen","StaticShape","Nuke Generator", True, False, False, False, False, True, 3, True, 0, False, "CargoBarrel", "NukGen") );
	if($TeamItemCount[%team @ "MfglAmmo"] < $TeamItemMax["MfglAmmo"])
	{
		Player::unmountItem(%player,$BackpackSlot);
		%object = newObject("","Mine","Suicidebomb2");
		addToSet("MissionCleanup", %object);
		%object.deployer = %client;
		GameBase::throw(%object,%player,5 * %client.throwStrength,false);
		systemMessage(%client,1,"Nuclear Pack will destruct in 20 seconds");
		$TeamItemCount[%team @ "MfglAmmo"]++;
		Player::decItemCount(%player,%item);
		if (Client::getGender(%client) == "Female") TeamMessages(3, GameBase::getTeam(%player), Client::getName(%client) @ ": She's gonna explode!~wfemale5.wtakcovr.wav");
		else TeamMessages(3, GameBase::getTeam(%player), Client::getName(%client) @ ": She's gonna explode!~wmale4.wtakcovr.wav");
	}
	else if (%object)
	{
		%name = Client::getName(%client);
		Player::trigger(%player,$BackpackSlot,false);
		Player::unmountItem(%player,$BackpackSlot);

		%beam = newObject("Nuke Generator","StaticShape",PortGenerator,true);
     		addToSet("MissionCleanup", %beam);
		GameBase::setTeam(%beam,%team);
		GameBase::setPosition(%beam,Vector::add($los::position, "0 0 1") );
		GameBase::setRotation(%beam,gamebase::getrotation(%player));
		Gamebase::setMapName(%beam,"Nuke Generator " @ %name);

		%object.beam = %beam;
		echo("MSG: ",Client::getName(%client)," established a NukGen.");
		if (Client::getGender(%client) == "Female") TeamMessages(3, $Wasteland::DetPackLimit/60, %name @ " established a Nuclear Generator! Nuclear warhead available in " @ %time @ " minutes!~wfemale2.wwait1.wav");
		else TeamMessages(3, %team, %name @ " established a Nuclear Generator! Nuclear warhead available in " @ $Wasteland::DetPackLimit/60 @ " minutes!~wmale2.wwait1.wav");
		if (%team == 0) %eteam = 1;
		else %eteam = 0;
		if (%eteam.smrtpck)
		{
			%eclient=%eteam.smrtpck;
			%opos = GameBase::getPosition(%player);
			%posX = getWord(%opos,0);
			%posY = getWord(%opos,1);
			TeamMessages(1, %eteam, "Vigil: " @ %name @ " established a Nuclear Generator!~wfemale1.wbasundr.wav");
		teamwaypointer(%eclient, %eteam, "NukeGen at WayPoint", %posX, %posY);
		}
		%team.nukgen = "true";
		schedule ("CargoBarrel::check(" @ %object @ ");",$Wasteland::DetPackLimit);
		Player::decItemCount(%player,%item);
		bottomprint(%client,"<jc>Team Technology Bonus: 5 points");
		%client.score = (%client.score +5);
	}
	else if ($TeamItemCount[%team @ "NukGen"] < $TeamItemMax["NukGen"])
	{
		bottomprint(%client,"<jc>You can deploy this Nuclear Pack on the ground as a Nuclear Generator, and it will make Nuclear Warheads.");
		systemMessage(%client,1,"Out of Nuclear Warheads.~wfemale1.woops.wav");
	}
	else if ($TeamItemCount[%team @ "NukGen"] > 0 && %team.nukgen == "")
	{
		bottomprint(%client,"<jc>Your team's Nuclear Generator has been destroyed.");
		systemMessage(%client,1,"Out of Nuclear Warheads.~wfemale1.wcolor7.wav");
	}
	else 	if (%team.nukgen != "")
	{
		bottomprint(%client,"<jc>Wait... Nuclear Generator is building warheads.");
		systemMessage(%client,1,"Out of Nuclear Warheads.~wfemale2.wwait1.wav");
	}
	else
	{
		systemMessage(%client,1,"Out of Nuclear Warheads.~wfemale1.woops.wav");
	}
}
//========================Energy Pack
ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;

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
	validateShape = true;
	validateMaterials = true;
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

//========================Flight Pack

ItemImageData FlightPackImage
{
	shapeFile = "mortarpack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = -2;
 	maxEnergy = -6;
	firstPerson = false;
};

ItemData FlightPack
{
	description = "Flight Pack";
	shapeFile = "mortarpack";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = FlightPackImage;
	price = 350;
	hudIcon = "FlightPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlightPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FlightPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FlightPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle)
		Player::unmountItem(%player,$WeaponSlot);
}

//========================Interceptor Pack

ItemImageData MechPackImage
{
	shapeFile = "logo";
	mountPoint = 2;
    	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MechPack
{
	description = "Interceptor Pack";
	shapeFile = "logo";
	className = "Backpack";
   	heading = "sPersonnel Movers";
	imageType = MechPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function MechPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function MechPack::onDeploy(%player,%item,%pos)
{
	if (MechPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function MechPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"] < $TeamItemMax[ScoutVehicle] && $TeamItemCount[GameBase::getTeam(%player) @ "MechPack"] < $TeamItemMax[MechPack])
	{
		%rot = GameBase::getRotation(%player);
		%fField = newObject("",flier,Scout,true);
		addToSet("MissionCleanup", %fField);
		GameBase::setTeam(%fField,Client::getTeam(%client));
		GameBase::setPosition(%fField,gamebase::getposition(%player));
		GameBase::setRotation(%fField,%rot);
		systemMessage(%client,0,"Piloting Scout");
		GameBase::startFadeIn(%fField);
		playSound(SoundPickupBackpack,gamebase::getposition(%player));
		$TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++;
		return true;
	}
	else systemMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//========================Inveigler
ItemImageData InveiglerPackImage
{	shapeFile = "logo";
	mountPoint = 2;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, -0.1, 0 };
	firstPerson = false;
};

ItemData InveiglerPack
{	description = "Inveigler";
	shapeFile = "logo";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = InveiglerPackImage;
	price = 400;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$CanControl[Inveigler] = 1;
$EmbedController[Inveigler] = 1;

function InveiglerPack::onUse(%player,%item)
{	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function InveiglerPack::onDeploy(%player,%item,%pos)
{	if(DeployInveigler(%player,%item,Inveigler,flier,Inveigler)) 
		if(!Player::isDead(%player)) 
			Player::decItemCount(%player,%item);
}

function DeployInveigler(%player,%item,%shape,%data,%name)
{	%client = Player::getClient(%player);
	if(GameBase::getLOSInfo(%player,3))
	{	if(Vector::dot($los::normal,"0 0 1") > 0.7)
		{	%rot = GameBase::getRotation(%player);
			%obj = newObject(%name,%data,%shape,true);
			if($TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"] >= $TeamItemMax[%item])
			{	centerprint(%client,"<jc>Maximum number of Inveiglers summoned.");
				deleteObject(%obj);
				return;
			}
			addToSet("MissionCleanup",%obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			GameBase::setPosition(%obj,$los::position);
			GameBase::setRotation(%obj,%rot);
			Gamebase::setMapName(%obj,%name);
			systemMessage(%client,0,"Inveigler summoned ");
			GameBase::startFadeIn(%obj);
			playSound(SoundPickupBackpack,$los::position);
			Client::setControlObject(%client,%obj);
			%player.vehicle = %obj;
			$TeamItemCount[GameBase::getTeam(%player) @ %name@"Pack"]++;
			return true;
		}
		else systemMessage(%client,0,"Can only summon to flat surfaces");
	}
	else systemMessage(%client,0,"Summon position out of range");
	return false;
}

//========================Regeneration Pack

ItemImageData LeechPackImage
{
	shapeFile = "mortartrail";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 8;
	maxEnergy = 14;
	sfxFire = SoundElevatorBlocked;
	projectileType = DrainBolt;
	mass = 1.0;
};

ItemData LeechPack
{
	description = "Leech Pack";
	shapeFile = "mortartrail";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LeechPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LeechPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Regen)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function LeechPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::mountItem(%player,Regen,$WeaponSlot);
 		%client = GameBase::getOwnerClient(%player);
		systemMessage(Player::getClient(%player), 0,"Ready to leech enemy health and power.");
	}
}

function LeechPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == Regen)
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

//========================Repair Pack

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
    	minEnergy = 0;
	maxEnergy = 0;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
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
	validateShape = true;
	validateMaterials = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun)
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

ItemImageData SMMLImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { -0.2, -0.4, 0.4 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	accuFire = false;
	reloadTime = 0.8;
	fireTime = 1.0;
	minEnergy = 5;
	maxEnergy = 6;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundPickUpWeapon;
	mass = 1.0;
};

ItemData SMML
{
	description = "SM-Missle Launcher";
	shapeFile = "grenadeL";
	className = "Weapon";
    	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SMMLImage;
	price = 350;
	hudIcon = "mortar";
	showWeaponBar = true;
};

function SMMLImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	if(%player.load != "")
	{
		%trans = GameBase::getMuzzleTransform(%player);
		$Faky = %player;
		$Faky2 = Gamebase::getPosition(%player);
		Player::trigger(%player,0,false);
		Projectile::spawnProjectile("Faker",%trans,%player,"0 0 0");
	}
	else systemMessage(%client,0,"Missile Tube is not loaded.~wPku_ammo.wav");
	Player::trigger(%player,0,false);
}
function SMML::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	if(%player.load != "") systemMessage(%client,0,"SMML is loaded with a " @ (%player.load).description @ ".");
	else
	{
		%c = Player::getMountedItem(%player, $BackpackSlot);
		if (%c.heading == "uGuided Missiles")
		{
			%vm = $vm[%c];
			if (%vm == "BallProj") systemMessage(%client,0,"You cannot load yourself into your own tube.~wmale5.wdsgst1.wav");
			else if (%vm == "BooProj")
			{
				systemMessage(%client,0,"Missile tube cannot safely hold a nuclear missile.~wAccess_Denied.wav");
				Player::unMountItem(%client,$BackpackSlot);
				Player::setItemCount(%player, %c, 0);
				$TeamItemCount[GameBase::getTeam(%player) @ %c]++;
				%obj = newObject("","Mine","EMPBlast");
				GameBase::throw(%obj,%player,0,true);
			}
			else
			{
				$TeamItemCount[GameBase::getTeam(%player) @ %c]++;
				%player.load = %vm;
				Player::unMountItem(%client,$BackpackSlot);
				Player::setItemCount(%player, %c, 0);
				systemMessage(%client,0,"SMML has been loaded with a " @ %vm.description @ ".");
				playSound(SoundMortaReload,GameBase::getPosition(%player));
			}
		}
		else systemMessage(%client,0,"You have no missile to load into your SMML.");
	}
}
//=========================JawPack
ItemImageData JawPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 13;
	sfxFire = SoundJAW;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
};

function JawPackImage::onActivate(%player,%imageSlot)
{
	%client = GameBase::getOwnerClient(%player);
	systemMessage(%client,0,"Rocket Lock On");
	%client.rocket = 1;
}

function JawPackImage::onDeactivate(%player,%imageSlot)
{
	%client = GameBase::getOwnerClient(%player);
	systemMessage(%client,0,"Rocket Lock Off");
	%client.rocket = 0;
	Player::trigger(%player,$BackpackSlot,false);
}
ItemData JawPack
{
	description = "Rocket-Lock Pack";
	shapeFile = "ammopack";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	hudIcon = "ammopack";
	imageType = JawPackImage;
	price = 200;
	showWeaponBar = true;
	hiliteOnActive = true;
};

//========================Sabotage Pack

ItemImageData SabotageImage
{
	shapeFile = "mortarammo";
	mountPoint = 2;
	weaponType = 2;
    	minEnergy = 0;
	maxEnergy = 0;
	mountOffset = { 0, -0.2, 0.1 };
	mountRotation = { 0, 1.57, 1.57 };
	firstPerson = false;
	mass = 1.0;
};

ItemData Sabotage
{
	description = "Saboteur Kit";
	shapeFile = "jetPack";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SabotageImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Sabotage::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == SabGun)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function Sabotage::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::mountItem(%player,SabGun,$WeaponSlot);
	}
}

function Sabotage::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == SabGun)
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

//========================Sensor Jammer
ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
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
	validateShape = true;
	validateMaterials = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	systemMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	systemMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//========================Shield Pack

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 4;
	maxEnergy = 9;
	sfxFire = SoundShieldOn;
	firstPerson = false;
	mass = 1.0;
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
	validateShape = true;
	validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	systemMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.022;
	%player.shieldon = true;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	systemMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
	%player.shieldon = false;
}

//===============New Spawn Point
$TeamItemMax[SpawnPack] = 1;
ItemImageData SpawnPackImage
{
	shapeFile = "dirArrows";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.2 };
  	mountRotation = { 0, 0, -1.57 };
	weaponType = 2;
	minEnergy = 12;
	maxEnergy = 12;
	sfxFire = SoundDiscSpin;
	firstPerson = false;
	mass = 1.0;
};

ItemData SpawnPack
{
	description = "Spawn Point Pack";
	shapeFile = "endarrow";
	className = "Backpack";
	heading = "cBackPacks";
	shadowDetailMask = 4;
	elasticity = 0.2;
	imageType = SpawnPackImage;
	showInventory = True;
	shadowDetailMask = 4;
	mapIcon = "M_camera";
	price = 900;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpawnPackImage::onActivate(%player,%imageSlot)
{
	%object = ( deployable(%player, SpawnPack, "StaticShape", "Deployable Spawn Point", True, False, False, False, True, True, 5, True, 0, False, SpwnMkr, "SpawnPack") );
	%team = GameBase::getTeam(%player);
	%client = Player::getClient(%player);
	%name = Client::getName(%client);
	%buyarmor = Client::getGender(%client); 
	if (%object)
	{
		Player::trigger(%player,$BackpackSlot,false);
		Player::decItemCount(%player,"SpawnPack");
		if (%team == 0) %eteam = 1;
		else %eteam = 0;
		if (%eteam.smrtpck)
		{
			%eclient=%eteam.smrtpck;
			%opos = GameBase::getPosition(%player);
			%posX = getWord(%opos,0);
			%posY = getWord(%opos,1);
			TeamMessages(1, %eteam, "Vigil: " @ %name @ " established a Deployable Spawn Point!~wfemale1.wbasundr.wav");
			teamwaypointer(%eclient, %eteam, "Enemy Spawn at WayPoint", %posX, %posY);
		}
		if (%buyarmor == "Female") TeamMessages(3, %team, %name @ " established a deployable Spawn Point!~wfemale2.wproceed.wav");
		else TeamMessages(3, %team, %name @ " established a deployable Spawn Point!~wmale2.wproceed.wav");
		%team.newspawn = %object;
	}
	else if ($TeamItemCount[%team @ "SpawnPack"] < $TeamItemMax["SpawnPack"] && %team.newspawn == "")
	{
		%team.newspawn = %player;
		if (%buyarmor == "Female") TeamMessages(3, %team, %name @ " is commanding a spawn point!~wfemale2.wovrhere.wav");
		else TeamMessages(3, %team, %name @ " is commanding a spawn point!~wmale2.wovrhere.wav");
	}
	else
	{
		Player::trigger(%player,$BackpackSlot,false);
	}
}

function SpawnPackImage::onDeactivate(%player,%imageSlot)
{
	%team = GameBase::getTeam(%player);
	if (getObjectType(%team.newspawn) == "Player") %team.newspawn = "";
	systemMessage(Player::getClient(%player),0,"Spawn Pack inactive.");
	Player::trigger(%player,$BackpackSlot,false);
}

//========================Stealth Shield

ItemImageData StealthShieldPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 6;
	maxEnergy = 9;
	sfxFire = SoundShieldOn;
	firstPerson = false;
	mass = 1.0;
};

ItemData StealthShieldPack
{
	description = "StealthShield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = StealthShieldPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StealthShieldPackImage::onActivate(%player,%imageSlot)
{
	if (%player == "-1" || !%player)return;
	systemMessage(Player::getClient(%player),0,"StealthShield On");
	%player.shieldStrength = 0.012;
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function StealthShieldPackImage::onDeactivate(%player,%imageSlot)
{
	if (%player == "-1" || !%player)return;
	systemMessage(Player::getClient(%player),0,"StealthShield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
}

//========================Teleport Pack
ItemImageData LightningPackImage
{
	shapeFile = "fusionbolt";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 10;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, 0.2, 0 };
	firstPerson = false;
	mass = 1.0;
};

ItemData LightningPack
{
	description = "Teleport Pack";
	shapeFile = "fusionbolt";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = LightningPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LightningPackImage::onActivate(%player,%imageSlot)
{
	systemMessage(Player::getClient(%player),0,"~wdiscreload.wav");
	%spawnMarker = GameBase::getPosition(%player);

	Player::trigger(%player,$BackpackSlot,false);
	%clientId = (client::getownedobject(%player));
	%client = Player::getClient(%player);
	%rnd = floor(getRandom() * 100);
	%teleset = nameToID("MissionCleanup/TeleJammer");
	%pteam = Gamebase::getTeam(%player);


	if (!GameBase::isActive(%client.telebeacon) && %client.telebeacon)
	{
		bottomprint(%client, "<jc><f2>Setting TeleBeacon.", 3);
		%client.telepoint = "";
		%client.telebeacon = "";
	}

	%ppos = (gamebase::getposition(%player));
	%distance = Vector::getDistance(%ppos, %client.telepoint);

	if (%client.telepoint && %distance > 350)
	{
		bottomprint(%client, "<jc><f2>To far from TeleBeacon, can not teleport. 350m Range.", 3);
		systemMessage(Player::getClient(%player),0,"~wfemale2.wtgtout.wav");
		return;
	}

	if (%client.telepoint)
	{
		%spawnMarker = %client.telepoint;

		%xPos = getWord(%spawnMarker, 0);
		%yPos = getword(%spawnMarker, 1);
		%zPos = getWord(%spawnMarker, 2);

		%o = %xPos @ "  " @ %yPos @ "  " @ %zPos;
		systemMessage(Player::getClient(%player),0,"~wshieldhit.wav");

		if (Player::getMountedItem(%client,$FlagSlot)== "flag")
		{
			%rnd = floor(getRandom() * 100);
			if (%rnd > 50)
			{
				%flag = (Player::getMountedItem(%client, $FlagSlot));
				Player::dropItem(%client, %flag);
				bottomprint(%client, "<jc><f2>Teleport malfunction, the flag was dropped...", 2);
				systemMessage(Player::getClient(%player),0,"~wfemale2.wgeteflg.wav");
			}
		}

		GameBase::SetPosition(%player, %o);
		Player::trigger(%player,$BackpackSlot,false);
		return;
	}
	else if (!%client.telepoint)
	{
		telebeacon(%client);
		return;
	}
}

function LightningPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//========================Warp Pack
ItemImageData WarpPackImage
{
	shapeFile = "fusionbolt";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 0;
  	mountOffset = { 0, 0.2, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
};
ItemData WarpPack
{
	description = "Warp Pack";
	shapeFile = "fusionbolt";
	className = "Backpack";
    	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = WarpPackImage;
	price = 275;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function WarpPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::trigger(%player,$BackpackSlot,true);
}

function WarpPackImage::onActivate(%player,%imageSlot)
{
	%client = (Player::getClient(%player));
	%energyLevel = GameBase::getEnergy(%player);
      %wpf = %client.warpf;
	%wpv = %client.warpv;
	if( %wpf == "" ) 
         %wpf = 10;
      if( %wpv == "" ) 
         %wpv = 0;	
	%basevec = "0 " @ %wpf @ " 0";
	%elevvec = "0 0 " @ %wpv;
	%rnd = floor(getRandom() * 100);
	%dgr = (%wpf + %wpv);
	systemMessage(Player::getClient(%player),0,"WARP HAZARD: Attempting settings x" @ %wpf @"m z" @ %wpv @"m.");
	%newplayerposa = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( %basevec, GameBase::getRotation(%player) ) );
	%newplayerpos = Vector::add(%newplayerposa,%elevvec);
	if (Player::getMountedItem(%client,$FlagSlot)== "flag")
	{
		if ( (%rnd + %dgr) >85 )
		{
			%flag = (Player::getMountedItem(%client, $FlagSlot));
			Player::dropItem(%client, %flag);
			systemMessage(Player::getClient(%player),1,"Warp Malfunction: Flag Dropped!");
		}
	}
	if (Player::getMountedItem(%client,$FlagSlot)!= "flag")
	{
		if (%rnd < %dgr)
		{
			%weaponType = (Player::getMountedItem(%client, $WeaponSlot));
			Player::dropItem(%client, %weaponType);
			systemMessage(Player::getClient(%player),1,"Warp Malfunction: Weapon Dropped!");
		}
		if ( (%rnd + 10) < %dgr)
		{
			%bkpk = (Player::getMountedItem(%client, $BackpackSlot));
			Player::dropItem(%client, %bkpk);
			systemMessage(Player::getClient(%player),1,"Warp Malfunction: Pack Dropped!");
		}
		if ( (%rnd < 21) && (%rnd > 18) )
		{
			%armor = Player::getArmor(%player);
			if (%armor == "aarmor")
			{
				Player::setArmor(%player,sarmor);
			}
			else if (%armor == "afemale")
			{
				Player::setArmor(%player, sfemale);
			}			
			systemMessage(Player::getClient(%player),1,"Warp Malfunction: Armor Morphed!~wflyer_mount.wav");
		}
	}
	if (%energyLevel > 80)
	{
		// PORT FIX: the warp never looked at where it was sending you. Ten metres forward while
		// facing even a gentle slope is a point just under the ground, and from there the player
		// fell out of the bottom of the world for good. If the first thing straight above the
		// target is the terrain itself, the target is buried: come out on the surface instead.
		// Warping through a wall into a room still works -- there the ray meets a ceiling first.
		if (GetLosInfo(Vector::add(%newplayerpos, "0 0 0.5"), Vector::add(%newplayerpos, "0 0 2000"), 1) == "True")
		{
			if ($los::object == -1 || getObjectType($los::object) == "SimTerrain")
				%newplayerpos = Vector::add($los::position, "0 0 0.5");
		}
		GameBase::setPosition(%player,%newplayerpos);
		systemMessage(Player::getClient(%player),0,"~wteleport2.wav");
	}
	if ( (%energyLevel < 80) || (%energyLevel == 80) )
	{
		systemMessage(Player::getClient(%player),1,"Failed: insufficient energy.~wSniper2.wav");
	}
	if (%rnd > 98)
	{
		%clientId = Player::getClient(%player);
		systemMessage(Player::getClient(%player),1,"Warp Malfunction: Fatal Interference!");
		GameBase::applyDamage(%player, $EnergyDamageType, 3, 1.0,1.0, 1.0, %player);
		remoteKill(%clientId);
	}
	%enew = (%energyLevel - 79);
	GameBase::setEnergy(%player, %enew);
	Player::trigger(%player,$BackpackSlot,false);
}

//========================Zepplin Ballon
ItemImageData Balloon1Image
{
	shapeFile = "Cactus2";
	mountPoint = 3;
	mountOffset = { 0.1, -0.5, 2};
	mountRotation = { 0, 0, 0 };
	accuFire = true;
};

ItemData Balloon1
{
	description = "Balloon";
	shapeFile = "Cactus2";
   	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = Balloon1Image;
	price = 0;
	hudIcon = "mortar";
	showWeaponBar = true;
	hiliteOnActive = true;
	showInventory = false;
 	className = "Tool";
};

function Balloon1Image::onActivate(%player,%imageSlot){}
function Balloon1Image::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData BalloonPackImage
{
	shapeFile = "mineammo";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, 0.1, 0 };
	mountRotation = { 1.57, 0, 0 };
	sfxFire = SoundWindDgust;
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};
ItemData BalloonPack
{
	description = "Zepplin";
	shapeFile = "mineammo";
	className = "Backpack";
   	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = BalloonPackImage;
	price = 650;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function BalloonPack::onMount(%player,%item) 
{	
	%client = Player::getClient(%player);
	if (!%client.zepop)
	{
		schedule("bottomprint(" @ %client @ ", \"<jc><f2>You've been equipped with a Zepplin Pack...\", 3);", 0);
		schedule("bottomprint(" @ %client @ ", \"<jc><f2>To set its options, hit 'Tab' to see the Options Menu...\", 3);", 3);
		schedule("bottomprint(" @ %client @ ", \"<jc><f2>...then select 'Weapon Options' followed by 'Zepplin Options'\", 3);", 6);
		schedule("bottomprint(" @ %client @ ", \"<jc><f2>Hit 'P' when ready to deploy your Zepplin!\", 3);", 9);
	}
	if (%client.oldpack != "" && %client.oldpack != "-1" && %client.zepop == 80) Bottomprint(%client, "This Rapid-Rise Zepplin Pack is worn in addition to one " @ %client.oldpack);
	if (%client.oldpack != "" && %client.oldpack != "-1" && %client.zepop == 20) Bottomprint(%client, "This Slow Rise Zepplin is worn in addition to one " @ %client.oldpack);
	if (%client.oldpack != "" && %client.oldpack != "-1" && %client.zepop == 10) Bottomprint(%client, "This Hovering Zepplin is worn in addition to one " @ %client.oldpack);
	if (%client.oldpack != "" && %client.oldpack != "-1" && %client.zepop == -70) Bottomprint(%client, "This Parachute Zepplin is worn in addition to one " @ %client.oldpack);
}

function BalloonPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	if (!%client.zepop)
	{
		systemMessage(%client,1,"See Weapon Options To Set Zepplin Options~wfemale1.woops.wav");
		schedule("bottomprint(" @ %client @ ", \"<jc><f2>To set Your Zepplin Pack options, hit 'Tab' to see the Options Menu...\", 3);", 0);
		schedule("bottomprint(" @ %client @ ", \"<jc><f2>...then select 'Item Options' followed by 'Zepplin Options'\", 3);", 3);
		schedule("bottomprint(" @ %client @ ", \"<jc><f2>Hit 'P' when ready to deploy your Zepplin!\", 3);", 6);
		Player::trigger(%player,$BackpackSlot,false);
	}
	else
	{
		if (%client.zepop == -70) systemMessage(%client,0,"Your pull your rip cord...~wflagflap.wav");
		else systemMessage(%client,0,"Hang on...~wwind1.wav");
		schedule ("Player::mountItem( " @ %client @ ", Balloon1,4);",0.3);
		schedule ("BalloonPackImage::check(" @ %player @ ");",1);
		%client.BalloonPack = "True";
	}
}

function BalloonPackImage::onDeactivate(%player,%imageSlot)
{
	%client = Player::getClient(%player);
	if (!%client.zepop) return;
	else if (%client.zepop == -70) 	systemMessage(%client,0,"Your chute folds and you release your risers.~wflyer_mount.wav");
	else systemMessage(%client,0,"You popped your Zepplin.~wdebris_small.wav");
	Player::trigger(%player,$BackpackSlot,false);
	%client.BalloonPack = "False";
	if (!Player::isDead(%player))
	{
		Player::unMountItem(%client,$BackpackSlot);
		Player::decItemCount(%player,BalloonPack);
		Player::unMountItem(%client,4);
		%oldpack = %client.oldpack;
		if (%oldpack != "BalloonPack" && %oldpack != "" && %oldpack != "False")
		{
			Player::mountItem(%client,%client.oldpack,$BackpackSlot);
			Player::incItemCount(%client, %client.oldpack,1);
		}
		if (Player::getArmor(%client) == "marmor" || Player::getArmor(%client) == "mfemale")
		{
			Player::setItemCount	(%client, Booster1Pack,1);
			Player::setItemCount	(%client, Booster2Pack,1);
			schedule ("Player::mountItem( " @ %client @ ", Booster1Pack,4);",0.5);
			schedule ("Player::mountItem( " @ %client @ ", Booster2Pack,5);",0.5);
		}
	}
}

function BalloonPackImage::check(%player)
{
	%client = Player::getClient(%player);
	if (%client.BalloonPack == "True")
	{
		%oldvel = Item::getVelocity(%player);
		%velX = getWord(%oldvel,0);
		%velY = getWord(%oldvel,1);
		%velZ = getWord(%oldvel,2);
		%nvelZ = %client.zepop;
		if (%nvelZ == "" || %nvelZ == "-1") %nvelZ = 20;

		if (%velZ < -90 && %nvelZ != -70)
		{
			
			systemMessage(%client = Player::getClient(%player),0,"You are falling way too fast, and your zepplin tears under the strain...~wBXplo1.wav");
			Player::trigger(%player,$BackpackSlot,false);
			%client.BalloonPack = "False";
		}
		else if (%velZ > -70 && %nvelZ == -70)
		{
			
			systemMessage(%client = Player::getClient(%player),0,"You are not falling fast enough to fill your chute...");
			Player::trigger(%player,$BackpackSlot,false);
			%client.BalloonPack = "False";
		}
		else
		{
			if (%velZ < 80)
			{
				%newvel = %velX @ " " @ %velY @ " " @ %nvelZ;
				Item::setVelocity(%player, %newvel);
				schedule ("BalloonPackImage::check(" @ %player @ ");",1);
			}
			else {}
		}
	}
	else {}
	return;
}

//========================
// Turrets d
//========================
//===
//========================Anti-Aircraft Turret
ItemImageData BarragePackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.5;
};

ItemData BarragePack
{
	description = "Anti-Aircraft Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    	heading = "dTurrets";
	imageType = BarragePackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1250;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BarragePack::onUse(%player,%item)
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

function BarragePack::onDeploy(%player,%item,%pos)
{
	if (BarragePack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BarragePack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Anti-AirCraft Turret",True,True,True,True,True,True,4,True,100, True, "BarrageTurret", "BarragePack");
}

//========================Anti-Grav Turret

ItemImageData AGravImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
};

ItemData AGravPack
{
	description = "Anti-Grav Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dTurrets";
	imageType = AGravImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AGravPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AGravPack::onDeploy(%player,%item,%pos)
{
	if (AGravPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AGravPack::deployShape(%player,%item)
{
 	deployable(%player,%item,"Turret","Anti-Grav Turret",False,False,False,False,False,False,5,True,5, True, "DeployableSnare", "AGravPack");
}

//========================Concussion Turret

ItemImageData ConPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
	mass = 2.5;
};

ItemData ConPack
{
	description = "Concussion Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "dTurrets";
	imageType = ConPackImage;
	shadowDetailMask = 4;
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

function ConPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Concussion Turret",False,False,False,False,False,False,4,True,100, True, "DeployableConTurret", "ConPack");
}

//========================Camera Pack

ItemImageData CameraPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
};

ItemData CameraPack
{
	description = "Dart Turret";
	shapeFile = "camera";
	className = "Backpack";
   	heading = "dTurrets";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
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
	deployable(%player,%item,"Turret","Dart Turret",False,False,False,False,False,False,5,True,30, True, "CameraTurret", %item);
}

//========================Deployable ELF Turret

ItemImageData DeployableElfImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.5;
};

ItemData DeployableElf
{
	description = "Elf Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
    	heading = "dTurrets";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 700;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableElf::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DeployableElf::onDeploy(%player,%item,%pos)
{
	if (DeployableElf::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function DeployableElf::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Deployable Elf Turret",False,False,False,False,False,False,5,True,20, True, "DeployableElfTurret", "DeployableElf");
}

//========================Emp Turret

ItemImageData ShockPackImage
{
	shapeFile = "indoorgun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.5;
};

ItemData ShockPack
{
	description = "EMP Turret";
	shapeFile = "indoorgun";
	className = "Backpack";
   	heading = "dTurrets";
	imageType = ShockPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

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
	if (ShockPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ShockPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","EMP Turret",False,False,False,False,False,False,5,True,15, True, "DeployableShock", "ShockPack");
}

//========================Flak Turret
ItemImageData FlakPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
	mass = 2.5;
};

ItemData FlakPack
{
	description = "Flak Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "dTurrets";
	imageType = FlakPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlakPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function FlakPack::onDeploy(%player,%item,%pos)
{
	if (FlakPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function FlakPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Flak Turret",False,False,False,False,False,False,4,True,25, True, "DeployableFlak", "FlakPack");
}

//========================Flame Turret
ItemImageData FlameTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData FlameTurretPack
{
	description = "Flame Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    heading = "dTurrets";
	imageType = FlameTurretPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlameTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function FlameTurretPack::onDeploy(%player,%item,%pos)
{
	if (FlameTurretPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function FlameTurretPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Flame Turret",False,False,False,False,False,False,4,True,25, True, "FlameTurret", "FlameTurretPack");
}

//=======================GunTuretPack

ItemImageData GunTuretPackImage 
{	shapeFile = "GunTuret";
	mountPoint = 2;
	mountOffset = { 0, 0, -1 };
	mountRotation = { 0, 0, 0 };
	mass = 8.0;
	firstPerson = false;
};

ItemData GunTuretPack
{	description = "Gunnery Bunker";
	shapeFile = "GunTuret";
	className = "Backpack";
	heading = "dTurrets";
	imageType = GunTuretPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1050;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GunTuretPack::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}
function GunTuretPack::onDeploy(%player,%item,%pos) 
{
	if (GunTuretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function GunTuretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,6))
	{
		%obj = getObjectType($los::object);

		if (!checkDeployArea(%client, Vector::add(%playerpos, EmplacementPack::rotVector( "0 3.2 1.5", GameBase::getRotation(%player))), 1, 1, 1.5))
		{
			systemMessage(%client,1,"Objects In The Way. Can not deploy.");
			return;
		}

		if (%obj == "SimTerrain")
		{
%name = Client::getName(%client);
%playerpos = GameBase::getPosition(%player);
%playerrot = GameBase::getRotation(%player);
%team = GameBase::getTeam(%player);
CreateBunkerSet(%client);

%objDevice =  newObject("Bunker","InteriorShape","ewedge.dis",true);
addToSet(MissionCleanup, %objDevice);
%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "0 3.2 -2.5", GameBase::getRotation(%player)));
GameBase::setPosition(%objDevice,%pos);
GameBase::setRotation(%objDevice,%playerrot);
GameBase::setTeam(%objDevice,%team);

%name1 = "Gunnery " @ Client::getName(%client);
instant StaticShape %name1
{
	dataBlock = "GunTuret";
	name = %name1;
	position = Vector::add(%playerpos, EmplacementPack::rotVector( "0 3.2 1.5", GameBase::getRotation(%player)));
	rotation = %playerrot;
	destroyable = "True";
	deleteOnDestroy = "False";
	base = "true";
};
addToSet("MissionCleanup/Bunker" @ %client,%name1);
addToSet("MissionCleanup",%name1);
%n1 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name1));
%n1.base = "true";
gamebase::setteam(%n1, %team);

%name2 = "Shield Stn " @ Client::getName(%client);
instant StaticShape %name2
{
	dataBlock = "GunTuretStn";
	name = %name2;
	position = %playerpos;
	rotation = %playerrot;
	destroyable = "True";
	deleteOnDestroy = "True";
	base = "true";
};
addToSet("MissionCleanup/Bunker" @ %client,%name2);
addToSet("MissionCleanup",%name2);
%n2 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name2));
%n2.base = "true";
gamebase::setteam(%n2, %team);

playSound(SoundPickupBackpack,$los::position);
$TeamItemCount[%team @ "GunTuretPack"]++;
systemMessage(%client,0,"Gunnery deployed.");
%newplayerpos = Vector::add(%playerpos, EmplacementPack::rotVector( "0 3.2 1.5", GameBase::getRotation(%player)));
GameBase::setPosition(%player,%newplayerpos);
return true;
	}
		else {systemMessage(%client,0,"Can only deploy on terrain.");}
	}
	else {systemMessage(%client,0,"Deploy position out of range");}
	return false;
}

function GunTuretPack::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "The Gunnery Turret has no auto-sensor and must be controlled manually.");
}

//========================Hyper-Grav Turret

ItemImageData HGravTurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
};

ItemData HGravTurretPack
{
	description = "Hyper-Grav Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dTurrets";
	imageType = HGravTurretPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HGravTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function HGravTurretPack::onDeploy(%player,%item,%pos)
{
	if (HGravTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function HGravTurretPack::deployShape(%player,%item)
{
 	deployable(%player,%item,"Turret","Hyper-Grav Turret",False,False,False,False,False,False,5,True,5, True, "DeployableHGravTurret", "HGravTurretPack");
}

//========================

ItemImageData TurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
	mass = 2.0;
};

ItemData TurretPack
{
	description = "Ion Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "dTurrets";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
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

function TurretPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Ion Turret",False,False,False,False,False,False,4,True,25, True, "DeployableTurret", "TurretPack");
}

//========================Laser Turret

ItemImageData LaserPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
};

ItemData LaserPack
{
	description = "Laser Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "dTurrets";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserPack::onUse(%player,%item)
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

function LaserPack::onDeploy(%player,%item,%pos)
{
	if (LaserPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function LaserPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Laser Turret",False,False,False,False,False,False,5,True,25, True, "DeployableLaser", "LaserPack");
}

//=======================Hellacious Cannon
$InvList[MalicePack] = 1;
$RemoteInvList[MalicePack] = 1;
$CanControl[MaliceTurret] = 1;
$EmbedController[MaliceTurret] = 1;
//==Recount item is in itemfunction.cs

ItemImageData MalicePackImage 
{	shapeFile = "hellfiregun";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 4.0;
	firstPerson = false;
};

ItemData MalicePack
{	description = "Hellacious Cannon";
	shapeFile = "hellfiregun";
	className = "Backpack";
	heading = "dTurrets";
	imageType = MalicePackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 3050;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MalicePack::onUse(%player,%item) 
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}
function MalicePack::onDeploy(%player,%item,%pos) 
{
	if (MalicePack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
function MalicePack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Hellacious Cannon",False,False,False,False,False,False,4,True,25, True, "MaliceTurret", "MalicePack");
}

function MalicePack::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "The Hellacious Cannon has no auto-sensor and must be controlled manually.");
}

//========================Mortar Turret

ItemImageData TargetPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 3.0;
};

ItemData TargetPack
{
	description = "Mortar Turret";
	shapeFile = "mortar_turret";
	className = "Backpack";
   	heading = "dTurrets";
	imageType = TargetPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TargetPack::onUse(%player,%item)
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

function TargetPack::onDeploy(%player,%item,%pos)
{
	if (TargetPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TargetPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Mortar Turret",True,False,True,True,True,True,4,True,25, True, "DeployableMortar", "TargetPack");
}

//========================Deployable Plasma Turret

ItemImageData PlasmaTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlasmaTurretPack
{
	description = "Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    	heading = "dTurrets";
	imageType = PlasmaTurretPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmaTurretPack::onUse(%player,%item)
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

function PlasmaTurretPack::onDeploy(%player,%item,%pos)
{
	if (PlasmaTurretPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function PlasmaTurretPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","RMT Plasma Turret",False,False,False,False,False,False,4,True,25, True, "DeployablePlasma", "PlasmaTurretPack");
}

//========================Rail Turret
ItemImageData RailTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData RailTurretPack
{
	description = "Rail Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "dTurrets";
	imageType = RailTurretPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RailTurretPack::onUse(%player,%item)
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

function RailTurretPack::onDeploy(%player,%item,%pos)
{
	if (RailTurretPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function RailTurretPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Rail Turret",False,False,False,False,False,False,4,True,25, True, "RailTurret", "RailTurretPack");
}

//========================Rocket Turret

ItemImageData RocketPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData RocketPack
{
	description = "Rocket Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
    	heading = "dTurrets";
	imageType = RocketPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketPack::onUse(%player,%item)
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

function RocketPack::onDeploy(%player,%item,%pos)
{
	if (RocketPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function RocketPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","RMT Rocket Turret",False,False,False,False,False,False,4,True,25, True, "DeployableRocket", "RocketPack");
}

//========================Chaingun Turret
ItemImageData ChaingunTurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.0;
};

ItemData ChaingunTurretPack
{
	description = "Target Acquisition Turr";
	shapeFile = "camera";
	className = "Backpack";
	heading = "dTurrets";
	imageType = ChaingunTurretPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

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
	deployable(%player,%item,"Turret","Target Acquisition Turret",False,False,False,False,False,False,4,True,100, True, "DeployableChaingun", "ChaingunTurretPack");
}

//========================Vulcan Turret
ItemImageData VulcanTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData VulcanTurretPack
{
	description = "Vulcan Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "dTurrets";
	imageType = VulcanTurretPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 850;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function VulcanTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}
function VulcanTurretPack::onDeploy(%player,%item,%pos)
{
	if (VulcanTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}
function VulcanTurretPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Vulcan Turret",False,False,False,False,False,False,4,True,25, True, "DeployableVulcan", "VulcanTurretPack");
}

//========================
// Construction e
//========================

//======================== Door

ItemImageData BlastDoorPackImage
{
	shapeFile = "teleport_square";
	mountPoint = 2;
    	mountOffset = { 0, -0.1, -1 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BlastDoorPack
{
	description = "Blast Doors";
	shapeFile = "teleport_square";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = BlastDoorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlastDoorPack::onUse(%player,%item)
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

function BlastDoorPack::onDeploy(%player,%item,%pos)
{
	if (BlastDoorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BlastDoorPack::deployShape(%player,%item)
{
	if (deployable(%player, %item, "StaticShape", "Blast Door", False, False, False, False, False, False, 4, True, 0, False, "BlastDoorR", "BlastDoorPack") ) deployable(%player, %item, "StaticShape", "Blast Door", True, False, False, False, False, False, 4, True, 0, False, "BlastDoorL", "BlastDoorPack");
}

//======================== Blast Floor Pack

ItemImageData BlastFloorPackImage
{
	shapeFile = "teleport_square";
	mountPoint = 2;
    	mountOffset = { 0, -0.1, -1 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BlastFloorPack
{
	description = "Blast Floor";
	shapeFile = "teleport_square";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = BlastFloorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlastFloorPack::onUse(%player,%item)
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

function BlastFloorPack::onDeploy(%player,%item,%pos)
{
	if (BlastFloorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BlastFloorPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	if($TeamItemCount[%team @ %item] < $TeamItemMax[%item])
	{
		GameBase::getLOSInfo(%player,3);
		%playerRot = GameBase::getRotation(%player);
		%deploypos = GameBase::getPosition(%player);
		if (Vector::dot($los::normal,"0 0 1") < 0.7 ) %deploypos = Vector::add(GameBase::getPosition(%player), "0 0 2.03");
		%inv = newObject("Blast Floor", "StaticShape", "BlastFloor", true);
		addToSet("MissionCleanup", %inv);
		GameBase::setRotation(%inv,%playerRot);
		GameBase::setPosition(%inv,%deploypos);
		Gamebase::setMapName(%inv,"Blast Floor");
		GameBase::setTeam(%inv,%team);
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[%team @ "BlastFloorPack"]++;
		systemMessage(Player::getClient(%player),0,"Blast Floor is laid.");
		%inv.nukable = "True";
	}
}

//======================== Blastwall

ItemImageData BlastWallPackImage
{
	shapeFile = "teleport_square";
	mountPoint = 2;
    	mountOffset = { 0, -0.1, -1 };
	mass = 2.5;
	firstPerson = false;
};

ItemData BlastWallPack
{
	description = "Blast Wall";
	shapeFile = "teleport_square";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = BlastWallPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlastWallPack::onUse(%player,%item)
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

function BlastWallPack::onDeploy(%player,%item,%pos)
{
	if (BlastWallPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BlastWallPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Blast Wall",True,False,False,False,False,False,4,True,0, False, "BlastWall", "BlastWallPack");
}


//========================SEED pack

ItemImageData SeedPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 1;
	firstPerson = false;
};

ItemData SeedPack
{
	description = "Cactus";
	shapeFile = "sensor_small";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = SeedPackImage;
	shadowDetailMask = 4;
	elasticity = 0.1;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SeedPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function SeedPack::onDeploy(%player,%item,%pos)
{
	if (SeedPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function SeedPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%rand = floor(getRandom() * 4);
	if(%rand == 0) %type = "Cactus";
	else if(%rand == 1) %type = "Cactus1";
	else if(%rand == 2) %type = "Cactus2"; 
	else %type = "Cactus3";
	%object = (deployable(%player, SeedPack, "StaticShape", "Cactus", True, False, False, False, True, True, 5, True, False, True, %type, "SeedPack") );
	if (%object)
	{
		%team = gamebase::getteam(%player);
		%object.tc = %client;
		echo("MSG: ",%client," planted a cactus");
		return true;
	}
}

//========================Electric Webs

ItemImageData ElectricWebImage
{
	shapeFile = "display_three";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };//1.57
	firstPerson = false;
	mass = 2.5;
};

ItemData ElectricWeb
{
	description = "Electric Web";
	shapeFile = "display_three";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = ElectricWebImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ElectricWeb::onUse(%player,%item)
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

function ElectricWeb::onDeploy(%player,%item,%pos)
{
	if (ElectricWeb::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ElectricWeb::deployShape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	%playerPos = GameBase::getPosition(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		%playerRot = GameBase::getRotation(%player);
		if (CheckForSpawn(%client,%playerPos))
		{
			%deploypos = Vector::add(GameBase::getPosition(%player), "0 0 2");
			%rot = Vector::add(%playerRot, "0 1.57 1.57");
			%inv = newObject("Electric Web","Turret","PlasmaDoorTurr",true);
			addToSet("MissionCleanup", %inv);
			GameBase::setTeam(%inv,GameBase::getTeam(%player));
			GameBase::setRotation(%inv,%rot);
			GameBase::setPosition(%inv,%deploypos);
			Gamebase::setMapName(%inv,"Electric Web" @  Client::getName(%client));
			Client::setOwnedObject(%client, %inv);
			Client::setOwnedObject(%client, %player);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "ElectricWeb"]++;
			$TeamItemCount[GameBase::getTeam(%player) @ "ElectricFloor"]++;
			systemMessage(%client,0,"Electric Web is spun.~wlightning_idle.wav");
			systemMessage(%client,0,"Base Defense: 2 points.");
			%client.score = (%client.score +2);
			%inv.tc = %client;
			%inv.nukable = "True";
		}
	}
}

//======================== Electric Web Floor

ItemImageData ElectricFloorImage
{
	shapeFile = "display_three";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.5;
};

ItemData ElectricFloor
{
	description = "Electric Web: ground";
	shapeFile = "display_three";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = ElectricFloorImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ElectricFloor::onUse(%player,%item)
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

function ElectricFloor::onDeploy(%player,%item,%pos)
{
	if (ElectricFloor::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ElectricFloor::deployShape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	if($TeamItemCount[%team @ "ElectricWeb"] < $TeamItemMax["ElectricWeb"])
	{
		%playerPos = GameBase::getPosition(%player);
		if (CheckForSpawn(%client,%playerPos))
		{
			%deploypos = Gamebase::getPosition(%player);
			if (Vector::dot($los::normal,"0 0 1") < 0.7 ) %deploypos = Vector::add(GameBase::getPosition(%player), "0 0 2");
			%rot = GameBase::getRotation(%player);
			%inv = newObject("Web Floor","Turret","PlasmaDoorTurr",true);
			addToSet("MissionCleanup", %inv);
			GameBase::setTeam(%inv,%team);
			GameBase::setRotation(%inv,%rot);
			GameBase::setPosition(%inv,%deploypos);
			Gamebase::setMapName(%inv,"Web Floor");
			Client::setOwnedObject(%client, %inv);
			Client::setOwnedObject(%client, %player);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[%team @ "ElectricWeb"]++;
			$TeamItemCount[%team @ "ElectricFloor"]++;
			systemMessage(%client,0,"Electric Web is spun.~wlightning_idle.wav");
			systemMessage(%client,0,"Base defense: 2 points.");
			%client.score = (%client.score +2);
			%inv.tc = %client;
			%inv.nukable = "True";
		}
	}
}

//========================Deployable Force Field

ItemImageData ForceFieldPackImage
{
	shapeFile = "display_three";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, -0.4 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldPack
{
	description = "Force Field: barrier";
	shapeFile = "display_three";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item)
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

function ForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (ForceFieldPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ForceFieldPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Small Force Field",True,False,False,False,False,False,4,True,0, False, "DeployableForceField", "ForceFieldPack");
}

//======================= Large Force Field

ItemImageData LargeForceFieldPackImage
{
	shapeFile = "display_three";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, -0.4 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeForceFieldPack
{
	description = "Force Field: large";
	shapeFile = "display_three";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = LargeForceFieldPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LargeForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeForceFieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}



function LargeForceFieldPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Large Force Field",True,False,False,False,False,False,4,True,0, False, "LargeForceField", "LargeForceFieldPack");
}

//========================Large Shock Force Field
ItemImageData LargeShockForceFieldPackImage
{
	shapeFile = "display_three";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, -0.4 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeShockForceFieldPack
{
	description = "Force Field: large shock";
	shapeFile = "display_three";
	className = "Backpack";
    	heading = "eConstruction";
	imageType = LargeShockForceFieldPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeShockForceFieldPack::onUse(%player,%item)
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

function LargeShockForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeShockForceFieldPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}



function LargeShockForceFieldPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Large Shock Force Field",True,False,False,False,False,False,4,True,0, True, "LargeShockForceField", "LargeShockForceFieldPack");
}

ItemImageData ShockFloorPackImage
{
	shapeFile = "display_three";
	mountPoint = 2;
   	mountOffset = { 0, -0.03, -0.4 };
	mass = 1.5;
	firstPerson = false;
};

ItemData ShockFloorPack
{
	description = "Force Field: shock floor";
	shapeFile = "display_three";
	className = "Backpack";
	heading = "eConstruction";
	imageType = ShockFloorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShockFloorPack::onUse(%player,%item)
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

function ShockFloorPack::onDeploy(%player,%item,%pos)
{
	if (ShockFloorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ShockFloorPack::deployShape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	if($TeamItemCount[%team @ "ShockFloorPack"] < $TeamItemMax["ShockFloorPack"])
	{
		%deploypos = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 3 0", GameBase::getRotation(%player) ) );
		if (Vector::dot($los::normal,"0 0 1") < 0.7 ) %deploypos = Vector::add(%deploypos, "0 0 2");
		%rot = Vector::add(GameBase::getRotation(%player), "1.57 0 0");
		%inv = newObject("Shock Floor", "StaticShape", "ShockFloor", true);
		addToSet("MissionCleanup", %inv);
		GameBase::setTeam(%inv,%team);
		GameBase::setRotation(%inv,%rot);
		GameBase::setPosition(%inv,%deploypos);
		Gamebase::setMapName(%inv,"Shock Floor");
		Client::setOwnedObject(%client, %inv);
		Client::setOwnedObject(%client, %player);
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[%team @ "ShockFloorPack"]++;
		systemMessage(%client,0,"Shock Floor is laid.");
		%inv.nukable = "True";
        }
}

//========================Healing Plant

ItemImageData PlantPackImage
{
	shapeFile = "plant2";
	mountPoint = 2;
   mountOffset = { 0, -0.5, -0.3 };
	mass = 1.0;
	firstPerson = false;
};

ItemData PlantPack
{
	description = "Healing Plant";
	shapeFile = "sensor_small";
	className = "Backpack";
   	heading = "eConstruction";
	imageType = PlantPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlantPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlantPack::onDeploy(%player,%item,%pos)
{
	if (PlantPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlantPack::deployShape(%player,%item)
{
	deployable(%player, %item, "StaticShape", "Healing Plant", True, False, False, False, True, True, 5, True, False, True, PlantTwo, %item);
}

//========================Teleport Pad

ItemImageData TeleportPackImage
{
	shapeFile = "fusionbolt";
	mountPoint = 2;
	mountOffset = { 0, 0.2, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.5;
};

ItemData TeleportPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
    	heading = "sPersonnel Movers";
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleportPack::onUse(%player,%item)
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

function TeleportPack::onDeploy(%player,%item,%pos)
{
	if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"]++;
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

function TeleportPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"] < $TeamItemMax[TeleportPack]) {

	if (GameBase::getLOSInfo(%player,5))
	{
		%obj = getObjectType($los::object);
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				if(checkDeployArea(%client,$los::position))
				{
					%pos = $los::position;
					%padd = "0 0 0.3";
                			%poss = Vector::add(%pos, %padd);

					if(GameBase::testPosition(%player, %poss)) { } else { systemMessage(%client,0,"Can not deploy inside other objects."); return; }

					%sensor = newObject("Teleport Pad","StaticShape",%shape,true);

					CreateteleportSimSet();
					addToSet("MissionCleanup/Teleports", %sensor);
					addToSet("MissionCleanup", %sensor);

					GameBase::setTeam(%sensor,GameBase::getTeam(%player));
					%pos = Vector::add($los::position,"0 0 1");
					GameBase::setPosition(%sensor,%pos);
					Gamebase::setMapName(%sensor,%name);
					systemMessage(%client,0,%item.description @ " deployed");
					%sensor.disabled = false;
					playSound(SoundPickupBackpack,$los::position);

					%beam = newObject("","StaticShape",ElectricalBeam,true);
					addToSet("MissionCleanup", %beam);
					GameBase::setTeam(%beam,GameBase::getTeam(%player));
					GameBase::setPosition(%beam,%pos);

					%sensor.beam1 = %beam;
					return true;
				}
			}
			else
				systemMessage(%client,0,"Can only deploy on flat surfaces");
		}
		else
			systemMessage(%client,0,"Deploy position out of range");
	}
	else
	 	systemMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

//========================HoloGram

ItemImageData HoloPackImage
{
	shapeFile = "plasmabolt";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1.0;
};

ItemData HoloPack
{
	description = "Hologram";
	shapeFile = "plasmabolt";
	className = "Backpack";
	heading = "eConstruction";
	imageType = HoloPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 900;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HoloPack::onUse(%player,%item)
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

function HoloPack::onDeploy(%player,%item,%pos)
{
	if (HoloPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
function HoloPack::deployShape(%player,%item)

{
	%client = Player::getClient(%player);
	%rand = floor(getRandom() * 4);
	if(%rand == 0) %type = "Hologram1";
	else if(%rand == 1) %type = "Hologram2";
	else %type = "Hologram3";
	deployable(%player, HoloPack, "StaticShape", "Hologram", True, False, False, False, True, True, 5, True, False, False, %type, "HoloPack");
}

//========================Poison Oak

ItemImageData TreePackImage
{
	shapeFile = "tree1";
	mountPoint = 2;
   	mountOffset = { 0, 0.15, -1 };
	mass = 3.0;
	firstPerson = false;
};

ItemData TreePack
{
	description = "Poison Oak";
	shapeFile = "sensor_small";
	className = "Backpack";
   	heading = "eConstruction";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 600;
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
	if (TreePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function TreePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%playerpos = GameBase::getPosition(%player);
	if (CheckForSpawn(%client,%playerPos) )
	{
		%object = ( deployable(%player,%item,"StaticShape","Carniverous Oak", True, False, False, False, True, False, 5, True, True, True, "TreeShapeTwo", %item) );
		if (%object)
		{
			%object.tc = %client;
			systemMessage(%client,0,"Carniverous Oak Planted");
			return true;
		}
	}
}

//========================Power Generator
ItemImageData PowerGeneratorPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData PowerGeneratorPack
{
	description = "Portable Generator";
	shapeFile = "generator_p";
	className = "Backpack";
   	heading = "eConstruction";
	imageType = PowerGeneratorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PowerGeneratorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Power Generator Will Power Your Team Equipment.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function PowerGeneratorPack::onDeploy(%player,%item,%pos) { if (PowerGeneratorPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function PowerGeneratorPack::deployShape(%player,%item)
{
	%object = (deployable(%player,"DepGenerator","StaticShape","DepGenerator",True,False,True,False,True,False,5,False,0,False, "DepGenerator", "PowerGeneratorPack"));
	if (%object)
	{
		gamebase::setteam(%object, gamebase::getteam(%player));
		addToSet("MissionCleanup", %object);
		addToSet("MissionGroup/Teams/Team" @ gamebase::getteam(%player), %object);
	}
}

ItemImageData PrismImage
{
	shapeFile = "mortar";
	mountPoint = 2;
	mountRotation = { -1.57, 3, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PrismPack
{
	description = "Prism";
	shapefile = "pyrm2";
	classname = "Backpack";
	heading = "eConstruction";
	imageType = prismImage;
	shadowDetailMask = 4;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function prismPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
	{
		Player::deployItem(%player,%item);
	}
}

function prismPack::onDeploy(%player,%item,%pos)
{
        if (prismPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function prismPack::deployShape(%player,%item)
{
	%team = GameBase::getTeam(%player);
	%client = Player::getClient(%player);
	if($TeamItemCount[%team @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,4))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				if(checkDeployArea(%client,$los::position))
				{
					%cname = "PyramidSet";
					%rot = GameBase::getRotation(%player);
					%inv = newObject("Disturbing Object","StaticShape","Pyramid",true);
					addToSet("MissionCleanup", %inv);
					addToSet("MissionCleanup/PyramidSet", %inv);
					GameBase::setTeam(%inv,%team);
					%pos = $los::position;
					GameBase::setPosition(%inv,%pos);
					Gamebase::setMapName(%inv,"Disturbing Object");

					%beam = newObject("Disturbing Object","Turret","prism",true);
					addToSet("MissionCleanup", %beam);
					GameBase::setTeam(%beam,%team);
					GameBase::setPosition(%beam,%pos);
					Gamebase::setMapName(%beam,"Disturbing Object");
					%inv.beam1 = %beam;
					%beam.beam = %inv;
					Client::setOwnedObject(%client, %beam); 
					Client::setOwnedObject(%client, %player);
					schedule ("PowerPrisms(" @ %beam @ ", 30," @  %client @ ",0);",3);

					%beam = newObject("Repairing Object","Turret","RepairPost",true);
					addToSet("MissionCleanup", %beam);
					if (%team == 0) %eteam = 1;
					else %eteam = 0;
					GameBase::setPosition(%beam,%pos);
					Gamebase::setMapName(%beam,"Leech");
					%inv.beam2 = %beam;
					%beam.beam = %inv;
					Client::setOwnedObject(%client, %beam); 
					Client::setOwnedObject(%client, %player);
					GameBase::setTeam(%beam,%eteam);
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[%team @ "prismPack"]++;
					schedule ("PowerPrisms(" @ %beam @ ", 30," @  %client @ ",1);",3);
					systemMessage(%client,0, "Wait... scanning for Prism's Power within 30 meters...~wsensor_deploy.wav");
					systemMessage(%client,1, "~wfemale1.wwait1.wav");
					return true;
				}
			}
			else
				systemMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			systemMessage(%client,0,"Deploy position out of range");
	}
	else
	 	systemMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//========================
//==Stations f
//========================
//xxx

//========================Deployable Ammo Station
ItemImageData DeployableAmmoPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableAmmoPack
{
	description = "Ammo Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   	heading = "fStations";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	elasticity = 0.2;
	price = $RemoteAmmoEnergy;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableAmmoPack::onUse(%player,%item)
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

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function DeployableAmmoPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Ammo Station",True,False,True,False,True,True,4,True,0,False, "DeployableAmmoStation", "DeployableAmmoPack");
}

//========================Bunker

ItemImageData BunkerPackImage
{
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, 0, -1 };
        mountRotation = { 0, 0, 0 };
	mass = 4;
        firstPerson = false;
};

ItemData BunkerPack
{
        description = "Bunker";
        shapeFile = "magcargo";
        className = "Backpack";
        heading = "fStations";
        shadowDetailMask = 4;
        imageType = BunkerPackImage;
        elasticity = 0.2;
        price = 300;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function BunkerPack::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Bunkers disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function EmplacementPack::rotVector(%vec,%rot)
{
	// this function rotates a vector about the z axis

	%vec_x = getWord(%vec,0);
	%vec_y = getWord(%vec,1);
	%vec_z = getWord(%vec,2);

	// new vector with z axis removed
	%basevec = %vec_x @ "  " @ %vec_y @ "  0";

	// change vector to distance and rotation
	%basedis = Vector::getDistance( "0 0 0", %basevec);
	%normvec = Vector::normalize( %basevec );
	%baserot = Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );

	// modify rotation and change back to vector (put z axis offset back)
	%newrot = Vector::add( %baserot, %rot );
	%newvec = Vector::getFromRot( %newrot, %basedis, %vec_z );

	return %newvec;
}


function BunkerPack::onDeploy(%player,%item,%pos)
{
	if (BunkerPack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
}

function CreateBunkerSet(%client)
{
    	%teleset = nameToID("MissionCleanup/Bunker" @ %client);
	if(%teleset == -1)
	{
		newObject("Bunker" @ %client,SimSet);
		addToSet("MissionCleanup","Bunker" @ %client);
		gamebase::setteam(%teleset, gamebase::getteam(%client));
	}
}

function BunkerPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,6))
	{
		%obj = getObjectType($los::object);

		if (!checkDeployArea(%client, $los::position, 5, 5, 3) )
		{
			systemMessage(%client,1,"Objects In The Way. Can not deploy.");
			return;
		}

		if (%obj == "SimTerrain")
		{
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
	%name = Client::getName(%client);
	%playerpos = GameBase::getPosition(%player);
	%playerrot = GameBase::getRotation(%player);
	%team = GameBase::getTeam(%player);
	CreateBunkerSet(%client);

	%objDevice =  newObject("Bunker","InteriorShape","ebunker.dis",true);
	%objDevice.objSide1 = newObject("Floor","InteriorShape","BEMfloatingpad.dis",true);
	%objDevice.objSide2 = newObject("Field","Staticshape",ForceField4,true);
	%objDevice.objSide3 = newObject("Field","Staticshape",ForceField4,true);
	%objDevice.objSide4 = newObject("Field","Staticshape",ForceField4,true);
	%objDevice.objPart1 = newObject("Power","StaticShape",SolarPanel,true);
	%objDevice.objPart2 = newObject("Supply","StaticShape",InventoryStation,true);
	%objDevice.objPart3 = newObject("Vehicle Stn","StaticShape",VehicleStation,true);
	%objDevice.objPart4 = newObject("Pad","StaticShape",VehiclePad,true);

	%objDevice.objSide1.objParent = %objDevice;
	%objDevice.objSide2.objParent = %objDevice;
	%objDevice.objSide3.objParent = %objDevice;
	%objDevice.objSide4.objParent = %objDevice;
	%objDevice.objPart1.objParent = %objDevice;
	%objDevice.objPart2.objParent = %objDevice;
	%objDevice.objPart3.objParent = %objDevice;
	%objDevice.objPart4.objParent = %objDevice;

	addToSet(MissionCleanup, %objDevice);
	addToSet(MissionCleanup, %objDevice.objSide1);
	addToSet(MissionCleanup, %objDevice.objSide2);
	addToSet(MissionCleanup, %objDevice.objSide3);
	addToSet(MissionCleanup, %objDevice.objSide4);
	addToSet(MissionCleanup, %objDevice.objPart1);
	addToSet(MissionCleanup, %objDevice.objPart2);
	addToSet(MissionCleanup, %objDevice.objPart3);
	addToSet(MissionCleanup, %objDevice.objPart4);

	deleteObject(%objDevice.objPart1);
	deleteObject(%objDevice.objPart2);
	deleteObject(%objDevice.objPart3);
	deleteObject(%objDevice.objPart4);

	GameBase::setPosition(%objDevice,%playerpos);
	GameBase::setRotation(%objDevice,%playerrot);
	GameBase::setTeam(%objDevice,%team);

	%pos = Vector::add(%playerpos, "0 0 -16");
	GameBase::setPosition(%objDevice.objSide1,%pos);
	GameBase::setRotation(%objDevice.objSide1,%playerrot);
	GameBase::setTeam(%objDevice.objSide1,%team);

	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "9.33 0.049 2.14", %playerrot ) );
	GameBase::setPosition(%objDevice.objSide2,%pos);
	%rot = Vector::add( %playerrot, "0.7 0 -1.57");
	GameBase::setRotation(%objDevice.objSide2,%rot);
	GameBase::setTeam(%objDevice.objSide2,%team);
	%objDevice.objSide2.base = "True";

	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-9.34 0.25 2.14", %playerrot ) );
	GameBase::setPosition(%objDevice.objSide3,%pos);
	%rot = Vector::add(%playerrot, "0.7 0 1.57");
	GameBase::setRotation(%objDevice.objSide3,%rot);
	GameBase::setTeam(%objDevice.objSide3,%team);
	%objDevice.objSide3.base = "True";

	%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "0 9.47 1.98", %playerrot ) );
	GameBase::setPosition(%objDevice.objSide4,%pos);
	%rot = Vector::add( %playerrot, "0.72 0 0");
	GameBase::setRotation(%objDevice.objSide4,%rot);
	GameBase::setTeam(%objDevice.objSide4,%team);
	%objDevice.objSide4.base = "True";

	%name1 = "BunkerPower " @ Client::getName(%client);
	%name2 = "BunkerSupply " @ Client::getName(%client);
	%name3 = "www.exploratoriums.com";
	%name4 = "Mod by Bïohazard";

	instant StaticShape %name1
	{
		dataBlock = "SolarPanel";
		name = %name1;
		position = Vector::add(%playerpos, EmplacementPack::rotVector( "5.19 0.23 3.91", %playerrot ) );
		rotation = Vector::add( %playerrot, "0 3.14 1.57");
		destroyable = "True";
		deleteOnDestroy = "False";
		base = "true";
	};
	instant StaticShape %name2
	{
		dataBlock = "InventoryStation";
		name = %name2;
		position = Vector::add(%playerpos, EmplacementPack::rotVector( "0 4.3 2.4", %playerrot ) );
		rotation = %playerrot;
		destroyable = "True";
		deleteOnDestroy = "False";
		base = "true";
	};

	instant StaticShape %name3
	{
		dataBlock = "VehicleStation";
		name = %name3;
		position = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.53 0.3 2.57", %playerrot ) );
		rotation = Vector::add( %playerrot, "0 0 1.57");
		destroyable = "True";
		deleteOnDestroy = "False";
		base = "true";
	};
	instant StaticShape %name4
	{
		dataBlock = "VehiclePad";
		name = %name4;
		position = Vector::add(%playerpos, "0 0 8.14");
		rotation = %playerrot;
		destroyable = "True";
		deleteOnDestroy = "False";
		base = "true";
	};

	addToSet("MissionCleanup/Bunker" @ %client,%name1);
	addToSet("MissionCleanup/Bunker" @ %client,%name2);
	addToSet("MissionCleanup/Bunker" @ %client,%name3);
	addToSet("MissionCleanup/Bunker" @ %client,%name4);

	addToSet("MissionCleanup",%name1);
	addToSet("MissionCleanup",%name2);
	addToSet("MissionCleanup",%name3);
	addToSet("MissionCleanup",%name4);

	%n1 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name1));
	%n2 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name2));
	%n3 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name3));
	%n4 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name4));

	%n1.base = "true";
	%n2.base = "true";
	%n3.base = "true";
	%n4.base = "true";

	gamebase::setteam(%n1, %team);
	gamebase::setteam(%n2, %team);
	gamebase::setteam(%n3, %team);
	gamebase::setteam(%n4, %team);

	playSound(SoundPickupBackpack,$los::position);

	$TeamItemCount[%team @ "BunkerPack"]++;
	systemMessage(%client,0,"Bunker deployed.");
	%newplayerpos = Vector::add(%playerpos, "0 0 2");
	GameBase::setPosition(%player,%newplayerpos);
	return true;

			}
			else {systemMessage(%client,0,"Can only deploy on flat surfaces");}
		}
		else {systemMessage(%client,0,"Can only deploy on terrain.");}
	}
	else {systemMessage(%client,0,"Deploy position out of range");}
	return false;
}

//========================Deployable Command Center
ItemImageData DeployableComPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DeployableComPack
{
	description = "Command Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
   	heading = "fStations";
	shadowDetailMask = 4	;
	imageType = DeployableComPackImage;
	elasticity = 0.2;
	price = $RemoteComEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableComPack::onUse(%player,%item)
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

function DeployableComPack::onDeploy(%player,%item,%pos)
{
	if (DeployableComPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DeployableComPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Remote Command Station",True,False,True,False,True,True,4,True,0,False, "DeployableComStation", "DeployableComPack");
}

//========================EmergencyInvo

ItemImageData EmergencyInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData EmergencyInvPack
{
	description = "Emergency Inventory";
	shapeFile = "invent_remote";
	className = "Backpack";
   	heading = "fStations";
	shadowDetailMask = 4	;
	imageType = EmergencyInvPackImage;
	elasticity = 0.2;
	price = 3000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function EmergencyInvPack::onUse(%player,%item)
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

function EmergencyInvPack::onDeploy(%player,%item,%pos)
{
	if (EmergencyInvPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function CreateEmergencyInvSet(%client)
{
    	%teleset = nameToID("MissionCleanup/EmergencyInv" @ %client);
	if(%teleset == -1)
	{
		newObject("EmergencyInv" @ %client,SimSet);
		addToSet("MissionCleanup","EmergencyInv" @ %client);
		gamebase::setteam(%teleset, gamebase::getteam(%client));
	}
}

function EmergencyInvPack::deployshape(%player,%item)
{
   if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
   {
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	%playerPos = GameBase::getPosition(%player);
	%deploypos = Vector::add(GameBase::getPosition(%player), "0 0 0");
	%number = $TeamItemCount[GameBase::getTeam(%player) @ "EmergencyInvPack"];
	CreateEmergencyInvSet(%client);
	%name1 = "Emergency Invo";
	%plat1 = "www.exploratoriums.com";
	
	instant StaticShape %plat1
	{
		dataBlock = "Mainpad";
		name = %plat1;
		position = Vector::add(GameBase::getPosition(%player), "0 0 0");
		rotation = Vector::add(GameBase::getRotation(%player), "0 0 0");
		destroyable = "True";
		deleteOnDestroy = "True";
		team = GameBase::getTeam(%player);
	};

//========================Invo Station
	instant StaticShape %name1
	{
		dataBlock = "EmergencyInv";
		name = %name1;
		position = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 0.50 0", GameBase::getRotation(%player) ) );
		rotation = Vector::add( GameBase::getRotation(%player), "0 0 0");
		destroyable = "True";
		deleteOnDestroy = "False";
		team = GameBase::getTeam(%player);
		crunch = "true";
	};


	addToSet("MissionCleanup/EmergencyInv" @ %client,%name1);
	addToSet("MissionCleanup/EmergencyInv" @ %client,%plat1);

	addToSet("MissionCleanup",%name1);
	addToSet("MissionCleanup",%plat1);

	%n1 = (nametoId("MissionCleanup/EmergencyInv" @ %client @ "/" @ %name1));
	%n2 = (nametoId("MissionCleanup/EmergencyInv" @ %client @ "/" @ %plat1));

	%n1.base = "true";
	%n2.base = "true";
	%n1.beam = %n2;

	gamebase::setteam(%n1, gamebase::getteam(%player));

	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "EmergencyInvPack"]++;
	systemMessage(%client,0,"Emergency Inventory Deployed. 5 points.");
      %client.score = (%client.score +5);
	return true;
   }
}

//===================Deployable Inventory
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
   	heading = "fStations";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	elasticity = 0.2;
	price = $RemoteInvEnergy + 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
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

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function DeployableInvPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Invo Station",True,False,True,False,True,True,4,True,0,False, "DeployableInvStation", "DeployableInvPack");
}


//========================
// Booby Traps g
//========================

ItemImageData TrapPack6Image
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TrapPack6
{
    description = "Energy Snare";
    shapeFile = "sensor_small";
    className = "Backpack";
    heading = "gBooby Traps";
    imageType = TrapPack6Image;
    shadowDetailMask = 4;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function TrapPack6::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Traps disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function TrapPack6::onDeploy(%player,%item,%pos)
{
	if (TrapPack6::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
function TrapPack6::deployShape(%player,%item)
{
       	%client = Player::getClient(%player);
       if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
       {
            %obj = newObject("Booby Trap Trigger","Mine","TrapPad6");
            addToSet("MissionCleanup", %obj);
            GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
            %player.throwTime = getSimTime() + 0.5;
            GameBase::setTeam (%obj,GameBase::getTeam (%client));
            Gamebase::setMapName(%obj,"Snare Trigger");
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%player) @ "TrapPack6"]++;
                systemMessage(%client,0,"Energy Snare is set.~wusepack.wav");
		%obj.tc = %client;
       }

}

ItemImageData TrapPack2Image
{
	shapeFile = "ammo1";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TrapPack2
{
    description = "Lasso-Snare Trap";
    shapeFile = "ammo1";
    className = "Backpack";
    heading = "gBooby Traps";
    imageType = TrapPack2Image;
    shadowDetailMask = 4;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function TrapPack2::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Traps disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function TrapPack2::onDeploy(%player,%item,%pos)
{
	if (TrapPack2::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
function TrapPack2::deployShape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if( $TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] && CheckForSpawn(%client,Gamebase::getPosition(%player) ) )
	{
		%obj = newObject("Booby Trap Trigger","Mine","TrapPad2");
		addToSet("MissionCleanup", %obj);
		%client = Player::getClient(%player);
		GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
		%player.throwTime = getSimTime() + 0.5;
		GameBase::setTeam (%obj,GameBase::getTeam (%client));
		playSound(SoundPickupBackpack,$los::position);
		$TeamItemCount[GameBase::getTeam(%player) @ "TrapPack2"]++;
		systemMessage(%client,0,"Lasso-Snare is set.~wusepack.wav");
		%obj.tc = %client;
	}

}

ItemImageData TrapPack1Image
{
	shapeFile = "mrtwig";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TrapPack1
{
    description = "Punji-Spike Trap";
    shapeFile = "mrtwig";
    className = "Backpack";
    heading = "gBooby Traps";
    imageType = TrapPack1Image;
    shadowDetailMask = 4;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function TrapPack1::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Traps disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function TrapPack1::onDeploy(%player,%item,%pos)
{
	if (TrapPack1::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
function TrapPack1::deployShape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if( $TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] && CheckForSpawn(%client,Gamebase::getPosition(%player) ) )
        {
                %obj = newObject("Booby Trap Trigger","Mine","TrapPad1");
                addToSet("MissionCleanup", %obj);
                %client = Player::getClient(%player);
                GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                %player.throwTime = getSimTime() + 0.5;
                GameBase::setTeam (%obj,GameBase::getTeam (%client));
                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%player) @ "TrapPack1"]++;
                systemMessage(%client,0,"Punji Spike Trap is set.~wusepack.wav");
		%obj.tc = %client;
        }

}

ItemImageData TrapPack4Image
{
	shapeFile = "ammo1";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TrapPack4
{
    description = "Quick-Sand Trap";
    shapeFile = "ammo1";
    className = "Backpack";
    heading = "gBooby Traps";
    imageType = TrapPack4Image;
    shadowDetailMask = 4;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function TrapPack4::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Traps disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function TrapPack4::onDeploy(%player,%item,%pos)
{
	if (TrapPack4::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
function TrapPack4::deployShape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if( $TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] && CheckForSpawn(%client,Gamebase::getPosition(%player)) )
        {
                %deploypos = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 0 0", GameBase::getRotation(%player) ) );
                %playerPos = GameBase::getPosition(%player);
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                %inv = newObject("Booby Trap Trigger","Turret","TrapPad4",true);
                addToSet("MissionCleanup", %inv);
                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                GameBase::setRotation(%inv,%rot);
                GameBase::setPosition(%inv,%deploypos);
                Gamebase::setMapName(%inv,"Booby Trap " @  Client::getName(%client));
                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%player) @ "TrapPack4"]++;
                systemMessage(%client,0,"Sand Trap is set.~wusepack.wav");
		%inv.tc = %client;
        }
}

ItemImageData TrapPack3Image
{
	shapeFile = "ammo1";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TrapPack3
{
    description = "Scary Trap";
    shapeFile = "ammo1";
    className = "Backpack";
    heading = "gBooby Traps";
    imageType = TrapPack3Image;
    shadowDetailMask = 4;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function TrapPack3::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Traps disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function TrapPack3::onDeploy(%player,%item,%pos)
{
	if (TrapPack3::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
function TrapPack3::deployShape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if( $TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] && CheckForSpawn(%client,Gamebase::getPosition(%player)) )
        {
                %deploypos = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 0 0", GameBase::getRotation(%player) ) );
                %playerPos = GameBase::getPosition(%player);
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                %inv = newObject("Booby Trap Trigger","Turret","TrapPad3",true);
                addToSet("MissionCleanup", %inv);
                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                GameBase::setRotation(%inv,%rot);
                GameBase::setPosition(%inv,%deploypos);
                Gamebase::setMapName(%inv,"Booby Trap " @  Client::getName(%client));
                playSound(SoundPickupBackpack,$los::position);
                systemMessage(%client,0,"Scary Trap is set.~wusepack.wav");
                $TeamItemCount[GameBase::getTeam(%player) @ "TrapPack3"]++;
		%inv.tc = %client;
        }
}

ItemImageData TrapPack5Image
{
	shapeFile = "ammo1";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TrapPack5
{
    description = "Stun Trap";
    shapeFile = "ammo1";
    className = "Backpack";
    heading = "gBooby Traps";
    imageType = TrapPack5Image;
    shadowDetailMask = 4;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function TrapPack5::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Traps disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function TrapPack5::onDeploy(%player,%item,%pos)
{
	if (TrapPack5::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
function TrapPack5::deployShape(%player,%item)
{
        GameBase::getLOSInfo(%player,4);
        %client = Player::getClient(%player);
        if( $TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item] && CheckForSpawn(%client,Gamebase::getPosition(%player)) )
        {
                %deploypos = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 0 0", GameBase::getRotation(%player) ) );
                %playerPos = GameBase::getPosition(%player);
                %rot = Vector::add(GameBase::getRotation(%player), "0 0 0");
                %inv = newObject("Booby Trap Trigger","Turret","TrapPad5",true);
                addToSet("MissionCleanup", %inv);
                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                GameBase::setRotation(%inv,%rot);
                GameBase::setPosition(%inv,%deploypos);
                Gamebase::setMapName(%inv,"Booby Trap " @  Client::getName(%client));
                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%player) @ "TrapPack5"]++;
                systemMessage(%client,0,"Stun Trap is set.~wusepack.wav");
		%inv.tc = %client;
        }

}

//========================
//==Aerial Items g
//========================

ItemImageData airbasePackImage
{
        shapeFile = "dsply_v1";
        mountPoint = 2;
        mountOffset = { 0, 0, -1 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
	mass = 4.0;
};

ItemData airbase
{
	description = "Air Base";
	shapeFile = "dsply_v1";
	className = "Backpack";
	heading =  "gAerial Construction";
	imageType = airbasePackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function airbase::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Building disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function airbase::onDeploy(%player,%item,%pos)
{
        if (airbase::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function AirBaseBuild(%obj,%playerpos,%client,%team,%item,%playerrot)
{
	if (getObjectType(%obj) != "RocketDumb")
	{
		messageall(0,"Unable to build Air Base, objects in the way.");
		$TeamItemCount[%team @ %item]--;
		return;
	}
	%x = GameBase::getPosition(%obj);
	%posX = getWord(%x,2);
	%posY = (getWord(%playerpos,2)-50);
	if ((%posX - %posY) >50)
	{
		deleteObject(%obj);

		CreateBunkerSet(%client);

		%objDevice =  newObject("Bunker","InteriorShape","bunker.dis",true);
		%objDevice.objSide1 = newObject("Side1","InteriorShape","flatbrdgcap.dis",true);
		%objDevice.objSide2 = newObject("Side2","InteriorShape","flatbrdgcap.dis",true);
		%objDevice.objSide3 = newObject("Side3","InteriorShape","flatbrdg512.dis",true);

		%objDevice.objSide1.objParent = %objDevice;
		%objDevice.objSide2.objParent = %objDevice;
		%objDevice.objSide3.objParent = %objDevice;

		addToSet("MissionCleanup", %objDevice);
		addToSet("MissionCleanup", %objDevice.objSide1);
		addToSet("MissionCleanup", %objDevice.objSide2);
		addToSet("MissionCleanup", %objDevice.objSide3);

		GameBase::setPosition(%objDevice,%playerpos);
		GameBase::setRotation(%objDevice,%playerrot);
		GameBase::setTeam(%objDevice,%team);

		%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.61 3.24 13.82", %playerrot ) );
		GameBase::setPosition(%objDevice.objSide1,%pos);
		GameBase::setRotation(%objDevice.objSide1,%playerrot);

		%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.62 9.74 0.57", %playerrot ) );
		GameBase::setPosition(%objDevice.objSide2,%pos);
		%rot = Vector::add( %playerrot, "0 3.14 3.14");
		GameBase::setRotation(%objDevice.objSide2,%rot);

		%pos = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.65 9.69 0.57", %playerrot ) );
		GameBase::setPosition(%objDevice.objSide3,%pos);
		%rot = Vector::add(%playerrot, "0 3.14 0");
		GameBase::setRotation(%objDevice.objSide3,%rot);

		%name1 = "AirPower " @ Client::getName(%client);
		%name2 = "AirSupply " @ Client::getName(%client);
		%name3 = "www.exploratoriums.com";
		%name4 = "Mod by Bïohazard";
		%name5 = "Air Sensor " @ Client::getName(%client);

		instant StaticShape %name1
		{
			dataBlock = "PortGenerator";
			name = %name1;
			position = Vector::add(%playerpos, EmplacementPack::rotVector( "-7.3 7.4 0.54", %playerrot ) );
			rotation = Vector::add(%playerrot, "0 0 -3.14");
			destroyable = "True";
			deleteOnDestroy = "False";
			base = "true";
		};
		instant StaticShape %name2
		{
			dataBlock = "InventoryStation";
			name = %name2;
			position = Vector::add(%playerpos, EmplacementPack::rotVector( "-2 9.4 0.5", %playerrot ) );
			rotation = Vector::add( %playerrot, "0 0 -1.57");
			destroyable = "True";
			deleteOnDestroy = "False";
			base = "true";
		};

		instant StaticShape %name3
		{
			dataBlock = "VehicleStation";
			name = %name3;
			position = Vector::add(%playerpos, EmplacementPack::rotVector( "-7.68 10.15 0.51", %playerrot ) );
			rotation = Vector::add( %playerrot, "0 0 1.57");
			destroyable = "True";
			deleteOnDestroy = "False";
			base = "true";
		};
		instant StaticShape %name4
		{
			dataBlock = "VehiclePad";
			name = %name4;
			position = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.4 22.5 1.19", %playerrot ) );
			rotation = %playerrot;
			destroyable = "True";
			deleteOnDestroy = "False";
			base = "true";
		};
		instant Sensor %name5
		{
			dataBlock = "MediumPulseSensor";
			name = %name5;
			position = Vector::add(%playerpos, EmplacementPack::rotVector( "-4.5 4 14", %playerrot ) );
			rotation = Vector::add( %playerrot, "0 3.14 0");
			destroyable = "True";
			deleteOnDestroy = "False";
			base = "true";
		};

		addToSet("MissionCleanup/Bunker" @ %client,%name1);
		addToSet("MissionCleanup/Bunker" @ %client,%name2);
		addToSet("MissionCleanup/Bunker" @ %client,%name3);
		addToSet("MissionCleanup/Bunker" @ %client,%name4);
		addToSet("MissionCleanup/Bunker" @ %client,%name5);

		addToSet("MissionCleanup",%name1);
		addToSet("MissionCleanup",%name2);
		addToSet("MissionCleanup",%name3);
		addToSet("MissionCleanup",%name4);
		addToSet("MissionCleanup",%name5);

		%n1 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name1));
		%n2 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name2));
		%n3 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name3));
		%n4 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name4));
		%n5 = (nametoId("MissionCleanup/Bunker" @ %client @ "/" @ %name5));

		%n1.base = "true";
		%n2.base = "true";
		%n3.base = "true";
		%n4.base = "true";
		%n5.base = "true";

		gamebase::setteam(%n1, %team);
		gamebase::setteam(%n2, %team);
		gamebase::setteam(%n3, %team);
		gamebase::setteam(%n4, %team);
		gamebase::setteam(%n5, %team);

		playSound(bigExplosion2,%playerpos);
		Client::sendMessage(%client,0,"Air Base Deployed.");
		return true;
	}
	else schedule ("AirBaseBuild(\"" @ %obj@ "\",\"" @ %playerpos @ "\",\"" @ %client @ "\",\"" @ %team @ "\",\"" @ %item @ "\",\"" @ %playerrot @ "\");",0.1);
}

function airbase::deployshape(%player,%item)
{
  %client = Player::getClient(%player);
  if (GameBase::getLOSInfo(%player,5))
  {
	%team = gamebase::getteam(%client);
	%playerpos = Vector::add(GameBase::getPosition(%player), "0 0 50");
	if (!checkDeployArea(%client, %playerpos,20,5,10))
	{
		systemMessage(%client,1,"Objects in the air, cannot deploy.");
		return false;
	}
	%trans = "1 0 0 0 0 1 0 -1 0 "@Vector::add(%playerpos,"0 0 -48");
	%vel = Item::getVelocity(%player);
	%obj = Projectile::spawnProjectile(AirBaseRiser,%trans,%player,%vel);
	$TeamItemCount[%team @ %item]++;
	%playerrot = GameBase::getRotation(%player);
	AirBaseBuild(%obj,%playerpos,%client,%team,%item,%playerrot);
	return true;
  }
  else
  {
	systemMessage(%client,0,"Object out of range");
  	return false;
  }
}

ItemImageData AirAmmoPadImage
{
	shapeFile = "mortar_turret";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.5;
};
ItemData AirAmmoPad
{
        description = "Air Fuser Turret";
        shapefile = "mortar_turret";
        classname = "Backpack";
        heading =  "gAerial Construction";
        imageType = AirAmmoPadImage;
        shadowDetailMask = 4;
        elasticity = 0.1;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function AirAmmoPad::onUse(%player,%item)
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

function AirAmmoPad::onDeploy(%player,%item,%pos)
{
        if (AirAmmoPad::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function AirFuser(%obj,%inv,%client,%team,%item)
{
	if (getObjectType(%obj) != "RocketDumb")
	{
		messageall(0,"Unable to set Air Fuser, objects in the way.");
		$TeamItemCount[%team @ %item]--;
		return;
	}
	%x = GameBase::getPosition(%obj);
	%posX = getWord(%x,2);
	%y = GameBase::getPosition(%inv);
	%posY = getWord(%y,2);
	if ((%posX - %posY) >50)
	{
		deleteObject(%obj);
		%name = "Air Fuser Turret "@Client::getName(%client);
		%turret = newObject(%name,"Turret", AirFuser,true);
		addToSet("MissionCleanup", %turret);
		GameBase::setTeam(%turret,%team);
		GameBase::setPosition(%turret,Vector::add(GameBase::getPosition(%inv), "0 0 50"));
		GameBase::setRotation(%turret,"0 3.14 0");
		systemMessage(%client,0,"Air Fuser deployed.");
		GameBase::startFadeIn(%turret);
		playSound(SoundPickupBackpack,GameBase::getPosition(%inv));
		Gamebase::setMapName(%turret, %name);
		if ($Wasteland::TurretKill)
		{
			%player = Client::getOwnedObject(%client);
			Client::setOwnedObject(%client, %turret);
			Client::setOwnedObject(%client, %player);
		}
		%turret.nukable = "True";
	}
	else schedule ("AirFuser(\"" @ %obj@ "\",\"" @ %inv @ "\",\"" @ %client @ "\",\"" @ %team @ "\",\"" @ %item @ "\");",0.1);
}

function AirAmmoPad::deployshape(%player,%item)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);

	if (GameBase::getLOSInfo(%player,4))
	{
		%shape = (GameBase::getDataName($los::object)).shapeFile;
		if (%shape != "cube2")
		{
			if ($TeamItemCount[%team @ "AirFuserPad"] < $TeamItemMax["AirFuserPad"] )
			{
				if(checkDeployArea(%client,$los::position))
				{
					%object = (deployable(%player, AirFuserPad, "StaticShape", "Air Fuser Ground Unit", True, False, True, False, True, False, 5, True, False, True, "GroundUnit", "AirFuserPad") );
					if (%object) return true;
				}
			}
			else
			{
				systemMessage(%client,1,"Team item limit reached for Air Fuser Ground Units.");
				if ($TeamItemCount[%team @ %item] < $TeamItemMax[%item] ) systemMessage(%client,1,"Deploy this pack on an existing Air Fuser Ground Unit.");
			}
		}
		else
		{
			if ($TeamItemCount[%team @ %item] < $TeamItemMax[%item] )
			{
				%trans = "1 0 0 0 0 1 0 -1 0 "@Vector::add(GameBase::getPosition($los::object),"0 0 2");
				%vel = Item::getVelocity($los::object);
				%inv = $los::object;
				%obj = Projectile::spawnProjectile(AirFuserRiser,%trans,%inv,%vel);
				$TeamItemCount[%team @ %item]++;
				%obj.deployer = %client;
				AirFuser(%obj,$los::object,%client,%team,%item);
				return true;
			}
			else systemMessage(%client,1,"Team item limit reached for Air Fusers.");
		}
	}
	else systemMessage(%client,1,"Deploy position out of range.");
	return false;
}

//========================
//==Area Effect Items l
//========================
//xxx
//========================Antenna pack

ItemImageData AntennaPackImage
{
	shapeFile = "anten_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData AntennaPack
{
	description = "Antenna";
	shapeFile = "anten_small";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = AntennaPackImage;
	shadowDetailMask = 4;
	elasticity = 0.1;
	price = 3000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AntennaPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AntennaPack::onDeploy(%player,%item,%pos)
{
	if (AntennaPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function AntennaPack::deployShape(%player,%item)
{
	%object = (deployable(%player, AntennaPack, "StaticShape", "Antenna", True, False, False, True, True, True, 5, True, False, False, SmallAntenna, "AntennaPack") );
	if (%object)
	{
		%client = Player::getClient(%player);
		%team = gamebase::getteam(%player);
		if (%team == 0) %eteam = 1;
		else %eteam = 0;
		TeamMessages(3, %team, Client::getName(%client) @ ": Enemy Communication Interecept Antenna going online...~wsensor_deploy.wav");
		if (%eteam.scramb == True) TeamMessages(1, %eteam, "Encryptor Alert! " @ Client::getName(%client) @ " erected an Intercept Antenna!~wpulse_power.wav");
		if (%team == 0) %eteam = 1;
		else %eteam = 0;
		if (%eteam.smrtpck)
		{
			%opos = GameBase::getPosition(%player);
			%posX = getWord(%opos,0);
			%posY = getWord(%opos,1);
			%eclient=%eteam.smrtpck;
			schedule("TeamMessages(1," @ %eteam @ ", \"Vigil: Alert! Enemy erected an Incercept Antenna!~wmine_act.wav");
			teamwaypointer(%eclient, %eteam, "Antenna at WayPoint", %posX, %posY);
		}
		bottomprint(%client,"<jc>Team Technology Bonus: 5 points");
		%client.score = (%client.score +5);
		%team.anten = True;
		return true;
	}
}

//========================Arbitor Beacon
ItemImageData ArbitorBeaconPackImage
{
	shapeFile = "plasammo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData ArbitorBeaconPack
{
	description = "Area Stealth Device";
	shapeFile = "plasammo";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = ArbitorBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ArbitorBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Stealth Beacon Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ArbitorBeaconPack::onDeploy(%player,%item,%pos)
{
	if (ArbitorBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ArbitorBeaconPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Area Stealth",False,False,False,False,False,True,5,True,25,True, "ArbitorBeacon", "ArbitorBeaconPack");
}

//========================EMP Beacon
ItemImageData EMPBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData EMPBeaconPack
{
	description = "EMP Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = EMPBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function EMPBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The EMP Beacon Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function EMPBeaconPack::onDeploy(%player,%item,%pos)
{
	if (EMPBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function EMPBeaconPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","EMPBeacon",True,False,False,False,False,False,5,True,25,True, "EMPBeacon", "EMPBeaconPack");
}

//========================Shield Beacon
ItemImageData JammerBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData JammerBeaconPack
{
	description = "Missile Defense Beacon";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = JammerBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function JammerBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Jammer Beacon Has A 50m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function JammerBeaconPack::onDeploy(%player,%item,%pos)
{
	if (JammerBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function JammerBeaconPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","JammerBeacon",True,False,False,False,False,False,5,True,25,True, "JammerBeacon", "JammerBeaconPack");
}

//========================Motion Sensor

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
   	heading = "lArea Effect Items";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MotionSensorPack::onUse(%player,%item)
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

function MotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (MotionSensorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

function MotionSensorPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Sensor","Motion Sensor",False,False,False,False,False,False,5,True,0, False, "DeployableMotionSensor", %item);
}

//========================Pulse Sensor

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
   	heading = "lArea Effect Items";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PulseSensorPack::onUse(%player,%item)
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
function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (PulseSensorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
function PulseSensorPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Sensor","Pulse Sensor",False,False,False,False,False,False,5,True,0, False, "DeployablePulseSensor", %item);
}

//========================SkyEye

ItemImageData SkyEyePackImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	mass = 4;
};

ItemData SkyEyePack
{
	description = "Satellite Dish";
	shapeFile = "radar_small";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = SkyEyePackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 3000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function CreateSkyEyeSimSet()
{
    	%teleset = nameToID("MissionCleanup/SkyEye");
	if(%teleset == -1)
	{
		newObject("SkyEye",SimSet);
		addToSet("MissionCleanup","SkyEye");
	}
}
function SkyEyePack::onUse(%player,%item)
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
function SkyEyePack::onDeploy(%player,%item,%pos)
{
	if (SkyEyePack::deployShape(%player,"Satellite Uplink",SatBig,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "SkyEyePack"]++;
	}
}

function SkyEyePack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ "SkyEyePack"] < $TeamItemMax[SkyEyePack]) {

	if (GameBase::getLOSInfo(%player,5))
	{
		%obj = getObjectType($los::object);
		if (%obj == "SimTerrain")
		{
			if (Vector::dot($los::normal,"0 0 1") > 0.7)
			{
				if(checkDeployArea(%client,$los::position))
				{
					%poss = $los::position;

					%sensor = newObject("Satellite Uplinked","StaticShape",%shape,true);
					CreateSkyEyeSimSet();
					addToSet("MissionCleanup/SkyEye", %sensor);
					addToSet("MissionCleanup", %sensor);
					%pos = Vector::add($los::position,"0 0 0");
					GameBase::setPosition(%sensor,%pos);
					GameBase::setMapName(%sensor,%name);
					GameBase::setTeam(%sensor,GameBase::getTeam(%player));
					playSound(SoundPickupBackpack,$los::position);
					systemMessage(%client,0,%item.description @ " assembled.");
					%sensor.disabled = false;
					%sensor.nukable = "True";

					%beam = newObject("Satellite Uplink","Sensor",SatSensor,true);
					addToSet("MissionCleanup", %beam);
					GameBase::setTeam(%beam,GameBase::getTeam(%player));
					GameBase::setPosition(%beam,%pos);
					GameBase::setMapName(%sensor,%name);
					TeamMessages(3, GameBase::getTeam(%player), Client::getName(%client) @ ": Establishing SkyEye Satellite UpLink.~wsensor_deploy.wav");
					%sensor.beam1 = %beam;
      				systemMessage(%client,0,"Establishing Satellite Reconnaissance: 5 points.");
					bottomprint(%client,"<jc>Team Technology Bonus: 5 points");
					%client.score = (%client.score +5);
					if (%team == 0) %eteam = 1;
					else %eteam = 0;
					if (%eteam.smrtpck)
					{
						%eclient=%eteam.smrtpck;
						%opos = GameBase::getPosition(%player);
						%posX = getWord(%opos,0);
						%posY = getWord(%opos,1);
						TeamMessages(1,%eteam,"Vigil: Alert! Enemy established a Sky Eye Satellite Uplink!~wmine_act.wav");
						teamwaypointer(%eclient, %eteam, "SatDish at WayPoint", %posX, %posY);
					}
					return true;
				}
			}
			else
				systemMessage(%client,0,"Can only deploy on flat surfaces.");
		}
		else
			systemMessage(%client,0,"Can only deploy on terrain.");
		}
		else
			systemMessage(%client,0,"Deploy position out of range.");
	}
	else
	 	systemMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s.");
	return false;
}

function SatBig::onDestroyed(%this)
{
	TeamMessages(1, GameBase::getTeam(%this), "SkyEye Satellite UpLink Lost.~wfloat_explode.wav");
	schedule("deleteObject("@%this.beam1@");",1);
}

//========================Sensor Jammer

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
   	heading = "lArea Effect Items";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	elasticity = 0.2;
  	price = 225;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DeployableSensorJammerPack::onUse(%player,%item)
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

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos)
{
	if (DeployableSensorJammerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
function DeployableSensorJammerPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Sensor","Sensor Jammer",False,False,False,False,False,False,5,True,0, False, "DeployableSensorJammer", %item);
}

//========================Shield Beacon
ItemImageData ShieldBeaconPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData ShieldBeaconPack
{
	description = "Shield Device";
	shapeFile = "bridge";
	className = "Backpack";
   	heading = "lArea Effect Items";
	imageType = ShieldBeaconPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 1350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldBeaconPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	        bottomprint(Player::getClient(%player), "<jc><f2>The Shield Beacon Has A 25m Range.", 5);
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function ShieldBeaconPack::onDeploy(%player,%item,%pos)
{
	if (ShieldBeaconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ShieldBeaconPack::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","ShieldBeacon",True,False,False,False,False,False,5,True,25,True, "ShieldBeacon", "ShieldBeaconPack");
}

//========================
// Personnel Movers s
//========================
//xxx
//========================Accel Pad

ItemImageData AccelPPackImage
{
	shapeFile = "shieldpack";
	mountPoint = 2;
	firstPerson = false;
	mass = 2;
};

ItemData AccelPPack
{
	description = "Accelerator Pad";
	shapeFile = "elevator_6x6_octagon";
	className = "Backpack";
	heading = "sPersonnel Movers";
	imageType = AccelPPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 950;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AccelPPack::onUse(%player,%item)
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

function AccelPPack::onDeploy(%player,%item,%pos)
{
	if (AccelPPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"]++;
	}
}

function CreateAccelPadSimSet()
{
	%teleset = nameToID("MissionCleanup/AccelPadPack");
	if(%teleset == -1)
	{
		newObject("AccelPadPack",SimSet);
		addToSet("MissionCleanup","AccelPadPack");
	}
}

function AccelPPack::deployShape(%player,%item)
{
	%object = ( deployable(%player,%item,"StaticShape","Accelerator Pad", True, False, False, False, True, True, 4, True, False, False, "AccelPadPack", %item) );
	if (%object)
	{
		%pos = Vector::add($los::position,"0 0 -0.25");
		GameBase::setPosition(%player,Vector::add(%pos,"0 0 1"));
		GameBase::setPosition(%object,%pos);
		return true;
	}
}

//============================================== Elevator

ItemImageData ElevatorImage
{
	shapeFile = "dsply_v2";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData Elevator
{
	description = "Elevator";
	shapeFile = "dsply_v2";
	className = "Backpack";
    	heading = "sPersonnel Movers";
	imageType = ElevatorImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Elevator::onUse(%player,%item)
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

function Elevator::onDeploy(%player,%item,%pos)
{
	if (Elevator::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function Elevator::deployshape(%player,%item)
{
	%client = Player::getClient(%player);
	if(!GameBase::getLOSInfo(%player,4))
	{
		systemMessage(%client,1,"Deploy position out of range.");
		return false;
	}
	%team = GameBase::getTeam (%client);
	%obj = newObject("Elevator Pad","StaticShape","ElevatorTurr");
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam (%obj,%team);
	%pos = Vector::add(Gamebase::getPosition(%player), EmplacementPack::rotVector( "0 1 0", GameBase::getRotation(%player) ) );
	%rot = Vector::add(Gamebase::getRotation(%player), "1.57 0 0");
	GameBase::setPosition(%obj, %pos);
	GameBase::setRotation(%obj, %rot);
	%obj.origpos = %pos;
	%obj.nukable = "True";

	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "Elevator"]++;
	systemMessage(%client,0,"Elevator deployed.");
	return true;
}

//========================Launch Pad

ItemImageData LaunchPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = {0, -0.03, 0};
	mass = 1.0;
	firstPerson = false;
};

 ItemData LaunchPack
 {
 	description = "Launch Pad";
 	shapeFile = "AmmoPack";
 	className = "Backpack";
	heading = "sPersonnel Movers";
 	imageType = LaunchPackImage;
 	shadowDetailMask = 4;
 	elasticity = 0.2;
 	price = 500;
 	hudIcon = "deployable";
 	showWeaponBar = true;
 	hiliteOnActive = true;
 };

 function LaunchPack::onUse(%player,%item)
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

 function LaunchPack::onDeploy(%player,%item,%pos)
 {
 	if (LaunchPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
 }

function LaunchPack::deployShape(%player,%item)
{
	deployable(%player, %item, "StaticShape", "Launchboard", True, False, False, False, True, True, 5, True, False, False, DeployableLaunch, %item);
}

//========================MagBridge Pack

ItemImageData MagBridgeImage
{
	shapeFile = "dsply_s1";
	mountPoint = 2;
	mountOffset = { 0, 0.1, -0.4 };
	mass = 2;
	firstPerson = false;
};

ItemData MagBridgePack
{
	description = "Magneto Bridge";
	shapeFile = "dsply_s1";
	className = "Backpack";
   	heading = "sPersonnel Movers";
	shadowDetailMask = 4;
	imageType = MagBridgeImage;
	price = 400;
	hudIcon = "deployables";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function MagBridgePack::onUse(%player,%item)
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

function MagBridgePack::onDeploy(%player,%item,%pos)
{
	if (MagBridgePack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function MagBridgePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "MagBridgePack"] < $TeamItemMax["MagBridgePack"])
	{
		%rot = Vector::add( Vector::getRotation(%player), "0 1.57 0" );
		%pos = gamebase::getposition(%player);
		%fField = newObject("Magneto Bridge","StaticShape",MagBridge,true);
		addToSet("MissionCleanup", %fField);
		GameBase::setTeam(%fField,GameBase::getTeam(%player));
		GameBase::setPosition(%fField,Vector::add(%pos, EmplacementPack::rotVector( "0 -2 0", GameBase::getRotation(%player))));
		GameBase::setRotation(%fField,%rot);
            GameBase::setMapName(%fField,"Magneto Bridge");
      	systemMessage(%client,0,"Magneto Bridge deployed.");
		$TeamItemCount[GameBase::getTeam(%player) @ "MagBridgePack"]++;
		GameBase::startFadeIn(%fField);
		return true;
	}
	else systemMessage(%client,0,"Magneto Bridge already employed.");
return false;
}

//========================Portal itself
StaticShapeData Portal
{
	shapeFile = "plasmawall";
	debrisId = defaultDebrisLarge;
	maxDamage = 5.00;
	isTranslucent = true;
	visibleToSensor = true;
	description = "Portal";
};

function Portal::onCollision(%this,%obj)
{
	%clientId = Player::getClient(%obj);
	%player = %obj;
	%armor = Player::getArmor(%clientId);
	%data = GameBase::getDataName(%obj); if(%data.shapefile == "rocket") {	GameBase::setDamageLevel(%obj, 10); return; }
	if(%this.activated==True || Player::isDead(%obj))
	{
		return;
	}

	else
	{
		GameBase::applyDamage(%player,$TrapDam1,0.01,GameBase::getPosition(%player),"0 0 0","0 0 0",%this);
	}
	return;
}
function Portal::onDestroyed(%this)
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "HolePack"]--;
}

//========================Portable Hole pack
ItemImageData HolePackImage
{
	shapeFile = "display_three";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData HolePack
{
    description = "Portable Hole";
    shapeFile = "display_three";
    className = "Backpack";
    heading = "sPersonnel Movers";
    imageType = HolePackImage;
    shadowDetailMask = 4;
    elasticity = 0.2;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function HolePack::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	%pos = GameBase::getPosition(%player);
 	%group = nameToID("MissionCleanup/jailports");
	%num = Group::objectCount(%group);
	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%group, %i);
		%homepos = GameBase::getPosition(%obj);
		if (Vector::getDistance(%pos,%homepos) < 10 && Client::getTeam(%client) == GameBase::getTeam(%obj))
		{
			systemMessage(%client,1,"Too close to your team's jail.");
			deleteObject(%set);
			return False;
		}
	}
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function HolePack::onDeploy(%player,%item,%pos)
{
	if (HolePack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
function HolePack::deployShape(%player,%item)
{
	%object = ( deployable(%player,%item,"StaticShape","Portal",False,False,False,False,False,False,5,True,25, True, "Portal", "HolePack") );
	if (%object)
	{
		%client = Player::getClient(%player);
		%team = Client::getTeam(%client);
		TeamMessages(0, %team, "Friendly Portal Deployed~welevator2.wav", -2, "Hull Breech!~welevator2.wav", "Hull Breech!~welevator2.wav");
      	systemMessage(%client,0,"Establishing team access: 2 points.");
      	%client.score = (%client.score +2);
		return true;
	}
}

//========================Zepplinpack

ItemImageData ZepplinPackImage
{
	shapeFile = "mineammo";
	mountPoint = 2;
	mountOffset = { 0, 0.1, 0 };
	mountRotation = { 1.57, 0, 0 };
	mass = 2;
	firstPerson = false;
};

ItemData ZepplinPack
{
	description = "Zepplin Pad";
	shapeFile = "mineammo";
	className = "Backpack";
	heading = "sPersonnel Movers";
	imageType = ZepplinPackImage;
	shadowDetailMask = 4;
	elasticity = 0.1;
	price = 3000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ZepplinPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ZepplinPack::onDeploy(%player,%item,%pos)
{
	if (ZepplinPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ZepplinPack::deployShape(%player,%item)
{
	%object = ( deployable(%player,%item,"StaticShape","Zepplin Pad",True,False,False,False,True,False,6,True,0, False, "ZepplinPad", %item) );
	if (%object)
	{
		%client = Player::getClient(%player);
		bottomprint(%client,"<jc>Team Technology Bonus: 5 points");
		%client.score = (%client.score +5);
		%object.zepop = %client.zepop;
		if (%object.zepop == -70) Gamebase::setMapName(%object,"Parachute Pad " @ Client::getName(%client));
		return true;
	}
}

//========================
//==Missile Items u
//========================

ItemImageData CoolLauncherImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = {0, -0.1, -0.06 };
	mountRotation = {0, 0, 0};
	firstPerson = false;
	mass = 3;
};

ItemData CoolLauncher
{
	description = "Missile Control Station";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "uGuided Missiles";
	imageType = CoolLauncherImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CoolLauncher::onUse(%player,%item)
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

function CoolLauncher::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>The Missile Control Station has no remote control and must be controlled manually to fire.");
}

function CoolLauncher::onDeploy(%player,%item,%pos)
{
	if (CoolLauncher::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
	}
}

function CoolLauncher::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,4))
		{
			%o = ($los::object);
			%obj = getObjectType(%o);
			%datab = GameBase::getDataName(%o);

			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %datab == "BlastFloor")
			{}else
			{
				systemMessage(%client,1,"Can only deploy on terrain or buildings...");
				return;
			}
				if (Vector::dot($los::normal,"0 0 1") > 0.94)
				{
					if(checkDeployArea(%client,$los::position))
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
						%rot = GameBase::getRotation(%player);
						%forward = Vector::getFromRot(%rot, 2);
						%pos = Vector::add($los::position, %forward);
						%turret = newObject("remoteTurret","Turret",DeployableCoolMortar,true);
						addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,%pos);
						GameBase::setRotation(%turret,%rot);
						Gamebase::setMapName(%turret,"Missile Control Station");
						systemMessage(%client,0,"Missile Control Station deployed");
						%inv = newObject("comunit_remote", "StaticShape", "DeployableCoolStation", true);
						addToSet("MissionCleanup", %inv);
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						%backward = Vector::neg(Vector::getFromRot(%rot, 2.5));
						GameBase::setPosition(%inv,Vector::add(%pos, %backward));
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,"Missile Control Station");
						%turret.comstation = %inv;
						%turret.load = "CoolProj";
						%inv.comstation = %turret;
						playSound(SoundPickupBackpack,$los::position);
						return true;
					}
				}
				else systemMessage(%client,0,"Can only deploy on very flat surfaces");
		}
		else systemMessage(%client,0,"Deploy position out of range");
	}
	else systemMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//========================Various Missile Data

$vm[PhoenixM] = CoolProj;
$vm[NapM] = NapProj;
$vm[BooM] = BooProj;
$vm[EmpM] = EmpProj;
$vm[GasM] = GasProj;
$vm[BallM] = BallProj;
$vm[SpyPod] = SpyPodProj;

ItemImageData PhoenixMImage
{
	shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = {0, -0.1, -0.3 };
	mountRotation = {0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

//========================Emp Damage Missile
ItemData EmpM
{
	description = "EMP Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function EmpM::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================CannonBall Missile
ItemData BallM
{
	description = "Human Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BallM::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================Napalm, fire damage missile
ItemData NapM
{
	description = "Napalm Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function NapM::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================Nuke Missile
ItemData BooM
{
	description = "Nuclear Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BooM::onUse(%player,%item)
{
	%team = GameBase::getTeam(%player);
	if (%team.nukgen == True)
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		{
			Player::mountItem(%player,%item,$BackpackSlot);
		}
	}
	else
	{
		systemMessage(Player::getClient(%player),1, "Your Team has no nuclear capability.~waccess_denied.wav");
	}
}

//========================Pheonix Missile
ItemData PhoenixM
{
	description = "Phoenix Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PhoenixM::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================Spy Missile
ItemData SpyPod
{
	description = "SpyPod Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	elasticity = 0.2;
	price = 2000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpyPod::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================Poison Damage Missile
ItemData GasM
{
	description = "Toxin Missile";
	shapeFile = "rocket";
	className = "Backpack";
	heading = "uGuided Missiles";
	shadowDetailMask = 4 ;
	imageType = PhoenixMImage;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function GasM::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//========================
// Flyer Module's v
//========================

ItemImageData FlyerModuleImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = {0, -0.1, -0.5 };
	mountRotation = {0, 0, 0 };
	mass = 1.0;
	firstPerson = false;
};

ItemData DetPackModule
{
	description = "DetPack Module";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "dProwler Modules";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData HellFireModule
{
	description = "HellFireModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "dProwler Modules";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemData RamModule
{
	description = "RamModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "dProwler Modules";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

ItemImageData TitanPackImage
{
  	shapeFile  = "cmdpnl";
	mountPoint = 2;
	mountOffset = { 0, 0.1, 1.3 };
	mountRotation = { 3.14, 0, 0 };
};

ItemData TitanPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
  	heading = "cBackpacks";
	imageType = TitanPackImage;
	shadowDetailMask = 4;
	elasticity = 0.2;
	price = 0;
	hudIcon = "ammopack";
	showWeaponBar = false;
	hiliteOnActive = false;
};


ItemData WraithModule
{
	description = "WraithModule";
	shapeFile = "ammopack";
	className = "VModule";
   	heading = "dProwler Modules";
	shadowDetailMask = 7;
	imageType = FlyerModuleImage;
	price = 500;
	hudIcon = "shieldpack";
	showWeaponBar = true;
};

//========================
// Security
//========================
//==xxx
//========================Base Control Switch

ItemImageData SwitchPackImage
{
	shapeFile = "teleport_vertical";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.7 };
	mass = 4;
	firstPerson = false;
};

ItemData SwitchPack
{
	description = "Base Control Switch";
	shapeFile = "tower";
	className = "Backpack";
	heading = "vSecurity Items";
	imageType = SwitchPackImage;
	shadowDetailMask = 4;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SwitchPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot);
	else Player::deployItem(%player,%item);
}

function SwitchPack::onDeploy(%player,%item,%pos)
{
	if (SwitchPack::deployShape(%player,%item)) Player::decItemCount(%player,%item);
}

function SwitchPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player);
						%fField = newObject("Switch","StaticShape",BaseSwitch,true);
						addToSet("MissionCleanup", %fField);
						GameBase::setTeam(%fField,"4");
						GameBase::setPosition(%fField,$los::position);
						GameBase::setRotation(%fField,%rot);
						Gamebase::setMapName(%fField,"Base Control Switch");
						GameBase::startFadeIn(%fField);
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "SwitchPack"]++;
						schedule ("StealBase(" @ %fField @ ", 30," @  %client @ ");",3);
						systemMessage(%client,0, "Wait... scanning powergrids...~wsensor_deploy.wav");
						systemMessage(%client,1, "~wfemale1.wwait1.wav");
						TeamMessages(1, Client::getTeam(%client), "", -2, "null", "Mother of Pearl!!! " @ Client::getName(%client) @ " is trying to install the diabolical Base Control Switch on us!~wfemale1.wbasundr.wav");
						return true;
					}
				}
				else systemMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else systemMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else systemMessage(%client,0,"Deploy position out of range");
	}
	else systemMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//========================SmartPack: Base Smart Security

ItemImageData SmartPackImage
{
	shapeFile = "dsply_s1";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.4 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 1;
};

ItemData SmartPack
{
	description = "Base Vigil Security";
	shapeFile = "dsply_s1";
	className = "Backpack";
	heading = "vSecurity Items";
	shadowDetailMask = 4;
	imageType = SmartPackImage;
	price = 300;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function SmartPack::onUse(%player,%item)
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

function SmartPack::onDeploy(%player,%item,%pos)
{
	if (SmartPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function SmartPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	if($TeamItemCount[%team @ "SmartPack"] < $TeamItemMax["SmartPack"])
	{
		if (GameBase::getLOSInfo(%player,4))
		{
			if (Vector::dot($los::normal,"0 0 1") < 0.7 )
			{
				if(checkDeployArea(%client,$los::position))
				{
					%rot = Vector::add( Vector::getRotation($los::normal), "1.571 0 3.14" );
					%fField = newObject("Vigil Security","StaticShape",BluePanel,true);
					addToSet("MissionCleanup", %fField);
					GameBase::setTeam(%fField,%team);
					GameBase::setPosition(%fField,$los::position);
					GameBase::setRotation(%fField,%rot);
                			GameBase::setMapName(%fField,"Vigil Security");
					%team.smrtpck = %client;
					%fField.tc = %client;
					TeamMessages(3, %team, Client::getName(%client) @ ": Base Vigil Security System installed!~wmine_act.wav");
					if (%team == 0) %eteam = 1;
					else %eteam = 0;
					if (%eteam.anten == True) schedule("TeamMessages(1," @ %team @ ", \"Vigil: Alert! Enemy has an Intercept Antenna!~wmine_act.wav\");", 3);
					if (%eteam.scramb == True) schedule("TeamMessages(1," @ %team @ ", \"Vigil: Alert! Enemy has Chat Encryption!~wmine_act.wav\");", 6);
					if (%eteam.nukgen == True) schedule("TeamMessages(1," @ %team @ ", \"Vigil: Alert! Enemy has Nuclear Capability!~wmine_act.wav\");", 9);
     					$TeamItemCount[%team @ "SmartPack"]++;
					GameBase::startFadeIn(%fField);
					schedule ("SmartBase::check(" @ %fField @ ");",1);
					bottomprint(%client,"<jc>Team Technology Bonus: 5 points");
					%client.score = (%client.score +5);
					return true;
				}
			}
			else
				systemMessage(%client,0,"Cannot deploy underfoot.");
		}
		else
			systemMessage(%client,0,"Deploy position out of range");
	}
	else
	 	systemMessage(%client,0,"Base Security already installed.");

	return false;
}


//========================Recon Pack : Chat Secure

ItemImageData ReconPackImage
{
	shapeFile = "dsply_s2";
	mountPoint = 2;
	mountOffset = { 0, 0.1, -0.4 };
	firstPerson = false;
	mass = 1;
};

ItemData ReconPack
{
	description = "Chat Encryptor";
	shapeFile = "dsply_s2";
	className = "Backpack";
   heading = "vSecurity Items";
	shadowDetailMask = 4;
	imageType = ReconPackImage;
	price = 300;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function ReconPack::onUse(%player,%item)
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

function ReconPack::onDeploy(%player,%item,%pos)
{
	if (ReconPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ReconPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "ReconPack"] < $TeamItemMax["ReconPack"])
	{
		if (GameBase::getLOSInfo(%player,4))
		{
			if (Vector::dot($los::normal,"0 0 1") < 0.7 )
			{
				if(checkDeployArea(%client,$los::position))
				{
					%rot = Vector::add( Vector::getRotation($los::normal), "1.571 0 0" );
					%fField = newObject("Chat Encryptor","StaticShape",HTwoPanel,true);
					addToSet("MissionCleanup", %fField);
					%team = Client::getTeam(%client);
					GameBase::setTeam(%fField,%team);
					GameBase::setPosition(%fField,$los::position);
					GameBase::setRotation(%fField,%rot);
                			GameBase::setMapName(%fField,"Chat Encryptor");
					%team.scramb = True;
					TeamMessages(3, %team, Client::getName(%client) @ ": Team Chat now encrypted and secure!~wpulse_power.wav");
					if (%team == 0) %eteam = 1;
					else %eteam = 0;
					if (%eteam.smrtpck)
					{
						%opos = GameBase::getPosition(%player);
						%posX = getWord(%opos,0);
						%posY = getWord(%opos,1);
						%eclient=%eteam.smrtpck;
						TeamMessages(1,%eteam,"Vigil: Alert! Enemy has Chat Encryption!~wmine_act.wav");
						teamwaypointer(%eclient, %eteam, "Encryptor at WayPoint", %posX, %posY);
					}
     					$TeamItemCount[%team @ "ReconPack"]++;
					bottomprint(%client,"<jc>Team Technology Bonus: 5 points");
					%client.score = (%client.score +5);
					GameBase::startFadeIn(%fField);
					return true;
				}
			}
			else
				systemMessage(%client,0,"Cannot deploy underfoot.");
		}
		else
			systemMessage(%client,0,"Deploy position out of range");
	}
	else
	 	systemMessage(%client,0,"Chat Encryptor already employed.");

	return false;
}

//===============Spawn Killer Marker
ItemImageData BasePackImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.2};
	firstPerson = false;
	mass = 1;
};

ItemData BasePack
{
	description = "Invasion Marker";
	shapeFile = "flag";
	className = "Backpack";
	heading = "vSecurity Items";
	shadowDetailMask = 4;
	imageType = BasePackImage;
	showInventory = True;
	shadowDetailMask = 4;
	mapIcon = "M_camera";
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BasePack::onUse(%player,%item)
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

function BasePack::onDeploy(%player,%item,%pos)
{
	if (BasePack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function BasePack::deployShape(%player,%item)
{
	%object = ( deployable(%player,%item,"StaticShape","Base Invasion Marker",True,False,False,False,True,False,4,True,0, False, "BaseKill", %item) );
	if (%object)
	{
		%object.nukable = "True";
		%client = Player::getClient(%player);
		%team = gamebase::getteam(%player);
		if (%team == 0) %eteam = 1;
		else %eteam = 0;

		%beam = newObject("Base Invasion Marker","Sensor",DeployablePulseSensor,true);
		addToSet("MissionCleanup", %beam);
		GameBase::setTeam(%beam,%team);
		GameBase::setPosition(%beam,$los::position);
		Gamebase::setMapName(%beam,"Base Invasion Marker");

		%team.spntrpos = GameBase::getPosition(%player);

		TeamMessages(3, %team, Client::getName(%client) @ " established an offensive outpost!~wfemale1.wattbase.wav");
		if (%eteam.smrtpck)
		{
			%opos = GameBase::getPosition(%player);
			%posX = getWord(%opos,0);
			%posY = getWord(%opos,1);
			%eclient=%eteam.smrtpck;
			TeamMessages(1, %eteam, "Vigil: " @ Client::getName(%client) @ " erected an Invader's Marker!~wfemale1.wbasundr.wav");
			teamwaypointer(%eclient, %eteam, "Invasion at WayPoint", %posX, %posY);
		}
		bottomprint(%client,"<jc>Team Technology Bonus: 5 points");
		%client.score = (%client.score +5);

		return true;
	}
}

function BasePack::onMount(%player,%imageSlot)
{
	Bottomprint(Player::getClient(%player), "This marker allows for a small area of spawn-turrets to defend an invasive outpost.");
}

ItemImageData jailpackImage
{
	shapeFile = "dsply_s1";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.4 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 4;
};

ItemData jailpack
{
	description = "Jail Cell";
	shapeFile = "dsply_s1";
	className = "Backpack";
	heading = "vSecurity Items";
	imageType = jailpackImage;
	shadowDetailMask = 4;
	price = 9000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function jailpack::onUse(%player,%item)
{
   	if($noBuilding)
	{
		%client = Player::getClient(%player);
		systemMessage(%client,1,"Building disabled in this mission.~wC_BuySell.wav");
	}
	else
	{
		if (Player::getMountedItem(%player,$BackpackSlot) != %item)
			Player::mountItem(%player,%item,$BackpackSlot);
		else
			Player::deployItem(%player,%item);
	}
}

function jailpack::onDeploy(%player,%item,%pos)
{
	if (jailpack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}
function CreatejailportSimSet()
{
    %teleset = nameToID("MissionCleanup/jailports");
	if(%teleset == -1)
	{
		newObject("jailports",SimSet);
		addToSet("MissionCleanup","jailports");
	}
}

function makejail(%obj,%playerpos,%client,%team,%item,%playerrot,%veh)
{
	if (%veh !="" && %veh != -1 && %veh != false) deleteObject(%veh);
	if (getObjectType(%obj) != "RocketDumb")
	{
		messageall(0,"Unable to build Jail, objects in the way.");
		$TeamItemCount[%team @ %item]--;
		return;
	}
	%x = GameBase::getPosition(%obj);
	%posX = getWord(%x,2);
	%posY = getWord(%playerpos,2);
	if ((%posX - %posY) >50)
	{
		deleteObject(%obj);

	%set = newObject("Jail",SimSet);

	%objDevice =  newObject("Jail","InteriorShape","bunker4.1.dis",true);
	%objDevice.objSide5 = newObject("Jail","StaticShape",JailSwitchOpen,true);
	%objDevice.objSide6 = newObject("Jail","StaticShape",JailSwitchOpen,true);

	%objDevice.objSide5.objParent = %objDevice;
	%objDevice.objSide6.objParent = %objDevice;

	addToSet(MissionCleanup, %objDevice);
	addToSet(MissionCleanup, %objDevice.objSide5);
	addToSet(MissionCleanup, %objDevice.objSide6);

	%pos = Vector::add(%playerpos, "0 0 80");
	GameBase::setRotation(%objDevice,"0 0 0");
	GameBase::setPosition(%objDevice,%pos);
	GameBase::setTeam(%objDevice,%team);

	%pos = Vector::add(%playerpos, "-2.229 -4.841 80");
	GameBase::setRotation(%objDevice.objSide5,"0 0 0");
	GameBase::setPosition(%objDevice.objSide5,%pos);
	GameBase::setTeam(%objDevice.objSide5,%team);
	%objDevice.objSide5.base = "True";

	%pos = Vector::add(%playerpos, "2.219 -4.817 80");
	GameBase::setRotation(%objDevice.objSide6,"0 0 0");
	GameBase::setPosition(%objDevice.objSide6,%pos);
	GameBase::setTeam(%objDevice.objSide6,%team);
	%objDevice.objSide6.base = "True";

	playSound(bigExplosion2,%pos);

	%sensor = newObject("Teleport Pad","StaticShape","jailStand",true);
	CreatejailportSimSet();
	addToSet("MissionCleanup/jailports", %sensor);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,%team);
	%pos = Vector::add(%playerpos, "0.242 0.353 81.0");
	GameBase::setPosition(%sensor,%pos);
	Gamebase::setMapName(%sensor,%name);
	%sensor.disabled = false;

	CreateBunkerSet(%client);

	%name1 = "FF1"; %name2 = "FF2"; %name3 = "FF3"; %name4 = "FF4";

	instant StaticShape %name1
	{
		dataBlock = "ForceField3";
		name = %name1;
		position = Vector::add(%playerpos, "4.269 0.488 80.6");
		rotation = "0 0 1.57";
		destroyable = "False";
		deleteOnDestroy = "False";
		base = "true";
	};
	instant StaticShape %name2
	{
		dataBlock = "ForceField3";
		name = %name2;
		position = Vector::add(%playerpos, "-4.26 0.525 80.6");
		rotation = "0 0 1.57";
		destroyable = "False";
		deleteOnDestroy = "False";
		base = "true";
	};

	instant StaticShape %name3
	{
		dataBlock = "ForceField3";
		name = %name3;
		position = Vector::add(%playerpos, "0 -3.27 80.6");
		rotation = "0 0 0";
		destroyable = "False";
		deleteOnDestroy = "False";
		base = "true";
	};

	instant StaticShape %name4
	{
		dataBlock = "ForceField3";
		name = %name4;
		position = Vector::add(%playerpos, "0.031 4.288 80.6");
		rotation = "0 0 0";
		destroyable = "False";
		deleteOnDestroy = "False";
		base = "true";
	};

	addToSet("MissionCleanup",%name1);
	addToSet("MissionCleanup",%name2);
	addToSet("MissionCleanup",%name3);
	addToSet("MissionCleanup",%name4);

	%n1 = (nametoId("MissionCleanup" @ %client @ "/" @ %name1));
	%n2 = (nametoId("MissionCleanup" @ %client @ "/" @ %name2));
	%n3 = (nametoId("MissionCleanup" @ %client @ "/" @ %name3));
	%n4 = (nametoId("MissionCleanup" @ %client @ "/" @ %name4));

	%n1.base = "true";
	%n2.base = "true";
	%n3.base = "true";
	%n4.base = "true";

	gamebase::setteam(%n1, %team);
	gamebase::setteam(%n2, %team);
	gamebase::setteam(%n3, %team);
	gamebase::setteam(%n4, %team);

	%sensor.beam = %objDevice;
	%sensor.beam1 = %n1;
	%sensor.beam2 = %n2;
	%sensor.beam3 = %n3;
	%sensor.beam4 = %n4;
	%sensor.beam5 = %objDevice.objSide5;
	%sensor.beam6 = %objDevice.objSide6;

	echo("MSG: ",%client," deployed a Jail Cell");
	systemMessage(%client,0,%item.description @ " deployed 80 meters up");
   }
   else schedule ("makejail(\"" @ %obj@ "\",\"" @ %playerpos @ "\",\"" @ %client @ "\",\"" @ %team @ "\",\"" @ %item @ "\",\"" @ %playerrot @ "\");",0.1);
}

function jailpack::deployshape(%player,%item)
{
  %client = Player::getClient(%player);
  %team = gamebase::getteam(%client);
  if (GameBase::getLOSInfo(%player,5))
  {
	if($TeamItemCount[%team @ "jailpack"] >= $TeamItemMax[jailpack])
	{
		systemMessage(%client,0,"Cannot Deploy Jail Cell: one is already in place.");
		return false;
	}
	%playerpos = GameBase::getPosition(%player);
	if (checkDeployArea(%client,Vector::add(%playerpos,"0 0 80"),5,5,5))
	{
		%trans = "1 0 0 0 0 1 0 -1 0 "@%playerpos;
		%vel = Item::getVelocity(%player);
		%obj = Projectile::spawnProjectile(JailRiser,%trans,%player,%vel);
		$TeamItemCount[%team @ %item]++;
		%playerrot = GameBase::getRotation(%player);
		//=== Don't let the jail deploy underground====
		%veh = newObject(Test,flier,Scout,true);
		addToSet("MissionCleanup",%veh);
		%playerPos = Vector::add(GameBase::getPosition(%player), "0 0 5");
		GameBase::setPosition(%veh,Vector::add(%playerPos, "0 0 5"));
		//=============================================
		schedule ("makejail(\"" @ %obj @ "\" , \"" @ %playerpos @ "\" , \"" @ %client @ "\", \"" @ %team @ "\", \"" @ %item @ "\", \"" @ %playerrot @ "\", \"" @ %veh @ "\");",0.2);
		return true;
	}
  }
  else
  {
	systemMessage(%client,0,"Object out of range");
  	return false;
  }
}

ItemImageData JailCapPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	mass = 1;
	firstPerson = false;
};

ItemData JailCapPack
{
    description = "Jail Capture Pad";
    shapeFile = "flagstand";
    className = "Backpack";
   heading = "vSecurity Items";
    imageType = JailCapPackImage;
    shadowDetailMask = 4;
    price = 500;
    hudIcon = "deployable";
    showWeaponBar = true;
    hiliteOnActive = true;
};

function JailCapPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function JailCapPack::onDeploy(%player,%item,%pos)
{
	if (JailCapPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}
function JailCapPack::deployShape(%player,%item)
{
	deployable(%player,%item,"StaticShape","Jail Pad",True,False,False,False,False,False,4,True,100, True, "JailPad", "JailCapPack");
}
function JailCapPack::onMount(%player,%imageSlot)
{
	if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] < $TeamItemMax["jailpack"])
		Bottomprint(Player::getClient(%player), "<jc>Your Team Has No Jail Cell Yet");
}
//========================JailGun
ItemImageData JailGunImage
{
          shapeFile = "paintgun";
           mountPoint = 0;
           weaponType = 2;
           projectileType = jailbolt;
           minEnergy = 2;
           maxEnergy = 80;
           reloadTime = 1.0;
          lightType = 3;
          lightRadius = 2;
          lightTime = 1;
          lightColor = { 0.25, 0.25, 0.85 };
          sfxActivate = SoundPickUpWeapon;
          sfxFire     = SoundELFIdle;
};

ItemData JailGun
{
   heading = "vSecurity Items";
   description = "Jailer's Gun";
        className = "Weapon";
        hudIcon = "energyRifle";
        shapeFile  = "paintgun";
        shadowDetailMask = 4;
        imageType = JailGunImage;
        price = 385;
        showWeaponBar = true;
};

//========================Sentry

ItemImageData SentryImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2;
};

ItemData Sentry
{
	description = "Sentry";
	shapeFile = "remoteturret";
	className = "Backpack";
    	heading = "vSecurity Items";
	imageType = SentryImage;
	shadowDetailMask = 4;
	price = 700;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Sentry::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function Sentry::onDeploy(%player,%item,%pos)
{
	if (Sentry::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function Sentry::deployShape(%player,%item)
{
	deployable(%player,%item,"Turret","Sentry",False,False,False,False,False,False,5,True,20, True, "SentryTurret", "Sentry");
}

function Sentry::onMount(%player,%item) 
{
	if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] < $TeamItemMax["jailpack"])
		Bottomprint(Player::getClient(%player), "<jc>Your Team Has No Jail Cell Yet");
}

//========================LockOut Pack

ItemImageData LockoutPackImage
{
	shapeFile = "dsply_s1";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.4 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2;
};

ItemData LockOutPack
{
	description = "Switch Lock";
	shapeFile = "dsply_s1";
	className = "Backpack";
   heading = "vSecurity Items";
	shadowDetailMask = 4;
	imageType = LockOutPackImage;
	price = 300;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function LockOutPack::onUse(%player,%item)
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

function LockOutPack::onDeploy(%player,%item,%pos)
{
	if (LockOutPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function LockOutPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "LockOutPack"] < $TeamItemMax["LockOutPack"])
	{
		if (GameBase::getLOSInfo(%player,4))
		{
			%shape = (GameBase::getDataName($los::object)).shapeFile;
			if (%shape == "tower")
			{
				%rot = GameBase::getRotation(%player);
				%pos = Vector::add(Gamebase::getPosition($los::object), EmplacementPack::rotVector("-1.4 0 0", %rot));
				%fField = newObject("Switch Security System","StaticShape",HOnePanel,true);
				addToSet("MissionCleanup", %fField);
				%team = GameBase::getTeam(%player);
				GameBase::setRotation(%fField,%rot);
				GameBase::setPosition(%fField,%pos);
				GameBase::setTeam(%fField,%team);
                		GameBase::setMapName(%fField,"Switch Security System");
     				$TeamItemCount[%team @ "LockOutPack"]++;
				schedule ("LockBase(" @ %fField @ ", 3," @  %client @ ");",3);
				systemMessage(%client,0, "Wait... scanning switch network for team items...~wsensor_deploy.wav");
				systemMessage(%client,1, "~wfemale1.wwait1.wav");
				GameBase::startFadeIn(%fField);
				%fField.nukable = "True";
				return true;
			}
			else
				systemMessage(%client,0, "Must deploy a Switch Lock on a switch!~wfemale1.wdsgst1.wav");
		}
		else
			systemMessage(%client,0,"Deploy position out of range");
	}
	else
	 	systemMessage(%client,0,"Switch Lock in use.");

	return false;
}

//========================
//==Miscellany w
//========================

//========================Beacons

ItemData Beacon
{
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = "wMiscellany";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	validateShape = true;
	validateMaterials = true;
};

function Beacon::onUse(%player,%item)
{
	%team = GameBase::getTeam(%player);
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);

	if (%armor == "larmor" || %armor == "lfemale")
	{
		if ($noBuilding)
		{
			systemMessage(%clientId,1,"Det Bugs disabled in this mission.~wC_BuySell.wav");
			return 0;
		}
		else DeployDetBug(%clientId, %player, %item);
	}

	else if(%armor == "earmor" || %armor == "efemale")
	{
	        if($TeamItemCount[%team @ EngBeacons] < $TeamItemMax[EngBeacons])
		{
			if (!%clientId.EngBeacon || %clientId.EngBeacon == 0)
			{
				if (EngBeacon(%clientId, %player, %item))		// Standard Beacon
				{
					$TeamItemCount[%team @ "EngBeacons"]++;
					systemMessage(%clientId,0,"Engineer Beacon Set");
					Player::decItemCount(%player,%item);

				}
				else return false;
			}
			if (%clientId.EngBeacon == 1)
			{
				if (EngCamera(%clientId, %player, %item))		//=== Eng. Camera
				{
					$TeamItemCount[%team @ "EngBeacons"]++;
					systemMessage(%clientId,0,"Engineer Beacon Set");
					Player::decItemCount(%player,%item);
				}
				else return false;
			}

			if (%clientId.EngBeacon == 3)
			{
				if($matchStarted)
				{
					if(%player.throwTime < getSimTime())
					{
						%obj = newObject("","Item",RepairKit,1,false,false);
						addToSet("MissionCleanup", %obj);
						%client = Player::getClient(%player);
						GameBase::throw(%obj,%player,25,false);
						%player.throwTime = getSimTime() + 0.5;
						GameBase::setTeam(%obj, %team);
						systemMessage(%clientId,0,"MediKit Dropped");
						Player::decItemCount(%player,%item);
					}
					else return false;
				}
			}
		}
		else
			systemMessage(%clientId,0,"Deployable Item limit reached");

	}
	else if (%armor == "sarmor" || %armor == "sfemale" || %armor == "stimarmor" || %armor == "stimfemale")
		ScoutStim(%clientId, %player, %item);								//=== Scout Sensor

	else if (%armor == "spyarmor" || %armor == "spyfemale")
	{
		if (%obj = deployable(%player,%item,"Turret","SatchelPack",False,False,False,False,False,False,5,True,0, True, "DeployableSatchel", "SatchelPack"))
		{
			Player::decItemCount(%player,%item);
			%obj.tc = %clientId;
		}
	}

	else if (%armor == "jarmor")
	{

		if (player::getitemcount(%clientId, LasCannon) == 1)
		{
			if (%clientId.charging == 1)
			{
				return;
			}
			else if (%clientId.charging = "" || !%clientId.charging)
			{
				LasCannoner::Charge(%clientId, 8);
				%clientId.charging = 1;
				Player::decItemCount(%player,%item);
			}
		}
		else if (player::getitemcount(%clientId, PlasmaCannon) == 1)
		{
			if (%clientId.charging == 1)
			{
				return;
			}
			else if (%clientId.charging = "" || !%clientId.charging)
			{
				PlasmaCannoner::Charge(%clientId, 8);
				%clientId.charging = 1;
				Player::decItemCount(%player,%item);
			}
		}
		else
		{
			if (%clientId.charging == 1)
			{
				return;
			}
			else if (%clientId.charging = "" || !%clientId.charging)
			{
				Player::setItemCount(%clientId, PlasmaCannon,1);
				Player::mountItem(%clientId, PlasmaCannon, 0);
				PlasmaCannoner::Charge(%clientId, 8);
				%clientId.charging = 1;
				Player::decItemCount(%clientId,%item);
			}
		}

	}

	else if (%armor == "marmor" || %armor == "mfemale")
	{
		if($matchStarted)
		{
			if(%player.throwTime < getSimTime())
			{
				if (%clientId.boosted == 1)
				{
					systemMessage(Player::getClient(%player),1,"Booster Cooling.");
				}
				else
				{
					Player::trigger(%player,4,true);
					Player::trigger(%player,5,true);

					%ClientId.boosted = 1;
					%ClientId.boostercool = 1;

					%mass=%armor.mass;
					%len=50;
					%trans=GameBase::getMuzzleTransform(%player);
					%normvec=GetWord(%trans, 3) @ " " @ GetWord(%trans, 4) @ " " @ GetWord(%trans, 5);
					%rot=Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );
					%vec=Vector::getFromRot(%rot, %len*%mass, 0);
					Player::applyImpulse(%player,%vec);
					playSound(debrisMediumExplosion,gamebase::getposition(%player));
					systemMessage(Player::getClient(%player),0,"You use a Speed Booster.");
					Player::decItemCount(%player, %item);
					schedule ("" @ %ClientId @ ".boosted = 0;",2);
					schedule ("" @ %ClientId @ ".boostercool = 0;",6);

					schedule ("Player::trigger(" @ %player @ ",4,false);",1,%player);
					schedule ("Player::trigger(" @ %player @ ",5,false);",1,%player);
				}
			}
		}
	}

	else if (%armor == "aarmor" || %armor == "afemale" || %armor == "rarmor")
	{
		Renegades_startCloak(%clientId, %player);
		Player::decItemCount(%player,%item);
	}

	else if (%armor == "barmor" || %armor == "bfemale")
	{
		%ammoItem =	(Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType;
		if ($TeamItemMax[%ammoItem] && $TeamItemMax[%ammoItem] != 0)
		{
			messageall(0,"team ammoitem max");
			if ($TeamItemCount[%team @ %ammoItem] < $TeamItemMax[%ammoItem])
			{
				if(%ammoItem != "")
				{
					%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
					if(%delta)
					{
						Player::incItemCount(%clientId,%ammoitem,%delta);
					}
				}
			}
			else
			{
				systemMessage(%clientId,1,"Could Not Load Ammo. Team Limit Exceeded");
				return;
			}
		}
		else
		{
			if(%ammoItem != "" && %ammoItem != "MfglAmmo")
			{
				%delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]);
				if(%delta)
				{
					Player::incItemCount(%clientId,%ammoitem,%delta);
				}
			}
		}
		bottomprint(%clientId, "<jc>Loading backup "@%ammoItem@"...",3);
		systemMessage(%clientId,0,"~wmortar_reload.wav");
		Player::decItemCount(%player,%item);
	}
	else if (%armor == "harmor")
	{
		Renegades_startShield(%clientId, %player);
		Player::decItemCount(%player,%item);
	}
	else if (%armor == "tarmor")
	{
		if (Client::getGender(%clientId) == "Female") systemMessage(%clientId,3,"You becon your teammates to your aid.~wfemale5.whelp.wav");
		else systemMessage(%clientId,3,"You becon your teammates to your aid.~wmale5.whelp.wav");
		%numPlayers = getNumClients();
		for(%j = 0; %j < %numPlayers; %j = %j + 1)
		{
			%c = getClientByIndex(%j);
			if(%c != %clientId && %team == Client::getTeam(%c))
				issueTargCommand(%c, %c, 1, "Cover Titan "@Client::getName(%clientId)@"~wescfr", %j+1);
		}
	}
}

function DeployDetBug(%clientId, %player, %beacon)
{
	if($TeamItemCount[GameBase::getTeam(%player) @ "DetBug"] < $TeamItemMax[detbug])
	{
		%obj = NewObject("", "Item", "DetBug", 1, false);
		AddToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%player,15,false);
		systemMessage(Player::getClient(%player),0,"Det Bug Dropped");
		GameBase::SetTeam(%obj, GameBase::GetTeam(%clientId));
		%obj.DetBugOwner = %clientId;
		Player::decItemCount(%player,%beacon);
		$TeamItemCount[GameBase::getTeam(%player) @ "DetBug"]++;
	}
	else systemMessage(%clientId, $msgRed, "Your team does not have any more Det Bugs");
}

//========================DetBug
ItemData DetBug
{
	description = "Det Bug";
	className = "Ammo";
	shapeFile = "armorPatch";
  heading = "xAmmunition";
	shadowDetailMask = 4;
  price = 2;
};

function DetBug::OnCollision(%this, %object)
{
	if (getObjectType(%object) == "Player")
	{
		if(GameBase::GetTeam(%this) == GameBase::GetTeam(%object)) return;
		if(!Player::GetItemCount(%object, DetBug))
		{
			%client = Player::GetClient(%object);
			%armor = Player::getArmor(%object);
			Item::playPickupSound(%this);
			Player::SetItemCount(%client, DetBug, 1);
			%object.DetBug = True;
			%object.DetBugOwner = %this.DetBugOwner;
			schedule("DetBug::Detonate(" @ %object @ ");", 10);
  			$TeamItemCount[GameBase::getTeam(%this) @ "DetBug"]--;
			deleteobject(%this);
			if ( %armor == "earmor" || %armor == "efemale")
			{
				systemMessage(%client, 1, "You have collected a det bug for disarming.");
				%rnd = floor(getRandom() * 100);
				if (%rnd < 92)
				{
					Player::dropItem(%client, "DetBug");
					systemMessage(%client, 0, "~wpda_on.wav");
				}
				else
				{
					systemMessage(%client, 1, "DetBug Sweep Failure. Drop it before it detonates!~wC_BuySell.wav");
				}
			}
			else systemMessage(%client, 1, "You have acquired a det bug! Drop it before it detonates!");
		}
	}
}

function DetBug::onDrop(%player, %item)
{
	%client = Player::GetClient(%player);
	Player::SetItemCount(%player, DetBug, 0);
	%player.DetBug = False;
	%player.DetBugOwner = False;
	systemMessage(%client, $msgGreen, "DetBug Disarmed");
}

function DetBug::Detonate(%player)
{
	%client = Player::GetClient(%player);
	if(%player.DetBug)
	{
		systemMessage(%client, $msgRed, "DetBug Detonated!");
		%pos = GameBase::GetPosition(%player);
		%obj = newObject("", "Mine", "DetBugBomb");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%player.detbugowner,0,false);
		GameBase::setPosition(%obj, %pos);
		%player.DetBug = False;
		%player.DetBugOwner = False;
		Player::SetItemCount(%player, DetBug, 0);
	}
}

//========================Grenades

ItemData Grenade
{
	description = "Grenade";
	shapeFile = "grenade";
	heading = "wMiscellany";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	//validateShape = true;
	//validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			Player::decItemCount(%player,%item);
			%client = player::getclient(%player);
			%armor = Player::getArmor(%player);

			if (%armor == "larmor" || %armor == "lfemale")
				%obj = newObject("","Mine","HoloMine");		//==== repairlooking

			else if(%armor == "earmor" || %armor == "efemale")
				%obj = newObject("","Mine","EMPgrenade"); 	//==== Emp Grenade

			else if (%armor == "sarmor" || %armor == "sfemale")
				%obj = newObject("","Mine","Firebomb"); 	//==== FireBomb

			else if (%armor == "stimarmor" || %armor == "stimfemale")
				%obj = newObject("","Mine","Tranqgrenade"); 	//==== Tranq

			else if (%armor == "spyarmor" || %armor == "spyfemale")
			{
				%obj = newObject("","Mine","Plastique");
				systemMessage(%client,1, "Plastique Explosive will explode in " @ %client.Plastic @ " seconds");
				%timer = %client.plastic;
				schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", %timer);
			}

			else if (%armor == "aarmor" || %armor == "afemale")
				%obj = newObject("","Mine","EMPgrenade");	//==== EMP Greande

			else if (%armor == "barmor" || %armor == "bfemale")
				%obj = newObject("","Mine","Concussion");	//==== Concussion

			else if (%armor == "harmor")
				%obj = newObject("","Mine","Mortarbomb"); 	//==== Mortar Grenade

			else if(%armor == "rarmor" || %armor == "rfemale") 
				%obj = newObject("","Mine","PeaceMaker"); 	//==== PeaceShell

			else if(%armor == "jarmor")
			{
				if (Player::getMountedItem(%client,5) == Hammer2Pack)
				{
					Player::trigger(%player,4,true);	Player::trigger(%player,5,true);
					Player::trigger(%player,4,false);	Player::trigger(%player,5,false);
					playSound(SoundPlasmaTurretFire, GameBase::getPosition(%player));
					schedule("playSound(SoundFlyerDismount, GameBase::getPosition("@%player@"));", 0.25, %player);
					Player::incItemCount(%player,%item);
					GameBase::applyRadiusDamage($PlasmaDamageType, gamebase::getposition(%player), 5, 0.10, 2, %client);
				}
				return;
			}
			else //harmor,tarmor
				%obj = newObject("","Mine","Handgrenade");	//==== Standard

			//===================== End class select

 	 	 	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
	}
}

function Grenade::Plastic_Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//========================Mines

ItemData MineAmmo
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = "wMiscellany";
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{

			%armor = Player::getArmor(%player);
			%playerClient = Player::getClient(%player);

			if (%armor == "larmor" || %armor == "lfemale")
			{
				%obj = newObject("","Mine","Hologram");
			}
			//====================
			else if(%armor == "earmor" || %armor == "efemale")//=== Engineer Mines
			{
				if (%playerClient.EngMine == "0")
				{
					%obj = newObject("","Mine","ProxMine");
					%obj.tc = %playerClient;
					$TeamItemCount[GameBase::getTeam(%player) @ "ProxMine"]++;
				}
				else if (%playerClient.EngMine == "1")
				{
					%obj = newObject("","Mine","SubspaceMine");
				}
				else if (%playerClient.EngMine == "2")
				{
					%energy = GameBase::getEnergy(%player);
					%energy = (%energy - 15);
					if (%energy < 15)
					{
						bottomprint(%playerClient, "<jc>You're out of energy, can not deploy LaserMine.",3);
						return;
					}
					GameBase::setEnergy(%player,%energy);
					LaserMine(%playerClient, %player, %item);
					return;
				}
				else if (%playerClient.EngMine == "3")
				{
					%obj = newObject("","Mine","antipersonelMine");
				}
			}

			else if (%armor == "spyarmor" || %armor == "spyfemale")
			{
				%obj = newObject("","Mine","SubspaceMine");
			}

			else if (%armor == "aarmor" || %armor == "afemale")
			{
				%obj = newObject("","Mine","ShockMine");//=== ShockWaveMine
			}

			else if (%armor == "harmor")
			{
				if (%playerClient.dmines == 0 || !%playerClient.dmines)
				{
					%energy = GameBase::getEnergy(%player);
					%energy = (%energy - 10);
					if (%energy < 10)
					{
						bottomprint(%playerClient, "<jc>You're out of energy fat boy, can not deploy LaserMine.",3);
						return;
					}
					GameBase::setEnergy(%player,%energy);
					LaserMine(%playerClient, %player, %item);
					return;
				}
				else if (%playerClient.dmines == 1)
				{
					%obj = newObject("","Mine","antipersonelMine");
				}
			}
			else if (%armor == "rarmor")
			{
				if (GameBase::getLOSInfo(%player,5))
				{
					%rot = GameBase::getRotation(%player);
					%obj = newObject("Acid","Turret","AcidTurret",true);
					addToSet("MissionCleanup", %obj);
					GameBase::setTeam(%obj,GameBase::getTeam(%player));
					GameBase::setRotation(%obj,%rot);
					GameBase::setPosition(%obj,$los::position);
					Gamebase::setMapName(%obj,"Acid");
					systemMessage(%playerClient,0,"Applying acid...");
					playSound(SoundAcid,$los::position);
					%obj.tc = %playerClient;
					Player::decItemCount(%player,%item);
				}
				else systemMessage(%playerClient,0,"Object out of range");
				return;
			}
			else if (%armor == "jarmor")
			{
				if (player::getitemcount(%playerClient, PlasmaCannon) == 0)
				{
					Player::setItemCount(%playerClient, PlasmaCannon,1);
					Player::setItemCount(%playerClient, LasCannon,0);
					Player::mountItem(%playerClient, PlasmaCannon, 0);
				}
				else
				{
					Player::setItemCount(%playerClient, PlasmaCannon,0);
					Player::setItemCount(%playerClient, LasCannon,1);
					Player::mountItem(%playerClient, LasCannon, 0);
				}
				return;
			}
			else//tarmor,barmor,sarmor,marmor
			{
				%obj = newObject("","Mine","antipersonelMine");
			}
			//==== Finish Mine Deploy
		 	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,15 * %playerClient.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%playerClient));
			Player::decItemCount(%player,%item);
		}
	}
}

//================================ Laser Mine

function LaserMine(%clientId, %player, %bec)
{
   %item = "LaserMine";
   if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
   {
	if (GameBase::getLOSInfo(%player,6))
	{
		%obj = getObjectType($los::object);
		%prot = GameBase::getRotation(%player);
		%zRot = getWord(%prot,2);

		if (Vector::dot($los::normal,"0 0 1") > 0.2)
		{
			%rot = "0 0 " @ %zRot;
		}
		else
		{
			if (Vector::dot($los::normal,"0 0 -1") > 0.2)
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
			%turret = newObject("Camera","Turret",DeployableLaserM,true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setRotation(%turret,%rot);
			GameBase::setPosition(%turret,$los::position);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%turret) @ "LaserMine"]++;
			Player::decItemCount(%player,%bec);
			return true;
		}
		else {}
	}
	else
	{
		systemMessage(%clientId,0,"Deploy position out of range");
	}
   }
   else
   {
	 systemMessage(%clientId,0,"Deployable Item limit reached for laser mines");
   }
   return false;
}

//========================Repair Kit

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = "wMiscellany";
	shadowDetailMask = 4;
	price = 35;
	validateShape = true;
	validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);

	if ($poisonTime[%clientId])
	{
		$poisonTime[%clientId] =0;
	        bottomprint(%clientId, "<jc><f2>Poison cured.", 5);
	}
	if (%player.swim)
	{
		%swim = %player.swim - 100;
		if (%swim < 1) %swim  = 1;
		%player.swim = %swim;
		if (Client::getGender(%clientId) == "Female") systemMessage(%clientId,0,"More oxygen... ahh!~wfemale4.wcolor3.wav");
		else systemMessage(%clientId,0,"More oxygen...ahh!~wmale2.wcolor3.wav");
	}

	if (%armor == "sarmor" || %armor == "sfemale"  || %armor == "stimarmor" || %armor == "stimfemale")
	{
		if (%clientId.ovd > 15)
		{
			%overd = %clientId.ovd;

			%repair = (20 + floor(getRandom() * 25));
			%clientId.ovd = %clientId.ovd - %repair;
			if (%clientId.ovd < 0)
			{
				%clientId.ovd = 0;
			        bottomprint(%clientId, "<jc><f2>Over Dose Down to " @ %clientId.ovd @ "%.", 5);
			}
		        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Decreased from " @ %overd @ " to " @ %clientId.ovd @ "%.", 5);
	        }
		GameBase::repairDamage(%player,0.1);
	}

	else if(%armor == "larmor" || %armor == "lfemale")
	{
		GameBase::repairDamage(%player,0.1);
	}
	else if(%armor == "earmor" || %armor == "efemale")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "spyarmor" || %armor == "spyfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if( %armor == "marmor" || %armor == "mfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "aarmor" || %armor == "afemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "barmor" || %armor == "bfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "harmor")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "rarmor")
	{
		GameBase::repairDamage(%player,0.5);
	}
	else if(%armor == "jarmor")
	{
		GameBase::repairDamage(%player,0.5);
	}
	else
	{
		GameBase::repairDamage(%player,0.1);
	}
}

//========================Repair Patch
ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
    	heading = "wMiscellany";
	shadowDetailMask = 4;
  	price = 2;
	validateShape = true;
	validateMaterials = true;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		if(GameBase::getDamageLevel(%object) || %object.swim)
		{
			RepairPatch::onUse(%object, %this);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);

	if ($poisonTime[%clientId])
	{
		$poisonTime[%clientId] =0;
	        bottomprint(%clientId, "<jc><f2>Poison cured.", 5);
	}
	if (%player.swim)
	{
		%swim = %player.swim - 100;
		if (%swim < 1) %swim  = 1;
		%player.swim = %swim;
		if (Client::getGender(%clientId) == "Female") systemMessage(%clientId,0,"More oxygen... ahh!~wfemale4.wcolor3.wav");
		else systemMessage(%clientId,0,"More oxygen...ahh!~wmale2.wcolor3.wav");
	}

	if (%armor == "sarmor" || %armor == "sfemale"  || %armor == "stimarmor" || %armor == "stimfemale")
	{
		if (%clientId.ovd > 15)
		{
			%overd = %clientId.ovd;

			%repair = (20 + floor(getRandom() * 25));
			%clientId.ovd = %clientId.ovd - %repair;
			if (%clientId.ovd < 0)
			{
				%clientId.ovd = 0;
			        bottomprint(%clientId, "<jc><f2>Over Dose Down to " @ %clientId.ovd @ "%.", 5);
			}

		        bottomprint(%clientId, "<jc><f2>Chances Of OverDose Decreased from " @ %overd @ " to " @ %clientId.ovd @ "%.", 5);
	        }
		GameBase::repairDamage(%player,0.1);
	}

	else if(%armor == "larmor" || %armor == "lfemale")
	{
		GameBase::repairDamage(%player,0.1);
	}
	else if(%armor == "earmor" || %armor == "efemale")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else if(%armor == "spyarmor" || %armor == "spyfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "marmor" || %armor == "mfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "aarmor" || %armor == "afemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "barmor" || %armor == "bfemale")
	{
		GameBase::repairDamage(%player,0.2);
	}
	else if(%armor == "harmor")
	{
		GameBase::repairDamage(%player,0.3);
	}
	else
	{
		GameBase::repairDamage(%player,0.1);
	}
}

//========================
// Bone
//========================


ItemImageData BoneImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.2};
	firstPerson = false;
	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 0, 0 };
};

ItemData Bone
{
	description = "Bone";
	shapeFile = "flag";
	className = "Backpack";
	heading = "aArmor";
	shadowDetailMask = 4;
	imageType = BoneImage;
	showInventory = True;
	shadowDetailMask = 4;
	mapIcon = "M_camera";
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = false;
	hiliteOnActive = true;
	lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 0, 0 };
};

function Bone::Cemetary(%this)
{
	gamebase::setposition(%this, $Cemetary);
	if (%this.carrier == -1)
	{
		%this.carrier = "cemetary";
		GameBase::throw(%this,%this,10,true);
		messageAll(1, "A lost Bone has been placed into the Cemetary.~wflyer_mount.wav");
	}
}

function Bone::onDrop(%player,%item)
{
	%bone = %player.carryBone;
	%team = GameBase::getTeam(%bone);
	%client = Player::getClient(%player);
	%ClientName = Client::getName(%client);
	$FlagCarry[%team] = "";
	%bone.carrier = -1;
	%player.carryBone = "";
	Flag::clearWaypoint(%client, false);
  	schedule("Bone::Cemetary(" @ %bone @ ");", $Wasteland::FlagReturnTime, %Bone);
	Item::hide(%bone, false);
	if (Player::isDead(%player))
		GameBase::throw(%bone,%player,10,true);
	else
	{
		GameBase::throw(%bone,%player,15,false);
		Item::playPickupSound(%bone);
	}

	Player::decItemCount(%player,%item,1);
	messageAll(1, Client::getName(%client) @ " has dropped a Bone in the field.~wflyer_mount.wav");
	return %bone;
}

function Bone::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player" && !Player::isDead(%player))
	{
		%item = Item::getItemData(%this);
		%team = GameBase::getTeam(%this);
		%count = Player::getItemCount(%object,%item);
		%client = Player::getClient(%object);
		%carrierbone = Player::getMountedItem(%object, $FlagSlot);
		if (%carrierbone == %this) return;
		if (%carrierbone == "Bone")
		{
			bottomprint(%client, "<jc>You must drop the bone you have before you can pick up another." ,3);
			return;
		}
		if (%carrierbone == "flag")
		{
			bottomprint(%client, "<jc>You must drop the flag you have before you can pick up a bone." ,3);
			return;
		}
		if (!%count)
		{
			Player::mountItem(%object, Bone, $FlagSlot, %team);
			Player::setItemCount(%object, Bone, 1);
			$FlagCarry[%team] = %object;
			Item::hide(%this, true);
			%this.atHome = false;
			%this.carrier = %object;
			%this.pickupSequence++;
			%object.carryBone = %this;
			Item::hide(%this, true);
			messageAll(1, Client::getName(%client) @ " has collected a lost Bone.~wflyer_mount.wav");
		}
	}
}

ItemImageData JailGunlicksImage
{
  	shapeFile  = "zap_5";
	mountPoint = 0;
	mountRotation = { -1.57, 0, 0 };
};
ItemData JailGunlicks
{
    	heading = "bWeapons";
	description = "Jailer Beam";
	className = "Weapon";
    	shapeFile  = "zap";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = JailGunlicksImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};