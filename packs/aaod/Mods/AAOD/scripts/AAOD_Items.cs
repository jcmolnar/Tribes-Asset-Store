// ----------------- AAOD Weapons Script ---------------------

$NWeapons=0;

//	Add Weapon Function.. Designed to Allow the AAODX Weapon Kits to Dump Weapons into this file
//	and basically just insert themselves into the next weapon Prev Weapon Stack

function AddWeapon(%WeaponName)
{	// Create a New Weapon Index
	$Weap[$NWeapons]=%WeaponName;
	%PrevWeapon=$NWeapons-1;
	if(%PrevWeapon<0) %PrevWeapon=0;
	$NextWeapon[$Weap[%PrevWeapon]]=%WeaponName;	// Set the Prev Weapon to The New Weapon
	$NextWeapon[%Weapon]=$Weap[0];					// Set the Next Weapon to the First Weapon
	$PrevWeapon[$Weap[0]]=%WeaponName;
	$PrevWeapon[%WeaponName]=$Weap[%PrevWeapon];
	$NWeapons++;
}

AddWeapon(Blaster);
AddWeapon(PlasmaGun);
AddWeapon(ChainGun);
AddWeapon(AODReaper);
AddWeapon(DiscLauncher);
AddWeapon(GrenadeLauncher);
AddWeapon(Mortar);
AddWeapon(LaserRifle);
AddWeapon(EnergyRifle);
AddWeapon(AODSniperX);
AddWeapon(AODBBuster);
AddWeapon(AODStinger);
AddWeapon(AODBeaconGun);
AddWeapon(AODStasisGun);

//----------------------------------------------------
// SNIPER X Weapon Definition
//----------------------------------------------------
$AutoUse[AODSniperX]			= True;

$InvList[AODSniperX]			= 1;
$InvList[SniperXAmmo]			= 1;

$RemoteInvList[AODSniperX]		= 1;
$RemoteInvList[SniperXAmmo]		= 1;

$WeaponAmmo[AODSniperX]			= SniperXAmmo;
$SellAmmo[SniperXAmmo]			= 5;
$AmmoPackMax[SniperXAmmo]		= 10;

$ItemMax[larmor,AODSniperX]		= 1;
$ItemMax[lfemale,AODSniperX]	= 1;
$ItemMax[marmor,AODSniperX]		= 0;
$ItemMax[mfemale,AODSniperX]	= 0;
$ItemMax[harmor,AODSniperX]		= 0;

$ItemMax[larmor,SniperXAmmo]	= 5;
$ItemMax[lfemale,SniperXAmmo]	= 5;
$ItemMax[marmor,SniperXAmmo]	= 5;
$ItemMax[mfemale,SniperXAmmo]	= 5;
$ItemMax[harmor,SniperXAmmo]	= 5;

ExplosionData SniperXExp
{	shapeName		= "shockwave.DTS";
	soundId			=  SoundExpSniperX;
	faceCamera		= true;
	randomSpin		= true;
	hasLight		= true;
	lightRange		= 2.0;
	timeZero		= 0.100;
	timeOne			= 0.900;
	colors[0]		= {0.0,0.0,0.0};
	colors[1]		= {1.0,1.0,0.5};
	colors[2]		= {0.0,1.0,0.0};
	radFactors		= {0.0,1.0,0.0};
	shiftPosition	= False;
};

BulletData SniperShot
{	bulletShapeName = "smoke.dts";
	explosionTag	= SniperXExp;
	mass			= 2.0;
	collisionRadius = 0.0;
	bulletHoleIndex = 0;
	ExplosionRadius = 0;
	damageClass		= 0;
	damageValue		= 0.45;
	damageType		= $SniperXDamageType;
	aimDeflection	= 0.0;
	muzzleVelocity	= 1500.0;
	totalTime		= 1.5;
	liveTime		= 1.6;
	inheritedVelocityScale = 0.5;
	isVisible		= true;
	tracerPercentage = 1;
	tracerLength	= 10;
	detachFromShooter = false;
	soundId			= soundSniperShot;
	rotationPeriod	= 0;
	lightRange		= 1.0;
	lightColor		= {1.0, 0.25,0.25};
};

ItemData SniperXAmmo
{	description			= "SniperX Ammo";
	classname			= "Ammo";
	shapeFile			= "discammo";
	heading				= "xAmmunition";
	shadowDetailMask	= 4;
	price				= 150;
};

ItemImageData AODSniperXImage
{  	shapeFile		= "SNIPER";
	mountPoint		= 0;
	mountOffset		= { 0.10, 0, 0 };
	mountRotation	= { 0, -1.570796327, 0};
	weaponType		= 0;
	reloadTime		= 1.5;
	fireTime		= 0.25;
	projectileType	= SniperShot;
	ammotype		= SniperXAmmo;
	accuFire		= true;
	sfxFire			= SoundFireSniperX;
	sfxActivate		= SoundPickUpWeapon;
	sfxReload		= SoundSniperXReload;
};

ItemData AODSniperX
{	heading				= "bWeapons";
	description			= "HP Sniper Rifle";
	classname			= "Weapon";
	shapeFile			= "SNIPER";	
	hudIcon				= "sniper";	
	shadowDetailMask	= 4;	
	imageType			= AODSniperXImage;
	price				= 685;		
	showWeaponBar		= true;		
};

