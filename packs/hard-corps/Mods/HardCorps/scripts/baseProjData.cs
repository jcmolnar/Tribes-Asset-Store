# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
$BulletDamageType      =  1;
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
$ClusterDamageType        = 14;
$EMPulseDamageType        = 15;
$TurretDamageType = 16;
$MissionAreaDamageType = 17;
$RotaryCannonDamageType = 18;
$NapalmLauncherDamageType = 19;
$VehicleBombDamageType = 20;
$ClusterCannonDamageType = 21;


//--------------------------------------
BulletData ChaingunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.11;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 0.0;
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

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $TurretDamageType;

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
   damageType         = $TurretDamageType;

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
   damageType         = $TurretDamageType;

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
   mass             = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 120.0;
   aimDeflection      = 0.005;
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
   damageValue      = 0.403;
   damageType       = $TurretDamageType;
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

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.0055;
   baseDamageType    = $LaserDamageType;

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
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

LightningData lightningCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 50.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.08;
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

LightningData WeaponLockOutAttack
{
   bitmapName       = "paintPulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.001;
   energyDrainPerSec = 99.0;
   segmentDivisions = 1;
   numSegments      = 1;
   beamWidth        = 0.5;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   //soundId = SoundELFFire;
};

LightningData RearmingSystem
{
   bitmapName       = "repairadd.bmp";
   damageType       = $ElectricityDamageType;

   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.001;
   energyDrainPerSec = 97.0;

   segmentDivisions = 4;
   beamWidth        = 0.125;
   numSegments      = 5;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };

   //soundId = SoundELFFire;
};

LightningData ImpulseTurretAttack
{
   //bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.001;
   energyDrainPerSec = 98.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   //soundId = SoundELFFire;
};

LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $TurretDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.08;
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
	if (%enDrainPerSec == 99.0)
	{
		%client = Player::getClient(%target);
		%item = Player::getMountedItem(%client,$WeaponSlot);
		if (Player::getMountedItem(%client,$WeaponSlot) != -1 && Player::getMountedItem(%client,$WeaponSlot) != RepairGun && Player::getMountedItem(%client,$WeaponSlot) != PowerPackGun) 
			{
  				Item::playPickupSound(%item);
				Player::unmountitem(%client,%item);
				Client::sendMessage(%client,1,"Weapon Systems Locked Down..."); 
				playSound(SoundWeaponLock,GameBase::getPosition(%target));
			}
	} else 
	{
		if (%enDrainPerSec == 98.0)
			{
				%Zvalue = GameBase::GetRotation(Client::getOwnedObject(%target));
				%velocity = -25;
				%shooterDir = Vector::getFromRot(GameBase::getRotation(%target),%velocity,%Zvalue);
				Player::applyImpulse(%target, %shooterDir);
			}

		if (%enDrainPerSec == 97.0)
			{
				%client = Player::getClient(%target);
				%ammo = GameBase::getEnergy(%target);
				%dam = GameBase::getDamageLevel(%target);
				if (%dam > 0)
					{
						%dam-=0.02;
						if (%dam <= 0)
							{
								Client::sendMessage(%client,1,"Repair Complete."); 
								%dam = 0;
							}
						GameBase::setDamageLevel(%target, %dam);
					}
				if (%ammo < 100)
					{
						%ammo++;
						if (%ammo >= 100) 
							{
								Client::sendMessage(%client,1,"Rearming Complete."); 
								%ammo = 100;
							}
						GameBase::setEnergy(%target, %ammo);
					}
			}

		if(GameBase::getTeam(%shooterId) != GameBase::getTeam(%target) && %enDrainPerSec != 97.0)
		{
			%typeoftarget = getObjectType(%target);
			%typeofshooter = getObjectType(%shooterId);

			if ((%typeoftarget == "Player" || %typeoftarget == "Moveable") && %typeofshooter == "Player") 
			{
				%Zvalue = GameBase::GetRotation(Client::getOwnedObject(%target));
				%velocity = -25;
				%shooterDir = Vector::getFromRot(GameBase::getRotation(%target),%velocity,%Zvalue);
				Player::applyImpulse(%target, %shooterDir);
			}
			
			if (%enDrainPerSec != 98.0 && %enDrainPerSec != 97.0)
				{
					%damVal = %timeSlice * %damPerSec;
					%enVal  = %timeSlice * %enDrainPerSec;
					GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

					%typeoftarget = Gamebase::getDataName(%target);
					if (%typeoftarget != "Scout" && %typeoftarget != "LAPC" && %typeoftarget != "HAPC")
						{
							%energy = GameBase::getEnergy(%target);
						 	%energy = %energy - %enVal;
							if (%energy < 0) %energy = 0;
						      GameBase::setEnergy(%target, %energy);
						}
				}
		}
	}
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

	if (%target == %player) {
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
		%obj = GameBase::getDataName(%player.repairTarget);
		if(%obj == "InteriorForceField" || %obj == "ExteriorForceField") 
			{
				Client::sendMessage(%client,0,"Nothing in range.  Use the Power Generator Pack to recharge Force Fields.");
				Player::trigger(%player, $WeaponSlot, false);
				%player.repairTarget = -1;
				return;
			}
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
		if ($UseAdjustedScoring == "true")
			{
				if (GameBase::getDamageState(%target) != "Enabled")
					{
						if(%target.healerguy == "") 
							{
								%target.healerguy = %player;
							}
					}
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
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	%client = Player::getClient(%player);
	%object = %player.repairTarget;
	if (%object != -1)
		{
			%typeoftarget = getObjectType(%object);
			if (%typeoftarget == "Player")
				{
					%rclient = Player::getClient(%player.repairTarget);
					%name = Client::getName(%rclient);
				} else
				{
					%name = GameBase::getMapName(%player.repairTarget);
				}
		}

	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&	%player.repairTarget != -1) 
		{
			if (%object == %player) 
				{
					if (GameBase::getDamageLevel(%player) == 0) 
						{
							Player::trigger(%player,$WeaponSlot,false);
							return;
						}
				} else
				{
					if ($UseAdjustedScoring == "true" && GameBase::getDamageState(%object) == "Enabled" && %player == %object.healerguy && %object.pointforhealing == "false")
						{
							if (%client.showscorebonuses == "true") DoDestroyScoring(%player.repairTarget,%client,"Repair");
							%object.pointforhealing = "true";
						}
					if (GameBase::getDamageLevel(%object) == 0) 
						{
							if ($UseAdjustedScoring == "true")
								{
									if (GameBase::getTeam(%this) == GameBase::getTeam(%player))
										{
											if (%client.showscorebonuses == "true") Client::sendMessage(%client, 0, "You receive one point for fully repairing " @ %name @ ".");
											%client.score++;
											%client.defencebonus++;
											Game::refreshClientScore(%client);
										} else
										{
											if (%client.showscorebonuses == "true") Client::sendMessage(%client, 0, "You are penalized one point for fully repairing " @ %name @ ".");
											%client.score--;
											Game::refreshClientScore(%client);
										}
								}

							%object.healerguy = "";
							%object.pointforhealing = "false";
							Player::trigger(%player,$WeaponSlot,false);
							return;
						}
				}
		}
}

LaserData MotionLaser
{
   laserBitmapName   = "laserPulse.bmp";
   //hitName           = "laserhit.dts";

   damageConversion  = 0.0;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
};

//---------------------------------------

 BulletData PointDefenceBullet
 {
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.03;
   damageType         = $TurretDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
 };

 BulletData RotaryCannonAttack
 {
   bulletShapeName    = "bullet.dts";
   explosionTag = debrisExpSmall;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.175;
   damageType         = $RotaryCannonDamageType;

   aimDeflection      = 0.0001;
   muzzleVelocity     = 425.0;
   totalTime          = 0.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
 };

