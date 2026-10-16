//=============================
$ItemFavoritesKey = "Genocide";
//=============================	
$ItemPopTime = 30;
//=================
$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;
//=================
$Use[Blaster] = True;

$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[Mortar] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[Charger] = True;
$AutoUse[FusionRifle] = True;
$AutoUse[ShockRfile] = True;
$AutoUse[RadiationRifle] = True;
$AutoUse[DiscoRifle] = True;
$AutoUse[GatLaser] = True;
$AutoUse[GrazerCannon] = True;
$AutoUse[HybridLaser] = True;
$AutoUse[Grappling] = True;
$AutoUse[QuakeBlaster] = True;
$AutoUse[HellStorm] = True;
$AutoUse[FusionCannon] = True;
$AutoUse[MultiCannon] = True;
$AutoUse[Glock] = True;
$AutoUse[WTShotgun] = True;
$AutoUse[ParticalShotgun] = True;
$AutoUse[SXH] = True;
$AutoUse[Havoc] = True;
$AutoUse[HybridRail] = True;
$AutoUse[Minigun] = True;
$AutoUse[ShardGun] = True;
$AutoUse[DFMIYA] = True;
$AutoUse[Destroyer] = True;
$AutoUse[ARPG] = True;
$AutoUse[HybridChain] = True;
$AutoUse[PlasmaBlaster] = True;
$AutoUse[Blaze] = True;
$AutoUse[PlasmaGat] = True;
$AutoUse[MeltLaser] = True;
$AutoUse[SAStealth] = True;
$AutoUse[NapalmLauncher] = True;
$AutoUse[NapalmRocket] = True;
$AutoUse[Magma] = True;
$AutoUse[ShockWaveC] = True;
$AutoUse[Nitro] = True;
$AutoUse[FireMortar] = True;
$AutoUse[ContactMortar] = True;
$AutoUse[AirRaid] = True;
$AutoUse[TimeBomb] = True;
$AutoUse[AtomicBomb] = True;
$AutoUse[ClashRocket] = True;
$AutoUse[ETTR] = True;
$AutoUse[sludge] = True;
$AutoUse[Salvo] = True;
$AutoUse[AnarchyCannon] = True;
$AutoUse[Claymore] = True;
$AutoUse[HybridMortar] = True;
$AutoUse[HybridCannon] = True;
$AutoUse[HybridRocketLauncher] = True;
$AutoUse[HybridQuadLauncher] = True;
//=========================================
$ArmorType[Male, SniperArmor] = sarmor;
$ArmorType[Female, SniperArmor] = sarmor;
$ArmorType[Male, NewArmor] = narmor;
$ArmorType[Female, NewArmor] = narmor;
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[sarmor] = SniperArmor;
$ArmorName[narmor] = NewArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;
//==========================================

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 50;
$SellAmmo[HybridMortarAmmo] = 50;
$SellAmmo[GlockAmmo] = 50;
$SellAmmo[ShardGunAmmo] = 50;
$SellAmmo[MinigunAmmo] = 50;
$SellAmmo[DestroyerAmmo] = 50;
$SellAmmo[ClashRocketAmmo] = 50;
$SellAmmo[ETTRAmmo] = 50;
$SellAmmo[ShockWaveCAmmo] = 50;
$SellAmmo[HybridRailAmmo] = 50;
$SellAmmo[HybridChainAmmo] = 50;
$SellAmmo[HybridQuadAmmo] = 50;
$SellAmmo[MagmaAmmo] = 50;
$SellAmmo[HybridCannonAmmo] = 50;
$SellAmmo[HybridRocketLauncherAmmo] = 50;
$SellAmmo[DFMIYAAmmo] = 50;
$SellAmmo[WTShotgunAmmo] = 50;
$SellAmmo[SXHAmmo] = 50;
$SellAmmo[ARPGAmmo] = 50;
$SellAmmo[HavocAmmo] = 50;
$SellAmmo[PlasmaAmmo] = 50;
$SellAmmo[NapalmLauncherAmmo] = 50;
$SellAmmo[BlazeAmmo] = 50;
$SellAmmo[PlasmaGatAmmo] = 50;
$SellAmmo[DiscLauncherAmmo] = 50;
$SellAmmo[sludgeAmmo] = 50;
$SellAmmo[ParticalShotgunAmmo] = 50;
$SellAmmo[NapalmRocketAmmo] = 50;
$SellAmmo[AtomicBombAmmo] = 50;
$SellAmmo[SAStealthAmmo] = 50;
$SellAmmo[HellStormAmmo] = 50;
$SellAmmo[GrenadeAmmo] = 50;
$SellAmmo[MortarAmmo] = 50;
$SellAmmo[FireMortarAmmo] = 50;
$SellAmmo[SalvoAmmo] = 50;
$SellAmmo[ContactMortarAmmo] = 50;
$SellAmmo[AirRaidAmmo] = 50;
$SellAmmo[ClaymoreAmmo] = 50;
$SellAmmo[TimeBombAmmo] = 50;
$SellAmmo[NitroAmmo] = 50;
$SellAmmo[Beacon] = 50;
$SellAmmo[MineAmmo] = 50;
$SellAmmo[Grenade] = 50;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[GlockAmmo] = 15;
$AmmoPackMax[HybridRailAmmo] = 15;
$AmmoPackMax[HybridChainAmmo] = 150;
$AmmoPackMax[HybridQuadAmmo] = 15;
$AmmoPackMax[MagmaAmmo] = 15;
$AmmoPackMax[ClashRocketAmmo] = 15;
$AmmoPackMax[HybridCannonAmmo] = 20;
$AmmoPackMax[HybridMortarAmmo] = 20;
$AmmoPackMax[ShardGunAmmo] = 250;
$AmmoPackMax[WTShotgunAmmo] = 50;
$AmmoPackMax[SXHAmmo] = 50;
$AmmoPackMax[MinigunAmmo] = 50;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[NapalmLauncherAmmo] = 20;
$AmmoPackMax[BlazeAmmo] = 200;
$AmmoPackMax[PlasmaGatAmmo] = 50;
$AmmoPackMax[DiscLauncherAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[ContactMortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[ShockWaveCAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;
$AmmoPackMax[sludgeAmmo] = 15;
$AmmoPackMax[NapalmRocketAmmo] = 30;
$AmmoPackMax[AtomicBombAmmo] = 1;
$AmmoPackMax[SAStealthAmmo] = 25;
$AmmoPackMax[AntimatterLaserAmmo] = 10;
$AmmoPackMax[SalvoAmmo] = 15;
$AmmoPackMax[HavocAmmo] = 10;
$AmmoPackMax[TimeBombAmmo] = 20;
$AmmoPackMax[ARPGAmmo] = 40;
$AmmoPackMax[DestroyerAmmo] = 30;
$AmmoPackMax[DFMIYAAmmo] = 100;
$AmmoPackMax[FireMortarAmmo] = 10;
$AmmoPackMax[ParticalShotgunAmmo] = 10;
$AmmoPackMax[HybridRocketLauncher] = 10;
$AmmoPackMax[AirRaid] = 10;
$AmmoPackMax[Claymore] = 10;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = GlockAmmo;
$AmmoPackItems[2] = ShardGunAmmo;
$AmmoPackItems[3] = WTShotgunAmmo;
$AmmoPackItems[4] = SXHAmmo;
$AmmoPackItems[5] = PlasmaAmmo;
$AmmoPackItems[6] = BlazeAmmo;
$AmmoPackItems[7] = PlasmaGatAmmo;
$AmmoPackItems[8] = DiscLauncherAmmo;
$AmmoPackItems[9] = GrenadeAmmo;
$AmmoPackItems[10] = MortarAmmo;
$AmmoPackItems[11] = ContactMortarAmmo;
$AmmoPackItems[12] = MineAmmo;
$AmmoPackItems[13] = Grenade;
$AmmoPackItems[14] = Beacon;
$AmmoPackItems[15] = sludgeAmmo;
$AmmoPackItems[16] = NapalmRocketAmmo;
$AmmoPackItems[17] = AtomicBombAmmo;
$AmmoPackItems[18] = SAStealthAmmo;
$AmmoPackItems[19] = AntimatterLaserAmmo;
$AmmoPackItems[20] = SalvoAmmo;
$AmmoPackItems[21] = HavocAmmo;
$AmmoPackItems[22] = TimeBombAmmo;
$AmmoPackItems[23] = ARPGAmmo;
$AmmoPackItems[24] = DestroyerAmmo;
$AmmoPackItems[25] = DFMIYAAmmo;
$AmmoPackItems[26] = FireMortarAmmo;
$AmmoPackItems[27] = ParticalShotgunAmmo;
$AmmoPackItems[28] = ClaymoreAmmo;
$AmmoPackItems[29] = HybridRailAmmo;
$AmmoPackItems[30] = ShockWaveCAmmo;
$AmmoPackItems[31] = NapalmLauncherAmmo;
$AmmoPackItems[32] = HybridChainAmmo;
$AmmoPackItems[33] = HybridCannonAmmo;
$AmmoPackItems[34] = HybridRocketLauncherAmmo;
$AmmoPackItems[35] = HybridQuadAmmo;
$AmmoPackItems[36] = ClashRocketAmmo;
$AmmoPackItems[37] = MinigunAmmo;
$AmmoPackItems[38] = HybridMortarAmmo;
$AmmoPackItems[39] = MagmaAmmo;
$AmmoPackItems[40] = AirRaidAmmo;

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 0;
$TeamItemMax[DeployableInvPack] = 10;
$TeamItemMax[TurretPack] = 5;



$TeamItemMax[ARPGTurretPack] = 5;

$TeamItemMax[CameraPack] = 4;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 8;
$TeamItemMax[MotionSensorPack] = 8;
$TeamItemMax[ScoutVehicle] = 5;
$TeamItemMax[WarthogVehicle] = 5;
$TeamItemMax[SR71Vehicle] = 5;
$TeamItemMax[EnterpriseVehicle] = 5;
$TeamItemMax[BomberVehicle] = 5;
$TeamItemMax[SpeedBikeVehicle] = 5;
$TeamItemMax[ColossusVehicle] = 5;
$TeamItemMax[ArwingVehicle] = 5;
$TeamItemMax[HAPCVehicle] = 5;
$TeamItemMax[LAPCVehicle] = 5;
$TeamItemMax[Beacon] = 9999;
$TeamItemMax[mineammo] = 30;
$TeamItemMax[CMineAmmo] = 9999;
$TeamItemMax[grenade] = 9999;

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
$WeaponAmmo[HybridMortar] = "HybridMortarAmmo";
$WeaponAmmo[PlasmaBlaster] = "";
$WeaponAmmo[Magma] = "MagmaAmmo";
$WeaponAmmo[MeltLaser] = "";
$WeaponAmmo[NapalmLauncher] = "NapalmLauncherAmmo";
$WeaponAmmo[Minigun] = "MinigunAmmo";
$WeaponAmmo[QuakeBlaster] = "";
$WeaponAmmo[FusionRifle] = "";
$WeaponAmmo[HybridRocketLauncher] = "HybridRocketLauncherAmmo";
$WeaponAmmo[Grappling] = "";
$WeaponAmmo[ShockWaveC] = "ShockWaveCAmmo";
$WeaponAmmo[Glock] = GlockAmmo;
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[MultiCannon] = "";
$WeaponAmmo[Blaze] = BlazeAmmo;
$WeaponAmmo[PlasmaGat] = PlasmaGatAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[ETTR] = "ETTRAmmo";
$WeaponAmmo[ShardGun] = ShardGunAmmo;
$WeaponAmmo[Destroyer] = DestroyerAmmo;
$WeaponAmmo[HybridRail] = HybridRailAmmo;
$WeaponAmmo[HybridChain] = HybridChainAmmo;
$WeaponAmmo[HybridQuadLauncher] = HybridQuadAmmo;
$WeaponAmmo[HybridCannon] = HybridCannonAmmo;
$WeaponAmmo[DFMIYA] = DFMIYAAmmo;
$WeaponAmmo[WTShotgun] = WTShotgunAmmo;
$WeaponAmmo[SXH] = SXHAmmo;
$WeaponAmmo[ClashRocket] = ClashRocketAmmo;
$WeaponAmmo[ARPG] = ARPGAmmo;
$WeaponAmmo[Havoc] = HavocAmmo;
$WeaponAmmo[DiscLauncher] = DiscLauncherAmmo;
$WeaponAmmo[sludge] = sludgeAmmo;
$WeaponAmmo[ParticalShotgun] = ParticalShotgunAmmo;
$WeaponAmmo[NapalmRocket] = NapalmRocketAmmo;
$WeaponAmmo[AtomicBomb] = AtomicBombAmmo;
$WeaponAmmo[SAStealth] = SAStealthAmmo;
$WeaponAmmo[HellStorm] = HellStormAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Nitro] = NitroAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[FireMortar] = FireMortarAmmo;
$WeaponAmmo[AnarchyCannon] = "";
$WeaponAmmo[Salvo] = SalvoAmmo;
$WeaponAmmo[ContactMortar] = ContactMortarAmmo;
$WeaponAmmo[AirRaid] = AirRaidAmmo;
$WeaponAmmo[Claymore] = ClaymoreAmmo;
$WeaponAmmo[FusionCannon] = "";
$WeaponAmmo[TimeBomb] = TimeBombAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[RadiationRifle] = "";
$WeaponAmmo[Charger] = "";
$WeaponAmmo[GrazerCannon] = "";
$WeaponAmmo[ShockRfile] = "";
$WeaponAmmo[GatLaser] = "";
$WeaponAmmo[HybridLaser] = "";
$WeaponAmmo[DiscoRifle] = "";
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


function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19,%favItem20,%favItem21,%favItem22,%favItem23,%favItem24,%favItem25,%favItem26,%favItem27,%favItem28,%favItem29,%favItem30,%favItem31,%favItem32,%favItem33,%favItem34,%favItem35,%favItem36,%favItem37,%favItem38,%favItem39,%favItem40,%favItem41,%favItem42,%favItem43,%favItem44,%favItem45,%favItem46,%favItem47,%favItem48,%favItem49,%favItem50)
{
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
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") {
		%extraAmmo = $AmmoPackMax[%item];
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

function isPlayerBusy(%clientId)
{
	// Can't buy things if busy shooting.
	%state = Player::getItemState(%clientId,$WeaponSlot);
	return %state == "Fire" || %state == "Reload";
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
					return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack) {
			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
//				else if(%pack == EnergyPack) {
//					if(Player::getItemCount(%client,"LaserRifle") > 0) {
//						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
//						remoteSellItem(%client,22);						
//					}
//				}	
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);									 
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
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
//				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
//					buyItem(%client,"EnergyPack");
//					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
//				}
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
			%shouldBuy = VehicleStation::checkBuying(%client,%item);
			if(%shouldBuy == 1) {
				teamEnergyBuySell(%player,(%item.price * -1));
				return 1;
			}			
 			else if(%shouldBuy == 2)
				return 1;
		}
		else {
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

ExplosionData invExp
{
	shapeName = "shotgunex.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeScale = 1.0;
	colors[0] = { 50.0, 0.0, 0.0 };
	colors[1] = { 50.0, 0.0, 0.0 };
	colors[2] = { 50.0, 0.0, 0.0 };
	radFactors = { 50.0, 0.0, 0.0 };
};
GrenadeData Fire
{
	bulletShapeName = "shotgunbolt.dts";
	explosionTag = invExp;
	collideWithOwner = true;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.4;
	damageClass = 1;
	damageValue = -100;
	explosionRadius = 5;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 4;
	totalTime = 0.56;
	liveTime = 0.56;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "shotgunex.dts";
};

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
		for(%i=0; %i < 6.28; %i += 1.256) {
			%trans = Vector::add(getBoxCenter(%player), Vector::getFromRot("0 0 " @ %i, 1.3, 1.2));
			Projectile::spawnProjectile("Fire", "0 0 1 0 0 0 0 0 1 " @ %trans, %player, "0 0 -2");
		}
	}
}

