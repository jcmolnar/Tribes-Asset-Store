$PublicsBestMods = "Meltdown AAOD DESTRUCTION MODoftheDOG Chivalry";
$ItemFavoritesKey = "MeltdownClassix"; 
$ModFavoritesKey = "Null";
$Displaytime = 5;
$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;
$ExtraWeaponSlotA=4;
$ExtraWeaponSlotB=5;
$ExtraWeaponSlotC=6;
$ArmorDetailSlot=7;

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
$SellAmmo[BulletAmmo] = 125;
$SellAmmo[PlasmaAmmo] = 50;
$SellAmmo[DiscAmmo] = 50;
$SellAmmo[GrenadeAmmo] = 50;
$SellAmmo[MortarAmmo] = 50;
$SellAmmo[Beacon] = 50;
$SellAmmo[MineAmmo] = 50;
$SellAmmo[Grenade] = 50;
$SellAmmo[EMPGrenadeAmmo] = 50;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[BulletAmmo] = 250;
$AmmoPackMax[PlasmaAmmo] = 100;
$AmmoPackMax[DiscAmmo] = 75;
$AmmoPackMax[GrenadeAmmo] = 120;
$AmmoPackMax[MortarAmmo] = 60;
$AmmoPackMax[MineAmmo] = 15;
$AmmoPackMax[Grenade] = 20;
$AmmoPackMax[Beacon] = 25;
$AmmoPackMax[EMPGrenadeAmmo] = 60;

// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = EMPGrenadeAmmo;

// Limit on number of special Items you can buy
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

// Limit on number of special Items you can buy
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
$WeaponAmmo[EMPGrenadeLauncher] = EMPGrenadeAmmo;
$WeaponAmmo[RPGLauncher] = GrenadeAmmo;
$WeaponAmmo[RPMLauncher] = MortarAmmo;
$WeaponAmmo[RPEMPLauncher] = EMPGrenadeAmmo;
$WeaponAmmo[PoontangPie] = Pies;

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

function remoteBuyFavorites(%client,%favItem0,%favItem1,%favItem2,%favItem3,%favItem4,%favItem5,%favItem6,%favItem7,%favItem8,%favItem9,%favItem10,%favItem11,%favItem12,%favItem13,%favItem14,%favItem15,%favItem16,%favItem17,%favItem18,%favItem19)
{
  // only can buy fav every 1/2 second
   %time = getIntegerTime(true) >> 4; // int half seconds
   if(%time <= %client.lastBuyFavTime)
      return;

   %curItem = Player::getMountedItem(%client,$WeaponSlot); 
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
			if (isSelectableWeapon(%client,%curItem))
				Player::useItem(%client,%curItem);
			else if (%curItem == "RepairGun") 
				Player::useItem(%client,"RepairPack");
			else 
				selectValidWeapon(%client);
			updateBuyingList(%client);
		}
	}
}


function replenishTeamEnergy(%team)
{
	$TeamEnergy[%team] += $incTeamEnergy;
	schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy);
}

function resetArmor(%client,%armor)
{	%player=Client::getOwnedObject(%client);
	%client.inStasis--;
	if(%client.inStasis<=0)
	{	Player::setArmor(%client,%armor);
		%client.inStasis=0;
		%rate=$Recharge[%client.talent[$Rch]];
		%player=Client::getOwnedObject(%client);
		GameBase::setRechargeRate(%player,%rate);
	}
	else if(%client.inStasis >= 3)
	{	schedule("resetArmor("@%client@","@%armor@");",1,%player);
	}
	else
		schedule("resetArmor("@%client@","@%armor@");",2,%player);
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
					Client::sendMessage(%client,0,"Can't buy " @ %item.description @ " - "@ %energy @ " Energy points left");
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
			Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
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
				else if(%pack == Accelerator) {
					if(Player::getItemCount(%client,"PBW") > 0) {
						Client::sendMessage(%client,0,"Sold Particle Accelerator - Auto Selling PBW");
						remoteSellItem(%client, "PBW");						
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
				if(%item == PBW && Player::getItemCount(%client,"Accelerator") == 0) {
					buyItem(%client,"Accelerator");
					Client::sendMessage(%client,0,"Bought PBW - Auto buying Accelerator");
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
  		Client::sendMessage(%client,0,"You can't buy "@ %item.description @"~wC_BuySell.wav");
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
			else if(%item == Accelerator) { 
				if(Player::getItemCount(%client,"PBW") > 0) {
					Client::sendMessage(%client,0,"Sold Particle Accelerator - Auto Selling PBW");
					remoteSellItem(%client, "PBW");						
				}
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count-%numsell));
			updateBuyingList(%client);
			Client::SendMessage(%client,0,"~wbuysellsound.wav");
			return 1;
		}
	}
	Client::sendMessage(%client,0,"Can't sell that~wC_BuySell.wav");
}

