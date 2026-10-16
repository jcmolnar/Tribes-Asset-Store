//----------------------------------------------------------------------------

// Change this if you add new items
// and don't want to mess up everyone's
// favorites - just put in something
// that uniquely describes your new stuff.

$ItemFavoritesKey = "Apocalypse_Beta";

//----------------------------------------------------------------------------

$ItemPopTime = 30;

$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;
//Extra mount slots not used by defualt tribes
$ExtraSlotA=4;
$ExtraSlotB=5;
$ExtraSlotC=6;
$ExtraSlotD=7;

//Inventory Catagories
$InvCatArmors = "aArmor";
$InvCatVehicles = "aVehicle";
$InvCatWeapons[Sai] = "bSaiyan Attacks";
$invCatWeapons[Pro] = "bProtoManX Equipment";
$InvCatWeapons[All] = "bWeapons";
$InvCatWeapons[Ene] = "bEnergy Weapons";
$InvCatWeapons[Bea] = "cBeam Weapons";
$InvCatWeapons[Rif] = "dRifle Weapons";
$InvCatWeapons[Gat] = "eGatling Weapons";
$InvCatWeapons[Spr] = "fSpread Weapons";
$InvCatWeapons[Lau] = "gLauncher Weapons";
$InvCatWeapons[Lob] = "hLobbing Weapons";
$InvCatTools = "iTools";
$InvCatModule[Gre] = "jGrenade Modules";
$InvCatModule[Mor] = "kMortar Modules";
$InvCatModule[For] = "lForce Modules";
$InvCatModule[Apo] = "mApocalypse Modules";
$InvCatModule[Fla] = "nFlame Thower Parts";
$InvCatModule[Sho] = "oShotgun Chokes";
$InvCatPacks = "pBackpacks";
$InvCatModule[Ele] = "qElemental Cores";
$InvCatTurrets = "rTurrets";
$InvCatDeployables = "sDeployables";
$InvCatMisc = "tMiscellany";
$InvCatAmmo = "uAmmunition";

$AutoUse[ChargeGun] = True;

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

//----------------------------------------------------------------------------
// Server side methods
// The client side inventory dialogs call buyItem, sellItem,
// useItem and dropItem through remoteEvals.

