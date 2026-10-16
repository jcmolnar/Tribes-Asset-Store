function armorTable(%armor, %land, %impa, %crus, %bull, %plas, %ener, %expl, %miss, %debr, %shra, %lase, %mort, %blas, %elec, %mine, %ark1, %ark2, %ark3, %maxw, %pnts, %scou, %lapc, %hapc)
{
	$DamageScale[%armor, $LandingDamageType]     = %land;
	$DamageScale[%armor, $ImpactDamageType]      = %impa;
	$DamageScale[%armor, $CrushDamageType]       = %crus;
	$DamageScale[%armor, $BulletDamageType]      = %bull;
	$DamageScale[%armor, $PlasmaDamageType]      = %plas;
	$DamageScale[%armor, $EnergyDamageType]      = %ener;
	$DamageScale[%armor, $ExplosionDamageType]   = %expl;
	$DamageScale[%armor, $MissileDamageType]     = %miss;
	$DamageScale[%armor, $DebrisDamageType]      = %debr;
	$DamageScale[%armor, $ShrapnelDamageType]    = %shra;
	$DamageScale[%armor, $LaserDamageType]       = %lase;
	$DamageScale[%armor, $MortarDamageType]      = %mort;
	$DamageScale[%armor, $BlasterDamageType]     = %blas;
	$DamageScale[%armor, $ElectricityDamageType] = %elec;
	$DamageScale[%armor, $MineDamageType]        = %mine;
	$DamageScale[%armor, $ArkFieldDamageType]    = %ark1;
	$DamageScale[%armor, $ArkFieldDamageType]    = %ark2;
	$DamageScale[%armor, $ArkDamageType]         = %ark3;
	$MaxWeapons [%armor]                         = %maxw;
	$NeedPoints [%armor]                         = %pnts;
	$VehicleUse [%armor, scout]                  = %scou;
	$VehicleUse [%armor, lapc]                   = %lapc;
	$VehicleUse [%armor, hapc]                   = %hapc;
}

//------------armor  land  impa  crus  bull  plas  ener  expl  miss  debr  shra  lase  mort  blas  elec  mine  ark1  ark2  ark3  maxw  pnts  Scout   LAPC   HAPC
//-----------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  -----  -----  -----
armorTable(larmor,    1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,  1.3,    3,    0, False, False,  True);
armorTable(hlarmor,   1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,  1.2,    3,   25, False, False,  True);
armorTable(lmarmor,   1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,    4,   50, False,  True,  True);
armorTable(lmfemale,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,  1.1,    4,   50, False,  True,  True);
armorTable(marmor,    1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,    4,  100, False,  True,  True);
armorTable(mfemale,   1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0,    4,  100, False,  True,  True);
armorTable(hmarmor,   0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,    4,  200, False,  True,  True);
armorTable(hmfemale,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,  0.9,    4,  200, False,  True,  True);
armorTable(lharmor,   0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,    5,  400,  True,  True,  True);
armorTable(lhfemale,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,  0.8,    5,  400,  True,  True,  True);
armorTable(harmor,    0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,    5,  800,  True,  True,  True);
armorTable(hfemale,   0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,  0.7,    5,  800,  True,  True,  True);

function itemTable(%item, %larm, %hlar, %lmar, %lmfe, %marm, %mfem, %hmar, %hmfe, %lhar, %lhfe, %harm, %hfem, %pnts)
{
	$ItemMax[larmor,   %item] = %larm;
	$ItemMax[hlarmor,  %item] = %hlar;
	$ItemMax[lmarmor,  %item] = %lmar;
	$ItemMax[lmfemale, %item] = %lmfe;
	$ItemMax[marmor,   %item] = %marm;
	$ItemMax[mfemale,  %item] = %mfem;
	$ItemMax[hmarmor,  %item] = %hmar;
	$ItemMax[hmfemale, %item] = %hmfe;
	$ItemMax[lharmor,  %item] = %lhar;
	$ItemMax[lhfemale, %item] = %lhfe;
	$ItemMax[harmor,   %item] = %harm;
	$ItemMax[hfemale,  %item] = %hfem;
	$NeedPoints[%item]        = %pnts;
}

