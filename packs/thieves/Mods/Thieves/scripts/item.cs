$ItemFavoritesKey = "Tr001"; 
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
$AutoUse[ChargeGun] = True;
$Use[Blaster] = True;
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;
$AmmoPackItemsMax=9; 
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
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
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
function teamEnergyBuySell(%player,%cost)
{
%client = Player::getClient(%player);
%team = Client::getTeam(%client);
%station = %player.Station;
%stationName = GameBase::getDataName(%station); 
if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) {
%station.Energy += %cost; 
if(%station.Energy < 1)
%station.Energy = 0;
}
else if($TeamEnergy[%team] != "Infinite") { 
$TeamEnergy[%team] += %cost; 
%client.teamEnergy += %cost; 
}
}
function isPlayerBusy(%client)
{
%state = Player::getItemState(%client,$WeaponSlot);
return %state == "Fire" || %state == "Reload";
}
function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
if (isPlayerBusy(%client))
return;
%time = getIntegerTime(true) >> 4; 
if(%time <= %client.lastBuyFavTime)
return;
%client.lastBuyFavTime = %time;
%station = (Client::getOwnedObject(%client)).Station;
if(%station != "") {
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
if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client), %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) {
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
%delta = %energy /%item.price; 
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
else if($TeamItemMax[%item] != ""&& !$TestCheats) {
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
function buyItem(%client,%item)
{
%player = Client::getOwnedObject(%client);
%armor = Player::getArmor(%client);
if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && 
($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
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
if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
fillAmmoPack(%client); 
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
%pack = Player::getMountedItem(%client,$BackpackSlot);
if (%pack != -1) {
if(%pack == ammopack) 
checkMax(%client,%armor);
else if(%pack == EnergyPack) {
if(Player::getItemCount(%client,"LaserRifle") > 0) {
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
if(%client.respawn == ""&& %player.Station != "") {
%sPos = GameBase::getPosition(%player.Station);
%pPos = GameBase::getPosition(%client);
%posX = getWord(%sPos,0);
%posY = getWord(%sPos,1);
%posZ = getWord(%pPos,2);
%vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1); 
%newPosX = (getWord(%vec,0) * 1) + %posX; 
%newPosY = (getWord(%vec,1) * 1) + %posY;
GameBase::setPosition(%client, %newPosX @ " "@ %newPosY @ " "@ %posZ);
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
else if(%item == EnergyPack) { 
if(Player::getItemCount(%client,"LaserRifle") > 0) {
Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
remoteSellItem(%client,22); 
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
%item = getItemData(%type);
if (%item == Grenade || %item == MineAmmo) {
if (%strength < 0)
%strength = 0;
else
if (%strength > 100)
%strength = 100;
%client.throwStrength = 0.3 + 0.7 * (%strength /100);
Player::useItem(%client,%item);
}
}
function remoteDropItem(%client,%type)
{
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
%item = getItemData(%type);
Player::deployItem(%client,%item);
}
$NextWeapon[Blaster]=HyperBlaster;
$NextWeapon[HyperBlaster]=PlasmaGun;
$NextWeapon[PlasmaGun]=Incinerator;
$NextWeapon[Incinerator]=Chaingun;
$NextWeapon[Chaingun]=ATC;
$NextWeapon[ATC]=BlastCannon;
$NextWeapon[BlastCannon]=HeavyATC;
$NextWeapon[HeavyATC]=HeavyBlastCannon;
$NextWeapon[HeavyBlastCannon]=DiscLauncher;
$NextWeapon[DiscLauncher]=GrenadeLauncher;
$NextWeapon[GrenadeLauncher]=Disruptor;
$NextWeapon[Disruptor]=LaserRifle;
$NextWeapon[LaserRifle]=Railgun;
$NextWeapon[Railgun]=NaniteBurstRifle;
$NextWeapon[NaniteBurstRifle]=Mortar;
$NextWeapon[Mortar]=Minion;
$NextWeapon[Minion]=EnergyRifle;
$NextWeapon[EnergyRifle]=GravGun;
$NextWeapon[GravGun]=AntiGravGun;
$NextWeapon[AntiGravGun]=DimensionalRifter;
$NextWeapon[DimensionalRifter]=Blaster;
$PrevWeapon[Blaster]=DimensionalRifter;
$PrevWeapon[HyperBlaster]=Blaster;
$PrevWeapon[PlasmaGun]=HyperBlaster;
$PrevWeapon[Incinerator]=PlasmaGun;
$PrevWeapon[Chaingun]=Incinerator;
$PrevWeapon[ATC]=Chaingun;
$PrevWeapon[BlastCannon]=ATC;
$PrevWeapon[HeavyATC]=BlastCannon;
$PrevWeapon[HeavyBlastCannon]=HeavyATC;
$PrevWeapon[DiscLauncher]=HeavyBlastCannon;
$PrevWeapon[GrenadeLauncher]=DiscLauncher;
$PrevWeapon[Disruptor]=GrenadeLauncher;
$PrevWeapon[LaserRifle]=Disruptor;
$PrevWeapon[Railgun]=LaserRifle;
$PrevWeapon[NaniteBurstRifle]=Railgun;
$PrevWeapon[Mortar]=NaniteBurstRifle;
$PrevWeapon[Minion]=Mortar;
$PrevWeapon[EnergyRifle]=Minion;
$PrevWeapon[GravGun]=EnergyRifle;
$PrevWeapon[AntiGravGun]=GravGun;
$PrevWeapon[DimensionalRifter]=AntiGravGun;
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
if (%ammo == ""|| Player::getItemCount(%client,%ammo) > 0)
return true;
}
return false;
}
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
else {
if (%item.className == Weapon) {
if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) 
return 0;
} 
%extraAmmo = 0 ;
if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%item] != "") 
%extraAmmo = $AmmoPackMax[%item];
%count = Player::getItemCount(%player,%item);
if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) 
%delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
if (%delta > 0) {
Player::incItemCount(%player,%item,%delta);
if (%count == 0 && $AutoUse[%item]) 
Player::useItem(%player,%item);
Client::sendMessage(%client,0,"You received " @ %delta @ " "@ %item.description);
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
if($matchStarted) {
if(%item.className != Armor) {
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
ItemData InfiltratorArmor
{
heading = "cArmor";
description = "Infiltrator";
className = "Armor";
price = 145;
};
ItemData LightArmor
{
heading = "cArmor";
description = "Sniper";
className = "Armor";
price = 150;
};
ItemData SoldierArmor
{
heading = "cArmor";
description = "Psycho";
className = "Armor";
price = 225;
};
ItemData MediumArmor
{
heading = "cArmor";
description = "Mercenary";
className = "Armor";
price = 250;
};
ItemData AvengerArmor
{
heading = "cArmor";
description = "Kamikaze";
className = "Armor";
price = 250;
};
ItemData PredatorArmor
{
heading = "cArmor";
description = "Murderer";
className = "Armor";
price = 250;
};
ItemData HeavyArmor
{
heading = "cArmor";
description = "Engineer";
className = "Armor";
price = 400;
};
ItemData DreadnaughtArmor
{
heading = "cArmor";
description = "Tank";
className = "Armor";
price = 500;
};
ItemData ScoutVehicle
{
description = "Scout";
className = "Vehicle";
heading = "aVehicle";
price = 600;
};
ItemData LAPCVehicle
{
description = "LPC";
className = "Vehicle";
heading = "aVehicle";
price = 675;
};
ItemData HAPCVehicle
{
description = "HPC";
className = "Vehicle";
heading = "aVehicle";
price = 875;
};
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
exec(BaseWeapBlaster);
exec(TrWeapHyperb);
exec(BaseWeapPlasmagun);
exec(TrWeapFlameThrower);
exec(BaseWeapChaingun);
exec(TrWeapATC);
exec(TrWeapBlastCannon);
exec(TrWeapHATC);
exec(TrWeapHBlastCannon);
exec(BaseWeapDiscLauncher);
exec(BaseWeapGrenadeLauncher);
exec(TrWeapDisruptor);
exec(BaseWeapLaserRifle);
exec(TrWeapRailgun);
exec(TrWeapNBurst);
exec(BaseWeapMortar);
exec(TrWeapMinion);
exec(BaseWeapEnergyRifle);
exec(TrWeapGravGun);
exec(TrWeapAGravGun);
exec(TrWeapDRifter);
exec(BaseWeapTargetingLaser);
exec(BaseWeapRepairGun);
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
heading = "lDeployables";
shadowDetailMask = 4 ;
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
if (CheckDeployTerrain($los::object)) {
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
heading = "lDeployables";
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
if (CheckDeployTerrain($los::object)) {
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
heading = "iBackpacks";
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
function EnergyPack::onUnmount(%player,%item)
{
if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
Player::unmountItem(%player,$WeaponSlot);
}
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
};
ItemData RepairPack
{
description = "Repair Pack";
shapeFile = "armorPack";
className = "Backpack";
heading = "iBackpacks";
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
Player::mountItem(%player,%mounted,$WeaponSlot);
}
Item::onDrop(%player,%item);
}
} 
ItemImageData ShieldPackImage
{
shapeFile = "shieldPack";
mountPoint = 2;
weaponType = 2; 
minEnergy = 4;
maxEnergy = 9; 
sfxFire = SoundShieldOn;
firstPerson = false;
};
ItemData ShieldPack
{
description = "Shield Pack";
shapeFile = "shieldPack";
className = "Backpack";
heading = "iBackpacks";
shadowDetailMask = 4;
imageType = ShieldPackImage;
price = 175;
hudIcon = "shieldpack";
showWeaponBar = true;
hiliteOnActive = true;
};
function ShieldPackImage::onActivate(%player,%imageSlot)
{
%player.shieldFailed=False;
if(%player.shieldStrength==0) {
Client::sendMessage(Player::getClient(%player),0,"Shield On");
} else {
Client::sendMessage(Player::getClient(%player),0,"Shields incompatable.  You are already shielded.");
Player::trigger(%player,$BackpackSlot,false);
%player.shieldFailed=True;
return;
}
%player.shieldStrength = 0.012;
}
function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
if(%player.shieldFailed=="False") {
Client::sendMessage(Player::getClient(%player),0,"Shield Off");
Player::trigger(%player,$BackpackSlot,false);
%player.shieldStrength = 0;
} else {
%player.shieldFailed="False";
}
}
ItemImageData SensorJammerPackImage
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
ItemData SensorJammerPack
{
description = "Sensor Jammer Pack";
shapeFile = "sensorjampack";
className = "Backpack";
heading = "iBackpacks";
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
heading = "lDeployables";
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
function MotionSensorPack::deployShape(%player,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
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
ItemImageData AmmoPackImage
{
shapeFile = "AmmoPack";
mountPoint = 2;
mountOffset = { 0, -0.03, 0 };
firstPerson = false;
};
ItemData AmmoPack
{
description = "Ammo Pack";
shapeFile = "AmmoPack";
className = "Backpack";
heading = "iBackpacks";
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
if($matchStarted) {
%item = Item::onDrop(%player,%item);
for(%i = 0; %i < 7 ; %i = %i +1) {
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
%item.MortarAmmo = %numPack;
}
else {
%item.MineAmmo = %numPack;
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
for(%i = 0; %i < 7 ; %i = %i +1) {
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
else {
%numAdd = %item.MineAmmo;
}
Player::incItemCount(%player,%ammoItem,%numAdd);
} 
}
function fillAmmoPack(%client)
{
%player = Client::getOwnedObject(%client);
for(%i = 0; %i < $AmmoPackItemsMax ; %i = %i +1) {
%item = $AmmoPackItems[%i];
%maxnum = $AmmoPackMax[%item];
%maxnum = checkResources(%player,%item,%maxnum); 
if(%maxnum) {
Player::incItemCount(%client,%item,%maxnum);
teamEnergyBuySell(%player,%item.price * %maxnum * -1);
} 
}
}
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
heading = "lDeployables";
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
heading = "lDeployables";
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
heading = "lDeployables";
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
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
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
Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " "@ Client::getName(%client));
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
description = "Turret";
shapeFile = "remoteturret";
className = "Backpack";
heading = "oTurrets";
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
if (CheckDeployTerrain($los::object)) {
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
Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " "@ Client::getName(%client));
Client::sendMessage(%client,0,"Remote Turret deployed");
playSound(SoundPickupBackpack,$los::position);
$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
echo("MSG: ",%client," deployed a Remote Turret");
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
else {
%tobj=0;
for(%x=0;%x<%num;%x++) {
%obj=Group::getObject(%set,%x);
if(GameBase::getDataName(%obj)!="DeployableBaseOps"&&GameBase::getDataName(%obj)!="DeployablePlatform") %tobj++;
}
if(!%tobj){
deleteObject(%set);
return 1;
} else {
Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
}
}
deleteObject(%set);
return 0; 
}
function checkForceFieldDeployArea(%client,%pos)
{
%set=newObject("set",SimSet);
%tpos=Vector::add(%pos,"0 0 -5000");
%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%tpos,1,1,1,1);
if(%num) {
Client::sendMessage(%client,0,"Unable to deploy - Moving object already present here.");
deleteObject(%set);
return(0);
}
deleteObject(%set);
%set=newObject("set",SimSet);
%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
if(!%num) {
deleteObject(%set);
return 1;
}
if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "StaticShape" && (GameBase::getDataName(Group::getObject(%set,0)) == "DeployableForceField"
|| GameBase::getDataName(Group::getObject(%set,0)) == "DeployableLargeForceField"
||GameBase::getDataName(Group::getObject(%set,0)) == "DeployableBlastDoor")) { 
return 1;
}
else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
%obj = Group::getObject(%set,0); 
if(Player::getClient(%obj) == %client) 
Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
else
Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
} else {
%tobj=0;
for(%x=0;%x<%num;%x++) {
%obj=Group::getObject(%set,%x);
if(GameBase::getDataName(%obj)!="DeployableBaseOps"&&GameBase::getDataName(%obj)!="DeployablePlatform") %tobj++;
}
if(!%tobj){
deleteObject(%set);
return 1;
} else {
Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
}
}
deleteObject(%set);
return 0; 
}
function Item::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
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
function checkForceFieldDeployArea(%client,%pos)
{
%set=newObject("set",SimSet);
%tpos=Vector::add(%pos,"0 0 -5000");
%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%tpos,1,1,1,1);
if(%num) {
Client::sendMessage(%client,0,"Unable to deploy - Moving object already present here.");
deleteObject(%set);
return(0);
}
deleteObject(%set);
%set=newObject("set",SimSet);
%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
if(!%num) {
deleteObject(%set);
return 1;
}
if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "StaticShape" && (GameBase::getDataName(Group::getObject(%set,0)) == "DeployableForceField"
|| GameBase::getDataName(Group::getObject(%set,0)) == "DeployableLargeForceField"
||GameBase::getDataName(Group::getObject(%set,0)) == "DeployableBlastDoor")) { 
return 1;
}
else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { 
%obj = Group::getObject(%set,0); 
if(Player::getClient(%obj) == %client) 
Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
else
Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
} else {
%tobj=0;
for(%x=0;%x<%num;%x++) {
%obj=Group::getObject(%set,%x);
if(GameBase::getDataName(%obj)!="DeployableBaseOps"&&GameBase::getDataName(%obj)!="DeployablePlatform") %tobj++;
}
if(!%tobj){
deleteObject(%set);
return 1;
} else {
Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
}
}
deleteObject(%set);
return 0; 
}
function Item::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
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
$AutoUse[RepairKit] = false;
ItemData RepairKit
{
description = "Repair Kit";
shapeFile = "armorKit";
heading = "rMiscellany";
shadowDetailMask = 4;
price = 35;
};
function RepairKit::onUse(%player,%item)
{
echo("RepairKit::onUse called");
Player::decItemCount(%player,%item);
GameBase::repairDamage(%player,0.2);
}
ItemData MineAmmo
{
description = "Mine";
shapeFile = "mineammo";
heading = "rMiscellany";
shadowDetailMask = 4;
price = 10;
className = "HandAmmo";
};
function MineAmmo::onUse(%player,%item)
{
if($matchStarted) {
if(%player.throwTime < getSimTime() ) {
Player::decItemCount(%player,%item);
%armorclass=gamebase::getdataname(%player);
if(%armorclass=="infarmor"||%armorclass=="inffarmor")
%obj = newObject("","Mine","antipersonelCloneMine");
else if(%armorclass=="dreadarmor") 
%obj = newObject("","Mine","antipersonelRiftMine");
else
%obj = newObject("","Mine","antipersonelMine");
addToSet("MissionCleanup", %obj);
%client = Player::getClient(%player);
GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
%player.throwTime = getSimTime() + 0.5;
GameBase::setTeam(%obj,GameBase::getTeam(%client));
if(%armorclass=="infarmor"||%armorclass=="inffarmor")
GameBase::setRotation("\""@%obj,GameBase::getRotation(%player)@"\"");
echo("Mine::Deployed object #"@%obj@".  Team="@GameBase::getTeam(%obj));
} 
}
}
ItemData Grenade
{
description = "Grenade";
shapeFile = "grenade";
heading = "rMiscellany";
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
ItemData Beacon
{
description = "Beacon";
shapeFile = "sensor_small";
heading = "rMiscellany";
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
%armor=Player::getArmor(%player);
if(%armor=="infarmor"||%armor=="inffarmor") {
return(Beacon::setPersonalTeleport(%player,%item));
}
if(Player::getArmor(%player)=="avarmor" || Player::getArmor(%player)=="avfarmor") {
return(PhaseLokPack::deployShape(%player,%item));
}
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
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
%tobj=0;
for(%x=0;%x<%num;%x++) {
%obj=Group::getObject(%set,%x);
if(GameBase::getDataName(%obj)!="DeployableBaseOps"&&GameBase::getDataName(%obj)!="DeployablePlatform") %tobj++;
}
deleteObject(%set);
%num=%tobj;
if(!%num) {
%team = GameBase::getTeam(%player);
if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
addToSet("MissionCleanup", %beacon);
GameBase::setTeam(%beacon,GameBase::getTeam(%player));
GameBase::setRotation(%beacon,%rot);
GameBase::setPosition(%beacon,$los::position);
Gamebase::setMapName(%beacon,"Target Beacon");
Beacon::onEnabled(%beacon);
Client::sendMessage(%client,0,"Beacon deployed");
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
function Beacon::setPersonalTeleport(%player,%item)
{
%client = Player::getClient(%player);
%teleset = nameToID("MissionCleanup/PersonalWarp/!"@Client::getName(%client));
if(%teleset != -1)
{ 
%objcount=Group::objectCount(%teleset);
for(%c=0;%c<%objcount;%c++) {
%object=Group::getObject(%teleset,%c);
if(GameBase::getPosition(%object)!="0 0 0") {
%oldpos=GameBase::getPosition(%player);
%oldrot=GameBase::getRotation(%player);
if(Player::getArmor(%player)=="infarmor") 
{%beacon = newObject("", "StaticShape", "DefaultBeaconWarpCloneMale", true);}
else
{%beacon = newObject("", "StaticShape", "DefaultBeaconWarpCloneFemale", true);}
GameBase::setMapName(%beacon,Client::getName(%client));
GameBase::setPosition(%player, Vector::add(GameBase::getPosition(%object),"0 0 0.25"));
GameBase::setRotation(%beacon,%oldrot);
if(Player::getArmor(%player)=="inffarmor") %oldpos=Vector::add(%oldpos,"0 0 1");
Client::setOwnedObject(%client, %beacon); 
Client::setOwnedObject(%client, %player);
GameBase::setPosition(%beacon,%oldpos);
GameBase::setIsTarget(%beacon,False);
GameBase::setTeam(%beacon,GameBase::getTeam(%player));
addToSet("MissionCleanup",%beacon);
schedule("GameBase::startfadeOut("@%beacon@");",6);
schedule("deleteObject("@%beacon@");",9);
schedule("GameBase::playSound("@%object@",SoundBeaconUse,0);",0.35); 
%pteam=GameBase::getTeam(%player);
%oteam=GameBase::getTeam(%object);
if(%pteam!=%oteam) {
Client::sendMessage(%client,0,"You disintegrate upon dimensional reentry.");
Player::blowUp(%player);
schedule("GameBase::applyDamage("@%player@","@$CrushDamageType@",5,\""@GameBase::getPosition(%player)@"\",\"0 0 0\",\"0 0 0\","@%object@");",0.10);
%object.usesleft=0;
} else {
Client::sendMessage(%client,0,"Dimensional warp to set point successful.");
}
if(%object.usesleft--<=0) {
GameBase::applyDamage(%object,$DebrisDamageType,1,GameBase::getPosition(%object),"0 0 0","0 0 0",%object);
Client::sendMessage(%client,0,"Warp point disintegrates.");
}
return(true);
}
}
}
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
%set=newObject("set",SimSet);
%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
deleteObject(%set);
if(!%num) {
%team = GameBase::getTeam(%player);
%beacon = newObject("Warp Point ("@Client::getName(%client)@")", "StaticShape", "DefaultBeacon", true);
addToSet("MissionCleanup", %beacon);
%teleset = nameToID("MissionCleanup/PersonalWarp");
if(%teleset == -1)
{
newObject("PersonalWarp",SimSet);
addToSet("MissionCleanup","PersonalWarp");
}
%teleset = nameToID("MissionCleanup/PersonalWarp/!"@Client::getName(%client));
if(%teleset == -1)
{
newObject("!"@Client::getName(%client),SimSet);
addToSet("MissionCleanup/PersonalWarp","!"@Client::getName(%client));
}
addToSet("MissionCleanup/PersonalWarp/!"@Client::getName(%client), %beacon);
GameBase::setTeam(%beacon,GameBase::getTeam(%player));
GameBase::setRotation(%beacon,GameBase::getRotation(%player));
GameBase::setPosition(%beacon,$los::position);
Gamebase::setMapName(%beacon,"Warp ("@Client::getName(%client)@")");
GameBase::setIsTarget(%beacon,False);
%beacon.usesleft=3; 
Client::sendMessage(%client,0,"Warp point set.");
schedule("Beacon::PersonalTeleportClientCheck("@%client@",\""@Client::getName(%client)@"\","@%beacon@");",10);
playSound(SoundPickupBackpack,$los::position);
return true;
}
else
Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
}
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
}
else 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
}
else {
Client::sendMessage(%client,0,"Deploy position out of range");
}
return false;
}
function Beacon::PersonalTeleportClientCheck(%client,%ownername,%object) {
if(GameBase::getPosition(%object)=="0 0 0") return;
if(Client::getName(%client)!=%ownername) {
GameBase::applyDamage(%object,$DebrisDamageType,1,GameBase::getPosition(%object),"0 0 0","0 0 0",%object);
return;
}
schedule("Beacon::PersonalTeleportClientCheck("@%client@",\""@%ownername@"\","@%object@");",10);
}
ItemData RepairPatch
{
description = "Repair Patch";
className = "Repair";
shapeFile = "armorPatch";
heading = "rMiscellany";
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
%numsell = %count - %maxnum;
}
if (%count > 0 && %weaponflag && %item.className == Weapon) {
%numsell = 1;
%weaponflag = %weaponflag - 1;
}
if(%numsell > 0) {
Client::sendMessage(%client,0,"SOLD " @ %numsell @ " "@ %item);
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
exec(TrItem);
function Mission::reinitData()
{
if($Tr::Debug) echo($DebugHeading::Tr @ "Mission::reinitdata()");
for(%i=-1;%i<8;%i++) {
$TeamItemCount[%i @ DeployableAmmoPack] = 0;
$TeamItemCount[%i @ DeployableInvPack] = 0;
$TeamItemCount[%i @ TurretPack] = 0;
$TeamItemCount[%i @ CameraPack] = 0;
$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
$TeamItemCount[%i @ PulseSensorPack] = 0;
$TeamItemCount[%i @ MotionSensorPack] = 0;
$TeamItemCount[%i @ ScoutVehicle] = 0;
$TeamItemCount[%i @ LAPCVehicle] = 0;
$TeamItemCount[%i @ HAPCVehicle] = 0;
$TeamItemCount[%i @ Beacon] = 0;
$TeamItemCount[%i @ mineammo] = 0;
$TeamItemCount[%i @ DeployableTeleport] = 0;
$TeamItemCount[%i @ DShield] = 0;
$TeamItemCount[%i @ RocketTurretPack] = 0;
$TeamItemCount[%i @ DeployableForceField] = 0;
$TeamItemCount[%i @ DeployableLargeForceField] = 0;
$TeamItemCount[%i @ PhaseLokPack] = 0;
$TeamItemCount[%i @ DeployablePlatform] = 0;
$TeamItemCount[%i @ DeployableBlastDoor] = 0;
$TeamItemCount[%i @ DeployableBaseOps] = 0;
$TeamItemCount[%i @ DeployableTNTPak] = 0;
$TeamItemCount[%i @ DeployablePDS] = 0;
$TeamItemCount[%i @ PhaseLokAmmo] = 0;
}
$totalNumCameras = 0;
$totalNumTurrets = 0;
$totalNumRocketTurrets = 0;
for(%i = -1; %i < 8 ; %i++)
$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
