echo("Loading Screaming Fist Version");
editActionMap("playMap.sae");
bindCommand(keyboard0, make, control, "t", TO, "BotTree::AddTreePoint();");
bindCommand(keyboard0, break, control, "t", TO, "");

// initialise any startup variables and load from Tree File

function BotTree::Init_Tree()
{
// Reset Tree

$BotTree::Treepoint_Last = 0;

$BotTree::Treepoint_Exits = "";
$BotTree::Treepoint_ReSupplyPoint = "";
$BotTree::Treepoint_CommandPoint = "";
$BotTree::Treepoint_FlagPoint = "";
$BotTree::Treepoint_FirePoint = "";
$BotTree::Treepoint_GeneratorPoint = "";

// Set Tree Filename based on current mission

	%Filename = "BotTree_" @ $missionName @".cs";

// Load Tree if Exists else create blank one.

	if(isFile("config\\" @ %Filename))
		exec(%filename);
	else
		BotTree::Save_Tree();

	dbecho(1,"BotTree::Init_Tree: Loaded " @ $BotTree::Treepoint_Last @ " Tree Point");

	if($Spoonbot::BotTree_Design)
	{
		%manager = 2048;

		%found = false;

		while((%manager < 2070) && (%found == false))
			if (Client::getName(%manager) == "")
				%manager++;
			else if (Player::isAIControlled(%manager) == "true")
				%manager++;
			else
				%found = true;

		if (%manager == 2070)
		{
			dbecho(1,"No player to use as master owner of tree points, try again in 5 secs");

			schedule("BotTree::Init_Tree();", 2);

			$BotTree::Manager = %manager;
				
			return;
		}

		dbecho(1, "manager = " @ %manager @ ", name = '" @ Client::getName(%manager) @ "'");

		for (%x = 0; %x < $BotTree::Treepoint_Last; %x++)
			$BotTree::Debug_Treepoint_Object[%x] = 
				BotTree::DeployShape(%manager,%x);

		for(%x = 0; %x < $BotTree::Treepoint_Last; %x++)
			for (%y = (%x + 1); %y <= $BotTree::Treepoint_Last; %y++)
				if($BotTree::Treepoint_Los[%x,%y] == True)
					BotTree::DeployTreePointRouteShapes(%x,%y,%manager);

	}

	if($BotTree::Treepoint_Last != $BotTree::Treepoint_Last_Calc)
	{
			BotTree::Calculate_Tree_Routes();
			BotTree::Save_Tree();
	}
}

function BotTree::Save_Tree()
{
	$BotTree::Filename = "config\\BotTree_" @ $missionName @ ".cs";
	export("$BotTree::Treepoint*", $BotTree::Filename, false);
}

function BotTree::AddTreePoint(%id)
{
	for(	%AddedPoint = 0;
			((%AddedPoint < $BotTree::Treepoint_Last) &&
			($BotTree::Treepoint_Location[%AddedPoint] != "0 0 0")); %AddedPoint++) {}

	%position = GameBase::getPosition(%id);

	%message = "Added treepoint " @ %AddedPoint @ " @ " @ %position;
	Client::sendMessage(%id, 1, %message);

	$BotTree::Treepoint_Location[%AddedPoint] = Vector::Add(%position, "1 1 0");

	$BotTree::Treepoint_Los[%AddedPoint, %AddedPoint] = False;

	for(%x = 0; %x < %AddedPoint; %x++)
	{
		$BotTree::Treepoint_Los[%AddedPoint, %x] = False;
		$BotTree::Treepoint_Los[%x, %AddedPoint] = False;
		$BotTree::Treepoint_Route_Available[%x,%AddedPoint] = False;
        $BotTree::Treepoint_Route_Available[%AddedPoint,%x] = False;
	}

	//schedule("BotTree::DeployShape(" @ %id @ " , " @ %AddedPoint @ ");", 1);
	
	$BotTree::Debug_Treepoint_Object[%AddedPoint]
		= BotTree::DeployShape(%id,%AddedPoint);

	if (%AddedPoint == $BotTree::Treepoint_Last)
		$BotTree::Treepoint_Last++;

	BotTree::Save_Tree();
}

