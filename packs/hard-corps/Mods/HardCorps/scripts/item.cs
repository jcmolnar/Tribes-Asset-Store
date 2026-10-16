//----------------------------------------------------------------------------

$ItemFavoritesKey = "hardcorps";

//----------------------------------------------------------------------------

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
$AutoUse[DiscLauncher] = True;
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[Clustergun] = True;
$AutoUse[EMPulsegun] = True;

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
$SellAmmo[ClustergunAmmo] = 10;
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

// Limit on number of special Items you can buy
$TeamItemMax[GravityPadPack] = 4;
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[AATurretPack] = 4;
$TeamItemMax[ImpulseTurretPack] = 8;
$TeamItemMax[GeneratedForceFields] = 20;
$TeamItemMax[WeaponLockOutPack] = 8;
$TeamItemMax[HeavyTurretPack] = 4;
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[PointDefencePack] = 12;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 12;
$TeamItemMax[ProximityAlarmPack] = 6;
$TeamItemMax[ScoutVehicle] = 5;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 40;

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
$WeaponAmmo[Mortar] = MortarAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[Clustergun] = ClustergunAmmo;
$WeaponAmmo[EMPulsegun] = "";

// New objective/offence/defence bonuses and penalties

function DoDamageScoring(%this,%client)
{
	%item = GameBase::getDataName(%this);
	%lastdamager = %this.lastDamageObject;
	%deploything = "";
	%pointval = 0;
	%player = Client::getOwnedObject(%client);
	%showit = "true";
	%ds = GameBase::getDamageState(%this);

	if(%item == PulseSensor)
		{
			%deploything = " Large Pulse Sensor";
			%pointval = 1;
		}
	if(%item == MediumPulseSensor)
		{
			%deploything = " Medium Pulse Sensor";
			%pointval = 1;
		}
	if(%item == Scout)
		{
			%deploything = " Fighter";
			%pointval = 1;
		}
	if(%item == LAPC)
		{
			%deploything = " Light Carrier";
			%pointval = 1;
		}
	if(%item == HAPC)
		{
			%deploything = " Heavy Carrier";
			%pointval = 1;
		}
	if(%item == MortarTurret)
		{
			%deploything = " Mortar Turret";
			%pointval = 1;
		}
	if(%item == IndoorTurret)
		{
			%deploything = "n Indoor Turret";
			%pointval = 1;
		}
	if(%item == PlasmaTurret)
		{
			%deploything = " Plasma Turret";
			%pointval = 1;
		}
	if(%item == RocketTurret)
		{
			%deploything = " Rocket Turret";
			%pointval = 1;
		}
	if(%item == ELFTurret)
		{
			%deploything = "n ELF Turret";
			%pointval = 1;
		}
	if(%item.className == Generator)
		{
			if (%item != SolarPanel) %deploything = " Generator"; else %deploything = " Solar Panel";
			%pointval = 1;
		}
	if(%item == CommandStation)
		{
			%deploything = " Command Station";
			%pointval = 1;
		}
	if(%item == InventoryStation)
		{
			%deploything = "n Inventory Station";
			%pointval = 1;
		}
	if(%item == AmmoStation)
		{
			%deploything = "n Ammo Station";
			%pointval = 1;
		}
	if(%item == VehicleStation)
		{
			%deploything = " Vehicle Station";
			%pointval = 1;
		}
	if(%item == VehiclePad)
		{
			%deploything = " Vehicle Pad";
			%pointval = 1;
		}
	if(%item == DeployableInvStation)
		{
			%deploything = " Remote Inventory Station";
			%pointval = 1;
		}
	if(%item == DeployableAmmoStation)
		{
			%deploything = " Remote Ammo Station";
			%pointval = 1;
		}
	if(%item == GravityPad)
		{
			%deploything = " Gravity Pad Pack";
			%pointval = 1;
		}
	if(%item == DeployableTurret)
		{
			%deploything = " Remote Turret";
			%pointval = 1;
		}
	if(%item == ImpulseTurret)
		{
			%deploything = "n Impulse Turret";
			%pointval = 1;
		}
	if(%item == DeployableAATurret)
		{
			%deploything = " Remote Anti-Air Turret";
			%pointval = 1;
		}
	if(%item == DeployableHeavyTurret)
		{
			%deploything = " Remote Heavy Turret";
			%pointval = 1;
		}
	if(%item == PointDefence)
		{
			%deploything = " Point Defence Turret";
			%pointval = 1;
		}
	if(%item == DeployableWeaponLockOut)
		{
			%deploything = " Weapon Lock Out";
			%pointval = 1;
		}
	if(%item == InteriorForceField || %item == ExteriorForceField)
		{
			%deploything = " Force Field";
			%pointval = 0;
			%showit = "false";
		}
	if(%item == CameraTurret)
		{
			%deploything = " Camera Pack";
			%pointval = 1;
		}
	if(%item == DeployableSensorJammer)
		{
			%deploything = " Sensor Jammer";
			%pointval = 1;
		}
	if(%item == DeployablePulseSensor)
		{
			%deploything = " Pulse Sensor";
			%pointval = 1;
		}
	if(%item == DeployableMotionSensor)
		{
			%deploything = " Laser Motion Sensor";
			%pointval = 1;
		}
	if(%item == ProximityAlarm)
		{
			%deploything = " Proximity Alarm";
			%pointval = 1;
		}

	if (%client == %this.lastDamageObject) %pointval = 0;
	if (%ds == "Destroyed") %pointval = 0;

	if (GameBase::getTeam(%this) == GameBase::getTeam(%client))	
		{
			if (%client.showscorebonuses == "true" && %showit == "true" && %deploything != "" && %pointval != 0) Client::sendMessage(%client, 0, "You are penalized " @ %pointval @ " point(s) for damaging a" @ %deploything @ ".");
			if (%pointval != 0) %client.score -= %pointval;
		} else
		{
			if (%client.showscorebonuses == "true" && %showit == "true" && %deploything != "" && %pointval != 0) Client::sendMessage(%client, 0, "You receive " @ %pointval @ " point(s) for damaging a" @ %deploything @ ".");
			if (%pointval != 0) %client.score += %pointval;
		}

	Game::refreshClientScore(%client);
}

function DoDestroyScoring(%this,%client, %spec)
{
	%item = GameBase::getDataName(%this);
	%lastdamager = %this.lastDamageObject;
	%deploything = "";
	%pointval = 0;
	%offval = 0;
	%player = Client::getOwnedObject(%client);
	%showit = "true";
	%isp = GameBase::isPowered(%this);

	if(%item == PulseSensor)
		{
			%deploything = " Large Pulse Sensor";
			if (%isp) %pointval = 15; else %pointval = 5;
			%offval = 2;
		}
	if(%item == MediumPulseSensor)
		{
			%deploything = " Medium Pulse Sensor";
			if (%isp) %pointval = 15; else %pointval = 5;
			%offval = 2;
		}
	if(%item == Scout)
		{
			%deploything = " Fighter";
			%pointval = 5;
			%offval = 1;
		}
	if(%item == LAPC)
		{
			%deploything = " Light Carrier";
			%pointval = 10;
			%offval = 2;
		}
	if(%item == HAPC)
		{
			%deploything = " Heavy Carrier";
			%pointval = 15;
			%offval = 3;
		}
	if(%item == MortarTurret)
		{
			%deploything = " Mortar Turret";
			if (%isp) %pointval = 15; else %pointval = 5;
			%offval = 1;
		}
	if(%item == IndoorTurret)
		{
			%deploything = "n Indoor Turret";
			if (%isp) %pointval = 25; else %pointval = 10;
			%offval = 2;
		}
	if(%item == PlasmaTurret)
		{
			%deploything = " Plasma Turret";
			if (%isp) %pointval = 30; else %pointval = 10;
			%offval = 2;
		}
	if(%item == RocketTurret)
		{
			%deploything = " Rocket Turret";
			if (%isp) %pointval = 35; else %pointval = 10;
			%offval = 3;
		}
	if(%item == ELFTurret)
		{
			%deploything = "n ELF Turret";
			if (%isp) %pointval = 15; else %pointval = 5;
			%offval = 1;
		}
	if(%item.className == Generator)
		{
			if (%item != SolarPanel) %deploything = " Generator"; else %deploything = " Solar Panel";
			if (%item != SolarPanel) %pointval = 50; else %pointval = 10;
			%offval = 5;
		}
	if(%item == CommandStation)
		{
			%deploything = " Command Station";
			%pointval = 10;
			%offval = 1;
		}
	if(%item == InventoryStation)
		{
			%deploything = "n Inventory Station";
			%pointval = 25;
			%offval = 3;
		}
	if(%item == AmmoStation)
		{
			%deploything = "n Ammo Station";
			%pointval = 15;
			%offval = 2;
		}
	if(%item == VehicleStation)
		{
			%deploything = " Vehicle Station";
			%pointval = 15;
			%offval = 1;
		}
	if(%item == VehiclePad)
		{
			%deploything = " Vehicle Pad";
			%pointval = 15;
			%offval = 1;
		}
	if(%item == DeployableInvStation)
		{
			%deploything = " Remote Inventory Station";
			%pointval = 10;
			%offval = 2;
		}
	if(%item == DeployableAmmoStation)
		{
			%deploything = " Remote Ammo Station";
			%pointval = 5;
			%offval = 2;
		}
	if(%item == GravityPad)
		{
			%deploything = " Gravity Pad Pack";
			%pointval = 5;
			%offval = 2;
		}
	if(%item == DeployableTurret)
		{
			%deploything = " Remote Turret";
			%pointval = 10;
			%offval = 2;
		}
	if(%item == ImpulseTurret)
		{
			%deploything = "n Impulse Turret";
			%pointval = 10;
			%offval = 2;
		}
	if(%item == DeployableAATurret)
		{
			%deploything = " Remote Anti-Air Turret";
			%pointval = 15;
			%offval = 3;
		}
	if(%item == DeployableHeavyTurret)
		{
			%deploything = " Remote Heavy Turret";
			%pointval = 20;
			%offval = 3;
		}
	if(%item == PointDefence)
		{
			%deploything = " Point Defence Turret";
			%pointval = 5;
			%offval = 1;
		}
	if(%item == DeployableWeaponLockOut)
		{
			%deploything = " Weapon Lock Out";
			%pointval = 10;
			%offval = 1;
		}
	if(%item == InteriorForceField || %item == ExteriorForceField)
		{
			%deploything = " Force Field";
			if ($Game::MissionType == "Stairway") %pointval = 5;
				else {
						%pointval = 1;
						%offval = 1;
						%showit = "false";
					}
		}
	if(%item == CameraTurret)
		{
			%deploything = " Camera Pack";
			%pointval = 5;
			%offval = 1;
		}
	if(%item == DeployableSensorJammer)
		{
			%deploything = " Sensor Jammer";
			%pointval = 5;
			%offval = 1;
		}
	if(%item == DeployablePulseSensor)
		{
			%deploything = " Pulse Sensor";
			%pointval = 5;
			%offval = 1;
		}
	if(%item == DeployableMotionSensor)
		{
			%deploything = " Laser Motion Sensor";
			%pointval = 5;
			%offval = 1;
		}
	if(%item == ProximityAlarm)
		{
			%deploything = " Proximity Alarm";
			%pointval = 10;
			%offval = 1;
		}

	if (%spec == "Destroy")
		{
			if (GameBase::getTeam(%this) == GameBase::getTeam(%client))	
				{
					if (%client.showscorebonuses == "true" && %showit == "true" && %deploything != "" && %pointval != 0) Client::sendMessage(%client, 0, "You are penalized " @ %pointval @ " point(s) for destroying a" @ %deploything @ ".");
					if (%pointval != 0) %client.score -= %pointval;
					%client.defencebonus -= %offval;
				} else
				{
					if (%client.showscorebonuses == "true" && %showit == "true" && %deploything != "" && %pointval != 0) Client::sendMessage(%client, 0, "You receive " @ %pointval @ " point(s) for destroying a" @ %deploything @ ".");
					if (%pointval != 0) %client.score += %pointval;
					%client.offencebonus += %offval;
				}
		} else
		{
			if (GameBase::getTeam(%this) != GameBase::getTeam(%client))	
				{
					if (%client.showscorebonuses == "true" && %showit == "true" && %deploything != "" && %pointval != 0) Client::sendMessage(%client, 0, "You are penalized " @ %pointval @ " point(s) for repairing a" @ %deploything @ " to operation.");
					if (%pointval != 0) %client.score -= %pointval;
					%client.defencebonus -= %offval;
				} else
				{
					if (%client.showscorebonuses == "true" && %showit == "true" && %deploything != "" && %pointval != 0) Client::sendMessage(%client, 0, "You receive " @ %pointval @ " point(s) for repairing a" @ %deploything @ " to operation.");
					if (%pointval != 0) %client.score += %pointval;
					%client.offencebonus += %offval;
				}
		}
	if (%client.defencebonus < 0) %client.defencebonus = 0;
	Game::refreshClientScore(%client);
}

