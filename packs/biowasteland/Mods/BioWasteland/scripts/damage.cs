
//================================================================================ Players

for(%i = -1; %i < 34; %i++)//== 33 damage types listed in baseprojdata cs
{
	%dam = 1.0; //=== Base Damage
	if (%i==25) %dam = 0; //=== grounder
	else if (%i==22) %dam = 0; //=== cloak
	else if (%i==16) %dam = 0; //=== plasmawall
	$DamageScale[aarmor,	%i] 	= %dam;
	$DamageScale[afemale,	%i] 	= %dam;
	$DamageScale[barmor,	%i] 	= %dam;
	$DamageScale[bfemale,	%i] 	= %dam;
	$DamageScale[harmor,	%i] 	= %dam;
	$DamageScale[earmor,	%i] 	= %dam;
	$DamageScale[efemale,	%i] 	= %dam;
	$DamageScale[jarmor,	%i] 	= %dam;
	$DamageScale[larmor,	%i] 	= %dam;
	$DamageScale[lfemale,	%i] 	= %dam;
	$DamageScale[marmor,	%i] 	= %dam;
	$DamageScale[mfemale,	%i] 	= %dam;
	$DamageScale[sarmor,	%i] 	= %dam;
	$DamageScale[sfemale,	%i] 	= %dam;
	$DamageScale[spyarmor,	%i] 	= %dam;
	$DamageScale[spyfemale,	%i] 	= %dam;
	$DamageScale[stimarmor,	%i] 	= %dam;
	$DamageScale[stimfemale,%i] 	= %dam;
	$DamageScale[rarmor,	%i] 	= %dam;
	$DamageScale[tarmor,	%i] 	= %dam;
}

$DamageScale[aarmor,	$BlasterDamageType] 	= 0.5;
$DamageScale[aarmor,	$DebrisDamageType] 	= 1.2;
$DamageScale[aarmor,	$ElectricityDamageType] = 0.2;
$DamageScale[aarmor,	$EnergyDamageType] 	= 0.3;
$DamageScale[aarmor,	$EqualizerDamageType] 	= 1.2;
$DamageScale[aarmor,	$ExplosionDamageType] 	= 1.1;
$DamageScale[aarmor,	$FlashDamageType] 	= 0.5;
$DamageScale[aarmor,	$GravDamageType]	= 1.7;
$DamageScale[aarmor,	$LandingDamageType] 	= 0.3;
$DamageScale[aarmor,	$LaserDamageType] 	= 0.5;
$DamageScale[aarmor,	$MissileDamageType] 	= 1.2;
$DamageScale[aarmor,	$MortarDamageType] 	= 1.5;
$DamageScale[aarmor,	$NukeDamageType] 	= 1.3;
$DamageScale[aarmor,	$PlasmaDamageType] 	= 1.5;
$DamageScale[aarmor,	$PunchType] 	= 1;
$DamageScale[aarmor,	$ShrapnelDamageType] 	= 1.2;
$DamageScale[aarmor,	$SniperDamageType] 	= 1.2;
$DamageScale[aarmor,	$FusionDamageType] 	= 1.1;

$DamageScale[afemale,	$BlasterDamageType] 	= 0.5;
$DamageScale[afemale,	$DebrisDamageType] 	= 1.2;
$DamageScale[afemale,	$ElectricityDamageType] = 0.2;
$DamageScale[afemale,	$EnergyDamageType] 	= 0.3;
$DamageScale[afemale,	$EqualizerDamageType] 	= 1.2;
$DamageScale[afemale,	$FlashDamageType] 	= 0.5;
$DamageScale[afemale,	$GravDamageType]	= 1.7;
$DamageScale[afemale,	$LandingDamageType] 	= 0.3;
$DamageScale[afemale,	$LaserDamageType] 	= 0.5;
$DamageScale[afemale,	$MissileDamageType] 	= 1.2;
$DamageScale[afemale,	$MortarDamageType] 	= 1.5;
$DamageScale[afemale,	$NukeDamageType] 	= 1.3;
$DamageScale[afemale,	$PlasmaDamageType] 	= 1.5;
$DamageScale[afemale,	$PunchType] 	= 1;
$DamageScale[afemale,	$ShrapnelDamageType] 	= 1.2;
$DamageScale[afemale,	$SniperDamageType] 	= 1.2;

