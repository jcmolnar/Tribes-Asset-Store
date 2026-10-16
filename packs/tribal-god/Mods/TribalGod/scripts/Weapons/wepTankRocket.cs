RocketData TankRocket {
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 25;
	damageType = $LiLRocketDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 250;
	terminalVelocity = 250;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};
RocketData AdminTankRocket {
	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 1.0;
	damageClass = 1;
	damageValue = 50;
	damageType = $LiLRocketDamageType;
	explosionRadius = 5.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 275;
	terminalVelocity = 275;
	acceleration = 5.0;
	totalTime = 5.0;
	liveTime = 6.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 1.5;
	trailType = 2;
	trailString = "enex.dts";
	smokeDist = 25;
	soundId = SoundJetHeavy;
};

$TRocketLauncherSlotA = $XtraSlotA;
$TRocketLauncherSlotB = $XtraSlotB;
$TRocketLauncherSlotC = $XtraSlotC;

ItemData TRocketLauncherAmmo {
	description = "TRocketLauncher Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};
ItemImageData TRocketLauncherImage {
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	weaponType = 0; 
	reloadTime = 0.25;
	fireTime = 0.1;
	minEnergy = 5;	
	maxEnergy = 6;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};
ItemData TRocketLauncher {
	description = "Tank Rocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.346, 0.08, 0.01 }; 
	mountRotation = { 0, 1.575, 0 }; 
	hudIcon	= "sensorjamerpack";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4; 
	imageType = TRocketLauncherImage; 
	price = 2500; 
	showWeaponBar = true; 
};
ItemImageData TRocketLauncher2Image {
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.25; 
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
};
ItemData TRocketLauncher2 {
	description = "Tank Rocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	shadowDetailMask = 4; 
	imageType = TRocketLauncher2Image; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};
ItemImageData TRocketLauncher3Image {
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 0.25; 
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
};
ItemData TRocketLauncher3 {
	description = "Tank Rocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun";
	shadowDetailMask = 4;
	imageType = TRocketLauncher3Image;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};
ItemImageData TRocketLauncher4Image {
	shapeFile = "mortargun";
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 };
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 0.25;
	fireTime = 0.1;
	ammoType = TRocketLauncherAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	minEnergy = 5;	
	maxEnergy = 6;
};
ItemData TRocketLauncher4 {
	description = "Tank Rocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	shadowDetailMask = 4; 
	imageType = TRocketLauncher4Image; 
	price = 0; 
	showWeaponBar = false;
	showInventory = false; 
}; 

function TRocketLauncherImage::onFire(%player, %slot){
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[TRocketLauncher]);
	if(!%AmmoCount){ Client::sendMessage(%client, 0, "Tank RocketGun is out of ammo.~waccess_denied.wav"); return; }
	%client = GameBase::getOwnerClient(%player);
	%clientName = Player::getClient(%player);
	%clientId = Client::getName(%client);
	%trans = GameBase::getMuzzleTransform(%player);
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
	if(GameBase::getLOSInfo(%player, 3500)){	
		%object = getObjectType($los::object);
		%targeted = GameBase::getOwnerClient($los::object);
		if(%object == "Player" || %object == "Flier"){
			%targetP = Client::getName(%targeted);
			if(%client.isAdmin){
				Projectile::spawnProjectile("AdminTankMissile", %trans, %player, %vel, $los::object);
				Projectile::spawnProjectile("AdminTankMissile", %trans2, %player, %vel, $los::object);
			}else{
				Projectile::spawnProjectile("TankMissile", %trans, %player, %vel, $los::object);
				Projectile::spawnProjectile("TankMissile", %trans2, %player, %vel, $los::object);
			}
			Client::sendMessage(%client,0,"Tank Rocket Launcher lock acquired "@ %targetP @ "~wmine_act.wav");
			Client::sendMessage(%targeted,0,"Tank Rocket Launcher lock detected - " @ %clientId @ "~wono.wav");
			if(!$FiringTRocketLauncher[%client]){ CheckTRocketLauncher(%client, %player); }
			Player::decItemCount(%player,$WeaponAmmo[TRocketLauncher], 2);
		}else{
			if(%client.isGodAdmin){
				Projectile::spawnProjectile("AdminTankRocket", %trans, %player, %vel, %target);
				Projectile::spawnProjectile("AdminTankRocket", %trans2, %player, %vel, %target);
			}else{
				Projectile::spawnProjectile("TankRocket", %trans, %player, %vel, %target);
				Projectile::spawnProjectile("TankRocket", %trans2, %player, %vel, %target);
			}
			if(!$FiringTRocketLauncher[%client]){ CheckTRocketLauncher(%client, %player); }
			Player::decItemCount(%player, $WeaponAmmo[TRocketLauncher], 2);
		}
	}else{
		if(%clientId.isAdmin){
			Projectile::spawnProjectile("AdminTankRocket", %trans, %player, %vel, %target);
			Projectile::spawnProjectile("AdminTankRocket", %trans2, %player, %vel, %target);
		}else{
			Projectile::spawnProjectile("TankRocket", %trans, %player, %vel, %target);
			Projectile::spawnProjectile("TankRocket", %trans2, %player, %vel, %target);
		}
		if(!$FiringTRocketLauncher[%client]){ CheckTRocketLauncher(%client, %player); }
		Player::decItemCount(%player, $WeaponAmmo[TRocketLauncher], 2);
	}
}

function TRocketLauncher::onDrop(%player,%item){ %state = Player::getItemState(%player,$WeaponSlot); if(%state != "Fire" && %state != "Reload"){ Player::setItemCount(%player, TRocketLauncher2, 0); Item::onDrop(%player,%item); } }
function TRocketLauncher::onMount(%player,%item){ Player::mountItem(%player,TRocketLauncher2,$TRocketLauncherSlotA); Player::mountItem(%player,TRocketLauncher3,$TRocketLauncherSlotB); Player::mountItem(%player,TRocketLauncher4,$TRocketLauncherSlotC); }
function TRocketLauncher::onUnmount(%player,%imageSlot){ Player::unmountItem(%player,$TRocketLauncherSlotA); Player::unmountItem(%player,$TRocketLauncherSlotB); Player::unmountItem(%player,$TRocketLauncherSlotC); }
function CheckTRocketLauncher(%client, %player){
	if(Player::isTriggered(%player, $WeaponSlot) && (Player::getMountedItem(%player, $WeaponSlot) == "TRocketLauncher")){
		Player::trigger(%player, $TRocketLauncherSlotA, true);
		Player::trigger(%player, $TRocketLauncherSlotB, true);
		Player::trigger(%player, $TRocketLauncherSlotC, true);
		Schedule("CheckTRocketLauncher("@ %client @", "@ %player @");", 0.1); 
		$FiringTRocketLauncher[%client] = true;
	}else{
		Player::trigger(%player, $TRocketLauncherSlotA, false); 
		Player::trigger(%player, $TRocketLauncherSlotB, false); 
		Player::trigger(%player, $TRocketLauncherSlotC, false); 
		$FiringTRocketLauncher[%client] = false; 
	}
}