// New Turret Munkies Bonuses
function DoDeployBonuses(%player,%item)
{
	%deploything = "";
	%pointval = 0;
	%client = Player::getClient(%player);
	%showit = "true";

	if(%item == DeployableInvPack)
		{
			%deploything = " Remote Inventory Station";
			%client.defencebonus += 2;
			%pointval = 10;
		}
	if(%item == DeployableAmmoPack)
		{
			%deploything = " Remote Ammo Station";
			%client.defencebonus += 2;
			%pointval = 5;
		}
	if(%item == GravityPadPack)
		{
			%deploything = " Gravity Pad Pack";
			%client.defencebonus += 2;
			%pointval = 5;
		}
	if(%item == TurretPack)
		{
			%deploything = " Remote Turret";
			%client.defencebonus += 2;
			%pointval = 10;
		}
	if(%item == ImpulseTurretPack)
		{
			%deploything = "n Impulse Turret";
			%client.defencebonus += 1;
			%pointval = 10;
		}
	if(%item == AATurretPack)
		{
			%deploything = " Remote Anti-Air Turret";
			%client.defencebonus += 3;
			%pointval = 15;
		}
	if(%item == HeavyTurretPack)
		{
			%deploything = " Remote Heavy Turret";
			%client.defencebonus += 3;
			%pointval = 20;
		}
	if(%item == PointDefencePack)
		{
			%deploything = " Point Defence Turret";
			%client.defencebonus += 1;
			%pointval = 5;
		}
	if(%item == WeaponLockOutPack)
		{
			%deploything = " Weapon Lock Out";
			%client.defencebonus += 1;
			%pointval = 10;
		}
	if(%item == ForceFieldPack)
		{
			%deploything = " Force Field";
			%client.defencebonus += 1;
			%pointval = 0;
			%showit = "false";
		}
	if(%item == StairwayForceFieldPack)
		{
			%deploything = " Force Field";
			%pointval = 1;
		}
	if(%item == CameraPack)
		{
			%deploything = " Camera Pack";
			%client.defencebonus += 1;
			%pointval = 5;
		}
	if(%item == DeployableSensorJammerPack)
		{
			%deploything = " Sensor Jammer";
			%client.defencebonus += 1;
			%pointval = 5;
		}
	if(%item == PulseSensorPack)
		{
			%deploything = " Pulse Sensor";
			%client.defencebonus += 1;
			%pointval = 5;
		}
	if(%item == MotionSensorPack)
		{
			%deploything = " Laser Motion Sensor";
			%client.defencebonus += 1;
			%pointval = 5;
		}
	if(%item == ProximityAlarmPack)
		{
			%deploything = " Proximity Alarm";
			%client.defencebonus += 1;
			%pointval = 10;
		}
	
	if (%client.showscorebonuses == "true" && %showit == "true" && %deploything != "") Client::sendMessage(%client, 0, "You receive " @ %pointval @ " point(s) for deploying a" @ %deploything @ ".");
	if (%pointval != 0) %client.score += %pointval;
	Game::refreshClientScore(%client);
}


//----------------------------------------------------------------------------
// Server side methods
// The client side inventory dialogs call buyItem, sellItem,
// useItem and dropItem through remoteEvals.

function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	// IF - Cost positive selling    IF - Cost Negative buying 
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
			Client::sendMessage(%client,0,"Too many weapons for " @ $ArmorName[%armor].description @ " to carry");
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

function ItemDescriptions(%client,%item)
{
	if (%client.spawnimmunity <= 0 && %item.className != "Ammo" && %item.className != "HandAmmo") bottomprint(%client, "<jc><f2>" @ %item.description @ "\n <jc>" @ $HC::EquipmentDescriptions[%item] @ "", 3);
}

