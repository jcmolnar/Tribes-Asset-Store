GrenadeData ShieldBlast
{
   bulletShapeName    = "Shield.dts";
   explosionTag       = ShieldExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = -0.5;
   smokeName              = "Shield.dts";
};
//-=-=-=-=-=-=-=-=-=-=
//War-Agel Pojectiles
//-=-=-=-=-=-=-=-=-=-=
GrenadeData HolyShell 
{
  bulletShapeName = "shockwave_large.dts";
  explosionTag = LargeShockwave;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.2;
  mass = 1.0;
  elasticity = 0.4;
  damageClass = 1;
  damageValue = 10;
  damageType = $MortarDamageType;
  explosionRadius = 15;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 9999.99;
  totalTime = 30.0;
  liveTime = 0.1;
  projSpecialTime = 0.25;
  inheritedVelocityScale = 0.5;
  smokeName = "plasmabolt.dts";
  smokeDist = 50;
};
//-----------------------
LaserData bolt1
{
   laserBitmapName   = "stafflag.bmp";
   hitName           = "breath.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;

   lightRange        = 0.0;
   lightColor        = { 0.0, 0.0, 4.25 };

   detachFromShooter = true;
   hitSoundId        = soundfireplasma;
};

MineData firstTornado
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 12.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -120;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind1
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 12.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -120;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind2
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 12.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -120;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind3
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 12.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -120;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind4
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 12.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -120;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};


MineData wind5
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 16.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind6
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 18.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind7
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 20.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -200;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind8
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 22.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -200;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind9
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "breath";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 24.0;
  damageValue = 0.01;
  damageType = $MortarDamageType;
  kickBackStrength = -220;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData wind10
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "rocket";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 13.0;
  damageValue = 0.55;
  damageType = $MortarDamageType;
  kickBackStrength = 200;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function firstTornado::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.01,%this);
}

function wind1::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.05,%this);
}

function wind2::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);

}

function wind3::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.15,%this);
}

function wind4::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

function wind5::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

function wind6::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

function wind7::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.35,%this);
}

function wind8::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.4,%this);
}

function wind9::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.45,%this);
}

function wind10::onAdd(%this)
{
schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}
//-------------------------------
RocketData ABBolt
{
  bulletShapeName = "shield.dts";
  explosionTag = waterExp0;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 10;
  damageType = $MortarDamageType;
  explosionRadius = 6;
  kickBackStrength = 0.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 5.0;
  liveTime = 5.0;
  lightRange = 5.0;
  lightColor = { 1.0, 0.7, 0.5 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailLength = 50;
  trailWidth = 0.3;
  soundId = SoundElevatorRun;
};
//------------------------
function QuakeImage::onFire(%player, %slot)
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	%team = Gamebase::getTeam(%player);
		%obj = newObject("","Mine","thinggummie");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%client,35,false);
		GameBase::setTeam(%obj,%team);
}
// Player throws mine
// Mine spawns placeholder
// placeholder has the %clientId appended
// 

MineData thinggummie
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "mortar";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 0.0;
  damageValue = 0.0;
  damageType = $MineDamageType;
  kickBackStrength = 0;
  triggerRadius = 0.0;
  maxDamage = 100.0;
  shadowDetailMask = 0;
  destroyDamage = 1000.0;
  damageLevel = {1.0, 1.0};
};

function thinggummie::onAdd(%this)
{
	thinggummie::deployCheck(%this);
	return;
}

