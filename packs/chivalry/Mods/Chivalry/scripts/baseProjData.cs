# Damage Types
#
$ImpactDamageType	= -1;
$LandingDamageType	=  0;
$BulletDamageType      =  1;
$EnergyDamageType      =  2;
$PlasmaDamageType      =  3;
$ExplosionDamageType   =  4;
$ShrapnelDamageType    =  5;
$LaserDamageType       =  6;
$MortarDamageType      =  7;
$BlasterDamageType     =  8;
$ElectricityDamageType =  9;
$CrushDamageType       = 10;
$DebrisDamageType      = 11;
$MissileDamageType     = 12;
$MineDamageType        = 13;
$ReincarnateDamageType = 14;
$StasisDamageType 	= 15;
$FingerDamageType		= 16;
$PredatorDamageType	= 17;
$ShredderDamageType	= 18;
$StubberDamageType	= 19;
$LaserTDamageType		= 20;
$VulcanDamageType		= 21;
$GunshipDamageType	= 22;
$HammerDamageType		= 23;
$ShieldDamageType		= 24;
$EmpDamageType 		= 25;
$EvilDamageType 		= 26;
$DisarmDamageType 	= 27;
$AnnDamageType 		= 28;
$OutBoundsDamageType	= 29;
$StormDamageType		= 30;
$PhoenixDamageType	= 31;
$InfernoDamageType	= 32;
$ViperDamageType		= 33;
$ScatterDamageType 	= 34;
$HealDamageType		= 35;
$TurnDamageType		= 36;
$StutterDamageType	= 37;
$SuicideDamageType	= 38;
$HolyDamageType		= 39;
$GiveDamageType		= 40;
$TridentDamageType	= 41;

$NumVolcMines			= 0;
//$MaxVolcMines			= 50;
//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.09;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = turretExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $EnergyDamageType;
	explosionRadius  = 7.5;

   muzzleVelocity     = 50.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData BlasterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.125;
   damageType         = $BlasterDamageType;

   muzzleVelocity     = 200.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------
BulletData PlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.45;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData GrenadeShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//--------------------------------------
GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $MortarDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
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
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};


//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};



//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.007;
   damageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.0, 0.0, 0.0 };

   detachFromShooter = true;
   isVisible = False;
};

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};


LightningData FingersCharge
{
   bitmapName       = "repairadd.bmp";

   damageType       = $FingerDamageType;
   boltLength       = 60.0;
   coneAngle        = 15.0;
   damagePerSec      = 0.16;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1, 0.25, 0.85 };

   soundId = SoundELFFire;
};
function FingersCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $FingerDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}


LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

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

RepairEffectData RepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if(GameBase::getDataName(%target).description == "Altar of Life" || GameBase::getDataName(%target).description == "Altar of Brimstone")
	{
		Client::sendMessage(%client,0,"Cannot be used upon Altars.");
		Player::trigger(%player, $WeaponSlot, false);
		return;
	}

	else if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	if (GameBase::getDataName(%player.repairTarget).className == "Generator" || GameBase::getDataName(%player.repairTarget) == InventoryStation)
		{
			if(GameBase::getDamageState(%player.repairTarget) != "Enabled")
			{
				//messageall(0,"Generator is Non-Functional");
				%player.repairState = false;
			}
			else
			{
				//messageall(0,"Generator is Functional");
				%player.repairState = true;
			}
		}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if(GameBase::getDataName(%object).description == "Altar of Life" || GameBase::getDataName(%object).description == "Altar of Brimstone")
		return;
		else if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else {
			
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
			if(GameBase::getDataName(%object).className == "Generator" || GameBase::getDataName(%object) == InventoryStation)
			{
				if(!%player.repairState && !%object.checkRepair)
					if(GameBase::getDamageState(%object) == "Enabled")
					{
					%object.checkRepair = true;
					//messageall(0,"Schedule Points to be awarded.");
					schedule("RepairBolt::CheckRepair("@ %player @","@ %object @");",45);
					}
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
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) 
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
		else {
			if (GameBase::getDamageLevel(%object) == 0) 
				{
				Player::trigger(%player,$WeaponSlot,false);
				return;
				}
			}
	}
}

