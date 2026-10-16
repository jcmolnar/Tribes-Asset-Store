//        1 = Yes you are using the list.
//        0 = No you are NOT using the list.
$UserList::Activated = 1;
/////////////////////////////////////////////////////////////////////////////////////////////////
//$UserList::User[<User>,<Access>] = <IP>;
//
//<User>            User name
//
//<Access>          Untouchable2  - same as Untouchable but more admin functions
//                  Untouchable   - Untouchable admin
//                  God           - God Admin
//                  Super         - Super Admin
//                  Public        - Public Admin
//<IP>
//                  = What IP or IPs you want to list for that user. you can list
//                  as many IPs as you want. the only wildcard accepted is *
//                  For Example:
//                        User's actual IP = 209.14.25.25
//                        Successful IP Mask = 209.14.*.*
//                  When using the * that will allow any number for that part of the IP.
//                  Please be aware of the consequences of using wildcards and autoadmin.
//                  You may give a whole ISP control of your server, or even the whole Planet.
//
//==============================================================================================
////////////////////////////////////////////////////////////////////////////////////////////////
////////////////////////////// Examples ////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////////////////
//Untouchable2
//$UserList::User["-|DF|- Zed RWX", "Untouchable2"] = "12.*.*.*";


//Untouchable 
//$UserList::User["-|DF|- Zed RWX", "Untouchable"] = "12.*.*.*";

//God 
//$UserList::User["-|DF|- Zed RWX", "God"] = "24.71.*.*";


//Super
//$UserList::User["-|DF|- Zed RWX", "Super"] = "205.*.*.*";
//==============================================================================================
//////////////////////////////////////////////////////////////////////////////////////////////////

