$InvList[RubberMortar] = 1;
$MobileInvList[RubberMortar] = 1;
$RemoteInvList[RubberMortar] = 1;

$InvList[RubberAmmo] = 1;
$MobileInvList[RubberAmmo] = 1;
$RemoteInvList[RubberAmmo] = 1;

$AutoUse[RubberMortar]= false;
$WeaponAmmo[RubberMortar]= Rubberammo;
$SellAmmo[RubberAmmo]= 2;
$AmmoPackMax[RubberAmmo]= 4;

addWeapon(RubberMortar);
addAmmo(RubberMortar,RubberAmmo,1);

ItemData RubberAmmo
{
	description = "Air Mine";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RMortarImage
{
	shapeFile = "mine";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = RubberAmmo;
	reloadTime = 0.5;
	fireTime = 0.5;
	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPickUpWeapon;
	sfxActivate = SoundPickUpWeapon;
};

ItemData RubberMortar
{
	description = "Air Mine";
	className = "Weapon";
	shapeFile = "mine";
	hudIcon = "mortar";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RMortarImage;
	price = 275;
	showWeaponBar = true;
};

function RubberMortar::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Air Mine: <f2>leaves a mine hovering where you were.  Anyone who walks into it...");
}

function RMortarImage::onfire(%player, %slot)
{
	if(player::getitemcount(%player, RubberAmmo) > 0)
	{
		Player::decitemcount(%player, RubberAmmo);
		%obj = newObject("","StaticShape",AirealMine, true);
		gamebase::setteam(%obj, gamebase::getteam(%player));
		%pos = gamebase::getposition(%player);
		Gamebase::setposition(%obj, getword(%pos, 0) @ " " @ getword(%pos, 1) @ " " @ getword(%pos, 2) + 0.5);
	}
}