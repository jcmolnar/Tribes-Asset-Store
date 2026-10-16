//==========================================================
//---------------NEW VOTING SYSTEM!!------------------------
exec(WWII_MapList);

function filtermapname(%str)
{
%str = string::getsubstr(%str, 5, 200);
for(%x = 0; string::getsubstr(%str, %x, 1) != ""; %x++)
	{
	%c = string::getsubstr(%str, %x, 1);
	if(%c == "_") %c = " ";
	%newstr = %newstr @ %c;
	}
if(string::findsubstr(%newstr, " DM") != -1) %newstr = string::getsubstr(%newstr, 0, strlen(%newstr)-2);
return %newstr;
}

function M::Votingopts(%cl, %opt)
{
%x = 0;
if(%opt == "Mapchange")
	{
	%cl.cm = false;
	newmenu(%cl, "\xf7-------Pick Mission Type:-------\xf7", "Pickmaptype", true);
	addoption(%cl, %x++, "Conquest", "Conquest");
	addoption(%cl, %x++, "Server Coop", "Objective");
	addoption(%cl, %x++, "Deathmatch", "Deathmatch");
	return;
	}
else if(%opt == "Maprandom")
	{
	votesystem::startvote(%cl, "change the mission to a random one.",  "Vote::changeMission(); Conquest::SetObjectives(); conquest::missioncomplete(); server::nextmission();");
	return;
	}
else if(%opt == "addpoints")
	{
	newmenu(%cl, "\xf7--------Free Points!--------\xf7", "voteforpoints", true);
	addoption(%cl, %x++, "Add 50", "50");
	addoption(%cl, %x++, "Add 100", "100");
	addoption(%cl, %x++, "Add 200", "200");
	addoption(%cl, %x++, "Add 400", "400");
	addoption(%cl, %x++, "Add 800", "800");
	addoption(%cl, %x++, "Add 1600", "1600");
	return;
	}
else if(%opt == "voteyes")
	{
	if(%cl.voted || $Vote::CurVoteStatus != "voting") return; // PORT FIX: was a message with no return
	$Vote::CurVotesYes++; 
	%cl.voted = true;
	return;
	}
else if(%opt == "voteno")
	{
	if(%cl.voted || $Vote::CurVoteStatus != "voting") return; // PORT FIX: was a message with no return
	$Vote::CurVotesNo++; 
	%cl.voted = true;
	return;
	}
else if(%opt == "forcevotepass")
	{
	if(%cl.adminLVL < 3 || $Vote::CurVoteStatus != "voting") { WWIIPort::deny(%cl, "forcevotepass"); return; } // PORT FIX
	$Vote::CurVoteStatus = "passed"; 
	votesystem::votepassed();
	messageall(1, client::getname(%cl) @ " forced the vote to pass.");
	return;
	}
else if(%opt == "forcevotefail")
	{
	if(%cl.adminLVL < 3 || $Vote::CurVoteStatus != "voting") { WWIIPort::deny(%cl, "forcevotefail"); return; } // PORT FIX
	$Vote::CurVoteStatus = "failed"; 
	votesystem::votefailed();
	messageall(1, client::getname(%cl) @ " forced the vote to fail.");
	return;
	}
game::menurequest(%cl);
}

function m::voteforpoints(%cl, %opt)
{
if(%opt >= 400) { Centerprint(%cl, "<jc><f2>Sorry, you want too much!",3, SORRY); return; }
votesystem::startvote(%cl, "add " @ %opt @ " points to team scores.",  "$WWII::TeamPoints[Allied] += " @ %opt @ "; if($game::Missiontype != \"Objective\") $WWII::TeamPoints[Axis] += " @ %opt @ ";");
	

}

function M::pickmaptype(%cl, %opt)
{
%x = 0;
echo(PICKMAPTYPE);
echo(%opt);
if(%opt == "Conquest") 
	{
	newmenu(%cl, "\x87----------Pick Mission:----------\x87", "pickmap");
	for(%i = 0; %i < getnumwords($WWII::MapList["Conquest"]); %i++)
		{
		addoption(%cl, %x++, filtermapname(getword($WWII::MapList["Conquest"], %i)), getword($WWII::MapList["Conquest"], %i) @ " " @ %cl @ " Conquest");
		if(%i == 6) break;
		}
	if(getnumwords($WWII::MapList["Conquest"]) > 6) addoption(%cl, %x++, "More...", "more " @ %cl);
	return;
	}
else if(%opt == "Conquest2") 
	{
	newmenu(%cl, "\x87----------Pick Mission:----------\x87", "pickmap");
	for(%i = 7; %i < getnumwords($WWII::MapList["Conquest"]); %i++)
		{
		addoption(%cl, %x++, filtermapname(getword($WWII::MapList["Conquest"], %i)), getword($WWII::MapList["Conquest"], %i) @ " " @ %cl @ " Conquest");
		if(%i == 13) break;
		}
	//if(getnumwords($WWII::MapList["Conquest"]) > 13) addoption(%cl, %x++, "More...", "more " @ %cl);
	return;
	}
else if(%opt == "Objective")
	{
	newmenu(%cl, "\x87----------Pick Mission:----------\x87", "pickmap");
	for(%i = 0; %i < getnumwords($WWII::MapList["Objective"]); %i++)
		{
		addoption(%cl, %x++, filtermapname(getword($WWII::MapList["Objective"], %i)), getword($WWII::MapList["Objective"], %i) @ " " @ %cl @ " Objective");
		if(%i == 6) break;
		}
	return;
	}
else if(%opt == "Deathmatch")
	{
	newmenu(%cl, "\x87----------Pick Mission:----------\x87", "pickmap");
	for(%i = 0; %i < getnumwords($WWII::MapList["Deathmatch"]); %i++)
		{
		addoption(%cl, %x++, filtermapname(getword($WWII::MapList["Deathmatch"], %i)), getword($WWII::MapList["Deathmatch"], %i) @ " " @ %cl @ " Deathmatch");
		if(%i == 6) break;
		}
	//if(getnumwords($WWII::MapList["Objective"]) > 6) addoption(%cl, %x++, "More...", "more " @ %cl);
	return;
	}


game::menurequest(%cl);
}

