MineData AntipersonelMine
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	validateShape = false;
	validateMaterials = false;
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 3;
	damageValue = 0.9;
	damageType = $EMPDamageType;
	kickBackStrength = 350;
	triggerRadius = 1;
	maxDamage = 2;
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
	if(((%type == "Player") || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)))
	{ Schedule("Mine::Detonate("@ %this @");", 0.01, %this); }
}

function AntipersonelMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this, 1, "deploy");
	 	GameBase::setActive(%this, true);
		%set = newObject("set", SimSet);
		if(1 != containerBoxFillSet(%set, $MineObjectType, GameBase::getPosition(%this),1,1,1,0))
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else
	{ schedule("AntipersonelMine::deployCheck("@ %this @");", 3, %this); }
}	

function AntipersonelMine::onDestroyed(%this)
{ $TeamItemCount[GameBase::getTeam(%this) @"mineammo"]--; }

function AntipersonelMine::onDamage(%this, %type, %value, %pos, %vec, %mom, %object)
{
	%data = GameBase::getDataName(%this);
	if(%type == $DebugDamageType && GameBase::getTeam(%this) != Client::getTeam(%object))
	{
		%newObj = newObject("MineAmmo", Item, MineAmmo, 1, false);
		addToSet("MissionCleanup", %newObj);
		GameBase::setPosition(%newObj, Vector::add(GameBase::getPosition(%this), "0 0 1"));
		Schedule("deleteObject("@ %newObj @");", 4, %newObj);
		GameBase::setDamageLevel(%this, %data.maxDamage);
		return;
	}
	else if(%type == $EMPDamageType)
	{ return; }
	else if(%type == $MineDamageType)
	{ %value = %value * 0.25; }
	
	if((%data.maxDamage / 1.5) < %this.damage + %value) 
	{ GameBase::setDamageLevel(%this, %data.maxDamage); }
	else 
	{ %this.damage += %value; }
}