//cronerawr$
if($TDisLoaded != true)
{
	//schedule("MakeSensors();", 10);
	//both("reset tdisloaded");

}
$onlyonce = true;

$DuelMostMidAirHolder = "";
$DuelMostMidAir = "0";
$DuelLongestMAHolder = "";
$DuelLongestMA = "0";
//newObject("Viking", SimVolume, File::findFirst(titanDML.vol));
$InvList[HeavyArmor] = 0;
$numz = 2;
$PrintRed = "<F0>";
$PrintGreen = "<F1>";
$PrintWhite = "<F2>";
//deleteObject("MissionCleanup");
//newObject(MissionCleanup, SimGroup);

$Server::TeamDamageScale = 1;
$CorpseTimeoutValue = 22;
$Console::Prompt = "> ";

$White = 0;
$Red = 1;
$Beige = 2;
$Green = 3;
$error = "~werror_message.wav";
$beep = "~wmine_act.wav";
$AmmoPackMax[BulletAmmo] = 150;
$AmmoPackMax[PlasmaAmmo] = 30;
$AmmoPackMax[DiscAmmo] = 15;
$AmmoPackMax[GrenadeAmmo] = 15;
$AmmoPackMax[MortarAmmo] = 10;
$AmmoPackMax[MineAmmo] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackMax[Beacon] = 10;

$NextWeapon[EnergyRifle] = Blaster;
$NextWeapon[Blaster] = PlasmaGun;
$NextWeapon[PlasmaGun] = Chaingun;
$NextWeapon[Chaingun] = DiscLauncher;
$NextWeapon[DiscLauncher] = DiscLauncherKing;
$NextWeapon[DiscLauncherKing] = DiscLauncherBlue;
$NextWeapon[DiscLauncherBlue] = DiscLauncherGreen;
$NextWeapon[DiscLauncherGreen] = DiscLauncherYellow;
$NextWeapon[DiscLauncherYellow] = DiscLauncherPink;
$NextWeapon[DiscLauncherPink] = DiscLauncherBlack;
$NextWeapon[DiscLauncherBlack] = DiscLauncherPurple;
$NextWeapon[DiscLauncherPurple] = GrenadeLauncher;
function remoteDB(%cl)
{
	Player::setItemCount(%cl,DiscLauncherBlue,1);
	Player::setItemCount(%cl,DiscLauncherGreen,1);
	Player::setItemCount(%cl,DiscLauncherYellow,1);
	Player::setItemCount(%cl,DiscLauncherPink,1);
	Player::setItemCount(%cl,DiscLauncherBlack,1);
	Player::setItemCount(%cl,DiscLauncherPurple,1);
}
$NextWeapon[GrenadeLauncher] = Mortar;
$NextWeapon[Mortar] = LaserRifle;
$NextWeapon[LaserRifle] = FireWorksGun;
$NextWeapon[FireWorksGun] = TreeGun;
$NextWeapon[TreeGun] = WeedEater;
$NextWeapon[WeedEater] = CloneGun;
$NextWeapon[CloneGun] = GateGun;
$NextWeapon[GateGun] = Grabbler;
$NextWeapon[Grabbler] = DiscSeeka;
$NextWeapon[DiscSeeka] = PlasSeeka;
$NextWeapon[PlasSeeka] = Orbital1;
$NextWeapon[Orbital1] = Flaggy;
$NextWeapon[Flaggy] = MotherOfGod;
$NextWeapon[MotherOfGod] = SlowBouncy;
$NextWeapon[SlowBouncy] = Bouncy;
$NextWeapon[Bouncy] = LeGun;
$NextWeapon[LeGun] = LeNade;
$NextWeapon[LeNade] = Sweeper;
$NextWeapon[Sweeper] = ThreeG;
$NextWeapon[ThreeG] = EveryGun;
$NextWeapon[EveryGun] = Halo;
$NextWeapon[Halo] = ScoutSeeka;
$NextWeapon[ScoutSeeka] = EnergyRifle;


$PrevWeapon[Blaster] = EnergyRifle;
$PrevWeapon[PlasmaGun] = Blaster;
$PrevWeapon[Chaingun] = PlasmaGun;
$PrevWeapon[DiscLauncher] = Chaingun;
$PrevWeapon[DiscLauncherKing] = DiscLauncher;
$PrevWeapon[DiscLauncherGreen] = DiscLauncherKing;
$PrevWeapon[DiscLauncherBlue] = DiscLauncherGreen;
$PrevWeapon[DiscLauncherYellow] = DiscLauncherBlue;
$PrevWeapon[DiscLauncherPink] = DiscLauncherYellow;
$PrevWeapon[DiscLauncherBlack] = DiscLauncherPink;
$PrevWeapon[DiscLauncherPurple] = DiscLauncherBlack;
$PrevWeapon[GrenadeLauncher] = DiscLauncherPurple;
$PrevWeapon[Mortar] = GrenadeLauncher;
$PrevWeapon[LaserRifle] = Mortar;
$PrevWeapon[FireWorksGun] = LaserRifle;
$PrevWeapon[TreeGun] = FireWorksGun;
$PrevWeapon[WeedEater] = TreeGun;
$PrevWeapon[CloneGun] = WeedEater;
$PrevWeapon[GateGun] = CloneGun;
$PrevWeapon[Grabbler] = GateGun;
$PrevWeapon[DiscSeeka] = Grabbler;
$PrevWeapon[PlasSeeka] = DiscSeeka;
$PrevWeapon[Orbital1] = PlasSeeka;
$PrevWeapon[Flaggy] = Orbital1;
$PrevWeapon[MotherOfGod] = Flaggy;
$PrevWeapon[SlowBouncy] = MotherOfGod;
$PrevWeapon[Bouncy] = SlowBouncy;
$PrevWeapon[LeGun] = Bouncy;
$PrevWeapon[LeNade] = LeGun;
$PrevWeapon[Sweeper] = LeNade;
$PrevWeapon[ThreeG] = Sweeper;
$PrevWeapon[EveryGun] = ThreeG;
$PrevWeapon[Halo] = EveryGun;
$PrevWeapon[ScoutSeeka] = Halo;
$PrevWeapon[EnergyRifle] = ScoutSeeka;


$TeamDuel::TotalTeams = CheckTotalTeams();