$DamageScale[barmor,	$BlasterDamageType] = 1.2;
$DamageScale[barmor,	$BulletDamageType] = 1.3;
$DamageScale[barmor,	$EnergyDamageType] = 1.1;
$DamageScale[barmor,	$EqualizerDamageType] 	 = 1.1;
$DamageScale[barmor,	$ExplosionDamageType] = 0.5;
$DamageScale[barmor,	$GravDamageType] 	 = 0.1;
$DamageScale[barmor,	$LaserDamageType] = 1.2;
$DamageScale[barmor,	$MineDamageType] = 0.5;
$DamageScale[barmor,	$MissileDamageType] = 0.5;
$DamageScale[barmor,	$MortarDamageType] = 0.5;
$DamageScale[barmor,	$PlasmaDamageType] = 0.5;
$DamageScale[barmor,	$PunchType] 	= 1;
$DamageScale[barmor,	$ShrapnelDamageType] = 0.5;
$DamageScale[barmor,	$FusionDamageType] = 0.5;

$DamageScale[bfemale,	$BlasterDamageType] = 1.2;
$DamageScale[bfemale,	$BulletDamageType] = 1.3;
$DamageScale[bfemale,	$EnergyDamageType] = 1.1;
$DamageScale[bfemale,	$EqualizerDamageType]	 = 1.1;
$DamageScale[bfemale,	$ExplosionDamageType] = 0.5;
$DamageScale[bfemale,	$GravDamageType]	 = 0.1;
$DamageScale[bfemale,	$LaserDamageType] = 1.2;
$DamageScale[bfemale,	$MineDamageType] = 0.5;
$DamageScale[bfemale,	$MissileDamageType] = 0.5;
$DamageScale[bfemale,	$MortarDamageType] = 0.5;
$DamageScale[bfemale,	$PlasmaDamageType] = 0.5;
$DamageScale[bfemale,	$ShrapnelDamageType] = 0.5;
$DamageScale[bfemale,	$FusionDamageType] = 0.5;

$DamageScale[harmor,	$BlasterDamageType] = 0.7;
$DamageScale[harmor,	$BulletDamageType] = 0.5;
$DamageScale[harmor,	$CrushDamageType] = 0.8;
$DamageScale[harmor,	$DebrisDamageType] = 0.8;
$DamageScale[harmor,	$ElectricityDamageType] = 0.8;
$DamageScale[harmor,	$EnergyDamageType] = 0.7;
$DamageScale[harmor,	$EqualizerDamageType] 	 = 0.8;
$DamageScale[harmor,	$ExplosionDamageType] = 0.6;
$DamageScale[harmor,	$GravDamageType] 	 = 0.1;
$DamageScale[harmor,	$ImpactDamageType] = 0.8;
$DamageScale[harmor,	$LandingDamageType] = 0.8;
$DamageScale[harmor,	$LaserDamageType] = 0.6;
$DamageScale[harmor,	$MineDamageType] = 0.8;
$DamageScale[harmor,	$MissileDamageType] = 0.6;
$DamageScale[harmor,	$MortarDamageType] = 0.7;
$DamageScale[harmor,	$PlasmaDamageType] = 0.7;
$DamageScale[harmor,	$ShrapnelDamageType] = 0.8;
$DamageScale[harmor,	$SniperDamageType] = 0.6;
$DamageScale[harmor,	$FusionDamageType] = 0.6;

$DamageScale[earmor,	$EqualizerDamageType] 	 = 0.7;
$DamageScale[earmor,	$FlashDamageType] = 0.7;
$DamageScale[earmor,	$GravDamageType] 	 = 0.1;

$DamageScale[efemale,	$EqualizerDamageType]	 = 0.7;
$DamageScale[efemale,	$FlashDamageType] = 0.7;
$DamageScale[efemale,	$GravDamageType]	 = 0.1;

$DamageScale[jarmor,	$BlasterDamageType] = 1.5;
$DamageScale[jarmor,	$CrushDamageType] = 0.6;
$DamageScale[jarmor,	$ElectricityDamageType] = 1.2;
$DamageScale[jarmor,	$EnergyDamageType] = 1.3;
$DamageScale[jarmor,	$FlashDamageType] = 1.5;
$DamageScale[jarmor,	$GravDamageType] 	 = 0.1;
$DamageScale[jarmor,	$ImpactDamageType] = 0.5;
$DamageScale[jarmor,	$LandingDamageType] = 0.2;
$DamageScale[jarmor,	$LaserDamageType] = 0.5;
$DamageScale[jarmor,	$MortarDamageType] = 1.2;
$DamageScale[jarmor,	$PlasmaDamageType] = 2.0;

$DamageScale[larmor,	$BlasterDamageType] = 1.3;
$DamageScale[larmor,	$BulletDamageType] = 1.2;
$DamageScale[larmor,	$DebrisDamageType] = 1.2;
$DamageScale[larmor,	$EnergyDamageType] = 1.3;
$DamageScale[larmor,	$GravDamageType]	 = 0.1;
$DamageScale[larmor,	$MineDamageType] = 1.2;
$DamageScale[larmor,	$MortarDamageType] = 1.3;
$DamageScale[larmor,	$ShrapnelDamageType] = 1.2;

