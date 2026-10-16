//----------------------------------------------------------------------------
$ItemFavoritesKey = "Ultra_Renegades4";
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
$AutoUse[PlasmaRifle] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = false;
$AutoUse[SniperRifle] = True;
$AutoUse[TranqGun] = True;
$AutoUse[Railgun] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[ChargeGun] = False;
$AutoUse[Shotgun] = True;
$AutoUse[CloakGun] = True;

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
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 50;
$SellAmmo[DiscAmmo] = 199;
$SellAmmo[GrenadeAmmo] = 50;
$SellAmmo[PlasmaRifleAmmo] = 500;
$SellAmmo[MortarAmmo] = 50;
$SellAmmo[FFBAmmo] = 10;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[AirBrake] = 5;
$SellAmmo[RifleAmmo] = 500;
$SellAmmo[TranqAmmo] = 500;
$SellAmmo[RailAmmo] = 250;
$SellAmmo[ShotgunShells] = 50;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 199;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[PlasmaRifleAmmo] = 666;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[FFBAmmo] = 0;
$AmmoPackMax[Beacon] = 10;
$AmmoPackMax[RifleAmmo] = 500;
$AmmoPackMax[TranqAmmo] = 500;
$AmmoPackMax[RailAmmo] = 50;
$AmmoPackMax[ShotgunShells] = 50;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = PlasmaRifleAmmo;
$AmmoPackItems[5] = MortarAmmo;
$AmmoPackItems[6] = Beacon;
$AmmoPackItems[7] = RifleAmmo;
$AmmoPackItems[8] = TranqAmmo;
$AmmoPackItems[9] = RailAmmo;
$AmmoPackItems[10] = ShotgunShells;
$AmmoPackItems[11] = FFBAmmo;

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[ForceFieldPack]= 12;
$TeamItemMax[LargeFieldPack] = 4;
$TeamItemMax[RocketPack] = 4;
$TeamItemMax[TurretPack] = 8;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 10;
$TeamItemMax[JetVehicle] = 10;
$TeamItemMax[Jet2Vehicle] = 10;
$TeamItemMax[WraithVehicle] = 10;
$TeamItemMax[HAPCVehicle] = 10;
$TeamItemMax[LAPCVehicle] = 10;
$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;

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
$WeaponAmmo[PlasmaRifle] = PlasmaRifleAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[SniperRifle] = RifleAmmo;
$WeaponAmmo[TranqGun] = TranqAmmo;
$WeaponAmmo[Railgun] = RailAmmo;
$WeaponAmmo[FFBLauncher] = FFBAmmo;
$WeaponAmmo[Shotgun] = ShotgunShells;
$WeaponAmmo[CloakGun] = ""; 

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


function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
        %station = (Client::getOwnedObject(%client)).Station;
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
                if (%item.className == Armor) {
                        // Assign armor by requested type & gender
                        %buyarmor = $ArmorType[Client::getGender(%client), %item];
                        if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)        {
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
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
		//if(GameBase::getControlClient(%player) != -1) {
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
$NextWeapon[Railgun] = Blaster;
$NextWeapon[Blaster] = Shotgun;
$NextWeapon[Shotgun] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = SniperRifle;
$NextWeapon[SniperRifle] = TranqGun;
$NextWeapon[TranqGun] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = PlasmaRifle;
$NextWeapon[PlasmaRifle] = CloakGun;
$NextWeapon[CloakGun] = FFBLauncher;
$NextWeapon[FFBLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = EMPRocketLauncher; 
$NextWeapon[EMPRocketLauncher] = EMPGrenadeLauncher;
$NextWeapon[EMPGrenadeLauncher] = EnergyRifle;
$NextWeapon[EnergyRifle] = Railgun;

$PrevWeapon[Blaster] = Railgun;
$PrevWeapon[Shotgun] = Blaster;
$PrevWeapon[PlasmaGun] = Shotgun;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[SniperRifle] = DiscLauncher;
$PrevWeapon[CloakGun] = SniperRifle;
$PrevWeapon[TranqGun] = CloakGun;
$PrevWeapon[PlasmaRifle] = TranqGun;
$PrevWeapon[GrenadeLauncher] = PlasmaRifle;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[FFBLauncher] = Mortar;
$PrevWeapon[LaserRifle] = FFBLauncher;
$PrevWeapon[EMPRocketLauncher] = LaserRifle; 
$PrevWeapon[EMPGrenadeLauncher] = EMPRocketLauncher;
$PrevWeapon[EnergyRifle] = EMPGrenadeLauncher;
$PrevWeapon[Railgun] = EnergyRifle;

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
                                // Make sure it mounted (laser may not)
                                if (Player::getMountedItem(%client,$WeaponSlot) == %weapon)
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
                                // Make sure it mounted (laser may not)
                                if (Player::getMountedItem(%client,$WeaponSlot) == %weapon)
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
                if (!%ammo || Player::getItemCount(%client,%ammo) > 0)
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
                                Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item);
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
validateShape = true;

        lightType = 2;   // Pulsing
        lightRadius = 4;
        lightTime = 1.5;
        lightColor = { 1, 1, 1 };
};


