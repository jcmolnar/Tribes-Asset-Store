//===========================  Tribes 1.8 Item.cs File ===================================
//----------------------------------------------------------------------------

$ItemFavoritesKey = "NDGRenegadesv20";  // Change this if you add new items
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
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = True;
//========= Added for NDG Renegades
$AutoUse[EngRepGun] = True;
$AutoUse[CloakGun] = True;
$AutoUse[ThunderBolt] = True;
$AutoUse[IonGun] = True;
$AutoUse[Flamer] = True;
$AutoUse[RailGun] = True;
$AutoUse[WaveGun] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[ShockMortarGun] = True;
$AutoUse[ShotGun] = True;
$AutoUse[RocketLauncher] = True;
$AutoUse[WonderWand] = True;
$AutoUse[MedHealGun] = True;

$Use[Blaster] = True;

$ArmorType[Male, SniperArmor] = larmor;
$ArmorType[Male, GruntArmor] = marmor;
$ArmorType[Male, EngArmor] = harmor;
$ArmorType[Female, SniperArmor] = lfemale;
$ArmorType[Female, GruntArmor] = mfemale;
$ArmorType[Female, EngArmor] = harmor;
$ArmorType[Male, ScoutArmor] = sarmor;
$ArmorType[Female, ScoutArmor] = sfemale;
$ArmorType[Male, SpyArmor] = sparmor;
$ArmorType[Female, SpyArmor] = spfemale;
$ArmorType[Male, BursterArmor] = barmor;
$ArmorType[Female, BursterArmor] = bfemale;
$ArmorType[Male, FengArmor] = fearmor;
$ArmorType[Female, FengArmor] = fefemale;
$ArmorType[Male, PilotArmor] = pilarmor;
$ArmorType[Female, PilotArmor] = pilfemale;
$ArmorType[Male, MedicArmor] = medarmor;
$ArmorType[Female, MedicArmor] = medfemale;
$ArmorType[Male, CyclopsArmor] = darmor;
$ArmorType[Female, CyclopsArmor] = darmor;
$ArmorType[Male, SapperArmor] = saparmor;
$ArmorType[Female, SapperArmor] = sapfemale;

$ArmorName[larmor] = SniperArmor;
$ArmorName[marmor] = GruntArmor;
$ArmorName[harmor] = EngArmor;
$ArmorName[lfemale] = SniperArmor;
$ArmorName[mfemale] = GruntArmor;
$ArmorName[sarmor] = ScoutArmor;
$ArmorName[sfemale] = ScoutArmor;
$ArmorName[sparmor] = SpyArmor;
$ArmorName[spfemale] = SpyArmor;
$ArmorName[barmor] = BursterArmor;
$ArmorName[bfemale] = BursterArmor;
$ArmorName[fearmor] = FengArmor;
$ArmorName[fefemale] = FengArmor;
$ArmorName[pilarmor] = PilotArmor;
$ArmorName[pilfemale] = PilotArmor;
$ArmorName[medarmor] = MedicArmor;
$ArmorName[medfemale] = MedicArmor;
$ArmorName[darmor] = CyclopsArmor;
$ArmorName[saparmor] = SapperArmor;
$ArmorName[sapfemale] = SapperArmor;


// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
//============= Added for NDG Renegades
$SellAmmo[RailAmmo] = 5;
$SellAmmo[SniperAmmo] = 5;
$SellAmmo[ShockMortarAmmo] = 5;
$SellAmmo[ShotGunAmmo] = 5;
$SellAmmo[RocketAmmo] = 5;
$SellAmmo[WandAmmo] = 10;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 3;
$AmmoPackMax[Grenade] = 3;
$AmmoPackMax[Beacon] = 0;
//=============== Added for NDG Reneg
$AmmoPackMax[RailAmmo] = 10;
$AmmoPackMax[SniperAmmo] = 10;
$AmmoPackMax[ShockMortarAmmo] = 10;
$AmmoPackMax[ShotGunAmmo] = 5;
$AmmoPackMax[RocketAmmo] = 10;


// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
//=============== Added for NDG Reneg
$AmmoPackItems[8] = RailAmmo;
$AmmoPackItems[9] = SniperAmmo;
$AmmoPackItems[10] = ShockMortarAmmo;
$AmmoPackItems[11] = ShotGunAmmo;
$AmmoPackItems[12] = RocketAmmo;


// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 2;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;
//================================== Items added for NDG Renegades ================================
$TeamItemMax[DepPlasTurretPack] = 4;
$TeamItemMax[DepRailTurretPack] = 2;
$TeamItemMax[DepHoloPlasPack] = 4;
$TeamItemMax[DepRockTurretPack] = 4;
$TeamItemMax[DepHoloRockPack] = 2;
$TeamItemMax[PointDefTurretPack] = 2;
$TeamItemMax[ChainPack] = 3;
$TeamItemMax[MortTurretPack] = 2;
$TeamItemMax[LaserPack] = 4;
$TeamItemMax[CIWSTurretPack] = 2;
$TeamItemMax[DeployableFieldPack] = 4;
$TeamItemMax[ForceFieldPack] = 4;
$TeamItemMax[LargeForceFieldPack] = 2;
$TeamItemMax[BlastWallPack] = 2;
$TeamItemMax[SpringPack] = 3;
$TeamItemMax[PlatformPack] = 15;
$TeamItemMax[TeleportPack] = 3;
$TeamItemMax[TreePack] = 25;
$TeamItemMax[HoloPack] = 5;
$TeamItemMax[InterceptVehicle] = 2;
$TeamItemMax[SPCVehicle] = 2;
$TeamItemMax[WraithVehicle] = 2;
$TeamItemMax[EMPTurretPack] = 4;
$TeamItemMax[MiniPack]= 10;
$TeamItemMax[SatchelPack] = 3;

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
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
//======================= Added for NDG Reneg
$WeaponAmmo[EngRepGun] = "";
$WeaponAmmo[CloakGun] = "";
$WeaponAmmo[Thunderbolt] = "";
$WeaponAmmo[IonGun] = "";
$WeaponAmmo[Flamer] = "";
$WeaponAmmo[Railgun] = RailAmmo;
$WeaponAmmo[Wavegun] = "";
$WeaponAmmo[SniperRifle] = SniperAmmo;
$WeaponAmmo[ShockMortarGun] = ShockMortarAmmo;
$WeaponAmmo[ShotGun] = ShotGunAmmo;
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[WonderWand] = WandAmmo;
$WeaponAmmo[MedHealGun] = "";

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
                %station.Energy += %cost;                        //Remote StationEnergy
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

function buyItem(%client,%item)
{
        %player = Client::getOwnedObject(%client);
        %armor = Player::getArmor(%client);
        if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) &&
                        ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
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
                                else if(%pack == EnergyPack)
                                {
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
                %pPos        = GameBase::getPosition(%client);
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
                if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "")
                {
                //if(GameBase::getControlClient(%player) != -1)
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
$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = CloakGun;
$NextWeapon[CloakGun] = Thunderbolt;
$NextWeapon[Thunderbolt] = Flamer;
$NextWeapon[Flamer] = RailGun;
$NextWeapon[RailGun] = WaveGun;
$NextWeapon[WaveGun] = SniperRifle;
$NextWeapon[SniperRifle] = ShockMortarGun;
$NextWeapon[ShockMortarGun] = ShotGun;
$NextWeapon[ShotGun] = EngRepGun;
$NextWeapon[EngRepGun] = IonGun;
$NextWeapon[IonGun] = RocketLauncher;
$NextWeapon[RocketLauncher] = WonderWand;
$NextWeapon[WonderWand] = MedHealGun;
$NextWeapon[MedHealGun] = EnergyRifle;

$PrevWeapon[Blaster] = MedHealGun;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[EnergyRifle] = LaserRifle;
$PrevWeapon[CloakGun] = EnergyRifle;
$PrevWeapon[Thunderbolt] = CloakGun;
$PrevWeapon[Flamer] = Thunderbolt;
$PrevWeapon[RailGun] = Flamer;
$PrevWeapon[WaveGun] = RailGun;
$PrevWeapon[SniperRifle] = WaveGun;
$PrevWeapon[ShockMortarGun] = SniperRifle;
$PrevWeapon[ShotGun] = ShockMortarGun;
$PrevWeapon[EngRepGun] = ShotGun;
$PrevWeapon[IonGun] = EngRepGun;
$PrevWeapon[RocketLauncher] = IonGun;
$PrevWeapon[WonderWand] = RocketLauncher;
$PrevWeapon[MedHealGun] = WonderWand;

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

//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData SniperArmor
{
   heading = "aArmor";
        description = "Sniper-L";
        className = "Armor";
        price = 175;
};

ItemData ScoutArmor
{
        heading = "aArmor";
        description = "Scout-L";
        className = "Armor";
        price = 150;
};

ItemData SpyArmor
{
        heading = "aArmor";
        description = "Spy-L";
        className = "Armor";
        price = 175;
};

ItemData GruntArmor
{
   heading = "aArmor";
        description = "Grunt-M";
        className = "Armor";
        price = 250;
};

ItemData BursterArmor
{
        heading = "aArmor";
        description = "Burster-M";
        className = "Armor";
        price = 250;
};

ItemData FengArmor
{
        heading = "aArmor";
        description = "Field Engineer-M";
        className = "Armor";
        price = 275;
};

ItemData SapperArmor
{
        heading = "aArmor";
        description = "Sapper-M";
        className = "Armor";
        price = 250;
};

ItemData MedicArmor
{
        heading = "aArmor";
        description = "Medic-M";
        className = "Armor";
        price = 275;
};

ItemData PilotArmor
{
        heading = "aArmor";
        description = "Pilot-M";
        className = "Armor";
        price = 250;
};

ItemData EngArmor
{
           heading = "aArmor";
        description = "Engineer-H";
        className = "Armor";
        price = 400;
};

ItemData CyclopsArmor
{
        heading = "aArmor";
        description = "Cyclops-H";
        className = "Armor";
        price = 375;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
        description = "Scout";
        className = "Vehicle";
   heading = "aVehicle";
        price = 600;
};

ItemData InterceptVehicle
{
        description = "Interceptor";
        className = "Vehicle";
   heading = "aVehicle";
        price = 675;
};

ItemData WraithVehicle
{
        description = "Wraith";
        className = "Vehicle";
   heading = "aVehicle";
        price = 700;
};

ItemData SPCVehicle
{
        description = "Speedy PC";
        className = "Vehicle";
   heading = "aVehicle";
        price = 775;
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
        if(%player.Station==""){
                %ammo = %item.imageType.ammoType;
                if (%ammo == "") {
                        // Energy weapons dont have ammo types
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

function Blaster::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Blaster - Little bolts of energy");
}

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
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = ChaingunImage;
        price = 125;
        showWeaponBar = true;
};

function Chaingun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "ChainGun- Lots of bullets big spread pattern");
}


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
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = PlasmaGunImage;
        price = 175;
        showWeaponBar = true;
};

function PlasmaGun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "PlasmaGun- Large balls of super heated Plasma");
}

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
        projectileType = GrenadeShell;
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
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = GrenadeLauncherImage;
        price = 150;
        showWeaponBar = true;
};

function GrenadeLauncher::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Grenade Launcher- Kicks out Fragmentation Grenades");
}
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
        projectileType = MortarShell;
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
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = MortarImage;
        price = 375;
        showWeaponBar = true;
};

function Mortar::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Mortar- Fires Mortar Rounds to make bad guy go KABOOM!");
}
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
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = DiscLauncherImage;
        price = 150;
        showWeaponBar = true;
};

