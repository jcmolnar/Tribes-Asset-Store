$InvList[iFlameTurret] = 1;
$RemoteInvList[iFlameTurret] = 1;
$Object2Item[dFlameTurret] = iFlameTurret;
$DeployedObject[dFlameTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iFlameTurret] = 0;
$ItemMax[reconfemalearmor, iFlameTurret] = 0;
$ItemMax[espionagearmor, iFlameTurret] = 0;
$ItemMax[espionagefemalearmor, iFlameTurret] = 0;
$ItemMax[engineerarmor, iFlameTurret] = 1;
$ItemMax[engineerfemalearmor, iFlameTurret] = 1;
$ItemMax[infantryarmor, iFlameTurret] = 0;
$ItemMax[infantryfemalearmor, iFlameTurret] = 0;
$ItemMax[falloutarmor, iFlameTurret] = 0;
$ItemMax[falloutfemalearmor, iFlameTurret] = 0;
$ItemMax[demolitionsarmor, iFlameTurret] = 0;
$ItemMax[assaultarmor, iFlameTurret] = 0;
$ItemMax[artilleryarmor, iFlameTurret] = 0;
$ItemMax[commanderarmor, iFlameTurret] = 1;

$TeamItemMax[iFlameTurret] = 6;

ItemImageData FlameTurretImage
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 1.0;
};

ItemData iFlameTurret 
{
  description = "Flame Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = "fTurrets";
  imageType = FlameTurretImage;
  shadowDetailMask = 4;
  mass = 1.0;
  elasticity = 0.2;
  price = 300;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iFlameTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iFlameTurret::onDeploy(%player, %item, %pos) {
	if (iFlameTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iFlameTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dFlameTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dFlameTurret");
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
								%turret = newObject("FlameTurret","Turret", dFlameTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Flame Turret#" @ $totalNumFlameTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Flame Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iFlameTurret"]++;
								echo("MSG: ",%client," deployed a Flame Turret");
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

TurretData dFlameTurret 
{
  maxDamage = 0.65;
  maxEnergy = 60;
  minGunEnergy = 1;
  maxGunEnergy = 1;
  reloadDelay = 0.01;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  fireSound = SoundFlame;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
//  whirSound = SoundMissileTurretTurn;
  range = 30;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  visibleToSensor = true;
  debrisId = flashDebrisMedium;
  className = "Turret";
  shapeFile = "remoteturret";
  shieldShapeName = "shield";
  speed = 2.0;
  speedModifier = 1.50;
  projectileType = Flame;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  explosionId = LargeShockwave;
  description = "Flame Turret";
};

function dFlameTurret::onAdd(%this) {
	schedule("dFlameTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.01;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Flame Turret");
}

function dFlameTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dFlameTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dFlameTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iFlameTurret"]--;
}

function dFlameTurret::onPower(%this,%power,%generator) 
{
}

function dFlameTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

