//------------------------------------
// Change This If You Add New Items
// Or It Will Fuck Up Everyones Favs.
$ItemFavoritesKey = "Ultra_Tribal_God";
//------------------------------------

// Setup Inventory Variables.
$InvHeading[PsionicsWeapons] = "ePsionics Weapons:";
$InvHeading[DeployableBases] = "jDeployable Bases:";
$InvHeading[BulletWeapons] = "cProjectile Weapons:";
$InvHeading[EnergyWeapons] = "dEnergy Weapons:";
$InvHeading[Deployables2] = "iOther Deployables:";
$InvHeading[JailingItems] = "mJailing Toyz:";
$InvHeading[ForceFields] = "gForce Field Doors:";
$InvHeading[Deployables] = "hDeployables:";
$InvHeading[BackPacks] = "bBackPacks:";
$InvHeading[Turrets] = "fBase Defence Items:";
$InvHeading[oddnend] = "lSpecialty Items:";
$InvHeading[Armor] = "aArmors:";
$InvHeading[Walls] = "kDeployable Walls:";
$InvHeading[Misc] = "nMisc. Items:";
//-------------------------------------------------------------------------------------------


$ItemPopTime  = 3;

// Image Slot Variables.
$FlagSlot = 2;
$ToolSlot = 0;
$WeaponSlot = 0;
$DefaultSlot = 3;
$BackpackSlot = 1;

// Extra Image Slot Variables.
$XtraSlotA = 4;
$XtraSlotB = 5;
$XtraSlotC = 6;
$XtraSlotD = 7;
//-------------------------------------------------------------------------------------------


// Global object damage skins (staticShapes Turrets Stations Sensors)
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
//-------------------------------------------------------------------------------------------


$ArmorType[Male, LightArmor] = larmor;
$ArmorType[Male, MediumArmor] = marmor;
$ArmorType[Male, EnginArmor] = Earmor;
$ArmorType[Male, HeavyArmor] = harmor;

$ArmorType[Female, LightArmor] = lfemale;
$ArmorType[Female, MediumArmor] = mfemale;
$ArmorType[Female, EnginArmor] = Earmor;	   
$ArmorType[Female, HeavyArmor] = harmor;

$ArmorName[larmor] = LightArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[Earmor] = EnginArmor;
$ArmorName[harmor] = HeavyArmor;
$ArmorName[lfemale] = LightArmor;
$ArmorName[mfemale] = MediumArmor;
//-------------------------------------------------------------------------------------------


// Items in the AmmoPack
$AmmoPackItems[0] = BulletAmmo;
$AmmoPackItems[1] = PlasmaAmmo;
$AmmoPackItems[2] = DiscAmmo;
$AmmoPackItems[3] = GrenadeAmmo;
$AmmoPackItems[4] = Grenade;
$AmmoPackItems[5] = MineAmmo;
$AmmoPackItems[6] = MortarAmmo;
$AmmoPackItems[7] = Beacon;
$AmmoPackItems[8] = TankRPGAmmo;
//-------------------------------------------------------------------------------------------

// Flags Data
function Flag::onUse(%player, %item)
{ Player::mountItem(%player, %item, $FlagSlot); }

ItemImageData FlagImage
{
	shapeFile   = "Flag";
	mountPoint  = 2;
	mountOffset = { 0, 0, -0.35 };
	mountRotation = { 0, 0, 0 };
	lightType   = 2;
	lightRadius = 4;
	lightTime   = 1.5;
	lightColor  = { 1, 1, 1};
};

ItemData Flag
{
	description = "Flag";
	shapeFile = "flag";
	imageType = FlagImage;
	showInventory = false;
	shadowDetailMask = 4;
    validateShape = false;
	lightType = 2;
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
	lightType = 2;
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = { 1, 1, 1 };
};
//-----------------------------------------------------

// Armors Data
ItemData LightArmor
{
	heading = $InvHeading[Armor];
	description = "Asassin";
	className = "Armor";
	price = 180;
};

ItemData MediumArmor
{
	heading = $InvHeading[Armor];
	description = "Mercenary";
	className = "Armor";
	price = 275;
};

ItemData EnginArmor
{
	heading = $InvHeading[Armor];
	description = "Engineer";
	className = "Armor";
	price = 420;
};

