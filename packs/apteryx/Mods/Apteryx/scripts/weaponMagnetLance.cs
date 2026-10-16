$InvList[SpellFlameThrower] = 1;
$MobileInvList[SpellFlameThrower] = 1;
$RemoteInvList[SpellFlameThrower] = 1;

$AutoUse[SpellFlameThrower] = False;
$WeaponAmmo[SpellFlameThrower] = "";

addWeapon(SpellFlameThrower);

ItemImageData SpellFlameThrowerImage 
{
	shapeFile = "enbolt";
	mountOffset = { 0.0, -1.0, 0.0 };
	mountPoint = 0;
	weaponType = 0;
	minEnergy = 10;
	maxEnergy = 20;
	accuFire = false;
	reloadTime = 0.33;
	fireTime = 0.33;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData SpellFlameThrower 
{
	description = "Electro-Magnetic Lance";
	className = "Weapon";
	shapeFile = "enbolt";
	hudIcon = "blaster";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = SpellFlameThrowerImage;
	price = 335;
	showWeaponBar = true;
};

function SpellFlameThrower::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Electro-Magnetic Lance: <f2>an intense electromagnetic beam drains energy and deals good damage if you can actually hit with it.");
}

function spellFlameThrowerImage::onFire(%player, %slot)
{
	gamebase::setenergy(%player, gamebase::getenergy(%player) - 20);
	%vel = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	Projectile::spawnProjectile("MagneticLance",%trans,%player,%vel);		Projectile::spawnProjectile("MagneticLanceEffect1",%trans,%player,%vel);
	Projectile::spawnProjectile("MagneticLanceEffect2",%trans,%player,%vel);
}