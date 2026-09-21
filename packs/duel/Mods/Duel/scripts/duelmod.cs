	$Duel::Offsets[0] = "0 2048 0";
	$Duel::Offsets[1] = "2048 0 0";
	$Duel::Offsets[2] = "-2048 -2048 0";
	$Duel::Offsets[3] = "0 -2048 0";
	$Duel::Offsets[4] = "-2048 0 0";
	$Duel::Offsets[5] = "2048 -2048 0";
	$Duel::Offsets[6] = "-2048 2048 0";
	$Duel::Offsets[7] = "2048 2048 0";
	$Duel::Offsets[8] = "0 2048 0";
	$Duel::Offsets[9] = "2048 0 0";
	$Duel::Offsets[10] = "-2048 -2048 0";
	$Duel::Offsets[11] = "0 -2048 0";
	$Duel::Offsets[12] = "-2048 0 0";
	$Duel::Offsets[13] = "2048 -2048 0";

	$Duel::Master = true;

function resetLOS()
{
	 $los::position = ""; //Position the LOS hit the object "X Y Z".
	 $los::normal = "";//LOS vector Normalized.
	 $los::object = "";//The Id of the object that was hit by the LOS
 }

function RandomDuelSpawns(%x, %cnt)
{
	%offsetrot[0] =  "0 0 -1.57";
	%offsetrot[1] =  "0 0 1.57";
	%offsetrot[2] =  "0 0 0";
	%offsetrot[22] =  "0 0 -3.1401";
	%offsetrot[3] =  "0 0 -3.1397";
	%offsetrot[32] =  "0 0 0";
	//echo("X & Count: "@%x@" "@%cnt);
	%xcord = floor(getrandom()*1000);
	%ycord = floor(getrandom()*1000);
	$CDSP="";
	CheckDSPosition(%xcord,%ycord);
	//echo("CDSP"@$CDSP);
	if(getword($CDSP, 0)=="true")
	{
		echo("YAY GOT ONE!"@%x);
		$Duel::SpawnMarkerPos[%x, 1] = getword($CDSP, 2)@" "@getword($CDSP, 3)@" "@getword($CDSP, 4)+2 ;
		$Duel::SpawnMarkerPos[%x, 2] = getword($CDSP, 5)@" "@getword($CDSP, 6)@" "@getword($CDSP, 4)+2 ;

		$Duel::SpawnMarkerRot[%x, 1] = %offsetrot[getword($CDSP, 1)];

		if(getword($CDSP, 1) == "2")
		{
			$Duel::SpawnMarkerRot[%x, 2] = %offsetrot[22];
		}
		else if(getword($CDSP, 1) == "3")
			{
				$Duel::SpawnMarkerRot[%x, 2] = %offsetrot[32];
			}
		else
		{
			$Duel::SpawnMarkerRot[%x, 2] = vector::neg(%offsetrot[getword($CDSP, 1)]);
		}

		%x++;
	}else {
		return RandomDuelSpawns(%x, %cnt++);
	}
	$CDSP = "";
	if(%x < 14)
	{
		RandomDuelSpawns(%x, %cnt++);
	}

}

function CheckDSPosition(%x,%y)
{
	%dist = floor(20+((1+getrandom())*40));
	%offset[0] = %dist@" 0 0";
	%offset[1] = "-"@%dist@" 0 0";
	%offset[2] =  "0 "@%dist@" 0";
	%offset[3] =  "0 -"@%dist@" 0";




	resetlos();
	%pos = %x@" "@%y@" 10000";
	%rot = "0 0 0";
	%armor = "larmor";
	%distance = "20000";
	%pl = spawnPlayer(%armor, %pos, %rot);
	%rot = "-1.57 0 0";
	GameBase::getLOSInfo(%pl, %distance, %rot);

	//deleteObject(%pl);
	//both("hmm "@Object::getName($los::object));
	if(Object::getName($los::object) == "Terrain")
	{
		%dueler1pos = $los::position;


		//echo("random "@%rndm);
		for(%v = 0; %v < 4; %v++)
		{
			//both("cycles:"@%v);
			//both(%pos@" offset = "@%offset[%v]);
			//both("Sum = "@vector::add(%pos, %offset[%v]));
			gamebase::setposition(%pl, vector::add(%pos, %offset[%v]));

			resetlos();
			GameBase::getLOSInfo(%pl, %distance, %rot);
			if(Object::getName($los::object) == "Terrain")
			{
				//echo("DP "@%dueler1pos@" LOS "@$los::position);
				//echo("SUBTRACT: "@floor(getword($los::position, 2)-getword(%dueler1pos,2))@" and "@floor(getword(%dueler1pos,2)-getword($los::position, 2)));
				//echo(getword($los::position, 2)-getword(%dueler1pos,2)@"-"@getword($los::position, 2)-getword(%dueler1pos,2));
				%dif = floor(getword($los::position, 2)-getword(%dueler1pos,2));
				if(%dif > 0 && %dif < 15)
				{
					deleteobject(%pl);
					return $CDSP = true@" "@%v@" "@%x@" "@%y@" "@floor(getword($los::position, 2))@" "@floor(getword($los::position, 0))@" "@floor(getword($los::position, 1)) ;
				}
				else
				{
					%dif = floor(getword(%dueler1pos,2)-getword($los::position, 2));
					if(%dif > 0 && %dif < 15)
					{
						deleteobject(%pl);
						return $CDSP = true@" "@%v@" "@%x@" "@%y@" "@floor(getword($los::position, 2))+35@" "@floor(getword($los::position, 0))@" "@floor(getword($los::position, 1)) ;
					}
					else
					{
						deleteobject(%pl);
						$CDSP = false;
						echo("Utter Failure@!");
					}
				}
			}
		}
	}
	if(isobject(%pl))
	{
		deleteobject(%pl);
	}
}

   if(isobject($BuildGroup) == "False")
   {
	   echo("BG");
	   $BuildGroup = newObject(BuildGroup, SimGroup);
   }
function a(%tick)
{
	%tick--;
	echo("gon "@$Gonrena::made);
	if(%tick > 0)
	{
		schedule("a("@%tick@");", 0.1);
	}
}
//a(100);

if(nameToID("MissionGroup/Duel1") == "-1")
{
	echo("Osnap No Spawns!");
	$Map::Original = true;
	RandomDuelSpawns(0, 0);



}
else {

	for(%x = 1; %x < 13; %x++)
	{
		$Map::Original = false;

		$DuelSpotTaken[%x] = false;
		%group = nameToID("MissionGroup/Duel" @ %x);
		$Duel::SpawnMarkerPos[%x, 1] = gamebase::getposition(Group::getObject(%group, 0));
		$Duel::SpawnMarkerRot[%x, 1] = gamebase::getrotation(Group::getObject(%group, 0));
		$Duel::SpawnMarkerPos[%x, 2] = gamebase::getposition(Group::getObject(%group, 1));
		$Duel::SpawnMarkerRot[%x, 2] = gamebase::getrotation(Group::getObject(%group, 1));
		//$Duel::SpawnMarker[%x, 1] = (Group::getObject(%group, 0));
		//$Duel::SpawnMarker[%x, 2] = (Group::getObject(%group, 1));
	}
	echo("Regular Duel Setup, Spawns: "@%x);
	for(%v = 1; %v < 14; %v++)
	{
		echo(%v@": "@$Duel::SpawnMarkerPos[%v, 1]@"     -     "@$Duel::SpawnMarkerPos[%v, 2]);
		echo(%v@": "@$Duel::SpawnMarkerRot[%v, 1]@"     -     "@$Duel::SpawnMarkerRot[%v, 2]);
	}
}
//$qq=1;


echo("Loading Duelmod.cs");
exec(objectives);
exec("DuelRecord.cs");
if(!$Duel::RecordTime) $Duel::RecordTime = 9999;
$DuelBestTime = 9999;

$DuelSpotTaken[1] = false;
$DuelSpotTaken[2] = false;
$DuelSpotTaken[3] = false;
$DuelSpotTaken[4] = false;
$DuelSpotTaken[5] = false;
$DuelSpotTaken[6] = false;
$DuelSpotTaken[7] = false;
$DuelSpotTaken[8] = false;
$DuelSpotTaken[9] = false;
$DuelSpotTaken[10] = false;
$DuelSpotTaken[11] = false;
$DuelSpotTaken[12] = false;

$DuelDelayTime = 4;
$DuelHurtDelay = 1.5;

$DuelWeaponMax = 8;
$DuelPackMax = 4;

$DuelWeapon[1] = "Chaingun";
$DuelWeapon[2] = "Plasma Gun";
$DuelWeapon[3] = "Disc Launcher";
$DuelWeapon[4] = "Grenade Launcher";
$DuelWeapon[5] = "Laser Rifle";
$DuelWeapon[6] = "ELF Gun";
$DuelWeapon[7] = "Blaster";
$DuelWeapon[8] = "Mortar";
//$DuelWeapon[9] = "TreeGun";
//$DuelWeapon[10] = "WeedEater";

$DuelArmor[1] = "Light Armor";
$DuelArmor[2] = "Medium Armor";
$DuelArmor[3] = "Heavy Armor";

$DuelRealArmor[1] = "larmor";
$DuelRealFArmor[1] = "lfemale";
$DuelRealArmor[2] = "marmor";
$DuelRealFArmor[2] = "mfemale";
$DuelRealArmor[3] = "harmor";

$DuelPack[1] = "Energy Pack";
$DuelPack[2] = "Repair Pack";
$DuelPack[3] = "Shield Pack";
$DuelPack[4] = "Ammo Pack";
$DuelPack[5] = "Camera Pack";

$DuelRealPack[1] = EnergyPack;
$DuelRealPack[2] = RepairPack;
$DuelRealPack[3] = ShieldPack;
$DuelRealPack[4] = AmmoPack;
$DuelRealPack[5] = CameraPack;

$DuelRealWeapon[1] = Chaingun;
$DuelRealWeapon[2] = PlasmaGun;
$DuelRealWeapon[3] = DiscLauncher;
$DuelRealWeapon[4] = GrenadeLauncher;
$DuelRealWeapon[5] = LaserRifle;
$DuelRealWeapon[6] = EnergyRifle;
$DuelRealWeapon[7] = Blaster;
$DuelRealWeapon[8] = Mortar;
$DuelRealWeapon[9] = DiscLauncherKing;
$DuelRealWeapon[10] = DiscLauncherBlue;
$DuelRealWeapon[11] = DiscLauncherGreen;
$DuelRealWeapon[12] = DiscLauncherYellow;
$DuelRealWeapon[13] = DiscLauncherPink;
$DuelRealWeapon[13] = DiscLauncherBlack;
$DuelRealWeapon[14] = DiscLauncherPurple;
//$DuelRealWeapon[9] = TreeGun;
//$DuelRealWeapon[10] = WeedEater;

$DuelWeaponAmmo[1] = BulletAmmo;
$DuelWeaponAmmo[2] = PlasmaAmmo;
$DuelWeaponAmmo[3] = DiscAmmo;
$DuelWeaponAmmo[4] = GrenadeAmmo;
$DuelWeaponAmmo[8] = MortarAmmo;
function DuelCountdown(%clientId, %foeId, %timeLeft, %clientPl, %foePl) {
	if(!$Dueling[%clientId] || !$Dueling[%foeId])
	{
		$Duel::CountDown[%clientId] = "";
		$Duel::CountDown[%foeId] = "";
		return;
	}
	$Duel::CountDown[%clientId] = true;
	$Duel::CountDown[%foeId] = true;
	if (%timeLeft == 0) {
		$Duel::CountDown[%clientId] = "";
		$Duel::CountDown[%foeId] = "";
		BeginDuel(%clientId, %foeId, %clientPl, %foePl);
		return;
	}
	if (%timeLeft == 1) {
		BottomPrint(%clientId,"<jc><f1>Duel starts in <f2>1<f1> second.",2);
		BottomPrint(%foeId,"<jc><f1>Duel starts in <f2>1<f1> second.",2);
	} else {
		if (%timeLeft > 5) {
			CenterPrint(%clientId,"<jc><f2>READY!",2);
			CenterPrint(%foeId,"<jc><f2>READY!",2);
		} else {
			BottomPrint(%clientId,"<jc><f1>Duel starts in <f2>" @ %timeLeft @ "<f1> seconds.",2);
			BottomPrint(%foeId,"<jc><f1>Duel starts in <f2>" @ %timeLeft @ "<f1> seconds.",2);
		}
	}
	schedule("DuelCountdown(" @ %clientId @ "," @ %foeId @ "," @ (%timeLeft - 1) @ "," @ %clientPl @ "," @ %foePl @ ");", 1);
}
function PrefsReset(%client)
{
	$SpeedDuel[%clientId] = "False";
	%clientId.prefs["obsmode"] = "1stPerson";
}
function DuelResetClient(%clientId) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(DuelResetClient);
	}
	$Dueling[%clientId] = "";
	$DuelLineup[%clientId] = "";
	$DuelLastEnemy[%clientId] = "";
	$DuelWeaponSetup[%clientId, 0] = 0;
	$DuelWeaponSetup[%clientId, 1] = 0;
	$DuelWeaponSetup[%clientId, 2] = 0;
	$DuelPack[%clientId] = "1";
	$DuelArmor[%clientId] = "1";
   	$HighStreak[%clientId] = 0;

   	$DuelStreak[%clientId] = 0;

	%clientId.guiLock = false;



	//TD
	$Roaming[%clientId] = false;
	%clientid.MovementType = "Free Move";
   $DuelMidAir[%clientId] = 0;
   $DuelMaDist[%clientId] = 0;


   $DuelarmorType[%clientId] = "larmor";
   %clientId.Team = "";
   %clientId.canjump = true;
   %clientId.cantrigger = true;
   %clientId.debug = "";
   %clientId.loaded = false;
   %clientId.pack = 1;
   %clientId.armor = 1;
   %client.DM = false;
   %client.GoToSpecialMap = false;
   Stats::Reboot(%clientId);
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	remoteEval(%clientId, "setTime", -%curTimeLeft);
	%clientId.PWTries = 0;
	//if(%clientId.Team != "")
	//{
	//	LeaveTeam(%clientId);
	//}
	//TD
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(DuelResetClientEnd);
	}
}

