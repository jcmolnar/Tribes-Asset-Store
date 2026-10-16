$InvList[Railgun] = 1;
$MobileInvList[Railgun] = 1;
$RemoteInvList[Railgun] = 1;

$InvList[RailAmmo] = 1;
$MobileInvList[RailAmmo] = 1;
$RemoteInvList[RailAmmo] = 1;

$AutoUse[Railgun] = false;
$SellAmmo[RailAmmo] = 10;
$WeaponAmmo[Railgun] = "RailAmmo";

addWeapon(Railgun);
addAmmo(Railgun, RailAmmo, 2);

ItemData RailAmmo 
{
	description = "Railgun Bolt";
	className = "Ammo";
	heading = $InvHead[ihAmm];
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 4;
};

ItemImageData RailgunImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	weaponType = 0;	
	accuFire = true;
	ammoType = RailAmmo;
	reloadTime = 0.05;
	fireTime = 1.70;	
	lightType = 3;
	lightRadius = 6;
	lightTime = 1;
	lightColor = { 0.0, 0.0, 0.8 };
	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Railgun 
{
	description = "Railgun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = RailgunImage;
	price = 275;
	showWeaponBar = true;
};

ItemImageData Railgun2Image 
{
	shapeFile = "grenadeL";
	mountPoint = 0;	
	mountOffset = { 0, -0.2, 0 };
	mountRotation = { 0.005, 0, 0 };
	weaponType = 0;
	accuFire = true;
};

ItemData Railgun2
{
	description = "Railgun";
	shapeFile = "grenadeL";
	className = "Weapon";
	heading = $InvHead[ihWea];
	shadowDetailMask = 4;
	imageType = Railgun2Image;
	showWeaponBar = true;
	showInventory = false;
	price = 0;
};
function RailgunImage::onFire(%player, %slot)
{	
%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[Railgun]);
if(!%AmmoCount)return;

if($debug)
	echo("?? EVENT fire "@Player::getMountedItem(%player,0)@ " player "@ %player @" cl# "@ Player::getclient(%player));	
	
%client = GameBase::getOwnerClient(%player);
%clientName = Player::getClient(%player);
%clientId = Client::getName(%client);
%trans = GameBase::getMuzzleTransform(%player);
%vel = Item::getVelocity(%player);

%player.CrowRailGunShooting = true;
%obj = Projectile::spawnProjectile("RailgunLockon",%trans,%player,%vel);
schedule("deleteobject("@%obj@");",0.1);
}

function Railgun::onMount(%player,%item)
{	
	if($debug)
		echo("?? EVENT mount "@ %item @" onto player "@ %player @" cl# "@ Player::getclient(%player));

	Player::mountItem(%player,Railgun2,4);
	%clientId = Player::getclient(%player);
	if(%clientId.weaponHelp)
		bottomprint(%clientId, "<jc>Rail Gun: <f2>WARNING: NOT A NORMAL RAILGUN.  It spins the shell to curve toward its target.  Not a sniper weapon.");
}

function RailGunLockOn::damageTarget(%targetPl, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterPl)
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
	Player::decItemCount(%shooterPl, $WeaponAmmo[Railgun],1);
	%trans = gamebase::getmuzzletransform(%shooterPl);
	%vel = item::getvelocity(%shooterPl);

	projectile::spawnProjectile("RailCurve", %trans, %ShooterPl, %vel, %targetPl);
}

function Railgun::onUnmount(%player,%item)
{
	Player::unmountItem(%player,4);
}
