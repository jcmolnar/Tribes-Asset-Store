// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
$AutoUse[Warper] = False;

$ItemMax[larmor, Warper] = 1;
$ItemMax[lfemale, Warper] = 1;

//----------------------------------------------------------------------------

LaserData warpCharge
{
   laserBitmapName   = "paintPulse.bmp";//"forcefield5.bmp";
   //hitName           = "laserhit.dts";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = true;
   //hitSoundId        = SoundLaserHit;
};

ItemImageData WarperImage
{
shapeFile = "mortargun";
mountPoint = 0;
mountRotation = { 0, 3.14, 0 };
mountOffset = { 0, 0, 0 };

weaponType = 0; // Sustained
//projectileType = creatorCharge;
accuFire = true;
minEnergy = 0;
maxEnergy = 0;
reloadTime = 0.4;

lightType   = 3;  // Weapon Fire
lightRadius = 1;
lightTime   = 1;
lightColor = { 0.85, 0.25, 0.25 };

sfxFire     = SoundFireTargetingLaser;
sfxActivate = SoundPickUpWeapon;
};

ItemData Warper
{
description   = "Warper";
className     = "Tool";
shapeFile     = "paintgun";
//hudIcon       = "targetlaser";
heading = "bTools";
shadowDetailMask = 4;
imageType     = WarperImage;
price         = 50;
showWeaponBar = false;
};

function WarperImage::onFire(%player)
{
    //echo("CreatorImage::onFire(" @ %player @ ")");
    %clientId = Player::getclient(%player);
    if(%clientId.CannotDeploy == true)
    {
        Client::sendMessage(%clientId,1,"Your tool-usage priviliges have been disabled.~waccess_denied.wav");
        return;
    }
    %trans = GameBase::getMuzzleTransform(%player);
    %vel = Item::getVelocity(%player);
    Projectile::spawnProjectile("warpCharge",%trans,%player,%vel);

    if(!GameBase::getLOSInfo(%player,500))
	{
		Client::sendMessage(%clientId,0,"Warp position out of range");
		return;
    }
    
    %pos = $los::position;
    //echo("GameBase::setPosition(" @ %player @ ", " @ %pos @ ");");
    //schedule("GameBase::setPosition(" @ %player @ ", " @ %pos @ ");", 0.2);
    GameBase::setPosition(%player, %pos);

}

AddToInv(Warper);
AddWeapon(Warper);