function LockPlayers(%clientId, %foeId, %clientPl, %foePl) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(LockPlayers);
	}
	%clientId.observerMode = "pregame";
 	Client::setControlObject(%clientId, Client::getObserverCamera(%clientId));
 	//Observer::setOrbitObject(%clientId, %clientPl, -9, -9, -9);
 	Observer::setOrbitObject(%clientId, %clientPl, 5, 5, 5);
 	%foeId.observerMode = "pregame";
 	Client::setControlObject(%foeId, Client::getObserverCamera(%foeId));
 	//Observer::setOrbitObject(%foeId, %foePl, -9, -9, -9);
 	Observer::setOrbitObject(%foeId, %foePl, 5, 5, 5);

 	//TD
	//JamDueler(%clientPl);
	//JamDueler(%foePl);
}

function DuelStartHurt(%clientId, %foeId) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(LockPlayers);
	}
	$DuelCanHurt[%clientId] = true;
	$DuelCanHurt[%foeId] = true;
}

function BeginDuel(%clientId, %foeId, %clientPl, %foePl) {
	%time = Time::getMinutes((floor(getSimTime()) - %clientId.LastAction));
	if(%time > 0.9)
	{
		Game::refreshClientScore(%clientId);
		%clientId.LastAction = floor(getSimTime());
	}
	else
	{
		%clientId.LastAction = floor(getSimTime());
	}
	%time = Time::getMinutes((floor(getSimTime()) - %foeId.LastAction));
	if(%time > 0.9)
	{
		%foeId.LastAction = floor(getSimTime());
		Game::refreshClientScore(%foeId);
	}
	else
	{
		%foeId.LastAction = floor(getSimTime());
	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(BeginDuel);
	}

	%clientId.shotsFired[Duel]=0;
	%foeId.shotsFired[Duel]=0;
	%clientId.shotsHit[Duel]=0;
	%foeId.shotsHit[Duel]=0;
	%clientId.dead = false;
	%foeId.dead = false;

	schedule("DuelStartHurt(" @ %clientId @ "," @ %foeId @ ");", $DuelHurtDelay);

	GameBase::SetDamageLevel(%clientPl, 0);
	GameBase::SetDamageLevel(%foePl, 0);

	Client::sendMessage(%clientId, 0, "~wduelfight.wav");
	Client::sendMessage(%foeId, 0, "~wduelfight.wav");
	BottomPrint(%clientId, "<jc><f1>----- <f2>FIGHT! <f1>-----", 3);
	BottomPrint(%foeId, "<jc><f1>----- <f2>FIGHT! <f1>-----", 3);

	for (%i = 0; %i < 3; %i++) {
		if($DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}
	for (%i = 0; %i < 3; %i++) {
		if($DuelWeaponAmmo[$DuelWeaponSetup[%foeId, %i]] == "") {
			%hasenergy = true;
			break;
		}
	}


	Client::setControlObject(%clientId, client::getownedobject(%clientId));
	Client::setControlObject(%foeId, client::getownedobject(%foeId));

	$DuelStartTime[$DuelSpotIndex[%clientId]] = getSimTime();

	%time = floor($DuelStartTime[$DuelSpotIndex[%clientId]]);

	if(!%hasenergy) schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ "," @ %time @ ");", 30);

	//remoteEval(%clientId, "setTime", 0);
	//remoteEval(%foeId, "setTime", 0);
	schedule("DuelIntegrity("@%clientId@","@%foeId@");", 2);
	//both("wat");
}
function DuelIntegrity(%cl,%foe)
{
	//both("DuelIntegCheck");
	//both("Owned obj: "@client::getownedobject(%cl)@", "@client::getownedobject(%foe)@" Dueling: "@ $Dueling[%cl]@", "@$Dueling[%foe]@" Name: "@client::getname(%cl)@", "@client::getname(%foe));
	if(client::getownedobject(%cl) == -1 || client::getownedobject(%foe) == -1 || $Dueling[%cl] != %foe || $Dueling[%foe] != %cl || client::getname(%cl) == -1 || client::getname(%foe) == -1)
	{
		FinalizeDuel(%cl, %foe);
		//both("Duel compromised");
	}
}

function PlayersOutOfAmmo(%clientId, %foeId, %time) {
	if(%clientId.dead || %foeId.dead)
	{
		return;
	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(PlayersOutOfAmmo);
	}
	if(floor($DuelStartTime[$DuelSpotIndex[%clientId]]) == %time || floor($DuelStartTime[$DuelSpotIndex[%foeId]]) == %time)
	{
		if($Dueling[%clientId] == %foeId && $Dueling[%foeId] == %clientId) {
			for (%i = 0; %i < 3; %i++) {
				if(Player::getItemCount(%clientId, $DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]]) || %clientId.menuMode == "chooseweapon") {
					schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ ","@%time@");", 15);
					return;
				}
			}
			for (%i = 0; %i < 3; %i++) {
				if(Player::getItemCount(%foeId, $DuelWeaponAmmo[$DuelWeaponSetup[%clientId, %i]]) || %clientId.menuMode == "chooseweapon") {
					schedule("PlayersOutOfAmmo(" @ %clientId @ "," @ %foeId @ ","@%time@");", 15);
					return;
				}
			}
			MessageAll(1,Client::GetName(%clientId) @ " and " @ Client::GetName(%foeId) @ " have both run out of ammo. Its a draw.");
			FinalizeDuel(%clientId, %foeId);
		}
	}
	else
	{
		//echo("Out of ammo duplicate found and stopped.");
	}
}

//function Player::leaveMissionArea(%player) { }

function FinalizeDuel(%clientId, %foeId)
{

	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(FinalizeDuel);
	}
	$Dueling[%clientId] = false;
	$Dueling[%foeId] = false;

	ClearMines(%clientId);
	ClearMines(%foeId);

	%clientId.guiLock = false;
	%foeId.guiLock = false;

	$DuelSpawnMarker[%clientId] = "";
	$DuelSpawnMarker[%foeId] = "";

	$DuelSpotTaken[$DuelSpotIndex[%clientId]] = false;
	$DuelSpotIndex[%clientId] = "";
	$DuelSpotIndex[%foeId] = "";



	Game::refreshClientScore(%clientId);
	Game::refreshClientScore(%foeId);
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	remoteEval(%clientId, "setTime", -%curTimeLeft);
	remoteEval(%foeId, "setTime", -%curTimeLeft);

	if($timereached)
	{
		echo("map over stop called...");
		return;
	}


		Observer::enterObserverMode(%clientId);
	Observer::enterObserverMode(%foeId);

   if($SpeedDuel[%clientId] == "True" && $SpeedDuel[%foeId] == "False" || $SpeedDuel[%clientId] == "EndOfD" || $SpeedDuel[%clientId] == "True" && $SpeedDuel[%foeId] == "EndOfD")
   {
		   DuelPropose(%clientId,%foeId);
   }
   if($SpeedDuel[%foeId] == "True" && $SpeedDuel[%clientId] == "False" || $SpeedDuel[%foeId] == "EndOfD" || $SpeedDuel[%foeId] == "True" && $SpeedDuel[%clientId] == "EndOfD")
   {
		   DuelPropose(%foeId,%clientId);
   }
   //TD
   DuelMOD::missionObjectives();
   //TD
}
function setT(%clientId, %foeId, %t)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(setT);
	}
