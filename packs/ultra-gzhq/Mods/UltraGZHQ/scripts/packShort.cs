ItemImageData ShortPackImage
{
	shapeFile = "fusionbolt";
	mountPoint = 2;
	mountOffset = { 0, 0.2, 0.4 };
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.01;
	minEnergy = -1;
	maxEnergy = 1;
	sfxFire = SoundELFFire;
	firstPerson = false;
};

ItemData ShortPack
{
	description = "Electrical Short";
	shapeFile = "enex";
	className = "Penalty";
   heading = "gBackPacks";
	shadowDetailMask = 4;
	imageType = ShortPackImage;
	price = 0;
	hudIcon = "shieldpack";
	showWeaponBar = false;
	hiliteOnActive = true;
   //validateShape = true;
   //validateMaterials = true;
showInventory = false; 
};

function ShortPack::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$DefaultSlot) != %item) {
		Player::mountItem(%player,%item,$DefaultSlot);
	}
}

function ShortPack::onMount(%player,%item)
{
	Player::trigger(%player,$DefaultSlot,true);
	Client::sendMessage(Player::getClient(%player),1,"-=Power Systems have shorted out=-");
}

function ShortPackImage::onFire(%player, %slot) 
{
	%vecVelocity = Item::getVelocity(%player);
	%ZeroVelocity = GetWord(%vecVelocity, 0) / 8 @ " " @
			    GetWord(%vecVelocity, 1) / 8 @ " " @
			    GetWord(%vecVelocity, 2);
	Player::trigger(%player, $WeaponSlot, false);
	Item::setVelocity(%player, %ZeroVelocity);
	GameBase::setEnergy(%player,0);
}
