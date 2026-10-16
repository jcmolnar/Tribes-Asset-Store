



$ItemFavoritesKey = $MasterKey;
																										
$ItemPopTime = 30; 

$ToolSlot=0; 
$WeaponSlot=0; 
$BackpackSlot=1; 
$FlagSlot=2; 
$DefaultSlot=3;
$ExtraSlot=30;

$TeamItemMax[LaserTurrets] = 4;
$TeamItemMax[PlasmaTurrets] = 4;
$TeamItemMax[WatchdogPack] = 1;
$TeamItemMax[RocketPack] = 2; 
$TeamItemMax[AAPack] = 1; 
$TeamItemMax[DeployableComPack] = 3; 
$TeamItemMax[ForceFieldPack] = 4; 
$TeamItemMax[LargeForceFieldPack] = 1; 
$TeamItemMax[TripwirePack] = 0; 
$TeamItemMax[TeleportPack] = 8; 
$TeamItemMax[WraithVehicle] = 2; 
$TeamItemMax[JetVehicle] = 4; 
$TeamItemMax[SpringPack] = 10; 
$TeamItemMax[holopack] = 7; 
$TeamItemMax[SatchelPack] = 6; 
$TeamItemMax[BigInvPack] = 2; 
$TeamItemMax[ShockPack] = 3; 
$TeamItemMax[TargetPack] = 3;  
$TeamItemMax[DeployableAmmoPack] = 10; 
$TeamItemMax[DeployableInvPack] = 15; 
$TeamItemMax[TurretPack] = 6;
$TeamItemMax[TTurretPack] = 5;
$TeamItemMax[CameraPack] = 15; 
$TeamItemMax[BA] = 1; 
$TeamItemMax[Scouter] = 10; 
$TeamItemMax[DeployableSensorJammerPack] = 10; 
$TeamItemMax[PulseSensorPack] = 15; 
$TeamItemMax[MotionSensorPack] = 15; 
$TeamItemMax[Plas] = 3; 
$TeamItemMax[ScoutVehicle] = 4; 
$TeamItemMax[HAPCVehicle] = 1; 
$TeamItemMax[LAPCVehicle] = 3; 
$TeamItemMax[Beacon] = 20; 
$TeamItemMax[MineAmmo] = 30; 
$TeamItemMax[Aoe] = 13; 
$TeamItemMax[CoolLauncher] = 2;
$TeamItemMax[doorfourbyeightForceFieldPack] = 2;
$TeamItemMax[doorthreebyfourForceFieldPack] = 4;
$TeamItemMax[PlasmaPack] = 4;
$TeamItemMax[LELFPack] = 1;
$TeamItemMax[ElfPack] = 3;
$TeamItemMax[AirAmmoPad] = 4;

$WeaponAmmo[Blaster] = ""; 
$WeaponAmmo[Shotgun] = ShotgunShells; 
$WeaponAmmo[PlasmaGun] = PlasmaAmmo; 
$WeaponAmmo[Chaingun] = BulletAmmo; 
$WeaponAmmo[DiscLauncher] = DiscAmmo; 
$WeaponAmmo[HDiscLauncher] = HDiscAmmo;
$WeaponAmmo[GrenadeLauncher] = GrenadeAmmo; 
$WeaponAmmo[Mortar] = MortarAmmo; 
$WeaponAmmo[EMPGrenadeLauncher] = EMPGrenadeAmmo;
$WeaponAmmo[IXRocketLauncher] = RocketAmmo;
$WeaponAmmo[RocketLauncher] = RocketAmmo;
$WeaponAmmo[LaserRifle] = ""; 
$WeaponAmmo[EnergyRifle] = ""; 
$WeaponAmmo[SniperRifle] = SniperAmmo; 
$WeaponAmmo[Railgun] = RailAmmo; 
$WeaponAmmo[WaveGun] = ""; 
$WeaponAmmo[Flamer] = ""; 
$WeaponAmmo[Silencer] = SilencerAmmo; 
$WeaponAmmo[TranqGun] = TranqAmmo;

$SellAmmo[RocketAmmo] = 5;
$SellAmmo[SniperAmmo] = 15; 
$SellAmmo[RailAmmo] = 15; 
$SellAmmo[SilencerAmmo] = 25; 
$SellAmmo[TranqAmmo] = 5; 
$SellAmmo[BulletAmmo] = 50; 
$SellAmmo[ShotgunShells] = 5; 
$SellAmmo[PlasmaAmmo] = 5; 
$SellAmmo[EMPGrenadeAmmo] = 5; 
$SellAmmo[DiscAmmo] = 5; 
$SellAmmo[HDiscAmmo] = 5; 
$SellAmmo[GrenadeAmmo] = 5; 
$SellAmmo[MortarAmmo] = 5; 
$SellAmmo[Beacon] = 5; 
$SellAmmo[Boost] = 5; 
$SellAmmo[MineAmmo] = 5;
$SellAmmo[Grenade] = 5; 

$AutoUse[Blaster] = False; 
$AutoUse[SniperRifle] = False; 
$AutoUse[WaveGun] = False; 
$AutoUse[Railgun] = False; 
$AutoUse[Silencer] = False; 
$AutoUse[TranqGun] = False; 
$AutoUse[IXRocketLauncher] = False;
$AutoUse[RocketLauncher] = False;
$AutoUse[EMPGrenadeLauncher] = False;
$AutoUse[Shotgun] = False;
$AutoUse[Smoker] = False;
$AutoUse[Flagger] = False;
$AutoUse[Chaingun] = False; 
$AutoUse[PlasmaGun] = False; 
$AutoUse[Mortar] = False; 
$AutoUse[GrenadeLauncher] = False; 
$AutoUse[LaserRifle] = False; 
$AutoUse[EnergyRifle] = False; 
$AutoUse[TargetingLaser] = False; 
$AutoUse[Fixit] = False; 
$AutoUse[ChargeGun] = False;
$AutoUse[RepairKit] = False;

$Use[Blaster] = True;

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

$ArmorType[Male, LightArmor] = larmor; 
$ArmorType[Male, MediumArmor] = marmor; 
$ArmorType[Male, HeavyArmor] = harmor; 
$ArmorType[Female, LightArmor] = lfemale; 
$ArmorType[Female, MediumArmor] = mfemale; 
$ArmorType[Female, HeavyArmor] = harmor; 
$ArmorType[Male, ScoutArmor] = sarmor; 
$ArmorType[Male, BursterArmor] = barmor; 
$ArmorType[Male, EngArmor] = earmor;
$ArmorType[Male, DragArmor] = darmor; 
$ArmorType[Female, ScoutArmor] = sfemale; 
$ArmorType[Female, BursterArmor] = bfemale; 
$ArmorType[Female, EngArmor] = efemale; 
$ArmorType[Female, DragArmor] = darmor; 
$ArmorType[Male, BehArmor] = harmor; 
$ArmorType[Female, BehArmor] = harmor; 
$ArmorType[Male, SpArmor] = spyarmor; 
$ArmorType[Female, SpArmor] = spyfemale; 
$ArmorType[Male, CArmor] = dmarmor; 
$ArmorType[Female, CArmor] = dmfemale; 
$ArmorType[Male, InfArmor] = iarmor; 
$ArmorType[Female, InfArmor] = ifarmor; 

$ArmorName[sarmor] = ScoutArmor; 
$ArmorName[harmor] = BehArmor; 
$ArmorName[barmor] = BursterArmor;
$ArmorName[earmor] = EngArmor; 
$ArmorName[efemale] = EngArmor; 
$ArmorName[darmor] = DragArmor; 
$ArmorName[sfemale] = ScoutArmor; 
$ArmorName[bfemale] = BursterArmor; 
$ArmorName[spyarmor] = SpArmor; 
$ArmorName[spyfemale] = SpArmor; 
$ArmorName[dmarmor] = CArmor; 
$ArmorName[dmfemale] = CArmor; 
$ArmorName[iarmor] = InfArmor; 
$ArmorName[ifarmor] = InfArmor;
$ArmorName[larmor] = LightArmor; 
$ArmorName[marmor] = MediumArmor; 
$ArmorName[lfemale] = LightArmor; 
$ArmorName[mfemale] = MediumArmor; 

$AmmoPackItems[0] = BulletAmmo; 
$AmmoPackItems[1] = PlasmaAmmo; 
$AmmoPackItems[2] = DiscAmmo; 
$AmmoPackItems[3] = GrenadeAmmo; 
$AmmoPackItems[4] = Grenade; 
$AmmoPackItems[5] = MortarAmmo; 
$AmmoPackItems[6] = RocketAmmo; 
$AmmoPackItems[7] = SniperAmmo; 
$AmmoPackItems[8] = RailAmmo; 
$AmmoPackItems[9] = SilencerAmmo; 
$AmmoPackItems[10] = TranqAmmo; 
$AmmoPackItems[11] = Beacon; 
$AmmoPackItems[12] = HDiscAmmo; 
$AmmoPackItems[13] = EMPGrenadeAmmo; 
$AmmoPackItems[14] = RepairKit; 
$AmmoPackItems[15] = ShotgunShells;
$AmmoPackItems[16] = MineAmmo; 

function checkMax(%client,%armor)
{
 	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if(Player::getMountedItem(%client,$BackpackSlot) == OpticPack) %w = 1; else %w = 0;
	if (%numweapon > $MaxWeapons[%armor] - %w) {
	   %weaponflag = %numweapon - $MaxWeapons[%armor] - %w;
	}
	%team = Client::getTeam(%client); 
	%station = Client::getOwnedObject(%client).Station; 
	%stationName = GameBase::getDataName(%station); 
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
				%cost = (%item.price * %numsell);
				if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) { 
					%station.Energy += %cost; 
					if(%station.Energy < 1) 
						%station.Energy = 0; 
				} else if($TeamEnergy[%team] != "Infinite") { 
					$TeamEnergy[%team] += %cost; 
					%client.teamEnergy += %cost; 
				} 
				if(%count - %numsell < 0) %count = %numsell;
				Player::setItemCount(%client, %item, %count - %numsell);  
				updateBuyingList(%client);
			} 
		}
	}
}


function checkResources(%player,%item,%delta,%noMessage)
{
	%client = Player::getClient(%player);
	%armor = Player::getArmor(%player);
	%team = Client::getTeam(%client);
	%extraAmmo = 0 ;
	if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%armor, %item] != 0) {
		%extraAmmo = $AmmoPackMax[%armor, %item];
		if(%delta == $ItemMax[%armor, %item]) 
			%delta = %delta + %extraAmmo;
	}
	if(%client.spawn == "") {
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
		if(Player::getMountedItem(%client,$BackpackSlot) == OpticPack) %w = 1; else %w = 0;
		if (Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor] - %w) {
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
   else if($TeamItemMax[%item] != "") {
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

function buyItem(%client,%item) { 
	%player = Client::getOwnedObject(%client); 
	%armor = Player::getArmor(%client); 
	if ((Client::isItemShoppingOn(%client,%item) || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle)) { 
		if (%item.className == Armor) { 		
			%buyarmor = $ArmorType[Client::getGender(%client), %item]; 
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0) { 
				if (%client.poisonTime == 0 && %client.permap != true) {
					teamEnergyBuySell(%player,$ArmorName[%armor].price); 
					if(checkResources(%player,%item,1)) { 
						teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1); 
						if(%player.tfield) {
                     %player.tfield = false;
                     deleteObject(%player.tfieldlight);
                  }
                  Player::setArmor(%client,%buyarmor); 
						checkMax(%client,%buyarmor); 
						armorChange(%client); 
						Player::setItemCount(%client, $ArmorName[%armor], 0); 
						Player::setItemCount(%client, %item, 1); 
                  updateBuyingList(%client);
						if(%buyarmor == "harmor") {
							Player::setItemCount(%client, SMR2Pack,1);
							Player::mountItem(%client, SMR2Pack, 4);
							Player::setItemCount(%client, SMR3Pack,1);
							Player::mountItem(%client, SMR3Pack, 5);
						} else {
							if(Player::getMountedItem(%player, 4) == SMR2Pack) {
								Player::unmountItem(%player, 4);
								Player::setItemCount(%player, SMR2Pack,0);
							}
							if(Player::getMountedItem(%player, 5) == SMR3Pack) {
								Player::unmountItem(%player, 5);
								Player::setItemCount(%player, SMR3Pack,0);
							}
							if(%buyarmor == "earmor" || %buyarmor == "efemale") {
								Client::sendMessage(%client,0,"Bought Engineer - Auto buying Repair Gun");
								buyItem(%client,"Fixit");
							}
						}
						if (Player::getMountedItem(%client,$BackpackSlot) == ammopack) fillAmmoPack(%client); 
						return 1; 
					} 
				teamEnergyBuySell(%player,$ArmorName[%armor].price * -1); 
				}
			} 
		} else if (%item.className == Backpack) { 
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if(%item == OpticPack && Player::getItemClassCount(%client,"Weapon") >= $MaxWeapons[%armor]) {
				schedule("Client::sendMessage(" @ %client @ ",0,\"The Cybernetic Laser requires a free weapon slot\");", 0.1);
				return 0;
			}
			if (%pack != -1) {
				if(%pack == ammopack) 
					checkMax(%client,%armor);
				if(%pack == EnergyPack) {
					if(Player::getItemCount(%client,"LaserRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						remoteSellItemData(%client,LaserRifle);
					}
				} else
					Client::sendMessage(%client,0,"Sold " @ %pack.description);
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}			   
			if (checkResources(%player,%item,1)) {
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
		} else if(%item.className == Weapon) { 
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
					if(%delta) {
						teamEnergyBuySell(%player,(%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client,%ammoitem,%delta);
					}
				}
				return 1;
			}
		} else if(%item.className == Vehicle) {
		   if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item]) {
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1) {
					teamEnergyBuySell(%player,(%item.price * -1));
					return 1;
				}			
 				else if(%shouldBuy == 2)
					return 1;
			}
		} else {
			if($TeamItemMax[%item] != "") {						
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item])
			 	  return 0;
			 }
			%delta = checkResources(%player,%item,$ItemMax[%armor, %item]); 
			if(%delta) { 
				teamEnergyBuySell(%player,(%item.price * -1 * %delta)); 
		
				for(%i=0;%i<$numSpecials;%i++) {
					if (%item == $lll[%i]) {
						%yesflag = true;
					}
				}
		
				if (%yesflag == true) {
					for(%i=0;%i<$numSpecials;%i++) {
						if(%item != $lll[%i]) {
							if(Player::getItemCount(%client,$lll[%i]) > 0) {
								Client::sendMessage(%client,0,"Bought "@%item.description@" - Auto Selling "@$lll[%i].description@"."); 
								remoteSellItemData(%client,$lll[%i]);
							}
						}			
					}
				}
				Player::incItemCount(%client,%item,%delta); 
				return 1; 
			} 
		} 
	} 
	return 0; 
} 

$vm[ToM] = TProj;

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
			Projectile::spawnProjectile("ArmChan", "0 0 1 0 0 0 0 0 1 " @ %trans, %player, "0 0 -2");
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
	if (Client::isItemShoppingOn(%client,%item)) {
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
					remoteSellItemData(%client,LaserRifle);
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

function remoteSellItemData(%client,%item) { if (isPlayerBusy(%client)) return; %player = Client::getOwnedObject(%client); if (Client::isItemShoppingOn(%client,%item)) { if(Player::getItemCount(%client,%item) && %item.className != Armor) { %numsell = 1; if(%item.className == Ammo || %item.className == HandAmmo) { %count = Player::getItemCount(%client, %item); if(%count < $SellAmmo[%item]) %numsell = %count; else %numsell = $SellAmmo[%item]; } else if (%item == ammopack) checkMax(%client,Player::getArmor(%client)); else if($TeamItemMax[%item] != "") { if(%item.className == Vehicle) $TeamItemCount[(Client::getTeam(%client)) @ %item]--; } else if(%item == EnergyPack) { if(Player::getItemCount(%client,"LaserRifle") > 0) { Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle"); remoteSellItemData(%client,LaserRifle); } } teamEnergyBuySell(%player,%item.price * %numsell); Player::setItemCount(%player,%item,(%count-%numsell)); updateBuyingList(%client); Client::SendMessage(%client,0,"~wbuysellsound.wav"); return 1; } } Client::sendMessage(%client,0,"Cannot sell item ~wC_BuySell.wav"); } 

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
		if(GameBase::getLOSinfo(%player,3)) { 
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
	%player.isDeploying = flase; 
} 

function ixToggleDeploy(%this) { 
	if(%this.isDeploying) 
		%this.isDeploying = false; 
	else 
		%this.isDeploying = true; 
} 


function remoteThrowItem(%client,%type,%strength) {
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
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

function remoteDropItem(%client,%type) {
	if(GameBase::getControlClient(%client) == -1) return;
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

$vm[GasM] = GasProj;

function remoteDeployItem(%client,%type)
{
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

$NextWeapon[Fixit] = Shotgun; 
$NextWeapon[Shotgun] = Chaingun; 
$NextWeapon[Chaingun] = PlasmaGun; 
$NextWeapon[PlasmaGun] = DiscLauncher; 
$NextWeapon[DiscLauncher] = HDiscLauncher; 
$NextWeapon[HDiscLauncher] = GrenadeLauncher; 
$NextWeapon[GrenadeLauncher] = RocketLauncher; 
$NextWeapon[RocketLauncher] = IXRocketLauncher; 
$NextWeapon[IXRocketLauncher] = EMPGrenadeLauncher; 
$NextWeapon[EMPGrenadeLauncher] = Mortar; 
$NextWeapon[Mortar] = Silencer;
$NextWeapon[Silencer] = TranqGun; 
$NextWeapon[TranqGun] = Railgun; 
$NextWeapon[Railgun] = SniperRifle; 
$NextWeapon[SniperRifle] = Blaster; 
$NextWeapon[Blaster] = EnergyRifle; 
$NextWeapon[EnergyRifle] = WaveGun; 
$NextWeapon[WaveGun] = Flamer; 
$NextWeapon[Flamer] = LaserRifle; 
$NextWeapon[LaserRifle] = AAGun;
$NextWeapon[AAGun] = Fixit;

$PrevWeapon[Shotgun] = Fixit; 
$PrevWeapon[Chaingun] = Shotgun; 
$PrevWeapon[PlasmaGun] = Chaingun; 
$PrevWeapon[DiscLauncher] = PlasmaGun; 
$PrevWeapon[HDiscLauncher] = DiscLauncher; 
$PrevWeapon[GrenadeLauncher] = HDiscLauncher; 
$PrevWeapon[RocketLauncher] = GrenadeLauncher; 
$PrevWeapon[IXRocketLauncher] = RocketLauncher; 
$PrevWeapon[EMPGrenadeLauncher] = IXRocketLauncher; 
$PrevWeapon[Mortar] = EMPGrenadeLauncher; 
$PrevWeapon[Silencer] = Mortar;
$PrevWeapon[TranqGun] = Silencer; 
$PrevWeapon[Railgun] = TranqGun; 
$PrevWeapon[SniperRifle] = Railgun; 
$PrevWeapon[Blaster] = SniperRifle; 
$PrevWeapon[EnergyRifle] = Blaster; 
$PrevWeapon[WaveGun] = EnergyRifle; 
$PrevWeapon[Flamer] = WaveGun; 
$PrevWeapon[LaserRifle] = Flamer; 
$PrevWeapon[AAGun] = LaserRifle; 
$PrevWeapon[Fixit] = AAGun; 

function e (%client) {
	return !(%client.observerMode == "" || %client.observerMode == "pregame");
}


function remoteNextWeapon(%client) {

	if(e(%client)) return;

	if(%client.possessed) return;
	if(%client.possessing) %client = %client.poss;

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
				if (Player::getMountedItem(%client,$WeaponSlot) == %weapon || Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					break;
			}
		}
	}
}

function remotePrevWeapon(%client) {
	if(e(%client)) return;

	if(%client.possessed) return;
	if(%client.possessing) %client = %client.poss;
	
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


function selectValidWeapon(%client) {
	%item = EnergyRifle;
	for (%weapon = $NextWeapon[%item]; %weapon != %item;
			%weapon = $NextWeapon[%weapon]) {
		if (isSelectableWeapon(%client,%weapon)) {
			Player::useItem(%client,%weapon);
			return;
		}
	}
	if (isSelectableWeapon(%client,EnergyRifle)) Player::useItem(%client,EnergyRifle);
}

function isSelectableWeapon(%client,%weapon)
{
	if(Player::isDead(%client)) {
		return false;
	}
	if (Player::getItemCount(%client,%weapon) > 0) {
		%ammo = $WeaponAmmo[%weapon];
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0)
			return true;
	}
	return false;
}


function Item::giveItem(%player,%item,%delta) {
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item]) {		  
		%client = Player::getClient(%player);
		if (%item.className == Backpack) {
			if (Player::getMountedItem(%player,$BackpackSlot) == -1) {
		 		if (%item == OpticPack && Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor]) return 0;
				Player::incItemCount(%player,%item);
		 		Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item.description);
		 		return 1;
			}
		}
  		else {
			
			if (%item.className == Weapon) {
				if(Player::getMountedItem(%player,$BackpackSlot) == OpticPack) %w = 1; else %w = 0;
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor] - %w) 
					return 0;
			}  
			if (%item.className == Tool) {
				for(%i=0;%i<$numSpecials;%i++) {
					if (%item == $lll[%i]) {
						%yesflag = true;
					}
				}
				if (%yesflag == true) {
					for(%i=0;%i<$numSpecials;%i++) {
						if(%item != $lll[%i]) {
							if(Player::getItemCount(%client,$lll[%i]) > 0) {
								Client::sendMessage(%client,0,"No room for "@%item.description@" - carrying a "@$lll[%i].description@"."); 
								return 0;
							}
						}			
					}
				}
			}
			%extraAmmo = 0 ;
			if (Player::getMountedItem(%client,$BackpackSlot) == ammopack && $AmmoPackMax[%armor, %item] != 0) 
				%extraAmmo = $AmmoPackMax[%armor, %item];
			
			%count = Player::getItemCount(%player,%item);
			if (%count + %delta > $ItemMax[%armor, %item] + %extraAmmo) 
				%delta = ($ItemMax[%armor, %item] + %extraAmmo) - %count;
			if (%delta > 0) {
				if (%delta > 511) %delta = 511;
				Player::incItemCount(%player,%item,%delta);
				if(%item == "HDiscAmmo") {
					Player::setItemCount(%player, "HDisc1Ammo", 2);
					Player::setItemCount(%player, "HDisc2Ammo", 2);
				}
				if (%count == 0 && $AutoUse[%item]) 
					Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
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

function Item::onMount(%player,%item) { } 
function Item::onUnmount(%player,%item) { } 

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
			%client = Player::getClient(%player);
			if(%client.possessed && %item.className != Weapon) return;
			if(%client.possessing) { %player = Client::getOwnedObject(%client.poss); }

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
	lightRadius = 4.5;
	lightTime = 1.25;
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
	lightRadius = 4.5;
	lightTime = 1.25;
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
	lightTime = 1.25;
	lightColor = { 1, 1, 1 };
};

ItemData ScoutArmor { heading = "aArmor"; description = "Scout"; className = "Armor"; price = 425; }; 
ItemData SpArmor { heading = "aArmor"; description = "Spy"; className = "Armor"; price = 425; }; 
ItemData LightArmor { heading = "aArmor"; description = "Sniper"; className = "Armor"; price = 425; }; 
ItemData MediumArmor { heading = "aArmor"; description = "Mercenary"; className = "Armor"; price = 575; }; 
ItemData BursterArmor { heading = "aArmor"; description = "Burster"; className = "Armor"; price = 575; }; 
ItemData InfArmor { heading = "aArmor"; description = "Infiltrator"; className = "Armor"; price = 575; }; 
ItemData EngArmor { heading = "aArmor"; description = "Engineer"; className = "Armor"; price = 575; }; 
ItemData BehArmor { heading = "aArmor"; description = "Behemoth"; className = "Armor"; price = 700; }; 
ItemData DragArmor { heading = "aArmor"; description = "Cyborg"; className = "Armor"; price = 700; }; 

ItemData EMPProjVehicle { description = "EMP Missile"; className = "Vehicle"; price = 200; }; 
ItemData VoProjVehicle { description = "Vortex Missile"; className = "Vehicle"; price = 200; }; 
ItemData GasProjVehicle { description = "Toxin Missile"; className = "Vehicle"; price = 200; }; 
ItemData CoolProjVehicle { description = "Phoenix Missile"; className = "Vehicle"; price = 300; }; 
ItemData NapProjVehicle { description = "Napalm Missile"; className = "Vehicle"; price = 300; }; 
ItemData BoomProjVehicle { description = "HaVoC Missile"; className = "Vehicle"; price = 600; }; 

ItemData ScoutVehicle { description = "Scout"; className = "Vehicle"; heading = "aVehicle"; price = 600; }; 
ItemData WraithVehicle { description = "Wraith"; className = "Vehicle"; heading = "aVehicle"; price = 600; }; 
ItemData JetVehicle { description = "Interceptor"; className = "Vehicle"; heading = "aVehicle"; price = 600; }; 
ItemData LAPCVehicle { description = "LAPC"; className = "Vehicle"; heading = "aVehicle"; price = 675; }; 
ItemData HAPCVehicle { description = "HAPC"; className = "Vehicle"; heading = "aVehicle"; price = 875; }; 

ItemData CArmor { showInventory = false; heading = "aArmor"; description = "DeathMatch"; className = "Armor"; price = 700; }; 

ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%client = Player::getClient(%player);
	if(%client.possessed) return;
	if(%client.possessing) 
		%player = Client::getOwnedObject(%client.poss);

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

ItemData Tool { description = "Tool"; showInventory = false; }; 

function Tool::onUse(%player,%item) { if (%item != Flagger) { Player::mountItem(%player,%item,$ToolSlot); if($curVoteTopic == "") if(Client::getControlObject(Player::getClient(%player)) == %player) bottomprint(Player::getClient(%player), "<jc><f2>"@%item.description, 0.5); } } 


ItemData Ammo { description = "Ammo"; showInventory = false; }; 

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

ItemData BulletAmmo { description = "Bullets"; className = "Ammo"; shapeFile = "ammo1"; heading = "xAmmunition"; shadowDetailMask = 4; price = 1; }; 

ItemData ShotgunShells { description = "Shotgun Shells"; className = "Ammo"; shapeFile = "ammo2"; heading = "xAmmunition"; shadowDetailMask = 4; price = 5; }; 

ItemImageData Shotgun1Image { shapeFile = "shotgun"; mountPoint = 0; mountOffset = {0.065, 0, 0}; mountRotation = {0, -1.57, 0}; weaponType = 0; ammoType = ShotgunShells; reloadTime = 0.45; accuFire = true; fireTime = 0.45; }; 

ItemData Shotgun1 { heading = "bProjectile Weapons"; description = "Shotgun"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "ammopack"; shadowDetailMask = 4; imageType = Shotgun1Image; price = 125; showWeaponBar = false; showInventory = false; }; 

ItemImageData ShotgunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 0; mountOffset = {-0.065, 0, 0}; mountRotation = {0, 1.57, 0}; ammoType = ShotgunShells; reloadTime = 0.45; accuFire = false; fireTime = 0.45; sfxActivate = SoundPickUpWeapon; }; 

ItemData Shotgun { heading = "bProjectile Weapons"; description = "Shotgun"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "ammopack"; shadowDetailMask = 4; imageType = ShotgunImage; price = 125; showWeaponBar = true; }; 

function Shotgun::onMount(%player, %slot) {	
	Player::mountItem(%player, Shotgun1, 6); 
}
function Shotgun::onUnmount(%player, %slot) { 
	Player::unmountItem(%player, 6); 
}
function Shotgun::reload(%player, %shell) {
	if(%shell == 2)
		%player.st2 = false;
	else
		%player.st1 = false;
}
function Shotgun::FireSlot(%player, %slot) { 
	ixApplyKickback(%player, 45, 35); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel); 
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel); 
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
  	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel); 		
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
  	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel); 
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel); 		
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
  	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel);
	Projectile::spawnProjectile("ShotgunBullet", %trans, %player, %vel); 
	playSound(SoundFireShotgun, GameBase::getPosition(%player));
	schedule("Shotgun::reload(" @ %player @ "," @ %slot @ ");", 6, %player);
}
function ShotgunImage::onFire(%player, %slot) { 
	%pos = GameBase::getPosition(%player);
	if(%player.st1) {
		if(%player.st2) {
			playSound(SoundDryFire, %pos);
			return;
		} else {
			%player.st2 = true;
			schedule("Shotgun::FireSlot(" @ %player @ ",2);", 0.45, %player);
		}
	} else {
		%player.st1 = true;
		schedule("Shotgun::FireSlot(" @ %player @ ",1);", 0.45, %player);
	}
	Player::decItemCount(%player,$WeaponAmmo[Shotgun],1); 
	playSound(SoundWeaponSelect, %pos); 
	schedule("playSound(SoundWeaponSelect,GameBase::getPosition(" @ %player @ "));", 0.25);
}