function setupteam(%number)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(setupteam);
	}
	$TeamDuel::Time[%number] = "Disabled";
	$TeamDuel::Rounds[%number] = "4";
	$TeamDuel::Weapons[%number] = "Player's Choice";
	$TeamDuel::Packs[%number] = "Player's Choice";
	$TeamDuel::Arena[%number] = "None";
	$TeamDuel::Armor[%number] = "Player's Choice";
	$TeamDuel::Mines[%number] = "Off";
	$TeamDuel::Wins[%number] = "0";
	$TeamDuel::Losses[%number] = "0";
	$TeamDuel::Score[%number] = "0";

	$TeamDuel::InMatch[%number] = "";
	$TeamDuel::Abort[%number] = false;
	$TeamDuel::Challenging[%number] = "";
	$TeamDuel::AllowBlaster[%number] = true;

	$TeamDuel::MatchesLost[%number] = "0";
	$TeamDuel::MatchesWon[%number] = "0";

	$TeamDuel::CanHurt[%number] = "";

	$TeamDuel::ArenaSpawn[%number] = false;

	$TeamDuel::NewSpawns[%number] = false;

	$TeamDuel::Multi[%number] = false;
	//if($Map::Original)
	//{
	//	$TeamDuel::Arena[%number] = "Map";
	//}
	echo("Team Created: "@$TeamDuel::Name[%number]);
	echo("Default settings applied");
	SetStats(%number);
}

function remoteAD(%cl,%xx)
{
	%DMG = 0;
	%foe = %cl;
	Player::AddDamage(%cl, %xx, %foe);

}
function Player::AddDamage(%cl, %dmg, %foe)
{

	%pl = Client::getOwnedObject(%cl);
	//both(gamebase::getdamagelevel(%pl));
	%armor = Player::getArmor(%pl);
	%percent = floor(((%dmg / %armor.maxDamage) * 100)+0.5);
	//both("per: "@ %percent);

	if(%percent == "100")
	{
		%cl.damagecount=1;
		%cl.damaged[0] = %foe;
		%cl.damage[0] += %dmg;
		//both("first dmg");
	}
	else
	{
		for(%x = 0; %x < %damagecount; %x++)
		{
			if(%cl.damaged[%x] == %foe)
			{
				//a match:)
				%cl.damage[%x] += %dmg;
				return;
			}
		}
	}
	//for the end

}

