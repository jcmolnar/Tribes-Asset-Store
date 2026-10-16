//---------------------------------------------------------------------
//
//		PENIS HEAD
//
//---------------------------------------------------------------------

ItemImageData PenisPackImage
{
	shapeFile  = "cactus1";
	mountPoint = 2;
	mountOffset = { 0, 0.2, -0.5 }; 
	mountRotation = { 0, 0, 0 };
	weaponType = 0; // Single Shot
	reloadTime = 0.2;
	fireTime = 0;
	minEnergy = 5;
	maxEnergy = 6;
	projectileType = Undefined;
	accuFire = false;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1.0, 0.7, 0.5 };
	sfxFire = SoundFlyerActive;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PenisPack
{
	heading = "cBackPacks";
	description = "Penis";
	className = "BackPack";
	shapeFile  = "cactus1";
	hudIcon = "plasma";
	shadowDetailMask = 4;
	imageType = PenisPackImage;
	price = 0;
	showWeaponBar = true;
};
function PenisPack::onFire(%player, %slot) 
{
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("Pee",%trans,%player,%vel);
}

function PenisPack::onUnMount(%player,%item)
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 	if (%armor == "parmor")
	Client::sendMessage(%client,1,"The curse can not be removed so easily.");
	return;
}

function PenisPack::onDrop(%player,%item)
{
	%player = Client::getOwnedObject(%client);
 	%armor = Player::getArmor(%client);
 	if (%armor == "parmor")
	Client::sendMessage(%client,1,"The curse can not be removed so easily.");
	return;
}