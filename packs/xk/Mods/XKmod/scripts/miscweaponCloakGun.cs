$InvList[CloakGun] = 1; //Cloak Gun Made by Neo, Modified by King Shit.
$RemoteInvList[CloakGun] = 1;
$AutoUse[CloakGun] = True;
$WeaponAmmo[CloakGun] = "";

addWeapon(CloakGun);

ItemImageData CloakGunImage
{
  shapeFile = "paintgun";
  mountPoint = 0;
  weaponType = 0;
  minEnergy = 0;
  maxEnergy = 0;
  projectileType = "";
  accuFire = true;
  sfxActivate = SoundEnergyWhirl;
};

ItemData CloakGun
{
  description = "HH-Cloak Gun";
  className = "Tool";
  shapeFile = "paintgun";
  hudIcon = "energypack";
  heading = "bMisc. Weapons";
  shadowDetailMask = 4;
  imageType = CloakGunImage;
  price = 50;
  showWeaponBar = true;
};

function CloakGun::onMount(%player,%item) 
{
   GameBase::startFadeout(%player);
   %client = Player::getClient(%player);
   Bottomprint(%client, "<jc><f2>HH-Cloak Gun.");
  Client::sendMessage(Player::getClient(%player),0,"Cloaking On");
  %rate = Player::getSensorSupression(%player) + 20;
  Player::setSensorSupression(%player,%rate);
}

function CloakGun::onUnmount(%player,%item) 
{
   GameBase::startFadein(%player);
  Client::sendMessage(Player::getClient(%player),0,"Cloaking Off");
  %rate = Player::getSensorSupression(%player) - 20;
  Player::setSensorSupression(%player,%rate); 
}
//----------
