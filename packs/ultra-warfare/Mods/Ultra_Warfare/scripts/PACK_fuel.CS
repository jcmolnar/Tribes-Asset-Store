//================================================================
//Fuel Pack
//================================================================
$InvList[FuelPack] = 1;
$RemoteInvList[FuelPack] = 1;
//===================================================
$ItemMax[larmor, FuelPack] = 1;
$ItemMax[lfemale, FuelPack] = 1;
$ItemMax[marmor, FuelPack] = 1;
$ItemMax[mfemale, FuelPack] = 1;
$ItemMax[harmor, FuelPack] = 1;
//================================================================
//MinigunPack Tables
$FuelPackMax[FlamerAmmo] = 500;
$FuelPackItems[0] = FlamerAmmo;
//================================================================

ItemImageData FuelPackImage
{
	shapeFile = "pack_fuel";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
};

ItemData FuelPack
{
	description = "Fuel Pack";
	shapeFile = "pack_fuel";
	className = "Backpack";
	heading = "gUtility Packs";
	imageType = FuelPackImage;
	shadowDetailMask = 4;
	mass = 0.5;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = True;
	hiliteOnActive = true;
};

function FuelPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		%i = 0;
		%numPack = 0;
		%ammoItem = $FuelPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) {
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
		}	
		%item.Fuel = %numPack;		
	}
}

function FuelPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkFuelPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkFuelPacksAmmo(%player, %item)
{
	%i = 0;
	%ammoItem = $FuelPackItems[%i];
	%numAdd = %item.Fuel;
	Player::incItemCount(%player,%ammoItem,%numAdd);						 
}


function fillFuelPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%i = 0;
	%item = $FuelPackItems[%i];
	%maxnum = $FuelPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) {
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
	}
}


//================================================================