
//----------------------------------------------------------------------------

ItemImageData RepairPackImage
{
	shapeFile = "armorPack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	weaponType = 2;  // Sustained
   minEnergy = 3;
	maxEnergy = 5;   // Energy used/sec for sustained weapons
	firstPerson = false;
};

ItemData RepairPack
{
	description = "Repair Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepairPackImage;
	price = 199;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepairPack::onMount(%player,%item)
{
	GameBase::setAutoRepairRate(%player,GameBase::getAutoRepairRate(%player)+0.03);
}

function RepairPack::onUnmount(%player,%item)
{
	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) {
		Player::unmountItem(%player,$WeaponSlot);
	}
	GameBase::setAutoRepairRate(%player,GameBase::getAutoRepairRate(%player)-0.03);
}

function RepairPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
		Player::mountItem(%player,%item,$BackpackSlot);
	}
	else {
		%player.lastWeaponUsed = Player::getMountedItem(%player, $WeaponSlot);
		Player::mountItem(%player,RepairGun,$WeaponSlot);
		%client = Player::getClient(%player);
		Bottomprint(%client, "Repair Gun");
	}
}

function RepairPack::onDrop(%player,%item)
{
	if($matchStarted) {
		%mounted = Player::getMountedItem(%player,$WeaponSlot);
		if (%mounted == RepairGun) {
			Player::unmountItem(%player,$WeaponSlot);
		}
		else {
			// Remount the existing weapon to make sure the RepairGun
			// is not on the delayed mount "stack".
			Player::mountItem(%player,%mounted,$WeaponSlot);
		}
		Item::onDrop(%player,%item);
	}
}	

//----------------------------------------------------------------------------
$AssaultPackItems[0] = BulletAmmo;
$AssaultPackItems[1] = GrenadeAmmo;
$AssaultPackItems[2] = MortarAmmo;
$AssaultPackItems[3] = HowitzerAmmo;
$AssaultPackItems[4] = Grenade;

$AssaultPackMax[BulletAmmo] = 100;
$AssaultPackMax[GrenadeAmmo] = 12;
$AssaultPackMax[MortarAmmo] = 6;
$AssaultPackMax[HowitzerAmmo] = 4;
$AssaultPackMax[Grenade] = 5;

ItemImageData AssaultPackImage
{
	shapeFile = "shieldPack";
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	weaponType = 2; 
	minEnergy = 0;
	maxEnergy = 0;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData AssaultPack
{
	description = "Assault Pack";
	shapeFile = "ShieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = AssaultPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 299;
	hudIcon = "AmmoPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AssaultPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
	for(%i = 0; %i <= 4 ; %i = %i +1) 
		{
		%numPack = 0;
		%ammoItem = $AssaultPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		if(%i == 0) %item.BulletAmmo = %numPack;
		else if(%i == 1) %item.GrenadeAmmo = %numPack;
		else if(%i == 2) %item.MortarAmmo = %numPack;
		else if(%i == 3) %item.HowitzerAmmo = %numPack;
		else %item.Grenade = %numPack;
		}
	}
}

function AssaultPack::onCollision(%this,%object)
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
	for(%i = 0; %i <=4 ; %i = %i +1) {
		%ammoItem = $AssaultPackItems[%i];
		if(%i == 0) %numAdd = %item.BulletAmmo;
		else if(%i == 1) %numAdd = %item.GrenadeAmmo;
		else if(%i == 2) %numAdd = %item.MortarAmmo;
		else if(%i == 3) %numAdd = %item.HowitzerAmmo;
		else %numAdd = %item.Grenade;
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "Grenade" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%player,%ammoItem,%numAdd);
		if(%item.className == "HandAmmo" && Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
	}						 
}

function fillAssaultPack(%client)
{
%player = Client::getOwnedObject(%client);
for(%i = 0; %i <=4 ; %i = %i +1) 
	{
	%item = $AssaultPackItems[%i];
	%maxnum = $AssaultPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "Grenade" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		if(%item.className == "HandAmmo" && Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
		}	
	}
}

function AssaultPackImage::onActivate(%player,%imageSlot)
{
	if(%player.shieldStrength == %player.shieldMax) {
		%player.shieldRecharging = false;
		Player::trigger(%player,$BackpackSlot,false);
		Bottomprint(Player::getClient(%player), "Shields at Max");
		return;
	}
	%player.shieldRecharging = true;
	schedule("Player::rechargeShield("@ %player @");", 1.0, %player);
}