function buyItem(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (%client.showdescriptions == "true") ItemDescriptions(%client,%item);

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
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
				return 1;
			}
			else if(%pack != -1) {
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);									 
			}				 
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
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
		else if(%item.className == VehicleWeapon) 
			{
				%obj = $VList[%player.Station];

				if (%obj.leftpad == "false" && %obj != -1)
					{
						%vtype = Gamebase::getDataName(%obj);
						if (%vtype == "Scout")
							{
								%bought = "false";
								if (%obj.weaponry != "") 
									{
									 Client::SendMessage(%client,0,"Reconfiguring Vehicle Weaponry...");
									}
								if (%item == RotaryChaingun)
									{
										%obj.weaponry = RotaryChaingun;
										%obj.AmmoMinimum = 1;
										%obj.firesound = SoundVehicleRotaryCannonFire;
										%obj.AmmoCost = 0.75;
										%obj.firedelay = 0.18;
										%obj.attacktype = RotaryCannonAttack;
										%obj.multi = 1;
										%obj.firecount = 0;
										%bought = "true";
									}
								else if (%item == VehicleRocket)
									{
										%obj.weaponry = VehicleRocket;
										%obj.AmmoMinimum = 2.5;
										%obj.firesound = SoundFireFlierRocket;
										%obj.AmmoCost = 2.5;
										%obj.firedelay = 0.4;
										%obj.attacktype = FlierRocket;
										%obj.multi = 1;
										%obj.firecount = 0;
										%bought = "true";
									}
								else if (%item == NapalmLauncher)
									{
										%obj.weaponry = NapalmLauncher;
										%obj.AmmoMinimum = 2;
										%obj.firesound = SoundNapalmAttack;
										%obj.AmmoCost = 2;
										%obj.firedelay = 0.5;
										%obj.attacktype = NapalmAttack;
										%obj.multi = 1;
										%obj.firecount = 0;
										%bought = "true";
									}
								else if (%item == VehicleClusterCannon)
									{
										%obj.weaponry = VehicleClusterCannon;
										%obj.AmmoMinimum = 1;
										%obj.firesound = turretExplosion;
										%obj.AmmoCost = 1;
										%obj.firedelay = 0.4;
										%obj.attacktype = ClustergunShell;
										%obj.multi = 6;
										%obj.firecount = 0;
										%bought = "true";
									}
								else if (%item == VehicleEMPLauncher)
									{
										%obj.weaponry = VehicleEMPLauncher;
										%obj.AmmoMinimum = 0;
										%obj.firesound = SoundSpinUpDisc;
										%obj.AmmoCost = 0;
										%obj.firedelay = 4.0;
										%obj.attacktype = EMPulse;
										%obj.multi = 1;
										%obj.firecount = 0;
										%bought = "true";
									}
								else if (%item == VehicleBomb)
									{
										%obj.weaponry = VehicleBomb;
										%obj.AmmoMinimum = 25;
										%obj.firesound = SoundFireMortar;
										%obj.AmmoCost = 25;
										%obj.firedelay = 0.5;
										%obj.attacktype = VehicleBombAttack;
										%obj.multi = 1;
										%obj.firecount = 0;
										%bought = "true";
									}

								if (%bought == "true")
									{
									 Client::SendMessage(%client,0,"Vehicle now mounted with " @ %item.description @ ".");
									}
							} else Client::SendMessage(%client,0,"Unable to mount vehicle with " @ %item.description @ ".");

					}

				return 1;
			}
		else if(%item.className == VehicleModule) 
			{
				%obj = $VList[%player.Station];

				if (%obj.leftpad == "false" && %obj != -1)
					{
						%bought = "false";
						if (%obj.module != "") Client::SendMessage(%client,0,"Reconfiguring Vehicle Module...");
						if (%item == ShieldModule)
							{
								%obj.module = ShieldModule;
								%bought = "true";
							}
						else if (%item == AmmoModule)
							{
								%obj.module = AmmoModule;
								%bought = "true";
							}
						else if (%item == RepairModule)
							{
								%obj.module = RepairModule;
								%bought = "true";
							}
						else if (%item == SpeedModule)
							{
								%obj.module = SpeedModule;
								%bought = "true";
							}
						else if (%item == StealthModule)
							{
								%obj.module = StealthModule;
								%bought = "true";
							}	
						if (%bought == "true") Client::SendMessage(%client,0,"Vehicle now mounted with " @ %item.description @ ".");
					}

				return 1;
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
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
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

//
$NextWeapon[EMPulsegun] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = LaserRifle;
$NextWeapon[LaserRifle] = EnergyRifle;
$NextWeapon[EnergyRifle] = Mortar;
$NextWeapon[Mortar] = Clustergun;
$NextWeapon[Clustergun] = EMPulsegun;

$PrevWeapon[Blaster] = EMPulsegun;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[LaserRifle] = GrenadeLauncher;
$PrevWeapon[EnergyRifle] = LaserRifle;
$PrevWeapon[Mortar] = EnergyRifle;
$PrevWeapon[Clustergun] = Mortar;
$PrevWeapon[EMPulsegun] = Clustergun;


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
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]) {		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack) {
			// Only one backpack per armor, and it's always mounted
			if (Player::getMountedItem(%player,$BackpackSlot) == -1) {
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item.description @ ".");
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

function Flag::CheckForSuddenDeath(%player,%teamId)
{
	if (%player.suddendeathactive != "true" && $FlagName[%teamId].carrier != -1)
		{
			%ClientId = Player::getClient(%player);
			%player.suddendeathactive = "true";
			if ($SuddenDeathCounter[%teamId] > 0)
				{
					bottomprint(Player::getClient(%player), "<jc><f0>You have " @ $SuddenDeathCounter[%teamId] @" seconds till SUDDEN DEATH.", 2);
				}
		} else
		{
			$SuddenDeathCounter[%teamId]--;
			if ($SuddenDeathCounter[%teamId] <= 10 && $SuddenDeathCounter[%teamId] > 0)
				{
					bottomprint(Player::getClient(%player), "<jc><f0>" @ $SuddenDeathCounter[%teamId] @" seconds.", 1);
				}
			if ($SuddenDeathCounter[%teamId] <= 0)
				{
					if ($FlagName[%teamId].carrier != -1)
						{
							%ClientId = Player::getClient(%player);
							%ClientName = Client::getName(%ClientId);
							%playerTeam = GameBase::getTeam(%player);

							MessageAllExcept(%ClientId, 0, "" @ %ClientName @ " of the " @ getTeamName(%playerTeam) @ " team was killed because the team mounted insufficient flag offence.");
							$SuddenDeathCounter[%teamId] = $SuddenDeathTimeLimit;
							$SuddenDeathNotification = "false";

							// WERG ACTUAL SUDDEN DEATH
							%ClientId.DeathByFlag++;
							%ClientId.defencebonus++;
				                	Player::blowUp(%ClientId);
							Player::kill(%ClientId);
						      Game::refreshClientScore(%ClientId);

						} else
						{
							if ($SuddenDeathNotification[%teamId] == "false")
								{
									%flagTeam = GameBase::getTeam($FlagName[%teamId]);
									messageAll(0, "The " @ getTeamName(%flagTeam) @ " flag is now SUDDEN DEATH to touch.~wC_BuySell.wav");
									$SuddenDeathNotification[%teamId] = "true";
								}
						}
				}
		}
}

function Flag::CheckForStandoffs(%player)
{
	if($Game::MissionType == "CTF" && $Standoffs == "false" && getNumTeams() <= 2)
		{
			if ($FlagName[0].atHome != "true" && $FlagName[1].atHome != "true")
				{
					if ($StandoffsCountdownActive != "true")
						{
							$StandoffsCounter = $StandoffsTimeLimit;
							$StandoffsCountdownActive = "true";
						} else
						{
							if ($SuddenDeathTimeLimit == 0 && $StandoffsCounter == 0)
								{
									// do nothing
								} else $StandoffsCounter--;
							if ($StandoffsCounter <= 0)
							{
								$SuddenDeathActive="true";
								if ($StandoffsCounter == 0) 
								{
									messageAll(0, "Standoff Detected.");
									messageAll(0, "SUDDEN DEATH MODE ENABLED.~wC_BuySell.wav");
									messageAll(0, "Your team has " @ $SuddenDeathTimeLimit @ " seconds to damage the enemy flag carrier or your flag carrier dies.");
									$SuddenDeathCounter[0] = $SuddenDeathTimeLimit;
									$SuddenDeathCounter[1] = $SuddenDeathTimeLimit;
									$SuddenDeathNotification[0] = "false";
									$SuddenDeathNotification[1] = "false";
								}
								Flag::CheckForSuddenDeath($FlagName[0].carrier,0);
								Flag::CheckForSuddenDeath($FlagName[1].carrier,1);
							}

						}

				} else 
				{
					if (%StandoffsCountdownActive == "true")
						{
							if ($SuddenDeathActive == "true") messageAll(0, "SUDDEN DEATH MODE DISABLED.~wC_BuySell.wav");
						}
					$SuddenDeathActive = "false";
					$SuddenDeathCounter = $SuddenDeathTimeLimit;
					$StandoffsCountdownActive = "false";
				      $StandoffsCounter = $StandoffsTimeLimit;
					$FlagName[0].carrier.suddendeathcounter = $SuddenDeathTimeLimit;
					$FlagName[1].carrier.suddendeathcounter = $SuddenDeathTimeLimit;
					$FlagName[0].carrier.suddendeathactive = "false";
					$FlagName[1].carrier.suddendeathactive = "false";
					$SuddenDeathNotification[0] = "false";
					$SuddenDeathNotification[1] = "false";
				}

			if ($StandoffsCountdownActive == "true")
				{
					schedule("Flag::CheckForStandoffs(" @ %player @ ");", 1);
				}
		}
}

function Flag::onMount(%player,%imageSlot)
{
	if ($StandoffsCountdownActive != "true") schedule("Flag::CheckForStandoffs(" @ %player @ ");", 0.5);
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

//---------------------------------------------------------------------------

function HCTK::TKOn(%clientId)
{
	Player::unmountItem(%clientId,$WeaponSlot);
	Player::mountItem(%clientId,TKPack,7);
	centerprint(%clientId, "<jc><f0>Weapons Systems disabled due to Team Killing.", 5);
}

function HCTK::TKOff(%clientId)
{
	%clientId.TeamKills = 0;
	%clientId.teamkiller = "false";
	Player::unmountItem(%clientId,7);
	centerprint(%clientId, "<jc><f0>Weapons Systems restored to operation.", 5);
}

function HCTK::Timer(%clientId)
{
	if (%clientId.TeamKills > 0)
		{
			%clientId.TeamKills--;
			%clientId.tkactive = "true";
			if (%clientId.TeamKills > 0) schedule("HCTK::Timer(" @ %clientId @ ");", $TKTimeOut,%clientId);
		} else HCTK::TKOff(%clientId);
}

function HCTK::CheckForTKer(%clientId)
{
	if (%clientId.TeamKills >= $TKwarnlimit) 
		{
			if (%clientId.teamkiller != "true") 
				{
					messageAll(0, "Killing the Team-Killer " @ Client::getName(%clientId) @ " is now worth " @ (%clientId.TeamKills * 10) @ " points.");
					%clientId.teamkiller = "true";
					%clientId.tklog++;
					if (%clientId.tklog >= $TKKicklimit)
						{
						      %ip = Client::getTransportAddress(%client);
						      Net::kick(%clientId, "You were kicked because of Team-Killing.");
						}
					HCTK::TKOn(%clientId);
					HCTK::Timer(%clientId);
				}
		}
}

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData LightArmor
{
   heading = "aArmour";
	description = "Light Armour";
	className = "Armor";
	price = 200;
};

ItemData MediumArmor
{
   heading = "aArmour";
	description = "Medium Armour";
	className = "Armor";
	price = 300;
};

ItemData HeavyArmor
{
   heading = "aArmour";
	description = "Heavy Armour";
	className = "Armor";
	price = 400;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Fighter";
	className = "Vehicle";
   heading = "aVehicle";
	price = 250;
};

ItemData LAPCVehicle
{
	description = "Light Carrier";
	className = "Vehicle";
   heading = "aVehicle";
	price = 750;
};

ItemData HAPCVehicle
{
	description = "Heavy Carrier";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1000;
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

function Weapon::onMount(%player,%imageSlot)
{
	if ($UseTKEffect == "true" && Player::getClient(%player).teamkiller == "true") HCTK::TKOn(Player::getClient(%player));
	//if ($HC::AllowableEquipment[Player::getMountedItem(%player,%imageSlot)] == 0) Player::unmountItem(%player,$WeaponSlot);
}

function Weapon::onUse(%player,%item)
{
	if(%player.Station==""){
		if ($UseTKEffect == "true" && Player::getClient(%player).teamkiller == "true") HCTK::TKOn(Player::getClient(%player));
		//if ($HC::AllowableEquipment[%item] == 0) Player::unmountItem(%player,$WeaponSlot);
		%ammo = %item.imageType.ammoType;
		%clientId = Player::getClient(%player);
	
		%armor = Player::getArmor(%player);
		if (%ammo != "") %ammopercentage = (Player::getItemCount(%player,%ammo) / $ItemMax[%armor, %ammo]) * 20;


		%ammoleft = "";
		//%ammoleft = "Power-Limited";
		%detail = "Unknown Weapon.";

		//if (%ammo != "") %ammoleft = "   <f0>Ammo: <f1>" @ Player::getItemCount(%player,%ammo) @ "/" @ $ItemMax[%armor, %ammo] @ "";
		
		if (%item == Blaster) %detail = "<f0>Range: ||||||||||||||||<f1>||||   <f0>Damage: ||||||<f1>||||||||||||||   <f0>Rate Of Fire: ||||||||||||||||<f1>||||   <f0>Accuracy: ||||||||||||||||<f1>||||   <f0>Weight: ||||||||<f1>||||||||||||" @ %ammoleft @ "";

		if (%item == PlasmaGun) %detail = "<f0>Range: ||||||||||<f1>||||||||||   <f0>Damage: ||||||||||<f1>||||||||||   <f0>Rate Of Fire: ||||||||||<f1>||||||||||   <f0>Accuracy: |||||||||||||<f1>|||||||   <f0>Weight: ||||||||||<f1>||||||||||" @ %ammoleft @ "";

		if (%item == Chaingun) %detail = "<f0>Range: |||||||<f1>|||||||||||||   <f0>Damage: ||||||<f1>||||||||||||||   <f0>Rate Of Fire: |||||||||||||||<f1>|||||   <f0>Accuracy: |||<f1>|||||||||||||||||   <f0>Weight: ||||||||<f1>||||||||||||" @ %ammoleft @ "";

		if (%item == DiscLauncher) %detail = "<f0>Range: |||||||<f1>|||||||||||||   <f0>Damage: |||||||||||<f1>|||||||||   <f0>Rate Of Fire: |||||<f1>|||||||||||||||   <f0>Accuracy: ||||||||||||||||<f1>||||   <f0>Weight: ||||||||||||<f1>||||||||" @ %ammoleft @ "";

		if (%item == GrenadeLauncher) %detail = "<f0>Range: ||||||||||||<f1>||||||||   <f0>Damage: |||||||||||<f1>|||||||||   <f0>Rate Of Fire: ||||||||||<f1>||||||||||   <f0>Accuracy: ||||<f1>||||||||||||||||   <f0>Weight: ||||||||||||||<f1>||||||" @ %ammoleft @ "";

		if (%item == LaserRifle) %detail = "<f0>Range: ||||||||||||||||||||<f1>   <f0>Damage: ||||||||||||||||||<f1>||   <f0>Rate Of Fire: ||<f1>||||||||||||||||||   <f0>Accuracy: ||||||||||||||||||||<f1>   <f0>Weight: |||||||||||||<f1>|||||||" @ %ammoleft @ "";

		if (%item == EnergyRifle) %detail = "<f0>Range: ||||<f1>||||||||||||||||   <f0>Damage: |<f1>|||||||||||||||||||   <f0>Rate Of Fire: ||||||||||||||||||||<f1>   <f0>Accuracy: ||||||||<f1>||||||||||||   <f0>Weight: |||||||<f1>|||||||||||||" @ %ammoleft @ "";

		if (%item == Mortar) %detail = "<f0>Range: ||||||||||||||||||<f1>||   <f0>Damage: ||||||||||||||||||||<f1>   <f0>Rate Of Fire: |||<f1>|||||||||||||||||   <f0>Accuracy: ||||||||||<f1>||||||||||   <f0>Weight: ||||||||||||||||||||<f1>" @ %ammoleft @ "";

		if (%item == Clustergun) %detail = "<f0>Range: ||||||||||||||<f1>||||||   <f0>Damage: |||||||||||||<f1>|||||||   <f0>Rate Of Fire: ||||||||||<f1>||||||||||   <f0>Accuracy: ||<f1>||||||||||||||||||   <f0>Weight: ||||||||||||||<f1>||||||" @ %ammoleft @ "";

		if (%item == EMPulsegun) %detail = "<f0>Range: ||||||||||<f1>||||||||||   <f0>Damage: |<f1>|||||||||||||||||||   <f0>Rate Of Fire: ||||||||||<f1>||||||||||   <f0>Accuracy: ||||||||||||||<f1>||||||   <f0>Weight: ||||||||||||<f1>||||||||" @ %ammoleft @ "";

		if (%clientId.tkactive != "true" && %clientId.spawnimmunity <= 0) 
			{
				if (%clientId.weaponnames == "true" && %clientId.weaponstats == "true")
					{
						bottomprint(%clientId, "<jc><f2>" @ %item.description @ "\n <jc>" @ %detail @ "", 2.5);
					}
				if (%clientId.weaponnames == "true" && %clientId.weaponstats != "true")
					{
						bottomprint(%clientId, "<jc><f2>" @ %item.description @ "", 2.5);
					}
				if (%clientId.weaponnames != "true" && %clientId.weaponstats == "true")
					{
						bottomprint(%clientId, "<jc><f2>" @ %detail @ "", 2.5);
					}
			}
		if (%ammo == "") {
			// Energy weapons dont have ammo types
			if (%player.empeffect == 0) {
				Player::mountItem(%player,%item,$WeaponSlot);
			} else {
				Player::unmountitem(%player,%item);
				Client::sendMessage(Player::getClient(%player),0,
				strcat(%item.description," is not functioning due to EMP."));
			}
		}
		else {
			if (Player::getItemCount(%player,%ammo) > 0) 
			{
				Player::mountItem(%player,%item,$WeaponSlot);
				
			} else {
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
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "cEnergy Weapons";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 75;
	showWeaponBar = true;
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
   heading = "bProjectile Weapons";
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
   heading = "bProjectile Weapons";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
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
	projectileType = "GrenadeShell";
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
   heading = "dIndirect Fire Weapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------
ItemImageData EMPulsegunImage
{
	shapeFile = "grenadel"; 
	mountPoint = 0; 
	mountRotation = { 0,3.14, 0 }; 
	weaponType = 0; // Single Shot
	projectileType = EMPulse;
	accuFire = true;
	reloadTime = 0.3;
	fireTime = 1.0;
	minEnergy = 30;
	maxEnergy = 35;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundEMPulsegunFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundEMPulsegunReload;
};

ItemData EMPulsegun
{
	description = "EM Pulse Gun";
	className = "Weapon";
	shapeFile = "grenadel"; 
	hudIcon = "energypack";
   heading = "cEnergy Weapons";
	shadowDetailMask = 4;
	imageType = EMPulsegunImage;
	price = 150;
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
	projectileType = "MortarShell";
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
   heading = "dIndirect Fire Weapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 30;
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
   heading = "bProjectile Weapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
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
   heading = "cEnergy Weapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 0;
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
   heading = "mMiscellaneous";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 10;
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
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
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
   heading = "cEnergy Weapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
};

ItemData ClustergunAmmo
{
	description = "Cluster Rounds";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 3;
};

ItemImageData ClustergunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, -1.572, 0 };
	weaponType = 0; 
      minEnergy = 30;
	maxEnergy = 50;
//	projectileType = Clustergun;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.55;
	ammoType = ClustergunAmmo;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };	

	// sfxFire = turretExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Clustergun
{
	description = "Cluster Gun";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bProjectile Weapons";
	shadowDetailMask = 4;
	imageType = ClustergunImage;
	price = 250;
	showWeaponBar = true;
};

function ClustergunImage::onFire(%player, %slot)
 {
  %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Clustergun]);
	 if(%AmmoCount >= 1) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[Clustergun],1);
		 %trans = GameBase::getMuzzleTransform(%player);
		 playSound(turretExplosion,GameBase::getPosition(%player));
		 %vel = Item::getVelocity(%player);
		 Projectile::spawnProjectile("ClustergunShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClustergunShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClustergunShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClustergunShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClustergunShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClustergunShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClustergunShell",%trans,%player,%vel);
		 Projectile::spawnProjectile("ClustergunShell",%trans,%player,%vel);
	 }
	 else
		Client::sendMessage(Player::getClient(%player), 0,"Clustergun has no ammo");
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

//----------------------------------------------------------
ItemImageData PowerPackGunImage 
{ 
	shapeFile = "shotgun"; 
	mountPoint = 0; 
	mountRotation = { 0, 1.572, 0 };
	weaponType = 2; 
	projectileType = PowerPackEffect; 
	minEnergy = 1; 
	maxEnergy = 3; 
	lightType = 3; 
	lightRadius = 4.5; 
	lightTime = 1.8; 
	lightColor = { 0.1, 0.1, 1.0 }; 
	sfxActivate = SoundPickUpWeapon; 
	sfxFire = SoundGeneratorPower; 
      sfxReady = SoundGeneratorPower;
}; 

ItemData PowerPackGun
{ 
	description = "Power Pack"; 
	shapeFile = "shotgun"; 
	className = "Weapon"; 
	shadowDetailMask = 4; 
	imageType = PowerPackGunImage; 
	showInventory = false; 
	price = 300; 
}; 

function PowerPackGun::onMount(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,true); 
} 

function PowerPackGun::onUnmount(%player,%imageSlot) 
{ 
	Player::trigger(%player,$BackpackSlot,false); 
} 

ItemImageData PowerPackImage 
{ 
	shapeFile = "mortarammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0.0, 0.4 }; 
	mountRotation = { 0, 3.14159, 1.57 }; 
	weaponType = 2;
	minEnergy = -1; 
	maxEnergy = -3; 
 	firstPerson = false; 
	mass = 0.25;
}; 

ItemData PowerPack 
{ 
	description = "Power Generator Pack"; 
	shapeFile = "mortarammo"; 
	className = "Backpack"; 
	heading = "eBackpacks"; 
	shadowDetailMask = 4; 
	imageType = PowerPackImage; 
	price = 600; 
	hudIcon = "energypack"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	mass = 0.25;
}; 

function PowerPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == PowerPackGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function PowerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,PowerPackGun,$WeaponSlot);
	}
}

function PowerPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == PowerPackGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the PowerPackGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
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
   heading = "fDeployable Stations";
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
						Gamebase::setMapName(%inv,"Remote Inventory Station - " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Inventory Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++;
						echo("MSG: ",%client," deployed an Inventory Station");
						if($UseAdjustedScoring == "true") DoDeployBonuses(%player,DeployableInvPack);
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
   heading = "fDeployable Stations";
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
						Gamebase::setMapName(%inv,"Remote Ammo Station - " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Ammo Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++;
						echo("MSG: ",%client," deployed an Ammo Station");
						if($UseAdjustedScoring == "true") DoDeployBonuses(%player,DeployableAmmoPack);
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

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "eBackpacks";
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
   heading = "eBackpacks";
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
   heading = "eBackpacks";
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
	maxEnergy = 12;  // Energy used/sec for sustained weapons
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
   heading = "eBackpacks";
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

	// De-IFF user -- possible problem?
	Player::setDetectParameters(%player, 50, 150);

	%player.SensorJammerActive = "true";
	%player.jamdetect = "true";
 	GameBase::startFadeout(%player);
	SensorJammerPackImage::CheckForDisable(%player);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	// IFF user -- possible problem?
	Player::setDetectParameters(%player, 0.027, 0);

	Player::trigger(%player,$BackpackSlot,false);
	%player.SensorJammerActive = "false";
	%player.jamdetect = "false";
 	GameBase::startFadein(%player);
}

function SensorJammerPackImage::CheckForDisable(%player)
{
	if (%player.SensorJammerActive == "true")
	{
		%player.jamdetect = "true";
		if (Item::getVelocity(%player) == 0)
			{
				Player::setDetectParameters(%player, 50, 150);
			} else
			{
				Player::setDetectParameters(%Targetplayer, 0.027, 0);
			}

		%jam = "false";
		%ourteam = GameBase::getTeam(%player);
		if (%ourteam == 0) 
			{
				%theirteam = 1;
			} else %theirteam = 0;
		if (%player.empeffect != 0)
			{ 
				Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer disrupted by EMP");
				playSound(SoundEMPulseEffect,GameBase::getPosition(%player));
				%jam = "true";
		} else if ($FlagName[%theirteam].carrier == %player) 
			{
				if ($UseSensorJammerWithFlag != "true")
					{
						Client::sendMessage(Player::getClient(%player),0,"Unable to use Sensor Jammer while carrying the flag.~wC_BuySell.wav");
						%jam = "true";
					} else
					{
						%energy = GameBase::getEnergy(%player) - 12;
						if (%energy < 0) %energy = 0;
			      		GameBase::setEnergy(%player, %energy);
					}
		} else schedule("SensorJammerPackImage::CheckForDisable(" @ %player @ ");", 0.5,%player);

		if (%jam == "true")
			{
				%rate = Player::getSensorSupression(%player) - 20;
				Player::setSensorSupression(%player,%rate);
				// IFF user -- possible problem?
				Player::setDetectParameters(%Targetplayer, 0.027, 0);
				Player::trigger(%player,$BackpackSlot,false);
				%player.SensorJammerActive = "false";
				%player.jamdetect = "false";
		 		GameBase::startFadein(%player);
			}
	} else %player.jamdetect = "false";
}

//----------------------------------------------------------------------------

ItemImageData MotionSensorPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MotionSensorPack
{
	description = "Laser Motion Sensor";
	shapeFile = "camera";
	className = "Backpack";
   heading = "gDeployable Sensors";
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 50;
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

//	if (Item::deployShape(%player,"Laser Motion Sensor",MotionSensor,%item)) {
function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%mSensor = newObject("Camera","Turret",DeployableMotionSensor,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Laser Motion Sensor - " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Laser Motion Sensor deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Laser Motion Sensor");
					if($UseAdjustedScoring == "true") DoDeployBonuses(%player,MotionSensorPack);
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

//------------------------------------------------

ItemImageData DecoyFlagPackImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1};

	minEnergy = -0;
 	maxEnergy = -0;
	mass = -1.0;
	firstPerson = false;
};

