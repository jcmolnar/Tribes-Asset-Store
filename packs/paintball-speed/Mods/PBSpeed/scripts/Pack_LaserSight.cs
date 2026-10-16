//-projectile
TargetLaserData LaserPointer
{
   laserBitmapName   = "laserpulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};

//----------
ItemImageData TLPackImage 
{
	shapeFile = "jetpack";
	mountPoint = 2;
	weaponType = 2;
	projectileType = LaserPointer;
	minEnergy = 0.00000001;
	maxEnergy = 0.0000001;
	reloadTime = 0.2;
	sfxFire = SoundELFIdle;
	lightType = 0;   
	lightRadius = 0;
	lightTime = 0;
	lightColor = { 10, 10, 10 };
};

ItemData TLPack 
{
  description = "New: Laser Sight";
  shapeFile = "paintgun";
  className = "Backpack";
  heading = eBackpacks;
  shadowDetailMask = 4;
  imageType = TLPackImage;
  price = 275;
  hudIcon = "paintgun";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function TLPackImage::onActivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Laser On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function TLPackImage::onDeactivate(%player,%imageSlot) 
{
	Client::sendMessage(Player::getClient(%player),0,"Laser Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);	
}

//Invo Stuff
$ItemMax[larmor, TLPack] = 1;
$ItemMax[lfemale, TLPACK] = 1;
$InvList[TLPACK] = 1;
