MineData TG::ClayMorMine
{
	className = "Mine";
	description = "Claymor Mine";
	shapeFile = "mine";
	validateShape = false;
	validateMaterials = false;
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 25;
	damageValue = 0.4;
	damageType = $ClaymorDamageType;
	kickBackStrength = 100;
	triggerRadius = 1;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = { 1.0, 1.0 };
};

function TG::ClayMorMine::onAdd(%this)
{ %this.damage = 0; TG::ClayMorMine::deployCheck(%this); }

function TG::ClayMorMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if(((%type == "Player") || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)))
	{ schedule("Mine::Detonate(" @ %this @ ");", 0.01, %this); }
}

function TG::ClayMorMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0))
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
	{ schedule("TG::ClayMorMine::deployCheck("@ %this @");", 3, %this); }
}

function TG::ClayMorMine::onDamage(%this, %type, %value, %pos, %vec, %mom, %object)
{
	if(%type == $DebugDamageType && GameBase::getTeam(%this) != Client::getTeam(%object))
	{
		%newObj = newObject("TG::ClayMorMineAmmo", Item, TG::ClayMorMineAmmo, 1, false);
		addToSet("MissionCleanup", %newObj);
		GameBase::setPosition(%newObj, Vector::add(GameBase::getPosition(%this), "0 0 1"));
		Schedule("deleteObject("@ %newObj @");", 4, %newObj);
		GameBase::setDamageLevel(%this, %data.maxDamage);
		return;
	}
	else if(%type == $ClaymorDamageType)
	{ return; }
	
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage / 1.5) < %this.damage + %value) 
	{ GameBase::setDamageLevel(%this, %data.maxDamage); }
	else
	{ %this.damage += %value; }
}

function TG::ClayMorMine::onDestroyed(%this)
{ $TeamItemCount[GameBase::getTeam(%this) @"TG::ClayMorMineAmmo"]--; }