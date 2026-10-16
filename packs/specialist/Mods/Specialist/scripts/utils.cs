// Specialist utility functions

function SpecialistDropWeapon (%player) {
	// This function causes the player to drop their currently 
	// mounted weapon.
	// By RCabrera 2/14/00

	// echo("Dropping weapon for player: " @%player);

	// Get their currently mounted weapon
	%weapon = Player::getMountedItem(%player, $WeaponSlot);

	// Cause player to drop this weapon
	if (%weapon != -1) {
		Player::unmountItem(%player, $WeaponSlot);
		%success = Player::dropItem(%player, %weapon);
	}

	return %success;
}

function SpecialistTriggerWeapon (%player) {
	// This function causes the player to fire their currently 
	// mounted weapon.
	// By RCabrera 2/14/00

	// echo("Triggering weapon for player: " @%player);

	// Get their currently mounted weapon
	%weapon = Player::getMountedItem(%player, $WeaponSlot);

	// Cause player to drop this weapon
	if (%weapon != -1) {
		%success = Player::useItem(%player, %weapon);
	}

	return %success;
}

function SpecialistDropPack (%player) {
	// This function causes the player to drop their currently 
	// mounted pack.
	// By RCabrera 2/14/00

	// echo("Dropping pack for player: " @%player);

	// Get their currently carried pack
	%pack = Player::getMountedItem(%player, $BackpackSlot);

	// Cause player to drop the pack
	if (%pack != -1) {
		Player::unmountItem(%player, $BackpackSlot);
		return Player::dropItem(%player, %pack);
	}
}

function SpecialistTriggerPack (%player) {
	// This function causes the player to trigger their currently 
	// mounted pack.
	// By RCabrera 2/14/00

	// echo("Triggering pack for player: " @%player);

	// Get their currently carried pack
	%pack = Player::getMountedItem(%player, $BackpackSlot);

	// Cause player to trigger this pack
	if (%pack != -1) {
		%success = Player::useItem(%player, %pack);
	}

	return %success;
}

function SpecialistDropBeacon (%player) {
	// This function causes the player to drop their beacons.
	// By RCabrera 2/14/00

	// echo("Dropping beacon for player: " @%player);
	
	// Find the number of beacons they carry
	%numBeacons = Player::decItemCount(%player, Beacon, 0);

	// Cause player to drop all their beacons
	for (%i = 0; %i < %numBeacons; %i++) {
		Player::dropItem(%player, Beacon);
	}

	return %numBeacons;
}

function SpecialistDropFlag (%player) {
	// This function causes the player to drop the flag.
	// By RCabrera 2/14/00

	// echo("Dropping flag for player: " @%player);

	// Get their currently carried flag
	%flag = Player::getMountedItem(%player, $FlagSlot);

	// Cause player to drop the flag
	if (%flag != -1) {
		Player::unmountItem(%player, $FlagSlot);
		return Player::dropItem(%player, %flag);
	}
}

function SpecialistDeployBeacon (%player) {
	// This function causes the player to deploy their currently 
	// carried beacons.
	// By RCabrera 2/14/00

	// echo("Deploying beacon for player: " @%player);

	// Find the number of beacons they carry
	%numBeacons = Player::decItemCount(%player, "Beacon", 0);

	// Cause player to deploy all their beacons
	for (%i = 0; %i < %numBeacons; %i++) {
		Player::useItem(%player, "Beacon");
	}
	
	return %numBeacons;
}

function SpecialistCountTurretsMax (%turretType) {
	// This function will return the number of specified turrets in the area
	// using the MAX turret box.
	// By RCabrera for the Specialist mod, 3/1/00

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);

	// Count the turrets
	%number = CountObjects(%set, %turretType, %num);

	deleteObject(%set);

	return %number;
}

function SpecialistCountTurretsMin (%turretType) {
	// This function will return the number of specified turrets in the area
	// using the MIN turret box.
	// By RCabrera for the Specialist mod, 3/1/00

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);

	// Count the turrets
	%number = CountObjects(%set, %turretType, %num);

	deleteObject(%set);

	return %number;
}

