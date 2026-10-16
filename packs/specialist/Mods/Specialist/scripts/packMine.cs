$InvList[MinePack] = 1;
$RemoteInvList[MinePack] = 1;

// Who can use this pack
$ItemMax[reconarmor, MinePack] = 1;
$ItemMax[reconfemalearmor, MinePack] = 1;
$ItemMax[espionagearmor, MinePack] = 1;
$ItemMax[espionagefemalearmor, MinePack] = 1;
$ItemMax[engineerarmor, MinePack] = 1;
$ItemMax[engineerfemalearmor, MinePack] = 1;
$ItemMax[infantryarmor, MinePack] = 1;
$ItemMax[infantryfemalearmor, MinePack] = 1;
$ItemMax[falloutarmor, MinePack] = 1;
$ItemMax[falloutfemalearmor, MinePack] = 1;
$ItemMax[demolitionsarmor, MinePack] = 1;
$ItemMax[assaultarmor, MinePack] = 1;
$ItemMax[artilleryarmor, MinePack] = 1;
$ItemMax[commanderarmor, MinePack] = 1;

// Max Amount of mines the Mine Pack can carry
$MinePackMax[MineAmmo] = 10;
$MinePackMax[NormalMine] = 10;
$MinePackMax[DecoyMine] = 10;
$MinePackMax[EMPMine] = 10;
$MinePackMax[FlagMine] = 10;
$MinePackMax[FlashMine] = 10;
$MinePackMax[IncendiaryMine] = 10;

// Items in the MinePack
$MinePackItems[0] = MineAmmo;
$MinePackItems[1] = NormalMine;

ItemImageData MinePackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData MinePack
{
	description = "Mine Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = MinePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function MinePack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 2 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $MinePackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    		%item.MineAmmo = %numPack;
			}
			else {
	 	    		%item.NormalMine = %numPack;
			}
		}
	}
}

function MinePack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksMine(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksMine(%player, %item)
{
	for(%i = 0; %i < 2 ; %i = %i +1) {
		%ammoItem = $MinePackItems[%i];
		if(%i == 0) {
	        	%numAdd = %item.MineAmmo;
		}
		else {
			%numAdd = %item.NormalMine;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillMinePack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 2 ; %i = %i +1) {
		%item = $MinePackItems[%i];
		%maxnum = $MinePackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

function MinePack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Mine Pack allows the wearer to carry a lot of mines.");
	}
}