ItemData DecoyFlagPack
{
        description = "Decoy Flag Pack";
	shapeFile = "flag";
        imageType = DecoyFlagPackImage;
	className = "Backpack";
        heading = "eBackpacks";
        showInventory = true;
	shadowDetailMask = 4;
        price = 125;

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

function DecoyFlagPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

//------------------------------------------------

ItemImageData TKPackImage
{

	shapeFile = "breath";
	mountPoint = 7;
  	mountOffset = { 0, 0, 0 };
  	mountRotation = { 0, 0, 0 };
	mass = 0.0;

	lightType = 2; 
	lightRadius = 5; 
	lightTime = 0.5; 
	lightColor = { 1.0, 0.0, 0.0 }; 

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData TKPack
{
        description = "Team Killer Pack";
	shapeFile = "breath";
        imageType = TKPackImage;
	className = "TKerThingie";
        showInventory = false;
	shadowDetailMask = 4;

	lightType = 2;   // Pulsing
	lightRadius = 5;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	weaponType = 2;  // Sustained
	minEnergy = 6;
	maxEnergy = 12;   // Energy/sec for sustained weapons
	sfxFire = SoundUseAmmoStation;
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "eBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 15.0;
	elasticity = 0.2;
	price = 275;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AmmoPackImage::onMount(%player,%item)
{
	%player.AmmoPackActive = "false";
	%player.AmmoPackCounter = 0;
}

function AmmoPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Ammo Pack On");
	%player.AmmoPackActive = "true";
	AmmoPackImage::RegenerateAmmo(%player);
}

function AmmoPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Ammo Pack Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.AmmoPackActive = "false";
}

function AmmoPackImage::RegenerateAmmo(%player)
{
	%player.AmmoPackCounter++;

	if (checkResources(%player,BulletAmmo,1,1) > 0 && Player::getItemCount(%player,Chaingun) == 1) AmmoPackImage::resupply(%player,"ChainGun",BulletAmmo,1,3);
	else if (checkResources(%player,PlasmaAmmo,1,1) > 0 && Player::getItemCount(%player,PlasmaGun) == 1) AmmoPackImage::resupply(%player,"PlasmaGun",PlasmaAmmo,1,15);
	else if (checkResources(%player,DiscAmmo,1,1) > 0 && Player::getItemCount(%player,DiscLauncher) == 1) AmmoPackImage::resupply(%player,"DiscLauncher",DiscAmmo,1,18);
	else if (checkResources(%player,GrenadeAmmo,1,1) > 0 && Player::getItemCount(%player,GrenadeLauncher) == 1) AmmoPackImage::resupply(%player,"GrenadeLauncher",GrenadeAmmo,1,20);
	else if (checkResources(%player,ClustergunAmmo,1,1) > 0 && Player::getItemCount(%player,Clustergun) == 1) AmmoPackImage::resupply(%player,"Clustergun",ClustergunAmmo,1,17);
	else if (checkResources(%player,MortarAmmo,1,1) > 0 && Player::getItemCount(%player,Mortar) == 1) AmmoPackImage::resupply(%player,"Mortar",MortarAmmo,1,20);
	else if (checkResources(%player,Grenade,1,1) > 0 ) AmmoPackImage::resupply(%player,"",Grenade,1,15);
	else if (checkResources(%player,MineAmmo,1,1) > 0 ) AmmoPackImage::resupply(%player,"",MineAmmo,1,20);
	else if (checkResources(%player,Beacon,1,1) > 0 ) AmmoPackImage::resupply(%player,"",Beacon,1,10);
	else if (checkResources(%player,RepairKit,1,1) > 0 ) AmmoPackImage::resupply(%player,"",RepairKit,1,250);
	else 
		{
			%player.AmmoPackCounter = 0;
			Client::sendMessage(Player::getClient(%player),0,"Ammunition Fully Restored.");
			Player::trigger(%player,$BackpackSlot,false);
			%player.AmmoPackActive = "false";
		}
      if (%player.AmmoPackActive == "true") {
		  schedule("AmmoPackImage::RegenerateAmmo(" @ %player @ ");", 0.25,%player);
		}
}

function AmmoPackImage::resupply(%player,%weapon,%item,%delta,%genreq)
{
	if (%player.AmmoPackCounter >= %genreq) 
		{
			%delta = checkResources(%player,%item,%delta,1);		
			if(%delta > 0) {						
				Player::incItemCount(%player,%item,%delta);
				%player.AmmoPackCounter = 0;
	 			return %delta;
			}
			return 0;
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
   heading = "gDeployable Sensors";
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
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
   heading = "hDeployable Jammers";
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 200;
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
	description = "Remote Camera";
	shapeFile = "camera";
	className = "Backpack";
   heading = "gDeployable Sensors";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
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
					Gamebase::setMapName(%camera,"Remote Camera - " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Remote Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Remote Camera");
					if($UseAdjustedScoring == "true") DoDeployBonuses(%player,CameraPack);
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

ItemImageData PointDefencePackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData PointDefencePack
{
	description = "Point Defence Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "iLight Turrets";
	imageType = PointDefencePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PointDefencePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PointDefencePack::onDeploy(%player,%item,%pos)
{
	if (PointDefencePack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PointDefencePack"]++;
	}
}

//	if (Item::deployShape(%player,"Point Defence",PointDefence,%item)) {
function PointDefencePack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%krot = %rot;
					%xrot = getWord(%krot,1); //+ 1.516;
					%rot = "" @ getWord(%krot,0) @ " " @ %xrot @ " " @ getWord(%krot,2) @ "";

					%mpoint = newObject("Camera","Turret",PointDefence,true);
			   	      addToSet("MissionCleanup", %mpoint);
					GameBase::setTeam(%mpoint,GameBase::getTeam(%player));
					GameBase::setRotation(%mpoint,%rot);
					GameBase::setPosition(%mpoint,$los::position);
					Gamebase::setMapName(%mpoint,"Point Defence Turret - " @ Client::getName(%client));
					%xpoint = newObject("","StaticShape",PointDefenceOther,true);
				      addToSet("MissionCleanup", %xpoint);
					GameBase::setTeam(%xpoint,GameBase::getTeam(%player));
					GameBase::setRotation(%xpoint,%krot);
					GameBase::setPosition(%xpoint,$los::position);
					%mpoint.linkedobject = %xpoint;

					// LINK TURRET TO USER
			        	Client::setOwnedObject(%client, %mpoint);
			        	Client::setOwnedObject(%client, %player);

					Client::sendMessage(%client,0,"Point Defence Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Point Defence Turret");
					if($UseAdjustedScoring == "true") DoDeployBonuses(%player,PointDefencePack);
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

ItemImageData ImpulseTurretPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData ImpulseTurretPack
{
	description = "Impulse Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "jMedium Turrets";
	imageType = ImpulseTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ImpulseTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ImpulseTurretPack::onDeploy(%player,%item,%pos)
{
	if (ImpulseTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "ImpulseTurretPack"]++;
	}
}

//	if (Item::deployShape(%player,"Point Defence",Impulse,%item)) {
function ImpulseTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
					%xrot = getWord(%rot,2) + 1.516;
					%krot = "" @ getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ %xrot @ "";
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
						%xrot = getWord(%rot,2);
						%krot = "" @ getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ %xrot @ "";
					}
					else {
						%rot = Vector::getRotation($los::normal);
						%xrot = getWord(%rot,2);
						%krot = "" @ getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ %xrot @ "";
					}
				}
				if(checkDeployArea(%client,$los::position)) {

					%xpoint = newObject("","StaticShape",ImpulseOther,true);
				      addToSet("MissionCleanup", %xpoint);
					GameBase::setTeam(%xpoint,GameBase::getTeam(%player));
					GameBase::setRotation(%xpoint,%krot);
					GameBase::setPosition(%xpoint,$los::position);

					%mimpulse = newObject("Camera","Turret",ImpulseTurret,true);
	   	      addToSet("MissionCleanup", %mimpulse);
					GameBase::setTeam(%mimpulse,GameBase::getTeam(%player));
					GameBase::setRotation(%mimpulse,%rot);
					GameBase::setPosition(%mimpulse,$los::position);
					%mimpulse.linkedobject = %xpoint;
					Gamebase::setMapName(%mimpulse,"Impulse Turret - " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Impulse Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed an Impulse Turret");
					if($UseAdjustedScoring == "true") DoDeployBonuses(%player,ImpulseTurretPack);
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

ItemImageData WeaponLockOutPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData WeaponLockOutPack
{
	description = "Weapon Lock Out";
	shapeFile = "camera";
	className = "Backpack";
      heading = "iLight Turrets";
	imageType = WeaponLockOutPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
      shadowDetailMask = 4;
};

function WeaponLockOutPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function WeaponLockOutPack::onDeploy(%player,%item,%pos)
{
	if (WeaponLockOutPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "WeaponLockOutPack"]++;
	}
}

//	if (Item::deployShape(%player,"Weapon Lock Out",DeployableWeaponLockOut,%item)) {
function WeaponLockOutPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
					%krot = %rot;
					%xrot = getWord(%krot,1); // + 1.5167;
					%rot = "" @ getWord(%krot,0) @ " " @ %xrot @ " " @ getWord(%krot,2) @ "";

					%xpoint = newObject("","StaticShape",WeaponLockOutOther,true);
				      addToSet("MissionCleanup", %xpoint);
					GameBase::setTeam(%xpoint,GameBase::getTeam(%player));
					GameBase::setRotation(%xpoint,%krot);
					GameBase::setPosition(%xpoint,$los::position);

					%mwpnlock = newObject("Camera","Turret",DeployableWeaponLockOut,true);
	   	      addToSet("MissionCleanup", %mwpnlock);
					%mwpnlock.linkedobject = %xpoint;
					GameBase::setTeam(%mwpnlock,GameBase::getTeam(%player));
					GameBase::setRotation(%mwpnlock,%rot);
					GameBase::setPosition(%mwpnlock,$los::position);
					Gamebase::setMapName(%mwpnlock,"Weapon Lock Out - " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Weapon Lock Out deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Weapon Lock Out");
					if($UseAdjustedScoring == "true") DoDeployBonuses(%player,WeaponLockOutPack);
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

ItemImageData ProximityAlarmPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData ProximityAlarmPack
{
	description = "Proximity Alarm";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = "gDeployable Sensors";
	imageType = ProximityAlarmPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 75;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ProximityAlarmPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function ProximityAlarmPack::onDeploy(%player,%item,%pos)
{
	if (ProximityAlarmPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "ProximityAlarmPack"]++;
	}
}

//	if (Item::deployShape(%player,"Proximity Alarm",ProximityAlarm,%item)) {
function ProximityAlarmPack::deployShape(%player,%item)
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
					%mprox = newObject("","Turret",ProximityAlarm,true);
	   	      addToSet("MissionCleanup", %mprox);
					GameBase::setTeam(%mprox,GameBase::getTeam(%player));
					GameBase::setRotation(%mprox,%rot);
					GameBase::setPosition(%mprox,$los::position);
					Gamebase::setMapName(%mprox,"Proximity Alarm - " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Proximity Alarm deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Proximity Alarm");
					if($UseAdjustedScoring == "true") DoDeployBonuses(%player,ProximityAlarmPack);
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
	description = "Remote Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "jMedium Turrets";
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
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
								Gamebase::setMapName(%turret,"Remote Turret - " @ Client::getName(%client));
								// LINK TURRET TO USER
						        	Client::setOwnedObject(%client, %turret);
						        	Client::setOwnedObject(%client, %player);

								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								if($UseAdjustedScoring == "true") DoDeployBonuses(%player,TurretPack);

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
																			
ItemImageData HeavyTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData HeavyTurretPack
{
	description = "Heavy Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "kHeavy Turrets";
	imageType = HeavyTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HeavyTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function HeavyTurretPack::onDeploy(%player,%item,%pos)
{
	if (HeavyTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function HeavyTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableHeavyTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableHeavyTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableHeavyTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Remote Heavy Turret - " @ Client::getName(%client));

								// LINK TURRET TO USER
						        	Client::setOwnedObject(%client, %turret);
						        	Client::setOwnedObject(%client, %player);

								Client::sendMessage(%client,0,"Remote Heavy Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "HeavyTurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								if($UseAdjustedScoring == "true") DoDeployBonuses(%player,HeavyTurretPack);

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

//-----------------------------------------------------------
						
ItemImageData ForceFieldPackImage
{
	shapeFile = "mortarammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0.0, 0.4 }; 
	mountRotation = { 0, 3.14159, 1.57 }; 
	mass = 0.0;
	firstPerson = false;
};

ItemData ForceFieldPack
{
	description = "Force Field Generator";
	shapeFile = "mortarammo"; 
	className = "Backpack";
    heading = "eBackpacks";
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 0.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		{
			Player::mountItem(%player,%item,$BackpackSlot);
		} else 
		{
			%client = Player::getClient(%player);
			if ($TeamItemCount[GameBase::getTeam(%player) @ GeneratedForceFields] < $TeamItemMax[GeneratedForceFields])
				{
					%energy = GameBase::getEnergy(%player);
					if (%energy >= 80) 
					{
						$forcefieldgenerated[%client] = "false";
						playSound(SoundGenerateForceShield,GameBase::getPosition(%player));
						Player::deployItem(%player,%item);
						Player::setItemCount(%player, %item, 1);
						Player::mountItem(%player,%item,$BackpackSlot);
						if ($forcefieldgenerated[%client] == "true") 
							{
							 	%energy = %energy - 80;
								if (%energy < 0) %energy = 0;
							      GameBase::setEnergy(%player, %energy);
							}
					} else Client::sendMessage(%client,0,"Insufficient power to generate Force Field.");
				} else Client::sendMessage(%client,0,"No further Force Field generation possible.");
		}
}

function ForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (ForceFieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ GeneratedForceFields] < $TeamItemMax[GeneratedForceFields]) {
		if (GameBase::getLOSInfo(%player,5)) {
			%obj = getObjectType($los::object);
			%tobj = GameBase::getDataName($los::object);

			if (%obj == "InteriorShape" || %obj == "SimTerrain" || %tobj == "InteriorForceField" || %tobj == "ExteriorForceField")
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);

				%num = CountObjects(%set,"DeployableForceField",%num);
				deleteObject(%set);


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
				%mfield = newObject("","StaticShape",InteriorForceField,true);
							
				addToSet("MissionCleanup", %mfield);
				GameBase::setTeam(%mfield,GameBase::getTeam(%player));
				GameBase::setPosition(%mfield,$los::position);
				GameBase::setRotation(%mfield,%rot);
				Gamebase::setMapName(%mfield,"Force Field");
				Client::sendMessage(%client,0,"Force Field Generated");
				GameBase::startFadeIn(%mfield);
				playSound(SoundPickupBackpack,$los::position);
				playSound(ForceFieldClose,$los::position);
				$TeamItemCount[GameBase::getTeam(%player) @ "GeneratedForceFields"]++;			
				$forcefieldgenerated[%client] = "true";
				%mfield.isactive = false;
				if($UseAdjustedScoring == "true") DoDeployBonuses(%player,ForceFieldPack);
				return true;
			} else
			{
				Client::sendMessage(%client,0,"Cannot generate on this surface.");
			}
		}
		else 
			Client::sendMessage(%client,0,"Generation point out of range.");
	}
	else																						  
	 	Client::sendMessage(%client,0,"No further Force Field generation possible.");

	return false;
}

//-----------------------------------------------------------
						
ItemImageData StairwayForceFieldPackImage
{
	shapeFile = "mortarammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0.0, 0.4 }; 
	mountRotation = { 0, 3.14159, 1.57 }; 
	mass = 0.0;
	firstPerson = false;
};

ItemData StairwayForceFieldPack
{
	description = "Force Field Generator";
	shapeFile = "mortarammo"; 
	className = "Backpack";
    heading = "eBackpacks";
	imageType = StairwayForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 0.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StairwayForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		{
			Player::mountItem(%player,%item,$BackpackSlot);
		} else 
		{
			%client = Player::getClient(%player);
			if ($TeamItemCount[GameBase::getTeam(%player) @ GeneratedForceFields] < $TeamItemMax[GeneratedForceFields])
				{
					%energy = GameBase::getEnergy(%player);
					if (%energy >= 25) 
					{
						$forcefieldgenerated[%client] = "false";
						playSound(SoundGenerateForceShield,GameBase::getPosition(%player));
						Player::deployItem(%player,%item);
						Player::setItemCount(%player, %item, 1);
						Player::mountItem(%player,%item,$BackpackSlot);
						if ($forcefieldgenerated[%client] == "true") 
							{
							 	%energy = %energy - 25;
								if (%energy < 0) %energy = 0;
							      GameBase::setEnergy(%player, %energy);
							}
					} else Client::sendMessage(%client,0,"Insufficient power to generate Force Field.");
				} else Client::sendMessage(%client,0,"No further Force Field generation possible.");
		}
}

function StairwayForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (StairwayForceFieldPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function StairwayForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ GeneratedForceFields] < $TeamItemMax[GeneratedForceFields]) {
		if (GameBase::getLOSInfo(%player,5)) {
			%obj = getObjectType($los::object);
			%tobj = GameBase::getDataName($los::object);

			if (%obj == "InteriorShape" || %obj == "SimTerrain" || %tobj == "InteriorForceField" || %tobj == "ExteriorForceField")
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);

				%num = CountObjects(%set,"DeployableForceField",%num);
				deleteObject(%set);


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
				%mfield = newObject("","StaticShape",InteriorForceField,true);
							
				addToSet("MissionCleanup", %mfield);
				GameBase::setTeam(%mfield,GameBase::getTeam(%player));
				GameBase::setPosition(%mfield,$los::position);
				GameBase::setRotation(%mfield,%rot);
				Gamebase::setMapName(%mfield,"Force Field");
				Client::sendMessage(%client,0,"Force Field Generated");
				GameBase::startFadeIn(%mfield);
				playSound(SoundPickupBackpack,$los::position);
				playSound(ForceFieldClose,$los::position);
				$forcefieldgenerated[%client] = "true";
				%mfield.isactive = false;
				if($UseAdjustedScoring == "true") DoDeployBonuses(%player,StairwayForceFieldPack);
				return true;
			} else
			{
				Client::sendMessage(%client,0,"Cannot generate on this surface.");
			}
		}
		else 
			Client::sendMessage(%client,0,"Generation point out of range.");
	}
	else																						  
	 	Client::sendMessage(%client,0,"No further Force Field generation possible.");

	return false;
}


//------------------------------------------------------
ItemImageData GravityPadPackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	mass = 0.0;
};

ItemData GravityPadPack
{
        description = "Gravity Pad";
        shapeFile = "sensor_small";
        className = "Backpack";
        heading = "fDeployable Stations";
        imageType = GravityPadPackImage;
        shadowDetailMask = 4;
        mass = 0.0;
        elasticity = 0.2;
        price = 300;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function GravityPadPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function GravityPadPack::onDeploy(%player,%item,%pos)
{
        if (GravityPadPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function GravityPadPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "GravityPadPack"] < $TeamItemMax[GravityPadPack]) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
                            %set = newObject("set",SimSet);

				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);

                        %num = CountObjects(%set, GravityPadPack, %num);
                       deleteObject(%set);


				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
		                        %rot = GameBase::getRotation(%player);
            		            %objGravityPad = newObject("GravityPad", "StaticShape", GravityPad, true);
		                        addToSet("MissionCleanup", %objGravityPad);
		                        GameBase::setTeam(%objGravityPad, GameBase::getTeam(%player));
            		            GameBase::setPosition(%objGravityPad, $los::position);
		                        GameBase::setRotation(%objGravityPad, %rot);
						Gamebase::setMapName(%objGravityPad,"Gravity Pad - " @ Client::getName(%client));
		                        Client::sendMessage(%client,0,"Gravity Pad Deployed");
            		            echo("MSG: ",%client," deployed a Gravity Pad");
		                        GameBase::startFadeIn(%objGravityPad);
            		            playSound(SoundPickupBackpack, $los::position);
		                        $TeamItemCount[GameBase::getTeam(%player) @ "GravityPadPack"]++;
						if($UseAdjustedScoring == "true") DoDeployBonuses(%player,GravityPadPack);
            		            return true;
					} else 
						Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                }
                else
                        Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

