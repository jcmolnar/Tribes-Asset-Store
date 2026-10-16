exec(SpecialEffectExp);

MineData FlagSparkle
{
	className = "Mine";
 	description = "A Cowpie";
 	shapeFile = "breath";
 	shadowDetailMask = 4;
 	explosionId = FLFX1;
	explosionRadius = 0.0;
	damageValue = 0;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.5;
	collideWithOwner   = FALSE;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};
function FlagSparkle::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData FireworkEffect1
{
	className = "Mine";
 	description = "A Cowpie";
 	shapeFile = "plasmabolt";
 	shadowDetailMask = 4;
 	explosionId = FireworkExp1;
	explosionRadius = 0.0;
	damageValue = 0;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.5;
	collideWithOwner = FALSE;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function FireworkEffect1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.6,%this);
}

MineData FireworkEffect2
{
	className = "Mine";
 	description = "A Cowpie";
 	shapeFile = "fusionbolt";
 	shadowDetailMask = 4;
 	explosionId = FireworkExp2;
	explosionRadius = 0.0;
	damageValue = 0;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.5;
	collideWithOwner   = FALSE;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function FireworkEffect2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.6,%this);
}

MineData FireworkEffect3
{
	className = "Mine";
 	description = "A Cowpie";
 	shapeFile = "shotgunbolt";
 	shadowDetailMask = 4;
 	explosionId = FireworkExp3;
	explosionRadius = 0.0;
	damageValue = 0;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 0.5;
	collideWithOwner   = FALSE;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function FireworkEffect3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.6,%this);
}