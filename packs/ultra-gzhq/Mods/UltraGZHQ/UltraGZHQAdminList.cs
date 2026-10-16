// Ultra_Renagades_GZHQ auto admin list. Read at every connect while $UltraGZHQ::AutoAdmin is
// true (it is false in UltraGZHQ.cs). EMPTY in this pack: the 2002 file shipped two live
// entries (a "God" entry for one player name on any 172.*.*.* address and a public admin entry
// for another name on 63.136.*.*); they are not included.
//
// To use it, copy this file to config\UltraGZHQAdminList.cs and edit the copy.
//
//   $UserList::UserName[1] = "<player name, exactly>";
//   $UserList::UserMask[1] = "<AccessLevel> <IP mask>";
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
