function startCloak(%clientId) 
{
	// Taken straight from Renegades
	// fixed to remove armor change cheat -plasmatic
	
	%player = Client::getOwnedObject(%clientId);
	Client::sendMessage(%clientId,0,"Initiating cloak");
	GameBase::playSound(%player,ForceFieldOpen,0);
	GameBase::startFadeout(%player);
	%rate = Player::getSensorSupression(%player) + 3;
	Player::setSensorSupression(%player,%rate);
	if($cloakTime[%clientId] == 0) 
	{	$cloakTime[%clientId] = 20;
		checkPlayerCloak(%clientId);
	}
	else $cloakTime[%clientId] = 20;
}

function checkPlayerCloak(%clientId, %player) 
{
	%player = Client::getOwnedObject(%clientId);
	if(!Player::isDead(%player) && $cloakTime[%clientId] > 0) 
	{
		$cloakTime[%clientId] -= 2;
		schedule("checkPlayerCloak(" @ %clientId @ ");",2,%player);
	}
	else 
	{
		$cloakTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Your cloak has worn off");
		GameBase::playSound(%player,ForceFieldOpen,0);
		GameBase::startFadein(%player);
		%rate = Player::getSensorSupression(%player) - 5;
		Player::setSensorSupression(%player,0);
	}
}

function Drain(%damagedPlayer, %damagingPlayer)
{
	if(GameBase::getTeam(%targetPlayer) == GameBase::getTeam(%sourcePlayer) || Player::isDead(%damagingPlayer))
		return;
	GameBase::applyDamage(%damagedPlayer,$EnergyDamageType,0.2,GameBase::getPosition(%damagedPlayer),"0 0 0","0 0 0",%damagingPlayer);
	GameBase::setEnergy(%damagedPlayer, GameBase::getEnergy(%damagedPlayer) - 80);
	%lev = GameBase::getDamageLevel(%damagingPlayer);
	if(%lev <0.2)
		GameBase::setDamageLevel(%damagingPlayer, 0);
	else
		GameBase::setDamageLevel(%damagingPlayer,%lev-0.2);
	GameBase::setEnergy(%damagingPlayer, GameBase::getEnergy(%damagingPlayer) + 120);
	GameBase::playSound(%damagedPlayer,ForceFieldOpen,0);
	Client::sendMessage(Player::getClient(%damagingPlayer), 1, "You suck out " @ Client::getName(Player::getClient(%damagedPlayer)) @ "'s life force");
}

function startShield(%clientId) 
{
	// Taken straight from Renegades
	// fixed to remove armor change cheat -plasmatic
	
	%player = Client::getOwnedObject(%clientId);	
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

function checkPlayerShield(%clientId) 
{
	// Taken straight from Renegades
	// fixed by to remove armor change cheat -plasmatic
	
	%player = Client::getOwnedObject(%clientId);
	if($shieldTime[%clientId] > 0 && !Player::isDead(%player)) 
	{
		$shieldTime[%clientId] -= 2;
		schedule("checkPlayerShield(" @ %clientId @ ");",2,%player);
	}
	else 
	{
		$shieldTime[%clientId] = 0;
		Client::sendMessage(%clientId,0,"Emergency Force Shields Exausted");
		%player.shieldStrength = 0;
		GameBase::playSound(%player,ForceFieldOpen,0);
	}
}

$AssassinateChance = 25;
// function fixed so team members dont attemp to assinate each other -Plasmatic
function Assassinate(%targetPlayer, %sourcePlayer)
{
	%Tteam = GameBase::getTeam(%targetPlayer);
	%Steam = GameBase::getTeam(%sourcePlayer);
	%SClient = Player::getClient(%sourcePlayer);
	if((%Tteam != %Steam && %SClient.isSpy) || (%Tteam == %Steam && !%SClient.isSpy) || Player::isDead(%targetPlayer) || Player::isDead(%sourcePlayer))
		return;
	Client::sendMessage(%SClient, 1, "You attempt to assassinate your target");
	if(Player::getArmor(%targetPlayer) != Player::getArmor(%sourcePlayer))
	{
		if(floor(getrandom() * 100) <= $AssassinateChance)
		{
			GameBase::applyDamage(%targetPlayer,$AssassinDamageType,14.2,GameBase::getPosition(%targetPlayer),"0 0 0","0 0 0",%SClient);
			Client::sendMessage(Player::getClient(%targetPlayer), 1, "You were ASSASSINATED");
			Client::sendMessage(%SClient, 1, "You ASSASSINATED your target");
		}
		else
		{
			Client::sendMessage(%SClient, 1, "You failed to assassinate your target");
		}
	}
	else			
	{
		Client::sendMessage(%SClient, 1, "You cannot assassinate another assassin");
	}
}

$RepulsePower = 350;

function Repulse(%player, %item)
{
	// Alazane
	%set = newObject("set",SimSet);
	%ppos = GameBase::getPosition(%player);
	%num = containerBoxFillSet(%set, $SimPlayerObjectType, %ppos, 50, 50, 50,0);
	for(%i=0; %i<%num; %i++)
	{
		%oply = Group::getObject(%set,%i);
		if(%oply != %player)
		{
			%vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%oply), %ppos));
			%vec = (getWord(%vec, 0) * $RepulsePower) @ " " @ (getWord(%vec, 1) * $RepulsePower) @ " " @ (getWord(%vec, 2) * $RepulsePower);
			Player::applyImpulse(%oply, %vec);
		}
	}
	deleteObject(%set);
	Client::sendMessage(Player::getClient(%player),0, "You use a Repulsion Beacon");
	GameBase::playSound(%player, SoundFireMortar, 0);
	Player::decItemCount(%player,%item);
}