function DiscLauncher::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client,"Disc Launcher- Fires Michael Bolton CD's at your enemy");
}

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
        description = "Enhanced Laser Rifle";
        className = "Weapon";
        shapeFile = "sniper";
        hudIcon = "sniper";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = LaserRifleImage;
        price = 200;
        showWeaponBar = true;
};

function LaserRifle::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          BottomPrint(%Client, "Enhanced Laser Rifle- Slightly more powerful than it previous versions");
        if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
                Weapon::onUse(%player,%item);
        else
                Client::sendMessage(Player::getClient(%player),0,
                        "Must have an Energy Pack to use Laser Rifle.");
}

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
        shapeFile = "paintgun";
        mountPoint = 0;

        weaponType = 2; // Sustained
        projectileType = targetLaser;
        accuFire = true;
        minEnergy = 5;
        maxEnergy = 15;
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
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType     = TargetingLaserImage;
        price         = 50;
        showWeaponBar = false;
};

//------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
        shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
        projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
        reloadTime = 0.2;

   lightType = 3;  // Weapon Fire
   lightRadius = 2;
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
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
        showWeaponBar = true;
   price = 125;
};

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
          %client = Player::getClient(%player);
          Bottomprint(%client, "Repair Gun- The common mans repair unit");

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
   heading = "dDeployables";
        shadowDetailMask = 4        ;
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

//************************************** Field Station **************************************