function RepairBolt::CheckRepair(%player,%object)
{
	%object.checkRepair = false;
	%client = Player::getClient(%player);
	%clteam = Client::getTeam(%client);
	%obteam = GameBase::getTeam(%object);
	%name = GameBase::getMapName(%object);
		if(%name == "")
		%name = (GameBase::getDataName(%object)).description;
	%numPlayers = getNumClients();
	if(%numPlayers < 2)
	%alone = 0;
else
     	for(%cl = Client::getFirst();%cl != -1; %cl = Client::getNext(%cl))
     	{
               	if(%cl != %client && Client::getTeam(%cl) != %clteam)
           		 %alone++;
     	}
			
	if(%clteam == %obteam && GameBase::getDamageState(%object) == "Enabled" && !%client.Undead && %alone > 0)
	{
	Client::sendMessage(%client,0,"You get a point for restoring "@ %name);
	%client.score++;
	Game::refreshClientScore(%client);
	}
	else
	Client::sendMessage(%client,0,"No points for repairing "@%name@".  No aggressors.");
}

	
//--------------------------------------
BulletData ReincarnationBolt
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;  //Impact
   damageValue        = 0.01;
   damageType         = $ReincarnateDamageType;

   muzzleVelocity     = 55.0;
   totalTime          = 0.3;
   liveTime           = 0.1;
   lightRange         = 6.0;
   lightColor         = { 0.25, 1, 0.25 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
RocketData DaHammerRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = HammerExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $MortarDamageType;

   explosionRadius  = 17.0;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 3.0;
   liveTime         = 3.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};


//-------------------------------
RocketData StormRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 0.2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $StormDamageType;

   aimDeflection    = 0.009;
   explosionRadius  = 10.0;
   kickBackStrength = 150.0;
   muzzleVelocity   = 120.0;
   terminalVelocity = 120.0;
   acceleration     = 5.0;
   totalTime        = 1.7;
   liveTime         = 2.3;
   lightRange       = 10.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//------------------------------------------------------------
BulletData PredatorBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $PredatorDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 425.0;
   totalTime        = 0.1;
   liveTime         = 0.1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.2;
   tracerLength       = 60;
};

//--------------------------------------
RocketData ShredderDiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = energyExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.2;
   damageType       = $ShredderDamageType;

  // explosionRadius  = 7.5;
  // kickBackStrength = 150.0;

   muzzleVelocity   = 250.0;
   terminalVelocity = 250.0;
   acceleration     = 5.0;

   totalTime        = 0.9;
   liveTime         = 0.9;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//--------------------------------------
GrenadeData VolcanoShell
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
   damageType         = $MineDamageType;

   muzzleVelocity     = 15.0;
   terminalVelocity   = 15.0;
   explosionRadius    = 10;
   kickBackStrength   = 20.0;
   maxLevelFlightDist = 40.0;
   totalTime          = 1.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

function VolcanoShell::onAdd(%this)
{
	schedule("SpawnMines(" @ %this @ " , 5);",1.0,%this);
}

function SpawnMines(%this, %count) 
{
	if($NumVolcMines >= $MaxVolcMines)
	return;
	if(%count && %this)
	{
		if($NumVolcMines < $MaxVolcMines)
		{
		%obj = newObject("","Mine","Volc1");
		%client = GameBase::getOwnerClient(%obj);
		GameBase::setTeam (%obj,GameBase::getTeam(%this));
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,4.0,false);	
		$NumVolcMines++;
		}
		if($NumVolcMines < $MaxVolcMines)
		{
		%obj = newObject("","Mine","Volc1");
		%client = GameBase::getOwnerClient(%obj);
		GameBase::setTeam (%obj,GameBase::getTeam (%client));
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.0,false);
		$NumVolcMines++;
		}
		if($NumVolcMines < $MaxVolcMines)
		{
		%obj = newObject("","Mine","Volc1");
		%client = GameBase::getOwnerClient(%obj);
		GameBase::setTeam (%obj,GameBase::getTeam (%client));
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-4.0,false);
		$NumVolcMines++;
		}
		%count -= 1;
		schedule("SpwanMines(" @ %this @ " , " @ %count @ ");",1.0,%this);//0.5++++++++
	}
}

