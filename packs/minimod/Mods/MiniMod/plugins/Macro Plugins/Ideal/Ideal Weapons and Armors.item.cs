// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they cause
//  massive amounts of clashing with other plugins!!!

$ArmorType[Male, BuildingArmor] = scvarmor;
$ArmorType[Female, BuildingArmor] = scvarmor;
$ArmorName[scvarmor] = BuildingArmor;

$ArmorType[Male, TransformerArmor] = tarmor;
$ArmorType[Female, TransformerArmor] = tarmor;
$ArmorName[tarmor] = TransformerArmor;

$ArmorType[Male, SecretAgentArmor] = secrarmor;
$ArmorType[Female, SecretAgentArmor] = secrarmor;
$ArmorName[secrarmor] = SecretAgentArmor;

$ArmorType[Male, SpecialistArmor] = specarmor;
$ArmorType[Female, SpecialistArmor] = specarmor;
$ArmorName[specarmor] = SpecialistArmor;


$AutoUse[LaserChaingun] = True;
$WeaponAmmo[LaserChaingun] = "";

$AutoUse[SlowGun] = True;
$WeaponAmmo[SlowGun] = "SlowGunAmmo";
$AmmoPackMax[SlowGunAmmo] = 15;
$SellAmmo[SlowGunAmmo] = 5;
$AmmoPackItems[8] = SlowGunAmmo;

$AutoUse[Concuss] = True;
$WeaponAmmo[Concuss] = "ConcussAmmo";
$AmmoPackMax[ConcussAmmo] = 15;
$SellAmmo[ConcussAmmo] = 5;
$AmmoPackItems[9] = ConcussAmmo;

$AutoUse[Cloaker] = True;
$WeaponAmmo[Cloaker] = "";

$TeamItemMax[NuclearTurretPack] = 1;
$TeamItemMax[JetFireVechicle] = 4;
$TeamItemMax[SuperSensorPack] = 2;

$AmmoPackMax[HandgrenadeAmmo] = 10;
$AmmoPackItems[10] = HandgrenadeAmmo;

$AmmoPackMax[C4Ammo] = 5;
$AmmoPackItems[11] = C4Ammo;

$AutoUse[Marlin] = True;
$WeaponAmmo[Marlin] = "MarlinAmmo";
$AmmoPackMax[MarlinAmmo] = 30;
$SellAmmo[MarlinAmmo] = 8;
$AmmoPackItems[12] = ConcussAmmo;

$AmmoPackMax[FlashgrenadeAmmo] = 18;
$AmmoPackItems[13] = FlashgrenadeAmmo;

$AmmoPackMax[StungrenadeAmmo] = 6;
$AmmoPackItems[14] = StungrenadeAmmo;

$Grenade[0] = 5;
$Grenade[1] = C4Ammo;
$Grenade[2] = HandgrenadeAmmo;
$Grenade[3] = FlashgrenadeAmmo;
$Grenade[4] = StungrenadeAmmo;
$Grenade[5] = SuicideAmmo;


$AmmoPackMax[OriginalMine] = 6;
$AmmoPackItems[15] = OriginalMine;
$TeamItemMax[OriginalMine] = 35;

$TeamItemMax[ReplicatingMine] = 35;

$TeamItemMax[FlagMine] = 5;

