// Note: This alarm does not add to the LOS sensor network.
//	It does not even work by LOS.  It works THROUGH walls, etc.
//	No LOS is necessary.

$InvList[Alarm] = 1;
$RemoteInvList[Alarm] = 1;
$AutoUse[Alarm] = 0;
$Object2Item[mAlarm] = Alarm;
$CoreType[Alarm] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = Alarm;
$DeployedObject[mAlarm] = true;

$SellAmmo[Alarm] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, Alarm] = 2;
$ItemMax[reconfemalearmor, Alarm] = 2;
$ItemMax[espionagearmor, Alarm] = 3;
$ItemMax[espionagefemalearmor, Alarm] = 3;
$ItemMax[engineerarmor, Alarm] = 3;
$ItemMax[engineerfemalearmor, Alarm] = 3;
$ItemMax[infantryarmor, Alarm] = 3;
$ItemMax[infantryfemalearmor, Alarm] = 3;
$ItemMax[falloutarmor, Alarm] = 0;
$ItemMax[falloutfemalearmor, Alarm] = 0;
$ItemMax[demolitionsarmor, Alarm] = 0;
$ItemMax[assaultarmor, Alarm] = 3;
$ItemMax[artilleryarmor, Alarm] = 0;
$ItemMax[commanderarmor, Alarm] = 3;

$TeamItemMax[Alarm] = 4;

ItemData Alarm
{
   description = "* Alarm Core";
   shapeFile = "sensor_small";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 100;
   className = "HandAmmo";
};

function Alarm::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// We try to deploy it
		if (mAlarm::deployShape(%player, %item)) {
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player,Beacon);
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}

MineData mAlarm
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "Alarm";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = flashExpSmall;
	explosionRadius = 10.0;
	damageValue = 0.01;
	damageType = $NullDamageType;
	kickBackStrength = 20;
	triggerRadius = 10.0;
	maxDamage = 1.0;
};

function mAlarm::onAdd(%this)
{
	%this.damage = 0;
	mAlarm::deployCheck(%this);
}

function mAlarm::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);

	if ((%type == "Player") && GameBase::isActive(%this)) {

		%team = GameBase::getTeam(%this);

		// And if the player is an enemy
		if (GameBase::getTeam(%object) != %team) {

			// Disable this sensor for a couple of seconds
			// to avoid redundant warnings
			GameBase::setActive(%this, false);
			schedule("GameBase::setActive(" @%this@ ", true);", 5.0, %this);

			%client = Player::getClient(%object);

			// Then get the player's name
			%intruder = Client::getName(%client);

			// Get the player's armor
			%armor = Player::getArmor(%object);
			if (%armor == "reconarmor" || %armor == "reconfemalearmor")
				%armor = "Recon armor";
			else if (%armor == "espionagearmor" || %armor == "espionagefemalearmor")
				%armor = "Espionage armor";
			else if (%armor == "engineerarmor" || %armor == "engineerfemalearmor")
				%armor = "Engineer armor";
			else if (%armor == "infantryarmor" || %armor == "infantryfemalearmor")
				%armor = "Infantry armor";
			else if (%armor == "falloutarmor" || %armor == "falloutfemalearmor")
				%armor = "Fallout armor";
			else if (%armor == "demolitionsarmor")
				%armor = "Demolitions armor";
			else if (%armor == "assaultarmor")
				%armor = "Assault armor";
			else if (%armor == "artilleryarmor")
				%armor = "Artillery armor";
			else if (%armor == "commanderarmor")
				%armor = "Commander armor";
			else %armor = "an unknown armor";

			// Report this to the team of this object
			%message = "Intruder Alert! " @ %intruder @ " wearing " @%armor@ "!";
//			if($dedicated)
				echo("SAYTEAM: " @ %message);
		      	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
				if(Client::getTeam(%cl) == %team && !%cl.muted[%clientId])
            				Client::sendMessage(%cl, $MsgTypeGame, %message, %clientId);
		}
	}
}

function mAlarm::deployCheck(%this)
{
	GameBase::playSequence(%this, 1, "deploy");
 	GameBase::setActive(%this, true);
}	

function mAlarm::onDestroyed(%this)
{
	// Notify RepairBot of destruction
	dRepairBot::initiateRepairs(%this, true);

	// Notify ForceShield of destruction
	ForceShield::targetObjectDestroyed(%this);

	$TeamItemCount[GameBase::getTeam(%this) @ "Alarm"]--;
}

function mAlarm::deployShape(%player, %item)
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
					%newobj = newObject("Alarm","Mine",mAlarm);
					addToSet("MissionCleanup", %newobj);
					GameBase::setTeam(%newobj,GameBase::getTeam(%player));
					
					// GameBase::setRotation(%newobj, %rot);
					// GameBase::setPosition(%newobj, $los::position);
					GameBase::throw(%newobj, %player, 30, false);
					Gamebase::setMapName(%newobj,"Alarm#"@ $totalNumSpyCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Alarm deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%newobj) @ "Alarm"]++;
					echo("MSG: ",%client," deployed an Alarm");

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



