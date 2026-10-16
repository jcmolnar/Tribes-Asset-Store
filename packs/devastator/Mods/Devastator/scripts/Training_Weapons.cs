//Weapons-FixedTarget Training
//--------------------------------------
//all these functions do is set up the scene for each weapon.
//upon killing each target assigned, the next weapon lesson will resume.
exec("game.cs");
exec("Training_AI.cs");

//Globals
//////////////
$Train::missionType = "WEAPONS";
$counter = 0;
$AIkilled = 0;

//-------------------------------------
//fixedTargetsBlaster()
//-------------------------------------
function fixedTargetsBlaster(%playerId)
{   
   //weapon description
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>This mission will introduce you to the many weapons that are available in <f2>Devastator.\", 10);", 5);
   schedule("messageAll(0, \"~wshell_click.wav\");", 5);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Ready?\", 10);", 15);
   schedule("messageAll(0, \"~wshell_click.wav\");", 15);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Let's start with the Advanced Blaster.  This is a classic weapon with new modes, in this simulation you must use the beacons to switch firing modes.\", 10);", 25);
   schedule("messageAll(0, \"~wshell_click.wav\");", 25);
   
   //mount weapons
   schedule("Player::setItemCount(" @ %playerId @ ",Beacon, 5);", 25);
   schedule("Player::setItemCount(" @ %playerId @ ",Blaster, 1);", 25);
   schedule("Player::mountItem(" @ %playerId @ ", Blaster, 0);", 25);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Time to do some shooting!  Somewhere around you, an Engineer is trying to infiltrate your base.  Eliminate him with your Blaster.\", 10);", 30);
   schedule("messageAll(0, \"~wshell_click.wav\");", 30);
   
   //drone setup
   %name = "Shoot_Me";
   %group = "\"MissionGroup\\\\AI\\\\guard1\"";
   schedule("initAI(" @ %name @ ", " @ %group @ ", marmor);", 30);
   schedule("setTarget(" @ %playerId @ ", " @ %name @ ");", 30);
   $counter++;
}

//----------------------------------
//fixedTargetsLaserPistol()
//----------------------------------
function fixedTargetsPlasma(%playerId)
{   
   //description of weapon
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Next is the Laser Pistol.\", 10);", 10);
   schedule("messageAll(0, \"~wshell_click.wav\");", 10);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>The LP has about the same energy consumption as the Adv. Blaster, but far more distance.  This weapon is a good choice against lightly armored enemies because of its low power. \", 10);", 20);
   schedule("messageAll(0, \"~wshell_click.wav\");", 20);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Let's take out an unarmed Pilot and see how you like it.\", 10);",30);
   schedule("messageAll(0, \"~wshell_click.wav\");", 30);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Alright, Angel Kill has infiltrated your base, try to eliminate him.\", 10);", 40);
   schedule("messageAll(0, \"~wshell_click.wav\");", 40);
   
   //mount weapon
   schedule("Player::setItemCount(" @ %playerId @ ",Blaster, 0);", 12);
   schedule("Player::setItemCount(" @ %playerId @ ",LP, 1);", 12);
   schedule("Player::mountItem(" @ %playerId @ ", LP, 0);", 12);
   
   //drone details
   %name = "Angel_Kill";
   %group = "\"MissionGroup\\\\AI\\\\guard2\"";
   schedule("initAI(" @ %name @ " ," @  %group @ " , larmor);", 45);
   schedule("setTarget(" @ %playerId @ ", " @ %name @ ");", 45);
   $counter++;
}

