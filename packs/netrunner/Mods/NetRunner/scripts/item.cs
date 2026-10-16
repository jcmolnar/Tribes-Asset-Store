//----------------------------------------------------------------------------
$ItemFavoritesKey = "NetRunner100";	// Change this if you add new items
						// and don't want to mess up everyone's
						// favorites - just put in something
						// that uniquely describes your new stuff.
//----------------------------------------------------------------------------
$ToolSlot=0;
$WeaponSlot=0;
$BackpackSlot=1;
$FlagSlot=2;
$DefaultSlot=3;

$InvHead[iVehi] = "aTransportation";
$InvHead[iDeck] = "aDecks";
$InvHead[iOffe] = "bOffensive Software";
$InvHead[iTool] = "cUtilities";
$InvHead[iEnha] = "dEnhansive Software";
$InvHead[iNetw] = "eNetworks";
$InvHead[iDefe] = "fDefensive Software";
$InvHead[iTurr] = "gICE";
$InvHead[iMisc] = "hMiscellaneous";
$InvHead[iUpgr] = "iUpgrades";
$InvHead[iRelo] = "xReloads";

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
	if(!$InfiniteCreds)
	{
		%client.creds += %cost;
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
	if (isPlayerBusy(%client)) return;
// only can buy fav every 1/2 second
	%time = getIntegerTime(true) >> 4; // int half seconds
	if(%time <= %client.lastBuyFavTime) return;
	%client.lastBuyFavTime = %time;
	%station = (Client::getOwnedObject(%client)).Station;
	if(%station != "" )
	{
		%energy = %client.creds;
		if($InfiniteCreds || %energy > 0)
		{
			%error = 0;
			%bought = 0;
			%max = getNumItems();
			for (%i = 0; %i < %max; %i = %i + 1)
			{
				%item = getItemData(%i);
				if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats)
				{
					%count = Player::getItemCount(%client,%item);
					if(%count)
					{
						if(%item.className != Armor) 
						teamEnergyBuySell(Client::getOwnedObject(%client),(%item.price * %count));
						Player::setItemCount(%client, %item, 0);
					}
				}
			}
			for (%i = 0; %i < 20; %i++)
			{
				if(%favItem[%i] != "")
				{
					%item = getItemData(%favItem[%i]);
					if ((Client::isItemShoppingOn(%client,%item)) && ($ItemMax[Player::getArmor(%client),%item] > Player::getItemCount(%client,%item) || %item.className == Armor))
					{
						if(!buyItem(%client,%item)) %error = 1;
						else %bought++;
					}
				}
			}
			if(%bought)
			{
				if(%error) Client::sendMessage(%client,0,"~wC_BuySell.wav");
				else Client::SendMessage(%client,0,"~wbuysellsound.wav");
			}
			updateBuyingList(%client);
		}
	}
}

function checkResources(%player, %item, %delta, %noMessage)
{
	%client = Player::getClient(%player);
	%team = Client::getTeam(%client);
	if($TeamItemMax[%item] != "" && !$TestCheats)
	{
		if($TeamItemMax[%item] <= $TeamItemCount[%team, %item])
		{
			Client::sendMessage(%client, 0, "Deployable Item limit reached for " @ %item.description @ "s");
			return 0;
		}
	}
	if(%item.className == Weapon)
	{
		%armor = Player::getArmor(%client);
		if (Player::getItemClassCount(%client,"Weapon") >= ($MaxWeapons[%armor] + %client.maxwp))
		{
			Client::sendMessage(%client, 0, "Too many weapons for " @ $ArmorName[%armor].description @ " to carry");
			return 0;
		}
	}
	else if(%item == RepairPatch)
	{
		%pDamage = GameBase::getDamageLevel(%player);
		if(GameBase::getDamageLevel(%player) > 0) %delta = 1;
		else %delta = 0;
	}
	else if(%item.className != Armor && %item.className != Vehicle)
	{
		%armor = Player::getArmor(%client);
		%extraAmmo = 0;
		%max = $ItemMax[%armor, %item];
		%count = Player::getItemCount(%client, %item);
		if(%item.className == Ammo || %item.className == HandAmmo)
		{
			if (Player::getMountedItem(%client, $BackpackSlot) == ammopack)
			{
				%extraAmmo = floor(%max * $AmmoPackMulti);
			}
			%extraAmmo += floor(%extraAmmo * %client.ammom);
		}
		if(%delta + %count > %max + %extraAmmo) %delta = %max + %extraAmmo - %count;
	}
	if(!$TestCheats && %client.spawn == "")
	{
		%creds = %client.creds;
		if(!$InfiniteCreds)
		{
			if (%item.price * %delta > %creds) %delta = floor(%creds / %item.price); 
			if(%delta < 1 )
			{
				if(%noMessage == "") Client::sendMessage(%client,0,"Couldn't buy " @ %item.description @ " - "@ %energy @ " Credits left");
				return 0;
			}
		}
	}
	return %delta;
}

