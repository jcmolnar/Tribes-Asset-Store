
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//
//  ELF Gun (EnergyRifle)
//  By Dynamix
//
//  Alliance version by Alazane, 
//    see Contrib.txt
//
//  For installation information, see Install.txt
//
//-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

$InvList[ELF] = 1;
$RemoteInvList[ELF] = 1;
$AutoUse[ELF] = True;
$WeaponAmmo[ELF] = "";

addWeapon(ELF);

LightningData lightningCharge
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 15.0;
   coneAngle        = 20.0;
   damagePerSec      = 0.10;
   energyDrainPerSec = 60.0;
   segmentDivisions = 5;
   numSegments      = 5;
   beamWidth        = 0.325;//075;

   updateTime   = 120;
   skipPercent  = 0.2;
   displaceBias = 0.4;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

ItemImageData ELFImage
{
	shapeFile = "repairgun";
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

   sfxActivate = SoundElectricShock;
   sfxFire     = SoundELFIdle;
};

ItemData ELF
{
  className = "Weapon";
  description = "Shock Gun";
  heading = $InvHead[ihWea];
  hudIcon = "energyRifle";
  imageType = ELFImage;
  price = 125;
  shadowDetailMask = 4;
  shapeFile = "repairgun";
  showWeaponBar = true;
};

function ELF::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Shock Gun");
}
