// Note: This Loudmouth turret does not add to the LOS sensor network.
//	It does not even work by LOS.  It works THROUGH walls, etc.
//	No LOS is necessary.  It just shouts insults, and is cloaked.

$InvList[Loudmouth] = 1;
$RemoteInvList[Loudmouth] = 1;
$AutoUse[Loudmouth] = 0;
$Object2Item[mLoudmouth] = Loudmouth;
$CoreType[Loudmouth] = "Beacon";
$Core[Beacon, $BeaconInitCounter++] = Loudmouth;
$DeployedObject[mLoudmouth] = true;

$SellAmmo[Loudmouth] = 1;

// Don't forget to reset the team's count in item.cs

// Who can use this beacon and how much they can carry
$ItemMax[reconarmor, Loudmouth] = 2;
$ItemMax[reconfemalearmor, Loudmouth] = 2;
$ItemMax[espionagearmor, Loudmouth] = 3;
$ItemMax[espionagefemalearmor, Loudmouth] = 3;
$ItemMax[engineerarmor, Loudmouth] = 3;
$ItemMax[engineerfemalearmor, Loudmouth] = 3;
$ItemMax[infantryarmor, Loudmouth] = 3;
$ItemMax[infantryfemalearmor, Loudmouth] = 3;
$ItemMax[falloutarmor, Loudmouth] = 0;
$ItemMax[falloutfemalearmor, Loudmouth] = 0;
$ItemMax[demolitionsarmor, Loudmouth] = 0;
$ItemMax[assaultarmor, Loudmouth] = 3;
$ItemMax[artilleryarmor, Loudmouth] = 0;
$ItemMax[commanderarmor, Loudmouth] = 3;

$TeamItemMax[Loudmouth] = 10;

ItemData Loudmouth
{
   description = "* Loudmouth Core";
   shapeFile = "sensor_small";
   heading = "iBeacons";
   shadowDetailMask = 4;
   price = 50;
   className = "HandAmmo";
};

function Loudmouth::onUse(%player, %item) {
	// First we should check to see if they have a beacon wrapper for this core
	if (Player::incItemCount(%player, Beacon, 0) > 0) {

		// We try to deploy it
		if (mLoudmouth::deployShape(%player, %item)) {
			Player::decItemCount(%player,%item);
			Player::decItemCount(%player,Beacon);
		}
	}
	else {
		Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Core requires a beacon.");
	}
}

MineData mLoudmouth
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

function mLoudmouth::onAdd(%this)
{
	%this.damage = 0;
	mLoudmouth::deployCheck(%this);
}

function mLoudmouth::onCollision(%this, %object)
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
			schedule("GameBase::setActive(" @%this@ ", true);", 2.0, %this);

			%client = Player::getClient(%object);

			%ran = GetRandom() * 20;

			if (%ran < 1) %wav = "wshoot1";
			else if (%ran < 2) %wav = "taunt11";
			else if (%ran < 3) %wav = "taunt4";
			else if (%ran < 4) %wav = "taunt3";
			else if (%ran < 5) %wav = "taunt2";
			else if (%ran < 6) %wav = "taunt10";
			else if (%ran < 7) %wav = "taunt1";
			else if (%ran < 8) %wav = "ovrhere";
			else if (%ran < 9) %wav = "dsgst1";
			else if (%ran < 10) %wav = "dsgst2";

			if (%ran < 10)
				remoteLMSG(%client, %wav);
				//remoteEval(%client, LMSG, %wav);
		}
	}
}

function mLoudmouth::deployCheck(%this)
{
	GameBase::playSequence(%this, 1, "deploy");
 	GameBase::setActive(%this, true);
	GameBase::startFadeout(%this);
}	

function mLoudmouth::onDestroyed(%this)
{
	// Notify RepairBot of destruction
	dRepairBot::initiateRepairs(%this, true);

	// Notify ForceShield of destruction
	ForceShield::targetObjectDestroyed(%this);

	$TeamItemCount[GameBase::getTeam(%this) @ "Loudmouth"]--;
}

function mLoudmouth::deployShape(%player, %item)
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
					%newobj = newObject("Loudmouth","Mine",mLoudmouth);
					addToSet("MissionCleanup", %newobj);
					GameBase::setTeam(%newobj,GameBase::getTeam(%player));
					
					// GameBase::setRotation(%newobj, %rot);
					// GameBase::setPosition(%newobj, $los::position);
					GameBase::throw(%newobj, %player, 30, false);
					Gamebase::setMapName(%newobj,"Loudmouth"@ $totalNumSpyCameras++ @ " " @ Client::getName(%client));
					Client::sendMessage(%client,0,"Loudmouth deployed");
					playSound(SoundPickupBackpack,$los::position);
					$TeamItemCount[GameBase::getTeam(%newobj) @ "Loudmouth"]++;
					echo("MSG: ",%client," deployed an Loudmouth");

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