function remoteUseItem(%client,%type) { 
	%client.throwStrength = 1; 
	%item = getItemData(%type); 
	if (%item == Backpack) { 
		%item = Player::getMountedItem(%client,$BackpackSlot); 
		if(%item == "-1") ixCheckPickup(%client); 
	} else { 
		if (%item == Weapon) 
			%item = Player::getMountedItem(%client,$WeaponSlot); 
	} 
	Player::useItem(%client,%item); 
} 

function ixCheckPickup(%player) { 
	%client = Player::getClient(%player); 
	if(!%player.isDeploying) { 
		if(GameBase::getLOSinfo(%player,5)) { 
			%this = $los::object; 
			%name = GameBase::getDataName(%this); 
			if((%name.className != Armor) && (%name.className != Vehicle) && (%name.className != Generator) && (%name.className != Station)) { 
				%thisTeam = GameBase::getTeam(%this); 
				%team = Client::getTeam(%client); 
				if(%team == %thisTeam) 
					GameBase::virtual(%this,"packUp",$los::position,%client,%player); 
			} 
		} 
	} 
} 

function ixGivePack(%player, %pack, %team) { 
	%obj = newObject("","Item",%pack,1,false); 
	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj); 
	addToSet("MissionCleanup", %obj); 
	GameBase::setPosition(%obj,%player.deployPosition); 
	$TeamItemCount[%team @ %pack]--; 
	playSound(SoundPickupItem,%player.deployPosition); 
	%player.isDeploying = false; 
} 

function ixToggleDeploy(%this) { 
	if(%this.isDeploying) 
		%this.isDeploying = false; 
	else 
		%this.isDeploying = true; 
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
				Client::sendMessage(%client,0,"You got a " @ %item);
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
				Client::sendMessage(%client,0,"You got " @ %delta @ " " @ %item.description);
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
        bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description , $Displaytime);
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
	bottomprint(Player::getClient(%player), "<jc><f2>" @ %item.description @ " Deployed.", $Displaytime);
}


//----------------------------------------------------------------------------
// Flag
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

ItemData LightArmor
{
   heading = "aArmor";
	description = "Peltast (Light)";
	className = "Armor";
	price = 175;
};

ItemData BlastechArmor
{
   heading = "aArmor";
	description = "Blastech";
	className = "Armor";
	price = 200;
};

ItemData MediumArmor
{
   heading = "aArmor";
	description = "Hoplite (Engineer)";
	className = "Armor";
	price = 250;
};

ItemData MagIonArmor
{
   heading = "aArmor";
	description = "Magnetic Ion";
	className = "Armor";
	price = 300;
};

ItemData HeavyArmor
{
   heading = "aArmor";
	description = "Myrmidon (Heavy)";
	className = "Armor";
	price = 400;
};

ItemData MECHArmor
{
   heading = "aArmor";
	description = "MECH/Gundam";
	className = "Armor";
	price = 500;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData JetFireVehicle
{
	description = "JetFire";
	className = "Vehicle";
   heading = "aVehicle";
	price = 0;
};

ItemData ArwingV
{
	description = "Arwing";
	className = "Vehicle";
   heading = "aVehicle";
	price = 100;
};

ItemData EPodV
{
	description = "Lightning";
	className = "Vehicle";
   heading = "aVehicle";
	price = 175;
};

ItemData CutterV
{
	description = "Sky Cutter";
	className = "Vehicle";
   heading = "aVehicle";
	price = 250;
};

ItemData ExplorerV
{
	description = "3DFX Explorer";
	className = "Vehicle";
   heading = "aVehicle";
	price = 375;
};

ItemData RangerV
{
	description = "Sky Ranger";
	className = "Vehicle";
   heading = "aVehicle";
	price = 475;
};

ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
   heading = "aVehicle";
	price = 600;
};