function SpecialistCountAllTurretsMax () {
	// This function will return the number of turrets in the area
	// using the MAX turret box.
	// By RCabrera for the Specialist mod, 3/1/00

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);

	// Count the turrets
	%number = CountTurrets(%set, %num);

	deleteObject(%set);

	return %number;
}

function SpecialistCountAllTurretsMin () {
	// This function will return the number of turrets in the area
	// using the MIN turret box.
	// By RCabrera for the Specialist mod, 3/1/00

	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);

	// Count the turrets
	%number = CountTurrets(%set, %num);

	deleteObject(%set);

	return %number;
}

function SpecialistCheckDeploySurface(%obj) {
	// This function checks for a valid deploy surface and returns true if valid
	// By RCabrera for the Specialist mod, 3/1/00

	%surface = getObjectType(%obj);
	%name = GameBase::getDataName(%obj);

	if (%surface == "SimTerrain" || %surface == "InteriorShape" || $CanDeployOnto[%name])
		return true;
	else
		return false;
}

function SpecialistCheckDeploySurfaceStack(%obj, %deployItem) {
	// This function checks for a valid deploy surface and returns true if valid.
	// This variation allows for stacking of this item type.
	// By RCabrera for the Specialist mod, 3/7/00

	%surface = getObjectType(%obj);
	%name = GameBase::getDataName(%obj);
	// echo("Name: "@%name);
	// echo("Item: "@%deployItem);

	if (%surface == "SimTerrain" || %surface == "InteriorShape" || 
		$CanDeployOnto[%name] || %name == %deployItem)
		return true;
	else
		return false;
}

function SpecialistCheckDeploySurfaceOutsideOnly(%obj) {
	// This function checks for a valid turret/station deploy surface and returns true if valid
	// Works only for deploys on terrain
	// By RCabrera for the Specialist mod, 3/6/00

	%surface = getObjectType(%obj);
	if (%surface == "SimTerrain")
		return true;
	else
		return false;
}

function SpecialistCheckDeploySurfaceTraditional(%obj) {
	// This function checks for a valid turret/station deploy surface and returns true if valid
	// Works only for deploys on terrain and interior shapes
	// By RCabrera for the Specialist mod, 5/22/00

	%surface = getObjectType(%obj);
	if (%surface == "SimTerrain" || %surface == "InteriorShape")
		return true;
	else
		return false;
}

function CountTurrets(%set, %num) {
	%count = 0;
	for(%i=0;%i<%num;%i++) {
		%obj= GameBase::getDataName(Group::getObject(%set,%i));
		if(%obj.ClassName == Turret) 
			%count++;
	}
	return %count;
}

function SpecialistAttemptHack (%this, %player) {
	// This function will attempt to hack into an enemy object and reprogram it.
	// By RCabrera for the Specialist mod, 4/4/00

	// If the object  is already on the same team as the player, return
	if (GameBase::getTeam(%this) == GameBase::getTeam(%player)) return;

	// The more times that this function is called, the higher the probability of success
	// Multiple hackers can join forces against one object

	// If object is not powered, we can't hack it

	if (GameBase::getDamageState(%this) != "Enabled" ) {
		$HackAttempt[%this] = "";
		%client = Player::getClient(%player);
		Client::sendMessage(%client, 0, "Object is not powered");
		return;
	}

	// if the hack is just beginning
	if ($HackAttempt[%this] == "") {

		%client = Player::getClient(%player);
		Client::sendMessage(%client, 0, "Beginning hack...");

		$HackAttempt[%this] = 10; // percentage of success

		schedule("SpecialistPerformHack("@%this@", "@%player@", "@$HackAttempt[%this]@");", 1.3);

	}
	else {
		$HackAttempt[%this] += 10; // increase success rate
		if ($HackAttempt[%this] > 50) $HackAttempt[%this] = 50; // cap the success rate at 50%
	}
}

