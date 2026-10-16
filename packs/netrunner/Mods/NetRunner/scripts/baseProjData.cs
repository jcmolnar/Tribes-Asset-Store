# Damage Types
#
$ImpactDamageType		= -1;
$LandingDamageType	= 0;
$BulletDamageType		= 1;
$EnergyDamageType		= 2;
$PlasmaDamageType		= 3;
$ExplosionDamageType	= 4;
$ShrapnelDamageType	= 5;
$LaserDamageType		= 6;
$MortarDamageType		= 7;
$BlasterDamageType	= 8;
$ElectricityDamageType	= 9;
$CrushDamageType		= 10;
$DebrisDamageType		= 11;
$MissileDamageType	= 12;
$MineDamageType		= 13;
$ArkFieldDamageType	= 14;
$ArkFieldDamageType2    = 15;
$ArkDamageType		= 16;

//--------------------------------------
BulletData KillerMK0
{
	bulletShapeName = "paint.dts";
	explosionTag = bulletExp0;
	mass = 0.05;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.03;
	damageType = $BulletDamageType;
	muzzleVelocity = 300.0;
	totalTime = 1.5;
	liveTime = 4.0;
	inheritedVelocityScale = 0.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//--------------------------------------
BulletData KillerMK1
{
	bulletShapeName = "paint.dts";
	explosionTag = bulletExp0;
	mass = 0.05;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.066;
	damageType = $BulletDamageType;
	muzzleVelocity = 300.0;
	totalTime = 1.5;
	liveTime = 4.0;
	inheritedVelocityScale = 0.0;
	isVisible = True;
 	tracerPercentage = 1.0;
	tracerLength = 30;
};

//--------------------------------------
BulletData KillerMK2
{
	bulletShapeName = "paint.dts";
	explosionTag = bulletExp0;
	mass = 0.05;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.102;
	damageType = $BulletDamageType;
	muzzleVelocity = 300.0;
	totalTime = 1.5;
	liveTime = 4.0;
	inheritedVelocityScale = 0.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//--------------------------------------
BulletData KillerICE
{
	bulletShapeName = "paint.dts";
	explosionTag = bulletExp0;
	mass = 0.05;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.088;
	damageType = $BulletDamageType;
	muzzleVelocity = 300.0;
	totalTime = 1.5;
	liveTime = 4.0;
	lightRange = 3.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//--------------------------------------
BulletData WatchdogICE
{
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	damageClass = 0;
	damageValue = 0.11;
	damageType = $EnergyDamageType;
	muzzleVelocity = 100.0;
	totalTime = 2.0;
	liveTime = 4.0;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 1.0 };
	inheritedVelocityScale = 0.0;
	isVisible = True;
	rotationPeriod = 1;
};

//--------------------------------------
BulletData RotweilerICE
{
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	damageClass = 0;
	damageValue = 0.22;
	damageType = $EnergyDamageType;
	muzzleVelocity = 100.0;
	totalTime = 2.0;
	liveTime = 4.0;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 1.0 };
	inheritedVelocityScale = 0.0;
	isVisible = True;
	rotationPeriod = 1;
};

//--------------------------------------
BulletData Decrypt
{
	bulletShapeName = "enbolt.dts";
	explosionTag = energyExp;
	damageClass = 0;
	damageValue = 0.001;
	damageType = $PlasmaDamageType;
	muzzleVelocity = 50.0;
	totalTime = 1.0;
	liveTime = 2.0;
	lightRange = 3.0;
	lightColor = { 1, 1, 0 };
	inheritedVelocityScale = 0.3;
	isVisible = True;
	rotationPeriod = 1;
};

//--------------------------------------
BulletData WormMK0
{
	bulletShapeName = "discb.dts";
	explosionTag = bulletExp0;
	mass = 0.5;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.074;
	damageType = $ExplosionDamageType;
	muzzleVelocity = 100.0;
	totalTime = 4.0;
	liveTime = 6.0;
	lightRange = 5.0;
	isVisible = True;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.0;
};

//--------------------------------------
BulletData WormMK1
{
	bulletShapeName = "discb.dts";
	explosionTag = bulletExp0;
	mass = 0.5;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.164;
	damageType = $ExplosionDamageType;
	muzzleVelocity = 100.0;
	totalTime = 4.0;
	liveTime = 6.0;
	lightRange = 5.0;
	isVisible = True;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.0;
};

//--------------------------------------
BulletData WormMK2
{
	bulletShapeName = "discb.dts";
	explosionTag = bulletExp0;
	mass = 0.5;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.253;
	damageType = $ExplosionDamageType;
	muzzleVelocity = 100.0;
	totalTime = 4.0;
	liveTime = 6.0;
	lightRange = 5.0;
	isVisible = True;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.0;
};

//--------------------------------------
BulletData WormICE
{
	bulletShapeName = "discb.dts";
	explosionTag = bulletExp0;
	mass = 0.5;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.44;
	damageType = $ExplosionDamageType;
	muzzleVelocity = 100.0;
	totalTime = 4.0;
	liveTime = 6.0;
	isVisible = True;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.0;
};

//--------------------------------------
GrenadeData ConfuseMK0
{
	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.5;
	elasticity = 0.45;
	damageClass = 1;// 0 impact, 1, radius
	damageValue = 0.1;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 150;
	totalTime = 30.0;// special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.0;
	smokeName = "smoke.dts";
};

//--------------------------------------
GrenadeData ConfuseMK1
{
	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.5;
	elasticity = 0.45;
	damageClass = 1;// 0 impact, 1, radius
	damageValue = 0.22;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 150;
	totalTime = 30.0;// special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.0;
	smokeName = "smoke.dts";
};

//--------------------------------------
GrenadeData ConfuseMK2
{
	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.5;
	elasticity = 0.45;
	damageClass = 1;// 0 impact, 1, radius
	damageValue = 0.34;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 150;
	totalTime = 30.0;// special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.0;
	smokeName = "smoke.dts";
};

//--------------------------------------
GrenadeData ConfuseICE
{
	bulletShapeName = "grenade.dts";
	explosionTag = grenadeExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 0.5;
	elasticity = 0.45;
	damageClass = 1;// 0 impact, 1, radius
	damageValue = 0.22;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	maxLevelFlightDist = 150;
	totalTime = 30.0;// special meaning for grenades...
	liveTime = 1.0;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.0;
	smokeName = "smoke.dts";
};

//--------------------------------------
BulletData VampireMK1
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	mass = 0.05;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.55;
	damageType = $LaserDamageType;
	muzzleVelocity = 1000.0;
	totalTime = 1.5;
	liveTime = 4.0;
	inheritedVelocityScale = 0.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//--------------------------------------
BulletData VampireMK2
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	mass = 0.05;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.85;
	damageType = $LaserDamageType;
	muzzleVelocity = 1000.0;
	totalTime = 1.5;
	liveTime = 4.0;
	inheritedVelocityScale = 0.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//--------------------------------------
RocketData ExpelMK1
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;// 0 impact, 1, radius
	damageValue = 0.68;
	damageType = $MortarDamageType;
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
// rocket specific
	trailType = 2;// smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData ExpelICE
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;// 0 impact, 1, radius
	damageValue = 0.44;
	damageType = $MortarDamageType;
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
// rocket specific
	trailType = 2;// smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData Subvert
{
	bulletShapeName = "shotgunbolt.dts";
	explosionTag = blasterExp;
	damageClass = 0;
	damageValue = 0.001;
	damageType = $BlasterDamageType;
	muzzleVelocity = 200.0;
	totalTime = 1.0;
	liveTime = 0.05;
	lightRange = 3.0;
	lightColor = { 1.0, 0.25, 0.25 };
	inheritedVelocityScale = 0.5;
	isVisible = True;
	rotationPeriod = 1;
};

//--------------------------------------
RocketData ArkfireMK1
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;// 0 impact, 1, radius
	damageValue = 0.01;
	damageType = $ArkFieldDamageType;
	explosionRadius = 35.5;
	kickBackStrength = 250.0;
	muzzleVelocity = 65.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
// rocket specific
	trailType = 2;// smoke trail
	trailString = "rsmoke.dts";
	smokeDist = 1.8;
	soundId = SoundJetHeavy;
};

