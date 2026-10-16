echo("Loading Screaming Fist Version");
$TrainfolderNameForSystem = "System";
$TrainfolderNameForPath = "Path";

$TrainStationWait = 10;

exec("TrainData");

function Train::onNewPath(%this)
{
	NextWaypoint(%this);
}
function Train::onWaypoint(%this)
{
	echo("Train::onWaypoint: " @ %this);
	echo("-------------------------------");
	if($Train::NextSpeed[%this] != "")
	{
		RefreshSpeed(%this, $Train::NextSpeed[%this]);
		$Train::NextSpeed[%this] = "";
	}

	if($Train::SpeedBuffer[%this] != "")
	{
		if($Train::SpeedBuffer[%this] > 0)
		{
			$Train::SpeedBuffer[%this]--;
			if($Train::SpeedBuffer[%this] == 0)
		            Client::sendMessage($Train::Driver[%this], $MSGTypeSystem, "Train has reached desired speed.");

			RefreshSpeed(%this, $Train::Speed[%this]+1);
		}
		else if($Train::SpeedBuffer[%this] < 0)
		{
			$Train::SpeedBuffer[%this]++;
			if($Train::SpeedBuffer[%this] == 0)
		            Client::sendMessage($Train::Driver[%this], $MSGTypeSystem, "Train has reached desired speed.");

			RefreshSpeed(%this, $Train::Speed[%this]-1);
		}
	}

	NextWaypoint(%this);
}
function ResetTrain(%this)
{
	Moveable::setWaypoint(%this, 0);
}
function NextWaypoint(%this)
{
	//This function makes %this go to the next waypoint on its stack.
	//Once the current waypoint is the last waypoint, switch the train to waypoint 0 and wait x amount
	//of seconds before moving on to next waypoint.

	%which = round(Moveable::getPosition(%this));

	if(%which < (Moveable::getWaypointCount(%this)-1))
	{
		Moveable::moveToWaypoint(%this, %which+1);
	}
	else if(%which == (Moveable::getWaypointCount(%this)-1))
	{
		ResetTrain(%this);
		schedule("NextWaypoint(" @ %this @ ");", $TrainStationWait, %this);
	}
}

function RefreshSpeed(%this, %speed)
{
	//this function must ONLY be invoked by the onWaypoint event.  To change the speed manually, use SetSpeed

	if(%speed != $Train::Speed[%this])
	{
		//remember stuff about the current train
		%which = round(Moveable::getPosition(%this));
		%folderName = $Train::FolderName[%this];
		%driver = $Train::Driver[%this];
		%speedbuffer = $Train::SpeedBuffer[%this];

		//delete the current train
		$Train::Speed[%this] = "";
		$Train::FolderName[%this] = "";
		$Train::Driver[%this] = "";
		$Train::SpeedBuffer[%this] = "";

		HackStorePlayerPos();

		//helps to unstick player from platform for a fraction of a second.
		schedule("GameBase::setPosition(" @ %this @ ", \"0 0 0\"); deleteObject(" @ %this @ ");", 0.01); //this will leave a trail for 0.01 seconds, but who cares.

		//create the new train
		%newtrain = $Train::SpeedForName[%speed];
		%new = newObject("TrainObject", "Moveable", %newtrain, True);
		Moveable::setWaypoint(%new, %which);
		GameBase::setPosition(%new, "0 0 0");
		addToSet(%folderName, %new);

		//restore stuff from previous train to new train
		echo("Trying to restore a platform at waypoint " @ %which);
		$Train::FolderName[%new] = %folderName;
		$Train::Speed[%new] = %speed;
		$Train::Driver[%new] = %driver;
		$Train::SpeedBuffer[%new] = %speedbuffer;

		//switch MarkerPos's
		for(%i = 0; $Train::MarkerPos[%this, %i] != ""; %i++)
		{
			$Train::MarkerPos[%new, %i] = $Train::MarkerPos[%this, %i];
			$Train::MarkerPos[%this, %i] = "";
		}

		schedule("HackRestorePlayerPos(" @ %new @ ");", 0.02);
	}
}
function HackStorePlayerPos()
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		$ClientOldPos[%cl] = GameBase::getPosition(%cl);
	}
}
function HackRestorePlayerPos(%this)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%distance = Vector::getDistance(GameBase::getPosition(%cl), $ClientOldPos[%cl]);
		if(%distance > 5)
		{
			echo("TRAIN DEBUG: teleport error for client " @ %cl @ ", restoring to old position " @ $ClientOldPos[%cl]);
			GameBase::setPosition(%cl, $ClientOldPos[%cl]);

                  %trainvel = Item::getVelocity(%this);
			Item::setVelocity(%cl, %trainvel);
                  echo("TRAIN DEBUG: adding Item::setVelocity(" @ %trainvel @ ") to help with train mounting");
		}
	}
}

