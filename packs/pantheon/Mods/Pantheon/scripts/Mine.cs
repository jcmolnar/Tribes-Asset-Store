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
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
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
// Super Speed boost

MineData Boost
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 8.0; 
	damageValue = 0.0;
	damageType = $MineDamageType;
	kickBackStrength = 300;
	triggerRadius = 250;
	maxDamage = 0.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Boost::onAdd(%this)
{
	%this.damage = 0;
	Boost::deployCheck(%this);
}

function Boost::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == Boost || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Boost::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		//deleteObject(%set); //
	}
	else 
		schedule("Boost::deployCheck(" @ %this @ ");", 3, %this);
}	

function Boost::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

function Boost::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
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

//----------------------------------------------------------------------------
// Concussion
MineData Concussion
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
	explosionRadius = 15.0;
	damageValue = 0.75;
	damageType = $ShrapnelDamageType; // blind the victim
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Concussion::onAdd(%this)
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

MineData Smokegrenade
{
   mass = 0.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Smoke Grenade";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = smokeGrenExp;
	explosionRadius = 0.0;
	damageValue = 0.5;
	damageType = $NeutralDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Smokegrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
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


//----------------------------------------------------------------------------
MineData AtomGrenade
{
	mass = 0.5;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.25;
	friction = 2.0;
	className = "Handgrenade";
 	description = "Nuke Pack";
 	shapeFile = "magcargo";
	shadowDetailMask = 4;
	explosionId = NukeExp;
	explosionRadius = 300.0;
	damageValue = 250.0;
	damageType = $NukeGrenadeDamageType;
	kickBackStrength = 100;
	maxDamage = 250;

	lightType = 2;   // Pulsing
	lightRadius = 2;
	lightTime = 1.5;
	lightColor = { 0.15, 1, 0.35 };
};

function AtomGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	//schedule("Mine::Detonate(" @ %this @ ");",$Pantheon::NukeDetTime,%this);
	schedule("AtomGrenade::Detonate(" @ %this @ ");",$Pantheon::NukeDetTime,%this);
}

function AtomGrenade::onDestroyed(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);

	messageall(1,"Nuclear detonation has been detected!");
}

function AtomGrenade::Detonate(%this)
{
	%oldPos = GameBase::getPosition(%this);
	%centerPos = Vector::add(%oldPos, "0 0 100");

	%newPos = Vector::add(%oldPos, "0 0 5");
	%bomblet = newObject("","Mine","FWork1");//Shockwave Bomb
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.1, %bomblet);
	
	%newPos = Vector::add(%oldPos, "0 0 20");//Plume Bomb 1
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.1, %bomblet);

	%newPos = Vector::add(%newPos, "0 0 20");//Plume Bomb 2
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.15, %bomblet);

	%newPos = Vector::add(%newPos, "0 0 20");//Plume Bomb 3
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.2, %bomblet);

	%newPos = Vector::add(%newPos, "0 0 20");//Plume Bomb 4
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.25, %bomblet);

	%newPos = Vector::add(%newPos, "0 0 20");//Plume Bomb 5
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.3, %bomblet);

	%newPos = Vector::add(%centerPos, "0 20 -7"); //Northern bomb
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.3, %bomblet);

	%newPos = Vector::add(%centerPos, "0 -20 -7"); //Southern Bomb
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.3, %bomblet);

	%newPos = Vector::add(%centerPos, "20 0 -7"); //Eastern Bomb
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.3, %bomblet);

	%newPos = Vector::add(%centerPos, "-20 0 -7"); //Western Bomb
	%bomblet = newObject("","Mine","FWork");
	addToSet("MissionCleanup", %bomblet);
	GameBase::setPosition(%bomblet,%newPos);
	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.3, %bomblet);

//	%newPos = Vector::add(%centerPos, "0 40 -20"); //Northern bomb1
//	%bomblet = newObject("","Mine","FWork");
//	addToSet("MissionCleanup", %bomblet);
//	GameBase::setPosition(%bomblet,%newPos);
//	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.33, %bomblet);

//	%newPos = Vector::add(%centerPos, "0 -40 -20"); //Southern Bomb1
//	%bomblet = newObject("","Mine","FWork");
//	addToSet("MissionCleanup", %bomblet);
//	GameBase::setPosition(%bomblet,%newPos);
//	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.33, %bomblet);

//	%newPos = Vector::add(%centerPos, "40 0 -20"); //Eastern Bomb1
//	%bomblet = newObject("","Mine","FWork");
//	addToSet("MissionCleanup", %bomblet);
//	GameBase::setPosition(%bomblet,%newPos);
//	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.33, %bomblet);

