// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
$ItemMax[larmor,Welder]	= 1;
$ItemMax[lfemale,Welder]	= 1;

AddWeapon(Welder);
AddToInv(Welder);

LaserData welderCharge
{
   laserBitmapName   = "paintpulse.bmp";
   //hitName           = "laserhit.dts";

   damageConversion  = 0.000;
   baseDamageType    =  $ElectricityDamageType;

   beamTime          = 0.2;

    lightType   = 3;  // Weapon Fire
    lightRadius = 2;
    lightTime   = 1;
    lightColor  = { 0.25, 1, 0.25 };

   detachFromShooter = false;
   //hitSoundId        = SoundLaserHit;
};

ItemImageData WelderImage
{
	shapeFile = "mortar";	//"tracer";
	//mountPoint = 0;
	//mountOffset = { -0.1, -0.3, -0.1 };
	//mountRotation = {0, 1.57, 0};
	mountPoint		= 0;
    mountRotation = { 0, 0.785, 0 };
    mountOffset = { 0, 0, 0 };
    
    weaponType = 0; // SingleShot
	//projectileType = Invalid;

    //spinUpTime = 0.0;
    //spinDownTime = 0.0;
    //fireTime = 0.0;
    accuFire = true;
    
	minEnergy = 3;
	maxEnergy = 0; //8 Energy used/sec for sustained weapons
	reloadTime = 0.2;
	//lightType = 3; // Weapon Fire
	//lightRadius = 2;
	//lightTime = 1;
    //lightColor = { 0.85, 0.25, 0.25 };
    sfxActivate		= SoundPickUpWeapon;
    //sfxReady = SoundJammerOn;
	//sfxActivate = SoundActivateAmmoStation;
	//sfxFire = SoundLaserIdle;//SoundSpinUpDisc;	//SoundELFIdle;
};

ItemData Welder
{
	description   = "Object Welder";
	className     = "Tool";
	shapeFile     = "mortar";
	heading = "bTools";
	shadowDetailMask = 4;
	imageType     = WelderImage;
	price         = 50;
	showWeaponBar = false;
};

ItemImageData Weld1Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { -0.1, 0.0, 0.04 };
	mountRotation = {0, -1.57, 0};
	weaponType = 0;
};

ItemData Weld1
{
	description = "--";
	className = "Weapon";
	shapeFile = "paintgun";
	//hudIcon = "sniper";
	heading = "zInvalid";
	shadowDetailMask = 4;
	imageType = Weld1Image;
	price = 0;
	showWeaponBar = false;
};

ItemImageData Weld2Image
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0.1, 0.0, 0.04 };
	mountRotation = {0, 1.57, 0};
	weaponType = 0;
};

ItemData Weld2
{
	description = "--";
	className = "Weapon";
	shapeFile = "paintgun";
	//hudIcon = "sniper";
	heading = "zInvalid";
	shadowDetailMask = 4;
	imageType = Weld2Image;
	price = 0;
	showWeaponBar = false;
};
$WeldMode::[0] = "Welder";
$WeldMode::[1] = "Copier";

function WelderImage::onFire(%player)
{
    %clientId = Player::getclient(%player);
    if(%clientId.CannotDeploy == true)
    {
        Client::sendMessage(%clientId,1,"Your tool-usage priviliges have been disabled.~waccess_denied.wav");
        return;
    }
    if(%clientId.WeldMode == 0)
        Welder::WeldGrab(%player);
    else
        Welder::CopyObj(%player);
}

function Welder::onMount(%player,%item)
{
    Weapon::CompleteMount(%player,%item);
}

function Welder::MountExtras(%player)
{
	Player::mountItem(%player,Weld2,7);
    Player::mountItem(%player,Weld1,6);
}

function Welder::onUnmount(%player,%item)
{
	Player::unmountItem(%player,7);
    Player::unmountItem(%player,6);
}

