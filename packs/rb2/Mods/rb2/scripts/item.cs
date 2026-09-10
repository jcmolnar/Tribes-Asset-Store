//----------------------------------------------------------------------------

$ItemFavoritesKey = "RealityBites2";  // Change this if you add new items
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

$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[RealTargetingLaser] = False;
$AutoUse[RocketLauncher] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[FlareGun] = True;
$AutoUse[MineLauncher] = True;
$AutoUse[FusionGun] = True;
$AutoUse[PlasmaCannon] = True;
$AutoUse[DemoGun] = True;
$AutoUse[DecoyGun] = True;
$AutoUse[LavaCannon] = True;

$Use[Blaster] = True;

$ArmorType[Male, HyperArmor] = hlarmor;
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, EngArmor] = earmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Male, UltraArmor] = uharmor;
$ArmorType[Female, HyperArmor] = hlfemale;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, EngArmor] = efemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Female, UltraArmor] = uharmor;

$ArmorName[hlarmor] = HyperArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[earmor] = EngArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[uharmor] = UltraArmor;
$ArmorName[hlfemale] = HyperArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[efemale] = EngArmor;
$ArmorName[mfemale] = MediumArmor;

$Grenade[0] = 11;
$Grenade[1] = OriginalGrenade;
$Grenade[2] = EMPGrenade;
$Grenade[3] = Plastique;
$Grenade[4] = FlareGrenade;
$Grenade[5] = ConcussionGrenade;
$Grenade[6] = PoisonGrenade;
$Grenade[7] = SuicideBomb;
$Grenade[8] = TearGasGrenade;
$Grenade[9] = ECMGrenade;
$Grenade[10] = Scrambler;
$Grenade[11] = GasCanGrenade;
$Grenade[12] = SmokerGrenade;
$Grenade[13] = DefenderGrenade;
$Grenade[14] = StoneThrowGrenade;
$Grenade[15] = MolotovGrenade;

$Mine[0] = 11;
$Mine[1] = OriginalMine;
$Mine[2] = SatchelCharge;
$Mine[3] = SpringMine;

$Beacon[0] = 11;
$Beacon[1] = TargetBeacon;
$Beacon[2] = MotionBeacon;
$Beacon[3] = CameraBeacon;
$Beacon[4] = JammerBeacon;
$Beacon[5] = ShieldBeacon;
$Beacon[6] = TeleportBeacon;
$Beacon[7] = AlarmBeacon;


// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 300;
$SellAmmo[LavaAmmo] = 5;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[RocketAmmo] = 10;
$SellAmmo[SniperAmmo] = 5;
$SellAmmo[MinelAmmo] = 5;
$SellAmmo[DecoyAmmo] = 5;
$SellAmmo[EagleAmmo] = 20;

$SellAmmo[TargetBeacon] = 3;
$SellAmmo[MotionBeacon] = 3;
$SellAmmo[CameraBeacon] = 3;
$SellAmmo[JammerBeacon] = 3;
$SellAmmo[ShieldBeacon] = 5;
$SellAmmo[TeleportBeacon] = 3;
$SellAmmo[AlarmBeacon] = 2;

$SellAmmo[OriginalMine] = 10;
$SellAmmo[ReplicatingMine] = 3;
$SellAmmo[HologramMine] = 3;
$SellAmmo[SatchelCharge] = 3;
$SellAmmo[SpringMine] = 5;
$SellAmmo[PhaseLokMine] = 1;
$SellAmmo[FlagMine] = 3;
$SellAmmo[JailMine] = 3;
$SellAmmo[PointLaserMine] = 3;
$SellAmmo[EMPMine] = 3;
$SellAmmo[DoomsdayMine] = 1;

$SellAmmo[OriginalGrenade] = 15;
$SellAmmo[EMPGrenade] = 15;
$SellAmmo[Plastique] = 5;
$SellAmmo[GasCanGrenade] = 50;
$SellAmmo[StoneThrowGrenade] = 50;
$SellAmmo[SmokerGrenade] = 50;
$SellAmmo[MolotovGrenade] = 50;
$SellAmmo[FlareGrenade] = 15;
$SellAmmo[ConcussionGrenade] = 15;
$SellAmmo[PoisonGrenade] = 5;
$SellAmmo[SuicideBomb] = 1;
$SellAmmo[TearGasGrenade] = 5;
$SellAmmo[ECMGrenade] = 15;
$SellAmmo[Scrambler] = 8;
$SellAmmo[RepairGrenade] = 5;
$SellAmmo[DefenderGrenade] = 50;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 200;
$AmmoPackMax[DiscAmmo] = 50;
$AmmoPackMax[ShotgunAmmo] = 20;
$AmmoPackMax[SlugShotgunAmmo] = 20;
$AmmoPackMax[SPASAmmo] = 20;
$AmmoPackMax[GrenadeAmmo] = 6;
$AmmoPackMax[RocketAmmo] = 1;
$AmmoPackMax[RepairKit] = 2;
$AmmoPackMax[MinelAmmo] = 200;
$AmmoPackMax[britMagAmmo] = 100;
$AmmoPackMax[sawAmmo] = 100;
$AmmoPackMax[britMagAmmo] = 100; 
$AmmoPackMax[OICWAmmo] = 100; 


// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = RocketAmmo;
$AmmoPackItems[5] = SniperAmmo;
$AmmoPackItems[6] = RepairKit;
$AmmoPackItems[7] = FlareAmmo;
$AmmoPackItems[8] = MinelAmmo;
$AmmoPackItems[9] = LavaAmmo;
$AmmoPackItems[10] = ShieldBeacon;
$AmmoPackItems[11] = OriginalGrenade;
$AmmoPackItems[12] = ShotgunAmmo;
$AmmoPackItems[13] = SPASAmmo;
$AmmoPackItems[14] = SlugShotgunAmmo;
$AmmoPackItems[15] = britMagAmmo;
$AmmoPackItems[16] = sawAmmo;
$AmmoPackItems[17] = OICWAmmo;
$AmmoPackItems[18] = Grenade;
// $AmmoPackItems[17] = SlugShotgunAmmo;
// $AmmoPackItems[18] = SlugShotgunAmmo;


// Limit on number of special Items you can buy

$TeamItemMax[TurretPack] = 5;
$TeamItemMax[ChaingunTurretPack] = 6;
$TeamItemMax[BellygunTurretPack] = 6;
$TeamItemMax[SeekerPack] = 8;
$TeamItemMax[FlakPack] = 3;
$TeamItemMax[IonPack] = 2;
$TeamItemMax[ConPack] = 2;
$TeamItemMax[FlameTurretPack] = 2;
$TeamItemMax[ObeliskPack] = 2;
$TeamItemMax[PlasmaPack] = 3;
$TeamItemMax[AntiMatterTurretPack] = 2;
$TeamItemMax[PlasmaTurretDecoyPack] = 10;
$TeamItemMax[EngineerTurretPack] = 3;
$TeamItemMax[BarragePack] = 2;

$TeamItemMax[DeployableAmmoPack] = 4;
$TeamItemMax[DeployableInvPack] = 2;
$TeamItemMax[BotStationPack] = 1;
$TeamItemMax[DeployableForceField] = 4;
$TeamItemMax[DeployableLargeForceField] = 2;
$TeamItemMax[ObeliskPowerPack] = 3;
$TeamItemMax[DeployableLRMotionSensorPack] = 2;
$TeamItemMax[AccelPPack] = 2;
$TeamItemMax[BlastWall] = 50;
$TeamItemMax[DeployableSolarPanel] = 2;
$TeamItemMax[UtilityPack] = 2;
$TeamItemMax[Mirage] = 6;

$TeamItemMax[ArbitorBoxPack] = 1;
$TeamItemMax[DShieldPack] = 1;
$TeamItemMax[airbase] = 1;
$TeamItemMax[jailpack] = 1;
$TeamItemMax[OutpostPack] = 1;
$TeamItemMax[DeployableFullInvPack] = 1;

$TeamItemMax[ScoutVehicle] = 8;
$TeamItemMax[HAPCVehicle] = 6;
$TeamItemMax[LAPCVehicle] = 6;

$TeamItemMax[Guard_CMD] = 1;
$TeamItemMax[Mortar_CMD] = 1;
$TeamItemMax[Demo_CMD] = 1;
$TeamItemMax[Medic_CMD] = 1;
$TeamItemMax[Miner_CMD] = 1;
$TeamItemMax[Sniper_CMD] = 1;
$TeamItemMax[Painter_CMD] = 1;
$TeamItemMax[Runner_CMD] = 1;

$TeamItemMax[Guard_NRS] = 1;
$TeamItemMax[Mortar_NRS] = 1;
$TeamItemMax[Demo_NRS] = 1;
$TeamItemMax[Medic_NRS] = 1;
$TeamItemMax[Miner_NRS] = 1;
$TeamItemMax[Sniper_NRS] = 1;
$TeamItemMax[Painter_NRS] = 1;
$TeamItemMax[Runner_NRS] = 1;


$TeamItemMax[AttackDronePack] = 2;


// $TeamItemMax[Beacon] = 20;
// $TeamItemMax[Mineammo] = 25;

$TeamItemMax[TargetBeacon] = 2;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[BaseAlarm] = 10;

$TeamItemMax[OriginalMine] = 25;
$TeamItemMax[ReplicatingMine] = 40;
$TeamItemMax[OriginalReplicatingMine] = 10;
$TeamItemMax[HologramMine] = 15;
$TeamItemMax[SatchelPack] = 25;
$TeamItemMax[Springboard] = 200;
$TeamItemMax[PhaseLokAmmo] = 6;

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
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[SniperRifle] = SniperAmmo; 
$WeaponAmmo[FlareGun] = "";
$WeaponAmmo[MineLauncher] = MinelAmmo;
$WeaponAmmo[FusionGun] = "";
$WeaponAmmo[PlasmaCannon] = "ShotgunAmmo";
$WeaponAmmo[DemoGun] = "";
$WeaponAmmo[DecoyGun] = "DecoyAmmo";
$WeaponAmmo[LavaCannon] = LavaAmmo;

$ForceFieldPack::RechargeRate=0.1;

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
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation || %stationName == BotStation) 
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
	$SpawnFav = "True";
	//echo ("Buy Faves");
	if( !%client.observerMode == "" || $loadingMission == "true" || $matchStarted == "false" || %client.dead) 
	{
		return;
	}

	for (%i = 0; %i <= 19; %i++)
	{
		%client.fav[%i] = "";
		$spawnBuyList[%i, %client] = "";
	}


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
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation || %stationName == BotStation)
			%energy = %station.Energy;
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
			Client::sendMessage(%client,0,"Too many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}
	else if(%item.className == PriWeapon)
	{
		%armor = Player::getArmor(%client);
		%wcount = Player::getItemClassCount(%client,"PriWeapon");
		if (Player::getItemClassCount(%client,"PriWeapon") >= $MaxPriWeapons[%armor])
		{
			Client::sendMessage(%client,0,"Too many primary weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
  	}
	else if(%item.className == Tool)
	{
		%armor = Player::getArmor(%client);
		%tcount = Player::getItemClassCount(%client,"Tool");
		if (Player::getItemClassCount(%client,"Tool") >= $MaxTools[%armor])
		{
			Client::sendMessage(%client,0,"Too many tools for " @ $ArmorName[%armor].description @ " to carry");
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
	if(%item.className != Armor && %item.className != Vehicle && %item.className != Bot)
	{
		%count = Player::getItemCount(%client,%item);
	  	%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
		if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function ResetPrimary(%client) 
{

	Player::setItemCount(%client,LavaCannon,0); //M4 Machinegun
	Player::setItemCount(%client,chaingun,0);
	Player::setItemCount(%client,PlasmaGun,0);
	Player::setItemCount(%client,DiscLauncher,0);
	Player::setItemCount(%client,SniperRifle,0);
	Player::setItemCount(%client,GrenadeLauncher,0);
	Player::setItemCount(%client,RocketLauncher,0);
	Player::setItemCount(%client,DecoyGun,0);
	Player::setItemCount(%client,TommyGun,0);
	Player::setItemCount(%client,Remington,0);
	Player::setItemCount(%client,autoShotgun,0);
	Player::setItemCount(%client,britMAG,0);
	Player::setItemCount(%client,OICW,0);
	Player::setItemCount(%client,Klashnikov,0);
	Player::setItemCount(%client,berettaSMG,0);
	Player::setItemCount(%client,famas,0);
	Player::setItemCount(%client,musket,0);
	Player::setItemCount(%client,saw,0);
	Player::setItemCount(%client,ingram,0);
	Player::setItemCount(%client,berettaSMG,0);

}


function ResetGrenades(%client) 
{
	Player::setItemCount(%client,Grenade,0);
	Player::setItemCount(%client,OriginalGrenade,0);
	Player::setItemCount(%client,EMPGrenade,0);
	Player::setItemCount(%client,ECMGrenade,0);
	Player::setItemCount(%client,FlareGrenade,0);
	Player::setItemCount(%client,PoisonGrenade,0);
	Player::setItemCount(%client,TearGasGrenade,0);
	Player::setItemCount(%client,ConcussionGrenade,0);
	Player::setItemCount(%client,Scrambler,0);
	Player::setItemCount(%client,GasCanGrenade,0);
	Player::setItemCount(%client,StoneThrowGrenade,0);
	Player::setItemCount(%client,DefenderGrenade,0);
	Player::setItemCount(%client,SmokerGrenade,0);
	Player::setItemCount(%client,MolotovGrenade,0);
	Player::setItemCount(%client,SuicideBomb,0);
	Player::setItemCount(%client,Plastique,0);

}


function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
			($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || %item.className == Bot || $TestCheats))
	{
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
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats)
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
		else if(%item.className == Weapon || %item.className == Tool || %item.className == PriWeapon)
		{
			

				if(%item.heading == "bPrimary Weapons")
				{
					
					ResetPrimary(%client); 
					// Make sure player only carries a single primary weapon
					
				}


				Player::setItemCount(%client,%item,1);
				%ammoItem =  %item.imageType.ammoType; 

				// make sure we still buy ammo for this item.
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
		else if(%item.className == VehicleWeapon) 
		{
			%obj = $VList[%player.Station];
			if (%obj.leftpad == "false" && %obj != -1)
			{
				%vtype = Gamebase::getDataName(%obj);
				if (%vtype == "Scout")
				{
					if (%obj.weaponry != "") 
						 Client::SendMessage(%client,0,"Reconfiguring Vehicle Weaponry...");
					if (%obj.module == KamikazeModule)
					{
						Client::SendMessage(%client,0,"Removing " @ (%obj.module).description @ " to make room for weapon.");
						%obj.module = "";
					}
					%obj.weaponry = $Weaponry[%item];
					%obj.AmmoMinimum = $AmmoMinimum[%item];
					%obj.firesound = $FireSound[%item];
					%obj.AmmoCost = $AmmoCost[%item];
					%obj.firedelay = $FireDelay[%item];
					%obj.attacktype = $AttackType[%item];
					%obj.multi = $Multi[%item];
					%obj.firecount = $FireCount[%item];
					Client::SendMessage(%client,0,"Vehicle now mounted with " @ %item.description @ ".");
				}
				else Client::SendMessage(%client,0,"Unable to mount vehicle with " @ %item.description @ ".");
			}
			return 1;
		}
		else if(%item.className == VehicleModule) 
		{
			%obj = $VList[%player.Station];
			if (%obj.leftpad == "false" && %obj != -1)
			{
				%vtype = Gamebase::getDataName(%obj);
				if (%vtype != "Scout" || %item != "CloakModule")
				{
					if (%obj.module != "")
						Client::SendMessage(%client,0,"Reconfiguring Vehicle Module...");
					%obj.module = %item;
					if (%obj.weaponry != "" && %item == KamikazeModule)
					{
						Client::SendMessage(%client,0,"Removing vehicle weapon to make room for extra explosives.");
						%obj.weaponry = "";
						%obj.AmmoMinimum = "";
						%obj.firesound = "";
						%obj.AmmoCost = "";
						%obj.firedelay = "";
						%obj.attacktype = "";
						%obj.multi = "";
						%obj.firecount = "";
					}
					Client::SendMessage(%client,0,"Vehicle now mounted with " @ %item.description @ ".");
				}
				else Client::SendMessage(%client,0,"Vehicle too small for " @ %item.description @ ".");
			}
			return 1;
		}
	 	else if(%item.className == Bot)
	 	{
			if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
			{
				%shouldBuy = BotStation::checkBuying(%client,%item);
				if(%shouldBuy == 1)
				{
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
			}
		}
		else if(%item.className == Grenade)
		{
			
			ResetGrenades(%client); 
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
			//	if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
			//		%max += $AmmoPackMax[%item];
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
			//	if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
			//		%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,MineAmmo, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}
		}
		else if(%item.className == Beacon)
		{
			if(checkResources(%player,%item,1))
			{
				for(%i = 1; %i <= $Beacon[0]; %i++)
				{
					%b = $Beacon[%i];
					if(%item == %b) {}
					else
					{
						teamEnergyBuySell(%player,%b.price * Player::getItemCount(%player, %b));
						Player::setItemCount(%player, %b, 0);
					}
				}
				%max = $ItemMax[%armor, %item];
			//	if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
			//		%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,Beacon, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
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
}

function remoteBuyItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	if(buyItem(%client,%item))
	{
 		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		if(!%client.disablehelp)
			Client::sendMessage(%client,0,"HELP - " @ %item.description @ ": " @ $HelpMessage[%item]);
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
			else if (%item == ammopack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "")
			{
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
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
			else if(%item.className == Beacon)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, Beacon, %numsell);
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
		if (%item == Weapon || %item == PriWeapon) 
			%item = Player::getMountedItem(%client,$WeaponSlot);
	}
	Player::useItem(%client,%item);
}

function remoteThrowItem(%client,%type,%strength)
{
	%item = getItemData(%type);
	//echo("Throw item: " @ %item @ " of type " @ %type @ " Strength: " @ %strength);
	if (%item.className == "Grenade" || %item.className == "HandAmmo" || %item.className == "Mine")
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
		else if (%item == Weapon || %item == PriWeapon)
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo)
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon || %item.className == PriWeapon)
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

//-------------------------------------------------------------------------

// Weapon Sequences

$NextWeapon[LavaCannon] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = PlasmaCannon;
$NextWeapon[PlasmaCannon] = Chaingun;
$NextWeapon[Chaingun] = FusionGun;
$NextWeapon[FusionGun] = DiscLauncher;
$NextWeapon[DiscLauncher] = RocketLauncher;
$NextWeapon[RocketLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = MineLauncher;
$NextWeapon[MineLauncher] = DecoyGun;
$NextWeapon[DecoyGun] = LaserRifle;
$NextWeapon[LaserRifle] = SniperRifle;
$NextWeapon[SniperRifle] = EnergyRifle;
$NextWeapon[EnergyRifle] = FlareGun;
$NextWeapon[FlareGun] = LavaCannon;


$PrevWeapon[Blaster] = FlareGun;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[PlasmaCannon] = PlasmaGun;
$PrevWeapon[Chaingun] = PlasmaCannon;
$PrevWeapon[FusionGun] = Chaingun;
$PrevWeapon[DiscLauncher] = FusionGun;
$PrevWeapon[RocketLauncher] = DiscLauncher;
$PrevWeapon[GrenadeLauncher] = RocketLauncher;
$PrevWeapon[MineLauncher] = GrenadeLauncher;
$PrevWeapon[DecoyGun] = MineLauncher;
$PrevWeapon[LaserRifle] = DecoyGun;
$PrevWeapon[SniperRifle] = LaserRifle;
$PrevWeapon[EnergyRifle] = SniperRifle;
$PrevWeapon[LavaCannon] = EnergyRifle;
$PrevWeapon[FlareGun] = LavaCannon;

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
			}
		}
	}
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
			}
		}
	}
}