ItemImageData ChaingunImage {
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

ItemData Chaingun { description = "Chaingun"; className = "Weapon"; shapeFile = "chaingun"; hudIcon = "chain"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = ChaingunImage; price = 150; showWeaponBar = true; }; 

ItemData PlasmaAmmo { description = "Plasma Bolts"; heading = "xAmmunition"; className = "Ammo"; shapeFile = "plasammo"; shadowDetailMask = 4; price = 2; }; 

ItemImageData PlasmaGunImage { shapeFile = "plasma"; mountPoint = 0; weaponType = 0; ammoType = PlasmaAmmo; projectileType = PlasmaBolt; accuFire = true; reloadTime = 0.1; fireTime = 0.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 1, 0.25, 0.0 }; sfxFire = SoundFirePlasma; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; }; 

ItemData PlasmaGun { description = "Plasma Gun"; className = "Weapon"; shapeFile = "plasma"; hudIcon = "plasma"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = PlasmaGunImage; price = 175; showWeaponBar = true; }; 

ItemData SmallOrange {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 5;
	lightTime = 0.5;
	lightColor = { 1, 0.5, 0 };
};

ItemData PoweredBlue {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 10;
	lightTime = 0.75;
	lightColor = { 0, 0.5, 1 };
};
function PoweredBlue::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData PoweredSmallOrange {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 5;
	lightTime = 0.6;
	lightColor = { 1, 0.5, 0 };
};
function PoweredSmallOrange::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData PoweredMedOrange {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 10;
	lightTime = 0.7;
	lightColor = { 1, 0.5, 0 };
};
function PoweredMedOrange::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData PoweredMedRed {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 14;
	lightTime = 1.6;
	lightColor = { 1, 0, 0 };
};
function PoweredMedRed::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData PoweredSmallRed {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 11;
	lightTime = 1.5;
	lightColor = { 1, 0, 0 };
};
function PoweredSmallRed::onPower(%this, %power, %generator) { if(%power) GameBase::startFadeIn(%this); else GameBase::startFadeOut(%this); } 

ItemData MedRed {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 16;
	lightTime = 1.6;
	lightColor = { 1, 0.2, 0 };
};

ItemData SmallRed {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 11;
	lightTime = 1.6;
	lightColor = { 1, 0.2, 0 };
};

ItemData MedOrange {
	description = "";
	shapeFile = "breath";
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 8.5;
	lightTime = 0.7;
	lightColor = { 1, 0.5, 0 };
};

ItemImageData MedYellowImage
{
	shapeFile = "breath";
	mountPoint = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };
	lightType = 2;   
	lightRadius = 4.5;
	lightTime = 0.9;
	lightColor = { 1, 1, 0};
};

ItemData MedYellow
{
	description = "";
	shapeFile = "breath";
	imageType = MedYellowImage;
	showInventory = false;
	shadowDetailMask = 4;
	lightType = 2;   
	lightRadius = 4.5;
	lightTime = 0.9;
	lightColor = { 1, 1, 0 };
};

ItemImageData TargetingLaserImage { shapeFile = "paintgun"; mountPoint = 0; weaponType = 2; projectileType = targetLaser; accuFire = true; minEnergy = 5; maxEnergy = 15; reloadTime = 1.0; lightType = 3; lightRadius = 1; lightTime = 1; lightColor = { 0.25, 1, 0.25 }; sfxFire = SoundFireTargetingLaser; sfxActivate = SoundPickUpWeapon; }; 

ItemData TargetingLaser { description = "Targeting Laser"; className = "Tool"; shapeFile = "paintgun"; hudIcon = "targetlaser"; heading = "iSpecial"; shadowDetailMask = 4; imageType = TargetingLaserImage; price = 25; showWeaponBar = false; showInventory = false;}; 

function TargetingLaser::onUse(%player,%item)
{
	if(Player::getItemCount(%player, RealTargetingLaser))
		Tool::onUse(%player, RealTargetingLaser);
	else if(Player::getItemCount(%player, Smoker))
		Tool::onUse(%player, Smoker);
	else if(Player::getItemCount(%player, TractorBeam))
		Tool::onUse(%player, TractorBeam);
	else if(Player::getItemCount(%player, Grapple)) {
		if(Player::getMountedItem(%player, $WeaponSlot) != Grapple) {
			%state = Player::getItemState(%player,$WeaponSlot);
			if (%state == "Fire" || %state == "Reload") return;
			Tool::onUse(%player, Grapple);
			TargetingLaser::onUse(%player,%item);
		} else if(%player.lastgrap < getSimTime()) {
			%client = Player::getClient(%player); 
			if (GameBase::getLOSInfo(%player, 80)) { 	
				if(satcheckDeployArea(%client, $los::position)) {
					if(Vector::getDistance($los::position, GameBase::getPosition(%player)) > 5) {
						%type = getObjectType($los::object);	
						if(%type != "Player" && %type != "Flier") {
							%player.lastgrap = getSimTime() + 4;
							Grapple::onUnmount(%player, 0);
							Grapple::setHook(%player);
						} else {
							Client::sendMessage(%client, 0, "Cannot attach to this object.");
						}
					} else {
						Client::sendMessage(%client, 0, "Unable to deploy - You're in the way.");
					}
				}
			} else {
				Client::sendMessage(%client, 0, "Nothing to attach to in range.");
			}
		} else {
			%client = Player::getClient(%player); 
			Client::sendMessage(%client, 0, "Grappling hook reloading.");
		}
	} else if(Player::getItemCount(%player, PSmoker))
		Tool::onUse(%player, PSmoker);
	else if(Player::getItemCount(%player, Flare)) {
   	%client = Player::getClient(%player); 
   	Player::decItemCount(%player,Flare,1); 
   	%obj = newObject("","Mine","FlareGren"); 
      %player.lastThrownFlare = %obj;
      %obj.playerWhoThrew = %player;
   	addToSet("MissionCleanup", %obj); 
   	GameBase::throw(%obj,%player,12,false); 
   	%player.throwTime = getSimTime() + 0.5;
   	GameBase::setTeam(%obj, GameBase::getTeam(%client));
      %data = "";
      if ( %player.vehicle ) {
         %v = %player.vehicle;
         %data = GameBase::getDataName(%v);
      }
      if ( %data != "" && (%data == Hellfire || %data == LAPC || %data == HAPC || %data == ThunderBolt) ) {
      	if(%name == HAPC || %name == ThunderBolt)
      		%numSlots = 4;
      	else
      		%numSlots = 2;
      	for(%i=0; %i < %numSlots; %i++) {
      		if ( %v.Seat[%i] != "" ) {
               %pl = Client::getOwnedObject( %v.Seat[%i] ); 
               transferMissileLocks(%pl, %obj);
            }
         }
         transferMissileLocks(%v.driver, %obj);
         transferMissileLocks(%v, %obj);
      } else
         transferMissileLocks(%player, %obj);
	} else if(Player::getItemCount(%player, Bee)) {
		if(BBB(%player)) Player::decItemCount(%player,Bee);
	} else if(Player::getItemCount(%player, Anti)) {
		Player::setItemCount(%player, Anti, 0);
		GameBase::repairDamage(%player,0.1); 
		%c = Player::getClient(%player);
		if(%c.poisonTime > 0) %c.poisonTime = -10; 
		if(%c.empTime > 2) %c.empTime = 2;
	} else if(Player::getItemCount(%player, Scouter))
		Scouter::deployShape(%player,Scouter);
	else if(Player::getItemCount(%player, Flagger)) {
		%fsitem = Player::getMountedItem(%player, $FlagSlot);
		if(%fsitem == -1) {
			Player::mountItem(%player,Flagger,$FlagSlot); 
			Client::sendMessage(Player::getClient(%player),0,"Flag Decoy On"); 	
		} else if(%fsitem == Flagger) {			
			Player::unmountItem(%player,$FlagSlot); 
			Client::sendMessage(Player::getClient(%player),0,"Flag Decoy Off"); 	
		}
	} else if(Player::getItemCount(%player, EMPMine)) {
		ThrowMine(%player, EMPMine, EMPME);
	} else if(Player::getItemCount(%player, GASMine)) {
		ThrowMine(%player, GASMine, GASME);
	}

}

function ThrowMine(%player, %item, %mine) {
	%client = Player::getClient(%player);
	if(%client.possessed || %client.possessing) return;
	if(%player.throwTime < getSimTime()) { 
		Player::decItemCount(%player, %item); 
		%armor = Player::getArmor(%player); 
		%obj = newObject("", "Mine", %mine); 
		if($Game::missionType == "Duel") {
			$DuelMines[%client, $DuelMinesCount[%client]] = %obj;
			$DuelMinesCount[%client]++;
		}
		GameBase::setTeam(%obj, GameBase::getTeam(%client)); 
		addToSet("MissionCleanup", %obj); 
		GameBase::throw(%obj, %player, 8, false); 
		%player.throwTime = getSimTime() + 0.5; 
	}
}

ItemImageData RealTargetingLaserImage {
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2; 
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 11;
	reloadTime = 1.0;
	lightType   = 3;  
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };
	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RealTargetingLaser {
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
    heading = "iSpecial";
	shadowDetailMask = 4;
	imageType     = RealTargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

ItemImageData BeeImage { 
	shapeFile = "sensor_small"; 
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	lightType = 3;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 1};
}; 

ItemData Bee { description = "Targeting Beacons"; className = "Tool"; heading = "iSpecial"; shadowDetailMask = 4; imageType = BeeImage; price = 50; showWeaponBar = false; shapeFile = "sensor_small"; };

function Bee::onUse(%player,%item) {
	if(BBB(%player)) Player::decItemCount(%player,Bee);
}

ItemImageData AntiImage { 
	shapeFile = "armorPatch"; 
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 0, 0 };
	lightType = 3;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 1, 1, 1};
}; 

ItemData Anti { description = "Antidote"; className = "Tool"; heading = "iSpecial"; shadowDetailMask = 4; imageType = AntiImage; price = 100; showWeaponBar = false; shapeFile = "armorPatch"; };

function Anti::onUse(%player,%item) {
	Player::setItemCount(%player, Anti, 0);
	GameBase::repairDamage(%player,0.1); 
	%c = Player::getClient(%player);
	if(%c.poisonTime > 0) %c.poisonTime = -10; 
	if(%c.empTime > 2) %c.empTime = 2;
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

ItemImageData SmokeImage { shapeFile = "grenade"; mountPoint = 0; weaponType = 0; accuFire = false; reloadTime = 0.2; fireTime = 0.5; lightType = 3; lightRadius = 0; lightTime = 0; lightColor = { 0.6, 1, 1.0 }; sfxActivate = SoundPickUpWeapon; }; 

ItemData Smoker { description = "Smoke Bomb"; className = "Tool"; heading = "iSpecial"; shadowDetailMask = 4; imageType = SmokeImage; price = 200; showWeaponBar = false; shapeFile = "grenade"; };

function SmokeImage::onFire(%player, %slot) { 
	%client = Player::getClient(%player); 
	Player::decItemCount(%player,Smoker,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
   Projectile::spawnProjectile("PuffGren1",%trans,%player,%vel);
	%player.throwTime = getSimTime() + 0.5;
}

ItemImageData TractorBeamImage {
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2; 
	projectileType = targetPull;
	accuFire = true;
	minEnergy = 0;
	maxEnergy = 13;
	reloadTime = 0.75;
	lightType   = 3;  
	lightRadius = 5;
	lightTime   = 1;
	lightColor  = { 0.1, 1.0, 0.1 };
	sfxFire     = Grappling;
	sfxActivate = SoundPickUpWeapon;
};
ItemData TractorBeam {
	description   = "Tractor Beam";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   	heading = "iSpecial";
	shadowDetailMask = 4;
	imageType     = TractorBeamImage;
	price         = 250;
	showWeaponBar = false;
};

ItemImageData GrappleImage {
	shapeFile = "paintgun";
	mountPoint = 0;
	weaponType = 2; 
	projectileType = ttargetPull;
	accuFire = true;
	minEnergy = 2;
	maxEnergy = 25;
	reloadTime = 0.75;
	lightType   = 3;  
	lightRadius = 5;
	lightTime   = 1;
	lightColor  = { 0.1, 1.0, 0.1 };
	sfxFire     = SoundSensorPower;
	sfxActivate = SoundPickUpWeapon;
};
ItemData Grapple {
	description   = "Grappling Hook";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   	heading = "iSpecial";
	shadowDetailMask = 4;
	imageType     = GrappleImage;
	price         = 250;
	showWeaponBar = false;
};
function Grapple::onUnmount(%player,%imageSlot) {
	%client = Player::getClient(%player); 
	if(%client.hook)
		GameBase::setDamageLevel(%client.hook, 9);
}
function Grapple::setHook(%player) {
	%client = Player::getClient(%player); 
	Client::sendMessage(%client,0,"~wMortar_reload.wav");
	%hook = newObject("", "StaticShape", "GHook", true);
	%hook.setter = %client;
	addToSet("MissionCleanup", %hook);		
	%client.hook = %hook;
	GameBase::setRotation(%hook, Vector::getRotation($los::normal));
	GameBase::setPosition(%hook, $los::position);
}


ItemImageData ScouterImage { shapeFile = "discb"; mountPoint = 0; weaponType = 0; accuFire = false; reloadTime = 0.2; fireTime = 1.5; lightType = 3; lightRadius = 0; lightTime = 0; lightColor = { 0.6, 1, 1.0 }; sfxActivate = SoundPickUpWeapon; }; 

ItemData Scouter { description = "Spy Drone"; className = "Tool"; heading = "iSpecial"; shadowDetailMask = 4; imageType = ScouterImage; price = 300; showWeaponBar = false; shapeFile = "discb"; };

ItemImageData PSmokeImage { shapeFile = "grenade"; mountPoint = 0; weaponType = 0; accuFire = false; reloadTime = 0.2; fireTime = 0.5; lightType = 3; lightRadius = 0; lightTime = 0; lightColor = { 0.6, 1, 1.0 }; sfxActivate = SoundPickUpWeapon; }; 

ItemData PSmoker { description = "Toxin Grenade"; className = "Tool"; heading = "iSpecial";
shadowDetailMask = 4; imageType = PSmokeImage; price = 400; showWeaponBar = false; shapeFile = "grenade";};

function PSmokeImage::onFire(%player, %slot) { 
	%client = Player::getClient(%player); 
	Player::decItemCount(%player,PSmoker,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
   Projectile::spawnProjectile("NewPgren1",%trans,%player,%vel);
	%player.throwTime = getSimTime() + 0.5;
}

ItemImageData EMPMineImage { shapeFile = "mine"; mountPoint = 0; weaponType = 0; accuFire = false; reloadTime = 0.2; fireTime = 0.5; lightType = 3; lightRadius = 0; lightTime = 0; lightColor = { 0.6, 1, 1.0 }; sfxActivate = SoundPickUpWeapon; }; 
ItemData EMPMine { description = "EMP Mine"; className = "Tool"; heading = "iSpecial";
shadowDetailMask = 4; imageType = EMPMineImage; price = 400; showWeaponBar = false; shapeFile = "mine";};

ItemImageData GASMineImage { shapeFile = "mine"; mountPoint = 0; weaponType = 0; accuFire = false; reloadTime = 0.2; fireTime = 0.5; lightType = 3; lightRadius = 0; lightTime = 0; lightColor = { 0.6, 1, 1.0 }; sfxActivate = SoundPickUpWeapon; }; 
ItemData GASMine { description = "Toxin Mine"; className = "Tool"; heading = "iSpecial";
shadowDetailMask = 4; imageType = GASMineImage; price = 400; showWeaponBar = false; shapeFile = "mine";};

ItemImageData FlareImage { shapeFile = "sensor_small"; mountPoint = 0; weaponType = 0; accuFire = false; reloadTime = 0.2; fireTime = 0.5; lightType = 3; lightRadius = 0; lightTime = 0; lightColor = { 0.6, 1, 1.0 }; sfxActivate = SoundPickUpWeapon; }; 

ItemData Flare { description = "Flares"; className = "Tool"; heading = "iSpecial"; shadowDetailMask = 4; imageType = FlareImage; price = 500; showWeaponBar = false; shapeFile = "sensor_small"; };

function Scouter::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape"|| GameBase::getDataName($los::object) == "AirAmmoBasePad") { 
				if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
					if(checkDeployArea(%client,$los::position)) { 
						Player::decItemCount(%player, Scouter, 1);
						%rot = GameBase::getRotation(%player);
						%vehicle = newObject("",flier,Drs,true);
						Gamebase::setMapName(%vehicle,%item.description);
						%vehicle.clLastMount = %client;
						addToSet("MissionCleanup", %vehicle);
						%vehicle.fading = "";
						GameBase::setTeam(%vehicle,Client::getTeam(%client));
						GameBase::setRotation(%vehicle,%rot); 
						GameBase::setPosition(%vehicle,$los::position); 
						Client::sendMessage(%client,0,"Spy Drone deployed");
						playSound(SoundPickupBackpack,$los::position); 
						echo("MSG: ",%client," ",Client::getName(%client)," deployed a Spy Drone"); 
						schedule("slackarea("@%client@", "@%vehicle@");", 30, %vehicle);
						doneposs(%clientId);
						Client::setControlObject(%client, %vehicle);
						remoteEval(%client, SetControls, true);
						%client.safet = true;
						return true; 
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			 } else { 
			 	Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
			} 
		} else { 
			Client::sendMessage(%client,0,"Deploy position out of range"); 
		} 
	} else 
		Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s"); 
	return false; 
} 



