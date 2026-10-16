// =================================================================
//  U L T R A   R E N E G A D E S   V X  E L I T E     
// =================================================================
// Copyright © 2005 Armageddon. List of credits in credits.txt

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 3;
	damageValue = 0.85;
	damageType = $MineDamageType;
	kickBackStrength = 0;
	triggerRadius = 2;
	maxDamage = 2;
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
	if (((%type == "Player") || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this)
		 && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))//JR 1/31/99
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
MineData MajikMine
{
	className = "Mine";
   description = "Majik Mine";
   shapeFile = "mine";
   validateShape = true;
   validateMaterials = false;
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $ExplosionDamageType;
	kickBackStrength = 500;
	triggerRadius = 1.5;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 0.6;
	damageLevel = {1.0, 1.0};
};

function MajikMine::onAdd(%this)
{
	%this.damage = 0;
	MajikMine::deployCheck(%this);
}


function MajikMine::onCollision(%this,%object) 
{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this);
	 if ((%type == "Player" || %data == MajikMine || %data == Vehicle || %type == "Moveable") && 
		GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) 
	GameBase::setDamageLevel(%this, %data.maxDamage); }

function MajikMine::deployCheck(%this) 
{
	 if (GameBase::isAtRest(%this)) { GameBase::playSequence(%this,1,"deploy"); GameBase::setActive(%this,true); %set = newObject("set",SimSet); if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) { %data = GameBase::getDataName(%this); GameBase::setDamageLevel(%this, %data.maxDamage); } deleteObject(%set); } else schedule("MajikMine::deployCheck(" @ %this @ ");", 3, %this); }


function MajikMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function MajikMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $ExplosionDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
/////////////////////////////
//Claymore Gen/Pack       //
///////////////////////////
MineData ClaymoreGrenade 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "TimedExplosive";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 3.0;
	damageValue = 2.5;
	damageType = $ExplosiveDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 0.5;
};

function ClaymoreGrenade::onAdd(%this) {
}

function ClaymoreGrenade::setTimer(%this, %time) {
	schedule("Mine::Detonate(" @ %this @ ");", %time, %this);
}

function ClaymoreGrenade::onCollision(%this, %obj) {

	if(getObjectType(%obj) != "Player") {
		return;
	}

	if(Player::isDead(%obj)) {
		return;
	}

	%client = Player::getClient(%obj);
	%armor = Player::getArmor(%obj);

	// if the object is flying through the air, let's not allow defuses or detonations
	if (!GameBase::isAtRest(%this)) return;

	// If an engineer touches the explosive
	if (%armor == "CyMedium") {
		// set success rate
		if (%armor == "CyMedium") {
			%successrate = 9.5;
		}
		else {
			%successrate = 7.5;
		}

		// attempt to disarm the explosive
		%rnd = floor(getRandom() * 10);
		if(%rnd < %successrate) {
			playSound(SoundPickupItem,GameBase::getPosition(%this));

			// Success will remove the explosive
			deleteObject(%this);
			Client::sendMessage(%client, 1, "Explosives have been disarmed.");

			// If a HyMedium
			if (%armor == "HyMedium") {

				// Give the player a RepairKit and a beacon
				Item::giveItem(%obj, RepairKit, 1);
				Item::giveItem(%obj, Beacon, 1);
			}
		}
		else {
			// Failure will detonate the explosive
			Client::sendMessage(%client, 1, "Disarm attempt failed!");
			Mine::Detonate(%this);
			return;
		}
	}

	// other armors may detonate the explosive
	else {
		%rnd = floor(getRandom() * 10);
		if(%rnd > 8) {
			// detonate the explosive
			Mine::Detonate(%this);
			return;
		}
	}
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
      validateShape = true;
   validateMaterials = true;
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
// Multiple Grenade Types ~ Armageddon 2004
// Vortex Grenade ~ Confussion Reigns
//============================================================================
MineData VortexHandGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
   description = "Vortex Grenade";
   shapeFile = "discb";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
 	lightType = 2;
 	lightRadius = 10;
 	lightTime = 1.5;
 	lightColor = {0, 0, 50 };

};

function VortexHandgrenade::onAdd(%this)
{
	%startSlurping = 1.0;
	%boomTime = 3.0;
	for (%timeCounter=%startSlurping; %timeCounter <= %boomTime; %timeCounter = %timeCounter + 0.1)
	{ schedule("Vortexgrenade::VortexFun(" @ %this @ "," @ %timeCounter @ ");",%timeCounter,%this); }
	schedule("Mine::Detonate(" @ %this @ ");",%boomTime,%this);
}