function AssaultPackImage::onDeactivate(%player,%imageSlot)
{
	%player.shieldRecharging = false;
	Player::trigger(%player,$BackpackSlot,false);
	Bottomprint(Player::getClient(%player), "Shield Recharging Deactivated");
}

function AssaultPack::onMount(%player,%item)
{
	%player.shieldMax = 1.25;
	%player.shieldStrength = %player.shieldMax * 0.25;
	Bottomprint(Player::getClient(%player), "Shields: 25%");
	schedule("Player::capacitorFade("@ %player @");", 10, %player);
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 1);
}

function AssaultPack::onUnmount(%player,%item)
{
	%player.shieldStrength = 0;
	%player.shieldMax = 0;
	%player.shieldRecharging = false;
	%player.shieldHit = false;
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, false);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 1);
}

//----------------------------------------------------------------------------

$DefenderPackItems[0] = DiscAmmo;
$DefenderPackItems[1] = PlasmaAmmo;
$DefenderPackItems[2] = ShotgunAmmo;
$DefenderPackItems[3] = MineAmmo;

$DefenderPackMax[DiscAmmo] = 15;
$DefenderPackMax[PlasmaAmmo] = 15;
$DefenderPackMax[ShotgunAmmo] = 15;
$DefenderPackMax[MineAmmo] = 3;

ItemImageData DefenderPackImage
{
	shapeFile = "ShieldPack";
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	weaponType = 2;
	minEnergy = 0;
	maxEnergy = 0;
	sfxFire = SoundShieldOn;
	firstPerson = false;
};

ItemData DefenderPack
{
	description = "Defender Pack";
	shapeFile = "ShieldPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = DefenderPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 299;
	hudIcon = "AmmoPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function DefenderPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
	for(%i = 0; %i <= 3 ; %i = %i +1) 
		{
		%numPack = 0;
		%ammoItem = $DefenderPackItems[%i];
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		if(%i == 0) %item.DiscAmmo = %numPack;
		else if(%i == 1) %item.DiscAmmo = %numPack;
		else if(%i == 2) %item.PlasmaAmmo = %numPack;
		else if(%i == 3) %item.ShotgunAmmo = %numPack;
		else %item.MineAmmo = %numPack;
		}
	}
}

function DefenderPack::onCollision(%this,%object)
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

function DefenderPackImage::onActivate(%player,%imageSlot)
{
	if(%player.shieldStrength == %player.shieldMax) {
		%player.shieldRecharging = false;
		Player::trigger(%player,$BackpackSlot,false);
		Bottomprint(Player::getClient(%player), "Shields at Max");
		return;
	}
	%player.shieldRecharging = true;
	schedule("Player::rechargeShield("@ %player @");", 1.0, %player);
}

function DefenderPackImage::onDeactivate(%player,%imageSlot)
{
	%player.shieldRecharging = false;
	Player::trigger(%player,$BackpackSlot,false);
	Bottomprint(Player::getClient(%player), "Shield Recharging Deactivated");
}


function checkPacksAmmo(%player, %item)
{
	for(%i = 0; %i <=3 ; %i = %i +1) {
		%ammoItem = $DefenderPackItems[%i];
		if(%i == 0) %numAdd = %item.DiscAmmo;
		else if(%i == 1) %numAdd = %item.DiscAmmo;
		else if(%i == 2) %numAdd = %item.PlasmaAmmo;
		else if(%i == 3) %numAdd = %item.ShotgunAmmo;
		else %numAdd = %item.MineAmmo;
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "MineAmmo" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%player,%ammoItem,%numAdd);
		if(%item.className == "HandAmmo" && Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
	}						 
}

function fillDefenderPack(%client)
{
%player = Client::getOwnedObject(%client);
for(%i = 0; %i <=3 ; %i = %i +1) 
	{
	%item = $DefenderPackItems[%i];
	%maxnum = $DefenderPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "MineAmmo" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		if(%item.className == "HandAmmo" && Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
		}	
	}
}


