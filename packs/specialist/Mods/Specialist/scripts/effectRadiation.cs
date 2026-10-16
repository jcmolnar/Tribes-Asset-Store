// Specialist Radiation effect

function RadiatePlayer(%player, %damage, %killer) {

	// Scale the damage according to armor protection (documentation by RCabrera)
	%armor = Player::getArmor(%player);
	%dval = $DamageScale[%armor, $RadiationDamageType] * %damage;

	%pos = GameBase::getPosition(%player);
	%vec = Vector::getDistance(%pos, %pos);
	%mom = 0.0;
	Player::onDamage(%player, $RadiationDamageType, %dval, %pos, %vec, %mom, "torso", "front_right", %killer);



}

function RadiationUpdate(%object, %damage, %size) { 

	// If this Radiation still has time to go
	if ($RadiationTTG[%object] > 0) {

		// Let's collect all the players in the cloud

		%set = newObject("radiationSet", SimSet);
		%mask = $SimPlayerObjectType;
		%pos = $RadiationPos[%object];
		%num = containerBoxFillSet(%set, %mask, %pos, %size, %size, %size, 0);


		// And for each player in the radiation
		for (%index = 0; %index < %num; %index++) {
			%player = Group::getObject(%set, %index);

			// If not wearing a fallout pack
			if (Player::getMountedItem(%player,$BackpackSlot) != FalloutPack) {
				// Damage player
				RadiatePlayer(%player, %damage, $RadiationCanisterOwner[%object]);
			}
		}
		
		deleteObject(%set);

		schedule("RadiationUpdate(" @ %object @ ", " @%damage@ ", " @%size@ ");", 1);
		$RadiationTTG[%object] --;
	}
}

function PermanentRadiationUpdate(%object, %damage, %size) { 

	// Let's collect all the players in the cloud

	%set = newObject("radiationSet", SimSet);
	%mask = $SimPlayerObjectType;
	%pos = getBoxCenter(%object);

	%num = containerBoxFillSet(%set, %mask, %pos, %size, %size, %size, 0);


	// And for each player in the radiation
	for (%index = 0; %index < %num; %index++) {
		%player = Group::getObject(%set, %index);

		// If not wearing a fallout pack
		if (Player::getMountedItem(%player,$BackpackSlot) != FalloutPack) {
			// Damage player
			RadiatePlayer(%player, %damage, $NuclearWasteOwner[%object]);
		}
	}
		
	deleteObject(%set);

	schedule("PermanentRadiationUpdate(" @ %object @ ", " @%damage@ ", " @%size@ ");", 2, %object);

}
