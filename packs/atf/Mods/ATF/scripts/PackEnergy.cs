//--------------------------------------

$InvList[EnergyPack] = 1;
$RemoteInvList[EnergyPack] = 1;

//--------------------------------------

ItemImageData EnergyPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;  // Sustained

	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };

	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Energy Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EnergyPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function EnergyPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function EnergyPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == LaserRifle) 
		Player::unmountItem(%player,$WeaponSlot);
}

//--------------------------------------

//--------------------------------------

ItemImageData S1Image
{
	shapeFile = "Shockwave_Large";//armorPack,discb
	mountPoint = 2;
	weaponType = 2;  // Sustained
   minEnergy = -5;
	maxEnergy = -20;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.1, 0 };
  	mountRotation = { -3.0, 0, 0};
	//{vertical rotation, rotation in-line with armor, horizontal rotation(+=left)} 
	firstPerson = True;
};

ItemData EnergyPackS
{
	description = "Super Saiyan Energy";
	shapeFile = "Shockwave_Large";
	className = "BackPack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = S1Image;
	price = 1050;
	hudIcon = "energypack";
	showWeaponBar = False;
	hiliteOnActive = False;
   validateShape = False;
   validateMaterials = False;
};

function EnergyPackS::onUse(%player,%item)
{
	
Player::mountItem(%player,%item,$BackPackSlot);
	
}

//function EnergyPackS::onMount(%player,%item)
//{
//	Player::trigger(%player,$BackPackSlot,true);
//}
//
//function EnergyPackS::onUnmount(%player,%item)
//{
//		Player::unmountItem(%player,$WeaponSlot);
//}


//--------------------------------------

ItemImageData ShieldPackImageS
{
	shapeFile = "Shockwave_large";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	minEnergy = -1;
	maxEnergy = -2;   // Energy/sec for sustained weapons
	mountOffset = { 0, -0.1, 0 };
	mountRotation = { -6, 0, 0};
	sfxFire = SoundShieldOn;
	firstPerson = True;
};

ItemData ShieldPackS
{
	description = "Super Saiyan Shield";
	shapeFile = "ShockWave_Large";
	className = "BackPack";
   heading = "wBackpacks";
	shadowDetailMask = 4;
	imageType = ShieldPackImageS;
	price = 1075;
	hudIcon = "shieldpack";
	showWeaponBar = False;
	hiliteOnActive = False;
   validateShape = False;
   validateMaterials = False;
};

function ShieldPackImageS::onActivate(%player,%imageSlot)
{
	
	%player.shieldStrength = 0.001;
}

function ShieldPackImageS::onDeactivate(%player,%imageSlot)
{
	Player::trigger(%player,$BackPackSlot,false);
	%player.shieldStrength = 0.001;
}