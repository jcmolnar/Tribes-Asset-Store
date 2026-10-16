
function Armor::onBio(%client, %player)
{	
	
	if (!%player.onToxic) 
	{
		ToxicShock(%player);	
	}
	%player.onToxic = 200;
}



function ToxicShock(%player)
{
	if(Player::isDead(%player))	return;
	%player.onToxic = %player.onToxic -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onToxic > 70 )
		Projectile::spawnProjectile("ToxicSmoke1", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("ToxicSmoke2", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onToxic)
		schedule("ToxicShock("@%player@");",0.1);
	
}

function Armor::onShock(%client, %player)
{	
	
	if (!%player.Shocked) 
	{
		Player::unmountItem(%player,$WeaponSlot);
		Shockfire(%player);
		Client::sendMessage(%client,1, "Your energy system is FRIED!");	
	}
	%player.Shocked = 40;
	GameBase::setEnergy(%player,0);
}



function Shockfire(%player)
{
	if(Player::isDead(%player))	return;
	GameBase::playSound(%player, SoundEmpIdle,0);
	%player.Shocked = %player.Shocked -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ vector::add(getBoxCenter(%player),"0 0 0.5");
	%vel = Item::getVelocity(%player);
	if(%player.Shocked > 70 )
		Projectile::spawnProjectile("ShockedDamage", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(player::isjetting(%player))
		Projectile::spawnProjectile("ShockJet", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.Shocked)
		schedule("Shockfire("@%player@");",0.1);
	
}

function Armor::SpeedBooster(%player, %item, %power)
{
	%vec = Item::getVelocity(%player);
	if(%vec == "0 0 0")
	{
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
	GameBase::playSound(%player, SoundThrowItem, 0);
	Client::sendMessage(Player::getClient(%player),0, "Speed Boost Applied.");
}

function Armor::onBurn(%client, %player)
{	
	
	if (!%player.onfire) 
	{
		Plasmafire(%player);
		Client::sendMessage(%client,1, "Your energy system is on fire!");	
	}
	%player.onfire = 200;
}



function Plasmafire(%player)
{
	if(Player::isDead(%player))	return;
	%player.onfire = %player.onfire -1;
	%trans = "0 0 -1 0 0 0 0 0 -1 " @ getBoxCenter(%player);
	%vel = Item::getVelocity(%player);
	if(%player.onfire > 70 )
		Projectile::spawnProjectile("AnnihilationFlame", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>

	if(player::isjetting(%player))
		Projectile::spawnProjectile("JetSmoke", %trans, %player, %Vel); //transform, object, velocity vector, <projectile target (seeker)>
	if(%player.onfire)
		schedule("PlasmaFire("@%player@");",0.1);
	
}

function Armor::onSludge(%clientId, %player) 
{ 
	Client::sendMessage(%clientId,1,"Your Covered In Toxic Sludge."); 
	%drrate = GameBase::getDamageLevel(%player) + 0.05; 
	GameBase::setDamageLevel(%player, %drrate);
	Player::setDamageFlash(%player,0.5);
			if (Player::isDead(%player)) {
			messageall(0, Client::getName(%clientId) @ " melted Via Sludge."); 
			%clientId.scoreDeaths++;

 		playNextAnim(%player); 
		Player::blowUp(%player); 
		Player::kill(%player); 
 
			%clientId.score--; 
			Game::refreshClientScore(%clientId); 
			$poisonTime[%clientId] = 0; } 

		if($poisonTime[%clientId] == 0) { 
		Player::setDamageFlash(%player,0.75); 
		$poisonTime[%clientId] = 30; 
		checkPoison(%clientId, %player); 
		} 
	else $poisonTime[%clientId] = 30; 
	} 

function checkPoison(%clientId, %player) { 
	if($poisonTime[%clientId] > 0) { $poisonTime[%clientId] -= 2; 
	%drrate = GameBase::getDamageLevel(%player) + 0.05; 
		if (!Player::isDead(%player)) { GameBase::setDamageLevel(%player, %drrate); 
		Player::setDamageFlash(%player,0.25); 
			if (Player::isDead(%player)) {
			messageall(0, Client::getName(%clientId) @ " melted Via Sludge."); 
			%clientId.scoreDeaths++;

 		playNextAnim(%player); 
		Player::blowUp(%player); 
		Player::kill(%player); 
 
			%clientId.score--; 
			Game::refreshClientScore(%clientId); 
			$poisonTime[%clientId] = 0; } 
			} 
		else { $poisonTime[%clientId] = 0; 
		} 
		schedule("checkPoison(" @ %clientId @ ", " @ %player @ ");",1,%player); } 
	else { Client::sendMessage(%clientId,1,"The effects of the Toxic Sludge wear off."); 
	} 
} 
