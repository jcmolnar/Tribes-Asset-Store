$PhobiaxFavoritesKey = "Phobiax";
$InsomniaxFavoritesKey = "PxInsomniax";

function pxPhobiaxFavoritesKey()
{
  if($Phobiax::ExpansionItems)
  {
    $ItemFavoritesKey = $PhobiaxFavoritesKey;
  }
  else
  {
    $ItemFavoritesKey = $InsomniaxFavoritesKey;
  }
}
pxPhobiaxFavoritesKey();

$ItemPopTime = 30;
$ToolSlot = 0;
$WeaponSlot = 0;
$BackpackSlot = 1;
$FlagSlot = 2;
$DefaultSlot = 3;

$AutoUse[Blaster] = True;
$AutoUse[Chaingun] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[PlasmaGun] = True;
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;

$Use[DiscLauncher] = True;

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

DamageSkinData objectDamageSkins { bmpName[0] = "dobj1_object"; bmpName[1] = "dobj2_object"; bmpName[2] = "dobj3_object"; bmpName[3] = "dobj4_object"; bmpName[4] = "dobj5_object"; bmpName[5] = "dobj6_object"; bmpName[6] = "dobj7_object"; bmpName[7] = "dobj8_object"; bmpName[8] = "dobj9_object"; bmpName[9] = "dobj10_object"; };

$WeaponAmmo[Blaster] = "";
$WeaponAmmo[PlasmaGun] = PlasmaAmmo;
$WeaponAmmo[Chaingun] = BulletAmmo;
$WeaponAmmo[DiscLauncher] = DiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo;
$WeaponAmmo[Mortar] = MortarAmmo;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";

$PhalanxxSlot = 4;

$AutoUse[RocketLauncher] = True;
$AutoUse[EMPGrenadeLauncher] = True;
$AutoUse[MagGun] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[Inferno] = True;
$AutoUse[Shotgun] = True;
$AutoUse[Phalanxx] = True;

$SellAmmo[RocketAmmo] = 5;
$SellAmmo[EMPGrenadeAmmo] = 5;
$SellAmmo[RifleAmmo] = 5;
$SellAmmo[PyroCharge] = 10;
$SellAmmo[ShotgunShells] = 5;
$SellAmmo[PhalanxxAmmo] = 25;

$AmmoPackMax[RocketAmmo] = 15;
$AmmoPackMax[EMPGrenadeAmmo] = 10;
$AmmoPackMax[RifleAmmo] = 10;
$AmmoPackMax[PyroCharge] = 75;
$AmmoPackMax[ShotgunShells] = 10;
$AmmoPackMax[PhalanxxAmmo] = 100;

$AmmoPackItems[8] = RocketAmmo;
$AmmoPackItems[9] = EMPGrenadeAmmo;
$AmmoPackItems[10] = RifleAmmo;
$AmmoPackItems[11] = PyroCharge;
$AmmoPackItems[12] = ShotgunShells;
$AmmoPackItems[13] = PhalanxxAmmo;

$RocketBoosterMax[marmor, BoosterCharge] = 100;
$RocketBoosterMax[harmor, BoosterCharge] = 100;
$RocketBoosterMax[mfemale, BoosterCharge] = 100;

$VengeanceMax[harmor, VengeanceAmmo] = 30;
$ixVAmmo[Low] = 1;
$ixVAmmo[Medium] = 2;
$ixVAmmo[High] = 3;
$ixVAmmo[EMP] = 1;
$ixVAmmo[Pause] = 0;
$ixVAmmo[Doomsday] = 20;

$TeamItemMax[SentryPack] = 3;
$TeamItemMax[AvengerPack] = 3;
$TeamItemMax[SLAPCVehicle] = 1;
$TeamItemMax[BomberVehicle] = 1;
$TeamItemMax[ForceFieldPack] = 5;
$TeamItemMax[FlakPack] = 1;

$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[EMPGrenadeLauncher] = EMPGrenadeAmmo;
$WeaponAmmo[MagGun] = "";
$WeaponAmmo[SniperRifle] = RifleAmmo;
$WeaponAmmo[Inferno] = PyroCharge;
$WeaponAmmo[HvyThruster] = BoosterCharge;
$WeaponAmmo[MedThruster] = BoosterCharge; 
$WeaponAmmo[Shotgun] = ShotgunShells;
$WeaponAmmo[Phalanxx] = PhalanxxAmmo;

$RetributionShots[larmor] = 1;
$RetributionShots[marmor] = 2;
$RetributionShots[harmor] = 3;
$RetributionShots[lfemale] = 1;
$RetributionShots[mfemale] = 2;

$AutoUse[EnergyRepeater] = True;
$AutoUse[TazerBeamGun] = True;
$AutoUse[TazerBoltGun] = True;
$AutoUse[FlareGun] = True;
$AutoUse[NaniteInjector] = True;

$SellAmmo[FlareAmmo] = 5;
$SellAmmo[InjectorAmmo] = 5;

$AmmoPackMax[FlareAmmo] = 10;
$AmmoPackMax[InjectorAmmo] = 5;

$AmmoPackItems[14] = FlareAmmo;
$AmmoPackItems[15] = InjectorAmmo;
$AmmoPackTotal = 16;

function pxPhobiaxItem()
{
  if($Phobiax::ExpansionItems)
  {
    $AmmoPackTotal = 16;
    $TeamItemMax[SentryPack] = 3;

    $TeamItemMax[FighterVehicle] = 1;
    $TeamItemMax[SentinelPack] = 3;
    $TeamItemMax[DecimatorPack] = 1;
    $TeamItemMax[BoomBoxPack] = 1;
  }
  else
  {
    $AmmoPackTotal = 14;
    $TeamItemMax[SentryPack] = 5;

    $TeamItemMax[FighterVehicle] = 0;
    $TeamItemMax[SentinelPack] = 0;
    $TeamItemMax[DecimatorPack] = 0;
    $TeamItemMax[BoomBoxPack] = 0;
  }
}
pxPhobiaxItem();

$WeaponAmmo[EnergyRepeater] = "";
$WeaponAmmo[TazerBeamGun] = "";
$WeaponAmmo[TazerBoltGun] = "";
$WeaponAmmo[FlareGun] = FlareAmmo;
$WeaponAmmo[NaniteInjector] = InjectorAmmo;

