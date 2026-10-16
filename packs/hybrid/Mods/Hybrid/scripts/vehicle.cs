//----------------------------------------------------------------------------
//

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "Flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 50;
   minSpeed = -50;
	lift = 0.75;
	maxAlt = 2500;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 0;

	projectileType = Blazterbolt;
	reloadDelay = 0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Scout";
};

FlierData Warthog
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "Flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 70;
   minSpeed = -70;
	lift = 0.75;
	maxAlt = 2500;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 0;

	projectileType = FuzionRifleBullet;
	reloadDelay = 0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "armagedon";
};

FlierData SR71
{
   explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "Flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 90;
   minSpeed = -90;
	lift = 0.75;
	maxAlt = 2500;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 0;

	projectileType = MinigunBullet;
	reloadDelay = 0;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "armagedon2";
};

FlierData Enterprise
{
    explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "Flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 100;
   minSpeed = -100;
	lift = 0.75;
	maxAlt = 2500;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 0;

	projectileType = HellStormCloud;
	reloadDelay = 0.5;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "armagedon3";
};

FlierData Bomber
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.75;
   maxPitch = 0.75;
   maxSpeed = 80;
   minSpeed = -80;
	lift = 0.75;
	maxAlt = 2500;
	maxVertical = 10;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = BomberShell;
	reloadDelay = 0.5;
	repairRate = 0;
	fireSound = SoundFireMortar;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "B-52 Bomber";
};

FlierData SpeedBike
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 1.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 300;
   minSpeed = -100;
	lift = 5;
	maxAlt = 1000;
	maxVertical = 2.5;
	maxDamage = 0.3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 2.0;

	groundDamageScale = 1.0;

	projectileType = plasmablasterbolt;
	reloadDelay = 0.3;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Scout34";
};

FlierData Colossus
{
     explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 1.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 300;
   minSpeed = -100;
	lift = 5;
	maxAlt = 1000;
	maxVertical = 2.5;
	maxDamage = 0.3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 2.0;

	groundDamageScale = 1.0;

	projectileType = Discshell;
	reloadDelay = 0.3;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Scout23";
};

FlierData Arwing
{
	     explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 1.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 300;
   minSpeed = -100;
	lift = 5;
	maxAlt = 1000;
	maxVertical = 2.5;
	maxDamage = 0.3;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 2.0;

	groundDamageScale = 1.0;

	projectileType = HybridRPG;
	reloadDelay = 0.2;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundFlierCrash;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 22;
	description = "Scout238";
};

FlierData LAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 55;
   minSpeed = -55;
	lift = 0.5;
	maxAlt = 1500;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;
      
      projectileType = RepairShellBullet;
	reloadDelay = 0.5;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 12;
	description = "LPC";
};

FlierData HAPC
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.25;
   maxPitch = 0.175;
   maxSpeed = 65;								   
   minSpeed = -65;
	lift = 0.35;
	maxAlt = 1500;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;
      
      projectileType = HybridRocket;
	reloadDelay = 0.2;
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 12;
	description = "HPC";
};


//----------------------------------------------------------------------------

