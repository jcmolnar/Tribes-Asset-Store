//----------------------------------------------------------------------------

$ItemFavoritesKey = "UltraZX_Infinite";  // Change this if you add new items
                         // and don't want to mess up everyone's
                         // favorites - just put in something
                         // that uniquely describes your new stuff.

//----------------------------------------------------------------------------
//================================
// Easy Way For Invetory Headings
//================================
$InvHead[ihArm] = "b¤Armor¤";        
$InvHead[ihWea] = "T¤Weapons¤";
$InvHead[ihBac] = "c¤Backpacks¤";
$InvHead[ihSpl] = "W¤Spells¤";
$InvHead[ihMis] = "e¤Miscellany¤";
$InvHead[ihFFD] = "k¤Deployables¤";
$InvHead[ihDSe] = "D¤Sensor Network¤";
$InvHead[ihTur] = "L¤Turrets¤";
$InvHead[ihRem] = "r¤Remote Units¤";
$InvHead[ihAmo] = "x¤Ammunition¤";
//================================

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
				if(%item == LaserRifle && Player::getItemCount(%client,"EnergyPack") == 0) {
					buyItem(%client,"EnergyPack");
					Client::sendMessage(%client,0,"Bought Laser Rifle - Auto buying Energy Pack");
				}
if(%item == Nuclear && Player::getItemCount(%client,"NuclearShieldPack") == 0)
                        {
                           buyItem(%client,"NuclearShieldPack");
                           Client::sendMessage(%client,0,"Bought Nuclear Emitter - Auto buying Nuclear Emitter Shield");
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

ExplosionData invExp
{
	shapeName = "plasmaex.dts";
	faceCamera = true;
	randomSpin = true;
	hasLight = false;
	lightRange = 4.0;
	timeScale = 0.3;
	colors[0] = { 1.0, 1.0, 1.0 };
	colors[1] = { 1.0, 1.0, 1.0 };
	colors[2] = { 1.0, 1.0, 1.0 };
	radFactors = { 1.0, 1.0, 1.0 };
};
GrenadeData INVNADE
{
	bulletShapeName = "plasmabolt.dts";
	explosionTag = invExp;
	collideWithOwner = true;
	ownerGraceMS = 500;
	collisionRadius = 0.0;
	mass = 0.0;
	elasticity = 0.4;
	damageClass = 1;
	damageValue = -100;
	explosionRadius = 1.8;
	kickBackStrength = 0.0;
	maxLevelFlightDist = 4;
	totalTime = 0.56;
	liveTime = 0.56;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 1.0;
	smokeName = "plasmatrail.dts";
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
			Projectile::spawnProjectile("INVNADE", "0 0 1 0 0 0 0 0 1 " @ %trans, %player, "0 0 -2");
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
	%co1 = Client::getControlObject(%client);
	%co = GameBase::getDataName(%co1);
	if(%co != Scout && %co != MercJet && %co != LAPC && %co != HAPC)
	{
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (%item == -1 || $NextWeapon[%item] == "")
			selectValidWeapon(%client);
		else {
			for (%weapon = $NextWeapon[%item]; %weapon != %item;
					%weapon = $NextWeapon[%weapon]) {
				if (isSelectableWeapon(%client,%weapon)) {
					Player::useItem(%client,%weapon);
					if (Player::getMountedItem(%client,$WeaponSlot) == %weapon ||
						Player::getNextMountedItem(%client,$WeaponSlot) == %weapon)
					bottomPrint(%client,"  "@$WDesc[%weapon]);
					break;
				}
			}
		}
	}
	else
		getNextVWeap(%client);
}

function remotePrevWeapon(%client)
{
	%co1 = Client::getControlObject(%client);
	%co = GameBase::getDataName(%co1);
	if(%co != Scout && %co != MercJet && %co != LAPC && %co != HAPC)
	{
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
					bottomPrint(%client,"  "@$WDesc[%weapon]);
					break;
				}
			}
		}
	}
	else
		getPrevVWeap(%client);
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
   schedule("deleteObject(" @ %item @ ");",15, %item);
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

function Flag::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function Flag::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
}

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

function RaceFlag::onEnabled(%this)
{
   GameBase::setIsTarget(%this,true);
}

function RaceFlag::onDisabled(%this)
{
   GameBase::setIsTarget(%this,false);
}
//----------------------------------------------------------------------------
// Armors
//----------------------------------------------------------------------------

ItemData LightArmor
{
   heading = $InvHead[ihArm];
	description = "Light Suit";
	className = "Armor";
	price = 175;
};

ItemData MediumArmor
{
   heading = $InvHead[ihArm];
	description = "Medium Suit";
	className = "Armor";
	price = 250;
};

ItemData HeavyArmor
{
   heading = $InvHead[ihArm];
	description = "Heavy Suit";
	className = "Armor";
	price = 400;
};

//----------------------------------------------------------------------------
// Vehicles
//----------------------------------------------------------------------------

ItemData ScoutVehicle
{
	description = "Brawler Assault";
	className = "Vehicle";
   heading = "a-=Vehicle=-";
	price = 600;
};

ItemData MercJetVehicle
{
	description = "Mercenary Jet-Bike";
	className = "Vehicle";
   heading = "a-=Vehicle=-";
	price = 625;
};

ItemData LAPCVehicle
{
	description = "Star Destroyer";
	className = "Vehicle";
   heading = "a-=Vehicle=-";
	price = 650;
};

ItemData HAPCVehicle
{
	description = "Hover Tank";
	className = "Vehicle";
   heading = "a-=Vehicle=-";
	price = 875;
};
//----------------------------------------------------------------------------
/////////////ZX
/////////////
////////////
//
//----------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
      mountOffset = { 0, 0, 0 }; 
	mountRotation = { 0, 1.5, 0 }; 

	weaponType = 0; // Spinning
	minEnergy = 0.6;
	maxEnergy = 0.6;
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.0;
	fireTime = 0.075;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireLaser; 
	sfxActivate = SoundShellClick2;
};

ItemData LaserRifle
{
	description = "Laser Gat";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
   //validateShape = true;
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
//----------------------------------------------------------------------------

ItemImageData TaserRifleImage
{
        shapeFile = "sniper";
        mountPoint = 0;

        weaponType = 0; // 2,Sustained
        projectileType = TaserRfLaser;
        accuFire = true;
        minEnergy = 0.6;
        maxEnergy = 0.6;//brightness of beamhere
        reloadTime = 0.08;

        //lightType   = 3;  // Weapon Fire
        //lightRadius = 3;
        //lightTime   = 0.08;
        //lightColor = { 0.4, 0, 0.6 };

        sfxFire     = SoundTaserFire;
        sfxActivate = SoundShellClick2;
        sfxReady = SoundEnergyPackOn;
};

ItemData TaserRifle
{
        description   = "Taser Rifle";
        className     = "Weapon";
        shapeFile     = "sniper";
        hudIcon       = "sniper";
   heading = $InvHead[ihWea];
        shadowDetailMask = 4;
        imageType     = TaserRifleImage;
        price         = 100;
        showWeaponBar = true;
};


//--------------------------------------

ItemImageData FireballAbilityImage
{
	shapeFile = "plasmabolt";
	mountPoint = 0;
	
	weaponType = 0; // Single Shot
	//projectileType = FlamerBolt;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 1;
	minEnergy = 0.2;
	maxEnergy = 1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundDryFire;
	sfxActivate = SoundShellClick2;
	sfxReload = SoundMortarReload;
};

ItemData FireballAbility
{
        description = "Fire Ball";
        className = "Weapon";
        shapeFile = "plasmatrail";
        hudIcon = "deployable";
   heading = $InvHead[ihSpl];
        shadowDetailMask = 4;
        imageType = FireballAbilityImage;
        price = 250;
        showWeaponBar = true;
};

function FireballAbilityImage::onFire(%player, %slot) 
{		
		 	 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %armor = Player::getArmor(%player);
			 %los = GameBase::getLOSInfo(%player,3000);
			 %pos = $los::position;
			 %trans = GameBase::getMuzzleTransform(%player);
		       %vel = Item::getVelocity(%player);
					%fired = (Projectile::spawnProjectile("solarBurst1",%trans,%player,%vel));	%fired.deployer = %client;
					%fired = (Projectile::spawnProjectile("solarBurst2",%trans,%player,%vel));	%fired.deployer = %client;
}
//--------------------------------------
ItemData SmScreenAbilityAmmo
{
        description = "Smoke Implants";
        className = "Ammo";
        shapeFile = "grenammo";
   heading = $InvHead[ihAmo];
        shadowDetailMask = 4;
        price = 5;
};

ItemImageData SmScreenAbilityImage
{
        shapeFile = "breath";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = SmScreenAbilityAmmo;
        projectileType = SmScreen;
        accuFire = true;
        reloadTime = 0.1;
        fireTime = 0;

        //lightType = 3;  // Weapon Fire
        //lightRadius = 3;
        //lightTime = 0.05;
        //lightColor = { 1, 1, 1 };

        sfxFire = SoundJetHeavy;
        sfxActivate = SoundShellClick2;
};

ItemData SmScreenAbility
{
        description = "Smoke Screen";
        className = "Weapon";
        shapeFile = "breath";
        hudIcon = "deployable";
   heading = $InvHead[ihSpl];
        shadowDetailMask = 4;
        imageType = SmScreenAbilityImage;
        price = 23;
        showWeaponBar = true;
};

//--------------------------------------
ItemData ExSmScreenAbilityAmmo
{
        description = "Lair Implants";
        className = "Ammo";
        shapeFile = "grenammo";
   heading = $InvHead[ihAmo];
        shadowDetailMask = 4;
        price = 5;
};

ItemImageData ExSmScreenAbilityImage
{
        shapeFile = "fusionex";
        mountPoint = 0;

        weaponType = 0; // Single Shot
        ammoType = ExSmScreenAbilityAmmo;
        //projectileType = ExSmScreen;
        accuFire = true;
        reloadTime = 2.75;
        fireTime = 0;

        //lightType = 3;  // Weapon Fire
        //lightRadius = 3;
        //lightTime = 0.05;
        //lightColor = { 1, 1, 1 };

        sfxFire = SoundJetHeavy;
        sfxActivate = SoundShellClick2;
};

ItemData ExSmScreenAbility
{
        description = "SplitWaster";
        className = "Weapon";
        shapeFile = "enbolt";
        hudIcon = "deployable";
   heading = $InvHead[ihSpl];
        shadowDetailMask = 4;
        imageType = ExSmScreenAbilityImage;
        price = 23;
        showWeaponBar = true;
};

function ExSmScreenAbilityImage::onFire(%this,%player,%item) 
{
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,ExSmScreenAbilityAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,ExSmScreenAbilityAmmo);

 		%newObj = Projectile::spawnProjectile("NapShell", %trans, %this, %vel);
		schedule("TossFlame(" @ %newObj @ ", " @ %this @ ");", 3);
		schedule("SplitFlame(" @ %newObj @ ", " @ %this @ ");", 2.9);
	}
}

function SplitFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("NapSplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);
	Item::setVelocity(%obj, %vel);
}

function TossFlame(%newobj,%this){

		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 20);

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("NapFire", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);
		Item::setVelocity(%obj, %forceVel);
	//%rnd = (floor(getRandom()*20)/80);
		//schedule("SetMines(" @ %obj @ ", " @ %this @ ");", 2 - %rnd);
		}
	deleteobject(%newObj);
	}
}
//function SetMines(%newobj,%this){
//
//	if (GameBase::getPosition(%newObj)){
//		%Pos = GameBase::getPosition(%newobj); 
//   		%vel = Item::getVelocity(%newobj);
//		%Mine = newObject("","Mine","antipersonelMine");
//		GameBase::setTeam (%Mine,GameBase::getTeam (%this));
// 		addToSet("MissionCleanup", %Mine);
//      	GameBase::throw(%Mine,%this,-1,true);
//		GameBase::setPosition(%Mine, %pos);
//		Item::setVelocity(%Mine, %vel);
//	deleteobject(%newObj);
//	}
//}
//--------------------------------------
ItemData FireScreenAbilityAmmo
{
        description = "FireWall Bombs";
        className = "Ammo";
        shapeFile = "grenammo";
   heading = $InvHead[ihAmo];
        shadowDetailMask = 4;
        price = 5;
};

ItemImageData FireScreenAbilityImage
{
  shapeFile = "plasmabolt";
  mountPoint = 0;

  weaponType = 0; // Single Shot
  ammoType = FireScreenAbilityAmmo;
  projectileType = Firebomb;
  accuFire = false;
  reloadtime = 2.1;
  fireTime = 0.1;
  sfxFire = SoundPlasmaTurretFire;
  sfxReload = SoundDiscReload;
  sfxReady = SoundDiscSpin;
  sfxActivate = SoundShellClick2;
};

ItemData FireScreenAbility
{
        description = "Field Of Fire";
        className = "Weapon";
        shapeFile = "plasmabolt";
        hudIcon = "deployable";
   heading = $InvHead[ihSpl];
        shadowDetailMask = 4;
        imageType = FireScreenAbilityImage;
        price = 23;
        showWeaponBar = true;
};

//---------------------------------

