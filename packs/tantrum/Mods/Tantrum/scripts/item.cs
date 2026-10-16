//----------------------------------------------------------------------------

$ItemFavoritesKey = "";  // Change this if you add new items
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
$AutoUse[Chaingun] = False;
$AutoUse[plasflam] = True;
$AutoUse[Mortar] = False;
$AutoUse[Lightgun] = True;
$AutoUse[Shotgun] = False;
$AutoUse[Latgun] = True;
$AutoUse[DiscLauncher] = True;
$AutoUse[RocketLauncher] = True;
$AutoUse[GrenadeLauncher] = False;
$AutoUse[TargetingLaser] = False;

$nest = false;
$bent = false;
$sony = false;
//$spoonchosen = false;
$nx = false;
$dsf = false;
//$rdrrchosen = false;
//$erchosen = false;


$Use[Blaster] = True;

$ArmorType[Male, MedicArmor] = lfemale;
$ArmorType[Male, SniperArmor] = spyfemale;
$ArmorType[Male, ELFEliteforceArmor] = larmor; 
$ArmorType[Male, PyroArmor] = sarmor;  
$ArmorType[Male, EngineerArmor] = marmor;
$ArmorType[Male, TrooperArmor] = earmor;
$ArmorType[Male, JuggernautArmor] = harmor;
$ArmorType[Male, BotArmor] = tarmor;
$ArmorType[Female, MedicArmor] = lfemale;
$ArmorType[Female, SniperArmor] = spyfemale; 
$ArmorType[Female, ELFEliteforceArmor] = larmor; 
$ArmorType[Female, PyroArmor] = sarmor;  
$ArmorType[Female, EngineerArmor] = marmor;
$ArmorType[Female, TrooperArmor] = earmor;
$ArmorType[Female, JuggernautArmor] = harmor;
$ArmorType[Female, BotArmor] = tarmor;

