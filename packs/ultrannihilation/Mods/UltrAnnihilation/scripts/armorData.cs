
function startCloak(%clientId, %player) 
{
	// Taken straight from Renegades
	%armor = Player::getArmor(%player);
	Client::sendMessage(%clientId,0,"You Cast Invisibility");
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
{	%armor = Player::getArmor(%player);
	if (!Player::isDead(%player) && $cloakTime[%clientId] > 0) 
	{	$cloakTime[%clientId] -= 2;
		schedule("checkPlayerCloak(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else 
	{	$cloakTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Your Invisibilty Spell Wears Off");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}
}

function divineintervention(%clientId, %player) 
{	Client::sendMessage(%clientId,0,"You summon the powers of the Gods!");
	GameBase::repairDamage(%player,0.5);
	GameBase::playSound(%player,ForceFieldOpen,0);
	%player.shieldStrength = 0.200;
	%rate = Player::getSensorSupression(%player) + 5;
	Player::setSensorSupression(%player,%rate);
	if($shieldTime[%clientId] == 0) 
	{	$shieldTime[%clientId] = 5;
		checkdivineintervention(%clientId, %player);
	}
	else $shieldTime[%clientId] = 5;
}

function checkdivineintervention(%clientId, %player) 
{	if ($shieldTime[%clientId] > 0 && !Player::isDead(%player)) 
	{	$shieldTime[%clientId] -= 2;
		schedule("checkdivineintervention(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else 
	{	$shieldTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Your powers wear off.");
		%player.shieldStrength = 0;
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,%rate);
		GameBase::playSound(%player,ForceFieldOpen,0);
	}
}

function Drain(%damagedPlayer, %damagingPlayer)
{	if (GameBase::getTeam(%targetPlayer) == GameBase::getTeam(%sourcePlayer) || Player::isDead(%damagingPlayer))
		return;
	GameBase::applyDamage(%damagedPlayer,$EnergyDamageType,0.2,GameBase::getPosition(%damagedPlayer),"0 0 0","0 0 0",%damagingPlayer);
	GameBase::setEnergy(%damagedPlayer, GameBase::getEnergy(%damagedPlayer) - 80);
	%lev = GameBase::getDamageLevel(%damagingPlayer);
	if (%lev <0.2)
		GameBase::setDamageLevel(%damagingPlayer, 0);
	else
		GameBase::setDamageLevel(%damagingPlayer,%lev-0.2);
	GameBase::setEnergy(%damagingPlayer, GameBase::getEnergy(%damagingPlayer) + 120);
	GameBase::playSound(%damagedPlayer,ForceFieldOpen,0);
	Client::sendMessage(Player::getClient(%damagingPlayer), 1, "You suck out " @ Client::getName(Player::getClient(%damagedPlayer)) @ "'s life force");
}

function startShield(%clientId, %player) 
{	// Taken straight from Renegades
	Client::sendMessage(%clientId,0,"Emergency Force Shields Activated");
	GameBase::playSound(%player,ForceFieldOpen,0);
	%player.shieldStrength = 0.006;
	if($shieldTime[%clientId] == 0) 
	{	$shieldTime[%clientId] = 20;
		checkPlayerShield(%clientId, %player);
	}
	else $shieldTime[%clientId] = 20;
}

function checkPlayerShield(%clientId, %player) 
{	// Taken straight from Renegades
	if ($shieldTime[%clientId] > 0 && !Player::isDead(%player)) 
	{	$shieldTime[%clientId] -= 2;
		schedule("checkPlayerShield(" @ %clientId @ ", " @ %player @ ");",2,%player);
	}
	else 
	{	$shieldTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);
	}
}

function Steal(%targetPlayer, %sourcePlayer)
{	// Steal from targetPlayer and give to sourcePlayer
	// Taken straight from Renegades
	if (GameBase::getTeam(%targetPlayer) == GameBase::getTeam(%sourcePlayer) || Player::isDead(%sourcePlayer))
		return;
	Player::setDamageFlash(%targetPlayer,1.95);
	%sound = false;
	%max = getNumItems();
	for (%i = 0; %i < %max; %i = %i + 1)
	{	%count = Player::getItemCount(%targetPlayer,%i);
		if (%count)
		{	%delta = Item::giveItem(%sourcePlayer,getItemData(%i),%count);
			if (%delta > 0)
			{	Player::decItemCount(%targetPlayer,%i,%delta);
				%sound = true;
			}
		}
	}
	if (%sound)
		playSound(SoundPickupItem,GameBase::getPosition(%sourcePlayer));
}

$AssassinateChance = 25;

function Assassinate(%targetPlayer, %sourcePlayer)
{	if (GameBase::getTeam(%targetPlayer) == GameBase::getTeam(%sourcePlayer) || Player::isDead(%sourcePlayer))
		return;
	Client::sendMessage(Player::getClient(%sourcePlayer), 1, "You attempt to assassinate your target");
	if (Player::getArmor(%targetPlayer) != Player::getArmor(%sourcePlayer))
	{	if(floor(getrandom() * 100) <= $AssassinateChance)
		{
			GameBase::applyDamage(%targetPlayer,$AssassinDamageType,14.2,GameBase::getPosition(%targetPlayer),"0 0 0","0 0 0",Player::getClient(%sourcePlayer)); 
			Client::sendMessage(Player::getClient(%targetPlayer), 1, "You were ASSASSINATED");
			Client::sendMessage(Player::getClient(%sourcePlayer), 1, "You ASSASSINATED your target");
		}
		else
		{	Client::sendMessage(Player::getClient(%sourcePlayer), 1, "You failed to assassinate your target");
		}
	}
	else			
	{	Client::sendMessage(Player::getClient(%sourcePlayer), 1, "You cannot assassinate another assassin");
	}
}

$RepulsePower = 350;

function Repulse(%player, %item)
{	// Alazane
	%set = newObject("set",SimSet);
	%ppos = GameBase::getPosition(%player);
	%num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 50, 50, 50,0);
	for (%i=0; %i<%num; %i++)
	{	%oply = Group::getObject(%set,%i);
		if (%oply != %player)
		{	%vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%oply), %ppos));
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

function startPoison(%clientId, %player) 
{	// Taken straight from Renegades
	Client::sendMessage(%clientId,1,"You've been poisoned!");
	if($poisonTime[%clientId] == 0) 
	{	Player::setDamageFlash(%player,0.15);
		$poisonTime[%clientId] = 30;
		checkPlayerPoison(%clientId, %player);
	}
	else $poisonTime[%clientId] = 30;
}

function checkPlayerPoison(%clientId, %player) 
{	// Taken straight from Renegades
	if($poisonTime[%clientId] > 0) 
	{	$poisonTime[%clientId] -= 2;
		%drrate = GameBase::getDamageLevel(%player) + 0.05;
		if (!Player::isDead(%player)) 
		{	GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player,0.75);
			if (Player::isDead(%player)) 
			{	messageall(0, Client::getName(%clientId) @ " died.");
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

function startBurn(%clientId, %player) 
{	// Taken straight from Renegades
	Client::sendMessage(%clientId,1,"You caught on fire!");
	if($burnTime[%clientId] == 0) 
	{		Player::setDamageFlash(%player,0.75);
		$burnTime[%clientId] = 10;
		checkPlayerBurn(%clientId, %player);
	}
	else $burnTime[%clientId] = 10;
}

function checkPlayerBurn(%clientId, %player) 
{ // Taken straight from Renegades
	if($burnTime[%clientId] > 0) 
	{	$burnTime[%clientId] -= 2;
		%drrate = GameBase::getDamageLevel(%player) + 0.05;
		if (!Player::isDead(%player)) 
		{	GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player,0.75);
			if (Player::isDead(%player)) 
			{	messageall(0, Client::getName(%clientId) @ " went to hell.");
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

DamageSkinData armorDamageSkins 
{	bmpName[0] = "dskin1_armor";
	bmpName[1] = "dskin2_armor";
	bmpName[2] = "dskin3_armor";
	bmpName[3] = "dskin4_armor";
	bmpName[4] = "dskin5_armor";
	bmpName[5] = "dskin6_armor";
	bmpName[6] = "dskin7_armor";
	bmpName[7] = "dskin8_armor";
	bmpName[8] = "dskin9_armor";
	bmpName[9] = "dskin10_armor";
};

function Armor::onPoison(%client, %player)
{	startPoison(%client, %player);
}

function Armor::onBurn(%client, %player)
{	//	%rnd = floor(getRandom() * 10);
	//	if (%rnd > 5)
	//	startBurn(%client, %player);
}

function Armor::onPlayerContact(%targetPlayer, %sourcePlayer)
{
}

function Armor::ThrowGrenade(%player, %obj)
{	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	GameBase::setTeam (%obj,GameBase::getTeam (%client));
}

function Armor::onRepairKit(%player)
{	 // Heal poison with repair kit
	$poisonTime[Player::getClient(%player)] = 0;
	if (GameBase::getLOSInfo(%player,5)) 
	{	%obj = getObjectType($los::object);
		%name = GameBase::getDataName(%obj);
		if ((%name.className == Station))
			GameBase::repairDamage(%obj,0.27); 
	}
}

function Armor::SpeedBooster(%player, %item, %power)
{
	%vec = Item::getVelocity(%player);
	if (%vec == "0 0 0")
		%vec = "0 10 0"; // Could use line of site
	%vec = Vector::Normalize(%vec);
	%vec = GetWord(%vec, 0) * %power @ " " @ GetWord(%vec, 1) * %power @ " " @ GetWord(%vec, 2) * %power;
	Player::applyImpulse(%player, %vec);
	GameBase::playSound(%this, SoundFireMortar, 0);
	Client::sendMessage(Player::getClient(%player),0, "You spank yourself.");
	Player::decItemCount(%player,%item);
}

