ItemImageData IntercoolerPackImage
{
shapeFile = "jetPack";
weaponType = 2; 
mountPoint = 2;
mountOffset = { 0, -0.1, 0 };
minEnergy = -1;
maxEnergy = -3;
firstPerson = false;
};
ItemData IntercoolerPack
{
description = "Intercooler Pack";
shapeFile = "jetPack";
className = "Backpack";
heading = "iBackpacks";
shadowDetailMask = 4;
imageType = EnergyPackImage;
price = 250;
hudIcon = "energypack";
showWeaponBar = true;
hiliteOnActive = true;
};
function IntercoolerPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
}
function IntercoolerPack::onMount(%player,%item)
{
Player::trigger(%player,$BackpackSlot,true);
}