$Mine[0] = 3;
$Mine[1] = OriginalMine;
$Mine[2] = ReplicatingMine;
$Mine[3] = FlagMine;


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
//=====\=======\
					if(%buyarmor == SCVArmor)
					{
						Player::setItemCount(%client, SCVPack, 1);
						Player::mountItem(%client, SCVPack, $BackpackSlot);
						Player::setItemCount(%client, SCVGun, 1);
						Player::mountItem(%client, SCVGun, $WeaponSlot);
						%numsell = Player::getItemCount(%client, %item);
						Player::decItemCount(%client, FusionGun, %numsell);
					}
					if(%buyarmor != SCVArmor){
						%numsell = Player::getItemCount(%client, %item);
						Player::decItemCount(%client, SCVGun, %numsell);
						%numsell = Player::getItemCount(%client, %item);
						Player::decItemCount(%client, SCVPack, %numsell);
					}
					if(%buyarmor == tarmor)
					{
						Player::setItemCount(%client, JetfirePack, 1);
						Player::mountItem(%client, JetfirePack, $BackpackSlot);
						%numsell = Player::getItemCount(%client, %item);
						Player::decItemCount(%client, FusionGun, %numsell);
					}
					if(%buyarmor != tarmor)
					{
						%numsell = Player::getItemCount(%client, %item);
						Player::decItemCount(%client, JetfirePack, %numsell);
					}
				return 1;
				}

				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
			}
		}
		else if (%item.className == Backpack)
		{
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				else if(%pack == EnergyPack)
				{
					if(Player::getItemCount(%client,"LaserRifle") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						Player::decItemCount(%client,"LaserRifle");
						%gun=LaserRifle;
						teamEnergyBuySell(%player, %gun.price);
					}
//mod:
					if(Player::getItemCount(%client,"LaserChaingun") > 0)
					{
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Chaingun");
						Player::decItemCount(%client,"LaserChaingun");
						%gun=LaserChaingun;
						teamEnergyBuySell(%player, %gun.price);
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
		else if(%item.className == Weapon)
		{
			if(checkResources(%player,%item,1))
			{
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					if(Player::getArmor(%client) != tarmor)
						Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
//mod:
				if(%item == LaserChaingun && Player::getItemCount(%client,"EnergyPack") == 0)
				{
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Chaingun - Auto buying Energy Pack");
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
	 	else if(%item.className == Vehicle)
		{
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
//mod:
		else if(%item.className == Grenade)
		{
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
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
					%max += $AmmoPackMax[%item];
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
				if(Player::getMountedItem(%client, $BackpackSlot) == AmmoPack)
					%max += $AmmoPackMax[%item];
				%count = Player::getItemCount(%client, %item);
				%numToBuy = %max - %count;
				Player::incItemCount(%client,%item, %numToBuy);
				Player::setItemCount(%client,MineAmmo, Player::getItemCount(%client, %item));
				teamEnergyBuySell(%player,(%item.price * -1 * %numToBuy));
				return 1;
			}
		}
		else if(%item.className == Tool)
		{
			if(checkResources(%player,%item,1))
			{
				if(%item == RealTargetingLaser)
				{
					teamEnergyBuySell(%player, TractorBeam.price * Player::getItemCount(%player, TractorBeam));
					Player::setItemCount(%player, TractorBeam, 0);
				}
				else if(%item == TractorBeam)
				{
					teamEnergyBuySell(%player, RealTargetingLaser.price * Player::getItemCount(%player, TargetingLaser));
					Player::setItemCount(%player, RealTargetingLaser, 0);
				}
				Player::incItemCount(%client, %item);
				teamEnergyBuySell(%player, (%item.price * -1));
				Player::setItemCount(%client, TargetingLaser, 1);
				return 1;
			}
		}
		else
		{
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
		    %delta = checkResources(%player,%item,$ItemMax[%armor, %item]);
			 if(%delta || $testCheats)
			{
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client,%item,%delta);
				return 1;
			}
		}
		
 	}
	return 0;
}


function remoteSellItem(%client,%type)
{
	if (isPlayerBusy(%client))
		return;

	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats)
	{
		if(%item == shortEnergyRifle || %item == longEnergyRifle)
			%item = EnergyRifle;

		if(Player::getItemCount(%client,%item) && %item.className != Armor)
		{
			if(%item == EnergyRifle || %item == shortEnergyRifle || %item == longEnergyRifle)
				%client.justUsedELF = 0; //otherwise you get a new elf if you go to the inv with it mounted
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo)
			{
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) 
					%numsell = %count; 
				else 
					%numsell = $SellAmmo[%item];
			}
			else if (%item == ammopack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "")
			{
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == EnergyPack)
			{
				if(Player::getItemCount(%client,"LaserRifle") > 0)
				{
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					Player::decItemCount(%client,"LaserRifle");
					%gun=LaserRifle;
					teamEnergyBuySell(%player, %gun.price);
				}
//mod:
				if(Player::getItemCount(%client,"LaserChaingun") > 0)
				{
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Chaingun");
					Player::decItemCount(%client,"LaserChaingun");
					%gun=LaserChaingun;
					teamEnergyBuySell(%player, %gun.price);
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
///====\=======\=
//JetfirePack
			else if(%item.className == JetfirePack)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, JetfirePack, %numsell);
			}
			else if(%item.className == SCVGun)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, SCVGun, %numsell);
			}
			else if(%item.className == SCVPack)
			{
				%numsell = Player::getItemCount(%client, %item);
				Player::decItemCount(%client, SCVPack, %numsell);
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


function remoteThrowItem(%client,%type,%strength)
{
	//echo("Throw item: " @ %type @ " " @ %strength);
	%item = getItemData(%type);
//mod:

	if(%item == SuicideAmmo || %item == C4Ammo )
	{
		%client.throwStrength = 0;
		Player::useItem(%client, %item);
	}
	else if (%item.className == "Grenade" || %item.className == "HandAmmo" || %item.className == "Mine")
	{
		if (%strength < 0)
			%strength = 0;
		else
			if (%strength > 100)
				%strength = 100;
		%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
		Player::useItem(%client,%item);
	}
}

addPluginWeapon(Mortar, shortEnergyRifle);
addPluginWeapon(Mortar, LaserChaingun);
addPluginWeapon(Mortar, longEnergyRifle);
addPluginWeapon(Mortar, Marlin);
addPluginWeapon(Mortar, SlowGun);
addPluginWeapon(Mortar, Concuss);
addPluginWeapon(Mortar, Cloaker);


function remoteNextWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $NextWeapon[%item] == "")
		selectValidWeapon(%client);
	else
	{
		for (%weapon = $NextWeapon[%item]; %weapon != %item; %weapon = $NextWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				if (%weapon == EnergyRifle && (Player::getMountedItem(%client,$WeaponSlot) == shortEnergyRifle || Player::getMountedItem(%client, $WeaponSlot) == longEnergyRifle))
					break; //mounting ELF will not have EnergyRifle mounted if using long/short range versions
echo("Did not mount... Mounted Item is: " @ Player::getMountedItem(%client, $WeaponSlot) @ " but wanted it to be " @ %weapon);
			}
		}
	}
	Client::centerPrint(%weapon, 1);
	$guns++;
	schedule("clearPrint();", 2);
}

