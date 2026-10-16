// pack by plasmatic
$InvList[BuilderPack] = 1;
$MobileInvList[BuilderPack] = 1;
$RemoteInvList[BuilderPack] = 1;
AddItem(BuilderPack);

ItemImageData BuilderPackImage 
{
	shapeFile = "jetPack";
//	shapeFile = "AmmoPack";
	mountPoint = 2;
	mountOffset = { 0, -0.03, 0 };
	firstPerson = false;
  //energy pack like..	
	minEnergy = -2;
	maxEnergy = -3;
	weaponType = 2;
};

ItemData BuilderPack 
{
	description = "Attack Pack";
	shapeFile = "jetPack";
	className = "Backpack";
	heading = $InvHead[ihBac];
	imageType = BuilderPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 1900;
	hudIcon = "ammopack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$BuilderPackItems[0] = RailAmmo;
$BuilderPackMax[RailAmmo] = 5;
$BuilderPackItems[1] = RocketAmmo;
$BuilderPackMax[RocketAmmo] = 5;
$BuilderPackItems[2] = Grenade;
$BuilderPackMax[Grenade] = 7;
$BuilderPackItems[3] = PlasmaAmmo;
$BuilderPackMax[PlasmaAmmo] = 15;
$BuilderPackItems[4] = MineAmmo;
$BuilderPackMax[MineAmmo] = 3;


function BuilderPack::onDrop(%player, %item)
{
	if($matchStarted) {
		%item = Item::onDrop(%player,%item);
		for(%i = 0; %i < 5 ; %i = %i +1) {
			%numPack = 0;
			%ammoItem = $BuilderPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) {
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
			}	
			if(%i == 0) {
	 	    	%item.RailAmmo = %numPack;
			}
			else if(%i == 1) {
	 	    	%item.RocketAmmo = %numPack;
			}
			else if(%i == 2) {
	 	    	%item.Grenade = %numPack;
			}
			else if(%i == 3) {
	 	    	%item.PlasmaAmmo = %numPack;
			}
			else if(%i == 4) {
	 	    	%item.MineAmmo = %numPack;
			}
		}
	}
}

function BuilderPack::onCollision(%this,%object)
{
	if($debug) 
		event::collision(%this,%object);

	if (getObjectType(%object) == "Player") {
		%item = Item::getItemData(%this);
		%count = Player::getItemCount(%object,%item);
		if (Item::giveItem(%object,%item,Item::getCount(%this))) {
			Item::playPickupSound(%this);
			CheckBuilderPack(%object, %this);
			Item::respawn(%this);
		}
	}
}

function CheckBuilderPack(%player, %item)
{
	for(%i = 0; %i < 5 ; %i = %i +1) {
		%ammoItem = $BuilderPackItems[%i];
		
		if(%i == 0) {
	        %numAdd = %item.RailAmmo;
		}
		else if(%i == 1) {
	    	%numAdd = %item.RocketAmmo;
		}
		else if(%i == 2) {
	    	%numAdd = %item.Grenade;
		}
		else if(%i == 3) {
	    	%numAdd = %item.PlasmaAmmo;
		}
		else if(%i == 4) {
	    	%numAdd = %item.MineAmmo;
		}
		Player::incItemCount(%player,%ammoItem,%numAdd);
	}						 
}

function fillBuilderPack(%player)
{
	for(%i = 0; %i < 5 ; %i = %i +1) 
	{
		%item = $BuilderPackItems[%i];
		%maxnum = $BuilderPackMax[%item];
		%maxnum = checkResources(%player,%item,%maxnum); 
		if(%maxnum) {
			Player::incItemCount(%player,%item,%maxnum);
			teamEnergyBuySell(%player,%item.price * %maxnum * -1);
			}	
	}
}

function BuilderPack::onUse(%player,%item) 
{	
	if(Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	
		Player::mountItem(%player,%item,$BackpackSlot);
	}
}

function BuilderPack::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	

	Player::trigger(%player,$BackpackSlot,true);
	%clientId = Player::getclient(%player);
	
	if(Client::isItemShoppingOn(%clientId,%item))
		{
		Client::sendMessage(%clientId, 0, "~wturreton1.wav");	
		fillBuilderPack(%player);
		if(%clientId.weaponHelp)
			Bottomprint(%clientId, "<jc>Attack Pack: <f2>Assist pack for offensive Builders.");		
		}
	else 
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Attack Pack: <f2>Assist pack for offensive Builders.");
	
}


function BuilderPack::onUnmount(%player, %item)
{
	%client = Player::getClient(%player);
	if($matchStarted && Client::isItemShoppingOn(%client,%item))
	{
	for(%i = 0; %i < 5 ; %i = %i +1) 
		{
			%numPack = 0;
			%ammoItem = $BuilderPackItems[%i];
			%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
			%pCount = Player::getItemCount(%player, %ammoItem);
			if(%pCount > %maxnum) 
				{
				%numPack = %pCount - %maxnum;
				Player::decItemCount(%player,%ammoItem,%numPack);
				}	
		}
	}
}