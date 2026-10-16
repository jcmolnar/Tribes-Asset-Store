
//XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX 		       
//XX LightArmor  =	Seraph 		larmor	lfemale XX
//XX EngArmor    =	Slave 		earmor	efemale	XX
//XX MediumArmor =	Pawn		marmor		XX
//XX AlArmor     =	Navigator	aarmor		XX
//XX DragArmor   =	Atomizer	darmor		XX
//XX BursterArmor=	Paladin		barmor       	XX
//XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX XX
	

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

$ArmorType[Male, LightArmor] = larmor; 
$ArmorType[Male, MediumArmor] = marmor; 
$ArmorType[Male, BursterArmor] = barmor; 
$ArmorType[Male, EngArmor] = earmor; 
$ArmorType[Male, DragArmor] = darmor;
$ArmorType[Male, AlArmor] = aarmor;
$ArmorType[Female, LightArmor] = lfemale; 
$ArmorType[Female, MediumArmor] = marmor; 
$ArmorType[Female, BursterArmor] = barmor; 
$ArmorType[Female, EngArmor] = earmor; 
$ArmorType[Female, DragArmor] = darmor; 
$ArmorType[Female, AlArmor] = aarmor; 

// GHOST
$ArmorType[Male, GhostArmor] = garmor;
$ArmorType[Female, GhostArmor] = gfemale; 
$ArmorName[garmor] = GhostArmor; 
$ArmorName[gfemale] = GhostArmor;

$ArmorType[Male, GhostFloorArmor] = gfarmor;
$ArmorType[Female, GhostFloorArmor] = gffemale; 
$ArmorName[gfarmor] = GhostFloorArmor; 
$ArmorName[gffemale] = GhostFloorArmor; 
// GHOST

$ArmorName[larmor] = LightArmor; 
$ArmorName[lfemale] = LightArmor; 
$ArmorName[earmor] = EngArmor;
$ArmorName[efemale] = EngArmor;
$ArmorName[marmor] = MediumArmor;
$ArmorName[aarmor] = AlArmor;
$ArmorName[barmor] = BursterArmor; 
$ArmorName[darmor] = DragArmor; 

//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
//XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
																		
$DamageScale[larmor, $LandingDamageType] = 1.0; 
$DamageScale[larmor, $ImpactDamageType] = 1.0; 
$DamageScale[larmor, $CrushDamageType] = 1.0; 
$DamageScale[larmor, $BulletDamageType] = 1.2; 
$DamageScale[larmor, $PlasmaDamageType] = 1.0; 
$DamageScale[larmor, $EnergyDamageType] = 1.3; 
$DamageScale[larmor, $ExplosionDamageType] = 1.0; 
$DamageScale[larmor, $MissileDamageType] = 1.0; 
$DamageScale[larmor, $DebrisDamageType] = 1.2; 
$DamageScale[larmor, $ShrapnelDamageType] = 1.2; 
$DamageScale[larmor, $LaserDamageType] = 1.0; 
$DamageScale[larmor, $MortarDamageType] = 1.3; 
$DamageScale[larmor, $BlasterDamageType] = 1.3; 
$DamageScale[larmor, $ElectricityDamageType] = 1.0; 
$DamageScale[larmor, $MineDamageType] = 1.2; 
$DamageScale[larmor, $SniperDamageType] = 1.0; 
$DamageScale[larmor, $FlashDamageType] = 1.0; 

$MaxWeapons[larmor] = 3; 

$DamageScale[garmor, $LandingDamageType] = 1.0; 
$DamageScale[garmor, $ImpactDamageType] = 1.0; 
$DamageScale[garmor, $CrushDamageType] = 1.0; 
$DamageScale[garmor, $BulletDamageType] = 1.2; 
$DamageScale[garmor, $PlasmaDamageType] = 1.0; 
$DamageScale[garmor, $EnergyDamageType] = 1.3; 
$DamageScale[garmor, $ExplosionDamageType] = 1.0; 
$DamageScale[garmor, $MissileDamageType] = 1.0; 
$DamageScale[garmor, $DebrisDamageType] = 1.2; 
$DamageScale[garmor, $ShrapnelDamageType] = 1.2; 
$DamageScale[garmor, $LaserDamageType] = 1.0; 
$DamageScale[garmor, $MortarDamageType] = 1.3; 
$DamageScale[garmor, $BlasterDamageType] = 1.3; 
$DamageScale[garmor, $ElectricityDamageType] = 1.0; 
$DamageScale[garmor, $MineDamageType] = 1.2; 
$DamageScale[garmor, $SniperDamageType] = 1.0; 
$DamageScale[garmor, $FlashDamageType] = 1.0; 

$MaxWeapons[garmor] = 3; 

$DamageScale[gfarmor, $LandingDamageType] = 1.0; 
$DamageScale[gfarmor, $ImpactDamageType] = 1.0; 
$DamageScale[gfarmor, $CrushDamageType] = 1.0; 
$DamageScale[gfarmor, $BulletDamageType] = 1.2; 
$DamageScale[gfarmor, $PlasmaDamageType] = 1.0; 
$DamageScale[gfarmor, $EnergyDamageType] = 1.3; 
$DamageScale[gfarmor, $ExplosionDamageType] = 1.0; 
$DamageScale[gfarmor, $MissileDamageType] = 1.0; 
$DamageScale[gfarmor, $DebrisDamageType] = 1.2; 
$DamageScale[gfarmor, $ShrapnelDamageType] = 1.2; 
$DamageScale[gfarmor, $LaserDamageType] = 1.0; 
$DamageScale[gfarmor, $MortarDamageType] = 1.3; 
$DamageScale[gfarmor, $BlasterDamageType] = 1.3; 
$DamageScale[gfarmor, $ElectricityDamageType] = 1.0; 
$DamageScale[gfarmor, $MineDamageType] = 1.2; 
$DamageScale[gfarmor, $SniperDamageType] = 1.0; 
$DamageScale[gfarmor, $FlashDamageType] = 1.0; 

$MaxWeapons[gfarmor] = 3; 