function Welder::CopyObj(%player)
{
    %clientId = Player::getclient(%player);
   if(GameBase::getLOSInfo(%player,100))
   {
      %TempObj = $los::object;
      if(isObject(%TempObj) == false)
        return;
      if(%TempObj.DepIndex == "")
      {
        bottomprint(%clientid,"<jc>Copier: <f2>Nothing in range");
        return;
      }
      %msg = "Copyed " @ $DeployableDesc[%TempObj.DepIndex];
      %clientId.CurDeploy = %TempObj.DepIndex;
      bottomprint(%clientid,"<jc>Copier: <f2>" @ %msg);

      return;
   }
   bottomprint(%clientid,"<jc>Copier: <f2>Nothing in range");
}

function Welder::WeldGrab(%player)
{
    %clientId = Player::getclient(%player);
   if(GameBase::getLOSInfo(%player,100))
   {
      %trans = GameBase::getMuzzleTransform(%player);
      %vel = Item::getVelocity(%player);
      Projectile::spawnProjectile("welderCharge",%trans,%player,%vel);
      playSound(SoundBeaconUse, GameBase::getPosition(%player));
    
      %TempObj = $los::object;
      if(isObject(%TempObj) == false)
          return;
      %type = getObjectType(%TempObj);
        %name = GameBase::getMapName(%TempObj);
        if (%name == "")
           %name = %TempObj.Desc;
        if (%name == "")
           %name = "Object ID " @ %TempObj;
           
    if(WorkingLayer::isInLayerScope(%clientId, %TempObj) == false)
    {
        bottomprint(%clientid,"<jc>Object Welder: <f2>Object in non-active layer");
        return;
    }
           
      if (%type == "SimTerrain" || %type == "Player" || %type == "Flier")
      {
         bottomprint(%clientid,"<jc>Object Welder: <f2>Nothing in range");
         if(!Player::isAiControlled(%TempObj))
            return;
      }

      if (%TempObj.Owner != %clientId && Admin::isMovingAllObject(%clientId) != true)
      {
         if (%TempObj.Owner != "" || BuildGroup::IsInGroup(%clientId, %TempObj.Owner.buildgroup)) // If its not a mission obj or in same group, it's someone elses
         {
            bottomprint(%clientid,"<jc>Object Welder: <f2>Nothing in range");
            return;
         }
      }

      if(%TempObj.DontWeld == true)
      {
          bottomprint(%clientid,"<jc>Object Welder: <f2>Nothing in range");
          return;
      }

      if(%TempObj.weld == "" || %TempObj.weld == false)
      {
          %TempObj.weld = true;
          bottomprint(%clientid,"<jc>Object Welder: <f2>Object " @ %name @ " now welded in place");
          if(GameBase::getDataName(%TempObj).className == "ModXElevator")
            schedule("Elevator::onWeld("@%TempObj@","@%TempObj.weld@");",0.1,%TempObj);
          return;
      }
      
      if(%TempObj.weld == true)
      {
          %TempObj.weld = false;
          bottomprint(%clientid,"<jc>Object Welder: <f2>Object " @ %name @ " now freed");
          if(GameBase::getDataName(%TempObj).className == "ModXElevator")
            schedule("Elevator::onWeld("@%TempObj@","@%TempObj.weld@");",0.1,%TempObj);
          return;
      }
      
      return;
   }
   bottomprint(%clientid,"<jc>Object Welder: <f2>Nothing in range");
}

function WeldAllClObj(%clientId, %weld)
{
      if(%weld == true)
          %weldtype = "welded in place";
      else
          %weldtype = "freed";

      for(%i = 0; (%TempObj = %clientId.ClObj[%i]) != ""; %i++)
      {
          if(%weld == true)
          {
              %TempObj.weld = true;
              if(GameBase::getDataName(%TempObj).className == "ModXElevator")
                schedule("Elevator::onWeld("@%TempObj@","@%TempObj.weld@");",0.1,%TempObj);
              continue;
          }
          else
          {
              %TempObj.weld = false;
              if(GameBase::getDataName(%TempObj).className == "ModXElevator")
                schedule("Elevator::onWeld("@%TempObj@","@%TempObj.weld@");",0.1,%TempObj);
              continue;
          }
      }
      //bottomprint(%clientid,"<jc><f2>All objects are now " @ %weldtype);
      return %weldtype;
}
