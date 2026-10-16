//------------------------------------|
// Author: {-o-} Plasmatic
// Modified By: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemData TankShredderAmmo {
	description = "Tank Shredder Ammo";
	className = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 35;
};

ItemImageData TankShredderImage {
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { 0, -0.351, 0 };
	mountRotation = { 0, -1.01, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 5;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickupWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};
ItemData TankShredder {
	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "fear";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = TankShredderImage;
	price = 1000;
	showWeaponBar = true;
};

ItemImageData TankShredder2Image {
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.21, -0.351, 0 };
	mountRotation = { 0, 1.01, 0};
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 5;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickupWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};
ItemData TankShredder2 {
	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder2Image;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData TankShredder3Image {
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = { -1.3051, -0.201, 0.251 };
	mountRotation = { 0, 1.501, 0 };
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 5;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundPickupWeapon;
	sfxFire = SoundFireChaingun;
};
ItemData TankShredder3 {
	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder3Image;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData TankShredder4Image {
	shapeFile = "chaingun";
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 };
	mountRotation = { 0, -1.501, 0}; 
	weaponType = 1;
	reloadTime = 0;
	spinUpTime = 0.1;
	spinDownTime = 5;
	fireTime = 0.1;
	ammoType = TankShredderAmmo;
	projectileType = ShredderBullet;
	accuFire = true;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };
	sfxActivate = SoundPickupWeapon;
	sfxFire = SoundFireChaingun;
};
ItemData TankShredder4 {
	description = "Tank Shredder";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
	shadowDetailMask = 4;
	imageType = TankShredder4Image;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

function TankShredderImage::onFire(%player, %slot){
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	Projectile::spawnProjectile("ShredderBullet", %trans, %player, %vel, %player);
	if(!$FiringTankShredder[%client]) CheckTankShredder(%client, %player);
	if($TG::InfiniteAmmo:TankShredder != true) Player::decItemCount(%player,$WeaponAmmo[TankShredder], 0.5);
}

function TankShredderImage::spawnProjectile(%player){
	%client = GameBase::getOwnerClient(%player);
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player, $WeaponSlot) == "TankShredder")){
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Projectile::spawnProjectile("ShredderBullet", %trans, %player, %vel, %player);
		if($TG::InfiniteAmmo:TankShredder != true) Player::decItemCount(%player, $WeaponAmmo[TankShredder], 0.5);
	}
}

function TankShredder::onDrop(%player,%item){
	%state = Player::getItemState(%player, $WeaponSlot);
	if(%state != "Fire" && %state != "Reload"){
		Player::setItemCount(%player, TankShredder2, 0);
		Player::setItemCount(%player, TankShredder3, 0);
		Player::setItemCount(%player, TankShredder4, 0);
		Item::onDrop(%player, %item);
	}
}

function TankShredder::onMount(%player, %item){
	Player::mountItem(%player, TankShredder2, $XtraSlotA);
	Schedule("TankShredder::addMount("@ %player @");", 1.5);
}

function TankShredder::addMount(%player){
	%client = Player::getClient(%player);
	if(Player::getMountedItem(%client, 0) == TankShredder){
		Player::mountItem(%player, TankShredder3, $XtraSlotB);
		Player::mountItem(%player, TankShredder4, $XtraSlotC);
	}
}

function TankShredder::onUnmount(%player, %imageSlot){
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
}

function CheckTankShredder(%client, %player){
	if(Player::isTriggered(%player, $WeaponSlot) && (Player::getMountedItem(%player, $WeaponSlot) == "TankShredder")){
		Player::trigger(%player, $XtraSlotA,true);
		Player::trigger(%player, $XtraSlotB,true);
		Player::trigger(%player, $XtraSlotC,true);
		schedule("CheckTankShredder("@ %client @","@ %player @");", 0.1);
		$FiringTankShredder[%client] = true;
	}else{
		Player::trigger(%player, $XtraSlotA,false);
		Player::trigger(%player, $XtraSlotB,false);
		Player::trigger(%player, $XtraSlotC,false);
		$FiringTankShredder[%client] = false;
	}
}