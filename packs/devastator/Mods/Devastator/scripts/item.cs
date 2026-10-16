//----------------------------------------------------------------------------

$ItemFavoritesKey = "Dev";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------

$ItemPopTime = 30;

$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$AutoUse[Blaster] = True;
$AutoUse[Flamethrower] = True;
$AutoUse[Mortar] = True;
$AutoUse[GrenadeLauncher] = True;
$AutoUse[EnergyRifle] = True;
$AutoUse[TargetingLaser] = True;
$AutoUse[ChargeGun] = True;
$AutoUse[LP] = True;
$AutoUse[RL] = True;
$AutoUse[MG] = True;
$AutoUse[FL] = True;
$AutoUse[FP] = True;
$AutoUse[PC] = True;
$AutoUse[SP] = True;
$AutoUse[BH] = True;
$AutoUse[Shotgun1] = True;
$AutoUse[AR] = True;
$AutoUse[SR] = True;
$AutoUse[R] = True;
$AutoUse[V] = True;
$AutoUse[TB] = True;
$AutoUse[F] = True;
$AutoUse[EL] = True;
$AutoUse[Funk] = True;
$AutoUse[Sword] = True;
$AutoUse[PAttack] = True;
$AutoUse[AG] = True;
$AutoUse[Targeter] = True;

$Use[Blaster] = True;

$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, PantherArmor] = qarmor;
$ArmorType[Male, SniperArmor] = srarmor;
$ArmorType[Male, SpecialArmor] = sarmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, PyroArmor] = parmor;
$ArmorType[Male, HeavyArmor] = harmor;
$ArmorType[Male, TigerArmor] = tarmor;
$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, PantherArmor] = qfemale;
$ArmorType[Female, SniperArmor] = srfemale;
$ArmorType[Female, SpecialArmor] = sfemale;
$ArmorType[Female, MediumArmor] = mfemale;
$ArmorType[Female, PyroArmor] = pfemale;
$ArmorType[Female, HeavyArmor] = harmor;
$ArmorType[Female, TigerArmor] = tarmor;
$ArmorType[Male, PsychoArmor] = psarmor;
$ArmorType[Female, PsychoArmor] = psfemale;

$ArmorName[larmor] = LightArmor;
$ArmorName[qarmor] = PantherArmor;
$ArmorName[srarmor] = SniperArmor;
$ArmorName[sarmor] = SpecialArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[parmor] = PyroArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[tarmor] = TigerArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[qfemale] = PantherArmor;
$ArmorName[srfemale] = SniperArmor;
$ArmorName[sfemale] = SpecialArmor;
$ArmorName[mfemale] = MediumArmor;
$ArmorName[pfemale] = PyroArmor;
$ArmorName[psarmor] = PsychoArmor;
$ArmorName[psfemale] = PsychoArmor;

// Amount to remove when selling or dropping ammo
$SellAmmo[DiscAmmo] = 5;
$SellAmmo[GrenadeAmmo] = 5;
$SellAmmo[MortarAmmo] = 5;
$SellAmmo[Beacon] = 5;
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5;
$SellAmmo[RLAmmo] = 5;
$SellAmmo[MGAmmo] = 25;
$SellAmmo[SPAmmo] = 1;
$SellAmmo[Shotgun1Ammo] = 5;
$SellAmmo[ARAmmo] = 5;
$SellAmmo[SRAmmo] = 1;
$SellAmmo[FAmmo] = 5;
$SellAmmo[FlashGrenade] = 5;
$SellAmmo[ELAmmo] = 1;
$SellAmmo[PGLAmmo] = 1;
$SellAmmo[SmokeAmmo] = 1;
$SellAmmo[SmokeAmmo] = 1;

// Max Amount of ammo the Ammo Pack can carry
$AmmoPackMax[PGLAmmo] = 20;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[Beacon] = 10;
$AmmoPackMax[RLAmmo] = 10;
$AmmoPackMax[MGAmmo] = 600;
$AmmoPackMax[Shotgun1Ammo] = 30;
$AmmoPackMax[FlashGrenade] = 10;
$AmmoPackMax[ElAmmo] = 1;
$AmmoPackMax[MultiAmmo] = 20;

// Items in the AmmoPack
$AmmoPackItems[0] = PGLAmmo;
$AmmoPackItems[1] = DiscAmmo;
$AmmoPackItems[2] = GrenadeAmmo;
$AmmoPackItems[3] = Grenade;
$AmmoPackItems[4] = MineAmmo;
$AmmoPackItems[5] = MortarAmmo;
$AmmoPackItems[6] = Beacon;
$AmmoPackItems[7] = RLAmmo;
$AmmoPackItems[8] = MGAmmo;
$AmmoPackItems[9] = Shotgun1Ammo;
$AmmoPackItems[10] = FlashGrenade;
$AmmoPackItems[11] = ElAmmo;
$AmmoPackItems[12] = MultiAmmo;

// Limit on number of special Items you can buy
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[HAPCVehicle] = 1;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[KamikazeVehicle] = 3;
$TeamItemMax[JetVehicle] = 3;
$TeamItemMax[StealthVehicle] = 3;

$TeamItemMax[DisguisePack] = 2;

$TeamItemMax[Beacon] = 40;
$TeamItemMax[mineammo] = 35;

$TeamItemMax[DeployableAmmoPack] = 7;
$TeamItemMax[DeployableInvPack] = 5;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[CameraPack] = 15;
$TeamItemMax[DeployableSensorJammerPack] = 8;
$TeamItemMax[PulseSensorPack] = 15;
$TeamItemMax[MotionSensorPack] = 15;
$TeamItemMax[LaserPack] = 10;
$TeamItemMax[Laser2Pack] = 10;
$TeamItemMax[DTurretPack] = 5;
$TeamItemMax[DEPack] = 5;
$TeamItemMax[ForceFieldPack] = 6; 
$TeamItemMax[BlastWallPack] = 10;
$TeamItemMax[CTurretPack] = 5; 
$TeamItemMax[M350Pack] = 5; 
$TeamItemMax[BunkerPack] = 2;
$TeamItemMax[VehPack] = 1;
$TeamItemMax[PadPack] = 1; 
$TeamItemMax[SolarPack] = 1;

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
$WeaponAmmo[Flamethrower] = "";
$WeaponAmmo[EL] = "ELAmmo";
$WeaponAmmo[LP] = "";
$WeaponAmmo[RL] = "RLAmmo";
$WeaponAmmo[MG] = "MGAmmo";
$WeaponAmmo[FL] = "";
$WeaponAmmo[FP] = "";
$WeaponAmmo[PC] = "";
$WeaponAmmo[SP] = "SPAmmo";
$WeaponAmmo[BH] = "";
$WeaponAmmo[Shotgun1] = "Shotgun1Ammo";
$WeaponAmmo[AR] = "ARAmmo";
$WeaponAmmo[SR] = "SRAmmo";
$WeaponAmmo[TB] = "";
$WeaponAmmo[F] = "FAmmo";
$WeaponAmmo[Sword] = "";
$WeaponAmmo[PAttack] = "RageAmmo";
$WeaponAmmo[DiscLauncher] = "DiscAmmo";
$WeaponAmmo[GrenadeLauncher] = "GrenadeAmmo";
$WeaponAmmo[Mortar] = "MortarAmmo";
$WeaponAmmo[FreezeGun] = "";
$WeaponAmmo[Funk] = "";
$WeaponAmmo[EnergyRifle] = "";
$WeaponAmmo[Multi] = "MultiAmmo";
$WeaponAmmo[Beam] = "";
$WeaponAmmo[THPack] = "";
$WeaponAmmo[Shock] = "";
$WeaponAmmo[Flag] = "";
$WeaponAmmo[SmokeLauncher] = "SmokeAmmo";
$WeaponAmmo[PGL] = "PGLAmmo";
$WeaponAmmo[R] = "RAmmo";
$WeaponAmmo[V] = "";
$WeaponAmmo[Tazer] = "";
$WeaponAmmo[GR] = "GRAmmo";
$WeaponAmmo[Blaster] = "";
$WeaponAmmo[AG] = "";
$WeaponAmmo[HG] = "HGAmmo";
$WeaponAmmo[BlastC] = "";
$WeaponAmmo[Keg] = "";
$WeaponAmmo[Syn] = "SynAmmo";

//----------------------------------------------------------------------------
// WEAPON OPTIONS CODE

$FireModes[Handgrenade] = 8;	//- see mine.cs
$FireModes[Blaster] = 3;	//- BlasterBolt, BlasterBolt2, BlasterBolt3
$FireModes[DiscLauncher] = 3;	//- DiscShell, DiscShell2, DiscShell3
$FireModes[BH] = 2;		//- SpecialShell, PushShell
$FireModes[Shotgun1] = 2;	//- Meson, Normal
$FireModes[EnergyRifle] = 3;	//- 1 Shot, 2 Shots, 3 Shots
$FireModes[Pattack] = 2;	//- Damage, Heal
$FireModes[F] = 3;	        //- Small, Medium, Large