function thinggummie::deployCheck(%this)
{
  if (GameBase::isAtRest(%this)) 
  {
	%set = newObject("set",SimSet);
	if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
	{
      %data = GameBase::getDataName(%this);
      GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	deleteObject(%set);
		schedule("addTremors0(" @ %this @ ");",1.0,%this);
		schedule("addTremors1(" @ %this @ ");",1.25,%this);
		schedule("addTremors2(" @ %this @ ");",1.5,%this);
		schedule("addTremors3(" @ %this @ ");",1.75,%this);
		schedule("addTremors4(" @ %this @ ");",2.0,%this);
		schedule("addTremors5(" @ %this @ ");",2.25,%this);
		schedule("deleteObject(" @ %this @ ");",2.251,%this);
	}
	else schedule("thinggummie::deployCheck(" @ %this @ ");", 3, %this);
}

MineData tremorBomb
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "mortar";
  shadowDetailMask = 4;
  explosionId = debrisExpMedium;
  explosionRadius = 15.0;
  damageValue = 0.3;
  damageType = $MineDamageType;
  kickBackStrength = 0;
  triggerRadius = 0.0;
  maxDamage = 100.0;
  shadowDetailMask = 0;
  destroyDamage = 1000.0;
  damageLevel = {1.0, 1.0};
};

function tremorBomb::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

MineData tremorExp
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "mortar";
  shadowDetailMask = 4;
  explosionId = largeshockwave;
  explosionRadius = 15.0;
  damageValue = 0.1;
  damageType = $MineDamageType;
  kickBackStrength = 0;
  triggerRadius = 0.0;
  maxDamage = 100.0;
  shadowDetailMask = 0;
  destroyDamage = 1000.0;
  damageLevel = {1.0, 1.0};
};

function tremorExp::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

function addTremors0(%this)
{
	%pos = Gamebase::getPosition(%this);
			%xPos = getWord(%pos, 0);
			%yPos = getWord(%pos, 1);
			%zPos = getWord(%pos, 2);
			%newPos = %xPos+1 @ " " @ %yPos+1 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-1 @ " " @ %yPos+1 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);

			%newPos = %xPos+1 @ " " @ %yPos-1 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-1 @ " " @ %yPos-1 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
}

function addTremors1(%this)
{
	%pos = Gamebase::getPosition(%this);
			%xPos = getWord(%pos, 0);
			%yPos = getWord(%pos, 1);
			%zPos = getWord(%pos, 2);
			%newPos = %xPos+3 @ " " @ %yPos+3 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-3 @ " " @ %yPos+3 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);

			%newPos = %xPos+3 @ " " @ %yPos-3 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-3 @ " " @ %yPos-3 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
}

function addTremors2(%this)
{
	%pos = Gamebase::getPosition(%this);
			%xPos = getWord(%pos, 0);
			%yPos = getWord(%pos, 1);
			%zPos = getWord(%pos, 2);
			%newPos = %xPos+6 @ " " @ %yPos+6 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-6 @ " " @ %yPos+6 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);

			%newPos = %xPos+6 @ " " @ %yPos-6 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-6 @ " " @ %yPos-6 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
}

function addTremors3(%this)
{
	%pos = Gamebase::getPosition(%this);
			%xPos = getWord(%pos, 0);
			%yPos = getWord(%pos, 1);
			%zPos = getWord(%pos, 2);
			%newPos = %xPos+9 @ " " @ %yPos+9 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");
	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-9 @ " " @ %yPos+9 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);

			%newPos = %xPos+9 @ " " @ %yPos-9 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-9 @ " " @ %yPos-9 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
}

function addTremors4(%this)
{

	%pos = Gamebase::getPosition(%this);
			%xPos = getWord(%pos, 0);
			%yPos = getWord(%pos, 1);
			%zPos = getWord(%pos, 2);
			%newPos = %xPos+12 @ " " @ %yPos+12 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-12 @ " " @ %yPos+12 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);

			%newPos = %xPos+12 @ " " @ %yPos-12 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
			%newPos = %xPos-12 @ " " @ %yPos-12 @ " " @ %zPos;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorBomb");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
}

function addTremors5(%this)
{
	%pos = Gamebase::getPosition(%this);
			%xPos = getWord(%pos, 0);
			%yPos = getWord(%pos, 1);
			%zPos = getWord(%pos, 2);
			%newPos = %xPos @ " " @ %yPos @ " " @ %zPos+3;
					%rot = "0 0 0";
					%obj = newObject("","Mine","tremorExp");

	 				addToSet("MissionCleanup", %obj);
					GameBase::setPosition(%obj,%newPos);
					GameBase::setRotation(%obj,%rot);
}
//----------------------
GrenadeData GodShell 
{
  bulletShapeName = "rocket.dts";
  explosionTag = LargeShockwave;
  collideWithOwner = True;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 5.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.2;
  damageType = $MortarDamageType;
  explosionRadius = 20.0;
  kickBackStrength = 250.0;
  maxLevelFlightDist = 275;
  totalTime = 30.0;
  liveTime = 2.0;
  projSpecialTime = 0.002;
  inheritedVelocityScale = 0.5;
  smokeName = "shockwave.dts";
};

