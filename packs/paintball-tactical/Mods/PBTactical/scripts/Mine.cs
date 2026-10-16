//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "discammo";
   validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = M79Exp1;
	explosionRadius = 5.0;
	damageValue = 100;
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
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this))
	{
		%mineteam = GameBase::getTeam(%this);
        	%objteam = GameBase::getTeam(%object);
		if (%mineteam != %objteam)
		{
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
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
		}
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
	{
		%mineteam = GameBase::getTeam(%this);
        	%objteam = GameBase::getTeam(%object);
		GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	else
	{
		%this.damage += %value;
	}
}

//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "PaintNade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = coExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $BlasterDamageType;
	kickBackStrength = 100;
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
	%mineteam = GameBase::getTeam(%this);
        %objteam = GameBase::getTeam(%object);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}


function HandGrenade::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);


		%client = GameBase::getOwnerClient(%this);
		%player = client::getOwnedObject(%client);
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat2",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat3",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
		%fired = (Projectile::spawnProjectile("PaintSplat4",%trans,%this,%player));
		%fired.deployer = %client;
}

MineData Smoker
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "grenade";
	description = "Smoke Bomb";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 50000.01; //If smoke grenade can be destroyed, then the game will crash!
};

function Smoker::onAdd(%this)
{	
	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",40.0,%this);
	if ($GrenadeIsSmoking != 1)
		{
		schedule("SmokeLikeHell(" @ %this @ ", 270);",3.0,%this); //Make sure only one smoke grenade can go off at a time
		schedule("$GrenadeIsSmoking = 0;",30.0);		  //Or the game may crash, or just get REALLY slow
		}
	
}

function SmokeLikeHell(%this, %steps) //Deadtaco's smoke spew code
{
	if(%steps)
	{
		$GrenadeIsSmoking = 1;
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile("SmokeSpew",%trans,%this,%vel);
		schedule("SmokeLikeHell(" @ %this @ ", " @ %steps - 1 @ ");", 0.1);
	}
}


function Smoker::onCollision(%this,%obj)
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
}

function Smoker::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

function Smoker::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}

function Smoker::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("EndSpew",%trans,%this,0);
}

// Flash Grenade - Blinds your opponent

MineData Flashgrenade
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
	description = "Flash Grenade";
	shapeFile = "armorkit";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 10.0;
	damageValue = 0.1;
	damageType = $BangDamageType;
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

MineData carbon
{
   mass = 0.1;
   drag = 0.1;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "carbon";
   description = "carbon";
   shapeFile = "smoke";
   shadowDetailMask = 4;
   explosionId = coExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NullDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function carbon::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	//echo("%this = ", %this);
	schedule("Mine::Detonate(" @ %this @ ");",0.00001,%this);
}