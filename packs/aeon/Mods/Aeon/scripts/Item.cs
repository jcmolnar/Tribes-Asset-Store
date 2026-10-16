//----------------------------------------------------------------------------

$ItemFavoritesKey = "Aeon";

$ItemPopTime = 40;

//-Free Slots include 2-7
$ToolSlot = 0;
$WeaponSlot = 0;
$BackpackSlot = 1;

//----------------------------------------------------------------------------
function isPlayerBusy(%clientId)
{
	%player = Client::getOwnedObject(%clientId);	
	%state = Player::getItemState(%player,$WeaponSlot);
	if($CnHold[%player])
		return "CnHold";
	else if(%state == "Fire" || %state == "Reload")
		return %state;
}

function isPlayerIdle(%clientId)
{
	if(isPlayerBusy(%clientId) == "Ready" || isPlayerBusy(%clientId) == "Idle" || isPlayerBusy(%clientId) == "Reset")
		return true;
	return false;
}

function remoteUseItem(%clientId,%type)
{
	%clientId.throwStrength = 1;
	%item = getItemData(%type);
	if(%item == Backpack) 
		%item = Player::getMountedItem(%clientId,$BackpackSlot);
	else {
		if(%item == Weapon) 
			%item = Player::getMountedItem(%clientId,$WeaponSlot);
	}
	Player::useItem(%clientId,%item);
}

function remoteBuyItem(%clientId,%type)
{
	if(isPlayerBusy(%clientId))
		return;
	%item = getItemData(%type);
	if(Terminal::purchase(%clientId,%item)) {
		bottomPrint2(%clientId,"<jc><f1>You bought a <f0>"@%item.description@".",2,"BuySellSound.wav");
		%clientId.getting = getSimTime();
		schedule("Item::checkGetting("@%clientId@");",1.0,%clientId);
	}
	else 
		bottomPrint2(%clientId,"<jc><f1>You couldn't buy a <f0>"@%item.description@".",2,"C_BuySell.wav");
}

function remoteSellItem(%clientId,%type)
{
	if(isPlayerBusy(%clientId))
		return;
	if(Client::getOwnedObject(%clientId).Terminal) {
		%item = getItemData(%type);
		%cash = Terminal::sell(%clientId,%item);
		if(%cash >= 0) {
			bottomPrint2(%clientId,"<jc><f1>You sold a <f0>"@%item.description@"<f1> for <f0>$"@String::cashComma(floor(%cash))@"<f1>.",2,"BuySellSound.wav");
			%clientId.getting = getSimTime();
			schedule("Item::checkGetting("@%clientId@");",1.0,%clientId);
		}
		else 
			bottomPrint2(%clientId,"<jc><f1>You couldn't sell the <f0>"@%item.description@".",2,"C_BuySell.wav");
	}
	else
		remoteUseItem(%clientId,%type);
}

function remoteFetchData(%client)
{
	%client.warnFetchData++;
	if(%client.warnFetchData > 5) {
		//echo(%client);
	}
	else if(%client.warnFetchData == 1)
		schedule(%client@".warnFetchData = 0;",2.0,%client);
	BottomPrint(%client,"<jc><f1>That doesn't do shit so stop!",2);
}

function remoteThrowItem(%client,%type,%strength)
{
	%armor = Player::getArmor(%client);
	%player = Client::getOwnedObject(%client);
	if(%player.Station == "" && %player.waitThrowTime + $WaitThrowTime <= getSimTime()) {
		//if(GameBase::getControlClient(%player) != -1 || %player.vehicle != "") {
			%item = getItemData(%type);
			if(%item != Grenade || %item != MineAmmo || %item != Beacon || String::findSubStr(%item,"Activator") != 0) {
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
		//}
	}
}

function remoteDropItem(%client,%type)
{
	%armor = Player::getArmor(%client);
	if((Client::getOwnedObject(%client)).driver != 1) {
		%client.throwStrength = 1;
		%item = getItemData(%type);
		if(%item == Backpack) {
			%item = Player::getMountedItem(%client,$BackpackSlot);
			Player::dropItem(%client,%item);
		}
		else if(%item == Weapon) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if($Aeon::invNodrop[%item] != true)
				Player::dropItem(%client,%item);
		}
		else if(%item == Ammo) {
			%item = Player::getMountedItem(%client,$WeaponSlot);
			if(%item.className == Weapon) {
				%item = %item.imageType.ammoType;
				Player::dropItem(%client,%item);
			}
		}
		else if(%item.className != "HandAmmo" && %item.className != "Armor" && %item.className != "Activator")
			Player::dropItem(%client,%item);
		else
			bottomPrint(%client,"<jc><f3>Item-drop scripts are pointless here, they will only hurt you.");
	}
}

