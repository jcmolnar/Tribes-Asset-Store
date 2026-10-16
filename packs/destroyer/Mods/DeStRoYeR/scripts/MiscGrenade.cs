//--------------------------------------

$SellAmmo[Grenade] = 5;
$AmmoPackMax[Grenade] = 10;
$AmmoPackItems[4] = Grenade;

//--------------------------------------

$InvList[Grenade] = 1;
$RemoteInvList[Grenade] = 1;

//--------------------------------------

ItemData Grenade
{
   description = "Grenade";
   shapeFile = "grenade";
   heading = "gMiscellany";
   shadowDetailMask = 4;
   price = 5;
	className = "HandAmmo";
   validateShape = true;
   validateMaterials = true;
};

function Grenade::onUse(%player,%item)
{
	if($matchStarted && %player.throwTime < getSimTime())
	{
		if(!$build)Player::decItemCount(%player,%item);
		%armor = Player::getArmor(%player);
		eval(%armor @ "::onGrenade(" @ %player @ ");");
	}
}

//--------------------------------------

MineData Handgrenade //Warrior
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

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Incgrenade //Builder
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Incendiary grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $FlameDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Incgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Psygrenade //Psycic
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Psy-grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = plasmaexp;
	explosionRadius = 5.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 125;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Psygrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

MineData Empgrenade //Charger
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Empgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = Shockwave;
	explosionRadius = 5.0;
	damageValue = 0.1;
	damageType = $EMPDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.5;
	maxDamage = 1;
};

function Empgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Bombgrenade //Avenger
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Bomb";
   shapeFile = "mortarammo";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 15.0;
	damageValue = 0.5;
	damageType = $MortarDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Bombgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

MineData Mechgrenade //Mech
{
   mass = 0.2;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Mech-Nade";
   shapeFile = "Plasammo";
   shadowDetailMask = 4;
   explosionId = RocketExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ExplosionDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Mechgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
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

//--------------------------------------