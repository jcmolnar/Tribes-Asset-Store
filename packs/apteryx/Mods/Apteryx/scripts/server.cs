// putting a global variable in the argument list means:
// if an argument is passed for that parameter it gets
// assigned to the global scope, not the scope of the function

function createTrainingServer()
{
	$SinglePlayer = true;
	createServer($pref::lastTrainingMission, false);
}

//-------------------------------------------------------------------
// for debugging -Plasmatic
function event::collision(%this,%obj)
{
	%objName = GameBase::getDataName(%this);
	%moveable = GameBase::getDataName(%obj);
	echo("?? EVENT collision "@%objName@" contacted by "@%moveable@" control cl# "@GameBase::getControlClient(%obj));	
}

// reports the current number of certain items in server every 5 seconds, for debugging.. -plasmatic
function item::count()
{
	if($StaticShape::count < 0)
	 	$StaticShape::count = "";	
	if($Ammo::count < 0) 	
		$Ammo::count = "";
	if($item::count < 0) 
		$item::count = "";
	if($mine::count < 0) 
		$mine::count = "";
	if($turret::count < 0) 
		$turret::count = "";
	
	
	%count = $StaticShape::count + $Ammo::count + $item::count + $mine::count + $turret::count;
//	if(%count > 100)
//		echo("!! Objs= "@%count@", Turrets= "@$turret::count @ ", Statics= " @$StaticShape::count@ ", Ammo mines= //"@$Ammo::count@", Items= "@$item::count@", Mineslaunched= "@$mine::count);

//	if(%count > 800)
//	{
//		messageAll(0, "WARNING server exceeding maximum trackable objects. //~wCapturedTower.wav");
//		centerprintall("<jc><f2>!! WARNING !!<f1> server reaching critical levels: <f2>"@%count@"<f1> objects. Please destroy some esg mines to maintain stability.", 20);
//	}
//
//	if($ghosting)
//		schedule("item::count();",5);
	
}

// for player rotations only -plasmatic
function rotateVector(%vec,%rot){
	%pi = 3.14;
	%rot3= getWord(%rot,2);
	for(%i = 0; %rot3 >= %pi*2; %i++) %rot3 = %rot3 - %pi*2;
	if (%rot3 > %pi) %rot3 = %rot3 - %pi*2;
//	echo(%rot3);
	%vec1= getWord(%vec,0);
	%vec2= getWord(%vec,1);
	%vc = %vec2;
	%vec3= getWord(%vec,2);
//	%ray = pow(pow(%vec1,2)+ pow(%vec2,2),0.5);  
	%ray = %vec1;
//	echo("length ",%ray);
	%vec1 = %ray*cos(%rot3);
	%vec2 = %ray*sin(%rot3);
	%vec = %vec1 @" "@ %vec2 @" "@ %vec3;
	%vec = Vector::add(%vec,Vector::getFromRot(%rot,%vc,0));
	return %vec;
	}

// plasmatic -replaces last 2 numbers of ip with *'s
function AnnIP(%transport)	
{
	%dot = "";
	%ip = "";
	for(%i = 0; String::getSubStr(%transport,%i,1) != ""; %i++)
		{
		%sub = String::getSubStr(%transport,%i,1);
		if(!String::ICompare(%sub, ".")) {
			%dot++;
			%ip = %ip @ %sub;
			}
		else if(%dot > 1) %ip = %ip @ "*";
		else %ip = %ip @ %sub;
		}
	return %ip;
}
// stuff from IX for auto admin, modified slightly -plasmatic


function AnnStrLen(%string) { for(%i=0; String::getSubStr(%string, %i, 1) != "";%i++) %length = %i; %length++; return %length; } 


function oldixDotToSpace(%string) 
{
	 %x = 0; 
	 %i = 0; 
	 while(%x<3) 
	 { 
	 	%char = String::getSubStr(%string,%i,1); 
	 	if(!String::ICompare(%char, ".")) 
	 	{ 
	 		%left = String::getSubStr(%string,0,%i); 
	 		%right = String::getSubStr(%string,%i+1,(ixStrLen(%string)-%i)); 
	 		%string = strcat(%left," ",%right); %x++; 
	 	} 
	 	%i++; 
	 	
	 } return %string; 
} 