function teamEnergyBuySell(%player,%cost) { %client = Player::getClient(%player); %team = Client::getTeam(%client); %station = %player.Station; %stationName = GameBase::getDataName(%station); if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) { %station.Energy += %cost; if(%station.Energy < 1) %station.Energy = 0; } else if($TeamEnergy[%team] != "Infinite") { $TeamEnergy[%team] += %cost; %client.teamEnergy += %cost; } }
function isPlayerBusy(%client) { %state = Player::getItemState(%client,$WeaponSlot); return %state == "Fire" || %state == "Reload"; }
function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19) { if (isPlayerBusy(%client)) return; %time = getIntegerTime(true) >> 4; if(%time <= %client.lastBuyFavTime) return; %client.lastBuyFavTime = %time; %station = (Client::getOwnedObject(%client)).Station; if(%station != "" ) { %stationName = GameBase::getDataName(%station); if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) %energy = %station.Energy; else %energy = $TeamEnergy[Client::getTeam(%client)]; if(%energy == "Infinite" || %energy > 0) { %error = 0; %bought = 0; %max = getNumItems(); for (%i = 0; %i < %max; %i = %i + 1) { %item = getItemData(%i); if ($ServerCheats || Client::isItemShoppingOn(%client,%item)|| $TestCheats) { %count = Player::getItemCount(%client,%item); if(%count) { if(%item.className != Armor) teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count)); Player::setItemCount(%client, %item, 0); } } } Player::setItemCount(%client, Phalanxx2, 0); for (%i = 0; %i < 20; %i++) { if(%favItem[%i] != "") { %item = getItemData(%favItem[%i]); if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client), %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) { if(!buyItem(%client,%item)) %error = 1; else %bought++; } } } if(%bought) { if(%error) Client::sendMessage(%client,0,"~wC_BuySell.wav"); else Client::SendMessage(%client,0,"~wbuysellsound.wav"); } updateBuyingList(%client); } } }
function replenishTeamEnergy(%team) { $TeamEnergy[%team] += $incTeamEnergy; schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy); }
function checkResources(%player,%item,%delta,%noMessage) { %client = Player::getClient(%player); %team = Client::getTeam(%client); %pack = Player::getMountedItem(%client,$BackpackSlot); %extraAmmo = 0; if (%pack == ammopack && $AmmoPackMax[%item] != "") { %extraAmmo = $AmmoPackMax[%item]; if(%delta == $ItemMax[Player::getArmor(%client), %item]) %delta = %delta + %extraAmmo; } if (%pack == RocketBooster && $RocketBoosterMax[Player::getArmor(%client), %item] != "") { %extraAmmo = $RocketBoosterMax[Player::getArmor(%client), %item]; %delta = %delta + %extraAmmo; } if (%pack == Vengeance && $VengeanceMax[Player::getArmor(%client), %item] != "") { %extraAmmo = $VengeanceMax[Player::getArmor(%client), %item]; %delta = %delta + %extraAmmo; } if (%pack == RetributionPack) checkRetribution(%player); if($TestCheats == 0 && %client.spawn == "") { %energy = $TeamEnergy[%team]; %station = %player.Station; %sName = GameBase::getDataName(%station); if(%sName == DeployableInvStation || %sName == DeployableAmmoStation) { %energy = %station.Energy; } if(%energy != "Infinite") { if (%item.price * %delta > %energy) %delta = %energy / %item.price; if(%delta < 1 ) { if(%noMessage == "") Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - " @ %energy @ " Energy points left"); return 0; } } } if(%item.className == Weapon) { %armor = Player::getArmor(%client); %wcount = Player::getItemClassCount(%client,"Weapon"); if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) { Client::sendMessage(%client,0,"To many weapons for " @ $ArmorName[%armor].description @ " to carry"); return 0; } } else if(%item == RepairPatch) { %pDamage = GameBase::getDamageLevel(%player); if(GameBase::getDamageLevel(%player) > 0) return 1; return 0; } else if($TeamItemMax[%item] != "" && !$TestCheats) { if($TeamItemMax[%item] <= $TeamItemCount[%team, %item]) { Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return 0; } } if(%item.className != Armor && %item.className != Vehicle) { %count = Player::getItemCount(%client,%item); %max = $ItemMax[(Player::getArmor(%client)), %item] + %extraAmmo; if(%delta + %count >= %max) %delta = %max - %count; } return %delta; }
function buyItem(%client,%item) { %player = Client::getOwnedObject(%client); %armor = Player::getArmor(%client); %pack = Player::getMountedItem(%client,$BackpackSlot); if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) { if (%item.className == Armor) { %buyarmor = $ArmorType[Client::getGender(%client), %item]; if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0) { teamEnergyBuySell(%player,$ArmorName[%armor].price); if(checkResources(%player,%item,1)) { teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1); Player::setArmor(%client,%buyarmor); checkMax(%client,%buyarmor); armorChange(%client); Player::setItemCount(%client, $ArmorName[%armor], 0); Player::setItemCount(%client, %item, 1); if (%pack == ammopack) fillAmmoPack(%client); if (%pack == RocketBooster) fillRocketBooster(%client); if (%pack == Vengeance) fillVengeance(%client); if (%pack == RetributionPack) checkRetribution(%player); return 1; } teamEnergyBuySell(%player,$ArmorName[%armor].price * -1); } } else if (%item.className == Backpack) { if($TeamItemMax[%item] != "") { if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) return 0; if($TeamItemCount[(Client::getTeam(%client)) @ %item] < 0) $TeamItemCount[(Client::getTeam(%client)) @ %item] = 0; } if (%pack != -1) { if(%pack == ammopack) checkMax(%client,%armor); else if(%pack == RocketBooster) checkMax(%client,%armor); else if(%pack == Vengeance) checkMax(%client,%armor); else if(%pack == EnergyPack) { if((Player::getItemCount(%client,"LaserRifle") > 0) && (Player::getItemCount(%client,"EnergyRepeater") > 0)) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle and Energy Repeater"); remoteSellItem(%client,26); remoteSellItem(%client,17); } else if(Player::getItemCount(%client,"LaserRifle") > 0) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle"); remoteSellItem(%client,26); } else if(Player::getItemCount(%client,"EnergyRepeater") > 0) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Energy Repeater"); remoteSellItem(%client,17); } } teamEnergyBuySell(%player,%pack.price); Player::decItemCount(%client,%pack); } if (checkResources(%player,%item,1) || $testCheats) { teamEnergyBuySell(%player,%item.price * -1); Player::incItemCount(%client,%item); Player::useItem(%client,%item); if(%item == ammopack) fillAmmoPack(%client); if(%item == RocketBooster) fillRocketBooster(%client); if(%item == Vengeance) fillVengeance(%client); if(%item == RetributionPack) checkRetribution(%player); return 1; } else if(%pack != -1) { teamEnergyBuySell(%player,%pack.price * -1); Player::incItemCount(%client,%pack); Player::useItem(%client,%pack); if(%pack == ammopack) fillAmmoPack(%client); if(%pack == RocketBooster) fillRocketBooster(%client); if(%pack == Vengeance) fillVengeance(%client); if (%pack == RetributionPack) checkRetribution(%player); } } else if(%item.className == Weapon) { if(checkResources(%player,%item,1)) { %max = $MaxWeapons[%armor]; if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) { buyItem(%client,"EnergyPack"); Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack"); } else if(%item == EnergyRepeater && Player::getItemCount(%client,"EnergyPack") == 0) { buyItem(%client,"EnergyPack"); Client::sendMessage(%client,0,"Bought Energy Repeater - Auto buying Energy Pack"); } if(%item == Phalanxx) if(Player::getItemClassCount(%player,"Weapon") <= (%max - 2)) { Player::setItemCount(%client,"Phalanxx2",1); } else { Client::sendMessage(%client,0,"The Phalanxx Cannon Requires 2 Weapon Slots.~wC_BuySell.wav"); return 0; } Player::incItemCount(%client,%item); teamEnergyBuySell(%player,(%item.price * -1)); %ammoItem = %item.imageType.ammoType; if(%ammoItem != "") { %delta = checkResources(%player,%ammoItem,$ItemMax[%armor, %ammoItem]); if(%delta || $testCheats) { teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta)); Player::incItemCount(%client,%ammoitem,%delta); } } return 1; } } else if(%item.className == Vehicle) { if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) { %shouldBuy = VehicleStation::checkBuying(%client,%item); if(%shouldBuy == 1) { teamEnergyBuySell(%player,(%item.price * -1)); return 1; } else if(%shouldBuy == 2) return 1; } } else { if($TeamItemMax[%item] != "") { if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) return 0; if($TeamItemCount[(Client::getTeam(%client)) @ %item] < 0) $TeamItemCount[(Client::getTeam(%client)) @ %item] = 0; } %delta = checkResources(%player,%item,$ItemMax[%armor, %item]); if(%delta || $testCheats) { teamEnergyBuySell(%player,(%item.price * -1 * %delta)); Player::incItemCount(%client,%item,%delta); return 1; } } } return 0; }
function armorChange(%client) { %player = Client::getOwnedObject(%client); if(%client.respawn == "" && %player.Station != "") { %sPos = GameBase::getPosition(%player.Station); %pPos = GameBase::getPosition(%client); %posX = getWord(%sPos,0); %posY = getWord(%sPos,1); %posZ = getWord(%pPos,2); %vec = Vector::getFromRot(GameBase::getRotation(%player.Station),-1); %newPosX = (getWord(%vec,0) * 1) + %posX; %newPosY = (getWord(%vec,1) * 1) + %posY; GameBase::setPosition(%client, %newPosX @ " " @ %newPosY @ " " @ %posZ); } }
function remoteBuyItem(%client,%type) { if (isPlayerBusy(%client)) return; %item = getItemData(%type); if(buyItem(%client,%item)) { Client::sendMessage(%client,0,"~wbuysellsound.wav"); updateBuyingList(%client); } else Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav"); }
function remoteSellItem(%client,%type) { if (isPlayerBusy(%client)) return; %item = getItemData(%type); %player = Client::getOwnedObject(%client); if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats) { if(Player::getItemCount(%client,%item) && %item.className != Armor) { %numsell = 1; if(%item.className == Ammo || %item.className == HandAmmo) { %count = Player::getItemCount(%client, %item); if(%count < $SellAmmo[%item]) %numsell = %count; else %numsell = $SellAmmo[%item]; } else if (%item == ammopack) checkMax(%client,Player::getArmor(%client)); else if (%item == RocketBooster) checkMax(%client,Player::getArmor(%client)); else if (%item == Vengeance) checkMax(%client,Player::getArmor(%client)); else if (%item == Phalanxx) Player::setItemCount(%player,"Phalanxx2",0); else if($TeamItemMax[%item] != "") { if($TeamItemCount[(Client::getTeam(%client)) @ %item] < 0) $TeamItemCount[(Client::getTeam(%client)) @ %item] = 0; if(%item.className == Vehicle) $TeamItemCount[(Client::getTeam(%client)) @ %item]--; } else if(%item == EnergyPack) { if((Player::getItemCount(%client,"LaserRifle") > 0) && (Player::getItemCount(%client,"EnergyRepeater") > 0)) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle and Energy Repeater"); remoteSellItem(%client,26); remoteSellItem(%client,17); } else if(Player::getItemCount(%client,"LaserRifle") > 0) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle"); remoteSellItem(%client,26); } else if(Player::getItemCount(%client,"EnergyRepeater") > 0) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Energy Repeater"); remoteSellItem(%client,17); } } teamEnergyBuySell(%player,%item.price * %numsell); Player::setItemCount(%player,%item,(%count-%numsell)); updateBuyingList(%client); Client::SendMessage(%client,0,"~wbuysellsound.wav"); return 1; } } Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav"); }
function remoteUseItem(%client,%type) { %client.throwStrength = 1; %item = getItemData(%type); if (%item == Backpack) { %item = Player::getMountedItem(%client,$BackpackSlot); if(%item == "-1") ixCheckPickup(%client); } else { if (%item == Weapon) %item = Player::getMountedItem(%client,$WeaponSlot); } Player::useItem(%client,%item); }
function ixCheckPickup(%player) { %client = Player::getClient(%player); if(!%player.isDeploying) { if(GameBase::getLOSinfo(%player,3)) { %this = $los::object; %name = GameBase::getDataName(%this); if((%name.className != Armor) && (%name.className != Vehicle) && (%name.className != Generator) && (%name.className != Station)) { %thisTeam = GameBase::getTeam(%this); %team = Client::getTeam(%client); if(%team == %thisTeam) GameBase::virtual(%this,"packUp",$los::position,%client,%player); } } } }
function ixGivePack(%player, %pack, %team) { %obj = newObject("","Item",%pack,1,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); GameBase::setPosition(%obj,%player.deployPosition); $TeamItemCount[%team @ %pack]--; playSound(SoundPickupItem,%player.deployPosition); %player.isDeploying = false; }
function ixGetOwnerName(%this) { if(Client::getName(%this.owner) == %this.ownerName) return %this.ownerName; else return ""; }
function ixGetOwnerClient(%this) { if(Client::getName(%this.owner) == %this.OwnerName) return %this.owner; else return 0; }
function ixToggleDeploy(%this) { if(%this.isDeploying) %this.isDeploying = false; else %this.isDeploying = true; }
function remoteThrowItem(%client,%type,%strength) { %player = Client::getOwnedObject(%client); if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) { if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") { %item = getItemData(%type); if (%item == Grenade || %item == MineAmmo) { if (%strength < 0) %strength = 0; else if (%strength > 100) %strength = 100; %client.throwStrength = 0.3 + 0.7 * (%strength / 100); Player::useItem(%client,%item); } } } }
function remoteDropItem(%client,%type) { if((Client::getOwnedObject(%client)).driver != 1) { %client.throwStrength = 1; %item = getItemData(%type); if (%item == Backpack) { %item = Player::getMountedItem(%client,$BackpackSlot); Player::dropItem(%client,%item); } else if (%item == Weapon) { %item = Player::getMountedItem(%client,$WeaponSlot); Player::dropItem(%client,%item); } else if (%item == Ammo) { %item = Player::getMountedItem(%client,$WeaponSlot); if(%item.className == Weapon) { %item = %item.imageType.ammoType; Player::dropItem(%client,%item); } } else Player::dropItem(%client,%item); } }
function remoteDeployItem(%client,%type) { %item = getItemData(%type); Player::deployItem(%client,%item); }

$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = EnergyRepeater;
$NextWeapon[EnergyRepeater] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = NaniteInjector;
$NextWeapon[NaniteInjector] = FlareGun;
$NextWeapon[FlareGun] = EMPGrenadeLauncher;
$NextWeapon[EMPGrenadeLauncher] = RocketLauncher;
$NextWeapon[RocketLauncher] = SniperRifle;
$NextWeapon[SniperRifle] = MagGun;
$NextWeapon[MagGun] = TazerBeamGun;
$NextWeapon[TazerBeamGun] = TazerBoltGun;
$NextWeapon[TazerBoltGun] = Inferno;
$NextWeapon[Inferno] = Shotgun;
$NextWeapon[Shotgun] = Phalanxx;
$NextWeapon[Phalanxx] = EnergyRifle;

$PrevWeapon[EnergyRifle] = Phalanxx;
$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[EnergyRepeater] = Chaingun;
$PrevWeapon[DiscLauncher] = EnergyRepeater;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[NaniteInjector] = LaserRifle;
$PrevWeapon[FlareGun] = NaniteInjector;
$PrevWeapon[EMPGrenadeLauncher] = FlareGun;
$PrevWeapon[RocketLauncher] = EMPGrenadeLauncher;
$PrevWeapon[SniperRifle] = RocketLauncher;
$PrevWeapon[MagGun] = SniperRifle;
$PrevWeapon[TazerBeamGun] = MagGun;
$PrevWeapon[TazerBoltGun] = TazerBeamGun;
$PrevWeapon[Inferno] = TazerBoltGun;
$PrevWeapon[Shotgun] = Inferno;
$PrevWeapon[Phalanxx] = Shotgun;

function remoteNextWeapon(%client) { %item = Player::getMountedItem(%client,$WeaponSlot); if(ixCheckVengeance(%client, %item)) { if (%item == -1 || $NextWeapon[%item] == "") selectValidWeapon(%client); else { for(%weapon = $NextWeapon[%item]; %weapon != %item;%weapon = $NextWeapon[%weapon]) { if (isSelectableWeapon(%client,%weapon)) { Player::useItem(%client,%weapon); if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break; } } } } }
function remotePrevWeapon(%client) { %item = Player::getMountedItem(%client,$WeaponSlot); if(ixCheckVengeance(%client, %item)) { if (%item == -1 || $PrevWeapon[%item] == "") selectValidWeapon(%client); else { for(%weapon = $PrevWeapon[%item]; %weapon != %item;%weapon = $PrevWeapon[%weapon]) { if (isSelectableWeapon(%client,%weapon)) { Player::useItem(%client,%weapon); if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon) break; } } } } }

function selectValidWeapon(%client) { %item = EnergyRifle; for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon]) { if (isSelectableWeapon(%client,%weapon)) { Player::useItem(%client,%weapon); break; } } }
function isSelectableWeapon(%client,%weapon) { if (Player::getItemCount(%client,%weapon)) { %ammo = $WeaponAmmo[%weapon]; if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0) return true; } return false; }
function Item::giveItem(%player,%item,%delta) { %armor = Player::getArmor(%player); %pack = Player::getMountedItem(%client,$BackpackSlot); if($ItemMax[%armor, %item]) { %client = Player::getClient(%player); if (%item.className == Backpack) { if (Player::getMountedItem(%player,$BackpackSlot) == -1) { if(%item == Vengeance && %client.DoomsdayMode == 1) %item = DoomsdayPack; Player::incItemCount(%player,%item); Player::useItem(%player,%item); Client::sendMessage(%client,0,"You received a " @ %item @ " backpack"); return 1; } } else { if (%item.className == Weapon) { %max = $MaxWeapons[%armor]; if(%item == Phalanxx) { %max = max - 1; if (Player::getItemClassCount(%player,"Weapon") >= %max) return 0; } else { if (Player::getItemClassCount(%player,"Weapon") >= %max) return 0; } } %extraAmmo = 0; if (%pack == ammopack && $AmmoPackMax[%item] != "") %extraAmmo = $AmmoPackMax[%item]; if (%pack == RocketBooster && $RocketBoosterMax[Player::getArmor(%client), %item] != "") %extraAmmo = $RocketBoosterMax[Player::getArmor(%client), %item]; if (%pack == Vengeance && $VengeanceMax[Player::getArmor(%client), %item] != "") %extraAmmo = $VengeanceMax[Player::getArmor(%client), %item]; if (%pack == RetributionPack) checkRetribution(%player); %count = Player::getItemCount(%player,%item); if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) %delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count; if (%delta > 0) { Player::incItemCount(%player,%item,%delta); if(%item == Phalanxx) Player::setItemCount(%player,Phalanxx2,1); if (%count == 0 && $AutoUse[%item]) Player::useItem(%player,%item); Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description); return %delta; } } } return 0; }

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this) { %item = Item::getItemData(%this); %sound = $PickupSound[%item.className]; if (%sound != "") playSound(%sound,GameBase::getPosition(%this)); else { playSound(SoundPickupItem,GameBase::getPosition(%this)); } }
function Item::respawn(%this) { if (Item::isRotating(%this)) { Item::hide(%this,True); schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this); } else { deleteObject(%this); } }
function Item::onAdd(%this) { }
function Item::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { %item = Item::getItemData(%this); %count = Player::getItemCount(%object,%item); if (Item::giveItem(%object,%item,Item::getCount(%this))) { Item::playPickupSound(%this); Item::respawn(%this); } } }
function Item::onMount(%player,%item) { }
function Item::onUnmount(%player,%item) { }
function Item::onUse(%player,%item) { Player::mountItem(%player,%item,$DefaultSlot); }
function Item::pop(%item) { GameBase::startFadeOut(%item); schedule("deleteObject(" @ %item @ ");",2.5, %item); }
function Item::onDrop(%player,%item) { if($matchStarted) { if(%item.className != Armor) { if(%item == RocketBooster) { ixThrowBooster(%player,%item); return 0; } else if(%item == RetributionPack) { pxActivateRetribution(%player,%item); return 0; } else { %obj = newObject("","Item",%item,1,false); if(%pack == BoomBoxDetPack) schedule("Item::Pop(" @ %obj @ ");", ($ItemPopTime * 3), %obj); else schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); if (Player::isDead(%player)) GameBase::throw(%obj,%player,10,true); else { GameBase::throw(%obj,%player,15,false); Item::playPickupSound(%obj); } Player::decItemCount(%player,%item,1); return %obj; } } } }
function Item::onDeploy(%player,%item,%pos) { }
function ixThrowBooster(%player,%item) { %vel = Item::getVelocity(%player); %trans = "0 0 " @ getRandom() @ " 0 0 " @ getRandom() @ " 0 0 " @ getRandom() @ " " @ getBoxCenter(%player); if (Player::isDead(%player)) Projectile::spawnProjectile("EjectedBooster",%trans,%player,%vel,%player); else { Projectile::spawnProjectile("EjectedBooster",%trans,%player,%vel,%player); playSound(SoundPickupItem,GameBase::getPosition(%player)); } Player::decItemCount(%player,%item,1); }
function pxActivateRetribution(%player,%item) { %playerClient = Player::getClient(%player); %targetClient = %playerClient.RetributionTarget; %target = Client::getControlObject(%targetClient); if((Player::isDead(%player)) && (!Player::isDead(%target))) { %damType = %playerClient.RetributionDamType; %playerTeam = Client::getTeam(%playerClient); %targetTeam = Client::getTeam(%targetClient); if((%damType != $RetributionDamageType && %damType != $MineDamageType && %damType != $ConcussionMineDamageType && %damType != $EMPMineDamageType && %damType != $CloakedMineDamageType && %damType != $BoomBoxFizzleDamageType && %damType != $BoomBoxNukeDamageType && %damType != $NaniteDamageType) && %playerTeam != %targetTeam) { %targetType = getObjectType(%target); if(%targetType == "Player" || %targetType == "Flier") { ixLockWarning(%playerClient, %target, %targetType, 0.5, RetributionPack); %armor = Player::getArmor(%player); %shots = $RetributionShots[%armor]; %vecOut = Vector::neg(%playerClient.RetributionVecIn); for(%i = 1; %i <= %shots; %i++) { schedule("pxFireRetribution(" @ %player @ "," @ %target @ ", \"" @ %vecOut @ "\", " @ %i @ ");", (%i / 2)); } } } else { %obj = newObject("","Item",%item,1,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,10,true); } } else { %obj = newObject("","Item",%item,1,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,15,false); Item::playPickupSound(%obj); } Player::setItemCount(%player,%item,0); }
function pxFireRetribution(%player, %target, %vecOut, %i) { %pos = getWord(getBoxCenter(%player), 0) @ " " @ getWord(getBoxCenter(%player), 1) @ " " @ (getWord(getBoxCenter(%player), 2) + 1); %trans = "0 0 1 0 0 0 0 0 1 " @ %pos; %vel = Item::getVelocity(%player); %proj = Projectile::spawnProjectile("RetributionMissile", %trans, %player, %vel, %target); Item::setVelocity(%proj, pxAdjustSpeed(%vecOut, 75)); GameBase::setRotation(%proj, %vecOut); playSound(SoundMissileTurretFire, %pos); }
function pxAdjustSpeed(%vec, %num) { %x = getWord(%vec, 0); %y = getWord(%vec, 1); %z = getWord(%vec, 2); if(%x < 0) %x2 = %x * -1; else %x2 = %x; if(%y < 0) %y2 = %y * -1; else %y2 = %y; if(%z < 0) %z2 = %z * -1; else %z2 = %z; if(%x2 > %y2) %high = %x2; else %high = %y2; if(%z2 > %high) %high = %z2; %scaler = %num / %high; %newVec = (%x * %scaler) @ " " @ (%y * %scaler) @ " " @ (%z * %scaler); return %newVec; }

