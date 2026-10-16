//Lurker Morph pack, Hydra
$InvList[LurkerPack] = 1;
$RemoteInvList[LurkerPack] = 1;
$VehicleInvList[LurkerPack] = 1;

ItemImageData LurkerPackImage 
{
  shapeFile = "mortarpack";
  mountPoint = 2;
  weaponType = 0;
//  projectileType = lightningCharge;
  minEnergy = 2;
  maxEnergy = 0;
  reloadTime = 0.2;
};

ItemData LurkerPack 
{
  description = "Lurker Morph";
  shapeFile = "shieldPack";
  className = "Backpack";
  heading = $InvHead[ihPsi];
  shadowDetailMask = 4;
  imageType = LurkerPackImage;
  price = 500;
  hudIcon = "shieldpack";
  showWeaponBar = true;
  hiliteOnActive = true;
};

function LurkerPackImage::onUse(%player,%imageSlot)
{
  %client = Player::getClient(%player);
  Client::sendMessage(Player::getClient(%player),1,"Lurker Morph started, please wait for metamorphosis to complete.");
  Player::setArmor(%client,parmor);
  %armor = Player::getArmor(%client);
  armorChange(%client);
//  Player::setItemCount(%client, $ArmorName[%armor], 0);
  checkMaxDrop(%client,%armor);
//  Player::dropItem(%client,Player::getMountedItem(%client,$WeaponSlot));
  schedule ("Player::setArmor(" @ %client @ ",armorKickAss);", 30);
  schedule ("armorChange(%client)", 30);
//  schedule ("Player::setItemCount(%client, parmor, 0)", 30);
  schedule("Player::setItemCount(%client, SBarrage, 1)", 30);
  schedule("Player::setItemCount(%client, BloodLust, 1)", 30);
  schedule("Player::setItemCount(%client, BloodLustAmmo, 100)", 30);
  schedule("Player::setItemCount(%client, Burrow, 1)", 30);
  schedule("Player::setItemCount(%client, BurrowAmmo, 5)", 30);
}

function LurkerPackImage::onDeactivate(%player,%imageSlot) 
{
//
}