//	%newPos = Vector::add(%centerPos, "-40 0 -20"); //Western Bomb1
//	%bomblet = newObject("","Mine","FWork");
//	addToSet("MissionCleanup", %bomblet);
//	GameBase::setPosition(%bomblet,%newPos);
//	schedule("Mine::Detonate(" @ %bomblet @ ");", 0.33, %bomblet);

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
	explosionRadius = 300.0;
	damageValue = 100.0;
	damageType = $NukeGrenadeDamageType;
	kickBackStrength = 50;
	maxDamage = 50;
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
	kickBackStrength = 500;
	maxDamage = 50;
};

//----------------------------------------------------------------------------
MineData Nukebomb
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
   explosionId = LargeShockwave;
	explosionRadius = 19.5;
	damageValue = 0.9;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Nukebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
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
//----------------------------------------------------------------------------
MineData Mortarbomb
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
	explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Mortarbomb::onAdd(%this)
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

//----------------------------------------------------------------------------
// Fragmentation Grenades 
//----------------------------------------------------------------------------
MineData Firebomb
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
	explosionId = debrisExpLarge;
	explosionRadius = 15.0;
	damageValue = 0.3;
	damageType = $flashExpLarge;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Firebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
        schedule("DeployFrags(" @ %this @ " , 1);",1.0,%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}
function DeployFrags(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Frag1");
 		%team = GameBase::getTeam(%this);
            	GameBase::setTeam(%obj, %team);
 
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%obj = newObject("","Mine","Frag2");
		%team = GameBase::getTeam(%this);
            	GameBase::setTeam(%obj, %team);

 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%obj = newObject("","Mine","Frag3");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeployFrags(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}


MineData Assaultbomb
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
	explosionId = LargeShockwave;
	explosionRadius = 15.0;
	damageValue = 0.4;
	damageType = $flashExpLarge;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Assaultbomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("DeployAssaultFrags(" @ %this @ " , 1);",1.0,%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}
function DeployAssaultFrags(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","MortarBomb");
 		%team = GameBase::getTeam(%this);
		GameBase::setTeam(%obj, %team);
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%player.throwTime = getSimTime() + 0.5;

//		%count -= 1;
//		schedule("DeployAssaultFrags(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

MineData Suicidebomb
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "magcargo";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 20.0;
  damageValue = 3.5;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 300;
  triggerRadius = 0.5;
  maxDamage = 3.5;
};

function Suicidebomb::onAdd (%this)
{
  %data = GameBase::getDataName (%this);
  schedule ("Mine::Detonate(" @ %this @ ");", 0.5, %this);
}

function Mine::onDamage (%this, %type, %value, %pos, %vec, %mom, %object)
{
  if (%type == $MineDamageType)
    %value = %value * 0.25;
  %damageLevel = GameBase::getDamageLevel (%this);
  GameBase::setDamageLevel (%this, %damageLevel + %value);
}

function Mine::Detonate (%this)
{
%data = GameBase::getDataName (%this);
GameBase::setDamageLevel (%this, %data.maxDamage);
}

MineData Suicidebomb2
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "magcargo";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 20.0;
  damageValue = 3.5;
  damageType = $ShrapnelDamageType;
  kickBackStrength = 300;
  triggerRadius = 0.5;
  maxDamage = 3.5;
};

function Suicidebomb2::onAdd (%this)
{
  %data = GameBase::getDataName (%this);
  schedule ("Mine::Detonate(" @ %this @ ");", 1, %this);
}

function Suicidebomb2::onCollision (%this, %obj)
{
  if (getObjectType (%obj) != "Player")
    {
      return;
    }
    if (Player::isDead (%obj))
    {
      return;
    }
    %c = Player::getClient (%obj);
    %playerTeam = GameBase::getTeam (%obj);
    %teleTeam = GameBase::getTeam (%this);
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
//=-=-=-=-=-
MineData Frag1
{
   	
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 20.0;
	damageValue = 0.05;
	damageType = $FlashDamageType;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Frag1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Frag2
{
   	
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 20.0;
	damageValue = 0.05;
	damageType = $FlashDamageType;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Frag2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Frag3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 20.0;
	damageValue = 0.05;
	damageType = $FlashDamageType;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Frag3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

//=-=-=-=-
MineData Bomblet1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Bomblet2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Bomblet3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomblet3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}
//=-=-=-=- Nuke Bomb =-=-=-=-
//=-=-=-=-
MineData Nuke1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 30.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Nuke1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Nuke2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 30.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Nuke2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Nuke3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 30.0;
	damageValue = 0.5;
	damageType = $PlasmaDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Nuke3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}