function selectValidWeapon(%client)
{
	%item = Blaster;
	for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
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


//-------------------------------------------------------------------------

// Tool Sequences

$NextTool[RealTargetingLaser] = FlareGun;
$NextTool[FlareGun] = RealTargetingLaser;

function remoteNextTool(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextTool[%item] == "")
		selectValidTool(%client);
	else
	{
		for (%tool = $NextTool[%item]; %tool != %item; %tool = $NextTool[%tool])
		{
			if (isSelectableTool(%client,%tool))
			{
				Player::useItem(%client,%tool);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %tool || Player::getNextMountedItem(%client,$WeaponSlot) == %tool)
					break;
			}
		}
	}
}

function selectValidTool(%client)
{
	%item = RealTargetingLaser;
	for (%tool = $NextTool[%item]; %tool != %item; %tool = $NextTool[%tool])
	{
		if (isSelectableTool(%client,%tool))
		{
			Player::useItem(%client,%tool);
			break;
		}
	}
}

function isSelectableTool(%client,%tool)
{
	if (Player::getItemCount(%client,%tool))
	{
		%ammo = $WeaponAmmo[%tool];
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
		 		if (Player::isAIControlled(%client) == True)
		 			BotGear::CheckBackpack(%client);
				Client::sendMessage(%client,0,"You are now wearing a " @ %item @ "");
		 		return 1;
			}
		}
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
		else if(%item.className == Beacon)
		{
			if(Player::getItemCount(%player, Beacon) == Player::getItemCount(%player, %item))
			{
				%count = Player::getItemCount(%player, %item);
				%total = $ItemMax[%armor, %item];
				%extra = %total - %count;
				if(%delta > %extra)
					%delta = %extra;
				if(%delta > 0)
				{
					Player::incItemCount(%player, %item, %delta);
					Player::incItemCount(%player, Beacon, %delta);
					Client::sendMessage(%client, 0, "You received " @ %delta @ " " @ %item.description);
					return %delta;
				}
			}
		}
  		else
  		{
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon)
			{
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			if (%item.className == PriWeapon)
			{
				if (Player::getItemClassCount(%player,"PriWeapon") >= $MaxPriWeapons[%armor]) 
					return 0;
			}  
			if (%item.className == Tool)
			{
				if (Player::getItemClassCount(%player,"Tool") >= $MaxTools[%armor]) 
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
	else
	{
		// Generic item sound
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
	// If the item is rotating we respawn it,
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
			%client = Player::getClient(%player);
			if(%item.className == Grenade)
			{
				%amount = $SellAmmo[%item];
				if (%amount > Player::getItemCount(%player, %item))
					%amount = Player::getItemCount(%player, %item);
				Player::decItemCount(%client, Grenade, %amount);
				Player::decItemCount(%client, %item, %amount);
			}
			else if(%item.className == Mine)
			{
				%amount = $SellAmmo[%item];
				if (%amount > Player::getItemCount(%player, %item))
					%amount = Player::getItemCount(%player, %item);
				Player::decItemCount(%client, MineAmmo, %amount);
				Player::decItemCount(%client, %item, %amount);
			}
			else if(%item.className == Beacon)
			{
				%amount = $SellAmmo[%item];
				if (%amount > Player::getItemCount(%player, %item))
					%amount = Player::getItemCount(%player, %item);
				Player::decItemCount(%client, Beacon, %amount);
				Player::decItemCount(%client, %item, %amount);
			}
			else
			{
				Player::decItemCount(%player,%item,1);
				%amount = 1;
			}
			%obj = newObject("","Item",%item,%amount,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) 
				GameBase::throw(%obj,%player,10,true);
			else
			{
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
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
	shapeFile = "dsply_v1";
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
	shapeFile = "dsply_v1";
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

// Hyperlight Armor - straight out of Orion

ItemData HyperArmor
{
	heading = "aSoldier";
	description = "Recon";
	shapeFile = "larmor";
	className = "Armor";
	price = 1;
};

ItemData LightArmor
{
	heading = "aSoldier";
	description = "Sniper";
	shapeFile = "larmor";
	className = "Armor";
	price = 1;
};

// Engineer Armour - from the Tricon Team

ItemData EngArmor
{
	heading = "aSoldier";
        description = "Engineer";
	shapeFile = "marmor";
	className = "Armor";
        price = 1;
};

ItemData MediumArmor
{
	heading = "aSoldier";
	description = "Grenadier";
	shapeFile = "marmor";
	className = "Armor";
	price = 1;
};

ItemData HeavyArmor
{
	heading = "aSoldier";
	description = "Commando";
	shapeFile = "larmor";
	className = "Armor";
	price = 1;
};

// Ultraheavy Armour = straight out of Orion

ItemData UltraArmor
{
	heading = "aSoldier";
	description = "Heavy Gunner";
	shapeFile = "marmor";
	className = "Armor";
	price = 1;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "AH64 Apache";
	className = "Vehicle";
	shapeFile = "flyer";
	heading = "aVehicle";
	price = 10;
};

ItemData LAPCVehicle
{
	description = "Huey";
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	heading = "aVehicle";
	price = 10;
};

ItemData HAPCVehicle
{
	description = "Chinook";
	className = "Vehicle";
	shapeFile = "hover_apc";
	heading = "aVehicle";
	price = 10;
};


//----------------------------------------------------------------------------
// Commndable Purchaseable Bots
//----------------------------------------------------------------------------

ItemData Guard_CMD
{
	description = "Guard Bot";
	className = "Bot";
	shapeFile = "harmor";
	heading = "aBot";
	price = 10;
};

ItemData Mortar_CMD
{
	description = "Mortar Bot";
	className = "Bot";
	shapeFile = "harmor";
	heading = "aBot";
	price = 10;
};

ItemData Demo_CMD
{
	description = "Demolitions Bot";
	className = "Bot";
	shapeFile = "marmor";
	heading = "aBot";
	price = 10;
};

ItemData Medic_CMD
{
	description = "Medic Bot";
	className = "Bot";
	shapeFile = "marmor";
	heading = "aBot";
	price = 10;
};

ItemData Miner_CMD
{
	description = "Minelayer Bot";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 10;
};

ItemData Sniper_CMD
{
	description = "Sniper Bot";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 10;
};

ItemData Painter_CMD
{
	description = "Painter Bot";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 0;
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
	if (%ammo == "")
	{
		// Energy weapons dont have ammo types
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else
	{
		if (Player::getItemCount(%player,%ammo) > 0) 
			Player::mountItem(%player,%item,$WeaponSlot);
		else
		{
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


//Deadtaco's knife thrust 

ItemImageData TargetingLaserImage
{
	shapeFile = "tracer";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { -0.0, 1.0, 0.0 };
	weaponType = 0; // Sustained
	// projectileType = BarrettFlash;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 1;
	reloadTime = 0.1;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	// sfxFire     = SoundFireTargetingLaser;
	// sfxActivate = SoundKnifeThrust;
};

ItemData TargetingLaser
{
	showInventory = false;
	description   = "Targeting Laser";
	className     = "NotTool";
	shapeFile     = "tracer";
	hudIcon       = "targetlaser";
	heading	= "eMelee Weapons";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 0;
	showWeaponBar = false;
};


function TargetingLaserImage::onFire(%player, %slot)
{


}

function TargetingLaser::OnMount(%player,%imageslot)
{

		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("knifethrust",%trans,%player,%vel);
}


function TargetingLaser::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);


	remoteNextTool(%clientId);
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

//----------------------------------------------------------------------------

// ------------------------------------TACOMOD ITEMS----------------------//


ItemData LavaAmmo
{
	description = "M4 Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData LavaImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = LavaAmmo;
	projectileType = M4Bullet;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.10;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 0.1, 1.0 };

	sfxFire = rocketExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	// sfxReady = SoundMortarIdle;
};

ItemData LavaCannon 
{
	description = "M4 Machinegun";
	className = "PriWeapon";
	shapeFile = "sniper";
	hudIcon = "mortar";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = LavaImage;
	price = 0;
	showWeaponBar = true;
};

function LavaCannon::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using M4 Machinegun - A decent light weight U.S. machinegun.", 5);
	}
}


ItemData EagleAmmo
{
	description = "DE 50 Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData BlasterImage
{
	shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	mountOffset = { -0.0, -0.1, 0.0 };

	ammoType = EagleAmmo;
	reloadTime = 0;
	fireTime = 1.2;

	projectileType = DEBullet;
	accuFire = True;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
	heading = "cSecondary Weapons";
	description = "Desert Eagle 50";
	className = "Weapon";
	shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 0;
	showWeaponBar = true;
};

function Blaster::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using Desert Eagle.  Great close-range handgun.", 5);
	}
}

//------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "force";
	mountPoint = 0;
	mountrotation = {0.1, 0, 0};
	mountOffset = { 0.0, 0.0, -0.3 };
	weaponType = 0;  // Sustained
	projectileType = ProdCharge;
	minEnergy = 3;
	maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.5;
                        
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 0.85 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
	description = "Cattle Prod";
	shapeFile = "force";
	hudIcon = "energyRifle";
	className = "Tool";
	heading = "eMelee Weapons";
	shadowDetailMask = 4;
	imageType = EnergyRifleImage;
	showWeaponBar = true;
	price = 0;
};

function EnergyRifle::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using cattle prod - Moo!", 2);
	}
}

//----------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.4;
	spinDownTime = 3;
	fireTime = 0.02;

	ammoType = BulletAmmo;
	// projectileType = ChaingunBullet;
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
	description = "Minigun";
	className = "PriWeapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 0;
	showWeaponBar = true;
};


function ChaingunImage::onFire(%player, %slot) 
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Chaingun]);
	%armor = Player::getArmor(%player);
	// Player::decItemCount(%player,$WeaponAmmo[Chaingun],1);

		if(%AmmoCount)
		{
			ixApplyKickback(%player, 25, 140);
			// $TeamItemCount[GameBase::getTeam(%player) @ "BulletAmmo"]++;	 
			Player::decItemCount(%player,$WeaponAmmo[Chaingun],1);

			%client = GameBase::getOwnerClient(%player);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);

			Projectile::spawnProjectile("barrelsmoke",%trans,%player,"0 0 2");
			%client = GameBase::getOwnerClient(%player);
			%fired = (Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel));
			%fired.deployer = %player;
			%fired.deployer = %client;
		}
		else
		{
			Client::sendMessage(Player::getClient(%player), 0,"Out Of ammo");
		}

}



// ***********************************************IX STUFF*****************************************************


function ixApplyKickback(%player, %strength, %lift) 
{
	if((!%lift) && (%lift != 0))
		%lift = 0;

	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (ixSin(%rad));
	%y = ixCos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force = ixDotProd(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%dir = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}

function ixDotProd(%vec, %scalar) 
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function ixSin(%theta) 
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta) 
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}


// *********************************************END IX STUFF***************************************************





function Chaingun::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using minigun -- There's Nothing like dispensing 500 rounds per minute!", 2);
	}
}

//----------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "HK G36 Ammo";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // spinning
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.15;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = bigExplosion3;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "HK G36 Rifle";
	className = "PriWeapon";
	shapeFile = "sniper";
	hudIcon = "plasma";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 0;
	showWeaponBar = true;
};