function DefenderPack::onMount(%player,%item)
{
	%player.shieldMax = 1.25;
	%player.shieldStrength = %player.shieldMax * 0.25;
	Bottomprint(Player::getClient(%player), "Shields: 25%");
	schedule("Player::capacitorFade("@ %player @");", 10, %player);
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 1);
}

function DefenderPack::onUnmount(%player,%item)
{
	%player.shieldStrength = 0;
	%player.shieldMax = 0;
	%player.shieldRecharging = false;
	%player.shieldHit = false;
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 1);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Scout Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData ScoutPackImage
{
	shapeFile = "mortargun";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0.25 };
	mountRotation = { -1.8, 0, 0 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
//	sfxFire = SoundFireFlierRocket;
};

ItemData ScoutPack
{
	description = "Scout Pack";
	shapeFile = "mortargun";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = ScoutPackImage;
	price = 199;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function ScoutPackImage::onActivate(%player,%imageSlot)
{
	if(GameBase::isAtRest(%player) != True) {
		if (GameBase::getEnergy(%player) > 30) {
			ScoutPackImage::Boost(%player);
			GameBase::setEnergy(%player,GameBase::getEnergy(%player)-30);
		}
		else {
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy for afterburners.");
			GameBase::setEnergy(%player,GameBase::getEnergy(%player)/1.5);
		}
}
if(Player::isTriggered(%player,$BackpackSlot))
	 Player::trigger(%player,$BackpackSlot,false);
}


function ScoutPackImage::Boost(%player)
{
	%playerVector=Item::getVelocity(%player);
	%rndCheck=Floor(getRandom()*100);
	if (%rndCheck <=2)
		{ %boostAmount=0.5; %message="They said they fixed it! I trusted them! It's not my fault!"; }
	else if (%rndCheck > 2 && %rndCheck <=5)
		{ %boostAmount=1.0; %message="Damn piece of junk!"; }
	else if (%rndCheck > 10 && %rndCheck < 90)
		{ %boostAmount=2.5; %message="Afterburners!"; }
	else if (%rndCheck >=90 && %rndCheck < 95)
		{ %boostAmount=3; %message="Gawd damn!"; }
	else if (%rndCheck >=95)
		{ %boostAmount=5; %message="You must have a ramjet in your pants!"; }
	else
		{ %boostAmount=2; %message="Boosted."; }
	%boostVector=getWord(%playerVector, 0)*%boostAmount @ " " @ getWord(%playerVector, 1)*%boostAmount @ " " @ getWord(%playerVector, 2)*%boostAmount @ " ";
	Item::setVelocity(%player, %boostVector);
	if(%boostAmount<2) {
		playVoice(Player::getClient(%player),0,"LeftMissionArea");
		playVoice(Player::getClient(%player),"dsgst4");
	}
	else {
		GameBase::playSound(%player, SoundFireFlierRocket,0);
		playVoice(Player::getClient(%player),"cheer2");
	}
	Client::sendMessage(Player::getClient(%player),0,%message);
}

function ScoutPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) + 3.5);
}

function ScoutPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 3.5);
}

//----------------------------------------------------------------------------

$SniperPackItems[0] = SniperAmmo;
$SniperPackMax[SniperAmmo] = 10;

ItemImageData SniperPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	weaponType = 2; 
	maxEnergy = 10.5;
	sfxFire = SoundJammerOn;
	firstPerson = false;
};

ItemData SniperPack
{
	description = "Sniper Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	imageType = SniperPackImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 199;
	hudIcon = "AmmoPack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function SniperPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
		%numPack = 0;
		%ammoItem = SniperAmmo;
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		%item.SniperAmmo = %numPack;
	}
}

function SniperPack::onCollision(%this,%object)
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

function SniperPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jammer On");
	%rate = Player::getSensorSupression(%player) + 10;
	Player::setSensorSupression(%player,%rate);
}

function SniperPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Jammer Off");
	%rate = Player::getSensorSupression(%player) - 10;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

function SniperPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	%rechargeRate = GameBase::getRechargeRate(%player) + 2.5;
	GameBase::setRechargeRate(%player,%rechargeRate);
}

function SniperPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	%rechargeRate = GameBase::getRechargeRate(%player) - 2.5;
	GameBase::setRechargeRate(%player,%rechargeRate);
}

