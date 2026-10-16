//------------------------------------------------------------------------
//---------------- GunsNAmmo Weapon Design by [RR]Mr.Pibb ----------------
//------------------------------------------------------------------------
SoundData SoundRackingMetal
{
	wavFileName = "mortar_reload.wav";
	profile = "Profile3dNear";
};

//--------------------------------------
SoundData SoundRackingBolt
{
	wavFileName = "weapon5.wav";
	profile = "Profile3dNear";
};

//------------------------------------------------------------------------
ItemData PistolRounds
{
	heading = "bAmmo Pouch";
	description = "Pistol Round";
	className = "Ammunition";
	shapeFile = "ammo2";
	price = $TerminalCost[PistolRounds];
};
$Plural[PistolRounds] = "Pistol Rounds";

//--------------------------------------
ItemData PistolMagazine
{
	heading = "bAmmo Pouch";
	description = "Pistol Magazine";
	className = "Ammunition";
	shapeFile = "ammo2";
	price = $TerminalCost[PistolMagazine];
};
$Plural[PistolMagazine] = "Pistol Magazines";

//--------------------------------------
ItemData RifleRounds
{
	heading = "bAmmo Pouch";
	description = "Rifle Round";
	className = "Ammunition";
	shapeFile = "ammo2";
	price = $TerminalCost[RifleRounds];
};
$Plural[RifleRounds] = "Rifle Rounds";

//--------------------------------------
ItemData RifleMagazine
{
	heading = "bAmmo Pouch";
	description = "Rifle Magazine";
	className = "Ammunition";
	shapeFile = "ammo2";
	price = $TerminalCost[RifleMagazine];
};
$Plural[RifleMagazine] = "Rifle Magazines";

//--------------------------------------
ItemData ShotgunRounds
{
	heading = "bAmmo Pouch";
	description = "Shotgun Round";
	className = "Ammunition";
	shapeFile = "ammo2";
	price = $TerminalCost[ShotgunRounds];
};
$Plural[ShotgunRounds] = "Shotgun Rounds";

//--------------------------------------
ItemData ShotgunMagazine
{
	heading = "bAmmo Pouch";
	description = "Shotgun Magazine";
	className = "Ammunition";
	shapeFile = "ammo2";
	price = $TerminalCost[ShotgunMagazine];
};
$Plural[ShotgunMagazine] = "Shotgun Magazines";

//--------------------------------------
ItemData EmptyRounds
{
	heading = "bAmmo Pouch";
	description = "Empty Round";
	className = "Ammunition";
	shapeFile = "ammo2";
	price = $TerminalCost[EmptyRounds];
};
$Plural[EmptyRounds] = "Empty Rounds";

//--------------------------------------
ItemData EmptyMagazine
{
	heading = "bAmmo Pouch";
	description = "Empty Magazine";
	className = "Ammunition";
	shapeFile = "ammo2";
	price = $TerminalCost[EmptyMagazine];
};
$Plural[EmptyMagazine] = "Empty Magazines";

//------------------------------------------------------------------------
ItemImageData PistolImage
{
	shapeFile = "paintgun";
	mountOffset = {0,0,0};
	mountRotation = {0,0,0};
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.25;

	sfxActivate = "SoundPickUpWeapon";
};

//--------------------------------------
ItemData SingleActionPistol
{
	heading = "aWeapons";
	description = "Single Action Pistol";
	className = "Firearm";
	shapeFile = "paintgun";
	hudIcon = "weapon";
	imageType = "PistolImage";
	price = $TerminalCost[SingleActionPistol];
	showWeaponBar = "true";
};
$Plural[SingleActionPistol] = "Single Action Pistols";

//--------------------------------------
ItemData DoubleActionPistol
{
	heading = "aWeapons";
	description = "Double Action Pistol";
	className = "Firearm";
	shapeFile = "paintgun";
	hudIcon = "weapon";
	imageType = "PistolImage";
	price = $TerminalCost[DoubleActionPistol];
	showWeaponBar = "true";
};
$Plural[DoubleActionPistol] = "Double Action Pistols";

