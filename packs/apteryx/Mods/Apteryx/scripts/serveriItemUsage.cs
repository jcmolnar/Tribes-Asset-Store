// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ARMOR WEAPON MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormDM] = 4;
$MaxWeapons[armorfDM] = 4;
$MaxWeapons[armormAngel] = 1;
$MaxWeapons[armorfAngel] = 1;
$MaxWeapons[armormSpy] = 3;
$MaxWeapons[armorfSpy] = 3;
$MaxWeapons[armormNecro] = 3;
$MaxWeapons[armorfNecro] = 3;
$MaxWeapons[armormWarrior] = 3;
$MaxWeapons[armorfWarrior] = 3;
$MaxWeapons[armormBuilder] = 2;
$MaxWeapons[armorfBuilder] = 2;
$MaxWeapons[armorTroll] = 2;
$MaxWeapons[armorTank] = 4;
$MaxWeapons[armorTitan] = 4;

function PopulateCanPilot(%APC, %mDM, %fDM, %mAN, %fAN, %mSP, %fSP, %mNE, %fNE, %mME, %fME, %mBU, %fBU, %TR, %TA, %TI)
{
	$VehicleUse[armormDM, %APC] = %mDM;
	$VehicleUse[armorfDM, %APC] = %fDM;
	$VehicleUse[armormAngel, %APC] = %mAN;
	$VehicleUse[armorfAngel, %APC] = %fAN;
	$VehicleUse[armormSpy, %APC] = %mSP;
	$VehicleUse[armorfSpy, %APC] = %fSP;
	$VehicleUse[armormNecro, %APC] = %mNE;
	$VehicleUse[armorfNecro, %APC] = %fNE;
	$VehicleUse[armormWarrior, %APC] = %mME;
	$VehicleUse[armorfWarrior, %APC] = %fME;
	$VehicleUse[armormBuilder, %APC] = %mBU;
	$VehicleUse[armorfBuilder, %APC] = %fBU;
	$VehicleUse[armorTroll, %APC] = %TR;
	$VehicleUse[armorTank, %APC] = %TA;
	$VehicleUse[armorTitan, %APC] = %TI;  
}

$CP = 1;
$CR = 2;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// CAN PILOT                  	mDM,       fDM,       mAN,       fAN,       mSP,       fSP,       mNE,       fNE,       mME,       fME,       mBU,       fBU,        TR,        TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-	---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---  ---
//PopulateCanPilot(Wraith,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,	 $CP | $CR, $CP | $CR, $CR, 	$CR, $CR,       $CR,       $CR,       $CR, $CR);
PopulateCanPilot(Interceptor,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,	 $CP | $CR, $CP | $CR, $CR, 	$CR, $CR,       $CR,       $CR,       $CR, $CR);
PopulateCanPilot(Scout,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,	 $CP | $CR, $CP | $CR, $CR, 	$CR, $CR,       $CR,       $CR,       $CR, $CR);
PopulateCanPilot(LAPC,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,	 $CP | $CR, $CP | $CR, $CR, 	$CR, $CR,       $CR,       $CR,       $CR, $CR);
PopulateCanPilot(HAPC,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,	 $CP | $CR, $CP | $CR, $CR, 	$CR, $CR,       $CR,       $CR,       $CR, $CR);
//PopulateCanPilot(Interceptor,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, 	$CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,       $CR,       $CR, $CR);
//PopulateCanPilot(Scout,		$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR,       $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,       $CR,       $CR, $CR);
//PopulateCanPilot(LAPC,		$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR, $CR);
//PopulateCanPilot(HAPC,		$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR, $CR);