function clearPrint()
{
	$guns--;
	if($guns==0)
		Client::centerPrint("", 1);
}

function remotePrevWeapon(%client)
{
	%item = Player::getMountedItem(%client,$WeaponSlot);
	if (%item == -1 || $PrevWeapon[%item] == "")
		selectValidWeapon(%client);
	else
	{
		for (%weapon = $PrevWeapon[%item]; %weapon != %item; %weapon = $PrevWeapon[%weapon])
		{
			if (isSelectableWeapon(%client,%weapon))
			{
				Player::useItem(%client,%weapon);
				// Make sure it mounted (laser may not), or at least
				// next in line to be mounted.
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
				if (%weapon == EnergyRifle && (Player::getMountedItem(%client,$WeaponSlot) == shortEnergyRifle || Player::getMountedItem(%client, $WeaponSlot) == longEnergyRifle))
					break; //mounting ELF will not have EnergyRifle mounted if using long/short range versions
echo("Did not mount... Mounted Item is: " @ Player::getMountedItem(%client, $WeaponSlot) @ " but wanted it to be " @ %weapon);
			}
		}
	}
	Client::centerPrint("Now using ", %weapon, 1);
	$guns++;
	schedule("clearPrint();", 2);
}

function selectValidWeapon(%client)
{
	%item = cloaker; //changed to allow multiple energy rifle types
	for (%weapon = $NextWeapon[%item]; %cycle != 2; %weapon = $NextWeapon[%weapon])//made %cycle so that it selects elf as first gun too
	{
		if (isSelectableWeapon(%client,%weapon))
		{
			Player::useItem(%client,%weapon);
			break;
		}
		if(%weapon == %item)
			%cycle++;
	}
}

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item])
	{		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack)
		{
			// Only one backpack per armor, and it's always mounted
			if (Player::getMountedItem(%player,$BackpackSlot) == -1)
			{
		 		Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
//				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
				Client::sendMessage(%client,0,"You received a " @ %item.description);
		 		return 1;
			}
		}