function BotTree::NearestTreePoint(%Location)
{
	return "";
}

function BotTree::NextTreePoint(%CurrentTree)
{
}



function BotTree::Calculate_Tree_Routes()
{

// loop around map points until no mo routes added

%Modified = True;
%Repeat_Count = 0;
%Max_Hops = 50;

// clear all routes first.

for (%x = 0; %x < $BotTree::Treepoint_Last; %x++)
	for (%y = (%x + 1); %y <= $BotTree::Treepoint_Last; %y++)
	{
		$BotTree::Treepoint_Route_Available[%x,%y] = false;
		$BotTree::Treepoint_Route_Available[%y,%x] = false;
		// fix for deleted routes
		if (($BotTree::Treepoint_Location[%x] == "0 0 0") ||
			($BotTree::Treepoint_Location[%y] == "0 0 0"))
		{
			$BotTree::Treepoint_Los[%x,%y] = false;
			$BotTree::Treepoint_Los[%y,%x] = false;
		}
	}

while ((%Modified == True) && (%Repeat_Count <= %Max_Hops))
{
	%Modified = False;

// Loop through all possible combinations of waypoints
 
    for (%x = 0; %x < $BotTree::Treepoint_Last; %x++)
	{
		for (%y = (%x + 1); %y <= $BotTree::Treepoint_Last; %y++)
		{
			//dbecho(1, "%x=" @ %x @ ", %y=" @ %y);

	        %RouteFound = False;
 
// If LOS = True then route available = true

			//dbecho(1, "Route between " @ %x @ " and " @ %y @ " = " @
			//	$BotTree::Treepoint_Route_Available[%x,%y]);

            if ($BotTree::Treepoint_Route_Available[%x,%y] == false)
			{

                if ($BotTree::Treepoint_Los[%x,%y] == True )
				{
                    $BotTree::Treepoint_Route_Available[%x,%y] = True;
                    $BotTree::Treepoint_Route[%x,%y] = "";
                    $BotTree::Treepoint_Route_Available[%y,%x] = True;
                    $BotTree::Treepoint_Route[%y,%x] = "";
                    %RouteFound = True;
				}
                else

// Look for indirect route based on alternate waypoint

				{            
                    %z = 0;
            
                    while ((%z < $BotTree::Treepoint_Last) && (%RouteFound == False))
					{

// Stop check for source and destination
						if ((%z != %x) && (%z != %y) && ($BotTree::Treepoint_Los[%x,%z] == True))
						{
		                    if ($BotTree::Treepoint_Route_Available[%z,%y] == True)
							{
				                $BotTree::Treepoint_Route_Available[%x,%y] = True;
					            $BotTree::Treepoint_Route_Available[%y,%x] = True;

                                $BotTree::Treepoint_Route[%x,%y] = %z @ " " @ $BotTree::Treepoint_Route[%z,%y];
	                            $BotTree::Treepoint_Route[%y,%x] = $BotTree::Treepoint_Route[%y,%z] @ " " @ %z;
		                        %RouteFound = True;
			                }
						}

						%z++;
                    }
        
                }

            }

            if (%RouteFound == True)
			{
				%Modified = True;
				dbecho(1, "Route added between " @ %x @ " and " @ %y);
			}
        }
	}

    if (%Modified == True)
          %Repeat_Count++;


}

$BotTree::Treepoint_Last_Calc = $BotTree::Treepoint_Last;

}


function BotTree::DeployShape(%player,%point)
{
 %position = $BotTree::Treepoint_Location[%point];
 %client = Player::getClient(%player);

 %rot = GameBase::getRotation(%player);
 %dobj = newObject("","StaticShape",TreePointShape,true);
 addToSet("MissionCleanup", %dobj);
 GameBase::setTeam(%dobj,GameBase::getTeam(%client));

 GameBase::setPosition(%dobj,%position);
 GameBase::setRotation(%dobj,%rot);
 Gamebase::setMapName(%dobj,"Tree Point");
 GameBase::startFadeIn(%dobj);

 return %dobj;
}