function PopulateDamageScale(%damagetype, %mDM, %fDM, %mAN, %fAN, %mSP, %fSP, %mNE, %fNE, %mME, %fME, %mBU, %fBU, %TR, %TA, %TI, %h1, %vSc, %vIn, %vWr, %vLa, %vHa, %pSv, %pPr, %pSu, %wOs)
{
	$DamageScale[armormDM, %damagetype] = %mDM;
	$DamageScale[armorfDM, %damagetype] = %fDM;
	$DamageScale[armormAngel, %damagetype] = %mAN;
	$DamageScale[armorfAngel, %damagetype] = %fAN;
	$DamageScale[armormSpy, %damagetype] = %mSP;
	$DamageScale[armorfSpy, %damagetype] = %fSP;
	$DamageScale[armormNecro, %damagetype] = %mNE;
	$DamageScale[armorfNecro, %damagetype] = %fNE;
	$DamageScale[lghost, %damagetype] = %mNE;
	$DamageScale[fghost, %damagetype] = %fNE;
	$DamageScale[armormWarrior, %damagetype] = %mME;
	$DamageScale[armorfWarrior, %damagetype] = %fME;
	$DamageScale[armormBuilder, %damagetype] = %mBU;
	$DamageScale[armorfBuilder, %damagetype] = %fBU;
	$DamageScale[armorTroll, %damagetype] = %TR;
	$DamageScale[armorTank, %damagetype] = %TA;
	$DamageScale[armorTitan, %damagetype] = %TI;  
	$DamageScale[harmor, %damagetype] = %h1;
	$DamageScale[Scout, %damagetype] = %vSc;
	$DamageScale[interceptor, %damagetype] = %vIn;
	$DamageScale[wraith, %damagetype] = %vWr;
	$DamageScale[lapc, %damagetype] = %vLa;
	$DamageScale[hapc, %damagetype] = %vHa;
	$DamageScale[SurveyDroid, %damagetype] = %pSv;
	$DamageScale[ProbeDroid, %damagetype] = %pPr;
	$DamageScale[SuicideDroid, %damagetype] = %pSu;
	$DamageScale[OSMissile, %damagetype] = %wOs;
}
//					     armormDM  ,  Angel  ,   Spy   ,  Necro  ,  Warrior, Builder, Troll,Tank,Titn,harm,Figh,intr,Wrai,lapc,hapc,Surv,probe,sui,OSMis
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// DAMAGE SCALE                                mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI,  h1,  vSc, vIn, vWr, vLa, vHa, pSv, pPr, pSu, wOS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
// adjusted -Plasmatic 
PopulateDamageScale($ImpactDamageType,         1.0, 1.0, 1.2, 1.2, 0.7, 0.7, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($LandingDamageType,        1.0, 1.0, 0.7, 0.7, 0.8, 0.8, 0.8, 0.8, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($BulletDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 0.0, 1.1, 1.1, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($EnergyDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 0.7, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($PlasmaDamageType,         1.0, 1.0, 1.2, 1.2, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ExplosionDamageType,      1.0, 1.0, 0.7, 0.7, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.7, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ShrapnelDamageType,       1.0, 1.0, 1.5, 1.5, 0.8, 0.8, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 0.6, 0.8, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($LaserDamageType,          1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 0.9, 0.9, 1.1, 1.1, 1.0, 1.0, 1.2, 1.0, 1.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($MortarDamageType,         1.0, 1.0, 0.5, 0.5, 0.8, 0.8, 1.1, 1.1, 1.0, 1.0, 0.9, 0.9, 0.8, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($BlasterDamageType,        1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ElectricityDamageType,    1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.2, 1.2, 1.3, 1.4, 1.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($CrushDamageType,          1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($DebrisDamageType,         1.0, 1.0, 1.0, 1.0, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($MissileDamageType,        1.0, 1.0, 1.2, 1.2, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($AntiTurretDamageType,    0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05,0.05, 0.05,1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($MineDamageType,           1.0, 1.0, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 1.0, 1.0, 1.0, 1.0, 0.8, 0.6, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($SniperDamageType,         1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 0.9, 0.9, 0.9, 0.9, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ShockDamageType,          1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ShotgunDamageType,        1.0, 1.0, 1.0, 1.0, 0.7, 0.7, 0.7, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($SoulDamageType,           1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($AssassinDamageType,       1.0, 1.0, 1.0, 1.0, 0.2, 0.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($DisarmDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($TurretVortexDamageType,   1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($MeleeDamageType,   1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);

PopulateDamageScale($PoisonDamageType,         1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($TrollPlasmaDamageType,    0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.7, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8, 0.8);
//					     armormDM  ,  Angel  ,   Spy   ,  Necro  ,  Warrior, Builder ,Trol,Tank,Titn,harm,Figh,intr,Wrai,lapc,hapc,Surv,probe,sui,OSMis
$Console::Prompt = ">>";

function PopulateItemMax(%item, %mDM, %fDM, %mAN, %fAN, %mSP, %fSP, %mNE, %fNE, %mME, %fME, %mBU, %fBU, %TR, %TA, %TI, %h1, %h2, %h3)
{
	$ItemMax[armormDM, %item] = %mDM;
	$ItemMax[armorfDM, %item] = %fDM;
	$ItemMax[armormAngel, %item] = %mAN;
	$ItemMax[armorfAngel, %item] = %fAN;
	$ItemMax[armormSpy, %item] = %mSP;
	$ItemMax[armorfSpy, %item] = %fSP;
	$ItemMax[armormNecro, %item] = %mNE;
	$ItemMax[armorfNecro, %item] = %fNE;
	$ItemMax[armormWarrior, %item] = %mME;
	$ItemMax[armorfWarrior, %item] = %fME;
	$ItemMax[armormBuilder, %item] = %mBU;
	$ItemMax[armorfBuilder, %item] = %fBU;
	$ItemMax[armorTroll, %item] = %TR;
	$ItemMax[armorTank, %item] = %TA;
	$ItemMax[armorTitan, %item] = %TI;  
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// WEAPONS                                     mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AngelFire,			0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(BabyNukeMortar,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(BabyNukeAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   7,   7,   0,   0,   0);
PopulateItemMax(DiscLauncher,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(DiscAmmo,			30,  30,  0,   0,   0,   0,   0,   0,   4,   4,   0,   0,   0,   0,   6);
PopulateItemMax(Fixit,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Flamer,				1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(FlamerAmmo,			50,  50,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(FlameThrower,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(FlameThrowerAmmo,		50,  50,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(GrenadeLauncher,		1,   1,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(GrenadeAmmo,			20,  20,  0,   0,   0,   0,   6,   6,   8,   8,   0,   0,   0,   0,  12);
PopulateItemMax(HDiscLauncher,			1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(HDiscLauncherAmmo,		30,  30,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  18);
PopulateItemMax(HeavensFury,			0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Jailgun,			1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(MineLauncher,			1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(MineLauncherAmmo,		5,   5,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Mortar,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(MortarAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   9);
PopulateItemMax(OSLauncher,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(OSAmmo,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  15);
PopulateItemMax(ParticleBeamWeapon,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ParticleBeamShells,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PhaseDisrupter,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0);
PopulateItemMax(PhaseDisrupterAmmo,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   3,   0,   0);
PopulateItemMax(PlasmaGun,			1,   1,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(PlasmaAmmo,			30,  30,  0,   0,   0,   0,   8,   8,  10,  10,   0,   0,   0,   0,  16);
PopulateItemMax(PulseCannon,			0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Railgun,			0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(RailAmmo,			0,   0,   0,   0,   0,   0,  10,  10,  12,  12,   0,   0,   0,   0,   0);
PopulateItemMax(RocketLauncher,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(RocketAmmo,			10,  10,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(RubberMortar,			1,   1,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(RubberAmmo,			10,  10,  8,   8,   0,   0,   8,   8,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ShockwaveGun,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(Shotgun,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(ShotGunShells,			30,  30,  0,   0,   0,   0,   0,   0,  15,  15,   0,   0,   0,   0,   0);
PopulateItemMax(SniperRifle,			0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SniperAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SoulSucker,			0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Stinger,			1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0);
PopulateItemMax(StingerAmmo,			10,  10,  0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   3,   0,   0);
PopulateItemMax(TargetingLaser,			1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0,   0,   1,   1);
PopulateItemMax(TankShredder,			0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(TankShredderAmmo,		0,   0,   0,   0,   0,   0,  20,  20,   0,   0,   0,   0,   0, 500,   0);
PopulateItemMax(TRocketLauncher,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1);
PopulateItemMax(TRocketLauncherAmmo,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,  40, 200);
PopulateItemMax(TankRPGLauncher,		0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TankRPGAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TBlastCannon,			0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   1,   1);
PopulateItemMax(TBlastCannonAmmo,		0,   0,   0,   0,   0,   0,   0,   0,  75,  75,   0,   0,   0,  30, 100);
PopulateItemMax(Vulcan,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(VulcanAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// SPELLS                                      mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(DeathRay,			0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(DisarmerSpell,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(ShockingGrasp,			0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(Stasis,				0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Elf,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(FlameStrike,			0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);  
PopulateItemMax(SpellFlameThrower,		0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// MISC                                        mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(flag,				1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);  
PopulateItemMax(Beacon,				1,   1,   2,   2,   1,   1,   2,   2,   5,   5,   2,   2,   2,   5,   2);  
PopulateItemMax(Grenade,			8,   8,   3,   3,   4,   4,   2,   2,   8,   8,   5,   5,   0,   8,   3);
PopulateItemMax(MineAmmo,			3,   3,   3,   3,   2,   2,   2,   2,   3,   3,   5,   5,   4,   3,   5);
PopulateItemMax(RepairKit,			1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// PACKS                                       mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AmmoPack,			1,   1,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(EnergyPack,			1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   1,   1);
PopulateItemMax(RepairPack,			1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(ShieldPack,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(BuilderPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SensorJammerPack,		1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   1,   1);
PopulateItemMax(PhaseShifterPack,		0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(CloakingDevice,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(StealthShieldPack,		1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(Laptop,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);  
PopulateItemMax(SightPack,			0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(SuicidePack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(RegenerationPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ChameleonPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SurveyDroidPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ProbeDroidPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SuicideDroidPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ghostpack,			0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   1);
PopulateItemMax(DroneSelectorPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// SENSORS                                     mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(CameraPack,			0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   1,   0);
PopulateItemMax(DeployableSensorJammerPack,	0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   0,   1,   0);
PopulateItemMax(MotionSensorPack,		0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   0,   1,   0);
PopulateItemMax(AlarmPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(PulseSensorPack,		0,   0,   1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   0,   1,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TURRETS                                     mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(FusionTurretPack,		1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(LaserTurretPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(RocketPack,			0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PlasmaTurretPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(MortarTurretPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);  
PopulateItemMax(ShockTurretPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(NuclearTurretPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(FlameTurretPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(IrradiationTurretPack,		1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TurretPack,			0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(VortexTurretPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ParticleBeamTurretPack,		1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// BARRIERS                                    mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(BlastWallPack,			0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ForceFieldPack,			1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(ForceFieldDoorPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(LargeForceFieldPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(LargeForceFieldDoorPack,	0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PlatformPack,			0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// DEPLOYABLES                                 mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(BaseCloakPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ControlJammerPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(DeployableAmmoPack,		1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(DeployableComPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(DeployableInvPack,		1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(FighterPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(JailTower,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(JumpPadPack,			0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TeleportPack,			1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(TransportPack,			0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// POWER SYSTEMS                               mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(MobileInventoryPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0); 
PopulateItemMax(PortableGeneratorPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PortableSolarPack,		0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(PowerNodePack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SatSystemPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ShieldGenPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ShieldNodePack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// REMOTE BASES                                mDM, fDM, mAN, fAN, mSP, fSP, mNE, fNE, mME, fME, mBU, fBU,  TR,  TA,  TI
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AirBasePack,			1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(BunkerPack,			0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(CommandShipPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(GunShipPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SupplyShipPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);


// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM BARRIERS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[BlastWallPack] = 1;
$TeamItemMax[ForceFieldPack] = 16;
$TeamItemMax[ForceFieldDoorPack] = 8;
$TeamItemMax[LargeForceFieldPack] = 8;
$TeamItemMax[LargeForceFieldDoorPack] = 1;
$TeamItemMax[PlatformPack] = 2;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM DEPLOYABLES MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[AcceleratorDevicePack] = 2;
$TeamItemMax[AcceleratorDevice] = 2;
$TeamItemMax[BaseCloakPack] = 1;
$TeamItemMax[ControlJammerPack] = 1;
$TeamItemMax[DeployableAmmoPack] = 10;
$TeamItemMax[DeployableComPack] = 5;
$TeamItemMax[DeployableInvPack] = 10;
$TeamItemMax[DeployableTeleport] = 2;
$TeamItemMax[JailTower] = 1;
$TeamItemMax[Springboard] = 3;
$TeamItemMax[JumpPadPack] = 4;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM DRONES MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[SurveyDroidPack] = 10;
$TeamItemMax[ProbeDroidPack] = 3;
$TeamItemMax[SuicideDroidPack] = 6;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM POWER SYSTEMS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[MobileInventoryPack] = 5;
$TeamItemMax[PortableGeneratorPack] = 1;
$TeamItemMax[PortableSolarPack] = 1;
$TeamItemMax[PowerNodePack] = 20;
$TeamItemMax[SatSystemPack] = 1;
$TeamItemMax[ShieldGenPack] = 1;
$TeamItemMax[ShieldNodePack] = 20;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM REMOTE BASES MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[AirBasePack] = 1;
$TeamItemMax[BunkerPack] = 4;
$TeamItemMax[CommandShipPack] = 1;
$TeamItemMax[GunShipPack] = 1;
$TeamItemMax[SupplyShipPack] = 1;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM SENSORS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[CameraPack] = 5;
$TeamItemMax[DeployableSensorJammerPack] = 5;
$TeamItemMax[MotionSensorPack] = 5;
$TeamItemMax[PulseSensorPack] = 5;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM TURRETS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[FlameTurretPack] = 2;
$TeamItemMax[FusionTurretPack] = 2;
$TeamItemMax[TurretPack] = 2;
$TeamItemMax[IrradiationTurretPack] = 2;
$TeamItemMax[LaserTurretPack] = 4;
$TeamItemMax[MortarTurretPack] = 2;
$TeamItemMax[NuclearTurretPack] = 2;
$TeamItemMax[ParticleBeamTurretPack] = 2;
$TeamItemMax[PlasmaTurretPack] = 2;
$TeamItemMax[RocketPack] = 2;
$TeamItemMax[VortexTurretPack] = 2;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM VEHICLES MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[ScoutVehicle] = 2;
$TeamItemMax[InterceptorVehicle] = 2;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[HAPCVehicle] = 2;
