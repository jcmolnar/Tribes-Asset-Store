// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
AddToRP(RepairPack);

ItemImageData RepairGunImage
{
shapeFile = "repairgun";

mountPoint = 0;
mountRotation = { 0, -2, 0 };
mountOffset = { 0, 0, 0 };

weaponType = 2;  // Sustained
projectileType = RepairBolt;
minEnergy  = 3;
maxEnergy = 10;  // Energy used/sec for sustained weapons

lightType   = 3;  // Weapon Fire
lightRadius = 1;
lightTime   = 1;
lightColor  = { 0.25, 1, 0.25 };

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
price = 125;
validateShape = true;
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
weaponType = 2;  // Sustained
minEnergy = 0;
maxEnergy = 0;   // Energy used/sec for sustained weapons
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
price = 125;
hudIcon = "repairpack";
showWeaponBar = true;
hiliteOnActive = true;
validateShape = true;
validateMaterials = true;
};

function RepairPack::onUnmount::old(%player,%item)
{
if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) 
{
Player::unmountItem(%player,$WeaponSlot);
}
}

function RepairPack::onUse::old(%player,%item)
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

function RepairPack::onDrop::old(%player,%item)
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
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
Player::mountItem(%player,%mounted,$WeaponSlot);
}
Item::onDrop(%player,%item);
}
}	