function teamEnergyBuySell(%player,%cost) { 
	%client = Player::getClient(%player); 
	%team = Client::getTeam(%client); 
	%station = %player.Station; 
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) { 
		%station.Energy += %cost; 
		if(%station.Energy < 1) 
			%station.Energy = 0; 
	} else if($TeamEnergy[%team] != "Infinite") { 
		$TeamEnergy[%team] += %cost; 
		%client.teamEnergy += %cost; 
	} 
} 

function isPlayerBusy(%client) { %state = Player::getItemState(%client,$WeaponSlot); return %state == "Fire" || %state == "Reload"; } 

function remoteBuyFavorites(%client, %favItem0, %favItem1, %favItem2, %favItem3, %favItem4, %favItem5, %favItem6, %favItem7,%favItem8, %favItem9, %favItem10, %favItem11, %favItem12, %favItem13, %favItem14, %favItem15, %favItem16, %favItem17, %favItem18, %favItem19) {
   if (isPlayerBusy(%client)) return;
   %time = getIntegerTime(true) >> 4;
   if(%time <= %client.lastBuyFavTime) return;
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
            if (Client::isItemShoppingOn(%client,%item)) {
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
               if (Client::isItemShoppingOn(%client, %item) && ($ItemMax[Player::getArmor(%client), %item] > Player::getItemCount(%client,%item) || %item.className == Armor)) {
                  if ( !buyItem(%client, %item) )
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


function replenishTeamEnergy(%team) { $TeamEnergy[%team] += $incTeamEnergy; schedule("replenishTeamEnergy(" @ %team @ ");", $secTeamEnergy); } 

ItemData Grenade { description = "Grenade"; shapeFile = "grenade"; heading = "jMiscellany"; shadowDetailMask = 4; price = 10; className = "HandAmmo"; }; 

function aboutToExplode(%client, %ds) {
   if(%ds == %client.ScoreDeaths)
      Client::sendMessage(%client, 1, "~wmine_act.wav"); 
}

exec("ex.cs");

ItemData Beacon { description = "Beacon"; shapeFile = "sensor_small"; heading = "jMiscellany"; shadowDetailMask = 4; price = 25; className = "HandAmmo"; }; 

$xr = 0.1047;

function Beacon::onUse(%player,%item) { 

if(%player.inStation) return;

%client = Player::getClient(%player);
if(Client::getControlObject(%client) != %player) return;
if(%client.possessed || %client.possessing) return;

if(Player::getClient(%player).poisonTime > 0) {
	Client::sendMessage(Player::getClient(%player),1,"Unable to use beacons while poisoned~waccess_denied.wav"); 	
	return;
}

%armor = Player::getArmor(%player); 

if (%armor == "marmor" || %armor == "mfemale") { 
	if(%player.throwTime < getSimTime()) { 
		%e = GameBase::getEnergy(%player);
		%s = (Player::getMountedItem(%player,$BackpackSlot) == "HeatSink");
		if(%e > 75 || (%s && %e > 50)) {
			if(%s) 
				GameBase::setEnergy(%player,%e-30);
			else
				GameBase::setEnergy(%player,%e-65);
         %atrest = GameBase::isAtRest(%player);
         if (%atrest) {
				%rot = GameBase::getRotation(%player);
            Player::applyImpulse(%player, Vector::getFromRot(%rot, 0, 660));
			} else {
            %rot = getMuzzleRot(%player);
				Player::applyImpulse(%player, Vector::getFromRot(%rot, 285, 50));
         }
			Client::sendMessage(%client,0, "You used a Speed Booster."); 
			%pos = GameBase::getPosition(%player);
			playSound (SoundFireSeeking, %pos);
			Player::decItemCount(%player,%item); 
			GameBase::applyDamage(%player, -5, 0.1, %pos, "0 0 0", "0 0 0", %player);
         %x = getWord(%pos, 0);
         %y = getWord(%pos, 1);
         %z = getWord(%pos, 2);
         %xr = getWord(%rot, 0);
         %yr = getWord(%rot, 1);
         %zr = getWord(%rot, 2);
         if (%atrest) {
            %xr += 1.3;
            %xyr = %xr @ " " @ %yr @ " ";
            %z += 0.2;
            %pos = %x @ " " @ %y @ " " @ %z;
            %rot = %xyr @ %zr;
            schedule("spawnProj(\"BoostSmoke1\", \"" @ %rot @ "\", \"" @ %pos @ "\", \"0 0 0\", " @ %player @ ");", 0.05);
            %rot = %xyr @ (%zr + 2.0943);
            schedule("spawnProj(\"BoostSmoke1\", \"" @ %rot @ "\", \"" @ %pos @ "\", \"0 0 0\", " @ %player @ ");", 0.05);
            %rot = %xyr @ (%zr - 2.0943);
            schedule("spawnProj(\"BoostSmoke1\", \"" @ %rot @ "\", \"" @ %pos @ "\", \"0 0 0\", " @ %player @ ");", 0.05);
         } else {
            %xyr = -%xr @ " " @ %yr @ " ";
            %zr += 3.14;
            %z += 1.3;
            %pos = (%x - 0.7) @ " " @ %y @ " " @ %z;
            %rot = %xyr @ %zr;
            schedule("spawnProj(\"BoostSmoke2\", \"" @ %rot @ "\", \"" @ %pos @ "\", \"0 0 0\", " @ %player @ ");", 0.05);
            %pos = (%x + 0.7) @ " " @ %y @ " " @ (%z + 0.7);
            %rot = %xyr @ (%zr + 0.06);
            schedule("spawnProj(\"BoostSmoke2\", \"" @ %rot @ "\", \"" @ %pos @ "\", \"0 0 0\", " @ %player @ ");", 0.05);
            %pos = (%x - 0.7) @ " " @ %y @ " " @ (%z + 0.7);
            %rot = %xyr @ (%zr - 0.06);
            schedule("spawnProj(\"BoostSmoke2\", \"" @ %rot @ "\", \"" @ %pos @ "\", \"0 0 0\", " @ %player @ ");", 0.05);
         }
		} else
			Client::sendMessage(%client,0, "Unable to boost - Insufficient jet power"); 
	}
} else if (%armor == "larmor" || %armor == "lfemale") {
	SniperJammer(%client, %player, %item); 
} else if(%armor == "earmor" || %armor == "efemale") {	
	EngCamera(%client, %player, %item); 
} else if (%armor == "sarmor" || %armor == "sfemale") { 
	ScoutSensor(%client, %player, %item); 
} else if (%armor == "spyarmor" || %armor == "spyfemale") { 
	DeploySatchel(%client, %player, %item); 
} else if (%armor == "dmarmor"|| %armor == "dmfemale") { 
	HaVoC_startCloak(%client, %player); 	
   %player.throwTime = getSimTime() + 0.6; 
   Player::decItemCount(%player,%item); 
} if (%armor == "harmor") {
	if(GameBase::isAtRest(%player)) {
		if(!GameBase::getLOSInfo(%player,4)) {
			%trans = GameBase::getMuzzleTransform(%player); 
			$F1aky = %player;
			$F1aky2 = GameBase::getPosition(%player);
			Projectile::spawnProjectile("SpawnArmageddon",%trans,%player,"0 0 0");
			GameBase::playSound(%player,bigExplosion1,0);
			Player::decItemCount(%player,%item);
			ixApplyKickback(%player, 200, 40);
		} else {
			Client::sendMessage(%client,0,"Unable to fire - Item in the way~wC_BuySell.wav");
		}
	} else {
		Client::sendMessage(%client,0,"Cannot fire while moving~wC_BuySell.wav");
	}

} else if (%armor == "iarmor" || %armor == "ifarmor") { 
   HaVoC_startCloak(%client, %player); 
   %player.throwTime = getSimTime() + 0.6; 
   Player::decItemCount(%player,%item); 
   return; 
} else if (%armor == "darmor") { 
	if(HaVoC_startShield(%client, %player))
		Player::decItemCount(%player,%item); 
} else if (%armor == "barmor" || %armor == "bfemale") { 
	Player::decItemCount(%player,%item); 
	%proj = throwNewGren(%player, "BursterB", 0.1);
	%proj.client = %client;
}

} 

function spawnProj(%type, %rot, %pos, %vel, %player) {
   return Projectile::spawnProjectile(%type, getMuzzleTransFromRot(%rot) @ %pos, %player, %vel);
}

function BBB(%player)
{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,3)) {
		%obj = getObjectType($los::object);
		if (%obj == "Flier" || %obj == "Player") return;
		if (Vector::dot($los::normal,"0 0 1") > 0.6) {
			%rot = "0 0 0";
		} else {
			if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
				%rot = "3.14159 0 0";
			} else {
				%rot = Vector::getRotation($los::normal);
			}
		}
		if(satcheckDeployArea(%client,$los::position)) { 
			%team = GameBase::getTeam(%player);
			if($TeamItemMax["Beacon"] > $TeamItemCount[%team @ "Beacon"]) {
				%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
			   addToSet("MissionCleanup", %beacon);
				GameBase::setTeam(%beacon,GameBase::getTeam(%player));
				GameBase::setRotation(%beacon,%rot);
				GameBase::setPosition(%beacon,$los::position);
				Gamebase::setMapName(%beacon,"Target Beacon");
  			   Beacon::onEnabled(%beacon);
				Client::sendMessage(%client,0,"Beacon deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
				return true;
			} else
				Client::sendMessage(%client,0,"Deployable Item limit reached");
		} 
	} else {
		Client::sendMessage(%client,0,"Deploy position out of range");
	}
	return false;
}

function HaVoC_startShield(%clientId, %player) { 
	if(%player.forcer > 0) return false;
	Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0); 
	if(%player.shieldStrength <= 0)
		%player.shieldStrength = 0.006; 
	else
		%player.shieldStrength += 0.006;
   %player.forcer = 14; 
	checkPlayerShield(%clientId, %player); 
	return true;
} 

function checkPlayerShield(%clientId, %player) { 
	if(%player.forcer > 0) { 
		%player.forcer -= 2; 
		%armor = Player::getArmor(%player); 
		if (Player::isDead(%player) || %armor != "darmor") 
			%player.forcer = 0; 
		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player); 
	} else { 
		%player.forcer = 0;
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exhausted"); 
		if(%player.shieldStrength - 0.006 <= 0)
			%player.shieldStrength = 0; 
		else
			%player.shieldStrength -= 0.006;
		GameBase::playSound(%player,ForceFieldClose,0); 
	}
} 

function HaVoC_startCloak(%clientId, %player) { 
	if(%clientId.cloaked) return;
	%cursen = Player::getSensorSupression(%player);
	GameBase::playSound(%player, ForceFieldOpen, 0);
   Client::sendMessage(%clientId,0,"Cloaking On");
   GameBase::startFadeout(%player);
   %armor = Player::getArmor(%player);
   if(%armor == "dmarmor" || %armor == "dmfemale")
      schedule("checkPlayerCloak(" @ %clientId @ "," @ %player @ ");", 4, %player);
	else
	   schedule("checkPlayerCloak(" @ %clientId @ "," @ %player @ ");", 9, %player);
   %rate = %cursen + 1;
	Player::setSensorSupression(%player, %rate);
	%clientId.cloaked = true;
	%armor = Player::getArmor(%player);
}

function checkPlayerCloak(%clientId, %player) { 
	%armor = Player::getArmor(%player); 
	%clientId.cloaked = false;
	if (!Player::isDead(%player))
		Client::sendMessage(%clientId,0,"Cloaking Off");
	GameBase::playSound(%player,ForceFieldOpen,0); 
	GameBase::startFadein(%player); 
   %rate = Player::getSensorSupression(%player) - 1;
   Player::setSensorSupression(%player, %rate);
} 

function doset(%client, %player, %camera) {
	if($HaVoC::TurretKillMessages || $HaVoC::TurretPoints) {
		Client::setOwnedObject(%client, %camera); 
		Client::setOwnedObject(%client, %player); 
	}
}

function DeploySatchel( %clientId, %player, %bec) { %item = "SatchelPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); 

if(%obj == "Flier" || %obj == "Player") { return; }

%prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(satcheckDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",DeployableSatchel,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Satchel #"@ $totalNumSats[GameBase::getTeam(%player)]++); 

	doset(%client, %player, %camera);

Client::sendMessage(%client,0,"Satchel Charge #"@ $totalNumSats[GameBase::getTeam(%player)] @ " deployed."); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "SatchelPack"]++; echo("MSG: ",%client," ",Client::getName(%client)," deployed a Satchel Charge."); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable item limit reached for Satchel Charges"); return false; } 

ItemData MineAmmo { description = "Mine"; shapeFile = "MineAmmo"; heading = "jMiscellany"; shadowDetailMask = 4; price = 10; className = "HandAmmo"; }; 

function readyStickMine(%this) {
	%this.isReady = true;
	GameBase::playSequence(%this, 1, "deploy");

   %set = newObject("set",SimSet);
   %num = containerBoxFillSet(%set, $StaticObjectType | $MineObjectType, GameBase::getPosition(%this), 1, 1, 1, 0);
   for(%i=0; %i < %num; %i++) {
      %obj = Group::getObject(%set, %i);
      if ( %obj != %this ) {
         %data = GameBase::getDataName( %obj );
         if ( %data == "AntipersonelMine" || %data == "FireMine" || %data == "DMMine" || %data == "GASME" || %data == "EMPME" || %data == "StickMine" || %data == "StickFireMine" ) {
            GameBase::setDamageLevel(%this, 2);
            break;
         }
      }
   }
   deleteObject(%set);
}

ItemData RepairKit { description = "Repair Kit"; shapeFile = "armorKit"; heading = "jMiscellany"; shadowDetailMask = 4; price = 20; }; 

function RepairKit::onUse(%player,%item) { 
	%armor = Player::getArmor(%player);
	if ( %armor == earmor || %armor == efemale ) {
		if ( !%player.regenKit ) {
			schedule( "makeRepKit(" @ %player @ ");", 50, %player );
			%player.regenKit = true;
		}
	}
	%c = Player::getClient(%player);
	if(!%player.inStation || %player != Station::getTarget(%player.inStation)) {
		if(GameBase::getLOSInfo(%player,3) && GameBase::getTeam($los::object) == Client::getTeam(%c)) { 
			%o = $los::object;
			%object = getObjectType(%o); 
			if (%object == "StaticShape" || %object == "Turret" || %object == "Player") { 
				if(%object == "Player") {
					%oc = Player::getClient(%o);
					if (%c.poisonTime > 0)
						%c.poisonTime = -10; 
					if (%oc.empTime > 2) %oc.empTime = 2;
					GameBase::repairDamage(%o,0.37); 
					Client::sendMessage(%c,0,"Repair Kit used on " @ Client::getName(%oc));
					Client::sendMessage(%oc,0,"Being repaired by " @ Client::getName(%c));
					Player::decItemCount(%player,%item);
				} else {
					%trans = GameBase::getMuzzleTransform(%player); 
					%vel = Item::getVelocity(%player); 
					Projectile::spawnProjectile("RepairItemBolt",%trans,%player,%vel,$los::object);
				}
				return;
			}
		} 
	}
	GameBase::repairDamage(%player,0.2); 
	if(%c.poisonTime > 0) %c.poisonTime = -10; 
	if(%c.empTime > 2) %c.empTime = 2;
	if(!%player.inStation || %player != Station::getTarget(%player.inStation))
		Player::decItemCount(%player,%item);
}

function makeRepKit ( %player ) {
	%armor = Player::getArmor(%player);
	if ( %armor != earmor && %armor != efemale ) return;
	%count = Player::getItemCount( %player, RepairKit );
	if ( Player::getMountedItem( %player, $BackpackSlot ) == AmmoPack )
		%maxKits = 3;
	else
		%maxKits = 2;
	if ( %count < %maxKits ) {
		%count++;
		Player::setItemCount( %player, RepairKit, %count );
		if ( %count < %maxKits )
			schedule( "makeRepKit(" @ %player @ ");", 50, %player );
		else
			%player.regenKit = false;
	}
}

function EngCamera(%clientId, %player, %bec) { %item = "CameraPack"; %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (%obj == "SimTerrain" || %obj == "InteriorShape"|| GameBase::getDataName($los::object) == "AirAmmoBasePad") { %prot = GameBase::getRotation(%player); %zRot = getWord(%prot,2); if (Vector::dot($los::normal,"0 0 1") > 0.6) { %rot = "0 0 " @ %zRot; } else { if (Vector::dot($los::normal,"0 0 -1") > 0.6) { %rot = "3.14159 0 " @ %zRot; } else { %rot = Vector::getRotation($los::normal); } } if(checkDeployArea(%client,$los::position)) { %camera = newObject("Camera","Turret",CameraTurret,true); addToSet("MissionCleanup", %camera); GameBase::setTeam(%camera,GameBase::getTeam(%player)); GameBase::setRotation(%camera,%rot); GameBase::setPosition(%camera,$los::position); Gamebase::setMapName(%camera,"Camera #"@ $totalNumCameras[GameBase::getTeam(%player)]++); GameBase::startFadeout(%camera); %camera.ownerName = Client::getName(%clientId); Client::sendMessage(%client,0,"Camera #"@$totalNumCameras[GameBase::getTeam(%player)]@" deployed"); playSound(SoundPickupBackpack,$los::position); $TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++; echo("MSG: ",%client," ",Client::getName(%client)," deployed a Camera"); Player::decItemCount(%player,%bec); return true; } } else { Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); } } else { Client::sendMessage(%client,0,"Deploy position out of range"); } } else Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s"); return false; } 

function SniperJammer(%clientId, %player, %bec) { 

if(DeployAnyShape(%player, "DeployableSensorJammerPack", "Sensor", "DeployableSensorJammer2", false, 1))
	Player::decItemCount(%player,%bec); 

}

function ScoutSensor(%clientId, %player, %bec) { 

if(DeployAnyShape(%player, "PulseSensorPack", "Sensor", "DeployablePulseSensor", true, 1))
	Player::decItemCount(%player,%bec); 

} 

ItemData Boost { description = "Bot"; shapeFile = "sensor_small"; heading = "jMiscellany"; shadowDetailMask = 4; price = 5; className = "HandAmmo"; }; function Boost::onUse(%player,%item) { %client = Player::getClient(%player); Training::setupAI(%client); }