$DamageScale[marmor, $LandingDamageType] = 1.0; 
$DamageScale[marmor, $ImpactDamageType] = 1.0; 
$DamageScale[marmor, $CrushDamageType] = 1.0; 
$DamageScale[marmor, $BulletDamageType] = 1.0; 
$DamageScale[marmor, $PlasmaDamageType] = 1.0; 
$DamageScale[marmor, $EnergyDamageType] = 1.0; 
$DamageScale[marmor, $ExplosionDamageType] = 1.0; 
$DamageScale[marmor, $MissileDamageType] = 1.0; 
$DamageScale[marmor, $ShrapnelDamageType] = 1.0; 
$DamageScale[marmor, $DebrisDamageType] = 1.0; 
$DamageScale[marmor, $LaserDamageType] = 1.0; 
$DamageScale[marmor, $MortarDamageType] = 1.0; 
$DamageScale[marmor, $BlasterDamageType] = 1.0; 
$DamageScale[marmor, $ElectricityDamageType] = 1.0; 
$DamageScale[marmor, $MineDamageType] = 1.0; 
$DamageScale[marmor, $SniperDamageType] = 1.0; 
$DamageScale[marmor, $FlashDamageType] = 1.0; 

$MaxWeapons[marmor] = 5; 

$DamageScale[lfemale, $LandingDamageType] = 1.0; 
$DamageScale[lfemale, $ImpactDamageType] = 1.0; 
$DamageScale[lfemale, $CrushDamageType] = 1.0; 
$DamageScale[lfemale, $BulletDamageType] = 1.2; 
$DamageScale[lfemale, $PlasmaDamageType] = 1.0; 
$DamageScale[lfemale, $EnergyDamageType] = 1.3; 
$DamageScale[lfemale, $ExplosionDamageType] = 1.0; 
$DamageScale[lfemale, $MissileDamageType] = 1.0; 
$DamageScale[lfemale, $ShrapnelDamageType] = 1.2; 
$DamageScale[lfemale, $DebrisDamageType] = 1.2; 
$DamageScale[lfemale, $LaserDamageType] = 1.0; 
$DamageScale[lfemale, $MortarDamageType] = 1.3; 
$DamageScale[lfemale, $BlasterDamageType] = 1.3; 
$DamageScale[lfemale, $ElectricityDamageType] = 1.0; 
$DamageScale[lfemale, $MineDamageType] = 1.2; 
$DamageScale[lfemale, $SniperDamageType] = 1.0; 
$DamageScale[lfemale, $FlashDamageType] = 1.0; 

$MaxWeapons[lfemale] = 3;

$DamageScale[gfemale, $LandingDamageType] = 1.0; 
$DamageScale[gfemale, $ImpactDamageType] = 1.0; 
$DamageScale[gfemale, $CrushDamageType] = 1.0; 
$DamageScale[gfemale, $BulletDamageType] = 1.2; 
$DamageScale[gfemale, $PlasmaDamageType] = 1.0; 
$DamageScale[gfemale, $EnergyDamageType] = 1.3; 
$DamageScale[gfemale, $ExplosionDamageType] = 1.0; 
$DamageScale[gfemale, $MissileDamageType] = 1.0; 
$DamageScale[gfemale, $ShrapnelDamageType] = 1.2; 
$DamageScale[gfemale, $DebrisDamageType] = 1.2; 
$DamageScale[gfemale, $LaserDamageType] = 1.0; 
$DamageScale[gfemale, $MortarDamageType] = 1.3; 
$DamageScale[gfemale, $BlasterDamageType] = 1.3; 
$DamageScale[gfemale, $ElectricityDamageType] = 1.0; 
$DamageScale[gfemale, $MineDamageType] = 1.2; 
$DamageScale[gfemale, $SniperDamageType] = 1.0; 
$DamageScale[gfemale, $FlashDamageType] = 1.0; 

$MaxWeapons[gfemale] = 3;

$DamageScale[gffemale, $LandingDamageType] = 1.0; 
$DamageScale[gffemale, $ImpactDamageType] = 1.0; 
$DamageScale[gffemale, $CrushDamageType] = 1.0; 
$DamageScale[gffemale, $BulletDamageType] = 1.2; 
$DamageScale[gffemale, $PlasmaDamageType] = 1.0; 
$DamageScale[gffemale, $EnergyDamageType] = 1.3; 
$DamageScale[gffemale, $ExplosionDamageType] = 1.0; 
$DamageScale[gffemale, $MissileDamageType] = 1.0; 
$DamageScale[gffemale, $ShrapnelDamageType] = 1.2; 
$DamageScale[gffemale, $DebrisDamageType] = 1.2; 
$DamageScale[gffemale, $LaserDamageType] = 1.0; 
$DamageScale[gffemale, $MortarDamageType] = 1.3; 
$DamageScale[gffemale, $BlasterDamageType] = 1.3; 
$DamageScale[gffemale, $ElectricityDamageType] = 1.0; 
$DamageScale[gffemale, $MineDamageType] = 1.2; 
$DamageScale[gffemale, $SniperDamageType] = 1.0; 
$DamageScale[gffemale, $FlashDamageType] = 1.0; 

$MaxWeapons[gffemale] = 3;


$DamageScale[barmor, $LandingDamageType] = 0.5; 
$DamageScale[barmor, $ImpactDamageType] = 0.5; 
$DamageScale[barmor, $CrushDamageType] = 0.1; 
$DamageScale[barmor, $BulletDamageType] = 0.4; 
$DamageScale[barmor, $PlasmaDamageType] = 0.5; 
$DamageScale[barmor, $EnergyDamageType] = 0.5; 
$DamageScale[barmor, $ExplosionDamageType] = 0.3; 
$DamageScale[barmor, $MissileDamageType] = 0.3; 
$DamageScale[barmor, $DebrisDamageType] = 0.3; 
$DamageScale[barmor, $ShrapnelDamageType] = 0.3; 
$DamageScale[barmor, $LaserDamageType] = 1.0; 
$DamageScale[barmor, $MortarDamageType] = 0.6; 
$DamageScale[barmor, $BlasterDamageType] = 0.5; 
$DamageScale[barmor, $ElectricityDamageType] = 0.4; 
$DamageScale[barmor, $MineDamageType] = 1.0; 
$DamageScale[barmor, $SniperDamageType] = 1.0; 
$DamageScale[barmor, $FlashDamageType] = 0.3; 