$ArmorName[lfemale] = MedicArmor;
$ArmorName[spyfemale] = SniperArmor;
$ArmorName[larmor] = ELFEliteforceArmor;
$ArmorName[sarmor] = PyroArmor;
$ArmorName[marmor] = EngineerArmor;
$ArmorName[earmor] = TrooperArmor; 
$ArmorName[harmor] = JuggernautArmor;
$ArmorName[tarmor] = BotArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[TorchAmmo] = 50;
$SellAmmo[BulletAmmo] = 50;
$SellAmmo[NeedleAmmo] = 50;
$SellAmmo[ShotgunShells] = 5;
$SellAmmo[PlasmaAmmo] = 5;
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[vaporAmmo] = 5;
$SellAmmo[repAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[bioAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;

// Limit on number of special Items you can buy
$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[DeployableHealth] = 2;
$TeamItemMax[DeployableTrap] = 2;
$TeamItemMax[DeployableTTrap] = 8;
$TeamItemMax[TurretPack] = 4;
$TeamItemMax[AlfiePack] = 1;
$TeamItemMax[CameraPack] = 4;
$TeamItemMax[RobotPack] = 3;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
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
$WeaponAmmo[Mortar] = Mortar;
$WeaponAmmo[LaserRifle] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[Torch] = torchAmmo;
$WeaponAmmo[RocketLauncher] = torchAmmo;
$WeaponAmmo[RocketLauncher2] = torchAmmo;
$WeaponAmmo[thrower] = throwerAmmo;
$WeaponAmmo[Flamer] = "";
$WeaponAmmo[dagger] = "";
$WeaponAmmo[lightgun] = "";
$WeaponAmmo[lightgun2] = "";
$WeaponAmmo[lightgun3] = "";
$WeaponAmmo[latgun] = "";
$WeaponAmmo[hydo] = "BulletAmmo";
$WeaponAmmo[hydo2] = "BulletAmmo";
$WeaponAmmo[latgun2] = "";
$WeaponAmmo[latgun3] = "";
$WeaponAmmo[WaveGun] = "";
$WeaponAmmo[moondustlauncher]= vaporAmmo;
$WeaponAmmo[moondust2]= vaporAmmo;
$WeaponAmmo[moondust3]= vaporAmmo;
$WeaponAmmo[moondust4]= vaporAmmo;
$WeaponAmmo[repLauncher] = repAmmo;
$WeaponAmmo[bio] = bioAmmo;
$WeaponAmmo[burster] = burstAmmo;
$WeaponAmmo[macGun] = BrotAmmo;
$WeaponAmmo[mac2] = BrotAmmo;
$WeaponAmmo[mac3] = BrotAmmo;
$WeaponAmmo[mac4] = BrotAmmo;
$WeaponAmmo[handlas] = NeedleAmmo;
$WeaponAmmo[hand3] = NeedleAmmo;
$WeaponAmmo[poly] = "";
$WeaponAmmo[Shotgun] = ShotgunShells;

$AutoUse[BotGun] = false;
$WeaponAmmo[BotGun] = BotAmmo; 
$SellAmmo[BotAmmo] = 5;

$AutoUse[BotGunX] = false;
$WeaponAmmo[BotGunX] = BotAmmo; 
$SellAmmo[BotAmmo] = 5;

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = true;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}


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
		if (%item.className == Armor) {
			// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				//teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if(checkResources(%player,%item,1)) {
					//teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					//Player::setArmor(%client,%buyarmor);
					//checkMax(%client,%buyarmor);
					//armorChange(%client);
     				//Player::setItemCount(%client, $ArmorName[%armor], 0);  
     				//Player::setItemCount(%client, %item, 1);  
					//if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
						//fillAmmoPack(%client);	
					//return 1;
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
				if(%item == PyroArmor) {
					buyItem(%client,"GasTankPack");
					buyItem(%client,"plasflam");
					buyItem(%client,"torch");
					buyItem(%client,"flamer");
					buyItem(%client,"PlasmaGun");
					buyItem(%client,"PlasmaAmmo");
					buyItem(%client,"TorchAmmo");
					Client::sendMessage(%client,0,"Bought Pyro Loadout");
				}
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
				if(%item == WaveGun && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought EMP - Auto buying Energy Pack");
				}
				if(%item == poly && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Taser - Auto buying Energy Pack");
				}
				if(%item == plasflam && Player::getItemCount(%client,"GasTankPack") == 0) {
					buyItem(%client,"GasTankPack");
					Client::sendMessage(%client,0,"Bought Flame Thrower - Auto buying Gas Tank");
				}
				if(%item == Flamer && Player::getItemCount(%client,"GasTankPack") == 0) {
					buyItem(%client,"GasTankPack");
					Client::sendMessage(%client,0,"Bought Torch Launcher - Auto buying Gas Tank");
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
	if (%item == "moondustLauncher") {
   Player::setItemCount(%clientId,Mortar,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,bio,0);
   Player::setItemCount(%clientId,Macgun,0);
   Player::setItemCount(%clientId,MortarAmmo,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,VaporAmmo,0);
   Player::setItemCount(%clientId,bioAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,EnergyPack,0);
   Player::setItemCount(%clientId,RepairKit,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
	}
	if (%item == "macGun") {
   Player::setItemCount(%clientId,Mortar,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,bio,0);
   Player::setItemCount(%clientId,Macgun,0);
   Player::setItemCount(%clientId,MortarAmmo,0);
   Player::setItemCount(%clientId,brotAmmo,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,VaporAmmo,0);
   Player::setItemCount(%clientId,bioAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,EnergyPack,0);
   Player::setItemCount(%clientId,RepairKit,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
	}
	if (%item == "dagger") {
   Player::setItemCount(%clientId,lightgun,0);
   Player::setItemCount(%clientId,SniperRifle,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,SniperAmmo,0);
   Player::setItemCount(%clientId,Claking,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "plasflam") {
   Player::setItemCount(%clientId,torch,0);
   Player::setItemCount(%clientId,flamer,0);
   Player::setItemCount(%clientId,PlasmaGun,0);
   Player::setItemCount(%clientId,PlasmaAmmo,0);
   Player::setItemCount(%clientId,TorchAmmo,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,GasTankPack,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "WaveGun") {
   Player::setItemCount(%clientId,poly,0);
   Player::setItemCount(%clientId,burster,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,BursterAmmo,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,EnergyPack,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "talepack") {
   Player::setItemCount(%clientId,GrenadeLauncher,0);
   Player::setItemCount(%clientId,Chaingun,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,GrenadeAmmo,0);
   Player::setItemCount(%clientId,BulletAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,TalePack,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "CameraPack") {
   Player::setItemCount(%clientId,GrenadeLauncher,0);
   Player::setItemCount(%clientId,Chaingun,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,GrenadeAmmo,0);
   Player::setItemCount(%clientId,BulletAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "TeleportPack") {
   Player::setItemCount(%clientId,GrenadeLauncher,0);
   Player::setItemCount(%clientId,Chaingun,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,GrenadeAmmo,0);
   Player::setItemCount(%clientId,BulletAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "HealthTreePack") {
   Player::setItemCount(%clientId,GrenadeLauncher,0);
   Player::setItemCount(%clientId,Chaingun,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,GrenadeAmmo,0);
   Player::setItemCount(%clientId,BulletAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "TurretPack") {
   Player::setItemCount(%clientId,GrenadeLauncher,0);
   Player::setItemCount(%clientId,Chaingun,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,GrenadeAmmo,0);
   Player::setItemCount(%clientId,BulletAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "Girl") {
   Player::setItemCount(%clientId,GrenadeLauncher,0);
   Player::setItemCount(%clientId,Chaingun,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,GrenadeAmmo,0);
   Player::setItemCount(%clientId,BulletAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "RepairPack") {
   Player::setItemCount(%clientId,lightgun,0);
   Player::setItemCount(%clientId,Chaingun,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,BulletAmmo,0);
   Player::setItemCount(%clientId,Flagger,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
	if (%item == "RocketLauncher") {
   Player::setItemCount(%clientId,latgun,0);
   Player::setItemCount(%clientId,GrenadeLauncher,0);
   Player::setItemCount(%clientId,RocketLauncher,0);
   Player::setItemCount(%clientId,DiscLauncher,0);
   Player::setItemCount(%clientId,Shotgun,0);
   Player::setItemCount(%clientId,DiscAmmo,0);
   Player::setItemCount(%clientId,GrenadeAmmo,0);
   Player::setItemCount(%clientId,TorchAmmo,0);
   Player::setItemCount(%clientId,ShotgunShells,0);
   Player::setItemCount(%clientId,EnergyPack,0);
   Player::setItemCount(%clientId,MineAmmo,0);
   Player::setItemCount(%clientId,Grenade,0);
   Player::setItemCount(%clientId,RepairKit,0);
	}
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
			else if (%item == talepack) {
				//Client::sendMessage(%client,0,"This is not only a test");
				if (%player.tfield) {
		   			schedule("deleteObject(" @ %player.laghte @ ");", 1.25, %player.laghte);
					//Client::sendMessage(%client,0,"Testing my work once again");
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

$NextWeapon[bio] = moondustLauncher;                                      ////Argon Spread
$NextWeapon[moondustLauncher] = Mortar;                                   ///Moondust Cannon
$NextWeapon[Mortar] = RocketLauncher;                                     //Mortar
$NextWeapon[RocketLauncher] = DiscLauncher;                              //Rocket Launcher
$NextWeapon[DiscLauncher] = GrenadeLauncher;                            //Disc Launcher
$NextWeapon[GrenadeLauncher] = Chaingun;                               //Nade Launcher
$NextWeapon[Chaingun] = Shotgun;                                      //Chain
$NextWeapon[Shotgun] = macGun;                                       //Shotgun
$NextWeapon[macGun] = PlasmaGun;                                    //MachineGuns
$NextWeapon[PlasmaGun] = Torch;                                    //Plasma Gun
$NextWeapon[Torch] = plasflam;                                    //Hand Rockets
$NextWeapon[plasflam] = Flamer;                                  //Flame Thrower
$NextWeapon[Flamer] = WaveGun;                                  //Torch Grenade Launcher
$NextWeapon[WaveGun] = Burster;                                //Emp Shock
$NextWeapon[Burster] = poly;                                  //Burster
$NextWeapon[poly] = dagger;                                  //taser
$NextWeapon[dagger] = SniperRifle;                          //railgun
$NextWeapon[SniperRifle] = lightgun;                       //sniperrifle
$NextWeapon[lightgun] = latgun;                           //zapper for lfemale
$NextWeapon[latgun] = thrower;                           //zapper for larmor
$NextWeapon[thrower] = energyrifle;                     //suicide bomb    
$NextWeapon[energyrifle] = hydo;                       //work dam you   
$NextWeapon[hydo] = repLauncher;                     ///new gyp weap  
$NextWeapon[repLauncher] = bio;                    ////repair gun

$PrevWeapon[moondustLauncher] = bio;
$PrevWeapon[Mortar] = moondustLauncher;
$PrevWeapon[RocketLauncher] = Mortar;
$PrevWeapon[DiscLauncher] = RocketLauncher;
$PrevWeapon[GrenadeLauncher] = DiscLauncher;
$PrevWeapon[Chaingun] = GrenadeLauncher;
$PrevWeapon[Shotgun] = Chaingun;
$PrevWeapon[macGun] = Shotgun;
$PrevWeapon[PlasmaGun] = macGun;
$PrevWeapon[Torch] = PlasmaGun;
$PrevWeapon[plasflam] = Torch;
$PrevWeapon[Flamer] = plasflam;
$PrevWeapon[WaveGun] = Flamer;
$PrevWeapon[Burster] = WaveGun;
$PrevWeapon[poly] = Burster;
$PrevWeapon[dagger] = poly;
$PrevWeapon[SniperRifle] = dagger;
$PrevWeapon[lightgun] = SniperRifle;
$PrevWeapon[latgun] = lightgun;
$PrevWeapon[thrower] = latgun;
$PrevWeapon[energyrifle] = thrower;
$PrevWeapon[hydo] = energyrifle;
$PrevWeapon[repLauncher] = hydo;
$PrevWeapon[bio] = repLauncher;

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
   validateShape = true;

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

ItemData MedicArmor { heading = "aArmor"; description = "Medic"; className = "Armor"; price = 425; };
ItemData SniperArmor { heading = "aArmor"; description = "Assassin"; className = "Armor"; price = 575; };
ItemData ELFEliteforceArmor { heading = "aArmor"; description = "Gyp"; className = "Armor"; price = 425; };
ItemData PyroArmor { heading = "aArmor"; description = "Pyro"; className = "Armor"; price = 425; };
ItemData EngineerArmor { heading = "aArmor"; description = "Engineer"; className = "Armor"; price = 575; };
ItemData TrooperArmor { heading = "aArmor"; description = "Trooper"; className = "Armor"; price = 175; };
ItemData JuggernautArmor { heading = "aArmor"; description = "Juggernaut"; className = "Armor"; price = 700; };
ItemData BotArmor { heading = "aArmor"; description = "Robot Shell"; className = "Armor"; price = 175; };

ItemData ScoutVehicle { description = "Assault Jet"; className = "Vehicle"; heading = "aVehicle"; price = 600; };
ItemData HAPCVehicle { description = "War Taxi"; className = "Vehicle"; heading = "aVehicle"; price = 875; };

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle { description = "Assault Jet"; className = "Vehicle"; heading = "aVehicle"; price = 600; }; 
ItemData HAPCVehicle { description = "War Taxi"; className = "Vehicle"; heading = "aVehicle"; price = 875; };

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
			Player::mountItem(%player,%item,$WeaponSlot);
			%client = Player::getClient(%player);
			if(Client::getControlObject(%client) == %player)
				if(%client.hv == 0)
					bottomprint(%client, "<jc><f2>"@%item.description, 0.6);
		}
		else {
			if (Player::getItemCount(%player,%ammo) > 0) {
				Player::mountItem(%player,%item,$WeaponSlot);
				%client = Player::getClient(%player);
				if(Client::getControlObject(%client) == %player)
					if(%client.hv == 0)
						bottomprint(%client, "<jc><f2>"@%item.description, 0.6);
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
$ItemMax[harmor, Twig] = 0;
$ItemMax[larmor, Twig] = 0;
$ItemMax[lfemale, Twig] = 0;
$ItemMax[marmor, Twig] = 1;
$ItemMax[sarmor, Twig] = 0;
$ItemMax[tarmor, Twig] = 0;
$ItemMax[earmor, Twig] = 0;
$ItemMax[spyfemale, Twig] = 0;
$TeamItemMax[Twig] = 1;

ItemImageData TwigImage
{
        shapeFile = "flag";//newdoor5
        mountPoint = 2;
        //mountOffset = { -0.375, 0, 0 };
        //mountRotation = { 0, 1.57, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData Twig
{
        description = "Flag Mine";
        shapeFile = "Flag";
        className = "Backpack";
        heading = "fDepoyables";
        imageType = TwigImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 50;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function Twig::onMount(%player,%item){
		%client = Player::getClient(%player);
		%AmmoCount = (Player::getItemCount(%player,Seed));
		if(%AmmoCount == 0 && Client::isItemShoppingOn(%client,%item)){	

		buyItem(%client,Seed);
		//Client::sendMessage(%client,0,"Nothing");
		}
	}



function Twig::onUse(%player,%item)
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

function Twig::onDeploy(%player,%item,%pos)
{
        if (Twig::deployShape(%player,%item))
        {
	%AmmoCount = ( Player::getItemCount(%player,Seed)) ;
	if(%AmmoCount)Player::decItemCount(%player,Seed);

	else Player::decItemCount(%player,%item);
        }
}
function Twig::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
	%AmmoCount = ( Player::getItemCount(%player,Seed)+1) ;
	if(%AmmoCount){
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
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
					%xpos = getWord($los::position,0);
					%ypos = getWord($los::position,1);
					%zpos = getWord($los::position,2);
	%teamc = GameBase::getTeam(%client);
	%flagc = $teamFlag[%teamc];
	%flagpos = GameBase::getPosition(%flagc);
					%xflagpos = getWord(%flagpos,0);
					%yflagpos = getWord(%flagpos,1);
					%zflagpos = getWord(%flagpos,2);
      ///Testing           Client::sendMessage(%client,0,"X-Coordinate:  " @ %xpos @ " Flag X: " @ %xflagpos @ ".");
	%answer = %xflagpos - %xpos;
	%answer1 = %zflagpos - %zpos;
	%answer2 = %yflagpos - %ypos;
	%thisbooler = 0;
	%thisybooler = 0;
			if (%answer >= 10 || %anser <= -10) {
				%thisbooler = 1;
			}
			else {
				%thisbooler = 0;
			}
			if (%answer2 >= 10 || %answer2 <= -10) {
				%thisbooler = 1;
			}
			else {
				%thisbooler = 0;
			}
			if (%answer1 >= 10 || %answer1 <= -10) {
				%thisybooler = 1;
			}
			else {
				%thisybooler = 0;
			}
			if (%thisbooler == 1 || %thisybooler == 1) {
	                  %camera = newObject("Twig","StaticShape",TwigShape,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
                              Gamebase::setMapName(%camera,"Flag Mine ." @ Client::getName(%client));
					if(!$build)Client::sendMessage(%client,0,"Flag Mine Deployed");
					playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "Twig"]++;
					$Twig++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed Flag Mine ");
					return true;

                        }
			else if (%thisbooler == 0 || %thisybooler == 0) {
		 		Client::sendMessage(%client,0,"Your Flagstand is too close to deploy a Flag Mine.");
			}
		}
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot Deploy Here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
}

StaticShapeData TwigShape
{
        shapeFile = "flag";
        debrisId = flashDebrisLarge;
        maxDamage = 0.1;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Flag Mine";
};




function TwigShape::onDestroyed(%this)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "Flag Mine"]--;

}

function TwigShape::onCollision(%this,%obj){
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%TwigTeam = GameBase::getTeam(%this);
		if(%TwigTeam != %playerTeam){
		%dlevel = GameBase::getDamageLevel(%obj) + 0.2;
		%data = GameBase::getDataName(%this);
		GameBase::setDamageLevel(%this, %data.maxDamage);
		GameBase::setDamageLevel(%obj, %dlevel); 
		Player::setDamageFlash(%obj,0.5);
	if(Player::isDead(%obj)){
		%name = Client::getName(%c); 
		Messageall(0,%name@" thought he was real slick."); 
 		playNextAnim(%obj); 
		//Player::blowUp(%obj); 
		//Player::kill(%obj); 
	}
		return;
		}
	TwigShape::openDoor(%this);
	client::sendmessage(%c, 0, "~wmale1.wdsgst4.wav"); 
	return;
}


function TwigShape::openDoor(%this) {

	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -2");
	GameBase::setPosition(%this,%pos);
	schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
	schedule("TwigShape::closeDoor("@%this@");",1);
}

function TwigShape::closeDoor(%this) {
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 2");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);
	schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.05);
}

ItemImageData FlaggerImage { 
	shapeFile = "flag"; 
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };

	lightType = 2;   
	lightRadius = 4.5;
	lightTime = 1.25;
	lightColor = { 1, 1, 1};
}; 

ItemData Flagger { description = "Flag Decoy"; className = "Tool"; heading = "iSpecial";
shadowDetailMask = 4; shapeFile = "flag"; imageType = FlaggerImage; price = 200; showWeaponBar = false; };

function Flagger::onUnmount(%player,%imageSlot) {
	if(Player::getItemCount(%player, Flag)) Player::mountItem(%player,Flag,$FlagSlot); 
}

function Flagger::onUse(%player,%item)
{
	%fsitem = Player::getMountedItem(%player, $FlagSlot);
	if(%fsitem == -1) {
		Player::mountItem(%player,Flagger,$FlagSlot); 
		Client::sendMessage(Player::getClient(%player),0,"Flag Decoy On"); 	
	} else if(%fsitem == Flagger) {			
		Player::unmountItem(%player,$FlagSlot); 
		Client::sendMessage(Player::getClient(%player),0,"Flag Decoy Off"); 	
	}
}

$TeamItemMax[Girl] = 1;

ItemImageData GirlImage
{
        shapeFile = "remoteturret";
        mountPoint = 0;
        
        mass = 1.5;
        firstPerson = false;
};

ItemData Girl
{
        description = "Hologram";
        shapeFile = "remoteturret";
        className = "Backpack";
        heading = "fDeployables";
        imageType = GirlImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 25;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function Girl::onUse(%player,%item)
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

function Girl::onDeploy(%player,%item,%pos)
{
        if (Girl::deployShape(%player,%item)&& !$build)
        {
                Player::decItemCount(%player,%item);
        }
}
function Girl::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]|| $build) {
                if (GameBase::getLOSInfo(%player,3)) {

                        %obj = getObjectType($los::object);
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
					%xpos = getWord($los::position,0);
					%ypos = getWord($los::position,1);
					%zpos = getWord($los::position,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot + 3.14159;%zpos += 1.1;//floor
				}
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;%zpos -= 1.1;//ceiling
					}
					else {
						%rot = Vector::getRotation($los::normal);//other
					}
				}

	                  %camera = newObject("Girl","StaticShape",GirlShape,true);
		//	%teamc = GameBase::getTeam(%player);
		//	%pointc = "instant Marker 'Drop Point1' {
			//	dataBlock = 'DropPointMarker';
		//		name = 'FortSpawn';
			//	position = %xpos @ ' ' @ %ypos @ ' ' @ %zpos;
		//		rotation = %prot;
		//		};";
	   	//      addToSet("MissionGroup/Teams/" @ %teamc @ "/DropPoints/Random", %pointc);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);				
					GameBase::setPosition(%camera,%xpos@" "@%ypos@" "@%zpos);
                              Gamebase::setMapName(%camera,"Hologram ." @ Client::getName(%client));
					if(!$build)Client::sendMessage(%client,0,"Hologram deployed");
					playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "Girl"]++;
					$Girl++;
			echo("MSG: ",Client::getName(%client)," CL# ",%client," deployed a Hologram");
					return true;
					}
                       else {
			GameBase::playSound(%player, usepack, 0);
			if (!$build) Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}

StaticShapeData GirlShape
{
        shapeFile = "harmor";//newdoor5,elevator_4x4,elevpad2,mainpad,logo
        debrisId = defaultDebrisLarge;
        maxDamage = 1.0;
        visibleToSensor = true;
        isTranslucent = true;
        description = "Clone";
};




function GirlShape::onDestroyed(%this, %player)
{
   StaticShape::onDestroyed(%this);
   $TeamItemCount[GameBase::getTeam(%this) @ "Girl"]--;
}

function GirlShape::onCollision(%this,%obj){
	if(getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%GirlTeam = GameBase::getTeam(%this);
		if(%GirlTeam != %playerTeam){
			return;
		}
	GirlShape::openDoor(%this);
	client::sendmessage(%c, 0, "~wmale1.whello.wav");
	schedule("Client::sendMessage("@%c@", 0,\"~wmale1.wbye.wav\");", 0.50);
	return;
	}


function GirlShape::openDoor(%this) {

	GameBase::startfadeout(%this);
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 4");
	GameBase::setPosition(%this,%pos);
	//schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.05);
	schedule("GirlShape::closeDoor("@%this@");",1);
	}

function GirlShape::closeDoor(%this) {
	%pos=GameBase::getPosition(%this);
	%pos=Vector::add(%pos,"0 0 -4");
	GameBase::setPosition(%this,%pos);
	GameBase::startfadein(%this);

	}

ItemImageData HealthMinePackImage
{
	shapeFile = "bigtwig";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData HealthMinePack
{
	description = "Life Tree";
	shapeFile = "bigtwig";
	className = "repair";
    heading = "fDeployables";
	imageType = HealthMinePackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HealthMinePack::onUse(%player,%item)
{
		Player::deployItem(%player,%item);
}

function HealthMinePack::onDeploy(%player,%item,%pos)
{
	if (HealthMinePack::deployShape(%player,"Life Tree",DeployableHealth,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableHealth"]++;
	}
}

function HealthMinePack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableHealth"] < $TeamItemMax[DeployableHealth]) {
		if (GameBase::getLOSInfo(%player,10)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("Life Tree","StaticShape",%shape,true);
                        addToSet("MissionCleanup/Teleports", %sensor);
				addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						%pos = Vector::add($los::position,"0 0 0");
						echo("LOS pos " @ $los::position @ " " @ %pos);
						GameBase::setPosition(%sensor,%pos);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						%sensor.disabled = false;
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

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ DeployableHealth] = 0;
}	

StaticShapeData DeployableHealth
{
    className = "DeployableHealth";
	damageSkinData = "objectDamageSkins";

	shapeFile = "tree1";
	maxDamage = 0.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
    explosionId = debrisExpsmall;
    debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};													

function RemoveBeam(%b)
{
	deleteObject(%b);
}

function DeployableHealth::onCollision(%this,%obj,%player)
{
	GameBase::repairDamage(%obj,0.125);
        Client::sendMessage(%player, 0, ": ...Healing... :");
}

function DeployableHealth::onDestroyed(%this,%obj)
{
}


ItemImageData teleportpackImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData teleportpack
{
	description = "Portal";
	shapeFile = "sensor_small";
	className = "Backpack";
    heading = "fDeployables";
	imageType = teleportpackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function teleportpack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function teleportpack::onDeploy(%player,%item,%pos)
{
	if (teleportpack::deployShape(%player,"Portal",DeployableTeleport,%item)) {
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

function teleportpack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) {
		if (GameBase::getLOSInfo(%player,10)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("Portal","StaticShape",%shape,true);
						//%sensor1 = newObject("Touch","StaticShape",DeployableToucher,true);
						CreateteleportSimSet();
                        addToSet("MissionCleanup/Teleports", %sensor);
				addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						//GameBase::setTeam(%sensor1,GameBase::getTeam(%player));
						%pos = Vector::add($los::position,"0 0 0");
						echo("LOS pos " @ $los::position @ " " @ %pos);
						GameBase::setPosition(%sensor,%pos);
						Gamebase::setMapName(%sensor,%name);
						//GameBase::setPosition(%sensor1,%pos);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						%sensor.disabled = false;
						playSound(SoundPickupBackpack,$los::position);

						%beam = newObject("","StaticShape",ElectricalBeamBig,true);
						//%stat = newObject("","StaticShape",Flagstand,true);
                        		addToSet("MissionCleanup", %beam);
                        		addToSet("MissionCleanup", %stat);
						GameBase::setTeam(%beam,GameBase::getTeam(%player));
						GameBase::setPosition(%beam,%pos);
						%sensor.beam1 = %beam;

						

//				            schedule("DeployableTeleport::Destruct("@%sensor@");",600);
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

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ DeployableTeleport] = 0;
}

StaticShapeData DeployableTeleport
{
    className = "DeployableTeleport";
	damageSkinData = "objectDamageSkins";

	shapeFile = "sensor_small";
	maxDamage = 0.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
    explosionId = debrisExpsmall;
    debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};


StaticShapeData DeployableToucher
{
    className = "DeployableToucher";
	damageSkinData = "objectDamageSkins";

	shapeFile = "Teleporter";
	maxDamage = 0.75;
	maxEnergy = 200;

   	mapFilter = 2;
	visibleToSensor = true;
    explosionId = debrisExpsmall;
    debrisId = flashDebrisLarge;

	lightRadius = 12.0;
	lightType=2;
	lightColor = {1.0,0.2,0.2};
};


				
function RemoveBeam(%b)
{
	deleteObject(%b);
}				

function DeployableTeleport::Destruct(%this)
{
    //CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
}
														 
function DeployableTeleport::onDestroyed(%this)
{
      schedule("RemoveBeam("@%this.beam1@");",1);
      

   // CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);

    $TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]--;

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
        if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
        {
//        echo("Applying damage to mate");
        GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		return;
        }
    }
}

function DeployableTeleport::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
	{
        return;
	}

    if(Player::isDead(%obj))
	{
        return;
	}

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	
    if(%teleTeam != %playerTeam)
	{
        Client::SendMessage(%c,0,"Access Denied - Wrong team.~waccess_denied.wav");
        return;
	}

    if(%this.disabled == true)
	{
        Client::SendMessage(%c,0,"...Recharging Teleport Beam...~waccess_denied.wav");

        return;
	}

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
	  if(GameBase::getTeam(%o) == %playerteam && %o != %this)
        {
			GameBase::playSound(%o,ForceFieldOpen,0);
			GameBase::playSound(%this,ForceFieldOpen,0);
            	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
	            %o.Disabled = true;
      	      %this.Disabled = true;
		//	GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			if(floor(getRandom() * 55) == 0)
			{
                    Client::SendMessage(%c,0,"...Teleportation cloning error...");
		        GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			}
			else
			{
		            schedule("DeployableTeleport::Reenable("@%o@");",5);
      		      schedule("DeployableTeleport::Reenable("@%this@");",5);
			}
			return;
        }
    }
    Client::SendMessage(%c,0,"No Teleport Destination - Another portal is needed.~waccess_denied.wav");
}

function DeployableTeleport::Reenable(%this)
{
	%this.disabled = false;
}

function RemoveBeam(%b)
{
	deleteObject(%b);
}				

function DeployableToucher::Destruct(%this)
{
    //CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
}
														 
function DeployableToucher::onDestroyed(%this)
{

   // CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);


    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
        if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
        {
//        echo("Applying damage to mate");
        GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
		return;
        }
    }
}

function DeployableToucher::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
	{
        return;
	}

    if(Player::isDead(%obj))
	{
        return;
	}

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);

	
    if(%teleTeam != %playerTeam)
	{
        Client::SendMessage(%c,0,"Access Denied - Wrong team.~waccess_denied.wav");
        return;
	}

    if(%this.disabled == true)
	{
        Client::SendMessage(%c,0,"...Recharging Teleport Beam...~waccess_denied.wav");

        return;
	}

    %teleset = nameToID("MissionCleanup/Teleports");

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
	  if(GameBase::getTeam(%o) == %playerteam && %o != %this)
        {
			GameBase::playSound(%o,ForceFieldOpen,0);
			GameBase::playSound(%this,ForceFieldOpen,0);
            	GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
	            %o.Disabled = true;
      	      %this.Disabled = true;
		//	GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			if(floor(getRandom() * 55) == 0)
			{
                    Client::SendMessage(%c,0,"...Teleportation cloning error...");
		        GameBase::applyDamage(%obj,$CrushDamageType,0.15,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
			}
			else
			{
		            schedule("DeployableToucher::Reenable("@%o@");",5);
      		      schedule("DeployableToucher::Reenable("@%this@");",5);
			}
			return;
        }
    }
    Client::SendMessage(%c,0,"No Teleport Destination - Another portal is needed.~waccess_denied.wav");
}

function DeployableToucher::Reenable(%this)
{
	%this.disabled = false;
}

ItemImageData TrapPackImage
{
	shapeFile = "mine";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData TrapPack
{
	description = "Foot-Trap";
	shapeFile = "mine";
	className = "Ammo";
    heading = "fDeployables";
	imageType = TrapPackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 3200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TrapPack::onUse(%player,%item)
{
		Player::deployItem(%player,%item);
}

function TrapPack::onDeploy(%player,%item,%pos)
{
	if (TrapPack::deployShape(%player,"Foot-Trap",DeployableTrap,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTrap"]++;
	}
}

function TrapPack::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTrap"] < $TeamItemMax[DeployableTrap]) {
		if (GameBase::getLOSInfo(%player,10)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform") {

				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("Foot-Trap","StaticShape",%shape,true);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						%pos = Vector::add($los::position,"0 0.5 0");
						echo("LOS pos " @ $los::position @ " " @ %pos);
						%rot = "0 3.14 0";
						GameBase::setPosition(%sensor,%pos);
						GameBase::setRotation(%sensor,%rot);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						%sensor.disabled = false;
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

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ DeployableTrap] = 0;
}	

StaticShapeData DeployableTrap
{
    className = "DeployableTrap";
	damageSkinData = "objectDamageSkins";

	shapeFile = "mine";
	maxDamage = 0.75;
	maxEnergy = 100;

   	mapFilter = 2;
	visibleToSensor = true;
    explosionId = debrisExpsmall;
    debrisId = flashDebrisLarge;

	lightRadius = 4.0;
	lightType = 2;
	lightColor = {1.0,0.2,0.2};
};													

function RemoveTrap(%b)
{
	deleteObject(%b);
}

function DeployableTrap::onCollision(%this,%obj,%player)
{
 Client::sendMessage(Player::getClient(%player),0,"- You have been Trapped! -");
	createCell(%player);
}

function createCell(%player)
{
		if (GameBase::getLOSInfo(%player,10)) {
						%sens = newObject("Trap",DeployableTTrap,%shape,true);
						%pos = Vector::add($los::position,"2 0 0");
						echo("LOS pos " @ $los::position @ " " @ %pos);
						GameBase::setPosition(%sens,%pos);
						Gamebase::setMapName(%sens,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						%sens.disabled = false;
						playSound(SoundPickupBackpack,$los::position);
		}
}

StaticShapeData DeployableTTrap
{
    className = "DeployableTTrap";
	damageSkinData = "objectDamageSkins";

	shapeFile = "forcefield_3x4";
	maxDamage = 0.75;
	maxEnergy = 100;

   	mapFilter = 2;
	visibleToSensor = true;
    explosionId = debrisExpsmall;
    debrisId = flashDebrisLarge;

	lightRadius = 4.0;
	lightType = 2;
	lightColor = {0,0,2};
};

function DeployableTrap::onDestroyed(%this,%obj)
{
	RemoveTrap(%this);
}

////---------------------------------------------------------------------------------------------------

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

ItemData repAmmo { description = "Scrap Metal"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 3; }; 

ItemData NeedleAmmo { description = "Needles"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; }; 

ItemData BrotAmmo { description = "Machinegun Bullets"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; }; 

ItemData torchAmmo { description = "Rocket"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; }; 

ItemData ShotgunShells { description = "Shotgun Shells"; className = "Ammo"; shapeFile = "ammo2"; heading = "xAmmunition"; shadowDetailMask = 4; price = 5; }; 

$sgunSlotA=4;

ItemImageData ShotgunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; mountOffset = {-0.065, 0, 0}; mountRotation = {0, -1, 0}; ammoType = ShotgunShells; reloadTime = 0.45; accuFire = false; fireTime = 0.45; sfxFire = SoundFireChaingun; sfxActivate = SoundPickUpWeapon; }; 

ItemData Shotgun { heading = "bProjectile Weapons"; description = "Shotgun"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "ammopack"; shadowDetailMask = 4; imageType = ShotgunImage; price = 125; showWeaponBar = true; }; 

ItemImageData sgun2Image { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; mountOffset = {-0.085, 0, 0}; mountRotation = {0, 1, 0}; ammoType = ShotgunShells; reloadTime = 0.45; accuFire = false; fireTime = 0.45; sfxActivate = SoundPickUpWeapon; }; 

ItemData sgun2 { heading = "bProjectile Weapons"; description = "Shotgunextra"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "ammopack"; shadowDetailMask = 4; imageType = sgun2Image; price = 125; showWeaponBar = true; }; 

$sgunSlotA=4;

function Shotgun::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, sgun2,$sgunSlotA);
}

function Shotgun::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$sgunSlotA);
}

function ShotgunImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Shotgunshells,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("gunbullet",%trans,%player,%vel,%player); 
	Projectile::spawnProjectile("gunbullet1",%trans,%player,%vel,%player);
	Projectile::spawnProjectile("gunbullet2",%trans,%player,%vel,%player);
	Projectile::spawnProjectile("gunbullet3",%trans,%player,%vel,%player);
	Projectile::spawnProjectile("gunbullet4",%trans,%player,%vel,%player);
	Projectile::spawnProjectile("gunbullet5",%trans,%player,%vel,%player);
	Projectile::spawnProjectile("FarterShell",%trans,%player,%vel,%player);
	if(!$Firingshotgun[%client]) 
		Checkshotgun(%client, %player); 
}

function Shotgun::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, sgun2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckShotgun(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Shotgun")) 
	{	Player::trigger(%player,$sgunSlotA,true); 
		schedule("CheckShotgun(" @ %client @ "," @ %player @ ");",0.1); 
		$Firingshotgun[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$sgunSlotA,false); 
		$Firingshotgun[%client] = false; 
	} 
}

ItemImageData handlasImage {
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0, 3.14, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = NeedleAmmo;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.6, 0, 1 };
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData handlas { description = "Needler"; className = "Weapon"; shapeFile = "repairgun"; hudIcon = "chain"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = handlasImage; price = 150; showWeaponBar = true; }; 

function handlasImage::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[handlas]);
	if(%AmmoCount)
	{
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1500))
		{
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Projectile::spawnProjectile("NeedlerMissile",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[handlas],1);
         			%player.tafei = GameBase::getPosition(%player);
	 			playSound(SoundFireBlaster, %player.tafei);
				%one = 1;
				//h2Image::choice(%one, %player, %vel, $los::object);
				
			}
			else
			{
				Projectile::spawnProjectile("NeedleRocket",%trans,%player,%vel);
				Player::decItemCount(%player,$WeaponAmmo[handlas],1);
         			%player.tafei = GameBase::getPosition(%player);
	 			playSound(SoundFireBlaster, %player.tafei);
				%two = 2;
				//h2Image::choice(%two, %player, %vel, $los::object);
			}
		}
		else if(!GameBase::getLOSInfo(%player,1500))
		{
			Projectile::spawnProjectile("NeedleRocket",%trans,%player,%vel);
			Player::decItemCount(%player,$WeaponAmmo[handlas],1);
         			%player.tafei = GameBase::getPosition(%player);
	 			playSound(SoundFireBlaster, %player.tafei);
				%three = 3;
				//h2Image::choice(%three, %player, %vel, $los::object);
		}
		if(!$Firinghandlas[%client]) {
			Checkhandlas(%client, %player);
		}
	}
	else {}
}


ItemImageData h2Image {
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { -0.95, 0, 0 };
	mountRotation = { 0, 3.14, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = NeedleAmmo;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.6, 0, 1 };
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData h2 { description = "Needler2"; className = "Weapon"; shapeFile = "repairgun"; hudIcon = "chain"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = h2Image; price = 150; showWeaponBar = true; }; 

function h2Image::choice(%chosen, %player, %vel, $los::object)
{
	if (%chosen == 1) {
		Projectile::spawnProjectile("NeedleMissile",%trans,%player,%vel,$los::object);
		Player::decItemCount(%player,$WeaponAmmo[handlas],1);
	}
	else if (%chosen == 2) {
		Projectile::spawnProjectile("NeedleRocket",%trans,%player,%vel);
		Player::decItemCount(%player,$WeaponAmmo[handlas],1);
	}
	else if (%chosen == 3) {
		Projectile::spawnProjectile("NeedleRocket",%trans,%player,%vel);
		Player::decItemCount(%player,$WeaponAmmo[handlas],1);
	}
}

$handSlot=4;

function handlas::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, h2,$handSlot);
}

function handlas::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$handSlot);
}

