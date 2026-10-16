// SexNC17UserList.cs -- admin user list of SEX mod NC17 (loaded by scripts\server.cs).
//
// EMPTY as shipped. The 2004 archive's adminuserlist.cs gave "God" admin to 18 player NAMES coming
// from whole address blocks (172.*.*.*, 63.*.*.*, 209.*.*.* ...): anyone using one of those names
// from such an address was admin on every server running the mod. It is not shipped.
//
// A player is matched by NAME and by ADDRESS at connect; there is no password step in this mod
// (the password word is not used), so give an exact address, never a wide mask.
//
//   $UserList::User[1] = "<number> <Name-without-spaces> <unused> <AccessLevel> <IP mask> [<IP mask> ...]";
//
// AccessLevel: God (admin + super admin), AutoSuper (admin + super admin), AutoPublic (admin).
// Example (not active):
//   $UserList::User[1] = "1 SomeName x AutoPublic 203.0.113.7";
//   $UserList::MaxUsers = 1;

$UserList::MaxUsers = 0;