function BotTree::DeployRouteShape(%player,%position)
{

 %client = Player::getClient(%player);
 %rot = GameBase::getRotation(%player);
 %dobj = newObject("","StaticShape",TreePointRouteShape,true);
 addToSet("MissionCleanup", %dobj);
 GameBase::setTeam(%dobj,GameBase::getTeam(%player));

 GameBase::setPosition(%dobj,%position);
 GameBase::setRotation(%dobj,%rot);
 Gamebase::setMapName(%dobj,"Tree Point Route");
 GameBase::startFadeIn(%dobj);

 return %dobj;

}




function BotTree::DeployTreePointRouteShapes(%x, %y, %player)
{

	%startid = $BotTree::Debug_Treepoint_Object[%x];
	%destid = $BotTree::Debug_Treepoint_Object[%y];
	%numberofpoints = 2;
	%startpos = GameBase::getPosition(%startid);
	%destpos = GameBase::getPosition(%destid);
	%diff = Vector::sub(%destpos, %startpos);
	%Dist = Vector::getDistance(%destpos, %startpos);
	if (%Dist < 0)
		%Dist *= -1;

	%delta = (getWord(%diff,0) / %numberofpoints) @ " " @ getWord(%diff,1) / %numberofpoints @ " " @ getWord(%diff,2) / %numberofpoints;

	%z = 1;

	%nextpos = Vector::Add(%StartPos, %delta);
	%Startpos = %nextpos;

	while(%z < %numberofpoints)
	{

		$BotTree::Debug_Treepoint_Object[%x,%y] = // Need to find a way of setting Y poition at floor level !
					BotTree::DeployRouteShape(%player,Vector::Add(%Startpos, "0 0 0.5"));	

		$BotTree::Debug_Treepoint_Object[%y,%x] = $BotTree::Debug_Treepoint_Object[%x,%y];

		%nextpos = Vector::Add(%StartPos, %delta);

		dbecho(1, "dbobject for (" @ %x @ "," @ %y @ ") = " @ $BotTree::Debug_Treepoint_Object[%x,%y]);
		%StartPos = %nextpos;

		%z++;
	}

}