//----------------------------------------------------------------------------
																			
ItemImageData AATurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData AATurretPack
{
	description = "Anti-Air Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "kHeavy Turrets";
	imageType = AATurretPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AATurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AATurretPack::onDeploy(%player,%item,%pos)
{
	if (AATurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function AATurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableAATurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableAATurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableAATurret,true);
	                     addToSet("MissionCleanup", %turret);

								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Remote Anti-Air Turret - " @ Client::getName(%client));
								// LINK TURRET TO USER
						        	Client::setOwnedObject(%client, %turret);
						        	Client::setOwnedObject(%client, %player);

								Client::sendMessage(%client,0,"Remote Anti-Air Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "AATurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Anti-Air Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								if($UseAdjustedScoring == "true") DoDeployBonuses(%player,AATurretPack);
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

//------------------------------------------------------
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
						Gamebase::setMapName(%sensor,"" @ %item.description @ " - " @ Client::getName(%client));
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%item.description);
						if($UseAdjustedScoring == "true") DoDeployBonuses(%player,%item);
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

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "mMiscellaneous";
   shadowDetailMask = 4;
   price = 50;
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
   heading = "mMiscellaneous";
   shadowDetailMask = 4;
   price = 20;
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
		}
	}
}


//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "mMiscellaneous";
   shadowDetailMask = 4;
   price = 10;
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

