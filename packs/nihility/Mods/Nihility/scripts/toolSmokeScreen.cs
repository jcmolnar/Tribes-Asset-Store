//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Smokey);
$InvList[Smokey] = 1;

$AutoUse[Smokey] = True;
$WeaponAmmo[Smokey] = "";

$ItemMax[larmor, Smokey] = 0;		//Seraph
$ItemMax[lfemale, Smokey] = 0;		//Seraph
$ItemMax[earmor, Smokey] = 1;		//Slave
$ItemMax[efemale, Smokey] = 1;		//Slave
$ItemMax[marmor, Smokey] = 0;		//Pawn
$ItemMax[aarmor, Smokey] = 1;		//Navigator
$ItemMax[darmor, Smokey] = 0;		//Atomizer
$ItemMax[barmor, Smokey] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

ItemImageData SmokeyImage 
{	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 1;
	maxEnergy = 1;
	reloadTime = 1;
	fireTime = 0.01;
	projectileType = SmokeyShell;
	accuFire = true;
	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Smokey 
{	description = "Smoke Screen";
	className = "Tool";
	shapeFile = "grenadeL";
	hudIcon = "mortar";
	heading = "fTools";
	shadowDetailMask = 4;
	imageType = SmokeyImage;
	price = 77;
	showWeaponBar = true;
};

function Smokey::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "<jc><f2>Smoke Screen");
}