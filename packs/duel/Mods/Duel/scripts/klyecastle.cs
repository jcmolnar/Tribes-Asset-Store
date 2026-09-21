$KlyeCastle[Northern] = "0 1 0";
$KlyeCastle[Eastern] = "1 0 0";
$KlyeCastle[Southern] = "0 -1 0";
$KlyeCastle[Western] = "-1 0 0";
$KlyeCastle[Up] = "0 0 1";
$KlyeCastle[Down] = "0 0 -1";

$KlyeCastleVelocity = "0 0 0";

$KlyeCastleArmed = false;

$KCPCount = 0;



function remoteKlyeCastle(%clientId)
{

}
function DivideVelocity()
{
	return gw($KlyeCastleVelocity, 0)/150@" "@gw($KlyeCastleVelocity, 1)/150@" "@gw($KlyeCastleVelocity, 2)/150 ;
}


function KlyeCastleWeapons()
{
	if(!$KlyeCastleArmed)
	{
		$KlyeCastleArmed = true;
		//both("Powering weapons...");

		if($klyeEngineRunning)
		{
			$klyeEngineRunning = false;
		}

		%numItems = Group::objectCount($BuildGroup);



		for(%i = 0 ; %i<%numItems ; %i++)
		{
			%obj = Group::getObject($BuildGroup, %i);
			%type = getObjectType(%obj);
			//both(%type);
			if(%type == "Turret")
			{
				//both(%type);
				gamebase::setposition(%obj, MyVector::Add(%obj.spawnOffset, gamebase::getposition($KlyeCastleMain)));
			}
				//%pos = gamebase::getposition(%obj);
				//%pos = MyRound(getword(%pos, 0))@" "@MyRound(getword(%pos, 1))@" "@MyRound(getword(%pos, 2));
				//%rot = gamebase::getrotation(%obj);
			//	$project[%y+=1] = %type@" "@%name@" "@%pos@" "@%rot ;
				//addtodb(%obj);
			//}
			gamebase::setteam(%obj, 6);

		}

	}
	else {
		$KlyeCastleArmed = false;

		//both("Powering down weapons...");

		%numItems = Group::objectCount($BuildGroup);

		for(%i = 0 ; %i<%numItems ; %i++)
		{
			%obj = Group::getObject($BuildGroup, %i);
			%type = getObjectType(%obj);
			gamebase::setteam(%obj, 1);
			if(%type == "Turret")
			{
				//both(%type);
				gamebase::setposition(%obj, "0 0 -1000");
			}
		}
	}
}


function moveCastle()
{
	//both("moving...");

	//if(gamebase::setposition($klyeCastle[0] == vector::add($klyeCastleObjPos[%a], $klyeCastleCurrentPos)))
	//{
	//	echo("MC cancel?");
		%flag=true;
	//}
	//both("start of movecastle...");
	if($klyeEngineRunning)
	{
		%numItems = Group::objectCount($BuildGroup);
		for(%i = 0 ; %i<%numItems ; %i++)
		{
			%obj = Group::getObject($BuildGroup,%i);
			%type = getObjectType(%obj);
			%name = GameBase::getDataName(%obj);


			if(%type == "Player" || %type == "StaticShape" || %type == "InteriorShape")
			{
				if(%type == "Player")
				{
					if(Vector::getDistance(GameBase::getPosition(%obj), GameBase::getPosition($KlyeCastleMain)) > 80)
					{
						addToSet("MissionCleanup", %obj);
					}
				}
				 //echo(%obj@" "@%name @" "@%type);
				//both("moving it... "@vector::add(gamebase::getposition(%obj), DivideVelocity()));

				%DV = DivideVelocity();
				%pos = Getword(gamebase::getposition(%obj), 0)+Getword(%DV, 0)@" "@Getword(gamebase::getposition(%obj), 1)+Getword(%DV, 1)@" "@Getword(gamebase::getposition(%obj), 2)+Getword(%DV, 2) ;
				//both("first "@%pos);
				%pos = MyVector::Add(gamebase::getposition(%obj),%DV);
				//both("second "@%pos);
				gamebase::setposition(%obj, %pos);
			}
		}
		schedule("moveCastle();",0.01);
	}
}



function KCarrowSwitch::onCollision(%this, %object)
{
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		%pl = Client::getOwnedObject(%cl);
		if(Vector::getDistance(GameBase::getPosition(%this), GameBase::getPosition(%pl)) < 50)
		{
			$KCPassenger[$KCPCount++] = %cl;
			addToSet("BuildGroup", %pl);
			//both("Added "@client::getname(%cl)@" to the passenger list");
		}
		else
		{
			addToSet("MissionCleanup", %pl);
		}
	}

	%name = GameBase::getMapName(%this);
	%firstname = gw(%name,0);
	//both("FN "@%firstname@" reg: "@%name);
	if(%firstname == "Northern" || %firstname == "Eastern" || %firstname == "Southern" || %firstname == "Western" || %firstname == "Up" || %firstname == "Down")
	{
		//$KlyeCastleVelocity = vector::add($KlyeCastle[%firstname],$KlyeCastleVelocity);
		$KlyeCastleVelocity = Getword($KlyeCastle[%firstname], 0)+Getword($KlyeCastleVelocity, 0)@" "@Getword($KlyeCastle[%firstname], 1)+Getword($KlyeCastleVelocity, 1)@" "@Getword($KlyeCastle[%firstname], 2)+Getword($KlyeCastleVelocity, 2) ;
		GameBase::setMapName(%this, KCSwitch::String(%firstname));
	}
	if(%firstname == "Stop" || %firstname == "Start")
	{
		//both(%firstname@" called..");
		if($klyeEngineRunning)
		{
			$klyeEngineRunning = false;
			//GameBase::setMapName(%this, "Start Engine");
		}
		else {
			$klyeEngineRunning = true;
			if($KlyeCastleArmed)
			{
				//both("moving... powerdown");
				KlyeCastleWeapons();
			}
			moveCastle();
			//GameBase::setMapName(%this, "Stop Engine");
		}
	}
	if(%firstname == "Reset")
	{
		$KlyeCastleVelocity = "0 0 0";
	}

	//
	if(%firstname == "Weapons")
	{
		//$KlyeCastleVelocity = "0 0 0";
		//both("weapons...");
		KlyeCastleWeapons();
	}

//both("GetName: "@Object::getName(%this)@" - DataName: "@GameBase::getDataName(%this)@" file?:"@%this.filename@" Map: "@GameBase::getMapName(%this));
	%client = Player::getClient(%object);
	if(getObjectType(%object) == "Player" && gamebase::getteam(%this) != gamebase::getteam(%client))
	{
		//messageall(1, client::getname(%client)@" has taken the objective for the "@$TeamDuel::Name[%client.Team]@" team!~wCapturedTower.wav");
		gamebase::setteam(%this, gamebase::getteam(%client));
	}
	//moveCastle();
	return;
}
function KCSwitch::String(%name)
{
	%string = %name@" Power: "@$KlyeCastleVelocity ;
	return %string;
}
function KCSwitch::OnAdd(%this)
{
	schedule("KCSwitchCheck("@%this@");",0.01);
}
function KCSwitchCheck(%this)
{

}

//functiom
//Object::getName(%my_object)@" - "@GameBase::getDataName(%my_object)@" "@%my_object.filename

//Gamebase::setMapName(%turret,%type @ " of "@Client::getName(%client) @ "'s");

  // $numCaps++;