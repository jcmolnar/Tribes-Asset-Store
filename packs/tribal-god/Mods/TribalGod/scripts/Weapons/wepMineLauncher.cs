//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|
ItemData MineLauncherAmmo {	
	description = "MineLauncher ammo"; 
	className = "Ammo"; 
	shapeFile = "grenammo"; 
	heading = "xAmmunition"; 
	shadowDetailMask = 4; 
	price = 2;
};
ItemImageData MineLauncherImage {	
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = MineLauncherAmmo;
	accuFire = true;
	reloadTime = 0.8;
	fireTime = 0.08;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPickUpWeapon;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};
ItemData MineLauncher {	
	description = "MineLauncher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 150;
	showWeaponBar = true;
};
function MineLauncherImage::onFire(%player, %slot){
	if(!Player::getItemCount(%player, $WeaponAmmo[MineLauncher])) return;
	%clientId = Player::getClient(%player);
	%fired.deployer = %player;
	%vel = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%armor = Player::getArmor(%player);
	if($WeaponMode[%clientId, MineLauncher] == "Tranq_Grenade"){
		if(!%clientId.coolingGun){
			%player.team = GameBase::getTeam(%clientId);
			%newObj = Projectile::spawnProjectile("MinerShell", %trans, %player, %vel);
			schedule("SplitExplosion("@ %newObj @", "@ %player @");", 2.8);
			schedule("TG::TossMines("@ %newObj @", "@ %player @", 10, true, \"EMPgrenshl\");", 3.0);
			CoolGun(%clientId, 4);
			Schedule("Client::sendMessage("@ %clientId @", 3, \"Blast Shell Is Ready.~wbuysellsound.WAV\");", 4);
		}else if(%clientId.coolingGun){
			Player::trigger(%player, 0, false);
			Client::sendMessage(%clientId, 1, "Re Packing Blast Shell...~wSensor_Deploy.wav");
		}
	}
	else if($WeaponMode[%clientId, MineLauncher] == "BurstMine_Grenade"){
		if(!%clientId.coolingGun){
			%player.team = GameBase::getTeam(%clientId);
			%newObj = Projectile::spawnProjectile("MinerShell", %trans, %player, %vel);
			Schedule("SplitExplosion(" @ %newObj @ ", " @ %player @ ");", 2.8);
			Schedule("TG::TossMines("@ %newObj @", "@ %player @", 10, true, \"MineFloaters\", true);", 3.0);
			CoolGun(%clientId, 3);
			Schedule("Client::sendMessage("@ %clientId @", 3, \"Mine Shell Is Ready.~wbuysellsound.WAV\");", 3);
		}else{
			Player::trigger(%player, 0, false);
			Client::sendMessage(%clientId, 1, "Re Packing Mine Shell...~wSensor_Deploy.wav");
		}
	}
	else if($WeaponMode[%clientId, MineLauncher] == "Light_Grenade"){
		%fired = Projectile::spawnProjectile("EMPgrenshl", %trans, %player, %vel);
		%fired.deployer = %client;
	}
	else if($WeaponMode[%clientId, MineLauncher] == "RadiusMine"){
		%obj = newObject("", "Mine", "Radius_Mine");
		GameBase::throw(%obj,%player,20,false);
		addToSet("MissionCleanup", %obj);
		%pos = GameBase::getPosition(%player);
		GameBase::setPosition(%obj, %pos);
		%obj.deployer = %client;
		GameBase::setTeam (%obj, GameBase::getTeam(%player));
	}
	else if($WeaponMode[%clientId, MineLauncher] == ""){
		%obj = newObject("","Mine","TG::ClayMorMine");
		GameBase::setTeam(%obj, GameBase::getTeam(%player));
		GameBase::throw(%obj,%player,20,false);
		addToSet("MissionCleanup", %obj);
		%pos = GameBase::getPosition(%player);
		GameBase::setPosition(%obj, %pos);
		%obj.deployer = %client;
	}
	if($TG::InfiniteAmmo:MineLauncher != true) Player::decItemCount(%player, $WeaponAmmo[MineLauncher], 1);
}