ItemData HeavyArmor
{
	heading = $InvHeading[Armor];
	description = "BoRg";
	className = "Armor";
	price = 650;
};
//-----------------------------------------------------

// Vehicles
ItemData ScoutVehicle
{
	description = "Scout";
	className = "Vehicle";
	heading = "aVehicle";
	price = 500;
};

ItemData LAPCVehicle
{
	description = "LPC";
	className = "Vehicle";
	heading = "aVehicle";
	price = 750;
};

ItemData HAPCVehicle
{
	description = "HPC";
	className = "Vehicle";
	heading = "aVehicle";
	price = 1000;
};
//-----------------------------------------------------

// Tools Data: Weapons, Tools, Ammo, Misc. Items..
ItemData Weapon
{
	description = "Weapon";
	showInventory = false;
};

function Weapon::onDrop(%player,%item)
{
	%state = Player::getItemState(%player, $WeaponSlot);
	if(%state != "Fire" && %state != "Reload")
	{ Item::onDrop(%player, %item); }
}	
//-----------------------------------------------------

ItemData Tool
{
	description = "Tool";
	showInventory = false;
};

function Tool::onUse(%player,%item)
{ Player::mountItem(%player,%item,$ToolSlot); }
//-----------------------------------------------------

ItemData Ammo
{
	description = "Ammo";
	showInventory = false;
};
//-----------------------------------------------------

//====Begin Repair Kit====|
$AutoUse[RepairKit] = false;

$ItemMax[larmor, RepairKit]  = 3;
$ItemMax[marmor, RepairKit]  = 5;
$ItemMax[harmor, RepairKit]  = 7;
$ItemMax[lfemale, RepairKit] = 3;
$ItemMax[mfemale, RepairKit] = 5;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile   = "armorKit";
   heading     = $InvHeading[Misc];
   shadowDetailMask = 4;
   price            = 35;
   validateShape    = false;
   validateMaterials = false;
};

function RepairKit::onUse(%player,%item)
{
	Player::decItemCount(%player, %item);
	GameBase::repairDamage(%player, 0.99);
}
//====End Repair Kit====|


//====Begin Mine Ammo====|
$InvList[MineAmmo] = 1;

$ItemMax[larmor, MineAmmo]  = 10;
$ItemMax[marmor, MineAmmo]  = 20;
$ItemMax[harmor, MineAmmo]  = 35;
$ItemMax[lfemale, MineAmmo] = 10;
$ItemMax[mfemale, MineAmmo] = 20;
$ItemMax[Earmor, MineAmmo] = 25;

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
   validateShape = false;
   validateMaterials = false;
};

function MineAmmo::onUse(%player, %item){
	if($matchStarted){
		if(%player.throwTime < getSimTime()){
			%armorVar = Player::getArmor(%player);
			%client = Player::getClient(%player);
			if(%armorVar == "Earmor"){
				%player = Client::getControlObject(%client);
				Player::decItemCount(%player, %item);
				%obj = newObject("", "Mine", "antipersonelMine");
				addToSet("MissionCleanup", %obj);
				Player::setAnimation(%player, 21);
				schedule("GameBase::throw("@ %obj @", "@ %player @", 55 * "@ %client.throwStrength @", false);", 0.8);
				%player.throwTime = getSimTime() + 0.5;
				GameBase::setTeam(%obj, GameBase::getTeam(%client));
				playVoice(%client, outway);
			}else{
				%obj = newObject("", "Mine", "antipersonelMine");
				addToSet("MissionCleanup", %obj);
				%client = Player::getClient(%player);
				GameBase::throw(%obj, %player, 15 * %client.throwStrength, false);
				%player.throwTime = getSimTime() +0.5;
				GameBase::setTeam(%obj, GameBase::getTeam(%client));
			}
		}
		if($TG::InfiniteAmmo:Mine != true){
			Player::decItemCount(%player, %item);
		}
	}
}

function MineAmmo::onCollision(%this, %object){
	if(getObjectType(%object) == "Player"){
		%client = Player::getClient(%object);
		%armor  = Player::getArmor(%object);
		if(Player::getItemCount(%object, MineAmmo) < $ItemMax[%armor, MineAmmo]){
			Item::playPickupSound(%this);
			Player::incItemCount(%client, MineAmmo, 1);
			Schedule("deleteObject("@ %this @");", 0.1, %this);
			return;
		}else Client::sendMessage(%client, 0, "Maximum Ammount Reached For MineAmmo.~wAccess_Denied.wav");
	}
}
//====End Mine Ammo====|


