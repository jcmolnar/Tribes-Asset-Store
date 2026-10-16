//-----------------------------------------------------------
// Holocaust v3.5 "With Duel" by /D:B/Spector -- entry script for the Modern Client (1.50)
//
// The 2001 install was a Tribes\holocaust\ folder holding this settings file,
// HolocaustUserList.cs, mine.cs and scripts.vol, started by
//    Infinitespawn.exe *tribes.exe -mod Holocaust -dedicated      (Holocaust.bat)
// The loader now runs this copy from Mods\Holocaust\Holocaust.cs.  Everything
// below the PORT BLOCK is the original settings file, byte for byte.
//-----------------------------------------------------------

// ---- PORT BLOCK (added by the port) ----------------------
echo("Holocaust v3.5 (/D:B/Spector) -- 1.50 port entry");
// The scripts used to put this text into $modList (armordata.cs, damagetypes.cs,
// game.cs).  On 1.50 $modList is the search path, so the label lives here.
$hh::ModLabel = "Holocaust v3.5";
// ---- end of PORT BLOCK ------------------------------------

//-----------------------------For Setting Up Holocaust

$hh::PublicAdminVote = False; 	//- for poeple to have the vote option in the menu (tab key)	
$hh::ChangeMissionVote = True; 	//- for poeple to have the vote option in the menu (tab key)	
$hh::ChangeTeams = True; 	//- to allow poeple to change teams  (tab key)			
$hh::KickVote = True; 		//- for poeple to have the vote option in the menu (tab key)			
$hh::TeamDamageSwitch = false; 	//- for poeple to have the vote option in the menu (tab key)
$hh::FlagReturnTime = 45;
$hh::FriendlyMines = True; 	//- for if the mines are friendly (if they do not damage to team members)		
$hh::StationTime = 35; 		//- how long before the get kicked out of an inv station		
$hh::VoteIncTime = 15; 		//- how long for voting		
$hh::KickMessage = "Get Lost!";    //- the message for the person who was kicked
$hh::RespawnEffectTime = 2;	   // how long the neat respawn effects last and fair respawn (how much time the player has before becoming fair game to be killed)			     
$hh::TeleCountdownTime = 300;			
$trace = false;						
$AnnihilatorEnable = True;	// sets mitiz to this mode			
$TeamKillMin = 2;             	// how many team kills warnings		
$hh::TKLimit = 3; 		// how long before getting kicked for team kills		
$hh::BaseKillWarning = 3;	// how many warnings for basekills		
$hh::BaseKillLimit = 5;		// how many it takes to get kicked		
$flagToStandTime = 180;
//------------------------------------------------------- team energy ----------------------------------------
$DefaultTeamEnergy = "Infinite";
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy;
//------------------------------------------------------------------------------------------------------------ 
$WaitThrowTime = 2;         // how long before a player can throw a mine or gernade after leaving an inv station
$TeamEnergyCheat = 0;
$MaxTeamEnergy = 700000;
$incTeamEnergy = 700;
$secTeamEnergy = 30;
$ItemRespawnTime = 30;       
$TeammateSpending = -4000;  
$WarnEnergyLow = 4000;	    
$InitialPlayerEnergy = 5000;
exec(HolocaustUserList);        

//----------------------------------- for team damage to allways be off
// this setting must be placed in the serverprefs.cs file
// $Server::TeamDamageScale = "0";
// 0 = teamdamage off
// 1 = teamdamage on
//-----------------------------------------------------------------------			
