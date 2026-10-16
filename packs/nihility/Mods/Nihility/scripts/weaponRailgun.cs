//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Railgun);
$InvList[Railgun] = 1;
$InvList[RailAmmo] = 1;

$SellAmmo[RailAmmo] = 10;
$AutoUse[Railgun] = True;
$WeaponAmmo[Railgun] = RailAmmo;

$ItemMax[larmor, Railgun] = 1;		//Seraph
$ItemMax[lfemale, Railgun] = 1;		//Seraph
$ItemMax[earmor, Railgun] = 0;		//Slave
$ItemMax[efemale, Railgun] = 0;		//Slave
$ItemMax[marmor, Railgun] = 0;		//Pawn
$ItemMax[aarmor, Railgun] = 0;		//Navigator
$ItemMax[darmor, Railgun] = 0;		//Atomizer
$ItemMax[barmor, Railgun] = 0;		//Paladin

$ItemMax[larmor, RailAmmo] = 10;	//Seraph
$ItemMax[lfemale, RailAmmo] = 10;	//Seraph
$ItemMax[earmor, RailAmmo] = 0;		//Slave
$ItemMax[efemale, RailAmmo] = 0;	//Slave
$ItemMax[marmor, RailAmmo] = 0;		//Pawn
$ItemMax[aarmor, RailAmmo] = 0;		//Navigator
$ItemMax[darmor, RailAmmo] = 0;		//Atomizer
$ItemMax[barmor, RailAmmo] = 0;		//Paladin
//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemData RailAmmo 
{
	description = "Rifle Ammo";
	className = "Ammo";
	heading = "xAmmunition";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
}; 

ItemImageData RailgunImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0};
	weaponType = 0;
	ammoType = RailAmmo;
	projectileType = RailRound;
	accuFire = true;
	reloadTime = 0.6;
	fireTime = 0.30;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
}; 

ItemData Railgun 
{
	description = "Hellspike Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
	heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 77;
	showWeaponBar = true;
}; 

function Railgun::onUse(%player,%item)
{
Weapon::onUse(%player,%item);
        bottomprint(Player::getClient(%player), "<jc><f2>Hellspike Rifle", 2); }
