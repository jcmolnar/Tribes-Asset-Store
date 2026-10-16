//alternating weapon firings by Annihilation, altered by Crow! to eliminate things that became uneccesary due to it no longer being a disc weapon, and added the railgun lockon

$InvList[HDiscLauncher] = 1;
$MobileInvList[HDiscLauncher] = 1;
$RemoteInvList[HDiscLauncher] = 1;

$InvList[HDiscLauncherAmmo] = 1;
$MobileInvList[HDiscLauncherAmmo] = 1;
$RemoteInvList[HDiscLauncherAmmo] = 1;

$AutoUse[HDiscLauncher] = false;
$WeaponAmmo[HDiscLauncher] = HDiscLauncherAmmo; 
$SellAmmo[HDiscLauncherAmmo] = 5;

addWeapon(HDiscLauncher);
addAmmo(HDiscLauncher,HDiscLauncherAmmo,5);

ItemData HDiscLauncherAmmo
{
	description = "Railgun2 Ammo";
	className = "Ammo";
	shapeFile = "discammo";
	heading = $InvHead[ihAmm];
	shadowDetailMask = 4;
	price = 4;
}; 

ItemImageData HDiscLauncher1Image 
{
	mountOffset = { -0.25, 0.0, 0.0 };
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	ammoType = HDiscLauncherAmmo;
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0.0, 0.0, 1.0 };
	sfxFire = SoundMissileTurretFire;
};

ItemData HDiscLauncher1
{
	description = "Railgun 2";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncher1Image;
	price = 450;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HDiscLauncher2Image
{
	mountOffset = { 0.0, 0.0, 0.0 };
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	ammoType = HDiscLauncherAmmo;
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.5;
	lightType = 3;
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 0.0, 0.0, 1.0 };
	sfxFire = SoundMissileTurretFire;
};

ItemData HDiscLauncher2
{
	description = "Railgun 2";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "disk";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncher2Image;
	price = 450;
	showWeaponBar = false;
	showInventory = false;
};

ItemImageData HDiscLauncherImage
{
	shapeFile = "breath";
	mountPoint = 0;
	weaponType = 0;
	ammoType = HDiscLauncherAmmo;
	accuFire = true;
	reloadTime = 0.2;
	fireTime = 0.6;
	lightType = 3;
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 0.0, 0.0, 1.0 };
	sfxActivate = SoundPickUpWeapon;
};

ItemData HDiscLauncher 
{
	description = "Railgun 2";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = HDiscLauncherImage;
	price = 460;
	showWeaponBar = true;
};

function HDiscLauncherImage::onFire(%player, %slot)
{ 		
//They need to have enough energy and ammo
%energy = GameBase::getEnergy(%player);
if(%energy >= 10)
 {
   if(player::getItemCount(%player, HdiscLauncherAmmo) > 0)
   {

	if($debug)
		echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));		

	%client = GameBase::getOwnerClient(%player);

	if(%client.hd == 0)
	{
		%client.hd = 1;
		Player::trigger(%player,6,true);
		Player::trigger(%player,6,false);
 	}
	else
	{
		%client.hd = 0;
		Player::trigger(%player,7,true);
		Player::trigger(%player,7,false);
	}
   }
 }
}

function HDiscLauncher::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));	

	Player::mountItem(%player,HDiscLauncher1,6);
 	Player::mountItem(%player,HDiscLauncher2,7);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		Bottomprint(%clientId, "<jc>Railgun 2: <f2>The Destroyer can mount two railguns, doubling the firing rate.  Possibly the best anti aircraft weapon avaliable.  Requires a small amount of energy.");
}

function HDiscLauncher::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,6);
 	Player::unmountItem(%player,7);
}

function HDiscLauncher1Image::onFire(%player, %slot)
{
if($debug)
	echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);

%player.CrowRailGunShooting = true;
%obj = Projectile::spawnProjectile("Railgun2Lockon",%trans,%player,%vel);
schedule("deleteobject("@%obj@");",0.1);
}

function HDiscLauncher2Image::onFire(%player, %slot)
{
if($debug)
	echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	

%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);

%player.CrowRailGunShooting = true;
%obj = Projectile::spawnProjectile("Railgun2Lockon",%trans,%player,%vel);
schedule("deleteobject("@%obj@");",0.1);
}

function RailGun2LockOn::damageTarget(%targetPl, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterPl)
{
//Tricky! %shooterpl is actually the CLIENT, even though %targetPl is the player.. thank you, dynamix..

	%shooterTeam = GameBase::getTeam(%shooterPl);
	%targetTeam = GameBase::getTeam(%targetPl);

//The only thing that railgun can lock onto of its own team is a vehicle (in case it was hijacked)
	if(%shooterTeam == %targetTeam && getobjectType(%TargetPl) != "Flier")
		return;

//set things right
	%shooterPl = client::getownedobject(%shooterpl);
	if(%shooterPl.CrowRailGunShooting == false)
		return;
	%shooterPl.CrowRailGunShooting = false;
	GameBase::setEnergy(%shooterPl, gamebase::getenergy(%shooterPl) - 11);
	Player::decItemCount(%shooterPl, $WeaponAmmo[HDiscLauncher]);
	%trans = gamebase::getmuzzletransform(%shooterPl);
	%vel = item::getvelocity(%shooterPl);

	projectile::spawnProjectile("RailCurve", %trans, %ShooterPl, %vel, %targetPl);
}