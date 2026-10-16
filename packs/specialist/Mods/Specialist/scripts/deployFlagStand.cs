$InvList[iFlagStand] = 1;
$RemoteInvList[iFlagStand] = 1;
$Object2Item[dFlagStand] = iFlagStand;
$DeployedObject[dFlagStand] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iFlagStand] = 0;
$ItemMax[reconfemalearmor, iFlagStand] = 0;
$ItemMax[espionagearmor, iFlagStand] = 0;
$ItemMax[espionagefemalearmor, iFlagStand] = 0;
$ItemMax[engineerarmor, iFlagStand] = 1;
$ItemMax[engineerfemalearmor, iFlagStand] = 1;
$ItemMax[infantryarmor, iFlagStand] = 0;
$ItemMax[infantryfemalearmor, iFlagStand] = 0;
$ItemMax[falloutarmor, iFlagStand] = 0;
$ItemMax[falloutfemalearmor, iFlagStand] = 0;
$ItemMax[demolitionsarmor, iFlagStand] = 0;
$ItemMax[assaultarmor, iFlagStand] = 0;
$ItemMax[artilleryarmor, iFlagStand] = 0;
$ItemMax[commanderarmor, iFlagStand] = 0;

$TeamItemMax[iFlagStand] = 1;

ItemImageData FlagStandImage
{
  shapeFile = "flagstand";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 1.6, 0, 0 };
  firstPerson = false;
};

ItemData iFlagStand 
{
  description = "Flag Stand";
  shapeFile = "flagstand";
  className = "Backpack";
  heading = "dDeployables";
  imageType = FlagStandImage;
  shadowDetailMask = 4;
  mass = 20.0;
  elasticity = 0.2;
  price = 900;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iFlagStand::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iFlagStand::onDeploy(%player, %item, %pos) {
	if (iFlagStand::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iFlagStand::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
		// get LOS info
		if (GameBase::getLOSInfo(%player, 3)) {

			// can only deploy on terrain or interiors
			if (SpecialistCheckDeploySurface($los::object)) {

						// Make sure it's on a flat surface
						if (Vector::dot($los::normal,"0 0 1") > 0.7) {
						// Try to stick it straight up or down, otherwise
						// just use the surface normal
						// if (Vector::dot($los::normal,"0 0 1") > 0.6) {
						// 	%rot = GameBase::getRotation(%player); 
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

								// Find closest flag stand
								// by getting all the objects in range,
								%set = newObject("searchSet", SimSet);
								%mask = $ItemObjectType;
								%pos = $los::position;
								%size = 40;
								%num = containerBoxFillSet(%set, %mask, %pos, %size, %size, %size, 0);

								// going through them and looking for flag stands,
								// and finding the closest flag stand to our deploy point.
								%closestSoFar = -1;

								for (%index = 0; %index < %num; %index++) {
									%currObj = Group::getObject(%set, %index);
									
									%name = GameBase::getDataName(%currObj);
									// echo("Name: " @%name);

									if (%name == Flag && %currObj.carrier == -1) {
									
										if (%closestSoFar == -1) %closestSoFar = %currObj;
										else {
											%distance = Vector::getDistance(GameBase::getPosition(%currObj), %pos);
											if (%distance < %closestSoFar && GameBase::getTeam(%player) == GameBase::getTeam(%currObj))
												%closestSoFar = %currObj;
										}
									}
								}

								deleteObject(%set);

								// If a flag stand was found, 
								if (%closestSoFar > -1) {

									%rot = GameBase::getRotation(%player); 
									%turret = newObject("FlagStand", "StaticShape", dFlagStand, true);
									addToSet("MissionCleanup", %turret);
									GameBase::setTeam(%turret,GameBase::getTeam(%player));
									GameBase::setPosition(%turret,$los::position);
									GameBase::setRotation(%turret,%rot);
									Gamebase::setMapName(%turret,"Flag Stand - " @ Client::getName(%client));
									Client::sendMessage(%client,0,"Flag Stand deployed");
									playSound(SoundPickupBackpack,$los::position);
									$TeamItemCount[GameBase::getTeam(%player) @ "iFlagStand"]++;
									echo("MSG: ",%client," deployed a Flag Stand");
									return true;

									// get the set of the closest generator,
									// %genSet = getGroup(%closestSoFar);

									// add this generator to it.
									// addToSet(%genSet, %turret);

									// Add to our Cleanup table
									// for (%index = 0; $SpecialistCleanup[%index] != ""; %index++) {
									// }
									// echo("index: " @%index);
									// $SpecialistCleanup[%index] = %turret;

									// echo("Object: " @%turret);
								} else Client::sendMessage(%client,0,"No flag stand in range.");


							}
						 }
						 else
							Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
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

StaticShapeData dFlagStand
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	maxDamage = 2.0;
	explosionId = flashExpMedium;
	description = "Flag Stand";
};

function dFlagStand::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	%flagTeam = GameBase::getTeam(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iFlagStand"]--;

	if (%this.hasFlag) {
		// return flag to stand
		%flag = $teamFlag[GameBase::getTeam(%this)];

		GameBase::setPosition(%flag, %flag.originalPosition);
		Item::setVelocity(%flag, "0 0 0");
	//	%flag.flagStand = "";
		%flag.atHome = true;
		$flagAtHome[1] = true;

		%team = GameBase::getTeam(%flag);

		GameBase::startFadeIn(%flag);
		Item::hide(%flag, false);

		(%flag.carrier).carryFlag = "";
	      	%flag.carrier = -1;
	//        	Flag::clearWaypoint(%client, false);
	//      	ObjectiveMission::ObjectiveChanged(%flag);
	//	ObjectiveMission::checkScoreLimit();
		%flag.lastTeam = "";

		// Alert the team
		TeamMessages(1, %flagTeam, "Your team's temporary flag stand was destroyed. The flag has returned to its initial position.~wflagreturn.wav", %flagTeam, "");
	}
}


function dFlagStand::onCollision(%this, %object) {
	FlagStand::onCollision(%this, %object);
}

