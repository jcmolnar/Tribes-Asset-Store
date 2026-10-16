

// ================ Poison Gas cloud functions ===============

function PoisonGasCloud::initializeData () {
	// This function will initialize the gas cloud data arrays.
	// It should only be called at the beginning of each mission.
	// By RCabrera for the Specialist mod, 1/28/00

	// Search through all available indices
	for (%i = 0; %i < $Specialist::MaximumNumberOfGasClouds; %i ++) {

		// Initialize it's values
		$PoisonGasCloudTTG[%i] = -1;
		$PoisonGasCloudObject[%i] = -1;
		$PoisonGasCloudOwner[%i] = -1;
		$PoisonGasCloudPosition[%i] = "0 0 0";
	}

	// Initialize total to zero
	$PoisonGasCloudTotal = 0;

}

function PoisonGasCloud::getNextIndex() {
	// This function will return the next available index
	// for the Poison Gas Cloud data arrays.  If none are
	// available, it will return -1.
	// By RCabrera for the Specialist mod, 1/28/00

	// Search through all available indices
	for (%i = 0; %i < $Specialist::MaximumNumberOfGasClouds; %i ++) {



		// if the TTG has been set to -1 (a sentinel value)
		if ($PoisonGasCloudTTG[%i] == -1) {
		
			// reserve this number
			$PoisonGasCloudTTG[%i] = -99;

			// Then return that number
			return %i;
		}
	}
	// Otherwise, we could not find any empty slots, return -1
	return -1;
}

function PoisonGasCloud::updateAll(%execute) {
	// This function will update the TTG on all current gas
	// clouds, and delete any clouds that have expired.  If
	// there are any remaining gas clouds, it will reschedule
	// itself to be executed in 1 second.
	// By RCabrera for the Specialist mod, 1/28/00

	// Some synchronicity control
	$PoisonGasCloudUpdateScheduled = false;
	// %repeat = false;

	// If this is the first call, %execute will be false. Only
	// when this function calls itself is %execute set to true.
	if (%execute) {
		
		// Iterate through each poison gas cloud slot
		for (%i = 0; %i < $Specialist::MaximumNumberOfGasClouds; %i ++) {

			// If this gas cloud was just added and waiting for data
			if ($PoisonGasCloudTTG[%i] == -99) {

				// do nothing (for now)
			}

			// Else If this gas cloud is active
			else if ($PoisonGasCloudTTG[%i] > 0) {
			
				// decrement it's Time To Go
				$PoisonGasCloudTTG[%i] --;

				// and this function will be scheduled again
				// %repeat = true;

			}

			// Else If this gas cloud's time has just expired
			else if ($PoisonGasCloudTTG[%i] != -1) {

				// Get the object ID of this gas cloud
				%obj = $PoisonGasCloudObject[%i];


				// Detonate the mine at the center of this gas cloud
				Mine::detonate(%obj);

				// Reinitialize the Poison Gas Cloud array slots
				$PoisonGasCloudIndex[%obj] = -1;
				$PoisonGasCloudTTG[%i] = -1;
				$PoisonGasCloudObject[%i] = -1;
				$PoisonGasCloudTotal --;
			}
		}
	}
	
	// If %execute was false
	else {

		// Then we'll schedule this function again
		// %repeat = true;
	}

	// Now we check to see if we want to reschedule this function
//	if (%repeat) {
	if ($PoisonGasCloudTotal > 0 && $PoisonGasCloudUpdateScheduled == false) {

		// Block any further calls to this function
		$PoisonGasCloudUpdateScheduled = true;

		// and we reschedule for 1 second
		schedule("PoisonGasCloud::updateAll(true);", 1.0);
	}
}