echo("Loading Screaming Fist Version");
# Damage Types
#
//*************************************************************************************************************
// SF Addition - Begin - 7/18/99 - 10:40 PM
//*************************************************************************************************************
$ImpactDamageType				= -1;
$LandingDamageType				= 0;
$LightningDamageType			= 1;
$ExplosionDamageType			= 2;
$ShrapnelDamageType				= 3;
$CrushDamageType				= 4;
$DebrisDamageType				= 5;
$MissileDamageType				= 6;
$MineDamageType					= 7;
$MinigunDamageType				= 8;
$AssRifleDamageType				= 9;
$SniperRifleDamageType			= 10;
$OspreyTurretDamageType			= 11;
$FlamerDamageType				= 12;
$GlockDamageType				= 13;
$LightningDamageType			= 14;
$SilencedAssRifleDamageType		= 15;
$SilencedGlockDamageType		= 16;
$MAWAssRifleDamageType			= 17;
$MAWIncendiaryRifleDamageType	= 18;
$MAWGrenadeLauncherDamageType	= 19;
$BloodDamageType				= 20;
$FBWMissleDamageType			= 21;
$ShotgunDamageType 				= 22;
$FlashDamageType				= 23;
$ComancheBulletDamageType		= 24;
$ComancheImpactDamageType		= 25;
$OspreyImpactDamageType			= 26;
$BigCannonDamageType			= 27;
$HowitzerDamageType				= 28;
$HomingFlareDamageType			= 29;

function ShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	if(%rand <= 0.5)
	{
		%rot = GameBase::getRotation(%this);
		%startpos = Vector::getFromRot(%rot, -0.35);
		%rot = Vector::add(%rot, %normalrot);
		%casingpos = Vector::getFromRot(%rot, 1.0);
		%casingpos = Vector::add(%casingpos, %startpos);
		
		%rotx = getWord(%rot, 0) - %rand;
		%roty = getWord(%rot, 1);
		%rotz = getWord(%rot, 2) - 0.785;
		%newrot = %rotx@" "@%roty@" "@%rotz;
		
		%pos = GameBase::getPosition(%this);
		%pos = Vector::add(%pos, %casingpos);
		
		%this = newObject("","Mine","shell");
		addToSet("MissionCleanup", %this);
		GameBase::setPosition(%this, %pos);
		GameBase::setRotation(%this, %newrot);
		
		%strength = 0.2;
		%obj = newObject("","Mine","shell");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,%strength,false);
		
		deleteObject(%this);
	}
}

function AssRifleShellEject(%this)
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
		
		%this = newObject("","Mine","shell");
		addToSet("MissionCleanup", %this);
		GameBase::setPosition(%this, %pos);
		GameBase::setRotation(%this, %newrot);
		
		%strength = 0.2;
		%obj = newObject("","Mine","shell");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,%strength,false);
		
		deleteObject(%this);
	}
}

function ShotgunShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	%rot = GameBase::getRotation(%this);
	%startpos = Vector::getFromRot(%rot, -0.3);
	%rot = Vector::add(%rot, %normalrot);
	%casingpos = Vector::getFromRot(%rot, 1.0);
	%casingpos = Vector::add(%casingpos, %startpos);
	
	%rotx = getWord(%rot, 0) - %rand;
	%roty = getWord(%rot, 1);
	%rotz = getWord(%rot, 2) - 0.785;
	%newrot = %rotx@" "@%roty@" "@%rotz;
	
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, %casingpos);
	
	%this = newObject("","Mine","shotgunshell");
	addToSet("MissionCleanup", %this);
	GameBase::setPosition(%this, %pos);
	GameBase::setRotation(%this, %newrot);
	
	%strength = 0.2;
	%obj = newObject("","Mine","shotgunshell");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,%strength,false);
	
	deleteObject(%this);
}

function BigShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	%rot = GameBase::getRotation(%this);
	%startpos = Vector::getFromRot(%rot, -0.7);
	%rot = Vector::add(%rot, %normalrot);
	%casingpos = Vector::getFromRot(%rot, 1.0);
	%casingpos = Vector::add(%casingpos, %startpos);
	
	%rotx = getWord(%rot, 0) - %rand;
	%roty = getWord(%rot, 1);
	%rotz = getWord(%rot, 2) - 0.785;
	%newrot = %rotx@" "@%roty@" "@%rotz;
	
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, %casingpos);
	
	%this = newObject("","Mine","bigshell");
	addToSet("MissionCleanup", %this);
	GameBase::setPosition(%this, %pos);
	GameBase::setRotation(%this, %newrot);
	
	%strength = 0.3;
	%obj = newObject("","Mine","bigshell");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,%strength,false);
	
	deleteObject(%this);
}

function TurretShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	%rot = GameBase::getRotation(%this);
	%startpos = Vector::getFromRot(%rot, -0.3);
	%rot = Vector::add(%rot, %normalrot);
	%casingpos = Vector::getFromRot(%rot, 1.0);
	%casingpos = Vector::add(%casingpos, %startpos);
	
	%rotx = getWord(%rot, 0) - %rand;
	%roty = getWord(%rot, 1);
	%rotz = getWord(%rot, 2) - 0.785;
	%newrot = %rotx@" "@%roty@" "@%rotz;
	
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, %casingpos);
	
	%this = newObject("","Mine","turretshell");
	addToSet("MissionCleanup", %this);
	GameBase::setPosition(%this, %pos);
	GameBase::setRotation(%this, %newrot);
	
	%strength = 0.3;
	%obj = newObject("","Mine","turretshell");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,%strength,false);
	
	deleteObject(%this);
}

function bigTurretShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	%rot = GameBase::getRotation(%this);
	%startpos = Vector::getFromRot(%rot, -0.3);
	%rot = Vector::add(%rot, %normalrot);
	%casingpos = Vector::getFromRot(%rot, 1.0);
	%casingpos = Vector::add(%casingpos, %startpos);
	
	%rotx = getWord(%rot, 0) - %rand;
	%roty = getWord(%rot, 1);
	%rotz = getWord(%rot, 2) - 0.785;
	%newrot = %rotx@" "@%roty@" "@%rotz;
	
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, %casingpos);
	
	%this = newObject("","Mine","bigturretshell");
	addToSet("MissionCleanup", %this);
	GameBase::setPosition(%this, %pos);
	GameBase::setRotation(%this, %newrot);
	
	%strength = 0.3;
	%obj = newObject("","Mine","bigturretshell");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,%strength,false);
	
	deleteObject(%this);
}

function mortarTurretShellEject(%this)
{
	%normalrot = "0 0 -0.785";
	%rand = getRandom();
	%rot = GameBase::getRotation(%this);
	%startpos = Vector::getFromRot(%rot, -0.3);
	%rot = Vector::add(%rot, %normalrot);
	%casingpos = Vector::getFromRot(%rot, 1.0);
	%casingpos = Vector::add(%casingpos, %startpos);
	
	%rotx = getWord(%rot, 0) - %rand;
	%roty = getWord(%rot, 1);
	%rotz = getWord(%rot, 2) - 0.785;
	%newrot = %rotx@" "@%roty@" "@%rotz;
	
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos, %casingpos);
	
	%this = newObject("","Mine","mortarshell");
	addToSet("MissionCleanup", %this);
	GameBase::setPosition(%this, %pos);
	GameBase::setRotation(%this, %newrot);
	
	%strength = 0.3;
	%obj = newObject("","Mine","mortarshell");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,%strength,false);
	
	deleteObject(%this);
}

//----------------------------------------

BulletData ShotGunBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.03;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.09;
	damageType         = $ShotgunDamageType;
	
	aimDeflection      = 0.045;
	muzzleVelocity     = 450.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//----------------------------------------

BulletData GlockBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $GlockDamageType;
	
	aimDeflection      = 0.006;
	muzzleVelocity     = 325.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//----------------------------------------

BulletData InvisGlockBullet
{
	bulletShapeName    = "";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $GlockDamageType;
	
	aimDeflection      = 0.006;
	muzzleVelocity     = 325.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 0.0;
	tracerLength       = 0;
};

//----------------------------------------

BulletData SilencedGlockBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $SilencedGlockDamageType;
	
	aimDeflection      = 0.006;
	muzzleVelocity     = 225.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//----------------------------------------

BulletData InvisSilencedGlockBullet
{
	bulletShapeName    = "";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $SilencedGlockDamageType;
	
	aimDeflection      = 0.006;
	muzzleVelocity     = 225.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 0.0;
	tracerLength       = 0;
};

//---------------------------------------------------------

BulletData AssRifleBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $AssRifleDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//---------------------------------------------------------

BulletData InvisAssRifleBullet
{
	bulletShapeName    = "";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $AssRifleDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 0.0;
	tracerLength       = 0;
};

//----------------------------------------------------------

BulletData SilencedAssRifleBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $SilencedAssRifleDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 275.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//----------------------------------------------------------

BulletData InvisSilencedAssRifleBullet
{
	bulletShapeName    = "";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $SilencedAssRifleDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 275.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 0.0;
	tracerLength       = 0;
};

//-------------------------------------------------------

BulletData MinigunClip
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.1;
	damageType         = $MinigunDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = false;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//-------------------------------------------------------

BulletData InvisMinigunClip
{
	bulletShapeName    = "";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.1;
	damageType         = $MinigunDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = false;
	
	tracerPercentage   = 0.0;
	tracerLength       = 0;
};

//----------------------------------------------------

