//--------------=Hybrid Damage Types=-----------------------\\

$ImpactDamageType                                     = -1;
$LandingDamageType                                    =  0;
$RipperBulletDamageType                               =  1;
$EnergyDamageType                                     =  2;
$PlasmaCannonDamageType                               =  3;
$StormHammerDamageType                                =  4;
$BioShrapnelDamageType                                =  5;
$LazereXDamageType                                    =  6;
$SplitMortarDamageType                                =  7;
$BlazterDamageType                                    =  8;
$ElectricityDamageType                                =  9;
$CrushDamageType                                      = 10;
$DebrisDamageType                                     = 11;
$MissileDamageType                                    = 12;
$MineDamageType                                       = 13;

//--------------=Added Hybrid Damage Types=-----------------\\

$FusionDamageType                                     = 14; 
$TimeBombDamageType                                   = 15; 
$FuzionDamageType                                     = 16; 
$HavocDamageType                                      = 17; 
$ShardDamageType                                      = 18; 
$GlockDamageType                                      = 19; 
$EWebDamageType   	                              = 20; 
$ARPGDamageType                                       = 21; 
$StealthDamageType                                    = 22; 
$MultiDamageType                                      = 23; 
$WTShotgunDamageType                                  = 24; 
$HellStormDamageType       			      = 25; 
$AnarchyCannonDamageType          		      = 26; 
$PlasGatDamageType       			      = 27; 
$ParticalShotgunDamageType             		      = 28; 
$EMPDamageType                                        = 29; 
$SalvoDamageType                                      = 30;
$AtomicDamageType                                     = 31; 
$RadiationDamageType                                  = 32; 
$DiscoDamageType                                      = 33; 
$LazerGatDamageType                                   = 34;
$GrazerDamageType                                     = 35;
$HybridLaserDamageType                                = 36;
$QuakeDamageType                                      = 37;
$SXHDamageType                                        = 38;
$HybridRailDamageType                                 = 39;
$MiniGunDamageType                                    = 40;
$DFMIYADamageType                                     = 41;
$DestroyerDamageType                                  = 42;
$HybridChainDamageType                                = 43;
$PlasmaBlasterDamageType                              = 44;
$BlazeDamageType                                      = 45;
$MeltLaserDamageType                                  = 46;
$NapalmLDamageType                                    = 47;
$NapalmRDamageType                                    = 48;
$MagmaDamageType                                      = 49;
$NitroDamageType                                      = 50;
$FireMDamageType                                      = 51;
$ContactMDamageType                                   = 52;
$RaidDamageType                                       = 53;
$ClashDamageType                                      = 54;
$SludgeDamageType                                     = 55;
$HybridMortarDamageType                               = 56;
$HybridCannonDamageType                               = 57;
$HybridMissileDamageType                              = 58;
$HybridRPGDamageType                                  = 59;
$ETTRDamageType                                       = 60;

######################################TESTING######################################
################################Shell Eject Animation FX###########################
################################A SlipKnot Original################################

function BulletDTSShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	if(%rand <= 0.5)
	{
		%rot = GameBase::getRotation(%this);
		%startpos = Vector::getFromRot(%rot, -0.6);
		%rot = Vector::add(%rot, %normalrot);
		%casingpos = Vector::getFromRot(%rot, 1.0);
		%casingpos = Vector::add(%casingpos, %startpos);
	
		%rotx = getWord(%rot, 0) - %rand;
		%roty = getWord(%rot, 1);
		%rotz = getWord(%rot, 2) - 0.785;
		%newrot = %rotx@" "@%roty@" "@%rotz;

		%pos = GameBase::getPosition(%this);
		%pos = Vector::add(%pos, %casingpos);
	
		%this = newObject("","Mine","BulletDTSEJCT");
		addToSet("MissionCleanup", %this);
		GameBase::setPosition(%this, %pos);
		GameBase::setRotation(%this, %newrot);
	
		%strength = 0.2;
		%obj = newObject("","Mine","BulletDTSEJCT");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,%strength,false);
	
		deleteObject(%this);
	}
}


function PlasmaDTSShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	if(%rand <= 0.5)
	{
		%rot = GameBase::getRotation(%this);
		%startpos = Vector::getFromRot(%rot, -0.6);
		%rot = Vector::add(%rot, %normalrot);
		%casingpos = Vector::getFromRot(%rot, 1.0);
		%casingpos = Vector::add(%casingpos, %startpos);
	
		%rotx = getWord(%rot, 0) - %rand;
		%roty = getWord(%rot, 1);
		%rotz = getWord(%rot, 2) - 0.785;
		%newrot = %rotx@" "@%roty@" "@%rotz;

		%pos = GameBase::getPosition(%this);
		%pos = Vector::add(%pos, %casingpos);
	
		%this = newObject("","Mine","PlasmaDTSEJCT");
		addToSet("MissionCleanup", %this);
		GameBase::setPosition(%this, %pos);
		GameBase::setRotation(%this, %newrot);
	
		%strength = 0.2;
		%obj = newObject("","Mine","PlasmaDTSEJCT");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,%strength,false);
	
		deleteObject(%this);
	}
}


function GrenadeDTSShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	if(%rand <= 0.5)
	{
		%rot = GameBase::getRotation(%this);
		%startpos = Vector::getFromRot(%rot, -0.6);
		%rot = Vector::add(%rot, %normalrot);
		%casingpos = Vector::getFromRot(%rot, 1.0);
		%casingpos = Vector::add(%casingpos, %startpos);
	
		%rotx = getWord(%rot, 0) - %rand;
		%roty = getWord(%rot, 1);
		%rotz = getWord(%rot, 2) - 0.785;
		%newrot = %rotx@" "@%roty@" "@%rotz;

		%pos = GameBase::getPosition(%this);
		%pos = Vector::add(%pos, %casingpos);
	
		%this = newObject("","Mine","GrenadeDTSEJCT");
		addToSet("MissionCleanup", %this);
		GameBase::setPosition(%this, %pos);
		GameBase::setRotation(%this, %newrot);
	
		%strength = 0.2;
		%obj = newObject("","Mine","GrenadeDTSEJCT");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,%strength,false);
	
		deleteObject(%this);
	}
}

function MortarDTSShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	if(%rand <= 0.5)
	{
		%rot = GameBase::getRotation(%this);
		%startpos = Vector::getFromRot(%rot, -0.6);
		%rot = Vector::add(%rot, %normalrot);
		%casingpos = Vector::getFromRot(%rot, 1.0);
		%casingpos = Vector::add(%casingpos, %startpos);
	
		%rotx = getWord(%rot, 0) - %rand;
		%roty = getWord(%rot, 1);
		%rotz = getWord(%rot, 2) - 0.785;
		%newrot = %rotx@" "@%roty@" "@%rotz;

		%pos = GameBase::getPosition(%this);
		%pos = Vector::add(%pos, %casingpos);
	
		%this = newObject("","Mine","MortarDTSEJCT");
		addToSet("MissionCleanup", %this);
		GameBase::setPosition(%this, %pos);
		GameBase::setRotation(%this, %newrot);
	
		%strength = 0.2;
		%obj = newObject("","Mine","MortarDTSEJCT");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,%strength,false);
	
		deleteObject(%this);
	}
}

function DiscDTSShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	if(%rand <= 0.5)
	{
		%rot = GameBase::getRotation(%this);
		%startpos = Vector::getFromRot(%rot, -0.6);
		%rot = Vector::add(%rot, %normalrot);
		%casingpos = Vector::getFromRot(%rot, 1.0);
		%casingpos = Vector::add(%casingpos, %startpos);
	
		%rotx = getWord(%rot, 0) - %rand;
		%roty = getWord(%rot, 1);
		%rotz = getWord(%rot, 2) - 0.785;
		%newrot = %rotx@" "@%roty@" "@%rotz;

		%pos = GameBase::getPosition(%this);
		%pos = Vector::add(%pos, %casingpos);
	
		%this = newObject("","Mine","DiscDTSEJCT");
		addToSet("MissionCleanup", %this);
		GameBase::setPosition(%this, %pos);
		GameBase::setRotation(%this, %newrot);
	
		%strength = 0.2;
		%obj = newObject("","Mine","DiscDTSEJCT");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,%strength,false);
	
		deleteObject(%this);
	}
}

function RocketDTSShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	if(%rand <= 0.5)
	{
		%rot = GameBase::getRotation(%this);
		%startpos = Vector::getFromRot(%rot, -0.6);
		%rot = Vector::add(%rot, %normalrot);
		%casingpos = Vector::getFromRot(%rot, 1.0);
		%casingpos = Vector::add(%casingpos, %startpos);
	
		%rotx = getWord(%rot, 0) - %rand;
		%roty = getWord(%rot, 1);
		%rotz = getWord(%rot, 2) - 0.785;
		%newrot = %rotx@" "@%roty@" "@%rotz;

		%pos = GameBase::getPosition(%this);
		%pos = Vector::add(%pos, %casingpos);
	
		%this = newObject("","Mine","RocketDTSEJCT");
		addToSet("MissionCleanup", %this);
		GameBase::setPosition(%this, %pos);
		GameBase::setRotation(%this, %newrot);
	
		%strength = 0.2;
		%obj = newObject("","Mine","RocketDTSEJCT");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,%strength,false);
	
		deleteObject(%this);
	}
}
//==================================================================================
BulletData ARPGShell
{
   bulletShapeName    = "grenade.dts";

   explosionTag       = grenadeExp;
   expRandCycle       = 0.02;
   aimDeflection      = 0.02;

   collisionRadius = 0.0;
   mass = 2.0;
   damageClass        = 1;       
   damageValue        = 0.5;
   damageType         = $ARPGDamageType;
   explosionRadius = 7.5;
   kickBackStrength = 50.0;

   muzzleVelocity     = 65.0;
   terminalVelocity = 80.0;
   acceleration = 5.0;
   totalTime          = 6.5;
   liveTime = 8.0;
   lightRange = 5.0;
   lightColor = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;
	
   tracerPercentage   = 10.0;
   tracerLength       = 30;
};
///////////////////////////////////////////////////////////////////////////////////

