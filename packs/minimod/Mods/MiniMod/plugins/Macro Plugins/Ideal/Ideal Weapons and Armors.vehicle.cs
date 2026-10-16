// This is a MiniMod Macro-Plugin.
// Due to the nature of this plugin it cannot be broken down into inividual plugins.
//
// This is the set of armors and weapons from the Ideal Mod.
// Note: At the time of this plugin's release, MiniMod v.03~v.05 only supports this
//  kind of plugin in the most "BETA'ish" form. If you are not a good scriptor it is
//  NOT recommended that you play with these.
//
// Unless Macro-plugins are ported in a EXTREMELY articulate manner they WILL cause
//  massive amounts of clashing with other plugins!!!

$DamageScale[Jetfire, $ObeliskDamageType]        = 0.5;
$DamageScale[Jetfire, $MarlinDamageType]        = 0.5;
$DamageScale[Jetfire, $LCGDamageType]        = 1.0;

//--------------------

$DamageScale[Jetfire, $ImpactDamageType] = 0.2;
$DamageScale[Jetfire, $BulletDamageType] = 1.0;
$DamageScale[Jetfire, $PlasmaDamageType] = 1.0;
$DamageScale[Jetfire, $EnergyDamageType] = 1.0;
$DamageScale[Jetfire, $ExplosionDamageType] = 1.0;
$DamageScale[Jetfire, $ShrapnelDamageType] = 1.0;
$DamageScale[Jetfire, $DebrisDamageType] = 1.0;
$DamageScale[Jetfire, $MissileDamageType] = 1.0;
$DamageScale[Jetfire, $LaserDamageType] = 1.0;
$DamageScale[Jetfire, $MortarDamageType] = 1.0;
$DamageScale[Jetfire, $BlasterDamageType] = 1.0;
$DamageScale[Jetfire, $ElectricityDamageType] = 1.0;
$DamageScale[Jetfire, $MineDamageType]        = 10.0;

FlierData Jetfire
{
	explosionId = flashExpLarge;
	debrisId = JetfireBoom;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.8;
   maxPitch = 0.8;
   maxSpeed = 55;
   minSpeed = -10;
	lift = 0.85;
	maxAlt = 50;
	maxVertical = 13;
	maxDamage = 1.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.7;

	groundDamageScale = 1.0;

	projectileType = JetfireBullet;
	reloadDelay = 0.3;
	repairRate = 0;
	fireSound = debrisSmallExplosion;
	damageSound = SoundFlierCrash;
	ramDamage = 2.0;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = false;
	driverPose = 22;
	description = "JetFire";
};

function Jetfire::Dismount(%this, %cl)
{
//dismount...

	Player::useItem(%cl, "JetfirePack");
      %pl = Client::getOwnedObject(%cl);
	%pl.lastMount = %this;
	%pl.newMountTime = getSimTime() + 3.0;
	Player::setMountObject(%pl, -1, 0);
	%rot = GameBase::getRotation(%this);
	%rotZ = getWord(%rot,2);
	GameBase::setRotation(%pl, "0 0 " @ %rotZ);
      Client::setControlObject(%cl, %pl);

	%newPos = Vector::add(GameBase::getPosition(%cl), "0 0 -2");
	GameBase::setPosition(%pl, %newPos); //to compensate for being too high on dismount

	playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
	if(%pl.lastWeapon != "")
	{
		Player::useItem(%pl,%pl.lastWeapon);		 	
		%pl.lastWeapon = "";
	}
	%pl.driver = "";
	%pl.vehicle = "";


//make sure you have the same health as in Plane mode:
	%damage = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%pl, %damage);

//then get rid of the vehicle

	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
	GameBase::setPosition(%this, "-1000 -1000 -1000");
	GameBase::applyRadiusDamage($MineDamageType, "-1000 -1000 -1000", 500, 10000, 1000, %this);
}

function Vehicle::dismount(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
	if(GameBase::getDataName(%this) == "Jetfire")
	{
		Jetfire::Dismount(%this, %cl);
		return;
	}

      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
		   // dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 	Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}