$DamageScale[Scout,$ImpactDamageType] = 1.0;
$DamageScale[Scout,$LandingDamageType] = 1.0;           
$DamageScale[Scout,$RipperBulletDamageType] = 1.0;                              
$DamageScale[Scout,$EnergyDamageType] = 1.0;                                    
$DamageScale[Scout,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[Scout,$StormHammerDamageType] = 1.0;                              
$DamageScale[Scout,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[Scout,$LazereXDamageType] = 1.0;                                    
$DamageScale[Scout,$SplitMortarDamageType] = 1.0;                                
$DamageScale[Scout,$BlazterDamageType] = 1.0;                                    
$DamageScale[Scout,$ElectricityDamageType] = 1.0;                                
$DamageScale[Scout,$CrushDamageType] = 1.0;                                      
$DamageScale[Scout,$DebrisDamageType] = 1.0;                                     
$DamageScale[Scout,$MissileDamageType] = 1.0;                                    
$DamageScale[Scout,$MineDamageType] = 1.0;                                       
$DamageScale[Scout,$FusionDamageType] = 1.0;                                     
$DamageScale[Scout,$TimeBombDamageType] = 1.0;                                 
$DamageScale[Scout,$FuzionDamageType] = 1.0;                                    
$DamageScale[Scout,$HavocDamageType] = 1.0;                                    
$DamageScale[Scout,$ShardDamageType] = 1.0;                                    
$DamageScale[Scout,$GlockDamageType] = 1.0;                                      
$DamageScale[Scout,$EWebDamageType] = 1.0;   	                             
$DamageScale[Scout,$ARPGDamageType] = 1.0;                                    
$DamageScale[Scout,$StealthDamageType] = 1.0;                                   
$DamageScale[Scout,$MultiDamageType] = 1.0;                                      
$DamageScale[Scout,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[Scout,$HellStormDamageType] = 1.0;       			       
$DamageScale[Scout,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[Scout,$PlasGatDamageType] = 1.0;       			      
$DamageScale[Scout,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[Scout,$EMPDamageType] = 1.0;                                        
$DamageScale[Scout,$SalvoDamageType] = 1.0;                                      
$DamageScale[Scout,$AtomicDamageType] = 1.0;                                     
$DamageScale[Scout,$RadiationDamageType] = 1.0;                                   
$DamageScale[Scout,$DiscoDamageType] = 1.0;                                       
$DamageScale[Scout,$LazerGatDamageType] = 1.0;                                   
$DamageScale[Scout,$GrazerDamageType] = 1.0;                                     
$DamageScale[Scout,$HybridLaserDamageType] = 1.0;                                
$DamageScale[Scout,$QuakeDamageType] = 1.0;                                      
$DamageScale[Scout,$SXHDamageType] = 1.0;                                        
$DamageScale[Scout,$HybridRailDamageType] = 1.0;                                 
$DamageScale[Scout,$MiniGunDamageType] = 1.0;                                    
$DamageScale[Scout,$DFMIYADamageType] = 1.0;                                     
$DamageScale[Scout,$DestroyerDamageType] = 1.0;                                 
$DamageScale[Scout,$HybridChainDamageType] = 1.0;                                
$DamageScale[Scout,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[Scout,$BlazeDamageType] = 1.0;                                      
$DamageScale[Scout,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[Scout,$NapalmLDamageType] = 1.0;                                    
$DamageScale[Scout,$NapalmRDamageType] = 1.0;                                    
$DamageScale[Scout,$MagmaDamageType] = 1.0;                                      
$DamageScale[Scout,$NitroDamageType] = 1.0;                                      
$DamageScale[Scout,$FireMDamageType] = 1.0;                                      
$DamageScale[Scout,$ContactMDamageType] = 1.0;                                   
$DamageScale[Scout,$RaidDamageType] = 1.0;                                       
$DamageScale[Scout,$ClashDamageType] = 1.0;                                      
$DamageScale[Scout,$SludgeDamageType] = 1.0;                                     
$DamageScale[Scout,$HybridMortarDamageType] = 1.0;                               
$DamageScale[Scout,$HybridCannonDamageType] = 1.0;                               
$DamageScale[Scout,$HybridMissileDamageType] = 1.0;                              
$DamageScale[Scout,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[Scout,$ETTRDamageType] = 1.0; 

$DamageScale[LAPC,$ImpactDamageType] = 1.0;
$DamageScale[LAPC,$LandingDamageType] = 1.0;           
$DamageScale[LAPC,$RipperBulletDamageType] = 1.0;                              
$DamageScale[LAPC,$EnergyDamageType] = 1.0;                                    
$DamageScale[LAPC,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[LAPC,$StormHammerDamageType] = 1.0;                              
$DamageScale[LAPC,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[LAPC,$LazereXDamageType] = 1.0;                                    
$DamageScale[LAPC,$SplitMortarDamageType] = 1.0;                                
$DamageScale[LAPC,$BlazterDamageType] = 1.0;                                    
$DamageScale[LAPC,$ElectricityDamageType] = 1.0;                                
$DamageScale[LAPC,$CrushDamageType] = 1.0;                                      
$DamageScale[LAPC,$DebrisDamageType] = 1.0;                                     
$DamageScale[LAPC,$MissileDamageType] = 1.0;                                    
$DamageScale[LAPC,$MineDamageType] = 1.0;                                       
$DamageScale[LAPC,$FusionDamageType] = 1.0;                                     
$DamageScale[LAPC,$TimeBombDamageType] = 1.0;                                 
$DamageScale[LAPC,$FuzionDamageType] = 1.0;                                    
$DamageScale[LAPC,$HavocDamageType] = 1.0;                                    
$DamageScale[LAPC,$ShardDamageType] = 1.0;                                    
$DamageScale[LAPC,$GlockDamageType] = 1.0;                                      
$DamageScale[LAPC,$EWebDamageType] = 1.0;   	                             
$DamageScale[LAPC,$ARPGDamageType] = 1.0;                                    
$DamageScale[LAPC,$StealthDamageType] = 1.0;                                   
$DamageScale[LAPC,$MultiDamageType] = 1.0;                                      
$DamageScale[LAPC,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[LAPC,$HellStormDamageType] = 1.0;       			       
$DamageScale[LAPC,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[LAPC,$PlasGatDamageType] = 1.0;       			      
$DamageScale[LAPC,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[LAPC,$EMPDamageType] = 1.0;                                        
$DamageScale[LAPC,$SalvoDamageType] = 1.0;                                      
$DamageScale[LAPC,$AtomicDamageType] = 1.0;                                     
$DamageScale[LAPC,$RadiationDamageType] = 1.0;                                   
$DamageScale[LAPC,$DiscoDamageType] = 1.0;                                       
$DamageScale[LAPC,$LazerGatDamageType] = 1.0;                                   
$DamageScale[LAPC,$GrazerDamageType] = 1.0;                                     
$DamageScale[LAPC,$HybridLaserDamageType] = 1.0;                                
$DamageScale[LAPC,$QuakeDamageType] = 1.0;                                      
$DamageScale[LAPC,$SXHDamageType] = 1.0;                                        
$DamageScale[LAPC,$HybridRailDamageType] = 1.0;                                 
$DamageScale[LAPC,$MiniGunDamageType] = 1.0;                                    
$DamageScale[LAPC,$DFMIYADamageType] = 1.0;                                     
$DamageScale[LAPC,$DestroyerDamageType] = 1.0;                                 
$DamageScale[LAPC,$HybridChainDamageType] = 1.0;                                
$DamageScale[LAPC,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[LAPC,$BlazeDamageType] = 1.0;                                      
$DamageScale[LAPC,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[LAPC,$NapalmLDamageType] = 1.0;                                    
$DamageScale[LAPC,$NapalmRDamageType] = 1.0;                                    
$DamageScale[LAPC,$MagmaDamageType] = 1.0;                                      
$DamageScale[LAPC,$NitroDamageType] = 1.0;                                      
$DamageScale[LAPC,$FireMDamageType] = 1.0;                                      
$DamageScale[LAPC,$ContactMDamageType] = 1.0;                                   
$DamageScale[LAPC,$RaidDamageType] = 1.0;                                       
$DamageScale[LAPC,$ClashDamageType] = 1.0;                                      
$DamageScale[LAPC,$SludgeDamageType] = 1.0;                                     
$DamageScale[LAPC,$HybridMortarDamageType] = 1.0;                               
$DamageScale[LAPC,$HybridCannonDamageType] = 1.0;                               
$DamageScale[LAPC,$HybridMissileDamageType] = 1.0;                              
$DamageScale[LAPC,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[LAPC,$ETTRDamageType] = 1.0; 

$DamageScale[HAPC,$ImpactDamageType] = 1.0;
$DamageScale[HAPC,$LandingDamageType] = 1.0;           
$DamageScale[HAPC,$RipperBulletDamageType] = 1.0;                              
$DamageScale[HAPC,$EnergyDamageType] = 1.0;                                    
$DamageScale[HAPC,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[HAPC,$StormHammerDamageType] = 1.0;                              
$DamageScale[HAPC,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[HAPC,$LazereXDamageType] = 1.0;                                    
$DamageScale[HAPC,$SplitMortarDamageType] = 1.0;                                
$DamageScale[HAPC,$BlazterDamageType] = 1.0;                                    
$DamageScale[HAPC,$ElectricityDamageType] = 1.0;                                
$DamageScale[HAPC,$CrushDamageType] = 1.0;                                      
$DamageScale[HAPC,$DebrisDamageType] = 1.0;                                     
$DamageScale[HAPC,$MissileDamageType] = 1.0;                                    
$DamageScale[HAPC,$MineDamageType] = 1.0;                                       
$DamageScale[HAPC,$FusionDamageType] = 1.0;                                     
$DamageScale[HAPC,$TimeBombDamageType] = 1.0;                                 
$DamageScale[HAPC,$FuzionDamageType] = 1.0;                                    
$DamageScale[HAPC,$HavocDamageType] = 1.0;                                    
$DamageScale[HAPC,$ShardDamageType] = 1.0;                                    
$DamageScale[HAPC,$GlockDamageType] = 1.0;                                      
$DamageScale[HAPC,$EWebDamageType] = 1.0;   	                             
$DamageScale[HAPC,$ARPGDamageType] = 1.0;                                    
$DamageScale[HAPC,$StealthDamageType] = 1.0;                                   
$DamageScale[HAPC,$MultiDamageType] = 1.0;                                      
$DamageScale[HAPC,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[HAPC,$HellStormDamageType] = 1.0;       			       
$DamageScale[HAPC,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[HAPC,$PlasGatDamageType] = 1.0;       			      
$DamageScale[HAPC,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[HAPC,$EMPDamageType] = 1.0;                                        
$DamageScale[HAPC,$SalvoDamageType] = 1.0;                                      
$DamageScale[HAPC,$AtomicDamageType] = 1.0;                                     
$DamageScale[HAPC,$RadiationDamageType] = 1.0;                                   
$DamageScale[HAPC,$DiscoDamageType] = 1.0;                                       
$DamageScale[HAPC,$LazerGatDamageType] = 1.0;                                   
$DamageScale[HAPC,$GrazerDamageType] = 1.0;                                     
$DamageScale[HAPC,$HybridLaserDamageType] = 1.0;                                
$DamageScale[HAPC,$QuakeDamageType] = 1.0;                                      
$DamageScale[HAPC,$SXHDamageType] = 1.0;                                        
$DamageScale[HAPC,$HybridRailDamageType] = 1.0;                                 
$DamageScale[HAPC,$MiniGunDamageType] = 1.0;                                    
$DamageScale[HAPC,$DFMIYADamageType] = 1.0;                                     
$DamageScale[HAPC,$DestroyerDamageType] = 1.0;                                 
$DamageScale[HAPC,$HybridChainDamageType] = 1.0;                                
$DamageScale[HAPC,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[HAPC,$BlazeDamageType] = 1.0;                                      
$DamageScale[HAPC,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[HAPC,$NapalmLDamageType] = 1.0;                                    
$DamageScale[HAPC,$NapalmRDamageType] = 1.0;                                    
$DamageScale[HAPC,$MagmaDamageType] = 1.0;                                      
$DamageScale[HAPC,$NitroDamageType] = 1.0;                                      
$DamageScale[HAPC,$FireMDamageType] = 1.0;                                      
$DamageScale[HAPC,$ContactMDamageType] = 1.0;                                   
$DamageScale[HAPC,$RaidDamageType] = 1.0;                                       
$DamageScale[HAPC,$ClashDamageType] = 1.0;                                      
$DamageScale[HAPC,$SludgeDamageType] = 1.0;                                     
$DamageScale[HAPC,$HybridMortarDamageType] = 1.0;                               
$DamageScale[HAPC,$HybridCannonDamageType] = 1.0;                               
$DamageScale[HAPC,$HybridMissileDamageType] = 1.0;                              
$DamageScale[HAPC,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[HAPC,$ETTRDamageType] = 1.0; 

$DamageScale[Warthog,$ImpactDamageType] = 1.0;
$DamageScale[Warthog,$LandingDamageType] = 1.0;           
$DamageScale[Warthog,$RipperBulletDamageType] = 1.0;                              
$DamageScale[Warthog,$EnergyDamageType] = 1.0;                                    
$DamageScale[Warthog,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[Warthog,$StormHammerDamageType] = 1.0;                              
$DamageScale[Warthog,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[Warthog,$LazereXDamageType] = 1.0;                                    
$DamageScale[Warthog,$SplitMortarDamageType] = 1.0;                                
$DamageScale[Warthog,$BlazterDamageType] = 1.0;                                    
$DamageScale[Warthog,$ElectricityDamageType] = 1.0;                                
$DamageScale[Warthog,$CrushDamageType] = 1.0;                                      
$DamageScale[Warthog,$DebrisDamageType] = 1.0;                                     
$DamageScale[Warthog,$MissileDamageType] = 1.0;                                    
$DamageScale[Warthog,$MineDamageType] = 1.0;                                       
$DamageScale[Warthog,$FusionDamageType] = 1.0;                                     
$DamageScale[Warthog,$TimeBombDamageType] = 1.0;                                 
$DamageScale[Warthog,$FuzionDamageType] = 1.0;                                    
$DamageScale[Warthog,$HavocDamageType] = 1.0;                                    
$DamageScale[Warthog,$ShardDamageType] = 1.0;                                    
$DamageScale[Warthog,$GlockDamageType] = 1.0;                                      
$DamageScale[Warthog,$EWebDamageType] = 1.0;   	                             
$DamageScale[Warthog,$ARPGDamageType] = 1.0;                                    
$DamageScale[Warthog,$StealthDamageType] = 1.0;                                   
$DamageScale[Warthog,$MultiDamageType] = 1.0;                                      
$DamageScale[Warthog,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[Warthog,$HellStormDamageType] = 1.0;       			       
$DamageScale[Warthog,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[Warthog,$PlasGatDamageType] = 1.0;       			      
$DamageScale[Warthog,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[Warthog,$EMPDamageType] = 1.0;                                        
$DamageScale[Warthog,$SalvoDamageType] = 1.0;                                      
$DamageScale[Warthog,$AtomicDamageType] = 1.0;                                     
$DamageScale[Warthog,$RadiationDamageType] = 1.0;                                   
$DamageScale[Warthog,$DiscoDamageType] = 1.0;                                       
$DamageScale[Warthog,$LazerGatDamageType] = 1.0;                                   
$DamageScale[Warthog,$GrazerDamageType] = 1.0;                                     
$DamageScale[Warthog,$HybridLaserDamageType] = 1.0;                                
$DamageScale[Warthog,$QuakeDamageType] = 1.0;                                      
$DamageScale[Warthog,$SXHDamageType] = 1.0;                                        
$DamageScale[Warthog,$HybridRailDamageType] = 1.0;                                 
$DamageScale[Warthog,$MiniGunDamageType] = 1.0;                                    
$DamageScale[Warthog,$DFMIYADamageType] = 1.0;                                     
$DamageScale[Warthog,$DestroyerDamageType] = 1.0;                                 
$DamageScale[Warthog,$HybridChainDamageType] = 1.0;                                
$DamageScale[Warthog,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[Warthog,$BlazeDamageType] = 1.0;                                      
$DamageScale[Warthog,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[Warthog,$NapalmLDamageType] = 1.0;                                    
$DamageScale[Warthog,$NapalmRDamageType] = 1.0;                                    
$DamageScale[Warthog,$MagmaDamageType] = 1.0;                                      
$DamageScale[Warthog,$NitroDamageType] = 1.0;                                      
$DamageScale[Warthog,$FireMDamageType] = 1.0;                                      
$DamageScale[Warthog,$ContactMDamageType] = 1.0;                                   
$DamageScale[Warthog,$RaidDamageType] = 1.0;                                       
$DamageScale[Warthog,$ClashDamageType] = 1.0;                                      
$DamageScale[Warthog,$SludgeDamageType] = 1.0;                                     
$DamageScale[Warthog,$HybridMortarDamageType] = 1.0;                               
$DamageScale[Warthog,$HybridCannonDamageType] = 1.0;                               
$DamageScale[Warthog,$HybridMissileDamageType] = 1.0;                              
$DamageScale[Warthog,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[Warthog,$ETTRDamageType] = 1.0; 

$DamageScale[SR71,$ImpactDamageType] = 1.0;
$DamageScale[SR71,$LandingDamageType] = 1.0;           
$DamageScale[SR71,$RipperBulletDamageType] = 1.0;                              
$DamageScale[SR71,$EnergyDamageType] = 1.0;                                    
$DamageScale[SR71,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[SR71,$StormHammerDamageType] = 1.0;                              
$DamageScale[SR71,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[SR71,$LazereXDamageType] = 1.0;                                    
$DamageScale[SR71,$SplitMortarDamageType] = 1.0;                                
$DamageScale[SR71,$BlazterDamageType] = 1.0;                                    
$DamageScale[SR71,$ElectricityDamageType] = 1.0;                                
$DamageScale[SR71,$CrushDamageType] = 1.0;                                      
$DamageScale[SR71,$DebrisDamageType] = 1.0;                                     
$DamageScale[SR71,$MissileDamageType] = 1.0;                                    
$DamageScale[SR71,$MineDamageType] = 1.0;                                       
$DamageScale[SR71,$FusionDamageType] = 1.0;                                     
$DamageScale[SR71,$TimeBombDamageType] = 1.0;                                 
$DamageScale[SR71,$FuzionDamageType] = 1.0;                                    
$DamageScale[SR71,$HavocDamageType] = 1.0;                                    
$DamageScale[SR71,$ShardDamageType] = 1.0;                                    
$DamageScale[SR71,$GlockDamageType] = 1.0;                                      
$DamageScale[SR71,$EWebDamageType] = 1.0;   	                             
$DamageScale[SR71,$ARPGDamageType] = 1.0;                                    
$DamageScale[SR71,$StealthDamageType] = 1.0;                                   
$DamageScale[SR71,$MultiDamageType] = 1.0;                                      
$DamageScale[SR71,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[SR71,$HellStormDamageType] = 1.0;       			       
$DamageScale[SR71,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[SR71,$PlasGatDamageType] = 1.0;       			      
$DamageScale[SR71,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[SR71,$EMPDamageType] = 1.0;                                        
$DamageScale[SR71,$SalvoDamageType] = 1.0;                                      
$DamageScale[SR71,$AtomicDamageType] = 1.0;                                     
$DamageScale[SR71,$RadiationDamageType] = 1.0;                                   
$DamageScale[SR71,$DiscoDamageType] = 1.0;                                       
$DamageScale[SR71,$LazerGatDamageType] = 1.0;                                   
$DamageScale[SR71,$GrazerDamageType] = 1.0;                                     
$DamageScale[SR71,$HybridLaserDamageType] = 1.0;                                
$DamageScale[SR71,$QuakeDamageType] = 1.0;                                      
$DamageScale[SR71,$SXHDamageType] = 1.0;                                        
$DamageScale[SR71,$HybridRailDamageType] = 1.0;                                 
$DamageScale[SR71,$MiniGunDamageType] = 1.0;                                    
$DamageScale[SR71,$DFMIYADamageType] = 1.0;                                     
$DamageScale[SR71,$DestroyerDamageType] = 1.0;                                 
$DamageScale[SR71,$HybridChainDamageType] = 1.0;                                
$DamageScale[SR71,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[SR71,$BlazeDamageType] = 1.0;                                      
$DamageScale[SR71,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[SR71,$NapalmLDamageType] = 1.0;                                    
$DamageScale[SR71,$NapalmRDamageType] = 1.0;                                    
$DamageScale[SR71,$MagmaDamageType] = 1.0;                                      
$DamageScale[SR71,$NitroDamageType] = 1.0;                                      
$DamageScale[SR71,$FireMDamageType] = 1.0;                                      
$DamageScale[SR71,$ContactMDamageType] = 1.0;                                   
$DamageScale[SR71,$RaidDamageType] = 1.0;                                       
$DamageScale[SR71,$ClashDamageType] = 1.0;                                      
$DamageScale[SR71,$SludgeDamageType] = 1.0;                                     
$DamageScale[SR71,$HybridMortarDamageType] = 1.0;                               
$DamageScale[SR71,$HybridCannonDamageType] = 1.0;                               
$DamageScale[SR71,$HybridMissileDamageType] = 1.0;                              
$DamageScale[SR71,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[SR71,$ETTRDamageType] = 1.0; 

$DamageScale[Enterprise,$ImpactDamageType] = 1.0;
$DamageScale[Enterprise,$LandingDamageType] = 1.0;           
$DamageScale[Enterprise,$RipperBulletDamageType] = 1.0;                              
$DamageScale[Enterprise,$EnergyDamageType] = 1.0;                                    
$DamageScale[Enterprise,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[Enterprise,$StormHammerDamageType] = 1.0;                              
$DamageScale[Enterprise,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[Enterprise,$LazereXDamageType] = 1.0;                                    
$DamageScale[Enterprise,$SplitMortarDamageType] = 1.0;                                
$DamageScale[Enterprise,$BlazterDamageType] = 1.0;                                    
$DamageScale[Enterprise,$ElectricityDamageType] = 1.0;                                
$DamageScale[Enterprise,$CrushDamageType] = 1.0;                                      
$DamageScale[Enterprise,$DebrisDamageType] = 1.0;                                     
$DamageScale[Enterprise,$MissileDamageType] = 1.0;                                    
$DamageScale[Enterprise,$MineDamageType] = 1.0;                                       
$DamageScale[Enterprise,$FusionDamageType] = 1.0;                                     
$DamageScale[Enterprise,$TimeBombDamageType] = 1.0;                                 
$DamageScale[Enterprise,$FuzionDamageType] = 1.0;                                    
$DamageScale[Enterprise,$HavocDamageType] = 1.0;                                    
$DamageScale[Enterprise,$ShardDamageType] = 1.0;                                    
$DamageScale[Enterprise,$GlockDamageType] = 1.0;                                      
$DamageScale[Enterprise,$EWebDamageType] = 1.0;   	                             
$DamageScale[Enterprise,$ARPGDamageType] = 1.0;                                    
$DamageScale[Enterprise,$StealthDamageType] = 1.0;                                   
$DamageScale[Enterprise,$MultiDamageType] = 1.0;                                      
$DamageScale[Enterprise,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[Enterprise,$HellStormDamageType] = 1.0;       			       
$DamageScale[Enterprise,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[Enterprise,$PlasGatDamageType] = 1.0;       			      
$DamageScale[Enterprise,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[Enterprise,$EMPDamageType] = 1.0;                                        
$DamageScale[Enterprise,$SalvoDamageType] = 1.0;                                      
$DamageScale[Enterprise,$AtomicDamageType] = 1.0;                                     
$DamageScale[Enterprise,$RadiationDamageType] = 1.0;                                   
$DamageScale[Enterprise,$DiscoDamageType] = 1.0;                                       
$DamageScale[Enterprise,$LazerGatDamageType] = 1.0;                                   
$DamageScale[Enterprise,$GrazerDamageType] = 1.0;                                     
$DamageScale[Enterprise,$HybridLaserDamageType] = 1.0;                                
$DamageScale[Enterprise,$QuakeDamageType] = 1.0;                                      
$DamageScale[Enterprise,$SXHDamageType] = 1.0;                                        
$DamageScale[Enterprise,$HybridRailDamageType] = 1.0;                                 
$DamageScale[Enterprise,$MiniGunDamageType] = 1.0;                                    
$DamageScale[Enterprise,$DFMIYADamageType] = 1.0;                                     
$DamageScale[Enterprise,$DestroyerDamageType] = 1.0;                                 
$DamageScale[Enterprise,$HybridChainDamageType] = 1.0;                                
$DamageScale[Enterprise,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[Enterprise,$BlazeDamageType] = 1.0;                                      
$DamageScale[Enterprise,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[Enterprise,$NapalmLDamageType] = 1.0;                                    
$DamageScale[Enterprise,$NapalmRDamageType] = 1.0;                                    
$DamageScale[Enterprise,$MagmaDamageType] = 1.0;                                      
$DamageScale[Enterprise,$NitroDamageType] = 1.0;                                      
$DamageScale[Enterprise,$FireMDamageType] = 1.0;                                      
$DamageScale[Enterprise,$ContactMDamageType] = 1.0;                                   
$DamageScale[Enterprise,$RaidDamageType] = 1.0;                                       
$DamageScale[Enterprise,$ClashDamageType] = 1.0;                                      
$DamageScale[Enterprise,$SludgeDamageType] = 1.0;                                     
$DamageScale[Enterprise,$HybridMortarDamageType] = 1.0;                               
$DamageScale[Enterprise,$HybridCannonDamageType] = 1.0;                               
$DamageScale[Enterprise,$HybridMissileDamageType] = 1.0;                              
$DamageScale[Enterprise,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[Enterprise,$ETTRDamageType] = 1.0; 

$DamageScale[Bomber,$ImpactDamageType] = 1.0;
$DamageScale[Bomber,$LandingDamageType] = 1.0;           
$DamageScale[Bomber,$RipperBulletDamageType] = 1.0;                              
$DamageScale[Bomber,$EnergyDamageType] = 1.0;                                    
$DamageScale[Bomber,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[Bomber,$StormHammerDamageType] = 1.0;                              
$DamageScale[Bomber,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[Bomber,$LazereXDamageType] = 1.0;                                    
$DamageScale[Bomber,$SplitMortarDamageType] = 1.0;                                
$DamageScale[Bomber,$BlazterDamageType] = 1.0;                                    
$DamageScale[Bomber,$ElectricityDamageType] = 1.0;                                
$DamageScale[Bomber,$CrushDamageType] = 1.0;                                      
$DamageScale[Bomber,$DebrisDamageType] = 1.0;                                     
$DamageScale[Bomber,$MissileDamageType] = 1.0;                                    
$DamageScale[Bomber,$MineDamageType] = 1.0;                                       
$DamageScale[Bomber,$FusionDamageType] = 1.0;                                     
$DamageScale[Bomber,$TimeBombDamageType] = 1.0;                                 
$DamageScale[Bomber,$FuzionDamageType] = 1.0;                                    
$DamageScale[Bomber,$HavocDamageType] = 1.0;                                    
$DamageScale[Bomber,$ShardDamageType] = 1.0;                                    
$DamageScale[Bomber,$GlockDamageType] = 1.0;                                      
$DamageScale[Bomber,$EWebDamageType] = 1.0;   	                             
$DamageScale[Bomber,$ARPGDamageType] = 1.0;                                    
$DamageScale[Bomber,$StealthDamageType] = 1.0;                                   
$DamageScale[Bomber,$MultiDamageType] = 1.0;                                      
$DamageScale[Bomber,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[Bomber,$HellStormDamageType] = 1.0;       			       
$DamageScale[Bomber,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[Bomber,$PlasGatDamageType] = 1.0;       			      
$DamageScale[Bomber,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[Bomber,$EMPDamageType] = 1.0;                                        
$DamageScale[Bomber,$SalvoDamageType] = 1.0;                                      
$DamageScale[Bomber,$AtomicDamageType] = 1.0;                                     
$DamageScale[Bomber,$RadiationDamageType] = 1.0;                                   
$DamageScale[Bomber,$DiscoDamageType] = 1.0;                                       
$DamageScale[Bomber,$LazerGatDamageType] = 1.0;                                   
$DamageScale[Bomber,$GrazerDamageType] = 1.0;                                     
$DamageScale[Bomber,$HybridLaserDamageType] = 1.0;                                
$DamageScale[Bomber,$QuakeDamageType] = 1.0;                                      
$DamageScale[Bomber,$SXHDamageType] = 1.0;                                        
$DamageScale[Bomber,$HybridRailDamageType] = 1.0;                                 
$DamageScale[Bomber,$MiniGunDamageType] = 1.0;                                    
$DamageScale[Bomber,$DFMIYADamageType] = 1.0;                                     
$DamageScale[Bomber,$DestroyerDamageType] = 1.0;                                 
$DamageScale[Bomber,$HybridChainDamageType] = 1.0;                                
$DamageScale[Bomber,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[Bomber,$BlazeDamageType] = 1.0;                                      
$DamageScale[Bomber,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[Bomber,$NapalmLDamageType] = 1.0;                                    
$DamageScale[Bomber,$NapalmRDamageType] = 1.0;                                    
$DamageScale[Bomber,$MagmaDamageType] = 1.0;                                      
$DamageScale[Bomber,$NitroDamageType] = 1.0;                                      
$DamageScale[Bomber,$FireMDamageType] = 1.0;                                      
$DamageScale[Bomber,$ContactMDamageType] = 1.0;                                   
$DamageScale[Bomber,$RaidDamageType] = 1.0;                                       
$DamageScale[Bomber,$ClashDamageType] = 1.0;                                      
$DamageScale[Bomber,$SludgeDamageType] = 1.0;                                     
$DamageScale[Bomber,$HybridMortarDamageType] = 1.0;                               
$DamageScale[Bomber,$HybridCannonDamageType] = 1.0;                               
$DamageScale[Bomber,$HybridMissileDamageType] = 1.0;                              
$DamageScale[Bomber,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[Bomber,$ETTRDamageType] = 1.0; 

$DamageScale[SpeedBike,$ImpactDamageType] = 1.0;
$DamageScale[SpeedBike,$LandingDamageType] = 1.0;           
$DamageScale[SpeedBike,$RipperBulletDamageType] = 1.0;                              
$DamageScale[SpeedBike,$EnergyDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[SpeedBike,$StormHammerDamageType] = 1.0;                              
$DamageScale[SpeedBike,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[SpeedBike,$LazereXDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$SplitMortarDamageType] = 1.0;                                
$DamageScale[SpeedBike,$BlazterDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$ElectricityDamageType] = 1.0;                                
$DamageScale[SpeedBike,$CrushDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$DebrisDamageType] = 1.0;                                     
$DamageScale[SpeedBike,$MissileDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$MineDamageType] = 1.0;                                       
$DamageScale[SpeedBike,$FusionDamageType] = 1.0;                                     
$DamageScale[SpeedBike,$TimeBombDamageType] = 1.0;                                 
$DamageScale[SpeedBike,$FuzionDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$HavocDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$ShardDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$GlockDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$EWebDamageType] = 1.0;   	                             
$DamageScale[SpeedBike,$ARPGDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$StealthDamageType] = 1.0;                                   
$DamageScale[SpeedBike,$MultiDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[SpeedBike,$HellStormDamageType] = 1.0;       			       
$DamageScale[SpeedBike,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[SpeedBike,$PlasGatDamageType] = 1.0;       			      
$DamageScale[SpeedBike,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[SpeedBike,$EMPDamageType] = 1.0;                                        
$DamageScale[SpeedBike,$SalvoDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$AtomicDamageType] = 1.0;                                     
$DamageScale[SpeedBike,$RadiationDamageType] = 1.0;                                   
$DamageScale[SpeedBike,$DiscoDamageType] = 1.0;                                       
$DamageScale[SpeedBike,$LazerGatDamageType] = 1.0;                                   
$DamageScale[SpeedBike,$GrazerDamageType] = 1.0;                                     
$DamageScale[SpeedBike,$HybridLaserDamageType] = 1.0;                                
$DamageScale[SpeedBike,$QuakeDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$SXHDamageType] = 1.0;                                        
$DamageScale[SpeedBike,$HybridRailDamageType] = 1.0;                                 
$DamageScale[SpeedBike,$MiniGunDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$DFMIYADamageType] = 1.0;                                     
$DamageScale[SpeedBike,$DestroyerDamageType] = 1.0;                                 
$DamageScale[SpeedBike,$HybridChainDamageType] = 1.0;                                
$DamageScale[SpeedBike,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[SpeedBike,$BlazeDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[SpeedBike,$NapalmLDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$NapalmRDamageType] = 1.0;                                    
$DamageScale[SpeedBike,$MagmaDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$NitroDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$FireMDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$ContactMDamageType] = 1.0;                                   
$DamageScale[SpeedBike,$RaidDamageType] = 1.0;                                       
$DamageScale[SpeedBike,$ClashDamageType] = 1.0;                                      
$DamageScale[SpeedBike,$SludgeDamageType] = 1.0;                                     
$DamageScale[SpeedBike,$HybridMortarDamageType] = 1.0;                               
$DamageScale[SpeedBike,$HybridCannonDamageType] = 1.0;                               
$DamageScale[SpeedBike,$HybridMissileDamageType] = 1.0;                              
$DamageScale[SpeedBike,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[SpeedBike,$ETTRDamageType] = 1.0; 

$DamageScale[Colossus,$ImpactDamageType] = 1.0;
$DamageScale[Colossus,$LandingDamageType] = 1.0;           
$DamageScale[Colossus,$RipperBulletDamageType] = 1.0;                              
$DamageScale[Colossus,$EnergyDamageType] = 1.0;                                    
$DamageScale[Colossus,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[Colossus,$StormHammerDamageType] = 1.0;                              
$DamageScale[Colossus,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[Colossus,$LazereXDamageType] = 1.0;                                    
$DamageScale[Colossus,$SplitMortarDamageType] = 1.0;                                
$DamageScale[Colossus,$BlazterDamageType] = 1.0;                                    
$DamageScale[Colossus,$ElectricityDamageType] = 1.0;                                
$DamageScale[Colossus,$CrushDamageType] = 1.0;                                      
$DamageScale[Colossus,$DebrisDamageType] = 1.0;                                     
$DamageScale[Colossus,$MissileDamageType] = 1.0;                                    
$DamageScale[Colossus,$MineDamageType] = 1.0;                                       
$DamageScale[Colossus,$FusionDamageType] = 1.0;                                     
$DamageScale[Colossus,$TimeBombDamageType] = 1.0;                                 
$DamageScale[Colossus,$FuzionDamageType] = 1.0;                                    
$DamageScale[Colossus,$HavocDamageType] = 1.0;                                    
$DamageScale[Colossus,$ShardDamageType] = 1.0;                                    
$DamageScale[Colossus,$GlockDamageType] = 1.0;                                      
$DamageScale[Colossus,$EWebDamageType] = 1.0;   	                             
$DamageScale[Colossus,$ARPGDamageType] = 1.0;                                    
$DamageScale[Colossus,$StealthDamageType] = 1.0;                                   
$DamageScale[Colossus,$MultiDamageType] = 1.0;                                      
$DamageScale[Colossus,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[Colossus,$HellStormDamageType] = 1.0;       			       
$DamageScale[Colossus,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[Colossus,$PlasGatDamageType] = 1.0;       			      
$DamageScale[Colossus,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[Colossus,$EMPDamageType] = 1.0;                                        
$DamageScale[Colossus,$SalvoDamageType] = 1.0;                                      
$DamageScale[Colossus,$AtomicDamageType] = 1.0;                                     
$DamageScale[Colossus,$RadiationDamageType] = 1.0;                                   
$DamageScale[Colossus,$DiscoDamageType] = 1.0;                                       
$DamageScale[Colossus,$LazerGatDamageType] = 1.0;                                   
$DamageScale[Colossus,$GrazerDamageType] = 1.0;                                     
$DamageScale[Colossus,$HybridLaserDamageType] = 1.0;                                
$DamageScale[Colossus,$QuakeDamageType] = 1.0;                                      
$DamageScale[Colossus,$SXHDamageType] = 1.0;                                        
$DamageScale[Colossus,$HybridRailDamageType] = 1.0;                                 
$DamageScale[Colossus,$MiniGunDamageType] = 1.0;                                    
$DamageScale[Colossus,$DFMIYADamageType] = 1.0;                                     
$DamageScale[Colossus,$DestroyerDamageType] = 1.0;                                 
$DamageScale[Colossus,$HybridChainDamageType] = 1.0;                                
$DamageScale[Colossus,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[Colossus,$BlazeDamageType] = 1.0;                                      
$DamageScale[Colossus,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[Colossus,$NapalmLDamageType] = 1.0;                                    
$DamageScale[Colossus,$NapalmRDamageType] = 1.0;                                    
$DamageScale[Colossus,$MagmaDamageType] = 1.0;                                      
$DamageScale[Colossus,$NitroDamageType] = 1.0;                                      
$DamageScale[Colossus,$FireMDamageType] = 1.0;                                      
$DamageScale[Colossus,$ContactMDamageType] = 1.0;                                   
$DamageScale[Colossus,$RaidDamageType] = 1.0;                                       
$DamageScale[Colossus,$ClashDamageType] = 1.0;                                      
$DamageScale[Colossus,$SludgeDamageType] = 1.0;                                     
$DamageScale[Colossus,$HybridMortarDamageType] = 1.0;                               
$DamageScale[Colossus,$HybridCannonDamageType] = 1.0;                               
$DamageScale[Colossus,$HybridMissileDamageType] = 1.0;                              
$DamageScale[Colossus,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[Colossus,$ETTRDamageType] = 1.0; 

$DamageScale[Arwing,$ImpactDamageType] = 1.0;
$DamageScale[Arwing,$LandingDamageType] = 1.0;           
$DamageScale[Arwing,$RipperBulletDamageType] = 1.0;                              
$DamageScale[Arwing,$EnergyDamageType] = 1.0;                                    
$DamageScale[Arwing,$PlasmaCannonDamageType] = 1.0;                             
$DamageScale[Arwing,$StormHammerDamageType] = 1.0;                              
$DamageScale[Arwing,$BioShrapnelDamageType] = 1.0;                                
$DamageScale[Arwing,$LazereXDamageType] = 1.0;                                    
$DamageScale[Arwing,$SplitMortarDamageType] = 1.0;                                
$DamageScale[Arwing,$BlazterDamageType] = 1.0;                                    
$DamageScale[Arwing,$ElectricityDamageType] = 1.0;                                
$DamageScale[Arwing,$CrushDamageType] = 1.0;                                      
$DamageScale[Arwing,$DebrisDamageType] = 1.0;                                     
$DamageScale[Arwing,$MissileDamageType] = 1.0;                                    
$DamageScale[Arwing,$MineDamageType] = 1.0;                                       
$DamageScale[Arwing,$FusionDamageType] = 1.0;                                     
$DamageScale[Arwing,$TimeBombDamageType] = 1.0;                                 
$DamageScale[Arwing,$FuzionDamageType] = 1.0;                                    
$DamageScale[Arwing,$HavocDamageType] = 1.0;                                    
$DamageScale[Arwing,$ShardDamageType] = 1.0;                                    
$DamageScale[Arwing,$GlockDamageType] = 1.0;                                      
$DamageScale[Arwing,$EWebDamageType] = 1.0;   	                             
$DamageScale[Arwing,$ARPGDamageType] = 1.0;                                    
$DamageScale[Arwing,$StealthDamageType] = 1.0;                                   
$DamageScale[Arwing,$MultiDamageType] = 1.0;                                      
$DamageScale[Arwing,$WTShotgunDamageType] = 1.0;                                  
$DamageScale[Arwing,$HellStormDamageType] = 1.0;       			       
$DamageScale[Arwing,$AnarchyCannonDamageType] = 1.0;          		      
$DamageScale[Arwing,$PlasGatDamageType] = 1.0;       			      
$DamageScale[Arwing,$ParticalShotgunDamageType] = 1.0;             		      
$DamageScale[Arwing,$EMPDamageType] = 1.0;                                        
$DamageScale[Arwing,$SalvoDamageType] = 1.0;                                      
$DamageScale[Arwing,$AtomicDamageType] = 1.0;                                     
$DamageScale[Arwing,$RadiationDamageType] = 1.0;                                   
$DamageScale[Arwing,$DiscoDamageType] = 1.0;                                       
$DamageScale[Arwing,$LazerGatDamageType] = 1.0;                                   
$DamageScale[Arwing,$GrazerDamageType] = 1.0;                                     
$DamageScale[Arwing,$HybridLaserDamageType] = 1.0;                                
$DamageScale[Arwing,$QuakeDamageType] = 1.0;                                      
$DamageScale[Arwing,$SXHDamageType] = 1.0;                                        
$DamageScale[Arwing,$HybridRailDamageType] = 1.0;                                 
$DamageScale[Arwing,$MiniGunDamageType] = 1.0;                                    
$DamageScale[Arwing,$DFMIYADamageType] = 1.0;                                     
$DamageScale[Arwing,$DestroyerDamageType] = 1.0;                                 
$DamageScale[Arwing,$HybridChainDamageType] = 1.0;                                
$DamageScale[Arwing,$PlasmaBlasterDamageType] = 1.0;                              
$DamageScale[Arwing,$BlazeDamageType] = 1.0;                                      
$DamageScale[Arwing,$MeltLaserDamageType] = 1.0;                                  
$DamageScale[Arwing,$NapalmLDamageType] = 1.0;                                    
$DamageScale[Arwing,$NapalmRDamageType] = 1.0;                                    
$DamageScale[Arwing,$MagmaDamageType] = 1.0;                                      
$DamageScale[Arwing,$NitroDamageType] = 1.0;                                      
$DamageScale[Arwing,$FireMDamageType] = 1.0;                                      
$DamageScale[Arwing,$ContactMDamageType] = 1.0;                                   
$DamageScale[Arwing,$RaidDamageType] = 1.0;                                       
$DamageScale[Arwing,$ClashDamageType] = 1.0;                                      
$DamageScale[Arwing,$SludgeDamageType] = 1.0;                                     
$DamageScale[Arwing,$HybridMortarDamageType] = 1.0;                               
$DamageScale[Arwing,$HybridCannonDamageType] = 1.0;                               
$DamageScale[Arwing,$HybridMissileDamageType] = 1.0;                              
$DamageScale[Arwing,$HybridRPGDamageType] = 1.0;                                  
$DamageScale[Arwing,$ETTRDamageType] = 1.0; 

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if ((%armor == "larmor" || %armor == "lfemale" || %armor == "sarmor" || %armor == "narmor") && Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      Client::setControlObject(%client, %this);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if(GameBase::getDataName(%this) != Scout
                              && GameBase::getDataName(%this) != SkateBoard
					&& GameBase::getDataName(%this) != Warthog
					&& GameBase::getDataName(%this) != SR71
					&& GameBase::getDataName(%this) != Enterprise
					&& GameBase::getDataName(%this) != Bomber
					&& GameBase::getDataName(%this) != SpeedBike
					&& GameBase::getDataName(%this) != Colossus
					&& GameBase::getDataName(%this) != Arwing) 
					{
					 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 
						if(%mountSlot) 
							{
								%object.vehicleSlot = %mountSlot;
								%object.vehicle = %this;
								Player::setMountObject(%object, %this, %mountSlot);
								playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
							}
					}
				else if (GameBase::getControlClient(%this) == -1)
					Client::sendMessage(Player::getClient(%object),0,"You must be in Battalion, Tactical Sniper or Hybrid Armor to pilot this vehicle.~wError_Message.wav");
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC)
		%numSlots = 4;
	else
		%numSlots = 2;
	%count=0;
	for(%i=0;%i<%numSlots;%i++)  
		if(%this.Seat[%i] == "") {
			%slotPos[%count] = Vehicle::getMountPoint(%this,%i+2);
			%slotVal[%count] = %i+2;
			%lastEmpty = %i+2;
			%count++;
		}
	if(%count == 1) {
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
		%this.Seat[%freeSlot-2] = %client;
		return %freeSlot;
	}
	else
		return "False";
}

function getClosestPosition(%num,%playerPos,%slotPos0,%slotPos1,%slotPos2,%slotPos3)
{
	%playerX = getWord(%playerPos,0);
	%playerY = getWord(%playerPos,1);
	for(%i = 0 ;%i<%num;%i++) {
		%x = (getWord(%slotPos[%i],0)) - %playerX;
		%y = (getWord(%slotPos[%i],1)) - %playerY;
		if(%x < 0)
			%x *= -1;
		if(%y < 0)
			%y *= -1;
		%newDistance = sqrt((%x*%x)+(%y*%y));
		if(%newDistance < %distance || %distance == "") {
	  		%distance = %newDistance;			
			%closePos = %i;	
		}
	}		
	return %closePos;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "lfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "sarmor")
	{
		%height = 2;
		%velocity = 90;
		%zVec = 90;
	}
	else if(%armor == "marmor" || %armor == "mfemale") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor") {
		%height = 2;
		%velocity = 140;
		%zVec = 110;
	}
	else if(%armor == "jarmor") {
		%height = 4;
		%velocity = 140;
		%zVec = 110;
	}

	%pos = GameBase::getPosition(%passenger);
	%posX = getWord(%pos,0);
	%posY	= getWord(%pos,1);
	%posZ	= getWord(%pos,2);

	if(GameBase::testPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height))) {	
		%client = Player::getClient(%passenger);
		%this.Seat[%passenger.vehicleSlot-2] = "";
		%passenger.vehicleSlot = "";
	   %passenger.vehicle= "";
		Player::setMountObject(%passenger, -1, 0);
		%rotZ = getWord(GameBase::getRotation(%passenger),2);
		GameBase::setRotation(%passenger, "0 0 " @ %rotZ);
		GameBase::setPosition(%passenger,%posX @ " " @ %posY @ " " @ (%posZ + %height));
		%jumpDir = Vector::getFromRot(GameBase::getRotation(%passenger),%velocity,%zVec);
		Player::applyImpulse(%passenger,%jumpDir);
	}
	else
		Client::sendMessage(Player::getClient(%passanger),0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
}

function Vehicle::jump(%this,%mom)
{
   Vehicle::dismount(%this,%mom);
}

function Vehicle::dismount(%this,%mom)
{
   %cl = GameBase::getControlClient(%this);
   if(%cl != -1)
   {
      %pl = Client::getOwnedObject(%cl);
      if(getObjectType(%pl) == "Player")
      {
		   // dismount the player	  
			if(GameBase::testPosition(%pl, Vehicle::getMountPoint(%this,0))) {
				%pl.lastMount = %this;
				%pl.newMountTime = getSimTime() + 3.0;
				Player::setMountObject(%pl, %this, 0);
        	 	Player::setMountObject(%pl, -1, 0);
				%rot = GameBase::getRotation(%this);
				%rotZ = getWord(%rot,2);
				GameBase::setRotation(%pl, "0 0 " @ %rotZ);
				Player::applyImpulse(%pl,%mom);
        	 	Client::setControlObject(%cl, %pl);
				playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
				if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
//	if($testcheats || $servercheats)
	$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
   %cl = GameBase::getControlClient(%this);
	%pl = Client::getOwnedObject(%cl);
	if(%pl != -1) {
	   Player::setMountObject(%pl, -1, 0);
   	Client::setControlObject(%cl, %pl);
		if(%pl.lastWeapon != "") {
			Player::useItem(%pl,%pl.lastWeapon);		 	
			%pl.lastWeapon = "";
		}
		%pl.driver = "";
	   %pl.vehicle= "";
	}
	for(%i = 0 ; %i < 4 ; %i++)
		if(%this.Seat[%i] != "") {
			%pl = Client::getOwnedObject(%this.Seat[%i]);
		   Player::setMountObject(%pl, -1, 0);
	  	 	Client::setControlObject(%this.Seat[%i], %pl);
			%pl.vehicleSlot = "";
		   %pl.vehicle= "";
		}
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
		0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}