function buyItem(%client, %item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats || %client.spawn) && ($ItemMax[%armor, %item] || %item.className == Armor || %item.className == Vehicle || $TestCheats))
	{
		if (%item.className == Armor)
		{
// Assign armor by requested type & gender 
			%buyarmor = $ArmorType[Client::getGender(%client), %item];
			if(%armor != %buyarmor || Player::getItemCount(%client, %item) == 0)
			{
				teamEnergyBuySell(%player, $ArmorName[%armor].price);
				if(checkResources(%player, %item, 1))
				{
					teamEnergyBuySell(%player, %item.price * -1);
					Player::setArmor(%client, %buyarmor);
					setupShoppingList(%client, %station);
					checkMax(%client, %buyarmor);
					armorChange(%client);
					Player::setItemCount(%client, $ArmorName[%armor], 0);
					Player::setItemCount(%client, %item, 1);
					if (Player::getMountedItem(%client, $BackpackSlot) == ammopack) fillAmmoPack(%client);
					return 1;
				}
				teamEnergyBuySell(%player, $ArmorName[%armor].price * -1);
				%station = %player.Station;
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
			%pack = Player::getMountedItem(%client, $BackpackSlot);
			if (%pack != -1)
			{
				if(%pack == ammopack) checkMax(%client, %armor);
				teamEnergyBuySell(%player, %pack.price);
				Player::decItemCount(%client, %pack, 1);
			}
			if (checkResources(%player,%item,1) || $testCheats)
			{
				teamEnergyBuySell(%player,%item.price * -1);
				Player::incItemCount(%client, %item, 1);
				Player::useItem(%client,%item); 
				if(%item == ammopack) fillAmmoPack(%client);
				return 1;
			}
		}
		else if(%item.className == Tool)
		{
			if(checkResources(%player, %item, 1))
			{
				Player::incItemCount(%client, %item, 1);
				teamEnergyBuySell(%player,%item.price * -1);
				Player::useItem(%player, %item); 
				Player::decItemCount(%client, %item, 1);
				return 1;
			}
		}
		else if(%item.className == Weapon)
		{
			if(checkResources(%player, %item, 1))
			{
				Player::incItemCount(%client, %item, 1);
				teamEnergyBuySell(%player, (%item.price * -1));
				%ammoItem = %item.imageType.ammoType; 
				if(%ammoItem != "")
				{
					%delta = checkResources(%player, %ammoItem, $ItemMax[%armor, %ammoItem]);
					if(%delta || $testCheats)
					{
						teamEnergyBuySell(%player, (%ammoItem.price * -1 * %delta));
						Player::incItemCount(%client, %ammoitem, %delta);
					}
				}
				return 1;
			}
		}
		 else if(%item.className == Vehicle)
		{
			if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
			{
				%shouldBuy = VehicleStation::checkBuying(%client,%item);
				if(%shouldBuy == 1)
				{
					if(checkResources(%player,%item,1))
					{
						teamEnergyBuySell(%player,(%item.price * -1));
						return 1;
					}
				}
				else if(%shouldBuy == 2) return 1;
			}
		}
		else
		{
			if($TeamItemMax[%item] != "")
			{
				if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) return 0;
			}
			%delta = checkResources(%player, %item, $ItemMax[%armor, %item]);
			if(%delta || $testCheats)
			{
				teamEnergyBuySell(%player,(%item.price * -1 * %delta));
				Player::incItemCount(%client, %item, %delta);
				return 1;
			}
		}
	}
	return 0;
}