function AODSniperX::Help(%client)
{	%msg=HelpTitle("SniperX: High Powered Sniper Rifle");
	%msg=AddHelpLine(%msg,"Fires a special bullet that is designed.");
	%msg=AddHelpLine(%msg,"to penetrate heavy armor. This makes this an excellent Heavy killing weapon");
	%msg=AddHelpLine(%msg,"Does not do well against lightly armored targets");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
// ----------------------------------
// End of AODSniperX 
//-----------------------------------

//-----------------------------------
// Beacon Gun Script
//-----------------------------------
$InvList[AODBeaconGun]			= 1;
$RemoteInvList[AODBeaconGun]	= 1;		
$AutoUse[AODBeaconGun]			= True;
$WeaponAmmo[AODBeaconGun]		= BeaconAmmo;
$InvList[BeaconAmmo]			= 1;	
$RemoteInvList[BeaconAmmo]		= 1;
$SellAmmo[BeaconAmmo]			= 5;


$ItemMax[larmor,AODBeaconGun]	= 1;
$ItemMax[lfemale,AODBeaconGun]	= 1;
$ItemMax[marmor,AODBeaconGun]	= 1;
$ItemMax[mfemale,AODBeaconGun]	= 1;
$ItemMax[harmor,AODBeaconGun]	= 1;

$ItemMax[larmor,BeaconAmmo]		=5;
$ItemMax[lfemale,BeaconAmmo]	=5;
$ItemMax[marmor,BeaconAmmo]		=8;
$ItemMax[mfemale,BeaconAmmo]	=8;
$ItemMax[harmor,BeaconAmmo]		=10;


ExplosionData AODBeaconGunExp
{	shapeName = "shockwave.dts";	
	soundId=  SoundBeaconExplosion;	
	faceCamera=true;				
	randomSpin = true;		
	hasLight=true;			
	lightRange=9.0;			
	timeZero=0.100;			
	timeOne=0.900;			
	colors[0]={0.5,0.4,0.2};
	colors[1]={1.0,1.0,0.5};
	colors[2]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;	
};

RocketData BeaconRocket
{	bulletShapeName		= "sensor_small.dts";
	explosionTag		= AODBeaconGunExp;
	#collideWithOwner	= true;
	#ownerGraceMS		= 750;
	collisionRadius		= 0.0;
	mass				= 1.0;
	damageClass			= 1;    
	damageValue			= 0.10;
	damageType			= $BeaconDamageType;
	explosionRadius		= 15.0;
	kickBackStrength	= 75.0;
	muzzleVelocity		= 25.0;
	terminalVelocity	= 25.0;
	acceleration		= 1.0;
	totalTime			= 22.0;
	liveTime			= 23.0;
	lightRange			= 5.0;
	lightColor			= { 0.2, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType			= 2;                
	trailString			= "rsmoke.dts";
	smokeDist			= 1.5;
	soundId				= SoundJetHeavy;
};

// Secondary Item Definitions... Ammo containers etc.

ItemData BeaconAmmo
{	description		= "Beacon Ammo";
	classname		= "Ammo";
	shapeFile		= "sensor_small";		
	heading			= "xAmmunition";
	shadowDetailMask = 4;
	price			= 50;
};

//***************************************************
// Item Image Definitions
//***************************************************

ItemImageData AODBeaconGunImage
{	shapeFile		= "PaintGun";
	mountPoint		= 0;
	mountOffset		= { -0.1, 0, 0 };
	mountRotation	= { 0, -2.75, 0};
	weaponType		= 0;
	reloadTime		= 0.75;
	fireTime		= 1.5;
	minEnergy		= 15;	
	maxEnergy		= 50;	
	projectileType	= Unknown;
	ammoType		= BeaconAmmo;
	accuFire		= true;
	sfxActivate		= SoundPickUpWeapon;
};

ItemData AODBeaconGun
{	heading				= "bWeapons";
	description			= "Beacon Gun";
	classname			= "Weapon";
	shapeFile			= "PaintGun";
	hudIcon				= "mortar";	
	shadowDetailMask	= 4;
	imageType			= AODBeaconGunImage;	
	price				= 450;				
	showWeaponBar		= true;	
};

function AODBeaconGun::Help(%client)
{	%msg=HelpTitle("AODBeaconGun: Beacon Deployment Device");
	%msg=AddHelpLine(%msg,"Launches Special Rockets which carry beacons up to");
	%msg=AddHelpLine(%msg,"200 meters or so.. Allows for the deployment of beacons");
	%msg=AddHelpLine(%msg,"on enemy emplacements without great risk.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

function DeployRBeacon(%player)
{	// if($trace) echo( $ver@"|DeployRbeacon  ");
	%position=$Location;
	%rot=$Rotation;
	%beacon = newObject("Target Beacon", "StaticShape", "DefaultBeacon", true);
	if($traceObj) Echo($Ver,"|Created New Object :",%beacon," Beacon");
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,%position);
	Gamebase::setMapName(%beacon,"Target Beacon");
	Beacon::onEnabled(%beacon);
}

function AODBeaconGunImage::onFire(%player,%slot)
{	// if($trace) echo( $ver@"|AODBeaconGunImage::onFire");
	%client = GameBase::getOwnerClient(%player);
	%AmmoCount = (Player::getItemCount(%player, $WeaponAmmo[AODBeaconGun]) && Player::getItemCount(%player,Beacon)) ;
	if(%AmmoCount)
	{	%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if(GameBase::getLOSInfo(%player,250))
		{	%object = getObjectType($los::object);
			if (%object!="Player" && %object !="Flier" && %object !="") // == "SimTerrain" || %object == "InteriorShape" || %object=="StaticShape") 
			{	// Try to stick it straight up or down, otherwise
				// just use the surface normal
				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{	%rot = "0 0 0";}
				else 
				{	if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
					{	%rot = "3.14159 0 0";}
					else 
					{	%rot = Vector::getRotation($los::normal);}
				}
				%team = GameBase::getTeam(%player);
				if($TeamItemMax[Beacon] > $TeamItemCount[%team @ Beacon] || $TestCheats) 
				{	%Dist=Vector::getDistance(GameBase::getPosition(%player),$los::position);
					if(%Dist==0)
					{	%tTime=1;}
					else
					{	%tTime=%Dist/25;}

					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("BeaconRocket",%trans,%player,%vel,$los::object);
					playSound(SoundMissileReload, GameBase::getPosition(%player));
					GiveKickBack(%player, 15, 1);
					Client::sendMessage(%client,0,"Beacon Away");
					$Location=$los::position;
					$Rotation=%rot;
					schedule("DeployRBeacon(" @ %player @ " );",%tTime);
					$TeamItemCount[GameBase::getTeam(%beacon) @ "Beacon"]++;
					Player::decItemCount(%player,Beacon);
				}
				else
				Client::sendMessage(%client,0,"Deployable Item limit reached! ~Error_Message.wav");
			}
			else
			Client::sendMessage(%client,0,"** Invalid Target - Unable to attach to Object! ** ~wError_Message.wav");
		}
		else
		Client::sendMessage(%client,0,"** Object Out of Range !! ** ~wError_Message.wav");
	}
	else
	{	if (!Player::getItemCount(%player, $WeaponAmmo[AODBeaconGun]))
	{	Client::sendMessage(%client,0,"** Out of BeaconAmmo!! ** ~waccess_denied.wav");}
	else
	{ 	Client::sendMessage(%client,0,"** Out of Beacons!! ** ~waccess_denied.wav");}
	}

}

//----------------------------
// Bunker Buster Script
//----------------------------

$AutoUse[AODBBuster]			= True;
$InvList[AODBBuster]			= 1;	
$RemoteInvList[AODBBuster]		= 1;	
$WeaponAmmo[AODBBuster]			= BusterAmmo;
$InvList[BusterAmmo]			= 1;
$RemoteInvList[BusterAmmo]		= 1;
$SellAmmo[BusterAmmo]			= 5;

$ItemMax[larmor,AODBBuster]		= 0;
$ItemMax[lfemale,AODBBuster]	= 0;
$ItemMax[marmor,AODBBuster]		= 0;
$ItemMax[mfemale,AODBBuster]	= 0;
$ItemMax[harmor,AODBBuster]		= 1;

$ItemMax[larmor,BusterAmmo]		= 5;
$ItemMax[lfemale,BusterAmmo]	= 5;
$ItemMax[marmor,BusterAmmo]		= 5;
$ItemMax[mfemale,BusterAmmo]	= 5;
$ItemMax[harmor,BusterAmmo]		= 5;



ExplosionData AODBBusterExp
{
	shapeName = "shockwave_large.dts";
	soundId=  SoundBusterExplosion;	
	faceCamera=true;				
	randomSpin = true;	
	hasLight=true;		
	lightRange=9.0;		
	timeZero=0.100;		
	timeOne=0.900;		
	colors[0]={0.5,0.4,0.2};
	colors[1]={1.0,1.0,0.5};
	colors[2]={0.0,1.0,0.0};
	radFactors={0.5,1.0,0.0};
	shiftPosition=False;	
};


RocketData BusterRocket
{	bulletShapeName  = "rocket.dts";
	explosionTag     = AODBBusterExp;
	#collideWithOwner = true;
	#ownerGraceMS = 750;
	collisionRadius  = 0.0;
	mass             = 1.0;
	damageClass      = 1;       
	damageValue      = 2.5;
	damageType       = $BusterDamageType;
	explosionRadius  = 10.0;
	kickBackStrength = 400.0;
	muzzleVelocity   = 10.0;
	terminalVelocity = 30.0;
	acceleration     = 0.75;
	totalTime        = 22.0;
	liveTime         = 23.0;
	lightRange       = 5.0;
	lightColor       = { 0.2, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType   = 2;                // smoke trail
	trailString = "rsmoke.dts";
	smokeDist   = 2.8;
	soundId = SoundJetHeavy;
};

ItemData BusterAmmo
{	description = "Bunker Buster Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData AODBBusterImage
{	shapeFile		= "Mortar";	
	mountPoint		= 0;		
	weaponType		= 0; 
	reloadTime		= 0.75;
	fireTime		= 0.2;
	minEnergy		= 5;
	maxEnergy		= 6;
	projectileType	= "Undefined";
	ammoType		= BusterAmmo;
	accuFire		= true;
	sfxFire			= SoundMissileTurretFire;
	sfxActivate		= SoundPickUpWeapon; 
	sfxReady		= SoundBusterActive;
	sfxReload		= SoundMortarReload;
};

ItemData AODBBuster
{	heading = "bWeapons";
	description = "Bunker Buster";
	classname = "Weapon";
	shapeFile  = "Mortar";
	hudIcon = "mortar";	
	shadowDetailMask = 4;
	imageType = AODBBusterImage;
	price = 450;				
	showWeaponBar = true;		
};

function AODBBuster::Help(%client)
{	%msg=HelpTitle("Bunker Buster: High Energy concusive Rocket");
	%msg=AddHelpLine(%msg,"This monster fires a special High Energy explosive rocket.");
	%msg=AddHelpLine(%msg,"designed to take out mass. Works great against Turrets & such.");
	%msg=AddHelpLine(%msg,"Does not do well against light targets");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

function AODBBusterImage::onFire(%player,%slot)
{	// if($trace) echo( $ver@"|AODBBusterImage::onFire");
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AODBBuster]);
	if(%AmmoCount)
	{	%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		Player::decItemCount(%player,$WeaponAmmo[AODBBuster],1);
		playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
		Projectile::spawnProjectile("BusterRocket",%trans,%player,%vel);
		GiveKickBack(%player, 200, 1);
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}


//--------------------------------------------------
//		ADVANCED TARGETING PACK
//--------------------------------------------------
$InvList[AODATPack]				= 1;
$RemoteInvList[AODATPack]		= 1;

$ItemMax[lfemale, AODATPack]	= 0;
$ItemMax[mfemale, AODATPack]	= 1;
$ItemMax[larmor, AODATPack]		= 0;
$ItemMax[marmor, AODATPack]		= 1;
$ItemMax[harmor, AODATPack]		= 0;

ItemImageData AODATPackImage
{	shapeFile		= "radar_small";
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, 0 };
	minEnergy		= 1;
 	maxEnergy		= 3;
	firstPerson		= false;
	mass			= 2.5;
};

ItemData AODATPack
{	description		= "Adv. Targeting Pack";
	shapeFile		= "radar_small";
	classname		= "Backpack";
	heading			= "cBackpacks";
	shadowDetailMask = 4;
	imageType		= AODATPackImage;
	price			= 750;
	hudIcon			= "energypack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
	mass			= 4.0;
};

function AODATPack::Help(%client)
{	%msg=HelpTitle("Advanced Targeting Pack: Seeking Missile Programming Pack");
	%msg=AddHelpLine(%msg,"Uses Heat and radar imaging to loack in on a traget and program that into");
	%msg=AddHelpLine(%msg,"a standard seeking missile. Excellent against air targets");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

function AODATPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);}
}

function AODATPack::onMount(%player,%item)
{	Player::trigger(%player,$BackpackSlot,true);
}

function AODATPack::onUnmount(%player,%item)
{
}

//------------------------------
// Missile Launcher Script
//------------------------------

$InvList[AODStinger]			= 1;	
$RemoteInvList[AODStinger]		= 1;
$AutoUse[AODStinger]			= True;
$WeaponAmmo[AODStinger]			= MissileAmmo;
$InvList[MissileAmmo]			= 1;
$RemoteInvList[MissileAmmo]		= 1;
$SellAmmo[MissileAmmo]			= 5;

$ItemMax[larmor,AODStinger]		= 0;
$ItemMax[lfemale,AODStinger]	= 0;
$ItemMax[marmor,AODStinger]		= 1;
$ItemMax[mfemale,AODStinger]	= 1;
$ItemMax[harmor,AODStinger]		= 1;

$ItemMax[larmor,MissileAmmo]	=0;
$ItemMax[lfemale,MissileAmmo]	=0;
$ItemMax[marmor,MissileAmmo]	=10;
$ItemMax[mfemale,MissileAmmo]	=10;
$ItemMax[harmor,MissileAmmo]	=15;


ExplosionData AODStingerExp
{	shapeName = "shockwave.DTS";
	soundId=  RocketExplosion;	
	faceCamera=true;			
	randomSpin = true;			
	hasLight=true;				
	lightRange=8.0;				
	timeZero=0.100;				
	timeOne=0.900;				
	colors[0]={0.0,0.0,0.0};	
	colors[1]={1.0,1.0,0.5};	
	colors[2]={0.0,1.0,0.0};	
	radFactors={0.0,1.0,0.0};	
	shiftPosition=False;		
};

SeekingMissileData AAODM1
{	bulletShapeName  = "Rocket.dts";
	explosionTag     = AODStingerExp;
	collisionRadius  = 0.0;
	mass             = 0.5;
	damageClass      = 1;       
	damageValue      = 0.65;
	damageType       = $StingerDamageType;
	explosionRadius  = 8.5;
	kickBackStrength = 125.0;
	muzzleVelocity   = 50.0;
	terminalVelocity = 100.0;
	acceleration     = 1.0;
	totalTime        = 8.0;
	liveTime         = 9.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType		= 2;      
	trailString		= "mortartrail.dts";
	smokeDist		= 2;
	soundId			= SoundJetHeavy;
	seekingTurningRadius    = 2.5;
};

SeekingMissileData AAODM2
{	bulletShapeName  = "Rocket.dts";
	explosionTag     = AODStingerExp;
	collisionRadius  = 0.0;
	mass             = 1.0;
	damageClass      = 1;       
	damageValue      = 0.50;
	damageType       = $StingerDamageType;
	explosionRadius  = 7.5;
	kickBackStrength = 175.0;
	muzzleVelocity   = 75.0;
	terminalVelocity = 150.0;
	acceleration     = 5.0;
	totalTime        = 6.0;
	liveTime         = 7.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// Missile specific
	trailType		= 2;                
	trailString		= "rsmoke.dts";
	smokeDist		= 20;
	soundId			= SoundJetHeavy;
};

RocketData AAODRocket
{	bulletShapeName  = "rocket.dts";
	explosionTag     = AODStingerExp;
	collisionRadius  = 0.0;
	mass             = 2.0;
	damageClass      = 1;
	damageValue      = 0.65;
	damageType       = $StingerDamageType;
	explosionRadius  = 9.5;
	kickBackStrength = 175.0;
	muzzleVelocity   = 75.0;
	terminalVelocity = 80.0;
	acceleration     = 5.0;
	totalTime        = 6.0;
	liveTime         = 7.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType   = 2;                
	trailString = "rsmoke.dts";
	smokeDist   = 20;
	soundId = SoundJetHeavy;
};


ItemData MissileAmmo
{	description = "Std Missile Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 50;
};

//***************************************************
// Item Image Definitions
//***************************************************

ItemImageData AODStingerImage
{	shapeFile		= "grenadeL";
	mountPoint		= 0;		
	mountOffset		= { -0.1, 0, 0 };
	mountRotation	= { 0, -2.00, 0};
	weaponType		= 0; 	
	reloadTime		= 1.5;	
	fireTime		= 0.1;	
	minEnergy		= 5;	
	maxEnergy		= 6;	
	projectileType	= Undefined;
	ammoType		= MissileAmmo;
	accuFire		= true;	
	sfxFire			= SoundPickUpBackpack;
	sfxActivate		= SoundPickUpWeapon;
	sfxReload		= SoundMissileReload;
	sfxReady		= SoundMissileIdle;
};

ItemData AODStinger
{	heading			= "bWeapons";
	description		= "Missile Launcher";
	classname		= "Weapon";
	shapeFile		= "GrenadeL";
	hudIcon			= "mortar";
	shadowDetailMask = 4;
	imageType		= AODStingerImage;
	price			= 350;
	showWeaponBar	= true;
};
function AODStinger::Help(%client)
{	%msg=HelpTitle("AODStinger: Rocket Missile Launcher Combo Weapon");
	%msg=AddHelpLine(%msg,"If not pointed directly at a player or vehicle Fires a dumbfire rocket");
	%msg=AddHelpLine(%msg,"which does good damage. If a Player or Vehicle is directly in the ");
	%msg=AddHelpLine(%msg,"crosshairs the missile will lock onto the target & seek it out.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}


function AODStingerImage::onFire(%player,%slot)
{	// if($trace) echo( $ver@"|AODStingerImage::onFire");
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AODStinger]);
	if(%AmmoCount)
	{	%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		// if($trace) echo($ver,"| Player Has Pack =",%pack);
		if (%pack=="AODATPack") 
		{	// Special Targeting Routine
			GameBase::getLOSInfo(%player,350);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	%targetcl=Player::GetClient(%target);	 
				// if($trace) echo($ver,"| target is ",%target, " Client is ",%client);
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
					GiveKickBack(%player, 125, 1);
				}
				else if(%jam==2)
				{	%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	Projectile::spawnProjectile("AAODM1",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"** UNKNOWN!! Lock Aquired - " @ %name @ "~wmine_act.wav");
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						GiveKickBack(%player, 125, 1);
					}
				}
				else
				{	Projectile::spawnProjectile("AAODM1",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					%name = Client::getName(%target);
					SendLockWarning(%TargetCl,1);
					Client::sendMessage(%client,0,"** Image Lock Aquired - " @ %name @ "~wmine_act.wav");
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					GiveKickBack(%player, 125, 1);
				}
			}
			else
			{	Client::sendMessage(%client,0,"** No Image Lock (Alternate Scan Engaged)- " @ %name @ "~wmine_act.wav");
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	%TargetCl=Player::GetClient(%target);	 
					// if($trace) echo($ver,"| target is ",%target, " Client is ",%client);
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
						GiveKickBack(%player, 125, 1);
					}
					else if(%jam==2)
					{	%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	Projectile::spawnProjectile("AAODM1",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
							%name = Client::getName(%target);
							SendLockWarning(%TargetCl,2);
							Client::sendMessage(%client,0,"** UNKNOWN!! Lock Aquired - " @ %name @ "~wmine_act.wav");
							playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
							GiveKickBack(%player, 125, 1);
						}
					}
					else
					{	Projectile::spawnProjectile("AAODM1",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						%name = Client::getName(%target);
						SendLockWarning(%TargetCl,2);
						Client::sendMessage(%client,0,"** Sensor Lock Aquired - " @ %name @ "~wmine_act.wav");
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						GiveKickBack(%player, 125, 1);
					}
				}
				else
				{	Client::sendMessage(%client,0,"** NO Valid Target Firing Unprogrammed Missile ** " @ %name @ "~wmine_act.wav");
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
					GiveKickBack(%player, 125, 1);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,350))
			{	%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				if(%object == "Player" || %object == "Flier")
				{	Projectile::spawnProjectile("AAODM2",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					%name = Client::getName(%targetId);
					SendLockWarning(%targetId,0);
					Client::sendMessage(%client,0,"** Lock Aquired - " @ %name @ "~wmine_act.wav");
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					//playSound(SoundMissileReload, GameBase::getPosition(%player));
					GiveKickBack(%player, 125, 1);
				}
				else
				{	Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
					//playSound(SoundMissileReload, GameBase::getPosition(%player));
					GiveKickBack(%player, 125, 1);
				}
			}
			else
			{	Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
				//playSound(SoundMissileReload, GameBase::getPosition(%player));
				GiveKickBack(%player, 125, 1);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}
function CheckTargetJamming(%target)
{	// Is Target A Player If not Return a 0
	// If target Wearing a jamming Pack & is it turned on If No Return a 0 If Yes return a 1
	// Does Target have stealth ability if lvl1 then return 1 if lvl 2 return 2 else return 0
	%jamming=0;
	%type=getObjectType(%target);
	if(%type!="PLAYER")
		return(0);

	%pack=Player::getMountedItem(%target,$BackpackSlot);
	// if($trace) echo($ver,"| Target Has Pack =",%pack);
	if (%pack=="SensorJammerPack")
	{	if($trace) echo($ver,"| Target Has Jammer Pack =",%pack);
		if (Player::isTriggered(%target,$BackpackSlot) )
			%jamming=1;
	}

	if(%target.talent[$Stealth]==1)
		%jamming=1;
	if(%target.talent[$Stealth]==2)
		%jamming=2;
	return (%jamming);
}

function AquireTarget(%this,%option,%pos)
{	// Options are	0 - Line of Sight Scan
	//				1 - Local Area Scan
	//				2 - Infiltrator Jammed Scan
	//				3 - AAPC Scan

	if($trace) echo($ver,"| Aquiring Target for player ",%this," type of scan ",%option," Position ",%pos);
	%team = GameBase::getTeam(%this);
	%target=0;
	
	%set = newObject("set",SimSet);
	
	if(%option==1)
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType,%pos,250,250,250,0);
	}
	else if(%option==2)
	{
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,250,250,250,0);
	}
	else if(%option==3)
	{
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,200,200,-100,0);
	}
	else 
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType ,%pos,80,80,80,0);
	
	// echo(" Number of Objects = ",%tnum);


	if (%tnum>0)
	{	// There are Targets within scan range
		if($traceAll) echo($Ver,"| AODATPack Scan Has Located ",%tnum," Targets.. in a ",%option," Scan");
		for (%i=0;%i<%tnum;%i++)
		{	%tgt=Group::getObject(%set,%i);
			%tgtTeam=GameBase::getTeam(%tgt);
			if(%option==2)
			{	echo("Jammed Aquisition %team ",%team, " Target team ",%tgtTeam);
				if(%team==%tgtTeam)	
					%target=%tgt;
			}
			else
			{	echo("Normal Aquisition %team ",%team, " Target team ",%tgtTeam);
				if(%team!=%tgtTeam) 
					%target=%tgt;
			}
				
			if(%target)
			{	// if($trace) echo($ver,"| Target Aquisition of ",%target," Target Locked");
				%i=%tnum;
			}
		}
	}
	deleteObject(%set);
	return (%target);
}
//*****************************
// End of Missile Launcher Def
//*****************************