GrenadeData MinerShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType; 

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 20.0;
   liveTime           = 20.0; // grenade time live after contact
   projSpecialTime    = 0.01; // smoke interval

   inheritedVelocityScale = 0.5;
   smokeName     = "dustplume.dts";
};

GrenadeData MineFloaters
{
   bulletShapeName    = "mine.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	//5.0
   elasticity         = 0.45;	//0.1

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $ShrapnelDamageType; 

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; // grenade time live after contact
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "dustplume.dts";
};

GrenadeData ClaymoreSplit
{
   bulletShapeName    = "Mortar.dts";//grenade.dts
   explosionTag       = debrisExpSmall;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01; // grenade time live after contact
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "dustplume.dts";
};
####################################################################################################
//----------------=End Damage Types=-----------------------
//=========================================================
//----------------=Start Null Data=------------------------

GrenadeData Invul 
{ 
	bulletShapeName = "shotgunbolt.dts"; 
	explosionTag = InvulExp; 
	collideWithOwner = false; 
	ownerGraceMS = 500; 
	collisionRadius = 0.0; 
	mass = 0.0; 
	elasticity = 0.1; 
	damageClass = 0; 
	damageValue = -0.01; 
	damageType = $ImpactDamageType; 
	explosionRadius = 1; 
	kickBackStrength = 0.0; 
	maxLevelFlightDist = 4; 
	totalTime = 0.55; 
	liveTime = 0.55; // grenade time live after contact
        lightRange         = 3.0;
        lightColor         = { 5.0, 0.2, 0.2 };
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 1.0; 
	smokeName = "shotgunex.dts"; 
}; 

//-----------------------------------------------------------

GrenadeData ShockedDamage
{
   bulletShapeName    = "enex.dts";
   explosionTag       = ShockedDamageExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.3;
   damageType         = $NullDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "rsmoke.dts";
};

GrenadeData ShockJet
{
   bulletShapeName    = "laserhit.dts";
   explosionTag       = ShockJetExp;
   collideWithOwner   = True;
   ownerGraceMS       = 0;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.1;
   damageType         = $EnergyDamageType;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

//-----------------------------------------------------------

GrenadeData ToxicSmoke1
{
   bulletShapeName    = "plastrail.dts";
   explosionTag       = ToxicShock2Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 1.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
//   projSpecialTime    = 0.01;
   projSpecialTime    = 2.5;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};

//-----------------------------------------------------------

GrenadeData ToxicSmoke2
{
   bulletShapeName    = "mortartrail.dts";
   explosionTag       = ToxicShock1Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;
   damageValue        = 0.0;
   damageType         = false;

   explosionRadius    = 0;
   kickBackStrength   = 0;
   maxLevelFlightDist = 0;
   totalTime          = 0.01;    // special meaning for grenades...
   liveTime           = 0.01;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "mortartrail.dts";
};

//------------------=End Null Data=--------------------------
//===========================================================
//----------------=Start Bullet Data=------------------------

BulletData BlazterBolt
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = BlasterXExp;

   damageClass        = 0;
   damageValue        = 0.25;
   damageType         = $BlazterDamageType;
   explosionRadius    = 3.0;
   aimDeflection      = 0.01;

   muzzleVelocity     = 300.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 5.0, 0.2, 0.2 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};

//------------------------------------------------------------

BulletData RipperChaingunBullet 
	{ 
	bulletShapeName = "bullet.dts"; 
	explosionTag = RipperbulletExp; 
	expRandCycle = 3; 
	mass = 0.05; 
	bulletHoleIndex = 0; 
	damageClass = 0; 
	damageValue = 0.03; 
	damageType = $RipperBulletDamageType; 
	aimDeflection = 0.005; 
	muzzleVelocity = 425.0; 
	totalTime = 1.5; 
	inheritedVelocityScale = 1.0; 
	isVisible = False; 
	tracerPercentage = 1.0; 
	tracerLength = 35; 
	}; 

//------------------------------------------------------------

RocketData PlasmaCannonbolt 
	{ 
	bulletShapeName = "Plasmabolt.dts"; 
	explosionTag = PlasmaCExp; 
	collisionRadius = 0.0; 
	mass = 2.0; 
	damageClass = 1; 
	damageValue = 0.55; 
	damageType = $PlasmaCannonDamageType; 
	explosionRadius = 5.0; 
	kickBackStrength = 0; 
	muzzleVelocity = 65.0; 
	terminalVelocity = 80.0; 
	acceleration = 11.0; 
	totalTime = 6.5; 
	liveTime = 8.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.63, 0.0 }; 
	inheritedVelocityScale = 0.5; 
	trailType = 2; 
	trailString = "plasmabolt.dts"; 
	smokeDist = 9.8;
	soundId = SoundDryFire; 
	};

//--------------------------------------------------------------

GrenadeData BioGrenadeShell1
{ 
        bulletShapeName = "mortar.dts";
        explosionTag = BioExp;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 5;
        elasticity = 0.02;
        damageClass = 1;
        damageValue = 0.9;
        damageType = $BioShrapnelDamageType;
        explosionRadius = 8;
        kickBackStrength = 100;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 1.5;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "mortartrail.dts";
        soundId = SoundELFFire;
};

GrenadeData BioGrenadeShell2
{ 
        bulletShapeName = "grenade.dts";
        explosionTag = BioExp2;
        collideWithOwner = True;
        ownerGraceMS = 250;
        collisionRadius = 0.2;
        mass = 5;
        elasticity = 0.02;
        damageClass = 1;
        damageValue = 0;
        //damageType = $BioShrapnelDamageType;
        explosionRadius = 8;
        kickBackStrength = 100;
        maxLevelFlightDist = 250;
        totalTime = 5;
        liveTime = 1.5;
        projSpecialTime = 0.05;
        inheritedVelocityScale = 0.5;
        smokeName = "plastrail.dts";
        soundId = SoundELFFire;
};
//---------------------------------------------------------------
// Split Mortar
//---------------------------------------------------------------

GrenadeData MortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $SplitMortarDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 20.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "mortartrail.dts";
};

GrenadeData MortarSplit
{
   bulletShapeName    = "mortartrail.dts";
   explosionTag       = MortSplitExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;     
   damageValue        = 0;
   damageType         = $SplitMortarDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 5;
   totalTime          = 0.01;    
   liveTime           = 0.01; 
   projSpecialTime    = 0.05;
   soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "mortartrail.dts";
};



GrenadeData MortarFire
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;     
   damageValue        = 1.0;
   damageType         = $SplitMortarDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 100.0;
   maxLevelFlightDist = 5;
   totalTime          = 0.01;    
   liveTime           = 0.01; 
   projSpecialTime    = 0.05;
   soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "mortartrail.dts";
};

//-------------------------------------------------------

RocketData DiscShell
{
   bulletShapeName = "discb.dts";
   explosionTag    = StormhammerExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.7;
   damageType       = $StormHammerDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 100.0;
   acceleration     = 15.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;


   // rocket specific
   trailType   = 1;
   trailLength = 25;
   trailWidth  = 0.7;
   soundId = SoundDiscSpin;
};

//----------------------------------------------------------