$MaxWeapons[barmor] = 6; 

$DamageScale[darmor, $LandingDamageType] = 0.8; 
$DamageScale[darmor, $ImpactDamageType] = 0.8; 
$DamageScale[darmor, $CrushDamageType] = 0.8; 
$DamageScale[darmor, $BulletDamageType] = 0.5; 
$DamageScale[darmor, $PlasmaDamageType] = 0.7; 
$DamageScale[darmor, $EnergyDamageType] = 0.7; 
$DamageScale[darmor, $ExplosionDamageType] = 0.6; 
$DamageScale[darmor, $MissileDamageType] = 0.6; 
$DamageScale[darmor, $DebrisDamageType] = 0.8; 
$DamageScale[darmor, $ShrapnelDamageType] = 0.8; 
$DamageScale[darmor, $LaserDamageType] = 0.3; 
$DamageScale[darmor, $MortarDamageType] = 0.7; 
$DamageScale[darmor, $BlasterDamageType] = 0.7; 
$DamageScale[darmor, $ElectricityDamageType] = 0.8; 
$DamageScale[darmor, $MineDamageType] = 0.8; 
$DamageScale[darmor, $SniperDamageType] = 0.3; 
$DamageScale[darmor, $FlashDamageType] = 1.0; 

$MaxWeapons[darmor] = 6; 

$DamageScale[earmor, $LandingDamageType] = 1.0; 
$DamageScale[earmor, $ImpactDamageType] = 1.0; 
$DamageScale[earmor, $CrushDamageType] = 1.0; 
$DamageScale[earmor, $BulletDamageType] = 1.0; 
$DamageScale[earmor, $PlasmaDamageType] = 1.0; 
$DamageScale[earmor, $EnergyDamageType] = 1.0; 
$DamageScale[earmor, $ExplosionDamageType] = 1.0; 
$DamageScale[earmor, $MissileDamageType] = 1.0; 
$DamageScale[earmor, $ShrapnelDamageType] = 1.0; 
$DamageScale[earmor, $DebrisDamageType] = 1.0; 
$DamageScale[earmor, $LaserDamageType] = 1.0; 
$DamageScale[earmor, $MortarDamageType] = 1.0; 
$DamageScale[earmor, $BlasterDamageType] = 1.0; 
$DamageScale[earmor, $ElectricityDamageType] = 1.0; 
$DamageScale[earmor, $MineDamageType] = 1.0; 
$DamageScale[earmor, $SniperDamageType] = 1.0; 
$DamageScale[earmor, $FlashDamageType] = 1.0; 

$MaxWeapons[earmor] = 4; 

$DamageScale[efemale, $LandingDamageType] = 1.0; 
$DamageScale[efemale, $ImpactDamageType] = 1.0; 
$DamageScale[efemale, $CrushDamageType] = 1.0; 
$DamageScale[efemale, $BulletDamageType] = 1.0; 
$DamageScale[efemale, $EnergyDamageType] = 1.0; 
$DamageScale[efemale, $PlasmaDamageType] = 1.0; 
$DamageScale[efemale, $ExplosionDamageType] = 1.0; 
$DamageScale[efemale, $MissileDamageType] = 1.0; 
$DamageScale[efemale, $ShrapnelDamageType] = 1.0; 
$DamageScale[efemale, $DebrisDamageType] = 1.0; 
$DamageScale[efemale, $LaserDamageType] = 1.0; 
$DamageScale[efemale, $MortarDamageType] = 1.0; 
$DamageScale[efemale, $BlasterDamageType] = 1.0; 
$DamageScale[efemale, $ElectricityDamageType] = 1.0; 
$DamageScale[efemale, $MineDamageType] = 1.0; 
$DamageScale[efemale, $SniperDamageType] = 1.0; 
$DamageScale[efemale, $FlashDamageType] = 1.0; 

$MaxWeapons[efemale] = 4; 

$DamageScale[aarmor, $LandingDamageType] = 0.5; 
$DamageScale[aarmor, $ImpactDamageType] = 1.0; 
$DamageScale[aarmor, $CrushDamageType] = 1.0; 
$DamageScale[aarmor, $BulletDamageType] = 1.0; 
$DamageScale[aarmor, $PlasmaDamageType] = 2.0; 
$DamageScale[aarmor, $EnergyDamageType] = 1.0; 
$DamageScale[aarmor, $ExplosionDamageType] = 1.0; 
$DamageScale[aarmor, $MissileDamageType] = 1.0; 
$DamageScale[aarmor, $ShrapnelDamageType] = 1.0; 
$DamageScale[aarmor, $DebrisDamageType] = 1.0; 
$DamageScale[aarmor, $LaserDamageType] = 0.5; 
$DamageScale[aarmor, $MortarDamageType] = 1.2; 
$DamageScale[aarmor, $BlasterDamageType] = 0.5; 
$DamageScale[aarmor, $ElectricityDamageType] = 0.5; 
$DamageScale[aarmor, $MineDamageType] = 1.0; 
$DamageScale[aarmor, $SniperDamageType] = 1.0; 
$DamageScale[aarmor, $FlashDamageType] = 2.0; 

$MaxWeapons[aarmor] = 4; 


