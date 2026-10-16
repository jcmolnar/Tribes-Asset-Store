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
	validateShape = false;
	validateMaterials = false;
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
	schedule("Mine::Detonate(" @ %this @ ");", 2.0, %this);
}

MineData Flash
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Flashgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashgrenadeaExp;
	explosionRadius = 30;
	damageValue = 0.20;
	damageType = $FlashDamageType;
	kickBackStrength = 0.01;
	triggerRadius = 5;
	maxDamage = 2;
};

function Flash::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData BlastGren {
	mass = 1.0;
	drag = 0.75;
	density = 0.5;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Flak";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = EngineerBoostExp;
	explosionRadius = 15;
	damageValue = 0.45;
	damageType = $MiscDamageType;
	kickBackStrength = 150;
	triggerRadius = 3;
	maxDamage = 0.5;
};

function BlastGren::onAdd(%this){
	%data = GameBase::getDataName(%this);
	Schedule("Mine::Detonate("@ %this @");", 2.0, %this);
}