function Vortexgrenade::VortexFun(%this, %timeCounter)
{
	%grenadePos=GameBase::getPosition(%this);
  	%grenadeSet=newObject("grendadeSet",SimSet);
	%numObjects=containerBoxFillSet(%grenadeSet,$SimPlayerObjectType | $VehicleObjectType,%grenadePos,40,40,40,0);
	for (%objCounter=0; %objCounter <= %numObjects; %objCounter++)
		{
		%target=Group::getObject(%grenadeSet, %objCounter);
		%targetPos=GameBase::getPosition(%target);

		%grenadeX=getWord(%grenadePos, 0);
		%grenadeY=getWord(%grenadePos, 1);
		%grenadeZ=getWord(%grenadePos, 2);
		%targetX=getWord(%targetPos, 0);
		%targetY=getWord(%targetPos, 1);
		%targetZ=getWord(%targetPos, 2);
		%wayPointOne=%grenadeX+(30-((%timeCounter-1.5)*20)) @ " " @ %grenadeY+(30-((%timeCounter-1.5)*20)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointTwo=%grenadeX+(30-((%timeCounter-1.5)*20)) @ " " @ %grenadeY-(30-((%timeCounter-1.5)*20)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointThree=%grenadeX-(30-((%timeCounter-1.5)*20)) @ " " @ %grenadeY-(30-((%timeCounter-1.5)*20)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";
		%wayPointFour=%grenadeX-(30-((%timeCounter-1.5)*20)) @ " " @ %grenadeY+(30-((%timeCounter-1.5)*20)) @ " " @ (%targetZ-%grenadeZ)/2 @ " ";

		if(%targetX-%grenadeX>=0 && %targetY-%grenadeY>=0)
			%targetWayPoint=%wayPointTwo;
		if(%targetX-%grenadeX>=0 && %targetY-%grenadeY<0)
			%targetWayPoint=%wayPointThree;
		if(%targetX-%grenadeX<0 && %targetY-%grenadeY<0)
			%targetWayPoint=%wayPointFour;
		if(%targetX-%grenadeX<0 && %targetY-%grenadeY>=0)
			%targetWayPoint=%wayPointOne;

		%distanceToWayPoint=Vector::getDistance(%targetPos, %targetWayPoint);
		%force=1+(%distanceToWayPoint / 200);
		%targetVector=Vector::sub(%targetWayPoint, %targetPos);
		%targetNewVector=getWord(%targetVector, 0) * %force @ " " @ getWord(%targetVector, 1) * %force @ " " @ getWord(Vector, 2) * %force @ " "; 
		Item::setVelocity(%target, %targetNewVector);
		}
		
	deleteObject(%grenadeSet);
}

//----------------------------------------------------------------------------
// Multiple Grenade Types ~ Armageddon 2004
// Fusion Grenade ~ Pretty
//============================================================================

MineData FusionBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "grenade";
	description = "FireBomb1";
	shapeFile = "discb";
	shadowDetailMask = 4;
	explosionId = turretExp;
	explosionRadius = 8.0;
	damageValue = 0.2;
	damageType = $FusionDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 500.01; //If FireBomb can be destroyed, then the game will crash!
};

BulletData FusionBombSpew
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = EnergyExp;


   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $FusionDamageType;
   explosionRadius    = 7.0;


   aimDeflection      = 1.0;
   muzzleVelocity     = 1.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 3.0;
   lightColor         = { 0,0, 5 };
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   
// soundId = SoundJetLight;

};

BulletData FusionBombHeat
{
   bulletShapeName    = "paint.dts";
   explosionTag       = energyExp;


   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $FusionDamageType;
   explosionRadius    = 6.0;


   aimDeflection      = 3.0;
   muzzleVelocity     = 1.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 1.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.0;
   isVisible          = True;

   
// soundId = SoundJetLight;

};

function FusionBomb::onAdd(%this)
{	
	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",16.0,%this);
	schedule("FusionFuel(" @ %this @ ", 120);",1.0,%this); 

	
}

function FusionFuel(%this, %steps) //Deadtaco's Molotov spew code
{
	if(%steps)
	{
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile("FusionBombSpew",%trans,%this,"0 0 -2");
	        Projectile::spawnProjectile("FusionBombSpew",%trans,%this,"0 0 -3");
		Projectile::spawnProjectile("FusionBombHeat",%trans,%this,%vel);
		schedule("FusionFuel(" @ %this @ ", " @ %steps - 1 @ ");", 0.1);
	}
}


function FusionBomb::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}
	if(Player::isDead(%obj))
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
}

function FusionBomb::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