//mod:
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

  		else
		{
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon)
			{
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
			if (%delta > 0)
			{
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


ItemData SecretAgentArmor
{
   heading = "aArmor";
	description = "Changeling";
	className = "Armor";
	price = 600;
};

ItemData SpecialistArmor
{
   heading = "aArmor";
	description = "Specialist";
	className = "Armor";
	price = 600;
};

ItemData TransformerArmor
{
   heading = "aArmor";
	description = "Transformer";
	className = "Armor";
	price = 1000;
};

ItemData BuildingArmor
{
   heading = "aArmor";
	description = "SCV";
	className = "Armor";
	price = 1500;
};

ItemData JetFireVehicle
{
	description = "JetFire";
	className = "Vehicle";
   heading = "aVehicle";
	price = 875;
};

ItemImageData JetfirePackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;

	maxEnergy = 0;
	weaponType = 2;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData JetfirePack
{
	description = "Jetfire Transformation";
	className = "Backpack";
	shapeFile = "mortarpack";
	hudIcon = "shieldpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = JetfirePackImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function JetfirePackImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	Player::applyImpulse(%player, "0 0 300");
	%vel = Item::getVelocity(%client);

	if(Player::getMountedItem(%client, $FlagSlot) == "flag")
	{
		Player::dropItem(%client, Player::getMountedItem(%client, $FlagSlot));
		Client::sendMessage(%client, 1, "You dropped the flag while transforming!");
	}

	%item = JetfireVehicle;

	%markerPos = GameBase::getPosition(%client);
	%set = newObject("",Flier, Jetfire, true);
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
}

function JetfirePackImage::onDeactivate(%player, %imageSlot)
{
// do nothing really... all handled by dismounting.
}


function Weapon::onUse(%player,%item)
{
	%client = Player::getClient(%player);

	if(%player.justUsedELF == 1 && %item != %client.elfVersion) //just used elf & not using it now
	{
		Player::setItemCount(%client, shortEnergyRifle, 0);
		Player::setItemCount(%client, longEnergyRifle, 0);
		Player::setItemCount(%client, EnergyRifle, 1);
		%player.justUsedELF = 0;
	}

	%ammo = %item.imageType.ammoType;
	if (%ammo == "") {
		// Energy weapons dont have ammo types
		Player::mountItem(%player,%item,$WeaponSlot);
	}
	else {
		if (Player::getItemCount(%player,%ammo) > 0) 
			Player::mountItem(%player,%item,$WeaponSlot);
		else {
			Client::sendMessage(%client,0, strcat(%item.description," has no ammo"));
		}
	}
}


function Tool::onUse(%player,%item)
{
	if(%player.justUsedELF == 1 && %item != %client.elfVersion) //just used elf & not using it now
	{
		Player::setItemCount(%client, shortEnergyRifle, 0);
		Player::setItemCount(%client, longEnergyRifle, 0);
		Player::setItemCount(%client, EnergyRifle, 1);
		%player.justUsedELF = 0;
	}

	Player::mountItem(%player,%item,$ToolSlot);
}



ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = "";
	accuFire = true;

	//sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

function BlasterImage::onFire(%this,%slot)
{
	%client = GameBase::getOwnerClient(%this);
	if(%client.overloadblaster == 4) //in between modes
	{
		Client::sendMessage(%client, 0, "Please wait...");
		playSound(SoundAccessDenied,GameBase::getPosition(%this));
		return;
	}

	if(%client.overloadblaster == 0)
	{
		if(GameBase::getEnergy(%this) > BlasterImage.maxEnergy)
		{
			playSound(SoundFireBlaster,GameBase::getPosition(%this));

			GameBase::setEnergy(%this, GameBase::getEnergy(%this) - BlasterImage.minEnergy);
			%Trans = GameBase::getMuzzleTransform(%this);
			%ShootVel = Item::getVelocity(%this);

			Projectile::spawnProjectile("BlasterBolt", %Trans, %this, %ShootVel);
		}
		else
			playSound(SoundGunEmpty,GameBase::getPosition(%this));
	}
	else
	{
		%armor = Player::getArmor(%this);
		if(GameBase::getEnergy(%this) == %armor.maxEnergy) //must have full energy to fire
		{
			playSound(SoundPlasmaTurretFire,GameBase::getPosition(%this));

			GameBase::setEnergy(%this, 0);
			%Trans = GameBase::getMuzzleTransform(%this);
			%ShootVel = Item::getVelocity(%this);

			Projectile::spawnProjectile("SuperBlasterBolt", %Trans, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) @ " " @ getWord(%Trans, 4) @ " " @ getWord(%Trans, 5) - 0.1 @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8) ;
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) @ " " @ getWord(%Trans, 4) @ " " @ getWord(%Trans, 5) + 0.1 @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8) ;
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) @ " " @ getWord(%Trans, 4) - 0.1 @ " " @ getWord(%Trans, 5) @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8);
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) @ " " @ getWord(%Trans, 4) + 0.1 @ " " @ getWord(%Trans, 5) @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8);
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) - 0.1 @ " " @ getWord(%Trans, 4) @ " " @ getWord(%Trans, 5) @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8);
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);

			%Transother = getWord(%Trans, 0) @ " " @ getWord(%Trans, 1) @ " " @ getWord(%Trans, 2) @ " " @ getWord(%Trans, 3) + 0.1 @ " " @ getWord(%Trans, 4) @ " " @ getWord(%Trans, 5) @ " " @ getWord(%Trans, 6) @ " " @ getWord(%Trans, 7) @ " " @ getWord(%Trans, 8);
			Projectile::spawnProjectile("OtherBlasterBolt", %Transother, %this, %ShootVel);



			%rand = floor(getRandom() * 5);

			if(%rand)
			{
				schedule("BlasterImage::melt(" @ %client @ ");", 0.4, %this);
			}
		%client.overloadblaster = 0;
		}
		else
			playSound(SoundGunEmpty,GameBase::getPosition(%this));

	}
}

