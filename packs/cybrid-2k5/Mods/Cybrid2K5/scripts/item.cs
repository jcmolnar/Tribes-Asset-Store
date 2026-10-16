// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

$ItemFavoritesKey = "Cybrid2K5";  

exec(SpecialEffects); //Armageddon's Majik Flagypoo
exec(SpecialEffectBombs); //Armageddon's Majik Flagypoo
exec(SpecialEffectsFunctions); //Armageddon's Majik Flagypoo

//================================
// Easy Way For Invetory Headings
//================================
$InvHead[ihArm] = "a-=)Armor Suits¤•";       
$InvHead[ihWea] = "b-=)Weapon Cache¤•";
$InvHead[ihCyL] = "c•¤• Banshee Cache •¤•";
$InvHead[ihCyM] = "d•¤• Adjudicator Cache •¤•";
$InvHead[ihCyH] = "e•¤• Executioner Cache •¤•";
$InvHead[ihHyL] = "f•¤• Talon Cache •¤•";
$InvHead[ihHyM] = "g•¤• Predator Cache •¤•";
$InvHead[ihHyH] = "h•¤• Eagle Cache •¤•";
$InvHead[ihCLB] = "i•¤• Banshee Packs •¤•";
$InvHead[ihCMB] = "j•¤• Adjudicator Packs •¤•";
$InvHead[ihCHB] = "k•¤• Executioner Packs •¤•";
$InvHead[ihHLB] = "l•¤• Talon Packs •¤•";
$InvHead[ihHMB] = "m•¤• Predator Packs •¤•";
$InvHead[ihHHB] = "n•¤• Eagle Packs •¤•";
$InvHead[ihTur] = "o-=)Turret Systems¤•"; 
$InvHead[ihBkp] = "p-=)Tactical Back Packs¤•";
$InvHead[ihFie] = "q-=)Field Equiptment¤•";
$InvHead[ihSen] = "r-=)Sensor Networks¤•";
$InvHead[ihUpg] = "s-=)Armor Upgrades¤•";
$InvHead[ihBfe] = "t-=)Base/Field Equipment¤•";
$InvHead[ihDef] = "u-=)Deffence Equiptment¤•";
//===========================================
// Slots ETC
//-------------------------------------------
$ItemPopTime = 3;
$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;
//===========================================
// Auto Use?
//-------------------------------------------

$AutoUse[FusionRifle] = False;
$AutoUse[PhazerRifle] = False;
$AutoUse[ElectroPlasmCannon] = False;

$AutoUse[EnergyPistol] = False;
$AutoUse[TriFusionCannon] = False;
$AutoUse[PulseGrenadeLauncher] = False;
$AutoUse[ToxicThrower] = False;
$AutoUse[PulseRocketGun] = False;

$AutoUse[AntimatterRocketGun] = False;
$AutoUse[IONCannon] = False;
$AutoUse[PulseGauss] = False;
$AutoUse[ArmageddonCannon] = False;
$AutoUse[EnergyBeamCannon] = False;
$AutoUse[SplitFissionGun] = False;
$AutoUse[ReverseFissionEmitter] = False;

$AutoUse[Pistol] = False;
$AutoUse[Verminator] = False;
$AutoUse[SniperRifle] = False;
$AutoUse[ShotGun] = False;
$AutoUse[TalonRocketGun] = False;

$AutoUse[MissileLauncher] = False;
$AutoUse[BlazeThrower] = False;
$AutoUse[BurnerGun] = False;
$AutoUse[MineLauncher] = False;
$AutoUse[RailGun] = False;
$AutoUse[AutoGrenadeGun] = False;
$AutoUse[AssaultRifle] = False;

$AutoUse[HybridLaser] = False;
$AutoUse[HybridChain] = False;
$AutoUse[HybridRail] = False;
$AutoUse[HybridCannon] = False;
$AutoUse[HybridPlasma] = False;
$AutoUse[HybridMortar] = False;
$AutoUse[HybridRocketLauncher] = False;
$AutoUse[HybridQuadLauncher] = False;
$AutoUse[HybridNuke] = False;
//===========================================
// Use?
//-------------------------------------------
$Use[FusionRifle] = False;
$Use[PhazerRifle] = False;
$Use[ElectroPlasmCannon] = False;

$Use[EnergyPistol] = False;
$Use[TriFusionCannon] = False;
$Use[PulseGrenadeLauncher] = False;
$Use[ToxicThrower] = False;
$Use[PulseRocketGun] = False;

$Use[AntiMatterRocketGun] = False;
$Use[IONCannon] = False;
$Use[PulseGauss] = False;
$Use[ArmageddonCannon] = False;
$Use[SplitFissionGun] = False;
$Use[ReverseFissionEmitter] = False;

$Use[Pistol] = False;
$Use[Verminator] = False;
$Use[SniperRifle] = False;
$Use[ShotGun] = False;
$Use[TalonRocketGun] = False;

$Use[MissileLauncher] = False;
$Use[BlazeThrower] = False;
$Use[BurnerGun] = False;
$Use[MineLauncher] = False;
$Use[RailGun] = False;
$Use[AutoGrenadeGun] = False;
$Use[AssaultRifle] = False;

$Use[HybridLaser] = False;
$Use[HybridChain] = False;
$Use[HybridRail] = False;
$Use[HybridCannon] = False;
$Use[HybridPlasma] = False;
$Use[HybridMortar] = False;
$Use[HybridRocketLauncher] = False;
$Use[HybridQuadLauncher] = False;
$Use[HybridNuke] = False;
//===========================================
// Armor Name To DataBlock Name
//-------------------------------------------
$ArmorType[Male, HybridLightArmor] = HyLight;
$ArmorType[Female, HybridLightArmor] = HyLight;
$ArmorType[Male, HybridMediumArmor] = HyMedium;
$ArmorType[Female, HybridMediumArmor] = HyMedium;
$ArmorType[Male, HybridHeavyArmor] = HyHeavy;
$ArmorType[Female, HybridHeavyArmor] = HyHeavy;
//=====Cybrids
$ArmorType[Male, CybridLightArmor] = CyLight;
$ArmorType[Female, CybridLightArmor] = CyLight;
$ArmorType[Male, CybridMediumArmor] = CyMedium;
$ArmorType[Female, CybridMediumArmor] = CyMedium;
$ArmorType[Male, CybridHeavyArmor] = CyHeavy;	   
$ArmorType[Female, CybridHeavyArmor] = CyHeavy;
//===========================================
// DataBlock Name To List Name
//-------------------------------------------
$ArmorName[HyLight] = HybridLightArmor;
$ArmorName[HyMedium] = HybridMediumArmor;
$ArmorName[HyHeavy] = HybridHeavyArmor;
$ArmorName[CyLight] = CybridLightArmor;
$ArmorName[CyMedium] = CybridMediumArmor;
$ArmorName[CyHeavy] = CybridHeavyArmor;

//===========================================
// For Grens/Mines/Beacons/Nodes
//-------------------------------------------
$Grenade[0] = 12;
$Grenade[1] = VortexGrenade;
$Grenade[2] = FusionGrenade;
$Grenade[3] = PulseGrenade;
$Grenade[4] = RadiationGrenade;
$Grenade[5] = RailGrenade;

//--------------------------------------------
$Mine[0] = 2;
$Mine[1] = OriginalMine;
$Mine[2] = TripMine;
//---------------------------------------------
// Amount to remove when selling or dropping ammo
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[OriginalGrenade] = 4;

$SellAmmo[VortexGrenade] = 3;
$SellAmmo[FusionGrenade] = 3;
$SellAmmo[PulseGrenade] = 5;
$SellAmmo[RadiationGrenade] = 5;
$SellAmmo[RailGrenade] = 4;

//-----------------------------
$SellAmmo[OriginalMine] = 10;
$SellAmmo[TripMine] = 5;
//===========================================
// Team Item Max #
//-------------------------------------------
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[PulseSensorPack] = 10;
$TeamItemMax[MotionSensorPack] = 10;

$TeamItemMax[ScoutVehicle] = 10;
$TeamItemMax[MercJetVehicle] = 10;
$TeamItemMax[HAPCVehicle] = 10;
$TeamItemMax[LAPCVehicle] = 12;
$TeamItemMax[Beacon] = 500;
$TeamItemMax[mineammo] = 500;
$TeamItemMax[ElectricWeb] = 5;

//===========================================
// Damage Skins
//-------------------------------------------
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
//===========================================
// Weapon To Ammo
//-------------------------------------------
$WeaponAmmo[FusionRifle] = "";
$WeaponAmmo[PhazerRifle] = "";
$WeaponAmmo[ElectroPlasmCannon] = "";

$WeaponAmmo[EnergyPistol] = "";
$WeaponAmmo[TriFusionCannon] = "";
$WeaponAmmo[PulseGrenadeLauncher] = "";
$WeaponAmmo[ToxicThrower] = "";
$WeaponAmmo[PulseRocketGun] = "";

$WeaponAmmo[AntiMatterRocketGun] = "";
$WeaponAmmo[IONCannon] = "";
$WeaponAmmo[PulseGauss] = "";
$WeaponAmmo[ArmageddonCannon] = "";
$WeaponAmmo[EnergyBeamCannon] = "";
$WeaponAmmo[SplitFissionGun] = "";
$WeaponAmmo[ReverseFissionEmitter] = "";

$WeaponAmmo[Pistol] = "";
$WeaponAmmo[Verminator] = "";
$WeaponAmmo[SniperRifle] = "";
$WeaponAmmo[ShotGun] = "";
$WeaponAmmo[TalonRocketGun] = "";

$WeaponAmmo[MissileLauncher] = "";
$WeaponAmmo[BlazeThrower] = "";
$WeaponAmmo[BurnerGun] = "";
$WeaponAmmo[MineLauncher] = "";
$WeaponAmmo[RailGun] = "";
$WeaponAmmo[AutoGrenadeGun] = "";
$WeaponAmmo[AssaultRifle] = "";

$WeaponAmmo[HybridLaser] = "";
$WeaponAmmo[HybridChain] = "";
$WeaponAmmo[HybridRail] = "";
$WeaponAmmo[HybridCannon] = "";
$WeaponAmmo[HybridPlasma] = "";
$WeaponAmmo[HybridMortar] = "";
$WeaponAmmo[HybridRocketLauncher] = "";
$WeaponAmmo[HybridQuadLauncher] = "";
$WeaponAmmo[HybridNuke] = "";
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

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%favItem20,%favItem21,%favItem22,%favItem23,%favItem24,%favItem25,%favItem26,%favItem27,%favItem28,%favItem29)
{
	%clientId = %client;
	%client.CurFav = %favItem[0];
	for(%i = 1; %favItem[%i] != ""; %i++)
		%client.CurFav = %client.CurFav @", "@ %favItem[%i];

	if (isPlayerBusy(%client))
		return;

   // only can buy fav every 1/2 second
   %time = getIntegerTime(true) >> 4; // int half seconds
   if(%time <= %client.lastBuyFavTime)
      return;

   %client.lastBuyFavTime = %time;

	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" || %client.isSpecialFav) {
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
				if ((Client::isItemShoppingOn(%client,%item)|| %client.isSpecialFav) || $TestCheats || $ServerCheats) {
					%count = Player::getItemCount(%client,%item);
					if(%count) {
						if(%item.className != Armor) 
							teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);  
					}
				}
			}

			for (%i = 0; %i < 30; %i++)
			{ 
				if(getItemData(%favItem[%i]).className == Armor)
				{
					%buyArmor = getItemData(%favItem[%i]);
					buyItem(%client,%buyArmor);  
					break;
				}
		  	}
			updateBuyingList(%client);

			%string = "finishBuyFavorites("@%client;
			for(%i = 0; %favItem[%i] != ""; %i++)
				%string = %string@","@%favItem[%i];
			%string = %string @ ");";
			schedule(%string,0.2);
		}
	}

	if($Settings::Station[%client] == "")
	{
		$Settings::Station[%client] = 11;
		Client::sendMessage(%client, 3, "Your inventory method has just been changed to \"Auto-Buy on Collision\". Please press tab to change it if needed.");
	}
}

function finishBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%favItem20,%favItem21,%favItem22,%favItem23,%favItem24,%favItem25,%favItem26,%favItem27,%favItem28,%favItem29)
{
	%clientId = %client;
	for (%i = 0; %i < 30; %i++)
	{ 
		if(getItemData(%favItem[%i]).className == Armor)
		{
			%buyArmor = getItemData(%favItem[%i]);
			break;
		}
  	}

	for (%i = 0; %i < 30; %i++)
	{ 
		if(%favItem[%i] != "")
		{
			%item = getItemData(%favItem[%i]);
			if (((Client::isItemShoppingOn(%client,%item)) || %client.isSpecialFav) && ($ItemMax[Player::getArmor(%client),  %item] > Player::getItemCount(%client,%item) || %item.className == Armor))
			{
				if(%item != %buyArmor)
				{
					if(!buyItem(%client,%item))  
						%error = 1;
					else
						%bought++;
				}
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
	if(%clientId.isSpecialFav)
		%clientId.isSpecialFav = "";
}


function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}

function Old::checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);

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
		else if(Player::getItemClassCount(%client,"Weapon")+$WeaponSlotOccupation[%item] > $MaxWeapons[%armor])
		{
			Client::sendMessage(%client,0,"Need " @ $WeaponSlotOccupation[%item] @ " SLOTS to carry this weapon!");
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
	if(%item.className != Armor && %item.className != Vehicle) 
{
	   %count = Player::getItemCount(%client,%item);
	  	%max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo ;
	   if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

function checkResources(%player,%item,%delta,%noMessage,%armor)
{
	%client = Player::getClient(%player);
	if(%armor == "")
		%armor = Player::getArmor(%client);

	%team = Client::getTeam(%client);

	if($TestCheats == 0 && %client.spawn == "")
	{
		%energy = $TeamEnergy[%team];
    		%station = %player.Station;
		%sName = GameBase::getDataName(%station);
		if(%sName == DeployableInvStation || %sName == DeployableAmmoStation)
		{
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
	if(%item.className == Weapon)
	{
		%wcount = Player::getItemClassCount(%player,"Weapon");
		if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) {
			Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
		else if(Player::getItemClassCount(%client,"Weapon")+$WeaponSlotOccupation[%item] > $MaxWeapons[%armor])
		{
			Client::sendMessage(%client,0,"Need " @ $WeaponSlotOccupation[%item] @ " SLOTS to carry this weapon!");
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
		%count = Player::getItemCount(%player,%item);
		%max = $ItemMax[%armor, %item] + %extraAmmo ;
		if(%delta + %count >= %max) 
			%delta = %max - %count;
	}
	return %delta;
}

GrenadeData BuyArmorProj
{
   bulletShapeName    = "fusionex.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "fusionex.dts";
};

function LaunchArmorBuyProj(%player) 
{
	%armor = Player::getArmor(%player);
	%pack = Player::getMountedItem(%player,$BackpackSlot);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
	Projectile::spawnProjectile("BuyArmorProj",%trans,%player,%vel,%player);
}

//----------------------------------------------------------------------------
// Replace Grenade Types so only one type is equipted ~ Armageddon 2004
//----------------------------------------------------------------------------
function ResetGrenades(%client) 
{
	Player::setItemCount(%client,Grenade,0);
	Player::setItemCount(%client,OriginalGrenade,0);

	Player::setItemCount(%client,VortexGrenade,0);
	Player::setItemCount(%client,FusionGrenade,0);
	Player::setItemCount(%client,PulseGrenade,0);
	Player::setItemCount(%client,RadiationGrenade,0);
	Player::setItemCount(%client,RailGrenade,0);

}
//---------------------------------------------------------------

function buyItem(%client,%item,%buyArmor)
{
	%clientId = %client;
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	%pack = Player::getMountedItem(%client,$BackpackSlot);

	%checkCheats = $ServerCheats || $TestCheats;
	%checkA = %checkCheats || Client::isItemShoppingOn(%client,%item) || %client.spawn || %clientId.isSpecialFav;
	%checkB = $ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats;
	if (%checkA && %checkB)
	{
		if (%item.className == Armor)
		{
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if($debug)

				echo(%buyarmor);
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)
			{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1))
				{
					if($Armor::BuySpecial[%armor])
						eval("SellSpecial::"@%armor@"("@%client@");");

					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
					//Start Armor Extras
 					if (%buyarmor == "CyLight")
					{
					Player::setItemCount	(%client, BansheePack,1);
					schedule ("Player::mountItem( " @ %client @ ", BansheePack,7);",0.3);
					}
					else if (%buyarmor != "CyLight")
					{
					Player::unMountItem(%client,7);
					}
					//------
 					if (%buyarmor == "CyMedium")
					{
					Player::setItemCount	(%client, AdjucPack,1);
					Player::setItemCount	(%client, Adjuc2Pack,1);
					schedule ("Player::mountItem( " @ %client @ ", AdjucPack,6);",0.3);
					schedule ("Player::mountItem( " @ %client @ ", Adjuc2Pack,7);",0.3);
					}
					else if (%buyarmor != "CyMedium")
					{
					Player::unMountItem(%client,6);
					Player::unMountItem(%client,7);
					}
					//------
 					if (%buyarmor == "CyHeavy")
					{
					Player::setItemCount	(%client, ExecutionerPack,1);
					Player::setItemCount	(%client, Executioner2Pack,1);
					schedule ("Player::mountItem( " @ %client @ ", ExecutionerPack,6);",0.3);
					schedule ("Player::mountItem( " @ %client @ ", Executioner2Pack,7);",0.3);
					}
					else if (%buyarmor != "CyHeavy")
					{
					Player::unMountItem(%client,6);
					Player::unMountItem(%client,7);
					}
					//------
 					if (%buyarmor == "HyLight")
					{
					Player::setItemCount	(%client, TalonPack,1);
					schedule ("Player::mountItem( " @ %client @ ", TalonPack,7);",0.3);
					}
					else if (%buyarmor != "HyLight")
					{
					Player::unMountItem(%client,7);
					}
					//------
 					if (%buyarmor == "HyMedium")
					{
					Player::setItemCount	(%client, Predator1Pack,1);
					Player::setItemCount	(%client, Predator2Pack,1);
					schedule ("Player::mountItem( " @ %client @ ", Predator1Pack,6);",0.3);
					schedule ("Player::mountItem( " @ %client @ ", Predator2Pack,7);",0.3);
					}
					else if (%buyarmor != "HyMedium")
					{
					Player::unMountItem(%client,6);
					Player::unMountItem(%client,7);
					}
					//------
 					if (%buyarmor == "HyHeavy")
					{
					Player::setItemCount	(%client, Eagle1Pack,1);
					Player::setItemCount	(%client, Eagle2Pack,1);
					schedule ("Player::mountItem( " @ %client @ ", Eagle1Pack,6);",0.3);
					schedule ("Player::mountItem( " @ %client @ ", Eagle2Pack,7);",0.3);
					}
					else if (%buyarmor != "HyHeavy")
					{
					Player::unMountItem(%client,6);
					Player::unMountItem(%client,7);
					}
					if(!%client.spawn)
						LaunchArmorBuyProj(%player);
     					Player::setItemCount(%client, $ArmorName[%armor], 0);  
     					Player::setItemCount(%client, %item, 1);  
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack)
		{
			if($TeamItemMax[%item] != "")
			{
				if(!$TeamItemCount[GameBase::getTeam(%client) @ %item])
					$TeamItemCount[GameBase::getTeam(%client) @ %item] = 0;

				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 		return 0;
				else if(!%client.isSpecialFav && !%client.spawn)
					Client::SendMessage(%client, 3, $TeamItemCount[GameBase::getTeam(%client) @ %item]@" out of "@$TeamItemMax[%item]);
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
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,Beacon, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
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
	if (($ServerCheats || (Client::isItemShoppingOn(%client,%item) || %clientId.isSpecialFav) || $TestCheats) && %item != "flag") {
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
			else if(%item == EnergyPack) { 
				if(Player::getItemCount(%client,"LaserRifle") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					remoteSellItem(%client,22);						
				}
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
	else if(%item == "flag")
		return;

	Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav");
}

function remoteUseItem(%client,%type)
{
	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
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
	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	%player=Client::getownedobject(%client);
	if((%player==-1) || Player::IsDead(%player))
	return;

	%item = getItemData(%type);
	if (%item == Grenade || %item == MineAmmo) 
	{
		if (%strength < 0) %strength = 0;
		else if (%strength > 100) %strength = 100;
		%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
		Player::useItem(%client,%item);
	}
}

function remoteDropItem(%client,%type)
{
	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	if((Client::getOwnedObject(%client)).driver != 1) {
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
	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

//==Quick Weapon Add, Next/Prev

$NWeapons=0;

function AddWeapon(%WeaponName)
{	// Create a New Weapon Index
	$Weap[$NWeapons]=%WeaponName;
	%PrevWeapon=$NWeapons-1;
	if(%PrevWeapon<0) %PrevWeapon=0;
	$NextWeapon[$Weap[%PrevWeapon]]=%WeaponName;	// Set the Prev Weapon to The New Weapon
	$NextWeapon[%Weapon]=$Weap[0];					// Set the Next Weapon to the First Weapon
	$PrevWeapon[$Weap[0]]=%WeaponName;
	$PrevWeapon[%WeaponName]=$Weap[%PrevWeapon];
	$NWeapons++;
	if($debug)
	{
		echo("$Weapon::preName[" @ $NWeapons @ "] = "				@ $Weapon::preName[$NWeapons]);
		echo("$PrevWeapon[" @ $Weapon::preName[0] @ "] = "			@ $PrevWeapon[$Weapon::preName[0]]);
		echo("$NextWeapon[" @ %Weapon @ "] = "					@ $NextWeapon[%Weapon]);
		echo("$NextWeapon[" @ $Weapon::preName[%PrevWeapon] @ "] = "	@ $NextWeapon[$Weapon::preName[%PrevWeapon]]);
		echo("$PrevWeapon[" @ %WeaponName @ "] = "				@ $PrevWeapon[$Weapon::preName[0]]);
		
	}
}

AddWeapon(PhazerRifle);
AddWeapon(FusionRifle);
AddWeapon(ElectroPlasmCannon);
AddWeapon(EnergyPistol);
AddWeapon(TriFusionCannon);
AddWeapon(PulseGrenadeLauncher);
AddWeapon(ToxicThrower);
AddWeapon(PulseRocketGun);
AddWeapon(AntiMatterRocketGun);
AddWeapon(IONCannon);
AddWeapon(PulseGauss);
AddWeapon(ArmageddonCannon);
AddWeapon(EnergyBeamCannon);
AddWeapon(SplitFissionGun);
AddWeapon(ReverseFissionEmitter);
AddWeapon(Pistol);
AddWeapon(Verminator);
AddWeapon(SniperRifle);
AddWeapon(ShotGun);
AddWeapon(TalonRocketGun);
AddWeapon(MissileLauncher);
AddWeapon(BlazeThrower);
AddWeapon(BurnerGun);
AddWeapon(MineLauncher);
AddWeapon(RailGun);
AddWeapon(AutoGrenadeGun);
AddWeapon(AssaultRifle);
AddWeapon(HybridLaser);
AddWeapon(HybridChain);
AddWeapon(HybridRail);
AddWeapon(HybridCannon);
AddWeapon(HybridPlasma);
AddWeapon(HybridMortar);
AddWeapon(HybridRocketLauncher);
AddWeapon(HybridQuadLauncher);
AddWeapon(HybridNuke);



function remoteNextWeapon(%client)
{
	if(!(%client.observerMode == "" || %client.observerMode == "pregame"))
		return;

	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	%co1 = Client::getControlObject(%client);
	%co = GameBase::getDataName(%co1);
	if(%co != Scout && %co != MercJet && %co != LAPC && %co != HAPC)
	{
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (%item == -1 || $NextWeapon[%item] == "")
			selectValidWeapon(%client);
		else {
			for (%weapon = $NextWeapon[%item]; %weapon != %item;
					%weapon = $NextWeapon[%weapon]) {
				if (isSelectableWeapon(%client,%weapon)) {
					Player::useItem(%client,%weapon);
					if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				}
			}
		}
	}
	else
		getNextVWeap(%client);
}

function remotePrevWeapon(%client)
{
	if(!(%client.observerMode == "" || %client.observerMode == "pregame"))
		return;

	if(%client.possessed)
	{
		return;
	}

	if(%client.possessing)
	{
		%client = %client.poss;
	}
	%co1 = Client::getControlObject(%client);
	%co = GameBase::getDataName(%co1);
	if(%co != Scout && %co != MercJet && %co != LAPC && %co != HAPC)
	{
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (%item == -1 || $PrevWeapon[%item] == "")
			selectValidWeapon(%client);
		else {
			for (%weapon = $PrevWeapon[%item]; %weapon != %item;
					%weapon = $PrevWeapon[%weapon]) {
				if (isSelectableWeapon(%client,%weapon)) {
					Player::useItem(%client,%weapon);
					if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				}
			}
		}
	}
	else
		getPrevVWeap(%client);
}
function selectValidWeapon(%client)
{
	%item = PhazerRifle;
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

// Default Item

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]) {		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack) {
			if (Player::getMountedItem(%player,$BackpackSlot) == -1) {
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
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
  		else {
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
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
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}	

function Item::respawn(%this)
{
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
	Player::mountItem(%player,%item,$DefaultSlot);
}

function Item::pop(%item)
{
 	GameBase::startFadeOut(%item);
   schedule("deleteObject(" @ %item @ ");",15, %item);
}

function Item::onDrop(%player,%item)
{
	if($matchStarted) {
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

function Flag::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function Flag::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
} 
//----------------------------------------------------------------------------

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };
	lightType = 2;   
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
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

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData HybridLightArmor
{
   heading = $InvHead[ihArm];
	description = "Hybrid: Talon";
	className = "Armor";
	price = 0;
};

ItemData HybridMediumArmor
{
   heading = $InvHead[ihArm];
	description = "Hybrid: Predator";
	className = "Armor";
	price = 0;
};

ItemData HybridHeavyArmor
{
   heading = $InvHead[ihArm];
	description = "Hybrid: Eagle";
	className = "Armor";
	price = 0;
};


ItemData CybridLightArmor
{
   heading = $InvHead[ihArm];
	description = "Cybrid: Banshee";
	className = "Armor";
	price = 0;
};

ItemData CybridMediumArmor
{
   heading = $InvHead[ihArm];
	description = "Cybrid: Adjudicator";
	className = "Armor";
	price = 0;
};

ItemData CybridHeavyArmor
{
   heading = $InvHead[ihArm];
	description = "Cybrid: Executioner";
	className = "Armor";
	price = 0;
};
//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Brawler Assault";
	className = "Vehicle";
   heading = "a-=[Vehicle]=-";
	price = 5000;
};

ItemData MercJetVehicle
{
	description = "Mercenary Jet-Bike";
	className = "Vehicle";
   heading = "a-=[Vehicle]=-";
	price = 6000;
};

ItemData LAPCVehicle
{
	description = "Star Destroyer";
	className = "Vehicle";
   heading = "a-=[Vehicle]=-";
	price = 6500;
};

ItemData HAPCVehicle
{
	description = "Hover Tank";
	className = "Vehicle";
   heading = "a-=[Vehicle]=-";
	price = 7500;
};


//+++++++++++++++++++++++++++++++++++++
// Weapon Code
//+++++++++++++++++++++++++++++++++++++
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
function HybridVector::rotVector(%vec,%rot)
{
	%vec_x = getWord(%vec,0);
	%vec_y = getWord(%vec,1);
	%vec_z = getWord(%vec,2);
	%basevec = %vec_x @ "  " @ %vec_y @ "  0";
	%basedis = Vector::getDistance( "0 0 0", %basevec);
	%normvec = Vector::normalize( %basevec );
	%baserot = Vector::add( Vector::getRotation( %normvec ), "1.571 0 0" );
	%newrot = Vector::add( %baserot, %rot );
	%newvec = Vector::getFromRot( %newrot, %basedis, %vec_z );

	return %newvec;
}
//--------------------------------------------------------------
ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 1;
	reloadTime = 0.1;

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
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 0;
	showWeaponBar = false;
};

//------------------------------------------------------------------------------
// Cybrid Light Weapons
//----------------------------------------------------------------------------
ItemImageData PhazerRifle2Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
   	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 7, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 20;
	maxEnergy = 30;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.0, 5.0, 0.0 };
};

ItemData PhazerRifle2
{
	description = "PhazerRifle2";
	className = "Scope";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = PhazerRifle2Image;
	price = 0;
	showWeaponBar = FALSE;
	showInventory = FALSE;
	validateShape = TRUE;
};

ItemImageData PhazerRifleImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
   	mountOffset = { 0.1, 0, 0 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, -7, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	projectileType = PhazerLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 20;
	maxEnergy = 30;
	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 0.0, 5.0, 0.0 };
	sfxFire = SoundPhazerPistolFire;
	sfxActivate = SoundPhazerPistolActivate;
	sfxReload = SoundPhazerPistolReload;
	sfxReady = SoundPhazerPistolReady;
};

ItemData PhazerRifle
{
	description = "Phazer Pistol";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "reticle";
   heading = $InvHead[ihCyL];
	shadowDetailMask = 4;
	imageType = PhazerRifleImage;
	price = 150;
	showWeaponBar = true;
};


function PhazerRifle::onMount(%player,%item,$WeaponSlot)
{
	GameBase::setRechargeRate(%player,50); 
	%client = Player::getclient(%player);
      	Bottomprint(%client, "Phazer Rifle: <f2>You tend to glow after useing this.", 3);
	Player::mountItem(%player,PhazerRifle2,3);
}

function PhazerRifle::onUnmount(%player,%item,$WeaponSlot)
{
	GameBase::setRechargeRate(%player,8); 
	Player::unmountItem(%player,3);
}
//----------------------------------------------------------------------------------------
ItemImageData FusionScopeImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
   	mountOffset = { 0, -0.05, 0.04 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData FusionScope
{
	description = "Fusion Scope";
	className = "Scope";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = FusionScopeImage;
	price = 0;
	showWeaponBar = FALSE;
	showInventory = FALSE;
	validateShape = TRUE;
};

ItemImageData FusionScope2Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
   	mountOffset = { 0, 0.6, 0.05 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 22.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData FusionScope2
{
	description = "Fusion Scope2";
	className = "Scope";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = FusionScope2Image;
	price = 0;
	showWeaponBar = FALSE;
	showInventory = FALSE;
	validateShape = TRUE;
};

ItemImageData FusionRifleImage
{
   shapeFile  = "sniper";
	mountPoint = 0;
      	mountRotation = { 0, 0, 0 };
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 1;
	maxEnergy = 0.1;
	projectileType = FusionRifleBullet;
	accuFire = true;
	sfxFire = SoundFusionRifleFire;
	sfxActivate = SoundFusionRifleActivate;
	sfxReload = SoundFusionRifleReload;
	sfxReady = SoundFusionRifleReady;
};

ItemData FusionRifle
{
   	heading = $InvHead[ihCyL];
	description = "Fusion Rifle";
	className = "Weapon";
   	shapeFile  = "sniper";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = FusionRifleImage;
	price = 100;
	showWeaponBar = true;
};

function FusionRifle::onMount(%player,%item,$WeaponSlot)
{
      %client = Player::getclient(%player);
      bottomprint(%client, "Fuzion Rifle: <f2>Shoots a Fast Contained Bolt Of Electricity That Burst Into Flames On Contact.", 3);
	Player::mountItem(%player,FusionScope,3);
	Player::mountItem(%player,FusionScope2,4);
}

function FusionRifle::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unmountItem(%player,3);
	Player::unmountItem(%player,4);
}

//----------------------------------------------------------------------------
ItemImageData ElectroPlasmCannon2Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData ElectroPlasmCannon2
{
	description = "ElectroPlasmCannon2";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = ElectroPlasmCannon2Image;
	showWeaponBar = false;
};

ItemImageData ElectroPlasmCannonImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.8;
	minEnergy = 1;
	maxEnergy = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.0, 5.0, 3.0 };
	sfxFire = SoundElectroPlasmCannonFire;
	sfxActivate = SoundElectroPlasmCannonActivate;
	sfxReload = SoundElectroPlasmCannonReload;
	sfxReady = SoundElectroPlasmCannonReady;
};

ItemData ElectroPlasmCannon
{
	description = "Electro-Plasm Cannon";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = $InvHead[ihCyL];
	shadowDetailMask = 4;
	imageType = ElectroPlasmCannonImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};


function ElectroPlasmCannon::onMount(%player,%item)
{
	Player::mountItem(%player,ElectroPlasmCannon2,3);
}

function ElectroPlasmCannonImage::onFire(%player, %slot)
{
	%velocity = Item::getVelocity(%player);
	%rot = GameBase::getRotation(%player);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("ElectroPlasmCannonBolt",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)-0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("ElectroPlasmCannonBolt",%transform,%player,%velocity); 
	%newRot=getWord(%rot,0) @ " " @ getWord(%rot,1) @ " " @ getWord(%rot,2)+0.1 @ " ";
	GameBase::setRotation(%player, %newrot);
	%transform = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("ElectroPlasmCannonBolt",%transform,%player,%velocity); 
	GameBase::setRotation(%player, %rot);
}

function ElectroPlasmCannon2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Plasma Cannon: <f2>Packs a Bigger Punch Than The Old Plasma Gun.", 3);
}

function ElectroPlasmCannon::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
}
//-------------------------------------------------------------------------------------------------------------
// Cybrid Medium Weapons
//-------------------------------------------------------------------------------------------------------------

ItemImageData EnergyPistol1Image 
{	shapeFile = "energygun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.2;
	projectileType = EnergyPistolBullet;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.0, 0.0, 3.0 };
	sfxFire = SoundEnergyPistolFire;
	sfxActivate = SoundEnergyPistolActivate;
	sfxReload = SoundEnergyPistolReload;
	sfxReady = SoundEnergyPistolReady;
};

ItemData EnergyPistol1
{	description = "Energy Pistols";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "disk";
	heading = $InvHead[ihCyM];
	shadowDetailMask = 4;
	imageType = EnergyPistol1Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData EnergyPistol2Image
{	shapeFile = "energygun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { -0.7, 0, 0 };
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.2;
	projectileType = EnergyPistolBullet;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.0, 0.0, 3.0 };
	sfxFire = SoundEnergyPistolFire;
	sfxActivate = SoundEnergyPistolActivate;
	sfxReload = SoundEnergyPistolReload;
	sfxReady = SoundEnergyPistolReady;
};

ItemData EnergyPistol2
{	description = "Energy Pistol";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "disk";
	heading = $InvHead[ihCyM];
	shadowDetailMask = 4;
	imageType = EnergyPistol2Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData EnergyPistolImage
{	shapeFile = "grenade";
	mountPoint = 3;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.2;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.0, 0.0, 3.0 };
	sfxFire = SoundEnergyPistolFire;
	sfxActivate = SoundEnergyPistolActivate;
	sfxReload = SoundEnergyPistolReload;
	sfxReady = SoundEnergyPistolReady;
};

ItemData EnergyPistol 
{	description = "Energy Pistols";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihCyM];
	shadowDetailMask = 4;
	imageType = EnergyPistolImage;
	price = 250;
	showWeaponBar = true;
};

function EnergyPistolImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,3);  
	%state2 = Player::getItemState(%player,4);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);     
		%num = Gamebase::getEnergy(%player);  
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);    
			Player::trigger(%player,3,true);    
			Player::trigger(%player,3,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);  
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		}  
	} 
} 

function EnergyPistol::onMount(%player,%imageSlot) 
{  
	%num = Gamebase::getEnergy(%player);  
	Player::mountItem(%player,EnergyPistol1,3);  
	Player::mountItem(%player,EnergyPistol2,4); 
} 

function EnergyPistol::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,3);  
	Player::unmountItem(%player,4); 
}
//-------------------------------------------------------------------------------------------------------------
ItemImageData TriFusionCannon3Image // Top
{
	mountOffset = { 0, 0, 0.2 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 6.30, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	shapeFile = "shotgun";
   	mountPoint = 0;

   	weaponType = 2;  // Sustained
	projectileType = TriFusionCharge1;
	minEnergy = 1;
	maxEnergy = 0.1;
	reloadTime = 0.2;
                        
   	lightType = 3;  // Weapon Fire
   	lightRadius = 2;
  	lightTime = 1;
   	lightColor = { 5, 0, 0 };

};

ItemData TriFusionCannon3
{
   	description = "Tri-Fusion Cannon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
   	className = "Weapon";
   	heading = $InvHead[ihCyM];
   	shadowDetailMask = 4;
   	imageType = TriFusionCannon3Image;
   	price = 275;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData TriFusionCannon2Image // Right
{
	mountOffset = { 0.1, 0, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.57, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right //-1.575
	shapeFile = "shotgun";
   	mountPoint = 0;

   	weaponType = 2;  // Sustained
	projectileType = TriFusionCharge3;

	reloadTime = 0.2;
        minEnergy = 1;
	maxEnergy = 0.1;             
   	lightType = 3;  // Weapon Fire
   	lightRadius = 2;
  	lightTime = 1;
   	lightColor = { 0, 5, 0 };

};

ItemData TriFusionCannon2
{
   	description = "Tri-Fusion Cannon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
   	className = "Weapon";
   	heading = $InvHead[ihCyM];
   	shadowDetailMask = 4;
   	imageType = TriFusionCannon2Image;
   	price = 275;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData TriFusionCannon1Image // Left
{
	mountOffset = { -0.1, 0, 0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.57, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right //-1.575
	shapeFile = "shotgun";
   	mountPoint = 0;

   	weaponType = 2;  // Sustained
	projectileType = TriFusionCharge2;
	minEnergy = 1;
	maxEnergy = 0.1;
	reloadTime = 0.2;
                        
   	lightType = 3;  // Weapon Fire
   	lightRadius = 2;
  	lightTime = 1;
   	lightColor = { 0, 0, 5 };

};

ItemData TriFusionCannon1
{
   	description = "Tri-Fusion Cannon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
   	className = "Weapon";
   	heading = $InvHead[ihCyM];
   	shadowDetailMask = 4;
   	imageType = TriFusionCannon1Image;
   	price = 275;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData TriFusionCannonImage
{
	shapeFile = "mortargun";
   	mountPoint = 0;
   	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
   	weaponType = 2;  // Sustained
	
	minEnergy = 1;
	maxEnergy = 0.1;
	reloadTime = 0.2;
                        

	sfxFire = SoundTriFusionCannonFire;
	sfxActivate = SoundTriFusionCannonActivate;
	sfxReload = SoundTriFusionCannonReload;
	sfxReady = SoundTriFusionCannonReady;
};

ItemData TriFusionCannon
{
   	description = "Tri-Fusion Cannon";
	shapeFile = "mortargun";
	hudIcon = "energypack";
   	className = "Weapon";
   	heading = $InvHead[ihCyM];
   	shadowDetailMask = 4;
   	imageType = TriFusionCannonImage;
	showWeaponBar = true;
   	price = 275;
};

function TriFusionCannonImage::onActivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,3,true); 
	Player::trigger(%player,4,true); 
	Player::trigger(%player,5,true); 
}

function TriFusionCannonImage::onDeactivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,3,false); 
	Player::trigger(%player,4,false); 
	Player::trigger(%player,5,false); 
}
 
function TriFusionCannon::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,TriFusionCannon1,3); 
	Player::mountItem(%player,TriFusionCannon2,4); 
	Player::mountItem(%player,TriFusionCannon3,5); 
} 