//--------------------------------------
RocketData InfernoBolt
{
   bulletShapeName  = "plasmabolt.dts";
   explosionTag     = plasmaExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $InfernoDamageType;

   explosionRadius  = 7.0;
   kickBackStrength = 60.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 2.5;
   liveTime         = 1.5;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "smoke.dts";
   smokeDist   = 2.5;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ShockwaveGunBolt
{
   bulletShapeName  = "rsmoke.dts";
   explosionTag     = LargeShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $EnergyDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 350.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 65.0;
   acceleration     = 5.0;
   totalTime        = 2.5;
   liveTime         = 1.5;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.7, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 0.0;

   soundId = SoundWindAmbient;
};

//-------------------------------------
BulletData StubberShell
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $StubberDamageType;

   explosionRadius  = 2.0;
   kickBackStrength = 0.0;
   aimDeflection      = 0.009;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = false;

   tracerPercentage   = 1.0;
   tracerLength       = 40;
};

//-------------------------------------------
RocketData ViperRocket
{
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 1.0;
damageClass = 1; // 0 impact, 1, radius
damageValue = 0.3;
damageType = $ViperDamageType;
explosionRadius = 9.5;
kickBackStrength = 50.0;
muzzleVelocity = 70.0;
terminalVelocity = 70.0;
acceleration = 20.0;
totalTime = 10.0;
liveTime = 10.0;
lightRange = 5.0;
lightColor = { 1.0, 0.7, 0.5 };
inheritedVelocityScale = 0.5;
// rocket specific
trailType = 2; // smoke trail
trailString = "rsmoke.dts";
smokeDist = 1.8;
soundId = SoundJetHeavy;
};

SeekingMissileData ViperMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.3;
   damageType       = $ViperDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 6;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

LightningData ViperPrep
{
bitmapName = "lightningNew.bmp";
boltLength = 250.0;
coneAngle = 1.0;
damagePerSec = 0;
energyDrainPerSec = 0;
segmentDivisions = 2;
numSegments = 2; 
beamWidth = 0.25;
updateTime = 3000;
skipPercent = 0.5;
displaceBias = 0.15;
lightRange = 3.0;
lightColor = { 0.0, 0.0, 0.0 };
isVisible = false;
};
function ViperPrep::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%client = %shooterId;
%player = Client::getControlObject(%client);
%data = getObjectType(%target);
if(%data == "Player" || %data == "Flier") 
{
if(!%player.vehicle || (%target.vehicle != %player.vehicle && %target != %player.vehicle)) 
{
schedule(%client @ ".isFiring = 0;",1.0);
if(%data == "Player") 
{
//Client::sendMessage(%data,0,"Viper lock detected! ");
if(%target.vehicle)
%target = %target.vehicle;
}
%client.targetLock = %target;
GameBase::PlaySound(%player, SoundMineActivate, 1);
//Client::sendMessage(%client,0,"Viper lock acquired ");
}
else
%client.targetLock = 0;
}
else
%client.targetLock = 0;
}

//======================================================================== Shotgun Blast

BulletData ScattergunBullet
{
   bulletShapeName    = "tumult_small.dts";
   explosionTag       = debrisExpSmall;
   expRandCycle       = 2;
   mass               = 0.07;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 6.0;
   damageValue        = 0.06;
   damageType         = $ScatterDamageType;
   aimDeflection      = 0.019;
   muzzleVelocity     = 150.0;
   totalTime          = 0.9;
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   
};

//--------------------------------------
BulletData HvyPlasmaBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.6;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 3.2;

   muzzleVelocity     = 65.0;
   totalTime          = 1.5;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
