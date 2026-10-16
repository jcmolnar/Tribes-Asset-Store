//---------------------------------------------------------------------------------
// New deploy functions from shifter added on 9-11-02 by -Defender
//---------------------------------------------------------------------------------
//==================================================================================== Deployables Functions

function MDConnectMessageAll(%player)  // Defender
{
%cl = Player::getClient(%player);
if(%cl != -1)
%clname = Client::getName(%cl);
//MessageAllExcept(%cl, 0, %clname @ "~wpjplayerjoined.wav");
MessageAllExcept(%cl, 0, %clname @ "~wpjplayerjoined.wav");
}

function MDmissionComplete() // Defender
{
messageAll(0,"~wANN.gameover.wav");
messageAll(0,"~wwin_stereo.wav");
}
function MDClientleaveGame() // Defender
{
messageAll(0,"~wpjplayerdropped.wav");
}

function checkDeployArea(%client,%pos)
{
  	%set=newObject("set",SimSet);
	%num=containerBoxFillSet(%set,$VehicleObjectType | $StaticObjectType | $ItemObjectType | $SimPlayerObjectType,%pos,1,1,1,1);
	%n = Group::objectCount(%set);

	if(!%num)
	{
		deleteObject(%set);
		return 1;
	}

	%datab = GameBase::getDataName(Group::getObject(%set,0));
	%obj = (getObjectType(Group::getObject(%set,0)));

	echo ("obj " @ %obj);

	if ((%obj == "SimTerrain" || %obj == "InteriorShape" || %datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform"  || %datab == "BlastFloor" || %datab == "BlastWall" || %datab == "LargeEmplacementPlatform"))
	{
		deleteObject(%set);
		return 1;
	}
	else if(%num == 1 && getObjectType(Group::getObject(%set,0)) == "Player")
	{
		%obj = Group::getObject(%set,0);
		if(Player::getClient(%obj) == %client)
			Client::sendMessage(%client,1,"Unable to deploy - You're in the way");
		else
			Client::sendMessage(%client,1,"Unable to deploy - Player in the way");
	}
	else
		Client::sendMessage(%client,1,"Unable to deploy - Item in the way");

	deleteObject(%set);
	return 0;
}


//======================================= Check For Objects In a Deployables way.
function CheckForObjects(%pos, %l, %w, %h)
{
	%Set = newObject("cfoset",SimSet);
	%Mask = $SimPlayerObjectType|$StaticObjectType|$VehicleObjectType|$MineObjectType|$SimInteriorObjectType; //cloaks people, thiings, vehicles, mines, and the base itself

	if (%l && %w && %h)
	{
		containerBoxFillSet(%Set, %Mask, %Pos, %l, %w, %h,0);
	}
	else
	{
		containerBoxFillSet(%Set, %Mask, %Pos, 25, 25, 25,0);
	}

	%num = Group::objectCount(%Set);

	for(%i; %i < %num; %i++)
	{
		%obj = Group::getObject(%Set, %i);

		if (%obj != "-1")
		{
			if (getObjectType(%obj) == "Player")
			{
			}
			else
			{
				deleteObject(%set);
				return False;
			}
		}
	}
	deleteObject(%set);
	return True;
}

//===========================================
function CountObjects(%set,%name,%num)
{
	%count = 0;

	if (%name)
	{
		for(%i=0;%i<%num;%i++)
		{
			%obj=Group::getObject(%set,%i);
			if(GameBase::getDataName(Group::getObject(%set,%i)) == %name)
				%count++;
		}
	}
	else if (!%name)
	{
		for(%i=0;%i<%num;%i++)
		{
			%obj=Group::getObject(%set,%i);
			%object = getObjectType(%obj);
			%shape = GameBase::getDataName(%obj).shapeFile;
			if(%object == "Turret" || %shape == "flag")
				%count++;
		}
	}
	return %count;

}

//---------------------------------------------------------------------------------
// Remote deploy for items
//---------------------------------------------------------------------------------
// Deployable Box
//---------------------------------------------------------------------------------
$MaxNumTurretsInBox = 3;     	//Number of remote turrets allowed in the area
$TurretBoxMaxLength = 55;    	//Define Max Length of the area
$TurretBoxMaxWidth =  55;    	//Define Max Width of the area
$TurretBoxMaxHeight = 55;    	//Define Max Height of the area

$TurretBoxMinLength = 25;	//Define Min Length from another turret
$TurretBoxMinWidth =  25;	//Define Min Width from another turret
$TurretBoxMinHeight = 15;    	//Define Min Height from another turret

//=============================================================================================== Deployable Functions
// %player  = Player Id doing the deploy
// %item    = Item being deployed
// %type    = Type of item - Turret, StaticShape, Beacon - etc
// %name    = Name of item - Ion Turret
// %angle   = Check angel (to mount on walls, etc.) (True/False/Player) Checks angel - Does Not Check - Uses Players Rotation Reguardless
// %freq    = Check Frequency (True/False) = Too Many Other Turrets
// %prox    = Check Proximity (True/False) = Too Many Of SAME Type Of Item
// %noinside= Checks to see if deployment is IN a building.
// %area    = Check Area (for objects in the way) (True/False)
// %surface = Check Surface Type  (True/False)
// %range   = Max deploy distance from player (number best between 3 and 5) meters from player.
// %limit   = Check limit (True/False)
// %flag    = Give Flag Defence Bonus 0 = None and higher for score ammount.
// %kill    = Count for kills (for turrets)
// %deploy  = The item to be deployed (actualy item data name)
// %count   = What item to count

function deployable(%player,%item,%type,%name,%angle,%freq,%prox,%noinside,%area,%surface,%range,%limit,%flag, %kill, %deploy, %count)
{
	%client = Player::getClient(%player);
	%playerteam = Client::getTeam(%client);
	%playerpos = GameBase::getPosition(%player);
	%homepos = ($teamFlag[%playerteam]).originalPosition;
	%flagdist = Vector::getDistance(%playerpos,%homepos);

	if($TeamItemCount[GameBase::getTeam(%player) @ %count] < $TeamItemMax[%count])
	{
		if (GameBase::getLOSInfo(%player,%range))
		{
			%o = ($los::object);
			%obj = getObjectType(%o);
			%datab = GameBase::getDataName(%o);
			%pos = $los::position;

			if (%surface)
			{
				if (%obj == "SimTerrain" || %obj == "InteriorShape")
				{

				}
				else if (%datab == "DeployablePlatform" || %datab == "LargeAirBasePlatform" || %datab == "BlastFloor" || %datab == "BlastWall" || %datab == "LargeEmplacementPlatform")
				{

				}
				else
				{
					Client::sendMessage(%client,1,"Can only deploy on terrain or buildings...");
					return;
				}
			}

			if (%prox)
			{
				%set = newObject("proxset",SimSet);
				%num = containerBoxFillSet(%set,$StaticObjectType,%pos,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
				%num = CountObjects(%set,%deploy,%num);
				deleteObject(%set);
				if($MaxNumTurretsInBox > %num){}
				else
				{
					Client::sendMessage(%client,1,"Frequency Overload - Too close to other " @ %deploy @ "s.");
					return;
				}

				%set = newObject("minimumset",SimSet);
				%Mask = $StaticObjectType|$VehicleObjectType|$ItemObjectType;
				%num = containerBoxFillSet(%Set, %Mask, %pos, 2.5,2.5,2.5, 0);
				%num = CountObjects(%set,"",%num);
				deleteObject(%set);
				if(!%num){}else
				{
					Client::sendMessage(%client,1,"Frequency Overload - Too close to other remote turrets");
					return;
				}
			}

			if (%noinside)
			{
				%padd = "0 0 10";%poss = Vector::add(%pos, %padd);
				for (%b=1; %b < 15; %b++)
				{
					%padd = "0 0 " @ %b;
					%poss = Vector::add(%pos, %padd);
					if(!GameBase::testPosition(%player, %poss))
						%nope = 1;
				}
				if (%nope == 1)
				{
					Client::sendMessage(%client,0,"You can not deploy " @ %name @ ", space to enclosed.");
					return;
				}


			}
			if (%freq)
			{
				%set = newObject("freqset",SimSet);%Mask = $StaticObjectType|$VehicleObjectType|$ItemObjectType;
				%num = containerBoxFillSet(%Set, %Mask, $los::position, $TurretBoxMaxLength/2,$TurretBoxMaxWidth/2,$TurretBoxMaxHeight/2, 0);
				%num = CountObjects(%set,"",%num);
				deleteObject(%set);
				if(%num > 0)
				{
					Client::sendMessage(%client,1,"Other objects in the way.");
					return;
				}
			}

			if (%angle == "True")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					%prot = GameBase::getRotation(%player);
					%zRot = getWord(%prot,2);

					if (Vector::dot($los::normal,"0 0 1") > 0.6)
					{
						%rot = "0 0 " @ %zRot;
					}
					else
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6)
						{
							%rot = "3.14159 0 " @ %zRot;
						}
						else
						{
							%rot = Vector::getRotation($los::normal);
						}
					}
				}
				else
				{
					Client::sendMessage(%client,1,"Can only deploy on flat surfaces");
					return 0;
				}
			}
			else if (%angle == "Player")
			{
				%rot = GameBase::getRotation(%player);
			}
			else if(%angle == "Flat")
			{
				%rot = "-1.54564 0.02591 -3.09105";

			}
			else if (!%angle || %angle == "False")
			{
				%prot = GameBase::getRotation(%player);
				%zRot = getWord(%prot,2);
				if (Vector::dot($los::normal,"0 0 1") > 0.6)
				{
					%rot = "0 0 " @ %zRot;
				}
				else
				{
					if (Vector::dot($los::normal,"0 0 -1") > 0.6)
					{
						%rot = "3.14159 0 " @ %zRot;
					}
					else
					{
						%rot = Vector::getRotation($los::normal);
					}
				}
			}

			if (%area)
			{
				if(!checkDeployArea(%client,$los::position))
				{
					return 0;
				}
			}

			%turret = newObject(%name,%type, %deploy,true);
			addToSet("MissionCleanup", %turret);
			GameBase::setTeam(%turret,GameBase::getTeam(%player));
			GameBase::setPosition(%turret,$los::position);
			GameBase::setRotation(%turret,%rot);
			Client::sendMessage(%client,0,"" @ %name @ " deployed");
			GameBase::startFadeIn(%turret);
			playSound(SoundPickupBackpack,$los::position);
			$TeamItemCount[GameBase::getTeam(%player) @ "" @ %count @ ""]++;

			//echo("MSG: ",%client," deployed a " @ %name);

			if (%type == "Turret")
				Gamebase::setMapName(%turret, %name @ " # " @ $totalNumTurrets++ @ " " @ Client::getName(%client));
			else
				Gamebase::setMapName(%turret, %name);

			if (%flagdist < %flag && %flag != 0)
			{
				%client.score = %client.score + $Score::FlagDef;
				if ($ScoreOn) bottomprint(%Client, "Score + " @ $Score::FlagDef @ " Flag Defence = " @ %client.score @ " Total Score" ,3);
				Game::refreshClientScore(%client);
			}

			if ($Shifter::TurretKill && %kill)
			{
				Client::setOwnedObject(%client, %turret);
				Client::setOwnedObject(%client, %player);
			}
			return %turret;
		}
		else
			Client::sendMessage(%client,1,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,1,"Deployable Item limit reached for " @ %item.description @ "'s.");
	return false;
}

