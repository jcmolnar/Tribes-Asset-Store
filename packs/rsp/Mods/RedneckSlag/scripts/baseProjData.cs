//Globals
$hacking = "false";
$Viral = "false";
$isInfected[0] = "false";
$origTeam[0] = "-1";
$minHacked = "-1";
$maxHacked = "-1";
$minInfected = "-1";
$minInfected = "-1";
//End Globals

# Damage Types
#
$ImpactDamageType		  = -1;
$LandingDamageType	  =  0;
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
//--------------------------------
//Begin Redneck Slag Additions
$NeutralDamageType    = 14;
$FighterGunDamageType  = 15;
$PulseMortarDamageType = 16;
$GatBlasterDamageType = 17;
$SniperRifleDamageType = 18;
$NukeGrenadeDamageType = 19;
$RmtChainDamageType = 20;
$PlasmaCannonDamageType = 21;
$HellfireDamageType = 22;
$KamikazeDamageType = 23;
$SniperRifleHeadShot = 24; //Sniper rifle head shot damage type. For messages only
$AAMissileDamageType = 25;
$BlanketBombDamageType = 26;
$FlakDamageType = 27;
$AntiMatterDamageType = 28;

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

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $EnergyDamageType;

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

//AA Rocket
//--------------------------------------
SeekingMissileData AATurretMissile
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $AAMissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 75.0;
   totalTime         = 90;
   liveTime          = 90;
   seekingTurningRadius    = 2.0;
   nonSeekingTurningRadius = 2.0;
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
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
LaserData sniperLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

//   damageConversion  = 0.007;
   damageConversion  = 0.0022;
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
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.05;//Was .15 in 1.14b
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.1;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

LightningData turretCharge
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
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
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
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

//--------------------------------------
// Fighter Round - HightechRedneck
//--------------------------------------
BulletData FighterBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.15;
   damageType         = $FighterGunDamageType;

   aimDeflection      = 0.004;
   muzzleVelocity     = 500.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 60;
};

//--------------------------------------
// Pulse Mortar Shell HightechRedneck
//--------------------------------------

GrenadeData PulseMortarShell
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = PulseMortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 2.0;
   elasticity         = 0.65;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 6.0;
   damageType         = $PulseMortarDamageType;

   explosionRadius    = 50.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 175;
   totalTime          = 30.0;
   liveTime           = 3.0;
   projSpecialTime    = 0.075;

   inheritedVelocityScale = 0.7;
   smokeName              = "fusionbolt.dts";
};

//----------------------------------------
// Gat. Blaster Shot
//----------------------------------------
BulletData GatBlasterShot
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = blasterExp;

   damageClass        = 0;
   damageValue        = 0.05;
   damageType         = $GatBlasterDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 3.0;
   liveTime           = 2.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//------------------------------------------
// Sniper Round
//------------------------------------------

BulletData SniperRifleShot
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = SniperShotExp;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.7;
   damageType         = $SniperRifleDamageType;

   muzzleVelocity     = 2000.0;
   totalTime          = 3.0;
   inheritedVelocityScale = 0.0;
   isVisible          = false;

   lightRange         = 2.0;
   lightColor         = { 0.85, 0.75, 0.0 };

   tracerPercentage   = 1.0;
   tracerLength       = 50;
};

//--------------------------------------
// Remote Chain Turret Rounds HightechRedneck
//--------------------------------------

BulletData RmtChainBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $RmtChainDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 425.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//-----------------------------------------
// Plasma Cannon Round - Hightech Redneck
//-----------------------------------------
BulletData PlasmaCannonBlast
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = PlasmaCannonExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.45;
   damageType         = $PlasmaCannonDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 55.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