//-----------------------------------
//fixedTargetsShotgun()
//-----------------------------------
function fixedTargetsdisc(%playerId)
{   
   //describe the weapon
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>The next weapon available to you is the Advanced Shotgun, with two firing modes, remember in training your firing modes are switched by pressing the beacon key.\", 10);", 10);
   schedule("messageAll(0, \"~wshell_click.wav\");", 10);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>This is definitely a weapon that you want to master.  Not only does the Advanced Shotgun have high-power, it also spits out multiple shot in each blast.\", 10);", 20);
   schedule("messageAll(0, \"~wshell_click.wav\");", 20);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>The best way to get a feel for the power of this weapon is to see if you can shoot a BOT target.\", 10);", 30);
   schedule("messageAll(0, \"~wshell_click.wav\");", 30);
   
   //mount the correct weapon
   schedule("Player::setItemCount(" @ %playerId @ ",LP, 0);", 12);
   schedule("Player::setItemCount(" @ %playerId @ ",Shotgun1, 1);", 12);
   schedule("Player::setItemCount(" @ %playerId @ ",ShotgunClip, 100);", 12);
   schedule("Player::setItemCount(" @ %playerId @ ",Shotgun1Ammo, 2);", 12);
   schedule("Player::mountItem(" @ %playerId @ ", Shotgun1, 0);", 12);
   
   //create a drone for them to shoot 
   %name = "\"HiMyNameisBob\"";
   %group = "\"MissionGroup\\\\AI\\\\guard3\"";
   schedule("initAI(" @ %name @ " ," @  %group @ " , harmor);", 35);
   schedule("setTarget(" @ %playerId @ ", " @ %name @ ");", 35);
   $counter++;
}

//-----------------------------------
//fixedTargetsAssaultRifle()
//-----------------------------------
function fixedTargetsAssaultRifle(%playerId)
{   
   //describe the weapon
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>The specialists' rapid-fire weapon is the Assault Rifle.\", 10);", 10);
   schedule("messageAll(0, \"~wshell_click.wav\");", 10);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Learning to use the Assault Rifle could be vital.  It's light, fast, deadly, and fairly accurate.  It runs on 30 rounds to the clip.\", 10);", 20);
   schedule("messageAll(0, \"~wshell_click.wav\");", 20);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Test your Specialist ability against this BOT target, you can hammer down like a minigun, or you can plick off shots more like a sniper.\", 10);", 30);
   schedule("messageAll(0, \"~wshell_click.wav\");", 30);
   
   //mount the correct weapon
   schedule("Player::setItemCount(" @ %playerId @ ",AR, 1);", 12);
   schedule("Player::setItemCount(" @ %playerId @ ",Shotgun1, 0);", 12);
   schedule("Player::setItemCount(" @ %playerId @ ",AssaultClip, 100);", 32);
   schedule("Player::setItemCount(" @ %playerId @ ",ARAmmo, 30);", 32);
   schedule("Player::mountItem(" @ %playerId @ ", AR, 0);", 12);
   
   //create a drone for them to shoot 
   %name = "\"Bullseye\"";
   %group = "\"MissionGroup\\\\AI\\\\guard3\"";
   schedule("initAI(" @ %name @ " ," @  %group @ " , sarmor);", 35);
   schedule("setTarget(" @ %playerId @ ", " @ %name @ ");", 35);
   $counter++;
}

//--------------------------------------
//fixedTargetsMinigun()
//--------------------------------------
function fixedTargetsChain(%playerId)
{   
   //weapon description
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Next, we will use the Minigun.  Capable of churning out explosive flechettes in rapid order, it can chew up even agile Striders in short order.\", 10);", 10);
   schedule("messageAll(0, \"~wshell_click.wav\");", 10);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Similar to the Chaingun, but faster, it is deadly at short range, it loses much of its effectiveness at greater distances, and watch your ammo, its a huge ammo-hog.\", 10);", 20);
   schedule("messageAll(0, \"~wshell_click.wav\");", 20);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Let's fire a few rounds and get an idea of the range of the Minigun. Try and take out Death Cobra while he crosses your path below your base tower.\", 10);", 30);
   schedule("messageAll(0, \"~wshell_click.wav\");", 30);

   //weapon mounting
   schedule("Player::setItemCount(" @ %playerId @ ",MG, 1);", 12);
   schedule("Player::setItemCount(" @ %playerId @ ",MGAmmo, 500);", 35);
   schedule("Player::setItemCount(" @ %playerId @ ",AR, 0);", 12);
   schedule("Player::mountItem(" @ %playerId @ ", MG, 0);", 12);
   
   //drone stuff
   %name = "Death_Cobra";
   %group = "\"MissionGroup\\\\AI\\\\guard4\"";
   schedule("initAI(" @ %name @ " ," @  %group @ " , qarmor);", 35);
   schedule("setTarget(" @ %playerId @ ", " @ %name @ ");", 35);
   $counter++;
}