//-------------------------------------------
//***** Stasis Cannon Weapon Definition *****
//-------------------------------------------
$InvList[AODStasisGun]			= 1;	
$RemoteInvList[AODStasisGun]	= 1;	
$AutoUse[AODStasisGun]			= True;
$WeaponAmmo[AODStasisGun]		= StasisAmmo;
$InvList[StasisAmmo]			= 1;
$RemoteInvList[StasisAmmo]		= 1;
$SellAmmo[StasisAmmo]			= 5;

$ItemMax[larmor,AODStasisGun]	= 0;	
$ItemMax[lfemale,AODStasisGun]	= 0;	
$ItemMax[marmor,AODStasisGun]	= 1;	
$ItemMax[mfemale,AODStasisGun]	= 1;	
$ItemMax[harmor,AODStasisGun]	= 0;

$ItemMax[larmor,StasisAmmo]		= 0;
$ItemMax[lfemale,StasisAmmo]	= 0;
$ItemMax[marmor,StasisAmmo]		= 10;
$ItemMax[mfemale,StasisAmmo]	= 10;
$ItemMax[harmor,StasisAmmo]		= 0;	

ExplosionData AODStasisGunExp
{	shapeName	= "plasmaEx.DTS";
	soundId		=  SoundExpStasisCannon;
	faceCamera	= true;				
	randomSpin	= true;			
	hasLight	= true;			
	lightRange	= 2.0;			
	timeZero	= 0.100;		
	timeOne		= 0.900;		
	colors[0]	={0.0,0.0,0.0};	
	colors[1]	={1.0,1.0,0.5};	
	colors[2]	={0.0,1.0,0.0};	
	radFactors	={0.0,1.0,0.0};	
	shiftPosition=False;		
};

