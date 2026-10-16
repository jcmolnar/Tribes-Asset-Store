//*******************
//TRIBAL COMBAT ADMIN
//*******************
function processMenuPlayerSettings(%clientId,%opt)
{
 if(%opt == "changeteams")
 {
  if(!$matchStarted || !$Server::TourneyMode)
  {
   Client::buildMenu(%clientId, "Pick a team:", "PickTeam", true);
   if(!$Combat::noObserver) Client::addMenuItem(%clientId,"0Observer", -2);
   Client::addMenuItem(%clientId,"1Automatic", -1);
   if(!$Combat::evenTeams)
   {
    for(%i = 0;%i < $numValidTeams;%i++) Client::addMenuItem(%clientId, (%i+2) @ getTeamName(%i), %i);
   }
   return;
  }
 }
 else if(%opt == "changeskin" && $Combat::customSkin) // PORT: the setting was only tested by the menu
 {
  Client::buildMenu(%clientId,"Change Skin:","ChangeSkin",true);
  Client::addMenuItem(%clientId, "1Use Team Skin", "teamskin");
  Client::addMenuItem(%clientId, "2Use Custom Skin", "customskin");
  return;
 }
}

function processMenuVoteOptions(%clientId,%opt)
{
 if(%opt == "vcmission")
 {
      Admin::changeMissionMenu(%clientId,false);
      return;
 }
 else if(%opt == "vctruce")
   {
      %current = $Server::Truce;
	  if(!%current) %current = "disabled";
      Client::buildMenu(%clientId, "From "@%current@" to:", "VoteTruce", true);
	  Client::addMenuItem(%clientId, "11 Minute", 1);
      Client::addMenuItem(%clientId, "22 Minutes", 2);
      Client::addMenuItem(%clientId, "33 Minutes", 3);
      Client::addMenuItem(%clientId, "44 Minutes", 4);
      Client::addMenuItem(%clientId, "55 Minutes", 5);
      Client::addMenuItem(%clientId, "68 Minutes", 8);
      Client::addMenuItem(%clientId, "710 Minutes", 10);
      Client::addMenuItem(%clientId, "8Disable the truce", 0);
      return;
   }
 else if(%opt == "vcitems")
 {
      Client::buildMenu(%clientId, "Vote item mode", "VoteItemMode", true);

	  if($Combat::BaseItems) Client::addMenuItem(%clientId, "1Set to combat mode", 9);
      else Client::addMenuItem(%clientId, "1Set to simulated base", 1);

      if(!$Combat::BaseItems)
	  {
	   if(!$Combat::NoVehicles) Client::addMenuItem(%clientId, "2No Vehicles", 2);
	   else Client::addMenuItem(%clientId, "2Enable Vehicles", 2);

	   if(!$Combat::NoTurrets) Client::addMenuItem(%clientId, "3No Turrets", 3);
	   else Client::addMenuItem(%clientId, "3Enable Turrets", 3);

	   if(!$Combat::NoEmplacements) Client::addMenuItem(%clientId, "4No Emplacements", 4);
	   else Client::addMenuItem(%clientId, "4Enable Emplacements", 4);

	   if(!$Combat::NoStructures) Client::addMenuItem(%clientId, "5No Structures", 5);
	   else Client::addMenuItem(%clientId, "5Enable Structures", 5);

	   if(!$Combat::NoTeleports) Client::addMenuItem(%clientId, "6No Teleports", 6);
	   else Client::addMenuItem(%clientId, "6Enable Teleports", 6);

	   if(!$Combat::NoTraps) Client::addMenuItem(%clientId, "7No Traps", 7);
	   else Client::addMenuItem(%clientId, "7Enable Traps", 7);

	   if(!$Combat::NoDrones) Client::addMenuItem(%clientId, "8No Drones", 8);
	   else Client::addMenuItem(%clientId, "8Enable Drones", 8);
	  }
      return;
 }
 else if(%opt == "vcdamage")
 {
      Client::buildMenu(%clientId, "From "@$Combat::DamageMode@" to:", "VoteDamageMode", true);
      Client::addMenuItem(%clientId, "1Low Damage", "low");
      Client::addMenuItem(%clientId, "2Normal Damage", "normal");
      Client::addMenuItem(%clientId, "3High Damage", "high");
	  if($Combat::CustomDamage) Client::addMenuItem(%clientId, "4Custom Server Damage", "custom");
      return;
 }
}

