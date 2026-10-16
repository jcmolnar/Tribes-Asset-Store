$InvList[iELFTurret] = 1;
$RemoteInvList[iELFTurret] = 1;
$Object2Item[dELFTurret] = iELFTurret;
$DeployedObject[dELFTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iELFTurret] = 0;
$ItemMax[reconfemalearmor, iELFTurret] = 0;
$ItemMax[espionagearmor, iELFTurret] = 0;
$ItemMax[espionagefemalearmor, iELFTurret] = 0;
$ItemMax[engineerarmor, iELFTurret] = 1;
$ItemMax[engineerfemalearmor, iELFTurret] = 1;
$ItemMax[infantryarmor, iELFTurret] = 0;
$ItemMax[infantryfemalearmor, iELFTurret] = 0;
$ItemMax[falloutarmor, iELFTurret] = 0;
$ItemMax[falloutfemalearmor, iELFTurret] = 0;
$ItemMax[demolitionsarmor, iELFTurret] = 0;
$ItemMax[assaultarmor, iELFTurret] = 0;
$ItemMax[artilleryarmor, iELFTurret] = 0;
$ItemMax[commanderarmor, iELFTurret] = 0;

$TeamItemMax[iELFTurret] = 2;

ItemImageData ELFTurretImage
{
  shapeFile = "chainturret";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 3.0;
};

ItemData iELFTurret 
{
  description = "ELF Turret";
  shapeFile = "chainturret";
  className = "Backpack";
  heading = "fTurrets";
  imageType = ELFTurretImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 850;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iELFTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iELFTurret::onDeploy(%player, %item, %pos) {
	if (iELFTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iELFTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {
				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dELFTurret");
				if($MaxNumTurretsInBox > %num) {
					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dELFTurret");
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
								%turret = newObject("ELFTurret","Turret", dELFTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"ELF Turret#" @ $totalNumELFTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"ELF Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iELFTurret"]++;
								echo("MSG: ",%client," deployed a ELF Turret");
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

TurretData dELFTurret	   
{			 
	maxDamage = 1.0;
	maxEnergy = 150;
	minGunEnergy = 50;
	maxGunEnergy = 5;
	range = 40;
	visibleToSensor = true;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = defaultDebrisMedium;
	className = "ELF Turret";
	shapeFile = "chainturret";
	shieldShapeName = "shield";
	speed = 5.0;
	speedModifier = 1.5;
	projectileType = turretCharge;
	reloadDelay = 0.3;
	explosionId = LargeShockwave;
	description = "ELF Turret";

	fireSound        = SoundGeneratorPower;
	activationSound  = SoundChainTurretOn;
	deactivateSound  = SoundChainTurretOff;
	damageSkinData   = "objectDamageSkins";
	shadowDetailMask = 8;

	isSustained     = true;
	firingTimeMS    = 750;
	energyRate      = 30.0;
};

function dELFTurret::onAdd(%this) {
	schedule("dELFTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "iELF Turret");
}

function dELFTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dELFTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dELFTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iELFTurret"]--;
}

function dELFTurret::onPower(%this,%power,%generator) 
{
}

function dELFTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