RocketData StasisShot
{  bulletShapeName = "FusionBolt.dts";
   explosionTag    = AODStasisGunExp;
   collisionRadius = 0.0;
   mass            = 2.0;
   damageClass      = 1;       // 0 impact, 1, radius
   damageValue      = 0.05;
   damageType       = $StasisDamageType;
   explosionRadius  = 5.5;
   kickBackStrength = 50.0;

   muzzleVelocity   = 165.0;
   terminalVelocity = 180.0;
   acceleration     = 5.0;

   totalTime        = 3.5;
   liveTime         = 4.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   // rocket specific
   trailType   = 1;
   trailLength = 25;
   trailWidth  = 0.5;

   soundId = SoundStasisShot;
};


ItemData StasisAmmo
{	description = "Micro STASIS Shells";
	classname = "Ammo";
	shapeFile = "plasammo";		
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 20;
};

ItemImageData AODStasisGunImage
{	shapeFile		= "shotgun";
	mountPoint		= 0;		
	weaponType		= 0;		
	reloadTime		= 0.15;		
	fireTime		= 0.15;		
	minEnergy		= 5;		
	maxEnergy		= 10;		
	projectileType	= StasisShot;
	ammotype		= StasisAmmo;
	accuFire		= true;	
	mountOffset		= { -0.1, 0, 0 };
	mountRotation	= { 0, -2.00, 0};
	sfxFire			= SoundFireStasisCannon;
	sfxActivate		= SoundPickUpWeapon;
	sfxReady		= SoundStasisCannonIdle;
	sfxReload		= SoundReloadStasisCannon;

};

