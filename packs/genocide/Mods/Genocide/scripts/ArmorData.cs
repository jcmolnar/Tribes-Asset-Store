//----------------=Misc Data=--------------------
$LightJetForce = 350;
$LightJetDrain = 1;
$LightJumpForce = 90;

$MediumJetForce = 450;
$MediumJetDrain = 1;
$MediumJumpForce = 100;
//-----------------=Misc End=--------------------

//--------------------
//New Deployable Data
//---------------------
$TeamItemMax[AirBasePack] = 1;
$TeamItemMax[RemoteBase] = 2;
$TeamItemMax[BlastDoorpack] = 15;
$TeamItemMax[plat] = 15;
$TeamItemMax[plat2] = 15;
$TeamItemMax[lgbForceFieldPack] = 15;
$TeamItemMax[medaForceFieldPack] = 15;
$TeamItemMax[medbForceFieldPack] = 15;
$TeamItemMax[medcForceFieldPack] = 15;
//++++++++++++++++++++++++++++++++++++
$TeamItemMax[TurretPack] = 15;
$TeamItemMax[LaserTurretPack] = 15;
$TeamItemMax[MaliceTurretPack] = 15;
$TeamItemMax[LaserTurretBPack] = 15;
$TeamItemMax[ARPGTurretPack] = 15;
$TeamItemMax[MiniFlakTurretPack] = 15;
$TeamItemMax[MiniSamTurretPack] = 15;
$TeamItemMax[ElectricWeb] = 5;

