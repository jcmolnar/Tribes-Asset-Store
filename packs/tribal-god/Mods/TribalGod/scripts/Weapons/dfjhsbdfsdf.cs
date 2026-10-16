// Item Data:
$WeaponAmmo[NDisc] = NDiscAmmo;

$ItemMax[larmor, NDisc]  = 1;
$ItemMax[marmor, NDisc]  = 1;
$ItemMax[harmor, NDisc]  = 1;
$ItemMax[lfemale, NDisc] = 1;
$ItemMax[mfemale, NDisc] = 1;

$ItemMax[larmor, NDiscAmmo]  = 250;
$ItemMax[marmor, NDiscAmmo]  = 325;
$ItemMax[harmor, NDiscAmmo]  = 800;
$ItemMax[lfemale, NDiscAmmo] = 250;
$ItemMax[mfemale, NDiscAmmo] = 325;

// Ammo:
ItemData NDiscAmmo {
	description="NDisc Ammo";
	classname="Ammo";
	shapeFile="mortarammo";
	heading="xAmmunition";
	shadowDetailMask=4;
	price=50;
};

ItemImageData NDiscImage {
	shapeFile = "breath"; 
	mountPoint = 0;
	mountOffset = { -1.2, 0, 0 };
	weaponType = 0; 
	reloadTime = 0.25;
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = NDiscAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemImageData NDisc1Image {
	shapeFile = "disc"; 
	mountPoint = 0;
	mountRotation = { 0,-1.57, 0 };
	weaponType = 0; 
	reloadTime = 0.25;
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemImageData NDisc2Image {
	shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0, 1.57, 0 }; 
	weaponType = 0; 
	reloadTime = 0.25; 
	fireTime = 0.1; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemImageData NDisc3Image {
	shapeFile = "disc"; 
	mountPoint = 0; 
	mountOffset = { -1.2, 0.08, 0.01 };
	mountRotation = { 0, 1.575, 0};
	weaponType = 0; 
	reloadTime = 0.25; 
	fireTime = 0.1; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemImageData NDisc4Image {
	shapeFile = "disc";
	mountPoint = 0; 
	mountOffset = { -1.2, 0.08, 0.01 };
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 0.25;
	fireTime = 0.1; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};
ItemData NDisc {
	description="Quad Disc";
	className="Weapon";
	shapeFile="disc";
	hudIcon="sensorjamerpack";
	heading=$InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType=NDiscImage;
	price=500;
	showWeaponBar=true;
};
ItemData NDisc1 {
	description="Quad Disc";
	className="Weapon";
	shapeFile="disc";
	hudIcon="sensorjamerpack";
	heading=$InvHeading[BulletWeapons];
	shadowDetailMask=4;
	imageType=NDisc1Image;
	price=450;
	showWeaponBar=false;
	showInventory=false;
};
ItemData NDisc2 {
	description="Quad Disc";
	className="Weapon";
	shapeFile="disc";
	shadowDetailMask=4;
	imageType=NDisc2Image;
	price=0;
	showWeaponBar=false;
	showInventory=false;
};
ItemData NDisc3 {
	description="Quad Disc";
	className="Weapon";
	shapeFile="disc";
	shadowDetailMask=4;
	imageType=NDisc3Image;
	price=0;
	showWeaponBar=false;
	showInventory=false;
}; 
ItemData NDisc4 {
	description="Quad Disc";
	className="Weapon";
	shapeFile="disc";
	shadowDetailMask=4;
	imageType=NDisc4Image;
	price=0;
	showWeaponBar=false;
	showInventory=false;
};

function NDiscImage::onFire(%player, %slot){
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[NDisc]);
	if(!%AmmoCount){ Client::sendMessage(%client, 0, "Quad Disc is out of ammo.~waccess_denied.wav"); return; }
	
	%clientId = Player::getClient(%player);
	%name = Client::getName(%clientId);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
	%vel = Item::getVelocity(%player);
	%pos = gamebase::getposition(%player);
	%rot = gamebase::getrotation(%player);
	%vec = Vector::getFromRot(%rot);
	%vec1 = getWord(%vec, 0);
	%vec2 = getWord(%vec, 1);
	%pos1 = getWord(%trans, 0);
	%pos2 = getWord(%trans, 1);
	%pos3 = getWord(%trans, 2);
	%pos4 = getWord(%trans, 3);
	%pos5 = getWord(%trans, 4);
	%pos6 = getWord(%trans, 5);
	%pos7 = getWord(%trans, 6);
	%pos8 = getWord(%trans, 7);
	%pos9 = getWord(%trans, 8);
	%pos10 = getWord(%trans, 9) + %vec2;
	%pos11 = getWord(%trans, 10) - %vec1;
	%pos12 = getWord(%trans, 11);
	%trans2 = %pos1 @" "@ %pos2 @" "@ %pos3 @" "@ %pos4 @" "@ %pos5 @" "@ %pos6 @" "@ %pos7 @" "@ %pos8 @" "@ %pos9 @" "@ %pos10 @" "@ %pos11 @" "@ %pos12;
	
	if(%clientId.ND == 1){
		Projectile::spawnProjectile("NDiscShell", %trans, %player, %vel);
		Schedule("Projectile::spawnProjectile(\"NDiscShell\", \""@ %trans @"\", "@ %player @", \""@ %vel @"\");", 0.45); // PORT: transform + velocity were not quoted (run-time syntax error, 2nd disc never fired)
		Player::Trigger(%player, 4, true);
		Player::Trigger(%player, 4, false);
		Player::Trigger(%player, 5, true);
		Player::Trigger(%player, 5, false);
		Player::decItemCount(%player, $WeaponAmmo[NDisc], 2);
		%clientId.ND = 0;
		return;
	}else if(%clientId.ND == "" || %clientId.ND == 0){
		Projectile::spawnProjectile("NDiscShell", %trans2, %player, %vel);
		Schedule("Projectile::spawnProjectile(\"NDiscShell\", \""@ %trans2 @"\", "@ %player @", \""@ %vel @"\");", 0.35); // PORT: same
		Player::Trigger(%player, 6, true);
		Player::Trigger(%player, 7, true);
		Player::Trigger(%player, 6, false);
		Player::Trigger(%player, 7, false);
		%clientId.ND = 1;
	}
}

function NDisc::onDrop(%player,%item){
	%state = Player::getItemState(%player, $WeaponSlot);
	if(%state != "Fire" && %state != "Reload"){
		Player::setItemCount(%player, NDisc1, 0);
		Player::setItemCount(%player, NDisc2, 0);
		Player::setItemCount(%player, NDisc3, 0);
		Player::setItemCount(%player, NDisc4, 0);
		Item::onDrop(%player, %item);
	}
}

function NDisc::onMount(%player, %item){
	Player::mountItem(%player, NDisc1, 4);
	Player::mountItem(%player, NDisc2, 5);
	Player::mountItem(%player, NDisc3, 6);
	Player::mountItem(%player, NDisc4, 7);
}

function NDisc::onUnmount(%player, %imageSlot){
	Player::unmountItem(%player, 4);
	Player::unmountItem(%player, 5);
	Player::unmountItem(%player, 6);
	Player::unmountItem(%player, 7);
}