function	BotTree::TreeMenu(%this,%object)
{
// Check to see if %object is tree point. If so show menu.

	%found = false;

	for (%x = 0; ((%x < $BotTree::Treepoint_Last) && (%found == false)); %x++)
		if(%object == $BotTree::Debug_Treepoint_Object[%x])
		{
			%ClientId = Player::getClient(%this);

			%found = true;

			$BotTree::Client_Treepoint[%ClientId] = %x;

			Client::buildMenu(%ClientId, "Tree Point " @ %x, "TreeMain", true);

			Client::addMenuItem(%ClientId, "1Start Tree Point LO", "Start");

			Client::addMenuItem(%ClientId, "2End Tree Point LO" @ $BotTree::Client_Treepoint_Start[%ClientId], "End");

			Client::addMenuItem(%ClientId, "3Delete Tree Point Menu", "Delete");

			if(String::findSubStr($BotTree::Treepoint_Exits,
				$BotTree::Client_Treepoint[%ClientId] @ " ") >= 0)
				Client::addMenuItem(%ClientId, "4Remove Exit Point", "Exit");
			else
				Client::addMenuItem(%ClientId, "4Add Exit Point", "Exit");

			if(String::findSubStr($BotTree::Treepoint_GeneratorPoint,
				$BotTree::Client_Treepoint[%ClientId] @ " ") == 0)
				Client::addMenuItem(%ClientId, "5Remove Generator Point", "Generator");
			else
				Client::addMenuItem(%ClientId, "5Add Generator Point", "Generator");

			if(String::findSubStr($BotTree::Treepoint_CommandPoint,
				$BotTree::Client_Treepoint[%ClientId] @ " ") == 0)
				Client::addMenuItem(%ClientId, "6Remove Command Point", "Command");
			else
				Client::addMenuItem(%ClientId, "6Add Command Point", "Command");

			if(String::findSubStr($BotTree::Treepoint_ReSupplyPoint,
				$BotTree::Client_Treepoint[%ClientId] @ " ") == 0)
				Client::addMenuItem(%ClientId, "7Remove ReSupply Point", "ReSupply");
			else
				Client::addMenuItem(%ClientId, "7Add ReSupply Point", "ReSupply");

			if(String::findSubStr($BotTree::Treepoint_FirePoint,
				$BotTree::Client_Treepoint[%ClientId] @ " ") == 0)
				Client::addMenuItem(%ClientId, "8Remove Fire Point", "Fire");
			else
				Client::addMenuItem(%ClientId, "8Add Fire Point", "Fire");

		}
	
	if(%found == false) // else check to see if it's a treepoint route
	{
		dbecho(1, "checking for route");
	    for (%x = 0; ((%x < $BotTree::Treepoint_Last)  && (%found == false)); %x++)
			for (%y = (%x + 1); ((%y <= $BotTree::Treepoint_Last)  && (%found == false)); %y++)
				if(%object == $BotTree::Debug_Treepoint_Object[%x,%y])
				{
					%ClientId = Player::getClient(%this);

					%found = true;

					$BotTree::Client_Treepointx[%ClientId] = %x;
					$BotTree::Client_Treepointy[%ClientId] = %y;

					Client::buildMenu(%ClientId, "Tree Point Route " @ %x, "TreeRouteMain", true);

					Client::addMenuItem(%ClientId, "1Delete Tree Point Route", "Delete");
				}
	}
	return;
}


function processMenuTreeRouteMain(%ClientId, %opt)
{
	if(%opt == "Delete")
	{
		%x = $BotTree::Client_Treepointx[%ClientId];
		%y = $BotTree::Client_Treepointy[%ClientId];
		  
		%team = GameBase::getTeam(%Clientid);

		BotFuncs::TeamMessage(%team,"Removing Tree Point Route " @ %x @ "," @ %y);

		$BotTree::Treepoint_Los[%x,%y] = false;
		$BotTree::Treepoint_Los[%y,%x] = false;
		deleteObject($BotTree::Debug_Treepoint_Object[%x,%y]);

		if($BotTree::Treepoint_Last <= $SpoonBot::BotTree_MaxAutoCalc)
			BotTree::Calculate_Tree_Routes();

		BotTree::Save_Tree();
	}
}