ItemData SpellAbilityAmmo
{
	description = "Clones";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SpellAbilityImage
{
	shapeFile = "breath";
	mountPoint = 0;

	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.1;

	ammoType = SpellAbilityAmmo;
	projectileType = SpellAbilityproj;
	accuFire = true;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };

	//sfxFire = soundwindgust;
	sfxActivate = SoundShellClick2;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData SpellAbility
{
	description = "Clone Spell";
	className = "Weapon";
	shapeFile = "breath";
   //validateShape = true;
	hudIcon = "sniper";
   heading = $InvHead[ihSpl];
	shadowDetailMask = 4;
	imageType = SpellAbilityImage;
	price = 125;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

ItemImageData BlasterImage
{
   shapeFile  = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.05;
	minEnergy = 1;
	maxEnergy = 0.1;

	projectileType = GrBlasterBolt;
	accuFire = true;

	sfxFire = energyExplosion;
	sfxActivate = SoundShellClick2;
};


ItemData Blaster
{
   heading = $InvHead[ihWea];
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "paintgun";
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
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;

	ammoType = BulletAmmo;
	projectileType = ChaingunBullet;
	accuFire = true;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };

	sfxFire = debrissmallexplosion;
	sfxActivate = SoundShellClick2;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData Chaingun
{
	description = "Chaingun";
	className = "Weapon";
	shapeFile = "sniper";
   //validateShape = true;
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------
ItemImageData Chain2Image
{
	shapeFile = "Sniper";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Chain2
{
	description = "Chain2";
	className = "Weapon";
	shapeFile = "Sniper";
	shadowDetailMask = 4;
	imageType = Chain2Image;
	showWeaponBar = false;
};

ItemData VerminatorAmmo
{
	description = "Retaliator Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData VerminatorImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.1;
	//spinDownTime = 0.1;
	fireTime = 0.02;

	ammoType = VerminatorAmmo;
	projectileType = VerminatorBullet;
	accuFire = true;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundShellClick2;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData Verminator
{
	description = "Retaliator";
	className = "Weapon";
	shapeFile = "sniper";
   //validateShape = true;
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = VerminatorImage;
	price = 150;
	showWeaponBar = true;
};

function Verminator::onMount(%player,%item)
{
	Player::mountItem(%player,Chain2,7);
}

function Verminator::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
//----------------------------------------------------------------------------

ItemData LiLPOOmkiAmmo
{
	description = "MayHeM Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData LiLPOOmkiImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.5;
	//spinDownTime = 3;
	fireTime = 0.02;

	ammoType = LiLPOOmkiAmmo;
	projectileType = LiLPOOmkiBullet;
	accuFire = true;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };

	sfxFire = ricochet2;
	sfxActivate = SoundShellClick2;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData LiLPOOmki
{
	description = "IX-MayHeM";
	className = "Weapon";
	shapeFile = "sniper";
   //validateShape = true;
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LiLPOOmkiImage;
	price = 125;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------

ItemData LiLPOOmkiiAmmo
{
	description = "Rail Bolts";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData LiLPOOmkiiImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Spinning
	reloadTime = 0;
	//spinUpTime = 0.5;
	//spinDownTime = 3;
	fireTime = 0.02;

	ammoType = LiLPOOmkiiAmmo;
	projectileType = LiLPOOmkiiBullet;
	accuFire = true;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundShellClick2;
	//sfxSpinUp = SoundSpinUp;
	//sfxSpinDown = SoundSpinDown;
};

ItemData LiLPOOmkii
{
	description = "IX-Railgun";
	className = "Weapon";
	shapeFile = "sniper";
  // validateShape = true;
	hudIcon = "sniper";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = LiLPOOmkiiImage;
	price = 125;
	showWeaponBar = true;
};

//----------------------------------------------------------------------------
//IX-2002Zx
//------------------------------
ItemData IX2002Ammo
{
	description = "IX2002 Bullet";
	className = "Ammo";
	shapeFile = "force";//mortarammo
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData IX2002Image
{
	shapeFile = "sniper";//disc paintgun
	mountPoint = 0;
	//mountOffset = {-0.1,0.1,-0.1};//{0.065, 0.1, -0.1}
	//mountRotation = {0, -1.57, 0}; //-1.57



	weaponType = 0; // 0 singleshot,3 disk, 1 spinning,2 sustained
	ammoType = IX2002Ammo;
	projectileType = IX2002ZXBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.02;
	//spinUpTime = 0;

	sfxFire = ricochet3;
	sfxActivate = SoundShellClick2;
	//sfxReload = SoundDiscReload;
	//sfxReady = SoundMortarTurretTurn;
};

ItemData IX2002
{
	description = "IX-2002";
	className = "Weapon";
	shapeFile = "sniper";// paintgun
	hudIcon = "mortar";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = IX2002Image;//DiscLauncherImage
	price = 2002;
	showWeaponBar = true;
};

//-=-=-=-=-=-=-=-=-=-=-=-
// FEB Coded By:SlipKnot
//-=-=-=-=-=-=-=-=-=-=-=-
ItemData FEBAmmo
{
	description = "FEB Bullet";
	className = "Ammo";
	shapeFile = "force";//mortarammo
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData FEBImage
{
	shapeFile = "sniper";//disc paintgun
	mountPoint = 0;
	mountOffset = { 0 , 0 , 0.05};//{0.065, 0.1, -0.1}
	mountRotation = {0, 7, 0}; //-1.57



	weaponType = 0; // 0 singleshot,3 disk, 1 spinning,2 sustained
	ammoType = FEBAmmo;
	projectileType = FEBBullet;
	accuFire = true;
	reloadTime = 0;
	fireTime = 0.02;
	//spinUpTime = 0;

	sfxFire = ricochet1;
	sfxActivate = SoundShellClick2;
	//sfxReload = SoundDiscReload;
	//sfxReady = SoundMortarTurretTurn;
};

ItemData FEB
{
	description = "IX-FEB";
	className = "Weapon";
	shapeFile = "sniper";// paintgun
	hudIcon = "mortar";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FEBImage;//DiscLauncherImage
	price = 2002;
	showWeaponBar = true;
};

//--------------------------------------------------------
ItemData ShotgunAmmo
{
	description = "BuckShot Shells";
	className = "Ammo";
	shapeFile = "ammo1";
      heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 10;
};

ItemImageData ShotgunImage
{
	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0; // SingleShot
	reloadTime = 0.2;
	fireTime = 0.1;
	ammoType = ShotgunAmmo;
	accuFire = false;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = shockExplosion;
      sfxActivate = SoundShellClick2;
};

ItemData Shotgun
{
	description = "ShotGun";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "chain";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	price = 400;
	showWeaponBar = true;
};

function ShotgunImage::onFire(%player,%slot)
{
	for(%i = 0; %i < 12; %i++)
	{
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ShotgunPellet",%trans,%player,%vel);
	}
	Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
}

//---------------------------------------------------------------------------
ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = $InvHead[ihAmo];
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
	reloadTime = 0.03;
	fireTime = 0.03;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundShellClick2;
	sfxReload = SoundDryFire;
};

ItemData PlasmaGun
{
	description = "Plasma Gun";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
   //validateShape = true;
};

//----------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	//projectileType = GrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundShellClick2;
	sfxReload = SoundDryFire;
};

ItemData GrenadeLauncher
{
	description = "Grenade Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
   //validateShape = true;
};

function GrenadeLauncherImage::onFire(%player, %slot)
{
	Gamebase::setEnergy(%player,Gamebase::getEnergy(%player) -1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
      Projectile::spawnProjectile("Gren1",%trans,%player,%vel-15);
      Projectile::spawnProjectile("Gren1",%trans,%player,%vel);
	Projectile::spawnProjectile("Gren1",%trans,%player,%vel+15);
	Projectile::spawnProjectile("Gren2",%trans,%player,%vel-15);
	Projectile::spawnProjectile("Gren2",%trans,%player,%vel);
	Projectile::spawnProjectile("Gren2",%trans,%player,%vel+15);
	Projectile::spawnProjectile("Gren3",%trans,%player,%vel-15);
	Projectile::spawnProjectile("Gren3",%trans,%player,%vel);
	Projectile::spawnProjectile("Gren3",%trans,%player,%vel+15);
	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
}
//----------------------------------------------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = $InvHead[ihAmo];
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

	//lightType = 3;  // Weapon Fire
	//lightRadius = 3;
	//lightTime = 1;
	//lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundShellClick2;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 375;
	showWeaponBar = true;
   //validateShape = true;
};

//----------------------------------------------------------------------------

ItemData LiLFFBAmmo 
{ 
        description = "Heavy Mortar Ammo";
        className = "Ammo";
        heading = $InvHead[ihAmo];
        shapeFile = "grenammo";
        shadowDetailMask = 4;
        price = 5;
}; 

ItemImageData LiLFFBImage 
{ 
        shapeFile = "mortargun";
        mountPoint = 0;
        weaponType = 0;
        ammoType = LiLFFBAmmo;
        projectileType = LiLFFBShell;
        accuFire = false;
        reloadTime = 1;
        fireTime = 0;
        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
        sfxFire = SoundMortarTurretFire;
        sfxActivate = SoundShellClick2;
        sfxReady = SoundGeneratorPower;
};

ItemData LiLFFB
{ 
        description = "Heavy Impact Mortar";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "plasma";
        heading = $InvHead[ihWea];
        shadowDetailMask = 4;
        imageType = LiLFFBImage;
        price = 100;
        showWeaponBar = true;
};

//==============================================================
// Idea from JA Man's UR Mod. But modified HEAVILY!!!
//--------------------------------------------------------------
ItemImageData NU1Image
{
	shapeFile = "jetpack";
	mountPoint = 0; 
	mountOffset = { 0, 0.1, 0 }; //-  left-right, back-front, up-down
	mountRotation = { -1.5, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData NU1
{
	description = "Nuke pt2";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = NU1Image;
	showWeaponBar = false;
};


ItemData NuclearAmmo 
{ 
        description = "Nuclear Ammo";
        className = "Ammo";
        heading = "xAmmunition";
        shapeFile = "grenammo";
        shadowDetailMask = 4;
        price = 5;
}; 

ItemImageData NuclearImage 
{ 
        shapeFile = "mortargun";
        mountPoint = 0;
        mountOffset = { 0, 0, 0 };
	  mountRotation = { 0, -3.10, 0 };
        weaponType = 0;
        ammoType = NuclearAmmo;
        //projectileType = FgcShell;
        accuFire = false;
        reloadTime = 1;
        fireTime = 0;
        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
        sfxFire = bigexplosion1;
        sfxActivate = SoundShellClick2;
        sfxReady = SoundGeneratorPower;
};

ItemData Nuclear
{ 
        description = "Nuclear Emitter";
        className = "Weapon";
        shapeFile = "mortargun";
        hudIcon = "plasma";
        heading = $InvHead[ihWea];
        shadowDetailMask = 4;
        imageType = NuclearImage;
        price = 9000;
        showWeaponBar = true;
};

function Nuclear::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,1) == NuclearShieldPack)
	{
	      //BottomPrint(Player::getClient(%player),"<f1><jc>Nuclear Emitter Mounted",2);
            Weapon::onUse(%player,%item);
      }      
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have a Nuclear Emitter Shield Pack to use Nuclear Emitter."); 
}

function Nuclear::onMount(%player,%item)
{
	Player::mountItem(%player,NU1,7);
}

function Nuclear::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}
 
function NuclearImage::onFire(%player,%slot)
{
	echo("Firing Double Nuke!");
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("Nuke6",%trans,%player,%vel);
	Projectile::spawnProjectile("Nuke5",%trans,%player,%vel);
	Projectile::spawnProjectile("Nuke4",%trans,%player,%vel);
	Projectile::spawnProjectile("Nuke3",%trans,%player,%vel);
	Projectile::spawnProjectile("Nuke2",%trans,%player,%vel);
	Projectile::spawnProjectile("Nuke1",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[Nuclear],1);
}
//=============================================
// +Atomizer+
//=============================================
ItemData AtomizerAmmo 
{ 
description = "Atomizer Ammo"; 
className = "Ammo"; 
shapeFile = "grenammo"; 
heading = "xAmmunition"; 
shadowDetailMask = 4; 
price = 700; 
};

ItemImageData PlasCan1Image
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0, 0, 0.2 };
};

ItemData PlasCan1
{
	description = "PlasCan1";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = PlasCan1Image;
	showWeaponBar = false;
};

ItemImageData PlasCan2Image
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountRotation = { 0, -2.0934, 0 };
	mountOffset = { -0.1, 0, 0.05};
};

ItemData PlasCan2
{
	description = "PlasCan2";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = PlasCan2Image;
	showWeaponBar = false;
};


ItemImageData PlasCan3Image
{
	shapeFile = "disc";
	mountPoint = 0; 
	mountRotation = { 0, 2.0934, 0 };
	mountOffset = { 0.1, 0, 0.05 };
};

ItemData PlasCan3
{
	description = "PlasCan3";
	className = "Weapon";
	shapeFile = "disc";
	shadowDetailMask = 4;
	imageType = PlasCan3Image;
	showWeaponBar = false;
};


ItemImageData AtomizerImage
{
	shapeFile = "mortargun";
	mass = 2;
	mountPoint = 0;
	mountOffset = { 0, 0.2, 0.0 };
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	accuFire = true;
	reloadTime = 1.0;
	fireTime = 0.5;
AmmoType = AtomizerAmmo;
	//projectileType = ;
	minEnergy = 10;
	maxEnergy = 20;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = bigexplosion1;
	sfxActivate = SoundShellClick2;
	sfxReload = SoundFailPack;
	sfxReady = SoundWeapon5;
};

ItemData Atomizer
{
	description = "Atomizer";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = AtomizerImage;
	price = 9999;
	showWeaponBar = true;
	mass = 0;
};

function Atomizer::onMount(%player,%item)
{
	Player::mountItem(%player,PlasCan1,5);
	Player::mountItem(%player,PlasCan2,6);
	Player::mountItem(%player,PlasCan3,7);
}

function Atomizer::onUnMount(%player,%item)
{
	Player::unmountItem(%player,5);
	Player::unmountItem(%player,6);
	Player::unmountItem(%player,7);
}

function AtomizerImage::onFire(%this,%player,%item) 
{ 
	%client = GameBase::getOwnerClient(%this);
	%AmmoCount = (Player::getItemCount(%client,AtomizerAmmo));
  	%trans = GameBase::getMuzzleTransform(%this);
   	%vel = Item::getVelocity(%this);
	if(%AmmoCount){
	Player::decItemCount(%client,PlasCAmmo);
	if(GameBase::getLOSInfo(%this,800)){
		%Dist=Vector::getDistance(GameBase::getPosition(%this),$los::position);
		if(%Dist == 0)  %time = 1;
		else	%time=(%Dist/180)-0.05;
 		%newObj = Projectile::spawnProjectile("AgedonShell", %trans, %this, %vel);
		schedule("SpawnAgedon(" @ %newObj @ ", " @ %this @ ");", %time);
		
	}
	else{
		%time = 1; 
 		%newObj = Projectile::spawnProjectile("AgedonShell", %trans, %this, %vel);
		schedule("SpawnAgedon(" @ %newObj @ ", " @ %this @ ");", %time);
	}
	}
}

function SpawnAgedon(%newobj,%this){



		%Pos = GameBase::getPosition(%newobj); 
   		%vel = Item::getVelocity(%newobj);
		%xvel = getWord(%vel,0);
		%yvel = getWord(%vel,1);
		%zvel = getWord(%vel,2);

// Pretty shell split

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 	%obj = Projectile::spawnProjectile("PrettySplit", %trans, %this, %vel);
	Projectile::spawnProjectile(%obj);
	GameBase::setPosition(%obj, %pos);

// Spawn butterflies

if (GameBase::getPosition(%newObj)){
	for(%i=0; %i < 15; %i += 1) {

		%xrnd = %xvel + floor(getRandom() * 60) -30;
		%yrnd = %yvel + floor(getRandom() * 60) -30;
		%zrnd = %zvel + floor(getRandom() * 60) -30;

	%forceVel = %xrnd@" "@%yrnd@" "@%zrnd;

	%trans =  "0 0 1 0 0 0 0 0 1 " @ getBoxCenter(%newObj);
 		%obj = Projectile::spawnProjectile("AgedonGrenadeShell", %trans, %this, %vel);
		Projectile::spawnProjectile(%obj);
		GameBase::setPosition(%obj, %pos);

	Item::setVelocity(%obj, %forceVel);

		}
	deleteobject(%newObj);
	}
}
//--------------------------------------------------------------
// New LocK JaW By: *SlipKnot*
//--------------------------------------------------------------
ItemData LiLRocketLauncherAmmo
{
	description = "LocK JaW Ammo";
	className = "Ammo";
	shapeFile = "rocket";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 0;
};

ItemImageData R1Image
{
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0, -0.2, -0.2 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData R1
{
	description = "Lock Jaw pt2";
	className = "Weapon";
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = R1Image;
	showWeaponBar = false;
};

ItemImageData LiLRocketLauncherImage
{
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Spinning
	accuFire = true;
      ammotype = LiLRocketLauncherammo;
	reloadTime = 0.2;
	fireTime = 0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireSeeking;
	sfxActivate = SoundShellClick2;
};

ItemData LiLRocketLauncher
{ 
        description = "LocK-JaW";
        className = "Weapon";
        shapeFile = "grenadel";
        hudIcon = "plasma";
        heading = $InvHead[ihWea];
        shadowDetailMask = 4;
        imageType = LiLRocketLauncherImage;
        price = 100;
        showWeaponBar = true;
};

function LiLRocketLauncher::onMount(%player,%item)
{
	Player::mountItem(%player,R1,7);
}

function LiLRocketLauncher::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function LiLRocketLauncherImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[LiLRocketLauncher]);
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
				Client::sendMessage(%client,3,"LocK-JaW lock acquired! - "@ %targetP @ "~wmine_act.wav");
				Client::sendMessage(%targeted,1,"*^*!WARNING!*^* LocK-JaW lock detected - " @ %clientId @ "~waccess_denied.wav");
				Projectile::spawnProjectile("StingerMissile2",%trans,%player,%vel,$los::object);
				Player::decItemCount(%player,$WeaponAmmo[LiLRocketLauncher],1);
			}
			else
			{
				Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,%player);
				Player::decItemCount(%player,$WeaponAmmo[LiLRocketLauncher],1);
			}
		}
		else
		{
			Projectile::spawnProjectile("StingerRocket",%trans,%player,%vel,$los::object);
			Player::decItemCount(%player,$WeaponAmmo[LiLRocketLauncher],1);
		}
	}
	else 
		Client::sendMessage(Player::getClient(%player),0,"LocK JaW is out of ammo.~waccess_denied.wav");
}

