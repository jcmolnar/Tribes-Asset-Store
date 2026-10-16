//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

exec(combatMine);

MineData AntipersonelMine
{
	className = "Mine";
    description = "Antipersonel Mine";
    shapeFile = "mine";
    shadowDetailMask = 4;
    explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.7;
	damageType = $MineDamageType;
	kickBackStrength = 50;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
   validateShape = true;
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
if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable")
 && GameBase::isActive(%this) && (GameBase::getTeam(%this) != GameBase::getTeam(%object)) )
  GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
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
	  else schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//DAMAGE MODE
	%value *= $Combat::DamageScale;

   if(%type == $MineDamageType) %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
	else %this.damage += %value;
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
    description = "Handgrenade";
    shapeFile = "grenade";
    shadowDetailMask = 4;
    explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.55;
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

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//DAMAGE MODE
	%value *= $Combat::DamageScale;

   if(%type == $MineDamageType) %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//****************************************
// Demolition Grenade
//****************************************
MineData DemoGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
   elasticity = 0;
   friction = 100;
   className = "Handgrenade";
   description = "Demolition Grenade";
   shapeFile = "sensorjampack";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
   explosionRadius = 5;
   damageValue = 8.0;
   damageType = $ShrapnelDamageType;
   kickBackStrength = 800;
   triggerRadius = 0.5;
   maxDamage = 2;
};

function DemoGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//****************************************
// Blast Grenade
//****************************************
MineData BlastGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
   elasticity = 0.15;
   friction = 1.0;
   className = "Handgrenade";
   description = "Blast Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
   explosionRadius = 18.0;
   damageValue = 0.7;
   damageType = $ShrapnelDamageType;
   kickBackStrength = 200; //400;
   triggerRadius = 0.5;
   maxDamage = 2;
};

function BlastGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
