// LOS Function filter:
// 1 = SimTerrainObjectType | SimInteriorObjectType
// 2 = StaticObjectType
// 4 = MoveableObjectType
// 8 = VehicleObjectType
// 16 = PlayerObjectType
// 32 = MineObjectType
// 64 = ItemObjectType
//
// The function returns true if it hit something, the details are placed in the
// global variables $los::position, $los::normal, $los::object (same as the
// GameBase LOS function).

$BotTree::T_Count = 0;

function BotTree::Add_T(%id, %pos)
{

// check to see if an exiting point is within 1 unit, if so ignore request.

	%add_tp = -1;

	for(%x = 0; %x < $BotTree::T_Count; %x++)
		if(Vector::getDistance(%pos, $BotTree::T_Pos[%x]) < 1)
			%add_tp = %x;

	if(%add_tp == -1)
	{
		$BotTree::T_Pos[$BotTree::T_Count] = %pos;

		BotFuncs::TeamMessage(GameBase::getTeam(%id), "Added Tree point " @ $BotTree::T_Count @ " at " @ %pos);

if ($Spoonbot::DebugMode)
		dbecho(1,"Added Tree point " @ $BotTree::T_Count @ " at " @ %pos);
if ($Spoonbot::DebugMode)
		dbecho(1,"Point " @ $BotTree::T_Count @ " can see " @ BotTree::GetLosView(%pos));

		// Start: code added by Sam Wilson
		// This is to keep track of an adjacency matrix for all of the treepoints
		// With the adjacency matrix we can greatly improve the speed of shortest-path
		// calculation
		for( %x = 0; %x < $BotTree::T_Count; %x++ )
		{
			// if the current point is visible from the point we're adding
			// then put the distance between then in the matrix.  Otherwise,
			// indicate that there is no LOS.  (I will use a value of
			// 99999 to indicate no LOS.)
			%nextPos = $BotTree::T_Pos[ %x ];

			if( BotTree::CheckLOS( %pos, %nextPos, 200 ) == true )
			{
				%distance = Vector::getDistance( %pos, %nextPos );
				$BotTree::T_Adjacency[ $BotTree::T_Count, %x ] = %distance; //changed in 0.5g: Minimizes Bottree file size
				$BotTree::T_Adjacency[ %x, $BotTree::T_Count ] = %distance;
			}
			else
			{
				%distance = 99999;
			}
		}
		// The new point is adjacent to itself
		$BotTree::T_Adjacency[ $x, $BotTree::T_Count ] = -1;

		// End: code added by Sam Wilson

		$BotTree::T_Count = $BotTree::T_Count + 1;

		//botTree::DeployShapeAtPos(%id, Vector::Add(%Pos,"0 0 2"));

		BotTree::Save_Tree();

	}
}

// Function to see if a point can see all points in list

function BotTree::CanSeeAllLOS(%Point,%Points)
{
	%Result = true;
	%PointCount = BotThink::getWordCount(%points);
	%Pos = $BotTree::T_Pos[%Point];
	%Cansee = "";
	for(%x = 0; %x < %PointCount; %x++)
	{
		if	((%Point != getWord(%points,%x)) &&
			(BotTree::CheckLOS(%Pos,$BotTree::T_Pos[getWord(%points,%x)],200) == False))
			%Result = False;
		else
			%cansee = %cansee @ getWord(%points,%x) @ " ";
	}

	return %Result;
}

function BotTree::CheckLOS(%pos1,%pos2,%MaxDist)
{
	%Result = False;

	if(Vector::getDistance(%pos1,%pos2) < %MaxDist)
		if(GetLosInfo(%pos1, %pos2, 1) == 0)
			%Result = True;
	return %Result;
}