function BlasterImage::melt(%client)
{
	Player::decItemCount(%client, Blaster);
	Client::sendMessage(%client, 1, "The Blaster melted when firing.");
}





ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	projectileType = "";
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

//	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function GrenadeLauncherImage::onFire(%this,%slot)
{
	%ammo = Player::getItemCount(%this, GrenadeAmmo);
	%client = GameBase::getOwnerClient(%this);
	if(%ammo > 0)
	{
		Player::decItemCount(%this, GrenadeAmmo);
		%Trans = GameBase::getMuzzleTransform(%this);
		%ShootVel = Item::getVelocity(%this);
		if(%client.grenType == "")
			%client.grenType = "GrenadeShell";
		Projectile::spawnProjectile(%client.grenType, %Trans, %this, %ShootVel);
		playSound(SoundFireGrenade,GameBase::getPosition(%this));
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
}



ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = "";
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	//sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

function DiscLauncherImage::onFire(%this,%slot)
{
	%ammo = Player::getItemCount(%this, DiscAmmo);
	%client = GameBase::getOwnerClient(%this);
	if(%ammo > 0)
	{
		Player::decItemCount(%this, DiscAmmo);
		%Trans = GameBase::getMuzzleTransform(%this);
		%ShootVel = Item::getVelocity(%this);
		GameBase::getLOSInfo(%this, 20);
		if(%client.discType == "Homing")
			Projectile::spawnProjectile("HomingDiscShell", %Trans, %this, %ShootVel, $los::object);
		else
			Projectile::spawnProjectile("DiscShell", %Trans, %this, %ShootVel);
		playSound(SoundFireDisc,GameBase::getPosition(%this));
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
	
}

ItemImageData DeadWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = 50.0;
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
	mass = 50.0;
	showInventory = false;
};

function DeadWeight::onDrop(%player, %item)
{}

ItemImageData LessWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -4.0;
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
	mass = -4.0;
	showInventory = false;
};

function LessWeight::onDrop(%player, %item)
{}

ItemImageData LessWeight2Image
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -7.0;
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
	mass = -7.0;
	showInventory = false;
};

function LessWeight2::onDrop(%player, %item)
{}

ItemImageData LessWeight3Image
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -11.0;
};

ItemData LessWeight3
{
	description = "Deadweight";
	className = "Tool";
	shapeFile = "grenammo";
   heading = "eDeployables";
	shadowDetailMask = 4;
	imageType = LessWeight3Image;
	price = 0;
	showWeaponBar = false;
	mass = -11.0;
	showInventory = false;
};

function LessWeight3::onDrop(%player, %item)
{}

ItemImageData SCVGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = SCVProjectile;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.5;
	lightColor = { 0, 0, 0 };

	sfxFire = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SCVGun
{
	description = "Nanite Assembler";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SCVGunImage;
	price = 0;
	showWeaponBar = true;
};

ItemData MarlinAmmo
{
	description = "Marlin Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 5;
};


ItemImageData MarlinImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	//projectileType = Marlinshot;
	accuFire = true;
	ammoType = MarlinAmmo;
	reloadTime = 8;
	fireTime = 2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 0.5;
	lightColor = { 0, 0, 0 };

//	sfxFire = ricochet2;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Marlin
{
	description = "Marlin Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MarlinImage;
	price = 750;
	showWeaponBar = true;
};


function MarlinImage::onFire(%this,%slot)
{
	%ammo = Player::getItemCount(%this, MarlinAmmo);
	if(%ammo > 0)
	{
		if(%this.outArea==0)
		{
			Player::decItemCount(%this, MarlinAmmo);
			%client = GameBase::getOwnerClient(%this);
			%Trans = GameBase::getMuzzleTransform(%this);
			%ShootVel = Item::getVelocity(%this);
			Projectile::spawnProjectile("Marlinshot", %Trans, %this, %ShootVel);
			%obj = newObject("","Mine","SmokeGrenade");
	 		addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%this,"0 0 0",0);
			%gunPos = getWord(%trans, 9) @ " " @ getWord(%trans, 10) @ " " @ getWord(%trans, 11);
			GameBase::setPosition(%obj, %gunPos);
			playSound(ricochet2,GameBase::getPosition(%this));
		}
		else
			Client::sendMessage(Player::getClient(%this),0,"You have to be inside the mission area to fire the Marlin." @ "~wbutton1.wav"); 
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
}