LaserData sniperLaser
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "shotgunex.dts";

   damageConversion  = 0.60;
   baseDamageType    = $LazerexDamageType;

   beamTime          = 1.0;

   lightRange        = 2.0;
   lightColor        = { 5.0, 0.0, 0.0 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

//-----------------------------------------------------------
// Start Flux Beams
//-----------------------------------------------------------


LightningData FluxCharge1
{
   bitmapName       = "paintglow.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 100.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}


LightningData FluxCharge2
{
   bitmapName       = "shex05.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.3;
   energyDrainPerSec = 45.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 80;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};


LightningData FluxCharge3
{
   bitmapName       = "fusion05.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.3;
   energyDrainPerSec = 10.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.155;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function FluxCharge3::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %dectructiveValue = %DestructiveRotation;
   %DestructiveRotation = GameBase::GetRotation(Client::getOwnedObject(%shooterId));
   %velocity = -35;
   %destructiveShooterDir = Vector::getFromRot(GameBase::getRotation(%shooterId),%velocity,%destuctiveValue);
   Player::applyImpulse(%target, %destructiveShooterDir);
   
   %player = client::getOwnedObject(%shooterId);
   %armor = Player::getArmor(%shooterId);
   %targetDestruction = GameBase::getDamageState(%targetDestuction);

   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if(%energy < 0) %energy = 0;
   GameBase::setEnergy(%target, %energy);

   if(%targetDestruction != "Destroyed")
   {
   %destructorHealth = GameBase::getDamageLevel(%player);
   if(%destructorHealth != 0) 
   GameBase::setDamageLevel(%player,%destructorHealth - (%enVal * 0.01));
   }
}

//---------------=End Standard Weapon Projectiles=-------------------------------------------------------------

//---------------=Start Energy Based Projectiles=--------------------------------------------------------------

RocketData FuzionRifleBullet
{
   bulletShapeName = "enbolt.dts";
   explosionTag    = FuzionRifleExp;

   collisionRadius = 0.0;
   mass            = 0.5;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.60;
   damageType       = $FuzionDamageType;

   explosionRadius  = 0;
   kickBackStrength = 0;

   muzzleVelocity   = 800.0;
   terminalVelocity = 800.0;
   acceleration     = 8.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 5.0, 0, 0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 20;
   trailWidth  = 0.3;

   soundId = SoundDiscSpin;
};

//---------------------------------------------------------------------------------------------------------------
// Shock rifle Data
//---------------------------------------------------------------------------------------------------------------

LaserData ShockLaser
{
   laserBitmapName   = "forcefield.bmp";
   hitname           = "fusionex.dts";
   damageConversion  = 0.7;
   baseDamageType    = $EMPDamageType;
   beamTime          = 2.2;
   lightRange        = 2.0;
   lightColor        = { 0.0, 0.0, 50.25 };
   detachFromShooter = true;
   hitSoundId        = SoundELF;
};

//--------------------------------------

RocketData ShockRocket
{
   bulletShapeName  = "fusionbolt.dts";
   explosionTag     = AnarchyRifleExp;
   collisionRadius  = 0.0;
   mass             = 5.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.85;
   damageType       = $EMPDamageType;

   muzzleVelocity   = 2100.0;
   terminalVelocity = 2100.0;
   acceleration     = 30.0;
   totalTime        = 7.0;
   liveTime         = 5.0;
   lightRange       = 5.0;
   lightColor       = { 0.0, 0.0, 50.25 };
   inheritedVelocityScale = 0.5;

   //rocket specific
  trailType   = 2;                
  trailString = "enex.dts";
   smokeDist   = 1.8;

   soundId = SoundFireSeeking;
};

//-------------------------------------

LaserData RadiationLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = "paint.dts";

   damageConversion  = 0.025;
   baseDamageType    = $RadiationDamageType;

   beamTime          = 2.0;

   lightRange        = 10.0;
   lightColor        = { 0, 5.0, 0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

//-------------------------------------

LaserData DiscoLaser
{
   laserBitmapName   = "x08.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 75;
   damageValue = 50;

   baseDamageType    = $DiscoDamageType;

   beamTime          = 30.0;

   lightRange        = 10;
   lightColor        = { 40.0, 0.23, 1.0 };

   detachFromShooter = true;
   hitSoundId        = SoundLaserHit;
};

//---------------------------------------

LaserData GatlaserBeam
{
   laserBitmapName   = "laserpulse.bmp";
   hitName           = "shotgunex.dts";
   damageConversion  = 0.05;
   baseDamageType    = $LazerGatDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundShieldHit;
};

//----------------------------------------

LaserData GrazerLaser
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "fusionex.dts";
   damageConversion  = 0.05;
   baseDamageType    = $GrazerDamageType;
   beamTime          = 0.3;
   lightRange        = 4.0;
   lightColor        = { 0, 3, 0 };
   detachFromShooter = false;
   hitSoundId        = turretExplosion;
};

//-----------------------------------------

LaserData HybridBeam
{
   laserBitmapName   = "warp.bmp";
   hitname           = "plasmatrail.dts";
   damageConversion  = 0.25;
   baseDamageType    = $HybridLaserDamageType;
   beamTime          = 6.0;
   lightRange        = 2.0;
   lightColor        = { 1.0, 0.0, 1.0 };
   detachFromShooter = true;
   hitSoundId        = SoundELF;
};

//-----------------------------------------

LightningData GrapplingBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 300.0; // 120
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 0.0;
   segmentDivisions = 1;
   numSegments      = 3;
   beamWidth        = 1.0;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };

   soundId = SoundELFFire;
};

$TractorPower = 50;

function GrapplingBeam::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) 
{
  %obj1 = %target;
  %obj2 = %shooterId;

   // Get object's mass  
  if (getObjectType(%obj1) == "Player") 
    %obj1mass = Player::getArmor(%obj1).mass;
  else
    %obj1mass = 10000;

  %obj2mass = Player::getArmor(%obj2).mass;

   // 
  %vec = Vector::Normalize(Vector::Sub(GameBase::getPosition(%obj1), GameBase::getPosition(%obj2)));

  if (getObjectType(%obj1) == "Player")
  {
    %mul = $TractorPower - ($TractorPower * %obj1mass) / (%obj1mass + %obj2mass);
    %nvec = (getWord(%vec, 0) * %mul * -1) @ " " @
            (getWord(%vec, 1) * %mul * -1) @ " " @
            (getWord(%vec, 2) * %mul * -1);
    //Player::applyImpulse(%obj1, %nvec);
    Item::setVelocity(%obj1, %nvec);
  }

   // obj2 is always a player
  %mul = $TractorPower - ($TractorPower * %obj2mass) / (%obj1mass + %obj2mass);
  %nvec = (getWord(%vec, 0) * %mul) @ " " @
          (getWord(%vec, 1) * %mul) @ " " @
          (getWord(%vec, 2) * %mul);
  //Player::applyImpulse(%obj2, %nvec);
  Item::setVelocity(%obj2, %nvec);
}

//-----------------------------------------------------

RocketData QuakeBlast
{
   bulletShapeName = "tumult_small.dts";
   explosionTag    = PulseExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.1;
   damageType       = $QuakeDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 900.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "dustplume.dts";
   smokeDist   = 1.8;


   soundId = SoundDiscSpin;
};

//-----------------------------------------------------