function PlasmaGun::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using HK G36 - Great long-range automatic rifle.", 2);
	}
}

//----------------------------------------------------------------------------

ItemData DiscAmmo
{
	description = "M60 Round";
	className = "Ammo";
	shapeFile = "discammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountrotation = {0, 3, 0};
	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = HeavyBullet;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.17;
	// spinUpTime = 0.25;

	sfxFire = shockexplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	// sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "M60";
	className = "PriWeapon";
	shapeFile = "sniper";
	hudIcon = "disk";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 0;
	showWeaponBar = true;
};

function DiscLauncher::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"You are too drunk to do anything.  Stop drinking your molotovs!.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using M60 - An extremely heavy machinegun.", 2);
	}
}

//----------------------------------------------------------------------------

// Sniper Rifle - straight out of Orion, modified to use Poison Darts from Shifter

ItemData SniperAmmo
{
	description = "50 Cal. Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SniperAmmo;
	// projectileType = BarettaBullet;
	accuFire = true;
	reloadTime = 2.25;
	fireTime = 0.3;

	lightType = 3;  // Weapon Fire
	lightRadius = 10;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundPickUpWeapon;
};

ItemData SniperRifle
{
	description = "50 Cal. Barett";
	className = "PriWeapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 0;
	showWeaponBar = true;
};


function SniperRifle::onUse(%player,%item)
{
	$Supergun = %item;

	%clientId = Player::getClient(%player);
	if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using Barrett 50 Cal sniper rifle. Hold still when firing to get a kill shot!", 3);
	}
}

function SniperRifleImage::onFire(%player, %slot) 
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[SniperRifle]);
	// Player::decItemCount(%player,$WeaponAmmo[Chaingun],1);
	GameBase::setRotation(%Supergun, "0 0 " @ %AmmoCount);
		if(%AmmoCount)
		{
			
			// Player::decItemCount(%player,$WeaponAmmo[SniperRifle],1);

			%client = GameBase::getOwnerClient(%player);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
 		 	Projectile::spawnProjectile("BarrettFlash",%trans,%player,"0 0 0");


			Player::trigger(%player,6,true);    
			Player::trigger(%player,6,false);   
			playSound(SoundBarrettFire,GameBase::getPosition(%player));
			// %fired = (Projectile::spawnProjectile("BarettaBullet",%trans,%player,%vel));
			// %fired.deployer = %player;
			%pack = Player::getMountedItem(%client,$FlagSlot);

			if (%pack == -1) // Player can't use barrett as cheat launcher if carrying flag
			{
			schedule("ixApplyKickback(" @ %player @ ", 200, 70);", 0.1);
			}			   

			
	
		}
		else
		{
			Client::sendMessage(Player::getClient(%player), 0,"Out Of ammo.  You need to reload!");
		}

}

// Enhanced Barrett Looks here

ItemImageData BGunScopeImage
{
	shapeFile  = "grenadel";
	mountPoint = 0;
	mountRotation = {3.1, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.1, 0.1 };

	ammoType = TommyGunAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = DEBullet;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BGunScope
{
	heading = "cSecondary Weapons";
	description = "BGunScope";
	className = "PriWeapon";
	shapeFile  = "grenadel";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BGunScopeImage;
	price = 0;
	showWeaponBar = true;
};

ItemImageData BGunClipImage
{
	shapeFile  = "ammopack";
	mountPoint = 0;
	mountRotation = {1.5, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.1, -0.0 };

	ammoType = SniperAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = ArtilleryShell;
	accuFire = false;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BGunClip
{
	heading = "cSecondary Weapons";
	description = "ammopack";
	className = "PriWeapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BGunClipImage;
	price = 0;
	showWeaponBar = true;
};

ItemImageData BGunSpewImage
{
	shapeFile  = "force";
	mountPoint = 0;
	mountRotation = {0.0, 0, 0 };
	weaponType = 0; // Single Shot
	mountOffset = { -0.0, 0.0, 0.0 };

	ammoType = SniperAmmo;
	reloadTime = 0.1;
	fireTime = 0.1;

	projectileType = BarettaBullet;
	accuFire = true;

	sfxFire = turretexplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BGunSpew
{
	heading = "cSecondary Weapons";
	description = "ammopack";
	className = "PriWeapon";
	shapeFile  = "force";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BGunSpewImage;
	price = 0;
	showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item)
{
	Player::MountItem(%player,BGunScope,5);
	Player::MountItem(%player,BGunClip,7);
	Player::MountItem(%player,BGunSpew,6);
}
function SniperRifle::onUnMount(%player,%item)
{
	Player::UnMountItem(%player,5);
	Player::UnMountItem(%player,6);
	Player::UnMountItem(%player,7);
}

// ----------------------------------------END BARRETT ENHANCEMENT--------------------------------












//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "tracer";
	mountPoint = 0;
	mountRotation = { -0.25, 0.0, 0 };
	mountOffset = { -0.0, 0.75, -0.4 };
	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	// sfxFire = SoundFireLaser;
	// sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "tracer";
	hudIcon = "sniper";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 0;
	showWeaponBar = true;
};


function LaserRifle::OnMount(%player,%imageslot)
{

		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("knifethrust",%trans,%player,%vel);
}

function LaserRifle::onUse(%player,%item)
{	

}

//----------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "M29 Grenade";
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
	reloadTime = 3.5;
	fireTime = 1.0;

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
	description = "M29 Gren. Launcher";
	className = "PriWeapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 0;
	showWeaponBar = true;
};

function GrenadeLauncher::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"You are too drunk to do anything.  Stop drinking your molotovs!.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using M29 Grenade Launcher - Extremely explosive and deadly.", 2);
	}
}

//----------------------------------------------------------------------------

// Mortar Removed

//----------------------------------------------------------------------------

// Stinger missile Launcher

ItemData RocketAmmo 
{
	description = "Rocket Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData RocketImage 
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.0, 0.0, 0.4 };
	mountRotation = { 0, 0.1, 0 };	
	weaponType = 0;
	ammoType = RocketAmmo;
//	projectileType = "Undefined";
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 4.8;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	// sfxReady = SoundMortarIdle;
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
			%targetObj = Client::getOwnedObject(%targetId);

			if(%object == "Player" || %object == "Flier" || %object == "Turret" || %object == "Sensor")
			{			 

				if ((%targetObj.cloaked == 0) && (%targetObj.cloakdevice == 0) && (%targetObj.cloakPack == 0) && (%targetObj.cloakBoost == 0) && (%targetObj.cloakGun == 0) && (%targetObj.cloakplane == 0))  // Can't get a visual lock on a cloaked object or player
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
					bottomprint(Player::getClient(%player), "<JC>*****  Rocket has no lock!  *****", 3);
				}
			}
			else
			{
//				Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...Reinitializing Tracking System");
				Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
				bottomprint(Player::getClient(%player), "<JC>*****  Rocket has no lock!  *****", 3);
			}
		}
		else
		{
//			Client::sendMessage(Player::getClient(%player), 0,"Target Lock Failed...Reinitializing Tracking System");
			Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel,%player);
			bottomprint(Player::getClient(%player), "<JC>*****  Rocket has no lock!  *****", 3);
		}
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"You have no Ammo for the Stinger");
} //=== End standard missile fire.

ItemData RocketLauncher
{
	description = "Stinger";
	className = "PriWeapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = RocketImage;
	price = 0;
	showWeaponBar = true;
};

function Tracker(%clientId, %targetId, %delay) 
{
	if(%targetId) 
	{
		%name = Client::getName(%clientId);
		 Client::sendMessage(%targetId,0,"** WARNING ** - " @ %name @ " has a Missile Lock!");

	}
} 

function RocketLauncher::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"You are too drunk to do anything.  Stop drinking your molotovs!.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using Stinger - get 'em in your crosshairs and the missile will lock onto their heat.", 2);
	}
}

//----------------------------------------------------------------------------

ItemImageData RealTargetingLaserImage
{
	bitmapName = "repairadd.bmp";
	shapeFile = "tracer";
	mountPoint = 0;
	mountRotation = { 0.45, -1.0, 0 };
	mountOffset = { -0.0, 0.0, 0.0 };
	weaponType = 0; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	// sfxFire     = SoundFireTargetingLaser;
	// sfxActivate = SoundPickUpWeapon;
};

ItemData RealTargetingLaser
{
	description   = "Lance swing";
	className     = "Tool";
	shapeFile     = "tracer";
	hudIcon       = "targetlaser";
	heading	= "eMelee Weapons";
	shadowDetailMask = 4;
	imageType     = RealTargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

function RealTargetingLaser::onUse(%player,%item)
{

}

function RealTargetingLaser::OnMount(%player,%imageslot)
{

		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("knifethrust",%trans,%player,%vel);
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
	price = 0;
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


ItemData FlareAmmo
{
	description = "Flares";
	className = "Ammo";
	shapeFile = "tracer";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData FlareGunImage
{
	shapeFile = "tracer";
	mountPoint = 0;
	mountRotation = { 0.9, -2.0, 0 };
	mountOffset = { -0.0, 0.0, 0.0 };
	weaponType = 0; // Sustained
	// projectileType = KnifeThrust;
	minEnergy = 1;
	maxEnergy = 1;
	accuFire = true;
	reloadTime = 0.25;
	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 1, 1, 1 };
	sfxFire     = soundknifethrust;
	// sfxActivate = soundknifethrust;
};

ItemData FlareGun
{
	description   = "Lance (bladed spear)";
	className     = "Tool";
	shapeFile     = "tracer";
	hudIcon       = "plasma";
	heading = "eMelee Weapons";
	shadowDetailMask = 4;
	imageType     = FlareGunImage;
	price         = 300;
	showWeaponBar = true;
};

function FlareGun::OnMount(%player,%imageslot)
{
	
}


function FlareGunImage::onFire(%player, %slot)
{

   		 playSound(soundknifethrust, GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 // Projectile::spawnProjectile("knifethrust",%trans,%player,%vel);

		Player::UnMountItem(%player,$weaponslot);		
		Player::MountItem(%player,RealTargetingLaser,7);

		schedule("Player::UnMountItem(" @ %player @ ",7);", 0.05);
		schedule("Player::MountItem(" @ %player @ ",TargetingLaser, 7);", 0.05);
		schedule("Player::UnMountItem(" @ %player @ ",7);", 0.10);
		schedule("Player::MountItem(" @ %player @ ",LaserRifle, 7);", 0.10);
		schedule("Player::UnMountItem(" @ %player @ ",7);", 0.15);
		schedule("Player::MountItem(" @ %player @ ",TargetingLaser, 7);", 0.15);
		schedule("Player::UnMountItem(" @ %player @ ",7);", 0.15);
		schedule("Player::MountItem(" @ %player @ ",RealTargetingLaser, $weaponslot);", 0.20);
		schedule("Player::UnMountItem(" @ %player @ ",7);", 0.25);
		schedule("Player::MountItem(" @ %player @ ",FlareGun, $weaponslot);", 0.25);
		
		
}



function FlareGun::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount tools while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using Japanese Lance - Trust, parry, thrust, thrust.", 2);
	}
}

//----------------------------------------------------------------------------

// Mine Launcher - ripped from hvTactical

ItemData MinelAmmo
{
	description = "Napalm";
	className = "Ammo";
	shapeFile = "liqcyl";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MineLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MinelAmmo;
	projectileType = napalmspray;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.05;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	// sfxFire = SoundJetLight;
	sfxActivate = SoundFlameTurret;
	// sfxReload = SoundJetLight;
};

ItemData MineLauncher
{
	description = "Flamethrower";
	className = "PriWeapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 5;
	showWeaponBar = true;
};

function MineLauncher::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using Napalm Launcher.  Great for close-range flaming.", 2);
	}
}


//----------------------------------------------------------------------------

// Particle Accelerator - ripped from hvTactical



//----------------------------------------------------------------------------

// Fusion Blaster - created by Dewy of MiniMod fame
//musket whack butt

ItemImageData FusionGunImage
{
        shapeFile  = "sniper";
	mountPoint = 0;
	mountRotation = { 0.0, 0.0, -2.8 };
	mountOffset = { -0.5, 0.0, 0.0 };
        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.3;
        minEnergy = 6;
        maxEnergy = 7;

        projectileType = FusionGunBolt;
	accuFire = true;

	sfxFire = rocketExplosion;
	sfxActivate = SoundPickUpWeapon;
//	sfxReload = SoundMortarReload;
	sfxReady = SoundUseAmmoStation ;
};

ItemData FusionGun
{
	heading = "bPrimary Weapons";
        description = "Bot OICW Nader";
	className = "Weapon";
        shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
        imageType = FusionGunImage;
        price = 5;
	showWeaponBar = true;
};

function FusionGun::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"You are too drunk to do anything.  Stop drinking your molotovs!.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
	}
}

//----------------------------------------------------------------------------


// Plasma Cannon - ripped from Redneck Slag Pack

ItemData ShotgunAmmo
{
	description = "Shotgun Shell";
	className = "Ammo";
	shapeFile = "mortarammo";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};


ItemImageData PlasmaCannonImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	// projectileType = ShotgunPellet;
	ammoType = ShotgunAmmo;
	accuFire = True;
	reloadTime = 1.5;
	fireTime = 0.2;
	
	lightType = 3; // Weapon Fire
	lightRadius = 5;
	lightTime = 2;
	lightColor = { 0, 0, 1 };

	sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData PlasmaCannon
{
	description = "Pellet Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	heading = "cSecondary Weapons";
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 0;
	showWeaponBar = true;
};

function PlasmaCannon::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"You are too drunk to do anything.  Stop drinking your molotovs!.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using Double Barrelled Shotgun with pellets - Kill a bird or two.", 2);
	}
}

function PlasmaCannonImage::onFire(%player, %slot)
{
 	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[PlasmaCannon]);
	
	if (%AmmoCount)
	 {
   		 playSound(turretExplosion,GameBase::getPosition(%player));
		 %trans = GameBase::getMuzzleTransform(%player);
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
		 Projectile::spawnProjectile("GunFlame",%trans,%player,%vel);
		 Projectile::spawnProjectile("GunFlame",%trans,%player,%vel);
		 Player::decItemCount(%player,$WeaponAmmo[PlasmaCannon],1);
	 }
	 else
	 {
	 	playSound(SoundPackFail,GameBase::getPosition(%player));
	 	Player::trigger(%player,$WeaponSlot,false);
	 	Client::sendMessage(Player::getClient(%player), 0,"Shotgun is outta ammo!");
	 } 
}


















// Backpacks
//----------------------------------------------------------------------------

ItemData Backpack
{				
	description = "Backpack";
	showInventory = false;
};

function Backpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::trigger(%player,$BackpackSlot);
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
	heading = "dWorn Items";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 5;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	if (%player.shieldStrength < 0)
		%player.shieldStrength = 0;
	%player.shieldStrength += 0.012;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength -= 0.012;
	if (%player.shieldStrength < 0)
		%player.shieldStrength = 0;
}