function teamEnergyBuySell(%player,%cost)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	// IF - Cost positive selling	 IF - Cost Negitive buying
	%station = %player.Station;
	%stationName = GameBase::getDataName(%station); 
	if(%stationName == DeployableInvStation || %stationName == DeployableAmmoStation) {
		%station.Energy += %cost;			//Remote StationEnergy
		if(%station.Energy < 1)
			%station.Energy = 0;
	}
	else if($TeamEnergy[%team] != "Infinite") {
		$TeamEnergy[%team] += %cost;	//Total TeamEnergy
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
			for (%i = 0; %i < %max; %i++) {
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
	%armor = $ArmorName[Player::getArmor(%player)];
	%pack = Player::getMountedItem(%client,$BackpackSlot);
	if ((%pack == ammopack || %pack == ultimapack) && $AmmoPackMax[%item] != "") {
		if(%item == Beacon)
			%extraAmmo = $APBeaconMax[%armor];
		else if(%item == Grenade)
			%extraAmmo = $APGrenadeMax[%armor];
		else
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
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats)) {
		printMessage(%player,%item);
		if (%item.className == Armor) {
			// Assign armor by requested type & gender
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client,%item) == 0)	{
				teamEnergyBuySell(%player,$ArmorName[%armor].price);
				if($ArmorName[%armor] == UltimaArmor) {
					$WeapMode[%client,GrenadeLauncher] = 1;
					$WeapMode[%client,Mortar] = 1;
					$WeapMode[%client,RangerMortar] = 1;
					$WeapMode[%client,Shotgun] = 1;
					$WeapMode[%client,ApocGun] = 1;
					$WeapMode[%client,RepulseGun] = 1;
					$WeapMode[%client,FlameThower] = 1;
				}
				if(checkResources(%player,%item,1)) {
					teamEnergyBuySell(%player,$ArmorName[%buyarmor].price * -1);
					Player::setArmor(%client,%buyarmor);
					checkMax(%client,%buyarmor);
					armorChange(%client);
					Player::setItemCount(%client, $ArmorName[%armor], 0);
					Player::setItemCount(%client, %item, 1);
					%pack = Player::getMountedItem(%client,$BackpackSlot);
					if(%pack == ammopack || %pack == ultimapack)
						fillAmmoPack(%client);
					if(%client.invo)
						setupShoppingList(%client,%client.invo,%client.ListType); // armor based list
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

			// Only one backpack per armor.
			%pack = Player::getMountedItem(%client,$BackpackSlot);
			if (%pack != -1) {
				if(%pack == ammopack || %pack == ultimapack)
					checkMax(%client,%armor);
				else if(%pack == EnergyPack && %item != PerGenPack) {
					if(Player::getItemCount(%client,"ChainLaser") > 0) {
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Pulse Laser");
						remoteSellItem(%client,$ItemNTN[ChainLaser]);
					}
					if(Player::getItemCount(%client,"BeamCannon") > 0) {
						Client::sendMessage(%client,0,"Sold - Auto Selling Beam Cannon");
						remoteSellItem(%client,$ItemNTN[BeamCannon]);
					}
					if(Player::getItemCount(%client,"LaserRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
						remoteSellItem(%client,$ItemNTN[LaserRifle]);
					}
				}
				else if(%pack == PerGenPack && %item != EnergyPack) {
					if(Player::getItemCount(%client,"ChainLaser") > 0) {
						Client::sendMessage(%client,0,"Sold Personal Generator - Auto Selling Pulse Laser");
						remoteSellItem(%client,$ItemNTN[ChainLaser]);
					}
					if(Player::getItemCount(%client,"BeamCannon") > 0) {
						Client::sendMessage(%client,0,"Sold Personal Generator - Auto Selling Beam Cannon");
						remoteSellItem(%client,$ItemNTN[BeamCannon]);
					}
					if(Player::getItemCount(%client,"LaserRifle") > 0) {
						Client::sendMessage(%client,0,"Sold Personal Generator - Auto Selling Laser Rifle");
						remoteSellItem(%client,$ItemNTN[LaserRifle]);
					}
				}
				else if(%pack == ConverterPack) {
					if(Player::getItemCount(%client,"ShockGun") > 0) {
						Client::sendMessage(%client,0,"Sold Damage Converter - Auto Selling Shock Gun");
						remoteSellItem(%client,$ItemNTN[ShockGun]);
					}
				}
				teamEnergyBuySell(%player,%pack.price);
				Player::decItemCount(%client,%pack);
			}
			if (checkResources(%player,%item,1) || $testCheats) {
				if($Apocalypse::Module) {
					if(%item == ElementPack && Player::getItemCount(%client,"ElemFirMod") == 0 && Player::getItemCount(%client,"ElemWinMod") == 0 && Player::getItemCount(%client,"ElemEarMod") == 0 && Player::getItemCount(%client,"ElemEleMod") == 0) {
						buyItem(%client,"ElemFirMod");
						Client::sendMessage(%client,0,"Bought Elemental Barrier - Auto buying Fire Core");
					}
				}
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);
				if(%item == ammopack || %item == ultimapack)
					fillAmmoPack(%client);
				return 1;
			}
			else if(%pack != -1) {
				if($Apocalypse::Module) {
					if(%item == ElementPack && Player::getItemCount(%client,"ElemFirMod") == 0 && Player::getItemCount(%client,"ElemWinMod") == 0 && Player::getItemCount(%client,"ElemEarMod") == 0 && Player::getItemCount(%client,"ElemEleMod") == 0) {
						buyItem(%client,"ElemFirMod");
						Client::sendMessage(%client,0,"Bought Elemental Barrier - Auto buying Fire Core");
					}
				}
				teamEnergyBuySell(%player,%pack.price * -1);
				Player::incItemCount(%client,%pack);
				Player::useItem(%client,%pack);
				if(%pack == ammopack || %pack == ultimapack)
					fillAmmoPack(%client);
			}
		}
		else if(%item.className == Weapon) {
			if(checkResources(%player,%item,1)) {
				if(Player::getItemCount(%client,"EnergyPack") == 0 && Player::getItemCount(%client,"PerGenPack") == 0) {
					if(%item == LaserRifle) {
						buyItem(%client,"EnergyPack");
						Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
					}
					if(%item == BeamCannon) {
						buyItem(%client,"EnergyPack");
						Client::sendMessage(%client,0,"Bought Beam Cannon - Auto buying Energy Pack");
					}
					if(%item == ChainLaser) {
						buyItem(%client,"EnergyPack");
						Client::sendMessage(%client,0,"Bought Pulse Laser - Auto buying Energy Pack");
					}
				}
				if(%item == ShockGun && Player::getItemCount(%client,"ConverterPack") == 0) {
					buyItem(%client,"ConverterPack");
					Client::sendMessage(%client,0,"Bought Shock Gun - Auto buying Damage Converter");
				}
				if($Apocalypse::Module) {
					if(%item == Shotgun && Player::getItemCount(%client,"ShotFulMod") == 0 && Player::getItemCount(%client,"ShotImpMod") == 0 && Player::getItemCount(%client,"ShotModMod") == 0 && Player::getItemCount(%client,"ShotSktMod") == 0) {
						buyItem(%client,"ShotFulMod");
						Client::sendMessage(%client,0,"Bought Shotgun - Auto buying Full Choke");
					}
					if(%item == FlameThrower && Player::getItemCount(%client,"FlamSpaMod") == 0) {
						buyItem(%client,"FlamSpaMod");
						Client::sendMessage(%client,0,"Bought Flame Thrower - Auto buying Ignitor");
					}
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
		else if (%item.className == Module) {
			// Only one module for a weapon.
			if($ModuleWep[%item] == GrenadeLauncher) {
				if(Player::getItemCount(%client,GrenEmpMod) > 0) {
					teamEnergyBuySell(%player,GrenEmpMod);
					Player::decItemCount(%client,GrenEmpMod);
				}
				else if(Player::getItemCount(%client,GrenNapMod) > 0) {
					teamEnergyBuySell(%player,GrenNapMod);
					Player::decItemCount(%client,GrenNapMod);
				}
			}
			else if($ModuleWep[%item] == Shotgun) {
				if(Player::getItemCount(%client,ShotFulMod) > 0) {
					teamEnergyBuySell(%player,ShotFulMod);
					Player::decItemCount(%client,ShotFulMod);
				}
				else if(Player::getItemCount(%client,ShotImpMod) > 0) {
					teamEnergyBuySell(%player,ShotImpMod);
					Player::decItemCount(%client,ShotImpMod);
				}
				else if(Player::getItemCount(%client,ShotModMod) > 0) {
					teamEnergyBuySell(%player,ShotModMod);
					Player::decItemCount(%client,ShotModMod);
				}
				else if(Player::getItemCount(%client,ShotSktMod) > 0) {
					teamEnergyBuySell(%player,ShotSktMod);
					Player::decItemCount(%client,ShotSktMod);
				}
			}
			else if($ModuleWep[%item] == ElementPack) {
				if(Player::getItemCount(%client,ElemFirMod) > 0) {
					teamEnergyBuySell(%player,ElemFirMod);
					Player::decItemCount(%client,ElemFirMod);
				}
				else if(Player::getItemCount(%client,ElemWinMod) > 0) {
					teamEnergyBuySell(%player,ElemWinMod);
					Player::decItemCount(%client,ElemWinMod);
				}
				else if(Player::getItemCount(%client,ElemEarMod) > 0) {
					teamEnergyBuySell(%player,ElemEarMod);
					Player::decItemCount(%client,ElemEarMod);
				}
				else if(Player::getItemCount(%client,ElemEleMod) > 0) {
					teamEnergyBuySell(%player,ElemEleMod);
					Player::decItemCount(%client,ElemEleMod);
				}
			}
			if (checkResources(%player,%item,1) || $testCheats) {
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client,%item);
				Player::useItem(%client,%item);
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
	%player = client::getownedobject(%client);

	if(!%player.Station)
	{
		Client::sendMessage(%client,1,"You must be at an Inventory Station to buy items.~waccess_denied.wav");
		return;
	}

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
			else if(%item == ammopack || %item == ultimapack)
				checkMax(%client,Player::getArmor(%client));
			else if($TeamItemMax[%item] != "") {
				if(%item.className == Vehicle)
					$TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			else if(%item == PerGenPack) {
				if(Player::getItemCount(%client,"ChainLaser") > 0) {
					Client::sendMessage(%client,0,"Sold Personal Generator - Auto Selling Pulse Laser");
					remoteSellItem(%client,$ItemNTN[ChainLaser]);
				}
				if(Player::getItemCount(%client,"BeamCannon") > 0) {
					Client::sendMessage(%client,0,"Sold Personal Generator - Auto Selling Beam Cannon");
					remoteSellItem(%client,$ItemNTN[BeamCannon]);
				}
				if(Player::getItemCount(%client,"LaserRifle") > 0) {
					Client::sendMessage(%client,0,"Sold Personal Generator - Auto Selling Laser Rifle");
					remoteSellItem(%client,$ItemNTN[LaserRifle]);
				}
			}
			else if(%item == EnergyPack) {
				if(Player::getItemCount(%client,"ChainLaser") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Pulse Laser");
					remoteSellItem(%client,$ItemNTN[ChainLaser]);
				}
				if(Player::getItemCount(%client,"BeamCannon") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Beam Cannon");
					remoteSellItem(%client,$ItemNTN[BeamCannon]);
				}
				if(Player::getItemCount(%client,"LaserRifle") > 0) {
					Client::sendMessage(%client,0,"Sold Energy Pack - Auto Selling Laser Rifle");
					remoteSellItem(%client,$ItemNTN[LaserRifle]);
				}
			}
			else if(%item == ConverterPack) {
				if(Player::getItemCount(%client,"ShockGun") > 0) {
					Client::sendMessage(%client,0,"Sold Damage Converter - Auto Selling Shock Gun");
					remoteSellItem(%client,$ItemNTN[ShockGun]);
				}
			}
			if(%item.className == Module) {
				if($ModuleWep[%item] == GrenadeLauncher)
					$WeapMode[%client,GrenadeLauncher] = 1;
				else if($ModuleWep[%item] == Shotgun && Player::getItemCount(%client,Shotgun) > 0) {
					Client::sendMessage(%client,0,"Cannot sell chokes ~wC_BuySell.wav");
					return;
				}
				else if($ModuleWep[%item] == Mortar) {
					$WeapMode[%client,Mortar] = 1;
					$WeapMode[%client,RangerMortar] = 1;
				}
				else if($ModuleWep[%item] == RepulseGun)
					$WeapMode[%client,RepulseGun] = 1;
				else if($ModuleWep[%item] == ApocGun)
					$WeapMode[%client,ApocGun] = 1;
				else if($ModuleWep[%item] == ElementPack && Player::getItemCount(%client,ElementPack) > 0) {
					Client::sendMessage(%client,0,"Cannot sell elemental cores ~wC_BuySell.wav");
					return;
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


exec("scripts\\nextprevweapons.cs");

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
		if (%ammo == "" || Player::getItemCount(%client,%ammo) > 0 || %weapon == ShockGun)
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
				if(%item == ElementPack)
					Item::giveItem(%player,ElemFirMod,1);
				Player::incItemCount(%player,%item);
				Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item.description);
				printMessage(%player,%item);
				return 1;
			}
		}
		else if(%item.className == Module)
			Player::useItem(%player,%item);
		else {
			// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon) {
				if (Player::getItemClassCount(%player,"Weapon") >= $MaxWeapons[%armor])
					return 0;
				%pack = Player::getMountedItem(%player,$BackpackSlot);
				if(%item == Shotgun)
					Item::giveItem(%player,ShotFulMod,1);
				if(%item == FlameThrower)
					Item::giveItem(%player,FlamSpaMod,1);
				else if(%item == ChainLaser && (%pack != EnergyPack || %pack != PerGenPack))
					return 0;
				else if(%item == BeamCannon && (%pack != EnergyPack || %pack != PerGenPack))
					return 0;
				else if(%item == LaserRifle && (%pack != EnergyPack || %pack != PerGenPack))
					return 0;
				else if(%item == ShockGun && %pack != ConverterPack)
					return 0;
			}
			%extraAmmo = 0 ;
			%armname = $ArmorName[Player::getArmor(%player)];
			%bpack = Player::getMountedItem(%client,$BackpackSlot);
			if ((%bpack == ammopack || %bpack == ultimapack) && $AmmoPackMax[%item] != "") {
				if(%item == Beacon)
					%extraAmmo = $APBeaconMax[%armname];
				else if(%item == Grenade)
					%extraAmmo = $APGrenadeMax[%armname];
				else
					%extraAmmo = $AmmoPackMax[%item];
			}
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
		if(%item.className == "Module")
			return;
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

	lightType = 2;	 // Pulsing
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

	lightType = 2;	 // Pulsing
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

	lightType = 2;	 // Pulsing
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

//Moved into each vehicles own file

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
	if(%player.Station=="" && !$Apocalypse::SlugFest){
		%ammo = %item.imageType.ammoType;
		if (%ammo == "") {
			// Energy weapons dont have ammo types
			Player::mountItem(%player,%item,$WeaponSlot);
			printMessage(%player,%item);
		}
		else {
			if (Player::getItemCount(%player,%ammo) > 0 || %item == ShockGun) {
				Player::mountItem(%player,%item,$WeaponSlot);
				printMessage(%player,%item);
			}
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
	printMessage(%player,%item);
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
// Backpacks
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
			//	los::position
			//	los::normal
			//	los::object
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
		Player::setItemCount(%clientId,Beacon,	200);

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

exec("scripts\\missionreinitdata.cs");