// END WEAPON OPTIONS CODE
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
	if(($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		if($ShowWeapBuyMsg[%clientId] == true)
			Weapon::descriptionMSG(%client,%item,"OnBuy");
		if(%item.className == Armor) {
			if(%item == "Ghost") {
				Player::unMountItem(%client,$WeaponSlot);
				Player::setMountObject(%client,%item,1);
				Client::setControlObject(%client,%item);
			}
			else {
				// Assign armor by requested type & gender 
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
						if(Player::getMountedItem(%client,$BackpackSlot) == ammopack) 
							fillAmmoPack(%client);	
						return 1;
					}
					teamEnergyBuySell(%player,$ArmorName[%armor].price * -1);
				}
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
				else if(%pack == BeamPack) {
					if(Player::getItemCount(%client,"Beam") > 0) {
						Client::sendMessage(%client,0,"Sold Coolant Pack - Auto Selling Beam Cannon");
						remoteSellItem(%client,Beam);
					}
				}
				else if(%pack == AGPack) {
					if(Player::getItemCount(%client,"AG") > 0) {
						Client::sendMessage(%client,0,"Sold Containment Pack - Auto Selling Acid Gun");
						remoteSellItem(%client,AG);
					}
				}
				else if(%pack == FTPack) {
					if(Player::getItemCount(%client,"FlameThrower") > 0) {
						Client::sendMessage(%client,0,"Sold Fuel Tank - Auto Selling FlameThrower");
						remoteSellItem(%client,FlameThrower);
					}
				}
				else if(%pack == FreezePack) {
					if(Player::getItemCount(%client,"FreezeGun") > 0) {
						Client::sendMessage(%client,0,"Sold Liquid Nitrogen Pack - Auto Selling Freeze Gun");
						remoteSellItem(%client,FreezeGun);
					}
				}
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if(checkResources(%player,%item,1) || $testCheats) {
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
				if(%item == Beam && Player::getItemCount(%client,"BeamPack") == 0) {
					buyItem(%client,"BeamPack");
					Client::sendMessage(%client,0,"Bought Beam Cannon - Auto buying Coolant Pack");
				}
				if(%item == AG && Player::getItemCount(%client,"AGPack") == 0) {
					buyItem(%client,"AGPack");
					Client::sendMessage(%client,0,"Bought Acid Gun - Auto buying Containment Pack");
				}
				if(%item == FlameThrower && Player::getItemCount(%client,"FTPack") == 0) {
					buyItem(%client,"FTPack");
					Client::sendMessage(%client,0,"Bought FlameThrower - Auto buying Fuel Pack");
				}
				if(%item == FreezeGun && Player::getItemCount(%client,"FreezePack") == 0) {
					buyItem(%client,"FreezePack");
					Client::sendMessage(%client,0,"Bought Freeze Gun - Auto buying liquid nitrogen Pack");
				}
				if($Clip[%item] != "")
					buyItem(%client,$Clip[%item]);
				Player::incItemCount(%client,%item);
				teamEnergyBuySell(%player,(%item.price * -1));
				%ammoItem =  %item.imageType.ammoType; 
				if(%ammoItem != "" && %ammoItem != "RageAmmo") {
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

ExplosionData FireExp
{
	shapeName = "plasmabolt.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = true;
	lightRange = 4.0;
	timeScale = 0.3;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};
GrenadeData Fire
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = FireExp;
	collideWithOwner = false;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.4;
	damageClass = 0;
	damageValue = 0;
	explosionRadius = 1;
	kickBackStrength = 0.3;
	maxLevelFlightDist = 4;
	totalTime = 0.56;
	liveTime = 0.56;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "plasmabolt.dts";
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
			else if(%item == MG) {
				remoteSellItem(%client,MGAmmo);						
				Player::setItemCount(%player,MGAmmo,0);
				teamEnergyBuySell(%player,MGAmmo.price * Player::getItemCount(%client,MGAmmo));
			}
			else if (%item == ammopack) 
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle) 
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == BeamPack) { 
				if(Player::getItemCount(%client,"Beam") > 0) {
					Client::sendMessage(%client,0,"Sold Coolant Pack - Auto Selling Beam Cannon");
					remoteSellItem(%client,Beam);						
				}
			}
			else if(%item == AGPack) { 
				if(Player::getItemCount(%client,"AG") > 0) {
					Client::sendMessage(%client,0,"Sold Containment Pack - Auto Selling Acid Gun");
					remoteSellItem(%client,AG);						
				}
			}
			else if(%item == FTPack) { 
				if(Player::getItemCount(%client,"FlameThrower") > 0) {
					Client::sendMessage(%client,0,"Sold Fuel Pack - Auto Selling Flame Thrower");
					remoteSellItem(%client,FlameThrower);						
				}
			}
			else if(%item == FreezePack) { 
				if(Player::getItemCount(%client,"FreezeGun") > 0) {
					Client::sendMessage(%client,0,"Sold Liquid Nitrogen Pack - Auto Selling Freeze Gun");
					remoteSellItem(%client,FreezeGun);						
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
	echo("Use item: " @ %type @ " " @ %item);
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
	%armor = Player::getArmor(%client);
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo || %item == FlashGrenade) {
				if (%strength < 0)
					%strength = 0;
				else
					if(%strength > 100)
						%strength = 100;
				%Multiplier = $ThrowStrength[%armor];
				if(!%Multiplier)
					%Multiplier = 1.0;
				%strength *= %Multiplier;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%item);
			}
		}
	}
}