//stuff start
//TD
   %numClients = getNumClients();

	for(%i = 0 ; %i < %numClients ; %i++)
	%clientList[%i] = getClientByIndex(%i);
	%doIt = 1;
	while(%doIt == 1) {
	%doIt = "";
	for(%i= 0 ; %i < %numClients; %i++) {
	if($DuelMaDist[%clientList[%i]] < $DuelMaDist[%clientList[%i+1]]) {
	   %hold = %clientList[%i];
	   %clientList[%i] = %clientList[%i+1];
	   %clientList[%i+1]= %hold;
	   %doIt=1;
	}
 }
}
  $DuelLongestMA = $DuelMaDist[%clientList[0]];
  $DuelLongestMAHolder = Client::getName(%clientList[0]);
  if($DuelLongestMA > $Duel::LongestMA)
  {
	$Duel::LongestMA = $DuelLongestMA;
	$Duel::LongestMAHolder = $DuelLongestMAHolder;
	if($Duel::LongestMA > 50)
	{
	   messageall(0, $Duel::LongestMAHolder @ " now holds the record for furthest midair: " @ $Duel::LongestMA @ " meters");
	   export("$Duel::Record*", "config\\DuelRecord.cs", False);
	}
  }

  for(%i = 0 ; %i < %numClients ; %i++)
	 %clientList[%i] = getClientByIndex(%i);
  %doIt = 1;
  while(%doIt == 1) {
	 %doIt = "";
	 for(%i= 0 ; %i < %numClients; %i++) {
		if($DuelMidair[%clientList[%i]] < $DuelMidair[%clientList[%i+1]]) {
		   %hold = %clientList[%i];
		   %clientList[%i] = %clientList[%i+1];
		   %clientList[%i+1]= %hold;
		   %doIt=1;
		}
	 }
  }
  $DuelMostMidair = $DuelMidAir[%clientList[0]];
	   $DuelMostMidairHolder = Client::getName(%clientList[0]);
	   if($DuelMostMidair > $Duel::MostMidair)
	   {
			   $Duel::MostMidair = $DuelMostMidair;
			   $Duel::MostMidairHolder = $DuelMostMidairHolder;
			   if($Duel::MostMidair > 20)
			   {
					   messageall(0, $Duel::MostMidairHolder @ " now holds the record for most midairs: " @ $Duel::MostMidair);
					   export("$Duel::Record*", "config\\DuelRecord.cs", False);
			   }
	   }
   //stuff end
	if(%t > 0 && getNumClients() > 1 && Client::getName(%clientId) != "" && Client::getName(%foeId) != "")
	{

		if(%t < $Duel::RecordTime) {
			schedule("messageall(0, \"" @ Client::getName(%foeId) @ " set a new fastest win record!~wCapturedTower.wav\");", 1.5);
	        $Duel::RecordTimeHolder = Client::getName(%foeId);
	        $Duel::RecordTimeLoser = Client::getName(%clientId);
			$Duel::RecordTime = %t;
	        export("$Duel::Record*", "config\\DuelRecord.cs", False);
		}
		if(%t < $DuelBestTime) {
	        $DuelBestTimeHolder = Client::getName(%foeId);
	        $DuelBestTimeLoser = Client::getName(%clientId);
			$DuelBestTime = %t;
		}
	}
}
function GetHealth(%cl)
{
	//%armor = Player::getArmor(%pl).maxDamage

	%pl = Client::getOwnedObject(%cl);
	%armor = Player::getArmor(%pl);
	if(Player::getItemCount(%pl, RepairKit))
	{
		%rkit = ((0.2 / %armor.maxDamage) * 100) + 0.001 ;
		%hadKit = true;
		//both("rkit: "@%rkit);
	}
	%dmg = (100 - (gamebase::getdamagelevel(%pl) / %armor.maxDamage) * 100);// + %rkit;


	%z=0;
	for(%x = 1; %x < 8; %x++)
	{
		if(%x != "5" && %x != "6" && %x != "7")
		{
			%ammo=0;
			//both(%x@" "@$DuelRealWeapon[%x]);
			if(Player::getItemCount(%pl, $DuelRealWeapon[%x]))
			{

				//both($DuelRealWeapon[%x] @" "@$DuelWeaponAmmo[%x]@" has "@Player::getItemCount(%pl, $DuelWeaponAmmo[%x])@"/"@$ItemMax[Player::getArmor(%pl), $DuelWeaponAmmo[%x]]);
				if(Player::getItemCount(%pl, "ammopack"))
				{
					%ammo = $AmmoPackMax[$DuelWeaponAmmo[%x]];
				}
				else { %ammo = 0; }
				//%count[%z++] = floor(100 - (Player::getItemCount(%pl, $DuelWeaponAmmo[%x])+%ammo / $ItemMax[Player::getArmor(%pl), $DuelWeaponAmmo[%x]]+%ammo) * 100);
				%count[%z++] = floor(((Player::getItemCount(%pl, $DuelWeaponAmmo[%x])) / ($ItemMax[%armor, $DuelWeaponAmmo[%x]]+%ammo)*100)+0.5) ;
				//both(%count[%z]);
			}
		}
	}
	if(Player::getItemCount(%pl, "ammopack"))
	{
		%count[%z++] = floor(((Player::getItemCount(%pl, Grenade)) / ($ItemMax[%armor, Grenade]+$AmmoPackMax[Grenade])*100)) ;
		//%count[%z++] = floor(((Player::getItemCount(%pl, Beacon)) / ($ItemMax[%armor, Beacon]+$AmmoPackMax[Beacon])*100)) ;
		//%count[%z++] = floor(((Player::getItemCount(%pl, MineAmmo)) / ($ItemMax[%armor, MineAmmo]+$AmmoPackMax[MineAmmo])*100)/2) ;
	}
	else {
		%count[%z++] = floor(((Player::getItemCount(%pl, Grenade)) / ($ItemMax[%armor, Grenade])*100)) ;
		//%count[%z++] = floor(((Player::getItemCount(%pl, Beacon)) / ($ItemMax[%armor, Beacon])*100)) ;
		//%count[%z++] = floor(((Player::getItemCount(%pl, MineAmmo)) / ($ItemMax[%armor, MineAmmo])*100)/2) ;
	}
	if(Player::getItemCount(%pl, RepairKit))
	{
		%count[%z++] = 100;
	}
	else {
		%count[%z++] = 0;
	}
	for(%x = 1; %x < %z+1; %x++)
	{
		//both("counts: "@%x@%count[%x]);
		%newcount += %count[%x];
	}
	%ammo = (%newcount/%z) ;
	%newammo="";
	%newdmg="";
	for(%x = 0; %x < 4; %x++)
	{
		%newammo = %newammo@String::getSubStr(%ammo, %x, 1);
	}

	if(%dmg > 99.9)
		%lim=3;
	else
		%lim=5;


	for(%x = 0; %x < %lim; %x++)
	{
		%newdmg = %newdmg@String::getSubStr(%dmg, %x, 1);
	}

	%accuracy = MyRound(((%cl.ThisRoundTotalHitsDone/%cl.ThisRoundTotalShotsFired)*100),1);
	//both("shots H, S "@%cl.ThisRoundTotalHitsDone@", "@%cl.ThisRoundTotalShotsFired);

	if(%accuracy < 0)
		%accuracy = 0;

//	%total = floor(((%dmg+%ammo)/2)+0.5);
	if(%hadKit)
	{
		%message = "Health: "@MyRound(%dmg,3)@"% (+Kit) Accuracy: "@%accuracy@"%";
	}
	else
	{
		%message = "Health: "@MyRound(%dmg,3)@"% Accuracy: "@%accuracy@"%";
	}

	return %message;
	//return both((%dmg + floor((%newcount/(%z+1)+0.5)))/2) ;

}
function EndDuel(%clientId, %damageType) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(EndDuel);
	}
	%foeId = $Dueling[%clientId];

	Stop::TimeTracker(%clientId, "DuelTime");
	Stop::TimeTracker(%foeId, "DuelTime");

	if ($Dueling[%clientId] && $DuelCanHurt[%clientId]) {
		%t = getSimTime() - $DuelStartTime[$DuelSpotIndex[%clientId]];
		setT(%clientId, %foeId, %t);
		if(%t > 0 && %t < $DuelBest[%foeId]) {
			$DuelBest[%foeId] = %t;
			$DuelBestDisplay[%foeId] = formattedbest(%t);
		}
		%t = formattedbest(%t);

		$DuelCanHurt[%clientId] = false;
		$DuelCanHurt[%foeId] = false;

		//%foeId.score++;

		//%scoreKills = GetPlayType(%foeId)@"scoreKills";
		//%scoreDeaths = GetPlayType(%clientId)@"scoreDeaths";
		// eval( "%foeId." @ %scoreKills @ "++;");
		// eval( "%clientId." @ %scoreDeaths @ "++;");
		%PlayType = GetPlayType(%clientId);

		Score::IncreaseStat(%foeId, "scoreKills", 1, %PlayType, %damageType);
		Score::IncreaseStat(%clientId, "scoreDeaths", 1, %PlayType, %damageType);
		Score::IncreaseStat(%foeId, "scoreKillsTotal", 1, %PlayType);
		Score::IncreaseStat(%clientId, "scoreDeathsTotal", 1, %PlayType);
		Score::SetStat(%clientId, "KillStreak", 0, %playType);
		Score::IncreaseStat(%foeId, "KillStreak", 1, %PlayType);
		Score::CompareStat(%foeId, "BestKillStreak", Score::GetStat(%foeId, "KillStreak", %playType), %playType);


		//%clientId.scoreDeaths++;

		if(%damageType != -2) playASound(%clientId, %foeId);

		setHigh(%clientId);
		$DuelStreak[%clientId] = 0;

		//MessageAll(1,Client::GetName(%foeId) @ " has triumphed over " @ Client::GetName(%clientId) @ "! (" @ %t @ ")");
		%health = GetHealth(%foeId);
//		both("Health: "@%health);
		MessageAll(1,Client::GetName(%foeId) @ " has triumphed over " @ Client::GetName(%clientId) @ "! "@getHealth(%foeId)@" "@ %t);
		centerprint(%clientId,"<jc><f2>You lose!", 6);
		%msg = "<jc><f2>You win!";
		if(%foeId.score[%PlayType, "KillStreak"] > 1) {
			%msg = %msg @ "\n\n<f1>You have <f2>" @ %foeId.score[%PlayType, "KillStreak"] @ "<f1> wins in a row";
			if(%foeId.score[%PlayType, "KillStreak"] > 3) {
				%msg = %msg @ "!";
				if(%foeId.score[%PlayType, "KillStreak"] > 7)
					%msg = %msg @ "!!!";
				if(%foeId.score[%PlayType, "KillStreak"] > 12)
					%msg = %msg @ "!!!!";
			} else
				%msg = %msg @ ".";
		}
		centerprint(%foeId, %msg, 8);


		if($Winners::On[%clientId] && $Winners::On[%foeId])
		{
			for(%x = 0; %x < 3; %x++)
			{
				if(getword($Winners::List[%clientId], %x) != %foeId && getword($Winners::List[%clientId], %x) != %clientId)
				{
					%newfoe = getword($Winners::List[%clientId], %x);
					//both("Found it! "@client::getname(%newfoe));
					break;
				}
			}
			if(%newfoe == "" || $Dueling[%newfoe] || %newfoe.team != "")
			{
				FinalizeDuel(%clientId, %foeId);
				return;
			}
			%clientId.observerTarget = %foeId;
			%clientId.observerMode = "observerOrbit";
			//both("winners found! "@%x);
			 schedule("FinalizeDuel(" @ %foeId @ "," @ %clientId @ ");", $DuelDelayTime-1.5);
			 schedule("DuelInit(" @ %foeId @ "," @ %newfoe @ ");", $DuelDelayTime-0.5);
			 return;
		 }



		   if($SpeedDuel[%clientId] == "True" && $SpeedDuel[%foeId] == "True")
		   {
				   schedule("FinalizeDuel(" @ %clientId @ "," @ %foeId @ ");", 0.5);
				   schedule("DuelInit(" @ %clientId @ "," @ %foeId @ ");", 1);
		   }
		   if($SpeedDuel[%clientId] == "False" || $SpeedDuel[%foeId] == "False" || $SpeedDuel[%clientId] == "EndOfD" || $SpeedDuel[%foeId] == "EndOfD")
		   {
				   schedule("FinalizeDuel(" @ %clientId @ "," @ %foeId @ ");", $DuelDelayTime-1);
		   }

		//schedule("FinalizeDuel(" @ %clientId @ "," @ %foeId @ ");", $DuelDelayTime);

	} else if ($Dueling[%clientId] && !$DuelCanHurt[%clientId]) {
		Client::sendMessage(%clientId, 1, Client::GetName(%clientId) @ " has ended the duel prior to start.~werror_message.wav");
		Client::sendMessage(%foeId, 1, Client::GetName(%clientId) @ " has ended the duel prior to start.~werror_message.wav");
		FinalizeDuel(%clientId, %foeId);
	}

}

function Vote::changeMission() {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Vote::changeMission);
	}
   $timeLimitReached = true;
   $timeReached = true;
   DuelMOD::missionObjectives();
}

function CheckDuelTime(%clientId,%foeId, %timeLeft) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(CheckDuelTime);
	}
	if ($DuelLineup[%clientId] != %foeId) return;
	if (%timeLeft == 0) {
		$DuelLineup[%clientId] = "";
		Client::SendMessage(%clientId,0,Client::GetName(%foeId) @ " did not accept the duel in time.~waccess_denied.wav");
		return;
	}
	if ($Dueling[%foeId] && $Dueling[%foeId] != %clientId) {
		$DuelLineup[%clientId] = "";
		Client::SendMessage(%clientId,0,Client::GetName(%foeId) @ " has accepted a duel with somebody else.~waccess_denied.wav");
		return;
	}
	if (Client::GetName(%foeId) == "") {
		$DuelLineup[%clientId] = "";
		return;
	}
	if (Client::GetName(%clientId) == "") {
		$DuelLineup[%clientId] = "";
		return;
	}
	schedule("CheckDuelTime(" @ %clientId @ ", " @ %foeId @ ", " @ (%timeLeft - 3) @ ");",3);
}

function DuelPropose(%clientId,%foeId,%again) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(DuelPropose);
	}
	//TD
	if(%clientId.Team != "")
	{
		client::sendmessage(%clientId,0,"Get off your team asshole!~werror_message.wav");
		return;
	}
	if(%foeId.Team != "" && %foeId)
	{
		client::sendmessage(%clientId,0, Client::GetName(%foeId)@" is currently on a TeamDuel team.~werror_message.wav");
		return;
	}
	if(%clientId.Team == "" && %foeId.Team == "")
	{
	//TD
		if (%foeId == %clientId) {
			client::sendmessage(%clientId,0,"You can't duel yourself!~werror_message.wav");
			return;
		}
		if ($Dueling[%clientId]) {
			client::sendmessage(%clientId,0,"Hello!? You're already in a duel!~werror_message.wav");
			return;
		}
		if (!%foeId || %foeId == 0 || Client::GetName(%foeId) == "") {
			Client::SendMessage(%clientId,0,"That person is not in the game.~waccess_denied.wav");
			return;
		}
		if ($Dueling[%foeId]) {
			client::sendmessage(%clientId,0, Client::GetName(%foeId) @ " is currently in a duel. Try again later.~waccess_denied.wav");
			return;
		}
		if($DuelModeOff[%foeId]) {
			Client::SendMessage(%clientId,0,Client::GetName(%foeId) @ " currently has duels disabled.~waccess_denied.wav");
			return;
		}
		if ($DuelLineup[%foeId] == %clientId) {
			DuelInit(%clientId, %foeId);
			return;
		}
		$DuelLineup[%clientId] = %foeId;
		Client::sendMessage(%clientId,0,Client::GetName(%foeId) @ " has 30 seconds to accept the duel.");
		if(%foeId.dm)
		{
			BottomPrint(%foeId,"<jc>" @ Client::GetName(%clientId) @ " has requested a duel.", 8);
		}
		else {
			CenterPrint(%foeId,"<jc>" @ Client::GetName(%clientId) @ " has requested a duel.", 8);
		}
		Client::sendMessage(%foeId,0,"You have 30 seconds to accept a duel from " @ Client::GetName(%clientId) @ ".");
		CheckDuelTime(%clientId, %foeId, 30);
		if(%again && %foeId.score["DL", "KillStreak"] > 5) {
			client::sendMessage(%clientId, 0, "~wduelagain.wav");
			client::sendMessage(%foeId, 0, "~wduelagain.wav");
		}
		return;
	}
}