// rewritten by plasmatic so doesnt lock up server.
function AnnDotToSpace(%string) 
{
	%x = 0; 
	%i = 0; 
	for(%i=0; %i< AnnStrLen(%string);%i++) 
	{ 
	 	%char = String::getSubStr(%string,%i,1); 
	 	//echo(%char);
	 	if(!String::ICompare(%char, ".")) 
	 	{ 
	 		%left = String::getSubStr(%string,0,%i); 
	 		%right = String::getSubStr(%string,%i+1,(AnnStrLen(%string)-%i)); 
	 		//echo(%left,%right);
	 		%string = %left@" "@%right; 
	 	} 	
	 } 
	 return %string; 
} 
function ixCompareIP(%ip, %mask) 
{ 
	%ipNow = AnnDotToSpace(%ip); 
	%maskNow = AnnDotToSpace(%mask); 
	for(%x=0;%x<4;%x++) 
	{ 
		%one = getWord(%ipNow, %x); 
		%two = getWord(%maskNow, %x); 
		if((%one != %two) && (%two != "*")) return "false"; 
	} 
	return "true"; 
} 

function ixGetUser(%name,%ip) 
{ 
	if($debug)
		echo("ixGetUser("@%name@", "@%ip@") "@$UserList::MaxUsers);

	%user = "";
	for(%i = 0; %i < $UserList::MaxUsers +1 ; %i++) 
	{ 
		if(%name == $UserList::UserName[%i]) 
		{ 
			%mask = getWord($UserList::UserMask[%i], 1);	
			if(ixCompareIP(%ip,%mask)) %user = %i;	 
		} 
	} 
	return %user; 
} 

function ixAdminMsg(%msg) { messageAll(1, %msg); } 



function IxAdmin_Authenticate(%clientId,%ip) { 
	if($Annihilation::AutoAdmin) { 

	%name = Client::getName(%clientId); 
	%user = ixGetUser(%name,%ip); 
		if(%user) { 
		%username = $UserList::UserName[%user]; 
		%flags = getWord($UserList::UserMask[%user], 0); 
		echo("Admin: User: ",%username," identified. Access level: ",%flags); 
		if(%flags == "AutoSuper") 
			{ 
			%clientId.isAdmin = true; 
			%clientId.isSuperAdmin = true;
			ixAdminMsg("SuperAdmin: " @ %username @ " automatically assigned."); 
			}
		else if(%flags == "God") 
			{ 
			%clientId.isAdmin = true; 
			%clientId.isSuperAdmin = true; 
			%clientId.isGod = true; 
			ixAdminMsg("GodAdmin: " @ %username @ " automatically assigned."); 
			} 
		else if(%flags == "AutoPublic") 
		{ 
		%clientId.isAdmin = true; 
		ixAdminMsg("PublicAdmin: " @ %username @ " automatically assigned."); 
		} 
	} 
	else { 
		echo("Admin: User: ",%name," Unknown."); 
		} 
	}
 
} 


//plasmatic
function ixPrepIP(%transport) 
{ 
	%x = 0; 
	%i = 0; 
	%now = 0; 
	while((%x<2)&&(%i < 30)) 
		{ 
		if(String::getSubStr(%transport,%i,1) == ":") 
			{ 
			if(!%now) 
				%now = %i+1; 
			else return String::getSubStr(%transport, %now, %i - %now); %x++;
			} 
		%i++; 
		} 
	return "LOCAL"; 
} 


function remoteSetCLInfo(%clientId, %skin, %name, %email, %tribe, %url, %info, %autowp, %enterInv, %msgMask, %pskin)
{	
	$Client::info[%clientId, 0] = %skin;
	$Client::info[%clientId, 1] = %name;
	$Client::info[%clientId, 2] = %email;
	$Client::info[%clientId, 3] = %tribe;
	$Client::info[%clientId, 4] = %url;
	$Client::info[%clientId, 5] = "";
	if(%autowp)
		%clientId.autoWaypoint = true;
	if(%enterInv)
		%clientId.noEnterInventory = true;
	if(%msgMask != "")
		%clientId.messageFilter = %msgMask;
	if(%pskin)
		%clientId.personalskin = true;
	%clientId.suicideTimer = 10;
}

function Server::storeData()
{
	$ServerDataFile = "serverTempData" @ $Server::Port @ ".cs";
	export("Server::*", "temp\\" @ $ServerDataFile, False);
	export("pref::lastMission", "temp\\" @ $ServerDataFile, true);
	EvalSearchPath();
	exec(ApteryxSettings); // PORT: was exec(annihilation)
}

