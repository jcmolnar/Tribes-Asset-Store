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
	$TeamItemCount[GameBase::getTeam(%this) @ "OriginalMineAmmo"]++;
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
		%type = getObjectType(%object);
		%data = GameBase::getDataName(%this);
		if (((%type == "Player") || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)))
			GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[GameBase::getTeam(%this) @ "OriginalMineAmmo"] > $TeamItemMax[OriginalMineAmmo])
		{
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
	$TeamItemCount[GameBase::getTeam(%this) @ "OriginalMineAmmo"]--;
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

MineData EMPMine
{
	className = "Mine";
	description = "EMP Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = EMPulseExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $EMPDamageType;
	kickBackStrength = 0;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function EMPMine::onAdd(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "EMPMineAmmo"]++;
	%this.damage = 0;
	EMPMine::deployCheck(%this);
}

function EMPMine::onCollision(%this,%object)
{
		%type = getObjectType(%object);
		%data = GameBase::getDataName(%this);
		if (((%type == "Player") || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)))
			GameBase::setDamageLevel(%this, %data.maxDamage);
}

function EMPMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[GameBase::getTeam(%this) @ "EMPMineAmmo"] > $TeamItemMax[EMPMineAmmo])
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("EMPMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function EMPMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "EMPMineAmmo"]--;
}

function EMPMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

MineData StickyMine
{
	className = "Mine";
	description = "EMP Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	elasticity = -0.15;
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

function StickyMine::onAdd(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "StickyMineAmmo"]++;
	%this.damage = 0;
	StickyMine::deployCheck(%this);
}

function StickyMine::onCollision(%this,%object)
{
		%type = getObjectType(%object);
		%data = GameBase::getDataName(%this);
		if (((%type == "Player") || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)))
			GameBase::setDamageLevel(%this, %data.maxDamage);
}

function StickyMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[GameBase::getTeam(%this) @ "StickyMineAmmo"] > $TeamItemMax[StickyMineAmmo])
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("StickyMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function StickyMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "StickyMineAmmo"]--;
}

function StickyMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
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

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData Concussiongrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
   description = "Concussion Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $NoDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Concussiongrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData Flashgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp1;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Flashgrenade1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Flashgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp2;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Flashgrenade2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Flashgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp3;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Flashgrenade3::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Flashgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp4;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Flashgrenade4::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Flashgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};
//Thanks *IX*Savage1!
function Flashgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("DeployFlash(" @ %this @ " , 5);",0.8,%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.9,%this);
}

function DeployFlash(%this, %count) 
{
	if(%count && %this)
	{

		%rand = 1 + floor(getRandom() * 4);

		%name = "Flashgrenade" @ %rand;

		%obj = newObject("","Mine",%name);
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.3,true);
		
		%obj = newObject("","Mine",%name);
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.3,true);


		%count -= 1;
		schedule("DeployFlash(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}

MineData EMPBurst
{
	mass = 4.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.01;
	friction = 1.0;

	className = "Handgrenade";
   description = "EMP Throw-off Energy";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = EMPBurstExp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 0.0;
	triggerRadius = 0.5;
	maxDamage = 2;
	isVisible = false;
};

function EMPBurst::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
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