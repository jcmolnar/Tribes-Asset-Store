$InvList[SniperRifle] = 1;
$MobileInvList[SniperRifle] = 1;
$RemoteInvList[SniperRifle] = 1;

$InvList[SniperAmmo] = 1;
$MobileInvList[SniperAmmo] = 1;
$RemoteInvList[SniperAmmo] = 1;

$AutoUse[SniperRifle] = false;
$SellAmmo[SniperAmmo] = 5;
$WeaponAmmo[SniperRifle] = "";

addWeapon(SniperRifle);
addAmmo(SniperRifle, SniperAmmo, 2);

ItemData SniperAmmo 
{
	description = "Sniper Ammo";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData SniperRifleImage 
{
	shapeFile = "paintgun";
	mountPoint = 0;
	minenergy = 20;
	maxenergy = 20;
	//mountRotation = { 0,-1.57, 0 };
	weaponType = 0;
	accuFire = true;
	fireTime = 1.0;
	reloadTime = 0.5;
	sfxFire = debrisSmallExplosion;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SniperRifle 
{
	description = "Magnetic Mirror";
	className = "Weapon";
	shapeFile = "paintgun";
	hudIcon = "shieldpack";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = SniperRifleImage;
	price = 325;
	showWeaponBar = true;
};

function SniperRifle::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));
	
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Magnetic Mirror: <f2>Fires a shield face in front of you that overpowers incoming shots and redirects them toward where you are aiming.  Will not completely stop area affect weapons, and consistently fails indoors due to magnetic resonance with metal.");
}

function SniperRifleimage::onfire(%player, %slot)
{
	%client = Player::getclient(%player);
	%client.throwstrength = 2.5;
	gamebase::setenergy(%player, gamebase::getenergy(%player) - 20);
	%obj = newObject("","Mine","ShootingShield");
	Armor::ThrowGrenade(%player, %obj);
	gamebase::setrotation(%obj, gamebase::getrotation(%player));
	%pos = gamebase::getposition(%obj);
	%temp1 = getword(%pos, 0);
	%temp2 = getword(%pos, 1);
	%temp3 = getword(%pos, 2);
	%temp3 = %temp3 - 4;
	gamebase::setposition(%obj, ""@%temp1@" "@%temp2@" "@%temp3);
	$CrowOwner = %player;
}