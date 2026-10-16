//Infested gauss rifle, from marines, M
$InvList[InfHyperB] = 1;
$RemoteInvList[InfHyperB] = 1;
$VehicleInvList[InfHyperB] = 1;
$AutoUse[InfHyperB] = False;
$WeaponAmmo[InfHyperB] = "";

addWeapon(InfHyperB);

BulletData InfLasBolt
{
   bulletShapeName   = "bullet.dts";
   explosionTag      = InfBulletExp1;
//   expRandCycle      = 2;
   damageType        = 0;
   damageValue       = 0.1;
   bulletholeIndex   = 0;
   baseDamageType    = $ShellDamageType;
   damageType        = $ShellDamageType;
   aimDeflection     = 0.002;
   liveTime          = 0.4;
   totalTime         = 0.4;
   lightRange        = 1.0;
   lightColor        = { 1.0, 0.25, 0.25 };
   muzzleVelocity    = 600.0;
   terminalVelocity  = 600.0;
   inheritedVelocityScale = 1.0;
   detachFromShooter = false;
};

ItemImageData InfHyperBImage
{
   shapeFile  = "Chaingun";
	mountPoint = 0;
        spinUpTime = 0.4;
        spinDownTime = 1.5;
      weaponType = 1;
	projectileType = InfLasBolt;
	reloadTime = 0.05;
	fireTime = 0.1;
	minEnergy = 0.2;
	maxEnergy = 1;

	accuFire = false;
        sfxSpinUp = SoundSpinUp;
	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
};

ItemData InfHyperB
{
   heading = $InvHead[ihPsi];
	description = "Infested Gauss Rifle";
	className = "Weapon";
   shapeFile  = "Chaingun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = InfHyperBImage;
	price = 500;
	showWeaponBar = true;
};

function InfHyperB::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Infested Gauss Rifle: <f2>Once a weapon held by valiant hands, this weapon now serves The Swarm. http://www.tribes-universe.com/StarSeigeCraft");
}