function SetSpeed(%this, %speed)
{
	//if someone tries to increase or decrease the speed manually, the acceleration will stop
	$Train::SpeedBuffer[%this] = "";

	if($Train::Speed[%this] == 0)
	{
		//if the platform is stopped, then we have to make the call to the platform manually, because how else
		//would a platform of speed 0 encounter the next waypoint?  Plus, if it's at speed 0, it is obviously still
		//at one of the waypoints, because it can't change speed unless it's AT a waypoint.
		RefreshSpeed(%this, %speed);
	}
	else
	{
		$Train::NextSpeed[%this] = %speed;
	}
}

function round(%n)
{
	%f = floor(%n);
	%a = %n - %f;
	if(%a < 0.5)
		%b = 0;
	else if(%a >= 0.5)
		%b = 1;

	return %f + %b;
}

function Train::onCollision(%this, %object)
{
	%clientId = Player::getClient(%object);

	for(%i = 1; $personalTrainArray[%clientId, %i] != ""; %i++){}
	$personalTrainArray[%clientId, %i] = "1 " @ %this;
	schedule("$personalTrainArray[" @ %clientId @ ", " @ %i @ "] = \"\";", 5);
}

function IsOnTrain(%clientId)
{
	%wtrain = "";

	for(%i = 1; %i <= 20; %i++)
	{
		%z = floor(GetWord($personalTrainArray[%clientId, %i], 0));
		if(%z == -1) %z = 0;

		%cnt += %z;
		if(GetWord($personalTrainArray[%clientId, %i], 1) != -1 && %wtrain == "")
			%wtrain = GetWord($personalTrainArray[%clientId, %i], 1);
	}

	if(%cnt > 3)
		return %wtrain;
	else
		return -1;
}

function InitTrain()
{
	$Train::InitSpeed = 10;

	%group = nameToId("MissionGroup\\Trains");

	if(%group != -1)
	{
		%count = Group::objectCount(%group);
		for(%i = 0; %i <= %count-1; %i++)
		{
			%object = Group::getObject(%group, %i);
			%system = Object::getName(%object);
			%wtrain = String::getSubStr(%system, String::len($TrainfolderNameForSystem), String::len(%system)-String::len($TrainfolderNameForSystem));

			//find %train id
			%g = nameToId("MissionGroup\\Trains\\" @ %system);
			%c = Group::objectCount(%g);
			for(%k = 0; %k <= %c-1; %k++)
			{
				%o = Group::getObject(%g, %k);
				if(getObjectType(%o) == "Moveable")
					%train = %o;
			}

			$Train::Speed[%train] = $Train::InitSpeed;
			$Train::NextSpeed[%train] = "";
			$Train::FolderName[%train] = "MissionGroup\\Trains\\" @ %system;
			$Train::Driver[%train] = "";
			$Train::SpeedBuffer[%train] = "";

			//go thru all the markers / droppoints and perhaps do something?
			%groupForPath = nameToId("MissionGroup\\Trains\\" @ %system @ "\\" @ $TrainfolderNameForPath);
			%countForPath = Group::objectCount(%groupForPath);
			for(%j = 0; %j <= %countForPath-1; %j++)
			{
				%o1 = Group::getObject(%groupForPath, %j);
				$Train::MarkerPos[%train, %j] = GameBase::getPosition(%o1);
			}
		}
	}
}