//-------------------------------------------------------
// Hack Gun Beam - RSP - HR
//-------------------------------------------------------
RepairEffectData HackBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.2;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function HackBolt::onAcquire(%this, %player, %target)
{
	if($RSP::AllowHacking) {

		%client = Player::getClient(%player);
	
		if (%target != %player) {
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player); //added
			%pName = Client::getName(%client); //added
			%tName = getTeamName(%team); //added
			
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
	
			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;
	
			if(%team == %pTeam) {
				Client::sendMessage(%client,0,"You can't hack into things your team owns!");	
				return;
			}
				
			if(checkHackable(%name, %shape) || getObjectType(%player.repairTarget) == "Player") {
				if(getObjectType(%player.repairTarget) == "Player") {
					Client::sendMessage(%client,0,"Hacking electronics is possible but mind control?!?!?! Your kidding right?");
				}
				else {
					Client::sendMessage(%client,0,"It is not possible to hack in to a " @ %name);
					return;
				}
			}
			else {
				if(%name == "False" && %shape == "grenammo") {
					Client::sendMessage(%client,0,"Disarming the Nuke Pack. Please wait...");
					TeamMessages(0, GameBase::getTeam(%player.repairTarget),Client::getName(%client) @ " has begun disarming a nuke.");
				}
				else {
					Client::sendMessage(%client,0,"Hacking " @ %name @ ". Please wait...");
				}

				$hacking = "true";
				if(!$origTeam[%target]) {
					$origTeam[%target] = %team;
				}
				hackingItem(%target, %pTeam, %pName, %tName, %name, %team, $RSP::HackTime, %client);
			}
		}	
	}
	else
	{
		Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}

function HackBolt::onRelease(%this, %player)
{
	$hacking = false;
}

function checkHackable(%name, %shape)
{
	if(%shape == "Generator" || %shape == "generator_p" || %shape == "solar_med" || %shape == "inventory_sta" || %shape == "elevator_4x4"
	|| %shape == "elevator_6x6" || %shape == "elevator_6x6_octagon" || %shape == "elevator_8x4" || %shape == "elevator_8x6" || %shape == "elevator_9x9"
	|| %shape == "elevator16x16_octo" || %shape == "elevator6X4" || %shape == "elevator_6x5" || %shape == "elevator_8x8" || %shape == "elevator6x4thin"
	|| %shape == "elevator6x6thin" || %shape == "elevator_5x5" || %shape == "elevator_4x5" || %shape == "door_top" || %shape == "door_bot"
	|| %shape == "newdoor1_l" || %shape == "newdoor1_r" || %shape == "newdoor2_l" || %shape == "newdoor2_r" || %shape == "newdoor3_l"
	|| %shape == "newdoor3_r" || %shape == "newdoor4_l" || %shape == "newdoor4_r" || %shape == "newdoor6_l" || %shape == "newdoor6_r"
	|| %shape == "door_8x8_l" || %shape == "door_8x8_r" || %shape == "forcefield" || %shape == "forcefield_3x4" || %shape == "forcefield_4x17"
	|| %shape == "newdoor3_r" || %shape == "newdoor4_l" || %shape == "newdoor4_r" || %shape == "newdoor6_l" || %shape == "newdoor6_r"
	|| %shape == "forcefield_4x14" || %shape == "forcefield_4x8" || %shape == "forcefield_5x5" || %shape == "door_4x4_diagonal" || %shape == "tower") {
		//Add any exceptions to top rule before this comment ex: if(%name != "Sub Generator")
			//return 0; //Uncomment if you add exceptions
		//else //Uncomment if you add exceptions
			return 1;
	}

	return 0;
}

function hackingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client)
{
	%shape = (GameBase::getDataName(%target)).shapeFile;
	
	if(%time > 0) {
		if($hacking) {		
			$RSP::HackStr[%client, 0] = %pName; $RSP::HackStr[%client, 1] = %tName; $RSP::HackStr[%client, 2] = %name; // PORT: names are not spliced into the scheduled script any more
			schedule("hackingItem('" @ %target @ "','" @ %pTeam @ "',$RSP::HackStr[" @ %client @ ",0],$RSP::HackStr[" @ %client @ ",1],$RSP::HackStr[" @ %client @ ",2],'" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "');", 1);
		}
	}
	else {
		if($hacking) {
		
			if($isInfected[%target]) {
				showDeathAnim(%client);
				Player::Kill(%client);
				messageallexcept(%client,0,%pName @ " thought it would be safe to hack the infected " @ %name @ ".");
			
				%randNum = getRandom() * 100;
			
				if(%randNum >= 50) {
					$isInfected[%target] = "false";
					Client::sendMessage(%client,0,"The viral infection was destroyed for the price of your life.");
				}
				else
				{
					Client::sendMessage(%client,0,"Your hacking attempt wasn't able to destroy the virus. What a pitiful waste of life.");
				}
				return 1;
			}
			//Client::sendMessage(%client,0,"Welcome " @ %pName @ " :)");
			else {
				if(%name == "False" && %shape == "grenammo") {
					TeamMessages(1, %pTeam, %pName @ " gets 2 points for disarming the " @ %tName @ "'s Nuke Pack!");
					TeamMessages(1, %team, %pName @ " disarmed the " @ %tName @ "Nuke Pack!");
					%client.score = %client.scoreKills + 2;
					Game::refreshClientScore(%client);
					$RSP::NukeActive[GameBase::getTeam(%target)] = False;
					deleteObject(%target);
				}
				else {
					TeamMessages(1, %pTeam, %pName @ " hacked into the " @ %tName @ "'s " @ %name @ "!");
					TeamMessages(1, %team, %pName @ " hacked into your teams " @ %name @ "!");
					GameBase::setTeam(%target,%pTeam);
					if($RSP::HackedTime) {
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", $RSP::HackedTime);
					}
					else {
						schedule("GameBase::setTeam('" @ %target @ "','" @ $origTeam[%target] @ "');", "300");
					}
			
					if(%target < $minHacked || $minHacked == -1) {
						$minHacked = %target;
					}
					if(%target > $maxHacked || $maxHacked == -1) {
						$maxHacked = %target;
					}
				}
			}
		}
	}
}

//-------------------------------------------------------
// Viral Gun Beam - RSP - HR
//-------------------------------------------------------
RepairEffectData ViralBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 10.0;
   segmentDivisions = 4;
   beamWidth        = 0.1;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function ViralBolt::onAcquire(%this, %player, %target)
{
	if($RSP::AllowHacking) {
		%client = Player::getClient(%player);
	
		if (%target != %player) {
			%player.repairTarget = %target;
			%name = GameBase::getMapName(%target);
			%team = GameBase::getTeam(%target);
			%pTeam = GameBase::getTeam(%player); //added
			%pName = Client::getName(%client); //added
			%tName = getTeamName(%team); //added
			
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
	
			%shape = (GameBase::getDataName(%player.repairTarget)).shapeFile;

			if($isInfected[%target] && %team == %pTeam) {
				Client::sendMessage(%client,0,"The " @ %name @ " is already infected.");
				return;
			}

			if(%team == %pTeam && !checkHackable(%name, %shape) && getObjectType(%player.repairTarget) != "Player") {
				Client::sendMessage(%client,0,"Starting viral upload!");
				$Viral = "true";
				infectingItem(%target, %pTeam, %pName, %tName, %name, %team, $RSP::HackTime, %client, 0);
				return;
			}

			if(%team != %pTeam && !checkHackable(%name, %shape) && getObjectType(%player.repairTarget) != "Player" && $isInfected[%target]) {
				Client::sendMessage(%client,0,"Starting viral flush!");
				$Viral = "true";
				infectingItem(%target, %pTeam, %pName, %tName, %name, %team, $RSP::HackTime, %client, 1);
				return;
			}
		}	
	}
	else {
		Client::sendMessage(%client,0,"Hacking/Infecting disabled on this server");
	}
}

function ViralBolt::onRelease(%this, %player)
{
	$Viral = "false";
}