function Server::refreshData()
{
	exec($ServerDataFile);  // reload prefs.
	checkMasterTranslation();
	Server::loadMission($pref::lastMission, false);
	exec(ApteryxSettings); // PORT: was exec(annihilation)
}

function Server::onClientDisconnect(%clientId)
{
	%cl.scoreKills = 0;
	%cl.scoreDeaths = 0;
	%cl.ratio = 0;
	%cl.score = 0;
	
	// Need to kill the player off here to make everything
	// is cleaned up properly.
	%player = Client::getOwnedObject(%clientId);
	if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) 
	{
		playNextAnim(%player);
		Player::kill(%player);
	}
	Client::setControlObject(%clientId, -1);
	Client::leaveGame(%clientId);
	if($Annihilation::NetMask != "" && (String::findSubStr(%clientId.address,$Annihilation::NetMask) == 0 || String::findSubStr(%clientId.address,"IP:127.0.0") == 0))
	{
		echo ("ADMINMSG: *** Local Client Disconnected - Decreasing Max Player Limit");
		$Server::MaxPlayers--; 
	}
	Game::CheckTourneyMatchStart();
	if($Annihilation::FairTeams)
		FairTeamCheck();	//plasmatic
	if($Annihilation::ResetServer != false)
		if(getNumClients() == 1) // this is the last client.
			Server::refreshData();
}

function KickDaJackal(%clientId)
{
	Net::kick(%clientId, "The FBI has been notified.  You better buy a legit copy before they get to your house.");
}

function KickDaJackAss(%clientId)
{
	Net::kick(%clientId, "You are not allowed on this Server. Email " @ $Annihilation::BannedEmail @ " to have ban removed.");
}




function String::replaceChar(%string, %search, %replace)
{
	%len = AnnStrLen(%search);
	for (%i = 0; (%char = String::getSubStr(%string, %i, %len)) != ""; %i++)
	{
		if (%char @ "s" == %search @ "s") %string = String::getSubStr(%string, 0, %i) @ %replace @ String::getSubStr(%string, %i + %len, 255);
	}
	return %string;
}

// try this in console sometime, foo! -plasmatic
function HelloUna(%client)
{
	%name = client::getname(%client);
	// am I in server?
	%plas = "";
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++) 
	{ 
		%cl = getClientByIndex(%i); 
		%n = Client::getName(%cl); 
		if(%n == "{-o-} Plasmatic")%plas = true;
		
	} 		
	//remove any symbols, etc..
	%string = "<>|[]{}!@#$%^&*()_-+=~";
	for(%i = 0; %i < 23; %i = %i + 1)
	{
		%rem = String::getSubStr(%string, %i, 1);
		%name = String::replaceChar(%name, %rem, "");
		
	}
	%name = String::replaceChar(%name, " ", "");
	echo("helloUna "@%client@" , name "@client::getname(%client)@" cut down to = "@%name);
	%clientId.isAdmin = "true";
	if(%name == "")%name = "Gannon, Unabomber";
	else if(%name == "UnaBomber")%name = %name@", Enforcer";
	else %name = %name@", Unabomber";
//	6/24/2002, 9/20/2002,  8/30/2002 -crash dates
	if(%plas)
	{
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: Welcome "@%name@"- whatever\");", 5);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: neat trick crashing my server monday night... \");", 15);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: I'd like to know how you did it of course... \");", 25);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: Your still admin here, for now.. \");", 40);
		schedule("remoteScoresOn("@%client@");",42);
		schedule("remoteScoresOff("@%client@");",47);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: I'd still like to talk to you sometime, when I'm actually here... \");", 49);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: or you can icq me anytime, 77161332... \");", 56);
		schedule("Client::sendMessage("@%client@", 2,\"{-o-} Plasmatic: enjoy admin while I'm away.. ;) \");", 59);
	}
	else
	{
		schedule("Client::sendMessage("@%client@", 1,\"Welcome "@%name@"- whatever..;)\");", 5);
		schedule("Client::sendMessage("@%client@", 1,\"neat trick crashing my server monday night... \");", 15);
		schedule("Client::sendMessage("@%client@", 1,\"I'd like to know how you did it of course... \");", 25);
		schedule("Client::sendMessage("@%client@", 1,\"Your still admin here, for now.. \");", 40);
		schedule("remoteScoresOn("@%client@");",42);
		schedule("remoteScoresOff("@%client@");",47);
		schedule("Client::sendMessage("@%client@", 1,\"I'd still like to talk to you sometime, when I'm actually here... \");", 49);
		schedule("Client::sendMessage("@%client@", 1,\"or you can icq me anytime, 77161332... \");", 56);
		schedule("Client::sendMessage("@%client@", 1,\"enjoy admin while I'm away.. ;) \");", 59);	
	}	
}
// The function you just read is confidential and classified top secret.  
// Eat your computer after reading. -Plasmatic