function handlas::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, h2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function Checkhandlas(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "handlas")) 
	{	Player::trigger(%player,$handSlot,true);
		schedule("Checkhandlas(" @ %client @ "," @ %player @ ");",0.1); 
		$Firinghandlas[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$handSlot,false);
		$Firinghandlas[%client] = false; 
	} 
}


ItemImageData hand3Image {
	shapeFile = "repairgun";
	mountPoint = 0;
	mountRotation = { 0.5, 0, 0 };
	mountRotation = { 0, 3.14, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = NeedleAmmo;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.6, 0, 1 };
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData hand3 { description = "Needler"; className = "Weapon"; shapeFile = "repairgun"; hudIcon = "chain"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = hand3Image; price = 150; showWeaponBar = true; }; 

function hand3Image::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[hand3]);
	if(%AmmoCount)
	{
		%client = GameBase::getOwnerClient(%player);
		%clientName = Player::getClient(%player);
		%clientId = Client::getName(%client);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,1500))
		{
			%object = getObjectType($los::object);
			%targeted = GameBase::getOwnerClient($los::object);
			if(%object == "Player" || %object == "Flier")
			{
				%targetP = Client::getName(%targeted);
				Projectile::spawnProjectile("NeedlerMissile",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[hand3],1);
         			%player.tafei = GameBase::getPosition(%player);
	 			playSound(SoundFireBlaster, %player.tafei);
				%one = 1;
				//h4Image::choice(%one, %player, %vel, $los::object);
				
			}
			else
			{
				Projectile::spawnProjectile("NeedleRocket",%trans,%player,%vel);
				Player::decItemCount(%player,$WeaponAmmo[hand3],1);
         			%player.tafei = GameBase::getPosition(%player);
	 			playSound(SoundFireBlaster, %player.tafei);
				%two = 2;
				//h4Image::choice(%two, %player, %vel, $los::object);
			}
		}
		else if(!GameBase::getLOSInfo(%player,1500))
		{
			Projectile::spawnProjectile("NeedleRocket",%trans,%player,%vel);
			Player::decItemCount(%player,$WeaponAmmo[hand3],1);
         			%player.tafei = GameBase::getPosition(%player);
	 			playSound(SoundFireBlaster, %player.tafei);
				%three = 3;
				//h4Image::choice(%three, %player, %vel, $los::object);
		}
		if(!$Firinghand3[%client]) {
			Checkhand3(%client, %player);
		}
	}
	else {}
}