//-----------------------------------
//fixedTargetsSniper
//-----------------------------------
function fixedTargetsSniper(%playerId)
{   
   //describe weapon
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>For long-range sniping, nothing beats the Sniper Rifle.  A powerful, long-distance weapon that can hit a target miles away!\", 10);", 5);
   schedule("messageAll(0, \"~wshell_click.wav\");", 5);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Because it only has 5 shots a clip, it must reload after every 5 shots.  As an added bonus to all of the snipers out there, you can use the Laser Site to enhance the accuracy of your shots.\", 10);", 15);
   schedule("messageAll(0, \"~wshell_click.wav\");", 10);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Zoom in on me and go for the head shot. Use your compass to locate my position to the north of you, then try to take me out with the Sniper Rifle.\", 10);", 25);
   schedule("messageAll(0, \"~wshell_click.wav\");", 25);

   //mount weapon
   schedule("Player::setItemCount(" @ %playerId @ ",MG, 0);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",SR, 1);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",SRAmmo, 5);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",SniperClip, 100);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",TLPack, 1);", 8);
   schedule("Player::mountItem(" @ %playerId @ ", TLPack, 1);", 8);
   schedule("Player::mountItem(" @ %playerId @ ", SR, 0);", 8);

   //setup target to shoot
   %group = "\"MissionGroup\\\\AI\\\\guard5\"";
   %name = "\"Ice\"";
   schedule("initAI(" @ %name @ " ," @  %group @ " , srarmor);", 45);
   schedule("setTarget(" @ %playerId @ ", " @ %name @ ");", 45);
   $counter++;
}

//-----------------------------------
//fixedTargetsPistol
//-----------------------------------
function fixedTargetsPistol(%playerId)
{   
   //describe weapon
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>But, maybe your out of ammo for your Sniper Rifle, what now?  Simple, use your Silenced Pistol as a last ditch sniping effort!\", 10);", 5);
   schedule("messageAll(0, \"~wshell_click.wav\");", 5);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>The Pistol only has 9 shots a clip, so don't think you can hammer down on it.  Unlike the Sniper Rifle, the pistol is quite, weaker, and has a lower velocity rate.\", 10);", 15);
   schedule("messageAll(0, \"~wshell_click.wav\");", 10);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Theres a Psycho on the loose! Take him out with your silenced pistol, so that you don't get spotted by him!\", 10);", 25);
   schedule("messageAll(0, \"~wshell_click.wav\");", 25);

   //mount weapon
   schedule("Player::setItemCount(" @ %playerId @ ",SR, 0);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",SP, 1);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",SPAmmo, 9);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",PistolClip, 100);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",TLPack, 0);", 8);
   schedule("Player::mountItem(" @ %playerId @ ", SP, 0);", 8);

   //setup target to shoot
   %group = "\"MissionGroup\\\\AI\\\\guard5\"";
   %name = "\"WalkBOT\"";
   schedule("initAI(" @ %name @ " ," @  %group @ " , psarmor);", 35);
   schedule("setTarget(" @ %playerId @ ", " @ %name @ ");", 35);
   $counter++;
}

