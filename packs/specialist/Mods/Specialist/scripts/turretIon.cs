$InvList[iIonTurret] = 1;
$RemoteInvList[iIonTurret] = 1;
$Object2Item[DeployableTurret] = iIonTurret;
$DeployedObject[DeployableTurret] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this turret and how many they can carry
$ItemMax[reconarmor, iIonTurret] = 0;
$ItemMax[reconfemalearmor, iIonTurret] = 0;
$ItemMax[espionagearmor, iIonTurret] = 0;
$ItemMax[espionagefemalearmor, iIonTurret] = 0;
$ItemMax[engineerarmor, iIonTurret] = 1;
$ItemMax[engineerfemalearmor, iIonTurret] = 1;
$ItemMax[infantryarmor, iIonTurret] = 0;
$ItemMax[infantryfemalearmor, iIonTurret] = 0;
$ItemMax[falloutarmor, iIonTurret] = 0;
$ItemMax[falloutfemalearmor, iIonTurret] = 0;
$ItemMax[demolitionsarmor, iIonTurret] = 0;
$ItemMax[assaultarmor, iIonTurret] = 0;
$ItemMax[artilleryarmor, iIonTurret] = 0;
$ItemMax[commanderarmor, iIonTurret] = 1;

$TeamItemMax[iIonTurret] = 10;

ItemImageData IonTurretImage
{
  shapeFile = "remoteturret";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
  mass = 1.0;
};

ItemData iIonTurret 
{
  description = "Ion Turret";
  shapeFile = "remoteturret";
  className = "Backpack";
  heading = "fTurrets";
  imageType = IonTurretImage;
  shadowDetailMask = 4;
  mass = 1.0;
  elasticity = 0.2;
  price = 350;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iIonTurret::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iIonTurret::onDeploy(%player, %item, %pos) {
	if (iIonTurret::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iIonTurret::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

				// Count the turrets in the maximum turret box
				%num = SpecialistCountTurretsMax("DeployableTurret");
				if($MaxNumTurretsInBox > %num) {

					// Count the turrets in the minimum turret box
					%num = SpecialistCountTurretsMin("DeployableTurret");
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
								%turret = newObject("IonTurret","Turret",DeployableTurret,true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Ion Turret#" @ $totalNumIonTurrets++ @ " " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Ion Turret deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iIonTurret"]++;
								echo("MSG: ",%client," deployed an Ion Turret");
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

