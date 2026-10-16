$InvList[Heavensfury] = 1;
$MobileInvList[Heavensfury] = 1;
$RemoteInvList[Heavensfury] = 1;

$AutoUse[Heavensfury] = True;
$WeaponAmmo[Heavensfury] = "";

addWeapon(Heavensfury);

ItemImageData HeavensfuryImage 
{	shapeFile = "shotgun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.02;
	fireTime = 0.02;
	minEnergy = 6;
	maxEnergy = 7;
	projectileType = HeavensfuryBolt;
	accuFire = false;
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Heavensfury 
{	heading = $InvHead[ihWea];
	description = "Heaven's Fury";
	className = "Weapon";
	shapeFile = "shotgun";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = HeavensfuryImage;
	price = 385;
	showWeaponBar = true;
};

function Heavensfury::onMount(%player,%item) 
{	%client = Player::getClient(%player);
	Bottomprint(%client, "Heaven's Fury: <f2>The angel's version of a shotgun.");
}