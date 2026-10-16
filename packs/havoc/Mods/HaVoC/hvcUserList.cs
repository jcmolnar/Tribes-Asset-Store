// PORT (Modern Tribes 1.50): shipped switched off. The original file had the list ACTIVE with two
// AutoSuper entries for the author's names and addresses.
// Activated
// 	1 = Yes you are using the list.
//	0 = No you are NOT using the list.
$UserList::Activated = 0; //PORT: was 1

// Set this to the number of users in your list.
$UserList::MaxUsers = 3;

//The Actual User.
//$UserList::User[1] = "<UserNumber> <UserName> <UserPassword> <AccessLevel> <IP Masks>";
//
//<UserNumber> 	= What is this users Usernumber. 
//
//<UserName> 	= What is this Users Regular Name. 
//		  (HAS TO BE ONE WORD - NO Spaces)
//
//<UserPassword>	= What this user's SAD() Password is. 
//		  (HAS TO BE ONE WORD - NO Spaces)
//
//<AccessLevel>  = What Access do they have. Choices are:
//		  AutoSuper 	- Automatically gives the user Super Admin status. 
//		  AutoPublic 	- Automatically gives the user Public Admin status. 
//				   If the password is identical to any $HaVoC::PAPassword[]
//				   the user will use special lockouts, if available.  Else
//				   they get the default PA lockouts.
//
//<IP Masks> 	= What IP or IPs you want to list for that user. you can list
//		  as many IPs as you want. The only wildcard accepted is * 
//		  For Example:
//			User's actual IP = 172.16.0.1
//			Successful IP Mask = 172.16.*.*
//		  When using the * that will allow any number for that part of the IP. 
//		  Please be aware of the consequences of using wildcards and autoadmin. 
//		  You may give a whole ISP control of your server, or even the whole planet. 
//
//Example of User Entries:
//PORT-OFF: $UserList::User[1] = "1 [HvC]NaTeDoGG nopassword AutoSuper 206.11.248.84";
//PORT-OFF: $UserList::User[2] = "2 [HvC]Dev nopassword AutoSuper 206.13.43.109";

