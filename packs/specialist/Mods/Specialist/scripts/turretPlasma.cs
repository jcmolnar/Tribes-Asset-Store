$InvList[iPlasmaTurret] = 1;
$RemoteInvList[iPlasmaTurret] = 1;
$Object2Item[dPlasmaTurret] = iPlasmaTurret;
$DeployedObject[dPlasmaTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iPlasmaTurret] = 0;
$ItemMax[reconfemalearmor, iPlasmaTurret] = 0;
$ItemMax[espionagearmor, iPlasmaTurret] = 0;
$ItemMax[espionagefemalearmor, iPlasmaTurret] = 0;
$ItemMax[engineerarmor, iPlasmaTurret] = 1;
$ItemMax[engineerfemalearmor, iPlasmaTurret] = 1;
$ItemMax[infantryarmor, iPlasmaTurret] = 0;
$ItemMax[infantryfemalearmor, iPlasmaTurret] = 0;
$ItemMax[falloutarmor, iPlasmaTurret] = 0;
$ItemMax[falloutfemalearmor, iPlasmaTurret] = 0;
$ItemMax[demolitionsarmor, iPlasmaTurret] = 0;
$ItemMax[assaultarmor, iPlasmaTurret] = 0;
$ItemMax[artilleryarmor, iPlasmaTurret] = 0;
$ItemMax[commanderarmor, iPlasmaTurret] = 0;

$TeamItemMax[iPlasmaTurret] = 4;

ItemImageData PlasmaTurretImage
{
  shapeFile = "hellfiregun";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 2.5;
};

ItemData iPlasmaTurret 
{
  description = "Plasma Turret";
  shapeFile = "hellfiregun";
  className = "Backpack";
  heading = "fTurrets";
  imageType = PlasmaTurretImage;
  shadowDetailMask = 4;
  mass = 2.5;
  elasticity = 0.2;
  price = 650;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iPlasmaTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iPlasmaTurret::onDeploy(%player, %item, %pos) {
	if (iPlasmaTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iPlasmaTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dPlasmaTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dPlasmaTurret");
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
								%turret = newObject("PlasmaTurret","Turret", dPlasmaTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Plasma Turret#" @ $totalNumPlasmaTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Plasma Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iPlasmaTurret"]++;
								echo("MSG: ",%client," deployed a Plasma Turret");
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

TurretData dPlasmaTurret
{
	maxDamage = 1.0;
	maxEnergy = 200;
	minGunEnergy = 75;
	maxGunEnergy = 6;
	reloadDelay = 0.8;
	fireSound = SoundPlasmaTurretFire;
	activationSound = SoundPlasmaTurretOn;
	deactivateSound = SoundPlasmaTurretOff;
	whirSound = SoundPlasmaTurretTurn;
	range = 100;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "hellfiregun";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = FusionBolt;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Plasma Turret";
};
	

function dPlasmaTurret::onAdd(%this) {
	schedule("dPlasmaTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Plasma Turret");
}

function dPlasmaTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dPlasmaTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dPlasmaTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iPlasmaTurret"]--;
}

function dPlasmaTurret::onPower(%this,%power,%generator) 
{
}

function dPlasmaTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

