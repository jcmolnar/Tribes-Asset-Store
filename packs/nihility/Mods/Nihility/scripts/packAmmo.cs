//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
$InvList[AmmoPack] = 1;

$ItemMax[larmor, AmmoPack] = 1;		//Seraph
$ItemMax[lfemale, AmmoPack] = 1;	//Seraph
$ItemMax[earmor, AmmoPack] = 1;		//Slave
$ItemMax[efemale, AmmoPack] = 1;	//Slave
$ItemMax[marmor, AmmoPack] = 1;		//Pawn
$ItemMax[aarmor, AmmoPack] = 1;		//Navigator
$ItemMax[darmor, AmmoPack] = 1;		//Atomizer
$ItemMax[barmor, AmmoPack] = 1;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

$AmmoPackItems[0] = BeaconAmmo;
$AmmoPackItems[1] = BulletAmmo; 
$AmmoPackItems[2] = TranqAmmo; 
$AmmoPackItems[3] = DiscAmmo; 
$AmmoPackItems[4] = GrenadeAmmo; 
$AmmoPackItems[5] = xgatlingammo; 
$AmmoPackItems[6] = MortarAmmo; 
$AmmoPackItems[7] = KShredderAmmo; 
$AmmoPackItems[8] = NukeAmmo; 
$AmmoPackItems[9] = PlasmaAmmo; 
$AmmoPackItems[10] = RailAmmo; 
$AmmoPackItems[11] = RepairKit; 
$AmmoPackItems[12] = MineAmmo; 
$AmmoPackItems[13] = Grenade; 
$AmmoPackItems[14] = Beacon;
$AmmoPackItems[15] = RocketAmmo; 
$AmmoPackItems[16] = RPGAmmo; 


$AmmoPackMax[BeaconAmmo] = 5; 
$AmmoPackMax[BulletAmmo] = 200; 
$AmmoPackMax[TranqAmmo] = 20; 
$AmmoPackMax[DiscAmmo] = 25; 
$AmmoPackMax[GrenadeAmmo] = 25; 
$AmmoPackMax[xgatlingammo] = 50; 
$AmmoPackMax[MortarAmmo] = 30; 
$AmmoPackMax[KShredderAmmo] = 300; 
$AmmoPackMax[NukeAmmo] = 2; 
$AmmoPackMax[PlasmaAmmo] = 20; 
$AmmoPackMax[RailAmmo] = 10;
$AmmoPackMax[RepairKit] = 1; 
$AmmoPackMax[MineAmmo] = 10; 
$AmmoPackMax[Grenade] = 10; 
$AmmoPackMax[Beacon] = 5;
$AmmoPackMax[RocketAmmo] = 15;
$AmmoPackMax[RPGAmmo] = 15;

ItemImageData AmmoPackImage 
{ 
	shapeFile = "Mine"; 
	mountPoint = 2; 
	mountRotation = { -1.57, -3.14, 3.14}; 
	mountOffset = { 0, 0.3, 0.15 }; 
	firstPerson = false; 
}; 

ItemData AmmoPack 
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = AmmoPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 33;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

ItemImageData AmmoPack2Image 
{ 
	shapeFile = "Mine"; 
	mountPoint = 2; 
	mountRotation = { 1.57, -3.14, 3.14}; 
	mountOffset = { 0, 0.25, 0.15 }; 
	firstPerson = false; 
}; 

