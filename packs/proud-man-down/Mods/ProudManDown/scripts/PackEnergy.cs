//--------------------------------------

$InvList[EnergyPack] = 1;
$RemoteInvList[EnergyPack] = 1;

//--------------------------------------

ItemImageData EnergyPackImage
{
	shapeFile = "plant2";
	mountPoint = 2;
	mountOffset = { 0, 0.2, -0.5 };
//	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData EnergyPack
{
	description = "Sniper Camo";
	shapeFile = "plant2";
	className = "Backpack";
   heading = "fBackpacks";
	shadowDetailMask = 4;
	imageType = EnergyPackImage;
	price = 150;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
};

function EnergyPack::onMount(%player,%item)
{
	
}

function EnergyPack::onUnmount(%player,%item)
{
	
}

function EnergyPack::onDrop(%player, %item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$BackpackSlot);
		if (%mounted == EnergyPack) {
			Player::unmountItem(%player,$BackpackSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$BackpackSlot);
		}
		Item::onDrop(%player,%item);
	}

}

function EnergyPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
			Item::playPickupSound(%this);
			Item::respawn(%this);
		}
	}
}

//--------------------------------------