function remoteSort(%cl)
{
	resetlos();
	%pl = Client::getOwnedObject(%cl);
	GameBase::getLOSInfo(%pl, "9000", "-1.57 0 0");
}
function MatchSetup(%Team1, %Team2, %extraT1, %extraT2)
{
	if(%Team1 == "" || %Team2 == "" || isobject($TeamDuel::Leader[%Team1]) != "True" || isobject($TeamDuel::Leader[%Team2])  != "True")	{		return echo("False MatchSetup");	}//
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(MatchSetup);
	}
	%client1 = $TeamDuel::Leader[%Team1];
	%client2 = $TeamDuel::Leader[%Team2];

	if($TeamDuel::Score[%Team1] == "0" && $TeamDuel::Score[%Team2] == "0")
	{
		%client1.notready = true;
		%client2.notready = true;
		messageall(0, $TeamDuel::Name[%Team1] @ " and " @ $TeamDuel::Name[%Team2] @ " are about to fight! [Rounds: "@ $TeamDuel::Rounds[%Team1] @", Arena: "@ $TeamDuel::Arena[%Team1] @", Packs: "@ $TeamDuel::Packs[%Team1] @", Weapons: "@ GetWeaponString(%Team1) @"]");
	   %message = "Waiting for the captains to ready up. [Press Fire].";
	   TMessage(%Team1, %Team2, $Green, %message);
	   echo("Match Setup: notready status set. Waiting for ready up");
	}
	$TeamDuel::InMatch[%Team1] = "True";
	$TeamDuel::InMatch[%Team2] = "True";
	$TeamDuel::Challenging[%Team1] = %Team2;
	$TeamDuel::Challenging[%Team2] = %Team1;
	$TeamDuel::RoundEnded[%Team1] = false;
	$TeamDuel::RoundEnded[%Team2] = false;
	$TeamDuel::CanHurt[%Team1] = "False";
	$TeamDuel::CanHurt[%Team2] = "False";
	//SetStats(%Team1);
	//SetStats(%Team2);
	%client1.isAlive = "True";
	Game::refreshClientScore(%client1);
	%client2.isAlive = "True";
	Game::refreshClientScore(%client2);
	$TeamDuel::MissionArea[%Team1] = 700;
	$TeamDuel::MissionArea[%Team2] = 700;
	if($TeamDuel::Arena[%Team1] != "None")
	{
		//$TeamDuel::ArenaStatus[$TeamDuel::Arena[%Team1]] = "Taken";

		if($Map::Original && $TeamDuel::Arena[%Team1] == "Map")
		{
			if($TeamDuel::Score[%Team1] == "0" && $TeamDuel::Score[%Team2] == "0")
			{
				//TeamDuel::CreateArenaSpawns(%Team1, %Team2);
				echo("Match Setup: arena map found! Starting arena spawn setup from map info...");
				//for(%x = 0; (%x < 30) ; %x++)
				//{
					%team = 0;
					%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/start");
					%count = Group::objectCount(%group);
					ECHO("COUNT1: "@%count);
					for(%i = 0; %i < %count; %i++)
					{
						%obj = Group::getObject(%group, %i);
						$TeamDuel::Spawn[%Team1, %i] = gamebase::getposition(%obj);
						$TeamDuel::SpawnRot[%Team1, %i] = gamebase::getrotation(%obj);
						echo("Team: "@%Team1@" Spawn: "@%i@"  "@$TeamDuel::Spawn[%Team1, %i]);
					}
					%team++;
					%group = nameToID("MissionGroup/Teams/team" @ %team @ "/DropPoints/start");
					%count = Group::objectCount(%group);
					ECHO("COUNT2: "@%count);
					for(%i = 0; %i < %count; %i++)
					{
						%obj = Group::getObject(%group, %i);
						$TeamDuel::Spawn[%Team2, %i] = gamebase::getposition(%obj);
						$TeamDuel::SpawnRot[%Team2, %i] = gamebase::getrotation(%obj);
						echo("Team: "@%Team2@" Spawn: "@%i@"  "@$TeamDuel::Spawn[%Team2, %i]);
					}
				//}
				SetupTeamSpawn(%Team1);
				SetupTeamSpawn(%Team2);
				TeamDuelCountDownTicker(%Team1, %Team2);
				return;

			}
		}
		if($TeamDuel::Score[%Team1] == "0" && $TeamDuel::Score[%Team2] == "0")
		{
			TeamDuel::MakeArena($TeamDuel::Arena[%Team1], %Team1, %Team2);
		}
		SetupTeamSpawn(%Team1);
		SetupTeamSpawn(%Team2);
		TeamDuelCountDownTicker(%Team1, %Team2);
		echo("Match Setup: arena match found! Starting arena spawn setup");

		return;
	}
	if($TeamDuel::Arena[%Team1] == "None")
	{
		%spotTaken = true;
		%ii = 0;
		while (%spotTaken) {
			   %ii++;
			   if (%ii > 60) {
					   Client::SendMessage(%client1,0,"No duel spawn spots are vacant. Try again when a duel finishes.~waccess_denied.wav");
					   return;
			   }
			   %i = floor(getRandom() * 12) + 1;
			   if (!$DuelSpotTaken[%i]) {
					   $DuelSpotIndex[%client1] = %i;
					   $DuelSpotIndex[%client2] = %i;
					   %group = nameToID("MissionGroup/Duel" @ %i);
					   %count = Group::objectCount(%group);
					  // $DuelSpawnMarker[%client1] = Group::getObject(%group, 0);
					  // $DuelSpawnMarker[%client2] = Group::getObject(%group, 1);
					  	$DuelSpawnMarker[%client1] = %i;
						$DuelSpawnMarker[%client2] = %i;
					   $DuelSpotTaken[%i] = true;
					   %spotTaken = false;
			   }
		}

				//GameBase::getPosition($DuelSpawnMarker[%client1]);
				$TeamDuel::Spawn[%Team1, 0] = $Duel::SpawnMarkerPos[$DuelSpawnMarker[%client1], 1];
				$TeamDuel::SpawnRot[%Team1, 0] = $Duel::SpawnMarkerRot[$DuelSpawnMarker[%client1], 1];
				$TeamDuel::Spawn[%Team2, 0] = $Duel::SpawnMarkerPos[$DuelSpawnMarker[%client2], 2];
				$TeamDuel::SpawnRot[%Team2, 0] = $Duel::SpawnMarkerRot[$DuelSpawnMarker[%client2], 2];

				//$TeamDuel::SpawnRot[%Team1, 0] = GameBase::getRotation($DuelSpawnMarker[%client1]);
				//$TeamDuel::Spawn[%Team2, 0] = GameBase::getPosition($DuelSpawnMarker[%client2]);
				//$TeamDuel::SpawnRot[%Team2, 0] = GameBase::getRotation($DuelSpawnMarker[%client2]);
				if($TeamDuel::NewSpawns[%Team1])
				{
					RandomSpawns(%Team1);
				}
				%pl = TeamDuelSpawn(%client1, 0);
				echo("Client: "@ client::getname(%client1) @"("@ %client1 @") Team: " @ %client1.Team @ " PL: " @ %pl @" Spot: 0");

				LockTeam(%client1, %pl);
				%client1.observerMode = "";
				%client1.observerTarget = "";
				%client1.guiLock = true;
				DM::LeaveDM(%client1);
				Client::setGuiMode(%client1, $GuiModePlay);
				gamebase::setteam(%client1, $TeamDuel::RealTeam[%client1.team]);
				Client::setSkin(%client1, $Client::info[%client1, 0]);
				if($TeamDuel::Skin[%client1.Team] != "")
				{
					Client::setskin(%client1, $TeamDuel::Skin[%client1.Team]);
				}
				SpawnNoArena(%client1);
				%pl.StartCode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl);
				$TeamDuel::Challenging[%client1.Team] = %client2.Team;

				%pl = TeamDuelSpawn(%client2, 0);

				echo("Client: "@ client::getname(%client2) @"("@ %client2 @") Team: " @ %client2.Team @ " PL: " @ %pl @" Spot: 0");


				LockTeam(%client2, %pl);
				%client2.observerMode = "";
				%client2.observerTarget = "";
				%client2.guiLock = true;
				DM::LeaveDM(%client2);
				Client::setGuiMode(%client2, $GuiModePlay);
				gamebase::setteam(%client2, $TeamDuel::RealTeam[%client2.team]);
				Client::setSkin(%client2, $Client::info[%client2, 0]);
				if($TeamDuel::Skin[%client2.Team] != "")
				{
					Client::setskin(%client2, $TeamDuel::Skin[%client2.Team]);
				}
				SpawnNoArena(%client2);
				%pl.StartCode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl);
				$TeamDuel::Challenging[%client2.Team] = %client1.Team;


				TeamDuelCountDownTicker(%Team1, %Team2);
	}
}



function TeamDuelCanHurt(%team)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TeamDuelCanHurt);
	}
	$TeamDuel::CanHurt[%team] = "True";
}



