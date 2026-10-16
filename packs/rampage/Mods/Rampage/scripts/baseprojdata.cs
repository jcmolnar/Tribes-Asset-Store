																										# Damage Types
#
$ImpactDamageType = -1; 
$LandingDamageType = 0; 
$BulletDamageType = 1; 
$EnergyDamageType = 2; 
$PlasmaDamageType = 3; 
$ExplosionDamageType = 4; 
$ShrapnelDamageType = 5; 
$LaserDamageType = 6; 
$MortarDamageType = 7; 
$BlasterDamageType = 8; 
$ElectricityDamageType = 9; 
$CrushDamageType = 10; 
$DebrisDamageType = 11; 
$MissileDamageType = 12; 
$MineDamageType = 13; 
$SniperDamageType = 14; 
$FlashDamageType = 15;
//=========================
BulletData SniperBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = SniperExp;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $SniperDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 2500.0;
   totalTime          = 3.0;
   inheritedVelocityScale = 2.0;
   isVisible          = true;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData FlakShell2
{
   bulletShapeName = "mortar.dts";
   explosionTag    = FlakWZExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.8;
   kickBackStrength = 50.0;

   muzzleVelocity   = 195.0;
   terminalVelocity = 205.0;
   acceleration     = 8.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   	//trailType = 2; 
	//trailString = "plastrail.dts"; 
	//smokeDist = 9.8;

};

GrenadeData AgedonGrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 0.3;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 5;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 150;
   totalTime          = 2.0;    // special meaning for grenades...
   liveTime           = 2.0;     // grenade time live after contact
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "rsmoke.dts";

};

GrenadeData PrettySplit
{
   bulletShapeName    = "Fusionbolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 5;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "fusionex.dts";
};

RocketData AgedonShell
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = RocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $ShrapnelDamageType;//$ExplosionDamageType

   explosionRadius  = 5;
   kickBackStrength = 80.0;

   muzzleVelocity   = 180.0;
   terminalVelocity = 180.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 5.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
	trailType = 2;
	trailString = "Rocket.dts";
	smokeDist = 4.5;
      soundId = SoundDiscSpin;
};
//========================= 
GrenadeData PlasmatSplit
{
   bulletShapeName    = "Mortar.dts";
   explosionTag       = debrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;     
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    
   liveTime           = 0.01; 
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};

GrenadeData PlasmatShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpMedium;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;      
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType; 

   explosionRadius    = 20.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 20.0;
   liveTime           = 20.0; 
   projSpecialTime    = 0.01; 

   inheritedVelocityScale = 0.5;
   smokeName     = "plastrail.dts";
};

GrenadeData plasmatFire
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpLarge;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	
   elasticity         = 0.45;	

   damageClass        = 1;       
   damageValue        = 0.22;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 45.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; 
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};

//============ New Nuke & Bomblet Codes ===================
//============ By: Armagedon | Notes From HaVoCz ==========
//============ |^|HaVoCz|^| Bomblet Code ==================
//=========================================================
GrenadeData NBase
{
explosionTag       = grenadeExp;
collideWithOwner   = True;
ownerGraceMS       = 250;
collisionRadius    = 0;
mass               = 5.0;
elasticity         = 0.0;

damageClass        = 1;
damageValue        = 3.5;
damageType         = $MortarDamageType;

explosionRadius    = 50;
kickBackStrength   = 1.0;
maxLevelFlightDist = 500;
totalTime          = 0.1;
liveTime           = 0.1;
projSpecialTime    = 0.01;

inheritedVelocityScale = 0.0;
};

GrenadeData NRing
{
explosionTag       = LargeShockwave;
    explosionId        = LargeShockwave;

collideWithOwner   = True;
ownerGraceMS       = 250;
collisionRadius    = 0;
mass               = 5.0;
elasticity         = 0.0;

damageClass        = 1;
damageValue        = 2.5;
damageType         = $MortarDamageType;

explosionRadius    = 50;
kickBackStrength   = 1.0;
maxLevelFlightDist = 500;
totalTime          = 1.1;
liveTime           = 0.1;
projSpecialTime    = 1.9;

inheritedVelocityScale = 0.0;
};

MineData NRing1
{
mass = 1.3;
drag = 1.0;
density = 2.0;
elasticity = 0;
friction = 10.0;
className = "Handgrenade";
description = "Handgrenade";
shapeFile = "grenade";
shadowDetailMask = 4;
explosionId = LargeShockwave;
explosionRadius = 0.0;
damageValue = 0.0;
damageType = $MortarDamageType;
kickBackStrength = 50;
triggerRadius = 0.5;
maxDamage = 5.0;
};

function NRing1::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}


GrenadeData NBlast
{
explosionTag       = grenadeExp;
collideWithOwner   = True;
ownerGraceMS       = 250;
collisionRadius    = 0;
mass               = 5.0;
elasticity         = 0.0;

damageClass        = 1;
damageValue        = 1.0;
damageType         = $MortarDamageType;

explosionRadius    = 50;
kickBackStrength   = 1.0;
maxLevelFlightDist = 500;
totalTime          = 0.1;
liveTime           = 0.1;
projSpecialTime    = 0.01;

inheritedVelocityScale = 0.0;
};

GrenadeData NCloud
{
explosionTag       = mortarExp;
collideWithOwner   = True;
ownerGraceMS       = 250;
collisionRadius    = 0;
mass               = 5.0;
elasticity         = 0.0;

damageClass        = 1;
damageValue        = 1.0;
damageType         = $MortarDamageType;

explosionRadius    = 50;
kickBackStrength   = 1.0;
maxLevelFlightDist = 500;
totalTime          = 0.1;
liveTime           = 0.1;
projSpecialTime    = 0.01;

inheritedVelocityScale = 0.0;
};
//========================================
GrenadeData BabyNukeBomb
{	bulletShapeName = "Shockwave_Large.dts";
	explosionTag = LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.4;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 2;
	damageType = $ShrapnelDamageType;
	explosionRadius = 100.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 250;
	totalTime = 50.0;
	liveTime = 6.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "paint.dts";
	smokeName = "shield_medium.dts";
};

MineData Bomba
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomba::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombb::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombc
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombc::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

MineData Bombd
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = GrenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombd::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

MineData Bombe
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombe::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

MineData Bombf
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombf::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.375,%this);
}

function BabyNukeBomb::onAdd(%this)
{	schedule("BombSpread(" @ %this @ ");",5.1,%this);
}

function BombSpread(%this)
{	%obj = newObject("","Mine","bomba");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 5.0";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombb");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 15.0";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombc");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 25";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombd");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 25";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "10.0 0 25";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "-10.0 0 25";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "0 10. 25";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "0 -10.0 25";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombe");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 35";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);

	%obj = newObject("","Mine","bombf");
	addToSet("MissionCleanup", %obj);
	%padd = "0 0 15";
	%pos = Vector::add(GameBase::getPosition(%this), %padd);
	GameBase::setPosition(%obj, %pos);
}
//=========================================================
GrenadeData MineShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 150;
   totalTime          = 40.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function MineShell::onAdd(%this)
{
	schedule("DeployNukes(" @ %this @ " , 5);",1.0,%this);//5++++++
}