//====Begin Radius Mine====|
$ItemMax[larmor, RadiusMineAmmo]  = 1;
$ItemMax[marmor, RadiusMineAmmo]  = 1;
$ItemMax[harmor, RadiusMineAmmo]  = 1;
$ItemMax[lfemale, RadiusMineAmmo] = 1;
$ItemMax[mfemale, RadiusMineAmmo] = 1;

ItemData RadiusMineAmmo {
	description = "Radius Mine";
	shapeFile = "mineammo";
	heading = $InvHeading[Misc];
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};

function RadiusMineAmmo::onUse(%player,%item){
	if($matchStarted){
		if(%player.throwTime < getSimTime()){
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","radiusMine");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
		}
	}
}
//====End Radius Mine====|


//====Begin Grenade====|
$InvList[Grenade] = 1;

$ItemMax[larmor, Grenade]  = 100;
$ItemMax[marmor, Grenade]  = 125;
$ItemMax[harmor, Grenade]  = 250;
$ItemMax[Earmor, Grenade]  = 250;
$ItemMax[lfemale, Grenade] = 100;
$ItemMax[mfemale, Grenade] = 125;

ItemData Grenade {
	description = "Grenade";
	shapeFile = "grenade";
	heading = $InvHeading[Misc];
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
	validateShape = false;
	validateMaterials = false;
};

function Grenade::onUse(%armor, %item){
	if($matchStarted){
		%c = Player::getClient(%armor);
		%vel = Item::getVelocity(%armor);
		%newVel = getWord(%vel, 0) / 6 @" "@ getWord(%vel, 1) / 6 @" "@ getWord(%vel, 2) / 6;
		Item::setVelocity(%armor, %newVel);
		Client::sendMessage(%c, 0, "AirBrake Used.");
		if($TG::InfiniteAmmo:Grens == true) Player::decItemCount(%armor, %item);
	}
}


//====Begin Flash Grenade====|
$ItemMax[larmor, FlashGrenade] = 40;
$ItemMax[marmor, FlashGrenade] = 65;
$ItemMax[harmor, FlashGrenade] = 90;
$ItemMax[Earmor, FlashGrenade]  = 90;
$ItemMax[lfemale, FlashGrenade] = 40;
$ItemMax[mfemale, FlashGrenade] = 65;

ItemData FlashGrenade {
   description = "FlashGrenade";
   shapeFile = "grenade";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
   validateShape = false;
   validateMaterials = false;
};

