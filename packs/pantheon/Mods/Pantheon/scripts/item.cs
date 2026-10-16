
//----------------------------------------------------------------------------

$ItemFavoritesKey = "Pantheon";  // Change this if you add new items
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
$AutoUse[EMPGrenadeLauncher] = True;
$AutoUse[LaserRifle] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = False;
$AutoUse[RocketLauncher] = True;
$AutoUse[SniperRifle] = True;
$AutoUse[Railgun] = True;
$AutoUse[FGC] = True;
$AutoUse[Vulcan] = True;
$AutoUse[DeathLaser] = True;

$Use[Blaster] = True;

$NukeTeam[0] = 0;
$NukeTeam[1] = 0;
$NukeTeam[2] = 0;
$NukeTeam[3] = 0;
$NukeTeam[4] = 0;
$NukeTeam[5] = 0;
$NukeTeam[6] = 0;
$NukeTeam[7] = 0;

$ArmorType[Male, ScoutArmor] = sarmor;
$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Male, AssaultArmor] = aarmor;

$ArmorType[Female, ScoutArmor] = fsarmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;	   
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Female, AssaultArmor] = aarmor;

$ArmorName[sarmor] = ScoutArmor;
$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[fsarmor] = ScoutArmor;
$ArmorName[flarmor] = LightArmor;
$ArmorName[fmarmor] = MediumArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[aarmor] = AssaultArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[BulletAmmo] = 25;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[EMPGrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[RocketAmmo] = 5;
$SellAmmo[SniperAmmo] = 25;
$SellAmmo[VulcanAmmo] = 200;
$SellAmmo[FGCAmmo] = 1;
$SellAmmo[RailAmmo] = 5;
$SellAmmo[RocketAmmo] = 5;
$SellAmmo[ShotgunAmmo] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[RailAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[EMPGrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 5;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 3;
$AmmoPackMax[Beacon] = 2;
$AmmoPackMax[RocketAmmo] = 10;
$AmmoPackMax[SniperAmmo] = 10;
$AmmoPackMax[VulcanAmmo] = 100;
$AmmoPackMax[DiscAmmo] = 20;
$AmmoPackMax[ShotgunAmmo] = 10;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MortarAmmo;
$AmmoPackItems[6] = RocketAmmo;
$AmmoPackItems[7] = SniperAmmo;
$AmmoPackItems[8] = RailAmmo;
$AmmoPackItems[9] = EMPGrenadeAmmo;
$AmmoPackItems[10] = VulcanAmmo;
$AmmoPackItems[11] = MineAmmo;
$AmmoPackItems[12] = Beacon;
$AmmoPackItems[13] = ShotgunAmmo;


// Limit on number of special Items you can buy
// (*** change in objectives.cs too ***)

$TeamItemMax[DeployableAmmoPack] = $Pantheon::AmmoStationLimit;
$TeamItemMax[DeployableInvPack] = $Pantheon::InvStationLimit;
$TeamItemMax[DeployableComPack] = $Pantheon::CommandStationLimit;

$TeamItemMax[CameraPack] = $Pantheon::CameraLimit;
$TeamItemMax[ProximityAlarmPack] = $Pantheon::ProximityAlarmLimit;
$TeamItemMax[DeployableSensorJammerPack] = $Pantheon::SensorJammerLimit;
$TeamItemMax[PulseSensorPack] = $Pantheon::PulseSensorLimit;
$TeamItemMax[MotionSensorPack] = $Pantheon::MotionSensorLimit;

$TeamItemMax[Beacon] = $Pantheon::BeaconLimit;
$TeamItemMax[mineammo] = $Pantheon::MineLimit;

$TeamItemMax[ForceFieldPack] = $Pantheon::ForceFieldLimit;
$TeamItemMax[LargeForceFieldPack] = $Pantheon::LargeForceFieldLimit;
$TeamItemMax[ForceFieldDoorPack] = $Pantheon::ForceFieldDoorLimit;

$TeamItemMax[TurretPack] = $Pantheon::IndoorTurretLimit;
$TeamItemMax[LaserPack] = $Pantheon::LaserTurretLimit;
$TeamItemMax[DissectionPack] = $Pantheon::DissectionLimit;
$TeamItemMax[MortarTurretPack] = $Pantheon::MortarTurretLimit;
$TeamItemMax[VulcanPack] = $Pantheon::VulcanTurretLimit;
$TeamItemMax[PlasmaPack] = $Pantheon::PlasmaTurretLimit;
$TeamItemMax[RocketPack] = $Pantheon::MissileTurretLimit;
$TeamItemMax[DumbRocketPack] = $Pantheon::RocketBatteryLimit;
$TeamItemMax[PlasmaTurretDecoyPack] = $Pantheon::PlasmaTurretDecoy;
$TeamItemMax[BlastwallPack] = $Pantheon::BlastWallLimit;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[TeleportPack] = 2;
$TeamItemMax[DeployableTeleportDecoy] = $Pantheon::TeleportDecoyLimit;
$TeamItemMax[TeleportDecoyPack] = $Pantheon::TeleportDecoyLimit;
$TeamItemMax[DeployableSolarPanel] = $Pantheon::SolarPanelLimit;
$TeamItemMax[SniperPadPack] = $Pantheon::SniperPadLimit;
$TeamItemMax[OutpostPack] = $Pantheon::OutpostLimit;
$TeamItemMax[SpringPack] = $Pantheon::SpringboardLimit;
$TeamItemMax[PlatformPack] = $Pantheon::PlatformLimit;
$TeamItemMax[TreePack] = $Pantheon::SeedPackLimit;
$TeamItemMax[ShockPack] = $Pantheon::ELFTurretLimit;
$TeamItemMax[MechPack] = $Pantheon::InterceptorPackLimit;
$TeamItemMax[SuicidePack] = $Pantheon::NumberOfNukes;
$TeamItemMax[FGCPack] = $Pantheon::FGCPackLimit;

$TeamItemMax[ScoutVehicle] = $Pantheon::ScoutVehicleLimit;
$TeamItemMax[MarauderVehicle] = $Pantheon::MarauderVehicleLimit;
$TeamItemMax[HAPCVehicle] = $Pantheon::HAPCVehicleLimit;
$TeamItemMax[LAPCVehicle] = $Pantheon::LAPCVehicleLimit;
$TeamItemMax[GunshipVehicle] = $Pantheon::GunshipVehicleLimit;
$TeamItemMax[JetVehicle] = $Pantheon::InterceptorLimit;
$TeamItemMax[MechVehicle] = $Pantheon::InterceptorPackLimit;

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
$WeaponAmmo[EMPGrenadeLauncher] = EMPGrenadeAmmo;
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[DeathLaser] = "";
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[SniperRifle] = SniperAmmo; 
$WeaponAmmo[Railgun] = RailAmmo;
$WeaponAmmo[Vulcan] = VulcanAmmo;
$WeaponAmmo[Shotgun] = ShotgunAmmo;
$WeaponAmmo[FGC] = FGCAmmo;




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

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
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

function checkDeployArea(%client,%pos)
{
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
	else
	{
		Client::sendMessage(%client,0,"Unable to deploy - Item in the way");
	//	deleteObject(%set);
	//	return 1;
	}
	deleteObject(%set);
	return 0;	
}

//function checkDeployArea2(%client,%pos,%length,%width,%height)
function checkDeployArea2(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,0.1,0.1,0.1,0);
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
	else
	{
		Client::sendMessage(%client,0,"Unable to deploy - Item is in the way");
	//	deleteObject(%set);
	//	return 1;
	}
	deleteObject(%set);
	return 0;	
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
			Client::sendMessage(%client,0,"Too many weapons for " @ $ArmorName[%armor].description @ " to carry.");
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
			Client::sendMessage(%client,0,"Item limit reached for " @ %item.description @ "s. Limit: " @ $TeamItemMax[%item]);
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
		%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
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

//
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = GrenadeLauncher;
$NextWeapon[GrenadeLauncher] = EMPGrenadeLauncher;
$NextWeapon[EMPGrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = DeathLaser;
$NextWeapon[DeathLaser] = RocketLauncher;
$NextWeapon[RocketLauncher] = SniperRifle;
$NextWeapon[SniperRifle] = EnergyRifle;
$NextWeapon[EnergyRifle] = Railgun;
$NextWeapon[Railgun] = FGC;
$NextWeapon[FGC] = Vulcan;
$NextWeapon[Vulcan] = Shotgun;
$NextWeapon[Shotgun] = Blaster;



$PrevWeapon[Blaster] = Shotgun;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[EMPGrenadeLauncher] = GrenadeLauncher;
$PrevWeapon[Mortar] = EMPGrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[DeathLaser] = LaserRifle;
$PrevWeapon[RocketLauncher] = DeathLaser;
$PrevWeapon[SniperRifle] = RocketLauncher;
$PrevWeapon[EnergyRifle] = SniperRifle;
$PrevWeapon[Railgun] = EnergyRifle;
$PrevWeapon[FGC] = Railgun;
$PrevWeapon[Vulcan] = FGC;
$PrevWeapon[Shotgun] = Vulcan;



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
				%team = Client::getTeam(%player);
				%playerpos = GameBase::getPosition(%player);
				%flagpos = ($teamFlag[%team]).originalPosition;	
				%flagdist = Vector::getDistance(%playerpos,%flagpos);
				if (%flagdist < 125)
				{
					if (%item.description == "Repair Kit" && (%armor == "harmor" || %armor == "aarmor"))
					{
						return 0;
					}
				}
				else
				{
				Player::incItemCount(%player,%item,%delta);
				if (%count == 0 && $AutoUse[%item]) 
					Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
				return %delta;
				}
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

ItemData ScoutArmor
{
   heading = "aArmor";
	description = "Scout Armor";
	className = "Armor";
	price = 150;
};

ItemData LightArmor
{
   heading = "aArmor";
	description = "Peltast (Light)";
	className = "Armor";
	price = 175;
};

ItemData MediumArmor
{
   heading = "aArmor";
	description = "Hoplite (Engineer)";
	className = "Armor";
	price = 250;
};

ItemData HeavyArmor
{
   heading = "aArmor";
	description = "Myrmidon (Heavy)";
	className = "Armor";
	price = 400;
};

ItemData AssaultArmor
{
   heading = "aArmor";
	description = "Assault Armor";
	className = "Armor";
	price = 700;
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

function ScoutVehicle::onUse(%player) 
{
    if (Player::IsTriggered(%player,0))
    {
      %client=Player::GetClient(%player);
      Projectile::SpawnProjectile(ScoutRocket, GameBase::GetMuzzleTransform(%player), %player, 0, %client.LaunchAt);  
    }
}

ItemData GunshipVehicle
{
	description = "Gunship";
	className = "Vehicle";
	heading = "aVehicle";
	price = 750;
};

ItemData MarauderVehicle
{
	description = "Marauder";
	className = "Vehicle";
	heading = "aVehicle";
	price = 600;
};

ItemData JetVehicle
{
	description = "Interceptor";
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
	if (%ammo == "")
	{
		// Energy weapons dont have ammo types
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else
	{
		if (Player::getItemCount(%player,%ammo) > 0)
		{
			Player::mountItem(%player,%item,$WeaponSlot);
			%client = Player::getClient(%player);
			if (Client::getControlObject(%client) == %player)
			{
				bottomprint (%client, "<jc><f2>" @ %item.description, 0.75);
			}
		}
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
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//					AMMUNITION SECTION
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
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

//----------------------------------------------------------------------------

ItemData EMPGrenadeAmmo
{
	description = "EMP Grenades";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

//----------------------------------------------------------------------------

ItemData FGCAmmo
{
	description = "FGC-9000 Nukes";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 500;
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

//----------------------------------------------------------------------------

ItemData RailAmmo
{
	description = "Railgun Bolt";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

//----------------------------------------------------------------------------

ItemData RocketAmmo
{
	description = "Rockets";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 50;
};

//----------------------------------------------------------------------------

ItemData ShotgunAmmo
{
	description = "Shotgun Shell";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

//----------------------------------------------------------------------------

ItemData SniperAmmo
{
	description = "Sniper Bullet";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 5;
};

//----------------------------------------------------------------------------

ItemData VulcanAmmo
{
	description = "Vulcan Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};



//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//					 WEAPONS SECTION
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData BlasterImage
{
	shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.15;
	minEnergy = 2;
	maxEnergy = 3;

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


//----------------------------------------------------------------------------

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = false;

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


//----------------------------------------------------------------------------

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
//	sfxReady = SoundDiscSpin;
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

//----------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 2;
	projectileType = lightningCharge;
	minEnergy = 3;
	maxEnergy = 11;
	reloadTime = 0.2;
                        
	lightType = 3;
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

//----------------------------------------------------------------------------

ItemImageData EMPGrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = EMPGrenadeAmmo;
	projectileType = EMPGrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundLaserIdle;
};

ItemData EMPGrenadeLauncher
{
	description = "EMP Grenade Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sensorjamerpack";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = EMPGrenadeLauncherImage;
	price = 475;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

ItemImageData FGCImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = FGCAmmo;
	projectileType = FgcShell;
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
	sfxReady = SoundMortarIdle;
};

ItemData FGC
{
	description = "FGC-9000";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "ammopack";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = FGCImage;
	price = 3500;
	showWeaponBar = true;
};

function FGC::onUse(%player,%item)
{
	
	if(Player::getMountedItem(%player,$BackpackSlot) == FgcPack) Weapon::onUse(%player,%item);
	else Client::sendMessage(Player::getClient(%player),0,"Must have the FGC-9000 Pack to use the FGC-9000."); 
	
}

//----------------------------------------------------------------------------

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

//----------------------------------------------------------------------------

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
	shapeFile = "paintgun";
	hudIcon = "sniper";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
};

function LaserRifle::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item);
	else Client::sendMessage(Player::getClient(%player),0,"Must have an Energy Pack to use Laser Rifle."); 
}

//----------------------------------------------------------------------------

ItemImageData DeathLaserImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;
	projectileType = DeathLaserBeam;
	accuFire = true;
	minEnergy = 1;
	maxEnergy = 5;
	reloadTime = 0.1;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0, 0, 1 };
	sfxFire = SoundGeneratorPower;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DeathLaser
{
	description = "Laser Rifle, Rapidfire";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
	heading = bWeapons;
	shadowDetailMask = 4;
	imageType = DeathLaserImage;
	price = 500;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

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

//----------------------------------------------------------------------------

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0;
	ammoType = PlasmaAmmo;
	projectileType = PlasmaBolt;
	accuFire = true;
	reloadTime = 0.08;
	fireTime = 0.5;

	lightType = 3;
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

//----------------------------------------------------------------------------

ItemImageData RailgunImage
{
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

//----------------------------------------------------------------------------

ItemImageData RocketImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = RocketAmmo;
 	projectileType = Nuke;
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

//----------------------------------------------------------------------------

ItemImageData ShotgunImage
{
	shapeFile = "shotgun";
    	mountPoint = 0;
	ammoType = ShotgunAmmo;
	weaponType = 0;
	reloadTime = 1.25;
	fireTime = 0.75;
	accuFire = false;
	sfxActivate = SoundPickUpWeapon;
	sfxFire     = SoundFireShotgun;
	sfxReload   = SoundMortarReload;
};

ItemData Shotgun
{
	description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "blaster";
	className = "Weapon";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	showWeaponBar = true;
	price = 500;
};


function ShotgunImage::onFire(%player, %slot) 
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Shotgun]);
	if(%AmmoCount) 
		{
			%client = GameBase::getOwnerClient(%player);
			Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
	
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
			Projectile::spawnProjectile("ShotgunBlast",%trans,%player,%vel);
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of Shells");

}

//----------------------------------------------------------------------------

ItemImageData SniperRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0;
	ammoType = SniperAmmo;
	projectileType = SniperBullet;
	accuFire = true;
	reloadTime = 2.0;
	fireTime = 0;

	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0.0, 0 };

	sfxFire = SniperFire;
	sfxActivate = SoundPickUpWeapon;
	
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


//----------------------------------------------------------------------------

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

	lightType   = 3;
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description	= "Targeting Laser";
	className	= "Tool";
	shapeFile	= "paintgun";
	hudIcon		= "targetlaser";
	heading		= "bWeapons";
	shadowDetailMask = 4;
	imageType	= TargetingLaserImage;
	price		= 50;
	showWeaponBar	= false;
};

//------------------------------------------------------------------------------

ItemImageData VulcanImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1;
	reloadTime = 0.20;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0;

	ammoType = VulcanAmmo;
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

//----------------------------------------------------------------------------

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

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//					BACKPACK SECTION
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

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
		for(%i = 0; %i < 13 ; %i = %i +1) {
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
	 	    	%item.RocketAmmo = %numPack;
			}
			else if(%i == 7) {
	 	    	%item.SniperAmmo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.RailAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.EMPGrenadeAmmo = %numPack;
			}
			else if(%i == 10) {
	 	    	%item.VulcanAmmo = %numPack;
			}
			else if(%i == 11) {
	 	    	%item.MineAmmo = %numPack;
			}
			else if(%i == 12) {
	 	    	%item.Beacon = %numPack;
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
	for(%i = 0; %i < 14 ; %i = %i +1) {
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
 	    	%numAdd = %item.EMPGrenadeAmmo;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.VulcanAmmo;
		}
		else if(%i == 11) {
 	    	%numAdd = %item.MineAmmo;
		}
		else if(%i == 12) {
			%numAdd = %item.BeaconAmmo;
		}
		else if(%i == 13) {
			%numAdd = %item.ShotgunAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 14 ; %i = %i +1)
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

ItemImageData LaptopImage
{
	shapeFile = "AmmoPack";
	weaponType = 2;

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

//----------------------------------------------------------------------------

ItemData Laptop
{
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

function Laptop::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function Laptop::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//----------------------------------------------------------------------------

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

ItemImageData FgcPackImage
{
	shapeFile = "generator_p";
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
	description = "FGC-9000 Pack";
	shapeFile = "generator_p";
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FgcPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FgcPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == FGC) 
		Player::unmountItem(%player,$WeaponSlot);
}

//----------------------------------------------------------------------------

//=-=-=-=-=-=-=-=-==-

ItemImageData MechPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MechPack
{
	description = "Interceptor Pack";
	shapeFile = "flyer";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = MechPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MechPack::onUse(%player,%item)
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

function MechPack::onDeploy(%player,%item,%pos)
{
	if (MechPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function MechPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"] < $TeamItemMax[JetVehicle])
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
						%fField = newObject("",flier,Jet,true);

						addToSet("MissionCleanup", %fField);
						GameBase::setTeam(%fField,GameBase::getTeam(%player));
						GameBase::setPosition(%fField,$los::position);
						GameBase::setRotation(%fField,%rot);
						Gamebase::setMapName(%fField,"Mech Robot");
						Client::sendMessage(%client,0,"Piloting Interceptor");
						GameBase::startFadeIn(%fField);
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "JetVehicle"]++;
						return true;
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData SuicidePackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0.75, -0.5, -0.3 };
	mountRotation = { 0, -1.5, 0 };
	mass = 5.0;
	firstPerson = false;

	lightType = 2;
	lightRadius = 10;
	lightTime = 1.5;
	lightColor = { 1, 0, 0 };

};

ItemData SuicidePack
{
	description = "Nuke Pack";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = SuicidePackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 20000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SuicidePack::onUse (%player, %item)
{
	%team = GameBase::getTeam(%player);
	if (Player::getMountedItem (%player, $BackpackSlot) != %item)
	{
		Player::mountItem (%player, %item, $BackpackSlot);
	}
	else
	{
		if ($NukeTeam[%team] < $TeamItemMax[SuicidePack])
		{
        		Player::deployItem (%player, %item);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Nuke Limit Exceeded. Limit is " @ $NukeTeam[%team] @ " per team.");
		}
	}
}

function SuicidePack::onDeploy (%player, %item, %pos)
{
	if (SuicidePack::deployShape (%player, %item))
	{
		Player::decItemCount (%player, %item);
	}
}

function SuicidePack::deployShape(%player,%item)
{
	if($matchStarted)
	{
		Player::unmountItem (%player, $BackpackSlot);
		%obj = newObject("","Mine","AtomGrenade");
 	 	addToSet("MissionCleanup", %obj);
		%client = Player::getClient(%player);
		GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
		GameBase::setTeam(%obj, Client::getTeam(%client));
			
		%team = GameBase::getTeam(%player);
		%tName = getTeamName(%team);
		$NukeTeam[%team] += 1;
		$TeamItemCount[GameBase::getTeam(%player) @ "SuicidePack"]++;
		messageall(1,"The " @ %tName @ " have deployed a nuke!~wLeftMissionArea.wav");
	}
}

//----------------------------------------------------------------------------

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


//----------------------------------------------------------------------------

ItemImageData ShieldPackImage
{
	shapeFile = "shieldPack";
	weaponType = 2;

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 4;
	maxEnergy = 9;

	sfxFire = SoundShieldOn;
	firstPerson = false;

	lightType = 2;
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 0, 0.25, 1 };

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
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//					 STATIONS SECTION
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
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
	heading = "dStations";
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
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{
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
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------
//=-=-=-=- Command Center =-=-=-=-

ItemImageData DeployableComPackImage
{
	shapeFile = "ammounit_remote";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 4.5;
	firstPerson = false;
};

ItemData DeployableComPack
{
	description = "Command Station";
	shapeFile = "ammounit_remote";
	className = "Backpack";
	heading = "dStations";
	shadowDetailMask = 4	;
	imageType = DeployableComPackImage;
	mass = 4.0;
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
	if (DeployableComPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function DeployableComPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{

				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{
						%inv = newObject("comunit_remote","StaticShape","DeployableComStation",true);
						addToSet("MissionCleanup", %inv);
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%inv,GameBase::getTeam(%player));
						GameBase::setPosition(%inv,$los::position);
						GameBase::setRotation(%inv,%rot);
						Gamebase::setMapName(%inv,%name);
						Client::sendMessage(%client,0,"Command Station deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%inv) @ "DeployableComPack"]++;
						return true;
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
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
	heading = "dStations";
	shadowDetailMask = 4;
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
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{
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
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//                          DEPLOYABLES SECTION
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
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
	description = "Base Alarm";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = "eDeployables";
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
					Gamebase::setMapName(%mprox,"Base Alarm #" @ $totalnumalarms[GameBase::getTeam(%player)]++);
					Client::sendMessage(%client,0,"Base Alarm deployed");
					playSound(SoundPickupBackpack,$los::position);
					echo("MSG: ",%client," deployed a Base Alarm");
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


ItemImageData BlastwallPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
//	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData BlastwallPack
{
	description = "Blast Wall";
	shapeFile = "newdoor5";
	className = "Backpack";
	heading = "eDeployables";
	imageType = BlastwallPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function BlastwallPack::onUse(%player,%item)
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

function BlastwallPack::onDeploy(%player,%item,%pos)
{
	if (BlastwallPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}

}

function BlastwallPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%name = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%name == "BlastWall") || (%name == "LargeForceField") || (%name == "DeployableForceField") || (%name == "ForceFieldDoorShape") || (%name == "DeployablePlatform")  )) {
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"BlastWall",%num);
				deleteObject(%set);
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if ((%name == "BlastWall") || (%name == "LargeForceField") || (%name == "DeployableForceField") || (%name == "ForceFieldDoorShape") || (%name == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1") {
						%rot = GameBase::getRotation(%player);
						%phase = newObject("","StaticShape",BlastWall,true);
						%team = GameBase::getTeam(%player);
						addToSet("MissionCleanup", %phase);
						GameBase::setTeam(%phase,%team);
						GameBase::setPosition(%phase,$los::position);
						GameBase::setRotation(%phase,%rot);
						Gamebase::setMapName(%phase,"Blast Wall");
						Client::sendMessage(%client,0,"Blast Wall Deployed");
						GameBase::startFadeIn(%phase);
						playSound(SoundPickupBackpack,$los::position);
						playSound(ForceFieldOpen,$los::position);
						$TeamItemCount[%team @ "BlastwallPack"]++;
						return true;
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;

}

//----------------------------------------------------------------------------
//=-=-=-=-=-=-=-=-==-

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
	heading = "eDeployables";
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::deployItem(%player,%item);
	}
}

function CameraPack::onDeploy(%player,%item,%pos)
{
	if (CameraPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
		//	if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

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
		//	}
		//	else {
		//		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		//	}
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
//-=-=-=-=-=-=-=- Platform Pack =-=-=-=-=-=-=-

ItemImageData PlatformPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlatformPack
{
	description = "Deployable Platform";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "eDeployables";
	imageType = PlatformPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlatformPack::onUse(%player,%item)
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

function PlatformPack::onDeploy(%player,%item,%pos)
{
	if (PlatformPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function PlatformPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%name = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%name == "BlastWall") || (%name == "LargeForceField") || (%name == "DeployableForceField") || (%name == "ForceFieldDoorShape") || (%name == "DeployablePlatform")  )) {
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"DeployablePlatform",%num);
				deleteObject(%set);
				//	if (Vector::dot($los::normal,"0 0 1") > 0.7) {

					if ((%name == "BlastWall") || (%name == "LargeForceField") || (%name == "DeployableForceField") || (%name == "ForceFieldDoorShape") || (%name == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1") {
						%rot = GameBase::getRotation(%player);
						%fField = newObject("DeployablePlatform","StaticShape",DeployablePlatform,true);
						%team = GameBase::getTeam(%player);
						addToSet("MissionCleanup", %fField);
						GameBase::setTeam(%fField,%team);
						GameBase::setPosition(%fField,$los::position);
						GameBase::setRotation(%fField,%rot);
						Gamebase::setMapName(%fField,"Deployable Platform");
						Client::sendMessage(%client,0,"Platform Deployed");
						GameBase::startFadeIn(%fField);
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[%team @ "PlatformPack"]++;
						return true;
					}
			//	}
			//	else 
			//		Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData ForceFieldDoorPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldDoorPack
{
	description 		= "Force Field, Door";
	shapeFile 		= "AmmoPack";
	className 		= "Backpack";
	heading 		= "eDeployables";
	imageType 		= ForceFieldDoorPackImage;
	shadowDetailMask 	= 4;
	mass 			= 2.5;
	elasticity 		= 0.2;
	price			= 800;
	hudIcon 		= "deployable";
	showWeaponBar		= true;
	hiliteOnActive		= true;
};

function ForceFieldDoorPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player, $BackpackSlot) != %item)
	{
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else
	{
		Player::deployItem(%player, %item);
	}
}

function ForceFieldDoorPack::onDeploy(%player, %item, %pos)
{
if (ForceFieldDoorPack::deployShape(%player, %item))
    {
	    Player::decItemCount(%player, %item);
    }
}

function ForceFieldDoorPack::deployShape(%player, %item)
{
	%client = Player::getClient(%player);
	if ($TeamItemCount[GameBase::getTeam (%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player, 3))
		{
			%obj = getObjectType($los::object);
			%name = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%name == "BlastWall") || (%name == "LargeForceField") || (%name == "DeployableForceField") || (%name == "ForceFieldDoorShape") || (%name == "DeployablePlatform")  ))
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if ((%name == "BlastWall") || (%name == "LargeForceField") || (%name == "DeployableForceField") || (%name == "ForceFieldDoorShape") || (%name == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{
						%obj = getObjectType($los::object);
						%rot = GameBase::getRotation(%player);
						%team = GameBase::getTeam(%player);
						%fField = newObject("ForceFieldDoorPack", "StaticShape", ForceFieldDoorShape, true);
						addToSet("MissionCleanup", %fField);
						GameBase::setTeam(%fField, %team);
						GameBase::setRotation(%fField, %rot);
						GameBase::setPosition(%fField, $los::position);
						Gamebase::setMapName(%fField, "Force Field Door");
						Client::sendMessage(%client, 0, "Force Field Door deployed");
						playSound(SoundPickupBackpack, $los::position);
						$TeamItemCount[%team @ "ForceFieldDoorPack"]++;
						return true;
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} Client::sendMessage(%client,0,"Can not deploy there");
		} else Client::sendMessage(%client, 0, "Deploy position out of range");
	} else Client::sendMessage(%client, 0, "Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData LargeForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LargeForceFieldPack
{
	description = "Force Field, Large";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "eDeployables";
	imageType = LargeForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LargeForceFieldPack::onUse(%player,%item)
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

function LargeForceFieldPack::onDeploy(%player,%item,%pos)
{
	if (LargeForceFieldPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function LargeForceFieldPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "LargeForceField") || (%dataname == "DeployableForceField") || (%dataname == "ForceFieldDoorShape") || (%dataname == "DeployablePlatform")  ))
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if ((%dataname == "BlastWall") || (%dataname == "LargeForceField") || (%dataname == "DeployableForceField") || (%dataname == "ForceFieldDoorShape") || (%dataname == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea2(%client,$los::position,0.1,0.1,0.1))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{
						%rot = GameBase::getRotation(%player);
						%fField = newObject("","StaticShape",LargeForceField,true);
						%team = GameBase::getTeam(%player);
						addToSet("MissionCleanup", %fField);
						GameBase::setTeam(%fField,%team);
						GameBase::setPosition(%fField,$los::position);
						GameBase::setRotation(%fField,%rot);
						Gamebase::setMapName(%fField,"Large Force Field");
						Client::sendMessage(%client,0,"Force Field Deployed");
						GameBase::startFadeIn(%fField);
						playSound(SoundPickupBackpack,$los::position);
						playSound(ForceFieldOpen,$los::position);
						$TeamItemCount[%team @ "LargeForceFieldPack"]++;
						return true;
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy there");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

//--------------------------------------------------------
//=-=-=-=-=- Deployable Force Field Pack --=-=-=-=-=-=-=- 
//--------------------------------------------------------
						
ItemImageData ForceFieldPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData ForceFieldPack
{
	description = "Force Field, Small";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "eDeployables";
	imageType = ForceFieldPackImage;
	shadowDetailMask = 4;
	mass = 1.5;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ForceFieldPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%name = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%name == "BlastWall") || (%name == "LargeForceField") || (%name == "DeployableForceField") || (%name == "ForceFieldDoorShape") || (%name == "DeployablePlatform")  ))
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if ((%name == "BlastWall") || (%name == "LargeForceField") || (%name == "DeployableForceField") || (%name == "ForceFieldDoorShape") || (%name == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{
						%rot = GameBase::getRotation(%player);
						%fField = newObject("","StaticShape",DeployableForceField,true);
						addToSet("MissionCleanup", %fField);
						GameBase::setTeam(%fField,GameBase::getTeam(%player));
						GameBase::setPosition(%fField,$los::position);
						GameBase::setRotation(%fField,%rot);
						Gamebase::setMapName(%fField,"Small Force Field");
						Client::sendMessage(%client,0,"Force Field Deployed");
						GameBase::startFadeIn(%fField);
						playSound(SoundPickupBackpack,$los::position);
						playSound(ForceFieldOpen,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++;
						return true;
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy there");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
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
	heading = "eDeployables";
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
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
		//	if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

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
		//	}
		//	else {
		//		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		//	}
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

ItemImageData OutpostPackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.2, 0 };
	mass = 4.0;
	firstPerson = false;
};

ItemData OutpostPack
{
	description = "Outpost";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = "eDeployables";
	imageType = OutpostPackImage;
	shadowDetailMask = 4;
	mass = 4.0;
	elasticity = 0.2;
	price = 6000;
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
	%rota = GameBase::getRotation(%client);
	%rotate = getWord(%rota,2);
	if (%rotate > -0.785 && %rotate < 0.785)
	{
//	echo ("Deploying Northward");
	}

	else if (%rotate > 0.785 && %rotate < 2.355)
	{
//	echo ("Deploying Westward");
	}

	else if (%rotate > 2.355 || %rotate < -2.355)
	{
//	echo ("Deploying Southward");
	}

	else if (%rotate < -0.785 && %rotate > -2.355)
	{
//	echo ("Deploying Eastward");
	}

	if($TeamItemCount[%team @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
				%num = CountObjects(%set,"BlastWall",%num);
				deleteObject(%set);

				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{
							//--- Generator ---//
						%where = $los::position;
						%pos = Vector::add(%where,"0 -4 0");
						%rot = "0 0 0";
						%outpostgen = newObject("OutpostGen","StaticShape",OutpostGen,true);
						addToSet("MissionCleanup", %outpostgen);
						GameBase::setTeam(%outpostgen,%team);
						GameBase::setPosition(%outpostgen,%pos);
						GameBase::setRotation(%outpostgen,%rot);
						Gamebase::setMapName(%outpostgen,"Outpost Generator");

							//--- Back Wall ---//
						%where = $los::position;
						%rot = "0 0 0";
						%backwall = newObject("","StaticShape",BlastWall,true);
						addToSet("MissionCleanup", %backwall);
						GameBase::setTeam(%backwall,%team);
						GameBase::setPosition(%backwall,%where);
						GameBase::setRotation(%backwall,%rot);
						Gamebase::setMapName(%backwall,"Outpost");

							//--- Right Wall ---//
						%rightwall = newObject("","StaticShape",BlastWall,true);
						addToSet("MissionCleanup", %rightwall);
						GameBase::setTeam(%rightwall,%team);
						%pos = Vector::add(%where,"4.7250 -5.200 0");
						%rot2 = "0 0 1.57";
						GameBase::setPosition(%rightwall,%pos);
						GameBase::setRotation(%rightwall,%rot2);
						Gamebase::setMapName(%rightwall,"Outpost");

							//--- Left Wall ---//
						%leftwall = newObject("","StaticShape",BlastWall,true);
						addToSet("MissionCleanup", %leftwall);
						GameBase::setTeam(%leftwall,%team);
						%pos = Vector::add(%where,"-4.767 -5.200 0");
						GameBase::setPosition(%leftwall,%pos);
						GameBase::setRotation(%leftwall,%rot2);
						Gamebase::setMapName(%leftwall,"Outpost");

							//--- Right Door ---//
						%rightdoor = newObject("","StaticShape",ForceFieldDoorShape,true);
						addToSet("MissionCleanup", %rightdoor);
						GameBase::setTeam(%rightdoor,%team);
						%rot2 = "0 1.57 0";
						%pos = Vector::add(%where,"0.04 -9.907 3.942");
						GameBase::setPosition(%rightdoor,%pos);
						GameBase::setRotation(%rightdoor,%rot2);
						Gamebase::setMapName(%rightdoor,%name);

							//--- Left Door ---//
						%leftdoor = newObject("","StaticShape",ForceFieldDoorShape,true);
						addToSet("MissionCleanup", %leftdoor);
						GameBase::setTeam(%leftdoor,%team);
						%rot2 = "0 1.57 0";
						%pos = Vector::add(%where,"-4.45 -9.907 3.942");
						GameBase::setPosition(%leftdoor,%pos);
						GameBase::setRotation(%leftdoor,%rot2);
						Gamebase::setMapName(%leftdoor,%name);

							//--- Roof ---//
						%roof = newObject("","StaticShape",Blastwall,true);
						addToSet("MissionCleanup", %roof);
						GameBase::setTeam(%roof,%team);
						%rot2 = "1.57 0 3.14";
						%pos = Vector::add(%where,"-0.05 -7.726 7.735");
						GameBase::setPosition(%roof,%pos);
						GameBase::setRotation(%roof,%rot2);
						Gamebase::setMapName(%roof,"Outpost");
						%roof = newObject("","StaticShape",Blastwall,true);
						addToSet("MissionCleanup", %roof);
						GameBase::setTeam(%roof,%team);
						%rot2 = "1.57 3.14 3.14";
						%pos = Vector::add(%where,"0 -7.726 7.735");
						GameBase::setPosition(%roof,%pos);
						GameBase::setRotation(%roof,%rot2);
						Gamebase::setMapName(%roof,"Outpost");

							//--- Floor ---//
						%floor = newObject("","StaticShape",OutpostFloor,true);
						addToSet("MissionCleanup", %floor);
						GameBase::setTeam(%floor,%team);
						%rot2 = "0 0 1.18";
						%pos = Vector::add(%where,"0 -7.726 -0.532");
						GameBase::setPosition(%floor,%pos);
						GameBase::setRotation(%floor,%rot2);
						Gamebase::setMapName(%floor,"Outpost");

							//--- Front Wall Shield ---//
						%rot2 = "0 0 0";
						%pos = Vector::add(%where,"0 -15.468 0");
						%frontwall = newObject("","StaticShape",BlastWall,true);
						addToSet("MissionCleanup", %frontwall);
						GameBase::setTeam(%frontwall,%team);
						GameBase::setPosition(%frontwall,%pos);
						GameBase::setRotation(%frontwall,%rot2);
						Gamebase::setMapName(%frontwall,"Outpost");

						//--- Blah blah ---//
						Client::sendMessage(%client,0,"Outpost Deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[%team @ "OutpostPack"]++;
						return true;
					}
				}
				else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else Client::sendMessage(%client,0,"Can not deploy on buildings.");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
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
	description = "Pulse Sensor";
	shapeFile = "radar_small";
	className = "Backpack";
	heading = "eDeployables";
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
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}

//----------------------------------------------------------------------------

ItemImageData TreePackImage
{
	shapeFile = "jetpack";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData TreePack
{
	description = "Seed Pack";
	shapeFile = "jetpack";
	className = "Backpack";
	heading = "eDeployables";
	imageType = TreePackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.1;
	price = 50;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TreePack::onUse(%player,%item)
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

function TreePack::onDeploy(%player,%item,%pos)
{
	if (TreePack::deployShape(%player,%item))
	{
		//Player::decItemCount(%player,%item); //thus infinite trees to plant
	}
}

function TreePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			if (%obj != "InteriorShape")
			{
					if(checkDeployArea(%client,$los::position))
					{
						%rot = GameBase::getRotation(%player);
						%rand = floor(getRandom() * 6);
						if(%rand == 0) %type = "TreeShapeTwo";
						else if(%rand == 1) %type = "TreeShape"; 
						else if(%rand == 2) %type = "PlantTwo";
						else if(%rand == 3) %type = "TreeShapeTwo";
						else if(%rand == 4) %type = "TreeShape"; 
						else if(%rand == 5) %type = "PlantTwo";
						else %type = "PlantTwo";

						%tree = newObject("A Tree","StaticShape",%type,true);
                 				addToSet("MissionCleanup", %tree);
						GameBase::setTeam(%tree,GameBase::getTeam(%player));
						GameBase::setPosition(%tree,$los::position);
						GameBase::setRotation(%tree,%rot);
						Gamebase::setMapName(%tree,"Tree " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Seed Planted");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "TreePack"]++;
						return true;
					}
			} else Client::sendMessage(%client,0,"Cannot deploy in buildings");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description);
	return false;
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
	heading = "eDeployables";
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
	if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
	}
}

//----------------------------------------------------------------------------

ItemImageData SniperPadPackImage
{
	shapeFile = "ammopack";
	mountPoint = 2;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SniperPadPack
{
	description	= "Sniper Pad";
	shapefile	= "ammopack";
	classname	= "Backpack";
	heading		= "eDeployables";
	imageType	= SniperPadPackImage;
	shadowDetailMask = 4;
	mass		= 1.0;
	elasticity	= 0.1;
	price		= 650;
	hudIcon		= "deployable";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function SniperPadPack::onUse(%player,%item)
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

function SniperPadPack::onDeploy(%player,%item,%pos)
{
         if (SniperPadPack::deployShape(%player,%item))
         {
                 Player::decItemCount(%player,%item);
         }
} 

function SniperPadPack::deployShape(%player,%item)
{
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
		%pad = newObject("SniperPad","StaticShape",SniperPad,true);
		%where = GameBase::getPosition(%player);
		%team = GameBase::getTeam(%player);
		addToSet("MissionCleanup", %pad);
		%rot = GameBase::getRotation(%player);
		GameBase::setTeam(%pad,%team);
		GameBase::setRotation(%pad,%rot);
		GameBase::setPosition(%pad,%where);
		Gamebase::setMapName(%pad,%name);
		Client::sendMessage(%client,0,"Sniper Pad deployed");
		%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
		addToSet("MissionCleanup", %inv);
		%pos = Vector::add(%where,"0 0 1");
		GameBase::setTeam(%inv,%team);
		GameBase::setRotation(%inv,%rot);
		GameBase::setPosition(%inv,%pos);
		Gamebase::setMapName(%inv,%name);
		playSound(SoundPickupBackpack,$los::position);
		return true;
	}
}

//----------------------------------------------------------------------------

ItemImageData DeployableSolarPanelImage
{
	shapeFile = "radar_small";
	mountPoint = 2;
  	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	mass = 0.5;
	firstPerson = false;
};

ItemData DeployableSolarPanel
{
	description = "Solar Panel";
	shapeFile = "solar_med";
	className = "Backpack";
	heading = "eDeployables";
	shadowDetailMask = 4	;
	imageType = DeployableSolarPanelImage;
	mass = 3.0;
	elasticity = 0.2;
	price = 750;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};


function DeployableSolarPanel::onUse(%player,%item)
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

function DeployableSolarPanel::onDeploy(%player,%item,%pos)
{
	if (DeployableSolarPanel::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}	

function DeployableSolarPanel::deployShape(%player,%item)
{
	echo (%player.outArea);
	%client = Player::getClient(%player);
	if(%player.outArea){
		Client::sendMessage(%client,0,"Can only deploy within the mission boundries.");
		return;
	}
		
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%teamnum = GameBase::getTeam(%player);
						%SPanel = newObject("Deployable Solar Panel","StaticShape",RemoteSolarPanel,true);
						if (%teamnum == "0")
						{ 	 					
						  addToSet("MissionGroup/Teams/team0", %SPanel);
						}
						else if (%teamnum == "1")
						{ 	 					
						  addToSet("MissionGroup/Teams/team1", %SPanel);
						}
						else if (%teamnum == "2")
						{ 	 					
						  addToSet("MissionGroup/Teams/team2", %SPanel);
						}
						else if (%teamnum == "3")
						{ 	 					
						  addToSet("MissionGroup/Teams/team3", %SPanel);
						}
						else if (%teamnum == "4")
						{ 	 					
						  addToSet("MissionGroup/Teams/team4", %SPanel);
						}
						else if (%teamnum == "5")
						{ 	 					
						  addToSet("MissionGroup/Teams/team5", %SPanel);
						}
						else if (%teamnum == "6")
						{ 	 					
						  addToSet("MissionGroup/Teams/team6", %SPanel);
						}
						else if (%teamnum == "7")
						{ 	 					
						  addToSet("MissionGroup/Teams/team7", %SPanel);
						}
						%rot = GameBase::getRotation(%player); 
						GameBase::setTeam(%SPanel,GameBase::getTeam(%player));
						GameBase::setPosition(%SPanel,$los::position);
						GameBase::setRotation(%SPanel,%rot);
						Gamebase::setMapName(%SPanel,%name);
						GameBase::generatePower(%SPanel, True);
						Client::sendMessage(%client,0,"Solar Panel deployed");
						$TeamItemCount[GameBase::getTeam(%SPanel) @ "DeployableSolarPanel"]++;
						return true;
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can only deploy on terrain");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//----------------------------------------------------------------------------

ItemImageData SpringPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData SpringPack
{
	description = "Springboard";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "eDeployables";
	imageType = SpringPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SpringPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player, $BackpackSlot) != %item)
	{
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else
	{
		Player::deployItem(%player, %item);
	}
}

function SpringPack::onDeploy(%player, %item, %pos)
{
	if (SpringPack::deployShape(%player, %item))
	{
		Player::decItemCount(%player, %item);
	}
}

function SpringPack::deployShape(%player, %item)
{
	%client = Player::getClient(%player);
	if ($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player, 3))
		{
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
			{
				%set = newObject("set", SimSet);
				%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, $ForceFieldBoxMinLength, $ForceFieldBoxMinWidth, $ForceFieldBoxMinHeight, 0);
				%num = CountObjects(%set, "DeployableCactus", %num);
				deleteObject(%set);
				if (Vector::dot($los::normal, "0 0 1") > 0.7)
				{
					if (checkDeployArea(%client, $los::position))
					{
						%rot = GameBase::getRotation(%player);
						%phase = newObject("", "StaticShape", DeployableSpring, true);
						addToSet("MissionCleanup", %phase);
						GameBase::setTeam(%phase, GameBase::getTeam (%player));
						GameBase::setPosition(%phase, $los::position);
						GameBase::setRotation(%phase, %rot);
						Gamebase::setMapName(%phase, "Springboard");
						Client::sendMessage(%client, 0, "Springboard Deployed");
						GameBase::startFadeIn(%phase);
						playSound(SoundPickupBackpack, $los::position);
						playSound(ForceFieldOpen, $los::position);
						$TeamItemCount[GameBase::getTeam(%player) @ "SpringPack"]++;
						return true;
					}
				} else Client::sendMessage(%client, 0, "Can only deploy on flat surfaces");
			} else Client::sendMessage(%client, 0, "Can only deploy on terrain or buildings");
		} else Client::sendMessage(%client, 0, "Deploy position out of range");
	} else Client::sendMessage(%client, 0, "Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData TeleportPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TeleportPack
{
	description = "Teleport Pad";
	shapeFile = "flagstand";
	className = "Backpack";
	heading = "eDeployables";
	imageType = TeleportPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
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
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]++;
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
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform") || (%dataname == "OutpostFloor")  ))
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform") || (%dataname == "OutpostFloor"))
					{
						%deployok = "1";
					}
					else 
					{
		//				if(checkDeployArea(%client,$los::position))					
		//				{
							%deployok = "1";
		//				}
		//				else return false;
					}
					if (%deployok == "1")
					{
						%sensor = newObject("Teleport Pad","StaticShape",%shape,true);
						CreateteleportSimSet();
                	        		addToSet("MissionCleanup/Teleports", %sensor);
						addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						%pos = Vector::add($los::position,"0 0 0.3");
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
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData TeleportDecoyPackImage
{
	shapeFile = "flagstand";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TeleportDecoyPack
{
	description = "Teleport Pad Decoy";
	shapeFile = "flagstand";
	className = "Backpack";
	heading = "eDeployables";
	imageType = TeleportDecoyPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TeleportDecoyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function TeleportDecoyPack::onDeploy(%player,%item,%pos)
{
	if (TeleportDecoyPack::deployShape(%player,"Teleport Pad",DeployableTeleportDecoy,%item))
	{
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleportDecoy"]++;
	}
}

function TeleportDecoyPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleportDecoy"] < $TeamItemMax[DeployableTeleportDecoy])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform") || (%dataname == "OutpostFloor")  ))
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform") || (%dataname == "OutpostFloor"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{
						%sensor = newObject("Teleport Pad","StaticShape",%shape,true);
						%team = GameBase::getTeam(%player);
						addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,%team);
						%pos = Vector::add($los::position,"0 0 0.3");
						GameBase::setPosition(%sensor,%pos);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						%sensor.disabled = false;
						playSound(SoundPickupBackpack,$los::position);
						%beam = newObject("","StaticShape",ElectricalBeamBig,true);
						addToSet("MissionCleanup", %beam);
						GameBase::setTeam(%beam,%team);
						GameBase::setPosition(%beam,%pos);
						%sensor.beam1 = %beam;
						return true;
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}


//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//                            TURRETS SECTION
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData DissectionImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DissectionPack
{
	description = "Dissection Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = "fTurrets";
	imageType = DissectionImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DissectionPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DissectionPack::onDeploy(%player,%item,%pos)
{
	if (DissectionPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DissectionPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform") || (%dataname == "OutpostFloor")  ))
			{
//				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform") || (%dataname == "OutpostFloor"))
					{
						%deployok = "1";
					}
					else 
					{
						if(checkDeployArea(%client,$los::position))					
						{
							%deployok = "1";
						}
						else return false;
					}
					if (%deployok == "1")
					{

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
						%camera = newObject("Camera","Turret",DeployableDissection,true);
						addToSet("MissionCleanup", %camera);
						GameBase::setTeam(%camera,GameBase::getTeam(%player));
						GameBase::setRotation(%camera,%rot);
						GameBase::setPosition(%camera,$los::position);
						Gamebase::setMapName(%camera,"Dissection#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Dissection Turret deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%camera) @ "DissectionPack"]++;
						//--------------//
						%team = Client::getTeam(%client);
						%playerpos = GameBase::getPosition(%client);
						%flagpos = ($teamFlag[%team]).originalPosition;	
						%flagdist = Vector::getDistance(%playerpos,%flagpos);
						if (%flagdist < 25)
						{
							%client.score += 1;
							%client.turrets += 1;
							Game::refreshClientScore(%client);
							bottomprint(%client, "You receive 1 point for defending the flag.");
						}
						//--------------//
						return true;
					}
//				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");		
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}




ItemImageData ShockPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ShockPack
{
	description = "ELF Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = "fTurrets";
	imageType = ShockPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
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
	if (ShockPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function ShockPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
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
				if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
				{
					%deployok = "1";
				}
				else 
				{
					if(checkDeployArea(%client,$los::position))	
					{
						%deployok = "1";
					}
					else return false;
				}
				if (%deployok == "1")
				{
					%camera = newObject("Camera","Turret",DeployableShock,true);
					addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Shock Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Shock Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "ShockPack"]++;
					return true;
				}
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData LaserPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData LaserPack
{
	description = "Laser Turret";
	shapeFile = "camera";
	className = "Backpack";
	heading = "fTurrets";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserPack::onDeploy(%player,%item,%pos)
{
	if (LaserPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function LaserPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
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
				if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
				{
					%deployok = "1";
				}
				else 
				{
					if(checkDeployArea(%client,$los::position))	
					{
						%deployok = "1";
					}
					else return false;
				}
				if (%deployok == "1")
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
					//--------------//
					%team = Client::getTeam(%client);
					%playerpos = GameBase::getPosition(%client);
					%flagpos = ($teamFlag[%team]).originalPosition;	
					%flagdist = Vector::getDistance(%playerpos,%flagpos);
					if (%flagdist < 25)
					{
						%client.score += 1;
						%client.turrets += 1;
						Game::refreshClientScore(%client);
						bottomprint(%client, "You receive 1 point for defending the flag.");
					}
					//--------------//
					return true;
				}
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");		
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData MortarTurretPackImage 
{
  shapeFile = "ammounit_remote";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
};

ItemData MortarTurretPack 
{
	description = "Mortar Turret";
	shapeFile = "mortar_turret";
	className = "Backpack";
	heading = fTurrets;
	imageType = MortarTurretPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 800;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MortarTurretPack::onUse(%player,%item) 
{
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
    Player::mountItem(%player,%item,$BackpackSlot);
  else 
    Player::deployItem(%player,%item);
}

function MortarTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Mortar Turret has no auto-sensor and must be controlled manually to fire.");
}

function MortarTurretPack::onDeploy(%player,%item,%pos)
{
	if (MortarTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function MortarTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableMortar",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableMortar",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
							{
								%deployok = "1";
							}
							else 
							{
								if(checkDeployArea(%client,$los::position))	
								{
									%deployok = "1";
								}
								else return false;
							}
							if (%deployok == "1")
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableMortar,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								GameBase::setMapName(%turret,"Mortar Turret #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Mortar Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "MortarTurretPack"]++;
								return true;
							}
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	}else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData PlasmaPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData PlasmaPack
{
	description = "Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "fTurrets";
	imageType = PlasmaPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmaPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function PlasmaPack::onDeploy(%player,%item,%pos)
{
	if (PlasmaPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function PlasmaPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			%objteam = GameBase::getTeam($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployablePlasma",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
			    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployablePlasma",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
							{
								%deployok = "1";
							}
							else 
							{
								if(checkDeployArea(%client,$los::position))	
								{
									%deployok = "1";
								}
								else return false;
							}
							if (%deployok == "1")
							{
								%team = Client::getTeam(%client);
								%playerpos = GameBase::getPosition(%client);
								%flagpos = ($teamFlag[%team]).originalPosition;	
								%flagdist = Vector::getDistance(%playerpos,%flagpos);

								for(%i = 0; %i < 4; %i++)
								{
									if (%team != %i)
									{
										if (%objteam != "-1")
										{
											if (%objteam != %team)
											{
												bottomprint(%client, "You can't deploy that here.");
												return;
											}
										}
									}
								}

								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",DeployablePlasma,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Plasma Turret #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Plasma Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "PlasmaPack"]++;
								return true;
							}
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData DumbRocketPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData DumbRocketPack
{
	description = "Rocket Battery";
	shapeFile = "missileturret";
	className = "Backpack";
	heading = "fTurrets";
	imageType = DumbRocketPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 650;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DumbRocketPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DumbRocketPack::onDeploy(%player,%item,%pos)
{
	if (DumbRocketPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DumbRocketPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableDumbRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
					%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableDumbRocket",%num);
					deleteObject(%set);
					if(0 == %num)
					{
						if (Vector::dot($los::normal,"0 0 1") > 0.7)
						{
							if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
							{
								%deployok = "1";
							}
							else 
							{
								if(checkDeployArea(%client,$los::position))	
								{
									%deployok = "1";
								}
								else return false;
							}
							if (%deployok == "1")
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableDumbRocket,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Rocket Turret #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Rocket Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "DumbRocketPack"]++;
								return true;
							}
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

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
	description = "Seeking Missile Turret";
	shapeFile = "missileturret";
	className = "Backpack";
	heading = "fTurrets";
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
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableRocket",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
							{
								%deployok = "1";
							}
							else 
							{
								if(checkDeployArea(%client,$los::position))	
								{
									%deployok = "1";
								}
								else return false;
							}
							if (%deployok == "1")
							{
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteTurret","Turret",DeployableRocket,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Missile Turret #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Missile Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "RocketPack"]++;
								return true;
							}
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
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
	description = "Turret";
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
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			%dataname = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || (%obj == "StaticShape") && ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform")  ))
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableTurret",%num);
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
							if ((%dataname == "BlastWall") || (%dataname == "DeployablePlatform"))
							{
								%deployok = "1";
							}
							else 
							{
								if(checkDeployArea(%client,$los::position))	
								{
									%deployok = "1";
								}
								else return false;
							}
							if (%deployok == "1")
							{
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
								Client::setOwnedObject(%client, %turret);
								Client::setOwnedObject(%client, %player);
								return true;
							}
						} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}


//----------------------------------------------------------------------------

ItemImageData PlasmaTurretDecoyImage
{
	shapeFile = "hellfiregun";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData PlasmaTurretDecoyPack
{
	description = "Turret Decoy";
	shapeFile = "hellfiregun";
	className = "Backpack";
	heading = "fTurrets";
	imageType = PlasmaTurretDecoyImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmaTurretDecoyPack::onDeploy(%player,%item,%pos)
{
	if (PlasmaTurretDecoyPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function PlasmaTurretDecoyPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
	    		%set = newObject("set",SimSet);
			%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
			%num = CountObjects(%set,"PlasmaTurretDecoy",%num);
			deleteObject(%set);
			if($MaxNumTurretsInBox > %num)
			{
		    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,"PlasmaTurretDecoy",%num);
				deleteObject(%set);
				if(0 == %num)
				{
					if (Vector::dot($los::normal,"0 0 1") > 0.7)
					{
						if(checkDeployArea(%client,$los::position))
						{
							%rot = GameBase::getRotation(%player); 
							%turret = newObject("hellfiregun","Turret",PlasmaTurretDecoy,true);
							%teamnum = GameBase::getTeam(%player);
							if (%teamnum == "0")
							{ 	 					
								addToSet("MissionGroup/Teams/team0", %turret);
							}
							else if (%teamnum == "1")
							{ 	 					
								addToSet("MissionGroup/Teams/team1", %turret);
							}
							else if (%teamnum == "2")
							{ 	 					
								addToSet("MissionGroup/Teams/team2", %turret);
							}
							else if (%teamnum == "3")
							{ 	 					
								addToSet("MissionGroup/Teams/team3", %turret);
							}
							else if (%teamnum == "4")
							{ 	 					
								addToSet("MissionGroup/Teams/team4", %turret);
							}
							else if (%teamnum == "5")
							{ 	 					
						  		addToSet("MissionGroup/Teams/team5", %turret);
							}
							else if (%teamnum == "6")
							{ 	 					
								addToSet("MissionGroup/Teams/team6", %turret);
							}
							else if (%teamnum == "7")
							{ 	 					
								addToSet("MissionGroup/Teams/team7", %turret);
							}
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"Plasma Turret #" @ $totalNumDecoys++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Turret Decoy deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[GameBase::getTeam(%player) @ "PlasmaTurretDecoyPack"]++;
							return true;
						}
					}
					else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				} 
				else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
			}
			else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
		}
		else Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------

ItemImageData VulcanPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 3.0;
	firstPerson = false;
};

ItemData VulcanPack
{
	description = "Vulcan Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
        heading = "fTurrets";
	imageType = VulcanPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 1000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function VulcanPack::onUse(%player,%item)
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

function VulcanPack::onDeploy(%player,%item,%pos)
{
	if (VulcanPack::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function VulcanPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
			%obj = getObjectType($los::object);
			%objteam = GameBase::getTeam($los::object);
			%name = GameBase::getDataName($los::object);
			%deployok = "0";
			if (%obj == "InteriorShape" || (%obj == "StaticShape") && ((%name == "BlastWall") || (%name == "DeployablePlatform")  ))
			{
				%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableVulcan",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num)
				{
		    			%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableSentry",%num) + CountObjects(%set,"DeployableTurret",%num) + CountObjects(%set,"DeployableVulcan",%num);
					deleteObject(%set);
					if(0 == %num)
					{
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
							else { %rot = Vector::getRotation($los::normal); }
						}

						if ((%name == "BlastWall") || (%name == "DeployablePlatform"))
						{
							%deployok = "1";
						}
						else 
						{
							if(checkDeployArea(%client,$los::position))	
							{
								%deployok = "1";
							}
							else return false;
						}
						if (%deployok == "1")
						{
				
							%team = Client::getTeam(%client);
							%playerpos = GameBase::getPosition(%client);
							%flagpos = ($teamFlag[%team]).originalPosition;	
							%flagdist = Vector::getDistance(%playerpos,%flagpos);

							for(%i = 0; %i < 4; %i++)
							{
								if (%team != %i)
								{
									%flagpos = ($teamFlag[%i]).originalPosition;
									%flagdist = Vector::getDistance(%playerpos,%flagpos);
									if (%flagdist < 100)
									{
										bottomprint(%client, "You can't deploy that here.");
										return;
									}
									else if (%objteam != "-1")
									{
										if (%objteam != %team)
										{
											bottomprint(%client, "You can't deploy that here.");
											return;
										}
									}
								}
							}
							%flagpos = ($teamFlag[%team]).originalPosition;	
							%flagdist = Vector::getDistance(%playerpos,%flagpos);
//							%rot = GameBase::getRotation(%player); 
							%turret = newObject("remoteTurret","Turret",DeployableVulcan,true);
							addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,$los::position);
							GameBase::setRotation(%turret,%rot);
							Gamebase::setMapName(%turret,"Vulcan Turret #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
							Client::sendMessage(%client,0,"Vulcan Turret deployed");
							playSound(SoundPickupBackpack,$los::position);
							$TeamItemCount[%team @ "VulcanPack"]++;
							//--------------//
							if (%flagdist < 30)
							{
								%client.score += 1;
								%client.turrets += 1;
								Game::refreshClientScore(%client);
								bottomprint(%client, "You receive 1 point for defending the flag.");
							}
							//--------------//
							return true;
						} //checkdeploy
					} else Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				} else Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			} else Client::sendMessage(%client,0,"Can not deploy here");
		} else Client::sendMessage(%client,0,"Deploy position out of range");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
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

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//					MISCELLANY SECTION
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "gMiscellany";
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
  %armor = Player::getArmor (%player);
  %clientId = Player::getClient (%player);
  if (%armor == "sarmor" || %armor == "larmor" || %armor == "lfemale" || %armor == "fsarmor")
  {
    if($matchStarted)
    {
	if(%player.throwTime < getSimTime()) {
	%obj = newObject("","Mine","Boost");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	Client::sendMessage(Player::getClient(%player),0,"You use a Speed Booster."); 
	Player::decItemCount(%player,%item);
      }
    }
  }
  if (%armor == "marmor" || %armor == "mfemale")
  {
    TurretDecoy (%player, %item);
  }

  if (%armor == "harmor" || %armor == "aarmor")
  {
    if($matchStarted)
    {
	if(%player.throwTime < getSimTime()) {
	%client = Player::getClient(%player);
	%obj = newObject("","Mine","AssaultBomb");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	Player::decItemCount(%player,%item);
      }
    }
  }
  else
  if (Beacon::deployShape(%player,%item))
  {
    Player::decItemCount(%player,%item);
  }
}

function TurretDecoy(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
		//	if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"PlasmaTurretDecoy",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"PlasmaTurretDecoy",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("hellfiregun","Turret",PlasmaTurretDecoy,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Turret Decoy #" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Turret Decoy deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "PlasmaTurretDecoy"]++;
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
		//	}
		//	else 
		//		Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "gMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
// class selection grenades		
				%armor = Player::getArmor(%player);
				if (%armor == "sarmor")
                            	%obj = newObject("","Mine","Handgrenade"); 

		     		if (%armor == "larmor" || %armor == "lfemale")
                            	%obj = newObject("","Mine","Concussion"); 

				if (%armor == "marmor" || %armor == "mfemale")
	                        %obj = newObject("","Mine","Firebomb"); 

			      	if (%armor == "harmor")
	                      	%obj = newObject("","Mine","Mortarbomb"); 

			      	if (%armor == "aarmor")
	                      	%obj = newObject("","Mine","Nukebomb"); 

 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));//


		}
	}
}

//----------------------------------------------------------------------------

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

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "gMiscellany";
   shadowDetailMask = 4;
   price = 35;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}




//----------------------------------------------------------------------------
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
	$TeamItemCount[0 @ HoverVehicle] = 0;
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
	$TeamItemCount[1 @ HoverVehicle] = 0;
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
	$TeamItemCount[2 @ HoverVehicle] = 0;
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
	$TeamItemCount[3 @ HoverVehicle] = 0;
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
	$TeamItemCount[4 @ HoverVehicle] = 0;
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
	$TeamItemCount[5 @ HoverVehicle] = 0;
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
	$TeamItemCount[6 @ HoverVehicle] = 0;
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
	$TeamItemCount[7 @ HoverVehicle] = 0;
	$TeamItemCount[7 @ LAPCVehicle] = 0;
	$TeamItemCount[7 @ HAPCVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;

	//=-=-=-- Pantheon v0.3
	
	$TeamItemCount[0 @ RocketPack] = 0;
	$TeamItemCount[1 @ RocketPack] = 0;
	$TeamItemCount[2 @ RocketPack] = 0;
	$TeamItemCount[3 @ RocketPack] = 0;
	$TeamItemCount[4 @ RocketPack] = 0;
	$TeamItemCount[5 @ RocketPack] = 0;
	$TeamItemCount[6 @ RocketPack] = 0;
	$TeamItemCount[7 @ RocketPack] = 0;


	$TeamItemCount[0 @ DumbRocketPack] = 0;
	$TeamItemCount[1 @ DumbRocketPack] = 0;
	$TeamItemCount[2 @ DumbRocketPack] = 0;
	$TeamItemCount[3 @ DumbRocketPack] = 0;
	$TeamItemCount[4 @ DumbRocketPack] = 0;
	$TeamItemCount[5 @ DumbRocketPack] = 0;
	$TeamItemCount[6 @ DumbRocketPack] = 0;
	$TeamItemCount[7 @ DumbRocketPack] = 0;





	$TeamItemCount[0 @ LaserPack] = 0;
	$TeamItemCount[1 @ LaserPack] = 0;
	$TeamItemCount[2 @ LaserPack] = 0;
	$TeamItemCount[3 @ LaserPack] = 0;
	$TeamItemCount[4 @ LaserPack] = 0;
	$TeamItemCount[5 @ LaserPack] = 0;
	$TeamItemCount[6 @ LaserPack] = 0;
	$TeamItemCount[7 @ LaserPack] = 0;

	$TeamItemCount[0 @ DeployableComPack] = 0;
	$TeamItemCount[1 @ DeployableComPack] = 0;
	$TeamItemCount[2 @ DeployableComPack] = 0;
	$TeamItemCount[3 @ DeployableComPack] = 0;
	$TeamItemCount[4 @ DeployableComPack] = 0;
	$TeamItemCount[5 @ DeployableComPack] = 0;
	$TeamItemCount[6 @ DeployableComPack] = 0;
	$TeamItemCount[7 @ DeployableComPack] = 0;
      
	$TeamItemCount[0 @ PlasmaPack] = 0;
	$TeamItemCount[1 @ PlasmaPack] = 0;
	$TeamItemCount[2 @ PlasmaPack] = 0;
	$TeamItemCount[3 @ PlasmaPack] = 0;
	$TeamItemCount[4 @ PlasmaPack] = 0;
	$TeamItemCount[5 @ PlasmaPack] = 0;
	$TeamItemCount[6 @ PlasmaPack] = 0;
	$TeamItemCount[7 @ PlasmaPack] = 0;

	$TeamItemCount[0 @ DeployableTeleport] = 0;
	$TeamItemCount[1 @ DeployableTeleport] = 0;
	$TeamItemCount[2 @ DeployableTeleport] = 0;
	$TeamItemCount[3 @ DeployableTeleport] = 0;
	$TeamItemCount[4 @ DeployableTeleport] = 0;
	$TeamItemCount[5 @ DeployableTeleport] = 0;
	$TeamItemCount[6 @ DeployableTeleport] = 0;
	$TeamItemCount[7 @ DeployableTeleport] = 0;

	$TeamItemCount[0 @ DeployableTeleportDecoy] = 0;
	$TeamItemCount[1 @ DeployableTeleportDecoy] = 0;
	$TeamItemCount[2 @ DeployableTeleportDecoy] = 0;
	$TeamItemCount[3 @ DeployableTeleportDecoy] = 0;
	$TeamItemCount[4 @ DeployableTeleportDecoy] = 0;
	$TeamItemCount[5 @ DeployableTeleportDecoy] = 0;
	$TeamItemCount[6 @ DeployableTeleportDecoy] = 0;
	$TeamItemCount[7 @ DeployableTeleportDecoy] = 0;

	$TeamItemCount[0 @ TeleportDecoyPack] = 0;
	$TeamItemCount[1 @ TeleportDecoyPack] = 0;
	$TeamItemCount[2 @ TeleportDecoyPack] = 0;
	$TeamItemCount[3 @ TeleportDecoyPack] = 0;
	$TeamItemCount[4 @ TeleportDecoyPack] = 0;
	$TeamItemCount[5 @ TeleportDecoyPack] = 0;
	$TeamItemCount[6 @ TeleportDecoyPack] = 0;
	$TeamItemCount[7 @ TeleportDecoyPack] = 0;

	$TeamItemCount[0 @ MarauderVehicle] = 0;
	$TeamItemCount[1 @ MarauderVehicle] = 0;
	$TeamItemCount[2 @ MarauderVehicle] = 0;
	$TeamItemCount[3 @ MarauderVehicle] = 0;
	$TeamItemCount[4 @ MarauderVehicle] = 0;
	$TeamItemCount[5 @ MarauderVehicle] = 0;
	$TeamItemCount[6 @ MarauderVehicle] = 0;
	$TeamItemCount[7 @ MarauderVehicle] = 0;

	$TeamItemCount[0 @ JetVehicle] = 0;
	$TeamItemCount[1 @ JetVehicle] = 0;
	$TeamItemCount[2 @ JetVehicle] = 0;
	$TeamItemCount[3 @ JetVehicle] = 0;
	$TeamItemCount[4 @ JetVehicle] = 0;
	$TeamItemCount[5 @ JetVehicle] = 0;
	$TeamItemCount[6 @ JetVehicle] = 0;
	$TeamItemCount[7 @ JetVehicle] = 0;



	$TeamItemCount[0 @ BlastwallPack] = 0;
	$TeamItemCount[1 @ BlastwallPack] = 0;
	$TeamItemCount[2 @ BlastwallPack] = 0;
	$TeamItemCount[3 @ BlastwallPack] = 0;
	$TeamItemCount[4 @ BlastwallPack] = 0;
	$TeamItemCount[5 @ BlastwallPack] = 0;
	$TeamItemCount[6 @ BlastwallPack] = 0;
	$TeamItemCount[7 @ BlastwallPack] = 0;

	$TeamItemCount[0 @ ShockPack] = 0;
	$TeamItemCount[1 @ ShockPack] = 0;
	$TeamItemCount[2 @ ShockPack] = 0;
	$TeamItemCount[3 @ ShockPack] = 0;
	$TeamItemCount[4 @ ShockPack] = 0;
	$TeamItemCount[5 @ ShockPack] = 0;
	$TeamItemCount[6 @ ShockPack] = 0;
	$TeamItemCount[7 @ ShockPack] = 0;

	$TeamItemCount[0 @ SpringPack] = 0;
	$TeamItemCount[1 @ SpringPack] = 0;
	$TeamItemCount[2 @ SpringPack] = 0;
	$TeamItemCount[3 @ SpringPack] = 0;
	$TeamItemCount[4 @ SpringPack] = 0;
	$TeamItemCount[5 @ SpringPack] = 0;
	$TeamItemCount[6 @ SpringPack] = 0;
	$TeamItemCount[7 @ SpringPack] = 0;

	$TeamItemCount[0 @ OutpostPack] = 0;
	$TeamItemCount[1 @ OutpostPack] = 0;
	$TeamItemCount[2 @ OutpostPack] = 0;
	$TeamItemCount[3 @ OutpostPack] = 0;
	$TeamItemCount[4 @ OutpostPack] = 0;
	$TeamItemCount[5 @ OutpostPack] = 0;
	$TeamItemCount[6 @ OutpostPack] = 0;
	$TeamItemCount[7 @ OutpostPack] = 0;

	$TeamItemCount[0 @ PlatformPack] = 0;
	$TeamItemCount[1 @ PlatformPack] = 0;
	$TeamItemCount[2 @ PlatformPack] = 0;
	$TeamItemCount[3 @ PlatformPack] = 0;
	$TeamItemCount[4 @ PlatformPack] = 0;
	$TeamItemCount[5 @ PlatformPack] = 0;
	$TeamItemCount[6 @ PlatformPack] = 0;
	$TeamItemCount[7 @ PlatformPack] = 0;

	$TeamItemCount[0 @ TreePack] = 0;
	$TeamItemCount[1 @ TreePack] = 0;
	$TeamItemCount[2 @ TreePack] = 0;
	$TeamItemCount[3 @ TreePack] = 0;
	$TeamItemCount[4 @ TreePack] = 0;
	$TeamItemCount[5 @ TreePack] = 0;
	$TeamItemCount[6 @ TreePack] = 0;
	$TeamItemCount[7 @ TreePack] = 0;

	$TeamItemCount[0 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[1 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[2 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[3 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[4 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[5 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[6 @ ForceFieldDoorPack] = 0;
	$TeamItemCount[7 @ ForceFieldDoorPack] = 0;

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

	$TeamItemCount[0 @ VulcanPack] = 0;
	$TeamItemCount[1 @ VulcanPack] = 0;
	$TeamItemCount[2 @ VulcanPack] = 0;
	$TeamItemCount[3 @ VulcanPack] = 0;
	$TeamItemCount[4 @ VulcanPack] = 0;
	$TeamItemCount[5 @ VulcanPack] = 0;
	$TeamItemCount[6 @ VulcanPack] = 0;
	$TeamItemCount[7 @ VulcanPack] = 0;

	$TeamItemCount[0 @ DissectionPack] = 0;
	$TeamItemCount[1 @ DissectionPack] = 0;
	$TeamItemCount[2 @ DissectionPack] = 0;
	$TeamItemCount[3 @ DissectionPack] = 0;
	$TeamItemCount[4 @ DissectionPack] = 0;
	$TeamItemCount[5 @ DissectionPack] = 0;
	$TeamItemCount[6 @ DissectionPack] = 0;
	$TeamItemCount[7 @ DissectionPack] = 0;

  	$TeamItemCount[0 @ MortarTurretPack] = 0;
  	$TeamItemCount[1 @ MortarTurretPack] = 0;
  	$TeamItemCount[2 @ MortarTurretPack] = 0;
  	$TeamItemCount[3 @ MortarTurretPack] = 0;
  	$TeamItemCount[4 @ MortarTurretPack] = 0;
  	$TeamItemCount[5 @ MortarTurretPack] = 0;
  	$TeamItemCount[6 @ MortarTurretPack] = 0;
        $TeamItemCount[7 @ MortarTurretPack] = 0;

	$TeamItemCount[0 @ MechVehicle] = 0;
	$TeamItemCount[1 @ MechVehicle] = 0;
	$TeamItemCount[2 @ MechVehicle] = 0;
	$TeamItemCount[3 @ MechVehicle] = 0;
	$TeamItemCount[4 @ MechVehicle] = 0;
	$TeamItemCount[5 @ MechVehicle] = 0;
	$TeamItemCount[6 @ MechVehicle] = 0;
	$TeamItemCount[7 @ MechVehicle] = 0;

	$TeamItemCount[0 @ MechPack] = 0;
	$TeamItemCount[1 @ MechPack] = 0;
	$TeamItemCount[2 @ MechPack] = 0;
	$TeamItemCount[3 @ MechPack] = 0;
	$TeamItemCount[4 @ MechPack] = 0;
	$TeamItemCount[5 @ MechPack] = 0;
	$TeamItemCount[6 @ MechPack] = 0;
	$TeamItemCount[7 @ MechPack] = 0;

	$TeamItemCount[0 @ ProximityAlarmPack] = 0;
	$TeamItemCount[1 @ ProximityAlarmPack] = 0;
	$TeamItemCount[2 @ ProximityAlarmPack] = 0;
	$TeamItemCount[3 @ ProximityAlarmPack] = 0;
	$TeamItemCount[4 @ ProximityAlarmPack] = 0;
	$TeamItemCount[5 @ ProximityAlarmPack] = 0;
	$TeamItemCount[6 @ ProximityAlarmPack] = 0;
	$TeamItemCount[7 @ ProximityAlarmPack] = 0;

	$TeamItemCount[0 @ SniperPadPack] = 0;
	$TeamItemCount[1 @ SniperPadPack] = 0;
	$TeamItemCount[2 @ SniperPadPack] = 0;
	$TeamItemCount[3 @ SniperPadPack] = 0;
	$TeamItemCount[4 @ SniperPadPack] = 0;
	$TeamItemCount[5 @ SniperPadPack] = 0;
	$TeamItemCount[6 @ SniperPadPack] = 0;
	$TeamItemCount[7 @ SniperPadPack] = 0;

	$TeamItemCount[0 @ DeployableSolarPanel] = 0;
	$TeamItemCount[1 @ DeployableSolarPanel] = 0;
	$TeamItemCount[2 @ DeployableSolarPanel] = 0;
	$TeamItemCount[3 @ DeployableSolarPanel] = 0;
	$TeamItemCount[4 @ DeployableSolarPanel] = 0;
	$TeamItemCount[5 @ DeployableSolarPanel] = 0;
	$TeamItemCount[6 @ DeployableSolarPanel] = 0;
	$TeamItemCount[7 @ DeployableSolarPanel] = 0;

	$TeamItemCount[0 @ SuicidePack] = 0;
	$TeamItemCount[1 @ SuicidePack] = 0;
	$TeamItemCount[2 @ SuicidePack] = 0;
	$TeamItemCount[3 @ SuicidePack] = 0;
	$TeamItemCount[4 @ SuicidePack] = 0;
	$TeamItemCount[5 @ SuicidePack] = 0;
	$TeamItemCount[6 @ SuicidePack] = 0;
	$TeamItemCount[7 @ SuicidePack] = 0;

	$totalnumalarms[0] = 0;
	$totalnumalarms[1] = 0;
	$totalnumalarms[2] = 0;
	$totalnumalarms[3] = 0;
	$totalnumalarms[4] = 0;
	$totalnumalarms[5] = 0;
	$totalnumalarms[6] = 0;
	$totalnumalarms[7] = 0;

	$NukeTeam[0] = 0;
	$NukeTeam[1] = 0;
	$NukeTeam[2] = 0;
	$NukeTeam[3] = 0;
	$NukeTeam[4] = 0;
	$NukeTeam[5] = 0;
	$NukeTeam[6] = 0;
	$NukeTeam[7] = 0;

	//=-=-=-=-


	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