function TriFusionCannon::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,3); 
	Player::unmountItem(%player,4); 
	Player::unmountItem(%player,5); 
} 

function TriFusionCannon3::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
     	bottomprint(%client, "Tri-Fusion Cannon: <f2>An ELF Wiht Multiple Beams, Each With It's Own Function", 3);
}
//-------------------------------------------------------------------------------------------------------------
ItemImageData PulseGrenadeLauncher1Image 
{	shapeFile = "grenadel";
	mountPoint = 0;
      	mountRotation = {0, -1.5, 0}; 
      	mountOffset = {-0.1, 0, 0};
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.1;
	projectileType = PulseGrenadeShell1;
   	lightType = 3;  // Weapon Fire
   	lightRadius = 2;
  	lightTime = 1;
   	lightColor = { 0, 0, 5 };
	sfxFire = SoundPulseGrenadeLauncherFire1;
	sfxActivate = SoundPulseGrenadeLauncherActivate;
	sfxReload = SoundPulseGrenadeLauncherReload;
	sfxReady = SoundPulseGrenadeLauncherReady;
};

ItemData PulseGrenadeLauncher1
{	description = "PulseGrenadeLauncher";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "disk";
	heading = "bBullet";
	shadowDetailMask = 4;
	imageType = PulseGrenadeLauncher1Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData PulseGrenadeLauncher2Image
{	shapeFile = "grenadel";
	mountPoint = 0;
      	mountRotation = {0, 1.5, 0}; 
      	mountOffset = {0, 0, 0};
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.1;
	projectileType = PulseGrenadeShell2;
   	lightType = 3;  // Weapon Fire
   	lightRadius = 2;
  	lightTime = 1;
   	lightColor = { 0, 5, 0 };
	sfxFire = SoundPulseGrenadeLauncherFire2;
	sfxActivate = SoundPulseGrenadeLauncherActivate;
	sfxReload = SoundPulseGrenadeLauncherReload;
	sfxReady = SoundPulseGrenadeLauncherReady;
};

ItemData PulseGrenadeLauncher2
{	description = "PulseGrenadeLauncher2";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "disk";
	heading = $InvHead[ihCyM];
	shadowDetailMask = 4;
	imageType = PulseGrenadeLauncher2Image;
	price = 250;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData PulseGrenadeLauncherImage
{	shapeFile = "breath";
	mountPoint = 3;
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.3;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.1;
};

ItemData PulseGrenadeLauncher 
{	description = "Pulse Grenade Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihCyM];
	shadowDetailMask = 4;
	imageType = PulseGrenadeLauncherImage;
	price = 250;
	showWeaponBar = true;
};

function PulseGrenadeLauncherImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,3);  
	%state2 = Player::getItemState(%player,4);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);     
		%num = Gamebase::getEnergy(%player);  
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);    
			Player::trigger(%player,3,true);    
			Player::trigger(%player,3,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);  
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		}  
	} 
} 

function PulseGrenadeLauncher::onMount(%player,%imageSlot) 
{  
	%num = Gamebase::getEnergy(%player);  
	Player::mountItem(%player,PulseGrenadeLauncher1,3);  
	Player::mountItem(%player,PulseGrenadeLauncher2,4); 
} 

function PulseGrenadeLauncher::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,3);  
	Player::unmountItem(%player,4); 
}
//--------------------------------------------------------------------------------------------------------
ItemImageData ToxicThrower1Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData ToxicThrower1
{
	description = "ToxicThrower1";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = ToxicThrower1Image;
	showWeaponBar = false;
};

ItemImageData ToxicThrower2Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 3.15 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData ToxicThrower2
{
	description = "ToxicThrower2";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = ToxicThrower2Image;
	showWeaponBar = false;
};

ItemImageData ToxicThrowerImage 
{
	shapeFile = "mortar";
	mountPoint = 0;
	weaponType = 0;
	mountOffset = { 0, 0.6, 0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	projectileType = ToxicSpray;
	accuFire = false;
	minEnergy = 1;
	maxEnergy = 0.1;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxActivate = SoundToxicThrowerActivate;
	sfxReload = SoundToxicThrowerReload;
	sfxReady = SoundToxicThrowerReady;
};

ItemData ToxicThrower 
{
	description = "Toxic Sprayer";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "weapon";
	heading = $InvHead[ihCyM];
	shadowDetailMask = 4;
	imageType = ToxicThrowerImage;
	price = 175;
	showWeaponBar = true;
};

function ToxicThrower::onMount(%player,%item)
{
	Player::mountItem(%player,ToxicThrower2,3);
	Player::mountItem(%player,ToxicThrower1,4);
}

function ToxicThrower::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
	Player::unmountItem(%player,4);
}
//-------------------------------------------------------------------------------------------------------------
ItemImageData PulseRocketGun2Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0, -0.45, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData PulseRocketGun2
{
	description = "PulseRocketGun2";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = PulseRocketGun2Image;
	showWeaponBar = false;
};

ItemImageData PulseRocketGunImage 
{
   shapeFile = "mortargun";
   mountPoint = 0;
   mountOffset = { -0.03, 0.08, 0.01 }; 
   mountRotation = { 0, 1.575, 0};  
   weaponType = 0; 
   accuFire = true; 
   reloadTime = 0.9; 
   fireTime = 0.2; 
   minEnergy = 1;
   maxEnergy = 0.1;
   lightType = 3; 
   lightRadius = 3; 
   lightTime = 1; 
   lightColor = { 0, 0, 5 }; 
   sfxFire = SoundPulseRocketGunFire;
   sfxActivate = SoundPulseRocketGunActivate;
   sfxReload = SoundPulseRocketGunReload;
   sfxReady = SoundPulseRocketGunReady;
}; 

ItemData PulseRocketGun 
{ 
   description = "Pulse RocketGun"; 
   className = "Weapon"; 
   shapeFile = "sniper"; 
   hudIcon = "blaster"; 
   heading = $InvHead[ihCyM]; 
   shadowDetailMask = 4; 
   imageType = PulseRocketGunImage; 
   price = 300; 
   showWeaponBar = true; 
};

function PulseRocketGun::onMount(%player,%item)
{
	Player::mountItem(%player,PulseRocketGun2,3);
}

function PulseRocketGun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
}

function PulseRocketGun2::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Pulse RocketGun: <f2>Fires a Rocket With a Electric Pulse Seeking System.");
}

function PulseRocketGunImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,750)) 
		{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier" || %object == "Turret") 
			{ 
			PulseLockWarning(%client, $los::object, %object);
			 %newObj = Projectile::spawnProjectile("PulseSearch", %trans, %player, %vel);
			schedule("FirePulse(" @ %newObj @ ", " @ %client @ ");", 0.1, %player);
			Projectile::spawnProjectile("PulseMissile",%trans,%player,%vel,$los::object); 
		} 
		else 
		{
			%client.targetLock = 0;
			Projectile::spawnProjectile("PulseRocket",%trans,%player,%vel,%player);
			return;
		}
		
	} else {
		%client.targetLock = 0;
		Projectile::spawnProjectile("PulseRocket",%trans,%player,%vel,%player);

	}
} 

function FirePulse(%newObj, %client) {
	%player = Client::getOwnedObject(%client);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
	if(%client.targetLock) 
	{
		Projectile::spawnProjectile("PulseRocket",%trans,%player,%vel,%client.targetLock);
		
	} 
	else 
	{
				
	}
	%client.targetLock = 0;
	deleteobject(%newObj);
}

function PulseLockWarning(%clientId, %target, %targetType) 
{ 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier) 
	{
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else 
			%msg = "Vehicle"; 
	} 
	else if (%targetType == Turret) 
	{
		if(%targetName != "") 
			%msg = "Turret Deployed By" @ %name; 
		else 
			%msg = "Turret"; 
	} 
	else
		%msg = %targetName;
	Client::sendMessage(%clientId,3,"Pulse Lock Aquired: " @ %msg @ "~wmine_act.wav");
	if(%targetType == Flier || (Player::getArmor(%target)) != "") 
		{
		Client::sendMessage(%targetId,1,"!WARNING! - " @ %name @ " has a Pulse lock!~waccess_denied.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 1.0); 
	}
}
//------------------------------------------------------------------------------------------------------------
// Cybrid Heavy Weapons
//------------------------------------------------------------------------------------------------------------
ItemImageData AntimatterRocketGun1Image
{
	shapeFile = "grenAmmo";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, -0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 3.1, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AntimatterRocketGun1
{
	description = "AntimatterRocketGun1";
	className = "Weapon";
	shapeFile = "grenAmmo";
	shadowDetailMask = 4;
	imageType = AntimatterRocketGun1Image;
	showWeaponBar = false;
};

ItemImageData AntimatterRocketGun2Image
{
	shapeFile = "grenAmmo";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, -0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 3.1, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AntimatterRocketGun2
{
	description = "AntimatterRocketGun2";
	className = "Weapon";
	shapeFile = "grenAmmo";
	shadowDetailMask = 4;
	imageType = AntimatterRocketGun2Image;
	showWeaponBar = false;
};

ItemImageData AntimatterRocketGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      	mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 2;
	fireTime = 2;
   	minEnergy = 1;
   	maxEnergy = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.63, 0.0 };
   	sfxFire = SoundAntimatterRocketGunFire;
   	sfxActivate = SoundAntimatterRocketGunActivate;
   	sfxReload = SoundAntimatterRocketGunReload;
   	sfxReady = SoundAntimatterRocketGunReady;
};

ItemData AntimatterRocketGun
{
	description = "Antimatter Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
   	heading = $InvHead[ihCyH];
	shadowDetailMask = 4;
	imageType = AntimatterRocketGunImage;
	price = 275;
	showWeaponBar = true;
};

function AntimatterRocketGun::onMount(%player,%item)
{
	Player::mountItem(%player,AntimatterRocketGun1,3);
	Player::mountItem(%player,AntimatterRocketGun2,4);
}

function AntimatterRocketGun::onUnmount(%player,%imageSlot)
{ 
	Player::unmountItem(%player,3);
	Player::unmountItem(%player,4); 
}

function AntimatterRocketGunImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("AntimatterRocket",%trans,%player,%vel);
	Projectile::spawnProjectile("AntimatterRocket2",%trans,%player,%vel);
}

function AntimatterRocketGun2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      	Bottomprint(%client, "Antimatter Launcher: <f2>A Missile Of Devistating Power.", 3);
}
//------------------------------------------------------------------------------------------------------
ItemImageData IONCannonTImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, 0.3 };
	weaponType = 2; // Single Shot
	projectileType = IONLaserA;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;
	sfxActivate = SoundPickUpWeapon;
};

ItemData IONCannonT
{
	description = "IONCannon Top";
	className = "Weapon";
	shapeFile = "sniper";
   	validateShape = false;
	hudIcon = "sniper";
   	heading = $InvHead[ihCyH];
	shadowDetailMask = 4;
	imageType = IONCannonTImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData IONCannonLImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0, -2.0934, 0 };
	mountOffset = { -0.1, 0, 0.2};
	weaponType = 2; // Sustained
	projectileType = IONLaserB;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;
	sfxActivate = SoundPickUpWeapon;
};

ItemData IONCannonL
{
	description = "IONCannon Left";
	className = "Weapon";
	shapeFile = "sniper";
   	validateShape = false;
	hudIcon = "sniper";
   	heading = $InvHead[ihCyH];
	shadowDetailMask = 4;
	imageType = IONCannonLImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData IONCannonRImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0, 2.0934, 0 };
	mountOffset = { 0.1, 0, 0.2 };
	weaponType = 2; // Single Shot
	projectileType = IONLaserC;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;
	sfxActivate = SoundPickUpWeapon;
};

ItemData IONCannonR
{
	description = "IONCannon Right";
	className = "Weapon";
	shapeFile = "sniper";
   	validateShape = false;
	hudIcon = "chain";
   	heading = $InvHead[ihCyH];
	shadowDetailMask = 4;
	imageType = IONCannonRImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData IONCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.3, 0 };
	weaponType = 0; // Single or lagss!
	spinUpTime = 4.0;
	spinDownTime = 1.0;
	reloadTime = 4.0;
	fireTime = 1.0;
   	minEnergy = 1;
   	maxEnergy = 0.1;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.5;
	lightColor = { 0, 3, 0 };
	sfxActivate = SoundIONCannonnActivate;
      	sfxFire = SoundIONCannonnFire; 
      	sfxReLoad = SoundIONCannonnReload;
	sfxSpinUp = SoundIONCannonnSpin;
	sfxSpinDown = SoundIONCannonnSpin;
};

ItemData IONCannon
{
   	description = "ION Cannon";
	shapeFile = "mortargun";
	hudIcon = "reticle";
   	className = "Weapon";
   	heading = $InvHead[ihCyH];
   	shadowDetailMask = 4;
   	imageType = IONCannonImage;
	showWeaponBar = true;
   	price = 225;
};

function IONCannon::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,IONCannonT,3); 
	Player::mountItem(%player,IONCannonL,4); 
	Player::mountItem(%player,IONCannonR,5); 

	Player::trigger(%player,3,true);
	Player::trigger(%player,4,true);
	Player::trigger(%player,5,true);
}

function IONCannonImage::onFire(%this,%slot)
{
  %client = Player::getClient(%this);
  schedule("FireIONCannon("@%this@","@8@");",0.01,%this);
}

function FireIONCannon(%this,%repeat)
{
  if(%repeat == 0) return;
  %client = Player::getClient(%this);
  %trans = GameBase::getMuzzleTransform(%client);
  %vel = Item::getVelocity(%client);
  Projectile::spawnProjectile(IONBolt,%trans,%this,%vel);
  %repeat--;
  schedule("FireIONCannon("@%this@","@%repeat@");",0.12,%this);
}

function IONCannonT::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "ION Cannon: <f2>All other lasers dont compair to this wicked beast", 3);
}

function IONCannon::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,3,False);
	Player::trigger(%player,4,False);
	Player::trigger(%player,5,False);

	Player::unmountItem(%player,3); 
	Player::unmountItem(%player,4); 
	Player::unmountItem(%player,5); 
}
//------------------------------------------------------------------------------------------------------
ItemImageData PulseGauss1Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountRotation = { 0, 0, 0 };
    	mountOffset = { -0.2, -0.85, 0.4 };
};

ItemData PulseGauss1
{
	description = "PulseGauss1";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = PulseGauss1Image;
	showWeaponBar = false;
};

ItemImageData PulseGaussImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
    	mountOffset = { -0.2, -0.5, 0.4 };
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.3;
	spinDownTime = 0.2;
	fireTime = 0.1;
   	minEnergy = 1;
   	maxEnergy = 0.1;
	accuFire = False;//true

	lightType = 3;  // Weapon Fire 2//pulsing
	lightRadius = 2;
	lightTime = 2;
	lightColor = { 0.0, 0.0, 1 };

	sfxFire = SoundPulseGaussFire;
	sfxActivate = SoundPulseGaussActivate;
	sfxSpinUp = SoundPulseGaussSpin;
	sfxSpinDown = SoundPulseGaussSpin;
};

ItemData PulseGauss
{
	description = "Pulse Gauss Cannon";
	className = "Weapon";
	shapeFile = "chaingun";
   validateShape = true;
	hudIcon = "chain";
   heading = $InvHead[ihCyH];
	shadowDetailMask = 4;
	imageType = PulseGaussImage;
	price = 125;
	showWeaponBar = true;
};

function PulseGauss::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,PulseGauss1,3); 
}

function PulseGaussImage::onFire(%this) 
{
   %client = GameBase::getOwnerClient(%this);
   %trans = GameBase::getMuzzleTransform(%this);
   %vel = Item::getVelocity(%this);

		%xrnd = floor(getRandom() *10)/100 -0.05;
		%yrnd = floor(getRandom() *10)/100 -0.05;
		%zrnd = floor(getRandom() *10)/100 -0.05;
		%trans1= getWord(%trans,0);
		%trans2= getWord(%trans,1);
		%trans3= getWord(%trans,2);
		%trans4= getWord(%trans,3) + %xrnd;
		%trans5= getWord(%trans,4) + %yrnd;
		%trans6= getWord(%trans,5) + %zrnd;
		%trans7= getWord(%trans,6);
		%trans8= getWord(%trans,7);
		%trans9= getWord(%trans,8);
		%trans10=getWord(%trans,9);
		%trans11=getWord(%trans,10);
		%trans12=getWord(%trans,11);
		
		%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;

		Projectile::spawnProjectile("PulseGaussBullet", %NewTrans, %this, %vel);
}

function PulseGauss1::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "PulseGauss: <f2>All other lasers dont compair to this wicked beast", 3);
}

function PulseGauss::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,3); 
}
//------------------------------------------------------------------------------------------------------
ItemImageData ArmageddonCannon1Image
{
	shapeFile = "mine";
	mountPoint = 0; 
	mountOffset = { 0.05, 0.5, -0.1 };	
	mountRotation = {0, -1.57, 1.57};
};

ItemData ArmageddonCannon1
{
	description = "ArmageddonCannon1";
	className = "Weapon";
	shapeFile = "mine";
	shadowDetailMask = 4;
	imageType = ArmageddonCannon1Image;
	showWeaponBar = false;
};