//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData LightArmor
{
   heading = "aArmor";
        description = "Light Armor";
        className = "Armor";
        price = 175;
};

ItemData MediumArmor
{
   heading = "aArmor";
        description = "Medium Armor";
        className = "Armor";
        price = 250;
};

ItemData HeavyArmor
{
   heading = "aArmor";
        description = "Heavy Armor";
        className = "Armor";
        price = 400;
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

ItemData JetVehicle
{
        description = "Avenger";
        className = "Vehicle";
   heading = "aVehicle";
        price = 600;
};

ItemData Jet2Vehicle
{
        description = "EMP Bomber";
        className = "Vehicle";
   heading = "aVehicle";
        price = 600;
};

ItemData WraithVehicle
{
        description = "Wraith";
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


//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

ItemData Weapon
{
        description = "Weapon";
        showInventory = false;
};

function Weapon::onUse(%player,%item)
{
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
        mountRotation = { 0, 4.5, 0 };
        weaponType = 0; // Single Shot
        reloadTime = 0;
        fireTime = 0.001;
        minEnergy = 0;
        maxEnergy = 0;

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

function Blaster::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Ghetto Blaster.", 3);
}
//----------------------------------------------------------------------------

ItemData BulletAmmo
{
        description = "ChainGun Ammo";
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
	projectileType = LeaveThisAlone;
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
        description = "ChainGun";
        className = "Weapon";
        shapeFile = "chaingun";
        hudIcon = "chain";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = ChaingunImage;
        price = 125;
        showWeaponBar = true;
};

function ChaingunImage::onFire(%player, %slot) 
{
   %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Chaingun]);
   if(%AmmoCount) 
      { 
	   Player::decItemCount(%player,$WeaponAmmo[Chaingun],1); 
	   %trans = GameBase::getMuzzleTransform(%player); 
	   %vel = Item::getVelocity(%player);
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
 	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
	   	Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel); 
	} 
   else Client::sendMessage(Player::getClient(%player), 0,"Chaingun has no Ammo."); 
}

function Chaingun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Chain Gun.", 3);
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
        reloadTime = 0.05;
        fireTime = 0.05;

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

function PlasmaGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Plasma Gun", 3);
}
//----------------------------------------------------------------------------

ItemData GrenadeAmmo
{
        description = "GrenadeAmmo";
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
        reloadTime = 0.05;
        fireTime = 0.05;

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

function GrenadeLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Grenade Launcher", 3);
}
//-------------------------------------------------
ItemData PlasmaRifleAmmo
{
        description = "PlasmaRifleAmmo";
        className = "Ammo";
        shapeFile = "grenammo";
   heading = "xAmmunition";
        shadowDetailMask = 4;
        price = 2;
};

ItemImageData PlasmaRifleImage
{
        shapeFile = "grenadeL";
        mountPoint = 0;   
        mountRotation = { 0, 3, 0 };
        weaponType = 0; // Single Shot
        ammoType = PlasmaRifleAmmo;
        projectileType = FusionBolt;
        accuFire = True;
        reloadTime = 0.01;
        fireTime = 0.05;

        lightType = 3;  // Weapon Fire
        lightRadius = 1;
        lightTime = 0.1;
        lightColor = { 1, 1, 1 };

        sfxFire = SoundFirePlasma;
        sfxActivate = SoundGeneratorPower;
};