function radiant1(%this, %count) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","radiant1");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","radiant1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function radiant2(%this, %count) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","radiant2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","radiant2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

MineData radiant1
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "rocket";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 30.0;
  damageValue = 0.15;
  damageType = $MortarDamageType;
  kickBackStrength = 150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData radiant2
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "rocket";
  shadowDetailMask = 4;
  explosionId = LargeShockwave;
  explosionRadius = 30.0;
  damageValue = 0.15;
  damageType = $MortarDamageType;
  kickBackStrength = 150;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function radiant1::onAdd(%this)
{
	schedule("radiant2(" @ %this @ ");",0.1,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

function radiant2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

function GodShell::onAdd(%this)
{
  schedule("radiant1(" @ %this @ ");",0.6,%this);
}
//--------------------------------
GrenadeData putridbomb
{
  bulletShapeName = "mortar.dts";
  explosionTag = mortarExp;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 1.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.01;
  damageType = $PoisonEffect;
  explosionRadius = 25.0;
  kickBackStrength = 100.0;
  maxLevelFlightDist = 150;
  totalTime = 5.0;
  liveTime = 0.5;
  projSpecialTime = 0.12;
  inheritedVelocityScale = 0.5;
  smokeName = "mortartrail.dts";
};
MineData gas1
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "mortartrail";
  shadowDetailMask = 4;
  explosionId = mortarexp;
  explosionRadius = 6.5;
  damageValue = 50.0;
  damageType = $MortarDamagetype;
  kickBackStrength = 0;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData gas2
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "mortartrail";
  shadowDetailMask = 4;
  explosionId = mortarExp;
  explosionRadius = 7.0;
  damageValue = 50.0;
  damageType = $MortarDamageType;
  kickBackStrength = 0;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

MineData gas3
{
  className = "Mine";
  description = "BigEx";
  shapeFile = "mortartrail";
  shadowDetailMask = 4;
  explosionId = mortarExp;
  explosionRadius = 5.5;
  damageValue = 50.0;
  damageType = $MortarDamagetype;
  kickBackStrength = 0;
  triggerRadius = 2.5;
  maxDamage = 0.5;
  shadowDetailMask = 0;
  destroyDamage = 1.0;
  damageLevel = {1.0, 1.0};
};

function gas1::onAdd(%this)
{
	schedule("gas2(" @ %this @ ");",0.1,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.4,%this);
}

function gas2::onAdd(%this)
{
	schedule("gas3(" @ %this @ ");",0.1,%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

function gas3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.2,%this);
}

function gas1(%this) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","gas1");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","gas1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function gas2(%this) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","gas2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","gas2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function gas3(%this, %count) 
{
	if(%this)
	{		
		%obj = newObject("","Mine","gas3");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);

		%obj = newObject("","Mine","gas3");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);
	}
}

