$InvList[LaternPack] = 1;
$RemoteInvList[LaternPack] = 1;

ItemImageData LaternPackImage 
{	
	shapeFile = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	lightType = 2;   // Pulsing
	lightRadius = 15;
	lightTime = 1.5;
	lightColor = { 0, 0, 1.0 };
	minEnergy = -20;
	maxEnergy = -6;
	firstPerson = false;
};

ItemData LaternPack 
{	
	description = "Lantern Pack";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = cBackpacks;
	shadowDetailMask = 4;
	imageType = LaternPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function LaternPack::onUse(%player,%item) 
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function LaternPack::onMount(%player,%item) 
{	
	if($debug)echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	
	Player::trigger(%player,$BackpackSlot,true);
	%clientId = Player::getclient(%player);
	bottomprint(%clientid, "<jc><f1>Lantern Pack: a pack that shines light around you. A good pack in the dark...otherwise...useless.");
}

function LaternPack::onUnmount(%player,%item) 
{	
	//if(Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
	//	Player::unmountItem(%player,$WeaponSlot);
}