ItemImageData ArmageddonCannonImage
{
   shapeFile = "mortargun";
   mountPoint = 0;
   mountOffset = { -0.1, -0.3, -0.1 };
   mountRotation = {0, 1.57, 0};

   weaponType = 0;  // Sustained
   reloadTime = 0;
   fireTime = 0;
   minEnergy = 1;
   maxEnergy = 0.1;         
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundArmageddonCannonActivate;
   sfxFire     = SoundArmageddonCannonCharge;
};

ItemData ArmageddonCannon
{
   description = "Armageddon Cannon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
   className = "Weapon";
   heading = $InvHead[ihCyH];
   shadowDetailMask = 4;
   imageType = ArmageddoncannonImage;
	showWeaponBar = true;
   price = 375;
   validateShape = false;
};

function ArmageddonCannon::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,ArmageddonCannon1,3); 
}

function ArmageddonCannonImage::onFire(%player,%slot)
{
	if($canFireARM[%player] == "") { $canFireARM[%player] = true; }
	
	if($canFireARM[%player])
	{
		%armor = Player::getArmor(%player);
		if(%armor == "CyHeavy") { %cMax = 200; }		
		FireARM(%player, 0, %cMax);
		$canFireARM[%player] = false;
	}
}

function FireARM(%player,%chargeRate,%cMax)
{	
	if(%chargeRate < %cMax)
	{
			%chargeRate += 1.0;
		bottomprint(player::getClient(%player), "<JC><f3> ...:::(<F1>Charging<F3>):::... <f2>"@%chargeRate@"<f1> %", 0.3);
	}
	else if(%chargeRate >= %cMax)
	{
		bottomprint(player::getClient(%player), "<JC><f3> ...:::(<F1>Charging<F3>):::... <f2>"@%cMax@"<f1> % <F3>...:::]<f1>Maximun Charge<F3>[:::...", 0.5);
		%chargeRate = %cMax;
	}
	
	if(Player::getItemState(%player,$weaponslot) != "Fire")
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%velocity = Item::getVelocity(%player);
		for(%i=0; %i < 2; %i++) 
		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			%velocity = Item::getVelocity(%player);
			if(%chargeRate < 25)
				Projectile::spawnProjectile("FusionRifleBullet",%trans,%player,%vel);
			else if(%chargeRate < 50)
				Projectile::spawnProjectile("ElectroPlasmCannonbolt",%trans,%player,%vel);
			else if(%chargeRate < 75)
				Projectile::spawnProjectile("PulseGrenadeShell1",%trans,%player,%vel);
			else if(%chargeRate < 100)
				Projectile::spawnProjectile("EnergyPistolBullet",%trans,%player,%vel);
			else if(%chargeRate < 125)
				Projectile::spawnProjectile("PulseRocket",%trans,%player,%vel);
			else if(%chargeRate < 150)
				Projectile::spawnProjectile("AntimatterRocket",%trans,%player,%vel);
			else if(%chargeRate < 199)
				Projectile::spawnProjectile("IONBolt",%trans,%player,%vel);
			else
				Projectile::spawnProjectile("ArmageddonShot",%trans,%player,%vel);
		}
		$canFireARM[%player] = true;	
	}
	else
		schedule("FireARM("@%player@","@%chargeRate@","@%cMax@");",0.04);
}

function ArmageddonCannon1::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Armageddon Cannon: <f2>This Weapon Pulls Atoms From The Air And Charges Them To There Max And Fires Them In A Hail Storm Of Fury.", 3);
}

function ArmageddonCannon::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,3); 
}
//------------------------------------------------------------------------------------------------------
ItemImageData EnergyBeamCannon1Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData EnergyBeamCannon1
{
	description = "EnergyBeamCannon1";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = EnergyBeamCannon1Image;
	showWeaponBar = false;
};

ItemImageData EnergyBeamCannon2Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { -0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData EnergyBeamCannon2
{
	description = "EnergyBeamCannon2";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = EnergyBeamCannon2Image;
	showWeaponBar = false;
};

ItemImageData EnergyBeamCannon3Image
{
	shapeFile = "mortar";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0}; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData EnergyBeamCannon3
{
	description = "EnergyBeamCannon3";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = EnergyBeamCannon3Image;
	showWeaponBar = false;
};

ItemImageData EnergyBeamCannonImage
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; 
	reloadTime = 5.0;
	fireTime = 1.0;
	accuFire = true;
	projectiletype = EnergyBeam;
   	minEnergy = 1;
   	maxEnergy = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire     = SoundEnergyBeamCannonFire;
	sfxActivate = SoundEnergyBeamCannonActivate;
        sfxReady = SoundEnergyBeamCannonIdle;
};

ItemData EnergyBeamCannon
{
	description = "Energy Beam Cannon";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "chain";
   	heading = $InvHead[ihCyH];
	shadowDetailMask = 4;
	imageType = EnergyBeamCannonImage;
	price = 0;
	showWeaponBar = true;
};

function EnergyBeamCannon::onMount(%player,%item)
{
	Player::mountItem(%player, EnergyBeamCannon1, 3);
	Player::mountItem(%player, EnergyBeamCannon2, 4);
	Player::mountItem(%player, EnergyBeamCannon3, 5);
}

function EnergyBeamCannon::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 3);
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
}

//------------------------------------------------------------------------------------------------------

ItemImageData SplitFissionGun1Image
{
	shapeFile = "plasammo";
	mountPoint = 0;
	mountOffset = { 0, -0.3, -0.11 };
	mountRotation = { 0,  1.57, 1.57}; 
};

ItemData SplitFissionGun1
{
	description = "SplitFissionGun1";
	className = "Weapon";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	imageType = SplitFissionGun1Image;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData SplitFissionGunImage
{
	shapeFile = "mortargun";
  	mountPoint = 0;
	mountOffset = { 0, 0, -0.2};
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; // Single Shot
        accuFire = true;
        reloadTime = 3;
        fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundJetHeavy;
        sfxActivate = SoundPickUpWeapon;
};

ItemData SplitFissionGun
{
	description = "Split Fission Mortar";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "fear";
   heading = $InvHead[ihCyH];
	shadowDetailMask = 4;
	imageType = SplitFissionGunImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function SplitFissionGun::onMount(%player,%item)
{
	Player::mountItem(%player, SplitFissionGun1, 3);
}

function SplitFissionGun::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 3);
}

function SplitFissionGunImage::onFire(%this,%player,%item) 
{
	%client = GameBase::getOwnerClient(%this);
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);

 		%newObj = Projectile::spawnProjectile("FissionShell", %trans, %this, %vel);
		schedule("TossFlame(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitFlame(" @ %newObj @ ", " @ %this @ ");", 2.9);
}

function SplitFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("FissionSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 8; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("FissionFire", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
		}
	deleteobject(%newObj);
	}
}
//------------------------------------------------------------------------------------------------------
ItemImageData ReverseFissionEmitter1Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountRotation = { 0, 0, 0 };
    	mountOffset = { -0.2, -0.85, 0.4 };
};

ItemData ReverseFissionEmitter1
{
	description = "Reverse Fission Emitter1";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = ReverseFissionEmitter1Image;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData ReverseFissionEmitterImage
{
	shapeFile = "mortargun";
  	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
    	mountOffset = { -0.2, -0.5, 0.4 };
	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 25.0;
	fireTime = 0.5;
	minEnergy = 1;
	maxEnergy = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
};

ItemData ReverseFissionEmitter
{
	description = "Reverse Fission Emitter";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "Mortar";
   heading = $InvHead[ihCyH];
	shadowDetailMask = 4;
	imageType = ReverseFissionEmitterImage;
	price = 0;
	showWeaponBar = true;
};

function ReverseFissionEmitter::onMount(%player,%item)
{
	Player::mountItem(%player, ReverseFissionEmitter1, 3);
}

function ReverseFissionEmitter::onUnmount(%player,%item)
{
	Player::unmountItem(%player, 3);
}

function ReverseFissionEmitterImage::onFire(%player, %slot)
{
	Weapon::onFire(%player,DisruptorBolt,False);
	Weapon::onFire(%player,DisruptorTail);
}

//------------------------------------------------------------------------------------------------------
// Hybrid Light Weapons 11:44pm Sept 04/05
//------------------------------------------------------------------------------------------------------
ItemImageData Pistol1Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Pistol1
{
	description = "Pistol1";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = Pistol1Image;
	showWeaponBar = false;
};

ItemImageData Pistol2Image
{
	shapeFile = "energygun";
	mountPoint = 0; 
	mountOffset = { 0, -0.1, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Pistol2
{
	description = "Pistol2";
	className = "Weapon";
	shapeFile = "energygun";
	shadowDetailMask = 4;
	imageType = Pistol2Image;
	showWeaponBar = false;
};

ItemImageData PistolImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single shot
	reloadTime = 0.5;
	fireTime = 0.5;
	minEnergy = 1;
	maxEnergy = 0.1;
	projectileType = PistolBullet;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData Pistol
{
	description = "50.Cal Pistol";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "sniper";
   heading = $InvHead[ihHyL];
	shadowDetailMask = 4;
	imageType = PistolImage;
	price = 0;
	showWeaponBar = true;
};

function Pistol::onMount(%player,%item)
{
	Player::mountItem(%player,Pistol1,3);
	Player::mountItem(%player,Pistol2,4);
}

function Pistol::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "Pistol: <f2>Shoots a High Cal. Armor Piercing Bullet.", 3);
}

function Pistol::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
	Player::unmountItem(%player,4);
}
//------------------------------------------------------------------------------------------------------
ItemImageData Verminator2Image
{
	shapeFile = "Sniper";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Verminator2
{
	description = "Verminator2";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = Verminator2Image;
	showWeaponBar = false;
};

ItemImageData VerminatorImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	accuFire = true;
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.3;
	spinDownTime = 0.2;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Verminator
{
	description = "Verminator";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = $InvHead[ihHyL];
	shadowDetailMask = 4;
	imageType = VerminatorImage;
	price = 0;
	showWeaponBar = true;
   validateMaterials = true;
};

function Verminator::onMount(%player,%item)
{
	Player::mountItem(%player,Verminator2,3);
}

function Verminator2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "Verminator: <f2>Like The Original ChainGun But With a Few Modifications.", 3);
}

function VerminatorImage::onFire(%this) 
{
   %client = GameBase::getOwnerClient(%this);
   %trans = GameBase::getMuzzleTransform(%this);
   %vel = Item::getVelocity(%this);

		%xrnd = floor(getRandom() *5)/100 -0.025;
		%yrnd = floor(getRandom() *5)/100 -0.025;
		%zrnd = floor(getRandom() *5)/100 -0.025;
		%trans1= getWord(%trans,0);
		%trans2= getWord(%trans,1);
		%trans3= getWord(%trans,2);
		%trans4= getWord(%trans,3) + %xrnd;
		%trans5= getWord(%trans,4) + %yrnd;
		%trans6= getWord(%trans,5) + %zrnd;
		%trans7= getWord(%trans,6);
		%trans8= getWord(%trans,7);
		%trans9= getWord(%trans,8);
		%trans10=getWord(%trans,9);
		%trans11=getWord(%trans,10);
		%trans12=getWord(%trans,11);
		
		%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;

		Projectile::spawnProjectile("VerminatorBullet", %NewTrans, %this, %vel);
}

function Verminator::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,3);  
}


//------------------------------------------------------------------------------------------------------
ItemImageData SniperRifle2Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { -0.02, -0.04, -0.02 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.57, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData SniperRifle2
{
	description = "Havoc2";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = SniperRifle2Image;
	showWeaponBar = false;
};

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0.1, -0.08 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	reloadTime = 1.5;
	fireTime = 1.5;
	minEnergy = 1;
	maxEnergy = 0.1;
	projectileType = HaVoCBullet;
	accuFire = true;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle
{
	description = "HaVoC Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = $InvHead[ihHyL];
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 200;
	showWeaponBar = true;
};


function SniperRifle2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "HaVoC Sniper Rifle: <f2>The Most Advanced Sniper rifle Ever To Exist.", 3);
}

function SniperRifle::onMount(%player,%item)
{
	Player::mountItem(%player,SniperRifle2,3);
}

function SniperRifle::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
}

//------------------------------------------------------------------------------------------------------
ItemImageData Shotgun2Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = {-0.085, 0, 0}; 
	mountRotation = {0, 1, 0}; 
};

ItemData Shotgun2
{
	description = "Shotgun2";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = Shotgun2Image;
	showWeaponBar = false;
};

ItemImageData ShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountOffset = {-0.065, 0, 0}; 
	mountRotation = {0, -1, 0}; 
	weaponType = 0; // SingleShot
	reloadTime = 0.4;
	fireTime = 0.4;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Shotgun
{
	description = "12.Gauge";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disc";
   	heading = $InvHead[ihHyL];
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	price = 0;
	showWeaponBar = true;
};

function ShotgunImage::onFire(%player,%slot)
{
	for(%i = 0; %i < 12; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ShotPellet",%trans,%player,%vel);
	}
}

function Shotgun::onMount(%player,%item)
{
	Player::mountItem(%player,Shotgun2,3);
}

function Shotgun2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "12.Gauge: <f2>A Powerful and Fast Double Barreled Killer.", 3);
}

function Shotgun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
}
//------------------------------------------------------------------------------------------------------
ItemImageData TalonRocketGunImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
      mountOffset = { 0.0, 0.0, -0.2 };
	mountRotation = { 0, 0, 0 };	
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 1;
	fireTime = 1;
	minEnergy = 1;
	maxEnergy = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.63, 0.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData TalonRocketGun
{
	description = "Talon Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
   heading = $InvHead[ihHyL];
	shadowDetailMask = 4;
	imageType = TalonRocketGunImage;
	price = 0;
	showWeaponBar = true;
};

function TalonRocketGunImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("TalonRocket1",%trans,%player,%vel);
	Projectile::spawnProjectile("TalonRocket2",%trans,%player,%vel);
}

function TalonRocketGun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Talon Rocket Launcher: <f2>A Missile Launcher for Light Hybrids Only.", 3);
}
//------------------------------------------------------------------------------------------------------
// Hybrid Medium Weapons 
//------------------------------------------------------------------------------------------------------
ItemImageData MissileLauncher2Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0.1195, 0, -0.05 };
	mountRotation = { 0, -0.5, 0 };
};

ItemData MissileLauncher2
{
	description = "MissileLauncher2";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = MissileLauncher2Image;
	showWeaponBar = false;
};


ItemImageData MissileLauncherImage 
{ 
        shapeFile = "mortargun";
        mountPoint = 0;
	mountOffset = { 0.13, 0, -0.035 };
	mountRotation = { 0, -1.48, 0 };
        weaponType = 0;
        accuFire = false;
        reloadTime = 1;
        fireTime = 1;
	minEnergy = 1;
	maxEnergy = 0.1;
        lightType = 3;
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.4, 0, 0.6 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData MissileLauncher
{ 
        description = "Missile Launcher";
        className = "Weapon";
        shapeFile = "grenadel";
        hudIcon = "plasma";
   heading = $InvHead[ihHyM];
        shadowDetailMask = 4;
        imageType = MissileLauncherImage;
        price = 0;
        showWeaponBar = true;
};

function MissileLauncher::onMount(%player,%item)
{
	Player::mountItem(%player,MissileLauncher2,3);
}

function MissileLauncher2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "MissileLauncher: <f2>A Powerful and Fast Double Barreled Killer.", 3);
}

function MissileLauncher::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
}

function MissileLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,750)) 
		{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier" || %object == "Turret") 
			{ 
			MissileLockWarning(%client, $los::object, %object);
			 %newObj = Projectile::spawnProjectile("MissileSearch", %trans, %player, %vel);
			schedule("FireMissileLauncher(" @ %newObj @ ", " @ %client @ ");", 0.1, %player);
			Projectile::spawnProjectile("MissileEMP",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("Missile",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("MissileSubmission",%trans,%player,%vel,$los::object); 
		} 
		else 
		{
			%client.targetLock = 0;
			Projectile::spawnProjectile("MissileALT",%trans,%player,%vel,%player);
			return;
		}
		
	} else {
		%client.targetLock = 0;
		Projectile::spawnProjectile("MissileALT",%trans,%player,%vel,%player);
    }
}	

function FireMissileLauncher(%newObj, %client) {
	%player = Client::getOwnedObject(%client);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
	if(%client.targetLock) 
	{
		Projectile::spawnProjectile("MissileALT",%trans,%player,%vel,%client.targetLock);
		
	} 
	else 
	{
				
	}
	%client.targetLock = 0;
	deleteobject(%newObj);
}

function MissileLockWarning(%clientId, %target, %targetType) 
{ 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier) 
	{
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else 
			%msg = "Vehicle"; 
	} 
	else if (%targetType == Turret) 
	{
		if(%targetName != "") 
			%msg = "Turret Deployed By" @ %name; 
		else 
			%msg = "Turret"; 
	} 
	else
		%msg = %targetName;
	Client::sendMessage(%clientId,3,"Missile Lock Aquired: " @ %msg @ "~wmine_act.wav");
	if(%targetType == Flier || (Player::getArmor(%target)) != "") 
		{
		Client::sendMessage(%targetId,1,"!WARNING! - " @ %name @ " has a Missile lock!~waccess_denied.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~waccess_denied.wav\");", 1.0); 
	}
}
//------------------------------------------------------------------------------------------------------
ItemImageData BlazeThrower1Image
{
	shapeFile = "plasmabolt";
	mountPoint = 0; 
   	mountOffset = { 0, 0.6, 0 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData BlazeThrower1
{
	description = "BlazeThrower1";
	className = "Weapon";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	imageType = BlazeThrower1Image;
	showWeaponBar = false;
};

ItemImageData BlazeThrowerImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, -3.08, 0 };
	weaponType = 0;
	accuFire = false;
	reloadTime = 0.01;
	fireTime = 0.01;
	minEnergy = 1;
	maxEnergy = 0.1;
	projectileType = BlazeBolt;
	lightType = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundJetLight;
	sfxActivate = SoundPickUpWeapon;
};

ItemData BlazeThrower
{
	description = "Blaze Thrower";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = $InvHead[ihHyM];
	shadowDetailMask = 4;
	imageType = BlazeThrowerImage;
	price = 0;
	showWeaponBar = true;
};

function BlazeThrower::onMount(%player,%item)
{
	Player::mountItem(%player,BlazeThrower1,3);
}

function BlazeThrower1::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Blaze Thrower: <f2>Basic Flame Thrower.", 3);
}

function BlazeThrower::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
}
//------------------------------------------------------------------------------------------------------

ItemImageData BurnerGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;
	weaponType = 0;

	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true;
	reloadTime = 0.6;
	fireTime = 0.6;
	lightType = 3;
	lightRadius = 4;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

ItemData BurnerGun
{
	description = "Burner Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
	heading = $InvHead[ihHyM];
	shadowDetailMask = 4;
	imageType = BurnerGunImage;
	price = 0;
	showWeaponBar = true;
};
	
function BurnerGun::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Burner Gun: <f2>Plasma Comes To Life.", 3);
}