ItemData AvengerV
{
	description = "ThunderTank";
	className = "Vehicle";
   heading = "aVehicle";
	price = 625;
};

ItemData HammerV
{
	description = "Star Hammer";
	className = "Vehicle";
   heading = "aVehicle";
	price = 650;
};

ItemData FighterV
{
	description = "Star Fighter";
	className = "Vehicle";
   heading = "aVehicle";
	price = 675;
};

ItemData LAPCVehicle
{
	description = "LPC -- LandSkimmer";
	className = "Vehicle";
   heading = "aVehicle";
	price = 700;
};

ItemData ValkyrieV
{
	description = "Valkyrie Interceptor";
	className = "Vehicle";
   heading = "aVehicle";
	price = 750;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
   heading = "aVehicle";
	price = 800;
};

ItemData TankV
{
	description = "Hover Tank";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
};

ItemData IcarusV
{
	description = "Annihilator";
	className = "Vehicle";
   heading = "aVehicle";
	price = 1024;
};

	$TeamItemMax[ArwingV] = 5;
	$TeamItemCount[0 @ ArwingV] = 0;
	$TeamItemCount[1 @ ArwingV] = 0;
	$TeamItemCount[2 @ ArwingV] = 0;
	$TeamItemCount[3 @ ArwingV] = 0;

	$TeamItemMax[CutterV] = 5;
	$TeamItemCount[0 @ CutterV] = 0;
	$TeamItemCount[1 @ CutterV] = 0;
	$TeamItemCount[2 @ CutterV] = 0;
	$TeamItemCount[3 @ CutterV] = 0;

	$TeamItemMax[HammerV] = 5;
	$TeamItemCount[0 @ HammerV] = 0;
	$TeamItemCount[1 @ HammerV] = 0;
	$TeamItemCount[2 @ HammerV] = 0;
	$TeamItemCount[3 @ HammerV] = 0;

	$TeamItemMax[ExplorerV] = 5;
	$TeamItemCount[0 @ ExplorerV] = 0;
	$TeamItemCount[1 @ ExplorerV] = 0;
	$TeamItemCount[2 @ ExplorerV] = 0;
	$TeamItemCount[3 @ ExplorerV] = 0;

	$TeamItemMax[RangerV] = 5;
	$TeamItemCount[0 @ RangerV] = 0;
	$TeamItemCount[1 @ RangerV] = 0;
	$TeamItemCount[2 @ RangerV] = 0;
	$TeamItemCount[3 @ RangerV] = 0;

	$TeamItemMax[IcarusV] = 5;
	$TeamItemCount[0 @ IcarusV] = 0;
	$TeamItemCount[1 @ IcarusV] = 0;
	$TeamItemCount[2 @ IcarusV] = 0;
	$TeamItemCount[3 @ IcarusV] = 0;

	$TeamItemMax[AvengerV] = 5;
	$TeamItemCount[0 @ AvengerV] = 0;
	$TeamItemCount[1 @ AvengerV] = 0;
	$TeamItemCount[2 @ AvengerV] = 0;
	$TeamItemCount[3 @ AvengerV] = 0;

	$TeamItemMax[FighterV] = 5;
	$TeamItemCount[0 @ FighterV] = 0;
	$TeamItemCount[1 @ FighterV] = 0;
	$TeamItemCount[2 @ FighterV] = 0;
	$TeamItemCount[3 @ FighterV] = 0;

	$TeamItemMax[TankV] = 1;
	$TeamItemCount[0 @ TankV] = 0;
	$TeamItemCount[1 @ TankV] = 0;
	$TeamItemCount[2 @ TankV] = 0;
	$TeamItemCount[3 @ TankV] = 0;

	$TeamItemMax[ValkyrieV] = 3;
	$TeamItemCount[0 @ ValkyrieV] = 0;
	$TeamItemCount[1 @ ValkyrieV] = 0;
	$TeamItemCount[2 @ ValkyrieV] = 0;
	$TeamItemCount[3 @ ValkyrieV] = 0;

//----------------------------------------------------------------------------
// Tools, Weapons & ammo
//----------------------------------------------------------------------------

function ixDotProd(%vec, %scalar) 
{ %return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar); return %return; } 

function ixSin(%theta) 
{ return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800)); }  

function ixCos(%theta) 
{ return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800)); } 

