// Specialist targeted effect

function Target(%object) {
	// This function will target an object.
	// By RCabrera 4/26/00

	GameBase::setIsTarget(%object, true);
}

function DeTarget(%object) {
	// This function will de-target an object.
	// By RCabrera 4/26/00

	GameBase::setIsTarget(%object, false);
}

