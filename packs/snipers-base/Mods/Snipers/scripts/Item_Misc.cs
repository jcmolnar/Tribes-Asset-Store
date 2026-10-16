exec(turret);
//---------------------------------------------------------------------------
//
//	MISC ITEMS
//
//---------------------------------------------------------------------------

//----------------------------------------------------------------------------
//	REPAIR KIT
//----------------------------------------------------------------------------
$AutoUse[RepairKit] = false;

ItemData RepairKit
{
   description = "Repair Kit";
   shapeFile = "armorKit";
   heading = "dMiscellany";
   shadowDetailMask = 4;
   price = 35;
   validateShape = true;
   validateMaterials = true;
};

function RepairKit::onUse(%player,%item) 
{
	Player::decItemCount(%player,%item);
	%armor = Player::getArmor(%player);
	GameBase::repairDamage(%player,%armor.maxdamage / 3);
	%c = Player::getClient(%player);
	$poisonTime[%c] = 0;
	$burnTime[%c] = 0;
}


//----------------------------------------------------------------------------
//	MINEAMMO
//----------------------------------------------------------------------------

ItemData MineAmmo
{
   description = "Mine";
   shapeFile = "mineammo";
   heading = "dMiscellany";
   shadowDetailMask = 4;
   price = 10;
	className = "HandAmmo";
};

function MineAmmo::onUse(%player,%item) 
{
	if($matchStarted) 
	{
		if(%player.throwTime < getSimTime() ) 
		{
			Player::decItemCount(%player,%item);
			%armor = Player::getArmor(%player);
			%client = Player::getClient(%player);
			if ($Deathmatch)
			%obj = newObject("","Mine","DMMine");
			else 
			{
			%obj = newObject("","Mine","antipersonelMine");
			GameBase::setTeam (%obj,GameBase::getTeam (%client));
			}
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------------------------------
//	GRENADE
//----------------------------------------------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "dMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted) {
		if(%player.throwTime < getSimTime() ) {
			Player::decItemCount(%player,%item);
			%obj = newObject("","Mine","Handgrenade");
 	 	 	addToSet("MissionCleanup", %obj);
			%client = Player::getClient(%player);
			GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}


//----------------------------------------------------------------------------
//	BEACON
//----------------------------------------------------------------------------

ItemData Beacon
{
   description = "Beacon";
   shapeFile = "sensor_small";
   heading = "dMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Beacon::onUse(%player,%item)
{
	if (Beacon::deployShape(%player,%item)) {
		Player::decItemCount(%player,%item);
	}
}

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
//	REPAIRPATCH
//----------------------------------------------------------------------------

ItemData RepairPatch
{
	description = "Repair Patch";
	className = "Repair";
	shapeFile = "armorPatch";
   heading = "dMiscellany";
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

//----------------------------------------------------------------------------
//	SMOKE BOMB
//----------------------------------------------------------------------------

ItemImageData SmokeImage 
{ 
	shapeFile = "grenade"; 
	mountPoint = 0; 
	weaponType = 0; 
	accuFire = false; 
	reloadTime = 0.2; 
	fireTime = 0.5; 
	lightType = 3; 
	lightRadius = 0; 
	lightTime = 0; 
	lightColor = { 0.6, 1, 1.0 }; 
	sfxActivate = SoundPickUpWeapon; 
}; 

ItemData Smoker 
{ 
	description = "Demo. Grenade"; 
	className = "Tool"; 
	heading = "dMiscellany"; 
	shadowDetailMask = 4; 
	imageType = SmokeImage; 
	price = 200; 
	showWeaponBar = false; 
	shapeFile = "grenade"; 
};

function SmokeImage::onFire(%player, %slot) 
{ 
	%client = Player::getClient(%player); 
	Player::decItemCount(%player,Smoker,1); 
	%obj = newObject("","Mine","Puffbomb"); 
	addToSet("MissionCleanup", %obj); 
	GameBase::throw(%obj,%player,5,false); 
	%player.throwTime = getSimTime() + 0.5;
	GameBase::setTeam(%obj,GameBase::getTeam (%client));
}

MineData Puffbomb 
{ 
	mass = 0.3; 
	drag = 1.0; 
	density = 2.0; 
	elasticity = 0.15; 
	friction = 1.0; 
	className = "Handgrenade"; 
	description = "Handgrenade"; 
	shapeFile = "grenade"; 
	shadowDetailMask = 4; 
	explosionId = puffExp; 
	explosionRadius = 7.5; 
	damageValue = 0.01; 
	damageType = $BlindDamageType; 
	kickBackStrength = 10; 
	triggerRadius = 0.5; 
	maxDamage = 2.0; 
}; 

function Puffbomb::onAdd(%this) { 
	schedule("Mine::Detonate(" @ %this @ ");",1.6,%this); 
} 

function Puffbomb::onDestroyed(%this) {
	Aoe::deployShape(%this, 25, $BlindDamageType, 17);
	GameBase::applyRadiusDamage($BlindDamageType, getBoxCenter(%this), 40, 1, 5, %this);
}