function BurnerGunImage::onFire(%player, %slot) 
{		
		%vel = Item::getVelocity(%player);
		if(%vel == 0 || vector::normalize(%vel) != "-NAN -NAN -NAN")	
		{	
			%trans = GameBase::getMuzzleTransform(%player);	
		 	%proj = Projectile::spawnProjectile("Burnerbolt",%trans,%player,%vel);

		 	%vel = HybridVector::rotVector( "5 0 -5", GameBase::getRotation(%player));
		 	%proj =Projectile::spawnProjectile("Burnerbolt",%trans,%player,%vel);

		 	%vel = HybridVector::rotVector( "-5 0 -5", GameBase::getRotation(%player));
		 	%proj =Projectile::spawnProjectile("Burnerbolt",%trans,%player,%vel);

		 	%vel = HybridVector::rotVector( "0 2 5", GameBase::getRotation(%player));
		 	%proj =Projectile::spawnProjectile("Burnerbolt",%trans,%player,%vel);
			Burnerbolt::checkFire(%proj);
			$burnerOwner[%proj] = %player;
	
		}
		else 	
			echo("!! Burner Error, Burner. vel ="@%vel);			
		
	}


function Burnerbolt::checkFire(%this)
{
	%pos = GameBase::getPosition(%this);
	if(%pos != "0 0 0")
	{
		$burnerPos[%this] = %pos;
		schedule("Burnerbolt::checkFire("@%this@");",0.025);		
	}
	else
		BurnerBolt::startfire(%this);
}

function BurnerBolt::startFire(%this)
{
	%Pos = $burnerPos[%this]; 
	%player = $burnerOwner[%this]; 
	$burnerPos[%this] = false; 
	$burnerOwner[%this] = false; 
		
	%fire = newObject("", "StaticShape", BurnerFireanchor, true);
	GameBase::setPosition(%fire,%pos);
	addToSet("MissionCleanup", %fire);
	%fire.firetime = 10;	
	Burnerbolt::floatFire(%player,%fire);
}

function Burnerbolt::floatFire(%player,%fire)
{
	%Pos = GameBase::getPosition(%fire); 
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ %pos;

	Projectile::spawnProjectile("BurnerFloater", %trans, %player, "0 0 0");

	%fire.firetime--;	
	if(%fire.firetime > 0 )
		schedule("Burnerbolt::floatFire("@%player@", "@%fire@");",0.5);
	else	
		deleteobject(%fire);
	
}

StaticShapeData BurnerFireAnchor 	
{ 
	shapeFile = "breath";	//"zap";		
	maxDamage = 10000.0; 
	isTranslucent = true; 
	description = "Fiiiire!";  
	disableCollision = true;	
};
//------------------------------------------------------------------------------------------------------
ItemImageData MineLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	mountPoint = 0;
	mountRotation = { 0, 0.785, 0 };
	mountOffset = {-0.065, 0, 0.07}; 
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = false;
	reloadTime = 2;
	fireTime = 2;
	lightType = 3;
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
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHead[ihHyM];
	shadowDetailMask = 4;
        imageType = MineLauncherImage;
	price = 0;
	showWeaponBar = true;
};


function MineLauncherImage::onFire(%this) 
{
	%client = GameBase::getOwnerClient(%this);
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);

 		%newObj = Projectile::spawnProjectile("MinerShell", %trans, %this, %vel);
		schedule("SplitMines(" @ %newObj @ ", " @ %this @ ");", 2.8);
		schedule("TossMines(" @ %newObj @ ", " @ %this @ ");", 3);

}

function SplitMines(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("MinerSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossMines(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);


if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("MinerFloaters", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	%rnd = (floor(getRandom()*20)/80);
		schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
		}
	deleteobject(%newObj);
	}
}
function SetMines(%newobj,%this){

	if (GameBase::getPosition(%newObj)){
		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%Mine = newObject("","Mine","MajikMine");
		GameBase::setTeam (%Mine,GameBase::getTeam (%this));
 		addToSet("MissionCleanup", %Mine);
      	GameBase::throw(%Mine,%this,-1,true);
		GameBase::setPosition(%Mine, %pos);
		Item::setVelocity(%Mine, %vel);
	deleteobject(%newObj);
	}
}

function MineLauncher::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Mine Launcher: <f2>Set 15 Mines At The Push Of A Button.", 3);
}
//------------------------------------------------------------------------------------------------------
ItemImageData RailGunLeftImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { -0.07, 0.2, 0 };
	mountRotation = { 0, -1.57, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	fireTime = 0.075;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RailGunLeft
{
	description = "RailGun Left";
	className = "Weapon";
	shapeFile = "sniper";
   	validateShape = true;
	hudIcon = "chain";
	heading = $InvHead[ihHyM];
	shadowDetailMask = 4;
	imageType = RailGunLeftImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData RailGunRightImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0.07, 0.2, 0 };
	mountRotation = { 0, 1.57, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	fireTime = 0.075;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RailGunRight
{
	description = "RailGun Right";
	className = "Weapon";
	shapeFile = "sniper";
   	validateShape = true;
	hudIcon = "chain";
	heading = $InvHead[ihHyM];
	shadowDetailMask = 4;
	imageType = RailGunRightImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData RailGunImage
{
	shapeFile  = "discammo";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right

	weaponType = 3;
	projectileType = RailGunShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData RailGun
{
	description = "Rail Gun";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihHyM];
	shadowDetailMask = 4;
	imageType = RailGunImage;
	price = 0;
	showWeaponBar = true;
};

function RailGun::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,RailGunLeft,3); 
	Player::mountItem(%player,RailGunRight,4); 
}

function RailGunLeft::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "RailGun: <f2>Bam!.", 3);
}

function RailGun::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,3); 
	Player::unmountItem(%player,4); 
}
//------------------------------------------------------------------------------------------------------
ItemImageData GrenBarrelImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, -0.2, 0.02 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData GrenBarrel
{
	description = "Auto-Gren Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
   validateShape = true;
	hudIcon = "chain";
   heading = "cProjectile Weapons";
	shadowDetailMask = 4;
	imageType = GrenBarrelImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData AutoGrenadeGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.4;
	spinDownTime = 5;
	fireTime = 0.6;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundTeleportPower;
	sfxSpinDown = SoundTeleportPower;
};

ItemData AutoGrenadeGun
{
	description = "Auto-Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
   validateShape = true;
	hudIcon = "grenade";
	heading = $InvHead[ihHyM];
	shadowDetailMask = 4;
	imageType = AutoGrenadeGunImage;
	price = 0;
	showWeaponBar = true;
};

function AutoGrenadeGun::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,GrenBarrel,3); 
}

function GrenBarrel::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Auto-Grenade Launcher: <f2>Bam!.", 3);
}

function AutoGrenadeGunImage::onFire(%this) 
{
   %client = GameBase::getOwnerClient(%this);
   %trans = GameBase::getMuzzleTransform(%this);
   %vel = Item::getVelocity(%this);
   for(%i=0; %i < 1; %i++) 
		{
		%xrnd = floor(getRandom() *10)/100 -0.05;
		%yrnd = floor(getRandom() *10)/100 -0.05;
		%zrnd = floor(getRandom() *10)/100 -0.05;
		%trans1= getWord(%trans,0);
		%trans2= getWord(%trans,1);
		%trans3= getWord(%trans,2);
		%trans4= getWord(%trans,3) + %xrnd;
		%trans5= getWord(%trans,4) + %yrnd;
		%trans6= getWord(%trans,5) + %zrnd;
		%trans7= getWord(%trans,6);
		%trans8= getWord(%trans,7);
		%trans9= getWord(%trans,8);
		%trans10=getWord(%trans,9);
		%trans11=getWord(%trans,10);
		%trans12=getWord(%trans,11);
		
		%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;

		Projectile::spawnProjectile("AutoGrenade", %NewTrans, %this, %vel);

	}
}

function AutoGrenadeGun::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,3); 
}

//------------------------------------------------------------------------------------------------------
ItemImageData AssaultRifle2Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
   	mountOffset = { 0, 0.08, 0.1 }; //-  left-right, back-front, up-down
   	mountRotation = { 0, 22.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData AssaultRifle2
{
	description = "AssaultRifle2";
	className = "Scope";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = AssaultRifle2Image;
	price = 0;
	showWeaponBar = FALSE;
	showInventory = FALSE;
	validateShape = TRUE;
};

ItemImageData AssaultRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;
	minEnergy = 1;
	maxEnergy = 0.1;
	weaponType = 0; 
	projectileType = AssaultRifleShell;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0;

	sfxFire = ricochet3;
	sfxActivate = SoundPickUpWeapon;

};

ItemData AssaultRifle
{
	description = "M-45 Assault Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "mortar";
	heading = $InvHead[ihHyM];
	shadowDetailMask = 4;
	imageType = AssaultRifleImage;
	price = 0;
	showWeaponBar = true;
};

function AssaultRifle::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,AssaultRifle2,3); 
}

function AssaultRifle2::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      	Bottomprint(%client, "AssaultRifle: <f2>Bam!.", 3);
}

function AssaultRifle::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,3); 
}
//------------------------------------------------------------------------------------------------------
// Hybrid Heavy Weapons
//------------------------------------------------------------------------------------------------------
ItemImageData HybridLaser1Image
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { 0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData HybridLaser1
{
	description = "HybridLaser1";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = HybridLaser1Image;
	showWeaponBar = false;
};

ItemImageData HybridLaser2Image
{
	shapeFile = "sniper";
	mountPoint = 0; 
	mountOffset = { -0.1, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData HybridLaser2
{
	description = "HybridLaser2";
	className = "Weapon";
	shapeFile = "sniper";
	shadowDetailMask = 4;
	imageType = HybridLaser2Image;
	showWeaponBar = false;
};


ItemImageData HybridLaser3Image
{
	shapeFile = "GrenadeL";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0}; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData HybridLaser3
{
	description = "HybridLaser3";
	className = "Weapon";
	shapeFile = "grenadeL";
	shadowDetailMask = 4;
	imageType = HybridLaser3Image;
	showWeaponBar = false;
};

ItemImageData HybridLaserImage
{
	shapeFile = "repairgun";
	mountPoint = 0; 
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; 
	reloadTime = 1.0;
	fireTime = 0.3;
	accuFire = true;
	projectiletype = HybridLaserBeam;
	minEnergy = 50;
	maxEnergy = 2; 
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireLaser;
      	sfxreload   = SoundMortarReload;
	sfxActivate = SoundMortarTurretOff;
};

ItemData HybridLaser
{
	description = "Hybrid Laser";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "reticle";
	heading = $InvHead[ihHyH];
	shadowDetailMask = 4;
	imageType = HybridLaserImage;
	price = 0;
	showWeaponBar = true;
};

function HybridLaser1::onMount(%player,%item,$WeaponSlot)
{	
	GameBase::setRechargeRate(%player,80); 
	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Laser: <f2>A New Weapon To the Hybrid Family.The King of Lasers.", 3);
}

function HybridLaser::onMount(%player,%item)
{
	Player::mountItem(%player, HybridLaser1, 3);
	Player::mountItem(%player, HybridLaser2, 4);
	Player::mountItem(%player, HybridLaser3, 5);
}

function HybridLaser::onUnMount(%player,%item)
{
	GameBase::setRechargeRate(%player,8); 
	Player::unmountItem(%player, 3);
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
}
//------------------------------------------------------------------------------------------------------
ItemImageData HybridChainImage 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, -0.351, 0 };
	mountRotation = { 0, 3, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickupWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData HybridChain 
{	description = "Hybrid Chain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = $InvHead[ihHyH];
	shadowDetailMask = 4;
	imageType = HybridChainImage;
	price = 375;
	showWeaponBar = true;
};


ItemImageData HybridChain2Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.21, -0.351, 0 };
	mountRotation = { 0, 3, 0};
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	projectileType = HybridChainBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData HybridChain2 
{	description = "HybridChain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = HybridChain2Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData HybridChain3Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.3051, -0.201, 0.251 };
	mountRotation = { 0, 3, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	projectileType = HybridChainBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData HybridChain3 
{	description = "HybridChain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = HybridChain3Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};
ItemImageData HybridChain4Image 
{	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 };
	mountRotation = { 0, 3, 0}; 
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 0.1;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	projectileType = HybridChainBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
};

ItemData HybridChain4 
{	description = "HybridChain";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = HybridChain4Image;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

$HybridChainSlotA=3;
$HybridChainSlotB=4;
$HybridChainSlotC=5;

function HybridChain::onMount(%player,%imageSlot, %item, $WeaponSlot) 
{	
	Player::mountItem(%player,HybridChain2,$HybridChainSlotA);
	Player::mountItem(%player,HybridChain3,$HybridChainSlotB);
	Player::mountItem(%player,HybridChain4,$HybridChainSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Chaingun: <f2>Made Only For The Hybrid, For Obvious Reasons");
}

function HybridChain::onUnmount(%player,%imageSlot) 
{	
	Player::unmountItem(%player,$HybridChainSlotA);
	Player::unmountItem(%player,$HybridChainSlotB);	 
	Player::unmountItem(%player,$HybridChainSlotC);
}

function CheckHybridChain(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "HybridChain")) 
	{	Player::trigger(%player,$HybridChainSlot,true);
		schedule("CheckHybridChain(" @ %client @ "," @ %player @ ");",0.05);
		$FiringHybridChain[%client] = true;
	}
	else
	{	Player::trigger(%player,$HybridChainSlot,false);
		$FiringHybridChain[%client] = false;
	}
}

function HybridChainImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("HybridChainBullet",%trans,%player,%vel,%player);
	if(!$FiringHybridChain[%client]) 
		CheckHybridChain(%client, %player);
}

function HybridChain::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot);
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, HybridChain2, 0);
		Item::onDrop(%player,%item);
	}
}

function CheckHybridChain(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "HybridChain")) 
	{	Player::trigger(%player,$HybridChainSlotA,true);
		Player::trigger(%player,$HybridChainSlotB,true);
		Player::trigger(%player,$HybridChainSlotC,true);
		schedule("CheckHybridChain(" @ %client @ "," @ %player @ ");",0.1);
		$FiringHybridChain[%client] = true;
	}
	else 
	{	Player::trigger(%player,$HybridChainSlotA,false);
		Player::trigger(%player,$HybridChainSlotB,false);
		Player::trigger(%player,$HybridChainSlotC,false);
		$FiringHybridChain[%client] = false;
	}
}
//------------------------------------------------------------------------------------------------------
ItemImageData HybridRail2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.05, 0.05 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData HybridRail2
{
	description = "HybridRail2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = HybridRail2Image;
	showWeaponBar = false;
};

ItemImageData HybridRail3Image
{
	shapeFile = "energygun";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 22.0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData HybridRail3
{
	description = "HybridRail3";
	className = "Weapon";
	shapeFile = "energygun";
	shadowDetailMask = 4;
	imageType = HybridRail3Image;
	showWeaponBar = false;
};

ItemImageData HybridRailImage
{
	shapeFile = "sniper";
	mountPoint = 0;
        mountOffset = { 0, 0.0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0;
	projectileType = HybridRailBullet;
	accuFire = true;
	reloadTime = 3.0;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0.0, 1.25, 1.25 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HybridRail
{
	description = "Hybrid RailGun";
	className = "Weapon";
	shapeFile = "sniper";
	validateShape = true;
	hudIcon = "sniper";
	heading = $InvHead[ihHyH];
	shadowDetailMask = 4;
	imageType = HybridRailImage;
	price = 0;
	showWeaponBar = true;
};

function HybridRail::onUse(%player,%item)
{
        Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>High Cal. Rifle", 2);
}

function HybridRail::onMount(%player,%item)
{
	Player::mountItem(%player,HybridRail2,3);
	Player::mountItem(%player,HybridRail3,4);
}

function HybridRail::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
	Player::unmountItem(%player,4);
}
//------------------------------------------------------------------------------------------------------
ItemImageData HybridCannonTImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, 0.2 };
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HybridCannonT
{
	description = "Hybrid Cannon Top";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HybridCannonTImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HybridCannonLImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	mountRotation = { 0, -2.0934, 0 };
	mountOffset = { -0.1, 0, 0.05};
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HybridCannonL
{
	description = "Hybrid Cannon Left";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HybridCannonLImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HybridCannonRImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	mountRotation = { 0, 2.0934, 0 };
	mountOffset = { 0.1, 0, 0.05 };
	weaponType = 2; // Sustained
	minEnergy = 0.5;
	maxEnergy = 0.01;
	reloadTime = 1.0;
	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData HybridCannonR
{
	description = "Hybrid Cannon Right";
	className = "Weapon";
	shapeFile = "sniper";
   validateShape = false;
	hudIcon = "chain";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HybridCannonRImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HybridCannonImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	minEnergy = 1;
	maxEnergy = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundEnergyTurretTurn;
	sfxReady = SoundBeaconActive;
};

ItemData HybridCannon 
{	description = "Hybrid Blast Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
  	heading = $InvHead[ihHyH];
	shadowDetailMask = 4;
	imageType = HybridCannonImage; 
	price = 0;
	showWeaponBar = true;
};

function HybridCannon::onMount(%player,%item)
{
	Player::mountItem(%player,HybridCannonR,3);
	Player::mountItem(%player,HybridCannonL,4);
	Player::mountItem(%player,HybridCannonT,5);
}

function HybridCannon::onUnMount(%player,%item)
{
	Player::unmountItem(%player,3);
	Player::unmountItem(%player,4);
	Player::unmountItem(%player,5);
}

function HybridCannonT::onMount(%player,%item,$WeaponSlot)
{	
	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Cannon: <f2>A very Deadly Hybrid Weapon,Only a Hybrid could Handle This Much Power." ,3);
}
function HybridCannonImage::onFire(%player,%slot) 
{	
	%armor = Player::getArmor(%player);
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
		PlaySound(SoundFireFlierRocket, GameBase::getPosition(%player));
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
                Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);
		Projectile::spawnProjectile("HybridCannonShot",%trans,%player,%vel);

}
//------------------------------------------------------------------------------------------------------
ItemImageData HybridPlasma1Image 
{	
	shapeFile  = "mortargun";
	mountPoint = 0;
	mountOffset = { -0.02, 0, 0 };
	mountRotation = { 0, -1.57, 0 };
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.2;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.1;
	projectileType = HybridPlasmaBolt;
   	lightType = 3;  // Weapon Fire
   	lightRadius = 2;
  	lightTime = 1;
   	lightColor = { 0, 0, 5 };
	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundPickUpWeapon;
};

ItemData HybridPlasma1
{	description = "HybridPlasma";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "disk";
	heading = "bBullet";
	shadowDetailMask = 4;
	imageType = HybridPlasma1Image;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HybridPlasma2Image
{	
	shapeFile  = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.02, 0, 0 };
	mountRotation = { 0, 1.57, 0 };
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.2;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.1;
	projectileType = HybridPlasmaBolt;
   	lightType = 3;  // Weapon Fire
   	lightRadius = 2;
  	lightTime = 1;
   	lightColor = { 0, 5, 0 };
	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundPickUpWeapon;
};

ItemData HybridPlasma2
{	description = "HybridPlasma2";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "disk";
	heading = $InvHead[ihHyH];
	shadowDetailMask = 4;
	imageType = HybridPlasma2Image;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HybridPlasmaImage
{	shapeFile = "grenammo";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.05 };
	weaponType = 3;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.2;
	minEnergy = 1;
	maxEnergy = 0.1;
	spinUpTime = 0.1;
};

ItemData HybridPlasma 
{	description = "HybridPlasma Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
	heading = $InvHead[ihHyH];
	shadowDetailMask = 4;
	imageType = HybridPlasmaImage;
	price = 0;
	showWeaponBar = true;
};

function HybridPlasmaImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,3);  
	%state2 = Player::getItemState(%player,4);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);     
		%num = Gamebase::getEnergy(%player);  
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);    
			Player::trigger(%player,3,true);    
			Player::trigger(%player,3,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);  
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		}  
	} 
} 