function remoteDeployItem(%client,%type)
{
	%item = getItemData(%type);
	Player::deployItem(%client,%item);
}

//----------------------------------------------------------------------------
// Default item scripts
//----------------------------------------------------------------------------

function Item::getValue(%item,%isDat)
{
	if(!%isDat)
		%data = GameBase::getDataName(%item);
	else
		%data = %item;
	if(!%isDat && %data.className == "Vehicle")
		%data = $VehicleToItem[%data];
	%price = $CatalogPrice[%data];
	if(%price == "" || %price < 0)
		%price = %data.price;
	if(!%isDat) {
		if(%item.worth)
			%price += %item.worth;
	}
	return %price;
}

function Item::giveItem(%player,%item,%delta,%id,%pos)
{
	%clientId = Player::getClient(%player);
	if(%player < 4000)
		%player = Client::getOwnedObject(%clientId);
	if(%pos == "")
		%pos = GameBase::getPosition(%id);
	if(%item.className == Backpack) {
		if(%item == "DeployPack") {
			if(Player::getItemCount(%player,"DeployPack") > 0) {
				if($DeployPack[%clientId] == $DeployTypeThis[%id]) {
					bottomPrint(%clientId,"<jc><f3>Got a pack, select it from your inventory to mount it.");
					Item::playPickupSound(%item,%pos);
					%count = Player::getItemCount(%clientId,%item);
				 	Player::setItemCount(%player,%item,%count+%delta);
					return 1;
				}
				else {
					bottomPrint(%clientId,"<jc><f3>Can only hold one kind of Deployable at once.");
					return 0;
				}
			}
			else {
				$DeployPack[%clientId] = $DeployTypeThis[%id];
				Item::playPickupSound(%item,%pos);
				bottomPrint(%clientId,"<jc><f3>Got a pack, select it from your inventory to mount it.");
			 	%count = Player::getItemCount(%clientId,%item);
			 	Player::setItemCount(%player,%item,%count+1);
				Player::useItem(%player,%item);
				return 1;
			}
		}
	 	else {
		 	%count = Player::getItemCount(%clientId,%item);
		 	Player::setItemCount(%player,%item,%count+%delta);
			Player::useItem(%player,%item);
			Item::playPickupSound(%item,%pos);
			bottomPrint(%clientId,"<jc><f3>Got a pack, select it from your inventory to mount it.");
		 	return 1;
		}
	}
	else if(%item.className == "Books") {
		if(Player::getItemCount(%player,"Book") > 0) {
			bottomPrint(%clientId,"<jc><f3>You can only hold one Book at a time!");
			return 0;
		}
		else {
			Item::playPickupSound(%item,%pos);
		 	if(%player == %id.tosser)
			 	Books::rentBook(%clientId,$BookType[%id],"true true");
			else
			 	Books::rentBook(%clientId,$BookType[%id],true);
			Item::invUpdate(%clientId,false);
			Item::respawn(%id);
			return 0;
		}
	}
  	else {
		%count = Player::getItemCount(%player,%item);
		Player::setItemCount(%player,%item,%count+%delta);
		Item::playPickupSound(%item,%pos);
		if(%count == 0 && $AutoUse[%item])
			Player::useItem(%player,%item);
		if($Aeon::grabTempCount[%player,%item] == "")
			$Aeon::grabTempCount[%player,%item] = 1;
		else
			$Aeon::grabTempCount[%player,%item]++;
		Item::invUpdate(%clientId,true);
		return %delta;
	}
	return 0;
}

function Item::getDescription(%item,%delta)
{
	%desc = $CatalogName[%item];
	if(%desc == "")
		%desc = %item.description;
	%s = "";
	if(%delta > 1) {
		if($Plural[%item] != "")
			%desc = $Plural[%item];
		else
			%s = "s";
	}
	return %desc@%s;
}

//----------------------------------------------------------------------------

$PickupSound[Ammo] = "SoundPickupAmmo";
$PickupSound[Weapon] = "SoundPickupWeapon";
$PickupSound[Backpack] = "SoundPickupBackpack";
$PickupSound[Repair] = "SoundPickupHealth";

function Item::playPickupSound(%this,%pos)
{
	%sound = $PickupSound[%this.className];
	if(%sound != "")  
		playSound(%sound,%pos);
	else
		playSound(SoundPickupItem,%pos);
}	

function Item::respawn(%this)
{
	if(Item::isRotating(%this)) {
		Item::hide(%this,True);
		schedule("Item::hide("@%this@",false); GameBase::startFadeIn("@%this@");",$ItemRespawnTime,%this);
	}
	else
		deleteObject(%this);
}	