function remoteDropItem(%client,%type)
{
	%armor = Player::getArmor(%client);
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
//---------------------------------------------------------------------------

ItemData Temp
{
        shadowdetailmask = 4;
	description = "Temp"; 
	showInventory = false; 
};

function Temp::onUse(%player,%this)
{
	%temp = $TempType;
	%CurWeapon = Player::getMountedItem(%player,$WeaponSlot);
	if(%CurWeapon == THPack) {
		GameBase::setPosition(%player,GameBase::getPosition(%temp));
		Item::Pop(%temp);
		$TempType = "";
	}
	player::setItemCount(%player,%this,0);
}

ItemData TeleZap
{
        shapeFile = "zap";
        shadowdetailmask = 4;
};

function TeleZap::onAdd(%this)
{
	schedule("Item::Pop("@%this@");",$CorpseTimeoutValue); 
}

function TeleZap::onCollision(%this,%object)
{
	GameBase::applyDamage(%object,$ThisDamageType,0.1, GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
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
	if(%sound != "")  
		playSound(%sound,GameBase::getPosition(%this));
	else
		playSound(SoundPickupItem,GameBase::getPosition(%this));
}	

function Item::respawn(%this)
{
	if(Item::isRotating(%this)) {
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else
		deleteObject(%this);
}	

function Item::onAdd(%this)
{
}

function Item::onCollision(%this,%object)
{
	if(getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if(Item::giveItem(%object,%item,Item::getCount(%this))) {
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
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			if(Player::isDead(%player)) 
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
//	Player::mountItem(%player,%item,$WeaponSlot);
}

//----------------------------------------------------------------------------

BulletData FlagAttack
{
	bulletShapeName    = "breath.dts";
	explosionTag       = BreathExp;
	mass               = 0.1;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 1.0;
	damageType         = $FlagDamageType;
	aimDeflection      = 0.001;
	muzzleVelocity     = 25.0;
	totalTime          = 0.1;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	tracerPercentage   = 1.0;
	tracerLength       = 50;
};

ItemImageData FlagImage
{
	shapeFile = "flag";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.35 }; //-  left-right, back-front, up-down
	weaponType = 0; // Single Shot
	reloadTime = 0.5;
	fireTime = 0.3;
	minEnergy = 0;
	maxEnergy = -1;
	projectileType = FlagAttack;
	accuFire = true;
	sfxFire = SoundThrowItem;
	
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

ItemData LightArmor
{
	heading = "aArmor";
	description = "Pilot";
	className = "Armor";
	shapeFile = "larmor";
	price = 175;
};

ItemData PantherArmor
{
	heading = "aArmor";
	description = "Strider";
	className = "Armor";
	shapeFile = "larmor";
	price = 175;
};

ItemData SniperArmor
{
	heading = "aArmor";
	description = "Sniper";
	className = "Armor";
	shapeFile = "larmor";
	price = 175;
};

ItemData SpecialArmor
{
	heading = "aArmor";
	description = "Specialist";
	className = "Armor";
	shapeFile = "larmor";
	price = 175;
};

function SpecialArmor::onMount(%player,%item) 
{
	GameBase::startFadeOut(%player);
}
function SpecialArmor::onDeath(%player,%item) 
{
	GameBase::startFadeIn(%player);
}

ItemData MediumArmor
{
	heading = "aArmor";
	description = "Engineer";
	className = "Armor";
	shapeFile = "marmor";
	price = 250;
};

ItemData PyroArmor
{
	heading = "aArmor";
	description = "Pyro";
	className = "Armor";
	shapeFile = "marmor";
	price = 255;
};

ItemData HeavyArmor
{
	heading = "aArmor";
	description = "Heavy Infantry";
	className = "Armor";
	shapeFile = "harmor";
	price = 350;
};

ItemData TigerArmor
{
	heading = "aArmor";
	description = "Titan";
	className = "Armor";
	shapeFile = "harmor";
	price = 400;
};

ItemData PsychoArmor
{
	heading = "aArmor";
	description = "Psycho!"; // PORT: the name began with byte 0xA1
	className = "Armor";
	shapeFile = "marmor";
	price = 300;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Black Falcon";
	className = "Vehicle";
	shapeFile = "flyer";
	heading = "aFighters";
	price = 600;
};

ItemData LAPCVehicle
{
	description = "Night Hawk Bomber";
	className = "Vehicle";
	shapeFile = "hover_apc_sml";
	heading = "bBombers";
	price = 675;
};

ItemData HAPCVehicle
{
	description = "B-52 Strato-Fortress";
	className = "Vehicle";
	shapeFile = "hover_apc";
	heading = "bBombers";
	price = 875;
};

ItemData KamikazeVehicle
{
	description = "Kamikaze";
	className = "Vehicle";
	shapeFile = "flyer";
	heading = "cMisc";
	price = 600;
};

ItemData JetVehicle
{
	description = "Eagle Fighter";
	className = "Vehicle";
	shapeFile = "flyer";
	heading = "aFighters";
	price = 600;
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
	if (%state != "Fire" && %state != "Reload" && !$Reload)
		Item::onDrop(%player,%item);
}	

//----------------------------------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
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
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
	heading = "bEnergy Weapons";
	description = "Adv. Blaster";
	className = "Weapon";
	shapeFile  = "energygun";
	hudIcon = "blaster1";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

function BlasterImage::onFire(%player,%slot)
{
	%clientId = Player::getClient(%player);
	if($WeapMode[%clientId,Blaster] == 1||$WeapMode[%clientId,Blaster] == "") {
		%proj = Weapon::onFire(%player,BlasterBolt);
		Gamebase::setEnergy(%player,Gamebase::getEnergy(%player)-(Player::getArmor(%player).maxEnergy/10));
	} else if($WeapMode[%clientId,Blaster] == 2 && GameBase::getEnergy(%player) >= Player::getArmor(%player).maxEnergy/6) {
		%proj = Weapon::onFire(%player,BlasterBolt2);
		Gamebase::setEnergy(%player,Gamebase::getEnergy(%player)-(Player::getArmor(%player).maxEnergy/6));
	} else if($WeapMode[%clientId,Blaster] == 3) {
		%proj = Weapon::onFire(%player,BlasterBolt3);
		Gamebase::setEnergy(%player,Gamebase::getEnergy(%player)-(Player::getArmor(%player).maxEnergy/2.75));
	}
}

//----------------------------------------------------------------------------

ItemImageData PCImage
{
	shapeFile  = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.4;
	fireTime = 0.4;
	minEnergy = 3;
	maxEnergy = 8;

	projectileType = FusionBolt;
	accuFire = true;

	sfxFire = SoundPlasmaTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PC
{
	heading = "bEnergy Weapons";
	description = "Hellfire Cannon";
	className = "Weapon";
	shapeFile  = "mortargun";
	hudIcon = "plas";
	shadowDetailMask = 4;
	imageType = PCImage;
	price = 85;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

ItemData MGAmmo
{
	description = "Minigun Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MGImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountRotation = { 0, 1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.01;

	ammoType = MGAmmo;
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

ItemData MG
{
	description = "Minigun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	heading = "cAmmo-Based Weapons";
	shadowDetailMask = 4;
	imageType = MGImage;
	price = 325;
	showWeaponBar = true;
};

ItemImageData MGSmokerImage
{
	shapeFile = "breath";
  	mountPoint = 0;
	mountRotation = { 1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	mountOffset = { 0, 0.2, 0.0 }; //- X= left-right, Y= back-front, Z= up-down
	weaponType = 0; // Single Shot
	projectileType = MGSmoke;
	accuFire = false;
	reloadTime = 0;
	minEnergy = 2;
	maxEnergy = 5;
	fireTime = 0.01;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData MGSmoker
{
	description = "Smoke";
	className = "Weapon";
	shapeFile = "breath";
	hudIcon = "Mortar";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = MGSmokerImage;
	showInventory = false;
	showWeaponBar = false;
};
$MGBurnSpeed = 50;
function MGImage::onFire(%player, %slot)
{
	%client = Player::getClient(%player);
	%AmmoCount = Player::getItemCount(%player,$WeaponAmmo[MG]);
	if(%AmmoCount > 0) {
		if(GameBase::getEnergy(%player) > 10)
			%proj = Weapon::onFire(%player);
		else if(GameBase::getEnergy(%player) <= 10 && %player.MGcoolMSG == 1) {
			%value = 0.2;
			if(GameBase::getDamageLevel(%player)+%value < Player::getArmor(%player).maxDamage) {
				Player::setDamageFlash(%player,%value);
				GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player)+%value);
			}
			else {
				Player::trigger(%player,%slot,false);
				Player::killOff(%client,%client,$MGBurnDamageType,"BlowUp");
				return;
			}
			Client::sendMessage(%client,1,"YOU WERE BURNED BY THE MINIGUN!!!~waccess_denied.wav");
			%player.MGburncount++;
			Player::trigger(%player,%slot,false);
			if(%player.MGburncount > 3)
				Player::dropItem(%player,MG);
		}
		%player.MGcool++;
		if(%player.currentProj)
			%player.previousProj = %player.currentProj;
		%player.currentProj = %proj;
		if(%player.MGcool > $MGBurnSpeed)
			%player.MGcool = $MGBurnSpeed;
		%pos = GameBase::getPosition(%proj);
		CheckMGcool(%player,%pos);
		if(!%player.checkcooling || %player.checkcooling == "" || %player.checkcooling == 0) {
			%player.checkcooling = 1;
			schedule("MGCool::CheckState("@%player@");",0.9);
		}
	}
}

function CheckMGcool(%player,%pos)
{
	if(%player.MGcool == $MGBurnSpeed) {
		Player::trigger(%player,7,true);
		Player::trigger(%player,7,false);
		if(!%player.MGcoolMSG || %player.MGcoolMSG == 0) {
			Client::sendMessage(Player::getClient(%player),1,"WARNING! MINIGUN OVERHEATING!!!~waccess_denied.wav");
			%player.MGcoolMSG = 1;
			schedule(%player @ ".MGcoolMSG--;",1);
		}
	}
}

function MGCool::CheckState(%player)
{
	if(Player::getItemState(%player,$WeaponSlot) == "SpinDown")
		bottomprint(Player::getClient(%player),"<jc><f0>Minigun cooling...");
	else if(Player::getItemState(%player,$WeaponSlot) == "Idle") {
		%player.MGcool = 0;
		%player.checkcooling = 0;
		bottomprint(Player::getClient(%player),"<jc><f0>Minigun Ready!",1);
		return;
	}
	schedule("MGCool::CheckState("@%player@");",1.0,%player);
}

function MG::onMount(%player,%item)
{
	Player::mountItem(%player,MGSmoker,7);
}

function MG::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

//----------------------------------------------------------------------------

ItemImageData FunkImage
{
   	shapeFile  = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0.3;
	fireTime = 0.4;

	minEnergy = 5;
	maxEnergy = 6;
	projectileType = FunkBlast;
	accuFire = true;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Funk
{
	heading = "zFun Weapons";
	description = "Party Gun";
	className = "Weapon";
   	shapeFile  = "grenadeL";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = FunkImage;
	price = 235;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

ItemData Shotgun1Ammo
{
	description = "Shotgun Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData Shotgun1Image
{
	shapeFile = "shotgun";
	mountPoint = 0;

	weaponType = 0; 
	reloadTime = 0.9;
	fireTime = 0.0;
     
	ammoType = Shotgun1Ammo;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = MineExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Shotgun1
{
	description = "Adv. Shotgun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "Shotgun";
	heading = "cAmmo-Based Weapons";
	shadowDetailMask = 4;
	imageType = Shotgun1Image;
	price = 200;
	showWeaponBar = true;
};

function Shotgun1Image::onFire(%player, %slot)
{
	%clientId = Player::getClient(%player);
	%AmmoCount = Player::getItemCount(%player,$WeaponAmmo[Shotgun1]);
	if(($WeapMode[%clientId,Shotgun1] == 1||$WeapMode[%clientId,Shotgun1] == "")&&(%AmmoCount > 0)) {
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet,False);
		Weapon::onFire(%player,Shotgun1bullet);
	}
	else if($WeapMode[%clientId,Shotgun1] == 2 && %AmmoCount >= 2) {
		Weapon::onFire(%player,MShot1,False);
		Weapon::onFire(%player,MShot1,False);
		Weapon::onFire(%player,MShot1,False);
		Weapon::onFire(%player,MShot1,False);
		Weapon::onFire(%player,MShot1,False);
		Weapon::onFire(%player,MShot2,False);
		Weapon::onFire(%player,MShot2,False);
		Weapon::onFire(%player,MShot2,False);
		Weapon::onFire(%player,MShot2,False);
		Weapon::onFire(%player,MShot2,False);
		Weapon::onFire(%player,MShot3,False);
		Weapon::onFire(%player,MShot3,False);
		Weapon::onFire(%player,MShot3,False);
		Weapon::onFire(%player,MShot3);
		Weapon::onFire(%player,MShot3);
	}
	else if($WeapMode[%clientId,Shotgun1] == 2 && %AmmoCount < 2)
		Player::useItem(%player,ShotgunClip);
}

//----------------------------------------------------------------------------

ItemImageData FPImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = MiniPlasmaBolt;
	accuFire = true;
	minEnergy = 3;
	maxEnergy = 4;
	reloadTime = 0.1;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundJetHeavy;
	sfxReload = SoundDryFire;
};

ItemData FP
{
	description = "Plasma Pistol";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "plasma";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = FPImage;
	price = 175;
	showWeaponBar = true;
};

//=======================================

ItemData ARAmmo
{
	description = "Assault Bullets";
	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ARImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ARAmmo;
	accuFire = true;
	reloadTime = 0.15;
	fireTime = 0.01;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = debrisSmallExplosion;
	sfxActivate = SoundDryFire;
};

ItemData AR
{
	description = "Assault Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = ARImage;
	price = 175;
	showWeaponBar = true;
};
$CaseSpeed = 0.3;
function ARImage::onFire(%player,%slot)
{
	%AmmoCount = Player::getItemCount(%player,ARAmmo);
	if(%AmmoCount > 0) {
		if(Player::getMountedItem(%player,$BackpackSlot) == CSDPack)
			Weapon::onFire(%player,AssaultBullet2);
		else
			Weapon::onFire(%player,AssaultBullet);
		%trans = GameBase::getMuzzleTransform(%player);
		%vec0 = getWord(%trans,0);
		%vec1 = getWord(%trans,1);
		%vec2 = getWord(%trans,2);
		%vec3 = getWord(%trans,6);
		%vec4 = getWord(%trans,7);
		%vec5 = getWord(%trans,8);
		%vec6 = getWord(%trans,9);
		%vec7 = getWord(%trans,10);
		%vec8 = getWord(%trans,11);
		%rot1 = %vec3@" "@%vec4@" "@%vec5;
		%pos1 = %vec6@" "@%vec7@" "@%vec8;
		%vecRot = Vector::Add(GameBase::getRotation(%player),"0 0 3.141592654");
		%posVec = Vector::getFromRot(%vecRot,0.5);
		%pos1 = Vector::Add(%pos1,%posVec);
		%rot0 = Vector::getRotAim(%Pos1,%targetPos);
		%rotCas = Vector::Add(GameBase::getRotation(%player),"1.570796327 0.7853981635 0");
		//%rotCas = Vector::Add(GameBase::getRotation(%player),"0 0 -1.570796327");
		%vecCas = Vector::getFromRot(%rotCas,$CaseSpeed);
		%trans = %vec0@" "@%vec1@" "@%vec2@" "@%vecCas@" "@%rot1@" "@%pos1;
		%casing = Projectile::spawnProjectile("ShellCasing",%trans,%player,"0 0 1");
	}
}
//=======================================

ItemData SPAmmo
{
	description = "S. Pistol Ammo";
   	heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SPImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = SPAmmo;
	projectileType = PistolBullet;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.7;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundJetLight;
	sfxActivate = SoundJetLight;
	sfxReload = SoundJetLight;
};

ItemData SP
{
	description = "Silenced Pistol";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "chain";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = SPImage;
	price = 175;
	showWeaponBar = true;
};

//--------------------------------------
ItemImageData EnergyrifleImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0;
	spinDownTime = 0;
	fireTime = 0.2;

	minenergy = 2;
	maxenergy = 9;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundPickUpWeapon;
};

ItemData EnergyRifle
{
	description = "Confetti Launcher";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "chain";
   	heading = "zFun Weapons";
	shadowDetailMask = 4;
	imageType = EnergyRifleImage;
	price = 125;
	showWeaponBar = true;
};

function EnergyRifleImage::onFire(%player, %slot)
{
	%clientId = Player::getClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	if(($WeapMode[%clientId,EnergyRifle] == 1||$WeapMode[%clientId,EnergyRifle] == "")&& Gamebase::getEnergy(%player) > 0) {
		Weapon::onFire(%player,confetti);
		Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) - 4);
	} else if($WeapMode[%clientId,EnergyRifle] == 2 && Gamebase::getEnergy(%player) > 0) {
		Weapon::onFire(%player,confetti);
		Weapon::onFire(%player,confetti2);
		Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) - 8);
	} else if($WeapMode[%clientId,EnergyRifle] == 3 && Gamebase::getEnergy(%player) > 0) {
		Weapon::onFire(%player,confetti);
		Weapon::onFire(%player,confetti2);
		Weapon::onFire(%player,confetti3);
		Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) - 12);
	}
}

//----------------------------------------------------------------------------

ItemImageData FreezeImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = liquidnitrogen;
	accuFire = true;
	minEnergy = 3;
	maxEnergy = 4;
	reloadTime = 0.1;
	fireTime = 0.01;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundJetHeavy;
	sfxReload = SoundJetHeavy;
};

ItemData FreezeGun
{
	description = "Freeze Gun";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = FreezeImage;
	price = 175;
	showWeaponBar = true;
};

function FreezeGun::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == FreezePack)
		Weapon::onUse(%player,%item);
	else if(IsIce(Player::getClient(%player)))
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Freeze Tank to use the Freeze Gun."); 
}