ItemData AmmoPack2 
{
	description = "Ammo Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
	heading = "cBackpacks";
	imageType = AmmoPack2Image;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 33;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$AmmoPackSlotA = 5;


function AmmoPack::onMount(%player,%item)
{
	Player::mountItem(%player,AmmoPack2,$AmmoPackSlotA);
}

function AmmoPack::onUnmount(%player,%item)
{
	Player::unmountItem(%player,$AmmoPackSlotA);
}

function AmmoPack::onDrop(%player, %item)
{
	if($matchStarted)
	{
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 14 ; %i = %i +1)
		{
			%numPack = 0; %ammoItem = $AmmoPackItems[%i]; %maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum)
		{
			%numPack = %pCount - %maxnum; Player::decItemCount(%player,%ammoItem,%numPack);
		}
		if(%i == 0)
			{ %item.BeaconAmmo = %numPack;
		}
		else if(%i == 1)
		{
			%item.BulletAmmo = %numPack;
		}
		else if(%i == 2)
		{
			%item.TranqAmmo = %numPack;
		}
		else if(%i == 3)
		{
			%item.DiscAmmo = %numPack;
		}
		else if(%i == 4)
		{
			%item.GrenadeAmmo = %numPack;
		}
		else if(%i == 5)
		{
			%item.xgatlingammo = %numPack;
		}
		else if(%i == 6)
		{
			%item.MortarAmmo = %numPack;
		}
		else if(%i == 7)
		{
			%item.KShredderAmmo = %numPack;
		}
		else if(%i == 8)
		{
			%item.NukeAmmo = %numPack;
		}
		else if(%i == 9)
		{
			%item.PlasmaAmmo = %numPack;
		}
		else if(%i == 10)
		{
			%item.RailAmmo = %numPack;
		}
		else if(%i == 11)
		{
			%item.RepairKit = %numPack;
		}
		else if(%i == 12)
		{
			%item.MineAmmo = %numPack;
		}
		else if(%i == 13)
		{
			%item.Grenade = %numPack;
		}
		else if(%i == 14)
		{
			%item.Beacon = %numPack;
		}
		else if(%i == 15)
		{
			%item.RocketAmmo = %numPack;
		}
		else if(%i == 16)
		{
			%item.RPGAmmo = %numPack;
		}
	}
}
}

function AmmoPack::onCollision(%this,%object)
{
	if (getObjectType(%object) == "Player")
	{
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this)))
		{
			Item::playPickupSound(%this);
			checkPacksAmmo(%object, %this);
			Item::respawn(%this);
		}
	}
}

function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i < 14 ; %i = %i +1)
	{
		%ammoItem = $AmmoPackItems[%i]; if(%i == 0)
		{
			%numAdd = %item.BeaconAmmo;
		}
		else if(%i == 1)
		{
			%numAdd = %item.BulletAmmo;
		}
		else if(%i == 2)
		{
			%numAdd = %item.TranqAmmo;
		}
		else if(%i == 3)
		{
			%numAdd = %item.DiscAmmo;
		}
		else if(%i == 4)
		{
			%numAdd = %item.GrenadeAmmo;
		}
		else if(%i == 5)
		{
			%numAdd = %item.xgatlingammo;
		}
		else if(%i == 6)
		{
			%numAdd = %item.MortarAmmo;
		}
		else if(%i == 7)
		{
			%numAdd = %item.KShredderAmmo;
		}
		else if(%i == 8)
		{
			%numAdd = %item.NukeAmmo;
		}
		else if(%i == 9)
		{
			%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 10)
		{
			%numAdd = %item.RailAmmo;
		}
		else if(%i == 11)
		{
			%numAdd = %item.RepairKit;
		}
		else if(%i == 12)
		{
			%numAdd = %item.MineAmmo;
		}
		else if(%i == 13)
		{
			%numAdd = %item.Grenade;
		}
		else if(%i == 14)
		{
			%numAdd = %item.Beacon;
		}
		else if(%i == 15)
		{
			%numAdd = %item.RocketAmmo;
		}
		else if(%i == 15)
		{
			%numAdd = %item.RPGAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}
}

function fillAmmoPack(%client)
{
	%player = Client::getOwnedObject(%client);
	for(%i = 0; %i < 13 ; %i = %i +1)
	{
		%item = $AmmoPackItems[%i];
		%maxnum = $AmmoPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum);
		if(%maxnum)
		{
			Player::incItemCount(%client,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}
	}
}