ItemData AODStasisGun
{   heading			= "bWeapons";
	description		= "Stasis-Cannon";
	classname		= "Weapon";
	shapeFile		= "shotgun";	
	hudIcon			= "plasma";	
	shadowDetailMask = 4;	
	imageType		= AODStasisGunImage;	
	price			= 450;				
	showWeaponBar	= true;		
};

function AODStasisGun::Help(%client)
{	%msg=HelpTitle("AODStasisGun: Alternate time/Reality Weapon");
	%msg=AddHelpLine(%msg,"Fires an energy blast which surrounds an area a 'warps'");
	%msg=AddHelpLine(%msg,"the reality in this small area so that time & mass are different");
	%msg=AddHelpLine(%msg,"Target can barely move & cant fly...Does not do much damage on it's own");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

// *************************************
//	REAPER Autocannon
// *************************************
$AutoUse[AODReaper]				= True;
$InvList[AODReaper]				= 1;	
$RemoteInvList[AODReaper]		= 1;	
$WeaponAmmo[AODReaper]			= ReaperAmmo;
$InvList[ReaperAmmo]			= 1;
$RemoteInvList[ReaperAmmo]		= 1;
$SellAmmo[ReaperAmmo]			= 25;

$ItemMax[larmor,AODReaper]		= 0;
$ItemMax[lfemale,AODReaper]		= 0;
$ItemMax[marmor,AODReaper]		= 0;
$ItemMax[mfemale,AODReaper]		= 0;
$ItemMax[harmor,AODReaper]		= 1;

$ItemMax[larmor,ReaperAmmo]		=0;
$ItemMax[lfemale,ReaperAmmo]	=0;
$ItemMax[marmor,ReaperAmmo]		=0;
$ItemMax[mfemale,ReaperAmmo]	=0;
$ItemMax[harmor,ReaperAmmo]		=150;


ExplosionData ReaperExp0
{
   shapeName = "plastrail.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData ReaperExp1
{
   shapeName = "flash_small.dts";
   soundId   = shockExplosion;
   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 8.0;

   timeScale = 1.5;

   timeZero = 0.0;
   timeOne  = 0.500;

   colors[0]  = { 0.0, 0.0, 0.0 };
   colors[1]  = { 1.0, 1.0, 1.0 };
   colors[2]  = { 1.0, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 1.0 };
};

ExplosionData ReaperExp2
{
   shapeName = "chainspk.dts";
   soundId   = ricochet3;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0,  0.0, 0.0 };
   colors[1]  = { 0.75, 1.0, 1.0 };
   colors[2]  = { 0.75, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData ReaperExp3
{
   shapeName = "chainspk.dts";
   soundId   = ricochet2;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0,  0.0, 0.0 };
   colors[1]  = { 0.75, 1.0, 1.0 };
   colors[2]  = { 0.75, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};

ExplosionData ReaperExp4
{
   shapeName = "chainspk.dts";
   soundId   = ricochet1;

   faceCamera = true;
   randomSpin = true;
   hasLight   = true;
   lightRange = 1.0;

   timeZero = 0.100;
   timeOne  = 0.900;

   colors[0]  = { 0.0,  0.0, 0.0 };
   colors[1]  = { 0.75, 1.0, 1.0 };
   colors[2]  = { 0.75, 1.0, 1.0 };
   radFactors = { 0.0, 1.0, 0.0 };

   shiftPosition = True;
};


BulletData ReaperShot
{	bulletShapeName    = "plastrail.dts";
	explosionTag       = ReaperExp0;
	expRandCycle       = 5;
	mass               = 0.05;
	bulletHoleIndex    = 0;
	damageClass        = 0;       // 0 impact, 1, radius
	damageValue        = 0.1;
	damageType         = $ReaperDamageType;
	aimDeflection      = 0.005;
	muzzleVelocity     = 150.0;
	kickBackStrength   = 75.0;
	totalTime          = 0.5;
	inheritedVelocityScale = 0.5;
	isVisible          = false;
	lightRange         = 3.0;
	lightColor         = { 0.75, 0.75, 0.25 };
	tracerPercentage   = 0.25;
	tracerLength       = 15;
};

ItemData ReaperAmmo
{	description = "Reaper Ammo";
	classname = "Ammo";
	shapeFile = "ammo1";
	heading = "xAmmunition";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData AODReaperImage
{	shapeFile		= "chaingun";
	mountPoint		= 0;
	mountOffset		= { 0.1, 0, 0 };
	mountRotation	= { 0, 1.57, 0};
	weaponType		= 1; // Spinning
	reloadTime		= 0;
	spinUpTime		= 0.25;
	spinDownTime	= 1;
	fireTime		= 0.12;
	ammoType		= ReaperAmmo;
	projectileType	= ReaperShot;
	accuFire		= false;
	lightType		= 3;  // Weapon Fire
	lightRadius		= 3;
	lightTime		= 1;
	lightColor		= { 0.6, 1, 1 };
	sfxFire			= SoundFireReaper;
	sfxActivate		= SoundPickUpWeapon;
	sfxSpinUp		= SoundSpinUpReaper;
	sfxSpinDown		= SoundSpinDownReaper;
};

ItemData AODReaper
{   description		= "Reaper AutoCannon";
	classname		= "Weapon";
	shapeFile		= "chaingun";
	hudIcon			= "chain";
	heading			= "bWeapons";
	shadowDetailMask = 4;
	imageType		= AODReaperImage;
	price			= 425;
	showWeaponBar	= true;
};

function AODReaper::Help(%client)
{	%msg=HelpTitle("Reaper-Cannon: Rapid Fire Minigun with explosive bullets");
	%msg=AddHelpLine(%msg,"Designed for Heavies to keep those pesky lights");
	%msg=AddHelpLine(%msg,"at bay. Rapid Fire means it chews through ammo but then");
	%msg=AddHelpLine(%msg,"Life can be expensive..");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}


//****************************************************
// AAOD Mod BACKPACK Kit
//************************************
//----------------------------------------------------------------------------
// ====================================
//		**** SuperRepair Pack ****
// ++++++++++++++++++++++++++++++++++++
//	Useable Only By Heavies....
//	Repairs Items Very Fast
//	Occupies 2 Slots BackPack & Flag
//	Can only Be unmounted At Inventory Station
//	Has 4 x The Rnage of normal repair bolts
//	Has 2 x the repair speed of normal Packs
//	Uses 11/3 the energy

$InvList[AODSuperRPack]				= 1;
$RemoteInvList[AODSuperRPack]		= 1;

$ItemMax[larmor, AODSuperRPack]			= 0;
$ItemMax[lfemale, AODSuperRPack]		= 0;
$ItemMax[marmor, AODSuperRPack]			= 0;
$ItemMax[mfemale, AODSuperRPack]		= 0;
$ItemMax[harmor, AODSuperRPack]			= 1;


RepairEffectData SuperRBolt
{	bitmapName			= "LightningNew.bmp";
	boltLength			= 20.0;
	segmentDivisions	= 6;
	beamWidth			= 0.175;
	updateTime			= 450;
	skipPercent			= 0.6;
	displaceBias		= 0.15;
	lightRange			= 6.0;
	lightColor			= { 0.85, 0.25, 0.25 };
};

ItemImageData SuperRPackImage
{	shapeFile		= "armorPack";
	mountPoint		= 2;
	weaponType		= 2;  // Sustained
	minEnergy		= 0;
	maxEnergy		= 0;   // Energy used/sec for sustained weapons
  	mountOffset		= { 0, -0.05, 0 };
  	mountRotation	= { 0, 0, 0 };
	firstPerson		= false;
};

ItemData AODSuperRPack
{	description		= "Super-Repair Pack";
	shapeFile		= "armorPack";
	className		= "Backpack";
	heading			= "cBackpacks";
	shadowDetailMask = 4;
	imageType		= SuperRPackImage;
	price			= 750;
	hudIcon			= "repairpack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

ItemImageData SuperR2Image
{	shapeFile		= "armorPack";
	mountPoint		= 2;
	weaponType		= 2;  // Sustained
	minEnergy		= 0;
	maxEnergy		= 0;   // Energy used/sec for sustained weapons
  	mountOffset		= { 0, -0.05, -0.10 };
  	mountRotation	= { 0, 3.14159, -0.015 };
	firstPerson		= false;
};

ItemData SuperR2Pack
{	description		= "Super-Repair Pack";
	shapeFile		= "armorPack";
	className		= "Backpack";
	heading			= "cBackpacks";
	shadowDetailMask = 4;
	imageType		= SuperR2Image;
	hudIcon			= "repairpack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

ItemImageData SuperRGunImage
{	shapeFile		= "repairgun";
	mountPoint		= 0;
	mountOffset		= { -0.15, 0, 0 };
	mountRotation	= { 0, 1.57, 0};
	weaponType		= 2;	// Sustained
	projectileType	= SuperRBolt;
	minEnergy		= 3;
	maxEnergy		= 13;	// Energy used/sec for sustained weapons
	lightType		= 3;	// Weapon Fire
	lightRadius		= 1;
	lightTime		= 1;
	lightColor		= { 0.25, 1, 0.25 };
	sfxActivate		= SoundPickUpWeapon;
	sfxFire			= SoundSuperROn;
};

ItemData AODSuperRGun
{	description		= "Super-Repair Gun";
	shapeFile		= "repairgun";
	className		= "Weapon";
	shadowDetailMask = 4;
	imageType		= SuperRGunImage;
	showInventory	= false;
	price			= 150;
};

function AODSuperRPack::Help(%client)
{	%msg=HelpTitle("Super-Repair Pack:  For Heavies Only");
	%msg=AddHelpLine(%msg,"Uses Backpack & Flag Slot - Cannot Be dropped MUST be SOLD.");
	%msg=AddHelpLine(%msg,"Repairs Twice as fast. uses only 1.3 times as much power");
	%msg=AddHelpLine(%msg,"Has 4 Times the range of a regular Repair Pack");
	%msg=AddHelpLine(%msg,"Need - New AAODSFX Sound Pack to Hear the Sound. www.bdtech.net/aaod ");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}
function AODSuperRPack::onUnmount(%player,%item)
{	if (Player::getMountedItem(%player,$WeaponSlot) == AODSuperRGun) 
	{	Player::unmountItem(%player,$WeaponSlot);
	}
	Player::UnMountItem(%player,$FlagSlot);
}

function AODSuperRPack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	
	}
	else
	{	Player::mountItem(%player,AODSuperRGun,$WeaponSlot);
	}
}

function AODSuperRPack::onMount(%player,%item)
{	Player::mountItem(%player,SuperR2Pack,$FlagSlot);
}

function AODSuperRPack::onDrop(%player,%item)
{	%client = Player::getClient(%player);
	Client::SendMessage(%client,0,"Unable to DROP this type of Pack. Must BE Sold at an Inventory Station~wAAODSFX14.WAV");
}	

function AODSuperRGun::onMount(%player,%imageSlot)
{	Player::trigger(%player,$BackpackSlot,true);
	Player::trigger(%player,$FlagSlot,true);
}

function AODSuperRGun::onUnmount(%player,%imageSlot)
{	Player::trigger(%player,$BackpackSlot,false);
	Player::trigger(%player,$FlagSlot,false);
}



//******************************************************
//				End Super Repair Pack
//******************************************************


// ====================================
//		**** AAOD Combo Pack1  ****
// ++++++++++++++++++++++++++++++++++++
//	Useable Only By Medium & Heavies....
//	Combo ShieldPack/EnergyPack


$InvList[AODCombo1Pack]				= 1;
$RemoteInvList[AODCombo1Pack]		= 1;

$ItemMax[larmor, AODCombo1Pack]			= 0;
$ItemMax[lfemale, AODCombo1Pack]		= 0;
$ItemMax[marmor, AODCombo1Pack]			= 1;
$ItemMax[mfemale, AODCombo1Pack]		= 1;
$ItemMax[harmor, AODCombo1Pack]			= 1;

//----------------------------------------------------------------------------
ItemImageData Combo1PackImage
{	shapeFile		= "shieldPack";
	mountOffset		= { 0, 0, 0.12 };
	mountRotation	= { 0 ,0 , 0};
	mountPoint		= 2;
	weaponType		= 2;  // Sustained
	minEnergy		= 4;
	maxEnergy		= 9;   // Energy/sec for sustained weapons
	sfxFire			= SoundShieldOn;
	firstPerson		= false;
};

ItemData AODCombo1Pack
{	description		= "Energy + Shield Pack";
	shapeFile		= "shieldPack";
	className		= "Backpack";
	heading			= "cBackpacks";
	shadowDetailMask = 4;
	imageType		= Combo1PackImage;
	price			= 650;
	hudIcon			= "shieldpack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

ItemImageData Combo1APackImage
{	shapeFile		= "jetPack";
	weaponType		= 2;  // Sustained
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, -0.15 };
	minEnergy		= -1;
 	maxEnergy		= -3.5;
	firstPerson		= false;
	Mass			= 1.5;
};

ItemData Combo1APack
{	description		= "COMBO 1 Energy/Shield Pack";
	shapeFile		= "jetPack";
	className		= "Backpack";
	heading			= "cBackpacks";
	shadowDetailMask = 4;
	imageType		= Combo1APackImage;
	price			= 650;
	hudIcon			= "energypack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODCombo1Pack::Help(%client)
{	%msg=HelpTitle("Advanced Energy + Shield COMBO Pack:  For Mediums & Heavies");
	%msg=AddHelpLine(%msg,"Uses Backpack & Flag Slot - Cannot Be dropped MUST be SOLD.");
	%msg=AddHelpLine(%msg,"Provides the benifits of Having Both a Shield and ");
	%msg=AddHelpLine(%msg,"an energy Pack. The Energy Pack in this version is a little");
	%msg=AddHelpLine(%msg,"better than the std. one to handle the extra load.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

function AODCombo1Pack::onMount(%player,%item)
{	
	Player::mountItem(%player,Combo1APack,$FlagSlot);
	Player::trigger(%player,$FlagSlot,true);
}

function AODCombo1Pack::onUnmount(%player,%item)
{	Player::UnmountItem(%player,$FlagSlot);
}

function Combo1PackImage::onActivate(%player,%imageSlot)
{	echo("AOD Combo1 Pack on Activate");
	Client::sendMessage(Player::getClient(%player),0,"Shield On");
	Player::trigger(%player,$BackPackSlot,true);
	%player.shieldStrength = 0.012;
}

function Combo1PackImage::onDeactivate(%player,%imageSlot)
{	echo("AOD Combo1 Pack on DeActivate");
	Client::sendMessage(Player::getClient(%player),0,"Shield Off");
	Player::trigger(%player,$BackPackSlot,false);
	%player.shieldStrength = 0;
}

function AODCombo1Pack::onDrop(%player,%item)
{	%client = Player::getClient(%player);
	Client::SendMessage(%client,0,"Unable to DROP this type of Pack. Must BE Sold at an Inventory Station~WAAODSFX14.WAV");
}	

// ====================================
//		**** AAOD Combo Pack2  ****
// ++++++++++++++++++++++++++++++++++++
//	Useable Only By Medium & Heavies....
//	Combo SensorJammer/EnergyPack


$InvList[AODCombo2Pack]				= 1;
$RemoteInvList[AODCombo2Pack]		= 1;

$ItemMax[larmor, AODCombo2Pack]			= 0;
$ItemMax[lfemale, AODCombo2Pack]		= 0;
$ItemMax[marmor, AODCombo2Pack]			= 1;
$ItemMax[mfemale, AODCombo2Pack]		= 1;
$ItemMax[harmor, AODCombo2Pack]			= 1;

//----------------------------------------------------------------------------
ItemImageData Combo2PackImage
{	shapeFile		= "sensorjampack";
	mountPoint		= 2;
	weaponType		= 2;  // Sustained
	maxEnergy		= 10;  // Energy used/sec for sustained weapons
	sfxFire			= SoundJammerOn;
  	mountOffset		= { 0, -0.05, 0.12 };
  	mountRotation	= { 0, 0, 0 };
	firstPerson		= false;
};

ItemData AODCombo2Pack
{	description		= "Energy + Jammer Pack";
	shapeFile		= "sensorjampack";
	className		= "Backpack";
	heading			= "cBackpacks";
	shadowDetailMask = 4;
	imageType		= Combo2PackImage;
	price			= 700;
	hudIcon			= "sensorjamerpack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODCombo2Pack::Help(%client)
{	%msg=HelpTitle("Advanced Energy + Sensor Jammer COMBO Pack:  For Mediums & Heavies");
	%msg=AddHelpLine(%msg,"Uses Backpack & Flag Slot - Cannot Be dropped MUST be SOLD.");
	%msg=AddHelpLine(%msg,"Provides the benifits of Having Both a Sensor Jammer and ");
	%msg=AddHelpLine(%msg,"an energy Pack. The Energy Pack in this version is a little");
	%msg=AddHelpLine(%msg,"better than the std. one to handle the extra load.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

function Combo2PackImage::onActivate(%player,%imageSlot)
{	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer On");
	%rate = Player::getSensorSupression(%player) + 20;
	Player::setSensorSupression(%player,%rate);
}

function Combo2PackImage::onDeactivate(%player,%imageSlot)
{	Client::sendMessage(Player::getClient(%player),0,"Sensor Jammer Off");
	%rate = Player::getSensorSupression(%player) - 20;
	Player::setSensorSupression(%player,%rate);
	Player::trigger(%player,$BackpackSlot,false);
}

function AODCombo2Pack::onMount(%player,%item)
{	Echo("AOD Combo2Pack Trigger Energy Pack");
	Player::mountItem(%player,Combo1APack,$FlagSlot);
	Player::trigger(%player,$FlagSlot,true);
}

function AODCombo2Pack::onUnmount(%player,%item)
{	Player::UnmountItem(%player,$FlagSlot);
}


function AODCombo2Pack::onDrop(%player,%item)
{	%client = Player::getClient(%player);
	Client::SendMessage(%client,0,"Unable to DROP this type of Pack. Must BE Sold at an Inventory Station~WAAODSFX14.WAV");
}	


//----------------------------------------------------------------------------
// ====================================
//		**** AAOD Combo Pack3  ****
// ++++++++++++++++++++++++++++++++++++
//	Useable Only By Medium & Heavies....
//	Combo Ammo/EnergyPack

$InvList[AODCombo3Pack]				= 1;
$RemoteInvList[AODCombo3Pack]		= 1;

$ItemMax[larmor, AODCombo3Pack]			= 1;
$ItemMax[lfemale, AODCombo3Pack]		= 1;
$ItemMax[marmor, AODCombo3Pack]			= 1;
$ItemMax[mfemale, AODCombo3Pack]		= 1;
$ItemMax[harmor, AODCombo3Pack]			= 1;

//----------------------------------------------------------------------------

ItemImageData Combo3PackImage
{	shapeFile	= "AmmoPack";
	mountPoint	= 2;
	mountOffset = { 0, 0, 0 };
	firstPerson = false;
	mass		= 1.25;
};

ItemData AODCombo3Pack
{	description		= "Ammo + Energy Pack";
	shapeFile		= "AmmoPack";
	className		= "Backpack";
	heading			= "cBackpacks";
	imageType		= Combo3PackImage;
	shadowDetailMask = 4;
	mass			= 2.0;
	elasticity		= 0.2;
	price			= 725;
	hudIcon			= "ammopack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODCombo3Pack::Help(%client)
{	%msg=HelpTitle("Advanced Energy + Ammo COMBO Pack:  For ALL Classes");
	%msg=AddHelpLine(%msg,"Uses Backpack & Flag Slot - Cannot Be dropped MUST be SOLD.");
	%msg=AddHelpLine(%msg,"Provides the benifits of Having Both an AMMO Pack and ");
	%msg=AddHelpLine(%msg,"an energy Pack. The Energy Pack in this version is a little");
	%msg=AddHelpLine(%msg,"better than the std. one to handle the extra load.");
	%msg=AddHelpLine(%msg,"*** CANNOT GRAB FLAG with this PACK!!");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

function AODCombo3Pack::onMount(%player,%item)
{	Player::mountItem(%player,Combo1APack,2);
	Player::trigger(%player,$FlagSlot,true);
}


function AODCombo3Pack::onUnmount(%player,%item)
{	Player::UnmountItem(%player,$FlagSlot);
}

function AODCombo3Pack::onDrop(%player,%item)
{	%client = Player::getClient(%player);
	Client::SendMessage(%client,0,"Unable to DROP this type of Pack. Must BE Sold at an Inventory Station~WAAODSFX14.WAV");
}	


// ====================================
//		**** AAOD Combo Pack4  ****
// ++++++++++++++++++++++++++++++++++++
//	Useable By All Classes....
//	Combo ShieldPack/EnergyPack


$InvList[AODCombo4Pack]				= 1;
$RemoteInvList[AODCombo4Pack]		= 1;

$ItemMax[larmor, AODCombo4Pack]			= 1;
$ItemMax[lfemale, AODCombo4Pack]		= 1;
$ItemMax[marmor, AODCombo4Pack]			= 1;
$ItemMax[mfemale, AODCombo4Pack]		= 1;
$ItemMax[harmor, AODCombo4Pack]			= 1;

//----------------------------------------------------------------------------

ItemImageData Combo4PackImage
{	shapeFile	= "armorPack";
	mountPoint	= 2;
	weaponType	= 2;  // Sustained
	minEnergy	= 0;
	maxEnergy	= 4;   // Energy used/sec for sustained weapons
  	mountOffset = { 0, -0.05, 0 };
  	mountRotation = { 0, 0, 0 };
	firstPerson = false;
};

ItemData AODCombo4Pack
{	description = "Repair + Energy Pack";
	shapeFile	= "armorPack";
	className	= "Backpack";
	heading		= "cBackpacks";
	shadowDetailMask = 4;
	imageType	= Combo4PackImage;
	price		= 725;
	hudIcon		= "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};


ItemImageData Combo4APackImage
{	shapeFile		= "jetPack";
	weaponType		= 2;  // Sustained
	mountPoint		= 2;
	mountOffset		= { 0, -0.1, -0.15 };
	minEnergy		= -1;
 	maxEnergy		= -3;
	firstPerson		= false;
	Mass			= 1.5;
};

ItemData Combo4APack
{	description		= "Energy COMBO Pack";
	shapeFile		= "jetPack";
	className		= "Backpack";
	heading			= "cBackpacks";
	shadowDetailMask = 4;
	imageType		= Combo4APackImage;
	price			= 650;
	hudIcon			= "energypack";
	showWeaponBar	= true;
	hiliteOnActive	= true;
};

function AODCombo4Pack::onUnmount(%player,%item)
{	if (Player::getMountedItem(%player,$WeaponSlot) == RepairGun) 
	{	Player::unmountItem(%player,$WeaponSlot);
	}
}

function AODCombo4Pack::onUse(%player,%item)
{	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
	}
	else 
	{	Player::mountItem(%player,RepairGun,$WeaponSlot);
	}
}

function AODCombo4Pack::onDrop(%player,%item)
{	%client = Player::getClient(%player);
	Client::SendMessage(%client,0,"Unable to DROP this type of Pack. Must BE Sold at an Inventory Station~WAAODSFX14.WAV");
}	

function AODCombo4Pack::Help(%client)
{	%msg=HelpTitle("Advanced Repair + Energy COMBO Pack:  For ALL Classes");
	%msg=AddHelpLine(%msg,"Uses Backpack & Flag Slot - Cannot Be dropped MUST be SOLD.");
	%msg=AddHelpLine(%msg,"Provides the benifits of Having Both a repair and ");
	%msg=AddHelpLine(%msg,"an energy Pack.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}

function AODCombo4Pack::onMount(%player,%item)
{	Player::mountItem(%player,Combo4APack,$FlagSlot);
	Player::trigger(%player,$FlagSlot,true);
}

function AODCombo4Pack::onUnmount(%player,%item)
{	Player::UnmountItem(%player,$FlagSlot);
}

//**************************************
//	End Combo Pack Scripts
//**************************************


// 	AODCmdPack Backpack Script
$InvList[AODCmdPack]			= 1;
$RemoteInvList[AODCmdPack]		= 1;
$TeamItemMax[AODCmdPack]		= 1;

$ItemMax[larmor, AODCmdPack]	= 1;
$ItemMax[lfemale, AODCmdPack]	= 1;
$ItemMax[marmor, AODCmdPack]	= 1;
$ItemMax[mfemale, AODCmdPack]	= 1;
$ItemMax[harmor, AODCmdPack]	= 1;

ItemImageData AODCmdPackImage 
{	shapeFile		= "ammounit_remote";
	mountPoint		= 2;
	mountOffset		= { 0, -0.25, 0.5 };
	mountRotation	= { 0, 3.141592654, 0 };
	mass			= 3.0;
	firstPerson		= false;
};

ItemData AODCmdPack 
{	description = "Command BackPack";
	shapeFile = "CMDPNL";
	classname = "Backpack";
	heading = "cBackpacks";
	imageType = AODCmdPackImage;
	shadowDetailMask = 4;
	mass = 3.0;
	elasticity = 0.2;
	price = 250;
	hudIcon = "repairpack";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function AODCmdPack::Help(%client)
{	%msg=HelpTitle("Command Pack: Portable Command Centre");
	%msg=AddHelpLine(%msg,"Allows any Class of Character to access all the command");
	%msg=AddHelpLine(%msg,"functions just as if he was at a real command station.");
	topPrint(%client,%Msg,8);
	Client::sendMessage(%client,0,"~wAAODSFX18.wav");
}


function AODCmdPack::onUse(%player,%item)
{	if($trace) echo( $ver@"|Command Pack on Use");
	%client = Player::getClient(%player);
	if (Player::getMountedItem(%player,$BackpackSlot) != %item) 
	{	Player::mountItem(%player,%item,$BackpackSlot);
		// if($trace) echo( $ver@"|mounting Command Pack");
	}
	else 
	{	remoteCommandMode(%client);	// This Portion here brings up the command screen when the 'PACK' key is pressed
		if($trace) echo( $ver@"|accessing Command Functions");
	}
}

function Client::takeControl(%clientId, %objectId)
{	if($trace) echo( $ver@"|function Client::takeControl(%clientId, %objectId)");
	if(%objectId == -1)
	{  return;  }
	%pl = Client::getOwnedObject(%clientId);
	if(%pl.driver != "" || %pl.vehicleSlot != "")
		return;
	if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
	{	return;  }
	if(GameBase::getControlClient(%objectId) != -1)
	{	// if($trace) echo( $ver@"|Ctrl Client = " @ GameBase::getControlClient(%objectId));
		return;
	}
	%name = GameBase::getDataName(%objectId);
	if (%name==AATurret)
	{	Client::SendMessage(%clientId,0,"UNABLE to Manually Control AA Turret!!");
		return;
	}
	
	if (%name==ArtilleryTurret)	// Activate Counter Battery Stuff...If it Exists
	{	%team=GameBase::getTeam(%ObjectId);
		if(%team==0)
			%enemy=1;
		else if(%team==1)
			%enemy=0;
		if($CounterBattery[%enemy])	// Other Team has a counter Battery sensor
		{	DesignateTarget(%objectId,30,false);
		}
	}
		
	if((%name != CameraTurret && %name != DeployableTurret) && (%name!=SAMTurret && %name != GROGTurret) && (%name != INFERNOMine && %name != VELCROTurret)&& (%name != ArtilleryTurret && %name!=AssaultDesignator)&& (%name != DefenderTurret && %name != MORTTurret))
	{	if(!GameBase::isPowered(%objectId))
		{	return;	}
	}
	if (Player::getMountedItem(%clientId,$BackpackSlot) != AODCmdPack) 
	{	if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret && !$TestCheats) 
		{	Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
			return;
		}
	}
	if(GameBase::getDamageState(%objectId) == "Enabled") 
	{	Client::setControlObject(%clientId, %objectId);
		Client::setGuiMode(%clientId, $GuiModePlay);
	}
}
