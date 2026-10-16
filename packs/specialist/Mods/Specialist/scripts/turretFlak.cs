$InvList[iFlakTurret] = 1;
$RemoteInvList[iFlakTurret] = 1;
$Object2Item[dFlakTurret] = iFlakTurret;
$DeployedObject[dFlakTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iFlakTurret] = 0;
$ItemMax[reconfemalearmor, iFlakTurret] = 0;
$ItemMax[espionagearmor, iFlakTurret] = 0;
$ItemMax[espionagefemalearmor, iFlakTurret] = 0;
$ItemMax[engineerarmor, iFlakTurret] = 1;
$ItemMax[engineerfemalearmor, iFlakTurret] = 1;
$ItemMax[infantryarmor, iFlakTurret] = 0;
$ItemMax[infantryfemalearmor, iFlakTurret] = 0;
$ItemMax[falloutarmor, iFlakTurret] = 0;
$ItemMax[falloutfemalearmor, iFlakTurret] = 0;
$ItemMax[demolitionsarmor, iFlakTurret] = 0;
$ItemMax[assaultarmor, iFlakTurret] = 0;
$ItemMax[artilleryarmor, iFlakTurret] = 0;
$ItemMax[commanderarmor, iFlakTurret] = 0;

$TeamItemMax[iFlakTurret] = 4;

ItemImageData FlakTurretImage
{
  shapeFile = "hellfiregun";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 2.0;
};

ItemData iFlakTurret 
{
  description = "Flak Turret";
  shapeFile = "hellfiregun";
  className = "Backpack";
  heading = "fTurrets";
  imageType = FlakTurretImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 650;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iFlakTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iFlakTurret::onDeploy(%player, %item, %pos) {
	if (iFlakTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iFlakTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dFlakTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dFlakTurret");
					if(0 == %num) {
						// Make sure it's on a flat surface
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						// Try to stick it straight up or down, otherwise
						// just use the surface normal
						//if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						//	%rot = "0 0 0";
						//}
						//else {
						//	if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
						//		%rot = "3.14159 0 0";
						//	}
						//	else {
						//		%rot = Vector::getRotation($los::normal);
						//	}
						//}
							// Make sure player is out of the way
							if(checkDeployArea(%client,$los::position)) {
								%rot = GameBase::getRotation(%player); 
								%turret = newObject("FlakTurret","Turret", dFlakTurret, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Flak Turret#" @ $totalNumFlakTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Flak Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iFlakTurret"]++;
								echo("MSG: ",%client," deployed a Flak Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						}
						else
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
					} 
					else
						Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
				}
				else 
					Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
			}
			else 
				Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
		}
		else 
			Client::sendMessage(%client,0,"Deploy position out of range");
	}
	else																						  
	 	Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}

SeekingMissileData FlakTurretRound 
{
	bulletShapeName = "mortar.dts";
	explosionTag    = flakExp;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.15;
	damageType       = $FlakDamageType;
	explosionRadius  = 25.0;
	kickBackStrength = 150.0;

	muzzleVelocity   = 150.0;
	terminalVelocity = 600.0;
	acceleration = 5.0;
	totalTime        = 0.9;
	liveTime         = 0.9;

	lightRange       = 5.0;
	lightColor       = { 1.0, 1.0, 0.5 };

	inheritedVelocityScale = 0.5;

	isVisible = true;
	tracerPercentage = 1.0;
	tracerLength = 90;

	seekingTurningRadius    = 3000;
	nonSeekingTurningRadius = 2500.0;
	proximityDist     = 1.5;
	smokeDist         = 0.0;

	// rocket specific
	trailType   = 1;
	trailLength = 15;
	trailWidth  = 0.3;

	soundId = SoundDiscSpin;
};

TurretData dFlakTurret 
{
  maxDamage = 1.25;
  maxEnergy = 175;
  minGunEnergy = 25;
  maxGunEnergy = 6;
  reloadDelay = 1.2;
  fireSound = SoundMissileTurretFire;
  activationSound = SoundMissileTurretOn;
  deactivateSound = SoundMissileTurretOff;
  whirSound = SoundMissileTurretTurn;
  range = 150;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  visibleToSensor = true;
  debrisId = flashDebrisMedium;
  className = "Turret";
  shapeFile = "hellfiregun";
  shieldShapeName = "shield";
  speed = 2.0;
  speedModifier = 2.0;
  projectileType = FlakTurretRound;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  explosionId = LargeShockwave;
  description = "Flak Turret";
   targetableFovRatio = 0.5;
};

function dFlakTurret::onAdd(%this) {
	schedule("dFlakTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 3);
	%this.shieldStrength = 0.01;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Flak Turret");
}

function dFlakTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dFlakTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dFlakTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iFlakTurret"]--;
}

function dFlakTurret::onPower(%this,%power,%generator)
{
//	if (%power) {
//		%this.shieldStrength = 0.03;
//		GameBase::setRechargeRate(%this,5);
//	}
//	else {
//		%this.shieldStrength = 0;
//		GameBase::setRechargeRate(%this,0);
//		Turret::checkOperator(%this);
//	}
//	GameBase::setActive(%this,%power);
}

function dFlakTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}

function dFlakTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

