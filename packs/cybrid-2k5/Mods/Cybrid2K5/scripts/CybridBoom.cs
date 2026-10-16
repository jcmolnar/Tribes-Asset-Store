//------------------------------------------------------------------//
//-Ice's Nuke Code, please, do not distribute without my permission-//
//------------------------------------------------------------------//

$NMABD = 10;
$NadeEllipseObj = "";
$NadeEllipseType = "";
$NadeEllipseLength = 3;

function NuclearExplosion(%pos)
{
	%obj = newObject("","Mine","NRad");
	addToSet("MissionCleanup", %obj); //-Core
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRing1");
	addToSet("MissionCleanup", %obj); //-Horiz Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRing2");
	addToSet("MissionCleanup", %obj); //-Vert Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRing3");
	addToSet("MissionCleanup", %obj); //-Final Ring
	GameBase::setPosition(%obj,%pos);

	CreateSphere(%pos,"NAfter","Mine",$NMABD);
}

function PowerExplosion(%pos)
{
	%obj = newObject("","Mine","GRad");
	addToSet("MissionCleanup", %obj); //-Core
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","GRing1");
	addToSet("MissionCleanup", %obj); //-Horiz Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","GRing2");
	addToSet("MissionCleanup", %obj); //-Vert Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","GRing3");
	addToSet("MissionCleanup", %obj); //-Final Ring
	GameBase::setPosition(%obj,%pos);

	CreateSphere(%pos,"GRad","Mine",$NMABD);
}

//==================================================================================================== Making a Sphere

function CreateSphere(%pos,%obj,%type,%size)
{
	if(!%size)
		%size = 10;
	for(%i = 0; %i < 6.28; %i += 1.256) {
		%NewPos1 = Vector::add(%pos, Vector::getFromRot(%i@" 0 0",%size, 0.0));  // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos2 = Vector::add(%pos, Vector::getFromRot("0 "@%i@" 0",0.0,%size)); // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos3 = Vector::add(%pos, Vector::getFromRot("0 0 "@%i,0.0,%size));   // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%obj1 = newObject("",%type,%obj);
		%obj2 = newObject("",%type,%obj);
		%obj3 = newObject("",%type,%obj);
		addToSet("MissionCleanup",%obj1);
		addToSet("MissionCleanup",%obj2);
		addToSet("MissionCleanup",%obj3);
		GameBase::setPosition(%obj1,%NewPos1);
		GameBase::setPosition(%obj2,%NewPos2);
		GameBase::setPosition(%obj3,%NewPos3);
	}
}

//==================================================================================================== Making an Elipse

function CreateEllipse(%pos,%obj,%type,%length,%width)
{
	if(!%length)
		%length = 5;
	if(!%width)
		%width = 1;
	for(%i = -(%length); %i <= %length; %i++) {
		%w = 1/%width;
		%x = %w*%i*%i;
		%X1 = %length * %length - %x;
		%X2 = %length * %length * -1 + %x;
		%NewPos1 = Vector::add(%pos,%i@" "@%X1@" 0");
		%NewPos2 = Vector::add(%pos,%i@" "@%X2@" 0");
		if(%type == "Flier") {
			%obj1 = newObject("",%type,%obj,true);
			%obj2 = newObject("",%type,%obj,true);
		}
		else if(%type == "Mine") {
			%obj1 = newObject("",%type,%obj);
			%obj2 = newObject("",%type,%obj);
		}
		else {
			%obj1 = newObject("",%type,%obj,1,false);
			%obj2 = newObject("",%type,%obj,1,false);
		}
		if(!%obj1 || !%obj2)
			return;
		addToSet("MissionCleanup",%obj1);
		addToSet("MissionCleanup",%obj2);
		GameBase::setPosition(%obj1,%NewPos1);
		GameBase::setPosition(%obj2,%NewPos2);
	}
}

//==================================================================================================== Making an Elipse

function SetSmokers(%pos)
{
	%obj = newObject("","Mine","Smoker1");
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","Smoker2");
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","Smoker3");
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","Smoker4");
	addToSet("MissionCleanup", %obj);
	GameBase::setPosition(%obj,%pos);
}

//==================================================================================================== Nuclear Explosion

MineData NRad
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = plasmaExp;
        explosionRadius = 25;
        damageValue = 1.0;
	damageType = $AntimatterDamageType;
        kickBackStrength = 100;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing1
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 50.0;
        damageValue = 1.0;
	damageType = $AntimatterDamageType;
        kickBackStrength = 450;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing2
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave2;
        explosionRadius = 15.0;
        damageValue = 1.0;
	damageType = $AntimatterDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData NRing3
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
	explosionId = KamiExplosion;
	explosionRadius = 15.0;
        damageValue = 0.65;
	damageType = $AntimatterDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.01;
	maxDamage = 20.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData NAfter
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = NAfterExp;
        explosionRadius = 5.0;
        damageValue = 0.65;
	damageType = $AntimatterDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

//- so far 0.08 is the earliest able to detonate a spawned mine
//- NRad should detonate all other mines in the center except NRing3, intentionally
function NRad::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.08,%this);
}
//- NRing3 is a final ring effect so call it last
function NRing3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}
function NAfter::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

MineData GRad
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
	explosionId = turretExp;
	//explosionId = blasterExp;
	//explosionId = ShieldExp;
	//explosionId = plasmaExp;
	explosionRadius = 20.0;
	damageValue = 0;
	damageType = $AntimatterDamageType;
        kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing1
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $AntimatterDamageType;
        kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing2
{
	className = "Mines";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave2;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $AntimatterDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing3
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave3;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $AntimatterDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function GRad::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function GRing1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function GRing2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}
function GRing3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

//====================================================================================================

MineData Smoker1
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = SmokerExp1;
        explosionRadius = 5;
        damageValue = 0;
	damageType = $AntimatterDamageType;
        kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 20.0;
	damageLevel = {1.0, 1.0};
};

MineData Smoker2
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = SmokerExp2;
        explosionRadius = 10;
        damageValue = 0;
	damageType = $AntimatterDamageType;
        kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 20.0;
	damageLevel = {1.0, 1.0};
};

MineData Smoker3
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = SmokerExp3;
        explosionRadius = 5;
        damageValue = 0;
	damageType = $AntimatterDamageType;
        kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 20.0;
	damageLevel = {1.0, 1.0};
};

MineData Smoker4
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = SmokerExp4;
        explosionRadius = 10;
        damageValue = 0;
	damageType = $AntimatterDamageType;
        kickBackStrength = 0;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 20.0;
	damageLevel = {1.0, 1.0};
};

function Smoker1::onCollision(%this,%object)
{
	GameBase::applyRadiusDamage($SmokeDamageType,getboxcenter(%this),10,0,0,%object);
}
function Smoker2::onCollision(%this,%object)
{
	GameBase::applyRadiusDamage($SmokeDamageType,getboxcenter(%this),10,0,0,%object);
}
function Smoker3::onCollision(%this,%object)
{
	GameBase::applyRadiusDamage($SmokeDamageType,getboxcenter(%this),10,0,0,%object);
}
function Smoker4::onCollision(%this,%object)
{
	GameBase::applyRadiusDamage($SmokeDamageType,getboxcenter(%this),10,0,0,%object);
}

function Smoker1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}
function Smoker2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}
function Smoker3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}
function Smoker4::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",1.25,%this);
}
