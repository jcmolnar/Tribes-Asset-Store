  ////////////////////////////////////////////////////////// 
//////////  Code for V1 of "Extreme Frisbee"  ////////////////
 //////////       Code by: CaN-O-SpAm        ////////////////
//////////  e-mail:gilthri@unforgettable.com  ////////////////
  //////////////////////////////////////////////////////////

//---------- General Stuff (ie. flag return time/shopping list/spawnlist/team skins/MOTD/warmup time/max hold etc.) -------------------------------------------------------------

$flagCatchIndex = 0;		//So we can tell if someone else has picked it up



$flagMaxHoldTime = 10;	//Time before we force the player to throw the flag
$flagReturnTime = 35;   //------- was  45

$ItemFavoritesKey = "frisbeeV1";  

$spawnBuyList[0] = LightArmor;
$spawnBuyList[1] = TargetingLaser;
$spawnBuyList[2] = EnergyPack;
$spawnBuyList[3] = RepairKit;
$spawnBuyList[4] = Grenade;
$spawnBuyList[5] = "";

//$Server::teamName[0] = "Alpha Alliance";
//$Server::teamSkin[0] = "swolf";
//$Server::teamName[1] = "Beta Brood";
//$Server::teamSkin[1] = "dsword";

//$Server::JoinMOTD = "Extreme Tribes Frisbee!";

$Server::JoinMsgDelay = 0.5;
$Server::JoinMsgHeight = 9;
$Server::JoinMsgLength = 18;
$Server::JoinMsg[0] = "<jc><f3>Extreme Frisbee";
$Server::JoinMsg[1] = "<jc><f1>for StarSiege Tribes";
$Server::JoinMsg[2] = "<jc><f2>version 1";
$Server::JoinMsg[3] = "";
$Server::JoinMsg[4] = "<jc><f3>Goal";
$Server::JoinMsg[5] = "<jc><f1>Help your team carry the frisbee into the enemy goal area";
$Server::JoinMsg[6] = "";
$Server::JoinMsg[7] = "<jc><f3>Keys";
$Server::JoinMsg[8] = "<jc><f1>Control+f throws the frisbee";
$Server::JoinMsg[9] = "";
$Server::JoinMsg[10] = "<jc><f3>Credits";
$Server::JoinMsg[11] = "<jc><f1>Programing: |-CaN-O-SpAm-|";
$Server::JoinMsg[12] = "";
$Server::JoinMsg[13] = "<jc><f3>Play Testing";
$Server::JoinMsg[14] = "<jc><f1>Jabbering~Ewok, Krage, Syntax451 and many others";
$Server::JoinMsg[15] = "";
$Server::JoinMsg[16] = "<jc><f3>Special Thanks";
$Server::JoinMsg[17] = "<jc><f1>Screw Terminal, Dynamix and the Tribes community";

$Server::warmupTime = 5;

//------------------------------------------------ Inv Station Lists ---------------------

// List of all items available to buy from inventory station-------
$InvList[Blaster] = 0;
$InvList[Chaingun] = 0;
$InvList[Disclauncher] = 0;
$InvList[GrenadeLauncher] = 0;
$InvList[Mortar] = 0;
$InvList[PlasmaGun] = 0;
$InvList[LaserRifle] = 0;
$InvList[EnergyRifle] = 0;
$InvList[TargetingLaser] = 1;
$InvList[MineAmmo] = 0;
$InvList[Grenade] = 1;
$InvList[Beacon] = 0;

$InvList[BulletAmmo] = 0;
$InvList[PlasmaAmmo] = 0;
$InvList[DiscAmmo] = 0;
$InvList[GrenadeAmmo] = 0;
$InvList[MortarAmmo] = 0;
  
$InvList[EnergyPack] = 1;
$InvList[RepairPack] = 1;
$InvList[ShieldPack] = 1;
$InvList[SensorJammerPack] = 1;
$InvList[MotionSensorPack] = 1;
$InvList[PulseSensorPack] = 1;
$InvList[DeployableSensorJammerPack] = 1;
$InvList[CameraPack] = 1;
$InvList[TurretPack] = 0;
$InvList[AmmoPack] = 0;
$InvList[RepairKit] = 1;
$InvList[DeployableInvPack] = 0;
$InvList[DeployableAmmoPack] = 0;