SoundData SoundHackSuccess
{
   wavFileName = "sensor_deploy.wav";
   profile = Profile3dNear;
};

SoundData SoundHackFailure
{
   wavFileName = "Access_Denied.wav";
   profile = Profile3dNear;
};

function SpecialistPerformHack(%this, %player, %successrate) {
	
	%client = Player::getClient(%player);

	// If object is a permanent sensor or turret
	%class = getObjectType(%obj);
	%name = GameBase::getDataName(%obj);

	// if not a deployable object
	if (!$DeployedObject[%name]) {

		// If object is not powered or is destroyed, we can't hack it
		%state = GameBase::getDamageState(%this);
		if (!GameBase::isPowered(%this) && %state != "Enabled") {
			$HackAttempt[%this] = "";
			Client::sendMessage(%client, 0, "Object is not powered");
			return;
		}
	}

	// if success rate has changed since this function was first called
	if (%successrate < $HackAttempt[%this]) {

		// reschedule the actual hack
		schedule("SpecialistPerformHack("@%this@", "@%player@", "@$HackAttempt[%this]@");", 1.0);
		Client::sendMessage(%client, 0, "Hacking...");
	}
	else {

		// see if we are successful
		%rnd = floor(getRandom() * 100);

		if (%rnd < $HackAttempt[%this]) {
			// success!
			Client::sendMessage(%client, 0, "Hack successful!");

			// record original team (for unhacking)
			%this.originalTeam = GameBase::getTeam(%this);

			GameBase::setTeam(%this, GameBase::getTeam(%player));
			Turret::onSetTeam(%this, %this.originalTeam);
			GameBase::playSound(%this, SoundHackSuccess, 3);

			if ($Specialist::unHackTime != 0) {
				schedule("SpecialistUnhack("@%this@");", $Specialist::unHackTime);
			}
		}
		else {
			// failure!
			Client::sendMessage(%client, 1, "Hack failed");
			GameBase::playSound(%this, SoundHackFailure, 3);
		}
		$HackAttempt[%this] = "";
	}
}

function SpecialistUnhack(%this) {
	// This function is called when the time limit for hacked turrets and sensors has expired.
	// It returns the object to it's original team.
	// By RCabrera for the Specialist mod, 6/25/00

	%currentTeam = GameBase::getTeam(%this);
	GameBase::setTeam(%this, %this.originalTeam);
	Turret::onSetTeam(%this, %currentTeam);
	GameBase::playSound(%this, SoundHackSuccess, 3);
}

SoundData SoundUndeploy
{
   wavFileName = "rmt_turret.wav";
   profile = Profile3dNear;
};