BulletData StasisBolt
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = energyExp;

   damageClass        = 1;  //Radius
   damageValue        = 0.01;
   damageType         = $StasisDamageType;
	explosionRadius    = 3;

   muzzleVelocity     = 100.0;
   totalTime          = 1;
   liveTime           = 1;
   lightRange         = 3.0;
   lightColor         = { 0.25, 1, 0.25 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------
GrenadeData ShockwvShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 0.0;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $ImpactDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 370.0;
   maxLevelFlightDist = 1;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   //smokeName              = "enbolt.dts";
};

//---------------------------------------------
RepairEffectData CrafterBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 12.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function CrafterBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if(GameBase::getDataName(%target).description == "Altar of Life" || GameBase::getDataName(%target).description == "Altar of Brimstone")
	{
		Client::sendMessage(%client,0,"Cannot be used upon Altars.");
		Player::trigger(%player, $WeaponSlot, false);
		return;
	}
	else if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.1;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.2;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
		if (GameBase::getDataName(%player.repairTarget).className == "Generator" || GameBase::getDataName(%player.repairTarget) == InventoryStation)
		{
			if(GameBase::getDamageState(%player.repairTarget) != "Enabled")
			{
				//messageall(0,"Generator is Non-Functional");
				%player.repairState = false;
			}
			else
			{
				//messageall(0,"Generator is Functional");
				%player.repairState = true;
			}
		}

	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function CrafterBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if(GameBase::getDataName(%object).description == "Altar of Life" || GameBase::getDataName(%object).description == "Altar of Brimstone")
		return;
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		if(GameBase::getDataName(%object).className == "Generator" || GameBase::getDataName(%object) == InventoryStation)
			{
				if(!%player.repairState && !%object.checkRepair)
					if(GameBase::getDamageState(%object) == "Enabled")
					{
					%object.checkRepair = true;
					//messageall(0,"Schedule Points to be awarded.");
					schedule("CrafterBolt::CheckRepair("@ %player @","@ %object @");",45);
					}
			}	
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function CrafterBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == CrafterGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

function CrafterBolt::CheckRepair(%player,%object)
{
	%object.checkRepair = false;
	%client = Player::getClient(%player);
	%clteam = Client::getTeam(%client);
	%obteam = GameBase::getTeam(%object);
	%name = GameBase::getMapName(%object);
		if(%name == "")
		%name = (GameBase::getDataName(%object)).description;
	%numPlayers = getNumClients();
	if(%numPlayers < 2)
	%alone = 0;
else
     	for(%cl = Client::getFirst();%cl != -1; %cl = Client::getNext(%cl))
     	{
               	if(%cl != %client && Client::getTeam(%cl) != %clteam)
           		 %alone++;
     	}

			
	if(%clteam == %obteam && GameBase::getDamageState(%object) == "Enabled" && !%client.Undead && %alone > 0)
	{
	Client::sendMessage(%client,0,"You get a point for restoring "@ %name);
	%client.score++;
	Game::refreshClientScore(%client);
	}
	else
	Client::sendMessage(%client,0,"No points for repairing "@%name@".  No aggressors.");
}

//-----------------------------------------------

LaserData LaserTurretSmall
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.03;
   damageType    = $LaserTDamageType;
	damageClass        = 0;       // 0 impact, 1, radius

   beamTime          = 0.2;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

//------------------------------------------------------------
BulletData VulcBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.06;
   damageType         = $VulcanDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 425.0;
   totalTime        = 4.0;
   liveTime         = 4.0;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.2;
   tracerLength       = 60;
};
//----------------------------
BulletData GunshipBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $GunshipDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
//--------------============-----------=-=-=-=-=-=-
RocketData ShieldRocket
{
   bulletShapeName  = "shockwave.dts";
   explosionTag     = ShieldExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.01;
   damageType       = $ShieldDamageType;

   explosionRadius  = 6;
   kickBackStrength = 0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 2.0;
   liveTime         = 2.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.7, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shockwave.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
//----------------------
RocketData EmpRocket
{
   bulletShapeName  = "enex.dts";
   explosionTag     = turretExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.03;
   damageType       = $EmpDamageType;

   explosionRadius  = 7;
   kickBackStrength = 50;
   muzzleVelocity   = 75.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 2.0;
   liveTime         = 2.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.7, 1.0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 3.0;

   soundId = SoundJetHeavy;
};

//-------------------------------------------

//--------------------------------------
GrenadeData PhoenixFlame
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = plasmaExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.0;
   mass               = 1.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $PhoenixDamageType;

   muzzleVelocity     = 50.0;
   terminalVelocity   = 50.0;
   explosionRadius    = 10;
   kickBackStrength   = 20.0;
   maxLevelFlightDist = 80.0;
   totalTime          = 5.0;    // special meaning for grenades...
   liveTime           = 4.5;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "shotgunex.dts";
};