//-------------------------------------

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
	heading = "dWorn Items";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 0;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
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
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else
		{
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	



ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
//	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "dWorn Items";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 0.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPack::onMount(%player,%item)
{
	%repairRate = 0.01;
	%rate = GameBase::getAutoRepairRate(%player) + %repairRate;
	GameBase::setAutoRepairRate(%player,%rate);
}

function AmmoPack::onUnmount(%player,%item)
{
	%repairRate = 0.01;
	%rate = GameBase::getAutoRepairRate(%player) - %repairRate;
	if (%rate < 0)
		%rate = 0;
	GameBase::setAutoRepairRate(%player,%rate);
}

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted)
	{
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 10 ; %i = %i +1)
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
			if(%i == 0)
		 	    	%item.BulletAmmo = %numPack;
			else if(%i == 1)
		 	    	%item.PlasmaAmmo = %numPack;
			else if(%i == 2)
		 	    	%item.DiscAmmo = %numPack;
			else if(%i == 3)
		 	    	%item.GrenadeAmmo = %numPack;
			else if(%i == 4)
	 	    		%item.RocketAmmo = %numPack;
			else if(%i == 5)
		 	    	%item.SniperAmmo = %numPack;
			else if(%i == 6)
		 	    	%item.MortarAmmo = %numPack;
			else if(%i == 7)
	 	    		%item.RepairKit = %numPack;
			else if(%i == 8)
				%item.FlareAmmo = %numPack;
			else if(%i == 9)
				%item.MinelAmmo = %numPack;
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
	for(%i = 0; %i < 10 ; %i = %i +1)
	{
		%ammoItem = $AmmoPackItems[%i];
		if(%i == 0)
		        %numAdd = %item.BulletAmmo;
		else if(%i == 1)
	    		%numAdd = %item.PlasmaAmmo;
		else if(%i == 2)
	    		%numAdd = %item.DiscAmmo;
		else if(%i == 3)
	    		%numAdd = %item.GrenadeAmmo;
		else if(%i == 4)
 	    		%numAdd = %item.RocketAmmo;
		else if(%i == 5)
 	    		%numAdd = %item.SniperAmmo;
		else if(%i == 6)
 	    		%numAdd = %item.MortarAmmo;
		else if(%i == 7)
 	    		%numAdd = %item.RepairKit;
		else if(%i == 8)
			%numAdd = %item.FlareAmmo;
		else if(%i == 9)
			%numAdd = %item.MinelAmmo;
		else if(%i == 16)
			%numAdd = %item.SawAmmo;
		else if(%i == 17)
			%numAdd = %item.OICWAmmo;
		else if(%i == 15)
			%numAdd = %item.BritMagAmmo;
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 10 ; %i = %i +1)
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



//Construction Pack - an idea of my own but with code based upon Seed Pack

ItemImageData ConstructorPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData ConstructorPack
{
	description = "Ramp Pack";
	shapeFile = "newdoor5";
	className = "Backpack";
	heading = "hField Deployment";
	imageType = ConstructorPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ConstructorPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
		// MODERN-PORT (2026-09-04): display-name override disabled -- see admin.cs.
		//$ModList = $RBModListAdmin;
	}
	else 
	{
		Player::deployItem(%player,%item);
	}
}

function ConstructorPack::onDeploy(%player,%item,%pos)
{
	if (BlastWall::deployShape(%player,%item))
	{
		//Player::decItemCount(%player,%item); //thus infinite walls to build
	}
}



function BlastWall::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "BlastWall"] < $TeamItemMax[BlastWall])
	{
		if (GameBase::getLOSInfo(%player,30)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "BlastWallShape" || GameBase::getDataName($los::object) == "OutpostWall") 
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{
					%rot = "-0.85 0 " @ %zRot;
				}
				else 	
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
					{
						%rot = "-0.85 0 " @ %zRot;
					}
					else 
					{
						%rot = Vector::getRotation($los::normal);
					}
				}

					%camera = newObject("BlastWall","StaticShape",BlastWallShape,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					%offset = "0.0 0.0 -1.0";
					GameBase::setPosition(%camera,Vector::add($los::position, %offset));
					Gamebase::setMapName(%camera,"Ramp#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					// Client::sendMessage(%client,0,"Ramp deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "BlastWall"]++;
					// echo("MSG: ",%client," deployed a ramp section");
					return true;
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain, buildings, or other ramps");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ "ramps");
        return false;
}

//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Turrets
//----------------------------------------------------------------------------

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	if(!%num)
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "StaticShape" && (GameBase::getDataName(Group::getObject(%set,0)) == "DeployableForceField"
		|| GameBase::getDataName(Group::getObject(%set,0)) == "DeployableLargeForceField" || GameBase::getDataName(Group::getObject(%set,0)) == "BlastWallShape"
		|| GameBase::getDataName(Group::getObject(%set,0)) == "LargeAirBasePlatform" || GameBase::getDataName(Group::getObject(%set,0)) == "OutpostFloor"
		|| GameBase::getDataName(Group::getObject(%set,0)) == "OutpostWall" || GameBase::getDataName(Group::getObject(%set,0)) == "AlarmKit" || GameBase::getDataName(Group::getObject(%set,0)) == "DoomsdayDevice")) 
	{ 
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
	else if(%num == 1)
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	else
		Client::sendMessage(%client,0,"Unable to deploy - One or more items and/or players in the way");
	deleteObject(%set);
	return 0;	
}

function CheckDeployTerrain (%this)
{
	%obj=getObjectType(%this);
	if( %obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName(%this) == "LargeAirBasePlatform" || GameBase::getDataName(%this)=="OutpostFloor" || GameBase::getDataName(%this)=="OutpostWall")
	{
		return 1;
	}
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

function CheckForObjects(%pos, %l, %w, %h)
{
	%Set = newObject("set",SimSet);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType;

	if (%l && %w && %h)
	{
		containerBoxFillSet(%Set, %Mask, %Pos, %l, %w, %h,0);
	}
	else
	{
		containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);	
	}

	%num = Group::objectCount(%Set);

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (%obj != "-1")
		{
			if (getObjectType(%obj) == "Player")
			{
			}
			else
			{
				deleteObject(%set);
				return False;
			}
		}
	}
	deleteObject(%set);
	return True;
}

//----------------------------------------------------------------------------


// Chaingun Turret - from the Bitchin Mod

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
        description = "Defense Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "fTurrets";
        imageType = ChaingunTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
        price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ChaingunTurretPack::onUse(%player,%item)
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

function ChaingunTurretPack::onDeploy(%player,%item,%pos)
{
        if (ChaingunTurretPack::deployShape(%player,%item))
        {
		Player::decItemCount(%player,%item);
	}
}

function FollowthePlane(%this, %plane)
{

		GameBase::setRotation(%this, "0 3 0");
		 %loc = Gamebase::getPosition(%plane);
		 %locZ = getWord(%loc,2);
		 %locx = getWord(%loc,0);
		 %locy = getWord(%loc,1);

Gamebase::setPosition(%this, " " @ %locx @ " " @ %locy @ " " @ %locz -3 @ " ");

if(GameBase::getDamageLevel(%plane) < (GameBase::getDataName(%plane)).maxDamage)
	schedule("FollowthePlane(" @ %this @ ", "  @ %plane @ ");", 0.05);
else
	GameBase::setDamageLevel(%this, 10000);


}


function ChaingunTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = getObjectType($los::object);
			%objtype = Gamebase::getDataName($los::object);
			%objnumber = $los::object;
			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = 0;
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num)
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = 0;
				deleteObject(%set);
				if(0 == %num) 
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					if (Vector::dot($los::normal,"0 0 1") > 0.6)
						%rot = "0 0 " @ %zRot;
					else
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6)
							%rot = "3.14159 0 " @ %zRot;
						else
							%rot = Vector::getRotation($los::normal);
					}
					if(checkDeployArea(%client,$los::position))
					{

						if (%objtype != "LAPC")
						{
						%turret = newObject("Chaingun Turret","Turret",DeployableChaingun,true);
						Client::sendMessage(%client,0,"Remote Chaingun Turret deployed");
						}

						if (%objtype == "LAPC")
						{
						%turret = newObject("Chaingun Turret","Turret",BellygunTurret,true);
						}

						addToSet("MissionCleanup", %turret);
						GameBase::setTeam(%turret,GameBase::getTeam(%player));
						GameBase::setPosition(%turret,$los::position);
						GameBase::setRotation(%turret,%rot);


						if (%objtype != "LAPC")
						{
						Gamebase::setMapName(%turret,"Defensive Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
						}
						if (%objtype == "LAPC")
						{
						Gamebase::setMapName(%turret,"Belly Gun#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
						FollowThePlane(%turret, $los::object);
						GameBase::startFadeOut(%turret);
						Client::sendMessage(%client,1,"HUEY BELLY GUN INSTALLED - AUTOTRACKING ENABLED.");
						}


						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ChaingunTurretPack"]++;
						echo("MSG: ",%client," deployed a defensive Turret");
						//	Remote turrets - kill points to player that deploy them
						Client::setOwnedObject(%client, %turret); 
						Client::setOwnedObject(%client, %player);
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
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

// Flak Cannon - A modified mod mod modded mod that is now RB

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
	description = "Anti Aircraft Gun";
	shapeFile = "hellfiregun";
	className = "Backpack";
	heading = "fTurrets";
	imageType = FlakPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlakPack::onUse(%player,%item)
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

function FlakPack::onDeploy(%player,%item,%pos)
{
	if (FlakPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function FlakPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object)=="OutpostWall")
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableIon",%num) + CountObjects(%set,"DeployableFlak",%num) + CountObjects(%set,"DeployableConTurret",%num) + CountObjects(%set,"BarrageTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableIon",%num) + CountObjects(%set,"DeployableFlak",%num) + CountObjects(%set,"DeployableConTurret",%num) + CountObjects(%set,"BarrageTurret",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if(checkDeployArea(%client,$los::position))
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("AA Cannon","Turret",DeployableFlak,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Flak Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Anti Aircraft cannon deployed");
								 
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "FlakPack"]++;
								echo("MSG: ",%client," deployed a Flak Turret");
								//	Remote turrets - kill points to player that deploy them
								 Client::setOwnedObject(%client, %turret);
								 Client::setOwnedObject(%client, %player);
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



// Ion Cannon - my own idea

ItemImageData IonPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
	mass = 2.5;
};

ItemData IonPack
{
	description = "Mobile Artillery";
	shapeFile = "mortar_turret";
	className = "Backpack";
	heading = "fTurrets";
	imageType = IonPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function IonPack::onUse(%player,%item)
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

function IonPack::onDeploy(%player,%item,%pos)
{
	if (IonPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function IonPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object)=="OutpostWall")
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableFlak",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableIon",%num) + CountObjects(%set,"DeployableFlak",%num) + CountObjects(%set,"DeployableConTurret",%num) + CountObjects(%set,"BarrageTurret",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if(checkDeployArea(%client,$los::position))
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("Mobile Arty","Turret",DeployableIon,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Artillery #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Artillery deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "IonPack"]++;
								echo("MSG: ",%client," deployed artillery");
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

// Seeker Turret - based upon hvTactical's Watchdog but modified by Epsilon

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
	description = "Claymore";
	shapeFile = "camera";
	className = "Backpack";
	heading = "fTurrets";
	imageType = SeekerImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SeekerPack::onUse(%player,%item)
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

function SeekerPack::onDeploy(%player,%item,%pos)
{
	if (SeekerPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function SeekerPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,10))
		{
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
	    		%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = 0;
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num)
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = 0;
				deleteObject(%set);
				if(0 == %num) 
				{
					// Try to stick it straight up or down, otherwise
					// just use the surface normal
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);
					if (Vector::dot($los::normal,"0 0 1") > 0.6)
						%rot = "0 0 " @ %zRot;
					else
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6)
							%rot = "3.14159 0 " @ %zRot;
						else
							%rot = Vector::getRotation($los::normal);
					}
					if(checkDeployArea(%client,$los::position))
					{
						%camera = newObject("Claymore","Turret",DeployableSeeker,true);
						addToSet("MissionCleanup", %camera);
						GameBase::setTeam(%camera,GameBase::getTeam(%player));
						GameBase::setRotation(%camera,%rot);
						GameBase::setPosition(%camera,$los::position);
						Gamebase::setMapName(%camera,"Claymore#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
						Client::sendMessage(%client,0,"claymore Armed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%camera) @ "SeekerPack"]++;
						echo("MSG: ",%client," armed a claymore");
						//	Remote turrets - kill points to player that deploy them
						Client::setOwnedObject(%client, %camera);
						Client::setOwnedObject(%client, %player);
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
			Client::sendMessage(%client,0,"Deploy position out of range");		
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------



//----------------------------------------------------------------------------
// Other Deployables
//----------------------------------------------------------------------------

ItemImageData DeployableInvPackImage
{
	shapeFile = "invent_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 500.0;
	firstPerson = false;
};

ItemData DeployableInvPack
{
	description = "Inventory Station";
	shapeFile = "invent_remote";
	className = "Backpack";
	heading = "jOther Deployables";
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 500.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableInvPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function DeployableInvPack::onDeploy(%player,%item,%pos)
{
	if (DeployableInvPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}	

function DeployableInvPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape")
//			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
						addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,"Remote Inventory Station");
						Client::sendMessage(%client,0,"Inventory Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
						echo("MSG: ",%client," deployed an Inventory Station");
						return true;
					}
				}
				else
				{
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				}
//			}
//			else
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
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
	heading = "jOther Deployables";
	shadowDetailMask = 4;
	imageType = DeployableAmmoPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableAmmoPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function DeployableAmmoPack::onDeploy(%player,%item,%pos)
{
	if (DeployableAmmoPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}	

function DeployableAmmoPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape")
//			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
						addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,"Remote Ammo Station");
						Client::sendMessage(%client,0,"Ammo Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
						echo("MSG: ",%client," deployed an Ammo Station");
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
//			}
//			else 
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//------------------------------------------------

ItemImageData BotStationPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.0;
	firstPerson = false;
};

ItemData BotStationPack
{
	description = "Overcharge station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = "jOther Deployables";
	shadowDetailMask = 4	;
	imageType = BotStationPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function BotStationPack::onUse(%player,%item)
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

function BotStationPack::onDeploy(%player,%item,%pos)
{
	if (BotStationPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function BotStationPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,10))
		{
			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape")
//			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
				{
					if(checkDeployArea(%client,$los::position))
					{
						%inv = newObject("ammounit_remote","StaticShape","BotStation",true);
						addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,"Overcharge Station");
						Client::sendMessage(%client,0,"Overcharge Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "BotStationPack"]++;
						echo("MSG: ",%client," deployed an overcharge Station");
						return true;
					}
				}
				else
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
//			}
//			else
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//------------------------------------------------

// Utility Device - my own idea, code copied from Arbitor Box and Gravity Turret

ItemImageData UtilityPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData UtilityPack
{
	description = "Utility Device";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = "jOther Deployables";
	shadowDetailMask = 4;
	imageType = UtilityPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function UtilityPack::onUse(%player,%item)
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

function UtilityPack::onDeploy(%player,%item,%pos)
{
	if (UtilityPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function UtilityPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "UtilityPack"] < $TeamItemMax[UtilityPack])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
    			%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,25,25,25,0);
			%num = CountObjects(%set,"UtilityDevice",%num);
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
				if(checkBeaconDeployArea(%client,$los::position)) 
				{
					%turret = newObject("Utility Device","Turret",UtilityDevice,true);
					addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setPosition(%turret,$los::position);
					GameBase::setRotation(%turret,%rot);
					Gamebase::setMapName(%turret,"Utility Device#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Utility Device deployed");
					$UtilityDeviceOwnedBy[%turret] = %client;
					$UtilityDeviceConfig[%turret] = 1; // Set To Blackout Mode.
					Client::sendMessage(%client,3,"Utility Device: Set to Blackout Mode");
					Client::sendMessage(%client,3,"Utility Device: Touch to change modes.");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%player) @ "UtilityPack"]++;
					echo("MSG: ",%client," deployed a Utility Device");
					return true;
				}
			}	 
			else
				Client::sendMessage(%client,0,"Frequency Overload - Too close to another Utility Device");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "es");
	return false;
}

//------------------------------------------------

// Long Range Motion Sensor - taken from Redneck Slag Pack

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
	heading = "jOther Deployables";
	shadowDetailMask = 4	;
	imageType = DeployableLRMotionSensorPackImage;
	mass = 2.5;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableLRMotionSensorPack::onUse(%player,%item)
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

function DeployableLRMotionSensorPack::onDeploy(%player,%item,%pos)
{
	if (DeployableLRMotionSensorPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}	

function DeployableLRMotionSensorPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object)=="OutpostWall")
			{
		    		if (Vector::dot($los::normal,"0 0 1") > 0.7)
		    		{
					if(checkDeployArea(%client,$los::position))
					{
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
						$SensorNetworkEnabled = true;
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


//----------------------------------------------------------------------------





// Obelisk of Light Power Source - from the Ideal mod

ItemImageData ObeliskPowerPackImage
{
	shapeFile = "bullet";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.0;
	firstPerson = false;
};

ItemData ObeliskPowerPack
{
	description = "Obelisk Power Source";
	shapeFile = "bullet";
	className = "Backpack";
	heading = "jOther Deployables";
	imageType = ObeliskPowerPackImage;
	shadowDetailMask = 4;
	mass = 0.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function ObeliskPowerPack::onMount(%player,%item)
{

	Player::wiggy(%player, 1000);
	Player::DanceGroove(2, %player, 30);
	
}


function Player::DanceGroove(%tempo, %player, %loops) // Deadtaco's rockin' dance beat
{

	if(%loops)
	{

	playsound(SoundBassDrum, GameBase::getPosition(%player));

	schedule("playsound(SoundBassDrum, GameBase::getPosition(" @ %player @ "));", 0.2 * %tempo);

	schedule("playsound(SoundBassDrum, GameBase::getPosition(" @ %player @ "));", 0.6 * %tempo);
	schedule("playsound(SoundBassDrum, GameBase::getPosition(" @ %player @ "));", 0.8 * %tempo);
	schedule("playsound(SoundBassDrum, GameBase::getPosition(" @ %player @ "));", 1.0 * %tempo);
	schedule("playsound(SoundBassDrum, GameBase::getPosition(" @ %player @ "));", 1.4 * %tempo);

	schedule("playsound(SoundTomTom,  GameBase::getPosition(" @ %player @ "));", 0.4 * %tempo);
	schedule("playsound(SoundTomTom,  GameBase::getPosition(" @ %player @ "));", 0.7 * %tempo);
	schedule("playsound(SoundTomTom,  GameBase::getPosition(" @ %player @ "));", 0.9 * %tempo);
	schedule("playsound(SoundTomTom,  GameBase::getPosition(" @ %player @ "));", 1.2 * %tempo);
	schedule("playsound(SoundTomTom,  GameBase::getPosition(" @ %player @ "));", 1.5 * %tempo);

	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.0 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.1 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.2 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.3 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.4 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.5 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.6 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.7 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.8 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 0.9 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 1.0 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 1.1 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 1.2 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 1.3 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 1.4 * %tempo);
	schedule("playsound(Soundhihat,  GameBase::getPosition(" @ %player @ "));", 1.5 * %tempo);

	schedule("Player::DanceGroove(" @ %tempo @ ", " @ %player @ ", " @ %loops - 1 @ ");", 1.6 * %tempo);

	}
}

function Player::wiggy(%this, %steps)
{
	if(%steps)
	{
		%x = getRandom() * 100 - 50;
		%y = getRandom() * 100 - 50;
		%z = getRandom() * 25;
		%t = floor(getRandom() * 99.99);

		if(%t >= 95)
		{
			Player::setAnimation(%this, 45);
		}


		%armor = Player::getArmor(%this);
		if(%armor == "uharmor")
		{
			%x = %x * 2.0;
			%y = %y * 2.0;
			%z = %z * 2.0;
		}
		else if(%armor == "harmor")
		{
			%x = %x * 1.5;
			%y = %y * 1.5;
			%z = %z * 1.5;
		}
		else if(%armor == "hlarmor")
		{
			%x = %x * 0.75;
			%y = %y * 0.75;
			%z = %z * 0.75;
		}

		Player::applyImpulse(%this, %x @ " " @ %y @ " " @ %z);
		 
		schedule("Player::wiggy(" @ %this @ ", " @ %steps - 1 @ ");", 0.1);
		
	}
}






//----------------------------------------------------------------------------


//----------------------------------------------------------------------------
// Unique Items
//----------------------------------------------------------------------------



// Outpost - borrowed from Pantheon mod

ItemImageData OutpostPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.2, 0 };
//	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData OutpostPack
{
	description = "Outpost";
	shapeFile = "newdoor5";
	className = "Backpack";
	heading = "hField Deployment";
	imageType = OutpostPackImage;
	shadowDetailMask = 4;
	mass = 4.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function OutpostPack::onUse(%player,%item)
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

function OutpostPack::onDeploy(%player,%item,%pos)
{
	if (OutpostPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function OutpostPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%player);
	if($TeamItemCount[%team @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,10)) 
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
							//--- Generator ---//
						%where = $los::position;
						%pos = Vector::add(%where,"0 -4 0");
						%rot = "0 0 0";
						%outpostgen = newObject("OutpostGen","StaticShape",OutpostGen,true);
						addToSet("MissionGroup/Teams/Team" @ %team, %outpostgen);
						GameBase::setTeam(%outpostgen,%team);
						GameBase::setPosition(%outpostgen,%pos);
						GameBase::setRotation(%outpostgen,%rot);
						Gamebase::setMapName(%outpostgen,"Outpost Generator");

							//--- Remote Inv. Station ---//
						%pos = Vector::add(%where,"2.5 -2 0");
						%rot = "0 0 0";
						%inv = newObject("ammounit_remote","StaticShape","Inventorystation",true);
						addToSet("MissionCleanup", %inv);
						GameBase::playSequence(%inv,0,"power");
						GameBase::playSequence(%inv,1);
						GameBase::setRechargeRate(%inv,10);
						%outpostgen.bigstation = %inv;
						GameBase::setTeam(%inv,%team);
						GameBase::setPosition(%inv,%pos);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,"Outpost Inv. Station");
						$OutpostDevices[%outpostgen,1] = %inv;

							//--- Remote Ammo. Station ---//
						%pos = Vector::add(%where,"-2.5 -2 0");
						%rot = "0 0 0";
						%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
						addToSet("MissionCleanup", %inv);
						GameBase::setTeam(%inv,%team);
						GameBase::setPosition(%inv,%pos);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,"Outpost Ammo. Station");
						$OutpostDevices[%outpostgen,2] = %inv;

							//--- Back Wall ---//
						%rot = "0 0 0";
						%backwall = newObject("","StaticShape",OutpostWall,true);
						addToSet("MissionCleanup", %backwall);
						GameBase::setTeam(%backwall,%team);
						GameBase::setPosition(%backwall,%where);
						GameBase::setRotation(%backwall,%rot);
						Gamebase::setMapName(%backwall,"Outpost Wall");
						$OutpostDevices[%outpostgen,3] = %backwall;

							//--- Right Wall ---//
						%rightwall = newObject("","StaticShape",OutpostWall,true);
						addToSet("MissionCleanup", %rightwall);
						GameBase::setTeam(%rightwall,%team);
						%pos = Vector::add(%where,"4.7250 -5.200 0");
						%rot2 = "0 0 1.57";
						GameBase::setPosition(%rightwall,%pos);
						GameBase::setRotation(%rightwall,%rot2);
						Gamebase::setMapName(%rightwall,"Outpost Wall");
						$OutpostDevices[%outpostgen,4] = %rightwall;

							//--- Left Wall ---//
						%leftwall = newObject("","StaticShape",OutpostWall,true);
						addToSet("MissionCleanup", %leftwall);
						GameBase::setTeam(%leftwall,%team);
						%pos = Vector::add(%where,"-4.767 -5.200 0");
						GameBase::setPosition(%leftwall,%pos);
						GameBase::setRotation(%leftwall,%rot2);
						Gamebase::setMapName(%leftwall,"Outpost Wall");
						$OutpostDevices[%outpostgen,5] = %leftwall;

							//--- Right Door ---//
						%rightdoor = newObject("","StaticShape",OutpostDoor,true);
						addToSet("MissionCleanup", %rightdoor);
						GameBase::setTeam(%rightdoor,%team);
						%rot2 = "0 1.57 0";
						%pos = Vector::add(%where,"0.04 -9.907 3.942");
						GameBase::setPosition(%rightdoor,%pos);
						GameBase::setRotation(%rightdoor,%rot2);
						Gamebase::setMapName(%rightdoor,"Outpost Door");
						$OutpostDevices[%outpostgen,6] = %rightdoor;

							//--- Left Door ---//
						%leftdoor = newObject("","StaticShape",OutpostDoor,true);
						addToSet("MissionCleanup", %leftdoor);
						GameBase::setTeam(%leftdoor,%team);
						%rot2 = "0 1.57 0";
						%pos = Vector::add(%where,"-4.45 -9.907 3.942");
						GameBase::setPosition(%leftdoor,%pos);
						GameBase::setRotation(%leftdoor,%rot2);
						Gamebase::setMapName(%leftdoor,"Outpost Door");
						$OutpostDevices[%outpostgen,7] = %leftdoor;

							//--- Roof ---//
						%roof = newObject("","StaticShape",OutpostWall,true);
						addToSet("MissionCleanup", %roof);
						GameBase::setTeam(%roof,%team);
						%rot2 = "1.57 0 3.14";
						%pos = Vector::add(%where,"-0.05 -7.726 7.735");
						GameBase::setPosition(%roof,%pos);
						GameBase::setRotation(%roof,%rot2);
						Gamebase::setMapName(%roof,"Outpost Roof");
						$OutpostDevices[%outpostgen,8] = %roof;

						%roof = newObject("","StaticShape",OutpostWall,true);
						addToSet("MissionCleanup", %roof);
						GameBase::setTeam(%roof,%team);
						%rot2 = "1.57 3.14 3.14";
						%pos = Vector::add(%where,"0 -7.726 7.735");
						GameBase::setPosition(%roof,%pos);
						GameBase::setRotation(%roof,%rot2);
						Gamebase::setMapName(%roof,"Outpost Roof");
						$OutpostDevices[%outpostgen,9] = %roof;

							//--- Floor ---//
						%floor = newObject("","StaticShape",OutpostFloor,true);
						addToSet("MissionCleanup", %floor);
						GameBase::setTeam(%floor,%team);
						%rot2 = "0 0 1.18";
						%pos = Vector::add(%where,"0 -7.726 -0.532");
						GameBase::setPosition(%floor,%pos);
						GameBase::setRotation(%floor,%rot2);
						Gamebase::setMapName(%floor,"Outpost Floor");
						$OutpostDevices[%outpostgen,10] = %floor;

							//--- Front Wall Shield ---//
						%rot2 = "0 0 0";
						%pos = Vector::add(%where,"0 -15.468 0");
						%frontwall = newObject("","StaticShape",OutpostWall,true);
						addToSet("MissionCleanup", %frontwall);
						GameBase::setTeam(%frontwall,%team);
						GameBase::setPosition(%frontwall,%pos);
						GameBase::setRotation(%frontwall,%rot2);
						Gamebase::setMapName(%frontwall,"Outpost Wall");
						$OutpostDevices[%outpostgen,11] = %frontwall;

						//--- Blah blah ---//
						Client::sendMessage(%client,0,"Outpost Deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[%team @ "OutpostPack"]++;
						echo("MSG: ",%client," deployed an Outpost");
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
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//----------------------------------------------------------------------------

// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object)=="OutpostWall")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
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
// Miscellany
//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
	description = "Repair Kit";
	shapeFile = "armorKit";
	heading = "pMiscellany";
	shadowDetailMask = 4;
	price = 5;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}

//----------------------------------------------------------------------------
// Mines - much of this code was ripped from Ideal
//----------------------------------------------------------------------------

ItemData MineAmmo
{
	showInventory = false;
	description = "Mine";
	shapeFile = "mineammo";
//	heading = "mMines";
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
};

ItemData OriginalMine
{
	description = "Anti-personnel Mine";
	shapeFile = "mineammo";
	heading = "mMines";
	shadowDetailMask = 4;
	price = 0;
	className = "Mine";
};

ItemData SatchelCharge
{
	description = "Satchel Charge";
	shapeFile = "camera";
	heading = "mMines";
	shadowDetailMask = 4;
	price = 5;
	className = "Mine";
};

ItemData SpringMine
{
	description = "Springboard";
	shapeFile = "flagstand";
	heading = "mMines";
	shadowDetailMask = 4;
	price = 0;
	className = "Mine";
};

ItemData PhaseLokMine
{
	description = "PhaseLok";
	shapeFile = "remoteTurret";
	heading = "mMines";
	shadowDetailMask = 4;
	price = 0;
	className = "Mine";
};

function MineAmmo::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if($matchStarted && %clientId.scrambled == 0)
	{
		if(%player.throwTime < getSimTime() )
		{
			%clientId = Player::getClient(%player);
			if(Player::getItemCount(%player, OriginalMine))
			{
				%name = "AntipersonelMine";
				%item = OriginalMine;
			}
			else if(Player::getItemCount(%player, BouncingBettyMine))
			{
				%name = "BettyMine";
				%item = BouncingBettyMine;
			}
			else if(Player::getItemCount(%player, SatchelCharge))
			{
				DeploySatchel(%clientId, %player, %item);
				return;
			}
			else if(Player::getItemCount(%player, SpringMine))
			{
				LaunchMine(%clientId, %player, %item);
				return;
			}
			else if(Player::getItemCount(%player, PhaseLokMine))
			{
				PhaseMine(%clientId, %player, %item);
				return;
			}
			else
				return;
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, MineAmmo);
			%obj = newObject("","Mine",%name);
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam(%obj,GameBase::getTeam(%client));//JR 1/31/99
			Client::setOwnedObject(%client, %obj);
			Client::setOwnedObject(%client, %player);
		}
	}
}


//----------------------------------------------------------------------------
// Grenades - much of this code was ripped from Ideal
//----------------------------------------------------------------------------

ItemData Grenade
{
	showInventory = false;
	description = "Grenade";
	shapeFile = "grenade";
//	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
};

ItemData OriginalGrenade
{
	description = "Frag Grenade";
	shapeFile = "grenade";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData EMPGrenade
{
	description = "EMP Grenade";
	shapeFile = "grenade";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 10;
	className = "Grenade";
};

ItemData ECMGrenade
{
	description = "ECM Grenade";
	shapeFile = "grenade";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 10;
	className = "Grenade";
};

ItemData FlareGrenade
{
	description = "Flash Grenade";
	shapeFile = "grenade";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 2;
	className = "Grenade";
};

ItemData PoisonGrenade
{
	description = "Jiffypop";
	shapeFile = "larmor";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "Grenade";
};

ItemData TearGasGrenade
{
	description = "Tear Gas Grenade";
	shapeFile = "rocket";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "Grenade";
};

ItemData ConcussionGrenade
{
	description = "Concussion Grenade";
	shapeFile = "mortar";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData Scrambler
{
	description = "Incindiary Grenade";
	shapeFile = "grenade";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData Plastique
{
	description = "Plastique";
	shapeFile = "sensor_small";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData GasCanGrenade
{
	description = "Gas Can";
	shapeFile = "liqcyl";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "Grenade";
};

ItemData StoneThrowGrenade
{
	description = "Bag of rocks";
	shapeFile = "mortar";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "Grenade";
};

ItemData DefenderGrenade
{
	description = "Sticky Bomb";
	shapeFile = "liqcyl";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "Grenade";
};

ItemData SmokerGrenade
{
	description = "Smoke Grenade";
	shapeFile = "grenade";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "Grenade";
};

ItemData MolotovGrenade
{
	description = "Molotov";
	shapeFile = "grenade";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "Grenade";
};

ItemData SuicideBomb
{
	description = "Bungee Ball";
	shapeFile = "mortarammo";
	heading = "lGrenades";
	shadowDetailMask = 4;
	price = 0;
	className = "Grenade";
};

function Grenade::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if($matchStarted && %clientId.scrambled == 0)
	{
		if(%player.throwTime < getSimTime() )
		{
			if(Player::getItemCount(%player, OriginalGrenade) > 0)
			{
				%item = OriginalGrenade;
				%name = "Handgrenade";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, EMPGrenade) > 0)
			{
				%item = EMPGrenade;
				%name = "EMPBomb";
				%chuckmod = 1;
			}
			else if(Player::getItemCount(%player, Plastique) > 0)
			{
				%item = Plastique;
				%name = "NukeBomb";
				Client::sendMessage(%clientId,1, "Plastic Explosive will explode in 15 seconds"); 
				%chuckmod = 0.5;
			}
			else if(Player::getItemCount(%player, GasCanGrenade) > 0)
			{
				%item = GasCanGrenade;
				%name = "GasCan";
				Client::sendMessage(%clientId,1, "Gas can dropped!  Run like hell!"); 
				%chuckmod = 0.5;
			}

			else if(Player::getItemCount(%player, StoneThrowGrenade) > 0)
			{
				%item = StoneThrowGrenade;
				%name = "StoneThrow";
				%chuckmod = 3.0;
			}

			else if(Player::getItemCount(%player, DefenderGrenade) > 0)
			{
				%item = DefenderGrenade;
				%name = "Defender";
				%chuckmod = 2.0;
			}

			else if(Player::getItemCount(%player, FlareGrenade) > 0)
			{
				%item = FlareGrenade;
				%name = "Flashgrenade";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, ConcussionGrenade) > 0)
			{
				%item = ConcussionGrenade;
				%name = "Concussion";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, PoisonGrenade) > 0)
			{
				%item = PoisonGrenade;
				%name = "Tranqgrenade";
				%chuckmod = 3;
			}
			else if(Player::getItemCount(%player, SuicideBomb) > 0)
			{
				%item = SuicideBomb;
				%name = "KamikazeBomb";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, TearGasGrenade) > 0)
			{
				%item = TearGasGrenade;
				%name = "Pacificationgrenade";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, ECMGrenade) > 0)
			{
				%item = ECMGrenade;
				%name = "Decloakgrenade";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, Scrambler) > 0)
			{
				%item = Scrambler;
				%name = "ScramblerBomb";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, MolotovGrenade) > 0)
			{
				%item = MolotovGrenade;
				%name = "Molotov";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, SmokerGrenade) > 0)
			{
				%item = SmokerGrenade;
				%name = "Smoker";
				%chuckmod = 2;
			}
			else
				return;
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
			%armor = Player::getArmor(%player);
			%obj = newObject("","Mine",%name);
 	 	 	addToSet("MissionCleanup", %obj);
			if(%name == "NukeBomb")
				schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", 15);
			if(%name == "GasCan")
				schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", 950);
			if(%name != "StoneThrow")
			GameBase::throw(%obj,%player,9 * %clientId.throwStrength * %chuckmod,false);
			else
			GameBase::throw(%obj,%player,20,false);

			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//----------------------------------------------------------------------------