function processMenuAdminOptions(%clientId,%opt)
{
   if(!%clientId.isAdmin) // PORT: no admin test
   {
      Game::menuRequest(%clientId);
      return;
   }
   if(%opt == "ctimelimit")
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
   else if(%opt == "cmission")
   {
      Admin::changeMissionMenu(%clientId,true);
      return;
   }
   else if(%opt == "struce")
   {
      Client::buildMenu(%clientId, "Declare intitial truce for:", "SetTruce", true);
      Client::addMenuItem(%clientId, "11 Minute", 1);
      Client::addMenuItem(%clientId, "22 Minutes", 2);
      Client::addMenuItem(%clientId, "33 Minutes", 3);
      Client::addMenuItem(%clientId, "44 Minutes", 4);
      Client::addMenuItem(%clientId, "55 Minutes", 5);
      Client::addMenuItem(%clientId, "68 Minutes", 8);
      Client::addMenuItem(%clientId, "710 Minutes", 10);
      Client::addMenuItem(%clientId, "8Disable the truce", 0);
      return;
   }

   else if(%opt == "sitems")
   {
      Client::buildMenu(%clientId, "Set server item mode", "SetItemMode", true);

	  if($Combat::BaseItems) Client::addMenuItem(%clientId, "1Set to combat mode", 9);
      else Client::addMenuItem(%clientId, "1Set to simulated base", 1);

      if(!$Combat::BaseItems)
	  {
	   if(!$Combat::NoVehicles) Client::addMenuItem(%clientId, "2No Vehicles", 2);
	   else Client::addMenuItem(%clientId, "2Enable Vehicles", 2);

	   if(!$Combat::NoTurrets) Client::addMenuItem(%clientId, "3No Turrets", 3);
	   else Client::addMenuItem(%clientId, "3Enable Turrets", 3);

	   if(!$Combat::NoEmplacements) Client::addMenuItem(%clientId, "4No Emplacements", 4);
	   else Client::addMenuItem(%clientId, "4Enable Emplacements", 4);

	   if(!$Combat::NoStructures) Client::addMenuItem(%clientId, "5No Structures", 5);
	   else Client::addMenuItem(%clientId, "5Enable Structures", 5);

	   if(!$Combat::NoTeleports) Client::addMenuItem(%clientId, "6No Teleports", 6);
	   else Client::addMenuItem(%clientId, "6Enable Teleports", 6);

	   if(!$Combat::NoTraps) Client::addMenuItem(%clientId, "7No Traps", 7);
	   else Client::addMenuItem(%clientId, "7Enable Traps", 7);

	   if(!$Combat::NoDrones) Client::addMenuItem(%clientId, "8No Drones", 8);
	   else Client::addMenuItem(%clientId, "8Enable Drones", 8);
	  }
      return;
   }

   else if(%opt == "sdamage")
   {
      Client::buildMenu(%clientId, "Set the server damage mode:", "SetDamageMode", true);
      Client::addMenuItem(%clientId, "1Low Damage", "low");
      Client::addMenuItem(%clientId, "2Normal Damage", "normal");
      Client::addMenuItem(%clientId, "3High Damage", "high");
	  if($Combat::CustomDamage) Client::addMenuItem(%clientId, "4Custom Server Damage", "custom");
      return;
   }

   else if(%opt == "rmission")
   {
      Client::buildMenu(%clientId, "Confirm Restart:", "RMissionConfirm", true);
      Client::addMenuItem(%clientId, "1Restart", "yes");
      Client::addMenuItem(%clientId, "2Do not Restart", "no");
      return;
   }

   else if(%opt == "reset")
   {
      Client::buildMenu(%clientId, "Confirm Reset:", "raffirm", true);
      Client::addMenuItem(%clientId, "1Reset", "yes");
      Client::addMenuItem(%clientId, "2Don't Reset", "no");
      return;
   }
}

