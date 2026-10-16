//=========================================================================================================================================
// Tools.cs
//=========================================================================================================================================

$AutoUse[RepairTool] = True;

$WeaponAmmo[RepairTool] = "";

$InvList[RepairTool] = 1;

//------------------------------------------------------------------------------ Repair Gun

ItemImageData RepairToolImage
{
	shapeFile = "repairgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = RepairBolt;
   minEnergy = 1;
   maxEnergy = 6;  // Energy used/sec for sustained weapons
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData RepairTool
{
   description = "Repair Gun";
	shapeFile = "repairgun";
	hudIcon = "repairpack";
   className = "bWeapons";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 125;
   validateShape = true;
};

//----------------------------------------------------------------------------