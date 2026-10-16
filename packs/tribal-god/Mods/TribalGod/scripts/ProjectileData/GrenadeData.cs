//-------------------------------------------------| - Begin Grenade Data
GrenadeData SmScreen
{ 
	bulletShapeName     = "smoke.dts"; // shape of bullet
	explosionTag        = SmScreenExp; // explosion to use (see basexpdata.cs)
	collideWithOwner    = True;        // ?
	ownerGraceMS        = 250;         // ?
	collisionRadius     = 0;           // deasn't really apply for grenade datas 
	mass                = 9;           // ?
	elasticity          = 0.01;        // ?
	damageClass         = 1;           // 0 impact, 1 radius
	damageValue         = 0.2;         // how much damage this will apply to player or object
	damageType          = $SmokeDamageType;// what damagetype to use(basically changes the death messages)
	explosionRadius     = 5;           // There will be a 5 meter radius explosion 
	kickBackStrength    = 0;           // no kickback needed\wanted for these projectiles
	maxLevelFlightDist  = 250;         // maximum it can be in the air b4 it explodes?
	totalTime           = 1;           // time after collision that it will explode?
	liveTime            = 32;          // grenade time live after contact
	projSpecialTime     = 0.08;        // ?
	inheritedVelocityScale = 0.5;      // it will gain 0.5 in speed once shot?
	smokeName              = "smoke.dts";  // name of trail 
	soundId                = SoundJetHeavy;// sound of item after its been fired
};
//-------------------------------------------------|

GrenadeData ExSmScreen
{ 
	bulletShapeName     = "fusionex.dts";
	explosionTag        = ExSmScreenExp;
	collideWithOwner    = True;
	ownerGraceMS        = 250;
	collisionRadius     = 0;
	mass                = 9;
	elasticity          = 0.01;
	damageClass         = 1;
	damageValue         = 280;
	damageType          = $ShrapnelDamageType;
	explosionRadius     = 5;
	kickBackStrength    = 0;
	maxLevelFlightDist  = 250;
	totalTime           = 10;
	liveTime            = 6;
	projSpecialTime     = 0.01;
	inheritedVelocityScale = 0.5;
	smokeName              = "plasmatrail.dts";
	soundId                = SoundELFFire;
};
//-------------------------------------------------|

GrenadeData GrenadeShell
{
	bulletShapeName    = "grenade.dts";
	explosionTag       = grenadeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.2;
	mass               = 1.0;
	elasticity         = 0.45;
	damageClass        = 1;       
	damageValue        = 0.5;
	damageType         = $ShrapnelDamageType;
	explosionRadius    = 15;
	kickBackStrength   = 150.0;
	maxLevelFlightDist = 150;
	totalTime          = 9.0; 
	liveTime           = 1.0;
	projSpecialTime    = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName              = "smoke.dts";
};
//-------------------------------------------------|

GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;     
   damageValue        = 10.0;
   damageType         = $MortarDamageType;
   explosionRadius    = 15.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 6;
   liveTime           = 2;
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};
//-------------------------------------------------|

GrenadeData LiLFFBShell { 
	bulletShapeName = "plasammo.DTS";
	explosionTag = LiLFFBExp;
	collideWithOwner = True;
	ownerGraceMS = 250;
	collisionRadius = 0.2;
	mass = 9;
	elasticity = 0.1;
	damageClass = 1;
	damageValue = 150;
	damageType = $ShrapnelDamageType;
	explosionRadius = 15;
	kickBackStrength = 300;
	maxLevelFlightDist = 250;
	totalTime = 5;
	liveTime = 1;
	projSpecialTime = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName = "smoke.dts";
	soundId = SoundELFFire;
};
//-------------------------------------------------|

GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       
   damageValue        = 1.32;
   damageType         = $MortarDamageType;
   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 9.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};
//-------------------------------------------------|

GrenadeData EMPgrenshl
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = ShockwaveThree;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;
   damageClass        = 1;       
   damageValue        = 0.4;
   damageType         = $FlashDamageType;
   explosionRadius    = 20;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 130;
   totalTime          = 30.0;    
   liveTime           = 2.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "enex.dts";
};
//-------------------------------------------------|

GrenadeData Tranqgren
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;
   damageClass        = 1;       
   damageValue        = 50.9;
   damageType         = $MortarDamageType;
   explosionRadius    = 20;
   kickBackStrength   = 0;
   maxLevelFlightDist = 130;
   totalTime          = 30.0;   
   liveTime           = 1.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};
//-------------------------------------------------|

GrenadeData MortarShell420
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;
   damageClass        = 1;      
   damageValue        = 50.9;
   damageType         = $MortarDamageType;
   explosionRadius    = 20;
   kickBackStrength   = 0;
   maxLevelFlightDist = 130;
   totalTime          = 30.0;    
   liveTime           = 2.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
