// Activated
// 	1 = Yes you are using the list.
//	0 = No you are NOT using the list.

$UserList::Activated = 0;

// How many Users In your list?

$UserList::MaxUsers = 3;

//<UserNumber> 	 = What is this users Usernumber. 
//
//<UserName> 	 = What is this Users Regular Name. 
//
//<UserPassword> = Not supported, enable password manually from the Renegades.cs
//
//<AccessLevel>  = What level of auto-admin you which to give to the player:
//		  God		- Assigns God Admin 
//		  AutoSuper 	- Assigns Super Admin
//		  AutoPublic 	- Assigns Public Admin
//                NoKick        - Player can not be kicked by vote
//
//<IP Masks> 	= What IP or IPs you want to list for that user. You can list
//		  as many IP addresses as you like by changing the MaxDataFields, and
//		  increasing the array by that number, i.e. [1,7]...[1,8]..etc. 
//		  The only wildcard accepted is * 
//		  For Example:
//			User's actual IP = 172.16.0.1
//			Successful IP Mask = 172.16.*.*
//		  When using the * that will allow any number for that part of the IP. 
//		  Please be aware of the consequences of using wildcards and autoadmin. 
//		  You may give a whole ISP control of your server, or even the whole Planet. 


$UserList::MaxDataFields = 6; //range is 4 to whatever, depending on the number
			      //of ip addresses you want to specify.  6 is a good
			      //number which gives you the ability to enter 3 seperate
			      //IP addresses per user.  
//Example of user data

//  *** user #1 ***
//$UserList::User[1,0] = "1";		  // <UserNumber>
//$UserList::User[1,1] = "ZOD";  // <UserName> 
//$UserList::User[1,2] = "000";		  // <UserPassword>  Not supported
//$UserList::User[1,3] = "God";		  // <AccessLevel>
//$UserList::User[1,4] = "20.21.222.23";  // <IP Mask>
//$UserList::User[1,5] = "";		  // <additional IP Mask>
//$UserList::User[1,6] = "";		  // <additional IP Mask>

// *** user #2 ***
//$UserList::User[2,0] = "2";
//$UserList::User[2,1] = "sal9000";
//$UserList::User[2,2] = "000";
//$UserList::User[2,3] = "AutoSuper";
//$UserList::User[2,4] = "20.21.222.24";
//$UserList::User[2,5] = "166.55.44.33";
//$UserList::User[2,6] = "";

// *** user #3 ***
//$UserList::User[3,0] = "3";
//$UserList::User[3,1] = "Drk";
//$UserList::User[3,2] = "000";
//$UserList::User[3,3] = "AutoPublic";
//$UserList::User[3,4] = "20.21.222.*";
//$UserList::User[3,5] = "";
//$UserList::User[3,6] = "";

//go ahead and build your list


$UserList::User[1,0] = "1";
$UserList::User[1,1] = "";
$UserList::User[1,2] = "000";
$UserList::User[1,3] = "";
$UserList::User[1,4] = "";
$UserList::User[1,5] = "";
$UserList::User[1,6] = "";

$UserList::User[2,0] = "2";
$UserList::User[2,1] = "";
$UserList::User[2,2] = "000";
$UserList::User[2,3] = "";
$UserList::User[2,4] = "";
$UserList::User[2,5] = "";
$UserList::User[2,6] = "";

$UserList::User[3,0] = "3";
$UserList::User[3,1] = "";
$UserList::User[3,2] = "000";
$UserList::User[3,3] = "";
$UserList::User[3,4] = "";
$UserList::User[3,5] = "";
$UserList::User[3,6] = "";

$UserList::User[4,0] = "4";
$UserList::User[4,1] = "";
$UserList::User[4,2] = "000";
$UserList::User[4,3] = "";
$UserList::User[4,4] = "";
$UserList::User[4,5] = "";
$UserList::User[4,6] = "";

$UserList::User[5,0] = "5";
$UserList::User[5,1] = "";
$UserList::User[5,2] = "000";
$UserList::User[5,3] = "";
$UserList::User[5,4] = "";
$UserList::User[5,5] = "";
$UserList::User[5,6] = "";