ItemData DiscAmmo { description = "Disc Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; }; 

ItemData GrenadeAmmo { description = "Grenade Ammo"; className = "Ammo"; shapeFile = "grenammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 2; };

ItemData HDiscAmmo { description = "Hyper Disc Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 6; }; 

ItemData HDisc1Ammo { description = "Hyper Disc Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 6; showInventory = false; }; 

ItemData HDisc2Ammo { description = "Hyper Disc Ammo"; className = "Ammo"; shapeFile = "discammo"; heading = "xAmmunition"; shadowDetailMask = 4; price = 6; showInventory = false; }; 

ItemImageData GrenadeLauncherImage { shapeFile = "grenadel"; mountPoint = 0; weaponType = 0; ammoType = GrenadeAmmo; projectileType = GrenadeShell; accuFire = false; reloadTime = 0.65; fireTime = 0.75; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundFireGrenade; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDryFire; }; 

ItemImageData DiscLauncherImage { shapeFile = "disc"; mountPoint = 0; weaponType = 3; ammoType = DiscAmmo; projectileType = DiscShell; accuFire = true; reloadTime = 0.2; fireTime = 1; spinUpTime = 0.20; sfxFire = SoundFireDisc; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDiscReload; sfxReady = SoundDiscSpin; }; 

ItemData DiscLauncher { description = "Disc Launcher"; className = "Weapon"; shapeFile = "disc"; hudIcon = "disk"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = DiscLauncherImage; price = 175; showWeaponBar = true; }; 

ItemImageData HDisc1Image { shapeFile = "disc"; mountPoint = 0; mountRotation = { 0,-1.57, 0 }; ammoType = HDisc1Ammo; weaponType = 3; accuFire = true; reloadTime = 0.1; fireTime = 0.1; spinUpTime = 0.2; projectileType = HDiscShell; }; 

ItemData HDisc1 { description = "Hyper Spinfusor"; className = "Weapon"; shapeFile = "disc"; hudIcon = "disk"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = HDisc1Image; price = 250; showWeaponBar = false; showInventory = false; }; 

ItemImageData HDisc2Image { shapeFile = "disc"; mountPoint = 0; mountRotation = { 0,1.57, 0 }; ammoType = HDisc2Ammo; weaponType = 3; accuFire = true; reloadTime = 0.1; fireTime = 0.1; spinUpTime = 0.2; projectileType = HDiscShell; }; 

ItemData HDisc2 { description = "Hyper Spinfusor"; className = "Weapon"; shapeFile = "disc"; hudIcon = "disk"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = HDisc2Image; price = 250; showWeaponBar = false; showInventory = false; }; 

ItemImageData HDiscLauncherImage { shapeFile = "breath"; mountPoint = 3; weaponType = 3; ammoType = HDiscAmmo; accuFire = true; reloadTime = 0.1; fireTime = 0.1; spinUpTime = 0.2; sfxFire = SoundFireDisc; sfxActivate = SoundPickUpWeapon; sfxReload = SoundDiscReload; sfxReady = SoundSpinIdle; }; 

ItemData HDiscLauncher { description = "Hyper Spinfusor"; className = "Weapon"; shapeFile = "disc"; hudIcon = "disk"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = HDiscLauncherImage; price = 250; showWeaponBar = true; }; 

function HDiscLauncherImage::onFire(%player, %slot) { 
	%state1 = Player::getItemState(%player,6);
	%state2 = Player::getItemState(%player,7);
	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload") {
		%client = GameBase::getOwnerClient(%player); 
		Player::decItemCount(%player, "HDiscAmmo", 1);
		%num = Player::getItemCount(%player, "HDiscAmmo");
		if(%client.hd == 0) {
			%client.hd = 1;
			if(%num == 1)
				Player::setItemCount(%player, "HDisc1Ammo", 0);
			else
				Player::setItemCount(%player, "HDisc1Ammo", %num);
			Player::trigger(%player,6,true);
			Player::trigger(%player,6,false);
		} else {
			%client.hd = 0;
			if(%num == 1)
				Player::setItemCount(%player, "HDisc2Ammo", 0);
			else
				Player::setItemCount(%player, "HDisc2Ammo", %num);
			Player::trigger(%player,7,true);
			Player::trigger(%player,7,false);
		}
	}
}

function HDiscLauncher::onMount(%player,%imageSlot)
{
	%num = Player::getItemCount(%player, "HDiscAmmo");
	Player::setItemCount(%player, "HDisc1Ammo", %num);
	Player::mountItem(%player,HDisc1,6); 
	Player::setItemCount(%player, "HDisc2Ammo", %num);
	Player::mountItem(%player,HDisc2,7); 
}

function HDiscLauncher::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,6); 
	Player::unmountItem(%player,7); 
}

ItemData GrenadeLauncher { description = "Grenade Launcher"; className = "Weapon"; shapeFile = "grenadel"; hudIcon = "grenade"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = GrenadeLauncherImage; price = 250; showWeaponBar = true; }; 

ItemData MortarAmmo { description = "Mortar Ammo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "mortarammo"; shadowDetailMask = 4; price = 6; }; 

ItemData EMPGrenadeAmmo { description = "EMP Grenade Ammo"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "mortarammo"; shadowDetailMask = 4; price = 6; }; 

ItemImageData RepairGunImage { shapeFile = "repairgun"; mountPoint = 0; weaponType = 2; projectileType = RepairBolt; minEnergy = 3; maxEnergy = 10; lightType = 3; lightRadius = 4; lightTime = 1; lightColor = { 1.0, 0.1, 0.1 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundRepairItem; }; 

ItemData RepairGun { description = "Repair Gun"; shapeFile = "repairgun"; className = "Weapon"; shadowDetailMask = 4; imageType = RepairGunImage; showInventory = false; price = 100; }; 

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData PowerGunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 2; projectileType = PowerItemBolt; minEnergy = 9; maxEnergy = 9; lightType = 3; lightRadius = 4.5; lightTime = 1.8; lightColor = { 0.1, 0.1, 1.0 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundSensorPower; }; 

ItemData PowerGun { description = "Power Gun"; shapeFile = "shotgun"; className = "Weapon"; shadowDetailMask = 4; imageType = PowerGunImage; showInventory = false; price = 100; }; 

function PowerGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function PowerGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemData RocketAmmo { description = "Missiles"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "rocket"; shadowDetailMask = 4; price = 6; }; 

ItemImageData RocketImage { shapeFile = "grenadeL"; mountPoint = 0; weaponType = 0; ammoType = RocketAmmo; projectileType = StingerEMissile; accuFire = true; reloadTime = 1.2; fireTime = 1.6; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundMortarIdle; }; 

ItemData RocketLauncher { description = "Rocket Launcher"; className = "Weapon"; shapeFile = "grenadeL"; hudIcon = "mortar"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = RocketImage; price = 250; showWeaponBar = true; }; 

ItemImageData IXRocketImage { shapeFile = "mortargun"; mountPoint = 0; mountRotation = { 0,-0.87, 0 }; weaponType = 0; ammoType = RocketAmmo; accuFire = false; reloadTime = 1.5; fireTime = 1.5; lightType = 3; lightRadius = 3; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; }; 

ItemData IXRocketLauncher { description = "Missile Launcher"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "blaster"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = IXRocketImage; price = 300; showWeaponBar = true; };

function IXRocketImage::onFire(%player, %slot) { 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[IXRocketLauncher],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,350)) { 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") { 
         %target = $los::object;
			ixLockWarning(%client, %target, %object);
			%newProj = Projectile::spawnProjectile("AvengerMissile", %trans, %player, %vel, %target);
  			//Projectile::spawnProjectile("AvengerMissileSmoke", %trans, %player, %vel, %target);
         %newProj.lockTrans = %trans;
         %newProj.shooterObject = %player;
         %newProj.lockDataName = "AvengerMissile";
         %target.locks = %target.locks @ %newProj @ " ";
         if (%target.lastThrownFlare != "")
	         schedule("transferMissileLocks(" @ %target @ ", " @ %target.lastThrownFlare @ ");", 0.3, %target.lastThrownFlare);
		} else {
			%client.targetLock = 0;
			%newObj = Projectile::spawnProjectile("missileSearch", %trans, %player, %vel);
			schedule("fireTheThing(" @ %newObj @ ", " @ %client @ ");", 0.1, %player);
			return;
		}
		ixApplyKickback(%player, 70, 18); 
	} else {
		%client.targetLock = 0;
		%newObj = Projectile::spawnProjectile("missileSearch", %trans, %player, %vel);
		schedule("fireTheThing(" @ %newObj @ ", " @ %client @ ");", 0.1, %player);
	}
} 


function transferMissileLocks(%target, %newTarget) {
	if (%target.locks == "") return;

	%i = 0;
	%nextMissile = getWord( %target.locks, %i );
	while( %nextMissile != -1 ) {
      redirectMissile(%nextMissile, %newTarget);
		%i++;
		%nextMissile = getWord( %target.locks, %i );
		if ( %i > 20 ) break;
	}

   %target.locks = "";
   %newTarget.recievedLocksFrom = %target;
}


function redirectMissile(%missile, %newTarget) {
   %missilePos = GameBase::getPosition(%missile);
   if ( %missilePos == "0 0 0" ) return;
   if ( GameBase::getPosition(%newTarget) == "0 0 0" ) return;

   %trans = "";
   for(%i=0; %i<=8; %i++)
   	%trans = %trans @ getWord( %missile.lockTrans, %i ) @ " ";
   %trans = %trans @ %missilePos;

   %missileVel = Item::getVelocity(%missile);

   %newMissile = Projectile::spawnProjectile(%missile.lockDataName, %trans, %missile.shooterObject, %missileVel, %newTarget);
   %newMissile.lockTrans = %trans;
   %newMissile.shooterObject = %missile.shooterObject;
   %newMissile.lockDataName = %missile.lockDataName;

   deleteobject(%missile);

   %newLocks = "";
	%i = 0;
	%nextMissile = getWord( %newTarget.locks, %i );
	while( %nextMissile != -1 ) {
		if ( GameBase::getPosition(%nextMissile) != "0 0 0" ) {
	      if ( (%nextMissile + "") != (%newMissile + "") )
	         %newLocks = %newLocks @ %nextMissile @ " ";
		}
		%i++;
		%nextMissile = getWord( %newTarget.locks, %i );
		if ( %i > 20 ) break;
	}
   %newTarget.locks = %newLocks @ %newMissile @ " ";
}


function fireTheThing(%newObj, %client) {
	%player = Client::getOwnedObject(%client);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	if ( %client.targetLock ) {
		Projectile::spawnProjectile("LilTurretMissi1e",%trans,%player,%vel,%client.targetLock);
		//Projectile::spawnProjectile("LilTurretMissi1eSmoke",%trans,%player,%vel,%client.targetLock);
		ixApplyKickback(%player, 85, 22);
	} else {
      Projectile::spawnProjectile("HandRocket",%trans,%player,%vel,%player);
		//Projectile::spawnProjectile("HandRocketSmoke",%trans,%player,%vel,%player);
		ixApplyKickback(%player, 70, 20);
	}
	%client.targetLock = 0;
	deleteobject(%newObj);
}

ItemImageData EMPGrenadeLauncherImage { shapeFile = "mortargun"; mountPoint = 0; mountRotation = { 0,2.25, 0 }; weaponType = 0; ammoType = EMPGrenadeAmmo; projectileType = EMPGrenadeShell; accuFire = false; reloadTime = 0.45; fireTime = 1.5; lightType = 3; lightRadius = 6; lightTime = 1.7; lightColor = { 0.15, 0.15, 1.0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = Bliomp; }; 

ItemData EMPGrenadeLauncher { description = "EMP Grenade Launcher"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "sensorjamerpack"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = EMPGrenadeLauncherImage; price = 300; showWeaponBar = true; }; 

ItemData SniperAmmo { description = "Sniper Bullets"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; 

ItemImageData MortarImage { shapeFile = "mortargun"; mountPoint = 0; weaponType = 0; ammoType = MortarAmmo; projectileType = MortarShell; accuFire = false; reloadTime = 0.4; fireTime = 2.1; lightType = 3; lightRadius = 9; lightTime = 1; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundFireMortar; sfxActivate = SoundPickUpWeapon; sfxReload = SoundMortarReload; sfxReady = SoundMortarIdle; }; 

ItemData Mortar { description = "Mortar"; className = "Weapon"; shapeFile = "mortargun"; hudIcon = "mortar"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = MortarImage; price = 350; showWeaponBar = true; }; 

ItemData SilencerAmmo { description = "Magnum Bullets"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 5; }; 

ItemImageData SilencerImage { shapeFile = "energygun"; mountPoint = 0; weaponType = 0; ammoType = SilencerAmmo; projectileType = SilencerBullet; accuFire = true; reloadTime = 0.0; fireTime = 0.5; lightType = 3; lightRadius = 4; lightTime = 0.4; lightColor = { 1, 1, 1 }; sfxFire = SoundFireMortar; }; 

ItemData Silencer { description = "Magnum"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "targetlaser"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = SilencerImage; price = 150; showWeaponBar = true; }; 

ItemData TranqAmmo { description = "Poison Darts"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 3; }; 

ItemImageData TranqGunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = TranqAmmo; projectileType = TranqDart; accuFire = true; reloadTime = 1.75; fireTime = 0; lightType = 3; lightRadius = 6; lightTime = 2; lightColor = { 0.1, 1.0, 0.1 }; sfxFire = ricochet3; sfxActivate = SoundPickUpWeapon; }; 

ItemData TranqGun { description = "Dart Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "blaster"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = TranqGunImage; price = 250; showWeaponBar = true; }; 

ItemData RailAmmo { description = "Railgun Bolts"; className = "Ammo"; heading = "xAmmunition"; shapeFile = "ammo1"; shadowDetailMask = 4; price = 3; }; 

ItemImageData RailgunImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = RailAmmo; projectileType = RailRound; accuFire = true; reloadTime = 0.5; fireTime = 1.3; lightType = 3; lightRadius = 15; lightTime = 3.5; lightColor = { 0.1, 0.1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxActivate = SoundPickUpWeapon; sfxSpinUp = SoundSpinUp; sfxSpinDown = SoundSpinDown; }; 

ItemData Railgun { description = "Railgun"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = RailgunImage; price = 300; showWeaponBar = true; }; 

ItemImageData SniperRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; ammoType = SniperAmmo; accuFire = true; reloadTime = 2.2; projectileType = SniperRound; fireTime = 0; lightType = 3; lightRadius = 5; lightTime = 2; lightColor = { 1.0, 1.0, 1.0 }; sfxFire = ricochet2; sfxActivate = SoundPickUpWeapon; }; 

ItemData SniperRifle { description = "Sniper Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "targetlaser"; heading = "bProjectile Weapons"; shadowDetailMask = 4; imageType = SniperRifleImage; price = 300; showWeaponBar = true; }; 

ItemImageData BlasterImage { shapeFile = "energygun"; mountPoint = 0; weaponType = 0; reloadTime = 0; fireTime = 0.3; minEnergy = 2; maxEnergy = 3; projectileType = BlasterBolt; accuFire = true; sfxFire = SoundFireBlaster; sfxActivate = SoundPickUpWeapon; }; 

ItemData Blaster { heading = "cEnergy Weapons"; description = "Blaster"; className = "Weapon"; shapeFile = "energygun"; hudIcon = "blaster"; shadowDetailMask = 4; imageType = BlasterImage; price = 100; showWeaponBar = true; }; 

ItemImageData EnergyRifleImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 2; projectileType = boltCharge; minEnergy = 3; maxEnergy = 10; reloadTime = 0.2; lightType = 3; lightRadius = 3.5; lightTime = 1; lightColor = { 0.25, 0.25, 1.0 }; sfxActivate = SoundPickUpWeapon; sfxFire = SoundELFIdle; }; 

ItemData EnergyRifle { description = "ELF Gun"; shapeFile = "shotgun"; hudIcon = "energyRifle"; className = "Weapon"; heading = "cEnergy Weapons"; shadowDetailMask = 4; imageType = EnergyRifleImage; showWeaponBar = true; price = 200; }; 

ItemImageData WaveGunImage { shapeFile = "shotgun"; mountPoint = 0; weaponType = 3; minEnergy = 50; maxEnergy = 54; projectileType = Shock; accuFire = true; reloadTime = 0.7; fireTime = 0.4; sfxFire = SoundPlasmaTurretFire; sfxActivate = SoundPickUpWeapon; }; 

ItemData WaveGun { description = "Shockwave Cannon"; className = "Weapon"; shapeFile = "shotgun"; hudIcon = "disk"; heading = "cEnergy Weapons"; shadowDetailMask = 4; imageType = WaveGunImage; price = 250; showWeaponBar = true; }; 

ItemImageData FlamerImage { shapeFile = "grenadel"; mountPoint = 0; mountRotation = { 0,3.14, 0 }; weaponType = 0; reloadTime = 0.11; fireTime = 0.11; minEnergy = 3; projectileType = FlamerBolt; maxEnergy = 5; accuFire = false; sfxFire = SoundJetHeavy; sfxActivate = SoundPickUpWeapon; }; 

ItemData Flamer { heading = "cEnergy Weapons"; description = "Flame Thrower"; className = "Weapon"; shapeFile = "grenadel"; hudIcon = "plasma"; shadowDetailMask = 4; imageType = FlamerImage; price = 300; showWeaponBar = true; }; 

ItemImageData LaserRifleImage { shapeFile = "sniper"; mountPoint = 0; weaponType = 0; projectileType = SniperLaser; accuFire = true; reloadTime = 0.45; fireTime = 0.5; minEnergy = 10; maxEnergy = 70; lightType = 3; lightRadius = 2.8; lightTime = 0.9; lightColor = { 1.0, 0.0, 0.0 }; sfxFire = SoundFireLaser; sfxActivate = SoundPickUpWeapon; }; 

ItemData LaserRifle { description = "Laser Rifle"; className = "Weapon"; shapeFile = "sniper"; hudIcon = "sniper"; heading = "cEnergy Weapons"; shadowDetailMask = 4; imageType = LaserRifleImage; price = 350; showWeaponBar = true; }; 

function LaserRifle::onUse(%player,%item) { if(Player::getMountedItem(%player,$BackpackSlot) == EnergyPack) Weapon::onUse(%player,%item); else Client::sendMessage(Player::getClient(%player),0, "Must have an Energy Pack to use Laser Rifle."); } 

ItemImageData FixitImage { shapeFile = "repairgun"; mountPoint = 0; weaponType = 2; projectileType = RepairBolt; minEnergy = 5; maxEnergy = 15; lightType = 3; lightRadius = 3; lightTime = 2.7; lightColor = { 1.0, 0.1, 0.1 }; sfxFire = SoundRepairItem; sfxActivate = SoundPickUpWeapon; }; 

ItemData Fixit { description = "Engineer Repair Gun"; className = "Tool"; shapeFile = "repairgun"; hudIcon = "targetlaser"; heading = "cEnergy Weapons"; shadowDetailMask = 4; imageType = FixitImage; price = 500; showWeaponBar = false; }; 

ItemData Backpack { description = "Backpack"; showInventory = false; }; 

function Backpack::onUse(%player,%item) {
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
	Player::mountItem(%player,%item,$BackpackSlot);
} else {
	if(%item != OpticPack || Player::getMountedItem(%player, $WeaponSlot) != -1) {
		Player::trigger(%player,$BackpackSlot);
		if(%item == OpticPack || %item == SMRPack) {
			Player::trigger(%player,$BackpackSlot);
			if(%item == OpticPack) {
				GameBase::setRechargeRate(%player,0);
				%player.rejuv = 1;
				schedule("rejuv("@%player@");", 2.5);
			}
		}
	}
}
}

function Extrapack::onUse(%player,%item) { if (Player::getMountedItem(%player,$ExtraSlot) != %item) { Player::mountItem(%player,%item,$ExtraSlot); } else { Player::trigger(%player,$ExtraSlot); } } 

ItemImageData DeployableInvPackImage { shapeFile = "invent_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemImageData CoolLauncherImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData CoolLauncher { description = "Missile Control Station"; shapeFile = "missileturret"; className = "Backpack"; heading = "uGuided Missile System"; imageType = CoolLauncherImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 2000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function CoolLauncher::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function CoolLauncher::onDeploy(%player,%item,%pos) { if (CoolLauncher::deployShape(%player,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ %item]++;  } } 

function CoolLauncher::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,4)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "AirAmmoBasePad") { 
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set,$MineObjectType | $MoveableObjectType | $VehicleObjectType | $StaticObjectType | $ItemObjectType,$los::position,20,20,$TurretBoxMinHeight,0); 
				for(%i=0;%i<%num;%i++) {
					%obj=Group::getObject(%set,%i);
					if(GameBase::getDataName(Group::getObject(%set,%i)) == "AirAmmoBasePad") 
						%num--;
				}
				deleteObject(%set); 
				if(%num == 0) { 
					if (Vector::dot($los::normal,"0 0 1") > 0.94) {
						if(checkDeployArea(%client,$los::position)) { 
			    			%losnormal = $los::normal;
							%lospos = $los::position;
							for(%i = 1.57; %i < 4.71; %i += 3.14) {
								if(GameBase::getLOSInfo(%player, 5.5, "0 0 " @ %i)) {
									Client::sendMessage(%client,0,"Can only deploy in open areas"); 
									return false;
								}
							}
							%prot = GameBase::getRotation(%player);
							GameBase::setRotation(%player, "0 0 " @ (getword(%prot, 2) + 1.57));
							for(%i = 1.57; %i < 4.71; %i += 3.14) {
								if(GameBase::getLOSInfo(%player, 5.5, "0 0 " @ %i)) {
									GameBase::setRotation(%player, %prot);
									Client::sendMessage(%client,0,"Can only deploy in open areas"); 
									return false;
								}
							}
							GameBase::setRotation(%player, %prot);
							%zRot = getWord(%prot, 2);
							if (Vector::dot(%losnormal,"0 0 1") > 0.6) {
								%rot = "0 0 " @ %zRot;
							} else {
								if (Vector::dot(%losnormal,"0 0 -1") > 0.6) {
									%rot = "3.14159 0 " @ %zRot;
								} else {
									%rot = Vector::getRotation(%losnormal);
								}
							}
							%rot = GameBase::getRotation(%player);
							%forward = Vector::getFromRot(%rot, -2.65);  
							%pos = Vector::add(%lospos, %forward);
							%turret = newObject("remoteTurret","Turret",DeployableCoolMortar,true);
							addToSet("MissionCleanup", %turret);
							GameBase::setTeam(%turret,GameBase::getTeam(%player));
							GameBase::setPosition(%turret,%pos);
							GameBase::setRotation(%turret,%rot); 
							Gamebase::setMapName(%turret,"Missile Control Station"); 
							Client::sendMessage(%client,0,"Missile Control Station deployed"); 	
							%inv = newObject("comunit_remote", "StaticShape", "DeployableCoolStation", true);
							addToSet("MissionCleanup", %inv); 
							GameBase::setTeam(%inv,GameBase::getTeam(%player));
							%backward = Vector::neg(Vector::getFromRot(%rot, 2.65));  
							GameBase::setPosition(%inv,Vector::add(%pos, %backward));
							GameBase::setRotation(%inv,%rot);
							Gamebase::setMapName(%inv,"Missile Control Station"); 
							%turret.comstation = %inv;
							%turret.load = "CoolProj";
							%inv.comstation = %turret;
							playSound(SoundPickupBackpack, %lospos); 
							return true; 
						}
					} else Client::sendMessage(%client,0,"Can only deploy on very flat surfaces"); 
				} else Client::sendMessage(%client,0,"Cannot deploy near other objects"); 
			} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} else Client::sendMessage(%client,0,"Deploy position out of range"); 
	} else Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s"); return false; 
} 

