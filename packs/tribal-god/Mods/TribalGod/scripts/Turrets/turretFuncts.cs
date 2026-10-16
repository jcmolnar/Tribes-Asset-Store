//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
//
//========== Setup ItemMax ==========//
ItemMax(MiniSmokeTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(FireBallTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(MiniFlakTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(MiniELFTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(MiniSAMTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(NuclearTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(ObeliskPowerPack, 1, 1, 1, 1, 1, 1);
ItemMax(LaserTurretBPack, 1, 1, 1, 1, 1, 1);
ItemMax(RepairTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(ChainTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(FlameTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(LaserTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(DissectionPack, 1, 1, 1, 1, 1, 1);
ItemMax(ArbitorBoxPack, 1, 1, 1, 1, 1, 1);
ItemMax(JailTurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(RTurretGenPack, 1, 1, 1, 1, 1, 1);
ItemMax(RejuvenationPack, 1, 1, 1, 1, 1);
ItemMax(TaserTrtBPack, 1, 1, 1, 1, 1, 1);
ItemMax(TaserTrtCPack, 1, 1, 1, 1, 1, 1);
ItemMax(WatchdogPack, 1, 1, 1, 1, 1, 1);
ItemMax(ObeliskPack, 1, 1, 1, 1, 1, 1);
ItemMax(CameraPack, 1, 1, 1, 1, 1, 1);
ItemMax(PlasmaPack, 1, 1, 1, 1, 1, 1);
ItemMax(TurretPack, 1, 1, 1, 1, 1, 1);
ItemMax(RailTurret, 1, 1, 1, 1, 1, 1);
ItemMax(ConPack, 1, 1, 1, 1, 1, 1);
//===================================//


//========== Setup InvItems ==========//
AddToInv(MiniSmokeTurretPack, 1, 0);
AddToInv(FireBallTurretPack, 1, 0);
AddToInv(MiniFlakTurretPack, 1, 0);
AddToInv(MiniELFTurretPack, 1, 0);
AddToInv(MiniSAMTurretPack, 1, 0);
AddToInv(NuclearTurretPack, 1, 0);
AddToInv(ObeliskPowerPack, 1, 0);
AddToInv(LaserTurretBPack, 1, 0);
AddToInv(RepairTurretPack, 1, 0);
AddToInv(FlameTurretPack, 1, 0);
AddToInv(LaserTurretPack, 1, 0);
AddToInv(DissectionPack, 1, 0);
AddToInv(ArbitorBoxPack, 1, 0);
AddToInv(JailTurretPack, 1, 0);
AddToInv(RTurretGenPack, 1, 0);
AddToInv(RejuvenationPack, 1, 0);
AddToInv(TaserTrtBPack, 1, 0);
AddToInv(TaserTrtCPack, 1, 1);
AddToInv(WatchdogPack, 1, 0);
AddToInv(ObeliskPack, 1, 0);
AddToInv(CameraPack, 1, 1);
AddToInv(TurretPack, 1, 0);
AddToInv(RailTurret, 1, 0);
AddToInv(ConPack, 1, 0);
//====================================//

function Turret::onAdd(%this){ if(GameBase::getMapName(%this) == "") GameBase::setMapName (%this, "Turret"); }
function Turret::onActivate(%this){ GameBase::playSequence(%this, 0, power); }
function Turret::onDeactivate(%this){ GameBase::stopSequence(%this, 0); Turret::checkOperator(%this); }
function Turret::onSetTeam(%this, %oldTeam){ if(GameBase::getTeam(%this) != Client::getTeam(GameBase::getControlClient(%this))) Turret::checkOperator(%this); }
function Turret::checkOperator(%this){
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1){
		%pl = Client::getOwnedObject(%cl);
		Player::setMountObject(%pl, -1,0);
		Client::setControlObject(%cl, %pl);
	}
	Client::setGuiMode(%cl, 2);
}
function Turret::onPower(%this,%power,%generator){
	if(%power){ %this.shieldStrength = 0.03; GameBase::setRechargeRate(%this,10); }
	else{ %this.shieldStrength = 0; GameBase::setRechargeRate(%this, 0); Turret::checkOperator(%this); }
	GameBase::setActive(%this,%power);
}
function Turret::onEnabled(%this){
	if(GameBase::isPowered(%this)){
		%this.shieldStrength = 0.03;
		GameBase::setRechargeRate(%this,10);
		GameBase::setActive(%this, true);
	}
}
function Turret::onDisabled(%this){
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this,0);
	Turret::onDeactivate(%this);
}
function Turret::onDestroyed(%this){
	StaticShape::objectiveDestroyed(%this);
	%this.shieldStrength = 0;
	GameBase::setRechargeRate(%this, 0);
	Turret::onDeactivate(%this);
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 9, 3, 0.40, 0.1, 200, 100); 
}
function Turret::onDamage(%this, %type, %value, %pos, %vec, %mom, %object){
	if(%this.objectiveLine){ %this.lastDamageTeam = GameBase::getTeam(%object); }
	%TDS = 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object)){
		%name = GameBase::getDataName(%this);
		if(%name != CameraTurret)
		{ %TDS = $Server::TeamDamageScale; }
	}
	StaticShape::shieldDamage(%this, %type, %value * %TDS, %pos, %vec, %mom, %object);
}
function Turret::onControl(%this, %object){ %client = Player::getClient(%object); Client::sendMessage(%client, 0, "Controlling turret "@ %this); }
function Turret::onDismount(%this, %object){
	%client = Player::getClient(%object);
	Client::sendMessage(%client, 0, "Leaving turret "@ %this);
}
//function Turret::onCollision(%this, %object)
//{
//	if(getObjectType(%object) == "Player")
//	{
//		Player::mountItem(%object, %this);
//	}
//}