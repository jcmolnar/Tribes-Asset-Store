$GuiModeCommand    = 2;
$LastControlObject = 0;

function Observer::triggerDown(%client)
{
}

function Observer::orbitObjectDeleted(%cl)
{
}

function Observer::leaveMissionArea(%cl)
{
}

function Observer::enterMissionArea(%cl)
{
}

function Observer::triggerUp(%client)
{
	if(%client.observerMode == "dead") {
		if(%client.dieTime + $Server::respawnTime < getSimTime()) {
			if(Game::playerSpawn(%client, true)) {
				%client.observerMode = "";
				Observer::checkObserved(%client);
			}
		}
	}
	else if(%client.observerMode == "observerOrbit")
		Observer::nextObservable(%client);
	else if(%client.observerMode == "observerFly") {
		%obsPos = "0";
		while(Aeon::onMap(%obsPos) != true) {
			%ObsX = -420+(ranDim(3070));
			%ObsY = -650+(ranDim(3070));
			%ObsZ = Property::terrainHeight(%ObsX@" "@%ObsY)+1+(10*getRandom());
			%obsPos = %ObsX@" "@%ObsY@" "@%ObsZ;
			%obsRot = Vector::getRotAim(%obsPos,"0 0 "@%ObsZ);
		}
		Observer::setFlyMode(%client,%obsPos,%obsRot,true,true);
	}
	else if(%client.observerMode == "justJoined") {
		if(Aeon::getUserPW(%client) == true)
			Game::playerSpawn(%client,false);
		else if($ClientInfo[%client,pass] != "")
			bottomPrint2(%client,"<jc><f2>That password is incorrect, please try again.",5,"C_BuySell.wav");
		else
			bottomPrint2(%client,"<jc><f1>Please input your desired profile password, <f2>NOTE:<f1> remember or write this password down, you will need to enter it each time you connect.",5,"C_BuySell.wav");
	}
	else
		echo("Observer Else!");
}

function Observer::jump(%client)
{
	if(%client.observerMode == "observerFly") {
		%client.observerMode = "observerOrbit";
		%client.observerTarget = %client;
		Observer::nextObservable(%client);
	}
	else if(%client.observerMode == "observerOrbit") {
		%client.observerTarget = "";
		%client.observerMode = "observerFly";
		%obsPos = "0";
		while(Aeon::onMap(%obsPos) != true) {
			%ObsX = -420+(ranDim(3070));
			%ObsY = -650+(ranDim(3070));
			%ObsZ = Property::terrainHeight(%ObsX@" "@%ObsY)+1+(10*getRandom());
			%obsPos = %ObsX@" "@%ObsY@" "@%ObsZ;
			%obsRot = Vector::getRotAim(%obsPos,"0 0 "@%ObsZ);
		}
		Observer::setFlyMode(%client,%obsPos,%obsRot,true,true);
	}
	if((Client::getOwnedObject(%client)).Sub != "")
		Player::trigger(Client::getOwnedObject(%client),$BackpackSlot,false);
}

function Observer::isObserver(%clientId)
{
	return %clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly";
}

function Observer::enterObserverMode(%clientId)
{
	if(%clientId.observerMode == "observerOrbit" || %clientId.observerMode == "observerFly")
		return false;
	Client::clearItemShopping(%clientId);
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%clientId);
		Player::kill(%clientId);
	}
	Client::setOwnedObject(%clientId, -1);
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	%clientId.observerMode = "observerOrbit";
	GameBase::setTeam(%clientId, -1);
	Observer::jump(%clientId);
	remotePlayMode(%clientId);
	return true;
}

function Observer::checkObserved(%client)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		if(%cl.observerTarget == %client) {
			if(%cl.observerMode == "observerOrbit")
				Observer::setOrbitObject(%cl, %client, 5, 5, 5);
			else if(%cl.observerMode == "commander")
				Observer::setOrbitObject(%cl, %client, -3, -3, -3);
		}
	}
}

function Observer::setTargetClient(%client, %target)
{
	if(%client.observerMode != "observerOrbit")
		return false;
	%owned = Client::getOwnedObject(%target);
	if(%owned == -1)
		return false;
	Observer::setOrbitObject(%client, %target, 5, 5, 5);
	bottomprint(%client, "<jc>Observing " @ Client::getName(%target), 5);
	%client.observerTarget = %target;
	return true;
}

function Observer::nextObservable(%client)
{
	%lastObserved = %client.observerTarget;
	%nextObserved = Client::getNext(%lastObserved);
	%ct = 128;
	while(%ct--) {
		if(%nextObserved == -1) {
			%nextObserved = Client::getFirst();
			continue;
		}
		%owned = Client::getOwnedObject(%nextObserved);
		if(%nextObserved == %lastObserved && %owned == -1) {
			Observer::jump(%client);
			return;
		}
		if(%owned == -1) {
			%nextObserved = Client::getNext(%nextObserved);
			continue;
		}
		Observer::setTargetClient(%client, %nextObserved);
		return;
	}
	Observer::jump(%client);
}

function Observer::prevObservable(%client)
{
}

function remoteSCOM(%clientId, %observeId)
{
	if(%observeId != -1) {
		if(Client::getTeam(%clientId) == Client::getTeam(%observeId) && (%clientId.observerMode == "" || %clientId.observerMode == "commander") && Client::getGuiMode(%clientId) == $GuiModeCommand) {
			Client::limitCommandBandwidth(%clientId, true);
			if(%clientId.observerMode != "commander") {
				%clientId.observerMode = "commander";
				%clientId.lastControlObject = Client::getControlObject(%clientId);
			}
			Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
			Observer::setOrbitObject(%clientId, %observeId, -3, -3, -3);
			%clientId.observerTarget = %observeId;
			Observer::setDamageObject(%clientId, %clientId);
		}
	}
	else {
		Client::limitCommandBandwidth(%clientId, false);
		if(%clientId.observerMode == "commander") {
			Client::setControlObject(%clientId, %clientId.lastControlObject);
			%clientId.lastControlObject = "";
			%clientId.observerMode = "";
			%clientId.observerTarget = "";
		}
	}
}