//--------Weapons------------------  larm  hlar  lmar  lmfe  marm  mfem  hmar  hmfe  lhar  lhfe  harm  hfem  pnts
//---------------------------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----
itemTable(Blaster,			    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(LChaingun,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(Chaingun,			    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(HChaingun,			    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    0);
itemTable(LDisclauncher,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(Disclauncher,			    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(HDisclauncher,		    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    0);
itemTable(LGrenadeLauncher,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(GrenadeLauncher,		    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(HGrenadeLauncher,		    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    0);
itemTable(Mortar,				    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    0);
itemTable(Arkfire,			    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(Arkfire2,			    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    0);
itemTable(PlasmaGun,			    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(LaserRifle,			    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(HLaserRifle,			    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    0);
itemTable(LEnergyRifle,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(EnergyRifle,			    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(HEnergyRifle,			    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    0);
//--------Miscellaneous------------  larm  hlar  lmar  lmfe  marm  mfem  hmar  hmfe  lhar  lhfe  harm  hfem  pnts
//---------------------------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----
itemTable(MineAmmo,			    1,    1,    2,    2,    2,    2,    2,    2,    3,    3,    3,    3,    0);
itemTable(Grenade,			    3,    4,    5,    5,    6,    6,    7,    7,    8,    8,    9,    9,    0);
itemTable(Beacon,				    3,    3,    3,    3,    3,    3,    3,    3,    3,    3,    3,    3,    0);
itemTable(RepairKit,			    1,    1,    2,    2,    2,    2,    2,    2,    3,    3,    3,    3,    0);
//--------Tools--------------------  larm  hlar  lmar  lmfe  marm  mfem  hmar  hmfe  lhar  lhfe  harm  hfem  pnts
//---------------------------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----
itemTable(EnergyConduit,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(ProgramSlot,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(Ram,				    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(Resist,				    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
//--------Ammo---------------------  larm  hlar  lmar  lmfe  marm  mfem  hmar  hmfe  lhar  lhfe  harm  hfem  pnts
//---------------------------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----
itemTable(BlasterAmmo,			    1,    1,    2,    2,    2,    2,    2,    2,    3,    3,    3,    3,    0);
itemTable(BulletAmmo,			  150,  175,  200,  200,  225,  225,  250,  250,  275,  275,  300,  300,    0);
itemTable(PlasmaAmmo,			   10,   11,   12,   12,   13,   13,   14,   14,   15,   15,   16,   16,    0);
itemTable(DiscAmmo,			   10,   12,   14,   14,   16,   16,   18,   18,   20,   20,   22,   22,    0);
itemTable(GrenadeAmmo,			   10,   11,   12,   12,   13,   13,   14,   14,   15,   15,   16,   16,    0);
itemTable(MortarAmmo,			    5,    6,    7,    7,    8,    8,    9,    9,   10,   10,   11,   11,    0);
itemTable(ArkfireAmmo,			    1,    1,    2,    2,    2,    2,    3,    3,    4,    4,    5,    5,    0);
itemTable(LaserAmmo,			    5,   10,   15,   15,   20,   20,   25,   25,   30,   30,   35,   35,    0);
//--------Packs--------------------  larm  hlar  lmar  lmfe  marm  mfem  hmar  hmfe  lhar  lhfe  harm  hfem  pnts
//---------------------------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----
itemTable(CloakPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(EnergyPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(RepairPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(ShieldPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(SensorJammerPack,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(AmmoPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
//--------Turrets------------------  larm  hlar  lmar  lmfe  marm  mfem  hmar  hmfe  lhar  lhfe  harm  hfem  pnts
//---------------------------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----
itemTable(TurretPack,			    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(RotPack,			    0,    0,    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    0);
itemTable(SolburnPack,			    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(OmniPack,			    0,    0,    0,    0,    0,    0,    1,    1,    1,    1,    1,    1,    0);
//--------Sensors------------------  larm  hlar  lmar  lmfe  marm  mfem  hmar  hmfe  lhar  lhfe  harm  hfem  pnts
//---------------------------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----
itemTable(MotionSensorPack,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(PulseSensorPack,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(DeployableSensorJammerPack,   1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(CameraPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(SpringPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
//--------Deployables--------------  larm  hlar  lmar  lmfe  marm  mfem  hmar  hmfe  lhar  lhfe  harm  hfem  pnts
//---------------------------------  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----  ----
itemTable(DeployableInvPack,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(DeployableAmmoPack,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(ArkFieldPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(FireWallPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(ExponentialPack,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(LargeExponentialPack,	    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(DataWallPack,			    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
itemTable(LargeDataWallPack,		    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    0);