ItemData Beacon
{
	description = "Beacon";
	shapeFile = "sensor_small";
	heading = "mMiscellaneous";
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

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "mMiscellaneous";
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
		Player::setItemCount(%clientId,Clustergun,1);
		Player::setItemCount(%clientId,EMPulsegun,1);

		Player::setItemCount(%clientId,BulletAmmo,200);
		Player::setItemCount(%clientId,PlasmaAmmo,200);
		Player::setItemCount(%clientId,GrenadeAmmo,200);
		Player::setItemCount(%clientId,DiscAmmo,200);
		Player::setItemCount(%clientId,MortarAmmo,200);
		Player::setItemCount(%clientId,ClustergunAmmo,200);

      Player::setItemCount(%clientId,Grenade, 200);
      Player::setItemCount(%clientId,MineAmmo, 200);
		Player::setItemCount(%clientId,Beacon,  200);

		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);
		Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
		Player::setItemCount(%clientId,ClustergunAmmo,$ItemMax[%armor, ClustergunAmmo]);
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
	$TeamItemCount[0 @ HeavyTurretPack] = 0;
	$TeamItemCount[0 @ CameraPack] = 0;
	$TeamItemCount[0 @ PointDefencePack] = 0;
	$TeamItemCount[0 @ ImpulseTurretPack] = 0;
	$TeamItemCount[0 @ WeaponLockOutPack] = 0;
	$TeamItemCount[0 @ ProximityAlarmPack] = 0;
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
	$TeamItemCount[1 @ ImpulseTurretPack] = 0;
	$TeamItemCount[1 @ HeavyTurretPack] = 0;
	$TeamItemCount[1 @ CameraPack] = 0;
	$TeamItemCount[1 @ PointDefencePack] = 0;
	$TeamItemCount[1 @ WeaponLockOutPack] = 0;
	$TeamItemCount[1 @ ProximityAlarmPack] = 0;
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
	$TeamItemCount[2 @ ImpulseTurretPack] = 0;
	$TeamItemCount[2 @ HeavyTurretPack] = 0;
	$TeamItemCount[2 @ CameraPack] = 0;
	$TeamItemCount[2 @ PointDefencePack] = 0;
	$TeamItemCount[2 @ WeaponLockOutPack] = 0;
	$TeamItemCount[2 @ ProximityAlarmPack] = 0;
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
	$TeamItemCount[3 @ ImpulseTurretPack] = 0;
	$TeamItemCount[3 @ HeavyTurretPack] = 0;
	$TeamItemCount[3 @ CameraPack] = 0;
	$TeamItemCount[3 @ PointDefencePack] = 0;
	$TeamItemCount[3 @ WeaponLockOutPack] = 0;
	$TeamItemCount[3 @ ProximityAlarmPack] = 0;
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
	$TeamItemCount[4 @ ImpulseTurretPack] = 0;
	$TeamItemCount[4 @ HeavyTurretPack] = 0;
	$TeamItemCount[4 @ CameraPack] = 0;
	$TeamItemCount[4 @ PointDefencePack] = 0;
	$TeamItemCount[4 @ WeaponLockOutPack] = 0;
	$TeamItemCount[4 @ ProximityAlarmPack] = 0;
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
	$TeamItemCount[5 @ ImpulseTurretPack] = 0;
	$TeamItemCount[5 @ HeavyTurretPack] = 0;
	$TeamItemCount[5 @ CameraPack] = 0;
	$TeamItemCount[5 @ PointDefencePack] = 0;
	$TeamItemCount[5 @ WeaponLockOutPack] = 0;
	$TeamItemCount[5 @ ProximityAlarmPack] = 0;
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
	$TeamItemCount[6 @ ImpulseTurretPack] = 0;
	$TeamItemCount[6 @ HeavyTurretPack] = 0;
	$TeamItemCount[6 @ CameraPack] = 0;
	$TeamItemCount[6 @ PointDefencePack] = 0;
	$TeamItemCount[6 @ WeaponLockOutPack] = 0;
	$TeamItemCount[6 @ ProximityAlarmPack] = 0;
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
	$TeamItemCount[7 @ ImpulseTurretPack] = 0;
	$TeamItemCount[7 @ HeavyTurretPack] = 0;
	$TeamItemCount[7 @ CameraPack] = 0;
	$TeamItemCount[7 @ PointDefencePack] = 0;
	$TeamItemCount[7 @ WeaponLockOutPack] = 0;
	$TeamItemCount[7 @ ProximityAlarmPack] = 0;
	$TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
	$TeamItemCount[7 @ PulseSensorPack] = 0;
	$TeamItemCount[7 @ MotionSensorPack] = 0;
	$TeamItemCount[7 @ ScoutVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;

	$TeamItemCount[0 @ ForceFieldPack] = 0;
	$TeamItemCount[1 @ ForceFieldPack] = 0;
	$TeamItemCount[2 @ ForceFieldPack] = 0;
	$TeamItemCount[3 @ ForceFieldPack] = 0;
	$TeamItemCount[4 @ ForceFieldPack] = 0;
	$TeamItemCount[5 @ ForceFieldPack] = 0;
	$TeamItemCount[6 @ ForceFieldPack] = 0;
	$TeamItemCount[7 @ ForceFieldPack] = 0;

	$TeamItemCount[0 @ StairwayForceFieldPack] = 0;
	$TeamItemCount[1 @ StairwayForceFieldPack] = 0;
	$TeamItemCount[2 @ StairwayForceFieldPack] = 0;
	$TeamItemCount[3 @ StairwayForceFieldPack] = 0;
	$TeamItemCount[4 @ StairwayForceFieldPack] = 0;
	$TeamItemCount[5 @ StairwayForceFieldPack] = 0;
	$TeamItemCount[6 @ StairwayForceFieldPack] = 0;
	$TeamItemCount[7 @ StairwayForceFieldPack] = 0;

	$TeamItemCount[0 @ GravityPadPack] = 0;
	$TeamItemCount[1 @ GravityPadPack] = 0;
	$TeamItemCount[2 @ GravityPadPack] = 0;
	$TeamItemCount[3 @ GravityPadPack] = 0;
	$TeamItemCount[4 @ GravityPadPack] = 0;
	$TeamItemCount[5 @ GravityPadPack] = 0;
	$TeamItemCount[6 @ GravityPadPack] = 0;
	$TeamItemCount[7 @ GravityPadPack] = 0;

	$TeamItemCount[0 @ AATurretPack] = 0;
	$TeamItemCount[1 @ AATurretPack] = 0;
	$TeamItemCount[2 @ AATurretPack] = 0;
	$TeamItemCount[3 @ AATurretPack] = 0;
	$TeamItemCount[4 @ AATurretPack] = 0;
	$TeamItemCount[5 @ AATurretPack] = 0;
	$TeamItemCount[6 @ AATurretPack] = 0;
	$TeamItemCount[7 @ AATurretPack] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

ItemImageData MiscModuleImage
{
	shapeFile = "breath";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 0;
	fireTime = 0;

	accuFire = false;

	lightType = 0;
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 0, 0, 0 };

};

