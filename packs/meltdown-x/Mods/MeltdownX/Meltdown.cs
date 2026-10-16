#################################################################################################################################
# This mod is copyrighted © 2003 *(COOP)*											#
# 																#
# Base Programming by INH*DynaBlade												#
# Debuggin' by {J}MEGA-Man,*(COOP)*												#
# Additional programming by:UNFORGIVEN												#
# Other people who contributed: YOUWANTME, WarOrphan, Stunna, Wheel,TTYT							#
# Email:kjmartin@gci.net													#
#################################################################################################################################

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

$Meltdown::JoinMOTD = "<f0>Welcome to Meltdown X - Black OP'S vX OMEGA<f0>\n\nReady for the slaughter? Fire When Ready!.";

#############################################
# Server Switches (set to false to disable) #
#############################################

$Meltdown::PublicAdminVote = False; 		// Can vote to admin
$Meltdown::ChangeMissionVote = True; 		// Can vote to change missions
$Meltdown::ChangeTeams = True; 			// Must be true for Fair teams to work
$Meltdown::KickVote = True; 				// Can vote to Kick
$Meltdown::TeamDamageSwitch = True; 		// Can vote to Enable/disable team damage
$Meltdown::FlagReturnTime = 10; 			// Time in seconds before flag will return to it's flagstand
$Meltdown::StationTime = 50; 				// Cannot be less than 10 or higher than 60 or else it will use default. Set to false to disable
$Meltdown::VoteIncTime = 15; 				// # of mins to vote to increase time
$Meltdown::KickMessage = "GOODBYE!";  // The message that displays when you kick/ban someone  
$Meltdown::RespawnEffectTime = 1;			// How long the cool respawn effect lasts (seconds)
$mallcomment = "ITS ALL OR NOTHING!";	      // What displays in the bottom mission window when they respawn
$Meltdown::TeleCountdownTime = 300;			// Time in seconds it takes the teleporter to blow up if not deployed
$trace = false;						// Extra in-game messages exported to console
$AnnihilatorEnable = True;                           // You can choose if you what the extra Mitzi Annihilator mode added onto the Mitzi Blast Cannon
//PORT-OFF: ;   (a bare semicolon is a syntax error: the settings file stopped loading HERE)

###########################
# Server Anti-TK settings #
###########################

$TeamKillMin = 4;             			// Before he can qualify for being kicked for TKs
$Meltdown::TKLimit = 8; 				// How many TKs before he is kicked 

##########################
# Default game variables #
# for more advanced      #
# servers ONLY!          #
# -INH*DynaBlade         #
##########################

//---------------------------------------------------------------------------------
//  Time player has to put flag in flagstand before it gets returned to its last
//  location. Only for F&R Missions
//---------------------------------------------------------------------------------
$flagToStandTime = 180;

//---------------------------------------------------------------------------------
// Energy each team is given at beginning of game
//---------------------------------------------------------------------------------
$DefaultTeamEnergy = "Infinite";

//---------------------------------------------------------------------------------
// Team Energy variables
//---------------------------------------------------------------------------------
$TeamEnergy[-1] = $DefaultTeamEnergy; 
$TeamEnergy[0]  = $DefaultTeamEnergy; 
$TeamEnergy[1]  = $DefaultTeamEnergy; 
$TeamEnergy[2]  = $DefaultTeamEnergy; 
$TeamEnergy[3]  = $DefaultTeamEnergy; 
$TeamEnergy[4]  = $DefaultTeamEnergy; 
$TeamEnergy[5]  = $DefaultTeamEnergy; 
$TeamEnergy[6]  = $DefaultTeamEnergy; 				
$TeamEnergy[7]  = $DefaultTeamEnergy; 

//---------------------------------------------------------------------------------
// Time in sec player must wait before he can throw a Grenade or Mine after leaving
//	a station.
//---------------------------------------------------------------------------------
$WaitThrowTime = 2;

