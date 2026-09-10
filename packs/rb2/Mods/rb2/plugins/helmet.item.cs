
$HelpMessage[Helmet] = "Keeps people from getting deadly headshots on you.";
$InvList[Helmet] = 1;
$RemoteInvList[Helmet] = 1;


$ItemMax[hlarmor, Helmet] = 1;
$ItemMax[hlfemale, Helmet] = 1;
$ItemMax[marmor, Helmet] = 1;
$ItemMax[mfemale, Helmet] = 1;
$ItemMax[larmor, Helmet] = 1;
$ItemMax[lfemale, Helmet] = 1;
$ItemMax[earmor, Helmet] = 1;
$ItemMax[efemale, Helmet] = 1;
$ItemMax[harmor, Helmet] = 1;
$ItemMax[uharmor, Helmet] = 1;


ItemImageData HelmetImage
{
	shapeFile = "discammo";
	mountPoint = 2;
	mountOffset = { 0, 0.2, 0.5 };
//	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData Helmet
{
	description = "Kevlar Helmet";
	shapeFile = "discammo";
	className = "Backpack";
	heading = "dWorn Items";
	imageType = HelmetImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function Helmet::onMount(%player,%item)
{
	
}

function Helmet::onUnmount(%player,%item)
{
	
}

function Helmet::onDrop(%player, %item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$BackpackSlot);
		if (%mounted == helmet) {
			Player::unmountItem(%player,$BackpackSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$BackpackSlot);
		}
		Item::onDrop(%player,%item);
	}

}

function Helmet::onCollision(%this,%object)
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
