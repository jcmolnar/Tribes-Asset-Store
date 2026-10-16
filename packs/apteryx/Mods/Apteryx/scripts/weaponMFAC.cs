$InvList[DisarmerSpell] = 1;
$MobileInvList[DisarmerSpell] = 1;
$RemoteInvList[DisarmerSpell] = 1;

$AutoUse[DisarmerSpell] = True;
$WeaponAmmo[DisarmerSpell] = "";

addWeapon(DisarmerSpell);

ItemImageData DisarmerSpellImage
{
	shapeFile = "energygun";
	mountPoint = 0;
	weaponType = 0;
	reloadTime = 0.5;
	fireTime = 1.5;
	accuFire = true;
	sfxFire = SoundFireMortar;
	sfxReload = SoundDiscReload;
	sfxActivate = SoundPickUpWeapon;
};

ItemData DisarmerSpell 
{
	heading = $InvHead[ihWea];
	description = "MFAC";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "fear";
	shadowDetailMask = 4;
	imageType = DisarmerSpellImage;
	price = 550;
	showWeaponBar = true;
};

function DisarmerSpell::onMount(%player,%item) 
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Magnetto-Fusion Assault Cannon: <f2>fires a slow projectile with no blast radius but an incredible punch.");
}

function DisarmerSpellImage::onFire(%player, %slot)
{
	%energy = gamebase::getenergy(%player);
	if(%energy >= 42)
	{
		GameBase::setEnergy(%player, %energy - 40);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("MFAC",%trans,%player,%vel);
	}
}