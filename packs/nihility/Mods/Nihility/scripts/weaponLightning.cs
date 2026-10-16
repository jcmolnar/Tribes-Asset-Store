//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++
addWeapon(Blaster);
$InvList[Blaster] = 1;

$AutoUse[Blaster] = True;
$WeaponAmmo[Blaster] = "";

$ItemMax[larmor, Blaster] = 1;		//Seraph
$ItemMax[lfemale, Blaster] = 1;		//Seraph
$ItemMax[earmor, Blaster] = 1;		//Slave
$ItemMax[efemale, Blaster] = 1;		//Slave
$ItemMax[marmor, Blaster] = 1;		//Pawn
$ItemMax[aarmor, Blaster] = 1;		//Navigator
$ItemMax[darmor, Blaster] = 0;		//Atomizer
$ItemMax[barmor, Blaster] = 0;		//Paladin

//+++++++++++++++++++++++++++++++++++++
//+++++++++++++++++++++++++++++++++++++

//flyerflame.bmp, pglite00.bmp, flyer.bmp
//middle row :
//pulse04.bmp   lightningNewSub
//bottom row : 		warp
//flare.bmp, 	repairadd


LightningData BlasterCharge
{
   bitmapName       = "zap03.bmp";//lightningNew  paintpulse.dts 

   damageType       = $ElectricityDamageType;
   boltLength       = 100;
   coneAngle        = 5.0;
   damagePerSec      = 0.26;
   energyDrainPerSec = 20.0;
   segmentDivisions = 6;  //6
   numSegments      = 8;   //8
   beamWidth        = 0.4; //.4   //075;
//   boltLength       = 150.0;
//   coneAngle        = 10.0;
//   damagePerSec      = 0.2;
//   energyDrainPerSec = 30.0;
   
  // segmentDivisions = 2;
  // numSegments      = 8;
  // beamWidth        = 0.2;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 15.0;
   lightColor = { 0.25, 0.25, 0.85 };
   

   soundId = SoundELFFire;
};

//--------------------------------------

ItemImageData BlasterImage
{
shapeFile = "shotgun";
   mountPoint = 0;
   
//      mountRotation = { 0, -2.335, 0 };
//   mountOffset = { -0.01, 0, -0.01 };
      mountRotation = { 0, 3.14, 0 };


   weaponType = 2;  // Sustained
   projectileType = BlasterCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 1.0, 0.25 };

   sfxActivate = SoundPickUpWeapon;
  // sfxFire     = SoundFireTargetingLaser; 
   sfxFire     = SoundELFIdle;
};

ItemImageData BlasterRImage
{
shapeFile = "shotgun";
   mountPoint = 0;
   
   mountRotation = { 0, -0.785, 0 };
   mountOffset = { 0.08 , 0, -0.08 };
   
   weaponType = 2;  // Sustained
   projectileType = BlasterCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 1.0, 0.25 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
   //sfxFire     = SoundELFIdle;
};

ItemImageData BlasterLImage
{
shapeFile = "shotgun";
   mountPoint = 0;
   mountRotation = { 0, 2.335, 0 };
   mountOffset = { -0.1, 0, 0.1 };
   weaponType = 2;  // Sustained
   projectileType = BlasterCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 1.0, 0.25 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
   //sfxFire     = SoundELFIdle;
};

ItemImageData BlasterBImage
{
shapeFile = "shotgun";
   mountPoint = 0;
   mountRotation = { 0, 0.785, 0 };
   mountOffset = { 0.01, 0, 0.01 };
   weaponType = 2;  // Sustained
   projectileType = BlasterCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 1.0, 0.25 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundFireTargetingLaser;
   //sfxFire     = SoundELFIdle;
};


ItemData BlasterL
{
   description = "Left";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = BlasterLImage;
	showWeaponBar = false;
	showInventory = false;
   price = 1;
   validateShape = true;
};

ItemData BlasterR
{
   description = "Right";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = BlasterRImage;
	showWeaponBar = false;
	showInventory = false;
   price = 1;
   validateShape = true;
};

ItemData BlasterB
{
   description = "Bottom";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = BlasterBImage;
	showWeaponBar = false;
	showInventory = false;
   price = 1;
   validateShape = true;
};

ItemData Blaster
{
   description = "Lightning Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = BlasterImage;
	showWeaponBar = true;
   price = 77;
   validateShape = true;
};

//$BlasterSlotA=4;
//$BlasterSlotB=7;
$BlasterSlotC=5;



function Blaster::onMount(%player,%imageSlot,%item,$WeaponSlot) 
{
	%client = Player::getclient(%player);
        bottomprint(%client, "<jc><f2>Lightning Gun");

	//Player::mountItem(%player,blasterL,$BlasterSlotA); 
	//Player::mountItem(%player,blasterR,$BlasterSlotB);
	//Player::mountItem(%player,blasterB,$BlasterSlotC);
}

function Blaster::onUnmount(%player,%imageSlot)
{
	//Player::unmountItem(%player,$BlasterSlotA); 
	//Player::unmountItem(%player,$BlasterSlotB); 
	//Player::unmountItem(%player,$BlasterSlotC); 
}