//---------------------------------------
//fixedTargetsGrenade()
//---------------------------------------
function fixedTargetsGrenade(%playerId)
{   
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>On to a more explosive weapon!  Let's take a look at the Advanced Grenade Launcher.\", 10);", 5);
   schedule("messageAll(0, \"~wshell_click.wav\");", 5);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Grenades launched from the launcher are more advanced, exploding a few seconds after impact.  To clear out the inside of a bunker, just lob a couple of these grenades inside and watch the enemy come running out.\", 10);", 15);
   schedule("messageAll(0, \"~wshell_click.wav\");", 15);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>A Pyro thinks he can hide in a bunker.  Time to teach him the error of his ways.\", 10);", 25);
   schedule("messageAll(0, \"~wshell_click.wav\");", 25);
   schedule("bottomprint(" @ %playerId @ ", \"<f1><jc>Watch the bunker at the bottom of your base tower, and fire a couple of flaming grenades when you see the chicken sh*t run inside.\", 10);", 35);
   schedule("messageAll(0, \"~wshell_click.wav\");", 35);

   //mount weapon
   schedule("Player::setItemCount(" @ %playerId @ ",grenadeAmmo, 50);", 40);
   schedule("Player::setItemCount(" @ %playerId @ ",SR, 0);", 8);
   schedule("Player::setItemCount(" @ %playerId @ ",grenadelauncher, 1);", 8);
   schedule("Player::mountItem(" @ %playerId @ ", grenadelauncher, 0);", 8);

   //setup target to shoot
   %group1 = "\"MissionGroup\\\\AI\\\\guard6\"";
   %name1 = "Hidee_Poo";
   schedule("initAI(" @ %name1 @ " ," @  %group1 @ " , parmor);", 40);
   schedule("setTarget(" @ %playerId @ ", " @ %name1 @ ");", 40);
   $counter++;
}

//-------------------------------
//weaponsStart()
//-------------------------------
function weaponsStart(%clientId)
{
  fixedTargetsBlaster(%clientId);
}

//-------------------------------
//initAi()
//-------------------------------
function initAI(%name, %group, %armor)
{
  createAI(%name, %group, %armor, %name);
}

//-------------------------------
//Game:playerSpawned()
//-------------------------------
function Game::playerSpawned(%pl, %clientId, %armor)
{
   replenishAmmo();
} 

//--------------------------------
//AI::onDroneKilled()
//--------------------------------
function AI::onDroneKilled(%aiName)
{
	%clientId = 2049;
	if(%aiName == "Shoot_Me") {
		fixedTargetsPlasma(%clientId);
		bottomprint(%clientId, "<f1><jc>You got him!", 5);
		$AIkilled++;
		ObjectiveScreen();
	}
	else if(%aiName == "Angel_Kill") {
		fixedTargetsDisc(%clientId);
		bottomprint(%clientId, "<f1><jc>Good Job!", 5);
		$AIkilled++;
		ObjectiveScreen();
	}
	else if(%aiName == "HiMyNameisBob") {
		fixedTargetsChain(%clientId);
//		fixedTargetsAssaultRifle(%clientId);
		bottomprint(%clientId, "<f1><jc>That was so hard... yawn...", 5);
		$AIkilled++;
		ObjectiveScreen();
	}
//	else if(%aiName == "Bullseye")
//	{
//	  fixedTargetsChain(%clientId);
//		bottomprint(%clientId, "<f1><jc>Nice job, you got skills.", 5);
//		$AIkilled++;
//		ObjectiveScreen();
//	}
	else if(%aiName == "Death_Cobra") {
		fixedTargetsSniper(%clientId);
		bottomprint(%clientId, "<f1><jc>He isn't too happy about that!", 5);
		$AIkilled++;
		ObjectiveScreen();
	}
	else if(%aiName == "Ice") {
		fixedTargetsGrenade(%clientId);
//		fixedTargetsPistol(%clientId);
		Client::sendMessage(%client,$MsgTypeChat,"[Dead]: You got lucky!",AI::getId(%AIName));
		bottomprint(%clientId, "<f2><jc>Ice: <f1>You got lucky!", 10);
		$AIkilled++;
		ObjectiveScreen();
		}
//	else if(%aiName == "WalkBOT") {
//		fixedTargetsGrenade(%clientId);
//		bottomprint(%clientId, "<f1><jc>He never heard it coming!", 5);
//		$AIkilled++;
//		ObjectiveScreen();
//	}
	else if(%aiName == "Hidee_Poo") {
		endMission(%clientId);
		bottomprint(%clientId, "<f1><jc>Yea, that lil' coward!", 5);
		$AIkilled++;
	}
}  