//----------------------------------------------------------------------------

ItemImageData AGImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = Acid;
	accuFire = true;
	minEnergy = 3;
	maxEnergy = 4;
	reloadTime = 0.1;
	fireTime = 0.01;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundJetHeavy;
	sfxActivate = SoundJetHeavy;
	sfxReload = SoundJetHeavy;
};

ItemData AG
{
	description = "Acid Gun";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = AGImage;
	price = 175;
	showWeaponBar = true;
};

function AG::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == AGPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,"Must have a Containment Pack to use the Acid Gun."); 
}

ItemImageData AGPackImage
{
	shapeFile = "sensor_small";
	weaponType = 2;  // Sustained
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 }; //-  left-right, back-front, up-down
	mountRotation = { -1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData AGPack
{
	description = "Containment Pack";
	shapeFile = "ammopack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = AGPackImage;
	price = 150;
	hudIcon = "plasammo";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AGPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
}
function AGPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function AGPack::onUnmount(%player,%item)
{
	if(Player::getMountedItem(%player,$WeaponSlot) == AG) 
		Player::unmountItem(%player,$WeaponSlot);
}

//---------------------------------------------------------

ItemImageData FreezePackImage
{
	shapeFile = "plasammo";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData FreezePack
{
	description = "Liquid Nitrogen Tank";
	shapeFile = "plasammo";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = FreezePackImage;
	price = 150;
	hudIcon = "plasammo";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FreezePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
}
function FreezePack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function FreezePack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == FreezeGun) 
		Player::unmountItem(%player,$WeaponSlot);
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
	shapeFile = "GrenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
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
	description = "Adv. Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenadeL";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price =   50;
	showWeaponBar = true;
};

function GrenadeLauncherImage::onFire(%player, %slot)
{
	if(Player::getItemCount(%player,$WeaponAmmo[GrenadeLauncher]) > 0) {
		if(Player::getMountedItem(%player,$BackpackSlot) == CSDPack)
			Weapon::onFire(%player,AdvGrenShell);
		else
			Weapon::onFire(%player,GrenadeShell);
	}
}

//----------------------------------------------------------------------------

