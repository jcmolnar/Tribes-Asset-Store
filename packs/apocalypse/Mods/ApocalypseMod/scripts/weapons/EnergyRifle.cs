//--------------------------------------

$AutoUse[EnergyRifle] = True;
$WeaponAmmo[EnergyRifle] = "";

addToInv(EnergyRifle,1,1);

setArmorItemMax(EnergyRifle,1,1,1,1,1,1,1, 1, 0,0,0,0);

//--------------------------------------

LightningData lightningCharge
{
   bitmapName	    = "zap03.bmp";

   damageType	    = $ElectricityDamageType;
   boltLength	    = 40.0;
   coneAngle	    = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 6;
   numSegments	    = 8;
   beamWidth	    = 0.4;//075;

   updateTime	= 120;
   skipPercent	= 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

//--------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
			
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = $InvCatWeapons[All];
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

$MountMSG[EnergyRifle] = "<JC><F2>ELF Gun <F0>- <F1>Electron Flux Gun drains the target's energy and minor damage.";

AddWeapon(EnergyRifle);
