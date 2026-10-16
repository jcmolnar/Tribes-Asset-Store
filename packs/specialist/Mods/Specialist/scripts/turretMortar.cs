$InvList[iMortarTurret] = 1;
$RemoteInvList[iMortarTurret] = 1;
$Object2Item[dMortarTurret] = iMortarTurret;
$DeployedObject[dMortarTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iMortarTurret] = 0;
$ItemMax[reconfemalearmor, iMortarTurret] = 0;
$ItemMax[espionagearmor, iMortarTurret] = 0;
$ItemMax[espionagefemalearmor, iMortarTurret] = 0;
$ItemMax[engineerarmor, iMortarTurret] = 1;
$ItemMax[engineerfemalearmor, iMortarTurret] = 1;
$ItemMax[infantryarmor, iMortarTurret] = 0;
$ItemMax[infantryfemalearmor, iMortarTurret] = 0;
$ItemMax[falloutarmor, iMortarTurret] = 0;
$ItemMax[falloutfemalearmor, iMortarTurret] = 0;
$ItemMax[demolitionsarmor, iMortarTurret] = 0;
$ItemMax[assaultarmor, iMortarTurret] = 0;
$ItemMax[artilleryarmor, iMortarTurret] = 0;
$ItemMax[commanderarmor, iMortarTurret] = 0;

$TeamItemMax[iMortarTurret] = 2;

ItemImageData MortarTurretImage
{
  shapeFile = "mortar_turret";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 3.0;
};

ItemData iMortarTurret 
{
  description = "Mortar Turret";
  shapeFile = "mortar_turret";
  className = "Backpack";
  heading = "fTurrets";
  imageType = MortarTurretImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 800;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iMortarTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iMortarTurret::onDeploy(%player, %item, %pos) {
	if (iMortarTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iMortarTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dMortarTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dMortarTurret");
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
								%turret = newObject("MortarTurret","Turret", dMortarTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Mortar Turret#" @ $totalNumMortarTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Mortar Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iMortarTurret"]++;
								echo("MSG: ",%client," deployed a Mortar Turret");
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


TurretData dMortarTurret
{
	maxDamage = 1.0;
	maxEnergy = 45;
	minGunEnergy = 45;
	maxGunEnergy = 100;
	reloadDelay = 2.0;
	fireSound = SoundMortarTurretFire;
	activationSound = SoundMortarTurretOn;
	deactivateSound = SoundMortarTurretOff;
	whirSound = SoundMortarTurretTurn;
	range = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	visibleToSensor = true;
	debrisId = defaultDebrisMedium;
	className = "Turret";
	shapeFile = "mortar_turret";
	shieldShapeName = "shield_medium";
	speed = 2.0;
	speedModifier = 2.0;
	projectileType = MortarTurretShell;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = LargeShockwave;
	description = "Mortar Turret";
};
	

function dMortarTurret::onAdd(%this) {
	schedule("dMortarTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Mortar Turret");
}

function dMortarTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dMortarTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dMortarTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iMortarTurret"]--;
}

function dMortarTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