function spawnBuyItem(%client, %item)
{
	%player = Client::getOwnedObject(%client);
	%armor = Player::getArmor(%client);
	if (%item.className == Armor)
	{
// Assign armor by requested type & gender 
		Player::setArmor(%client, %item);
		armorChange(%client);
		Player::setItemCount(%client, $ArmorName[%item], 1);
		return 1;
	}
	else if (%item.className == Backpack)
	{
		if($TeamItemMax[%item] != "")
		{
			if($TeamItemCount[GameBase::getTeam(%client) @ %item] >= $TeamItemMax[%item]) return 0;
		}
		Player::setItemCount(%client, %item, 1);
		Player::useItem(%client,%item); 
		if(%item == ammopack) spawnFillAmmoPack(%client);
		return 1;
	}
	else if(%item.className == Weapon)
	{
		if (Player::getItemClassCount(%client,"Weapon") >= ($MaxWeapons[%armor] + %client.maxwp) || $ItemMax[%armor, %item] == 0) return 0;
		Player::incItemCount(%client, %item, 1);
		%ammo = %item.imageType.ammoType; 
		if(%ammo != "")
		{
			%ammoMax = $ItemMax[%armor, %ammo];
			%count = Player::getItemCount(%client, %ammo);
			Player::incItemCount(%client, %ammo, %ammoMax - %count);
		}
		return 1;
	}
	else
	{
		Player::setItemCount(%client, %item, $ItemMax[%armor, %item]);
		return 1;
	}
	return 0;
}

function armorChange(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%client.respawn == "" && %player.Station != "")
	{
		%sPos = GameBase::getPosition(%player.Station);
		%pPos= GameBase::getPosition(%client);
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
	if (isPlayerBusy(%client)) return;
	%item = getItemData(%type);
	if(buyItem(%client,%item))
	{
		Client::sendMessage(%client,0,"~wbuysellsound.wav");
		updateBuyingList(%client);
	}
	else Client::sendMessage(%client,0,"You couldn't buy "@ %item.description @"~wC_BuySell.wav");
}

function remoteSellItem(%client,%type)
{
	if (isPlayerBusy(%client)) return;
	%item = getItemData(%type);
	%player = Client::getOwnedObject(%client);
	if ($ServerCheats || Client::isItemShoppingOn(%client,%item) || $TestCheats)
	{
		if(Player::getItemCount(%client,%item) && %item.className != Armor)
		{
			%numsell = 1;
			if(%item.className == Ammo || %item.className == HandAmmo)
			{
				%count = Player::getItemCount(%client, %item);
				if(%count < $SellAmmo[%item]) %numsell = %count; 
				else %numsell = $SellAmmo[%item];
			}
			else if (%item == ammopack) checkMax(%client, Player::getArmor(%client));
			else if($TeamItemMax[%item] != "")
			{
				if(%item.className == Vehicle) $TeamItemCount[(Client::getTeam(%client)) @ %item]--;
			}
			teamEnergyBuySell(%player,%item.price * %numsell);
			Player::setItemCount(%player,%item,(%count - %numsell));
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
	if (%item == Backpack) %item = Player::getMountedItem(%client,$BackpackSlot);
	else if (%item == Weapon) %item = Player::getMountedItem(%client,$WeaponSlot);
	Player::useItem(%client,%item);
}

function remoteThrowItem(%client,%type,%strength)
{
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime())
	{
		if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "")
		{
			%item = getItemData(%type);
			if (%item == Grenade || %item == MineAmmo)
			{
				if (%strength < 0) %strength = 0;
				else if (%strength > 100) %strength = 100;
				%client.throwStrength = 0.3 + 0.7 * (%strength / 100);
				Player::useItem(%client,%item);
			}
		}
	}
}

function remoteDropItem(%client,%type)
{
	if((Client::getOwnedObject(%client)).driver != 1)
	{
		%client.throwStrength = 1;
		%item = getItemData(%type);
		if (%item == Backpack)
		{
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Weapon)
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			Player::dropItem(%client,%item);
		}
		else if (%item == Ammo)
		{
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon)
			{
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
		}
		else Player::dropItem(%client,%item);
	}
}

