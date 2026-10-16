// PORT (Modern Tribes 1.50): this is the mod's own 2K4.cs. comchat.cs execs it at boot and at every
// mission load, so the lines that stamped the host name, join password, port, player limit, master
// list and last mission are commented out (//PORT-OFF:), the other $Server:: defaults only apply
// when the host has not set them, and the two telnet prefs are commented out. Everything else is
// the original. Set your admin passwords and names below exactly as XCaliburReadMe.txt describes.

//*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
//												           *
//					       						                   |
//	  |*|        */*/*/*/*\	  |*|   /*/     /*/ *|	     |*|	© 				   * 		
//    ____|*|____   */      /*/	  |*|  /*/     /*/  *|	 ____|*|____				           |
//    ____ * ____	    */	  |*| /*/     /*/   *|	 ____ * ____			                   *
//	  |*|		   */	  |*|/*/     /*/    *|	     |*|			                   |
//	  |*|	          */	  |* */	    /*/	    *|	     |*|					   *
//    ____|*|____        */	  |* *\	   /*/*/*/*/*|	 ____|*|____					   |		
//    ____ * ____       */ 	  |*|\*\            *|	 ____ * ____				           *
//	  |*|	       */	  |*| \*\	    *|	     |*|					   |	
//	  |*|	      */*/*/*/*/  |*|  \*\	    *|       |*|					   *		
//													   |
// © +]-[YBRID ‡2k4‡ ©  By +]-[+DT (Hybird Development Team): +]-[+Armageddon+  +]-[+WOG+  +]-[+WorstAim+  *
//                                                                                                         |
//   COPYRIGHT 1998 - 2004 By +]-[+Armageddon+  +]-[+WOG+  +]-[+WorstAim+                                  *          
//	                                                                                                   |
//   © PROTECTED BY COPYRIGHT LAW U.S.C. Act 17 Section 102 (a) ©                                          *
//                                                      						   |				           
//   For all you numbnuts out there, this means DO NOT UNDER ANY CIRCUMSTANCES CHANGE ALTER, OR OTHERWISE  *
//   MODIFY ANYTHING CONTAINED IN THIS, OR ANY OTHER OF HYBRIDS CODE, UNLESS GIVEN THE EXPRESSED WRITTEN   |
//   CONSENT OF +]-[+Armageddon+  +]-[+WOG+ and +]-[+WorstAim+                                             *
//									                                   |     
//-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*


//PORT-OFF: $Server::JoinPassword = ""; //Put Your Server Join Password Here If You Want A Permanent One
//PORT-OFF: $Server::HostName = ""; //Put Your Server Name Here
$ServerHost = ""; // Put Your Tribes Name Here
$AutoAdmin = "True";   // Put True Or False.  True Is On, False Is Off.
$MemberTagCheck::Activated = "True";  // Put True Or False. If You Want To Be Able To Connect Without You Tag On, Leave It As False, Otherwise, Enter True.

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

//***************************
//* Server Anti-TK settings *
//***************************

$XCalibur::TeamKillMsg = "Team Killing WILL NOT be tolerated on this server";
$XCaliburAntiTeamKillProximity = 50;
$XCaliburTKKillwarning = 100;
$XCaliburTKbantime = 1;
$TeamKillMin = 100;             			// Before he can qualify for being kicked for TKs
$XCaliburTKLimit = 100; 				      // How many TKs before he is kicked 
$XCalibur::BaseKillWarning = 100;			// How many base kills before warned
$XCalibur::BaseKillLimit = 100;				// Haw many Base kills before he's Kicked

//**************************************
//* Server Anti-Password Hack settings *
//**************************************

$GDMaxPassTry = 3;					// How many password attempts before kick.					
$GDWarnPassTry = 2;					// How many password attempts before warning.

//**************************************
//*        CLAN MEMBERS                *
//*                                    *
//*  Put Your Clans Members Here       *
//*                                    *
//*                                    *
//**************************************

$ClanMembers = "<F0>|| <F2>+]-[+Armageddon+<F0> | <F2>+]-[+WhIzAtIt+<F0> | <F2>+]-[+HaWk+<F0> | <F2>+]-[+Smurf+<F0> | <F2>+]-[+StOrM+<F0> ||\n|| <F2>+]-[+RVD+<F0> | <F2>+]-[+Moose+<F0> | <F2>+]-[+Mors+<F0> | <F2>+]-[+jInZo+<F0> ||"; //Put Clan Member Names Here.  
$ClanMembers2 = "<F0>|| <F2>+]-[+'][']-[()R+<F0> | <F2>+]-[+c0re+<F0> | <F2>+]-[+Messiah+<F0> | <F2>+]-[+*|O|Siris*+<F0> | <F2>+]-[+WOG+<F0> ||\n|| <F2>+]-[+WorstAim+<F0> | <F2>+]-[+*POPS*+<F0> | <F2>+]-[+LoCkDoWn+<F0> ||"; //Put Clan Member Names Here.
$ClanMembers3 = "<F0>|| <F2>+]-[+MortalMan+<F0> | <F2>+]-[+KitKat+<F0> | <F2>+]-[+MastaCheif+<F0> | <F2>+]-[+Iron_Walnut+<F0> | <F2>+]-[+QuaKe+<F0> ||\n|| <F2>+]-[+ChEeDeR+<F0> | <F2>+]-[+Rebel+<F0> | <F2>+]-[+sneakyl+<F0> ||"; //Put Clan Member Names Here.
$ClanMembers4 = ""; //Put Clan Member Names Here.