//---------------------------------------------------------------------------------
// If 1 then Team Spending Ignored -- Team Energy is set to $MaxTeamEnergy every
// 	$secTeamEnergy.
//---------------------------------------------------------------------------------
$TeamEnergyCheat = 0;

//---------------------------------------------------------------------------------
// MAX amount team energy can reach
//---------------------------------------------------------------------------------
$MaxTeamEnergy = 700000;

//---------------------------------------------------------------------------------
// Amount to inc team energy every ($secTeamEnergy) seconds
//---------------------------------------------------------------------------------
$incTeamEnergy = 700;

//---------------------------------------------------------------------------------
// (Rate is sec's) Set how often TeamEnergy is incremented
//---------------------------------------------------------------------------------
$secTeamEnergy = 30;

//---------------------------------------------------------------------------------
// (Rate is sec's) Items respwan
//---------------------------------------------------------------------------------
$ItemRespawnTime = 30;

//---------------------------------------------------------------------------------
// TEAM ENERGY -  Warn team when teammate has spent x amount - Warn team that 
//				  energy level is low when it reaches x amount 
//---------------------------------------------------------------------------------
$TeammateSpending = -4000;  //Set = to 0 if don't want the warning message
$WarnEnergyLow = 4000;	    //Set = to 0 if don't want the warning message

//---------------------------------------------------------------------------------
// Amount added to TeamEnergy when a player joins a team
//---------------------------------------------------------------------------------
$InitialPlayerEnergy = 5000;

//===============================================================================//

########################################
# Spoonbot (Bioderm) settings/switches #
# For you Bot lovers out there         #
# -INH*DynaBlade                       #
########################################

$DisableBotRespawn = true; 				//== If true, then bots do not respawn. This works for holograms too
$SpoonBot::BotTree_MaxAutoCalc = 10;		//== Threshhold after which auto route generation is disabled.
$Spoonbot::BotChat = true;				//== If the bot's chat messages annoy you, you can turn them off here.
$Spoonbot::RespawnDelay = 2;				//== How many seconds until bots respawn after being killed
$Spoonbot::IQ = 100;					//== The IQ controls the bot's overall skill, like targeting precision, speed, etc.
$Spoonbot::ThinkingInterval = 5;			//== Interval in sec between which bots will "reconsider" their situation
								//== NOTE: RespawnDelay MUST be higher than ThinkingInterval
								//== ANOTHER NOTE: The slower your CPU, the higher this should be.
$Spoonbot::MovementInterval = 1.5;			//== Interval in sec between calls of the Movement code.
								//== This should be generally lower than ThinkingInterval
								//== NOTE: Again, the slower your CPU, the higher this should be.
								//== If you experience "lag", set these values even higher.
$Spoonbot::RetreatDamageLevel = 0.9;		//== Bots will retreat if damage exceeds this value. 0.0 means no damage, 1.0 means dead.

# Bot talk

