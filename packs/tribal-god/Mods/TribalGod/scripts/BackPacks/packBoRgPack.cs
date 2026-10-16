$BoRgSlotA = $DefaultSlot;
$BoRgSlotB = $XtraSlotD;

ItemImageData BoRgItem1Image
{
	shapeFile = "mortargun";
	mountPoint = 0;
    mountOffset = { -0.95, 0.35, 0.15 };
	weaponType = 2;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;
};
ItemData BoRgItem1
{
	description = "BattlePack Advanced";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
    heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = BoRgItem1Image;
	price = 375;
	showWeaponBar = false;
    validateShape = false;
};
ItemImageData BoRgItem2Image
{
	shapeFile = "sensorjampack";
	mountPoint = 2;
	weaponType = 2;
	maxEnergy = 0.1;
	sfxFire = SoundJammerOn;
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};
ItemData BoRgItem2
{
	description = "BattlePack Advanved";
	shapeFile = "sensorjampack";
	className = "Backpack";
	heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = BoRgItem2Image;
	price = 600;
	hudIcon = "sensorjamerpack";
	showWeaponBar = false;
	hiliteOnActive = true;
};
ItemImageData BoRgDeviceImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0.15, 0.35, 0.15 };
	weaponType = 2;
	maxEnergy = 0.1;
	firstPerson = true;
};
ItemData BoRgDevice
{
	description = "BattlePack Advanved";
	shapeFile = "mortargun";
	className = "Backpack";
	heading = $InvHeading[BackPacks];
	shadowDetailMask = 4;
	imageType = BoRgDeviceImage;
	price = 600;
	hudIcon = "mortar";
	showWeaponBar = false;
	hiliteOnActive = false;
};
function BoRgDevice::onMount(%player, %item) 
{	
	Player::mountItem(%player, BoRgItem1, $BoRgSlotA);  
	Player::mountItem(%player, BoRgItem2, $BoRgSlotB);
	%player.shieldStrength = 0.008;
	Player::setSensorSupression(%player,3);
	Player::trigger(%player,2,true);
}
function BoRgDevice::onUnmount(%player, %imageSlot) 
{
	Player::unmountItem(%player, $BoRgSlotA);
	Player::unmountItem(%player, $BoRgSlotB);
	%player.shieldStrength = 0;
	Player::setSensorSupression(%player, 0);
	Player::trigger(%player, 2, false);
}
function BoRgDevice::onDrop(%player, %item) 
{
	%state = Player::getItemState(%player, $WeaponSlot);
	if(%state != "Fire" && %state != "Reload") 
	{
		Player::setItemCount(%player, BoRgItem1, 0);
		Player::setItemCount(%player, BoRgItem2, 0);
		Item::onDrop(%player, %item);
		Player::trigger(%player, $BackpackSlot, false);
	}
}
function BoRgDeviceImage::onActivate(%player,%imageSlot)
{
	%clientId = Player::getClient(%player);
	%vel   = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%pos = gamebase::getposition(%player);
	%rot = gamebase::getrotation(%player);
	%vec = Vector::getFromRot(%rot);
	
	%vec1 = getWord(%vec,0);
	%vec2 = getWord(%vec,1);
	%pos1 = getWord(%trans,0);
	%pos2 = getWord(%trans,1);
	%pos3 = getWord(%trans,2);
	%pos4 = getWord(%trans,3);
	%pos5 = getWord(%trans,4);
	%pos6 = getWord(%trans,5);
	%pos7 = getWord(%trans,6);
	%pos8 = getWord(%trans,7);
	%pos9 = getWord(%trans,8);
	%pos10 = getWord(%trans,9) + %vec2;
	%pos11 = getWord(%trans,10) - %vec1;
	%pos12 = getWord(%trans,11);
	
	%trans2 = %pos1 @" "@ %pos2 @" "@ %pos3 @" "@%pos4@" "@ %pos5 @" "@ %pos6 @" "@ %pos7 @" "@ %pos8 @" "@ %pos9 @" "@ %pos10 @" "@ %pos11 @" "@ %pos12;
	if(%clientId.isSuperAdmin)
	{
		Projectile::spawnProjectile("AdminTankRocket", %trans2, %player, %vel);
		Projectile::spawnProjectile("AdminTankRocket", %trans, %player, %vel);
    }
    else if(!%clientId.isSuperAdmin)
    { 
        Projectile::spawnProjectile("NukeTurret", %trans2, %player, %vel);
        Projectile::spawnProjectile("NukeTurret", %trans, %player, %vel);
    }
    Player::trigger(%player,$BoRgSlotA,true);
    Client::sendMessage(%clientId, 0, "~wBXplo1.wav");
}
function BoRgDeviceImage::onDeactivate(%player,%imageSlot)
{
   %clientId = Player::getClient(%player);
   Player::trigger(%player, $BoRgSlotA, false);
   Client::sendMessage(%clientId, 0, "~wturretoff2.wav");
}