function RotaryCannonAttack::onAdd(%this)
{
	%this.damage = 0;
}
function RotaryCannonAttack::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

 BulletData HeavyTurretAttack
 {
   bulletShapeName    = "rocket.dts";
   explosionTag = debrisExpSmall;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.06;
   damageType         = $TurretDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 120.0;
   totalTime          = 4.0;
   liveTime		    = 2.0;
   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
 };

function HeavyTurretAttack::onAdd(%this)
{
	%this.damage = 0;
}
function HeavyTurretAttack::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

BulletData ClustergunShell
 {
	 bulletShapeName = "rocket.dts";
	 explosionTag = ClustergunExp;
	 mass = 0.05;
	 bulletHoleIndex = 0;
	 collisionRadius    = 15.0;
	 damageClass = 1;
	 explosionRadius    = 3;
	 kickBackStrength   = 125.0;
	 damageValue = 0.055;
	 damageType = $ClusterCannonDamageType;
	 aimDeflection = 0.015;

	 muzzleVelocity = 150.0;
	 totalTime = 1.75;
	 liveTime = 0.35;
	 inheritedVelocityScale = 0.8;
	 isVisible = True;
	
	 triggerRadius = 5;
 	 damageLevel = {1.0, 1.0};
	 maxDamage = 1.0;

	 tracerPercentage   = 100.0;
	 tracerLength = 30;
	 smokeName              = "mortartrail.dts"; //plasmatrail.dts";
 };

function ClustergunShell::onAdd(%this)
{
	%this.damage = 0;
}
function ClustergunShell::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

//--------------------------------------
RocketData EMPulse
{
   bulletShapeName = "rocket.dts";
   explosionTag    = EMPulseExp;

   collisionRadius = 0.0;
   mass            = 0.1;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.001;
   damageType       = $EMPulseDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 15.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 180.0;
   acceleration     = 10.0;

   triggerRadius = 5;
   damageLevel = {0.001, 0.001};
   maxDamage = 0.001;

   totalTime        = 2.5;
   liveTime         = 3.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 1.0, 0.4 };

   inheritedVelocityScale = 0.0;

   // rocket specific
   trailType   = 1;
   trailLength = 8;
   trailWidth  = 0.3;

   soundId = SoundShieldOn;
};

RepairEffectData PowerPackEffect 
{ 
	bitmapName = "lightningNew.bmp"; 
	boltLength = 25.0; 
	segmentDivisions = 2; 
	beamWidth = 0.27; 
	updateTime = 100; 
	skipPercent = 0.5; 
	displaceBias = 0.03; 
	lightRange = 6.0; 
	lightColor = { 0.25, 0.25, 1.0 }; 
}; 