function remoteDeployItem(%client,%type)
{
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

$Deployables = 0;

function addDeployable(%depl, %tim)
{
	$TeamItemMax[%depl] = %tim;
	$DeployList[$Deployables] = %depl;
	$Deployables++;
}

//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------

function Item::giveItem(%player,%item,%delta)
{
	%armor = Player::getArmor(%player);
	if($ItemMax[%armor, %item])
	{
		%client = Player::getClient(%player);
		if (%item.className == Backpack)
		{
// Only one backpack per armor, and it's always mounted
			if (Player::getMountedItem(%player, $BackpackSlot) == -1)
			{
				Player::incItemCount(%player, %item, 1);
				Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received a " @ %item @ " backpack");
				return 1;
			}
		}
		else
		{
// Check num weapons carried by player can't have more then max
			if (%item.className == Weapon)
			{
				if (Player::getItemClassCount(%player,"Weapon") >= ($MaxWeapons[%armor] + %client.maxwp)) return 0;
			}
// Make sure it doesn't exceed carrying capacity
			if(%item.className == Ammo || %item.className == HandAmmo)
			{
				%extraAmmo = 0;
				if (Player::getMountedItem(%client,$BackpackSlot) == ammopack)
				{
					%extraAmmo = floor($ItemMax[%armor, %item] * $AmmoPackMulti);
				}
				%extraAmmo += floor(%extraAmmo * %client.ammom);
				%max = $ItemMax[%armor, %item] + %extraAmmo;
			}
			else %max = $ItemMax[%armor, %item];
			%count = Player::getItemCount(%player, %item);
			if(%delta + %count >= %max) %delta = %max - %count;
			if (%delta > 0)
			{
				Player::incItemCount(%player, %item, %delta);
				if (%count == 0 && $AutoUse[%item]) Player::useItem(%player,%item);
				Client::sendMessage(%client,0,"You received " @ %delta @ " " @ %item.description);
				return %delta;
			}
		}
	}
	return 0;
}

//----------------------------------------------------------------------------
// Default Item object methods

function Item::playPickupSound(%this)
{
	%item = Item::getItemData(%this);
	%sound = $PickupSound[%item.className];
	if (%sound != "") playSound(%sound,GameBase::getPosition(%this));
	else
	{
// Generic item sound
		playSound(SoundPickupItem,GameBase::getPosition(%this));
	}
}

function Item::respawn(%this)
{
// If the item is rotating we respawn it,
	if (Item::isRotating(%this))
	{
		Item::hide(%this,True);
		schedule("Item::hide(" @ %this @ ",false); GameBase::startFadeIn(" @ %this @ ");",$ItemRespawnTime,%this);
	}
	else
	{
		deleteObject(%this);
	}
}

function Item::onAdd(%this)
{
}

function Item::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
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
	if($matchStarted)
	{
		if(%item.className != Armor)
		{
			%obj = newObject("","Item",%item,1,false);
			schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
			addToSet("MissionCleanup", %obj);
			if (Player::isDead(%player)) GameBase::throw(%obj,%player,10,true);
			else
			{
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			Player::decItemCount(%player, %item, 1);
			return %obj;
		}
	}
}

function Item::onDeploy(%player,%item,%pos)
{
}

// Remote deploy for items

function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3))
		{
// GetLOSInfo sets the following globals:
// los::position
// los::normal
// los::object
			%obj = getObjectType($los::object);
			if (%obj == "SimTerrain" || %obj == "InteriorShape")
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

//----------------------------------------------------------------------------

function remoteGiveAll(%clientId)
{
	if ($TestCheats)
	{
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
		Player::setItemCount(%clientId,Beacon,200);
		Player::setItemCount(%clientId,RepairKit,200);
	}
	else if($ServerCheats)
	{
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

function checkMax(%client, %armor)
{
	%weaponflag = 0;
	%numweapon = Player::getItemClassCount(%client,"Weapon");
	if (%numweapon > ($MaxWeapons[%armor] + %client.maxwp)) %weaponflag = %numweapon - ($MaxWeapons[%armor] + %client.maxwp);
	%max = getNumItems();
	for (%i = 0; %i < %max; %i++)
	{
		%item = getItemData(%i);
		if (%item.className == Armor || %item.className == Vehicle) continue;
		%maxnum = $ItemMax[%armor, %item];
		if(%maxnum != "")
		{
			%numsell = 0;
			%count = Player::getItemCount(%client, %item);
			if(%count > %maxnum)
			{
				%numsell = %count - %maxnum;
			}
			if (%count > 0 && %weaponflag && %item.className == Weapon)
			{
				%numsell = 1;
				%weaponflag--;
			}
			if(%numsell > 0)
			{
				Client::sendMessage(%client, 0, "SOLD " @ %numsell @ " " @ %item);
				teamEnergyBuySell(Client::getOwnedObject(%client), (%item.price * %numsell));
				Player::setItemCount(%client, %item, %count - %numsell);
				updateBuyingList(%client);
			} 
		}
	}
}

function Mission::reinitData()
{
	for(%i = 0; %i < 8; %i++)
	{
		for(%n = 0; %n < $Deployables; %n++)
		{
			$TeamItemCount[%i @ $DeployList[%n]] = 0;
		}
	}
	$totalNumCameras = 0;
	$totalNumTurrets = 0;
}

echo('>> Loading Items');
exec(item_tables);
exec(item_flag);
exec(item_armor);
exec(item_ammo);
exec(item_weapon);
exec(item_tool);
exec(item_backpack);
exec(item_beacon);
exec(item_mine);
exec(item_repairkit);
exec(item_repairpatch);
exec(item_vehicle);
exec(item_deadweight);
echo('>> Finished Loading Items');