function SpecialistUndeploy(%player) {
	// This function will perform undeploys on any deployables.
	// By RCabrera for the Specialist mod, 4/16/00

	// get client
	%client = Player::getClient(%player);

	// get armor
	%armor = Player::getArmor(%player);

	// if the player is not an engineer, return
	if (%armor != engineerarmor && %armor != engineerfemalearmor) {
		return;
	}

	// if the engineer is wearing a pack, return
	if (Player::getItemClassCount(%player, "Backpack") > 0) {
		Client::sendMessage(%client, 0, "You already have a backpack");
		return;
	}

	// get LOS and check to see what is there
	GameBase::getLOSinfo(%player, 3);
	%obj = $los::object;

	// check to see if the object is a deployable type
	%class = getObjectType(%obj);
	%name = GameBase::getDataName(%obj);
	
	// echo("Class: " @%class);
	// echo("Name: " @%name);

	if (%class != Turret && %class != StaticShape && %class != Mine && %class != Sensor) return;

	// if the object is not on player's team, return
	if (GameBase::getTeam(%obj) != GameBase::getTeam(%player)) {
		return;
	}

	// now we assume that the engineer is trying to pick up a deployable

	// check the damage state
	if (GameBase::getDamageState(%obj) != "Enabled") {
		Client::sendMessage(%client, 0, "Cannot undeploy -- Object is disabled");
		return;
	}

	// if the turret is not one of these deployable types, return
	if (%class == Turret) {
		if ($DeployedObject[%name] == "") {
			Client::sendMessage(%client, 0, "You cannot undeploy this object");
			return;
		}
	}
	else if (%class == StaticShape) {
		if ($DeployedObject[%name] == "") {
			Client::sendMessage(%client, 0, "You cannot undeploy this object");
			return;
		}
	}
	else if (%class == Mine) {
		if ($DeployedObject[%name] == "") {
			Client::sendMessage(%client, 0, "You cannot undeploy this object");
			return;
		}
	}
	else if (%class == Sensor) {
		if ($DeployedObject[%name] == "") {
			Client::sendMessage(%client, 0, "You cannot undeploy this object");
			return;
		}
	}
	else return;

	// If we are trying to undeploy a flag stand with a flag on it
	if (%name == "dFlagStand" && %obj.hasFlag) {
		Client::sendMessage(%client, 0, "Cannot undeploy -- flag on stand");
		return;
	}

	Client::sendMessage(%client, 0, "Undeploying...");

	// Call the onUndeployed function for the object
	GameBase::virtual(%obj, "onUndeployed", %obj);

	// remove the object
	deleteObject(%obj);

	// update team maxes
	$TeamItemCount[GameBase::getTeam(%player) @ $Object2Item[%name]]--;

	// give the engineer the corresponding item
	Player::setItemCount(%player, $Object2Item[%name], 1);
	Player::mountItem(%player, $Object2Item[%name], $BackpackSlot);

	playSound(SoundUndeploy,GameBase::getPosition(%player));
}
	
function SpecialistArmorOnDon (%player, %armor) {
	// This function is called when the player puts on a new armor
	// We will use this to set the abilities of the armor when donned
	// By RCabrera for the Specialist mod, 4/21/00

	// if Recon armor
	if (%armor == "reconarmor" || %armor == "reconfemalearmor") {
		// increase sensor range
		Player::setDetectParameters(%player, 0.0001, 0);
	}
	// else
	else {
		// reset sensor range
		Player::setDetectParameters(%player, 0.03, 0);
	}

	// if Commander armor
	if (%armor == "commanderarmor") {
		// set autorepair rate
		GameBase::setAutoRepairRate(%player, 0.02);
	}
	// else
	else {
		// reset autorepair rate
		GameBase::setAutoRepairRate(%player, 0);
	}

}