//--------------------------------------------------------------

ItemData LiLEMPRocketLauncherAmmo 
{ 
        description = "Ion Trackers";
        className = "Ammo";
        heading = $InvHead[ihAmo];
        shapeFile = "grenammo";
        shadowDetailMask = 4;
        price = 5;
}; 

ItemImageData TICImage
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData TIC
{
	description = "TIC";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = TICImage;
	showWeaponBar = false;
};

ItemImageData LiLEMPRocketLauncherImage 
{ 
        shapeFile = "plasma";
	  mountPoint = 0; 
	  mountOffset = { 0, -0.1, -0.1 }; //-  left-right, back-front, up-down
	  mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
        weaponType = 0;
        ammoType = LiLEMPRocketLauncherAmmo;
        //projectileType = LiLFFBShell;
        accuFire = false;
        reloadTime = 0.2;
        fireTime = 0;
        //lightType = 3;
        //lightRadius = 3;
        //lightTime = 1;
        //lightColor = { 0.4, 0, 0.6 };
        sfxFire = SoundEMPfire;
        sfxActivate = SoundShellClick2;
        //sfxReady = SoundGeneratorPower;
};

ItemData LiLEMPRocketLauncher
{ 
        description = "Tracking Ion Cannon";
        className = "Weapon";
        shapeFile = "grenadel";
        hudIcon = "plasma";
        heading = $InvHead[ihWea];
        shadowDetailMask = 4;
        imageType = LiLEMPRocketLauncherImage;
        price = 100;
        showWeaponBar = true;
};

function LiLEMPRocketLauncher::onMount(%player,%item)
{
	Player::mountItem(%player,TIC,7);
}

function LiLEMPRocketLauncher::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}

function LiLEMPRocketLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[LiLEMPRocketLauncher],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,350)) 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("LiLEMPRocketONE",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("LiLEMPRocketTWO",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("LiLEMPRocketalt",%trans,%player,%vel);
	} else 
                        Projectile::spawnProjectile("LiLEMPRocketalt",%trans,%player,%vel);  
} 

//--------------------------------------------------------------
//--------------------------------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = $InvHead[ihAmo];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 0; // DiscLauncher
	ammoType = DiscAmmo;
	projectileType = DiscShell;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0;
	//spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundShellClick2;
	//sfxReload = SoundDiscReload;
	//sfxReady = SoundDiscSpin;
};

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

//--------------------------------------------------------------
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
	sfxActivate = SoundShellClick2;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

//------------------------------------------------------------------------------

ItemImageData BeamOfPainImage
{
	shapeFile = "shotgun";
   mountPoint = 0;
       mountoffset = { 0, 0, -0.2 };
       mountrotation = { 0, 3, 0 };
   weaponType = 2;  // Sustained
	projectileType = BeamOfPainProj;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.03;
                        
   //lightType = 3;  // Weapon Fire
   //lightRadius = 2;
   //lightTime = 1;
   //lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundShellClick2;
   sfxFire     = SoundELFFire;
};

ItemData BeamOfPain
{
   description = "Beam Of Pain";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = BeamOfPainImage;
	showWeaponBar = true;
   price = 125;
   //validateShape = true;
};

//--------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;
       // mountoffset = { 0, 0, -0.2 };
       // mountrotation = { 0, 3, 0 };
   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.08;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundShellClick2;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
   //validateShape = true;
};

//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// Cloak-Gun Taken But Re-coded From UR3v1.5
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
ItemImageData CloakGunImage
{
   shapeFile = "shotgun";
   mountPoint = 0;
   mountRotation = { 0, 0.785, 0 };

   weaponType = 2;  // Sustained
   projectileType = cloakingCharge;
   minEnergy = 3;
   maxEnergy = 3;  // Energy used/sec for sustained weapons
   reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 3;
   lightTime = 1;
   lightColor = { 0.15, 0.85, 0.15 };

   sfxActivate = SoundShellClick2;
   sfxFire     = SoundELFIdle;
};

ItemData CloakGun
{
   description = "Cloaking-Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = $InvHead[ihWea];
   shadowDetailMask = 4;
   imageType = CloakGunImage;
	showWeaponBar = true;
   price = 900;
   //validateShape = false;
};

//-----------------------------------------------
ItemImageData JailGunImage
{
shapeFile = "shotgun";
mountPoint = 0;
mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
mountRotation = { 0, -0.785, 0 };
weaponType = 2;
projectileType = jailbolt;
minEnergy = 5;
maxEnergy = 8;
reloadTime = 2.0;
lightType = 3;
lightRadius = 2;
lightTime = 1;
lightColor = { 0.25, 0.25, 0.85 };
sfxActivate = SoundPickUpWeapon;
sfxFire = SoundELFIdle;
};

