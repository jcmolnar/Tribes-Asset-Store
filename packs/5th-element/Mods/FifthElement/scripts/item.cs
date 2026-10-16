
$WaitThrowTime = 2;
 $ItemFavoritesKey = "5th";
 $ItemPopTime = 30;
 $ToolSlot=0;
 $WeaponSlot=0;
 $BackpackSlot=1;
 $FlagSlot=2;
 $DefaultSlot=3;


$ExtraSlotA=4;
$ExtraSlotB=5;
$ExtraSlotC=6;
$ExtraSlotD=7;
$ExtraSlotE=8;
$ExtraSlotF=9;
$ExtraSlotG=10;

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
 $AutoUse[TargetMarkLaser] = False;

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
//==================================
$ArmorType[Male, DeathArmor] = DAarmor;
$ArmorType[Female, DeathArmor] = DAarmor;
$ArmorName[DAarmor] = DeathArmor;
//==================================

 $SellAmmo[BulletAmmo] = 25;
 $SellAmmo[PlasmaAmmo] = 5;
 $SellAmmo[DiscAmmo] = 5;
 $SellAmmo[GrenadeAmmo] = 5;
 $SellAmmo[MortarAmmo] = 5;
 $SellAmmo[Beacon] = 5;
 $SellAmmo[Boost] = 5;
 $SellAmmo[Plastique] = 5;
 $SellAmmo[DetBug] = 1;
 $SellAmmo[MineAmmo] = 5;
 $SellAmmo[Grenade] = 5;

 $AmmoPackMax[BulletAmmo] = 150;
 $AmmoPackMax[PlasmaAmmo] = 30;
 $AmmoPackMax[DiscAmmo] = 15;
 $AmmoPackMax[GrenadeAmmo] = 15;
 $AmmoPackMax[MortarAmmo] = 10;
 $AmmoPackMax[MineAmmo] = 3;
 $AmmoPackMax[Grenade] = 5;
 $AmmoPackMax[Beacon] = 3;
 $AmmoPackMax[RepairKit] = 1;
 $AmmoPackItems[0] = BulletAmmo;
 $AmmoPackItems[1] = PlasmaAmmo;
 $AmmoPackItems[2] = DiscAmmo;
 $AmmoPackItems[3] = GrenadeAmmo;
 $AmmoPackItems[4] = Grenade;
 $AmmoPackItems[5] = RepairKit;
 $AmmoPackItems[6] = MineAmmo;
 $AmmoPackItems[7] = MortarAmmo;
 $AmmoPackItems[8] = Beacon;

 $TeamItemMax[DeployableAmmoPack] = 10;
 $TeamItemMax[DeployableInvPack] = 15;
 $TeamItemMax[TurretPack] = 3;
 $TeamItemMax[FlameTurretPack] = 3;
 $TeamItemMax[CameraPack] = 15;
 $TeamItemMax[DeployableSensorJammerPack] = 10;
 $TeamItemMax[PulseSensorPack] = 15;
 $TeamItemMax[MotionSensorPack] = 15;
 $TeamItemMax[ScoutVehicle] = 3;
 $TeamItemMax[HAPCVehicle] = 1;
 $TeamItemMax[LAPCVehicle] = 2;
 $TeamItemMax[Beacon] = 40;
 $TeamItemMax[mineammo] = 35;

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
 $WeaponAmmo[HDiscLauncher] = HDiscAmmo;
 $WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
 $WeaponAmmo[Mortar] = Mortar;
 $WeaponAmmo[LaserRifle] = "";
 $WeaponAmmo[EnergyRifle] = "";

 $AutoUse[RocketLauncher] = True;
 $AutoUse[SniperRifle] = True;
 $AutoUse[WaveGun] = True;
 $AutoUse[Railgun] = True;
 $AutoUse[Vulcan] = True;
 $AutoUse[Silencer] = True;
 $AutoUse[IonGun] = True;
 $AutoUse[HyperB] = True;
 $AutoUse[Omega] = True;

 $ArmorType[Male, ScoutArmor] = sarmor;
 $ArmorType[Male, BursterArmor] = barmor;
 $ArmorType[Male, EngArmor] = earmor;
 $ArmorType[Male, DragArmor] = darmor;
 $ArmorType[Male, CyboArmor] = harmor;
 $ArmorType[Male, SpawnArmor] = spnmale;
 $ArmorType[Female, ScoutArmor] = sfemale;
 $ArmorType[Female, BursterArmor] = bfemale;
 $ArmorType[Female, EngArmor] = earmor;
 $ArmorType[Female, CyboArmor] = harmor;
 $ArmorType[Female, DragArmor] = darmor;
 $ArmorType[Female, SpawnArmor] = spnfemale;
 $ArmorType[Male, SpArmor] = spyarmor;
 $ArmorType[Female, SpArmor] = spyfemale;
 $ArmorType[Male, AlArmor] = aarmor;
 $ArmorType[Female, AlArmor] = afemale;
 $ArmorType[Male, CArmor] = dmarmor;
 $ArmorType[Female, CArmor] = dmfemale;

 $ArmorName[sarmor] = ScoutArmor;
 $ArmorName[barmor] = BursterArmor;
 $ArmorName[spnmale] = SpawnArmor;
 $ArmorName[spnfemale] = SpawnArmor;
 $ArmorName[earmor] = EngArmor;
 $ArmorName[efemale] = EngArmor;
 $ArmorName[harmor] = CyboArmor;
 $ArmorName[darmor] = DragArmor;
 $ArmorName[sfemale] = ScoutArmor;
 $ArmorName[bfemale] = BursterArmor;
 $ArmorName[spyarmor] = SpArmor;
 $ArmorName[spyfemale] = SpArmor;
 $ArmorName[aarmor] = AlArmor;
 $ArmorName[afemale] = AlArmor;
 $ArmorName[dmarmor] = CArmor;
 $ArmorName[dmfemale] = CArmor;

 $SellAmmo[RocketAmmo] = 3;
 $SellAmmo[SniperAmmo] = 15;
 $SellAmmo[RailAmmo] = 25;
 $SellAmmo[SilencerAmmo] = 25;
 $SellAmmo[VulcanAmmo] = 100;
 $SellAmmo[FlamerAmmo] = 150;
 $SellAmmo[HDiscAmmo] = 10;
 $SellAmmo[TrackerMissileAmmo] = 5;

 $AmmoPackMax[RocketAmmo] = 10;
 $AmmoPackMax[SniperAmmo] = 5;
 $AmmoPackMax[RailAmmo] = 5;
 $AmmoPackMax[VulcanAmmo] = 50;
 $AmmoPackMax[FlamerAmmo] = 50;
 $AmmoPackMax[SilencerAmmo] = 10;
 $AmmoPackMax[HDiscAmmo] = 8;
 $AmmoPackItems[9] = RocketAmmo;
 $AmmoPackItems[10] = SniperAmmo;
 $AmmoPackItems[11] = RailAmmo;
 $AmmoPackItems[12] = VulcanAmmo;
 $AmmoPackItems[13] = SilencerAmmo;
 $AmmoPackItems[14] = FlamerAmmo;
 $AmmoPackItems[15] = HDiscAmmo;

 if ($Renegades::detLimit == "")
 {
	$Renegades::detLimit = "15";
 }

 $TeamItemMax[Vengeance] = 2;
 $TeamItemMax[SuicidePack] = $Renegades::detLimit;
 $TeamItemMax[LaserTurret] = 4;
 $TeamItemMax[RailTurret] = 3;
 $TeamItemMax[VulcanTurret] = 2;
 $TeamItemMax[RocketPack] = 4;
 $TeamItemMax[DeployableComPack] = 5;
 $TeamItemMax[DeployableFieldSensorPack] = 2;
 $TeamItemMax[DeployableLRMotionSensorPack] = 2;
 $TeamItemMax[ForceFieldPack] = 10;
 $TeamItemMax[ForceFieldDoorPack] = 10;
 $TeamItemMax[LargeForceFieldPack] = 4;
 $TeamItemMax[LargeForceFieldDoorPack] = 2;
 $TeamItemMax[LaserPack] = 4;
 $TeamItemMax[TripwirePack] = 20;
 $TeamItemMax[DeployableTeleport] = 2;
 $TeamItemMax[PlatformPack] = 25;
 $TeamItemMax[MechPack] = 5;
 $TeamItemMax[HPCPack] = 2;
 $TeamItemMax[ScoutPack] = 5;
 $TeamItemMax[WraithVehicle] = 2;
 $TeamItemMax[JetVehicle] = 5;
 $TeamItemMax[CorAirVehicle] = 2;
 $TeamItemMax[SLAPCVehicle] = 1;
 $TeamItemMax[SpringPack] = 15;
 $TeamItemMax[hologram] = 15;
 $TeamItemMax[SatchelPack] = 25;
 $TeamItemMax[BigInvPack] = 2;
 $TeamItemMax[ShockPack] = 4;
 $TeamItemMax[TargetPack] = 2;

 $VengeanceMax[darmor, VengeanceAmmo] = 30;

 $ixVAmmo[Low] = 1;
 $ixVAmmo[Medium] = 2;
 $ixVAmmo[High] = 3;
 $ixVAmmo[EMP] = 1;
 $ixVAmmo[Pause] = 0;

 $WeaponAmmo[RocketLauncher] = RocketAmmo;
 $WeaponAmmo[SniperRifle] = SniperAmmo;
 $WeaponAmmo[Railgun] = RailAmmo;
 $WeaponAmmo[WaveGun] = "";
 $WeaponAmmo[IonGun] = "";
 $WeaponAmmo[Flamer] = FlamerAmmo;
 $WeaponAmmo[Omega] = "";
 $WeaponAmmo[Silencer] = SilencerAmmo;
 $WeaponAmmo[Vulcan] = VulcanAmmo;
 $WeaponAmmo[TargetMarkLaser] = "";


 function teamEnergyBuySell(%player,%cost) {
 %client = Player::getClient(%player);
 %team = Client::getTeam(%client);
 %station = %player.Station;
 %stationName = GameBase::getDataName(%station);
 if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) {
 %station.Energy += %cost;
 if(%station.Energy < 1) %station.Energy = 0;
 }
 else if($TeamEnergy[%team] != "Infinite") {
 $TeamEnergy[%team] += %cost;
 %client.teamEnergy += %cost;
 }
 }
 function isPlayerBusy(%client) {
 %state = Player::getItemState(%client,$WeaponSlot);
 return %state == "Fire" || %state == "Reload";
 }
 function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19) {
 if (isPlayerBusy(%client)) return;
 %time = getIntegerTime(true) >> 4;
 if(%time <= %client.lastBuyFavTime) return;
 %client.lastBuyFavTime = %time;
 %station = (Client::getOwnedObject(%client)).Station;
 if(%station != "" ) {
 %stationName = GameBase::getDataName(%station);
 if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) %energy = %station.Energy;
 else %energy = $TeamEnergy[Client::getTeam(%client)];
 if(%energy == "Infinite" || %energy > 0) {
 %error = 0;
 %bought = 0;
 %max = getNumItems();
 for (%i = 0;
 %i < %max;
 %i = %i + 1) {
 %item = getItemData(%i);
 if ($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats) {
 %count = Player::getItemCount(%client,%item);
 if(%count) {
 if(%item.className != Armor) teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
 Player::setItemCount(%client, %item, 0);
 }
 }
 }
 for (%i = 0;
 %i < 20;
 %i++) {
 if(%favItem[%i] != "") {
 %item = getItemData(%favItem[%i]);
 if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client), %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) {
 if(!buyItem(%client,%item)) %error = 1;
 else %bought++;
 }
 }
 }
 if(%bought) {
 if(%error) Client::sendMessage(%client,0,"~wC_BuySell.wav");
 else Client::SendMessage(%client,0,"~wbuysellsound.wav");
 }
 updateBuyingList(%client);
 }
 }
 }
 function replenishTeamEnergy(%team) {
 $TeamEnergy[%team] += $incTeamEnergy;
 schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
 }
 function checkResources(%player,%item,%delta,%noMessage) {
 %client = Player::getClient(%player);
 %team = Client::getTeam(%client);
 %pack = Player::getMountedItem(%client,$BackpackSlot);
 %extraAmmo = 0 ;
 if (%pack == ammopack && $AmmoPackMax[%item] != "") {
 %extraAmmo = $AmmoPackMax[%item];
 if(%delta == $ItemMax[Player::getArmor(%client), %item]) %delta = %delta + %extraAmmo;
 }
 if (%pack == Vengeance && $VengeanceMax[Player::getArmor(%client), %item] != "") {
 %extraAmmo = $VengeanceMax[Player::getArmor(%client), %item];
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
 if (%item.price * %delta > %energy) %delta = %energy / %item.price;
 if(%delta < 1 ) {
 if(%noMessage == "") Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
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
 if(GameBase::getDamageLevel(%player) > 0) return 1;
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
 if(%delta + %count >= %max) %delta = %max - %count;
 }
 return %delta;
 }
 function buyItem(%client,%item) {
 %player = Client::getOwnedObject(%client);
 %armor = Player::getArmor(%client);
 %pack = Player::getMountedItem(%client,$BackpackSlot);
 if(%item == DeathArmor && !%client.spawn && !%client.isSuperAdmin) return 0;
 if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
 if (%item.className == Armor) {
 %buyarmor = $ArmorType[Client::getGender(%client), %item];
 if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0) {
 teamEnergyBuySell(%player,$ArmorName[%armor].price);
 if(checkResources(%player,%item,1)) {
 teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
 Player::setArmor(%client,%buyarmor);
 checkMax(%client,%buyarmor);
 armorChange(%client);
 Player::setItemCount(%client, $ArmorName[%armor], 0);
 Player::setItemCount(%client, %item, 1);
 if (%pack == ammopack) fillAmmoPack(%client);
 if (%pack == Vengeance) fillVengeance(%client);
 if (%buyarmor == "barmor" || %buyarmor == "bfemale")
{
Player::setItemCount	(%client, MortarPack,1);
Player::setItemCount	(%client, Booster1Pack,1);
Player::setItemCount	(%client, Booster2Pack,1);
schedule ("Player::mountItem( " @ %client @ ", MortarPack,3);",0.3);
schedule ("Player::mountItem( " @ %client @ ", Booster1Pack,4);",0.3);
schedule ("Player::mountItem( " @ %client @ ", Booster2Pack,5);",0.3);
}
else if (%buyarmor != "barmor" || %buyarmor != "bfemale")
{
Player::unMountItem(%client,3);
Player::unMountItem(%client,4);
Player::unMountItem(%client,5);
}
 if (%buyarmor == "aarmor" || %buyarmor == "afemale")
{
Player::setItemCount	(%client, AL1Pack,1);
Player::setItemCount	(%client, AL2Pack,1);
schedule ("Player::mountItem( " @ %client @ ", AL1Pack,4);",0.3);
schedule ("Player::mountItem( " @ %client @ ", AL2Pack,5);",0.3);
}
else if (%buyarmor != "aarmor" || %buyarmor != "afemale")
{
Player::unMountItem(%client,4);
Player::unMountItem(%client,5);
}
 if (%buyarmor == "harmor")
{
Player::setItemCount	(%client, CY1Pack,1);
Player::setItemCount	(%client, CY2Pack,1);
schedule ("Player::mountItem( " @ %client @ ", CY1Pack,4);",0.3);
schedule ("Player::mountItem( " @ %client @ ", CY2Pack,5);",0.3);
}
else if (%buyarmor != "harmor")
{
Player::unMountItem(%client,4);
Player::unMountItem(%client,5);
}
 if (%buyarmor == "marmor" || %buyarmor == "mfemale")
{
Player::setItemCount	(%client, Merc1Pack,1);
Player::setItemCount	(%client, Merc2Pack,1);
Player::setItemCount	(%client, Merc3Pack,1);
Player::setItemCount	(%client, Merc4Pack,1);
schedule ("Player::mountItem( " @ %client @ ", Merc1Pack,3);",0.3);
schedule ("Player::mountItem( " @ %client @ ", Merc2Pack,4);",0.3);
schedule ("Player::mountItem( " @ %client @ ", Merc3Pack,5);",0.3);
schedule ("Player::mountItem( " @ %client @ ", Merc4Pack,7);",0.3);
}
else if (%buyarmor != "marmor" || %buyarmor != "mfemale")
{
Player::unMountItem(%client,3);
Player::unMountItem(%client,4);
Player::unMountItem(%client,5);
Player::unMountItem(%client,7);
}
if (%buyarmor == "earmor" || %buyarmor == "efemale")
{
Player::setItemCount	(%client, RiflePack1,1);
Player::setItemCount	(%client, RiflePack,1);
schedule ("Player::mountItem( " @ %client @ ", RiflePack1,4);",0.3);
schedule ("Player::mountItem( " @ %client @ ", RiflePack,5);",0.3);
}
else if (%buyarmor != "earmor" || %buyarmor != "efemale")
{
Player::unMountItem(%client,4);
Player::unMountItem(%client,5);
}
 if (%buyarmor == "darmor")
{
Player::setItemCount	(%client, DRPack,1);
Player::setItemCount	(%client, DR2Pack,1);
Player::setItemCount	(%client, DR3Pack,1);
Player::setItemCount	(%client, DR4Pack,1);
schedule ("Player::mountItem( " @ %client @ ", DRPack,3);",0.3);
schedule ("Player::mountItem( " @ %client @ ", DR2Pack,4);",0.3);
schedule ("Player::mountItem( " @ %client @ ", DR3Pack,5);",0.3);
schedule ("Player::mountItem( " @ %client @ ", DR4Pack,7);",0.3);
}
else if (%buyarmor != "darmor")
{
Player::unMountItem(%client,3);
Player::unMountItem(%client,4);
Player::unMountItem(%client,5);
Player::unMountItem(%client,7);
}
if (%buyarmor == "sarmor")
{
Player::setItemCount	(%client, SCPack,1);
schedule ("Player::mountItem( " @ %client @ ", SCPack,4);",0.3);
}
else if (%buyarmor != "sarmor")
{
Player::unMountItem(%client,4);
}
if (%buyarmor == "sfemale")
{
Player::setItemCount	(%client, SCFPack,1);
schedule ("Player::mountItem( " @ %client @ ", SCFPack,4);",0.3);
}
else if (%buyarmor != "sfemale")
{
Player::unMountItem(%client,4);
}
if (%buyarmor == "spyarmor" || %buyarmor == "spyfemale")
{
Player::setItemCount	(%client, SyPack,1);
schedule ("Player::mountItem( " @ %client @ ", SyPack,4);",0.3);
}
else if (%buyarmor != "spyarmor" || %buyarmor != "spyfemale")
{
Player::unMountItem(%client,4);
}
if (%buyarmor == "larmor" || %buyarmor == "lfemale")
{
Player::setItemCount	(%client, RiflePack,1);
schedule ("Player::mountItem( " @ %client @ ", RiflePack,4);",0.3);
}
else if (%buyarmor != "larmor" || %buyarmor != "lfemale")
{
Player::unMountItem(%client,4);
}
//ARMOR ADDONS END
 return 1;
 }
 teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
 }
 }
 else if (%item.className == Backpack) {
 if($TeamItemMax[%item] != "") {
 if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) return 0;
 }
 if (%pack != -1) {
 if(%pack == ammopack) checkMax(%client,%armor);
 else if(%pack == Vengeance) checkMax(%client,%armor);
 else if(%pack == EnergyPack) {
 if(Player::getItemCount(%client,"LaserRifle") > 0) {
 Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
 remoteSellItem(%client,38);
 }
 }
 teamEnergyBuySell(%player,%pack.price);
 Player::decItemCount(%client,%pack);
 }
 if (checkResources(%player,%item,1) || $testCheats) {
 teamEnergyBuySell(%player,%item.price * -1);
 Player::incItemCount(%client,%item);
 Player::useItem(%client,%item);
 if(%item == ammopack) fillAmmoPack(%client);
 if(%item == Vengeance) fillVengeance(%client);
 return 1;
 }
 else if(%pack != -1) {
 teamEnergyBuySell(%player,%pack.price * -1);
 Player::incItemCount(%client,%pack);
 Player::useItem(%client,%pack);
 if(%pack == ammopack) fillAmmoPack(%client);
 if(%pack == Vengeance) fillVengeance(%client);
 }
 }
 else if(%item.className == Weapon) {
 if(checkResources(%player,%item,1)) {
 %max = $MaxWeapons[%armor];
 if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
 buyItem(%client,"EnergyPack");
 Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
 }
 Player::incItemCount(%client,%item);
 teamEnergyBuySell(%player,(%item.price * -1));
 %ammoItem = %item.imageType.ammoType;
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
 else if(%shouldBuy == 2) return 1;
 }
 }
 else {
 if($TeamItemMax[%item] != "") {
 if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) return 0;
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
 function armorChange(%client) {
 %player = Client::getOwnedObject(%client);
 if(%client.respawn == "" && %player.Station != "") {
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
 function remoteBuyItem(%client,%type) {
 if (isPlayerBusy(%client)) return;
 %item = getItemData(%type);
 if(buyItem(%client,%item)) {
 Client::sendMessage(%client,0,"~wbuysellsound.wav");
 updateBuyingList(%client);
 }
 else Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
 }
 function remoteSellItem(%client,%type) {
 if (isPlayerBusy(%client)) return;
 %item = getItemData(%type);
 %player = Client::getOwnedObject(%client);
 if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) {
 if(Player::getItemCount(%client,%item) && %item.className != Armor) {
 %numsell = 1;
 if(%item.className == Ammo || %item.className == HandAmmo) {
 %count = Player::getItemCount(%client, %item);
 if(%count < $SellAmmo[%item]) %numsell = %count;
 else %numsell = $SellAmmo[%item];
 }
 else if (%item == ammopack) checkMax(%client,Player::getArmor(%client));
 else if (%item == Vengeance) checkMax(%client,Player::getArmor(%client));
 else if($TeamItemMax[%item] != "") {
 if(%item.className == Vehicle) $TeamItemCount[(Client::getTeam(%client)) @ %item]--;
 }
 else if(%item == EnergyPack) {
 if(Player::getItemCount(%client,"LaserRifle") > 0) {
 Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
 remoteSellItem(%client,38);
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
 function remoteUseItem(%client,%type) {
 %client.throwStrength = 1;
 %item = getItemData(%type);
 if (%item == Backpack) {
 %item = Player::getMountedItem(%client,$BackpackSlot);
 if(%item == "-1") ixCheckPickup(%client);
 }
 else {
 if (%item == Weapon) %item = Player::getMountedItem(%client,$WeaponSlot);
 }
 if(((%item == SniperRifle) || (%item == Mortar) || (%item == EMPGrenadeLauncher)) && (isPlayerBusy(%client))) {
 Client::sendMessage(%client,0,"Cannot Change weapons until this one has reloaded");
 return;
 }
 Player::useItem(%client,%item);
 }
 function ixCheckPickup(%player) {
 %client = Player::getClient(%player);
 if(!%player.isDeploying) {
 if(GameBase::getLOSinfo(%player,3)) {
 %this = $los::object;
 %name = GameBase::getDataName(%this);
 if((%name.className != Armor) && (%name.className != Vehicle) && (%name.className != Generator)) {
 %thisTeam = GameBase::getTeam(%this);
 %team = Client::getTeam(%client);
 if(%team == %thisTeam) GameBase::virtual(%this,"packUp",$los::position,%client,%player);
 }
 }
 }
 }
 function ixGivePack(%player, %pack, %team) {
 %obj = newObject("","Item",%pack,1,false);
 schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj);
 GameBase::setPosition(%obj,%player.deployPosition);
 $TeamItemCount[%team @ %pack]--;
 playSound(SoundPickupItem,%player.deployPosition);
 %player.isDeploying = flase;
 }
 function ixGetOwnerName(%this) {
 if(Client::getName(%this.owner) == %this.ownerName) return %this.ownerName;
 else return "";
 }
 function ixGetOwnerClient(%this) {
 if(Client::getName(%this.owner) == %this.OwnerName) return %this.owner;
 else return 0;
 }
 function ixToggleDeploy(%this) {
 if(%this.isDeploying) %this.isDeploying = false;
 else %this.isDeploying = true;
 }

 function remoteThrowItem(%client,%type,%strength) {
 if (%client.freeze) return;
 %player = Client::getOwnedObject(%client);
 if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
 if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
 %item = getItemData(%type);
 if (%item == Grenade || %item == MineAmmo) {
 if (%strength < 0) %strength = 0;
 else if (%strength > 100) %strength = 100;
 %client.throwStrength = 0.3 + 0.7 * (%strength / 100);
 Player::useItem(%client,%item);
 }
 }
 }
 }
 function remoteDropItem(%client,%type) {
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
 else Player::dropItem(%client,%item);
 }
 }
 function remoteDeployItem(%client,%type) {
 %item = getItemData(%type);
 Player::deployItem(%client,%item);
 }



 function Item::giveItem(%player,%item,%delta) {
 %armor = Player::getArmor(%player);
 %pack = Player::getMountedItem(%client,$BackpackSlot);
 if($ItemMax[%armor, %item]) {
 %client = Player::getClient(%player);
 if(!%client.strip) {
 if (%item.className == Backpack) {
 if (Player::getMountedItem(%player,$BackpackSlot) == -1) {
 Player::incItemCount(%player,%item);
 Player::useItem(%player,%item);
 Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
 return 1;
 }
 }
 else {
 if (%item.className == Weapon) {
 if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) return 0;
 }
 %extraAmmo = 0 ;
 if (%pack == ammopack && $AmmoPackMax[%item] != "") %extraAmmo = $AmmoPackMax[%item];
 if (%pack == Vengeance && $VengeanceMax[Player::getArmor(%client), %item] != "") %extraAmmo = $VengeanceMax[Player::getArmor(%client), %item];
 %count = Player::getItemCount(%player,%item);
 if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) %delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
 if (%delta > 0) {
 Player::incItemCount(%player,%item,%delta);
 if(%item == "HDiscAmmo") {
 //Player::setItemCount(%player, "HDisc1Ammo", 2);
 //Player::setItemCount(%player, "HDisc2Ammo", 2);
 }
 if(%item == "VulcanAmmo") {
 //Player::setItemCount(%player, "Vulcan1Ammo", 2);
 //Player::setItemCount(%player, "Vulcan2Ammo", 2);
 }
 if (%count == 0 && $AutoUse[%item]) Player::useItem(%player,%item);
 Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
 return %delta;
 }
 }
 }
 return 0;
 }
 }
 $PickupSound[Ammo] = "SoundPickupAmmo";
 $PickupSound[Weapon] = "SoundPickupWeapon";
 $PickupSound[Backpack] = "SoundPickupBackpack";
 $PickupSound[Repair] = "SoundPickupHealth";
 function Item::playPickupSound(%this) {
 %item = Item::getItemData(%this);
 %sound = $PickupSound[%item.className];
 if (%sound != "") playSound(%sound,GameBase::getPosition(%this));
 else {
 playSound(SoundPickupItem,GameBase::getPosition(%this));
 }
 }
 function Item::respawn(%this) {
 if (Item::isRotating(%this)) {
 Item::hide(%this,True);

 schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
 }
 else {
 deleteObject(%this);
 }
 }
 function Item::onAdd(%this) {
 }
 function Item::onCollision(%this,%object) {
 if (getObjectType(%object) == "Player") {
 %item = Item::getItemData(%this);
 %count = Player::getItemCount(%object,%item);
 if (Item::giveItem(%object,%item,Item::getCount(%this))) {
 Item::playPickupSound(%this);
 Item::respawn(%this);
 }
 }
 }
 function Item::onMount(%player,%item) {
 }
 function Item::onUnmount(%player,%item) {
 }
 function Item::onUse(%player,%item) {
 Player::mountItem(%player,%item,$DefaultSlot);
 }
 function Item::pop(%item) {
 GameBase::startFadeOut(%item);
 schedule("deleteObject(" @ %item @ ");",2.5, %item);
 }
 function Item::onDrop(%player,%item) {
 if($matchStarted) 
 {
 if(%item.className != Armor) 
 {
 if(%item == RocketBooster) 
 {	
 ixThrowBooster(%player,%item);
 return 0;
 }
 else 
 {
 %obj = newObject("","Item",%item,1,false);
 schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 addToSet("MissionCleanup", %obj);
 if (Player::isDead(%player)) GameBase::throw(%obj,%player,10,true);
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
 }
 function Item::onDeploy(%player,%item,%pos) {
 }
 function ixThrowBooster(%player,%item) {
 %vel = Item::getVelocity(%player);
 %trans = "0 0 " @ getRandom() @ " 0 0 " @ getRandom() @ " 0 0 " @ getRandom() @ " " @ getBoxCenter(%player);
 if (Player::isDead(%player)) Projectile::spawnProjectile("EjectedBooster",%trans,%player,%vel,%player);
 else {
 Projectile::spawnProjectile("EjectedBooster",%trans,%player,%vel,%player);
 playSound(SoundPickupItem,GameBase::getPosition(%player));
 }
 Player::decItemCount(%player,%item,1);
 }
 function Flag::onUse(%player,%item) {
 Player::mountItem(%player,%item,$FlagSlot);
 }
 ItemImageData FlagImage {
 shapeFile = "flag";
 mountPoint = 2;
 mountOffset = {0,0,-0.35};
 mountRotation = {0,0,0};
 lightType = 2;
 lightRadius = 4;
 lightTime = 1.5;
 lightColor = {1,1,1};
 };

 ItemData Flag {
 description = "Flag";
 shapeFile = "flag";
 validateShape = true;
 imageType = FlagImage;
 showInventory = false;
 shadowDetailMask = 4;
 lightType = 2;
 lightRadius = 4;
 lightTime = 1.5;
 lightColor = {1,1,1};
 };

 ItemData RaceFlag {
 description = "Race Flag";
 shapeFile = "flag";
 imageType = FlagImage;
 showInventory = false;
 shadowDetailMask = 4;
 lightType = 2;
 lightRadius = 4;
 lightTime = 1.5;
 lightColor = {1,1,1};
 };

 ItemData ScoutArmor 
{
 heading = "aArmor";
 description = "Neo-Scout";
 className = "Armor";
 price = 175;
 };

 ItemData SpArmor {
 heading = "aArmor";
 description = "Neo-Spy";
 className = "Armor";
 price = 175;
 }
;
 ItemData LightArmor {
 heading = "aArmor";
 description = "Neo-Sniper";
 className = "Armor";
 price = 175;
 }
;
 ItemData MediumArmor  {
 heading = "aArmor";
 description = "Neo-Mercenary";
 className = "Armor";
 price = 250;
 };
 ItemData BursterArmor {
 heading = "aArmor";
 description = "Neo-Burster";
 className = "Armor";
 price = 250;
 }
;
 ItemData EngArmor {
 heading = "aArmor";
 description = "Neo-Engineer";
 className = "Armor";
 price = 250;
 }
;
 ItemData AlArmor {
 heading = "aArmor";
 description = "Neo-Alien";
 className = "Armor";
 price = 250;
 }
;
 ItemData CyboArmor {
 heading = "aArmor";
 description = "Neo-Cyborg";
 className = "Armor";
 price = 400;
 }
;
 ItemData DragArmor {
 heading = "aArmor";
 description = "Neo-Dragoon";
 className = "Armor";
 price = 450;
 }
;


 ItemData DeathArmor  
{
 heading = "aArmor";
 description = "Death Angel";
 className = "Armor";
 price = 250;
showInventory = false;
 };


 ItemData ScoutVehicle {
 description = "Scout";
 className = "Vehicle";
 heading = "aVehicle";
 price = 600;
 }
;
 ItemData WraithVehicle {
 description = "Wraith";
 className = "Vehicle";
 heading = "aVehicle";
 price = 600;
 }
;
 ItemData JetVehicle {
 description = "Interceptor";
 className = "Vehicle";
 heading = "aVehicle";
 price = 600;
 }
;
 ItemData CorAirVehicle {
 description = "Corsair";
 className = "Vehicle";
 heading = "aVehicle";
 price = 600;
 }
;
 ItemData SLAPCVehicle {
 description = "EMP Bomber LPC";
 className = "Vehicle";
 heading = "bAPCs";
 price = 750;
 }
;
 ItemData LAPCVehicle {
 description = "Bomber LPC";
 className = "Vehicle";
 heading = "bAPCs";
 price = 675;
 }
;
 ItemData HAPCVehicle {
 description = "Stealth HPC";
 className = "Vehicle";
 heading = "bAPCs";
 price = 875;
 }
;
 ItemData Weapon {
 description = "Weapon";
 showInventory = false;
 }
;
 function Weapon::onUse(%player,%item) {
 %ammo = %item.imageType.ammoType;
 if (%ammo == "") {
 Player::mountItem(%player,%item,$WeaponSlot);
 }
 else {
 if (Player::getItemCount(%player,%ammo) > 0) Player::mountItem(%player,%item,$WeaponSlot);
 else {
 Client::sendMessage(Player::getClient(%player),0, strcat(%item.description," has no ammo"));
 }
 }
 }
 ItemData Tool {
 description = "Tool";
 showInventory = false;
 }
;
 function Tool::onUse(%player,%item) {
 Player::mountItem(%player,%item,$ToolSlot);
 }
 ItemData Ammo {
 description = "Ammo";
 showInventory = false;
 }
;
 function Ammo::onDrop(%player,%item) {
 if($matchStarted) {
 %count = Player::getItemCount(%player,%item);
 %delta = $SellAmmo[%item];
 if(%count <= %delta) {
 if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) %delta = %count;
 else %delta = %count - 1;
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
//-----------------------------Blaster----------------------
 ItemImageData BlasterImage 
{
 shapeFile = "energygun";
 mountPoint = 0;
 weaponType = 0;
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
 heading = "bWeapons";
 description = "Blaster";
 className = "Weapon";
 shapeFile = "energygun";
 hudIcon = "blaster";
 shadowDetailMask = 4;
 imageType = BlasterImage;
 price = 85;
 showWeaponBar = true;
 };

//------------------------Chaingun
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
 weaponType = 1;
 reloadTime = 0;
 spinUpTime = 0.6;
 spinDownTime = 3;
 fireTime = 0.2;
 ammoType = BulletAmmo;
 projectileType = ChaingunBullet;
 accuFire = true;
 lightType = 3;
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

//------------------------PlasmaGun
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
 weaponType = 0;
 ammoType = PlasmaAmmo;
 projectileType = PlasmaBolt;
 accuFire = true;
 reloadTime = 0.1;
 fireTime = 0.5;
 lightType = 3;
 lightRadius = 3;
 lightTime = 1;
 lightColor = {1, 1, 0.2 };
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
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = PlasmaGunImage;
 price = 175;
 showWeaponBar = true;
 };

//------------------------Grenade Launcher
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
 projectileType = GrenadeShell;
 accuFire = false;
 reloadTime = 0.5;
 fireTime = 0.5;
 lightType = 3;
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

//--------------------------Mortar
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
 projectileType = MortarShell;
 accuFire = false;
 reloadTime = 0.5;
 fireTime = 2.0;
 lightType = 3;
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
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = MortarImage;
 price = 375;
 showWeaponBar = true;
 };

//-----------------------Disc Launcher
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
 weaponType = 3;
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
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = DiscLauncherImage;
 price = 150;
 showWeaponBar = true;
 };

//-------------------------Hyper Disc
 ItemData HDiscAmmo 
{
 description = "Hyper Disc";
 className = "Ammo";
 shapeFile = "discammo";
 heading = "xAmmunition";
 shadowDetailMask = 4;
 price = 2;
 };

 ItemImageData HDiscLauncherImage 
{
 shapeFile = "disc";
 mountPoint = 0;
 mountOffset = { 0.0, 0.0, 0.0 }; 
 mountRotation = { 0, 7, 0 }; 
 weaponType = 3;
 ammoType = HDiscAmmo;
 projectileType = DiscShell;
 accuFire = true;
 reloadTime = 0.1;
 fireTime = 0.12;
 spinUpTime = 0.2;
 sfxFire = SoundFireDisc;
 sfxActivate = SoundPickUpWeapon;
 sfxReload = SoundDiscReload;
 sfxReady = SoundDiscSpin;
 };

 ItemData HDiscLauncher 
{
 description = "Hyper Spinfuser";
 className = "Weapon";
 shapeFile = "disc";
 hudIcon = "disk";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = HDiscLauncherImage;
 price = 150;
 showWeaponBar = true;
 };


//--------------------Laser Rifle
 ItemImageData LaserRifleImage 
{
 shapeFile = "sniper";
 mountPoint = 0;
 weaponType = 0;
 projectileType = SniperLaser2;
 accuFire = true;
 reloadTime = 1.2;
 fireTime = 0.5;
 minEnergy = 10;
 maxEnergy = 60;
 lightType = 3;
 lightRadius = 2;
 lightTime = 1;
 lightColor = { 1, 0, 0 };
 sfxFire = SoundFireLaser;
 sfxActivate = SoundPickUpWeapon;
 validateShape = true;
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
 };

 function LaserRifle::onUse(%player,%item) {
 if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item);
 else Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use the Laser Rifle.");
 }

//---------------------------Repairgun
 ItemImageData RepairGunImage 
{
 shapeFile = "repairgun";
 mountPoint = 0;
 weaponType = 2;
 projectileType = RepairBolt;
 minEnergy = 3;
 maxEnergy = 10;
 lightType = 3;
 lightRadius = 1;
 lightTime = 1;
 lightColor = { 0.25, 1, 0.25 };
 sfxActivate = SoundPickUpWeapon;
 sfxFire = SoundRepairItem;
 };

 ItemData RepairGun 
{
 description = "Repair-Gun";
 shapeFile = "repairgun";
 className = "Weapon";
 shadowDetailMask = 4;
 imageType = RepairGunImage;
 showInventory = false;
 price = 125;
 };

 function RepairGun::onMount(%player,%imageSlot) {
 Player::trigger(%player,$BackpackSlot,true);
 }

 function RepairGun::onUnmount(%player,%imageSlot) {
 Player::trigger(%player,$BackpackSlot,false);
 }

//-------------------------------------Hyper Blaster
 ItemImageData HyperBImage 
{
 shapeFile = "paintgun";
 mountPoint = 0;
 weaponType = 0;
 reloadTime = 0;
 fireTime = 0.18;
 minEnergy = 7;
 maxEnergy = 8;
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
 shapeFile = "plasma";
 hudIcon = "blaster";
 shadowDetailMask = 4;
 imageType = HyperBImage;
 price = 285;
 showWeaponBar = true;
 };

//-------------------Rocket Launcher
ItemData RocketAmmo 
{
description = "RocketAmmo";
className = "Ammo";
heading = "xAmmunition";
shapeFile = "mortarammo";
shadowDetailMask = 4;
price = 5;
};

ItemImageData RocketLauncherImage 
{
shapeFile = "mortargun";
mountPoint = 0;
mountOffset = { 0.0, 0.0, -0.2 };
weaponType = 0;
ammoType = RocketAmmo;
accuFire = false;
reloadTime = 0.5;
fireTime = 1.5;
lightType = 3;
lightRadius = 3;
lightTime = 1;
lightColor = {0.6, 1, 1.0 };
sfxFire = SoundMissileTurretFire;
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundMortarReload;
};

ItemData RocketLauncher 
{
description = "Rocket Launcher";
className = "Weapon";
shapeFile = "mortargun";
hudIcon = "blaster";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = RocketLauncherImage;
price = 250;
showWeaponBar = true;
};
 
function RocketLauncherImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RocketLauncher]);
	if(%AmmoCount)
	{	
		%cl = Player::getClient(%player);
   %gay = Client::getName(%cl);

		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($DiskerUseMTPack) 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl = Player::GetClient(%target);	 
				%jam = CheckTargetJamming(%target);
				if(%jam == 1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
					Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,$los::object);
					ixApplyKickback(%player, 100, 20);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,1,%tpos);
					
					if(%target)
					{	
						Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>" @ %name, 10);
					}
				}
				else
				{	
					Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
					%name = Client::getName(%target);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,0,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
						Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,$los::object);
						ixApplyKickback(%player, 100, 20);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,12,%tpos);
						%playername = Client::getName(%player);
						if(%target)
						{	
							Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
							%name = Client::getName(%target);
							centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
						      Client::sendMessage(%client,0,"~wmine_act.wav");
						      Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						}
					}
					else
					{	
						Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
					Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,$los::object);
					ixApplyKickback(%player, 100, 20);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);	
				%objname = GameBase::getDataName($los::object);
				if(%object == "Player" || %object == "Flier") 
				{	
					Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
					%name = Client::getName(%targetId);	
                              centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);
				}
				else if(%object == "Turret" || %object =="Sensor")
				{	
					Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
					
                              centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Rocket <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %objname, 10);
				}
				else
  				{
				
				Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
				Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,$los::object);
				ixApplyKickback(%player, 100, 20);
			}

			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1);
				Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,$los::object);
				ixApplyKickback(%player, 100, 20);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