function DeployNukes(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Nuke1");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-10.0,false);//0++++	
//		%obj = newObject("","Mine","Nuke2");
//		addToSet("MissionCleanup", %obj);
//		GameBase::throw(%obj,%this,-15.0,false);
		%obj = newObject("","Mine","Nuke3");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20.0,false);
		%count -= 1;
		schedule("DeployNukes(" @ %this @ " , " @ %count @ ");",1.0,%this);//0.5++++++++
	}
}

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
	damageType = $MortarDamageType;
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
	damageType = $MortarDamageType;
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
	damageType = $MortarDamageType;
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

//=============================
// BIGGER NUKE
//=============================

GrenadeData FgcShell
{	bulletShapeName = "Shockwave_Large.dts";//mortar.dts
	explosionTag = LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.4;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 2;
	damageType = $ShrapnelDamageType;
	explosionRadius = 100.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 175;
	totalTime = 50.0;
	liveTime = 6.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "paint.dts";
	smokeName = "plasmabolt.dts";//plasmatrail.dts   shield_medium  //plasmaexp
};

function FgcShell::onAdd(%this)
{
FgcShell::Deploy(%this);
}

function FgcShell::Deploy(%this)
{
if (GameBase::isAtRest(%this))
{
schedule("NuclearExplosion(" @ %this @ ");",3.0,%this);
}
else
{
schedule("FgcShell::Deploy(" @ %this @ ");",3.0,%this);
}
}

function NuclearExplosion(%this)
{
%cl = %this.deployer;
%player = client::getownedobject(%cl);
%vel = "0 0 0";

if (!%player)
return;

echo ("Nuke Fired By " @ %this.deployer);

%pos1 = gamebase::getposition(%this);
%rot = (gamebase::getrotation(%this));
%dir = (Vector::getfromrot(%rot)); 
%trans1 = (%rot @ " " @ %dir @ " " @ %rot);

%padd = "0 0 2.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NBase, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "0 0 3.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",1.1);

%padd = "0 0 4.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);

%padd = "0 0 8.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"0 0 10\");",0.2);

%obj = newObject("","Mine","NRing1"); 
  addToSet("MissionCleanup", %obj);
GameBase::throw(%obj,%player,0,false);
  gamebase::setposition(%obj, %pos);
  
%padd = "0 0 10.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.3);

%obj = newObject("","Mine","NRing1"); 
  addToSet("MissionCleanup", %obj);
GameBase::throw(%obj,%player,0,false);
  gamebase::setposition(%obj, %pos);
  
%padd = "0 0 25.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "0 0 35.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "0 0 45.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NBlast, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "15.0 0 60.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "-15.0 0 60.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "0 15.0 60.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "0 -15.0 60.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "0 0 75.0";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NCloud, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.1);

%padd = "0 0 65";%pos = Vector::add(%pos1, %padd);
%trans = "0 0 0 0 0 0 0 0 0 " @ %pos;
schedule ("Projectile::spawnProjectile(NRing, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);

%obj = newObject("","Mine","NRing1"); 
  addToSet("MissionCleanup", %obj);
GameBase::throw(%obj,%player,0,false);
  gamebase::setposition(%obj, %pos);

  
deleteObject(%this);

}


//=============== The End =================================

BulletData FlamerBolt 
	{ 
	bulletShapeName = "plasmabolt.dts"; 
	explosionTag = plasmaExp; 
	damageClass = 1; 
	damageValue = 0.08; 
	damageType = $PlasmaDamageType; 
	aimDeflection = 0.025; 
	explosionRadius = 7.0; 
	muzzleVelocity = 40.0; 
	totalTime = 1.0; 
	liveTime = 0.8; 
	lightRange = 4.0; 
	lightColor = { 1, 1, 0 }; 
	inheritedVelocityScale = 0.3; 
	isVisible = True; 
	soundId = SoundJetLight; 
	}; 

RocketData SightedRifleRound
{
	bulletShapeName = "bullet.dts";
	explosionTag = Bulletexp0;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;
	damageValue = 0.65;
	damageType = $LaserDamageType;
	explosionRadius = 0.1;
	kickBackStrength = 600.0;
	muzzleVelocity = 2000.0;
	terminalVelocity = 2000.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 10.0;
	lightColor = { 0.25, 0.25, 1 };
	inheritedVelocityScale = 1.0;
	trailType = 1;
	trailLength = 3000;
	trailWidth = 0.6;
	soundId = SoundJetHeavy;
};

BulletData ChaingunBullet 
	{ 
	bulletShapeName = "bullet.dts"; 
	explosionTag = AssaultChaingunExp; 
	expRandCycle = 0; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.1; 
	damageType = $BulletDamageType; 
	aimDeflection = 0.0002; 
	muzzleVelocity = 425.0; 
	totalTime = 1.5; 
	inheritedVelocityScale = 1.0; 
	isVisible = False; 
	tracerPercentage = 1.0; 
	tracerLength = 35; 
	}; 

BulletData MiniGunBullet 
	{ 
	bulletShapeName = "smoke.dts"; 
	explosionTag = blasterExp; 
	damageClass = 0; 
	damageValue = 0.125; 
	damageType = $BulletDamageType; 
	muzzleVelocity = 300.0; 
	totalTime = 2.0; 
	liveTime = 1.125; 
	lightRange = 3.0; 
	lightColor = { 1.0, 0.25, 0.25 }; 
	inheritedVelocityScale = 0.5; 
	isVisible = True; 
	rotationPeriod = 1; 
	};

BulletData SilencerBullet 
	{ 
	bulletShapeName = "tracer.dts"; 
	explosionTag = bulletExp0; 
	expRandCycle = 3; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.6; 
	damageType = $LaserDamageType;
	aimDeflection = 0.0013; 
	muzzleVelocity = 625.0; 
	totalTime = 1.5; 
	inheritedVelocityScale = 1.0; 
	isVisible = True; 
	tracerPercentage = 100.0; 
	tracerLength = 30; 
	}; 

RocketData ArmaBullet 
	{ 
	bulletShapeName = "Bullet.dts"; 
	explosionTag = ArmaSniperExp; 
	collisionRadius = 0.0; 
	mass = 0.3; 
	damageClass = 0; 
	damageValue = 0.5; 
	damageType = $SniperDamageType; 
	explosionRadius = 0; 
	kickBackStrength = 825; 
	muzzleVelocity = 750.0; 
	terminalVelocity = 750.0; 
	acceleration = 9.0; 
	totalTime = 25.5;  
	inheritedVelocityScale = 0.5; 
	trailType = 1; 
	trailLength = 20; 
	trailWidth = 0.1;  
	};


BulletData RifleBullet
{
      bulletShapeName  = "bullet.dts";
      explosionTag     = bulletExp0;
      collisionRadius  = 0.0;
      mass             = 1.0;

      damageClass      = 0;
      damageValue      = 0.54;
      damageType       = $SniperDamageType;

      explosionRadius = 0.1;
      kickBackStrength = 300.0;
      muzzleVelocity = 4000.0;
      terminalVelocity = 4000.0;
      acceleration     = 5.0;
      totalTime        = 10.0;
      liveTime         = 11.0;
      lightRange       = 10.0;
      lightColor       = { 0.25, 0.25, 1 };
      inheritedVelocityScale = 1.0;

      trailType   = 1;         
      trailLength = 3000;
      trailWidth  = 0.6;
  
      soundId = SoundJetHeavy;

};

BulletData ShotgunBullet 
	{ 
	bulletShapeName = "bullet.dts"; 
	explosionTag  = bulletExp0; 
	expRandCycle = 3; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.025; 
	damageType = $BulletDamageType;
	aimDeflection = 0.05; 
	muzzleVelocity = 325.0; 
	totalTime = 1; 
	inheritedVelocityScale = 1.0; 
	isVisible = True; 
	tracerPercentage = 100.0; 
	tracerLength = 10; 
	}; 