ItemData JailGun
{
heading = $InvHead[ihWea];
description = "Jail-Gun";
className = "Tool";
shapeFile  = "shotgun";
shadowDetailMask = 4;
imageType = JailGunImage;
price = 600;
showWeaponBar = true;
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

	sfxActivate = SoundShellClick2;
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
   //validateShape = true;
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
   heading = $InvHead[ihRem];
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
		%Set = newObject("set",SimSet);
						                                %Mask = $StaticObjectType;
						                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
						                                for(%i; %i < %num; %i++)
						                                {
						                                        %thing = Group::getObject(%Set, %i);
						                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
						                                        {
						                                                %inbase= true;
						                                                break;
						                                        }
						                                }
						                                deleteObject(%Set);
						                                if(%inbase)
                                {
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
					//remotekill(%client);
					bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
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
   heading = $InvHead[ihRem];
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
		%Set = newObject("set",SimSet);
						                                %Mask = $StaticObjectType;
						                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
						                                for(%i; %i < %num; %i++)
						                                {
						                                        %thing = Group::getObject(%Set, %i);
						                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
						                                        {
						                                                %inbase= true;
						                                                break;
						                                        }
						                                }
						                                deleteObject(%Set);
						                                if(%inbase)
                                {
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
					//remotekill(%client);
					bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
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
 	maxEnergy = -20;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
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
   heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 125;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
   validateMaterials = true;
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
	maxEnergy = 18;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData ShieldPack
{
	description = "Shield Pack";
	shapeFile = "shieldPack";
	className = "Backpack";
   heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = ShieldPackImage;
	price = 175;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
   validateMaterials = true;
};

function ShieldPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	%player.shieldStrength = 0.008;
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
	maxEnergy = 18;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "StealthShield Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
   validateMaterials = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
	%player.shieldStrength = 0.008;
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
	%player.shieldStrength = 0;
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

//----------------------------------------------------------------------------

ItemImageData CloakingDeviceImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 18;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData CloakingDevice
{
	description = "Cloaking Device";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = CloakingDeviceImage;
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

//----------------------------------------------------------------------------------------------

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
   heading = $InvHead[ihDSe];
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
		%Set = newObject("set",SimSet);
						                                %Mask = $StaticObjectType;
						                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
						                                for(%i; %i < %num; %i++)
						                                {
						                                        %thing = Group::getObject(%Set, %i);
						                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
						                                        {
						                                                %inbase= true;
						                                                break;
						                                        }
						                                }
						                                deleteObject(%Set);
						                                if(%inbase)
                                {
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
					//remotekill(%client);	
					bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
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
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//Base Alarm Coded By: *SlipKnot*(Beats ADT eh?)
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
ItemImageData BaseAlarmImage
	{
	shapeFile = "sensor_small";
	mountPoint = 2;
	mountOffset = { 0, 0, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
	};

ItemData BaseAlarm
	{
      description = "Base Alarm";
      shapeFile = "sensor_small";
      className = "Backpack";
      heading = $InvHead[ihDSe];
      shadowDetailMask = 4;
      imageType = BaseAlarmImage;
      mass = 2.0;
      elasticity = 0.2;
      price = 150;
      hudIcon = "deployable";
      showWeaponBar = true;
      hiliteOnActive = true;
	};

function BaseAlarm::onUse(%player,%item)
	{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	//Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	Player::deployItem(%player,%item);
	}

function BaseAlarm::onDeploy(%player,%item,%pos)
	{
	if (BaseAlarm::deployShape(%player,%item)) 
	Player::decItemCount(%player,%item);
	}

function BaseAlarm::deployShape(%player,%item)
	{
 	%client = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object);
	if (%obj == "InteriorShape") 
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.6) 
	%rot = "0 0 0";
	else 
	{
	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
	%rot = "3.14159 0 0";
	else 
	%rot = Vector::getRotation($los::normal);
	}
	%alarm = newObject("","StaticShape", "AlarmKit",true);
 	addToSet("MissionCleanup", %alarm);
	GameBase::setTeam(%alarm,GameBase::getTeam(%player));
	GameBase::setRotation(%alarm,%rot);
	GameBase::setPosition(%alarm,$los::position);
	Gamebase::setMapName(%alarm,%name);
	Gamebase::setMapName(%alarm,"Base Alarm");
	Client::sendMessage(%client,0,"Base Alarm deployed");
	echo("MSG: ",%client," deployed a Base Alarm");
      	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on buildings");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range");
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
   heading = $InvHead[ihBac];
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
//-------------------------------------------------------------------
ItemImageData FABPackImage
{
	shapeFile = "mine";//armorPack
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = 0;
	maxEnergy = 0;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, 0.3, 0.20 };
  	mountRotation = { -1.57, -3.14, 0};
	firstPerson = false;
};

ItemData FABPack
{
	description = "Fabrication Pack";
	shapeFile = "mine";
	className = "Backpack";
   heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = FABPackImage;
	price = 700;
	hudIcon = "sniper";
	showWeaponBar = true;
	hiliteOnActive = true;
   	//validateShape      = true;
   validateMaterials = false;
};

function FABPackImage::onActivate(%clientId,%player,%imageSlot)
{
	%armor = Player::getArmor(%clientId);
	Player::setItemCount(%clientId,BulletAmmo,$ItemMax[%armor, BulletAmmo]);
	Player::setItemCount(%clientId,PlasmaAmmo,$ItemMax[%armor, PlasmaAmmo]);
	Player::setItemCount(%clientId,DiscAmmo,$ItemMax[%armor, DiscAmmo]);
	Player::setItemCount(%clientId,GrenadeAmmo,$ItemMax[%armor, GrenadeAmmo]);
	Player::setItemCount(%clientId,MortarAmmo,$ItemMax[%armor, MortarAmmo]);
	Player::setItemCount(%clientId,FEBAmmo,$ItemMax[%armor, FEBAmmo]);
	Player::setItemCount(%clientId,IX2002Ammo,$ItemMax[%armor, IX2002Ammo]);
	Player::setItemCount(%clientId,LiLFFBAmmo,$ItemMax[%armor, LiLFFBAmmo]);
	Player::setItemCount(%clientId,LiLRocketLauncherAmmo,$ItemMax[%armor, LiLRocketLauncherAmmo]);
	Player::setItemCount(%clientId,LiLEMPRocketLauncherAmmo,$ItemMax[%armor, LiLEMPRocketLauncherAmmo]);
	Player::setItemCount(%clientId,RepairKit,$ItemMax[%armor, RepairKit]);
	Player::setItemCount(%clientId,LiLPOOmkiAmmo,$ItemMax[%armor, LiLPOOmkiAmmo]);
	Player::setItemCount(%clientId,LiLPOOmkiiAmmo,$ItemMax[%armor, LiLPOOmkiiAmmo]);
	Player::setItemCount(%clientId,SmScreenAbilityAmmo,$ItemMax[%armor, SmScreenAbilityAmmo]);
	Player::setItemCount(%clientId,ExSmScreenAbilityAmmo,$ItemMax[%armor, ExSmScreenAbilityAmmo]);
	Player::setItemCount(%clientId,FireScreenAbilityAmmo,$ItemMax[%armor, FireScreenAbilityAmmo]);
	Player::setItemCount(%clientId,spellabilityAmmo,$ItemMax[%armor, spellabilityAmmo]);
	Player::setItemCount(%clientId,ShotgunAmmo,$ItemMax[%armor, ShotgunAmmo]);
	Player::setItemCount(%clientId,Beacon,$ItemMax[%armor, Beacon]);
	Player::setItemCount(%clientId,Grenade,$ItemMax[%armor, Grenade]);
	Player::setItemCount(%clientId,MineAmmo,$ItemMax[%armor, MineAmmo]);

Player::setItemCount(%clientId,FABPack,0);

}

function FABPackImage::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}
//-------------------------------------------------------------------
ItemImageData NuclearShieldPackImage
{
	shapeFile = "mortarpack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 4;
	maxEnergy = 80;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData NuclearShieldPack
{
	description = "Nuclear Emitter Shield";
	shapeFile = "mortarPack";
	className = "Backpack";
   heading = $InvHead[ihBac];
	shadowDetailMask = 4;
	imageType = NuclearShieldPackImage;
	price = 225;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
   validateMaterials = true;
};

function ContainmentCritical(%client, %player)
{
   Client::sendMessage(%client,1,"Nuclear containment grid has become critical - Ejecting Nuclear Shield Pack.");
   Client::sendMessage(%client,1,"Nuclear containment grid has become critical - Ejecting Nuclear Emitter.");
   //%item2 = Player::getMountedItem(%client,$WeaponSlot);
   //if(%item2 != Nuclear)
   //    Player::mountItem(%player,"Nuclear",$WeaponSlot);
   Player::dropItem(%player,"Nuclear");
   
   
}

function NuclearShieldPackImage::onActivate(%player,%imageSlot)
{
      %client = Player::getClient(%player);
      %item = Player::getMountedItem(%client,$BackpackSlot);
      Client::sendMessage(%client,0,"Nuclear Emitter Shield On -- Five seconds until nuclear containment failure.");
	%player.shieldStrength = 0.999;
      //bottomPrint(Player::getClient(%player),"Five seconds until
      schedule("ContainmentCritical(" @ %client @ "," @ %player @ ");", 5, %client); 
      schedule("Player::dropItem(" @ %player @ "," @ %item @ ");", 5.5,%client);
      schedule(%player @ ".shieldStrength = 0;", 5.6, %client);
   
}

function NuclearShieldPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Nuclear Emitter Shield Off");
	Player::trigger(%player,$BackpackSlot,false);
	%player.shieldStrength = 0;
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
   heading = $InvHead[ihDSe];
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
   heading = $InvHead[ihDSe];
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
   heading = $InvHead[ihDSe];
	imageType = CameraPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 100;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
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
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		%Set = newObject("set",SimSet);
						                                %Mask = $StaticObjectType;
						                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
						                                for(%i; %i < %num; %i++)
						                                {
						                                        %thing = Group::getObject(%Set, %i);
						                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
						                                        {
						                                                %inbase= true;
						                                                break;
						                                        }
						                                }
						                                deleteObject(%Set);
						                                if(%inbase)
                                {
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
					//remotekill(%client);	
					bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
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

//----------------------VX
//function Kickabitch(%clientId)
//{
//Net::kick(%clientId, "Guess you thought you where gonna be cute and slam me eh bitch? Well I have banned your Bitch ass from ultra!.");
//}
//
//----------------------------------------------------------------------------
																			
ItemImageData LaserTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LaserTurretPack
{
	description = "Laser Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = LaserTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretPack::deployShape(%player,%item)) {
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

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function LaserTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {
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
					%turret = newObject("remoteTurret","Turret",LaserTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Laser Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Laser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "LaserTurretPack"]++;
					echo("MSG: ",%client," deployed a Laser Turret");
					////	Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
		       //remotekill(%client);
		       bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
		       //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
		 
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

//////////////////////////////////////////////////////////////////////////////////////////////////////////
//disable for stick on ceiling above
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//function LaserTurretPack::deployShape(%player,%item)
//{
//	%client = Player::getClient(%player);
//	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
//		if (GameBase::getLOSInfo(%player,3)) {
//			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
//	    		%set = newObject("set",SimSet);
//				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
//				%num = CountObjects(%set,"LaserTurret",%num);
//				deleteObject(%set);
//				if($MaxNumTurretsInBox > %num) {
//		    		%set = newObject("set",SimSet);
//					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
//					%num = CountObjects(%set,"LaserTurret",%num);
//					deleteObject(%set);
//					if(0 == %num) {
//						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
//							if(checkDeployArea(%client,$los::position)) {
//								%rot = GameBase::getRotation(%player); 
//								%turret = newObject("remoteTurret","Turret",LaserTurret,true);
//	                     addToSet("MissionCleanup", %turret);
//								GameBase::setTeam(%turret,GameBase::getTeam(%player));
//								GameBase::setPosition(%turret,$los::position);
//								GameBase::setRotation(%turret,%rot);
//								Gamebase::setMapName(%turret,"Laser Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
//								Client::sendMessage(%client,0,"Laser Turret deployed");
//								playSound(SoundPickupBackpack,$los::position);
//								$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurretPack"]++;
//								echo("MSG: ",%client," deployed a Laser Turret");
//								//	Remote turrets - kill points to player that deploy them
//								Client::setOwnedObject(%client, %turret); 
//								Client::setOwnedObject(%client, %player);
//								return true;
//							}
//						}
//						else 
//							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
//					} 
//					else
//						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
//				}
//			   else 
//					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
//			}
//			else 
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
//		}
//		else 
//			Client::sendMessage(%client,0,"Deploy position out of range");
//	}
//	else																						  
//	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
//
//	return false;
//}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//above disabled
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//----------------------VX

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
	description = "Ionic Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
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


//////////////////////////////////////////////////////////////////////
//function already exists above
//////////////////////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//------------------------------------------------------------------------------------
///////////////////////////////////////////////////////////////////////
function TurretPack::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
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
								Gamebase::setMapName(%turret,"Ionic Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"LiL Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "TurretPack"]++;
								echo("MSG: ",%client," deployed a Ionic Turret");
								//	Remote turrets - kill points to player that deploy them
								//Client::setOwnedObject(%client, %turret); 
								//Client::setOwnedObject(%client, %player);
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
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

//--VX-

//------------------------------------------------------------------------------------

ItemImageData 	TaserTrtBPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData TaserTrtBPack
{
        description = "Taser Turret";
        shapeFile = "camera";
        className = "Backpack";
      heading = $InvHead[ihTur];
        imageType = TaserTrtBPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function TaserTrtBPack::onUse(%player,%item)
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

function TaserTrtBPack::onDeploy(%player,%item,%pos)
{
        if (TaserTrtBPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function TaserTrtBPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
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
					%turret = newObject("Camera","Turret",DeployableTaserTrtB,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Taser Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Taser Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "TaserTrtBPack"]++;
					echo("MSG: ",%client," deployed a Taser Turret");
					////Remote turrets - kill points to player that deploy them
					//Client::setOwnedObject(%client, %turret); 
                  			//Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
		//remotekill(%client);
		//Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
		bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

/////////////////////////////////////////////////////
//this function replaced above for sticking on ceiling
/////////////////////////////////////////////////////
//function TaserTrtBPack::deployShape(%player,%item)
//{
//        %client = Player::getClient(%player);
//        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
//        {
//                if (GameBase::getLOSInfo(%player,3))
//                {
//                                %Set = newObject("set",SimSet);
//                                %Mask = $StaticObjectType;
//                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 100, 100, 100,0);
//                                for(%i; %i < %num; %i++)
//                                {
//                                        %thing = Group::getObject(%Set, %i);
//                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
//                                        {
//                                                %inbase= true;
//                                                break;
//                                        }
//                                }
//                                deleteObject(%Set);
//                                if(%inbase)
//                                {
//                                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
//                                        {
//                                                if(checkDeployArea(%client,$los::position))
//                                                {
//                                                        %rot = GameBase::getRotation(%player);
//
//                                                        %turret = newObject("camera","Turret",DeployableTaserTrtB,true);
//                                                                addToSet("MissionCleanup", %turret);
//                                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
//                                                        GameBase::setPosition(%turret,$los::position);
//                                                        GameBase::setRotation(%turret,%rot);
//                                                        Gamebase::setMapName(%turret,"Taser Turret" @ Client::getName(%client));
//
//
//                                                        %backward = Vector::neg(Vector::getFromRot(%rot, 0.8));//meaning backwards a little bit.
//
//                                                        GameBase::setPosition(%cyl,Vector::add($los::position, %backward));
//                                                        GameBase::setRotation(%cyl,%rot);
//                                                        Gamebase::setMapName(%cyl,"DeployableTaserTrtB");
//
//                                                        %turret.cyl = %cyl;
//                                                        %cyl.turret = %turret;
//
//                                                        Client::sendMessage(%client,0,"Taser Turret deployed");
//                                                        playSound(SoundPickupBackpack,$los::position);
//                                                        $TeamItemCount[GameBase::getTeam(%player) @ "TaserTrtBPack"]++;
//                                                        echo("MSG: ",%client," deployed an Taser Turret");
//                                                        //        Remote turrets - kill points to player that deploy them
//                                                        Client::setOwnedObject(%client, %turret);
//                                                        Client::setOwnedObject(%client, %player);
//
//                                                        if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
//                                                        {
//                                                                GameBase::setDamageLevel(%turret, 0.7 * TaserTrtBPack.maxDamage);
//                                                                
//                                                        }
//
//                                                        return true;
//                                                }
//                                                else
//                                                        Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
//                                        }
//                                        else
//                                                Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
//                                }
//                                else
//                                        Client::sendMessage(%client,0,"You must be near your base.");          
//                }
//                else
//                        Client::sendMessage(%client,0,"Deploy position out of range");
//        }
//        else
//                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
//
//        return false;
//}
//
//
////------------------------------------------------------------------------------------

ItemImageData 	TaserTrtCPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData TaserTrtCPack
{
        description = "Tracking Turret";
        shapeFile = "camera";
        className = "Backpack";
      heading = $InvHead[ihDSe];
        imageType = TaserTrtCPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function TaserTrtCPack::onUse(%player,%item)
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

function TaserTrtCPack::onDeploy(%player,%item,%pos)
{
        if (TaserTrtCPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function TaserTrtCPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
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
					%turret = newObject("Camera","Turret",DeployableTaserTrtC,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Taser Tracker#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Taser Tracker deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "TaserTrtCPack"]++;
					echo("MSG: ",%client," deployed a Taser Tracker");
					////Remote turrets - kill points to player that deploy them
					//Client::setOwnedObject(%client, %turret); 
					//Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			//remotekill(%client);
			bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
			//Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}


//////////////////////////////////////////////////////
//function above replaces this one for stick on ceiling listening to the ORB Live93
//////////////////////////////////////////////////////
//function TaserTrtCPack::deployShape(%player,%item)
//{
//        %client = Player::getClient(%player);
//        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
//        {
//                if (GameBase::getLOSInfo(%player,3))
//                {
//                                %Set = newObject("set",SimSet);
//                                %Mask = $StaticObjectType;
//                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 100, 100, 100,0);
//                                for(%i; %i < %num; %i++)
//                                {
//                                        %thing = Group::getObject(%Set, %i);
//                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
//                                        {
//                                                %inbase= true;
//                                                break;
//                                        }
//                                }
//                                deleteObject(%Set);
//                                if(%inbase)
//                                {
//                                        if (Vector::dot($los::normal,"0 0 1") > 0.7)
//                                        {
//                                                if(checkDeployArea(%client,$los::position))
//                                                {
//                                                        %rot = GameBase::getRotation(%player);
//
//                                                        %turret = newObject("camera","Turret",DeployableTaserTrtC,true);
//                                                                addToSet("MissionCleanup", %turret);
//                                                        GameBase::setTeam(%turret,GameBase::getTeam(%player));
//                                                        GameBase::setPosition(%turret,$los::position);
//                                                        GameBase::setRotation(%turret,%rot);
//                                                        Gamebase::setMapName(%turret,"Taser Tracker" @ Client::getName(%client));
//
//
//                                                        %backward = Vector::neg(Vector::getFromRot(%rot, 0.8));//meaning backwards a little bit.
//
//                                                        GameBase::setPosition(%cyl,Vector::add($los::position, %backward));
//                                                        GameBase::setRotation(%cyl,%rot);
//                                                        Gamebase::setMapName(%cyl,"DeployableTaserTrtC");
//
//                                                        %turret.cyl = %cyl;
//                                                        %cyl.turret = %turret;
//
//                                                        Client::sendMessage(%client,0,"Taser Tracker deployed");
//                                                        playSound(SoundPickupBackpack,$los::position);
//                                                        $TeamItemCount[GameBase::getTeam(%player) @ "TaserTrtCPack"]++;
//                                                        echo("MSG: ",%client," deployed an Taser Tracker");
//                                                        //        Remote turrets - kill points to player that deploy them
//                                                        Client::setOwnedObject(%client, %turret);
//                                                        Client::setOwnedObject(%client, %player);
//
//                                                        if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
//                                                        {
//                                                                GameBase::setDamageLevel(%turret, 0.7 * TaserTrtCPack.maxDamage);
//                                                                
//                                                        }
//
//                                                        return true;
//                                                }
//                                                else
//                                                        Client::sendMessage(%client, 0, "Cannot deploy. Item in way");
//                                        }
//                                        else
//                                                Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
//                                }
//                                else
//                                        Client::sendMessage(%client,0,"You must be near your base.");          
//                }
//                else
//                        Client::sendMessage(%client,0,"Deploy position out of range");
//        }
//        else
//                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
//
//        return false;
//}
//
//
////------------------------------------------------------------------------------------
//end dont use me
////////////////////////////////////////////////////////////////////////////////////////
//Mini-Plasma
//----------------------------------------------------------------------------
																			
ItemImageData MaliceTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MaliceTurretPack
{
	description = "Chaingun Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MaliceTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MaliceTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MaliceTurretPack::onDeploy(%player,%item,%pos)
{
	if (MaliceTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MaliceTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
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
					%turret = newObject("remoteTurret","Turret",MaliceTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Chaingun Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Chaingun Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MaliceTurretPack"]++;
					echo("MSG: ",%client," deployed a Chaingun Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}
////////////////////////////////////////////////////////////////////////////////////////
//Mini-Plasma
//----------------------------------------------------------------------------
																			
ItemImageData LaserTurretBPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData LaserTurretBPack
{
	description = "Plasma Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = LaserTurretBPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaserTurretBPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function LaserTurretBPack::onDeploy(%player,%item,%pos)
{
	if (LaserTurretBPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

/////////////////////////////////////////////////////
//countobject already exists
////////////////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
//
///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function LaserTurretBPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
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
					%turret = newObject("remoteTurret","Turret",LaserTurretB,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Plasma Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Plasma Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "LaserTurretBPack"]++;
					echo("MSG: ",%client," deployed a Plasma Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
				                                         //remotekill(%client);
				                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
				                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
		else {
			Client::sendMessage(%client,0,"Deploy position out of range");		
		}
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
	return false;
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////
//disable for stick on ceiling above
//////////////////////////////////////////////////////////////////////////////////////////////////////////
//function LaserTurretPack::deployShape(%player,%item)
//{
//	%client = Player::getClient(%player);
//	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
//		if (GameBase::getLOSInfo(%player,3)) {
//			%obj = getObjectType($los::object);
//			if (%obj == "SimTerrain" || %obj == "InteriorShape") {
//	    		%set = newObject("set",SimSet);
//				%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
//				%num = CountObjects(%set,"LaserTurret",%num);
//				deleteObject(%set);
//				if($MaxNumTurretsInBox > %num) {
//		    		%set = newObject("set",SimSet);
//					%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
//					%num = CountObjects(%set,"LaserTurret",%num);
//					deleteObject(%set);
//					if(0 == %num) {
//						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
//							if(checkDeployArea(%client,$los::position)) {
//								%rot = GameBase::getRotation(%player); 
//								%turret = newObject("remoteTurret","Turret",LaserTurret,true);
//	                     addToSet("MissionCleanup", %turret);
//								GameBase::setTeam(%turret,GameBase::getTeam(%player));
//								GameBase::setPosition(%turret,$los::position);
//								GameBase::setRotation(%turret,%rot);
//								Gamebase::setMapName(%turret,"Laser Turret#" @ $totalNumTurrets++ @ " " @ Client::getName(%client));
//								Client::sendMessage(%client,0,"Laser Turret deployed");
//								playSound(SoundPickupBackpack,$los::position);
//								$TeamItemCount[GameBase::getTeam(%player) @ "LaserTurretPack"]++;
//								echo("MSG: ",%client," deployed a Laser Turret");
//								//	Remote turrets - kill points to player that deploy them
//								Client::setOwnedObject(%client, %turret); 
//								Client::setOwnedObject(%client, %player);
//								return true;
//							}
//						}
//						else 
//							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
//					} 
//					else
//						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
//				}
//			   else 
//					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
//			}
//			else 
//				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
//		}
//		else 
//			Client::sendMessage(%client,0,"Deploy position out of range");
//	}
//	else																						  
//	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
//
//	return false;
//}
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//above disabled
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

ItemImageData MiniFlakTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniFlakTurretPack
{
	description = "Flak Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MiniFlakTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniFlakTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MiniFlakTurretPack::onDeploy(%player,%item,%pos)
{
	if (MiniFlakTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

//////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
///////////////////////////////////////////

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MiniFlakTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {
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
					%turret = newObject("remoteTurret","Turret",MiniFlakTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"Flak Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Flak Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MiniFlakTurretPack"]++;
					echo("MSG: ",%client," deployed a Flak Turret");
					////	Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
		       //remotekill(%client);
		       bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
		       //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
		 
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

ItemImageData MiniSAMTurretPackImage
{
	shapeFile = "remoteturret";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData MiniSAMTurretPack
{
	description = "S.A.M Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   heading = $InvHead[ihTur];
	imageType = MiniSAMTurretPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 350;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MiniSAMTurretPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		Player::deployItem(%player,%item);
	}
}

function MiniSAMTurretPack::onDeploy(%player,%item,%pos)
{
	if (MiniSAMTurretPack::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

//////////////////////////////////////////
//function CountObjects(%set,%name,%num) 
//{
//	%count = 0;
//	for(%i=0;%i<%num;%i++) {
//		%obj=Group::getObject(%set,%i);
//		if(GameBase::getDataName(Group::getObject(%set,%i)) == %name) 
//			%count++;
//	}
//	return %count;
//}
///////////////////////////////////////////

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MiniSAMTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
		                                %Mask = $StaticObjectType;
		                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
		                                for(%i; %i < %num; %i++)
		                                {
		                                        %thing = Group::getObject(%Set, %i);
		                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
		                                        {
		                                                %inbase= true;
		                                                break;
		                                        }
		                                }
		                                deleteObject(%Set);
		                                if(%inbase)
                                {
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
					%turret = newObject("remoteTurret","Turret",MiniSAMTurret,true);
	   	      addToSet("MissionCleanup", %turret);
					GameBase::setTeam(%turret,GameBase::getTeam(%player));
					GameBase::setRotation(%turret,%rot);
					GameBase::setPosition(%turret,$los::position);
					Gamebase::setMapName(%turret,"S.A.M Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"S.A.M Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%turret) @ "MiniSAMTurretPack"]++;
					echo("MSG: ",%client," deployed a S.A.M Turret");
					////	Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %turret); 
                                        Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else {
		                                         
		       //remotekill(%client);
		       bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
		       //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
		 
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

ItemImageData 	MiniELFTurretPackImage
{
        shapeFile = "camera";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData MiniELFTurretPack
{
        description = "ELF Turret";
        shapeFile = "camera";
        className = "Backpack";
      heading = $InvHead[ihTur];
        imageType = MiniELFTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function MiniELFTurretPack::onUse(%player,%item)
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

function MiniELFTurretPack::onDeploy(%player,%item,%pos)
{
        if (MiniELFTurretPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MiniELFTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
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
					%elfturret = newObject("camera","Turret",MiniELFTurret,true);
	   	      addToSet("MissionCleanup", %elfturret);
					GameBase::setTeam(%elfturret,GameBase::getTeam(%player));
					GameBase::setRotation(%elfturret,%rot);
					GameBase::setPosition(%elfturret,$los::position);
					Gamebase::setMapName(%elfturret,"ELF#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"ELF deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%elfturret) @ "MiniELFTurretPack"]++;
					echo("MSG: ",%client," deployed a ELF");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %elfturret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			//remotekill(%client);
			bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
			//Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
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


ItemImageData 	MiniSmokeTurretPackImage
{
        shapeFile = "remoteturret";
        mountPoint = 2;
        mountOffset = { 0, -0.12, -0.1 };
        mountRotation = { 0, 0, 0 };
        mass = 1;
        firstPerson = false;
};

ItemData MiniSmokeTurretPack
{
        description = "Grip Turret";
        shapeFile = "camera";
        className = "Backpack";
      heading = $InvHead[ihTur];
        imageType = MiniSmokeTurretPackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 200;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};


function MiniSmokeTurretPack::onUse(%player,%item)
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

function MiniSmokeTurretPack::onDeploy(%player,%item,%pos)
{
        if (MiniSmokeTurretPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

///////////////////////////////////////////////////
//stick on ceiling modified from camera deploy function
///////////////////////////////////////////////////
function MiniSmokeTurretPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if (GameBase::getLOSInfo(%player,3)) {
		
		%Set = newObject("set",SimSet);
				                                %Mask = $StaticObjectType;
				                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
				                                for(%i; %i < %num; %i++)
				                                {
				                                        %thing = Group::getObject(%Set, %i);
				                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
				                                        {
				                                                %inbase= true;
				                                                break;
				                                        }
				                                }
				                                deleteObject(%Set);
				                                if(%inbase)
                                {
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
					%elfturret = newObject("camera","Turret",MiniSmokeTurret,true);
	   	      addToSet("MissionCleanup", %elfturret);
					GameBase::setTeam(%elfturret,GameBase::getTeam(%player));
					GameBase::setRotation(%elfturret,%rot);
					GameBase::setPosition(%elfturret,$los::position);
					Gamebase::setMapName(%elfturret,"Grip Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Grip Turret deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%elfturret) @ "MiniSmokeTurretPack"]++;
					echo("MSG: ",%client," deployed a Grip Turret");
					////Remote turrets - kill points to player that deploy them
					Client::setOwnedObject(%client, %elfturret); 
					Client::setOwnedObject(%client, %player);
					return true;
				}
			}
			else {
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
		}
		
		 else
				                                         
			//remotekill(%client);
			bottomprint(%client, "                             Fair play distance exceeded for " @ %item.description @ "s", 3);
			//Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
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

ItemImageData lgaForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData lgaForceFieldPack
{
        description = "4x14 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihFFD];
        imageType = lgaForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function lgaForceFieldPack::onUse(%player,%item)
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

function lgaForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (lgaForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function lgaForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("lgaForceFieldPack","StaticShape",lgaForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "lgaForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------

ItemImageData lgbForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData lgbForceFieldPack
{
        description = "4x14 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihFFD];
        imageType = lgbForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function lgbForceFieldPack::onUse(%player,%item)
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

function lgbForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (lgbForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function lgbForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("lgbForceFieldPack","StaticShape",lgbForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "lgbForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medaForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medaForceFieldPack
{
        description = "4x8 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihFFD];
        imageType = medaForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medaForceFieldPack::onUse(%player,%item)
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

function medaForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medaForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medaForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medaForceFieldPack","StaticShape",medaForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medaForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medbForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medbForceFieldPack
{
        description = "5x5 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihFFD];
        imageType = medbForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medbForceFieldPack::onUse(%player,%item)
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

function medbForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medbForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medbForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medbForceFieldPack","StaticShape",medbForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medbForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}


//----------------------------------------------------------------------------
ItemImageData medcForceFieldPackImage
{
        shapeFile = "AmmoPack";
        mountPoint = 2;
        mountOffset = { 0, 0, 0 };
        mountRotation = { 0, 0, 0 };
        mass = 2.5;
        firstPerson = false;
};

ItemData medcForceFieldPack
{
        description = "3x4 FFD";
        shapeFile = "AmmoPack";
        className = "Backpack";
        heading = $InvHead[ihFFD];
        imageType = medcForceFieldPackImage;
        shadowDetailMask = 4;
        mass = 2.5;
        elasticity = 0.2;
        price = 500;
        hudIcon = "deployable";
        showWeaponBar = true;
        hiliteOnActive = true;
};

function medcForceFieldPack::onUse(%player,%item)
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

function medcForceFieldPack::onDeploy(%player,%item,%pos)
{
        if (medcForceFieldPack::deployShape(%player,%item))
        {
                Player::decItemCount(%player,%item);
        }
}

function medcForceFieldPack::deployShape(%player,%item)
{
         %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
                if (GameBase::getLOSInfo(%player,3)) {
                
                %Set = newObject("set",SimSet);
								                                %Mask = $StaticObjectType;
								                                %num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
								                                for(%i; %i < %num; %i++)
								                                {
								                                        %thing = Group::getObject(%Set, %i);
								                                        if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
								                                        {
								                                                %inbase= true;
								                                                break;
								                                        }
								                                }
								                                deleteObject(%Set);
								                                if(%inbase)
                                {
                

                        %obj = getObjectType($los::object);
                                %rot = GameBase::getRotation(%player);

                                        %camera = newObject("medcForceFieldPack","StaticShape",medcForceFieldShape,true);
                                        addToSet("MissionCleanup", %camera);
                                        GameBase::setTeam(%camera,GameBase::getTeam(%player));
                                        GameBase::setRotation(%camera,%rot);
                                        GameBase::setPosition(%camera,$los::position);
                                        Gamebase::setMapName(%camera,"Force Field Door#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
                                        Client::sendMessage(%client,0,"Force Field Door deployed");
                                        playSound(SoundPickupBackpack,$los::position);
                                        $TeamItemCount[GameBase::getTeam(%camera) @ "medcForceFieldPack"]++;
                                        echo("MSG: ",%client," deployed a Force Field Door ");
                                        return true;

                        }
                        
                        else
									                                         
									                                         //remotekill(%client);
									                                         bottomprint(%client, "                         Fair play distance exceeded for " @ %item.description @ "s", 3);
									                                         //Client::sendMessage(%client,0,"Fair play distance exceeded for " @ %item.description @ "s");
                }
                        
                       else {
                                Client::sendMessage(%client,0,"Cannot deploy here.");
                        }

        }
        else
                 Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

        return false;
}
//-------------|Electric Web By: Biohazard|----- Thanks!
ItemImageData ElectricWebImage
{
	shapeFile = "display_three";
	mountPoint = 2;
	mountOffset = { 0, -0.03, -0.4 };
	mountRotation = { 0, 0, 0 };//1.57
	firstPerson = false;
};

ItemData ElectricWeb
{
	description = "Electric Web";
	shapeFile = "display_three";
	className = "Backpack";
    	heading = $InvHead[ihFFD];
	imageType = ElectricWebImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ElectricWeb::onUse(%player,%item)
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

function ElectricWeb::onDeploy(%player,%item,%pos)
{
	if (ElectricWeb::deployShape(%player,%item))
	{
		Player::decItemCount(%player,%item);
	}
}

function ElectricWeb::deployShape(%player,%item)
{
        GameBase::getLOSInfo(%player,3);
        %client = Player::getClient(%player);
        if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
        {
                %playerPos = GameBase::getPosition(%player);
                %deploypos = Vector::add(GameBase::getPosition(%player), "0 0 2");
                %rot = Vector::add(GameBase::getRotation(%player), "0 1.57 1.57");
                %inv = newObject("Electric Web","Turret","PlasmaDoorTurr",true);
                addToSet("MissionCleanup", %inv);
                GameBase::setTeam(%inv,GameBase::getTeam(%player));
                GameBase::setRotation(%inv,%rot);
                GameBase::setPosition(%inv,%deploypos);
                Gamebase::setMapName(%inv,"Electric Web" @  Client::getName(%client));
                Client::setOwnedObject(%client, %inv); 
                Client::setOwnedObject(%client, %player);
                playSound(SoundPickupBackpack,$los::position);
                $TeamItemCount[GameBase::getTeam(%player) @ "ElectricWeb"]++;
                Client::sendMessage(%client,0,"Electric Web is spun.~wlightning_idle.wav");
      
        }

}
//===========================================
TurretData ArbitorBox
	{
	className = "Turret";
	shapeFile = "plasammo";
	maxDamage = 2;
	maxEnergy = 0;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	supressable = true;
	pinger = false;
	dopplerVelocity = 0;
	castLOS = true;
	supression = true;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Arbitor Box";
	damageSkinData = "objectDamageSkins";
	};

ItemImageData ArbitorBoxPackImage
	{
	shapeFile = "plasammo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
	};

ItemData ArbitorBoxPack
	{
	description = "Arbitor Device";
	shapeFile = "plasammo";
	className = "Backpack";
      heading = $InvHead[ihFFD];
	imageType = ArbitorBoxPackImage;
	shadowDetailMask = 4;
	mass = 2.5;
	elasticity = 0.2;
	price = 420;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function ArbitorBoxPack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
	//Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else
	{
	if (Vector::GetDistance(%deplpos,%teamposa) < 100 || Vector::GetDistance(%deplpos,%teamposb) < 100 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	}
	else
	Player::deployItem(%player,%item);
	}
	}

function ArbitorBoxPack::onDeploy(%player,%item,%pos)
	{
	if (ArbitorBoxPack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
	}

function ArbitorBoxPack::deployShape(%player,%item)
	{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
	if (GameBase::getLOSInfo(%player,10))
	{
	%obj = getObjectType($los::object); 
	if (%obj != "Player") 
	{
	if (Vector::dot($los::normal,"0 0 1") > 0.7)
	{
	%rot = GameBase::getRotation(%player); 
	%turret = newObject("ArbitorBox","Turret",ArbitorBox,true);
      addToSet("MissionCleanup", %turret);
	GameBase::setTeam(%turret,GameBase::getTeam(%player));
	GameBase::setPosition(%turret,$los::position);
	GameBase::setRotation(%turret,%rot);
	Gamebase::setMapName(%turret,"Arbitor Device " @ Client::getName(%client));
	Client::sendMessage(%client,0,"Arbitor Device deployed");
	playSound(SoundPickupBackpack,$los::position);
	$TeamItemCount[GameBase::getTeam(%player) @ "ArbitorBoxPack"]++;
	echo("MSG: ",%client," deployed an Arbitor Box");
	if(Player::getMountedItem(%player, $BackpackSlot) == SCVPack)
	GameBase::setDamageLevel(%turret, 0.7 * ArbitorBox.maxDamage);
	return true;
	}
	else 
	Client::sendMessage(%client,0,"Can only deploy on flat surfaces.");
	}
	else 
	Client::sendMessage(%client,0,"Can't be deployed on players.");
	}
	else 
	Client::sendMessage(%client,0,"Deploy position out of range.");
	}
	else																						  
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "es");
	return false;
	}

function ArbitorBox::onAdd(%this)
	{
	schedule("ArbitorBox::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	if (GameBase::getMapName(%this) == "") 
	GameBase::setMapName (%this, "Arbitor Box");
	}

function ArbitorBox::deploy(%this) { GameBase::playSequence(%this,1,"deploy"); }

function ArbitorBox::onEndSequence(%this,%thread) { GameBase::setActive(%this,true); }

function ArbitorBox::onDisabled(%this)
	{
	Turret::onDisabled(%this);
	%num = Group::objectCount(%this.set);
	for(%i=%num-1; %i >= 0; %i--)
	{
	%obj = Group::getObject(%this.set, %i);
	GameBase::startFadeIn(%obj);
	%obj.cloaked = 0;
	}
	GameBase::setActive(%this,false);
	deleteObject(%this.set);
	}

function ArbitorBox::onDestroyed(%this)
	{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "ArbitorBoxPack"]--;
	}

function ArbitorBox::onPower(%this,%power,%generator) {}

function ArbitorBox::onEnabled(%this) 
	{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType; 
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
	%obj = Group::getObject(%Set, %i);
	if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) && %obj != %this)
	{
	GameBase::startFadeOut(%obj);
	%obj.cloaked = 1;
	}
	}
	%this.set = %Set;
	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 0.25, %this);
	}	

function ArbitorBox::checkArbitorBox(%this)
	{
	if(GameBase::getDamageState(%this) != "Enabled")
	return;
	%this.evenodd = !%this.evenodd; 
	%Set = newObject("set",SimSet); 
	%Pos = GameBase::getPosition(%this); 
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; 
	containerBoxFillSet(%Set, %Mask, %Pos, 200, 200, 50,0);
	%num = Group::objectCount(%Set);
	for(%i; %i < %num; %i++)
	{
	%obj = Group::getObject(%Set, %i);
	if(GameBase::getTeam(%obj) == GameBase::getTeam(%this) && %obj != %this)
	{
	GameBase::startFadeOut(%obj);
	%obj.cloaked = 1 + %this.evenodd; 
	}
	}
	%num = Group::objectCount(%this.set);
	for(%j; %j < %num; %j++)
	{
	%obj = Group::getObject(%this.set, %j);
	if(%obj != %this && GameBase::getTeam(%obj) == GameBase::getTeam(%this))
	if(%obj.cloaked != (%this.evenodd + 1)) 
	{
	%obj.cloaked = 0;
	if(%obj.cloakPack == 0 && %obj.cloakGun == 0) GameBase::startFadeIn(%obj); 
	}
	}
	deleteObject(%this.set); 
	%this.set = %Set; 
	schedule("ArbitorBox::checkArbitorBox(" @ %this @ ");", 6.0, %this); 
	}
////////////////////////////////////////////
ItemImageData JailCapPackImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData JailCapPack
	{
	description = "Jail Capture Trap";
	shapeFile = "discammo";
	className = "Backpack";
	heading = $InvHead[ihFFD];
	imageType = JailCapPackImage;
	shadowDetailMask = 4;
	mass = 1.0;
	elasticity = 0.2;
	price = 500;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function JailCapPack::onUse(%player,%item)
	{
      if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	%client = Player::getClient(%player);
	//Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
      else 
      Player::deployItem(%player,%item);
	}

function JailCapPack::onDeploy(%player,%item,%pos)
	{
      if (JailCapPack::deployShape(%player,%item)) 
      Player::decItemCount(%player,%item);
	}

function JailCapPack::deployShape(%player,%item)
	{
      %client = Player::getClient(%player);
      if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{
      if (GameBase::getLOSInfo(%player,10)) 
	{
	%obj = getObjectType($los::object); 
	if (%obj == "Player")
	{
	Client::sendMessage(%client,0,"Can't be deployed on players");
      return false;
	} 
	%playerPos = GameBase::getPosition(%player);
      %flag = $teamFlag[GameBase::getTeam(%player)];
      %flagpos = gamebase::getPosition(%flag);
	if(Vector::getDistance(%flagpos, %playerpos) < 10)
      {
      Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
      return false;
      }
	%prot = GameBase::getRotation(%player);
      %zRot = getWord(%prot,2);
      %rot =  "1.57079 0 " @ %zRot;
      %padd = "0 0 0";
      %pos = Vector::add($los::position,%padd); 
	%camera = newObject("","StaticShape","jailpad",true);
      addToSet("MissionCleanup", %camera);
      GameBase::setTeam(%camera,GameBase::getTeam(%player));
      GameBase::setRotation(%camera,"0 0 0");
      GameBase::setPosition(%camera,%pos);
      Gamebase::setMapName(%camera,"JailPad " @ Client::getName(%client));
      Client::sendMessage(%client,0,"Jail Pad Deployed");
      playSound(SoundPickupBackpack,$los::position);
      $TeamItemCount[GameBase::getTeam(%player) @ "JailCapPack"]++;
      echo("MSG: ",%client," deployed a Jail Pad");
      return true;
	}
      else 
      Client::sendMessage(%client,0,"Deploy position out of range.");
	}
      else
      Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	return false;
	}
///////////////////////////////////////////
ItemImageData jailpackImage
	{
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	};

ItemData jailpack
	{
	description = "Jail Cell";
	shapeFile = "shieldpack";
	className = "Backpack";
	heading = $InvHead[ihFFD];
	imageType = jailpackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 7000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
	};

function jailpack::onUse(%player,%item)
	{
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	//Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 111 || Vector::getDistance(%deplpos, %teamposb) < 111 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function jailpack::onDeploy(%player,%item,%pos)
	{
	if (jailpack::deployShape(%player,%item))
	Player::decItemCount(%player,%item);
	}

function CreatejailportSimSet()
	{
	%teleset = nameToID("MissionCleanup/jailports");
	if(%teleset == -1)
	{
	newObject("jailports",SimSet);
	addToSet("MissionCleanup","jailports");
	}
	}

function jailpack::deployshape(%player,%item)
	{
	GameBase::getLOSInfo(%player,10);
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ "jailpack"] >= $TeamItemMax[jailpack])
	{
	Client::sendMessage(%client,0,"Can Not Deploy Jail Cell Already In Place");
	return false;
	}
      %objDevice = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide1 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide2 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide3 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide4 = newObject("Jail","Staticshape",LLargeForceField,true);
      %objDevice.objSide5 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide6 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide7 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide8 = newObject("Jail","StaticShape",JailSwitchOpen,true);
      %objDevice.objSide9 = newObject("Jail","StaticShape",LLargeForceField,true);
      %objDevice.objSide10 = newObject("Jail","StaticShape",JailSwitchClose,true);
      %objDevice.objSide1.objParent = %objDevice;
      %objDevice.objSide2.objParent = %objDevice;
      %objDevice.objSide3.objParent = %objDevice;
      %objDevice.objSide4.objParent = %objDevice;
      %objDevice.objSide5.objParent = %objDevice;
      %objDevice.objSide6.objParent = %objDevice;
      %objDevice.objSide7.objParent = %objDevice;
      %objDevice.objSide8.objParent = %objDevice;
      %objDevice.objSide9.objParent = %objDevice;
      %objDevice.objSide10.objParent = %objDevice;
      addToSet(MissionCleanup, %objDevice);
      addToSet(MissionCleanup, %objDevice.objSide1);
      addToSet(MissionCleanup, %objDevice.objSide2);
      addToSet(MissionCleanup, %objDevice.objSide3);
      addToSet(MissionCleanup, %objDevice.objSide4);
      addToSet(MissionCleanup, %objDevice.objSide5);
      addToSet(MissionCleanup, %objDevice.objSide6);
      addToSet(MissionCleanup, %objDevice.objSide7);
      addToSet(MissionCleanup, %objDevice.objSide8);
      addToSet(MissionCleanup, %objDevice.objSide9);
      addToSet(MissionCleanup, %objDevice.objSide10);
      %pos = Vector::add(GameBase::getPosition(%player), "0 1 80");
      GameBase::setRotation(%objDevice.objSide1,"0 0 0");
      GameBase::setPosition(%objDevice.objSide1,%pos);
      GameBase::setTeam(%objDevice.objSide1,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "-5.5 6.5 80");
      GameBase::setRotation(%objDevice.objSide2,"0 0 4.71339");
      GameBase::setPosition(%objDevice.objSide2,%pos);
      GameBase::setTeam(%objDevice.objSide2,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "5.5 6.5 80");
      GameBase::setRotation(%objDevice.objSide3,"0 0 4.71339");
      GameBase::setPosition(%objDevice.objSide3,%pos);
      GameBase::setTeam(%objDevice.objSide3,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 12.5 86");
      GameBase::setRotation(%objDevice.objSide4,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide4,%pos);
      GameBase::setTeam(%objDevice.objSide4,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 .5 86");
      GameBase::setRotation(%objDevice,"4.71339 0 0");
      GameBase::setPosition(%objDevice,%pos);
      GameBase::setTeam(%objDevice,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 12.5 80");
      GameBase::setRotation(%objDevice.objSide6,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide6,%pos);
      GameBase::setTeam(%objDevice.objSide6,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 .5 80");
      GameBase::setRotation(%objDevice.objSide7,"4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide7,%pos);
      GameBase::setTeam(%objDevice.objSide7,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "-5 13 80.00");
      GameBase::setRotation(%objDevice.objSide8,"0 0 0");
      GameBase::setPosition(%objDevice.objSide8,%pos);
      GameBase::setTeam(%objDevice.objSide8,GameBase::getTeam(%player));
      %pos = Vector::add(GameBase::getPosition(%player), "0 18 80");
      GameBase::setRotation(%objDevice.objSide9,"-4.71339 0 0");
      GameBase::setPosition(%objDevice.objSide9,%pos);
      GameBase::setTeam(%objDevice.objSide9,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "5 13 80.00");
	GameBase::setRotation(%objDevice.objSide10,"0 0 0");
	GameBase::setPosition(%objDevice.objSide10,%pos);
	GameBase::setTeam(%objDevice.objSide10,GameBase::getTeam(%player));
	playSound(SoundPickupBackpack,$los::position);
	newObject("jaildoor",SimSet);
	addToSet("MissionCleanup","jaildoor");
	%sensor = newObject("jaildoor","StaticShape",jLargeForceField,true);
	addToSet("MissionCleanup/jaildoor", %sensor);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 12 80");
	GameBase::setPosition(%sensor,%pos);
	GameBase::setRotation(%sensor,"0 0 0");
	%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	%sensor = newObject("Teleport Pad","StaticShape","jailStand",true);
	CreatejailportSimSet();
	addToSet("MissionCleanup/jailports", %sensor);
	addToSet("MissionCleanup", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 81");
	GameBase::setPosition(%sensor,%pos);
	Gamebase::setMapName(%sensor,%name);
	%sensor.disabled = false;
	playSound(SoundPickupBackpack,$los::position);
	%beam = newObject("","StaticShape",ElectricalBeamBig,true);
	addToSet("MissionCleanup", %beam);
	GameBase::setTeam(%beam,GameBase::getTeam(%player));
	GameBase::setPosition(%beam,%pos);
	%sensor.beam1 = %beam;
	playSound(SoundPickupBackpack,$los::position);
	newObject("releasepad",SimSet);
	CreatereleasepadSimSet();
	addToSet("MissionCleanup/releasepad", %sensor);
	addToSet("MissionCleanup", %sensor);
	%sensor = newObject("releasepad","StaticShape","jailStandTop",true);
	addToSet("MissionCleanup/releasepad", %sensor);
	GameBase::setTeam(%sensor,GameBase::getTeam(%player));
	%pos = Vector::add(GameBase::getPosition(%player), "0 3 86.30");
	GameBase::setPosition(%sensor,%pos);
	Gamebase::setMapName(%sensor,%name);
	%sensor.disabled = false;
	$TeamItemCount[GameBase::getTeam(%sensor) @ "jailpack"]++;
	echo("MSG: ",%client," deployed a Jail Cell");
	Client::sendMessage(%client,0,%item.description @ " deployed 250' Up");
	return true;
	}

function ToJail(%client,%team)
{
	
	%player = Client::getOwnedObject(%client);
	echo("jailed pl# "@%player);
	%player.invulnerable = true;

		schedule("prisonguard("@%client@");",1);
		%name = Client::getName(%Client);
		GameBase::SetPosition(%client, $JailPosition[%Team]);		
		Client::SendMessage(%client,0,"Your jail sentence will last 30 seconds.");
		schedule("JailBreak(" @ %client @ ", " @ %team @ ");",30);
		schedule("JailBird(" @ %client @ ", " @ %team @ ");",1);		
		if(GameBase::getControlClient(%player) != %client){
		//yank em outa that turret or vehicle NYPD style!
			if(%player.ManualCommandTag)
				{	
				%player.ManualCommandTag = False;
				%player.CommandTag = "";
				}
			Player::setMountObject(%player, -1,0);
			Client::setControlObject(%client, %player);	
		
		}

}

function prisonguard(%client)
{
	%player = Client::getOwnedObject(%client);
	%player.jailed = true;
}

function JailBird(%client, %team)
{	
	%player = Client::getOwnedObject(%client);
	if(Player::isDead(%player)) return;
	%playerPos = GameBase::getPosition(%player);
	%playerdist = Vector::getDistance($JailPosition[%Team], %playerpos);
	if(%playerdist > 10)
		{
		Client::SendMessage(%client, 0, "You've escaped! Run Forrest Run!!!!");	
		Messageallexcept(%client,0,Client::getName(%client)@" escaped from jail.");				
		schedule("ParoleGrace("@%client@");",5);
		%player = Client::getOwnedObject(%client);
		%player.jailed = false;	
		}
	if(%player.jailed)  schedule("JailBird(" @ %client @ ", " @ %team @ ");",1);
}






//plasmatic
function JailBreak(%client, %team)
{
	%player = Client::getOwnedObject(%client);
//	echo("jail client "@%client@" player# "@%player@" in team's "@ %team@" jail");
	%playerPos = GameBase::getPosition(%player);
	%playerdist = Vector::getDistance($JailPosition[%Team], %playerpos);
	schedule("ParoleGrace("@%client@");",5);
//	echo("%playerdist "@%playerdist);
	if(%playerdist < 10){	
		%posX = getWord($JailPosition[%Team], 0);
		%posY = getWord($JailPosition[%Team], 1);
		%posZ = getWord($JailPosition[%Team], 2) + 10;
		%freeplayerpos = %posX@" "@%posY@" "@%posZ;
		GameBase::SetPosition(%client, %freeplayerpos);
		Client::SendMessage(%client, 0, "You Have Been Released. Run Forrest Run!!!!~wshieldhit.wav");
		Messageallexcept(%client,0,Client::getName(%client)@" Was paroled early from jail.");
		%player.jailed = "";
	}
}

function ParoleGrace(%client){
	%player = Client::getOwnedObject(%client);
	%player.invulnerable = "";
	%player.jailed = "";
//	echo("jail grace over");
	}

function CreatereleasepadSimSet()
	{
	%teleset = nameToID("MissionCleanup/releasepad");
	if(%teleset == -1)
	{
	newObject("releasepad",SimSet);
	addToSet("MissionCleanup","releasepad");
	}
	}



//----------------------------------------------------------------------------
ItemImageData RemoteBaseImage 
	{ 
	shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
	firstPerson = false;
	}; 

ItemData RemoteBase 
	{ 
	description = "Remote Base"; 
	shapeFile = "discammo"; 
	className = "Backpack"; 
	heading = $InvHead[ihFFD];
	imageType = RemoteBaseImage; 
	shadowDetailMask = 4; 
	mass = 2.5; 
	elasticity = 0.2; 
	price = 8000; 
	hudIcon = "deployable"; 
	showWeaponBar = true; 
	hiliteOnActive = true; 
	}; 

function RemoteBase::onUse(%player,%item) 
	{
	if(getObjectType(%player) != "Player") return; // PORT: Remote* = client-callable; a client call passes a client id here
	%client = Player::getClient(%player);
	%teamposa = ($teamFlag[0]).originalPosition;
	%teamposb = ($teamFlag[1]).originalPosition;
	%deplteam = GameBase::getTeam(%player);
	%deplpos = GameBase::getPosition(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{
	//Client::sendMessage(%client,0,$TeamItemCount[Gamebase::getTeam(%player)@%item] @ "  " @ %item.description @ "s deployed out of " @ $TeamItemMax[%item]); 
	Player::mountItem(%player,%item,$BackpackSlot);
	} 
	else 
	{
	if (Vector::getDistance(%deplpos, %teamposa) < 100 || Vector::getDistance(%deplpos, %teamposb) < 100 )
	{
	Client::sendMessage(%client,0,"You are too close to the base!");
	Player::mountItem(%player,%item,$BackpackSlot);
	return;
	} 
	else 
	Player::deployItem(%player,%item);
	}
	}

function RemoteBase::onDeploy(%player,%item,%pos) 
	{ 
	if(getObjectType(%player) != "Player") return; // PORT: Remote* = client-callable; a client call passes a client id here
	if (RemoteBase::deployShape(%player,%item)) 
	{ 
	Player::decItemCount(%player,%item); 
	$TeamItemCount[GameBase::getTeam(%player) @ "RemoteBase"]++;
	} 
	} 

function RemoteBase::deployShape(%player,%item) 
	{ 
	if(getObjectType(%player) != "Player") return; // PORT: Remote* = client-callable; a client call passes a client id here
	%client = Player::getClient(%player);
	%playpos = GameBase::getPosition(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) 
	{ 
	if (GameBase::getLOSInfo(%player,20)) 
	{ 
	%obj = getObjectType($los::object);
	if (%obj == "SimTerrain" || %obj == "Large Platform") 
	{ 
	if(Vector::GetDistance(%playpos,$los::position) > 9 ) 
	{
	%base = newObject("Remotebase",InteriorShape,"bunker4.dis",false);
	%base.basebackwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baseleftwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baserightwall = newObject("Remotebase","Staticshape",bLargeForceField,true);
	%base.baseturret = newObject("Remotebase","Turret",PlasmaTurret,false);
	%base.basesolar = newObject("Remotebase","StaticShape",SolarPanel,false);
	%base.basestation = newObject("Remotebase","StaticShape",InventoryStation,false);
	%base.basedoor = newObject("Remotebase","Staticshape",bdForceField,true);
	%base.basedoor.objParent = %base;
	%base.basebackwall.objParent = %base;
	%base.baseleftwall.objParent = %base;
	%base.baserightwall.objParent = %base;
	%base.baseturret.objParent = %base;
	%base.basesolar.objParent = %base;
	%base.basestation.objParent = %base;
	addToSet("MissionCleanup", %base);
	addToSet("MissionCleanup", %base.basebackwall);
	addToSet("MissionCleanup", %base.baseleftwall);
	addToSet("MissionCleanup", %base.baserightwall);
	addToSet("MissionCleanup", %base.baseturret);
	addToSet("MissionCleanup", %base.basesolar);
	addToSet("MissionCleanup", %base.basedoor);
	addToSet("MissionCleanup", %base.basestation);
	GameBase::setTeam(%base,GameBase::getTeam(%player));
	GameBase::setPosition(%base,$los::position);
	GameBase::setRotation(%base,"0 0 0");
	%pos = Vector::add($los::position, "0 5.875 0");
	GameBase::setRotation(%base.basebackwall,"0 0 0");
	GameBase::setPosition(%base.basebackwall,%pos);
	GameBase::setTeam(%base.basebackwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 -5.875 0");
	GameBase::setRotation(%base.basedoor,"0 0 0");
	GameBase::setPosition(%base.basedoor,%pos);
	GameBase::setTeam(%base.basedoor,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "-5.875 0 0");
	GameBase::setRotation(%base.baseleftwall,"0 0 4.7125");
	GameBase::setPosition(%base.baseleftwall,%pos);
	GameBase::setTeam(%base.baseleftwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "5.875 0 0");
	GameBase::setRotation(%base.baserightwall,"0 0 4.7125");
	GameBase::setPosition(%base.baserightwall,%pos);
	GameBase::setTeam(%base.baserightwall,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 0.2 9.77");
	GameBase::setRotation(%base.baseturret,"0 0 0");
	GameBase::setPosition(%base.baseturret,%pos);
	GameBase::setTeam(%base.baseturret,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 -0.2 9.50");
	GameBase::setRotation(%base.basesolar,"0 0 0");
	GameBase::setPosition(%base.basesolar,%pos);
	GameBase::setTeam(%base.basesolar,GameBase::getTeam(%player));
	%pos = Vector::add($los::position, "0 3 1");
	GameBase::setRotation(%base.basestation,"0 0 0");
	GameBase::setPosition(%base.basestation,%pos);
	GameBase::setTeam(%base.basestation,GameBase::getTeam(%player));
	$TeamItemCount[GameBase::getTeam(%sensor) @ "RemoteBase"]++;
	Gamebase::setMapName(%base,"Remote Base " @ Client::getName(%client));
	Client::setOwnedObject(%client, %base);
      Client::setOwnedObject(%client, %player);
	Client::sendMessage(%client,0,"Remote base deployed"); 
	playSound(SoundPickupBackpack,$los::position); 
	echo("MSG: ",%client," deployed a Remote Base"); 
	return true; 
	}
	else 
	Client::sendMessage(%client,0,"You are too close to the deploy position."); 
	} 
	else 
	Client::sendMessage(%client,0,"Can only be deployed on terrain."); 
	} 
	else 
	Client::sendMessage(%client,0,"Deploy position out of range"); 
	} 
	else 
	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s"); 
	return false; 
	} 
//----------------------------------------------------------------------------

function deployAirBase::Initialize()
{	
	$TeamItemCount[0 @ AirBasePack] = 0;
	$TeamItemCount[1 @ AirBasePack] = 0;
	$TeamItemCount[2 @ AirBasePack] = 0;
	$TeamItemCount[3 @ AirBasePack] = 0;
	$TeamItemCount[4 @ AirBasePack] = 0;
	$TeamItemCount[5 @ AirBasePack] = 0;
	$TeamItemCount[6 @ AirBasePack] = 0;
	$TeamItemCount[7 @ AirBasePack] = 0;
}

ItemImageData AirBasePackImage
	{
      shapeFile = "discammo"; 
	mountPoint = 2; 
	mountOffset = { 0, 0, 0.125 };
	mountRotation = { 90, 0, 0 }; 
	mass = 2.5;
      firstPerson = false;
	};

ItemData AirBasePack
{	
	description = "Sky Base";
	shapeFile = "Discammo";
	className = "Backpack";
	heading = $InvHead[ihFFD];
	imageType = AirBasePackImage;
	shadowDetailMask = 4;
	mass = 5.0;
	elasticity = 0.2;
	price = 10000;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

StaticShapeData AirBaseForceFieldLarge
{
	shapeFile = "forcefield";
	debrisId = defaultDebrisLarge;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Sky Base";
};

StaticShapeData AirBaseForceFieldSmall
{
	shapeFile = "ForceField_4x8";
	debrisId = defaultDebrisSmall;
	maxDamage = 50000;
	visibleToSensor = true;
	isTranslucent = true;
	description = "Mod By: *DK*SlipKnot*";
};

function AirBasePack::onUse(%player,%item)
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::deployItem(%player,%item);
}

function AirBasePack::onDeploy(%player,%item,%pos)
{	if(AirBasePack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CreateAirBaseSimSet(%team)
{
	%teleset = nameToID("MissionCleanup/AirBase" @ %team);
	if(%teleset == -1)
	{
		newObject("AirBase" @ %team,SimSet);
		addToSet("MissionCleanup","AirBase" @ %team);
	}
}

function AirBasePack::deployshape(%player,%item)
{
	%name = "Air Base";
	%team = GameBase::getTeam(%player);

	%client = Player::getClient(%player);

	if(!GameBase::getLOSInfo(%player,3))
	{
		Client::sendMessage(%client,0,"Deploy position too far away");
		return false;
	}
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item])
	{
		Client::sendMessage(%client,0,"Can Not Deploy A Sky Base is Already In-Use");
		return false;
	}
	%playerpos = GameBase::getPosition(%player);
	%team = GameBase::getTeam(%player);
	%flag = $teamFlag[%team];
	%flagpos = gamebase::getPosition(%flag);

	if(Vector::getDistance(%flagpos, %playerpos) < 50)
	{
		Client::sendMessage(%client,0,"You are too close to your flag, Must be further from flag to deploy.");
		return ;
	}
	%obj = getObjectType($los::object);
	if(%obj != "SimTerrain") 
	{
		Client::sendMessage(%client,0,"Can only deploy on terrain");
		return false;
	}
	CreateAirBaseSimSet(%team);
	
//	echo(%playerpos);
	%posX = getWord(%playerpos, 0);
	%posY = getWord(%playerpos, 1);
	%posZ = getWord(%playerpos, 2) + 300;
	%playerpos = %posX@" "@%posY@" "@%posZ;
	//%playerpos = "0 0 0";

	// Tower Floor
	%object = newObject("Air Base","InteriorShape", "BEMfloatingPad.dis");
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-5 -5 0");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
//	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);

	// Tower Roof
	%object = newObject("Air Base","InteriorShape", "BESfloatingPad.dis");
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	addToSet(MissionCleanup, %object);
	%pos = Vector::add(%playerpos, "0 0 38");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 3.14159 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);

	// Force Field Wall
	%object = newObject("Air Base","StaticShape",AirBaseForceFieldLarge,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "5.8746 0 14.5");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 1.570796";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base Small1","StaticShape",AirBaseForceFieldSmall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-5.75 2.05 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 1.570796";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base","StaticShape",AirBaseForceFieldLarge,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "0 5.8746 14.5");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395");
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	// Force Field Wall
	%object = newObject("Air Base Small","StaticShape",AirBaseForceFieldSmall,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "2.03 -5.75 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,%name);
	
	%object = newObject("Vehicle Station","StaticShape",VehicleStation,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-3.60177 3.95522 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0.7853981";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Vehicle Station");
	
	%object = newObject("Vehicle Pad","StaticShape",VehiclePad,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-10.6862 -11.1697 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 -0 2.3561944";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Vehicle Pad");
	
	%object = newObject("Inventory Station","StaticShape",InventoryStation,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "3.69689 -3.64708 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -2.3561944";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Inventory Station");
	
	%object = newObject("Command Station","StaticShape",CommandStation,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "4.25588 4.13451 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -0.7853981";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Command Station");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "-7.49755 1.43987 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 -1.5707963";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Solar Panel");
	
	%object = newObject("Solar Panel","StaticShape",SolarPanel,false);
	addToSet(MissionCleanup, %object);
	addToSet("MissionCleanup/AirBase" @ %team, %object);
	%pos = Vector::add(%playerpos, "1.58014 -7.45512 16");
	//%rot = Vector::add(GameBase::getRotation(%player), "0 0 0.395"); -5.9946
	%rot = "0 0 0";
	GameBase::setRotation(%object,%rot);
	GameBase::setPosition(%object,%pos);
	GameBase::setTeam(%object,%team);
	Gamebase::setMapName(%object,"Sky Base Solar Panel 2");

	$TeamItemCount[%team @ %item]++;
	echo("MSG: ",%client," deployed a Sky Base");
	Client::sendMessage(%client,0,%item.description @ " Built 300 meters up");
	playSound(SoundPickupBackpack,$los::position);
	return true;
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

$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 35;
   //validateShape = true;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item)
{
	if(!$UltraZX::Infinite::RepairKit)
	{
		Player::decItemCount(%player,%item);
	}
	GameBase::repairDamage(%player,0.99);
}

//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
   //validateShape = true;
   validateMaterials = true;
};

function MineAmmo::onUse(%player,%item)
{
        if($matchStarted) {
                if(%player.throwTime < getSimTime() ) 
                {
                	if(!$UltraZX::Infinite::Mine)
                	{
                        	Player::decItemCount(%player,%item);
                        }
                        %obj = newObject("","Mine","antipersonelMine");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                        %player.throwTime = getSimTime() + 0.5;
                  GameBase::setTeam (%obj,GameBase::getTeam (%client));
                }
        }
}

//----------------------------------------------------------------------
ItemData RadiusMineAmmo
{
   description = "Radius Mine";
   shapeFile = "mineammo";
heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 10;
        className = "HandAmmo";
};

function RadiusMineAmmo::onUse(%player,%item)
{
        if($matchStarted) {
                if(%player.throwTime < getSimTime() ) {
                	if(!$UltraZX::Infinite::RadiusMine)
                	{
                        	Player::decItemCount(%player,%item);
                        }
                        %obj = newObject("","Mine","radiusMine");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
                        %player.throwTime = getSimTime() + 0.5;
                  GameBase::setTeam (%obj,GameBase::getTeam (%client));
                }
        }
}

//---------------------------------------------------------------------------
ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   //validateShape = true;
   validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	Item::setvelocity(%player,0);
      //client::sendmessage(player::getclient(%player),0,"Air Break Applied.~wLand_On_Ground.wav");
	if(!$UltraZX::Infinite::Brake)
	{
		Player::decItemCount(%player,%item);
	}
}



//----------------------------------------------------------------------------



//----------------------------------------------------------------------------



//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = $InvHead[ihMis];
   shadowDetailMask = 4;
   price = 5;
        className = "HandAmmo";
};

function Beacon::onUse(%player,%item)
{
        //if (Beacon::deployShape(%player,%item)) {
        //        Player::decItemCount(%player,%item);
        //}
                if($matchStarted) {
                if(%player.throwTime < getSimTime() ) {
                        if(!$UltraZX::Infinite::Boost)
                        	Player::decItemCount(%player,%item);
                        %obj = newObject("","Mine","boost");
                         addToSet("MissionCleanup", %obj);
                        %client = Player::getClient(%player);
                        GameBase::throw(%obj,%player,0,false);
                        %player.throwTime = getSimTime() + 0.2;
                        //Client::sendMessage(Player::getClient(%player),0,"Speed Boost Applied.~wseek_fire.wav");
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
   heading = $InvHead[ihMis];
	shadowDetailMask = 4;
  	price = 2;
   //validateShape = true;
   validateMaterials = true;
};

function RepairPatch::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		if(GameBase::getDamageLevel(%object)) {
			GameBase::repairDamage(%object,0.5);
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

ItemImageData 	cactuspackImage
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

ItemData cactusPack
{
        description = "Flag Pack";
        shapeFile = "flag";
        className = "Backpack";
      heading = $InvHead[ihBac];
        imageType = cactuspackImage;
        shadowDetailMask = 4;
        mass = 1;
        elasticity = 0.2;
        price = 200;
        hudIcon = "flag";
        showWeaponBar = true;
        hiliteOnActive = true;
};

///////////////////////////////////////////////////////////////////////////////////

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
	
	//--VX-

	$TeamItemCount[0 @ MercJetVehicle] = 0;
	$TeamItemCount[1 @ MercJetVehicle] = 0;
	$TeamItemCount[2 @ MercJetVehicle] = 0;
	$TeamItemCount[3 @ MercJetVehicle] = 0;
	$TeamItemCount[4 @ MercJetVehicle] = 0;
	$TeamItemCount[5 @ MercJetVehicle] = 0;
      $TeamItemCount[6 @ MercJetVehicle] = 0;
	$TeamItemCount[7 @ MercJetVehicle] = 0;
	
	$TeamItemCount[0 @ LaserTurretPack] = 0;
	$TeamItemCount[1 @ LaserTurretPack] = 0;
	$TeamItemCount[2 @ LaserTurretPack] = 0;
	$TeamItemCount[3 @ LaserTurretPack] = 0;
	$TeamItemCount[4 @ LaserTurretPack] = 0;
	$TeamItemCount[5 @ LaserTurretPack] = 0;
        $TeamItemCount[6 @ LaserTurretPack] = 0;
	$TeamItemCount[7 @ LaserTurretPack] = 0;

	$TeamItemCount[0 @ MaliceTurretPack] = 0;
	$TeamItemCount[1 @ MaliceTurretPack] = 0;
	$TeamItemCount[2 @ MaliceTurretPack] = 0;
	$TeamItemCount[3 @ MaliceTurretPack] = 0;
	$TeamItemCount[4 @ MaliceTurretPack] = 0;
	$TeamItemCount[5 @ MaliceTurretPack] = 0;
	$TeamItemCount[6 @ MaliceTurretPack] = 0;
	$TeamItemCount[7 @ MaliceTurretPack] = 0;
	
	$TeamItemCount[0 @ LaserTurretBPack] = 0;
	$TeamItemCount[1 @ LaserTurretBPack] = 0;
	$TeamItemCount[2 @ LaserTurretBPack] = 0;
	$TeamItemCount[3 @ LaserTurretBPack] = 0;
	$TeamItemCount[4 @ LaserTurretBPack] = 0;
	$TeamItemCount[5 @ LaserTurretBPack] = 0;
	$TeamItemCount[6 @ LaserTurretBPack] = 0;
	$TeamItemCount[7 @ LaserTurretBPack] = 0;
	
	$TeamItemCount[0 @ TaserTrtBPack] = 0;
	$TeamItemCount[1 @ TaserTrtBPack] = 0;
	$TeamItemCount[2 @ TaserTrtBPack] = 0;
	$TeamItemCount[3 @ TaserTrtBPack] = 0;
	$TeamItemCount[4 @ TaserTrtBPack] = 0;
	$TeamItemCount[5 @ TaserTrtBPack] = 0;
	$TeamItemCount[6 @ TaserTrtBPack] = 0;
	$TeamItemCount[7 @ TaserTrtBPack] = 0;
	
	$TeamItemCount[0 @ TaserTrtCPack] = 0;
	$TeamItemCount[1 @ TaserTrtCPack] = 0;
	$TeamItemCount[2 @ TaserTrtCPack] = 0;
	$TeamItemCount[3 @ TaserTrtCPack] = 0;
	$TeamItemCount[4 @ TaserTrtCPack] = 0;
	$TeamItemCount[5 @ TaserTrtCPack] = 0;
	$TeamItemCount[6 @ TaserTrtCPack] = 0;
	$TeamItemCount[7 @ TaserTrtCPack] = 0;
	
	$TeamItemCount[0 @ MiniFlakTurretPack] = 0;
	$TeamItemCount[1 @ MiniFlakTurretPack] = 0;
	$TeamItemCount[2 @ MiniFlakTurretPack] = 0;
	$TeamItemCount[3 @ MiniFlakTurretPack] = 0;
	$TeamItemCount[4 @ MiniFlakTurretPack] = 0;
	$TeamItemCount[5 @ MiniFlakTurretPack] = 0;
        $TeamItemCount[6 @ MiniFlakTurretPack] = 0;
	$TeamItemCount[7 @ MiniFlakTurretPack] = 0;
	
	$TeamItemCount[0 @ MiniSAMTurretPack] = 0;
	$TeamItemCount[1 @ MiniSAMTurretPack] = 0;
	$TeamItemCount[2 @ MiniSAMTurretPack] = 0;
	$TeamItemCount[3 @ MiniSAMTurretPack] = 0;
	$TeamItemCount[4 @ MiniSAMTurretPack] = 0;
	$TeamItemCount[5 @ MiniSAMTurretPack] = 0;
        $TeamItemCount[6 @ MiniSAMTurretPack] = 0;
	$TeamItemCount[7 @ MiniSAMTurretPack] = 0;
	
	$TeamItemCount[0 @ MiniELFTurretPack] = 0;
	$TeamItemCount[1 @ MiniELFTurretPack] = 0;
	$TeamItemCount[2 @ MiniELFTurretPack] = 0;
	$TeamItemCount[3 @ MiniELFTurretPack] = 0;
	$TeamItemCount[4 @ MiniELFTurretPack] = 0;
	$TeamItemCount[5 @ MiniELFTurretPack] = 0;
	$TeamItemCount[6 @ MiniELFTurretPack] = 0;
	$TeamItemCount[7 @ MiniELFTurretPack] = 0;
	
	$TeamItemCount[0 @ MiniSmokeTurretPack] = 0;
	$TeamItemCount[1 @ MiniSmokeTurretPack] = 0;
	$TeamItemCount[2 @ MiniSmokeTurretPack] = 0;
	$TeamItemCount[3 @ MiniSmokeTurretPack] = 0;
	$TeamItemCount[4 @ MiniSmokeTurretPack] = 0;
	$TeamItemCount[5 @ MiniSmokeTurretPack] = 0;
	$TeamItemCount[6 @ MiniSmokeTurretPack] = 0;
	$TeamItemCount[7 @ MiniSmokeTurretPack] = 0;
	
	$TeamItemCount[0 @ lgaForceFieldPack] = 0;
	$TeamItemCount[1 @ lgaForceFieldPack] = 0;
	$TeamItemCount[2 @ lgaForceFieldPack] = 0;
	$TeamItemCount[3 @ lgaForceFieldPack] = 0;
	$TeamItemCount[4 @ lgaForceFieldPack] = 0;
	$TeamItemCount[5 @ lgaForceFieldPack] = 0;
	$TeamItemCount[6 @ lgaForceFieldPack] = 0;
	$TeamItemCount[7 @ lgaForceFieldPack] = 0;
	       
	$TeamItemCount[0 @ lgbForceFieldPack] = 0;
	$TeamItemCount[1 @ lgbForceFieldPack] = 0;
	$TeamItemCount[2 @ lgbForceFieldPack] = 0;
	$TeamItemCount[3 @ lgbForceFieldPack] = 0;
	$TeamItemCount[4 @ lgbForceFieldPack] = 0;
	$TeamItemCount[5 @ lgbForceFieldPack] = 0;
	$TeamItemCount[6 @ lgbForceFieldPack] = 0;
	$TeamItemCount[7 @ lgbForceFieldPack] = 0;
	       
	       
	$TeamItemCount[0 @ medaForceFieldPack] = 0;
	$TeamItemCount[1 @ medaForceFieldPack] = 0;
	$TeamItemCount[2 @ medaForceFieldPack] = 0;
	$TeamItemCount[3 @ medaForceFieldPack] = 0;
	$TeamItemCount[4 @ medaForceFieldPack] = 0;
	$TeamItemCount[5 @ medaForceFieldPack] = 0;
	$TeamItemCount[6 @ medaForceFieldPack] = 0;
	$TeamItemCount[7 @ medaForceFieldPack] = 0;
	       
	$TeamItemCount[0 @ medbForceFieldPack] = 0;
	$TeamItemCount[1 @ medbForceFieldPack] = 0;
	$TeamItemCount[2 @ medbForceFieldPack] = 0;
	$TeamItemCount[3 @ medbForceFieldPack] = 0;
	$TeamItemCount[4 @ medbForceFieldPack] = 0;
	$TeamItemCount[5 @ medbForceFieldPack] = 0;
	$TeamItemCount[6 @ medbForceFieldPack] = 0;
	$TeamItemCount[7 @ medbForceFieldPack] = 0;
	              
	$TeamItemCount[0 @ medcForceFieldPack] = 0;
	$TeamItemCount[1 @ medcForceFieldPack] = 0;
	$TeamItemCount[2 @ medcForceFieldPack] = 0;
	$TeamItemCount[3 @ medcForceFieldPack] = 0;
	$TeamItemCount[4 @ medcForceFieldPack] = 0;
	$TeamItemCount[5 @ medcForceFieldPack] = 0;
	$TeamItemCount[6 @ medcForceFieldPack] = 0;
        $TeamItemCount[7 @ medcForceFieldPack] = 0;
        
	$TeamItemCount[0 @ ElectricWeb] = 0;
	$TeamItemCount[1 @ ElectricWeb] = 0;
	$TeamItemCount[2 @ ElectricWeb] = 0;
	$TeamItemCount[3 @ ElectricWeb] = 0;
	$TeamItemCount[4 @ ElectricWeb] = 0;
	$TeamItemCount[5 @ ElectricWeb] = 0;
	$TeamItemCount[6 @ ElectricWeb] = 0;
        $TeamItemCount[7 @ ElectricWeb] = 0; 

        $TeamItemCount[0 @ DeployableTeleport] = 0;
	$TeamItemCount[1 @ DeployableTeleport] = 0;
	$TeamItemCount[2 @ DeployableTeleport] = 0;
	$TeamItemCount[3 @ DeployableTeleport] = 0;
	$TeamItemCount[4 @ DeployableTeleport] = 0;
	$TeamItemCount[5 @ DeployableTeleport] = 0;
	$TeamItemCount[6 @ DeployableTeleport] = 0;
	$TeamItemCount[7 @ DeployableTeleport] = 0;
	
        $TeamItemCount[0 @ RadiusMineAmmo] = 0;
	$TeamItemCount[1 @ RadiusMineAmmo] = 0;
	$TeamItemCount[2 @ RadiusMineAmmo] = 0;
	$TeamItemCount[3 @ RadiusMineAmmo] = 0;
	$TeamItemCount[4 @ RadiusMineAmmo] = 0;
	$TeamItemCount[5 @ RadiusMineAmmo] = 0;
	$TeamItemCount[6 @ RadiusMineAmmo] = 0;
	$TeamItemCount[7 @ RadiusMineAmmo] = 0;
	
	
        $TeamItemCount[0 @ cactuspack] = 0;
	$TeamItemCount[1 @ cactuspack] = 0;
	$TeamItemCount[2 @ cactuspack] = 0;
	$TeamItemCount[3 @ cactuspack] = 0;
	$TeamItemCount[4 @ cactuspack] = 0;
	$TeamItemCount[5 @ cactuspack] = 0;
	$TeamItemCount[6 @ cactuspack] = 0;
	$TeamItemCount[7 @ cactuspack] = 0;

        $TeamItemCount[0 @ BaseAlarm] = 0;
	$TeamItemCount[1 @ BaseAlarm] = 0;
	$TeamItemCount[2 @ BaseAlarm] = 0;
	$TeamItemCount[3 @ BaseAlarm] = 0;
	$TeamItemCount[4 @ BaseAlarm] = 0;
	$TeamItemCount[5 @ BaseAlarm] = 0;
	$TeamItemCount[6 @ BaseAlarm] = 0;
	$TeamItemCount[7 @ BaseAlarm] = 0;

        $TeamItemCount[0 @ ArbitorBoxPack] = 0;
	$TeamItemCount[1 @ ArbitorBoxPack] = 0;
	$TeamItemCount[2 @ ArbitorBoxPack] = 0;
	$TeamItemCount[3 @ ArbitorBoxPack] = 0;
	$TeamItemCount[4 @ ArbitorBoxPack] = 0;
	$TeamItemCount[5 @ ArbitorBoxPack] = 0;
	$TeamItemCount[6 @ ArbitorBoxPack] = 0;
	$TeamItemCount[7 @ ArbitorBoxPack] = 0;

	  $TeamItemCount[0 @ JailCappack] = 0;
	$TeamItemCount[1 @ JailCappack] = 0;
	$TeamItemCount[2 @ JailCappack] = 0;
	$TeamItemCount[3 @ JailCappack] = 0;
	$TeamItemCount[4 @ JailCappack] = 0;
	$TeamItemCount[5 @ JailCappack] = 0;
	$TeamItemCount[6 @ JailCappack] = 0;
	$TeamItemCount[7 @ JailCappack] = 0;

	  $TeamItemCount[0 @ Jailpack] = 0;
	$TeamItemCount[1 @ Jailpack] = 0;
	$TeamItemCount[2 @ Jailpack] = 0;
	$TeamItemCount[3 @ Jailpack] = 0;
	$TeamItemCount[4 @ Jailpack] = 0;
	$TeamItemCount[5 @ Jailpack] = 0;
	$TeamItemCount[6 @ Jailpack] = 0;
	$TeamItemCount[7 @ Jailpack] = 0;

	  $TeamItemCount[0 @ RemoteBase] = 0;
	$TeamItemCount[1 @ RemoteBase] = 0;
	$TeamItemCount[2 @ RemoteBase] = 0;
	$TeamItemCount[3 @ RemoteBase] = 0;
	$TeamItemCount[4 @ RemoteBase] = 0;
	$TeamItemCount[5 @ RemoteBase] = 0;
	$TeamItemCount[6 @ RemoteBase] = 0;
	$TeamItemCount[7 @ RemoteBase] = 0;

	  $TeamItemCount[0 @ AirBasePack] = 0;
	$TeamItemCount[1 @ AirBasePack] = 0;
	$TeamItemCount[2 @ AirBasePack] = 0;
	$TeamItemCount[3 @ AirBasePack] = 0;
	$TeamItemCount[4 @ AirBasePack] = 0;
	$TeamItemCount[5 @ AirBasePack] = 0;
	$TeamItemCount[6 @ AirBasePack] = 0;
	$TeamItemCount[7 @ AirBasePack] = 0;
	
	//--VX

	$totalNumCameras = 0;
	$totalNumTurrets = 0;


	for(%i = -1; %i < 8 ; %i++)
		$TeamEnergy[%i] = $DefaultTeamEnergy; 
}