ItemImageData PhoenixMImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 1.0; firstPerson = false; }; 

ItemData EmpM { description = "EMP Missile"; shapeFile = "rocket"; className = "Backpack"; heading = "uGuided Missile System"; shadowDetailMask = 4 ; imageType = PhoenixMImage; mass = 2.0; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function EmpM::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

ItemData GasM { description = "Toxin Missile"; shapeFile = "rocket"; className = "Backpack"; heading = "uGuided Missile System"; shadowDetailMask = 4 ; imageType = PhoenixMImage; mass = 2.0; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function GasM::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

ItemData VoM { description = "Vortex Missile"; shapeFile = "rocket"; className = "Backpack"; heading = "uGuided Missile System"; shadowDetailMask = 4 ; imageType = PhoenixMImage; mass = 2.0; elasticity = 0.2; price = 600; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function VoM::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

ItemData PhoenixM { description = "Phoenix Missile"; shapeFile = "rocket"; className = "Backpack"; heading = "uGuided Missile System"; shadowDetailMask = 4 ; imageType = PhoenixMImage; mass = 2.0; elasticity = 0.2; price = 650; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function PhoenixM::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

ItemData ToM { description = "Tomahawk Missile"; shapeFile = "rocket"; className = "Backpack"; heading = "uGuided Missile System"; shadowDetailMask = 4 ; imageType = PhoenixMImage; mass = 2.0; elasticity = 0.2; price = 700; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function ToM::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

ItemData NapM { description = "Napalm Missile"; shapeFile = "rocket"; className = "Backpack"; heading = "uGuided Missile System"; shadowDetailMask = 4 ; imageType = PhoenixMImage; mass = 2.0; elasticity = 0.2; price = 1100; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function NapM::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

ItemData CM { description = "Cluster Bomb"; shapeFile = "rocket"; className = "Backpack"; heading = "uGuided Missile System"; shadowDetailMask = 4 ; imageType = PhoenixMImage; mass = 2.0; elasticity = 0.2; price = 1200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function CM::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

ItemData BooM { description = "HaVoC Missile"; shapeFile = "rocket"; className = "Backpack"; heading = "uGuided Missile System"; shadowDetailMask = 4 ; imageType = PhoenixMImage; mass = 2.0; elasticity = 0.2; price = 2000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function BooM::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 


function AOE::check(%pos, %radius, %type, %object) {
	GameBase::applyRadiusDamage(%type, %pos, %radius, 0.01, -40, %object);
	schedule("AOE::check(\""@%pos@"\","@%radius@","@%type@","@%object@");",1,%object);
}

function Aoe::deployShape(%object, %radius, %type, %dur) {
   %team = GameBase::getTeam(%object);
   if (%team == -1)
      %team = %object.team;
	if($TeamItemCountAOE[%team] < $TeamItemMax[Aoe]) { 
		%camera = newObject("Camera","Turret",DeployableAoe,true);
		addToSet("MissionCleanup", %camera);
		GameBase::setPosition(%camera,GameBase::getPosition(%object));

		GameBase::setTeam(%camera,%team);

		Gamebase::setMapName(%camera,"");
		%data = GameBase::getDataName(%camera);
		$TeamItemCountAOE[%team]++;
		schedule("GameBase::setDamageLevel("@%camera@", 101);",%dur,%camera);
		schedule("$TeamItemCountAOE[" @ %team @ "]--;",%dur-1,%camera);
      %pos = getBoxCenter(%object);
      %pos = getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ (getWord(%pos, 2) + 2);
		schedule("AOE::check(\"" @ %pos @ "\"," @ %radius @ "," @ %type @ "," @ %camera @ ");", 0.75, %camera);			
		return %camera;
	}
	return false;
}

function DeployableInvPack::onUse(%player,%item) {
   if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
      Player::mountItem(%player,%item,$BackpackSlot);
   } else {
      Player::deployItem(%player,%item);
   }
} 

function DeployableInvPack::onDeploy(%player,%item,%pos) { 
   if ( GameBase::getLOSInfo(%player,3) ) {
      %set = newObject("set", SimSet);
   	%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 5.5, 5.5, 2, 0);
   	for(%i = 0; %i < %num; %i++) {
   		%obj = Group::getObject(%set, %i);
   		if( GameBase::getDataName(%obj) == "AmmoStation" || GameBase::getDataName(%obj) == "DeployableAmmoStation" ) {
		    	%client = Player::getClient(%player);
            Client::sendMessage(%client, 0, "Unable to deploy - Too close to another station");
            return;
         }
      }
   }
	if (DeployAnyShape(%player, %item, "StaticShape", "DeployableInvStation", true, 1)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

ItemImageData DeployableAmmoPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 1.0; firstPerson = false; }; 

function DeployableAmmoPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function DeployableAmmoPack::onDeploy(%player,%item,%pos) { 
   if ( GameBase::getLOSInfo(%player,3) ) {
      %set = newObject("set", SimSet);
   	%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 5.5, 5.5, 2, 0);
   	for(%i = 0; %i < %num; %i++) {
   		%obj = Group::getObject(%set, %i);
   		if( GameBase::getDataName(%obj) == "InventoryStation" || GameBase::getDataName(%obj) == "DeployableInvStation" ) {
		    	%client = Player::getClient(%player);
            Client::sendMessage(%client, 0, "Unable to deploy - Too close to another station");
            return;
         }
      }
   }
	if (DeployAnyShape(%player, %item, "StaticShape", "DeployableAmmoStation", true, 1)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

ItemImageData DeployableComPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.12, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 4.5; firstPerson = false; }; 



ItemImageData AirAmmoPadPackImage
{
        shapeFile = "ammopack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        firstPerson = false;
};
ItemData AirAmmoPad
{
        description = "Air Pad";
        shapefile = "ammopack";
        classname = "Backpack";
        heading =  "fDeployables";
        imageType = AirAmmoPadPackImage;
        shadowDetailMask = 4;
        mass = 1.0;
        elasticity = 0.1;
        price = 400;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

ItemImageData PlasImage { shapeFile = "armorpack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, -0.1, 0.15 }; mountRotation = { 0, 3.14159, 0 }; minEnergy = 0; maxEnergy = 0; firstPerson = false; }; 

ItemData Plas { description = "Repair Drone"; shapeFile = "armorpack"; className = "Backpack"; heading = "fDeployables"; shadowDetailMask = 4; imageType = PlasImage; price = 400; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function AirAmmoPad::onUse(%player,%item)
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

function AirAmmoPad::onDeploy(%player,%item,%pos)
{
        if (AirAmmoPad::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function AirAmmoPad::deployshape(%player,%item) {
	GameBase::getLOSInfo(%player,3);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		%playerPos = GameBase::getPosition(%player);
		%flag = $teamFlag[GameBase::getTeam(%player)];
		%flagpos = %flag.originalPosition;
		if(Vector::getDistance(%flagpos, %playerpos) > 10) {
			%set = newObject("set",SimSet); 
			%num = containerBoxFillSet(%set,$MineObjectType | $MoveableObjectType | $VehicleObjectType | $StaticObjectType | $ItemObjectType,%playerPos,30,30,30,0); 
			deleteObject(%set); 
			if(%num != 0) {
		    	Client::sendMessage(%client,0,"Cannot deploy near other objects");
				return false;
			}
			$TeamItemCount[GameBase::getTeam(%player) @ %item]++;
			%camera = newObject("Spy Station","Staticshape",AirAmmoBasePad,true);
			addToSet("MissionCleanup", %camera);
			%rot = GameBase::getRotation(%player);
			GameBase::setTeam(%camera,GameBase::getTeam(%player));
			GameBase::setRotation(%camera,%rot);
			GameBase::setPosition(%camera,GameBase::getPosition(%player));
			Gamebase::setMapName(%camera,"Air Pad");
			Client::sendMessage(%client,0,"Air Pad deployed");
			%inv = newObject("ammounit_remote","StaticShape","DeployableAmmoStation",true);
			addToSet("MissionCleanup", %inv);
			GameBase::setTeam(%inv,GameBase::getTeam(%player));
			GameBase::setRotation(%inv,%rot);
			%pos = GameBase::getPosition(%player);
			%off = Vector::getFromRot(%rot, 0, 0.5);
			%pos = Vector::add(%off, %pos);
			GameBase::setPosition(%inv,%pos);
			Gamebase::setMapName(%inv,"Air Pad");
			playSound(SoundPickupBackpack,$los::position);
			echo("MSG: ",%client," deployed an Air Pad ");
			return true;
		} else
	    	Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
		return false;
	}
}







function Hider::onUse(%player,%item)
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

function Hider::onDeploy(%player,%item,%pos)
{
	if (Hider::deployShape(%player,%item)) 
	{
		Player::decItemCount(%player,%item);
	}
}


function toggleCloak(%this) {
	GameBase::startFadeIn(%this);
   schedule("GameBase::startFadeIn(" @ %this.cloaked @ ");", 2.5, %this);
   schedule("GameBase::startFadeOut(" @ %this.cloaked @ ");", 5, %this);
   schedule("GameBase::startFadeOut(" @ %this @ ");", 7.5, %this);
   schedule("toggleCloak(" @ %this @ ");", 45, %this);
}

function Hider::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			%data = GameBase::getDataName($los::object);
			if ((%obj == "StaticShape" || %obj == "Turret" || %obj == "Sensor") && %data != "doorthreebyfourForceFieldShape" && %data != "doorfourbyeightForceFieldShape" && %data != "TowerSwitch") {
    				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				} else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					} else {
						%rot = Vector::getRotation($los::normal);
					}
				}
				%turret = newObject("","Sensor",DeployableCSensor,true);
	         addToSet("MissionCleanup", %turret);
				GameBase::setTeam(%turret,GameBase::getTeam(%player));
				GameBase::setPosition(%turret,$los::position);
				GameBase::setRotation(%turret,%rot);
				%turret.ownerName = Client::getName(%client); dotog(%player);
				Gamebase::setMapName(%turret,"Cloaking Device");
				Client::sendMessage(%client,0,"Cloaking Device deployed");
				playSound(SoundPickupBackpack,$los::position);
				$TeamItemCount[GameBase::getTeam(%player) @ "Hider"]++;
				echo("MSG: ",%client," ",Client::getName(%client)," deployed a Cloaking Device");
				GameBase::startFadeOut($los::object);
            schedule("toggleCloak(" @ %turret @ ");", 33, %turret);
				schedule("GameBase::startFadeOut("@%turret@");", 6, $los::object);
				%turret.cloaked = $los::object;
				return true;
			} else {
				Client::sendMessage(%client,0,"Cannot cloak this object");
			}
		} else {
			Client::sendMessage(%client,0,"Deploy position out of range");
		}
	} else {																				Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	}
	return false;
}

function DeployablePulseSensor::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",PulseSensorPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}


function DeployableCSensor::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				GameBase::startFadeIn(%this.cloaked);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",Hider," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function DeployableComStation::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",DeployableComPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function DeployableComPack::onUse(%player,%item) {
   if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
      Player::mountItem(%player,%item,$BackpackSlot);
   } else {
      if ( %player.outArea == 1 ) {
         Client::SendMessage(Player::getClient(%player), 0, "Cannot deploy out of bounds.~waccess_denied.wav");
         return; 
      }
      Player::deployItem(%player,%item);
   }
} 

function DeployableComPack::onDeploy(%player,%item,%pos) { 
	%com = DeployAnyShape(%player, %item, "StaticShape", "DeployableComStation", true, 1);
	if(%com) { 
		GameBase::playSequence(%com, 0, "power");
		GameBase::playSequence(%com, 1);
		Player::decItemCount(%player,%item); 
	} 
} 

ItemImageData AmmoPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; firstPerson = false; }; 

ItemData AmmoPack { description = "Ammo Pack"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "dBackpacks"; imageType = AmmoPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 50; hudIcon = "ammopack"; showWeaponBar = true; hiliteOnActive = true; };

ItemImageData EnergyPackImage { shapeFile = "jetPack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; minEnergy = -3; maxEnergy = -5; firstPerson = false; }; 

ItemData EnergyPack { description = "Energy Pack"; shapeFile = "jetPack"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = EnergyPackImage; price = 100; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; }; 

function EnergyPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

function EnergyPack::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); } 

function EnergyPack::onUnmount(%player,%item) { if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) Player::unmountItem(%player,$WeaponSlot); } 

ItemImageData RepairPackImage { shapeFile = "armorPack"; mountPoint = 2; weaponType = 2; minEnergy = 0; maxEnergy = 0; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData RepairPack { description = "Repair Pack"; shapeFile = "armorPack"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = RepairPackImage; price = 100; hudIcon = "repairpack"; showWeaponBar = true; hiliteOnActive = true; lightType = 2; lightRadius = 4; lightTime = 1; lightColor = { 1, 0.1, 0.1 }; }; 

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

ItemImageData ShieldPackImage { shapeFile = "shieldPack"; mountPoint = 2; weaponType = 2; minEnergy = 5; maxEnergy = 10; sfxFire = SoundShieldOn; firstPerson = false; }; 

ItemData ShieldPack { description = "Shield Pack"; shapeFile = "shieldPack"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = ShieldPackImage; price = 175; hudIcon = "shieldpack"; showWeaponBar = true; hiliteOnActive = true; }; 

function ShieldPackImage::onActivate(%player,%imageSlot) {
   Client::sendMessage(Player::getClient(%player), 0, "Shield On");
   %player.shieldStrength = 0.013;
   %rate = Player::getSensorSupression(%player) + 1;
   Player::setSensorSupression(%player, %rate);
}

function ShieldPackImage::onDeactivate(%player,%imageSlot) {
   Player::trigger(%player,$BackpackSlot,false);
   Client::sendMessage(Player::getClient(%player), 0, "Shield Off");
   %player.shieldStrength = 0;
   %rate = Player::getSensorSupression(%player) - 1;
   Player::setSensorSupression(%player, %rate);
} 

ItemImageData SensorJammerPackImage { shapeFile = "sensorjampack"; mountPoint = 2; weaponType = 2; maxEnergy = 7; sfxFire = SoundJammerOn; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData SensorJammerPack { description = "Sensor Jammer Pack"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = SensorJammerPackImage; price = 200; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; }; 

function SensorJammerPackImage::onActivate(%player, %imageSlot) {
   Client::sendMessage(Player::getClient(%player), 0, "Sensor Jammer On");
   %rate = Player::getSensorSupression(%player) + 35;
   Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player, %imageSlot) {
   Client::sendMessage(Player::getClient(%player), 0, "Sensor Jammer Off");
   %rate = Player::getSensorSupression(%player) - 35;
   Player::setSensorSupression(%player,%rate);
   Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData CloakingDeviceImage { shapeFile = "sensorjampack"; mountPoint = 2; weaponType = 2; minEnergy = 5; maxEnergy = 10; sfxFire = SoundJammerOn; mountOffset = { 0, -0.05, 0 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 


function PowerPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == PowerGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function PowerPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::mountItem(%player,PowerGun,$WeaponSlot);
	}
}

function PowerPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == PowerGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	


ItemImageData HeatSinkImage { shapeFile = "jetpack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, -0.1, 0.15 }; mountRotation = { 0, 3.14159, 0 }; minEnergy = -1; maxEnergy = -2; firstPerson = false; }; 

ItemData HeatSink { description = "Heat Sink"; shapeFile = "jetpack"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = HeatSinkImage; price = 200; hudIcon = "targetlaser"; showWeaponBar = true; hiliteOnActive = true; }; 

function HeatSink::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } 

function HeatSink::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); Player::getClient(%player).burnTime = 0; } 

function Plas::onUse(%player,%item) { 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot); 
	} else { 
		Player::deployItem(%player,%item); 
	} 
} 

function Plas::onDeploy(%player,%item,%pos) { 
	if (Plas::deployShape(%player,%item)) { 
		Player::decItemCount(%player,%item); 
		$TeamItemCount[GameBase::getTeam(%player) @ %item]++; 
	} 
} 

function Plas::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
		if (GameBase::getLOSInfo(%player,3)) { 
			%obj = getObjectType($los::object); 
			if (%obj == "SimTerrain" || %obj == "InteriorShape"|| GameBase::getDataName($los::object) == "AirAmmoBasePad") { 
				if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
					if(checkDeployArea(%client,$los::position)) { 

						%rot = GameBase::getRotation(%player);
						%vehicle = newObject("",flier,Dr,true);
						Gamebase::setMapName(%vehicle,%item.description);
						%vehicle.clLastMount = %client;
						addToSet("MissionCleanup", %vehicle);
						%vehicle.fading = "";
						GameBase::setTeam(%vehicle,Client::getTeam(%client));
						GameBase::setRotation(%vehicle,%rot); 
						GameBase::setPosition(%vehicle,$los::position); 
						Client::sendMessage(%client,0,"Repair Drone deployed");
						playSound(SoundPickupBackpack,$los::position); 
						echo("MSG: ",%client," ",Client::getName(%client)," deployed a Repair Drone"); 
						schedule("checkarea("@%client@", "@%vehicle@");", 30, %vehicle);
						doneposs(%clientId);
						Client::setControlObject(%client, %vehicle);
						remoteEval(%client, SetControls, true);
						%client.safet = true;
						return true; 
					}
				} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			 } else { 
			 	Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
			} 
		} else { 
			Client::sendMessage(%client,0,"Deploy position out of range"); 
		} 
	} else 
		Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s"); 
	return false; 
} 

ItemImageData SMRPackImage { shapeFile = "mortargun"; mountPoint = 3; mountOffset = { -0.3, 0.1, 2.1 }; mountRotation = { 0, 0, 0 }; weaponType = 0; ammoType = RocketAmmo; projectileType = StingerMissile; accuFire = true; reloadTime = 3.0; fireTime = 0.0; lightType = 3; lightRadius = 3; lightTime = 1.5; lightColor = { 0.6, 1, 1.0 }; sfxFire = SoundMissileTurretFire; sfxReload = SoundMortarReload; }; 

ItemData SMRPack { description = "Auto Rocket Cannon"; shapeFile = "mortargun"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = SMRPackImage; price = 400; hudIcon = "mortar"; showWeaponBar = true; hiliteOnActive = true; }; 

function SMRPackImage::onActivate(%player,%imageSlot) {  } 
function SMRPackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData PowerPackImage { shapeFile = "mortarammo"; mountPoint = 2; weaponType = 2; minEnergy = -2; maxEnergy = -3; mountOffset = { 0, 0.0, 0.4 }; mountRotation = { 0, 3.14159, 1.57 }; firstPerson = false; lightType = 2; lightRadius = 5; lightTime = 0.6; lightColor = { 0.1, 0.1, 0.7 }; }; 

ItemData PowerPack { description = "Power Core Pack"; shapeFile = "mortarammo"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = PowerPackImage; price = 400; hudIcon = "repairpack"; showWeaponBar = true; hiliteOnActive = true; }; 

ItemImageData TPackImage { shapeFile = "sensorjampack"; weaponType = 2; mountPoint = 2; mountOffset = { 0, -0.1, 0 }; minEnergy = 0; maxEnergy = 0; firstPerson = false; }; 

ItemData TPack { description = "Teleport Pack"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = TPackImage; price = 500; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; }; 

function decrtfield(%player) {
   %player.tfield = 2;
}

function TPack::onUse(%player,%item) { 
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) { 		
		Player::mountItem(%player,%item,$BackpackSlot); 
	} else {
		%clientId = Player::getClient(%player);
		if(!%player.tfield) {
        	if(!GameBase::isAtRest(%player)) {
            Client::sendMessage(%clientId, 0, "Cannot create teleport field while moving.");
            return;
         }
         %player.tfieldpos = GameBase::getPosition(%player);
         %light = newObject("", Item, MedYellow, 1, false, false, false);
    	 	addToSet("MissionCleanup", %light);
         %player.tfieldlight = %light;
         GameBase::setPosition(%light, %player.tfieldpos);
			playSound(ForceFieldOpen, %player.tfieldpos);
         %player.tfield = 1;
         echo(%clientId);
         echo(%player);
         echo(%player.tfield);
         schedule("decrtfield(" @ %player @ ");", 3, %player);
         GameBase::setRechargeRate(%player, 0);
         %player.rejuv = 1;
      } else {
         if(%player.tfield < 2) {
            Client::sendMessage(%clientId, 0, "Teleport Pack recharging.");
            return;
         }
         %player.tfield = 1;
         %delay = Vector::getDistance(GameBase::getPosition(%player), %player.tfieldpos) * 0.01;
         if(%delay > 0.8) {
            Client::sendMessage(%clientId, 0, "Preparing to teleport...");
				%fadeInTime = 1;
				%quarters = ( (%delay - 2.5) / %fadeInTime);
				if ( %quarters % 2 == 1 ) %quarters -= 1;
				for(%i = 0; %i < %quarters; %i++) {
					if ( %i % 2 == 0 ) {
						echo ("fade out @ " @ (%i * %fadeInTime));
						schedule("GameBase::startFadeOut(" @ %player @ ");", (%i * %fadeInTime), %player );
					} else {
						echo ("fade in @ " @ (%i * %fadeInTime));
						schedule("GameBase::startFadeIn(" @ %player @ ");", (%i * %fadeInTime), %player );
					}
				}
				echo ("fade in @ " @ %delay );
				schedule("GameBase::startFadeIn(" @ %player @ ");", %delay, %player);
            schedule("telePlyr(" @ %player @ ");", %delay, %player);
         } else
            telePlyr(%player);
      }
	}
}