function infectingItem(%target, %pTeam, %pName, %tName, %name, %team, %time, %client, %flush)
{
	if(%time > 0) {
		if($Viral) {
			$RSP::InfStr[%client, 0] = %pName; $RSP::InfStr[%client, 1] = %tName; $RSP::InfStr[%client, 2] = %name; // PORT: names are not spliced into the scheduled script any more
			schedule("infectingItem('" @ %target @ "','" @ %pTeam @ "',$RSP::InfStr[" @ %client @ ",0],$RSP::InfStr[" @ %client @ ",1],$RSP::InfStr[" @ %client @ ",2],'" @ %team @ "','" @ %time - 1 @ "','" @ %client @ "','" @ %flush @ "');", 1);
		}
	}
	else {
		if($Viral) {
			if(%flush) {
				$isInfected[%target] = "false";
				Client::sendMessage(%client,0,"Infection flushed.");
			}
			else
			{
				$isInfected[%target] = "true";
				Client::sendMessage(%client,0,"Infection completed.");
				TeamMessages(1, %pTeam, %pName @ " uploaded a defensive virus into the " @ %name @ "!");
				if($RSP::InfectedTime) {
					schedule("$isInfected[" @ %target @ "] = 'false';", $RSP::InfectedTime); // PORT: was 'true'
				}
				else {
					schedule("$isInfected[" @ %target @ "] = 'false';", "300"); // PORT: was 'true'
				}
			
				if(%target < $minInfected || $minInfected == -1) {
					$minInfected = %target;
				}
				if(%target > $maxInfected || $maxInfected == -1) {
					$maxInfected = %target;
				}
			}
		}
	}
}

function cleanUpHacks()
{
	if(!$minHacked) $minHacked = 8300;
	if(!$maxHacked) $maxHacked = 8300;
	if(!$minInfected) $minInfected = 8500;
	if(!$maxInfected) $maxInfected = 8500;
	
	for(%i = $minHacked;%i <= $maxHacked;%i++) {
		if($origTeam[%i]) { 
			//GameBase::setTeam(%i,$origTeam[%i]);
			$origTeam[%i] = -1;
			echo("Team changed");
		}
	}

	for(%i = $minInfected;%i <= $maxInfected;%i++) {
		if($isInfected[%i]) { 
			$isInfected[%i] = "false";
			echo("Infection flushed");
		}
	}

	$minHacked = -1;
	$maxHacked = -1;
	$minInfected = -1;
	$maxInfected = -1;
}

//Engineer Repair Bolt

RepairEffectData EngRepairBolt
{
   bitmapName       = "repairadd.bmp";
   boltLength       = 500.0;
   segmentDivisions = 10;
   beamWidth        = 0.125;

   updateTime   = 450;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.25, 0.25 };
};

function EngRepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
		Client::sendMessage(%client,0,"Nothing in range");
		Player::trigger(%player, $WeaponSlot, false);
		return;
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.5;
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
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function EngRepairBolt::onRelease(%this, %player)
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

function EngRepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == EngRepairGun &&
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

//--------------------------------------
// Pulse Mortar Shell HightechRedneck
//--------------------------------------

GrenadeData BlanketBombShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 2.5;
   elasticity         = 0.5;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 3.5;
   damageType         = $BlanketBombDamageType;

   explosionRadius    = 25.0;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 200;
   totalTime          = 15.0;
   liveTime           = 5.0;
   projSpecialTime    = 0.075;

   inheritedVelocityScale = 1;
   smokeName              = "smoke.dts";
};

//--------------------------------------------
// Hellfire Ammo - HightechRedneck
//--------------------------------------------
RocketData HellfireShot
{
   bulletShapeName = "rocket.dts";
   explosionTag    = rocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $HellfireDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 200.0;

   muzzleVelocity   = 65.0;
   terminalVelocity = 70.0;
   acceleration     = 5.0;

   totalTime        = 10.0;
   liveTime         = 11.0;

   lightRange       = 15.0;
   lightColor       = { 1.0, 0.7, 0.5 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------------
// Flak Ammo - HightechRedneck
//--------------------------------------------
GrenadeData FlakShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 25.0;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.5;
   damageType         = $FlakDamageType;

   explosionRadius    = 100.0;
   kickBackStrength   = 15.0;
   maxLevelFlightDist = 500;
   totalTime          = 1.0;    // special meaning for grenades...
   liveTime           = 0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

// Anti Matter shot - HTR
BulletData AntiMatterShot
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = flashExpLarge;

   damageClass        = 0;
   damageValue        = 1.0;
   damageType         = $AntiMatterDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 20.0;
   liveTime           = 1.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};