function BotTree::CheckItemLOS(%pos1,%pos2,%MaxDist)
{
	%Result = False;

	%xPos = getWord(%pos1, 0);                   //Now add some height to coordinates to make sure we get a correct LOS
	%yPos = getword(%pos1, 1);
	%zPos = getWord(%pos1, 2) + 1.5;
	%pos1 = %xPos @ "  " @ %yPos @ "  " @ %zPos;

	%xPos = getWord(%pos2, 0);
	%yPos = getword(%pos2, 1);
	%zPos = getWord(%pos2, 2) + 0.5;
	%pos2 = %xPos @ "  " @ %yPos @ "  " @ %zPos;


	if(Vector::getDistance(%pos1,%pos2) < %MaxDist)
		if(GetLosInfo(%pos1, %pos2, 1) == 0)
			%Result = True;
	return %Result;
}

function BotTree::GetLosView(%pos)
{
	%Result = "";

	for(%x = 0; %x < $BotTree::T_Count; %x++)
		if(	($BotTree::T_Pos[%x] != %Pos) &&
				BotTree::CheckLOS(%pos,$BotTree::T_Pos[%x],200))
			%Result = %Result @ %x @ " ";
	
	return %Result;
}



function BotTree::AutoTree(%id)
{

// Find Nearest Object with no near TreePoint
//
//	%IdPos = GameBase::getPosition(%object);
//
//	%Target = -1;
//
//	%TargetDistance = 99999;
//
//	for(%x = 0; %x < $BotFuncs::AllCount; %x++)
//	{
//		%object = $BotFuncs::AllList[%x];
//
//		%TargetPos = GameBase::getPosition(%object);
//
//		%Distance = Vector::getDistance(%TargetPos,%AiPos);
//		
//		if(%Distance < %TargetDistance)
//		{
//			%TargetTree = BotTree::FindNearestTreebyPos(%TargetPos);
//			
//			if(%TargetTree != -1)
//			{
//				%TreePos = Vector::getDistance(%TargetPos,$BotTree::T_Pos[%TargetTree]);
//				%TreeDistance = Vector::getDistance(%TargetPos,%TreePos);
//
//				if(%TreeDistance >= 10)
//				{
//					%Target = %object;
//					%TargetDistance = %Distance;
//				}
//			}
//			else
//			{
//				%Target = %object;
//				%TargetDistance = %Distance;
//			}
//
//
//		}
//
//	}

//	dbecho(1,"Tree Target = " @ %Target @ ", distance = " @ %TargetDistance );

// Check for startup vars - no nulls please!.

	if($BotTree::LastGoodPos == "")
	{
		$BotTree::LastGoodLosView = BotTree::GetLosView(Vector::Add(GameBase::getPosition(%id),"0 0 2"));
		$BotTree::LastGoodPos = Vector::Add(GameBase::getPosition(%id),"0 0 0.01");
if ($Spoonbot::DebugMode)
		dbecho(1,"Init tree search engine");
	}

// Get current position

	$BotTree::CurrentPos = Vector::Add(GameBase::getPosition(%id),"0 0 2");

	if($BotTree::LastGoodPos != $BotTree::CurrentPos)
	{

		$BotTree::CurrentPos = Vector::Add(GameBase::getPosition(%id),"0 0 0.01");
		$BotTree::CurrentLosView = BotTree::GetLosView($BotTree::CurrentPos);
		
		if($BotTree::CurrentLosView == $BotTree::LastGoodLosView) // LOS!
		{
			$BotTree::LastGoodPos = $BotTree::CurrentPos;
			$BotTree::LastGoodLosView = $BotTree::CurrentLosView;
		}
		else // No LOS!
		{


if ($Spoonbot::DebugMode)
			dbecho(1,"Los change.");
if ($Spoonbot::DebugMode)
			dbecho(1,"Last    = " @ $BotTree::LastGoodLosView);
if ($Spoonbot::DebugMode)
			dbecho(1,"Current = " @ $BotTree::CurrentLosView);

// Lost contact with tree points so add a new one a last good point.

			if ((BotThink::getWordCount($BotTree::CurrentLosView) == 0) &&
				(BotThink::getWordCount($BotTree::LastGoodLosView) > 0))
			{
if ($Spoonbot::DebugMode)
				dbecho(1,"Type 1: Added point at last good pos");
				BotTree::Add_T(%id, Vector::Add($BotTree::LastGoodPos,"0 0 2"));
			}

// Gained contact with tree points. Add tree point at current position
// Should never happen as in design mode it should not be possible to lose sight in tree points.

//Comment by Werewolf: It happens, when you switch teams. I always switch teams to map the other team's base, so this IS a common situation!

			else if((BotThink::getWordCount($BotTree::CurrentLosView) > 0) &&
					(BotThink::getWordCount($BotTree::LastGoodLosView) == 0))
			{
				BotTree::Add_T(%id,Vector::Add( $BotTree::CurrentPos,"0 0 2"));
if ($Spoonbot::DebugMode)
				dbecho(1,"Type 2: Added point at current pos");
			}

// Tree point view has reduced/remained same count with different views.
// Check to see if any still in view can see us/rest. If not add one at last good pos.

			else if(BotThink::getWordCount($BotTree::CurrentLosView) <=
					BotThink::getWordCount($BotTree::LastGoodLosView))
			{
if ($Spoonbot::DebugMode)
				dbecho(1,"Type 3: ???");

				%wordcount = BotThink::getWordCount($BotTree::LastGoodLosView);
				
				%add_tp = true;

				for(%y = 0; %y < %wordcount; %y++)
				{
					%point = getWord($BotTree::LastGoodLosView,%y);
					%pos = $BotTree::T_Pos[%point];

					if(BotTree::CheckLOS(%pos,$BotTree::CurrentPos,200))
						if(BotTree::CanSeeAllLOS(%point,$BotTree::LastGoodLosView) == True)
							%add_tp = false;
				}

				if(%add_tp == true)
				{
					BotTree::Add_T(%id, Vector::Add($BotTree::LastGoodPos,"0 0 2"));
if ($Spoonbot::DebugMode)
					dbecho(1,"Type 3: Added point at last good pos");
				}
			}

// Tree point view has increased/remained same count with different views.
// Check to see if any still in view can see us/rest. If not add one at current pos.

			else if(BotThink::getWordCount($BotTree::CurrentLosView) >=
					BotThink::getWordCount($BotTree::LastGoodLosView))
			{
if ($Spoonbot::DebugMode)
				dbecho(1,"Type 4: ???");

				%wordcount = BotThink::getWordCount($BotTree::CurrentLosView);
				
				%add_tp = true;

				for(%y = 0; %y < %wordcount; %y++)
				{
					%point = getWord($BotTree::CurrentLosView,%y);

					if(BotTree::CanSeeAllLOS(%point,$BotTree::CurrentLosView) == True)
						%add_tp = false;

				}

				if(%add_tp == true)
				{
					BotTree::Add_T(%id, Vector::Add($BotTree::CurrentPos,"0 0 2"));
if ($Spoonbot::DebugMode)
					dbecho(1,"Type 4: Added point at current pos");
				}
			}
			else
			{
if ($Spoonbot::DebugMode)
				dbecho(1,"Cannot fathem out last and current los info");
			}	

			$BotTree::CurrentLosView = BotTree::GetLosView($BotTree::CurrentPos);
					
			$BotTree::LastGoodPos = $BotTree::CurrentPos;
			$BotTree::LastGoodLosView = $BotTree::CurrentLosView;

if ($Spoonbot::DebugMode)
			dbecho(1,"New Los.");
if ($Spoonbot::DebugMode)
			dbecho(1,"NewLast    = " @ $BotTree::LastGoodLosView);
if ($Spoonbot::DebugMode)
			dbecho(1,"NewCurrent = " @ $BotTree::CurrentLosView);

		}
	}


	$BOTTREE::Target_Loc = "<" @ $BotTree::LastGoodLosView @ ">";
	$BOTTREE::Unresolved_Objects = "<" @ $BotTree::CurrentLosView @ ">";
	$BOTTREE::User_Loc = $BotTree::CurrentPos;

// Reschedule after a couple of  milli secs!
	schedule("BotTree::AutoTree(" @ %Id@ ");", 0.1);
}