//--------------=Damage Values=------------------
$DamageScale[sarmor,   $LandingDamageType] = 1.0;
$DamageScale[larmor,   $LandingDamageType] = 1.0;
$DamageScale[marmor,   $LandingDamageType] = 1.0;
$DamageScale[harmor,   $LandingDamageType] = 1.0;
$DamageScale[narmor,   $LandingDamageType] = 1.0;
$DamageScale[lfemale,  $LandingDamageType] = 1.0;
$DamageScale[mfemale,  $LandingDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,    $ImpactDamageType] = 1.0;
$DamageScale[larmor,    $ImpactDamageType] = 1.0;
$DamageScale[marmor,    $ImpactDamageType] = 1.0;
$DamageScale[harmor,    $ImpactDamageType] = 1.5;
$DamageScale[narmor,    $ImpactDamageType] = 1.5;
$DamageScale[lfemale,   $ImpactDamageType] = 1.0;
$DamageScale[mfemale,   $ImpactDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,     $CrushDamageType] = 1.0;
$DamageScale[larmor,     $CrushDamageType] = 1.0;
$DamageScale[marmor,     $CrushDamageType] = 1.0;
$DamageScale[harmor,     $CrushDamageType] = 1.0;
$DamageScale[narmor,     $CrushDamageType] = 1.0;
$DamageScale[lfemale,    $CrushDamageType] = 1.0;
$DamageScale[mfemale,    $CrushDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,    $RipperBulletDamageType] = 1.2;
$DamageScale[larmor,    $RipperBulletDamageType] = 1.2;
$DamageScale[marmor,    $RipperBulletDamageType] = 1.0;
$DamageScale[harmor,    $RipperBulletDamageType] = 0.6;
$DamageScale[narmor,    $RipperBulletDamageType] = 0.6;
$DamageScale[lfemale,   $RipperBulletDamageType] = 1.2;
$DamageScale[mfemale,   $RipperBulletDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,    $PlasmaCannonDamageType] = 1.0;
$DamageScale[larmor,    $PlasmaCannonDamageType] = 1.0;
$DamageScale[marmor,    $PlasmaCannonDamageType] = 0.6;
$DamageScale[harmor,    $PlasmaCannonDamageType] = 0.4;
$DamageScale[narmor,    $PlasmaCannonDamageType] = 0.4;
$DamageScale[lfemale,   $PlasmaCannonDamageType] = 1.0;
$DamageScale[mfemale,   $PlasmaCannonDamageType] = 0.6;
//-----------------------------------------------
$DamageScale[sarmor,    $EnergyDamageType] = 1.3;
$DamageScale[larmor,    $EnergyDamageType] = 1.3;
$DamageScale[marmor,    $EnergyDamageType] = 1.0;
$DamageScale[harmor,    $EnergyDamageType] = 0.7;
$DamageScale[narmor,    $EnergyDamageType] = 0.7;
$DamageScale[lfemale,   $EnergyDamageType] = 1.3;
$DamageScale[mfemale,   $EnergyDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,  $StormHammerDamageType] = 1.0;
$DamageScale[larmor,  $StormHammerDamageType] = 1.0;
$DamageScale[marmor,  $StormHammerDamageType] = 1.0;
$DamageScale[harmor,  $StormHammerDamageType] = 0.6;
$DamageScale[narmor,  $StormHammerDamageType] = 0.6;
$DamageScale[lfemale, $StormHammerDamageType] = 1.0;
$DamageScale[mfemale, $StormHammerDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,  $MissileDamageType] = 1.0;
$DamageScale[larmor,  $MissileDamageType] = 1.0;
$DamageScale[marmor,  $MissileDamageType] = 1.0;
$DamageScale[harmor,  $MissileDamageType] = 1.2;
$DamageScale[narmor,  $MissileDamageType] = 1.2;
$DamageScale[lfemale, $MissileDamageType] = 1.0;
$DamageScale[mfemale, $MissileDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,  $DebrisDamageType] = 1.2;
$DamageScale[larmor,  $DebrisDamageType] = 1.2;
$DamageScale[marmor,  $DebrisDamageType] = 1.0;
$DamageScale[harmor,  $DebrisDamageType] = 0.8;
$DamageScale[narmor,  $DebrisDamageType] = 0.8;
$DamageScale[lfemale, $DebrisDamageType] = 1.2;
$DamageScale[mfemale, $DebrisDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,  $bioShrapnelDamageType] = 1.2;
$DamageScale[larmor,  $bioShrapnelDamageType] = 1.2;
$DamageScale[marmor,  $bioShrapnelDamageType] = 1.0;
$DamageScale[harmor,  $bioShrapnelDamageType] = 0.8;
$DamageScale[narmor,  $bioShrapnelDamageType] = 0.8;
$DamageScale[lfemale, $bioShrapnelDamageType] = 1.2;
$DamageScale[mfemale, $bioShrapnelDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,     $LazerexDamageType] = 1.0;
$DamageScale[larmor,     $LazerexDamageType] = 1.0;
$DamageScale[marmor,     $LazerexDamageType] = 1.0;
$DamageScale[harmor,     $LazerexDamageType] = 0.6;
$DamageScale[narmor,     $LazerexDamageType] = 0.6;
$DamageScale[lfemale,    $LazerexDamageType] = 1.0;
$DamageScale[mfemale,    $LazerexDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,    $SplitMortarDamageType] = 1.3;
$DamageScale[larmor,    $SplitMortarDamageType] = 1.3;
$DamageScale[marmor,    $SplitMortarDamageType] = 1.0;
$DamageScale[harmor,    $SplitMortarDamageType] = 1.3;
$DamageScale[narmor,    $SplitMortarDamageType] = 1.3;
$DamageScale[lfemale,   $SplitMortarDamageType] = 1.3;
$DamageScale[mfemale,   $SplitMortarDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,   $BlazterDamageType] = 1.3;
$DamageScale[larmor,   $BlazterDamageType] = 1.3;
$DamageScale[marmor,   $BlazterDamageType] = 1.0;
$DamageScale[harmor,   $BlazterDamageType] = 0.7;
$DamageScale[narmor,   $BlazterDamageType] = 0.7;
$DamageScale[lfemale,  $BlazterDamageType] = 1.3;
$DamageScale[mfemale,  $BlazterDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor, $ElectricityDamageType] = 1.0;
$DamageScale[larmor, $ElectricityDamageType] = 1.0;
$DamageScale[marmor, $ElectricityDamageType] = 1.0;
$DamageScale[harmor, $ElectricityDamageType] = 1.0;
$DamageScale[narmor, $ElectricityDamageType] = 1.0;
$DamageScale[lfemale, $ElectricityDamageType] = 1.0;
$DamageScale[mfemale, $ElectricityDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $MineDamageType] = 1.2;
$DamageScale[larmor, $MineDamageType] = 1.2;
$DamageScale[marmor, $MineDamageType] = 1.0;
$DamageScale[harmor, $MineDamageType] = 0.8;
$DamageScale[narmor, $MineDamageType] = 0.8;
$DamageScale[lfemale, $MineDamageType] = 1.2;
$DamageScale[mfemale, $MineDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $FusionDamageType] = 1.0;
$DamageScale[larmor, $FusionDamageType] = 1.0;
$DamageScale[marmor, $FusionDamageType] = 1.0;
$DamageScale[harmor, $FusionDamageType] = 0.75;
$DamageScale[narmor, $FusionDamageType] = 0.75;
$DamageScale[lfemale, $FusionDamageType] = 1.0;
$DamageScale[mfemale, $FusionDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $TimebombDamageType] = 1.0;
$DamageScale[larmor, $TimebombDamageType] = 1.0;
$DamageScale[marmor, $TimebombDamageType] = 1.0;
$DamageScale[harmor, $TimebombDamageType] = 1.0;
$DamageScale[narmor, $TimebombDamageType] = 1.0;
$DamageScale[lfemale, $TimebombDamageType] = 1.0;
$DamageScale[mfemale, $TimebombDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $FuzionDamageType] = 1.3;
$DamageScale[larmor, $FuzionDamageType] = 1.3;
$DamageScale[marmor, $FuzionDamageType] = 1.0;
$DamageScale[harmor, $FuzionDamageType] = 0.7;
$DamageScale[narmor, $FuzionDamageType] = 0.7;
$DamageScale[lfemale, $FuzionDamageType] = 1.3;
$DamageScale[mfemale, $FuzionDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $HavocDamageType] = 1.5;
$DamageScale[larmor, $HavocDamageType] = 1.0;
$DamageScale[marmor, $HavocDamageType] = 1.0;
$DamageScale[harmor, $HavocDamageType] = 1.3;
$DamageScale[narmor, $HavocDamageType] = 1.3;
$DamageScale[lfemale, $HavocDamageType] = 1.0;
$DamageScale[mfemale, $HavocDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $ShardDamageType] = 1.2;
$DamageScale[larmor, $ShardDamageType] = 1.2;
$DamageScale[marmor, $ShardDamageType] = 1.0;
$DamageScale[harmor, $ShardDamageType] = 0.6;
$DamageScale[narmor, $ShardDamageType] = 0.6;
$DamageScale[lfemale, $ShardDamageType] = 1.2;
$DamageScale[mfemale, $ShardDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $GlockDamageType] = 1.5;
$DamageScale[larmor, $GlockDamageType] = 1.4;
$DamageScale[marmor, $GlockDamageType] = 1.2;
$DamageScale[harmor, $GlockDamageType] = 0.6;
$DamageScale[narmor, $GlockDamageType] = 0.6;
$DamageScale[lfemale, $GlockDamageType] = 1.4;
$DamageScale[mfemale, $GlockDamageType] = 1.2;
//-------------------------------------------------
$DamageScale[sarmor, $EWebDamageType] = 5.0;
$DamageScale[larmor, $EWebDamageType] = 5.0;
$DamageScale[marmor, $EWebDamageType] = 5.0; 
$DamageScale[harmor, $EWebDamageType] = 5.0;
$DamageScale[narmor, $EWebDamageType] = 5.0;
$DamageScale[lfemale, $EWebDamageType] = 5.0;
$DamageScale[mfemale, $EWebDamageType] = 5.0; 
//-------------------------------------------------
$DamageScale[sarmor, $ARPGDamageType] = 1.0;
$DamageScale[larmor, $ARPGDamageType] = 1.0;
$DamageScale[marmor, $ARPGDamageType] = 1.0;
$DamageScale[harmor, $ARPGDamageType] = 1.7;
$DamageScale[narmor, $ARPGDamageType] = 1.7;
$DamageScale[lfemale, $ARPGDamageType] = 1.0;
$DamageScale[mfemale, $ARPGDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $StealthDamageType] = 1.3;
$DamageScale[larmor, $StealthDamageType] = 1.1;
$DamageScale[marmor, $StealthDamageType] = 1.0;
$DamageScale[harmor, $StealthDamageType] = 1.1;
$DamageScale[harmor, $StealthDamageType] = 1.1;
$DamageScale[lfemale, $StealthDamageType] = 1.1;
$DamageScale[mfemale, $StealthDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $MultiDamageType] = 1.0;
$DamageScale[larmor, $MultiDamageType] = 1.0;
$DamageScale[marmor, $MultiDamageType] = 1.0;
$DamageScale[harmor, $MultiDamageType] = 1.0;
$DamageScale[narmor, $MultiDamageType] = 1.0;
$DamageScale[lfemale, $MultiDamageType] = 1.0;
$DamageScale[mfemale, $MultiDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $WTShotgunDamageType] = 1.0;
$DamageScale[larmor, $WTShotgunDamageType] = 1.2;
$DamageScale[marmor, $WTShotgunDamageType] = 1.0;
$DamageScale[harmor, $WTShotgunDamageType] = 0.9;
$DamageScale[narmor, $WTShotgunDamageType] = 0.9;
$DamageScale[lfemale, $WTShotgunDamageType] = 1.2;
$DamageScale[mfemale, $WTShotgunDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $HellStormDamageType] = 1.0;
$DamageScale[larmor, $HellStormDamageType] = 1.0;
$DamageScale[marmor, $HellStormDamageType] = 1.0;
$DamageScale[harmor, $HellStormDamageType] = 1.0;
$DamageScale[narmor, $HellStormDamageType] = 1.0;
$DamageScale[lfemale, $HellStormDamageType] = 1.0;
$DamageScale[mfemale, $HellStormDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor,  $SalvoDamageType] = 1.0;
$DamageScale[larmor,  $SalvoDamageType] = 1.0;
$DamageScale[marmor,  $SalvoDamageType] = 1.0;
$DamageScale[harmor,  $SalvoDamageType] = 1.2;
$DamageScale[narmor,  $SalvoDamageType] = 1.2;
$DamageScale[lfemale, $SalvoDamageType] = 1.0;
$DamageScale[mfemale, $SalvoDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $AnarchyCannonDamageType] = 1.0;
$DamageScale[larmor, $AnarchyCannonDamageType] = 1.0;
$DamageScale[marmor, $AnarchyCannonDamageType] = 1.0;
$DamageScale[harmor, $AnarchyCannonDamageType] = 1.0;
$DamageScale[narmor, $AnarchyCannonDamageType] = 1.0;
$DamageScale[lfemale, $AnarchyCannonDamageType] = 1.0;
$DamageScale[mfemale, $AnarchyCannonDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $PlasGatDamageType] = 1.0;
$DamageScale[larmor, $PlasGatDamageType] = 1.0;
$DamageScale[marmor, $PlasGatDamageType] = 1.0;
$DamageScale[harmor, $PlasGatDamageType] = 1.0;
$DamageScale[narmor, $PlasGatDamageType] = 1.0;
$DamageScale[lfemale, $PlasGatDamageType] = 1.0;
$DamageScale[mfemale, $PlasGatDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $ParticalShotgunDamageType] = 0.5;
$DamageScale[larmor, $ParticalShotgunDamageType] = 0.75;
$DamageScale[marmor, $ParticalShotgunDamageType] = 1.0;
$DamageScale[harmor, $ParticalShotgunDamageType] = 1.5;
$DamageScale[narmor, $ParticalShotgunDamageType] = 1.5;
$DamageScale[lfemale, $ParticalShotgunDamageType] = 0.75;
$DamageScale[mfemale, $ParticalShotgunDamageType] = 1.0;
//-------------------------------------------------
$DamageScale[sarmor, $EMPDamageType] = 0.5;
$DamageScale[larmor, $EMPDamageType] = 0.5;
$DamageScale[marmor, $EMPDamageType] = 0.5;
$DamageScale[harmor, $EMPDamageType] = 0.5;
$DamageScale[narmor, $EMPDamageType] = 0.5;
$DamageScale[lfemale, $EMPDamageType] = 0.5;
$DamageScale[mfemale, $EMPDamageType] = 0.5;
//-------------------------------------------------
$DamageScale[sarmor, $AtomicDamageType] = 5.0; 
$DamageScale[larmor, $AtomicDamageType] = 5.0;  
$DamageScale[narmor, $AtomicDamageType] = 5.0; 
$DamageScale[harmor, $AtomicDamageType] = 5.0; 
$DamageScale[marmor, $AtomicDamageType] = 5.0; 
$DamageScale[lfemale, $AtomicDamageType] = 5.0; 
$DamageScale[mfemale, $AtomicDamageType] = 5.0; 
//-------------------------------------------------
$DamageScale[sarmor,     $RadiationDamageType] = 1.0;
$DamageScale[larmor,     $RadiationDamageType] = 1.0;
$DamageScale[marmor,     $RadiationDamageType] = 1.0;
$DamageScale[harmor,     $RadiationDamageType] = 0.6;
$DamageScale[narmor,     $RadiationDamageType] = 0.6;
$DamageScale[lfemale,    $RadiationDamageType] = 1.0;
$DamageScale[mfemale,    $RadiationDamageType] = 1.0;
//--------------------------------------------------
$DamageScale[sarmor,     $DiscoDamageType] = 2.0;
$DamageScale[larmor,     $DiscoDamageType] = 2.0;
$DamageScale[marmor,     $DiscoDamageType] = 2.0;
$DamageScale[harmor,     $DiscoDamageType] = 1.6;
$DamageScale[narmor,     $DiscoDamageType] = 1.6;
$DamageScale[lfemale,    $DiscoDamageType] = 2.0;
$DamageScale[mfemale,    $DiscoDamageType] = 2.0;
//---------------------------------------------------
$DamageScale[sarmor,     $LazerGatDamageType] = 1.0;
$DamageScale[larmor,     $LazerGatDamageType] = 1.0;
$DamageScale[marmor,     $LazerGatDamageType] = 1.0;
$DamageScale[harmor,     $LazerGatDamageType] = 0.6;
$DamageScale[narmor,     $LazerGatDamageType] = 0.6;
$DamageScale[lfemale,    $LazerGatDamageType] = 1.0;
$DamageScale[mfemale,    $LazerGatDamageType] = 1.0;
//---------------------------------------------------
$DamageScale[sarmor,     $GrazerDamageType] = 1.0;
$DamageScale[larmor,     $GrazerDamageType] = 1.0;
$DamageScale[marmor,     $GrazerDamageType] = 1.0;
$DamageScale[harmor,     $GrazerDamageType] = 0.6;
$DamageScale[narmor,     $GrazerDamageType] = 0.6;
$DamageScale[lfemale,    $GrazerDamageType] = 1.0;
$DamageScale[mfemale,    $GrazerDamageType] = 1.0;
//---------------------------------------------------
$DamageScale[sarmor,     $HybridLaserDamageType] = 1.0;
$DamageScale[larmor,     $HybridLaserDamageType] = 1.0;
$DamageScale[marmor,     $HybridLaserDamageType] = 1.0;
$DamageScale[harmor,     $HybridLaserDamageType] = 0.6;
$DamageScale[narmor,     $HybridLaserDamageType] = 0.6;
$DamageScale[lfemale,    $HybridLaserDamageType] = 1.0;
$DamageScale[mfemale,    $HybridLaserDamageType] = 1.0;
//----------------------------------------------------
$DamageScale[sarmor,  $QuakeDamageType] = 1.0;
$DamageScale[larmor,  $QuakeDamageType] = 1.0;
$DamageScale[marmor,  $QuakeDamageType] = 1.0;
$DamageScale[harmor,  $QuakeDamageType] = 0.6;
$DamageScale[narmor,  $QuakeDamageType] = 0.6;
$DamageScale[lfemale, $QuakeDamageType] = 1.0;
$DamageScale[mfemale, $QuakeDamageType] = 1.0;
//------------------------------------------------------
$DamageScale[sarmor,    $SXHDamageType] = 1.2;
$DamageScale[larmor,    $SXHDamageType] = 1.2;
$DamageScale[marmor,    $SXHDamageType] = 1.0;
$DamageScale[harmor,    $SXHDamageType] = 0.6;
$DamageScale[narmor,    $SXHDamageType] = 0.6;
$DamageScale[lfemale,   $SXHDamageType] = 1.2;
$DamageScale[mfemale,   $SXHDamageType] = 1.0;
//------------------------------------------------------
$DamageScale[sarmor,    $HybridRailDamageType] = 1.2;
$DamageScale[larmor,    $HybridRailDamageType] = 1.2;
$DamageScale[marmor,    $HybridRailDamageType] = 1.0;
$DamageScale[harmor,    $HybridRailDamageType] = 0.6;
$DamageScale[narmor,    $HybridRailDamageType] = 0.6;
$DamageScale[lfemale,   $HybridRailDamageType] = 1.2;
$DamageScale[mfemale,   $HybridRailDamageType] = 1.0;
//--------------------------------------------------------
$DamageScale[sarmor,    $MiniGunDamageType] = 1.2;
$DamageScale[larmor,    $MiniGunDamageType] = 1.2;
$DamageScale[marmor,    $MiniGunDamageType] = 1.0;
$DamageScale[harmor,    $MiniGunDamageType] = 0.6;
$DamageScale[narmor,    $MiniGunDamageType] = 0.6;
$DamageScale[lfemale,   $MiniGunDamageType] = 1.2;
$DamageScale[mfemale,   $MiniGunDamageType] = 1.0;
//---------------------------------------------------------
$DamageScale[sarmor,    $DFMIYADamageType] = 1.2;
$DamageScale[larmor,    $DFMIYADamageType] = 1.2;
$DamageScale[marmor,    $DFMIYADamageType] = 1.0;
$DamageScale[harmor,    $DFMIYADamageType] = 0.6;
$DamageScale[narmor,    $DFMIYADamageType] = 0.6;
$DamageScale[lfemale,   $DFMIYADamageType] = 1.2;
$DamageScale[mfemale,   $DFMIYADamageType] = 1.0;
//---------------------------------------------------------
$DamageScale[sarmor,    $DestroyerDamageType] = 1.2;
$DamageScale[larmor,    $DestroyerDamageType] = 1.2;
$DamageScale[marmor,    $DestroyerDamageType] = 1.0;
$DamageScale[harmor,    $DestroyerDamageType] = 0.6;
$DamageScale[narmor,    $DestroyerDamageType] = 0.6;
$DamageScale[lfemale,   $DestroyerDamageType] = 1.2;
$DamageScale[mfemale,   $DestroyerDamageType] = 1.0;
//---------------------------------------------------------
$DamageScale[sarmor,    $HybridChainDamageType] = 1.2;
$DamageScale[larmor,    $HybridChainDamageType] = 1.2;
$DamageScale[marmor,    $HybridChainDamageType] = 1.0;
$DamageScale[harmor,    $HybridChainDamageType] = 0.6;
$DamageScale[narmor,    $HybridChainDamageType] = 0.6;
$DamageScale[lfemale,   $HybridChainDamageType] = 1.2;
$DamageScale[mfemale,   $HybridChainDamageType] = 1.0;
//----------------------------------------------------------
$DamageScale[sarmor,    $PlasmaBlasterDamageType] = 1.0;
$DamageScale[larmor,    $PlasmaBlasterDamageType] = 1.0;
$DamageScale[marmor,    $PlasmaBlasterDamageType] = 0.6;
$DamageScale[harmor,    $PlasmaBlasterDamageType] = 0.4;
$DamageScale[narmor,    $PlasmaBlasterDamageType] = 0.4;
$DamageScale[lfemale,   $PlasmaBlasterDamageType] = 1.0;
$DamageScale[mfemale,   $PlasmaBlasterDamageType] = 0.6;
//-----------------------------------------------------------
$DamageScale[sarmor,    $BlazeDamageType] = 1.0;
$DamageScale[larmor,    $BlazeDamageType] = 1.0;
$DamageScale[marmor,    $BlazeDamageType] = 0.6;
$DamageScale[harmor,    $BlazeDamageType] = 0.4;
$DamageScale[narmor,    $BlazeDamageType] = 0.4;
$DamageScale[lfemale,   $BlazeDamageType] = 1.0;
$DamageScale[mfemale,   $BlazeDamageType] = 0.6;
//---------------------------------------------------
$DamageScale[sarmor,     $MeltLaserDamageType] = 1.0;
$DamageScale[larmor,     $MeltLaserDamageType] = 1.0;
$DamageScale[marmor,     $MeltLaserDamageType] = 1.0;
$DamageScale[harmor,     $MeltLaserDamageType] = 0.6;
$DamageScale[narmor,     $MeltLaserDamageType] = 0.6;
$DamageScale[lfemale,    $MeltLaserDamageType] = 1.0;
$DamageScale[mfemale,    $MeltLaserDamageType] = 1.0;
//---------------------------------------------------
$DamageScale[sarmor,    $NapalmLDamageType] = 1.0;
$DamageScale[larmor,    $NapalmLDamageType] = 1.0;
$DamageScale[marmor,    $NapalmLDamageType] = 0.6;
$DamageScale[harmor,    $NapalmLDamageType] = 0.4;
$DamageScale[narmor,    $NapalmLDamageType] = 0.4;
$DamageScale[lfemale,   $NapalmLDamageType] = 1.0;
$DamageScale[mfemale,   $NapalmLDamageType] = 0.6;
//----------------------------------------------------
$DamageScale[sarmor,  $NapalmRDamageType] = 1.2;
$DamageScale[larmor,  $NapalmRDamageType] = 1.2;
$DamageScale[marmor,  $NapalmRDamageType] = 1.0;
$DamageScale[harmor,  $NapalmRDamageType] = 0.8;
$DamageScale[narmor,  $NapalmRDamageType] = 0.8;
$DamageScale[lfemale, $NapalmRDamageType] = 1.2;
$DamageScale[mfemale, $NapalmRDamageType] = 1.0;
//----------------------------------------------------
$DamageScale[sarmor,    $MagmaDamageType] = 1.0;
$DamageScale[larmor,    $MagmaDamageType] = 1.0;
$DamageScale[marmor,    $MagmaDamageType] = 0.6;
$DamageScale[harmor,    $MagmaDamageType] = 0.4;
$DamageScale[narmor,    $MagmaDamageType] = 0.4;
$DamageScale[lfemale,   $MagmaDamageType] = 1.0;
$DamageScale[mfemale,   $MagmaDamageType] = 0.6;
//-----------------------------------------------------
$DamageScale[sarmor,  $NitroDamageType] = 1.2;
$DamageScale[larmor,  $NitroDamageType] = 1.2;
$DamageScale[marmor,  $NitroDamageType] = 1.0;
$DamageScale[harmor,  $NitroDamageType] = 0.8;
$DamageScale[narmor,  $NitroDamageType] = 0.8;
$DamageScale[lfemale, $NitroDamageType] = 1.2;
$DamageScale[mfemale, $NitroDamageType] = 1.0;
//------------------------------------------------------
$DamageScale[sarmor,    $FireMDamageType] = 1.3;
$DamageScale[larmor,    $FireMDamageType] = 1.3;
$DamageScale[marmor,    $FireMDamageType] = 1.0;
$DamageScale[harmor,    $FireMDamageType] = 1.3;
$DamageScale[narmor,    $FireMDamageType] = 1.3;
$DamageScale[lfemale,   $FireMDamageType] = 1.3;
$DamageScale[mfemale,   $FireMDamageType] = 1.0;
//------------------------------------------------------
$DamageScale[sarmor,    $ContactMDamageType] = 1.3;
$DamageScale[larmor,    $ContactMDamageType] = 1.3;
$DamageScale[marmor,    $ContactMDamageType] = 1.0;
$DamageScale[harmor,    $ContactMDamageType] = 1.3;
$DamageScale[narmor,    $ContactMDamageType] = 1.3;
$DamageScale[lfemale,   $ContactMDamageType] = 1.3;
$DamageScale[mfemale,   $ContactMDamageType] = 1.0;
//------------------------------------------------------
$DamageScale[sarmor,    $RaidDamageType] = 1.3;
$DamageScale[larmor,    $RaidDamageType] = 1.3;
$DamageScale[marmor,    $RaidDamageType] = 1.0;
$DamageScale[harmor,    $RaidDamageType] = 1.3;
$DamageScale[narmor,    $RaidDamageType] = 1.3;
$DamageScale[lfemale,   $RaidDamageType] = 1.3;
$DamageScale[mfemale,   $RaidDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,  $ClashDamageType] = 1.0;
$DamageScale[larmor,  $ClashDamageType] = 1.0;
$DamageScale[marmor,  $ClashDamageType] = 1.0;
$DamageScale[harmor,  $ClashDamageType] = 1.2;
$DamageScale[narmor,  $ClashDamageType] = 1.2;
$DamageScale[lfemale, $ClashDamageType] = 1.0;
$DamageScale[mfemale, $ClashDamageType] = 1.0;
//------------------------------------------------------
$DamageScale[sarmor,    $SludgeDamageType] = 1.3;
$DamageScale[larmor,    $SludgeDamageType] = 1.3;
$DamageScale[marmor,    $SludgeDamageType] = 1.0;
$DamageScale[harmor,    $SludgeDamageType] = 1.3;
$DamageScale[narmor,    $SludgeDamageType] = 1.3;
$DamageScale[lfemale,   $SludgeDamageType] = 1.3;
$DamageScale[mfemale,   $SludgeDamageType] = 1.0;
//-----------------------------------------------
$DamageScale[sarmor,    $HybridMortarDamageType] = 1.3;
$DamageScale[larmor,    $HybridMortarDamageType] = 1.3;
$DamageScale[marmor,    $HybridMortarDamageType] = 1.0;
$DamageScale[harmor,    $HybridMortarDamageType] = 1.3;
$DamageScale[narmor,    $HybridMortarDamageType] = 1.3;
$DamageScale[lfemale,   $HybridMortarDamageType] = 1.3;
$DamageScale[mfemale,   $HybridMortarDamageType] = 1.0;
//-----------------------------------------------------
$DamageScale[sarmor,  $HybridCannonDamageType] = 1.0;
$DamageScale[larmor,  $HybridCannonDamageType] = 1.0;
$DamageScale[marmor,  $HybridCannonDamageType] = 1.0;
$DamageScale[harmor,  $HybridCannonDamageType] = 1.2;
$DamageScale[narmor,  $HybridCannonDamageType] = 1.2;
$DamageScale[lfemale, $HybridCannonDamageType] = 1.0;
$DamageScale[mfemale, $HybridCannonDamageType] = 1.0;
//-----------------------------------------------------
$DamageScale[sarmor,  $HybridMissileDamageType] = 1.0;
$DamageScale[larmor,  $HybridMissileDamageType] = 1.0;
$DamageScale[marmor,  $HybridMissileDamageType] = 1.0;
$DamageScale[harmor,  $HybridMissileDamageType] = 1.2;
$DamageScale[narmor,  $HybridMissileDamageType] = 1.2;
$DamageScale[lfemale, $HybridMissileDamageType] = 1.0;
$DamageScale[mfemale, $HybridMissileDamageType] = 1.0;
//-----------------------------------------------------
$DamageScale[sarmor,  $HybridRPGDamageType] = 1.0;
$DamageScale[larmor,  $HybridRPGDamageType] = 1.0;
$DamageScale[marmor,  $HybridRPGDamageType] = 1.0;
$DamageScale[harmor,  $HybridRPGDamageType] = 1.2;
$DamageScale[narmor,  $HybridRPGDamageType] = 1.2;
$DamageScale[lfemale, $HybridRPGDamageType] = 1.0;
$DamageScale[mfemale, $HybridRPGDamageType] = 1.0;
//----------------------------------------------------------
$DamageScale[sarmor,    $ETTRDamageType] = 1.0;
$DamageScale[larmor,    $ETTRDamageType] = 1.0;
$DamageScale[marmor,    $ETTRDamageType] = 0.6;
$DamageScale[harmor,    $ETTRDamageType] = 0.4;
$DamageScale[narmor,    $ETTRDamageType] = 0.4;
$DamageScale[lfemale,   $ETTRDamageType] = 1.0;
$DamageScale[mfemale,   $ETTRDamageType] = 0.6;

