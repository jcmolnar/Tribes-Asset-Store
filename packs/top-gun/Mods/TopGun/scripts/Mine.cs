//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
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
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
	{
		// DELTA FORCE 
		if(Gamebase::getTeam(%this) == Gamebase::getTeam(%object)) return;
		// END DELTA FORCE
		GameBase::setDamageLevel(%this, %data.maxDamage);
	}
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		} else GameBase::startFadeOut(%this); // Invisible mines!
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
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

MineData Smokegrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = smokeExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Smokegrenade::onAdd(%this)
{
	schedule("smokeDetonate("@%this@");", 1, %this);
}

function smokeDetonate(%this)
{
	if($SmokeTime[%this] > 0)
	{
		%gren = newObject("", "Mine", "Smokegrenade");
		$GrenOwner[%gren] = $GrenOwner[%this];
		$SmokeTime[%gren] = $SmokeTime[%this] - 1;
		GameBase::setPosition(%gren, GameBase::getPosition(%this));
		GameBase::setRotation(%gren, GameBase::getRotation(%this));
	}
	GameBase::setDamageLevel(%this, 2);

	// Blind anyone actually inside the smoke cloud...
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$SimPlayerObjectType,GameBase::getPosition(%this),20,20,20,0);
	if(%num > 0)
	{
		for(%i = 0; %i < %num; %i++)
		{
			%player = Group::getObject(%set, %i);
			Player::setDamageFlash(%player, 1.0);
			schedule("Player::setDamageFlash("@%player@",0.0);", 2.0, %player);
		}
	}
	deleteObject(%set);
}

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function grenadeFindOwner(%this)
{
	GameBase::getLOSInfo(%this, 3, "0 0 3.142");
	return Player::getClient($los::object);
}

function checkSmoke(%this)
{
	%owner = grenadeFindOwner(%this);
	echo(%owner);
	$GrenOwner[%this] = %owner;
	if($GrenMode[%owner] == 1) 
	{ // Smoke
		$SmokeGren[%this] = true;
		$SmokeTime[%this] = $Server::SmokePuffs; // # of puffs of smoke
	} else $SmokeGren[%this] = false;
}

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	
	// DELTA FORCE
	schedule("checkSmoke("@%this@");", 0.05, %this);
	// END DELTA FORCE

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
	if(!$SmokeGren[%this]) // Not a smoke grenade
	{
		GameBase::setDamageLevel(%this, %data.maxDamage);
	} else 
	{
		%gren = newObject("", "Mine", "Smokegrenade");
		$GrenOwner[%gren] = $GrenOwner[%this];
		$SmokeTime[%gren] = $SmokeTime[%this];
		GameBase::setPosition(%gren, GameBase::getPosition(%this));
		GameBase::setRotation(%gren, GameBase::getRotation(%this));
		Smokegrenade::onAdd(%gren);
		deleteObject(%this);
	}
}
