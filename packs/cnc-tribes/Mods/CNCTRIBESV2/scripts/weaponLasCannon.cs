
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Las Cannon
//  By <[DC]>Paladin
//
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[LasCannon] = 1;
$RemoteInvList[LasCannon] = 1;
$AutoUse[LasCannon] = False;
$WeaponAmmo[LasCannon] = "";

addWeapon(LasCannon);

LaserData LasCannonCharge
{
   laserBitmapName   = "discglow1.bmp";
   hitName           = "laserhit.dts";

   damageConversion  = 0.055;
   baseDamageType    = $LaserDamageType;

   beamTime          = 1.0;

   lightRange        = 1.0;
   lightColor        = { 0.0, 0.0, 1.52 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

ItemImageData LasCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 2;
  mountOffset = { -0.5, 0.0, 0.3 };
  mountRotation = { 0.2, 0, 0 };

	weaponType = 0; // Single Shot
	projectileType = LasCannonCharge;
	accuFire = True;
	reloadTime = 3.0;
	fireTime = 0.05;
	minEnergy = 20;
	maxEnergy = 25;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 2.5, 2.0, 2.0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LasCannon
{
	description = "Las Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	heading = $InvHead[ihWea];
	hudIcon = "sniper";
	shadowDetailMask = 4;
	imageType = LasCannonImage;
	price = 1200;
	showWeaponBar = true;
};

function LasCannon::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Las Cannon: The most powerful energy weapon avaiable. However, it requires the Adv. Energy Pack to fire, which weighs the user down considerably.");
}

function LasCannon::onUse(%player,%item)
{
	if(Player::getMountedItem(%player,$BackpackSlot) == LaserPack)
		Weapon::onUse(%player,%item);
	else
		Client::sendMessage(Player::getClient(%player),0,
			"Must have an Adv. Energy Pack to use a Las Cannon."); }

