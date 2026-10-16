//================================================================
//Minigun AmmoPack
//================================================================
$InvList[MinigunAmmoPack] = 1;
$RemoteInvList[MinigunAmmoPack] = 1;
//===================================================
$ItemMax[larmor, MinigunAmmoPack] = 1;
$ItemMax[lfemale, MinigunAmmoPack] = 1;
$ItemMax[marmor, MinigunAmmoPack] = 1;
$ItemMax[mfemale, MinigunAmmoPack] = 1;
$ItemMax[harmor, MinigunAmmoPack] = 1;
//================================================================
//MinigunPack Tables
$MinigunAmmoPackMax[MinigunAmmo] = 500;
$MinigunAmmoPackItems[0] = MinigunAmmo;
//================================================================

ItemImageData MinigunAmmoPackImage
{
	shapeFile = "pack_mini";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
};

ItemData MinigunAmmoPack
{
	description = "Minigun Ammo Pack";
	shapeFile = "pack_mini";
	className = "Backpack";
	heading = "gUtility Packs";
	imageType = MinigunAmmoPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = True;
	hiliteOnActive = true;
};

function MinigunAmmoPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		%i = 0;
		%numPack = 0;
		%ammoItem = $MinigunAmmoPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) {
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
		}	
		%item.MinigunAmmo = %numPack;		
	}
}

function MinigunAmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkMinigunPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkMinigunPacksAmmo(%player, %item)
{
	%i = 0;
	%ammoItem = $MinigunAmmoPackItems[%i];
	%numAdd = %item.MinigunAmmo;
	Player::incItemCount(%player,%ammoItem,%numAdd);						 
}


function fillMinigunAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%i = 0;
	%item = $MinigunAmmoPackItems[%i];
	%maxnum = $MinigunAmmoPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) {
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
	}
}


//================================================================