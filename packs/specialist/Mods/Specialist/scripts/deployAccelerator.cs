$InvList[iAccelerator] = 1;
$RemoteInvList[iAccelerator] = 1;
$Object2Item[dAccelerator] = iAccelerator;
$DeployedObject[dAccelerator] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iAccelerator] = 0;
$ItemMax[reconfemalearmor, iAccelerator] = 0;
$ItemMax[espionagearmor, iAccelerator] = 0;
$ItemMax[espionagefemalearmor, iAccelerator] = 0;
$ItemMax[engineerarmor, iAccelerator] = 1;
$ItemMax[engineerfemalearmor, iAccelerator] = 1;
$ItemMax[infantryarmor, iAccelerator] = 0;
$ItemMax[infantryfemalearmor, iAccelerator] = 0;
$ItemMax[falloutarmor, iAccelerator] = 0;
$ItemMax[falloutfemalearmor, iAccelerator] = 0;
$ItemMax[demolitionsarmor, iAccelerator] = 0;
$ItemMax[assaultarmor, iAccelerator] = 0;
$ItemMax[artilleryarmor, iAccelerator] = 0;
$ItemMax[commanderarmor, iAccelerator] = 0;

$TeamItemMax[iAccelerator] = 3;

$AcceleratorRechargeTime = 3;

SoundData SoundAcceleratorActivate
{
   wavFileName = "teleport2.wav";
   profile = Profile3dNear;
};

ItemImageData AcceleratorImage
{
  shapeFile = "flagstand";
  mountPoint = 2;
  mountOffset = { 0, -0.9, -0.5 };
  mountRotation = { 1.6, 0, 0 };
  firstPerson = false;
	mass = 2.5;
};

ItemData iAccelerator 
{
  description = "Accelerator";
  shapeFile = "flagstand";
  className = "Backpack";
  heading = "dDeployables";
  imageType = AcceleratorImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 3200;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iAccelerator::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iAccelerator::onDeploy(%player, %item, %pos) {
	if (iAccelerator::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iAccelerator::deployShape(%player,%item)
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

								// position this correctly
								%rot = GameBase::getRotation(%player); 
								// %rotX = getWord(%rot, 0);
								// %rotY = getWord(%rot, 1);
								// %rotZ = getWord(%rot, 2);
								// %rotX += 1.0;
								// %rot = %rotX @" "@ %rotY @" "@ %rotZ;

								%turret = newObject("Accelerator", "StaticShape", dAccelerator, true);
								addToSet("MissionCleanup", %turret);
								GameBase::setTeam(%turret,GameBase::getTeam(%player));
								GameBase::setPosition(%turret,$los::position);
								GameBase::setRotation(%turret,%rot);
								Gamebase::setMapName(%turret,"Accelerator - " @ Client::getName(%client));
								Client::sendMessage(%client,0,"Accelerator deployed");
								playSound(SoundPickupBackpack,$los::position);
								$TeamItemCount[GameBase::getTeam(%player) @ "iAccelerator"]++;
								echo("MSG: ",%client," deployed an Accelerator");
								%turret.locked = true;
								schedule("dAccelerator::unlock("@%turret@");", $AcceleratorRechargeTime);
								return true;

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

StaticShapeData dAccelerator
{
	shapeFile = "flagstand";
	debrisId = defaultDebrisSmall;
	damageSkinData = "objectDamageSkins";
	shadowDetailMask = 16;
	maxDamage = 3.0;
	explosionId = flashExpMedium;
	description = "Accelerator";
};

function dAccelerator::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iAccelerator"]--;

}


function dAccelerator::onCollision(%this, %object) {
	// This function will accelerate the player when they 
	// collide with the Accelerator.

	// Check to see if it's a player
	%type = getObjectType(%object);
	if (%type != "Player") return;

	// Check to see if the Accelerator is locked
	if (%this.locked) {
		// print a message
		%client = Player::getClient(%object);
		Client::sendMessage(%client,0,"Please wait while Accelerator recharges");
		return;
	}

	// Check to see if armor restrictions are correct
	%pArmor = Player::getArmor(%object);
	if ( %pArmor == commanderarmor) {
		// print a message
		%client = Player::getClient(%object);
		Client::sendMessage(%client,0,"ACCESS DENIED -- This armor type cannot be accelerated");
		return;
	}

	// lock the Accelerator
	dAccelerator::lock(%this);

	// First we get the player's facing direction
	%player = %object;
	%trans = GameBase::getMuzzleTransform(%player);
	
	// Then we calculate the power and direction
	// based on the player's armor
	%armor = Player::getArmor(%player);
		
	if (%armor == reconarmor || %armor == reconfemalearmor)
		%power =  275;
	else if (%armor == espionagearmor || %armor == espionagefemalearmor)
		%power =  275;
	else if (%armor == infantryarmor || %armor == infantryfemalearmor)
		%power = 400;
	else if (%armor == engineerarmor || %armor == engineerfemalearmor)
		%power = 400;
	else if (%armor == falloutarmor || %armor == falloutfemalearmor)
		%power = 400;
	else if (%armor == demolitionsarmor)
		%power = 450;
	else if (%armor == assaultarmor)
		%power = 650;
	else if (%armor == artilleryarmor)
		%power = 700;
	else if (%armor == commanderarmor)
		%power = 600;

	%rotX = getWord(%trans, 3);
	%rotY = getWord(%trans, 4);
	%rotZ = getWord(%trans, 5);
	%Xvec = %rotX * %power;
	%Yvec = %rotY * %power;
	%Zvec = %rotZ * %power;
	
	%vector = %Xvec @ " " @ %Yvec @ " " @ %Zvec;
	
	// Then we play the rocket sound
	GameBase::playSound(%player, SoundFireFlierRocket, 3);
	
	// Then we apply impulse in that direction
	Player::applyImpulse(%player, %vector);

	// schedule the unlocks
	schedule("dAccelerator::unlock("@%this@");", $AcceleratorRechargeTime);

}

function dAccelerator::lock(%this) {
	// This function locks the Accelerator so that it cannot be used.
	%this.locked = true;
}

function dAccelerator::unlock(%this) {
	// This function unlocks the Accelerator so that it can be used.
	%this.locked = "";
}

