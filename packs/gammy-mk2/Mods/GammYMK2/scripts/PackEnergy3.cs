//--------------------------------------

$InvList[EnergyPack3] = 1;
$RemoteInvList[EnergyPack3] = 1;

//--------------------------------------

ItemImageData EnergyPack3Image
{
	shapeFile = "Liqcyl";
	weaponType = 2;  // Sustained
                mass = 2.5;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -20;
 	maxEnergy = -40;
	firstPerson = false;
};

ItemData EnergyPack3
{
	description = "D-Cell Pack";
	shapeFile = "Liqcyl";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPack3Image;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EnergyPack3::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack3::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack3::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}


//--------------------------------------
//--------------------------------------

$InvList[EnergyPack4] = 1;
$RemoteInvList[EnergyPack4] = 1;

//--------------------------------------

ItemImageData EnergyPack4Image
{
	shapeFile = "Liqcyl";
	weaponType = 2;  // Sustained
                mass = 2.5;
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.8 };

	minEnergy = -10;
 	maxEnergy = -20;
	firstPerson = false;
};

ItemData EnergyPack4
{
	description = "Core Generator";
	shapeFile = "Liqcyl";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPack4Image;
	price = 750;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EnergyPack4::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack4::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack4::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RocketLauncher2x) 
		Player::unmountItem(%player,$WeaponSlot);
}

//--------------------------------------
//--------------------------------------

$InvList[EnergyPack5] = 1;
$RemoteInvList[EnergyPack5] = 1;

//--------------------------------------

ItemImageData EnergyPack5Image
{
	shapeFile = "Generator_P";
	weaponType = 2;  // Sustained
                mass = 30.5;
	mountPoint = 2;
	mountOffset = { 0, -0.1, -0.8 };

	minEnergy = -50;
 	maxEnergy = -100;
	firstPerson = false;
};

ItemData EnergyPack5
{
	description = "Heavy Core Gen.";
	shapeFile = "Liqcyl";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPack5Image;
	price = 750;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EnergyPack5::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack5::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack5::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RocketLauncher2x) 
		Player::unmountItem(%player,$WeaponSlot);
}

//--------------------------------------

$InvList[FlashPack] = 1;
$RemoteInvList[FlashPack] = 1;

//--------------------------------------

ItemImageData FlashPackImage
{
	shapeFile = "Force";
	weaponType = 2;  // Sustained
                mass = 1;
	mountPoint = 2;
	mountoffset = { -0.5, 1.5, 0 };
        //{Side-Side(+=right),Front-Back(+=forward),Z(+=up)}
	mountrotation = { -0.3, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 

	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData FlashPack
{
	description = "Light Modifier";
	shapeFile = "Force";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = FlashPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function FlashPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FlashPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}
//--------------------------------------
//--------------------------------------

$InvList[FirePack] = 1;
$RemoteInvList[FirePack] = 1;

//--------------------------------------

ItemImageData FirePackImage
{
	shapeFile = "Force";
	weaponType = 2;  // Sustained
                mass = 1;
	mountPoint = 2;
	mountOffset = { -1.0, 1.5, 0 };
	mountrotation = { -0.3, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData FirePack
{
	description = "Fire Modifier";
	shapeFile = "Force";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = FirePackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function FirePack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function FirePack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//--------------------------------------
//--------------------------------------

$InvList[EmpPack] = 1;
$RemoteInvList[EmpPack] = 1;

//--------------------------------------

ItemImageData EmpPackImage
{
	shapeFile = "Force";
	weaponType = 2;  // Sustained
                mass = 1.5;
	mountPoint = 2;
	mountOffset = { -0.5, 1.5, 0 };
	mountrotation = { -0.3, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData EmpPack
{
	description = "Emp Modifier";
	shapeFile = "Force";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = EmpPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EmpPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EmpPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//--------------------------------------

//--------------------------------------

$InvList[PoisonPack] = 1;
$RemoteInvList[PoisonPack] = 1;

//--------------------------------------

ItemImageData PoisonPackImage
{
	shapeFile = "Force";
	weaponType = 2;  // Sustained
                mass = 1.5;
	mountPoint = 2;
	mountOffset = { -0.5, 1.5, 0 };
	mountrotation = { -0.3, 0, 0 };
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
};

ItemData PoisonPack
{
	description = "Poison Modifier";
	shapeFile = "Force";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = PoisonPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function PoisonPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function PoisonPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//--------------------------------------