DamageSkinData armorDamageSkins { 
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



PlayerData larmor
{ 
	className = "Armor"; 
	shapeFile = "larmor"; 
	damageSkinData = "armorDamageSkins"; 
	debrisId = playerDebris; 
	flameShapeName = "paint"; 
	shieldShapeName = "shield"; 
	shadowDetailMask = 1; 
	visibleToSensor = True; 
	mapFilter = 1; 
	mapIcon = "M_player"; 
	canCrouch = true; 
	maxJetSideForceFactor = 12; 
	maxJetForwardVelocity = 22; 
	minJetEnergy = 1; 
	jetForce = 236; 
	jetEnergyDrain = 1.4; 
	maxDamage = 0.66; 
	maxForwardSpeed = 16; 
	maxBackwardSpeed = 16; 
	maxSideSpeed = 16; 
	groundForce = 40 * 9.0; 
	mass = 9.0; 
	groundTraction = 3.0; 
	maxEnergy = 125; 
	drag = 1.0; 
	density = 1.2; 
	minDamageSpeed = 25; 
	damageScale = 0.005; 
	jumpImpulse = 120; 
	jumpSurfaceMinDot = 0.2; 
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14] = { "fall", none, 1, true, true, true, false, 3 };
	animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
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
	animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
	animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
	footPrints = { 0, 1 };
	boxWidth = 0.5;
	boxDepth = 0.5;
	boxNormalHeight = 2.2;
	boxCrouchHeight = 1.8;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage = 0.6666;
	boxCrouchTorsoPercentage = 0.3333;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
};

PlayerData garmor
{ 
	className = "Armor"; 
	shapeFile = "larmor"; 
	damageSkinData = "armorDamageSkins"; 
	debrisId = playerDebris; 
	flameShapeName = "paint"; 
	shieldShapeName = "shield"; 
	shadowDetailMask = 1; 
	visibleToSensor = True; 
	mapFilter = 1; 
	mapIcon = "M_player"; 
	canCrouch = true; 
	maxJetSideForceFactor = 12; 
	maxJetForwardVelocity = 22; 
	minJetEnergy = 1; 
	jetForce = 236; 
	jetEnergyDrain = 1.4; 
	maxDamage = 0.66; 
	maxForwardSpeed = 16; 
	maxBackwardSpeed = 16; 
	maxSideSpeed = 16; 
	groundForce = 40 * 9.0; 
	mass = 9.0; 
	groundTraction = 3.0; 
	maxEnergy = 125; 
	drag = 1.0; 
	density = 1.2; 
	minDamageSpeed = 25; 
	damageScale = 0.005; 
	jumpImpulse = 120; 
	jumpSurfaceMinDot = 0.2; 
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14] = { "fall", none, 1, true, true, true, false, 3 };
	animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
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
	animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
	animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
	footPrints = { 0, 1 };
	boxWidth = 0.0;
	boxDepth = 0.0;
	boxNormalHeight = 2.2;
	boxCrouchHeight = 1.8;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage = 0.6666;
	boxCrouchTorsoPercentage = 0.3333;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
};


PlayerData gfarmor
{ 
	className = "Armor"; 
	shapeFile = "larmor"; 
	damageSkinData = "armorDamageSkins"; 
	debrisId = playerDebris; 
	flameShapeName = "paint"; 
	shieldShapeName = "shield"; 
	shadowDetailMask = 1; 
	visibleToSensor = True; 
	mapFilter = 1; 
	mapIcon = "M_player"; 
	canCrouch = true; 
	maxJetSideForceFactor = 12; 
	maxJetForwardVelocity = 22; 
	minJetEnergy = 1; 
	jetForce = 236; 
	jetEnergyDrain = 1.4; 
	maxDamage = 0.66; 
	maxForwardSpeed = 16; 
	maxBackwardSpeed = 16; 
	maxSideSpeed = 16; 
	groundForce = 40 * 9.0; 
	mass = 9.0; 
	groundTraction = 3.0; 
	maxEnergy = 125; 
	drag = 1.0; 
	density = 1.2; 
	minDamageSpeed = 25; 
	damageScale = 0.005; 
	jumpImpulse = 120; 
	jumpSurfaceMinDot = 0.2; 
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14] = { "fall", none, 1, true, true, true, false, 3 };
	animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 };
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
	animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
	animData[43] = { "celebration 1",none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
	footPrints = { 0, 1 };
	boxWidth = 0.5;
	boxDepth = 0.5;
	boxNormalHeight = 0.0;
	boxCrouchHeight = 0.0;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage = 0.6666;
	boxCrouchTorsoPercentage = 0.3333;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
}; 

PlayerData marmor 
{ 
	className = "Armor"; 
	shapeFile = "marmor"; 
	flameShapeName = "lflame";
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
	jetForce = 325; 
	jetEnergyDrain = 1.0; 
	maxDamage = 1.0; 
	maxForwardSpeed = 9.0; 
	maxBackwardSpeed = 7.0; 
	maxSideSpeed = 7.0; 
	groundForce = 35 * 13.0; 
	mass = 13.0; 
	groundTraction = 3.0; 
	maxEnergy = 90; 
	drag = 1.0; 
	density = 1.5; 
	minDamageSpeed = 25; 
	damageScale = 0.005; 
	jumpImpulse = 110; 
	jumpSurfaceMinDot = 0.2; 
	animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
	animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
	animData[2] = { "runback", none, 1, true, false, true, false, 3 }; animData[3] = { "side left", none, 1, true, false, true, false, 3 }; animData[4] = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; 
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; 
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; 
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; 
	animData[14] = { "fall", none, 1, true, true, true, false, 3 }; 
	animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
	animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; 
	animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; 
	animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; 
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; 
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; 
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
	animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; 
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; 
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; 
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; 
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; 
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft };
	lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };
	footPrints = { 2, 3 };
	boxWidth = 0.7;
	boxDepth = 0.7;
	boxNormalHeight = 2.4;
	boxNormalHeadPercentage = 0.83;
	boxNormalTorsoPercentage = 0.49;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
}; 

