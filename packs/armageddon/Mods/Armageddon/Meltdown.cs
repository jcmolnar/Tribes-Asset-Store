
######################################
# Server startup variables           #
# Color Tags:                        #
# White Text = <f2>                  #
# Light Text = <f1>                  #
# Normal Text = <f0>                 # 
# \n = New Line                      #
# Leaving the messages without color #
# tags will result in the usage of   #
# the last used color                #
# In this case, White.               #
# You can also use these commands    #
# for setting up your server         #
# information (serverprefs.cs)       #
######################################



#############################################
# Server Switches (set to false to disable) #
#############################################

$Meltdown::BckDrMessage = "You may not use backdoor console access. Your Name and IP are logged and Traced"; 
$Meltdown::SpawnDelay = 5;				// Amount in seconds when a player cant spawn in some situations.
$Meltdown::PublicAdminVote = False; 		// Can vote to admin
$Meltdown::ChangeMissionVote = True; 		// Can vote to change missions
$Meltdown::ChangeTeams = True; 			// Must be true for Fair teams to work
$Meltdown::KickVote = True; 				// Can vote to Kick
$Meltdown::TeamDamageSwitch = True; 		// Can vote to Enable/disable team damage
$Meltdown::FlagReturnTime = 45; 			// Time in seconds before flag will return to it's flagstand
$Meltdown::StationTime = 50; 				// Cannot be less than 10 or higher than 60 or else it will use default. Set to false to disable
$Meltdown::VoteIncTime = 15; 				// # of mins to vote to increase time
$Meltdown::KickMessage =  "Get off my server you idiot.... and dont show your face here again any time soon!!";  // The message that displays when you kick/ban someone  
$Meltdown::RespawnEffectTime = 20;			// How long the cool respawn effect lasts (seconds)
$mallcomment = "?";	      // What displays in the bottom mission window when they respawn
$Meltdown::Version = "-=Armageddon=-";					

###########################
# Server Anti-TK settings #
###########################

$MD::TeamKillMsg = "Team Killing WILL NOT be tolerated on this server";
$MDAntiTeamKillProximity = 50;
$MeltdownTKKillwarning = 2;
$MeltdownTKbantime = 2400;
$TeamKillMin = 2;             			// Before he can qualify for being kicked for TKs
$MeltdownTKLimit = 4; 				// How many TKs before he is kicked 
$Meltdown::BaseKillWarning = 2;			// How many base kills before warned
$Meltdown::BaseKillLimit = 3;				// Haw many Base kills before he's Kicked

#####################################
# Server Anti-Password Hack settings#
#####################################

$GDMaxPassTry = 3;					// How many password attempts before kick.					
$GDWarnPassTry = 2;					// How many password attempts before warning.

#################
#  ->>EVENT<<-  #
#################

//PORT-OFF: $Event = "The Greatest Clan Alliance of Meltdown History took place 26th April 2002. =(w00)= and [GL] Unite. Strength and Honor!";
//PORT-OFF: $Event2 = "GreyBOT construction continues. Any Ideas email me at:- greyserver@hotmail.com";
//PORT-OFF: $Event3 = "Any URGENT Messages? Type !urgent and then your message and I will receive it. Please leave contact details as well.";

//This notice will come up 10 minutes into every map. Use this to advertise 
//special events or to let fellow clan members know about practices etc.
//Event 1 = 15 mins left
//Event 2 = 10 mins left
//Event 3 = 5 mins left
#######################################
#           Tag-Ban                   #
# Allows you to specify the tag of any#
# clan you want to have banned.       #
#######################################

//PORT-OFF: $TagBAN[0] = "{Op4}";
//PORT-OFF: $TagBAN[1] = "{PTK}";
//PORT-OFF: $TagBAN[2] = "[H:H]";
//PORT-OFF: $TagBAN[3] = "Omega";
//PORT-OFF: $TagBAN[4] = "(M00)";
//PORT-OFF: $TagBAN[5] = "[woo]";
$TagBAN[6] = "";
$TagBAN[7] = "";
$TagBAN[8] = "";
$TagBAN[9] = "";
$TagBAN[10] = "";

#######################################
#           Tag-Ban                   #
# Allows you to specify the tag of any#
# clan you want to have banned.       #
#######################################

$BadNAME[0] = "Fuck";
$BadNAME[1] = "Shit";
$BadNAME[2] = "Penis";
$BadNAME[3] = "Wank";
$BadNAME[4] = "Dick";
$BadNAME[5] = "Bitch";
$BadNAME[6] = "Fuk";
$BadNAME[7] = "Cum";
$BadNAME[8] = "";
$BadNAME[9] = "";
$BadNAME[10] = "";

########################################
#           Name-Ban                   #
# Allows you to specify the Name of any#
# clan you want to have banned.        #
########################################

//PORT-OFF: $NameBAN[0] = "{MA}Shizz";
//PORT-OFF: $NameBAN[1] = "[RR]Mister Pibb";
//PORT-OFF: $NameBAN[2] = "VashTheStampede";
//PORT-OFF: $NameBAN[3] = "Omega-Cookie";
//PORT-OFF: $NameBAN[4] = "Sephiroth";
//PORT-OFF: $NameBAN[5] = "UltimateD";
//PORT-OFF: $NameBAN[6] = "RouflesK";
$NameBAN[7] = "";
$NameBAN[8] = "";
$NameBAN[9] = "";
$NameBAN[10] = "";

########################################
#           IP-Ban                     #
# Allows you to specify the IP of any  #
# clan you want to have banned.        #
########################################

