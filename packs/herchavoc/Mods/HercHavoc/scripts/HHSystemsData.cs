//----------------------------------------------------------------------------
// Herc Havoc -- "HERC Systems" pack datablocks (special components, pack key).
// Exec'd from modDataBlocks.cs so they register BEFORE preloadServerDataBlocks.
// Logic lives in HHComponents.cs.
//----------------------------------------------------------------------------

// Starsiege mine-launch sounds (sfx_ara / sfx_prx, Mods\HercHavoc\Starsiege)
SoundData HHSfxMineArach
{
   wavFileName = "sfx_ara.wav";
   profile = Profile3dNear;
};

SoundData HHSfxMineProx
{
   wavFileName = "sfx_prx.wav";
   profile = Profile3dNear;
};

ItemImageData HHSystemsImage
{
   shapeFile = "sensorjampack";
   mountPoint = 2;
   weaponType = 2;           // sustained: pack key = on/off (stock jammer pattern)
   minEnergy = 0;
   maxEnergy = 0;
   firstPerson = false;
};

ItemData HHSystems
{
   description = "HERC Systems";
   shapeFile = "sensorjampack";
   className = "Backpack";
   heading = "cBackpacks";
   shadowDetailMask = 4;
   imageType = HHSystemsImage;
   price = 0;
   hudIcon = "sensorjamerpack";
   showWeaponBar = true;
   hiliteOnActive = true;
};
