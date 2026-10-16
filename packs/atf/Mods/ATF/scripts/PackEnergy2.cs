//--------------------------------------

$InvList[EnergyPack2] = 1;
$RemoteInvList[EnergyPack2] = 1;

//--------------------------------------

ItemImageData EnergyPack2Image
{
	shapeFile = "Generator_p";
	weaponType = 2;  // Sustained
                mass = 7.5;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -40;
 	maxEnergy = -80;
	firstPerson = false;
};

ItemData EnergyPack2
{
	description = "Energizer Pack";
	shapeFile = "Zap_5";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPack2Image;
	price = 250;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EnergyPack2::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack2::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack2::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == SM) 
		Player::unmountItem(%player,$WeaponSlot);
}


//--------------------------------------
$ItemMax[larmor, PhantomPack] = 1;
$ItemMax[Warmor, PhantomPack] = 0;
$ItemMax[Aarmor, PhantomPack] = 0;
$ItemMax[Barmor, PhantomPack] = 0;
$ItemMax[Marmor, PhantomPack] = 0;
$ItemMax[Harmor, PhantomPack] = 0;
$ItemMax[Xarmor, PhantomPack] = 0;
$ItemMax[Garmor, PhantomPack] = 0;
$ItemMax[Zarmor, PhantomPack] = 0;
$ItemMax[Sarmor, PhantomPack] = 0;

//--------------------------------------

$InvList[PhantomPack] = 1;
$RemoteInvList[PhantomPack] = 1;

//--------------------------------------

ItemImageData PhantomPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = 5;
	maxEnergy = 140;   // Energy/sec for sustained weapons
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData PhantomPack
{
	description = "Phantom Pack";
	shapeFile = "laserhit";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = PhantomPackImage;
	price = 975;
	hudIcon = "shieldpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function PhantomPackImage::onActivate(%player,%imageSlot)
{
	%armor = Player::getArmor(%player);
	if(%armor==Larmor)Player::setArmor(%player,Parmor);
}

function Light(%player)
{
Player::setArmor($play,Larmor);
}

function PhantomPackImage::onDeactivate(%player,%imageSlot)
{

	%armor = Player::getArmor(%player);
	$play=%player;
	if(%armor==Parmor)schedule("Light();", 2);
	//Player::trigger(%player,$BackpackSlot,false);
}