function m::pickmap(%cl, %opt)
{

%mapname = getword(%opt, 0);
%type = getword(%opt, 2);
if(%mapname == "more") { M::pickmaptype(%cl, "Conquest2"); return; }
%changer = getword(%opt, 1);

if(%cl.cm) menu::confirmclient(%cl, " admincm(" @ %changer @ "," @ %mapname @ "," @ %type @ ");");

else { votesystem::startvote(%changer, "change the mission to " @ filtermapname(%mapname) @ "(" @ %type @ ")",  "Vote::changeMission(); Conquest::SetObjectives(); conquest::missioncomplete(); server::loadmission(" @ %mapname @ ");");

}}

function admincm(%changer, %mapname, %type)
{
messageall(1, client::getname(%changer)  @ " changed the mission to " @ filtermapname(%mapname) @ "(" @ %type @ ")"); 
Vote::changeMission(); 
server::loadmission(%mapname);
}

//==============================================VOTE SYSTEM=======================================
//------------------------------------------------------------------------------------------------

function votesystem::startvote(%voter, %message, %command)
{
if($Vote::CurVoteStatus == "voting") { client::sendmessage(%voter, 0, "Another vote is in progress."); return; }
else if($Vote::VoteEnabled) { client::sendmessage(%voter, 0, "You can vote only 20 seconds after the previous vote."); return; }
dbecho(1, "REPORT: Vote start. cl id = " @ %voter @ ", command = " @ %command);
$Vote::CurVotesYes = 0;
$Vote::CurVotesYes++; 
%voter.voted = true;
$Vote::CurVotesNo = 0;
$Vote::CurVoteStatus = "voting";
$Vote::CurVoteCommand = %command;
$Vote::CurVoteClient = %voter;
$Vote::VoteEnabled = true;
$vote::CurVoteDesc = %message;
bottomprintall("<f1><jc>" @ client::getname(%voter) @ " started a vote to " @ %message, 10,VOTE);
schedule("votesystem::countvotes();", 30);
}

function votesystem::countvotes()
{
if($Vote::CurVoteStatus == "") return;
%totalscore = $Vote::CurVotesYes - $Vote::CurVotesNo;

if(%totalscore == 0) 
	{ 
	$Vote::CurVoteStatus = "teko";
	messageall(0, "The vote to " @ $Vote::CurVoteDesc @ " did not pass. For = " @ $Vote::CurVotesYes @ ". Against = " @ $Vote::CurVotesNo @ "."); 
	Votesystem::VoteFailed();
	}	
else if(%totalscore < 0) 
	{ 
	$Vote::CurVoteStatus = "failed";
	messageall(0, "The vote to " @ $Vote::CurVoteDesc @ " failed. For = " @ $Vote::CurVotesYes @ ". Against = " @ $Vote::CurVotesNo @ "."); 
	Votesystem::VoteFailed();
	}
else    { 
	$Vote::CurVoteStatus = "passed";
	messageall(0, "The vote to " @ $Vote::CurVoteDesc @ " passed. For = " @ $Vote::CurVotesYes @ ". Against = " @ $Vote::CurVotesNo @ "."); 
	Votesystem::VotePassed();
	}

for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
        {
            %cl.voted = false;
        }
}

function votesystem::votefailed()
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
        {
            %cl.voted = false;
        }
dbecho(1, "REPORT: Vote fail. cl id = " @ $Vote::CurVoteClient @ ", command = " @ $vote::curvotecommand);
deletevariables("Vote::CurVote*");
schedule("$Vote::VoteEnabled = false;", 20);
}

function votesystem::votepassed()
{
for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
        {
            %cl.voted = false;
        }
dbecho(1, "REPORT: Vote pass. cl id = " @ $Vote::CurVoteClient @ ", command = " @ $vote::curvotecommand);
eval($Vote::CurVoteCommand);
deletevariables("Vote::CurVote*");
schedule("$Vote::VoteEnabled = false;", 20);
}


function remotevoteyes(%manager)
{
if($WWII::TraceClients) %manager.remotecall++;	
if($Vote::CurVoteStatus == "voting" && !%manager.voted) 
	{
	$Vote::CurVotesYes++; 
	%manager.voted = true;
	}
}

function remotevoteno(%manager)
{
if($WWII::TraceClients) %manager.remotecall++;	
if($Vote::CurVoteStatus == "voting" && !%manager.voted) 
	{
	$Vote::CurVotesNo++;
	%manager.voted = true;
	}
}