ItemImageData h4Image {
	shapeFile = "repairgun";
	mountPoint = 0;
	mountOffset = { -0.7, 0, 0 };
	mountRotation = { 0, 3.14, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;
	ammoType = NeedleAmmo;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.6, 0, 1 };
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData h4 { description = "aNeedler2"; className = "Weapon"; shapeFile = "repairgun"; hudIcon = "chain"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = h4Image; price = 150; showWeaponBar = true; }; 

function h4Image::choice(%chosen, %player, %vel, $los::object)
{
	if (%chosen == 1) {
		Projectile::spawnProjectile("NeedleMissile",%trans,%player,%vel,$los::object);
		Player::decItemCount(%player,$WeaponAmmo[hand3],1);
	}
	else if (%chosen == 2) {
		Projectile::spawnProjectile("NeedleRocket",%trans,%player,%vel);
		Player::decItemCount(%player,$WeaponAmmo[hand3],1);
	}
	else if (%chosen == 3) {
		Projectile::spawnProjectile("NeedleRocket",%trans,%player,%vel);
		Player::decItemCount(%player,$WeaponAmmo[hand3],1);
	}
}

$haSlot=4;

function hand3::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, h4,$haSlot);
}

function hand3::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$haSlot);
}

function hand3::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, h4, 0); 
		Item::onDrop(%player,%item); 
	}
}

function Checkhand3(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "hand3")) 
	{	Player::trigger(%player,$haSlot,true);
		schedule("Checkhand3(" @ %client @ "," @ %player @ ");",0.1); 
		$Firinghand3[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$haSlot,false);
		$Firinghand3[%client] = false; 
	} 
}

ItemImageData polyImage
{
   shapeFile = "paintgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
   projectileType = grabelBeam;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
			
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.85, 0.85, 0.15 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData poly
{
  className = "Weapon";
  description = "Taser";
  heading = "cEnergy Weapons";
  hudIcon = "energyRifle";
  imageType = polyImage;
  price = 225;
  shadowDetailMask = 4;
  shapeFile = "paintgun";
  showWeaponBar = true;
};

ItemImageData daggerImage
{
   shapeFile = "energygun";
   mountPoint = 0;
   mountOffset = { -0.2, 0, 0 };
   mountRotation = { 0, -2, 0 };
   weaponType = 0;
   projectiletype = railLaser;
   minEnergy = 20;
   maxEnergy = 25;
   reloadTime = 0.5;
			
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.8, 0, 1.5 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
};

ItemData dagger
{
  className = "Weapon";
  description = "Rail-Gun";
  heading = "cEnergy Weapons";
  hudIcon = "energyRifle";
  imageType = daggerImage;
  price = 500;
  shadowDetailMask = 4;
  shapeFile = "energygun";
  showWeaponBar = true;
};

ItemImageData railImage
{
   shapeFile = "energygun";
   mountPoint = 0;
   mountOffset = { -0.3, 0, 0 };
   mountRotation = { 0, 2, 0 };
   weaponType = 0;
   reloadTime = 0.1;
			
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.8, 0, 1.5 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData rail
{
  className = "Weapon";
  description = "Rail-Gun2";
  heading = "cEnergy Weapons";
  hudIcon = "energyRifle";
  imageType = railImage;
  price = 500;
  shadowDetailMask = 4;
  shapeFile = "energygun";
  showWeaponBar = true;
};

$railSlotA=4;

function dagger::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, rail,$railSlotA);
}

function dagger::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$railSlotA);
}

function daggerImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,railAmmo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	if(!$Firingdagger[%client]) 
		Checkdagger(%client, %player); 
}

function dagger::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, rail, 0); 
		Item::onDrop(%player,%item); 
	}
}

function Checkdagger(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "dagger")) 
	{	Player::trigger(%player,$railSlotA,true); 
		schedule("Checkdagger(" @ %client @ "," @ %player @ ");",0.1); 
		$Firingdagger[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$railSlotA,false); 
		$Firingdagger[%client] = false; 
	} 
}


function noZoom(%player)
{
$pref::CommanderZoomTime = "450";
$pref::PlayerZoomSpeed = "0.000001";
}

function yesZoom(%player)
{
$pref::CommanderZoomTime = "250";
$pref::PlayerZoomSpeed = "0.00999908";
}

ItemImageData repLauncherImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 0;
	minEnergy = 3;
 	maxEnergy = 5;
	accuFire = false;
	reloadTime = 0.02;
	fireTime = 0.2;
	projectileType = RepRock;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 2;
	lightColor = { 2, 1, 1 };

	sfxFire = SoundELFIdle;
	sfxActivate = SoundPickUpWeapon;
};

ItemData repLauncher
{
	description = "Welding Gun";
	className = "repair";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
	heading = "hRepair Equipment";
	shadowDetailMask = 4;
	imageType = repLauncherImage;
	price = 400;
	showWeaponBar = true;
};