##############################################################################
## Tactical Sniper Arsenal
##############################################################################
$ItemMax[sarmor, Blaster] = 1;                                
$ItemMax[sarmor, Chaingun] = 1;                                
$ItemMax[sarmor, PlasmaGun] = 1;                                
$ItemMax[sarmor, GrenadeLauncher] = 1;                         
$ItemMax[sarmor, Mortar] = 0;                                     
$ItemMax[sarmor, DiscLauncher] = 0;                             
$ItemMax[sarmor, LaserRifle] = 1;                                 
$ItemMax[sarmor, Charger] = 1;                                    
$ItemMax[sarmor, FusionRifle] = 1;                              
$ItemMax[sarmor, ShockRfile] = 1;                               
$ItemMax[sarmor, RadiationRifle] = 1;                            
$ItemMax[sarmor, DiscoRifle] = 0;                                                             
$ItemMax[sarmor, GatLaser] = 1;                                  
$ItemMax[sarmor, GrazerCannon] = 0;                               
$ItemMax[sarmor, HybridLaser] = 0;                              
$ItemMax[sarmor, Grappling] = 1;                               
$ItemMax[sarmor, QuakeBlaster] = 1;                                                          
$ItemMax[sarmor, HellStorm] = 0;                                
$ItemMax[sarmor, FusionCannon] = 0;                              
$ItemMax[sarmor, MultiCannon] = 1;                                
$ItemMax[sarmor, Glock] = 1;                                      
$ItemMax[sarmor, WTShotgun] = 0;                                 
$ItemMax[sarmor, ParticalShotgun] = 1;                           
$ItemMax[sarmor, SXH] = 1;                                      
$ItemMax[sarmor, Havoc] = 1;                                   
$ItemMax[sarmor, HybridRail] = 0;                                 
$ItemMax[sarmor, Minigun] = 1;                                   
$ItemMax[sarmor, ShardGun] = 0;                                  
$ItemMax[sarmor, DFMIYA] = 1;                                  
$ItemMax[sarmor, Destroyer] = 1;                                  
$ItemMax[sarmor, ARPG] = 0;                                     
$ItemMax[sarmor, HybridChain] = 0;                              
$ItemMax[sarmor, PlasmaBlaster] = 0;                            
$ItemMax[sarmor, Blaze] = 1;                                    
$ItemMax[sarmor, PlasmaGat] = 0;                              
$ItemMax[sarmor, MeltLaser] = 1;                             
$ItemMax[sarmor, SAStealth] = 0;                               
$ItemMax[sarmor, NapalmLauncher] = 1;                           
$ItemMax[sarmor, NapalmRocket] = 1;                             
$ItemMax[sarmor, Magma] = 0;                                  
$ItemMax[sarmor, Shockwave] = 1;                                  
$ItemMax[sarmor, Nitro] = 1;                                      
$ItemMax[sarmor, FireMortar] = 0;                                 
$ItemMax[sarmor, ContactMortar] = 0;                              
$ItemMax[sarmor, AirRaid] = 0;                                   
$ItemMax[sarmor, TimeBomb] = 1;                                  
$ItemMax[sarmor, AtomicBomb] = 0;                                 
$ItemMax[sarmor, ClashRocket] = 1;                                
$ItemMax[sarmor, ETTR] = 1;                                     
$ItemMax[sarmor, sludge] = 0;                                   
$ItemMax[sarmor, Salvo] = 0;                                     
$ItemMax[sarmor, AnarchyCannon] = 0;                              
$ItemMax[sarmor, Claymore] = 0;                                   
$ItemMax[sarmor, HybridMortar] = 0;                               
$ItemMax[sarmor, HybridCannon] = 0;                               
$ItemMax[sarmor, HybridRocketLauncher] = 0;                      
$ItemMax[sarmor, HybridQuadLauncher] = 0; 
##############################################################################
## Misc Devices
##############################################################################
$ItemMax[sarmor, RepairKit] = 20;
$ItemMax[sarmor, MineAmmo] = 3;
$ItemMax[sarmor, Grenade] = 50;
$ItemMax[sarmor, Beacon]  = 50;
##############################################################################
## Ammunition
##############################################################################
$ItemMax[sarmor, BulletAmmo] = 150;
$ItemMax[sarmor, PlasmaAmmo] = 30;
$ItemMax[sarmor, GrenadeAmmo] = 20;
$ItemMax[sarmor, MortarAmmo] = 0;
$ItemMax[sarmor, DiscLauncherAmmo] = 0;
$ItemMax[sarmor, HellStormAmmo] = 0;
$ItemMax[sarmor, GlockAmmo] = 20;
$ItemMax[sarmor, WTShotgunAmmo] = 0;
$ItemMax[sarmor, ParticalShotgunAmmo] = 20;
$ItemMax[sarmor, SXHAmmo] = 25;
$ItemMax[sarmor, HavocAmmo] = 15;
$ItemMax[sarmor, HybridRailAmmo] = 0;
$ItemMax[sarmor, MinigunAmmo] = 150;
$ItemMax[sarmor, ShardGunAmmo] = 0;
$ItemMax[sarmor, DFMIYAAmmo] = 150;
$ItemMax[sarmor, DestroyerAmmo] = 150;
$ItemMax[sarmor, ARPGAmmo] = 0;
$ItemMax[sarmor, HybridChainAmmo] = 0;
$ItemMax[sarmor, BlazeAmmo] = 200;
$ItemMax[sarmor, PlasmaGatAmmo] = 0;
$ItemMax[sarmor, SAStealthAmmo] = 0;
$ItemMax[sarmor, NapalmLauncherAmmo] = 10;
$ItemMax[sarmor, NapalmRocketAmmo] = 20;
$ItemMax[sarmor, MagmaAmmo] = 0;
$ItemMax[sarmor, ShockWaveCAmmo] = 20;
$ItemMax[sarmor, NitroAmmo] = 25;
$ItemMax[sarmor, FireMortarAmmo] = 0;
$ItemMax[sarmor, ContactMortarAmmo] = 0;
$ItemMax[sarmor, AirRaidAmmo] = 0;
$ItemMax[sarmor, TimeBombAmmo] = 10;
$ItemMax[sarmor, AtomicBombAmmo] = 0;
$ItemMax[sarmor, ClashRocketAmmo] = 20;
$ItemMax[sarmor, ETTRAmmo] = 666;
$ItemMax[sarmor, SludgeAmmo] = 0;
$ItemMax[sarmor, SalvoAmmo] = 0;
$ItemMax[sarmor, ClaymoreAmmo] = 0;
$ItemMax[sarmor, HybridMortarAmmo] = 0;
$ItemMax[sarmor, HybridCannonAmmo] = 0;
$ItemMax[sarmor, HybridRocketLauncherAmmo] = 0;
$ItemMax[sarmor, HybridQuadAmmo] = 0;
#####################################################################
## Tactical BackPacks
#####################################################################
$ItemMax[sarmor, EnergyPack] = 1;
$ItemMax[sarmor, RepairPack] = 0;
$ItemMax[sarmor, ShieldPack] = 0;
$ItemMax[sarmor, StealthShieldPack] = 1;
$ItemMax[sarmor, AmmoPack] = 1;
$ItemMax[sarmor, XTremePack] = 0;
$ItemMax[sarmor, AntiGravPack] = 0;
$ItemMax[sarmor, MCChargerPack] = 1;
#####################################################################
## Deployables
#####################################################################
$ItemMax[sarmor, DeployableInvPack] = 0;
$ItemMax[sarmor, DeployableAmmoPack] = 0;
$ItemMax[sarmor, AirBasePack] = 0;
$ItemMax[sarmor, RemoteBase] = 0;
$ItemMax[sarmor, BlastDoorpack] = 0;
$ItemMax[sarmor, plat] = 0;
$ItemMax[sarmor, plat2] = 0;
$ItemMax[sarmor, lgbForceFieldPack] = 0;
$ItemMax[sarmor, medaForceFieldPack] = 0;
$ItemMax[sarmor, medbForceFieldPack] = 0;
$ItemMax[sarmor, medcForceFieldPack] = 1;
$ItemMax[sarmor, MotionSensorPack] = 1;
$ItemMax[sarmor, PulseSensorPack] = 1;
$ItemMax[sarmor, DeployableSensorJammerPack] = 1;
$ItemMax[sarmor, CameraPack] = 1;
#####################################################################
## Turrets
#####################################################################
$ItemMax[sarmor, TurretPack] = 0;
$ItemMax[sarmor, LaserTurretPack] = 0;
$ItemMax[sarmor, MaliceTurretPack] = 0;
$ItemMax[sarmor, LaserTurretBPack] = 0;
$ItemMax[sarmor, ARPGTurretPack] = 0;
$ItemMax[sarmor, MiniFlakTurretPack] = 0;
$ItemMax[sarmor, MiniSamTurretPack] = 0;
$ItemMax[sarmor, ElectricWeb] = 0;