function processMenuTreeMain(%ClientId, %opt)
{
	if(%opt == "Fire")
	{
		%team = GameBase::getTeam(%Clientid);

		if(String::findSubStr($BotTree::Treepoint_ReSupplyPoint,
			$BotTree::Client_Treepoint[%ClientId] @ " ") >= 0)
		{
			BotFuncs::TeamMessage(%team,"Tree Fire Point Removed @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			%New_ReSupplyPoint = "";
			
			%x = 0;

			%wordcount = BotThink::getWordCount($BotTree::Treepoint_ReSupplyPoint);

			for(%x = 0; %x < %wordcount; %x++)
				if(getWord($BotTree::Treepoint_ReSupplyPoint,%x) !=
					$BotTree::Client_Treepoint[%ClientId])
						%New_ReSupplyPoint = %New_ReSupplyPoint @ getWord($BotTree::Treepoint_ReSupplyPoint,%x) @ " ";

			$BotTree::Treepoint_ReSupplyPoint = %New_ReSupplyPoint;
			
		}
		else
		{
			BotFuncs::TeamMessage(%team,"Tree Fire Point Added @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			$BotTree::Treepoint_ReSupplyPoint = $BotTree::Treepoint_ReSupplyPoint @
					$BotTree::Client_Treepoint[%ClientId] @ " ";

		}

		BotTree::save_Tree();
	}
	else if(%opt == "ReSupply")
	{
		%team = GameBase::getTeam(%Clientid);

		if(String::findSubStr($BotTree::Treepoint_ReSupplyPoint,
			$BotTree::Client_Treepoint[%ClientId] @ " ") >= 0)
		{
			BotFuncs::TeamMessage(%team,"Tree ReSupply Point Removed @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			%New_ReSupplyPoint = "";
			
			%x = 0;

			%wordcount = BotThink::getWordCount($BotTree::Treepoint_ReSupplyPoint);

			for(%x = 0; %x < %wordcount; %x++)
				if(getWord($BotTree::Treepoint_ReSupplyPoint,%x) !=
					$BotTree::Client_Treepoint[%ClientId])
						%New_ReSupplyPoint = %New_ReSupplyPoint @ getWord($BotTree::Treepoint_ReSupplyPoint,%x) @ " ";

			$BotTree::Treepoint_ReSupplyPoint = %New_ReSupplyPoint;
			
		}
		else
		{
			BotFuncs::TeamMessage(%team,"Tree ReSupply Point Added @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			$BotTree::Treepoint_ReSupplyPoint = $BotTree::Treepoint_ReSupplyPoint @
					$BotTree::Client_Treepoint[%ClientId] @ " ";

		}

		BotTree::save_Tree();
	}
	else if(%opt == "Command")
	{
		%team = GameBase::getTeam(%Clientid);

		if(String::findSubStr($BotTree::Treepoint_CommandPoint,
			$BotTree::Client_Treepoint[%ClientId] @ " ") >= 0)
		{
			BotFuncs::TeamMessage(%team,"Tree Command Point Removed @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			%New_CommandPoint = "";
			
			%x = 0;

			%wordcount = BotThink::getWordCount($BotTree::Treepoint_CommandPoint);

			for(%x = 0; %x < %wordcount; %x++)
				if(getWord($BotTree::Treepoint_CommandPoint,%x) !=
					$BotTree::Client_Treepoint[%ClientId])
						%New_CommandPoint = %New_CommandPoint @ getWord($BotTree::Treepoint_CommandPoint,%x) @ " ";

			$BotTree::Treepoint_CommandPoint = %New_CommandPoint;
			
		}
		else
		{
			BotFuncs::TeamMessage(%team,"Tree Command Point Added @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			$BotTree::Treepoint_CommandPoint = $BotTree::Treepoint_CommandPoint @
					$BotTree::Client_Treepoint[%ClientId] @ " ";

		}

		BotTree::save_Tree();
	}
	else if(%opt == "Generator")
	{
		%team = GameBase::getTeam(%Clientid);

		if(String::findSubStr($BotTree::Treepoint_GeneratorPoint,
			$BotTree::Client_Treepoint[%ClientId] @ " ") >= 0)
		{
			BotFuncs::TeamMessage(%team,"Tree Generator Point Removed @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			%New_GeneratorPoint = "";
			
			%x = 0;

			%wordcount = BotThink::getWordCount($BotTree::Treepoint_GeneratorPoint);

			for(%x = 0; %x < %wordcount; %x++)
				if(getWord($BotTree::Treepoint_GeneratorPoint,%x) !=
					$BotTree::Client_Treepoint[%ClientId])
						%New_GeneratorPoint = %New_GeneratorPoint @ getWord($BotTree::Treepoint_GeneratorPoint,%x) @ " ";

			$BotTree::Treepoint_GeneratorPoint = %New_GeneratorPoint;
			
		}
		else
		{
			BotFuncs::TeamMessage(%team,"Tree Generator Point Added @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			$BotTree::Treepoint_GeneratorPoint = $BotTree::Treepoint_GeneratorPoint @
					$BotTree::Client_Treepoint[%ClientId] @ " ";

		}

		BotTree::save_Tree();
	}
	else if(%opt == "Exit")
	{
		%team = GameBase::getTeam(%Clientid);

		if(String::findSubStr($BotTree::Treepoint_Exits,
			$BotTree::Client_Treepoint[%ClientId] @ " ") >= 0)
		{
			BotFuncs::TeamMessage(%team,"Tree Exit Point Removed @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			%New_Exits = "";
			
			%x = 0;

			%wordcount = BotThink::getWordCount($BotTree::Treepoint_Exits);

			for(%x = 0; %x < %wordcount; %x++)
				if(getWord($BotTree::Treepoint_Exits,%x) !=
					$BotTree::Client_Treepoint[%ClientId])
						%New_Exits = %New_Exits @ getWord($BotTree::Treepoint_Exits,%x) @ " ";

			$BotTree::Treepoint_Exits = %New_Exits;
			
		}
		else
		{
			BotFuncs::TeamMessage(%team,"Tree Exit Point Added @ " @
				$BotTree::Client_Treepoint[%ClientId]);

			$BotTree::Treepoint_Exits = $BotTree::Treepoint_Exits @
					$BotTree::Client_Treepoint[%ClientId] @ " ";

		}

		BotTree::save_Tree();
	}
	else if(%opt == "Start")
	{
		$BotTree::Client_Treepoint_Start[%ClientId] = $BotTree::Client_Treepoint[%ClientId];
	}
	else if(%opt == "End")
	{
		$BotTree::Client_Treepoint_End[%ClientId] = $BotTree::Client_Treepoint[%ClientId];
		
		if($BotTree::Treepoint_Los[$BotTree::Client_Treepoint_Start[%ClientId],$BotTree::Client_Treepoint_End[%ClientId]] == false)
		{
			%team = GameBase::getTeam(%Clientid);

			BotFuncs::TeamMessage(%team,"TreePoint Route added between " @
				$BotTree::Client_Treepoint_Start[%ClientId] @ " and " @
				$BotTree::Client_Treepoint_End[%ClientId] @ ".");

			$BotTree::Treepoint_Los[$BotTree::Client_Treepoint_Start[%ClientId],$BotTree::Client_Treepoint_End[%ClientId]] = True;
			$BotTree::Treepoint_Los[$BotTree::Client_Treepoint_End[%ClientId],$BotTree::Client_Treepoint_Start[%ClientId]] = True;

			BotTree::DeployTreePointRouteShapes($BotTree::Client_Treepoint_Start[%ClientId], $BotTree::Client_Treepoint_End[%ClientId], %ClientId);

			if($BotTree::Treepoint_Last <= $SpoonBot::BotTree_MaxAutoCalc)
				BotTree::Calculate_Tree_Routes();

			BotTree::Save_Tree();
		}
		else
			BotFuncs::TeamMessage(%team,"TreePoint Route already exists between " @
				$BotTree::Client_Treepoint_Start[%ClientId] @ " and " @
				$BotTree::Client_Treepoint_End[%ClientId] @ "!");
	}
	else if(%opt == "Delete")
	{
		Client::buildMenu(%ClientId, "Tree Point Delete:","TreeDel", true);

		Client::addMenuItem(%ClientId, "1Delete Tree Point and Routes", "YesPoint");

		Client::addMenuItem(%ClientId, "2Delete all Routes", "YesRoute");
	}
	else
		return;
}



function processMenuTreeDel(%ClientId, %opt)
{


	%team = GameBase::getTeam(%Clientid);

	if(%opt == "YesPoint")
	{
		deleteObject($BotTree::Debug_Treepoint_Object[$BotTree::Client_Treepoint[%ClientId]]);

		$BotTree::Treepoint_Location[$BotTree::Client_Treepoint[%ClientId]] = "0 0 0";

		BotFuncs::TeamMessage(%team,"TreePoint " @
				$BotTree::Client_Treepoint[%ClientId] @
				" deleted and any LOS associtated with it,");

		for(%x = 0; %x < $BotTree::Treepoint_Last; %x++)
		{
			if($BotTree::Treepoint_Los[%x,$BotTree::Client_Treepoint[%ClientId]] == True)
			{
				$BotTree::Treepoint_Los[%x,$BotTree::Client_Treepoint[%ClientId]] = false;
				$BotTree::Treepoint_Los[$BotTree::Client_Treepoint[%ClientId],%x] = false;
				deleteObject($BotTree::Debug_Treepoint_Object[$BotTree::Client_Treepoint[%ClientId],%x]);
			}
		}

		if($BotTree::Treepoint_Last <= $SpoonBot::BotTree_MaxAutoCalc)
			BotTree::Calculate_Tree_Routes();

		BotTree::Save_Tree();

	}
	else if(%opt == "YesRoute")
	{
		for(%x = 0; %x <  $BotTree::Treepoint_Last; %x++)
			if($BotTree::Treepoint_Los[%x,$BotTree::Client_Treepoint[%ClientId]] == True)
			{
				$BotTree::Treepoint_Los[%x,$BotTree::Client_Treepoint[%ClientId]] = false;
				$BotTree::Treepoint_Los[$BotTree::Client_Treepoint[%ClientId],%x] = false;
				deleteObject($BotTree::Debug_Treepoint_Object[$BotTree::Client_Treepoint[%ClientId],%x]);
			}

			BotFuncs::TeamMessage(%team,"TreePoint " @
				$BotTree::Client_Treepoint_Start[%ClientId] @
				" LOS details removed");

			if($BotTree::Treepoint_Last <= $SpoonBot::BotTree_MaxAutoCalc)
				BotTree::Calculate_Tree_Routes();

			BotTree::Save_Tree();
	}
}





// Callable functions for tree selection.

function BotTree::FindNearestTreebyId(%id)
{
	%PlayerPosition = GameBase::getPosition(%id);

	%Nearest = -1;

	%Distance = 999999;

	for(%x = 0; %x < $BotTree::Treepoint_Last; %x++)
	{
		%TreePosition = $BotTree::Treepoint_Location[%x];

		%NomDistance = Vector::getDistance(%PlayerPosition, %TreePosition);

		if (%NomDistance < %Distance)
		{
			%Nearest = %x;
			%Distance = %NomDistance;
		}
	}
 
	dbecho(1, "Nearest Point Position = " @ %TreePosition);

	dbecho(1, "Distance = " @ %Distance);

	return %Nearest;
 
}



function BotTree::FindNearestTreebyPos(%PlayerPosition)
{
	%Nearest = -1;

	%Distance = 999999;

	for(%x = 0; %x < $BotTree::Treepoint_Last; %x++)
	{
		%TreePosition = $BotTree::Treepoint_Location[%x];

		%NomDistance = Vector::getDistance(%PlayerPosition, %TreePosition);

		//dbecho(1, "nomdistance = " @ %NomDistance);

		if (%NomDistance < %Distance)
		{
			%Nearest = %x;
			%Distance = %NomDistance;
		}
	}
 
	dbecho(1, "Nearest Point Position = " @ %TreePosition);

	dbecho(1, "Distance = " @ %Distance);

	return %Nearest;
 
}


function BotTree::FindNearestTreeExitbyTreePoint(%Point)
{
	%hopcount = 9999;
	%ExitDesignate = -1;

	for(%x = 0; %x < $BotTree::Treepoint_Last; %x++)	// Check all tree points
		if(String::findSubStr($BotTree::Treepoint_Exits,%x @ " ") >= 0) // check if tree exit
			if($BotTree::Treepoint_Route_Available[%Point,%x] == True)
			{
				if(BotThink::getWordCount($BotTree::Treepoint_Route[%Point,%x]) < %hopcount)
				{
					%hopcount = $BotTree::Treepoint_Route_Available[%Point,%x];
					%ExitDesignate = %x;
				}	
			}

	dbecho(1, "Nearest exit point to " @ %Point @ " = " @ %ExitDesignate );

	return %ExitDesignate;
}
