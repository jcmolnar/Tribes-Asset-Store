//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Nukes);
$InvList[Nukes] = 1;
$InvList[NukeAmmo] = 1;

$SellAmmo[NukeAmmo] = 5;
$AutoUse[Nukes] = True;
$WeaponAmmo[Nukes] = NukeAmmo;

$ItemMax[larmor, Nukes] = 0;	//Seraph
$ItemMax[lfemale, Nukes] = 0;	//Seraph
$ItemMax[earmor, Nukes] = 0;	//Slave
$ItemMax[efemale, Nukes] = 0;	//Slave
$ItemMax[marmor, Nukes] = 0;	//Pawn
$ItemMax[aarmor, Nukes] = 0;	//Navigator
$ItemMax[darmor, Nukes] = 0;	//Atomizer
$ItemMax[barmor, Nukes] = 1;	//Paladin

$ItemMax[larmor, NukeAmmo] = 5;	//Seraph
$ItemMax[lfemale, NukeAmmo] = 5;//Seraph
$ItemMax[earmor, NukeAmmo] = 0;	//Slave
$ItemMax[efemale, NukeAmmo] = 0;//Slave
$ItemMax[marmor, NukeAmmo] = 0;	//Pawn
$ItemMax[aarmor, NukeAmmo] = 0;	//Navigator
$ItemMax[darmor, NukeAmmo] = 0;	//Atomizer
$ItemMax[barmor, NukeAmmo] = 5;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++


ItemData NukeAmmo
{
	description = "Warhead";
	className = "Ammo";
   	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 11;
};

ItemImageData NukesImage
{	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, 0.1, 0};
	mountRotation = { 0, 3.1416, 0}; //3.1416
	weaponType = 0; // Single Shot
	projectileType = FgcShell;//BabyNukeBomb
	accuFire = true;
	ammoType = NukeAmmo;
	reloadTime = 1;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};


ItemImageData NukesiImage
{	shapeFile = "plasammo";
	mountPoint = 0;
	mountOffset = { 0, -0.17, -0.25 };
	mountRotation = { 0,  1.57, 1.57}; //3.1416
	weaponType = 0; // Single Shot
	projectileType = FgcShell;//BabyNukeBomb
	accuFire = true;
	ammoType = NukeAmmo;
	reloadTime = 1;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };
	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData Nukesi
{	description = "Reaper Nuke Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = NukesiImage;
	price = 1;
	showWeaponBar = false;
	showInventory = false;
};

ItemData Nukes
{	description = "Reaper Nuke Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = NukesImage;
	price = 777;
	showWeaponBar = true;
};

$NukesSlotA=4;


function Nukes::onUse(%player,%item, $WeaponSlot)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == Gamma)
	{
	Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Reaper Nuke Launcher", 2);
	Player::mountItem(%player,nukesi,$NukesSlotA);
	}
	//Client::sendMessage(%client,0,"Must have Deut. Battery to use Negatron Beam");
}

//function Nukes::onMount(%player,%imageSlot,%item,$WeaponSlot) 
//{
//	if(Player::getMountedItem(%player,$BackpackSlot) == Gamma)
//	Weapon::onUse(%player,%item);
//	%client = Player::getclient(%player);
//        bottomprint(%client, "<jc><f2>Reaper Nuke Launcher");
//	Player::mountItem(%player,nukesi,$NukesSlotA);
//	
//
//}

function Nukes::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$NukesSlotA);
}