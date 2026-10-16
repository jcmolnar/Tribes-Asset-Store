//=====================================
LaserData sniperLaser {
	laserBitmapName = "laserPulse.bmp";
	hitName = "laserhit.dts";
	damageConversion = 0.007;
	baseDamageType = $LaserDamageType;
	beamTime = 0.5;
	lightRange = 2.0;
	lightColor = { 1.0, 0.25, 0.25 };
	detachFromShooter = false;
	hitSoundId = SoundLaserHit;
};

//=====================================
LightningData lightningCharge {
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

//=====================================
LightningData turretCharge {
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

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId){
	%damVal = %timeSlice * %damPerSec;
	%enVal  = %timeSlice * %enDrainPerSec;
	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);
	%energy = GameBase::getEnergy(%target);
	%energy = %energy - %enVal;
	if(%energy < 0) %energy = 0;
	GameBase::setEnergy(%target, %energy);
}

//=====================================
RepairEffectData RepairBolt {
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
function RepairBolt::onAcquire(%this, %player, %target){
	%client = Player::getClient(%player);
	if(%target == %player){
		%player.repairTarget = -1;
		if(GameBase::getDamageLevel(%player) != 0){
			%player.repairRate = 0.05;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}else{
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}else{
		%player.repairTarget = %target;
		%player.repairRate   = 0.1;
		if(getObjectType(%player.repairTarget) == "Player"){
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}else{
			%name = GameBase::getMapName(%target);
			if(%name == "") %name = (GameBase::getDataName(%player.repairTarget)).description;
		}
		if(GameBase::getDamageLevel(%player.repairTarget) == 0){
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if(getObjectType(%player.repairTarget) == "Player") Client::sendMessage(%rclient,0,"Being repaired by "@ Client::getName(%client));
		Client::sendMessage(%client,0,"Repairing "@ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}
function RepairBolt::onRelease(%this, %player){
	%object = %player.repairTarget;
	if(%object != -1){
		%client = Player::getClient(%player);
		if(%object == %player) Client::sendMessage(%client,0,"AutoRepair Off");
		else{
			if(GameBase::getDamageLevel(%object) == 0) Client::sendMessage(%client,0,"Repair Done");
			else Client::sendMessage(%client,0,"Repair Stopped");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0) %rate = 0;
		GameBase::setAutoRepairRate(%object,%rate);
	}
}
function RepairBolt::checkDone(%this, %player){
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == RepairGun && %player.repairTarget != -1){
		%object = %player.repairTarget;
		if(%object == %player){
			if(GameBase::getDamageLevel(%player) == 0){
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}else{
			if(GameBase::getDamageLevel(%object) == 0){
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

//=====================================
TargetLaserData targetLaser {
   laserBitmapName   = "paintPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = 0;
   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };
   detachFromShooter = false;
};