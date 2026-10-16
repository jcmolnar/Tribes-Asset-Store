//-----------------------------------------------------------
// Snipers Base 2.0 by King Shit -- entry script for the Modern Client (1.50)
//
// The 2001 install put this settings file in Tribes\config\Snipers.cs and the
// scripts in Tribes\Snipers\ ; "-mod Snipers" ran it as the mod-name script
// (Snipers.txt, INSTALLATION steps 1-4).  The loader now runs this copy from
// Mods\Snipers\Snipers.cs.  Everything below the PORT BLOCK is the original
// settings file; the lines the port changed are marked PORT.
//-----------------------------------------------------------

// ---- PORT BLOCK (added by the port) ----------------------
echo("Snipers Base 2.0 (King Shit) -- 1.50 port entry");

// Shown to a joining client in the loading text.
$MODInfo = "<f2>Snipers Base <f1>v2.0\n<f2>by King Shit";

// The mod was built on the Alliance engine and still calls its log functions
// (logging.cs), which this archive does not contain.  Each call printed
// "Unknown command" (every chat line, every kill).  They only wrote log lines.
function reportText(%client, %command, %line) { }
function reportKill(%clKiller, %clVictim, %damageType) { }
function reportGame(%line) { }
function reportTeam(%client, %line) { }
function reportDeploy(%item, %client) { }

// Insomniax station time-out helpers (station.cs calls them; the archive lost
// their definitions).  Text taken from the Insomniax admin code as shipped in
// the Alliance engine's station.cs.
function ixDotProd(%vec, %scalar)
{
	%return = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %return;
}

function ixSin(%theta)
{
	return (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
}

function ixCos(%theta)
{
	return (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
}
// ---- end of PORT BLOCK ------------------------------------

// ---- PORT: stock functions this mod's scripts call but none of its files defines ----
// (text copied from the 1.50 base scripts game.cs / turret.cs, which the mod's own
//  game.cs / turret.cs replace)
function Game::ForceTourneyMatchStart()
{
   %playerCount = 0;
   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pregame")
         %playerCount++;
   }
   if(%playerCount == 0)
      return;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")   
         processMenuInitialPickTeam(%cl, -2); // throw these guys into observer
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
   }
   Server::Countdown(30);
}

function Game::CheckTourneyMatchStart()
{
   if($CountdownStarted || $matchStarted)
      return;
   
   // loop through all the clients and see if any are still notready
   %playerCount = 0;
   %notReadyCount = 0;

   for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
   {
      if(%cl.observerMode == "pickingTeam")
      {
         %notReady[%notReadyCount] = %cl;
         %notReadyCount++;
      }   
      else if(%cl.observerMode == "pregame")
      {
         if(%cl.notready)
         {
            %notReady[%notReadyCount] = %cl;
            %notReadyCount++;
         }
         else
            %playerCount++;
      }
   }
   if(%notReadyCount)
   {
      if(%notReadyCount == 1)
         MessageAll(0, Client::getName(%notReady[0]) @ " is holding things up!");
      else if(%notReadyCount < 4)
      {
         for(%i = 0; %i < %notReadyCount - 2; %i++)
            %str = Client::getName(%notReady[%i]) @ ", " @ %str;

         %str = %str @ Client::getName(%notReady[%i]) @ " and " @ Client::getName(%notReady[%i+1]) 
                     @ " are holding things up!";
         MessageAll(0, %str);
      }
      return;
   }

   if(%playerCount != 0)
   {
      for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
      {
         %cl.notready = "";
         %cl.notreadyCount = "";
         bottomprint(%cl, "", 0);
      }
      Server::Countdown(30);
   }
}

function Turret::checkOperator(%this)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1) {
   	%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
	   Client::setControlObject(%cl, %pl);
   }
	Client::setGuiMode(%cl,2);
}

// PORT: baseProjData.cs:65 gives the chaingun bullet damageType = $BulletDamageType, which
// the mod never sets (it renamed type 1 to $ShotgunDamageType): the bullet was typed 0 =
// landing damage.  1 is the stock value and the mod's own shotgun type.
$BulletDamageType = 1;