function HybridPlasma::onMount(%player,%imageSlot) 
{  
	%num = Gamebase::getEnergy(%player);  
	Player::mountItem(%player,HybridPlasma1,3);  
	Player::mountItem(%player,HybridPlasma2,4); 
} 

function HybridPlasma::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,3);  
	Player::unmountItem(%player,4); 
}
//------------------------------------------------------------------------------------------------------
ItemImageData HybridMortar1Image 
{ 
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -0.1, -0.7, 0.5 };
	mountRotation = { 0, 7, 0 };
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	minEnergy = 1;
	maxEnergy = 0.1;
	fireTime = 0.3;
	projectileType = HybridMortarShell; 
}; 

ItemData HybridMortar1 
{ 
	description = "HybridMortar";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = $InvHead[ihWea];
	shadowDetailMask = 4; 
	imageType = HybridMortar1Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData HybridMortar2Image 
{
	 shapeFile = "mortargun"; 
	mountPoint = 0;
      mountOffset = { -1.1, -0.7, 0.5 };
	mountRotation = { 0, -7, 0 };
	minEnergy = 1;
	maxEnergy = 0.1;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0.0;
	fireTime = 0.3;
	projectileType = HybridMortarShell; 
}; 

ItemData HybridMortar2 
{ 
	description = "HybridMortar";
	 className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = $InvHead[ihHyH];
	shadowDetailMask = 4; 
	imageType = HybridMortar2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData HybridMortarImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 3; 
	weaponType = 0; 
	reloadTime = 0.0;
	minEnergy = 1;
	maxEnergy = 0.1;
	fireTime = 0.3;
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;

}; 

ItemData HybridMortar
{ 
	description = "Hybrid Dual Mortar"; 
	className = "Weapon"; 
	shapeFile = "sniper"; 
	hudIcon = "mortar"; 
     heading = $InvHead[ihHyH];
	shadowDetailMask = 4; 
	imageType = HybridMortarImage; 
	price = 0; 
	showWeaponBar = true;
}; 

function HybridMortarImage::onFire(%player, %slot) 
{  
	%state1 = Player::getItemState(%player,3);  
	%state2 = Player::getItemState(%player,4);  
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);     
		%num = Gamebase::getEnergy(%player);  
		if(%client.hd == 0) 
		{    
			%client.hd = 1;    
			if(%num == 1)     
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);    
			Player::trigger(%player,3,true);    
			Player::trigger(%player,3,false);   
		} 
		else 
		{    
			%client.hd = 0;    
			if(%num == 1)     
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);  
			Player::trigger(%player,4,true);    
			Player::trigger(%player,4,false);   
		}  
	} 
} 

function HybridMortar::onMount(%player,%imageSlot) 
{  
	%num = Gamebase::getEnergy(%player);  
	Player::mountItem(%player,HybridMortar1,3);  
	Player::mountItem(%player,HybridMortar2,4); 
} 

function HybridMortar::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,3);  
	Player::unmountItem(%player,4); 
}
//------------------------------------------------------------------------------------------------------
$HybridRocketLauncherSlotA=3;
$HybridRocketLauncherSlotB=4;
$HybridRocketLauncherSlotC=5; 

ItemImageData HybridRocketLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData HybridRocketLauncher 
{	description = "Hybrid Twin Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	hudIcon = "ammopack"; 
	heading = $InvHead[ihHyH];
	shadowDetailMask = 4; 
	imageType = HybridRocketLauncherImage; 
	price = 1500; 
	showWeaponBar = true; 
}; 

ItemImageData HybridRocketLauncher2Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
};	

ItemData HybridRocketLauncher2 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridRocketLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData HybridRocketLauncher3Image 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
}; 

ItemData HybridRocketLauncher3 
{	description = "Hybrid Dual Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridRocketLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData HybridRocketLauncher4Image 
{	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 };
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
}; 

ItemData HybridRocketLauncher4 
{	description = "Hybrid Twin Missile"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridRocketLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

//  Begin HybridRocketLauncher New Fire Function By: Armagedon
                     
function HybridRocketLauncherImage::onFire(%player, %slot) 
{	
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		
		// ------- Second Projectile Placement --------
		
		%pos=gamebase::getposition(%player);
		%rot=gamebase::getrotation(%player);
		%vec=Vector::getFromRot(%rot);
		
		%vec1=getWord(%vec,0);
		%vec2=getWord(%vec,1);
		
		%pos1=getWord(%trans,0);
		%pos2=getWord(%trans,1);
		%pos3=getWord(%trans,2);
		%pos4=getWord(%trans,3);
		%pos5=getWord(%trans,4);
		%pos6=getWord(%trans,5);
		%pos7=getWord(%trans,6);
		%pos8=getWord(%trans,7);
		%pos9=getWord(%trans,8);
		%pos10=getWord(%trans,9) + %vec2;
		%pos11=getWord(%trans,10) - %vec1;
		%pos12=getWord(%trans,11);
		
		%trans2=%pos1@" "@%pos2@" "@%pos3@" "@%pos4@" "@%pos5@" "@%pos6@" "@%pos7@" "@%pos8@" "@%pos9@" "@%pos10@" "@%pos11@" "@%pos12;
		
		// ----- End of Second Projectile Placement -----
		
		if(GameBase::getLOSInfo(%player,1500))
		{	
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Projectile::spawnProjectile("HybridMissile",%trans,%player,%vel,$los::object);
				Projectile::spawnProjectile("HybridMissile",%trans2,%player,%vel,$los::object);
				Client::sendMessage(%client,3,"Missile lock acquired - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"!*!*!WARNING!*!*! Missile lock detected - " @ %clientId @ "~waccess_denied.wav");
				if(!$FiringHybridRocketLauncher[%client]) 
					CheckHybridRocketLauncher(%client, %player);
			}
			else
			{
				Projectile::spawnProjectile("HybridRocket",%trans,%player,%vel,%target);
				Projectile::spawnProjectile("HybridRocket",%trans2,%player,%vel,%target);
				if(!$FiringHybridRocketLauncher[%client]) 
					CheckHybridRocketLauncher(%client, %player); 
			}
		}
		else
		{
			Projectile::spawnProjectile("HybridRocket",%trans,%player,%vel,%target);
			Projectile::spawnProjectile("HybridRocket",%trans2,%player,%vel,%target);
			if(!$FiringHybridRocketLauncher[%client]) 
				CheckHybridRocketLauncher(%client, %player); 
		}
}

function HybridRocketLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, HybridRocketLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function HybridRocketLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,HybridRocketLauncher2,$HybridRocketLauncherSlotA); 
	Player::mountItem(%player,HybridRocketLauncher3,$HybridRocketLauncherSlotB); 
	Player::mountItem(%player,HybridRocketLauncher4,$HybridRocketLauncherSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Twin Launcher: <f2>This Dual Launcher Also Has a Heat Sink Device For Added Destruction." ,3);  
}

function HybridRocketLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$HybridRocketLauncherSlotA);
	Player::unmountItem(%player,$HybridRocketLauncherSlotB);	 
	Player::unmountItem(%player,$HybridRocketLauncherSlotC);
}

function CheckHybridRocketLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "HybridRocketLauncher")) 
	{	Player::trigger(%player,$HybridRocketLauncherSlotA,true);
		Player::trigger(%player,$HybridRocketLauncherSlotB,true);
		Player::trigger(%player,$HybridRocketLauncherSlotC,true);
		schedule("CheckHybridRocketLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringHybridRocketLauncher[%client] = true;
	} 
	else 
	{	Player::trigger(%player,$HybridRocketLauncherSlotA,false); 
		Player::trigger(%player,$HybridRocketLauncherSlotB,false); 
		Player::trigger(%player,$HybridRocketLauncherSlotC,false); 
		$FiringHybridRocketLauncher[%client] = false; 
	} 
}
//------------------------------------------------------------------------------------------------------

ItemImageData HybridQuadLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData HybridQuadLauncher 
{	description = "Hybrid Quad RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, 1.1, 0}; 
	hudIcon = "ammopack"; 
	heading = $InvHead[ihHyH];
	shadowDetailMask = 4; 
	imageType = HybridQuadLauncherImage; 
	price = 0; 
	showWeaponBar = true; 
};

ItemImageData HybridQuadLauncher2Image 
{
	projectileType = HybridRPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0}; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	minEnergy = 1;
	maxEnergy = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData HybridQuadLauncher2 
{	description = "Hybrid RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridQuadLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData HybridQuadLauncher3Image 
{	
	projectileType = HybridRPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0;
	minEnergy = 1;
	maxEnergy = 0.1;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData HybridQuadLauncher3 
{	description = "Hybrid RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridQuadLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData HybridQuadLauncher4Image 
{	
	projectileType = HybridRPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, 1.50, 0}; 
	weaponType = 0; 
	reloadTime = 2.0; 
	minEnergy = 1;
	maxEnergy = 0.1;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData HybridQuadLauncher4 
{	description = "Hybrid RPG"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "ammopack"; 
	shadowDetailMask = 4; 
	imageType = HybridQuadLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$HybridQuadSlotA=3;
$HybridQuadSlotB=4;
$HybridQuadSlotC=5;

function HybridQuadLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player,HybridQuadLauncher2,$HybridQuadSlotA); 
	Player::mountItem(%player,HybridQuadLauncher3,$HybridQuadSlotB); 
	Player::mountItem(%player,HybridQuadLauncher4,$HybridQuadSlotC);
	%client = Player::getclient(%player);
	bottomprint(%client, "Hybrid Quad RPG: <f2>Launches 4 RPG Missiles At One Time, Mass Destruction With Some Flare.");
}

function HybridQuadLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$HybridQuadSlotA);
	Player::unmountItem(%player,$HybridQuadSlotB);	 
	Player::unmountItem(%player,$HybridQuadSlotC);
}

function HybridQuadLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("HybridRPG",%trans,%player,%vel,%player); 
	if(!$FiringHybridQuadLauncher[%client]) 
		CheckHybridQuadLauncher(%client, %player); 
}

function HybridQuadLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, HybridQuadLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckHybridQuadLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "HybridQuadLauncher")) 
	{	Player::trigger(%player,$HybridQuadSlotA,true);
		Player::trigger(%player,$HybridQuadSlotB,true);
		Player::trigger(%player,$HybridQuadSlotC,true); 
		schedule("CheckHybridQuadLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringHybridQuadLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$HybridQuadSlotA,false); 
		Player::trigger(%player,$HybridQuadSlotB,false); 
		Player::trigger(%player,$HybridQuadSlotC,false); 
		$FiringHybridQuadLauncher[%client] = false; 
	} 
}
//------------------------------------------------------------------------------------------------------

ItemImageData HybridNukeCoreImage
{
	shapeFile = "plasammo";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.22 };
	mountRotation = { 0,  1.57, 1.57}; 
};

ItemData HybridNukeCore
{
	description = "HybridNuke Core";
	className = "Weapon";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	imageType = HybridNukeCoreImage;
	showWeaponBar = false;
	showInventory = false;
};


ItemImageData HybridNukeImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
        mountOffset = { 0, 0, -0.2};
	weaponType = 0; // Single Shot
	accuFire = true;
	reloadTime = 5;
	fireTime = 5;
	minEnergy = 1;
	maxEnergy = 0.1;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = bigExplosion1;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundMortarIdle;
	sfxReload = SoundMortarReload;
	
};

ItemData HybridNuke
{
	description = "Hybrid Thermal Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = $InvHead[ihHyH];
	shadowDetailMask = 4;
	imageType = HybridNukeImage;
	price = 0;
	showWeaponBar = true;
};

function HybridNukeCore::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      Bottomprint(%client, "Hybrid Thermal Launcher: <f2>Harness The Power Of The Atom and Use It To Obliterate Your Enemies.", 3);
}

function HybridNuke::onMount(%player,%item)
{
	Player::mountItem(%player, HybridNukeCore, 3);
}

function HybridNuke::onUnmount(%player,%item)
{
	Player::unmountItem(%player, 3);
}

function HybridNukeImage::onFire(%player, %slot) 
{

		 %client = GameBase::getOwnerClient(%player);
		 %trans = GameBase::getMuzzleTransform(%player);
	     	%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("AtomBomb",%trans,%player,%vel);
}
//END---------------------------------------------------------------------------------------------------