function putridbomb::onAdd(%this)
{
  schedule("gas1(" @ %this @ ");",0.6,%this);
}
//------------------------
LightningData ESPShot
{
   bitmapName       = "shield08.bmp";
   damageType       = $ElectricityDamageType;
   boltLength = 100.0;
   coneAngle = 15.0;
   damagePerSec = 0;
   energyDrainPerSec = 0;
   segmentDivisions = 0;
   numSegments = 3;
   beamWidth = 0.8;

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
//-------------------------------------
RocketData fireballshot
{
  bulletShapeName = "discb.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  explosionRadius = 8.0;
  damageValue = 10;
  damageType = $ExplosionDamageType;
  kickBackStrength = 50.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailWidth = 0.5;
  trailLength = 300.0;
};

RocketData fireballshot2
{
  bulletShapeName = "discb.dts";
  explosionTag = turretExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  explosionRadius = 8.0;
  damageValue = 10;
  damageType = $ExplosionDamageType;
  kickBackStrength = 50.0;
  muzzleVelocity = 200.0;
  terminalVelocity = 200.0;
  acceleration = 5.0;
  totalTime = 4.0;
  liveTime = 5.0;
  lightRange = 10.0;
  lightColor = { 0.25, 0.25, 1 };
  inheritedVelocityScale = 0.5;
  trailType = 1;
  trailWidth = 0.5;
  trailLength = 300.0;
};

function fireballshot::onAdd(%this)
{
%this.inc = 0.1;
%this.dec = -0.1;

schedule("trailLoop(" @ %this @ ",fireballshot2,12,1,0.25);",0.1,%this);

}

//-------------------------------------
BulletData freezebolt
{
   bulletShapeName    = "smoke.dts";
   explosionTag       = freezeexp;
   expRandCycle       = 0;
   mass               = 0.07;
   damageClass        = 0;       // 0 impact, 1, radius
   explosionRadius    = 0;
   damageValue        = 100.0;
   damageType         = $plasmadamagetype;
   aimDeflection      = 0.001;
   muzzleVelocity     = 150.0;
   totalTime          = 12;
   inheritedVelocityScale = 0.5;
   isVisible          = True;
};
//--------------------------------------
RocketData solarBurst1
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = grenadeExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.0;
  baseDamageType = $DamageType[Solar];
  explosionRadius = 35.0;
  kickBackStrength = 0.0;
  muzzleVelocity = 50.0;
  terminalVelocity = 50.0;
  acceleration = 5.0;
  totalTime = 2.1;
  liveTime = 2.1;
  lightRange = 0.0;
  lightColor = { 1.0, 1.0, 9.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "fiery.dts";
  smokeDist = 1.9;
  soundId = soundjetheavy;
};

RocketData solarBurst2
{
  bulletShapeName = "plasmatrail.dts";
  explosionTag = plasmaExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 0.7;
  baseDamageType = $DamageType[Solar];
  explosionRadius = 25.0;
  kickBackStrength = 0.0;
  muzzleVelocity = 50.0;
  terminalVelocity = 50.0;
  acceleration = 5.0;
  totalTime = 2.1;
  liveTime = 2.1;
  lightRange = 0.0;
  lightColor = { 1.0, 1.0, 9.5 };
  inheritedVelocityScale = 0.5;
  trailType = 2;
  trailString = "plasmaEx.dts";
  smokeDist = 2.8;
  soundId = soundfireplasma;
};

GrenadeData SolarTrail
{
  bulletShapeName = "plasmabolt.dts";
  explosionTag = plasmaExp;
  collideWithOwner = False;
  ownerGraceMS = 250;
  collisionRadius = 0.3;
  mass = 15.0;
  elasticity = 0.1;
  damageClass = 1;
  damageValue = 0.1;
  damageType = $DamageType[TMortar];
  explosionRadius = 30.0;
  kickBackStrength = 8.0;
  maxLevelFlightDist = 250;
  totalTime = 0.2;
  liveTime = 0.2;
  projSpecialTime = 0.01;
  inheritedVelocityScale = 0.5;
  smokeName = "breath.dts";
};

function solarBurst1::onAdd(%this)
{
schedule("trailLoop(" @ %this @ ",SolarTrail,36,0,0.15);",0.7,%this);
}
//----------------------------------------------------------------------------

RocketData HealBlast
{
   bulletShapeName  = "plasmatrail.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = -100.0;
   damageType       = $MineDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = 50.0;
   muzzleVelocity   = 200;
   terminalVelocity = 200.0;
   acceleration     = 5.0;
   totalTime        = 10;
   liveTime         = 10;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//----------------------------------------------------------------------------

RocketData ImplodeBlast
{
   bulletShapeName  = "enex.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 100.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 5.0;
   kickBackStrength = -250.0;
   muzzleVelocity   = 100;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 20;
   liveTime         = 20;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};