$MaxWeapons[sarmor] = 6;


##############################################################################
## Battalion Warrior Arsenal
##############################################################################
$ItemMax[larmor, Blaster] = 1;                                
$ItemMax[larmor, Chaingun] = 1;                                
$ItemMax[larmor, PlasmaGun] = 1;                                
$ItemMax[larmor, GrenadeLauncher] = 1;                         
$ItemMax[larmor, Mortar] = 1;                                     
$ItemMax[larmor, DiscLauncher] = 1;                             
$ItemMax[larmor, LaserRifle] = 1;                                 
$ItemMax[larmor, Charger] = 1;                                    
$ItemMax[larmor, FusionRifle] = 1;                              
$ItemMax[larmor, ShockRfile] = 1;                               
$ItemMax[larmor, RadiationRifle] = 1;                            
$ItemMax[larmor, DiscoRifle] = 0;                                                             
$ItemMax[larmor, GatLaser] = 1;                                  
$ItemMax[larmor, GrazerCannon] = 0;                               
$ItemMax[larmor, HybridLaser] = 0;                              
$ItemMax[larmor, Grappling] = 1;                               
$ItemMax[larmor, QuakeBlaster] = 0;                                                          
$ItemMax[larmor, HellStorm] = 0;                                
$ItemMax[larmor, FusionCannon] = 0;                              
$ItemMax[larmor, MultiCannon] = 1;                                
$ItemMax[larmor, Glock] = 0;                                      
$ItemMax[larmor, WTShotgun] = 1;                                 
$ItemMax[larmor, ParticalShotgun] = 1;                           
$ItemMax[larmor, SXH] = 1;                                      
$ItemMax[larmor, Havoc] = 1;                                   
$ItemMax[larmor, HybridRail] = 0;                                 
$ItemMax[larmor, Minigun] = 0;                                   
$ItemMax[larmor, ShardGun] = 0;                                  
$ItemMax[larmor, DFMIYA] = 0;                                  
$ItemMax[larmor, Destroyer] = 0;                                  
$ItemMax[larmor, ARPG] = 1;                                     
$ItemMax[larmor, HybridChain] = 0;                              
$ItemMax[larmor, PlasmaBlaster] = 1;                            
$ItemMax[larmor, Blaze] = 1;                                    
$ItemMax[larmor, PlasmaGat] = 1;                              
$ItemMax[larmor, MeltLaser] = 1;                             
$ItemMax[larmor, SAStealth] = 0;                               
$ItemMax[larmor, NapalmLauncher] = 1;                           
$ItemMax[larmor, NapalmRocket] = 1;                             
$ItemMax[larmor, Magma] = 0;                                  
$ItemMax[larmor, Shockwave] = 0;                                  
$ItemMax[larmor, Nitro] = 1;                                      
$ItemMax[larmor, FireMortar] = 0;                                 
$ItemMax[larmor, ContactMortar] = 0;                              
$ItemMax[larmor, AirRaid] = 0;                                   
$ItemMax[larmor, TimeBomb] = 1;                                  
$ItemMax[larmor, AtomicBomb] = 0;                                 
$ItemMax[larmor, ClashRocket] = 1;                                
$ItemMax[larmor, ETTR] = 0;                                     
$ItemMax[larmor, sludge] = 1;                                   
$ItemMax[larmor, Salvo] = 0;                                     
$ItemMax[larmor, AnarchyCannon] = 0;                              
$ItemMax[larmor, Claymore] = 0;                                   
$ItemMax[larmor, HybridMortar] = 0;                               
$ItemMax[larmor, HybridCannon] = 0;                               
$ItemMax[larmor, HybridRocketLauncher] = 0;                      
$ItemMax[larmor, HybridQuadLauncher] = 0; 
##############################################################################
## Misc Devices
##############################################################################
$ItemMax[larmor, RepairKit] = 20;
$ItemMax[larmor, MineAmmo] = 3;
$ItemMax[larmor, Grenade] = 50;
$ItemMax[larmor, Beacon]  = 50;
##############################################################################
## Ammunition
##############################################################################
$ItemMax[larmor, BulletAmmo] = 200;
$ItemMax[larmor, PlasmaAmmo] = 35;
$ItemMax[larmor, GrenadeAmmo] = 25;
$ItemMax[larmor, MortarAmmo] = 15;
$ItemMax[larmor, DiscLauncherAmmo] = 25;
$ItemMax[larmor, HellStormAmmo] = 0;
$ItemMax[larmor, GlockAmmo] = 25;
$ItemMax[larmor, WTShotgunAmmo] = 25;
$ItemMax[larmor, ParticalShotgunAmmo] = 25;
$ItemMax[larmor, SXHAmmo] = 25;
$ItemMax[larmor, HavocAmmo] = 20;
$ItemMax[larmor, HybridRailAmmo] = 0;
$ItemMax[larmor, MinigunAmmo] = 0;
$ItemMax[larmor, ShardGunAmmo] = 0;
$ItemMax[larmor, DFMIYAAmmo] = 0;
$ItemMax[larmor, DestroyerAmmo] = 0;
$ItemMax[larmor, ARPGAmmo] = 45;
$ItemMax[larmor, HybridChainAmmo] = 0;
$ItemMax[larmor, BlazeAmmo] = 250;
$ItemMax[larmor, PlasmaGatAmmo] = 125;
$ItemMax[larmor, SAStealthAmmo] = 0;
$ItemMax[larmor, NapalmLauncherAmmo] = 15;
$ItemMax[larmor, NapalmRocketAmmo] = 25;
$ItemMax[larmor, MagmaAmmo] = 0;
$ItemMax[larmor, ShockWaveCAmmo] = 0;
$ItemMax[larmor, NitroAmmo] = 50;
$ItemMax[larmor, FireMortarAmmo] = 0;
$ItemMax[larmor, ContactMortarAmmo] = 0;
$ItemMax[larmor, AirRaidAmmo] = 0;
$ItemMax[larmor, TimeBombAmmo] = 10;
$ItemMax[larmor, AtomicBombAmmo] = 0;
$ItemMax[larmor, ClashRocketAmmo] = 25;
$ItemMax[larmor, ETTRAmmo] = 0;
$ItemMax[larmor, SludgeAmmo] = 15;
$ItemMax[larmor, SalvoAmmo] = 0;
$ItemMax[larmor, ClaymoreAmmo] = 0;
$ItemMax[larmor, HybridMortarAmmo] = 0;
$ItemMax[larmor, HybridCannonAmmo] = 0;
$ItemMax[larmor, HybridRocketLauncherAmmo] = 0;
$ItemMax[larmor, HybridQuadAmmo] = 0;
#####################################################################
## Tactical BackPacks
#####################################################################
$ItemMax[larmor, EnergyPack] = 1;
$ItemMax[larmor, RepairPack] = 1;
$ItemMax[larmor, ShieldPack] = 1;
$ItemMax[larmor, StealthShieldPack] = 0;
$ItemMax[larmor, AmmoPack] = 1;
$ItemMax[larmor, XTremePack] = 1;
$ItemMax[larmor, AntiGravPack] = 0;
$ItemMax[larmor, MCChargerPack] = 1;
#####################################################################
## Deployables
#####################################################################
$ItemMax[larmor, DeployableInvPack] = 0;
$ItemMax[larmor, DeployableAmmoPack] = 0;
$ItemMax[larmor, AirBasePack] = 0;
$ItemMax[larmor, RemoteBase] = 0;
$ItemMax[larmor, BlastDoorpack] = 0;
$ItemMax[larmor, plat] = 0;
$ItemMax[larmor, plat2] = 0;
$ItemMax[larmor, lgbForceFieldPack] = 0;
$ItemMax[larmor, medaForceFieldPack] = 0;
$ItemMax[larmor, medbForceFieldPack] = 1;
$ItemMax[larmor, medcForceFieldPack] = 0;
$ItemMax[larmor, MotionSensorPack] = 1;
$ItemMax[larmor, PulseSensorPack] = 1;
$ItemMax[larmor, DeployableSensorJammerPack] = 0;
$ItemMax[larmor, CameraPack] = 0;
#####################################################################
## Turrets
#####################################################################
$ItemMax[larmor, TurretPack] = 1;
$ItemMax[larmor, LaserTurretPack] = 0;
$ItemMax[larmor, MaliceTurretPack] = 0;
$ItemMax[larmor, LaserTurretBPack] = 0;
$ItemMax[larmor, ARPGTurretPack] = 0;
$ItemMax[larmor, MiniFlakTurretPack] = 0;
$ItemMax[larmor, MiniSamTurretPack] = 0;
$ItemMax[larmor, ElectricWeb] = 0;

$MaxWeapons[larmor] = 10;