// initialise any startup variables and load from Tree File

function BotTree::Init_Tree()
{

// Reset Tree
$BotTree::T_Count = 0;
$BotTree::T_Count_Calc = 0;
$BotTree::T_Exits = "";
$BotTree::T_ReSupplyPoint = "";
$BotTree::T_CommandPoint = "";
$BotTree::T_FlagPoint = "";
$BotTree::T_FirePoint = "";
$BotTree::T_GeneratorPoint = "";

// Load pos details on objects to be linked into Tree system, gens, guns etc.



// Set Tree Filename based on current mission

	%Filename = "BT_" @ $missionName @".cs";

// Load Tree if Exists else create blank one.

//	exec("Vehicle");	//For some reason, vehicle.cs doesn't get loaded sometimes. This fixes it.

	// PORT FIX: the seven tree files that came with the mod now sit in the mod folder, not in
	// config\. isFile() opens a real file at exactly config\BT_<map>.cs and so never saw them: the
	// mod then wrote an empty tree and the bots had no routes. Order now:
	//   1. config\BT_<map>.cs -- a tree the host made or edited (design mode saves there);
	//      exec'd by its path so a tree saved in this session is read from disk;
	//   2. BT_<map>.cs anywhere on the search path -- the ones shipped with the mod;
	//   3. neither: write an empty tree, as before.
	if(isFile("config\\" @ %Filename))
		exec("config\\" @ %Filename);
	else if(File::findFirst(%Filename) != "")
		exec(%Filename);
	else
		BotTree::Save_Tree();

	dbecho(1,"BotTree::Init_Tree: Loaded " @ $BotTree::T_Count @ " Tree Point");

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

//If there are not points add one by player.

		if($BotTree::T_Count == 0)
//			BotTree::Add_T(%id, Vector::Add(GameBase::getPosition(%id),"0 0 3"));

		%id=%manager;
		%pos=GameBase::getPosition(%manager);

		$BotTree::T_Pos[$BotTree::T_Count] = %pos;

		BotFuncs::TeamMessage(GameBase::getTeam(%id), "Added Tree point " @ $BotTree::T_Count @ " at " @ %pos);

if ($Spoonbot::DebugMode)
		dbecho(1,"Added Tree point " @ $BotTree::T_Count @ " at " @ %pos);

if ($Spoonbot::DebugMode)
		dbecho(1,"Point " @ $BotTree::T_Count @ " can see " @ BotTree::GetLosView(%pos));

		// Start: code added by Sam Wilson
		// This is to keep track of an adjacency matrix for all of the treepoints
		// With the adjacency matrix we can greatly improve the speed of shortest-path
		// calculation
		for( %x = 0; %x < $BotTree::T_Count; %x++ )
		{
			// if the current point is visible from the point we're adding
			// then put the distance between then in the matrix.  Otherwise,
			// indicate that there is no LOS.  (I will use a value of
			// 99999 to indicate no LOS.)
			%nextPos = $BotTree::T_Pos[ %x ];

			if( BotTree::CheckLOS( %pos, %nextPos, 200 ) == true )
			{
				%distance = Vector::getDistance( %pos, %nextPos );
				$BotTree::T_Adjacency[ $BotTree::T_Count, %x ] = %distance;
				$BotTree::T_Adjacency[ %x, $BotTree::T_Count ] = %distance;
			}
			else
			{
				%distance = 99999;
			}
		}
		// The new point is adjacent to itself
		$BotTree::T_Adjacency[ $x, $BotTree::T_Count ] = -1;

		// End: code added by Sam Wilson

		$BotTree::T_Count = $BotTree::T_Count + 1;

		//botTree::DeployShapeAtPos(%id, Vector::Add(%Pos,"0 0 2"));

		BotTree::Save_Tree();
		BotTree::AutoTree(%Manager);

	}
}