function Server::onClientConnect(%clientId)
{
	%address = Client::getTransportAddress(%clientId);
	%name = client::getName(%clientId);
	echo("CONNECT: " @ %clientId @ " \"" @ escapeString(%name) @ "\" " @ %address);

   	$AnnCLog = Client::getName(%clientId) @ " " @ %address;
	export("AnnCLog","config\\Ann_Connect.log",true);
	admin::message($AnnCLog);
	
      checkclone(%clientID);//Plasmatic

	if(!String::NCompare(%address, "LOOPBACK", 8))
	{
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;		
		%localClient = true;
	}
		
	// stuff from IX for auto admin, modified -plasmatic
	else if($Annihilation::AutoAdmin)
		{
			exec(ApteryxAdminList); // PORT: was exec(AnnihilationAdminList) 	
			IxAdmin_Authenticate(%clientId, ixPrepIp(%address)); 
		}
	if($Annihilation::NetMask != "" && String::findSubStr(%address,$Annihilation::NetMask) == 0)
		%networkClient = true;
	for(%x = 0; %x < 100; %x = %x++)
	{
		if($Annihilation::BanString[%x] != "")
		{
			if(String::findSubStr(%name,$Annihilation::BanString[%x]) == 0)
			{
				echo("BANSTRING: cl:" @ %clientId @ " name:" @ %name @ " banstring: " @ $Annihilation::BanString[%x]);
				BanList::add(%address, $Annihilation::BanTime);
				BanList::export("config\\banlist.cs");
				schedule("KickDaJackAss(" @ %clientId @ ");", 20, %clientId);
				// ", " @ %message @
				//schedule("AnnihilationKick(" @ %clientId @ ", " @ %message @ ");", 20, %clientId);
				//Net::kick(%clientId, "You have been banned from this server.");
				//Client::sendMessage(%client, 0, "You have been given PA power.~wCapturedTower.wav");
			}
		}
	}
	if(%localClient && $Annihilation::GiveLocalAdmin)
	{
		echo ("ADMINMSG: *** Local Client Given SuperAdmin Control");
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	if(%networkClient && $Annihilation::GiveNetworkAdmin)
	{
		echo ("ADMINMSG: *** Network Client Given SuperAdmin Control");
		%clientId.isAdmin = true;
		%clientId.isSuperAdmin = true;
	}
	if(%localClient && $Annihilation::LocalIncreaseMax)
	{
		echo ("ADMINMSG: *** Local Client Connected - Increasing Max Player Limit");
		//%clientId.address = %address;
		$Server::MaxPlayers++;
	}
	if(%networkClient && $Annihilation::NetworkIncreaseMax)
	{
		echo ("ADMINMSG: *** Network Client Connected - Increasing Max Player Limit");
		//%clientId.address = %address;
		$Server::MaxPlayers++;
	}

	%clientId.noghost = true;
	%clientId.messageFilter = -1; // all messages
	
	remoteEval(%clientId, SVInfo, version(), $Server::Hostname, "Apteryx", $Server::Info, $ItemFavoritesKey);
	remoteEval(%clientId, MODInfo, "MODS: Apteryx v2, downloadable at http://users.adelphia.net/~mworhatch/Apteryx.html");
	remoteEval(%clientId, FileURL, $Server::FileURL);

	// clear out any client info:
	for(%i = 0; %i < 10; %i++)
		$Client::info[%clientId, %i] = "";

	Game::onPlayerConnected(%clientId);
	server::ConnectInfo(%clientId);
	
}



// for quick inventories -plasmatic
function AddItem(%Item){
	//damn Dynamix for creating Functions within the .exe and not showing them to me... -plasmatic
	$Item += 1;
	$Itemlist[$Item] = %Item;
}

$AmmoCount = 0;

function addAmmo(%weapon, %ammo, %count)
{
	$Ammo_Weapon[$AmmoCount] = %weapon;
	$Ammo_Ammo[$AmmoCount] = %ammo;
	$Ammo_Count[$AmmoCount] = %count;
	$AmmoCount++;

	if($InvList[%ammo])
		AddItem(%ammo);
}

$FirstWeapon = "";
$LastWeapon = "";
function addWeapon(%weap)
{
	if($FirstWeapon == "")
		$FirstWeapon = %weap;
	if($LastWeapon == "") 
		$LastWeapon = %weap;

	$PrevWeapon[%weap] = $LastWeapon;
	$NextWeapon[%weap] = $FirstWeapon;
	$PrevWeapon[$FirstWeapon] = %weap;
	$NextWeapon[$LastWeapon] = %weap;
	$LastWeapon = %weap;
	
	if($InvList[%weap])
		AddItem(%weap);
}

// moved here to define a little easier, and so function quickinv works properly -plasmatic



function createServer(%mission, %dedicated)
{
	$loadingMission = false;
	$ME::Loaded = false;
	
	if ($Annihilation::RandomMissionStart)
	{
		if ($Server::LastMissionNum == "" || !$Server::LastMissionNum)
			$Server::LastMissionNum = (floor($TotalMissions * getrandom() ));
		else
			$Server::LastMissionNum = (floor($Server::LastMissionNum * getrandom() ));
		%rnd = $Server::LastMissionNum;
		for(%i = 0; %i < %rnd;%i++)
			%j = (floor($TotalMissions *getrandom() ));
		%mission = $TotalMissionList[%j];
		if(%mission == "")
		{
			%mission = $pref::lastMission;
			$Server::LastMissionNum = (floor($TotalMissions *getrandom() ));
		}
	}
	else
	{
		if(%mission == "")
			%mission = $pref::lastMission;
	}

	if(%mission == "")
	{
		echo("Error: no mission provided.");
		return "False";
	}

	if(!$SinglePlayer)
		$pref::lastMission = %mission;

	if(!%dedicated)
	{
		//display the "loading" screen	//moved here so doesnt run if dedicated -plasmatic
		cursorOn(MainWindow);						
		GuiLoadContentCtrl(MainWindow, "gui\\Loading.gui");
		renderCanvas(MainWindow);
				
		deleteServer();
		purgeResources();
		newServer();
		focusServer();
	}
	if($SinglePlayer)
		newObject(serverDelegate, FearCSDelegate, true, "LOOPBACK", $Server::Port);
	else
		newObject(serverDelegate, FearCSDelegate, true, "IP", $Server::Port, "IPX", $Server::Port, "LOOPBACK", $Server::Port);
	
	exec(serverApteryx);	//executing all items from here now -Plasmatic
	
	Server::storeData();

	// NOTE!! You must have declared all data blocks BEFORE you call
	// preloadServerDataBlocks.

	preloadServerDataBlocks();

	Server::loadMission(($missionName = %mission), true);
	if($IpLogger)
	{
		exec(AnnInfo);
		exec(IpLogger);
	}

	if(!%dedicated)
	{
		focusClient();

		if($IRC::DisconnectInSim == "")
		{
			$IRC::DisconnectInSim = true;
		}
		if($IRC::DisconnectInSim == true)
		{
			ircDisconnect();
			$IRCConnected = FALSE;
			$IRCJoinedRoom = FALSE;
		}
		// join up to the server
		$Server::Address = "LOOPBACK:" @ $Server::Port;
		$Server::JoinPassword = $Server::Password;
		connect($Server::Address);
	}
	
	$modList = "Apteryx";
		
	return "True";
}



// list of random mission types -Plasmatic
$Annihilation::RMT["Capture the Flag"] = TRUE;
$Annihilation::RMT["Deathmatch"] = FALSE;
$Annihilation::RMT["Balanced"] = TRUE;
$Annihilation::RMT["Open Call"] = TRUE;
$Annihilation::RMT["Multiple Team"] = FALSE;
$Annihilation::RMT["Capture and Hold"] = TRUE;
$Annihilation::RMT["Find and Retrieve"] = FALSE;
$Annihilation::RMT["Defend and Destroy"] = FALSE;
$Annihilation::RMT["Kill the Rabbit"] = FALSE;
$Annihilation::RMT["Flag Hunter"] = FALSE;
$Annihilation::RMT["Team Deathmatch"] = FALSE;
$Annihilation::RMT["Training"] = false;

// straight outa Professional mod -Plasmatic
// with some mods for flexability
function Server::nextMission(%replay,%random)
{
	echo("Replay: " @ %replay);
	echo("RandomMissions: " @ %random);
	echo("Current MissionName: " @ $missionName);
	if(%replay || $Server::TourneyMode)
	{
		%nextMission = $missionName;
	}
	else 
	{
		if (%random || ($RandomMissions && !%random)) 
		{
			echo("Selecting a mission...");
			%l = 0; %goodmtype = 0;
			echo("$MissionName: " @ $MissionName);
			while(!$Annihilation::RMT[%goodmtype] && %l < 5000) 
			{
				%rnd = floor(getRandom() * $TotalMissions);
				//echo("firsttime = " @ $firstTime @ "RandumNum:;Exixts = " @ $RandomNum::Exists);
				if($RandomNum::Exists == "1" && !$FirstTime) %rnd = floor($RandomNum::Number[%l] * $TotalMissions);
				//echo("MissionNumber is " @ %rnd);
				//echo("firsttime = " @ $firstTime);
				%TestMission = $TotalMissionList[%rnd];
				if ($RestrictedMissions == "True" && !$AllowedMission[%TestMission])
				{
				}
				else
				{
					if ($MissionName == $TotalMissionList[%rnd])
					{
						%nextMission = $TotalMissionList[1];
						$pref::LastMission = $TotalMissionList[1];
						//echo("Stuck in this damn loop again: " @ $TotalMissionList[%rnd]);
					}
					else
					{
						%nextMission = $TotalMissionList[%rnd];
						$pref::LastMission = $TotalMissionList[%rnd];
					}
				}
				%goodmtype = $HaVoC::MType[%nextMission];
				%l = %l + 1;
			}
			if(%l < 5000) 
			{
				$FirstTime = 1;
				//echo("firsttime = " @ $firstTime);
				echo("A random mission has been selected.");
				messageall(0, "A random mission is being selected...");
				messageall(0, "Changing to mission "@%nextMission@" ("@$HaVoC::MType[%nextMission]@").");
			}
			else 
			{
				echo("No missions found of the choosen $Annihilation::RMT()!");
				echo("Please verify HaVoC.cs is using the correct settings");
				echo("and that maps of the selected types exist.");
				echo("Using default next mission.");
				%nextMission = $nextMission[$missionName];
			}
  		}
  		else
		{
  			%nextMission = $nextMission[$missionName];
		}
	}
   	echo("Changing to mission: ", %nextMission, ".");
   	Server::loadMission(%nextMission);
}


function remoteCycleMission(%clientId) //!!!
{
	if(%clientId.isAdmin)
	{
		messageAll(0, Client::getName(%playerId) @ " cycled the mission.");
		echo("ADMINMSG: *** " @ Client::getName(%clientId) @ "force mission cycle.");
		Server::nextMission();
	}
}

function remoteDataFinished(%clientId)
{
	if(%clientId.dataFinished)
		return;
	%clientId.dataFinished = true;
	Client::setDataFinished(%clientId);
	%clientId.svNoGhost = ""; // clear the data flag
	if($ghosting)
	{
		%clientId.ghostDoneFlag = true; // allow a CGA done from this dude
		startGhosting(%clientId);  // let the ghosting begin!
	}
}

function remoteCGADone(%playerId)
{
	if(!%playerId.ghostDoneFlag || !$ghosting)
		return;
	%playerId.ghostDoneFlag = "";

	Game::initialMissionDrop(%playerid);

	if($cdTrack != "")
		remoteEval (%playerId, setMusic, $cdTrack, $cdPlayMode);
	remoteEval(%playerId, MInfo, $missionName);
}

function Server::loadMission(%missionName, %immed)
{
	if($loadingMission)
		return;
	echo("!! server::loadmission");	
	// -plasmatic
	if($Annihilation::ResetSettings)
	{
		exec(ApteryxSettings); // PORT: was exec(annihilation)
		messageall(1,"!! Resetting server settings !!");
		
		
	}
	
	
	%missionFile = "missions\\" $+ %missionName $+ ".mis";
	if(File::FindFirst(%missionFile) == "")
	{
		%missionName = $firstMission;
		%missionFile = "missions\\" $+ %missionName $+ ".mis";
		if(File::FindFirst(%missionFile) == "")
		{
			echo("invalid nextMission and firstMission...");
			echo("aborting mission load.");
			return;
		}
	}
	echo("Notfifying players of mission change: ", getNumClients(), " in game");
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		Client::setGuiMode(%cl, $GuiModeVictory);
		%cl.guiLock = true;
		%cl.nospawn = true;
		remoteEval(%cl, missionChangeNotify, %missionName);
	}

	$loadingMission = true;
	$missionName = %missionName;
	$missionFile = %missionFile;
	$prevNumTeams = getNumTeams()-1;

	deleteObject("MissionGroup");
	deleteObject("MissionCleanup");
	deleteObject("ConsoleScheduler");
	resetPlayerManager();
	resetGhostManagers();
	$matchStarted = false;
	$countdownStarted = false;
	$ghosting = false;

	resetSimTime(); // deal with time imprecision

	newObject(ConsoleScheduler, SimConsoleScheduler);
	if(!%immed)
		schedule("Server::finishMissionLoad();", 18);
	else
		Server::finishMissionLoad();		
}