RocketData SniperRifleBullet
{
	bulletShapeName  = "";
	explosionTag     = bulletExp0;
	collisionRadius  = 0.0;
	mass             = 2.0;
	
	damageClass      = 0;       // 0 impact, 1, radius
	damageValue      = 0.5;     // 8 normal
	damageType       = $SniperRifleDamageType;
	
	explosionRadius  = 0.0;
	kickBackStrength = 0.0;
	muzzleVelocity   = 2000.0;
	terminalVelocity = 2000.0;
	acceleration     = 0;
	totalTime        = 15.0;
	liveTime         = 16.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 1.0;
	
	trailType   = 2;                // smoke trail
	trailString = "rsmoke.dts";
	smokeDist   = 9.9;
	
	soundId = SoundJetHeavy;
};

function SniperRifleBullet::onAdd(%this)
{
	BigShellEject(%this);
}

//-----------------------------------------------------

RocketData StandardRocket
{
	bulletShapeName  = "rocket.dts";
	explosionTag     = rocketExp;
	collisionRadius  = 0.0;
	mass             = 2.0;
	
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 1.0;
	damageType       = $MissileDamageType;
	
	explosionRadius  = 16.0;
	kickBackStrength = 250.0;
	muzzleVelocity   = 65.0;
	terminalVelocity = 240.0;
	acceleration     = 8.0;
	totalTime        = 15.0;
	liveTime         = 16.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	
	// rocket specific
	trailType   = 2;                // smoke trail
	trailString = "rsmoke.dts";
	smokeDist   = 1.8;
	
	soundId = SoundJetHeavy;
};

//-----------------------------------------------------------

BulletData InvisFBWRocket
{
	bulletShapeName  = "incenbullet.dts";
	explosionTag     = debrisBigIncenExp;
	mass             = 0.1;
	
	damageClass      = 1;       
	damageValue      = 0.0;
	damageType       = $MAWIncendiaryRifleDamageType;
	aimDeflection      = 0.0;
	kickBackStrength = 0.1;
	muzzleVelocity   = 0.1;
	totalTime        = 0.01;
	liveTime         = 0.01;
	inheritedVelocityScale = 1.0;
	
	soundId = NoSound;
};

// BEGIN ADDED CODE
function FBWOutOfFuel(%fbw) {
	%cl = GameBase::getControlClient(%fbw);
	Vehicle::dismount(%fbw, "0 0 0");
	remoteEval(%cl, BP, "<jc><f0>Rocket Out of Fuel", 2);
}
function FBWLowFuel(%fbw) {
	%cl = GameBase::getControlClient(%fbw);
	remoteEval(%cl, BP, "<jc><f0>Rocket Low On Fuel", 3);
}
// END ADDED CODE

function InvisFBWRocket::onAdd(%this)
{
	%rot = GameBase::getRotation(%this);
	%pos = GameBase::getPosition(%this);
	%client = $clientID;
	$clientID = 0;
	
	//Spawn Rocket
	%obj = newObject("","Flier","FBWRocket",true);
	addToSet("MissionCleanup", %obj);
	$FBWClientID[%obj] = %client;
	GameBase::setTeam(%obj, GameBase::getTeam(%client));
	//echo("$FBWClientID[%obj] - Proj onAdd ",$FBWClientID[%obj]);
	//Position
	GameBase::setPosition(%obj, %pos);
	GameBase::setRotation(%obj, %rot);
	//Set Controls
	Client::setControlObject(%client,%obj);
	
	// BEGIN ADDED CODE
	schedule("FBWLowFuel("@%obj@");", 12, %obj);
	schedule("FBWOutOfFuel("@%obj@");", 15, %obj);
	// END ADDED CODE
}

//-----------------------------------------------------------

BulletData InvisFlyingBug
{
	bulletShapeName  = "incenbullet.dts";
	explosionTag     = debrisBigIncenExp;
	mass             = 0.1;
	
	damageClass      = 1;       
	damageValue      = 0.0;
	damageType       = $MAWIncendiaryRifleDamageType;
	aimDeflection      = 0.0;
	kickBackStrength = 0.1;
	muzzleVelocity   = 0.1;
	totalTime        = 0.01;
	liveTime         = 0.01;
	inheritedVelocityScale = 1.0;
	
	soundId = NoSound;
};

function InvisFlyingBug::onAdd(%this)
{
	%rot = GameBase::getRotation(%this);
	%pos = GameBase::getPosition(%this);
	%spawnPos = Vector::getFromRot(%rot, 2.0);
	%pos = Vector::add(%pos, %spawnPos);
	
	%client = $FlyClientID;
	$FlyClientID = 0;
	
	//Spawn Flying Bug Camera
	%obj = newObject("","Flier","FlyingBug",true);
	addToSet("MissionCleanup", %obj);
	$FlyingBugClient[%obj] = %client;
	GameBase::setTeam(%obj, GameBase::getTeam(%client));
	//echo("$FlyingBugClient[%obj] - Proj onAdd ",$FlyingBugClient[%obj]);
	//Position
	GameBase::setPosition(%obj, %pos);
	GameBase::setRotation(%obj, %rot);
	//Set Controls
	Client::setControlObject(%client,%obj);
}

