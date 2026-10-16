echo ("Setting Item Limits to map specific limits.");
$TeamItemMax[VulcanPack] = $Pantheon::VulcanTurretLimit+2;
$TeamItemMax[SuicidePack] = $Pantheon::NumberOfNukes+1;
$TeamItemMax[LaserPack] = $Pantheon::LaserTurretLimit+3;
$TeamItemMax[BlastwallPack] = $Pantheon::BlastWallLimit+4;
$TeamItemMax[ForceFieldPack] = $Pantheon::ForceFieldLimit+4;
$TeamItemMax[LargeForceFieldPack] = $Pantheon::LargeForceFieldLimit+3;
$TeamItemMax[ForceFieldDoorPack] = $Pantheon::ForceFieldDoorLimit+2;

function GroupTrigger::onEnter(%this, %object)
{
	// this gets the clients id number
	%client = Player::getClient(%object);
	// Diamond Sword in out positions 
	if (GameBase::getTeam(%this) == GameBase::getTeam(%client))
	{
		if(%this.num == "DS1")
		{  
			%positionOut = "238.75 539.269 201.425";
			Client::SendMessage(%client,0,"Teleporting .~wshieldhit.wav");
			GameBase::setPosition(%client, %positionOut);
			GameBase::setRotation(%client, "0 -0 -1.60");
		}
		// Blood Eagle in out positions
		else if(%this.num == "BE1")
		{
			%positionOut = "230.351 -493.041 201.333";
			Client::SendMessage(%client,0,"Teleporting.~wshieldhit.wav");
			GameBase::setPosition(%client, %positionOut);
			GameBase::setRotation(%client, "0 0 -1.57");
		}
	}
	else Client::sendMessage(%client,0,"Wrong team.");
}