//----------------------------------
//endMission()
//----------------------------------
function endMission(%clientId)
{
  %name = Client::getName(%clientId);
  %String = "\"<f1><jc>Way to go " @ %name @ ", you have completed the weapons introduction mission!\"";
  schedule("bottomprint(" @ %clientId @ ", " @ %String @ " , 10);", 5);
  schedule("messageAll(0, \"~wshell_click.wav\");", 5); 
  schedule("Training::MissionComplete(" @ %clientId @ ");", 15);
}

//----------------------------------
//StayInBounds()
//----------------------------------
function StayInBounds(%clientId)
{ 
	%player = Client::getOwnedObject(%clientId);
	%flash = 0.4;
	Player::setDamageFlash(%player, %flash);
	%pos = "203.811 -532.056 176.938";
	messageAll(0, "You must Stay inside your base!" @ "~wshieldhit.wav");
	GameBase::setPosition(%ClientId, %pos);
} 
   
//------------------------------------------
//GroupTrigger::onLeave()
//------------------------------------------
function GroupTrigger::onLeave(%this, %object)
{ 
   %clId = Client::getFirst();
   //The trigger stuff is not completely reliable, so we'll try our own 
   //hard-coded rough check here as well:
   %pos = Gamebase::getPosition( %clId );

   %x = getWord(%pos, 0 );
   %y = getWord(%pos, 1 );
   %z = getWord(%pos, 2 );

   // Seems to work pretty well.  You can get on top of the platform now.  I increased
   // the Z so you can fly pretty high (it will cause the call to the else{} below.
   //
   // This has the "side effect" that there now IS a way to leave the platform, but you 
   // have to try, and I think it qualifies as an easter egg rather than a bug.  
   if( %x < 193 || %x > 212 || %y < -539 || %y > -521 || %z < 175 || %z > 250 )
   {
      dbecho(2,"Out of Bounds!");
      StayInBounds(%clId);
   }
   else
   {
      dbecho(2,"onLeave() erroneously called in Weapons Training");
   }
} 

//----------------------------------
//setTarget()
//----------------------------------
function setTarget(%playerId, %name)
{
	%id = AI::getId(%name);
	%targIdx = (%id - 2048);
//	issueTargCommand(%playerId, %playerId, 1,"Waypoint set to target", %targIdx);
	issueTargCommand(%playerId, %playerId, 1,"You Must Kill Target", %targIdx);
}				

//----------------------------------
//missionSummary()
//----------------------------------
function missionSummary()
{
   %time = getSimTime();
   
   Training::displayBitmap(0);
   Team::setObjective(0, 1, "<f5><jl>Mission Completion:");
   Team::setObjective(0, 2, "<f1>   -Completed:");
   Team::setObjective(0, 3, "\n");
   Team::setObjective(0, 4, "<f5><jl>Mission Information:");
   Team::setObjective(0, 5, "<f1>   -Mission Name: Introduction to Weapons");
   Team::setObjective(0, 6, "\n");
   
   Team::setObjective(0, 7, "<f5><j1>Mission Summary:");
   
   Team::setObjective(0, 8, "<f1>   -Total Mission Time: " @ "<f1>" @ Time::getMinutes(%time) @ " Minutes " @ Time::getSeconds(%time) @ " Seconds");
   Team::setObjective(0, 9, "\n");
   Team::setObjective(0, 10, "\n");
   Team::setObjective(0, 11, "\n");
   Team::setObjective(0, 12, "\n");
   Team::setObjective(0, 13, "\n");
   Team::setObjective(0, 14, "\n");
}

//--------------------------------------
//Training::missionComplete()
//--------------------------------------
function Training::missionComplete(%cl)
{
  Client::setGuiMode(%cl, $GuiModeObjectives);
  missionSummary();
  remoteEval(2049, TrainingEndMission);
}

//-------------------------------------
//remoteTrainingEndMission()
//-------------------------------------
function remoteTrainingEndMission()
{
   schedule("EndGame();", 8);
}