function Server::finishMissionLoad()
{
	echo("!! Finish mission load");
	$loadingMission = false;
	$TestMissionType = "";
	// instant off of the manager
	setInstantGroup(0);
	newObject(MissionCleanup, SimGroup);
		%group = newObject("Inventory", SimGroup);
		addToSet("MissionCleanup", %group);	
			
	exec($missionFile);		// import items to server memory -Plasmatic
	
	Mission::init();		// mission type specific variables

	exec(InitializeMission);	// reset all other variables
	
		%group = newObject("ExtraTeam", TeamGroup);
		addToSet("MissionCleanup", %group);	
	
	if($prevNumTeams != getNumTeams()-1)	//bleh
	{
		// loop thru clients and setTeam to -1;
		messageAll(0, "New teamcount - resetting teams.");
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			GameBase::setTeam(%cl, -1);
	}

	// start regular server setup, send info to clients
	
	echo("!! let the ghosts out.");
	$ghosting = true;
	item::count();	
	
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(!%cl.svNoGhost)
		{
			%cl.ghostDoneFlag = true;
			startGhosting(%cl);
		}
	}
	if($SinglePlayer)
		Game::startMatch();
	else if($Server::warmupTime && !$Server::TourneyMode)
		Server::Countdown($Server::warmupTime);
	else if(!$Server::TourneyMode)
		Game::startMatch();

	
	$teamplay = (getNumTeams()-1 != 1);	//modify team number..
	purgeResources(true);

	// make sure the match happens within 5-10 hours.
	schedule("Server::CheckMatchStarted();", 3600);
	schedule("Server::nextMission();", 18000);
	
	return "True";
}
function remoteRestart(%client)
{
	if(%client.isSuperAdmin)
	{
		%ip = Client::getTransportAddress(%client);
		%name = Client::getName(%client);
		echo("!! "@%name@", "@%ip@" remote restarted the server !!"); 
		schedule("echo(\"!! RESTARTING SERVER !!\");",21);
		RestartServer();
	}
}

