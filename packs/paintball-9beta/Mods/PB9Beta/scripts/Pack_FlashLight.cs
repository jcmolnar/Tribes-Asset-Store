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
	shapeFile = "shieldpack";
	mountPoint = 2;
	weaponType = 2;
	projectileType = FlashLight;
	minEnergy = 0.00000001;
	maxEnergy = 0.0000001;
	reloadTime = 0.2;
	//sfxFire = SoundELFIdle;
	lightType = 0;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 10, 10, 10 };
};

ItemData FLPack 
{
  description = "Flash Light";
  shapeFile = "paintgun";
  className = "Backpack";
  heading = eBackpacks;
  shadowDetailMask = 4;
  imageType = FLPackImage;
  price = 275;
  hudIcon = "paintgun";
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

$ItemMax[larmor, FLPack] = 1;
$ItemMax[lfemale, FLPack] = 1;
$InvList[FLPack] = 1;