//-------------------------------------------------------------

BulletData MAWAssRifleBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $MAWAssRifleDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//--------------------------------------

BulletData InvisMAWAssRifleBullet
{
	bulletShapeName    = "";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.15;
	damageType         = $MAWAssRifleDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 0.0;
	tracerLength       = 0;
};

//--------------------------------------

GrenadeData MAWIncendiaryRifleShell
{
	bulletShapeName  = "incenbullet.dts";
	explosionTag     = debrisBigIncenExp;
	collideWithOwner   = True;
	ownerGraceMS       = 800;
	collisionRadius    = 0.2;
	mass               = 0.5;
	elasticity         = 0.20;
	
	damageClass      = 1;       
	damageValue      = 0.35;
	damageType       = $MAWIncendiaryRifleDamageType;
	
	explosionRadius    = 5;
	kickBackStrength   = 150.0;
	maxLevelFlightDist = 800;
	totalTime          = 0.7;    // special meaning for grenades...
	liveTime           = 0.7;
	projSpecialTime    = 0.01;
	
	inheritedVelocityScale = 1.0;
	
	smokeName   = "breath.dts";
	smokeDist   = 0.5;
	
	soundId = SoundJetHeavy;
};

function MAWExplode(%this)
{
	
	//Client stuff
	%client = $IncenClient[%this];
	$IncenClient[%this] = "";
	
	//Team stuff
	%team = GameBase::getTeam(%client);
	//echo("client - onAdd ", %client);
	//echo("team - onAdd ",%team);
	
	//Rotation of original
	%rot = GameBase::getRotation(%this);
	
	//Position of Original
	%pos = GameBase::getPosition(%this);
	
	%this = newObject("","Mine","IncenDebris");
	addToSet("MissionCleanup", %this);
	
	//Rotation
	%vect[0]= 0.75;
	%vect[1]= getWord(%rot, 1);
	%vect[2]= getWord(%rot, 2) + 0.2;
	GameBase::setRotation (%this,%vect[0]@" "@%vect[1]@" "@%vect[2]);
	
	//Position
	%posx = getWord(%pos, 0);
	%posy = getWord(%pos, 1);
	%posz = getWord(%pos, 2) + 0.25;
	%Newpos = %posx@" "@%posy@" "@%posz;
	if( !GameBase::testPosition(%this, %Newpos))
		%posz = getWord(%pos, 2) - 0.25;
	GameBase::setPosition(%this, %Newpos);
	
	//Obj 1
	%vect[2]= getWord(%rot, 2);
	%obj = newObject("","Mine","IncenDebris");
	addToSet("MissionCleanup", %obj);
	$IncenDebrisClient[%obj] = %client;
	GameBase::setRotation (%this,%vect[0] @ " " @ %vect[1] @ " " @ %vect[2]);
	GameBase::throw(%obj,%this,0.2,false);
	
	//Obj 2
	%vect[2]= getWord(%rot, 2)+ 0.3;
	%obj = newObject("","Mine","IncenDebris");
	addToSet("MissionCleanup", %obj);
	$IncenDebrisClient[%obj] = %client;
	GameBase::setRotation (%this,%vect[0] @ " " @ %vect[1] @ " " @ %vect[2]);
	GameBase::throw(%obj,%this,0.4,false);
	
	//Obj 3
	%vect[2]= getWord(%rot, 2) - 0.3;
	%obj = newObject("","Mine","IncenDebris");
	addToSet("MissionCleanup", %obj);
	$IncenDebrisClient[%obj] = %client;
	GameBase::setRotation (%this,%vect[0] @ " " @ %vect[1] @ " " @ %vect[2]);
	GameBase::throw(%obj,%this,0.4,false);
	
	//obj 4
	%vect[2]= getWord(%rot, 2) - 0.3;
	%obj = newObject("","Mine","IncenDebris");
	addToSet("MissionCleanup", %obj);
	$IncenDebrisClient[%obj] = %client;
	GameBase::setRotation (%this,%vect[0] @ " " @ %vect[1] @ " " @ %vect[2]);
	GameBase::throw(%obj,%this,0.6,false);
	
	//obj 5
	%vect[2]= getWord(%rot, 2)+ 0.3;
	%obj = newObject("","Mine","IncenDebris");
	addToSet("MissionCleanup", %obj);
	$IncenDebrisClient[%obj] = %client;
	GameBase::setRotation (%this,%vect[0] @ " " @ %vect[1] @ " " @ %vect[2]);
	GameBase::throw(%obj,%this,0.6,false);
	
	//obj 6
	%vect[2]= getWord(%rot, 2);
	%obj = newObject("","Mine","IncenDebris");
	addToSet("MissionCleanup", %obj);
	$IncenDebrisClient[%obj] = %client;
	GameBase::setRotation (%this,%vect[0] @ " " @ %vect[1] @ " " @ %vect[2]);
	GameBase::throw(%obj,%this,0.6,false);
	
	deleteObject(%this);
}

