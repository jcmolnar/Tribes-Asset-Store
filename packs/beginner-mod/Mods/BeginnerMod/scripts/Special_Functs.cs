//-----------------------------------------
// Special_Functs.cs
// Author: Dustin Bruce.
// Started: August 8th, 2003 2:57pm
//-----------------------------------------
//
$AmmoPack::num = 0;
$ReInit::num = 0;
$Armor::num = 0;
//
DamageSkinData objectDamageSkins {
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
//==========================================================================================
// createWeapon:
//==========================================================================================
// This should help to explain how this function should be called. Don't leave arguments
// blank unless it's an energy weapon that your using and you don't have ammo for it. In
// which case you could leave the last 3 args empty, as "" or not calling the last 3 at all.
// ie once you've called the 3 weapon item max args you could stop it there.
// createWeapon(Blaster, "", 1, 1, false, "", 1, 1, 1);
//
// %weapon - The weapon's datablock name, ie: 'ItemData MyWeapon' would be called as
// createWeapon("MyWeapon", bla, bla, etc..
//
// %ammo - The weapon's ammo's datablock name, ie: 'ItemData MyWeaponAmmo' would be called
// as createWeapon("MyWeapon", "MyWeaponAmmo", bla, bla, etc..
//
// %inv - 1 = In Inventory, 0 = Not In Inventory(goes for ammo and weapon).
//
// %remote - 1 = In Remote Inventory, 0 = Not In Remote Inventory
// (goes for ammo and weapon).
//
// %autoUse - This is called as either true or false, if true whenever this weapon is picked
// up it will be mounted, or when leaving an inventory. I leave these to false on every 
// weapon.
//
// %sellAmmo - How much ammo to sell per.. uhh.. sell.. :) ie: 30
//
// %wlmax - Light Armor's Weapon Item Max. 1 or 0
//
// %wmmax - Medium Armor's Weapon Max.
//
// %whmax - Heavy Armor's Weapon Max.
//
// %almax - Light Armor's Ammo Max.
//
// %ammax - Medium Armor's Ammo Max.
//
// %ahmax - Heavy Armor's Ammo Max.
//
function createWeapon(%weapon, %ammo, %inv, %remote, %autoUse, %sellAmmo, %wlmax, %wmmax, %whmax, %almax, %ammax, %ahmax){
	$AutoUse[%weapon] = %autoUse;
	
	if(%ammo == ""){
		$WeaponAmmo[%weapon] = "";
	}else{
		$WeaponAmmo[%weapon] = %ammo;
		$SellAmmo[%ammo] = %sellAmmo;
		$ItemMax[larmor, %ammo]  = %almax;
		$ItemMax[lfemale, %ammo] = %almax;
		$ItemMax[marmor, %ammo]  = %ammax;
		$ItemMax[mfemale, %ammo] = %ammax;
		$ItemMax[harmor, %ammo]  = %ahmax; // PORT: was larmor (typo)
		
		$InvList[%ammo] = %inv;
		$RemoteInvList[%ammo] = %remote;
	}
	
	$ItemMax[larmor, %weapon]  = %wlmax;
	$ItemMax[lfemale, %weapon] = %wlmax;
	$ItemMax[marmor, %weapon]  = %wmmax;
	$ItemMax[mfemale, %weapon] = %wmmax;
	$ItemMax[harmor, %weapon]  = %whmax; // PORT: was larmor (typo)
	
	$InvList[%weapon] = %inv;
	$RemoteInvList[%weapon] = %remote;
}
//==========================================================================================
//
//
//==========================================================================================
// createBackPack:
//==========================================================================================
//
// %pack - ItemData block name.
//
// %inv - 0 = don't put it into inventory stations, 1 = put em in there.
//
// %remote - 0 = don't put it into remote inventory stations, 1 = put em in.
//
// %lmax - for this, and the last 2 arguments it's either a 1 (armor can have item) or a
// 0 (armor can't have item). lmax is for light male and light female armors.
//
// %mmax - medium armor max for this item(1 or 0 same as %lmax). This is for both male and
// female medium armors.
//
// %hmax - heavy armor max for this item(1 or 0).
//
function createBackPack(%pack, %inv, %remote, %lmax, %mmax, %hmax){
	$InvList[%pack] = %inv;
	$RemoteInvList[%pack] = %remote;
	
	$ItemMax[larmor, %pack] = %lmax;
	$ItemMax[marmor, %pack] = %mmax;
	$ItemMax[harmor, %pack] = %hmax;
	$ItemMax[lfemale, %pack] = %lmax;
	$ItemMax[mfemale, %pack] = %mmax;
}
//==========================================================================================
// createMisc
//==========================================================================================
//
// This is for things like mines, the repair kit, hand grenades.. you get the idea... 
// 
// %misc - ItemData name of the misc item.
//
// %autouse - call this as false on everything.
//
// %inv - 0 or 1, 1 will put it into the inventory stations, 0 won't.
//
// %remote - 1 puts it in, 0 leaves it out of remote inventory stations.
//
function createMisc(%misc, %autouse, %inv, %remote, %lmax, %mmax, %hmax, %sellAmmo, %tim){
	if(%autouse != "") $AutoUse[%misc] = %autouse;
	
	$InvList[%misc] = %inv;
	$RemoteInvList[%misc] = %remote;
	
	$ItemMax[larmor, %misc] = %lmax;
	$ItemMax[marmor, %misc] = %mmax;
	$ItemMax[harmor, %misc] = %hmax;
	$ItemMax[lfemale, %misc] = %lmax;
	$ItemMax[mfemale, %misc] = %mmax;
	
	if(%sellAmmo != "") $SellAmmo[%misc] = %sellAmmo;
	if(%tim != ""){
		$TeamItemMax[%misc] = %tim;
		ReInit::Add(%misc);
	}
}
//==========================================================================================
// createDeployable:
//==========================================================================================


function createDeployable(%deployable, %inv, %remote, %lmax, %mmax, %hmax, %tim){
	$InvList[%deployable] = %inv;
	$RemoteInvList[%deployable] = %remote;
	
	$ItemMax[larmor, %deployable] = %lmax;
	$ItemMax[marmor, %deployable] = %mmax;
	$ItemMax[harmor, %deployable] = %hmax;
	$ItemMax[lfemale, %deployable] = %lmax;
	$ItemMax[mfemale, %deployable] = %mmax;
	
	$TeamItemMax[%deployable] = %tim;
	ReInit::Add(%deployable);
}
//==========================================================================================


function createArmor(%genderM, %genderF, %description, %price, %armorName){ 
   $ArmorType[Male, %armorName] = %genderM; 
   $ArmorType[Female, %armorName] = %genderF; 
    
   $ArmorName[%genderM] = %armorName; 
   $ArmorName[%genderF] = %armorName; 
    
   %ItemData = "ItemData "@ %armorName @" { heading = \"aArmor\"; description = \""@ %description @"\"; className = \"Armor\"; price = "@ %price @"; };"; 
   eval(%ItemData); 
}


//==========================================================================================
// AmmoPack::addAmmo:
//==========================================================================================
//
// %item - Ammo to fill, use the ammo's datablock name.
// 
// %extra - How many more of the item should be givin?
//
function AmmoPack::addAmmo(%item, %extra){
	$AmmoPackItems[$AmmoPack::num] = %item;
	$AmmoPackMax[%item] = %extra;
	$AmmoPack::num += 1;
}
//==========================================================================================


//==========================================================================================
// ReInit::Add:
//==========================================================================================
//
// %item - Item Datablock name.
//
function ReInit::Add(%item){
	$ReInit::Item[$ReInit::num] = %item;
	$ReInit::num += 1;
}
//==========================================================================================

//==========================================================================================
// deployItemX:
//==========================================================================================
$newWord[SimTerrain] = "Terrain";
$newWord[InteriorShape] = "Buildings";
$newWord[StaticShape] = "Deployed Objects";

// This should be used by all items that are deployed, turrets and mics deployables..
//
// %player - Player deploying the object.
//
// %item - Item being deployed. I think %item would be the object id, not sure though.. just
// use %item from the ::onDeploy function for your item.
//
// %class - Class of object, e.g. "StaticShape" or "Turret" or "InteriorShape".
//
// %shape - shape of item e.g DeployableAmmoStation, CameraTurret, or DeployableInvStation.
//
// %angle - Options: ("Player", "Flat", or true)

function deployItemX(%player, %item, %class, %shape, %angle, %terrain, %dplRange, %range, %breakable){
	%client = Player::getClient(%player);
	if(!GameBase::getLOSInfo(%player, %dplRange)){
		Client::sendMessage(%client, 0, "Deploy position out of range");
		return false;
	}
	//Echo("Vector::dot = "@ Vector::dot($los::normal, "0 0 1"));
	
	if(%angle == true){
		if(Vector::dot($los::normal, "0 0 1") > 0.7){
			%prot = GameBase::getRotation(%player);
			%zRot = getWord(%prot, 2);
			if(Vector::dot($los::normal, "0 0 1") > 0.6) %rot = "0 0 "@ %zRot;
			else{
				if(Vector::dot($los::normal,"0 0 -1") > 0.6) %rot = "3.14159 0 "@ %zRot;
				else %rot = Vector::getRotation($los::normal);
			}
		}else{
			Client::sendMessage(%client, 0, "Can only deploy on flat surfaces");
			return false;
		}
	}
	else if(%angle == "Player") %rot = GameBase::getRotation(%player);
	else if(%angle == "Flat") %rot = "-1.54564 0.02591 -3.09105";
	else if(%angle == "Any"){
		%prot = GameBase::getRotation(%player);
		%zRot = getWord(%prot, 2);
		if(Vector::dot($los::normal,"0 0 1") > 0.6){
			%rot = "0 0 "@ %zRot;
		}else{
			if(Vector::dot($los::normal, "0 0 -1") > 0.6) %rot = "3.14159 0 "@ %zRot;
			else %rot = Vector::getRotation($los::normal);
		}
	}
	
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] >= $TeamItemMax[%item]){
		Client::sendMessage(%client, 0, "Deployable Item limit reached for "@ %item.description @"s.");
		return false;
	}
	
	if(%terrain != "" && %terrain != false){
		if(%terrain == "All"){
			if(%obj != "SimTerrain" && %obj != "InteriorShape" && %obj != "StaticShape"){
				Client::sendMessage(%client, 0, "Can only deploy on terrain, buildings and deployed objects.");
				return false;
			}
		}else{
			%terrainA = getWord(%terrain, 0);
			%terrainB = getWord(%terrain, 1);
			%obj = getObjectType($los::object);
			
			if(%terrainB != ""){
				if(%obj != %terrainA && %obj != %terrainB){
					Client::sendMessage(%client, 0, "Can only deploy on "@ $newWord[%terrainA] @" or "@ $newWord[%terrainB] @".");
					return false;
				}
			}else{
				if(%obj != %terrain){
					Client::sendMessage(%client, 0, "Can only deploy on "@ $newWord[%terrain] @".");
					return false;
				}
			}
		}
	}
	
	if(%range == true){
		if(!checkDeployArea(%client, $los::position)) return false;
	}
	%obj = newObject(%item.description, %class, %shape, %breakable);
	addToSet("MissionCleanup", %obj);
	GameBase::setTeam(%obj, GameBase::getTeam(%player));
	GameBase::setRotation(%obj, %rot);
	GameBase::setPosition(%obj, $los::position);
	$TeamItemCount[GameBase::getTeam(%obj) @ %item]++;
	Gamebase::setMapName(%obj, Client::getName(%client) @" - "@ %item.description @" #"@ $TeamItemCount[GameBase::getTeam(%player) @ %item] @"");
	Client::sendMessage(%client, 0, %item.description @" deployed");
	playSound(SoundPickupBackpack, $los::position);
	Echo("Deploy: \""@ %item.description @"\" - "@ Client::getName(%client) @"("@ %client @")");
	Player::decItemCount(%player, %item);
	return true;
}
//==========================================================================================

TurretData CameraTurret {
	className = "Turret";
	shapeFile = "camera";
	maxDamage = 0.25;
	maxEnergy = 10;
	speed = 20;
	speedModifier = 1.0;
	range = 50;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	visibleToSensor = true;
	shadowDetailMask = 4;
	castLOS = true;
	supression = false;
	supressable = false;
	mapFilter = 2;
	mapIcon = "M_camera";
	debrisId = defaultDebrisSmall;
	FOV = 0.707;
	pinger = false;
	explosionId = debrisExpMedium;
	description = "Camera";
};
function CameraTurret::onAdd(%this){
	Schedule("CameraTurret::deploy("@ %this @");", 1, %this);
	if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Camera");
}
function CameraTurret::deploy(%this){
	GameBase::playSequence(%this,1,"deploy");
}
function CameraTurret::onEndSequence(%this, %thread){
	GameBase::setActive(%this, true);
}
function CameraTurret::onDestroyed(%this){
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @"CameraPack"]--;
}