function FlashGrenade::onUse(%player, %item){
	if($matchStarted){
		if(%player.throwTime < getSimTime()){
			Player::decItemCount(%player,%item);
			%obj = newObject("", "Mine", "Flash");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj, %player, 9 * %client.throwStrength, false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}
//====End Flash Grenade====|


//====Begin LiLBoost====|
$ItemMax[larmor, LiLBoostammo]  = 35;
$ItemMax[marmor, LiLBoostammo]  = 35;
$ItemMax[harmor, LiLBoostammo]  = 35;
$ItemMax[lfemale, LiLBoostammo] = 35;
$ItemMax[mfemale, LiLBoostammo] = 35;

ItemData LiLBoostammo {
	description = "LiLBoost";
	shapeFile = "sensor_small";
	heading = $InvHeading[Misc];
	shadowDetailMask = 4;
	price = 5;
	className = "HandAmmo";
};

function LiLBoostammo::onUse(%player, %item){
	if($matchStarted){
		if(%player.throwTime < getSimTime()){
			if($TG::InfiniteAmmo:Grens == false) Player::decItemCount(%player, %item);
			%obj = newObject("", "Mine", "LiLBoost");
			addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj, %player, 0, false);
			%player.throwTime = getSimTime() + 0.6;
			Client::sendMessage(Player::getClient(%player), 0, "You use a LiL Booster.");
		}
	}
}
//====End LiLBoost====|


//====Begin [TG]ClayMorMine====|
$ItemMax[larmor, TG::ClayMorMineAmmo]  = 35;
$ItemMax[marmor, TG::ClayMorMineAmmo]  = 35;
$ItemMax[harmor, TG::ClayMorMineAmmo]  = 35;
$ItemMax[lfemale, TG::ClayMorMineAmmo] = 35;
$ItemMax[mfemale, TG::ClayMorMineAmmo] = 35;

ItemData TG::ClayMorMineAmmo {
   description = "Claymor Mine";
   shapeFile = "mineammo";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 10;
   className = "HandAmmo";
};

function TG::ClayMorMineAmmo::onUse(%player, %item){
	if(!$matchStarted) return;
	%client = Player::getClient(%player);
	%playerTeam = GameBase::getTeam(%player);
	if(%player.throwTime < getSimTime()){
		Player::decItemCount(%player, %item);
		%obj = newObject("", "Mine", "TG::ClayMorMine");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
		%player.throwTime = getSimTime() + 0.5;
		GameBase::setTeam(%obj, %playerTeam);
	}
}
//====End [TG]ClayMorMine====|


//====Begin Repair Patch====|
ItemData RepairPatch {
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
	heading = $InvHeading[Misc];
	shadowDetailMask = 4;
	price = 2;
	validateShape = false;
	validateMaterials = false;
};

function RepairPatch::onCollision(%this,%object){
	if(getObjectType(%object) == "Player"){
		if(GameBase::getDamageLevel(%object)){
			GameBase::repairDamage(%object, 0.5);
			%item = Item::getItemData(%this);
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}
function RepairPatch::onUse(%player,%item){
	Player::decItemCount(%player,%item);
	GameBase::repairDamage(%player, 0.1);
}
//====End Repair Patch====|


//====Begin Cactus Pack====|
$ItemMax[larmor, cactuspack]  = 1;
$ItemMax[marmor, cactuspack]  = 1;
$ItemMax[harmor, cactuspack]  = 1;
$ItemMax[lfemale, cactuspack] = 1;
$ItemMax[mfemale, cactuspack] = 1;

ItemImageData cactuspackImage {
	shapeFile = "cactus2";
	mountPoint = 2;
	mountOffset = { 0, 0.2, -1.7 };
	mountRotation = { 0, 0, 0 };
	mass = 1;
	firstPerson = false;
};
ItemData cactusPack {
	description = "Land Camo";
	shapeFile = "cactus2";
	className = "Backpack";
	heading = $InvHeading[Misc];
	imageType = cactuspackImage;
	shadowDetailMask = 4;
	mass = 1;
	elasticity = 0.2;
	price = 200;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};
//====End Cactus Pack====|
	  


//====Begin Tunneler====|
$InvList[Tunneler] = 1;
$RemoteInvList[Tunneler] = 1;

$ItemMax[larmor, Tunneler]  = 1;
$ItemMax[marmor, Tunneler]  = 1;
$ItemMax[harmor, Tunneler]  = 1;
$ItemMax[lfemale, Tunneler] = 1;
$ItemMax[mfemale, Tunneler] = 1;

ItemData Tunneler {
   description = "Tunneler";
   shapeFile = "sensor_small";
   heading = $InvHeading[Misc];
   shadowDetailMask = 4;
   price = 5;
   className = "HandAmmo";
};

function Tunneler::onUse(%player, %item){
	if($matchStarted) {
		GameBase::getLOSinfo(%player, 225);
		GameBase::setPosition(%player, $los::position);
	}
}
//====End Tunneler====|

// This is more of an ammo refill now, not really a cheat. X
function remoteGiveAll(%clientId){
	%c = %clientId;
	if($TG::GiveallOn != true){
		Client::sendMessage(%c, 1, "Cheats have been turned off.~access_denied.wav");
		return;
	}
	if(!%c.GiveallEnabled && !%c.isAdmin){
		Client::sendMessage(%c,1,"Cheats have not been enabled.~access_denied.wav");
		return;
	}
	%armor = Player::getArmor(Client::getOwnedObject(%c));
	if(%armor=="larmor" || %armor=="lfemale"){
		// I'll just use larmor here, male and female can carry the same
		// ammount of everything as of right now. 5-10-03 1:55pm
		Player::setItemCount(%c,TRocketLauncher,$ItemMax[larmor,TRocketLauncher]);
		Player::setItemCount(%c,FireballAbility,$ItemMax[larmor,FireballAbility]);
		Player::setItemCount(%c,DoublePlasma,$ItemMax[larmor,DoublePlasma]);
		Player::setItemCount(%c,DiscLauncher,$ItemMax[larmor,DiscLauncher]);
		Player::setItemCount(%c,PlasmaCannon,$ItemMax[larmor,PlasmaCannon]);
		Player::setItemCount(%c,TankShredder,$ItemMax[larmor,TankShredder]);
		Player::setItemCount(%c,MineLauncher,$ItemMax[larmor,MineLauncher]);
		Player::setItemCount(%c,LiLPOOmkii,$ItemMax[larmor,LiLPOOmkii]);
		Player::setItemCount(%c,PlasmaGun,$ItemMax[larmor,PlasmaGun]);
		Player::setItemCount(%c,LiLPOOmki,$ItemMax[larmor,LiLPOOmki]);
		Player::setItemCount(%c,Blaster,$ItemMax[larmor,Blaster]);
		Player::setItemCount(%c,Mortar,$ItemMax[larmor,Mortar]);
		Player::setItemCount(%c,LiLFFB,$ItemMax[larmor,LiLFFB]);
		
		Player::setItemCount(%c,TRocketLauncherAmmo,$ItemMax[larmor,TRocketLauncherAmmo]);
		Player::setItemCount(%c,FireballAbilityAmmo,$ItemMax[larmor,FireballAbilityAmmo]);
		Player::setItemCount(%c,TankShredderAmmo,$ItemMax[larmor,TankShredderAmmo]);
		Player::setItemCount(%c,MineLauncherAmmo,$ItemMax[larmor,MineLauncherAmmo]);
		Player::setItemCount(%c,DoublePlasmaAmmo,$ItemMax[larmor,DoublePlasmaAmmo]);
		Player::setItemCount(%c,LiLPOOmkiiAmmo,$ItemMax[larmor,LiLPOOmkiiAmmo]);
		Player::setItemCount(%c,LiLPOOmkiAmmo,$ItemMax[larmor,LiLPOOmkiAmmo]);
		Player::setItemCount(%c,BulletAmmo,$ItemMax[larmor,BulletAmmo]);
		Player::setItemCount(%c,PlasmaAmmo,$ItemMax[larmor,PlasmaAmmo]);
		Player::setItemCount(%c,MortarAmmo,$ItemMax[larmor,MortarAmmo]);
		Player::setItemCount(%c,LiLFFBAmmo,$ItemMax[larmor,LiLFFBAmmo]);
		Player::setItemCount(%c,RepairKit,$ItemMax[larmor,RepairKit]);
		Player::setItemCount(%c,DiscAmmo,$ItemMax[larmor,DiscAmmo]);
		Player::setItemCount(%c,MineAmmo,$ItemMax[larmor,MineAmmo]);
		Player::setItemCount(%c,Grenade,$ItemMax[larmor,Grenade]);
		Player::setItemCount(%c,Beacon,$ItemMax[larmor,Beacon]);
		
	}else if(%armor=="marmor" || %armor=="mfemale"){
		Player::setItemCount(%c,TRocketLauncher, 1);
		Player::setItemCount(%c,FireballAbility, 1);
		Player::setItemCount(%c,PlasmaCannon, 1);
		Player::setItemCount(%c,TankShredder, 1);
		Player::setItemCount(%c,DoublePlasma, 1);
		Player::setItemCount(%c,DiscLauncher, 1);
		Player::setItemCount(%c,MineLauncher, 1);
		Player::setItemCount(%c,LiLPOOmkii, 1);
		Player::setItemCount(%c,PlasmaGun, 1);
		Player::setItemCount(%c,LiLPOOmki, 1);
		Player::setItemCount(%c,Mortar, 1);
		Player::setItemCount(%c,LiLFFB, 1);
		
		Player::setItemCount(%c,TRocketLauncherAmmo, 999);
		Player::setItemCount(%c,FireballAbilityAmmo, 999);
		Player::setItemCount(%c,TankShredderAmmo, 999);
		Player::setItemCount(%c,MineLauncherAmmo, 500);
		Player::setItemCount(%c,DoublePlasmaAmmo, 999);
		Player::setItemCount(%c,LiLPOOmkiiAmmo, 999);
		Player::setItemCount(%c,LiLPOOmkiAmmo, 999);
		Player::setItemCount(%c,BulletAmmo, 500);
		Player::setItemCount(%c,PlasmaAmmo, 999);
		Player::setItemCount(%c,MortarAmmo, 500);
		Player::setItemCount(%c,LiLFFBAmmo, 55);
		Player::setItemCount(%c,DiscAmmo, 500);
		Player::setItemCount(%c,RepairKit, 10);
		Player::setItemCount(%c,MineAmmo, 50);
		Player::setItemCount(%c,Grenade, 350);
		Player::setItemCount(%c,Beacon, 350);
	}else if(%armor == "harmor"){
		Player::setItemCount(%c,TRocketLauncher,$ItemMax[harmor,TRocketLauncher]);
		Player::setItemCount(%c,FireballAbility,$ItemMax[harmor,FireballAbility]);
		Player::setItemCount(%c,PlasmaCannon,$ItemMax[harmor,PlasmaCannon]);
		Player::setItemCount(%c,TankShredder,$ItemMax[harmor,TankShredder]);
		Player::setItemCount(%c,DoublePlasma,$ItemMax[harmor,DoublePlasma]);
		Player::setItemCount(%c,LiLPOOmkii,$ItemMax[harmor,LiLPOOmkii]);
		Player::setItemCount(%c,PlasmaGun,$ItemMax[harmor,PlasmaGun]);
		Player::setItemCount(%c,LiLPOOmki,$ItemMax[harmor,LiLPOOmki]);
		Player::setItemCount(%c,Mortar,$ItemMax[harmor,Mortar]);
		Player::setItemCount(%c,LiLFFB,$ItemMax[harmor,LiLFFB]);
		Player::setItemCount(%c,TRocketLauncherAmmo,$ItemMax[harmor,TRocketLauncherAmmo]);
		Player::setItemCount(%c,FireballAbilityAmmo,$ItemMax[harmor,FireballAbilityAmmo]);
		Player::setItemCount(%c,TankShredderAmmo,$ItemMax[harmor,TankShredderAmmo]);
		Player::setItemCount(%c,DoublePlasmaAmmo,$ItemMax[harmor,DoublePlasmaAmmo]);
		Player::setItemCount(%c,LiLPOOmkiiAmmo,$ItemMax[harmor,LiLPOOmkiiAmmo]);
		Player::setItemCount(%c,LiLPOOmkiAmmo,$ItemMax[harmor,LiLPOOmkiAmmo]);
		Player::setItemCount(%c,BulletAmmo,$ItemMax[harmor,BulletAmmo]);
		Player::setItemCount(%c,PlasmaAmmo,$ItemMax[harmor,PlasmaAmmo]);
		Player::setItemCount(%c,MortarAmmo,$ItemMax[harmor,MortarAmmo]);
		Player::setItemCount(%c,LiLFFBAmmo,$ItemMax[harmor,LiLFFBAmmo]);
		Player::setItemCount(%c,RepairKit,$ItemMax[harmor,RepairKit]);
		Player::setItemCount(%c,MineAmmo,$ItemMax[harmor,MineAmmo]);
		Player::setItemCount(%c,Grenade,$ItemMax[harmor,Grenade]);
		Player::setItemCount(%c,Beacon,$ItemMax[harmor,Beacon]);
	}else if(%armor == "Earmor"){
		Player::setItemCount(%c,MineSweeper,$ItemMax[Earmor,MineSweeper]);
		Player::setItemCount(%c,PlasmaGun,$ItemMax[Earmor,PlasmaGun]);
		
		Player::setItemCount(%c,RepairKit,$ItemMax[Earmor,RepairKit]);
		Player::setItemCount(%c,MineAmmo,$ItemMax[Earmor,MineAmmo]);
		Player::setItemCount(%c,Grenade,$ItemMax[Earmor,Grenade]);
		Player::setItemCount(%c,Beacon,$ItemMax[Earmor,Beacon]);
	}	
	Client::sendMessage(%c,3,"Re-Stocking Inventory~wfailpack.wav");
}