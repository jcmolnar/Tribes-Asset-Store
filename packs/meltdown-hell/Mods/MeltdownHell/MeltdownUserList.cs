################################################################################
# Meltdown Admin User List    			                               #
#==============================================================================#
# Made and tested by INH*DynaBlade 								 #
# People who contributed: Chivalry DEV Team (proud member), <SSA>, Emo1313,    #
# Shayne Hyde and [HvC]NateDoGG 								 #
# Email: dynablade@clannorthwind.net							 #
################################################################################

$CurAdminName = "Meltdown";  			// The Auto-Admin name that prompts you when you've been auto-admined by that name.

// Activated
// 	1 = Yes you are using the list.
//	0 = No you are NOT using the list.
$UserList::Activated = 1;

// Set this to the number of users in your list.
$UserList::MaxUsers = 4;

//The Actual User.
//$UserList::User[1] = "<UserNumber> <UserName> <UserPassword> <AccessLevel> <IP Masks>";
//
//<UserNumber> 	= What is this users Usernumber. 
//
//<UserName> 	= What is this Users Regular Name. 
//		  (HAS TO BE ONE WORD - NO Spaces)
//
//<UserPassword>	= What this user's SAD() Password is. 
//		  (HAS TO BE ONE WORD - NO Spaces)
//
//<AccessLevel>  = What Access do they have. Choices are:
//		  AutoSuper 	- Automatically gives the user Super Admin status. 
//		  AutoPublic 	- Automatically gives the user Public Admin status. 
//				   If the password is identical to any $HaVoC::PAPassword[]
//				   the user will use special lockouts, if available.  Else
//				   they get the default PA lockouts.
//
//<IP Masks> 	= What IP or IPs you want to list for that user. you can list
//		  as many IPs as you want. The only wildcard accepted is * 
//		  For Example:
//			User's actual IP = 172.16.0.1
//			Successful IP Mask = 172.16.*.*
//		  When using the * that will allow any number for that part of the IP. 
//		  Please be aware of the consequences of using wildcards and autoadmin. 
//		  You may give a whole ISP control of your server, or even the whole planet. 
//

#================================ Place HaVoC-Admin Data here ================================#




#================================ Place HaVoC-Admin Data here ================================#

#######################################################
# Server Public Admin (PA) Passwords                  #
# Great for those clan Members who want Admin         #
# Usage: (console) sad("Password");                   # 
# You can add up to 96 differrent PA passwords (0-95) #
#######################################################

$Meltdown::PAPassword[0] = "";
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

$Meltdown::SadPassword[0] = "";
$Meltdown::SadPassword[1] = "";
$Meltdown::SadPassword[2] = "";
$Meltdown::SadPassword[3] = "";
$Meltdown::SadPassword[4] = "";
$Meltdown::SadPassword[5] = "";
$Meltdown::SadPassword[6] = "";
$Meltdown::SadPassword[7] = "";

######################################################################
# Server Auto-admin Variables                                        #
# Add your ppl who you want to admin when they connect to the server #
# You can have as many as 128 different auto-admin names             #
######################################################################

$CurAdminName = "Meltdown";  			// The Auto-Admin name that prompts you when you've been auto-admined by that name.

$Server::AutoAdmin[0] = "";
$Server::AutoAdmin[1] = "";
$Server::AutoAdmin[2] = "";
$Server::AutoAdmin[3] = "";
$Server::AutoAdmin[4] = "";
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

$Server::AutoAdminAddr[0] = "";
$Server::AutoAdminAddr[1] = "";
$Server::AutoAdminAddr[2] = "";
$Server::AutoAdminAddr[3] = "";
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