function FusionBomb::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}

function FusionBomb::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

//----------------------------------------------------------------------------
// Multiple Grenade Types ~ Armageddon 2004
// Pulse Grenade ~ 1...2...3...4...5...6...7
//============================================================================

MineData PulseBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "grenade";
	description = "FireBomb1";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = turretExp;
	explosionRadius = 8.0;
	damageValue = 0.2;
	damageType = $PulseDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 500.01; //If FireBomb can be destroyed, then the game will crash!
};

BulletData Pulse1
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = TurretExp;


   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $FusionDamageType;
   explosionRadius    = 7.0;


   aimDeflection      = 1.0;
   muzzleVelocity     = 1.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 3.0;
   lightColor         = { 0,0, 5 };
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   
// soundId = SoundJetLight;

};

BulletData Pulse2
{
   bulletShapeName    = "paint.dts";
   explosionTag       = turretExp;


   damageClass        = 1;
   damageValue        = 0.2;
   damageType         = $FusionDamageType;
   explosionRadius    = 6.0;


   aimDeflection      = 3.0;
   muzzleVelocity     = 1.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 1.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.0;
   isVisible          = True;

   
// soundId = SoundJetLight;

};

function PulseBomb::onAdd(%this)
{	
	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",16.0,%this);
	schedule("PulseBlink(" @ %this @ ", 120);",1.0,%this); 

	
}

function PulseBlink(%this, %steps) //Deadtaco's Molotov spew code
{
	if(%steps)
	{
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile("Pulse2",%trans,%this,"0 0 -2");
	        Projectile::spawnProjectile("Pulse1",%trans,%this,"0 0 -3");
		Projectile::spawnProjectile("Pulse2",%trans,%this,%vel);
		schedule("PulseBlink(" @ %this @ ", " @ %steps - 1 @ ");", 0.1);
	}
}


function PulseBomb::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}
	if(Player::isDead(%obj))
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
}

function PulseBomb::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

function PulseBomb::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}

function PulseBomb::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}
//----------------------------------------------------------------------------
// Multiple Grenade Types ~ Armageddon 2004
// Radiation "Dirty" Bomb ~ Ewww it's So dirty...
//============================================================================

MineData RadiationBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 1.0;
	className = "grenade";
	description = "Radiation Bomb";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $RadiationDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 50000.01; //If smoke grenade can be destroyed, then the game will crash!
};

BulletData DirtySpew
{
   bulletShapeName    = "mortarex.dts";
   explosionTag       = DirtyBombExp;


   damageClass        = 1;
   damageValue        = 0.0;
   damageType         = $RadiationDamageType;
   explosionRadius    = 5.0;


   aimDeflection      = 1.0;
   muzzleVelocity     = 25.0;
   totalTime          = 1.5;
   liveTime           = 0.5;
   lightRange         = 3.0;
   lightColor         = { 0, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   
// soundId = SoundJetLight;

};

GrenadeData DirtyEnd
{ 
	bulletShapeName = "plastrail.dts"; 
	explosionTag = DirtyEndExp; 
	collideWithOwner = false; 
	ownerGraceMS = 500; 
	collisionRadius = 0.0; 
	mass = 0.0; 
	elasticity = 0.1; 
	damageClass = 0; 
	damageValue = -0.01; 
	damageType = $RadiationDamageType; 
	explosionRadius = 1; 
	kickBackStrength = 0.0; 
	maxLevelFlightDist = 4; 
	totalTime = 0.55; 
	liveTime = 0.55; // grenade time live after contact
        lightRange         = 3.0;
        lightColor         = { 0.0, 0.0, 0.0 };
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 1.0; 
	smokeName = "plastrail.dts"; 
};

function RadiationBomb::onAdd(%this)
{	
	
	%obj = %this;
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",40.0,%this);
	if ($Radiate != 1)
		{
		schedule("DirtyCloud(" @ %this @ ", 270);",3.0,%this); //Make sure only one smoke grenade can go off at a time
		schedule("$Radiate = 0;",30.0);		  //Or the game may crash, or just get REALLY slow
		}
	
}

function DirtyCloud(%this, %steps) 
{
	if(%steps)
	{
		$Radiate = 1;
		%trans = GameBase::getMuzzleTransform(%this);
		%vel = Item::getVelocity(%this);
		Projectile::spawnProjectile("DirtySpew",%trans,%this,%vel);
		schedule("DirtyCloud(" @ %this @ ", " @ %steps - 1 @ ");", 0.1);
	}
}


function RadiationBomb::onCollision(%this,%obj)
{
	if(getObjectType(%obj) != "Player")
	{
		return;
	}
	if(Player::isDead(%obj))
	{
		return;
	}
	%c = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
}

function RadiationBomb::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);

}