//----------------------------------------

GrenadeData MAWGrenadeShell
{
	bulletShapeName    = "grenproj.dts";
	explosionTag       = nadeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 250;
	collisionRadius    = 0.2;
	mass               = 1.0;
	elasticity         = 0.20;
	
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 0.8;
	damageType         = $MAWGrenadeLauncherDamageType;
				
	explosionRadius    = 10;
	kickBackStrength   = 200.0;
	maxLevelFlightDist = 150;
	totalTime          = 30.0;    // special meaning for grenades...
	liveTime           = 1.5;
	projSpecialTime    = 0.05;
	
	inheritedVelocityScale = 0.5;
	
	smokeName          = "rsmoke.dts";
	smokeDist   = 0.5;
	
	soundId = SoundLaserHit;
};



//---------------------------------------------------------

BulletData MachinegunBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.05;
	damageType         = $AssRifleDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

function MachinegunBullet::onAdd(%this)
{
	turretShellEject(%this);
}

//-------------------------------------------------------
BulletData ComancheBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.8;
	damageType         = $ComancheBulletDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 0.75;
	inheritedVelocityScale = 1.0;
	isVisible          = false;
	
	tracerPercentage   = 1.0;
	tracerLength       = 70;
};

//function ComancheBullet::onAdd(%this)
//{
//	ShellEject(%this);
//}

//-------------------------------------------------------
BulletData BigCannonShell
{
	bulletShapeName  = "bigcannonbullet.dts";
	explosionTag     = bigShellExp;
	mass             = 0.05;
	
	damageClass      = 1;       
	damageValue      = 0.35;
	damageType       = $BigCannonDamageType;
	explosionRadius  = 4.0;
	aimDeflection      = 0.002;
	kickBackStrength = 150.0;
	muzzleVelocity   = 125.0;
	totalTime        = 6.0;
	liveTime         = 2.0;
	isVisible        = True;
	lightRange       = 4.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 1.0;
	soundId = SoundJetHeavy;
};

function BigCannonShell::onAdd(%this)
{
	bigTurretShellEject(%this);
}

//--------------------------------------

GrenadeData MortarTurretShell
{
	bulletShapeName    = "mortar.dts";
	explosionTag       = mortarExp;
	collideWithOwner   = True;
	ownerGraceMS       = 400;
	collisionRadius    = 1.0;
	mass               = 8.0;
	elasticity         = 0.1;
	
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 1.32;
	damageType         = $HowitzerDamageType;
	
	explosionRadius    = 30.0;
	kickBackStrength   = 250.0;
    maxLevelFlightDist = 450;
	totalTime          = 50.0;    
	liveTime           = 0.1;
	projSpecialTime    = 0.05;
	
	inheritedVelocityScale = 0.5;
	smokeName              = "rsmoke.dts";
};

function MortarTurretShell::onAdd(%this)
{
	mortarTurretShellEject(%this);
}

//--------------------------------------

GrenadeData MineMortarShell
{
	bulletShapeName    = "minemortar.dts";
	explosionTag       = nadeExp;
	collideWithOwner   = True;
	ownerGraceMS       = 400;
	collisionRadius    = 1.0;
	mass               = 8.0;
	elasticity         = 0.1;
	
	damageClass        = 1;       // 0 impact, 1, radius
	damageValue        = 1.0;
	damageType         = $HowitzerDamageType;
	
	explosionRadius    = 1.0;
	kickBackStrength   = 150.0;
    maxLevelFlightDist = 450;
	totalTime          = 50.0;    
	liveTime           = 0.1;
	projSpecialTime    = 0.05;
	
	inheritedVelocityScale = 0.5;
	smokeName              = "rsmoke.dts";
};

function MineMortarShell::onAdd(%this)
{
	%number = 1;
	//echo("I'm Called!");
	%howitzer = $HowitzerId;
	$HowitzerId = 0;
	
	%team = GameBase::getTeam(%howitzer);
	//echo("%team ",%team);
	mortarTurretShellEject(%this);
	schedule("deployMine("@%number@","@%this@","@%team@");", 1.0, %this);
}

