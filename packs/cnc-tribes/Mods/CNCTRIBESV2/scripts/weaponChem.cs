//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  Virus Launcher
//
//  For installation information, see Install.txt
//  Created by <[DC]>Paladin
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$InvList[Virus] = 1;
$InvList[VirusAmmo] = 1;
$RemoteInvList[Virus] = 1;
$RemoteInvList[VirusAmmo] = 1;
$AutoUse[Virus] = False;
$SellAmmo[VirusAmmo] = 5;
$WeaponAmmo[Virus] = VirusAmmo;

addWeapon(Virus);
addAmmo(Virus, VirusAmmo, 2);

BulletData VirusShell 
{
  bulletShapeName = "dustplume.dts";
  explosionTag  = bulletExp0;
  damageClass = 1;
  damageValue = 0.06;
  damageType = $EnergyDamageType;
  explosionRadius = 10.0;
  muzzleVelocity = 30.0;
  totalTime = 0.8;
  liveTime = 0.8;
  lightRange = 3.0;
  lightColor = { 1, 1, 0 };
  inheritedVelocityScale = 0.3;
  isVisible = True;
  soundId = SoundJetLight;
};

ItemData VirusAmmo
{
	description = "Neurotoxin";
	className = "Ammo";
   heading = $InvHead[ihAmm];
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
	showInventory = False;
};

ItemImageData VirusImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = VirusAmmo;
	projectileType = VirusShell;
	accuFire = false;
	reloadTime = 0.05;
	fireTime = 0.05;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Virus
{
	description = "Virus Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = $InvHead[ihWma];
	shadowDetailMask = 4;
	imageType = VirusImage;
	price = 1575;
	showWeaponBar = true;
};

function Virus::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
      bottomprint(%client, "The virus launcher. Ahhhh....sugar sweet chemical weapons. The bane of any armours existence. Need I say more?");
}

