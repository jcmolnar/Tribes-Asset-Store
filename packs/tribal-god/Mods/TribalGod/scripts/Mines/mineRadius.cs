MineData RadiusMine
{
	className = "Mine";
	description = "Radius Mine";
	shapeFile = "flag";
	validateShape = false;
	validateMaterials = false;
	shadowDetailMask = 4;
	explosionId = radiusmineexp;
	explosionRadius = 20;
	damageValue = 1;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 10;
	maxDamage = 1;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function RadiusMine::onAdd(%this)
{ %this.damage = 0; RadiusMine::deployCheck(%this); }

function RadiusMine::onCollision(%this, %object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	
	if(((%type == "Player") || %data == RadiusMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
	{ GameBase::setDamageLevel(%this, %data.maxDamage); }
}

function RadiusMine::deployCheck(%this)
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
	{ schedule("RadiusMine::deployCheck("@ %this @");", 3, %this); }
}	

function RadiusMine::onDestroyed(%this)
{ $TeamItemCount[GameBase::getTeam(%this) @ "radiusmineammo"]--; }

function RadiusMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $MineDamageType)
	{ %value = %value * 0.25; }
	%data = GameBase::getDataName(%this);
	
	if((%data.maxDamage/1.5) < %this.damage+%value)
	{ GameBase::setDamageLevel(%this, %data.maxDamage); }
	else{ %this.damage += %value; }
}