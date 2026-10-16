$InvList[FlameThrower] = 1;
$MobileInvList[FlameThrower] = 1;
$RemoteInvList[FlameThrower] = 1;

$InvList[FlameThrowerAmmo] = 1;
$MobileInvList[FlameThrowerAmmo] = 1;
$RemoteInvList[FlameThrowerAmmo] = 1;

$AutoUse[FlameThrower] = False;
$SellAmmo[FlameThrowerAmmo] = 25;	
$WeaponAmmo[FlameThrower] = FlameThrowerAmmo;

addWeapon(FlameThrower);
addAmmo(FlameThrower, FlameThrowerAmmo, 10);

ItemData FlameThrowerAmmo 
{
	description = "Acid Cannisters";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};


//===========================

ItemImageData FlameThrowerImage 
{
	shapeFile = "mortar";
	mountPoint = 0;
	weaponType = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	ammoType = FlameThrowerAmmo;
	projectileType = AcidSpray;
	accuFire = false;
	reloadTime = 0.1;
	fireTime = 0.1;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundJetHeavy;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundJetLight;
};

ItemData FlameThrower 
{
	description = "Acid Sprayer";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FlameThrowerImage;
	price = 175;
	showWeaponBar = true;
};

function FlameThrower::onMount(%player,%item) 
{	

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Acid Sprayer: <f2>Mounted");
}