function TeamDuelCountdown(%Team1, %Team2, %timeLeft)
{
	echo("Team: "@%team1@" 2: "@%team2);
	echo("TD COUNTDOWN: "@$Teamduel::challenging[1]@" "@$Teamduel::challenging[2]@" "@$Teamduel::inmatch[1]@" "@$Teamduel::inmatch[2]);
	if(%Team1 == "" || %Team2 == "" || $TeamDuel::Challenging[%Team1] == "" || $TeamDuel::Challenging[%Team2] == "" || $TeamDuel::InMatch[%Team1] == "" || $TeamDuel::InMatch[%Team2] == "")	{
		echo("False TeamDuelCountdown");
		return ;
		}
	$TeamDuel::CanHurt[%Team1] = "False";
	$TeamDuel::CanHurt[%Team2] = "False";
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TeamDuelCountdown);
	}
	if($TeamDuel::Abort[%Team1] || $TeamDuel::Abort[%Team2])
	{
		schedule("$TeamDuel::Abort["@%Team1@"] = false;", %timeLeft+1.0);
		schedule("$TeamDuel::Abort["@%Team2@"] = false;", %timeLeft+1.0);
		$TeamDuel::Ticker[%Team1] = "false";
		$TeamDuel::Ticker[%Team2] = "false";
		return;
	}
	$TeamItemCount[%Team1, LaserRifle] = 0;
	$TeamItemCount[%Team2, LaserRifle] = 0;
	if(%timeLeft == "" || %timeLeft == "-1")
	{
		%timeLeft = "1";
	}
       if (%timeLeft == 0)
       {
		   $TeamDuel::CanHurt[%Team1] = "";
		   $TeamDuel::CanHurt[%Team2] = "";
		   %message = "<jc><f0>Fight!<f1>";
		   PrintTeam(%Team1@" "@%Team2, %message, bottom);//top, center, bottom
           $TeamDuel::Ticker[%Team1] = false;
           $TeamDuel::Ticker[%Team2] = false;

           BeginTeamDuel(%Team1, %Team2);
           schedule("TeamDuelCanHurt(" @ %Team1 @ ");", $DuelHurtDelay+1.00);
           schedule("TeamDuelCanHurt(" @ %Team2 @ ");", $DuelHurtDelay+1.00);
           //schedule("Ticker("@%Team1@", "@%Team2@");",$DuelHurtDelay+1.50);

			echo("Match Started");
			//if($TeamDuel::Arena[%Team1] == "None" || $TeamDuel::Arena[%Team2] == "None")
			//{
				moveSensors(%Team1@" "@%Team2);
			//}

           return;
       }
		$TeamDuel::Ticker[%Team1] = true;
		$TeamDuel::Ticker[%Team2] = true;
       if (%timeLeft == 1)
       {
		   %message = "<jc><f1>Match starts in <f2>1<f1> second.";
		   PrintTeam(%Team1@" "@%Team2, %message, bottom);//top, center, bottom
       }
       else
       {
           if (%timeLeft <= 5)
           {
                %message = "<jc><f1>Match starts in <f2>" @ %timeLeft @ "<f1> seconds.";
		   		PrintTeam(%Team1@" "@%Team2, %message, bottom);//top, center, bottom
           }
           else
           {
				if (%timeLeft == 10)
				{

					%message = "<jc><f1>Match starts in <f2>" @ %timeLeft @ "<f1> seconds.";
					PrintTeam(%Team1@" "@%Team2, %message, bottom);//top, center, bottom
				}

            }
       }
       schedule("TeamDuelCountdown(" @ %Team1 @ "," @ %Team2 @ "," @ (%timeLeft - 1) @ ");", 1);
}
function TeamDuelCountDownTicker(%Team1, %Team2, %tick)
{
	echo("TD COUNTDOWNTICKER: "@$Teamduel::challenging[1]@" "@$Teamduel::challenging[2]@" "@$Teamduel::inmatch[1]@" "@$Teamduel::inmatch[2]);
	$TeamItemCount[%Team1, LaserRifle] = 99;
	$TeamItemCount[%Team2, LaserRifle] = 99;
	if(%Team1 == "" || %Team2 == "")	{		return echo("False TeamDuelCountDownTicker");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(TeamDuelCountDownTicker);
	}
	if($TeamDuel::Abort[%Team1] || $TeamDuel::Abort[%Team2])
	{
		$TeamDuel::Abort[%Team1] = false;
		$TeamDuel::Abort[%Team2] = false;
		$TeamDuel::Ticker[%Team1] = "";
		$TeamDuel::Ticker[%Team2] = "";
		echo("abortion");
		return;
	}
	$TeamDuel::Ticker[%Team1] = true;
	$TeamDuel::Ticker[%Team2] = true;
	%message = "";
	if(%tick == "")
	{
		%tick = 0;
	}
	if($TeamDuel::Leader[%Team1].notready == "" && $TeamDuel::Leader[%Team2].notready == "")
	{
		TeamDuelCountdown(%Team1, %Team2, 6);
		return;
	}
	if($TeamDuel::Leader[%Team1].notready || $TeamDuel::Leader[%Team2].notready)
	{
		%tick++;
		if(%tick/10 == "1")
        {
			%tick = -4;
			if($TeamDuel::Leader[%Team1].notready == "true" && $TeamDuel::Leader[%Team2].notready == "true")
			{
				%message = "Waiting on "@ client::getname($TeamDuel::Leader[%Team1]) @" and "@ client::getname($TeamDuel::Leader[%Team2]) @" to ready up.";
				schedule("TeamDuelCountDownTicker("@ %Team1 @","@ %Team2 @","@ %tick @");", 1);
				TMessage(%Team1, %Team2, $Green, %message);
				return;
			}
			if($TeamDuel::Leader[%Team1].notready == "true")
			{
				%message = "Waiting on "@ client::getname($TeamDuel::Leader[%Team1]) @" to ready up.";
				schedule("TeamDuelCountDownTicker("@ %Team1 @","@ %Team2 @","@ %tick @");", 1);
				TMessage(%Team1, %Team2, $Green, %message);
				return;
			}
			if($TeamDuel::Leader[%Team2].notready == "true")
			{
				%message = "Waiting on "@ client::getname($TeamDuel::Leader[%Team2]) @" to ready up.";
				schedule("TeamDuelCountDownTicker("@ %Team1 @","@ %Team2 @","@ %tick @");", 1);
				TMessage(%Team1, %Team2, $Green, %message);
				return;
			}
		}
	}
	schedule("TeamDuelCountDownTicker("@ %Team1 @","@ %Team2 @","@ %tick @");", 1);
}

function BeginTeamDuel(%Team1, %Team2)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False BeginTeamDuel");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(BeginTeamDuel);
	}
	if($TeamDuel::Abort[%Team1] || $TeamDuel::Abort[%Team2])
	{
		SecondaryClear(%Team1, %Team2, 1);
		$TeamDuel::Abort[%Team1] = false;
		$TeamDuel::Abort[%Team1] = false;
	}
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
		if(%cl.team == %Team1 || %cl.team == %Team2)
		{
			//remoteEval(%cl, "setTime", 0);
			Client::setControlObject(%cl, %cl.Owns);
			GameBase::SetDamageLevel(%cl.Owns, 0);
			%cl.guiLock = false;
			Client::setGuiMode(%cl, $GuiModePlay);
			%cl.oob = false;
			%cl.observerTarget = "";
			if(Client::getOwnedObject(%cl) == "-1")
			{
				Client::setOwnedObject(%cl, %cl.owns);
			}
			%pl = Client::getOwnedObject(%cl);
			%pl.StartCode = gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl);
		}
	}
	$TeamDuel::Start[%Team1] = floor(getSimTime() + 0.5);
	$TeamDuel::Start[%Team2] = $TeamDuel::Start[%Team1];
	$TeamDuel::Center[%Team1] = GetTotalLeaderCoords(%Team1, %Team2);
	$TeamDuel::Center[%Team2] = $TeamDuel::Center[%Team1];
	if($TeamDuel::Arena[%Team1] == "None")
	{
		CreateMissionArea(%Team1@" "@%Team2, $TeamDuel::Start[%Team1]);
	}
}
$TeamDuel::DistanceMA = 700;

