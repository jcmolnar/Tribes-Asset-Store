//gauss rifle, from marines, M
$InvList[Gauss] = 1;
$RemoteInvList[Gauss] = 1;
$VehicleInvList[Gauss] = 1;
$AutoUse[Gauss] = False;
$WeaponAmmo[Gauss] = "";

addWeapon(Gauss);

BulletData GaussBolt
{
   bulletShapeName   = "bullet.dts";
   explosionTag      = bulletexp1;
   expRandCycle      = 4;
   damageType        = 0;
   damageValue       = 0.1;
   bulletholeIndex   = 0;
   baseDamageType    = $ShellDamageType;
   damageType        = $ShellDamageType;
   aimDeflection     = 0.0015;
   liveTime          = 0.4;
   totalTime         = 0.4;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   muzzleVelocity    = 800.0;
   terminalVelocity  = 800.0;
   acceleration      = 20.0;
   inheritedVelocityScale = 0.2;
   detachFromShooter = false;
};

ItemImageData GaussImage
{
   shapeFile  = "chaingun";
	mountPoint = 0;
        spinUpTime = 0.4;
        spinDownTime = 1.5;
        weaponType = 1;
	projectileType = GaussBolt;
//	ammoType = GaussAmmo;
	reloadTime = 0.05;
	fireTime = 0.1;
	minEnergy = 0.2;
	maxEnergy = 1;

	accuFire = false;
        sfxSpinUp = SoundSpinUp;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Gauss
{
   heading = $InvHead[ihWea];
	description = "8MM C-14 Gauss Rifle";
	className = "Weapon";
   shapeFile  = "chaingun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = GaussImage;
	price = 500;
	showWeaponBar = true;
};

function Gauss::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "8MM C-14 Gauss Rifle: <f2>Rapid-fire standard issue Marine rifle. StarSeigeCraft website- http://www.tribes-universe.com/StarSeigeCraft");
}