function PowerPackEffect::onAcquire(%this, %player, %target) 
{
	%client = Player::getClient(%player); 
	%player.powerTarget = ""; 
	%objType = getObjectType(%target); 
	if(%objType == "Player") 
		{
			if(%target == %player) 
				{ 
					Client::sendMessage(%client,0,"Nothing to power in range"); 
					Player::trigger(%player, $WeaponSlot, false); 
					return; 
				}
			%tc = Player::getClient(%target); 
			if(%tc.isPowered) 
				{
					Player::trigger(%player, $WeaponSlot, false); 
					return; 
				} 
			Client::sendMessage(%client,0, "Powering " @ Client::getName(%tc)); 
			Client::sendMessage(%tc,0, "Receiving power from " @ Client::getName(%client)); 
			%tc.isPowered = true; 
			%player.powerTarget = %target; 
			GameBase::setRechargeRate(%target, 30); 
			return; 
		} else if(%objType == "Flier")
		{
			%player.powerTarget = %target; 
			%target.shieldStrength = %target.shieldStrength + 0.12; 
			Client::sendMessage(%client,0, "Shielding " @ 
			$VehicleToItem[GameBase::getDataName(%target)].description); 
			return; 
		}
	%obj = GameBase::getDataName(%target); 
	if (GameBase::getDamageState(%target) != "Enabled" && %obj != "InteriorForceField" && %obj != "ExteriorForceField") 
		{ 
			Client::sendMessage(%client,0, %obj.description @ " is damaged"); 
			Player::trigger(%player, $WeaponSlot, false); 
			return; 
		} 

	if(GameBase::isPowered(%target)) 
		{ 
			if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation") 
				{ 
					Client::sendMessage(%client,0, %obj.description @ " is already powered"); 
					Player::trigger(%player, $WeaponSlot, false); 
					return; 

				} else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor" || %obj == "MortarTurret") 
				{ 
					%player.powerTarget = %target; 
					%player.rechargeRate = GameBase::getRechargeRate(%target);
					Client::sendMessage(%client,0, "Enhancing " @ %obj.description @ ""); 
					GameBase::setRechargeRate(%target,15); 
					return;
				}
		} 

	if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation") 
		{ 
			%player.powerTarget = %target; 
			Client::sendMessage(%client,0, "Powering " @ %obj.description); 
			GameBase::playSequence(%target,0,"power"); 
			GameBase::playSequence(%target,1); 
			%target.StationTempPower = true; 
		} else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor" || %obj == "MortarTurret") 
		{ 
			%player.powerTarget = %target; 
			Client::sendMessage(%client,0, "Powering " @ %obj.description); 
			%target.shieldStrength = 0.03; 
			GameBase::setRechargeRate(%target,10); 
	} else if(%obj == "DeployableInvStation" || %obj == "DeployableAmmoStation")
		{
			if ((%obj == "DeployableInvStation" && %target.Energy < $RemoteInvEnergy) || (%obj == "DeployableAmmoStation" && %target.Energy < $RemoteAmmoEnergy))
				{
					%player.powerTarget = %target; 
					Client::sendMessage(%client,0, "Recharging " @ %obj.description @ ""); 
					%target.recharging = "true";
					PowerPackEffect::PowerRecharge(%player.powerTarget,%obj);
				} else 
				{
					Client::sendMessage(%client,0, "" @ %obj.description @ " is fully charged."); 
					Player::trigger(%player, $WeaponSlot, false); 
					return; 
				}

	} else if(%obj == "InteriorForceField" || %obj == "ExteriorForceField")
		{
			%player.powerTarget = %target; 
			%player.powerRate   = 0.40;

			if (GameBase::getDamageLevel(%player.powerTarget) == 0) 
				{
					Client::sendMessage(%client,0,%obj.description @ " is not damaged");
					Player::trigger(%player,$WeaponSlot,false);
					%player.powerTarget = -1;
					return;
				}
			Client::sendMessage(%client,0,"Recharging " @ %obj.description);
		
			%rate = GameBase::getAutoRepairRate(%player.powerTarget) + %player.powerRate;
			GameBase::setAutoRepairRate(%player.powerTarget,%rate);
		} else 
		{ 
			Client::sendMessage(%client,0,"Nothing to power in range"); 
			Player::trigger(%player, $WeaponSlot, false); 
		} 
} 

