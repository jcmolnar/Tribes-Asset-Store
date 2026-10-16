$InvList[iIndoorTurret] = 1;
$RemoteInvList[iIndoorTurret] = 1;
$Object2Item[dIndoorTurret] = iIndoorTurret;
$DeployedObject[dIndoorTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iIndoorTurret] = 0;
$ItemMax[reconfemalearmor, iIndoorTurret] = 0;
$ItemMax[espionagearmor, iIndoorTurret] = 0;
$ItemMax[espionagefemalearmor, iIndoorTurret] = 0;
$ItemMax[engineerarmor, iIndoorTurret] = 1;
$ItemMax[engineerfemalearmor, iIndoorTurret] = 1;
$ItemMax[infantryarmor, iIndoorTurret] = 0;
$ItemMax[infantryfemalearmor, iIndoorTurret] = 0;
$ItemMax[falloutarmor, iIndoorTurret] = 0;
$ItemMax[falloutfemalearmor, iIndoorTurret] = 0;
$ItemMax[demolitionsarmor, iIndoorTurret] = 0;
$ItemMax[assaultarmor, iIndoorTurret] = 0;
$ItemMax[artilleryarmor, iIndoorTurret] = 0;
$ItemMax[commanderarmor, iIndoorTurret] = 0;

$TeamItemMax[iIndoorTurret] = 4;

ItemImageData IndoorTurretImage
{
  shapeFile = "indoorgun";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 2.0;
};

ItemData iIndoorTurret 
{
  description = "Indoor Turret";
  shapeFile = "indoorgun";
  className = "Backpack";
  heading = "fTurrets";
  imageType = IndoorTurretImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 450;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iIndoorTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iIndoorTurret::onDeploy(%player, %item, %pos) {
	if (iIndoorTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iIndoorTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dIndoorTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dIndoorTurret");
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
								%turret = newObject("IndoorTurret","Turret", dIndoorTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Indoor Turret#" @ $totalNumIndoorTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Indoor Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iIndoorTurret"]++;
								echo("MSG: ",%client," deployed a Indoor Turret");
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


TurretData dIndoorTurret
{
	className = "Turret";
	shapeFile = "indoorgun";
	projectileType = MiniFusionBolt;
	maxDamage = 2.5;
	maxEnergy = 60;
	minGunEnergy = 20;
	maxGunEnergy = 6;
	reloadDelay = 0.4;
	speed = 5.0;
	speedModifier = 1.0;
	range = 25;
	visibleToSensor = true;
	dopplerVelocity = 2;
	castLOS = true;
	supression = false;
	supressable = false;
	pinger = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundEnergyTurretFire;
	activationSound = SoundEnergyTurretOn;
	deactivateSound = SoundEnergyTurretOff;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 8;
	explosionId = debrisExpMedium;
	description = "Indoor Turret";

};


function dIndoorTurret::onAdd(%this) {
	schedule("IndoorTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Indoor Turret");
}

function dIndoorTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dIndoorTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dIndoorTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iIndoorTurret"]--;
}

function dIndoorTurret::onPower(%this,%power,%generator) 
{
}

function dIndoorTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