PlayerData lfemale 
{ 

	className = "Armor"; 
	shapeFile = "lfemale"; 
	flameShapeName = "paint"; 
	shieldShapeName = "shield"; 
	damageSkinData = "armorDamageSkins"; 
	debrisId = playerDebris; 
	shadowDetailMask = 1; 
	visibleToSensor = True; 
	mapFilter = 1; 
	mapIcon = "M_player"; 
	canCrouch = true; 
	maxJetSideForceFactor = 12; 
	maxJetForwardVelocity = 22; 
	minJetEnergy = 1; 
	jetForce = 236; 
	jetEnergyDrain = 1.4; 
	maxDamage = 0.66; 
	maxForwardSpeed = 16; 
	maxBackwardSpeed = 16; 
	maxSideSpeed = 16; 
	groundForce = 40 * 9.0; 
	mass = 9.0; 
	groundTraction = 3.0; 
	maxEnergy = 125; 
	drag = 1.0; 
	density = 1.2; 
	minDamageSpeed = 25; 
	damageScale = 0.005; 
	jumpImpulse = 120; 
	jumpSurfaceMinDot = 0.2; 
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14] = { "fall", none, 1, true, true, true, false, 3 };
	animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
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
	animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
	footPrints = { 0, 1 };
	boxWidth = 0.5; //0.5
	boxDepth = 0.5;	//0.5
	boxNormalHeight = 2.2;
	boxCrouchHeight = 1.8;
	boxNormalHeadPercentage = 0.85;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage = 0.88;
	boxCrouchTorsoPercentage = 0.35;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
}; 

PlayerData gfemale 
{ 

	className = "Armor"; 
	shapeFile = "lfemale"; 
	flameShapeName = "paint"; 
	shieldShapeName = "shield"; 
	damageSkinData = "armorDamageSkins"; 
	debrisId = playerDebris; 
	shadowDetailMask = 1; 
	visibleToSensor = True; 
	mapFilter = 1; 
	mapIcon = "M_player"; 
	canCrouch = true; 
	maxJetSideForceFactor = 12; 
	maxJetForwardVelocity = 22; 
	minJetEnergy = 1; 
	jetForce = 236; 
	jetEnergyDrain = 1.4; 
	maxDamage = 0.66; 
	maxForwardSpeed = 16; 
	maxBackwardSpeed = 16; 
	maxSideSpeed = 16; 
	groundForce = 40 * 9.0; 
	mass = 9.0; 
	groundTraction = 3.0; 
	maxEnergy = 125; 
	drag = 1.0; 
	density = 1.2; 
	minDamageSpeed = 25; 
	damageScale = 0.005; 
	jumpImpulse = 120; 
	jumpSurfaceMinDot = 0.2; 
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14] = { "fall", none, 1, true, true, true, false, 3 };
	animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
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
	animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
	footPrints = { 0, 1 };
	boxWidth = 0.0; //0.5
	boxDepth = 0.0;	//0.5
	boxNormalHeight = 2.2;
	boxCrouchHeight = 1.8;
	boxNormalHeadPercentage = 0.85;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage = 0.88;
	boxCrouchTorsoPercentage = 0.35;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
}; 

PlayerData gffemale 
{ 

	className = "Armor"; 
	shapeFile = "lfemale"; 
	flameShapeName = "paint"; 
	shieldShapeName = "shield"; 
	damageSkinData = "armorDamageSkins"; 
	debrisId = playerDebris; 
	shadowDetailMask = 1; 
	visibleToSensor = True; 
	mapFilter = 1; 
	mapIcon = "M_player"; 
	canCrouch = true; 
	maxJetSideForceFactor = 12; 
	maxJetForwardVelocity = 22; 
	minJetEnergy = 1; 
	jetForce = 236; 
	jetEnergyDrain = 1.4; 
	maxDamage = 0.66; 
	maxForwardSpeed = 16; 
	maxBackwardSpeed = 16; 
	maxSideSpeed = 16; 
	groundForce = 40 * 9.0; 
	mass = 9.0; 
	groundTraction = 3.0; 
	maxEnergy = 125; 
	drag = 1.0; 
	density = 1.2; 
	minDamageSpeed = 25; 
	damageScale = 0.005; 
	jumpImpulse = 120; 
	jumpSurfaceMinDot = 0.2; 
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14] = { "fall", none, 1, true, true, true, false, 3 };
	animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
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
	animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRHard, SoundLFootRSnow, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft, SoundLFootRSoft };
	lFootSounds = { SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLHard, SoundLFootLSnow, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft, SoundLFootLSoft };
	footPrints = { 0, 1 };
	boxWidth = 0.5; //0.5
	boxDepth = 0.5;	//0.5
	boxNormalHeight = 0.0; //2.2
	boxCrouchHeight = 0.0; //1.8
	boxNormalHeadPercentage = 0.85;
	boxNormalTorsoPercentage = 0.53;
	boxCrouchHeadPercentage = 0.88;
	boxCrouchTorsoPercentage = 0.35;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
}; 