//------------------------Sniper 
ItemData SniperAmmo 
{
 description = "Sniper Bullet";
 className = "Ammo";
 heading = "xAmmunition";
 shapeFile = "ammo1";
 shadowDetailMask = 4;
 price = 5;
 };

 ItemImageData SniperRifleImage 
{
 shapeFile = "sniper";
 mountPoint = 0;
 weaponType = 0;
 ammoType = SniperAmmo;
 projectileType = SniperRound;
 accuFire = true;
 reloadTime = 1.3;
 fireTime = 0.1;
 lightType = 3;
 lightRadius = 2;
 lightTime = 0.5;
 lightColor = { 1.0, 0, 0 };
 sfxFire = debrissmallexplosion;
sfxActivate = SoundPickUpWeapon;
sfxReload = SoundDryFire;
 };

 ItemData SniperRifle 
{
 description = "Sniper Rifle";
 className = "Weapon";
 shapeFile = "sniper";
 hudIcon = "targetlaser";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = SniperRifleImage;
 price = 375;
 showWeaponBar = true;
 };
 
//------------------------------Silencer
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
 projectileType = SilencerBullet;
 accuFire = true;
 reloadTime = 0.65;
 fireTime = 0.0;
 lightType = 3;
 lightRadius = 6;
 lightTime = 2;
 lightColor = { 0, 0, 0 };
 sfxFire = SoundFireMortar;
 sfxActivate = SoundPickUpWeapon;
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

