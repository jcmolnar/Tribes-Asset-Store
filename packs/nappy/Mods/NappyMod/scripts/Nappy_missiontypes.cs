function Mission::CTF::create(%numTeams)
{
		// add a flag
		for(%i = 0; %i < %numTeams; %i++){
			// add a 'base' group for the flag
			%base = newObject(Base, SimGroup);
			addToSet("MissionGroup\\Teams\\team" @ %i, %base);
			// add the flag
			%flag = newObject(Flag @ %i, Item, Flag, 1, false);
			%flag.scoreValue = 1;
			GameBase::setMapName(%flag, "Flag " @ (%i + 1));
			addToSet(%base, %flag);
		}
		// add lines to the mission file...
		addExportText("$teamScoreLimit = " @ $CTF::winCaps @ ";");
		addExportText("exec(objectives);");
		addExportText("$Game::missionType = \"CTF\";");
}








function Mission::FandR::create(%numTeams)
{
		// add flagstands for the teams
		for(%i = 0; %i < %numTeams; %i++){
			// add a 'base' group for the stands
			%base = newObject(Base, SimGroup);
			addToSet("Missiongroup\\Teams\\team" @ %i, %base);
			// add all the stands
			for(%j = 0; %j < $FandR::numFlags; %j++){
				%stand = newObject("Stand" @ %j, StaticShape, FlagStand);
				GameBase::setMapName(%stand, "Stand " @ (%j + 1));
				addToSet(%base, %stand);
			}
		}
		// add the flags   
		for(%i = 0; %i < $FandR::numFlags; %i++){
			%flag = newObject(Flag @ %i, Item, Flag, 1, false);
			%flag.scoreValue = 2;
			GameBase::setMapName(%flag, "Flag " @ (%i + 1));
			addToSet(MissionGroup, %flag);
		}
		// add lines to the mission file...
		addExportText("$teamScoreLimit = " @ ($FandR::numFlags * 2) @ ";");
		addExportText("exec(objectives);");
		addExportText("$Game::missionType = \"F&R\";");
}





