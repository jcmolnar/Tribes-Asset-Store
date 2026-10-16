$InvList[RemoteDetonator] = 1;
$RemoteInvList[RemoteDetonator] = 1;

$AutoUse[RemoteDetonator] = 1;

// Don't forget to add weapon into Next and Prev tables in NextWeapon.cs

// Who can use this tool
$ItemMax[reconarmor, RemoteDetonator] = 0;
$ItemMax[reconfemalearmor, RemoteDetonator] = 0;
$ItemMax[espionagearmor, RemoteDetonator] = 0;
$ItemMax[espionagefemalearmor, RemoteDetonator] = 0;
$ItemMax[engineerarmor, RemoteDetonator] = 0;
$ItemMax[engineerfemalearmor, RemoteDetonator] = 0;
$ItemMax[infantryarmor, RemoteDetonator] = 0;
$ItemMax[infantryfemalearmor, RemoteDetonator] = 0;
$ItemMax[falloutarmor, RemoteDetonator] = 0;
$ItemMax[falloutfemalearmor, RemoteDetonator] = 0;
$ItemMax[demolitionsarmor, RemoteDetonator] = 1;
$ItemMax[assaultarmor, RemoteDetonator] = 0;
$ItemMax[artilleryarmor, RemoteDetonator] = 0;
$ItemMax[commanderarmor, RemoteDetonator] = 1;

SoundData SoundTriggerDetonator
{
   wavFileName = "Shell_click.wav";
   profile = Profile3dNear;
};

ItemImageData RemoteDetonatorImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single shot
	// projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime   = 3;
	lightColor  = { 1, 0, 1 };

	sfxFire     = SoundTriggerDetonator;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RemoteDetonator
{
	description   = "Remote Detonator";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
	heading = "tTools";
	shadowDetailMask = 4;
	imageType     = RemoteDetonatorImage;
	price         = 100;
	showWeaponBar = false;
};

function RemoteDetonatorImage::onFire(%this, %slot) 
{
	// This function will trigger this player's team's detonation frequency
	%player = %this;

	// Get this player's team
	%team = GameBase::getTeam(%player);

	// trigger frequency
	DetonationFrequency::Trigger(%team);

}