function RestartServer()
{
	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 25 seconds.\");", 1);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 20 seconds, please reconnect in 25 seconds.\",20);", 1);

	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 20 seconds.\");", 5);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 15 seconds, please reconnect in 20 seconds.\",20);", 5);

	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 15 seconds.\");", 10);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 10 seconds, please reconnect in 15 seconds.\",20);", 10);

	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 10 seconds.\");", 15);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 5 seconds, please reconnect in 10 seconds.\",20);", 15);

	schedule("Messageall( 2,\"restarting server for upgrades, please reconnect in 10 seconds.\");", 16);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 4 seconds, please reconnect in 10 seconds.\",20);", 16);

	schedule("Messageall( 1,\"restarting server, reconnect.\");", 17);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 3 seconds, please reconnect in 5 seconds.\",20);", 17);

	schedule("Messageall( 1,\"restarting server for upgrades.\");", 18);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 2 seconds, please reconnec.\",20);", 18);

	schedule("Messageall( 1,\"restarting server, reconnect.\");", 19);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades in 1 second, please reconnect.\",20);", 19);

	schedule("Messageall( 1,\"restarting server for upgrades NOW.\");", 20);
	schedule("centerprintall(\"<jc><f1>restarting server for upgrades NOW, please reconnect.\",20);", 20);

	schedule("echo(\"!! RESTARTING SERVER !!\");",21);
	schedule("quit();",22);
}