function Flag::onUse(%player,%item) { Player::mountItem(%player,%item,$FlagSlot); }
ItemImageData FlagImage { shapeFile = "flag"; mountPoint = 2; mountOffset = { 0, 0, -0.35 }; mountRotation = { 0, 0, 0 }; lightType = 2; lightRadius = 4; lightTime = 1.5; lightColor = { 1, 1, 1}; };
ItemData Flag { description = "Flag"; shapeFile = "flag"; imageType = FlagImage; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 4; lightTime = 1.5; lightColor = { 1, 1, 1 }; };
ItemData RaceFlag { description = "Race Flag"; shapeFile = "flag"; imageType = FlagImage; showInventory = false; shadowDetailMask = 4; lightType = 2; lightRadius = 4; lightTime = 1.5; lightColor = { 1, 1, 1 }; };

ItemData LightArmor { heading = "aArmor"; description = "Light Armor"; className = "Armor"; price = 175; };
ItemData MediumArmor { heading = "aArmor"; description = "Medium Armor"; className = "Armor"; price = 250; };
ItemData HeavyArmor { heading = "aArmor"; description = "Heavy Armor"; className = "Armor"; price = 400; };

ItemData ScoutVehicle { description = "Scout"; className = "Vehicle"; heading = "aVehicle"; price = 600; };
ItemData LAPCVehicle { description = "LPC"; className = "Vehicle"; heading = "aVehicle"; price = 675; };
ItemData BomberVehicle { description = "Firestorm Bomber"; className = "Vehicle"; heading = "aVehicle"; price = 700; };
ItemData FighterVehicle { description = "Lightningstrike Fighter"; className = "Vehicle"; heading = "aVehicle"; price = 750; };
ItemData HAPCVehicle { description = "HPC"; className = "Vehicle"; heading = "aVehicle"; price = 875; };
ItemData SLAPCVehicle { description = "Stealth LPC"; className = "Vehicle"; heading = "aVehicle"; price = 875; };

ItemData Weapon { description = "Weapon"; showInventory = false; };
function Weapon::onDrop(%player,%item) { %state = Player::getItemState(%player,$WeaponSlot); if (%state != "Fire" && %state != "Reload") Item::onDrop(%player,%item); }
function Weapon::onUse(%player,%item) { if(%player.Station==""){ %ammo = %item.imageType.ammoType; if (%ammo == "") { Player::mountItem(%player,%item,$WeaponSlot); } else { if (Player::getItemCount(%player,%ammo) > 0) Player::mountItem(%player,%item,$WeaponSlot); else { Client::sendMessage(Player::getClient(%player),0, strcat(%item.description," has no ammo")); } } } }

ItemData Tool { description = "Tool"; showInventory = false; };
function Tool::onUse(%player,%item) { Player::mountItem(%player,%item,$ToolSlot); }

ItemData Ammo { description = "Ammo"; showInventory = false; };
function Ammo::onDrop(%player,%item) { if($matchStarted) { %count = Player::getItemCount(%player,%item); %delta = $SellAmmo[%item]; if(%count <= %delta) { if( %item == BulletAmmo || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item) %delta = %count; else %delta = %count - 1; } if(%delta > 0) { %obj = newObject("","Item",%item,%delta,false); schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,20,false); Item::playPickupSound(%obj); Player::decItemCount(%player,%item,%delta); } } }

ItemImageData BlasterImage { shapeFile = "energygun"; mountPoint = 0; weaponType = 0; reloadTime = 0; fireTime = 0.3; minEnergy = 5; maxEnergy = 6; projectileType = BlasterBolt; accuFire = true; sfxFire = SoundFireBlaster; sfxActivate = SoundPickUpWeapon; };
ItemData Blaster { heading = "bWeapons"; description = "Blaster"; className = "Weapon"; shapeFile = "energygun"; hudIcon = "blaster"; shadowDetailMask = 4; imageType = BlasterImage; price = 85; showWeaponBar = true; };

ItemData BulletAmmo { description = "Bullet"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; };
ItemImageData ChaingunImage { shapeFile = "chaingun"; mountPoint = 0; weaponType = 1; reloadTime = 0; spinUpTime = 0.5; spinDownTime = 3; fireTime = 0.2; ammoType = BulletAmmo; projectileType = ChaingunBullet; accuFire = false; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1 }; sfxFire = SoundFireChaingun; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; };
ItemData Chaingun { description = "Chaingun"; className = "Weapon"; shapeFile = "chaingun"; hudIcon = "chain"; heading = "bWeapons"; shadowDetailMask = 4; imageType = ChaingunImage; price = 125; showWeaponBar = true; };

ItemImageData EnergyRepeaterImage { shapeFile = "chaingun"; mountPoint = 0; weaponType = 1; reloadTime = 0; spinUpTime = 0.5; spinDownTime = 3.0; fireTime = 0.1; minEnergy = 3; maxEnergy = 4; projectileType = EnergyRepeaterBolt; accuFire = true; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0, 0, 1 }; sfxFire = SoundFireChaingun; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; };
ItemData EnergyRepeater { description = "Energy Repeater"; className = "Weapon"; shapeFile = "chaingun"; hudIcon = "weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = EnergyRepeaterImage; price = 200; showWeaponBar = true; };
function EnergyRepeater::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Energy Repeater."); }

ItemData PlasmaAmmo { description = "Plasma Bolt"; heading = "xAmmunition"; className = "Ammo"; shapeFile = "plasammo"; shadowDetailMask = 4; price = 2; };
ItemImageData PlasmaGunImage { shapeFile = "plasma"; mountPoint = 0; weaponType = 0; ammoType = PlasmaAmmo; projectileType = PlasmaBolt; accuFire = true; reloadTime = 0.1; fireTime = 0.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 1, 1, 0.2 }; sfxFire = SoundFirePlasma; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; };
ItemData PlasmaGun { description = "Plasma Gun"; className = "Weapon"; shapeFile = "plasma"; hudIcon = "plasma"; heading = "bWeapons"; shadowDetailMask = 4; imageType = PlasmaGunImage; price = 175; showWeaponBar = true; };

ItemData GrenadeAmmo { description = "Grenade Ammo"; className = "Ammo"; shapeFile = "grenammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; };
ItemImageData GrenadeLauncherImage { shapeFile = "grenadeL"; mountPoint = 0; weaponType = 0; ammoType = GrenadeAmmo; projectileType = GrenadeShell; accuFire = false; reloadTime = 0.5; fireTime = 0.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundFireGrenade; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; };
ItemData GrenadeLauncher { description = "Grenade Launcher"; className = "Weapon"; shapeFile = "grenadeL"; hudIcon = "grenade"; heading = "bWeapons"; shadowDetailMask = 4; imageType = GrenadeLauncherImage; price = 150; showWeaponBar = true; };

ItemData MortarAmmo { description = "Mortar Ammo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "mortarammo"; shadowDetailMask = 4; price = 5; };
ItemImageData MortarImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = MortarAmmo; projectileType = MortarShell; accuFire = false; reloadTime = 0.5; fireTime = 2.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundMortarIdle; };
ItemData Mortar { description = "Mortar"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "mortar"; heading = "bWeapons"; shadowDetailMask = 4; imageType = MortarImage; price = 375; showWeaponBar = true; };

ItemData DiscAmmo { description = "Disc"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; };
ItemImageData DiscLauncherImage { shapeFile = "disc"; mountPoint = 0; weaponType = 3; ammoType = DiscAmmo; projectileType = DiscShell; spinUpTime = 0.25; sfxFire = SoundFireDisc; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDiscReload; sfxReady = SoundDiscSpin; };
ItemData DiscLauncher { description = "Disc Launcher"; className = "Weapon"; shapeFile = "disc"; hudIcon = "disk"; heading = "bWeapons"; shadowDetailMask = 4; imageType = DiscLauncherImage; price = 150; showWeaponBar = true; };

ItemImageData LaserRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; projectileType = SniperLaser; accuFire = true; reloadTime = 0.1; fireTime = 0.5; minEnergy = 10; maxEnergy = 60; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 1, 0, 0 }; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; };
ItemData LaserRifle { description = "Laser Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "sniper"; heading = "bWeapons"; shadowDetailMask = 4; imageType = LaserRifleImage; price = 200; showWeaponBar = true; };
function LaserRifle::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Laser Rifle."); }

ItemImageData TargetingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = targetLaser; accuFire = true; minEnergy = 5; maxEnergy = 15; reloadTime = 1.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; };
ItemData TargetingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TargetingLaserImage; price = 50; showWeaponBar = false; };

ItemImageData EnergyRifleImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 2; projectileType = lightningCharge; minEnergy = 3; maxEnergy = 11; reloadTime = 0.2; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 0.25, 0.25, 0.85 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundELFIdle; };
ItemData EnergyRifle { description = "ELF Gun"; shapeFile = "shotgun"; hudIcon = "energyRifle"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = EnergyRifleImage; showWeaponBar = true; price = 125; };

ItemImageData RepairGunImage { shapeFile = "repairgun"; mountPoint = 0; weaponType = 2; projectileType = RepairBolt; minEnergy = 3; maxEnergy = 10; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundRepairItem; };
ItemData RepairGun { description = "Repair Gun"; shapeFile = "repairgun"; className = "Weapon"; shadowDetailMask = 4; imageType = RepairGunImage; showInventory = false; price = 125; };
function RepairGun::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); }
function RepairGun::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); }

ItemData RocketAmmo { description = "Rocket Ammo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "mortarammo"; shadowDetailMask = 4; price = 5; };
ItemImageData RocketImage { shapeFile = "grenadeL"; mountPoint = 0; weaponType = 0; ammoType = RocketAmmo; accuFire = false; reloadTime = 0.2; fireTime = 1.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; };
function RocketImage::onFire(%player, %slot) { %client = GameBase::getOwnerClient(%player); Player::decItemCount(%player,$WeaponAmmo[RocketLauncher],1); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); if(GameBase::getLOSInfo(%player,350)) { %object = getObjectType($los::object); if(%object == "Player" || %object == "Flier") { if((%object == "Player" && Player::getMountedItem($los::object,$BackpackSlot) == MagneticShieldPack) || (%object == "Flier" && GameBase::getDataName($los::object) == SLAPC)) { Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,%player); } else { ixLockWarning(%client,$los::object,%object,0,Avenger); Projectile::spawnProjectile("AvengerMissile",%trans,%player,%vel,$los::object); } } else Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,%player); } else Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,%player); ixApplyKickback(%player, 100, 20); }
ItemData RocketLauncher { description = "Rocket Launcher"; className = "Weapon"; shapeFile = "grenadeL"; hudIcon = "blaster"; heading = "bWeapons"; shadowDetailMask = 4; imageType = RocketImage; price = 250; showWeaponBar = true; };

ItemData EMPGrenadeAmmo { description = "EMPGrenadeAmmo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "mortarammo"; shadowDetailMask = 4; price = 50; };
ItemImageData EMPGrenadeLauncherImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = EMPGrenadeAmmo; projectileType = EMPGrenadeShell; accuFire = false; reloadTime = 0.5; fireTime = 2.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.25, 0.25, 1.0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundLaserIdle; };
ItemData EMPGrenadeLauncher { description = "EMP Grenade Launcher"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "sensorjamerpack"; heading = "bWeapons"; shadowDetailMask = 4; imageType = EMPGrenadeLauncherImage; price = 475; showWeaponBar = true; };

ItemImageData MagGunImage { shapeFile = "repairgun"; mountPoint = 0; mountOffset = { -0.1, 0, 0 }; mountRotation = { 0, -1.575, 0}; weaponType = 2; minEnergy = 3; maxEnergy = 7; reloadTime = 0.2; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 0.85, 0.25, 0.25 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundELFIdle; };
function MagGunImage::onActivate(%player,%imageSlot) { Player::trigger(%player,$PhalanxxSlot,true); }
function MagGunImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$PhalanxxSlot,false); }
ItemData MagGun { description = "MAG Gun"; shapeFile = "repairgun"; hudIcon = "energyRifle"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = MagGunImage; showWeaponBar = true; price = 500; };
function MagGun::onMount(%player,%imageSlot) { Player::mountItem(%player,MagGun2,$PhalanxxSlot); }
function MagGun::onUnmount(%player,%imageSlot) { Player::unmountItem(%player,$PhalanxxSlot); }
ItemImageData MagGunImage2 { shapeFile = "repairgun"; mountPoint = 0; mountOffset = { 0.1, 0, 0 }; mountRotation = { 0, 1.575, 0}; weaponType = 2; projectileType = MagnetCharge; minEnergy = 3; maxEnergy = 7; reloadTime = 0.2; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 0.85, 0.25, 0.25 }; };
ItemData MagGun2 { description = "MAG Gun"; shapeFile = "repairgun"; hudIcon = "energyRifle"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = MagGunImage2; showWeaponBar = true; price = 500; };