$DamageScale[lfemale,	$BlasterDamageType] = 1.3;
$DamageScale[lfemale,	$BulletDamageType] = 1.2;
$DamageScale[lfemale,	$DebrisDamageType] = 1.2;
$DamageScale[lfemale,	$EnergyDamageType] = 1.3;
$DamageScale[lfemale,	$GravDamageType]	 = 0.1;
$DamageScale[lfemale,	$MineDamageType] = 1.2;
$DamageScale[lfemale,	$MortarDamageType] = 1.3;
$DamageScale[lfemale,	$PunchType] 	= 1;
$DamageScale[lfemale,	$ShrapnelDamageType] = 1.2;

$DamageScale[marmor,	$ElectricityDamageType] = 0.6;
$DamageScale[marmor,	$GravDamageType]	 = 0.1;

$DamageScale[mfemale,	$ElectricityDamageType] = 0.6;
$DamageScale[mfemale,	$GravDamageType]	 = 0.1;

$DamageScale[sarmor,	$BlasterDamageType] = 1.3;
$DamageScale[sarmor,	$BulletDamageType] = 1.2;
$DamageScale[sarmor,	$CrushDamageType] = 0.5;
$DamageScale[sarmor,	$DebrisDamageType] = 1.2;
$DamageScale[sarmor,	$EnergyDamageType] = 1.3;
$DamageScale[sarmor,	$EqualizerDamageType]	 = 1.1;
$DamageScale[sarmor,	$GravDamageType]	 = 0.1;
$DamageScale[sarmor,	$ImpactDamageType] = 0.5;
$DamageScale[sarmor,	$LandingDamageType] = 0.5;
$DamageScale[sarmor,	$LaserDamageType] = 1.2;
$DamageScale[sarmor,	$MineDamageType] = 1.2;
$DamageScale[sarmor,	$MortarDamageType] = 1.3;
$DamageScale[sarmor,	$ShrapnelDamageType] = 1.2;

$DamageScale[sfemale,	$BlasterDamageType] = 1.3;
$DamageScale[sfemale,	$BulletDamageType] = 1.2;
$DamageScale[sfemale,	$CrushDamageType] = 0.5;	
$DamageScale[sfemale,	$DebrisDamageType] = 1.2;
$DamageScale[sfemale,	$EnergyDamageType] = 1.3;
$DamageScale[sfemale,	$EqualizerDamageType]	 = 1.1;
$DamageScale[sfemale,	$GravDamageType]	 = 0.1;
$DamageScale[sfemale,	$ImpactDamageType] = 0.5;	
$DamageScale[sfemale,	$LandingDamageType] = 0.5;
$DamageScale[sfemale,	$MineDamageType] = 1.2;
$DamageScale[sfemale,	$MortarDamageType] = 1.3;
$DamageScale[sfemale,	$ShrapnelDamageType] = 1.2;

$DamageScale[spyarmor,	$BlasterDamageType] = 1.3;
$DamageScale[spyarmor,	$BulletDamageType] = 0.5;
$DamageScale[spyarmor,	$DebrisDamageType] = 1.3;
$DamageScale[spyarmor,	$EnergyDamageType] = 1.3;
$DamageScale[spyarmor,	$EqualizerDamageType]	 = 0.9;
$DamageScale[spyarmor,	$ExplosionDamageType] = 1.2;
$DamageScale[spyarmor,	$GravDamageType]	 = 0.1;
$DamageScale[spyarmor,	$MineDamageType] = 1.2;
$DamageScale[spyarmor,	$MissileDamageType] = 1.3;
$DamageScale[spyarmor,	$MortarDamageType] = 1.3;
$DamageScale[spyarmor,	$NukeDamageType] = 0.9;
$DamageScale[spyarmor,	$PlasmaDamageType] = 1.2;
$DamageScale[spyarmor,	$ShrapnelDamageType] = 1.3;
$DamageScale[spyarmor,	$FusionDamageType] = 1.2;

$DamageScale[spyfemale, $GravDamageType]	 = 0.1;
$DamageScale[spyfemale, $NukeDamageType] = 0.9;
$DamageScale[spyfemale,	$BlasterDamageType] = 1.3;
$DamageScale[spyfemale,	$BulletDamageType] = 0.5;
$DamageScale[spyfemale,	$DebrisDamageType] = 1.3;
$DamageScale[spyfemale,	$EnergyDamageType] = 1.3;
$DamageScale[spyfemale,	$EqualizerDamageType]	 = 0.9;
$DamageScale[spyfemale,	$ExplosionDamageType] = 1.2;
$DamageScale[spyfemale,	$MineDamageType] = 1.2;
$DamageScale[spyfemale,	$MissileDamageType] = 1.3;
$DamageScale[spyfemale,	$MortarDamageType] = 1.3;
$DamageScale[spyfemale,	$PlasmaDamageType] = 1.2;
$DamageScale[spyfemale,	$PunchType] 	= 1;
$DamageScale[spyfemale,	$ShrapnelDamageType] = 1.3;
$DamageScale[spyfemale,	$FusionDamageType] = 1.2;