function BotTree::Save_Tree()
{
	$BotTree::Filename = "config\\BT_" @ $missionName @ ".cs";
	export("$BotTree::T_*", $BotTree::Filename, false);
}

function BotTree::Calculate_Tree_Routes()
{
	// The main calculation algorithm has been changed to use Dijkstra's
	// algorithm.

	// Remove any unwanted points

	BotTree::Optimise_Points();

	BotTree::Save_Tree();

	// Run Dijkstra's algorithm on the adjacency matrix.  Dijkstra's
	// algorithm for finding shortest paths in a graph is pretty
	// standard.  You should be able to find a good description
	// of it in any data structures text or book of algorithms.
	// My comments will only make sense if you already know how
	// the algorithm works.

	for( %start = 0; %start < $BotTree::T_Count; %start++ )
		// loop through all possible starting
		// vertices
	{
		dbecho( 1, "Starting calcs for point " @ %start );

		// Set up the variables for each run through the
		// algorithm.

		for( %x = 0; %x < $BotTree::T_Count; %x++ )
		{
			// initialise the set of points for which optimal
			// paths have been found.  Starts with only the
			// starting vertex.
			%IsInOptimisedSet[ %x ] = 0;

			// Initialise an array that holds the length of the
			// current least path.

			%distance[ %x ] = $BotTree::T_Adjacency[ %start, %x ];

			if (%distance[ %x ] == 0)
				%distance[ %x ] = 99999;

			// Initialise routes with the simplest routes, if they exist
			if($BotTree::T_Adjacency[ %start, %x ] != 0)
			{
				$BotTree::T_R[ %start, %x ] = %start @ " " @ %x;
			}
			else
			{
				$BotTree::T_R[ %start, %x ] = "n";
			}
		}	
		%IsInOptimisedSet[ %start ] = 1;

		// The shortest path from %start to %start is just the vertex %start
		$BotTree::T_R[ %start, %start ] = %start;

		for( %step = 1; %step < $BotTree::T_Count; %step++ )
		{
			%least = 100000;
			%v = -1;

			for( %x = 0; %x < $BotTree::T_Count; %x++ )
			{
				if( %IsInOptimisedSet[ %x ] == 0 )
				{
					if( %distance[ %x ] < %least )
					{
						%least = %distance[ %x ];
						%v = %x;
					}
				}
			}

			// %v is the vertex closest to our optimised set, so
			// add it to the set.
			%IsInOptimisedSet[ %v ] = 1;

			// See if paths through %v are better than the current paths
			for( %x = 0; %x < $BotTree::T_Count; %x++ )
			{
				if ($BotTree::T_Adjacency[ %v, %x ] != 0 ) {
					%sum = %distance[ %v ] + $BotTree::T_Adjacency[ %v, %x ];
				}
				else {
					%sum = %distance[ %v ] + 999999;
				}

				if( %sum < %distance[ %x ] )
					// If going through %v is shorter
				{
					%distance[ %x ] = %sum;
					// %v is right before %x in the shortest
					// path from %start to %x
					$BotTree::T_R[ %start, %x ] = $BotTree::T_R[ %start, %v ] @ " " @ %x;
				}
			}
		}
	}
	BotTree::Save_Tree();
}


