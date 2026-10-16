// Apteryx auto admin list (was annihilationadminlist.cs). Read only when
// $Annihilation::AutoAdmin is true (ApteryxSettings.cs; false in this pack).
//
// The 2003 file shipped five LIVE entries (the author as "God" on a /16 network and on the mask
// "00000000", and four friends as AutoSuper / AutoPublic on /16 networks). None is carried over.
//
// $UserList::UserName[n] = "<the player's name>";
// $UserList::UserMask[n] = "<AccessLevel> <IP mask> [<IP mask> ...]";
//
// AccessLevel:  God         super admin (flagged "God")
//               AutoSuper   super admin
//               AutoPublic  public admin
// IP mask:      four numbers separated by dots, * allowed for any number, one word.
//               209.14.25.25 = that address only; 209.14.25.* = that subnet.
//               A wide mask gives admin to ANYONE on that network who types the name.
//
// Example (two admins):
//   $UserList::MaxUsers = 2;
//   $UserList::UserName[1] = "SomePlayer";
//   $UserList::UserMask[1] = "AutoSuper 203.0.113.7";
//   $UserList::UserName[2] = "OtherPlayer";
//   $UserList::UserMask[2] = "AutoPublic 203.0.113.*";

$UserList::MaxUsers = 0;	// TOTAL number of admin users listed above