ItemImageData TazerBeamGunImage { shapeFile = "paintgun"; mountPoint = 0; mountOffset = { -0.03325, 0, 0 }; mountRotation = { 0, -1.575, 0}; weaponType = 2; minEnergy = 3; maxEnergy = 7; reloadTime = 0.2; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 0.0, 1.0, 0.0 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundIdleTazerBeam; };
function TazerBeamGunImage::onActivate(%player,%imageSlot) { Player::trigger(%player,$PhalanxxSlot,true); }
function TazerBeamGunImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$PhalanxxSlot,false); }
ItemData TazerBeamGun { description = "Tazer"; shapeFile = "paintgun"; hudIcon = "energyRifle"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TazerBeamGunImage; showWeaponBar = true; price = 600; };
function TazerBeamGun::onMount(%player,%imageSlot) { Player::mountItem(%player,TazerBeamGun2,$PhalanxxSlot); }
function TazerBeamGun::onUnmount(%player,%imageSlot) { Player::unmountItem(%player,$PhalanxxSlot); }
ItemImageData TazerBeamGunImage2 { shapeFile = "paintgun"; mountPoint = 0; mountOffset = { 0.03325, 0, 0 }; mountRotation = { 0, 1.575, 0}; weaponType = 2; projectileType = TazerBeam; minEnergy = 3; maxEnergy = 7; reloadTime = 0.2; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 0.0, 1.0, 0.0 }; };
ItemData TazerBeamGun2 { description = "Tazer"; shapeFile = "paintgun"; hudIcon = "energyRifle"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TazerBeamGunImage2; showWeaponBar = true; price = 600; };

ItemImageData TazerBoltGunImage { shapeFile = "paintgun"; mountPoint = 0; mountOffset = { -0.03325, 0, 0 }; mountRotation = { 0, -1.575, 0}; weaponType = 0; minEnergy = 15; maxEnergy = 15; reloadTime = 1.0; fireTime = 0.5; accuFire = true; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.0, 1.0, 0.0 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundFireTazerBolt; };
function TazerBoltGunImage::onFire(%player, %slot) { %client = GameBase::getOwnerClient(%player); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); Projectile::spawnProjectile("TazerBolt",%trans,%player,%vel,%player); if(!$pxFiringTazerBoltGun[%client]) pxCheckTazerBoltGun(%client, %player); }
ItemData TazerBoltGun { description = "Tazer"; shapeFile = "paintgun"; mountOffset = { -0.03325, 0, 0 }; mountRotation = { 0, -1.575, 0}; hudIcon = "targetlaser"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TazerBoltGunImage; showWeaponBar = true; price = 600; };
function TazerBoltGun::onDrop(%player,%item) { %state = Player::getItemState(%player,$WeaponSlot); if (%state != "Fire" && %state != "Reload") { Player::setItemCount(%player, TazerBoltGun2, 0); Item::onDrop(%player,%item); } }
function TazerBoltGun::onMount(%player,%imageSlot) { Player::mountItem(%player,TazerBoltGun2,$PhalanxxSlot); }
function TazerBoltGun::onUnmount(%player,%imageSlot) { Player::unmountItem(%player,$PhalanxxSlot); }
ItemImageData TazerBoltGunImage2 { shapeFile = "paintgun"; mountPoint = 0; mountOffset = { 0.03325, 0, 0 }; mountRotation = { 0, 1.575, 0}; weaponType = 0; fireTime = 0.5; projectileType = TazerBolt; accuFire = true; minEnergy = 15; maxEnergy = 15; reloadTime = 1.0; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.0, 1.0, 0.0 }; };
function TazerBoltGunImage2::onFire(%player, %slot) { %client = GameBase::getOwnerClient(%player); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); Projectile::spawnProjectile("TazerBolt",%trans,%player,%vel,%player); if(!$pxFiringTazerBoltGun2[%client]) pxCheckTazerBoltGun2(%client, %player); }
ItemData TazerBoltGun2 { description = "Tazer"; shapeFile = "paintgun"; mountOffset = { 0.03325, 0, 0 }; mountRotation = { 0, -1.575, 0}; hudIcon = "targetlaser"; className = "Weapon"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TazerBoltGunImage2; showWeaponBar = true; price = 0; showInventory = false; };
function pxCheckTazerBoltGun(%client, %player) { if(Player::isTriggered(%player,$WeaponSlot)) { Player::trigger(%player,$PhalanxxSlot,true); schedule("pxCheckTazerBoltGun(" @ %client @ "," @ %player @ ");",0.1); $pxFiringTazerBoltGun[%client] = true; } else { Player::trigger(%player,$PhalanxxSlot,false); $pxFiringTazerBoltGun[%client] = false; } }
function pxCheckTazerBoltGun2(%client, %player) { if(Player::isTriggered(%player,$WeaponSlot)) { Player::trigger(%player,$PhalanxxSlot,true); schedule("pxCheckTazerBoltGun2(" @ %client @ "," @ %player @ ");",0.1); $pxFiringTazerBoltGun2[%client] = true; } else { Player::trigger(%player,$PhalanxxSlot,false); $pxFiringTazerBoltGun2[%client] = false; } }

ItemData RifleAmmo { description = "Rifle Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 5; };
ItemImageData SniperRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = RifleAmmo; projectileType = RifleBullet; accuFire = true; reloadTime = 3.5; fireTime = 0.5; lightType = 3; lightRadius = 6; lightTime = 1; lightColor = { 1, 1, 1 }; sfxFire = SoundFireIX2000; sfxActivate = SoundPickUpWeapon; sfxReady = SoundDryFire; };
ItemData SniperRifle { description = "IX-2000 Sniper Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "sniper"; heading = "bWeapons"; shadowDetailMask = 4; imageType = SniperRifleImage; price = 300; showWeaponBar = true; };

ItemData BoosterCharge { description = "Booster Charge"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 5; };
ItemImageData HvyThrusterImage { shapeFile = "rsmoke"; mountPoint = 0; mountOffset = { -0.715, -0.5, 0.2 }; mountRotation = { -2.0944, 0, 0}; weaponType = 1; reloadTime = 0; spinUpTime = 0.0; spinDownTime = 0.0; fireTime = 0.1; ammoType = BoosterCharge; projectileType = Booster; accuFire = false; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 1, 1, 0 }; sfxFire = SoundFlyerActive; sfxActivate = SoundPickUpWeapon; };
ItemData HvyThruster { description = "Heavy Thruster"; className = "Weapon"; shapeFile = "mortar"; shadowDetailMask = 4; imageType = HvyThrusterImage; price = 50; showInventory = false; };
function HvyThruster::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); }
function HvyThruster::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); }
ItemImageData MedThrusterImage { shapeFile = "rsmoke"; mountPoint = 0; mountOffset = { -0.524, -0.5, 0.2 }; mountRotation = { -2.0944, 0, 0}; weaponType = 1; reloadTime = 0; spinUpTime = 0.0; spinDownTime = 0.0; fireTime = 0.1; ammoType = BoosterCharge; projectileType = Booster; accuFire = false; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 1, 1, 0 }; sfxFire = SoundFlyerActive; sfxActivate = SoundPickUpWeapon; };
ItemData MedThruster { description = "Medium Thruster"; className = "Weapon"; shapeFile = "mortar"; shadowDetailMask = 4; imageType = MedThrusterImage; price = 50; showInventory = false; };
function MedThruster::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); }
function MedThruster::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); }

ItemImageData PilotKeyImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; minEnergy = 0; maxEnergy = 0; lightType = 0; lightRadius = 0; lightTime = 0; lightColor = { 0, 0, 0 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundPilotKeyInUse; };
function PilotKeyImage::onActivate(%player,%imageSlot) { playSound(SoundPilotKeyOn,GameBase::getPosition(%player)); bottomprint(Player::getClient(%player),"<jc><f1>Pilot Key Activated: Vehicle Interface Enabled.",5); }
function PilotKeyImage::onDeactivate(%player,%imageSlot) { playSound(SoundPilotKeyOff,GameBase::getPosition(%player)); if($pxPilotKeyOn[Player::getClient(%player)] != true) bottomprint(Player::getClient(%player),"<jc><f1>Pilot Key Deactivated: Vehicle Interface Disabled.",5); }
ItemData PilotKey { description = "Vehicle Interface Key"; shapeFile = "paintgun"; className = "Weapon"; shadowDetailMask = 4; imageType = PilotKeyImage; showInventory = false; price = 450; };
function PilotKey::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); }
function PilotKey::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); }

ItemData PyroCharge { description = "Pyro Charge"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 5; };
ItemImageData InfernoImage { shapeFile = "mortar"; mountPoint = 0; weaponType = 1; reloadTime = 0; spinUpTime = 0.5; spinDownTime = 0.0; fireTime = 0.1; ammoType = PyroCharge; projectileType = FlameBurst; accuFire = false; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 1, 1, 0 }; sfxFire = SoundFlyerActive; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundDryFire; sfxSpinDown = SoundDryFire; };
ItemData Inferno { description = "Pyro-Torch"; className = "Weapon"; shapeFile = "mortar"; hudIcon = "energypack"; heading = "bWeapons"; shadowDetailMask = 4; imageType = InfernoImage; price = 250; showWeaponBar = true; };

ItemData ShotgunShells { description = "Shotgun Shells"; className = "Ammo"; shapeFile = "ammo2"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; };
ItemImageData ShotgunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; ammoType = ShotgunShells; reloadTime = 1.0; accuFire = false; fireTime = 0.5; sfxFire = SoundFireShotgun; sfxActivate = SoundPickUpWeapon; };
ItemData Shotgun { heading = "bWeapons"; description = "Shotgun"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "ammopack"; shadowDetailMask = 4; imageType = ShotgunImage; price = 85; showWeaponBar = true; };
function ShotgunImage::onFire(%player, %slot) { Player::decItemCount(%player,$WeaponAmmo[Shotgun],1); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); }

ItemImageData MissileLauncherImage { shapeFile = "grenadeL"; mountPoint = 0; weaponType = 2; projectileType = LongLockLaser; minEnergy = 500; maxEnergy = 10; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.0, 0.0, 1.0 }; };
ItemData MissileLauncher { description = "Missile Launcher"; shapeFile = "grenadeL"; className = "Weapon"; shadowDetailMask = 4; imageType = MissileLauncherImage; showInventory = false; price = 125; };
function MissileLauncher::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; if($ixVScanner[%client] == "Doomsday") { Player::mountItem(%player,"DoomsdayLauncher",$WeaponSlot); } }
function MissileLauncher::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }

ItemImageData DoomsdayLauncherImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 2; projectileType = DoomsdayLockLaser; minEnergy = 500; maxEnergy = 10; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 1.0, 0.0, 0.0 }; };
ItemData DoomsdayLauncher { description = "Missile Launcher"; shapeFile = "mortargun"; className = "Weapon"; shadowDetailMask = 4; imageType = DoomsdayLauncherImage; showInventory = false; price = 125; };
function DoomsdayLauncher::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }
function DoomsdayLauncher::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }

ItemImageData LockingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = LongLockLaser; accuFire = true; minEnergy = 2; maxEnergy = 20; reloadTime = 0.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.0, 0.0, 1.0 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; };
ItemData LockingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = LockingLaserImage; price = 50; showWeaponBar = false; };
function LockingLaser::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; Player::mountItem(%player,$ixVScanner[%client] @ "LockingLaser",$WeaponSlot); }

ItemImageData LongLockingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = LongLockLaser; accuFire = true; minEnergy = 2; maxEnergy = 20; reloadTime = 0.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.0, 0.0, 1.0 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; };
ItemData LongLockingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = LongLockingLaserImage; price = 50; showWeaponBar = false; };
function LongLockingLaser::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }
function LongLockingLaser::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }

ItemImageData MediumLockingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = MediumLockLaser; accuFire = true; minEnergy = 2; maxEnergy = 20; reloadTime = 0.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.0, 0.0, 1.0 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; };
ItemData MediumLockingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = MediumLockingLaserImage; price = 50; showWeaponBar = false; };
function MediumLockingLaser::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }
function MediumLockingLaser::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }

ItemImageData ShortLockingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = ShortLockLaser; accuFire = true; minEnergy = 2; maxEnergy = 20; reloadTime = 0.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.0, 0.0, 1.0 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; };
ItemData ShortLockingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = ShortLockingLaserImage; price = 50; showWeaponBar = false; };
function ShortLockingLaser::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }
function ShortLockingLaser::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }

ItemImageData DoomsdayLockingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = DoomsdayLockLaser; accuFire = true; minEnergy = 2; maxEnergy = 20; reloadTime = 0.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 1.0, 0.0, 0.0 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; };
ItemData DoomsdayLockingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = DoomsdayLockingLaserImage; price = 50; showWeaponBar = false; };
function DoomsdayLockingLaser::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }
function DoomsdayLockingLaser::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); %client = Gamebase::GetControlClient(%player); $ixLockTime[%client] = 0; }

ItemData PhalanxxAmmo { description = "Phalanxx Ammo"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; };
ItemImageData PhalanxxImage { shapeFile = "chaingun"; mountPoint = 0; mountOffset = { -0.1, 0, 0 }; mountRotation = { 0, -1.575, 0}; weaponType = 1; reloadTime = 0; spinUpTime = 0.1; spinDownTime = 0.1; fireTime = 0.2; ammoType = PhalanxxAmmo; accuFire = true; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1 }; sfxFire = SoundFireChaingun; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; };
function PhalanxxImage::onFire(%player, %slot) { %client = GameBase::getOwnerClient(%player); Player::decItemCount(%player,$WeaponAmmo[Phalanxx],1); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); Projectile::spawnProjectile("PhalanxxBullet",%trans,%player,%vel,%player); if(!$ixFiringPhalanxx[%client]) ixCheckPhalanxx(%client, %player); }
ItemData Phalanxx { description = "Phalanxx Cannon"; className = "Weapon"; shapeFile = "chaingun"; mountOffset = { -0.1, 0, 0 }; mountRotation = { 0, -1.575, 0}; hudIcon = "chain"; heading = "bWeapons"; shadowDetailMask = 4; imageType = PhalanxxImage; price = 550; showWeaponBar = true; };
function Phalanxx::onDrop(%player, %item) { %state = Player::getItemState(%player,$WeaponSlot); if (%state != "Fire" && %state != "Reload") { Player::setItemCount(%player, Phalanxx2, 0); Item::onDrop(%player,%item); } }
function Phalanxx::onMount(%player, %imageSlot) { Player::mountItem(%player,Phalanxx2,$PhalanxxSlot); }
function Phalanxx::onUnmount(%player, %imageSlot) { Player::unmountItem(%player,$PhalanxxSlot); }
ItemImageData Phalanxx2Image { shapeFile = "chaingun"; mountPoint = 0; mountOffset = { 0.1, 0, 0 }; mountRotation = { 0, 1.575, 0 }; weaponType = 1; reloadTime = 0; spinUpTime = 0.1; spinDownTime = 0.1; fireTime = 0.2; ammoType = PhalanxxAmmo; projectileType = PhalanxxBullet; accuFire = true; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1 }; sfxFire = SoundFireChaingun; };
ItemData Phalanxx2 { description = "Phalanxx Cannon"; className = "Weapon"; shapeFile = "chaingun"; hudIcon = "chain"; heading = "bWeapons"; shadowDetailMask = 4; imageType = Phalanxx2Image; price = 0; showWeaponBar = true; showInventory = false; };
function ixCheckPhalanxx(%client, %player) { if(Player::isTriggered(%player,$WeaponSlot)) { Player::trigger(%player,$PhalanxxSlot,true); schedule("ixCheckPhalanxx(" @ %client @ "," @ %player @ ");",0.1); $ixFiringPhalanxx[%client] = true; } else { Player::trigger(%player,$PhalanxxSlot,false); $ixFiringPhalanxx[%client] = false; } }


