FlierData Scout {
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
    shapeFile = "flyer";
    shieldShapeName = "shield_medium";
    mass = 9.0;
    drag = 1.0;
    density = 1.2;
    maxBank = 1;
    maxPitch = 1;
    maxSpeed = 300;
    minSpeed = -25;
	lift = 50;
	maxAlt = 500;
	maxVertical = 750;
	maxDamage = 5;
	damageLevel = { 1.0, 1.0 };
	maxEnergy = 1000;
	accel = 20;
	groundDamageScale = 0.19;
	reloadDelay = 0.25;
	repairRate = 2.5;
	fireSound = explosion3;
	damageSound = SoundFlierCrash;
	ramDamage = 5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;
	visibleDriver = true;
	driverPose = 22;
	description = "Scout";
};

function Scout::onAdd(%this){
	$Vehicle::curWeapon[%this] = $Vehicle::Weapon[Scout, 1];
	Vehicle::onAdd(%this);
}

function Scout::onFire(%this){
	if(%this.delay > 0){
		return; 
	}else{
		%ammo = $Vehicle::Ammo[Scout, $Vehicle::curWeapon[%this]];
		if(%ammo > 0){
			%data   = GameBase::getDataName(%this);
			%client = GameBase::getControlClient(%this);
			%player = Client::getOwnedObject(%client);
			%trans  = GameBase::getMuzzleTransform(%this);
			%vel    = Item::getVelocity(%this);
			%velA = getWord(%vel, 0);
			%velB = getWord(%vel, 1);
			%velC = getWord(%vel, 2);
			%velocity = %velA @" "@ %velB +100 @" "@ %velC;
			
			Projectile::spawnProjectile($Vehicle::curWeapon[%this], %trans, %player, %velocity);
			Schedule("Vehicle::CoolGun("@ %this @");", 1.0, %this);
			$Vehicle::Ammo[Scout, $Vehicle::curWeapon[%this]]--;
		}
		else{
			Client::sendMessage(%this.clLastMount, 0, "Your out of "@ $Vehicle::curWeapon[%this] @".");
		}
		%this.delay = $Vehicle::WepDelay[$Vehicle::curWeapon[%this]];
	}
}

function Scout::onDamage(%this, %type, %value, %pos, %vec, %mom, %object){
	%shooterTeam = GameBase::getTeam(%this);
	%damagedTeam = Client::getTeam(%object);
	%shooterClient = GameBase::getControlClient(%this);
	if(%shooterTeam == %damagedTeam || %shooterClient == %object){
		return; 
	}
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this, %type, %value, %pos, %vec, %mom, %object);
}