//----------------------------Shockwave
 ItemImageData WaveGunImage 
{
 shapeFile = "grenadeL";
 mountRotation = {0,3.14, 0 };
 mountPoint = 0;
 weaponType = 0;
 minEnergy = 20;
 maxEnergy = 25;
 reloadTime = 1.0;
 projectileType = Shock;
 accuFire = true;
 fireTime = 0.9;
 sfxFire = SoundPlasmaTurretFire;
 sfxActivate = SoundPickUpWeapon;
 };

 ItemData WaveGun 
{
 description = "Shockwave Cannon";
 className = "Weapon";
 shapeFile = "shotgun";
 hudIcon = "disk";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = WaveGunImage;
 price = 250;
 showWeaponBar = true;
 };

//--------------------------------RailGun
 ItemData RailAmmo 
{
 description = "Railgun Bolt";
 className = "Ammo";
 heading = "xAmmunition";
 shapeFile = "ammo1";
 shadowDetailMask = 4;
 price = 5;
 };

 ItemImageData RailgunImage 
{
 shapeFile = "sniper";
 mountPoint = 0;
 weaponType = 0;
 ammoType = RailAmmo;
 projectileType = RailRound;
 accuFire = true;
 reloadTime = 0.2;
 fireTime = 1.2;
 lightType = 3;
 lightRadius = 5;
 lightTime = 2.5;
 lightColor = { 0.1, 0.1, 1.0 };
 sfxFire = SoundMissileTurretFire;
 sfxActivate = SoundPickUpWeapon;
 };

 ItemData Railgun 
{
 description = "Railgun";
 className = "Weapon";
 shapeFile = "sniper";
 hudIcon = "blaster";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = RailgunImage;
 price = 375;
 showWeaponBar = true;
 };

//----------------------------Vulcan
 ItemData VulcanAmmo 
{
 description = "Vulcan Bullet";
 className = "Ammo";
 shapeFile = "ammo1";
 heading = "xAmmunition";
 shadowDetailMask = 4;
 price = 20;
 };

 ItemImageData VulcanImage 
{
 shapeFile = "chaingun";
 mountPoint = 0;
 mountOffset = {0,0,0};
mountRotation = {0,1.57,0};
 weaponType = 0;
 ammoType = VulcanAmmo;
projectileType = VulcanBullet;
 accuFire = true;
 reloadTime = 0;
 fireTime = 0.1;
 spinUpTime = 0.2;
 sfxFire = debrissmallexplosion;
 sfxActivate = SoundPickUpWeapon;
 sfxSpinUp = SoundSpinUp;
 sfxSpinDown = SoundSpinDown;
 };

 ItemData Vulcan 
{
 description = "Vulcan Cannon";
 className = "Weapon";
 shapeFile = "chaingun";
 hudIcon = "chain";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = VulcanImage;
 price = 550;
 showWeaponBar = true;
 }; 

//-------------------------------------FlameThrower
 ItemData FlamerAmmo 
{
 description = "Flame Capsules";
 className = "Ammo";
 shapeFile = "ammo1";
 heading = "xAmmunition";
 shadowDetailMask = 4;
 price = 1;
 };

 ItemImageData FlamerImage 
{
 shapeFile = "GrenadeL";
 mountPoint = 0;
 weaponType = 0;
 reloadTime = 0.15;
 fireTime = 0;
 ammoType = FlamerAmmo;
 minEnergy = 7;
 maxEnergy = 12;
 projectileType = FlamerBolt;
 accuFire = true;
 sfxFire = SoundFlamerz;
 sfxActivate = SoundPickUpWeapon;
 };

 ItemData Flamer 
{
 heading = "bWeapons";
 description = "Flame Thrower";
 className = "Weapon";
 shapeFile = "GrenadeL";
 hudIcon = "plasma";
 shadowDetailMask = 4;
 imageType = FlamerImage;
 price = 385;
 showWeaponBar = true;
 };

//---------------------------IonRifle
 ItemImageData IonGunImage 
{
 shapeFile = "GrenadeL";
 mountPoint = 0;
 weaponType = 0;
 reloadTime = 0;
 fireTime = 0.3;
 minEnergy = 9;
 maxEnergy = 10;
 projectileType = IonBolt;
 accuFire = true;
 sfxFire = SoundFireLaser;
 sfxActivate = SoundPickUpWeapon;
 };

 ItemData IonGun 
{
 heading = "bWeapons";
 description = "Ion Rifle";
 className = "Weapon";
 shapeFile = "GrenadeL";
 hudIcon = "targetlaser";
 shadowDetailMask = 4;
 imageType = IonGunImage;
 price = 250;
 showWeaponBar = true;
 };

//-----------------------------OmegaCannon
 ItemImageData OmegaImage 
{
 shapeFile = "shotgun";
 mountRotation = {0,3.14, 0};
 mountPoint = 0;
 weaponType = 0;
 reloadTime = 0.05;
 fireTime = 0;
 minEnergy = 5;
 maxEnergy = 6;
 //projectileType = OmegaBolt;
 accuFire = false;
 sfxFire = SoundJetHeavy;
 sfxActivate = SoundPickUpWeapon;
 };

 ItemData Omega 
{
 heading = "bWeapons";
 description = "Omega Rifle";
 className = "Weapon";
 shapeFile = "shotgun";
 hudIcon = "energypack";
 shadowDetailMask = 4;
 imageType = OmegaImage;
 price = 385;
 showWeaponBar = true;
 };

function OmegaImage::onFire(%player,%slot)
{
	//echo("Firing Omega");
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("OmegaBolt",%trans,%player,%vel);
	Projectile::spawnProjectile("OmegaBolt2",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[Omega],1);
}
//------------------------------------PlasmaCannon
 ItemImageData PlasmaCannonImage 
{
 shapeFile = "mortargun";
 mountPoint = 0;
 weaponType = 0; // Single Shot
 projectileType = PlasmaCannonBlast;
 accuFire = True;
 reloadTime = 0.5;
 fireTime = 0.2;
 minEnergy = 10;
 maxEnergy = 15;
 lightType = 3; // Weapon Fire
 lightRadius = 5;
 lightTime = 2;
 lightColor = { 0, 0, 1 };
 sfxFire = SoundPlasmaTurretFire;
 sfxActivate = SoundPickUpWeapon;
 sfxReload = SoundGeneratorPower;
 };

 ItemData PlasmaCannon 
{
 description = "Plasma Cannon";
 className = "Weapon";
 shapeFile = "mortargun";
 hudIcon = "plasma";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = PlasmaCannonImage;
 price = 250;
 showWeaponBar = true;
 };

//----------------------------------------ELF
 ItemImageData EnergyRifleImage 
{
 shapeFile = "shotgun";
 mountPoint = 0;
 weaponType = 2;
 projectileType = boltCharge;
 minEnergy = 3;
 maxEnergy = 15;
 reloadTime = 0.2;
 lightType = 3;
 lightRadius = 2;
 lightTime = 1;
 lightColor = { 0.25, 0.25, 0.85 };
 sfxActivate = SoundPickUpWeapon;
 sfxFire = SoundELFIdle;
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
 price = 325;
 };
 
//-------------------------------------TargetLaser
 ItemImageData TargetingLaserImage 
{
 shapeFile = "paintgun";
 mountPoint = 0;
 weaponType = 2;
 projectileType = targetLaser;
 accuFire = true;
 minEnergy = 5;
 maxEnergy = 15;
 reloadTime = 1.0;
 lightType = 3;
 lightRadius = 1;
 lightTime = 1;
 lightColor = {0.25, 1, 0.25 };
 sfxFire = SoundFireTargetingLaser;
 sfxActivate = SoundPickUpWeapon;
 };

 ItemData TargetingLaser 
{
 description = "Targeting Laser";
 className = "Tool";
 shapeFile = "paintgun";
 hudIcon = "targetlaser";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = TargetingLaserImage;
 price = 50;
 showWeaponBar = false;
 };

//-------------------------------------FixIT
 ItemImageData FixitImage 
{
 shapeFile = "repairgun";
 mountPoint = 0;
 weaponType = 2;
 projectileType = RepairBolt;
 minEnergy = 5;
 maxEnergy = 15;
 lightType = 3;
 lightRadius = 1;
 lightTime = 1;
 lightColor = { 0.25, 1, 0.25 };
 sfxFire = SoundRepairItem;
 sfxActivate = SoundPickUpWeapon;
 };

 ItemData Fixit 
{
 description = "Repair Gun";
 className = "Tool";
 shapeFile = "repairgun";
 hudIcon = "targetlaser";
 heading = "bWeapons";
 shadowDetailMask = 4;
 imageType = FixitImage;
 price = 50;
 showWeaponBar = false;
 };
//------------------------------------------------------
LightningData TargetMarkLaserBeam
{
  boltLength = 400.0;
  coneAngle = 35.0;
  damagePerSec = 0.0;
  energyDrainPerSec = 0.0;
  segmentDivisions = 0;	
  numSegments = 1;
  beamWidth = 0.100;
  updateTime = 2000;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.25, 0.25, 0.85 };
  soundId = SoundELFFire;
};

function TargetMarkLaserBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
	if (%shooterId.LaunchAt != %target)
	{
		%shooterID.LaunchAt=%target;
		//Get preferred name
		if (getObjectType(%target) == "Player") 
		%n = Client::getName(Player::getClient(%target));
		else %n = GameBase::getMapName(%target);
		//If better names are blank, grab the data name
		if (%n == "") %n = GameBase::getDataName(%target);
		Client::sendMessage(%shooterId, 0, "Marked " @ %n);
	}
}

ItemImageData TargetMarkLaserImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = TargetMarkLaserBeam;
  accuFire = true;
  minEnergy = 5;
  maxEnergy = 15;
  reloadTime = 1.0;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundFireTargetingLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData TargetMarkLaser 
{
  description = "Target Marking Laser";
  className = "Weapon";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = "bWeapons";
  shadowDetailMask = 4;
  imageType = TargetMarkLaserImage;
	price = 50;
  showWeaponBar = true;
};

function TargetMarkLaser::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<f2>Target Marking Laser:<f0> Used to paint a target for the user's seeking weapons.");
}
//--------------------------------------MissileLauncher
ItemImageData MissileLauncherImage 
{
shapeFile = "mortargun";
mountPoint = 0;
weaponType = 2;
projectileType = LongLockLaser;
minEnergy = 500;
maxEnergy = 10;
lightType = 3;
lightRadius = 1;
lightTime = 1;
lightColor = {0.0, 0.0, 1.0 };
};

ItemData MissileLauncher 
{
description = "Missile Launcher";
shapeFile = "mortargun";
className = "Weapon";
shadowDetailMask = 4;
imageType = MissileLauncherImage;
showInventory = false;
price = 125;
};

function MissileLauncher::onMount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,true);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
}

function MissileLauncher::onUnmount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,false);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
}

ItemImageData LockingLaserImage 
{
shapeFile = "paintgun";
mountPoint = 0;
weaponType = 2;
projectileType = LongLockLaser;
accuFire = true;
minEnergy = 2;
maxEnergy = 20;
reloadTime = 0.0;
lightType = 3;
lightRadius = 1;
lightTime = 1;
lightColor = {0.0, 0.0, 1.0 };
sfxFire = SoundFireTargetingLaser;
sfxActivate = SoundPickUpWeapon;
};

ItemData LockingLaser 
{
description = "Targeting Laser";
className = "Tool";
shapeFile = "paintgun";
hudIcon = "targetlaser";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = LockingLaserImage;
price = 50;
showWeaponBar = false;
};

function LockingLaser::onMount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,true);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
Player::mountItem(%player,$ixVScanner[%client] @ "LockingLaser",$WeaponSlot);
}

ItemImageData LongLockingLaserImage 
{
shapeFile = "paintgun";
mountPoint = 0;
weaponType = 2;
projectileType = LongLockLaser;
accuFire = true;
minEnergy = 2;
maxEnergy = 20;
reloadTime = 0.0;
lightType = 3;
lightRadius = 1;
lightTime = 1;
lightColor = {0.0, 0.0, 1.0 };
sfxFire = SoundFireTargetingLaser;
sfxActivate = SoundPickUpWeapon;
};

ItemData LongLockingLaser 
{
description = "Targeting Laser";
className = "Tool";
shapeFile = "paintgun";
hudIcon = "targetlaser";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = LongLockingLaserImage;
price = 50;
showWeaponBar = false;
};

function LongLockingLaser::onMount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,true);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
}

function LongLockingLaser::onUnmount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,false);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
}

ItemImageData MediumLockingLaserImage 
{
shapeFile = "paintgun";
mountPoint = 0;
weaponType = 2;
projectileType = MediumLockLaser;
accuFire = true;
minEnergy = 2;
maxEnergy = 20;
reloadTime = 0.0;
lightType = 3;
lightRadius = 1;
lightTime = 1;
lightColor = {0.0, 0.0, 1.0 };
sfxFire = SoundFireTargetingLaser;
sfxActivate = SoundPickUpWeapon;
};

ItemData MediumLockingLaser 
{
description = "Targeting Laser";
className = "Tool";
shapeFile = "paintgun";
hudIcon = "targetlaser";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = MediumLockingLaserImage;
price = 50;
showWeaponBar = false;
};

function MediumLockingLaser::onMount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,true);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
}

function MediumLockingLaser::onUnmount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,false);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
}

ItemImageData ShortLockingLaserImage 
{
shapeFile = "paintgun";
mountPoint = 0;
weaponType = 2;
projectileType = ShortLockLaser;
accuFire = true;
minEnergy = 2;
maxEnergy = 20;
reloadTime = 0.0;
lightType = 3;
lightRadius = 1;
lightTime = 1;
lightColor = { 0.0, 0.0, 1.0 };
sfxFire = SoundFireTargetingLaser;
sfxActivate = SoundPickUpWeapon;
};

ItemData ShortLockingLaser 
{
description = "Targeting Laser";
className = "Tool";
shapeFile = "paintgun";
hudIcon = "targetlaser";
heading = "bWeapons";
shadowDetailMask = 4;
imageType = ShortLockingLaserImage;
price = 50;
showWeaponBar = false;
};

function ShortLockingLaser::onMount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,true);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
}

function ShortLockingLaser::onUnmount(%player,%imageSlot) {
Player::trigger(%player,$BackpackSlot,false);
%client = Gamebase::GetControlClient(%player);
$ixLockTime[%client] = 0;
}