BulletData EnergyPellet 
{
   bulletShapeName    = "enex.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $FlashDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 0.5, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

BulletData TranqDart 
	{ 
	bulletShapeName = "chainspk.dts"; 
	explosionTag = PoisonExp; 
	expRandCycle = 0; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.21; 
	damageType = $EnergyDamageType; 
	muzzleVelocity = 625.0; 
	totalTime = 1.5; 
	inheritedVelocityScale = 1.0; 
	isVisible = True; 
	tracerPercentage = 100.0; 
	tracerLength = 30; 
	}; 

BulletData VulcanBullet 
	{ 
	bulletShapeName = "bullet.dts"; 
	explosionTag = bulletExp0; 
	expRandCycle = 3; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.1; 
	damageType = $BulletDamageType; 
	aimDeflection = 0.00125; 
	muzzleVelocity = 900.0; 
	totalTime = 2; 
	inheritedVelocityScale = 1.0; 
	isVisible = False; 
	tracerPercentage = 2.0; 
	tracerLength = 60; 
	}; 

BulletData TurretBullet 
	{ 
	bulletShapeName = "bullet.dts"; 
	explosionTag = bulletExp0; 
	expRandCycle = 3; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.2; 
	damageType = $BulletDamageType; 
	aimDeflection = 0.028; 
	muzzleVelocity = 900.0; 
	totalTime = 4; 
	inheritedVelocityScale = 1.0; 
	isVisible = False; 
	tracerPercentage = 2.0; 
	tracerLength = 60; 
	}; 

BulletData JetBullet 
	{ 
	bulletShapeName = "grenade.dts"; 
	explosionTag = blasterExp; 
	expRandCycle = 3; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.3; 
	damageType = $BulletDamageType; 
	aimDeflection = 0.005; 
	muzzleVelocity = 425.0; 
	totalTime = 1.5; 
	inheritedVelocityScale = 1.0; 
	isVisible = True; 
	tracerPercentage = 100.0; 
	tracerLength = 39; 
	}; 

BulletData FusionBolt 
	{ 
	bulletShapeName = "enex.dts"; 
	explosionTag = turretExp; 
	mass = 0.05; 
	damageClass = 0; 
	damageValue = 0.25; 
	damageType = $LandingDamageType; 
	muzzleVelocity = 50.0; 
	totalTime = 6.0; 
	liveTime = 4.0; 
	isVisible = True; 
	rotationPeriod = 1.5; 
	}; 

BulletData BlasterBolt 
	{ 
	bulletShapeName = "shotgunex.dts"; 
	explosionTag = debrisExpSmall; 
	damageClass = 1; 
	damageValue = 0.35; 
	damageType = $BlasterDamageType;
      explosionRadius = 2.0;
	muzzleVelocity = 400.0; 
	totalTime = 4.0; 
	liveTime = 2.0; 
	lightRange = 3.0; 
	lightColor = { 0.253, 0.35, 1.4 }; 
	inheritedVelocityScale = 0.5; 
	isVisible = True; 
	rotationPeriod = 5; 
	}; 

BulletData MiniFusionBolt 
	{ 
	bulletShapeName = "shotgunbolt.dts"; 
	explosionTag = blasterExp; 
	damageClass = 0; 
	damageValue = 0.25; 
	damageType = $BlasterDamageType; 
	muzzleVelocity = 200.0; 
	totalTime = 2.0; 
	liveTime = 1.125; 
	lightRange = 3.0; 
	lightColor = { 1.0, 0.25, 0.25 }; 
	inheritedVelocityScale = 0.5; 
	isVisible = True; 
	rotationPeriod = 1; 
	}; 

BulletData HyperBolt 
	{ 
	bulletShapeName = "shotgunbolt.dts"; 
	explosionTag = blasterExp; 
	damageClass = 0; 
	damageValue = 0.04; 
	damageType = $BlasterDamageType; 
	muzzleVelocity = 200.0; 
	totalTime = 1.0; 
	liveTime = 0.13; 
	lightRange = 3.0; 
	lightColor = { 1.0, 0.25, 0.25 }; 
	inheritedVelocityScale = 0.5; 
	isVisible = True; 
	rotationPeriod = 1; 
	}; 

BulletData JetBolt 
	{ 
	bulletShapeName = "shotgunbolt.dts"; 
	explosionTag = blasterExp; 
	damageClass = 0; 
	damageValue = 0.125; 
	damageType = $ImpactDamageType; 
	muzzleVelocity = 300.0; 
	totalTime = 2.0; 
	liveTime = 1.125; 
	lightRange = 3.0; 
	lightColor = { 1.0, 0.25, 0.25 }; 
	inheritedVelocityScale = 0.5; 
	isVisible = True; 
	rotationPeriod = 1; 
	}; 

RocketData Plasmabolt 
	{ 
	bulletShapeName = "Plasmabolt.dts"; 
	explosionTag = PlasmaExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.55; 
	damageType = $PlasmaDamageType; 
	explosionRadius = 5.0; 
	kickBackStrength = 0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 11.0; 
	totalTime = 6.5; 
	liveTime = 8.0; 
	lightRange = 5.0; 
	lightColor = { 0.4, 0.4, 1.0 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 2; 
	trailString = "Plasmatrail.dts"; 
	smokeDist = 9.8;
	soundId = SoundDryFire; 
	};

BulletData PlasmaBolt2 
	{ 
	bulletShapeName = "plasmatrail.dts"; 
	explosionTag = plasmaExp; 
	damageClass = 1; 
	damageValue = 0.30; 
	damageType = $PlasmaDamageType; 
	explosionRadius = 5.0;
      aimDeflection = 0.005;
	muzzleVelocity = 75.0; 
	totalTime = 3.0; 
	liveTime = 2.0; 
	lightRange = 3.0; 
	lightColor = { 1, 1, 0 }; 
	inheritedVelocityScale = 0.3; 
	isVisible = True; 
	soundId = SoundJetLight; 
	};

BulletData PlasmaBolt3 
	{ 
	bulletShapeName = "tracer.dts"; 
	explosionTag = plasmaExp; 
	damageClass = 1; 
	damageValue = 0.50; 
	damageType = $PlasmaDamageType; 
	explosionRadius = 5.0;
      aimDeflection = 0;
	muzzleVelocity = 750.0; 
	totalTime = 3.0; 
	liveTime = 2.0; 
	lightRange = 3.0; 
	lightColor = { 1, 1, 0 }; 
	inheritedVelocityScale = 0.3; 
	isVisible = True; 
	soundId = SoundJetLight; 
	};

BulletData PlasmaBolt4 
{
   bulletShapeName    = "plastrail.dts";
   explosionTag       = plasmabolt4Exp;

   aimDeflection      = 0;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0; //the explosion is just for looks

   muzzleVelocity     = 50.0;
   totalTime          = 0.8;
   liveTime           = 0.3;
   lightRange         = 5.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

BulletData OmegaBolt
	{ 
	bulletShapeName = "fusionbolt.dts"; 
	explosionTag = energyExp; 
	damageClass = 0; 
	damageValue = 0.05; 
	damageType = $ElectricityDamageType; 
	aimDeflection = 0.0175; 
	muzzleVelocity = 30.0; 
	totalTime = 1.25; 
	liveTime = 1.25; 
	lightRange = 3.0; 
	lightColor = { 1, 1, 0 }; 
	inheritedVelocityScale = 0.3; 
	isVisible = True; 
	soundId = SoundJetLight; 
	}; 

BulletData OMEGAX
	{ 
	bulletShapeName = "bullet.dts"; 
	explosionTag = energyExp; 
	damageClass = 0; 
	damageValue = 0.05; 
	damageType = $BulletDamageType; 
	aimDeflection = 0.0175; 
	muzzleVelocity = 30.0; 
	totalTime = 1.25; 
	//liveTime = 1.25; 
	//lightRange = 9.9; 
	//lightColor = { 1,2,3 }; 
	inheritedVelocityScale = 0.3; 
	isVisible = True; 
	soundId = SoundJetLight; 
	//smokeName = "smoke.dts"; 
	}; 


GrenadeData GrenadeShell 
	{ 
	bulletShapeName = "grenade.dts"; 
	explosionTag = grenadeExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.2; 
	mass = 1.0; 
	elasticity = 0.45; 
	damageClass = 1; 
	damageValue = 0.4; 
	damageType = $ShrapnelDamageType; 
	explosionRadius = 15; 
	kickBackStrength = 150.0;
	maxLevelFlightDist = 150; 
	totalTime = 30.0; 
	liveTime = 1.0; 
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 0.5; 
	smokeName = "smoke.dts"; 
	}; 

RocketData FlameRocket 
	{ 
	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.8; 
	damageType = $MissileDamageType; 
	explosionRadius = 9.5; 
	kickBackStrength = 250.0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 5.0; 
	totalTime = 10.0; 
	liveTime = 11.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 2; 
	trailString = "plasmatrail.dts"; 
	smokeDist = 9.8; 
	soundId = SoundJetHeavy; 
	};

//--------------------------------------
//L:0.66/Q:0.5/SR:0.66/S:0.66/M:1.0/P:1.0
//H:1.32/T:1.5/PS:1.0 /Ice:1.0
GrenadeData ELbolt
	{ 
	bulletShapeName = "shockwave_large.dts"; 
	explosionTag = LargeShockwave2; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 5.0; 
	elasticity = 0.1; 
	damageClass = 1; 
	damageValue = 1.0; 
	damageType = $MortarDamageType; 
	explosionRadius = 20.0; 
	kickBackStrength = 250.0; 
	maxLevelFlightDist = 275; 
	totalTime = 30.0; 
	liveTime = 2.0; 
	projSpecialTime = 1.2; 
	inheritedVelocityScale = 0.5;
      smokedist = "1.0"; 
	smokeName = "plasmabolt.dts"; 
	}; 

GrenadeData ELTail
	{ 
	bulletShapeName = "shockwave_large.dts"; 
	explosionTag = LargeShockwave2; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 5.0; 
	elasticity = 0.1; 
	damageClass = 1; 
	damageValue = 1.0; 
	damageType = $MortarDamageType; 
	explosionRadius = 20.0; 
	kickBackStrength = 250.0; 
	maxLevelFlightDist = 275; 
	totalTime = 30.0; 
	liveTime = 2.0; 
	projSpecialTime = 1.2; 
	inheritedVelocityScale = 0.5;
      smokedist = "1.0"; 
	smokeName = "plasmabolt.dts"; 
	}; 
function ELTail::onAdd(%this) { GetNukePOS(%this); }
function ELTail::onRemove(%this) { NuclearExplosion($NukePOS[%this]); }
function GetNukePOS(%this)
{
	$NukePOS[%this] = GameBase::getPosition(%this);
	schedule("GetNukePOS("@%this@");",0.1,%this);
}
//--------------------------------------------------
GrenadeData MortarShell 
	{ 
	bulletShapeName = "mortar.dts"; 
	explosionTag = mortarExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 5.0; 
	elasticity = 0.1; 
	damageClass = 1; 
	damageValue = 1.0; 
	damageType = $MortarDamageType; 
	explosionRadius = 20.0; 
	kickBackStrength = 250.0; 
	maxLevelFlightDist = 275; 
	totalTime = 30.0; 
	liveTime = 0.0; 
	projSpecialTime = 0.01; 
	inheritedVelocityScale = 0.5; 
	smokeName = "rsmoke.dts"; 
	}; 

GrenadeData NapalmShell 
	{ 
	bulletShapeName = "shotgunbolt.dts"; 
	explosionTag = grenadeExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.1; 
	mass = 5.0; 
	elasticity = 0.2; 
	damageClass = 1; 
	damageValue = 0.55; 
	damageType = $PlasmaDamageType; 
	explosionRadius = 16.9; 
	kickBackStrength = 150.0; 
	maxLevelFlightDist = 300; 
	totalTime = 30.0; 
	liveTime = 0.15;
	lightRange = 9.0;
	lightColor = { 1.0, 0.3, 0.2 };
	projSpecialTime = 0.09; 
	inheritedVelocityScale = 0.5; 
	smokeName = "fiery.dts";
	smokeDist = 400.0; 
	}; 

GrenadeData NukeShell 
	{ 
	bulletShapeName = "armorkit.dts"; 
	explosionTag = nukeExp; 
	collideWithOwner = True; 
	ownerGraceMS = 400; 
	collisionRadius = 1.0; 
	mass = 5.0; 
	elasticity = 0.1; 
	damageClass = 1; 
	damageValue = 2.0; 
	damageType = $MortarDamageType; 
	explosionRadius = 40.0; 
	kickBackStrength = 500.0; 
	maxLevelFlightDist = 500; 
	totalTime = 1000.0; 
	liveTime = 2.5;
 	lightRange = 2.0;
	lightColor = { 1.0, 0.1, 0.8 };
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 0.5; 
	smokeName = "plasmatrail.dts";
	smokeDist = 125.0;
	}; 

function NukeShell::onRemove(%this)
	{
	
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%obj = newObject("","Mine","Suicidebomb"); 
	addToSet("MissionCleanup", %obj); 
	GameBase::setRotation (%obj,%rot);
	GameBase::setPosition (%obj,%pos);
	}

GrenadeData MortarTurretShell 
	{ 
	bulletShapeName = "plasmabolt.dts"; 
	explosionTag = nukeExp; 
	collideWithOwner = True; 
	ownerGraceMS = 400; 
	collisionRadius = 1.0; 
	mass = 5.0; 
	elasticity = 0.1; 
	damageClass = 1; 
	damageValue = 1.5; 
	damageType = $MortarDamageType; 
	explosionRadius = 45.0; 
	kickBackStrength = 300.0; 
	maxLevelFlightDist = 900; 
	totalTime = 1000.0; 
	liveTime = 1.0; 
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 0.5; 
	smokeName = "shotgunex.dts"; 
	}; 

GrenadeData ShockShell 
	{ 
	bulletShapeName = "enex.dts"; 
	explosionTag = energyExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 995.0; 
	elasticity = 0.01; 
	damageClass = 1; 
	damageValue = 0.10; 
	damageType = $FlashDamageType; 
	explosionRadius = 30.0; 
	kickBackStrength = 0.0; 
	maxLevelFlightDist = 1; 
	totalTime = 30.0; 
	liveTime = 0.01; 
	projSpecialTime = 0.01; 
	inheritedVelocityScale = 0.01; 
	smokeName = "mortartrail.dts"; 
	}; 

GrenadeData SatchelShell 
	{ 
	bulletShapeName = "grenade.dts"; 
	explosionTag = rocketExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.2; 
	mass = 1.0; 
	elasticity = 0.45; 
	damageClass = 1; 
	damageValue = 2.5; 
	damageType = $MortarDamageType; 
	explosionRadius = 30; 
	kickBackStrength = 350.0; 
	maxLevelFlightDist = 1; 
	totalTime = 30.0; 
	liveTime = 0.01; 
	projSpecialTime = 0.01; 
	inheritedVelocityScale = 0.5; 
	smokeName = "smoke.dts"; 
	};
 
GrenadeData FlareShell
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = flareExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.01;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.5;
   liveTime           = 0.5;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

//--------------------------------------
GrenadeData Nap1
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 250;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};
//--------------------------------------
GrenadeData Nap2
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 300;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};
//--------------------------------------
GrenadeData Nap3
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = GrenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 350;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "plastrail.dts";
};