function Player::leaveMissionArea(%player)
{
	%cl = Player::getClient(%player);
	if($TeamDuel::Arena[%cl.Team] == "None") return;

	if(%cl.Team != "" && %cl.isAlive && $Map::Original && $TeamDuel::Arena[%cl.Team] == "Map")
	{
		%cl.oob = true;
		//both("player::");
		Client::sendMessage(%cl,1,"You have left the mission area.");
		alertPlayer(%cl, 10);
	}
}
function Player::enterMissionArea(%player)
{
	%cl = Player::getClient(%player);
	if(%cl.Team != "" && $TeamDuel::Arena[%cl.Team] == "Map")
	{
		%cl.oob = false;
		Client::sendMessage(%cl,1,"You have entered the mission area.");
	}
}

function CreateMissionArea(%Teams, %time)
{
	//both(%teams@" "@%time);
	%time2 = Time::getMinutes((floor(getSimTime()) - %time));
	for(%x = 1; gw(%Teams,%x-1) != -1; %x++)
	{
		%Team[%x] = gw(%Teams,%x-1);
	}


	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(CreateMissionArea);
	}
	if($TeamDuel::Start[%Team[1]] == %time)
	{
		//if(%time2 > 0)
		//{
			//$TeamDuel::Start[%Team1] = floor(getSimTime() + 0.5);
			//$TeamDuel::Start[%Team2] = $TeamDuel::Start[%Team1];
			//%time = $TeamDuel::Start[%Team1];
			//CompileCoords(%Team1, %Team2);
			//WayPointThemALL(%Team1, %Team2);
			//moveSensors(%Team1@" "@%Team2);

			//both("resetting clock, setting waypoints");
		//}


		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			for(%a = 1; %Team[%a] != ""; %a++)
			{
				if(%cl.Team == %Team[%a] && %cl.isAlive)
				{
					%pl = client::getownedobject(%cl);
					if(gamebase::getposition(%pl)@" "@GameBase::getrotation(%pl) == %pl.StartCode)
						%pl.IdleHits++;

					%cpos = GameBase::getPosition(%pl);
					%distance = floor(Vector::getDistance(getword(%cpos, 0)@" "@getword(%cpos, 1)@" 0", getword($TeamDuel::Center[%cl.Team], 0)@" "@getword($TeamDuel::Center[%cl.Team], 1)@" 0") + 0.5);
					//%distance2 = floor(Vector::getDistance(GameBase::getPosition(%cl), gamebase::getposition($TeamDuel::Sensor[%cl.Team])) + 0.5);
					//messageall(1, Client::getname(%cl)@" distance from center: "@%distance@" distance from sensor: "@%distance2);
					if(%distance < $TeamDuel::MissionArea[%cl.team] && $Teamduel::arena[%cl.team] != "Map")
					{
						if(%cl.oob)
						{
							Client::sendMessage(%cl,1,"You have entered the mission area.");
						}
						%cl.oob = false;
					}
					//both("distance... "@%distance);
					if(%distance > $TeamDuel::MissionArea[%cl.team])
					{
						if(%cl.oob == "false")
						{
							%cl.oob = true;
							Client::sendMessage(%cl,1,"You have left the mission area.");
							alertPlayer(%cl, 10);
							%posX = getWord($TeamDuel::Center[%cl.Team],0);
							%posY = getWord($TeamDuel::Center[%cl.Team],1);
							IssueCommand(%cl, %cl, 0, "Waypoint set to mission center", %posX, %posY);
						}
					}
				}
			}
		}
	}
	else
	{
		//both("Start time does not match. stopping mission area");
		return;
	}
	schedule("CreateMissionArea(\""@%Teams@"\", \""@%time@"\");", 5);
}
function alertPlayer(%client, %count)
{
	echo("ALERT PLAYER "@%client@" ALIVE? "@%client.isAlive);
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(alertPlayer);
	}
	if(%client.isAlive)
	{
		if(%client.Team != "" && $TeamDuel::Arena[%client.Team] == "None")
		{
			echo("arena is none... check oob");
			%distance = floor(Vector::getDistance(GameBase::getPosition(%client), $TeamDuel::Center[%client.Team]) + 0.5);
			if(%distance < $TeamDuel::MissionArea[%client.team])
			{
				if(%client.oob)
				{
					Client::sendMessage(%client,1,"You have entered the mission area.");
				}
				%client.oob = false;
				return;
			}
		}
		if(%client.oob)
		{
			playSound(OOBEEP,GameBase::getPosition(client::getownedobject(%client)));
			//Client::sendMessage(%client,1,"~wLeftMissionArea.wav");
			if(%count > 1)
			schedule("alertPlayer(" @ %client @ ", " @ %count - 1 @ ");",1.5,%client);
			else
			schedule("leaveMissionAreaDamage(" @ %client @ ");",1,%client);
		}
	}
}


