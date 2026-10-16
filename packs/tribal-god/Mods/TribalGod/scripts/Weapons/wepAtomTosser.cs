ItemData ATosserAmmo {
	description = "ATosser Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData ATosserImage {
	shapeFile   = "grenadeL";
	mountPoint  = 0;
	mountOffset = { -0.1, 0, 0 };
	mountRotation = { 0, -1.85, 0};
	weaponType  = 0; 
	reloadTime  = 0.25;
	fireTime    = 0.1;
	minEnergy   = 5;
	maxEnergy   = 6;
	ammoType    = ATosserAmmo;
	accuFire    = true;
	sfxFire	    = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload   = SoundMortarReload;
};

ItemData ATosser {
	heading   = $InvHeading[BulletWeapons];
	description = "Atom Tosser";
	classname = "Weapon";
	shapeFile = "GrenadeL";
	hudIcon	  = "sensorjamerpack";
	shadowDetailMask = 4;
	imageType = ATosserImage;
	price     = 350;
	showWeaponBar = true;
};

// Some of this code was borrowed from plasmatic's gord.
function ATosserImage::onFire(%player, %slot){
	%client = Player::getClient(%player);
	%ammo = Player::getItemCount(%player, ATosserAmmo);
	if(%ammo > 0){
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player, 800)){
			%dist = Vector::getDistance(GameBase::getPosition(%player), $los::position);
			if(%dist == 0)
			{ %time = -0.05; }
			else
			{ %time = (%dist / 180) + 0.25; }
			%obj = Projectile::spawnProjectile(AtomShell, %trans, %player, %vel);
			Schedule("ScatterBombs("@ %player @", "@ %client @", "@ %obj @");", %time, %obj);
		}
		else
		{
			%obj = Projectile::spawnProjectile(AtomShell, %trans, %player, %vel);
			Schedule("ScatterBombs("@ %player @", "@ %client @", "@ %obj @");", 2);
		}
		Player::decItemCount(%player, $WeaponAmmo[ATosser]);
	}
}