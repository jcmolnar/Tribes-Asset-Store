//----------------------------------------------------------------------------
//Special Pack-Items
//----------------------------------------------------------------------------
ItemImageData BurnFlameImage
{
	shapeFile = "plasmabolt";
	mountPoint = 2;
	mountOffset = { 0, 0.1, 0.3 };
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.45;
	minEnergy = -1;
	maxEnergy = 0;
	sfxFire = SoundJetHeavy;
	firstPerson = false;
};

ItemData BurnFlame
{
	description = "Flamer Burn";
	shapeFile = "plasmaex";
	className = "Penalty";
   heading = "gBackPacks";
	shadowDetailMask = 4;
	imageType = BurnFlameImage;
	price = 0;
	hudIcon = "shieldpack";
	showWeaponBar = false;
	hiliteOnActive = true;
   validateShape = true;
   validateMaterials = true;
showInventory = false; 
};

function BurnFlame::onUse(%player,%item)
{
	if (Player::getMountedItem(%player,$DefaultSlot) != %item) {
		Player::mountItem(%player,%item,$DefaultSlot);
	}
}

function BurnFlame::onMount(%player,%item)
{
	Player::trigger(%player,$DefaultSlot,true);
	Client::sendMessage(Player::getClient(%player),1,"Your Magma Cannon Back Fired!");
}

function BurnFlameImage::onUnmount(%player,%item)
{
	Client::sendMessage(Player::getClient(%player),0,"You are no longer burning.");
}
function BurnFlameImage::onFire(%player, %slot) 
{
	GameBase::applyDamage(%player,$BurnDamageType, 0.3,
	GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
}