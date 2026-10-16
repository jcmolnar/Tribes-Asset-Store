//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 15.0; //250
	damageValue = 0.65; //0
	damageType = $MineDamageType;
	kickBackStrength = 150; //500
	triggerRadius = 5; //250
	maxDamage = 1.0;//0
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
		deleteObject(%set); //
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
   shapeFile = "bullet"; //"mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 8.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 300; //500
	triggerRadius = 250; //250
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
//----------------------------------------------------------------------------
// flag Bomb

MineData Hologram
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "flag";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 5.0; //250
	damageValue = 0.75; //0.75
	damageType = $MineDamageType;
	kickBackStrength = 150; //500
	triggerRadius = 0.5; //250 //2.5
	maxDamage = 1.0; //3.00;
	shadowDetailMask = 0;
	destroyDamage = 1.0; //2.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.75;
	lightColor = { 0.85, 0.25, 0.25 };

};

function Hologram::onAdd(%this)
{
	%this.damage = 0;
	Boost::deployCheck(%this);
}

function Hologram::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Hologram::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}	

function Hologram::onDestroyed(%this)
{
	//$TeamItemCount[GameBase::getTeam(%this) @ "Beacon"]--;
}

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $ShrapnelDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//----------------------------------------------------------------------------
// normal


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
	damageValue = 0.6;
	damageType = $PlasmaDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 0.85, 0.25, 0.25  };
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
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData EMPbomb
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
   explosionId = EMPPulseExp; 
	explosionRadius = 30.0;
	damageValue = 0.1;
	damageType = $EMPDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 0.75, 0.25, 0.65  };
};

function EMPbomb::onAdd(%this)
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
   explosionId = Shockwave;
	explosionRadius = 15.0;
	damageValue = 0.3;
	damageType = $ImpactDamageType; // blind the victim
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 0.75, 0.75, 0.35  };
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
	explosionRadius = 20.0;
	damageValue = 0.35;
	damageType = $ImpactDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 0.05, 0.25, 0.45  };
};

function Nukebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); //3.0+++++++++++++
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

	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.1;
	lightColor = { 0.25, 0.75, 0.05  };
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
	explosionRadius = 20.0;
	damageValue = 0.1;
	damageType = $flashExpLarge;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Firebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
      schedule("DeployFrags(" @ %this @ " , 5);",1.0,%this);
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
//=-=-=-=-=-ClusterBomb++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
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
	explosionId = rocketExp;
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ExplosionDamageType;
	kickBackStrength = 50;
	triggerRadius = 5.0;
	maxDamage = 1.5;
};

function Frag1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",8.0,%this);//2.0+++++++++++
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
	explosionId = rocketExp;
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ExplosionDamageType;
	kickBackStrength = 50;
	triggerRadius = 5.0;
	maxDamage = 1.5;
};

function Frag2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",8.5,%this);//2.25++++++++++++
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
	explosionId = rocketExp;
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ExplosionDamageType;
	kickBackStrength = 50;
	triggerRadius = 5.0;
	maxDamage = 1.5;
};

function Frag3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",9.0,%this);//2.5++++++++
}
//=-=-=-=-MineLauncherAmmo=-=-=-=-+++++++++++++++++++++++++++++++++++++++++++++++++
MineData Nuke1
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke1::onAdd(%this)
{
	%this.damage = 0;
	Nuke1::deployCheck(%this);
}

function Nuke1::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke1::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Nuke1::deployCheck(" @ %this @ ");", 3, %this);
}
//------------------
MineData Nuke2
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke2::onAdd(%this)
{
	%this.damage = 0;
	Nuke2::deployCheck(%this);
}

function Nuke2::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke2::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Nuke2::deployCheck(" @ %this @ ");", 3, %this);
}
//----------------------
MineData Nuke3
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Bomblet";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ImpactDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.5;
};
function Nuke3::onAdd(%this)
{
	%this.damage = 0;
	Nuke3::deployCheck(%this);
}

function Nuke3::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Nuke3::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Nuke3::deployCheck(" @ %this @ ");", 3, %this);
}
//+++++++++++++++++++++++++
//new for hvTactical-v1
//-------------------------
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData C4e
{
	className = "Mine";
   description = "C4 Explosive";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 20.0;
	damageValue = 10.0;
	damageType = $MineDamageType;
	kickBackStrength = 600; //knockback, lower#=stronger?
	triggerRadius = 5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 3.0;
	damageLevel = {1.0, 1.0};
      lightType = 2;   // Pulsing
	lightRadius = 3;
	lightTime = 0.1;
	lightColor = { 0.85, 0.25, 0.25 };
};