ItemImageData LaserChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	projectileType = LaserChain;
	spinUpTime = 0.9;
	spinDownTime = 3;

	accuFire = false;
	reloadTime = 0;
	fireTime = 0.2;
	minEnergy = 5.0;
	maxEnergy = 5.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;

};

ItemData LaserChaingun
{
	description = "Laser Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = LaserChaingunImage;
	price = 300;
	showWeaponBar = true;
};

function LaserChaingun::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have an Energy Pack to use a Laser Chaingun."); 
}

ItemData SlowGunAmmo
{
	description = "Mass Gun Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData SlowGunImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SlowGunAmmo;
	projectileType = SlowPod;
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

ItemData SlowGun
{
	description = "Mass Gun";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "grenade";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = SlowGunImage;
	price = 250;
	showWeaponBar = true;
};

ItemData concussAmmo
{
	description = "Chaos Shots";
	className = "Ammo";
   heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData concussImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = concussAmmo;
	//projectileType = concussShot;
	accuFire = false;
	reloadTime = 0.3;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function concussImage::onFire(%this, %slot)
{
	%ammo = Player::getItemCount(%this, concussAmmo);
	if(%ammo > 0)
	{
		Player::decItemCount(%this, concussAmmo);
		%client = GameBase::getOwnerClient(%this);
		%Trans = GameBase::getMuzzleTransform(%this);
		%ShootVel = Item::getVelocity(%this);
		if(%client.chaosShot == "") //first shot
			%client.chaosShot = "Concussshot";
		Projectile::spawnProjectile(%client.chaosShot, %Trans, %this, %ShootVel);
	}
	else
		Client::sendMessage(Player::getClient(%this),0,"Out of ammo." @ "~wbutton1.wav");
}

ItemData concuss
{
	description = "Chaos Gun";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = concussImage;
	price = 300;
	showWeaponBar = true;
};

ItemImageData CloakerImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained

	projectileType = cloakerbolt;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 1, 0 };

//	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;

};

ItemData Cloaker
{
	description = "Handheld Cloak";
	className = "Weapon";
	shapeFile = "repairgun";
	hudIcon = "deployable";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = CloakerImage;
	price = 0;
	showWeaponBar = true;
};



ItemImageData TractorBeamImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetPull;
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



ItemData TractorBeam
{
	description   = "Tractor Beam";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "cTools";
	shadowDetailMask = 4;
	imageType     = TractorBeamImage;
	price         = 50;
	showWeaponBar = false;
};

function TargetingLaser::onUse(%player,%item)
{
	if(Player::getItemCount(%player, RealTargetingLaser))
		Tool::onUse(%player, RealTargetingLaser);
	else if(Player::getItemCount(%player, TractorBeam))
		Tool::onUse(%player, TractorBeam);
}



ItemImageData RealTargetingLaserImage
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



ItemData RealTargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "cTools";
	shadowDetailMask = 4;
	imageType     = RealTargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

ItemImageData LongEnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = longlightningCharge;
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

ItemData LongEnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = longEnergyRifleImage;
	showWeaponBar = true;
   price = 125;
};


ItemImageData shortEnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = shortlightningCharge;
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

ItemData shortEnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = shortEnergyRifleImage;
	showWeaponBar = true;
   price = 125;
};


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
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%inv, 0.7 * DeployableInvStation.maxDamage);
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
						if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
							GameBase::setDamageLevel(%inv, 0.7 * DeployableAmmoStation.maxDamage);
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


function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle || Player::getMountedItem(%player,$WeaponSlot) == LaserChaingun) 
		Player::unmountItem(%player,$WeaponSlot);
}

ItemImageData SCVPackImage
{
	shapeFile = "mortarammo";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData SCVPack
{
	description = "SCV Building Pack";
	shapeFile = "mortarammo";
	className = "Backpack";
   heading = "dBackpacks";
	shadowDetailMask = 4;
	imageType = SCVPackImage;
	price = 0;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SCVPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		%client = Player::getClient(%player);
		schedule(%client.deployable @ "::deployShape(" @ %player @ ", " @ %client.deployable @ ");", 0.1, %player);
	}
}

