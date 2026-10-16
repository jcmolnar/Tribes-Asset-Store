// Specialist stealth effect

function Stealthify(%player, %radius) {
	// This function will fadeout the player and associate a 
	// sensor-jammed area around them (defined by radius).
	// By RCabrera 2/9/00

	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + %radius;
	Player::setSensorSupression(%player, %rate);
	%player.guiLock = true;
	%clientId = Player::getClient(%player);
	%clientId.guiLock = true;
}

function Destealthify(%player, %radius) {
	// This function will fade in the player undo
	// their sensor suppression (be sure radius is correct).
	// By RCabrera 2/9/00

	GameBase::startFadein(%player);
	%rate = Player::getSensorSupression(%player) - %radius;
	Player::setSensorSupression(%player, %rate);
	Player::trigger(%player, $BackpackSlot, false);
	%player.guiLock = "";
	%clientId = Player::getClient(%player);
	%clientId.guiLock = "";
}

