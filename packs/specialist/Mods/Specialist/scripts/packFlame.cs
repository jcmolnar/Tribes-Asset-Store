$InvList[FlamePack] = 1;
$RemoteInvList[FlamePack] = 1;

// Who can use this pack
$ItemMax[reconarmor, FlamePack] = 0;
$ItemMax[reconfemalearmor, FlamePack] = 0;
$ItemMax[espionagearmor, FlamePack] = 0;
$ItemMax[espionagefemalearmor, FlamePack] = 0;
$ItemMax[engineerarmor, FlamePack] = 0;
$ItemMax[engineerfemalearmor, FlamePack] = 0;
$ItemMax[infantryarmor, FlamePack] = 1;
$ItemMax[infantryfemalearmor, FlamePack] = 1;
$ItemMax[falloutarmor, FlamePack] = 0;
$ItemMax[falloutfemalearmor, FlamePack] = 0;
$ItemMax[demolitionsarmor, FlamePack] = 0;
$ItemMax[assaultarmor, FlamePack] = 1;
$ItemMax[artilleryarmor, FlamePack] = 0;
$ItemMax[commanderarmor, FlamePack] = 1;

// Max Amount of flame ammo the Flame Pack can carry
$FlamePackMax[FlamethrowerAmmo] = 800;

// Items in the FlamePack
$FlamePackItems[0] = FlamethrowerAmmo;

ItemImageData FlamePackImage
{
	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
//   mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData FlamePack
{
	description = "Flame Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = FlamePackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 325;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function FlamePack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 1 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $FlamePackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    		%item.FlamethrowerAmmo = %numPack;
			}
			else {
	 	    		// %item.NormalMine = %numPack;
			}
		}
	}
}

function FlamePack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			checkPacksFlame(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksFlame(%player, %item)
{
	for(%i = 0; %i < 1 ; %i = %i +1) {
		%ammoItem = $FlamePackItems[%i];
		if(%i == 0) {
	        		%numAdd = %item.FlamethrowerAmmo;
		}
		else {
			// %numAdd = %item.NormalMine;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillFlamePack(%client)
{
	// echo("Filling Flame Pack");
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 1 ; %i = %i +1) {
		%item = $FlamePackItems[%i];
		%maxnum = $FlamePackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
	}
}

function FlamePack::onMount(%player, %item) {
	if (%player.showHelp) {
		%client = Player::getClient(%player);
		Bottomprint(%client, "The Flame Pack makes the wearer fire-retardant and carries additional fuel for the Flamethrower.");
	}
}