function BotTree::DeployShape(%player,%point)
{
 %position = $BotTree::T_Pos[%point];
 %client = Player::getClient(%player);

 %rot = GameBase::getRotation(%player);
 %dobj = newObject("","StaticShape",TreePointShape,true);
 addToSet("MissionCleanup", %dobj);
 GameBase::setTeam(%dobj,GameBase::getTeam(%player));

 GameBase::setPosition(%dobj,%position);
 GameBase::setRotation(%dobj,%rot);
 Gamebase::setMapName(%dobj,"Tree Point");
 GameBase::startFadeIn(%dobj);

 return %dobj;
}


function BotTree::DeployShapeAtPos(%player,%position)
{
 %client = Player::getClient(%player);

 %rot = GameBase::getRotation(%player);
 %dobj = newObject("","StaticShape",TreePointRouteShape,true);
 addToSet("MissionCleanup", %dobj);
 GameBase::setTeam(%dobj,GameBase::getTeam(%player));

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

if ($Spoonbot::DebugMode)
		dbecho(1, "dbobject for (" @ %x @ "," @ %y @ ") = " @ $BotTree::Debug_Treepoint_Object[%x,%y]);
		%StartPos = %nextpos;

		%z++;
	}

}

// Callable functions for tree selection.

function BotTree::FindNearestTreebyId(%id)
{
	%PlayerPosition = GameBase::getPosition(%id);

	%Nearest = -1;

	%Distance = 999999;

	for(%x = 0; %x < $BotTree::T_Count; %x++)
	{
		%TreePosition = $BotTree::T_Pos[%x];

		%NomDistance = Vector::getDistance(%PlayerPosition, %TreePosition);

		if ((%NomDistance < %Distance) &&
			(BotTree::CheckLOS(%PlayerPosition, %TreePosition,200) == True))
		{
			%Nearest = %x;
			%Distance = %NomDistance;
		}
	}
 
	return %Nearest;
 
}