function deployMine(%number, %this, %team)
{
	if( %number <= 5 )
	{
		//echo("I'm Called too!");
		
		//%rot = GameBase::getRotation(%this);
		%pos = GameBase::getPosition(%this);
		//%rotx = -1 * getWord(%rot, 0);
		//%roty = -1 * getWord(%rot, 1);
		//%rotz = -1 * getWord(%rot, 2);
		//%newrot = %rotx@" "@%roty@" "@%rotz;
		%newrot = "-1.570796 0 0";
		//echo(%newrot);
		
		%strength = 5.0;
		
		%temp = newObject("","Mine","shell");
		addToSet("MissionCleanup", %temp);
		GameBase::setPosition(%temp, %pos);
		GameBase::setRotation(%temp, %newrot);
		
		%obj = newObject("","Mine","AntipersonelMine");
		addToSet("MissionCleanup", %obj);
		
		GameBase::setTeam(%obj, %team);
		if( $TeamItemCount[%team @ "MineAmmo"] < $TeamItemMax["MineAmmo"])
		{
			//echo("I work!");
			$TeamItemCount[%team @ "MineAmmo"]++;
			GameBase::throw(%obj,%temp,%strength,false);
		}
		else
			deleteObject(%obj);
		
		deleteObject(%temp);
		%number++;
		schedule("deployMine("@%number@","@%this@","@%team@");", 0.2, %this);
	}
}

//--------------------------------------

BulletData OspreyTurretBullet
{
	bulletShapeName    = "bullet.dts";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.35;
	damageType         = $OspreyTurretDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 1.0;
	tracerLength       = 30;
};

//--------------------------------------

BulletData InvisOspreyTurretBullet
{
	bulletShapeName    = "";
	explosionTag       = bulletExp0;
	expRandCycle       = 3;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.35;
	damageType         = $OspreyTurretDamageType;
	
	aimDeflection      = 0.004;
	muzzleVelocity     = 425.0;
	totalTime          = 1.5;
	inheritedVelocityScale = 1.0;
	isVisible          = False;
	
	tracerPercentage   = 0.0;
	tracerLength       = 0;
};

//--------------------------------------
SeekingMissileData HomingFlare
{
	bulletShapeName = "shotgunbolt.dts";
	explosionTag    = blasterExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.002;
	damageType       = $HomingFlareDamageType;
	explosionRadius  = 16.0;
	kickBackStrength = 0.0;
	
	muzzleVelocity    = 95.0;
	totalTime         = 3;
	liveTime          = 3;
	seekingTurningRadius    = 1.0;
	nonSeekingTurningRadius = 1.0;
	proximityDist     = 8.0;
	smokeDist         = 0.0;
	
	lightRange       = 10.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	
	inheritedVelocityScale = 0.5;
	
	soundId = SoundJetHeavy;
};

//-------------------------------------------------------
LightningData ReloadBolt
{
	bitmapName = "lightningNew.bmp";
	boltLength = 10;
	coneAngle = 45.0;
	damagePerSec = 0;
	energyDrainPerSec = -1.0;
	segmentDivisions = 0;
	numSegments = 1;
	beamWidth = 0.0;
	updateTime   = 120;
	skipPercent  = 0.5;
	displaceBias = 0.15;
	lightRange = 0.0;
	lightColor = { 0.0, 0.0, 0.0 };
	isVisible = false;
};

function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
	//Ammo Loader
	%name = GameBase::getDataName(%target);
	if( %name == "HowitzerTurret" || %name == "BigCannonTurret" || %name == "DeployableTurret" )
	{
		if( %name.maxEnergy < 1 )
			%name.maxEnergy = 200;
		%enDrainPerSec = %name.maxEnergy / 20;
		
		%Player = Client::getControlObject(%shooterId);
		
		if( $AmmoTossAnim[%shooterId] != TRUE )
		{
			if( %name != "DeployableTurret" )
				%tossedAmmo = newObject("","Mine","turretFullShell");
			else
				%tossedAmmo = newObject("","Mine","smallTurretFullShell");
			
			addToSet("MissionCleanup", %tossedAmmo);
			
			GameBase::throw(%tossedAmmo,%Player,3.0,false);
			$AmmoTossAnim[%shooterId] = TRUE;
			schedule("$AmmoTossAnim["@%shooterId@"] = FALSE;",0.5);
		}
		
		%enVal  = %timeSlice * %enDrainPerSec;
		%energy = GameBase::getEnergy(%target);
		%energy = %energy + %enVal;
		
		if (%energy > %name.maxEnergy) {
			%energy = %name.maxEnergy;
		}
		GameBase::setEnergy(%target, %energy);
		
		//Output
		if($MessageRepeat[%shooterId] != TRUE)
		{
			$MessageRepeat[%shooterId] = TRUE;
			%ammoPercent = (%energy / %name.maxEnergy) * 100;
			
			remoteEval(%shooterId, BP, "<jc><f0>"@%name.description@" Ammo: <f1>"@%ammoPercent@"%", 1);
			playSound(SoundDetTimerSet, GameBase::getPosition(%shooterId));
			schedule("$MessageRepeat["@%shooterId@"] = FALSE;",1.0);
		}
	}
	else
		if( %name == "DeployableAmmoStation" || %name == "DeployableInvStation" )
		{
			%enVal = %timeSlice * 10;
			%target.Energy = %target.Energy + %enVal;
			
			if( $AmmoTossAnim[%shooterId] != TRUE )
			{
				%Player = Client::getControlObject(%shooterId);
				%tossedAmmo = newObject("","Mine","smallTurretFullShell");
				addToSet("MissionCleanup", %tossedAmmo);
				GameBase::throw(%tossedAmmo,%Player,3.0,false);
				$AmmoTossAnim[%shooterId] = TRUE;
				schedule("$AmmoTossAnim["@%shooterId@"] = FALSE;",0.5);
			}
			
			if($MessageRepeat[%shooterId] != TRUE)
			{
				$MessageRepeat[%shooterId] = TRUE;
				remoteEval(%shooterId, BP, "<jc><f0>"@%name.description@" Energy: <f1>"@%target.Energy, 1);
				playSound(SoundDetTimerSet, GameBase::getPosition(%shooterId));
				schedule("$MessageRepeat["@%shooterId@"] = FALSE;",1.0);
			}
		}
		else
			Player::trigger(%shooterId, 0, 0);
}