##############################################################################
## Deffencive Engineer Arsenal
##############################################################################
$ItemMax[marmor, Blaster] = 1;                                
$ItemMax[marmor, Chaingun] = 1;                                
$ItemMax[marmor, PlasmaGun] = 1;                                
$ItemMax[marmor, GrenadeLauncher] = 1;                         
$ItemMax[marmor, Mortar] = 0;                                     
$ItemMax[marmor, DiscLauncher] = 1;                             
$ItemMax[marmor, LaserRifle] = 0;                                 
$ItemMax[marmor, Charger] = 0;                                    
$ItemMax[marmor, FusionRifle] = 1;                              
$ItemMax[marmor, ShockRfile] = 1;                               
$ItemMax[marmor, RadiationRifle] = 0;                            
$ItemMax[marmor, DiscoRifle] = 0;                                                             
$ItemMax[marmor, GatLaser] = 1;                                  
$ItemMax[marmor, GrazerCannon] = 0;                               
$ItemMax[marmor, HybridLaser] = 0;                              
$ItemMax[marmor, Grappling] = 1;                               
$ItemMax[marmor, QuakeBlaster] = 1;                                                          
$ItemMax[marmor, HellStorm] = 0;                                
$ItemMax[marmor, FusionCannon] = 1;                              
$ItemMax[marmor, MultiCannon] = 1;                                
$ItemMax[marmor, Glock] = 1;                                      
$ItemMax[marmor, WTShotgun] = 1;                                 
$ItemMax[marmor, ParticalShotgun] = 1;                           
$ItemMax[marmor, SXH] = 1;                                      
$ItemMax[marmor, Havoc] = 0;                                   
$ItemMax[marmor, HybridRail] = 0;                                 
$ItemMax[marmor, Minigun] = 1;                                   
$ItemMax[marmor, ShardGun] = 1;                                  
$ItemMax[marmor, DFMIYA] = 1;                                  
$ItemMax[marmor, Destroyer] = 1;                                  
$ItemMax[marmor, ARPG] = 1;                                     
$ItemMax[marmor, HybridChain] = 0;                              
$ItemMax[marmor, PlasmaBlaster] = 1;                            
$ItemMax[marmor, Blaze] = 1;                                    
$ItemMax[marmor, PlasmaGat] = 1;                              
$ItemMax[marmor, MeltLaser] = 0;                             
$ItemMax[marmor, SAStealth] = 1;                               
$ItemMax[marmor, NapalmLauncher] = 1;                           
$ItemMax[marmor, NapalmRocket] = 1;                             
$ItemMax[marmor, Magma] = 0;                                  
$ItemMax[marmor, Shockwave] = 1;                                  
$ItemMax[marmor, Nitro] = 1;                                      
$ItemMax[marmor, FireMortar] = 0;                                 
$ItemMax[marmor, ContactMortar] = 0;                              
$ItemMax[marmor, AirRaid] = 0;                                   
$ItemMax[marmor, TimeBomb] = 1;                                  
$ItemMax[marmor, AtomicBomb] = 0;                                 
$ItemMax[marmor, ClashRocket] = 0;                                
$ItemMax[marmor, ETTR] = 1;                                     
$ItemMax[marmor, sludge] = 1;                                   
$ItemMax[marmor, Salvo] = 1;                                     
$ItemMax[marmor, AnarchyCannon] = 0;                              
$ItemMax[marmor, Claymore] = 0;                                   
$ItemMax[marmor, HybridMortar] = 0;                               
$ItemMax[marmor, HybridCannon] = 0;                               
$ItemMax[marmor, HybridRocketLauncher] = 0;                      
$ItemMax[marmor, HybridQuadLauncher] = 0; 
##############################################################################
## Misc Devices
##############################################################################
$ItemMax[marmor, RepairKit] = 20;
$ItemMax[marmor, MineAmmo] = 3;
$ItemMax[marmor, Grenade] = 50;
$ItemMax[marmor, Beacon]  = 50;
##############################################################################
## Ammunition
##############################################################################
$ItemMax[marmor, BulletAmmo] = 250;
$ItemMax[marmor, PlasmaAmmo] = 40;
$ItemMax[marmor, GrenadeAmmo] = 30;
$ItemMax[marmor, MortarAmmo] = 0;
$ItemMax[marmor, DiscLauncherAmmo] = 30;
$ItemMax[marmor, HellStormAmmo] = 0;
$ItemMax[marmor, GlockAmmo] = 20;
$ItemMax[marmor, WTShotgunAmmo] = 25;
$ItemMax[marmor, ParticalShotgunAmmo] = 25;
$ItemMax[marmor, SXHAmmo] = 30;
$ItemMax[marmor, HavocAmmo] = 0;
$ItemMax[marmor, HybridRailAmmo] = 0;
$ItemMax[marmor, MinigunAmmo] = 225;
$ItemMax[marmor, ShardGunAmmo] = 225;
$ItemMax[marmor, DFMIYAAmmo] = 225;
$ItemMax[marmor, DestroyerAmmo] = 225;
$ItemMax[marmor, ARPGAmmo] = 60;
$ItemMax[marmor, HybridChainAmmo] = 0;
$ItemMax[marmor, BlazeAmmo] = 275;
$ItemMax[marmor, PlasmaGatAmmo] = 150;
$ItemMax[marmor, SAStealthAmmo] = 25;
$ItemMax[marmor, NapalmLauncherAmmo] = 15;
$ItemMax[marmor, NapalmRocketAmmo] = 25;
$ItemMax[marmor, MagmaAmmo] = 0;
$ItemMax[marmor, ShockWaveCAmmo] = 30;
$ItemMax[marmor, NitroAmmo] = 75;
$ItemMax[marmor, FireMortarAmmo] = 10;
$ItemMax[marmor, ContactMortarAmmo] = 15;
$ItemMax[marmor, AirRaidAmmo] = 0;
$ItemMax[marmor, TimeBombAmmo] = 10;
$ItemMax[marmor, AtomicBombAmmo] = 0;
$ItemMax[marmor, ClashRocketAmmo] = 0;
$ItemMax[marmor, ETTRAmmo] = 666;
$ItemMax[marmor, SludgeAmmo] = 15;
$ItemMax[marmor, SalvoAmmo] = 18;
$ItemMax[marmor, ClaymoreAmmo] = 0;
$ItemMax[marmor, HybridMortarAmmo] = 0;
$ItemMax[marmor, HybridCannonAmmo] = 0;
$ItemMax[marmor, HybridRocketLauncherAmmo] = 0;
$ItemMax[marmor, HybridQuadAmmo] = 0;
#####################################################################
## Tactical BackPacks
#####################################################################
$ItemMax[marmor, EnergyPack] = 0;
$ItemMax[marmor, RepairPack] = 1;
$ItemMax[marmor, ShieldPack] = 1;
$ItemMax[marmor, StealthShieldPack] = 0;
$ItemMax[marmor, AmmoPack] = 0;
$ItemMax[marmor, XTremePack] = 1;
$ItemMax[marmor, AntiGravPack] = 0;
$ItemMax[marmor, MCChargerPack] = 1;
#####################################################################
## Deployables
#####################################################################
$ItemMax[marmor, DeployableInvPack] = 1;
$ItemMax[marmor, DeployableAmmoPack] = 1;
$ItemMax[marmor, AirBasePack] = 1;
$ItemMax[marmor, RemoteBase] = 1;
$ItemMax[marmor, BlastDoorpack] = 1;
$ItemMax[marmor, plat] = 1;
$ItemMax[marmor, plat2] = 1;
$ItemMax[marmor, lgbForceFieldPack] = 1;
$ItemMax[marmor, medaForceFieldPack] = 1;
$ItemMax[marmor, medbForceFieldPack] = 1;
$ItemMax[marmor, medcForceFieldPack] = 1;
$ItemMax[marmor, MotionSensorPack] = 1;
$ItemMax[marmor, PulseSensorPack] = 1;
$ItemMax[marmor, DeployableSensorJammerPack] = 1;
$ItemMax[marmor, CameraPack] = 1;
#####################################################################
## Turrets
#####################################################################
$ItemMax[marmor, TurretPack] = 1;
$ItemMax[marmor, LaserTurretPack] = 1;
$ItemMax[marmor, MaliceTurretPack] = 1;
$ItemMax[marmor, LaserTurretBPack] = 1;
$ItemMax[marmor, ARPGTurretPack] = 1;
$ItemMax[marmor, MiniFlakTurretPack] = 1;
$ItemMax[marmor, MiniSamTurretPack] = 1;
$ItemMax[marmor, ElectricWeb] = 1;

$MaxWeapons[marmor] = 9;

##############################################################################
## Armageddon Mech Arsenal
##############################################################################
$ItemMax[harmor, Blaster] = 0;                                
$ItemMax[harmor, Chaingun] = 0;                                
$ItemMax[harmor, PlasmaGun] = 0;                                
$ItemMax[harmor, GrenadeLauncher] = 0;                         
$ItemMax[harmor, Mortar] = 1;                                     
$ItemMax[harmor, DiscLauncher] = 1;                             
$ItemMax[harmor, LaserRifle] = 0;                                 
$ItemMax[harmor, Charger] = 0;                                    
$ItemMax[harmor, FusionRifle] = 1;                              
$ItemMax[harmor, ShockRfile] = 0;                               
$ItemMax[harmor, RadiationRifle] = 1;                            
$ItemMax[harmor, DiscoRifle] = 1;                                                             
$ItemMax[harmor, GatLaser] = 1;                                  
$ItemMax[harmor, GrazerCannon] = 1;                               
$ItemMax[harmor, HybridLaser] = 0;                              
$ItemMax[harmor, Grappling] = 1;                               
$ItemMax[harmor, QuakeBlaster] = 0;                                                          
$ItemMax[harmor, HellStorm] = 1;                                
$ItemMax[harmor, FusionCannon] = 0;                              
$ItemMax[harmor, MultiCannon] = 1;                                
$ItemMax[harmor, Glock] = 1;                                      
$ItemMax[harmor, WTShotgun] = 1;                                 
$ItemMax[harmor, ParticalShotgun] = 1;                           
$ItemMax[harmor, SXH] = 0;                                      
$ItemMax[harmor, Havoc] = 1;                                   
$ItemMax[harmor, HybridRail] = 0;                                 
$ItemMax[harmor, Minigun] = 0;                                   
$ItemMax[harmor, ShardGun] = 0;                                  
$ItemMax[harmor, DFMIYA] = 1;                                  
$ItemMax[harmor, Destroyer] = 1;                                  
$ItemMax[harmor, ARPG] = 1;                                     
$ItemMax[harmor, HybridChain] = 0;                              
$ItemMax[harmor, PlasmaBlaster] = 1;                            
$ItemMax[harmor, Blaze] = 1;                                    
$ItemMax[harmor, PlasmaGat] = 1;                              
$ItemMax[harmor, MeltLaser] = 0;                             
$ItemMax[harmor, SAStealth] = 1;                               
$ItemMax[harmor, NapalmLauncher] = 1;                           
$ItemMax[harmor, NapalmRocket] = 0;                             
$ItemMax[harmor, Magma] = 1;                                  
$ItemMax[harmor, Shockwave] = 1;                                  
$ItemMax[harmor, Nitro] = 1;                                      
$ItemMax[harmor, FireMortar] = 1;                                 
$ItemMax[harmor, ContactMortar] = 1;                              
$ItemMax[harmor, AirRaid] = 1;                                   
$ItemMax[harmor, TimeBomb] = 1;                                  
$ItemMax[harmor, AtomicBomb] = 1;                                 
$ItemMax[harmor, ClashRocket] = 0;                                
$ItemMax[harmor, ETTR] = 0;                                     
$ItemMax[harmor, sludge] = 1;                                   
$ItemMax[harmor, Salvo] = 1;                                     
$ItemMax[harmor, AnarchyCannon] = 1;                              
$ItemMax[harmor, Claymore] = 1;                                   
$ItemMax[harmor, HybridMortar] = 0;                               
$ItemMax[harmor, HybridCannon] = 0;                               
$ItemMax[harmor, HybridRocketLauncher] = 0;                      
$ItemMax[harmor, HybridQuadLauncher] = 0; 
##############################################################################
## Misc Devices
##############################################################################
$ItemMax[harmor, RepairKit] = 30;
$ItemMax[harmor, MineAmmo] = 3;
$ItemMax[harmor, Grenade] = 50;
$ItemMax[harmor, Beacon]  = 50;
##############################################################################
## Ammunition
##############################################################################
$ItemMax[harmor, BulletAmmo] = 0;
$ItemMax[harmor, PlasmaAmmo] = 0;
$ItemMax[harmor, GrenadeAmmo] = 0;
$ItemMax[harmor, MortarAmmo] = 25;
$ItemMax[harmor, DiscLauncherAmmo] = 35;
$ItemMax[harmor, HellStormAmmo] = 1;
$ItemMax[harmor, GlockAmmo] = 30;
$ItemMax[harmor, WTShotgunAmmo] = 30;
$ItemMax[harmor, ParticalShotgunAmmo] = 30;
$ItemMax[harmor, SXHAmmo] = 0;
$ItemMax[harmor, HavocAmmo] = 30;
$ItemMax[harmor, HybridRailAmmo] = 0;
$ItemMax[harmor, MinigunAmmo] = 0;
$ItemMax[harmor, ShardGunAmmo] = 0;
$ItemMax[harmor, DFMIYAAmmo] = 300;
$ItemMax[harmor, DestroyerAmmo] = 300;
$ItemMax[harmor, ARPGAmmo] = 70;
$ItemMax[harmor, HybridChainAmmo] = 0;
$ItemMax[harmor, BlazeAmmo] = 300;
$ItemMax[harmor, PlasmaGatAmmo] = 300;
$ItemMax[harmor, SAStealthAmmo] = 25;
$ItemMax[harmor, NapalmLauncherAmmo] = 10;
$ItemMax[harmor, NapalmRocketAmmo] = 0;
$ItemMax[harmor, MagmaAmmo] = 150;
$ItemMax[harmor, ShockWaveCAmmo] = 35;
$ItemMax[harmor, NitroAmmo] = 100;
$ItemMax[harmor, FireMortarAmmo] = 15;
$ItemMax[harmor, ContactMortarAmmo] = 15;
$ItemMax[harmor, AirRaidAmmo] = 15;
$ItemMax[harmor, TimeBombAmmo] = 10;
$ItemMax[harmor, AtomicBombAmmo] = 3;
$ItemMax[harmor, ClashRocketAmmo] = 0;
$ItemMax[harmor, ETTRAmmo] = 0;
$ItemMax[harmor, SludgeAmmo] = 20;
$ItemMax[harmor, SalvoAmmo] = 24;
$ItemMax[harmor, ClaymoreAmmo] = 20;
$ItemMax[harmor, HybridMortarAmmo] = 0;
$ItemMax[harmor, HybridCannonAmmo] = 0;
$ItemMax[harmor, HybridRocketLauncherAmmo] = 0;
$ItemMax[harmor, HybridQuadAmmo] = 0;
#####################################################################
## Tactical BackPacks
#####################################################################
$ItemMax[harmor, EnergyPack] = 0;
$ItemMax[harmor, RepairPack] = 0;
$ItemMax[harmor, ShieldPack] = 0;
$ItemMax[harmor, StealthShieldPack] = 0;
$ItemMax[harmor, AmmoPack] = 1;
$ItemMax[harmor, XTremePack] = 1;
$ItemMax[harmor, AntiGravPack] = 1;
$ItemMax[harmor, MCChargerPack] = 1;
#####################################################################
## Deployables
#####################################################################
$ItemMax[harmor, DeployableInvPack] = 0;
$ItemMax[harmor, DeployableAmmoPack] = 0;
$ItemMax[harmor, AirBasePack] = 0;
$ItemMax[harmor, RemoteBase] = 0;
$ItemMax[harmor, BlastDoorpack] = 1;
$ItemMax[harmor, plat] = 1;
$ItemMax[harmor, plat2] = 0;
$ItemMax[harmor, lgbForceFieldPack] = 1;
$ItemMax[harmor, medaForceFieldPack] = 0;
$ItemMax[harmor, medbForceFieldPack] = 1;
$ItemMax[harmor, medcForceFieldPack] = 1;
$ItemMax[harmor, MotionSensorPack] = 0;
$ItemMax[harmor, PulseSensorPack] = 0;
$ItemMax[harmor, DeployableSensorJammerPack] = 0;
$ItemMax[harmor, CameraPack] = 0;
#####################################################################
## Turrets
#####################################################################
$ItemMax[harmor, TurretPack] = 0;
$ItemMax[harmor, LaserTurretPack] = 0;
$ItemMax[harmor, MaliceTurretPack] = 0;
$ItemMax[harmor, LaserTurretBPack] = 0;
$ItemMax[harmor, ARPGTurretPack] = 0;
$ItemMax[harmor, MiniFlakTurretPack] = 0;
$ItemMax[harmor, MiniSamTurretPack] = 1;
$ItemMax[harmor, ElectricWeb] = 0;