//------------------------------------------------------------------------------------------
 ItemData Backpack 
 {description = "Backpack"; 
 showInventory = false;
};

 function Backpack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::trigger(%player,$BackpackSlot);
 }
 }

 ItemImageData DeployableInvPackImage 
{
 shapeFile = "invent_remote";
 mountPoint = 2;
 mountOffset = {0, -0.12, -0.3 };
 mountRotation = {0, 0, 0 };
 mass = 2.5;
 firstPerson = false;
 };

 ItemData DeployableInvPack 
{
 description = "Inventory Station";
 shapeFile = "invent_remote";
 className = "Backpack";
 heading = "dDeployables";
 shadowDetailMask = 4 ;
 imageType = DeployableInvPackImage;
 mass = 2.0;
 elasticity = 0.2;
 price = $RemoteInvEnergy + 200;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function DeployableInvPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function DeployableInvPack::onDeploy(%player,%item,%pos) {
 if (DeployableInvPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function DeployableInvPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %turret = newObject("ammounit_remote","StaticShape","DeployableInvStation",true);
 addToSet("MissionCleanup", %turret);
 %rot = GameBase::getRotation(%player);
 %clName = Client::getName(%client);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
//***
 Gamebase::setMapName(%turret,"RMT Inv Station#" @ $totalNumTurrets++ @ " " @ %clName);
//***
 addToSet(%client.deployables, %turret);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Inventory Station deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%turret) @ "DeployableInvPack"]++;
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
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData DeployableAmmoPackImage {
 shapeFile = "ammounit_remote";
 mountPoint = 2;
 mountOffset = {
 0, -0.1, -0.3 }
;
 mountRotation = {
 0, 0, 0 }
;
 mass = 1.0;
 firstPerson = false;
 }
;
 ItemData DeployableAmmoPack {
 description = "Ammo Station";
 shapeFile = "ammounit_remote";
 className = "Backpack";
 heading = "dDeployables";
 shadowDetailMask = 4;
 imageType = DeployableAmmoPackImage;
 mass = 2.0;
 elasticity = 0.2;
 price = $RemoteAmmoEnergy;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function DeployableAmmoPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function DeployableAmmoPack::onDeploy(%player,%item,%pos) {
 if (DeployableAmmoPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function DeployableAmmoPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %turret = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
 addToSet("MissionCleanup", %turret);
 %rot = GameBase::getRotation(%player);
 %clName = Client::getName(%client);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
//***
 Gamebase::setMapName(%turret,"RMT Ammo Station#" @ $totalNumTurrets++ @ " " @ %clName);
//***
 addToSet(%client.deployables, %turret);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Ammo Station deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%turret) @ "DeployableAmmoPack"]++;
 echo("MSG: ",%client," deployed an Ammo Station");
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData DeployableComPackImage {
 shapeFile = "ammounit_remote";
 mountPoint = 2;
 mountOffset = {
 0, -0.12, -0.3 }
;
 mountRotation = {
 0, 0, 0 }
;
 mass = 4.5;
 firstPerson = false;
 }
;
 ItemData DeployableComPack {
 description = "Command Station";
 shapeFile = "ammounit_remote";
 className = "Backpack";
 heading = "dDeployables";
 shadowDetailMask = 4 ;
 imageType = DeployableComPackImage;
 mass = 4.0;
 elasticity = 0.2;
 price = $RemoteComEnergy + 200;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function DeployableComPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function DeployableComPack::onDeploy(%player,%item,%pos) {
 if (DeployableComPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function DeployableComPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %turret = newObject("comunit_remote","StaticShape","DeployableComStation",true);
 %clName = Client::getName(%client);
 addToSet("MissionCleanup", %turret);
 %rot = GameBase::getRotation(%player);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
//***
 Gamebase::setMapName(%turret,"RMT Command Station#" @ $totalNumTurrets++ @ " " @ %clName);
//***
 addToSet(%client.deployables, %turret);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Command Station deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%turret) @ "DeployableComPack"]++;
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
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData EnergyPackImage {
 shapeFile = "jetPack";
 weaponType = 2;
 mountPoint = 2;
 mountOffset = {
 0, -0.1, 0 }
;
 minEnergy = -3;
 maxEnergy = -5;
 firstPerson = false;
 }
;
 ItemData EnergyPack {
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
 }
;
 function EnergyPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 }
 function EnergyPack::onMount(%player,%item) {
 Player::trigger(%player,$BackpackSlot,true);
 }
 function EnergyPack::onUnmount(%player,%item) {
 if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) Player::unmountItem(%player,$WeaponSlot);
 }
 ItemImageData RepairPackImage {
 shapeFile = "armorPack";
 mountPoint = 2;
 weaponType = 2;
 minEnergy = 0;
 maxEnergy = 0;
 mountOffset = {
 0, -0.05, 0 }
;
 mountRotation = {
 0, 0, 0 }
;
 firstPerson = false;
 }
;
 ItemData RepairPack {
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
 }
;
 function RepairPack::onUnmount(%player,%item) {
 if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
 Player::unmountItem(%player,$WeaponSlot);
 }
 }
 function RepairPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::mountItem(%player,RepairGun,$WeaponSlot);
 }
 }
 function RepairPack::onDrop(%player,%item) {
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
 ItemImageData ShieldPackImage {
 shapeFile = "shieldPack";
 mountPoint = 2;
 weaponType = 2;
 minEnergy = 6;
 maxEnergy = 9;
 sfxFire = SoundShieldOn;
 firstPerson = false;
 }
;
 ItemData ShieldPack {
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
 }
;
 function ShieldPackImage::onActivate(%player,%imageSlot) {
 Client::sendMessage(Player::getClient(%player),0,"Shield On");
 %player.shieldStrength = 0.012;
 }
 function ShieldPackImage::onDeactivate(%player,%imageSlot) {
 Client::sendMessage(Player::getClient(%player),0,"Shield Off");
 Player::trigger(%player,$BackpackSlot,false);
 %player.shieldStrength = 0;
 }
 ItemImageData SensorJammerPackImage {
 shapeFile = "sensorjampack";
 mountPoint = 2;
 weaponType = 2;
 maxEnergy = 10;
 sfxFire = SoundJammerOn;
 mountOffset = { 0, -0.05, 0 };
 mountRotation = { 0, 0, 0 };
 firstPerson = false;
 };
 
 ItemData SensorJammerPack {
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
 }
;
 function SensorJammerPackImage::onActivate(%player,%imageSlot) {
 Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
 %rate = Player::getSensorSupression(%player) + 20;
 Player::setSensorSupression(%player,%rate);
 }
 function SensorJammerPackImage::onDeactivate(%player,%imageSlot) {
 Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
 %rate = Player::getSensorSupression(%player) - 20;
 Player::setSensorSupression(%player,%rate);
 Player::trigger(%player,$BackpackSlot,false);
 }
 ItemImageData CloakingDeviceImage {
 shapeFile = "sensorjampack";
 mountPoint = 2;
 weaponType = 2;
 maxEnergy = 10;
 sfxFire = SoundJammerOn;
 mountOffset = { 0, -0.05, 0 };
 mountRotation = { 0, 0, 0 };
 firstPerson = false;
 };

 ItemData CloakingDevice {
 description = "Cloaking Device-Shield";
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

 function CloakingDeviceImage::onActivate(%player,%imageSlot) {
 %clientId = Player::getClient(%player);
 GameBase::startFadeout(%player);
 Client::sendMessage(%clientId,0,"Cloaking Device On");
 %rate = Player::getSensorSupression(%player) + 3;
 Player::setSensorSupression(%player,%rate);
 %player.guiLock = true;
 %c = Player::getClient(%player);
 %c.guiLock = true;
 %clientId.ghostDoneFlag = true;
 %player.shieldStrength = 0.006;
 %clientId.Ghosting = true;
 }

 function CloakingDeviceImage::onDeactivate(%player,%imageSlot) {
 %clientId = Player::getClient(%player);
 GameBase::startFadein(%player);
 Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
 %rate = Player::getSensorSupression(%player) - 3;
 Player::setSensorSupression(%player,%rate);
 Player::trigger(%player,$BackpackSlot,false);
 %player.guiLock = "";
 %c = Player::getClient(%player);
 %player.shieldStrength = 0;
 %c.guiLock = "";
 %clientId.Ghosting = false;
 }

ItemImageData HeatSinkImage {
shapeFile = "jetPack";
weaponType = 2;
mountPoint = 2;
mountOffset = {0, -0.1, 0.15};
mountRotation = {0, 3.14159, 0};
minEnergy = -1;
maxEnergy = -3;
firstPerson = false;
};

ItemData HeatSink {
description = "Nitrogen Jetpack";
shapeFile = "jetPack";
className = "Backpack";
heading = "cBackpacks";
shadowDetailMask = 4;
imageType = HeatSinkImage;
price = 250;
hudIcon = "targetlaser";
showWeaponBar = true;
hiliteOnActive = true;
};

function HeatSink::onUse(%player,%item) {
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
}
function HeatSink::onMount(%player,%item) {
%client = Player::getClient(%player);
Bottomprint(%client, "This pack will mask your heat signature making you invisible to Anti-Aricraft Guns and Missile Turrets.");
Player::trigger(%player,$BackpackSlot,true);
}
//-------------------
 ItemImageData StealthShieldPackImage {
 shapeFile = "shieldPack";
 mountPoint = 2;
 weaponType = 2;
 minEnergy = 7;
 maxEnergy = 10;
 sfxFire = SoundShieldOn;
 firstPerson = false;
 };

 ItemData StealthShieldPack {
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

 function StealthShieldPackImage::onActivate(%player,%imageSlot) {
 Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
 %player.shieldStrength = 0.012;
 %rate = Player::getSensorSupression(%player) + 2;
 Player::setSensorSupression(%player,%rate);
 }
 function StealthShieldPackImage::onDeactivate(%player,%imageSlot) {
 Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
 Player::trigger(%player,$BackpackSlot,false);
 %player.shieldStrength = 0;
 %rate = Player::getSensorSupression(%player) - 2;
 Player::setSensorSupression(%player,%rate);
 }

 ItemData VengeanceAmmo {
 description = "Vengeance Ammo";
 className = "Ammo";
 shapeFile = "ammo2";
 heading = "xAmmunition";
 shadowDetailMask = 4;
 price = 5;
 };
 
 ItemImageData VengeanceImage {
 shapeFile = "remoteturret";
 mountPoint = 2;
 weaponType = 2;
 minEnergy = 0;
 maxEnergy = 0;
 mountOffset = {0, 0, 0 };
 mountRotation = {0, 0, 0 };
 firstPerson = false;
 ammoType = VengeanceAmmo;
 };

 ItemData Vengeance {
 description = "Vengeance Missile Pack";
 shapeFile = "remoteturret";
 className = "Backpack";
 heading = "cBackpacks";
 shadowDetailMask = 4;
 imageType = VengeanceImage;
 price = 625;
 hudIcon = "targetlaser";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function Vengeance::onMount(%player,%item)
 {
 $TeamItemCount[GameBase::getTeam(%player) @ "Vengenace"]++;
 }
 function Vengeance::onUnmount(%player,%item) 
 {
 %weapon = Player::getMountedItem(%player,$WeaponSlot);
 if ((%weapon == MissileLauncher) || (%weapon == LongLockingLaser) || (%weapon == MediumLockingLaser) || (%weapon == ShortLockingLaser)) 
 {
 Player::unmountItem(%player,$WeaponSlot);
 }
 }
 function Vengeance::onUse(%player,%item) 
 {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
 {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 %this = Player::getMountedItem(%player,$WeaponSlot);
 if(ixCheckVengeance(GameBase::getOwnerClient(%player), %this)) 
 {
 Player::mountItem(%player,LockingLaser,$WeaponSlot);
 }
 }
 }
 function Vengeance::onDrop(%player,%item) 
 {
 if($matchStarted) 
 {
 %mounted = Player::getMountedItem(%player,$WeaponSlot);
 if ((%mounted == MissileLauncher) || (%mounted == LockingLaser)) Player::unmountItem(%player,$WeaponSlot);
 else Player::mountItem(%player,%mounted,$WeaponSlot);
 %item = Item::onDrop(%player,%item);
 %pCount = Player::getItemCount(%player, "VengeanceAmmo");
 Player::decItemCount(%player,"VengeanceAmmo",%pCount);
 %item.VengeanceAmmo = %pCount;
 }
 }
 function Vengeance::onCollision(%this,%object) 
 {
 if (getObjectType(%object) == "Player") 
 {
 %item = Item::getItemData(%this);
 %count = Player::getItemCount(%object,%item);
 if (Item::giveItem(%object,%item,Item::getCount(%this))) 
 {
 Item::playPickupSound(%this);
 Player::incItemCount(%object,"VengeanceAmmo",%this.VengeanceAmmo);
 Item::respawn(%this);
 }
 }
 }
 function fillVengeance(%client) 
 {
 %player = Client::getOwnedObject(%client);
 %item = "VengeanceAmmo";
 %maxnum = checkResources(%player,%item,$VengeanceMax[Player::getArmor(%client), %item]);
 if(%maxnum) 
 {
 Player::incItemCount(%client,%item,%maxnum);
 teamEnergyBuySell(%player,%item.price * %maxnum * -1);
 } 
 }

 ItemImageData ImpulsePackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 weaponType = 2;
 //sfxFire = SoundFireMortar;
 sfxReady = SoundDryFire;
 reloadTime = 3.0;
 minEnergy = 0;
 maxEnergy = 0;
 mountOffset = { 0, -0.05, 0 };
 mountRotation = { 0, 0, 0 };
 firstPerson = false;
 };

 ItemData ImpulsePack {
 description = "Impulse Pack";
 shapeFile = "AmmoPack";
 className = "Backpack";
 heading = "cBackpacks";
 imageType = ImpulsePackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 325;
 hudIcon = "ammopack";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function ImpulsePackImage::onActivate(%player,%imageSlot) {
 %e = GameBase::getEnergy(%player);
 %client = Player::getClient(%player);
 if (%e >= 40) {
 GameBase::setEnergy(%player,%e-20);
 Client::sendMessage(Player::getClient(%player),0,"Impulse Applied");
 if(GameBase::isAtRest(%player)) Player::applyImpulse(%player, Vector::getFromRot(GameBase::getRotation(%client),0,525));
 else Player::applyImpulse(%player, Vector::getFromRot(GameBase::getRotation(%client),400,200));
 Player::trigger(%player,$BackpackSlot,false);
 }
 else {
 Client::sendMessage(Player::getClient(%player),1,"Insufficent Energy to apply impulse.~waccess_denied.wav");
 Player::trigger(%player,$BackpackSlot,false);
 }
 }
 function ImpulsePackImage::onDeactivate(%player,%imageSlot) {
 Player::trigger(%player,$BackpackSlot,false);
 }
 ItemImageData LaptopImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = { 0, -0.03, 0 };
 weaponType = 2;
 minEnergy = -1;
 maxEnergy = -3;
 mass = 0.5;
 firstPerson = false;
 };

 ItemData Laptop {
 description = "Command Laptop";
 shapeFile = "ammounit_remote";
 className = "Backpack";
 heading = "cBackpacks";
 shadowDetailMask = 4;
 imageType = LaptopImage;
 price = 650;
 hudIcon = "energypack";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function Laptop::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 }
 function Laptop::onMount(%player,%item) {
 Player::trigger(%player,$BackpackSlot,true);
 }
 function Laptop::onUnmount(%player,%item) {
 }
 ItemImageData SuicidePackImage {
 shapeFile = "magcargo";
 mountPoint = 2;
 mountOffset = { 0, -0.5, -0.3 };
 mountRotation = { 0, 0, 0 };
 mass = 2.5;
 firstPerson = false;
 };

 ItemData SuicidePack {
 description = "DetPack";
 shapeFile = "magcargo";
 className = "Backpack";
 heading = "cBackpacks";
 imageType = SuicidePackImage;
 shadowDetailMask = 4;
 mass = 2.5;
 elasticity = 0.2;
 price = 450;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function SuicidePack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function SuicidePack::onUnmount(%player,%item) {
 }
 function SuicidePack::onDeploy(%player,%item,%pos) {
 if (SuicidePack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function SuicidePack::deployShape(%player,%item) {
 Player::unmountItem(%player,$BackpackSlot);
 %obj = newObject("","Mine","Suicidebomb2");
 addToSet("MissionCleanup", %obj);
 %client = Player::getClient(%player);
 GameBase::throw(%obj,%player,4,false);
 Client::sendMessage(%client,1,"Det Pack will destruct in 15 seconds");
 $TeamItemCount[GameBase::getTeam(%player) @ "SuicidePack"]++;
 }

 ItemImageData AmmoPackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = { 0, -0.03, 0 };
 firstPerson = false;
 };

 ItemData AmmoPack {
 description = "Ammo Pack";
 shapeFile = "AmmoPack";
 className = "Backpack";
 heading = "cBackpacks";
 imageType = AmmoPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 325;
 hudIcon = "ammopack";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function AmmoPack::onDrop(%player, %item) {
 if($matchStarted) {
 %item = Item::onDrop(%player,%item);
 for(%i = 0; %i < 16 ; %i = %i +1) {
 %numPack = 0;
 %ammoItem = $AmmoPackItems[%i];
 %maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
 %pCount = Player::getItemCount(%player, %ammoItem);
 if(%pCount > %maxnum) {
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
 %item.MortarAmmo  = %numPack;
 }
 else if(%i == 6) {
 %item.RocketAmmo = %numPack;
 }
 else if(%i == 7) {
 %item.SniperAmmo = %numPack;
 }
 else if(%i == 8) {
 %item.RailAmmo = %numPack;
 }
 else if(%i == 9) {
 %item.SilencerAmmo = %numPack;
 }
 else if(%i == 10) {
 %item.VulcanAmmo = %numPack;
 }
 else if(%i == 11) {
 %item.Beacon = %numPack;
 }
 else if(%i == 12) {
 %item.MineAmmo = %numPack;
 }
 else if(%i == 13) {
 %item.FlamerAmmo = %numPack;
 }
 else if(%i == 14) {
 %item.HDiscAmmo = %numPack;
 }
 else {
 %item.RepairKit = %numPack;
 }
 }
 }
 }
 function AmmoPack::onCollision(%this,%object) {
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
 function checkPacksAmmo(%player, %item) {
 for(%i = 0; %i < 16 ; %i = %i +1) {
 %ammoItem = $AmmoPackItems[%i];
 if(%i == 0) {
 %numAdd = %item.BulletAmmo;
 }
 else if(%i == 1) {
 %numAdd = %item.PlasmaAmmo;
 }
 else if(%i == 2) {
 %numAdd = %item.DiscAmmo;
 }
 else if(%i == 3) {
 %numAdd = %item.GrenadeAmmo;
 }
 else if(%i == 4) {
 %numAdd = %item.Grenade;
 }
 else if(%i == 5) {
 %numAdd = %item.MortarAmmo;
 }
 else if(%i == 6) {
 %numAdd = %item.RocketAmmo;
 }
 else if(%i == 7) {
 %numAdd = %item.SniperAmmo;
 }
 else if(%i == 8) {
 %numAdd = %item.RailAmmo;
 }
 else if(%i == 9) {
 %numAdd = %item.SilencerAmmo;
 }
 else if(%i == 10) {
 %numAdd = %item.VulcanAmmo;
 }
 else if(%i == 11) {
 %numAdd = %item.Beacon;
 }
 else if(%i == 12) {
 %numAdd = %item.MineAmmo;
 }
 else if(%i == 13) {
 %numAdd = %item.FlamerAmmo;
 }
 else if(%i == 14) {
 %numAdd = %item.HDiscAmmo;
 }
 else {
 %numAdd = %item.RepairKit;
 }
 Player::incItemCount(%player,%ammoItem,%numAdd);
 }
 }
 function fillAmmoPack(%client) {
 %player = Client::getOwnedObject(%client);
 for(%i = 0; %i < 16 ; %i = %i +1) {
 %item = $AmmoPackItems[%i];
 %maxnum = $AmmoPackMax[%item];
 %maxnum = checkResources(%player,%item,%maxnum);
 if(%maxnum) {
 Player::incItemCount(%client,%item,%maxnum);
 teamEnergyBuySell(%player,%item.price * %maxnum * -1);
 }
 }
 }



ItemData TrackerMissileAmmo
{
  description = "Homing Missiles";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "rocket";
  shadowDetailMask = 4;
  price = 50;
};

SeekingMissileData TrackerMissile
{
  bulletShapeName = "rocket.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.8;
  damageType = $MissileDamageType;
  explosionRadius = 9.5;
  kickBackStrength = 175.0;
  muzzleVelocity = 72.0;
  totalTime = 10;
  liveTime = 10;
  seekingTurningRadius = 4;
  nonSeekingTurningRadius = 20.0;
  proximityDist = 1.5;
  smokeDist = 500;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
};

ItemImageData TrackerMissilePackImage 
{
  shapeFile = "mortargun";
  mountPoint = 2;
  mountOffset = { 0.4, 0.1, 0.35 };
  mountRotation = { 0.2, 0, 0 };
  weaponType = 0;
  ammoType = TrackerMissileAmmo;
  projectileType = TrackerMissile;
  accuFire = true;
  reloadTime = 5.0;
  fireTime = 0.0;
  lightType = 3;
  lightRadius = 3;
  lightTime = 1;
  lightColor = { 0.6, 1, 1.0 };
  sfxFire = SoundMissileTurretFire;
  sfxReload = SoundMortarReload;
};

ItemData TrackerMissilePack 
{
  description = "Homing Missile Cannon";
  shapeFile = "mortargun";
  className = "Backpack";
  heading = "cBackpacks";
  shadowDetailMask = 4;
  imageType = TrackerMissilePackImage;
  price = 500;
  hudIcon = "mortar";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function TrackerMissilePack::onUse(%player,%item) 
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else if (Player::getItemCount(%player, TrackerMissileAmmo) > 0 && !%player.TrackerMissileAirborn)
	{
		%player.TrackerMissileAirborn = True;
		Player::decItemCount(%player, TrackerMissileAmmo);
		%client=Player::GetClient(%player);
		Projectile::SpawnProjectile(TrackerMissile, GameBase::GetMuzzleTransform(%player), %player, 0, %client.LaunchAt);  
		schedule(%player @ ".TrackerMissileAirborn = False;", 2, %player);
	}
}

function TrackerMissilePack::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<f2>Homing Missile Cannon:<f0> Mark a person or item with the <f3>Target Marking Laser <F2>in order to use properly.");
}

//---------------------------------------------------------------------



 ItemImageData MotionSensorPackImage {
 shapeFile = "sensor_small";
 mountPoint = 2;
 mountOffset = {
 0, 0, 0.1 }
;
 mountRotation = {
 1.57, 0, 0 }
;
 firstPerson = false;
 }
;
 ItemData MotionSensorPack {
 description = "Motion Sensor";
 shapeFile = "sensor_small";
 className = "Backpack";
 heading = "fSensors";
 imageType = MotionSensorPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 125;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function MotionSensorPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function MotionSensorPack::onDeploy(%player,%item,%pos) {
 if (MotionSensorPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 $TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++;
 }
 }
 function MotionSensorPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
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
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }

 ItemImageData PulseSensorPackImage {
 shapeFile = "radar_small";
 mountPoint = 2;
 mountOffset = {
 0, 0, 0.1 }
;
 mountRotation = {
 1.57, 0, 0 }
;
 firstPerson = false;
 }
;
 ItemData PulseSensorPack {
 description = "Pulse Sensor";
 shapeFile = "radar_small";
 className = "Backpack";
 heading = "fSensors";
 imageType = PulseSensorPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 125;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function PulseSensorPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function PulseSensorPack::onDeploy(%player,%item,%pos) {
 if (PulseSensorPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 $TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
 }
 }
//---------------------------------------------------------
 function PulseSensorPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
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
 %mSensor = newObject("","Sensor",DeployablePulseSensor,true);
 addToSet("MissionCleanup", %mSensor);
 GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
 GameBase::setRotation(%mSensor,%rot);
 GameBase::setPosition(%mSensor,$los::position);
 Gamebase::setMapName(%mSensor,"Pulse Sensor");
 Client::sendMessage(%client,0,"Pulse Sensor deployed");
 playSound(SoundPickupBackpack,$los::position);
 echo("MSG: ",%client," deployed a Pulse Sensor");
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
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData DeployableSensorJamPackImage {
 shapeFile = "sensor_jammer";
 mountPoint = 2;
 mountOffset = {
 0, 0.03, 0.1 }
;
 mountRotation = {
 1.57, 0, 0 }
;
 firstPerson = false;
 }
;
 ItemData DeployableSensorJammerPack {
 description = "Sensor Jammer";
 shapeFile = "sensor_jammer";
 className = "Backpack";
 heading = "fSensors";
 imageType = DeployableSensorJamPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 225;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function DeployableSensorJammerPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function DeployableSensorJammerPack::onDeploy(%player,%item,%pos) {
 if (DeployableSensorJammerPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 $TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
 }
 }
//---------------------------------------------------------
 function DeployableSensorJammerPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
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
 %mSensor = newObject("","Sensor",DeployableSensorJammer,true);
 addToSet("MissionCleanup", %mSensor);
 GameBase::setTeam(%mSensor,GameBase::getTeam(%player));
 GameBase::setRotation(%mSensor,%rot);
 GameBase::setPosition(%mSensor,$los::position);
 Gamebase::setMapName(%mSensor,"Sensor Jammer");
 Client::sendMessage(%client,0,"Sensor Jammer deployed");
 playSound(SoundPickupBackpack,$los::position);
 echo("MSG: ",%client," deployed a Sensor Jammer");
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
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
//---------------------------------------------------------
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
 heading = "fSensors";
 shadowDetailMask = 4	;
 imageType = DeployableLRMotionSensorPackImage;
 mass = 2.5;
 elasticity = 0.2;
 price = 750;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
};

function DeployableLRMotionSensorPack::onUse(%player,%item)
 {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }

 function DeployableLRMotionSensorPack::onDeploy(%player,%item,%pos)
 {
 if (DeployableLRMotionSensorPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }	

 function DeployableLRMotionSensorPack::deployShape(%player,%item)
 {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape") {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player); 
 %DTPad = newObject("","Sensor",DeployableLongRangeMotionSensor,true);
 addToSet("MissionCleanup", %DTPad);
 GameBase::setTeam(%DTPad,GameBase::getTeam(%player));
 GameBase::setPosition(%DTPad,Vector::add($los::position, "0 0 -0.05"));
 GameBase::setRotation(%DTPad, %rot);
 Gamebase::setMapName(%DTPad,"Long Range Motion Sensor");
 %clName = Client::getName(%client);
 %Lrmotion.owner = %client;
 %Lrmotion.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Long Range Motion Sensor deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "DeployableLRMotionSensorPack"]++;
 echo("MSG: ",%client," deployed a Long Range Motion Sensor");
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
//---------------------------------------------------------
 ItemImageData DeployableFieldSensorPackImage
 {
 shapeFile = "sensorjampack";
 mountPoint = 2;
 mountOffset = { 0, -0.07, 0 };
 mountRotation = { 0, 0, 0 };
 mass = 2.5;
 firstPerson = false; 
 };
 ItemData DeployableFieldSensorPack
 {
 description = "Field Sensor";
 shapeFile = "sensor_pulse_med";
 className = "Backpack";
 heading = "fSensors";
 shadowDetailMask = 4	;
 imageType = DeployableFieldSensorPackImage;
 mass = 2.5;
 elasticity = 0.2;
 price = 750;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function DeployableFieldSensorPack::onUse(%player,%item)
 {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function DeployableFieldSensorPack::onDeploy(%player,%item,%pos)
 {
 if (DeployableFieldSensorPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }	

 function DeployableFieldSensorPack::deployShape(%player,%item)
 {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape") {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player); 
 %DTPad = newObject("","Sensor",DeployableFieldSensor,true);
 addToSet("MissionCleanup", %DTPad);
 GameBase::setTeam(%DTPad,GameBase::getTeam(%player));
 GameBase::setPosition(%DTPad,Vector::add($los::position, "0 0 -0.05"));
 GameBase::setRotation(%DTPad, %rot);
 Gamebase::setMapName(%DTPad,"Field Sensor");
 %clName = Client::getName(%client);
 %Fsensor.owner = %client;
 %Fsensor.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Field Sensor deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "DeployableFieldSensorPack"]++;
 echo("MSG: ",%client," deployed a Field Sensor");
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
//---------------------------------------------------------
 ItemImageData CameraPackImage
 {
 shapeFile = "camera";
 mountPoint = 2;
 mountOffset = { 0, -0.1, -0.06 };
 mountRotation = { 0, 0, 0 };
 firstPerson = false;
 };

 ItemData CameraPack {
 description = "Camera";
 shapeFile = "camera";
 className = "Backpack";
 heading = "dDeployables";
 imageType = CameraPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 100;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

function CameraPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }

function CameraPack::onDeploy(%player,%item,%pos) {
 if (CameraPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }

 function CameraPack::deployShape(%player,%item) {
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
 %clName = Client::getName(%client);
 %turret = newObject("Camera","Turret",CameraTurret,true);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setRotation(%turret,%rot);
 GameBase::setPosition(%turret,$los::position);
 %clName = Client::getName(%client);
 Gamebase::setMapName(%turret,"Camera#" @ $totalNumCameras++ @ ": " @ %clName @ " .");
 Client::sendMessage(%client,0,"Camera deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%turret) @ "CameraPack"]++;
 addToSet(%client.deployables, %turret);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
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

 ItemImageData TurretPackImage {
 shapeFile = "remoteturret";
 mountPoint = 2;
 mountOffset = { 0, -0.12, -0.1 };
 mountRotation = { 0, 0, 0 };
 mass = 2.5;
 firstPerson = false;
 };

 ItemData TurretPack {
 description = "Ion Turret";
 shapeFile = "remoteturret";
 className = "Backpack";
 heading = "eTurrets";
 imageType = TurretPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 350;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function TurretPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function TurretPack::onDeploy(%player,%item,%pos) {
 if (TurretPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 %client = Player::getClient(%player);
 if(Client::isItemShoppingOn(%client,%item)) {
 playNextAnim(%client);
 Player::kill(%client);
 }
 }
 }
 function CountObjects(%set,%name,%num) {
 %count = 0;
 for(%i=0;%i<%num;%i++) {
 %obj=Group::getObject(%set,%i);
 if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
 }
 return %count;
 }
 function TurretPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 %player.deployTest = $los::position;
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableFlame",%num);
 deleteObject(%set);
 if($MaxNumTurretsInBox > %num) {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
 %num = CountObjects(%set,"Deployableturret",%num) + CountObjects(%set,"DeployableFlame",%num);
 deleteObject(%set);
 if(0 == %num) {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("remoteTurret","Turret",DeployableTurret,true);
 %clName = Client::getName(%client);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"RMT Ion Turret#" @ $totalNumTurrets++ @ ": " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Remote Ion Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
 echo("MSG: ",%client," deployed a Remote Turret");
 Client::setOwnedObject(%client, %turret);
 Client::setOwnedObject(%client, %player);
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
 }
 else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 function checkDeployArea(%client,%pos) {
 %set=newObject("set",SimSet);
 %num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
 if(!%num) {
 deleteObject(%set);
 return 1;
 }
 else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") {
 %obj = Group::getObject(%set,0);
 if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
 else Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
 }
 else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
 deleteObject(%set);
 return 0;
 }
//--------
 ItemImageData FlameTurretPackImage {
 shapeFile = "remoteturret";
 mountPoint = 2;
 mountOffset = { 0, -0.12, -0.1 };
 mountRotation = { 0, 0, 0 };
 mass = 2.5;
 firstPerson = false;
 };

 ItemData FlameTurretPack {
 description = "Flame Turret";
 shapeFile = "remoteturret";
 className = "Backpack";
 heading = "eTurrets";
 imageType = FlameTurretPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 350;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function FlameTurretPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function FlameTurretPack::onDeploy(%player,%item,%pos) {
 if (FlameTurretPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 %client = Player::getClient(%player);
 if(Client::isItemShoppingOn(%client,%item)) {
 playNextAnim(%client);
 Player::kill(%client);
 }
 }
 }
 function CountObjects(%set,%name,%num) {
 %count = 0;
 for(%i=0;%i<%num;%i++) {
 %obj=Group::getObject(%set,%i);
 if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
 }
 return %count;
 }
 function FlameTurretPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployableFlame",%num) + CountObjects(%set,"DeployableTurret",%num);
 deleteObject(%set);
 if($MaxNumTurretsInBox > %num) {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableFlame",%num) + CountObjects(%set,"DeployableTurret",%num);
 deleteObject(%set);
 if(0 == %num) {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("remoteTurret","Turret",DeployableFlame,true);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"RMT Flame Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
 %clName = Client::getName(%client);
 addToSet(%client.deployables, %turret);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Remote Flame Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "FlameTurretPack"]++;
 echo("MSG: ",%client," deployed a Remote Turret");
 Client::setOwnedObject(%client, %turret);
 Client::setOwnedObject(%client, %player);
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
 }
 else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
//--------
 ItemImageData LaserPackImage {
 shapeFile = "camera";
 mountPoint = 2;
 mountOffset = {0,-0.1,-0.06 };
 mountRotation = {0,0,0};
 firstPerson = false;
 };

 ItemData LaserPack {
 description = "Laser Turret";
 shapeFile = "camera";
 className = "Backpack";
 heading = "eTurrets";
 imageType = CameraPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 300;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function LaserPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function LaserPack::onDeploy(%player,%item,%pos) {
 if (LaserPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 %client = Player::getClient(%player);
 if(Client::isItemShoppingOn(%client,%item)) {
 playNextAnim(%client);
 Player::kill(%client);
 }
 }
 function LaserPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployableLaser",%num);
 deleteObject(%set);
 if($MaxNumTurretsInBox > %num) {
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
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
 %turret = newObject("Camera","Turret",DeployableLaser,true);
 %clName = Client::getName(%client);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setRotation(%turret,%rot);
 GameBase::setPosition(%turret,$los::position);
 Gamebase::setMapName(%turret,"RMT Laser Turret#" @ $totalNumCameras++ @ ": " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Laser Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%turret) @ "LaserPack"]++;
 Client::setOwnedObject(%client, %turret);
 Client::setOwnedObject(%client, %player);
 return true;
 }
 }
 else {
 Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 }
 else Client::sendMessage(%client,0,"Interference from other laser turrets in the area");
 }
 else {
 Client::sendMessage(%client,0,"Deploy position out of range");
 }
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData ShockPackImage {
 shapeFile = "indoorgun";
 mountPoint = 2;
 mountOffset = {
 0, -0.1, -0.06 }
;
 mountRotation = {
 0, 0, 0 }
;
 firstPerson = false;
 }
;
 ItemData ShockPack {
 description = "Shock Turret";
 shapeFile = "indoorgun";
 className = "Backpack";
 heading = "eTurrets";
 imageType = ShockPackImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 600;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function ShockPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function ShockPack::onDeploy(%player,%item,%pos) {
 if (ShockPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function ShockPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
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
 %clName = Client::getName(%client);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployableShock",%num);
 deleteObject(%set);
 if($MaxNumTurretsInBox > %num) {
 %turret = newObject("Camera","Turret",DeployableShock,true);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setRotation(%turret,%rot);
 GameBase::setPosition(%turret,$los::position);
 Gamebase::setMapName(%turret,"RMT Shock Turret#" @ $totalNumTurrets++ @ ": " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Shock Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%turret) @ "ShockPack"]++;
 return true;
 }
 else Client::sendMessage(%client,0,"Interference from other Shock turrets in the area");
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
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData TargetPackImage {
 shapeFile = "ammounit_remote";
 mountPoint = 2;
 mountOffset = {
 0, -0.1, -0.06 }
;
 mountRotation = {
 0, 0, 0 }
;
 firstPerson = false;
 }
;
 ItemData TargetPack {
 description = "Mortar Turret";
 shapeFile = "mortar_turret";
 className = "Backpack";
 heading = "eTurrets";
 imageType = TargetPackImage;
 shadowDetailMask = 4;
 mass = 3.0;
 elasticity = 0.2;
 price = 800;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function TargetPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function TargetPack::onMount(%player,%item) {
 %client = Player::getClient(%player);
 Bottomprint(%client, "The Mortar Turret has no auto-sensor and must be controlled manually to fire.");
 }
 function TargetPack::onDeploy(%player,%item,%pos) {
 if (TargetPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function TargetPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployableMortar",%num);
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
 %turret = newObject("remoteTurret","Turret",DeployableMortar,true);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 %clName = Client::getName(%client);
 Gamebase::setMapName(%turret,"Mortar Turret#" @ $totalNumTurrets++ @ ": " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Remote Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "TargetPack"]++;
 echo("MSG: ",%client," deployed a Remote Turret");
 Client::setOwnedObject(%client, %turret);
 Client::setOwnedObject(%client, %player);
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
 }
 else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData LaserTurretImage {
 shapeFile = "remoteturret";
 mountPoint = 2;
 mountOffset = {
 0, -0.12, -0.1 }
;
 mountRotation = {
 0, 0, 0 }
;
 mass = 2.5;
 firstPerson = false;
 }
;
 ItemData LaserTurret {
 description = "Plasma Turret";
 shapeFile = "remoteturret";
 className = "Backpack";
 heading = "eTurrets";
 imageType = LaserTurretImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 650;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function LaserTurret::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function LaserTurret::onDeploy(%player,%item,%pos) {
 if (LaserTurret::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 %client = Player::getClient(%player);
 if(Client::isItemShoppingOn(%client,%item)) {
 playNextAnim(%client);
 Player::kill(%client);
 }
 }
 function CountObjects(%set,%name,%num) {
 %count = 0;
 for(%i=0;
%i<%num;
%i++) {
 %obj=Group::getObject(%set,%i);
 if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
 }
 return %count;
 }
 function LaserTurret::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployablePlasma",%num);
 deleteObject(%set);
 if($MaxNumTurretsInBox > %num) {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
 %num = CountObjects(%set,"DeployablePlasma",%num);
 deleteObject(%set);
 if(0 == %num) {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("hellfiregun","Turret",DeployablePlasma,true);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 %clName = Client::getName(%client);
 Gamebase::setMapName(%turret,"RMT Plasma Turret#" @ $totalNumTurrets++ @ ": " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Plasma Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "LaserTurret"]++;
 Client::setOwnedObject(%client, %turret);
 Client::setOwnedObject(%client, %player);
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
 }
 else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 function checkDeployArea(%client,%pos) {
 %set=newObject("set",SimSet);
 %num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
 if(!%num) {
 deleteObject(%set);
 return 1;
 }
 else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") {
 %obj = Group::getObject(%set,0);
 if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
 else Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
 }
 else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
 deleteObject(%set);
 return 0;
 }
 ItemImageData VulcanTurretImage {
 shapeFile = "remoteturret";
 mountPoint = 2;
 mountOffset = {
 0, -0.12, -0.1 }
;
 mountRotation = {
 0, 0, 0 }
;
 mass = 2.5;
 firstPerson = false;
 }
;
 ItemData VulcanTurret {
 description = "Anti-Aircraft/Vulcan Turret";
 shapeFile = "remoteturret";
 className = "Backpack";
 heading = "eTurrets";
 imageType = VulcanTurretImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 750;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function VulcanTurret::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function VulcanTurret::onDeploy(%player,%item,%pos) {
 if (VulcanTurret::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function VulcanTurret::onMount(%player,%item) {
 %client = Player::getClient(%player);
 }
 function CountObjects(%set,%name,%num) {
 %count = 0;
 for(%i=0;
%i<%num;
%i++) {
 %obj=Group::getObject(%set,%i);
 if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
 }
 return %count;
 }
 function VulcanTurret::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$AATurretBoxMaxLength,$AATurretBoxMaxWidth,$AATurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployableVulcan",%num);
 deleteObject(%set);
 if($MaxNumAATurretsInBox > %num) {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$AATurretBoxMinLength,$AATurretBoxMinWidth,$AATurretBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableVulcan",%num);
 deleteObject(%set);
 if(0 == %num) {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %clName = Client::getName(%client);
 %turret = newObject("hellfiregun","Turret",DeployableVulcan,true);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"Anti-Aircraft/Vulcan Turret#" @ $totalNumTurrets++ @ ": " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Anti-Aircraft/Vulcan Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "VulcanTurret"]++;
 Client::setOwnedObject(%client, %turret);
 Client::setOwnedObject(%client, %player);
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
 }
 else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData RailTurretImage {
 shapeFile = "remoteturret";
 mountPoint = 2;
 mountOffset = {
 0, -0.12, -0.1 }
;
 mountRotation = {
 0, 0, 0 }
;
 mass = 2.5;
 firstPerson = false;
 }
;
 ItemData RailTurret {
 description = "Rail Turret";
 shapeFile = "remoteturret";
 className = "Backpack";
 heading = "eTurrets";
 imageType = RailTurretImage;
 shadowDetailMask = 4;
 mass = 2.0;
 elasticity = 0.2;
 price = 850;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function RailTurret::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function RailTurret::onDeploy(%player,%item,%pos) {
 if (RailTurret::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function RailTurret::onMount(%player,%item) {
 %client = Player::getClient(%player);
 Bottomprint(%client, "The Rail Turret has no auto-sensor and must be controlled manually to fire.");
 }
 function CountObjects(%set,%name,%num) {
 %count = 0;
 for(%i=0;
%i<%num;
%i++) {
 %obj=Group::getObject(%set,%i);
 if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
 }
 return %count;
 }
 function RailTurret::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployableVulcan",%num);
 deleteObject(%set);
 if($MaxNumTurretsInBox > %num) {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
 %num = CountObjects(%set,"DeployablePlasma",%num);
 deleteObject(%set);
 if(0 == %num) {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("hellfiregun","Turret",DeployableRail,true);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"Rail Turret#" @ $totalNumTurrets++ @ ": " @ %clName @ " .");
 %clName = Client::getName(%client);
 addToSet(%client.deployables, %turret);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Rail Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "RailTurret"]++;
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
 }
 else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData RocketPackImage {
 shapeFile = "remoteturret";
 mountPoint = 2;
 mountOffset = {
 0, -0.12, -0.1 }
;
 mountRotation = {
 0, 0, 0 }
;
 mass = 3.0;
 firstPerson = false;
 }
;
 ItemData RocketPack {
 description = "Missile Turret";
 shapeFile = "missileturret";
 className = "Backpack";
 heading = "eTurrets";
 imageType = RocketPackImage;
 shadowDetailMask = 4;
 mass = 3.0;
 elasticity = 0.2;
 price = 950;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function RocketPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function RocketPack::onDeploy(%player,%item,%pos) {
 if (RocketPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function RocketPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
 %num = CountObjects(%set,"DeployableRocket",%num);
 deleteObject(%set);
 if($MaxNumTurretsInBox > %num) {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableRocket",%num);
 deleteObject(%set);
 if(0 == %num) {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("missileturret","Turret",DeployableRocket,true);
 addToSet("MissionCleanup", %turret);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"RMT Missile Turret#" @ $totalNumTurrets++ @ ": " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %clName = Client::getName(%client);
 %Turret.owner = %client;
 %Turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Missile Turret deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
 Client::setOwnedObject(%client, %turret);
 Client::setOwnedObject(%client, %player);
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
 }
 else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData ForceFieldPackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = {0,-0.03,0};
 mass = 2.5;
 firstPerson = false;
 };

 ItemData ForceFieldPack 
 {
 description = "Force Field";
 shapeFile = "AmmoPack";
 className = "Backpack";
 heading = "dDeployables";
 imageType = ForceFieldPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 600;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function ForceFieldPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function ForceFieldPack::onDeploy(%player,%item,%pos) {
 if (ForceFieldPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function ForceFieldPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableForceField",%num);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("","StaticShape",DeployableForceField,true);
 addToSet("MissionCleanup", %turret);
 %clName = Client::getName(%client);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"RMT Force Field#" @ $totalNumTurrets++ @ " " @ %clName);
 addToSet(%client.deployables, %turret);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Force Field Deployed");
 GameBase::startFadeIn(%turret);
 playSound(SoundPickupBackpack,$los::position);
 playSound(ForceFieldOpen,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;
 return true;
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData ForceFieldDoorPackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = { 0, -0.03, 0 };
 mass = 2.5;
 firstPerson = false;
 };

 ItemData ForceFieldDoorPack {
 description = "Force Field Door";
 shapeFile = "AmmoPack";
 className = "Backpack";
 heading = "dDeployables";
 imageType = ForceFieldDoorPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 600;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function ForceFieldDoorPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function ForceFieldDoorPack::onDeploy(%player,%item,%pos) {
 if (ForceFieldDoorPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function ForceFieldDoorPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableForceField",%num);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("","StaticShape",DeployableForceFieldDoor,true);
 addToSet("MissionCleanup", %turret);
 %clName = Client::getName(%client);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"RMT Force Field Door#" @ $totalNumTurrets++ @ " " @ %clName);
 addToSet(%client.deployables, %turret);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Force Field Door Deployed");
 GameBase::startFadeIn(%turret);
 playSound(SoundPickupBackpack,$los::position);
 playSound(ForceFieldOpen,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldDoorPack"]++;
 return true;
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData LargeForceFieldPackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = {
 0, -0.03, 0 }
;
 mass = 2.5;
 firstPerson = false;
 }
;
 ItemData LargeForceFieldPack {
 description = "Large Force Field";
 shapeFile = "AmmoPack";
 className = "Backpack";
 heading = "dDeployables";
 imageType = LargeForceFieldPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 1200;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function LargeForceFieldPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function LargeForceFieldPack::onDeploy(%player,%item,%pos) {
 if (LargeForceFieldPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function LargeForceFieldPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableForceField",%num);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("","StaticShape",LargeForceField,true);
 addToSet("MissionCleanup", %turret);
 %clName = Client::getName(%client);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"RMT Large Force Field#" @ $totalNumTurrets++ @ " " @ %clName);
 addToSet(%client.deployables, %turret);
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Force Field Deployed");
 GameBase::startFadeIn(%turret);
 playSound(SoundPickupBackpack,$los::position);
 playSound(ForceFieldOpen,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldPack"]++;
 return true;
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData LargeForceFieldDoorPackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = {0,-0.03,0};
 mass = 2.5;
 firstPerson = false;
 };
 ItemData LargeForceFieldDoorPack {
 description = "Large Force Field Door";
 shapeFile = "AmmoPack";
 className = "Backpack";
 heading = "dDeployables";
 imageType = LargeForceFieldDoorPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 1200;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function LargeForceFieldDoorPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function LargeForceFieldDoorPack::onDeploy(%player,%item,%pos) {
 if (LargeForceFieldDoorPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function LargeForceFieldDoorPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableForceField",%num);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("","StaticShape",LargeForceFieldDoor,true);
 addToSet("MissionCleanup", %turret);
 %clName = Client::getName(%client);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"RMT Large Force Field Door#" @ $totalNumTurrets++ @ " " @ %clName);
 addToSet(%client.deployables, %turret);
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Force Field Deployed");
 GameBase::startFadeIn(%turret);
 playSound(SoundPickupBackpack,$los::position);
 playSound(ForceFieldOpen,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "LargeForceFieldDoorPack"]++;
 return true;
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData TripwirePackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = {
 0, -0.1, 0 }
;
 mass = 2.5;
 firstPerson = false;
 }
;
 ItemData TripwirePack {
 description = "Blast Wall";
 shapeFile = "newdoor5";
 className = "Backpack";
 heading = "dDeployables";
 imageType = TripwirePackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 600;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function TripwirePack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function TripwirePack::onDeploy(%player,%item,%pos) {
 if (TripwirePack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function TripwirePack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain") {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
 %num = CountObjects(%set,"BlastWall",%num);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %turret = newObject("","StaticShape",BlastWall,true);
 addToSet("MissionCleanup", %turret);
 %clName = Client::getName(%client);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"Blastwall: " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Blast Wall Deployed");
 GameBase::startFadeIn(%turret);
 playSound(SoundPickupBackpack,$los::position);
 playSound(ForceFieldOpen,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "TripwirePack"]++;
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData HoloPackImage {
 shapeFile = "ShieldPack";
 mountPoint = 2;
 mountOffset = {
 0, -0.03, 0 }
;
 mass = 1.0;
 firstPerson = false;
 }
;
 ItemData HoloPack {
 description = "Hologram";
 shapeFile = "larmor";
 className = "Backpack";
 heading = "dDeployables";
 imageType = HoloPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 900;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;

 }
;
 function HoloPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function HoloPack::onDeploy(%player,%item,%pos) {
 if (HoloPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
//new hologram from HaVoC by [HvC] NateDogg
function HoloPack::deployShape(%player,%item) 
{ 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[holopack]) 
{ 
if (GameBase::getLOSInfo(%player,3)) 
{ 
%obj = getObjectType($los::object); 
if (Vector::dot($los::normal,"0 0 1") > 0.7) 
{ 
if(checkDeployArea(%client,$los::position)) 
{ 
if(Vector::getDistance(GameBase::getPosition($teamFlag[GameBase::getTeam(%player)]), $los::position) < 1) 
{
Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
return false;
}
%rPos = GameBase::getRotation(%client);            
%HologramName = Client::getName(%client) @ "   ";   
while($Hologram[%HologramName] != "")
%HologramName = %HologramName @ " ";
%parmor = Player::getArmor(%player); 
%rnd = floor(getRandom() * 10); 
if(%rnd > 6) 
%armor = "larmor";
else if(%rnd > 2 && %rnd < 7) 
%armor = "marmor";
else 
%armor = "darmor";
if (%parmor == "dmarmor" || %parmor == "dmfemale")
%armor = %parmor;
%some = Ai::spawn(%HologramName, %armor, $los::position, %rPos);  
$Hologram[%HologramName] = GameBase::getTeam(%player);   
%hID = AI::getId(%HologramName);   
%type = Player::getMountedItem(%client,0);   
Player::setItemCount(%hId, %type, 1);   
Player::mountItem(%hId, %type, 0);   
Client::sendMessage(%client,0,"Decoy Deployed"); 
GameBase::startFadeIn(%hID); 
playSound(ForceFieldOpen,$los::position); 
$TeamItemCount[GameBase::getTeam(%player) @ "HoloPack"]++; 
return true; 
} 
} 
else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
} 
else Client::sendMessage(%client,0,"Deploy position out of range"); 
} 
else Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s"); 
return false; 
} 
 ItemImageData SpringPackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = {
 0, -0.03, 0 }
;
 mass = 2.5;
 firstPerson = false;
 }
;
 ItemData SpringPack {
 description = "Springboard";
 shapeFile = "AmmoPack";
 className = "Backpack";
 heading = "dDeployables";
 imageType = SpringPackImage;
 shadowDetailMask = 4;
 mass = 1.0;
 elasticity = 0.2;
 price = 500;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function SpringPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function SpringPack::onDeploy(%player,%item,%pos) {
 if (SpringPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function SpringPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape") {
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableCactus",%num);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %phase = newObject("","StaticShape",DeployableSpring,true);
 addToSet("MissionCleanup", %phase);
 GameBase::setTeam(%phase,GameBase::getTeam(%player));
 GameBase::setPosition(%phase,$los::position);
 GameBase::setRotation(%phase,%rot);
 Gamebase::setMapName(%phase,"Springboard");
 %clName = Client::getName(%client);
 %Spring.owner = %client;
 %Spring.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Springboard Deployed");
 GameBase::startFadeIn(%phase);
 playSound(SoundPickupBackpack,$los::position);
 playSound(ForceFieldOpen,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++;
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
 ItemImageData PlatformPackImage {
 shapeFile = "AmmoPack";
 mountPoint = 2;
 mountOffset = {
 0, -0.03, 0 }
;
 mass = 2.5;
 firstPerson = false;
 }
;
 ItemData PlatformPack {
 description = "Deployable Platform";
 shapeFile = "AmmoPack";
 className = "Backpack";
 heading = "dDeployables";
 imageType = PlatformPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 600;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function PlatformPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function PlatformPack::onDeploy(%player,%item,%pos) {
 if (PlatformPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function PlatformPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
 %num = CountObjects(%set,"DeployablePlatform",%num);
 deleteObject(%set);
 %rot = GameBase::getRotation(%player);
 %turret = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true);
 addToSet("MissionCleanup", %turret);
 %clName = Client::getName(%client);
 GameBase::setTeam(%turret,GameBase::getTeam(%player));
 GameBase::setPosition(%turret,$los::position);
 GameBase::setRotation(%turret,%rot);
 Gamebase::setMapName(%turret,"Deployable Platform: " @ %clName @ " .");
 addToSet(%client.deployables, %turret);
 %turret.owner = %client;
 %turret.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Platform Deployed");
 GameBase::startFadeIn(%turret);
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
 return true;
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }

 ItemImageData TeleportPackImage {
 shapeFile = "flagstand";
 mountPoint = 2;
 mountOffset = { 0, 0, 0.1 };
 mountRotation = { 1.57, 0, 0 };
 firstPerson = false;
 };

 ItemData TeleportPack {
 description = "Teleport Pad";
 shapeFile = "flagstand";
 className = "Backpack";
 heading = "dDeployables";
 imageType = TeleportPackImage;
 shadowDetailMask = 4;
 mass = 5.0;
 elasticity = 0.2;
 price = 3200;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function TeleportPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function TeleportPack::onDeploy(%player,%item,%pos) {
 if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) {
 Player::decItemCount(%player,%item);
 $TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++;
 }
 }
 function CreateteleportSimSet() {
 %teleset = nameToID("MissionCleanup/Teleports");
 if(%teleset == -1) {
 newObject("Teleports",SimSet);
 addToSet("MissionCleanup","Teleports");
 }
 }
 function TeleportPack::deployShape(%player,%name,%shape,%item) {
 %client = Player::getClient(%player);
 %playerPos = GameBase::getPosition(%player);
 %flag = $teamFlag[GameBase::getTeam(%player)];
 %flagpos = gamebase::getPosition(%flag);
 echo("%flagpos " @ %flagpos);
 echo("%playerpos " @ %playerpos);
 if(Vector::getDistance(%flagpos, %playerpos) > 20) {
 if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %sensor = newObject("Teleport Pad","StaticShape",%shape,true);
 CreateteleportSimSet();
 addToSet("MissionCleanup/Teleports", %sensor);
 addToSet("MissionCleanup", %sensor);
 GameBase::setTeam(%sensor,GameBase::getTeam(%player));
 %pos = Vector::add($los::position,"0 0 1");
 echo("LOS pos " @ $los::position @ " " @ %pos);
 GameBase::setPosition(%sensor,%pos);
 Gamebase::setMapName(%sensor,%name);
 Client::sendMessage(%client,0,%item.description @ " deployed");
 %sensor.disabled = false;
 playSound(SoundPickupBackpack,$los::position);
 %clName = Client::getName(%client);
 %Teleport.owner = %client;
 %Teleport.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 %beam = newObject("","StaticShape",ElectricalBeamBig,true);
 addToSet("MissionCleanup", %beam);
 GameBase::setTeam(%beam,GameBase::getTeam(%player));
 GameBase::setPosition(%beam,%pos);
 %sensor.beam1 = %beam;
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
 }
 else Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
 return false;
 }

 ItemImageData MechPackImage {
 shapeFile = "ammounit_remote";
 mountPoint = 2;
 mountOffset = {0,-0.03,0};
 mass = 2.5;
 firstPerson = false;
 };

 ItemData MechPack {
 description = "Interceptor Pack";
 shapeFile = "ammounit_remote";
 className = "Backpack";
 heading = "dDeployables";
 imageType = MechPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 600;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 };

 function MechPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function MechPack::onDeploy(%player,%item,%pos) {
 if (MechPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function MechPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"] < $TeamItemMax[JetVehicle]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain") {
 %set = newObject("set",SimSet);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %phase = newObject("",flier,Jet,true);
 addToSet("MissionCleanup", %phase);
 GameBase::setTeam(%phase,GameBase::getTeam(%player));
 GameBase::setPosition(%phase,$los::position);
 GameBase::setRotation(%phase,%rot);
 %clName = Client::getName(%client);
 %Interceptor.owner = %client;
 %Interceptor.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Piloting Interceptor");
 GameBase::startFadeIn(%phase);
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"]++;
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
  
 ItemImageData ScoutPackImage {
 shapeFile = "ammounit_remote";
 mountPoint = 2;
 mountOffset = {0,-0.03,0};
 mass = 2.5;
 firstPerson = false;
 };

 ItemData ScoutPack {
 description = "Scout Pack";
 shapeFile = "ammounit_remote";
 className = "Backpack";
 heading = "dDeployables";
 imageType = ScoutPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 600;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function ScoutPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function ScoutPack::onDeploy(%player,%item,%pos) {
 if (ScoutPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function ScoutPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"] < $TeamItemMax[ScoutVehicle]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain") {
 %set = newObject("set",SimSet);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %phase = newObject("",flier,Scout,true);
 addToSet("MissionCleanup", %phase);
 GameBase::setTeam(%phase,GameBase::getTeam(%player));
 GameBase::setPosition(%phase,$los::position);
 GameBase::setRotation(%phase,%rot);
 Gamebase::setMapName(%phase,"Scout Pack");
 %clName = Client::getName(%client);
 %Scout.owner = %client;
 %Scout.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Deployed a Scout");
 GameBase::startFadeIn(%phase);
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "ScoutVehicle"]++;
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }

//-----------------------------
 ItemImageData HPCPackImage {
 shapeFile = "ammounit_remote";
 mountPoint = 2;
 mountOffset = {
 0, -0.03, 0 }
;
 mass = 2.5;
 firstPerson = false;
 }
;
 ItemData HPCPack {
 description = "Stealth HPC Pack";
 shapeFile = "ammounit_remote";
 className = "Backpack";
 heading = "dDeployables";
 imageType = HPCPackImage;
 shadowDetailMask = 4;
 mass = 1.5;
 elasticity = 0.2;
 price = 1600;
 hudIcon = "deployable";
 showWeaponBar = true;
 hiliteOnActive = true;
 }
;
 function HPCPack::onUse(%player,%item) {
 if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
 Player::mountItem(%player,%item,$BackpackSlot);
 }
 else {
 Player::deployItem(%player,%item);
 }
 }
 function HPCPack::onDeploy(%player,%item,%pos) {
 if (HPCPack::deployShape(%player,%item)) {
 Player::decItemCount(%player,%item);
 }
 }
 function HPCPack::deployShape(%player,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] < $TeamItemMax[HAPCVehicle]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain") {
 %set = newObject("set",SimSet);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 if(checkDeployArea(%client,$los::position)) {
 %rot = GameBase::getRotation(%player);
 %phase = newObject("",flier,HAPC,true);
 addToSet("MissionCleanup", %phase);
 GameBase::setTeam(%phase,GameBase::getTeam(%player));
 GameBase::setPosition(%phase,$los::position);
 GameBase::setRotation(%phase,%rot);
 Gamebase::setMapName(%phase,"HPC Pack");
 %clName = Client::getName(%client);
 %HPC.owner = %client;
 %HPC.ownerName = %clName;
 ixToggleDeploy(%player);
 schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
 Client::sendMessage(%client,0,"Deployed StealthHPC");
 GameBase::startFadeIn(%phase);
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++;
 return true;
 }
 }
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }

 function Item::deployShape(%player,%name,%shape,%item) {
 %client = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
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
 else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
 }
 else Client::sendMessage(%client,0,"Deploy position out of range");
 }
 else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
 return false;
 }
//------------------------------
 $AutoUse[RepairKit] = false;
 ItemData RepairKit {
 description = "Repair Kit";
 shapeFile = "armorKit";
 heading = "gMiscellany";
 shadowDetailMask = 4;
 price = 35;
 }
;
 function RepairKit::onUse(%player,%item) {
 if(%player.inStation) return;
 Player::decItemCount(%player,%item);
 GameBase::repairDamage(%player,0.2);
 %c = Player::getClient(%player);
 %c.poisontime = 0;
 }

ItemData MineAmmo
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = "gMiscellany";
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

			//==== Check Armour To Mine Type

			%armor = Player::getArmor(%player);
			%clientId = Player::getClient(%player);

			if (%armor == "larmor" || %armor == "lfemale") //====blind mine
			{
				%obj = newObject("","Mine","BlindMine"); 
				Player::decItemCount(%player,%item);
			}

			if(%armor == "earmor" || %armor == "efemale")				//=== EMP mine
			{
				%obj = newObject("","Mine","EMPMine"); 
				Player::decItemCount(%player,%item);

			}

			if (%armor == "sarmor" || %armor == "sfemale") //======= Shockwave Mine
			{
				%obj = newObject("","Mine","ShockwaveMine"); 
				Player::decItemCount(%player,%item);					
			}

			if (%armor == "spyarmor" || %armor == "spyfemale") //======= Detbug
			{
				if($matchStarted)
				{
				   if (!%clientId.ghosting) {	
					if(%player.throwTime < getSimTime())
					{
						echo ("Item " @ %item);
						%obj = newObject("","Item",DetBug,1,false,false);
						%client = Player::getClient(%player);
						GameBase::throw(%obj,%player,-25,false);
						%player.throwTime = getSimTime() + 0.5;
						Client::sendMessage(Player::getClient(%player),0,"[TAS]:Det Bug Dropped"); 
						Player::decItemCount(%player, %item);
						%obj.dropper = %clientId;
						GameBase::setTeam(%obj, GameBase::getTeam(%player));
						schedule("DetBug::Detonate(" @ %obj @ ");", 12);
					}
				    }
				}					
			}

			if (%armor == "marmor" || %armor == "mfemale") //====== Straight up good ol base mine
			{
				%obj = newObject("","Mine","antipersonelMine"); 
				Player::decItemCount(%player,%item);					
			}

			if (%armor == "aarmor" || %armor == "afemale")
			{
				%obj = newObject("","Mine","PoisonMine");				//=== PoisonMine
				Player::decItemCount(%player,%item);					
			}

			if (%armor == "harmor") //======= Heavy Mortar Mine
			{
				%obj = newObject("","Mine","MortarMine"); 
				Player::decItemCount(%player,%item);					
			}

			if (%armor == "barmor" || %armor == "bfemale") //======= Flame Mine
			{
				%obj = newObject("","Mine","IncendiaryMine"); 
				Player::decItemCount(%player,%item);					
			}

			if (%armor == "darmor") //====== Prox Mine
			{
				%obj = newObject("","Mine","ProxMine"); 
				Player::decItemCount(%player,%item);
			}
			//==== Finish Mine Deploy

		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;

			GameBase::setTeam (%obj,GameBase::getTeam (%client));

		}
	}
}
 ItemData Grenade {
 description = "Grenade";
 shapeFile = "grenade";
 heading = "gMiscellany";
 shadowDetailMask = 4;
 price = 5;
 className = "HandAmmo";
}
;
 function Grenade::onUse(%player,%item) {
 if($matchStarted) {
 if(%player.throwTime < getSimTime() ) {
 Player::decItemCount(%player,%item);
 %armor = Player::getArmor(%player);
        if (%armor == "larmor" || %armor == "lfemale") %obj = newObject("","Mine","HoloMine");
 	if(%armor == "sarmor" || %armor == "sfemale") %obj = newObject("","Mine","Concussion");
	if (%armor == "barmor" || %armor == "bfemale") %obj = newObject("","Mine","Firebomb");
 	if (%armor == "spyarmor" || %armor == "spyfemale") {
 	    Client::sendMessage(Player::getClient(%player),1, "[TAS]:Plastique Explosive will explode in 8 seconds");
 	    %obj = newObject("","Mine","Nukebomb");
        }
 	if (%armor == "marmor" || %armor == "mfemale") %obj = newObject("","Mine","Handgrenade");
 	if (%armor == "aarmor" || %armor == "afemale") %obj = newObject("","Mine","Tranqgrenade");
 	if (%armor == "harmor") %obj = newObject("","Mine","Mortarbomb");
 	if (%armor == "earmor" || %armor == "efemale") %obj = newObject("","Mine","Shockgrenade");
 	if (%armor == "darmor") %obj = newObject("","Mine","Mortarbomb");
 	if (%armor == "dmarmor" || %armor == "dmfemale") {
             %clientId = Player::getClient(%player);
 	     if($modeTime[%clientId] == 1) {
                 Client::sendMessage(Player::getClient(%player),1, "[TAS]:Plastique Explosive will explode in 8 seconds");
 		 %obj = newObject("","Mine","Nukebomb");
             }
        else if($modeTime[%clientId] == 2) {
        %obj = newObject("","Mine","Concussion");
        }
 	else if($modeTime[%clientId] == 3) {
 	%obj = newObject("","Mine","Shockgrenade");
 	}
 	else if($modeTime[%clientId] == 4) {
 	%obj = newObject("","Mine","Tranqgrenade");
 	}
 	else if($modeTime[%clientId] == 5) {
 	%obj = newObject("","Mine","Mortarbomb");
 	}
 	else if($modeTime[%clientId] == 6) {
 	%obj = newObject("","Mine","Firebomb");
 	}
 	else %obj = newObject("","Mine","Handgrenade");
 	}
 	addToSet("MissionCleanup", %obj);
 	%client = Player::getClient(%player);
 	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
 	%player.throwTime = getSimTime() + 0.5;
 	GameBase::setTeam (%obj,GameBase::getTeam (%client));
	}
   
 }
 }
 ItemData Beacon {
 description = "Beacon";
 shapeFile = "sensor_small";
 heading = "gMiscellany";
 shadowDetailMask = 4;
 price = 5;
 className = "HandAmmo";
 validateShape = true;
 validateMaterials = true;
 };

function Beacon::onUse(%player,%item) {
if(%player.inStation) return;
%clientId = Player::getClient(%player);
if(Client::getControlObject(%clientId) != %player) return;
if(%clientId.poisonTime > 0) {
	Client::sendMessage(Player::getClient(%player),1,"[TAS]:Unable to use beacons while poisoned~waccess_denied.wav");
	
	return;
}
%armor = Player::getArmor(%player);
if (%armor == "marmor" || %armor == "mfemale") {
	if(%player.throwTime < getSimTime()) {
 		%obj = newObject("","Mine","Booster");
 		addToSet("MissionCleanup", %obj);
 		%clientId = Player::getClient(%player);
		GameBase::throw(%obj,%player,15 * %clientId.throwStrength,false);
		%player.throwTime = getSimTime() + 0.5;
		Client::sendMessage(Player::getClient(%player),0, "[TAS]:You use a Speed Booster.");
		Player::decItemCount(%player,%item);
	}
}
else if (%armor == "larmor" || %armor == "lfemale") {
  	if (%clientId.Jamtime == 0) {
        Renegades_StartJam(%clientId, %player);
	Player::decItemCount(%player,%item);
        }
	else {
        Client::sendMessage(Player::getClient(%player),1,"[TAS]:Unable to use beacons while one is in use~waccess_denied.wav");
        return;
 	}
}
else if(%armor == "earmor" || %armor == "efemale") {

	EngMotion(%clientId, %player, %item);
}
else if (%armor == "sarmor" || %armor == "sfemale") {
	ScoutSensor(%clientId, %player, %item);
}
else if (%armor == "spyarmor" || %armor == "spyfemale") {
	DeploySatchel(%clientId, %player, %item);
}
else if (%armor == "dmarmor"|| %armor == "dmfemale") {
	
	if (%clientId.cloaktime == 0) {
	Renegades_startCloak(%clientId, %player);
	Player::decItemCount(%player,%item);
	}
	else {
        Client::sendMessage(Player::getClient(%player),1,"[TAS]:Unable to use beacons while one is in use~waccess_denied.wav");
        return;
 	}

}
else if (%armor == "harmor") {

	if (%clientId.shieldtime == 0) {
	Renegades_StartShield(%clientId, %player);
	Player::decItemCount(%player, %item);
	}
	else {
        Client::sendMessage(Player::getClient(%player),1,"[TAS]:Unable to use beacons while one is in use~waccess_denied.wav");
        return;
 	}

}
else if (%armor == "aarmor" || %armor == "afemale") {

	if (%clientId.cloaktime == 0) {
	Renegades_StartCloak(%clientId, %player);
	Player::decItemCount(%player, %item);
	}
	else {
        Client::sendMessage(Player::getClient(%player),1,"[TAS]:Unable to use beacons while one is in use~waccess_denied.wav");
        return;
 	}

}
else if (%armor == "darmor") {
	ForceDeploy(%clientId, %player, %item);
}
else if (%armor == "barmor" || %armor == "bfemale") {

	if (%clientId.stimTime == 0) {
 	Renegades_startStim(%clientId, %player);
 	Player::decItemCount(%player,%item);
 	}
	else {
        Client::sendMessage(Player::getClient(%player),1,"[TAS]:Unable to use beacons while one is in use~waccess_denied.wav");
     	return;
 	} 
}

}

function Renegades_startStim(%clientId, %player) 
{
 	if(%clientId.stimTime > 0) return;
 	Client::sendMessage(%clientId,0,"[TAS]:Ground Speed Doubled");
 	%armor = Player::getArmor(%player);
 	%armor.maxForwardSpeed = 20;
	%armor.maxBackwardSpeed = 18;
 	GameBase::playSound(%player,ForceFieldOpen,0);
 		if(%clientId.stimTime == 0) 
		{
 			%clientId.stimTime = 10;
 			checkPlayerStim(%clientId, %player);
 		}
 		else %clientId.stimTime = 10;
}

function checkPlayerStim(%clientId, %player) 
{
 	%armor = Player::getArmor(%player);
	if(%clientId.stimTime > 0) 
	{
 		%clientId.stimTime -= 2;
 		if (!Player::isDead(%player) && (%armor == "barmor" || %armor == "bfemale")) 
		{
 		}
 		else 
		{
 			%clientId.stimTime = 0;
 			%armor.maxForwardSpeed = 9;
 		}
 	schedule("checkPlayerStim(" @ %clientId @ ", " @ %player @ ");",2,%player);
 	}
 	else {
 	Client::sendMessage(%clientId,0,"[TAS]:Ground Speed Normalized");
 	%armor = Player::getArmor(%player);
 	%armor.maxForwardSpeed = 10;
 	%armor.maxBackwardSpeed = 9;
 	GameBase::playSound(%player,ForceFieldOpen,0);
 	}
}


function Renegades_startShield(%clientId, %player) { 

	if(%clientId.shieldTime > 0) return;
	Client::sendMessage(%clientId,0,"[TAS]:Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0); 
	if(%player.shieldStrength <= 0)
		%player.shieldStrength = 0.006; 
	else
		%player.shieldStrength += 0.006;
	if(%clientId.shieldTime == 0) { 
		%clientId.shieldTime = 16; 
		checkPlayerShield(%clientId, %player); 
	} else 
		%clientId.shieldTime = 16; 

} 

function checkPlayerShield(%clientId, %player) { 

	if(%clientId.shieldTime > 0) { 
		%clientId.shieldTime -= 2; 
		%armor = Player::getArmor(%player); 
		if (Player::isDead(%player) || %armor != "harmor") 
			%clientId.shieldTime = 0; 
		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} else { 
		Client::sendMessage(%clientId,0,"[TAS]:Emergency Force Shields Exausted"); 
		if(%player.shieldStrength - 0.006 <= 0)
			%player.shieldStrength = 0; 
		else
			%player.shieldStrength -= 0.006;
		GameBase::playSound(%player,ForceFieldClose,0); 
	} 
} 

function Renegades_startCloak(%clientId, %player) 
{
 	if (%clientId.cloakTime > 0) return;
	%armor = Player::getArmor(%player);
 	Client::sendMessage(%clientId,0,"[TAS]:Stealth Systems Active");
 	GameBase::playSound(%player,ForceFieldOpen,0);
 	GameBase::startFadeout(%player);
 	%rate = Player::getSensorSupression(%player) + 3;
 	Player::setSensorSupression(%player,%rate);
 	if(%clientId.cloakTime == 0) 
	{
 		%clientId.cloakTime = 16;
 		checkPlayerCloak(%clientId, %player);
 	}
 		else %clientId.cloakTime = 16;
}

function checkPlayerCloak(%clientId, %player) {
 
	%armor = Player::getArmor(%player); 
	if(%clientId.cloakTime > 0) { 
		%clientId.cloakTime -= 2; 
		if (Player::isDead(%player) || !(%armor == "aarmor" || %armor == "afemale" || %armor == "dmarmor" || %armor == "dmfemale")) %clientId.cloakTime = 0;
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} else { 
		Client::sendMessage(%clientId,0,"[TAS]:Stealth Systems Inactive");
		GameBase::playSound(%player,ForceFieldOpen,0); 
		GameBase::startFadein(%player); 
		Player::setSensorSupression(%player,0); 
	} 
} 

function Renegades_startJam(%clientId, %player) 
{ 
 	if (%clientId.jamTime > 0) return;
	%cursen = Player::getSensorSupression(%player);
	if(!%cursen)
		Client::sendMessage(%clientId,0,"[TAS]:Jamming Field On"); 
	GameBase::playSound(%player,ForceFieldOpen,0); 
	%rate = %cursen + 3;
	Player::setSensorSupression(%player,%rate); 
	%armor = Player::getArmor(%player); 
	if(%clientId.jamTime == 0) { 
			%clientId.jamTime = 8;
		checkPlayerJam(%clientId, %player); 
	} else { 
		%clientId.jamTime += 8; 
		if(%clientId.cloakTime > 16) 
		%clientId.cloakTime = 16; 
		} 
} 

function checkPlayerJam(%clientId, %player) { 
	%armor = Player::getArmor(%player); 
	if(%clientId.jamTime > 0) { 
		%clientId.jamTime -= 2; 
		if (Player::isDead(%player) || !(%armor == "larmor" || %armor == "lfemale")) %clientId.jamTime = 0;
		schedule("checkPlayerJam(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} else { 
		Client::sendMessage(%clientId,0,"[TAS]:Jamming Field Off");
		GameBase::playSound(%player,ForceFieldOpen,0); 
		GameBase::startFadein(%player); 
		Player::setSensorSupression(%player,0); 
	} 
} 
//---------------------------------------------------
 function DeploySatchel( %clientId, %player, %bec) {
 %item = "SatchelPack";
 %clientId = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
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
 if(checkDeployArea(%clientId,$los::position)) {
 %camera = newObject("Camera","Turret",DeployableSatchel,true);
 addToSet("MissionCleanup", %camera);
 GameBase::setTeam(%camera,GameBase::getTeam(%player));
 GameBase::setRotation(%camera,%rot);
 GameBase::setPosition(%camera,$los::position);
 Gamebase::setMapName(%camera,"Satchel Charge#"@ $totalNumCameras++ @ " " @ Client::getName(%clientId));
 Client::sendMessage(%clientId,0,"Satchel Charge#"@ $totalNumCameras @ " deployed. Set it off from within the Commander Screen.");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++;
 echo("MSG: ",%clientId," deployed a Satchel Charge.");
 Player::decItemCount(%player,%bec);
 return true;
 }
 }
 else {
 Client::sendMessage(%clientId,0,"Deploy position out of range");
 }
 }
 else Client::sendMessage(%clientId,0,"Deployable Item limit reached for Satchel Charges");
 return false;
 }

//-------
function EngMotion(%clientId, %player, %bec) 
{ 
   %item = "MotionSensorPack"; 
   %clientId = Player::getClient(%player); 
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
          {
            if (GameBase::getLOSInfo(%player,3)) 
                { 
                   %obj = getObjectType($los::object); 
                   if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") 
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
       if(checkDeployArea(%clientId,$los::position)) 
           {
             %camera = newObject("sensor_small","Sensor",DeployableMotionSensor,true);
             addToSet("MissionCleanup", %camera); 
             GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
             GameBase::setRotation(%camera,%rot); 
             GameBase::setPosition(%camera,$los::position); 
             Gamebase::setMapName(%camera,"MotionSensor");
             Client::sendMessage(%clientId,0,"Motion Sensor deployed"); 
             playSound(SoundPickupBackpack,$los::position); 
             $TeamItemCount[GameBase::getTeam(%camera) @ "MotionSensorPack"]++; 
             echo("MSG: ",%clientId," deployed a Motion Sensor"); 
             Player::decItemCount(%player,%bec); 
             return true; 
           } 
  } 
else 
{ 
Client::sendMessage(%clientId,0,"Can only deploy on terrain or buildings"); 
} 
} 
else { 
Client::sendMessage(%clientId,0,"Deploy position out of range"); 
} 
} 
else Client::sendMessage(%clientId,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 
 function ScoutSensor(%clientId, %player, %bec) {
 %item = "PulseSensorPack";
 %clientId = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
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
 if(checkDeployArea(%clientId,$los::position)) {
 %camera = newObject("radar_small","Sensor",DeployablePulseSensor,true);
 addToSet("MissionCleanup", %camera);
 GameBase::setTeam(%camera,GameBase::getTeam(%player));
 GameBase::setRotation(%camera,%rot);
 GameBase::setPosition(%camera,$los::position);
 Gamebase::setMapName(%camera,"Pulse Sensor");
 Client::sendMessage(%clientId,0,"Pulse Sensor deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%camera) @ "PulseSensorPack"]++;
 echo("MSG: ",%clientId," deployed a Pulse Sensor");
 Player::decItemCount(%player,%bec);
 return true;
 }
 }
 else {
 Client::sendMessage(%clientId,0,"Can only deploy on terrain or buildings");
 }
 }
 else {
 Client::sendMessage(%clientId,0,"Deploy position out of range");
 }
 }
 else Client::sendMessage(%clientId,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }
//--------

//-------
function ForceDeploy(%clientId, %player, %bec) {
 %item = "ForceFieldPack";
 %clientId = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 %set = newObject("set",SimSet);
 %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
 %num = CountObjects(%set,"DeployableForceField",%num);
 deleteObject(%set);
 if (Vector::dot($los::normal,"0 0 1") > 0.7) {
 %rot = GameBase::getRotation(%player);
 %phase = newObject("","StaticShape",DeployableForceField,true);
 addToSet("MissionCleanup", %phase);
 GameBase::setTeam(%phase,GameBase::getTeam(%player));
 GameBase::setPosition(%phase,$los::position);
 GameBase::setRotation(%phase,%rot);
 Gamebase::setMapName(%phase,"Force Field");
 Client::sendMessage(%clientId,0,"Force Field Deployed");
 GameBase::startFadeIn(%phase);
 playSound(SoundPickupBackpack,$los::position);
 playSound(ForceFieldOpen,$los::position);
 $TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;
 Player::decItemCount(%player,%bec);
 return true;
 }
 else Client::sendMessage(%clientId,0,"Can only deploy on flat surfaces");
 }
 else Client::sendMessage(%clientId,0,"Deploy position out of range");
 }
 else Client::sendMessage(%clientId,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
}
//-------
 function SniperJammer(%clientId, %player, %bec) {
 %item = "DeployableSensorJammerPack";
 %clientId = Player::getClient(%player);
 if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
 if (GameBase::getLOSInfo(%player,3)) {
 %obj = getObjectType($los::object);
 if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
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
 if(checkDeployArea(%clientId,$los::position)) {
 %camera = newObject("sensor_jammer","Sensor",DeployableSensorJammer,true);
 addToSet("MissionCleanup", %camera);
 GameBase::setTeam(%camera,GameBase::getTeam(%player));
 GameBase::setRotation(%camera,%rot);
 GameBase::setPosition(%camera,$los::position);
 Gamebase::setMapName(%camera,"SensorJammer");
 Client::sendMessage(%clientId,0,"SensorJammer deployed");
 playSound(SoundPickupBackpack,$los::position);
 $TeamItemCount[GameBase::getTeam(%camera) @ "DeployableSensorJammerPack"]++;
 echo("MSG: ",%clientId," deployed a Sensor Jammer");
 Player::decItemCount(%player,%bec);
 return true;
 }
 }
 else {
 Client::sendMessage(%clientId,0,"Can only deploy on terrain or buildings");
 }
 }
 else {
 Client::sendMessage(%clientId,0,"Deploy position out of range");
 }
 }
 else Client::sendMessage(%clientId,0,"Deployable Item limit reached for " @ %item.description @ "s");
 return false;
 }

 ItemData Plastique {
 description = "Grenade Mode";
 shapeFile = "sensor_small";
 heading = "gMiscellany";
 shadowDetailMask = 4;
 price = 5;
 className = "HandAmmo";
 }
;

 function Plastique::onUse(%player,%item) {
 if($matchStarted) {
 if(%player.throwTime < getSimTime() ) {
 %player.throwTime = getSimTime() + 0.5;
 %clientId = Player::getClient(%player);
 if( ($modeTime[%clientId] != 1) && ($modeTime[%clientId] != 2) && ($modeTime[%clientId] != 3) && ($modeTime[%clientId] != 4) && ($modeTime[%clientId] != 5) && ($modeTime[%clientId] != 6) ) {
 $modeTime[%clientId] = 0;
 }
 if($modeTime[%clientId] == 0) {
 Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Normal");
 $modeTime[%clientId] = 1;
 }
 if($modeTime[%clientId] == 1) {
 Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Fire");
 $modeTime[%clientId] = 2;
 }
 else if($modeTime[%clientId] == 2) {
 Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Shock");
 $modeTime[%clientId] = 3;
 }
 else if($modeTime[%clientId] == 3) {
 Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Poison");
 $modeTime[%clientId] = 4;
 }
 else if($modeTime[%clientId] == 4) {
 Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Mortar");
 $modeTime[%clientId] = 5;
 }
 else if($modeTime[%clientId] == 5) {
 Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Concussion");
 $modeTime[%clientId] = 6;
 }
 else if($modeTime[%clientId] == 6) {
 Client::sendMessage(Player::getClient(%player),1, "Grenade Type: Plastique Explosives");
 $modeTime[%clientId] = 1;
 }
 }
 }
 }
//================================================================================================ DetBug
ItemData DetBug
{	
	description = "Det Bug";
	className = "Ammo";
	shapeFile = "armorPatch";
   	heading = "xAmmunition";
	shadowDetailMask = 4;
  	price = 2;
};

function DetBug::onCollision(%this,%object)
{
	echo ("Det But Collide");
	%item = Item::getItemData(%this);
	%dropper = %this.dropper;
	
	echo ("This " @ %this);
	echo ("Obj. " @ %object);
	echo ("Drp. " @ %dropper);
	
	if (getObjectType(%object) == "Player" && GameBase::getTeam(%this) != GameBase::getTeam(%object) && GameBase::getTeam(%this) != -1)
	{
		Player::incItemCount(%object,%item,1);
		Item::playPickupSound(%this);				
		DetBug::onUse(%object, %item, %dropper);
		deleteObject(%this);
	}
	else
		return;
}

function DetBug::Detonate(%this)
{
	%obj = newObject("","Mine","EMPBlast");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 1.5";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	deleteObject(%this);
	GameBase::setPosition(%obj, %pos);
}

function DetBug::onUse(%player,%item, %dropper)
{
	DetBug::CheckDet(%player, %item, %dropper, 10);
}

function DetBug::CheckDet(%player, %item, %dropper, %time)
{
	%clientId = Player::getClient(%player);
	%clientId.lastdropper = %dropper;
	echo ("Checking");
	echo ("Player  " @ %player);
	echo ("Item    " @ %item);
	echo ("Dropper " @ %dropper);
	echo ("Time    " @ %time);

	if(%time > 0)
	{
		%time -= 2;
	        bottomprint(%clientId, "<jc><f2>[TAS]:You have a DetBug *YOU* will detonate in " @ %time @ " seconds.", 2);
		
		if (Player::getItemCount(%player,"DetBug"))
		{
			if  (!Player::isDead(%player)) 
			{  
				echo ("Waiting");
				Player::setDamageFlash(%player,0.35);
				schedule("DetBug::CheckDet(" @ %player @ ", " @ %item @ ", " @ %dropper @ ", " @ %time @ ");",2, %player);
			}
			else
			{
				%time = 0;
				return;
			}
		}
		else
		{
			%time = 0;
			return;
		}
   	}
	else
	{
		%obj = newObject("","Mine","EMPBlast");
		addToSet("MissionCleanup", %obj);
		%padd = "0 0 3.5";
		%pos = Vector::add(GameBase::getPosition(%player), %padd);
		GameBase::setPosition(%obj, %pos);	

		%dammulta = (GameBase::getDataName(%player).maxDamage);
		%dammultb = GameBase::getDamageLevel(%player);
		%multiplier = (%dammulta - %dammultib) * 10;
		Player::blowUp(%player);
		GameBase::playSound(%player, SoundFireMortar, 0);
		
		GameBase::applyRadiusDamage($FlashDamageType, getBoxCenter(%player), (gamebase::GetRadius(%player) * 2), %multiplier, 5, %dropper);
		
		Client::sendMessage(%clientId,0,"[TAS]:...BOOM...");
	}	
}

function DetBug::onDrop(%player,%item)
{
	
	%clientId = Player::getClient(%player);
	%lastdropper = %clientId.lastdropper;
	
	echo ("ITEM = " @ %item);
	echo ("Last = " @ %lastdropper);
	echo ("CL   = " @ %clientId);
	
	%obj = newObject("","Item",%item,1,false);
	schedule("Item::Pop(" @ %obj @ ");", 5.0, %obj);
	addToSet("MissionCleanup", %obj);
	%obj.dropper = %lastdropper;

	GameBase::SetTeam(%obj, -1);
	
	if (Player::isDead(%player)) 
		GameBase::throw(%obj,%player,10,true);
	else
	{
		GameBase::throw(%obj,%player,15,false);
		Item::playPickupSound(%obj);
	}
	Player::decItemCount(%player,%item,1);
	schedule("DetBug::Detonate(" @ %obj @ ");", 4);

}
 ItemData RepairPatch {
 description = "Repair Patch";
 className = "Repair";
 shapeFile = "armorPatch";
 heading = "gMiscellany";
 shadowDetailMask = 4;
 price = 2;
 }
;
 function RepairPatch::onCollision(%this,%object) {
 if (getObjectType(%object) == "Player") {
 if(GameBase::getDamageLevel(%object)) {
 GameBase::repairDamage(%object,0.125);
 %c = Player::getClient(%object);
 %c.poisonTime = 0;
 %item = Item::getItemData(%this);
 Item::playPickupSound(%this);
 Item::respawn(%this);
 }
 }
 }
 function RepairPatch::onUse(%player,%item) {
 Player::decItemCount(%player,%item);
 GameBase::repairDamage(%player,0.1);
 }
 function remoteGiveAll(%clientId) {
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
 Player::setItemCount(%clientId,Beacon, 200);
 Player::setItemCount(%clientId,RepairKit,200);
 }
 else if($ServerCheats) {
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

 function checkMax(%client,%armor) {
 %weaponflag = 0;
 %numweapon = Player::getItemClassCount(%client,"Weapon");
 if (%numweapon > $MaxWeapons[%armor]) {
 %weaponflag = %numweapon - $MaxWeapons[%armor];
 }
 %max = getNumItems();
 for (%i = 0;
 %i < %max;
 %i = %i + 1) {
 %item = getItemData(%i);
 %maxnum = $ItemMax[%armor, %item];
 if(%maxnum != "") {
 %numsell = 0;
 %count = Player::getItemCount(%client,%item);
 if(%count > %maxnum) {
 %numsell = %count - %maxnum;
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
 function checkPlayerCash(%client) {
 %team = Client::getTeam(%client);
 if($TeamEnergy[%team] != "Infinite") {
 if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) {
 if(%client.teamEnergy >= 0) %diff = $InitialPlayerEnergy;
 else %diff = $InitialPlayerEnergy + %client.teamEnergy;
 $TeamEnergy[%team] -= %diff;
 }
 }
 }
 function Mission::reinitData() {
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
 $TeamItemCount[0 @ ForceFieldDoorPack] = 0;
 $TeamItemCount[1 @ ForceFieldDoorPack] = 0;
 $TeamItemCount[2 @ ForceFieldDoorPack] = 0;
 $TeamItemCount[3 @ ForceFieldDoorPack] = 0;
 $TeamItemCount[4 @ ForceFieldDoorPack] = 0;
 $TeamItemCount[5 @ ForceFieldDoorPack] = 0;
 $TeamItemCount[6 @ ForceFieldDoorPack] = 0;
 $TeamItemCount[7 @ ForceFieldDoorPack] = 0;
 $TeamItemCount[0 @ LaserPack] = 0;
 $TeamItemCount[1 @ LaserPack] = 0;
 $TeamItemCount[2 @ LaserPack] = 0;
 $TeamItemCount[3 @ LaserPack] = 0;
 $TeamItemCount[4 @ LaserPack] = 0;
 $TeamItemCount[5 @ LaserPack] = 0;
 $TeamItemCount[6 @ LaserPack] = 0;
 $TeamItemCount[7 @ LaserPack] = 0;
 $TeamItemCount[0 @ FlameTurretPack] = 0;
 $TeamItemCount[1 @ FlameTurretPack] = 0;
 $TeamItemCount[2 @ FlameTurretPack] = 0;
 $TeamItemCount[3 @ FlameTurretPack] = 0;
 $TeamItemCount[4 @ FlameTurretPack] = 0;
 $TeamItemCount[5 @ FlameTurretPack] = 0;
 $TeamItemCount[6 @ FlameTurretPack] = 0;
 $TeamItemCount[7 @ FlameTurretPack] = 0;
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
 $TeamItemCount[0 @ CorAirVehicle] = 0;
 $TeamItemCount[1 @ CorAirVehicle] = 0;
 $TeamItemCount[2 @ CorAirVehicle] = 0;
 $TeamItemCount[3 @ CorAirVehicle] = 0;
 $TeamItemCount[4 @ CorAirVehicle] = 0;
 $TeamItemCount[5 @ CorAirVehicle] = 0;
 $TeamItemCount[6 @ CorAirVehicle] = 0;
 $TeamItemCount[7 @ CorAirVehicle] = 0;
 $TeamItemCount[0 @ SLAPCVehicle] = 0;
 $TeamItemCount[1 @ SLAPCVehicle] = 0;
 $TeamItemCount[2 @ SLAPCVehicle] = 0;
 $TeamItemCount[3 @ SLAPCVehicle] = 0;
 $TeamItemCount[4 @ SLAPCVehicle] = 0;
 $TeamItemCount[5 @ SLAPCVehicle] = 0;
 $TeamItemCount[6 @ SLAPCVehicle] = 0;
 $TeamItemCount[7 @ SLAPCVehicle] = 0;
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
 $TeamItemCount[0 @ LargeForceFieldPack] = 0;
 $TeamItemCount[1 @ LargeForceFieldPack] = 0;
 $TeamItemCount[2 @ LargeForceFieldPack] = 0;
 $TeamItemCount[3 @ LargeForceFieldPack] = 0;
 $TeamItemCount[4 @ LargeForceFieldPack] = 0;
 $TeamItemCount[5 @ LargeForceFieldPack] = 0;
 $TeamItemCount[6 @ LargeForceFieldPack] = 0;
 $TeamItemCount[7 @ LargeForceFieldPack] = 0;
 $TeamItemCount[0 @ LargeForceFieldDoorPack] = 0;
 $TeamItemCount[1 @ LargeForceFieldDoorPack] = 0;
 $TeamItemCount[2 @ LargeForceFieldDoorPack] = 0;
 $TeamItemCount[3 @ LargeForceFieldDoorPack] = 0;
 $TeamItemCount[4 @ LargeForceFieldDoorPack] = 0;
 $TeamItemCount[5 @ LargeForceFieldDoorPack] = 0;
 $TeamItemCount[6 @ LargeForceFieldDoorPack] = 0;
 $TeamItemCount[7 @ LargeForceFieldDoorPack] = 0;
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
 $TeamItemCount[0 @ BigInvPack] = 0;
 $TeamItemCount[1 @ BigInvPack] = 0;
 $TeamItemCount[2 @ BigInvPack] = 0;
 $TeamItemCount[3 @ BigInvPack] = 0;
 $TeamItemCount[4 @ BigInvPack] = 0;
 $TeamItemCount[5 @ BigInvPack] = 0;
 $TeamItemCount[6 @ BigInvPack] = 0;
 $TeamItemCount[7 @ BigInvPack] = 0;
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
 $TeamItemCount[0 @ DeployableLRMotionSensorPack] = 0;
 $TeamItemCount[1 @ DeployableLRMotionSensorPack] = 0;
 $TeamItemCount[2 @ DeployableLRMotionSensorPack] = 0;
 $TeamItemCount[3 @ DeployableLRMotionSensorPack] = 0;
 $TeamItemCount[4 @ DeployableLRMotionSensorPack] = 0;
 $TeamItemCount[5 @ DeployableLRMotionSensorPack] = 0;
 $TeamItemCount[6 @ DeployableLRMotionSensorPack] = 0;
 $TeamItemCount[7 @ DeployableLRMotionSensorPack] = 0;
 $TeamItemCount[0 @ DeployableFieldSensorPack] = 0;
 $TeamItemCount[1 @ DeployableFieldSensorPack] = 0;
 $TeamItemCount[2 @ DeployableFieldSensorPack] = 0;
 $TeamItemCount[3 @ DeployableFieldSensorPack] = 0;
 $TeamItemCount[4 @ DeployableFieldSensorPack] = 0;
 $TeamItemCount[5 @ DeployableFieldSensorPack] = 0;
 $TeamItemCount[6 @ DeployableFieldSensorPack] = 0;
 $TeamItemCount[7 @ DeployableFieldSensorPack] = 0;
 $totalNumCameras = 0;
 $totalNumTurrets = 0;
 for(%i = -1;
 %i < 8 ;
 %i++) $TeamEnergy[%i] = $DefaultTeamEnergy;
 }
 