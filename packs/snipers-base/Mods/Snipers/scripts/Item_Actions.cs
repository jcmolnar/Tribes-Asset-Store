//------------------------------------------------------------------------------
//
//	ITEM ACTIONS
//
//------------------------------------------------------------------------------
//-------------------------------------------------
//	CLOAKING
//-------------------------------------------------
function startCloak(%clientId, %player) 
{ // Taken straight from Renegades
  %armor = Player::getArmor(%player);
  Client::sendMessage(%clientId,0,"Cloaking On");
  GameBase::playSound(%player,ForceFieldOpen,0);
  GameBase::startFadeout(%player);
  %rate = Player::getSensorSupression(%player) + 3;
  Player::setSensorSupression(%player,%rate);
  if($cloakTime[%clientId] == 0) 
  {
    $cloakTime[%clientId] = 30;
    checkPlayerCloak(%clientId, %player);
  }
  else $cloakTime[%clientId] = 30;
}

function checkPlayerCloak(%clientId, %player) 
{
  %armor = Player::getArmor(%player);
  if (!Player::isDead(%player) && $cloakTime[%clientId] > 0) 
  {
    $cloakTime[%clientId] -= 2;  
    schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
  }
  else 
  {
    $cloakTime[%clientId] = 0;
    Client::sendMessage(%clientId,0,"Cloaking Off");
    GameBase::playSound(%player,ForceFieldOpen,0);
    GameBase::startFadein(%player);
    %rate = Player::getSensorSupression(%player) - 5;
    Player::setSensorSupression(%player,0);
  }
}

//--------------------------------------------------------------
//	PLAYER DRAIN
//--------------------------------------------------------------
function Drain(%damagedPlayer, %damagingPlayer)
{
  if (GameBase::getTeam(%targetPlayer) == GameBase::getTeam(%sourcePlayer) ||
      Player::isDead(%damagingPlayer))
    return;

  GameBase::applyDamage(%damagedPlayer,$EnergyDamageType,0.2,GameBase::getPosition(%damagedPlayer),"0 0 0","0 0 0",%damagingPlayer);
  GameBase::setEnergy(%damagedPlayer, GameBase::getEnergy(%damagedPlayer) - 60);
  %lev = GameBase::getDamageLevel(%damagingPlayer);
  if (%lev <0.2)
    GameBase::setDamageLevel(%damagingPlayer, 0);
  else
    GameBase::setDamageLevel(%damagingPlayer,%lev-0.2);
  GameBase::setEnergy(%damagingPlayer, GameBase::getEnergy(%damagingPlayer) + 120);
  GameBase::playSound(%damagedPlayer,ForceFieldOpen,0);
  Client::sendMessage(Player::getClient(%damagingPlayer), 1, "You drain " @ Client::getName(Player::getClient(%damagedPlayer)) @ "'s life");
}

//---------------------------------------------------------------
//	PLAYER STARTSHIELD
//---------------------------------------------------------------
function startShield(%clientId, %player) 
{ // Taken straight from Renegades
  Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
  GameBase::playSound(%player,ForceFieldOpen,0);
  %player.shieldStrength = 0.006;
  if($shieldTime[%clientId] == 0) 
  {
    $shieldTime[%clientId] = 20;
    checkPlayerShield(%clientId, %player);
  }
  else $shieldTime[%clientId] = 20;
}

function checkPlayerShield(%clientId, %player) 
{ // Taken straight from Renegades
  if ($shieldTime[%clientId] > 0  && !Player::isDead(%player)) 
  {
    $shieldTime[%clientId] -= 2;
    schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
  }
  else 
  {
    $shieldTime[%clientId] = 0;
    Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
    %player.shieldStrength = 0;
    GameBase::playSound(%player,ForceFieldOpen,0);
  }
}

//---------------------------------------------------------------
//	PLAYER STEAL
//---------------------------------------------------------------
function Steal(%targetPlayer, %sourcePlayer)
 // Steal from targetPlayer and give to sourcePlayer
{ // Taken straight from Renegades
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 	if (%armor == "parmor")
	return;

  if (GameBase::getTeam(%targetPlayer) == GameBase::getTeam(%sourcePlayer) ||
      Player::isDead(%sourcePlayer))
    return;

  Player::setDamageFlash(%targetPlayer,1.95);
  %sound = false;
  %max = getNumItems();
  for (%i = 0; %i < %max; %i = %i + 1)
  {
    %count = Player::getItemCount(%targetPlayer,%i);
    if (%count)
    {
      %delta = Item::giveItem(%sourcePlayer,getItemData(%i),%count);
      if (%delta > 0)
      {
        Player::decItemCount(%targetPlayer,%i,%delta);
        %sound = true;
      }
    }
  }
  if (%sound)
    playSound(SoundPickupItem,GameBase::getPosition(%sourcePlayer));
}

//-----------------------------------------------------------------
//	PLAYER REPULSE
//-----------------------------------------------------------------
$RepulsePower = 350;