ItemData FlareAmmo { description = "Flare"; className = "Ammo"; shapeFile = "grenammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 6; };
ItemImageData FlareGunImage { shapeFile = "energygun"; mountPoint = 0; mountRotation = { 0, -1.5, 0}; weaponType = 0; projectileType = HeatFlare; accuFire = true; reloadTime = 1.5; fireTime = 1.0; ammoType = FlareAmmo; lightType = 3; lightRadius = 2; lightTime = 1; lightColor = { 1, 1, 0 }; sfxFire = SoundFlareFire; sfxActivate = SoundPickUpWeapon; };
ItemData FlareGun { description = "Flare Gun"; className = "Weapon"; shapeFile = "energygun"; hudIcon = "energypack"; heading = "bWeapons"; shadowDetailMask = 4; imageType = FlareGunImage; price = 300; showWeaponBar = true; };

ItemData InjectorAmmo { description = "Nanites"; className = "Ammo"; shapeFile = "plasammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 5; };
ItemImageData NaniteInjectorImage { shapeFile = "sniper"; mountPoint = 0; mountRotation = { 0, -1.5, 0}; weaponType = 0; projectileType = NanoBolt; accuFire = true; reloadTime = 2.5; fireTime = 1.0; ammoType = InjectorAmmo; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 1, 0, 1 }; sfxFire = SoundFireInjector; sfxActivate = SoundPickUpWeapon; };
ItemData NaniteInjector { description = "Nanite Injector"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = NaniteInjectorImage; price = 325; showWeaponBar = true; };

ItemData Backpack { description = "Backpack"; showInventory = false; };
function Backpack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::trigger(%player,$BackpackSlot); } }

