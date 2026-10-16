$InvList[iSmokeTurret] = 1;
$RemoteInvList[iSmokeTurret] = 1;
$Object2Item[dSmokeTurret] = iSmokeTurret;
$DeployedObject[dSmokeTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iSmokeTurret] = 0;
$ItemMax[reconfemalearmor, iSmokeTurret] = 0;
$ItemMax[espionagearmor, iSmokeTurret] = 0;
$ItemMax[espionagefemalearmor, iSmokeTurret] = 0;
$ItemMax[engineerarmor, iSmokeTurret] = 1;
$ItemMax[engineerfemalearmor, iSmokeTurret] = 1;
$ItemMax[infantryarmor, iSmokeTurret] = 0;
$ItemMax[infantryfemalearmor, iSmokeTurret] = 0;
$ItemMax[falloutarmor, iSmokeTurret] = 0;
$ItemMax[falloutfemalearmor, iSmokeTurret] = 0;
$ItemMax[demolitionsarmor, iSmokeTurret] = 0;
$ItemMax[assaultarmor, iSmokeTurret] = 0;
$ItemMax[artilleryarmor, iSmokeTurret] = 0;
$ItemMax[commanderarmor, iSmokeTurret] = 1;

$TeamItemMax[iSmokeTurret] = 4;

ItemImageData SmokeTurretImage
{
  shapeFile = "indoorgun";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 2.0;
};

ItemData iSmokeTurret 
{
  description = "Smoke Turret";
  shapeFile = "indoorgun";
  className = "Backpack";
  heading = "fTurrets";
  imageType = SmokeTurretImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 500;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iSmokeTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iSmokeTurret::onDeploy(%player, %item, %pos) {
	if (iSmokeTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iSmokeTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dSmokeTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dSmokeTurret");
					if(0 == %num) {
						// Make sure it's on a flat surface
						// if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						// Try to stick it straight up or down, otherwise
						// just use the surface normal
						if (Vector::dot($los::normal,"0 0 1") > 0.6) {
							%rot = "0 0 0";
						}
						else {
							if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
								%rot = "3.14159 0 0";
							}
							else {
								%rot = Vector::getRotation($los::normal);
							}
						}
							// Make sure player is out of the way
							if(checkDeployArea(%client,$los::position)) {
								// %rot = GameBase::getRotation(%player); 
								%turret = newObject("smokeTurret","Turret", dSmokeTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Smoke Turret#" @ $totalNumSmokeTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Smoke Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iSmokeTurret"]++;
								echo("MSG: ",%client," deployed a Smoke Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						// }
						// else
						//	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
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


ExplosionData SmokeExp
{
   shapeName = "mortarex.dts";
   soundId   = shockExplosion;

   faceCamera = true;
   randomSpin = false;
   hasLight   = false;
   lightRange = 5.0;

   timeScale = 15.0;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 1.0, 1.0, 1.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 1.0, 1.0, 1.0 };
};

GrenadeData SmokeShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = SmokeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.001;
   damageType         = $BlindDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 40;
   totalTime          = 10.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};

TurretData dSmokeTurret 
{
  maxDamage = 2.0;
  maxEnergy = 20;
  minGunEnergy = 10;
  maxGunEnergy = 20;
  reloadDelay = 2.0;
  fireSound = SoundMortarTurretFire;
  activationSound = SoundMortarTurretOn;
  deactivateSound = SoundMortarTurretOff;
  whirSound = SoundMortarTurretTurn;
  range = 30;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  visibleToSensor = true;
  debrisId = defaultDebrisMedium;
  className = "Turret";
  shapeFile = "indoorgun";
  shieldShapeName = "shield_medium";
  speed = 5.0;
  speedModifier = 1.50;
  projectileType = SmokeShell;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  explosionId = LargeShockwave;
  description = "Smoke Turret";
};

function dSmokeTurret::onAdd(%this) {
	schedule("dSmokeTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Smoke Turret");
}

function dSmokeTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dSmokeTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dSmokeTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iSmokeTurret"]--;
}

function dSmokeTurret::onPower(%this,%power,%generator) 
{
}

function dSmokeTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

