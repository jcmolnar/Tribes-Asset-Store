// JesterMOD v1 by Casey D'Angelo (scripts.vol dated 2000-12-21, release 2001-02; built on
// Ultra Renegades VX4) -- Modern Tribes (1.50) entry script. Not part of the original release.
// The original was one scripts.vol in tribes\JesterMOD, started with (JesterMOD.bat):
//     Tribes +exec serverConfig -mod JesterMOD
// serverConfig.cs held only commented-out lines (admin password, telnet); ServerPrefs.cs was a
// stock prefs file with the author's server name and team names. Neither is needed here.
// Launch here:  -mod Jester
echo(">> JesterMOD v1");

$MODInfo = "JesterMOD v1 by Casey D'Angelo";

// PORT: the 1.50 server.cs hands a late joiner the match clock through Game::syncClientClock,
// which lives in the base objectives.cs this mod replaces. Same arithmetic as the mod's own
// Game::checkTimeLimit (game.cs).
function Game::syncClientClock(%cl)
{
   if(!$matchStarted || !$Server::timeLimit)
      return;
   remoteEval(%cl, "setTime", -(($Server::timeLimit * 60) + $missionStartTime - getSimTime()));
}

// PORT: the mod kept this function in its server.cs, which is otherwise an old stock copy and is
// not shipped (the 1.50 one runs). The guided-missile weapons call it (item.cs:1807, :1876).
// Unchanged.
function RocketLockWarning(%clientId, %target, %targetType) 
{ 
	%targetId = GameBase::getControlClient(%target);
	%targetName = Client::getName(%targetId); 
	%name = Client::getName(%clientId); 
	if(%targetType == Flier) {
		if(%targetName != "") 
			%msg = "Vehicle Piloted by " @ %targetName; 
		else 
			%msg = "Vehicle"; 
	} else 
		%msg = %targetName; 
	Client::sendMessage(%clientId,0,"Lock Aquired: " @ %msg @ "~wmine_act.wav");
	//if(%targetType == Flier || whatArm(Player::getArmor(%target)) == 3) {
		if(%targetType == "Player" || %targetType == "Flier") {
		Client::sendMessage(%targetId,0,"WARNING - " @ %name @ " has a guided missile lock!~werror_message.wav");
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~werror_message.wav\");", 0.5);
		schedule("Client::sendMessage(" @ %targetId @ ",0,\"~werror_message.wav\");", 1.0); 
	}
}