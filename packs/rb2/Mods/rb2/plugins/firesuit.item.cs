
$HelpMessage[FireSuit] = "Environmental suit: Protects you against radiation, fire, and gravity altering devices.";
$InvList[FireSuit] = 1;
$RemoteInvList[FireSuit] = 1;


$ItemMax[hlarmor, FireSuit] = 1;
$ItemMax[hlfemale, FireSuit] = 1;
$ItemMax[marmor, FireSuit] = 1;
$ItemMax[mfemale, FireSuit] = 1;
$ItemMax[larmor, FireSuit] = 1;
$ItemMax[lfemale, FireSuit] = 1;
$ItemMax[earmor, FireSuit] = 1;
$ItemMax[efemale, FireSuit] = 1;
$ItemMax[harmor, FireSuit] = 1;
$ItemMax[uharmor, FireSuit] = 1;


ItemImageData FireSuitImage
{
	shapeFile = "discammo";
	mountPoint = 2;
	mountOffset = { 0, 0.2, 0.0 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData FireSuit
{
	description = "Environ. Suit";
	shapeFile = "mineammo";
	className = "Backpack";
	heading = "dWorn Items";
	imageType = FireSuitImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 0;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FireSuit::onMount(%player,%item)
{
	
}

function FireSuit::onUnmount(%player,%item)
{
	
}

function FireSuit::onDrop(%player, %item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$BackpackSlot);
		if (%mounted == FireSuit) {
			Player::unmountItem(%player,$BackpackSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$BackpackSlot);
		}
		Item::onDrop(%player,%item);
	}

}

function FireSuit::onCollision(%this,%object)
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