// List of all items available to buy from Remote Station-----------------
$RemoteInvList[Blaster] = 0;
$RemoteInvList[Chaingun] = 0;
$RemoteInvList[Disclauncher] = 0;
$RemoteInvList[GrenadeLauncher] = 0;
$RemoteInvList[Mortar] = 0;
$RemoteInvList[PlasmaGun] = 0;
$RemoteInvList[LaserRifle] = 0;
$RemoteInvList[EnergyRifle] = 0;
$RemoteInvList[TargetingLaser] = 1;
$RemoteInvList[MineAmmo] = 0;
$RemoteInvList[Grenade] = 1;
$RemoteInvList[Beacon] = 0;

$RemoteInvList[BulletAmmo] = 0;
$RemoteInvList[PlasmaAmmo] = 0;
$RemoteInvList[DiscAmmo] = 0;
$RemoteInvList[GrenadeAmmo] = 0;
$RemoteInvList[MortarAmmo] = 0;
  
$RemoteInvList[EnergyPack] = 1;
$RemoteInvList[RepairPack] = 1;
$RemoteInvList[ShieldPack] = 1;
$RemoteInvList[SensorJammerPack] = 1;
$RemoteInvList[MotionSensorPack] = 1;
$RemoteInvList[PulseSensorPack] = 1;
$RemoteInvList[DeployableSensorJammerPack] = 1;
$RemoteInvList[CameraPack] = 1;
$RemoteInvList[TurretPack] = 0;
$RemoteInvList[AmmoPack] = 0;
$RemoteInvList[RepairKit] = 1;


//------------ New Game::initialMissionDrop(%clientId) function & scrolling code ------------------------------------------