function leaveMissionAreaDamage(%client)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(leaveMissionAreaDamage);
	}
	if($TeamDuel::CanHurt[%client.Team] && %client.isAlive)
	{
		if(%client.Team != ""  && $TeamDuel::Arena[%client.Team] == "None")
		{
			echo("checking non arena oob info");
			%distance = floor(Vector::getDistance(GameBase::getPosition(%client), $TeamDuel::Center[%client.Team]) + 0.5);
			if(%distance < $TeamDuel::MissionArea[%client.team])
			{
				%client.oob = false;
				Client::sendMessage(%client,1,"You have entered the mission area.");
				return;
			}
		}

		if(%client.Team != ""  && $TeamDuel::Arena[%client.Team] == "Map")
		{
			echo("checking arena oob info: .... please work");
		}

		%player = Client::getOwnedObject(%client);
		if(%client.oob)
		{
			if(!Player::isDead(%player) && %client.isAlive)
			{
				Player::setDamageFlash(%client,0.6);
				if((GameBase::getDamageLevel(%player) + 0.05) >= (Player::getArmor(%player)).maxdamage && $TeamDuel::CanHurt[%client.Team])
				{
					Client::sendMessage(%client,1,"You have been killed for leaving the mission area.~wLeftMissionArea.wav");
					MessageAllExcept(%client, 1, Client::getName(%client) @ " has been killed for leaving the mission area.");
					playNextAnim(%client);
					Player::kill(%client);
					Client::onKilled(%client, %client, -2);
				}
				else
				{
					GameBase::setDamageLevel(%player,GameBase::getDamageLevel(%player) + 0.05);
					schedule("leaveMissionAreaDamage(" @ %client @ ");",1);
				}
			}
		}
	}
}
function EndRound(%Team1, %Team2)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False EndRound");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(EndRound);
	}
	if($TeamDuel::Arena[%Team1] == "None" || $TeamDuel::Arena[%Team2] == "None")
	{
	//	deleteSensors(%Team1, %Team2);
	}
	$TeamDuel::Start[%Team1] = "";
	$TeamDuel::Start[%Team2] = "";
	echo("EndRound called for teams ("@%Team1@") and ("@%Team2@")");
	if($TeamDuel::Arena[%Team1] == "None" || $TeamDuel::Arena[%Team2] == "None")
	{
		Delete($TeamDuel::Leader[%Team1]);
		Delete($TeamDuel::Leader[%Team2]);
	}
	ForceObserver(%Team1, %Team2, true);
	DuelMOD::missionObjectives();

	%winner = "";
	//%cl.observerMode = "";
	if(GetTeamPlayerCount(%Team1) == "0")
	{
		%winner = %Team2;
	}
	if(GetTeamPlayerCount(%Team2) == "0")
	{
		%winner = %Team1;
	}
	if($TeamDuel::Score[%Team1] == $TeamDuel::Rounds[%Team1] && %winner == "" && %Team1 != "" && %Team2 != "")
	{
		%winner = %Team1;
		%loser = %Team2;
	}
	if($TeamDuel::Score[%Team2] == $TeamDuel::Rounds[%Team2] && %winner == "" && %Team1 != "" && %Team2 != "")
	{
		%winner = %Team2;
		%loser = %Team1;
	}
	if($TeamDuel::Score[%Team1] > $TeamDuel::Score[%Team2] && %winner == "" && %Team1 != "" && %Team2 != "")
	{
		%message = "<f1><jc>You are winning by " @ $TeamDuel::Score[%Team1] - $TeamDuel::Score[%Team2] @ ".  You need " @  $TeamDuel::Rounds[%Team1] - $TeamDuel::Score[%Team1] @ " games to win! \n ";
		PrintTeam(%Team1, %message, center);//top, center, bottom
		%message = "<f1><jc>You are losing by " @ $TeamDuel::Score[%Team1] - $TeamDuel::Score[%Team2] @ ".  They need " @ $TeamDuel::Rounds[%Team1] - $TeamDuel::Score[%Team1] @ " games to win! \n ";
		PrintTeam(%Team2, %message, center);//top, center, bottom
	}
	if($TeamDuel::Score[%Team2] > $TeamDuel::Score[%Team1] && %winner == "" && %Team1 != "" && %Team2 != "")
	{
		%message = "<f1><jc>You are winning by " @ $TeamDuel::Score[%Team2] - $TeamDuel::Score[%Team1] @ ".  You need " @  $TeamDuel::Rounds[%Team2] - $TeamDuel::Score[%Team2] @ " games to win! \n ";
		PrintTeam(%Team2, %message, center);//top, center, bottom
		%message = "<f1><jc>You are losing by " @ $TeamDuel::Score[%Team2] - $TeamDuel::Score[%Team1] @ ".  They need " @ $TeamDuel::Rounds[%Team2] - $TeamDuel::Score[%Team2] @ " games to win! \n ";
		PrintTeam(%Team1, %message, center);//top, center, bottom
	}
	if($TeamDuel::Score[%Team2] == $TeamDuel::Score[%Team1] && %winner == "" && %Team1 != "" && %Team2 != "")
	{
		%message = "<f1><jc>You are tied.  You need " @ $TeamDuel::Rounds[%Team2] - $TeamDuel::Score[%Team2] @ " games to win! \n ";
		PrintTeam(%Team1@" "@%Team2, %message, center);//top, center, bottom
	}
		%client1 = $TeamDuel::Leader[%Team1];
		%client2 = $TeamDuel::Leader[%Team2];
		$DuelSpawnMarker[%Team1] = "";
		$DuelSpawnMarker[%Team2] = "";
		$DuelSpotTaken[$DuelSpotIndex[%client1]] = false;
		$DuelSpotTaken[$DuelSpotIndex[%client2]] = false;
		$DuelSpotIndex[%client1] = "";
		$DuelSpotIndex[%client2] = "";
	if(%winner != "" && %Team1 != "" && %Team2 != "")
	{
		$ArenaInUse[$TeamDuel::Arena[%winner], $TeamDuel::ArenaNum[%winner]] = false;

		$TeamDuel::ArenaStatus[$TeamDuel::Arena[%winner]] = "Free";
		$TeamDuel::ArenaStatus[$TeamDuel::Arena[%loser]] = "Free";
		%message = $TeamDuel::Name[%winner] @" ("@ $TeamDuel::Score[%winner] @") has triumphed over "@ $TeamDuel::Name[%loser] @" ("@ $TeamDuel::Score[%loser] @") !" ;
		TMessage(666, 666,  $Red, %message, 1);
		$TeamDuel::Wins[%winner]++;
		$TeamDuel::Losses[%loser]++;
		$TeamDuel::Challenging[%winner] = "";
		$TeamDuel::Challenging[%loser] = "";
		$TeamDuel::InMatch[%winner] = "";
		$TeamDuel::InMatch[%loser] = "";
		$TeamDuel::Score[%winner] = "0";
		$TeamDuel::Score[%loser] = "0";
		$TeamDuel::InMatch[%winner] = "";
		$TeamDuel::InMatch[%loser] = "";
		ClearSpawns(%Team1, %Team2);
		//DeleteArena($TeamDuel::Arena[%winner]);
		//$TeamDuel::Arena[%winner] = "None";
		//$TeamDuel::Arena[%loser] = "None";
		echo("Match is over for ("@%winner@") and ("@%loser@")");
		if($onlyonce == "false")
		{
			//messageall(1, "Resuming map change.");
			Game::checkTimeLimit();
		}
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.team == %winner || %cl.team == %loser)
			{
				Score::IncreaseStat(%cl, "TDMatchesPlayed", 1);
				if(%cl.team == %winner)
					Score::IncreaseStat(%cl, "TDMatchesWon", 1);
				if(%cl.team == %loser)
					Score::IncreaseStat(%cl, "TDMatchesLost", 1);
			}
		}
		return;
	}
	if(%Team1 != "" && %Team2 != "")
	{
		SetStats(%Team1);
		SetStats(%Team2);
	}
	if($TeamDuel::InMatch[%Team1] == "True" && $TeamDuel::InMatch[%Team2] == "True")
	{
		//messageall($GREEN, "drop now");
		schedule("MatchSetup("@ %Team1 @","@ %Team2 @");", 2.0);
	}
}