//--------------------------------------
BulletData ArkfireMK2
{
	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	mass = 0.05;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.01;
	damageType = $ArkFieldDamageType2;
	muzzleVelocity = 1000.0;
	totalTime = 1.5;
	liveTime = 4.0;
	inheritedVelocityScale = 0.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//--------------------------------------
LightningData LeechMK0
{
	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 40.0;
	coneAngle = 35.0;
	damagePerSec = 0.05;
	energyDrainPerSec = 18.2;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

//--------------------------------------
LightningData LeechMK1
{
	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 40.0;
	coneAngle = 35.0;
	damagePerSec = 0.11;
	energyDrainPerSec = 40.0;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

//--------------------------------------
LightningData LeechMK2
{
	bitmapName = "lightningNew.bmp";
	damageType = $ElectricityDamageType;
	boltLength = 40.0;
	coneAngle = 35.0;
	damagePerSec = 0.17;
	energyDrainPerSec = 61.8;
	segmentDivisions = 4;
	numSegments = 5;
	beamWidth = 0.125;//075;
	updateTime = 120;
	skipPercent = 0.5;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.25, 0.25, 0.85 };
	soundId = SoundELFFire;
};

//--------------------------------------
LightningData ElectricICE
{
	bitmapName = "lightningNew.bmp";
	damageType = $BulletDamageType;
	boltLength = 40.0;
	coneAngle = 35.0;
	damagePerSec = 0.11;
	energyDrainPerSec = 40.0;
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

//--------------------------------------
SeekingMissileData TraceICE
{
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 0;// 0 impact, 1, radius
	damageValue = 0.2;
	damageType = $MissileDamageType;
	explosionRadius = 5.0;
	kickBackStrength = 100.0;
	muzzleVelocity = 75.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 9;
	nonSeekingTurningRadius = 50.0;
	proximityDist = 1.5;
	smokeDist = 1.75;
	lightRange = 5.0;
	lightColor = { 0.4, 0.4, 1.0 };
	inheritedVelocityScale = 0.0;
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
TargetLaserData targetLaser
{
	laserBitmapName = "paintPulse.bmp";
	damageConversion = 0.0;
	baseDamageType = 0;
	lightRange = 2.0;
	lightColor = { 0.25, 1.0, 0.25 };
	detachFromShooter = false;
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

RepairEffectData RepairBolt
{
	bitmapName = "repairadd.bmp";
	boltLength = 10.0;
	segmentDivisions = 4;
	beamWidth = 0.125;
	updateTime = 450;
	skipPercent = 0.6;
	displaceBias = 0.15;
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	if (%target == %player)
	{
		%player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0)
		{
			%player.repairRate = 0.1;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else
		{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else
	{
		%player.repairTarget = %target;
		%player.repairRate = 0.2;
		if (getObjectType(%player.repairTarget) == "Player")
		{
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

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1)
	{
		%client = Player::getClient(%player);
		if (%object == %player)
		{
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else
		{
			if (GameBase::getDamageLevel(%object) == 0)
			{
				Client::sendMessage(%client,0,"Repair Done");
			}
			else
			{
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if (%rate < 0) %rate = 0;
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

function EvalPlayerDamage(%client, %player, %damager, %type, %option)
{
	if(Client::getOwnedObject(%damager) != -1) %damager = Client::getOwnedObject(%damager);
	if(%type == $ImpactDamageType || %type == $LandingDamageType || %type == $BulletDamageType || %type == $PlasmaDamageType || %type == $BlasterDamageType || %type == $CrushDamageType || %type == $DebrisDamageType || %type == $ArkDamageType) return;
	if(%type == $EnergyDamageType)
	{
		if($MsgTime[%player] == "") $MsgTime[%player] = 0;
		%time = getIntegerTime(true) >> 5;
		%diff = %time - $MsgTime[%player];
		if (%diff < 10) return;
		if(!%damager) return;
		%team = GameBase::getTeam(%damager);
		for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl))
		{
			if(%team == GameBase::getTeam(%cl)) Client::sendMessage(%cl, 1, "An ICE is attacking someone!");
		}
		Client::sendMessage(%client, 1, "Data Fortress has been alerted to your presence!");
		$MsgTime[%player] = %time;
		return;
	}
	if(%type == $ArkFieldDamageType)
	{
		ArkFieldPack::deployShape(%player, 0, 10, %damager);
		return;
	}
	if(%type == $ArkFieldDamageType2)
	{
		ArkFieldPack::deployShape(%player, 1, 10, %damager);
		return;
	}
	if(%type == $ShrapnelDamageType)
	{
		Client::setGuiMode(%client, $GuiModeCommand);
		return;
	}
	if(%type == $MortarDamageType)
	{
		Player::trigger(%player, $WeaponSlot, false);
		%weaponType = Player::getMountedItem(%player, $WeaponSlot);
		if(%weaponType != -1) Player::dropItem(%player, %weaponType);
		return;
	}
	if(%type == $LaserDamageType)
	{
		%dlevel = GameBase::getDamageLevel(%damager);
		if(%dlevel > 0.4) GameBase::setDamageLevel(%damager, (%dlevel - 0.4));
		else GameBase::setDamageLevel(%damager, 0);
		return;
	}
	if(%type == $ElectricityDamageType)
	{
		%elevel = GameBase::getEnergy(%damager);
		if(!%elevel) return;
		%maxlev = %damager.maxenergy;
		if(%maxlev == "") %maxlev = Gamebase::getControlClient(%damager).armor.maxenergy;
		if(%elevel < %maxlev - 0.15) GameBase::setEnergy(%damager, (%elevel + 0.15));
		else GameBase::setEnergy(%damager, %maxlev);
		return;
	}
	if(%option)
	{
		%rnd = floor(getRandom() * 20);
		if (%rnd < 2) return;
		if ($LastSpecHarm[%player, %type] == "" || $LastSpecHarm[%player, %type] < 0) $LastSpecHarm[%player, %type] = 0;
		$LastSpecHarm[%player, %type]++;
		if($LastSpecHarm[%player, %type] == 1)
		{
			if(%type == $MineDamageType)
			{
				Player::incItemCount(%player, DeadWeight);
				Player::mountItem(%player, DeadWeight, 4);
				$time[%type, %player] = %rnd + 10;
				Client::sendMessage(%client, 1, "Deck systems effected by feedback loop!");
			}
			if(%type == $MissileDamageType)
			{
				$SpecHarm[%player, %type] = GameBase::getControlClient(%damager);
				%player.tracing = 1;
				$time[%type, %player] = %rnd + 20;
				Client::sendMessage(%client, 1, "Trace running!");
			}
			if(%type == $ExplosionDamageType)
			{
				$SpecHarm[%player, %type] = GameBase::getControlClient(%damager);
				$time[%type, %player] = %rnd + 10;
				Client::sendMessage(%client, 1, "Worm program detected!");
			}
		}
		else
		{
			if(%type == $MineDamageType)
			{
				$time[%type, %player] += 5;
			}
			if(%type == $ExplosionDamageType)
			{
				$SpecHarm[%player, %type] = GameBase::getControlClient(%damager);
				$time[%type, %player] += 5;
			}
			if(%type == $MissileDamageType)
			{
				$SpecHarm[%player, %type] = GameBase::getControlClient(%damager);
				if($time[%type, %player] > 2) $time[%type, %player]--;
				if(%player.tracing != 1)
				{
					Client::sendMessage(%client, 1, "Trace continued!");
					%player.tracing = 1;
					$time[%type, %player] = 15;
				}
			}
		}
	}
	else
	{
		if($LastSpecHarm[%player, %type] > 1)
		{
			$LastSpecHarm[%player, %type]--;
			return;
		}
		if($time[%type, %player] > 2) $time[%type, %player] -= 2;
		else
		{
			if(%type == $MissileDamageType && %player.tracing == 1)
			{
				%player.tracing = "";
				$time[%type, %player] = "";
				$LastSpecHarm[%player, %type] = "";
				%harm = $SpecHarm[%player, %type];
				$SpecHarm[%player, %type] = "";
				Player::kill(%client);
				Client::onKilled(%client, %harm, %type);
				return;
			}
			%list[$ExplosionDamageType, 0] = "Worm program eradicated.";
			%list[$MissileDamageType, 0] = "Trace redirected.";
			%list[$MineDamageType, 0] = "Feedback tuned out.";
			if(%type == $MineDamageType) Player::decItemCount(%player,DeadWeight);
			if(%type == $MissileDamageType) %player.tracing = "";
			$time[%type, %player] = "";
			$LastSpecHarm[%player, %type] = "";
			$SpecHarm[%player, %type] = "";
			Client::sendMessage(%client, 1, %list[%type, 0]);
			return;
		}
	}
	if (!Player::isDead(%player))
	{
		if(%type == $ExplosionDamageType)
		{
			%dmglev = GameBase::getDamageLevel(%player);
			%armor = Player::getArmor(%client);
			%dmglev += (0.1 * ($damagescale[%armor, %type] - %client.resis));
			GameBase::setDamageLevel(%player, %dmglev);
			Player::setDamageFlash(%player,0.75);
			if (Player::isDead(%player))
			{
				$time[%type, %player] = "";
				%player.tracing = "";
				$LastSpecHarm[%player, %type] = "";
				%harm = $SpecHarm[%player, %type];
				$SpecHarm[%player, %type] = "";
				Client::onKilled(%client, %harm, %type);
				return;
			}
		}
	}
	else
	{
		$time[%type, %player] = "";
		%player.tracing = "";
		$LastSpecHarm[%player, %type] = "";
		$SpecHarm[%player, %type] = "";
		return;
	}
	schedule("EvalPlayerDamage(" @ %client @ ", " @ %player @ ", " @ %damager @ ", " @ %type @ ", 0);", 2, %player);
}

function EvalObjectDamage(%object, %damager, %type, %option)
{
	if(Client::getOwnedObject(%damager) != -1) %damager = Client::getOwnedObject(%damager);
	if(%type == $ImpactDamageType || %type == $LandingDamageType || %type == $BulletDamageType || %type == $CrushDamageType || %type == $DebrisDamageType || %type == $EnergyDamageType || %type == $ShrapnelDamageType || %type == $MortarDamageType || %type == $MineDamageType || %type == $MissileDamageType) return;
	if(%type == $ArkFieldDamageType)
	{
		ArkFieldPack::deployShape(%object, 0, 10);
		return;
	}
	if(%type == $ArkFieldDamageType2)
	{
		ArkFieldPack::deployShape(%object, 1, 10);
		return;
	}
	if(%type == $LaserDamageType)
	{
		%dlevel = GameBase::getDamageLevel(%damager);
		if(%dlevel > 0.1) GameBase::setDamageLevel(%damager, (%dlevel - 0.1));
		else GameBase::setDamageLevel(%damager, 0);
		return;
	}
	if(%type == $ElectricityDamageType)
	{
		%elevel = GameBase::getEnergy(%damager);
		%maxlev = %damager.maxenergy;
		if(%maxlev == "") %maxlev = Gamebase::getControlClient(%damager).armor.maxenergy;
		if(%elevel < %maxlev - 0.15) GameBase::setEnergy(%damager, (%elevel + 0.15));
		else GameBase::setEnergy(%damager, %maxlev);
		return;
	}
	if(%option)
	{
		%rnd = floor(getRandom() * 20);
		if (%rnd < 2) return;
		%client = Gamebase::getOwnerClient(%damager);
		if ($LastSpecHarm[%object, %type] == "" || $LastSpecHarm[%object, %type] < 0) $LastSpecHarm[%object, %type] = 0;
		$LastSpecHarm[%object, %type]++;
		if($LastSpecHarm[%object, %type] == 1)
		{
			if(%type == $PlasmaDamageType)
			{
				%object.decrypting = 1;
				Client::sendMessage(%client, 1, "Decrypting Shields.");
				$time[%type, %object] = %rnd + 10;
			}
			if(%type == $BlasterDamageType)
			{
				Client::sendMessage(%client, 1, "Subverting Object.");
				%object.subverting = 1;
				$time[%type, %object] = %rnd + 10;
				$SpecHarm[%object, %type] = %damager;
			}
			if(%type == $ExplosionDamageType)
			{
				$time[%type, %object] = %rnd + 10;
			}
		}
		else
		{
			if(%type == $PlasmaDamageType)
			{
				if(%object.decrypting != 1) %object.decrypting = 1;
				if($time[%type, %object] > 2) $time[%type, %object]--;
			}
			if(%type == $BlasterDamageType)
			{
				if(%object.subverting != 1) %object.subverting = 1;
				if($time[%type, %object] > 2) $time[%type, %object]--;
				$SpecHarm[%object, %type] = %damager;
			}
			if(%type == $ExplosionDamageType)
			{
				$time[%type, %object] += 5;
			}
		}
	}
	else
	{
		if($LastSpecHarm[%object, %type] > 1)
		{
			$LastSpecHarm[%object, %type]--;
			return;
		}
		if($time[%type, %object] > 2) $time[%type, %object] -= 2;
		else
		{
			if(%type == $PlasmaDamageType)
			{
				if(%object.decrypting == 1)
				{
					if(%object.shieldStrength > 0)
					{
						%client = Gamebase::getOwnerClient(%damager);
						Client::sendMessage(%client, 1, "Shields decrypted.");
						%object.lastShield = %object.shieldStrength;
						%object.shieldStrength = 0;
						schedule("RevertShield(" @ %object @ ");", 45, %object);
					}
				}
				%object.decrypting = "";
			}
			if(%type == $BlasterDamageType)
			{
				if(%object.subverting == 1)
				{
					%damager = $SpecHarm[%object, %type];
					%client = Gamebase::getOwnerClient(%damager);
					if(%object.lastTeam == "") %object.lastTeam = GameBase::getTeam(%object);
					GameBase::setTeam(%object, GameBase::getTeam(%damager));
					Client::sendMessage(%client, 1, "Object subverted.");
					if(%object.ownerClient != "")
					{
						Client::setOwnedObject(%client, %object); 
						Client::setOwnedObject(%client, %damager);
					}
					schedule("RevertOwner(" @ %object @ ");", 45, %object);
				}
				%object.subverting = "";
			}
			$SpecHarm[%object, %type] = "";
			$time[%type, %object] = "";
			$LastSpecHarm[%object, %type] = "";
			return;
		}
	}
	if (GameBase::getDamageState(%object) != "Destroyed")
	{
		if(%type == $ExplosionDamageType)
		{
			%dmglev = GameBase::getDamageLevel(%object);
			%name = Gamebase::getDataName(%object);
			if($damagescale[%name, %type] > 0) %dmglev += 0.1 * $damagescale[%name, %type];
			else %dmglev += 0.1;
			GameBase::setDamageLevel(%object, %dmglev);
			if (GameBase::getDamageState(%object) == "Destroyed")
			{
				$time[%type, %object] = "";
				$LastSpecHarm[%object, %type] = "";
				$SpecHarm[%object, %type] = "";
				StaticShape::objectiveDestroyed(%object);
				return;
			}
		}
	}
	else
	{
		$time[%type, %object] = "";
		$LastSpecHarm[%object, %type] = "";
		$SpecHarm[%object, %type] = "";
		return;
	}
	schedule("EvalObjectDamage(" @ %object @ ", " @ %damager @ ", " @ %type @ ", 0);", 2, %object);
}

function RevertShield(%object)
{
	if (GameBase::getDamageState(%object) == "Enabled") %object.shieldStrength = %object.lastShield;
	%object.lastShield = "";
}

function RevertOwner(%object)
{
	GameBase::setTeam(%object, %object.lastTeam);
	%object.lastTeam = "";
	if(%object.ownerClient != "")
	{
		%owner = %object.ownerClient;
		%player = Client::getOwnedObject(%owner);
		Client::setOwnedObject(%owner, %object); 
		Client::setOwnedObject(%owner, %player);
	}
}