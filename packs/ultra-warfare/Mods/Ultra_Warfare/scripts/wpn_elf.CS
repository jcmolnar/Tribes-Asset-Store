//================================================================
//T2 ELF
//================================================================
$AutoUse[ELFGun] = False;
//================================================================
$InvList[ELFGun] = 1;
$RemoteInvList[ELFGun] = 1;
//================================================================
$DamageScale[larmor, $ELFDamageType] = 1.0;  
$DamageScale[lfemale, $ELFDamageType] = 1.0;
$DamageScale[marmor, $ELFDamageType] = 1.0;  
$DamageScale[mfemale, $ELFDamageType] = 1.0; 
$DamageScale[harmor, $ELFDamageType] = 1.0;  

$ItemMax[larmor, ELFGun] = 1;
$ItemMax[lfemale, ELFGun] = 1; 
$ItemMax[marmor, ELFGun] = 1;
$ItemMax[mfemale, ELFGun] = 1; 
$ItemMax[harmor, ELFGun] = 1;
//================================================================
SoundData SoundWPNELFAct
{
   wavFileName = "wpn_ELF_act.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNELF
{
   wavFileName = "wpn_ELF.wav";
   profile = Profile3dNear;
};
SoundData SoundWPNELFFire
{
   wavFileName = "wpn_ELF_hit.wav";
   profile = Profile3dNear;
};

//================================================================
LightningData Elfgunproj
{
   bitmapName       = "proj_elf.bmp";

   damageType       = $ELFDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 60.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundWPNELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ELFDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}
//================================================================
ItemImageData ELFGunImage
{
        shapeFile = "wpn_ELF";
        mountPoint = 0;
  
	  weaponType = 2;  // Sustained
	  projectileType = ELFgunproj;
  	  minEnergy = 2;
  	  maxEnergy = 11;  // Energy used/sec for sustained weapons
	  reloadTime = 0.2;

        lightType = 3;  // Weapon Fire
        lightRadius = 2;
        lightTime = 1;
        lightColor = { 0, 0, 2 };

        sfxFire = SoundWPNELF;
        sfxActivate = SoundWPNELFAct;
};

ItemData ELFGun
{
        description = "ELF Projector";
        className = "Weapon";
        shapeFile = "sniper";
        hudIcon = "wpn_ELF";
   	heading = "bWeapons";
        shadowDetailMask = 4;
        imageType = ELFGunImage;
        price = 0;
        showWeaponBar = true;
};
//================================================================
//echo("ELF gun Loaded");
