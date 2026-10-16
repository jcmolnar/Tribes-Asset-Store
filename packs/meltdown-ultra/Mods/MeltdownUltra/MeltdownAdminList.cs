//=========================================================================================================================================
// AutoAdmin Options
//=========================================================================================================================================

//==== Wild card IP's must just be left blank. Do NOT use the * in place of an octet. Note below for an example.
//==== NEW AutoAdmin - SAD Password Assignments

//==== NOTE : ALL OF THESE LINES MUST BE PRESENT FOR AUTO/SAD ADMIN TO WORK - PER PLAYER!!!

//PORT-OFF: $MD::Admin["autoa", ")WAR(Defender"] = 1;			//== (0 or 1) 1 Turns ON AutoAdmin
//PORT-OFF: $MD::Admin["noban", ")WAR(Defender"] = 1;			//== (0 or 1) 1 Adds player to NOBan list
//PORT-OFF: $MD::Admin["ipadr", ")WAR(Defender"] = "IP:4.60.105";	//== Ip mask for AutoAdmining check (Left blank will NOT Autoadmin, MUST contain an IP mask to Autoadmin)
//PORT-OFF: $MD::Admin["sadpw", ")WAR(Defender"] = "";	//== Optional SAD password for user - Left blank user will NOT be able to use SAD ability.
//PORT-OFF: $MD::Admin["admin", ")WAR(Defender"] = 1;			//== (0 or 1) 1 Sets User to Normal Admin
//PORT-OFF: $MD::Admin["super", ")WAR(Defender"] = 1;			//== (0 or 1) 1 Sets User to BOTH Normal/SuperAdmin

//PORT-OFF: $MD::Admin["autoa", "YourName"] = 1;			//== (0 or 1) 1 Turns ON AutoAdmin
//PORT-OFF: $MD::Admin["noban", "YourName"] = 1;			//== (0 or 1) 1 Adds player to NOBan list
//PORT-OFF: $MD::Admin["ipadr", "YourName"] = "YourIP:4.60.105";	//== Ip mask for AutoAdmining check (Left blank will NOT Autoadmin, MUST contain an IP mask to Autoadmin)
//PORT-OFF: $MD::Admin["sadpw", "YourName"] = "";	//== Optional SAD password for user - Left blank user will NOT be able to use SAD ability.
//PORT-OFF: $MD::Admin["admin", "YourName"] = 1;			//== (0 or 1) 1 Sets User to Normal Admin
//PORT-OFF: $MD::Admin["super", "YourName"] = 1;			//== (0 or 1) 1 Sets User to BOTH Normal/SuperAdmin

//PORT-OFF: $MD::Admin["autoa", "YourName"] = 1;			//== (0 or 1) 1 Turns ON AutoAdmin
//PORT-OFF: $MD::Admin["noban", "YourName"] = 1;			//== (0 or 1) 1 Adds player to NOBan list
//PORT-OFF: $MD::Admin["ipadr", "YourName"] = "YourIP:4.60.105";	//== Ip mask for AutoAdmining check (Left blank will NOT Autoadmin, MUST contain an IP mask to Autoadmin)
//PORT-OFF: $MD::Admin["sadpw", "YourName"] = "";	//== Optional SAD password for user - Left blank user will NOT be able to use SAD ability.
//PORT-OFF: $MD::Admin["admin", "YourName"] = 1;			//== (0 or 1) 1 Sets User to Normal Admin
//PORT-OFF: $MD::Admin["super", "YourName"] = 1;			//== (0 or 1) 1 Sets User to BOTH Normal/SuperAdmin

//PORT-OFF: $MD::Admin["autoa", "YourName"] = 1;			//== (0 or 1) 1 Turns ON AutoAdmin
//PORT-OFF: $MD::Admin["noban", "YourName"] = 1;			//== (0 or 1) 1 Adds player to NOBan list
//PORT-OFF: $MD::Admin["ipadr", "YourName"] = "YourIP:4.60.105";	//== Ip mask for AutoAdmining check (Left blank will NOT Autoadmin, MUST contain an IP mask to Autoadmin)
//PORT-OFF: $MD::Admin["sadpw", "YourName"] = "";	//== Optional SAD password for user - Left blank user will NOT be able to use SAD ability.
//PORT-OFF: $MD::Admin["admin", "YourName"] = 1;			//== (0 or 1) 1 Sets User to Normal Admin
//PORT-OFF: $MD::Admin["super", "YourName"] = 1;			//== (0 or 1) 1 Sets User to BOTH Normal/SuperAdmin