function DuelInit(%clientId, %foeId) {
	if($Duel::Master)
	{
		if($Winners::On[%clientId] == "" && $Winners::On[%foeId])
		{
			processMenuOptions(%foeId, "disablewinners");
		}
		if($Winners::On[%foeId] == "" && $Winners::On[%clientId])
		{
			processMenuOptions(%clientId, "disablewinners");
		}
		if(%clientId.dm)	{	DM::LeaveDM(%clientId);	}
		if(%foeId.dm) 		{	DM::LeaveDM(%foeId);	}


		%clientId.TeamJoining = "";
		%foeId.TeamJoining = "";
		if($TDebug && $TeamDuel::Master)
		{
			LogFunction(DuelInit);
		}
		MessageAll(0, Client::GetName(%clientId) @ " and " @ Client::GetName(%foeId) @ " are about to duel!");
		%spotTaken = true;
		%ii = 0;
		while (%spotTaken) {
			%ii++;
			if (%ii > 60) {
				Client::SendMessage(%clientId,0,"No duel spawn spots are vacant. Try again when a duel finishes.~waccess_denied.wav");
				Client::SendMessage(%foeId,0,"No duel spawn spots are vacant. Try again when a duel finishes.~waccess_denied.wav");
				$DuelLineup[%clientId] = "";
				$DuelLineup[%foeId] = "";
				$Dueling[%clientId] = "";
				$Dueling[%foeId] = "";
				return;
			}
			%i = floor(getRandom() * 12) + 1;
			if (!$DuelSpotTaken[%i]) {
				$DuelSpotIndex[%clientId] = %i;
				$DuelSpotIndex[%foeId] = %i;
				%group = nameToID("MissionGroup/Duel" @ %i);
				%count = Group::objectCount(%group);
				//$DuelSpawnMarker[%clientId] = Group::getObject(%group, 0);
				//$DuelSpawnMarker[%foeId] = Group::getObject(%group, 1);
				$DuelSpawnMarker[%clientId] = %i;
				$DuelSpawnMarker[%foeId] = %i;
				$DuelSpotTaken[%i] = true;
				%spotTaken = false;
			}
		}
		%clientId.observerMode = "";
		%foeId.observerMode = "";
		%foeId.observerTarget = "";
		%clientId.observerTarget = "";
		%clientId.guiLock = true;
		%foeId.guiLock = true;
		Client::setGuiMode(%clientId, $GuiModePlay);
		Client::setGuiMode(%foeId, $GuiModePlay);

		$DuelLineup[%clientId] = "";
		$DuelLineup[%foeId] = "";
		$Dueling[%clientId] = %foeId;
		$Dueling[%foeId] = %clientId;
		$DuelLastEnemy[%clientId] = %foeId;
		$DuelLastEnemy[%foeId] = %clientId;

		Game::refreshClientScore(%clientId);
		Game::refreshClientScore(%foeId);

		$numz++;
		if($numz < 2 || $numz > 6)
		{
			$numz = 2;
		}

		%ClientId.Dex=1;
		%foeId.Dex=2;
		%clientPl = DuelSpawn(%clientId);
		%foePl = DuelSpawn(%foeId);
		LockPlayers(%clientId, %foeId, %clientPl, %foePl);

		//TD


		//if($DuelSpotIndex[%clientId] <= 8) {
		//	GameBase::SetTeam(%clientId, $DuelSpotIndex[%clientId] - 1);
		//	GameBase::SetTeam(%clientPl, $DuelSpotIndex[%clientId] - 1);
		//	GameBase::SetTeam(%foeId, $DuelSpotIndex[%foeId] - 1);
		//	GameBase::SetTeam(%foePl, $DuelSpotIndex[%foeId] - 1);
		//} else {
		//	GameBase::SetTeam(%clientId, $DuelSpotIndex[%clientId] - 9);
		//	GameBase::SetTeam(%clientPl, $DuelSpotIndex[%clientId] - 9);
		//	GameBase::SetTeam(%foeId, $DuelSpotIndex[%foeId] - 9);
		//	GameBase::SetTeam(%foePl, $DuelSpotIndex[%foeId] - 9);
		//}
		//TD
		Player::setDetectParameters(%clientPl, 0, 300);
		Player::setDetectParameters(%foePl, 0, 300);

		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			if (Client::GetTeam(%cl) == -1) {
				if (%cl.observerTarget == %clientId)
					Observer::setTargetClient(%cl, %clientId);
				else if (%cl.observerTarget == %foeId)
					Observer::setTargetClient(%cl, %foeId);
			}
		}

		if($Winners::On[%clientId] && $Winners::On[%foeId])
		{
			for(%x = 0; %x < 3; %x++)
			{
				if(getword($Winners::List[%clientId], %x) != %foeId && getword($Winners::List[%clientId], %x) != %clientId)
				{
					%newfoe = getword($Winners::List[%clientId], %x);
					//both("Found it! "@client::getname(%newfoe));
					setObsOrbit(%newfoe, %clientId);
					break;
				}
			}
		}

		$DuelCanHurt[%clientId] = false;
		$DuelCanHurt[%foeId] = false;

		if($Winners::On[%clientId] && $Winners::On[%foeId])
		{
		   DuelCountdown(%clientId, %foeId, 4, %clientPl, %foePl);
		   return;
		}

		if($SpeedDuel[%foeId] == "True" && $SpeedDuel[%clientId] == "True")
		{
			DuelCountdown(%clientId, %foeId, 2, %clientPl, %foePl);
		}
		else {
			DuelCountdown(%clientId, %foeId, 7, %clientPl, %foePl);
		}
	}


}

function DuelSpawn(%clientId)
{
	ECHO("FUCK"@$DuelSpawnMarker[%clientId]);
	if($DuelSpawnMarker[%clientId] == -1) {
		%spawnPos = "0 0 600";
	    %spawnRot = "0 0 0";
	} else {
		//%spawnPos = gamebase::getposition($DuelSpawnMarker[%clientId]);
		%spawnPos = $Duel::SpawnMarkerPos[$DuelSpawnMarker[%clientId], %clientId.Dex];
		ECHO("spawn stuff: "@$Duel::SpawnMarkerPos[$DuelSpawnMarker[%clientId], %clientId.Dex]@" "@$Duel::SpawnMarkerPos[$DuelSpawnMarker[%clientId], %clientId.Dex]);
	   // %spawnRot = GameBase::getRotation($DuelSpawnMarker[%clientId]);
		%spawnRot =  $Duel::SpawnMarkerPos[$DuelSpawnMarker[%clientId], %clientId.Dex];
	}
	%armor = "larmor";
	%pl = spawnPlayer(%armor, %spawnPos, %spawnRot);
	%pl.owner = %clientId;

	if(%pl != -1)
		Client::setOwnedObject(%clientId, %pl);
	Client::setSkin(%clientId, $Client::info[%clientId, 0]);

	Player::AssignLoadout(%clientId, true);


   resetlos();
   	GameBase::getLOSInfo(%pl, 30, "-1.57 0 0");
  // 	both($los::position@" "@$los::object);
   	if($los::position != "")
   	{
		//both("worked");
   		gamebase::setposition(%clientId, $los::position);
	}
	//resetlos();
	%clientId.owns = %pl;
	return %pl;
}
function RequestWinners(%client, %dueler1, %dueler2)
{
	client::sendmessage(%dueler1, $white, client::getname(%client)@" is requesting winnners mode. Vote yes(Ctrl+Y) or open the tab menu to enable or deny his request.");
	client::sendmessage(%dueler2, $white, client::getname(%client)@" is requesting winnners mode. Vote yes(Ctrl+Y) or open the tab menu to enable or deny his request.");
	$Winners::Wants[%dueler1] = true;
	$Winners::Wants[%dueler2] = true;
	$Winners::Requesting[%client] = true;
	$Winners::RequestingID[%client] = %dueler1@" "@%dueler2;
}
function Game::menuRequest(%clientId, %skip)
{
	%time = Time::getMinutes((floor(getSimTime()) - %clientId.LastAction));
	if(%time > 0.9)
	{
		%clientId.LastAction = floor(getSimTime());
		Game::refreshClientScore(%clientId);
	}
	else
	{
		%clientId.LastAction = floor(getSimTime());
	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Game::menuRequest);
	}
	//TD
 	if(%clientId.Team != "" && %skip == "" && $TeamDuel::Master && %clientId.selClient == "")
 	{
		%option = "teamduelsetup";
		processMenummisc(%clientId, %option);
		return;
	}
	//TD
   %curItem = 0;
	// 1.50 PORT: was the literal "=Argh!='s Duel" -- the one server this build was
	// taken from. A published pack must not put that server's name on every host's
	// menu, so the menu header now follows $Server::HostName (set in serverConfig.cs).
	%menuTitle = $Server::HostName;
	if(%menuTitle == "")
		%menuTitle = "Duel Tournament";
	if(!%clientId.selClient)
		Client::buildMenu(%clientId, %menuTitle, "options", true);
	else
		Client::buildMenu(%clientId, Client::getName(%clientId.selClient) @ ":", "options", true);



   if(%clientId.selClient) {
	   if(%clientId.selClient.private)
	   {
		   %clientId.selClient = "";
		   Client::cancelMenu(%clientId);
		   Game::menuRequest(%clientId);
		   return;
	   }
      %sel = %clientId.selClient;
      %name = Client::getName(%sel);

		if(%sel != %clientId && $DuelLineup[%clientId] != %sel && %clientId.Team == "" && %sel.Team == "" && $Duel::Master)//TD
			Client::addMenuItem(%clientId, %curItem++ @ "Request Duel", "duel " @ %sel);

		//TD

		if($Dueling[%clientId.selClient] && %clientId.Team == "" && $Winners::On[%clientId] == "" && !$Dueling[%clientId] && %clientId.selClient != %clientId && $Duel::Master|| !$Dueling[%clientId] && $DuelLastEnemy[%clientId] != "" && $DuelLineup[%clientId] != $DuelLastEnemy[%clientId] && %clientId.Team == "" && $Winners::On[%clientId] == "" && %clientId.selClient != %clientId && $Duel::Master)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "Request Winners", "winners " @ %sel);
		}


		if(%clientId.isSuperAdmin)
		{

			if(%sel.Team != "")
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Change "@%name@"'s team", "changehisteam " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Remove "@%name@" from team", "removehimfromteam " @ %sel);
				Client::addMenuItem(%clientId, %curItem++ @ "Make "@%name@" leader of team", "makethisdudeleader " @ %sel);
			}
			else
			{
				if($TeamDuel::TotalTeams > 0)
				{
					Client::addMenuItem(%clientId, %curItem++ @ "Add "@%name@" to a team", "changehisteam " @ %sel);
				}
			}
		}

		Client::addMenuItem(%clientId, %curItem++ @ "View "@%name@"'s Stats", "viewadvscore "@%sel);
		if(%sel.Team != "" && %clientId.Team == "")
		{
			if($TeamDuel::Locked[%sel.Team])
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Request to join "@$TeamDuel::Name[%sel.Team]@"", "joinrequest "@%sel.Team);
			}
			else
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Join the "@$TeamDuel::Name[%sel.Team]@" team.", "joinrequest "@%sel.Team);
			}
		}
		Client::addMenuItem(%clientId, %curItem++ @ "Talk privately with " @ %name, "whisper " @ %sel);

		if(Observer::isObserver(%clientId) && %clientId != %sel && !Observer::isObserver(%sel))
			Client::addMenuItem(%clientId, %curItem++ @ "Observe", "observe " @ %sel);
      if($curVoteTopic == "" && !%clientId.isAdmin) {
         //Client::addMenuItem(%clientId, %curItem++ @ "Vote to admin " @ %name, "vadmin " @ %sel);
         Client::addMenuItem(%clientId, %curItem++ @ "Vote to kick " @ %name, "vkick " @ %sel);
      }
      if(%clientId.isSuperAdmin)
      {
		  Client::addMenuItem(%clientId, %curItem++ @ "Admin Stuff", "AdminStuff");
	  }
      //if(%clientId.isAdmin) {
	        // Client::addMenuItem(%clientId, %curItem++ @ "Kick " @ %name, "kick " @ %sel);
	       // if(%clientId.isSuperAdmin) {
    	       // Client::addMenuItem(%clientId, %curItem++ @ "Ban " @ %name, "ban " @ %sel);
        		//if(!%sel.isAdmin)
					//Client::addMenuItem(%clientId, %curItem++ @ "Admin", "admin " @ %sel);
				//else if(%clientId == %sel || !%sel.isSuperAdmin)
					//Client::addMenuItem(%clientId, %curItem++ @ "Remove Admin Status", "removeadmin " @ %sel);
			//}
     // }
		if(%clientId.isSuperAdmin)// || %clientId.CanLoad)
		{
			if($GlobalMute[%sel])
			{
				Client::addMenuItem(%clientId, %curItem++ @ "Remove Global Mute", "gmutetoggle "@%sel);
			}
			else {
				Client::addMenuItem(%clientId, %curItem++ @ "Globally Mute", "gmutetoggle "@%sel);
			}
			//echo($GlobalMute[%sel]);
		}
      if(%clientId.muted[%sel])
         Client::addMenuItem(%clientId, %curItem++ @ "Unmute " @ %name, "unmute " @ %sel);
      else
         Client::addMenuItem(%clientId, %curItem++ @ "Mute " @ %name, "mute " @ %sel);
   } else
	   Client::addMenuItem(%clientId, %curItem++ @ "Miscellany", "misc");


   	if($curVoteTopic != "" && %clientId.vote == "") {
      Client::addMenuItem(%clientId, %curItem++ @ "Vote YES to " @ $curVoteTopic, "voteYes " @ $curVoteCount);
      Client::addMenuItem(%clientId, %curItem++ @ "Vote NO to " @ $curVoteTopic, "voteNo " @ $curVoteCount);
   	  return;
	}

	if (!$Dueling[%clientId] && $DuelLastEnemy[%clientId] != "" && $DuelLineup[%clientId] != $DuelLastEnemy[%clientId] && %clientId.Team == "" && $Duel::Master)
		Client::addMenuItem(%clientId, %curItem++ @ "Request Last Duel", "rerequest " @ $DuelLastEnemy[%clientId]);


		if(%clientId.team == "" && $Duel::Master)
		{
		 Client::addMenuItem(%clientId, %p++ @ "Auto Request Last Duel", toggleSpeed);
		 }
	if($Winners::On[%clientId])
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Disable Winners", "disablewinners");
	}
	if($Winners::Wants[%clientId] && %clientId.Team == "" && $Winners::On[%clientId] == "")
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Winners Mode", "winnersmode");
	}
