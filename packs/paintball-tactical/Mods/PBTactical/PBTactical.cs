// Paintball v.Tactical_XCal (2004-03-19) -- Modern Tribes (1.50) entry script AND settings file.
//
// Original launch line (PaintballMODReadMe!.txt):
//    Tribes.exe +exec PBTactical.cs -mod PBTactical          (InfiniteSpawn.exe ... -dedicated)
// with this file copied to config\. Here it sits in the mod folder: the client runs it once at
// start-up because it carries the mod's name, and the mod's own scripts (server.cs, comchat.cs)
// exec it again on every mission. Everything below this block is the release's file.
//
// PORT changes in the settings below (search for PORT):
//   $Server::HostName is left to your own server prefs.
//   $XCalibur::XAPassword[0] shipped as "DEFAULT" (the top admin level); it is blank now.
//      Set it before you host:  say  !XAdmin <password>  in chat to log in.
//   $TelnetPort / $TelnetPassword are left to your own prefs.
// The admin tool writes its lists and logs into config\ (XNames.cs, XPW.cs, IPBans.cs,
// banlist.cs, connections.txt, Chat.txt, Commands.txt, hackerlog.txt and others).

//
//       PAINTBALL V. Tactical_XCal Created By +]-[+Armageddon+ and +]-[+WorstAim
// 
//            COPYRIGHT Under U.S.C. Act 17 Title 102 Section (a) and (b)
//
//
//
//







//*********************************************
//*		.:: PBTactical.cs ::.	      *
//*              			      *
//* This is all pretty self explanitory.      *
//* Set up your pw.  XCalibur (The Admin)     *
//* takes care of   			      *
//* other passwords.  I tried to make this as *
//* easy as I could to use. Theres not much   *
//* else to say, so enjoy		      *
//*********************************************				

//*********************************************
//		STUFF 2 KNO		      
//
//  \n can be used to add a new line. 
//  \t can be used to add a tab.
//  <F0> <F1> and <F2> Can All Be Put Before Names And Are Used To Add Color.  <F0> is orange, <F1> is regular beige, <F2> is white
//
//*********************************************

///////////////////////////////////////////
// 
//        SERVER SETUP


//PORT-OFF: $Server::HostName = "+]-[+ Tactical +]-[+"; //Put Your Server Name Here

//+++++++++++++++++++++++++++++++++++
// THIS IS VERY IMPORTANT FILL IT OUT

$ServerHost = ""; // Put Your Tribes Name Here, you will be the 1st person to have XList access
$ServerHost1 = ""; // Put the name of the 2nd person who you want to have XList access here
$ServerHost2 = ""; // Put the name of the 3rd person who you want to have XList access here
$ClearServerPassOnRestart = "true"; //True Means That If A Server Join Password Is Set, It Is Cleared Everytime The Server Is Restarted.  False Means The PW Is Kept.

//++++++++++++++++++++++++++++++
// Usefull Stuff

$AutoAdmin = "false";   // Put True Or False.  True Is On, False Is Off.
$MemberTagCheck::Activated = "false";  // Put True Or False. If You Want To Be Able To Connect Without You Tag On, Leave It As False, Otherwise, Enter True.

//*********************************************
//* Server Switches (set to false to disable) *
//*********************************************

$XCalibur::BckDrMessage = "You may not use backdoor console access. Your Name and IP are logged and Traced"; 
$XCalibur::SpawnDelay = 5;				// Amount in seconds when a player cant spawn in some situations.
$XCalibur::PublicAdminVote = False; 		// Can vote to admin
$XCalibur::ChangeMissionVote = True; 		// Can vote to change missions
$XCalibur::ChangeTeams = True; 			// Must be true for Fair teams to work
$XCalibur::KickVote = True; 				// Can vote to Kick
$XCalibur::TeamDamageSwitch = True; 		// Can vote to Enable/disable team damage
$XCalibur::FlagReturnTime = 45; 			// Time in seconds before flag will return to it's flagstand
$XCalibur::StationTime = false; 				// Cannot be less than 10 or higher than 60 or else it will use default. Set to false to disable
$XCalibur::VoteIncTime = 15; 				// * of mins to vote to increase time
$XCalibur::RespawnEffectTime = 20;			// How long the cool respawn effect lasts (seconds)				
$Paintball::LeaveAreaTime = "0";                       //Sets To Either Kill You When You Leave The Mission Area Or Not
$Paintball::StationKickTime = "10";                    //Number Of Seconds Before A Person Is Booted From A Station

///////////////////////////////////////////////////////////////////////////////

//***************************
//* Server Anti-TK settings *
//***************************

