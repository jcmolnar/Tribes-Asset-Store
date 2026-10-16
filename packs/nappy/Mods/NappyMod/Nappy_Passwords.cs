//+=========================TELNET SERVER PARAMETERS================================+

// PORT (off: a remote console is the host's choice, not a mod's) $TelnetPort = "1234";			//port number for a server monitoring program like tricon to connect through 	
// PORT (off; the password published in the release is removed) $TelnetPassword = "";		//this password is needed for programs using the Telnet Port


//___________________________________________________________________________________________
//|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
//___________________________________________________________________________________________
//|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|

			// to set the password put the password you want it to be in the ""
			// EXAMPLE: $MemberPassword = "IamAmember";

//__________________________________
$Nappy::Admin::Passwords = 0;//set this to 1 if you want to use global passwords

$FriendPassword = "";
$MemberPassword = "";
$AdminPassword = "";
$SuperAdminPassword = "";
$UltraAdminPassword = "";
$GodAdminPassword = "";

//__________________________________
$Nappy::Personal::Passwords = 0;//set this to 1 if you want to use personal passwords

//+============================PERSONAL PASSWORD SETUP============================+
 
 //$AdminPassword[#] = "Password AdminLevel Rank TagId OwnersName";
 //
 // # - starts at 1
 // Password - if set to empty it can't be used
 // AdminLevel - Member/Admin/Super
 // Rank - 0 to whatever. Can't kick/ban same rank or higher
 // TagId - this is the number in the [] of the $ClanTag you want to use
 // OwnersName - displays this name so super admins can see what password
 //is being used and who is using it
 //
 //$ClanTag1[1] = "Tag1";//TagId = 1
 //$ClanTag1[2] = "Tag2";//TagId = 2
 //$ClanTag1[3] = "Tag3";//TagId = 3
 //
 //$IP[ID1,ID2,ID3] = "23.210.79.0";
 //
 //ID1 is the account id starting at 1 and continuing with no breaks from start to end
 //jumping from 3 to 5 will make it stop at 3 no matter how many more are set
 //ID2 is the ip set id so an account can use multiple sets of ips and also doesn't allow skipping of numbers
 //ID3 is the range id and when set to 1 its the low range
 //if 2 is also set it will allow ips within the 2 ranges to use the password
 //if 2 is not set then it will only allow the ip set for 1 to be used
 //
 //
 //EXAMPLE LIST
 //$AdminPassword[1] = "jw3k1 Super 10 2 Billy";
 //   $IP[1,1,1] = "23.210.79.0";
 //   $IP[1,2,1] = "11.67.0.0";
 //   $IP[1,3,1] = "11.67.100.255";
 //$AdminPassword[2] = "rdrr Member 3 1 Joey";
 //   $IP[2,1,1] = "6.2.80.100";
 //$AdminPassword[3] = "hmmm Admin 6 3 Killer Bunny";//names were moved to the end so they could contain spaces
 //   $IP[3,1,1] = "24.77.56.10";
 //   $IP[3,2,1] = "40.160.7.24";
 //   $IP[3,3,1] = "9.11.15.0";
 //$LastAdminNumber = 3;//this is used to know when to stop checking for more



//+=================================WORKING EXAMPLE=======================================+

//$AdminPassword[1] = "password Admin 10 1 Player"; // PORT: the "working example" was live code (blanked again five lines below)
//$IP[1,1,1] = "123.4.56.789"; // PORT: same

//+=================================NOW, SET YOURS UP=====================================+

$AdminPassword[1] = "";
$IP[1,1,1] = "*.*.*.*";
$IP[1,2,1] = "*.*.*.*";
$AdminPassword[2] = "";
$IP[2,1,1] = "*.*.*.*";
$AdminPassword[3] = "";
$IP[3,1,1] = "*.*.*.*";
$AdminPassword[4] = "";
$IP[4,1,1] = "*.*.*.*";


$LastAdminNumber = 4;		//This is used to tell when to stop checking for another password
				//$ListAdminNumber = (# of admins set up);
				//How many members you got? That's how many it's able to go up to.


//___________________________________________________________________________________________
//|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
//___________________________________________________________________________________________
//|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|_|