ItemImageData RepCannonTImage
{
   shapeFile  = "repairgun";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.065 };
	mountRotation = { 0, 3.14, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	fireTime = 0.075;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepCannonT
{
	description = "RepairCannon Top";
	className = "Weapon";
	shapeFile = "repairgun";
   validateShape = true;
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = RepCannonTImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData RepCannonRImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { 0.075, 0, 0.065 };
	mountRotation = { 0, 1.047, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	fireTime = 0.075;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepCannonR
{
	description = "RepairCannon Right";
	className = "Weapon";
	shapeFile = "repairgun";
   validateShape = true;
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = RepCannonRImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData RepCannonLImage
{
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { -0.075, 0, 0.065 };
	mountRotation = { 0, -1.047, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	fireTime = 0.075;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepCannonL
{
	description = "RepairCannon Left";
	className = "Weapon";
	shapeFile = "repairgun";
   validateShape = true;
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = RepCannonLImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData RepairGunImage
{
	shapeFile = "shotgunbolt";
	mountPoint = 0;
	mountOffset = { 0, 0.05, 0 };

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
	price = 0;
   validateShape = true;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,RepCannonT,3); 
	Player::mountItem(%player,RepCannonR,4); 
	Player::mountItem(%player,RepCannonL,5); 
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,3); 
	Player::unmountItem(%player,4); 
	Player::unmountItem(%player,5); 
	Player::trigger(%player,$BackpackSlot,false);
}


//----------------------------------------------------------------------------
// Backpacks
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
///////////////////////////////////////////////////
// Talon Packs                                  //
// Nitrogen JetPack - Armageddon 03 5th Element//
////////////////////////////////////////////////
ItemImageData HeatSinkPackImage 
{
	shapeFile = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = {0, -0.1, 0.15};
	mountRotation = {0, 3.14159, 0};
	minEnergy = -1;
	maxEnergy = -3;
	firstPerson = false;
};

ItemData HeatSinkPack 
{
	description = "Nitrogen Jetpack";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = $InvHead[ihHLB];
	shadowDetailMask = 4;
	imageType = HeatSinkPackImage;
	price = 250;
	hudIcon = "targetlaser";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HeatSinkPack::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
	Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function HeatSinkPack::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Nitrogen Jetpack will mask your heat signature making you invisible to Anti-Aricraft Guns and Missile Turrets.");
	Player::trigger(%player,$BackpackSlot,true);
}
///////////////////////////////////////////////////
// Talon Packs                                  //
// Jammer Pack - Dynamix Sensor Jammer         //
////////////////////////////////////////////////
ItemImageData JammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 18;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
	mountOffset = {0, -0.1, 0.15};
	mountRotation = {0, 3.14159, 0};
	firstPerson = false;
};

ItemData JammerPack
{
	description = "Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   	heading = $InvHead[ihHLB];
	shadowDetailMask = 4;
	imageType = JammerPackImage;
	price = 0;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   	validateShape = true;
   	validateMaterials = true;
};

function JammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jammer On");
	%rate = Player::getSensorSupression(%player) + 25;
	Player::setSensorSupression(%player,%rate);
}

function JammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jammer Off");
	%rate = Player::getSensorSupression(%player) - 25;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

function JammerPack::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Jammer Pack Will Jam All Turrets Signals.");
}
///////////////////////////////////////////////////
// Talon Packs                                  //
// Medic Pack - Armageddon 05 +Cybrid+ 2K5     //
////////////////////////////////////////////////
ItemImageData MedicPackImage
{
	shapeFile = "armorpack";
	mountPoint = 2;
	mountOffset = {0, -0.1, 0.15};
	mountRotation = {0, 3.14159, 0};
	firstPerson = false;
};

ItemData MedicPack
{
	description = "Medic Pack";
	shapeFile = "armorpack";
	className = "Backpack";
	heading = $InvHead[ihHLB];
	imageType = MedicPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MedicPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else {
		// Get user's energy
		%energy = GameBase::getEnergy(%player);

		// If enough energy,
		%required = 125;
		if (%energy >= %required) {

			// Subtract energy
			GameBase::setEnergy(%player, %energy - %required);

			// Create repair kit
			%obj = newObject("", "Item", "RepairKit", 1, false);
 	 	 	addToSet("MissionCleanup", %obj);

			// Throw repair kit
			GameBase::throw(%obj, %player, 10, false);

			// Play sound
			GameBase::playSound(%player, SoundPickupBackpack, 3);
		}
	}
}

function MedicPack::onMount(%player, %item) 
{
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Medic Pack creates Repair Kits when used.");
}
///////////////////////////////////////////////////
// Talon Packs                                  //
// Tick Pack - TartLoaf 03 MadMax Mod          //
////////////////////////////////////////////////
StaticShapeData tickWall
{
   shapeFile = "flagstand";
	debrisId = flashDebrisLarge;
	explosionId = flashExpLarge;
   maxDamage = 10000.0;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
};

ItemImageData tickPackImage
{	
	shapeFile = "mine";
	mountPoint = 2;
	mountOffset = { 0, 0.2, 0 };
	mountRotation = { 1.57, 0, 0 };
	weaponType = 2;  // Sustained
	maxEnergy = -1;
	minEnergy = -2;
	sfxFire = SoundShieldOn;
	mass = 2.5;
	firstPerson = false;
};

ItemData tickPack
{	
	description = "Tick Pack";
	shapeFile = "mine";
	className = "Backpack";
	heading = $InvHead[ihHLB];
	imageType = tickPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 1500;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};
function PLSendMsg(%player,%chan,%message)
{
	Client::sendMessage(Player::getClient(%player),%chan,%message);
}
function tickPackImage::onActivate(%player,%imageSlot)
{
	
	if(Item::getVelocity(%player) != "0 0 0")
	{
		PLSendMsg(%player,1,"You must be completely still to use the Tick Pack!~wError_message.wav");
		return;	
	}
	tickPack2::Tick(%player);
	player::trigger(%player,$backpackslot,true);
	%player.shieldstrength = 0.04;
}
function tickPackImage::onDeactivate(%player,%imageSlot)
{
	killTick(Player::getClient(%player));
	player::trigger(%player,$backpackslot,false);
	%pos = GameBase::getPosition(%player);
	GameBase::setPosition(%player,Vector::add(%pos,"0 0 1.45"));
	%player.shieldstrength = 0;
}

function TickSimSet(%client)
{
	%teleset = nameToID("MissionCleanup/tick_" @ %client);
	if(%teleset == -1)
	{	newObject("tick_" @ %client,SimSet);
		addToSet("MissionCleanup","tick_" @ %client);
	}
	else
		killTick(%client);
}
function killTick(%client)
{
	//%set1 = nameToID("MissionCleanup/tick_" @ %client);
	//%x =  0; // for alt method
	for(%x=0; %x<6; %x++) 	
	{
		echo($Tick[%client,%x]);	
		deleteObject($Tick[%client,%x]);
	}
	//deleteObject(%set1);
}
function tickPack::Tick(%player)
{// alternate method of tick
		%pos = GameBase::getPosition(%player);
		%off = "0 0 -1.45";
		GameBase::setPosition(%player,Vector::add(%pos,%off));	
		%pos = GameBase::getPosition(%player);
		$tickpos[%player] = %pos;
		%client = Player::getClient(%player);
		%off = "0 0 -0.1";
		%rot = "3.14 0 0";
		$Tick[%client,0] = newObject("tickWall","StaticShape",tickWall,true);
		%obj = $Tick[%client,0];
		GameBase::setRotation(%obj,%rot);
		GameBase::setPosition(%obj,Vector::add(%pos,%off));
		addToSet("MissionCleanup", %obj);	
		stayTicked(%player);
}
function stayTicked(%player)
{// alternate func 2
	%client = Player::getClient(%player);
	if(!isObject($Tick[%client,0])) return;
	if($tickpos[%player] != GameBase::getPosition(%player))
		GameBase::setPosition(%player,$tickpos[%player]);
	
	schedule("stayTicked("@%player@");",0.5,%player);
	
}
function tickPack2::Tick(%player)
{// original idea; caused crashing, but "cooler".
		echo("Tickin" @ %player);
		%client = Player::getClient(%player);
		//TickSimSet(%client);
		
		%pos = GameBase::getPosition(%player);
		%off = "0 0 -1.45";
		GameBase::setPosition(%player,Vector::add(%pos,%off));
		%pos = GameBase::getPosition(%player);
		$tickpos[%player] = %pos;
		%off = "0 0 -0.1";
		%rot = "3.14 0 0";
		$Tick[%client,0] = newObject("tickWall","StaticShape",tickWall,true);
		%obj = $Tick[%client,0];
		GameBase::setRotation(%obj,%rot);
		GameBase::setPosition(%obj,Vector::add(%pos,%off));
		addToSet("MissionCleanup", %obj);
		
		%off = "1 0 0.5";
		%rot = "1.57 1.57 0";
		$Tick[%client,1] = newObject("tickWall","StaticShape",tickWall,true);
		%obj = $Tick[%client,1];
		GameBase::setRotation(%obj,%rot);
		GameBase::setPosition(%obj,Vector::add(%pos,%off));
		addToSet("MissionCleanup", %obj);
		
		%off = "-1 0 0.5";
		%rot = "1.57 1.57 0";
		$Tick[%client,2] = newObject("tickWall","StaticShape",tickWall,true);
		%obj = $Tick[%client,2];
		GameBase::setRotation(%obj,%rot);
		GameBase::setPosition(%obj,Vector::add(%pos,%off));
		addToSet("MissionCleanup", %obj);
		
		%off = "0 1 0.5";
		%rot = "1.57 0 0";
		$Tick[%client,3] = newObject("tickWall","StaticShape",tickWall,true);
		%obj = $Tick[%client,3];
		GameBase::setRotation(%obj,%rot);
		GameBase::setPosition(%obj,Vector::add(%pos,%off));
		addToSet("MissionCleanup", %obj);
		
		%off = "0 -1 0.5";
		%rot = "1.57 0 0";
		$Tick[%client,4] = newObject("tickWall","StaticShape",tickWall,true);
		%obj = $Tick[%client,4];
		GameBase::setRotation(%obj,%rot);
		GameBase::setPosition(%obj,Vector::add(%pos,%off));
		addToSet("MissionCleanup", %obj);
		
		%off = "0 0 2.5";
		%rot = "0 0 0";
		$Tick[%client,5] = newObject("tickWall","StaticShape",tickWall,true);
		%obj = $Tick[%client,5];
		GameBase::setRotation(%obj,%rot);
		GameBase::setPosition(%obj,Vector::add(%pos,%off));
		addToSet("MissionCleanup", %obj);
		
		stayTicked(%player);
}

function TickPack::onMount(%player, %item) 
{
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Tick Pack Allows You To Dig In A Snipers Trench.");
}

///////////////////////////////////////////////////
// Preadtor Packs                               //
// FlightPack - Armageddon&Worstaim 04 SeX.NC17//
////////////////////////////////////////////////
ItemImageData FlightPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = {0, -0.1, 0.15};
	mountRotation = {0, 3.14159, 0};

	minEnergy = -3;
 	maxEnergy = -10;
	firstPerson = false;
};

ItemData FlightPack
{
	description = "Flight Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = $InvHead[ihHMB];
	shadowDetailMask = 4;
	imageType = FlightPackImage;
	price = 0;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = false;
};
 

function FlightPack::onUse(%player,%item)
{
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
 {
     Player::mountItem(%player,%item,$BackpackSlot);
 }
 Player::trigger(%player,$BackpackSlot,true);
 echo("Using");
 echo("Energy/Boost Pack By: Armageddon, little tweaking by Aim, but 99 percent by Arm");
 echo("WorstAim WuZ HeRe At [9:58 PM]-5/09/04"); 
 echo("WorstAim is my hero- Armageddon [10:17 PM]-5/09/04");
 FlightPackImage::onActivate(%player, %imageSlot);
}
 
function FlightPack::onMount(%player,%item)
{
  Player::trigger(%player,$BackpackSlot,false);
  Player::trigger(%player,%item,false);
  $BoostUsed[%player] = false;
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Flight Pack Allows You To Use A Boost Cell Every 10 Seconds To Maximize Flight.");
}
 
function FlightPack::onUnmount(%player,%item)
{
  RemoteNextWeapon(Player::getClient(%player));
}

function FlightPackImage::onActivate(%player, %imageSlot)
{
 	//echo("Activated");
        //********Created A New Conditional Statement You Can Only Boost If $BoostUsed = true; Defined $BoostUsed as False in EnergyPack::onMount Because Otherwise The $BoostUsed Isn't "run" By Tribes
        //********Also Moved The schedule BoostWaitTime and %time To The Conditional To Prevent BoostCell Loaded Msg's From Appearing When They Arn't Supposed To  -Aim
	if(!$BoostUsed[%player])
	{
		//echo("Calling Boost");
 		FlightPack::Boost(%player);
		%time = 10; //45 30
		schedule("BoostWaitTime(" @ %time @ ", " @ %player @ ");", 1, %player);
		Booster::smoke(%player);
		$BoostUsed[%player] = true;
		%player.Boostfire = 50;
	}
        GameBase::playSound(%player, SoundFireWooHoo, 0);
}
 
 

function FlightPack::Boost(%player)
{
 echo("BOOST");
 %forwardVelocity = 400;//300
 %verticalVelocity = 15;//10
 %vector = Vector::getFromRot(GameBase::getRotation(%player), %forwardVelocity, %verticalVelocity);
 Player::applyImpulse(%player, %vector);
}
 
function Booster::smoke(%player)
{
 if(Player::isDead(%player)) return;
 %player.Boostfire = %player.Boostfire -1;
 %trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
 %vel = Item::getVelocity(%player);
 if(vector::getdistance(%vel,"0 0 0") > 10)
  Projectile::spawnProjectile("BoostSmoke", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
 if(%player.Boostfire > 1)
  schedule("Booster::smoke("@%player@");",0.05); 
 
}
 
function FlightPackImage::onDeactivate(%player, %imageSlot)
{
//
}
//BoostWait, Timed crap
function BoostWaitTime(%time, %player)
{
  //echo("Called BoostWait");
 if(%time > 0)
 {
  	schedule("BoostWaitTime( " @ %time - 1 @ ", " @ %player @ ");", 1, %player);
 }
 else if(%time == 0)
 {
     	BoostReset(%player);
 }
}
//Boost recharge
function BoostReset(%player)
{
 $BoostUsed[%player] = false;
 Client::sendMessage(Player::getClient(%player),3,":Flight Pack • Boost Cell Loaded:~wmale2.wcheer2.wav");
}
////////////////////////////////////////////////////
// Preadtor Packs                                //
// StealthPack Various Creators 98-05 Armageddon//
/////////////////////////////////////////////////
ItemImageData StealthPackImage 
{
  shapeFile = "shieldPack";
  mountPoint = 2;
  weaponType = 2;
  minEnergy = 6;
  maxEnergy = 9;
  sfxFire = SoundShieldOn;
  firstPerson = false;
};

ItemData StealthPack 
{
  description = "Stealth Pack";
  shapeFile = "shieldPack";
  className = "Backpack";
  heading = $InvHead[ihHMB];
  shadowDetailMask = 4;
  imageType = StealthPackImage;
  price = 0;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};
function StealthPackImage::onActivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),3,":Stealth Pack • On:");
  %player.shieldStrength = 0.012;
  %rate = Player::getSensorSupression(%player) + 20;
  Player::setSensorSupression(%player,%rate);
  GameBase::startFadeout(%player); 

}
function StealthPackImage::onDeactivate(%player,%imageSlot) 
{
  Client::sendMessage(Player::getClient(%player),1,":Stealth Pack • Off:");
  Player::trigger(%player,$BackpackSlot,false);
  %player.shieldStrength = 0;
  %rate = Player::getSensorSupression(%player) - 20;
  Player::setSensorSupression(%player,%rate);
  GameBase::startFadein(%player);

}
////////////////////////////////////////////////////
// Preadtor Packs                                //
// Repair Pack Dynamix 98-=-RepairGun Armageddon//
/////////////////////////////////////////////////
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
   heading = $InvHead[ihHMB];
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 0;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
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
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}
////////////////////////////////////////////////////
// Preadtor Packs                                //
// Claymore Pack Armageddon 05                  //
/////////////////////////////////////////////////
ItemImageData ClaymorePackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ClaymorePack 
{
	description = "Claymore Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   	heading = $InvHead[ihHMB];
	shadowDetailMask = 4;
	imageType = ClaymorePackImage;
	price = 0;
	hudIcon = "plasma";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemData TriggeredClaymorePack 
{
	description = "Claymore Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	shadowDetailMask = 4;
	imageType = ClaymorePackImage;
	price = 0;
	hudIcon = "plasma";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ClaymorePack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else {

		Client::sendMessage(Player::getClient(%player),0,"Explosives armed");

		// remove the Claymore pack
		Player::setItemCount(%player, ClaymorePack, 0);

		// create a triggered Claymore pack
		%obj = newObject("", "Item", "TriggeredClaymorePack", 1, false);
	 	addToSet("MissionCleanup", %obj);

		// throw it
		GameBase::throw(%obj, %player, 15, false);

		// Play sound
		GameBase::playSound(%player, SoundPickupBackpack, 3);

		// schedule it's Claymore
		schedule("TriggeredClaymorePack::Detonate("@%obj@");", 4.0, %obj);
	}
}


function TriggeredClaymorePack::Detonate(%this) {
	// detonate the Claymore pack

	%numberOfExplosives = 20;
	%time = 5;

	for (%i = 0; %i < %numberOfExplosives; %i++) {

		// create each explosive
		%obj = newObject("","Mine","ClaymoreGrenade");
 	 	addToSet("MissionCleanup", %obj);

		// set its timer
		ClaymoreGrenade::setTimer(%obj, %time);

		// throw it out randomly from the pack
		GameBase::throw(%obj, %this, 6, true);
	}

	deleteObject(%this);
}

function TriggeredClaymorePack::onCollision(%this, %obj) {
	// Check for defusing
	if(getObjectType(%obj) != "Player") {
		return;
	}

	if(Player::isDead(%obj)) {
		return;
	}

	%client = Player::getClient(%obj);
	%armor = Player::getArmor(%obj);

	// if the object is flying through the air, let's not allow defuses or detonations
	if (!GameBase::isAtRest(%this)) return;

	// If the proper armor touches the explosive
	if (%armor == "CyMedium") 
	{
		// set success rate
		if (%armor == "CyMedium") 
		{
			%successrate = 9.5;
		}
		else 
		{
			%successrate = 7.5;
		}

		// attempt to disarm the explosive
		%rnd = floor(getRandom() * 10);
		if(%rnd < %successrate) {
			playSound(SoundPickupItem,GameBase::getPosition(%this));

			// Success will remove the explosive
			deleteObject(%this);
			Client::sendMessage(%client, 1, "Explosives have been disarmed.");

			// If a HyMedium
			if (%armor == "HyMedium") {

				// Give the player an explosive pack & Repair Kit
				Item::giveItem(%obj, ClaymorePack, 1);
				Item::giveItem(%obj, RepairKit, 1);
			}
		}
		else {
			// Failure will detonate the explosive
			Client::sendMessage(%client, 1, "Disarm attempt failed!");
			TriggeredDemolitionsPack::Detonate(%this);
			return;
		}
	}

	// other armors may detonate the explosive
	else {
		%rnd = floor(getRandom() * 10);
		if(%rnd > 8) {
			// detonate the explosive
			TriggeredClaymorePack::Detonate(%this);
			return;
		}
	}

}
/////////////////////////////////////////////////
// Eagle Packs                                //
// Thrust Pack Armageddon 05                 //
//////////////////////////////////////////////
ItemImageData ThrustPackImage
{
	shapeFile = "shieldpack";
	weaponType = 0;
	projectileType = ThrustBlast;
	reloadTime = 1;
	mass = -7.0;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 1;
	maxEnergy = 0.1;
	firstPerson = false;
};

ItemData ThrustPack
{
	description = "Thrust Pack";
	shapeFile = "shieldpack";
	className = "Backpack";
   	heading = $InvHead[ihHHB];
	shadowDetailMask = 4;
	imageType = ThrustPackImage;
	price = 0;
	mass = -7.0;
	hudIcon = "jetpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ThrustPackImage::onActivate(%player,%imageSlot)
{
	%client = Player::getClient(%player);
  	Client::sendMessage(Player::getClient(%player),3,":Thrust Pack • On:");
	Player::trigger(%player,$BackpackSlot,true);
}

function ThrustPackImage::onDeactivate(%player,%imageSlot)
{
	%client = Player::getClient(%player);
  	Client::sendMessage(Player::getClient(%player),1,":Thrust Pack • Off:");
	Player::trigger(%player,$BackpackSlot,false);
}

function ThrustPack::onMount(%player,%item)
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "The Thrust Pack Manipulates Your Mass & Launches A Non-Harmfull Blast When Activated For Better Jetting.");
}
/////////////////////////////////////////////////
// Eagle Packs                                //
// Shield Pack + FX Armageddon 05            //
//////////////////////////////////////////////
ItemImageData ShieldPackImage
{
	shapeFile = "shieldpack";
	mountPoint = 2; 
	weaponType = 0;
	projectileType = ShieldBlast;
	reloadTime = 0;
	minEnergy = -1;
	maxEnergy = -4;   // Energy/sec for sustained weapons
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield+ Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   	heading = $InvHead[ihHHB];
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 0;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   	validateShape = true;
   	validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
  	Client::sendMessage(Player::getClient(%player),3,":Shield Pack • On:");
	%player.shieldStrength = 0.008;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
  	Client::sendMessage(Player::getClient(%player),1,":Shield Pack • Off:");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
}
/////////////////////////////////////////////////
// Eagle Packs                                //
// Health Pack Armageddon 05                 //
//////////////////////////////////////////////
ItemImageData RepairCannonTImage
{
   shapeFile  = "armorPack";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.065 };
	mountRotation = { 0, 3.14, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	fireTime = 0.075;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepairCannonT
{
	description = "RepairCannon Top";
	className = "Weapon";
	shapeFile = "repairgun";
   validateShape = true;
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = RepairCannonTImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData RepairCannonRImage
{
	shapeFile = "armorPack";
	mountPoint = 0;
	mountOffset = { 0.075, 0, 0.065 };
	mountRotation = { 0, 1.047, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	fireTime = 0.075;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepairCannonR
{
	description = "RepairCannon Right";
	className = "Weapon";
	shapeFile = "repairgun";
   validateShape = true;
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = RepairCannonRImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData RepairCannonLImage
{
	shapeFile = "armorPack";
	mountPoint = 0;
	mountOffset = { -0.075, 0, 0.065 };
	mountRotation = { 0, -1.047, 0 };
	weaponType = 0; // Spinning
	reloadTime = 0;
	fireTime = 0.075;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RepairCannonL
{
	description = "RepairCannon Left";
	className = "Weapon";
	shapeFile = "repairgun";
   validateShape = true;
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = RepairCannonLImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData RepairCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, 0.05, 0 };

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

ItemData RepairCannon
{
	description = "RepairCannon";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairCannonImage;
	showInventory = false;
	price = 0;
   validateShape = true;
};

function RepairCannon::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,RepairCannonT,3); 
	Player::mountItem(%player,RepairCannonR,4); 
	Player::mountItem(%player,RepairCannonL,5); 
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairCannon::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,3); 
	Player::unmountItem(%player,4); 
	Player::unmountItem(%player,5); 
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData HealthPackImage
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

ItemData HealthPack
{
	description = "Health Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = $InvHead[ihHHB];
	shadowDetailMask = 4;
	imageType = HealthPackImage;
	price = 0;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function HealthPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairCannon) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function HealthPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,RepairCannon,$WeaponSlot);
	}
}

function HealthPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairCannon) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}
/////////////////////////////////////////////////
// Eagle Packs                                //
// Battle Mech Pack Armageddon 05            //
//////////////////////////////////////////////
ItemImageData MechPackImage
{
	shapeFile = "mineammo";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData MechPack
{
	description = "Mech Pack";
	className = "Backpack";
	shapeFile = "mineammo";
	hudIcon = "shieldpack";
   	heading = $InvHead[ihHHB];
	shadowDetailMask = 4;
	imageType = MechPackImage;
	price = 0;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function MechPackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%vel = Item::getVelocity(%client);

	if(Player::getMountedItem(%client, $FlagSlot) == "flag")
	{
		Player::dropItem(%client, Player::getMountedItem(%client, $FlagSlot));
		Client::sendMessage(%client, 1, "You lost flag while becoming a Mech");
	}

	%item = HAPCVehicle;

	%markerPos = GameBase::getPosition(%client);
	%set = newObject("",Flier, HAPC, true);
	%damage = GameBase::getDamageLevel(%player);


	%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;

	%vehicle = newObject("",flier,$DataBlockName[%item],true);
	Gamebase::setMapName(%vehicle,%item.description);
      	%vehicle.clLastMount = %client;
	addToSet("MissionCleanup", %vehicle);
  	%vehicle.fading = 1;
	GameBase::setTeam(%vehicle,Client::getTeam(%client));
	GameBase::setPosition(%vehicle,%markerPos);
	GameBase::setRotation(%vehicle,GameBase::getRotation(%client));
	deleteObject(%set);
	$TeamItemCount[Client::getTeam(%client) @ %item]++;

	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	if(%weapon != -1)
	{
		%player.lastWeapon = %weapon;
		Player::unMountItem(%player,$WeaponSlot);
	}

	Player::setMountObject(%player, %vehicle, 1);
	Client::setControlObject(%client, %vehicle);
	%player.driver = 1;
	%player.vehicle = %vehicle;
	%vehicle.clLastMount = %client;
	GameBase::setDamageLevel(%vehicle, %damage);

	Item::setVelocity(%client, %vel);
	Player::setItemCount(%player, MechPack, 0);
}

function MechPackImage::onDeactivate(%player, %imageSlot)
{
	Player::setItemCount(%player, MechPack, 0);
}
/////////////////////////////////////////////////
// Banshee Packs                              //
// Vanish Pack Armageddon 05                 //
//////////////////////////////////////////////
ItemImageData VanishPackImage
{
	shapeFile = "shield";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 8;
	maxEnergy = 8;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData VanishPack
{
	description = "Vanish Pack";
	shapeFile = "shield";
	className = "Backpack";
   	heading = $InvHead[ihCLB];
	shadowDetailMask = 4;
	imageType = VanishPackImage;
	price = 0;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   	validateShape = false;
   	validateMaterials = true;
};


function VanishPackImage::onActivate(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	Player::trigger(%player,$BackpackSlot,True);
	Client::sendMessage(%clientId,0,"Activating Terrain Shifter");

	$VanishPack::OldPos[%player] = GameBase::getPosition(%player);
	%xPos = getword($VanishPack::OldPos[%player], 0);
	%yPos = getword($VanishPack::OldPos[%player], 1);
	%Pos = %xPos @ " " @ %yPos @ " -100000";
	GameBase::setPosition(%player, %Pos);

	%player.Sub = newObject("Player Subsitution", "StaticShape", VanishZap, true);
	GameBase::setPosition(%player.Sub, $VanishPack::OldPos[%player]);

	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	Observer::setOrbitObject(%clientId, %player.Sub, 3, 3, 3);

	%clientId.guiLock = true;

	bottomprint(%clientId, "<jc><f0>Press the <f4>[JUMP KEY]<f0> when you want to return!", 5);
}

function VanishPackImage::onDeactivate(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	Player::trigger(%player,$BackpackSlot,false);
	Client::sendMessage(%clientId,0,"Deactivating Terrain Shifter");

	Item::setVelocity(%player, 0);
	GameBase::setPosition(%player, $VanishPack::OldPos[%player]);
	Item::setVelocity(%player, 0);

	Client::setControlObject(%clientId, %player);

	deleteObject(%player.Sub);
	%player.Sub = "";

	%clientId.guiLock = false;
}
// ========================================================
// W E I G H T  &  M A S S  M A N I P U L A T I O N
// ========================================================

ItemData Weight
{				
	description = "";
	className = "Tool";
	showInventory = false;
};

function Weight::onDrop(%player, %item){}
function Weight::onUse(%player, %item){}

ItemImageData DeadWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = 90000.0;
};

ItemData DeadWeight
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = DeadWeightImage;
	price = 0;
	showWeaponBar = false;
	mass = 90000.0;
	showInventory = false;
};