function telePlyr(%player) {
   %player.tfield = false;
   schedule("deleteObject(" @ %player.tfieldlight @ ");", 1.25, %player.tfieldlight);
   GameBase::playSound(%player, teleported, 0);
   GameBase::setPosition(%player.tfieldlight, GameBase::getPosition(%player));
   GameBase::setPosition(%player, %player.tfieldpos);
   GameBase::setEnergy(%player, 0);
   rejuv(%player);
}

function TPack::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); } 

function TPack::onUnmount(%player,%item) {  } 



function WatchdogPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function WatchdogPack::onDeploy(%player,%item,%pos)
{
	if (DeployAnyShape(%player, %item, "Turret", "DeployableWatchdog", false, 1)) {
		Player::decItemCount(%player,%item);
	}
}

function DeployableWatchdog::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",WatchdogPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

ItemImageData ElfPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData ElfPack
{
	description = "ELF Turret";
	shapeFile = "camera";
	className = "Backpack";
   heading = "eTurrets";
	imageType = ElfPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ElfPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	} else {
		Player::deployItem(%player,%item);
	}
}
function kmakem(%player, %HologramName) {
	%hID = AI::getId(%HologramName);   
   if (!%hID) return;
	if ( Vector::getDistance( GameBase::getPosition(%player), GameBase::getPosition(%hID) ) > 25 ) {
	   playNextAnim(%hID);
		Player::kill(%hID); 
	}
}
function ElfPack::onDeploy(%player,%item,%pos)
{
	if (DeployTheShape(%player, %item, "DeployableElf", "ELFTurret LELFTurret", 2, false, $TurretBoxMaxLength, $TurretBoxMaxWidth, $TurretBoxMaxHeight, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, "", "ELF")) {
		Player::decItemCount(%player,%item);
	}
}

function DeployableElf::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("GameBase::SetPosition(" @ %this @ ", \"0 0 -10000\");",1.9,%this); 
				schedule("specDel(" @ %this @ ");",2,%this); 
				schedule("ixGivePack(" @ %player @ ",ElfPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function DeployTheShape(%player, %item, %turret, %objects, %flagdist, %flatonly, %MaxLength, %MaxWidth, %MaxHeight, %MinLength, %MinWidth, %MinHeight, %number, %msg) {
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%playerTeam = GameBase::getTeam(%player);
			if(Vector::getDistance($teamFlag[%playerTeam].originalPosition, $los::position) < %flagdist) {
				Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
				return false;
			}
			%obj = getObjectType($los::object);
			if (%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "AirAmmoBasePad") {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
				return false;
			}
			if(!checkDeployArea(%client, $los::position)) return false;
			%set = newObject("set",SimSet); 
			%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 45, 45, 32, 0); 
			%num = CountThes(%set, %num);
			deleteObject(%set); 
			if(%num > 4) {
				Client::sendMessage(%client,0,"Sensor Interference - Too many turrets in the area");
				return false;
			}			
			%set = newObject("set",SimSet); 
			%numinset = containerBoxFillSet(%set, $StaticObjectType, $los::position, %MaxLength, %MaxWidth, %MaxHeight, 0); 
			%num = CountObjects(%set, %turret, %numinset);
			%object = getword(%objects, 0);
			for(%i = 1; %object != -1; %i++) {
				%num = %num + CountObjects(%set, %object, %numinset);
				%object = getword(%objects, %i);
			}
			deleteObject(%set); 
			if(%num < $MaxNumTurretsInBox) { 
				%set = newObject("set",SimSet); 
				%numinset = containerBoxFillSet(%set, $StaticObjectType, $los::position, %MinLength, %MinWidth, %MinHeight, 0); 
				%num = CountObjects(%set, %turret, %numinset);
				%object = getword(%objects, 0);
				for(%i = 1; %object != -1; %i++) {
					%num = %num + CountObjects(%set, %object, %numinset);
					%object = getword(%objects, %i);
				}
				deleteObject(%set); 
				if(%num == 0) {
					%rot = GameBase::getRotation(%player);
					if (%flatonly) {
						if (Vector::dot($los::normal, "0 0 1") <= 0.7) {
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
							return false;
						}
					} else {
						%zRot = getWord(%rot, 2);
						if (Vector::dot($los::normal, "0 0 1") > 0.6) {
							%rot = "0 0 " @ %zRot;
						} else {
							if (Vector::dot($los::normal, "0 0 -1") > 0.6) {
								%rot = "3.14159 0 " @ %zRot;
							} else {
								%rot = Vector::getRotation($los::normal);
							}
						}
					}

               %initialObject = $los::object;
               %initialNormal = $los::normal;
               %initialPosition = $los::position;

               if ( %turret == "DeployablePlasma" || %turret == "DeployableRocket" || %turret == "DeployableMortar" ) {
                  if ( GameBase::getLOSInfo(%player, 2, "1.57 0 0") ) {
   						Client::sendMessage(%client, 0, "Unable to deploy - Not enough space");
      					return false;
                  }
               }

					if(%number != "") {
						%number++;
						%number = " #" @ %number;
					}
					%turret = newObject("", "Turret", %turret, true);
					addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret, %playerTeam);
					GameBase::setRotation(%turret, %rot);
					GameBase::startFadeIn(%turret);
					GameBase::setPosition(%turret, %initialPosition);
					%turret.ownerName = Client::getName(%client); 
					dotog(%player);
					Gamebase::setMapName(%turret, %item.description @ %number @ " " @ %turret.ownerName);
					Client::sendMessage(%client, 0, %item.description @ %number @ " deployed");
					echo("MSG: ",%client," ",%turret.ownerName," deployed ",%item.description,%number); 
					playSound(SoundPickupBackpack,%initialPosition);
					$TeamItemCount[%playerTeam @ %item]++;
					%client.hasDeployed = true;
					doset(%client, %player, %turret);
					return %turret;
				} else
					Client::sendMessage(%client,0,"Frequency Overload - Too close to another " @ %msg @ " Turret"); 
			} else
				Client::sendMessage(%client,0,"Interference from other " @ %msg @ " Turrets in the area");
		} else
			Client::sendMessage(%client,0,"Deploy position out of range");
	} else																						  
	 	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	return false;
}

function DeployAnyShape(%player, %item, %cat, %name, %flatonly, %deployon) {
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%playerTeam = GameBase::getTeam(%player);
			if(Vector::getDistance($teamFlag[%playerTeam].originalPosition, $los::position) < 1) {
				Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
				return false;
			}
			%obj = getObjectType($los::object);
			if(%deployon == 1) {
				if (%obj != "SimTerrain" && %obj != "InteriorShape" && GameBase::getDataName($los::object) != "AirAmmoBasePad") {
					Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
					return false;
				}
			} else if(%deployon == 2) {
				if (%obj != "SimTerrain") {
					Client::sendMessage(%client,0,"Can only deploy on terrain");
					return false;
				}
			}
			if(!checkDeployArea(%client, $los::position)) return false;
			%rot = GameBase::getRotation(%player);
			if (%flatonly) {
				if (Vector::dot($los::normal, "0 0 1") <= 0.7) {
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					return false;
				}
			} else {
				%zRot = getWord(%rot, 2);
				if (Vector::dot($los::normal, "0 0 1") > 0.6) {
					%rot = "0 0 " @ %zRot;
				} else {
					if (Vector::dot($los::normal, "0 0 -1") > 0.6) {
						%rot = "3.14159 0 " @ %zRot;
					} else {
						%rot = Vector::getRotation($los::normal);
					}
				}
			}
			%turret = newObject("", %cat, %name, true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret, %playerTeam);
			GameBase::setRotation(%turret, %rot);
			GameBase::startFadeIn(%turret);
			GameBase::setPosition(%turret, $los::position);
			%turret.ownerName = Client::getName(%client); 
			dotog(%player);
			Gamebase::setMapName(%turret, %item.description);
			Client::sendMessage(%client, 0, %item.description @ " deployed");
			echo("MSG: ",%client," ",%turret.ownerName," deployed ",%item.description); 
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[%playerTeam @ %item]++;
			%client.hasDeployed = true;
			doset(%client, %player, %turret);
			return %turret;
		} else
			Client::sendMessage(%client,0,"Deploy position out of range");
	} else																						  
	 	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	return false;
}

function LELFPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	} else {
		Player::deployItem(%player,%item);
	}
}

function LELFPack::onDeploy(%player,%item,%pos)
{
	if (DeployTheShape(%player, %item, "LELFTurret", "DeployableElf ELFTurret", 3, true, $TurretBoxMaxLength, $TurretBoxMaxWidth, $TurretBoxMaxHeight, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, "", "ELF")) {
		Player::decItemCount(%player,%item);
	}
}

function LELFTurret::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("GameBase::SetPosition(" @ %this @ ", \"0 0 -10000\");",1.9,%this); 
				schedule("specDel(" @ %this @ ");",2,%this); 
				schedule("ixGivePack(" @ %player @ ",LELFPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

ItemImageData TurretPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData TurretPack { description = "Ion Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "eTurrets"; imageType = TurretPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 350; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };

ItemImageData TTurretPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData TTurretPack { description = "Tractor Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "eTurrets"; imageType = TTurretPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 375; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; };


ItemImageData ShockPackImage { shapeFile = "indoorgun"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData ShockPack { description = "EMP Turret"; shapeFile = "indoorgun"; className = "Backpack"; heading = "eTurrets"; imageType = ShockPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 400; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

ItemImageData PlasmaPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};


function makem(%client, %player, %HologramName, %str) {
	%spawnMarker = GameBase::getPosition(%client);
	%rPos = GameBase::getRotation(%client);
	if ( %str < 0.8 ) %o = -1.5; else %o = 1.5;
	%off = Vector::getFromRot(%rPos, %o);
	%HologramPos = Vector::add(%spawnMarker, %off);
	%some = Ai::spawn(%HologramName, Player::getArmor(%client) @ "holo", %HologramPos, %rPos);  
	$Hologram[%HologramName] = GameBase::getTeam(%player);   
	playSound(ForceFieldOpen,%HologramPos); 
	%hID = AI::getId(%HologramName);   
   schedule("kmakem(" @ %player @", \"" @ escapeString(%HologramName) @ "\");", 30);
	%type = Player::getMountedItem(%client,0);   
	Player::setItemCount(%hId, %type, 1);   
	Player::mountItem(%hId, %type, 0);   
	Item::setVelocity(%hId, Item::getVelocity(%player));
	if($killh[%player] == $lastmade[%player]) {
		%na = Client::getName(%client) @ " ";
		if($killh[%player] != %na)
			%HologramName = %na;
		else if($killh[%player] != %na @ " ")
			%HologramName = %na @ " ";
	} else
		$killh[%player] = $lastmade[%player];
	$lastmade[%player] = %HologramName;
}

ItemData PlasmaPack
{
	description = "Flame Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = "eTurrets";
	imageType = PlasmaPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function PlasmaPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)	{
		Player::mountItem(%player,%item,$BackpackSlot);
	} else {
		Player::deployItem(%player,%item);
	}
}

function PlasmaPack::onDeploy(%player,%item,%pos)
{
	if (DeployTheShape(%player, %item, "DeployableMiniPlasma", "", 1.75, true, 42, 42, 17, 12, 12, 12, "", "Flame")) {
		Player::decItemCount(%player,%item);
	}
}

function CountObjects(%set,%name,%num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(%obj) == %name) 
			%count++;
	}
	return %count;
}

function CountThes(%set, %num) 
{
	%count = 0;
	for(%i=0;%i<%num;%i++) 
	{
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)).className == "Turret") 
			%count++;
	}
	return %count;
}

function DeployableMiniPlasma::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",PlasmaPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function rejuv(%player) {
	%player.rejuv = "";
	if(Player::getClient(%player).empTime <= 0 && !%player.tfield)
		GameBase::setRechargeRate(%player,8);
}

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	%team = Client::getTeam(%client);
	for(%i=0;%i<%num;%i++) {
		%obj=Group::getObject(%set,%i);
		if(GameBase::getDataName(Group::getObject(%set,%i)) == "AirAmmoBasePad") 
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


function satcheckDeployArea(%client,%pos)
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
		deleteObject(%set);
		return 1;
	}

	deleteObject(%set);
	return 0;	
		

}


ItemImageData OpticPackImage { shapeFile = "repairgun"; mountPoint = 2; mountOffset = { 0.2, 0.4, 0.45 }; mountRotation = { 0, 0, 0 }; weaponType = 0; projectileType = wiperLaser; accuFire = true; reloadTime = 1; fireTime = 0.0; minEnergy = 1; maxEnergy = 60; lightType = 2; lightRadius = 5; lightTime = 1.4; lightColor = { 1.0, 0.1, 0.1 }; sfxFire = SoundFireLaser; }; 

ItemData OpticPack { description = "Cybernetic Laser"; shapeFile = "repairgun"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = OpticPackImage; price = 500; hudIcon = "sniper"; showWeaponBar = true; hiliteOnActive = true; }; 

function OpticPackImage::onActivate(%player,%imageSlot) { }
function OpticPackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData SuicidePackImage { shapeFile = "magcargo"; mountPoint = 2; mountOffset = { 0, -0.5, -0.3 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData SuicidePack { description = "Demolition Pack"; shapeFile = "magcargo"; className = "Backpack"; heading = "dBackpacks"; imageType = SuicidePackImage; shadowDetailMask = 4; mass = 2.5; elasticity = 0.2; price = 500; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function SuicidePack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function SuicidePack::onUnmount(%player,%item) { } 

function SuicidePack::onDeploy(%player,%item,%pos) { if (SuicidePack::deployShape(%player,%item)) { Player::decItemCount(%player,%item); } } 

function SuicidePack::deployShape(%player,%item) { 
	%client = Player::getClient(%player); 
	if(%client.dpackthrow > getSimTime()) return;
	Player::unmountItem(%player,$BackpackSlot); 
	%obj = newObject("","Mine","Suicidebomb2"); 
	addToSet("MissionCleanup", %obj); 
	GameBase::throw(%obj,%player,3 * %client.throwStrength,false); 
	Client::sendMessage(%client,1,"Demolition Pack will destruct in 20 seconds."); 
	%client.dpackthrow = getSimTime() + 20;
} 

ItemImageData LaptopImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; weaponType = 2; minEnergy = -1; maxEnergy = -1; mass = 0.5; firstPerson = false; }; 

ItemData Laptop { description = "Command Laptop"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = LaptopImage; price = 700; hudIcon = "energypack"; showWeaponBar = true; hiliteOnActive = true; }; function Laptop::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } } function Laptop::onMount(%player,%item) { Player::trigger(%player,$BackpackSlot,true); } function Laptop::onUnmount(%player,%item) { } 


ItemImageData SMR2PackImage { shapeFile = "mortargun"; mountPoint = 3; mountOffset = { -0.27, 0.1, 2.175 }; mountRotation = { 0, -1.57, 0 }; weaponType = 0; projectileType = PimpinMissile; accuFire = true; reloadTime = 3.0; fireTime = 0.0; lightType = 3; lightRadius = 5; lightTime = 2; lightColor = { 1, 1, 1.0 }; sfxFire = explosion3; }; 

ItemData SMR2Pack { description = "Cannon"; shapeFile = "mortargun"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = SMR2PackImage; price = 350; hudIcon = "mortar"; showWeaponBar = false; hiliteOnActive = true; showInventory = false; }; 

function SMR2PackImage::onActivate(%player,%imageSlot) {  } 
function SMR2PackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData SMR3PackImage { shapeFile = "mortargun"; mountPoint = 3; mountOffset = { 0.46, 0.1, 2.175 }; mountRotation = { 0, 1.57, 0 }; weaponType = 0; projectileType = PimpinMissile; accuFire = true; reloadTime = 3.0; fireTime = 0.0; lightType = 3; lightRadius = 5; lightTime = 2; lightColor = { 1.0, 1, 1.0 }; sfxFire = explosion3; }; 

ItemData SMR3Pack { description = "Cannon"; shapeFile = "mortargun"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = SMR3PackImage; price = 350; hudIcon = "mortar"; showWeaponBar = false; hiliteOnActive = true; showInventory = false; }; 

function SMR3PackImage::onActivate(%player,%imageSlot) {  } 
function SMR3PackImage::onDeactivate(%player,%imageSlot) { Player::trigger(%player,$BackpackSlot,false); } 