ItemData RLAmmo
{
	description = "Rocket Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RLImage
{
	shapeFile = "grenadeL";
  	mountPoint = 0;
	mountOffset = { -0.1, -0.4, 0.4 }; //-  left-right, back-front, up-down
	mountRotation = { 0, -1.5, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = shockExplosion;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData RL
{
	description = "Rocket Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "Mortar";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = RLImage;
	price = 375;
	showWeaponBar = true;
};

function RL::onMount(%player,%item)
{
	Player::mountItem(%player,Targeter,7);
}

function RL::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function RLImage::onFire(%player,%slot)
{
	Player::trigger(%player,7,true);
	schedule("Player::trigger("@%player@","@7@","@false@");",0.5);
	Weapon::onFire(%player);
}

ItemImageData TargeterImage
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

ItemData Targeter
{
	description   = "Targeter";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   	heading = "dTools";
	shadowDetailMask = 4;
	imageType     = TargeterImage;
	price         = 50;
	showInventory = false;
	showWeaponBar = false;
};

ItemImageData Targeter2Image
{
	shapeFile   = "repairgun";
	mountPoint  = 0;

	weaponType  = 2; // Sustained
	projectileType = targetLaser;
	accuFire    = true;
	minEnergy   = 5;
	maxEnergy   = 15;
	reloadTime  = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Targeter2
{
	description   = "Targeter2";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   	heading       = "dTools";
	shadowDetailMask = 4;
	imageType     = Targeter2Image;
	price         = 50;
	showWeaponBar = false;
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
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------
ItemData FAmmo
{
	description = "Flare Ammo";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData FImage
{
	shapeFile = "energygun";
	mountPoint = 0;
	mountRotation = { 0, 3, 0 };
	weaponType = 0; // Single Shot
	ammoType = Fammo;
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

ItemData F
{
	description = "Flare Gun";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "mortar";
	heading = "dTools";
	shadowDetailMask = 4;
	imageType = FImage;
	price = 375;
	showWeaponBar = true;
};

function FImage::onFire(%player,%slot)
{
	%client = Player::getClient(%player);
	echo(getCommandStatus(%client));
	%AmmoCount = Player::getItemCount(%player, FAmmo);
	if(%AmmoCount > 0) {
		if($WeapMode[%client,F] == 1||$WeapMode[%client,F] == "")
			Weapon::onFire(%player,FlareShell);
		else if($WeapMode[%client,F] == 2)
			Weapon::onFire(%player,FlareShellMed);
		else if($WeapMode[%client,F] == 3)
			Weapon::onFire(%player,FlareShellLarge);
		%clientName = client::GetName(%client);
		messageAll(0,%clientName@": Help Me!!!~wShell_Click.wav");
		%value = Player::getArmor(%player).maxDamage/10.1;
		if(GameBase::getDamageLevel(%player)+%value < Player::getArmor(%player).maxDamage) {
			Player::setDamageFlash(%player,%value);
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player)+%value);
		}
		else {
			Player::trigger(%player,%slot,false);
			Player::killOff(%client,%client,$FlareOopsDamageType,"BlowUp");
			return;
		}
	}
}

//----------------------------------------------------------------------------

ItemImageData BHImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = false;
	reloadTime = 5.0;
	fireTime = 3.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFloatMineExplosion;
	sfxActivate = SoundMineActivate;
	sfxReload = SoundActivateAmmoStation;
	sfxReady = SoundLaserIdle;
};

ItemData BH
{
	description = "Disruptor Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = BHImage;
	price = 375;
	showWeaponBar = true;
};

function BHImage::onFire(%player,%slot)
{
	%clientId = Player::getClient(%player);
	if($WeapMode[%clientId,BH] == 1 || $WeapMode[%clientId,BH] == "") {
		Weapon::onFire(%player,SpecialShell);
		Gamebase::setEnergy(%player,Gamebase::getEnergy(%player)-(Player::getArmor(%player).maxEnergy/2));
	} else if($WeapMode[%clientId,BH] == 2) {
		Weapon::onFire(%player,PushShell);	
		Gamebase::setEnergy(%player,Gamebase::getEnergy(%player)-(Player::getArmor(%player).maxEnergy/2));
	}
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
	description = "Adv. Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "Fdisk";
	heading = "cAmmo-based Weapons";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function DiscLauncherImage::onFire(%player,%slot)
{
	%clientId = Player::getClient(%player);
	%AmmoCount = Player::getItemCount(%player, DiscAmmo);
	if(%AmmoCount > 0) {
		if($WeapMode[%clientId,DiscLauncher] == 1||$WeapMode[%clientId,DiscLauncher] == "") {
			if(Player::getMountedItem(%player,$BackpackSlot) == CSDPack)
				Weapon::onFire(%player,AdvDiscShot,GameBase::getMuzzleTransform(%player),%player,Item::getVelocity(%player));
			else
				Weapon::onFire(%player,DiscShell);
		}
		else if($WeapMode[%clientId,DiscLauncher] == 2) {
			Weapon::onFire(%player,DiscShell2);
			Gamebase::setEnergy(%player,Gamebase::getEnergy(%player)-(Player::getArmor(%player).maxEnergy/10));
		}
		else if($WeapMode[%clientId,DiscLauncher] == 3)
			Weapon::onFire(%player,DiscShell3);
}
}
//----------------------------------------------------------------------------

ItemImageData LPImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = PistolLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.7;
	minEnergy = 4;
	maxEnergy = 20;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundPackFail;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LP
{
	description = "Laser Pistol";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "sniper";
	heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = LPImage;
	price = 200;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

ItemImageData FLImage
{
	shapeFile = "Paintgun";
	mountPoint = 0;

	weaponType = 2;
	projectileType = FlashBeam;
	minEnergy = 0.00000001;
	maxEnergy = 0.0000001;
	reloadTime = 0.2;
	lightType = 0;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 10, 10, 10 };

	sfxActivate = SoundPickUpWeapon;
};

ItemData FL
{
	description = "Flashlight";
	className = "Tool";
	shapeFile = "paintGun";
	hudIcon = "sniper";
	heading = "dTools";
	shadowDetailMask = 4;
	imageType = FLImage;
	price = 200;
	showWeaponBar = true;
};

function FL::onMount(%player,%item) 
{
	Player::mountItem(%player,Targeter2,7);
}

function FL::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

//----------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "repairgun";
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
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
   	heading = "dTools";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

//------------------------------------------------------------------------------

ItemImageData TBImage
{
	shapeFile = "grenammo";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = ToolBolt;
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

ItemData TB
{
	description = "Toolbox";
	shapeFile = "grenammo";
	hudIcon = "energygun";
	className = "Tool";
	heading = "dTools";
	shadowDetailMask = 4;
	imageType = TBImage;
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
	Bottomprint(%client, "<jc>The Medic Pack repairs things at a good speed, short range though.");
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
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::trigger(%player,$BackpackSlot);
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
	heading = "fDeployables";
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
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
	heading = "fDeployables";
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
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
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

ItemImageData TGPackImage
{
	shapeFile = "shieldpack";
	weaponType = 0;
	projectileType = BoosterBlast;
	reloadTime = 2;

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = 2;
 	maxEnergy = 5;
	firstPerson = false;
};

ItemData TGPack
{
	description = "Booster Pack";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = TGPackImage;
	price = 150;
	hudIcon = "jetpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function TGPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Booster Pack On");
	Player::mountItem(%this,LessWeight,10);
}

function TGPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Booster Pack Off");
	Player::trigger(%player,$BackpackSlot,false);
	Player::decItemCount(%this,LessWeight);
}

//----------------------------------------------------------------------------

ItemImageData PTPackImage
{
	shapeFile = "jetpack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -10;
 	maxEnergy = -10;
	firstPerson = false;
};

ItemData PTPack
{
	description = "Pilot Pack";
	shapeFile = "jetpack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = PTPackImage;
	price = 150;
	hudIcon = "jetpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PTPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
}

function PTPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//----------------------------------------------------------------------------

ItemImageData FTPack2Image
{
	shapeFile = "mortar";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0.1, -0.1, 0.0 };
	mountRotation = { -1.5, 0, -1.5 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData FTPack2
{
	description = "Fuel Tank2";
	className = "Weapon";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	imageType = FTPack2Image;
	showWeaponBar = false;
};

ItemImageData FTPackImage
{
	shapeFile = "mortar";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { -0.1, -0.1, 0 };
	mountRotation = { -1.5, 0, -1.5 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData FTPack
{
	description = "Fuel Tank";
	shapeFile = "plasammo";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = FTPackImage;
	price = 150;
	hudIcon = "plasammo";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FTPack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
}


function FTPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
	Player::MountItem(%player, FTPack2, 4);
}

function FTPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == Flamethrower) 
		Player::unmountItem(%player,$WeaponSlot);
	Player::UnMountItem(%player, 4);
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
	description = "Medic Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if(Player::getMountedItem(%player,$WeaponSlot) == RepairGun)
		Player::unmountItem(%player,$WeaponSlot);
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::mountItem(%player,RepairGun,$WeaponSlot);
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if(%mounted == RepairGun)
			Player::unmountItem(%player,$WeaponSlot);
		Item::onDrop(%player,%item);
	}
}	

//----------------------------------------------------------------------------

ItemImageData ShieldPackImage
{
	shapeFile = "shieldpack";
	mountPoint = 2; 
	weaponType = 0;
	projectileType = ShieldBlast;
	reloadTime = 0;
	minEnergy = -1;
	maxEnergy = -4;   // Energy/sec for sustained weapons
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Flight Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Flight Pack On");
	%CurSup = Player::getSensorSupression(%player); 
	Player::setSensorSupression(%player, %CurSup-20);
	GameBase::setIsTarget(%player, True);
}

function ShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Flight Pack Off");
	Player::trigger(%player,$BackpackSlot,false);
	%CurSup = Player::getSensorSupression(%player); 
	Player::setSensorSupression(%player, %CurSup+20);
	GameBase::setIsTarget(%player, False);
}

//----------------------------------------------------------------------------

ItemImageData CSDPackImage
{
	shapeFile = "shieldpack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 0;  // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CSDPack
{
	description = "Weapon Enhancent Pack";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = CSDPackImage;
	price = 200;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CSDPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>The Weapon Enhancement Pack will make a few of your weapons better.");
}

//----------------------------------------------------------------------------

ItemImageData CDPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 5;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CDPack
{
	description = "Cloaking Device";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = CDPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CDPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
	GameBase::startFadeOut(%player);
}

function CDPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	GameBase::startFadeIn(%player);
	Player::trigger(%player,$BackpackSlot,false);
}

function CDPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>The Cloaking Device renders you invisible for a certian period of time.");
}

//=======================================

ItemImageData PCDPackImage 
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 8;
	maxEnergy = 9;
	reloadTime = 0.2;
	lightType = 2;   
	lightRadius = 4;
	lightTime = 0.5;
	lightColor = { 10, 10, 10 };
};

ItemData PCDPack 
{
  description = "Distraction Device";
  shapeFile = "discammo";
  className = "Backpack";
  heading = eBackpacks;
  shadowDetailMask = 4;
  imageType = PCDPackImage;
  price = 275;
  hudIcon = "discammo";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function PCDPackImage::onActivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Distraction On");
}

function PCDPackImage::onDeactivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Distraction Device Off");
	Player::trigger(%player,$BackpackSlot,false);
}