function RadiationBomb::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage + 10000);
}

function RadiationBomb::onDestroyed(%this)
{
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("DirtyEnd",%trans,%this,0);
}

//----------------------------------------------------------------------------
// Multiple Grenade Types ~ Armageddon 2004
// Rail Bomb ~ Ewww it's So dirty...
//============================================================================

function Grenade::useRail(%player)
{
	%client = Player::getClient(%player);
	%obj = newObject("","Mine","RailBomb");
	%obj.thrower = %client;
 	addToSet("MissionCleanup", %obj);
	%client = Player::getClient(%player);
	GameBase::throw(%obj,%player,9 * %client.throwStrength,false);
	%player.throwTime = getSimTime() + 0.5;
}

RocketData RailGBullet
{
   bulletShapeName = "bullet.dts";
   explosionTag    = bulletExp0;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.35;
   damageType       = $EnergyDamageType;

   explosionRadius  = 3.0;
   kickBackStrength = 0.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 1000.0;
   acceleration     = 1.0;

   totalTime        = 8.5;
   liveTime         = 18.0;

   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.15;
   soundId = SoundJetHeavy;
};

MineData RailBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "grenade";
	description = "Handgrenade";
	shapeFile = "discammo";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0;
	damageType = $EnergyDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

StaticShapeData RailThrower
{
	className = "Beacon";
	damageSkinData = "objectDamageSkins";

	shapeFile = "discammo";
	maxDamage = 1;
	maxEnergy = 200;

	castLOS = true;
	supression = false;
	mapFilter = 2;
	visibleToSensor = true;
	explosionId = flashExpSmall;
	debrisId = flashDebrisSmall;
};

$DamageScale[RailThrower, $EnergyDamageType] = 0;

function RailBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("RailBomb::Detonate(" @ %this @ ");",1.0,%this);
}

function RailBomb::Detonate(%this)
{
	%clientId = %this.thrower;
	%this.thrower = "";
	%thisPos = gamebase::getposition(%this);
	spawnRailThrower(%clientId, %thisPos);
	Mine::Detonate(%this);
}

function getBalancedNum(%number)
{
	%balanceRatio = getNumClients()/2;
	if(%balanceRatio < 0.5)
		%balanceRatio = 0.5;
	%return = %number/%balanceRatio;
	return %return;
}

function spawnRailThrower(%clientId, %pos)
{
	%player = Client::getOwnedObject(%clientId);
	%beacon = newObject("Rail Bomb", "StaticShape", "RailThrower", true);
	addToSet("MissionCleanup", %beacon);
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,%pos);
	Gamebase::setMapName(%beacon,"Rail Bomb");
	%time = getBalancedNum(120);
	if(%time < 5)
		%time = 5;
   	spawnRailThrower::throwThings(%clientId, %beacon, %time);
}

function spawnRailThrower::throwThings(%clientId, %this, %count)
{
	%player = Client::getOwnedObject(%clientId);
	if(%count > 0)
	{
		%pos = gamebase::getposition(%this);
		%rot = getRandom()*200@" "@getRandom()*200@" "@getRandom()*200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("RailGBullet", %trans1, %player, %rot, %player);

		%rot = getRandom()*-200@" "@getRandom()*-200@" "@getRandom()*-200;
		%dir = Vector::getfromrot(%rot);
		%pos1 = Vector::add(%pos, "0 0 -0.01");	
		%trans1 = %rot @ " " @ %dir @ " " @ %dir @ " " @ %pos1;
		Projectile::spawnProjectile("RailGBullet", %trans1, %player, %rot, %player);

		schedule("spawnRailThrower::throwThings("@%clientId@","@%this@","@%count-2@");",0.3,%this);
	}
	else
		schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}

//----------------------------------------------------------------------------
// Thermal Mermal
//----------------------------------------------------------------------------
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
        explosionRadius = 15.0;
        damageValue = 0;
        damageType = $ThermalDamageType;
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
        explosionRadius = 15.0;
        damageValue = 0;
        damageType = $ThermalDamageType;
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
        explosionRadius = 15.0;
        damageValue = 0;
        damageType = $ThermalDamageType;
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
        explosionRadius = 15.0;
        damageValue = 0;
        damageType = $ThermalDamageType;
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
        damageValue = 0;
        damageType = $ThermalDamageType;
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
        explosionRadius = 37.5;
        damageValue = 0;
        damageType = $ThermalDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Bombf::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.375,%this);
}