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
	visibleToSensor = true;
};

// Launched mines
MineData MiniMine
{
	className = "Mine";
   description = "Tiny Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.15;
	damageType = $MineDamageType;
	kickBackStrength = 75;
	triggerRadius = 1.25;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

// ZX-2 Mine
MineData GasMine
{
	className = "Mine";
   description = "Chemical Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = plasmaExp;
	explosionRadius = 50.0;
	damageValue = 0.0;
	damageType = $ChemDamageType;
	kickBackStrength = 1;
	triggerRadius = 3.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function Mine::onAdd(%this)
{
	%this.damage = 0;
	Mine::deployCheck(%this);
}

function Mine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player") || %data == AntipersonelMine || %data == MiniMine || %data == GasMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
	{
		GameBase::setDamageLevel(%this, %data.maxDamage);
		%pickAnim = radnomItems(4, 34, 34, 33, 28);
		Player::setAnimation(%object, %pickAnim);
	}
}

function Mine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
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
	else 
		schedule("Mine::deployCheck(" @ %this @ ");", 3, %this);
}	

function Mine::onDestroyed(%this)
{
//	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
   %this.lastDamageObject = %object;
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

MineData IncenHandgrenade
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
   explosionId = incendiaryExp;
	explosionRadius = 35.0;
	damageValue = 0.2;
	damageType = $FireDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 20;
};

function IncenHandgrenade::onAdd(%this)
{
	%this.Time = 20;
	schedule("IncendSpawns("@ %this @");",1.0,%this);

	schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
}

function IncendSpawns(%this)
{
	if(%this.Time > 0)
	{
		%obj = newObject("","Mine","IncenMini");
		addToSet("MissionCleanup", %obj);
		GameBase::setTeam(%obj,GameBase::getTeam(%this));
		echo(GameBase::getTeam(%this));
		echo(GameBase::getTeam(%obj));
		GameBase::setPosition(%obj,GameBase::getPosition(%this));
		schedule("IncendSpawns("@ %this @");",0.1,%this);
		%cl = %this.THOwn;
		%pl = Client::getOwnedObject(%cl);
		Client::setOwnedObject(%cl,%obj);
		Client::setOwnedObject(%cl,%pl);
	}
}

MineData IncenMini
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Handgrenade";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = debrisExpSmall;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

// The explosive from the NukePack
MineData NukeBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Nuke Pack Boom";
   shapeFile = "mineammo";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 50.0;
	damageValue = 8.5;
	damageType = $NukeDamageType;
	kickBackStrength = 4000;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function NukeBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.01,%this);
}

MineData ShockBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Shock Grenade";
   shapeFile = "discb";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 14.0;
	damageValue = 0.2;
	damageType = $NukeDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 10;
};

function ShockBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
}

MineData EnergyBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Energy Grenade";
   shapeFile = "mortarammo";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 15.0;
	damageValue = 0.5;
	damageType = $IonDamageType;
	kickBackStrength = 30;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function EnergyBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("EnergyBomb::Detonate(" @ %this @ ");",3.0,%this);
}

function EnergyBomb::Detonate(%this)
{
	%bp = GameBase::getPosition(%this);
	%a = Vector::add(%bp,"0 0 1");
	%b = Vector::add(%bp,"0.25 0 1");
	%c = Vector::add(%bp,"0 0.25 1");
	%d = Vector::add(%bp,"-0.25 0 1");
	%e = Vector::add(%bp,"0 -0.25 1");
	%f = Vector::add(%bp,"0.5 0 0");
	%g = Vector::add(%bp,"0 0.5 0");
	%h = Vector::add(%bp,"-0.5 0 0");
	%i = Vector::add(%bp,"0 -0.5 0");
	TFunc::SpawnFX(%a,-1,"TeleBomb");
	TFunc::SpawnFX(%b,-1,"TeleBomb");
	TFunc::SpawnFX(%c,-1,"TeleBomb");
	TFunc::SpawnFX(%d,-1,"TeleBomb");
	TFunc::SpawnFX(%e,-1,"TeleBomb");
	TFunc::SpawnFX(%f,-1,"TeleBomb");
	TFunc::SpawnFX(%g,-1,"TeleBomb");
	TFunc::SpawnFX(%h,-1,"TeleBomb");
	TFunc::SpawnFX(%i,-1,"TeleBomb");
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

MineData DistorterBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Spacial Distortion Device";
   shapeFile = "plasammo";
   shadowDetailMask = 4;
   explosionId = SpaceTear;
	explosionRadius = 13.0;
	damageValue = 0.075;
	damageType = $DisruptionDamageType;
	kickBackStrength = -10;
	triggerRadius = 0.5;
	maxDamage = 10;
};

function DistorterBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",3.0,%this);
}

MineData WaveBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Shockwave Bomb";
   shapeFile = "mortarammo";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 60.0;
	damageValue = 0.005;
	damageType = $NukeDamageType;
	kickBackStrength = 900;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function WaveBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	Mine::DeployCheck(%this);
}

MineData HeavyBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Mortar Bomb";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 20;
};

function HeavyBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",3.9,%this);
}

MineData TripBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
   description = "Trip Bomb";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

// Instant Effects - Used variously in the mod for special effects
MineData Exhaust
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Orbital Insertion Pack Exhaust";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = OOPExhaust;
	explosionRadius = 6.0;
	damageValue = 0.025;
	damageType = $ExhaustDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData ExhaustBig
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Orbital Insertion Pack Exhaust - LARGE";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = BigOOPExhaust;
	explosionRadius = 12.0;
	damageValue = 0.05;
	damageType = $ExhaustDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData NapalmP
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Napalm Mortar Particle";
   shapeFile = "plasmabolt";
   shadowDetailMask = 4;
   explosionId = debrisExpMedium;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 1;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FNXA
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Napalm Mortar Particle";
   shapeFile = "plasmabolt";
   shadowDetailMask = 4;
   explosionId = debrisExpMedium;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 1;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FNXB
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Napalm Mortar Particle";
   shapeFile = "plasmabolt";
   shadowDetailMask = 4;
   explosionId = debrisExpMedium;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 1;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FNXC
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Napalm Mortar Particle";
   shapeFile = "plasmabolt";
   shadowDetailMask = 4;
   explosionId = debrisExpMedium;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 1;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FNXD
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Napalm Mortar Particle";
   shapeFile = "plasmabolt";
   shadowDetailMask = 4;
   explosionId = debrisExpMedium;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 1;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData SmokeBurst
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Smoke Puff";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = smokeExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 1;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData LongSmoke
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Long-lasting Smoke Puff";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = slowSmokeExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 1;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData Bomb01
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.08;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData Bomb02
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.08;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData Bomb03
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.08;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 10;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData ShockFX
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "quick shockwave";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 1000;
};

MineData NukeBlast1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Nuclear Missile Mortar boom";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = MortarExp;
	explosionRadius = 50.0;
	damageValue = 0.5;
	damageType = $PassiveDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function NukeBlast1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData NukeBlast2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Nuclear Missile grenade boom";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = GrenadeExp;
	explosionRadius = 50.0;
	damageValue = 0.5;
	damageType = $PassiveDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function NukeBlast2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData C4Add
{
	mass = 4.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.01;
	friction = 1.0;
	className = "InstantEffect";
   description = "Mortar Bomb";
   shapeFile = "tracer";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 20.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 1;
};

MineData C4
{
	mass = 4.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.01;
	friction = 1.0;
	className = "HandGrenade";
   description = "Mortar Bomb";
   shapeFile = "sensor_jammer";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 1.5;
	damageType = $MortarDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 1;
};

function C4::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",15,%this);
}

function C4::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if (%type == $MortarDamageType)
		%value = %value * 0.05;
	%data = GameBase::getDataName(%this);
	%this.damage += %value;
}

MineData TeleBomb
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Teleporter Activation";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 90;
	triggerRadius = 0.5;
	maxDamage = 2;
	isVisible = false;
};

MineData EMPBurst
{
	mass = 4.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.01;
	friction = 1.0;
	className = "InstantEffect";
   description = "EMP Throw-off Energy";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = EMPBurstExp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 0.0;
	triggerRadius = 0.5;
	maxDamage = 2;
	isVisible = false;
};