function PowerPackEffect::onRelease(%this, %player) 
{ 
	if (%player.powerTarget != "") 
		{ 
			%objType = getObjectType(%player.powerTarget); 
			if(%objType == "Flier") 
				{ 
					%player.powerTarget.shieldStrength = %player.powerTarget.shieldStrength - 0.12; 
					%player.powerTarget = ""; 
					return; 
				} else if(%objType == "Player") 
				{ 
					Player::getClient(%player.powerTarget).isPowered = false; 
					GameBase::setRechargeRate(%player.powerTarget, 8); 
					%player.powerTarget = ""; 
					return; 
				} 
			%obj = GameBase::getDataName(%player.powerTarget);
			if(%obj == "InteriorForceField" || %obj == "ExteriorForceField") 
				{
					%object = %player.powerTarget;
					if (%object != -1) 
						{
							%client = Player::getClient(%player);
							if (GameBase::getDamageLevel(%object) == 0) 
								{
									Client::sendMessage(%client,0,"Recharging Complete");
								} else 
								{
									Client::sendMessage(%client,0,"Recharging Stopped");
								}
						}
					%rate = GameBase::getAutoRepairRate(%object) - %player.powerRate;
				      if (%rate < 0) %rate = 0;
      				GameBase::setAutoRepairRate(%object,%rate);
					return;
				}
			%obj = GameBase::getDataName(%player.powerTarget); 
			if((GameBase::isPowered(%player.powerTarget)) && (%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor" || %obj == "MortarTurret"))
				{ 
					%client = Player::getClient(%player);
					Client::sendMessage(%client,0,"Enhancing Stopped");
					GameBase::setRechargeRate(%player.powerTarget,%player.rechargeRate); 
					%player.powerTarget = ""; 
					return;
				}

			if(%obj == "DeployableInvStation" || %obj == "DeployableAmmoStation")
				{
					%object = %player.powerTarget;
					if (%object != -1)
						{
							%player.powerTarget.recharging = "false";
							%client = Player::getClient(%player);
							if ((%obj == "DeployableInvStation" && %player.powerTarget.Energy >= $RemoteInvEnergy) || (%obj == "DeployableAmmoStation" && %player.powerTarget.Energy >= $RemoteAmmoEnergy))
								Client::sendMessage(%client,0,"Recharging Complete");
									else Client::sendMessage(%client,0,"Recharging Stopped");
						}
					return;
				}

			if(!GameBase::isPowered(%player.powerTarget)) 
				{ 
					%obj = GameBase::getDataName(%player.powerTarget); 
					if(%obj == "InventoryStation" || %obj == "AmmoStation" || %obj == "CommandStation") 
						{ 
							(%player.powerTarget).StationTempPower = false; 
							Station::weaponCheck(%player.powerTarget); 
							GameBase::stopSequence(%player.powerTarget,0); 
							GameBase::setSequenceDirection(%player.powerTarget,1,0); 
							GameBase::pauseSequence(%player.powerTarget,1); 
							GameBase::stopSequence(%player.powerTarget,2); 
							Station::checkTarget(%player.powerTarget); 
							%obj = (%player.powerTarget).lastPlayer; 
							if(%player.powerTarget == %obj.inStation) %obj.inStation = false; 
						} else if(%obj == "PlasmaTurret" || %obj == "ELFTurret" || %obj == "RocketTurret" || %obj == "IndoorTurret" || %obj == "PulseSensor" || %obj == "MediumPulseSensor" || %obj == "MortarTurret") 
						{ 
							GameBase::setActive(%player.powerTarget, false); 
							(%player.powerTarget).shieldStrength = 0; 
							GameBase::setRechargeRate(%player.powerTarget,0); 
							GameBase::pauseSequence(%player.powerTarget,0); 
							Turret::checkOperator(%player.powerTarget); 
						}
				} 


		%player.powerTarget = ""; 
	} 
} 

function PowerPackEffect::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == PowerPackGun && %player.powerTarget != -1) 
		{
			%obj = GameBase::getDataName(%player.powerTarget);
			if(%obj == "InteriorForceField" || %obj == "ExteriorForceField") 
				{
					if (GameBase::getDamageLevel(%player.powerTarget) == 0) 
						{
							Player::trigger(%player,$WeaponSlot,false);
							return;
						}
				}
			if(%obj == "DeployableInvStation" || %obj == "DeployableAmmoStation")
				{
					%client = Player::getClient(%player);
					if (%obj == "DeployableInvStation" && %player.powerTarget.Energy >= $RemoteInvEnergy)
						{
							%player.powerTarget.Energy = $RemoteInvEnergy;
							%player.powerTarget.recharging = "false";
							Player::trigger(%player,$WeaponSlot,false);
							if ($UseAdjustedScoring == "true") %client.defencebonus++;
							return;
						}
					if (%obj == "DeployableAmmoStation" && %player.powerTarget.Energy >= $RemoteAmmoEnergy)
						{
							%player.powerTarget.Energy = $RemoteAmmoEnergy;
							%player.powerTarget.recharging = "false";
							Player::trigger(%player,$WeaponSlot,false);
							if ($UseAdjustedScoring == "true") %client.defencebonus++;
							return;
						}
				}

		}
}