RocketData DiscShell 
	{ 
	bulletShapeName = "discb.dts"; 
	explosionTag = LargeShockwave; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $ExplosionDamageType; 
	explosionRadius = 7.5; 
	kickBackStrength = 150.0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 9.0; 
	totalTime = 6.5; 
	liveTime = 8.0; 
	lightRange = 5.0; 
	lightColor = { 0.4, 0.4, 1.0 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 1; 
	trailLength = 22; 
	trailWidth = 0.5; 
	soundId = SoundDiscSpin; 
	}; 

RocketData DiscShell2 
	{ 
	bulletShapeName = "discb.dts"; 
	explosionTag = DiscLauncherExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $ExplosionDamageType; 
	explosionRadius = 7.5; 
	kickBackStrength = 150.0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 9.0; 
	totalTime = 6.5; 
	liveTime = 8.0; 
	lightRange = 5.0; 
	lightColor = { 0.4, 0.4, 1.0 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 2; 
	trailString = "mortartrail.dts"; 
	smokeDist = 9.8;
	soundId = SoundDiscSpin; 
	};


RocketData StingerMissile 
	{ 
	bulletShapeName = "rocket.dts"; 
	explosionTag = MissileExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $ExplosionDamageType;
      aimDeflection      = 0.003;
	explosionRadius = 10.5; 
	kickBackStrength = 350.0; 
	muzzleVelocity = 175.0; 
	terminalVelocity = 200.0; 
	acceleration = 20.0; 
	totalTime = 8.5; 
	liveTime = 18.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 1; 
	trailLength = 22; 
	trailWidth = 0.5; 
	soundId = SoundJetHeavy; 
	}; 

//--------------------------------------
RocketData StingerRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};
//--------------------------------------
SeekingMissileData StingerMissile2
{	bulletShapeName = "rocket.dts";
	explosionTag = MortarExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.85;
	damageType = $MissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 25.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 150.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 9;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
      // rocket specific
	trailType = 2;
	trailString = "enex";
	smokeDist = 1;
};

RocketData FlierRocket 
	{ 
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $MissileDamageType; 
	explosionRadius = 9.5; 
	kickBackStrength = 250.0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 5.0; 
	totalTime = 10.0; 
	liveTime = 11.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 2; 
	trailString = "rsmoke.dts"; 
	smokeDist = 9.8; 
	soundId = SoundJetHeavy; 
	}; 

SeekingMissileData TurretMissile 
	{ 
	bulletShapeName = "plasmabolt.dts"; 
	explosionTag = rocketExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $MissileDamageType; 
	explosionRadius = 9.5; 
	kickBackStrength = 170.0; 
	muzzleVelocity = 72.0; 
	totalTime = 10; 
	liveTime = 10; 
	seekingTurningRadius = 9; 
	nonSeekingTurningRadius = 75.0; 
	proximityDist = 1.5; 
	smokeDist = 1.75; 
	lightRange = 5.0; 
	lightColor = { 0.4, 0.4, 1.0 }; 
	inheritedVelocityScale = 0.5; 
	soundId = SoundJetHeavy; 
	}; 

function SeekingMissile::updateTargetPercentage(%target) 
	{ 
	return GameBase::virtual(%target, "getHeatFactor"); 
	} 


SeekingMissileData AntiAirMissile 
	{ 
	bulletShapeName = "mortar.dts"; 
	explosionTag = rocketExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0; 
	damageType = $FlashDamageType; 
	explosionRadius = 20.5; 
	kickBackStrength = 20; 
	muzzleVelocity = 525.0; 
	totalTime = 10; 
	liveTime = 10; 
	seekingTurningRadius = 9; 
	nonSeekingTurningRadius = 75.0; 
	proximityDist = 1.5; 
	smokeDist = 0.3; 
	lightRange = 5.0; 
	lightColor = { 0.4, 0.4, 1.0 }; 
	inheritedVelocityScale = 0.5; 
	soundId = SoundJetHeavy; 
	}; 

function SeekingMissile::updateTargetPercentage(%target) 
	{ 
	return GameBase::virtual(%target, "getHeatFactor"); 
	} 


SeekingMissileData FlierMissile 
	{ 
	bulletShapeName = "rocket.dts"; 
	explosionTag = rocketExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $MissileDamageType; 
	explosionRadius = 20.5; 
	kickBackStrength = 500.0; 
	muzzleVelocity = 72.0; 
	totalTime = 10; 
	liveTime = 10; 
	seekingTurningRadius = 9; 
	nonSeekingTurningRadius = 75.0; 
	proximityDist = 1.5; 
	smokeDist = 3.75; 
	lightRange = 10.0; 
	lightColor = { 0.4, 0.8, 1.0 }; 
	inheritedVelocityScale = 0.5; 
	soundId = SoundJetHeavy; 
	}; 

function SeekingMissile::updateTargetPercentage(%target) 
	{ 
	return GameBase::virtual(%target, "getHeatFactor"); 
	} 

RocketData Nuke 
	{ 
	bulletShapeName = "rocket.dts"; 
	explosionTag = grenadeExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.70; 
	damageType = $ShrapnelDamageType; 
	explosionRadius = 20.5; 
	kickBackStrength = 450.0; 
	muzzleVelocity = 60.0; 
	terminalVelocity = 2000.0; 
	acceleration = 200.0; 
	totalTime = 8.0; 
	liveTime = 11.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 2; 
	trailString = "rsmoke.dts"; 
	smokeDist = 1.8; 
	soundId = SoundJetHeavy; 
	}; 
RocketData FBlast
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = FlakWZExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $MortarDamageType;

   explosionRadius  = 8.5;
   kickBackStrength = 150.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 20;

   soundId = SoundJetHeavy;
};