//================================================================================================ Deploy Shape
function Item::deployShape(%player,%name,%shape,%item)
{
	%client = Player::getClient(%player);
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item])
	{
		if (GameBase::getLOSInfo(%player,3)) {

			%obj = getObjectType($los::object);
            %objname = GameBase::getDataName(%obj);
            if (%obj == "SimTerrain" || %obj == "InteriorShape" || %obj == "DeployablePlatform" || %objname == "ssFloatingPad")
			{
				if (Vector::dot($los::normal,"0 0 1") > 0.7)
				{
					if(checkDeployArea(%client,$los::position))
					{
						%sensor = newObject("","Sensor",%shape,true);
 	        	  	 		addToSet("MissionCleanup", %sensor);
						GameBase::setTeam(%sensor,GameBase::getTeam(%player));
						GameBase::setPosition(%sensor,$los::position);
						Gamebase::setMapName(%sensor,%name);
						Client::sendMessage(%client,0,%item.description @ " deployed");
						playSound(SoundPickupBackpack,$los::position);
						echo("MSG: ",%client," deployed a ",%name);
						return true;
					}
				}
				else
					Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
			}
			else
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
	return false;
}


////////////////////////////////////////////////////////////////////////////////
// END
////////////////////////////////////////////////////////////////////////////////

