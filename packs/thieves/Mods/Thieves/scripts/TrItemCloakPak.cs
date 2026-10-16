ItemImageData CloakPackImage
{
shapeFile = "shieldPack";
mountPoint = 2;
weaponType = 2; 
maxEnergy = 11; 
sfxFire = SoundShieldOn;
firstPerson = false;
};
ItemData CloakPack
{
description = "Cloaking Pack";
shapeFile = "shieldPack";
className = "Backpack";
heading = "iBackpacks";
shadowDetailMask = 4;
imageType = CloakPackImage;
price = 250;
hudIcon = "shieldpack";
showWeaponBar = true;
hiliteOnActive = true;
};
function CloakPackImage::onActivate(%player,%imageSlot)
{
Client::sendMessage(Player::getClient(%player),0,"Cloaking On");
GameBase::startFadeOut(%player);
%rate = Player::getSensorSupression(%player) + 20;
Player::setSensorSupression(%player,%rate);
}
function CloakPackImage::onDeactivate(%player,%imageSlot)
{
Client::sendMessage(Player::getClient(%player),0,"Cloaking Off");
GameBase::startFadeIn(%player);
%rate = Player::getSensorSupression(%player) - 20;
Player::setSensorSupression(%player,%rate);
Player::trigger(%player,$BackpackSlot,false);
}
