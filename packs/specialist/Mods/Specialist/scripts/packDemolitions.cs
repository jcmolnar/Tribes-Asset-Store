$InvList[DemolitionsPack] = 1;
$RemoteInvList[DemolitionsPack] = 1;

// Who can use this pack
$ItemMax[reconarmor, DemolitionsPack] = 0;
$ItemMax[reconfemalearmor, DemolitionsPack] = 0;
$ItemMax[espionagearmor, DemolitionsPack] = 0;
$ItemMax[espionagefemalearmor, DemolitionsPack] = 0;
$ItemMax[engineerarmor, DemolitionsPack] = 0;
$ItemMax[engineerfemalearmor, DemolitionsPack] = 0;
$ItemMax[infantryarmor, DemolitionsPack] = 0;
$ItemMax[infantryfemalearmor, DemolitionsPack] = 0;
$ItemMax[falloutarmor, DemolitionsPack] = 0;
$ItemMax[falloutfemalearmor, DemolitionsPack] = 0;
$ItemMax[demolitionsarmor, DemolitionsPack] = 1;
$ItemMax[assaultarmor, DemolitionsPack] = 0;
$ItemMax[artilleryarmor, DemolitionsPack] = 0;
$ItemMax[commanderarmor, DemolitionsPack] = 0;

ItemImageData DemolitionsPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData DemolitionsPack {
	description = "Demolitions Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = DemolitionsPackImage;
	price = 1000;
	hudIcon = "plasma";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemData TriggeredDemolitionsPack {
	description = "Triggered Demolitions Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = DemolitionsPackImage;
	price = 1000;
	hudIcon = "plasma";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DemolitionsPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else {

		Client::sendMessage(Player::getClient(%player),0,"Explosives armed");

		// remove the demolitions pack
		Player::setItemCount(%player, DemolitionsPack, 0);

		// create a triggered demolitions pack
		%obj = newObject("", "Item", "TriggeredDemolitionsPack", 1, false);
	 	addToSet("MissionCleanup", %obj);

		// throw it
		GameBase::throw(%obj, %player, 15, false);

		// Play sound
		GameBase::playSound(%player, SoundPickupBackpack, 3);

		// schedule it's detonation
		schedule("TriggeredDemolitionsPack::Detonate("@%obj@");", 4.0, %obj);
	}
}


function TriggeredDemolitionsPack::Detonate(%this) {
	// detonate the demolitions pack

	%numberOfExplosives = 20;
	%time = 5;

	for (%i = 0; %i < %numberOfExplosives; %i++) {

		// create each explosive
		%obj = newObject("","Mine","mTimedExplosiveGrenade");
 	 	addToSet("MissionCleanup", %obj);

		// set its timer
		mTimedExplosiveGrenade::setTimer(%obj, %time);

		// throw it out randomly from the pack
		GameBase::throw(%obj, %this, 6, true);
	}

	deleteObject(%this);
}

function TriggeredDemolitionsPack::onCollision(%this, %obj) {
	// Check for defusing
	if(getObjectType(%obj) != "Player") {
		return;
	}

	if(Player::isDead(%obj)) {
		return;
	}

	%client = Player::getClient(%obj);
//	%playerTeam = GameBase::getTeam(%obj);
//	%thisTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);

	// if the object is flying through the air, let's not allow defuses or detonations
	if (!GameBase::isAtRest(%this)) return;

	// If the proper armor touches the explosive
	if (%armor == "engineerarmor" || %armor == "engineerfemalearmor" || %armor == "demolitionsarmor"  || %armor == "commanderarmor") {
		// set success rate
		if (%armor == "demolitionsarmor") {
			%successrate = 9.5;
		}
		else {
			%successrate = 7.5;
		}

		// attempt to disarm the explosive
		%rnd = floor(getRandom() * 10);
		if(%rnd < %successrate) {
			playSound(SoundPickupItem,GameBase::getPosition(%this));

			// Success will remove the explosive
			deleteObject(%this);
			Client::sendMessage(%client, 1, "Explosives have been disarmed.");

			// If a demolitions specialist
			if (%armor == "demolitionsarmor") {

				// Give the player an explosive pack
				Item::giveItem(%obj, DemolitionsPack, 1);
			}
		}
		else {
			// Failure will detonate the explosive
			Client::sendMessage(%client, 1, "Disarm attempt failed!");
			TriggeredDemolitionsPack::Detonate(%this);
			return;
		}
	}

	// other armors may detonate the explosive
	else {
		%rnd = floor(getRandom() * 10);
		if(%rnd > 8) {
			// detonate the explosive
			TriggeredDemolitionsPack::Detonate(%this);
			return;
		}
	}

}
