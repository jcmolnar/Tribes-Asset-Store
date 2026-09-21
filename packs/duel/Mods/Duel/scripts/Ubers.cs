

function UberSpawn(%clientId)
{
	if(!Player::isDead(Client::getOwnedObject(%clientId)) &&  %clientId.dm)
	{
		%team = 0;
		%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/start");
		if(Group::objectCount(%group) <= $ubercnt+1)
		{
			$ubercnt = -1;
		}
		gamebase::setposition(%clientid,gamebase::getposition(Group::getObject(%group, $ubercnt++)));
	}
	else {
		client::sendmessage(%clientId, $Red, "You must be alive and in DM to go to Uber area.");
	}
}