ItemImageData DeployableInvPackImage { shapeFile = "invent_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; };
ItemData DeployableInvPack { description = "Inventory Station"; shapeFile = "invent_remote"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4 ; imageType = DeployableInvPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteInvEnergy + 200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function DeployableInvPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function DeployableInvPack::onDeploy(%player,%item,%pos) { if (DeployableInvPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function DeployableInvPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %inv = newObject("ammounit_remote","StaticShape","DeployableInvStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,"RMT Inv: " @ Client::getName(%client) @ " ."); ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); Client::sendMessage(%client,0,"Inventory Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableInvPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed an Inventory Station"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData DeployableAmmoPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 1.0; firstPerson = false; };
ItemData DeployableAmmoPack { description = "Ammo Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dDeployables"; shadowDetailMask = 4; imageType = DeployableAmmoPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteAmmoEnergy; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };

function DeployableAmmoPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function DeployableAmmoPack::onDeploy(%player,%item,%pos) { if (DeployableAmmoPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function DeployableAmmoPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true); addToSet("MissionCleanup", %inv); %rot = GameBase::getRotation(%player); GameBase::setTeam(%inv,GameBase::getTeam(%player)); GameBase::setPosition(%inv,$los::position); GameBase::setRotation(%inv,%rot); Gamebase::setMapName(%inv,"RMT Ammo: " @ Client::getName(%client) @ " ."); ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); Client::sendMessage(%client,0,"Ammo Station deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableAmmoPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed an Ammo Station"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData EnergyPackImage { shapeFile = "jetPack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; minEnergy = -1; maxEnergy = -3; firstPerson = false; };
ItemData EnergyPack { description = "Energy Pack"; shapeFile = "jetPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = EnergyPackImage; price = 150; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; };
function EnergyPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } }
function EnergyPack::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); }
function EnergyPack::onUnmount(%player,%item) { if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) Player::unmountItem(%player,$WeaponSlot); if (Player::getMountedItem(%player,$WeaponSlot) == EnergyRepeater) Player::unmountItem(%player,$WeaponSlot); }

ItemImageData RepairPackImage { shapeFile = "armorPack"; mountPoint = 2; weaponType = 2; minEnergy = 0; maxEnergy = 0; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; };
ItemData RepairPack { description = "Repair Pack"; shapeFile = "armorPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = RepairPackImage; price = 125; hudIcon = "repairpack"; showWeaponBar = true; hiliteOnActive = true; };
function RepairPack::onUnmount(%player,%item) { if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) { Player::unmountItem(%player,$WeaponSlot); } }
function RepairPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::mountItem(%player,RepairGun,$WeaponSlot); } }
function RepairPack::onDrop(%player,%item) { if($matchStarted) { %mounted = Player::getMountedItem(%player,$WeaponSlot); if (%mounted == RepairGun) { Player::unmountItem(%player,$WeaponSlot); } else { Player::mountItem(%player,%mounted,$WeaponSlot); } Item::onDrop(%player,%item); } }

ItemImageData ShieldPackImage { shapeFile = "shieldpack"; mountPoint = 2; weaponType = 2; minEnergy = 4; maxEnergy = 9; sfxFire = SoundShieldOn; firstPerson = false; };
ItemData ShieldPack { description = "Shield Pack"; shapeFile = "shieldpack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = ShieldPackImage; price = 175; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; };
function ShieldPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Shield On"); %player.shieldStrength = 0.012; }
function ShieldPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Shield Off"); Player::trigger(%player,$BackpackSlot,false); %player.shieldStrength = 0; }

ItemImageData SensorJammerPackImage { shapeFile = "sensorjampack"; mountPoint = 2; weaponType = 2; maxEnergy = 10; sfxFire = SoundJammerOn; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; };
ItemData SensorJammerPack { description = "Sensor Jammer Pack"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = SensorJammerPackImage; price = 200; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; };
function SensorJammerPackImage::onActivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On"); %rate = Player::getSensorSupression(%player) + 20; Player::setSensorSupression(%player,%rate); }
function SensorJammerPackImage::onDeactivate(%player,%imageSlot) { Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off"); %rate = Player::getSensorSupression(%player) - 20; Player::setSensorSupression(%player,%rate); Player::trigger(%player,$BackpackSlot,false); }

ItemImageData MotionSensorPackImage { shapeFile = "sensor_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; };
ItemData MotionSensorPack { description = "Motion Sensor"; shapeFile = "sensor_small"; className = "Backpack"; heading = "dDeployables"; imageType = MotionSensorPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 125; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function MotionSensorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function MotionSensorPack::onDeploy(%player,%item,%pos) { if (MotionSensorPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "MotionSensorPack"]++; } }
function MotionSensorPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %mSensor = newObject("","Sensor",DeployableMotionSensor,true); addToSet("MissionCleanup", %mSensor); GameBase::setTeam(%mSensor,GameBase::getTeam(%player)); GameBase::setRotation(%mSensor,%rot); GameBase::setPosition(%mSensor,$los::position); %clName = Client::getName(%client); Gamebase::setMapName(%mSensor,"Motion Sensor: " @ %clname @ " ."); %mSensor.owner = %client; %mSensor.ownerName = %clName; Client::sendMessage(%client,0,"Motion Sensor deployed"); playSound(SoundPickupBackpack,$los::position); echo("MSG: ",%client,":",Client::getName(%client)," deployed a Motion Sensor"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData AmmoPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; firstPerson = false; };
ItemData AmmoPack { description = "Ammo Pack"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "cBackpacks"; imageType = AmmoPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 325; hudIcon = "ammopack"; showWeaponBar = true; hiliteOnActive = true; };
function AmmoPack::onDrop(%player, %item) { if($matchStarted) { %item = Item::onDrop(%player,%item); for(%i = 0; %i < $AmmoPackTotal ; %i = %i +1) { %numPack = 0; %ammoItem = $AmmoPackItems[%i]; %maxnum = $ItemMax[Player::getArmor(%player), %ammoItem]; %pCount = Player::getItemCount(%player, %ammoItem); if(%pCount > %maxnum) { %numPack = %pCount - %maxnum; Player::decItemCount(%player,%ammoItem,%numPack); } if(%i == 0) { %item.BulletAmmo = %numPack; } else if(%i == 1) { %item.PlasmaAmmo = %numPack; } else if(%i == 2) { %item.DiscAmmo = %numPack; } else if(%i == 3) { %item.GrenadeAmmo = %numPack; } else if(%i == 4) { %item.Grenade = %numPack; } else if(%i == 5) { %item.MineAmmo = %numPack; } else if(%i == 6) { %item.MortarAmmo = %numPack; } else if(%i == 7) { %item.Beacon = %numPack; } else if(%i == 8) { %item.RocketAmmo = %numPack; } else if(%i == 9) { %item.EMPGrenadeammo = %numPack; } else if(%i == 10) { %item.RifleAmmo = %numPack; } else if(%i == 11) { %item.PyroCharge = %numPack; } else if(%i == 12) { %item.ShotgunShells = %numPack; } else if(%i == 13) { %item.PhalanxxAmmo = %numPack; } else if(%i == 14) { %item.FlareAmmo = %numPack; } else if(%i == 15) { %item.InjectorAmmo = %numPack; } } } }
function AmmoPack::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { %item = Item::getItemData(%this); %count = Player::getItemCount(%object,%item); if (Item::giveItem(%object,%item,Item::getCount(%this))) { Item::playPickupSound(%this); checkPacksAmmo(%object, %this); Item::respawn(%this); } } }
function checkPacksAmmo(%player, %item) { for(%i = 0; %i < $AmmoPackTotal ; %i++) { %ammoItem = $AmmoPackItems[%i]; if(%i == 0) { %numAdd = %item.BulletAmmo; } else if(%i == 1) { %numAdd = %item.PlasmaAmmo; } else if(%i == 2) { %numAdd = %item.DiscAmmo; } else if(%i == 3) { %numAdd = %item.GrenadeAmmo; } else if(%i == 4) { %numAdd = %item.Grenade; } else if(%i == 5) { %numAdd = %item.MineAmmo; } else if(%i == 6) { %numAdd = %item.MortarAmmo; } else if(%i == 7) { %numAdd = %item.Beacon; } else if(%i == 8) { %numAdd = %item.RocketAmmo; } else if(%i == 9) { %numAdd = %item.EMPGrenadeammo; } else if(%i == 10) { %numAdd = %item.RifleAmmo; } else if(%i == 11) { %numAdd = %item.PyroCharge; } else if(%i == 12) { %numAdd = %item.ShotgunShells; } else if(%i == 13) { %numAdd = %item.PhalanxxAmmo; } else if(%i == 14) { %numAdd = %item.FlareAmmo; } else if(%i == 15) { %numAdd = %item.InjectorAmmo; } Player::incItemCount(%player,%ammoItem,%numAdd); } }
function fillAmmoPack(%client) { %player = Client::getOwnedObject(%client); for(%i = 0; %i < $AmmoPackTotal ; %i = %i +1) { %item = $AmmoPackItems[%i]; %maxnum = $AmmoPackMax[%item]; %maxnum = checkResources(%player,%item,%maxnum); if(%maxnum) { Player::incItemCount(%client,%item,%maxnum); teamEnergyBuySell(%player,%item.price * %maxnum * -1); } } }

ItemImageData PulseSensorPackImage { shapeFile = "radar_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; };
ItemData PulseSensorPack { description = "Pulse Sensor"; shapeFile = "radar_small"; className = "Backpack"; heading = "dDeployables"; imageType = PulseSensorPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 125; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function PulseSensorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function PulseSensorPack::onDeploy(%player,%item,%pos) { if (Item::deployShape(%player,"Pulse Sensor: " @ Client::getName(Player::getClient(%player)) @ " .",DeployablePulseSensor,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++; } }

ItemImageData DeployableSensorJamPackImage { shapeFile = "sensor_jammer"; mountPoint = 2; mountOffset = { 0, 0.03, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; };
ItemData DeployableSensorJammerPack { description = "Sensor Jammer"; shapeFile = "sensor_jammer"; className = "Backpack"; heading = "dDeployables"; imageType = DeployableSensorJamPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 225; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function DeployableSensorJammerPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function DeployableSensorJammerPack::onDeploy(%player,%item,%pos) { if (Item::deployShape(%player,"Sensor Jammer: " @ Client::getName(Player::getClient(%player)) @ " .",DeployableSensorJammer,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++; } }

ItemImageData CameraPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; };
ItemData CameraPack { description = "Camera"; shapeFile = "camera"; className = "Backpack"; heading = "dDeployables"; imageType = CameraPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 100; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function CameraPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function CameraPack::onDeploy(%player,%item,%pos) { if (CameraPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function CameraPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",CameraTurret,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); %clName = Client::getName(%client); Gamebase::setMapName(%camera,"Camera #"@ $totalNumCameras++ @ ": " @ %clName @ " ."); Client::sendMessage(%client,0,"Camera deployed"); %camera.owner = %client; %camera.ownerName = %clName; ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed a Camera"); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData TurretPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; };
ItemData TurretPack { description = "Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = TurretPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 350; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function TurretPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function TurretPack::onDeploy(%player,%item,%pos) { if (TurretPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function CountObjects(%set,%name,%num) { %count = 0; for(%i=0;%i<%num;%i++) { %obj=Group::getObject(%set,%i); if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++; } return %count; }
function TurretPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %player.deployTest = $los::position; if(!ixCheckFlagProx(getWord($los::position, 0), getWord($los::position, 1), getWord($los::position, 2), 4)) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableTurret",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableSentinel",%num) + CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableAvenger",%num) + CountObjects(%set,"DeployableForceField",%num) + CountObjects(%set,"DeployableTargetTurret",%num); deleteObject(%set); if((0 == %num) && (!ixCheckNothing($los::position,2))) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableTurret,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); %clName = Client::getName(%client); Gamebase::setMapName(%turret,"RMT Turret #" @ $totalNumTurrets++ @ ": " @ %clName @ " ."); addToSet(%client.deployables, %turret); %turret.owner = %client; %turret.ownerName = %clName; Client::sendMessage(%client,0,"Remote Turret deployed"); ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed a Remote Turret"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other deployables"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"You are too close to a Flag Stand."); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }
function checkDeployArea(%client,%pos) { %set=newObject("set",SimSet); %num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1); if(!%num) { deleteObject(%set); return 1; } else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player") { %obj = Group::getObject(%set,0); if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way"); else Client::sendMessage(%client,0,"Unable to deploy - Player in the way"); } else Client::sendMessage(%client,0,"Unable to deploy - Item in the way"); deleteObject(%set); return 0; }

ItemImageData SentryPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; };
ItemData SentryPack { description = "Sentry"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = SentryPackImage; shadowDetailMask = 4; mass = 2.5; elasticity = 0.2; price = 525; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function SentryPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function SentryPack::onDeploy(%player,%item,%pos) { if (SentryPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function SentryPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %player.deployTest = $los::position; if(!ixCheckFlagProx(getWord($los::position, 0), getWord($los::position, 1), getWord($los::position, 2), 4)) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableSentry",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableSentinel",%num) + CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableAvenger",%num) + CountObjects(%set,"DeployableForceField",%num) + CountObjects(%set,"DeployableTargetTurret",%num); deleteObject(%set); if((0 == %num) && (!ixCheckNothing($los::position,2))) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableSentry,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); %clName = Client::getName(%client); Gamebase::setMapName(%turret,"Sentry #" @ $totalNumTurrets++ @ ": " @ %clName @ " ."); addToSet(%client.deployables, %turret); %turret.owner = %client; %turret.ownerName = %clName; Client::sendMessage(%client,0,"Remote Sentry deployed"); ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "SentryPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed a Remote Sentry"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other deployables"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"You are too close to a Flag Stand."); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData SentinelPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 1.5; firstPerson = false; };
ItemData SentinelPack { description = "Sentinel"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = SentinelPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 675; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function SentinelPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function SentinelPack::onDeploy(%player,%item,%pos) { if (SentinelPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function SentinelPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } %player.deployTest = $los::position; if(!ixCheckFlagProx(getWord($los::position, 0), getWord($los::position, 1), getWord($los::position, 2), 4)) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableSentinel",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableSentinel",%num) + CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableAvenger",%num) + CountObjects(%set,"DeployableForceField",%num) + CountObjects(%set,"DeployableTargetTurret",%num); deleteObject(%set); if((0 == %num) && (!ixCheckNothing($los::position,2))) { if(checkDeployArea(%client,$los::position)) { %turret = newObject("remoteTurret","Turret",DeployableSentinel,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); %clName = Client::getName(%client); Gamebase::setMapName(%turret,"Sentinel #" @ $totalNumTurrets++ @ ": " @ %clName @ " ."); addToSet(%client.deployables, %turret); %turret.owner = %client; %turret.ownerName = %clName; Client::sendMessage(%client,0,"Sentinel deployed"); ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "SentinelPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed a Sentinel"); return true; } } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other deployables"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"You are too close to a Flag Stand."); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData AvengerPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 3.0; firstPerson = false; };
ItemData AvengerPack { description = "Avenger"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = AvengerPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 650; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function AvengerPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function AvengerPack::onDeploy(%player,%item,%pos) { if (AvengerPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function AvengerPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %player.deployTest = $los::position; if(!ixCheckFlagProx(getWord($los::position, 0), getWord($los::position, 1), getWord($los::position, 2), 4)) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0); %num = CountObjects(%set,"DeployableAvenger",%num); deleteObject(%set); if($MaxNumTurretsInBox > %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0); %num = CountObjects(%set,"DeployableSentinel",%num) + CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableAvenger",%num) + CountObjects(%set,"DeployableForceField",%num) + CountObjects(%set,"DeployableTargetTurret",%num); deleteObject(%set); if((0 == %num) && (!ixCheckNothing($los::position,2))) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableAvenger,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); %clName = Client::getName(%client); Gamebase::setMapName(%turret,"Avenger #" @ $totalNumTurrets++ @ ": " @ %clName @ " ."); addToSet(%client.deployables, %turret); %turret.owner = %client; %turret.ownerName = %clName; Client::sendMessage(%client,0,"Avenger deployed"); ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "AvengerPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed an Avenger"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other deployables"); } else Client::sendMessage(%client,0,"Interference from other remote turrets in the area"); } else Client::sendMessage(%client,0,"You are too close to a Flag Stand."); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

function ixCheckFlagProx(%px, %py, %pz, %prox) { %t = getNumTeams(); for(%i = 0; %i < %t; %i++) { %flag = $teamFlag[%i]; if(%flag != "") { %fx = getWord(%flag.originalPosition, 0); %fy = getWord(%flag.originalPosition, 1); %fz = getWord(%flag.originalPosition, 2); %fxl = %fx - %prox; %fxh = %fx + %prox; %fyl = %fy - %prox; %fyh = %fy + %prox; %fzl = %fz - %prox; %fzh = %fz + %prox; if((%fxh > %px) && (%fxl < %px)) if((%fyh > %py) && (%fyl < %py)) if((%fzh > %pz) && (%fzl < %pz)) return true; } } return false; }
function ixCheckNothing(%pos, %prox) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,%pos,%prox,%prox,%prox,0); %num = CountObjects(%set,"DeployableMotionSensor",%num) + CountObjects(%set,"DefaultBeacon",%num) + CountObjects(%set,"CameraTurret",%num) + CountObjects(%set,"DeployableSensorJammer",%num) + CountObjects(%set,"DeployablePulseSensor",%num); deleteObject(%set); return (%num > 0); }

ItemImageData FlakPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 3.0; firstPerson = false; };
ItemData FlakPack { description = "Flak Cannon"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = FlakPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 750; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function FlakPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function FlakPack::onDeploy(%player,%item,%pos) { if (FlakPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function FlakPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,4)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %player.deployTest = $los::position; if(!ixCheckFlagProx(getWord($los::position, 0), getWord($los::position, 1), getWord($los::position, 2), 4)) { if(!ixCheckNothing($los::position,2)) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableFlak,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); %clName = Client::getName(%client); Gamebase::setMapName(%turret,"Flak Cannon : " @ %clName @ " ."); addToSet(%client.deployables, %turret); %turret.owner = %client; %turret.ownerName = %clName; Client::sendMessage(%client,0,"Flak Cannon deployed"); ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); playSound(SoundPickupBackpack,$los::position); playSound(SoundChainTurretOn,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "FlakPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed a Flak Cannon"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other deployables"); } else Client::sendMessage(%client,0,"You are too close to a Flag Stand."); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData DecimatorPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 4.5; firstPerson = false; };
ItemData DecimatorPack { description = "Decimator"; shapeFile = "remoteturret"; className = "Backpack"; heading = "dDeployables"; imageType = DecimatorPackImage; shadowDetailMask = 4; mass = 4.5; elasticity = 0.2; price = 1750; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function DecimatorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function DecimatorPack::onDeploy(%player,%item,%pos) { if (DecimatorPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function DecimatorPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,4)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %player.deployTest = $los::position; if(!ixCheckFlagProx(getWord($los::position, 0), getWord($los::position, 1), getWord($los::position, 2), 4)) { if(!ixCheckNothing($los::position,2)) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %turret = newObject("remoteTurret","Turret",DeployableDecimator,true); addToSet("MissionCleanup", %turret); GameBase::setTeam(%turret,GameBase::getTeam(%player)); GameBase::setPosition(%turret,$los::position); GameBase::setRotation(%turret,%rot); %clName = Client::getName(%client); Gamebase::setMapName(%turret,"Decimator : " @ %clName @ " ."); addToSet(%client.deployables, %turret); %turret.owner = %client; %turret.ownerName = %clName; Client::sendMessage(%client,0,"Decimator deployed"); ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player); playSound(SoundPickupBackpack,$los::position); playSound(SoundChainTurretOn,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "DecimatorPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed a Decimator"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other deployables"); } else Client::sendMessage(%client,0,"You are too close to a Flag Stand."); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData ForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 1.0; firstPerson = false; };
ItemData ForceFieldPack { description = "Small Force Field"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dDeployables"; imageType = ForceFieldPackImage; shadowDetailMask = 4; mass = 1.0; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };
function ForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function ForceFieldPack::onDeploy(%player,%item,%pos) { if (ForceFieldPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function ForceFieldPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %player.deployTest = $los::position; if(!ixCheckFlagProx(getWord($los::position, 0), getWord($los::position, 1), getWord($los::position, 2), 4)) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0); %num = CountObjects(%set,"DeployableForceField",%num); deleteObject(%set); if(0 == %num) { %set = newObject("set",SimSet); %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,5,5,5,0); %num = CountObjects(%set,"DeployableSentinel",%num) + CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableAvenger",%num) + CountObjects(%set,"DeployableFlak",%num) + CountObjects(%set,"DeployableDecimator",%num) + CountObjects(%set,"DeployableTargetTurret",%num); deleteObject(%set); if((0 == %num) && (!ixCheckNothing($los::position,2))) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %rot = GameBase::getRotation(%player); %fField = newObject("","StaticShape",DeployableForceField,true); addToSet("MissionCleanup", %fField); GameBase::setTeam(%fField,GameBase::getTeam(%player)); GameBase::setPosition(%fField,$los::position); GameBase::setRotation(%fField,%rot); %clName = Client::getName(%client); Gamebase::setMapName(%fField,"Small Force Field: " @ %clName @ " ."); Client::sendMessage(%client,0,"Force Field Deployed"); ixToggleDeploy(%player); %fField.owner = %client; %fField.ownerName = %clName; schedule("ixToggleDeploy(" @ %player @ ");",2,%player); GameBase::startFadeIn(%fField); playSound(SoundPickupBackpack,$los::position); playSound(ForceFieldOpen,$los::position); $TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed a Small Force Field"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other deployables"); } else Client::sendMessage(%client,0,"Frequency Overload - Too close to other Force Fields"); } else Client::sendMessage(%client,0,"You are too close to a Flag Stand."); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %item.description @ "s"); return false; }

ItemImageData CloakingDeviceImage { shapeFile = "sensorjampack"; mountPoint = 2; weaponType = 2; maxEnergy = 11; minEnergy = 1; reloadTime = 3.0; fireTime = 3.0; sfxFire = SoundCloakOn; mountOffset = { 0, -0.05, 0.22 }; mountRotation = { 0, 3.14159, 0 }; firstPerson = false; };
ItemData CloakingDevice { description = "Cloaking Device"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = CloakingDeviceimage; price = 600; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; };
function CloakingDeviceImage::onActivate(%player,%imageSlot) { %item = Player::getMountedItem(%player,%imageSot); GameBase::playSequence(%item,2,"Something"); GameBase::startFadeout(%player); Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On"); %rate = Player::getSensorSupression(%player) + 1; Player::setSensorSupression(%player,%rate); }
function CloakingDeviceImage::onDeactivate(%player,%imageSlot) { %item = Player::getMountedItem(%player,%imageSot); GameBase::playSequence(%item,2,"Something"); GameBase::startFadein(%player); Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off"); %rate = Player::getSensorSupression(%player) - 1; Player::setSensorSupression(%player,%rate); Player::trigger(%player,$BackpackSlot,false); }

ItemImageData HeatSinkImage { shapeFile = "jetPack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, -0.1, 0.15 }; mountRotation = { 0, 3.14159, 0 }; minEnergy = 0; maxEnergy = 0; firstPerson = false; };
ItemData HeatSink { description = "Heat Sink"; shapeFile = "jetPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = HeatSinkImage; price = 250; hudIcon = "targetlaser"; showWeaponBar = true; hiliteOnActive = true; };
function HeatSink::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } }
function HeatSink::onMount(%player,%item) { GameBase::playSequence(%item,2,"Something"); Player::trigger(%player,$BackpackSlot,true); }

ItemImageData PilotPackImage { shapeFile = "AmmoPack"; mountPoint = 2; weaponType = 2; mountOffset = { 0, -0.03, 0.2 }; mountRotation = { 0, 3.14159, 0 }; minEnergy = 0; maxEnergy = 0; firstPerson = false; };
ItemData PilotPack { description = "Pilot Pack"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = PilotPackImage; price = 450; hudIcon = "compass"; showWeaponBar = true; hiliteOnActive = true; };
function PilotPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::mountItem(%player,PilotKey,$WeaponSlot); } }
function PilotPack::onDrop(%player,%item) { if($matchStarted) { %mounted = Player::getMountedItem(%player,$WeaponSlot); if (%mounted == PilotKey) { Player::unmountItem(%player,$WeaponSlot); } else { Player::mountItem(%player,%mounted,$WeaponSlot); } Item::onDrop(%player,%item); } }

ItemImageData MagneticShieldPackImage { shapeFile = "shieldpack"; weaponType = 0; mountPoint = 2; mountOffset = { 0, 0.0, 0.15 }; mountRotation = { 0, 3.14159, 0 }; minEnergy = 0; maxEnergy = 0; firstPerson = false; };
ItemData MagneticShieldPack { description = "Magnetic Shield Pack"; shapeFile = "shieldpack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = MagneticShieldPackImage; price = 250; hudIcon = "energyRifle"; showWeaponBar = true; hiliteOnActive = true; };
function MagneticShieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } }
function MagneticShieldPack::onMount(%player,%item) { GameBase::playSequence(%item,2,"Something"); Player::trigger(%player,$BackpackSlot,true); }

ItemImageData BoomBoxPackImage { shapeFile = "magcargo"; mountPoint = 2; mountOffset = { 0, -0.4, -0.6 }; mountRotation = { 0, 0, 0.05 }; mass = 3.0; firstPerson = false; };
ItemData BoomBoxPack { description = "Boom Box"; shapeFile = "magcargo"; className = "Backpack"; heading = "dDeployables"; imageType = BoomBoxPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.1; price = 600; hudIcon = "backpack"; showWeaponBar = true; hiliteOnActive = true; };
function BoomBoxPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } }
function BoomBoxPack::onDeploy(%player,%item,%pos) { if (BoomBoxPack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); Player::incItemCount(%player,BoomBoxDetPack); Player::useItem(%player,BoomBoxDetPack); } }
function BoomBoxPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3.5)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { %player.deployTest = $los::position; if(!ixCheckFlagProx(getWord($los::position, 0), getWord($los::position, 1), getWord($los::position, 2), 4)) { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { if(%client.BoomBox != "") { if(GameBase::getTeam(%player) == GameBase::getTeam(%client.BoomBox)) { Client::sendMessage(%client,0,"You already have a Boom Box in play"); return false; } else { %oldBox = %client.BoomBox; %oldData = GameBase::getDataName(%this); GameBase::setDamageLevel(%oldBox, %oldData.maxDamage); } } %rot = GameBase::getRotation(%player); %boomBox = newObject("","StaticShape",BoomBoxBomb,true); addToSet("MissionCleanup", %boomBox); GameBase::setPosition(%boomBox,$los::position); GameBase::setRotation(%boomBox,%rot); GameBase::setTeam(%boomBox, GameBase::getTeam(%player)); %client.BoomBox = %boomBox; %boomBox.Owner = %client; %boomBox.BoomBoxPos = getBoxCenter(%boomBox); %boomBox.BoxDetonated = 0; %client.BoomBoxDeployed = 1; %clock = $BoomBoxTimer[%client]; Gamebase::setMapName(%boomBox,"Boom Box: T-" @ %clock @ "s"); bottomprint(%client,"<jc><f2>Boom Box Deployed.\nAuto Detonation Timer Set: <f1>" @ %clock @ "<f0>\n\nTo detonate this Boom Box manually, you must use the Detonation Pack that has been automatically provided to you.",15); playSound(BoomBoxSound, getBoxCenter(%player)); schedule("pxBoomBoxCountdown(" @ %boomBox @ ");",1,%boomBox); $TeamItemCount[GameBase::getTeam(%player) @ "BoomBoxPack"]++; echo("MSG: ",%client,":",Client::getName(%client)," deployed a Boom Box"); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"You are too close to a Flag Stand."); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else { if($TeamItemMax[%item] > 1) %text = %item.description @ "s"; else %text = %item.description; Client::sendMessage(%client,0,"Only " @ $TeamItemMax[%item] @ " " @ %text @ " may be in play at a time."); } return false; }
function pxBoomBoxCountdown(%this) { %mapName = GameBase::getMapName(%this); %start = (String::findSubStr(%mapName,"-") + 1); %end = String::findSubStr(%mapName,"s"); %clock = String::getSubStr(%mapName, %start, %end - %start); %timer = pxAdjustTimer(%clock, -1, 0); if(%timer == "0:00") { %this.BoxDetonated = 1; %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } else { Gamebase::setMapName(%this,"Boom Box: T-" @ %timer @ "s"); schedule("pxBoomBoxCountdown(" @ %this @ ");",1,%this); } }
function pxAdjustTimer(%clock, %adjustment, %minimum) { %colon = String::findSubStr(%clock,":"); %mins = String::getSubStr(%clock, 0, %colon); %secs = String::getSubStr(%clock, (%colon + 1), 2); if(%secs >= 60) { %extras = floor(%secs / 60); %mins += %extras; %secs -= (%extras * 60); } if(%mins >= 10) { %mins = 10; %secs = 00; } %timer = ((%mins * 60) + %secs); %timer += %adjustment; if(%timer > 180) %timer = 180; if(%timer < %minimum) %timer = %minimum; %clock = getClockTimer(%timer); return %clock; }
function pxMushroomCloud(%player, %pos) { pxMushroomCloudSound(%pos); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"1\", 0, 0, 00.25);", 0.10); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"1\", 0, 0, 00.50);", 0.20); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"1\", 0, 0, 00.75);", 0.30); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"2\", 0, 0, 03.00);", 0.10); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"4\", 0, 0, 04.50);", 0.15); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"2\", 0, 0, 06.00);", 0.20); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"2\", 0, 0, 09.00);", 0.40); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"2\", 0, 0, 12.00);", 0.60); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"2\", 0, 0, 15.00);", 0.80); schedule("pxMushroomCloudSection(" @ %player @ ", \"" @ %pos @ "\", \"3\", 0, 0, 20.00);", 1.00); }
function pxMushroomCloudSection(%player, %pos, %part, %xInc, %yInc, %zInc) { %newPos = (getWord(%pos, 0) + %xInc) @ " " @ (getWord(%pos, 1) + %yInc) @ " " @ (getWord(%pos, 2) + %zInc); if(%part == "4") { Projectile::spawnProjectile("MushroomCloud" @ %part,"1 0 0.75 1 0 0.75 1 0 0.75 " @ %newPos,%player,"0 0 0",%player); Projectile::spawnProjectile("MushroomCloud" @ %part,"0 1 0.75 0 1 0.75 0 1 0.75 " @ %newPos,%player,"0 0 0",%player); Projectile::spawnProjectile("MushroomCloud" @ %part,"-1 0 0.75 -1 0 0.75 -1 0 0.75 " @ %newPos,%player,"0 0 0",%player); Projectile::spawnProjectile("MushroomCloud" @ %part,"0 -1 0.75 0 -1 0.75 0 -1 0.75 " @ %newPos,%player,"0 0 0",%player); Projectile::spawnProjectile("MushroomCloud" @ %part,"0.7 0.7 0.75 0.7 0.7 0.75 0.7 0.7 0.75 " @ %newPos,%player,"0 0 0",%player); Projectile::spawnProjectile("MushroomCloud" @ %part,"-0.7 -0.7 0.75 -0.7 -0.7 0.75 -0.7 -0.7 0.75 " @ %newPos,%player,"0 0 0",%player); Projectile::spawnProjectile("MushroomCloud" @ %part,"-0.7 0.7 0.75 -0.7 0.7 0.75 -0.7 0.7 0.75 " @ %newPos,%player,"0 0 0",%player); Projectile::spawnProjectile("MushroomCloud" @ %part,"0.7 -0.7 0.75 0.7 -0.7 0.75 0.7 -0.7 0.75 " @ %newPos,%player,"0 0 0",%player); } else if(%part == "1") { Projectile::spawnProjectile("MushroomCloud" @ %part,"0 0 -1 0 0 -1 0 0 -1 " @ %newPos,%player,"0 0 0",%player); } else Projectile::spawnProjectile("MushroomCloud" @ %part,"0 0 1 0 0 0 0 0 1 " @ %newPos,%player,"0 0 0",%player); }
function pxMushroomCloudSound(%pos) { schedule("playSound(SoundBoxBoom1, \"" @ %pos @ "\");", 0.0); schedule("playSound(SoundBoxBoom2, \"" @ %pos @ "\");", 0.65); schedule("playSound(SoundBoxBoom3, \"" @ %pos @ "\");", 1.25); }

ItemImageData BoomBoxDetPackImage { shapeFile = "grenammo"; weaponType = 2; mountPoint = 2; mountOffset = { 0, 0.15, 0.1 }; mountRotation = { 1.57, 3.14159, 0.05 }; minEnergy = 0; maxEnergy = 0; firstPerson = false; };
ItemData BoomBoxDetPack { description = "Detonation Pack"; shapeFile = "grenammo"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = BoomBoxDetPackImage; price = 300; hudIcon = "clock"; showWeaponBar = true; hiliteOnActive = true; };
function BoomBoxDetPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::mountItem(%player,BoomBoxSwitch,$WeaponSlot); } }
function BoomBoxDetPack::onMount(%player,%imageSlot) { %client = Player::getClient(%player); if(%client.BoomBoxDeployed != 1) { %client.BoomBoxDeployed = ""; %pack = Player::getMountedItem(%player,$BackpackSlot); %boomBox = %item.BoomBox; %client.BoomBox = %boomBox; %owner = item.BoomBoxOwner; %boomBox.Owner = %client; if(%owner.BoomBox == %boomBox) %owner.BoomBox = ""; Client::sendMessage(%client,0,"You have picked up the Detonation Pack for " @ Client::getName(%owner) @ "'s Boom Box"); %pack.BoomBox = ""; %pack.BoomBoxOwner = ""; } }
function BoomBoxDetPack::onUnmount(%player,%imageSlot) { %client = Player::getClient(%player); %pack = Player::getMountedItem(%player,$BackpackSlot); %boomBox = %client.BoomBox; %pack.BoomBox = %boomBox; %pack.BoomBoxOwner = %boomBox.Owner; }
function BoomBoxDetPack::onDrop(%player,%item) { if($matchStarted) { %mounted = Player::getMountedItem(%player,$WeaponSlot); if (%mounted == BoomBoxSwitch) { Player::unmountItem(%player,$WeaponSlot); } else { Player::mountItem(%player,%mounted,$WeaponSlot); } Item::onDrop(%player,%item); } }

ItemImageData BoomBoxSwitchImage { shapeFile = "force"; mountPoint = 0; weaponType = 0; mountOffset = { 0, -0.2, 0 }; mountRotation = { -1, 0, 0 }; reloadTime = 1.0; fireTime = 1.0; lightType = 0; lightRadius = 0; lightTime = 0; lightColor = { 0, 0, 0 }; sfxActivate = SoundPickUpWeapon; };
function BoomBoxSwitchImage::onFire(%player, %slot) { %client = Player::getClient(%player); %pack = Player::getMountedItem(%player,$BackpackSlot); if(%pack == BoomBoxDetPack) { playSound(BoomBoxSound, getBoxCenter(%player)); %this = %client.BoomBox; if(%this != "") { %this.BoxDetonated = 1; %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); centerprint(%client,""); Client::sendMessage(%client,1,"*** Boom Box Detonated!"); echo("MSG: ",%client,":",Client::getName(%client)," detonated a Boom Box"); } else Client::sendMessage(%client,0,"Unable to detonate Boom Box. It has been destroyed."); Player::setItemCount(%player,%pack,0); } Player::unMountItem(%player,$WeaponSlot); }
ItemData BoomBoxSwitch { description = "Boom Box Detonation Switch"; shapeFile = "force"; className = "Weapon"; shadowDetailMask = 4; imageType = BoomBoxSwitchImage; showInventory = false; price = 0; };
function BoomBoxSwitch::onMount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,true); }
function BoomBoxSwitch::onUnmount(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); }