BulletData HellStormCloud
{
   bulletShapeName    = "fiery.dts";
   explosionTag       = grenadeExp;

   collisionRadius    = 0.0;
   mass               = 1.0;

   damageClass        = 1;
   damageValue        = 0.4;
   damageType         = $HellStormDamageType;

   explosionRadius    = 9.0;
   kickBackStrength   = 200;

   muzzleVelocity     = 350.0;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

//--------------------------------------------------------

RocketData FusionCannonShell
{
   bulletShapeName = "fusionex.dts";
   explosionTag    = mortarExp;

   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $FusionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 100;
   terminalVelocity = 120;
   acceleration     = 1;

   totalTime        = 20.0;
   liveTime         = 21.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 20;

   soundId = SoundDiscSpin;
};

//-------------------=Start Multi-Cannon Projectiles=------------------

BulletData MC00
{
   bulletShapeName    = "enbolt.dts";
   validateShape      = false;
   explosionTag       = energyExp;
   mass               = 0.05;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.05;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.01;
   muzzleVelocity     = 200.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC01
{
   bulletShapeName    = "shotgunbolt.dts";
   validateShape      = false;
   explosionTag       = BlasterXExp;
   mass               = 0.05;
   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.1;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.01;
   muzzleVelocity     = 200.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC02
{
   bulletShapeName    = "fusionbolt.dts";
   validateShape      = false;
   explosionTag       = turretExp;
   mass               = 0.05;
   explosionRadius = 3.0;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.2;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.009;
   muzzleVelocity     = 210.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC03
{
   bulletShapeName    = "plasmabolt.dts";
   validateShape      = false;
   explosionTag       = plasmaExp;
   mass               = 0.05;
   explosionRadius = 5.0;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.005;
   muzzleVelocity     = 240.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC04
{
   bulletShapeName    = "shield.dts";
   validateShape      = false;
   explosionTag       = ShockwaveFour;
   mass               = 0.05;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 10.0;
   damageValue        = 0.6;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.02;
   muzzleVelocity     = 270.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC05
{
   bulletShapeName    = "fusionex.dts";
   validateShape      = false;
   explosionTag       = grenadeExp;
   mass               = 0.05;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 10.0;
   damageValue        = 0.95;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.002;
   muzzleVelocity     = 280.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};
BulletData MC06
{
   bulletShapeName    = "mortar.dts";
   validateShape      = false;
   explosionTag       = nappyExp;
   mass               = 0.05;
   damageClass        = 1;       // 0 impact, 1, radius
   explosionRadius = 10.0;
   damageValue        = 1.3;
   damageType         = $PhaserDamageType;
   aimDeflection      = 0.005;
   muzzleVelocity     = 310.0;
   totalTime          = 3.5;
   inheritedVelocityScale = 1.0;
   isVisible          = true;
   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

RocketData MCMega
{
   bulletShapeName  = "shield_large.dts";
   explosionTag     = mortarExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $PhaserDamageType;

   explosionRadius  = 25.5;
   kickBackStrength = 450.0;
   muzzleVelocity   = 265.0;
   terminalVelocity = 380.0;
   acceleration     = 2.0;
   totalTime        = 3.0;
   liveTime         = 4.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;
   trailString = "Plasmaex.dts";
   smokeDist   = 1.0;
   soundId = SoundJetHeavy;
};

//------------------=End Multic-Cannon Projectiles=--------------------

//----------------------=Start Cartridge Based=------------------------

RocketData GlockBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = smokerExp;  
   collisionRadius  = 0.0;
   mass             = 0.4;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $GlockDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 0.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   //trailType   = 1;         
   //trailLength = 3000; 
   //trailWidth  = 0.7; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};

//--------------------------------------------------

BulletData WT12GPellet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = ShotExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.07;
   damageType         = $WTShotgunDamageType;

   aimDeflection      = 0.02;
   muzzleVelocity     = 300.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------------------

BulletData ParticalPellet1
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = PartRedExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $ParticalShotgunDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 50.0, 0.0, 0.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

BulletData ParticalPellet2
{
   bulletShapeName    = "enex.dts";
   explosionTag       = PartBlueExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $ParticalShotgunDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 0.0, 50.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};

BulletData ParticalPellet3
{
   bulletShapeName    = "paint.dts";
   explosionTag       = PartGreenExp;

   damageClass        = 0;
   damageValue        = 0.2;
   damageType         = $ParticalShotgunDamageType;

   muzzleVelocity     = 300.0;
   totalTime          = 6.0;
   liveTime           = 4.0;

   lightRange         = 2.0;
   lightColor         = { 0.0, 50.0, 0.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   aimDeflection      = 0.02;

   rotationPeriod = 0.5;
};
//----------------------------------------------------

RocketData SXHBullet
{
   bulletShapeName    = "breath.dts";
   explosionTag       = SXHshotexp1; 
expRandCycle = 3; 
   collisionRadius  = 0.0;
   mass             = 0.8;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $SXHDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   //trailType   = 1;         
   //trailLength = 3000; 
   //trailWidth  = 0.7; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};

//---------------------------------------------------

RocketData HaVoCBullet
{
   bulletShapeName    = "tracer.dts";
   explosionTag       = HavocExp;  
   collisionRadius  = 0.0;
   mass             = 0.8;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 5.0;
   damageType       = $HavocDamageType;

   explosionRadius  = 1.0; //0.1;
   kickBackStrength = 600.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;         
   trailLength = 3000; 
   trailWidth  = 0.7; 
   tracerPercentage   = 100.0; 
   tracerLength       = 30; 

 soundId = SoundJetHeavy;
};

//------------------------------------------------------

RocketData HybridRailSpike
{
   bulletShapeName    = "tracer.dts";
   explosionTag       = BulletExp0;  
   collisionRadius  = 0.0;
   mass             = 5.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 3.0;
   damageType       = $HybridRailDamageType;

   explosionRadius  = 1.0;
   kickBackStrength = 60.0;
   muzzleVelocity   = 2000.0;
   terminalVelocity = 2000.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 10.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 1;         
   trailLength = 3000; 
   trailWidth  = 0.5; 
   tracerPercentage   = 100.0; 
   tracerLength       = 300; 

 soundId = SoundJetHeavy;
};

//------------------------------------------------------------

BulletData MinigunBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = bulletExp0;
	expRandCycle = 3;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $MiniGunDamageType;
      aimDeflection      = 0.002;
	muzzleVelocity = 900.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//-------------------------------------------------------------

BulletData Shard
{
   bulletShapeName    = "enex.dts";
   explosionTag       = ShardExp;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.16;
   damageType         = $ShardDamageType;

   aimDeflection      = 0.005;
   muzzleVelocity     = 400.0;
   totalTime          = 0.7;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//----------------------------------------------------------------

RocketData DFMIYABullet
{
   bulletShapeName = "Rocket.dts";
   explosionTag    = vulcanrocketExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $DFMIYADamageType;

   explosionRadius  = 10;
   kickBackStrength = 5;

   muzzleVelocity   = 355;
   terminalVelocity = 355;
   acceleration     = 1;

   totalTime        = 2;
   liveTime         = 1;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 15;
   trailWidth  = 0.8;

   soundId = SoundDiscSpin;
};

//-----------------------------------------------------------

BulletData DestroyerBullet
{
   bulletShapeName    = "laserhit.dts";
   explosionTag       = smokerExp;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.17;
   damageType         = $DestroyerDamageType;

   aimDeflection      = 0.002;
   muzzleVelocity     = 400.0;
   totalTime          = 0.7;
   inheritedVelocityScale = 1.0;
   isVisible          = true;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//------------------------------------------------------------

BulletData HybridChainBullet
{	bulletShapeName = "bullet.dts";
	explosionTag = HybridCExp;
	expRandCycle = 0;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 0;  // 0 impact, 1, radius
	damageValue = 0.075;
	damageType = $HybridChainDamageType;
	muzzleVelocity = 768.0;
	totalTime = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible = False;
	tracerPercentage = 1.0;
	tracerLength = 30;
};

//------------------------------------------------------------

GrenadeData ClusterBomb
{	bulletShapeName = "Shockwave_Large.dts";
	explosionTag = LargeShockwave;
	collideWithOwner = True;
	ownerGraceMS = 500;
	collisionRadius = 0.3;
	mass = 5.0;
	elasticity = 0.4;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 3;
	damageType = $AtomicDamageType;
	explosionRadius = 100.0;
	kickBackStrength = 100.0;
	maxLevelFlightDist = 250;
	totalTime = 50.0;
	liveTime = 6.0;
	projSpecialTime = 0.01;
	inheritedVelocityScale = 0.5;
	//smokeName = "paint.dts";
	smokeName = "shield_large.dts";
};

function ClusterBomb::onAdd(%this, %player)
{
	schedule("bombspread(" @ %this @ ");",5.0);
}

function bombspread(%this)
{
                %obj = newObject("","Mine","bomba");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 5.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombb");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombc");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "-10.0 0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 10. 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);

                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 -10.0 25";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombe");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 35";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


                %obj = newObject("","Mine","bombf");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 15";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
		    Client::setOwnedObject(%client, %turret);


}

//______________________________________________________________________________________



RocketData swordhit 
{	bulletShapeName = "mortartrail.dts";
	explosionTag = WebExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.00;
	damageType = $FlashDamageType;
	explosionRadius = 5;
	kickBackStrength = -300.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";
	smokeDist = 4.5;
	soundId = SoundJetHeavy;
};
//--------------------------------------
// GripBolt By: *SlipKnot*
//--------------------------------------
RocketData IonEEBolt 
{	bulletShapeName = "mortartrail.dts";
	explosionTag = WebExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.00;
	damageType = $FlashDamageType;
	explosionRadius = 5;
	kickBackStrength = -300.0;
	muzzleVelocity = 200.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 0.0, 1.0, 0.0 };
	inheritedVelocityScale = 0.5;
	trailType = 2;
	trailString = "mortartrail.dts";
	smokeDist = 4.5;
	soundId = SoundJetHeavy;
};
//=======================
SeekingMissileData MiniFlakproj
{
   bulletShapeName = "mortar.dts";
   explosionTag    = debrisExpLarge;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $ShrapnelDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 100.0;
   totalTime         = 3;
   liveTime          = 3;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   //smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   //soundId = SoundJetHeavy;
};

//--------------------------------------
SeekingMissileData MiniSAMproj
{
   bulletShapeName = "rocket.dts";
   explosionTag    = Rocketexp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 30.0;
   terminalvelocity  = 100;
   acceleration      = 2;
   totalTime         = 20;
   liveTime          = 20;
   seekingTurningRadius    = 1;
   nonSeekingTurningRadius = 1;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   //lightRange       = 5.0;
   //lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.76;

   //soundId = SoundJetHeavy;
};
//---------
BulletData PlasmaBoltTurrt
{
   bulletShapeName    = "plasmaex.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 1;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4;

   muzzleVelocity     = 600;
   totalTime          = 2;
   liveTime           = 1;
   //lightRange         = 3.0;
   //lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0;
   isVisible          = True;

   soundId = SoundJetLight;
};



//- ------------ Charge bolts

//--------------------------------------
GrenadeData NapSplit
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;     
   damageValue        = 0.1;
   damageType         = $NapalmLDamageType;

   explosionRadius    = 10;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 150;
   totalTime          = 0.01;    
   liveTime           = 0.01; 
   projSpecialTime    = 0.05;
soundId = SoundJetLight;
   inheritedVelocityScale = 0.5;

   smokeName              = "plasmatrail.dts";
};

GrenadeData NapShell
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
//   mass               = 5.0;
//   elasticity         = 0.1;
   mass               = 1.0;
   elasticity         = 0.2;

   damageClass        = 1;      
   damageValue        = 0.2;
   damageType         = $NapalmLDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 20.0;
   liveTime           = 20.0; 
   projSpecialTime    = 0.01; 

   inheritedVelocityScale = 0.5;
   smokeName     = "plasmatrail.dts";
};

GrenadeData NapFire
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 1.0;	
   elasticity         = 0.45;	

   damageClass        = 1;       
   damageValue        = 0.22;
   damageType         = $NapalmLDamageType;

   explosionRadius    = 15.0;
   kickBackStrength   = 10.0;
   maxLevelFlightDist = 275;
   totalTime          = 2.1;
   liveTime           = 2.1; 
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

//--------------------------------------

//======================================
//======================================
BulletData swordBullet
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = armExp;
   damageClass        = 0;
   damageValue        = 0.075;
   damageType         = $BlasterDamageType;
   muzzleVelocity     = 90.0;
   totalTime          = 0.03;
   liveTime           = 0.031;
   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = false;
};
//--------------------------------------
RocketData StingerRocket
{	bulletShapeName = "FusionBolt.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $ETTRDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "paint.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};
//--------------------------------------
SeekingMissileData StingerMissile
{	bulletShapeName = "fusionex.dts";
	explosionTag = MortarExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.8;
	damageType = $ETTRDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 25.0;
	muzzleVelocity = 150.0;
	terminalVelocity = 150.0;
	totalTime = 10;
	liveTime = 10;
	seekingTurningRadius = 9;
	nonSeekingTurningRadius = 75.0;
	proximityDist = 1.5;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
      // rocket specific
	trailType = 2;
	trailString = "rsmoke.dts";
	smokeDist = 1;
};
//--------------------------------------
SeekingMissileData HybridMissile
{	bulletShapeName = "Rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 0.5;
	damageClass = 1;
	damageValue = 0.50;
	damageType = $HybridMissileDamageType;
	explosionRadius = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity = 50.0;
	terminalVelocity = 120.0;
	acceleration = 1.0;
	totalTime = 8.0;
	liveTime = 9.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType = 2;
	trailString = "plasmabolt";
	smokeDist = 1;
	soundId = SoundJetHeavy;
	seekingTurningRadius = 2.5;
};

function SeekingMissile::updateTargetPercentage(%target)
{
	return GameBase::virtual(%target, "getHeatFactor");
}
//--------------------------------------
GrenadeData BigBoom
{
   bulletShapeName    = "shockwave_large.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = False;
   ownerGraceMS       = 0;
   collisionRadius    = 0.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 50;
   damageType         = $BoomDamageType;

   explosionRadius    = 50;
   kickBackStrength   = 50.0;
   maxLevelFlightDist = 0;
   totalTime          = 0.1;
   liveTime           = 0.1;
   projSpecialTime    = 0.1;

   inheritedVelocityScale = 0.5;

   smokeName              = "plasmabolt.dts";
};
//---------------------------------------- 
GrenadeData HybridShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 6.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $HybridMortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 50;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmatrail.dts";
   smokeDist          = 0.01;
};

GrenadeData HybridShell2
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = Fire3Exp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 6.0;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $HybridMortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 100;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "plasmatrail.dts";
   smokeDist          = 0.01;
};
//---------------------------------------
RocketData NRocket
{	bulletShapeName = "Mortar.dts";
	explosionTag = DebrisExpLarge;
	collisionRadius = 0.0;
	mass = 1.5;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $FlakDamageType;
	explosionRadius = 5;
	kickBackStrength = 35;
	muzzleVelocity = 120.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 3.0, 0.7, 5.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plastrail.dts";
	smokeDist = 5;
	soundId = SoundJetHeavy;
};

//--------------------------------------


RocketData chainRockets
{	bulletShapeName = "discb.dts";
	explosionTag = TurretExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.8;
	damageType = $ExplosionDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "snowplume.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};



BulletData ALCbullet
{
   bulletShapeName    = "Paint.dts";
   explosionTag       = debrisExpSmall;

   damageClass        = 1;
   damageValue        = 0.35;
   damageType         = $BlasterDamageType;
   explosionRadius    = 3.0;
   aimDeflection      = 0.01;

   muzzleVelocity     = 300.0;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};


GrenadeData ScatterBomb
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = PopcornExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;
   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0;
   damageType         = $MortarDamageType;
   explosionRadius    = 20.0;
   kickBackStrength   = 20.0;
   maxLevelFlightDist = 445;
   totalTime          = 3.6;
   liveTime           = 3.5;
   projSpecialTime    = 0.01;
   inheritedVelocityScale = 0.5;
   smokeName              = "flash_small.dts";
};

BulletData HybridCannonShot
{	bulletShapeName = "shotgunbolt.dts";
	explosionTag = BlastExp0;
	expRandCycle = 0;
	mass = 0.05;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.255;
	damageType = $HybridCannonDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0.025;
	muzzleVelocity = 255.0;
	totalTime = 17.5;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};


RocketData HybridRocket
{	bulletShapeName = "rocket.dts";
	explosionTag = rocketExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;
	damageValue = 0.65;
	damageType = $HybridMissileDamageType;
	explosionRadius = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity = 75.0;
	terminalVelocity = 80.0;
	acceleration = 5.0;
	totalTime = 6.0;
	liveTime = 7.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;
	trailString = "plasmabolt.dts";
	smokeDist = 20;
	soundId = SoundJetHeavy;
};

RocketData HybridRPG
{	bulletShapeName = "rocket.dts";
	explosionTag = grenadeExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.4;
	damageType = $HybridRPGDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plasmatrail.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};

RocketData MagmaRocket
{	bulletShapeName = "plasmabolt.dts";
	explosionTag = plasmaExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.7;
	damageType = $MagmaDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plasmabolt.dts";
	smokeDist = 6;
	soundId = SoundJetHeavy;
};



RocketData ClashRocket1
{	bulletShapeName = "rocket.dts";
	explosionTag = ClashExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $ClashDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.63, 0.0 };       
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "plasmatrail.dts";
	smokeDist = 3;
	soundId = SoundJetHeavy;
};

RocketData ClashRocket2
{	bulletShapeName = "rocket.dts";
	explosionTag = ClashExp;
	collisionRadius = 0.0;
	mass = 2.0;
	damageClass = 1;  // 0 impact, 1, radius
	damageValue = 0.3;
	damageType = $ClashDamageType;
	explosionRadius = 15;
	kickBackStrength = 150.0;
	muzzleVelocity = 100.0;
	terminalVelocity = 200.0;
	acceleration = 5.0;
	totalTime = 10.0;
	liveTime = 11.0;
	lightRange = 5.0;
	lightColor = { 1.0, 0.63, 0.0 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 2;  // smoke trail
	trailString = "smoke.dts";
	smokeDist = 1;
	soundId = SoundJetHeavy;
};


BulletData VulcanBullet
{	bulletShapeName = "rocket.dts";
	explosionTag = RocketExp;
	mass = 0.10;
	bulletHoleIndex = 0;
	damageClass = 1;
	damageValue = 0.15;
	damageType = $BulletDamageType;
	explosionRadius = 7.5;
	kickBackStrength = 50.0;
	aimDeflection = 0;
	muzzleVelocity = 355.0;
	totalTime = 10;
	inheritedVelocityScale = 1.0;
	isVisible = True;
	tracerPercentage = 1.0;
	tracerLength = 30;
};




BulletData FlierBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = rocketExp;
   expRandCycle       = 3;
   mass               = 5.0;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.30;
   damageType         = $AvengerDamageType;

   aimDeflection      = 0.015;
   muzzleVelocity     = 900.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};







//--------------------------------------
RocketData M10Bullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = M102Exp;  
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $BulletDamageType;

   explosionRadius  = 2.0; 
   kickBackStrength = 6.0;
   muzzleVelocity   = 500.0;
   terminalVelocity = 1000.0;
   acceleration     = 5.0;
   totalTime        = 5.0;
   liveTime         = 5.0;
   lightRange       = 1.0;
   lightColor       = {0.25, 0.25, 1};
   inheritedVelocityScale = 1.0;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "breath.dts";
   smokeDist   = 0.5;

 soundId = SoundJetHeavy;
};


RocketData FlakBullet
{
   bulletShapeName = "mortar.dts";
   explosionTag    = debrisExpMedium;

   collisionRadius = 0.0;
   mass            = 1;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.6;
   damageType       = $ExplosionDamageType;
   aimDeflection = 0;
   explosionRadius  = 5.0;
   kickBackStrength = 0.10;

   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;

   totalTime        = 10.0;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1;

   
   soundId = SoundDiscSpin;
};


BulletData ChargedPlasmaBullet
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = plasmaExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.6;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 6;

   muzzleVelocity     = 75.0;
   totalTime          = 111.5;
   inheritedVelocityScale = 1.0;
   isVisible          = True;

   rotationPeriod     = 144.0;
};






