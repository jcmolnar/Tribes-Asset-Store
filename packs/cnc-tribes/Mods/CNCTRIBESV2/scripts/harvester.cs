// Set the limit that harvesters can carry is $8000 worth of ore.
// You should also set the harvester's maxEnergy to this.
$HarvesterLimit = 8000;

function Harvester::onAdd(%this) {
	GameBase::setEnergy(%this, 0);

	Vehicle::onAdd(%this);

}

function Harvester::onCollision(%this, %object) {
	%name = GameBase::getDataName(%object);
	if(%name == ore1 || %name == ore2 || %name == ore3) { // Collect the ore
		%temp = $HarvesterLimit - GameBase::getEnergy(%this);
		if (%temp > %name.price) {
			GameBase::setEnergy(%this, GameBase::getEnergy(%this) + %name.price);
			Item::respawn(%object);
		} else if (%temp > 0) {
			GameBase::setEnergy(%this, $HarvesterLimit);
			Item::respawn(%object);
		}
	} else if(%name == VehiclePad) { // Convert it to cash
		$TeamEnergy[GameBase::getTeam(%this)] += GameBase::getEnergy(%this);
		GameBase::setEnergy(%this, 0);
	}

	Vehicle::onCollision(%this, %object);
}