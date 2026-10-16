//================================================================
// Rocket launcher 
//================================================================



ItemImageData RocketLauncherImage
{
	shapeFile = "grenadel";
	mountPoint = 0;
	mountoffset = { 0, 0, -0.2 };
       mountrotation = { 0, 3, 0 };

	weaponType = 0; // Single Shot
	//projectileType = LiLFFBShell;
	accuFire = false;
	reloadTime = 0.07;
	fireTime = 0;
	minEnergy = 1;
	maxEnergy = 0.1;

	//lightType = 3;  // Weapon Fire
	//lightRadius = 2;
	//lightTime = 1;
	//lightColor = { 1, 0, 0 };

	sfxFire = SoundEMPfire;
                     sfxActivate = SoundPickUpWeapon;
};

ItemData RocketLauncher
{
	description = "Star Burster";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "plasma";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RocketLauncherImage;
	price = 50;
	//showWeaponBar = true;
	showinventory = true;
   //validateShape = true;
   validateMaterials = true;
};

function RocketLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	if(GameBase::getLOSInfo(%player,350)) 
	{ 
		%object = getObjectType($los::object); 
		if(%object == "Player" || %object == "Flier") 
		
		{  
		        RocketLockWarning(%client, $los::object, %object);
			Projectile::spawnProjectile("StripperONE",%trans,%player,%vel,$los::object);
			Projectile::spawnProjectile("StripperTWO",%trans,%player,%vel,$los::object);
		} else 
		        Projectile::spawnProjectile("Stripperalt",%trans,%player,%vel);
	} else 
                        Projectile::spawnProjectile("Stripperalt",%trans,%player,%vel);  
} 


	//=================================================================
echo("Payload Loaded");