ItemImageData PulseSensorPackImage { shapeFile = "radar_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; 

ItemData PulseSensorPack { description = "Pulse Sensor"; shapeFile = "radar_small"; className = "Backpack"; heading = "gSensors"; imageType = PulseSensorPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 50; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 


ItemImageData MotionSensorPackImage { shapeFile = "sensor_small"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; 

ItemData MotionSensorPack { description = "Motion Sensor"; shapeFile = "sensor_small"; className = "Backpack"; heading = "gSensors"; imageType = MotionSensorPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 100; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function MotionSensorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function MotionSensorPack::onDeploy(%player,%item,%pos) { 
	if (DeployAnyShape(%player, %item, "Sensor", "DeployableMotionSensor", false, 1)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function DeployableMotionSensor::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",MotionSensorPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function AmmoPack::onDrop(%player, %item) { 
	if($matchStarted) { 
		%item = Item::onDrop(%player,%item); 
		for(%i = 0; %i < 17 ; %i = %i +1) { 
			%numPack = 0; 
			%ammoItem = $AmmoPackItems[%i]; 
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem]; 
			%pCount = Player::getItemCount(%player, %ammoItem); 
			if(%pCount > %maxnum) { 
				%numPack = %pCount - %maxnum; 
				Player::decItemCount(%player, %ammoItem, %numPack); 
			} 
			if(%i == 0) { 
				%item.BulletAmmo = %numPack; 
			} else if(%i == 1) { 
				%item.PlasmaAmmo = %numPack; 
			} else if(%i == 2) { 
				%item.DiscAmmo = %numPack; 
			} else if(%i == 3) { 
				%item.GrenadeAmmo = %numPack; 
			} else if(%i == 4) { 
				%item.Grenade = %numPack; 
			} else if(%i == 5) { 
				%item.MortarAmmo = %numPack; 
			} else if(%i == 6) { 
				%item.RocketAmmo = %numPack; 
			} else if(%i == 7) { 
				%item.SniperAmmo = %numPack; 
			} else if(%i == 8) { 
				%item.RailAmmo = %numPack; 
			} else if(%i == 9) { 
				%item.SilencerAmmo = %numPack; 
			} else if(%i == 10) { 
				%item.TranqAmmo = %numPack; 
			} else if(%i == 11) { 
				%item.Beacon = %numPack; 
			} else if(%i == 12) { 
				%item.HDiscAmmo = %numPack; 
			} else if(%i == 13) { 
				%item.EMPGrenadeAmmo = %numPack; 
			} else if(%i == 14) { 
				%item.RepairKit = %numPack; 
			} else if(%i == 15) { 
				%item.ShotgunShells = %numPack; 
			} else if(%i == 16) {  
				%item.MineAmmo = %numPack; 
			} 
		} 
	} 
} 

$lll[0] = "RealTargetingLaser";
$lll[1] = "TractorBeam";
$lll[2] = "Smoker";
$lll[3] = "PSmoker";				
$lll[4] = "Flagger";
$lll[5] = "Scouter";
$lll[6] = "Anti";
$lll[7] = "Bee";
$lll[8] = "Grapple";
$lll[9] = "EMPMine";
$lll[10] = "GASMine";
$lll[11] = "Flare";
$numSpecials = 12;

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
	for(%i = 0; %i < 17 ; %i = %i +1) { 
		%ammoItem = $AmmoPackItems[%i]; 
		if(%i == 0) { 
			%numAdd = %item.BulletAmmo; 
		} else if(%i == 1) { 
			%numAdd = %item.PlasmaAmmo; 
		} else if(%i == 2) { 
			%numAdd = %item.DiscAmmo; 
		} else if(%i == 3) { 
			%numAdd = %item.GrenadeAmmo; 
		} else if(%i == 4) { 
			%numAdd = %item.Grenade; 
		} else if(%i == 5) { 
			%numAdd = %item.MortarAmmo; 
		} else if(%i == 6) { 
			%numAdd = %item.RocketAmmo; 
		} else if(%i == 7) { 
			%numAdd = %item.SniperAmmo; 
		} else if(%i == 8) { 
			%numAdd = %item.RailAmmo; 
		} else if(%i == 9) { 
			%numAdd = %item.SilencerAmmo; 
		} else if(%i == 10) { 
			%numAdd = %item.TranqAmmo; 		 
		} else if(%i == 11) { 
			%numAdd = %item.Beacon; 
		} else if(%i == 12) { 
			%numAdd = %item.HDiscAmmo; 
		} else if(%i == 13) { 
			%numAdd = %item.EMPGrenadeAmmo; 
		} else if(%i == 14) { 
			%numAdd = %item.RepairKit; 
		} else if(%i == 15) { 
			%numAdd = %item.ShotgunShells; 
		} else if(%i == 16) { 
			%numAdd = %item.MineAmmo; 
		} 
		Player::incItemCount(%player, %ammoItem, %numAdd); 
	} 
} 

ItemData CloakingDevice { description = "Cloaking Pack"; shapeFile = "sensorjampack"; className = "Backpack"; heading = "dBackpacks"; shadowDetailMask = 4; imageType = CloakingDeviceimage; price = 800; hudIcon = "sensorjamerpack"; showWeaponBar = true; hiliteOnActive = true; }; 

function CloakingDeviceImage::onActivate(%player,%imageSlot) {
   GameBase::startFadeout(%player);
   Client::sendMessage(Player::getClient(%player),0,"Cloaking Device On");
   %rate = Player::getSensorSupression(%player) + 1;
   Player::setSensorSupression(%player,%rate);
} 

function CloakingDeviceImage::onDeactivate(%player,%imageSlot) {
   GameBase::startFadein(%player);
   Client::sendMessage(Player::getClient(%player),0,"Cloaking Device Off");
   %rate = Player::getSensorSupression(%player) - 1;
   Player::setSensorSupression(%player, %rate);
   Player::trigger(%player,$BackpackSlot,false);
} 

function fillAmmoPack(%client) { 
	%player = Client::getOwnedObject(%client);
	%team = Client::getTeam(%client); 
	%station = %player.Station; 
	%stationName = GameBase::getDataName(%station); 
	%armor = Player::getArmor(%player);
	for(%i = 0; %i < 17 ; %i = %i +1) { 
		%item = $AmmoPackItems[%i]; 
		%maxnum = $AmmoPackMax[%armor, %item]; 
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%item == "mineammo") 
			if(((%armor == "dmarmor" || %armor == "dmfemale") && !$HaVoC::DMMines) || $Game::missionType == "Arena")
				%maxnum = 0;
		if(%maxnum) { 
			Player::incItemCount(%client,%item,%maxnum);
			%cost = %item.price * %maxnum * -1;
			if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) { 
				%station.Energy += %cost; 
				if(%station.Energy < 1) 
					%station.Energy = 0; 
			} else if($TeamEnergy[%team] != "Infinite") { 
				$TeamEnergy[%team] += %cost; 
				%client.teamEnergy += %cost; 
			} 
		} 
	} 
} 

function PulseSensorPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function PulseSensorPack::onDeploy(%player,%item,%pos) { if (Item::deployShape(%player,"Pulse Sensor",DeployablePulseSensor,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ %item]++; } } 

ItemImageData DeployableSensorJamPackImage { shapeFile = "sensor_jammer"; mountPoint = 2; mountOffset = { 0, 0.03, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; 

function DeployableSensorJammer::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",DeployableSensorJammerPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

ItemData DeployableSensorJammerPack { description = "Sensor Jammer"; shapeFile = "sensor_jammer"; className = "Backpack"; heading = "gSensors"; imageType = DeployableSensorJamPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 100; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function DeployableSensorJammerPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function DeployableSensorJammerPack::onDeploy(%player,%item,%pos) { if (Item::deployShape(%player,"Sensor Jammer",DeployableSensorJammer,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ %item]++; } } 


ItemImageData CameraPackImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

function CameraTurret::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",CameraPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

ItemData CameraPack { description = "Camera"; shapeFile = "camera"; className = "Backpack"; heading = "gSensors"; imageType = CameraPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 100; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function CameraPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function CameraPack::onDeploy(%player,%item,%pos) { 
	%team = GameBase::getTeam(%player);
	if (DeployTheShape(%player, %item, "CameraTurret", "", 0, false, 0, 0, 0, 0, 0, 0, $totalNumCameras[%team], "")) { 
		$totalNumCameras[%team]++;
		Player::decItemCount(%player,%item); 
	} 
} 

ItemImageData WatchdogImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData WatchdogPack
{
	description = "Watchdogg";
	shapeFile = "camera";
	className = "Backpack";
	heading = "gSensors";
	imageType = WatchdogImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 400;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};



ItemImageData BAImage { shapeFile = "camera"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; 

ItemData BA { description = "Base Alarm"; shapeFile = "camera"; className = "Backpack"; heading = "gSensors"; imageType = BAImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 500; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function BA::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function BA::onDeploy(%player,%item,%pos) { 
	if (DeployAnyShape(%player, %item, "Turret", "BAlarm", false, 1)) { 
		Player::decItemCount(%player,%item); 
	} 
} 


function TurretPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 


function TurretPack::onDeploy(%player,%item,%pos) { 
	if (DeployTheShape(%player, %item, "DeployableTurret", "", 2, false, $TurretBoxMaxLength, $TurretBoxMaxWidth, $TurretBoxMaxHeight, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, "", "Ion")) {
		Player::decItemCount(%player,%item); 
	} 
} 

function DeployableTurret::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",TurretPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function TTurretPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function TTurretPack::onDeploy(%player,%item,%pos) { 
	if (DeployTheShape(%player, %item, "DeployableTTurret", "", 2, false, $TurretBoxMaxLength, $TurretBoxMaxWidth, $TurretBoxMaxHeight, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, "", "Tractor")) {
		Player::decItemCount(%player,%item); 
	} 
} 

function DeployableTTurret::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",TTurretPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

ItemImageData LaserTurretImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData LaserTurret { description = "Plasma Turret"; shapeFile = "remoteturret"; className = "Backpack"; heading = "eTurrets"; imageType = LaserTurretImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 650; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

ItemImageData LaserPackImage { shapeFile = "indoorgun"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; };  

ItemData LaserPack { description = "Laser Turret"; 
shapeFile = "indoorgun"; 
className = "Backpack"; heading = "eTurrets"; imageType = LaserPackImage; shadowDetailMask = 4; mass = 2.0; elasticity = 0.2; price = 650; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

ItemImageData AAPackImage { shapeFile = "indoorgun"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 3.0; firstPerson = false; }; 

ItemData AAPack { description = "AA Turret"; shapeFile = "indoorgun"; className = "Backpack"; heading = "eTurrets"; imageType = AAPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 650; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function AAPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function AAPack::onDeploy(%player,%item,%pos) { 
	if (DeployAnyShape(%player, %item, "Turret", "DeployableAA", false, 1)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function DeployableAA::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",AAPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function LaserPack::onUse(%player,%item) { 

if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function LaserPack::onDeploy(%player,%item,%pos) { 
	if (LaserPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item); 
} 

function LaserPack::deployShape(%player,%item) { 
%client = Player::getClient(%player); 
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) { 
	if (GameBase::getLOSInfo(%player,3)) { 
		%obj = getObjectType($los::object); 
		if (%obj == "SimTerrain" || %obj == "InteriorShape"|| GameBase::getDataName($los::object) == "AirAmmoBasePad") { 
			%prot = GameBase::getRotation(%player); 
			%zRot = getWord(%prot,2); 
			if (Vector::dot($los::normal,"0 0 1") > 0.6) { 
				%rot = "0 0 " @ %zRot; 
			} else { 
				if (Vector::dot($los::normal,"0 0 -1") > 0.6) { 
					%rot = "3.14159 0 " @ %zRot; 
				} else { 
					%rot = Vector::getRotation($los::normal); 
				} 
			} 
			if(checkDeployArea(%client, $los::position)) { 
   			%set = newObject("set",SimSet); 
   			%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 45, 45, 30, 0); 
   			%num = CountThes(%set, %num);
   			deleteObject(%set); 
   			if(%num > 4) {
   				Client::sendMessage(%client,0,"Sensor Interference - Too many turrets in the area");
   				return false;
   			}
				%set = newObject("set",SimSet); 
				%num = containerBoxFillSet(%set, $StaticObjectType, $los::position, 27, 27, 27, 0);
				%las = 0;
            %las = CountObjects(%set,"DeployableLaser",%num);
				deleteObject(%set);
				if(%las == 0) {
					%camera = newObject("Camera","Turret",DeployableLaser,true); 
					addToSet("MissionCleanup", %camera); 
					GameBase::setTeam(%camera,GameBase::getTeam(%player)); 
					GameBase::setRotation(%camera,%rot); 
					GameBase::setPosition(%camera,$los::position); 
					Gamebase::setMapName(%camera,"Laser Turret #"@ $totalNumCameras++ @ " " @ Client::getName(%client));
					%camera.ownerName = Client::getName(%client); 
					dotog(%player);
					Client::sendMessage(%client,0,"Laser Turret deployed"); 
					playSound(SoundPickupBackpack,$los::position); 
					$TeamItemCount[GameBase::getTeam(%player) @ "LaserPack"]++; 
					return true; 
				} else 
					Client::sendMessage(%client,0,"Interference from other Laser turrets in the area"); 
			} 
		} else { 
			Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
		} 
	} else { 
		Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
} else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
return false; 
} 

function DeployableLaser::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",LaserPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function ShockPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function ShockPack::onDeploy(%player,%item,%pos) { 
	if (DeployTheShape(%player, %item, "DeployableShock", "", 2, false, $TurretBoxMaxLength + 6, $TurretBoxMaxWidth + 6, $TurretBoxMaxHeight + 6, $TurretBoxMinLength + 6, $TurretBoxMinWidth + 6, $TurretBoxMinHeight + 6, "", "EMP")) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function DeployableShock::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",ShockPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function DeployableMortar::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",TargetPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

ItemImageData TargetPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.1, -0.06 }; mountRotation = { 0, 0, 0 }; firstPerson = false; }; 

ItemData TargetPack { description = "Mortar Turret"; shapeFile = "mortar_turret"; className = "Backpack"; heading = "eTurrets"; imageType = TargetPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 800; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function TargetPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function TargetPack::onDeploy(%player,%item,%pos) { 
	%team = GameBase::getTeam(%player);
	if (DeployTheShape(%player, %item, "DeployableMortar", "MortarTurret", 4.2, true, $TurretBoxMaxLength, $TurretBoxMaxWidth, $TurretBoxMaxHeight, $TurretBoxMinLength, $TurretBoxMinWidth, $TurretBoxMinHeight, $totalNumMor[%team], "Mortar")) { 
		$totalNumMor[%team]++;
		Player::decItemCount(%player,%item); 
	} 
} 

function checkarea(%cl, %c) {
	if(Vector::getDistance(getboxcenter(%cl), getboxcenter(%c)) > 200 || GameBase::getControlClient(%c) != %cl) {
		if(GameBase::getControlClient(%c) == %cl)
			Client::sendMessage(%cl,0,"Repair Drone out of range - Connection lost");
		GameBase::setDamageLevel(%c, 10);
	} else
		schedule("checkarea("@%cl@", "@%c@");", 15, %c);
}

function LaserTurret::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function LaserTurret::onDeploy(%player,%item,%pos) { 
	if (DeployTheShape(%player, %item, "DeployablePlasma", "PlasmaTurret", 4.5, true, $TurretBoxMaxLength * 2.3, $TurretBoxMaxWidth * 2.3, $TurretBoxMaxHeight * 2.3, $TurretBoxMinLength * 2.3, $TurretBoxMinWidth * 2.3, $TurretBoxMinHeight * 2.3, "", "Plasma")) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function specDel(%this) {
	Turret::checkOperator(%this);
	deleteObject(%this);
}

function DeployablePlasma::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",LaserTurret," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

function slackarea(%cl, %c) {
	if(Vector::getDistance(getboxcenter(%cl), getboxcenter(%c)) > 270 || GameBase::getControlClient(%c) != %cl) {
		if(GameBase::getControlClient(%c) == %cl)
			Client::sendMessage(%cl,0,"Spy Drone out of range - Connection lost");
		GameBase::setDamageLevel(%c, 10);
	} else
		schedule("slackarea("@%cl@", "@%c@");", 15, %c);
}

ItemImageData RocketPackImage { shapeFile = "remoteturret"; mountPoint = 2; mountOffset = { 0, -0.12, -0.1 }; mountRotation = { 0, 0, 0 }; mass = 3.0; firstPerson = false; }; 

ItemData RocketPack { description = "Rocket Turret"; shapeFile = "missileturret"; className = "Backpack"; heading = "eTurrets"; imageType = RocketPackImage; shadowDetailMask = 4; mass = 3.0; elasticity = 0.2; price = 1000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function RocketPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function RocketPack::onDeploy(%player,%item,%pos) { 
	%team = GameBase::getTeam(%player);
	if (DeployTheShape(%player, %item, "DeployableRocket", "RocketTurret DeployableAA", 4.7, true, $TurretBoxMaxLength * 2, $TurretBoxMaxWidth * 2, $TurretBoxMaxHeight * 2, $TurretBoxMinLength * 4, $TurretBoxMinWidth * 4, $TurretBoxMinHeight * 4, $totalNumTurrets[%team], "Rocket")) { 
		$totalNumTurrets[%team]++;
		Player::decItemCount(%player,%item); 
	} 
} 

function DeployableRocket::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("specDel(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",RocketPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

ItemImageData ForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemImageData LELFPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LELFPack
{
	description = "Large ELF Turret";
	shapeFile = "chainturret";
	className = "Backpack";
   heading = "eTurrets";
	imageType = LELFPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function dotog(%player) {
ixToggleDeploy(%player); schedule("ixToggleDeploy(" @ %player @ ");",2,%player);
}

ItemData ForceFieldPack { description = "Force Field"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "hDefense"; imageType = ForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 700; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function ForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 


function DeployForceShape(%player, %item, %name, %flagdist) {
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%playerTeam = GameBase::getTeam(%player);
			if(Vector::getDistance($teamFlag[%playerTeam].originalPosition, $los::position) < %flagdist) {
				Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
				return false;
			}

         %initialObject = $los::object;
         %initialNormal = $los::normal;
         %initialPosition = $los::position;
         %playerPos = GameBase::getPosition(%player);
         %newPos = getWord(%playerPos, 0) @ " " @ getWord(%playerPos, 1) @ " " @ (getWord(%playerPos, 2) + 0.2);
         GameBase::setPosition(%player, %newPos);
         %bFoundLos = GameBase::getLOSInfo(%player, 4);
         GameBase::setPosition(%player, %playerPos);
         if ( %bFoundLos && $los::normal != %initialNormal ) {
				Client::sendMessage(%client, 0, "Unable to deploy - Not enough space");
				return false;
         }

         if ( GameBase::getLOSInfo(%player, 2, "1.57 0 0") ) {
            Client::sendMessage(%client, 0, "Unable to deploy - Not enough space2");
      		return false;
         }

			%obj = getObjectType(%initialObject);
			if (%obj != "SimTerrain" && %obj != "InteriorShape"|| GameBase::getDataName(%initialObject) == "AirAmmoBasePad") {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
				return false;
			}

			if (Vector::dot(%initialNormal, "0 0 1") <= 0.7) {
				Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
				return false;
			}

			%turret = newObject("", "StaticShape", %name, true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret, %playerTeam);
			GameBase::setRotation( %turret, GameBase::getRotation(%player) );
			GameBase::startFadeIn(%turret);
			GameBase::setPosition(%turret, %initialPosition);
			%turret.ownerName = Client::getName(%client); 
			dotog(%player);
			Gamebase::setMapName(%turret, %item.description);
			Client::sendMessage(%client, 0, %item.description @ " deployed");
			echo("MSG: ",%client," ",%turret.ownerName," deployed ",%item.description); 
			playSound(SoundPickupBackpack,%initialPosition);
			playSound(ForceFieldOpen,%initialPosition);
			$TeamItemCount[%playerTeam @ %item]++;
			%client.hasDeployed = true;
			doset(%client, %player, %turret);
			return %turret;
		} else
			Client::sendMessage(%client,0,"Deploy position out of range");
	} else																						  
	 	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s");
	return false;
}

function ForceFieldPack::onDeploy(%player,%item,%pos) { 
	if (DeployForceShape(%player, %item, "DeployableForceField", 4)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function DeployableForceField::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",ForceFieldPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav"); 
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}


ItemImageData LargeForceFieldPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData LargeForceFieldPack { description = "Large Force Field"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "hDefense"; imageType = LargeForceFieldPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 1400; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function LargeForceFieldPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function LargeForceFieldPack::onDeploy(%player,%item,%pos) { 
	if (DeployForceShape(%player, %item, "LargeForceField", 6.4)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function LargeForceField::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",LargeForceFieldPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}


ItemImageData doorthreebyfourForceFieldPackImage
{
        
        shapeFile = "AmmoPack";
        mountPoint = 2;
		mountPoint = 2; mountOffset = { 0, -0.03, 0 }; 
		mass = 2.5;
        firstPerson = false;
};

ItemData doorthreebyfourForceFieldPack
{
        description = "Force Field Door";
        
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = "hDefense";
        imageType = doorthreebyfourForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorthreebyfourForceFieldPack::onUse(%player,%item)
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

function doorthreebyfourForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (DeployForceShape(%player, %item, "doorthreebyfourForceFieldShape", 0))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorthreebyfourForceFieldShape::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",doorthreebyfourForceFieldPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}

ItemImageData doorfourbyeightForceFieldPackImage
{
        
        shapeFile = "AmmoPack";
        mountPoint = 2;
		mountPoint = 2; mountOffset = { 0, -0.03, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData doorfourbyeightForceFieldPack
{
        description = "Large Force Field Door";
        
        shapeFile = "AmmoPack";
        className = "Backpack";
          heading = "hDefense";
        imageType = doorfourbyeightForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 1000;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function doorfourbyeightForceFieldPack::onUse(%player,%item)
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

function doorfourbyeightForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (DeployForceShape(%player, %item, "doorfourbyeightForceFieldShape", 0))
        {
                Player::decItemCount(%player,%item);
        }
}

function doorfourbyeightForceFieldShape::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",doorfourbyeightForceFieldPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}



function HoloPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 
function HoloPack::onDeploy(%player,%item,%pos) { 
	if (HoloPack::deployShape(%player,%item)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

function HoloPack::deployShape(%player,%item) { %client = Player::getClient(%player); if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[holopack]) { if (GameBase::getLOSInfo(%player,3)) { %obj = getObjectType($los::object); if (Vector::dot($los::normal,"0 0 1") > 0.7) { if(checkDeployArea(%client,$los::position)) { 

if(Vector::getDistance($teamFlag[GameBase::getTeam(%player)].originalPosition, $los::position) < 1) {
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
	
	} } else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); } else Client::sendMessage(%client,0,"Deploy position out of range"); } else Client::sendMessage(%client,0,"Deployable item limit reached for " @ %item.description @ "s"); return false; } 


ItemImageData SpringPackImage { shapeFile = "AmmoPack"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

function DeployableSpring::packUp(%this, %pos, %client, %player) { 
	%ownerName = %this.ownerName; 
	if(%ownerName != "") { 
		%name = Client::getName(%client); 
		if(%ownerName == %name || %client.isSuperAdmin || getClientByName(%ownerName) == 0) { 
			if(%this.packingup) return;
			if(!GameBase::getDamageLevel(%this)) { 
				%this.packingup = true;
				%player.isDeploying = true; 
				GameBase::setSequenceDirection(%this,1,0); 
				%player.deployPosition = %pos; 
				playSound(ForceFieldClose,%pos);
				schedule("deleteObject(" @ %this @ ");",1.9,%this); 
				schedule("ixGivePack(" @ %player @ ",SpringPack," @ Client::getTeam(%client) @ ");",2.0,%player); 
			} else 
				Client::sendMessage(%client, 0,"This "@ GameBase::getDataName(%this).description @" is damaged, it won't pack up.~waccess_denied.wav");  
		} else 
			Client::sendMessage(%client, 0, "Only " @ %ownerName @ " can pack up this item.~waccess_denied.wav"); 
	} 
}


ItemData SpringPack { description = "Springboard"; shapeFile = "AmmoPack"; className = "Backpack"; heading = "fDeployables"; imageType = SpringPackImage; shadowDetailMask = 4; mass = 1.0; elasticity = 0.2; price = 700; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; function SpringPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function SpringPack::onDeploy(%player,%item,%pos) { 
	if (DeployAnyShape(%player, %item, "StaticShape", "DeployableSpring", true, 1)) { 
		Player::decItemCount(%player,%item); 
	} 
} 

ItemData DeployableComPack { description = "Command Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "fDeployables"; shadowDetailMask = 4 ; imageType = DeployableComPackImage; mass = 4.0; elasticity = 0.2; price = 900; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 


ItemImageData HiderImage
{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData Hider
{
	description = "Cloaking Device";
	shapeFile = "sensor_small";
	className = "Backpack";
	heading = "fDeployables";
	imageType = HiderImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemImageData TeleportPackImage { shapeFile = "flagstand"; mountPoint = 2; mountOffset = { 0, 0, 0.1 }; mountRotation = { 1.57, 0, 0 }; firstPerson = false; }; ItemData TeleportPack { description = "Teleport Pad"; shapeFile = "enerpad"; className = "Backpack"; heading = "fDeployables"; imageType = TeleportPackImage; shadowDetailMask = 4; mass = 5.0; elasticity = 0.2; price = 3200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 


ItemData DeployableAmmoPack { description = "Ammo Station"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "fDeployables"; shadowDetailMask = 4; imageType = DeployableAmmoPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteAmmoEnergy; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

ItemData DeployableInvPack { description = "Inventory Station"; shapeFile = "invent_remote"; className = "Backpack"; heading = "fDeployables"; shadowDetailMask = 4 ; imageType = DeployableInvPackImage; mass = 2.0; elasticity = 0.2; price = $RemoteInvEnergy + 200; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 


function TeleportPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function TeleportPack::onDeploy(%player,%item,%pos) { if (TeleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) { Player::decItemCount(%player,%item); $TeamItemCount[GameBase::getTeam(%player) @ %item]++; } } 

function TeleportPack::deployShape(%player,%name,%shape,%item) { 
	%client = Player::getClient(%player); 
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[TeleportPack]) { 
	if (GameBase::getLOSInfo(%player,3)) { 
		%obj = getObjectType($los::object); 
		if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "AirAmmoBasePad") { 

			if(Vector::getDistance($teamFlag[GameBase::getTeam(%player)].originalPosition, $los::position) < 4) {
				Client::sendMessage(%client,0,"You are too close to your flag~waccess_denied.wav");
				return false;
			}

			if (Vector::dot($los::normal,"0 0 1") > 0.7) { 
				if(checkDeployArea(%client,$los::position)) { 
					%pad = newObject("Teleport Pad","StaticShape",%shape,true); 
					%beam = newObject("","StaticShape",ElectricalBeamBig,true); 
					%t = newObject("","StaticShape",Tele,true); 
					addToSet("MissionCleanup", %pad); 	
					addToSet("MissionCleanup", %beam); 
					addToSet("MissionCleanup", %t); 
					%team = GameBase::getTeam(%player);
					Gamebase::setMapName(%pad, %name); 
					Gamebase::setMapName(%beam, "Teleport Pad"); 
					GameBase::setTeam(%pad, %team); 
					GameBase::setTeam(%beam, %team);
					GameBase::setTeam(%t, %team);
					%pos = Vector::add($los::position,"0 0 -0.41"); 
					GameBase::setRotation(%pad,GameBase::getRotation(%player)); 
					GameBase::setPosition(%pad,%pos); 
					%pos = Vector::add($los::position,"0 0 0.3"); 
					GameBase::setPosition(%beam,%pos); 
					GameBase::startFadein(%beam);
					GameBase::startFadein(%t); 
					GameBase::setPosition(%t,%pos); 
					Client::sendMessage(%client,0,%item.description @ " deployed"); 
					%pad.disabled = false; 
					playSound(SoundPickupBackpack,$los::position); 
					%pad.t = %t;
					%pad.b = %beam; 
					%t.p = %pad;
					return true; 
				} 
			} else Client::sendMessage(%client,0,"Can only deploy on flat surfaces"); 
		} else Client::sendMessage(%client,0,"Can only deploy on terrain or buildings"); 
	} else Client::sendMessage(%client,0,"Deploy position out of range"); 
} else Client::sendMessage(%client,0,"Deployable item limit reached for " @ %name @ "s"); return false; } 

ItemImageData MechPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 
ItemData MechPack { description = "Interceptor Pack"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "jMiscellany"; imageType = MechPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 1100; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 
function MechPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function MechPack::onDeploy(%player,%item,%pos) { 
	if (DeployAnyShape(%player, "JetVehicle", "flier", "Jet", true, 2)) { 
		Player::decItemCount(%player,%item); 
	}
} 

ItemImageData DetPackImage { shapeFile = "ammounit_remote"; mountPoint = 2; mountOffset = { 0, -0.03, 0 }; mass = 2.5; firstPerson = false; }; 

ItemData DetPack { description = "HAPC Pack"; shapeFile = "ammounit_remote"; className = "Backpack"; heading = "jMiscellany"; imageType = DetPackImage; shadowDetailMask = 4; mass = 1.5; elasticity = 0.2; price = 2000; hudIcon = "deployable"; showWeaponBar = true; hiliteOnActive = true; }; 

function DetPack::onUse(%player,%item) { if (Player::getMountedItem(%player,$BackpackSlot) != %item) { Player::mountItem(%player,%item,$BackpackSlot); } else { Player::deployItem(%player,%item); } } 

function DetPack::onDeploy(%player,%item,%pos) { 
	if (DeployAnyShape(%player, "HAPCVehicle", "flier", HAPC, true, 2)) { 
		Player::decItemCount(%player,%item); 
	}
} 

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape" || GameBase::getDataName($los::object) == "AirAmmoBasePad") {
				if (Vector::dot($los::normal,"0 0 1") > 0.7) {
					if(checkDeployArea(%client,$los::position)) {
						%sensor = newObject("","Sensor",%shape,true);
 	        	   	addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::startFadein(%sensor); 
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
	 	Client::sendMessage(%client,0,"Deployable item limit reached for " @ %name @ "s");
	return false;
}

ItemData RepairPatch { description = "Repair Patch"; className = "Repair"; shapeFile = "armorPatch"; heading = "jMiscellany"; shadowDetailMask = 4; price = 2; }; 

function RepairPatch::onCollision(%this,%object) { if (getObjectType(%object) == "Player") { if(GameBase::getDamageLevel(%object)) { GameBase::repairDamage(%object,0.125); %c = Player::getClient(%object); 
if(%c.poisonTime > 0) %c.poisonTime = -10; %item = Item::getItemData(%this); Item::playPickupSound(%this); Item::respawn(%this); } } } 

function RepairPatch::onUse(%player,%item) { Player::decItemCount(%player,%item); GameBase::repairDamage(%player,0.1); } 

function remoteGiveAll(%clientId) { } 

$vm[CM] = CProj;

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

function Mission::reinitdata() { $TeamItemCount[0 @ DeployableAmmoPack] = 0; $TeamItemCount[0 @ DeployableInvPack] = 0; $TeamItemCount[0 @ TurretPack] = 0; $TeamItemCount[0 @ CameraPack] = 0; $TeamItemCount[0 @ DeployableSensorJammerPack] = 0; $TeamItemCount[0 @ PulseSensorPack] = 0; $TeamItemCount[0 @ MotionSensorPack] = 0; $TeamItemCount[0 @ ScoutVehicle] = 0; $TeamItemCount[0 @ LAPCVehicle] = 0; $TeamItemCount[0 @ HAPCVehicle] = 0; $TeamItemCount[0 @ Beacon] = 0; $TeamItemCount[0 @ MineAmmo] = 0; $TeamItemCount[1 @ DeployableAmmoPack] = 0; $TeamItemCount[1 @ DeployableInvPack] = 0; $TeamItemCount[1 @ TurretPack] = 0; $TeamItemCount[1 @ CameraPack] = 0; $TeamItemCount[1 @ DeployableSensorJammerPack] = 0; $TeamItemCount[1 @ PulseSensorPack] = 0; $TeamItemCount[1 @ MotionSensorPack] = 0; $TeamItemCount[1 @ ScoutVehicle] = 0; $TeamItemCount[1 @ LAPCVehicle] = 0; $TeamItemCount[1 @ HAPCVehicle] = 0; $TeamItemCount[1 @ Beacon] = 0; $TeamItemCount[1 @ MineAmmo] = 0; $TeamItemCount[2 @ DeployableAmmoPack] = 0; $TeamItemCount[2 @ DeployableInvPack] = 0; $TeamItemCount[2 @ TurretPack] = 0; $TeamItemCount[2 @ CameraPack] = 0; $TeamItemCount[2 @ DeployableSensorJammerPack] = 0; $TeamItemCount[2 @ PulseSensorPack] = 0; $TeamItemCount[2 @ MotionSensorPack] = 0; $TeamItemCount[2 @ ScoutVehicle] = 0; $TeamItemCount[2 @ LAPCVehicle] = 0; $TeamItemCount[2 @ HAPCVehicle] = 0; $TeamItemCount[2 @ Beacon] = 0; $TeamItemCount[2 @ MineAmmo] = 0; $TeamItemCount[3 @ DeployableAmmoPack] = 0; $TeamItemCount[3 @ DeployableInvPack] = 0; $TeamItemCount[3 @ TurretPack] = 0; $TeamItemCount[3 @ CameraPack] = 0; $TeamItemCount[3 @ DeployableSensorJammerPack]= 0; $TeamItemCount[3 @ PulseSensorPack] = 0; $TeamItemCount[3 @ MotionSensorPack] = 0; $TeamItemCount[3 @ ScoutVehicle] = 0; $TeamItemCount[3 @ LAPCVehicle] = 0; $TeamItemCount[3 @ HAPCVehicle] = 0; $TeamItemCount[3 @ Beacon] = 0; $TeamItemCount[3 @ MineAmmo] = 0; $TeamItemCount[4 @ DeployableAmmoPack] = 0; $TeamItemCount[4 @ DeployableInvPack] = 0; $TeamItemCount[4 @ TurretPack] = 0; $TeamItemCount[4 @ CameraPack] = 0; $TeamItemCount[4 @ DeployableSensorJammerPack]= 0; $TeamItemCount[4 @ PulseSensorPack] = 0; $TeamItemCount[4 @ MotionSensorPack] = 0; $TeamItemCount[4 @ ScoutVehicle] = 0; $TeamItemCount[4 @ LAPCVehicle] = 0; $TeamItemCount[4 @ HAPCVehicle] = 0; $TeamItemCount[4 @ Beacon] = 0; $TeamItemCount[4 @ MineAmmo] = 0; $TeamItemCount[5 @ DeployableAmmoPack] = 0; $TeamItemCount[5 @ DeployableInvPack] = 0; $TeamItemCount[5 @ TurretPack] = 0; $TeamItemCount[5 @ CameraPack] = 0; $TeamItemCount[5 @ DeployableSensorJammerPack]= 0; $TeamItemCount[5 @ PulseSensorPack] = 0; $TeamItemCount[5 @ MotionSensorPack] = 0; $TeamItemCount[5 @ ScoutVehicle] = 0; $TeamItemCount[5 @ LAPCVehicle] = 0; $TeamItemCount[5 @ HAPCVehicle] = 0; $TeamItemCount[5 @ Beacon] = 0; $TeamItemCount[5 @ MineAmmo] = 0; $TeamItemCount[6 @ DeployableAmmoPack] = 0; $TeamItemCount[6 @ DeployableInvPack] = 0; $TeamItemCount[6 @ TurretPack] = 0; $TeamItemCount[6 @ CameraPack] = 0; $TeamItemCount[6 @ DeployableSensorJammerPack]= 0; $TeamItemCount[6 @ PulseSensorPack] = 0; $TeamItemCount[6 @ MotionSensorPack] = 0; $TeamItemCount[6 @ ScoutVehicle] = 0; $TeamItemCount[6 @ LAPCVehicle] = 0; $TeamItemCount[6 @ HAPCVehicle] = 0; $TeamItemCount[6 @ Beacon] = 0; $TeamItemCount[6 @ MineAmmo] = 0; $TeamItemCount[7 @ DeployableAmmoPack] = 0; $TeamItemCount[7 @ DeployableInvPack] = 0; $TeamItemCount[7 @ TurretPack] = 0; $TeamItemCount[7 @ CameraPack] = 0; $TeamItemCount[7 @ DeployableSensorJammerPack]= 0; $TeamItemCount[7 @ PulseSensorPack] = 0; $TeamItemCount[7 @ MotionSensorPack] = 0; $TeamItemCount[7 @ ScoutVehicle] = 0; $TeamItemCount[7 @ LAPCVehicle] = 0; $TeamItemCount[7 @ HAPCVehicle] = 0; $TeamItemCount[7 @ Beacon] = 0; $TeamItemCount[7 @ MineAmmo] = 0; $TeamItemCount[0 @ RocketPack] = 0; $TeamItemCount[1 @ RocketPack] = 0; $TeamItemCount[2 @ RocketPack] = 0; $TeamItemCount[3 @ RocketPack] = 0; $TeamItemCount[4 @ RocketPack] = 0; $TeamItemCount[5 @ RocketPack] = 0; $TeamItemCount[6 @ RocketPack] = 0; $TeamItemCount[7 @ RocketPack] = 0; $TeamItemCount[0 @ ForceFieldPack] = 0; $TeamItemCount[1 @ ForceFieldPack] = 0; $TeamItemCount[2 @ ForceFieldPack] = 0; $TeamItemCount[3 @ ForceFieldPack] = 0; $TeamItemCount[4 @ ForceFieldPack] = 0; $TeamItemCount[5 @ ForceFieldPack] = 0; $TeamItemCount[6 @ ForceFieldPack] = 0; $TeamItemCount[7 @ ForceFieldPack] = 0; $TeamItemCount[0 @ LaserPack] = 0; $TeamItemCount[1 @ LaserPack] = 0; $TeamItemCount[2 @ LaserPack] = 0; $TeamItemCount[3 @ LaserPack] = 0; $TeamItemCount[4 @ LaserPack] = 0; $TeamItemCount[5 @ LaserPack] = 0; $TeamItemCount[6 @ LaserPack] = 0; $TeamItemCount[7 @ LaserPack] = 0; $TeamItemCount[0 @ DeployableComPack] = 0; $TeamItemCount[1 @ DeployableComPack] = 0; $TeamItemCount[2 @ DeployableComPack] = 0; $TeamItemCount[3 @ DeployableComPack] = 0; $TeamItemCount[4 @ DeployableComPack] = 0; $TeamItemCount[5 @ DeployableComPack] = 0; $TeamItemCount[6 @ DeployableComPack] = 0; $TeamItemCount[7 @ DeployableComPack] = 0; $TeamItemCount[0 @ LaserTurret] = 0; $TeamItemCount[1 @ LaserTurret] = 0; $TeamItemCount[2 @ LaserTurret] = 0; $TeamItemCount[3 @ LaserTurret] = 0; $TeamItemCount[4 @ LaserTurret] = 0; $TeamItemCount[5 @ LaserTurret] = 0; $TeamItemCount[6 @ LaserTurret] = 0; $TeamItemCount[7 @ LaserTurret] = 0; $TeamItemCount[0 @ TeleportPack] = 0; $TeamItemCount[1 @ TeleportPack] = 0; $TeamItemCount[2 @ TeleportPack] = 0; $TeamItemCount[3 @ TeleportPack] = 0; $TeamItemCount[4 @ TeleportPack] = 0; $TeamItemCount[5 @ TeleportPack] = 0; $TeamItemCount[6 @ TeleportPack] = 0; $TeamItemCount[7 @ TeleportPack] = 0; $TeamItemCount[0 @ WraithVehicle] = 0; $TeamItemCount[1 @ WraithVehicle] = 0; $TeamItemCount[2 @ WraithVehicle] = 0; $TeamItemCount[3 @ WraithVehicle] = 0; $TeamItemCount[4 @ WraithVehicle] = 0; $TeamItemCount[5 @ WraithVehicle] = 0; $TeamItemCount[6 @ WraithVehicle] = 0; $TeamItemCount[7 @ WraithVehicle] = 0; $TeamItemCount[0 @ JetVehicle] = 0; $TeamItemCount[1 @ JetVehicle] = 0; $TeamItemCount[2 @ JetVehicle] = 0; $TeamItemCount[3 @ JetVehicle] = 0; $TeamItemCount[4 @ JetVehicle] = 0; $TeamItemCount[5 @ JetVehicle] = 0; $TeamItemCount[6 @ JetVehicle] = 0; $TeamItemCount[7 @ JetVehicle] = 0; $TeamItemCount[0 @ TripwirePack] = 0; $TeamItemCount[1 @ TripwirePack] = 0; $TeamItemCount[2 @ TripwirePack] = 0; $TeamItemCount[3 @ TripwirePack] = 0; $TeamItemCount[4 @ TripwirePack] = 0; $TeamItemCount[5 @ TripwirePack] = 0; $TeamItemCount[6 @ TripwirePack] = 0; $TeamItemCount[7 @ TripwirePack] = 0; $TeamItemCount[0 @ ShockPack] = 0; $TeamItemCount[1 @ ShockPack] = 0; $TeamItemCount[2 @ ShockPack] = 0; $TeamItemCount[3 @ ShockPack] = 0; $TeamItemCount[4 @ ShockPack] = 0; $TeamItemCount[5 @ ShockPack] = 0; $TeamItemCount[6 @ ShockPack] = 0; $TeamItemCount[7 @ ShockPack] = 0; $TeamItemCount[0 @ PlatformPack] = 0; $TeamItemCount[1 @ PlatformPack] = 0; $TeamItemCount[2 @ PlatformPack] = 0; $TeamItemCount[3 @ PlatformPack] = 0; $TeamItemCount[4 @ PlatformPack] = 0; $TeamItemCount[5 @ PlatformPack] = 0; $TeamItemCount[6 @ PlatformPack] = 0; $TeamItemCount[7 @ PlatformPack] = 0; $TeamItemCount[0 @ TreePack] = 0; $TeamItemCount[1 @ TreePack] = 0; $TeamItemCount[2 @ TreePack] = 0; $TeamItemCount[3 @ TreePack] = 0; $TeamItemCount[4 @ TreePack] = 0; $TeamItemCount[5 @ TreePack] = 0; $TeamItemCount[6 @ TreePack] = 0; $TeamItemCount[7 @ TreePack] = 0; $TeamItemCount[0 @ LargeForceFieldPack] = 0; $TeamItemCount[1 @ LargeForceFieldPack] = 0; $TeamItemCount[2 @ LargeForceFieldPack] = 0; $TeamItemCount[3 @ LargeForceFieldPack] = 0; $TeamItemCount[4 @ LargeForceFieldPack] = 0; $TeamItemCount[5 @ LargeForceFieldPack] = 0; $TeamItemCount[6 @ LargeForceFieldPack] = 0; $TeamItemCount[7 @ LargeForceFieldPack] = 0; 

	$TeamItemCount[0 @ WatchdogPack] = 0;
	$TeamItemCount[1 @ WatchdogPack] = 0;
	$TeamItemCount[2 @ WatchdogPack] = 0;
	$TeamItemCount[3 @ WatchdogPack] = 0;
	$TeamItemCount[4 @ WatchdogPack] = 0;
	$TeamItemCount[5 @ WatchdogPack] = 0;
	$TeamItemCount[6 @ WatchdogPack] = 0;
	$TeamItemCount[7 @ WatchdogPack] = 0;
	
	$TeamItemCount[0 @ Hider] = 0;
	$TeamItemCount[1 @ Hider] = 0;
	$TeamItemCount[2 @ Hider] = 0;
	$TeamItemCount[3 @ Hider] = 0;
	$TeamItemCount[4 @ Hider] = 0;
	$TeamItemCount[5 @ Hider] = 0;
	$TeamItemCount[6 @ Hider] = 0;
	$TeamItemCount[7 @ Hider] = 0;


for(%i = 0; %i < 8; %i++)
{
		$TeamItemCountAOE[%i] = 0;
}

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ CoolLauncher] = 0;
}



for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ WatchdogPack] = 0;
}

for(%i = 0; %i < 8; %i++)
{
                $TeamItemCount[%i @ AirAmmoPad] = 0;

}

	$TeamItemCount[0 @ LELFPack] = 0;
	$TeamItemCount[1 @ LELFPack] = 0;
	$TeamItemCount[2 @ LELFPack] = 0;
	$TeamItemCount[3 @ LELFPack] = 0;
	$TeamItemCount[4 @ LELFPack] = 0;
	$TeamItemCount[5 @ LELFPack] = 0;
	$TeamItemCount[6 @ LELFPack] = 0;
	$TeamItemCount[7 @ LELFPack] = 0;

	$TeamItemCount[0 @ PlasmaPack] = 0;
	$TeamItemCount[1 @ PlasmaPack] = 0;
	$TeamItemCount[2 @ PlasmaPack] = 0;
	$TeamItemCount[3 @ PlasmaPack] = 0;
	$TeamItemCount[4 @ PlasmaPack] = 0;
	$TeamItemCount[5 @ PlasmaPack] = 0;
	$TeamItemCount[6 @ PlasmaPack] = 0;
	$TeamItemCount[7 @ PlasmaPack] = 0;




for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ doorthreebyfourForceFieldPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}

for(%i = 0; %i < 8; %i++)
{
        $TeamItemCount[%i @ doorfourbyeightForceFieldPack] = 0;
        $TeamEnergy[%i] = $DefaultTeamEnergy;
}

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ ElfPack] = 0;
}

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ PlasmaPack] = 0;
}

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ Hider] = 0;
}

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ Plas] = 0;
}

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ BA] = 0;
}

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ TTurretPack] = 0;
}

for(%i = 0; %i < 8; %i++)
{
		$TeamItemCount[%i @ AAPack] = 0;
}

for(%i = 0; %i < 8; %i++)
{
		$totalNumAlarms[%i] = 0;
}

for(%i = 0; %i < 8; %i++) { $totalNumLas[%i] = 0; }

for(%i = 0; %i < 8; %i++) { $totalNumVul[%i] = 0; }

for(%i = 0; %i < 8; %i++) { $totalNumRail[%i] = 0; }

for(%i = 0; %i < 8; %i++) { $totalNumMor[%i] = 0; }

for(%i = 0; %i < 8; %i++) { $totalNumSats[%i] = 0; }

for(%i = 0; %i < 8; %i++) { $totalNumCameras[%i] = 0; }

for(%i = 0; %i < 8; %i++) { $totalNumTurrets[%i] = 0; }

for(%i = 0; %i < 8; %i++) {
	for(%ii = 0; %ii < Group::objectCount($TeleportPads[%i]); %ii++) {
		%pad = Group::getObject($TeleportPads[%i],%ii);
		Group::iterateRecursive(%pad.teleFXSet, TeleportPad::deleteBeams);
		schedule("deleteObject(" @ %pad.teleFXSet @ ");",0.1);
		schedule("deleteObject(" @ %pad.b @ ");", 0.3);
		schedule("deleteObject(" @ %pad.t @ ");", 0.3);
	}
	$TeamItemCount[%i @ TeleportPack] = 0;
	$TeleportPads[%i] = newObject("set",SimSet);
	$telePadNum[%i] = 0;
}

$TeamItemCount[0 @ TargetPack] = 0; $TeamItemCount[1 @ TargetPack] = 0; $TeamItemCount[2 @ TargetPack] = 0; $TeamItemCount[3 @ TargetPack] = 0; $TeamItemCount[4 @ TargetPack] = 0; $TeamItemCount[5 @ TargetPack] = 0; $TeamItemCount[6 @ TargetPack] = 0; $TeamItemCount[7 @ TargetPack] = 0; $TeamItemCount[0 @ SpringPack] = 0; $TeamItemCount[1 @ SpringPack] = 0; $TeamItemCount[2 @ SpringPack] = 0; $TeamItemCount[3 @ SpringPack] = 0; $TeamItemCount[4 @ SpringPack] = 0; $TeamItemCount[5 @ SpringPack] = 0; $TeamItemCount[6 @ SpringPack] = 0; $TeamItemCount[7 @ SpringPack] = 0; $TeamItemCount[0 @ holopack] = 0; $TeamItemCount[1 @ holopack] = 0; $TeamItemCount[2 @ holopack] = 0; $TeamItemCount[3 @ holopack] = 0; $TeamItemCount[4 @ holopack] = 0; $TeamItemCount[5 @ holopack] = 0; $TeamItemCount[6 @ holopack] = 0; $TeamItemCount[7 @ holopack] = 0; $TeamItemCount[0 @ SatchelPack] = 0; $TeamItemCount[1 @ SatchelPack] = 0; $TeamItemCount[2 @ SatchelPack] = 0; $TeamItemCount[3 @ SatchelPack] = 0; $TeamItemCount[4 @ SatchelPack] = 0; $TeamItemCount[5 @ SatchelPack] = 0; $TeamItemCount[6 @ SatchelPack] = 0; $TeamItemCount[7 @ SatchelPack] = 0; $TeamItemCount[0 @ BigInvPack] = 0; $TeamItemCount[1 @ BigInvPack] = 0; $TeamItemCount[2 @ BigInvPack] = 0; $TeamItemCount[3 @ BigInvPack] = 0; $TeamItemCount[4 @ BigInvPack] = 0; $TeamItemCount[5 @ BigInvPack] = 0; $TeamItemCount[6 @ BigInvPack] = 0; $TeamItemCount[7 @ BigInvPack] = 0; for(%i = -1; %i < 8 ; %i++) $TeamEnergy[%i] = $DefaultTeamEnergy; } 