if(%clientId.selClient == "")
{
	Client::addMenuItem(%clientId, %curItem++ @ "Loadout Setup", "loadoutsetup");
	//Client::addMenuItem(%clientId, %curItem++ @ "Weapons Setup", "weaponsetup");
	//Client::addMenuItem(%clientId, %curItem++ @ "Pack Setup", "packsetup");
	//TD
  // if($ArmorToggle) oldd
  // {
		   //Client::addMenuItem(%clientId, %curItem++ @ "Armor Setup", "armorsetup");
  // }
	if (!$Dueling[%clientId] && %clientId.Team == "") {
		if(%clientId.hasInvite)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "**Accept Invite Into TeamDuel**", "checkinvites");
		}
		//TD
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
			//TD
			if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId && %cl.Team == "")//TD
				%num++;
		}
		if(%num == 1) {
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
				if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId)
					Client::addMenuItem(%clientId, %curItem++ @ "Accept duel: " @ Client::GetName(%cl), "acceptduel " @ %cl);
			}
		} else if(%num > 1)
			Client::addMenuItem(%clientId, %curItem++ @ "Accept a duel...", "viewduels");
	}


	if(%clientId.scorecheck)
	{
		Client::addMenuItem(%clientId, %curItem++ @ "Restore Score? ("@%clientId.tick@")", "scorerestore");
	}
  if($TeamDuel::TotalTeams > 0 && %clientId.selClient == "" && !$Dueling[%clientId] && %clientId.Team == "")
  {
	  Client::addMenuItem(%clientId, %curItem++ @ "Join a team", "NEWjointeam");
  }
  if(%clientId.dm != "true" && !$Dueling[%clientId] && %clientId.IsAlive == "" && $DeathMatch::Master)
  {
	  Client::addMenuItem(%clientId, %curItem++ @ "Join Death Match", "JoinDM");
  }
  if(%clientId.dm && $DeathMatch::Master)
  {
	  if(!%clientId.GoToSpecialMap)
	  {
		  if($Game::missionType == "BooT CamP" || $Game::missionType == "Uber" || $Game::missionType == "XtremeSki")
		  {
			  Client::addMenuItem(%clientId, %curItem++ @ "Go "@$Game::MissionType, "GoSpecial");
		  }
	  }
	  Client::addMenuItem(%clientId, %curItem++ @ "Leave Death Match", "LeaveDM");
  }
  Client::addMenuItem(%clientId, %curItem++ @ "Team Duel Setup", "teamduelsetup");


	if($curVoteTopic == "") {
		if(%clientId.DM)
		{
			Client::addMenuItem(%clientId, %curItem++ @ "DM Voting", "vcarena");
		}
		else {
			if(!%clientId.isAdmin)
			{
      			Client::addMenuItem(%clientId, %curItem++ @ "Vote to change mission", "vcmission");
			}
		}
//      if($Server::TeamDamageScale == 1.0)
//         Client::addMenuItem(%clientId, %curItem++ @ "Vote to disable team damage", "vdtd");
//      else
//         Client::addMenuItem(%clientId, %curItem++ @ "Vote to enable team damage", "vetd");
   }
   if(%clientId.isAdmin) {
      Client::addMenuItem(%clientId, %curItem++ @ "Change mission", "cmission");
      Client::addMenuItem(%clientId, %curItem++ @ "Set Time Limit", "ctimelimit");
      //Client::addMenuItem(%clientId, %curItem++ @ "Reset Server Defaults", "reset");
   }
   //TD
}

  //TD
}


function hvcAdminMsg(%msg) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(hvcAdminMsg);
	}
	echo("SERVER: " @ %msg);
	%numPlayers = getNumClients();
	for(%i = 0; %i < %numPlayers; %i++) {
		%pl = getClientByIndex(%i);
		if(%pl.isSuperAdmin) {
			Client::sendMessage(%pl, 0, %msg);
		}
	}
}