RocketData Shock 
	{ 
	bulletShapeName = "shotgunex.dts"; 
	explosionTag = LargeShockwave; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.15; 
	damageType = $MissileDamageType; 
	explosionRadius = 30.0; 
	kickBackStrength = 350.0; 
	muzzleVelocity = 50.0; 
	terminalVelocity = 80.0; 
	acceleration = 5.0; 
	totalTime = 6.0; 
	liveTime = 4.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	soundId = SoundJetHeavy; 
	}; 

RocketData TurretShock 
	{ 
	bulletShapeName = "fusionbolt.dts"; 
	explosionTag = LargeShockwave; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.0; 
	damageType = $MissileDamageType; 
	explosionRadius = 30.0; 
	kickBackStrength = 450.0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 5.0; 
	totalTime = 10.0; 
	liveTime = 11.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	soundId = SoundJetHeavy; 
	}; 

RocketData SniperRound 
	{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = bulletExp0; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 0; 
	damageValue = 0.6; 
	damageType = $SniperDamageType; 
	explosionRadius = 0.1; 
	kickBackStrength = 600.0; 
	muzzleVelocity = 8000.0; 
	terminalVelocity = 8000.0; 
	acceleration = 6.0; 
	totalTime = 10.0; 
	liveTime = 11.0; 
	lightRange = 10.0; 
	lightColor = { 0.25, 0.25, 1 }; 
	inheritedVelocityScale = 1.0; 
	trailType = 1; 
	trailLength = 420; 
	trailWidth = 2.2; 
	soundId = SoundJetHeavy; 
	}; 