function LockTeam(%clientId, %pl)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(LockTeam);
	}
		%clientId.InvTrips = 0;
		if($TeamDuel::Arena[%clientId.Team] != "None" && $TeamDuel::ArenaSpawn[%clientId.Team])
		{
			%clientId.InvTrips++;
			%clientId.InvTrips++;
		}
	   Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
	   Observer::setOrbitObject(%clientId, %pl, 5, 5, 5);
		if($TeamDuel::Leader[%clientId.team].notready || $TeamDuel::Leader[$TeamDuel::Challenging[%clientId.team]].notready)
		{
		   %clientId.observerMode = "pregame";
		}
		else
		{
			schedule("Client::setControlObject("@%clientId@", "@%clientId.Owns@");", 1);
			GameBase::SetDamageLevel(%clientId.Owns, 0);
			%clientId.guiLock = false;
			Client::setGuiMode(%clientId, $GuiModePlay);
			%clientId.oob = false;
		}
}






function SetupTeamSpawn(%team, %overwrite)
{
	if(%Team == "")	{		return echo("False SetupTeamSpawn");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(SetupTeamSpawn);
	}
	%spot = 0;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl == %overwrite && %cl > "2000" && %overwrite > "2000")
		{
			//echo(%overwrite@" overwrite");
			//echo("Left Off: "@$TeamDuel::LeftOff[%team]);
			%spot = $TeamDuel::LeftOff[%team];
			%cl.observerMode = "";
			%cl.observerTarget = "";
			%cl.guiLock = true;
			Client::setGuiMode(%cl, $GuiModePlay);
			%pl = TeamDuelSpawn(%cl, %spot);
			LockTeam(%cl, %pl);
			gamebase::setteam(%cl, $TeamDuel::RealTeam[%overwrite.Team]);
			if($TeamDuel::Skin[%cl.Team] != "")
			{
				Client::setSkin(%cl, $TeamDuel::Skin[%cl.Team]);
			}

			%cl.isAlive = "True";
			Game::refreshClientScore(%cl);
			$TeamDuel::LeftOff[%team] = %spot++;
			echo("Setup Team Spawn ran for ["@%cl@"]"@Client::getname(%cl)@" Ticker Spawned");
			if($TeamDuel::Ticker[%cl.Team] == "" && $TeamDuel::InMatch[%cl.Team] == "True" && $TeamDuel::CanHurt[%cl.Team] == "")
			{
				Client::setControlObject(%cl, %cl.Owns);
				GameBase::SetDamageLevel(%cl.Owns, 0);
				%cl.guiLock = false;
				Client::setGuiMode(%cl, $GuiModePlay);
				%cl.oob = false;
				if(Client::getOwnedObject(%cl) == "-1")
				{
					Client::setOwnedObject(%cl, %cl.owns);
				}
			}
			//echo("Left Off: "@$TeamDuel::LeftOff[%team]);
			return;
		}
	}
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
			if(%cl.Team == %team && $TeamDuel::Leader[%team] != %cl || $TeamDuel::Arena[%cl.Team] != "None" && %cl.Team == %team)
			{
					if($Roaming[%cl] == "True")
					{
						//Item::Pop(%zit);
						playNextAnim(%cl);
						player::kill(%cl);
						Observer::enterObserverMode(%cl);
						gamebase::setTeam(%cl, -1);
						$Roaming[%cl] = false;
						//return;
					}
				%spot++;
				if($TeamDuel::Arena[%team] != "None")
				{
					%cl.Arena = "True";
				}
				%cl.observerMode = "";
				%cl.observerTarget = "";
				DM::LeaveDM(%cl);
				%cl.guiLock = true;
				Client::setGuiMode(%cl, $GuiModePlay);
				%pl = TeamDuelSpawn(%cl, %spot);
				LockTeam(%cl, %pl);
				gamebase::setteam(%cl, $TeamDuel::RealTeam[%team]);
				if($TeamDuel::Skin[%team] != "")
				{
					Client::setSkin(%cl, $TeamDuel::Skin[%team]);
				}
				%cl.isAlive = "True";
				Game::refreshClientScore(%cl);
				echo("Client: "@ client::getname(%cl) @"("@ %cl @") Team: " @ %team @ " PL: " @ %pl @" Spot: "@ %spot @" Owns: "@ %cl.Owns);
			}
	}
	$TeamDuel::LeftOff[%team] = %spot++;
}



function SpawnNoObjects(%clientId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(SpawnNoObjects);
	}
		%p = 0;
		%xoffset=5;
		%pos = gamebase::getposition(%clientId);
		%rot = gamebase::getrotation(%clientId);

		$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
		$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;

	for(%i = 1; %i < 16; %i++)
	{
		%pos = gamebase::getposition(%clientId);
		if((%i % 2) == 0)
		{
			%xoffset+=5;
			%pos = getword(%pos, 0)+%xoffset @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2)+200 ;
			//echo("even "@%i);
		}
		else
		{
			%pos = getword(%pos, 0) - %xoffset @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2)+200 ;
			//echo("odd "@%i);
		}
		$TeamDuel::Spawn[%clientId.Team, %p++] = %pos;
		//echo(%pos);
		$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
	}

		echo("Non Arena Battle Spawn Points Created: "@%p@", Team: "@%clientId.Team);
}