function Repulse(%player, %item)
{ // Alazane
    %set = newObject("set",SimSet);
    %ppos = GameBase::getPosition(%player);
    %num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 50, 50, 50,0);
    for (%i=0; %i<%num; %i++)
    {
      %oply = Group::getObject(%set,%i);
      if (%oply != %player)
      { 
        %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%oply), %ppos));
        %vec = (getWord(%vec, 0) * $RepulsePower) @ " " @
               (getWord(%vec, 1) * $RepulsePower) @ " " @
               (getWord(%vec, 2) * $RepulsePower);              
        Player::applyImpulse(%oply, %vec);
      }
    }
    deleteObject(%set);
    Client::sendMessage(Player::getClient(%player),0, "You use a Repulsion Beacon");
    GameBase::playSound(%player, SoundFireMortar, 0);
    Player::decItemCount(%player,%item);
}

//------------------------------------------------------------------
//	PLAYER START POISON
//------------------------------------------------------------------
function startPoison(%clientId, %player) 
{ // Taken straight from Renegades
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 	if (%armor == "parmor")
	return;

  Client::sendMessage(%clientId,1,"You are poisoned!");
  if($poisonTime[%clientId] == 0) 
  {
    Player::setDamageFlash(%player,0.75);
    $poisonTime[%clientId] = 30;
    checkPlayerPoison(%clientId, %player);
  }
  else $poisonTime[%clientId] = 30;
}

function checkPlayerPoison(%clientId, %player) 
{ // Taken straight from Renegades
  if($poisonTime[%clientId] > 0) 
  {
    $poisonTime[%clientId] -= 2;
    %drrate = GameBase::getDamageLevel(%player) + 0.05;
    if (!Player::isDead(%player)) 
    {
      GameBase::setDamageLevel(%player, %drrate);
      Player::setDamageFlash(%player,0.75);
      if (Player::isDead(%player)) 
      {
        messageall(0, Client::getName(%clientId) @ " died from a strange disease.");
        %clientId.scoreDeaths++;
        %clientId.score--;
        Game::refreshClientScore(%clientId);
        $poisonTime[%clientId] = 0;
      }
      else
        schedule("checkPlayerPoison(" @ %clientId @ ", " @ %player @ ");", 5, %player);
    }
    else 
      $poisonTime[%clientId] = 0;
  }
  else 
    Client::sendMessage(%clientId,1,"The effects of the poison wear off.");
}

function Armor::onPoison(%client, %player)
{
  startPoison(%client, %player);
}

//------------------------------------------------------------------
//	PLAYER START BURN
//------------------------------------------------------------------
function startBurn(%clientId, %player) 
{ // Taken straight from Renegades
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 	if (%armor == "parmor")
	return;

  Client::sendMessage(%clientId,1,"You caught on fire!");
  if($burnTime[%clientId] == 0) 
  {
    Player::setDamageFlash(%player,0.75);
    $burnTime[%clientId] = 10;
    checkPlayerBurn(%clientId, %player);
  }
  else $burnTime[%clientId] = 10;
}

function checkPlayerBurn(%clientId, %player) 
{ // Taken straight from Renegades
  if($burnTime[%clientId] > 0) 
  {
    $burnTime[%clientId] -= 2;
    %drrate = GameBase::getDamageLevel(%player) + 0.05;
    if (!Player::isDead(%player)) 
    {
      GameBase::setDamageLevel(%player, %drrate);
      Player::setDamageFlash(%player,0.75);
      if (Player::isDead(%player)) 
      {
        messageall(0, Client::getName(%clientId) @ " was incinerated.");
        %clientId.scoreDeaths++;
        %clientId.score--;
        Game::refreshClientScore(%clientId);
        $burnTime[%clientId] = 0;
      }
      else
        schedule("checkPlayerBurn(" @ %clientId @ ", " @ %player @ ");", 2, %player);
    }
    else 
      $burnTime[%clientId] = 0;
  }
  else 
    Client::sendMessage(%clientId,1,"You stop burning.");
}

function Armor::onBurn(%client, %player)
{
//  %rnd = floor(getRandom() * 10);
//  if (%rnd > 5)
//    startBurn(%client, %player);
}

//------------------------------------------------------------------
//	PLAYER ON REPAIR KIT
//------------------------------------------------------------------
function Armor::onRepairKit(%player)
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 	if (%armor == "parmor")
	return;

	// Heal poison & burn with repair kit
	$poisonTime[Player::getClient(%player)] = 0;
	$burnTime[Player::getClient(%player)] = 0;
}

//------------------------------------------------------------------
//	PLAYER ACTIONS
//------------------------------------------------------------------
function Armor::onPlayerContact(%targetPlayer, %sourcePlayer)
{
  //
}

function Armor::ThrowGrenade(%player, %obj)
{
  addToSet("MissionCleanup", %obj);
  %client = Player::getClient(%player);
  GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
  %player.throwTime = getSimTime() + 0.5;
  GameBase::setTeam (%obj,GameBase::getTeam (%client));
}

function Armor::SpeedBooster(%player, %item, %power)
{
  %vec = Item::getVelocity(%player);
  if (%vec == "0 0 0") %vec = "0 10 0"; // Could use line of site
  %vec = Vector::Normalize(%vec);
  %vec = GetWord(%vec, 0) * %power @ " " @
         GetWord(%vec, 1) * %power @ " " @
         GetWord(%vec, 2) * %power;
  Player::applyImpulse(%player, %vec);
  GameBase::playSound(%this, SoundFireMortar, 0);
  Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster Beacon.");
  Player::decItemCount(%player,%item);
}