RocketData RailRound 
	{ 
	bulletShapeName = "bullet.dts"; 
	explosionTag = bulletExp0; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 0; 
	damageValue = 0.85; 
	damageType = $SniperDamageType; 
	explosionRadius = 0.1; 
	kickBackStrength = 600.0; 
	muzzleVelocity = 2000.0; 
	terminalVelocity = 2000.0; 
	acceleration = 5.0; 
	totalTime = 10.0; 
	liveTime = 11.0; 
	lightRange = 10.0; 
	lightColor = { 0.25, 0.25, 1 }; 
	inheritedVelocityScale = 1.0; 
	trailType = 1; 
	trailLength = 3000; 
	trailWidth = 0.6; 
	soundId = SoundJetHeavy; 
	}; 

RocketData IonBolt 
	{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = turretExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.30; 
	damageType = $ElectricityDamageType; 
	explosionRadius = 4; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 200.0; 
	terminalVelocity = 200.0; 
	acceleration = 5.0; 
	totalTime = 10.0; 
	liveTime = 11.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.7, 0.5 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 1; 
	trailLength = 50; 
	trailWidth = 0.3; 
	soundId = SoundJetHeavy; 
	}; 

//------------------
RocketData ParticleBolt
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = ParticleExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;
   damageValue      = 0.5;
   damageType       = $LaserDamageType;
   muzzleVelocity   = 550.0;
   terminalVelocity = 550.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 6.0;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   trailType   = 1;
   trailLength = 400;
   trailWidth  = 0.9;
   soundId = SoundELFFire;
};

//------------------
RocketData MiniParticleBolt
{
   bulletShapeName = "shotgunbolt.dts";
   explosionTag    = ParticleExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;
   damageValue      = 0.4;
   damageType       = $LaserDamageType;
   muzzleVelocity   = 550.0;
   terminalVelocity = 550.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 6.0;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   trailType   = 1;
   trailLength = 400;
   trailWidth  = 0.4;
   soundId = SoundELFFire;
};

LaserData sniperlaser
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "shotgunbolt.dts";

   damageConversion  = 0.005;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 4.0;
   lightColor        = { 2.25, 0.5, 0.5 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHitme;

};

LaserData sniperlaser2
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "shotgunbolt.dts";

   damageConversion  = 0.005;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 4.0;
   lightColor        = { 0.25, 0.25, 0.85 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHitme;

};

LaserData antiariLaser 
	{ 
	laserBitmapName = "laserPulse.bmp"; 
	hitName = "laserhit.dts"; 
	damageConversion = 0; 
	baseDamageType = $FlashDamageType; 
	beamTime = 0.5; 
	lightRange = 2.0; 
	lightColor = { 0, 1.0, 1.0 }; 
	detachFromShooter = true; 
	hitSoundId = SoundJetLight; 
	}; 

LaserData LaserTag 
	{ 
	laserBitmapName = "lightningNew.bmp"; 
	hitName = "laserhit.dts"; 
	damageConversion = 0.01; 
	baseDamageType = $LaserDamageType; 
	beamTime = 0.5; 
	lightRange = 2.0; 
	lightColor = { 1.0, 0.25, 0.25 }; 
	detachFromShooter = false; 
	hitSoundId = SoundLaserHit; 
	}; 

LaserData railLaser 
	{ 
	laserBitmapName = "paintPulse.bmp"; 
	hitName = "laserhit.dts"; 
	damageConversion = 0.008; 
	baseDamageType = $SniperDamageType; 
	beamTime = 1.5; 
	lightRange = 5.0; 
	lightColor = { 0.25, 1.0, 0.25 }; 
	detachFromShooter = true; 
	hitSoundId = SoundLaserHit; 
	};

LaserData railLaser2 
	{ 
	laserBitmapName = "laserpulse.bmp"; 
	hitName = "laserhit.dts"; 
	damageConversion = 0.008; 
	baseDamageType = $SniperDamageType; 
	beamTime = 1.5; 
	lightRange = 5.0; 
	lightColor = { 0.25, 1.0, 0.25 }; 
	detachFromShooter = true; 
	hitSoundId = SoundLaserHit; 
	};

TargetLaserData targetLaser 
	{ 	
	laserBitmapName = "paintPulse.bmp"; 
	damageConversion = 0.0; 
	baseDamageType = 0; 
	lightRange = 2.0; 
	lightColor = { 0.25, 1.0, 0.25 }; 
	detachFromShooter = false; 
	}; 

//------LASER SIGHT

TargetLaserData targetLaser2
{
   laserBitmapName   = "laserPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
};