ItemImageData RotaryChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 5; 
	mountOffset = { 0, 10.0, 10 }; 
	mountRotation = { 0, 3.14159, 0 }; 

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

ItemData RotaryChaingun
{
	description = "Rotary Cannon";
	className = "VehicleWeapon";
	shapeFile = "chaingun";
 	hudIcon = "chain";
      heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = RotaryChaingunImage;
	price = 200;
	showWeaponBar = true;
};

ItemData VehicleRocket
{
	description = "Unguided Rocket";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 250;
	showWeaponBar = true;
};

ItemData NapalmLauncher
{
	description = "Napalm Launcher";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 300;
	showWeaponBar = true;
};

ItemData VehicleClusterCannon
{
	description = "Cluster Cannon";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 350;
	showWeaponBar = true;
};

ItemData VehicleEMPLauncher
{
	description = "EM Pulse Launcher";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 300;
	showWeaponBar = true;
};

ItemData VehicleBomb
{
	description = "HEAP Bombs";
	className = "VehicleWeapon";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "bVehicle Weapons";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 500;
	showWeaponBar = true;
};

ItemData AmmoModule
{
	description = "Ammo Module";
	className = "VehicleModule";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "cVehicle Modules";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 350;
	showWeaponBar = true;
};

ItemData RepairModule
{
	description = "Repair Module";
	className = "VehicleModule";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "cVehicle Modules";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 300;
	showWeaponBar = true;
};

ItemData ShieldModule
{
	description = "Shield Module";
	className = "VehicleModule";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "cVehicle Modules";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 250;
	showWeaponBar = true;
};

ItemData SpeedModule
{
	description = "Speed Module";
	className = "VehicleModule";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "cVehicle Modules";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 200;
	showWeaponBar = true;
};

ItemData StealthModule
{
	description = "Stealth Module";
	className = "VehicleModule";
	shapeFile = "breath";
 	hudIcon = "chain";
      heading = "cVehicle Modules";
	shadowDetailMask = 4;
	imageType = MiscModuleImage;
	price = 300;
	showWeaponBar = true;
};

// ARMOURS
$HC::EquipmentDescriptions[LightArmor] = "Light Armour remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[MediumArmor] = "Medium Armour has been balanced.  It is now an exact middle-ground \nbetween Light and Heavy Armours.";
$HC::EquipmentDescriptions[HeavyArmor] = "Heavy Armour remains unchanged from base Tribes.";

// WEAPONS
$HC::EquipmentDescriptions[Blaster] = "The Blaster remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[PlasmaGun] = "The Plasma Gun remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[Chaingun] = "The Chaingun remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[Disclauncher] = "The Disc Launcher remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[GrenadeLauncher] = "The Grenade Launcher remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[LaserRifle] = "Now useable by any armour and with any pack, the Laser Rifle causes \nconsiderably more damage when coupled with an Energy Pack.";
$HC::EquipmentDescriptions[EnergyRifle] = "More effective than ever before, the ELF Gun's increased range and \ndamage make it a fearsome battlefield weapon.";
$HC::EquipmentDescriptions[Mortar] = "The Mortar remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[Clustergun] = "A powerful weapon which fires a spray of high-explosive cluster \nmunitions at a target.";
$HC::EquipmentDescriptions[EMPulsegun] = "An area-effect energy weapon which causes electrical feedback that \ncan short out turrets, sensors, and even other players.\n\nThe EM Pulse Gun will also short out and heavily damage any Force Fields caught in its blast.";

// MISCELLANEOUS ITEMS
$HC::EquipmentDescriptions[MineAmmo] = "Mines remain unchanged from base Tribes.";
$HC::EquipmentDescriptions[Grenade] = "Grenades remain unchanged from base Tribes.";
$HC::EquipmentDescriptions[Beacon] = "Now able to cloak itself and to resist more damage, the Beacon is \nmore useful than ever before.";
$HC::EquipmentDescriptions[RepairKit] = "Repair Kits remain unchanged from base Tribes.";
$HC::EquipmentDescriptions[TargetingLaser] = "The Targeting Laser no longer draws power from the user's power cells.";

// BACKPACKS
$HC::EquipmentDescriptions[AmmoPack] = "The Ammo Pack no longer stores extra ammunition. Hit the (P)ack key to \nactivate/deactive the ammo-regeneration facility.";
$HC::EquipmentDescriptions[DecoyFlagPack] = "The Decoy Flag allows a user to confound and confuse enemies.  \nAs an added bonus, this pack also makes the user slightly more maneuverable.";
$HC::EquipmentDescriptions[EnergyPack] = "The Energy Pack remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[ForceFieldPack] = "Hit the (P)ack key to generate a force field on any surface.\n\nForce Fields decay slowly over time but may be recharged with the Power Generator Pack.";
$HC::EquipmentDescriptions[StairwayForceFieldPack] = "Hit the (P)ack key to generate a force field on any surface.\n\nForce Fields decay slowly over time.";
$HC::EquipmentDescriptions[PowerPack] = "Use the Power Generator Pack to power or enhance stations, players, vehicles, and turrets.\n\nAlso use the Power Generator Pack to recharge Force Fields and Remote Inventory/ Ammo Stations.";
$HC::EquipmentDescriptions[RepairPack] = "The Repair Pack remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[SensorJammerPack] = "The Sensor Jammer Pack cloaks the user in invisiblity.  \nEven the red triangle disappears if the user remains motionless.";
$HC::EquipmentDescriptions[ShieldPack] = "The Shield Pack remains unchanged from base Tribes.";

// DEPLOYABLES
$HC::EquipmentDescriptions[AATurretPack] = "The Anti-Air Turret will attack and destroy piloted Vehicles and jetting players.";
$HC::EquipmentDescriptions[CameraPack] = "Remote Cameras remain unchanged from base Tribes.";
$HC::EquipmentDescriptions[DeployableAmmoPack] = "The Remote Ammo Station remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[DeployableInvPack] = "The Remote Inventory Station remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[GravityPadPack] = "Once deployed, Gravity Pads provide an instant lift to anyone who walks on them.";
$HC::EquipmentDescriptions[HeavyTurretPack] = "The Heavy Turret Pack is a heavy, shielded turret.";
$HC::EquipmentDescriptions[ImpulseTurretPack] = "The Impulse Turret causes no damage but pushes enemies away from itself.";
$HC::EquipmentDescriptions[MotionSensorPack] = "The Laser Motion Sensor detects even cloaked enemies -- as long as they are moving.";
$HC::EquipmentDescriptions[PointDefencePack] = "Mounted on walls, roofs, or floors, this motion-activated chain-turret \nprovides great short-range indoors defence.";
$HC::EquipmentDescriptions[ProximityAlarmPack] = "The Proximity Alarm will announce the presence of any enemies within sensor range.";
$HC::EquipmentDescriptions[PulseSensorPack] = "The Pulse Sensor remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[TurretPack] = "The Remote Turret remains unchanged from base Tribes.";
$HC::EquipmentDescriptions[WeaponLockOutPack] = "Able to be deployed almost anywhere, the Weapon Lock Out will shut \ndown the weapon systems of enemies within its fifteen meter range.";

// VEHICLES
$HC::EquipmentDescriptions[ScoutVehicle] = "The Fighter can now be outfitted with a Vehicle Weapon and a Vehicle Module.\nFighter weaponry is now ammunition-limited.  The blue 'energy' bar shows how \nmuch ammunition remains for use.  Ammunition and damage can be restored by \nhovering over a friendly Vehicle Pad.";
$HC::EquipmentDescriptions[LAPCVehicle] = "Able to be piloted by Medium or Light Armour, the Light Carrier can also have a Vehicle Module.";
$HC::EquipmentDescriptions[HAPCVehicle] = "Able to be piloted by any armour, the Heavy Carrier can be mounted with a single Vehicle Module.";

// VEHICLE WEAPONS
$HC::EquipmentDescriptions[NapalmLauncher] = "Launch burning liquid death over a large area with the Napalm Launcher.  \nThough relatively ineffective against hardened targets, it can \nquickly and easily kill any armour type in the open.";
$HC::EquipmentDescriptions[RotaryChaingun] = "A rapid-firing, heavy vehicle-mounted version of the chaingun, the Rotary \nCannon's explosive-tipped rounds will tear through almost any target.";
$HC::EquipmentDescriptions[VehicleBomb] = "Four High-Explosive Armour-Piercing Bombs may be mounted under the \nFighter's wings.  Each has enough power to kill or cripple anything \nwithin the huge blast radius.";
$HC::EquipmentDescriptions[VehicleClusterCannon] = "A general-purpose weapon ideal for air-to-air and air-to-ground combat, \nthe Cluster Cannon is a heavier version of the Cluster Gun.";
$HC::EquipmentDescriptions[VehicleEMPLauncher] = "A vehicle-mounted version of the EM Pulse gun, the EMP Launcher can \nshort out sensors, turrets, and other players.\n\nThe EMP Launcher will also short out and \nheavily damage any Force Fields caught in its blast.";
$HC::EquipmentDescriptions[VehicleRocket] = "Similar to the scout's rockets from base Tribes, unguided vehicle \nrockets are dumb missiles that explode on contact.";

// VEHICLE MODULES
$HC::EquipmentDescriptions[AmmoModule] = "The Ammo Module is always active, slowly restoring a Fighter's ammunition.";
$HC::EquipmentDescriptions[RepairModule] = "The Repair Module is always active, slowly restoring a Vehicle to full health.";
$HC::EquipmentDescriptions[ShieldModule] = "The Shield Module is always active, protecting the Vehicle and its occupant(s) from harm.";
$HC::EquipmentDescriptions[SpeedModule] = "The Speed Module increases a Vehicle's speed, acceleration, and maneuverability.";
$HC::EquipmentDescriptions[StealthModule] = "The Stealth Module protects a Vehicle and its occupant(s) from being \ndetected and targeted by enemy turrets and sensors.";