$MaxWeapons[harmor] = 12;

##############################################################################
## Hybrid Destroyer Arsenal
##############################################################################
$ItemMax[narmor, Blaster] = 0;                                
$ItemMax[narmor, Chaingun] = 0;                                
$ItemMax[narmor, PlasmaGun] = 0;                                
$ItemMax[narmor, GrenadeLauncher] = 0;                         
$ItemMax[narmor, Mortar] = 1;                                     
$ItemMax[narmor, DiscLauncher] = 1;                             
$ItemMax[narmor, LaserRifle] = 0;                                 
$ItemMax[narmor, Charger] = 0;                                    
$ItemMax[narmor, FusionRifle] = 0;                              
$ItemMax[narmor, ShockRfile] = 0;                               
$ItemMax[narmor, RadiationRifle] = 1;                            
$ItemMax[narmor, DiscoRifle] = 1;                                                             
$ItemMax[narmor, GatLaser] = 1;                                  
$ItemMax[narmor, GrazerCannon] = 1;                               
$ItemMax[narmor, HybridLaser] = 1;                              
$ItemMax[narmor, Grappling] = 1;                               
$ItemMax[narmor, QuakeBlaster] = 1;                                                          
$ItemMax[narmor, HellStorm] = 0;                                
$ItemMax[narmor, FusionCannon] = 0;                              
$ItemMax[narmor, MultiCannon] = 1;                                
$ItemMax[narmor, Glock] = 0;                                      
$ItemMax[narmor, WTShotgun] = 0;                                 
$ItemMax[narmor, ParticalShotgun] = 0;                           
$ItemMax[narmor, SXH] = 0;                                      
$ItemMax[narmor, Havoc] = 0;                                   
$ItemMax[narmor, HybridRail] = 1;                                 
$ItemMax[narmor, Minigun] = 0;                                   
$ItemMax[narmor, ShardGun] = 0;                                  
$ItemMax[narmor, DFMIYA] = 1;                                  
$ItemMax[narmor, Destroyer] = 1;                                  
$ItemMax[narmor, ARPG] = 1;                                     
$ItemMax[narmor, HybridChain] = 1;                              
$ItemMax[narmor, PlasmaBlaster] = 1;                            
$ItemMax[narmor, Blaze] = 1;                                    
$ItemMax[narmor, PlasmaGat] = 1;                              
$ItemMax[narmor, MeltLaser] = 0;                             
$ItemMax[narmor, SAStealth] = 0;                               
$ItemMax[narmor, NapalmLauncher] = 1;                           
$ItemMax[narmor, NapalmRocket] = 0;                             
$ItemMax[narmor, Magma] = 0;                                  
$ItemMax[narmor, Shockwave] = 0;                                  
$ItemMax[narmor, Nitro] = 1;                                      
$ItemMax[narmor, FireMortar] = 1;                                 
$ItemMax[narmor, ContactMortar] = 1;                              
$ItemMax[narmor, AirRaid] = 1;                                   
$ItemMax[narmor, TimeBomb] = 1;                                  
$ItemMax[narmor, AtomicBomb] = 1;                                 
$ItemMax[narmor, ClashRocket] = 0;                                
$ItemMax[narmor, ETTR] = 0;                                     
$ItemMax[narmor, sludge] = 0;                                   
$ItemMax[narmor, Salvo] = 1;                                     
$ItemMax[narmor, AnarchyCannon] = 1;                              
$ItemMax[narmor, Claymore] = 1;                                   
$ItemMax[narmor, HybridMortar] = 1;                               
$ItemMax[narmor, HybridCannon] = 1;                               
$ItemMax[narmor, HybridRocketLauncher] = 1;                      
$ItemMax[narmor, HybridQuadLauncher] = 1; 
##############################################################################
## Misc Devices
##############################################################################
$ItemMax[narmor, RepairKit] = 30;
$ItemMax[narmor, MineAmmo] = 3;
$ItemMax[narmor, Grenade] = 50;
$ItemMax[narmor, Beacon]  = 50;
##############################################################################
## Ammunition
##############################################################################
$ItemMax[narmor, BulletAmmo] = 0;
$ItemMax[narmor, PlasmaAmmo] = 0;
$ItemMax[narmor, GrenadeAmmo] = 0;
$ItemMax[narmor, MortarAmmo] = 30;
$ItemMax[narmor, DiscLauncherAmmo] = 40;
$ItemMax[narmor, HellStormAmmo] = 1;
$ItemMax[narmor, GlockAmmo] = 0;
$ItemMax[narmor, WTShotgunAmmo] = 0;
$ItemMax[narmor, ParticalShotgunAmmo] = 0;
$ItemMax[narmor, SXHAmmo] = 0;
$ItemMax[narmor, HavocAmmo] = 0;
$ItemMax[narmor, HybridRailAmmo] = 40;
$ItemMax[narmor, MinigunAmmo] = 0;
$ItemMax[narmor, ShardGunAmmo] = 0;
$ItemMax[narmor, DFMIYAAmmo] = 350;
$ItemMax[narmor, DestroyerAmmo] = 350;
$ItemMax[narmor, ARPGAmmo] = 85;
$ItemMax[narmor, HybridChainAmmo] = 9999;
$ItemMax[narmor, BlazeAmmo] = 325;
$ItemMax[narmor, PlasmaGatAmmo] = 350;
$ItemMax[narmor, SAStealthAmmo] = 0;
$ItemMax[narmor, NapalmLauncherAmmo] = 20;
$ItemMax[narmor, NapalmRocketAmmo] = 0;
$ItemMax[narmor, MagmaAmmo] = 0;
$ItemMax[narmor, ShockWaveCAmmo] = 0;
$ItemMax[narmor, NitroAmmo] = 150;
$ItemMax[narmor, FireMortarAmmo] = 20;
$ItemMax[narmor, ContactMortarAmmo] = 20;
$ItemMax[narmor, AirRaidAmmo] = 20;
$ItemMax[narmor, TimeBombAmmo] = 15;
$ItemMax[narmor, AtomicBombAmmo] = 4;
$ItemMax[narmor, ClashRocketAmmo] = 0;
$ItemMax[narmor, ETTRAmmo] = 0;
$ItemMax[narmor, SludgeAmmo] = 0;
$ItemMax[narmor, SalvoAmmo] = 30;
$ItemMax[narmor, ClaymoreAmmo] = 25;
$ItemMax[narmor, HybridMortarAmmo] = 120;
$ItemMax[narmor, HybridCannonAmmo] = 50;
$ItemMax[narmor, HybridRocketLauncherAmmo] = 100;
$ItemMax[narmor, HybridQuadAmmo] = 100;
#####################################################################
## Tactical BackPacks
#####################################################################
$ItemMax[narmor, EnergyPack] = 0;
$ItemMax[narmor, RepairPack] = 1;
$ItemMax[narmor, ShieldPack] = 0;
$ItemMax[narmor, StealthShieldPack] = 0;
$ItemMax[narmor, AmmoPack] = 1;
$ItemMax[narmor, XTremePack] = 1;
$ItemMax[narmor, AntiGravPack] = 0;
$ItemMax[narmor, MCChargerPack] = 1;
#####################################################################
## Deployables
#####################################################################
$ItemMax[narmor, DeployableInvPack] = 0;
$ItemMax[narmor, DeployableAmmoPack] = 0;
$ItemMax[narmor, AirBasePack] = 0;
$ItemMax[narmor, RemoteBase] = 0;
$ItemMax[narmor, BlastDoorpack] = 1;
$ItemMax[narmor, plat] = 0;
$ItemMax[narmor, plat2] = 0;
$ItemMax[narmor, lgbForceFieldPack] = 1;
$ItemMax[narmor, medaForceFieldPack] = 0;
$ItemMax[narmor, medbForceFieldPack] = 0;
$ItemMax[narmor, medcForceFieldPack] = 0;
$ItemMax[narmor, MotionSensorPack] = 1;
$ItemMax[narmor, PulseSensorPack] = 1;
$ItemMax[narmor, DeployableSensorJammerPack] = 0;
$ItemMax[narmor, CameraPack] = 1;
#####################################################################
## Turrets
#####################################################################
$ItemMax[narmor, TurretPack] = 0;
$ItemMax[narmor, LaserTurretPack] = 0;
$ItemMax[narmor, MaliceTurretPack] = 0;
$ItemMax[narmor, LaserTurretBPack] = 0;
$ItemMax[narmor, ARPGTurretPack] = 0;
$ItemMax[narmor, MiniFlakTurretPack] = 1;
$ItemMax[narmor, MiniSamTurretPack] = 1;
$ItemMax[narmor, ElectricWeb] = 0;

$MaxWeapons[narmor] = 12;