//****************
function adminTeamKill(%playerId,%killerId)
{
	%client = GameBase::getOwnerClient(%killerId);
    if(%client.isSuperAdmin) return;

	$teamKills[%killerId]++;

	if($teamKills[%killerId] >= $Server::MaxTeamKills)
	{
	 if($traitorMode) setTraitor(%killerId);
	 else
	 {
		messageAll(0, Client::getName(%killerId) @ " has been kicked for Team Killing.\nConfirmed " @ $teamKills[%killerId] @ " Team Kills.");
        Net::kick(%killerId, "You have been kicked for team killing.");
		return;
	 }
    }
}

//*****************
function setTraitor(%traitorId)
{
 %client = GameBase::getOwnerClient(%traitorId);
 GameBase::setTeam(%traitorId,2);
 centerprint(%client,"<jc><f2>You have been exiled from your clan. You are now a TRAITOR.",10);
 echo(%client@" has become a TRAITOR");
}

//*****************
function processMenuSetTruce(%clientId,%options)
{
 if(!%clientId.isAdmin) return; // PORT: no admin test
 %options = floor(%options); // PORT: the minutes are the client's menu code
 if(%options < 0 || %options > 10) return;
 if(%options == 0)
 {
  $Server::Truce = false;
  $Server::ResetTruce = false;
  centerprintall("<jc><f2>"@Client::getName(%clientId) @ " has disabled the Truce.");
 }
 else
 {
  $Server::ResetTruce = true;
  $Server::NewTruce = %options;
  centerprintall("<jc><f2>"@Client::getName(%clientId) @ " has enabled the Truce for "@$Server::NewTruce@" minute(s) in the next match.");
 }
}

//*****************
function processMenuSetItemMode(%clientId,%options)
{
 if(!%clientId.isAdmin) return; // PORT: no admin test
 if(%options == 1)
 {
  $Combat::BaseItems = true;
  centerprintall("<jc><f2>"@Client::getName(%clientId)@" has set simulated base mode");
echo(%clientId@" has set simulated base mode");
 }
 else if(%options == 2)
 {
  if($Combat::NoVehicles) $Combat::NoVehicles = false;
  else $Combat::NoVehicles = true;
echo(%clientId@" set NoVehicles: "@$Combat::NoVehicles);
 }
 else if(%options == 3)
 {
  if($Combat::NoTurrets) $Combat::NoTurrets = false;
  else $Combat::NoTurrets = true;
echo(%clientId@" set NoTurrets: "@$Combat::NoTurrets);
 }
 else if(%options == 4)
 {
  if($Combat::NoEmplacements) $Combat::NoEmplacements = false;
  else $Combat::NoEmplacements = true;
echo(%clientId@" set NoEmplacements: "@$Combat::NoEmplacements);
 }
 else if(%options == 5)
 {
  if($Combat::NoStructures) $Combat::NoStructures = false;
  else $Combat::NoStructures = true;
echo(%clientId@" set NoStructures: "@$Combat::NoStructures);
 }
 else if(%options == 6)
 {
  if($Combat::NoTeleports) $Combat::NoTeleports = false;
  else $Combat::NoTeleports = true;
echo(%clientId@" set NoTeleports: "@$Combat::NoTeleports);
 }
 else if(%options == 7)
 {
  if($Combat::NoTraps) $Combat::NoTraps = false;
  else $Combat::NoTraps = true;
echo(%clientId@" set NoTraps: "@$Combat::NoTraps);
 }
 else if(%options == 8)
 {
  if($Combat::NoDrones) $Combat::NoDrones = false;
  else $Combat::NoDrones = true;
echo(%clientId@" set NoDrones: "@$Combat::NoDrones);
 }
 else if(%options == 9)
 {
  $Combat::BaseItems = false;
  $Combat::NoVehicles = false;
  $Combat::NoTurrets = false;
  $Combat::NoEmplacements = false;
  $Combat::NoStructures = false;
  $Combat::NoTeleports = false;
  $Combat::NoTraps = false;
  $Combat::NoDrones = false;
echo(%clientId@" reset menu item option to combat");
 }
 centerprint(%clientId,"<jc><f2>The match must restart before these changes will take effect.");
}

