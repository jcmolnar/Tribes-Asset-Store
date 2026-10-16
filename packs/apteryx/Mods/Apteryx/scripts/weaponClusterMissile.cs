$InvList[OSLauncher] = 1;
$MobileInvList[OSLauncher] = 1;
$RemoteInvList[OSLauncher] = 1;

$InvList[OSAmmo] = 1;
$MobileInvList[OSAmmo] = 1;
$RemoteInvList[OSAmmo] = 1;

$AutoUse[OSLauncher] = false;
$SellAmmo[OSAmmo] = 3;
$WeaponAmmo[OSLauncher] = OSAmmo;

addWeapon(OSLauncher);
addAmmo(OSLauncher, OSAmmo, 1);

ItemData OSAmmo 
{
	description = "Cluster Missiles";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "rocket";
	shadowDetailMask = 4;
	price = 25;
};

ItemImageData OSLauncherImage
{
	shapeFile = "grenadel";
	ammoType = OSAmmo;
	mountPoint = 0;
	mountRotation = { 0, 3.1416, 0 };
	weaponType = 0; // Single Shot
	minEnergy = 15;
	maxEnergy = 15;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 7.5;
	lightTime = 1.5;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireFlierRocket;
	sfxActivate = SoundPickUpWeapon;
};

ItemData OSLauncher 
{
	description = "Cluster Missile Launcher";
	className = "Weapon";
	shapeFile = "grenadel";
	hudIcon = "fear";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = OSLauncherImage;
	price = 500;
	showWeaponBar = true;
};

function OSLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Cluster Missile Launcher : Part 2: <f2>REQUIRES SCORPION WITH SPOTTER LASER. You shoot first, then the scorpion spots a location or person, and the poor target is soon pummeled with missiles.  Without scorpion to spot, this is akward and weak.");
}

//CrowNumMissiles keeps track of how large CrowMissileArray is.  CrowMissileArray holds all the missiles that exist. 
$CrowNumMissiles = 0;
$CrowMissileArray[0] = 0;
$CrowOwnerArray[0] = 0;

function OSLauncherImage::onFire(%player,%slot)
{		
	player::decitemcount(%player, OSAmmo);
	%trans = gamebase::getmuzzletransform(%player);
	%vel = item::getvelocity(%player);
	%obj = Projectile::SpawnProjectile("ClusterMom", %trans, %player, %vel, %player);
	$CrowMissileArray[$CrowNumMissiles] = %obj;
	$CrowOwnerArray[$CrowNumMissiles] = %player;
	$CrowNumMissiles++;
	%obj.IsClusterMissile = true;
//CrowMissileArray is now increased in size by one, and the new element points to the new object. CrowOwnerArray can now identify who the original shooter was.
}
//The rest of the missile shooting occurs when the spotter spots, so see spottinglaser file.

function ClusterFast::updateTargetPercentage(%target)
{
	return 1;
}
function ClusterMedium::updateTargetPercentage(%target)
{
	return 1;
}
function ClusterSlow::updateTargetPercentage(%target)
{
	return 1;
}
