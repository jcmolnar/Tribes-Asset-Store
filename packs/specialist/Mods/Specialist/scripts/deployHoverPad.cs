$InvList[iHoverPad] = 1;
$RemoteInvList[iHoverPad] = 1;
$Object2Item[HoverPad] = iHoverPad;
$DeployedObject[HoverPad] = true;
$CanDeployOnto[HoverPad] = true;

// Don't forget to reset team item counts in item.cs

// Who can use this deployable and how many they can carry
$ItemMax[reconarmor, iHoverPad] = 0;
$ItemMax[reconfemalearmor, iHoverPad] = 0;
$ItemMax[espionagearmor, iHoverPad] = 0;
$ItemMax[espionagefemalearmor, iHoverPad] = 0;
$ItemMax[engineerarmor, iHoverPad] = 1;
$ItemMax[engineerfemalearmor, iHoverPad] = 1;
$ItemMax[infantryarmor, iHoverPad] = 0;
$ItemMax[infantryfemalearmor, iHoverPad] = 0;
$ItemMax[falloutarmor, iHoverPad] = 0;
$ItemMax[falloutfemalearmor, iHoverPad] = 0;
$ItemMax[demolitionsarmor, iHoverPad] = 0;
$ItemMax[assaultarmor, iHoverPad] = 0;
$ItemMax[artilleryarmor, iHoverPad] = 0;
$ItemMax[commanderarmor, iHoverPad] = 0;

$TeamItemMax[iHoverPad] = 2;

ItemImageData HoverPadImage
{
  shapeFile = "magcargo";
  mountPoint = 2;
  mountOffset = { 0, -0.1, -0.06 };
  mountRotation = { 0, 0, 0 };
  firstPerson = false;
 mass = 1.0;
};

ItemData iHoverPad 
{
  description = "Hover Pad";
  shapeFile = "elevator16x16_octo";
  className = "Backpack";
  heading = "dDeployables";
  imageType = HoverPadImage;
  shadowDetailMask = 4;
  mass = 2.0;
  elasticity = 0.2;
  price = 1800;
  hudIcon = "deployable";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function iHoverPad::onUse(%player,%item) {  
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
		Player::mountItem(%player,%item,$BackpackSlot);
	else 
		Player::deployItem(%player,%item);
}

function iHoverPad::onDeploy(%player, %item, %pos) {
	if (iHoverPad::deployShape(%player, %item)) {
		Player::decItemCount(%player, %item);
	}
}

function iHoverPad::deployShape(%player,%item)
{
	%client = Player::getClient(%player);
	// Check team item count
	if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {


		// get position to place pad

		// First we get the player's muzzle transform
		%trans = GameBase::getMuzzleTransform(%player);

		// Get the player's position
		%pos = GameBase::getPosition(%player);

		// Calculate new position
		%rotX = getWord(%trans, 3);
		%rotY = getWord(%trans, 4);
		%rotZ = getWord(%trans, 5);
		%posX = getWord(%pos, 0);
		%posY = getWord(%pos, 1);
		%posZ = getWord(%pos, 2);

		%distance = 5;

		%newX = (%rotX * %distance) + %posX;
		%newY = (%rotY * %distance) + %posY;
		%newZ = (%rotZ * %distance) + %posZ;

		%newPos = %newX @" "@ %newY @" "@ %newZ;

		// make sure that it's far enough away from everything

    		%set = newObject("set",SimSet);
		%mask = $SimInteriorObjectType;
		%num = containerBoxFillSet(%set, %mask, %newPos, 5, 5, 5, 0);
		// echo("Number in set: " @%num);
		deleteObject(%set);

		%LOSsuccess = GameBase::getLOSInfo(%player, %distance);

		if (%num < 1 && (getObjectType($los::object) != "SimTerrain" || !%LOSsuccess)) {

			// Make sure player is out of the way
			if(checkDeployArea(%client, %newPos)) {
				%rot = GameBase::getRotation(%player); 
				%turret = newObject("HoverPad", "StaticShape", HoverPad, true);
				addToSet("MissionCleanup", %turret);
				GameBase::setTeam(%turret,GameBase::getTeam(%player));
				GameBase::setPosition(%turret, %newpos);
				GameBase::setRotation(%turret,%rot);
				Gamebase::setMapName(%turret,"Hover Pad - " @ Client::getName(%client));
				Client::sendMessage(%client,0,"Hover Pad deployed");
				playSound(SoundPickupBackpack, %newPos);
				$TeamItemCount[GameBase::getTeam(%player) @ "iHoverPad"]++;
				echo("MSG: ",%client," deployed a Hover Pad");
				return true;
			} else Client::sendMessage(%client,0,"Something is in the way");
		} else Client::sendMessage(%client,0,"Can only deploy away from terrain and buildings");
	} else Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");

	return false;
}


StaticShapeData HoverPad
{
	shapeFile = "elevator16x16_octo";
	debrisId = defaultDebrisSmall;
	maxDamage = 8.0;
	isTranslucent = false;
	description = "Hover Pad";
};

function HoverPad::onAdd(%this) {
	if (GameBase::getMapName(%this) == "") 
		GameBase::setMapName (%this, "Hover Pad");
}

function HoverPad::onDestroyed(%this) 
{
	StaticShape::onDestroyed(%this);
	$TeamItemCount[GameBase::getTeam(%this) @ "iHoverPad"]--;
}

