// Specialist personal shield effect

// number of seconds that the shield stays active
$PersonalShieldActiveTime = 30;

function ActivatePersonalShield(%player) { 
	// This function will activate the personal shield
	// By RCabrera for the Specialist mod, 3/1/00

	// Get Client ID
	%clientId = Player::getClient(%player);

	// Activate shield
	%player.shieldStrength = 0.005;
	%player.personalShieldActivated = true;

	// Print message
	Client::sendMessage(%clientId, 0, "Personal Shield Active");
	GameBase::playSound(%player, ForceFieldOpen, 0);

	// Schedule shield deactivation
	schedule("DeactivatePersonalShield(" @%player@ ");", $PersonalShieldActiveTime, %player);
}

function DeactivatePersonalShield(%player) { 
	// This function will deactivate the personal shield
	// By RCabrera for the Specialist mod, 3/1/00

	// Set shield to zero
	%player.shieldStrength = 0;
	%player.personalShieldActivated = false;

	// Get Client ID
	%clientId = Player::getClient(%player);

	// Print message
	Client::sendMessage(%clientId, 0, "Personal Shield Inactive");
	GameBase::playSound(%player, ForceFieldOpen, 0);
}
