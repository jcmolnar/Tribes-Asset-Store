//v2.0
//Use these values: 1 for active, 0 for inactive. Unless otherwise stated.
//You can make certain weapons not available by setting their inventory variable to 0

//PLEASE MAKE SURE THAT YOU DO NOT ERASE ANY SEMICOLONS!!!!!!!!!!!!!!!!!!!!!!!!!!

//if you do, it won't work.

//Run-Time Store
$StoreOpen = 1;

//Here are the options for the weapons contained within this version

//Nuke
$NukeEMPPulse = 1;
$NukeInventory = 1;

//Ricochet Gun (Bouncy)
$BouncyBounce = 0.65;     //Use values between 0 and 0.99 - Values Greater
                           //than 0.65 tend to bounce through walls.
$BouncyInventory = 1;

//ChainBlaster
$ChainBlasterInventory = 1;

//Cloaking Gun
$CloakGunInventory = 1;

//Backpack of Revenge
$RevengeInstantDetonation = 0;   //0 to drop flag mine, 1 to explode instantly
$RevengeRadius = 50.0;             //Explosion Radius (Kill Zone) in meters
$RevengeInventory = 1;

//MIRV
$MIRVinventory = 1;
$MIRVwarheads  = 8;		    //Be careful with this value, it could lag the hell out of your server.