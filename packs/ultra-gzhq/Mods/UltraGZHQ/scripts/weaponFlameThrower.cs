$InvList[Flamer] = 1;
$MobileInvList[Flamer] = 1;
$RemoteInvList[Flamer] = 1;

$WeaponAmmo[Flamer] = "";
$AutoUse[Flamer] = false;

addWeapon(Flamer);

//=======================
// Addons By: Arma
//=======================

ItemImageData Flame2Image
{
	shapeFile = "paintgun";
	mountPoint = 0; 
	mountOffset = { 0, 0.7, -0.1 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Flame2
{
	description = "Flame2";
	className = "Weapon";
	shapeFile = "paintgun";
	shadowDetailMask = 4;
	imageType = Flame2Image;
	showWeaponBar = false;
};

ItemImageData Flame3Image
{
	shapeFile = "grenadel";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Flame3
{
	description = "Flame3";
	className = "Weapon";
	shapeFile = "grenadel";
	shadowDetailMask = 4;
	imageType = Flame3Image;
	showWeaponBar = false;
};
//=======================
ItemImageData FlamerImage
{
	shapeFile = "breath";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;
	fireTime = 0.15;
	projectileType = FlamerBoltA;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireFlamer;
};

ItemData Flamer
{
	description = "Flame Thrower";
	shapeFile = "grenadel";
	hudIcon = "sensorjamerpack";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FlamerImage;
	showWeaponBar = true;
	price = 2500;
};

function Flamer::onMount(%player,%item)
{	

	Player::mountItem(%player, Flame2, 6);
	Player::mountItem(%player, Flame3, 7);

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Flame Thrower: <f2>Mounted");
}

function Flamer::onUnMount(%player,%item)
{
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}