function SpecialistBuyArmorPresets(%client, %armor) {
	// This function is called when the player puts on a new armor
	// It buys "standard" equipment for that armor automatically
	// to help newbies learn, and to help in setting favorites.
	// By RCabrera for the Specialist mod, 5/22/00

	%player = Client::getOwnedObject(%client);

	// if not at a station, we don't buy anything
	if (%player.station == "") {
		return;
	}

	// Sell all
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1) {
		%item = getItemData(%i);
		%numsell = 0;
		%count = Player::getItemCount(%client,%item);
		if(%count > 0) {  
			%numsell =  %count;
		}
		if(%numsell > 0 && %item.className != Armor) {
			teamEnergyBuySell(%player, (%item.price * %numsell));
			Player::setItemCount(%client, %item, %count - %numsell);  
			updateBuyingList(%client);
		} 
	}

	// buy armor presets

	if (%armor == "reconarmor" || %armor == "reconfemalearmor") {
		buyItem(%client, "SniperRifle");
		buyItem(%client, "DiscLauncher");
		buyItem(%client, "PlasmaGun");
		buyItem(%client, "EnergyPack");
		buyItem(%client, "EMPGrenade");
		buyItem(%client, "DecoyMine");
		buyItem(%client, "iPulseSensor");
		buyItem(%client, "Eavesdropper");
		return;
	}
	if (%armor == "espionagearmor" || %armor == "espionagefemalearmor") {
		buyItem(%client, "LaserPistol");
		buyItem(%client, "Chaingun");
		buyItem(%client, "DiscLauncher");
		buyItem(%client, "InfiltrationPack");
		buyItem(%client, "FlashGrenade");
		buyItem(%client, "FlagMine");
		buyItem(%client, "SpyCamera");
		return;
	}
	if (%armor == "infantryarmor" || %armor == "infantryfemalearmor") {
		buyItem(%client, "DiscLauncher");
		buyItem(%client, "Chaingun");
		buyItem(%client, "GrenadeLauncher");
		buyItem(%client, "PlasmaGun");
		buyItem(%client, "EnergyPack");
		buyItem(%client, "ShrapnelGrenade");
		buyItem(%client, "NormalMine");
		return;
	}
	if (%armor == "falloutarmor" || %armor == "falloutfemalearmor") {
		buyItem(%client, "RadiationCanister");
		buyItem(%client, "GasCanister");
		buyItem(%client, "AcidSprayer");
		buyItem(%client, "AcidCanister");
		buyItem(%client, "EnergyPack");
		buyItem(%client, "PoisonGasGrenade");
		buyItem(%client, "EMPMine");
		return;
	}
	if (%armor == "engineerarmor" || %armor == "engineerfemalearmor") {
		buyItem(%client, "EngRepairGun");
		buyItem(%client, "Flamethrower");
		buyItem(%client, "Shotgun");
		buyItem(%client, "PlasmaGun");
		buyItem(%client, "ExplosiveGat");
		buyItem(%client, "MedicPack");
		buyItem(%client, "SmokeLineGrenade");
		buyItem(%client, "EMPMine");
		buyItem(%client, "Camera");
		buyItem(%client, "MotionSensor");
		return;
	}
	if (%armor == "demolitionsarmor") {
		buyItem(%client, "RemoteDetonator");
		buyItem(%client, "ExplosiveGat");
		buyItem(%client, "DiscLauncher");
		buyItem(%client, "GrenadeLauncher");
		buyItem(%client, "Chaingun");
		buyItem(%client, "DemolitionsPack");
		buyItem(%client, "TimedExplosiveGrenade");
		buyItem(%client, "NormalMine");
		buyItem(%client, "RemoteBomb");
		return;
	}
	if (%armor == "assaultarmor") {
		buyItem(%client, "Flamethrower");
		buyItem(%client, "AntiPersonnelCannon");
		buyItem(%client, "AcidCanister");
		buyItem(%client, "EMPCannon");
		buyItem(%client, "Mortar");
		buyItem(%client, "EnergyPack");
		buyItem(%client, "IncendiaryGrenade");
		buyItem(%client, "IncendiaryMine");
		buyItem(%client, "PersonalShield");
		return;
	}
	if (%armor == "artilleryarmor") {
		buyItem(%client, "ArtilleryShell");
		buyItem(%client, "FieldMortar");
		buyItem(%client, "EMPCannon");
		buyItem(%client, "AntiPersonnelCannon");
		buyItem(%client, "FlakCannon");
		buyItem(%client, "RocketLauncher");
		buyItem(%client, "EnergyPack");
		buyItem(%client, "EMPGrenade");
		buyItem(%client, "EMPMine");
		buyItem(%client, "PersonalShield");
		return;
	}
	if (%armor == "commanderarmor") {
		buyItem(%client, "Shotgun");
		buyItem(%client, "LaserPistol");
		buyItem(%client, "Flamethrower");
		buyItem(%client, "AntiPersonnelCannon");
		buyItem(%client, "EngRepairGun");
		buyItem(%client, "GrenadeLauncher");
		buyItem(%client, "FlamePack");
		buyItem(%client, "SmokeLineGrenade");
		buyItem(%client, "FlagMine");
		buyItem(%client, "PersonalShield");
		return;
	}
}

SoundData SoundHandAttack
{
   wavFileName = "shieldhit.wav";
   profile = Profile3dNear;
};

SoundData SoundHandAttackMiss
{
   wavFileName = "throwitem.wav";
   profile = Profile3dNear;
};

