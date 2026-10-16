$InvList[iLaserTurret] = 1;
$RemoteInvList[iLaserTurret] = 1;
$Object2Item[dLaserTurret] = iLaserTurret;
$DeployedObject[dLaserTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iLaserTurret] = 0;
$ItemMax[reconfemalearmor, iLaserTurret] = 0;
$ItemMax[espionagearmor, iLaserTurret] = 0;
$ItemMax[espionagefemalearmor, iLaserTurret] = 0;
$ItemMax[engineerarmor, iLaserTurret] = 1;
$ItemMax[engineerfemalearmor, iLaserTurret] = 1;
$ItemMax[infantryarmor, iLaserTurret] = 0;
$ItemMax[infantryfemalearmor, iLaserTurret] = 0;
$ItemMax[falloutarmor, iLaserTurret] = 0;
$ItemMax[falloutfemalearmor, iLaserTurret] = 0;
$ItemMax[demolitionsarmor, iLaserTurret] = 0;
$ItemMax[assaultarmor, iLaserTurret] = 0;
$ItemMax[artilleryarmor, iLaserTurret] = 0;
$ItemMax[commanderarmor, iLaserTurret] = 1;

$TeamItemMax[iLaserTurret] = 6;

LaserData turretLaser
{
   laserBitmapName   = "laserPulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.012;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};


ItemImageData LaserTurretImage
{
  shapeFile = "camera";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 1.0;
};

ItemData iLaserTurret 
{
  description = "Laser Turret";
  shapeFile = "camera";
  className = "Backpack";
  heading = "fTurrets";
  imageType = LaserTurretImage;
  shadowDetailMask = 4;
  mass = 1.0;
  elasticity = 0.2;
  price = 300;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iLaserTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iLaserTurret::onDeploy(%player, %item, %pos) {
	if (iLaserTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iLaserTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dLaserTurret");

				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dLaserTurret");
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
								%turret = newObject("LaserTurret","Turret",dLaserTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Laser Turret#" @ $totalNumLaserTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Laser Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iLaserTurret"]++;
								echo("MSG: ",%client," deployed a Laser Turret");
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

TurretData dLaserTurret 
{
  className = "Turret";
  shapeFile = "camera";
  projectileType = turretLaser;
  maxDamage = 0.95;
  maxEnergy = 45;
  minGunEnergy = 35;
  maxGunEnergy = 35;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 10.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 80;
  visibleToSensor = true;
  shadowDetailMask = 4;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  debrisId = flashDebrisMedium;
  shieldShapeName = "shield";
  fireSound = SoundFireLaser;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
  explosionId = flashExpMedium;
  description = "Laser Turret";
  damageSkinData = "objectDamageSkins";
};

function dLaserTurret::onAdd(%this) {
	schedule("dLaserTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 2);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Laser Turret");
}

function dLaserTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dLaserTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dLaserTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iLaserTurret"]--;
}

function dLaserTurret::onPower(%this,%power,%generator) 
{
}

function dLaserTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