function SpawnNoArena(%clientId, %bonus)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(SpawnNoArena);
	}
	%player = Client::getOwnedObject(%clientId);
	gamebase::getlosinfo(%player, 3,"-1.57 0 0");
	%my_object = $los::object;
	%name = Object::getName(%my_object);
	if(%name == "Terrain")
	{
		SpawnNoObjects(%clientId);
		SetupTeamSpawn(%clientId.Team, %bonus);
		return;
	}
	if(%NAME == "iobservation1")
	{
		SpawnNoObjects(%clientId);
		SetupTeamSpawn(%clientId.Team, %bonus);
		return;
		if(GetTeamPlayerCount(%clientId.Team) >= 2)
		{
			%p = 0;
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2)-5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p] = %spawn;
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 3)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2)-5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 4)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2)-5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 5)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2)-5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 6)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2)-5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 7)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2)-5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 8)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2)-5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 9)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2)-5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		SetupTeamSpawn(%clientId.Team, %bonus);
		return;
	}
	if(%name == "aflagcolumn1" || %name == "mis_ob11" )
	{
		%rot = gamebase::getrotation(%clientId);
		if(GetTeamPlayerCount(%clientId.Team) >= 2)
		{
			%p = 0;
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%my_object);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2)-2.5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = gamebase::getposition(%clientId);
			%rot = gamebase::getrotation(%clientId);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 3)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%my_object);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2)-2.5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = gamebase::getposition(%clientId);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 4)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%my_object);
			%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2)-2.5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = gamebase::getposition(%clientId);
			%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 5)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%my_object);
			%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2)-2.5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = gamebase::getposition(%clientId);
			%pos = getword(%pos, 0) @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 6)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%my_object);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2)-2.5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = gamebase::getposition(%clientId);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;

		if(GetTeamPlayerCount(%clientId.Team) >= 7)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%my_object);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2)-2.5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = gamebase::getposition(%clientId);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 8)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%my_object);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2)-2.5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = gamebase::getposition(%clientId);
			%pos = getword(%pos, 0)+5 @ " " @ getword(%pos, 1)-5 @ " " @ getword(%pos, 2) ;

		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		if(GetTeamPlayerCount(%clientId.Team) >= 9)
		{
			%spawn = SpawnIt("aflagcolumn.dis");
			%pos = gamebase::getposition(%my_object);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2)-2.5 ;
			gamebase::setposition(%spawn, %pos);
			gamebase::setrotation(%spawn, gamebase::getrotation(%my_object));
			$TeamDuel::SpawnedItem[%clientId.Team, %p++] = %spawn;
			%pos = gamebase::getposition(%clientId);
			%pos = getword(%pos, 0)-5 @ " " @ getword(%pos, 1)+5 @ " " @ getword(%pos, 2) ;
		}
			$TeamDuel::Spawn[%clientId.Team, %p] = %pos;
			$TeamDuel::SpawnRot[%clientId.Team, %p] = %rot;
		SetupTeamSpawn(%clientId.Team, %bonus);
		return;

	}
	if(%name == "iblock1")
	{
		SpawnNoObjects(%clientId);
		SetupTeamSpawn(%clientId.Team, %bonus);
		return;
	}
	if(%name == "esmblock1")
	{
		SpawnNoObjects(%clientId);
		SetupTeamSpawn(%clientId.Team, %bonus);
		return;
	}
	if(%name == "COPSfloatingpad1")
	{
		SpawnNoObjects(%clientId);
		SetupTeamSpawn(%clientId.Team, %bonus);
		return;
	}
	SpawnNoObjects(%clientId);
	SetupTeamSpawn(%clientId.Team, %bonus);
	$los::object = "";
}


function ForceObserver(%Team1, %Team2, %endRound)
{
	if(%Team1 == "" || %Team2 == "")	{		return echo("False ForceObserver");	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(ForceObserver);
	}
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
	{
		if(%cl.Team == %Team1 && %Team1 != "" || %cl.Team == %Team2 && %Team2 != "")
		{
			%cl.observerTarget = "";
			if($TeamDuel::Arena[%Team1] == "None" || $TeamDuel::Arena[%Team2] == "None")
			{
				ClearMines(%cl);
			}
			Client::setGuiMode(%cl, $GuiModePlay);
			//if(%cl.dm != "true")
			//{
				gamebase::setteam(%cl, -1);
				Observer::enterObserverMode(%cl);
				%cl.observerMode = "observerFly";
			//}
			%cl.guilock = false;
			Client::setGuiMode(%cl, $GuiModePlay);

			Game::refreshClientScore(%cl);
			setCommandStatus(%cl, 0, "");

			remoteEval(%cl, "setTime", -%curTimeLeft);
			if(%endRound)
			{
				Score::IncreaseStat(%cl, "TDRoundsPlayed", 1);
				if(%cl.isAlive == "True")
				{
					Score::IncreaseStat(%cl, "RoundsSurvived", 1);
				}
			}
			%cl.IsAlive = "";
		}
	}
}
function DisOwn(%cl)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(DisOwn);
	}
	if(%cl.IsAlive != "True")
	{
		%cl.Owns = "";
	}
}
function ForceOneObs(%clientId, %killId)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(ForceOneObs);
	}
	gamebase::setteam(%clientId, -1);
	Observer::enterObserverMode(%clientId);
	%clientId.guilock = false;
	Client::setGuiMode(%clientId, $GuiModePlay);
	setCommandStatus(%clientId, 0, "");
	%clientId.IsAlive = "";
	%clientId.cantrigger = false;
	schedule("cantrigger("@%clientId@");", 1);
	schedule("canjump("@%clientId@");", 1);
    %clientId.canjump = false;
	if(%clientId != %killId)
	{
		%clientId.observerMode = "observerOrbit";
		setObsOrbit(%clientId, %killId, %x, %y, %z);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%cl.observertarget == %clientId && %cl.observertarget.DM != "true")
			{
				setObsOrbit(%cl, %killId, %x, %y, %z);
				%cl.observerMode = "observerOrbit";
			}
		}
	}
	%possessId = CheckIdle(%clientId.team);
	if(%possessId != false)
	{
		//client::sendmessage(%clientId, $Green, "You have idle player(s) on your team, observe him/her and use the Tab menu to possess!"@$beep);
		client::sendmessage(%clientId, $Green, "You have idle player(s) on your team, automatically possessing "@client::getname(%possessID)@"!"@$beep);
		schedule("TeamDuel::Possess("@%clientId@","@%possessId@");", 0.3);
	}
	if(%clientId.dm)
	{
		%clientId.observerMode = "dead";
	}
}



$loaded["TDMain.cs"] = true;
schedule("MakeSensors();", 5);

//%client = GameBase::getOwnerClient(%player);
//%trans = GameBase::getMuzzleTransform(%player);
//%vel = Item::getVelocity(%player);
//Projectile::spawnProjectile("sniperlaser2",%trans,%player,%vel);
$TDisLoaded = true;
exec(TDCTF);

exec(MultiTD);