ItemImageData RocketBoosterImage { shapeFile = "mortarpack"; mountPoint = 2; weaponType = 1; ammoType = BoosterCharge; firstPerson = false; mass = 2.0; };
ItemData RocketBooster { description = "Rocket Booster"; shapeFile = "mortarpack"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = RocketBoosterImage; price = 500; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; };
function RocketBooster::onUnmount(%player,%item) { %wpn = Player::getMountedItem(%player,$WeaponSlot); if ((%wpn == MedThruster) || (%wpn == HvyThruster)) { Player::unmountItem(%player,$WeaponSlot); } }
function RocketBooster::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) Player::mountItem(%player,%item,$BackpackSlot); else { %armor = Player::getArmor(%player); if(%armor == harmor) Player::mountItem(%player,HvyThruster,$WeaponSlot); else Player::mountItem(%player,MedThruster,$WeaponSlot); } }
function RocketBooster::onDrop(%player,%item) { if($matchStarted) { if(!Player::isDead(%player)) { %mounted = Player::getMountedItem(%player,$WeaponSlot); if ((%mounted == HvyThruster) || (%mounted == MedThruster)) Player::unmountItem(%player,$WeaponSlot); else Player::mountItem(%player,%mounted,$WeaponSlot); %item = Item::onDrop(%player,%item); %item.BoosterCharge = 0; } else { %item = Item::onDrop(%player,%item); %pCount = Player::getItemCount(%player, "BoosterCharge"); Player::decItemCount(%player,"BoosterCharge",%pCount); %item.BoosterCharge = %pCount; } } }
function fillRocketBooster(%client) { %player = Client::getOwnedObject(%client); %item = "BoosterCharge"; %maxnum = checkResources(%player,%item,$RocketBoosterMax[Player::getArmor(%client), %item]); if(%maxnum) { Player::incItemCount(%client,%item,%maxnum); teamEnergyBuySell(%player,%item.price * %maxnum * -1); } }
function RocketBooster::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { %item = Item::getItemData(%this); %count = Player::getItemCount(%object,%item); if (Item::giveItem(%object,%item,Item::getCount(%this))) { Item::playPickupSound(%this); Player::incItemCount(%object,"BoosterCharge",%this.BoosterCharge); Item::respawn(%this); } } }

ItemData RetributionAmmo { description = "Retribution Ammo"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 0; };
ItemImageData RetributionPackImage { shapeFile = "mortar"; weaponType = 1; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; mass = 0.75; ammoType = RetributionAmmo; };
ItemData RetributionPack { description = "Retribution Pack"; shapeFile = "mortar"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; mass = 0.75; imageType = RetributionPackImage; price = 700; hudIcon = "reticle"; showWeaponBar = true; hiliteOnActive = true; };
function RetributionPack::onMount(%player,%imageSlot) { checkRetribution(%player); }
function RetributionPack::onUnmount(%player,%imageSlot) { schedule("checkRetribution(" @ %player @ ");",1,%player); }
function RetributionPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } }
function checkRetribution(%player) { %client = Player::getClient(%player); if (Player::getMountedItem(%player,$BackpackSlot) == RetributionPack) Player::setItemCount(%client,RetributionAmmo,$RetributionShots[Player::getArmor(%client)]); else Player::setItemCount(%client,RetributionAmmo,0); }

ItemData VengeanceAmmo { description = "Vengeance Ammo"; className = "Ammo"; shapeFile = "ammo2"; heading = "xAmmunition"; shadowDetailMask = 4; price = 10; };
ItemImageData VengeanceImage { shapeFile = "remoteturret"; mountPoint = 2; weaponType = 2; minEnergy = 0; maxEnergy = 0; mountOffset = { 0, 0, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; ammoType = VengeanceAmmo; };
ItemData Vengeance { description = "Vengeance Missile Pack"; shapeFile = "remoteturret"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = VengeanceImage; price = 1500; hudIcon = "targetlaser"; showWeaponBar = true; hiliteOnActive = true; };
function Vengeance::onUnmount(%player,%item) { %weapon = Player::getMountedItem(%player,$WeaponSlot); if ((%weapon == MissileLauncher) || (%weapon == LongLockingLaser) || (%weapon == MediumLockingLaser) || (%weapon == ShortLockingLaser) || (%weapon == DoomsdayLockingLaser) || (%weapon == DoomsdayLauncher)) { Player::unmountItem(%player,$WeaponSlot); } }
function Vengeance::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { %this = Player::getMountedItem(%player,$WeaponSlot); if(ixCheckVengeance(GameBase::getOwnerClient(%player), %this)) { Player::mountItem(%player,LockingLaser,$WeaponSlot); } } }
function Vengeance::onDrop(%player,%item) { if($matchStarted) { %mounted = Player::getMountedItem(%player,$WeaponSlot); if ((%mounted == MissileLauncher) || (%mounted == LockingLaser)) Player::unmountItem(%player,$WeaponSlot); else Player::mountItem(%player,%mounted,$WeaponSlot); %item = Item::onDrop(%player,%item); %pCount = Player::getItemCount(%player, "VengeanceAmmo"); Player::decItemCount(%player,"VengeanceAmmo",%pCount); %item.VengeanceAmmo = %pCount; } }
function Vengeance::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { %item = Item::getItemData(%this); %count = Player::getItemCount(%object,%item); if (Item::giveItem(%object,%item,Item::getCount(%this))) { Item::playPickupSound(%this); Player::incItemCount(%object,"VengeanceAmmo",%this.VengeanceAmmo); Item::respawn(%this); } } }
function fillVengeance(%client) { %player = Client::getOwnedObject(%client); %item = "VengeanceAmmo"; %maxnum = checkResources(%player,%item,$VengeanceMax[Player::getArmor(%client), %item]); if(%maxnum) { Player::incItemCount(%client,%item,%maxnum); teamEnergyBuySell(%player,%item.price * %maxnum * -1); } }

