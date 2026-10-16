//-----------------------------------
// AI::initDrones()
//-----------------------------------
function AI::initDrones(%team, %numAi)
{
	dbecho(1, "spawning team " @ %team @ " ai...");
	if(%numAi < 1000){
		for(%guard = 0; %guard < %numAi; %guard++){
			//check for internal data
			%tempSet = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI");
			%tempItem = Group::getObject(%tempSet, %guard);
			%aiName = Object::getName(%tempItem);
			%set = nameToID("MissionGroup\\Teams\\team" @ %team @ "\\AI\\" @ %aiName);
			%numPts = Group::objectCount(%set);
			if(%numPts > 0){
				createAI(%aiName, %set, $AI::defaultArmorType, %aiName);
				%aiId = AI::getId( %aiName );
				GameBase::setTeam(%aiId, %team);
				AI::setVar( %aiName,  iq,  60 );
				AI::setVar( %aiName,  attackMode, 1);
				AI::setVar( %aiName,  pathType, $AI::defaultPathType);
				schedule("AI::setWeapons(" @ %aiName @ ");", 1);
			}
			else
				dbecho(1, "no info to spawn ai...");
		}
	}
}







