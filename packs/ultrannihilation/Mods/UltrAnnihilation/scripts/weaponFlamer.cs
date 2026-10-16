$InvList[Flamer] = 1;
$MobileInvList[Flamer] = 1;
$RemoteInvList[Flamer] = 1;

$InvList[FlamerAmmo] = 1;
$MobileInvList[FlamerAmmo] = 1;
$RemoteInvList[FlamerAmmo] = 1;

$WeaponAmmo[Flamer] = FlamerAmmo;
$AutoUse[Flamer] = True;

addWeapon(Flamer);
addAmmo(Flamer, FlamerAmmo, 5);

ItemData FlamerAmmo
{	description = "FlamerAmmo";
	heading = $InvHead[ihAmm];
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData FlamerImage
{	shapeFile = "shotgun";
        mountPoint = 0;
	ammoType = FlamerAmmo;
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.05;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundFireFlamer;
};

ItemData Flamer
{	description = "Flamer";
	shapeFile = "shotgun";
	hudIcon = "blaster";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = FlamerImage;
	showWeaponBar = true;
	price = 2500;
};

function FlamerImage::onFire(%player, %slot) 
{
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Flamer]);
	if(%AmmoCount) 
	{
		%client = GameBase::getOwnerClient(%player);
		Player::decItemCount(%player,$WeaponAmmo[Flamer],1);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("Flames",%trans,%player,%vel);
		Projectile::spawnProjectile("FlameSmoke",%trans,%player); 
	}
	else
		Client::sendMessage(Player::getClient(%player), 0,"Out Of FlamerAmmo");
}

function Flamer::onMount(%player,%item,$WeaponSlot)
{	%client = Player::getclient(%player);
	bottomprint(%client, "Flamer: <f2>This weapon fires flaming Gasoline to engulf your target.");
}
