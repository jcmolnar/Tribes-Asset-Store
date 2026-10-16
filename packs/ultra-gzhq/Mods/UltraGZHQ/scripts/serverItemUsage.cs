// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// ARMOR WEAPON MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$MaxWeapons[armormDM] = 6;
$MaxWeapons[armorfDM] = 6;

$MaxWeapons[LightArmor] = 8;
$MaxWeapons[LightFArmor] = 8;

$MaxWeapons[Assassin] = 7;
$MaxWeapons[FAssassin] = 7;


$MaxWeapons[Assault] = 8;
$MaxWeapons[FAssault] = 8;

$MaxWeapons[Deffence] = 6;
$MaxWeapons[FDeffence] = 6;

$MaxWeapons[Borg] = 7;

$MaxWeapons[Heavy] = 5;

$MaxWeapons[Destroyer] = 8;

function PopulateCanPilot(%APC, %mDM, %fDM, %lma, %lfa, %mas, %fas, %mat, %fat, %mdf, %fdf, %BR, %HA, %DS)
{
	$VehicleUse[armormDM, %APC] = %mDM;
	$VehicleUse[armorfDM, %APC] = %fDM;
	$VehicleUse[LightArmor, %APC] = %lma;
	$VehicleUse[LightFArmor, %APC] = %lfa;
	$VehicleUse[Assassin, %APC] = %mas;
	$VehicleUse[FAssassin, %APC] = %fas;
	$VehicleUse[Assault, %APC] = %mat;
	$VehicleUse[FAssault, %APC] = %fat;
	$VehicleUse[Deffence, %APC] = %mdf;
	$VehicleUse[FDeffence, %APC] = %fdf;
	$VehicleUse[Borg, %APC] = %BR;
	$VehicleUse[Heavy, %APC] = %HA;
	$VehicleUse[Destroyer, %APC] = %DS;  
}

$CP = 1;
$CR = 2;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// CAN PILOT                  	mDM,       fDM,       lma,       lfa,       mas,       fas,       mwr,       fwr,       mat,       fat,       mdf,       fdf,        BR,        HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-	---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---        ---  ---
//PopulateCanPilot(Wraith,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,       $CR,       $CR, $CR);
PopulateCanPilot(Interceptor,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,       $CR,       $CR, $CR);
PopulateCanPilot(Scout,	$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR,       $CR,       $CR,       $CR, $CR);
PopulateCanPilot(LAPC,		$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR, $CR);
PopulateCanPilot(HAPC,		$CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CP | $CR, $CR, $CR);

