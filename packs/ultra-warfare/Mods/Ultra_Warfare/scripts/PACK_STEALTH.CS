//================================================================
//Stealth shield Pack
//================================================================
$ItemMax[larmor, StealthShieldPack] = 1;
$ItemMax[lfemale, StealthShieldPack] = 1;
$ItemMax[marmor, StealthShieldPack] = 1;
$ItemMax[mfemale, StealthShieldPack] = 1;
$ItemMax[harmor, StealthShieldPack] = 1;
//================================================================
$InvList[StealthShieldPack] = 1;
$RemoteInvList[StealthShieldPack] = 1;
//================================================================
SoundData SoundStealthOn
{
   wavFileName = "pack_stealthon.wav";
   profile = Profile3dNear;
};
//=======================================
ItemImageData StealthShieldPackImage
 {
 shapeFile = "pack_stealth";
 mountPoint = 2;
 weaponType = 2;
 minEnergy = 10;
 maxEnergy = 6;
 sfxFire = SoundStealthOn;
 firstPerson = false;
 };
 ItemData StealthShieldPack
 {
 description = "Stealth Shield Pack";
 shapeFile = "pack_stealth";
 className = "Backpack";
 heading = "gUtility Packs";
 shadowDetailMask = 4;
 imageType = StealthShieldPackImage;
 price = 0;
 hudIcon = "shieldpack";
 showWeaponBar = true;
 hiliteOnActive = true;
 };
 function StealthShieldPackImage::onActivate(%player,%imageSlot)
 {
 Client::sendMessage(Player::getClient(%player),0,"StealthShield On");
 %player.shieldStrength = 0.036;
 %rate = Player::getSensorSupression(%player) + 20;
 Player::setSensorSupression(%player,%rate);
 }
 function StealthShieldPackImage::onDeactivate(%player,%imageSlot)
 {
 Client::sendMessage(Player::getClient(%player),0,"StealthShield Off");
 Player::trigger(%player,$BackpackSlot,false);
 %player.shieldStrength = 0;
 %rate = Player::getSensorSupression(%player) - 20;
 Player::setSensorSupression(%player,%rate);
 }

//================================================================