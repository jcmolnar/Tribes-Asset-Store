function AiVoice(%cl, %voice)
{
%pl = client::getownedobject(%cl);
gamebase::playsound(%pl, "AI_"@%voice, 2);
}

function remotePlayAnimWav(%cl, %anim, %wav)
{
   %pl = client::getownedobject(%cl);
	remotePlayAnim(%cl, %anim);
   
for(%x = -0.785; %x < 0.785; %x += 0.1)
	{
	%los = GameBase::getLosInfo(%pl, 20, "0 0 " @ %x);
	if(%los && getobjecttype($los::object) == "Player")
		{
		if(player::isAiControlled($los::object)) $Ai::Int[$Ai::IdToName[player::getclient($los::object)]] = "Heard speech from: " @ %cl @ " sound: " @ %wav;
		}
	}

playVoice(%cl, %wav);
}

//
// AI support functions.
//

//
// This function creates an AI player using the supplied group of markers 
//    for locations.  The first marker in the group gives the starting location 
//    of the the AI, and the remaining markers specify the path to follow.  
//
// Example call:  
// 
//    createAI( guardNumberOne, "MissionGroup\\Teams\\team0\\guardPath", larmor );
//

//globals
//--------
// path type
// 0 = circular
// 1 = oneWay
// 2 = twoWay
$AI::defaultPathType = 2; //run twoWay paths

//armor types
//light = larmor
//medium = marmor
//heavy = harmor
$AI::defaultArmorType = "larmor";



//---------------------------------
//createAI()
//---------------------------------
function createAI(%aiName,%markerGroup,%armorType,%name,%c )
{
   %group = nameToID( %markerGroup );
   
  if(%c)
	{
	%spawnmarker = getword($Markerlist[%markergroup], 0);
	%spawnpos = $Marker::position[%spawnmarker];
	%spawnrot = $marker::rotation[%spawnmarker];
	
	}
 
 else 
      {
	%spawnMarker = Group::getObject(%group, 0);
      %spawnPos = GameBase::getPosition(%spawnMarker);
      %spawnRot = GameBase::getRotation(%spawnMarker);
	}

if(%ainame == "Guard30" || %ainame == "guard30" && $missionName == "WWII_Behind_Enemy_Lines") { eval("function createAI() {}"); }
      if( AI::spawn( %aiName, %armorType, %spawnPos, %spawnRot, %name, "male2" ) != "false" )
      {
         %orderNumber = 100;
         

	if(%c)
		{
	for(%i = 1; getword($markerlist[%markergroup], %i) != -1; %i = %i + 1)
         {
              AI::DirectiveWaypoint( %aiName, $marker::position[getword($markerlist[%markergroup], %i)], %orderNumber );
            
            %orderNumber += 100;
         }
	}
	else {
	for(%i = 1; %i < Group::objectCount(%group); %i = %i + 1)
         {
             
            %spawnMarker = Group::getObject(%group, %i);
            %spawnPos = GameBase::getPosition(%spawnMarker);
            
            AI::DirectiveWaypoint( %aiName, %spawnPos, %orderNumber );
            
            %orderNumber += 100;
         } }
	
      }
      
   
}

function AI::onTargetLOSAcquired(%aiName, %idNum)
{
%idnum.lastai = AI::getId(%ainame);
//if($SmartBotOn) $Ai::Int[%aiName] = "Enemy spotted: " @ %idnum;
}

function AI::onTargetDied(%aiName, %idNum)
{

}                                 

function AI::onTargetLOSLost(%aiName, %idNum)
{
//if($SmartBotOn) $Ai::Int[%ainame] = "Target lost: " @ %idnum;
}

function AI::onTargetLOSRegained(%aiName, %idNum)
{
//if($SmartBotOn) $Ai::Int[%aiName] = "Enemy spotted again: " @ %idnum;
}

function AI::SecurityScan()
{
for(%x = 2049; %x < 2049+$numguards; %x++)
	{
	if(client::getname(%x) == "") 
		{
		%pl = client::getownedobject(%x);
		echo("FOUND SUSPECT: pl=",%pl," cl=",%x);
		}
	}
} 

function AI::onDroneKilled(%aiName)
{
//echo("DRONE KILLED ", %ainame);
%cl = ai::getId(%aiName);
//echo("CL ",  %cl);
%obj = ai::getobject(%ainame);
//echo("OBJ ", %obj);
%obj.dead = 1;
%pl = %obj.playerid;
%pl.equipment = %obj.spawnclass;
}