function remoteBuyItem(%client,%type)
{
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
//			else if(%item == EnergyPack) { 
//				if(Player::getItemCount(%client,"LaserRifle") > 0) {
//					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser-X");
//					remoteSellItem(%client,22);						
//				}
//                else if(%item == XTremePack) { 
//				if(Player::getItemCount(%client,"LaserRifle") > 0) {
//					Client::sendMessage(%client,0,"Sold XTreme Pack - Auto Selling Laser-X");
//					remoteSellItem(%client,22);						
//				}
//			}
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
	//echo("Throw item: " @ %type @ " " @ %strength);
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
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
					return 0;
			}  
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
				%extraAmmo = $AmmoPackMax[%item];
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
//=======================
$WeaponNum[1] = Blaster;
$WeaponNum[2] = Chaingun;
$WeaponNum[3] = PlasmaGun;
$WeaponNum[4] = GrenadeLauncher;
$WeaponNum[5] = Mortar;
$WeaponNum[6] = DiscLauncher;
$WeaponNum[7] = LaserRifle;
$WeaponNum[8] = Charger;
$WeaponNum[9] = FusionRifle;
$WeaponNum[10] = ShockRfile;
$WeaponNum[11] = RadiationRifle;
$WeaponNum[12] = DiscoRifle;
$WeaponNum[13] = GatLaser;
$WeaponNum[14] = GrazerCannon;
$WeaponNum[15] = HybridLaser;
$WeaponNum[16] = Grappling;
$WeaponNum[17] = QuakeBlaster;
$WeaponNum[18] = HellStorm;
$WeaponNum[19] = FusionCannon;
$WeaponNum[20] = MultiCannon;
$WeaponNum[21] = Glock;
$WeaponNum[22] = WTShotgun;
$WeaponNum[23] = ParticalShotgun;
$WeaponNum[24] = SXH;
$WeaponNum[25] = Havoc;
$WeaponNum[26] = HybridRail;
$WeaponNum[27] = Minigun;
$WeaponNum[28] = ShardGun;
$WeaponNum[29] = DFMIYA;
$WeaponNum[30] = Destroyer;
$WeaponNum[31] = ARPG;
$WeaponNum[32] = HybridChain;
$WeaponNum[33] = PlasmaBlaster;
$WeaponNum[34] = Blaze;
$WeaponNum[35] = PlasmaGat;
$WeaponNum[36] = MeltLaser;
$WeaponNum[37] = SAStealth;
$WeaponNum[38] = NapalmLauncher;
$WeaponNum[39] = NapalmRocket;
$WeaponNum[40] = Magma;
$WeaponNum[41] = ShockWaveC;
$WeaponNum[42] = Nitro;
$WeaponNum[43] = FireMortar;
$WeaponNum[44] = ContactMortar;
$WeaponNum[45] = AirRaid;
$WeaponNum[46] = TimeBomb;
$WeaponNum[47] = AtomicBomb;
$WeaponNum[48] = ClashRocket;
$WeaponNum[49] = ETTR;
$WeaponNum[50] = sludge;
$WeaponNum[51] = Salvo;
$WeaponNum[52] = AnarchyCannon;
$WeaponNum[53] = Claymore;
$WeaponNum[54] = HybridMortar;
$WeaponNum[55] = HybridCannon;
$WeaponNum[56] = HybridRocketLauncher;
$WeaponNum[57] = HybridQuadLauncher;