function repLauncher::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == RepairPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have a Medical Kit to use Repair Weapons."); } 

ItemData bioAmmo { description = "BioHazardous Materials"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 3; }; 


ItemImageData bioImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0, 3.14, 0 };

	weaponType = 0; // Single Shot
	ammoType = bioAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.8, 1, 0.3 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData bio
{
	description = "Argon Spread";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "bProjetile Weapons";
	shadowDetailMask = 4;
	imageType = bioImage;
	price = 400;
	showWeaponBar = true;
};

function bioImage::onFire(%player,%slot)
{
	echo("Firing BioSpawn!");

	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("clayBullet3",%trans,%player,%vel);
	Projectile::spawnProjectile("clayBullet4",%trans,%player,%vel);
	Projectile::spawnProjectile("clayBullet5",%trans,%player,%vel);

	Player::decItemCount(%player,$WeaponAmmo[bio],1);
}

ItemImageData FlamerImage { shapeFile = "mortargun"; mountPoint = 0; mountRotation = { 0, 2.7, 0 }; weaponType = 0; reloadTime = 0.5; fireTime = 0.45; minEnergy = 9; projectileType = FlamadeShell; maxEnergy = 9; accuFire = false; sfxFire = SoundFireGrenade; sfxActivate = SoundPickUpWeapon; }; 

ItemData Flamer { description = "Torch Launcher"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "grenade"; heading = "cEnergy Weapons"; shadowDetailMask = 4; imageType = FlamerImage; price = 250; showWeaponBar = true; }; 

ItemData throwerAmmo { description = "Time Bombs"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "magcargo"; shadowDetailMask = 4; price = 6; }; 

ItemData sniperAmmo { description = "Sniper Rounds"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; 

ItemImageData SniperRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = SniperAmmo; accuFire = true; reloadTime = 2.2; projectileType = SnipingShell; fireTime = 0; lightType = 3; lightRadius = 5; lightTime = 2; lightColor = { 1.0, 1.0, 1.0 }; sfxFire = ricochet2; sfxActivate = SoundPickUpWeapon; }; 

ItemData SniperRifle { description = "Sniper Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = SniperRifleImage; price = 300; showWeaponBar = true; }; 

ItemImageData WaveGunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 3; minEnergy = 15; maxEnergy = 19; projectileType = Shock; accuFire = true; reloadTime = 0.2; fireTime = 0.1; sfxFire = SoundPlasmaTurretFire; sfxActivate = SoundPickUpWeapon; }; 

ItemData WaveGun { description = "EMP Shockwave"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "blaster"; heading = "cEnergy Weapons"; shadowDetailMask = 4; imageType = WaveGunImage; price = 250; showWeaponBar = true; }; 

ItemImageData ClakingImage { shapeFile = "fusionbolt"; mountPoint = 1; mountRotation = { 0, 0, 0 }; mountOffset = { 0, 0, 0 }; mountRotation = { 3, 0, 0 }; weaponType = 2; minEnergy = 8; maxEnergy = 10; sfxFire = SoundJammerOn; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData Claking { description = "Cloak"; shapeFile = "fusionbolt"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = Clakingimage; price = 800; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; }; 

function ClakingImage::onActivate(%player,%imageSlot) {
 GameBase::startFadeout(%player);
 Client::sendMessage(Player::getClient(%player),0,"Cloak Activated"); 
 %rate = Player::getSensorSupression(%player) + 5;
 Player::setSensorSupression(%player,%rate);
 %player.guiLock = true;
 %c = Player::getClient(%player); %c.guiLock = true;
 %clientId.ghostDoneFlag = true;
 startGhosting(%cl);
 } 

function ClakingImage::onDeactivate(%player,%imageSlot) {
 GameBase::startFadein(%player);
 Client::sendMessage(Player::getClient(%player),0,"Cloak Deactivated");
 %rate = Player::getSensorSupression(%player) - 5;
 Player::setSensorSupression(%player,%rate);
 Player::trigger(%player,$BackpackSlot,false);
 %player.guiLock = "";
 %c = Player::getClient(%player);
 %c.guiLock = "";
 } 

ItemImageData talepackImage { shapeFile = "sensorjampack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, 0.3, 0.14 }; mountRotation = { 1.5, 0, 0 }; minEnergy = 0; maxEnergy = 0; firstPerson = false; }; 

ItemData talepack { description = "Teleportation Pack"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = talepackImage; price = 500; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; }; 

function decrtfield(%player) {
   %player.tfield = 2;
}

function talepack::onUse(%player,%item) { 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) { 		
		Player::mountItem(%player,%item,$BackpackSlot); 
	} else {
		%clientId = Player::getClient(%player);
		if(!%player.tfield) {
        	if(!GameBase::isAtRest(%player)) {
            Client::sendMessage(%clientId, 0, "Cannot create teleport field while moving.");
            return;
         }
         %player.tafei = GameBase::getPosition(%player);
	 %light = newObject("","StaticShape",ElectricalBeamBig,true);
//         %light = newObject("MedYellow", Item, MedYellow, 1, false);
    	 addToSet("MissionCleanup", %light);
         %player.laghte = %light;
         GameBase::setPosition(%light, %player.tafei);
         Client::sendMessage(%clientId, 0, "Destination Teleport Field has been created");
	 playSound(ForceFieldOpen, %player.tafei);
         GameBase::setRechargeRate(%player, 0);
         %player.tfield = 1;
         echo(%clientId);
         echo(%player);
         echo(%player.tfield);
         schedule("decrtfield(" @ %player @ ");", 3, %player);
         %player.rejuv = 1;
      } else {
         if(%player.tfield < 2) {
            Client::sendMessage(%clientId, 0, "...Teleport Pack recharging...");
            return;
         }
         %player.tfield = 1;
            telePlyr(%player);
      }
	}
}

function telePlyr(%player) {
   %player.tfield = 0;
   schedule("deleteObject(" @ %player.laghte @ ");", 1.25, %player.laghte);
   GameBase::setPosition(%player, %player.tafei);
   playSound(ForceFieldOpen, %player.tafei);
   GameBase::setEnergy(%player, 0);
   GameBase::setRechargeRate(%player, 8);
}

function talepack::onMount(%player,%item) {
	Player::trigger(%player,$BackpackSlot,true);
} 

function talepack::onUnmount(%player,%item) {
	if (%player.tfield) {
		   schedule("deleteObject(" @ %player.laghte @ ");", 1.25, %player.laghte);
	}
}

function talepack::onDrop(%player, %item) {
	if (%player.tfield) {
		   schedule("deleteObject(" @ %player.laghte @ ");", 1.25, %player.laghte);
	}
}

ItemData vaporAmmo { description = "MoonDust"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 3; }; 

$dustSlotA=4;
$dustSlotB=7;
$dustSlotC=6;

ItemImageData moondustLauncherImage 
{	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.25 }; 
	mountRotation = { 0, 1.50, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0; 
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = vaporAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData moondustLauncher 
{	description = "Moon Cannon"; 
	className = "Weapon"; 
	shapeFile = "mortargun";
	hudIcon = "mine"; 
	heading = "bProjectile Weapons"; 
	shadowDetailMask = 4; 
	imageType = moondustLauncherImage; 
	price = 550; 
	showWeaponBar = true; 
};

ItemImageData moondust2Image 
{	ammoType = vaporAmmo;
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0}; 
	weaponType = 0;
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData moondust2 
{	description = "moondust"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mine"; 
	shadowDetailMask = 4; 
	imageType = moondust2Image;
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData moondust3Image 
{	ammoType = vaporAmmo;
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 2.0;
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData moondust3 
{	description = "moondust"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mine"; 
	shadowDetailMask = 4; 
	imageType = moondust3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData moondust4Image 
{	ammoType = vaporAmmo;
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0}; 
	weaponType = 0;
	projectileType = dustShell;
	reloadTime = 2.0; 
	fireTime = 0.1;
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
};

ItemData moondust4 
{	description = "moondust"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mine"; 
	shadowDetailMask = 4; 
	imageType = moondust4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$dustSlotA=4;
$dustSlotB=7;
$dustSlotC=6;

function moondustLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, moondust2,$dustSlotA); 
	Player::mountItem(%player,moondust3,$dustSlotB); 
	Player::mountItem(%player,moondust4,$dustSlotC);
}

function moondustLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$dustSlotA);
	Player::unmountItem(%player,$dustSlotB);	 
	Player::unmountItem(%player,$dustSlotC);
}

function moondustLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,vaporammo,2); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("dustshell",%trans,%player,%vel,%player);
	Player::trigger(%player,$dustSlotA,true);
	Player::trigger(%player,$dustSlotB,true);
	Player::trigger(%player,$dustSlotC,true); 
	if(!$FiringmoondustLauncher[%client]) 
		CheckmoondustLauncher(%client, %player); 
}

function moondustLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, moondust2, 0); 
		Item::onDrop(%player,%item); 
	}
}

function CheckmoondustLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "moondustLauncher")) 
	{	Player::trigger(%player,$dustSlotA,true);
		Player::trigger(%player,$dustSlotB,true);
		Player::trigger(%player,$dustSlotC,true); 
		schedule("CheckmoondustLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringmoondustLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$dustSlotA,false); 
		Player::trigger(%player,$dustSlotB,false); 
		Player::trigger(%player,$dustSlotC,false); 
		$FiringMoondustLauncher[%client] = false; 
	} 
}

$mgSlotA=4;
$mgSlotB=7;
$mgSlotC=6;

ItemImageData macGunImage 
{	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, 0, 0 }; 
	mountRotation = { 0, 1.6, 0 }; 
	weaponType = 0; 
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 4.5;
	fireTime = 0.15;
	projectileType = Chaingunbullet;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = BrotAmmo; 
	accuFire = true;  
	sfxFire = SoundFireChaingun; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundPickUpWeapon;
}; 

ItemData macGun 
{	description = "Machine Guns"; 
	className = "Weapon"; 
	shapeFile = "chaingun";
	hudIcon = "chain"; 
	heading = "bProjectile Weapons"; 
	shadowDetailMask = 4; 
	imageType = macGunImage; 
	price = 150; 
	showWeaponBar = true; 
};

ItemImageData mac2Image 
{	ammoType = BrotAmmo; 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, 0, 0.12 }; 
	mountRotation = { 0, -1.0, 0}; 
	weaponType = 0;
	projectileType = Chaingunbullet2;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 4.5;
	fireTime = 0.15;
	accuFire = false; 
};

ItemData mac2 
{	description = "chainer"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = mac2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

ItemImageData mac3Image 
{	ammoType = BrotAmmo; 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.12 }; 
	mountRotation = { 0, 3.0, 0 }; 
	weaponType = 0;
	projectileType = Chaingunbullet;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 4.5;
	fireTime = 0.15;
	accuFire = false;  
};

ItemData mac3 
{	description = "chainer"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = mac3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData mac4Image 
{	ammoType = BrotAmmo; 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, -1.8, 0}; 
	weaponType = 0;
	projectileType = Chaingunbullet3;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 4.5;
	fireTime = 0.15;
	accuFire = false; 
};

ItemData mac4 
{	description = "chainer"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = mac4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$mgSlotA=4;
$mgSlotB=7;
$mgSlotC=6;

function macGun::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, mac2,$mgSlotA); 
	Player::mountItem(%player,mac3,$mgSlotB); 
	Player::mountItem(%player,mac4,$mgSlotC);
}

function macGun::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$mgSlotA);
	Player::unmountItem(%player,$mgSlotB);	 
	Player::unmountItem(%player,$mgSlotC);
}

function macGunImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Brotammo,2); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("chaingunbullet",%trans,%player,%vel);
	Player::trigger(%player,$mgSlotA,true);
	Player::trigger(%player,$mgSlotB,true);
	Player::trigger(%player,$mgSlotC,true);
	if(!$FiringmacGun[%client]) 
		CheckmacGun(%client, %player); 
}

function macGun::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, mac2, 0);
	Player::setItemCount(%player, mac3, 0); 
	Player::setItemCount(%player, mac4, 0);
		Item::onDrop(%player,%item); 
	}
}

