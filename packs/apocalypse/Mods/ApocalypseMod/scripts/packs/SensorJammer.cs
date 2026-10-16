//--------------------------------------

addToInv(SensorJammerPack,1,1);

setArmorItemMax(SensorJammerPack,1,1,1,1,1,1,1, 0, 0,0,0,0);

//--------------------------------------

ItemImageData SensorJammerPackImage
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundJammerOn;
	mountOffset = { 0, -0.05, 0 };
	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "Sensor Jammer Pack";
	shapeFile = "sensorjampack";
	className = "Backpack";
   heading = $InvCatPacks;
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   validateShape = true;
   //validateMaterials = true;
};

$MountMSG[SensorJammerPack] = "<JC><F2>Sensor Jammer Pack <F0>- <F1>Reduces your radar signature and prevents guided missile lock.";

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
	%player.Jammed = true;
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	if(%player.Jammed) {
		Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
		%rate = Player::getSensorSupression(%player) - 20;
		Player::setSensorSupression(%player,%rate);
		%player.Jammed = false;
		Player::trigger(%player,$BackpackSlot,false);
	}
}

//--------------------------------------