//--------------------------------------
BulletData FusionBolt
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = plasmaExp;
   mass               = 1.0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 1;
   damageType         = $EnergyDamageType;

   muzzleVelocity     = 150.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 1.5;
};

BulletData QuantumTorpedo
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = mortarExp;
   mass               = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $QuantumDamageType;
   explosionRadius    = 10.0;

   muzzleVelocity     = 55.0;
   totalTime          = 6.0;
   liveTime           = 4.0;
   isVisible          = True;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enbolt.dts";
   smokeDist   = 1.8;

   rotationPeriod = 1.5;
};

BulletData SR71Bolt
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;

   damageClass        = 0;
   damageValue        = 0.075;
   damageType         = $EnergyDamageType2;

   muzzleVelocity     = 100.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 5.0;
   lightColor         = { 0.0, 0.0, 5.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};


//---------------------


BulletData FusionCannonBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = FusionCannonExplosion;
   mass               = 0.05;
   explosionRadius    = 50;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 5.0;
   damageType         = $FusionDamageType;

   muzzleVelocity     = 30.0;
   totalTime          = 60.0;
   liveTime           = 4.0;
   isVisible          = True;

   rotationPeriod = 0.1;
};

BulletData SpeedBikeBullet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = debrisExpSmall;

   damageClass        = 1;
   damageValue        = 0.25;
   damageType         = $EnergyDamageType2;
   explosionRadius    = 3.0;

   muzzleVelocity     = 175.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 5.0;
   lightColor         = { 0.0, 0.0, 5.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shotgunex.dts";
   smokeDist   = 1.8;

   rotationPeriod = 0.1;
};

