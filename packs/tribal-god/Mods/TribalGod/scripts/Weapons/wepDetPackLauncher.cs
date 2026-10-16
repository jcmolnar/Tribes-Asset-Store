//------------------------------------|
// Author: [TG]-X-Ecutioner ©
// Email: dustin84@tribal-gods.com
// Aim: Dustin8420
//------------------------------------|

ItemData DetPackLauncherAmmo 
{	
	description = "DetPackLauncher ammo"; 
	className   = "Ammo"; 
	shapeFile   = "grenammo"; 
	heading     = "xAmmunition"; 
	shadowDetailMask = 4; 
	price            = 10;
};
ItemImageData DetPackLauncherImage 
{	
	shapeFile = "grenadeL";
	mountPoint = 0;
	weaponType = 0;
	ammoType = DetPackLauncherAmmo;
	accuFire = false;
	reloadTime = 1.0;
	fireTime = 0.05;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundPickUpWeapon;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};
ItemData DetPackLauncher 
{	
	description = "DetPack Launcher";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
	heading = $InvHeading[BulletWeapons];
	shadowDetailMask = 4;
	imageType = DetPackLauncherImage;
	price = 150;
	showWeaponBar = true;
};

function DetPackLauncherImage::onFire(%player, %slot){
	%Ammo = Player::getItemCount(%player, $WeaponAmmo[DetPackLauncher]);
	%playerId = Player::getClient(%player);
	if(!%Ammo) return;
	%fired.deployer = %player;
	%client = GameBase::getOwnerClient(%player);
	%vel = Item::getVelocity(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%armor = Player::getArmor(%player);
	%clientId = Player::getclient(%player);
	
	%obj = newObject("", "Mine", "Suicidebomb2");
	GameBase::throw(%obj, %player, 10, false);
	addToSet("MissionCleanup", %obj);
	%pos = GameBase::getPosition(%player);
	GameBase::setPosition(%obj, %pos);
	%obj.deployer = %client;
	GameBase::setTeam (%obj,GameBase::getTeam (%client));
	Client::sendMessage(%playerId,1,"20 Seconds untill detonation");
	Schedule("CheckDetonated("@ %client @");", 15);
	Player::decItemCount(%player,$WeaponAmmo[DetPackLauncher], 1);
}

function CheckDetonated(%playerId){
	if(!%playerId.fuckedup){
		BottomPrint(%playerId, "<jc><f1>5 <f0>Seconds Untill Detonation");
		Schedule("BottomPrint("@ %playerId @", \"<jc><f1>There she blows!\");", 5);
		Schedule("Client::sendMessage("@ %playerId @", 0, \"~wBXplo4.wav\");", 5);
		Schedule("Client::sendMessage("@ %playerId @", 0, \"~wBXplo1.wav\");", 5);
	}
}