ItemData PlasmaRifle
{
        description = "Plasma Rifle";
        className = "Weapon";
        shapeFile = "grenadeL";
        hudIcon = "energyRifle";
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = PlasmaRifleImage;
        price = 300;
        showWeaponBar = true;
};

function PlasmaRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Plasma Rifle.", 3);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
ItemData ShotgunShells { description = "Shotgun Shells"; className = "Ammo"; shapeFile = "ammo2"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; };

ItemImageData ShotgunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; ammoType = ShotgunShells; projectileType = ThisShouldBeUndefined; reloadTime = 0.5; accuFire = false; fireTime = 0.01; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; };

 ItemData Shotgun { heading = "bWeapons"; description = "Shotgun"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "ammopack"; shadowDetailMask = 4; imageType = ShotgunImage; price = 85; showWeaponBar = true; }; function ShotgunImage::onFire(%player, %slot) { %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]); if(%AmmoCount) { Player::decItemCount(%player,$WeaponAmmo[Shotgun],1); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player);
Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel); } else Client::sendMessage(Player::getClient(%player), 0,"You Ran Out Of Ammo for the Shotgun"); }

function Shotgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Shot Gun.", 3);
}

//----------------------------------------------------------------------------

ItemData MortarAmmo
{
        description = "MortarAmmo";
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
        reloadTime = 0.05;
        fireTime = 0.05;

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

function Mortar::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Mortar.", 3);
}

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
        reloadTime = 0.05;
        fireTime = 0.05;
        spinUpTime = 0.05;

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

function DiscLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Disc Launcher.", 3);
}

ItemImageData LaserRifleImage
{
        shapeFile = "sniper";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        projectileType = SniperLaser;
        accuFire = true;
        reloadTime = 0.05;
        fireTime = 0.05;
        minEnergy = 1;
        maxEnergy = 6;

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
   heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = LaserRifleImage;
        price = 200;
        showWeaponBar = true;
};

function LaserRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Laser Rifle.", 3);

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
function TargetingLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Targeting Laser.", 3);
}

//------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
        shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
        projectileType = lightningCharge;
   minEnergy = 1;
   maxEnergy = 1;  // Energy used/sec for sustained weapons
        reloadTime = 0.02;

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
   price = 500;
};

function EnergyRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding ELF Gun.", 3);
}
//----------------------------------------------------------------------------

ItemData RifleAmmo { description = "Rifle Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 5; };

//----------------------------------------------------------------------------

ItemImageData SniperRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = RifleAmmo; projectileType = RifleBullet; accuFire = true; reloadTime = 0.01; fireTime = 0.01; lightType = 3; lightRadius = 6; lightTime = 1; lightColor = { 1, 1, 1 }; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; sfxReady = SoundDryFire; };

ItemData SniperRifle { description = "IX-2000 Sniper Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "sniper"; heading = "bWeapons"; shadowDetailMask = 4; imageType = SniperRifleImage; price = 300; showWeaponBar = true; };

function SniperRifle::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding IX-2000 Sniper Rifle.", 3);
}

//----------------------------------------------------------------------------

ItemData TranqAmmo { description = "Poison Dart"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; ItemImageData TranqGunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = TranqAmmo; projectileType = TranqDart; accuFire = true; reloadTime = 0.05; fireTime = 0; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 1.0, 0, 0 }; sfxFire = SoundFireChainGun; sfxActivate = SoundPickUpWeapon; };

//----------------------------------------------------------------------------

ItemData TranqGun { description = "FEB Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "blaster"; heading = "bWeapons"; shadowDetailMask = 4; imageType = TranqGunImage; price = 475; showWeaponBar = true; };

function TranqGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding FEB Rifle.", 3);
}

//----------------------------------------------------------------------------
ItemData RailAmmo { description = "Railgun Bolt"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; };

ItemImageData RailgunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = RailAmmo; projectileType = RailRound; accuFire = true; reloadTime = 0.05; fireTime = 0.05; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 1.0, 0, 0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; };