ItemImageData SpecialistPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;

	weaponType = 2; // Sustained
	maxEnergy = 0;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SpecialistPack
{
	description = "Specialist Pack";
	className = "Backpack";
	shapeFile = "sensorjampack";
	hudIcon = "deployable";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = SpecialistPackImage;
	price = 0;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function SpecialistPackImage::onActivate(%player, %imageSlot)
{
	if(%player.cloakPack != 1 && %player.cloakGun != 1)
		GameBase::startFadeOut(%player);
	%player.cloakPack = 1;
	%rate = Player::getSensorSupression(%player) + 20;
	if(%rate < 20)
		%rate = 20;
	Player::setSensorSupression(%player,%rate);
	%player.shieldStrength += 0.01;
	Client::sendMessage(Player::getClient(%player), 0, "Specialist Pack activated.");
}

function SpecialistPackImage::onDeactivate(%player, %imageSlot)
{
	if(%player.cloakPack == 1 && %player.cloakGun != 1)
		GameBase::startFadeIn(%player);
	%player.cloakPack = 0;
	%rate = Player::getSensorSupression(%player) - 20;
	if(%rate < 0)
		%rate = 0;
	Player::setSensorSupression(%player,%rate);
	%player.shieldStrength -= 0.01;
	Player::trigger(%player,$BackpackSlot,false);
	Client::sendMessage(Player::getClient(%player), 0, "Specialist Pack deactivated.");
}

ItemImageData ChangelingNetImage
{
	shapeFile = "jetpack";
	mountPoint = 2;

	weaponType = 2; // Sustained
	maxEnergy = 10;

	mountOffset= { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ChangelingNet
{
	description = "Changeling Pack";
	className = "Backpack";
	shapeFile = "jetpack";
	hudIcon = "deployable";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ChangelingNetImage;
	price = 300;
	showWeaponBar = true;
	hiliteOnActive = false;
};

function ChangelingNetImage::onActivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	%team = GameBase::getTeam(%client);
	%client.realteam = %team;
	%client.traitor = 1;
	if(%team == 0)
		%newTeam = 1;
	else
		%newTeam = 0;
	GameBase::setTeam(%client, %newTeam);
	Client::sendMessage(%client, 1, "You appear to have changed teams...");
}

function ChangelingNetImage::onDeactivate(%player, %imageSlot)
{
	%client = Player::getClient(%player);
	GameBase::setTeam(%client, %client.realteam);
	%client.traitor = 0;
	Client::sendMessage(%client, 1, "You have returned to your original team.");
}




function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
//mod:
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
	 	    	%item.HandgrenadeAmmo = %numPack;
			}
			else if(%i == 5) {
	 	    	%item.MortarAmmo = %numPack;
			}
			else if(%i == 6) {
	 	    	%item.C4Ammo = %numPack;
			}
			else if(%i == 7) {
	 	    	%item.SlowGunAmmo = %numPack;
			}
			else if(%i == 8) {
	 	    	%item.ConcussAmmo = %numPack;
			}
			else if(%i == 9) {
	 	    	%item.MarlinAmmo = %numPack;
			}
			else if(%i == 10) {
			%item.FlashgrenadeAmmo = %numPack;
			}
			else if(%i == 11) {
			%item.StungrenadeAmmo = %numPack;
			}
			else {
	 	    	%item.originalMine = %numPack;
			}
		}
	}
}

function checkPacksAmmo(%player, %item)
{
//mod:
	for(%i = 0; %i < 13 ; %i = %i +1) {
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
	    	%numAdd = %item.HandgrenadeAmmo;
		}
		else if(%i == 5) {
 	    	%numAdd = %item.MortarAmmo;
		}
		else if(%i == 6) {
 	    	%numAdd = %item.C4Ammo;
		}
		else if(%i == 7) {
 	    	%numAdd = %item.SlowGunAmmo;
		}
		else if(%i == 8) {
 	    	%numAdd = %item.ConcussAmmo;
		}
		else if(%i == 9) {
 	    	%numAdd = %item.MarlinAmmo;
		}
		else if(%i == 10) {
 	    	%numAdd = %item.FlashgrenadeAmmo;
		}
		else if(%i == 11) {
 	    	%numAdd = %item.StungrenadeAmmo;
		}
		else
		{
			%numAdd = %item.originalMine;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}


ItemData OriginalMine
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "hMine";
   shadowDetailMask = 4;
   price = 10;
	className = "Mine";
};

ItemData ReplicatingMine
{
   description = "Replicating Mine";
   shapeFile = "mineammo";
   heading = "hMine";
   shadowDetailMask = 4;
   price = 20;
	className = "Mine";
};


ItemData FlagMine
{
   description = "Fake Flag Mine";
   shapeFile = "mineammo";
   heading = "hMine";
   shadowDetailMask = 4;
   price = 10;
	className = "Mine";
};