//----------------------------------------------------------

RepairEffectData ConsoleJackBolt
{
	bitmapName       = "consolepulse.bmp";
	boltLength       = 7.0;
	segmentDivisions = 4;
	beamWidth        = 0.0625;
	
	updateTime   = 450;
	skipPercent  = 0.6;
	displaceBias = 0.15;
	
	lightRange = 2.0;
	lightColor = { 0.0, 1.0, 1.0 };
};

function ConsoleJackBolt::onAcquire(%this, %player, %target)
{
	%name = GameBase::getDataName(%target);
	%type = getObjectType(%target);
	%client = Player::getClient(%player);
	%playerTeam = GameBase::getTeam(%player);
	%targetTeam = GameBase::getTeam(%target);
	//echo("%targetTeam ", %targetTeam);
	//echo("%type ",%type);
	%startTime = getSimTime();
	//echo("%startTime ",%startTime);
	//echo(GameBase::getDataName(%target));
	%mapName = GameBase::getMapName(%target);
	if(%mapName == "")
		%mapName = %name.description;
	
	if( %name == defaultDetpack )
	{
		remoteEval(%client, BP, "<jc><f0>Attempting to Upload <f1>Disarm Code", 2);
		$DetHack[%player] = TRUE;
		$HackStartTime[%player] = %startTime;
		%player.repairTarget = %target;
	}
	else
		if( (%name.className == "Turret" || %name.className == "Station") && GameBase::getDataName(%target) != "vehiclePad" )
		{
			if(%playerTeam != %targetTeam)
			{
				if (GameBase::getDamageLevel(%target) < %name.maxDamage)
				{
					remoteEval(%client, BP, "<jc><f0>Attempting Viral Upload to <f1>"@%mapName, 2);
					
					$HackStartTime[%player] = %startTime;
					%player.repairTarget = %target;
				}
				else
				{
					$HackRes[%player] = FAILED;
					%player.repairTarget = -1;
					remoteEval(%client, BP, "<jc><f0>Data Port Destroyed on "@%mapName, 2);
					Player::trigger(%player, $WeaponSlot, false);
					return;
				}
			}
			else
			{
				$HackRes[%player] = FAILED;
				%player.repairTarget = -1;
				remoteEval(%client, BP, "<jc><f0>Target is Same Team, Logging Off...", 2);
				Player::trigger(%player, $WeaponSlot, false);
				return;
			}
			
		}
		else
		{
			$HackRes[%player] = FAILED;
			%player.repairTarget = -1;
			remoteEval(%client, BP, "<jc><f0>No Data Port Available", 2);
			Player::trigger(%player, $WeaponSlot, false);
			return;
		}
}

function ConsoleJackBolt::onRelease(%this, %player)
{
	%object = %player.repairTarget;
	if (%object != -1) {
		%client = Player::getClient(%player);
		if ( $HackRes[%player] == "FAILED" )
		{
			remoteEval(%client, BP,"<jc><f0>Upload <f1>FAILED", 2);
		}
	}
	$HackRes[%player] = "FAILED";
	$DetHack[%player] = FALSE;
}