//--------------------------------------
GrenadeData BomberShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.5;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 1;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "chainspk.dts";
};
//-------------------------------------------------------------

GrenadeData SmokeShell
{
   bulletShapeName    = "armorPatch.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0.1;
   elasticity         = 0.1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $MortarDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 10;
   totalTime          = 30.0;
   liveTime           = 20.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "bluex.dts";
	smokeDist = 0;

};

//--------------------------------------
RocketData EvilRocket
{
   bulletShapeName  = "shockwave.dts";
   explosionTag     = Shockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.001;
   damageType       = $EvilDamageType;

   explosionRadius  = 0;
   kickBackStrength = 0.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 4.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "fiery.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//------------------------------------------------

LightningData DisarmerJolt
{
bitmapName = "lightningNew.bmp";
boltLength = 1200.0;
coneAngle = 0;
damagePerSec = 0.35;
damageType = $DisarmDamageType;
energyDrainPerSec = 0;
segmentDivisions = 4;
numSegments = 1; 
beamWidth = 0.5;
updateTime = 30;
skipPercent = 0.5;
displaceBias = 0.15;
lightRange = 3.0;
lightColor = { 0.0, 0.0, 0.0 };
isVisible = true;

soundId = SoundELFFire;

};

//---------------------------------------------

BulletData DropShell
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = dropExp;

   damageClass        = 0;  //Impact
   damageValue        = 0.001;
   damageType         = $DisarmDamageType;

   muzzleVelocity     = 700.0;
   totalTime          = 5.0;
   liveTime           = 5.0;
   lightRange         = 3;
   lightColor         = { 1, 0.5, 0.25 };
   inheritedVelocityScale = 0.3;
   isVisible          = false;

  //soundId = SoundELFFire;
};

//--------------------------------------
RocketData AnnRocket
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = HammerExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.4;
   damageType       = $AnnDamageType;

   explosionRadius  = 20.0;
   kickBackStrength = 300.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 3.0;
   liveTime         = 3.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData HealRocket
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = HealExp;

   damageClass        = 0;  //Impact
   damageValue        = 0.01;
   damageType         = $HealDamageType;

   muzzleVelocity     = 90.0;
   totalTime          = 0.4;
   liveTime           = 0.2;
   lightRange         = 6.0;
   lightColor         = { 1.0, 1.0, 1.0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};
//-----------------------------------
RocketData SummonBolt
{
   bulletShapeName  = "rsmoke.dts";
   explosionTag     = SummonShockwave;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $EnergyDamageType;

   explosionRadius  = 30.0;
   kickBackStrength = 0;
   muzzleVelocity   = 85.0;
   terminalVelocity = 85.0;
   acceleration     = 5.0;
   totalTime        = 1.0;
   liveTime         = 1.0;
   lightRange       = 10.0;
   lightColor       = { 1, 1, 0 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 0.0;

   soundId = SoundWindAmbient;
};

//------------------------------------------------------------
BulletData StutterBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 1;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $StutterDamageType;

   aimDeflection      = 0.0;
   muzzleVelocity     = 425.0;
   totalTime        = 0.1;
   liveTime         = 0.1;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1;
   tracerLength       = 60;
};
//------------------------------

