//----------------------------------------------------------------------------
// Data in Seperate files
//----------------------------------------------------------------------------

function startCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	Client::sendMessage(%clientId,0,"You Swallow your Invisibility Pill");
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);
	if($cloakTime[%clientId] == 0)
	{	$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId, %player);
	}
	else $cloakTime[%clientId] = 20;
}

function checkPlayerCloak(%clientId, %player)
{
	%armor = Player::getArmor(%player);
	if(!Player::isDead(%player) && $cloakTime[%clientId] > 0)
	{
		$cloakTime[%clientId] -= 2;
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else
	{
		$cloakTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Your Invisibilty Wears Off");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}
}
function startShield(%clientId, %player)
{
	Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0);
	%player.shieldStrength = 0.006;
	if($shieldTime[%clientId] == 0)
	{
		$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else
		$shieldTime[%clientId] = 20;
}

function checkPlayerShield(%clientId, %player)
{
	if($shieldTime[%clientId] > 0 && !Player::isDead(%player))
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
function Armor::SpeedBooster(%player, %item, %power)
{
	%vec = Item::getVelocity(%player);
	if(%vec == "0 0 0"){
	%rot=GameBase::getRotation(%player);
	%vec = Vector::getFromRot(%rot,%power,%power/10);
		}
	else{
	%vec = Vector::Normalize(%vec);
	%vec = GetWord(%vec, 0) * %power @ " " @ GetWord(%vec, 1) * %power @ " " @ GetWord(%vec, 2) * %power;
	}
	Player::applyImpulse(%player, %vec);
	GameBase::playSound(%player, SoundFireMortar, 0);
	Client::sendMessage(Player::getClient(%player),0, "You Fire your Retro jets.");
	if(!$build)Player::decItemCount(%player,%item);
}
function Armor::ThrowGrenade(%player, %obj)
{
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	GameBase::setTeam (%obj,GameBase::getTeam (%client));
}