function ConsoleJackBolt::checkDone(%this, %player)
{
	%target = %player.repairTarget;
	%client = Player::getClient(%player);
	%name = GameBase::getDataName(%target);
	$HackRes[%player] = "FAILED";
	
	if (Player::isTriggered(%player,$WeaponSlot) && Player::getMountedItem(%player,$WeaponSlot) == ConsoleJack)
	{
		if( getSimTime() > $HackStartTime[%player] + 2.0 && $DetHack[%player] == TRUE )
		{
			$DetHack[%player] = FALSE;
			$HackRes[%player] = "DETPACK";
			$status[%target] = "disarmed"; 
			remoteEval(%client, BP, "<jc><f0>Detpack <f1>DISARMED", 3);
			Client::sendMessage(%client, 0, "Detpack Disarmed");
			Player::setItemCount(%player, Detpack, 1);
			deleteObject(%target);
		}
		else
		{
			if( getSimTime() > $HackStartTime[%player] + 6.5 && $DetHack[%player] == FALSE )
			{
				%mapName = GameBase::getMapName(%target);
				if(%mapName == "")
					%mapName = %name.description;
				
				%rand = getRandom();
				if( %rand > 0.899 )
				{
					$HackRes[%player] = "DISABLED";
					remoteEval(%client, BP, "<jc><f0>"@%mapName@" <f1>DISABLED", 3);
					%disableDamage = GameBase::getDisabledDamage(%target);
					GameBase::setDamageLevel(%target, %disableDamage);
					Client::sendMessage(%client, 0, %mapName@" "@$HackRes[%player]);
				}
				else if( %rand > 0.649)
				{
					$HackRes[%player] = "DESTROYED";
					remoteEval(%client, BP, "<jc><f0>"@%mapName@" <f1>DESTROYED", 3);
					GameBase::setDamageLevel(%target, %name.maxDamage);
					Client::sendMessage(%client, 0, %mapName@" "@$HackRes[%player]);
				}
				else
				{
					if( %name.className == "Turret" && %name != BigCannonTurret && %name != HowitzerTurret )
					{
						$HackRes[%player] = "DISABLED";
						remoteEval(%client, BP, "<jc><f0>"@%mapName@" <f1>DISABLED", 3);
						%disableDamage = GameBase::getDisabledDamage(%target);
						GameBase::setDamageLevel(%target, %disableDamage);
						Client::sendMessage(%client, 0, %mapName@" "@$HackRes[%player]);
					}
					else
					{
						$HackRes[%player] = "ACCESSABLE";
						remoteEval(%client, BP, "<jc><f0>"@%mapName@" <f1>ACCESSABLE", 3);
						$NoneTeamAccess[%target] = TRUE;
						schedule("$NoneTeamAccess["@%target@"] = FALSE;",$HackEffectTimeLimit);
						Client::sendMessage(%client, 0, %mapName@" "@$HackRes[%player]);
					}
				}
				Player::trigger(%player, $WeaponSlot, false);
				return;
			}
			else
			{
				if( getSimTime() > $HackStartTime[%player] + 5.5 )
					remoteEval(%client, BP,"<jc><f0>Upload <f1>Successful", 1.0);
				else if( getSimTime() > $HackStartTime[%player] + 4.5 )
					remoteEval(%client, BP,"<jc><f0>Uploading <f1>. . . . . .", 1.0);
				else if( getSimTime() > $HackStartTime[%player] + 3.5 )
					remoteEval(%client, BP,"<jc><f0>Uploading <f1>. . . . <f0>. .", 1.0);
				else if( getSimTime() > $HackStartTime[%player] + 2.5 )
					remoteEval(%client, BP,"<jc><f0>Uploading <f1>. . <f0>. . . .", 1.0);
				else if( getSimTime() > $HackStartTime[%player] + 2 )
					remoteEval(%client, BP,"<jc><f0>Uploading . . . . . .<f0>", 0.5);
			}
		}
	}
}
//*************************************************************************************************************
// SF Addition - end
//*************************************************************************************************************

//--------------------------------------
SeekingMissileData TurretMissile
{
	bulletShapeName = "rocket.dts";
	explosionTag    = rocketExp;
	collisionRadius = 0.0;
	mass            = 2.0;
	
	damageClass      = 1;       // 0 impact, 1, radius
	damageValue      = 0.75;
	damageType       = $MissileDamageType;
	explosionRadius  = 10.5;
	kickBackStrength = 175.0;
	
	muzzleVelocity    = 75.0;
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

RepairEffectData RepairBolt
{
	bitmapName       = "repairadd.bmp";
	boltLength       = 10;
	segmentDivisions = 4;
	beamWidth        = 0.125;
	
	updateTime   = 450;
	skipPercent  = 0.6;
	displaceBias = 0.15;
	
	lightRange = 3.0;
	lightColor = { 0.85, 0.25, 0.25 };
};

function RepairBolt::onAcquire(%this, %player, %target)
{
	%client = Player::getClient(%player);
	
	if (%target == %player) {
		%player.repairTarget = -1;
		if (GameBase::getDamageLevel(%player) != 0) {
			%player.repairRate = 0.05;
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
	%DataName = GameBase::getDataName(%player.repairTarget);
	if(%DataName == "RocketTurret" || %DataName == "HowitzerTurret" || %DataName == "BigCannonTurret"
		|| %DataName == "IndoorTurret")
	{
		%rate = %DataName.maxDamage / 15.0;
		echo("%rate ",%rate);
	}
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
		
		%DataName = GameBase::getDataName(%player.repairTarget);
		if(%DataName == "RocketTurret" || %DataName == "HowitzerTurret" || %DataName == "BigCannonTurret"
			|| %DataName == "IndoorTurret" )
		{
			%rate = 0.0;
		}
		
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
