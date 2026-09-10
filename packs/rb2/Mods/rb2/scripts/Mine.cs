// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 1.0;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 5.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this)
{
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);

}

function AntipersonelMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ($Game::missionType != "DM")
	{
		if ((%type == "Player" || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object))
			GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	else
	{
		if ((%type == "Player" || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
			GameBase::setDamageLevel(%this, %data.maxDamage);
	}
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%team = GameBase::getTeam(%this);
		$TeamItemCount[%team @ "OriginalMine"]++;

		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[%team @ "OriginalMine"] > $TeamItemMax[OriginalMine])
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
			if($TeamItemCount[%team @ "OriginalMine"] > $TeamItemMax[OriginalMine])
				$TeamItemCount[%team @ "OriginalMine"]--;
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "OriginalMine"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
		%value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//----------------------------------------------------------------------------

MineData Handgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
	description = "Frag Grenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 20.0;
	damageValue = 2.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.5;
	maxDamage = 2;
};


function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
	%value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{

	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


function HandGrenade::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);


		%client = GameBase::getOwnerClient(%this);
		%fired = (Projectile::spawnProjectile("BungeeBullet",%trans,%this,0));
		%fired.deployer = %client;

		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);


}


//----------------------------------------------------------------------------

// Suicide bomb

MineData KamikazeBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.95;
	friction = 0.4;
	className = "grenade";
	description = "Bungee Ball";
	shapeFile = "bullet";
	shadowDetailMask = 4;
	explosionId = blasterExp;
	explosionRadius = 8.0;
	damageValue = 125.0;
	damageType = $KamikazeDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function KamikazeBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

function KamikazeBomb::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
		 Projectile::spawnProjectile("BungeeBullet",%trans,%this,0);
}

//----------------------------------------------------------------------------



MineData Nukebomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "grenade";
	description = "C4 pack";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 50.0;
	damageValue = 50.0;
	damageType = $SurpriseDamageType;
	kickBackStrength = 450;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Nukebomb::onAdd(%this)
{	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	//Grenade::OnUse(" @ %this @ ");
}

function Nukebomb::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}
	if(Player::isDead(%obj))
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);

		%rnd = floor(getRandom() * 10);
		if(%rnd > 6)
		{	
			Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");

			schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
			return;
		}
		else
		{	
			deleteObject(%this);
			Client::sendMessage(%c,1,"You disarmed the C4 pack.");
		}
	
}

function Nukebomb::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
	%value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Nukebomb::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//----------------------------------------------------------------------------

// Flash Grenade - Blinds your opponent (kinda) - By DeadTaco

MineData Flashgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
	description = "Flash Grenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = FlashyExp;
	explosionRadius = 40.0;
	damageValue = 0.2;
	damageType = $BulletDmgType18;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function FlashGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function FlashGrenade::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function FlashGrenade::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

	%weapon = Player::getMountedItem(%target,$FlagSlot);
	if(%weapon == "")
	return false;
	else
	Player::dropItem(%target,%weapon);
}

//----------------------------------------------------------------------------

// Concussion Grenade - Part of Deadtaco's Supply chain

MineData Concussion
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Grenade";
	description = "Concussion Grenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 20.0;
	damageValue = 0.75;
	damageType = $ExplosionDamageType;
	kickBackStrength = 750;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 0.75, 0.75, 0.35  };
};

function Concussion::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Concussion::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Concussion::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

	%weapon = Player::getMountedItem(%target,$WeaponSlot);
	if(%weapon == "")
	return false;
	else
	Player::dropItem(%target,%weapon);
}

//----------------------------------------------------------------------------

// Tear Gas Grenade

MineData Pacificationgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
	description = "Tear Gas Grenade";
	shapeFile = "rocket";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 0.0;
	damageType = $PacificationDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 0.25, 0.75, 0.05  };
};

function Pacificationgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Pacificationgrenade::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Pacificationgrenade::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

}

//----------------------------------------------------------------------------

// Reprogrammed to be a gas can flaming ball

MineData Decloakgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 0.0;
	className = "grenade";
	description = "Gascan Fireball";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = NapalmExp;
	explosionRadius = 15.0;
	damageValue = 0.25;
	damageType = $ScramblerDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 200.0;

      lightType = 2;   // Pulsing
	lightRadius = 3;
	lightTime = 0.1;
	lightColor = { 0.85, 0.25, 0.25 };
};

function Decloakgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Decloakgrenade::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Decloakgrenade::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

}

//----------------------------------------------------------------------------

// Scrambler - converted to incindiary grenade - Bursts enemies into flames

MineData ScramblerBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
	description = "Incindiary Grenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpMedium;
	explosionRadius = 25.0;
	damageValue = 0.4;
	damageType = $ScramblerDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.25, 0.25, 0.25 };
};

function ScramblerBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function ScramblerBomb::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MineDamageType)
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function ScramblerBomb::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

}

function ScramblerBomb::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);
		 Projectile::spawnProjectile("sparkflame",%trans,%this,0);

}


//----------------------------------------------------------------------------