function PCDPack::onMount(%player,%item) 
{
	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc>Use this too lure the enemy away.");
}

//-----------------------------------

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
	description = "Force Field"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
	heading = fDeployables; 
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
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function ForceFieldPack::onDeploy(%player,%item,%pos) 
{ 
	if (ForceFieldPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item);

} 

function ForceFieldPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objForceField = newObject("","StaticShape",DeployableForceField,true); 
	addToSet("MissionCleanup", %objForceField); 
	GameBase::setTeam(%objForceField,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objForceField,$los::position); 
	GameBase::setRotation(%objForceField,%rot); 
	Gamebase::setMapName(%objForceField,"Force Field"); 
	Client::sendMessage(%client,0,"Force Field Deployed"); 
	GameBase::startFadeIn(%objForceField); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "ForceFieldPack"]++; 
        reportDeploy(%objForceField, %client);
	return true; 
} 

//-------------------------------------

ItemImageData BlastWallPackImage 
{ 
	shapeFile = "AmmoPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData BlastWallPack 
{ 
	description = "BlastWall"; 
	shapeFile = "newdoor5"; 
	className = "Backpack"; 
	heading = fDeployables; 
	imageType = BlastWallPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function BlastWallPack::onUse(%player,%item) 
{ 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function BlastWallPack::onDeploy(%player,%item,%pos) 
{ 
	if (BlastWallPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function BlastWallPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) 
	{ Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); return false; }

	if (!GameBase::getLOSInfo(%player,3)) 
	{ Client::sendMessage(%client,0,"Deploy position out of range"); return false; }

	if (Vector::dot($los::normal,"0 0 1") <= 0.7) 
	{ Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); return false; }

	 //
	 // Passed validation, create the object
	 //
	%rot = GameBase::getRotation(%player); 
	%objBlastWall = newObject("","StaticShape",BlastWall,true); 
	addToSet("MissionCleanup", %objBlastWall); 
	GameBase::setTeam(%objBlastWall,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objBlastWall,$los::position); 
	GameBase::setRotation(%objBlastWall,%rot); 
	Gamebase::setMapName(%objBlastWall,"Bulkhead"); 
	Client::sendMessage(%client,0,"Bulkhead Deployed"); 
	GameBase::startFadeIn(%objBlastWall); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "BlastWallPack"]++; 
        reportDeploy(%objBlastWall, %client);
	return true; 
} 

//-------------------------------------

ItemImageData BunkerPackImage 
{ 
	shapeFile = "AmmoPack"; 
	mountPoint = 2; 
	mountOffset = { 0, -0.1, 0 }; 
	mass = 2.5; 
	firstPerson = false; 
}; 

ItemData BunkerPack 
{ 
	description = "Bunker"; 
	shapeFile = "AmmoPack"; 
	className = "Backpack"; 
	heading = fDeployables; 
	imageType = BunkerPackImage; 
	shadowDetailMask = 4; 
	mass = 1.5; 
	elasticity = 0.2; 
	price = 600; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
}; 

function BunkerPack::onUse(%player,%item) 
{ 
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot); 
	else 
		Player::deployItem(%player,%item); 
} 

function BunkerPack::onDeploy(%player,%item,%pos) 
{ 
	if(BunkerPack::deployShape(%player,%item)) 
		Player::decItemCount(%player,%item); 
} 

function BunkerPack::deployShape(%player,%item) 
{ 
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]) {
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
		return false;
	}
	%rot = GameBase::getRotation(%player); 
	%objBunker = newObject("Tower", InteriorShape,"bunker.dis");
	addToSet("MissionCleanup", %objBunker); 
	GameBase::setTeam(%objBunker,GameBase::getTeam(%player)); 
	GameBase::setPosition(%objBunker,$los::position); 
	GameBase::setRotation(%objBunker,%rot); 
	Gamebase::setMapName(%objBunker,"Bunker"); 
	Client::sendMessage(%client,0,"Bunker Deployed"); 
	GameBase::startFadeIn(%objBunker); 
	playSound(SoundPickupBackpack,$los::position); 
	playSound(ForceFieldOpen,$los::position); 
	$TeamItemCount[GameBase::getTeam(%player) @ "BunkerPack"]++; 
        reportDeploy(%objBunker, %client);
	return true; 
} 

//=======================================

ItemImageData TLPackImage 
{
	shapeFile = "shieldpack";
	mountPoint = 2;
	weaponType = 2;
	projectileType = LaserPointer;
	minEnergy = 0.00000001;
	maxEnergy = 0.0000001;
	reloadTime = 0.2;
	sfxFire = SoundELFIdle;
	lightType = 0;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 10, 10, 10 };
};

ItemData TLPack 
{
  description = "Laser Sight";
  shapeFile = "paintgun";
  className = "Backpack";
  heading = eBackpacks;
  shadowDetailMask = 4;
  imageType = TLPackImage;
  price = 275;
  hudIcon = "paintgun";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function TLPackImage::onActivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Sniper Pack On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function TLPackImage::onDeactivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Sniper Pack Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);	
}

function TLPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "The Laser Sight provides a much easier shot for snipers.");
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
	heading = "fDeployables";
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

function MotionSensorPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>Deploy this and people are easier too see by turrets.");
}

//----------------------------------------------------------------------------

ItemImageData AmmoPackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	//mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData AmmoPack
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "eBackpacks";
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
		for(%i = 0; $AmmoPackItems[%i] == ""; %i = %i +1) {
			if($AmmoPackItems[%i] == "" || $AmmoPackItems[%i] == -1)
				return;
			%numPack = 0;
			%ammoItem = $AmmoPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
				%item.MGAmmo = %numPack;
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
	        	%numAdd = %item.MGAmmo;
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
function AmmoPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>The Ammo Pack lets you hold a lot more ammo than your armor can hold.");
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
	heading = "fDeployables";
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
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function PulseSensorPack::onDeploy(%player,%item,%pos)
{
	if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) {
		Player::decItemCount(%player,%item);
		$TeamItemCount[GameBase::getTeam(%player) @ "PulseSensorPack"]++;
	}
}

function PulseSensorPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>Like A Motion Sensor, but is better used outside.");
}

//------------------------------

ItemImageData VehPackImage 
{  
       shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData VehPack 
{
        description = "Vehicle Station";
        shapeFile = "vehi_pur_pnl";
        className = "Backpack";
     	heading = "fDeployables";
        imageType = VehPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 1500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function VehPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
                Player::mountItem(%player,%item,$BackpackSlot);
        else
                Player::deployItem(%player,%item);
}
function VehPack::onDeploy(%player,%item,%pos)
{
        if(VehPack::deployShape(%player,%item))
                Player::decItemCount(%player,%item);
}
function VehPack::deployShape(%player,%item)
{
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set,"VehicleStation",%num);
                        deleteObject(%set);
                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                        {
				%team = GameBase::getTeam(%player);
                                %rot = GameBase::getRotation(%player);
                                %phase = newObject("vehi_pur_pnl","StaticShape",VehicleStation,true);
                                addToSet("MissionGroup/Teams/team" @ %team, %phase);
                                GameBase::setTeam(%phase,%team);
                                GameBase::setPosition(%phase,$los::position);
                                GameBase::setRotation(%phase,%rot);
                                Gamebase::setMapName(%phase,"Remote Vehicle Station");
                                Client::sendMessage(%client,0,"Vehicle Station Deployed");
                                GameBase::startFadeIn(%phase);
                                playSound(SoundPickupBackpack,$los::position);
                                $TeamItemCount[GameBase::getTeam(%player) @ "VehPack"]++;
                                return true;
                        }
                        else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                }
                else Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}

//----------------------------

ItemImageData PadPackImage 
{  
       shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData PadPack 
{
        description = "Vehicle Pad";
        shapeFile = "vehi_pur_poles";
        className = "Backpack";
     	heading = "fDeployables";
        imageType = PadPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 1500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function PadPack::onUse(%player,%item)
{
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
                Player::mountItem(%player,%item,$BackpackSlot);
        else
                Player::deployItem(%player,%item);
}
function PadPack::onDeploy(%player,%item,%pos)
{
        if (PadPack::deployShape(%player,%item))
                Player::decItemCount(%player,%item);
}
function PadPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set,"VehiclePad",%num);
                        deleteObject(%set);
                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                        {
					  %team = GameBase::getTeam(%player);
                                %rot = GameBase::getRotation(%player);
                                %phase = newObject("vehi_pur_poles","StaticShape",VehiclePad,true);
                                addToSet("MissionGroup/Teams/team" @ %team, %phase);
                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                GameBase::setPosition(%phase,$los::position);
                                GameBase::setRotation(%phase,%rot);
                                Gamebase::setMapName(%phase,"Remote Vehicle Pad");
                                Client::sendMessage(%client,0,"Vehicle Pad Deployed");
                                GameBase::startFadeIn(%phase);
                                playSound(SoundPickupBackpack,$los::position);
                                $TeamItemCount[GameBase::getTeam(%player) @ "PadPack"]++;
                                return true;
                        }
                        else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                }
                else Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}


//--------------------------------------


ItemImageData SolarPackImage 
{  
       shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, -0.03, 0 };
        mass = 0.5;
        firstPerson = false;
};

ItemData SolarPack 
{
        description = "Remote Generator";
        shapeFile = "solar_med";
        className = "Backpack";
     	heading = "fDeployables";
        imageType = SolarPackImage;
        shadowDetailMask = 4;
        mass = 1.5;
        elasticity = 0.2;
        price = 600;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};
function SolarPack::onUse(%player,%item) {
        if (Player::getMountedItem(%player,$BackpackSlot) != %item)
                Player::mountItem(%player,%item,$BackpackSlot);
        else
                Player::deployItem(%player,%item);
}
function SolarPack::onDeploy(%player,%item,%pos) {
        if (SolarPack::deployShape(%player,%item))
                Player::decItemCount(%player,%item);
}
function SolarPack::deployShape(%player,%item) {
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                if (GameBase::getLOSInfo(%player,3))
                {
                        %obj = getObjectType($los::object);
                        %set = newObject("set",SimSet);
                        %num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$ForceFieldBoxMinLength,$ForceFieldBoxMinWidth,$ForceFieldBoxMinHeight,0);
                        %num = CountObjects(%set,"SolarPanel",%num);
                        deleteObject(%set);
                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
                        {
					  %team = GameBase::getTeam(%player);
                                %rot = GameBase::getRotation(%player);
                                %phase = newObject("solar_med","StaticShape",SolarPanel,true);
                                addToSet("MissionGroup/Teams/team" @ %team, %phase);
                                GameBase::setTeam(%phase,GameBase::getTeam(%player));
                                GameBase::setPosition(%phase,$los::position);
                                GameBase::setRotation(%phase,%rot);
                                Gamebase::setMapName(%phase,"Backup Gen");
                                Client::sendMessage(%client,0,"Backup Gen Deployed");
                                GameBase::startFadeIn(%phase);
                                playSound(SoundPickupBackpack,$los::position);
                                $TeamItemCount[GameBase::getTeam(%player) @ "SolarPack"]++;
                                return true;
                        }
                        else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
                }
                else Client::sendMessage(%client,0,"Deploy position out of range");
        }
        else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
        return false;
}

//------------------------------------------------------------------------------------//
//-----------------------------WEIGHT-&-MASS-MANIPULATION-----------------------------//
//------------------------------------------------------------------------------------//

ItemData Weight
{				
	description = "";
	className = "Tool";
	showInventory = false;
};

function Weight::onDrop(%player, %item){}
function Weight::onUse(%player, %item){}

ItemImageData DeadWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = 90000.0;
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
	mass = 90000.0;
	showInventory = false;
};

ItemImageData LessWeightImage
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -2.0;
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
	mass = -2.0;
	showInventory = false;
};

ItemImageData LessWeight2Image
{
	shapeFile = "breath";
	mountPoint = 4;
	mass = -4.0;
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
	mass = -4.0;
	showInventory = false;
};

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
	heading = "fDeployables";
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
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
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
	heading = "fDeployables";
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

function CameraPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>The Camera pack is good for putting in enemy bases to see what the are doing, or put it near your turrets.");
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
								Client::sendMessage(%client,0,"Remote Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
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

function TurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>Deploy this and it will gaurd the area. It shoots ion bolts that can kill an enemy very quickly.");
}

//----------------------------------------------------------------------------
																			
