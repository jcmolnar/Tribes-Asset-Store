
$HelpMessage[FlakJacket] = "Protects you against explosions, like rockets and grenades.";
$InvList[FlakJacket] = 1;
$RemoteInvList[FlakJacket] = 1;


$ItemMax[hlarmor, FlakJacket] = 1;
$ItemMax[hlfemale, FlakJacket] = 1;
$ItemMax[marmor, FlakJacket] = 1;
$ItemMax[mfemale, FlakJacket] = 1;
$ItemMax[larmor, FlakJacket] = 1;
$ItemMax[lfemale, FlakJacket] = 1;
$ItemMax[earmor, FlakJacket] = 1;
$ItemMax[efemale, FlakJacket] = 1;
$ItemMax[harmor, FlakJacket] = 1;
$ItemMax[uharmor, FlakJacket] = 1;


ItemImageData FlakJacketImage
{
	shapeFile = "discammo";
	mountPoint = 2;
	mountOffset = { 0, 0.35, 0.0 };
	mountRotation = { -1.57, 0, 0 };
	firstPerson = false;
};

ItemData FlakJacket
{
	description = "Flak Jacket";
	shapeFile = "Mineammo";
	className = "Backpack";
	heading = "dWorn Items";
	imageType = FlakJacketImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlakJacket::onMount(%player,%item)
{
	
}

function FlakJacket::onUnmount(%player,%item)
{
	
}

function FlakJacket::onDrop(%player, %item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$BackpackSlot);
		if (%mounted == FlakJacket) {
			Player::unmountItem(%player,$BackpackSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$BackpackSlot);
		}
		Item::onDrop(%player,%item);
	}

}

function FlakJacket::onCollision(%this,%object)
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
