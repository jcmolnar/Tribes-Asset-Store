//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Im Rec Pack: by Alazane
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[ImRecPack] = 0;
$RemoteInvList[ImRecPack] = 0;

// addAmmo(xxx, xxx, 1);

SeekingMissileData ImRecMissile 
{
  bulletShapeName = "rocket.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 1.2;
  damageType = $MissileDamageType;
  explosionRadius = 9.5;
  kickBackStrength = 175.0;
  muzzleVelocity = 72.0;
  totalTime = 10;
  liveTime = 10;
  seekingTurningRadius = 4;
  nonSeekingTurningRadius = 35.0;
  proximityDist = 1.5;
  smokeDist = 50;
  lightRange = 5.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 0.5;
  soundId = SoundJetHeavy;
};

SeekingMissileData PhotonTorpedo
{
  bulletShapeName = "fusionbolt.dts";
  explosionTag = rocketExp;
  collisionRadius = 0.0;
  mass = 2.0;
  damageClass = 1;
  damageValue = 5;
  damageType = $MissileDamageType;
  explosionRadius = 9.5;
  kickBackStrength = 175.0;
  muzzleVelocity = 45.0;
  totalTime = 100;
  liveTime = 100;
  seekingTurningRadius = 10.0;
  nonSeekingTurningRadius = 10.0;
  proximityDist = 1.5;
  smokeDist = 0;
  lightRange = 50.0;
  lightColor = { 0.4, 0.4, 1.0 };
  inheritedVelocityScale = 0.0;
  soundId = SoundJetHeavy;
};

LightningData ImRecLaserBeam
{
//  laserBitmapName = "laserPulse.bmp";
//  damageConversion = 0.0;
//  baseDamageType = 0;
//  lightRange = 2.0;
//  lightColor = { 0.25, 1.0, 0.25 };
//  detachFromShooter = false;

//  bitmapName = "lightningNew.bmp";
//  damageType = $ElectricityDamageType;
  boltLength = 400.0;
  coneAngle = 35.0;
  damagePerSec = 0.0;
  energyDrainPerSec = 0.0;
  segmentDivisions = 0;	
  numSegments = 1;
  beamWidth = 0.100;
  updateTime = 2000;
  skipPercent = 0.5;
  displaceBias = 0.15;
  lightRange = 3.0;
  lightColor = { 0.25, 0.25, 0.85 };
  soundId = SoundELFFire;
};

function ImRecLaserBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
//  Projectile::SpawnProjectile(TurretMissile, GameBase::GetMuzzleTransform(%shooterID), %shooterid, 0, %target);  
  %shooterID.LaunchAt=%target;
  echo(%shooterid@" locked on to "@%target);
}

ItemImageData ImRecLaserImage 
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 2;
  projectileType = ImRecLaserbeam;
  accuFire = true;
  minEnergy = 5;
  maxEnergy = 15;
  reloadTime = 1.0;
  lightType = 3;
  lightRadius = 1;
  lightTime = 1;
  lightColor = { 0.25, 1, 0.25 };
  sfxFire = SoundFireTargetingLaser;
  sfxActivate = SoundPickUpWeapon;
};

ItemData ImRecLaser 
{
  description = "Missle Guidance Laser";
  className = "Tool";
  shapeFile = "paintgun";
  hudIcon = "targetlaser";
  heading = $InvHead[ihWea];
  shadowDetailMask = 4;
  imageType = ImRecLaserImage;
  price = 1;
  showWeaponBar = false;
};

function ImRecLaserImage::OnFire(%player,%slot)
{
  echo("OnFire: "@%player@","@%slot);
  GameBase::GetLOSInfo(%player,1000);
  echo("Targeting Object: "@$LOS::Object@"  "@GameBase::GetDataName($LOS::Object));
}

function ImRecLaserImage::OnActivate(%player)
{  
  echo("OnActivate: " @ %player);  
  GameBase::GetLOSInfo(%player,1000);   
  echo("Targeting Object: "@$LOS::Object@"  "@GameBase::GetDataName($LOS::Object));
  %player.launchat = $LOS::Object;
}

function ImRecLaserImage::OnDeactivate(%player)
{  
  echo("OnDeactivate: " @ %player);  
  GameBase::GetLOSInfo(%player,1000);   
  echo("Targeting Object: "@$LOS::Object@"  "@GameBase::GetDataName($LOS::Object));
//  if ($LOS::Object=%player.launchat)
  Projectile::SpawnProjectile(TurretMissile,GameBase::GetMuzzleTransform(%player),%player,0,%player.launchat);
}