$XCalibur::TeamKillMsg = "Team Killing WILL NOT be tolerated on this server";
$XCaliburAntiTeamKillProximity = 50;
$XCaliburTKKillwarning = 100;
$XCaliburTKbantime = 1;
$TeamKillMin = 1;             			// Before he can qualify for being kicked for TKs
$XCaliburTKLimit = 100; 				      // How many TKs before he is kicked 
$XCalibur::BaseKillWarning = 100;			// How many base kills before warned
$XCalibur::BaseKillLimit = 100;				// Haw many Base kills before he's Kicked

//**************************************
//* Server Anti-Password Hack settings *
//**************************************

$GDMaxPassTry = 3;					// How many password attempts before kick.					
$GDWarnPassTry = 2;					// How many password attempts before warning.

//************************************************************************************************
//*           Armor-Types                                                                        *
//* Put in all the armors of the mod you are playing.                                            *    
//* for example: $Armor[-1] = "mech";                                                            *
//* To find the armor of a mod you are playing, host the mod.                                    *
//* Than go to the DOS window and type: %armor = Player::getArmor(clientId); echo(""@%armor@""); *
//* (clientId = the client number example: 2049, 2050, 2051 ect...);                             *
//* this will display the name of the armor in the mod that the player is currenly in.           *
//* put that name into one of the quotes.   						       *
//* The reason for this is XCalibur can use the armors for the admin option "Change Armor".      *
//************************************************************************************************

$Armor[0] = "";
$Armor[1] = "";
$Armor[2] = "";
$Armor[3] = "";
$Armor[4] = "";
$Armor[5] = "";
$Armor[6] = "";
$Armor[7] = "";
$Armor[8] = "";
$Armor[9] = "";
$Armor[10] = "";

//Put the Game Name of the Armor Here.  For Example: $GameArmor[0] = "Light Armor";

$GameArmor[0] = "";
$GameArmor[1] = "";
$GameArmor[2] = "";
$GameArmor[3] = "";
$GameArmor[4] = "";
$GameArmor[5] = "";
$GameArmor[6] = "";
$GameArmor[7] = "";
$GameArmor[8] = "";
$GameArmor[9] = "";
$GameArmor[10] = "";


//**************************************
//*        CLAN MEMBERS                *
//*                                    *
//*  Put Your Clans Members Here       *
//*                                    *
//*                                    *
//**************************************

$ClanTag = "FILL OUT";     //Put You Clan Tag Here
$ClanInfo = "FILL OUT";    // Put Info About Your Clan Here
$ClanMembers = "FILL OUT"; //Put Clan Member Names Here.  
$ClanMembers2 = "FILL OUT"; //Put Clan Member Names Here.
$ClanMembers3 = "FILL OUT"; //Put Clan Member Names Here.
$ClanMembers4 = "FILL OUT"; //Put Clan Member Names Here.


//      -------
//     |       |     
//     |       |
//     |       |________________________________________________________________________
//=====     		       	                                                          \    
//                             	Put Your Master XCalibur Password Here.    	           \ 	  
//		     	       						                    \   			  
//           			 XCalibur is the Highest Admin                              /
//                                                                                         /
//=====         ________________________________________________________________________  /
//     |       |     
//     |       |
//     |       |	
//      -------

$XCalibur::XAPassword[0] = ""; //PORT: shipped as "DEFAULT" // PUT YOUR PASSWORD HERE AND DON'T DELETE IT

//**************************************
//  *                                *
//  *      SERVER MASTER NAME        *
//  *                                *
//**************************************

$XAdminName[0] = "FILL OUT"; // PUT YOUR NAME HERE, AND DON'T DELETE IT
$XAdminIP[0] = "FILL OUT"; // PUT YOUR IP HERE, AND DON'T DELETE IT Use a * to represent the last numbers that come after the . but before the : so for Example If Your IP Was: IP:61.412.51.55:9002 You Would Make It IP:61.412.51.*

//**************************************
//  *                                *
//  *     SERVER ADMIN LIST          *
//  * (Used In !XCalibur Function)   *
//  *                                *
//**************************************

$XCaliburAdmins = "Fill"; // Names Of XCaliburs Here
$MasterAdmins = "This";   // Names Of Master Admins Here
$SuperAdmins = "In";   // Names Of Super Admins Here
$PublicAdmins = "Bum";  // Names Of Public Admins Here

//***********************************
//*             CRAP                *
//***********************************
//You Can Change This If You Want

$XCalibur::AutoAssignTeam = true;
$XCalibur::AutoAssignTribe = "";
$XCalibur::AutoAssignLength = 5;
//PORT-OFF: $TelnetPort = "";
//PORT-OFF: $TelnetPassword = "";                                                                                                                                                                                                                                                                                                                                 
