//================================================================
//t2 sensor jammer Pack
//================================================================
$ItemMax[larmor, SensorJammerPack] = 1;
$ItemMax[lfemale, SensorJammerPack] = 1;
$ItemMax[marmor, SensorJammerPack] = 1;
$ItemMax[mfemale, SensorJammerPack] = 1;
$ItemMax[harmor, SensorJammerPack] = 1;
//================================================================
$InvList[SensorJammerPack] = 1;
$RemoteInvList[SensorJammerPack] = 1;
//================================================================
SoundData SoundSensorOn
{
   wavFileName = "pack_sensoron.wav";
   profile = Profile3dNearLoop;
};
//====================================
ItemImageData SensorJammerPackImage
{
	shapeFile = "pack_sensor";
	mountPoint = 2;
	weaponType = 2;  // Sustained
	maxEnergy = 10;  // Energy used/sec for sustained weapons
	sfxFire = SoundSensorOn;
  	//mountOffset = { 0, -0.05, 0 };
  	//mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData SensorJammerPack
{
	description = "Sensor Jammer Pack";
	shapeFile = "pack_sensor";
	className = "Backpack";
   heading = "gUtility Packs";
	shadowDetailMask = 4;
	imageType = SensorJammerPackImage;
	price = 200;
	hudIcon = "sensorjamerpack";
	showWeaponBar = true;
	hiliteOnActive = true;
   //validateShape = true;
   //validateMaterials = true;
};

function SensorJammerPackImage::onActivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
{
	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}
//================================================================