//*************
function processMenuSetDamageMode(%client,%options)
{
	if(!%client.isAdmin || (%options != "low" && %options != "normal" && %options != "high" && %options != "custom")) return; // PORT: no admin test, any text accepted
	$Combat::DamageMode = %options;
    centerprint(%client,"<jc><f2>The match must restart before these changes will take effect.");
}

//*************
function processMenuRMissionConfirm(%client, %options)
{
 if(!%client.isAdmin) return; // PORT: no admin test
 if(%options == "yes") Server::loadMission($missionName,true);
}

//*************
function processMenuChangeRGear(%client, %option)
{
 $Combat::RespawnGear[%client] = %option;
 centerprint(%client,"<jc><f0>You will now respawn with basic "@%option@" gear.",3);
}

//*******************
function processMenuVoteTruce(%clientId,%opt)
{
 %opt = floor(%opt); // PORT: the minutes are the client's menu code and went into the vote text shown to everyone
 if(%opt < 0 || %opt > 10) return;
 if(%opt == 0) %topic = "disable the truce";
 else %topic = "enable the truce for "@%opt@" minute(s)";
 Admin::startVote(%clientId,%topic,"changetruce",%opt);
}

//*******************
function processMenuVoteItemMode(%clientId,%opt)
{
 if(%opt == 1) %topic = "change to simulated base mode";
 else if(%opt == 2)
 {
  if($Combat::NoVehicles) %topic = "enable vehicles";
  else %topic = "disable vehicles";
 }
 else if(%opt == 3)
 {
  if($Combat::NoTurrets) %topic = "enable turrets";
  else %topic = "disable turrets";
 }
 else if(%opt == 4)
 {
  if($Combat::NoEmplacements) %topic = "enable emplacements";
  else %topic = "disable emplacements";
 }
 else if(%opt == 5)
 {
  if($Combat::NoStructures) %topic = "enable structures";
  else %topic = "disable structures";
 }
 else if(%opt == 6)
 {
  if($Combat::NoTeleports) %topic = "enable teleports";
  else %topic = "disable teleports";
 }
 else if(%opt == 7)
 {
  if($Combat::NoTraps) %topic = "enable traps";
  else %topic = "disable traps";
 }
 else if(%opt == 8)
 {
  if($Combat::NoDrones) %topic = "enable drones";
  else %topic = "disable drones";
 }
 else if(%opt == 9) %topic = "change to combat mode";
 if(%topic == "") return; // PORT: unknown code = a vote with no topic
 Admin::startVote(%clientId,%topic,"changeitems",%opt);
}

//*******************
function processMenuVoteDamageMode(%clientId,%opt)
{
 if(!$Combat::allowDamageModes || (%opt != "low" && %opt != "normal" && %opt != "high" && %opt != "custom")) return; // PORT: the setting and the four modes were only in the menu
 Admin::startVote(%clientId,"change damage mode to "@%opt,"changedamage",%opt);
}

