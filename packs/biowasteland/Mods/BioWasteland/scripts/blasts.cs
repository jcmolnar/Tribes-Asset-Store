//===================================== CloakBlast

MineData CloakBlast
{
	className = "Mine";
	description = "CloakBlast";
	shapeFile = "breath";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 0.1;
	damageType = $CloakDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function CloakBlast::onAdd(%this)
{
    schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}


//================================== EMP Blast

MineData EMPBlast
{
	className = "Mine";
	description = "CloakBlast";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 2.0;
	damageType = $FlashDamageType;
	kickBackStrength = 0.1;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function EMPBlast::onAdd(%this)
{
    schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}


//================================== MDM Blast

MineData MDMBlast
{
	className = "Mine";
	description = "MDMBlast";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 1.5;
	damageType = $MortarDamageType;
	kickBackStrength = 250;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function MDMBlast::onAdd(%this)
{
    schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
