//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Mortar);
$InvList[Mortar] = 1;
$InvList[MortarAmmo] = 1;

$SellAmmo[MortarAmmo] = 10;
$AutoUse[Mortar] = True;
$WeaponAmmo[Mortar] = MortarAmmo;

$ItemMax[larmor, Mortar] = 0;		//Seraph
$ItemMax[lfemale, Mortar] = 0;		//Seraph
$ItemMax[earmor, Mortar] = 0;		//Slave
$ItemMax[efemale, Mortar] = 0;		//Slave
$ItemMax[marmor, Mortar] = 0;		//Pawn
$ItemMax[aarmor, Mortar] = 0;		//Navigator
$ItemMax[darmor, Mortar] = 1;		//Atomizer
$ItemMax[barmor, Mortar] = 0;		//Paladin

$ItemMax[larmor, MortarAmmo] = 0;	//Seraph
$ItemMax[lfemale, MortarAmmo] = 0;	//Seraph
$ItemMax[earmor, MortarAmmo] = 0;	//Slave
$ItemMax[efemale, MortarAmmo] = 0;	//Slave
$ItemMax[marmor, MortarAmmo] = 0;	//Pawn
$ItemMax[aarmor, MortarAmmo] = 0;	//Navigator
$ItemMax[darmor, MortarAmmo] = 30;	//Atomizer
$ItemMax[barmor, MortarAmmo] = 20;	//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++



ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemImageData MortarImage 
{
	shapeFile = "mortargun";
//	mountRotation = { 0, 0, 0 };
//	mountOffset = { 0 , -0.2, 0.5 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShellRed;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemImageData MortarImage2 
{
	shapeFile = "mortargun";
	mountRotation = { 0, 0, 0 };
	mountOffset = { 0 , -0.6, 0.5 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemImageData MortarImage3 
{
	shapeFile = "energygun";
	mountRotation = { 0, -0.925, 0 }; // 1.57  .785
	mountOffset = { -0.08 , -0.75, 0.65 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 
 

ItemImageData MortarImage4 
{
	shapeFile = "energygun";
	mountRotation = { 0, -2.229, 0 }; // 1.57  .785
	mountOffset = { -0.08 , -0.75, 0.55 };
	mountPoint = 0;
	weaponType = 0;
	ammoType = MortarAmmo;
	projectileType = MortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
}; 

ItemData Mortar 
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 77;
	showWeaponBar = true;
};

ItemData Mortar2 
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage2;
	price = 77;
	showWeaponBar = false;
	showinventory = false;
};

ItemData Mortar3 
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage3;
	price = 77;
	showWeaponBar = false;
	showinventory = false;
};


ItemData Mortar4 
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = MortarImage4;
	price = 77;
	showWeaponBar = false;
	showinventory = false;
};


$MortarSlotA=4;
$MortarSlotB=7;
$MortarSlotC=6;

function Mortar::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Mortar");

//	Player::mountItem(%player,Mortar2,$MortarSlotA); 
//	Player::mountItem(%player,Mortar3,$MortarSlotB);
//	Player::mountItem(%player,Mortar4,$MortarSlotC);
}

function Mortar::onUnmount(%player,%imageSlot)
{
//	Player::unmountItem(%player,$MortarSlotA); 
//	Player::unmountItem(%player,$MortarSlotB); 
//	Player::unmountItem(%player,$MortarSlotC); 
}


//
//function Mortar::onUse(%player,%item)
//{
//Weapon::onUse(%player,%item);
//        bottomprint(Player::getClient(%player), "<jc><f2>Mortar", 2); }