function CheckmacGun(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "macGun")) 
	{	Player::trigger(%player,$mgSlotA,true);
		Player::trigger(%player,$mgSlotB,true);
		Player::trigger(%player,$mgSlotC,true); 
		schedule("CheckmacGun(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringmacGun[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$mgSlotA,false); 
		Player::trigger(%player,$mgSlotB,false); 
		Player::trigger(%player,$mgSlotC,false); 
		$FiringmacGun[%client] = false; 
	}
}

ItemImageData hydoImage 
{	ammoType = BulletAmmo; 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0.12 }; 
	mountRotation = { 0, 3.0, 0 }; 
	weaponType = 0;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 4.5;
	fireTime = 0.15;
	sfxFire = SoundPickUpWeapon;
	accuFire = false;  
};

ItemData hydo 
{	description = "Charger"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = hydoImage; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData hydo2Image 
{	ammoType = BulletAmmo; 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, -1.8, 0}; 
	weaponType = 0;
	projectileType = Chaingunbullet3;
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 4.5;
	fireTime = 0.15;
	accuFire = false; 
};

ItemData hydo2 
{	description = "chainer"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	shadowDetailMask = 4; 
	imageType = hydo2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};

$mmSlotA=4;

function hydo::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{  
	Player::mountItem(%player,hydo2,$mmSlotA);
}

function hydo::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$mmSlotA);
}

function hydoImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Bulletammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ChargeBolt",%trans,%player,%vel);
	Player::trigger(%player,$mmSlotA,true);
	if(!$Firinghydo[%client]) 
		Checkhydo(%client, %player); 
}

function hydo::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{
	Player::setItemCount(%player, hydo2, 0);
		Item::onDrop(%player,%item); 
	}
}

function Checkhydo(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "hydo")) 
	{	Player::trigger(%player,$mmSlotA,true);
		schedule("Checkhydo(" @ %client @ "," @ %player @ ");",0.1); 
		$Firinghydo[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$mmSlotA,false); 
		$Firinghydo[%client] = false; 
	}
}


ItemImageData plasflamImage { shapeFile = "grenadel"; mountPoint = 0; mountRotation = { 0, 3.14, 0 }; weaponType = 0; reloadTime = 0.02; fireTime = 0.03; minEnergy = 1; maxEnergy = 35; accuFire = false; sfxFire = SoundJetHeavy; sfxActivate = SoundPickUpWeapon; }; 

ItemData plasflam { heading = "cEnergy Weapons"; description = "Flame Thrower"; className = "Weapon"; shapeFile = "grenadel"; hudIcon = "plasma"; shadowDetailMask = 4; imageType = plasflamImage; price = 300; showWeaponBar = true; }; 

function plasflamImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("flamingrocket",%trans,%player,%vel);
	Projectile::spawnProjectile("flaming2rocket",%trans,%player,%vel);

}

ItemImageData GasTankPackImage { shapeFile = "plasammo"; weaponType = 2; mountPoint = 2; mountOffset = { 0, 0.12, -0.18 }; mountRotation = { 0, 0, -0.3 }; minEnergy = -1; maxEnergy = -2; firstPerson = false; }; 

ItemData GasTankPack { description = "Gas Tank"; shapeFile = "plasammo"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = GasTankPackImage; price = 100; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; }; 

function GasTankPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

function GasTankPack::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); } 

function GasTankPack::onUnmount(%player,%item) { 
	if (Player::getMountedItem(%player,$WeaponSlot) == plasflam) {
	Player::unmountItem(%player,$WeaponSlot);
	}
	if (Player::getMountedItem(%player,$WeaponSlot) == Flamer) {
	Player::unmountItem(%player,$WeaponSlot);
	}
	if (Player::getMountedItem(%player,$WeaponSlot) == napalmfire) {
	Player::unmountItem(%player,$WeaponSlot);
	}
} 

function poly::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Taser."); } 

function WaveGun::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to create Electro-Magentic Fields."); } 

function plasflam::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == GasTankPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have a Gas Tank to create Fire."); } 

function Flamer::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == GasTankPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have a Gas Tank to create Plasma."); } 

ItemImageData torchImage { shapeFile = "rocket"; mountPoint = 0; weaponType = 3; ammoType = torchAmmo; projectileType = FlieryShell; accuFire = true; reloadTime = 0.9; fireTime = 0.1; spinUpTime = 0; sfxFire = SoundJetHeavy; sfxActivate = SoundPickUpWeapon; sfxReload = SoundJetLight; sfxReady = SoundJetHeavy; }; 

ItemData torch { description = "Hand Rockets"; className = "Weapon"; shapeFile = "rocket"; hudIcon = "plasma"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = torchImage; price = 175; showWeaponBar = true; }; 

ItemImageData throwerImage
{
	shapeFile = "radar_small";
	mountPoint = -0.5;

	weaponType = 0; // Single Shot
	ammoType = throwerAmmo;
	projectileType = throwingBullet;
	accuFire = false;
	reloadTime = 0.2;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData thrower
{
	description = "Kamikaze Bomb";
	className = "Weapon";
	shapeFile = "radar_small";
	hudIcon = "shieldpack";
   heading = "fDeployables";
	shadowDetailMask = 4;
	imageType = throwerImage;
	price = 350;
	showWeaponBar = true;
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
   validateShape = true;
	hudIcon = "chain";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};


//----------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "Plasma Bolts";
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
	reloadTime = 0.02;
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
   validateShape = true;
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
   validateShape = true;
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
   validateShape = true;
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

ItemData BurstAmmo
{
	description = "Electric Burster Shells";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemData RailAmmo
{
	description = "Energy Rails";
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
	description = "Spynfuser";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData RocketLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.13, 0, -0.035 };
	mountRotation = { 0, -1.48, 0 };
	weaponType = 3; // DiscLauncher
	ammoType = torchAmmo;
	projectileType = RocketShell;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData RocketLauncher
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mine";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketLauncherImage;
	price = 150;
	showWeaponBar = true;
};

ItemImageData RocketLauncher2Image
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.1195, 0, -0.05 };
	mountRotation = { 0, -0.5, 0 };
	weaponType = 3; // DiscLauncher
	ammoType = torchAmmo;
	projectileType = RocketShell;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

ItemData RocketLauncher2
{
	description = "Rocket Launcher2";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mine";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketLauncher2Image;
	price = 150;
	showWeaponBar = true;
};
$rakeSlotA=4;

function RocketLauncher::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, RocketLauncher2,$rakeSlotA);
}

function RocketLauncher::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$rakeSlotA);
}

function RocketLauncherImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,torchAmmo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	Player::trigger(%player,$rakeSlotA,true);
	if(!$FiringRocketLauncher[%client]) 
		CheckRocketLauncher(%client, %player); 
}

function RocketLauncher::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{	Player::setItemCount(%player, RocketLauncher2, 0); 
		Item::onDrop(%player,%item);
	}
}

function CheckRocketLauncher(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "RocketLauncher")) 
	{	Player::trigger(%player,$rakeSlotA,true); 
		schedule("CheckRocketLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringRocketLauncher[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$rakeSlotA,false);  
		$FiringRocketLauncher[%client] = false; 
	}
}

//%%%%% this gun is offspring of Fallout mod, created by Floater Eater 
GrenadeData CannedBots 
{ 
   bulletShapeName    = "chainspk.dts"; 
   explosionTag       = botExp; 
   collideWithOwner   = True; 
   ownerGraceMS       = 250; 
   collisionRadius    = 0.3; 
   mass               = 8.0;//5.0; 
   elasticity         = 0.1; 

   damageClass        = 0;// 0 impact, 1, radius 
   damageValue        = 0.0;//1.0;
   damageType         = $MortarDamageType; 

   explosionRadius    = 1.0;//20.0; 
   kickBackStrength   = -250.0;//250.0; 
   maxLevelFlightDist = 0;//20;//275; 
   totalTime          = 4.0;//10.0;//30.0; 
   liveTime           = 1.0;//2.0; 
   projSpecialTime    = 0.01;//this tells how long between shockwaves 

   inheritedVelocityScale = 0.5; 
   smokeName              = "chainspk.dts"; 
}; 
//%%%%% 
ItemData BotAmmo 
{ 
   description = "Machines"; 
   className = "Ammo"; 
   shapeFile = "discammo"; 
   heading = "xAmmunition"; 
   shadowDetailMask = 4; 
   price = 2000; 
}; 

ItemImageData BotGunImage 
{ 
   shapeFile = "mortargun"; 
   mountPoint = 0; 

   weaponType = 1; // DiscLauncher //3; 
   ammoType = BotAmmo; 
//   projectileType = CannedBots; //%%% had to comment this out for ::onFire to be called. THANKS to [df]Perrionoia for that one! 
   accuFire = true; 
   reloadTime = 1.0;//0.25; 
   fireTime = 1.25; 
   spinUpTime = 1.25;//0.25; 

   sfxFire = SoundFireDisc; 
   sfxActivate = SoundPickUpWeapon; 
   sfxReload = SoundDiscReload; 
   sfxReady = SoundDiscSpin; 
}; 

ItemData BotGun 
{ 
   description = "Ex Machina"; 
   className = "Weapon"; 
   shapeFile = "disc"; 
   hudIcon = "disk"; 
   heading = "bWeapons"; 
   shadowDetailMask = 4; 
   imageType = BotGunImage; 
   price = 150; 
   showWeaponBar = true; 
}; 

ItemImageData BotGunXImage 
{ 
   shapeFile = "mortargun"; 
   mountPoint = 0; 

   weaponType = 1; 
   ammoType = BotAmmo; 
   accuFire = true; 
   reloadTime = 0.25; 
   fireTime = 1.25; 
   spinUpTime = 0.25; 

   sfxFire = SoundFireDisc; 
   sfxActivate = SoundPickUpWeapon; 
   sfxReload = SoundDiscReload; 
   sfxReady = SoundDiscSpin; 
}; 

ItemData BotGunX 
{ 
   description = "Botgun"; 
   className = "Weapon"; 
   shapeFile = "disc"; 
   hudIcon = "disk"; 
   heading = "bWeapons"; 
   shadowDetailMask = 4; 
   imageType = BotGunXImage; 
   price = 150; 
   showWeaponBar = true; 
};

function BotGunImage::onFire(%player, %slot) 
{       
//%%make it shoot something 

%trans = GameBase::getMuzzleTransform(%player); 
%vel = Item::getVelocity(%player); 
%client = Player::getClient(%player); 

Projectile::spawnProjectile("CannedBots",%trans,%player,%vel); 

//%%spawn BOT!!! 
%role = floor(getRandom() * 10); 
   if(%role == 0) 
   { 
   AI::bhelper("Nestor", "tarmor", %player, %client, GameBase::getTeam(%player), %role); 
   } 
   else if(%role == 1) 
   { 
   AI::bhelper("Sonny", "tarmor", %player, %client, GameBase::getTeam(%player), %role); 
   } 
   else if(%role == 2) 
   { 
   AI::bhelper("Spooner", "tarmor", %player, %client, GameBase::getTeam(%player), %role); 
   } 
   else if(%role == 3) 
   { 
   AI::bhelper("Bender", "tarmor", %player, %client, GameBase::getTeam(%player), %role); 
   } 
   else if(%role == 7) 
   { 
   if (GameBase::getTeam(%player) == 0)
     {
     AI::bhelper("EVIL_BOTTER", "larmor", %player, %client, 1, %role);//try not to roll a 7!!! it can cause your bots to fight each other! 
     }
   else 
     {
     AI::bhelper("EVIL_BOTTER", "larmor", %player, %client, 0, %role);//try not to roll a 7!!! it can cause your bots to fight each other! 
     }
   } 
   else 
   { 
   AI::bhelper("botter", "tarmor", %player, %client, GameBase::getTeam(%player), %role); 
   }
//%botterIQ = floor(getRandom() * 125) + 100; 
   if($debug) 
echo(%botterIQ); 

//AI::behavior(%client, %ai, %role, %botterIQ);//-now called in AI::bhelper(); -Floater 
//%%%%%%%%%%% IMPORTANT!!!!!!!! -Floater 
Player::decItemCount(%player,$WeaponAmmo[BotGun],1); 
//%%%%%%%%%%% removes 1 shot from inventory. 

}//%% BotGun::onFire function end!!! YAAAY I DID IT! -Floater 

