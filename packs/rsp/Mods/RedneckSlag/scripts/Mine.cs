//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
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
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object)) // Added team checking for RSP
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function AntipersonelMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
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

//-----------------------
//Redneck Slag Jump Mines
//-----------------------
MineData BoosterMine
{
	className = "Mine";
   description = "BoosterMine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = jumpMineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $NeutralDamageType;
	kickBackStrength = 500;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function BoosterMine::onAdd(%this)
{
	%this.damage = 0;
	BoosterMine::deployCheck(%this);
}

function BoosterMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == BoosterMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function BoosterMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("BoosterMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function BoosterMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "jumpmineammo"]--;
}

function BoosterMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//---------------------------------
// Con Grenade
//---------------------------------
MineData PushGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Concussion Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = jumpMineExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $NeutralDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 1;
};

//---------------------------------
// Flash Grenade
//---------------------------------
MineData BlindGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = BlindExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $NeutralDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 1;
};

//---------------------------------
// Nuke Pack
//---------------------------------
MineData AtomGrenade
{
   mass = 0.5;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.25;
	friction = 2.0;
	className = "Handgrenade";
   description = "Nuke Pack";
   shapeFile = "grenammo";
   shadowDetailMask = 4;
   explosionId = NukeExp;
	explosionRadius = 150.0;
	damageValue = 25.0;
	damageType = $NukeGrenadeDamageType;
	kickBackStrength = 500;
	maxDamage = 500;

	lightType = 2;   // Pulsing
	lightRadius = 2;
	lightTime = 1.5;
	lightColor = { 0.15, 1, 0.35 };
};

function AtomGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	
	schedule("AtomGrenade::Detonate(" @ %this @ ");",$RSP::NukeDetTime,%this);
}

function AtomGrenade::onDestroyed(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

	messageall(1,"Nuclear detonation has been detected!");
}

function AtomGrenade::Detonate(%this)
{
	$RSP::NukeActive[GameBase::getTeam(%this)] = False;
	
	%oldPos = GameBase::getPosition(%this);
	%centerPos = Vector::add(%oldPos, "0 0 100");

	%newPos = Vector::add(%oldPos, "0 0 5");
	%bomblet = newObject("","Mine","FWork1");//Shockwave Bomb
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.25, %bomblet);
	
	%newPos = Vector::add(%oldPos, "0 0 5");//Plume Bomb 1
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.25, %bomblet);

	%newPos = Vector::add(%newPos, "0 0 15");//Plume Bomb 2
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.5, %bomblet);

	%newPos = Vector::add(%newPos, "0 0 15");//Plume Bomb 3
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.75, %bomblet);

	%newPos = Vector::add(%newPos, "0 0 15");//Plume Bomb 4
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 1, %bomblet);

	%newPos = Vector::add(%newPos, "0 0 15");//Plume Bomb 5
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 1.25, %bomblet);

	%newPos = Vector::add(%centerPos, "0 10 -7"); //Northern bomb
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 1.5, %bomblet);

	%newPos = Vector::add(%centerPos, "0 -10 -7"); //Southern Bomb
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 1.5, %bomblet);

	%newPos = Vector::add(%centerPos, "10 0 -7"); //Eastern Bomb
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 1.5, %bomblet);

	%newPos = Vector::add(%centerPos, "-10 0 -7"); //Western Bomb
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 1.5, %bomblet);

	%newPos = Vector::add(%centerPos, "0 20 -14"); //Northern bomb1
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 2, %bomblet);

	%newPos = Vector::add(%centerPos, "0 -20 -14"); //Southern Bomb1
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 2, %bomblet);

	%newPos = Vector::add(%centerPos, "20 0 -14"); //Eastern Bomb1
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 2, %bomblet);

	%newPos = Vector::add(%centerPos, "-20 0 -14"); //Western Bomb1
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 2, %bomblet);

	%newPos = Vector::add(%centerPos, "0 0 15"); // Top Shockwave
	%bomblet = newObject("","Mine","FWork1");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 1, %bomblet);

	Mine::Detonate(%this);
}

//---------------------------------
// Firework Grenades - Part of the nuke
//---------------------------------
MineData FWork
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Firework";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = FireworkExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $NeutralDamageType;
	kickBackStrength = 300;
	maxDamage = 0;
};

MineData FWork1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Firework";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = FireworkExp1;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $NeutralDamageType;
	kickBackStrength = 300;
	maxDamage = 0;
};

//----------------------------
// Kamikaze Bomb
//----------------------------
MineData KamikazeBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Kamikaze Bomb";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = KamikazeExp;
	explosionRadius = 15.0;
    damageValue = 5.0;
	damageType = $KamikazeDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function KamikazeBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}