function BotTree::FindNearestTreebyPos(%PlayerPosition)
{
	%Nearest = -1;

	%Distance = 999999;

	for(%x = 0; %x < $BotTree::T_Count; %x++)
	{
		%TreePosition = $BotTree::T_Pos[%x];

		%NomDistance = Vector::getDistance(%PlayerPosition, %TreePosition);

		//dbecho(1, "nomdistance = " @ %NomDistance);

		if ((%NomDistance < %Distance) && (BotTree::CheckLOS(%PlayerPosition, %TreePosition,200) == True))
		{
			%Nearest = %x;
			%Distance = %NomDistance;
		}
	}
 
	return %Nearest;
 
}


function BotTree::GetMeToPos(%aiId, %Pos, %FinalPoint)
{

//	%FinalPoint = True; // patch until tree files 100%
// if nearest tree point to us is directly routeable to TreePoint then use it directly
// else route to nearest exit point to tree point.

	%AiPos = GameBase::getPosition(%aiId);

// Nearest point to destination

	%TreePoint = BotTree::FindNearestTreebyPos(%Pos);

	if(BotTree::checklos(%aipos, %pos,200) == True) // Go directly if last point set.
	{
if ($Spoonbot::DebugMode)
		dbecho(1, "(1)" @ %aiid @ " can see target, go direct " );

		if(%FinalPoint)
			BotFuncs::AddAttacker( %aiId, %Pos,5,4);
	}
	else
	{

if ($Spoonbot::DebugMode)
		dbecho(1, "(2)" @ %aiid @ " can see via one point target, go via point " );

// Nearest point to us

		%Nearest = BotTree::FindNearestTreebyId(%aiId);

// if nearest point = nearet point to target go directly to it

		if(%Nearest == %TreePoint)
		{

			%Location = $BotTree::T_Pos[%Nearest];

			BotFuncs::AddAttacker( %aiId, %Location,10,4);

			if(%FinalPoint)
				BotFuncs::AddAttacker( %aiId, %Pos,5,4);

		}

// else route.
		else if($BotTree::T_R[%Nearest, %TreePoint] != "n")
		{
if ($Spoonbot::DebugMode)
			dbecho(1, "(3)" @ %aiid @ " cant see via one point target, go via route" );

			%Location = $BotTree::T_Pos[%Nearest];

			BotFuncs::AddAttacker( %aiId, %Location,5,4); // Very close goal !

			%Treecount = BotThink::getWordCount($BotTree::T_R[%Nearest,%TreePoint]);

			for(%x = 0; %x < %Treecount; %x++)
			{
				%Point = getWord($BotTree::T_R[%Nearest,%TreePoint], %x);

if ($Spoonbot::DebugMode)
					dbecho(1, %aiId @ " next point " @ %Point);

				%Location = $BotTree::T_Pos[%Point];

				BotFuncs::AddAttacker( %aiId, %Location,5,4); // Very close goal !
			}

			%Location = $BotTree::T_Pos[%TreePoint];

			BotFuncs::AddAttacker( %aiId, %Location,5,4);

			if(%FinalPoint)
			{
				BotFuncs::AddAttacker( %aiId, %Pos,5,4);

if ($Spoonbot::DebugMode)
					dbecho(1, %aiId @ "Final Point " @ %Pos);
			}
		}
		else 
		{
if ($Spoonbot::DebugMode)
			dbecho(1,"Cant get " @ %aiid @ " to " @ %pos );
		}
	}
}