ItemImageData ImRecLauncherImage
{
  shapeFile = "mortargun";
  mountPoint = 2;
  weapontype = 2;
  mountoffset={ -0.43, -0.1, 0.3 };
  mountRotation = { 0.05, 0, 0 };
  firstPerson = true;
};

ItemData ImRecLauncher
{
  description = "Tracker Missiles";
  shapeFile = "mortargun";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = ImRecLauncherImage;
  price = 0;
  hudIcon = "mortar";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function ImRecLauncher::onUse(%player,%item) 
{
  echo("ImRec::OnUse("@%player@","@%item@")");
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else
  {
    Player::unmountItem(%player,$BackpackSlot);
    Player::unmountItem(%player,$WeaponSlot);
    Player::setitemcount(%player,ImRecLauncher,0);
    Player::setitemcount(%player,ImRecPack,1);
    Player::mountitem(%player,ImRecPack,$BackpackSlot);
    if (%player.prevweapon>"0")
      Player::mountitem(%player,%player.prevweapon,$WeaponSlot);
    else
      Player::unmountitem(%player,$WeaponSlot);
  }
}

ItemImageData ImRecPackImage 
{
  shapeFile = "mortargun";
  mountPoint = 2;
  weapontype = 2;
  mountoffset={ 0, -0.05, 0 };
  mountRotation = { 3.141592/2, 0, 0 };
  firstPerson = false;
};

ItemData ImRecPack 
{
  description = "Tracker Missiles";
  shapeFile = "mortargun";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = ImRecPackImage;
  price = 500;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function ImRecPack::onMount(%player,%item) 
{
  echo("ImRec::OnMount("@%player@","@%item@")");
}

function ImRecPack::onUnmount(%player,%item) 
{
  echo("ImRec::OnUnMount("@%player@","@%item@")");
}

function ImRecPack::onUse(%player,%item) 
{
  echo("ImRec::OnUse("@%player@","@%item@")");
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else
  {
    %player.prevweapon=Player::getmounteditem(%player,$WeaponSlot);
    Player::unmountItem(%player,$BackpackSlot);
    Player::setitemcount(%player,ImRecLauncher,1);
    Player::setitemcount(%player,ImRecLaser,1);
    Player::setitemcount(%player,ImRecPack,0);
    Player::mountitem(%player,ImRecLauncher,$BackpackSlot);
    Player::mountitem(%player,ImRecLaser,$WeaponSlot);
  }
}

function ImRecPack::onActivate(%player,%imageSlot) 
{
  echo("ImRec::onActivate("@%player@","@%imageSlot@")");
}

function ImRecPack::onDeActivate(%player,%imageSlot) 
{
  echo("ImRec::onDeActivate("@%player@","@%imageSlot@")");
}

function ImRecPack::onDrop(%player,%item) 
{
  echo("ImRec::OnDrop("@%player@","@%item@")");
  if($matchStarted) 
  {
    Item::onDrop(%player,%item);
  }
}
ItemImageData PhotonPackImage 
{
  shapeFile = "mortargun";
  mountPoint = 2;
  weapontype = 2;
  mountoffset={ 0, -0.05, 0 };
  mountRotation = { 3.141592/2, 0, 0 };
  firstPerson = false;
};

ItemData PhotonPack 
{
  description = "Vortex Missile";
  shapeFile = "mortargun";
  className = "Backpack";
  heading = $InvHead[ihBac];
  shadowDetailMask = 4;
  imageType = PhotonPackImage;
  price = 500;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function PhotonPack::onUse(%player,%item) 
{
  echo(%item@" "@Player::getMountedItem(%player,$BackpackSlot));
  if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
  {
    Player::mountItem(%player,%item,$BackpackSlot);
  }
  else
  {
    Player::unmount(%player,$BackpackSlot);
    Player::SetItemCount(%player,PhotonPack,0);
    %client=Player::GetClient(%player);
    Projectile::SpawnProjectile(PhotonTorpedo, GameBase::GetMuzzleTransform(%player), %player, 0, %client.LaunchAt);  
    echo(%player@" fired at "@%player.launchat);
  }
}
function PhotonPack::onDrop(%player,%item) 
{
  echo("ImRec::OnDrop("@%player@","@%item@")");
  if($matchStarted) 
  {
    Item::onDrop(%player,%item);
  }
}
