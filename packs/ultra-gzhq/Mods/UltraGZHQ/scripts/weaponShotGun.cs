$InvList[Shotgun] = 1;
$MobileInvList[Shotgun] = 1;
$RemoteInvList[Shotgun] = 1;

$InvList[ShotgunShells] = 1;
$MobileInvList[ShotgunShells] = 1;
$RemoteInvList[ShotgunShells] = 1;

$AutoUse[Shotgun] = false;
$WeaponAmmo[Shotgun] = ShotgunShells;
$SellAmmo[ShotgunShells] = 15;

addWeapon(Shotgun);
addAmmo(Shotgun, ShotgunShells, 5);

ItemData ShotgunShells 
{
	description = "Shotgun Shells";
	className = "Ammo";
	shapeFile = "ammo2";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 2;
};

function ShotgunShells::onDamage(%this)
{
	if($debug)echo("ShotgunShells::onDamage(%this) "@%this);
}


//=====================
// Added image by: Arma
//=====================
ItemImageData Shotgun2Image
{
	shapeFile = "shotgun";
	mountPoint = 0; 
	mountOffset = { 0, 0, 0 }; //-  left-right, back-front, up-down
	mountRotation = { 0, 0, 0 }; //- X= up-down , Y= roll-left-right , Z= left-right
};

ItemData Shotgun2
{
	description = "Shotgun2";
	className = "Weapon";
	shapeFile = "shotgun";
	shadowDetailMask = 4;
	imageType = Shotgun2Image;
	showWeaponBar = false;
};
//===========================

ItemImageData ShotgunImage 
{
	shapeFile = "breath";
	mountPoint = 0;
	weaponType = 0;
	ammoType = ShotgunShells;
	reloadTime = 0.1;
	accuFire = false;
	fireTime = 0.1;
	sfxFire = SoundFireShotgun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Shotgun 
{
	description = "Shotgun";
	shapeFile = "shotgun";
	hudIcon = "ammopack";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = ShotgunImage;
	showWeaponBar = true;
	price = 85;
};

function Shotgun::onMount(%player,%item) 
{	
      Player::mountItem(%player,Shotgun2,7);

	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Shotgun: <f2>Mounted");
}

function ShotgunImage::onFire(%player, %slot) 
{		
	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
		
	//echo("Boy howdy thats a blast!");

	Player::decItemCount(%player,$WeaponAmmo[Shotgun],1);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
	Projectile::spawnProjectile("ShotgunBullet",%trans,%player,%vel);
						
}


function Shotgun::onUnMount(%player,%item)
{
	Player::unmountItem(%player,7);
}