// ---- original settings file (config\Snipers.cs) follows ----
$Snipers::BanKickTime = "600";
$Snipers::fairTeams = "true";
$Snipers::PABan = "false";
$Snipers::PAKick = "true";
$Snipers::PAMission = "true";

$Snipers::PADetongue = "true";		//Allows PublicAdmins to have the ability to detongue someone
$Snipers::PABlowUp = "true";			//Allows PublicAdmins to have the ability to blowup someone
$Snipers::PAStripVoteRights = "true";	//Allows PublicAdmins to have the ability to strip someones ability to vote

$Snipers::PAModOptions = "false";
$Snipers::PAResetDefaults = "true";
$Snipers::PATeamChange = "true";
$Snipers::PATeamDamage = "true";
$Snipers::PATeamInfo = "false";
$Snipers::PATimelimit = "false";
$Snipers::PATourneyMode = "false";
$Snipers::PAVote = "false";

$Snipers::tkClientLvl = "1";
$Snipers::tkLimit = "3";
$Snipers::tkMultiple = "3";
$Snipers::tkServerLvl = "3";
//PORT-OFF: $TelnetPort = 28001;   (a mod must not open the host's remote console)


//You now have the ability to enable out of area damage.  Set this to true to enable.
//If you take a repair pack and try to live outside the mission area, you will be 
//teleported back to the original location that you entered in about 45 seconds.
//This works in free for all mode only
$Snipers::OutOfAreaDamage = true;

//Set to 1 if you want to enable the ban/kick by name, on player connect.  Make sure to set
//up your list in the config\\BBNList.cs
$BanByName::IsOn = 0;

//logs the name and IP of everyone who connects, to config\\Connect.log
$ConnectLog = true; 

//log people who are kicked by admins, to config\\KickList.log
$ExportAKicks = false; 

//log people who are kicked by the computer, to config\\KickList.log
$ExportCKicks = false; 

//log everyone who is auto-admined to config\\AdminLog.log
$ExportAdmin = 0;

//log all admins punishments applied to players to config\\AdminPunish.log
$ExportAdminPun = 1;

//What you want it to say when an admin kicks a client, this is a centerprint message
//The "\n" will seperate lines of text on the screen... Example....
$Admin::KickMessage = "For being a complete Idiot, and total moron.....\n\n You are being kicked off of this server. \n\n Come back when you no longer have an attack of the dumbass.";

//If you want to see your personal skins.  The skins must be installed in your(clientside)
//tribes\base\skins directory, and set this option to true.
$Snipers::PersonalSkin = "true"; 

//When set to true, no one can blow you out of ANY stations
//I wouldn't set this unless you have the station kick on also.
//Without the station kick, they can tie up a station for the rest of the game
//if they want, and nothing will blow them out!!
//If the person gets blocked in so that the station kick function can't
//kick them out, THEN you can shoot them out of the station, but not before.
$StationLockTD = "true";  // no knock from station with teamdamage off
$StationLockNTD = "true";  // no knock from station with teamdamage on

//How long the server will wait before ejecting someone out of a inventory station.  This
//only works when there are more then 3 people in the game
$Snipers::StationTime = "60";  //range is 10-60

$PA::noKick = "false";  //if set to true, public admins cant be kicked by a vote

//Special message for the owner when you gain super admin
//status with the SAD code and reports this name in the server info menu
$Owner::Name = "King Shit{|XK|}"; 

//ownerpassword gives God admin status, adminpassword gives
//superadmin status, and of course publicpassword gives public
//admin status

//PORT-OFF: $TelnetPassword = "password";
$OwnerPassword = "";   // PORT: was the published default "password"
$AdminPassword = "";   // PORT: was the published default "password"
$PublicPassword = "";   // PORT: was the published default "password"

//Enables stat tracking in console.  Usage will echo flag caps, returns, drops, 
//objective captures, destroyed objects.....etc.
$StatTrack = true;