$cheerList[0] = "Yeah, that's the ticket!";   	// YEAH			//This sets up a list of voice comments
$cheerList[1] = "Woo-hoo!! That gotta hurt!";   	// WOO-HOO
$cheerList[2] = "All right!!";   	// ALL RIGHT
$cheerList[3] = "Yooo-Hooo!";   	// Yooo-Hooo!
$cheerList[4] = "How did that feel?";    // Howd that feel?
$cheerList[5] = "I've had worse";    // I've Had worse
$cheerList[6] = "Missed me, sucker!";   	// Missed me!
$cheerList[7] = "Dance!";   	// Dance!
$cheerList[8] = "That looks like it's going to stain.";   	// Come Get some
$cheerList[9] = "Who gave you the nerve to get killed here?";   	// Come Get some
$cheerList[10] = "Geez, are you ok?";
$cheerList[11] = "Ouch, that HAD to hurt!";
$cheerList[12] = "Who da man!";
$cheerList[13] = "Yeh punk!";
$cheerList[14] = "You all banged up!";
$cheerList[15] = "Can anyone here play this game?";
$cheerList[16] = "Waiter! Come clean up this mess!";
$cheerList[17] = "Take my advice, or I'll spank you without pants";
$cheerList[18] = "Need a band-aid?";
$cheerList[19] = "Boo-Ya!!!";
$cheerList[20] = "Everyone line up single file... I'll get the laserrifle";
$cheerList[21] = "Sorry.  This is a NO BREATHING zone.  ";
$cheerList[22] = "Hey, drop to the console and type KILL.";
$cheerList[23] = "Damn, it should be illegal to suck so bad.";
$cheerList[24] = "Excuse me while I urinate on your corpse.";
$cheerList[25] = "Hey... found your spleen.";
$cheerList[26] = "Stick to Duke Nukem.";
$cheerList[27] = "That was just a sample.";
$cheerList[28] = "Nice try... A for effort.";
$cheerList[29] = "Thanks for the weapon.";
$cheerList[30] = "Just give up.";
$cheerList[31] = "How pathetic.";
$cheerList[32] = "Wow, what a shot.  I rule. ";
$cheerList[33] = "Sorry, didn't see you there. :)";
$cheerList[34] = "That's right... run... wuss....";
$cheerList[35] = "Why'd ya try to run %s?";
$cheerList[36] = "Just like a deer in headlights.";
$cheerList[37] = "Bahahaha!";
$cheerList[38] = "Man... I pity you. I really do.";
$cheerList[39] = "Yeah... you're my favorite.";
$cheerList[40] = "What do you call that shit?";
$cheerList[41] = "Learn from that.";
$cheerList[42] = "Your corpse made a fine screenshot.";
$cheerList[43] = "You weren't using that weapon anyway.";
$cheerList[44] = "Oh get up... you aint hurt!  :)";
$cheerList[45] = "Lovely chalk outline.";
$cheerList[46] = "Next time... move.";
$cheerList[47] = "Stick to observer mode.";
$cheerList[48] = "Love those death animations... you too apparently.";
$cheerList[49] = "Damn, you smell just like roast chicken.";
$cheerList[50] = "I love the sound of crunching bone. :)";
$cheerList[51] = "Burn baby burn.";
$cheerList[52] = "Dude... your skin blows.";
$cheerList[53] = "Instant karma.";
$cheerList[54] = "Does your face hurt? Well, its killin' me!";
$cheerList[55] = "Ooh, thats gotta hurt!";
$cheerList[56] = "B-b-b-b-Bad to the bone!";
$cheerList[57] = "Bull's Eye!";
$cheerList[58] = "I bet that hurt!";
$cheerList[59] = "Come meet my 2x4.";
$cheerList[60] = "Step right up to be knocked right down!";
$cheerList[61] = "He's dead, Jim!";
$cheerList[62] = "Keep the change.";
$cheerList[63] = "Oh, I'm gooood.";
$cheerList[64] = "There's no reason to act like that!";
$cheerList[65] = "Anyone got a spachula?";
$cheerList[66] = "Danger, Will Robinson, danger!";
$cheerList[67] = "Excuse me, is the circus in town?";
$cheerList[68] = "Terminated.";
$cheerList[69] = "BOOM, baby!";
$cheerList[70] = "You move like peanut butter!";
$cheerList[71] = "You gonna start playing or what?";
$cheerList[72] = "Keeping practising.";
$cheerList[73] = "Your in my house now!";
$cheerList[74] = "Ain't nobody stoppin me!";
$cheerList[75] = "Gun wounds again?";
$cheerList[76] = "Try strafing sometime.";
$cheerList[77] = "Can I be killed? I'm beginning to wonder.";
$cheerList[78] = "Next time, make me work for it.";
$cheerList[79] = "Am I a giant or did everyone else shrink?";
$cheerList[80] = "Why do you people even bother?";
$cheerList[81] = "Next time, don't bother dodging. Why prolong your agony?";
$cheerList[82] = "What happened?  >:)";
$cheerList[83] = "Mental note to self: Find server with better opponents.";
$cheerList[84] = "Christ people... try playing with a mouse. ";
$cheerList[85] = "Nobody can touch me in this level. ";
$cheerList[86] = "It *hurts* to be this kick-ass!  It *hurts*!";
$cheerList[87] = "I'm like the freaking energizer bunny over here.";
$cheerList[88] = "Why do they ALWAYS try to run??";
$cheerList[89] = "Just like cuttin' down weeds.";
$cheerList[90] = "Get the hell out of my way!";
$cheerList[91] = "Play dead... good boy.";
$cheerList[92] = "Step right up to get knocked right down!";
$cheerList[93] = "That's right, one free asskicking with every purchase.";
$cheerList[94] = "Did I get your attention?";
$cheerList[95] = "Am I evil?  Why, yes I am.";
$cheerList[96] = "Some people just don't die well.";
$cheerList[97] = "Hey look, I can chat while running full tilt!";
$cheerList[98] = "Hey, don't hate me just because you suck.";
$cheerList[99] = "BOW DOWN!";
$cheerList[100] = "He shoots... he SCORES!";
$cheerList[101] = "You should see a doctor about that.";
$cheerList[102] = "Thank you, come again.";
$cheerList[103] = "Down boy...";
$cheerList[104] = "I'm such a bastard. :)";
$cheerList[105] = "Hope you have death and dismemberment insurance.";
$cheerList[106] = "Boy, I'm gonna send this demo to Meanstryk. :)";
$cheerList[107] = "Sorry sir, but thank you for playing.";
$cheerList[108] = "Come on in... the slaughter's fine. ";
$cheerList[109] = "Hi... I'm the enemy.";
$cheerList[110] = "Making people feel bad feels SO good.";
$cheerList[111] = "Hey nice catch!";
$cheerList[112] = "Another one bites the dust.";
$cheerList[113] = "Someone had better dig a mass grave.";
$cheerList[114] = "Can't pay the bills, but damnit, this I can do.";
$cheerList[115] = "What the fuck you think YOU'RE doin'?";
$cheerList[116] = "Come share with me my hurtful thoughts. ";
$cheerList[117] = "Ha!  Somedays it really pays to be a bot.";
$cheerList[118] = "You should stick to Chess.";
$cheerList[119] = "Its frag time. Do you know where you're skill is?";
$cheerList[120] = "Walk into the light ;-)";
$cheerList[121] = "He chose...poorly.";
$cheerList[122] = "I'm immortal!...So far.";
$cheerList[123] = "Nothing can stop me now.";
$cheerList[124] = "I must be butter cause I'm on a roll!";
$cheerList[125] = "DEATH FROM ABOVE!!!";
$cheerList[126] = "I'd trash talk, but I'm too tired...*yawn*";
$cheerList[127] = "One small frag for me, one big head wound for you!";
$cheerList[128] = "All too easy.";
$cheerList[129] = "Come strong or don't come at all!";
$cheerList[130] = "Damnit! You messed my hair up!";