//----------------------------------------------------------------------------

ItemData Railgun { description = "Railgun"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bWeapons"; shadowDetailMask = 4; imageType = RailgunImage; price = 375; showWeaponBar = true; };

function Railgun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Rail Gun.", 3);
}


//----------------------------------------------------------------------------

ItemData FFBAmmo { description = "FFB Ammo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "grenammo"; shadowDetailMask = 4; price = 50; }; ItemImageData FFBImage { shapeFile = "mortargun"; mountPoint = 0;   mountRotation = { 0, 3, 0 }; weaponType = 0; ammoType = FFBAmmo; projectileType = FFBShell; accuFire = false; reloadTime = 2; fireTime = 0; lightType = 3; lightRadius = 4; lightTime = 1; lightColor = { 0, 0, 1 }; sfxFire = SoundFireGrenade; sfxActivate = SoundPickUpWeapon; sfxReady = SoundMortarIdle; };

//----------------------------------------------------------------------------

ItemData FFBLauncher { description = "Force Field Buster"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "plasma"; heading = "bWeapons"; shadowDetailMask = 4; imageType = FFBImage; price = 475; showWeaponBar = true;    validateShape = false; };

function FFBLauncher::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Force Field Buster.", 3);
}
//----------------------------------------------------------------------------


//----------------------------------------------------------------------------

ItemData EMPGrenadeAmmo { description = "EMPGrenadeAmmo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "mortarammo"; shadowDetailMask = 4; price = 50; }; ItemImageData EMPGrenadeLauncherImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = EMPGrenadeAmmo; projectileType = EMPGrenadeShell; accuFire = false; reloadTime = 0.1; fireTime = 0.1; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.25, 0.25, 1.0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundLaserIdle; };

//----------------------------------------------------------------------------

ItemData EMPGrenadeLauncher { description = "EMP Grenade Launcher"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "sensorjamerpack"; heading = "bWeapons"; shadowDetailMask = 4; imageType = EMPGrenadeLauncherImage; price = 475; showWeaponBar = true; };

//----------------------------------------------------------------------------

ItemData EMPRocketAmmo { description = "EMP Rockets"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "rocket"; shadowDetailMask = 4; price = 50; }; 

ItemImageData EMPRocketImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = EMPRocketAmmo; projectileType = EMPRocket; accuFire = true; reloadTime = 0.5; fireTime = 0.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundLaserIdle;  };

 ItemData EMPRocketLauncher { description = "EMP Rocket Launcher"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "sensorjamerpack"; heading = "bWeapons"; shadowDetailMask = 4; imageType = EMPRocketImage; price = 375; showWeaponBar = true; }; 

//----------------------------------------------------------------------------

ItemImageData CloakGunImage
{
   shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   projectileType = cloakingCharge;
   minEnergy = 3;
   maxEnergy = 3;  // Energy used/sec for sustained weapons
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

function CloakGun::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc><f2>Now holding Cloaking Gun.", 2);
}

//----------------------------------------------------------------------------