//--------------------------------------
BulletData MiniFusionBolt
{
   bulletShapeName    = "paint.dts";
   explosionTag       = FusionturretXExp;

   damageClass        = 0;
   damageValue        = 0.1;
   damageType         = $EMPDamageType;

   muzzleVelocity     = 80.0;
   totalTime          = 4.0;
   liveTime           = 2.0;

   lightRange         = 3.0;
   lightColor         = { 0.25, 0.25, 1.0 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 1;
};

//--------------------------------------


BulletData RFPlasmaBullet
{
   bulletShapeName    = "fusionbolt.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.15;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 400;
   totalTime          = 2.0;
   liveTime           = 1.125;

   lightRange         = 3.0;
   lightColor         = { 1.0, 0.25, 0.25 };
   inheritedVelocityScale = 0.5;
   isVisible          = True;

   rotationPeriod = 0.1;
};


//-----------------------------------
RocketData NewPlasmaBoltX
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = TurretExp;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.8;
   damageType       = $PlasmaCannonDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 150;
   terminalVelocity = 110;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};
//--------------------------------------


RocketData PlasmaBlasterBolt
{
   bulletShapeName = "plasmabolt.dts";
   explosionTag    = PlasmaBBExp;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.2;
   damageType       = $PlasmaBlasterDamageType;

   explosionRadius  = 6.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 250;
   terminalVelocity = 300;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmaex.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};



BulletData BlazeBullet1
{
   bulletShapeName    = "plasmabolt.dts";
   explosionTag       = Blaze1Exp;

   aimDeflection      = 0;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $BlazeDamageType;
   explosionRadius    = 4.0; //the explosion is just for looks
aimDeflection      = 0.01;

   muzzleVelocity     = 50.0;
   totalTime          = 0.4;
   liveTime           = 0.3;
   lightRange         = 5.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

BulletData BlazeBullet2
{
   bulletShapeName    = "shotgunex.dts";
   explosionTag       = Blaze2Exp;

   aimDeflection      = 0;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $BlazeDamageType;
   explosionRadius    = 3.0; //the explosion is just for looks
   aimDeflection      = 0.02;

   muzzleVelocity     = 50.0;
   totalTime          = 0.4;
   liveTime           = 0.3;
   lightRange         = 5.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};



RocketData EngineBullet
{
   bulletShapeName = "bullet.dts";
   explosionTag    = mortarExp;

   collisionRadius = 0.0;
   mass            = 0.5;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 50.0;
   kickBackStrength = 100.0;

   muzzleVelocity   = 50.0;
   terminalVelocity = 51.0;
   acceleration     = 1.0;

   totalTime        = 0.1;
   liveTime         = 10.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 11;
   trailLength = 11;
   trailWidth  = 11;

   soundId = SoundDiscSpin;
};

BulletData RamjetBullet
{
   bulletShapeName    = "shotgunbolt.dts";
   explosionTag       = fireExp;

   aimDeflection      = 0;

   damageClass        = 1;
   damageValue        = 1.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 4.0; //the explosion is just for looks

   muzzleVelocity     = 50.0;
   totalTime          = 10;
   liveTime           = 10;
   lightRange         = 5.0;
   lightColor         = { 0, 0, 1 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;

   rotationPeriod = 0.1;
};

BulletData PlasmaGatBullet
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = plasmaExp;

   damageClass        = 1;
   damageValue        = 0.4;
   damageType         = $PlasGatDamageType;
   explosionRadius    = 4.0;

   muzzleVelocity     = 600.0;
   aimDeflection      = 0.001;
   totalTime          = 2.0;
   liveTime           = 1.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};

RocketData NapalmRocketShell
{
   bulletShapeName = "mortar.dts";
   explosionTag    = fire3Exp;

   mass            = 4.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.3;
   damageType       = $NapalmRDamageType;

   explosionRadius  = 4.0;
   kickBackStrength = 0.4;

   muzzleVelocity   = 600;
   terminalVelocity = 610;
   acceleration     = 1;

   totalTime        = 5.0;
   liveTime         = 6.5;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};


RocketData SAStealthBullet
{
   bulletShapeName = "plasmatrail.dts";
   explosionTag    = ArmExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 0;
   damageValue      = 0.4;
   damageType       = $StealthDamageType;
   muzzleVelocity   = 750.0;
   terminalVelocity = 750.0;
   acceleration     = 5.0;
   totalTime        = 6.0;
   liveTime         = 6.0;
   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };
   inheritedVelocityScale = 0.5;
   trailType = 2;
   trailString = "plasmatrail.dts";
   smokeDist = 20;
   soundId = SoundELFFire;
};


BulletData PlasmaShotgunBullet
{
   bulletShapeName    = "plasmatrail.dts";
   explosionTag       = PlasmaExp;

   damageClass        = 1;
   damageValue        = 0.5;
   damageType         = $PlasmaDamageType;
   explosionRadius    = 3.5;

   muzzleVelocity     = 90.0;
   aimDeflection      = 0.01;
   totalTime          = 3.0;
   liveTime           = 2.0;
   lightRange         = 3.0;
   lightColor         = { 1, 1, 0 };
   inheritedVelocityScale = 0.3;
   isVisible          = True;

   soundId = SoundJetLight;
};


//--------------------------------------




RocketData SludgeShell
{
   bulletShapeName = "Mortartrail.dts";
   explosionTag    = SludgeExp;

   collisionRadius = 0.0;
   mass            = 0.2;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $SludgeDamageType;

   explosionRadius  = 15.0;
   kickBackStrength = 0;

   muzzleVelocity   = 80.0;
   terminalVelocity = 80.0;
   acceleration     = 10.0;

   totalTime        = 100;
   liveTime         = 100;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "mortartrail.dts";
   smokeDist   = 1.8;

   soundId = SoundDiscSpin;
};

GrenadeData ShockWaveShell 
{ 
	bulletShapeName = "mortar.dts"; 
	explosionTag = EMPPulseExp; 
	collideWithOwner = True; 
	ownerGraceMS = 250; 
	collisionRadius = 0.3; 
	mass = 1.0; 
	elasticity = 0.20; 
	damageClass = 1; 
	damageValue = 0.5; 
	damageType = $EMPDamageType; 
	explosionRadius = 40; 
	kickBackStrength = 900.0; 
	maxLevelFlightDist = 275; 
	totalTime = 30.0; 
	liveTime = 0.25; 
	projSpecialTime = 0.05; 
	inheritedVelocityScale = 0.5; 
	smokeName = "Shield.dts"; 
	soundId = SoundELFFire; 
};

RocketData TTGBullet
{
   bulletShapeName = "discb.dts";
   explosionTag    = grenadeExp;

   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.0;
   damageType       = $ExplosionDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 150.0;
   terminalVelocity = 200.0;
   acceleration     = 5.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmatrail.dts";
   smokeDist   = 1.8;


   soundId = SoundDiscSpin;
};
//--------------------------------------


//--------------------------------------
RocketData GravShockBullet
{
   bulletShapeName    = "dirarrows.dts";
   explosionTag       = grenadeExp;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.75;
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 900.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 3;

   soundId = SoundDiscSpin;
};

//this is just to make it look cooler
RocketData GravShockBullet2
{
   bulletShapeName    = "rocket.dts";
   explosionTag       = LargeShockwave;
   expRandCycle       = 0;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   collisionRadius = 0.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0;       // no damage
   damageType       = $ShrapnelDamageType;

   explosionRadius  = 10.0;
   kickBackStrength = 10.0;

   muzzleVelocity   = 300.0;
   terminalVelocity = 900.0;
   acceleration     = 500.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "plasmabolt.dts";
   smokeDist   = 3;

   soundId = SoundDiscSpin;
};

RocketData RailgunBullet
{
   bulletShapeName = "paint.dts";
   explosionTag       = bulletExp0;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 0.20;
   damageType       = $BulletDamageType;

   aimDeflection    = 0;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 350.0;
   terminalVelocity = 400.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 1.0, 0.4 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 3;
   trailLength = 3;
   trailWidth  = 3;

   soundId = SoundDiscSpin;
};

RocketData ColossusBullet
{
   bulletShapeName = "discb.dts";
   explosionTag       = rocketExp;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 0;       // 0 impact, 1, radius
   damageValue      = 2.0;
   damageType       = $ColossusDamageType;

   aimDeflection    = 0.025;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 350.0;
   terminalVelocity = 400.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 15.0;
   lightColor       = { 1.0, 0.0, 0.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 4000;
   trailWidth  = 3.0;

   soundId = SoundDiscSpin;
};

RocketData ArwingBullet
{
   bulletShapeName = "rocket.dts";
   explosionTag    = turretExp;

   collisionRadius = 0.0;
   mass            = 1.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.15;
   damageType       = $ArwingDamageType;

   aimDeflection    = 0.0;

   explosionRadius  = 7.5;
   kickBackStrength = 50.0;

   muzzleVelocity   = 100.0;
   terminalVelocity = 120.0;
   acceleration     = 10.0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 1.0, 0.4 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 30;
   trailWidth  = 0.75;

   soundId = SoundDiscSpin;
};

//--------------------------------------

GrenadeData NitroShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.25;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $NitroDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 200;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "laserhit.dts";
};

GrenadeData Smoker
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = SmokerExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.25;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 200;
   totalTime          = 30.0;    // special meaning for grenades...
   liveTime           = 1.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