$suckList[0] = "Hmmm.";   	// Hmmm
$suckList[1] = "Damnit!";   	// Dammit!
$suckList[2] = "Ahhh crap!";   	// Ahhh Crap!
$suckList[3] = "Duh!";   	// Duh!
$suckList[4] = "You Idiot!";   	// You Idiot!
$suckList[5] = "AWWWWUUUUHHH!!";   	// AWWWWWUUUUHHH!!
$suckList[6] = "What should I say?";   	// <SIGH resignation of>
$suckList[7] = "Doh!";   	// DOH! 
$suckList[8] = "Ooops!";   	// Ooops!
$suckList[9] = "It's pay-back time!";   	// Ooops!
$suckList[10] = "Elvis has left the building!";
$suckList[11] = "Time to change your diaper.";
$suckList[12] = "In your face bitch... in your face.";
$suckList[13] = "Look out man, I'm back in my zone.  Watch your ass!";
$suckList[14] = "NOW who has the big gun mother-fucker?!?";
$suckList[15] = "Oh, no wonder... I had the safety on...";
$suckList[16] = "Better run. my lag is letting up. ";
$suckList[17] = "Look out, I'm just getting warmed up.";
$suckList[18] = "Looks like there's a new lawman in town, eh?";
$suckList[19] = "Okay, I have your punk-ass figured.";
$suckList[20] = "How the fuck do you like it?";
$suckList[21] = "No more Mr. Nice Guy.";
$suckList[22] = "Oh man, you've had it now.";
$suckList[23] = "Feel that?  That's my foot in your ass.";
$suckList[24] = "Anyone else hear the theme from Rocky?";
$suckList[25] = "Your time's up.";
$suckList[26] = "Okay, now I start playing for real.";
$suckList[27] = "Hurt much?";
$suckList[28] = "My how the mighty have fallen.";
$suckList[29] = "Here's where you get off.";
$suckList[30] = "This aint no petting zoo.";
$suckList[31] = "Ever hear of the golden rule?";
$suckList[32] = "Your bullying days are over.";
$suckList[33] = "Now the shoe's on the other foot.";
$suckList[34] = "Wanna try for two out of three?";
$suckList[35] = "Hah!";
$suckList[36] = "That's what I THOUGHT... loser.";
$suckList[37] = "Memento Mori.";
$suckList[38] = "The man who dies with the most toys still dies!";
$suckList[39] = "I'd give you the finger, but you shot them off.";
$suckList[40] = "Your meaty skull is beautiful to me.";
$suckList[41] = "You all saw him...he had a gun!";
$suckList[42] = "I'm not gonna kill ya. Like hell I'm not!";
$suckList[43] = "Use the Farse, puke!";
$suckList[44] = "Ah...the joy of deathmatch.";
$suckList[45] = "Where's your crown, King Nothing?";
$suckList[46] = "Chill.";
$suckList[47] = "I'm spittin' on your corpse!";
$suckList[48] = "Exit light, enter night.";
$suckList[49] = "Respect my authoritay!";
$suckList[50] = "...and now you're going to die.";