LaserData ObeliskBeam
{
   laserBitmapName   = "PaintPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0125;
   damageType    = $LaserDamageType;

   beamTime          = 0.5;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LightningData lightningCharge 
	{ 
	bitmapName = "warp.bmp"; 
	damageType = $ElectricityDamageType; 
	boltLength = 40.0; 
	coneAngle = 35.0; 
	damagePerSec = 0.10; 
	energyDrainPerSec = 60.0; 
	segmentDivisions = 4; 
	numSegments = 5; 
	beamWidth = 0.125;
	updateTime = 120; 
	skipPercent = 0.5; 
	displaceBias = 0.15; 
	lightRange = 3.0; 
	lightColor = { 0.25, 0.25, 0.85 }; 
	soundId = SoundELFFire; 
	}; 

LightningData lightningCharge2 
	{ 
	bitmapName = "warp.bmp"; 
	damageType = $ElectricityDamageType; 
	boltLength = 60.0; 
	coneAngle = 35.0; 
	damagePerSec = 0.10; 
	energyDrainPerSec = 60.0; 
	segmentDivisions = 4; 
	numSegments = 5; 
	beamWidth = 0.125;
	updateTime = 120; 
	skipPercent = 0.5; 
	displaceBias = 0.15; 
	lightRange = 3.0; 
	lightColor = { 0.25, 0.25, 0.85 }; 
	soundId = SoundELFFire; 
	}; 

TargetLaserData LaserPointer
{
   laserBitmapName   = "laserpulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData turretCharge 
	{ 
	bitmapName = "lightningNew.bmp"; 
	damageType = $ElectricityDamageType; 
	boltLength = 40.0; 
	coneAngle = 35.0; 
	damagePerSec = 0.06; 
	energyDrainPerSec = 60.0; 
	segmentDivisions = 4; 
	numSegments = 5; 
	beamWidth = 0.125;
	updateTime = 120; 
	skipPercent = 0.5; 
	displaceBias = 0.15; 
	lightRange = 3.0; 
	lightColor = { 0.25, 0.25, 0.85 }; 
	soundId = SoundELFFire; 
	}; 


LightningData flightDrain 
	{ 
	bitmapName = "warp.bmp"; 
	damageType = $ElectricityDamageType; 
	boltLength = 40.0; 
	coneAngle = 35.0; 
	damagePerSec = 0; 
	energyDrainPerSec = 60.0; 
	segmentDivisions = 4; 
	numSegments = 5; 
	beamWidth = 0.125;
	updateTime = 120; 
	skipPercent = 0.5; 
	displaceBias = 0.15; 
	lightRange = 3.0; 
	lightColor = { 0.25, 0.25, 0.85 }; 
	soundId = SoundELFFire; 
	}; 


LightningData flightDrain2 
	{ 
	bitmapName = "warp.bmp"; 
	damageType = $ElectricityDamageType; 
	damagePerSec = 0; 
	energyDrainPerSec = 60.0; 
	updateTime = 120; 
	skipPercent = 0.5; 
	displaceBias = 0.15; 
	lightRange = 3.0; 
	lightColor = { 0.25, 0.25, 0.85 }; 
	soundId = SoundELFFire; 
	}; 

LightningData boltCharge 
	{ 
	bitmapName = "lightningNew.bmp"; 
	damageType = $ElectricityDamageType; 
	boltLength = 40.0; 
	coneAngle = 35.0; 
	damagePerSec = 0.20; 
	energyDrainPerSec = 60.0; 
	segmentDivisions = 4; 
	numSegments = 5; 
	beamWidth = 0.125;
	updateTime = 120; 
	skipPercent = 0.5; 
	displaceBias = 0.15; 
	lightRange = 3.0; 
	lightColor = { 0.25, 0.25, 0.85 }; 
	soundId = SoundELFFire; 
	}; 

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
	{ 
	%damVal = %timeSlice * %damPerSec; 
	%enVal = %timeSlice * %enDrainPerSec; 
	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId); 
	%energy = GameBase::getEnergy(%target); 
	%energy = %energy - %enVal; 
	if (%energy < 0) 
	{ 
	%energy = 0; 
	} 
	GameBase::setEnergy(%target, %energy); 
	} 

LightningData jailbolt
	{
  	bitmapName       = "lightningNew.bmp";
   	damageType       = $ElectricityDamageType;
   	boltLength       = 4.0;
   	coneAngle        = 1.0;
   	damagePerSec      = 0.01;
   	energyDrainPerSec = 60.0;
   	segmentDivisions = 1;
   	numSegments      = 1;
   	beamWidth        = 0.125;
   	updateTime   = 120;
   	skipPercent  = 0.5;
   	displaceBias = 0.15;
   	lightRange = 3.0;
   	lightColor = { 0.25, 0.25, 0.85 };
   	soundId = SoundELFFire;
	};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
	{
	%aclient = Player::getClient(%target);
	if(getObjectType(%target) != "Player")
      {
      return;
      }
	if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
      {
      return;
      }
      %teleset = nameToID("MissionCleanup/jailports");
      %playerTeam = GameBase::getTeam(%target);
      for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
      {
      %oteam=GameBase::getTeam(%o);
      if(%oteam != %playerTeam)
      {
	%sclient = Player::getClient(%shooterId);
      %sname = Client::getName(%sclient);
      %client = Player::getClient(%target);
      %vname = Client::getName(%client);
      GameBase::SetPosition(%target,GameBase::GetPosition(%o));
      Client::sendMessage(%client,0,"You Have Been Placed Under Arrest By " @ %sname);
      Client::SendMessage(%client,0,"Your jail sentence will last 60 seconds.");
      echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
      schedule("jLargeForceField::jailSesame("@%target@");",60);
      }
      }
	}
//======================================
//Grapple, Repulse , push & other
//Beam codes
//======================================
LightningData tractorCharge
{
   bitmapName = "lightningNew.bmp";
   damageType       = $ElectricityDamageType;
   boltLength = 200.0;
   coneAngle = 15.0;
   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 5;
   beamWidth = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 2.0;
   lightColor = { 1.00, 0.25, 0.25 };

   soundId = SoundELFFire;
};

function tractorCharge::pull(%client, %target)
{ 
	%myPos = GameBase::getPosition(%client);
	%yourPos = GameBase::getPosition(%target);
	%myRot = GameBase::getRotation(%client); 

	%dir = getWord(%myRot, 0) @ " " @ getWord(%myRot, 1) @ " " @ 3.14 + getWord(%myRot, 2);
	//make dir face opposite direction, thus pulls toward 

	%myFlatPos = getWord(%myPos, 0) @ " " @ getWord(%myPos, 1) @ " 0";
	%yourFlatPos = getWord(%yourPos, 0) @ " " @ getWord(%yourPos, 1) @ " 0"; 
	%dist = Vector::getDistance(%myFlatPos, %yourFlatPos);
	//so Z isn't in distance & doesn't make you go FLYING if you have a huge height difference

	%force = 13; //not too hard and fast

	%height = 10 * (getWord(%myPos, 2) - getWord(%yourPos, 2)); //diff in z-values 

	%diffVector = Vector::getFromRot(%dir, -%force, (-%height / %force)); 

	if(%client.tractorMode == 1)
		%diffVector = Item::getVelocity(%target);

	Item::setVelocity(%client, %diffVector); //the actual movement function
} 

function tractorCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	if(%target.shieldStrength > 0 || GameBase::getDataName(%target).className == "HandAmmo") {
		return;
	} 
	else {
		tractorCharge::pull(%shooterID,%target);
	}
} 

//===============new lasers
LaserData PhrailterLaser
{
   laserBitmapName   = "blue_blink4.bmp";		//"pulse.bmp";
   hitName           = "shockwave_large.dts";	//"laserhit.dts";

   damageConversion  = 0.00;		//0.007
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;	//0.7;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
	hitSoundId = SoundFlierCrash;
   hitSoundId        = bigExplosion1;
};

LaserData ParticleBeam
{	laserBitmapName = "laserpulse.bmp";
	hitName = "shockwave_large.dts";
	damageConversion = 0.064;
	DamageType = $BulletDamageType;
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundFlierCrash;
};
//====END TRACTOR Beam
LightningData antigravCharge
{
   bitmapName       = "repairadd.bmp";
   damageType       = $ElectricityDamageType;
   boltLength = 50.0;
   coneAngle = 15.0;
   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 5;
   beamWidth = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 2.0;
   lightColor = { 1.00, 0.25, 0.25 };

   soundId = SoundELFFire;
};

function antigravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{

	%playerId = %shooterId;
	if (%playerId.GravBolt == "0")
	{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = -25;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
	else
	{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = 25;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		
		
		%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
		Player::applyImpulse(%obj,%vec);
		
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

//=====END Re-Tractor Beam
//===Tractor Beam ====from Shifter
LightningData gravCharge
{
   bitmapName       = "lightningNew.bmp";
   damageType       = $ElectricityDamageType;
   boltLength = 200.0;
   coneAngle = 15.0;
   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 5;
   beamWidth = 0.25;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 2.0;
   lightColor = { 1.00, 0.25, 0.25 };

   soundId = SoundELFFire;
};

function gravCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{

	%playerId = %shooterId;
	if (%playerId.GravBolt == "0")
	{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = -25;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
	else
	{
		%Rotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId)); 
		%Zvalue = %Rotation;
		%velocity = -25;
		%shooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%Zvalue);
		
		
		%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
		Player::applyImpulse(%obj,%vec);
		
		Player::applyImpulse(%target, %shooterDir);

		%damVal = %timeSlice * %damPerSec;
		%enVal  = %timeSlice * %enDrainPerSec;
		GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	}
}

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}
//END===Tractor Beam
LightningData TractorBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 300.0; // 120
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 3;
   beamWidth        = 1.0;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };

   soundId = SoundELFFire;
};

