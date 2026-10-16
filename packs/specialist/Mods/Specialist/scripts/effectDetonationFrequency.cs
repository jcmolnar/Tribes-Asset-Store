function DetonationFrequency::initializeData(%nothing) {
	// This function will clear all the data
	// for the Remote Bomb Detonation Frequency data arrays.  
	// By RCabrera for the Specialist mod, 2/18/00

	// For each team
	for (%team = 0; %team < 8; %team ++) {

		// Search through all indices
		for (%i = 0; %i < $TeamItemMax[RemoteBomb]; %i ++) {

			// clear each slot
			$DetonationFrequency[%team @ %i] = "";
		}
	}
}

function DetonationFrequency::getNextIndex(%team) {
	// This function will return the next available index
	// for the Remote Bomb Detonation Frequency data arrays.  If none are
	// available, it will return -1.
	// By RCabrera for the Specialist mod, 2/17/00

	// Search through all indices
	for (%i = 0; %i < $TeamItemMax[RemoteBomb]; %i ++) {

		// if the this is an empty slot
		if ($DetonationFrequency[%team @ %i] == "") {
		
			// reserve this number
			// $DetonationFrequency[%team @ %i] = -1;

			// Then return that number
			return %i;
		}
	}
	// Otherwise, we could not find any empty slots, return -1
	return -1;
}

function DetonationFrequency::getIndex(%object) {
	// This function will return the index for the given object
	// in the Remote Bomb Detonation Frequency data arrays.  If unfound 
	// it will return -1.
	// By RCabrera for the Specialist mod, 2/17/00

	// Get this object's team
	%team = GameBase::getTeam(%object);

	// Search through all indices
	for (%i = 0; %i < $TeamItemMax[RemoteBomb]; %i ++) {

		// if the this is the object's slot
		if ($DetonationFrequency[%team @ %i] == %object) {
		
			// Then return this number
			return %i;
		}
	}
	// Otherwise, we could not find the requested object, return -1
	return -1;
}

function DetonationFrequency::Trigger(%team) {
	// This function will trigger all bombs set on this team's
	// detonation frequency, detonating them.
	// By RCabrera for the Specialist mod, 2/17/00

	%time = 0.0;

	// For every object in frequency
	for (%i = 0; %i < $TeamItemMax[RemoteBomb]; %i++) {
		
		schedule("DetonateBomb("@%team@", "@%i@");", %time);
		%time += 0.1;
	}
}

function DetonateBomb(%team, %index) {
	// This function actually detonates the bombs
	// By RCabrera for the Specialist mod, 6/25/00

	// If the slot is not empty
	if ($DetonationFrequency[%team @ %index] != "") {

		// detonate that bomb
		Mine::Detonate($DetonationFrequency[%team @ %index]);

	}
}