$InvList[iEMPTurret] = 1;
$RemoteInvList[iEMPTurret] = 1;
$Object2Item[dEMPTurret] = iEMPTurret;
$DeployedObject[dEMPTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iEMPTurret] = 0;
$ItemMax[reconfemalearmor, iEMPTurret] = 0;
$ItemMax[espionagearmor, iEMPTurret] = 0;
$ItemMax[espionagefemalearmor, iEMPTurret] = 0;
$ItemMax[engineerarmor, iEMPTurret] = 1;
$ItemMax[engineerfemalearmor, iEMPTurret] = 1;
$ItemMax[infantryarmor, iEMPTurret] = 0;
$ItemMax[infantryfemalearmor, iEMPTurret] = 0;
$ItemMax[falloutarmor, iEMPTurret] = 0;
$ItemMax[falloutfemalearmor, iEMPTurret] = 0;
$ItemMax[demolitionsarmor, iEMPTurret] = 0;
$ItemMax[assaultarmor, iEMPTurret] = 0;
$ItemMax[artilleryarmor, iEMPTurret] = 0;
$ItemMax[commanderarmor, iEMPTurret] = 1;

$TeamItemMax[iEMPTurret] = 4;

ItemImageData EMPTurretImage
{
  shapeFile = "indoorgun";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 2.0;
};

ItemData iEMPTurret 
{
  description = "EMP Turret";
  shapeFile = "indoorgun";
  className = "Backpack";
  heading = "fTurrets";
  imageType = EMPTurretImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 600;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iEMPTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iEMPTurret::onDeploy(%player, %item, %pos) {
	if (iEMPTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iEMPTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {

		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dEMPTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dEMPTurret");
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
								%turret = newObject("EMPTurret","Turret",dEMPTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"EMP Turret#" @ $totalNumEMPTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"EMP Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iEMPTurret"]++;
								echo("MSG: ",%client," deployed a EMP Turret");
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

TurretData dEMPTurret 
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
  projectileType = EMPGrenadeShell;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  explosionId = LargeShockwave;
  description = "EMP Turret";
};

function dEMPTurret::onAdd(%this) {
	schedule("dEMPTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "EMP Turret");
}

function dEMPTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dEMPTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dEMPTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iEMPTurret"]--;
}

function dEMPTurret::onPower(%this,%power,%generator) 
{
}

function dEMPTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