##############################################################################
## Battalion Warrior Arsenal -=- Female
##############################################################################
$ItemMax[lfemale, Blaster] = 1;                                
$ItemMax[lfemale, Chaingun] = 1;                                
$ItemMax[lfemale, PlasmaGun] = 1;                                
$ItemMax[lfemale, GrenadeLauncher] = 1;                         
$ItemMax[lfemale, Mortar] = 1;                                     
$ItemMax[lfemale, DiscLauncher] = 1;                             
$ItemMax[lfemale, LaserRifle] = 1;                                 
$ItemMax[lfemale, Charger] = 1;                                    
$ItemMax[lfemale, FusionRifle] = 1;                              
$ItemMax[lfemale, ShockRfile] = 1;                               
$ItemMax[lfemale, RadiationRifle] = 1;                            
$ItemMax[lfemale, DiscoRifle] = 0;                                                             
$ItemMax[lfemale, GatLaser] = 1;                                  
$ItemMax[lfemale, GrazerCannon] = 0;                               
$ItemMax[lfemale, HybridLaser] = 0;                              
$ItemMax[lfemale, Grappling] = 1;                               
$ItemMax[lfemale, QuakeBlaster] = 0;                                                          
$ItemMax[lfemale, HellStorm] = 0;                                
$ItemMax[lfemale, FusionCannon] = 0;                              
$ItemMax[lfemale, MultiCannon] = 1;                                
$ItemMax[lfemale, Glock] = 0;                                      
$ItemMax[lfemale, WTShotgun] = 1;                                 
$ItemMax[lfemale, ParticalShotgun] = 1;                           
$ItemMax[lfemale, SXH] = 1;                                      
$ItemMax[lfemale, Havoc] = 1;                                   
$ItemMax[lfemale, HybridRail] = 0;                                 
$ItemMax[lfemale, Minigun] = 0;                                   
$ItemMax[lfemale, ShardGun] = 0;                                  
$ItemMax[lfemale, DFMIYA] = 0;                                  
$ItemMax[lfemale, Destroyer] = 0;                                  
$ItemMax[lfemale, ARPG] = 1;                                     
$ItemMax[lfemale, HybridChain] = 0;                              
$ItemMax[lfemale, PlasmaBlaster] = 1;                            
$ItemMax[lfemale, Blaze] = 1;                                    
$ItemMax[lfemale, PlasmaGat] = 1;                              
$ItemMax[lfemale, MeltLaser] = 1;                             
$ItemMax[lfemale, SAStealth] = 0;                               
$ItemMax[lfemale, NapalmLauncher] = 1;                           
$ItemMax[lfemale, NapalmRocket] = 1;                             
$ItemMax[lfemale, Magma] = 0;                                  
$ItemMax[lfemale, Shockwave] = 0;                                  
$ItemMax[lfemale, Nitro] = 1;                                      
$ItemMax[lfemale, FireMortar] = 0;                                 
$ItemMax[lfemale, ContactMortar] = 0;                              
$ItemMax[lfemale, AirRaid] = 0;                                   
$ItemMax[lfemale, TimeBomb] = 1;                                  
$ItemMax[lfemale, AtomicBomb] = 0;                                 
$ItemMax[lfemale, ClashRocket] = 1;                                
$ItemMax[lfemale, ETTR] = 0;                                     
$ItemMax[lfemale, sludge] = 1;                                   
$ItemMax[lfemale, Salvo] = 0;                                     
$ItemMax[lfemale, AnarchyCannon] = 0;                              
$ItemMax[lfemale, Claymore] = 0;                                   
$ItemMax[lfemale, HybridMortar] = 0;                               
$ItemMax[lfemale, HybridCannon] = 0;                               
$ItemMax[lfemale, HybridRocketLauncher] = 0;                      
$ItemMax[lfemale, HybridQuadLauncher] = 0; 
##############################################################################
## Misc Devices
##############################################################################
$ItemMax[lfemale, RepairKit] = 20;
$ItemMax[lfemale, MineAmmo] = 3;
$ItemMax[lfemale, Grenade] = 50;
$ItemMax[lfemale, Beacon]  = 50;
##############################################################################
## Ammunition
##############################################################################
$ItemMax[lfemale, BulletAmmo] = 200;
$ItemMax[lfemale, PlasmaAmmo] = 35;
$ItemMax[lfemale, GrenadeAmmo] = 25;
$ItemMax[lfemale, MortarAmmo] = 15;
$ItemMax[lfemale, DiscLauncherAmmo] = 25;
$ItemMax[lfemale, HellStormAmmo] = 0;
$ItemMax[lfemale, GlockAmmo] = 25;
$ItemMax[lfemale, WTShotgunAmmo] = 25;
$ItemMax[lfemale, ParticalShotgunAmmo] = 25;
$ItemMax[lfemale, SXHAmmo] = 25;
$ItemMax[lfemale, HavocAmmo] = 20;
$ItemMax[lfemale, HybridRailAmmo] = 0;
$ItemMax[lfemale, MinigunAmmo] = 0;
$ItemMax[lfemale, ShardGunAmmo] = 0;
$ItemMax[lfemale, DFMIYAAmmo] = 0;
$ItemMax[lfemale, DestroyerAmmo] = 0;
$ItemMax[lfemale, ARPGAmmo] = 45;
$ItemMax[lfemale, HybridChainAmmo] = 0;
$ItemMax[lfemale, BlazeAmmo] = 250;
$ItemMax[lfemale, PlasmaGatAmmo] = 125;
$ItemMax[lfemale, SAStealthAmmo] = 20;
$ItemMax[lfemale, NapalmLauncherAmmo] = 15;
$ItemMax[lfemale, NapalmRocketAmmo] = 25;
$ItemMax[lfemale, MagmaAmmo] = 0;
$ItemMax[lfemale, ShockWaveCAmmo] = 0;
$ItemMax[lfemale, NitroAmmo] = 50;
$ItemMax[lfemale, FireMortarAmmo] = 0;
$ItemMax[lfemale, ContactMortarAmmo] = 0;
$ItemMax[lfemale, AirRaidAmmo] = 0;
$ItemMax[lfemale, TimeBombAmmo] = 10;
$ItemMax[lfemale, AtomicBombAmmo] = 0;
$ItemMax[lfemale, ClashRocketAmmo] = 25;
$ItemMax[lfemale, ETTRAmmo] = 0;
$ItemMax[lfemale, SludgeAmmo] = 15;
$ItemMax[lfemale, SalvoAmmo] = 0;
$ItemMax[lfemale, ClaymoreAmmo] = 0;
$ItemMax[lfemale, HybridMortarAmmo] = 0;
$ItemMax[lfemale, HybridCannonAmmo] = 0;
$ItemMax[lfemale, HybridRocketLauncherAmmo] = 0;
$ItemMax[lfemale, HybridQuadAmmo] = 0;
#####################################################################
## Tactical BackPacks
#####################################################################
$ItemMax[lfemale, EnergyPack] = 1;
$ItemMax[lfemale, RepairPack] = 1;
$ItemMax[lfemale, ShieldPack] = 1;
$ItemMax[lfemale, StealthShieldPack] = 0;
$ItemMax[lfemale, AmmoPack] = 1;
$ItemMax[lfemale, XTremePack] = 1;
$ItemMax[lfemale, AntiGravPack] = 0;
$ItemMax[lfemale, MCChargerPack] = 1;
#####################################################################
## Deployables
#####################################################################
$ItemMax[lfemale, DeployableInvPack] = 0;
$ItemMax[lfemale, DeployableAmmoPack] = 0;
$ItemMax[lfemale, AirBasePack] = 0;
$ItemMax[lfemale, RemoteBase] = 0;
$ItemMax[lfemale, BlastDoorpack] = 0;
$ItemMax[lfemale, plat] = 0;
$ItemMax[lfemale, plat2] = 0;
$ItemMax[lfemale, lgbForceFieldPack] = 0;
$ItemMax[lfemale, medaForceFieldPack] = 0;
$ItemMax[lfemale, medbForceFieldPack] = 1;
$ItemMax[lfemale, medcForceFieldPack] = 0;
$ItemMax[lfemale, MotionSensorPack] = 1;
$ItemMax[lfemale, PulseSensorPack] = 1;
$ItemMax[lfemale, DeployableSensorJammerPack] = 0;
$ItemMax[lfemale, CameraPack] = 0;
#####################################################################
## Turrets
#####################################################################
$ItemMax[lfemale, TurretPack] = 1;
$ItemMax[lfemale, LaserTurretPack] = 0;
$ItemMax[lfemale, MaliceTurretPack] = 0;
$ItemMax[lfemale, LaserTurretBPack] = 0;
$ItemMax[lfemale, ARPGTurretPack] = 0;
$ItemMax[lfemale, MiniFlakTurretPack] = 0;
$ItemMax[lfemale, MiniSamTurretPack] = 0;
$ItemMax[lfemale, ElectricWeb] = 0;

$MaxWeapons[lfemale] = 10;


##############################################################################
## Deffencive Engineer Arsenal  -=- Female
##############################################################################
$ItemMax[mfemale, Blaster] = 1;                                
$ItemMax[mfemale, Chaingun] = 1;                                
$ItemMax[mfemale, PlasmaGun] = 1;                                
$ItemMax[mfemale, GrenadeLauncher] = 1;                         
$ItemMax[mfemale, Mortar] = 0;                                     
$ItemMax[mfemale, DiscLauncher] = 1;                             
$ItemMax[mfemale, LaserRifle] = 0;                                 
$ItemMax[mfemale, Charger] = 0;                                    
$ItemMax[mfemale, FusionRifle] = 1;                              
$ItemMax[mfemale, ShockRfile] = 1;                               
$ItemMax[mfemale, RadiationRifle] = 0;                            
$ItemMax[mfemale, DiscoRifle] = 0;                                                             
$ItemMax[mfemale, GatLaser] = 1;                                  
$ItemMax[mfemale, GrazerCannon] = 0;                               
$ItemMax[mfemale, HybridLaser] = 0;                              
$ItemMax[mfemale, Grappling] = 1;                               
$ItemMax[mfemale, QuakeBlaster] = 1;                                                          
$ItemMax[mfemale, HellStorm] = 0;                                
$ItemMax[mfemale, FusionCannon] = 1;                              
$ItemMax[mfemale, MultiCannon] = 1;                                
$ItemMax[mfemale, Glock] = 1;                                      
$ItemMax[mfemale, WTShotgun] = 1;                                 
$ItemMax[mfemale, ParticalShotgun] = 1;                           
$ItemMax[mfemale, SXH] = 1;                                      
$ItemMax[mfemale, Havoc] = 0;                                   
$ItemMax[mfemale, HybridRail] = 0;                                 
$ItemMax[mfemale, Minigun] = 1;                                   
$ItemMax[mfemale, ShardGun] = 1;                                  
$ItemMax[mfemale, DFMIYA] = 1;                                  
$ItemMax[mfemale, Destroyer] = 1;                                  
$ItemMax[mfemale, ARPG] = 1;                                     
$ItemMax[mfemale, HybridChain] = 0;                              
$ItemMax[mfemale, PlasmaBlaster] = 1;                            
$ItemMax[mfemale, Blaze] = 1;                                    
$ItemMax[mfemale, PlasmaGat] = 1;                              
$ItemMax[mfemale, MeltLaser] = 0;                             
$ItemMax[mfemale, SAStealth] = 1;                               
$ItemMax[mfemale, NapalmLauncher] = 1;                           
$ItemMax[mfemale, NapalmRocket] = 1;                             
$ItemMax[mfemale, Magma] = 0;                                  
$ItemMax[mfemale, Shockwave] = 1;                                  
$ItemMax[mfemale, Nitro] = 1;                                      
$ItemMax[mfemale, FireMortar] = 0;                                 
$ItemMax[mfemale, ContactMortar] = 0;                              
$ItemMax[mfemale, AirRaid] = 0;                                   
$ItemMax[mfemale, TimeBomb] = 1;                                  
$ItemMax[mfemale, AtomicBomb] = 1;                                 
$ItemMax[mfemale, ClashRocket] = 0;                                
$ItemMax[mfemale, ETTR] = 1;                                     
$ItemMax[mfemale, sludge] = 1;                                   
$ItemMax[mfemale, Salvo] = 1;                                     
$ItemMax[mfemale, AnarchyCannon] = 0;                              
$ItemMax[mfemale, Claymore] = 0;                                   
$ItemMax[mfemale, HybridMortar] = 0;                               
$ItemMax[mfemale, HybridCannon] = 0;                               
$ItemMax[mfemale, HybridRocketLauncher] = 0;                      
$ItemMax[mfemale, HybridQuadLauncher] = 0; 
##############################################################################
## Misc Devices
##############################################################################
$ItemMax[mfemale, RepairKit] = 20;
$ItemMax[mfemale, MineAmmo] = 3;
$ItemMax[mfemale, Grenade] = 50;
$ItemMax[mfemale, Beacon]  = 50;
##############################################################################
## Ammunition
##############################################################################
$ItemMax[mfemale, BulletAmmo] = 250;
$ItemMax[mfemale, PlasmaAmmo] = 40;
$ItemMax[mfemale, GrenadeAmmo] = 30;
$ItemMax[mfemale, MortarAmmo] = 0;
$ItemMax[mfemale, DiscLauncherAmmo] = 30;
$ItemMax[mfemale, HellStormAmmo] = 0;
$ItemMax[mfemale, GlockAmmo] = 20;
$ItemMax[mfemale, WTShotgunAmmo] = 25;
$ItemMax[mfemale, ParticalShotgunAmmo] = 25;
$ItemMax[mfemale, SXHAmmo] = 30;
$ItemMax[mfemale, HavocAmmo] = 0;
$ItemMax[mfemale, HybridRailAmmo] = 0;
$ItemMax[mfemale, MinigunAmmo] = 225;
$ItemMax[mfemale, ShardGunAmmo] = 225;
$ItemMax[mfemale, DFMIYAAmmo] = 225;
$ItemMax[mfemale, DestroyerAmmo] = 225;
$ItemMax[mfemale, ARPGAmmo] = 60;
$ItemMax[mfemale, HybridChainAmmo] = 0;
$ItemMax[mfemale, BlazeAmmo] = 275;
$ItemMax[mfemale, PlasmaGatAmmo] = 150;
$ItemMax[mfemale, SAStealthAmmo] = 25;
$ItemMax[mfemale, NapalmLauncherAmmo] = 15;
$ItemMax[mfemale, NapalmRocketAmmo] = 25;
$ItemMax[mfemale, MagmaAmmo] = 0;
$ItemMax[mfemale, ShockWaveCAmmo] = 30;
$ItemMax[mfemale, NitroAmmo] = 75;
$ItemMax[mfemale, FireMortarAmmo] = 10;
$ItemMax[mfemale, ContactMortarAmmo] = 15;
$ItemMax[mfemale, AirRaidAmmo] = 0;
$ItemMax[mfemale, TimeBombAmmo] = 10;
$ItemMax[mfemale, AtomicBombAmmo] = 3;
$ItemMax[mfemale, ClashRocketAmmo] = 0;
$ItemMax[mfemale, ETTRAmmo] = 666;
$ItemMax[mfemale, SludgeAmmo] = 15;
$ItemMax[mfemale, SalvoAmmo] = 18;
$ItemMax[mfemale, ClaymoreAmmo] = 0;
$ItemMax[mfemale, HybridMortarAmmo] = 0;
$ItemMax[mfemale, HybridCannonAmmo] = 0;
$ItemMax[mfemale, HybridRocketLauncherAmmo] = 0;
$ItemMax[mfemale, HybridQuadAmmo] = 0;
#####################################################################
## Tactical BackPacks
#####################################################################
$ItemMax[mfemale, EnergyPack] = 0;
$ItemMax[mfemale, RepairPack] = 1;
$ItemMax[mfemale, ShieldPack] = 1;
$ItemMax[mfemale, StealthShieldPack] = 0;
$ItemMax[mfemale, AmmoPack] = 0;
$ItemMax[mfemale, XTremePack] = 1;
$ItemMax[mfemale, AntiGravPack] = 0;
$ItemMax[mfemale, MCChargerPack] = 1;
#####################################################################
## Deployables
#####################################################################
$ItemMax[mfemale, DeployableInvPack] = 1;
$ItemMax[mfemale, DeployableAmmoPack] = 1;
$ItemMax[mfemale, AirBasePack] = 1;
$ItemMax[mfemale, RemoteBase] = 1;
$ItemMax[mfemale, BlastDoorpack] = 1;
$ItemMax[mfemale, plat] = 1;
$ItemMax[mfemale, plat2] = 1;
$ItemMax[mfemale, lgbForceFieldPack] = 1;
$ItemMax[mfemale, medaForceFieldPack] = 1;
$ItemMax[mfemale, medbForceFieldPack] = 1;
$ItemMax[mfemale, medcForceFieldPack] = 1;
$ItemMax[mfemale, MotionSensorPack] = 1;
$ItemMax[mfemale, PulseSensorPack] = 1;
$ItemMax[mfemale, DeployableSensorJammerPack] = 1;
$ItemMax[mfemale, CameraPack] = 1;
#####################################################################
## Turrets
#####################################################################
$ItemMax[mfemale, TurretPack] = 1;
$ItemMax[mfemale, LaserTurretPack] = 1;
$ItemMax[mfemale, MaliceTurretPack] = 1;
$ItemMax[mfemale, LaserTurretBPack] = 1;
$ItemMax[mfemale, ARPGTurretPack] = 1;
$ItemMax[mfemale, MiniFlakTurretPack] = 1;
$ItemMax[mfemale, MiniSamTurretPack] = 1;
$ItemMax[mfemale, ElectricWeb] = 1;