######################################################################################
# The following bot configurations should be used ONLY by admins who know what       #
# they are doing... This can seriously mess up the way the bots in Meltdown/Spoon    #
# Bots work... Please make very sure of what you are doing before you alter any of   #
# these settings!!!  -INH*DynaBlade                                                  #
#                                                                                    #
# The following weapons are for what the bot will use when the enemy is...           #
# The Pack is the pack that the bot will have mounted.                               #
# All items listed here **MUST** be listed in the particular bots inventory below... #
######################################################################################

//=========================== Mortar Gear
$Spoonbot::MortarMArmor  = "harmor";
$Spoonbot::MortarFArmor  = "harmor";
$Spoonbot::MortarGear[0] = "mortar";		$Spoonbot::MortarAmmo[0] = "1";
$Spoonbot::MortarGear[1] = "mortarammo";		$Spoonbot::MortarAmmo[1] = "500";
$Spoonbot::MortarGear[2] = "chaingun";		$Spoonbot::MortarAmmo[2] = "1";
$Spoonbot::MortarGear[3] = "bulletammo";		$Spoonbot::MortarAmmo[3] = "50000";
$SpoonBot::MortarGear[4] = "PlasmaGun";		$Spoonbot::MortarAmmo[4] = "1";
$SpoonBot::MortarGear[5] = "plasmaammo";		$Spoonbot::MortarAmmo[5] = "500";
$Spoonbot::MortarGear[6] = "energypack";		$Spoonbot::MortarAmmo[6] = "1";
$Spoonbot::MortarGear[7] = "";

$Spoonbot::MortarClose = "PlasmaGun"; 
$Spoonbot::MortarLong  = "mortar";
$SpoonBot::MortarJet   = "chaingun";
$Spoonbot::MortarPack  = "energypack";