ItemImageData LessWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -2.0;
};

ItemData LessWeight
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = LessWeightImage;
	price = 0;
	showWeaponBar = false;
	mass = -2.0;
	showInventory = false;
};

ItemImageData LessWeight2Image
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -4.0;
};

ItemData LessWeight2
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
	heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = LessWeight2Image;
	price = 0;
	showWeaponBar = false;
	mass = -4.0;
	showInventory = false;
};
//----------------------------------------------------------------------------
// Turrets/Deps
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
   heading = $InvHead[ihBfe];
	shadowDetailMask = 4	;
	imageType = DeployableInvPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
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
		%Set = newObject("set",SimSet);
	        %Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		%thing = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		{
		%inbase= true;
		break;
		}
	}
		deleteObject(%Set);
		if(%inbase)
                {
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
		else 
                {
		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
		}
	}
		else 
                {
		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
	}
		else 
                {
		bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
		}
	}
		else 
                {
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
   heading = $InvHead[ihBfe];
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
		%Set = newObject("set",SimSet);
		%Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		%thing = Group::getObject(%Set, %i);
		if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		{
		%inbase= true;
		break;
		}
	}
		deleteObject(%Set);
		if(%inbase)
                {
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
					bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
	}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}
//-------------------------------------	




//----------------------------------------------------------------------------

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 18;  // Energy used/sec for sustained weapons
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
	heading = $InvHead[ihBkp];
	shadowDetailMask = 4;
	imageType = CloakingDeviceImage;
	price = 0;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CloakingDeviceImage::onActivate(%player,%imageSlot)
{
 	GameBase::startFadeout(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);
}

function CloakingDeviceImage::onDeactivate(%player,%imageSlot)
{
 	GameBase::startFadein(%player);
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
	%rate = Player::getSensorSupression(%player) - 3;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------------------------

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
	description = "Motion Sen. Network";
	shapeFile = "sensor_small";
	className = "Backpack";
   heading = $InvHead[ihSen];
	imageType = MotionSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
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

function MotionSensorPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		%Set = newObject("set",SimSet);
						                                %Mask = $StaticObjectType;
						                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
						                                for(%i; %i < %num; %i++)
						                                {
						                                        %thing = Group::getObject(%Set, %i);
						                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
						                                        {
						                                                %inbase= true;
						                                                break;
						                                        }
						                                }
						                                deleteObject(%Set);
						                                if(%inbase)
                                {

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
					%mSensor = newObject("","Sensor",DeployableMotionSensor,true);
	   	      addToSet("MissionCleanup", %mSensor);
					GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
					GameBase::setRotation(%mSensor,%rot);
					GameBase::setPosition(%mSensor,$los::position);
					Gamebase::setMapName(%mSensor,"Motion Sensor Network");
					Client::sendMessage(%client,0,"Motion Sensor Network deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Motion Sensor Network");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
					bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
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
	description = "Pulse Sen. Network";
	shapeFile = "radar_small";
	className = "Backpack";
   heading = $InvHead[ihSen];
	imageType = PulseSensorPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
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
	description = "Sen. Jammer Network";
  	shapeFile = "sensor_jammer";
  	className = "Backpack";
   heading = $InvHead[ihSen];
	imageType = DeployableSensorJamPackImage;
  	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
  	price = 0;
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
	description = "Spy Camera Network";
	shapeFile = "camera";
	className = "Backpack";
   heading = $InvHead[ihSen];
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
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
		%Set = newObject("set",SimSet);
						                                %Mask = $StaticObjectType;
						                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
						                                for(%i; %i < %num; %i++)
						                                {
						                                        %thing = Group::getObject(%Set, %i);
						                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
						                                        {
						                                                %inbase= true;
						                                                break;
						                                        }
						                                }
						                                deleteObject(%Set);
						                                if(%inbase)
                                {

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
					%camera = newObject("Camera","Turret",CameraTurret,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Spy Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Spy Camera deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
					echo("MSG: ",%client," deployed a Spy Camera");
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		else {
						
					bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3); 
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
	description = "Sentry Turret System";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = TurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
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


function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{
		%Set = newObject("set",SimSet);
                %Mask = $StaticObjectType;
		%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		for(%i; %i < %num; %i++)
		{
		        %thing = Group::getObject(%Set, %i);
			if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
			{
			       %inbase= true;
			       break;
			}
                }
		deleteObject(%Set);
		if(%inbase)
                {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
                        {
	    		%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"LaserTurret",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num) {
		    	%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
			%num = CountObjects(%set,"LaserTurret",%num);
			deleteObject(%set);
			if(0 == %num) 
                {
			if (Vector::dot($los::normal,"0 0 1") > 0.7) {
			if(checkDeployArea(%client,$los::position)) {
			%rot = GameBase::getRotation(%player); 
			%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Gamebase::setMapName(%turret,"Sentry Turret System#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			Client::sendMessage(%client,0,"Sentry Turret System deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
			echo("MSG: ",%client," deployed a Sentry Turret System");
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
		bottomprint(%client, "<JC><F1>!!!<F2>W A R N I N G<F1>!!! <F3>Fair play distance exceeded for <F1>" @ %item.description @ "s", 3);
                }
		else 
		Client::sendMessage(%client,0,"Deploy position out of range");
	        }
	        else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}




//-------------|Electric Web By: Arma|----- 
ItemImageData ElectricWebImage
{
	shapeFile = "display_three";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };//1.57
	firstPerson = false;
};

ItemData ElectricWeb
{
	description = "Electric Web";
	shapeFile = "display_three";
	className = "Backpack";
      heading = $InvHead[ihTur];
	imageType = ElectricWebImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 0;
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
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                %playerPos = GameBase::getPosition(%player);
                %deploypos = Vector::add(GameBase::getPosition(%player), "0 0 2");
                %rot = Vector::add(GameBase::getRotation(%player), "0 1.57 1.57");
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
                Client::sendMessage(%client,0,"Electric Web is spun.~wlightning_idle.wav");
      
        }

}

//----------------------------------------------------------------------------
// Remote deploy for items

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
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}
//----------------------------------------------------------------------------

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = $InvHead[ihUpg];
   shadowDetailMask = 4;
   price = 0;
   validateShape = true;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);

	%maxRepair = %armor.maxDamage*100000000000;

	Player::decItemCount(%player,%item);
	//== Get random amount....
	%repair = floor(getRandom() * %maxRepair);

	//== Now make it so that min:0 max:The full health
	%amount = %repair/100000000000;
	%perPercent = %armor.maxDamage / 100;

	if((%amount/%perPercent) < 10)
		%amount = %perPercent*10;

	%percentRepair = %amount / %perPercent;
	//== Now actually repair
	GameBase::repairDamage(%player,%amount);

	Client::SendMessage(%client, 3, "You Have Repaired " @ floor(%percentRepair) @ "% Of Your Armor.");
}


//----------------------------------------------------------------------------
// SwitchAble Mines - much of this code was ripped from Ideal Mod
//----------------------------------------------------------------------------

ItemData MineAmmo
{
	showInventory = false;
	description = "Mine";
	shapeFile = "mineammo";
//	heading = $InvHead[ihMne];
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
};

ItemData OriginalMine
{
	description = "Anti-personnel Mine";
	shapeFile = "mineammo";
	heading = $InvHead[ihMne];
	shadowDetailMask = 4;
	price = 10;
	className = "Mine";
};

ItemData TripMine
{
	description = "Trip Mine";
	shapeFile = "discammo";
	heading = $InvHead[ihMne];
	shadowDetailMask = 4;
	price = 10;
	className = "Mine";
};

//ItemData SatchelCharge
//{
//	description = "Satchel Charge";
//	shapeFile = "camera";
//	heading = $InvHead[ihMne];
//	shadowDetailMask = 4;
//	price = 5;
//	className = "Mine";
//};

//ItemData SpringMine
//{
//	description = "Springboard";
//	shapeFile = "flagstand";
//	heading = $InvHead[ihMne];
//	shadowDetailMask = 4;
//	price = 0;
//	className = "Mine";
//};

//ItemData PhaseLokMine
//{
//	description = "PhaseLok";
//	shapeFile = "remoteTurret";
//	heading = $InvHead[ihMne];
//	shadowDetailMask = 4;
//	price = 0;
//	className = "Mine";
//};

function MineAmmo::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			%clientId = Player::getClient(%player);
			if(Player::getItemCount(%player, OriginalMine))
			{
				%name = "AntipersonelMine";
				%item = OriginalMine;
			}
			else if(Player::getItemCount(%player, TripMine))
			{
				SetTripMine(%clientId, %player, %item);
				return;
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
			GameBase::setTeam(%obj,GameBase::getTeam(%client));
			Client::setOwnedObject(%client, %obj);
			Client::setOwnedObject(%client, %player);
		}
	}
}

//----------------------------------------------------------------------------
// SwitchAble Grenades - much of this code was ripped from Ideal Mod
//----------------------------------------------------------------------------

ItemData Grenade
{
	showInventory = false;
	description = "Grenade";
	shapeFile = "grenade";
//	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 0;
	className = "HandAmmo";
};

ItemData OriginalGrenade
{
	description = "Frag Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData PlasticGrenade
{
	description = "Plastic Explosive";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData PlasmaGrenade
{
	description = "Fire Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData EMPGrenade
{
	description = "EMP Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData DaisyGrenade
{
	description = "Daisy Cutter";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData AirStrikeGrenade
{
	description = "AirStrike DFA";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData SmokerGrenade
{
	description = "Smoke Bomb";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData FlareGrenade
{
	description = "Emergency Flare";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData FlashGrenade
{
	description = "Flash Bang";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData VortexGrenade
{
	description = "Vortex Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData FusionGrenade
{
	description = "Fusion Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData PulseGrenade
{
	description = "Pulse Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData RadiationGrenade
{
	description = "Radiation Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

ItemData RailGrenade
{
	description = "Rail Grenade";
	shapeFile = "grenade";
	heading = $InvHead[ihGrn];
	shadowDetailMask = 4;
	price = 5;
	className = "Grenade";
};

function Grenade::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	%clientName = client::GetName(Player::getClient(%player));
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			if(Player::getItemCount(%player, OriginalGrenade) > 0)
			{
				%item = OriginalGrenade;
				%name = "Handgrenade";
				%chuckmod = 0.5;
			}
			else if(Player::getItemCount(%player, PlasmaGrenade) > 0)
			{
				%item = PlasmaGrenade;
				%name = "FireBomb";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, EMPGrenade) > 0)
			{
				%item = EMPGrenade;
				%name = "EMPBomb";
				%chuckmod = 2;
			}
			else if(Player::getItemCount(%player, FlareGrenade) > 0)
			{
				%item = FlareGrenade;
				%name = "Flare1grenade";
				messageAll(1,%clientName@": *Flare Launched I'm In Need Of Some Assistance*~wmine_act.wav");
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, SmokerGrenade) > 0)
			{
				%item = SmokerGrenade;
				%name = "Smoker";
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, FlashGrenade) > 0)
			{
				%item = FlashGrenade;
				%name = "FlashHandgrenade";
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, VortexGrenade) > 0)
			{
				%item = VortexGrenade;
				%name = "VortexHandgrenade";
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, FusionGrenade) > 0)
			{
				%item = FusionGrenade;
				%name = "FusionBomb";
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, PulseGrenade) > 0)
			{
				%item = PulseGrenade;
				%name = "PulseBomb";
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, RadiationGrenade) > 0)
			{
				%item = RadiationGrenade;
				%name = "RadiationBomb";
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, RailGrenade) > 0)
			{
				//%item = RailGrenade;
				//%name = "RailBomb";
				//%chuckmod = 0.2;
				Grenade::useRail(%player);
			}
			else if(Player::getItemCount(%player, DaisyGrenade) > 0)
			{
				%item = DaisyGrenade;
				%name = "DaisyCutter";
				%chuckmod = 0.2;
			}
			else if(Player::getItemCount(%player, AirStrikeGrenade) > 0)
			{
				%item = AirStrikeGrenade;
				%name = "AirStrike";
				messageAll(1,%clientName@": !^!Called In An Air Strike!^!~waccess_denied.wav");
				%chuckmod = 0.5;
			}
			else if(Player::getItemCount(%player, PlasticGrenade) > 0)
			{
				%item = PlasticGrenade;
				%name = "PlasticExplosive";
				Client::sendMessage(%clientId,1, "Plastic Explosive will explode in 15 seconds.~waccess_denied.wav");
				%chuckmod = 0.5;
			}
			else
				return;
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
			%armor = Player::getArmor(%player);
			%obj = newObject("","Mine",%name);
			%obj.deployer = %player;
 	 	 	addToSet("MissionCleanup", %obj);
			if(%name == "PlasticExplosive")
			schedule("Grenade::Plastic_Detonate(" @ %obj @ ");", 15);
			GameBase::throw(%obj,%player,9 * %clientId.throwStrength * %chuckmod,false);
			GameBase::throw(%obj,%player,10,false);

			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = $InvHead[ihUpg];
   shadowDetailMask = 4;
   price = 0;
        className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
  if($matchStarted) 
{
                if(%player.throwTime < getSimTime() ) {
                        %obj = newObject("","Mine","boost");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,0,false);
                        %player.throwTime = getSimTime() + 0.2;
                }
        }
}

//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = $InvHead[ihUpg];
	shadowDetailMask = 4;
  	price = 0;
   validateShape = true;
   validateMaterials = true;
};


function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.5);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

function RepairPatch::onUse(%player,%item)
{
	GameBase::repairDamage(%player,0.1);
}

function remoteGiveAll(%clientId)
{
	if ($TestCheats) {


      		Player::setItemCount(%clientId,Grenade, 1);
      		Player::setItemCount(%clientId,MineAmmo, 1);
		Player::setItemCount(%clientId,Beacon,  1);

		Player::setItemCount(%clientId,RepairKit,1);
	}
	else if($ServerCheats) {
		%armor = Player::getArmor(%clientId);

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
// VX6
function recountitem(%itemname)
{
	if ($debug) echo ("Reiniting - " @ %itemname @ "");
	for(%i = -1; %i < 8 ; %i++)
		$TeamItemCount[%i @ %itemname] = 0;
}

function Mission::reinitData()
{
        // Ammo-Inv-Transport Systems
	recountitem("DeployableAmmoPack");
	recountitem("DeployableInvPack");
	recountitem("DeployableTeleport");
        // Turret Systems
	recountitem("TurretPack");
	recountitem("ElectricWeb");
        // Sensor Networks
	recountitem("CameraPack");
	recountitem("DeployableSensorJammerPack");
	recountitem("PulseSensorPack");
	recountitem("MotionSensorPack");
 	// Vehicles
	recountitem("ScoutVehicle");
	recountitem("MercJetVehicle");
	recountitem("LAPCVehicle");
	recountitem("HAPCVehicle");
        // Misc
	recountitem("Beacon");
	recountitem("mineammo");
	Cybrid::InitGroups();
	Cybrid::InitFlagFX();
	$totalNumCameras = 0;
	$totalNumTurrets = 0;


	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 

}

//----------------------------------------------------------------------------------------------------------------------------------------------
// Music That Fueled This Project: Fear Factor, American Head Charge, Nirvana, MisFiTs, DanZig, As I Lay Dying, Chimera & MUDVAYNE!  (Armageddon)
//----------------------------------------------------------------------------------------------------------------------------------------------