BulletData SlingBullet
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = rocketExp;
   //expRandCycle       = 2;
   mass               = 0.1;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius    = 10.0;
	//kickBackStrength = 150.0;
   damageValue        = 0.2;
   damageType         = $TridentDamageType;
   aimDeflection      = 0.01;
   muzzleVelocity     = 250.0;
   totalTime          = 0.9;
   inheritedVelocityScale = 0.5;
   isVisible          = True;
   
};
//--------------------------------------
GrenadeData HeMIRVShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.45;
   mass               = 5.0;
   elasticity         = 0.25;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};

function  HeMIRVShell::onAdd(%this)
{
%client = GameBase::getOwnerClient(%this);
%clteam = Client::getTeam(%client);
//messageall(0,"%this = "@%this@" Client = "@%client);
schedule("HeMIRVShell::Prep("@%this@");",1,%this);
}

function HeMIRVShell::Prep(%this)
{
HeMIRVShell::LaunchEm(%this);
}

function HeMIRVShell::LaunchEm(%this)
{

	%obj = newObject("","Mine","HeMIRVgrenade");
		%client = GameBase::getOwnerClient(%this);
		GameBase::setTeam (%obj,GameBase::getTeam(%client));
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.5,false);
		%pos = GameBase::getPosition(%this);
		playSound(SoundWeaponSelect,%pos);
		schedule("HeMIRVShell::Prep("@%this@");",0.5,%this);
}

//--------------------------------------
GrenadeData EmpMIRVShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = turretExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.45;
   mass               = 5.0;
   elasticity         = 0.25;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.001;
   damageType         = $EmpDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};

function  EmpMIRVShell::onAdd(%this)
{
schedule("EmpMIRVShell::Prep("@%this@");",1,%this);
}

function EmpMIRVShell::Prep(%this)
{
EmpMIRVShell::LaunchEm(%this);
}

function EmpMIRVShell::LaunchEm(%this)
{

	%obj = newObject("","Mine","EmpMIRVgrenade");
		%client = GameBase::getOwnerClient(%this);
		GameBase::setTeam (%obj,GameBase::getTeam(%client));
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.5,false);
		%pos = GameBase::getPosition(%this);
		playSound(SoundWeaponSelect,%pos);
		schedule("EmpMIRVShell::Prep("@%this@");",0.5,%this);
}

//-----------------------------------

RepairEffectData LifeBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 5.0;
   lightColor = { 1, 1, 1 };
};

function LifeBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.repairRate = 0.1;
	%player.repairTarget = %target;

		if (GameBase::getDataName(%target).description != "Altar of Life")
		{
		Client::sendMessage(%client,0,"May only be used upon the Altar of Life.");
		Player::trigger(%player,$WeaponSlot,false);
		%player.repairTarget = -1;
		return;
		}
	else
		if (GameBase::getDamageLevel(%target) == 0) {
			Client::sendMessage(%client,0,"Rite has been completed.");
			Player::trigger(%player,$WeaponSlot,false);
			//%player.repairTarget = -1;
			return;
			}
			else
			{
			Client::sendMessage(%client,0,"Ritual of Life has begun.");
			%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
			GameBase::setAutoRepairRate(%player.repairTarget,%rate);
			}

}
//fhfdhf   1945
function LifeBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
				if(GameBase::getDataName(%object).description == "Altar of Life")
			{
				if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Ritual Completed!");
				}
			else 
				Client::sendMessage(%client,0,"Ritual Stopped");

			}		
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
}

function LifeBolt::checkDone(%this, %player)
{
	%object = %player.repairTarget;
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == Life &&
		 %player.repairTarget != -1) 
	{
			if (GameBase::getDamageLevel(%object) == 0) 
				{
				playSound(holyrite, GameBase::getPosition(%object));
				Player::trigger(%player,$WeaponSlot,false);
				LifeBolt::Rite();
				GameBase::startfadeout(%object);
				schedule("deleteObject("@%object@");",2);
				return;
				}
	}
}