ItemData DoomsdayPack { description = "Vengeance Missile Pack"; shapeFile = "remoteturret"; className = "Backpack"; heading = "cBackpacks"; shadowDetailMask = 4; imageType = VengeanceImage; price = 1875; hudIcon = "fear"; showWeaponBar = true; hiliteOnActive = true; };
function DoomsdayPack::onUnmount(%player,%item) { %weapon = Player::getMountedItem(%player,$WeaponSlot); if ((%weapon == MissileLauncher) || (%weapon == LongLockingLaser) || (%weapon == MediumLockingLaser) || (%weapon == ShortLockingLaser) || (%weapon == DoomsdayLockingLaser) || (%weapon == DoomsdayLauncher)) { Player::unmountItem(%player,$WeaponSlot); } }
function DoomsdayPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { %this = Player::getMountedItem(%player,$WeaponSlot); if(ixCheckVengeance(GameBase::getOwnerClient(%player), %this)) { Player::mountItem(%player,LockingLaser,$WeaponSlot); } } }
function DoomsdayPack::onDrop(%player,%item) { if($matchStarted) { %mounted = Player::getMountedItem(%player,$WeaponSlot); if ((%mounted == MissileLauncher) || (%mounted == LockingLaser)) Player::unmountItem(%player,$WeaponSlot); else Player::mountItem(%player,%mounted,$WeaponSlot); %item = Item::onDrop(%player,Vengeance); Player::setItemCount(%player,DoomsdayPack,0); %pCount = Player::getItemCount(%player, "VengeanceAmmo"); Player::decItemCount(%player,"VengeanceAmmo",%pCount); %item.VengeanceAmmo = %pCount; } }

function Item::deployShape(%player,%name,%shape,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { %sensor = newObject("","Sensor",%shape,true); addToSet("MissionCleanup", %sensor); GameBase::setTeam(%sensor,GameBase::getTeam(%player)); GameBase::setPosition(%sensor,$los::position); Gamebase::setMapName(%sensor,%name); Client::sendMessage(%client,0,%item.description @ " deployed"); playSound(SoundPickupBackpack,$los::position); echo("MSG: ",%client,":",Client::getName(%client)," deployed a ",%name); return true; } } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable Item limit (" @ $TeamItemMax[%item] @ ") reached for " @ %name @ "s"); return false; }

$AutoUse[RepairKit] = false;
ItemData RepairKit { description = "Repair Kit"; shapeFile = "armorKit"; heading = "eMiscellany"; shadowDetailMask = 4; price = 35; };
function RepairKit::onUse(%player,%item) { Player::decItemCount(%player,%item); GameBase::repairDamage(%player,0.2); cureNanites(%player); }

ItemData MineAmmo { description = "Mine"; shapeFile = "mineammo"; heading = "eMiscellany"; shadowDetailMask = 4; price = 10; className = "HandAmmo"; };
function MineAmmo::onUse(%player,%item) { if($matchStarted) { if(%player.throwTime < getSimTime()) { %client = Player::getClient(%player); %ammo = $pxMineLoadout[%client]; if(!$Phobiax::ExpansionItems) $pxMineLoadout[%client] = "Antipersonel"; if(%ammo != "Concussion" && %ammo != "EMP" && %ammo != "Cloaked" && %ammo != "Antipersonel") $pxMineLoadout[%client] = "Antipersonel"; Player::decItemCount(%player,%item); %obj = newObject("","Mine",$pxMineLoadout[%client] @ "Mine"); addToSet("MissionCleanup", %obj); %obj.pxOwner = %client; GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; } } }

ItemData Grenade { description = "Grenade"; shapeFile = "grenade"; heading = "eMiscellany"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; };
function Grenade::onUse(%player,%item) { if($matchStarted) { if(%player.throwTime < getSimTime() ) { Player::decItemCount(%player,%item); %obj = newObject("","Mine","Handgrenade"); addToSet("MissionCleanup", %obj); %client = Player::getClient(%player); GameBase::throw(%obj,%player,9 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; } } }

ItemData Beacon { description = "Beacon"; shapeFile = "sensor_small"; heading = "eMiscellany"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; };
function Beacon::onUse(%player,%item) { if (Beacon::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } }
function Beacon::deployShape(%player,%item) { %client = Player::getClient(%player); if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape") { if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 0"; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 0"; } else { %rot = Vector::getRotation($los::normal); } } %set=newObject("set",SimSet); %num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1); deleteObject(%set); if(!%num) { %team = GameBase::getTeam(%player); if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) { %beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true); addToSet("MissionCleanup", %beacon); GameBase::setTeam(%beacon,GameBase::getTeam(%player)); GameBase::setRotation(%beacon,%rot); GameBase::setPosition(%beacon,$los::position); Gamebase::setMapName(%beacon,"Target Beacon"); Beacon::onEnabled(%beacon); Client::sendMessage(%client,0,"Beacon deployed"); $TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++; return true; } else Client::sendMessage(%client,0,"Deployable Item limit reached"); } else Client::sendMessage(%client,0,"Unable to deploy - Item in the way"); } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } return false; }

ItemData RepairPatch { description = "Repair Patch"; className = "Repair"; shapeFile = "armorPatch"; heading = "eMiscellany"; shadowDetailMask = 4; price = 2; };
function RepairPatch::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { if(GameBase::getDamageLevel(%object)) { GameBase::repairDamage(%object,0.125); %item = Item::getItemData(%this); Item::playPickupSound(%this); Item::respawn(%this); } } }
function RepairPatch::onUse(%player,%item) { Player::decItemCount(%player,%item); GameBase::repairDamage(%player,0.1); cureNanites(%player); }

function remoteGiveAll(%clientId) { if ($TestCheats) { Player::setItemCount(%clientId,Blaster,1); Player::setItemCount(%clientId,Chaingun,1); Player::setItemCount(%clientId,PlasmaGun,1); Player::setItemCount(%clientId,GrenadeLauncher,1); Player::setItemCount(%clientId,DiscLauncher,1); Player::setItemCount(%clientId,LaserRifle,1); Player::setItemCount(%clientId,EnergyRifle,1); Player::setItemCount(%clientId,TargetingLaser,1); Player::setItemCount(%clientId,Mortar,1); Player::setItemCount(%clientId,BulletAmmo,200); Player::setItemCount(%clientId,PlasmaAmmo,200); Player::setItemCount(%clientId,GrenadeAmmo,200); Player::setItemCount(%clientId,DiscAmmo,200); Player::setItemCount(%clientId,MortarAmmo,200); Player::setItemCount(%clientId,Grenade, 200); Player::setItemCount(%clientId,MineAmmo, 200); Player::setItemCount(%clientId,Beacon, 200); Player::setItemCount(%clientId,RepairKit,200); } else if($ServerCheats) { %armor = Player::getArmor(%clientId); Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]); Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]); Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]); Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]); Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]); Player::setItemCount(%clientId,Grenade, $ItemMax[%armor, Grenade]); Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]); Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]); Player::setItemCount(%clientId,RepairKit,1); } }
function checkMax(%client,%armor) { %weaponflag = 0; %numweapon = Player::getItemClassCount(%client,"Weapon"); if (%numweapon > $MaxWeapons[%armor]) { %weaponflag = %numweapon - $MaxWeapons[%armor]; } %max = getNumItems(); for (%i = 0; %i < %max; %i = %i + 1) { %item = getItemData(%i); %maxnum = $ItemMax[%armor, %item]; if(%maxnum != "") { %numsell = 0; %count = Player::getItemCount(%client,%item); if(%count > %maxnum) { %numsell = %count - %maxnum; } if (%count > 0 && %weaponflag && %item.className == Weapon) { %numsell = 1; %weaponflag = %weaponflag - 1; } if(%numsell > 0) { Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item); teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell)); Player::setItemCount(%client, %item, %count - %numsell); updateBuyingList(%client); } } } }
function checkPlayerCash(%client) { %team = Client::getTeam(%client); if($TeamEnergy[%team] != "Infinite") { if(%client.teamEnergy > ($InitialPlayerEnergy * -1) ) { if(%client.teamEnergy >= 0) %diff = $InitialPlayerEnergy; else %diff = $InitialPlayerEnergy + %client.teamEnergy; $TeamEnergy[%team] -= %diff; } } }

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

$TeamItemCount[0 @ SentryPack] = 0;
$TeamItemCount[1 @ SentryPack] = 0;
$TeamItemCount[2 @ SentryPack] = 0;
$TeamItemCount[3 @ SentryPack] = 0;
$TeamItemCount[4 @ SentryPack] = 0;
$TeamItemCount[5 @ SentryPack] = 0;
$TeamItemCount[6 @ SentryPack] = 0;
$TeamItemCount[7 @ SentryPack] = 0;
$TeamItemCount[0 @ AvengerPack] = 0;
$TeamItemCount[1 @ AvengerPack] = 0;
$TeamItemCount[2 @ AvengerPack] = 0;
$TeamItemCount[3 @ AvengerPack] = 0;
$TeamItemCount[4 @ AvengerPack] = 0;
$TeamItemCount[5 @ AvengerPack] = 0;
$TeamItemCount[6 @ AvengerPack] = 0;
$TeamItemCount[7 @ AvengerPack] = 0;
$TeamItemCount[0 @ FlakPack] = 0;
$TeamItemCount[1 @ FlakPack] = 0;
$TeamItemCount[2 @ FlakPack] = 0;
$TeamItemCount[3 @ FlakPack] = 0;
$TeamItemCount[4 @ FlakPack] = 0;
$TeamItemCount[5 @ FlakPack] = 0;
$TeamItemCount[6 @ FlakPack] = 0;
$TeamItemCount[7 @ FlakPack] = 0;
$TeamItemCount[0 @ BomberVehicle] = 0;
$TeamItemCount[1 @ BomberVehicle] = 0;
$TeamItemCount[2 @ BomberVehicle] = 0;
$TeamItemCount[3 @ BomberVehicle] = 0;
$TeamItemCount[4 @ BomberVehicle] = 0;
$TeamItemCount[5 @ BomberVehicle] = 0;
$TeamItemCount[6 @ BomberVehicle] = 0;
$TeamItemCount[7 @ BomberVehicle] = 0;
$TeamItemCount[0 @ SLAPCVehicle] = 0;
$TeamItemCount[1 @ SLAPCVehicle] = 0;
$TeamItemCount[2 @ SLAPCVehicle] = 0;
$TeamItemCount[3 @ SLAPCVehicle] = 0;
$TeamItemCount[4 @ SLAPCVehicle] = 0;
$TeamItemCount[5 @ SLAPCVehicle] = 0;
$TeamItemCount[6 @ SLAPCVehicle] = 0;
$TeamItemCount[7 @ SLAPCVehicle] = 0;
$TeamItemCount[0 @ ForceFieldPack] = 0;
$TeamItemCount[1 @ ForceFieldPack] = 0;
$TeamItemCount[2 @ ForceFieldPack] = 0;
$TeamItemCount[3 @ ForceFieldPack] = 0;
$TeamItemCount[4 @ ForceFieldPack] = 0;
$TeamItemCount[5 @ ForceFieldPack] = 0;
$TeamItemCount[6 @ ForceFieldPack] = 0;
$TeamItemCount[7 @ ForceFieldPack] = 0;
$ixRepairTeam[0] = "-1";
$ixRepairTeam[1] = "-1";
$ixRepairTeam[2] = "-1";
$ixRepairTeam[3] = "-1";
$ixRepairTeam[4] = "-1";
$ixRepairTeam[5] = "-1";
$ixRepairTeam[6] = "-1";
$ixRepairTeam[7] = "-1";
$TeamItemCount[0 @ DecimatorPack] = 0;
$TeamItemCount[1 @ DecimatorPack] = 0;
$TeamItemCount[2 @ DecimatorPack] = 0;
$TeamItemCount[3 @ DecimatorPack] = 0;
$TeamItemCount[4 @ DecimatorPack] = 0;
$TeamItemCount[5 @ DecimatorPack] = 0;
$TeamItemCount[6 @ DecimatorPack] = 0;
$TeamItemCount[7 @ DecimatorPack] = 0;
$TeamItemCount[0 @ SentinelPack] = 0;
$TeamItemCount[1 @ SentinelPack] = 0;
$TeamItemCount[2 @ SentinelPack] = 0;
$TeamItemCount[3 @ SentinelPack] = 0;
$TeamItemCount[4 @ SentinelPack] = 0;
$TeamItemCount[5 @ SentinelPack] = 0;
$TeamItemCount[6 @ SentinelPack] = 0;
$TeamItemCount[7 @ SentinelPack] = 0;
$TeamItemCount[0 @ FighterVehicle] = 0;
$TeamItemCount[1 @ FighterVehicle] = 0;
$TeamItemCount[2 @ FighterVehicle] = 0;
$TeamItemCount[3 @ FighterVehicle] = 0;
$TeamItemCount[4 @ FighterVehicle] = 0;
$TeamItemCount[5 @ FighterVehicle] = 0;
$TeamItemCount[6 @ FighterVehicle] = 0;
$TeamItemCount[7 @ FighterVehicle] = 0;
$TeamItemCount[0 @ BoomBoxPack] = 0;
$TeamItemCount[1 @ BoomBoxPack] = 0;
$TeamItemCount[2 @ BoomBoxPack] = 0;
$TeamItemCount[3 @ BoomBoxPack] = 0;
$TeamItemCount[4 @ BoomBoxPack] = 0;
$TeamItemCount[5 @ BoomBoxPack] = 0;
$TeamItemCount[6 @ BoomBoxPack] = 0;
$TeamItemCount[7 @ BoomBoxPack] = 0;
$totalNumCameras = 0;
$totalNumTurrets = 0;
for(%i = -1; %i < 8 ; %i++) $TeamEnergy[%i] = $DefaultTeamEnergy;
}