function BotTree::Stop(%aiId)
{
	BotFuncs::DeleteAllAttackPointsByPrio(%aiId, 4);
	$BotThink::Definitive_Attackpoint[%aiId] = "";
	$BotThink::ForcedOfftrack[%aiId] = false;
}


function BotTree::StopTeamBots(%aiId)
{

   %myTeam = GameBase::getTeam(%aiId);
   
   for(%i = 0; %i < $AttackerIndexCount; %i++)
      if(GameBase::getTeam($AttackerIndexIds[%i]) == %myteam)
		BotTree::Stop(%id);
}

function BotTree::CalculateRouteDistance(%Start,%Finish)
{
	%StartPos = $BotTree::T_Pos[%Start];
	%FinishPos = $BotTree::T_Pos[%Finish];
	%Route = $BotTree::T_R[%Start,%Finish];
	%HopCount = BotThink::getWordCount(%Route) - 1;


	if(%Route == "n")
		%Distance = 999999;

	else if (%Route == "")
		%Distance = Vector::getDistance(%StartPos,%FinishPos);

	else
	{
		%Distance = Vector::getDistance(%StartPos,$BotTree::T_Pos[getWord(%Route,0)]);

		for(%x = 0; %x < %HopCount; %x++)
			%Distance = %Distance +
					Vector::getDistance($BotTree::T_Pos[getWord(%Route,%x)],$BotTree::T_Pos[getWord(%Route,%x+1)]);

		%Distance = %Distance + Vector::getDistance(%EndPos,$BotTree::T_Pos[getWord(%Route,%HopCount)]);
	}

	//dbecho(1,"Distance between " @ %Start @ " and " @ %Finish @ " via '" @ %Route @ "' = " @ %Distance);

	return %Distance;
}


// Removes tree points if other's can already perform function.

function BotTree::Optimise_Points()
{
	for(%x = 0; %x < $BotTree::T_Count; %x++)
	{
		if($BotTree::T_Pos[%x] != "")
		{
			%LosView = BotTree::GetLosView($BotTree::T_Pos[%x]);

			%WordCount = BotThink::getWordCount(%LosView);
		
			%DeletePoint = False;

			for(%y = 0; ((%y < %WordCount) && (%DeletePoint == False)); %y++)
			{
				%Point = getWord(%LosView,%x);
			
				if(BotTree::CanSeeAllLOS(%Point,%LosView) == True)
				{
					%DeletePoint = True;

if ($Spoonbot::DebugMode)
					dbecho(1,%x @ " redundant, " @ %Point @ " can see " @ %LosView);
	
					$BotTree::T_Pos[%x] = "";
				}
			}
		}
	}
}