GrenadeData PGBullet
{
   bulletShapeName    = "enbolt.dts";
   explosionTag       = grenadeExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.2;
   mass               = 1.0;
   elasticity         = 0.45;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $ShrapnelDamageType;

   explosionRadius    = 15;
   kickBackStrength   = 150.0;
   maxLevelFlightDist = 150;
   totalTime          = 20.0;    // special meaning for grenades...
   liveTime           = 15.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;

   smokeName              = "smoke.dts";
};

//--------------------------------------





GrenadeData FireMortarShell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $FireMDamageType;

   explosionRadius    = 24.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 525;
   totalTime          = 30.0;
   liveTime           = 1.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

//--------------------------------------
GrenadeData MortarTurretShell
{
   bulletShapeName    = "mortartrail.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 400;
   collisionRadius    = 1.0;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.32;
   damageType         = $BioShrapnelDamageType;

   explosionRadius    = 30.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 400;
   totalTime          = 1000.0;
   liveTime           = 2.0;
   projSpecialTime    = 0.05;

   inheritedVelocityScale = 0.5;
   smokeName              = "plastrail.dts";
};

GrenadeData ContactMortarShell
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 2.0;
   damageType         = $ContactMDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 0.001;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "snowplume.dts";
};
   


GrenadeData ThermonuclearBullet
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 7.5;
   elasticity         = 0.05;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 200.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 200.0;
   kickBackStrength   = 1000.0;
   maxLevelFlightDist = 500;
   totalTime          = 500.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName	    = "smoke.dts";
   smokeDist          = 0.01;
};


GrenadeData Bombershell
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = mortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 1.0;
   damageType         = $MortarDamageType;

   explosionRadius    = 20.0;
   kickBackStrength   = 250.0;
   maxLevelFlightDist = 10;
   totalTime          = 30.0;
   liveTime           = 0.1;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "shotgunex.dts";
};

GrenadeData RepairShellBullet
{
   bulletShapeName    = "discb.dts";
   explosionTag       = rocketExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 0.2;
   elasticity         = 0.1;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = -100;
   damageType         = $MortarDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 50;
   maxLevelFlightDist = 275;
   totalTime          = 30.0;
   liveTime           = 3.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "laserhit.dts";
};

GrenadeData TimeBombShell1
{
   bulletShapeName    = "mortar.dts";
   explosionTag       = TimeBombExp1;
   collideWithOwner   = false;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 30.0;
   damageType         = $TimeBombDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 100;
   totalTime          = 50.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmatrail.dts";
};

GrenadeData TimeBombShell2
{
   bulletShapeName    = "laserhit.dts";
   explosionTag       = TimeBombExp2;
   collideWithOwner   = false;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.0;
   damageType         = $TimeBombDamageType;

   explosionRadius    = 10.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 100;
   totalTime          = 50.0;
   liveTime           = 10.0;
   projSpecialTime    = 0.01;
 
   inheritedVelocityScale = 0.5;
   smokeName              = "chainspk.dts";
};

GrenadeData Suicidebomb2
{
   bulletShapeName    = "generator_p.dts";
   explosionTag       = LargeShockwave;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 2.0;
   mass               = 5.0;
   elasticity         = 0.20;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 45.0;
   damageType         = $EnergyDamageType2;

   explosionRadius    = 20.0;
   kickBackStrength   = 500.0;
   maxLevelFlightDist = 100;
   totalTime          = 50.0;
   liveTime           = 5.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;
   smokeName              = "plasmabolt.dts";
};

GrenadeData AirRaid1
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $RaidDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 250;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "rsmoke.dts";
};
//--------------------------------------
GrenadeData AirRaid2
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $RaidDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 300;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "rsmoke.dts";
};
//--------------------------------------
GrenadeData AirRaid3
{
   bulletShapeName    = "grenade.dts";
   explosionTag       = MortarExp;
   collideWithOwner   = True;
   ownerGraceMS       = 250;
   collisionRadius    = 0.3;
   mass               = 5.0;
   elasticity         = 0.3;

   damageClass        = 1;       // 0 impact, 1, radius
   damageValue        = 0.4;
   damageType         = $RaidDamageType;

   explosionRadius    = 3;
   kickBackStrength   = 40;
   maxLevelFlightDist = 350;
   totalTime          = 30.0;
   liveTime           = 0.0;
   projSpecialTime    = 0.01;

   inheritedVelocityScale = 0.5;

   smokeName              = "rsmoke.dts";
};

//--------------------------------------
RocketData FlierRocket
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 9.5;
   kickBackStrength = 250.0;
   muzzleVelocity   = 65.0;
   terminalVelocity = 80.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "rsmoke.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData CannonBullet
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $CannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 500.0;
   muzzleVelocity   = 100.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "enex.dts";
   smokeDist   = 1;

   soundId = SoundJetHeavy;
};

LaserData AnarchyLaser
{
   laserBitmapName   = "laserpulse.bmp";
   hitname           = "laserhit.dts";
   damageConversion  = 0.7;
   baseDamageType    = $AnarchyCannonDamageType;
   beamTime          = 2.2;
   lightRange        = 2.0;
   lightColor        = { 0.0, 0.0, 50.25 };
   detachFromShooter = true;
   hitSoundId        = Soundlaseridle;
};



//--------------------------------------
RocketData AnarchyRocket1
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $AnarchyCannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = 500.0;
   muzzleVelocity   = 600.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "Plasmabolt.dts";
   smokeDist   = 1.3;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData AnarchyRocket2
{
   bulletShapeName  = "mortar.dts";
   explosionTag     = debrisExpLarge;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0;
   damageType       = $AnarchyCannonDamageType;

   explosionRadius  = 10.5;
   kickBackStrength = -500.0;
   muzzleVelocity   = 600.0;
   terminalVelocity = 600.0;
   acceleration     = 10.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 2;                // smoke trail
   trailString = "shield.dts";
   smokeDist   = 1.8;

   soundId = SoundJetHeavy;
};
//-----------------------
// minies
//-----------------------
TargetLaserData SXH5000Laser
{
   laserBitmapName   = "LaserPulse.bmp";
   damageConversion  = 0.0;
   baseDamageType    = 0;
   lightRange        = 0;
   lightColor        = { 0, 0, 0 };
   detachFromShooter = false;
};



//------------------------
RocketData GCannonBullet
{
   bulletShapeName  = "rocket.dts";
   explosionTag     = rocketExp;
   collisionRadius  = 0.0;
   mass             = 10.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 1.5;
   damageType       = $MissileDamageType;

   explosionRadius  = 8;
   kickBackStrength = 250.0;
   muzzleVelocity   = 200.0;
   terminalVelocity = 210.0;
   acceleration     = 5.0;
   totalTime        = 10.0;
   liveTime         = 11.0;
   lightRange       = 5.0;
   lightColor       = { 1.0, 0.7, 0.5 };
   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 0;
//   trailString = "laserhit.dts";
//   smokeDist   = 0.01;

   soundId = SoundJetHeavy;
};

//--------------------------------------
RocketData SalvoRocket 
{ 
   bulletShapeName = "rocket.dts"; 
   explosionTag = SalvorocketExp; 
   collisionRadius = 0; 
   mass = 2; 
   damageClass = 1; 
   damageValue = 5; 
   damageType = $SalvoDamageType; 
   explosionRadius = 15; 
   kickBackStrength = 250; 
   muzzleVelocity = 150; 
   terminalVelocity = 225; 
   acceleration = 25; 
   totalTime = 8; 
   liveTime = 1; 
   lightRange = 1; 
   lightColor = { 1, 1, 1 }; 
   inheritedVelocityScale = 0.25; 
   trailType = 2; 
   trailString = "plastrail.dts"; 
   smokeDist = 1; 
   soundId = SoundJetHeavy; 
};

//--------------------------------------
SeekingMissileData TurretMissile
{
   bulletShapeName = "discb.dts";
   explosionTag    = plasmaExp;
   collisionRadius = 0.0;
   mass            = 2.0;

   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.5;
   damageType       = $MissileDamageType;
   explosionRadius  = 9.5;
   kickBackStrength = 175.0;

   muzzleVelocity    = 72.0;
   totalTime         = 10;
   liveTime          = 10;
   seekingTurningRadius    = 9;
   nonSeekingTurningRadius = 75.0;
   proximityDist     = 1.5;
   smokeDist         = 1.75;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   soundId = SoundJetHeavy;
};

function SeekingMissile::updateTargetPercentage(%target)
{
   return GameBase::virtual(%target, "getHeatFactor");
}

//-------------------------------------- 
// These are kinda oddball dat's
// the lasers really don't fit into
// the typical projectile catagories...
//--------------------------------------
TargetLaserData targetLaser
{
   laserBitmapName   = "paintPulse.bmp";

   damageConversion  = 0.0;
   baseDamageType    = 0;

   lightRange        = 2.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
};


//--------------------------------------


//--------------------------------------
LaserData GRLaser
{
   laserBitmapName   = "paintpulse.bmp";
   hitName           = "shockwave_large.dts";

   damageConversion  = 0.55;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.10;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundPlasmaTurretOn;
};

LaserData MeltBeam
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "Plasmabolt.dts";

   damageConversion  = 0.70;
   baseDamageType    = $MeltLaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundBeaconUse;
};

