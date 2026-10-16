$InvList[FlagCarrierPack] = 1;
$RemoteInvList[FlagCarrierPack] = 1;

// Who can use this pack
$ItemMax[reconarmor, FlagCarrierPack] = 0;
$ItemMax[reconfemalearmor, FlagCarrierPack] = 0;
$ItemMax[espionagearmor, FlagCarrierPack] = 0;
$ItemMax[espionagefemalearmor, FlagCarrierPack] = 0;
$ItemMax[engineerarmor, FlagCarrierPack] = 1;
$ItemMax[engineerfemalearmor, FlagCarrierPack] = 1;
$ItemMax[infantryarmor, FlagCarrierPack] = 0;
$ItemMax[infantryfemalearmor, FlagCarrierPack] = 0;
$ItemMax[falloutarmor, FlagCarrierPack] = 0;
$ItemMax[falloutfemalearmor, FlagCarrierPack] = 0;
$ItemMax[demolitionsarmor, FlagCarrierPack] = 0;
$ItemMax[assaultarmor, FlagCarrierPack] = 0;
$ItemMax[artilleryarmor, FlagCarrierPack] = 0;
$ItemMax[commanderarmor, FlagCarrierPack] = 1;

ItemImageData FlagCarrierPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData FlagCarrierPack
{
	description = "Flag Carrier Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = FlagCarrierPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 125;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlagCarrierPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
}


function FlagCarrierPack::pickupFlag(%this, %object) {
	// This function allows the player to pickup their own flag while wearing
	// the FlagCarrierPack.
	// By RCabrera for the Specialist mod, 3/17/00

	%name = Item::getItemData(%this);
	%playerTeam = GameBase::getTeam(%object);
	%flagTeam = GameBase::getTeam(%this);
	%playerClient = Player::getClient(%object);
	%playerName = Client::getName(%playerClient);

	if(%object.outArea == "") {
		Player::setItemCount(%object, Flag, 1);
		Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
		Player::setItemCount(%object, FlagCarrierPack, 0);
		Item::hide(%this, true);
		$flagAtHome[1] = false;
		%this.atHome = false;
		%this.carrier = %object;
		this.pickupSequence++;
		%object.carryFlag = %this;
		 if(%this.fadeOut) {
			GameBase::startFadeIn(%this);
			%this.fadeOut= "";
		}

		// Alert the player's team
		TeamMessages(1, %playerTeam, %playerName@" is moving your team's flag.~wflag1.wav", %flagTeam, "");
		Client::sendMessage(%playerClient, 1, "You have 30 seconds to place the flag on a stand.");
	}
	else
		Client::sendMessage(%playerClient, 1, "Flag not in mission area.");
}

function FlagCarrierPack::setFlagCarryTimer(%this, %object) {

	// set the timer for limiting flag carry time to 30 seconds
	%time = 30;

	schedule("FlagCarrierPack::checkFlagsTime(" @ %this @");", %time);

}

function FlagCarrierPack::checkFlagsTime(%flag) {
	// echo("Flag: " @%flag);
	%client = Player::getClient(%flag.carrier);
	%player = %flag.carrier;

	// if carried by an enemy, then cancel
	if (GameBase::getTeam(%player) != GameBase::getTeam(%flag))
		return;

	// if on a flagstand, then cancel
	if (%flag.atHome) return;

	// the flag expires
	// echo("Flag has expired");
	GameBase::startFadeOut(%flag);
      	Player::setItemCount(%flag.carrier, "Flag", 0);
	%clientName = Client::getName(%client);
	%flagTeam = GameBase::getTeam(%flag);

	if(%client != -1) {
		TeamMessages(1, %flagTeam, %clientName @ " didn't put your flag on a flag stand in time!  It was returned to its initial position.~wflagreturn.wav", %flagTeam, "");
		Client::sendMessage(%client, 0, "You didn't get to a flag stand in time!  It was returned to its initial position.");
	}
	else
		MessageAll(0, "A flag was not put in a flag stand in time!  It was returned to its initial position.~wflagreturn.wav");

	// return flag to stand
	GameBase::setPosition(%flag, %flag.originalPosition);
	Item::setVelocity(%flag, "0 0 0");
//	%flag.flagStand = "";
	%flag.atHome = true;
	$flagAtHome[1] = true;

	%team = GameBase::getTeam(%flag);

	GameBase::startFadeIn(%flag);
	Item::hide(%flag, false);

	(%flag.carrier).carryFlag = "";
      	%flag.carrier = -1;
//        	Flag::clearWaypoint(%client, false);
//      	ObjectiveMission::ObjectiveChanged(%flag);
//	ObjectiveMission::checkScoreLimit();
	%flag.lastTeam = "";

}

function FlagCarrierPack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Flag Carrier Pack allows you to pick up your own flag for a brief period.");
	}
}