PlayerData mfemale 
{ 
	className = "Armor"; 
	shapeFile = "mfemale"; 
	flameShapeName = "mflame"; 
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
	jetForce = 325; 
	jetEnergyDrain = 1.0; 
	canCrouch = false; 
	maxDamage = 1.0; 
	maxForwardSpeed = 9.0; 
	maxBackwardSpeed = 7.0; 
	maxSideSpeed = 7.0; 
	groundForce = 35 * 13.0; 
	mass = 13.0; 
	groundTraction = 3.0; 
	maxEnergy = 90; 
	drag = 1.0; 
	density = 1.5; 
	minDamageSpeed = 25; 
	damageScale = 0.005; 
	jumpImpulse = 110; 
	jumpSurfaceMinDot = 0.2; 
	animData[0] = { "root", none, 1, true, true, true, false, 0 };
	animData[1] = { "run", none, 1, true, false, true, false, 3 };
	animData[2] = { "runback", none, 1, true, false, true, false, 3 };
	animData[3] = { "side left", none, 1, true, false, true, false, 3 };
	animData[4] = { "side left", none, -1, true, false, true, false, 3 };
	animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
	animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
	animData[7] = { "crouch root", none, 1, true, false, true, false, 3 };
	animData[8] = { "crouch root", none, 1, true, false, true, false, 3 };
	animData[9] = { "crouch root", none, -1, true, false, true, false, 3 };
	animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 };
	animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 };
	animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 };
	animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 };
	animData[14] = { "fall", none, 1, true, true, true, false, 3 };
	animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
	animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
	animData[18] = { "tumble end", none, 1, true, false, false, false, 3 };
	animData[19] = { "jet", none, 1, true, true, true, false, 3 };
	animData[20] = { "PDA access", none, 1, true, false, false, false, 3 };
	animData[21] = { "throw", none, 1, true, false, false, false, 3 };
	animData[22] = { "flyer root", none, 1, false, false, false, false, 3 };
	animData[23] = { "apc root", none, 1, true, true, true, false, 3 };
	animData[24] = { "apc root", none, 1, false, false, false, false, 3 };
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
	animData[38] = { "sign over here", none, 1, true, false, false, false, 2 };
	animData[39] = { "sign point", none, 1, true, false, false, true, 1 };
	animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 };
	animData[41] = { "sign stop", none, 1, true, false, false, true, 1 };
	animData[42] = { "sign salut", none, 1, true, false, false, true, 1 };
	animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 };
	animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 };
	animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 };
	animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 };
	animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 };
	animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 };
	animData[49] = { "pose stand", none, 1, true, false, false, true, 1 };
	animData[50] = { "wave", none, 1, true, false, false, true, 1 };
	jetSound = SoundJetLight;
	rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft };
	lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft };
	footPrints = { 2, 3 };
	boxWidth = 0.7;
	boxDepth = 0.7;
	boxNormalHeight = 2.4;
	boxNormalHeadPercentage = 0.84;
	boxNormalTorsoPercentage = 0.55;
	boxHeadLeftPercentage = 0;
	boxHeadRightPercentage = 1;
	boxHeadBackPercentage = 0;
	boxHeadFrontPercentage = 1;
}; 


PlayerData barmor 
{ 
className = "Armor"; 
shapeFile = "harmor"; 
flameShapeName = "breath"; //hflame  //fusionex
shieldShapeName = "fusionex"; //shield
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.5; 
maxJetForwardVelocity = 20; 
minJetEnergy = 1; 
jetForce = 200; 
jetEnergyDrain = 0; 
maxDamage = 2.50; 
maxForwardSpeed = 4.75;
maxBackwardSpeed = 2.5;
maxSideSpeed = 3.5;
groundForce = 35 * 18.0;
mass = 25.0; 
maxEnergy = 300; 
drag = 1.0; 
density = 3.5; 
canCrouch = false; 
minDamageSpeed = 25; 
damageScale = 0.006; 
jumpImpulse = 200; 
jumpSurfaceMinDot = 0.2; 


//animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
//animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
//animData[2] = { "runback", none, 1, true, false, true, false, 3 };
//animData[3] = { "side left", none, 1, true, false, true, false, 3 };
//animData[4] = { "side left", none, -1, true, false, true, false, 3 };
//animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
//animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
//animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
//animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
//animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
//animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundMortarIdle; rFootSounds = { SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSnow, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft }; lFootSounds = { SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSnow, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft }; footPrints = { 4, 5 }; boxWidth = 0.8; boxDepth = 0.8; boxNormalHeight = 2.6; boxNormalHeadPercentage = 0.70; boxNormalTorsoPercentage = 0.45; boxHeadLeftPercentage = 0.48; boxHeadRightPercentage = 0.70; boxHeadBackPercentage = 0.48; boxHeadFrontPercentage = 0.60; }; 

animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 };
animData[3] = { "side left", none, 1, true, false, true, false, 3 };
animData[4] = { "side left", none, -1, true, false, true, false, 3 };
animData[5] = { "jump stand", none, 1, true, false, true, false, 3 };
animData[6] = { "jump run", none, 1, true, false, true, false, 3 };
animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[9] = { "crouch root", none, -1, true, true, true, false, 3 };
animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", turretExplosion, 1, true, false, false, false, 3 }; animData[16] = { "landing", turretExplosion, 1, true, false, false, false, 3 }; animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundJetHeavy; rFootSounds = { turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion }; lFootSounds = { turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion, turretExplosion }; footPrints = { 4, 5 }; boxWidth = 0.8; boxDepth = 0.8; boxNormalHeight = 2.6; boxNormalHeadPercentage = 0.70; boxNormalTorsoPercentage = 0.45; boxHeadLeftPercentage = 0.48; boxHeadRightPercentage = 0.70; boxHeadBackPercentage = 0.48; boxHeadFrontPercentage = 0.60; }; 


	//turretExplosion


PlayerData darmor 
{ 
className = "Armor"; 
shapeFile = "harmor"; 
flameShapeName = "breath"; 
shieldShapeName = "plasmaex"; 
damageSkinData = "armorDamageSkins"; 
debrisId = playerDebris; 
shadowDetailMask = 1; 
visibleToSensor = True; 
mapFilter = 1; 
mapIcon = "M_player"; 
maxJetSideForceFactor = 0.8;
maxJetForwardVelocity = 12;
minJetEnergy = 1;
jetForce = 300;
jetEnergyDrain = 1.0;
maxDamage = 1.9;
maxForwardSpeed = 11.0;
maxBackwardSpeed = 7.0;
maxSideSpeed = 6.0;
groundForce = 35 * 18.0;
mass = 16.0;
groundTraction = 5.0;
maxEnergy = 200;
drag = 1.0; 
density = 2.5; 
canCrouch = false; 
minDamageSpeed = 25; 
damageScale = 0.006; 
jumpImpulse = 200; 
jumpSurfaceMinDot = 0.2; 


animData[0] = { "root", none, 1, true, true, true, false, 0 }; 
animData[1] = { "run", none, 1, true, false, true, false, 3 }; 
animData[2] = { "runback", none, 1, true, false, true, false, 3 }; animData[3] = { "side left", none, 1, true, false, true, false, 3 }; animData[4] = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundJetHeavy; rFootSounds = { SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRHard, SoundHFootRSnow, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft, SoundHFootRSoft }; lFootSounds = { SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLHard, SoundHFootLSnow, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft, SoundHFootLSoft }; footPrints = { 4, 5 }; boxWidth = 0.8; boxDepth = 0.8; boxNormalHeight = 2.6; boxNormalHeadPercentage = 0.70; boxNormalTorsoPercentage = 0.45; boxHeadLeftPercentage = 0.48; boxHeadRightPercentage = 0.70; boxHeadBackPercentage = 0.48; boxHeadFrontPercentage = 0.60; }; 