function ixApplyKickback(%player, %strength, %lift) 
{ if((!%lift) && (%lift != 0)) %lift = 0; %rot = GameBase::getRotation(%player); %rad = getWord(%rot, 2); %x = (-1) * (ixSin(%rad)); %y = ixCos(%rad); %dir = %x @ " " @ %y @ " 0"; %force = ixDotProd(Vector::neg(%dir),%strength); %x = getWord(%force, 0); %y = getWord(%force, 1); %dir = %x @ " " @ %y @ " " @ %lift; Player::applyImpulse(%player,%force); } 

function Sin(%theta)
{ return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));}
 
function Cos(%theta) 
{ return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));}

function NewVector(%vec, %scalar)
{	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function GiveKickback(%player, %strength, %lift)
{	
	if((!%lift) && (%lift != 0)) %lift = 0;
	%rot = GameBase::getRotation(%player);
	%rad = getWord(%rot, 2);
	%x = (-1) * (Sin(%rad));
	%y = Cos(%rad);
	%dir = %x @ " " @ %y @ " 0";
	%force=NewVector(Vector::neg(%dir),%strength);
	%x = getWord(%force, 0);
	%y = getWord(%force, 1);
	%force = %x @ " " @ %y @ " " @ %lift;
	Player::applyImpulse(%player,%force);
}

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

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "gMiscellany";
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

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "oMiscellany";
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

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "oMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Beacon::onUse(%player,%item, %client)
{
	%armor = Player::getArmor(%player);
	%clientId = Player::getClient(%player);

	if (%armor == "larmor" || %armor == "lfemale")
	{
		Gundam::Shield(%clientId, %player);
	}
	if(%armor == "marmor" || %armor == "mfemale")
	{
		EngCamera(%client, %player, %item); 
	} 	
	if(%armor == "harmor" || %armor == "MECH")
	{
		if (player::getitemcount(%clientId, LasCannon) == 1)
		{
			if (%clientId.charging == 1)
			{
				return;
			}
			else if (%clientId.charging = "" || !%clientId.charging)
			{
				LasCannoner::Charge(%clientId, 10);
				%clientId.charging = 1;
				Player::decItemCount(%player,%item);
			}		
		}
	else if (player::getitemcount(%clientId, PlasmaCannon) == 1)
		{
			if (%clientId.charging == 1)
			{
				return;
			}
			else if (%clientId.charging = "" || !%clientId.charging)
			{
				PlasmaCannoner::Charge(%clientId, 8);
				%clientId.charging = 1;
				Player::decItemCount(%player,%item);
			}				
		}
		else 
		{
			if(GameBase::isAtRest(%player)) {
				if(!GameBase::getLOSInfo(%player,4)) {
					%trans = GameBase::getMuzzleTransform(%player); 
				$F1aky = %player;
				$F1aky2 = GameBase::getPosition(%player);
				Projectile::spawnProjectile("F1aker",%trans,%player,"0 0 0");
				GameBase::playSound(%player,bigExplosion1,0);
				Player::decItemCount(%player,%item);
				} 
			else 
			{
			Client::sendMessage(%client,0,"Unable to fire - Item in the way~wC_BuySell.wav");
			}
	} else {
		Client::sendMessage(%client,0,"Cannot fire while moving~wC_BuySell.wav");
	}
	}	
	}
	if (%armor == "BlastechM" || %armor == "BlastechF")
	{    
		Gundam::Cloak(%clientId, %player);
		Player::decItemCount(%player,%item);
	}
	if (%armor == "MagIonM" || %armor == "MagIonF")
	{
		if (Beacon::deployShape(%player,%item)) {
			Player::decItemCount(%player,%item);
		}
	} 
}

function EngCamera(%clientId, %player, %bec) { %item = "CameraPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape"|| GameBase::getDataName($los::object) == "AirAmmoBasePad") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",CameraTurret,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Camera #"@ $totalNumCameras[GameBase::getTeam(%player)]++); GameBase::startFadeout(%camera); %camera.ownerName = Client::getName(%clientId); Client::sendMessage(%client,0,"Camera #"@$totalNumCameras[GameBase::getTeam(%player)]@" deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; echo("MSG: ",%client," ",Client::getName(%client)," deployed a Camera"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s"); return false; } 

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

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "oMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			Player::decItemCount(%player,%item);

			%armor = Player::getArmor(%player);

			if (%armor == "larmor" || %armor == "lfemale" || %armor == "BlastechM" || %armor == "BlastechF")
				%obj = newObject("","Mine","SmallGrenade");		

			if (%armor == "marmor" || %armor == "mfemale" || %armor == "MagIonM" || %armor == "MagIonF")
				%obj = newObject("","Mine","HandGrenade");	

			if (%armor == "harmor" || %armor == "MECH") {
				%bomb1 = newObject("","Mine","PocketNuke1");
				%bomb2 = newObject("","Mine","PocketNuke2"); 	
	 		}
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			if (%armor == "harmor") {
			GameBase::throw(%bomb1,%player,15 * %client.throwStrength,false);
			GameBase::throw(%bomb2,%player,15 * %client.throwStrength,false);
			} 
			else
			{
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			}
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
	}
}