//------------------------------------
//replenishAmmo()
//------------------------------------
function replenishAmmo()
{
  %playerId = 2049;
  
  if($counter == 3)
    Player::setItemCount(%playerId, ShotgunClip, 100);						  
//  else if($counter == 4)
//    Player::setItemCount(%playerId, AssaultClip, 100);
  else if($counter == 4)
    Player::setItemCount(%playerId, MGAmmo, 500);
  else if($counter == 5)
    Player::setItemCount(%playerId, SniperClip, 100);
//  else if($counter == 6)
//    Player::setItemCount(%playerId, PistolClip, 100);
  else if($counter == 6)
    Player::setItemCount(%playerId ,grenadeAmmo, 100);
  schedule("replenishAmmo();", 30);
}

//--------------------------------------------
//Game::initialMissionDrop()
//--------------------------------------------
function Game::initialMissionDrop(%clientId)
{
   GameBase::setTeam(%clientId, 0);
   Client::setGuiMode(%clientId, $GuiModePlay);
   Game::playerSpawn(%clientId, false);

   schedule("bottomprint(" @ %clientId @ ", \"<f1><jc>Training Mission 2 - Weapon Introduction.\", 5);", 0);
   schedule("messageAll(0, \"~wshell_click.wav\");", 0); 
   schedule("weaponsStart(" @ %clientId @ ");", 5);
	Training::displayBitmap(0);
	objectiveScreen();
}

//------------------------------------------------
//ObjectiveScreen()
//------------------------------------------------
function ObjectiveScreen()
{
   %time = getSimTime() - $MatchStartTime;
   Training::displayBitmap(0);
   Team::setObjective(0, 1, "<f5><jl>Mission Completion:");
   Team::setObjective(0, 2, "<f1>   -Firing range: Weapons training in progress");
   Team::setObjective(0, 3, "\n");
   Team::setObjective(0, 4, "<f5><jl>Mission Information:");
   Team::setObjective(0, 5, "<f1>   -Mission Name: Introduction to Weapons");
   Team::setObjective(0, 6, "\n");
   
   Team::setObjective(0, 7, "<f5><j1>Mission Summary:");
   Team::setObjective(0, 8, "<f1>   -Total Mission Time: " @ "<f1>" @ Time::getMinutes(%time) @ " Minutes " @ Time::getSeconds(%time) @ " Seconds");
   Team::setObjective(0, 9, "<f1>   -Total kills: " @ $AIkilled @ " out of 6");
//   Team::setObjective(0, 9, "<f1>   -Total kills: " @ $AIkilled @ " out of 8");
   
   Team::setObjective(0, 10, "\n");
   Team::setObjective(0, 11, "\n");
   Team::setObjective(0, 12, "\n");
   Team::setObjective(0, 13, "\n");
   Team::setObjective(0, 14, "\n");
}

//----------------------------------------
//Player::onDamage() //- Ice's Commentary: "Why the Hell is this even here?"
//----------------------------------------
//-Taken out
//-------------------------------------
//Ammo::onDrop() -don't be an idiot!
//-------------------------------------
function Ammo::onDrop(%player,%item)
{
	if($matchStarted) {
		%count = Player::getItemCount(%player,%item);
		%delta = $SellAmmo[%item];
		if(%count <= %delta) { 
			if( %item == "BulletAmmo" || (Player::getMountedItem(%player,$WeaponSlot)).imageType.ammoType != %item)
				%delta = %count;
			else 
				%delta = %count - 1;

		}
		if(%delta > 0) {
			%obj = newObject("","Item",%item,%delta,false);
      	schedule("Item::Pop(" @ %obj @ ");", $ItemPopTime, %obj);

      	addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,20,false);
			messageAll(0, "~wmale2.wdsgst2.wav");
			Player::decItemCount(%player,%item,%delta);
		}
	}
}	

//do nothing functions
function remoteScoresOn(%clientId)
{
}

function remoteScoresOff(%clientId)
{
}

function Item::onDrop(%player, %item)
{
}