function processMenuOptions(%clientId, %option) {
	%time = Time::getMinutes((floor(getSimTime()) - %clientId.LastAction));
	if(%time > 0.9)
	{
		%clientId.LastAction = floor(getSimTime());
		Game::refreshClientScore(%clientId);
	}
	else
	{
		%clientId.LastAction = floor(getSimTime());
	}
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction("processMenuOptions "@%option);
	}
	if(!$timeReached)
	{
   %opt = getWord(%option, 0);
   %cl = getWord(%option, 1);
   //TD
   %target = getWord(%option, 1);

	if(%opt == "viewsmurfs" && %target.AboveAdmin || %opt == "gmutetoggle" && %target.AboveAdmin || %opt == "removeadmin" && %target.AboveAdmin || %opt == "removehimfromteam" && %target.AboveAdmin || %opt == "mute" && %target.AboveAdmin || %opt == "vkick" && %target.AboveAdmin || %opt == "kickplayerteamaffirm" && %target.AboveAdmin || %opt == "ban" && %target.AboveAdmin)
	{
		//echo("hmm");
		return;
	}

   if(%opt == "disablewinners")
   {
	   $Winners::On[%clientId] = "";
		for(%x = 0; %x < 3; %x++)
		{
			%a[%x] = getword($Winners::List[%clientId], %x);
			$Winners::On[getword($Winners::List[%clientId], %x)] = "";
		}
		for(%x = 0; %x < 3; %x++)
		{
			$Winners::On[%a[%x]] = "";
			$Winners::List[%a[%x]] = "";
			$Winners::Wants[%a[%x]] = "";
			$Winners::Requesting[%a[%x]] = "";
			$SpeedDuel[%a[%x]] = "False";
			if(%a[%x] != %clientId)
			{
				client::sendmessage(%a[%x], $Red, client::getname(%clientId)@" has turned off winners mode.");
			}
			else {
				client::sendmessage(%a[%x], $Red, "You have turned off winners mode.");
			}
		}
   }
   if(%opt == "alowinners")
   {
	   if(%clientId.Team != "")
	   {
		   return;
	   }


	   if($Dueling[%clientId])
	   {
		   %other = $Dueling[%clientId];
	   }
	   else if(!$Dueling[%clientId] && $DuelLastEnemy[%clientId] != "" && $DuelLineup[%clientId] != $DuelLastEnemy[%clientId] && %clientId.Team == "")
	   {
		   %other = $DuelLastEnemy[%clientId] ;
	   }
	   else {
		   return;
		   //echo("failed");
	   }
	   $Winners::On[%clientId] = true;
	   client::sendmessage(%other, $Green, client::getname(%clientId)@" has enabled winners with you."@$beep);

		//if($Winners::On[%other])
		//{
			$Winners::On[%other] = true;
			$SpeedDuel[%other] = "False";
			$SpeedDuel[%target] = "False";
			$SpeedDuel[%clientId] = "False";
			$Winners::On[%target] = true;
			$Winners::List[%clientId] = %clientId@" "@%target@" "@%other;
			$Winners::List[%target] = %clientId@" "@%target@" "@%other;
			$Winners::List[%other] = %clientId@" "@%target@" "@%other;
			$Winners::Wants[%clientId] = "";
			$Winners::Wants[%other] = "";
			$Winners::Requesting[%target] = "";
			client::sendmessage(%target, $white, "You are now playing winners mode with "@client::getname(%clientId)@" and "@client::getname(%other));
			client::sendmessage(%clientId, $white, "You are now playing winners mode with "@client::getname(%target)@" and "@client::getname(%other));
			client::sendmessage(%other, $white, "You are now playing winners mode with "@client::getname(%clientId)@" and "@client::getname(%target));
			//both("Winners list : "@$Winners::List[%clientId]);
		//}

		//both("Winners list : "@$Winners::List[%clientId]@" -- other"@$Winners::On[%other]@" target"@$Winners::On[%target]@" client"@$Winners::On[%clientId]);


	   return;
   }
   if(%opt == "denywinners")
   {
	   if(%clientId.Team != "")
	   {
		   return;
	   }
   }
   if(%opt == "winnersmode")
   {
	   if(%clientId.Team != "")
	   {
		   return;
	   }
	   if($Winners::Wants[%clientId])
	   {
		   %i = 0;
		   	Client::buildMenu(%clientId, "Requesting Winners", "options", true);
			for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			{
				if($Winners::Requesting[%cl] && GetWord($Winners::RequestingID[%cl], 0) == %clientId || $Winners::Requesting[%cl] && GetWord($Winners::RequestingID[%cl], 1) == %clientId)
				{
					Client::addMenuItem(%clientId, %i++ @ client::getname(%cl)@": Allow", "alowinners "@%cl);
					//Client::addMenuItem(%clientId, %i++ @ client::getname(%cl)@": Deny", "denywinners "@%cl);
				}
			}
		}
		return;
	}
   if(%opt == "winners")
   {
	   if(%clientId.Team != "")
	   {
		   return;
	   }
	   %dueler1 = %target;
	   %dueler2 = $Dueling[%dueler1];
	   if($Dueling[%dueler1] == %dueler2 && $Dueling[%dueler2] == %dueler1)
   		{
			client::sendmessage(%dueler1, $white, client::getname(%clientID)@" is requesting winnners mode. Vote yes(Ctrl+Y) or open the tab menu to enable or deny his request.");
			client::sendmessage(%dueler2, $white, client::getname(%clientID)@" is requesting winnners mode. Vote yes(Ctrl+Y) or open the tab menu to enable or deny his request.");
			$Winners::Wants[%dueler1] = true;
			$Winners::Wants[%dueler2] = true;
			$Winners::Requesting[%clientID] = true;
			$Winners::RequestingID[%clientID] = %dueler1@" "@%dueler2;
		}
		return;
   }
   if(%opt == "scorerestore")
   {
	   %i = 0;
		Client::buildMenu(%clientId, "Restore Score? ("@%clientId.tick@")", "mmisc", true);
		Client::addMenuItem(%clientId, %i++ @ "Yes", "scorerestore yes");
		Client::addMenuItem(%clientId, %i++ @ "No", "scorerestore no");
		return;
   }
	if(%opt == "joinrequest")
	{
		if(%clientId.Team == "")
		{
			JoinRequest(%clientId, %cl);
		}
		return;
	}
	if(%opt == "checkinvites" || %opt == "loadoutsetup")
	{
		processMenummisc(%clientId, %opt);
		return;
	}
	if(%opt == "NEWjointeam")
	{
		processMenummisc(%clientId, %opt);
		return;
	}
	if(%opt == "JoinDM" || %opt == "LeaveDM")
	{
		processMenuDMenu(%clientId, %opt);
		return;
	}
	if(%opt == "teamduelsetup")
	{
		processMenummisc(%clientId, %opt);
		return;
	}
	if(%opt == "GoUber!")
	{
		UberSpawn(%clientId);
		return;
	}
	if(%opt == "GoSpecial")
	{
		%clientId.GoToSpecialMap = true;
		GoToSpecialMap(%clientId);
		return;
	}
	if(%opt == "changehisteam")
	{
		processMenummisc(%clientId, %opt@" "@%cl);
		return;
	}
	if(%opt == "makethisdudeleader")
	{
		processMenummisc(%clientId, %opt@" "@%cl);
		return;
	}
	if(%opt == "removehimfromteam")
	{
		processMenummisc(%clientId, %opt@" "@%cl);
		return;
	}
	//TD
	if(%opt == "removeadmin") {
		%cl.isAdmin = "";
		%cl.isSuperAdmin = "";
		if(%cl == %clientId)
			Client::sendMessage(%cl,1,"You have revoked your Admin Status.");
		else {
			Client::sendMessage(%cl,1,"Your Admin Status has been revoked.");
			hvcAdminMsg("Admin Status stripped from: " @ Client::getName(%cl) @ ".");
		}
	}
	if(%opt == "gmutetoggle")
	{
		if(CheckFriend(Client::getname(%cl)))
		{
			return;
		}
		if($GlobalMute[%cl])
		{
			$GlobalMute[%cl] = false;
		}
		else {
			$GlobalMute[%cl] = true;
		}
		game::menurequest(%clientId);

		return;
	}
	if(%opt == "viewadvscore2")
	{
		echo("MENU "@%option);
		Score::Display(%clientId.selClient, %clientId, getWord(%option, 1));
		return;
	}
	if(%opt == "viewadvscore")
	{
		Client::buildMenu(%clientId, "Score Options", "options", true);
		Client::addMenuItem(%clientId, %i++ @ "Duel Stats", "viewadvscore2 DL");
		Client::addMenuItem(%clientId, %i++ @ "TeamDuel Stats", "viewadvscore2 TD");

		Client::addMenuItem(%clientId, %i++ @ "DeathMatch Stats", "viewadvscore2 DM");
		//Score::Display(%target, %clientId);
		//ShowThisScore(%clientId, %target);
		//processMenuAdvScore(%clientId, %opt@" "@%target);
		return;
	}
	if(%opt == "misc") {
		processMenummisc(%clientId, "prefs");
		return;
		%i = 0;
		Client::buildMenu(%clientId, "Miscellany:", "mmisc", true);

		Client::addMenuItem(%clientId, %i++ @ "Observer Mode", "obsm");
		if (%clientId.prefs["DuelModeOff"])
			Client::addMenuItem(%clientId, %i++ @ "Enable Duels", "toggled");
		else
			Client::addMenuItem(%clientId, %i++ @ "Disable Duels", "toggled");

		//TD
		Client::addMenuItem(%clientId, %i++ @ "Auto Request Last Duel", toggleSpeed);
		//Client::addMenuItem(%clientId, %i++ @ "MidAir Debug", toggleMADEBUG);
		if(%clientId.prefs["VoteGraphic"])
		{
			Client::addMenuItem(%clientId, %i++ @ "Disable Vote Meter", togglevgraph);
		}
		else {
			Client::addMenuItem(%clientId, %i++ @ "Enable Vote Meter", togglevgraph);
		}
		if(%clientId.isSuperAdmin)
		{
			Client::addMenuItem(%clientId, %i++ @ "Admin Stuff", AdminStuff);
		}
		Client::addMenuItem(%clientId, %i++ @ "Amin Intervention: "@%clientId.prefs["allowabuse"], "toggledbuse");
		if(%clientId.isSuperAdmin || %clientId.CanLoad)
		{
			Client::addMenuItem(%clientId, %i++ @ "Saved Stats Setup", "SSS");
		}
		if (!$Dueling[%clientId] && $TeamDuel::Master|| Authorization(%clientId))
		{
			Client::addMenuItem(%clientId, %i++ @ "Team Duel Setup", teamduelsetup);
		}
		//TD

		return;
	}
	if(%opt == "observe") {
		%clientId.observerMode = "observerOrbit";
		Observer::setTargetClient(%clientId, %cl);
  		return;
	}
	if (%opt == "viewduels") {
		Client::buildMenu(%clientId, "Select a player to duel:", "Options", true);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
			if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId)
				Client::addMenuItem(%clientId, %curItem++ @ Client::GetName(%cl), "acceptduel " @ %cl);
		return;
	}
	if (%opt == "rerequest") {
		DuelPropose(%clientId, %cl, true);
		return;
	}
	if (%opt == "acceptduel") {
		if (!$Dueling[%cl] && $DuelLineup[%cl] == %clientId) {
			DuelPropose(%clientId, %cl, false);
			return;
		} else {
			Client::SendMessage(%clientId, 0, Client::GetName(%cl) @ " is no longer requesting a duel.~waccess_denied.wav");
			return;
		}
	}
	if (%opt == "weaponsetup") {
		$DuelWeaponSetup[%clientId, 0] = 0;
		$DuelWeaponSetup[%clientId, 1] = 0;
		$DuelWeaponSetup[%clientId, 2] = 0;
		WeaponSetup(%clientId, 0, 0);
        return;
	}
    if (%opt == "packsetup") {
		PackSetup(%clientId);
        return;
	}
	//TD
   if(%opt == "whisper")
   {
	   processMenuWhisper(%clientId);
	   return;
   }
   if(%opt == "armorsetup")
   {
		ArmorSetup(%clientId);
		return;
   }
   //TD
	if(%opt == "duel") {
		DuelPropose(%clientId, %cl, false);
		return;
	}

   if(%opt == "fteamchange")
   {
      %clientId.ptc = %cl;
      Client::buildMenu(%clientId, "Pick a team:", "FPickTeam", true);
      Client::addMenuItem(%clientId, "0Observer", -2);
      Client::addMenuItem(%clientId, "1Automatic", -1);
      for(%i = 0; %i < getNumTeams(); %i = %i + 1)
         Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
      return;
   }
   else if(%opt == "changeteams")
   {
      if(!$matchStarted || !$Server::TourneyMode)
      {
         Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
         Client::addMenuItem(%clientId, "0Observer", -2);
         Client::addMenuItem(%clientId, "1Automatic", -1);
         for(%i = 0; %i < getNumTeams(); %i = %i + 1)
            Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
         return;
      }
   }
   else if(%opt == "mute")
      %clientId.muted[%cl] = true;
   else if(%opt == "unmute")
      %clientId.muted[%cl] = "";
   else if(%opt == "vkick")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "kick " @ Client::getName(%cl), "kick", %cl);
   }
   else if(%opt == "vadmin")
   {
      %cl.voteTarget = true;
      Admin::startVote(%clientId, "admin " @ Client::getName(%cl), "admin", %cl);
   }
   else if(%opt == "vsmatch")
      Admin::startVote(%clientId, "start the match", "smatch", 0);
   else if(%opt == "vetd")
      Admin::startVote(%clientId, "enable team damage", "etd", 0);
   else if(%opt == "vdtd")
      Admin::startVote(%clientId, "disable team damage", "dtd", 0);
   else if(%opt == "etd")
      Admin::setTeamDamageEnable(%clientId, true);
   else if(%opt == "dtd")
      Admin::setTeamDamageEnable(%clientId, false);
   else if(%opt == "vcffa")
      Admin::startVote(%clientId, "change to Free For All mode", "ffa", 0);
   else if(%opt == "vctourney")
      Admin::startVote(%clientId, "change to Tournament mode", "tourney", 0);
   else if(%opt == "cffa")
      Admin::setModeFFA(%clientId);
   else if(%opt == "ctourney")
      Admin::setModeTourney(%clientId);
   else if(%opt == "voteYes" && %cl == $curVoteCount)
   {
      %clientId.vote = "yes";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "voteNo" && %cl == $curVoteCount)
   {
      %clientId.vote = "no";
      centerprint(%clientId, "", 0);
   }
   else if(%opt == "kick")
   {
      Client::buildMenu(%clientId, "Confirm kick:", "kaffirm", true);
      Client::addMenuItem(%clientId, "1Kick " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't kick " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "admin")
   {
      Client::buildMenu(%clientId, "Confirm admim:", "aaffirm", true);
      Client::addMenuItem(%clientId, "1Admin " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't admin " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "ban")
   {
      Client::buildMenu(%clientId, "Confirm Ban:", "baffirm", true);
      //Client::addMenuItem(%clientId, "1Ban " @ Client::getName(%cl), "yes " @ %cl);
      Client::addMenuItem(%clientId, "2Don't ban " @ Client::getName(%cl), "no " @ %cl);
      return;
   }
   else if(%opt == "smatch")
      Admin::startMatch(%clientId);
   else if(%opt == "vcmission" || %opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId, %opt == "cmission");
      return;
   }
   else if(%opt == "vcarena")
   {
	   if(%clientId.DM)
	   {
      		//DeathMatch::changeMissionMenu(%clientId);
      		processMenuDMMenu(%clientId, "base");
		}
      return;
   }
   else if(%opt == "ctimelimit")
   {
      Client::buildMenu(%clientId, "Change Time Limit:", "ctlimit", true);
      Client::addMenuItem(%clientId, "110 Minutes", 10);
      Client::addMenuItem(%clientId, "215 Minutes", 15);
      Client::addMenuItem(%clientId, "320 Minutes", 20);
      Client::addMenuItem(%clientId, "425 Minutes", 25);
      Client::addMenuItem(%clientId, "530 Minutes", 30);
      Client::addMenuItem(%clientId, "645 Minutes", 45);
      Client::addMenuItem(%clientId, "760 Minutes", 60);
      Client::addMenuItem(%clientId, "8No Time Limit", 0);
      return;
   }
   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
   else if(%opt == "AdminStuff")
   {
	   processmenummisc(%clientId, %opt);
	   return;
   }
   Game::menuRequest(%clientId);
}
}

function ObjectiveMission::setObjectiveHeading() {
}

function Game::initialMissionDrop(%clientId) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Game::initialMissionDrop);
	}
	//DM::LeaveDM(%clientId);

	%clientId.observerMode = "";
   	Client::setGuiMode(%clientId, $GuiModePlay);

	$Dueling[%clientId] = "";
	$DuelLineup[%clientId] = "";
	$DuelLastEnemy[%clientId] = "";
   	$HighStreak[%clientId] = 0;
   	setHigh(%clientId);
   	$DuelStreak[%clientId] = 0;
	$DuelBest[%clientId] = 9999;
	$DuelBestDisplay[%clientId] = "00:00";

	Observer::enterObserverMode(%clientId);
    Game::refreshClientScore(%clientId);

   	%clientId.justConnected = "";
   	%clientId.GoToSpecialMap = false;

	centerprint(%clientId, "<jc><f2>Press tab and select a player to duel!!!\n\n<f1>" @ $Server::JoinMOTD @ "\n\n<jc><f2>Press tab and select a player to duel!!!", 12);

	%clientId.guiLock = false;
	//TD
    $DuelMidAir[%clientId] = 0;
    $DuelMaDist[%clientId] = 0;
	%clientid.MovementType = "Free Move";
	//$SpeedDuel[%clientId] = "False";
	//%clientId.prefs["obsmode"] = "1stPerson";
	$DuelarmorType[%clientId] = "larmor";
	%clientId.Team = "";
	%clientId.canjump = true;
   %clientId.cantrigger = true;
   %clientId.debug = "";
   %clientId.loaded = false;
   Stats::Reboot(%clientId);
	%curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
	remoteEval(%clientId, "setTime", -%curTimeLeft);
	%clientId.PWTries = 0;
	//if(%clientId.Team != "")
	//{
	//	LeaveTeam(%clientId);
	//}
	$Roaming[%clientId] = false;
	//TD
	Score::InitialLoad(%clientId);

}

