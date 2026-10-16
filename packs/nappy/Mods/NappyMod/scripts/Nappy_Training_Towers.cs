




function Game::playerSpawn(%clientId, %respawn)
{
	%player = Client::getOwnedObject(%clientId);
	%client = Player::getClient(%player);
	$Client[%client, Nappy:stopLag] = 0;
	if($currentWay == 1)
	%spawnMarker = $startPoint;
	else
	%spawnMarker = $spawnPoint[$currentWay - 1]; 
   
	%clientId.guiLock = "";
	if(%spawnMarker == -1){
		%spawnPos = "0 0 300";
		%spawnRot = "0 0 0";
	}
	else{
		%spawnPos = GameBase::getPosition(%spawnMarker);
		%spawnRot = GameBase::getRotation(%spawnMarker);
	}

	if(!String::ICompare(Client::getGender(%clientId), "Male"))
		%armor = "larmor";
	else
		%armor = "lfemale";

	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
    
	GameBase::setTeam(%pl, Client::getTeam(%clientId));                                          
	Client::setOwnedObject(%clientId, %pl);                                                      
	Game::playerSpawned(%pl, %clientId, %armor, %respawn);                                       
	Client::setControlObject(%clientId, %pl);                                                 
}