ItemImageData DeployableFieldPackImage
{
        shapeFile = "invent_remote";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData DeployableFieldPack
{
        description = "Field Station";
        shapeFile = "invent_remote";
        className = "Backpack";
   heading = "dDeployables";
        shadowDetailMask = 4        ;
        imageType = DeployableFieldPackImage;
        mass = 2.0;
        elasticity = 0.2;
        price = $FieldInvEnergy + 200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function DeployableFieldPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DeployableFieldPack::onDeploy(%player,%item,%pos)
{
        if (DeployableFieldPack::deployShape(%player,%item)) {
                Player::decItemCount(%player,%item);
        }
}

function DeployableFieldPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                                if (Vector::dot($los::normal,"0 0 1") > 0.7) {
                                        if(checkDeployArea(%client,$los::position)) {
                                                %inv = newObject("ammounit_remote","StaticShape","DeployableFieldStation",true);
                                   addToSet("MissionCleanup", %inv);
                                                %rot = GameBase::getRotation(%player);
                                                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                                                GameBase::setPosition(%inv,$los::position);
                                                GameBase::setRotation(%inv,%rot);
                                                Gamebase::setMapName(%inv,%name);
                                                Client::sendMessage(%client,0,"Field Station deployed");
                                                playSound(SoundPickupBackpack,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%inv) @ "DeployableFieldPack"]++;
                                                echo("MSG: ",%client," deployed a Field Station");
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
   heading = "dDeployables";
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
   heading = "cBackpacks";
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
   heading = "cBackpacks";
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
   heading = "cBackpacks";
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
        maxEnergy = 10;  // Energy used/sec for sustained weapons
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
   heading = "cBackpacks";
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


//----------------------------------------------------------------------------

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
   heading = "dDeployables";
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

//        if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item))
function MotionSensorPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        // GetLOSInfo sets the following globals:
                        //         los::position
                        //         los::normal
                        //         los::object
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

//----------------------------------------------------------------------------

ItemImageData AmmoPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
   mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
        firstPerson = false;
};

ItemData AmmoPack
{
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

function AmmoPack::onDrop(%player, %item)
{
        if($matchStarted) {
                %item = Item::onDrop(%player,%item);
                for(%i = 0; %i < 12 ; %i = %i +1) {
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
                        else if(%i == 6) {
                        %item.RailAmmo = %numPack;
                        }
                        else if(%i == 7)  {
                        %item.SniperAmmo = %numPack;
                        }
                        else if(%i == 8)  {
                        %item.ShockMortarAmmo = %numPack;
                        }
                        else if(%i == 9)  {
                        %item.ShotGunAmmo = %numPack;
                        }
                        else if(%i == 10) {
                        %item.RocketAmmo = %numPack;
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
        for(%i = 0; %i < 12 ; %i = %i +1) {
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
                %numAdd = %item.RailAmmo;
                }
                else if(%i == 7) {
                %numAdd = %item.SniperAmmo;
                }
                else if(%i == 8) {
                %numAdd = %item.ShockMortarAmmo;
                }
                else if(%i == 9) {
                %numAdd = %item.ShotGunAmmo;
                }
                else if(%i == 10) {
                %numAdd = %item.RocketAmmo;
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
        for(%i = 0; %i < 12 ; %i = %i +1) {
                %item = $AmmoPackItems[%i];
                %maxnum = $AmmoPackMax[%item];
                %maxnum = checkResources(%player,%item,%maxnum);
                if(%maxnum) {
                        Player::incItemCount(%client,%item,%maxnum);
                        teamEnergyBuySell(%player,%item.price * %maxnum * -1);
                }
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
   heading = "dDeployables";
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
   heading = "dDeployables";
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
                        //         los::position
                        //         los::normal
                        //         los::object
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
                                        Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
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
        description = "Ion Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
   heading = "fTurrets";
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
                                                                Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Remote Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Remote Turret");
                                                                //        Remote turrets - kill points to player that deploy them
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
                        //         los::position
                        //         los::normal
                        //         los::object
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
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
        Player::decItemCount(%player,%item);
        GameBase::repairDamage(%player,0.2);
}


//-----------------All Removed to accomidate for NDG Renegades-----------------------------------

//ItemData MineAmmo
//{
//   description = "Mine";
//   shapeFile = "mineammo";
//   heading = "eMiscellany";
//   shadowDetailMask = 4;
//   price = 10;
//        className = "HandAmmo";
//};

//function MineAmmo::onUse(%player,%item)
//{
//        if($matchStarted) {
//                if(%player.throwTime < getSimTime() ) {
//                        Player::decItemCount(%player,%item);
//                        %obj = newObject("","Mine","antipersonelMine");
//                         addToSet("MissionCleanup", %obj);
//                        %client = Player::getClient(%player);
//                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
//                        %player.throwTime = getSimTime() + 0.5;
//                }
//        }
//}


//----------------------------------------------------------------------------

//ItemData Grenade
//{
//   description = "Grenade";
//   shapeFile = "grenade";
//   heading = "eMiscellany";
//   shadowDetailMask = 4;
//   price = 5;
//        className = "HandAmmo";
//};

//function Grenade::onUse(%player,%item)
//{
//        if($matchStarted) {
//                if(%player.throwTime < getSimTime() ) {
//                        Player::decItemCount(%player,%item);
//                        %obj = newObject("","Mine","Handgrenade");
//                           addToSet("MissionCleanup", %obj);
//                        %client = Player::getClient(%player);
//                        GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
//                        %player.throwTime = getSimTime() + 0.5;
//                }
//        }
//}


//----------------------------------------------------------------------------

//ItemData Beacon
//{
//   description = "Beacon";
//   shapeFile = "sensor_small";
//   heading = "eMiscellany";
//   shadowDetailMask = 4;
//   price = 5;
//        className = "HandAmmo";
//};

//function Beacon::onUse(%player,%item)
//{
//        if (Beacon::deployShape(%player,%item)) {
//                Player::decItemCount(%player,%item);
//        }
//}

//function Beacon::deployShape(%player,%item)
//{
//         %client = Player::getClient(%player);
//        if (GameBase::getLOSInfo(%player,3)) {
                // GetLOSInfo sets the following globals:
                //         los::position
                //         los::normal
                //         los::object
//                %obj = getObjectType($los::object);
//                if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                        // Try to stick it straight up or down, otherwise
                        // just use the surface normal
//                        if (Vector::dot($los::normal,"0 0 1") > 0.6) {
//                                %rot = "0 0 0";
//                        }
//                        else {
//                                if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
//                                        %rot = "3.14159 0 0";
//                                }
//                                else {
//                                        %rot = Vector::getRotation($los::normal);
//                                }
//                        }
//                          %set=newObject("set",SimSet);
//                        %num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,$los::position,0.3,0.3,0.3,1);
//                        deleteObject(%set);
//                        if(!%num) {
//                                %team = GameBase::getTeam(%player);
//                                if($TeamItemMax[%item] > $TeamItemCount[%team @ %item] || $TestCheats) {
//                                        %beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
//                                   addToSet("MissionCleanup", %beacon);
                                        //, CameraTurret, true);
//                                        GameBase::setTeam(%beacon,GameBase::getTeam(%player));
//                                        GameBase::setRotation(%beacon,%rot);
//                                        GameBase::setPosition(%beacon,$los::position);
//                                        Gamebase::setMapName(%beacon,"Target Beacon");
//                            Beacon::onEnabled(%beacon);
//                                        Client::sendMessage(%client,0,"Beacon deployed");
//                                        //playSound(SoundPickupBackpack,$los::position);
//                                        $TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
//                                        return true;
//                                }
//                                else
//                                        Client::sendMessage(%client,0,"Deployable Item limit reached");
//                        }
//                        else
//                                Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
//                }
//                else {
//                        Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
//                }
//        }
//        else {
//                Client::sendMessage(%client,0,"Deploy position out of range");
//        }
//        return false;
//}


//----------------------------------------------------------------------------

ItemData RepairPatch
{
        description = "Repair Patch";
        className = "Repair";
        shapeFile = "armorPatch";
   heading = "eMiscellany";
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

//===================== This is the section where NDG Renegades is adding some stuff. ====================

//===================== This is the section of Turrets added for the mod =================================

//------------------------------Deployable Plasma Turret----------------------------------------------

ItemImageData DepPlasTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData DepPlasTurretPack
{
        description = "Plasma Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
           heading = "fTurrets";
        imageType = DepPlasTurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DepPlasTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DepPlasTurretPack::onDeploy(%player,%item,%pos)
{
        if (DepPlasTurretPack::deployShape(%player,%item)) {
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

function DepPlasTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployablePlasma",%num);
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
                                                                %turret = newObject("hellfiregun","Turret",DeployablePlasma,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Plasma Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "DepPlasTurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Plasma Turret");
                                                                //        Remote turrets - kill points to player that deploy them
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

//----------------------------------Deployable Holo Plasma Turret----------------------------------

ItemImageData DepHoloPlasPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData DepHoloPlasPack
{
        description = "Holo Plasma Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
           heading = "hHolograms";
        imageType = DepHoloPlasPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DepHoloPlasPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DepHoloPlasPack::onDeploy(%player,%item,%pos)
{
        if (DepHoloPlasPack::deployShape(%player,%item)) {
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

function DepHoloPlasPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableHoloPlasma",%num);
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
                                                                %turret = newObject("hellfiregun","Turret",DeployableHoloPlasma,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Holo Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Holo Plasma Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "DepHoloPlasPack"]++;
                                                                echo("MSG: ",%client," deployed a Holo Plasma Turret");
                                                                //        Remote turrets - kill points to player that deploy them
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

//------------------------------------ Deployable Rail Turret ----------------------------
ItemImageData DepRailTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData DepRailTurretPack
{
        description = "Rail Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
           heading = "fTurrets";
        imageType = DepRailTurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DepRailTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DepRailTurretPack::onDeploy(%player,%item,%pos)
{
        if (DepRailTurretPack::deployShape(%player,%item)) {
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

function DepRailTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableRail",%num);
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
                                                                %turret = newObject("hellfiregun","Turret",DeployableRail,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Rail Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Rail Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "DepRailTurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Rail Turret");
                                                                //        Remote turrets - kill points to player that deploy them
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



//---------------------------Deployable Rocket turret ------------------------------------
ItemImageData DepRockTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData DepRockTurretPack
{
        description = "Rocket Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
           heading = "fTurrets";
        imageType = DepRockTurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DepRockTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DepRockTurretPack::onDeploy(%player,%item,%pos)
{
        if (DepRockTurretPack::deployShape(%player,%item)) {
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

function DepRockTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableRocket",%num);
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
                                                                %turret = newObject("missileturret","Turret",DeployableRocket,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Rocket Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Rocket Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "DepRockTurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Rocket Turret");
                                                                //        Remote turrets - kill points to player that deploy them
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

//---------------------------Deployable Holo Rocket turret ------------------------------------
ItemImageData DepHoloRockPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData DepHoloRockPack
{
        description = "Holo Rocket Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
           heading = "hHolograms";
        imageType = DepHoloRockPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function DepHoloRockPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function DepHoloRockPack::onDeploy(%player,%item,%pos)
{
        if (DepHoloRockPack::deployShape(%player,%item)) {
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

function DepHoloRockPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableHoloRocket",%num);
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
                                                                %turret = newObject("missileturret","Turret",DeployableHoloRocket,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Holo Rocket Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Holo Rocket Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "DepHoloRockPack"]++;
                                                                echo("MSG: ",%client," deployed a Holo Rocket Turret");
                                                                //        Remote turrets - kill points to player that deploy them
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

//--------------------------------Point Defense System Turret --------------------------------
ItemImageData PointDefTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData PointDefTurretPack
{
        description = "Point Defense System";
        shapeFile = "remoteturret";
        className = "Backpack";
           heading = "fTurrets";
        imageType = PointDefTurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function PointDefTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function PointDefTurretPack::onDeploy(%player,%item,%pos)
{
        if (PointDefTurretPack::deployShape(%player,%item)) {
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

function PointDefTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"PointRocket",%num);
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
                                                                %turret = newObject("mortar_turret","Turret",PointRocket,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Point D Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Point Defense Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "PointDefTurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Point Defense Rocket Turret");
                                                                //        Remote turrets - kill points to player that deploy them
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

//------------------------------ Deployable ChainGun Turret ----------------------
ItemImageData ChainPackImage {
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};
ItemData ChainPack {
        description = "ChainGun Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
        heading = "fTurrets";
        imageType = ChainPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 350;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function ChainPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function ChainPack::onDeploy(%player,%item,%pos) {
        if (ChainPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function CountObjects(%set,%name,%num) {
        %count = 0;
        for(%i=0;%i<%num;%i++)
        {
                %obj=Group::getObject(%set,%i);
                if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) %count++;
        }
        return %count;
}
function ChainPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
                        {
                                %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableChainTurret",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num)
                                {
                                        %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DeployableTurret",%num);
                                        deleteObject(%set);
                                        if(0 == %num)
                                        {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                                {
                                                        if(checkDeployArea(%client,$los::position))
                                                        {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("remoteTurret","Turret",DeployableChainTurret,true);
                                                                addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"RMT Chain Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Remote Chain Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "ChainPack"]++;
                                                                echo("MSG: ",%client," deployed a Remote Chain Turret");
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
        if(!%num)
        {
                deleteObject(%set);
                return 1;
        }
        else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player")
        {
                %obj = Group::getObject(%set,0);
                if(Player::getClient(%obj) == %client) Client::sendMessage(%client,0,"Unable to deploy - You're in the way");
                else Client::sendMessage(%client,0,"Unable to deploy - Player in the way");
        }
        else Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
        deleteObject(%set);
        return 0;
}

//--------------------------------Mortar Turret Pack ----------------------------

ItemImageData MortTurretPackImage {
        shapeFile = "ammounit_remote";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.06 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};
ItemData MortTurretPack {
        description = "Mortar Turret";
        shapeFile = "mortar_turret";
        className = "Backpack";
        heading = "fTurrets";
        imageType = MortTurretPackImage;
        shadowDetailMask = 4;
        mass = 3.0;
        elasticity = 0.2;
        price = 800;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function MortTurretPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function MortTurretPack::onMount(%player,%item) {
        %client = Player::getClient(%player);
        Bottomprint(%client, "   The Mortar Turret has no auto-sensor and must be controlled manually to fire.");
}
function MortTurretPack::onDeploy(%player,%item,%pos) {
        if (MortTurretPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function MortTurretPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
                        {
                                %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableMortar",%num);
                                deleteObject(%set);
                                if($MaxNumTurretsInBox > %num)
                                {
                                        %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
                                        %num = CountObjects(%set,"DeployableTurret",%num);
                                        deleteObject(%set);
                                        if(0 == %num)
                                        {
                                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                                {
                                                        if(checkDeployArea(%client,$los::position))
                                                        {
                                                                %rot = GameBase::getRotation(%player);
                                                                %turret = newObject("remoteTurret","Turret",DeployableMortar,true);
                                                                addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"Mortar Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"Mortar Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "MortTurretPack"]++;
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


//--------------------------- Laser Turret --------------------
ItemImageData LaserPackImage {
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.06 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};
ItemData LaserPack {
        description = "Laser Turret";
        shapeFile = "camera";
        className = "Backpack";
        heading = "fTurrets";
        imageType = LaserPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 300;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function LaserPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function LaserPack::onDeploy(%player,%item,%pos) {
        if (LaserPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function LaserPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                        %num = CountObjects(%set,"DeployableLaser",%num);
                        deleteObject(%set);
                        if($MaxNumTurretsInBox > %num)
                        {
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
                                        if(checkDeployArea(%client,$los::position))
                                        {
                                                %camera = newObject("Camera","Turret",DeployableLaser,true);
                                                addToSet("MissionCleanup", %camera);
                                                GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                                GameBase::setRotation(%camera,%rot);
                                                GameBase::setPosition(%camera,$los::position);
                                                Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                                Client::sendMessage(%client,0,"Laser Turret deployed");
                                                playSound(SoundPickupBackpack,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;
                                                return true;
                                        }
                                }
                                else
                                {
                                        Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                                }
                        }
                        else Client::sendMessage(%client,0,"Interference from other laser turrets in the area");
                }
                else
                {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}


//-----------------------------C.I.W.S. Turret-------------------------
ItemImageData CIWSTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData CIWSTurretPack
{
        description = "C.I.W.S. AA Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
           heading = "fTurrets";
        imageType = CIWSTurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 650;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function CIWSTurretPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else {
                Player::deployItem(%player,%item);
        }
}

function CIWSTurretPack::onDeploy(%player,%item,%pos)
{
        if (CIWSTurretPack::deployShape(%player,%item)) {
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

function CIWSTurretPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape") {
                            %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                %num = CountObjects(%set,"DeployableCIWS",%num);
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
                                                                %turret = newObject("missileturret","Turret",DeployableCIWS,true);
                             addToSet("MissionCleanup", %turret);
                                                                GameBase::setTeam(%turret,GameBase::getTeam(%player));
                                                                GameBase::setPosition(%turret,$los::position);
                                                                GameBase::setRotation(%turret,%rot);
                                                                Gamebase::setMapName(%turret,"CIWS Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
                                                                Client::sendMessage(%client,0,"CIWS Turret deployed");
                                                                playSound(SoundPickupBackpack,$los::position);
                                                                $TeamItemCount[GameBase::getTeam(%player) @ "CIWSTurretPack"]++;
                                                                echo("MSG: ",%client," deployed a Rocket Turret");
                                                                //        Remote turrets - kill points to player that deploy them
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

//-------------------------------- EMP Turret -----------------------------------
ItemImageData EMPTurretPackImage {
        shapeFile = "indoorgun";
        mountPoint = 2;
        mountOffset = { 0, -0.1, -0.06 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};
ItemData EMPTurretPack {
        description = "EMP Turret";
        shapeFile = "indoorgun";
        className = "Backpack";
        heading = "fTurrets";
        imageType = EMPTurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function EMPTurretPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function EMPTurretPack::onDeploy(%player,%item,%pos) {
        if (EMPTurretPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function EMPTurretPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
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
                                if(checkDeployArea(%client,$los::position))
                                {
                                        %set = newObject("set",SimSet);
                                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
                                        %num = CountObjects(%set,"DeployableShock",%num);
                                        deleteObject(%set);
                                        if($MaxNumTurretsInBox > %num)
                                        {
                                                %camera = newObject("Camera","Turret",DeployableShock,true);
                                                addToSet("MissionCleanup", %camera);
                                                GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                                GameBase::setRotation(%camera,%rot);
                                                GameBase::setPosition(%camera,$los::position);
                                                Gamebase::setMapName(%camera,"EMP Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                                Client::sendMessage(%client,0,"EMP Turret deployed");
                                                playSound(SoundPickupBackpack,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%camera) @ "EMPTurretPack"]++;
                                                return true;
                                        }
                                        else Client::sendMessage(%client,0,"Interference from other Shock turrets in the area");
                                }
                        }
                        else
                        {
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                        }
                }
                else
                {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}
//============================== This is the section which adds weapons of NDG ====================

//=============================================== Shot Gun ========================================
ItemData ShotGunAmmo
{
        description = "Shotgun Shells";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "ammo1";
        shadowDetailMask = 4;
        price = 5;
};

ItemImageData ShotGunImage
{
        shapeFile = "energygun";
        mountPoint = 0;
        ammoType = ShotGunAmmo;
        projectileType = "Undefined";
        weaponType = 0; // Single Shot
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

ItemData ShotGun
{
    description = "Shotgun";
    shapeFile = "energygun";
    hudIcon = "blaster";
    className = "Weapon";
    heading = "bWeapons";
    shadowDetailMask = 4;
    imageType = ShotGunImage;
    showWeaponBar = true;
    price = 500;
};

function ShotGun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "ShotGun- Up close means alot of damage");
}

function ShotGunImage::onFire(%player, %slot)
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[ShotGun]);
         if(%AmmoCount)
         {
                 %client = GameBase::getOwnerClient(%player);
                 Player::decItemCount(%player,$WeaponAmmo[ShotGun],1);
                 %trans = GameBase::getMuzzleTransform(%player);
             %vel = Item::getVelocity(%player);

                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
        }
        else
                Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}

//====================================== Shock Mortar ===============================================
ItemData ShockMortarAmmo {
        description = "Shock Mortar Ammo";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "mortarammo";
        shadowDetailMask = 4;
        price = 5;
};
ItemImageData ShockMortarGunImage {
        shapeFile = "mortargun";
        mountPoint = 0;
        weaponType = 0;
        ammoType = ShockMortarAmmo;
        projectileType = ShockMortarShell;
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
ItemData ShockMortarGun {
        description = "Shock Mortar";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "mortar";
        heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = ShockMortarGunImage;
        price = 375;
        showWeaponBar = true;
};

function ShockMortarGun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "ShockMortarGun- Use it to drain the energy of enemies and thier turrets");
}
//========================================== Sniper Rifle ========================================
ItemData SniperAmmo {
        description = "Sniper Bullet";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "ammo1";
        shadowDetailMask = 4;
        price = 5;
};
ItemImageData SniperRifleImage {
        shapeFile = "sniper";
        mountPoint = 0;
        weaponType = 0;
        ammoType = SniperAmmo;
        projectileType = SniperBullet;
        accuFire = true;
        reloadTime = 1.5;
        fireTime = 0;
        lightType = 3;
        lightRadius = 6;
        lightTime = 2;
        lightColor = { 1.0, 0, 0 };
        sfxFire = SoundFireChainGun;
        sfxActivate = SoundPickUpWeapon;
};
ItemData SniperRifle {
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

function SniperRifle::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Sniper Rifle- Reach out and touch someone");
}

//======================================== Shock Wave Gun ===========================================
ItemImageData WaveGunImage {
        shapeFile = "shotgun";
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
ItemData WaveGun {
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

function WaveGun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "WaveGun- Sends a large shockwave off on impact");
}

//============================================== Rail Gun ================================
ItemData RailAmmo {
        description = "Railgun Bolt";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "ammo1";
        shadowDetailMask = 4;
        price = 5;
};
ItemImageData RailgunImage {
        shapeFile = "sniper";
        mountPoint = 0;
        weaponType = 0;
        ammoType = RailAmmo;
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
ItemData Railgun {
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

function Railgun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "RailGun- Fires a superfast low damage nail at folks");
}

//========================================= Flame Thrower ====================================
ItemImageData FlamerImage {
        shapeFile = "GrenadeL";
        mountPoint = 0;
        weaponType = 0;
        reloadTime = 0.05;
        fireTime = 0;
        minEnergy = 5;
        maxEnergy = 6;
        projectileType = FlamerBolt;
        accuFire = true;
        sfxFire = SoundJetHeavy;
        sfxActivate = SoundPickUpWeapon;
};
ItemData Flamer {
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

function Flamer::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Flame Thrower- Short Range but sets them on fire");
}

//========================================= Ion Gun =======================================
ItemImageData IonGunImage {
        shapeFile = "GrenadeL";
        mountPoint = 0;
        weaponType = 0;
        reloadTime = 0;
        fireTime = 0.3;
        minEnergy = 19;
        maxEnergy = 20;
        projectileType = IonBolt;
        accuFire = true;
        sfxFire = SoundFireLaser;
        sfxActivate = SoundPickUpWeapon;
};
ItemData IonGun {
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

function IonGun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Ion Gun- Fires small fast bolts of Ion energy");
}

//======================================= ThunderBolt ======================================
ItemImageData ThunderboltImage {
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
ItemData Thunderbolt {
        description = "Thunderbolt";
        shapeFile = "shotgun";
        hudIcon = "energyRifle";
        className = "Weapon";
        heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = ThunderboltImage;
        showWeaponBar = true;
        price = 500;
};

function Thunderbolt::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Thunderbolt- Life draining Lightning bolts of death");
}

//====================================== Cloaking Gun =======================================
ItemImageData CloakGunImage
{
           shapeFile = "shotgun";
           mountPoint = 0;
           weaponType = 2;  // Sustained
           projectileType = cloakingCharge;
           minEnergy = 3;
           maxEnergy = 100;  // Energy used/sec for sustained weapons
           reloadTime = 0.2;
           lightType = 3;  // Weapon Fire
           lightRadius = 2;
           lightTime = 1;
           lightColor = { 0.15, 0.85, 0.15 };
           sfxActivate = SoundPickUpWeapon;
           sfxFire     = SoundELFIdle;
};

ItemData CloakGun
{
           description = "Cloaking Gun";
           shapeFile = "shotgun";
           hudIcon = "energyRifle";
           className = "Weapon";
           heading = "bWeapons";
           shadowDetailMask = 4;
           imageType = CloakGunImage;
           showWeaponBar = true;
           price = 900;
};

function CloakGun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "CloakGun- Will turn the target invisible, not to sensors though");
}

//======================================== Eng Repair Gun ================================
ItemImageData EngRepGunImage {
        shapeFile = "repairgun";
        mountPoint = 0;
        weaponType = 2;
        projectileType = RepairBolt2;
        minEnergy = 5;
        maxEnergy = 15;
        lightType = 3;
        lightRadius = 1;
        lightTime = 1;
        lightColor = { 1, 0.25, 0.25 };
        sfxFire = SoundRepairItem;
        sfxActivate = SoundPickUpWeapon;
};
ItemData EngRepGun {
        description = "Engineer Repair-Gun";
        className = "Tool";
        shapeFile = "repairgun";
        hudIcon = "targetlaser";
        heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = EngRepGunImage;
        price = 50;
        showWeaponBar = false;
};

function EngRepGun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Engineer Repair Gun- Fixes things twice as fast as repair pack");
}

//====================================== Medics Healing Gun ======================
ItemImageData MedHealGunImage {
        shapeFile = "repairgun";
        mountPoint = 0;
        weaponType = 2;
        projectileType = RepairBolt3;
        minEnergy = 5;
        maxEnergy = 15;
        lightType = 3;
        lightRadius = 1;
        lightTime = 1;
        lightColor = { 0.25, 0.25, 1 };
        sfxFire = SoundRepairItem;
        sfxActivate = SoundPickUpWeapon;
};
ItemData MedHealGun {
        description = "Medics Healing Gun";
        className = "Tool";
        shapeFile = "repairgun";
        hudIcon = "targetlaser";
        heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = MedHealGunImage;
        price = 50;
        showWeaponBar = false;
};

function MedHealGun::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Medics Healing Gun- Fixes people twice as fast as repair pack");
}


//=========================================== Rocket Launcher ===============================
ItemData RocketAmmo {
        description = "Rockets";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "rocket";
        shadowDetailMask = 4;
        price = 50;
};
ItemImageData RocketImage {
        shapeFile = "mortargun";
        mountPoint = 0;
        weaponType = 0;
        ammoType = RocketAmmo;
        projectileType = StingerMissile;
        accuFire = true;
        reloadTime = 0.5;
        fireTime = 2.0;
        lightType = 3;
        lightRadius = 3;
        lightTime = 1;
        lightColor = { 0.6, 1, 1.0 };
        sfxFire = SoundMissileTurretFire;
        sfxActivate = SoundPickUpWeapon;
        sfxReload = SoundMortarReload;
        sfxReady = SoundMortarIdle;
};
ItemData RocketLauncher {
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

function RocketLauncher::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Rocket Launcher- Fires a rocket straight forward to intended target");
}

//============================================= Other Deployable items ======================

//**************************************Stealth Shield Pack *********************************
ItemImageData StealthShieldPackImage {
        shapeFile = "shieldPack";
        mountPoint = 2;
        weaponType = 2;
        minEnergy = 6;
        maxEnergy = 9;
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
        %rate = Player::getSensorSupression(%player) + 20;
        Player::setSensorSupression(%player,%rate);
}
function StealthShieldPackImage::onDeactivate(%player,%imageSlot) {
        Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
        Player::trigger(%player,$BackpackSlot,false);
        %player.shieldStrength = 0;
        %rate = Player::getSensorSupression(%player) - 20;
        Player::setSensorSupression(%player,%rate);
}

//*************************************** Deployable Force Field ***********************************

ItemImageData ForceFieldPackImage {
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 2.5;
        firstPerson = false;
};
ItemData ForceFieldPack {
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
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function ForceFieldPack::onDeploy(%player,%item,%pos) {
        if (ForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function ForceFieldPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set,"DeployableForceField",%num);
                        deleteObject(%set);
                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                        {
                                %rot = GameBase::getRotation(%player);
                                %phase = newObject("","StaticShape",DeployableForceField,true);
                                addToSet("MissionCleanup", %phase);
                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                GameBase::setPosition(%phase,$los::position);
                                GameBase::setRotation(%phase,%rot);
                                Gamebase::setMapName(%phase,"Force Field");
                                Client::sendMessage(%client,0,"Force Field Deployed");
                                GameBase::startFadeIn(%phase);
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

//************************************** Large Deployable Force Field *******************************

ItemImageData LargeForceFieldPackImage {
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 2.5;
        firstPerson = false;
};
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
};
function LargeForceFieldPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function LargeForceFieldPack::onDeploy(%player,%item,%pos) {
        if (LargeForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function LargeForceFieldPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set,"DeployableForceField",%num);
                        deleteObject(%set);
                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                        {
                                %rot = GameBase::getRotation(%player);
                                %phase = newObject("","StaticShape",LargeForceField,true);
                                addToSet("MissionCleanup", %phase);
                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                GameBase::setPosition(%phase,$los::position);
                                GameBase::setRotation(%phase,%rot);
                                Gamebase::setMapName(%phase,"Force Field");
                                Client::sendMessage(%client,0,"Force Field Deployed");
                                GameBase::startFadeIn(%phase);
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

//************************************************ Blast Wall Pack ***************************************
ItemImageData BlastwallPackImage {
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.1, 0 };
        mass = 2.5;
        firstPerson = false;
};
ItemData BlastwallPack {
        description = "Blast Wall";
        shapeFile = "newdoor5";
        className = "Backpack";
        heading = "dDeployables";
        imageType = BlastwallPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function BlastwallPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function BlastwallPack::onDeploy(%player,%item,%pos) {
        if (BlastwallPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function BlastwallPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain")
                        {
                                %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                                %num = CountObjects(%set,"BlastWall",%num);
                                deleteObject(%set);
                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                {
                                        if(checkDeployArea(%client,$los::position))
                                        {
                                                %rot = GameBase::getRotation(%player);
                                                %phase = newObject("","StaticShape",BlastWall,true);
                                                addToSet("MissionCleanup", %phase);
                                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                                GameBase::setPosition(%phase,$los::position);
                                                GameBase::setRotation(%phase,%rot);
                                                Gamebase::setMapName(%phase,"Blast Wall");
                                                Client::sendMessage(%client,0,"Blast Wall Deployed");
                                                GameBase::startFadeIn(%phase);
                                                playSound(SoundPickupBackpack,$los::position);
                                                playSound(ForceFieldOpen,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%player) @ "BlastwallPack"]++;
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

//************************************************ Spring Pack ************************************
ItemImageData SpringPackImage {
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 2.5;
        firstPerson = false;
};
ItemData SpringPack {
        description = "Deployable Springboard";
        shapeFile = "flagstand";
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
};
function SpringPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function SpringPack::onDeploy(%player,%item,%pos) {
        if (SpringPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function SpringPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape")
                        {
                                %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                                %num = CountObjects(%set,"DeployableCactus",%num);
                                deleteObject(%set);
                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                {
                                        if(checkDeployArea(%client,$los::position))
                                        {
                                                %rot = GameBase::getRotation(%player);
                                                %phase = newObject("","StaticShape",DeployableSpring,true);
                                                addToSet("MissionCleanup", %phase);
                                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                                GameBase::setPosition(%phase,$los::position);
                                                GameBase::setRotation(%phase,%rot);
                                                Gamebase::setMapName(%phase,"SpringBoard");
                                                Client::sendMessage(%client,0,"SpringBoard Deployed");
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

//*********************************************** Deployable Platform *******************************
ItemImageData PlatformPackImage {
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 2.5;
        firstPerson = false;
};
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
};
function PlatformPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function PlatformPack::onDeploy(%player,%item,%pos) {
        if (PlatformPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function PlatformPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set,"DeployablePlatform",%num);
                        deleteObject(%set);
                        %rot = GameBase::getRotation(%player);
                        %phase = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true);
                        addToSet("MissionCleanup", %phase);
                        GameBase::setTeam(%phase,GameBase::getTeam(%player));
                        GameBase::setPosition(%phase,$los::position);
                        GameBase::setRotation(%phase,%rot);
                        Gamebase::setMapName(%phase,"Deployable Platform");
                        Client::sendMessage(%client,0,"Platform Deployed");
                        GameBase::startFadeIn(%phase);
                        playSound(SoundPickupBackpack,$los::position);
                        $TeamItemCount[GameBase::getTeam(%player) @ "PlatformPack"]++;
                        return true;
                }
                else Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}

//************************************************* Teleport Pads *********************************
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
        price = 2000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function TeleportPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function TeleportPack::onDeploy(%player,%item,%pos) {
        if (TeleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item))
        {
                Player::decItemCount(%player,%item);
                $TeamItemCount[GameBase::getTeam(%player) @ "TeleportPack"]++;
        }
}
function CreateteleportSimSet() {
        %teleset = nameToID("MissionCleanup/Teleports");
        if(%teleset == -1)
        {
                newObject("Teleports",SimSet);
                addToSet("MissionCleanup","Teleports");
        }
}
function TeleportPack::deployShape(%player,%name,%shape,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[TeleportPack])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
                        {
                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                {
                                        if(checkDeployArea(%client,$los::position))
                                        {
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
        return false;
}

//****************************** Cloaking Device ***********************************
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
        description = "Cloaking Device";
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
        GameBase::startFadeout(%player);
        Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
        %rate = Player::getSensorSupression(%player) + 5;
        Player::setSensorSupression(%player,%rate);
        %player.guiLock = true;
        %c = Player::getClient(%player);
        %c.guiLock = true;
        %clientId.ghostDoneFlag = true;
        startGhosting(%cl);
}
function CloakingDeviceImage::onDeactivate(%player,%imageSlot) {
        GameBase::startFadein(%player);
        Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
        %rate = Player::getSensorSupression(%player) - 5;
        Player::setSensorSupression(%player,%rate);
        Player::trigger(%player,$BackpackSlot,false);
        %player.guiLock = "";
        %c = Player::getClient(%player);
        %c.guiLock = "";
}

//***************************************** Lightning Pack ***********************************
ItemImageData LightningPackImage {
        shapeFile = "shieldPack";
        mountPoint = 2;
        weaponType = 2;
        projectileType = boltCharge;
        minEnergy = 9;
        maxEnergy = 10;
        reloadTime = 0.2;
        sfxFire = SoundELFIdle;
};
ItemData LightningPack {
        description = "Lightning Pack";
        shapeFile = "shieldPack";
        className = "Backpack";
        heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = LightningPackImage;
        price = 275;
        hudIcon = "shieldpack";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function LightningPackImage::onActivate(%player,%imageSlot) {
        Client::sendMessage(Player::getClient(%player),0,"Lightning Field On");
}
function LightningPackImage::onDeactivate(%player,%imageSlot) {
        Client::sendMessage(Player::getClient(%player),0,"Lightning Field Off");
        Player::trigger(%player,$BackpackSlot,false);
}

//************************************* Optic Laser Pack *****************************
ItemImageData OpticPackImage {
        shapeFile = "repairgun";
        mountPoint = 2;
        mountOffset = { 0.2, 0.4, 0.45 };
        mountRotation = { 0, 0, 0 };
        weaponType = 0;
        projectileType = SniperLaser;
        accuFire = true;
        reloadTime = 6.5;
        fireTime = 0.0;
        minEnergy = 10;
        maxEnergy = 60;
        lightType = 3;
        lightRadius = 2;
        lightTime = 1;
        lightColor = { 1, 0, 0 };
        sfxFire = SoundFireLaser;
};
ItemData OpticPack {
        description = "Cybernetic Laser";
        shapeFile = "repairgun";
        className = "Backpack";
        heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = OpticPackImage;
        price = 275;
        hudIcon = "sniper";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function OpticPackImage::onActivate(%player,%imageSlot) {
        schedule("use(\"backpack\");", 0.5);
}
function OpticPackImage::onDeactivate(%player,%imageSlot) {
        Player::trigger(%player,$BackpackSlot,false);
}

//********************************* Rocket Launcher Pack *******************************
ItemImageData SRMPackImage {
        shapeFile = "mortargun";
        mountPoint = 2;
        mountOffset = { -0.4, 0.1, 0.4 };
        mountRotation = { 0.2, 0, 0 };
        weaponType = 0;
        ammoType = RocketAmmo;
        projectileType = StingerMissile;
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
ItemData SRMPack {
        description = "Auto-Rocket Cannon";
        shapeFile = "mortargun";
        className = "Backpack";
        heading = "cBackpacks";
        shadowDetailMask = 4;
        imageType = SRMPackImage;
        price = 350;
        hudIcon = "mortar";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function SRMPackImage::onActivate(%player,%imageSlot) {
        schedule("use(\"backpack\");", 0.5);
}
function SRMPackImage::onDeactivate(%player,%imageSlot) {
        Player::trigger(%player,$BackpackSlot,false);
}

//********************************************** Command Laptop *************************
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
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
}
function Laptop::onMount(%player,%item) {
        Player::trigger(%player,$BackpackSlot,true);
}
function Laptop::onUnmount(%player,%item) {
}

//***************************** Suicide Det Pack ***********************************
ItemImageData SuicidePackImage {
        shapeFile = "magcargo";
        mountPoint = 2;
        mountOffset = { 0, -0.5, -0.3 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};
ItemData SuicidePack {
        description = "Suicide DetPack";
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
};
function SuicidePack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function SuicidePack::onUnmount(%player,%item) {
}
function SuicidePack::onDeploy(%player,%item,%pos) {
        if (SuicidePack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function SuicidePack::deployShape(%player,%item) {
        Player::unmountItem(%player,$BackpackSlot);
        %obj = newObject("","Mine","Suicidebomb2");
        addToSet("MissionCleanup", %obj);
        %client = Player::getClient(%player);
        GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
        Client::sendMessage(%client,1,"Det Pack will destruct in 20 seconds");
}

//**************************** Armor HoloGram ***********************************
ItemImageData HoloPackImage {
        shapeFile = "ShieldPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 1.0;
        firstPerson = false;
};
ItemData HoloPack {
        description = "Hologram";
        shapeFile = "larmor";
        className = "Backpack";
        heading = "hHolograms";
        imageType = HoloPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 900;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function HoloPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function HoloPack::onDeploy(%player,%item,%pos) {
        if (HoloPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function HoloPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "hologram"] < $TeamItemMax["HoloPack"])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set,"Hologram",%num);
                        deleteObject(%set);
                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                        {
                                if(checkDeployArea(%client,$los::position))
                                {
                                        %rot = GameBase::getRotation(%player);
                                        %rnd = floor(getRandom() * 10);
                                        if(%rnd > 6) %phase = newObject("","StaticShape",Hologram1,true);
                                        else if((%rnd > 2) && (%rnd < 7)) %phase = newObject("","StaticShape",Hologram2,true);
                                        else %phase = newObject("","StaticShape",Hologram3,true);
                                        %armor = Player::getArmor(%player);
                                        if (%armor == "dmarmor" || %armor == "dmfemale")
                                        {
                                                %phase = newObject("","StaticShape",Hologram2,true);
                                        }
                                        addToSet("MissionCleanup", %phase);
                                        GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                        GameBase::setPosition(%phase,$los::position);
                                        GameBase::setRotation(%phase,%rot);
                                        Client::sendMessage(%client,0,"Hologram Deployed");
                                        GameBase::startFadeIn(%phase);
                                        playSound(ForceFieldOpen,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%player) @ "hologram"]++;
                                        return true;
                                }
                        }
                        else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                }
                else Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}

//************************************** Deployable Tree *****************************
ItemImageData TreePackImage {
        shapeFile = "tree1";
        mountPoint = 2;
        mountOffset = { 0, 0.15, -1 };
        mass = 2.5;
        firstPerson = false;
};
ItemData TreePack {
        description = "Mechanical Tree";
        shapeFile = "tree1";
        className = "Backpack";
        heading = "dDeployables";
        imageType = TreePackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function TreePack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function TreePack::onDeploy(%player,%item,%pos) {
        if (TreePack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function TreePack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain")
                        {
                                %set = newObject("set",SimSet);
                                %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                                %num = CountObjects(%set,"DeployableTree",%num);
                                deleteObject(%set);
                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                {
                                        if(checkDeployArea(%client,$los::position))
                                        {
                                                %rot = GameBase::getRotation(%player);
                                                %rnd = floor(getRandom() * 10);
                                                if(%rnd > 5) %phase = newObject("","StaticShape",DeployableTree,true);
                                                else %phase = newObject("","StaticShape",DeployableTree2,true);
                                                addToSet("MissionCleanup", %phase);
                                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                                GameBase::setPosition(%phase,$los::position);
                                                GameBase::setRotation(%phase,%rot);
                                                Gamebase::setMapName(%phase,"Mechanical Tree");
                                                Client::sendMessage(%client,0,"Mechanical Tree Deployed");
                                                GameBase::startFadeIn(%phase);
                                                playSound(SoundPickupBackpack,$los::position);
                                                playSound(ForceFieldOpen,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
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

//************************************ Interceptor Pack *************************************
ItemImageData InterceptorPackImage {
        shapeFile = "ammounit_remote";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 2.5;
        firstPerson = false;
};
ItemData InterceptorPack {
        description = "Interceptor Pack";
        shapeFile = "ammounit_remote";
        className = "Backpack";
        heading = "dDeployables";
        imageType = InterceptorPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function InterceptorPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function InterceptorPack::onDeploy(%player,%item,%pos) {
        if (InterceptorPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function InterceptorPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "InterceptVehicle"] < $TeamItemMax[InterceptVehicle])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape")
                        {
                                %set = newObject("set",SimSet);
                                deleteObject(%set);
                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                {
                                        if(checkDeployArea(%client,$los::position))
                                        {
                                                %rot = GameBase::getRotation(%player);
                                                %phase = newObject("",flier,Interceptor,true);
                                                addToSet("MissionCleanup", %phase);
                                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                                GameBase::setPosition(%phase,$los::position);
                                                GameBase::setRotation(%phase,%rot);
                                                Client::sendMessage(%client,0,"Piloting Interceptor");
                                                GameBase::startFadeIn(%phase);
                                                playSound(SoundPickupBackpack,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%player) @ "InterceptVehicle"]++;
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

//*********************************************** HPC Pack *******************************
ItemImageData HPCPackImage {
        shapeFile = "ammounit_remote";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 2.5;
        firstPerson = false;
};
ItemData HPCPack {
        description = "HPC Pack";
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
};
function HPCPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
        {
                Player::mountItem(%player,%item,$BackpackSlot);
        }
        else
        {
                Player::deployItem(%player,%item);
        }
}
function HPCPack::onDeploy(%player,%item,%pos) {
        if (HPCPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}
function HPCPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"] < $TeamItemMax[HAPCVehicle])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape")
                        {
                                %set = newObject("set",SimSet);
                                deleteObject(%set);
                                if (Vector::dot($los::normal,"0 0 1") > 0.7)
                                {
                                        if(checkDeployArea(%client,$los::position))
                                        {
                                                %rot = GameBase::getRotation(%player);
                                                %phase = newObject("",flier,HAPC,true);
                                                addToSet("MissionCleanup", %phase);
                                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                                GameBase::setPosition(%phase,$los::position);
                                                GameBase::setRotation(%phase,%rot);
                                                Gamebase::setMapName(%phase,"HPC Pack");
                                                Client::sendMessage(%client,0,"Deployed HPC");
                                                GameBase::startFadeIn(%phase);
                                                playSound(SoundPickupBackpack,$los::position);
                                                $TeamItemCount[GameBase::getTeam(%player) @ "HAPCVehicle"]++;
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
function Item::deployShape(%player,%name,%shape,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform")
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
                                else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                        }
                        else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                }
                else Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
        return false;
}

//============================================================================================
//============================== Beacons Grenades and Mines ==================================
ItemData MineAmmo {
        description = "Mine";
        shapeFile = "mineammo";
        heading = "eMiscellany";
        shadowDetailMask = 4;
        price = 10;
        className = "HandAmmo";
};
function MineAmmo::onUse(%player,%item) {
        if($matchStarted)
        {
                if(%player.throwTime < getSimTime() )
                {
                        Player::decItemCount(%player,%item);
                        %client = Player::getClient(%player);
                        %armor = Player::getArmor(%player);
                        if (%armor == "sparmor" || %armor == "spfemale")
                        {
                                %obj = newObject("","Mine","PlasHoloMine");
                                GameBase::setTeam (%obj,GameBase::getTeam (%client));
                        }
                        else if (%armor == "saparmor" || %armor == "sapfemale")
                        {
                                %obj = newObject("","Mine","EMPMine");
                                GameBase::setTeam (%obj,GameBase::getTeam (%client));
                        }
                        else if (%armor == "harmor")
                        {
                                %obj = newObject("","Mine","BaseDMine");
                                GameBase::setTeam (%obj, GameBase::getTeam (%client));
                        }
//                        else if (%armor == "medarmor" || %armor == "medfemale")
//                        {
//                                %obj = newObject("","Mine","TeleMine");
//                                GameBase::setTeam (%obj, GameBase::getTeam (%client));
//                        }
                        else
                        {
                                %obj = newObject("","Mine","antipersonelMine");
                                GameBase::setTeam (%obj,GameBase::getTeam (%client));
                        }
                        addToSet("MissionCleanup", %obj);
                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                        %player.throwTime = getSimTime() + 0.5;
                }
        }
}
ItemData Grenade {
        description = "Grenade";
        shapeFile = "grenade";
        heading = "eMiscellany";
        shadowDetailMask = 4;
        price = 5;
        className = "HandAmmo";
};
function Grenade::onUse(%player,%item) {
        if($matchStarted)
        {
                if(%player.throwTime < getSimTime() )
                {
                        Player::decItemCount(%player,%item);
                        %armor = Player::getArmor(%player);
                        if (%armor == "larmor" || %armor == "lfemale") %obj = newObject("","Mine","HoloMine");
                        if(%armor == "medarmor" || %armor == "medfemale" || %armor == "saparmor" || %armor == "sapfemale") %obj = newObject("","Mine","Shockgrenade");
                        if (%armor == "sarmor" || %armor == "sfemale") %obj = newObject("","Mine","Firebomb");
                        if (%armor == "sparmor" || %armor == "spfemale")
                        {
                                Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 15 seconds");
                                %obj = newObject("","Mine","Nukebomb");
                        }
                        if (%armor == "marmor" || %armor == "mfemale") %obj = newObject("","Mine","Handgrenade");
                        if (%armor == "fearmor" || %armor == "fefemale") %obj = newObject("","Mine","Handgrenade");
                        if (%armor == "pilarmor" || %armor == "pilfemale") %obj = newObject("","Mine","Handgrenade");
                        if (%armor == "harmor") %obj = newObject("","Mine","Nukebomb");
                        if (%armor == "barmor" || %armor == "bfemale") %obj = newObject("","Mine","Concussion");
                        if (%armor == "darmor") %obj = newObject("","Mine","Mortarbomb");
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
        heading = "eMiscellany";
        shadowDetailMask = 4;
        price = 5;
        className = "HandAmmo";
};
function Beacon::onUse(%player,%item) {
        %armor = Player::getArmor(%player);
        %clientId = Player::getClient(%player);
        if (%armor == "larmor" || %armor == "lfemale" || %armor == "saparmor" || %armor == "sapfemale")
        {
                SniperJammer(%clientId, %player, %item);
        }
        if(%armor == "medarmor" || %armor == "medfemale" )
        {
                EngCamera(%clientId, %player, %item);
        }
        if(%armor == "fearmor" || %armor == "fefemale")
        {
                DeploySatchel(%clientID, %player, %item);
        }
        if (%armor == "sarmor" || %armor == "sfemale")
        {
                ScoutSensor(%clientId, %player, %item);
        }
        if (%armor == "sparmor" || %armor == "spfemale")
        {
                Renegades_startCloak(%clientId, %player);
                Player::decItemCount(%player,%item);
                // DeploySatchel(%clientId, %player, %item);
        }
        if (%armor == "marmor" || %armor == "mfemale" || %armor == "harmor")
        {
                if($matchStarted)
                {
                        if(%player.throwTime < getSimTime() )
                        {
                                %obj = newObject("","Mine","Booster");
                                addToSet("MissionCleanup", %obj);
                                %client = Player::getClient(%player);
                                GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                                %player.throwTime = getSimTime() + 0.5;
                                Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster.");
                                Player::decItemCount(%player,%item);
                        }
                }
        }
        if (%armor == "pilarmor" || %armor == "pilfemale")
        {
                if($matchStarted)
                {
                        if(%player.throwTime < getSimTime() )
                        {
                                %obj = newObject("","Mine","Booster");
                                addToSet("MissionCleanup", %obj);
                                %client = Player::getClient(%player);
                                GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                                %player.throwTime = getSimTime() + 0.5;
                                Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster.");
                                Player::decItemCount(%player,%item);
                        }
                }

                // Renegades_startCloak(%clientId, %player);
                // Player::decItemCount(%player,%item);
        }
        if (%armor == "barmor" || %armor == "bfemale")
        {
                if($matchStarted)
                {
                        if(%player.throwTime < getSimTime() )
                        {
                                %obj = newObject("","Mine","Firebomb");
                                addToSet("MissionCleanup", %obj);
                                %client = Player::getClient(%player);
                                GameBase::throw(%obj,%player,35 * %client.throwStrength,true);
                                %player.throwTime = getSimTime() + 0.5;
                                Player::decItemCount(%player,%item);
                        }
                }
        }
        if (%armor == "darmor")
        {
                Renegades_startShield(%clientId, %player);
                Player::decItemCount(%player,%item);
        }
}
function Renegades_startStim(%clientId, %player) {
        Client::sendMessage(%clientId,0,"You used a StimPack!");
        %this = "RepairPatch";
        Item::playPickupSound(%this);
        %armor = Player::getArmor(%player);
        %armor.maxForwardSpeed = %armor.maxForwardSpeed + 5;
        Player::setDamageFlash(%player,0.75);
        GameBase::applyDamage(%player,$LandingDamageType,0.20,GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
        if($stimTime[%clientId] == 0)
        {
                $stimTime[%clientId] = 20;
                checkPlayerStim(%clientId, %player);
        }
        else $StimTime[%clientId] = 20;
}
function checkPlayerStim(%clientId, %player) {
        if($StimTime[%clientId] > 0)
        {
                $StimTime[%clientId] -= 2;
                if (!Player::isDead(%player))
                {
                }
                else
                {
                        $StimTime[%clientId] = 0;
                        %armor.maxForwardSpeed = 9;
                }
                schedule("checkPlayerStim(" @ %clientId @ ", " @ %player @ ");",2,%player);
        }
        else
        {
                Client::sendMessage(%clientId,0,"StimPack wore off.");
                %armor = Player::getArmor(%player);
                %armor.maxForwardSpeed = 9;
        }
}
function Renegades_startShield(%clientId, %player) {
        Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
        GameBase::playSound(%player,ForceFieldOpen,0);
        %player.shieldStrength = 0.006;
        if($shieldTime[%clientId] == 0)
        {
                $shieldTime[%clientId] = 20;
                checkPlayerShield(%clientId, %player);
        }
        else $shieldTime[%clientId] = 20;
}
function checkPlayerShield(%clientId, %player) {
        %armor = Player::getArmor(%player);
        if($shieldTime[%clientId] > 0)
        {
                $shieldTime[%clientId] -= 2;
                if ((!Player::isDead(%player)) && (%armor == "darmor" || %armor == "dfemale"))
                {
                        if (Player::isDead(%player))
                        {
                        }
                }
                else
                {
                        $shieldTime[%clientId] = 0;
                }
                schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
        }
        else
        {
                Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
                %player.shieldStrength = 0;
                GameBase::playSound(%player,ForceFieldOpen,0);
        }
}
function Renegades_startCloak(%clientId, %player) {
        %armor = Player::getArmor(%player);
        Client::sendMessage(%clientId,0,"Cloaking On");
        GameBase::playSound(%player,ForceFieldOpen,0);
        GameBase::startFadeout(%player);
        %rate = Player::getSensorSupression(%player) + 5;
        Player::setSensorSupression(%player,%rate);
        if($cloakTime[%clientId] == 0)
        {
                $cloakTime[%clientId] = 30;
                checkPlayerCloak(%clientId, %player);
        }
        else $cloakTime[%clientId] = 30;
}
function checkPlayerCloak(%clientId, %player) {
        %armor = Player::getArmor(%player);
        if($cloakTime[%clientId] > 0)
        {
                $cloakTime[%clientId] -= 2;
                if ( (!Player::isDead(%player)) && (%armor == "sparmor" || %armor == "spfemale") )
                {
                }
                else
                {
                        $cloakTime[%clientId] = 0;
                }
                schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
        }
        else
        {
                Client::sendMessage(%clientId,0,"Cloaking Off");
                GameBase::playSound(%player,ForceFieldOpen,0);
                GameBase::startFadein(%player);
                %rate = Player::getSensorSupression(%player) - 5;
                Player::setSensorSupression(%player,0);
        }
}
function DeploySatchel( %clientId, %player, %bec) {
        %item = "SatchelPack";
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
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
                                Player::decItemCount(%player,%bec);
                                return true;
                        }
                }
                else
                {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for Satchel Charges");
        return false;
}
function EngCamera(%clientId, %player, %bec) {
        %item = "CameraPack";
        %client = Player::getClient(%player);
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
                                if(checkDeployArea(%client,$los::position))
                                {
                                        %camera = newObject("Camera","Turret",DeployableMini,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Enginerering Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Engineer Camera deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
                                        echo("MSG: ",%client," deployed a Engineering Camera");
                                        Player::decItemCount(%player,%bec);
                                        return true;
                                }
                        }
                        else
                        {
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                        }
                }
                else
                {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}
function SniperJammer(%clientId, %player, %bec) {
        %item = "DeployableSensorJammerPack";
        %client = Player::getClient(%player);
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
                                if(checkDeployArea(%client,$los::position))
                                {
                                        %camera = newObject("sensor_jammer","Sensor",DeployableSensorJammer,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"SensorJammer");
                                        Client::sendMessage(%client,0,"SensorJammer deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "DeployableSensorJammerPack"]++;
                                        echo("MSG: ",%client," deployed a Sensor Jammer");
                                        Player::decItemCount(%player,%bec);
                                        return true;
                                }
                        }
                        else
                        {
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                        }
                }
                else
                {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}
function ScoutSensor(%clientId, %player, %bec) {
        %item = "PulseSensorPack";
        %client = Player::getClient(%player);
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
                                if(checkDeployArea(%client,$los::position))
                                {
                                        %camera = newObject("radar_small","Sensor",DeployablePulseSensor,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Pulse Sensor");
                                        Client::sendMessage(%client,0,"Pulse Sensor deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "PulseSensorPack"]++;
                                        echo("MSG: ",%client," deployed a Pulse Sensor");
                                        Player::decItemCount(%player,%bec);
                                        return true;
                                }
                        }
                        else
                        {
                                Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
                        }
                }
                else
                {
                        Client::sendMessage(%client,0,"Deploy position out of range");
                }
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}

//************************************* Wand of Wonder ***********************************
ItemData WandAmmo
{
        description = "Wand Charges";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "ammo1";
        shadowDetailMask = 4;
        price = 5;
};

ItemImageData WonderWandImage
{
        shapeFile = "repairgun";
        mountPoint = 0;
        ammoType = WandAmmo;
        projectileType = "Undefined";
        weaponType = 0; // Single Shot
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

ItemData WonderWand
{
    description = "Wand of Wonder";
    shapeFile = "repairgun";
    hudIcon = "blaster";
    className = "Weapon";
    heading = "bWeapons";
    shadowDetailMask = 4;
    imageType = WonderWandImage;
    showWeaponBar = true;
    price = 500;
};

function WonderWand::onMount(%player,%item)
{
          %client = Player::getClient(%player);
          Bottomprint(%client, "Wand of Wonder- Pull the trigger and a different projectile every time");
}

function WonderWandImage::onFire(%player, %slot)
{
 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[WonderWand]);
         if(%AmmoCount)
         {
                 %client = GameBase::getOwnerClient(%player);
                 Player::decItemCount(%player,$WeaponAmmo[WonderWand],1);
                 %trans = GameBase::getMuzzleTransform(%player);
                 %vel = Item::getVelocity(%player);
                        %randnum = (getRandom() -0.5) * 100;

                        if ((%randnum < -45.0) && (%randnum > -50.0)) {
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        }
                        else if ((%randnum < -40.0) && (%randnum > -45.0)) {
                                Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
                        }
                        else if ((%randnum < -35.0) && (%randnum > -40.0)) {
                                Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
                        }
                        else if ((%randnum < -30.0) && (%randnum > -35.0)) {
                                Projectile::spawnProjectile("FusionBolt",%trans,%player,%vel);
                        }
                        else if ((%randnum < -25) && (%randnum > -30.0)) {
                                Projectile::spawnProjectile("PlasmaBolt",%trans,%player,%vel);
                        }
                        else if ((%randnum < -20) && (%randnum > -25)) {
                                Projectile::spawnProjectile("MiniFusionBolt",%trans,%player,%vel);
                        }
                        else if ((%randnum < -15) && (%randnum > -20)) {
                                Projectile::spawnProjectile("DiscShell",%trans,%player,%vel);
                        }
                        else if ((%randnum < -10) && (%randnum > -15)) {
                                Projectile::spawnProjectile("SniperLaser",%trans,%player,%vel);
                        }
                        else if ((%randnum < -5) && (%randnum > -10)) {
                                Projectile::spawnProjectile("IonBolt",%trans,%player,%vel);
                        }
                        else if ((%randnum < 0) && (%randnum > -5)) {
                                Projectile::spawnProjectile("ShockShell",%trans,%player,%vel);
                        }
                        else if ((%randnum < 5) && (%randnum > 0)) {
                                Projectile::spawnProjectile("SniperBullet",%trans,%player,%vel);
                        }
                        else if ((%randnum < 10) && (%randnum > 5)) {
                                Projectile::spawnProjectile("FlamerBolt",%trans,%player,%vel);
                        }
                        else if ((%randnum < 15) && (%randnum > 10)) {
                                Projectile::spawnProjectile("RailRound",%trans,%player,%vel);
                        }
                        else if ((%randnum < 20) && (%randnum > 15)) {
                                Projectile::spawnProjectile("ShockMortarShell",%trans,%player,%vel);
                        }
                        else if ((%randnum < 25) && (%randnum > 20)) {
                                Projectile::spawnProjectile("IonBolt",%trans,%player,%vel);
                        }
                        else if ((%randnum < 30) && (%randnum > 25)) {
                                Projectile::spawnProjectile("BlasterBolt",%trans,%player,%vel);
                        }
                        else if ((%randnum < 35) && (%randnum > 30)) {
                                Projectile::spawnProjectile("Shock",%trans,%player,%vel);
                        }
                        else if ((%randnum < 40) && (%randnum > 35)) {
                                Projectile::spawnProjectile("StingerMissile",%trans,%player,%vel);
                        }
                        else if ((%randnum < 43) && (%randnum > 40)) {
                                Projectile::spawnProjectile("MortarTurretShell",%trans,%player,%vel);
                        }
                        else if ((%randnum < 44) && (%randnum > 43)) {
                                Projectile::spawnProjectile("TurretMissile",%trans,%player,%vel);
                        }
                        else if ((%randnum < 48.5) && (%randnum > 44)) {
                                Projectile::spawnProjectile("FlyerShock",%trans,%player,%vel);
                        }

                        else {
                                Projectile::spawnProjectile("TurretMissile",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("PointMissile",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("IonBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("FusionBolt",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("DiscShell",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("FlyerShock",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShotGunBlast",%trans,%player,%vel);
                        Projectile::spawnProjectile("ShockMortarShell",%trans,%player,%vel);

                        }
        }
        else
                Client::sendMessage(Player::getClient(%player), 0,"Out Of Charges");

}

//******************************************************************
//***  Added to see if we could make the turrets vulnerable     ****
//***  to the effects of EMP rounds like the shock mortar       ****
//******************************************************************

function EnergyDrain(%object, %this)
{
if(%object.emp != 1)
        {
        if(Gamebase::getEnergy(%object) > 0)
                Gamebase::setEnergy(%object, 0);

        %object.emp = 1;
        if(getObjectType(%object) == "Player")
                {
                %oldrate = GameBase::getRechargeRate(%object);
                %newrate = %oldrate - 8;
                //was at %newrate
                GameBase::setRechargeRate(%object, 0);
                Client::sendMessage(Player::getClient(%object),0,"Hit by EMP, Start walking.");
        schedule("EnergyBack(" @ %object @ ", " @ %oldrate @ ");",20.0,%object);
                }
        else
                {
                %oldrate = GameBase::getRechargeRate(%object);
                %newrate = %oldrate - 8;
                GameBase::setRechargeRate(%object, %newrate);
        schedule("EnergyBack(" @ %object @ ", " @ %oldrate @ ");",20.0,%object);
                }

        }
}

function EnergyBack(%object, %level)
{
//was at %oldrate originally $level
GameBase::setRechargeRate(%object, 8);
Client::sendMessage(Player::getClient(%object),0,"Energy systems back to full.");
%object.emp = 2;

}






//===================Back to Testing cheats and such =============================
//----------------------------------------------------------------------------

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
                Player::setItemCount(%clientId,Beacon,  200);

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

        $totalNumCameras = 0;
        $totalNumTurrets = 0;

//================================== Added for NDG Renegades Items =============================
        $TeamItemCount[0 @ DepPlasTurretPack] = 0;
        $TeamItemCount[1 @ DepPlasTurretPack] = 0;
        $TeamItemCount[2 @ DepPlasTurretPack] = 0;
        $TeamItemCount[3 @ DepPlasTurretPack] = 0;
        $TeamItemCount[4 @ DepPlasTurretPack] = 0;
        $TeamItemCount[5 @ DepPlasTurretPack] = 0;
        $TeamItemCount[6 @ DepPlasTurretPack] = 0;
        $TeamItemCount[7 @ DepPlasTurretPack] = 0;

        $TeamItemCount[0 @ DepHoloPlasPack] = 0;
        $TeamItemCount[1 @ DepHoloPlasPack] = 0;
        $TeamItemCount[2 @ DepHoloPlasPack] = 0;
        $TeamItemCount[3 @ DepHoloPlasPack] = 0;
        $TeamItemCount[4 @ DepHoloPlasPack] = 0;
        $TeamItemCount[5 @ DepHoloPlasPack] = 0;
        $TeamItemCount[6 @ DepHoloPlasPack] = 0;
        $TeamItemCount[7 @ DepHoloPlasPack] = 0;

        $TeamItemCount[0 @ DepRailTurretPack] = 0;
        $TeamItemCount[1 @ DepRailTurretPack] = 0;
        $TeamItemCount[2 @ DepRailTurretPack] = 0;
        $TeamItemCount[3 @ DepRailTurretPack] = 0;
        $TeamItemCount[4 @ DepRailTurretPack] = 0;
        $TeamItemCount[5 @ DepRailTurretPack] = 0;
        $TeamItemCount[6 @ DepRailTurretPack] = 0;
        $TeamItemCount[7 @ DepRailTurretPack] = 0;

        $TeamItemCount[0 @ PointDefTurretPack] = 0;
        $TeamItemCount[1 @ PointDefTurretPack] = 0;
        $TeamItemCount[2 @ PointDefTurretPack] = 0;
        $TeamItemCount[3 @ PointDefTurretPack] = 0;
        $TeamItemCount[4 @ PointDefTurretPack] = 0;
        $TeamItemCount[5 @ PointDefTurretPack] = 0;
        $TeamItemCount[6 @ PointDefTurretPack] = 0;
        $TeamItemCount[7 @ PointDefTurretPack] = 0;

        $TeamItemCount[0 @ DepRockTurretPack] = 0;
        $TeamItemCount[1 @ DepRockTurretPack] = 0;
        $TeamItemCount[2 @ DepRockTurretPack] = 0;
        $TeamItemCount[3 @ DepRockTurretPack] = 0;
        $TeamItemCount[4 @ DepRockTurretPack] = 0;
        $TeamItemCount[5 @ DepRockTurretPack] = 0;
        $TeamItemCount[6 @ DepRockTurretPack] = 0;
        $TeamItemCount[7 @ DepRockTurretPack] = 0;

        $TeamItemCount[0 @ DepHoloRockPack] = 0;
        $TeamItemCount[1 @ DepHoloRockPack] = 0;
        $TeamItemCount[2 @ DepHoloRockPack] = 0;
        $TeamItemCount[3 @ DepHoloRockPack] = 0;
        $TeamItemCount[4 @ DepHoloRockPack] = 0;
        $TeamItemCount[5 @ DepHoloRockPack] = 0;
        $TeamItemCount[6 @ DepHoloRockPack] = 0;
        $TeamItemCount[7 @ DepHoloRockPack] = 0;

        $TeamItemCount[0 @ ChainPack] = 0;
        $TeamItemCount[1 @ ChainPack] = 0;
        $TeamItemCount[2 @ ChainPack] = 0;
        $TeamItemCount[3 @ ChainPack] = 0;
        $TeamItemCount[4 @ ChainPack] = 0;
        $TeamItemCount[5 @ ChainPack] = 0;
        $TeamItemCount[6 @ ChainPack] = 0;
        $TeamItemCount[7 @ ChainPack] = 0;

        $TeamItemCount[0 @ LaserPack] = 0;
        $TeamItemCount[1 @ LaserPack] = 0;
        $TeamItemCount[2 @ LaserPack] = 0;
        $TeamItemCount[3 @ LaserPack] = 0;
        $TeamItemCount[4 @ LaserPack] = 0;
        $TeamItemCount[5 @ LaserPack] = 0;
        $TeamItemCount[6 @ LaserPack] = 0;
        $TeamItemCount[7 @ LaserPack] = 0;

        $TeamItemCount[0 @ MortTurretPack] = 0;
        $TeamItemCount[1 @ MortTurretPack] = 0;
        $TeamItemCount[2 @ MortTurretPack] = 0;
        $TeamItemCount[3 @ MortTurretPack] = 0;
        $TeamItemCount[4 @ MortTurretPack] = 0;
        $TeamItemCount[5 @ MortTurretPack] = 0;
        $TeamItemCount[6 @ MortTurretPack] = 0;
        $TeamItemCount[7 @ MortTurretPack] = 0;

        $TeamItemCount[0 @ CIWSTurretPack] = 0;
        $TeamItemCount[1 @ CIWSTurretPack] = 0;
        $TeamItemCount[2 @ CIWSTurretPack] = 0;
        $TeamItemCount[3 @ CIWSTurretPack] = 0;
        $TeamItemCount[4 @ CIWSTurretPack] = 0;
        $TeamItemCount[5 @ CIWSTurretPack] = 0;
        $TeamItemCount[6 @ CIWSTurretPack] = 0;
        $TeamItemCount[7 @ CIWSTurretPack] = 0;

        $TeamItemCount[0 @ DeployableFieldPack] = 0;
        $TeamItemCount[1 @ DeployableFieldPack] = 0;
        $TeamItemCount[2 @ DeployableFieldPack] = 0;
        $TeamItemCount[3 @ DeployableFieldPack] = 0;
        $TeamItemCount[4 @ DeployableFieldPack] = 0;
        $TeamItemCount[5 @ DeployableFieldPack] = 0;
        $TeamItemCount[6 @ DeployableFieldPack] = 0;
        $TeamItemCount[7 @ DeployableFieldPack] = 0;

        $TeamItemCount[0 @ ForceFieldPack] = 0;
        $TeamItemCount[1 @ ForceFieldPack] = 0;
        $TeamItemCount[2 @ ForceFieldPack] = 0;
        $TeamItemCount[3 @ ForceFieldPack] = 0;
        $TeamItemCount[4 @ ForceFieldPack] = 0;
        $TeamItemCount[5 @ ForceFieldPack] = 0;
        $TeamItemCount[6 @ ForceFieldPack] = 0;
        $TeamItemCount[7 @ ForceFieldPack] = 0;

        $TeamItemCount[0 @ LargeForceFieldPack] = 0;
        $TeamItemCount[1 @ LargeForceFieldPack] = 0;
        $TeamItemCount[2 @ LargeForceFieldPack] = 0;
        $TeamItemCount[3 @ LargeForceFieldPack] = 0;
        $TeamItemCount[4 @ LargeForceFieldPack] = 0;
        $TeamItemCount[5 @ LargeForceFieldPack] = 0;
        $TeamItemCount[6 @ LargeForceFieldPack] = 0;
        $TeamItemCount[7 @ LargeForceFieldPack] = 0;

        $TeamItemCount[0 @ BlastWallPack] = 0;
        $TeamItemCount[1 @ BlastWallPack] = 0;
        $TeamItemCount[2 @ BlastWallPack] = 0;
        $TeamItemCount[3 @ BlastWallPack] = 0;
        $TeamItemCount[4 @ BlastWallPack] = 0;
        $TeamItemCount[5 @ BlastWallPack] = 0;
        $TeamItemCount[6 @ BlastWallPack] = 0;
        $TeamItemCount[7 @ BlastWallPack] = 0;

        $TeamItemCount[0 @ SpringPack] = 0;
        $TeamItemCount[1 @ SpringPack] = 0;
        $TeamItemCount[2 @ SpringPack] = 0;
        $TeamItemCount[3 @ SpringPack] = 0;
        $TeamItemCount[4 @ SpringPack] = 0;
        $TeamItemCount[5 @ SpringPack] = 0;
        $TeamItemCount[6 @ SpringPack] = 0;
        $TeamItemCount[7 @ SpringPack] = 0;

        $TeamItemCount[0 @ PlatformPack] = 0;
        $TeamItemCount[1 @ PlatformPack] = 0;
        $TeamItemCount[2 @ PlatformPack] = 0;
        $TeamItemCount[3 @ PlatformPack] = 0;
        $TeamItemCount[4 @ PlatformPack] = 0;
        $TeamItemCount[5 @ PlatformPack] = 0;
        $TeamItemCount[6 @ PlatformPack] = 0;
        $TeamItemCount[7 @ PlatformPack] = 0;

        $TeamItemCount[0 @ TeleportPack] = 0;
        $TeamItemCount[1 @ TeleportPack] = 0;
        $TeamItemCount[2 @ TeleportPack] = 0;
        $TeamItemCount[3 @ TeleportPack] = 0;
        $TeamItemCount[4 @ TeleportPack] = 0;
        $TeamItemCount[5 @ TeleportPack] = 0;
        $TeamItemCount[6 @ TeleportPack] = 0;
        $TeamItemCount[7 @ TeleportPack] = 0;

        $TeamItemCount[0 @ TreePack] = 0;
        $TeamItemCount[1 @ TreePack] = 0;
        $TeamItemCount[2 @ TreePack] = 0;
        $TeamItemCount[3 @ TreePack] = 0;
        $TeamItemCount[4 @ TreePack] = 0;
        $TeamItemCount[5 @ TreePack] = 0;
        $TeamItemCount[6 @ TreePack] = 0;
        $TeamItemCount[7 @ TreePack] = 0;

        $TeamItemCount[0 @ OpticPack] = 0;
        $TeamItemCount[1 @ OpticPack] = 0;
        $TeamItemCount[2 @ OpticPack] = 0;
        $TeamItemCount[3 @ OpticPack] = 0;
        $TeamItemCount[4 @ OpticPack] = 0;
        $TeamItemCount[5 @ OpticPack] = 0;
        $TeamItemCount[6 @ OpticPack] = 0;
        $TeamItemCount[7 @ OpticPack] = 0;

        $TeamItemCount[0 @ InterceptorPack] = 0;
        $TeamItemCount[1 @ InterceptorPack] = 0;
        $TeamItemCount[2 @ InterceptorPack] = 0;
        $TeamItemCount[3 @ InterceptorPack] = 0;
        $TeamItemCount[4 @ InterceptorPack] = 0;
        $TeamItemCount[5 @ InterceptorPack] = 0;
        $TeamItemCount[6 @ InterceptorPack] = 0;
        $TeamItemCount[7 @ InterceptorPack] = 0;

        $TeamItemCount[0 @ SRMPack] = 0;
        $TeamItemCount[1 @ SRMPack] = 0;
        $TeamItemCount[2 @ SRMPack] = 0;
        $TeamItemCount[3 @ SRMPack] = 0;
        $TeamItemCount[4 @ SRMPack] = 0;
        $TeamItemCount[5 @ SRMPack] = 0;
        $TeamItemCount[6 @ SRMPack] = 0;
        $TeamItemCount[7 @ SRMPack] = 0;

        $TeamItemCount[0 @ Laptop] = 0;
        $TeamItemCount[1 @ Laptop] = 0;
        $TeamItemCount[2 @ Laptop] = 0;
        $TeamItemCount[3 @ Laptop] = 0;
        $TeamItemCount[4 @ Laptop] = 0;
        $TeamItemCount[5 @ Laptop] = 0;
        $TeamItemCount[6 @ Laptop] = 0;
        $TeamItemCount[7 @ Laptop] = 0;

        $TeamItemCount[0 @ SuicidePack] = 0;
        $TeamItemCount[1 @ SuicidePack] = 0;
        $TeamItemCount[2 @ SuicidePack] = 0;
        $TeamItemCount[3 @ SuicidePack] = 0;
        $TeamItemCount[4 @ SuicidePack] = 0;
        $TeamItemCount[5 @ SuicidePack] = 0;
        $TeamItemCount[6 @ SuicidePack] = 0;
        $TeamItemCount[7 @ SuicidePack] = 0;

        $TeamItemCount[0 @ HoloPack] = 0;
        $TeamItemCount[1 @ HoloPack] = 0;
        $TeamItemCount[2 @ HoloPack] = 0;
        $TeamItemCount[3 @ HoloPack] = 0;
        $TeamItemCount[4 @ HoloPack] = 0;
        $TeamItemCount[5 @ HoloPack] = 0;
        $TeamItemCount[6 @ HoloPack] = 0;
        $TeamItemCount[7 @ HoloPack] = 0;

        $TeamItemCount[0 @ HPCPack] = 0;
        $TeamItemCount[1 @ HPCPack] = 0;
        $TeamItemCount[2 @ HPCPack] = 0;
        $TeamItemCount[3 @ HPCPack] = 0;
        $TeamItemCount[4 @ HPCPack] = 0;
        $TeamItemCount[5 @ HPCPack] = 0;
        $TeamItemCount[6 @ HPCPack] = 0;
        $TeamItemCount[7 @ HPCPack] = 0;

        $TeamItemCount[0 @ LightningPack] = 0;
        $TeamItemCount[1 @ LightningPack] = 0;
        $TeamItemCount[2 @ LightningPack] = 0;
        $TeamItemCount[3 @ LightningPack] = 0;
        $TeamItemCount[4 @ LightningPack] = 0;
        $TeamItemCount[5 @ LightningPack] = 0;
        $TeamItemCount[6 @ LightningPack] = 0;
        $TeamItemCount[7 @ LightningPack] = 0;

        $TeamItemCount[0 @ CloakingDevice] = 0;
        $TeamItemCount[1 @ CloakingDevice] = 0;
        $TeamItemCount[2 @ CloakingDevice] = 0;
        $TeamItemCount[3 @ CloakingDevice] = 0;
        $TeamItemCount[4 @ CloakingDevice] = 0;
        $TeamItemCount[5 @ CloakingDevice] = 0;
        $TeamItemCount[6 @ CloakingDevice] = 0;
        $TeamItemCount[7 @ CloakingDevice] = 0;

        $TeamItemCount[0 @ StealthShieldPack] = 0;
        $TeamItemCount[1 @ StealthShieldPack] = 0;
        $TeamItemCount[2 @ StealthShieldPack] = 0;
        $TeamItemCount[3 @ StealthShieldPack] = 0;
        $TeamItemCount[4 @ StealthShieldPack] = 0;
        $TeamItemCount[5 @ StealthShieldPack] = 0;
        $TeamItemCount[6 @ StealthShieldPack] = 0;
        $TeamItemCount[7 @ StealthShieldPack] = 0;

        $TeamItemCount[0 @ SPCVehicle] = 0;
        $TeamItemCount[1 @ SPCVehicle] = 0;
        $TeamItemCount[2 @ SPCVehicle] = 0;
        $TeamItemCount[3 @ SPCVehicle] = 0;
        $TeamItemCount[4 @ SPCVehicle] = 0;
        $TeamItemCount[5 @ SPCVehicle] = 0;
        $TeamItemCount[6 @ SPCVehicle] = 0;
        $TeamItemCount[7 @ SPCVehicle] = 0;

        $TeamItemCount[0 @ InterceptVehicle] = 0;
        $TeamItemCount[1 @ InterceptVehicle] = 0;
        $TeamItemCount[2 @ InterceptVehicle] = 0;
        $TeamItemCount[3 @ InterceptVehicle] = 0;
        $TeamItemCount[4 @ InterceptVehicle] = 0;
        $TeamItemCount[5 @ InterceptVehicle] = 0;
        $TeamItemCount[6 @ InterceptVehicle] = 0;
        $TeamItemCount[7 @ InterceptVehicle] = 0;

        $TeamItemCount[0 @ EMPTurretPack] = 0;
        $TeamItemCount[1 @ EMPTurretPack] = 0;
        $TeamItemCount[2 @ EMPTurretPack] = 0;
        $TeamItemCount[3 @ EMPTurretPack] = 0;
        $TeamItemCount[4 @ EMPTurretPack] = 0;
        $TeamItemCount[5 @ EMPTurretPack] = 0;
        $TeamItemCount[6 @ EMPTurretPack] = 0;
        $TeamItemCount[7 @ EMPTurretPack] = 0;

        $TeamItemCount[0 @ DeployableMini] = 0;
        $TeamItemCount[1 @ DeployableMini] = 0;
        $TeamItemCount[2 @ DeployableMini] = 0;
        $TeamItemCount[3 @ DeployableMini] = 0;
        $TeamItemCount[4 @ DeployableMini] = 0;
        $TeamItemCount[5 @ DeployableMini] = 0;
        $TeamItemCount[6 @ DeployableMini] = 0;
        $TeamItemCount[7 @ DeployableMini] = 0;



        for(%i = -1; %i < 8 ; %i++)
                $TeamEnergy[%i] = $DefaultTeamEnergy;
}