function checkPacksAmmo(%player, %item)
{
		%ammoItem = SniperAmmo;
		%numAdd = %item.SniperAmmo;
		Player::incItemCount(%player,%ammoItem,%numAdd);
}

function fillSniperPack(%client)
{
%player = Client::getOwnedObject(%client);
	%item = SniperAmmo;
	%maxnum = $SniperPackMax[0];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		}	
}

//----------------------------------------------------------------------------

ItemImageData StealthPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	weaponType = 2;  // Sustained
	maxEnergy = 10.5;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
	firstPerson = false;
};

ItemData StealthPack
{
	description = "Stealth Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = StealthPackImage;
	price = 199;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function StealthPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Stealth On");
	%rate = Player::getSensorSupression(%player) + 75;
	Player::setSensorSupression(%player,%rate);
	GameBase::startFadeOut(%player);
}

function StealthPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Stealth Off");
	%rate = Player::getSensorSupression(%player) - 75;
	Player::setSensorSupression(%player,%rate);
	GameBase::startFadeIn(%player);
	Player::trigger(%player,$BackpackSlot,false);
}


function StealthPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 2.5);
}

function StealthPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 2.5);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Minelayer Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData MinelayerPackImage
{
	shapeFile = "AmmoPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	minEnergy = -1;
 	maxEnergy = -3;
	firstPerson = false;
};

ItemData MinelayerPack
{
	description = "Minelayer Pack";
	shapeFile = "AmmoPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = MinelayerPackImage;
	price = 199;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$MinelayerPackMax[mineammo] = 10;

function MinelayerPack::onDrop(%player, %item)
{
if($matchStarted) 
	{
	%item = Item::onDrop(%player,%item);
		%numPack = 0;
		%ammoItem = MineAmmo;
		%maxnum = $ItemMax[Player::getArmor(%player), %ammoItem];
		%pCount = Player::getItemCount(%player, %ammoItem);
		if(%pCount > %maxnum) 
			{
			%numPack = %pCount - %maxnum;
			Player::decItemCount(%player,%ammoItem,%numPack);
			}	
		%item.MineAmmo = %numPack;
	}
}

function MinelayerPack::onCollision(%this,%object)
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
	%ammoItem = minemmmo;
	%numAdd = %item.MineAmmo;
	%mine = Player::getMountedItem(%player,$MineSlot);
	if(%mine != -1 && %mine != "MineAmmo" && %maxnum > 0) {
		while(Player::getMountedItem(%player,$MineSlot) != -1) {
			teamEnergyBuySell(%player,%mine.price);
			Player::decItemCount(%player,%mine);
			}
		}
	Player::incItemCount(%player,%ammoItem,%numAdd);
	if(Player::getMountedItem(%player,$MineSlot) == -1)
		Player::useItem(%player,%item);
}

function fillMinelayerPack(%client)
{
	%player = Client::getOwnedObject(%client);
	%item = MineAmmo;
	%maxnum = $MinelayerPackMax[%item];
	%maxnum = checkResources(%player,%item,%maxnum); 
	if(%maxnum) 
		{
		%mine = Player::getMountedItem(%player,$MineSlot);
		if(%mine != -1 && %mine != "MineAmmo" && %maxnum > 0) {
			while(Player::getMountedItem(%player,$MineSlot) != -1) {
				teamEnergyBuySell(%player,%mine.price);
				Player::decItemCount(%player,%mine);
				}
			}
		Player::incItemCount(%client,%item,%maxnum);
		teamEnergyBuySell(%player,%item.price * %maxnum * -1);
		if(Player::getMountedItem(%player,$MineSlot) == -1)
			Player::useItem(%player,%item);
		}	
}


function MinelayerPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 2.5);
}

function MinelayerPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) - 2.5);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Repulsor Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData RepulsorPackImage
{
	shapeFile = "armorPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
	sfxFire = rocketExplosion;
};

ItemData RepulsorPack
{
	description = "Repulsor Pack";
	shapeFile = "armorPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = RepulsorPackImage;
	price = 199;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function RepulsorPackImage::onActivate(%player,%imageSlot)
{
	if (GameBase::getEnergy(%player) > 50)	{ 
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)-50);
		RepulsorPackImage::Repel(%player);
	}
	else	{
		Client::sendMessage(Player::getClient(%player),0,"Not enough energy to repulse.");
		GameBase::setEnergy(%player,GameBase::getEnergy(%player)/1.5);
	}
	if(Player::isTriggered(%player,$BackpackSlot))
		Player::trigger(%player,$BackpackSlot,false); 
}