$MaxWeapon=57;

function remoteNextWeapon(%client)
{
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f2>+!You Have No Weapons!+", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item++;
	if(%item == $MaxWeapon+1)
		%item = 1;
	%weapon = $WeaponNum[%item];
	$CurWeap[%client] = %item;
	if(isSelectableWeapon(%client,%weapon)) {
		Player::useItem(%client,%weapon);
		$CurWeap = %item;
		if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
			break;
	}			
	else
		{ %client.wcyc++; if(%client.wcyc <= $MaxWeapon) remoteNextWeapon(%client); }
	%client.wcyc = ""; // PORT
}

function remotePrevWeapon(%client)
{
	if(Player::getItemClassCount(%client,Weapon) == 0) {
		bottomprint(%client, "<jc><f2>+!You Have No Weapons!+", 1);
		return FALSE;
	}
	%item = $CurWeap[%client];
	%item--;
	if(%item == 0)
		%item = $MaxWeapon;
	%weapon = $WeaponNum[%item];
	$CurWeap[%client] = %item;
	if(isSelectableWeapon(%client,%weapon)) {
		Player::useItem(%client,%weapon);
		if(Player::getMountedItem(%client,$WeaponSlot) == %weapon||Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
			break;
	}			
	else
		{ %client.wcyc++; if(%client.wcyc <= $MaxWeapon) remotePrevWeapon(%client); }
	%client.wcyc = ""; // PORT
}

function selectValidWeapon(%client)
{
	%item = 1;
	for(%weapon = %item++; %weapon != %item; %weapon = %item++) {
		echo(%weapon);
		if(isSelectableWeapon(%client,%weapon)) {
			Player::useItem(%client,%weapon);
			break;
		}
	}
}

function isSelectableWeapon(%client,%weapon)
{
	if(Player::getItemCount(%client,%weapon)) {
		%ammo = $WeaponAmmo[%weapon];
			if(%ammo == ""||Player::getItemCount(%client,%ammo) > 0)
				return true;
		}
	//PORT-OFF: }
	return false;
}