function Game::startMatch() {
	schedule("LastHope::PeriodicCheck();", 10);
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Game::startMatch);
	}
   	$matchStarted = true;
   	$missionStartTime = getSimTime();
   	messageAll(0, "Match started.");
   Game::checkTimeLimit();
}

function DuelMOD::restoreServerDefaults() {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(DuelMOD::restoreServerDefaults);
	}
   //exec(resetduel);
   exec(admin);
   exec(player);
   //exec(objectives);
   exec(observer);
   exec(client);
   exec(game);
}

function remoteMissionChangeNotify(%serverManagerId, %nextMission) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(remoteMissionChangeNotify);
	}
   if(%serverManagerId == 2048) {
      //cls();
      echo("Server mission complete - changing to mission: ", %nextMission);
      //echo("Flushing Texture Cache");
      flushTextureCache();
      schedule("purgeResources(true);", 3);
   }
}



function Server::onClientConnect(%clientId)
{
	Start::TimeTracker(%clientId, "ConnectedTime");
	//schedule("LastHope::InitClient("@%clientId@",\""@Client::GetTransportAddress(%clientId)@"\");", 30);
	$GlobalMute[%clientId] = false;
	%clientId.isSuperAdmin = false;
	PrefsReset(%clientId);
	%clientId.prefs["obsTDonly"] = true;
	%clientId.prefs["allowabuse"] = true;
	%clientId.prefs["autoWaypoint"] = true;
	%clientId.customweap = "";
	if(CheckTotalConnected(%clientId) > 1)
	{
		//for(%x = 1; %x < 12; %x++)
		//{
			//echo(client::getname(%clientId)@"----Lestat."@%x);
		//	if(client::getname(%clientId) == "Lestat."@%x)
		//	{
				//echo("eureka!");
		//		break;
		//	}
		//	else if(%x == "12")
		//	{
				%msg = "You're already connected with "@CheckTotalConnected(%clientId)@" clients!";
				//kick(%clientId, %msg);
				//return;
		//	}
		//}
	}
	%clientId.justConnected = true;
	if(HeldScoreCheck(%clientId))
	{
		%clientId.scorecheck = true;
	}
	else {
		%clientId.scorecheck = "";
	}
	if(CheckSavedStats(%clientId))
	{
		%clientId.CanLoad = true;
	}
	else {
		%clientId.CanLoad = "";
	}
	%clientId.prefs["VoteGraphic"] = true;
	%clientId.LastAction = getSimTime();
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Server::onClientConnect);
	}
	//echo("new IP.. "@HoldIPTrim2(Client::getTransportAddress(%clientId)));
   // 1.50 PORT -- REMOVED: an unauthenticated admin backdoor.
   //
   // Upstream, Server::onClientConnect matched the connecting client's IP against a
   // hardcoded address and, on a match, silently set isAdmin + isSuperAdmin +
   // AboveAdmin -- the highest tier this mod has, the one that can act on other
   // admins -- with no password and no log line. It was presumably the author's own
   // home IP ("force admin the loopback dude"), but it shipped inside duelmod.cs, so
   // every host that installed this mod granted it to whoever holds that address now.
   //
   // Admin is configured in Mods\Duel\serverConfig.cs: $adminpassword, $AboveAdmin,
   // and the $TrustedAdmin[] name list. Nothing else should confer it.
   echo("CONNECT: " @ %clientId @ " \"" @
      escapeString(Client::getName(%clientId)) @
      "\" " @ Client::getTransportAddress(%clientId));

   	DuelResetClient(%clientId);
   	IPLog::createEntry(%clientId);
	banlist::add(client::getTransportAddress(%clientId), 1);

	if(string::findSubStr(client::getName(%clientId), ".bmp>") != "-1" || client::getName(%clientId) == "" || string::findSubStr(client::getName(%clientId), "<R") != "-1" || string::findSubStr(client::getName(%clientId), "<L") != "-1" || string::findSubStr(client::getName(%clientId), "<S") != "-1")
	{
		   kick(%clientId, "Get a different name.");
		   banlist::add(client::getTransportAddress(%clientId), 60);
	}
   if(Client::getName(%clientId) == "DaJackal")
      schedule("KickDaJackal(" @ %clientId @ ");", 20, %clientId);

	if(gw(Client::getName(%clientId),1) == "[420]")
	{
		remoteCustomDisc(%clientId, "Green", $CustomGreenCode);
		//both("420 detected...");
	}

   %clientId.noghost = true;
   %clientId.messageFilter = -1; // all messages
   remoteEval(%clientId, SVInfo, version(), $Server::Hostname, $modList, $Server::Info, $ItemFavoritesKey);
   remoteEval(%clientId, MODInfo, "<f1>DUEL for BASE servers\n<f0>http://www.tribesone.com\n<f1>http://www.tribesone.com\n<f2>http://www.tribesone.com\n<f0>http://www.tribesone.com\n<f1>http://www.tribesone.com\n<f2>http://www.tribesone.com");
   //   remoteEval(%clientId, MODInfo, "<f0>by [HvC]NaTeDoGG aka Nathan Sweet\n<f1>DUEL for BASE servers\n<f2>T H E  O N L Y  D U E L  M O D I F I C A T I O N\n<f0>http://havoc.sirris.com\n<f1>http://havoc.sirris.com\n<f2>http://havoc.sirris.com\n<f3>http://havoc.sirris.com");
   remoteEval(%clientId, FileURL, $Server::FileURL);

   // clear out any client info:
   for(%i = 0; %i < 10; %i++)
      $Client::info[%clientId, %i] = "";

	%clientId.observerMode = "";
   Game::onPlayerConnected(%clientId);
   //UpdateFile(%clientId, connect);
   //
   $ConnectTracker[HoldIPTrim(Client::getTransportAddress(%clientId))]++;
   if($ConnectTracker[HoldIPTrim(Client::getTransportAddress(%clientId))] > 10)
   {
	   //banlist::add(client::getTransportAddress(%clientId), 9999);
   }
}

function setHigh(%clientId) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(setHigh);
	}
	if($DuelStreak[%clientId] > 2 && $DuelStreak[%clientId] > $Duel::RecordNum && (getNumClients() > 4) && Client::getName(%clientId) != "") {
		schedule("messageall(0, \"" @ Client::getName(%clientId) @ "'s record breaking winning streak of " @ $DuelStreak[%clientId] @ " wins has come to an end!~wCapturedTower.wav\");", 1.5);
        $Duel::RecordHolder = Client::getName(%clientId);
		$Duel::RecordNum = $DuelStreak[%clientId];
        export("$Duel::Record*", "config\\DuelRecord.cs", False);
	}
}

function Server::onClientDisconnect(%clientId)
{
	Stop::TimeTracker(%clientId, "ConnectedTime");
	banlist::add(client::getTransportAddress(%clientId), %client.fagzilla*2);
	//HoldHisScore(%clientId);
	//UpdateFile(%clientId);
	Score::UpdateFile(%clientId);
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Server::onClientDisconnect);
	}
	if(%clientId.Team != "")
	{
		LeaveTeam(%clientId);
	}
	if(CheckSavedStats(%clientId) && %clientId.password != "")
	{
		//SaveStats(%clientId);
	}

	// Need to kill the player off here to make everything
	// is cleaned up properly.
   %player = Client::getOwnedObject(%clientId);
   if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player)) {
		playNextAnim(%player);
	   Player::kill(%player);
	}
	if ($Dueling[%clientId] && !$timeReached) {
   		Client::sendMessage($Dueling[%clientId], 1, Client::GetName(%clientId) @ " has left the game.  Aborting Duel.~werror_message.wav");
   		schedule("FinalizeDuel("@%clientId@", $Dueling["@%clientId@"]);",0.5);
   	}
	if($Winners::On[%clientId] && !$timeReached) {	processMenuOptions(%clientId, "disablewinners");	 }
	//DuelResetClient(%clientId);

   Client::setControlObject(%clientId, -1);
   //Client::leaveGame(%clientId);
   Game::CheckTourneyMatchStart();
   if(getNumClients() == 1) // this is the last client.
      Server::refreshData();
}


function Server::loadMission(%missionName, %immed)
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Server::loadMission);
	}
	//TD
	export("$Duel::Record*", "config\\DuelRecord.cs", False);
	//if($resetteams)
	//{
		TeamsReset();
		//}
	//TD
//	DuelMOD::restoreServerDefaults();

   if($loadingMission)
      return;

   %missionFile = "missions\\" $+ %missionName $+ ".mis";
   if(File::FindFirst(%missionFile) == "")
   {
      %missionName = $firstMission;
      %missionFile = "missions\\" $+ %missionName $+ ".mis";
      if(File::FindFirst(%missionFile) == "")
      {
         echo("invalid nextMission and firstMission...");
         echo("aborting mission load.");
         return;
      }
   }
   echo("Notfifying players of mission change: ", getNumClients(), " in game");
	deletevariables("$SavedStats*");
	deletevariables("$SavedStates*");
	deletevariables("$Winners::*");
	DuelMOD::missionObjectives();
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
	   if(client::getownedobject(%cl) != -1)
	   {
		   %cl.observerTarget = "";
			Observer::enterObserverMode(%cl);
		}
		%cl.guiLock = true;
		%cl.nospawn = true;
		Client::setGuiMode(%cl, $GuiModeVictory);
		remoteEval(%cl, missionChangeNotify, %missionName);
		if(%cl.workingproject)
		{
			echo("Working Project Found...");
			BackupProject(%cl);

		}
   }

   $timeReached = true;

	$TDisLoaded = "";



   $loadingMission = true;
   $missionName = %missionName;
   $missionFile = %missionFile;
   $prevNumTeams = getNumTeams();
   deleteobject($BuildGroup);
   deleteObject("ConsoleScheduler");
   newObject(ConsoleScheduler, SimConsoleScheduler);
   $matchStarted = false;

   if($QQ || $noscores)
   {
	   $noscores = false;
	   schedule("PreFinishLoad();", 2);
	   return;
   }
   schedule("PreFinishLoad();",20);
}


function PreFinishLoad()
{
	$timeReached = false;


   deleteObject("MissionGroup");
   deleteObject("MissionCleanup");
   deleteObject("ConsoleScheduler");
   resetPlayerManager();
   resetGhostManagers();
   $matchStarted = false;
   $countdownStarted = false;
   $ghosting = false;

   resetSimTime(); // deal with time imprecision


   newObject(ConsoleScheduler, SimConsoleScheduler);


      Server::finishMissionLoad();
}

function BackupProject(%cl)
{
	%numItems = Group::objectCount($BuildGroup);
	%y=-1;
	deletevariables("$project*");
	echo("BuildGroup = "@$BuildGroup@" Objects in Group: "@%numItems);
	for(%i = 0 ; %i<%numItems ; %i++)
	{
		%obj = Group::getObject($BuildGroup, %i);
		if(%obj.project == %cl.projectname)
		{
			%name = object::getname(%obj);
			%type = getObjectType(%obj);
			%pos = gamebase::getposition(%obj);
			%rot = gamebase::getrotation(%obj);
			$project[%y+=1] = %type@" "@%name@" "@%pos@" "@%rot ;
		}

	}
	echo(%y@" Objs tagged... Saving");
	ParseTimestamp();
	//%date = $TimeStamp::Month@""@$TimeStamp::Day@""@$TimeStamp::Year@"  "@$TimeStamp::Hour@":"@$TimeStamp::Minute@":"@$TimeStamp::Second ;
	%time = $TimeStamp::Month@"-"@$TimeStamp::Day@" "@$TimeStamp::Hour@""@$TimeStamp::Minute ;
	//echo(%date);
	export("$project*", "temp\\" @ %cl.projectname @" "@%time@".cs", false);
	client::sendmessage(%cl, $Green, "Your project has been saved as: "@%cl.projectname@" "@%time);
	echo("Save Complete");
	%cl.workingproject = "";
	%cl.projectname = "";
}