function startPoison(%clientId, %player) 
{
	// Taken straight from Renegades
	//message changed to nanites, instead of 

	Client::sendMessage(%clientId,1,"Nanites are chewing away at you!");
	if($poisonTime[%clientId] == 0) 
	{
		Player::setDamageFlash(%player,0.75);
		$poisonTime[%clientId] = 30;
		checkPlayerPoison(%clientId, %player);
	}
	else
		$poisonTime[%clientId] = 30;
}

function checkPlayerPoison(%clientId, %player) 
{
	// Taken straight from Renegades
	if($poisonTime[%clientId] > 0) 
	{
		$poisonTime[%clientId] -= 2;
		%drrate = GameBase::getDamageLevel(%player) + 0.05;
		if(!Player::isDead(%player)) 
		{
		if(%player.invulnerable || $NoPlayerDamage || %player.frozen || $jailed[%player])
		{
			// no damage, just play a shield. -plasmatic
			%thisPos = getBoxCenter(%this);
			%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
			GameBase::activateShield(%this,%vec,%offsetZ);
			return;
		}
		else GameBase::setDamageLevel(%player, %drrate);
			Player::setDamageFlash(%player,0.25);
			if(Player::isDead(%player)) 
			{
				messageall(0, Client::getName(%clientId) @ " was killed by numerous nanites.");
				%clientId.scoreDeaths++;
				%clientId.score--;
				Game::refreshClientScore(%clientId);
				$poisonTime[%clientId] = 0;
			}
			else
				schedule("checkPlayerPoison(" @ %clientId @ ", " @ %player @ ");", 1.5, %player);
		}
		else 
			$poisonTime[%clientId] = 0;
	}
	else 
		Client::sendMessage(%clientId,1,"The nanites have worn themselves out.");
}

DamageSkinData armorDamageSkins 
{
	bmpName[0] = "dskin1_armor";
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
{
	startPoison(%client, %player);
}

function Armor::onBurn(%client, %player)
{	
	
	if (!%player.onfire) 
	{
		Plasmafire(%player);
		Client::sendMessage(%client,0, "Your energy system is on fire!");	
	}
	%player.onfire = 200;
}


function Plasmafire(%player)
{
	//plasmatic
	if(Player::isDead(%player))	return;
	%player.onfire = %player.onfire -2;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onfire > 70 )
		Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel);

	if(player::isjetting(%player))
		Projectile::spawnProjectile("JetSmoke", %trans, %player, %Vel);
	if(%player.onfire)
		schedule("PlasmaFire("@%player@");",0.2);
	
}

function Armor::onShock(%client, %player)
{	
	
	if (!%player.Shocked) 
	{
		//Player::unmountItem(%player,$WeaponSlot);
		Shockfire(%player);
		Client::sendMessage(%client,0, "You have been hit with EMP!");	
	}
	%player.Shocked = %player.Shocked * 0.5 + 20;
//usually visual lasts longer than actual effect if there is one emp, shorter if there is more
	GameBase::setEnergy(%player,0);
	%player.emptime = %player.emptime + 18;  //emptime = 0.1667 sec
	if(!%player.emping) ApplyEMP(%player);
	%player.emping = true;
}

function ApplyEMP(%player)
{
if(%player.emptime > 0)
{
	%player.emptime--;
	GameBase::setEnergy(%player, GameBase::getEnergy(%player) - 1.35);
	schedule("ApplyEMP("@%player@");", 0.1667);
}
else %player.emping = false;
}

function Shockfire(%player)
{
	//plasmatic
	if(Player::isDead(%player))	return;
	%player.Shocked = %player.Shocked -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%player),"0 0 0.5");
	%vel = Item::getVelocity(%player);
	if(%player.Shocked > 10 )
		Projectile::spawnProjectile("ShockedDamage", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.Shocked)
		schedule("Shockfire("@%player@");",0.5);	
}

function Armor::onPlayerContact(%targetPlayer, %sourcePlayer)
{
}

function Armor::ThrowGrenade(%player, %obj)
{
	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
	GameBase::setTeam (%obj,GameBase::getTeam(%client));
}

function Armor::onRepairKit(%player)
{
	 // Heal poison with repair kit
	$poisonTime[Player::getClient(%player)] = 0;
	if(GameBase::getLOSInfo(%player,5)) 
	{
		%obj = getObjectType($los::object);
		%name = GameBase::getDataName(%obj);
		if((%name.className == Station))
			GameBase::repairDamage(%obj,0.27);
	}
}

function Armor::SpeedBooster(%player, %item, %power)
{
	%vec = Item::getVelocity(%player);
	if(%vec == "0 0 0")
	{
	//fixed for stationary player, this is called if player is at rest -plasmatic
	//fixed to send em where they look... not just forward..
		%trans = GameBase::getMuzzleTransform(%player);
		%smack = %power/25;
		%rot=GameBase::getRotation(%player);
		%len = 30;
		%tr= getWord(%trans,5);
		if(%tr <=0 )%tr -=%tr;
		%up = %tr+0.15;
		%out = 1-%tr;
		%vec = Vector::getFromRot(%rot,%len*%out*%smack,%len*%up*%smack);
		}

	else{	
	%vec = Vector::Normalize(%vec);
	%vec = GetWord(%vec, 0) * %power @ " " @ GetWord(%vec, 1) * %power @ " " @ GetWord(%vec, 2) * %power;
	}
	Player::applyImpulse(%player, %vec);
	GameBase::playSound(%player, SoundFireMortar, 0);
	Client::sendMessage(Player::getClient(%player),0, "You use a booster.");
	if(!$build)Player::decItemCount(%player,%item);
}

