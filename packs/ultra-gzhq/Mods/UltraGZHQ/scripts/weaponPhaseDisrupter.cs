$InvList[PhaseDisrupter] = 1;
$MobileInvList[PhaseDisrupter] = 1;
$RemoteInvList[PhaseDisrupter] = 1;

$InvList[PhaseDisrupterAmmo] = 1;
$MobileInvList[PhaseDisrupterAmmo] = 1;
$RemoteInvList[PhaseDisrupterAmmo] = 1;

$AutoUse[PhaseDisrupter] = False;
$SellAmmo[PhaseDisrupterAmmo] = 2;
$WeaponAmmo[PhaseDisrupter] = PhaseDisrupterAmmo;

addWeapon(PhaseDisrupter);
addAmmo(PhaseDisrupter, PhaseDisrupterAmmo, 2);

ItemData PhaseDisrupterAmmo
{
	description = "Disrupter Ammo";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 200;
};

//=====================
// Added image by: Arma
//=====================
ItemImageData Phase2Image
{
	shapeFile = "jetpack";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { -1.40, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Phase2
{
	description = "Phase2";
	className = "Weapon";
	shapeFile = "jetpack";
	shadowDetailMask = 4;
	imageType = Phase2Image;
	showWeaponBar = false;
};
//===========================

ItemImageData PhaseDisrupterImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 3.10, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
	weaponType = 0; // Single Shot
	ammoType = PhaseDisrupterAmmo;
	//projectileType = PhaseDisrupterBolt;
	accuFire = true;
	reloadTime = 0.2;	//0.3
	fireTime = 0.2;	//0.3
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = BigExplosion1;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundJetLight;
	sfxReady = SoundJammerOn;
};

ItemData PhaseDisrupter
{
	description = "Void Disrupter";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = PhaseDisrupterImage;
	price = 1000;
	showWeaponBar = true;
};

function PhaseDisrupter::onMount(%player,%item) 
{	

	Player::mountItem(%player,Phase2,7);

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Void Disrupter: <f2>Mounted");
}

function PhaseDisrupterImage::onFire(%player,%slot)
{
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("PhaseDisrupterBolt",%trans,%player,%vel);
	Projectile::spawnProjectile("PhaseDisrupterBoltNull",%trans,%player,%vel);
	Player::decItemCount(%player,$WeaponAmmo[PhaseDisrupter],1);
}

function PhaseDisrupter::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}