//=========================== Guard Gear
$Spoonbot::GuardMArmor  = "harmor";
$Spoonbot::GuardFArmor  = "harmor";
$Spoonbot::GuardGear[0] = "mortar";		$Spoonbot::GuardAmmo[0] = "1";
$Spoonbot::GuardGear[1] = "mortarammo";		$Spoonbot::GuardAmmo[1] = "500";
$Spoonbot::GuardGear[2] = "chaingun";		$Spoonbot::GuardAmmo[2] = "1";
$Spoonbot::GuardGear[3] = "bulletammo";		$Spoonbot::GuardAmmo[3] = "50000";
$SpoonBot::GuardGear[4] = "PlasmaGun";		$Spoonbot::GuardAmmo[4] = "1";
$SpoonBot::GuardGear[5] = "plasmaammo";		$Spoonbot::GuardAmmo[5] = "500";
$Spoonbot::GuardGear[6] = "energypack";		$Spoonbot::GuardAmmo[6] = "1";
$Spoonbot::GuardGear[7] = "";

$Spoonbot::GuardClose = "PlasmaGun"; 
$Spoonbot::GuardLong  = "mortar";
$SpoonBot::GuardJet   = "chaingun";
$Spoonbot::GuardPack  = "energypack";

//=========================== Demo Gear
$SpoonBot::DemoMArmor  = "marmor";
$SpoonBot::DemoFArmor  = "mfemale";
$SpoonBot::DemoGear[0] = "PlasmaGun";		$Spoonbot::DemoAmmo[0] = "1";
$SpoonBot::DemoGear[1] = "plasmaammo";		$Spoonbot::DemoAmmo[1] = "500";
$SpoonBot::DemoGear[2] = "disclauncher";	$Spoonbot::DemoAmmo[2] = "1";
$SpoonBot::DemoGear[3] = "discammo";		$Spoonbot::DemoAmmo[3] = "500";
$SpoonBot::DemoGear[4] = "chaingun";		$Spoonbot::DemoAmmo[4] = "1";
$SpoonBot::DemoGear[5] = "bulletammo";		$Spoonbot::DemoAmmo[5] = "50000";
$SpoonBot::DemoGear[6] = "";

$Spoonbot::DemoClose = "Plasmagun";
$Spoonbot::DemoLong  = "disclauncher";
$SpoonBot::DemoJet   = "chaingun";
$Spoonbot::DemoPack  = "energypack";

//=========================== Medic Gear
$SpoonBot::MedicMArmor  = "marmor";
$SpoonBot::MedicFArmor  = "mfemale";
$SpoonBot::MedicGear[0] = "blaster";		$Spoonbot::MedicAmmo[0] = "1";
$SpoonBot::MedicGear[1] = "PlasmaGun";		$Spoonbot::MedicAmmo[1] = "1";
$SpoonBot::MedicGear[2] = "plasmaammo";		$Spoonbot::MedicAmmo[2] = "500";
$SpoonBot::MedicGear[3] = "disclauncher";	$Spoonbot::MedicAmmo[3] = "1";
$SpoonBot::MedicGear[4] = "discammo";		$Spoonbot::MedicAmmo[4] = "500";
$SpoonBot::MedicGear[5] = "repairkit";		$Spoonbot::MedicAmmo[5] = "1";
$SpoonBot::MedicGear[6] = "repairpack";		$Spoonbot::MedicAmmo[6] = "1";
$SpoonBot::MedicGear[7] = "";

$Spoonbot::MedicClose = "PlasmaGun";
$Spoonbot::MedicLong  = "disclauncher";
$SpoonBot::MedicJet   = "blaster";
$Spoonbot::MedicPack  = "repairpack";

//=========================== Miner Gear
$SpoonBot::MinerMArmor  = "larmor";
$SpoonBot::MinerFArmor  = "lfemale";
$SpoonBot::MinerGear[0] = "chaingun";		$Spoonbot::MinerAmmo[0] = "1";
$SpoonBot::MinerGear[1] = "PlasmaGun";		$Spoonbot::MinerAmmo[1] = "1";
$SpoonBot::MinerGear[2] = "plasmaammo";		$Spoonbot::MinerAmmo[2] = "500";
$SpoonBot::MinerGear[3] = "energypack";		$Spoonbot::MinerAmmo[3] = "1";
$SpoonBot::MinerGear[4] = "repairkit";		$Spoonbot::MinerAmmo[4] = "1";
$SpoonBot::MinerGear[5] = "bulletammo";		$Spoonbot::MinerAmmo[5] = "50000";
$SpoonBot::MinerGear[6] = "grenadelauncher";	$Spoonbot::MinerAmmo[6] = "1";
$SpoonBot::MinerGear[7] = "grenadeammo";	$Spoonbot::MinerAmmo[7] = "5000";
$SpoonBot::MinerGear[9] = "";

