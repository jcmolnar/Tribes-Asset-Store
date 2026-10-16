$InvList[iChainTurret] = 1;
$RemoteInvList[iChainTurret] = 1;
$Object2Item[dChainTurret] = iChainTurret;
$DeployedObject[dChainTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iChainTurret] = 0;
$ItemMax[reconfemalearmor, iChainTurret] = 0;
$ItemMax[espionagearmor, iChainTurret] = 0;
$ItemMax[espionagefemalearmor, iChainTurret] = 0;
$ItemMax[engineerarmor, iChainTurret] = 1;
$ItemMax[engineerfemalearmor, iChainTurret] = 1;
$ItemMax[infantryarmor, iChainTurret] = 0;
$ItemMax[infantryfemalearmor, iChainTurret] = 0;
$ItemMax[falloutarmor, iChainTurret] = 0;
$ItemMax[falloutfemalearmor, iChainTurret] = 0;
$ItemMax[demolitionsarmor, iChainTurret] = 0;
$ItemMax[assaultarmor, iChainTurret] = 0;
$ItemMax[artilleryarmor, iChainTurret] = 0;
$ItemMax[commanderarmor, iChainTurret] = 0;

$TeamItemMax[iChainTurret] = 2;

ItemImageData ChainTurretImage
{
  shapeFile = "chainturret";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 3.0;
};

ItemData iChainTurret 
{
  description = "Chain Turret";
  shapeFile = "chainturret";
  className = "Backpack";
  heading = "fTurrets";
  imageType = ChainTurretImage;
  shadowDetailMask = 4;
  mass = 3.0;
  elasticity = 0.2;
  price = 850;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iChainTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iChainTurret::onDeploy(%player, %item, %pos) {
	if (iChainTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iChainTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("dChainTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("dChainTurret");
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
								%turret = newObject("ChainTurret","Turret",dChainTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Chain Turret#" @ $totalNumChainTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Chain Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iChainTurret"]++;
								echo("MSG: ",%client," deployed a Chain Turret");
								//	Remote turrets - kill points to player that deploy them
								// Client::setOwnedObject(%client, %turret); 
								// Client::setOwnedObject(%client, %player);
								return true;
							}
						// }
						// else
						// 	Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
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

SoundData SoundFireTurretChaingun
{
   wavFileName = "machinegun.wav";
   profile = Profile3dMedium;
};

TurretData dChainTurret 
{
  maxDamage = 1.0;
  maxEnergy = 80;
  minGunEnergy = 1;
  maxGunEnergy = 1;
  reloadDelay = 0.2;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
  fireSound = SoundFireTurretChaingun;
  activationSound = SoundRemoteTurretOn;
  deactivateSound = SoundRemoteTurretOff;
//  whirSound = SoundMissileTurretTurn;
  range = 40;
  dopplerVelocity = 0;
  castLOS = true;
  supression = false;
  mapFilter = 2;
  mapIcon = "M_turret";
  visibleToSensor = true;
  debrisId = flashDebrisMedium;
  className = "Turret";
  shapeFile = "chainturret";
  shieldShapeName = "shield";
  speed = 1.0;
  speedModifier = 1.50;
  projectileType = ChaingunBullet;
  damageSkinData = "objectDamageSkins";
  shadowDetailMask = 8;
  explosionId = LargeShockwave;
  description = "Chain Turret";
};

function dChainTurret::onAdd(%this) {
	schedule("dChainTurret::deploy(" @ %this @ ");", 1, %this);
	GameBase::setRechargeRate(%this, 5);
	%this.shieldStrength = 0.010;
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Chain Turret");
}

function dChainTurret::deploy(%this) 
{
	GameBase::playSequence(%this,1,"deploy");
}

function dChainTurret::onEndSequence(%this,%thread) 
{
	GameBase::setActive(%this,true);
}

function dChainTurret::onDestroyed(%this) 
{
	Turret::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iChainTurret"]--;
}

function dChainTurret::onPower(%this,%power,%generator) 
{
}

function dChainTurret::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}