PlayerData earmor 
{ 
className = "Armor"; shapeFile = "marmor"; flameShapeName = "breath"; shieldShapeName = "shield"; damageSkinData = "armorDamageSkins"; debrisId = playerDebris; shadowDetailMask = 1; canCrouch = true; visibleToSensor = True; mapFilter = 1; mapIcon = "M_player"; maxJetSideForceFactor = 0.8; maxJetForwardVelocity = 17; minJetEnergy = 1; jetForce = 420; jetEnergyDrain = 1.0; maxDamage = 1.0; maxForwardSpeed = 7.0; maxBackwardSpeed = 6.0; maxSideSpeed = 6.0; groundForce = 35 * 13.0; mass = 15.0; groundTraction = 4.0; maxEnergy = 90; drag = 1.0; density = 1.5; minDamageSpeed = 25; damageScale = 0.005; jumpImpulse = 100; jumpSurfaceMinDot = 0.2; animData[0] = { "root", none, 1, true, true, true, false, 0 }; animData[1] = { "run", none, 1, true, false, true, false, 3 }; animData[2] = { "runback", none, 1, true, false, true, false, 3 }; animData[3] = { "side left", none, 1, true, false, true, false, 3 }; animData[4] = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundJetLight; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; footPrints = { 2, 3 }; boxWidth = 0.7; boxDepth = 0.7; boxNormalHeight = 2.4; boxNormalHeadPercentage = 0.83; boxNormalTorsoPercentage = 0.49; boxHeadLeftPercentage = 0; boxHeadRightPercentage = 1; boxHeadBackPercentage = 0; boxHeadFrontPercentage = 1; }; 



PlayerData efemale { className = "Armor"; shapeFile = "mfemale"; flameShapeName = "breath"; shieldShapeName = "shield"; damageSkinData = "armorDamageSkins"; debrisId = playerDebris; shadowDetailMask = 1; visibleToSensor = True; mapFilter = 1; mapIcon = "M_player"; maxJetSideForceFactor = 0.8; maxJetForwardVelocity = 17; minJetEnergy = 1; jetForce = 420; jetEnergyDrain = 1.0; canCrouch = true; maxDamage = 1.0; maxForwardSpeed = 8.0; maxBackwardSpeed = 7.0; maxSideSpeed = 7.0; groundForce = 35 * 13.0; mass = 13.0; groundTraction = 3.0; maxEnergy = 90; drag = 1.0; density = 1.5; minDamageSpeed = 25; damageScale = 0.005; jumpImpulse = 110; jumpSurfaceMinDot = 0.2; animData[0] = { "root", none, 1, true, true, true, false, 0 }; animData[1] = { "run", none, 1, true, false, true, false, 3 }; animData[2] = { "runback", none, 1, true, false, true, false, 3 }; animData[3] = { "side left", none, 1, true, false, true, false, 3 }; animData[4] = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundFireTargetingLaser; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; footPrints = { 2, 3 }; boxWidth = 0.7; boxDepth = 0.7; boxNormalHeight = 2.4; boxNormalHeadPercentage = 0.84; boxNormalTorsoPercentage = 0.55; boxHeadLeftPercentage = 0; boxHeadRightPercentage = 1; boxHeadBackPercentage = 0; boxHeadFrontPercentage = 1; }; 

//SoundBeaconActive

PlayerData aarmor { className = "Armor"; shapeFile = "harmor"; flameShapeName = "shield_large"; shieldShapeName = "shield"; damageSkinData = "armorDamageSkins"; debrisId = playerDebris; shadowDetailMask = 1; canCrouch = true; visibleToSensor = False; mapFilter = 1; mapIcon = "M_player"; maxJetSideForceFactor = 0.8; maxJetForwardVelocity = 17; minJetEnergy = 1; jetForce = 325; jetEnergyDrain = 1.0; maxDamage = 1.1; maxForwardSpeed = 12.0; maxBackwardSpeed = 11.0; maxSideSpeed = 11.0; groundForce = 35 * 13.0; mass = 15.0; groundTraction = 3.0; maxEnergy = 300; drag = 1.0; density = 1.5; minDamageSpeed = 25; damageScale = 0.005; jumpImpulse = 110; jumpSurfaceMinDot = 0.2; animData[0] = { "root", none, 1, true, true, true, false, 0 }; animData[1] = { "run", none, 1, true, false, true, false, 3 }; animData[2] = { "runback", none, 1, true, false, true, false, 3 }; animData[3] = { "side left", none, 1, true, false, true, false, 3 }; animData[4] = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundBeaconActive; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; footPrints = { 2, 3 }; boxWidth = 0.7; boxDepth = 0.7; boxNormalHeight = 2.4; boxNormalHeadPercentage = 0.83; boxNormalTorsoPercentage = 0.49; boxHeadLeftPercentage = 0; boxHeadRightPercentage = 1; boxHeadBackPercentage = 0; boxHeadFrontPercentage = 1; }; 