//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% 
//%%%%% new bot gun, makes defender bots. -Floater 
function BotGunXImage::onFire(%player,%slot) 
{ 
//%%%%% shooting begins 
%trans = GameBase::getMuzzleTransform(%player); 
%vel = Item::getVelocity(%player); 
%client = Player::getClient(%player); 

Projectile::spawnProjectile("CannedBots",%trans,%player,%vel); 
Player::decItemCount(%player,$WeaponAmmo[BotGunX],1); 
//%%%%% shooting ends %%%%%%%%%%%
%nest = false;
%sony = false;
%bent = false;
%sppon = false;
%nx = false;
%dsf = false;
%rdrr = false;
%erthang = false;
%rand = floor(getRandom() * 10);
Client::sendMessage(%client,0,"Random #: " @ %rand @ " .");
if (%rand >= 0 && %rand < 1)
{
%nest = true;
}
else if (%rand >= 1 && %rand < 2)
{
%sony = true;
}
else if (%rand >= 2 && %rand < 3)
{
%bent = true;
}
else if (%rand >= 3 && %rand < 4)
{
%sppon = true;
}
else if (%rand >= 4 && %rand < 5)
{
%nx = true;
}
else if (%rand >= 5 && %rand < 6)
{
%dsf = true;
}
else if (%rand >= 6 && %rand < 7)
{
%rdrr = true;
}
else if (%rand >= 7 || %rand < 0)
{
%erthang = true;
}
if (%nest == true)
{
//	if ($nestchosen == true) {
//		%sony = true;
//	}
//	if ($nestchosen == false) {
AI::bhelper("|Nestor.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
//$nestchosen == true;
//	}
}
if (%sony == true)
{
//	if ($sonychosen == true) {
//		%bent = true;
//	}
//	if ($sonychosen == false) {
AI::bhelper("|Sonny.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
//$sonychosen = true;
//	}
}
if (%bent == true)
{
//	if ($bentchosen == true) {
//		%sppon = true;
//	}
//	if ($bentchosen == false) {
AI::bhelper("|Bender.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
//$bentchosen = true;
//	}
}
if (%nx == true)
{
//	if ($nxchosen == true) {
//		%dsf = true;
//	}
//	if ($nxchosen == false) {
AI::bhelper("|Ns-5.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
//$nxchosen = true;
//	}
}
if (%dsf == true)
{
//	if ($dsfchosen == true) {
//		%rdrr = true;
//	}
//	if ($dsfchosen == false) {
AI::bhelper("|C-3PO.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
//$dsfchosen = true;
//	}
}
if (%rdrr == true)
{
//	if ($rdrrchosen == true) {
//		%erthang = true;
//	}
//	if ($rdrrchosen == false) {
AI::bhelper("|R2-D2.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
//$rdrrchosen = true;
//	}
}
if (%erthang = true)
{
//	if ($erchosen == true) {
//		%nest = true;
//	}
//	if ($erchosen == false) {
AI::bhelper("|Ns-2.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
//$erchosen = true;
//	}
}

}//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%% END ::onFire() function! -Floater

function BotGun::MountExtras(%player,%weapon)
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Blah Blah Blah");
}
function BotGunX::MountExtras(%player,%weapon)
{	
	if((Player::getclient(%player)).weaponHelp)
		Bottomprint(Player::getclient(%player), "<jc>"@%weapon.description@": <f2>Blah Blah Blah");
}

ItemImageData BursterImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	mountRotation = { 0, 3.14, 0 };
	weaponType = 0;
	ammoType = BurstAmmo;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = energyExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReady = SoundDiscSpin;
};

ItemData Burster
{
	description = "Burster";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "disk";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = BursterImage;
	price = 150;
	showWeaponBar = true;
};

function BursterImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Burstammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	%vel1 = Item::getVelocity(%player) + 4;
	%vel2 = Item::getVelocity(%player) - 3;
	//%trans1 = GameBase::getMuzzleTransform(%player) + 3; 
	//%trans2 = GameBase::getMuzzleTransform(%player) - 4; 
	Projectile::spawnProjectile("MFBolt",%trans,%player,%vel);
	Projectile::spawnProjectile("BurstingBolt1",%trans,%player,%vel1);
	Projectile::spawnProjectile("BurstingBolt2",%trans,%player,%vel);
	Projectile::spawnProjectile("BurstingBolt3",%trans,%player,%vel);
	Projectile::spawnProjectile("BurstingBolt4",%trans,%player,%vel2);
	if(!$FiringBurster[%client]) 
		CheckBurster(%client, %player); 
}

function CheckBurster(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Burster")) 
	{
		schedule("CheckBurster(" @ %client @ "," @ %player @ ");",0.1); 
		$FiringBurster[%client] = true; 
	} 
	else 
	{
		$FiringBurster[%client] = false; 
	}
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
	description = "Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
   validateShape = true;
   validateMaterials = true;
};

function LaserRifle::onUse(%player,%item)
{
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
   validateShape = true;
};

ItemImageData lightgunImage
{
	shapeFile = "paintgun";
   mountPoint = 0;
   mountOffset = { 0, 0.1 , 0 };
   mountRotation = { 0, -1.5, 0 };

   weaponType = 0;  // Sustained
 //projectileType = zapBullet;
   minEnergy = 11;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.2, 0.2, 1.5 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData lightgun
{
   description = "Zapper";
	shapeFile = "paintgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = lightgunImage;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

ItemImageData lightgun2Image
{
	shapeFile = "paintgun";
   mountPoint = 0;
   mountOffset = { -0.5, 0.1 , 0 };
   mountRotation = { 0, 1.4, 0 };

   weaponType = 0;  // Sustained
 //projectileType = lightCharge;
   minEnergy = 11;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.2, 0.2, 1.5 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData lightgun2
{
   description = "Lightning Gun2";
	shapeFile = "paintgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = lightgun2Image;
	showWeaponBar = true;
   price = 125;

};

ItemImageData lightgun3Image
{
	shapeFile = "mflame";
   mountPoint = 0;
   mountOffset = { -0.243, 0.19 , 0 };
   mountRotation = { 0, 0, 0 };

   weaponType = 0;  // Sustained
 //projectileType = lightCharge;
   minEnergy = 11;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.2, 0.2, 1.5 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData lightgun3
{
   description = "Lightning Gun3";
	shapeFile = "mflame";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = lightgun3Image;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

$lightSlotA=4;
$lightSlotB=7;

function lightgun::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, lightgun2,$lightSlotA); 
	Player::mountItem(%player,lightgun3,$lightSlotB); 
}

function lightgun::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$lightSlotA);
	Player::unmountItem(%player,$lightSlotB);
}

function lightgunImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("zapBullet",%trans,%player,%vel);
	if(!$Firinglightgun[%client])
		Checklightgun(%client, %player); 
}

function lightgun::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, lightgun2, 0); 
		Player::setItemCount(%player, lightgun3, 0); 
		Item::onDrop(%player,%item); 
	}
}

function Checklightgun(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "lightgun")) 
	{	Player::trigger(%player,$lightSlotA,true);
		schedule("Checklightgun(" @ %client @ "," @ %player @ ");",0.1); 
		$Firinglightgun[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$lightSlotA,false);
		$Firinglightgun[%client] = false; 
	} 
}

ItemImageData latgunImage
{
	shapeFile = "paintgun";
   mountPoint = 0;
   mountOffset = { -0.2, 0 , 0 };
   mountRotation = { 0, -1.5, 0 };

   weaponType = 0;  // Sustained
 //projectileType = zapBullet;
   minEnergy = 11;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.2, 0.2, 1.5 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData latgun
{
   description = "Zapper";
	shapeFile = "paintgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = latgunImage;
	showWeaponBar = true;
   price = 125;
};

ItemImageData latgun2Image
{
	shapeFile = "paintgun";
   mountPoint = 0;
   mountOffset = { -0.7, 0 , 0 };
   mountRotation = { 0, 1.4, 0 };

   weaponType = 0;  // Sustained
 //projectileType = lightCharge;
   minEnergy = 11;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.2, 0.2, 1.5 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData latgun2
{
   description = "Lightning Gun2";
	shapeFile = "paintgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = latgun2Image;
	showWeaponBar = true;
   price = 125;
};

ItemImageData latgun3Image
{
	shapeFile = "mflame";
   mountPoint = 0;
   mountOffset = { -0.453, 0.05 , 0 };
   mountRotation = { 0, 0, 0 };

   weaponType = 0;  // Sustained
 //projectileType = lightCharge;
   minEnergy = 11;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.2, 0.2, 1.5 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData latgun3
{
   description = "Lightning Gun3";
	shapeFile = "mflame";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = latgun3Image;
	showWeaponBar = true;
   price = 125;
};

$latslotA=4;
$latslotB=7;

function latgun::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{	Player::mountItem(%player, latgun2,$latslotA); 
	Player::mountItem(%player,latgun3,$latslotB); 
}

function latgun::onUnmount(%player,%imageSlot) 
{	Player::unmountItem(%player,$latslotA);
	Player::unmountItem(%player,$latslotB);
}

function latgunImage::onFire(%player, %slot) 
{	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("zapBullet",%trans,%player,%vel);
	if(!$Firinglatgun[%client])
		Checklatgun(%client, %player); 
}

function latgun::onDrop(%player,%item) 
{	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, latgun2, 0); 
		Player::setItemCount(%player, latgun3, 0); 
		Item::onDrop(%player,%item); 
	}
}

function Checklatgun(%client, %player) 
{	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "latgun")) 
	{	Player::trigger(%player,$latslotA,true);
		schedule("Checklatgun(" @ %client @ "," @ %player @ ");",0.1); 
		$Firinglatgun[%client] = true; 
	} 
	else 
	{	Player::trigger(%player,$latslotA,false);
		$Firinglatgun[%client] = false; 
	} 
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
   validateShape = true;
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
	shadowDetailMask = 4	;
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
   heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
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
	if (Player::getMountedItem(%player,$WeaponSlot) == encan) {
	Player::unmountItem(%player,$WeaponSlot);
	}
	if (Player::getMountedItem(%player,$WeaponSlot) == poly) {
	Player::unmountItem(%player,$WeaponSlot);
	} 
	if (Player::getMountedItem(%player,$WeaponSlot) == WaveGun) {
	Player::unmountItem(%player,$WeaponSlot);
	}
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
   validateShape = true;
   validateMaterials = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
	if (Player::getMountedItem(%player,$WeaponSlot) == replauncher) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,replauncher,$WeaponSlot);
	}
}