function PowerPackEffect::PowerRecharge(%target,%obj)
{
	if (%target.recharging == "true")
		{
			%target.Energy += 10;
			if (%obj == "DeployableInvStation" && %target.Energy >= $RemoteInvEnergy) 
				{
					%target.Energy = $RemoteInvEnergy;
				}
			if (%obj == "DeployableAmmoStation" && %target.Energy >= $RemoteAmmoEnergy) 
				{
					%target.Energy = $RemoteAmmoEnergy;
				}
			schedule("PowerPackEffect::PowerRecharge(" @ %target @ ",\"" @ %obj @ "\");",0.1,%target);
		}
}

GrenadeData VehicleBombAttack
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = BulletExp0;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0.0;
   elasticity         = 0.1;

   muzzleVelocity   = 0.0;
   terminalVelocity = 200.0;
   acceleration     = 1.0;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $VehicleBombDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 25.0;
   maxLevelFlightDist = 30;
   totalTime          = 35.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.1;

   lightRange = 10.0; 
   lightColor = { 1.0, 0.0, 0.0 }; 

   inheritedVelocityScale = 1.0;
   //smokeName              = "rsmoke.dts";
};

function VehicleBombAttack::onAdd(%this)
{
	schedule("VehicleBombAttackExplode(" @ %this @ ");",1.0,%this);
}

function VehicleBombAttackExplode(%this) 
{
	for(%i = 0; %i < 5; %i++)  
		{
			%obj = newObject("","Mine","VehicleBombBlast");
 			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%this,100,true);
		}
}

GrenadeData NapalmAttack
{
      explosionTag = NapalmExp;
 	collideWithOwner = True;
 	ownerGraceMS = 50;
 	collisionRadius = 10.0;
 	mass = 5.0;
 	elasticity = 0.1;
 	damageClass = 1;
 	damageValue = 0.30;
 	damageType = $NapalmLauncherDamageType;
 	explosionRadius = 10.0;
 	kickBackStrength = 0.1;
 	maxLevelFlightDist = 50;
      aimDeflection = 0.35;
 	totalTime = 4.0;
 	liveTime = 0.02;
 	projSpecialTime = 0.01;
 	lightRange = 10.0;
	lightColor = { 1, 1, 0 }; 
 	inheritedVelocityScale = 1.5;
 	smokeName = "plasmatrail.dts";
 	//soundId = SoundNapalmAttack;
 };

function NapalmAttack::onAdd(%this)
{
	schedule("NapalmAttackExplode(" @ %this @ ");",1.0,%this);
}

function NapalmAttackExplode(%this) 
{
	for(%i = 0; %i < 5; %i++)  
		{
			%obj = newObject("","Mine","NapalmBlast");
 			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%this,-100,true);
		}
}

 BulletData AATurretAttack
 {
   bulletShapeName    = "bullet.dts";
   explosionTag = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.001;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.06;
   damageType         = $TurretDamageType;

   aimDeflection      = 0.001;
   muzzleVelocity     = 200.0;
   totalTime          = 6.0;
   liveTime		    = 4.0;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
 };

