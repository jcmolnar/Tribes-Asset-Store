// Ultra Renegades Modmgt auto admin list. The mod runs exec("AutoAdmin.cs") every time a server
// is created; every connecting client that matches an entry is made SUPER ADMIN at once.
// EMPTY in this pack. The 2002 config\autoadmin.cs shipped sixteen live entries for the
// addresses 192.168.0.2 to 192.168.0.18; they are not included.
//
// To use it, copy this file to config\AutoAdmin.cs and edit the copy. Entries are numbered from
// 0 with no gaps; the list ends at the first number where both lines are missing.
//
//   $AutoAdmin::AutoAdminAddr0 = "IP:203.0.113.7:";   // address PREFIX; end it with ":" or the
//                                                     // entry also matches 203.0.113.70 to .79
//   $AutoAdmin::AutoAdmin0 = "SomePlayer";            // optional: also require this exact name
//
// An entry with a name and NO address line may match that name from ANY address: do not write one.
