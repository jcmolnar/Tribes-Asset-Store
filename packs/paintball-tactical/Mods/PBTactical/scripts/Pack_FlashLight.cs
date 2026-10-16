//-projectile
TargetLaserData FlashLight
{
   laserBitmapName   = "bar00.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 9.0;
   lightColor        = { 1.0, 1.0, 1.0 };

   detachFromShooter = true;
};

//----------
ItemImageData FLPackImage 
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	projectileType = FlashLight;
	minEnergy = 0.00000001;
	maxEnergy = 0.0000001;
	reloadTime = 0.2;
	lightType = 0;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 10, 10, 10 };
};

ItemData FLPack 
{
  description = "Flash Light";
  shapeFile = "sensorjampack";
  className = "Backpack";
  heading = $InvHead[ihGad];
  shadowDetailMask = 4;
  imageType = FLPackImage;
  price = 0;
  hudIcon = "fear";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function FLPackImage::onActivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Flash Light On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function FLPackImage::onDeactivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Flash Light Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);	
}

//Invo Stuff
$ItemMax[larmor, FLPack] = 1;
$ItemMax[lfemale, FLPACK] = 1;
$InvList[FLPACK] = 1;