function PopulateDamageScale(%damagetype, %mDM, %fDM, %lma, %lfa, %mas, %fas, %mwr, %fwr, %mat, %fat, %mdf, %fdf, %BR, %HA, %DS, %h1, %vSc, %vIn, %vWr, %vLa, %vHa, %pSv, %pPr, %pSu, %wOs)
{
	$DamageScale[armormDM, %damagetype] = %mDM;
	$DamageScale[armorfDM, %damagetype] = %fDM;
	$DamageScale[LightArmor, %damagetype] = %lma;
	$DamageScale[LightFArmor, %damagetype] = %lfa;
	$DamageScale[Assassin, %damagetype] = %mas;
	$DamageScale[FAssassin, %damagetype] = %fas;

	$DamageScale[Assault, %damagetype] = %mat;
	$DamageScale[FAssault, %damagetype] = %fat;
	$DamageScale[Deffence, %damagetype] = %mdf;
	$DamageScale[FDeffence, %damagetype] = %fdf;
	$DamageScale[Borg, %damagetype] = %BR;
	$DamageScale[Heavy, %damagetype] = %HA;
	$DamageScale[Destroyer, %damagetype] = %DS;  
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
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// DAMAGE SCALE                                mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS,  h1,  vSc, vIn, vWr, vLa, vHa, pSv, pPr, pSu, wOS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
// 
PopulateDamageScale($ImpactDamageType,         1.0, 1.0, 1.2, 1.2, 0.6, 0.6, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($LandingDamageType,        1.0, 1.0, 0.7, 0.7, 0.8, 0.8, 0.8, 0.8, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($BulletDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 0.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($EnergyDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 0.5, 1.0, 1.0, 0.7, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($PlasmaDamageType,         1.0, 1.0, 1.2, 1.2, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ExplosionDamageType,      1.0, 1.0, 0.7, 0.7, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.7, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ShrapnelDamageType,       1.0, 1.0, 1.5, 1.5, 0.8, 0.8, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 0.6, 0.8, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($LaserDamageType,          1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 0.9, 0.9, 1.1, 1.1, 1.0, 1.0, 1.2, 1.0, 1.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($MortarDamageType,         1.0, 1.0, 0.5, 0.5, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 0.9, 0.9, 0.8, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($BlasterDamageType,        1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ElectricityDamageType,    1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.2, 1.2, 1.3, 1.4, 1.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($CrushDamageType,          1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($DebrisDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($MissileDamageType,        1.0, 1.0, 1.2, 1.2, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($OSMissileDamageType,      1.0, 1.0, 1.5, 1.5, 1.0, 1.0, 0.7, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($MineDamageType,           1.0, 1.0, 0.7, 0.7, 0.4, 0.4, 0.4, 0.4, 1.0, 1.0, 1.0, 1.0, 0.8, 0.6, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($SniperMkiDamageType,      1.0, 1.0, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 0.9, 0.9, 0.9, 0.9, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ShockDamageType,          1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.7, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($ShotgunDamageType,        1.0, 1.0, 1.0, 1.0, 0.7, 0.7, 0.5, 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($SoulDamageType,           1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 0.7, 0.7, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($AssassinDamageType,       1.0, 1.0, 1.0, 1.0, 0.2, 0.2, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($DisarmDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($TurretVortexDamageType,   1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($BurnDamageType,    	     1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.5, 1.5, 0.2, 1.5, 1.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($PoisonDamageType,         1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($RocketDamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.5, 1.5, 0.2, 1.5, 1.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($DartDamageType,           1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($AcidDamageType,           1.0, 1.0, 1.2, 1.2, 1.0, 1.0, 0.8, 0.8, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($BeamOfPainDamageType,     1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($IX2000DamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($IX2002DamageType,         1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
PopulateDamageScale($SniperMkiiDamageType,     1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.9, 0.9, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
$Console::Prompt = ">>";


function PopulateItemMax(%item, %mDM, %fDM, %lma, %lfa, %mas, %fas, %mwr, %fwr, %mat, %fat, %mdf, %fdf, %BR, %HA, %DS, %h1, %h2, %h3)
{
	$ItemMax[armormDM, %item] = %mDM;
	$ItemMax[armorfDM, %item] = %fDM;
	$ItemMax[LightArmor, %item] = %lma;
	$ItemMax[LightFArmor, %item] = %lfa;
	$ItemMax[Assassin, %item] = %mas;
	$ItemMax[FAssassin, %item] = %fas;
	$ItemMax[Assault, %item] = %mat;
	$ItemMax[FAssault, %item] = %fat;
	$ItemMax[Deffence, %item] = %mdf;
	$ItemMax[FDeffence, %item] = %fdf;
	$ItemMax[Borg, %item] = %BR;
	$ItemMax[Heavy, %item] = %HA;
	$ItemMax[Destroyer, %item] = %DS;  
}

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// WEAPONS                                     mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(Blaster,			      0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);


PopulateItemMax(BabyNukeMortar,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(BabyNukeAmmo,			      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   5);

PopulateItemMax(DiscLauncher,			      1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(DiscAmmo,			      200, 200, 200, 200, 200, 200, 0,   0,   0,   0,   0,   0,   0,   0,   0);

PopulateItemMax(Fixit,				      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);

PopulateItemMax(Flamer,				      1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   1);

PopulateItemMax(FlameThrower,			      1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1,   0,   1);
PopulateItemMax(FlameThrowerAmmo,		      350, 350, 0,   0,   0,   0,   0,   0,   350, 350, 0,   0,   350, 0,   350);

PopulateItemMax(GrenadeLauncher,		      1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(GrenadeAmmo,			      30,  30,  0,   0,   30,  30,  0,   0,   30,  30,  30,  30,  30,  0,   30);

PopulateItemMax(HDiscLauncher,			0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(HDiscLauncherAmmo,		      0,   0,   0,   0,   0,   0,   0,   0,   252, 252, 252, 252, 252, 252, 252);

PopulateItemMax(IX2000,				      0,   0,   1,   1,   1,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(IX2000Ammo,			      0,   0,   500, 500, 500, 0,   0,   0,   500, 500, 0,   0,   0,   0,   0);

PopulateItemMax(IX2002,				      0,   0,   1,   1,   1,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(IX2002Ammo,			      0,   0,   500, 500, 500, 0,   0,   0,   500, 500, 0,   0,   0,   0,   0);

PopulateItemMax(Jailgun,			      1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0,   0);

PopulateItemMax(MineLauncher,			      1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(MineLauncherAmmo,		      10,  10,  0,   0,   0,   0,   0,   0,   10,  10,  10,  10,  0,   0,   10);

PopulateItemMax(Mortar,					0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0);
PopulateItemMax(MortarAmmo,				0,   0,   30,  30,  0,   0,   0,   0,   0,   0,   0,   0,   30,  0,   0);

PopulateItemMax(OSLauncher,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(OSAmmo,					0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   20);

PopulateItemMax(ParticleBeamWeapon,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(ParticleBeamShells,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);

PopulateItemMax(PhaseDisrupter,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   1);
PopulateItemMax(PhaseDisrupterAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   55,  0,   60);

PopulateItemMax(PlasmaGun,				1,   1,   1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(PlasmaAmmo,				200, 200, 200, 200, 200, 200, 0,   0,   200, 200, 200, 200, 200, 0,   200);

PopulateItemMax(Railgun,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(RailAmmo,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   250, 250,  0,   0,  0);

PopulateItemMax(RocketLauncher,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(RocketAmmo,				15,  15,  0,   0,   0,   0,   0,   0,   15,  15,  15,  15,  15,  0,   15);

PopulateItemMax(ShockwaveGun,				1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   0,   0,   0);

PopulateItemMax(Shotgun,				1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(ShotGunShells,			100, 100, 0,   0,   100, 100, 0,   0,   100, 100, 100, 100, 100, 0,   0);

PopulateItemMax(SniperMki,				0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SniperMkiAmmo,			0,   0,   500, 500, 500, 500, 0,   0,   0,   0,   0,   0,   0,   0,   0);

PopulateItemMax(SniperMkii,				0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SniperMkiiAmmo,			0,   0,   500, 500, 500, 500, 0,   0,   0,   0,   0,   0,   0,   0,   0);

PopulateItemMax(ShockLance,				0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);

PopulateItemMax(Stinger,				1,   1,   1,   1,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(StingerAmmo,				100, 100, 80,  80,  0,   0,   0,   0,   80,  80,  80,  80,  100, 0,   100);

PopulateItemMax(TargetingLaser,			1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);

PopulateItemMax(TankShredder,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,     0);
PopulateItemMax(TankShredderAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   999,   0);

PopulateItemMax(TRocketLauncher,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(TRocketLauncherAmmo,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   200, 0);

PopulateItemMax(TankRPGLauncher,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(TankRPGAmmo,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   150, 0);

PopulateItemMax(TBlastCannon,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(TBlastCannonAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   100, 0);

PopulateItemMax(TankMortar,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0);
PopulateItemMax(TankMortarAmmo,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   180, 0);

PopulateItemMax(Vulcan,					1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(VulcanAmmo,				400, 400, 0,   0,   0,   0,   0,   0,   400, 400, 400, 400, 400, 0,   0);

PopulateItemMax(FEBRifle,				0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(FEBRifleAmmo,				0,   0,   0,   0,   500, 500, 0,   0,   0,   0,   0,   0,   0,   0,   0);

PopulateItemMax(BeamOfPain,				0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);

PopulateItemMax(LazerRifle,				1,   1,   1,   1,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// MISC                                        mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(flag,					1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);  
PopulateItemMax(Beacon,					25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25); 
PopulateItemMax(Grenade,				25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25,  25);
PopulateItemMax(MineAmmo,				20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20,  20);
PopulateItemMax(RepairKit,				1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// PACKS                                       mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AmmoPack,				1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(EnergyPack,				1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(RepairPack,				1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(ShieldPack,				1,   1,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1,   0,   1);
PopulateItemMax(BuilderPack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(SensorJammerPack,			1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   0,   1,   1);
PopulateItemMax(CloakingDevice,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(StealthShieldPack,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0);
PopulateItemMax(Laptop,					0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);  
PopulateItemMax(SightPack,				0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SuicidePack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0);
PopulateItemMax(RegenerationPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0);
//PopulateItemMax(LightningPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
//PopulateItemMax(TeleportPack2,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(ChameleonPack,			0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(SurveyDroidPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ProbeDroidPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(SuicideDroidPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(TitanBurstPack,		      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1);
PopulateItemMax(TrollMagmaPack,		      0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   0,   0);
PopulateItemMax(SniperPack,		      	0,   0,   0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0);
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// SENSORS                                     mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(CameraPack,				0,   0,   1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1);
PopulateItemMax(DeployableSensorJammerPack,	0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(MotionSensorPack,			0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(AlarmPack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(PulseSensorPack,			0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TURRETS                                     mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(FusionTurretPack,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(LaserTurretPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(RocketPack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   0,   0);
PopulateItemMax(PlasmaTurretPack,			0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   1,   0,   0);
PopulateItemMax(MortarTurretPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);  
PopulateItemMax(ShockTurretPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
//PopulateItemMax(MMTurretPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(NuclearTurretPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(FlameTurretPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
//PopulateItemMax(RailTurretPack,			1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(IrradiationTurretPack,		1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(TurretPack,				0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1);
PopulateItemMax(VortexTurretPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ParticleBeamTurretPack,		1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// BARRIERS                                    mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(BlastWallPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ForceFieldPack,			1,   1,   1,   1,   0,   0,   1,   1,   1,   1,   1,   1,   1,   1,   1);
PopulateItemMax(ForceFieldDoorPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(LargeForceFieldPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(LargeForceFieldDoorPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(PlatformPack,				0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   1);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// DEPLOYABLES                                 mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
//PopulateItemMax(AcceleratorDevicePack,		1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(BaseCloakPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ControlJammerPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(DeployableAmmoPack,			1,   1,   0,   0,   1,   1,   0,   0,   1,   1,   1,   1,   1,   0,   1);
PopulateItemMax(DeployableComPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1);
PopulateItemMax(DeployableInvPack,			1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0);
PopulateItemMax(FighterPack,				0,   0,   1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
PopulateItemMax(JailTower,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(JumpPadPack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
//PopulateItemMax(MannequinPack,			1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1,   1);
//PopulateItemMax(Plastique,				1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   0);
//PopulateItemMax(ProbePack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
//PopulateItemMax(SpringPack,				1,   1,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(TeleportPack,				1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0);
PopulateItemMax(TransportPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
//PopulateItemMax(TreePack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// POWER SYSTEMS                               mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(MobileInventoryPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0); 
PopulateItemMax(PortableGeneratorPack,		0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(PortableSolarPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(PowerNodePack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(SatSystemPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ShieldGenPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(ShieldNodePack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// REMOTE BASES                                mDM, fDM, lma, lfa, mas, fas, mwr, fwr, mat, fat, mdf, fdf,  BR,  HA,  DS
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---  ---
PopulateItemMax(AirBasePack,				1,   1,   0,   0,   0,   0,   0,   0,   1,   1,   1,   1,   0,   0,   0);
//PopulateItemMax(BaseOpsPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(BunkerPack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   1);
PopulateItemMax(CommandShipPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(GunShipPack,				0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);
PopulateItemMax(SupplyShipPack,			0,   0,   0,   0,   0,   0,   0,   0,   0,   0,   1,   1,   0,   0,   0);


// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM BARRIERS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[BlastWallPack] = 20;
$TeamItemMax[ForceFieldPack] = 16;
$TeamItemMax[ForceFieldDoorPack] = 8;
$TeamItemMax[LargeForceFieldPack] = 8;
$TeamItemMax[LargeForceFieldDoorPack] = 4;
$TeamItemMax[PlatformPack] = 20;

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
//$TeamItemMax[Mannequin] = 12;
$TeamItemMax[Springboard] = 3;
//$TeamItemMax[TreePack] = 4;
//$TeamItemMax[TNTPack] = 4;
$TeamItemMax[JumpPadPack] = 3;

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
//$TeamItemMax[BaseOpsPack] = 1; //Borg Cube
//$TeamItemMax[DeployableBaseOps] = 1; //Borg Cube
$TeamItemMax[AirBasePack] = 1;
$TeamItemMax[BunkerPack] = 4;
$TeamItemMax[CommandShipPack] = 1;
$TeamItemMax[GunShipPack] = 1;
$TeamItemMax[SupplyShipPack] = 1;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM SENSORS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
//$TeamItemMax[BeaconAmmo] = 20;
$TeamItemMax[CameraPack] = 10;
$TeamItemMax[DeployableSensorJammerPack] = 10;
$TeamItemMax[MotionSensorPack] = 10;
$TeamItemMax[PulseSensorPack] = 10;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM TURRETS MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[FlameTurretPack] = 6;
$TeamItemMax[FusionTurretPack] = 4;
$TeamItemMax[TurretPack] = 10;
$TeamItemMax[IrradiationTurretPack] = 2;
$TeamItemMax[LaserTurretPack] = 16;
//$TeamItemMax[MMTurretPack] = 2;
$TeamItemMax[MortarTurretPack] = 2;
$TeamItemMax[NuclearTurretPack] = 2;
$TeamItemMax[ParticleBeamTurretPack] = 2;
$TeamItemMax[PlasmaTurretPack] = 8;
//$TeamItemMax[RailTurretPack] = 4;
$TeamItemMax[RocketPack] = 6;
$TeamItemMax[ShockTurretPack] = 8;
$TeamItemMax[VortexTurretPack] = 6;

// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// TEAM VEHICLES MAXs
// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
$TeamItemMax[ScoutVehicle] = 3;
$TeamItemMax[InterceptorVehicle] = 3;
//$TeamItemMax[WraithVehicle] = 2;
$TeamItemMax[LAPCVehicle] = 2;
$TeamItemMax[HAPCVehicle] = 2;