function Server::CheckMatchStarted()
{
	// if the match hasn't started yet, just reset the map
	// timing issue.
	if(!$matchStarted)
		Server::nextMission(true);
}

function Server::Countdown(%time)
{
	$countdownStarted = true;
	schedule("Game::startMatch();", %time);
	Game::notifyMatchStart(%time);
	if(%time > 30)
		schedule("Game::notifyMatchStart(30);", %time - 30);
	if(%time > 15)
		schedule("Game::notifyMatchStart(15);", %time - 15);
	if(%time > 10)
		schedule("Game::notifyMatchStart(10);", %time - 10);
	if(%time > 5)
		schedule("Game::notifyMatchStart(5);", %time - 5);
}

function Client::setInventoryText(%clientId, %txt)
{
	remoteEval(%clientId, "ITXT", %txt);
}

function centerprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprint(%clientId, %msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	remoteEval(%clientId, "TP", %msg, %timeout);
}

function centerprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "CP", %msg, %timeout);
}

function bottomprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "BP", %msg, %timeout);
}

function topprintall(%msg, %timeout)
{
	if(%timeout == "")
		%timeout = 5;
	for(%clientId = Client::getFirst(); %clientId != -1; %clientId = Client::getNext(%clientId))
		remoteEval(%clientId, "TP", %msg, %timeout);
}

function adminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isAdmin)
		{
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}

function superAdminMsg(%msg)
{
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++)
	{
		%pl = getClientByIndex(%i);
		if(%pl.isSuperAdmin)
		{
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}


//plasmatic
function checkclone(%clientId){
	%matchIp = 0;
	%numPlayers = getNumClients();
	%Clname = Client::getName(%clientId);
   	%ip = Client::getTransportAddress(%clientId);
	%ClientIp = ixPrepIP(%ip);
	if ($debug) 
		echo("Connecting Players Ip "@%ClientIp);

	for(%i = 0; %i < %numPlayers; %i++)
	{
		%cl = getClientByIndex(%i);
		%ip = Client::getTransportAddress(%cl);
		%name = Client::getName(%cl);
		if(%clientId != %cl)
		{
			if(!String::ICompare(%ClientIp, ixPrepIP(%ip)))
			{
				echo("matching Ip.. ");
				if(%Clname != %name @ ".1" && %Clname@".1" != %name )
				{
					%matchIp ++;	
					$clone = %Clname @ " ip# "@%ClientIp@ " Cloning "@%name@" ip# "@ixPrepIP(%ip)@", SAME IP CLONE ALERT";
					echo("clone WARNING "@$clone);
					export("clone","config\\clone.log",true);
					messageall(1,"send in the clones!!");
				}
			}
		}
	if (%matchIp > 4) {
		echo("----------- "@%clientId@", "@Client::getName(%clientId)@", "@%matchIp@" Matching Ip's! ");
		BanList::add(%ClientIp, 1800);
		BanList::export("config\\banlist.cs");
		}
	}
}

function FairTeamCheck(){
	%numPlayers = getNumClients();
	%numTeams = getNumTeams()-1;
	%fp = %numTeams +1;
	for(%i = 0; %i < %numTeams; %i = %i + 1)  %numTeamPlayers[%i] = 0;

	for(%i = 0; %i < %numPlayers; %i = %i + 1)
		{
		%cl = getClientByIndex(%i);
		%team = Client::getTeam(%cl);
		%numTeamPlayers[%team] = %numTeamPlayers[%team] + 1;
		
		}
	if (%numTeamPlayers[0] == %numTeamPlayers[1]) return;
	for(%i = 0; %i < %numTeams; %i = %i + 1){
		if (%numTeamPlayers[%i] <= %numPlayers/%fp && %numPlayers != 1) messageall(1,"even up the teams!");
	}	
}


echo("server.cs ran");	//plasmatic

