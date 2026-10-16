$InvList[iTargetingTurret] = 1;
$RemoteInvList[iTargetingTurret] = 1;
$Object2Item[dTargetingTurret] = iTargetingTurret;
$DeployedObject[dTargetingTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iTargetingTurret] = 0;
$ItemMax[reconfemalearmor, iTargetingTurret] = 0;
$ItemMax[espionagearmor, iTargetingTurret] = 0;
$ItemMax[espionagefemalearmor, iTargetingTurret] = 0;
$ItemMax[engineerarmor, iTargetingTurret] = 1;
$ItemMax[engineerfemalearmor, iTargetingTurret] = 1;
$ItemMax[infantryarmor, iTargetingTurret] = 0;
$ItemMax[infantryfemalearmor, iTargetingTurret] = 0;
$ItemMax[falloutarmor, iTargetingTurret] = 0;
$ItemMax[falloutfemalearmor, iTargetingTurret] = 0;
$ItemMax[demolitionsarmor, iTargetingTurret] = 0;
$ItemMax[assaultarmor, iTargetingTurret] = 0;
$ItemMax[artilleryarmor, iTargetingTurret] = 0;
$ItemMax[commanderarmor, iTargetingTurret] = 1;

$TeamItemMax[iTargetingTurret] = 2;

ItemImageData TargetingTurretImage
{
  shapeFile = "camera";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 0.5;
};

ItemData iTargetingTurret 
{
  description = "Targeting Turret";
  shapeFile = "camera";
  className = "Backpack";
  heading = "fTurrets";
  imageType = TargetingTurretImage;
  shadowDetailMask = 4;
  mass = 0.5;
  elasticity = 0.2;
  price = 250;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iTargetingTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iTargetingTurret::onDeploy(%player, %item, %pos) {
	if (iTargetingTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iTargetingTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dTargetingTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dTargetingTurret");
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
								%turret = newObject("TargetingTurret","Turret", dTargetingTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Targeting Turret#" @ $totalNumTargetingTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Targeting Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iTargetingTurret"]++;
								echo("MSG: ",%client," deployed a Targeting Turret");
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

LaserData TargetingTurretLaser {
	laserBitmapName   = "paintPulse.bmp";
	hitName           = "laserhit.dts";
	damageConversion  = 0.0;
	baseDamageType    = $TargetingDamageType;
	beamTime          = 0.5;
	lightRange        = 5.0;
	lightColor        = { 0.2, 1.0, 0.2 };
	detachFromShooter = false;
	hitSoundId        = SoundLaserHit;
};

TurretData dTargetingTurret 
{
  className = "Turret";
  shapeFile = "camera";
  projectileType = TargetingTurretLaser;
  maxDamage = 1.95;
  maxEnergy = 90;
  minGunEnergy = 1;
  maxGunEnergy = 1;
  sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  reloadDelay = 2.0;
  speed = 4.0;
  speedModifier = 1.5;
  range = 200;
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
  description = "Targeting Turret";
  damageSkinData = "objectDamageSkins";
};

function dTargetingTurret::onAdd(%this) {
	schedule("dTargetingTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Targeting Turret");
}

function dTargetingTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dTargetingTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dTargetingTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iTargetingTurret"]--;
}

function dTargetingTurret::onPower(%this,%power,%generator) 
{
}

function dTargetingTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