function Game::initialMissionDrop(%clientId)
{
	Client::setGuiMode(%clientId, $GuiModePlay);

   if($Server::TourneyMode)
      GameBase::setTeam(%clientId, -1);
   else
   {
      if(%clientId.observerMode == "observerFly" || %clientId.observerMode == "observerOrbit")
      {
	      %clientId.observerMode = "observerOrbit";
	      %clientId.guiLock = "";
         Observer::jump(%clientId);
         return;
      }
      %numTeams = getNumTeams();
      %curTeam = Client::getTeam(%clientId);

      if(%curTeam >= %numTeams || (%curTeam == -1 && (%numTeams < 2 || $Server::AutoAssignTeams)) )
         Game::assignClientTeam(%clientId);
   }    
	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
   %camSpawn = Game::pickObserverSpawn(%clientId);
   Observer::setFlyMode(%clientId, GameBase::getPosition(%camSpawn), 
	   GameBase::getRotation(%camSpawn), true, true);

   if(Client::getTeam(%clientId) == -1)
   {
      %clientId.observerMode = "pickingTeam";

      if($Server::TourneyMode && ($matchStarted || $matchStarting))
      {
         %clientId.observerMode = "observerFly";
         return;
      }
      else if($Server::TourneyMode)
      {
         if($Server::TeamDamageScale)
            %td = "ENABLED";
         else
            %td = "DISABLED";
         bottomprint(%clientId, "<jc><f1>Server is running in Competition Mode\nPick a team.\nTeam damage is " @ %td, 0);
      }
      Client::buildMenu(%clientId, "Pick a team:", "InitialPickTeam");
      Client::addMenuItem(%clientId, "0Observe", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      %clientId.justConnected = "";
   }
   else 
   {
      Client::setSkin(%clientId, $Server::teamSkin[Client::getTeam(%clientId)]);
      if(%clientId.justConnected)
      {
	 //centerprint(%clientId, $Server::JoinMOTD, 0);
         %clientId.justConnected = 100 - $Server::JoinMsgHeight;
         %clientId.observerMode = "justJoined";
           Game::msgScroller(%clientId);                         //Start the scrolling message!
      }
      else if(%clientId.observerMode == "justJoined")
      {
         centerprint(%clientId, "");
         %clientId.justConnected = "";
         %clientId.observerMode = "";
         Game::playerSpawn(%clientId, false);
      }
      else
         Game::playerSpawn(%clientId, false);
	}
	if($TeamEnergy[Client::getTeam(%clientId)] != "Infinite")
		$TeamEnergy[Client::getTeam(%clientId)] += $InitialPlayerEnergy;
	%clientId.teamEnergy = 0;
}


function Game::msgScroller(%clientId)
{
        if (%clientId.observerMode != "justJoined") {
                centerprint(%clientId, "", 0);
                return;
        }

	%msg = "";
	%clientId.justConnected = %clientId.justConnected + 1;
        if (%clientId.justConnected - 100 > $Server::JoinMsgLength) %clientId.justConnected = 100 - $Server::JoinMsgHeight;
//        if (%clientId.justConnected - 100 < $Server::JoinMsgLength) {
                for (%i = 0; %i < $Server::JoinMsgHeight ; %i = %i + 1) { 
                  if (%clientId.justConnected + %i - 100 > $Server::JoinMsgLength || %clientId.justConnected + %i - 100 < 0) {
				%msg=%msg @ "\n";
			} else {
                                %msg=%msg @ $Server::JoinMsg[%clientId.justConnected + %i - 100] @ "\n";
			}
		}
                schedule("Game::msgScroller(" @ %clientId @ ");", $Server::JoinMsgDelay);
//        }
	centerprint(%clientId, %msg, 0);
}

//------------ Code to make the flag into a frisbee (No new object, just replace flag so that caps still work --------

ItemImageData FlagImage
{
	shapeFile = "discb";
	mountPoint = 2;
	mountOffset = { -0.4, 0.3, 0.8 };
	mountRotation = { 0, -1, 0 };

	lightType = 2;   // Pulsing
	lightRadius = 12;
	lightTime = 0.3;
	lightColor =  { 0.4, 0.4, 1.0 };

};

ItemData Flag
{
	description = "flag";
	shapeFile = "discb";
	imageType = FlagImage;
	showInventory = true;
	shadowDetailMask = 4;

      mass               = 0.35;
   	inheritedVelocityScale = 0.1;
	elasticity         = 0.2;

	lightType = 2;   // Pulsing
	lightRadius = 12;
	lightTime = 0.3;
	lightColor = { 0.4, 0.4, 1 };

};

//----------The funtion for Caping with a flag stand (ie. in F&R) -------------------------------------------------

function FlagStand::onCollision(%this, %object)
{
   //echo("FlagStand collision ", %object);
   %standTeam = GameBase::getTeam(%this);
   %playerTeam = GameBase::getTeam(%object);

   if(%standTeam == -1 || getObjectType(%object) != "Player" || %object.carryFlag == ""
         || %playerTeam != %standTeam || %this.flag != "" || GameBase::getTeam(%object.carryFlag) != -1)
      return;

   // if we're here, we're carrying a flag, we've hit 
   // our flag stand, it doesn't have a flag, and we're not carrying
   // a team coded flag.

   %flag = %object.carryFlag;
   %flag.carrier = -1;
   Item::hide(%flag, false);
   GameBase::setPosition(%flag, GameBase::getPosition(%this));
	%flag.flagStand = %this;

   Player::setItemCount(%object, Flag, 0);
   %object.carryFlag = "";
   %playerClient = Player::getClient(%object);
   Flag::clearWaypoint(%playerClient, true);

   $teamScore[%playerTeam] += %flag.scoreValue;
   $deltaTeamScore[%playerTeam] += %flag.deltaTeamScore;
   %flag.holder = %this;
   %flag.holdingTeam = %playerTeam;
   %this.flag = %flag;

//frisbee carrier gets 10 points
               %playerClient.score += 10;
               Game::refreshClientScore(%playerClient);
               messageAll(0, Client::getName(%playerClient) @ " receives a 10 point goal bonus, and is transported to the center of the field.");

		GameBase::setPosition(%playerClient, %flag.originalPosition); //---------------------------- Teleporter code for after cap
            Item::setVelocity(%playerClient, "0 0 0");	              //---------------------------- set vel of player

		Player::setArmor(%playerClient,$ArmorType[Client::getGender(%playerClient), LightArmor]);
		armorChange(%playerClient);

   MessageAllExcept(%playerClient, 0, Client::getName(%playerClient) @ " stuffs " @ %flag.objectiveName @ " into the enemy goal.");
   Client::sendMessage(%playerClient, 0, "You carried " @ %flag.objectiveName @ " into the enemy goal.");
   TeamMessages(1, %playerTeam, "Your team put " @ %flag.objectiveName @ " into the enemy goal.~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team put " @ %flag.objectiveName @ " into your goal.~wflagcapture.wav");

   %flag.trainingObjectiveComplete = true;
   ObjectiveMission::ObjectiveChanged(%flag);
   ObjectiveMission::checkScoreLimit();
}

//-------------------------------- Flag Collition ----------------------------------------------------------------

function Flag::onCollision(%this, %object)
{
   //echo("Flag collision ", %object);
   if(getObjectType(%object) != "Player")
      return;

   if(%this.carrier != -1)
      return; // spurious collision
      
   if(Player::isAIControlled(%object))
   	return;   
      
   %name = Item::getItemData(%this);
   %playerTeam = GameBase::getTeam(%object);
   %flagTeam = GameBase::getTeam(%this);
   %playerClient = Player::getClient(%object);
   %touchClientName = Client::getName(%playerClient);
							 

   if(%flagTeam == %playerTeam)
   {
      // player is touching his own flag...
      if(!%this.atHome)
      {
         // the flag isn't home! so return it.
			GameBase::startFadeOut(%this);
			GameBase::setPosition(%this, %this.originalPosition);
         Item::setVelocity(%this, "0 0 0");
			GameBase::startFadeIn(%this);
         %this.atHome = true;
         MessageAllExcept(%playerClient, 0, %touchClientName @ " returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         Client::sendMessage(%playerClient, 0, "You returned the " @ getTeamName(%playerTeam) @ " flag!~wflagreturn.wav");
         teamMessages(1, %playerTeam, "Your flag was returned to base.", -2, "", "The " @ getTeamName(%playerTeam) @ " flag was returned to base.");
         %this.pickupSequence++;
         ObjectiveMission::ObjectiveChanged(%this);
      }
      else
      {
         // it's at home - see if we have an enemy flag!
         if(%object.carryFlag != "")
         {
            // can't cap the neutral flags, duh
           	%enemyTeam = GameBase::getTeam(%object.carryFlag);
			   if(%enemyTeam != -1)
            {
               MessageAllExcept(%playerClient, 0, %touchClientName @ " captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
               Client::sendMessage(%playerClient, 0, "You captured the " @ getTeamName(%enemyTeam) @ " flag!~wflagcapture.wav");
               TeamMessages(1, %playerTeam, "Your team captured the flag.", %enemyTeam, "Your team's flag was captured.");
            
               %flag = %object.carryFlag;
               %flag.atHome = true;
               %flag.carrier = -1;
               %flag.caps[%playerTeam]++;
               %flag.enemyCaps++;
               
               
               Item::hide(%flag, false);
               $flagAtHome[1] = true;
               GameBase::setPosition(%flag, %flag.originalPosition);
               Item::setVelocity(%flag, "0 0 0");

               %flag.trainingObjectiveComplete = true;
               ObjectiveMission::ObjectiveChanged(%flag);

               Player::setItemCount(%object, Flag, 0);
               %object.carryFlag = "";
               Flag::clearWaypoint(%playerClient, true);

               $teamScore[%playerTeam] += %flag.scoreValue;
               ObjectiveMission::checkScoreLimit();

               //flag carrier gets 5 points for caputure
               %playerClient.score += 5;
               Game::refreshClientScore(%playerClient);
               messageAll(0, Client::getName(%playerClient) @ " receives 5 point capture bonus.");
            }
         }
      }
   }
   else
   {
      // it's an enemy's flag! woohoo!
      if(%object.carryFlag == "")
      {
			if(%object.outArea == "") {
				// don't pick up our flags
        		if(%this.holdingTeam == %playerTeam)
        		   return;

        		Player::setItemCount(%object, Flag, 1);
        		Player::mountItem(%object, Flag, $FlagSlot, %flagTeam);
        		Item::hide(%this, true);
        		$flagAtHome[1] = false;
        		%this.atHome = false;
        		%this.carrier = %object;
        		%this.pickupSequence++;
        		%object.carryFlag = %this;
	 			Flag::setWaypoint(%playerClient, %this);
	 
	 			if(%this.fadeOut) {
					GameBase::startFadeIn(%this);
	 				%this.fadeOut= "";
				}
        		if(%flagTeam != -1)
        		{
	     		   MessageAllExcept(%playerClient, 0, %touchClientName @ " took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   Client::sendMessage(%playerClient, 0, "You took the " @ getTeamName(%flagTeam) @ " flag! ~wflag1.wav");
        		   TeamMessages(1, %playerTeam, "Your team has the " @ getTeamName(%flagTeam) @ " flag.", %flagTeam, "Your team's flag has been taken.");
        		}
        		else
        		{
        		   %hteam = %this.holdingTeam;
	     		   if(%hteam != -1)
        		   {
        	//	      $teamScore[%hteam] -= %this.scoreValue;
        	//	      $deltaTeamScore[%hteam] -= %this.deltaTeamScore;

     		            MessageAllExcept(%playerClient, 0, %touchClientName @ " retrieved " @ %this.objectiveName @ " from his team's goal.~wflag1.wav");	//(%hteam)
        		      Client::sendMessage(%playerClient, 0, "You retrieved " @ %this.objectiveName @ " from your goal.~wflag1.wav");
        		      TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", %hteam, "Your team lost " @ %this.objectiveName @ ".", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ " from the " @ getTeamName(%hteam) @ " team.");
				
				Flag::incCatchIndex();

				schedule("Flag::forceDrop(" @ %object @ ", " @ %this @ ", " @ $flagCatchIndex @ ");", $flagMaxHoldTime);
			
				Player::setArmor(%playerClient,$ArmorType[Client::getGender(%playerClient), HeavyArmor]);
				armorChange(%playerClient);

        		      %this.holdingTeam = -1;
        		      %this.holder.flag = "";


        		   }
        		   else
        		   {
	     		      MessageAllExcept(%playerClient, 0, %touchClientName @ " caught " @ %this.objectiveName @ ".~wflag1.wav");
				TeamMessages(1, %playerTeam, "Your team has " @ %this.objectiveName @ ".", -2, "", "The " @ getTeamName(%playerTeam) @ " team has taken " @ %this.objectiveName @ ".");
//frisbee catcher gets 0.5 points
	%playerClient.score += 0.5;
      Game::refreshClientScore(%playerClient);

		bottomprint(%playerClient, "<jc><f1>You caught the Frisbee!<f2> Control+f<f1> passes it!\nYou are a heavy and have 10 seconds to pass the Frisbee!\nYou get 0.5 a point bonus for catching the Frisbee", 10); //------------------ Meassage to palyer clientId

// 			      Client::sendMessage(%playerClient, 0, "You get a 0.5 point bonus for having caught the flag.");
//        		      Client::sendMessage(%playerClient, 0, "You caught " @ %this.objectiveName @ ". Press Control+f to throw it.~wflag1.wav");
				
				Flag::incCatchIndex();

				schedule("Flag::forceDrop(" @ %object @ ", " @ %this @ ", " @ $flagCatchIndex @ ");", $flagMaxHoldTime);

				Player::setArmor(%playerClient,$ArmorType[Client::getGender(%playerClient), HeavyArmor]);
				armorChange(%playerClient);

        
			   }
        		}
        		%this.trainingObjectiveComplete = true;
        		ObjectiveMission::ObjectiveChanged(%this);
			}
			else
  		      Client::sendMessage(%playerClient, 1, "The Frisbee is not in the playing field. Please be patient, and it will be returned to the center of the playing field.");
		}
   }
}

function Flag::incCatchIndex() 
{
	$flagCatchIndex++;
	if ($flagCatchIndex >= 32760) $flagCatchIndex=0;
//	echo($flagCatchIndex);
}


function Flag::forceDrop(%object, %this , %Index)
{
	if (%Index == $flagCatchIndex) Flag::onDrop(%object, %this);
//	echo(%Index);
}

//--------------------- Flag dropped

function Flag::onDrop(%player, %type)
{
	Flag::incCatchIndex();
   %playerTeam = GameBase::getTeam(%player);
   %flag = %player.carryFlag;
   %flagTeam = GameBase::getTeam(%flag);
   %playerClient = Player::getClient(%player);
   %dropClientName = Client::getName(%playerClient);

	Player::setArmor(%playerClient,$ArmorType[Client::getGender(%playerClient), LightArmor]);
	armorChange(%playerClient);

	bottomprint(%playerClient, "<jc><f1>You have passed the Frisbee", 5); //------------------ Meassage to palyer clientId

   if(%flagTeam == -1)
   {
      MessageAllExcept(%playerClient, 1, %dropClientName @ " passed " @ %flag.objectiveName @ "!");
//      Client::sendMessage(%playerClient, 1, "You dropped "  @ %flag.objectiveName @ "!");
   }
   else
   {
      MessageAllExcept(%playerClient, 0, %dropClientName @ " dropped the " @ getTeamName(%flagTeam) @ " flag!");
      Client::sendMessage(%playerClient, 0, "You dropped the " @ getTeamName(%flagTeam) @ " flag!");
      TeamMessages(1, %flagTeam, "Your flag was dropped in the field.", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was dropped in the field.");
   }
   GameBase::throw(%flag, %player, 10, false);
   Item::hide(%flag, false);
   Player::setItemCount(%player, "Flag", 0);
   %flag.carrier = -1;
   %player.carryFlag = "";
   Flag::clearWaypoint(%playerClient, false);

   schedule("Flag::checkReturn(" @ %flag @ ", " @ %flag.pickupSequence @ ");", $flagReturnTime);
	%flag.dropFade = 1;
   ObjectiveMission::ObjectiveChanged(%flag);
}



//------------------------ Called when one leaves the mission area -------------------------

function Flag::playerLeaveMissionArea(%this, %playerId)
{
   // if a guy leaves the area, warp the flag back to its base
   if(%this.carrier == %playerId)
   {
		GameBase::startFadeOut(%this);
      Player::setItemCount(%playerId, "Flag", 0);
		%playerClient = Player::getClient(%playerId);
	 	%clientName = Client::getName(%playerClient);
   	%flagTeam = GameBase::getTeam(%this);
  	   if(%flagTeam == -1 && (%this.flagStand == "" || (%this.flagStand).flag != "") ) 
   	{
      	MessageAllExcept(%playerClient, 0, %clientName @ " left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
      	Client::sendMessage(%playerClient, 0, "You left the mission area while carrying " @ %this.objectiveName @ "!  It was returned to its initial position.");
			GameBase::setPosition(%this, %this.originalPosition);
         Item::setVelocity(%this, "0 0 0");
			%this.flagStand = "";
   	}
   	else
   	{
			if(%flagTeam != -1) {
				%team = %flagTeam;
				GameBase::setPosition(%this, %this.originalPosition);
            Item::setVelocity(%this, "0 0 0");
			}
			else {
				%team = GameBase::getTeam(%this.flagStand);
				GameBase::setPosition(%this, %this.originalPosition);
            Item::setVelocity(%this, "0 0 0");
			}
			MessageAllExcept(%playerClient, 0, %clientName @ " left the mission area while carrying the Frisbee!");
      	Client::sendMessage(%playerClient, 0, "You left the mission area while carrying the Frisbee!");
      	TeamMessages(1, %team, "The Frisbee was returned to the center of the field.~wflagreturn.wav", -2, "", "The Frisbee was returned to the center of the field.");
	      %holdTeam = GameBase::getTeam(%this.flagStand);
	   	$teamScore[%holdTeam] += %this.scoreValue;
	   	$deltaTeamScore[%holdTeam] += %this.deltaTeamScore;
			%this.holder = %this.flagStand;
   		%this.flagStand.flag = %this;
			%this.holdingTeam = %holdTeam;
		}
		GameBase::startFadeIn(%this);
      %this.carrier = -1;
		Item::hide(%this, false);

		%playerId.carryFlag = "";
      Flag::clearWaypoint(%playerClient, false);
      ObjectiveMission::ObjectiveChanged(%this);
		ObjectiveMission::checkScoreLimit();
   }
}


//--------------------- Exit mission area=kill ----------------------------
//Player has a total of 10 seconds per life allowed outside designated mission area.
//After a player expends this 10 sec, the player is remotely killed.
//-lesson to be learned= stay in the mission area!

function Player::leaveMissionArea(%player)
{
   %cl = Player::getClient(%player);
	Client::sendMessage(%cl,1,"You have left the playing field.");
	%player.outArea=1;
	alertPlayer(%player, 3);
}

//checking for timeout of dieSeqCount
function Player::checkLMATimeout(%player, %seqCount)
{
   echo("checking player timeout " @ %player @ " " @ %seqCount);
   if(%player.dieSeqCount == %seqCount)
      remoteKill(Player::getClient(%player));
}

//called if player leaves mission area
function Player::enterMissionArea(%player)
{
   %player.outArea="";
   %player.dieSeqCount = 0;
   %player.timeLeft = %player.timeLeft - (getSimTime() - %player.leaveTime);
}
  
function alertPlayer(%player, %count)
{
	if(%player.outArea == 1) {
		%clientId = Player::getClient(%player);
	  	Client::sendMessage(%clientId,1,"~wLeftMissionArea.wav");
		if(%count > 1)
		   schedule("alertPlayer(" @ %player @ ", " @ %count - 1 @ ");",1.5,%clientId);
		else 
	   	schedule("leaveMissionAreaDamage(" @ %clientId @ ");",1,%clientId);
	}
}

function leaveMissionAreaDamage(%client)
{
	%player = Client::getOwnedObject(%client);
	if(%player.outArea == 1) {
		if(!Player::isDead(%player)) {
		  	Player::setDamageFlash(%client,0.1);
			GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
	   	schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
		}
		else { 
			playNextAnim(%client);	
			Client::onKilled(%client, %client);
		}
	}
}

//----------------------- Returns the falg after a time out -------------------------------------------------------

function Flag::checkReturn(%flag, %sequenceNum)
{
   //echo("checking for flag return: ", %flag, ", ", %sequenceNum);
   if(%flag.pickupSequence == %sequenceNum)
   {
		if(%flag.dropFade) { 
			GameBase::startFadeOut(%flag);
		  	%flag.dropFade= "";
			%flag.fadeOut= 1;
		   schedule("Flag::checkReturn(" @ %flag @ ", " @ %sequenceNum @ ");", 2.5);
		}
		else {
   	   %flagTeam = GameBase::getTeam(%flag);
   	   if(%flagTeam == -1)
   	   {
   	      if(%flag.flagStand == "" || %flag.flagStand.flag != "") {
					MessageAll(0, %flag.objectiveName @ " was returned to its initial position.");
				   GameBase::setPosition(%flag, %flag.originalPosition);
               Item::setVelocity(%flag, "0 0 0");
				   %flag.flagStand = "";
   			}
   			else
   			{
   	         %holdTeam = GameBase::getTeam(%flag.flagStand);
					TeamMessages(0, %holdTeam, "The Frisbee was returned to center field.~wflagreturn.wav", -2, "", "The Frisbee was returned to center field.~wflagreturn.wav");
				   GameBase::setPosition(%flag, %flag.originalPosition);
               %flag.flagStand.flag = %flag;
				   %flag.holdingTeam = %holdTeam;
				   %flag.carrier = -1;
				   $teamScore[%holdTeam] += %flag.scoreValue;
				   $deltaTeamScore[%holdTeam] += %flag.deltaTeamScore;
				   %flag.holder = %flag.flagStand;
				   TeamMessages(0,%holdTeam, "Your team holds " @ %flag.objectiveName @ ".~wflagcapture.wav", -2, "", "The " @ getTeamName(%playerTeam) @ " team holds " @ %flag.objectiveName @ ".");
				   ObjectiveMission::checkScoreLimit();
			   }
			}
         else
         {
   	      TeamMessages(0, %flagTeam, "Your flag was returned to base.~wflagreturn.wav", -2, "", "The " @ getTeamName(%flagTeam) @ " flag was returned to base.~wflagreturn.wav");
				GameBase::setPosition(%flag, %flag.originalPosition);
            Item::setVelocity(%flag, "0 0 0");
         }
         %flag.atHome = true;
			GameBase::startFadeIn(%flag);
   	   %flag.fadeOut= "";
			ObjectiveMission::ObjectiveChanged(%flag);
		}
   }
}

//---------------------------------- Sets up the Objective screen ------------------------------------------------

function Flag::getObjectiveString(%this, %forTeam)
{
   %thisTeam = GameBase::getTeam(%this);
   //echo("Flag objectiveString");
   
   if($missionComplete)
   {
      if(%thisTeam == -1)
      {
         if(%this.holdingTeam == %forTeam && %forTeam != -1)
            return "<Bflag_atbase.bmp>\nYour team finished the mission in control of " @ %this.objectiveName @ ".";
         else if(%this.holdingTeam == -1)
            return "<Bflag_neutral.bmp>\nNo team finished the mission in control of " @ %this.objectiveName @ ".";
         else {
				if(%forTeam != -1)
					return "<Bflag_enemycaptured.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
      		else
					return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team finished the mission in control of " @ %this.objectiveName @ ".";
			}
		}
      else if(%forTeam != -1)
      {
         if(%thisTeam == %forTeam)
            return "<Bflag_atbase.bmp>\nYour flag was captured " @ %this.enemyCaps @ " times.";
         else
            return "<Bflag_enemycaptured.bmp>\nYour team captured the " @ getTeamName(%thisTeam) @ " flag " @ %this.caps[%forTeam] @ " times.";
      }
  		else 
      	return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ "'s flag was captured " @ %this.enemyCaps @ " times.";
   }
   else
   {
      if(%thisTeam == -1)
      {
			if(%forTeam != -1) {
         	if(%this.holdingTeam == %forTeam)
         	   return "<Bflag_atbase.bmp>\nGet ready to get to steal the Frisbee from the other team.";
         	else if(%this.holdingTeam != -1)
         	   return "<Bflag_enemycaptured.bmp>\nGrab " @ %this.objectiveName @ " from your goal and take it up the field.";
         	else if(%this.carrier != -1)
         	{
         	   if(GameBase::getTeam(%this.carrier) == %forTeam)
         	      return "<Bflag_atbase.bmp>\nYour team controls the Frisbee, help your team put it into the enemy goal. (carried by " @ Client::getName(Player::getClient(%this.carrier)) @ ")";
         	   else
         	      return "<Bflag_enemycaptured.bmp>\nWaylay " @ Client::getName(Player::getClient(%this.carrier)) @ " and convey " @ %this.objectiveName @ " to the enemy goal.";
         	}
         	else if(%this.atHome)
         	   return "<Bflag_neutral.bmp>\nGoto center field to get " @ %this.objectiveName @ " then help your team get it into the enemy goal.";
         	else
         	   return "<Bflag_notatbase.bmp>\nFind " @ %this.objectiveName @ " and help your team get it into the enemy goal.";
      	}
			else {
         	if(%this.holdingTeam != -1)
         	   return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%this.holdingTeam) @ " team has " @ %this.objectiveName @ ".";
         	else if(%this.carrier != -1)
        	      return "<Bflag_atbase.bmp>\n" @ Client::getName(Player::getClient(%this.carrier)) @ " has " @ %this.objectiveName @ ".";
         	else if(%this.atHome)
         	   return "<Bflag_neutral.bmp>\n" @ %this.objectiveName @ " is the center of the playing field.";
				else
	        	   return "<Bflag_notatbase.bmp>\n" @ %this.objectiveName @ " is sitting around in the field, go find it.";
			}
		}
      else
      {
         if(%thisTeam == %forTeam)
         {
            if(%this.atHome)
               return "<Bflag_atbase.bmp>\nDefend your flag to prevent enemy captures.";
            else if(%this.carrier != -1)
               return "<Bflag_enemycaptured.bmp>\nReturn your flag to base. (carried by " @ Client::getName(Player::getClient(%this.carrier)) @ ")";
            else
               return "<Bflag_notatbase.bmp>\nReturn your flag to base. (dropped in the field)";
         }
         else
         {
				if(%forTeam != -1) {
            	if(%this.atHome)
            	   return "<Bflag_enemycaptured.bmp>\nGrab the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
            	else if(%this.carrier == -1)
            	   return "<Bflag_notatbase.bmp>\nFind the " @ getTeamName(%thisTeam) @ " flag and touch it to your's to score " @ %this.scoreValue @ " points.";
            	else if(GameBase::getTeam(%this.carrier) == %forTeam)
            	   return "<Bflag_atbase.bmp>\nEscort friendly carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " to base.";
            	else
            	   return "<Bflag_enemycaptured.bmp>\nWaylay enemy carrier " @ Client::getName(Player::getClient(%this.carrier)) @ " and steal his flag.";
         	}
				else {
            	if(%this.atHome)
            	   return "<Bflag_atbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag is at their base.";
            	else if(%this.carrier == -1)
            	   return "<Bflag_notatbase.bmp>\nThe " @ getTeamName(%thisTeam) @ " flag has been dropped in the field.";
            	else 
            	   return "<Bflag_atbase.bmp>\n" @ Client::getName(Player::getClient(%this.carrier)) @ " has the " @ getTeamName(%thisTeam) @ " flag.";
				}
			}         
      }
   }
}

//------------------------- Setup the H armor -------------------
PlayerData harmor
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "hflame";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.0;
   maxJetForwardVelocity = 0;
   minJetEnergy = 1;
   jetForce = 0;
   jetEnergyDrain = 0;

	maxDamage = 1.32;
   maxForwardSpeed = 6.0;
   maxBackwardSpeed = 4.0;
   maxSideSpeed = 4.0;
   groundForce = 35 * 18.0;
   groundTraction = 4.5;
   mass = 18.0;
	maxEnergy = 110;
   drag = 1.0;
   density = 2.5;
   canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 50;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundJetHeavy;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};

//----------------- Grenade redfine --------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 19.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.5;
	maxDamage = 5;
};

//------------------------- Keys ---------------------------------------------------------------------------------
//editActionMap("playMap.sae");
//bindCommand(keyboard, make, "4", to, "drop(Flag);");

//------------------ dump zone -------------
//GameBase::setIsTarget(%this,true);
//Set target on flag
//GameBase::setIsTarget(%flag,true);
//%this.enemyCaps = 0;
//bottomprint(%clientId, "<jc><f1>Training Mission 7 - Find and Retrieve", 5);
//Flag::setWaypoint(%playerClient, %this);
//Screw Terminal
//remoteKill(Player::getClient(%player));
