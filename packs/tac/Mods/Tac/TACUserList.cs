//================================================================================================
//=======                        TAC General Settings                            =======
//================================================================================================

// Activated
// 	1 = Yes you are using the list.
//	0 = No you are NOT using the list.
$UserList::Activated = 1;

//How many Admin Levels in your list?
$UserList::MaxClasses = 6;

// How many Users In your list?
$UserList::MaxUsers = 2;

// How many group passwords are there in your list?
$UserList::MaxGroups = 1;

//================================================================================================
//=======                         This is the admin group setup.                           =======
//================================================================================================
//
//	This list lets the server admin define custom admin levels for his server.
//
//eg.
//	$UserList::AdminName[1] = "AutoSuper";
//	$UserList::AdminIsImmune[1] = true;
//	$UserList::AdminGeneral[1] = true;
//	$UserList::AdminServerSettings[1] = true;
//	$UserList::AdminCanAdminPlayer[1] = true;
//	$UserList::AdminReferee[1] = true;
//	$Userlist::AdminAutoLogin[1] = true;
//
//	AdminName 					-	The name of the admin class
//	AdminIsImmune				-	This admin is immune to kicking and puratory modes?
//	AdminGeneral				-	This admin has general admin powers like changing maps,
//									kicking, banning, muting, setting mission times, etc
//	AdminServerSettings			-	This admin may change team names and may alter server
//									settings such as server password, Team Energy, etc
//	AdminCanAdminPlayer			-	Pretty obvious isn't it?
//	AdminReferee				-	Admin can put server into tournament or league mode and
//									can force the match start.  This admin may also adjust settings
//									for league matches and Team Names.
//	AdminAutoLogin				-	Admin is logged in automatically on connection to server
//									and does not need to use SAD command. Only advisable for
//									admins with static (non-changing) ip addresses.
//
//	NOTE: 	Any admin with the level of AdminServerSettings or AdminReferee MUST also have AdminGeneral
//			admin access.
//
//=================================================================================================


//Admin Group Number 1
$UserList::AdminName[1] = "AutoSuper";
$UserList::AdminIsImmune[1] = true;
$UserList::AdminGeneral[1] = true;
$UserList::AdminServerSettings[1] = true;
$UserList::AdminCanAdminPlayer[1] = true;
$UserList::AdminReferee[1] = true;
$Userlist::AdminAutoLogin[1] = true;

//Admin Group Number 2
$UserList::AdminName[2] = "SuperAdmin";
$UserList::AdminIsImmune[2] = true;
$UserList::AdminGeneral[2] = true;
$UserList::AdminServerSettings[2] = true;
$UserList::AdminCanAdminPlayer[2] = true;
$UserList::AdminReferee[2] = true;
$Userlist::AdminAutoLogin[2] = false;

//Admin Group Number 3
$UserList::AdminName[3] = "RefAdmin";
$UserList::AdminIsImmune[3] = false;
$UserList::AdminGeneral[3] = true;
$UserList::AdminServerSettings[3] = false;
$UserList::AdminCanAdminPlayer[3] = true;
$UserList::AdminReferee[3] = true;
$Userlist::AdminAutoLogin[3] = false;

//Admin Group Number 4
$UserList::AdminName[4] = "AutoRef";
$UserList::AdminIsImmune[4] = false;
$UserList::AdminGeneral[4] = true;
$UserList::AdminServerSettings[4] = false;
$UserList::AdminCanAdminPlayer[4] = true;
$UserList::AdminReferee[4] = true;
$Userlist::AdminAutoLogin[4] = true;

//Admin Group Number 5
$UserList::AdminName[5] = "PublicAdmin";
$UserList::AdminIsImmune[5] = false;
$UserList::AdminGeneral[5] = true;
$UserList::AdminServerSettings[5] = false;
$UserList::AdminCanAdminPlayer[5] = false;
$UserList::AdminReferee[5] = false;
$Userlist::AdminAutoLogin[5] = false;

//Admin Group Number 6
$UserList::AdminName[6] = "AutoPublic";
$UserList::AdminIsImmune[6] = false;
$UserList::AdminGeneral[6] = true;
$UserList::AdminServerSettings[6] = false;
$UserList::AdminCanAdminPlayer[6] = false;
$UserList::AdminReferee[6] = false;
$Userlist::AdminAutoLogin[6] = true;



//===============================================================================================
//=======                           This is the user setup.                               =======
//===============================================================================================
//
//	This list allows the server admin to define what players get admin rights
//
//eg.
//	$UserList::UserName[1] = "Wizard_TPG";
//	$UserList::UserPass[1] = "MyPassword";
//	$UserList::UserLevel[1] = "AutoSuper";
//	$UserList::UserIP[1] = "172.16.7.2 172.16.8.*";
//
//	UserName		-	Must be the EXACT players username.  " Character is not allowed
//	UserPass		-	Players SAD password
//	UserLevel		-	Admin group as defined above
//	UserIP			-	Specify players ip address/s.  * is used as wild card character.
//						eg.  172.16.7.2 is eqivalent to 172.16.*.* or 172.16.7.*
//
//===============================================================================================

$UserList::UserName[1] = "Wizard_TPG";
$UserList::UserPass[1] = "mypass";
$UserList::UserLevel[1] = "AutoSuper";
$UserList::UserIP1[1] = "139.130.60.150";
$UserList::UserIP2[1] = "198.142.*.*";

$UserList::UserName[2] = "[TPG]SaNTa[DTM]";
$UserList::UserPass[2] = "pass";
$UserList::UserLevel[2] = "SuperAdmin";
$UserList::UserIP1[2] = "*.*.*.*";




//===============================================================================================
//=======                          This is the Group setup.                               =======
//===============================================================================================
//
//	This list allows the server admin to define what a password that ANY player that knows the
//	password can use, irrespective of name or ip address.
//	WARNING:  Use this feature at your own risk as it IS a security risk to distribute a global
//				group password.
//
//eg.
//	$UserList::GroupPass[1] = "refpass";
//	$UserList::GroupLevel[1] = "RefAdmin";
//
//	GroupPass		-	The password.  All the group passwords MUST be different.
//	GroupLevel		-	Admin group as defined above
//
//===============================================================================================

$UserList::GroupPass[1] = "refpass";
$UserList::GroupLevel[1] = "RefAdmin";

