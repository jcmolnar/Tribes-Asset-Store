//--------------------------------------

$InvList[PowerEnhPack] = 1;
$RemoteInvList[PowerEnhPack] = 1;

$ItemMax[narmor, PowerEnhPack] = 1;
$ItemMax[aarmor, PowerEnhPack] = 0;
$ItemMax[darmor, PowerEnhPack] = 0;
$ItemMax[nfemale, PowerEnhPack] = 1;
$ItemMax[afemale, PowerEnhPack] = 0;
$ItemMax[warmor, PowerEnhPack] = 0;
$ItemMax[barmor, PowerEnhPack] = 0;
$ItemMax[sarmor, PowerEnhPack] = 0;
$ItemMax[avarmor, PowerEnhPack] = 0;
$ItemMax[wfemale, PowerEnhPack] = 0;
$ItemMax[bfemale, PowerEnhPack] = 0;

//--------------------------------------

ItemImageData PowerEnhPackImage
{
	shapeFile = "generator_p";
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
    mass = 5;
	firstPerson = false;
};

ItemData PowerEnhPack
{
	description = "Power Enhancement Pack";
	shapeFile = "generator_p";
	className = "Backpack";
   heading = "eBackpacks";
	shadowDetailMask = 4;
	imageType = PowerEnhPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function PowerEnhPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function PowerEnhPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

//--------------------------------------