$MaxWeapons[mfemale] = 9;

//------------------------------------------------------------------
// Tactical Sniper armor data:
//------------------------------------------------------------------

DamageSkinData armorDamageSkins
{
   bmpName[0] = "dskin1_armor";
   bmpName[1] = "dskin2_armor";
   bmpName[2] = "dskin3_armor";
   bmpName[3] = "dskin4_armor";
   bmpName[4] = "dskin5_armor";
   bmpName[5] = "dskin6_armor";
   bmpName[6] = "dskin7_armor";
   bmpName[7] = "dskin8_armor";
   bmpName[8] = "dskin9_armor";
   bmpName[9] = "dskin10_armor";
};

PlayerData sarmor
{
   className = "Armor";
   shapeFile = "lfemale";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "enex";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 20;
   maxJetForwardVelocity = 40;
   minJetEnergy = 1;
   jetForce = 180;
   jetEnergyDrain = 0;

	maxDamage = 0.30;
   maxForwardSpeed = 22;
   maxBackwardSpeed = 20;
   maxSideSpeed = 20;
   groundForce = 40 * 5.0;
   mass = 4.0;
   groundTraction = 10.0;
	maxEnergy = 60;
   drag = 2.0;
   density = 1.2;

	minDamageSpeed = 2000;
	damageScale = 0.005;

   jumpImpulse = 25;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundLaserIdle;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


function sarmor::onBio(%client, %player)
{
	Armor::onBio(%client, %player);
}

function sarmor::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}

function sarmor::onBeacon(%player, %item)
{
	Armor::SpeedBooster(%player, %item, 260);		
}

function sarmor::onSludge(%client, %player)
{
	Armor::onSludge(%client, %player);
}

//------------------------------------------------------------------
// Battalion armor data:
//------------------------------------------------------------------

PlayerData larmor
{
   className = "Armor";
   shapeFile = "larmor";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   flameShapeName = "shotgunex";
   shieldShapeName = "shield";
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";
   canCrouch = true;

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 40;
   minJetEnergy = 1;
   jetForce = $LightJetForce;
   jetEnergyDrain = $LightJetDrain;

	maxDamage = 0.66;
   maxForwardSpeed = 15;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = $LightJumpForce;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, direction
	// firstPerson, chaseCam, thirdPerson, signalThread
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 


    // celebration animations:
   animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
 
    // taunt animations:
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
 
    // poses:
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundDiscspin;
   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.6666;
   boxCrouchTorsoPercentage = 0.3333;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


function larmor::onBio(%client, %player)
{
	Armor::onBio(%client, %player);
}

function larmor::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}


function larmor::onBeacon(%player, %item)
{
	Armor::SpeedBooster(%player, %item, 290);		
}


function larmor::onSludge(%client, %player)
{
	Armor::onSludge(%client, %player);
}

//------------------------------------------------------------------
// Deffencive Engineer armor data:
//------------------------------------------------------------------

PlayerData marmor
{
   className = "Armor";
   shapeFile = "marmor";
   flameShapeName = "plasmatrail";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = $MediumJetForce;
   jetEnergyDrain = $MediumJetDrain;

	maxDamage = 1.0;
   maxForwardSpeed = 10.0;
   maxBackwardSpeed = 8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 10.0;
   mass = 10.0;
   groundTraction = 3.0;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = $MediumJumpForce;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundMortarIdle;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


function marmor::onBio(%client, %player)
{
	Armor::onBio(%client, %player);
}

function marmor::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}


function marmor::onBeacon(%player, %item)
{
	Armor::SpeedBooster(%player, %item, 310);		
}

function marmor::onSludge(%client, %player)
{
	Armor::onSludge(%client, %player);
}

//------------------------------------------------------------------
// Armageddon Mech armor data:
//------------------------------------------------------------------

PlayerData harmor
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "Fusionex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 2.0;
   maxJetForwardVelocity = 15;
   minJetEnergy = 1;
   jetForce = 350;
   jetEnergyDrain = 1;

	maxDamage = 1.32;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 8.0;
   maxSideSpeed = 8.0;
   groundForce = 35 * 10.0;
   groundTraction = 3.5;
   mass = 9.0;
	maxEnergy = 110;
   drag = 1.0;
   density = 2.5;
   canCrouch = false;

	minDamageSpeed = 25;
	damageScale = 0.006;

   jumpImpulse = 160;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundTankIdle;

   rFootSounds = 
   {
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRHard,
     SoundHFootRSnow,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft,
     SoundHFootRSoft
  }; 
   lFootSounds =
   {
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLHard,
      SoundHFootLSnow,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft,
      SoundHFootLSoft
   };

   footPrints = { 4, 5 };

   boxWidth = 0.8;
   boxDepth = 0.8;
   boxNormalHeight = 2.6;

   boxNormalHeadPercentage  = 0.70;
   boxNormalTorsoPercentage = 0.45;

   boxHeadLeftPercentage  = 0.48;
   boxHeadRightPercentage = 0.70;
   boxHeadBackPercentage  = 0.48;
   boxHeadFrontPercentage = 0.60;
};


function harmor::onBio(%client, %player)
{
	Armor::onBio(%client, %player);
}

function harmor::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}


function harmor::onBeacon(%player, %item)
{
	Armor::SpeedBooster(%player, %item, 340);		
}

function harmor::onSludge(%client, %player)
{
	Armor::onSludge(%client, %player);
}

//------------------------------------------------------------------
// Hybrid Destroyer armor Data:
//------------------------------------------------------------------
PlayerData Narmor
{
   className = "Armor";
   shapeFile = "harmor";
   flameShapeName = "shield_large";
   shieldShapeName = "shield_large";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   canCrouch = false;
   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 20;
   minJetEnergy = 1;
   jetForce = $LightJetForce;
   jetEnergyDrain = $LightJetDrain;

	maxDamage = 1.0;
   maxForwardSpeed = 11.0;
   maxBackwardSpeed = 10.0;
   maxSideSpeed = 10.0;
   groundForce = 35 * 5.0;
   mass = 8.0;
   groundTraction = 2.0;
	
	maxEnergy = 80;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = $MediumJumpForce;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundBeaconActive;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.83;
   boxNormalTorsoPercentage = 0.49;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};



function narmor::onBio(%client, %player)
{
	Armor::onBio(%client, %player);
}

function narmor::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}


function narmor::onBeacon(%player, %item)
{
	Armor::SpeedBooster(%player, %item, 370);		
}

function narmor::onSludge(%client, %player)
{
	Armor::onSludge(%client, %player);
}

//------------------------------------------------------------------
// Battalion armor female data:
//------------------------------------------------------------------

PlayerData lfemale
{
   className = "Armor";
   shapeFile = "lfemale";
   flameShapeName = "shotgunex";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   canCrouch = true;
   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 30;
   minJetEnergy = 1;
   jetForce = $LightJetForce;
   jetEnergyDrain = $LightJetDrain;

	maxDamage = 0.66;
   maxForwardSpeed = 15;
   maxBackwardSpeed = 10;
   maxSideSpeed = 10;
   groundForce = 40 * 9.0;
   mass = 9.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   drag = 1.0;
   density = 1.2;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = $MediumJumpForce;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };


   jetSound = SoundDiscSpin;

   rFootSounds = 
   {
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRHard,
     SoundLFootRSnow,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft,
     SoundLFootRSoft
  }; 
   lFootSounds =
   {
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLHard,
      SoundLFootLSnow,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft,
      SoundLFootLSoft
   };

   footPrints = { 0, 1 };

   boxWidth = 0.5;
   boxDepth = 0.5;
   boxNormalHeight = 2.3;
   boxCrouchHeight = 1.8;

   boxNormalHeadPercentage  = 0.85;
   boxNormalTorsoPercentage = 0.53;
   boxCrouchHeadPercentage  = 0.88;
   boxCrouchTorsoPercentage = 0.35;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


function lfemale::onBio(%client, %player)
{
	Armor::onBio(%client, %player);
}

function lfemale::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}


function lfemale::onBeacon(%player, %item)
{
	Armor::SpeedBooster(%player, %item, 290);		
}

function lfemale::onSludge(%client, %player)
{
	Armor::onSludge(%client, %player);
}

//------------------------------------------------------------------
// Deffencive Engineer female data:
//------------------------------------------------------------------

PlayerData mfemale
{
   className = "Armor";
   shapeFile = "mfemale";
   flameShapeName = "plasmatrail";
   shieldShapeName = "shield";
   damageSkinData = "armorDamageSkins";
	debrisId = playerDebris;
   shadowDetailMask = 1;

   visibleToSensor = True;
	mapFilter = 1;
	mapIcon = "M_player";

   maxJetSideForceFactor = 0.8;
   maxJetForwardVelocity = 17;
   minJetEnergy = 1;
   jetForce = 600;
   jetEnergyDrain = 1;

   canCrouch = False;
	maxDamage = 1.0;
   maxForwardSpeed = 8.0;
   maxBackwardSpeed = 7.0;
   maxSideSpeed = 7.0;
   groundForce = 35 * 13.0;
   mass = 13.0;
   groundTraction = 3.0;
	maxEnergy = 80;
   mass = 13.0;
   drag = 1.0;
   density = 1.5;

	minDamageSpeed = 25;
	damageScale = 0.005;

   jumpImpulse = 110;
   jumpSurfaceMinDot = 0.2;

   // animation data:
   // animation name, one shot, exclude, direction,
	// firstPerson, chaseCam, thirdPerson, signalThread

   // movement animations:
   animData[0]  = { "root", none, 1, true, true, true, false, 0 };
   animData[1]  = { "run", none, 1, true, false, true, false, 3 };
   animData[2]  = { "runback", none, 1, true, false, true, false, 3 };
   animData[3]  = { "side left", none, 1, true, false, true, false, 3 };
   animData[4]  = { "side left", none, -1, true, false, true, false, 3 };
   animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
   animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
   animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
   animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
   animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
   animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
   animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
   animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
   animData[14]  = { "fall", none, 1, true, true, true, false, 3 };
   animData[15]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[16]  = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
   animData[17]  = { "tumble loop", none, 1, true, false, false, false, 3 };
   animData[18]  = { "tumble end", none, 1, true, false, false, false, 3 };
   animData[19] = { "jet", none, 1, true, true, true, false, 3 };

   // misc. animations:
   animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
   animData[21] = { "throw", none, 1, true, false, false, false, 3 };
   animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
   animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
   animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
   
   // death animations:
   animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 };
   animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 };

   // signal moves:
	animData[38] = { "sign over here",  none, 1, true, false, false, false, 2 };
   animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
   animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
   animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
   animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; 

    // celebraton animations:
   animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
   animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
   animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };

    // taunt anmations:
   animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
   animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };

    // poses:
   animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
   animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };

	// Bonus wave
   animData[50] = { "wave", none, 1, true, false, false, true, 1 };

   jetSound = SoundMortarIdle;

   rFootSounds = 
   {
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRHard,
     SoundMFootRSnow,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft,
     SoundMFootRSoft
  }; 
   lFootSounds =
   {
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLHard,
      SoundMFootLSnow,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft,
      SoundMFootLSoft
   };

   footPrints = { 2, 3 };

   boxWidth = 0.7;
   boxDepth = 0.7;
   boxNormalHeight = 2.4;

   boxNormalHeadPercentage  = 0.84;
   boxNormalTorsoPercentage = 0.55;

   boxHeadLeftPercentage  = 0;
   boxHeadRightPercentage = 1;
   boxHeadBackPercentage  = 0;
   boxHeadFrontPercentage = 1;
};


function mfemale::onBio(%client, %player)
{
	Armor::onBio(%client, %player);
}

function mfemale::onShock(%client, %player)
{
	Armor::onShock(%client, %player);
}


function mfemale::onBeacon(%player, %item)
{
	Armor::SpeedBooster(%player, %item, 310);		
}

function mfemale::onSludge(%client, %player)
{
	Armor::onSludge(%client, %player);
}

//------------------------------------------------------------------
//
//------------------------------------------------------------------







