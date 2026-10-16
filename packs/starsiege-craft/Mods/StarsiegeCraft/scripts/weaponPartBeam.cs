//particle beam, toss, L
$WeaponAmmo[PartGun] = "";
$InvList[PartGun] = 1;
$AutoUse[PartGun] = False;
$RemoteInvList[PartGun] = 1;
$VehicleInvList[PartGun] = 1;

addWeapon(PartGun);

//=====================================================================//=== Partbeam ray

LightningData partbeam
{
   bitmapName       = "discglow1.bmp";
   damageType       = $ElectricityDamageType;
   boltLength       = 60.0;
   coneAngle        = 45.0;
   damagePerSec      = 0.5;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 2;
   beamWidth        = 0.3;//10;
   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;
   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };
   soundId = SoundELFFire;
};

//=====================================================================//=== Particle beam

ItemImageData PartGunImage
{
   shapeFile  = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Single Shot
	reloadTime = 1.0;
	minEnergy = 6;
	maxEnergy = 30;

	projectileType = Partbeam;
	accuFire = false;

	sfxFire = SoundJammerOn;
	sfxActivate = SoundPickUpWeapon;
};

ItemData PartGun
{
   heading = $InvHead[ihWet];
	description = "Particle Beam";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = PartGunImage;
	price = 325;
	showWeaponBar = true;
};


function PartGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "Particle Beam: <f2>This weapon generates a moderately strengthed ray to harm opponents.");
}