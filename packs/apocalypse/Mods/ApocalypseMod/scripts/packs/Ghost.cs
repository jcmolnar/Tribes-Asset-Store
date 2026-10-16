//----------------------------------------------------------------------------

addToInv(GhostPack,1,1);

setArmorItemMax(GhostPack,1,1,1,1,1,1,1, 0, 0,0,0,0);

//----------------------------------------------------------------------------

ItemImageData GhostPackImage
{
	shapeFile = "sensor_jammer";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
	mountOffset = { 0, 0.03, 0.1 };
	mountRotation = { 1.57, 0, 0 };
	firstPerson = false;
};

ItemData GhostPack
{
	description = "Ghost Pack";
	shapeFile = "sensor_jammer";
	className = "Backpack";
   heading = $InvCatPacks;
	shadowDetailMask = 4;
	imageType = GhostPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

$MountMSG[GhostPack] = "<JC><F2>Ghost Pack <F0>- <F1>Cloaks you making you invisble to others.";

function GhostPackImage::onActivate(%player,%imageSlot)
{
	GameBase::startFadeout(%player);
	Client::sendMessage(Player::getClient(%player),0,"Ghost Pack Activated");
	%rate = Player::getSensorSupression(%player) + 10;
	Player::setSensorSupression(%player,%rate);
	%player.Cloaked = true;
}

function GhostPackImage::onDeactivate(%player,%imageSlot)
{
	if(%player.Cloaked) {
		GameBase::startFadein(%player);
		Client::sendMessage(Player::getClient(%player),0,"Ghost Pack Deactivated");
		%rate = Player::getSensorSupression(%player) - 10;
		Player::setSensorSupression(%player,%rate);
		%player.Cloaked = false;
		Player::trigger(%player,$BackpackSlot,false);
	}
}

//--------------------------------------