LaserData MeltBeam2
{
   laserBitmapName   = "plasmabolt.bmp";
   hitName           = "Plasmabolt.dts";

   damageConversion  = 0.0;
   baseDamageType    = $MeltLaserDamageType;

   beamTime          = 0.5;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = true;
   hitSoundId        = SoundBeaconUse;
};

LaserData LaserTrtLaser 
{ 
        laserBitmapName = "laserpulse.bmp";
        hitName = "laserhit.dts";
        damageConversion = 0.09;
        baseDamageType = $LaserDamageType;
        beamTime = 0.08;
        //lightRange = 2;
        //lightColor = { 0.4, 0, 0.6 };
        detachFromShooter = true;
        hitSoundId = SoundBeaconUse;
};

LaserData CutterBullet
{
   laserBitmapName   = "pulse.bmp";
   hitName           = "laserhit.dts";

   damageConversion = 0.01;
   

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 0.0, 7.0, 1.0 };

   detachFromShooter = false;
   //hitSoundId        = 0;
};

LaserData SMLaser
{
   laserBitmapName   = "LaserPulse.bmp";
   hitName           = "PlasmaEx.dts";

   damageConversion  = 0.02;
   baseDamageType    = $laserDamageType;

   beamTime          = 0.4;

   lightRange        = 2.0;
   lightColor        = { 1.0, 0.25, 0.25 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LaserData GLaserBullet
{
   laserBitmapName   = "shex03.bmp";
   hitName           = "shotgunbolt.dts"; //make it like the disk explosion

   damageConversion  = 0.060;
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.1;

   lightRange        = 2.0;
   lightColor        = { 0, 0, 0 };

   detachFromShooter = false;
   hitSoundId        = SoundLaserHit;
};

LightningData GrapBeam
{
   bitmapName       = "zap01.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 35.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.0;
   energyDrainPerSec = 1000.0;
   segmentDivisions = 1;
   numSegments      = 5;
   beamWidth        = 0.5;//0.125//075;

   updateTime   = 120;
   skipPercent  = 0.25;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.85, 0.85, 0.15 };
};


LaserData AntimatterLaserBullet
{
   laserBitmapName   = "rlite00.bmp";
   hitName           = "laserhit.dts";

   damageValue = 0.30;

   baseDamageType    = $LaserDamageType;

   beamTime          = 0.2;

   lightRange        = 5;
   lightColor        = { 0.0, 0.0, 1.0 };

   detachFromShooter = false;
   //hitSoundId        = 0;
};
//++++++++++++++++++++++++++++++++++++++

//++++++++++++++++++++++++++++++++++++++

LightningData PlasmaBeam
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.50;
   energyDrainPerSec = 50.0;
   segmentDivisions = 3;
   numSegments      = 3;
   beamWidth        = 0.30;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

LightningData lightningCharge
{
   bitmapName       = "plasmabolt.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 40.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.50;
   energyDrainPerSec = 50.0;
   segmentDivisions = 8;
   numSegments      = 2;
   beamWidth        = 0.12;//075;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

LightningData EMPBullet
{
   bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 10.0;
   coneAngle        = 5.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 30.0;
   segmentDivisions = 1;
   numSegments      = 2;
   beamWidth        = 0.15;//0750;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};


LightningData TerretBeam
{
   bitmapName       = "fx_lensflare_2.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 60.0;
   coneAngle        = 5.0;
   damagePerSec      = 0.25;
   energyDrainPerSec = 80.0;
   segmentDivisions = 1;
   numSegments      = 2;
   beamWidth        = 0.15;//0750;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 1.25, 1.25, 1.85 };

   soundId = SoundELFFire;
};

RepairEffectData RepairBullet
{
   bitmapName       = "fx_lensflare_3.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 60.0;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepairing...");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range Max Range 35.5m");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 60.0;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not in need of medical attention");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being Patched by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Patching " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Complete.");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Completed");
			}
			else {
				Client::sendMessage(%client,0,"Repair Interupted");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}

LaserData WatchdogLaser
{
   laserBitmapName   = "paintPulse.bmp";
   hitName           = 0;

   damageConversion  = 0; 
   baseDamageType    = $LaserDamageType;

   beamTime          = 0.8;

   lightRange        = 10.0;
   lightColor        = { 0.25, 1.0, 0.25 };

   detachFromShooter = false;
   //hitSoundId        = 0;
};

LightningData turretCharge
{
   bitmapName       = "paintpulse.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 35.0;
   damagePerSec      = 0.06;
   energyDrainPerSec = 100.0;
   segmentDivisions = 4;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}


RepairEffectData RepairBolt
{
   bitmapName       = "eflsh5.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);

	if (%target == %player) {
	   %player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 100.0;
			%player.repairTarget = %player;
			Client::sendMessage(%client, 0, "AutoRepair On");
		}
		else {
			Client::sendMessage(%client,0,"Nothing in range");
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
	}
	else {
      %player.repairTarget = %target;
		%player.repairRate   = 0.1;
		if (getObjectType(%player.repairTarget) == "Player") {
			%rclient = Player::getClient(%player.repairTarget);
			%name = Client::getName(%rclient);
		}
		else { 
			%name = GameBase::getMapName(%target);
			if(%name == "") {
				%name = (GameBase::getDataName(%player.repairTarget)).description;
			}
		}
		if (GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return;
		}
		if (getObjectType(%player.repairTarget) == "Player") {
			Client::sendMessage(%rclient,0,"Being repaired by " @ Client::getName(%client));
		}
		Client::sendMessage(%client,0,"Repairing " @ %name);
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function RepairBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if (%object == %player) {
			Client::sendMessage(%client,0,"AutoRepair Off");
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Client::sendMessage(%client,0,"Repair Done");
			}
			else {
				Client::sendMessage(%client,0,"Repair Stopped");
			}
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
      if (%rate < 0)
         %rate = 0;
      
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function RepairBolt::checkDone(%this, %player)
{
	if (Player::isTriggered(%player,$WeaponSlot) && 
       Player::getMountedItem(%player,$WeaponSlot) == RepairGun &&
		 %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if (%object == %player) {
			if (GameBase::getDamageLevel(%player) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
		else {
			if (GameBase::getDamageLevel(%object) == 0) {
				Player::trigger(%player,$WeaponSlot,false);
				return;
			}
		}
	}
}
//===================
//Field Repair
//===================
RepairEffectData ToolBolt
{
   bitmapName       = "lightningNew.bmp";
   boltLength       = 35.5;
   segmentDivisions = 4;
   beamWidth        = 0.15;

   updateTime   = 45;
   skipPercent  = 0.6;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.0, 0.0, 0.8 };
};

function ToolBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	%player.repairTarget = %target;
	if(getObjectType(%target) == "Player")
		return false;
	if(getObjectType(%player.repairTarget) != "Player") {
		%player.repairRate = 100.0;
		%name = GameBase::getMapName(%target);
		if(%name == "")
			%name = (GameBase::getDataName(%player.repairTarget)).description;
		if(GameBase::getDamageLevel(%player.repairTarget) == 0) {
			Client::sendMessage(%client,0,%name @ " is not damaged");
			Player::trigger(%player,$WeaponSlot,false);
			%player.repairTarget = -1;
			return false;
		}
	}
	%rate = GameBase::getAutoRepairRate(%player.repairTarget) + %player.repairRate;
	GameBase::setAutoRepairRate(%player.repairTarget,%rate);
}

function ToolBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if(getObjectType(%object) == "Player")
		return false;
	if(%object != -1) {
		%client = Player::getClient(%player);
		if(getObjectType(%object) != "Player") {
			if(GameBase::getDamageLevel(%object) == 0)
				Client::sendMessage(%client,0,"Fixing Done");
			else
				Client::sendMessage(%client,0,"Fixing Stopped");
		}
		%rate = GameBase::getAutoRepairRate(%object) - %player.repairRate;
		if(%rate < 0)
			%rate = 0;
		GameBase::setAutoRepairRate(%object,%rate);
	}
}

function ToolBolt::checkDone(%this,%player)
{
	if(getObjectType(%player.repairTarget) == "Player")
		return false;
	if(Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == TB && %player.repairTarget != -1) {
		%object = %player.repairTarget;
		if(getObjectType(%object) != "Player" && GameBase::getDamageLevel(%object) == 0) {
			Player::trigger(%player,$WeaponSlot,false);
			return;
		}
	}
}

//----------------------------------------------------------------
//Cluster Mortar - based on Tricon Mine Launcher
//----------------------------------------------------------------

function ScatterBomb::onAdd(%this)
{
	schedule("DeployBombsA(" @ %this @ " , 2);",1.5,%this);
}

function DeployBombsA(%this, %count) 
{
	if(%count && %this)
	{

		%obj = newObject("","Mine","Bomb1");
		addToSet("MissionCleanup", %obj);
         GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,-1.0,false);	

		%obj = newObject("","Mine","Bomb2");
		addToSet("MissionCleanup", %obj);
         GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,-8.0,false);

		schedule("DeployBombsB(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

function DeployBombsB(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Bomb3");
		addToSet("MissionCleanup", %obj);
         GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,1.0,false);

		%obj = newObject("","Mine","Bomb4");
		addToSet("MissionCleanup", %obj);
         GameBase::setTeam(%obj, GameBase::getTeam(%this));
		GameBase::throw(%obj,%this,8.0,false);	

		%count --;
		schedule("DeployBombsA(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}