function HandCombat(%player, %target) {
	// This function is called when an Infantry specialist collides with enemy players
	// It damages the enemy player.
	// By RCabrera for the Specialist mod, 4/21/00
	// echo("Hand combat...");

	// if player or target is dead, then don't attack
	if(Player::isDead(%target) || Player::isDead(%player)) return;

	// If probability dictates it
	%rnd = floor(getRandom() * 10);
	if (%rnd < 6) {

		// Play "hit" sound effect
		GameBase::playSound(%target, SoundHandAttack, 3);

		// Apply hand damage to the target
		GameBase::applyDamage(%target, $HandDamageType, 0.1, GameBase::getPosition(%target), "0 -1 0", "0 0 0", GameBase::getOwnerClient(%player));

	}
	else {
		// Play the "miss" sound effect
		GameBase::playSound(%target, SoundHandAttackMiss, 3);
	}
}

SoundData SoundEffectRepairs
{
   wavFileName = "repair.wav";
   profile = Profile3dNear;
};

function EffectRepairs(%player, %target) {
	// This function is called when an Engineer specialist collides with friendly objects or players
	// It repairs them.
	// By RCabrera for the Specialist mod, 4/21/00
	// echo("Effecting repairs...");

	// If probability dictates it
	%rnd = floor(getRandom() * 10);
	if (%rnd < 5) {

		// Get damage state of target
		%state = GameBase::getDamageState(%target);
		
		// if the target is okay, then don't repair it
		if (%state == "Enabled") return;

		// Get damage level of target
		%damage = GameBase::getDamageLevel(%target);

		// Decrease damage level of target
		%damage -= 0.05;
		GameBase::setDamageLevel(%target, %damage);

		GameBase::playSound(%target, SoundEffectRepairs, 3);
	}
}

function SpecialistInitClient(%clientId) {
	// This function reinits all effects on the player.
	// By RCabrera for the Specialist mod, 6/28/00

	%playerId = Client::getOwnedObject(%clientId);

	// Set core prefs
	%clientId.currentGrenadeCore = ShrapnelGrenade;
	%clientId.currentMineCore = NormalMine;
	%clientId.currentBeaconCore = PersonalShield;

	// We must clear any effects that remain on the player
	$PoisonGasTTG[%clientId] = 0;
	$BlindTTG[%clientId] = 0;
	$burnTime[%clientId] = 0;
	$EMPTime[%clientId] = 0;
	$AcidBurnTime[%clientId] = 0;
	$TankShielded[%clientId] = "";
	$BuyingFavs[%clientId] = false;

	// Set shield to zero (in case they had a personal shield activated)
	%this.personalShieldActivated = false;
	%playerId.shieldStrength = 0;
}

function String::len(%string) {
	// from <http://www.planetstarsiege.com/scripting/tribes/filtermessage.shtml>
	for(%i=0; String::getSubStr(%string, %i, 1) != ""; %i++) %length++;
	return %length;
}

function String::replace(%string, %search, %replace)    {
	// From <http://www.planetstarsiege.com/scripting/tribes/filtermessage.shtml>
	// with modifications and documentation by RCabrera for the Specialist mod, 7/10/00

	// get the location of the first occurence of the search string
	%loc = String::findSubStr(%string, %search);

	for(%loc; %loc != -1; %i++)  {   

		// get the lengths of the string and the search string
		%lenstr = String::len(%string);
		%lenser = String::len(%search);

		// get the string before the targeted substring
		// %part1 = String::getSubStr(%string, 0, %loc - 1); // old line
		// New Line by RCabrera for the Specialist mod, 7/10/00
		%part1 = String::getSubStr(%string, 0, %loc);

		// get the string after the targeted substring
		%part2 = String::getSubStr(%string, %loc + %lenser, %lenstr - %loc - %lenser);

		// construct a new string
		// %string = %part1 @ " " @ %replace @ %part2; // old line
		// New Line by RCabrera for the Specialist mod, 7/10/00
		%string = %part1 @ %replace @ %part2;

		// get the location of the next occurence of the search string
		%loc = String::findSubStr(%string, %search);    
	}

	// return the string
	return %string; 
}

