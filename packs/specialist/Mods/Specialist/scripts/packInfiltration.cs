$InvList[InfiltrationPack] = 1;
$RemoteInvList[InfiltrationPack] = 1;

// Who can use this pack
$ItemMax[reconarmor, InfiltrationPack] = 0;
$ItemMax[reconfemalearmor, InfiltrationPack] = 0;
$ItemMax[espionagearmor, InfiltrationPack] = 1;
$ItemMax[espionagefemalearmor, InfiltrationPack] = 1;
$ItemMax[engineerarmor, InfiltrationPack] = 0;
$ItemMax[engineerfemalearmor, InfiltrationPack] = 0;
$ItemMax[infantryarmor, InfiltrationPack] = 0;
$ItemMax[infantryfemalearmor, InfiltrationPack] = 0;
$ItemMax[falloutarmor, InfiltrationPack] = 0;
$ItemMax[falloutfemalearmor, InfiltrationPack] = 0;
$ItemMax[demolitionsarmor, InfiltrationPack] = 0;
$ItemMax[assaultarmor, InfiltrationPack] = 0;
$ItemMax[artilleryarmor, InfiltrationPack] = 0;
$ItemMax[commanderarmor, InfiltrationPack] = 0;

SoundData SoundInfiltrationPackActivate
{
   wavFileName = "teleport2.wav";
   profile = Profile3dNear;
};

SoundData SoundInfiltrationPackFail
{
   wavFileName = "Mine_act.wav";
   profile = Profile3dNear;
};

ItemImageData InfiltrationPackImage
{
	shapeFile = "camera";
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.06 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData InfiltrationPack
{
	description = "Infiltration Pack";
	shapeFile = "camera";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = InfiltrationPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function InfiltrationPack::onUse(%player, %item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else {

		// Check to make sure the player has no flag
		if (Player::decItemCount(%player, Flag, 0) > 0) {
			Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Too much mass");
			GameBase::playSound(%player, SoundInfiltrationPackFail, 3);
			return;
		}

		// First we get the player's muzzle transform
		%trans = GameBase::getMuzzleTransform(%player);

		// Get the player's position
		%pos = GameBase::getPosition(%player);

		// Get player's energy
		%energy = GameBase::getEnergy(%player);

		// Calculate distance to go
		%distance = %energy / 12;

		// Drain energy
		GameBase::setEnergy(%player, 0);

		// Calculate new position
		%rotX = getWord(%trans, 3);
		%rotY = getWord(%trans, 4);
		%rotZ = getWord(%trans, 5);
		%posX = getWord(%pos, 0);
		%posY = getWord(%pos, 1);
		%posZ = getWord(%pos, 2);

		%newX = (%rotX * %distance) + %posX;
		%newY = (%rotY * %distance) + %posY;
		%newZ = (%rotZ * %distance) + %posZ;

		// Set new position (if there's space there)
		if(GameBase::testPosition(%player, %newX @ " " @%newY@ " " @%newZ)) {
			GameBase::setPosition(%player, %newX @ " " @%newY@ " " @%newZ);
			// Play sound
			GameBase::playSound(%player, SoundInfiltrationPackActivate, 3);
		}
		else {
			Client::sendMessage(GameBase::getOwnerClient(%player), 1, "Mass detected at destination");
			GameBase::playSound(%player, SoundInfiltrationPackFail, 3);
		}
	}
}

function InfiltrationPack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Infiltration Pack is used to infiltrate enemy bases through weak points in the structure.");
	}
}