//      -------
//     |       |     
//     |       |
//     |       |________________________________________________________________________
//=====     		       	                                                          \    
//                             	Put Your Master Admin Password Here.    	           \ 	  
//		     	       						                    \   			  
//           			 Master is the Highest Admin                                /
//                                                                                         /
//=====         ________________________________________________________________________  /
//     |       |     
//     |       |
//     |       |	
//      -------

$XCalibur::XAPassword[0] = ""; // PUT YOUR PASSWORD HERE AND DON'T DELETE IT

//**************************************
//  *                                *
//  *      SERVER MASTER NAME        *
//  *                                *
//**************************************

$XAdminName[0] = ""; // PUT YOUR NAME HERE, AND DON'T DELETE IT
$XAdminIP[0] = ""; // PUT YOUR IP HERE, AND DON'T DELETE IT USE A * TO REPRESENT THE AREA BETWEEN THE LAST . AND THE :   SO IF YOU IP WAS: IP:241.424.52.123:3922 it would be IP:241.424.52.*

//**************************************
//  *                                *
//  *     SERVER ADMIN LIST          *
//  * (Used In !XCalibur Function)   *
//  *                                *
//**************************************

$MasterAdmins = "<F0>|| <F2>+]-[+Armageddon+<F0> | <F2>+]-[+WhIzAtIt+<F0> | <F2>+]-[+HaWk+<F0> | <F2>+]-[+Smurf+<F0> | <F2>+]-[+RVD+<F0> | <F2>+]-[+WorstAim+<F0> | <F2>+]-[+WOG+<F0> ||"; // Names Of Master Admins Here
$GodAdmins = "<F0>|| <F2>+]-[+Moose+<F0> | <F2>+]-[+Mors+<F0> | <F2>+]-[+jInZo+<F0>  | <F2>+]-[+c0re+<F0> | <F2>+]-[+Messiah+<F0> | <F2>+]-[+'][']-[()R+<F0> ||";   // Names Of God Admins Here
$SuperAdmins = "<F0>|| <F2>+]-[+*|O|Siris*+<F0> | <F2>+]-[+*POPS*+<F0> | <F2>+]-[+LoCkDoWn+<F0> | <F2>+]-[+MortalMan+<F0> ||";   // Names Of Super Admins Here
$PublicAdmins = "<F0>|| <F2>+]-[+KitKat+<F0> | <F2>+]-[+MastaCheif+<F0> | <F2>+]-[+Iron_Walnut+<F0> | <F2>+]-[+QuaKe+<F0> ||";  // Names Of Public Admins Here

//***********************************
//*             CRAP/TELNET         *
//***********************************
//You Can Change This If You Want

$XCalibur::AutoAssignTeam = true;
$XCalibur::AutoAssignTribe = "";
$XCalibur::AutoAssignLength = 5;
//PORT-OFF: $TelnetPort = "";
//PORT-OFF: $TelnetPassword = "";

//***********************************
//*     DEFAULT SERVER GLOBALS      *
//***********************************

//PORT-OFF: $Server::MasterName1 = "UK Tribes Master";
//PORT-OFF: $Server::MasterName2 = "Australian Tribes Master";
//PORT-OFF: $Server::MaxPlayers = "8";
if($Server::MinVotes == "") $Server::MinVotes = "1";
if($Server::MinVotesPct == "") $Server::MinVotesPct = "0.5";
if($Server::MinVoteTime == "") $Server::MinVoteTime = "45";
//PORT-OFF: $Server::numMasters = "3";
//PORT-OFF: $Server::Port = "28001";
if($Server::respawnTime == "") $Server::respawnTime = "2";
if($Server::TeamDamageScale == "") $Server::TeamDamageScale = "0";
if($Server::teamName0 == "") $Server::teamName0 = "Blood Eagle";
if($Server::teamName1 == "") $Server::teamName1 = "Diamond Sword";
if($Server::teamName2 == "") $Server::teamName2 = "Children of the Phoenix";
if($Server::teamName3 == "") $Server::teamName3 = "Starwolf";
if($Server::teamName4 == "") $Server::teamName4 = "Generic 1";
if($Server::teamName5 == "") $Server::teamName5 = "Generic 2";
if($Server::teamName6 == "") $Server::teamName6 = "Generic 3";
if($Server::teamName7 == "") $Server::teamName7 = "Generic 4";
if($Server::teamSkin0 == "") $Server::teamSkin0 = "beagle";
if($Server::teamSkin1 == "") $Server::teamSkin1 = "dsword";
if($Server::teamSkin2 == "") $Server::teamSkin2 = "cphoenix";
if($Server::teamSkin3 == "") $Server::teamSkin3 = "swolf";
if($Server::teamSkin4 == "") $Server::teamSkin4 = "base";
if($Server::teamSkin5 == "") $Server::teamSkin5 = "base";
if($Server::teamSkin6 == "") $Server::teamSkin6 = "base";
if($Server::teamSkin7 == "") $Server::teamSkin7 = "base";
if($Server::timeLimit == "") $Server::timeLimit = "25";
if($Server::TourneyMode == "") $Server::TourneyMode = "false";
if($Server::VoteAdminWinMargin == "") $Server::VoteAdminWinMargin = "0.659999";
if($Server::VoteFailTime == "") $Server::VoteFailTime = "30";
if($Server::VoteWinMargin == "") $Server::VoteWinMargin = "0.549999";
if($Server::VotingTime == "") $Server::VotingTime = "20";
if($Server::warmupTime == "") $Server::warmupTime = "20";
//PORT-OFF: $Server::XLMasterN0 = "IP:198.74.32.55:28000";
//PORT-OFF: $Server::XLMasterN1 = "IP:198.74.35.10:28000";
//PORT-OFF: $Server::XLMasterN2 = "IP:198.74.40.67:28000";
//PORT-OFF: $pref::LastMission = "Raindance";

