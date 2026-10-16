
$NMABD = 10;

function NuclearExplosion(%pos)
{
	%obj = newObject("","Mine","NRad");
	addToSet("MissionCleanup", %obj); //-Core
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRingC");
	addToSet("MissionCleanup", %obj); //-Horiz Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRing2");
	addToSet("MissionCleanup", %obj); //-Vert Ring
	GameBase::setPosition(%obj,%pos);

	%obj = newObject("","Mine","NRing3");
	addToSet("MissionCleanup", %obj); //-Final Ring
	GameBase::setPosition(%obj,%pos);

	for(%i = 0; %i < 6.28; %i += 1.256) {
		%NewPos1 = Vector::add(%pos, Vector::getFromRot(%i@" 0 0",$NMABD, 0.0));  // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos2 = Vector::add(%pos, Vector::getFromRot("0 "@%i@" 0",0.0,$NMABD)); // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos3 = Vector::add(%pos, Vector::getFromRot("0 0 "@%i,0.0,$NMABD));   // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%obj1 = newObject("","Mine","NAfter");
		%obj2 = newObject("","Mine","NAfter");
		%obj3 = newObject("","Mine","NAfter");
		addToSet("MissionCleanup",%obj1);
		addToSet("MissionCleanup",%obj2);
		addToSet("MissionCleanup",%obj3);
		GameBase::setPosition(%obj1,%NewPos1);
		GameBase::setPosition(%obj2,%NewPos2);
		GameBase::setPosition(%obj3,%NewPos3);
	}
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

	for(%i = 0; %i < 6.28; %i += 1.256) {
		%NewPos1 = Vector::add(%pos, Vector::getFromRot(%i@" 0 0",$NMABD, 0.0));  // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos2 = Vector::add(%pos, Vector::getFromRot("0 "@%i@" 0",0.0,$NMABD)); // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%NewPos3 = Vector::add(%pos, Vector::getFromRot("0 0 "@%i,0.0,$NMABD));   // X = angle from center, Y = Horiz dist from center, Z = Vert dist from center
		%obj1 = newObject("","Mine","GRad");
		%obj2 = newObject("","Mine","GRad");
		%obj3 = newObject("","Mine","GRad");
		addToSet("MissionCleanup",%obj1);
		addToSet("MissionCleanup",%obj2);
		addToSet("MissionCleanup",%obj3);
		GameBase::setPosition(%obj1,%NewPos1);
		GameBase::setPosition(%obj2,%NewPos2);
		GameBase::setPosition(%obj3,%NewPos3);
	}
}

//==================================================================================================== Nuclear Explosion

//==================================================================================================== Nuclear Explosion

MineData NRad
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = plasmaExp;
        explosionRadius = 25;
        damageValue = 1.0;
	damageType = $MortarDamageType;
        kickBackStrength = 100;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData NRingC
{
	className = "Mine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 50.0;
        damageValue = 1.0;
	damageType = $MortarDamageType;
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
	damageType = $MortarDamageType;
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
        explosionId = LargeShockwave3;
        explosionRadius = 15.0;
        damageValue = 0.65;
	damageType = $mortarDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
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
	damageType = $mortarDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function NRad::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function NRingC::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function NRing2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
function NRing3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}
function NAfter::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
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
	damageType = $mortarDamageType;
        kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing1
{
	className = "NukeMine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $mortarDamageType;
        kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing2
{
	className = "NukeMine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave2;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $MortarDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.01;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
};

MineData GRing3
{
	className = "NukeMine";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave3;
        explosionRadius = 15.0;
        damageValue = 0;
	damageType = $MortarDamageType;
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

//==================================================================================================== Suicide Pack 2 On Deploy

