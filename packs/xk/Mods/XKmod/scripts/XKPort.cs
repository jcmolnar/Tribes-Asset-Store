// XKPort.cs -- written for the Modern Tribes (1.50) port of the XK mod; exec'd by server.cs.
//
// The mod's game.cs is built on the Tribes 1.0 game.cs (through Renegades Alliance), but its
// admin.cs, server.cs and objectives.cs (and the stock observer.cs) use three things that 1.0
// game.cs did not have yet. In the original each call printed "Unknown command": a tournament
// match could not be started by an admin or by everyone pressing fire, and a neutral flag never
// timed out. The two functions below are the stock ones; the timer is the stock value.
$flagToStandTime = 180;

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
      %cl.notready = "";
      %cl.notreadyCount = "";
      bottomprint(%cl, "", 0);
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

// server.cs picks the next map with this when $RandomMissions is set. It came from the mod's copy
// of missionlist.cs, which is otherwise the stock file and is not shipped.
function MissionList::nextRandom()
{
   %i = floor(getRandom() * $MLIST::Count);
   return $MLIST::EName[%i];
}

// ---- guards for admin.cs (menu codes and their arguments are sent by the client) -------------

// super admin, or public admin with that public-admin lockout open
function XKPort::PA(%clientId, %lockout)
{
   if(%clientId.isSuperAdmin)
      return true;
   if(%clientId.isAdmin && %lockout)
      return true;
   return false;
}

// May this client use this Options-menu code? Mirrors the conditions under which
// Game::menuRequest lists each entry.
function XKPort::mayOption(%clientId, %opt)
{
   if(%opt == "funadmin" || %opt == "execute" || %opt == "admin" || %opt == "gag"
      || %opt == "ungag" || %opt == "freeze" || %opt == "unfreeze")
      return %clientId.isSuperAdmin;
   if(%opt == "strip")
      return %clientId.isGod;
   if(%opt == "kick")
      return XKPort::PA(%clientId, $XKmod::PAKick);
   if(%opt == "ban")
      return XKPort::PA(%clientId, $XKmod::PABan);
   if(%opt == "fteamchange")
      return XKPort::PA(%clientId, $XKmod::PATeamChange);
   if(%opt == "etd" || %opt == "dtd")
      return XKPort::PA(%clientId, $XKmod::PATeamDamage);
   if(%opt == "cffa" || %opt == "ctourney" || %opt == "smatch")
      return XKPort::PA(%clientId, $XKmod::PATourneyMode);
   if(%opt == "ctimelimit")
      return XKPort::PA(%clientId, $XKmod::PATimeLimit);
   if(%opt == "reset")
      return XKPort::PA(%clientId, $XKmod::PAResetDefaults);
   if(%opt == "XKmod")
      return XKPort::PA(%clientId, $XKmod::PAModOptions);
   if(%opt == "cmission")
      return XKPort::PA(%clientId, $XKmod::PAMission);
   if(%opt == "vcmission")
      return $XKmod::PAMission && $curVoteTopic == "";
   if(%opt == "vkick")
      return $XKmod::PAKick && $curVoteTopic == "";
   if(%opt == "vadmin")
      return $XKmod::PAVote && $curVoteTopic == "";
   if(%opt == "tkopt")
   {
      %k = Insomniax_getKiller(%clientId);
      if(%k == "" || %k == %clientId)
         return false;
      return $tkKills[%k] >= $XKmod::tkLimit;
   }
   return true;
}

// The delayed kick of Admin::kick: the message holds the admin's name, so it is kept on the
// client object instead of being pasted into a schedule() string.
function XKPort::kickNow(%client)
{
   Net::kick(%client, %client.hsKickMsg);
}

// ---- station eject ---------------------------------------------------------------------------
// station.cs (ixStationEjectPlayer) calls these three Insomniax helpers; the XK scripts lost them
// (they sit in station.cs of the Renegades Alliance engine the mod was built from; text taken from
// there). Without them the timed-out player was not pushed out of the station.
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

// ---- per-mission reset of team deploy counters -------------------------------------------------
// serverXKmod::InitializeMission calls <file>::Initialize() for each module to zero its
// $TeamItemCount entries (the objects of the last map are deleted without their onDestroyed).
// These modules had no such function, so their team limit, once reached, stayed reached on every
// later map until the server was restarted. The three empty ones have nothing to reset
// (TreePack is zeroed by deployTree::Initialize).
function deployAirBase::Initialize()
{
   for(%i = 0; %i < 8; %i++)
      $TeamItemCount[%i @ airbase] = 0;
}

function deployHyperGravityTurret::Initialize()
{
   for(%i = 0; %i < 8; %i++)
      $TeamItemCount[%i @ HGravTurretPack] = 0;
}

function packTree::Initialize()
{
}

function packKamikaze::Initialize()
{
}

function miscBoostermine::Initialize()
{
}

// ---- stock function the mod's older turret.cs lacks -------------------------------------------
// turret.cs (RocketTurret::onPower) calls it when a rocket turret loses power, to put the player
// who is controlling the turret back in his body. Stock text.
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