function C4e::onAdd(%this)
{
	%this.damage = 0;
	C4e::deployCheck(%this);
}

function C4e::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function C4e::deployCheck(%this)
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
		schedule("C4e::deployCheck(" @ %this @ ");", 3, %this);
}	

function C4e::onDestroyed(%this)
{
//	Mine::onDestroyed(%this);//++++++++++++++++++++++++++++++++++++++++++++++++++++++
	$TeamItemCount[GameBase::getTeam(%this) @ "C4Pack"]--;//+++++++++++++++++++
}

function C4e::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Smoke1
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
	explosionId = smokeExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PlasmaDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Smoke1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Smoke2
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
	explosionId = smokeExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PlasmaDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Smoke2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Smoke3
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
	explosionId = smokeExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PlasmaDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Smoke3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Claymore
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 20.0;
	damageValue = 1.5;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.85, 0.25, 0.25 };
};

function Claymore::onAdd(%this)
{
	%this.damage = 0;
	Claymore::deployCheck(%this);
}

function Claymore::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Claymore::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Claymore::deployCheck(" @ %this @ ");", 3, %this);
}	

function Claymore::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function Claymore::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData TreeMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "tree1";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 30.0;
	damageValue = 0.3; //0.5;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 4.0;
	maxDamage = 6.0;
	shadowDetailMask = 0;
	destroyDamage = 6.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.75;
	lightColor = { 0.25, 0.25, 0.25 };
};

function TreeMine::onAdd(%this)
{
	%this.damage = 0;
	TreeMine::deployCheck(%this);
}

function TreeMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == Vehicle) &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function TreeMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("TreeMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function TreeMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function TreeMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData EMPMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 30.0;
	damageValue = 0.1;
	damageType = $EMPDamageType;
	kickBackStrength = 50;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.75, 0.25, 0.65 };
};

function EMPMine::onAdd(%this)
{
	%this.damage = 0;
	EMPMine::deployCheck(%this);
}

function EMPMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function EMPMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("EMPMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function EMPMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function EMPMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData MortarMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.25, 0.75, 0.05 };
};

function MortarMine::onAdd(%this)
{
	%this.damage = 0;
	MortarMine::deployCheck(%this);
}

function MortarMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MortarMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("MortarMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function MortarMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function MortarMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData ShockwaveMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 30.0;
	damageValue = 0.15;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.05, 0.25, 0.45 };
};

function ShockwaveMine::onAdd(%this)
{
	%this.damage = 0;
	ShockwaveMine::deployCheck(%this);
}

function ShockwaveMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ShockwaveMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("ShockwaveMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ShockwaveMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function ShockwaveMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData StingerMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 20.0;
	damageValue = 0.5;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.75, 0.75, 0.35 };
};

function StingerMine::onAdd(%this)
{
	%this.damage = 0;
	StingerMine::deployCheck(%this);
}

function StingerMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function StingerMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("StingerMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function StingerMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function StingerMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData HologramMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "larmor";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 20.0;
	damageValue = 0.5;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HologramMine::onAdd(%this)
{
	%this.damage = 0;
	HologramMine::deployCheck(%this);
}

function HologramMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HologramMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("HologramMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function HologramMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function HologramMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData BlastMine
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Demolition Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 1.35; //1.35+++++++++
	damageType = $MortarDamageType; 
	kickBackStrength = 350;
	triggerRadius = 5.0;
	maxDamage = 100.0;

      lightType = 2;   // Pulsing
	lightRadius = 8;
	lightTime = 0.1;
	lightColor = { 0.85, 0.25, 0.25 };
};

function BlastMine::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}

function BlastMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function BlastMine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData MotionMine
{
	className = "DeployableSensor";
   description = "Antipersonel Mine";
   shapeFile = "Mine"; //"sensor_small";
   shadowDetailMask = 4;
   explosionId = mineExp;

	visibleToSensor = true;//++++++
	range = 50;//+++++++
	dopplerVelocity = 1;//+++++++++
   castLOS = false;//++++++
   supression = false;//+++++
	supressable = false;//++++++
	pinger = false;//++++++++

	explosionRadius = 15.0; //20
	damageValue = 0.65; 
	damageType = $MineDamageType;
	kickBackStrength = 150; 
	triggerRadius = 5; //8
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function MotionMine::onAdd(%this)
{
	%this.damage = 0;
	MotionMine::deployCheck(%this);
}

function MotionMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == MotionMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MotionMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("MotionMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function MotionMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function MotionMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
function DeployableSensor::onAdd(%this)
{
	schedule("DeployableSensor::deploy(" @ %this @ ");",1,%this);
}

function DeployableSensor::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSensor::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
}