$Spoonbot::MinerClose = "PlasmaGun";
$Spoonbot::MinerLong  = "grenadelauncher";
$SpoonBot::MinerJet   = "chaingun";
$Spoonbot::MinerPack  = "energypack";

//=========================== Sniper Gear
$SpoonBot::SniperMArmor  = "larmor";
$SpoonBot::SniperFArmor  = "lfemale";
$SpoonBot::SniperGear[0] = "PlasmaGun";		$Spoonbot::SniperAmmo[0] = "1";
$SpoonBot::SniperGear[1] = "plasmaammo";	$Spoonbot::SniperAmmo[1] = "500";
$SpoonBot::SniperGear[2] = "LaserRifle";	$Spoonbot::SniperAmmo[2] = "1";
$SpoonBot::SniperGear[3] = "energypack";	$Spoonbot::SniperAmmo[3] = "1";
$SpoonBot::SniperGear[4] = "";

$Spoonbot::SniperClose = "PlasmaGun";
$Spoonbot::SniperLong  = "LaserRifle";


$SpoonBot::SniperJet   = "LaserRifle";
$Spoonbot::SniperPack  = "energypack";

//=========================== Painter Gear
$SpoonBot::PainterMArmor  = "larmor";
$SpoonBot::PainterFArmor  = "lfemale";
$SpoonBot::PainterGear[0] = "TargetingLaser";	$Spoonbot::PainterAmmo[0] = "1";
$SpoonBot::PainterGear[1] = "PlasmaGun";	$Spoonbot::PainterAmmo[1] = "1";
$SpoonBot::PainterGear[2] = "plasmaammo";	$Spoonbot::PainterAmmo[2] = "500";
$SpoonBot::PainterGear[3] = "disclauncher"; 	$Spoonbot::PainterAmmo[3] = "1";
$SpoonBot::PainterGear[4] = "discammo";		$Spoonbot::PainterAmmo[4] = "500";
$SpoonBot::PainterGear[5] = "";

$Spoonbot::PainterClose = "PlasmaGun";
$Spoonbot::PainterLong  = "TargetingLaser";
$SpoonBot::PainterJet   = "DiscLauncher";
$Spoonbot::PainterPack  = "";

//=========================== Standard Gear -- Used if Bot has no preset name...
$SpoonBot::StandardMArmor  = "marmor";
$SpoonBot::StandardFArmor  = "mfemale";
$SpoonBot::StandardGear[0] = "energypack";		$Spoonbot::StandardAmmo[0] = "1";
$SpoonBot::StandardGear[1] = "PlasmaGun";		$Spoonbot::StandardAmmo[1] = "1";
$SpoonBot::StandardGear[2] = "plasmaammo";		$Spoonbot::StandardAmmo[2] = "500";
$SpoonBot::StandardGear[3] = "disclauncher";		$Spoonbot::StandardAmmo[3] = "1";
$SpoonBot::StandardGear[4] = "discammo";		$Spoonbot::StandardAmmo[4] = "500";
$SpoonBot::StandardGear[5] = "chaingun";		$Spoonbot::StandardAmmo[5] = "1";
$SpoonBot::StandardGear[6] = "bulletammo";		$Spoonbot::StandardAmmo[6] = "5000";
$SpoonBot::StandardGear[7] = "";

$Spoonbot::StandardClose = "PlasmaGun";
$Spoonbot::StandardLong  = "disclauncher";
$SpoonBot::StandardJet   = "chaingun";
$Spoonbot::StandardPack  = "energypack";