function RepulsorPackImage::Repel(%player)
{
	%playerPos=GameBase::getPosition(%player);
  	%repelSet=newObject("grendadeSet",SimSet);
	%numObjects=containerBoxFillSet(%repelSet,$SimPlayerObjectType | $VehicleObjectType,%playerPos,35,35,15,0);
	for (%objCounter=0; %objCounter <= %numObjects; %objCounter++) {
		%target=Group::getObject(%repelSet, %objCounter);
		if (%target != %player)	{
			%targetPos=GameBase::getPosition(%target);
			%targetVector=Vector::neg(Vector::sub(%playerPos, %targetPos));
			%distanceToTarget=Vector::getDistance(%targetPos, %playerPos);
			%force=10-(%distanceToTarget*0.25);
			%targetNewVector=getWord(%targetVector, 0) * %force @ " " @ getWord(%targetVector, 1) * %force @ " " @ getWord(%targetVector, 2) * %force @ " "; 
			playSound(rocketExplosion, %targetPos);
			Item::setVelocity(%target, %targetNewVector);
		}
	}
	deleteObject(%repelSet);
}

function RepulsorPack::onMount(%player,%item)
{
	Player::trigger(%player,$BackpackSlot,false);
	%rechargeRate = GameBase::getRechargeRate(%player) + 2.5;
	GameBase::setRechargeRate(%player,%rechargeRate);
}

function RepulsorPack::onUnmount(%player,%item)
{
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	%rechargeRate = GameBase::getRechargeRate(%player) - 2.5;
	GameBase::setRechargeRate(%player,%rechargeRate);
}

//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//  Commander Pack
//  by Dissident
//  bt@efn.org
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------

ItemImageData CommanderPackImage
{
	shapeFile = "jetPack";
	weaponType = 2;
	mountPoint = 2;
	mountOffset = { 0, -0.1, 0 };
	minEnergy = 0;
 	maxEnergy = 0;
	firstPerson = false;
	sfxFire = SoundRepairItem;
};

ItemData CommanderPack
{
	description = "Commander Pack";
	shapeFile = "jetPack";
	className = "Backpack";
   heading = "cBackpacks";
	shadowDetailMask = 4;
	imageType = CommanderPackImage;
	price = 499;
	hudIcon = "energypack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function CommanderPack::onMount(%player,%item)
{
	%player.shieldMax = 1.0;
	%player.shieldStrength = %player.shieldMax * 0.25;
	Bottomprint(Player::getClient(%player), "Shields: 25%");
	schedule("Player::capacitorFade("@ %player @");", 10, %player);
	Player::trigger(%player,$BackpackSlot,false);
	GameBase::setRechargeRate(%player, GameBase::getRechargeRate(%player) + 2.5);
	GameBase::setAutoRepairRate(%player, Gamebase::getAutoRepairRate(%player) + 0.08);
}

function CommanderPack::onUnmount(%player,%item)
{
	%player.shieldStrength = 0;
	%player.shieldMax = 0;
	%player.shieldRecharging = false;
	%player.shieldHit = false;
	if (GameBase::isActive(%item)) 
		GameBase::setActive(%item, False);
	GameBase::setRechargeRate(%player,GameBase::getRechargeRate(%player) - 2.5);
	GameBase::setAutoRepairRate(%player, Gamebase::getAutoRepairRate(%player) - 0.08);
}


function CommanderPackImage::onActivate(%player,%imageSlot)
{
	if(%player.shieldStrength == %player.shieldMax) {
		%player.shieldRecharging = false;
		Player::trigger(%player,$BackpackSlot,false);
		Bottomprint(Player::getClient(%player), "Shields at Max");
		return;
	}
	%player.shieldRecharging = true;
	schedule("Player::rechargeShield("@ %player @");", 1.0, %player);
}

function CommanderPackImage::onDeactivate(%player,%imageSlot)
{
	%player.shieldRecharging = false;
	Player::trigger(%player,$BackpackSlot,false);
	Bottomprint(Player::getClient(%player), "Shield Recharging Deactivated");
}