$DamageScale[stimarmor, $GravDamageType]	 = 0.1;
$DamageScale[stimarmor,	$BlasterDamageType] = 1.3;
$DamageScale[stimarmor,	$BulletDamageType] = 1.2;
$DamageScale[stimarmor,	$CrushDamageType] = 0.5;
$DamageScale[stimarmor,	$DebrisDamageType] = 1.2;
$DamageScale[stimarmor,	$EnergyDamageType] = 1.3;
$DamageScale[stimarmor,	$EqualizerDamageType]	 = 1.1;
$DamageScale[stimarmor,	$ImpactDamageType] = 0.5;
$DamageScale[stimarmor,	$LandingDamageType] = 0.5;
$DamageScale[stimarmor,	$LaserDamageType] = 1.2;
$DamageScale[stimarmor,	$MineDamageType] = 1.2;
$DamageScale[stimarmor,	$MortarDamageType] = 1.3;
$DamageScale[stimarmor,	$PunchType] 	= 1;
$DamageScale[stimarmor,	$ShrapnelDamageType] = 1.2;

$DamageScale[stimfemale,$BlasterDamageType] = 1.3;
$DamageScale[stimfemale,$BulletDamageType] = 1.2;
$DamageScale[stimfemale,$CrushDamageType] = 0.5;
$DamageScale[stimfemale,$DebrisDamageType] = 1.2;
$DamageScale[stimfemale,$EnergyDamageType] = 1.3;
$DamageScale[stimfemale,$EqualizerDamageType]	 = 1.1;
$DamageScale[stimfemale,$GravDamageType]	 = 0.1;
$DamageScale[stimfemale,$ImpactDamageType] = 0.5;
$DamageScale[stimfemale,$LandingDamageType] = 0.5;
$DamageScale[stimfemale,$LaserDamageType] = 1.2;
$DamageScale[stimfemale,$MineDamageType] = 1.2;
$DamageScale[stimfemale,$MortarDamageType] = 1.3;
$DamageScale[stimfemale,$ShrapnelDamageType] = 1.2;

$DamageScale[rarmor,	$BlasterDamageType] = 1.3;
$DamageScale[rarmor,	$BulletDamageType] = 1.2;
$DamageScale[rarmor,	$CrushDamageType] = 0.5;
$DamageScale[rarmor,	$DebrisDamageType] = 1.2;
$DamageScale[rarmor,	$EnergyDamageType] = 1.3;
$DamageScale[rarmor,	$EqualizerDamageType]	 = 1.1;
$DamageScale[rarmor,	$GravDamageType]	 = 0.1;
$DamageScale[rarmor,	$ImpactDamageType] = 0.5;
$DamageScale[rarmor,	$LandingDamageType] = 0.5;
$DamageScale[rarmor,	$LaserDamageType] = 1.2;
$DamageScale[rarmor,	$MineDamageType] = 1.2;
$DamageScale[rarmor,	$MortarDamageType] = 1.3;
$DamageScale[rarmor,	$ShrapnelDamageType] = 1.2;

//============= Vehicles

for(%i = -1; %i < 34; %i++)
{
	if(%i==22) %dam = 0;//dont take cloaking damage
	else %dam = 1.0;
	$DamageScale[BallProj,	%i] 	= %dam;
	$DamageScale[BooProj,	%i] 	= %dam;
	$DamageScale[CoolProj,	%i] 	= %dam;
	$DamageScale[EMPProj,	%i] 	= %dam;
	$DamageScale[GasProj,	%i] 	= %dam;
	$DamageScale[NapProj,	%i] 	= %dam;
	$DamageScale[SpyPodProj,%i] 	= %dam;
	$DamageScale[Scout,	%i] 	= %dam;
	$DamageScale[Prowler,	%i] 	= %dam;
	$DamageScale[Fighter,	%i] 	= %dam;
	$DamageScale[LAPC,	%i] 	= %dam;
	$DamageScale[HAPC,	%i] 	= %dam;
	$DamageScale[GAPC,	%i] 	= %dam;
	$DamageScale[Inveigler,	%i] 	= %dam;
}
$DamageScale[Inveigler,	-1] 	= 0;
$DamageScale[GAPC,	-1] 	= 0;