//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "oMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

$InvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;

$ItemMax[harmor, MineAmmo] = 1;
$ItemMax[marmor, MineAmmo] = 1;
$ItemMax[mfemale, MineAmmo] = 1;
$ItemMax[larmor, MineAmmo] = 1;
$ItemMax[lfemale, MineAmmo] = 1;
$ItemMax[BlastechM, MineAmmo] = 1;
$ItemMax[BlastechF, MineAmmo] = 1;
$ItemMax[MagIonM, MineAmmo] = 1;
$ItemMax[MagIonF, MineAmmo] = 1;
$ItemMax[MECH, MineAmmo] = 1;

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
			GameBase::setTeam (%obj,GameBase::getTeam (%player));
		 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
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
function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	%team = Client::getTeam(%client);
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == "BlastFloorShape") 
			if(GameBase::getTeam(Group::getObject(%set,%i)) == %team)
				%num--;
	}
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

function remoteGiveAll(%clientId)
{
	if ($TestCheats) {}
	else if($ServerCheats) {}
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
      $TeamItemCount[0 @ CNode] = 0;
      $TeamItemCount[1 @ CNode] = 0;
      $TeamItemCount[2 @ CNode] = 0;
      $TeamItemCount[3 @ CNode] = 0;

	$TeamItemCount[0 @ ArwingV] = 0;
	$TeamItemCount[1 @ ArwingV] = 0;
	$TeamItemCount[2 @ ArwingV] = 0;
	$TeamItemCount[3 @ ArwingV] = 0;

	$TeamItemCount[0 @ CutterV] = 0;
	$TeamItemCount[1 @ CutterV] = 0;
	$TeamItemCount[2 @ CutterV] = 0;
	$TeamItemCount[3 @ CutterV] = 0;

	$TeamItemCount[0 @ HammerV] = 0;
	$TeamItemCount[1 @ HammerV] = 0;
	$TeamItemCount[2 @ HammerV] = 0;
	$TeamItemCount[3 @ HammerV] = 0;

	$TeamItemCount[0 @ ExplorerV] = 0;
	$TeamItemCount[1 @ ExplorerV] = 0;
	$TeamItemCount[2 @ ExplorerV] = 0;
	$TeamItemCount[3 @ ExplorerV] = 0;

	$TeamItemCount[0 @ RangerV] = 0;
	$TeamItemCount[1 @ RangerV] = 0;
	$TeamItemCount[2 @ RangerV] = 0;
	$TeamItemCount[3 @ RangerV] = 0;

	$TeamItemCount[0 @ IcarusV] = 0;
	$TeamItemCount[1 @ IcarusV] = 0;
	$TeamItemCount[2 @ IcarusV] = 0;
	$TeamItemCount[3 @ IcarusV] = 0;

	$TeamItemCount[0 @ AvengerV] = 0;
	$TeamItemCount[1 @ AvengerV] = 0;
	$TeamItemCount[2 @ AvengerV] = 0;
	$TeamItemCount[3 @ AvengerV] = 0;

	$TeamItemCount[0 @ FighterV] = 0;
	$TeamItemCount[1 @ FighterV] = 0;
	$TeamItemCount[2 @ FighterV] = 0;
	$TeamItemCount[3 @ FighterV] = 0;

	$TeamItemCount[0 @ TankV] = 0;
	$TeamItemCount[1 @ TankV] = 0;
	$TeamItemCount[2 @ TankV] = 0;
	$TeamItemCount[3 @ TankV] = 0;

	$TeamItemCount[0 @ ValkyrieV] = 0;
	$TeamItemCount[1 @ ValkyrieV] = 0;
	$TeamItemCount[2 @ ValkyrieV] = 0;
	$TeamItemCount[3 @ ValkyrieV] = 0;

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

	$TeamItemCount[0 @ dummy] = 0;
	$TeamItemCount[1 @ dummy] = 0;
	$TeamItemCount[2 @ dummy] = 0;
	$TeamItemCount[3 @ dummy] = 0;

	$TeamItemCount[0 @ dummypack] = 0;
	$TeamItemCount[1 @ dummypack] = 0;
	$TeamItemCount[2 @ dummypack] = 0;
	$TeamItemCount[3 @ dummypack] = 0;

	$TeamItemCount[0 @ HoloPack] = 0;
	$TeamItemCount[1 @ HoloPack] = 0;
	$TeamItemCount[2 @ HoloPack] = 0;
	$TeamItemCount[3 @ HoloPack] = 0;

	$TeamItemCount[0 @ treepack] = 0;
	$TeamItemCount[1 @ treepack] = 0;
	$TeamItemCount[2 @ treepack] = 0;
	$TeamItemCount[3 @ treepack] = 0;

      $TeamItemCount[0 @ DronePack] = 0;
      $TeamItemCount[1 @ DronePack] = 0;
      $TeamItemCount[2 @ DronePack] = 0;
      $TeamItemCount[3 @ DronePack] = 0;

        $TeamItemCount[0 @ FluxPack] = 0;
        $TeamItemCount[1 @ FluxPack] = 0;
        $TeamItemCount[2 @ FluxPack] = 0;
        $TeamItemCount[3 @ FluxPack] = 0;

        $TeamItemCount[0 @ Turret4Pack] = 0;
        $TeamItemCount[1 @ Turret4Pack] = 0;
        $TeamItemCount[2 @ Turret4Pack] = 0;
        $TeamItemCount[3 @ Turret4Pack] = 0;

        $TeamItemCount[0 @ DisruptorTurretPack] = 0;
        $TeamItemCount[1 @ DisruptorTurretPack] = 0;
        $TeamItemCount[2 @ DisruptorTurretPack] = 0;
        $TeamItemCount[3 @ DisruptorTurretPack] = 0;

        $TeamItemCount[0 @ IonTurretPack] = 0;
        $TeamItemCount[1 @ IonTurretPack] = 0;
        $TeamItemCount[2 @ IonTurretPack] = 0;
        $TeamItemCount[3 @ IonTurretPack] = 0;

        $TeamItemCount[0 @ PulseTurretPack] = 0;
        $TeamItemCount[1 @ PulseTurretPack] = 0;
        $TeamItemCount[2 @ PulseTurretPack] = 0;
        $TeamItemCount[3 @ PulseTurretPack] = 0;

        $TeamItemCount[0 @ DiscTurretPack] = 0;
        $TeamItemCount[1 @ DiscTurretPack] = 0;
        $TeamItemCount[2 @ DiscTurretPack] = 0;
        $TeamItemCount[3 @ DiscTurretPack] = 0;

        $TeamItemCount[0 @ RocketPack] = 0;
        $TeamItemCount[1 @ RocketPack] = 0;
        $TeamItemCount[2 @ RocketPack] = 0;
        $TeamItemCount[3 @ RocketPack] = 0;

	$TeamItemCount[0 @ ElectroTurretPack] = 0;
	$TeamItemCount[1 @ ElectroTurretPack] = 0;
	$TeamItemCount[2 @ ElectroTurretPack] = 0;
	$TeamItemCount[3 @ ElectroTurretPack] = 0;

	$TeamItemCount[0 @ TeleportPack] = 0;
	$TeamItemCount[1 @ TeleportPack] = 0;
	$TeamItemCount[2 @ TeleportPack] = 0;
	$TeamItemCount[3 @ TeleportPack] = 0;

	$TeamItemCount[0 @ DeployableTeleport] = 0;
	$TeamItemCount[1 @ DeployableTeleport] = 0;
	$TeamItemCount[2 @ DeployableTeleport] = 0;
	$TeamItemCount[3 @ DeployableTeleport] = 0;

	$TeamItemCount[0 @ PortaAmmo] = 0;
	$TeamItemCount[1 @ PortaAmmo] = 0;
	$TeamItemCount[2 @ PortaAmmo] = 0;
	$TeamItemCount[3 @ PortaAmmo] = 0;

	$TeamItemCount[0 @ PortaComm] = 0;
	$TeamItemCount[1 @ PortaComm] = 0;
	$TeamItemCount[2 @ PortaComm] = 0;
	$TeamItemCount[3 @ PortaComm] = 0;

        $TeamItemCount[0 @ doorfivebyfiveForceFieldPack] = 0;
        $TeamItemCount[1 @ doorfivebyfiveForceFieldPack] = 0;
        $TeamItemCount[2 @ doorfivebyfiveForceFieldPack] = 0;
        $TeamItemCount[3 @ doorfivebyfiveForceFieldPack] = 0;

        $TeamItemCount[0 @ doorfourbyeightForceFieldPack] = 0;
        $TeamItemCount[1 @ doorfourbyeightForceFieldPack] = 0;
        $TeamItemCount[2 @ doorfourbyeightForceFieldPack] = 0;
        $TeamItemCount[3 @ doorfourbyeightForceFieldPack] = 0;

        $TeamItemCount[0 @ BlastDoor] = 0;
        $TeamItemCount[1 @ BlastDoor] = 0;
        $TeamItemCount[2 @ BlastDoor] = 0;
        $TeamItemCount[3 @ BlastDoor] = 0;

        $TeamItemCount[0 @ BlastFloor] = 0;
        $TeamItemCount[1 @ BlastFloor] = 0;
        $TeamItemCount[2 @ BlastFloor] = 0;
        $TeamItemCount[3 @ BlastFloor] = 0;

$TeamItemCount[0 @ BaseOpsPack] = 0;
$TeamItemCount[1 @ BaseOpsPack] = 0;
$TeamItemCount[2 @ BaseOpsPack] = 0;
$TeamItemCount[3 @ BaseOpsPack] = 0;

$TeamItemCount[0 @ DeployableBaseOps] = 0;
$TeamItemCount[1 @ DeployableBaseOps] = 0;
$TeamItemCount[2 @ DeployableBaseOps] = 0;
$TeamItemCount[3 @ DeployableBaseOps] = 0;

$TeamItemCount[0 @ jailcappack] = 0;
$TeamItemCount[1 @ jailcappack] = 0;
$TeamItemCount[2 @ jailcappack] = 0;
$TeamItemCount[3 @ jailcappack] = 0;

$TeamItemCount[0 @ jailpack] = 0;
$TeamItemCount[1 @ jailpack] = 0;
$TeamItemCount[2 @ jailpack] = 0;
$TeamItemCount[3 @ jailpack] = 0;

$TeamItemCount[0 @ groundbase] = 0;
$TeamItemCount[1 @ groundbase] = 0;
$TeamItemCount[2 @ groundbase] = 0;
$TeamItemCount[3 @ groundbase] = 0;

$TeamItemCount[0 @ NukePack] = 0;
$TeamItemCount[1 @ NukePack] = 0;
$TeamItemCount[2 @ NukePack] = 0;
$TeamItemCount[3 @ NukePack] = 0;

$TeamItemCount[0 @ BNukePack] = 0;
$TeamItemCount[1 @ BNukePack] = 0;
$TeamItemCount[2 @ BNukePack] = 0;
$TeamItemCount[3 @ BNukePack] = 0;

$TeamItemCount[0 @ TNTPack] = 0;
$TeamItemCount[1 @ TNTPack] = 0;
$TeamItemCount[2 @ TNTPack] = 0;
$TeamItemCount[3 @ TNTPack] = 0;

$TeamItemCount[0 @ C4Pack] = 0;
$TeamItemCount[1 @ C4Pack] = 0;
$TeamItemCount[2 @ C4Pack] = 0;
$TeamItemCount[3 @ C4Pack] = 0;

$TeamItemCount[0 @ HPCPack] = 0;
$TeamItemCount[1 @ HPCPack] = 0;
$TeamItemCount[2 @ HPCPack] = 0;
$TeamItemCount[3 @ HPCPack] = 0;

$TeamItemCount[0 @ DefenderSatPack] = 0;
$TeamItemCount[1 @ DefenderSatPack] = 0;
$TeamItemCount[2 @ DefenderSatPack] = 0;
$TeamItemCount[3 @ DefenderSatPack] = 0;

	%numPlayers = getNumClients();
	
	for(%i = 0; %i < %numPlayers; %i++)
	{	%pl = getClientByIndex(%i);
		if($trace) echo($ver,"| Resetting Team Kill counts for - ",$User[%pl]);
		%pl.teamkills=0;
		%pl.tkobjects=0;
	}

	for(%i = -1; %i < 2 ; %i++)		// AAOD Mod Only Supports 2 Teams at this time
	{	$NodeSet[%i]		= false;
		$AAPCSet[%i]		= false;
		$PowerSet[%i]		= false;
		$PowerSat[%i]		= false;				// Satelite Power System
		$PowerSatSet[%i]	= "";				// Satelite Power System Node Set
		$TeamEnergy[%i]		= $DefaultTeamEnergy;
		$LastEnergy[%i]		= 0;
		$IncTeamEnergy[%i]	= $DefTeamEnergyInc; 
		$ShieldGenOn[%i]	= false;
		$ShieldGen[%i]		= false;
		$NodeSet[%i]		= "";
		$AAPCSet[%i]		= false;
		$LastFlagHolder[%i]	= false;
		$Teleporter[%i]		= false;
		$TeleportNode[%i]	= false;
		$ClassBGen[%i]		= "";
		$ClassAGen[%i]		= "";
		$Alarm[%i]			= false;
		$GenSet[%i]			= "";
				
		$TeamItemCount[%i @ DeployableAmmoPack]			= 0;
		$TeamItemCount[%i @ DeployableInvPack]			= 0;
		$TeamItemCount[%i @ TurretPack]					= 0;
		$TeamItemCount[%i @ CameraPack]					= 0;
		$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
		$TeamItemCount[%i @ PulseSensorPack]			= 0;
		$TeamItemCount[%i @ MotionSensorPack]			= 0;
		$TeamItemCount[%i @ ScoutVehicle]				= 0;
		$TeamItemCount[%i @ LAPCVehicle]				= 0;
		$TeamItemCount[%i @ HAPCVehicle]				= 0;
		$TeamItemCount[%i @ Beacon]						= 0;
		$TeamItemCount[%i @ mineammo]					= 0;
		$TeamItemCount[%i @ deployableTeleport]					= 0;
		$TeamItemCount[%i @ teleportpack]				= 0;
		$TeamItemCount[%i @ AODVelcroPack]				= 0;
		$TeamItemCount[%i @ AODInfernoPack]				= 0;
		$TeamItemCount[%i @ AODForce1Pack]				= 0;
		$TeamItemCount[%i @ AODForce2Pack]				= 0;
		$TeamItemCount[%i @ AODForceDoorS]				= 0;
		$TeamItemCount[%i @ AODForceDoorL]				= 0;
		$TeamItemCount[%i @ AODVehicle1]				= 0;
		$TeamItemCount[%i @ AODVehicle2]				= 0;
		$TeamItemCount[%i @ AODAAPack]					= 0;
		$TeamItemCount[%i @ AODDefender]				= 0;
		$TeamItemCount[%i @ AODArtilleryPack]			= 0;
		$TeamItemCount[%i @ AODMORTPack]				= 0;
		$TeamItemCount[%i @ AODBunker]					= 0;
		$TeamItemCount[%i @ AODBlastShield]				= 0;
		$TeamItemCount[%i @ AODMobileInv]				= 0;
		$TeamItemCount[%i @ AODMobileGen]				= 0;
		$TeamItemCount[%i @ AODShieldGen]				= 0;
		$TeamItemCount[%i @ AODShieldNode]				= 0;
		$TeamItemCount[%i @ AODTeamEGen]				= 0;
		$TeamItemCount[%i @ AODAmbushApPack]			= 0;
		$TeamItemCount[%i @ AODAmbushAAPack]			= 0;
		$TeamItemCount[%i @ AODJumpPad]					= 0;
		$TeamItemCount[%i @ AODTeleporter]				= 0;
		$TeamItemCount[%i @ AODCounterBattery]			= 0;
		$TeamItemCount[%i @ AODSolarTEGen]				= 0;
		$TeamItemCount[%i @ AODPortaSolar]				= 0;
		$TeamItemCount[%i @ AODSatPwrSys]				= 0;
		$TeamItemCount[%i @ AODPowerNode]				= 0;
		$TeamItemCount[%i @ AODAlarm]					= 0;
	}

	$totalNumCameras = 0;



	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}

exec("weapons.cs");
exec("packs.cs");
exec("deployables.cs");

//===========Unpacking Line============//

#####################END!!