function MineAmmo::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{

			if(Player::getItemCount(%player, OriginalMine))
			{
				%name = "AntipersonelMine";
				%item = OriginalMine;
			}
			else if(Player::getItemCount(%player, ReplicatingMine))
			{
				%name = "ReplicatorMine";
				%item = ReplicatingMine;
			}
			else if(Player::getItemCount(%player, FlagMine))
			{
				%name = "FakeFlag";
				%item = FlagMine;
			}

			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, MineAmmo);
			%obj = newObject("","Mine",%name);
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam(%obj,GameBase::getTeam(%client));//JR 1/31/99
		}
	}
}


ItemData C4Ammo
{
   description = "C4";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 15;
	className = "Grenade";
};


ItemData HandgrenadeAmmo
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 5;
	className = "Grenade";
};

ItemData FlashgrenadeAmmo
{
   description = "Flash Grenade";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 1;
	className = "Grenade";
};

ItemData StungrenadeAmmo
{
   description = "Stun Grenade";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 5;
	className = "Grenade";
};

ItemData SuicideAmmo
{
   description = "Suicide Bomb";
   shapeFile = "grenade";
   heading = "gGrenade";
   shadowDetailMask = 4;
   price = 20;
	className = "Grenade";
};


function Grenade::onUse(%player,%item)
{
	if($matchStarted)
	{
		if(%player.throwTime < getSimTime() )
		{
			%client = Player::getClient(%player);
			if(Player::getItemCount(%player, C4Ammo) > 0)
			{
				%chance = floor(getRandom() * 100);
				if(%chance < 5)
				{
					%item = C4Ammo;
					%name = "C4Oops";
					Client::sendMessage(Player::getClient(%player), 1, "The C4 went off while setting the charge!");
				}
				else if(%chance > 95)
				{
					%item = C4Ammo;
					%name = "C4Dud";
					Client::sendMessage(Player::getClient(%player), 1, "C4 deployed. 10 seconds until detonation.");
					schedule("Client::sendMessage(Player::getClient(" @ %player @ "), 1, 'The C4 did not explode...');", 10.0);
				}
				else
				{
					%item = C4Ammo;
					%name = "C4";
					Client::sendMessage(Player::getClient(%player), 1, "C4 deployed. 10 seconds until detonation.");
				}
			}
			else if(Player::getItemCount(%player, HandgrenadeAmmo) > 0)
			{
				%item = HandgrenadeAmmo;
				%name = "Handgrenade";
			}
			else if(Player::getItemCount(%player, SuicideAmmo) > 0)
			{
				%item = SuicideAmmo;
				%name = "SuicideBomb";
				%client.score -= 4;
			}
			else if(Player::getItemCount(%player, FlashgrenadeAmmo) > 0)
			{
				%item = FlashgrenadeAmmo;
				%name = "Flashgrenade";
			}
			else if(Player::getItemCount(%player, StungrenadeAmmo) > 0)
			{
				%item = StungrenadeAmmo;
				%name = "Stungrenade";
			}
			else
				return;
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player, Grenade);
			%armor = Player::getArmor(%player);
			%obj = newObject("","Mine",%name);
 	 	 	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}



function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if (%numweapon > $MaxWeapons[%armor])
	{
	   %weaponflag = %numweapon - $MaxWeapons[%armor];
	}
	%max = getNumItems2();
	for (%i = 0; %i < %max; %i = %i + 1)
	{
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
//		if(%maxnum != "") //removed so that I need not say maxnum = 0 for each weapon...


			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum)
			{
				%numsell =  %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon)
			{
				%numsell = 1;
				%weaponflag = %weaponflag - 1;
			}
			if(%numsell > 0)
			{
				if(%item != Grenade && %item != MineAmmo && %item != shortEnergyRifle && %item != longEnergyRifle && %item != TargetingLaser) //since they are just place holders, don't announce
				    	Client::sendMessage(%client,0,"SOLD " @ %numsell @ " " @ %item.description);
				teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
			} 
	}
}

// Additional SCVsupport stuff.

function PulseSensorPack::deployShape(%player, %item)
{
	if(Item::deployShape(%player, "Pulse Sensor", DeployablePulseSensor, %item))
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
}

function DeployableSensorJammerPack::deployShape(%player, %item)
{
	if(Item::deployShape(%player, "Sensor Jammer", DeployableSensorJammer, %item))
		$TeamItemCount[GameBase::getTeam(%player) @ "DeployableSensorJammerPack"]++;
}


echo("MiniMod: Please Ignore these warnings. Items need to be re-declared in order for the Ideal Pack to function correctly.");


function getNumItems2()
{
	return 85;
}
