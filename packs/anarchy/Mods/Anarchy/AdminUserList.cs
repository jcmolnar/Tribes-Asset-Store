// ANARCHY mod -- admin user list (server.cs execs "AdminUserList" when it loads).
// This is the release's template with the list SWITCHED OFF and its three sample accounts
// removed (they were real player names with the password "123", level God, mask *.*.*.*).
//
// 	1 = Yes you are using the list.
//	0 = No you are NOT using the list.
$UserList::Activated = 0;

// How many Users In your list?
$UserList::MaxUsers = 0;

//The Actual User.
//$UserList::User[1] = "<UserNumber> <UserName> <UserPassword> <AccessLevel> <IP Masks>";
//
//<UserNumber> 	= What is this users Usernumber.
//
//<UserName> 	= What is this Users Regular Name.
//		  (HAS TO BE ONE WORD - NO Spaces)
//
//<UserPassword> 	= Not used by this build: no script calls the password check (ixProcess).
//		  Put any one word here; the entry still needs five words.
//
//<AccessLevel> 	= What Access do they have. Only the automatic levels do anything:
//		  God           - Auto-God Admin status
//		  AutoSuper 	- Super Admin w/ Auto Admin.
//		  AutoPublic 	- Public Admin w/ Auto Admin.
//
//<IP Masks> 	= What IP or IPs you want to list for that user. you can list
//		  as many IPs as you want. the only wildcard accepted is *
//		  For Example:
//			User's actual IP = 209.14.25.25
//			Successful IP Mask = 209.14.*.*
//		  When using the * that will allow any number for that part of the IP.
//		  A mask must have all four parts. A player NAME is not proof of identity:
//		  with the mask *.*.*.* anyone who takes the name gets the rights.
//
//Example (do not use *.*.*.*):
//$UserList::User[1] = "1 SomeName x AutoSuper 203.0.113.*";
