//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
//$InvList[SensorJammerPack] = 1;

$ItemMax[larmor, SensorJammerPack] = 1;	//Seraph
$ItemMax[lfemale, SensorJammerPack] = 1;//Seraph
$ItemMax[earmor, SensorJammerPack] = 1;	//Slave
$ItemMax[efemale, SensorJammerPack] = 1;//Slave
$ItemMax[marmor, SensorJammerPack] = 0;	//Pawn
//PORT-OFF: $ItemMax[aarmor, SensorJammerPack = 1;	//Navigator
//PORT-OFF: $ItemMax[darmor, SensorJammerPack] = 0;	//Atomizer
//PORT-OFF: $ItemMax[barmor, SensorJammerPack] = 0;	//Paladin
//PORT-OFF: 
//PORT-OFF: //+++++++++++++++++++++++++++++++++++++
//PORT-OFF: //+++++++++++++++++++++++++++++++++++++
//PORT-OFF: 
//PORT-OFF: ItemImageData SensorJammerPackImage 
//PORT-OFF: {
//PORT-OFF: 	shapeFile = "sensorjampack";
//PORT-OFF: 	mountPoint = 2;
//PORT-OFF: 	weaponType = 2;
//PORT-OFF: 	maxEnergy = 10;
//PORT-OFF: 	sfxFire = SoundJammerOn;
//PORT-OFF: 	mountOffset = { 0, -0.05, 0 };
//PORT-OFF: 	mountRotation = { 0, 0, 0 };
//PORT-OFF: 	firstPerson = false;
//PORT-OFF: }; 
//PORT-OFF: 
//PORT-OFF: ItemData SensorJammerPack 
//PORT-OFF: {
//PORT-OFF: 	description = "Sensor Jammer Pack";
//PORT-OFF: 	shapeFile = "sensorjampack";
//PORT-OFF: 	className = "Backpack";
//PORT-OFF: 	heading = "cBackpacks";
//PORT-OFF: 	shadowDetailMask = 4;
//PORT-OFF: 	imageType = SensorJammerPackImage;
//PORT-OFF: 	price = 33;
//PORT-OFF: 	hudIcon = "sensorjamerpack";
//PORT-OFF: 	showWeaponBar = true;
//PORT-OFF: 	hiliteOnActive = true;
//PORT-OFF: }; 
//PORT-OFF: 
//PORT-OFF: function SensorJammerPackImage::onActivate(%player,%imageSlot)
//PORT-OFF: {
//PORT-OFF: 	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
//PORT-OFF: 	%rate = Player::getSensorSupression(%player) + 20;
//PORT-OFF: 	Player::setSensorSupression(%player,%rate);
//PORT-OFF: }
//PORT-OFF: 
//PORT-OFF: function SensorJammerPackImage::onDeactivate(%player,%imageSlot)
//PORT-OFF: {
//PORT-OFF: 	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
//PORT-OFF: 	%rate = Player::getSensorSupression(%player) - 20;
//PORT-OFF: 	Player::setSensorSupression(%player,%rate);
//PORT-OFF: 	Player::trigger(%player,$BackpackSlot,false);
//PORT-OFF: } 
