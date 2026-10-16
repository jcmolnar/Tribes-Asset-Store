// IX-Admin user list (template). The engine's admin.cs loads this file when the server is
// created. Text below is the template the Renegades 2K release shipped (same engine), with the
// sample user switched off. A copy of this file in config\ wins over this one.
//
// Activated
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
//<UserPassword> 	= What this user's SAD() Password is.
//		  (HAS TO BE ONE WORD - NO Spaces)
//
//<AccessLevel> 	= What Access do they have. Choices are:
//		  SuperAdmin 	- Super Admin. (duh).
//		  PublicAdmin 	- Public Admin. Uses Current Public admin Lockouts.
//		  AutoSuper 	- Super Admin w/ Auto Admin.
//		  AutoPublic 	- Public Admin, same as above w Auto Admin.
//
//<IP Masks> 	= What IP or IPs you want to list for that user. you can list
//		  as many IPs as you want. the only wildcard accepted is *
//		  For Example:
//			User's actual IP = 172.16.0.1
//			Successful IP Mask = 172.16.*.*
//		  When using the * that will allow any number for that part of the IP.
//		  Please be aware of the consequences of using wildcards and autoadmin.
//		  You may give a whole ISP control of your server, or even the whole Planet.
//		  Every mask needs all four parts (three dots).
//
//Example of a User Entry (remove the // and set $UserList::MaxUsers = 1 to use it):
//$UserList::User[1] = "1 SomeName SomePassword SuperAdmin 172.16.7.2 172.16.8.*";