function Item::onAdd(%this)
{
	Shakeable::addToNetwork(%this);
}

function Item::onCollision(%this,%object)
{
	if(getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if(Item::giveItem(%object,%item,Item::getCount(%this),%this)) {
			Item::respawn(%this);
		}
	}
}

function Item::invUpdate(%clientId,%disp,%update)
{
	%clientId.getting = getSimTime();
	%clientId.dispNew = "";
	if(%disp)
		%clientId.dispNew = true;
	if(!%update)
		%update = 0.5;
	schedule("Item::checkGetting("@%clientId@");",%update,%clientId);
}

function Item::checkGetting(%clientId)
{
	if(%clientId.getting <= getSimTime()-0.5 && %clientId.getting != "") {
		%clientId.getting = "";
		Aeon::getInventory(%clientId,true);
	}
}

function Item::onDrop(%player,%item)
{
	if($matchStarted) {
		if(%item.className != Armor) {
			%clientId = Player::getClient(%player);
			if(%item.className == "Books" && %clientId.isReading)
				return false;
			%id = Aeon::getAeonID(%clientId);
			%obj = newObject("","Item",%item,1,false);
 	 	  	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);
 	 	 	addToSet("MissionCleanup", %obj);
			%obj.tosser = %player;
			if(Player::isDead(%player))
				GameBase::throw(%obj,%player,10,true);
			else {
				GameBase::throw(%obj,%player,15,false);
				Item::playPickupSound(%obj);
			}
			Player::decItemCount(%player,%item,1);
			if(%item == "DeployPack") {
				$DeployTypeThis[%obj] = $DeployPack[%clientId];
				if(Player::getItemCount(%player,%item) < 1)
					$DeployPack[%clientId] = "";
			}
			else if(%item.className == "Books") {
				$BookType[%obj] = $Aeon::ClientInfo[%id,book];
			}
			Item::invUpdate(%clientId,false,1.0);
			return %obj;
		}
	}
}

//----------------------------------------------------------------------------

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
	if(!%item.isGrabbed) {
	 	GameBase::startFadeOut(%item);
		%item.popping = true;
		Shakeable::removeFromNetwork(%item);
		schedule("deleteObject("@%item@"); "@%item@".popping = \"\";",2.5, %item);
	}
	else {
		schedule("Item::pop("@%item@");",5.0,%item);
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

//------------------------------------------------------------------------------
function Tool::onUse(%player,%item)
{
	Player::mountItem(%player,%item,$ToolSlot);
}

//----------------------------------------------------------------------------
function Backpack::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) != %item)
		Player::mountItem(%player,%item,$BackpackSlot);
	else
		Player::trigger(%player,$BackpackSlot);
}

function RepairPack::onMount(%player,%item) 
{
	Player::setItemCount(%player,RepairGun,1);
	Player::setItemCount(%player,RepairPack,0);
}

//----------------------------------------------------------------------------
function CameraPack::onDeploy(%player,%item,%pos)
{
	if(CameraPack::deployShape(%player,%item))
		Player::decItemCount(%player,%item);
}

function CameraPack::deployShape(%player,%item)
{
 	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		if(GameBase::getLOSInfo(%player,3)) {
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain" || %obj == "InteriorShape") {
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
					%rot = "0 0 " @ %zRot;
				else {
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
						%rot = "3.14159 0 " @ %zRot;
					else
						%rot = Vector::getRotation($los::normal);
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
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
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
$AutoUse[RepairKit] = false;

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player,0.2);
}

//----------------------------------------------------------------------------
function RepairPatch::onCollision(%this,%object)
{
	if(getObjectType(%object) == "Player") {
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
	$totalNumCameras = 0;
	$totalNumTurrets = 0;
	for(%i = -1; %i < 8 ; %i++) {
		$TeamEnergy[%i] = $DefaultTeamEnergy;
		$TeamItemCount[%i @ DeployableAmmoPack] = 0;
		$TeamItemCount[%i @ DeployableInvPack] = 0;
		$TeamItemCount[%i @ TurretPack] = 0;
		$TeamItemCount[%i @ CameraPack] = 0;
		$TeamItemCount[%i @ DeployableSensorJammerPack] = 0;
		$TeamItemCount[%i @ PulseSensorPack] = 0;
		$TeamItemCount[%i @ MotionSensorPack] = 0;
		$TeamItemCount[%i @ ScoutVehicle] = 0;
		$TeamItemCount[%i @ LAPCVehicle] = 0;
		$TeamItemCount[%i @ HAPCVehicle] = 0;
		$TeamItemCount[%i @ Beacon] = 0;
	}	
}