$TractorPower = 50;

function TractorBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
  %obj1 = %target;
  %obj2 = %shooterId;

   // Get object's mass  
  if (getObjectType(%obj1) == "Player") 
    %obj1mass = Player::getArmor(%obj1).mass;
  else
    %obj1mass = 10000;

  %obj2mass = Player::getArmor(%obj2).mass;

   // 
  %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%obj1), GameBase::getPosition(%obj2)));

  if (getObjectType(%obj1) == "Player")
  {
    %mul = $TractorPower - ($TractorPower * %obj1mass) / (%obj1mass + %obj2mass);
    %nvec = (getWord(%vec, 0) * %mul * -1) @ " " @
            (getWord(%vec, 1) * %mul * -1) @ " " @
            (getWord(%vec, 2) * %mul * -1);
    //Player::applyImpulse(%obj1, %nvec);
    Item::setVelocity(%obj1, %nvec);
  }

   // obj2 is always a player
  %mul = $TractorPower - ($TractorPower * %obj2mass) / (%obj1mass + %obj2mass);
  %nvec = (getWord(%vec, 0) * %mul) @ " " @
          (getWord(%vec, 1) * %mul) @ " " @
          (getWord(%vec, 2) * %mul);
  //Player::applyImpulse(%obj2, %nvec);
  Item::setVelocity(%obj2, %nvec);
}
//======================================
RepairEffectData RepairBolt 
	{ 
	bitmapName = "fx_lensflare_1.bmp"; 
	boltLength = 20.0; 
	segmentDivisions = 4; 
	beamWidth = 0.125; 
	updateTime = 450; 
	skipPercent = 0.0; 
	displaceBias = 0.15; 
	lightRange = 3.0; 
	lightColor = { 0.85, 0.25, 0.25 }; 
	};

 
function RepairBolt::onAcquire(%this, %player, %target) 
	{ 
	%client = Player::getClient(%player);
	%targetTeam = GameBase::getTeam(%target);
	%clientTeam = GameBase::getTeam(%client);
	if (%targetTeam != %clientTeam && getObjectType(%target) == "Turret")
	{
	Client::sendMessage(%client,0,"You Dick");
	Player::trigger(%player, $WeaponSlot, false);
	%player.repairTarget = -1; 
	return;
	}
	else
	{
	if (%target == %player) 
	{ 
	%player.repairTarget = -1; 
	if (GameBase::getDamageLevel(%player) != 0) 
	{ 
	%player.repairRate = 0.25; 
	%player.repairTarget = %player; 
	Client::sendMessage(%client, 0, "AutoRepairing Mod By Armagedon");
	} 
	else 
	{ 
	Client::sendMessage(%client,0,"Try Again Mod By: Armagedon");
	Player::trigger(%player, $WeaponSlot, false);
	return;
	} 
	} 
	else 
	{ 
	%player.repairTarget = %target; 
	%player.repairRate = 3.0; 
	if (getObjectType(%player.repairTarget) == "Player" && %target != %player) 
	{
	%player.repairRate = 0.75; 
	%rclient = Player::getClient(%player.repairTarget); 
	%name = Client::getName(%rclient); 
	} 
	else 
	{ 
	%name = GameBase::getMapName(%target); 
	if(%name == "") 
	{ 
	%name = (GameBase::getDataName(%player.repairTarget)).description; 
	} 
	} 
	if (GameBase::getDamageLevel(%player.repairTarget) == 0) 
	{ 
	Client::sendMessage(%client,0,%name @ " is not damaged"); 
	Player::trigger(%player,$WeaponSlot,false); 
	%player.repairTarget = -1; 
	return; 
	} 
	if (getObjectType(%player.repairTarget) == "Player") 
	{ 
	Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client)); 
	} 
	Client::sendMessage(%client,0,"Repairing " @ %name); 
	} 
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; 
	GameBase::setAutoRepairRate(%player.repairTarget,%rate); 
	}
	}
 
function RepairBolt::onRelease(%this, %player) 
	{ 
	%object = %player.repairTarget; 
	if (%object != -1) 
	{ 
	%client = Player::getClient(%player); 
	if (%object == %player) 
	{ 
	Client::sendMessage(%client,0,"AutoRepairing Off Mod By: Armagedon"); 
	} 
	else 
	{ 
	if (GameBase::getDamageLevel(%object) == 0) 
	{ 
	Client::sendMessage(%client,0,"Repair Done Go Repair Somthing else"); 
	} 
	else 
	{ 
	Client::sendMessage(%client,0,"Why Did You Stop??"); 
	} 
	} 
	%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; 
	if (%rate < 0) 
	%rate = 0; 
	GameBase::setAutoRepairRate(%object,%rate); 
	} 
	} 


function RepairBolt::checkDone(%this, %player) 
	{ 
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1) 
	{ 
	%object = %player.repairTarget; 
	if (%object == %player) 
	{ 
	if (GameBase::getDamageLevel(%player) == 0) 
	{ 
	Player::trigger(%player,$WeaponSlot,false); 
	return; 
	} 
	} 
	else 
	{ 
	if (GameBase::getDamageLevel(%object) == 0) 
	{ 
	Player::trigger(%player,$WeaponSlot,false);
	return; 
	} 
	} 
	} 
	} 

RepairEffectData AutoBolt 
	{ 
	bitmapName = "repairadd.bmp"; 
	boltLength = 3.0; 
	segmentDivisions = 4; 
	beamWidth = 0.3; 
	updateTime = 450; 
	skipPercent = 0.6; 
	displaceBias = 0.15; 
	lightRange = 3.0; 
	lightColor = { 0.85, 0.25, 0.25 }; 
	}; 

function AutoBolt::onAcquire(%this, %player, %target) 
	{ 
	%client = Player::getClient(%player); 
	if (%target == %player) 
	{ 
	%player.repairTarget = -1; 
	if (GameBase::getDamageLevel(%player) != 0) 
	{ 
	%player.repairRate = 0.075; 
	%player.repairTarget = %player; 
	Client::sendMessage(%client, 3, "Healing....."); 
	} 
	else 
	{ 
	Client::sendMessage(%client,3,"Full Health"); 
	Player::trigger(%player, $BackpackSlot, false); 
	return; 
	} 
	} 
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate; 
	GameBase::setAutoRepairRate(%player.repairTarget,%rate); 
	} 

function AutoBolt::onRelease(%this, %player) 
	{ 
	%object = %player.repairTarget; 
	if (%object != -1) 
	{ 
	%client = Player::getClient(%player); 
	if (%object == %player) 
	{ 
	Client::sendMessage(%client,3,"Full Health"); 
	} 
	%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate; 
	if (%rate < 0) 
	%rate = 0; 
	GameBase::setAutoRepairRate(%object,%rate); 
	} 
	} 

function AutoBolt::checkDone(%this, %player) 
	{ 
	if (%player.repairTarget != -1) 
	{ 
	%object = %player.repairTarget; 
	if (%object == %player) 
	{ 
	if (GameBase::getDamageLevel(%player) == 0) 
	{ 
	Player::trigger(%player,$BackpackSlot,false); 
	return; 
	} 
	} 
	} 
	}
