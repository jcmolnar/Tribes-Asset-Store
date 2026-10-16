//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[RepairPack] = 1;

$ItemMax[larmor, RepairPack] = 1;	//Seraph
$ItemMax[lfemale, RepairPack] = 1;	//Seraph
$ItemMax[earmor, RepairPack] = 1;	//Slave
$ItemMax[efemale, RepairPack] = 1;	//Slave
$ItemMax[marmor, RepairPack] = 1;	//Pawn
$ItemMax[aarmor, RepairPack] = 1;	//Navigator
$ItemMax[darmor, RepairPack] = 0;	//Atomizer
$ItemMax[barmor, RepairPack] = 1;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData RepairGunImage 
{
	shapeFile = "repairgun";
	mountPoint = 0;
	weaponType = 2;
	projectileType = RepairBolt;
	reloadTime = 1; 
	minEnergy = 3;
	maxEnergy = 10;
	lightType = 3;
	lightRadius = 1;
	lightTime = 1;
	lightColor = { 0.25, 1, 0.25 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
}; 

ItemData RepairGun 
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 33;
}; 

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

ItemImageData RepairPackImage 
{
	shapeFile = "armorPack";
	mountPoint = 2;
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	reloadTime = 1;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};


ItemData RepairPack 
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
	heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 33;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun)
	{
		Player::unmountItem(%player,$WeaponSlot);
	}
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item)
	{
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else
	{
		Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun)
		{
			Player::unmountItem(%player,$WeaponSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}

