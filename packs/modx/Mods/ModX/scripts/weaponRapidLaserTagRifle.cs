// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//
//  Transform Manipulation by: Plasmatic
//
//----------------------------------------------------------------------------
$RapidLaserTagRifleDmg = 0.2;

BulletData RapidLaserTagRifleBoltRed
{
   explosionTag       = laserExpRed;
   damageClass        = 0;
   damageValue        = $RapidLaserTagRifleDmg;
   damageType         = $LaserTagDamageType;
   explosionRadius    = 1.0;

   muzzleVelocity     = 1800.0;
   totalTime          = 2.0;
   liveTime           = 2.0;
   inheritedVelocityScale = 100.0;
   isVisible          = False;

};


BulletData RapidLaserTagRifleBoltBlue
{
   explosionTag       = laserExpBlue;
   damageClass        = 0;
   damageValue        = $RapidLaserTagRifleDmg;
   damageType         = $LaserTagDamageType;
   explosionRadius    = 1.0;

   muzzleVelocity     = 1800.0;
   totalTime          = 2.0;
   liveTime           = 2.0;
   inheritedVelocityScale = 100.0;
   isVisible          = False;

};

ItemImageData RapidLaserTagRifleImage
{
    
    shapeFile = "chaingun";
    mountPoint = 0;
    mountRotation = { 0, 3.14, 0 };//1.57
    mountOffset = {0, -0.22, -0.07};
    weaponType = 3;
    reloadTime = 0.0;
    spinUpTime = 0.0;
    spinDownTime = 0.0;
    fireTime = 0.1;

    accuFire = true;

    minEnergy = 10;
    maxEnergy = 10;

    lightType = 3;  // Weapon Fire
    lightRadius = 2;
    lightTime = 1;
    lightColor = { 1, 0, 0 };

    sfxActivate = SoundPickUpWeapon;
};

function RapidLaserTagRifleImage::onFire(%player, %this)
{

    %set = newObject("set",SimSet);
    %radius = $LaserTagNoDmgBeaconRange;
    %numItems = containerBoxFillSet(%set, $StaticObjectType | $SimInteriorObjectType, GameBase::getPosition(%this), %radius, %radius, %radius, 0);
    for(%i = %numItems - 1 ; %i>=0; %i--)
    {
        %obj = Group::getObject(%set, %i);
        if(%obj.IsLTSafeBeacon == true)
            return;
    }

    %nrg = GameBase::getEnergy(%player);
    if(%nrg < RapidLaserTagRifleImage.minEnergy)
    {
        playSound(SoundDryFire,GameBase::getMuzzlePosition(%player));
        return;
    }

   %data = GameBase::getDataName(%player);
   %pos = GameBase::getPosition(%player);
   %Rot = GameBase::getRotation(%player);
   %energy = GameBase::getEnergy(%player);

      if (GameBase::getLOSInfo(%player,2000))
      {
         %distance = Vector::getDistance(%Pos, $LOS::position);

      }
      else %distance = 100;

      %d = %distance*3;

      if(%d > 400) %d = 400;
      if(%d < 50) %d = 50;
      //%m = %skew*2 +1;
      //%d = %skew*10;

      %Client = Player::getClient(%player);
      //bottomprint(%Client,"<jc>"@ %m@", "@%skew@", "@%d);


         %trans = GameBase::getMuzzleTransform(%player);
         %vel = Item::getVelocity(%player);
         %xrnd = (floor(getRandom() *21)-10)/%d;      //*21 -10)/100
         %yrnd = (floor(getRandom() *21)-10)/%d;
         %zrnd = (floor(getRandom() *21)-10)/%d;

         %trans1= getWord(%trans,0);
         %trans2= getWord(%trans,1);
         %trans3= getWord(%trans,2);
         %trans4= getWord(%trans,3) + %xrnd;
         %trans5= getWord(%trans,4) + %yrnd;
         %trans6= getWord(%trans,5) + %zrnd;
         %trans7= getWord(%trans,6);
         %trans8= getWord(%trans,7);
         %trans9= getWord(%trans,8);
         %trans10=getWord(%trans,9);
         %trans11=getWord(%trans,10);
         %trans12=getWord(%trans,11);
         %NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6 @" "@ %trans7 @" "@ %trans8 @" "@ %trans9 @" "@ %trans10 @" "@ %trans11 @" "@ %trans12;
         //%NewTrans = %trans1 @" "@ %trans2 @" "@ %trans3 @" "@ %trans4 @" "@ %trans5 @" "@ %trans6;
         //%obj = "TagerLaser";AntimLaser
    if($LaserTagXtra == BoolToNum(true))
    {
        if(GameBase::getTeam(%player) == 0)
        {
            Projectile::spawnProjectile("LaserTagLaserBlue",%NewTrans,%player,%vel);
            Projectile::spawnProjectile("RapidLaserTagRifleBoltBlue",%NewTrans,%player,%vel);
        }
        else
        {
            Projectile::spawnProjectile("LaserTagLaserRed",%NewTrans,%player,%vel);
            Projectile::spawnProjectile("RapidLaserTagRifleBoltRed",%NewTrans,%player,%vel);
        }
    }
    else
    {
        Projectile::spawnProjectile("LaserTagLaserRed",%NewTrans,%player,%vel);
        Projectile::spawnProjectile("RapidLaserTagRifleBoltRed",%NewTrans,%player,%vel);
    }


    //GameBase::setEnergy(%player, %nrg - RapidLaserTagRifleImage.maxEnergy);
    playSound(SoundFireLaser, GameBase::getMuzzlePosition(%player));
}

ItemData RapidLaserTagRifle
{
    description = "Rapid Laser Tag Rifle";
    className = "Weapon";
    shapeFile = "sniper";
    hudIcon = "sniper";
    heading = "bWeapons";
    shadowDetailMask = 4;
    imageType = RapidLaserTagRifleImage;
    price = 200;
    showWeaponBar = true;
    validateShape = true;
    validateMaterials = true;
};

AddWeapon(RapidLaserTagRifle);