//-------------------------------------------------|

GrenadeData MortarFlameShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.15;
   damageClass        = 1;       
   damageValue        = 50.9;
   damageType         = $MortarDamageType;
   explosionRadius    = 20;
   kickBackStrength   = 0;
   maxLevelFlightDist = 130;
   totalTime          = 30.0;    
   liveTime           = 0.0;   
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};
//-------------------------------------------------|

GrenadeData MortarShellNuke
{
   bulletShapeName     = "mortar.dts";
   explosionTag        = ShockwaveThree;
   collideWithOwner    = True;
   ownerGraceMS        = 250;
   collisionRadius     = 0.2;
   mass                = 1.0;
   elasticity          = 0.15;
   damageClass         = 1;       
   damageValue         = 0.5;
   damageType          = $NukerDamageType;
   explosionRadius     = 500;
   kickBackStrength    = 0;
   maxLevelFlightDist  = 130;
   totalTime           = 30.0;   
   liveTime            = 5.0;
   projSpecialTime     = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};
//-------------------------------------------------|

GrenadeData MinerShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;
   elasticity         = 0.2;
   damageClass        = 1;       
   damageValue        = 0.0;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 200;
   totalTime          = 20.0;
   liveTime           = 20.0; 
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
//-------------------------------------------------|

GrenadeData PrettySplit
{
   bulletShapeName    = "Mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;
   damageClass        = 1;      
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;
   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01; 
   liveTime           = 0.01;
   projSpecialTime    = 0.05;
   soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};
//-------------------------------------------------|

GrenadeData MineFloaters
{// ripped from annihilation mod, modified to fit the needs of the Tribal_God Mod
   bulletShapeName    = "mine.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	
   elasticity         = 0.45;	
   damageClass        = 1;      
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType; 
   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; 
   projSpecialTime    = 0.1;
   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};
//-------------------------------------------------|

GrenadeData MineShell 
{	bulletShapeName    = "mortar.dts";
	explosionTag       = debrisExpSmall;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.2;
	mass               = 0.5;
	elasticity         = 0.45;
	damageClass        = 1; 
	damageValue        = 0.0;
	damageType         = $MineDamageType;
	explosionRadius    = 10;
	kickBackStrength   = 0.0;
	maxLevelFlightDist = 150;
	totalTime          = 20.0; 
	liveTime           = 3.0;	
	projSpecialTime    = 0.05;
	inheritedVelocityScale = 0.5;
	smokeName              = "smoke.dts";
};

//-------------------------------------------------|

GrenadeData ArmChangeFX 
{ 
	bulletShapeName = "plasmatrail.dts"; 
	explosionTag = armChanExp; 
	collideWithOwner = false; 
	ownerGraceMS = 500; 
	collisionRadius = 0.0; 
	mass = 0.0; 
	elasticity = 0.1; 
	damageClass = 0; 
	damageValue = 0.01; 
	damageType = $ImpactDamageType; 
	explosionRadius = 1; 
	kickBackStrength = 0.0; 
	maxLevelFlightDist = 4; 
	totalTime = 0.55; 
	liveTime = 0.55;
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 1.0; 
	smokeName = "plasmatrail.dts"; 
};
//-------------------------------------------------| - End Grenade Data
GrenadeData MortarBunkerShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 2.0;
   elasticity         = 0.1;
   damageClass        = 1;     
   damageValue        = 15.0;
   damageType         = $MortarDamageType;
   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 1.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 1.5;
   smokeName              = "plasmatrail.dts";
};

GrenadeData MeteroidShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 2.0;
   elasticity         = 0.1;
   damageClass        = 1;     
   damageValue        = 15.0;
   damageType         = $MeteoroidDamageType;
   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 1.5;
   smokeName              = "plasmatrail.dts";
};

GrenadeData RatPoison
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag       = RatPoisonExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;    // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 275;
   totalTime          = 0.01;
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 1.0;
   smokeName              = "plastrail.dts";// mortartrail
};

GrenadeData AirStrikeMortarShell {
   bulletShapeName    = "liqcyl.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 1;
   damageClass        = 1;
   damageValue        = 12.0;
   damageType         = $MortarDamageType;
   explosionRadius    = 50.0;
   kickBackStrength   = 300.0;
   maxLevelFlightDist = 1;
   liveTime           = 0.01;
   totalTime          = 120.0;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 0;
   smokeName              = "shotgunex.dts";
};

GrenadeData ScatterShell {
   bulletShapeName    = "sensor_small.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;
   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $ExplosionDamageType;
   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};

GrenadeData AtomShell2 {
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       
   damageValue        = 0.32;
   damageType         = $MortarDamageType;
   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 9.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;
   inheritedVelocityScale = 0.5;
   smokeName              = "smoke.dts";
};