PlayerData afemale { className = "Armor"; shapeFile = "mfemale"; flameShapeName = "mflame"; shieldShapeName = "shield"; damageSkinData = "armorDamageSkins"; debrisId = playerDebris; shadowDetailMask = 1; visibleToSensor = True; mapFilter = 1; mapIcon = "M_player"; maxJetSideForceFactor = 0.8; maxJetForwardVelocity = 17; minJetEnergy = 1; jetForce = 325; jetEnergyDrain = 1.2; canCrouch = true; maxDamage = 1.0; maxForwardSpeed = 9.0; maxBackwardSpeed = 8.0; maxSideSpeed = 8.0; groundForce = 35 * 13.0; mass = 15.0; groundTraction = 3.0; maxEnergy = 200; drag = 1.0; density = 1.5; minDamageSpeed = 25; damageScale = 0.005; jumpImpulse = 110; jumpSurfaceMinDot = 0.2; animData[0] = { "root", none, 1, true, true, true, false, 0 }; animData[1] = { "run", none, 1, true, false, true, false, 3 }; animData[2] = { "runback", none, 1, true, false, true, false, 3 }; animData[3] = { "side left", none, 1, true, false, true, false, 3 }; animData[4] = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[8] = { "crouch root", none, 1, true, false, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, false, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 }; animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc root", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundJetLight; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; footPrints = { 2, 3 }; boxWidth = 0.7; boxDepth = 0.7; boxNormalHeight = 2.4; boxNormalHeadPercentage = 0.84; boxNormalTorsoPercentage = 0.55; boxHeadLeftPercentage = 0; boxHeadRightPercentage = 1; boxHeadBackPercentage = 0; boxHeadFrontPercentage = 1; }; 



PlayerData dmarmor { className = "Armor"; shapeFile = "marmor"; flameShapeName = "mflame"; shieldShapeName = "shield"; damageSkinData = "armorDamageSkins"; debrisId = playerDebris; shadowDetailMask = 1; canCrouch = true; visibleToSensor = True; mapFilter = 1; mapIcon = "M_player"; maxJetSideForceFactor = 0.8; maxJetForwardVelocity = 17; minJetEnergy = 1; jetForce = 325; jetEnergyDrain = 1.0; maxDamage = 1.0; maxForwardSpeed = 15.0; maxBackwardSpeed = 12.0; maxSideSpeed = 12.0; groundForce = 35 * 13.0; mass = 13.0; groundTraction = 3.0; maxEnergy = 90; drag = 1.0; density = 1.5; minDamageSpeed = 25; damageScale = 0.005; jumpImpulse = 115; jumpSurfaceMinDot = 0.2; animData[0] = { "root", none, 1, true, true, true, false, 0 }; animData[1] = { "run", none, 1, true, false, true, false, 3 }; animData[2] = { "runback", none, 1, true, false, true, false, 3 }; animData[3] = { "side left", none, 1, true, false, true, false, 3 }; animData[4] = { "side left", none, -1, true, false, true, false, 3 }; animData[5] = { "jump stand", none, 1, true, false, true, false, 3 }; animData[6] = { "jump run", none, 1, true, false, true, false, 3 }; animData[7] = { "crouch root", none, 1, true, true, true, false, 3 };
animData[8] = { "crouch root", none, 1, true, true, true, false, 3 }; animData[9] = { "crouch root", none, -1, true, true, true, false, 3 }; animData[10] = { "crouch forward", none, 1, true, false, true, false, 3 }; animData[11] = { "crouch forward", none, -1, true, false, true, false, 3 }; animData[12] = { "crouch side left", none, 1, true, false, true, false, 3 }; animData[13] = { "crouch side left", none, -1, true, false, true, false, 3 }; animData[14] = { "fall", none, 1, true, true, true, false, 3 }; animData[15] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 }; animData[16] = { "landing", SoundLandOnGround, 1, true, false, false, false, 3 };
animData[17] = { "tumble loop", none, 1, true, false, false, false, 3 };
animData[18] = { "tumble end", none, 1, true, false, false, false, 3 }; animData[19] = { "jet", none, 1, true, true, true, false, 3 }; animData[20] = { "PDA access", none, 1, true, false, false, false, 3 }; animData[21] = { "throw", none, 1, true, false, false, false, 3 }; animData[22] = { "flyer root", none, 1, false, false, false, false, 3 }; animData[23] = { "apc root", none, 1, true, true, true, false, 3 }; animData[24] = { "apc pilot", none, 1, false, false, false, false, 3 }; animData[25] = { "crouch die", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[26] = { "die chest", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[27] = { "die head", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[28] = { "die grab back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[29] = { "die right side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[30] = { "die left side", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[31] = { "die leg left", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[32] = { "die leg right", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[33] = { "die blown back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[34] = { "die spin", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[35] = { "die forward", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[36] = { "die forward kneel", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[37] = { "die back", SoundPlayerDeath, 1, false, false, false, false, 4 }; animData[38] = { "sign over here", none, 1, true, false, false, false, 2 }; animData[39] = { "sign point", none, 1, true, false, false, true, 1 }; animData[40] = { "sign retreat",none, 1, true, false, false, false, 2 }; animData[41] = { "sign stop", none, 1, true, false, false, true, 1 }; animData[42] = { "sign salut", none, 1, true, false, false, true, 1 }; animData[43] = { "celebration 1", none, 1, true, false, false, false, 2 }; animData[44] = { "celebration 2", none, 1, true, false, false, false, 2 }; animData[45] = { "celebration 3", none, 1, true, false, false, false, 2 }; animData[46] = { "taunt 1", none, 1, true, false, false, false, 2 }; animData[47] = { "taunt 2", none, 1, true, false, false, false, 2 }; animData[48] = { "pose kneel", none, 1, true, false, false, true, 1 }; animData[49] = { "pose stand", none, 1, true, false, false, true, 1 }; animData[50] = { "wave", none, 1, true, false, false, true, 1 }; jetSound = SoundJetLight; rFootSounds = { SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRHard, SoundMFootRSnow, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft, SoundMFootRSoft }; lFootSounds = { SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLHard, SoundMFootLSnow, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft, SoundMFootLSoft }; footPrints = { 2, 3 }; boxWidth = 0.7; boxDepth = 0.7; boxNormalHeight = 2.4; boxNormalHeadPercentage = 0.83; boxNormalTorsoPercentage = 0.49; boxHeadLeftPercentage = 0; boxHeadRightPercentage = 1; boxHeadBackPercentage = 0; boxHeadFrontPercentage = 1; }; 