function  LifeBolt::Rite()
{
	$TeamItemCount[GameBase::getTeam(%player) @ "LifeAltar"]--;
	for(%cl = Client::getFirst();%cl != -1;%cl = Client::getNext(%cl))
	{
		if(%cl.Undead || %cl.Litch)
		{
		playSound(holyrite, GameBase::getPosition(%cl));
		%player = Client::getOwnedObject(%cl);
		Player::blowUp(%player);
		Player::kill(%player);
		if(%cl.Undead)
		{
		Client::sendMessage(%cl,1,"You have been released from your Undead state by the Ritual of Life!");
		%cl.Undead = false;
		}
		else
		{
		Client::sendMessage(%cl,1,"Your soul has been freed from the Litch by the Ritual of Life!");
		%cl.Litch = false;
		%cl.isFree = true;
		$Evil::Litch = "";
		Player::setItemCount(%cl,UndeadSpell,0);
		}
		Game::assignClientTeam(%cl);
		}
	else
		Client::sendMessage(%cl,0,"The Ritual of Life has been performed!");
	}
}

//-----------------------------------

RepairEffectData BrimBolt
{
   bitmapName       = "laserPulse.bmp";
   boltLength       = 5.0;
   segmentDivisions = 4;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 5.0;
   lightColor = { 1, 0, 0 };
};

function BrimBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.repairRate = 0.2;
	%player.repairTarget = %target;

		if (GameBase::getDataName(%target).description != "Altar of Brimstone")
		{
		Client::sendMessage(%client,0,"May only be used upon the Altar of Brimstone.");
		Player::trigger(%player,$WeaponSlot,false);
		%player.repairTarget = -1;
		return;
		}
	else
		if (GameBase::getDamageLevel(%target) == 0) {
			Client::sendMessage(%client,0,"Rite has been completed.");
			Player::trigger(%player,$WeaponSlot,false);
			//%player.repairTarget = -1;
			return;
			}
			else
			{
			Client::sendMessage(%client,0,"Ritual of Brimstone has begun.");
			%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
			GameBase::setAutoRepairRate(%player.repairTarget,%rate);
			}

}
//fhfdhf   1945
function BrimBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
				if(GameBase::getDataName(%object).description == "Altar of Brimstone")
			{
				if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Ritual Completed!");
				}
			else 
				Client::sendMessage(%client,0,"Ritual Stopped");

			}		
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
}

function BrimBolt::checkDone(%this, %player)
{
	%object = %player.repairTarget;
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == Brim &&
		 %player.repairTarget != -1) 
	{
			if (GameBase::getDamageLevel(%object) == 0) 
				{
				Player::trigger(%player,$WeaponSlot,false);
				BrimBolt::Rite(%player);
				GameBase::startfadeout(%object);
				schedule("deleteObject("@%object@");",2);
				return;
				}
	}
}

function  BrimBolt::Rite(%player)
{
$TeamItemCount[GameBase::getTeam(%player) @ "BrimstoneAltar"]--;
%playteam = GameBase::getTeam(%player);
	
	for(%cl = Client::getFirst();%cl != -1;%cl = Client::getNext(%cl))
	{
	%armor = Player::getArmor(%cl);
	%clteam = Client::getTeam(%cl);
	if(%armor == magarmor || %armor == magfemale && %clteam == %playteam)
		{
	Player::setItemCount(%cl,Brimstone,1);
	Player::setItemCount(%cl,Brim,0);
	Client::sendMessage(%cl,0,"Rite of Brimstone has been completed!");
	playSound(holyrite, GameBase::getPosition(%cl));
		}
	}
}

//------------------------------

LightningData holyCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $HolyDamageType;
   boltLength       = 300.0;
   coneAngle        = 15.0;
   damagePerSec      = 0.4;
   energyDrainPerSec = 60.0;
   segmentDivisions = 5;
   numSegments      = 1;
   beamWidth        = 1.0;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1, 1, 1 };

   soundId = SoundELFFire;
};

function holyCharge::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $HolyDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}
//--------------------------------------
BulletData blessBolt
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;  //Impact
   damageValue        = 0.01;
   damageType         = $GiveDamageType;

   muzzleVelocity     = 55.0;
   totalTime          = 0.3;
   liveTime           = 0.1;
   lightRange         = 6.0;
   lightColor         = { 1, 1, 1 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   //soundId = SoundJetLight;
};