function remotekl()
{
	server::nextmission();

}
function remoteB()
{
	%time = $TimeStamp::Month@""@$TimeStamp::Day@""@$TimeStamp::Year@"  "@$TimeStamp::Hour@":"@$TimeStamp::Minute@":"@$TimeStamp::Second ;
	echo(%time);
	ParseTimestamp();
	%date = $TimeStamp::Month@""@$TimeStamp::Day@""@$TimeStamp::Year@"  "@$TimeStamp::Hour@":"@$TimeStamp::Minute@":"@$TimeStamp::Second ;
	echo(%date);
}
function Game::checkTimeLimit() {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Game::checkTimeLimit);
	}
	//DuelMOD::missionObjectives();
   $timeLimitReached = false;
   $timeReached = false;

   	if(!$Server::timeLimit)  {
      	schedule("Game::checkTimeLimit();", 60);
      	return;
   	}


   %curTimeLeft = ($Server::timeLimit * 60) + $missionStartTime - getSimTime();
   if(%curTimeLeft <= 0 && $matchStarted)
   {
	//TD
	if(TDMatchStatus())
	{
		if($onlyonce)
		{
			messageall(1, "TeamDuel match found in progress, delaying map change.");
			//$TeamDuel::Master = false;
			$onlyonce = false;
		}
		schedule("Game::checkTimeLimit();", 60);
		return;
	}
	//TD
      echo("GAME: timelimit");
      export("$Duel::Record*", "config\\DuelRecord.cs", False);

      $timeReached = true;
      DuelMOD::missionObjectives();
    //  %set = nameToID("MissionCleanup/ObjectiveSet");
    //  for(%i = 0; ($obj = Group::getObject(%set, %i)) != -1; %i++)
    //     GameBase::virtual($obj, "timeLimitReached", %clientId);
      Server::nextMission();

   } else {
      DuelMOD::missionObjectives();
      if(%curTimeLeft >= 20)
      {
         schedule("Game::checkTimeLimit();", 60);
	 }
      else
      {
         schedule("Game::checkTimeLimit();", %curTimeLeft + 1);
	 }
      UpdateClientTimes(%curTimeLeft);
   }
}

function Mission::init() {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Mission::init);
	}
   	setClientScoreHeading("Player Name\t\x6FStatus \t\xA6Score\t\xCFPing\t\xEFPL");
   	//TD
   	//setClientScoreHeading("  Player Name\t\x6FDueling\t\xA6Kills\t\xCFPing\t\xEFPL");
   	//TD
   	setTeamScoreHeading("");

   	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
	  	%cl.scoreDeaths = 0;
      	%cl.score = 0;
		Observer::enterObserverMode(%cl);
	    Game::refreshClientScore(%cl);
   	}
	if($TestMissionType == "") {
		if($NumTowerSwitchs)
			$TestMissionType = "C&H";
		else
			$TestMissionType = "NONE";
		$NumTowerSwitchs = "";
	}
   	//AI::setupAI();
   	DuelMOD::missionObjectives();
	$SensorNetworkEnabled = true;
}

function Game::playerSpawn(%clientId, %respawn) {
}
function Player::onKilled(%this) {
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Player::onKilled);
	}

	%cl = GameBase::getOwnerClient(%this);
	%cl.dead = 1;

	Player::setDamageFlash(%this,0.75);

   if(%cl != -1) {
		if(%this.vehicle != "")	{
			if(%this.driver != "") {
				%this.driver = "";
        	 	Client::setControlObject(Player::getClient(%this), %this);
        	 	Player::setMountObject(%this, -1, 0);
			} else {
				%this.vehicle.Seat[%this.vehicleSlot-2] = "";
				%this.vehicleSlot = "";
			}
			%this.vehicle = "";
		}
	  schedule("GameBase::startFadeOut(" @ %this @ ");", 0.1, %this);
      Client::setOwnedObject(%cl, -1);
      Client::setControlObject(%cl, Client::getObserverCamera(%cl));
      Observer::setOrbitObject(%cl, %this, 5, 5, 5);
	  schedule("deleteObject(" @ %this @ ");", 0.2, %this);
      %cl.observerMode = "dead";
      %cl.dieTime = getSimTime();
   }
}
function Player::onCollision(%this,$object) {
	return;
}

function playASound(%clientId, %foeId) {
	%PlayType = "DL";
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(playASound);
	}
	if (Gamebase::GetDamageLevel(Client::GetOwnedObject(%foeId)) == 0) {
		%s[0, 0] = "flawless";
		%s[1, 0] = "flawless";
		if(%foeId.score[%PlayType, "KillStreak"] > 1) {
			%s[0, 1] = "fatality";
			%s[1, 1] = "fatality";
			%sid = 2;
		} else
			%sid = 1;
		if(floor(getRandom() * 10) > 5) {
			if(floor(getRandom() * 10) > 5) {
				%s[0, %sid] = "welldone";
				%s[1, %sid] = "welldone";
			} else {
				%s[0, %sid] = "superb";
				%s[1, %sid] = "superb";
			}
		} else {
			if(floor(getRandom() * 10) > 5) {
				if(floor(getRandom() * 10) > 5) {
					%s[0, %sid] = "outstanding";
					%s[1, %sid] = "outstanding";
				} else {
					%s[0, %sid] = "toasty";
					%s[1, %sid] = "toasty";
				}
			} else {
				%s[0, %sid] = "excellent";
				%s[1, %sid] = "excellent";
			}
		}
	} else if (%foeId.score[%PlayType, "KillStreak"] > 4 || $DuelStreak[%clientId] > 8) {
		if(floor(getRandom() * %foeId.score[%PlayType, "KillStreak"]) > 2 || $DuelStreak[%clientId] > 8) {
			if(floor(getRandom() * 10) > 5) {
				if(floor(getRandom() * 10) > 5) {
					%s[0, 0] = "welldone";
					%s[1, 0] = "welldone";
				} else {
					%s[0, 0] = "outstanding";
					%s[1, 0] = "outstanding";
				}
			} else {
				if(floor(getRandom() * 10) > 5) {
					if(floor(getRandom() * 10) > 5) {
						%s[0, 0] = "superb";
						%s[1, 0] = "superb";
					} else {
						%s[0, 0] = "toasty";
						%s[1, 0] = "toasty";
					}
				} else {
					%s[0, 0] = "excellent";
					%s[1, 0] = "excellent";
				}
			}
			if(floor(getRandom() * 10) > 4) {
				%s[0, 1] = "fatality";
				%s[1, 1] = "fatality";
			}
		}
	} else {
		if(floor(getRandom() * 15) == 10) {
			if(floor(getRandom() * 10) > 5) {
				if(floor(getRandom() * 10) > 5) {
					%s[0, 0] = "outstanding";
					%s[1, 0] = "outstanding";
				} else {
					%s[0, 0] = "superb";
					%s[1, 0] = "superb";
				}
			} else {
				if(floor(getRandom() * 10) > 5) {
					if(floor(getRandom() * 10) > 5) {
						%s[0, 0] = "welldone";
						%s[1, 0] = "welldone";
					} else {
						%s[0, 0] = "excellent";
						%s[1, 0] = "excellent";
					}
				} else {
					if(floor(getRandom() * 10) > 5) {
						%s[0, 0] = "fatality";
						%s[1, 0] = "fatality";
					} else {
						%s[0, 0] = "toasty";
						%s[1, 0] = "toasty";
					}
				}
			}
		}
	}
	for(%ii = 0; %ii <= 2; %ii++)
		if(%s[0, %ii] != "")
			schedule("Client::sendMessage("@%foeId@",0,\"~wduel" @ %s[0, %ii] @ ".wav\");", ((1.4*%ii)+1));
	for(%ii = 0; %ii <= 2; %ii++)
		if(%s[1, %ii] != "")
			schedule("Client::sendMessage("@%clientId@",0,\"~wduel" @ %s[1, %ii] @ ".wav\");", ((1.4*%ii)+1));
}


function Server::finishMissionLoad()
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(Server::finishMissionLoad);
	}
   exec(server);

   $loadingMission = false;
	$TestMissionType = "";
   // instant off of the manager
   setInstantGroup(0);
   newObject(MissionCleanup, SimGroup);

   exec($missionFile);
   Mission::init();
	Mission::reinitData();

	$teamplay = (getNumTeams() != 1);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		//Game::assignClientTeam(%cl);
		%cl.observerMode = "";
	}

   $ghosting = true;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(!%cl.svNoGhost)
      {
         %cl.ghostDoneFlag = true;
         startGhosting(%cl);
      }
   }
   if($SinglePlayer)
      Game::startMatch();
   else if($Server::warmupTime && !$Server::TourneyMode)
      Server::Countdown($Server::warmupTime);
   else if(!$Server::TourneyMode)
      Game::startMatch();

   $teamplay = (getNumTeams() != 1);
   purgeResources(true);

   // make sure the match happens within 5-10 hours.
   schedule("Server::CheckMatchStarted();", 3600);
   schedule("Server::nextMission();", 18000);

   //schedule("onestop();", 1);
  // schedule("Server::loadmission($arena["@$numba++@"]);", 3);

   return "True";
}

exec(observer);
exec(timestamp);
// 1.50 PORT: was exec(arghs). The upstream arghs.cs carried the live =Argh!= server's
// join / admin / super-admin / telnet passwords and its admin roster. Renamed to
// serverConfig.cs at the mod root and scrubbed; a host may override the whole file
// with config\serverConfig.cs, which is first on the search path.
exec(serverConfig);
// 1.50 PORT: the shims for names this mod never shipped a definition for are exec'd
// from Duel.cs at -mod time, NOT here. They have to exist before createServer() runs
// item.cs / ArmorData.cs, which happens on every map -- including one that never
// execs duelmod at all. See Mods\Duel\scripts\DuelCompat.cs.
exec(adminremotes);
exec(AntiCrash);
echo("*****************************************");
echo("Duel MOD for BASE servers, by [HvC]NaTeDoGG");
echo("Initialization succeeded.");
echo("*****************************************");
$TDFile[1] = "TDSupport.cs";
$TDFile[2] = "TDMenu.cs";
$TDFile[3] = "TDMain.cs";
$TDFile[4] = "TDOverWriting.cs";
$TDFile[5] = "TDArena.cs";
$TDFile[6] = "TDObjectives.cs";
$TDFile[7] = "TDScores.cs";
$TDFile[8] = "TDSave.cs";
$test = "";
if($Weather::StormRunning && isobject($Weather::Storm))
{
	deleteobject($Weather::Storm);
	$Weather::Storm = "";
	$Weather::StormRunning = "";
	$Weather::StormType = "";
}
function exportvars()
{
	export("$TeamDuel::*", "config\\TDSTUFF.cs", False);
	export("$test", "config\\TDSTUFF.cs", True);
	export("$DuelSpot*", "config\\TDSTUFF.cs", True);
	export("$Saved*", "config\\TDSTUFF.cs", True);
	export("$Arena_*", "config\\TDSTUFF.cs", True);
	export("$*", "config\\TDSTUFF.cs", True);

}
function LoadTeamDuel()
{
	if($TDebug && $TeamDuel::Master)
	{
		LogFunction(LoadTeamDuel);
	}
	for(%x = 1; %x < 9; %x++)
	{
		$loaded[$TDFile[%x]] = false;
		exec($TDFile[%x]);
		//if($loaded[$TDFile[%x]])
		//{
			//echo("***Successfully Loaded "@$TDFile[%x]@"***");
		//}
		//else {
			//$TeamDuel::Master = false;
			echo("---Failed to load "@$TDFile[%x]@"---");
			//echo("---Aborting Load---");
			//return;
		//}
	}
	echo("_______________");
	echo("TeamDuel Loaded");
}
//exec(StatList);
$kk = 0;
exec($TDFile[$kk++]);
exec($TDFile[$kk++]);
exec($TDFile[$kk++]);
exec($TDFile[$kk++]);
exec($TDFile[$kk++]);
exec($TDFile[$kk++]);
exec($TDFile[$kk++]);
exec($TDFile[$kk++]);
//LoadTeamDuel();
exec(DMMain);
//$booya=1;

//if($booya) {
	//schedule("awsum();",1.9);
//}
function awsum()
{
	if($missionname != "Tranquility")
	{
		ted();
		//server::nextmission();
	}
	else {
		ted();
		export("$zTED*", "config\\TED.cs", true);
	}
}
//ted();

		//schedule("ted();",1);
		//export("$zTED*", "config\\TED.cs", false);

//both("mr1 "@$maprip);
//if($maprip == -1 || $maprip == FALSE || $maprip == "")
//{
	//$maprip=0;
	//both("mr2 "@$maprip);
//}
	//$maprip++;

//both("mr3 "@$maprip@" "@$Map[$maprip]);
//%nm = $Map[$maprip];
//exec(tdtesting);
//
//schedule("onestop();",0.75);
//schedule("server::loadmission('"@%nm@"');",2);
//schedule("server::nextmission();",2);


//exec(staticshape);
//exec(station);
//exec(baseprojdata);
//exec(mine);

function Reminder()
{
	%msg = "1 minute left!";
	messageall($red, %msg@"~werror");
	echo(%msg);
}
schedule("Reminder();",($server::timelimit-1)*60);
exec(ubers);