// Beacon Items - much of this code was patterned after that found in Ideal
//----------------------------------------------------------------------------

ItemData Beacon
{
	showInventory = false;
	description = "Beacon";
	shapeFile = "sensor_small";
//	heading = "nBeacon Items";
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

ItemData TargetBeacon
{
	description = "Airstrike Beacon";
	shapeFile = "sensor_small";
	heading = "nBeacon Items";
	shadowDetailMask = 4;
	price = 5;
	className = "Beacon";
};

ItemData MotionBeacon
{
	description = "Motion Sensor";
	shapeFile = "sensor_small";
	heading = "nBeacon Items";
	shadowDetailMask = 4;
	price = 0;
	className = "Beacon";
};

ItemData JammerBeacon
{
	description = "Sensor Jammer";
	shapeFile = "sensor_jammer";
	heading = "nBeacon Items";
	shadowDetailMask = 4;
	price = 5;
	className = "Beacon";
};

ItemData CameraBeacon
{
	description = "Camera";
	shapeFile = "camera";
	heading = "nBeacon Items";
	shadowDetailMask = 4;
	price = 0;
	className = "Beacon";
};

ItemData AlarmBeacon
{
	description = "Base Alarm";
	shapeFile = "sensor_small";
	heading = "nBeacon Items";
	shadowDetailMask = 4;
	price = 0;
	className = "Beacon";
};

ItemData ShieldBeacon
{
	description = "Extra Gun Clip";
	shapeFile = "sensor_small";
	heading = "nBeacon Items";
	shadowDetailMask = 4;
	price = 0;
	className = "Beacon";
};

ItemData TeleportBeacon
{
	description = "OICW Grenades";
	shapeFile = "grenade";
	heading = "nBeacon Items";
	shadowDetailMask = 4;
	price = 0;
	className = "Beacon";
};

function Beacon::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if(%clientId.scrambled == 0)
	{
		if(Player::getItemCount(%player, TargetBeacon) > 0)
		{
			if (Beacon::deployShape(%player,%item))
			{
				Player::decItemCount(%player,"Beacon");
				Player::decItemCount(%player,"TargetBeacon");
			}
		}
		else if(Player::getItemCount(%player, MotionBeacon) > 0)
		{
			EngSensor(%clientId, %player, %item);
		}
		else if(Player::getItemCount(%player, CameraBeacon) > 0)
		{
			EngCamera(%clientId, %player, %item);
		}
		else if(Player::getItemCount(%player, JammerBeacon) > 0)
		{
			SniperJammer(%clientId, %player, %item);
		}
		else if(Player::getItemCount(%player, ShieldBeacon) > 0)
		{
		%cli = Player::getClient(%player);
		bottomprint(Player::getClient(%player), "<jc><f2>\nReloading Magazine fed weapons...\n", 3);
			Player::setItemCount(%player,"LavaAmmo",30);
			Player::setItemCount(%player,"RemingtonAmmo",15);
			Player::setItemCount(%player,"KlashnikovAmmo",30);
			Player::setItemCount(%player,"TaurusAmmo",6);
			Player::setItemCount(%player,"EagleAmmo",20);
			Player::setItemCount(%player,"PlasmaAmmo",30);
			Player::setItemCount(%player,"SniperAmmo",6);
			Player::setItemCount(%player,"DecoyAmmo",30);
			Player::setItemCount(%player,"GlockAmmo",12);
			Player::setItemCount(%player,"TommyGunAmmo",50);
			Player::setItemCount(%player,"AutoShotgunAmmo",12);
			Player::setItemCount(%player,"RugerAmmo",16);
			Player::setItemCount(%player,"ingramAmmo",32);
			Player::setItemCount(%player,"berettasmgammo",30);
			Player::setItemCount(%player,"miniuziammo",20);
			Player::setItemCount(%player,"famasammo",30);
			Player::setItemCount(%player,"taurusammo",6);
			Player::decItemCount(%player,"Beacon");
			Player::decItemCount(%player,"ShieldBeacon");
			Player::setAnimation(%player, 21);

			%item = Player::getMountedItem(%clientId,$WeaponSlot);
			Player::UnMountItem(%player,$WeaponSlot);
			Player::ReloadMyGun(%clientId, %item);			


		}
		else if(Player::getItemCount(%player, AlarmBeacon) > 0)
		{
			AlarmDeploy(%clientId, %player, %item);
		}
		else if(Player::getItemCount(%player, TeleportBeacon) > 0)
		{
			%weaponName = Player::getMountedItem(%player,$WeaponSlot);
			// bottomprint(Player::getClient(%player), %weaponName, 2);
			
			if(%weaponName == OICW) //OICW grenade launcher, two weapons in one -- Deadtaco
			{
				%Shooter = Player::getClient(%player);
				
				if($GrenadeLaunching[%Shooter] == 0)
				{
				$GrenadeLaunching[%Shooter] = 1;
				schedule("$GrenadeLaunching[" @ %Shooter @ "] = 0;", 2.0); // wait a second before another OICW grenade can be used.
		 		%trans = GameBase::getMuzzleTransform(%player);
		 		%vel = Item::getVelocity(%player);
		 		Projectile::spawnProjectile("OICWGrenade",%trans,%player,%vel);
				// bottomprint(Player::getClient(%player), "OICW Grenade away!  Clear!", 2);
				playSound(SoundFireGrenade,GameBase::getPosition(%player));
				Player::decItemCount(%player,"Beacon");
				Player::decItemCount(%player,"TeleportBeacon");
				$GrenadeLaunching[%Shooter] = 1;
				}
				else
				{
				bottomprint(Player::getClient(%player), "<jc><f1>OICW Grenade reloading.  Please wait.", 2);
				}
			}

		}
		else
		{
		}
	}
}

//****************************************************

function Player::ReloadMyGun(%clientId, %item)
{

playSound(SoundthrowItem,GameBase::getPosition(%clientId));
%mypos = GameBase::getPosition(%clientId);

schedule("Player::CheckReloadTime(" @ %clientId @ ");", 0.1);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 0.3);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 0.5);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 0.7);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 0.9);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 1.1);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 1.3);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 1.7);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 2.0);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 2.5);
schedule("Player::CheckReloadTime(" @ %clientId @ ");", 2.7);
schedule("Player::Finishreloading(" @ %clientId @ ", " @ %item @ ");", 3.0);

schedule("playSound(SoundReload2, '" @ %mypos @ "' );", 1.0);
schedule("playSound(SoundReload1, '" @ %mypos @ "' );", 1.5);
schedule("playSound(SoundReload4, '" @ %mypos @ "' );", 2.5);
schedule("playSound(SoundthrowItem, '" @ %mypos @ "' );", 3.0);


}

function Player::CheckReloadTime(%clientId)
{

%item = Player::getMountedItem(%clientId,$WeaponSlot);
if (%item != -1)
	Player::UnMountItem(%clientId,$WeaponSlot);

}

function Player::FinishReloading(%clientId, %item)
{

Player::MountItem(%clientId,%item,$weaponSlot);
	
}


// Regular Beacon

function Beacon::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,20))
	{
		// GetLOSInfo sets the following globals:
		// 	los::position
		// 	los::normal
		// 	los::object
		%obj = getObjectType($los::object);
			// Try to stick it straight up or down, otherwise
			// just use the surface normal
			if (Vector::dot($los::normal,"0 0 1") > 0.6)
			{
				%rot = "0 0 0";
			}
			else
			{
				if (Vector::dot($los::normal,"0 0 -1") > 0.6)
				{
					%rot = "3.14159 0 0";
				}
				else
				{
					%rot = Vector::getRotation($los::normal);
				}
			}
			%bypassDeployCheck = 1;
			// if(checkBeaconDeployArea(%client,$los::position))
			if(%bypassDeployCheck == 1)
			{
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[TargetBeacon] > $TeamItemCount[%team @ "TargetBeacon"] || $TestCheats)
				{
					%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
					addToSet("MissionCleanup", %beacon);
					%beacon.owner = %player;
					//, CameraTurret, true);
					
					GameBase::setTeam(%beacon,GameBase::getTeam(%player));
					GameBase::setRotation(%beacon,%rot);
					GameBase::setPosition(%beacon,$los::position);
					Gamebase::setMapName(%beacon,"Airstrike Beacon");
					$BeaconOwner[%beacon] = %client;
					$LastBeaconOwner = %client;
					$RB::BeaconOwner[%beacon] = %client;
					
					//Deadtaco's super cool airstrike beacon
					//now create the bomb beacon
		 			%loc = Gamebase::getPosition(%beacon);
		 			%locZ = getWord(%loc,2);
		 			%locx = getWord(%loc,0);
		 			%locy = getWord(%loc,1);

					//airplane 1
					%beaconx = newObject("Strike Beacon", "StaticShape", "StrikeBeacon", true);
					addToSet("MissionCleanup", %beaconx);
					
					GameBase::setTeam(%beaconx,GameBase::getTeam(%player));
					GameBase::setRotation(%beaconx,"0 0 0");
					Gamebase::setPosition(%beaconx, " " @ %locx @ " " @ %locy - 500 @ " " @ %locz + 150 @ " ");

					Gamebase::setMapName(%beaconx,"Airstrike Beacon");

					//airplane 2
					%beaconx = newObject("Strike Beacon", "StaticShape", "StrikeBeacon", true);
					addToSet("MissionCleanup", %beaconx);
					
					GameBase::setTeam(%beaconx,GameBase::getTeam(%player));
					GameBase::setRotation(%beaconx,"0 0 0");
					Gamebase::setPosition(%beaconx, " " @ %locx - 25 @ " " @ %locy - 525 @ " " @ %locz + 150 @ " ");

					Gamebase::setMapName(%beaconx,"Airstrike Beacon");
					//airplane 3

					%beaconx = newObject("Strike Beacon", "StaticShape", "StrikeBeacon", true);
					addToSet("MissionCleanup", %beaconx);
					
					GameBase::setTeam(%beaconx,GameBase::getTeam(%player));
					GameBase::setRotation(%beaconx,"0 0 0");
					Gamebase::setPosition(%beaconx, " " @ %locx + 25 @ " " @ %locy - 525 @ " " @ %locz + 150 @ " ");

					Gamebase::setMapName(%beaconx,"Airstrike Beacon");

					//airplane 4

					%beaconx = newObject("Strike Beacon", "StaticShape", "StrikeBeacon", true);
					addToSet("MissionCleanup", %beaconx);
					
					GameBase::setTeam(%beaconx,GameBase::getTeam(%player));
					GameBase::setRotation(%beaconx,"0 0 0");
					Gamebase::setPosition(%beaconx, " " @ %locx + 50 @ " " @ %locy - 550 @ " " @ %locz + 150 @ " ");

					Gamebase::setMapName(%beaconx,"Airstrike Beacon");

					//airplane 5

					%beaconx = newObject("Strike Beacon", "StaticShape", "StrikeBeacon", true);
					addToSet("MissionCleanup", %beaconx);
					
					GameBase::setTeam(%beaconx,GameBase::getTeam(%player));
					GameBase::setRotation(%beaconx,"0 0 0");
					Gamebase::setPosition(%beaconx, " " @ %locx - 50 @ " " @ %locy - 550 @ " " @ %locz + 150 @ " ");

					Gamebase::setMapName(%beaconx,"Airstrike Beacon");

					Beacon::onEnabled(%beacon);
					Client::sendMessage(%client,0,"Airstrike Beacon deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "TargetBeacon"]++;
					echo("MSG: ",%client," deployed a Target Beacon");
					return true;
				}
				else
					Client::sendMessage(%client,0,"Deployable Item limit reached");
			}
			else
				Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	}
	else
		Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}

function checkBeaconDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.3,0.3,0.3,1);
	if(!%num)
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "StaticShape" && (GameBase::getDataName(Group::getObject(%set,0)) == "DeployableForceField"
		|| GameBase::getDataName(Group::getObject(%set,0)) == "DeployableLargeForceField" || GameBase::getDataName(Group::getObject(%set,0)) == "BlastWallShape"
		|| GameBase::getDataName(Group::getObject(%set,0)) == "LargeAirBasePlatform" || GameBase::getDataName(Group::getObject(%set,0)) == "OutpostFloor"
		|| GameBase::getDataName(Group::getObject(%set,0)) == "OutpostWall" || GameBase::getDataName(Group::getObject(%set,0)) == "AlarmKit" || GameBase::getDataName(Group::getObject(%set,0)) == "DoomsdayDevice")) 
	{ 
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
	else if(%num == 1)
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	else
		Client::sendMessage(%client,0,"Unable to deploy - One or more items and/or players in the way");
	deleteObject(%set);
	return 0;	
}

//****************************************************

// Motion Sensor

function EngSensor(%clientId, %player, %item)
{
	if (MotionSensorPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,"Beacon");
		Player::decItemCount(%player,"MotionBeacon");
		$TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
	}
}

function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[MotionSensorPack])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape")
//			{
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
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
//			}
//			else
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");		
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//*********************************************

// Springboard - ripped (presumably from Renegades) by the Tricon Team

function LaunchMine(%clientId, %player, %item)
{
 	if (SpringPack::deployShape(%player,%item))
 	{
		Player::decItemCount(%player,"MineAmmo");
		Player::decItemCount(%player,"SpringMine");
	}
}

function SpringPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "Springboard"] < $TeamItemMax[Springboard])
        {
                if (GameBase::getLOSInfo(%player,3)) 
                {
			if(checkBeaconDeployArea(%client,$los::position))
			{
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
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}

//*************************************************

//****************************************************

// Camera

function EngCamera(%clientId, %player, %item)
{
	if (CameraPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,"Beacon");
		Player::decItemCount(%player,"CameraBeacon");
	}
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[CameraPack])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape")
//			{
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
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
//			}
//			else
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");		
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//**************************************

// Deployable Sensor Jammer REMOVED

//**************************************

// Satchel Charge - ripped from Shifter

function DeploySatchel(	%clientId, %player, %bec)
{
	%item = "SatchelPack";
	%client = Player::getClient(%player);

	if($TeamItemCount[GameBase::getTeam(%player) @ "SatchelPack"] < $TeamItemMax["SatchelPack"])
	{
		if (GameBase::getLOSInfo(%player,20)) 
		{
			%obj = getObjectType($los::object);
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
				%camera = newObject("Camera","Turret",DeployableSatchel,true);
	   	   		addToSet("MissionCleanup", %camera);
				GameBase::setTeam(%camera,GameBase::getTeam(%player));
				GameBase::setRotation(%camera,%rot);
				GameBase::setPosition(%camera,$los::position);
				Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen.");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++;
				echo("MSG: ",%client," deployed a Satchel Charge.");
				Player::decItemCount(%player,"MineAmmo");
				Player::decItemCount(%player,"SatchelCharge");
				//	Remote turrets - kill points to player that deploy them
				Client::setOwnedObject(%client, %camera);
				Client::setOwnedObject(%client, %player);
				return true;
			}
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");		
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for Satchel Charges");
	return false;
}

//**************************************


// Part of Plastique - ripped from Shifter

function Grenade::Plastic_Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//**************************************

// Jail Capture Pad - an original idea from the Tricon Team

function JailPadMine(%clientId, %player, %item)
{
        if (JailCapPack::deployShape(%player,%item)) 
        {
		Player::decItemCount(%player,"MineAmmo");
		Player::decItemCount(%player,"JailMine");
        }
}

function JailCapPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"] < $TeamItemMax[JailCapPack]) 
        {
		if (GameBase::getLOSInfo(%player,3)) 
		{
			%obj = getObjectType($los::object);
			%playerPos = GameBase::getPosition(%player);
			%flag = $teamFlag[GameBase::getTeam(%player)];
			%flagpos = gamebase::getPosition(%flag);
			if(Vector::getDistance(%flagpos, %playerpos) < 10)
			{
				Client::sendMessage(%client,0,"You are too close to your mainframe, Must be further from mainframe to deploy.");
				return;
			}
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
			%rot =  "1.57079 0 " @ %zRot;
			%padd = "0 0 0";
			%pos = Vector::add($los::position,%padd);
			if(checkDeployArea(%client,$los::position))
			{
				%camera = newObject("","StaticShape","jailpad",true);
				addToSet("MissionCleanup", %camera);
				GameBase::setTeam(%camera,GameBase::getTeam(%player));
				GameBase::setRotation(%camera,"0 0 0");
				GameBase::setPosition(%camera,%pos);
				Gamebase::setMapName(%camera,"JailPad " @ $totalNumCameras++ @ " " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Jail Pad Deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"]++;
				echo("MSG: ",%client," deployed a Jail Pad");
				return true;
			}
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
		Client::sendMessage(%client,0,"Deployable Item limit reached for Jail Capture Pads");
	return false;
}


//**************************************

// Base Alarm - taken from Redneck Slag Pack

function AlarmDeploy(%clientId, %player, %item)
{
	if (BaseAlarm::deployShape(%player,%item))
	{
		Player::decItemCount(%player,"Beacon");
		Player::decItemCount(%player,"AlarmBeacon");
	}
}

function BaseAlarm::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);

	if (GameBase::getLOSInfo(%player,3))
	{
		if($TeamItemCount[GameBase::getTeam(%player) @ "BaseAlarm"] < $TeamItemMax[BaseAlarm])
		{
			%obj = getObjectType($los::object);
			if (%obj == "InteriorShape" || GameBase::getDataName($los::object)=="OutpostWall" || GameBase::getDataName($los::object)=="OutpostFloor" || GameBase::getDataName($los::object)=="LargeAirBasePlatform")
			{
				// Try to stick it straight up or down, otherwise
				// just use the surface normal
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 0";
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 0";
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
				if(checkDeployArea(%client,$los::position))
				{
					%alarm = newObject("","StaticShape", "AlarmKit",true);
					addToSet("MissionCleanup", %alarm);
					GameBase::setTeam(%alarm,GameBase::getTeam(%player));
					GameBase::setRotation(%alarm,%rot);
					GameBase::setPosition(%alarm,$los::position);
					Gamebase::setMapName(%alarm,"Base Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)]++);
					Client::sendMessage(%client,0,"Alarm #" @ $totalNumAlarms[GameBase::getTeam(%player)] @ " deployed");
					$TeamItemCount[GameBase::getTeam(%player) @ "BaseAlarm"]++;
					$pause[%alarm] = 0;
					echo("MSG: ",%client," deployed a Base Alarm");
					return true;
				}
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on buildings");
		}
		else
			Client::sendMessage(%client,0,"Deployable Item limit reached for Base Alarms");
	}
	else
		Client::sendMessage(%client,0,"Deploy position out of range");
	return false;
}

//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
	heading = "gMiscellany";
	shadowDetailMask = 4;
  	price = 2;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		if(GameBase::getDamageLevel(%object))
		{
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

// Drones - Ripped from Tribal Combat mod

function DeployDrone(%player,%item,%shape,%data)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		%rot = GameBase::getRotation(%player);
		%obj = newObject(%item.description,%data,%shape,true);
		addToSet("MissionCleanup",%obj);
		GameBase::setTeam(%obj,GameBase::getTeam(%player));
	

		%CurrentPos = Vector::Add(GameBase::getPosition(%player),"0 5 0");
		GameBase::setPosition(%obj,Stormbots::DronePosition(%player));

		GameBase::setRotation(%obj,%rot);
		Gamebase::setMapName(%obj,%item.description);
		Client::sendMessage(%client,0,%item.description @" Deployed ");
		GameBase::startFadeIn(%obj);
		playSound(SoundPickupBackpack,Stormbots::DronePosition(%player));
		echo("MSG: ",%client," deployed a " @ %item.description);

		%weapon = Player::getMountedItem(%player,$WeaponSlot);
		if(%weapon != -1)
		{
			%player.lastWeapon = %weapon;
			Player::unMountItem(%player,$WeaponSlot);
		}
		Client::setControlObject(%client, %obj);
		$Stormbots::UsingDrone[%client] = true;
		%player.vehicle = %obj;
		%obj.pilot = %client;
		$TeamItemCount[GameBase::getTeam(%player) @ %item]++;

		if (%shape == "AttackDrone")
		{
			%obj.weaponry = $Weaponry[%shape];
			%obj.AmmoMinimum = $AmmoMinimum[%shape];
			%obj.firesound = $FireSound[%shape];
			%obj.AmmoCost = $AmmoCost[%shape];
			%obj.firedelay = $FireDelay[%shape];
			%obj.attacktype = $AttackType[%shape];
			%obj.multi = $Multi[%shape];
			%obj.firecount = $FireCount[%shape];
		}
		return true;
	}
	else
		Client::sendMessage(%client,0,"Maximum number of "@ %item.description @"s deployed.");
	return false;
}

function Stormbots::DronePosition(%player)
{
	%rot = GameBase::getRotation(%player);
	%pos  = GameBase::getPosition(%player);
   
	//get player's x, y and z positions
	%comm_x = getWord(%pos, 0);
	%comm_y = getWord(%pos, 1);
	%comm_z = getWord(%pos, 2);

	//get offset x and y positions
	%offSetPos = Vector::getFromRot(%rot, 3);
	%off_x = getWord(%offSetPos, 0);
	%off_y = getWord(%offSetPos, 1);

	//calc new position
	%new_x = %comm_x + %off_x;
	%new_y = %comm_y + %off_y;
	%newPos = %new_x  @ " " @ %new_y @ " " @ %comm_z + 10;

	return %newPos;
}

//--------------------------------------

ItemImageData ADPackImage
{
	shapeFile = "flyer";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	mountRotation = { 0, -1.5, 1.5 };
	mass = 1.0;
	minEnergy = 8;
 	maxEnergy = 9;
	firstPerson = false;
};

ItemData AttackDronePack
{
	description = "RC Army Drone";
	shapeFile = "flyer";
	className = "Backpack";
	heading = "kRemote Drones";
	shadowDetailMask = 4;
	imageType = ADPackImage;
	mass = 0.5;
	price = 0;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AttackDronePack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function AttackDronePack::onDeploy(%player,%item,%pos)
{
	if(DeployDrone(%player,%item,AttackDrone,flier))
		if(!Player::isDead(%player))
			Player::decItemCount(%player,%item);
}

$Weaponry[AttackDrone] = AttackDroneGun;
$AmmoMinimum[AttackDrone] = 20;
$FireSound[AttackDrone] = SoundFireFightergun;
$AmmoCost[AttackDrone] = 5;
$FireDelay[AttackDrone] = 5;
$AttackType[AttackDrone] = FighterBullet;
$Multi[AttackDrone] = 1;
$FireCount[AttackDrone] = 0;

//--------------------------------------

// Vehicle Weapons

ItemImageData MiscModuleImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 0;
	fireTime = 0;

//	ammoType = "Unknown";
//	projectileType = "Unknown";
	accuFire = false;

	lightType = 0;
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 0, 0, 0 };

};

ItemImageData FighterGunImage
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 10.0, 10 }; 
	mountRotation = { 0, 3.14159, 0 }; 

	weaponType = 1; // Spinning
	reloadTime = 0.05;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	projectileType = FighterBullet;
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

ItemData FighterGun
{
	description = "Rotary Cannon";
	className = "VehicleWeapon";
	shapeFile = "chaingun";
 	hudIcon = "chain";
	heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = FighterGunImage;
	price = 0;
	showWeaponBar = true;
};

$Weaponry[FighterGun] = FighterGun;
$AmmoMinimum[FighterGun] = 20;
$FireSound[FighterGun] = SoundFireFightergun;
$AmmoCost[FighterGun] = 3;
$FireDelay[FighterGun] = 5;
$AttackType[FighterGun] = FighterBullet;
$Multi[FighterGun] = 1;
$FireCount[FighterGun] = 0;

ItemData VehicleRocket
{
	description = "LAU Rockets";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
	heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 0;
	showWeaponBar = true;
};

$Weaponry[VehicleRocket] = VehicleRocket;
$AmmoMinimum[VehicleRocket] = 50;
$FireSound[VehicleRocket] = SoundFireFlierRocket;
$AmmoCost[VehicleRocket] = 25;
$FireDelay[VehicleRocket] = 5;
$AttackType[VehicleRocket] = FlierRocket;
$Multi[VehicleRocket] = 1;
$FireCount[VehicleRocket] = 0;

ItemData NapalmLauncher
{
	description = "Flame Thrower";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
	heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 0;
	showWeaponBar = true;
};

$Weaponry[NapalmLauncher] = NapalmLauncher;
$AmmoMinimum[NapalmLauncher] = 15;
$FireSound[NapalmLauncher] = SoundFlameTurret;
$AmmoCost[NapalmLauncher] = 15;
$FireDelay[NapalmLauncher] = 14;
$AttackType[NapalmLauncher] = FlameLarge;
$Multi[NapalmLauncher] = 1;
$FireCount[NapalmLauncher] = 0;

ItemData VehicleMineLauncher
{
	description = "Mine Launcher";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
	heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 0;
	showWeaponBar = true;
};

$Weaponry[VehicleMineLauncher] = VehicleMineLauncher;
$AmmoMinimum[VehicleMineLauncher] = 25;
$FireSound[VehicleMineLauncher] = SoundFireGrenade;
$AmmoCost[VehicleMineLauncher] = 25;
$FireDelay[VehicleMineLauncher] = 30;
$AttackType[VehicleMineLauncher] = MineShell;
$Multi[VehicleMineLauncher] = 1;
$FireCount[VehicleMineLauncher] = 0;

ItemData VehicleShockCannon
{
	description = "Shockwave Cannon";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
	heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 0;
	showWeaponBar = true;
};

$Weaponry[VehicleShockCannon] = VehicleShockCannon;
$AmmoMinimum[VehicleShockCannon] = 25;
$FireSound[VehicleShockCannon] = SoundPlasmaTurretFire;
$AmmoCost[VehicleShockCannon] = 25;
$FireDelay[VehicleShockCannon] = 30;
$AttackType[VehicleShockCannon] = Shock;
$Multi[VehicleShockCannon] = 1;
$FireCount[VehicleShockCannon] = 0;

ItemData VehicleClusterCannon
{
	description = "Cluster Cannon";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
	heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 0;
	showWeaponBar = true;
};

$Weaponry[VehicleClusterCannon] = VehicleClusterCannon;
$AmmoMinimum[VehicleClusterCannon] = 10;
$FireSound[VehicleClusterCannon] = turretExplosion;
$AmmoCost[VehicleClusterCannon] = 10;
$FireDelay[VehicleClusterCannon] = 12;
$AttackType[VehicleClusterCannon] = ClusterBombShell;
$Multi[VehicleClusterCannon] = 6;
$FireCount[VehicleClusterCannon] = 0;

ItemData VehicleEMPLauncher
{
	description = "EMP Grenade Launcher";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
	heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 0;
	showWeaponBar = true;
};

$Weaponry[VehicleEMPLauncher] = VehicleEMPLauncher;
$AmmoMinimum[VehicleEMPLauncher] = 50;
$FireSound[VehicleEMPLauncher] = SoundSpinUpDisc;
$AmmoCost[VehicleEMPLauncher] = 50;
$FireDelay[VehicleEMPLauncher] = 30;
$AttackType[VehicleEMPLauncher] = EMPShell;
$Multi[VehicleEMPLauncher] = 1;
$FireCount[VehicleEMPLauncher] = 0;

ItemData VehicleBomb
{
	description = "High-Explosive Bomb";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
	heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 0;
	showWeaponBar = true;
};

$Weaponry[VehicleBomb] = VehicleBomb;
$AmmoMinimum[VehicleBomb] = 100;
$FireSound[VehicleBomb] = SoundFireMortar;
$AmmoCost[VehicleBomb] = 100;
$FireDelay[VehicleBomb] = 1;
$AttackType[VehicleBomb] = VehicleBombAttack;
$Multi[VehicleBomb] = 1;
$FireCount[VehicleBomb] = 0;


//----------------------------------------------------------------------------


ItemData DecoyAmmo
{
	showInventory = true;
	description = "Mp5 Rounds";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DecoyGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	mountrotation = {0, 3, 0};
	weaponType = 0; // Single Shot
	ammoType = DecoyAmmo;
	projectileType = DecoyBolt;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.08;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = debrisMediumExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData DecoyGun
{
	showInventory = true;
	description = "HK MP5";
	className = "PriWeapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = "bPrimary Weapons";
	shadowDetailMask = 4;
	imageType = DecoyGunImage;
	price = 5;
	showWeaponBar = true;
};

function DecoyGun::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if (%clientId.traitor == 1)
		Client::sendMessage(%clientId,0,"You are too drunk to do anything.  Stop drinking your molotovs!.");
	else if (%clientId.pacified == 1)
		Client::sendMessage(%clientId,0,"Cannot mount weapons while affected by Tear Gas.");
	else
	{
		Weapon::onUse(%player,%item);
		bottomprint(Player::getClient(%player), "<jc><f2>Using MP5.  Great Close-range submachinegun.", 2);
	}
}





// New and Roaming Purchaseable Bots

ItemData Runner_CMD
{
	description = "Runner Bot";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 0;
};

ItemData Guard_NRS
{
	description = "Roaming Guard";
	className = "Bot";
	shapeFile = "harmor";
	heading = "aBot";
	price = 0;
};

ItemData Mortar_NRS
{
	description = "Roaming Mortarman";
	className = "Bot";
	shapeFile = "harmor";
	heading = "aBot";
	price = 0;
};

ItemData Demo_NRS
{
	description = "Roaming Demo Bot";
	className = "Bot";
	shapeFile = "marmor";
	heading = "aBot";
	price = 0;
};

ItemData Medic_NRS
{
	description = "Roaming Medic";
	className = "Bot";
	shapeFile = "marmor";
	heading = "aBot";
	price = 0;
};

ItemData Miner_NRS
{
	description = "Roaming Minelayer";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 0;
};

ItemData Sniper_NRS
{
	description = "Roaming Sniper";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 0;
};

ItemData Painter_NRS
{
	description = "Roaming Painter";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 0;
};

ItemData Runner_NRS
{
	description = "Roaming Runner";
	className = "Bot";
	shapeFile = "larmor";
	heading = "aBot";
	price = 0;
};


// ---------------------------------------


function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if (%numweapon > $MaxWeapons[%armor])
	{
	   %weaponflag = %numweapon - $MaxWeapons[%armor];
	}
 	%toolflag = 0;
	%numtool = Player::getItemClassCount(%client,"Tool");
	if (%numtool > $MaxTools[%armor])
	{
	   %toolflag = %numtool - $MaxTools[%armor];
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
			if (%count > 0 && %weaponflag && %item.className == PriWeapon)
			{
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if (%count > 0 && %toolflag && %item.className == Tool)
			{
				%numsell = 1;
				%toolflag = %toolflag - 1;
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
	for(%i = 0; %i < 8; %i++)
	{
		$TeamItemCount[%i @ "TurretPack"] = 0;
		$TeamItemCount[%i @ "ChaingunTurretPack"] = 0;
		$TeamItemCount[%i @ "SeekerPack"] = 0;
		$TeamItemCount[%i @ "FlakPack"] = 0;
		$TeamItemCount[%i @ "IonPack"] = 0;
		$TeamItemCount[%i @ "ConPack"] = 0;
		$TeamItemCount[%i @ "FlameTurretPack"] = 0;
		$TeamItemCount[%i @ "ObeliskPack"] = 0;
		$TeamItemCount[%i @ "PlasmaPack"] = 0;
		$TeamItemCount[%i @ "AntiMatterTurretPack"] = 0;
		$TeamItemCount[%i @ "PlasmaTurretDecoyPack"] = 0;
		$TeamItemCount[%i @ "EngineerTurretPack"] = 0;
		$TeamItemCount[%i @ "BarragePack"] = 0;

		$TeamItemCount[%i @ "DeployableAmmoPack"] = 0;
		$TeamItemCount[%i @ "DeployableInvPack"] = 0;
		$TeamItemCount[%i @ "BotStationPack"] = 0;
		$TeamItemCount[%i @ "DeployableForceField"] = 0;
		$TeamItemCount[%i @ "DeployableLargeForceField"] = 0;
		$TeamItemCount[%i @ "ObeliskPowerPack"] = 0;
		$TeamItemCount[%i @ "DeployableLRMotionSensorPack"] = 0;
		$TeamItemCount[%i @ "AccelPPack"] = 0;
                $TeamItemCount[%i @ "BlastWall"] = 0;
                $TeamItemCount[%i @ "openabledoor"] = 0;
                $TeamItemCount[%i @ "sandbag"] = 0;
                $TeamItemCount[%i @ "SniperPerchPlatform"] = 0;
		$TeamItemCount[%i @ "DeployableSolarPanel"] = 0;
		$TeamItemCount[%i @ "UtilityPack"] = 0;
		$TeamItemCount[%i @ "Mirage"] = 0;

		$TeamItemCount[%i @ "DShieldPack"] = 0;
		$TeamItemCount[%i @ "airbase"] = 0;
                $TeamItemCount[%i @ "jailpack"] = 0;
		$TeamItemCount[%i @ "OutpostPack"] = 0;
		$TeamItemCount[%i @ "DeployableFullInvPack"] = 0;

		$TeamItemCount[%i @ "ScoutVehicle"] = 0;
		$TeamItemCount[%i @ "LAPCVehicle"] = 0;
		$TeamItemCount[%i @ "HAPCVehicle"] = 0;


		$TeamItemCount[%i @ "TargetBeacon"] = 0;
		$TeamItemCount[%i @ "CameraPack"] = 0;
		$TeamItemCount[%i @ "MotionSensorPack"] = 0;
		$TeamItemCount[%i @ "BaseAlarm"] = 0;

		$TeamItemCount[%i @ "OriginalMine"] = 0;
		$TeamItemCount[%i @ "BouncingBettyMine"] = 0;
		$TeamItemCount[%i @ "originalreplicatingmine"] = 0;
		$TeamItemCount[%i @ "replicatingmine"] = 0;
		$TeamItemCount[%i @ "HologramMine"] = 0;
		$TeamItemCount[%i @ "SatchelPack"] = 0;
                $TeamItemCount[%i @ "Springboard"] = 0;
		$TeamItemCount[%i @ "PhaseLokAmmo"] = 0;

		$TeamItemCount[%i @ AttackDronePack] = 0;

		$TeamBotUnavailable[%i] = 0;
		$totalNumAlarms[%i] = 0;

	}

	$totalNumAlarms[-1] = 0;
	$totalNumCameras = 0;
	$totalNumTurrets = 0;
	$totalNumDecoys = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

//--------------------------------------------------------------------------------------------------


instant SimGroup "elevatorRB" 
{
	instant SimPath "Path1" 
	{
		isLooping = "False";
		isCompressed = "False";
		instant Marker "Marker1" {
			dataBlock = "PathMarker";
			name = "";
			position = "0 0 -3.33333";
			rotation = "0 0 0";
		};
		instant Marker "Marker1" {
			dataBlock = "PathMarker";
			name = "";
			position = "0 0 6.66666";
			rotation = "0 0 0";
		};
	};
	instant Moveable "elevatorrb_octo1" {
		dataBlock = "elevatorrbcta";
		name = "";
		position = "0 0 -3.33333";
		rotation = "0 0 0";
		destroyable = "True";
		deleteOnDestroy = "False";
		Status = "up";
	};
};









// Inventory Help Messages

function remoteDisplayHelpMessage(%client)
{
	%sel = Control::getValue(BuyList);
	if (%sel > 0 && $LastSelectedItem != %sel)
	{
		%item = getItemData(%sel);
		if(!%client.disablehelp)
			Client::sendMessage(%client,0,"HELP - " @ %item.description @ ": " @ $HelpMessage[%item]);
		$LastSelectedItem = %sel;
	}
}

$HelpMessage[HyperArmor] = "Quick and agile without kevlar protection.";
$HelpMessage[LightArmor] = "Skilled with the 50 cal Barrett rifle.";
$HelpMessage[EngArmor] = "Able to deploy most items - max. 2 weapons, 2 tools.";
$HelpMessage[MediumArmor] = "Carries 4 grenades and a devestating grenade launcher.";
$HelpMessage[HeavyArmor] = "A strong soldier capable of wielding the M60 machinegun.";
$HelpMessage[UltraArmor] = "The only strong soldier who can wield the Stinger and Minigun.";

$HelpMessage[Blaster] = "Desert Eagle 50 Cal.  Great close-combat weapon";
$HelpMessage[Chaingun] = "Dispenses bullets at an extreme rate.  Great for mowing down armies.";
$HelpMessage[Disclauncher] = "The M60 is an extremely heavy and damaging machinegun.";
$HelpMessage[GrenadeLauncher] = "Fires an explosive grenade - good for shooting around corners.";
$HelpMessage[Mortar] = "Fires a highly destructive bomb - use with caution.";
$HelpMessage[PlasmaGun] = "Great long-range automatic weapon.";
$HelpMessage[LaserRifle] = "Fires a powerful laser beam - good for long to very long range.";
$HelpMessage[EnergyRifle] = "Drains energy from players and/or items and damages forcefields - close range only.";
$HelpMessage[RocketLauncher] = "Fires a target-tracking missile if you have your cross-hairs on the target, a dumbfire missile otherwise.";
$HelpMessage[SniperRifle] = "Used to punch holes straight through engine blocks at a long range.";
$HelpMessage[RealTargetingLaser] = "Will give your team-mates markers showing where they should fire to hit the target.";
$HelpMessage[FlareGun] = "A very long sword-like spear.  Use it to hack and push your enemies."; // MODERN-PORT: missing ';' truncated item.cs here ("ITEM.cs Line: 6940 - Syntax error"), losing the 60 help strings below
$HelpMessage[MineLauncher] = "Flamethrower is great to incinerate your enemies.";
$HelpMessage[FusionGun] = "Fires highly destructive energy bolts that explode after travelling a short distance.";
$HelpMessage[PlasmaCannon] = "Double Barrelled shotgun.  Deadly at close range, useless at far range.";
$HelpMessage[BulletAmmo] = "Ammunition for the Minigun.";
$HelpMessage[PlasmaAmmo] = "Ammunition for the shotgun.";
$HelpMessage[DiscAmmo] = "Ammunition for the M60.";
$HelpMessage[GrenadeAmmo] = "Ammunition for the Grenade Launcher.";
$HelpMessage[MortarAmmo] = "Ammunition for the Mortar.";
$HelpMessage[RocketAmmo] = "Ammunition for the Stinger.";
$HelpMessage[SniperAmmo] = "Ammunition for the Sniper Rifle.";
$HelpMessage[FlareAmmo] = "Ammunition for the Flare Gun.";
$HelpMessage[MinelAmmo] = "Fuel for the flamethrower.";

$HelpMessage[AmmoPack] = "Increases the amount and types of ammunition you can carry.";
$HelpMessage[RepairPack] = "Allows for the repair of items and players at short range, including yourself.";
$HelpMessage[ShieldPack] = "When activated, causes damage done to you to be taken from your energy reserves rather than from your health.";

$HelpMessage[ConstructorPack] = "Allows you to build ramps up to high places.";

$HelpMessage[ChaingunTurretPack] = "Fires a stream of bullets at enemy players.";
$HelpMessage[SeekerPack] = "Explodes with a fury of metal fragments when an enemy comes close.";
$HelpMessage[FlakPack] = "Fires dumbfire missiles at jetting players or vehicles.";
$HelpMessage[EngineerTurretPack] = "Can be configured by an Engineer by bumping into it. Can attract, repulse, drop mines or do other gravity-related stuff.";

$HelpMessage[DeployableInvPack] = "Allows you to purchase a limited range of items out in the field.";
$HelpMessage[DeployableAmmoPack] = "A cache of ammunition for field deployment.";
$HelpMessage[BotStationPack] = "Supercharges your thrusters for extra flight time.";
$HelpMessage[UtilityPack] = "Configured by an Engineer bumping into it. Has repair, powerdrain, and hack mode.";

$HelpMessage[OutpostPack] = "A generator, remote inv. station and remote ammo station surrounded by Blast Walls and Force Field doors.";

$HelpMessage[RepairKit] = "Will repair your health when used.";

$HelpMessage[OriginalMine] = "An explosive mine that burrows into the ground/floor when dropped.";
$HelpMessage[SatchelCharge] = "A camera with a bomb attached which you can set off from your Command Screen.";
$HelpMessage[SpringMine] = "A small pad that will throw anyone stepping on it up into the air.";

$HelpMessage[OriginalGrenade] = "Explodes and shoots deadly metal fragments within in a medium area.";
$HelpMessage[Plastique] = "An explosive parcel that will detonate 15 seconds after deployment.";
$HelpMessage[FlareGrenade] = "Temporarily blinds your enemy.";
$HelpMessage[ConcussionGrenade] = "Explodes with a powerful burst of concussive energy.";
$HelpMessage[PoisonGrenade] = "A mortar that fits in your pocket.  A very handy weapon.";
$HelpMessage[TearGasGrenade] = "Will cause any players caught in its blast to be unable to fire a weapon for 15 seconds.";
$HelpMessage[Scrambler] = "Laces an area with burning napalm.  Catches people on fire.";

$HelpMessage[TargetBeacon] = "Will give your team-mates markers showing where they should fire to hit the beacon.";
$HelpMessage[MotionBeacon] = "A small sensor that detects enemy players in motion - cannot be jammed.";
$HelpMessage[CameraBeacon] = "Can be used to spy on enemy activity - will also trigger friendly turrets in an enemy crosses its line of sight.";
$HelpMessage[ShieldBeacon] = "Extra clips for your machinegun and pistol.";
$HelpMessage[TeleportBeacon] = "Grenades for the OICW machinegun.  Use the becon key to fire them.";
$HelpMessage[AlarmBeacon] = "Will alert your team when anyone approaches this beacon or destroys it.";

$HelpMessage[ScoutVehicle] = "A one-person vehicle with a gun emplacement on the front; choose the weapon you want - requires scout or sniper to fly.";
$HelpMessage[LAPCVehicle] = "Will carry up to two passengers as well as the pilot - cannot be flown by Heavy Gunners.";
$HelpMessage[HAPCVehicle] = "Will carry up to four passengers as well as the pilot - cannot be flown by Heavy Gunners.";

$HelpMessage[FighterGun] = "Rapidly fires high-velocity explosive rounds - good for shooting at other vehicles.";
$HelpMessage[VehicleRocket] = "Shoots dumb-fire missiles in a straight line - use this for big targets.";
$HelpMessage[VehicleBomb] = "Drops a highly explosive bomb - be sure and get clear of this one!";

$HelpMessage[AttackDronePack] = "A small plane commonly used in the middle east to hunt terrorists.  Controlled remotely.";