//--------------------------------------
ItemData AutomaticPistol
{
	heading = "aWeapons";
	description = "Automatic Pistol";
	className = "Firearm";
	shapeFile = "paintgun";
	hudIcon = "weapon";
	imageType = "PistolImage";
	price = $TerminalCost[AutomaticPistol];
	showWeaponBar = "true";
};
$Plural[AutomaticPistol] = "Automatic Pistols";

//------------------------------------------------------------------------
ItemImageData ShotgunImage
{
	shapeFile = "energygun";
	mountOffset = {-0.05,-0.05,-0.05};
	mountRotation = {0,0,0};
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.25;

	sfxActivate = "SoundPickUpWeapon";
};

//--------------------------------------
ItemData PumpActionShotgun
{
	heading = "aWeapons";
	description = "Pump Action Shotgun";
	className = "Firearm";
	shapeFile = "energygun";
	hudIcon = "weapon";
	imageType = "ShotgunImage";
	price = $TerminalCost[PumpActionShotgun];
	showWeaponBar = "true";
};
$Plural[PumpActionShotgun] = "Pump Action Shotguns";

//--------------------------------------
ItemData SemiAutomaticShotgun
{
	heading = "aWeapons";
	description = "Semi-Automatic Shotgun";
	className = "Firearm";
	shapeFile = "energygun";
	hudIcon = "weapon";
	imageType = "ShotgunImage";
	price = $TerminalCost[SemiAutomaticShotgun];
	showWeaponBar = "true";
};
$Plural[SemiAutomaticShotgun] = "Semi-Automatic Shotguns";

//--------------------------------------
ItemData AutomaticShotgun
{
	heading = "aWeapons";
	description = "Automatic Shotgun";
	className = "Firearm";
	shapeFile = "energygun";
	hudIcon = "weapon";
	imageType = "ShotgunImage";
	price = $TerminalCost[AutomaticShotgun];
	showWeaponBar = "true";
};
$Plural[AutomaticShotgun] = "Automatic Shotguns";

//------------------------------------------------------------------------
ItemImageData RifleImage
{
	shapeFile = "sniper";
	mountOffset = {0,0,0};
	mountRotation = {0,0,0};
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.25;

	sfxActivate = "SoundPickUpWeapon";
};

//--------------------------------------
ItemData BoltActionRifle
{
	heading = "aWeapons";
	description = "Bolt Action Rifle";
	className = "Firearm";
	shapeFile = "sniper";
	hudIcon = "weapon";
	imageType = "RifleImage";
	price = $TerminalCost[BoltActionRifle];
	showWeaponBar = "true";
};
$Plural[BoltActionRifle] = "Bolt Action Rifles";

//--------------------------------------
ItemData SemiAutomaticRifle
{
	heading = "aWeapons";
	description = "Semi-Automatic Rifle";
	className = "Firearm";
	shapeFile = "sniper";
	hudIcon = "weapon";
	imageType = "RifleImage";
	price = $TerminalCost[SemiAutomaticRifle];
	showWeaponBar = "true";
};
$Plural[SemiAutomaticRifle] = "Semi-Automatic Rifles";

//--------------------------------------
ItemData AutomaticRifle
{
	heading = "aWeapons";
	description = "Automatic Rifle";
	className = "Firearm";
	shapeFile = "sniper";
	hudIcon = "weapon";
	imageType = "RifleImage";
	price = $TerminalCost[AutomaticRifle];
	showWeaponBar = "true";
};
$Plural[AutomaticRifle] = "Automatic Rifles";

//------------------------------------------------------------------------
ItemImageData Unarmed_Image
{
	shapeFile = "breath";
	mountOffset = {0,-0.2,0};
	mountRotation = {0,0,0};
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.25;
	sfxActivate = "SoundPickUpWeapon";
};

//--------------------------------------
ItemData Unarmed
{
	className = "Melee";
	shapeFile = "breath";
	imageType = "Unarmed_Image";
	showInventory = "false";
	showWeaponBar = "false";
};

//--------------------------------------
