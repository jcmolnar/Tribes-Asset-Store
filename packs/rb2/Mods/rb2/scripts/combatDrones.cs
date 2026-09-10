//TRIBAL COMBAT DRONES taken from stormbots directly - This script is borrowed 
//to save time and is not a part of Reality Bites
//********************

FlierData AttackDrone
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 0.1;
	drag = 1.0;
	density = 1.2;
	maxBank = 1.1;
	maxPitch = 1.15;
	maxSpeed = 60;
	minSpeed = 20;
	lift = -1.00;
	maxAlt = 950;
	maxVertical = 900;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 50;
	accel = 0.8;

//	projectileType = "unknown";
	reloadDelay = 0.12;
	fireSound = SoundFireMortar;

	groundDamageScale = 1.00;

	repairRate = 0;
	damageSound = SoundFlierCrash;
	ramDamage = 0.5;
	ramDamageType = $ImpactDamageType;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundDiscSpin;
	moveSound = SoundDiscSpin;

	visibleDriver = false;
	driverPose = 22;
	description = "Attack Drone";
};

function AttackDrone::onCollision(%this,%object)
{
}

function AttackDrone::jump(%this,%mom)
{
	%client = GameBase::getControlClient(%this);
	Client::sendMessage(%client,0,"Drone abandoned");
	GameBase::applyDamage(%this,$ImpactDamageType,10,GameBase::getPosition(%this),"0 0 0",%mom,%this);
	
			 %trans = GameBase::getMuzzleTransform(%this);
		 	 %vel = Item::getVelocity(%this);
		 	 Projectile::spawnProjectile("Planedead1",%trans,%this,%vel);
}

//function AttackDrone::onFire(%this,%slot)
//{
// %client = GameBase::getControlClient(%this);
//echo(%this@" "@%client);
//}

function AttackDrone::onDestroyed (%this,%mom)
{

			 %trans = GameBase::getMuzzleTransform(%this);
		 	 %vel = Item::getVelocity(%this);
		 	 Projectile::spawnProjectile("Planedead1",%trans,%this,%vel);

	$TeamItemCount[GameBase::getTeam(%this) @ "AttackDronePack"]--;
	%cl = GameBase::getControlClient(%this);
	GameBase::applyDamage(%cl,$ImpactDamageType,0.5,GameBase::getPosition(%cl),"0 0 0",%mom,%cl);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1)
	{
		Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") 
		{
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		$Stormbots::UsingDrone[%cl] = false;
		%pl.vehicle = "";
		%this.pilot = "";
	}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100);
}

function AttackDrone::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	if (%this.shieldstrength > 0)
		StaticShape::shieldDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	else
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

//*******************************************

$DamageScale[AttackDrone, $ImpactDamageType] = 1.0;
$DamageScale[AttackDrone, $BulletDamageType] = 2.0;
$DamageScale[AttackDrone, $PlasmaDamageType] = 2.0;
$DamageScale[AttackDrone, $EnergyDamageType] = 2.0;
$DamageScale[AttackDrone, $ExplosionDamageType] = 2.0;
$DamageScale[AttackDrone, $ShrapnelDamageType] = 2.0;
$DamageScale[AttackDrone, $DebrisDamageType] = 2.0;
$DamageScale[AttackDrone, $MissileDamageType] = 2.0;
$DamageScale[AttackDrone, $LaserDamageType] = 2.0;
$DamageScale[AttackDrone, $MortarDamageType] = 2.0;
$DamageScale[AttackDrone, $BlasterDamageType] = 2.0;
$DamageScale[AttackDrone, $ElectricityDamageType] = 2.0;
$DamageScale[AttackDrone, $MineDamageType]        = 2.0;
$DamageScale[AttackDrone, $FighterGunDamageType] = 2.0;
$DamageScale[AttackDrone, $KamikazeDamageType] = 5.0;
$DamageScale[AttackDrone, $ElectricDamageType] = 2.0;
$DamageScale[AttackDrone, $RocketDamageType] = 2.0;
$DamageScale[AttackDrone, $SniperDamageType] = 2.0;
$DamageScale[AttackDrone, $EMPDamageType] = 20.0;
$DamageScale[AttackDrone, $PlasmaCannonDamageType] = 2.0;
$DamageScale[AttackDrone, $FlameDamageType] = 2.0;
$DamageScale[AttackDrone, $AntiMatterDamageType] = 2.0;
$DamageScale[AttackDrone, $SatchelDamageType] = 2.0;
$DamageScale[AttackDrone, $BombDamageType] = 2.0;
$DamageScale[AttackDrone, $DroneDamageType] = 2.0;
$DamageScale[AttackDrone, $SurpriseDamageType] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType1] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType2] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType3] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType4] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType5] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType6] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType7] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType8] = 2.0;
$DamageScale[AttackDrone, $BulletDmgType9] = 2.0;