//PORT-OFF: $MD::Admin["autoa", "YourName"] = 1;			//== (0 or 1) 1 Turns ON AutoAdmin
//PORT-OFF: $MD::Admin["noban", "YourName"] = 1;			//== (0 or 1) 1 Adds player to NOBan list
//PORT-OFF: $MD::Admin["ipadr", "YourName"] = "YourIP:4.60.105";	//== Ip mask for AutoAdmining check (Left blank will NOT Autoadmin, MUST contain an IP mask to Autoadmin)
//PORT-OFF: $MD::Admin["sadpw", "YourName"] = "";	//== Optional SAD password for user - Left blank user will NOT be able to use SAD ability.
//PORT-OFF: $MD::Admin["admin", "YourName"] = 1;			//== (0 or 1) 1 Sets User to Normal Admin
//PORT-OFF: $MD::Admin["super", "YourName"] = 1;			//== (0 or 1) 1 Sets User to BOTH Normal/SuperAdmin

//== Local IP's (Assuming you have a LAN connection to the server and are not worried about band width from connecting Lan players,
// You can increase the limit when a player from this IP Mask connects.
//$Meltdown::LocalNetMask = " ";

//=============================================
//== Spawn favs - limited options List2 =============================================
//=============================================

//------Only add your name on 1 option at a time---------------------------------------------------------------------------
//PORT-OFF: $MD::SpawnBuyList2["List2", ")WAR(Defender"] = 1;  // on
$MD::SpawnBuyList2["List2", "PlayerName"] = 0;
$MD::SpawnBuyList2["List2", "PlayerName"] = 0;
$MD::SpawnBuyList2["List2", "PlayerName"] = 0;
$MD::SpawnBuyList2["List2", "PlayerName"] = 0;

//Spawn Buy List 2
$spawnBuyList2[0] = HeavyArmor;  // Myrmidon (Heavy)
$spawnBuyList2[1] = MBCannon;
$spawnBuyList2[2] = MMinigun;
$spawnBuyList2[3] = RailGun;
$spawnBuyList2[4] = Reassembler;
$spawnBuyList2[5] = MECHRocketLauncher;
$spawnBuyList2[6] = Mortar;
$spawnBuyList2[7] = TwinFusor;
$spawnBuyList2[8] = Grenade;
$spawnBuyList2[9] = Beacon;
$spawnBuyList2[10] = MineAmmo;
$spawnBuyList2[11] = RepairKit;
$spawnBuyList2[12] = EnergyPack;


//=============================================
//== Spawn favs - limited options List3 =============================================
//=============================================

//------Only add your name on 1 option at a time---------------------------------------------------------------------------
$MD::SpawnBuyList3["List3", "PlayerName"] = 0;  // on
$MD::SpawnBuyList3["List3", "PlayerName"] = 0;
$MD::SpawnBuyList3["List3", "PlayerName"] = 0;
$MD::SpawnBuyList3["List3", "PlayerName"] = 0;
$MD::SpawnBuyList3["List3", "PlayerName"] = 0;

//Spawn Buy List 3
$spawnBuyList3[0] = MECHArmor; // Assault
$spawnBuyList3[1] = MBCannon;
$spawnBuyList3[2] = MassDriver;
$spawnBuyList3[3] = RailGun;
$spawnBuyList3[4] = Reassembler;
$spawnBuyList3[5] = MECHRocketLauncher;
$spawnBuyList2[6] = Mortar;
$spawnBuyList3[7] = Grenade;
$spawnBuyList3[8] = Beacon;
$spawnBuyList3[9] = MineAmmo;
$spawnBuyList3[10] = RepairKit;
$spawnBuyList3[11] = EnergyPack;


// End

// I got lazy, and did not add the rest of the armors...