ItemImageData RepairGunImage
{
        shapeFile = "repairgun";
        mountPoint = 0;

        weaponType = 2;  // Sustained
        projectileType = RepairBolt;
        minEnergy  = 1;
        maxEnergy = 1;  // Energy used/sec for sustained weapons

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

ItemImageData ForceFieldPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ForceFieldPack
{	
	description = "Small Force Field";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "kForce Fields";
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 300;
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
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						// if player is within 30 yards of flag cannot deploy
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = gamebase::getPosition(%flag);
						echo("%flagpos " @ %flagpos);
						echo("%playerpos " @ %playerpos);
						if(Vector::getDistance(%flagpos, %playerpos) > 3)
						{
							%inv = newObject("Small Force Field","StaticShape","SmallForceField",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"Small Force Field  deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "ForceFieldPack"]++;
							echo("MSG: ",%client," deployed a Small Force Fieldl");
							return true;
						}
						else
							Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag.");
							return false;
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

// ****

ItemImageData LargeFieldPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LargeFieldPack
{	
	description = "Large Force Field";
	shapefile = "ammopack";
	classname = "Backpack";
	heading = "kForce Fields";
	imageType = LargeFieldPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.1;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeFieldPack::onUse(%player,%item)
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

function LargeFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeFieldPack::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}

function LargeFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
		if (GameBase::getLOSInfo(%player,3)) 
		{	
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") 
			{
					if (Vector::dot($los::normal,"0 0 1") > 0.7) 
					{
						// if player is within 30 yards of flag cannot deploy
						%playerPos = GameBase::getPosition(%player);
						%flag = $teamFlag[GameBase::getTeam(%player)];
						%flagpos = gamebase::getPosition(%flag);
						echo("%flagpos " @ %flagpos);
						echo("%playerpos " @ %playerpos);
						if(Vector::getDistance(%flagpos, %playerpos) > 5)
						{
							%inv = newObject("Large Force Field","StaticShape","LargeForceField",true);
	         	   				addToSet("MissionCleanup", %inv);
							%rot = GameBase::getRotation(%player); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							GameBase::setPosition(%inv,$los::position);
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,%name);
							Client::sendMessage(%client,0,"Large Force Field  deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%inv) @ "LargeFieldPack"]++;
							echo("MSG: ",%client," deployed a Large Force Fieldl");
							return true;
						}
						else
							Client::sendMessage(%client,0,"You are too close to your flag, cant hide the flag.");
							return false;
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
        minEnergy = 1;
        maxEnergy = 7;   // Energy/sec for sustained weapons
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
        Client::sendMessage(Player::getClient(%player),0,"Shield Activated");
        %player.shieldStrength = 0.038;
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
        Client::sendMessage(Player::getClient(%player),0,"Shield De-activated");
        Player::trigger(%player,$BackpackSlot,false);
        %player.shieldStrength = 0;
}


//----------------------------------------------------------------------------

ItemImageData SensorJammerPackImage
{
        shapeFile = "sensorjampack";
        mountPoint = 2;
        weaponType = 2;  // Sustained
        maxEnergy = 1;  // Energy used/sec for sustained weapons
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
// Cloaking Device - 
//----------------------------------------------------------------------------

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0.9, 6, 4 };
	firstPerson = false;
};

ItemData CloakingDevice
{
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

//-----------------------------------------------

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

//        if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) {
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
                for(%i = 0; %i < 8 ; %i = %i +1) {
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
                        else if(%i == 7) {
                             %item.EMPGrenadeAmmo = %numPack;
                        }
                        else if(%i == 8) {
                             %item.EMPRocketAmmo = %numPack;
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
        for(%i = 0; %i < 9 ; %i = %i +1) {
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
            %numpack = %item.EMPGrenadeAmmo;
            }
            else if(%i == 8) {
            %numpack = %item.EMPRocketAmmo;
            }

            else if(%i == 9) {
            %numpack = %item.ShotgunAmmo;
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
        for(%i = 0; %i < 9 ; %i = %i +1) {
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

//turrets

//Mini-Plasma
//----------------------------------------------------------------------------
ItemImageData TurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 3.0;
        firstPerson = false;
};

ItemData TurretPack
{
        description = "Mini-Plasma Turret";
        shapeFile = "remoteturret";
        className = "Backpack";
      heading = "LTurrets";
        imageType = TurretPackImage;
        shadowDetailMask = 4;
        mass = 2.0;
        elasticity = 0.2;
        price = 500;
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
				%num = CountObjects(%set,"DeployableMiniPlasma",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
							    %playerPos = GameBase::getPosition(%player);
							    %flag = $teamFlag[GameBase::getTeam(%player)];
							    %flagpos = %flag.originalposition;
							    if(Vector::getDistance(%flagpos, %playerpos) < 200)
							    {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Mini-Plasma Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Mini-Plasma Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Mini-Plasma Turret");
								//	Remote turrets - kill points to player that deploy them
								Client::setOwnedObject(%client, %turret); 
								Client::setOwnedObject(%client, %player);
								return true;
							    }	
							    else
							    {
							          Client::sendMessage(%client,1,"You may only deploy this near your base.~wmale3.wno.wav");
								    return false;
							    }
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
//----------------------------------------------------------------------------
//------------------------------------------------------------------------------------
//------------------DeployableRocket----------------Rocket Turret---------------------
//------------------------------------------------------------------------------------
//------------------------------------------------------------------------------------
						
ItemImageData RocketPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData RocketPack
{
	description = "Rocket Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "LTurrets";
	imageType = RocketPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function RocketPack::onDeploy(%player,%item,%pos)
{
	if (RocketPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function RocketPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {

	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
							    %playerPos = GameBase::getPosition(%player);
							    %flag = $teamFlag[GameBase::getTeam(%player)];
							    %flagpos = %flag.originalposition;
							    if(Vector::getDistance(%flagpos, %playerpos) < 175)
							    {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableRocket,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Rocket#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Rocket Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
								return true;
							    }	
							    else
							    {
							          Client::sendMessage(%client,1,"You may only deploy this near your base.~wmale3.wno.wav");
								    return false;
							    }
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
        GameBase::repairDamage(%player,0.99);
}


//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 10;
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
                  GameBase::setTeam (%obj,GameBase::getTeam (%client));

                }
        }
}


//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = false;
   validateMaterials = false;
};

function Grenade::onUse(%player,%item)
{
	Item::setvelocity(%player,0);
      client::sendmessage(player::getclient(%player),0,"Speed Brick applied.");
	Player::decItemCount(%player,%item);
}


//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
        className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
      %player.boostvel = vector::add(Item::getvelocity(%player),Item::getvelocity(%player));
      if(getword(%player.boostvel,0)>-600&&getword(%player.boostvel,0)<600&&getword(%player.boostvel,1)>-600&&getword(%player.boostvel,1)<600&&getword(%player.boostvel,2)>-600&&getword(%player.boostvel,2)<600)
	{
      	Item::setvelocity(%player,%player.boostvel);
      	client::sendmessage(player::getclient(%player),0,"Speed Boost applied.");
		Player::decItemCount(%player,%item);
	}
}

//----------------------------------------------------------------------------
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
                        GameBase::repairDamage(%object,0.99);
                        %item = Item::getItemData(%this);
                        Item::playPickupSound(%this);
                        Item::respawn(%this);
                }
        }
}

function RepairPatch::onUse(%player,%item)
{
        Player::decItemCount(%player,%item);
        GameBase::repairDamage(%player,0.9);
}


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
                Player::setItemCount(%clientId,SniperRifle,1);
                Player::setItemCount(%clientId,TargetingLaser,1);
                Player::setItemCount(%clientId,Mortar,1);

                Player::setItemCount(%clientId,BulletAmmo,200);
                Player::setItemCount(%clientId,PlasmaAmmo,200);
                Player::setItemCount(%clientId,GrenadeAmmo,200);
                Player::setItemCount(%clientId,RifleAmmo,200);
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
        $TeamItemCount[0 @ RocketPack] = 0;
        $TeamItemCount[0 @ CameraPack] = 0;
        $TeamItemCount[0 @ DeployableSensorJammerPack] = 0;
        $TeamItemCount[0 @ PulseSensorPack] = 0;
        $TeamItemCount[0 @ MotionSensorPack] = 0;
        $TeamItemCount[0 @ ScoutVehicle] = 0;
        $TeamItemCount[0 @ JetVehicle] = 0;
        $TeamItemCount[0 @ Jet2Vehicle] = 0;
        $TeamItemCount[0 @ WraithVehicle] = 0;
        $TeamItemCount[0 @ LAPCVehicle] = 0;
        $TeamItemCount[0 @ HAPCVehicle] = 0;
        $TeamItemCount[0 @ Beacon] = 0;
        $TeamItemCount[0 @ mineammo] = 0;
	  $TeamItemCount[0 @ ForceFieldPack] = 0;
	  $TeamItemCount[0 @ LargeFieldPack] = 0;
        $TeamItemCount[0 @ TurretPack] = 0; 


        $TeamItemCount[1 @ DeployableAmmoPack] = 0;
        $TeamItemCount[1 @ DeployableInvPack] = 0;
        $TeamItemCount[1 @ RocketPack] = 0;
        $TeamItemCount[1 @ CameraPack] = 0;
        $TeamItemCount[1 @ DeployableSensorJammerPack] = 0;
        $TeamItemCount[1 @ PulseSensorPack] = 0;
        $TeamItemCount[1 @ MotionSensorPack] = 0;
        $TeamItemCount[1 @ ScoutVehicle] = 0;
        $TeamItemCount[1 @ JetVehicle] = 0;
        $TeamItemCount[1 @ Jet2Vehicle] = 0;
        $TeamItemCount[1 @ WraithVehicle] = 0;
        $TeamItemCount[1 @ LAPCVehicle] = 0;
        $TeamItemCount[1 @ HAPCVehicle] = 0;
        $TeamItemCount[1 @ Beacon] = 0;
        $TeamItemCount[1 @ mineammo] = 0;
        $TeamItemCount[1 @ ForceFieldPack] = 0;
	  $TeamItemCount[1 @ LargeFieldPack] = 0;
        $TeamItemCount[1 @ TurretPack] = 0; 


        $TeamItemCount[2 @ DeployableAmmoPack] = 0;
        $TeamItemCount[2 @ DeployableInvPack] = 0;
        $TeamItemCount[2 @ RocketPack] = 0;
        $TeamItemCount[2 @ CameraPack] = 0;
        $TeamItemCount[2 @ DeployableSensorJammerPack] = 0;
        $TeamItemCount[2 @ PulseSensorPack] = 0;
        $TeamItemCount[2 @ MotionSensorPack] = 0;
        $TeamItemCount[2 @ ScoutVehicle] = 0;
        $TeamItemCount[2 @ JetVehicle] = 0;
        $TeamItemCount[2 @ Jet2Vehicle] = 0;
        $TeamItemCount[2 @ WraithVehicle] = 0;
        $TeamItemCount[2 @ LAPCVehicle] = 0;
        $TeamItemCount[2 @ HAPCVehicle] = 0;
        $TeamItemCount[2 @ Beacon] = 0;
        $TeamItemCount[2 @ mineammo] = 0;
        $TeamItemCount[2 @ ForceFieldPack] = 0;
	  $TeamItemCount[2 @ LargeFieldPack] = 0;
        $TeamItemCount[2 @ TurretPack] = 0; 


        $TeamItemCount[3 @ DeployableAmmoPack] = 0;
        $TeamItemCount[3 @ DeployableInvPack] = 0;
        $TeamItemCount[3 @ RocketPack] = 0;
        $TeamItemCount[3 @ CameraPack] = 0;
        $TeamItemCount[3 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[3 @ PulseSensorPack] = 0;
        $TeamItemCount[3 @ MotionSensorPack] = 0;
        $TeamItemCount[3 @ ScoutVehicle] = 0;
        $TeamItemCount[3 @ JetVehicle] = 0;
        $TeamItemCount[3 @ Jet2Vehicle] = 0;
        $TeamItemCount[3 @ WraithVehicle] = 0;
        $TeamItemCount[3 @ LAPCVehicle] = 0;
        $TeamItemCount[3 @ HAPCVehicle] = 0;
        $TeamItemCount[3 @ Beacon] = 0;
        $TeamItemCount[3 @ mineammo] = 0;
        $TeamItemCount[3 @ ForceFieldPack] = 0;
	  $TeamItemCount[3 @ LargeFieldPack] = 0;
        $TeamItemCount[3 @ TurretPack] = 0; 


        $TeamItemCount[4 @ DeployableAmmoPack] = 0;
        $TeamItemCount[4 @ DeployableInvPack] = 0;
        $TeamItemCount[4 @ RocketPack] = 0;
        $TeamItemCount[4 @ CameraPack] = 0;
        $TeamItemCount[4 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[4 @ PulseSensorPack] = 0;
        $TeamItemCount[4 @ MotionSensorPack] = 0;
        $TeamItemCount[4 @ ScoutVehicle] = 0;
        $TeamItemCount[4 @ JetVehicle] = 0;
        $TeamItemCount[4 @ Jet2Vehicle] = 0;
        $TeamItemCount[4 @ WraithVehicle] = 0;
        $TeamItemCount[4 @ LAPCVehicle] = 0;
        $TeamItemCount[4 @ HAPCVehicle] = 0;
        $TeamItemCount[4 @ Beacon] = 0;
        $TeamItemCount[4 @ mineammo] = 0;
        $TeamItemCount[4 @ ForceFieldPack] = 0;
	  $TeamItemCount[4 @ LargeFieldPack] = 0;
        $TeamItemCount[4 @ TurretPack] = 0; 


        $TeamItemCount[5 @ DeployableAmmoPack] = 0;
        $TeamItemCount[5 @ DeployableInvPack] = 0;
        $TeamItemCount[5 @ TurretPack] = 0;
        $TeamItemCount[5 @ CameraPack] = 0;
        $TeamItemCount[5 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[5 @ PulseSensorPack] = 0;
        $TeamItemCount[5 @ MotionSensorPack] = 0;
        $TeamItemCount[5 @ ScoutVehicle] = 0;
        $TeamItemCount[5 @ JetVehicle] = 0;
        $TeamItemCount[5 @ Jet2Vehicle] = 0;
        $TeamItemCount[5 @ WraithVehicle] = 0;
        $TeamItemCount[5 @ LAPCVehicle] = 0;
        $TeamItemCount[5 @ HAPCVehicle] = 0;
        $TeamItemCount[5 @ Beacon] = 0;
        $TeamItemCount[5 @ mineammo] = 0;
        $TeamItemCount[5 @ ForceFieldPack] = 0;
	  $TeamItemCount[5 @ LargeFieldPack] = 0;
        $TeamItemCount[5 @ RailTurret] = 0; 


        $TeamItemCount[6 @ DeployableAmmoPack] = 0;
        $TeamItemCount[6 @ DeployableInvPack] = 0;
        $TeamItemCount[6 @ TurretPack] = 0;
        $TeamItemCount[6 @ CameraPack] = 0;
        $TeamItemCount[6 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[6 @ PulseSensorPack] = 0;
        $TeamItemCount[6 @ MotionSensorPack] = 0;
        $TeamItemCount[6 @ ScoutVehicle] = 0;
        $TeamItemCount[6 @ JetVehicle] = 0;
        $TeamItemCount[6 @ Jet2Vehicle] = 0;
        $TeamItemCount[6 @ WraithVehicle] = 0;
        $TeamItemCount[6 @ LAPCVehicle] = 0;
        $TeamItemCount[6 @ HAPCVehicle] = 0;
        $TeamItemCount[6 @ Beacon] = 0;
        $TeamItemCount[6 @ mineammo] = 0;
        $TeamItemCount[6 @ ForceFieldPack] = 0;
	  $TeamItemCount[6 @ LargeFieldPack] = 0;
        $TeamItemCount[6 @ RailTurret] = 0; 


        $TeamItemCount[7 @ DeployableAmmoPack] = 0;
        $TeamItemCount[7 @ DeployableInvPack] = 0;
        $TeamItemCount[7 @ TurretPack] = 0;
        $TeamItemCount[7 @ CameraPack] = 0;
        $TeamItemCount[7 @ DeployableSensorJammerPack]= 0;
        $TeamItemCount[7 @ PulseSensorPack] = 0;
        $TeamItemCount[7 @ MotionSensorPack] = 0;
        $TeamItemCount[7 @ ScoutVehicle] = 0;
        $TeamItemCount[7 @ JetVehicle] = 0;
        $TeamItemCount[7 @ Jet2Vehicle] = 0;
        $TeamItemCount[7 @ WraithVehicle] = 0;
        $TeamItemCount[7 @ LAPCVehicle] = 0;
        $TeamItemCount[7 @ HAPCVehicle] = 0;
        $TeamItemCount[7 @ Beacon] = 0;
        $TeamItemCount[7 @ mineammo] = 0;
        $TeamItemCount[7 @ ForceFieldPack] = 0;
	  $TeamItemCount[7 @ LargeFieldPack] = 0;
        $TeamItemCount[7 @ RailTurret] = 0; 


        $totalNumCameras = 0;
        $totalNumTurrets = 0;

        for(%i = -1; %i < 8 ; %i++)
                $TeamEnergy[%i] = $DefaultTeamEnergy;
}