//*******************
function processMenuChangeSkin(%clientId,%opt)
{
 if(%opt == "teamskin")
 {
  %clientId.customSkin = "";
  Client::setSkin(%clientId,$Server::teamSkin[Client::getTeam(%clientId)]);
 }
 else if(%opt == "customskin")
 {
  for(%i = 0;%i < $numValidTeams;%i++)
  {
   %teamSkin[%i] = $Server::teamSkin[%i];
   if(($Client::info[%clientId,0] == $Server::TeamSkin[%i]) && Client::getTeam(%clientId) != %i)
   {
    Client::setSkin(%clientId,$Server::teamSkin[Client::getTeam(%clientId)]);
    Client::sendMessage(%clientId,0,"You may not use an enemy teams skin");
    return;
   }
  }
  %clientId.customSkin = "true";
  Client::setSkin(%clientId,$Client::info[%clientId,0]);
 }
}

//*******************
function Vote::setTruce(%options)
{
 if(%options == 0)
 {
  $Server::Truce = false;
  $Server::ResetTruce = false;
  centerprintall("<jc><f2>The truce has been disable by consensus.");
 }
 else
 {
  $Server::ResetTruce = true;
  $Server::NewTruce = %options;
  centerprintall("<jc><f2>the truce has been enable by vote for "@$Server::NewTruce@" minute(s) in the next match.");
 }
}

//*******************
function Vote::setItemMode(%options)
{
 if(%options == 1)
 {
  $Combat::BaseItems = true;
  centerprintall("<jc><f2>Item mode has been voted to simulated base for the next match.");
 }
 else if(%options == 2)
 {
  if($Combat::NoVehicles) $Combat::NoVehicles = false;
  else $Combat::NoVehicles = true;
  centerprintall("<jc><f2>NoVehicles has been voted to "@$Combat::NoVehicles@" for the next match");
 }
 else if(%options == 3)
 {
  if($Combat::NoTurrets) $Combat::NoTurrets = false;
  else $Combat::NoTurrets = true;
  centerprintall("<jc><f2>NoTurrets has been voted to "@$Combat::NoTurrets@" for the next match");
 }
 else if(%options == 4)
 {
  if($Combat::NoEmplacements) $Combat::NoEmplacements = false;
  else $Combat::NoEmplacements = true;
  centerprintall("<jc><f2>NoEmplacements has been voted to "@$Combat::NoEmplacements@" for the next match");
 }
 else if(%options == 5)
 {
  if($Combat::NoStructures) $Combat::NoStructures = false;
  else $Combat::NoStructures = true;
  centerprintall("<jc><f2>NoStrcutures has been voted to "@$Combat::NoStructures@" for the next match");
 }
 else if(%options == 6)
 {
  if($Combat::NoTeleports) $Combat::NoTeleports = false;
  else $Combat::NoTeleports = true;
  centerprintall("<jc><f2>NoTeleports has been voted to "@$Combat::NoTeleports@" for the next match");
 }
 else if(%options == 7)
 {
  if($Combat::NoTraps) $Combat::NoTraps = false;
  else $Combat::NoTraps = true;
  centerprintall("<jc><f2>NoTraps has been voted to "@$Combat::NoTraps@" for the next match");
 }
 else if(%options == 8)
 {
  if($Combat::NoDrones) $Combat::NoDrones = false;
  else $Combat::NoDrones = true;
  centerprintall("<jc><f2>NoDrones has been voted to "@$Combat::NoDrones@" for the next match");
 }
 else if(%options == 9)
 {
  $Combat::BaseItems = false;
  $Combat::NoVehicles = false;
  $Combat::NoTurrets = false;
  $Combat::NoEmplacements = false;
  $Combat::NoStructures = false;
  $Combat::NoTeleports = false;
  $Combat::NoTraps = false;
  $Combat::NoDrones = false;
  centerprintall("<jc><f2>Item mode has been voted to COMBAT for the next match.");
 }
}

//*******************
function Vote::setDamageMode(%options)
{
	$Combat::DamageMode = %options;
    centerprintall("<jc><f2>The damage mode has been voted to "@%options@" for the next match");
}