function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		if (%mounted == replauncher) {
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
   validateShape = true;
   validateMaterials = true;
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
   validateShape = true;
   validateMaterials = true;
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

//	if (Item::deployShape(%player,"Motion Sensor",MotionSensor,%item)) {
function MotionSensorPack::deployShape(%player,%item)
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
	for(%i = 0; %i < 7 ; %i = %i +1) {
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
	description = "Robot";
	shapeFile = "camera";
	className = "Backpack";
   heading = "fDeployables";
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
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
	if($TeamItemCount[GameBase::getTeam(%player) @ "CameraPack"] < $TeamItemMax[CameraPack]) {
//%%%%% shooting begins 
%trans = GameBase::getMuzzleTransform(%player); 
%vel = Item::getVelocity(%player); 
%client = Player::getClient(%player); 

Projectile::spawnProjectile("CannedBots",%trans,%player,%vel); 
//%%%%% shooting ends %%%%%%%%%%%
%nest = false;
%sony = false;
%bent = false;
%sppon = false;
%nx = false;
%dsf = false;
%ass = false;
%home = false;
%nss = false;
%her = false;
%are = false;
%shaz = false;
%sherm = false;

%rand = floor(getRandom() * 24);
//Client::sendMessage(%client,0,"Random #: " @ %rand @ " .");
if (%rand == 0 || %rand == 1)
{
%nest = true;
}
else if (%rand == 2 || %rand == 3)
{
%sony = true;
}
else if (%rand == 4 || %rand == 5)
{
%bent = true;
}
else if (%rand == 6 || %rand == 7)
{
%nx = true;
}
else if (%rand == 8 || %rand == 9)
{
%dsf = true;
}
else if (%rand == 10 || %rand == 11)
{
%nss = true;
}
else if (%rand == 12 || %rand == 13)
{
%ass = true;
}
else if (%rand == 14 || %rand == 15)
{
%are = true;
}
else if (%rand == 16 || %rand == 17)
{
%shaz = true;
}
else if (%rand == 18 || %rand == 19)
{
%her = true;
}
else if (%rand == 20 || %rand == 21)
{
%home = true;
}
else if (%rand == 22 || %rand == 23)
{
%sherm = true;
}

if (%nss == true)
{
	%teeam = GameBase::getTeam(%player);
	if (%teeam == 0) {
%aname = "|R2-D2.bot|";
AI::bhelper("|R2-D2.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teeam == 1) {
%aname = ".R2-D2|bot.";
AI::bhelper(".R2-D2|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%are == true)
{
	%teeam = GameBase::getTeam(%player);
	if (%teeam == 0) {
%aname = "|Aryan.bot|";
AI::bhelper("|Aryan.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teeam == 1) {
%aname = ".Aryan|bot.";
AI::bhelper(".Aryan|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%shaz == true)
{
	%teeam = GameBase::getTeam(%player);
	if (%teeam == 0) {
%aname = "|Shaz.bot|";
AI::bhelper("|Shaz.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teeam == 1) {
%aname = ".Shaz|bot.";
AI::bhelper(".Shaz|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%ass == true)
{
	%teeam = GameBase::getTeam(%player);
	if (%teeam == 0) {
%aname = "|Asimo.bot|";
AI::bhelper("|Asimo.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teeam == 1) {
%aname = ".Asimo|bot.";
AI::bhelper(".Asimo|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%her == true)
{
	%teeam = GameBase::getTeam(%player);
	if (%teeam == 0) {
%aname = "|Hermes.bot|";
AI::bhelper("|Hermes.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teeam == 1) {
%aname = ".Hermes|bot.";
AI::bhelper(".Hermes|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%home == true)
{
	%teeam = GameBase::getTeam(%player);
	if (%teeam == 0) {
%aname = "|Homer.bot|";
AI::bhelper("|Homer.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teeam == 1) {
%aname = ".Homer|bot.";
AI::bhelper(".Homer|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%sherm == true)
{
	%teeam = GameBase::getTeam(%player);
	if (%teeam == 0) {
%aname = "|Shrimp.bot|";
AI::bhelper("|Shrimp.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teeam == 1) {
%aname = "Shrimp.R2-D2|bot.";
AI::bhelper(".Shrimp|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%nest == true)
{
//	if ($t1firstbot == "|Nestor.bot|"){
//		$sony = true;
//		return;
//	}
//	if ($t2firstbot == "|Nestor.bot|"){
//		$sony = true;
//		return;
//	}
//	if ($t1secondbot == "|Nestor.bot|"){
//		$sony = true;
//		return;
//	}
//	if ($t2secondbot == "|Nestor.bot|"){
//		$sony = true;
//		return;
//	}
//	if ($t1thirdbot == "|Nestor.bot|"){
//		$sony = true;
//		return;
//	}
//	if ($t2thirdbot == "|Nestor.bot|"){
//		$sony = true;
//		return;
//	}

	%teeam = GameBase::getTeam(%player);
	if (%teeam == 0) {
%aname = "|Nestor.bot|";
AI::bhelper("|Nestor.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teeam == 1) {
%aname = ".Nestor|bot.";
AI::bhelper(".Nestor|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%sony == true)
{

//	if ($t1firstbot == "|Sonny.bot|"){
//		$bent = true;
//		return;
//	}
//	if ($t2firstbot == "|Sonny.bot|"){
//		$bent = true;
//		return;
//	}
//	if ($t1secondbot == "|Sonny.bot|"){
//		$bent = true;
//		return;
//	}
//	if ($t2secondbot == "|Sonny.bot|"){
//		$bent = true;
//		return;
//	}
//	if ($t1thirdbot == "|Sonny.bot|"){
//		$bent = true;
//		return;
//	}
//	if ($t2thirdbot == "|Sonny.bot|"){
//		$bent = true;
//		return;
//	}

	%teaam =  GameBase::getTeam(%player);
	if (%teaam == 0) {
%aname = "|Sonny.bot|";
AI::bhelper("|Sonny.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%teaam == 1) {
%aname = ".Sonny|bot.";
AI::bhelper(".Sonny|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%bent == true)
{
//	if ($t1firstbot == "|Bender.bot|"){
//		$nx = true;
//		return;
//	}
//	if ($t2firstbot == "|Bender.bot|"){
//		$nx = true;
//		return;
//	}
//	if ($t1secondbot == "|Bender.bot|"){
//		$nx = true;
//		return;
//	}
//	if ($t2secondbot == "|Bender.bot|"){
//		$nx = true;
//		return;
//	}
//	if ($t1thirdbot == "|Bender.bot|"){
//		$nx = true;
//		return;
//	}
//	if ($t2thirdbot == "|Bender.bot|"){
//		$nx = true;
//		return;
//	}
 	%tame = GameBase::getTeam(%player);
	if (%tame == 0) {
%aname = "|Bender.bot|";
AI::bhelper("|Bender.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%tame == 1) {
 %aname = ".Bender|bot.";
AI::bhelper(".Bender|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%nx == true)
{
//	if ($t1firstbot == "|Ns-5.bot|"){
//		$dsf = true;
//		return;
//	}
//	if ($t2firstbot == "|Ns-5.bot|"){
//		$dsf = true;
//		return;
//	}
//	if ($t1secondbot == "|Ns-5.bot|"){
//		$dsf = true;
//		return;
//	}
//	if ($t2secondbot == "|Ns-5.bot|"){
//		$dsf = true;
//		return;
//	}
//	if ($t1thirdbot == "|Ns-5.bot|"){
//		$dsf = true;
//		return;
//	}
//	if ($t2thirdbot == "|Ns-5.bot|"){
//		$dsf = true;
//		return;
//	}

	%tteam =  GameBase::getTeam(%player);
	if (%tteam == 0) {
%aname = "|Ns-5.bot|";
AI::bhelper("|Ns-5.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%tteam == 1) {
 %aname = ".Ns-5|bot.";
AI::bhelper(".Ns-5|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
}

if (%dsf == true)
{
//	if ($t1firstbot == "|C-3PO.bot|"){
//		$nest = true;
//		return;
//	}
//	if ($t2firstbot == "|C-3PO.bot|"){
//		$nest = true;
//		return;
//	}
//	if ($t1secondbot == "|C-3PO.bot|"){
//		$nest = true;
//		return;
//	}
//	if ($t2secondbot == "|C-3PO.bot|"){
//		$nest = true;
//		return;
//	}
//	if ($t1thirdbot == "|C-3PO.bot|"){
//		$nest = true;
//		return;
//	}
//	if ($t2thirdbot == "|C-3PO.bot|"){
//		$nest = true;
//		return;
//	}
//else {

	%tseam =  GameBase::getTeam(%player);
	if (%tseam == 0) {
%aname = "|C-3PO.bot|";
AI::bhelper("|C-3PO.bot|", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
	else if (%tseam == 1) {
%aname = ".C-3PO|bot.";
AI::bhelper(".C-3PO|bot.", "tarmor", %player, %client, GameBase::getTeam(%player), 11);
	}
//}
}

	%ci = Player::getClient(%player);
//%pos = GameBase::getPosition(%player);
//playSound(~wmale1.whello.wav,%pos);

%cname = Client::getName(%client);
$TeamItemCount[GameBase::getTeam(%player) @ "CameraPack"]++;
%droidnum = 0;
if ($TeamItemCount[GameBase::getTeam(%player) @ "CameraPack"] < $TeamItemMax[CameraPack]) {
	%droidnum = $TeamItemMax[CameraPack] - $TeamItemCount[GameBase::getTeam(%player) @ "CameraPack"];
Client::sendMessage(%ci,3, %aname @ ": Hello, " @ %cname @ " Pressing 'TAB' will allow you to select a target for me. You have " @ %droidnum @ " droids left. ~wmale1.whello.wav");

}
		else if ($TeamItemCount[GameBase::getTeam(%player) @ "CameraPack"] >= $TeamItemMax[CameraPack]) {
			%treamer = GameBase::getTeam(%player);
			//%tceam = GameBase::getTeamName(%treamer);
Client::sendMessage(%ci,3, %aname @ ": Hello, " @ %cname @ " Pressing 'TAB' will allow you to select a target for me. ~wmale1.whello.wav");
			Messageall(1, getTeamName(%treamer) @ " Deployable Droids are depleted");
		}
	}
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
	description = "Alarm Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "fDeployables";
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
								Client::sendMessage(%client,0,"Alarm Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed an Alarm Turret");
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

ItemImageData AlfiePackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData AlfiePack
{
	description = "ELF Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "fDeployables";
	imageType = AlfiePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AlfiePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function AlfiePack::onDeploy(%player,%item,%pos)
{
	if (AlfiePack::deployShape(%player,%item)) {
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

function AlfiePack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableElfer",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableElfer",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("chainTurret","Turret",DeployableElfer,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"ELF Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "AlfiePack"]++;
								echo("MSG: ",%client," deployed an ELF Turret");
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
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------

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
   validateShape = true;
   validateMaterials = true;
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
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
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
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "eMiscellany";
	shadowDetailMask = 4;
  	price = 2;
   validateShape = true;
   validateMaterials = true;
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
	$TeamItemCount[0 @ TalePack] = 0;
	$TeamItemCount[0 @ AlfiePack] = 0;
	$TeamItemCount[0 @ RobotPack] = 0;
	$TeamItemCount[0 @ GasTankPack] = 0;
	$TeamItemCount[0 @ Claking] = 0;
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
	$TeamItemCount[1 @ TalePack] = 0;
	$TeamItemCount[1 @ AlfiePack] = 0;
	$TeamItemCount[1 @ RobotPack] = 0;
	$TeamItemCount[1 @ GasTankPack] = 0;
	$TeamItemCount[1 @ Claking] = 0;
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
	$TeamItemCount[2 @ TalePack] = 0;
	$TeamItemCount[2 @ AlfiePack] = 0;
	$TeamItemCount[2 @ RobotPack] = 0;
	$TeamItemCount[2 @ GasTankPack] = 0;
	$TeamItemCount[2 @ Claking] = 0;
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
	$TeamItemCount[3 @ TalePack] = 0;
	$TeamItemCount[3 @ AlfiePack] = 0;
	$TeamItemCount[3 @ RobotPack] = 0;
	$TeamItemCount[3 @ GasTankPack] = 0;
	$TeamItemCount[3 @ Claking] = 0;
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
	$TeamItemCount[4 @ TalePack] = 0;
	$TeamItemCount[4 @ AlfiePack] = 0;
	$TeamItemCount[4 @ RobotPack] = 0;
	$TeamItemCount[4 @ GasTankPack] = 0;
	$TeamItemCount[4 @ Claking] = 0;
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
	$TeamItemCount[5 @ TalePack] = 0;
	$TeamItemCount[5 @ AlfiePack] = 0;
	$TeamItemCount[5 @ RobotPack] = 0;
	$TeamItemCount[5 @ GasTankPack] = 0;
	$TeamItemCount[5 @ Claking] = 0;
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
	$TeamItemCount[6 @ TalePack] = 0;
	$TeamItemCount[6 @ AlfiePack] = 0;
	$TeamItemCount[6 @ RobotPack] = 0;
	$TeamItemCount[6 @ GasTankPack] = 0;
	$TeamItemCount[6 @ Claking] = 0;
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
	$TeamItemCount[7 @ TalePack] = 0;
	$TeamItemCount[7 @ AlfiePack] = 0;
	$TeamItemCount[7 @ RobotPack] = 0;
	$TeamItemCount[7 @ GasTankPack] = 0;
	$TeamItemCount[7 @ Claking] = 0;
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

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}