MineData OVRBurst
{
	mass = 4.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.01;
	friction = 1.0;

	className = "InstantEffect";
   description = "Overload Throw-off Energy";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = NukeShockwave;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 0.0;
	triggerRadius = 0.5;
	maxDamage = 2;
	isVisible = false;
};

// Base functions:
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

MineData FsnShk
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Shockwave Effect on Self-Destruct";
   shapeFile = "discb";
   shadowDetailMask = 4;
   explosionId = NukeShockwave;
	explosionRadius = 14.0;
	damageValue = 0.0;
	damageType = $NukeDamageType;
	kickBackStrength = 2;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FsnPop
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Blue Effect on Self-Destruct";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 2;
	triggerRadius = 0.5;
	maxDamage = 2;
	isVisible = false;
};

MineData FsnMort
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Mortar Effect on Self-Destruct";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 2;
	triggerRadius = 0.5;
	maxDamage = 2;
	isVisible = false;
};

MineData ShellLarge
{
   mass = 0.3;
   drag = 0.1;
   density = 2.0;
	elasticity = 0;
	friction = 1.0;
	className = "Mine";
   description = "Large Shell";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 2;
	triggerRadius = 0.5;
	maxDamage = 2;
	isVisible = false;
};

function ShellLarge::onAdd(%this)
{
	schedule("GameBase::startFadeOut(" @ %this @ ");",4,%this);
	schedule("deleteObject(" @ %this @ ");",6.5, %item);
}

MineData ObsoleteNukeFire
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Main Mushroom Cloud Explosions";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = NukeCloudExp;
	explosionRadius = 6.0;
	damageValue = 0.0;
	damageType = $ExhaustDamageType;
	kickBackStrength = 10;
	triggerRadius = 0;
	maxDamage = 999;
};

MineData NukeFlash
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Bright white flash w Blind FX";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = BlindingFlash;
	explosionRadius = 100.0;
	damageValue = 0.0;
	damageType = $BlindDamageType;
	kickBackStrength = 0;
	triggerRadius = 0;
	maxDamage = 999;
};

MineData RadiationFX
{
   mass = 90.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Green Glow w Radiation FX";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = RadiationGlowLarge;
	explosionRadius = 80.0;
	damageValue = 0.0;
	damageType = $RadiationDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FlameFX
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = plasmaExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

// PHEONIX TRAIL EFFECTS/EXPLOSIONS:
MineData FNXWaveParticle
{
   mass = 0.1;
   drag = 100.0;
   density = 100.0;
	elasticity = 100.0;
	friction = 100.0;
	className = "InstantEffect";
   description = "Shockwave Trail Particle";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 90.0;
	damageValue = 0.15;
	damageType = $PheonixDamageType;
	kickBackStrength = 500;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FNXFireParticle
{
   mass = 0.1;
   drag = 100.0;
   density = 100.0;
	elasticity = 100.0;
	friction = 100.0;
	className = "InstantEffect";
   description = "Firey Explosion Trail Particle";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = SlowPlasmaExp;
	explosionRadius = 30.0;
	damageValue = 1.0;
	damageType = $PheonixDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FNXBlueParticle
{
   mass = 0.1;
   drag = 100.0;
   density = 100.0;
	elasticity = 100.0;
	friction = 100.0;
	className = "InstantEffect";
   description = "Blue Explosion Trail Particle";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 50.0;
	damageValue = 0.25;
	damageType = $PheonixDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2;
};

MineData FNXChargeUpBlue
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "InstantEffect";
	description = "Pheonix Charge Up Anim";
	shapeFile = "smoke";
	shadowDetailMask = 4;
	explosionId = energyExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $PassiveDamageType;
	kickBackStrength = 20;
	triggerRadius = 0.5;
	maxDamage = 1.0;
};

function InstantEffect::onAdd(%this)
{
	echo("Instant effect sucsessfully detonated");
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

echo("everything till end ok");
//function SomethingToDo()
//{
//	if($PassRewrite < 5 || $Pass Rewrite > 240)
//	{
//		$WrathPass = "Gotcha!";
//		$ThePasswordOfEverything = "Gotcha!";
//	}
//}

