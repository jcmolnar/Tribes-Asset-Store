$InvList[RocketPack] = 1;
$RemoteInvList[RocketPack] = 1;

// Who can use this pack
$ItemMax[reconarmor, RocketPack] = 1;
$ItemMax[reconfemalearmor, RocketPack] = 1;
$ItemMax[espionagearmor, RocketPack] = 1;
$ItemMax[espionagefemalearmor, RocketPack] = 1;
$ItemMax[engineerarmor, RocketPack] = 1;
$ItemMax[engineerfemalearmor, RocketPack] = 1;
$ItemMax[infantryarmor, RocketPack] = 1;
$ItemMax[infantryfemalearmor, RocketPack] = 1;
$ItemMax[falloutarmor, RocketPack] = 1;
$ItemMax[falloutfemalearmor, RocketPack] = 1;
$ItemMax[demolitionsarmor, RocketPack] = 1;
$ItemMax[assaultarmor, RocketPack] = 1;
$ItemMax[artilleryarmor, RocketPack] = 1;
$ItemMax[commanderarmor, RocketPack] = 0;

ItemImageData RocketPackImage 
{
	shapeFile = "jetpack";
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData RocketPack 
{
	description = "Rocket Pack";
	shapeFile = "jetpack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RocketPackImage;
	mass = 2.0;
	elasticity = 0.2;
	price = 300;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RocketPack::onUse(%player, %item) {

	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player, %item, $BackpackSlot);
	}
	else {
		// First we get the player's facing direction
		%trans = GameBase::getMuzzleTransform(%player);
		// echo("Trans: " @%trans);
		
		// Then we get the player's current energy
		%energy = GameBase::getEnergy(%player);
	
		// Then we calculate the rocket power and direction
		// based on the player's armor
		%armor = Player::getArmor(%player);
		
		if (%armor == reconarmor || %armor == reconfemalearmor)
			%power = %energy * 6;
		if (%armor == espionagearmor || %armor == espionagefemalearmor)
			%power = %energy * 6;
		if (%armor == infantryarmor || %armor == infantryfemalearmor)
			%power = %energy * 6;
		if (%armor == engineerarmor || %armor == engineerfemalearmor)
			%power = %energy * 6;
		if (%armor == falloutarmor || %armor == falloutfemalearmor)
			%power = %energy * 6;
		if (%armor == demolitionsarmor)
			%power = %energy * 6;
		if (%armor == assaultarmor)
			%power = %energy * 6.5;
		if (%armor == artilleryarmor)
			%power = %energy * 6.5;
		if (%armor == commanderarmor)
			%power = %energy * 5;

		%rotX = getWord(%trans, 3);
		%rotY = getWord(%trans, 4);
		%rotZ = getWord(%trans, 5);
		%Xvec = %rotX * %power;
		%Yvec = %rotY * %power;
		%Zvec = %rotZ * %power;
	
		%vector = %Xvec @ " " @ %Yvec @ " " @ %Zvec;
		// echo("Vector: " @%vector);
	
		// Then we play the rocket sound
		GameBase::playSound(%player, SoundFireFlierRocket, 3);
	
		// Then we apply impulse in that direction
		Player::applyImpulse(%player, %vector);
	
		// Then we subtract the player's energy
		GameBase::setEnergy(%player, %energy/2.5);
	}
}

function RocketPack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "When used, the Rocket Pack will propel the user in the direction they are facing.");
	}
}