ItemImageData CTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData CTurretPack
{
	description = "Chain Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "fDeployables";
	imageType = CTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function CTurretPack::onDeploy(%player,%item,%pos)
{
	if (CTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function CTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableCTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableCTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteCTurret","Turret",DeployableCTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT C Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Chain Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "CTurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Chain Turret");
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
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other Chain Turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other Chain turrets in the area");
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

function CTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>The Chain Turret shoots bullets that do little damage damage.");
}

//======================================================================== Suicide Pack

ItemImageData M350PackImage
{
	shapeFile = "magcargo";
	mountPoint = 2;
	mountOffset = { 0, -0.5, -0.3 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;

};

ItemData M350Pack
{
	description = "M-350";
	shapeFile = "magcargo";
	className = "Backpack";
	heading = "eBackpacks";
	imageType = M350PackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 450;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function M350Pack::onUse(%player,%item)
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

function M350Pack::onUnmount(%player,%item)
{
	deleteObject(%item);
	
}

function M350Pack::onDeploy(%player,%item,%pos)
{
	if (M350Pack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function M350Pack::deployShape(%player,%item)
{
	Player::unmountItem(%player,$BackpackSlot);
	%obj = newObject("","Mine","Mbomb");
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,3 * %client.throwStrength,false);
	Client::sendMessage(%client,1,"M-350 Set! Mass destruction starts in 20 seconds!");
}

//----------------------------------------------------------------------------
																			
ItemImageData DTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData DTurretPack
{
	description = "Disc Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
	heading = "fDeployables";
	imageType = DTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DTurretPack::onDeploy(%player,%item,%pos)
{
	if (DTurretPack::deployShape(%player,%item)) {
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

function DTurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
	    		%set = newObject("set",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
				%num = CountObjects(%set,"DeployableDTurret",%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num) {
		    		%set = newObject("set",SimSet);
					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
					%num = CountObjects(%set,"DeployableDTurret",%num);
					deleteObject(%set);
					if(0 == %num) {
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("remoteDTurret","Turret",DeployableDTurret,true);
	                     addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"RMT D Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Remote Disk Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "DTurretPack"]++;
								echo("MSG: ",%client," deployed a Remote Turret");
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
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other Disk Turrets");
				}
			   else 
					Client::sendMessage(%client,0,"Interference from other Disk turrets in the area");
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

function DTurretPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>This Turret Shoots Discs at anyone that comes near it.");
}

//=============================================
ItemImageData DEPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DEPack
{
	description = "Decoy Laser";
	shapeFile = "camera";
	className = "Backpack";
	heading = "fDeployables";
	imageType = DEPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DEPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function DEPack::onDeploy(%player,%item,%pos)
{
	if (DEPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function DEPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,10)) {
			%obj = getObjectType($los::object);
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot,2);
			if(Vector::dot($los::normal,"0 0 1") > 0.6)
				%rot = "0 0 " @ %zRot;
			else {
				if(Vector::dot($los::normal,"0 0 -1") > 0.6)
					%rot = "3.14159 0 " @ %zRot;
				else
					%rot = Vector::getRotation($los::normal);
			}
			%camera = newObject("Camera","Turret",DEDPack,true);
	   	      	addToSet("MissionCleanup", %camera);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,$los::position);
			Gamebase::setMapName(%camera,"Decoy Laser #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
			Client::setOwnedObject(%client, %camera);
			Client::setOwnedObject(%client, %player);
			Client::sendMessage(%client,0,"Decoy Laser Deployed");
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%camera) @ "DEPack"]++;
			return true;
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
		Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
}

function DEPack::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>The Decoy Shoots a non-Damaging Laser. Use this too distract the enemy.");
}

//=============================================
ItemImageData Laser2PackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData Laser2Pack
{
	description = "Short Range Laser";
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
};

function Laser2Pack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function Laser2Pack::onDeploy(%player,%item,%pos)
{
	if (Laser2Pack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

function Laser2Pack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,10)) {
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
					%camera = newObject("Camera","Turret",DeployableLaser2,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                              Client::setOwnedObject(%client, %camera);
                              Client::setOwnedObject(%client, %player);
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "Laser2Pack"]++;
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else																						  
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}

function LaserPack2::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc>This laser turret is good for indoor defence, It does a lot of damage at short range.");
}

//=============================================
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
	description = "Long Range Laser";
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
		if (GameBase::getLOSInfo(%player,10)) {
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
					%camera = newObject("Camera","Turret",DeployableLaser,true);
	   	      addToSet("MissionCleanup", %camera);
					GameBase::setTeam(%camera,GameBase::getTeam(%player));
					GameBase::setRotation(%camera,%rot);
					GameBase::setPosition(%camera,$los::position);
					Gamebase::setMapName(%camera,"Laser Turret#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                              Client::setOwnedObject(%client, %camera);
                              Client::setOwnedObject(%client, %player);
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%camera) @ "LaserPack"]++;
					return true;
				}
				else 
					Client::sendMessage(%client,0,"Deploy position out of range");
			}
			else																						  
			 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

		return false;
	}

function LaserPack::onMount(%player,%item) 
{
	Bottomprint(Player::getClient(%player), "<jc>This Laser Turret is good for outdoors, deploy on next to you and it can help you snipe the enemy. It does little damage.");
}
//----------------------------------------------------------------------------
// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,3)) {
			// GetLOSInfo sets the following globals:
			// 	los::position
			// 	los::normal
			// 	los::object
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape") {
				if(Vector::dot($los::normal,"0 0 1") > 0.7) {
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
	className = "Repair";
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

function HandAmmo::onUse(%player,%item)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			%client = Player::getClient(%player);
			%Multiplier = $ThrowStrength[%armor];
			if(!%Multiplier)
				%Multiplier = 1.0;
			GameBase::throw(%obj,%player,15 * %Multiplier * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
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
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	if($matchStarted) {
		if(%player.driver == 1)
			Vehicle::EndRoll(%player.vehicle);
		else if(%player.throwTime < getSimTime()) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","antipersonelMine");
		 	addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			%client = Player::getClient(%player);
			%Multiplier = $ThrowStrength[%armor];
			if(!%Multiplier)
				%Multiplier = 1.0;
			GameBase::throw(%obj,%player,15 * %Multiplier * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			%player.grenadeType = %item;
			%obj.thrower = %player;
		}
	}
}

function remoteCheckForRoll(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.driver == 1) {
		%player.vehicle.rolling = 1;
		Vehicle::BarrelRoll(%player.vehicle);
	}
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
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%client);
	if($matchStarted) {
		if(%player.throwTime < getSimTime()) {
			Player::decItemCount(%player,%item);
			if($WeapMode[%client,Handgrenade] == 1 || $WeapMode[%client,Handgrenade] == "")
				%obj = newObject("","Mine","Handgrenade");
			else
				%obj = newObject("","Mine",getword($WeapModeName[Handgrenade,$WeapMode[%client,Handgrenade]],0));
		 	addToSet("MissionCleanup", %obj);
			GameBase::setTeam(%obj,GameBase::getTeam(%player));
			%Multiplier = $ThrowStrength[%armor];
			if(!%Multiplier)
				%Multiplier = 1.0;
			GameBase::throw(%obj,%player,15 * %Multiplier * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			%obj.thrower = %player;
		}
	}
}

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
		Player::setItemCount(%clientId,Flamethrower,1);
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
	if(%numweapon > $MaxWeapons[%armor])
		%weaponflag = %numweapon - $MaxWeapons[%armor];
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%item = getItemData(%i);
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "") {
			%numsell = 0;
			%count = Player::getItemCount(%client,%item);
			if(%count > %maxnum)
				%numsell =  %count - %maxnum;
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
	$TeamItemCount[0 @ KamikazeVehicle] = 0;
	$TeamItemCount[0 @ JetVehicle] = 0;
	$TeamItemCount[0 @ StealthVehicle] = 0;
	$TeamItemCount[0 @ Beacon] = 0;
	$TeamItemCount[0 @ mineammo] = 0;
	$TeamItemCount[0 @ AAMinePack] = 0;

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
	$TeamItemCount[1 @ KamikazeVehicle] = 0;
	$TeamItemCount[1 @ JetVehicle] = 0;
	$TeamItemCount[1 @ StealthVehicle] = 0;
	$TeamItemCount[1 @ Beacon] = 0;
	$TeamItemCount[1 @ mineammo] = 0;
	$TeamItemCount[1 @ AAMinePack] = 0;

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
	$TeamItemCount[2 @ KamikazeVehicle] = 0;
	$TeamItemCount[2 @ JetVehicle] = 0;
	$TeamItemCount[2 @ StealthVehicle] = 0;
	$TeamItemCount[2 @ Beacon] = 0;
	$TeamItemCount[2 @ mineammo] = 0;
	$TeamItemCount[2 @ AAMinePack] = 0;

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
	$TeamItemCount[3 @ KamikazeVehicle] = 0;
	$TeamItemCount[3 @ JetVehicle] = 0;
	$TeamItemCount[3 @ StealthVehicle] = 0;
	$TeamItemCount[3 @ Beacon] = 0;
	$TeamItemCount[3 @ mineammo] = 0;
	$TeamItemCount[3 @ AAMinePack] = 0;

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
	$TeamItemCount[4 @ KamikazeVehicle] = 0;
	$TeamItemCount[4 @ JetVehicle] = 0;
	$TeamItemCount[4 @ StealthVehicle] = 0;
	$TeamItemCount[4 @ Beacon] = 0;
	$TeamItemCount[4 @ mineammo] = 0;
	$TeamItemCount[4 @ AAMinePack] = 0;

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
	$TeamItemCount[5 @ KamikazeVehicle] = 0;
	$TeamItemCount[5 @ JetVehicle] = 0;
	$TeamItemCount[5 @ StealthVehicle] = 0;
	$TeamItemCount[5 @ Beacon] = 0;
	$TeamItemCount[5 @ mineammo] = 0;
	$TeamItemCount[5 @ AAMinePack] = 0;

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
	$TeamItemCount[6 @ KamikazeVehicle] = 0;
	$TeamItemCount[6 @ JetVehicle] = 0;
	$TeamItemCount[6 @ StealthVehicle] = 0;
	$TeamItemCount[6 @ Beacon] = 0;
	$TeamItemCount[6 @ mineammo] = 0;
	$TeamItemCount[6 @ AAMinePack] = 0;

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
	$TeamItemCount[7 @ KamikazeVehicle] = 0;
	$TeamItemCount[7 @ JetVehicle] = 0;
	$TeamItemCount[7 @ StealthVehicle] = 0;
	$TeamItemCount[7 @ Beacon] = 0;
	$TeamItemCount[7 @ mineammo] = 0;
	$TeamItemCount[7 @ AAMinePack] = 0;

	$totalNumCameras = 0;
	$totalNumTurrets = 0;

	for(%i = -1; %i < 8 ; %i++) {
		$TeamItemCount[%i @ VehMaint] = 0;
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
	}
}
