
$HelpMessage[KevlarVest] = "Protects your chest against bullets, especially sniper rounds.  Can't be used by snipers or recon.";
$InvList[KevlarVest] = 1;
$RemoteInvList[KevlarVest] = 1;


$ItemMax[hlarmor, KevlarVest] = 0;
$ItemMax[hlfemale, KevlarVest] = 0;
$ItemMax[marmor, KevlarVest] = 1;
$ItemMax[mfemale, KevlarVest] = 1;
$ItemMax[larmor, KevlarVest] = 0;
$ItemMax[lfemale, KevlarVest] = 0;
$ItemMax[earmor, KevlarVest] = 1;
$ItemMax[efemale, KevlarVest] = 1;
$ItemMax[harmor, KevlarVest] = 1;
$ItemMax[uharmor, KevlarVest] = 1;


ItemImageData KevlarVestImage
{
	shapeFile = "discammo";
	mountPoint = 2;
	mountOffset = { 0, 0.35, 0.0 };
	mountRotation = { -1.57, 0, 0 };
	firstPerson = false;
};

ItemData KevlarVest
{
	description = "Kevlar Vest";
	shapeFile = "Mineammo";
	className = "Backpack";
	heading = "dWorn Items";
	imageType = KevlarVestImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 200;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function KevlarVest::onMount(%player,%item)
{
	
}

function KevlarVest::onUnmount(%player,%item)
{
	
}

function KevlarVest::onDrop(%player, %item)
{
	if($matchStarted)
	{
		%mounted = Player::getMountedItem(%player,$BackpackSlot);
		if (%mounted == KevlarVest) {
			Player::unmountItem(%player,$BackpackSlot);
		}
		else
		{
			Player::mountItem(%player,%mounted,$BackpackSlot);
		}
		Item::onDrop(%player,%item);
	}

}

function KevlarVest::onCollision(%this,%object)
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