//PORT-OFF: $IPBAN[0] = "IP:68.39.178.34";
//PORT-OFF: $IPBAN[1] = "IP:207.247.109";
//PORT-OFF: $IPBAN[2] = "IP:12.145.226";
//PORT-OFF: $IPBAN[3] = "IP:12.145.236";
//PORT-OFF: $IPBAN[4] = "IP:172.162.15";
$IPBAN[5] = "";
$IPBAN[6] = "";
$IPBAN[7] = "";
$IPBAN[8] = "";
$IPBAN[9] = "";


########################################
#           Tag-Admin                  #
# Allows you to specify the Tag of any #
# clan you want to have admined.        #
########################################

//PORT-OFF: $TagADMIN[0] = "[GL]";
//PORT-OFF: $TagADMIN[1] = "(w00)";
//PORT-OFF: $TagADMIN[2] = "|*|w00|*|";
$TagADMIN[3] = "";
$TagADMIN[4] = "";
$TagADMIN[5] = "";
$TagADMIN[6] = "";
$TagADMIN[7] = "";
$TagADMIN[8] = "";
$TagADMIN[9] = "";
$TagADMIN[10] = "";


#######################################################
# Server Public Admin (PA) Passwords                  #
# Great for those clan Members who want Admin         #
# Usage: (console) sad("Password");                   # 
# You can add up to 96 differrent PA passwords (0-95) #
#######################################################

//PORT-OFF: $Meltdown::PAPassword[0] = "batwings";
$Meltdown::PAPassword[1] = "";
$Meltdown::PAPassword[2] = "";
$Meltdown::PAPassword[3] = "";
$Meltdown::PAPassword[4] = "";
$Meltdown::PAPassword[5] = "";
$Meltdown::PAPassword[6] = "";
$Meltdown::PAPassword[7] = "";
$Meltdown::PAPassword[8] = "";
$Meltdown::PAPassword[9] = "";
$Meltdown::PAPassword[10] = "";
$Meltdown::PAPassword[11] = "";
$Meltdown::PAPassword[12] = "";
$Meltdown::PAPassword[13] = "";
$Meltdown::PAPassword[14] = "";
$Meltdown::PAPassword[15] = "";

#################################################################################
# Server Sad Password allocation                                                #
# Allows you to have multiple SAD passwords or store other ppl's SAD passwords. #
# MUCH safer than Auto-Admin, but it's manual...                                #
# You can add up to 64 differrent SAD passwords (0-63)                          #
#################################################################################

//PORT-OFF: $Meltdown::SadPassword[0] = "anakin";
$Meltdown::SadPassword[1] = "";
$Meltdown::SadPassword[2] = "";
$Meltdown::SadPassword[3] = "";
$Meltdown::SadPassword[4] = "";
$Meltdown::SadPassword[5] = "";
$Meltdown::SadPassword[6] = "";
$Meltdown::SadPassword[7] = "";
//PORT-OFF: $Meltdown::GAPassword[1] = "coremanv3k";
$Meltdown::GAPassword[2] = ""; 


######################################################################
# Server Auto-admin Variables                                        #
# Add your ppl who you want to admin when they connect to the server #
# You can have as many as 128 different auto-admin names             #
######################################################################

//PORT-OFF: $CurAdminName = "|*|w00|*|Grey";  			// The Auto-Admin name that prompts you when you've been auto-admined by that name.

//PORT-OFF: $Server::AutoAdmin[0] = "|*|w00|*|Grey";
//PORT-OFF: $Server::AutoAdmin[1] = "{||*||w00||*||}Q";
//PORT-OFF: $Server::AutoAdmin[2] = "|*|w00|*|SD";
//PORT-OFF: $Server::AutoAdmin[3] = "|*|w00|*|Beast";
//PORT-OFF: $Server::AutoAdmin[4] = "|*|w00|*|Grey";
$Server::AutoAdmin[5] = "";
$Server::AutoAdmin[6] = "";
$Server::AutoAdmin[7] = "";
$Server::AutoAdmin[8] = "";
$Server::AutoAdmin[9] = "";
$Server::AutoAdmin[10] = "";
$Server::AutoAdmin[11] = "";
$Server::AutoAdmin[12] = "";
$Server::AutoAdmin[13] = "";
$Server::AutoAdmin[14] = "";
$Server::AutoAdmin[15] = "";

##############################################################
# IPs have to be placed by IP: then your IP number.          #
# Ex.                                                        #
#                                                            #
# $Server::AutoAdminAddr[99] = "IP:123.456.789.0";           #
# You can have as many as 128 different auto-admin addresses #
##############################################################

//PORT-OFF: $Server::AutoAdminAddr[0] = "IP:217.36";
//PORT-OFF: $Server::AutoAdminAddr[1] = "IP:65";
//PORT-OFF: $Server::AutoAdminAddr[2] = "IP:66";
//PORT-OFF: $Server::AutoAdminAddr[3] = "IP:64";
$Server::AutoAdminAddr[4] = "";
$Server::AutoAdminAddr[5] = "";
$Server::AutoAdminAddr[6] = "";
$Server::AutoAdminAddr[7] = "";
$Server::AutoAdminAddr[8] = "";
$Server::AutoAdminAddr[9] = "";
$Server::AutoAdminAddr[10] = "";
$Server::AutoAdminAddr[11] = "";
$Server::AutoAdminAddr[12] = "";
$Server::AutoAdminAddr[13] = "";
$Server::AutoAdminAddr[14] = "";
$Server::AutoAdminAddr[15] = "";

###################################
#             CRAP                #
###################################

$Meltdown::AutoAssignTeam = true;
$Meltdown::AutoAssignTribe = "";
$Meltdown::AutoAssignLength = 5;
//PORT-OFF: $Server::Password = "";
//PORT-OFF: $TelnetPort = "";
//PORT-OFF: $TelnetPassword = "";
exec("Custom.cs");
