$InvList[iRocketTurret] = 1;
$RemoteInvList[iRocketTurret] = 1;
$Object2Item[dRocketTurret] = iRocketTurret;
$DeployedObject[dRocketTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iRocketTurret] = 0;
$ItemMax[reconfemalearmor, iRocketTurret] = 0;
$ItemMax[espionagearmor, iRocketTurret] = 0;
$ItemMax[espionagefemalearmor, iRocketTurret] = 0;
$ItemMax[engineerarmor, iRocketTurret] = 1;
$ItemMax[engineerfemalearmor, iRocketTurret] = 1;
$ItemMax[infantryarmor, iRocketTurret] = 0;
$ItemMax[infantryfemalearmor, iRocketTurret] = 0;
$ItemMax[falloutarmor, iRocketTurret] = 0;
$ItemMax[falloutfemalearmor, iRocketTurret] = 0;
$ItemMax[demolitionsarmor, iRocketTurret] = 0;
$ItemMax[assaultarmor, iRocketTurret] = 0;
$ItemMax[artilleryarmor, iRocketTurret] = 0;
$ItemMax[commanderarmor, iRocketTurret] = 0;

$TeamItemMax[iRocketTurret] = 3;

ItemImageData RocketTurretImage
{
  shapeFile = "missileturret";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 2.5;
};

ItemData iRocketTurret 
{
  description = "Rocket Turret";
  shapeFile = "missileturret";
  className = "Backpack";
  heading = "fTurrets";
  imageType = RocketTurretImage;
  shadowDetailMask = 4;
  mass = 2.5;
  elasticity = 0.2;
  price = 950;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iRocketTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iRocketTurret::onDeploy(%player, %item, %pos) {
	if (iRocketTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iRocketTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dRocketTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dRocketTurret");
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
								%turret = newObject("RocketTurret","Turret", dRocketTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Rocket Turret#" @ $totalNumRocketTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Rocket Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iRocketTurret"]++;
								echo("MSG: ",%client," deployed a Rocket Turret");
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


TurretData dRocketTurret
{
	maxDamage = 0.75;
	maxEnergy = 100;
	minGunEnergy = 60;
	maxGunEnergy = 60;
	range = 150;
	gunRange = 300;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisLarge;
	className = "Turret";
	shapeFile = "missileturret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = TurretMissile;
//	reloadDelay = 3.5;
	fireSound = SoundMissileTurretFire;
	activationSound = SoundMissileTurretOn;
	deactivateSound = SoundMissileTurretOff;
//	whirSound = SoundMissileTurretTurn;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
   targetableFovRatio = 0.5;
	explosionId = LargeShockwave;
	description = "Rocket Turret";
};

function dRocketTurret::onAdd(%this) {
	schedule("dRocketTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Rocket Turret");
}

function dRocketTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dRocketTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dRocketTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iRocketTurret"]--;
}

function dRocketTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}


function dRocketTurret::onPower(%this,%power,%generator)
{
}

function dRocketTurret::verifyTarget(%this,%target)
{
   if (GameBase::virtual(%target, "getHeatFactor") >= 0.5)
      return "True";
   else
      return "False";
}
