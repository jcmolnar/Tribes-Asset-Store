

function kickback(%object, %kickback) // Kickback
{
	%rot = GameBase::getRotation(%object); 
	%kick = Vector::getFromRot(%rot,%kickback,0);
	Player::applyImpulse(%object,%kick);
}

function useEnergy(%object, %energyUse) // Energy Usage
{
	%energy = GameBase::getEnergy(%object); 
 	%energy -= %energyUse;
	GameBase::setEnergy(%object,%energy);
}

function sin(%theta) // Sine & Cosine functions... useful for 3D Manipulation
{ 
	%sin = (%theta - (pow(%theta,3)/6) + (pow(%theta,5)/120) - (pow(%theta,7)/5040) + (pow(%theta,9)/362880) - (pow(%theta,11)/39916800));
	return %sin;
}

function cos(%theta) 
{
	%cos = (1 - (pow(%theta,2)/2) + (pow(%theta,4)/24) - (pow(%theta,6)/720) + (pow(%theta,8)/40320) - (pow(%theta,10)/3628800));
	return %cos;
}

function newVector(%vec, %scalar) // ?  (One of Valya's functions)
{	
	%nVec  = Vector::dot(%vec,%scalar @ " 0 0") @ " " @ Vector::dot(%vec,"0 " @ %scalar @ " 0") @ " " @ Vector::dot(%vec,"0 0 " @ %scalar);
	return %nVec;
}

function fireWeapon(%object,%projectile,%target,%num,%energyUse,%heatIncrease,%sound,%ammoType,%ammoDecrease,%kickback) // heatIncrease for Eradicator use only!! 
{
	%trans = GameBase::getMuzzleTransform(%object); // Location, Transform, Object Protocols
	%vel = Item::getVelocity(%object); 
	%pos = GameBase::getPosition(%object);
	%client = Player::getClient(%object);
if(%client.isafk){
		%client.isafk = false;
		messageall(1, $adminbotname @": "@Client::getName(%client)@" is now back and may be hurt");
		
	}

	if(%ammoType != false) 
	{
		if(Player::getItemCount(%object,%ammoType)) // Ammo checking script
		{
			Player::decItemCount(%object,%ammoType,%ammoDecrease);
		}
		else
		{
			Player::trigger(%object,$WeaponSlot,false);
			return false;
		}
	}

	kickback(%object,%kickback); 
	useEnergy(%object,%energyUse);

	if(%object.outArea) // OB check
		GameBase::applyDamage(%object,$DebrisDamageType,10,%pos,"0 0 0","0 0 0",%object);

	if($Eradicator::Authentic) // Using heatIncrease is only for use in Eradicator
		Player::incItemCount(%object,HeatValue,%heatIncrease);

	if(%sound != false) // Plays a sound, if there is one
		playSound(%sound, %pos);

	// Passed Validation.... FIRE!!
	if(%num > 1) // Multiple Weapons fire support
	{
		for(%p; %p < %num + 1; %p++) // Streamlined multiple weapons fire.. hehe
			Projectile::spawnProjectile(%projectile, %trans, %object, %vel, %target);
		
		return true;	
	}
	else if(%num = 1)
	{
		Projectile::spawnProjectile(%projectile, %trans, %object, %vel, %target);
		return true;
	}
	else
	{
		return false; // heh, just in case :)
	}
}

function Meltdown::getFOVInfo(%this,%pos) // derived from my original invention in Meltdown.
{
	%team = GameBase::getTeam(%this);
	%set1 = newObject("set1",SimSet);
	%set2 = newObject("set2",SimSet);
	%VehicleFOV = containerBoxFillSet(%set1,$VehicleObjectType,%pos,$MLRadarSize,$MLRadarSize,$MLRadarSize,0); // Would often move out of range
	%PlayerFOV = containerBoxFillSet(%set2,$SimPlayerObjectType,%pos,$MLRadarSize,$MLRadarSize,$MLRadarSize,0); // Would often move out of range

	if (%VehicleFOV > 0)
	{	
		for (%i=0; %i<%VehicleFOV; %i++)
		{	
			%tgt = Group::getObject(%set1,%i);
			%tgtTeam = GameBase::getTeam(%tgt);

			if(%team != %tgtTeam) 
				%target = %tgt;

			if(%target)
			{	
				%i = %VehicleFOV;
				%VTarg = "true";
			}
			
		}

	}
	if(%VTarg)
	{
		deleteObject(%set1);
		return(%target);
	}

	else if (%PlayerFOV > 0)
	{	
		for (%i=0; %i<%PlayerFOV; %i++)
		{	
                  %tgt = Group::getObject(%set2,%i);
			%tgtTeam = GameBase::getTeam(%tgt);

			if(%team != %tgtTeam) 
				%target = %tgt;

			if(%target)
			{
				%i = %PlayerFOV;
				%PTarg = "true";
			}
		}
	}
	if(%PTarg)
	{
		deleteObject(%set2);
		return(%target);
	}
}

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
	if (%pack=="CloakingDevice")
	{	if($trace) echo($ver,"| Target Has Cloaking Pack =",%pack);
			%jamming=2;
	}

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
	{	%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType,%pos,512,512,512,0); // Would often move out of range
	}
	else if(%option==2)
	{
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,512,512,512,0);
	}
	else if(%option==3)
	{
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType | $StaticShapeType ,%pos,512,512,-512,0);
	}
	else 
		%tnum = containerBoxFillSet(%set,$SimPlayerObjectType | $VehicleObjectType ,%pos,512,512,512,0);
	
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

//--------------------------------------------------------------------------------------------------------
// Blaster
//--------------------------------------------------------------------------------------------------------

ItemImageData BlasterImage
{
   shapeFile  = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 0.3;
	minEnergy = 5;
	maxEnergy = 6;

	projectileType = BlasterBolt;
	accuFire = true;

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Blaster
{
   heading = "bEnergy Weapons";
	description = "Blaster";
	className = "Weapon";
   shapeFile  = "energygun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = BlasterImage;
	price = 85;
	showWeaponBar = true;
};

AddWeapon(Blaster);

$ItemMax[larmor, AODForceProj] = 1;
$ItemMax[lfemale, AODForceProj] = 1;
$ItemMax[marmor, AODForceProj] = 1;
$ItemMax[mfemale, AODForceProj] = 1;
$ItemMax[harmor, AODForceProj] = 1;
$ItemMax[BlastechM, AODForceProj] = 1;
$ItemMax[BlastechF, AODForceProj] = 1;
$ItemMax[MagIonM, AODForceProj] = 1;
$ItemMax[MagIonF, AODForceProj] = 1;
$ItemMax[MECH, AODForceProj] = 1;

AddWeapon(AODForceProj);
AddDeployable(EForcefield);

$AutoUse[AODForceProj]				= True;

$InvList[AODForceProj]			= 1;
$RemoteInvList[AODForceProj]		= 1;	

RepairEffectData ForceBolt
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

ItemImageData ForceProjImage
{	shapeFile		= "repairgun";
	mountPoint		= 0;
	mountOffset		= { -0.15, 0, 0 };
	mountRotation	= { 0, 3.14159, 0};
	weaponType		= 2;	// Sustained
	projectileType	= ForceBolt;
	minEnergy		= 2.5;
	maxEnergy		= 11;	// Energy used/sec for sustained weapons
	lightType		= 3;	// Weapon Fire
	lightRadius		= 1;
	lightTime		= 1;
	lightColor		= { 0.25, 1, 0.25 };
	sfxActivate		= SoundPickUpWeapon;
	sfxFire			= SoundSuperROn;
};

ItemData AODForceProj
{	description		= "Riot-Shield Projector";
	shapeFile		= "repairgun";
	className		= "tool";
	heading			= "iHeat Effect Weapons & Riot Tools";
	shadowDetailMask = 4;
	imageType		= ForceProjImage;
	//showInventory	= false;
	price			= 250;
};

// ----------------------------------
// End of AODForceProj
//-----------------------------------


StaticShapeData ForceFieldE
{	shapeFile		= "forcefield_4x17";
	debrisId		= defaultDebrisSmall;
	maxDamage		= 110;
	maxEnergy		= 250;
	visibleToSensor = true;
	isTranslucent	= true;
	description		= "Riot-Shield";
	shieldShapeName = "shield";
	classname		= "ForceField";
};

function ForceBolt::onAcquire(%this, %player, %target)
{
	%newPos = GetLOSOffset(%player,5);
	%newitem = newObject("EField",StaticShape,ForceFieldE,true);
	addToSet("MissionCleanup", %newitem);
	GameBase::setTeam(%newitem,%team);
	GameBase::setRotation(%newitem,%rot);
	GameBase::setPosition(%newitem,%Newpos);
	Playsound(ForcefieldClose,%pos);
	%target=%newitem;
	%player.EField = %newItem;
	%player.repairTarget = %player.EField;
	Player::trigger(%player, $WeaponSlot, true);
	}

function ForceBolt::onRelease(%this, %player)
{	
	if($matchStarted)
	{	deleteobject(%player.Efield);
		%client = Player::getClient(%player);
		Player::trigger(%player, $WeaponSlot, false);
	}
}

function ForceBolt::checkDone(%this, %player)
{	%Vector=GameBase::getMuzzleTransform(%Player);
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);
	
	%newPos=GetLOSOffset(%player,5);

	GameBase::setRotation(%player.efield,%rot);
	GameBase::setPosition(%player.efield,%Newpos);
}

function GetLOSOffset(%player,%offset)
{	%Vector=GameBase::getMuzzleTransform(%Player);
	%pos=Gamebase::GetPosition(%player);
	%rot=GameBase::GetRotation(%player);
	%rot2=GetWord(%Vector,6)@" "@GetWord(%Vector,7)@" "@GetWord(%Vector,8);


	%X1=Getword(%vector,1);
	%Y1=Getword(%vector,2);
	%Z1=Getword(%vector,3);

	%X2=Getword(%vector,6);
	%Y2=Getword(%vector,7);
	%Z2=Getword(%vector,8);

	%zo1=SIN(%YRot) * %offset;
	%zo2=COS(%XRot) * %offset;
	%l2=COS(%YRot) * %offset;

	%p1=Vector::getFromRot(%rot,%l2,%zo);
	%NewPos=Vector::Add(%Pos,%p1);
	return(%NewPos);
}
function AODForceProj::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f1>Riot-Shield Projector - Use this to protect yourself and your team - Can withstand a direct hit by Star Destroyer");
}


//-----------------------------------
// Beacon Gun Script
//-----------------------------------
$InvList[AODBeaconGun]			= 1;
$RemoteInvList[AODBeaconGun]	      = 1;		
$AutoUse[AODBeaconGun]			= True;
$WeaponAmmo[AODBeaconGun]		= Beacon;
AddWeapon(AODBeaconGun);

$ItemMax[larmor,AODBeaconGun]	= 1;
$ItemMax[lfemale,AODBeaconGun]	= 1;
$ItemMax[marmor,AODBeaconGun]	= 1;
$ItemMax[mfemale,AODBeaconGun]	= 1;
$ItemMax[harmor,AODBeaconGun]	= 1;
$ItemMax[BlastechF, AODBeaconGun] = 1;
$ItemMax[BlastechM, AODBeaconGun] = 1;
$ItemMax[MagIonM, AODBeaconGun] = 1;
$ItemMax[MagIonF, AODBeaconGun] = 1;
$ItemMax[MECH, AODBeaconGun] = 1;

ExplosionData AODBeaconGunExp
{	shapeName = "shockwave.dts";	
	soundId =  SoundBeaconExplosion;	
	faceCamera = true;				
	randomSpin = true;		
	hasLight = true;			
	lightRange = 9.0;			
	timeZero = 0.100;			
	timeOne = 0.900;			
	colors[0] = {0.5,0.4,0.2};
	colors[1] = {1.0,1.0,0.5};
	colors[2] = {0.0,1.0,0.0};
	radFactors = {0.5,1.0,0.0};
	shiftPosition = False;	
};

RocketData BeaconRocket
{	
	bulletShapeName		= "sensor_small.dts";
	explosionTag		= AODBeaconGunExp;
	#collideWithOwner	= true;
	#ownerGraceMS		= 750;
	collisionRadius		= 0.0;
	mass				= 1.0;

	damageClass			= 1;    
	damageValue			= 0.10;
	damageType			= $NullDamageType;
	explosionRadius		= 15.0;
	kickBackStrength	= 75.0;
	muzzleVelocity		= 75.0;
	terminalVelocity	= 25.0;
	acceleration		= 25.0;
	totalTime			= 220.0;
	liveTime			= 230.0;
	lightRange			= 5.0;
	lightColor			= { 0.2, 0.7, 0.5 };
	inheritedVelocityScale = 0.5;
	// rocket specific
	trailType = 1; 
	trailLength = 999; 
	trailWidth = 1.3; 

	soundId				= SoundJetHeavy;
};

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
	ammoType		= Beacon;
	accuFire		= true;
	sfxActivate		= SoundPickUpWeapon;
};

ItemData AODBeaconGun
{	heading				= "jTools";
	description			= "Air-Strike Beacon Gun";
	classname			= "Weapon";
	shapeFile			= "PaintGun";
	hudIcon				= "mortar";	
	shadowDetailMask	= 4;
	imageType			= AODBeaconGunImage;	
	price				= 450;				
	showWeaponBar		= true;	
};

function DeployRBeacon(%player)
{	
	%c = Player::getClient(%player);
	%position = $Location;
	%rot = $Rotation;
	%beacon = newObject("Air-Strike Beacon", "StaticShape", "DefaultBeacon", true);
	addToSet("MissionCleanup", %beacon);
	GameBase::setTeam(%beacon,GameBase::getTeam(%player));
	GameBase::setRotation(%beacon,%rot);
	GameBase::setPosition(%beacon,%position);
	Gamebase::setMapName(%beacon,"Air-Strike Beacon");
	Beacon::onEnabled(%beacon);
	DeathFromAbove2(%position, %beacon, %player);
	client::sendMessage(%c,1,"Air-Strike Approved... Gunship Is Moving In for Carpet Bombing ~wmine_act.wav");
}

function AODBeaconGunImage::onFire(%player,%slot)
{	
	%client = GameBase::getOwnerClient(%player);
	%AmmoCount = (Player::getItemCount(%player, $WeaponAmmo[AODBeaconGun]) && Player::getItemCount(%player,Beacon)) ;
	
	if(%AmmoCount)
	{	
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		
		if(GameBase::getLOSInfo(%player,900))
		{	
			%object = getObjectType($los::object);
			
			if (%object!="Player" && %object !="Flier" && %object !="") // == "SimTerrain" || %object == "InteriorShape" || %object=="StaticShape") 
			{	
				
				if (Vector::dot($los::normal,"0 0 1") > 0.6) 
				{	
					%rot = "0 0 0";
				}
				else 
				{	
					if (Vector::dot($los::normal,"0 0 -1") > 0.6) 
					{	
						%rot = "3.14159 0 0";	
					}
					else 
					{	
						%rot = Vector::getRotation($los::normal);
					}
				}
				%team = GameBase::getTeam(%player);
				
				if($TeamItemMax[Beacon] > $TeamItemCount[%team @ Beacon] && $Airstrike != "true") 
				{	
					%Dist = Vector::getDistance(GameBase::getPosition(%player),$los::position);
					if(%Dist == 0)
					{	
						%tTime=1;
					}
					else
					{	
						%tTime=%Dist/25;
					}
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("BeaconRocket",%trans,%player,%vel,$los::object);
					playSound(SoundMissileReload, GameBase::getPosition(%player));
					GiveKickBack(%player, 15, 1);
					$Location = $los::position;
					$Rotation = %rot;
					schedule("DeployRBeacon(" @ %player @ " );",%tTime);
					Player::decItemCount(%player,Beacon);
					$Airstrike = "true";
				}
				else
				Client::sendMessage(%client,3,"Cannot call more than one Air-Strike at once! ~Error_Message.wav");
			}
			else
			Client::sendMessage(%client,3,"** Invalid Target - Unable to attach to Object! ** ~wError_Message.wav");
		}
		else
		Client::sendMessage(%client,3,"** Object Out of Range !! ** ~wError_Message.wav");
	}
	else
	{	if (!Player::getItemCount(%player, $WeaponAmmo[AODBeaconGun]))
	{	Client::sendMessage(%client,3,"** Out of Beacons!! ** ~waccess_denied.wav");}
	else
	{ 	Client::sendMessage(%client,3,"** Out of Beacons!! ** ~waccess_denied.wav");}
	}

}
//--------------------------------------------------------------------------------------------------------
// Ion Cannon
//--------------------------------------------------------------------------------------------------------

ItemImageData IonCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0 };

	weaponType = 0; // Single Shot
	minEnergy = 14; 
	maxEnergy = 15; 
	reloadTime = 0.65;
	fireTime = 0;

	projectileType = IonBolt; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData IonCannon
{
	description = "Ion Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = IonCannonImage;
	price = 255;
	showWeaponBar = true;
};

function IonCannon::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	Player::mountItem(%player,IonChargerA,$ExtraWeaponSlotA);
	Player::mountItem(%player,IonChargerB,$ExtraWeaponSlotB);
	Player::mountItem(%player,IonChargerC,$ExtraWeaponSlotC);
}

function IonCannon::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unmountItem(%player,$ExtraWeaponSlotA);
	Player::unmountItem(%player,$ExtraWeaponSlotB);
	Player::unmountItem(%player,$ExtraWeaponSlotC);
}

ItemImageData IonChargerAI
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.25 };

	weaponType = 0; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = IonBolt; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData IonChargerA
{
	description = "Ion Charger A";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = IonChargerAI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData IonChargerBI
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { 0.15, 0, 0 };

	weaponType = 0; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = IonBolt; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData IonChargerB
{
	description = "Ion Charger B";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = IonChargerBI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};


ItemImageData IonChargerCI
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountOffset = { -0.15, 0, 0 };

	weaponType = 0; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = IonBolt; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData IonChargerC
{
	description = "Ion Charger C";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = IonChargerCI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

$InvList[IonCannon] = 1;
$RemoteInvList[IonCannon] = 1;

$ItemMax[larmor, IonCannon] = 0;
$ItemMax[lfemale, IonCannon] = 0;
$ItemMax[marmor, IonCannon] = 1;
$ItemMax[mfemale, IonCannon] = 1;
$ItemMax[harmor, IonCannon] = 1;
$ItemMax[BlastechM, IonCannon] = 0;
$ItemMax[BlastechF, IonCannon] = 0;
$ItemMax[MagIonM, IonCannon] = 1;
$ItemMax[MagIonF, IonCannon] = 1;
$ItemMax[MECH, IonCannon] = 1;

AddWeapon(IonCannon);

//--------------------------------------------------------------------------------------------------------
// Omega Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData OmegaRifleImage
{
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = OmegaBolt;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData OmegaRifle
{
   description = "Reflux Rifle";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bEnergy Weapons";
   shadowDetailMask = 4;
   imageType = OmegaRifleImage;
	showWeaponBar = true;
   price = 500;
};

$InvList[OmegaRifle] = 1;
$RemoteInvList[OmegaRifle] = 1;

$ItemMax[larmor, OmegaRifle] = 0;
$ItemMax[lfemale, OmegaRifle] = 0;
$ItemMax[marmor, OmegaRifle] = 1;
$ItemMax[mfemale, OmegaRifle] = 1;
$ItemMax[harmor, OmegaRifle] = 1;
$ItemMax[BlastechM, OmegaRifle] = 0;
$ItemMax[BlastechF, OmegaRifle] = 0;
$ItemMax[MagIonM, OmegaRifle] = 1;
$ItemMax[MagIonF, OmegaRifle] = 1;
$ItemMax[MECH, OmegaRifle] = 1;

AddWeapon(OmegaRifle);

//--------------------------------------------------------------------------------------------------------
// Disarm Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData DisarmRifleImage
{
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 0;  // Sustained
	projectileType = Disarm;
	reloadTime = 1.5;
    minEnergy = 10;
    maxEnergy = 50;
                   
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData DisarmRifle
{
   description = "Riot Disarmer";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "iHeat Effect Weapons & Riot Tools";
   shadowDetailMask = 4;
   imageType = DisarmRifleImage;
	showWeaponBar = true;
   price = 2386;
};

$InvList[DisarmRifle] = 1;
$RemoteInvList[DisarmRifle] = 1;

$ItemMax[larmor, DisarmRifle] = 0;
$ItemMax[lfemale, DisarmRifle] = 0;
$ItemMax[marmor, DisarmRifle] = 1;
$ItemMax[mfemale, DisarmRifle] = 1;
$ItemMax[harmor, DisarmRifle] = 1;
$ItemMax[BlastechM, DisarmRifle] = 0;
$ItemMax[BlastechF, DisarmRifle] = 0;
$ItemMax[MagIonM, DisarmRifle] = 1;
$ItemMax[MagIonF, DisarmRifle] = 1;
$ItemMax[MECH, DisarmRifle] = 1;

AddWeapon(DisarmRifle);
//--------------------------------------------------------------------------------------------------------
// AlienLaser
//--------------------------------------------------------------------------------------------------------

ItemImageData AlienLaserImage
{
      shapeFile  = "sniper";
	mountPoint = 0;
      mountRotation = { 0, 360.0, 0 };
      weaponType = 0; // Single Shot
	projectileType = AlienRay;
	reloadTime = 2.5;
	fireTime = 0.5;
	minEnergy = 40;
	maxEnergy = 80;
      accuFire = true;
      sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AlienLaser
{
      description = "Santa's Beam-Stick";
	className = "Weapon";
   shapeFile  = "sniper";
	hudIcon = "blaster";
   heading = "fBeam Weapons";
      shadowDetailMask = 4;
	imageType = AlienLaserImage;
	price = 750;
	showWeaponBar = true;
};

$InvList[AlienLaser] = 0;
$RemoteInvList[AlienLaser] = 0;

$ItemMax[larmor, AlienLaser] = 0;
$ItemMax[lfemale, AlienLaser] = 0;
$ItemMax[marmor, AlienLaser] = 0;
$ItemMax[mfemale, AlienLaser] = 0;
$ItemMax[harmor, AlienLaser] = 0;
$ItemMax[BlastechM, AlienLaser] = 0;
$ItemMax[BlastechF, AlienLaser] = 0;
$ItemMax[MagIonM, AlienLaser] = 0;
$ItemMax[MagIonF, AlienLaser] = 0;
$ItemMax[MECH, AlienLaser] = 0;

AddWeapon(AlienLaser);

//--------------------------------------------------------------------------------------------------------
// Maser Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData MaserI
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperMaser;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0.5;
	minEnergy = 40;
	maxEnergy = 80;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFirePistol;
	sfxActivate = SoundPickUpWeapon;
};

ItemData MaserRifle
{
	description = "Blue Death";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = MaserI;
	price = 1250;
	showWeaponBar = true;
};

$InvList[MaserRifle] = 1;
$RemoteInvList[MaserRifle] = 1;

$ItemMax[larmor, MaserRifle] = 1;
$ItemMax[lfemale, MaserRifle] = 1;
$ItemMax[marmor, MaserRifle] = 1;
$ItemMax[mfemale, MaserRifle] = 1;
$ItemMax[harmor, MaserRifle] = 0;
$ItemMax[BlastechM, MaserRifle] = 1;
$ItemMax[BlastechF, MaserRifle] = 1;
$ItemMax[MagIonM, MaserRifle] = 1;
$ItemMax[MagIonF, MaserRifle] = 1;
$ItemMax[MECH, MaserRifle] = 0;

AddWeapon(MaserRifle);

//----------------------------------------------------------------------------

ItemImageData ChargerImage
{
	shapeFile = "plasmabolt";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	
   minEnergy = 3;
   maxEnergy = 3;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData Charger
{
   description = "Coulomb Cannon";
	shapeFile = "sniper";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "bWeapons";
   shadowDetailMask = 4;
   imageType = ChargerImage;
	showWeaponBar = true;
   price = 1500;
};

function ChargerImage::onActivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$ExtraWeaponSlotB,true); 
	Player::trigger(%player,$ExtraWeaponSlotC,true); 
	Player::trigger(%player,$ExtraWeaponSlotD,true); 
}

function ChargerImage::onDeactivate(%player,%imageSlot) 
{ 
	Player::trigger(%player,$ExtraWeaponSlotB,false); 
	Player::trigger(%player,$ExtraWeaponSlotC,false); 
	Player::trigger(%player,$ExtraWeaponSlotD,false); 
}
 
function Charger::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,ExtraCharger,$ExtraWeaponSlotB); 
	Player::mountItem(%player,ExtraCharger2,$ExtraWeaponSlotC); 
	Player::mountItem(%player,ExtraCharger3,$ExtraWeaponSlotD); 
} 

function Charger::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$ExtraWeaponSlotB); 
	Player::unmountItem(%player,$ExtraWeaponSlotC); 
	Player::unmountItem(%player,$ExtraWeaponSlotD); 
} 

ItemImageData ExtraChargerImage
{
	mountOffset = { 0.085, 0, 0.15 };
	mountRotation = { 0, 0.735, 0 };
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = destructiveCharge;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger
{
   heading = "bWeapons";
	description = "Coulomb Cannon";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ExtraChargerImage;
	price = 85;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData ExtraCharger2Image
{
	mountOffset = { -0.085, 0, 0.15 };
	mountRotation = { 0, -0.735, 0 };
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = OmegaBolt;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger2
{
   heading = "bWeapons";
	description = "Coulomb Cannon";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ExtraCharger2Image;
	price = 85;
	showWeaponBar = False;
	showInventory = False;
};

ItemImageData ExtraCharger3Image
{
	mountOffset = { 0, 0, 0 };
	mountRotation = { 0, 3.14, 0 };
	shapeFile = "sniper";
   mountPoint = 0;

   weaponType = 2;  // Sustained
	projectileType = turretCharge;
   minEnergy = 3;
   maxEnergy = 5;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;

  lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

};

ItemData ExtraCharger3
{
   heading = "bWeapons";
	description = "Coulomb Cannon";
	className = "Weapon";
   shapeFile  = "paintgun";
	hudIcon = "blaster";
	shadowDetailMask = 4;
	imageType = ExtraCharger3Image;
	price = 3000;
	showWeaponBar = False;
	showInventory = False;
};

$InvList[Charger] = 1;
$RemoteInvList[Charger] = 1;

$ItemMax[larmor, Charger] = 1;
$ItemMax[lfemale, Charger] = 1;
$ItemMax[marmor, Charger] = 1;
$ItemMax[mfemale, Charger] = 1;
$ItemMax[harmor, Charger] = 1;
$ItemMax[BlastechM, Charger] = 1;
$ItemMax[BlastechF, Charger] = 1;
$ItemMax[MagIonM, Charger] = 1;
$ItemMax[MagIonF, Charger] = 1;
$ItemMax[MECH, Charger] = 1;

AddWeapon(Charger);
//=========================================================================

ItemData MitziCore
{
	description = "MBC Power Charge";
	className = "Ammo";
	shapeFile = "ammo2";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MBImage 
{
	shapeFile = "MortarGun";
	mountPoint = 0;

	weaponType = 0;
	ammoType = MitziCore; 
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 1;
	
	sfxFire = SonicBlasts;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
};

function MBImage::onFire(%player,%slot)
{
	%playerId = Player::getClient(%player);
	%client = GameBase::getOwnerClient(%player);
	%trans = GameBase::getMuzzleTransform(%player);
	%vel = Item::getVelocity(%player);
	
	if (%playerId.Cannon == 0)
	{
		if(Player::getItemCount(%player,MitziCore) > 9)
		{
			Projectile::spawnProjectile("IonShock3",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,10);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Standard Mitzi Blast");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == 1)
	{
		if(Player::getItemCount(%player,MitziCore) > 14)
		{
			Projectile::spawnProjectile("IonShock4",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,15);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi EMP Blast");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == "2")
	{
		if(Player::getItemCount(%player,MitziCore) > 24)
		{
			Projectile::spawnProjectile("IonShock5",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,25);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Boost");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == "3")
	{
		if(Player::getItemCount(%player,MitziCore) > 124)
		{
			Projectile::spawnProjectile("BLHOLE",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,75);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),1,"Not enough energy to fire Mitzi BlackHOLE");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}
	else if (%playerId.Cannon == "4")
	{
		if(Player::getItemCount(%player,MitziCore) > 49)
		{
			Projectile::spawnProjectile("IonShock6",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,50);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Poison");
			Player::trigger(%player,$WeaponSlot,false);
		}
      }
	else if (%playerId.Cannon == "5")
	{
		if(Player::getItemCount(%player,MitziCore) > 39)
		{
			Projectile::spawnProjectile("IonShock7",%trans,%player,%vel);
			Player::decItemCount(%player,MitziCore,100);
		}
		else
		{
			Client::sendMessage(Player::getClient(%player),0,"Not enough energy to fire Mitzi Annihilator Blast");
			Player::trigger(%player,$WeaponSlot,false);
		}
	}

	if(!%player.recharge || %player.recharge != true)
	{
		%player.recharge = true;
		MBImage::onCharge(%player);
	}
}

function MBImage::onCharge(%player)
{
	%armor = Player::getArmor(%player);
	%pack = Player::getMountedItem(%player,$BackpackSlot);

	if(Player::getItemCount(%player,MBCannon) > 0)
	{
		if(Player::getItemCount(%player,MitziCore) < $ItemMax[%armor, MitziCore])
		{
			Player::incItemCount(%player,MitziCore,2);

			if(%pack == MitziCharger)
				schedule("MBImage::onCharge("@%player@");",0.25,%player);
			else
				schedule("MBImage::onCharge("@%player@");",0.5,%player);
		}
		else
			%player.recharge = false;
 	}
}

ItemData MBCannon
{
	description = "Mitzi Blast Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "blaster";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = MBImage;
	price = 2000;
	showWeaponBar = true;
};

AddWeapon(mbcannon);

$InvList[MBCannon] = 1;
$RemoteInvList[MBCannon] = 1;

$ItemMax[larmor, MBCannon] = 1;
$ItemMax[lfemale, MBCannon] = 1;
$ItemMax[marmor, MBCannon] = 1;
$ItemMax[mfemale, MBCannon] = 1;
$ItemMax[harmor, MBCannon] = 1;
$ItemMax[BlastechM, MBCannon] = 1;
$ItemMax[BlastechF, MBCannon] = 1;
$ItemMax[MagIonM, MBCannon] = 1;
$ItemMax[MagIonF, MBCannon] = 1;
$ItemMax[MECH, MBCannon] = 1;

$WeaponAmmo[MBCannon]			= MitziCore;
$SellAmmo[MitziCore]			= 100;

$InvList[MitziCore] = 1;
$RemoteInvList[MitziCore] = 1;

$ItemMax[harmor, MitziCore] = 125;
$ItemMax[marmor, MitziCore] = 60;
$ItemMax[mfemale, MitziCore] = 60;
$ItemMax[larmor, MitziCore] = 40;
$ItemMax[lfemale, MitziCore] = 40;
$ItemMax[BlastechM, MitziCore] = 40;
$ItemMax[BlastechF, MitziCore] = 40;
$ItemMax[MagIonM, MitziCore] = 60;
$ItemMax[MagIonF, MitziCore] = 60;
$ItemMax[MECH, MitziCore] = 125;



//------------------------------------------------------------------------------

ItemImageData ExtraEnergyImageA 
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
	mountRotation = { 0, 1.57, 0 }; 
	mountOffset = { 0.1, 0, 0.05 };
	minEnergy = 1;
	maxEnergy = 2;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = ProtronBolt;
	sfxFire = SoundFireBlaster;
}; 

ItemData ExtraEnergyA 
{ 
	description = "Protron";
	 className = "Weapon"; 
	shapeFile = "paintgun"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageA; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData ExtraEnergyImageB 
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
	mountRotation = { 0, 0, 0 }; 
	mountOffset = { 0.0, 0, 0 };
	minEnergy = 1;
	maxEnergy = 2;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = ProtronBolt;
	sfxFire = SoundFireBlaster;
}; 

ItemData ExtraEnergyB 
{ 
	description = "Protron";
	 className = "Weapon"; 
	shapeFile = "paintgun"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageB; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData ExtraEnergyImageC
{ 
	shapeFile = "paintgun"; 
	mountPoint = 0; 
	mountRotation = { 0, -1.57, 0 }; 
	mountOffset = { -0.1, 0, 0.05 };
	minEnergy = 1;
	maxEnergy = 2;
	weaponType = 0; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	projectileType = ProtronBolt;
	sfxFire = SoundFireBlaster;
}; 

ItemData ExtraEnergyC 
{ 
	description = "Protron";
	 className = "Weapon"; 
	shapeFile = "paintgun"; 
	hudIcon = "disk"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = ExtraEnergyImageC; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
}; 

ItemImageData EnergyGunImage 
{ 
	shapeFile = "breath"; 
	mountPoint = 0; 
	weaponType = 3; 
	accuFire = true; 
	reloadTime = 0; 
	fireTime = 0.1; 
	spinUpTime = 0.2; 
	sfxActivate = SoundPickUpWeapon; 
}; 

ItemData EnergyGun
{ 
	description = "Protron"; 
	className = "Weapon"; 
	shapeFile = "paintgun"; 
	hudIcon = "blaster"; 
     heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = EnergyGunImage; 
	price = 3500; 
	showWeaponBar = true; 
}; 

function EnergyGunImage::onFire(%player, %slot) // actually made by MEGA-Man... forgot his name in the credits! oops!
{  
	%state1 = Player::getItemState(%player,5);  
	%state2 = Player::getItemState(%player,6);  
	%state3 = Player::getItemState(%player,7);  

	if (%state1 != "Fire" && %state1 != "Reload" && %state2 != "Fire" && %state2 != "Reload" && %state3 != "Fire" & %state3 != "Reload") 
	{   
		%client = GameBase::getOwnerClient(%player);   
		if(%client.energy == 0) 
		{    
			%client.energy = 1;    
			Player::trigger(%player,6,true);    
			Player::trigger(%player,6,false);   
		} 
		else if(%client.energy == 1) 
		{    
			%client.energy = 2;    
			Player::trigger(%player,7,true);    
			Player::trigger(%player,7,false);   
		} 
		else 
		{    
			%client.energy = 0;    
			Player::trigger(%player,5,true);    
			Player::trigger(%player,5,false);   
		}  
	} 
} 

function EnergyGun::onMount(%player,%imageSlot) 
{  
	Player::mountItem(%player,ExtraEnergyA,6);  
	Player::mountItem(%player,ExtraEnergyB,7); 
	Player::mountItem(%player,ExtraEnergyC,5); 
} 

function EnergyGun::onUnmount(%player,%imageSlot) 
{  
	Player::unmountItem(%player,5);  
	Player::unmountItem(%player,6);  
	Player::unmountItem(%player,7); 
}

$InvList[EnergyGun] = 1;
$RemoteInvList[EnergyGun] = 1;

$ItemMax[larmor, EnergyGun] = 0;
$ItemMax[lfemale, EnergyGun] = 0;
$ItemMax[marmor, EnergyGun] = 0;
$ItemMax[mfemale, EnergyGun] = 0;
$ItemMax[harmor, EnergyGun] = 1;
$ItemMax[BlastechM, EnergyGun] = 0;
$ItemMax[BlastechF, EnergyGun] = 0;
$ItemMax[MagIonM, EnergyGun] = 0;
$ItemMax[MagIonF, EnergyGun] = 0;
$ItemMax[MECH, EnergyGun] = 1;

AddWeapon(EnergyGun);

//--------------------------------------------------------------------------------------------------------
// Chain Gun
//--------------------------------------------------------------------------------------------------------

ItemData BulletAmmo
{
	description = "Bullet";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData ChaingunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = BulletAmmo;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

function ChaingunImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[Chaingun]);
	 if(%Ammo) 
	 {
			 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.chaingun == 0)
			{
				Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Chaingun],1);
			}
			else if (%playerId.chaingun == 1)	// lol
			{
				Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
				Projectile::spawnProjectile("ChaingunBullet",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Chaingun],5);
			}
	}
}

ItemData Chaingun
{
	description = "Hyper-Chaingun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = ChaingunImage;
	price = 125;
	showWeaponBar = true;
};

AddWeapon(ChainGun);

//--------------------------------------------------------------------------------------------------------
// Gatling Blaster
//--------------------------------------------------------------------------------------------------------

ItemImageData GatlingBlasterImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 0;
	reloadTime = 0;
	fireTime = 0.1;
	minEnergy = 10;
	maxEnergy = 2;
	projectileType = GatlingBlasterBolt;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireBlaster;
	sfxActivate = SoundDryFire;
};

ItemData GatB
{
	description = "Gatler";
	className = "Weapon";
	shapeFile = "chaingun";

	hudIcon = "chaingun";
   heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = GatlingBlasterImage;
	price = 500;
	showWeaponBar = true;
};


AddWeapon(gatb);

$InvList[GatB] = 1;
$RemoteInvList[GatB] = 1;

$ItemMax[larmor, GatB] = 0;
$ItemMax[lfemale, GatB] = 0;
$ItemMax[marmor, GatB] = 1;
$ItemMax[mfemale, GatB] = 1;
$ItemMax[harmor, GatB] = 1;
$ItemMax[BlastechM, GatB] = 0;
$ItemMax[BlastechF, GatB] = 0;
$ItemMax[MagIonM, GatB] = 1;
$ItemMax[MagIonF, GatB] = 1;
$ItemMax[MECH, GatB] = 1;

//--------------------------------------------------------------------------------------------------------
// Gauss Cannon
//--------------------------------------------------------------------------------------------------------

ItemData GaussAmmo
{
	description = "Explosive Bullets";
	className = "Ammo";
	shapeFile = "ammo1";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData GaussGunImage
{
	shapeFile = "chaingun";
	mountPoint = 0;

	weaponType = 1; // Spinning
	reloadTime = 0;
	spinUpTime = 0.5;
	spinDownTime = 3;
	fireTime = 0.2;

	ammoType = GaussAmmo;
	projectileType = GaussBullet;
	accuFire = false;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1 };

	sfxFire = SoundFireChaingun;
	sfxActivate = SoundPickUpWeapon;
	sfxSpinUp = SoundSpinUp;
	sfxSpinDown = SoundSpinDown;
};

ItemData Gauss
{
	description = "Grey's Gauss Gun";
	className = "Weapon";
	shapeFile = "chaingun";
	hudIcon = "chain";
   heading = "cGatling Weapons";
	shadowDetailMask = 4;
	imageType = GaussGunImage;
	price = 650;
	showWeaponBar = true;
};

AddWeapon(Gauss);

$SellAmmo[GaussAmmo]			= 50;

$AmmoPackMax[GaussAmmo] = 50;
$AmmoPackItems[10] = GaussAmmo;

$InvList[Gauss] = 1;
$RemoteInvList[Gauss] = 1;

$InvList[GaussAmmo] = 1;

$RemoteInvList[GaussAmmo] = 1;

$ItemMax[larmor, Gauss] = 1;
$ItemMax[lfemale, Gauss] = 1;
$ItemMax[marmor, Gauss] = 1;
$ItemMax[mfemale, Gauss] = 1;
$ItemMax[harmor, Gauss] = 1;
$ItemMax[BlastechM, Gauss] = 1;
$ItemMax[BlastechF, Gauss] = 1;
$ItemMax[MagIonM, Gauss] = 1;
$ItemMax[MagIonF, Gauss] = 1;
$ItemMax[MECH, Gauss] = 1;

$ItemMax[larmor, GaussAmmo] = 70;
$ItemMax[lfemale, GaussAmmo] = 70;
$ItemMax[marmor, GaussAmmo] = 125;
$ItemMax[mfemale, GaussAmmo] = 125;
$ItemMax[harmor, GaussAmmo] = 150;
$ItemMax[BlastechM, GaussAmmo] = 100;
$ItemMax[BlastechF, GaussAmmo] = 100;
$ItemMax[MagIonM, GaussAmmo] = 125;
$ItemMax[MagIonF, GaussAmmo] = 125;
$ItemMax[MECH, GaussAmmo] = 150;

//---------------------------------------------------------- 
BulletData MiniGunBullet
{
   bulletShapeName    = "bullet.dts";
   explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
   damageType         = $BulletDamageType;

   aimDeflection      = 0.0075;
   muzzleVelocity     = 768.0;
   totalTime          = 1.5;
   inheritedVelocityScale = 1.0;
   isVisible          = False;

   tracerPercentage   = 1.0;
   tracerLength       = 30;
};

//--------------------------------------
RocketData Raygun_ray
{
   bulletShapeName = "tracer.dts";
   explosionTag    = rocketExp;


  collisionRadius = 0.0;

  explosionTag       = bulletExp0;
   expRandCycle       = 3;
   mass               = 0.05;
   bulletHoleIndex    = 0;

   damageClass        = 0;       // 0 impact, 1, radius
   damageValue        = 0.075;
   damageType         = $BulletDamageType;

   explosionRadius  = 7.5;
   kickBackStrength = 150.0;

   muzzleVelocity   = 768.0;
   terminalVelocity = 768.0;
   acceleration     = 0;

   totalTime        = 6.5;
   liveTime         = 8.0;

   lightRange       = 5.0;
   lightColor       = { 0.4, 0.4, 1.0 };

   inheritedVelocityScale = 0.5;

   trailType   = 1;
   trailLength = 0;
   trailWidth  = 0;

   soundId = SoundJetHeavy;
};

addweapon(Minigun);
$MinigunSlot=4; 
$AutoUse[Minigun] = True; 
$SellAmmo[MinigunAmmo] = 25; 
$AmmoPackMax[MinigunAmmo] = 50; 
$AmmoPackItems[13] = MinigunAmmo; 
$WeaponAmmo[Minigun] = MinigunAmmo; 

$InvList[Minigun]=1;	
$InvList[MinigunAmmo]=1;
$RemoteInvList[Minigun]=1;		// Some weapons are not available from remote inventory units
$RemoteInvList[MinigunAmmo]=1;

$ItemMax[lfemale,Minigun]=0;	// The maximum Light Female can carry
$ItemMax[larmor,Minigun]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,Minigun]=1;	// The maximum Medium Female can carry
$ItemMax[marmor,Minigun]=1;	// The maximum Medium Male can carry
$ItemMax[harmor,Minigun]=0;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, Minigun] = 0;
$ItemMax[BlastechF, Minigun] = 0;
$ItemMax[MagIonM, Minigun] = 1;
$ItemMax[MagIonF, Minigun] = 1;
$ItemMax[MECH, Minigun] = 0;

$ItemMax[lfemale,MinigunAmmo]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MinigunAmmo]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MinigunAmmo]=200;	// The maximum Medium Female can carry
$ItemMax[marmor,MinigunAmmo]=200;	// The maximum Medium Male can carry
$ItemMax[harmor,MinigunAmmo]=0;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MinigunAmmo] = 0;
$ItemMax[BlastechF, MinigunAmmo] = 0;
$ItemMax[MagIonM, MinigunAmmo] = 200;
$ItemMax[MagIonF, MinigunAmmo] = 200;
$ItemMax[MECH, MinigunAmmo] = 0;

ItemData MinigunAmmo 
{ 
	description = "MiniGun Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "zAmmo"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MinigunImage 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountRotation = { 0,1.57, 0 };
	mountOffset = { 0.225, 0, 0 };
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MinigunAmmo; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
	sfxActivate = SoundPickupMinigun; 
	//sfxSpinUp = SoundSpinUp; 
	sfxSpinDown = SoundMiniDown; 
}; 

function MinigunImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[Minigun],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%player,%vel,%player); 
	if(!$MDFiringMinigun[%client]) MDCheckMinigun(%client, %player); 
} 

ItemData Minigun 
{ 
	description = "MiniGun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
   heading = "cGatling Weapons";
	shadowDetailMask = 4; 
	imageType = MinigunImage; 
	price = 5000; 

	showWeaponBar = true; 
}; 

function Minigun::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, Minigun2, 0); 
		Item::onDrop(%player,%item); 
	} 
} 

function Minigun::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,Minigun2,$MinigunSlot); 
} 

function Minigun::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MinigunSlot); 
} 

ItemImageData Minigun2Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountRotation = { 0,-1.57, 0 };
	mountOffset = { 0, 0, 0 };
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MinigunAmmo; 
	projectileType = MinigunBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData Minigun2 
{ 
	description = "MiniGun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = Minigun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMinigun(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "Minigun")) 
	{ 
		Player::trigger(%player,$MinigunSlot,true); 
		schedule("MDCheckMinigun(" @ %client @ "," @ %player @ ");",0.05); 
		$MDFiringMinigun[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MinigunSlot,false); 
		$MDFiringMinigun[%client] = false; 
	} 
} 

$MMinigunSlotA=4;
$MMinigunSlotB=5;
$MMinigunSlotC=6; 

addweapon(MMinigun);
$AutoUse[MMinigun] = True; 
$SellAmmo[MMinigunAmmo] = 50; 
$AmmoPackMax[MMinigunAmmo] = 75; 
$AmmoPackItems[14] = MMinigunAmmo; 
$WeaponAmmo[MMinigun] = MMinigunAmmo; 

$InvList[MMinigun]=1;	
$InvList[MMinigunAmmo]=1;
//$RemoteInvList[Minigun]=1;		// Some weapons are not available from remote inventory units
$RemoteInvList[MMinigunAmmo]=1;

$ItemMax[lfemale,MMinigun]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MMinigun]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MMinigun]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MMinigun]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MMinigun]=1;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MMinigun] = 0;
$ItemMax[BlastechF, MMinigun] = 0;
$ItemMax[MagIonM, MMinigun] = 0;
$ItemMax[MagIonF, MMinigun] = 0;
$ItemMax[MECH, MMinigun] = 1;

$ItemMax[lfemale,MMinigunAmmo]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MMinigunAmmo]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MMinigunAmmo]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MMinigunAmmo]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MMinigunAmmo]=250;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MMinigunAmmo] = 0;
$ItemMax[BlastechF, MMinigunAmmo] = 0;
$ItemMax[MagIonM, MMinigunAmmo] = 0;
$ItemMax[MagIonF, MMinigunAmmo] = 0;
$ItemMax[MECH, MMinigunAmmo] = 200;

ItemData MMinigunAmmo 
{ 
	description = "MMinigun Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "zAmmo"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MMinigunImage 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -1.3051, -0.201, 0.251 }; 
	mountRotation = { 0, 1.501, 0 }; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMinigunAmmo; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
	sfxActivate = SoundPickupminigun; 
	//sfxSpinUp = SoundSpinUp; 
	sfxSpinDown = SoundMiniDown; 
}; 

function MMinigunImage::onFire(%player, %slot) 

{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[MMinigun],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("MinigunBullet",%trans,%player,%vel,%player); 
	if(!$MDFiringMMinigun[%client]) MDCheckMMinigun(%client, %player); 
} 

ItemData MMinigun 
{ 
	description = "MECHMinigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
   heading = "cGatling Weapons";
	shadowDetailMask = 4; 
	imageType = MMinigunImage; 
	price = 7500; 
	showWeaponBar = true; 
}; 

function MMinigun::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, MMinigun2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function MMinigun::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,MMinigun2,$MMinigunSlotA); 
	Player::mountItem(%player,MMinigun3,$MMinigunSlotB); 
	Player::mountItem(%player,MMinigun4,$MMinigunSlotC); 
} 

function MMinigun::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MMinigunSlotA);
	Player::unmountItem(%player,$MMinigunSlotB);	 
	Player::unmountItem(%player,$MMinigunSlotC);
} 

ItemImageData MMinigun2Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, -0.351, 0 }; 
	mountRotation = { 0, 1.01, 0}; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMinigunAmmo; 
	projectileType = MiniGunBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMinigun2 
{ 
	description = "MECHMinigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMinigun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData MMinigun3Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.351, 0 }; 
	mountRotation = { 0, -1.01, 0 }; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMinigunAmmo; 
	projectileType = ChaingunBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMinigun3 
{ 
	description = "MECHMinigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMinigun3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 
ItemImageData MMinigun4Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 }; 
	mountRotation = { 0, -1.501, 0};  
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMinigunAmmo; 
	projectileType = ChaingunBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMinigun4 
{ 
	description = "MECHMinigun"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMinigun4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMMinigun(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "MMinigun")) 
	{ 
		Player::trigger(%player,$MMinigunSlotA,true);
		Player::trigger(%player,$MMinigunSlotB,true);
		Player::trigger(%player,$MMinigunSlotC,true); 
		schedule("MDCheckMMinigun(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringMMinigun[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MMinigunSlotA,false); 
		Player::trigger(%player,$MMinigunSlotB,false); 
		Player::trigger(%player,$MMinigunSlotC,false); 
		$MDFiringMMinigun[%client] = false; 
	} 
} 






//--------------------------------------------------------------------------------------------------------
// Grenade Launcher
//--------------------------------------------------------------------------------------------------------

ItemData GrenadeAmmo
{
	description = "Grenade Ammo";
	className = "Ammo";
	shapeFile = "grenammo";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData GrenadeLauncherImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireGrenade;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function GrenadeLauncherImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[GrenadeLauncher]);
	 if(%Ammo) 
	 {
			 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.grenade == 0)
			{
				Projectile::spawnProjectile("GrenadeShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],1);
			}
			else if (%playerId.grenade == 1)
			{
				Projectile::spawnProjectile("ImpactGrenadeShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[GrenadeLauncher],2);
			}
	}
}

ItemData GrenadeLauncher
{
	description = "Super-*Nade";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = GrenadeLauncherImage;
	price = 150;
	showWeaponBar = true;
};

AddWeapon(GrenadeLauncher);

//--------------------------------------------------------------------------------------------------------
// Mortar 
//--------------------------------------------------------------------------------------------------------

ItemData MortarAmmo
{
	description = "Mortar Ammo";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function MortarImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[Mortar]);
	 if(%Ammo) 
	 {
			 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.mortar == 0)
			{
				Projectile::spawnProjectile("MortarShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
			else if (%playerId.mortar == 1)
			{
				Projectile::spawnProjectile("BettyShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
			else if (%playerId.mortar == 2)
			{
				Projectile::spawnProjectile("AntiBShell",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[Mortar],1);
			}
	}
}

ItemData Mortar
{
	description = "Mortar";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = MortarImage;
	price = 300;
	showWeaponBar = true;
};
$ItemMax[harmor, Mortar] = 1;
$ItemMax[harmor, MortarAmmo] = 15;
$ItemMax[larmor, Mortar] = 1;
$ItemMax[larmor, MortarAmmo] = 1;
$ItemMax[marmor, Mortar] = 1;
$ItemMax[marmor, MortarAmmo] = 1;
$ItemMax[lfemale, Mortar] = 1;
$ItemMax[lfemale, MortarAmmo] = 1;
$ItemMax[mfemale, Mortar] = 1;
$ItemMax[mfemale, MortarAmmo] = 1;
$ItemMax[BlastechM, Mortar] = 1;
$ItemMax[BlastechF, Mortar] = 1;
$ItemMax[MagIonM, Mortar] = 1;
$ItemMax[MagIonF, Mortar] = 1;
$ItemMax[MECH, Mortar] = 1;
$ItemMax[BlastechM, MortarAmmo] = 1;
$ItemMax[BlastechF, MortarAmmo] = 1;
$ItemMax[MagIonM, MortarAmmo] = 1;
$ItemMax[MagIonF, MortarAmmo] = 1;
$ItemMax[MECH, MortarAmmo] = 15;

AddWeapon(Mortar);

//--------------------------------------------------------------------------------------------------------
// Impact-Explosive Mortar 
//--------------------------------------------------------------------------------------------------------

$AutoUse[ImpactMortar]			= True;

AddWeapon(ImpactMortar);

$WeaponAmmo[ImpactMortar]			= ImpactAmmo;
$SellAmmo[ImpactAmmo]			= 10;
$AmmoPackMax[ImpactAmmo]		= 10;

$AmmoPackItems[15] = ImpactAmmo;

$InvList[ImpactMortar] = 1;
$RemoteInvList[ImpactMortar] = 1;

$InvList[ImpactAmmo] = 1;
$RemoteInvList[ImpactAmmo] = 1;

$ItemMax[harmor, ImpactMortar] = 1;
$ItemMax[harmor, ImpactAmmo] = 15;
$ItemMax[larmor, ImpactMortar] = 1;
$ItemMax[larmor, ImpactAmmo] = 5;
$ItemMax[marmor, ImpactMortar] = 1;
$ItemMax[marmor, ImpactAmmo] = 5;
$ItemMax[lfemale, ImpactMortar] = 1;
$ItemMax[lfemale, ImpactAmmo] = 5;
$ItemMax[mfemale, ImpactMortar] = 1;
$ItemMax[mfemale, ImpactAmmo] = 1;
$ItemMax[BlastechM, ImpactMortar] = 1;
$ItemMax[BlastechF, ImpactMortar] = 1;
$ItemMax[MagIonM, ImpactMortar] = 1;
$ItemMax[MagIonF, ImpactMortar] = 1;
$ItemMax[MECH, ImpactMortar] = 1;
$ItemMax[BlastechM, ImpactAmmo] = 1;
$ItemMax[BlastechF, ImpactAmmo] = 1;
$ItemMax[MagIonM, ImpactAmmo] = 1;
$ItemMax[MagIonF, ImpactAmmo] = 1;
$ItemMax[MECH, ImpactAmmo] = 15;

ItemData ImpactAmmo
{
	description = "Mini-Tactical Nukes";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData IMortarImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ImpactAmmo;
	projectileType = ImpactMortarShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;
	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData ImpactMortar
{
	description = "The Iron Fist";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = IMortarImage;
	price = 350;
	showWeaponBar = true;
};


//--------------------------------------------------------------------------------------------------------
// Implosion Cannon
//--------------------------------------------------------------------------------------------------------

ItemData IMPAmmo
{
	description = "Black-Ops Shells";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "grenammo";
	shadowDetailMask = 4;
	price = 10;
};

$InvList[IMPAmmo] = 1;
$RemoteInvList[IMPAmmo] = 1;

$SellAmmo[IMPAmmo]			= 2;

$AmmoPackMax[IMPAmmo] = 2;
$AmmoPackItems[30] = IMPAmmo;

ItemImageData ImpImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	ammoType = IMPAmmo;

	projectileType = ImplosionShell;
	accuFire = false;
	reloadTime = 0.75;
	fireTime = 1.5;
	lightType = 3;
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData ImpGun
{
	description = "'Black-Ops' Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "mortar";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
        imageType = ImpImage;
	price = 7500;
	showWeaponBar = true;
};

addweapon(impgun);

$InvList[ImpGun] = 1;
$RemoteInvList[ImpGun] = 1;

$ItemMax[marmor, ImpGun] = 1;
$ItemMax[mfemale, ImpGun] = 1;
$ItemMax[larmor, ImpGun] = 1;
$ItemMax[lfemale, ImpGun] = 1;
$ItemMax[harmor, ImpGun] = 1;
$ItemMax[BlastechM, ImpGun] = 1;
$ItemMax[BlastechF, ImpGun] = 1;
$ItemMax[MagIonM, ImpGun] = 1;
$ItemMax[MagIonF, ImpGun] = 1;
$ItemMax[MECH, ImpGun] = 1;

$ItemMax[marmor, ImpAmmo] = 6;
$ItemMax[mfemale, ImpAmmo] = 6;
$ItemMax[larmor, ImpAmmo] = 2;
$ItemMax[lfemale, ImpAmmo] = 2;
$ItemMax[harmor, ImpAmmo] = 10;
$ItemMax[BlastechM, ImpAmmo] = 2;
$ItemMax[BlastechF, ImpAmmo] = 2;
$ItemMax[MagIonM, ImpAmmo] = 6;
$ItemMax[MagIonF, ImpAmmo] = 6;
$ItemMax[MECH, ImpAmmo] = 1;


//-----------------------------------------------------------------
// EMP Grenade Launcher
//----------------------------------------------------------------------------

ItemData EMPGrenadeAmmo
{
	description = "EMP Mortars";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 50;
};

ItemImageData EMPGrenadeLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0; // Single Shot
	ammoType = EMPGrenadeAmmo;
	projectileType = EMPGrenadeShell;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.25, 0.25, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundLaserIdle;
};

ItemData EMPGrenadeLauncher
{
	description = "EMP Mortar Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sensorjamerpack";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = EMPGrenadeLauncherImage;
	price = 475;
	showWeaponBar = true;
};

AddWeapon(EMPGrenadeLauncher);

$ItemMax[larmor, EMPGrenadeLauncher] = 0;
$ItemMax[lfemale, EMPGrenadeLauncher] = 0;
$ItemMax[marmor, EMPGrenadeLauncher] = 1;
$ItemMax[mfemale, EMPGrenadeLauncher] = 1;
$ItemMax[harmor, EMPGrenadeLauncher] = 1;
$ItemMax[BlastechM, EMPGrenadeLauncher] = 0;
$ItemMax[BlastechF, EMPGrenadeLauncher] = 0;
$ItemMax[MagIonM, EMPGrenadeLauncher] = 1;
$ItemMax[MagIonF, EMPGrenadeLauncher] = 1;
$ItemMax[MECH, EMPGrenadeLauncher] = 1;

$ItemMax[larmor, EMPGrenadeAmmo] = 0;
$ItemMax[lfemale, EMPGrenadeAmmo] = 0;
$ItemMax[marmor, EMPGrenadeAmmo] = 5;
$ItemMax[mfemale, EMPGrenadeAmmo] = 5;
$ItemMax[harmor, EMPGrenadeAmmo] = 10;
$ItemMax[BlastechM, EMPGrenadeAmmo] = 0;
$ItemMax[BlastechF, EMPGrenadeAmmo] = 0;
$ItemMax[MagIonM, EMPGrenadeAmmo] = 5;
$ItemMax[MagIonF, EMPGrenadeAmmo] = 5;
$ItemMax[MECH, EMPGrenadeAmmo] = 3;

//--------------------------------------------------------------------------------------------------------
// Mine Launcher
//--------------------------------------------------------------------------------------------------------

ItemData MultiMineAmmo
{
	description = "Spawning Mines";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData MineLauncherImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = Deploybox;
	accuFire = true;
	ammoType = MultiMineAmmo;
	reloadTime = 0.5;
	fireTime = 1.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundLaserIdle;
};

ItemData MineLauncher
{
	description = "Mine Launcher";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "plasma";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = MineLauncherImage;
	price = 1200;
	showWeaponBar = true;
};

AddWeapon(minelauncher);

$AutoUse[MineLauncher]			= True;

$WeaponAmmo[MineLauncher]			= MultiMineAmmo;
$SellAmmo[MultiMineAmmo]			= 2;
$AmmoPackMax[MultiMineAmmo]		= 2;

$AmmoPackItems[17] = MultiMineAmmo;

$InvList[MineLauncher] = 1;
$RemoteInvList[MineLauncher] = 1;

$InvList[MultiMineAmmo] = 1;
$RemoteInvList[MultiMineAmmo] = 1;

$ItemMax[harmor, MineLauncher] = 1;
$ItemMax[harmor, MultiMineAmmo] = 5;
$ItemMax[larmor, MineLauncher] = 0;
$ItemMax[larmor, MultiMineAmmo] = 0;
$ItemMax[marmor, MineLauncher] = 1;
$ItemMax[marmor, MultiMineAmmo] = 3;
$ItemMax[lfemale, MineLauncher] = 0;
$ItemMax[lfemale, MultiMineAmmo] = 0;
$ItemMax[mfemale, MineLauncher] = 1;
$ItemMax[mfemale, MultiMineAmmo] = 3;
$ItemMax[BlastechM, MineLauncher] = 0;
$ItemMax[BlastechF, MineLauncher] = 0;
$ItemMax[MagIonM, MineLauncher] = 1;
$ItemMax[MagIonF, MineLauncher] = 1;
$ItemMax[MECH, MineLauncher] = 1;
$ItemMax[BlastechM, MultiMineAmmo] = 0;
$ItemMax[BlastechF, MultiMineAmmo] = 0;
$ItemMax[MagIonM, MultiMineAmmo] = 3;
$ItemMax[MagIonF, MultiMineAmmo] = 3;
$ItemMax[MECH, MultiMineAmmo] = 2;

//--------------------------------------------------------------------------------------------------------
// Baby-Nuke Launcher
//--------------------------------------------------------------------------------------------------------

ItemImageData BaybNookImage
{
	shapeFile = "mortar";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	accuFire = true;
	ammoType = MortarAmmo;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFireMortar; 
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData BabyNukeMortar
{
	description = "Tactical Nuke";
	className = "Weapon";
	shapeFile = "mortar";
	hudIcon = "plasma";
   heading = "dLobbing Weapons";
	shadowDetailMask = 4;
	imageType = BayBNookImage;
	price = 32000;
	showWeaponBar = true;
};

$WeaponAmmo[BabyNukeMortar] = BabyNukeMortar;

function BayBNookImage::onFire(%player, %slot) 
{
	 %AmmoCount = Player::getItemCount(%player, $WeaponAmmo[BabyNukeMortar]);
	 if(%AmmoCount) 
	 {
		 %client = GameBase::getOwnerClient(%player);
		 Player::decItemCount(%player,$WeaponAmmo[BabyNukeMortar],1);
		 %trans = GameBase::getMuzzleTransform(%player);
	     %vel = Item::getVelocity(%player);

			Projectile::spawnProjectile("ClusterBomb",%trans,%player,%vel);
}
	else
		Client::sendMessage(Player::getClient(%player), 1,"Oops. screwed ya!");

}

$AutoUse[BabyNukeMortar]			= True;

AddWeapon(babynukemortar);

$InvList[BabyNukeMortar] = 1;
$RemoteInvList[BabyNukeMortar] = 1;

$ItemMax[harmor, BabyNukeMortar] = 1;
$ItemMax[larmor, BabyNukeMortar] = 0;
$ItemMax[lfemale, BabyNukeMortar] = 0;
$ItemMax[marmor, BabyNukeMortar] = 0;
$ItemMax[mfemale, BabyNukeMortar] = 0;
$ItemMax[BlastechM, BabyNukeMortar] = 0;
$ItemMax[BlastechF, BabyNukeMortar] = 0;
$ItemMax[MagIonM, BabyNukeMortar] = 0;
$ItemMax[MagIonF, BabyNukeMortar] = 0;
$ItemMax[MECH, BabyNukeMortar] = 1;

//--------------------------------------------------------------------------------------------------------
// Smoke Bomb Launcher
//--------------------------------------------------------------------------------------------------------

ItemData LaserAmmo
{
	description = "Smoke Bomb";
	className = "Ammo";
	shapeFile = "plasammo";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData StasisI
{
	shapeFile = "plasma";
    mountPoint = 0;
	weaponType = 0; // Single Shot
	reloadTime = 0;
	fireTime = 2.5;
	ammotype = LaserAmmo;
	projectileType = smokebomb;
	accuFire = false;

	 lightType = 3;
	 lightRadius = 3;
	 lightTime = 1;
	 lightColor = { 1.0, 0.7, 0.5 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundMortarTurretFire;
};

ItemData StasisCannon
{
    description = "Tear-Gas";
	shapeFile = "plasma";
	hudIcon = "blaster";
    className = "Weapon";
   heading = "dLobbing Weapons";
    shadowDetailMask = 4;
    imageType = StasisI;
	showWeaponBar = true;
    price = 200;
};

$InvList[StasisCannon]			= 1;
$RemoteInvList[StasisCannon]	= 1;		
$AutoUse[StasisCannon]			= True;
$WeaponAmmo[StasisCannon]		= LaserAmmo;
AddWeapon(StasisCannon);

$ItemMax[larmor,StasisCannon]	= 0;
$ItemMax[lfemale,StasisCannon]	= 0;
$ItemMax[marmor,StasisCannon]	= 1;
$ItemMax[mfemale,StasisCannon]	= 1;
$ItemMax[harmor,StasisCannon]	= 1;
$ItemMax[BlastechF, StasisCannon] = 1;
$ItemMax[BlastechM, StasisCannon] = 1;
$ItemMax[MagIonM, StasisCannon] = 1;
$ItemMax[MagIonF, StasisCannon] = 1;
$ItemMax[MECH, StasisCannon] = 1;

$ItemMax[larmor, LaserAmmo] = 0;
$ItemMax[lfemale, LaserAmmo] = 0;
$ItemMax[marmor, LaserAmmo] = 5;
$ItemMax[mfemale, LaserAmmo] = 5;
$ItemMax[harmor, LaserAmmo] = 10;
$ItemMax[BlastechF, LaserAmmo] = 5;
$ItemMax[BlastechM, LaserAmmo] = 5;
$ItemMax[MagIonM, LaserAmmo] = 5;
$ItemMax[MagIonF, LaserAmmo] = 5;
$ItemMax[MECH, LaserAmmo] = 10;

//--------------------------------------------------------------------------------------------------------
// Disc Launcher
//--------------------------------------------------------------------------------------------------------

ItemData DiscAmmo
{
	description = "Disc";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData DiscLauncherImage
{
	shapeFile = "disc";
	mountPoint = 0;

	weaponType = 3; // DiscLauncher
	ammoType = DiscAmmo;
	accuFire = true;
	reloadTime = 0.25;
	fireTime = 0.3;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDiscReload;
	sfxReady = SoundDiscSpin;
};

function DiscLauncherImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[DiscLauncher]);
	if(%AmmoCount)
	{	
		%cl = Player::getClient(%player);
   %gay = Client::getName(%cl);

		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($DiskerUseMTPack) 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl = Player::GetClient(%target);	 
				%jam = CheckTargetJamming(%target);
				if(%jam == 1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,1,%tpos);
					
					if(%target)
					{	
						Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Disc <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>" @ %name, 10);
					}
				}
				else
				{	
					Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					%name = Client::getName(%target);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Disc <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,0,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
						Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,12,%tpos);
						%playername = Client::getName(%player);
						if(%target)
						{	
							Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
							%name = Client::getName(%target);
							centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Disc <f1>lock on you...take evasive action QUICK!! ");
						      Client::sendMessage(%client,0,"~wmine_act.wav");
						      Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						}
					}
					else
					{	
						Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Disc <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);	
				%objname = GameBase::getDataName($los::object);
				if(%object == "Player" || %object == "Flier") 
				{	
					Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					%name = Client::getName(%targetId);	
                              centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Disc <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);
				}
				else if(%object == "Turret" || %object =="Sensor")
				{	
					Projectile::spawnProjectile("DiscShellTracker",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
					
                              centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Disc <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %objname, 10);
				}
				else
  				{
				
				Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
				Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
			}

			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[DiscLauncher],1);
				Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

ItemData DiscLauncher
{
	description = "Disc Launcher";
	className = "Weapon";
	shapeFile = "disc";
	hudIcon = "disk";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = DiscLauncherImage;
	price = 150;
	showWeaponBar = true;
};

AddWeapon(DiscLauncher);

$DDLSlot = 4;

ItemData TwinFusorAmmo
{
	description = "TwinFusors";
	className = "Ammo";
	shapeFile = "discammo";
   heading = "zAmmo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData DDLI2 
{
	 shapeFile = "disc"; 
	mountPoint = 0; 
	mountRotation = { 0,1.57, 0 };
	mountOffset = { 0.03, 0, 0 };
	 ammoType = TwinFusorAmmo; 
	weaponType = 3; 
	accuFire = true; 

	reloadTime = 0.15;
	fireTime = 0.3;
	spinUpTime = 0.25;
	projectileType = DiscShell; 
}; 

ItemData DualDisc2 
{ 
	description = "TwinFusor";
	 className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
	heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = DDLI2; 
	price = 0; 
	showWeaponBar = false; 
	showInventory = false; 
};

ItemImageData DDLI1 
{ 
	shapeFile = "Disc"; 
	mountPoint = 0; 
	weaponType = 3; 
	mountRotation = { 0,-1.57, 0 }; 
	mountOffset = { 0.1, 0, 0 };
	ammoType = TwinFusorAmmo; 
	accuFire = true; 
	reloadTime = 0.25;
	fireTime = 1.25;
	spinUpTime = 0.25;

	sfxFire = SoundFireDisc; 
	sfxActivate = SoundPickUpWeapon; 
	sfxReload = SoundDiscReload; 
	sfxReady = SoundDiscSpin; 
}; 

ItemData TwinFusor
{ 
	description = "TwinFusor"; 
	className = "Weapon"; 
	shapeFile = "disc"; 
	hudIcon = "disk"; 
   heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = DDLI1; 
	price = 3750; 
	showWeaponBar = true; 
}; 

function TwinFusor::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, DualDisc2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function TwinFusor::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,DualDisc2,$DDLSlot); 
} 

function TwinFusor::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$DDLSlot);
} 

function DDLI1::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,TwinFusorAmmo,0.5); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("DiscShell",%trans,%player,%vel,%player); 
	if(!$DualDisc2Activate[%client]) DD2CheckActivate(%client, %player); 
} 

function DD2CheckActivate(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "TwinFusor")) 
	{ 
		Player::trigger(%player,$DDLSlot,true);
		schedule("DD2CheckActivate(" @ %client @ "," @ %player @ ");",0.05); 
		$DualDisc2Activate[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$DDLSlot,false); 
		$DualDisc2Activate[%client] = false; 
	} 
} 

AddWeapon(TwinFusor);

$WeaponAmmo[TwinFusor]			= TwinFusorAmmo;
$SellAmmo[TwinFusorAmmo]			= 5;

$InvList[TwinFusor] = 1;
$RemoteInvList[TwinFusor] = 1;
$InvList[TwinFusorAmmo] = 1;
$RemoteInvList[TwinFusorAmmo] = 1;
$UplinkInvList[TwinFusor] = 1;
$UplinkInvList[TwinFusorAmmo] = 1;

$ItemMax[harmor, TwinFusor] = 1;
$ItemMax[marmor, TwinFusor] = 1;
$ItemMax[mfemale, TwinFusor] = 1;
$ItemMax[larmor, TwinFusor] = 1;
$ItemMax[lfemale, TwinFusor] = 1;
$ItemMax[BlastechM, TwinFusor] = 1;
$ItemMax[BlastechF, TwinFusor] = 1;
$ItemMax[MagIonM, TwinFusor] = 1;
$ItemMax[MagIonF, TwinFusor] = 1;
$ItemMax[MECH, TwinFusor] = 1;

$ItemMax[harmor, TwinFusorAmmo] = 200;
$ItemMax[marmor, TwinFusorAmmo] = 150;
$ItemMax[mfemale, TwinFusorAmmo] = 150;
$ItemMax[larmor, TwinFusorAmmo] = 50;
$ItemMax[lfemale, TwinFusorAmmo] = 50;
$ItemMax[BlastechM, TwinFusorAmmo] = 100;
$ItemMax[BlastechF, TwinFusorAmmo] = 100;
$ItemMax[MagIonM, TwinFusorAmmo] = 150;
$ItemMax[MagIonF, TwinFusorAmmo] = 150;
$ItemMax[MECH, TwinFusorAmmo] = 200;

#-----------------------------------------------------------------#
# Missile Launcher Script by Valya[AAOD], Z_Dog and INH*DynaBlade # // I can't believe it's not butter..
#-----------------------------------------------------------------#

# Who did what to make this extrodinary script possible
# INH*DynaBlade: 
# Rewrote most of the scripts and tweaked the missiles
#
# Valya[AAOD]:
# The original designer of the Missile Launcher
#
# Z-Dog:
# Implemented new Graphics Design for Missile Launcher

$RRocketgunSlotA = 4;
AddWeapon(aodstinger);
$InvList[AODStinger]			= 1;	
$RemoteInvList[AODStinger]		= 1;
$AutoUse[AODStinger]			= True;
$WeaponAmmo[AODStinger]			= MissileAmmo;
$InvList[MissileAmmo]			= 1;
$RemoteInvList[MissileAmmo]		= 1;
$SellAmmo[MissileAmmo]			= 5;

$ItemMax[larmor,AODStinger]		= 1;
$ItemMax[lfemale,AODStinger]		= 1;
$ItemMax[marmor,AODStinger]		= 1;
$ItemMax[mfemale,AODStinger]		= 1;
$ItemMax[harmor,AODStinger]		= 1;
$ItemMax[MagIonM, AODStinger] 	= 1;
$ItemMax[MagIonF, AODStinger] 	= 1;
$ItemMax[MECH, AODStinger] 		= 1;
$ItemMax[BlastechF, AODStinger] 	= 1;
$ItemMax[BlastechM, AODStinger] 	= 1;

$ItemMax[larmor,MissileAmmo]		= 10;
$ItemMax[lfemale,MissileAmmo]		= 10;
$ItemMax[marmor,MissileAmmo]		= 14;
$ItemMax[mfemale,MissileAmmo]		= 14;
$ItemMax[harmor,MissileAmmo]		= 20;
$ItemMax[MagIonM, MissileAmmo] 	= 14;
$ItemMax[MagIonF, MissileAmmo] 	= 14;
$ItemMax[MECH, MissileAmmo] 		= 15;
$ItemMax[BlastechF, MissileAmmo] 	= 7;
$ItemMax[BlastechM, MissileAmmo] 	= 7;

RocketData AAODRocket
{	
	bulletShapeName  = "rocket.dts";
	explosionTag     = FDExp;
	collisionRadius  = 0.0;
	mass             = 2.0;
	damageClass      = 1;
	damageValue      = 0.5;
	damageType       = $MissileDamageType;
	explosionRadius  = 9.5;
	kickBackStrength = 700.0;
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
	trailString = "shockwave.dts";
	smokeDist   = 1.8;
	soundId = SoundJetHeavy;
};

ItemData MissileAmmo
{	description = "Std Missile Ammo";
	classname = "Ammo";
	shapeFile = "mortarammo";		
	heading = "zAmmo";
	shadowDetailMask = 4;
	price = 50;
};

//***************************************************
// Item Image Definitions
//***************************************************

ItemImageData AODStingerImage
{
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 }; 
	mountRotation = { 0, -1.575, 0};    
	weaponType		= 0; 	
	reloadTime		= 1.5;	
	fireTime		= 0.1;	
	minEnergy		= 5;	
	maxEnergy		= 6;	
	ammoType		= MissileAmmo;
	accuFire		= true;	
	sfxFire			= SoundPickUpBackpack;
	sfxActivate		= SoundPickUpWeapon;
	sfxReload		= SoundMissileReload;
	sfxReady		= SoundMissileIdle;
};

ItemData AODStinger
{	   
	heading = "eLaunchers";
	description		= "Missile Launcher";
	classname		= "Weapon";
	shapeFile		= "GrenadeL";
	hudIcon			= "mortar";
	shadowDetailMask = 4;
	imageType		= AODStingerImage;
	price			= 350;
	showWeaponBar	= true;
};

function AODStingerImage::onFire(%player,%slot) 
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[AODStinger]);
	if(%AmmoCount)
	{	
		%cl = Player::getClient(%player);
   %gay = Client::getName(%cl);

		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack = Player::getMountedItem(%player,$BackpackSlot);

		if(%pack == "TargPack") 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Missile <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));

					}
				}
				else
				{	
					Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Missile <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
					}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
							if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
							centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Missile <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

							playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
						}
					}
					else
					{	
						Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
						if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Missile <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
					Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				%objname = GameBase::getDataName($los::object);
				if(%object == "Player" || %object == "Flier")
				{	
					centerprint(%targetId,"<jc><f0>" @ %gay@" <f1>Has a <f2>Seeking-Missile <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);


					Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				}
				else if(%object == "Turret" || %object =="Sensor")
				{	
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>Seeking-Missile <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %objname, 10);


					Projectile::spawnProjectile("TurretMissile2",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
					if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
					playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				}
				else
			      {	
				Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
				if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
			       }

			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[AODStinger],1);
				if(!$mdFiringAODStinger[%client]) mdCheckAODStinger(%client, %player); 
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

function AODStinger::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, AODStinger2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function AODStinger::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,AODStinger2,$RRocketgunSlotA); 

} 

function AODStinger::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$RRocketgunSlotA);

} 

ItemImageData AODStinger2Image 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
};	

ItemData AODStinger2 
{ 
	description = "Missile Launcher"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = AODStinger2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function mdCheckAODStinger(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "AODStinger")) 
	{ 
		schedule("mdCheckAODStinger(" @ %client @ "," @ %player @ ");",0.01); 
		$mdFiringAODStinger[%client] = true; 
	} 
	else 
	{ 
		$mdFiringAODStinger[%client] = false; 
	} 
} 

//*****************************
// End of Missile Launcher Def
//*****************************

//--------------------------------------------------------------------------------------------------------
// Rocket Propelled Grenade (RPG)
//--------------------------------------------------------------------------------------------------------

ItemImageData RPGImage
{
	shapeFile = "grenadeL";
	mountPoint = 0;
	mountRotation = { 0,3.14, 0 };

	weaponType = 0; // Single Shot
	ammoType = GrenadeAmmo;
	accuFire = false;
	reloadTime = 0.9;
	fireTime = 0.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundMissileTurretFire;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function RPGImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RPGLauncher]);
	if(%AmmoCount)
	{	
		%cl = Player::getClient(%player);
   		%gay = Client::getName(%cl);
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		if ($RPGUseMTPack) 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);

		if(%target)
			{	
				%targetcl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPG <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					%name = Client::getName(%target);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPG <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
						Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
							%name = Client::getName(%target);
							centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPG <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						}
					}
					else
					{	
						Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPG <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				%objname = GameBase::getDataName($los::object);
				if(%object == "Player" || %object == "Flier" )				{	
					Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,$los::object);
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					%name = Client::getName(%targetId);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPG <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
				else if(%object == "Turret" || %object =="Sensor")

				{	
					Projectile::spawnProjectile("SeekingRPG",%trans,%player,%vel,$los::object);
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
					%name = Client::getName(%targetId);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPG <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %objname, 10);


			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
			}
}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPGLauncher],1);
				playSound(SoundMissileTurretFire, GameBase::getPosition(%player));
				Projectile::spawnProjectile("RPG",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

ItemData RPGLauncher
{
	description = "RPG";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "grenade";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = RPGImage;
	price = 400;
	showWeaponBar = true;
};

$AutoUse[RPGLauncher]			= True;

AddWeapon(rpglauncher);

$InvList[RPGLauncher] = 1;
$RemoteInvList[RPGLauncher] = 1;

$ItemMax[larmor, RPGLauncher] = 0;
$ItemMax[lfemale, RPGLauncher] = 0;
$ItemMax[marmor, RPGLauncher] = 1;
$ItemMax[mfemale, RPGLauncher] = 1;
$ItemMax[harmor, RPGLauncher] = 0;
$ItemMax[BlastechF, RPGLauncher] = 0;
$ItemMax[BlastechM, RPGLauncher] = 0;
$ItemMax[MagIonM, RPGLauncher] = 1;
$ItemMax[MagIonF, RPGLauncher] = 1;
$ItemMax[MECH, RPGLauncher] = 0;

$MrpgSlotA=4;
$MrpgSlotB=5;
$MrpgSlotC=6; 

$AutoUse[MrpgLauncher] = True; 
$SellAmmo[MrpgAmmo] = 150; 
$AmmoPackMax[MrpgAmmo] = 50; 
$AmmoPackItems[15] = MrpgAmmo; 
$WeaponAmmo[MrpgLuancher] = MrpgAmmo; 

$InvList[MrpgLauncher]=1;	
$InvList[MrpgAmmo]=1;
$RemoteInvList[MrpgAmmo]=1;

$ItemMax[lfemale,MrpgLauncher]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MrpgLauncher]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MrpgLauncher]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MrpgLauncher]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MrpgLauncher]=1;	// The maximum Heavy of either sex can carry
$ItemMax[MECH, MrpgLauncher]=1;

$ItemMax[lfemale,MrpgAmmo]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MrpgAmmo]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MrpgAmmo]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MrpgAmmo]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MrpgAmmo]=100;	// The maximum Heavy of either sex can carry
$ItemMax[MECH, MrpgAmmo]=150;

ItemData MrpgAmmo 
{ 
	description = "RPGs"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "zAmmo";
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MrpgLauncherImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.305, -0.20, 0.25 }; 
	mountRotation = { 0, 1.50, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	fireTime = 0.2;
	minEnergy	= 5;	
	maxEnergy	= 6;
	ammoType = MrpgAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickupminigun; 
	sfxReload = SoundSpinUp; 
	sfxReady = SoundMiniDown; 
}; 

function MrpgLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,Mrpgammo,1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("RPG",%trans,%player,%vel,%player); 
	if(!$MDFiringMrpgLauncher[%client]) MDCheckMrpgLauncher(%client, %player); 
} 

addweapon(mrpgLauncher);

ItemData MrpgLauncher 
{ 
	description = "Kabutsuchi"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	mountOffset = { -1.1, 0.02, 0.4 }; 
	mountRotation = { 0, -1.1, 0}; 
	hudIcon = "chain"; 
	heading = "eLaunchers"; 
	shadowDetailMask = 4; 
	imageType = MrpgLauncherImage; 
	price = 550; 
	showWeaponBar = true; 
}; 

function MrpgLauncher::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, MrpgLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function MrpgLauncher::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,MrpgLauncher2,$MrpgSlotA); 
	Player::mountItem(%player,MrpgLauncher3,$MrpgSlotB); 
	Player::mountItem(%player,MrpgLauncher4,$MrpgSlotC); 
} 

function MrpgLauncher::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MrpgSlotA);
	Player::unmountItem(%player,$MrpgSlotB);	 
	Player::unmountItem(%player,$MrpgSlotC);
} 

ItemImageData MrpgLauncher2Image 
{ 
	ammoType = MrpgAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.35, 0 }; 
	mountRotation = { 0, 1.0, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
}; 

ItemData MrpgLauncher2 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = MrpgLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData MrpgLauncher3Image 
{ 
	ammoType = MrpgAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.35, 0 }; 
	mountRotation = { 0, -1.0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
}; 

ItemData MrpgLauncher3 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = MrpgLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
};
 
ItemImageData MrpgLauncher4Image 
{ 
	ammoType = MrpgAmmo; 
	projectileType = RPG; 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = {0.10, -0.20, 0.25 }; 
	mountRotation = { 0, -1.50, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	accuFire = false; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
}; 

ItemData MrpgLauncher4 
{ 
	description = "MECHRPG"; 
	className = "Weapon"; 
	shapeFile = "grenadeL"; 
	hudIcon = "chain"; 
	heading = "eLaunchers";
	shadowDetailMask = 4; 
	imageType = MrpgLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMrpgLauncher(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "MrpgLauncher")) 
	{ 
		Player::trigger(%player,$MrpgSlotA,true);
		Player::trigger(%player,$MrpgSlotB,true);
		Player::trigger(%player,$MrpgSlotC,true); 
		schedule("MDCheckMrpgLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringMrpgLauncher[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MrpgSlotA,false); 
		Player::trigger(%player,$MrpgSlotB,false); 
		Player::trigger(%player,$MrpgSlotC,false); 
		$MDFiringMrpgLauncher[%client] = false; 
	} 
} 
//--------------------------------------------------------------------------------------------------------
// Rocket Propelled Mortar (RPM)
//--------------------------------------------------------------------------------------------------------

ItemImageData RPMImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	mountRotation = { 0,3.14, 0 };

	weaponType = 0; // Single Shot
	ammoType = MortarAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

function RPMImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RPMLauncher]);
	if(%AmmoCount)
	{	
		%cl = Player::getClient(%player);
   		%gay = Client::getName(%cl);
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($RPMUseMTPack)
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)
			{	
				%targetcl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
				}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPM <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					%name = Client::getName(%target);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPM <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
						Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
							%name = Client::getName(%target);
							centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPM <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						}
					}
					else
					{	
						Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPM <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				%objname = GameBase::getDataName($los::object);
				if(%object == "Player" || %object == "Flier")
				{	
					Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					%name = Client::getName(%targetId);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPM <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
				else if(%object == "Turret" || %object == "Sensor")
				{	
					Projectile::spawnProjectile("SeekingRPM",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
					%name = Client::getName(%targetId);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPM <f1>lock on you...take evasive action QUICK!! ");
					Client::sendMessage(%client,0,"~wmine_act.wav");
					Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %objname, 10);

				

			}
			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
				Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
			}
		}

			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPMLauncher],1);
				Projectile::spawnProjectile("RPM",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

ItemData RPMLauncher
{
	description = "RPM";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = RPMImage; 
	price = 800;
	showWeaponBar = true;
};

$AutoUse[RPMLauncher]			= True;

AddWeapon(rpmlauncher);

$InvList[RPMLauncher] = 1;
$RemoteInvList[RPMLauncher] = 1;

$ItemMax[larmor, RPMLauncher] = 0;
$ItemMax[lfemale, RPMLauncher] = 0;
$ItemMax[marmor, RPMLauncher] = 0;
$ItemMax[mfemale, RPMLauncher] = 0;
$ItemMax[harmor, RPMLauncher] = 1;
$ItemMax[BlastechF, RPMLauncher] = 0;
$ItemMax[BlastechM, RPMLauncher] = 0;
$ItemMax[MagIonM, RPMLauncher] = 0;
$ItemMax[MagIonF, RPMLauncher] = 0;
$ItemMax[MECH, RPMLauncher] = 1;
//----------------------------------
// Mech Annihilator
//----------------------------------

$MMminigunSlotA=4;
$MMminigunSlotB=5;
$MMminigunSlotC=6; 

addweapon(MMminigun);
$AutoUse[MMminigun] = True; 
$SellAmmo[MMminigunAmmo] = 50; 
$AmmoPackMax[MMminigunAmmo] = 75; 
$AmmoPackItems[14] = MMminigunAmmo; 
$WeaponAmmo[MMminigun] = MMminigunAmmo; 

$InvList[MMminigun]=1;	
$InvList[MMminigunAmmo]=1;
//$RemoteInvList[Mminigun]=1;		// Some weapons are not available from remote inventory units
$RemoteInvList[MMminigunAmmo]=1;

$ItemMax[lfemale,MMminigun]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MMminigun]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MMminigun]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MMminigun]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MMminigun]=1;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MMminigun] = 0;
$ItemMax[BlastechF, MMminigun] = 0;
$ItemMax[MagIonM, MMminigun] = 0;
$ItemMax[MagIonF, MMminigun] = 0;
$ItemMax[MECH, MMminigun] = 1;

$ItemMax[lfemale,MMminigunAmmo]=0;	// The maximum Light Female can carry
$ItemMax[larmor,MMminigunAmmo]=0;	// The maximum Light Male can carry
$ItemMax[mfemale,MMminigunAmmo]=0;	// The maximum Medium Female can carry
$ItemMax[marmor,MMminigunAmmo]=0;	// The maximum Medium Male can carry
$ItemMax[harmor,MMminigunAmmo]=200;	// The maximum Heavy of either sex can carry
$ItemMax[BlastechM, MMminigunAmmo] = 0;
$ItemMax[BlastechF, MMminigunAmmo] = 0;
$ItemMax[MagIonM, MMminigunAmmo] = 0;
$ItemMax[MagIonF, MMminigunAmmo] = 0;
$ItemMax[MECH, MMminigunAmmo] = 200;

ItemData MMminigunAmmo 
{ 
	description = "MMminigun Ammo"; 
	className = "Ammo"; 
	shapeFile = "ammo1"; 
	heading = "zAmmo"; 
	shadowDetailMask = 4; 
	price = 1; 
}; 

ItemImageData MMminigunImage 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -1.3051, -0.201, 0.251 }; 
	mountRotation = { 0, 1.501, 0 }; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMminigunAmmo; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
	sfxActivate = SoundPickupminigun; 
	//sfxSpinUp = SoundSpinUp; 
	sfxSpinDown = SoundMiniDown; 
}; 

function MMminigunImage::onFire(%player, %slot) 

{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[MMminigun],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("GaussBullet",%trans,%player,%vel,%player); 
	if(!$MDFiringMMinigun[%client]) MDCheckMMminigun(%client, %player); 
} 

ItemData MMminigun 
{ 
	description = "MECH Annihilator"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
   heading = "cGatling Weapons";
	shadowDetailMask = 4; 
	imageType = MMminigunImage; 
	price = 7500; 
	showWeaponBar = true; 
}; 

function MMminigun::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, MMminigun2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function MMminigun::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,MMminigun2,$MMminigunSlotA); 
	Player::mountItem(%player,MMminigun3,$MMminigunSlotB); 
	Player::mountItem(%player,MMminigun4,$MMminigunSlotC); 
} 

function MMminigun::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MMminigunSlotA);
	Player::unmountItem(%player,$MMminigunSlotB);	 
	Player::unmountItem(%player,$MMminigunSlotC);
} 

ItemImageData MMminigun2Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { -1.21, -0.351, 0 }; 
	mountRotation = { 0, 1.01, 0}; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMminigunAmmo; 
	projectileType = GaussBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMminigun2 
{ 
	description = "MECH Annihilator"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMminigun2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

ItemImageData MMminigun3Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.351, 0 }; 
	mountRotation = { 0, -1.01, 0 }; 
	weaponType = 1; 
	reloadTime = 0; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.1; 
	ammoType = MMminigunAmmo; 
	projectileType = GatlingBlasterBolt; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMminigun3 
{ 
	description = "MECH Annihilator"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMminigun3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 
ItemImageData MMminigun4Image 
{ 
	shapeFile = "chaingun"; 
	mountPoint = 0;
	mountOffset = {0.101, -0.201, 0.251 }; 
	mountRotation = { 0, -1.501, 0};  
	weaponType = 1; 
	reloadTime = 0.5; 
	spinUpTime = 0.1; 
	spinDownTime = 0.1; 
	fireTime = 0.25; 
	ammoType = MMminigunAmmo; 
	projectileType = GaussBullet; 
	accuFire = true; 
	lightType = 3; 
	lightRadius = 3; 
	lightTime = 1; 
	lightColor = { 0.6, 1, 1 }; 
	sfxFire = SoundFireChaingun; 
}; 

ItemData MMminigun4 
{ 
	description = "MECH Annihilator"; 
	className = "Weapon"; 
	shapeFile = "chaingun"; 
	hudIcon = "chain"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MMminigun4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMMminigun(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "MMminigun")) 
	{ 
		Player::trigger(%player,$MMminigunSlotA,true);
		Player::trigger(%player,$MMminigunSlotB,true);
		Player::trigger(%player,$MMminigunSlotC,true); 
		schedule("MDCheckMMminigun(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringMMminigun[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MMminigunSlotA,false); 
		Player::trigger(%player,$MMminigunSlotB,false); 
		Player::trigger(%player,$MMminigunSlotC,false); 
		$MDFiringMMminigun[%client] = false; 
	} 
} 
//--------------------------------------------------------------------------------------------------------
// Rocket Propelled ElectroMagneticPulse (RPEMP)
//--------------------------------------------------------------------------------------------------------

ItemData RPEMPAmmo
{
	description = "RPEMP Ammo";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "mortar";
	shadowDetailMask = 4;
	price = 5;
};

ItemImageData RPEMPImage
{
	shapeFile = "mortargun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = EMPGrenadeAmmo;
	accuFire = false;
	reloadTime = 0.5;
	fireTime = 2.0;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundLaserIdle;
};

function RPEMPImage::onFire(%player,%slot)
{	
	%AmmoCount = Player::getItemCount(%player, $WeaponAmmo[RPEMPLauncher]);
	if(%AmmoCount)
	{	
		%cl = Player::getClient(%player);
   		%gay = Client::getName(%cl);
		%client = GameBase::getOwnerClient(%player);
		%trans = GameBase::getMuzzleTransform(%player);
		%vel = Item::getVelocity(%player);
		%pack=Player::getMountedItem(%player,$BackpackSlot);
		if ($RPEMPUseMTPack) 
		{	
			GameBase::getLOSInfo(%player,1024);
			%tpos=($los::position);
			%target=AquireTarget(%player,0,%tpos);
			if(%target)

		{	
				%targetcl=Player::GetClient(%target);	 
				%jam=CheckTargetJamming(%target);
				if(%jam==1)
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);


			}
				else if(%jam==2)
				{	
					%tpos=GameBase::getPosition(%player);
					%target=AquireTarget(%player,2,%tpos);
					if(%target)
					{	
						Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPEMP <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,%target);
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					%name = Client::getName(%target);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPEMP <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
			}
			else
			{	
				%tpos=GameBase::getPosition(%player);
				%target=AquireTarget(%player,1,%tpos);
				if(%target)
				{	
					%TargetCl=Player::GetClient(%target);	 
					%jam=CheckTargetJamming(%target);
					if(%jam==1)
					{	
						Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
						Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);
		}
					else if(%jam==2)
					{	
						%tpos=GameBase::getPosition(%player);
						%target=AquireTarget(%player,2,%tpos);
						if(%target)
						{	
							Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,%target);
							Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
							%name = Client::getName(%target);
							centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPEMP <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

						}
					}
					else
					{	
						Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,%target);
						Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
						%name = Client::getName(%target);
						centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPEMP <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

					}
				}
				else
				{	
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);
				}
			}
			
		}
		else
		{		
			if(GameBase::getLOSInfo(%player,1024))
			{	
				%object = getObjectType($los::object);
				%targetId = GameBase::getOwnerClient($los::object);
				%objname = GameBase::getDataName($los::object);			
				if(%object == "Player" || %object == "Flier")
				{	
					Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					%name = Client::getName(%targetId);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPEMP <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %name, 10);

				}
				else if(%object == "Turret" || %object == "Sensor")
				{	
					Projectile::spawnProjectile("SeekingRPEMP",%trans,%player,%vel,$los::object);
					Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
					%name = Client::getName(%targetId);
					centerprint(%targetId,"<jc><f0>" @ %gay @" <f1>Has a <f2>RPEMP <f1>lock on you...take evasive action QUICK!! ");
						Client::sendMessage(%client,0,"~wmine_act.wav");
						Bottomprint(%client, "<jc><f0>Target Acquired : <f2>"@ %objname, 10);

				}
				else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
				Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);
			}
		}

			else
			{	
				Player::decItemCount(%player,$WeaponAmmo[RPEMPLauncher],1);
				Projectile::spawnProjectile("RPEMP",%trans,%player,%vel,$los::object);
			}
		}
	}
	else
		Client::sendMessage(%client,0,"** Out of Ammo!! ** ~waccess_denied.wav");
}

ItemData RPEMPLauncher
{
	description = "RPEMP";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "grenade";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = RPEMPImage; 
	price = 1600;
	showWeaponBar = true;
};

$AutoUse[RPEMPLauncher]			= True;

AddWeapon(rpemplauncher);

$InvList[RPEMPLauncher] = 1;
$RemoteInvList[RPEMPLauncher] = 1;

$ItemMax[larmor, RPEMPLauncher] = 0;
$ItemMax[lfemale, RPEMPLauncher] = 0;
$ItemMax[marmor, RPEMPLauncher] = 0;
$ItemMax[mfemale, RPEMPLauncher] = 0;
$ItemMax[harmor, RPEMPLauncher] = 1;
$ItemMax[BlastechF, RPEMPLauncher] = 0;
$ItemMax[BlastechM, RPEMPLauncher] = 0;
$ItemMax[MagIonM, RPEMPLauncher] = 0;
$ItemMax[MagIonF, RPEMPLauncher] = 0;
$ItemMax[MECH, RPEMPLauncher] = 1;

//=============================================================================================\\

$MRocketgunSlotA=4;
$MRocketgunSlotB=5;
$MRocketgunSlotC=6; 

addweapon(MECHRocketLauncher);
$InvList[MECHRocketLauncher]			= 1;	
$RemoteInvList[MECHRocketLauncher]		= 1;
$AutoUse[MECHRocketLauncher]			= True;

$WeaponAmmo[MECHRocketLauncher]                  = MissileAmmo;
$AmmoPackMax[MissileAmmo] 		= 8; 
$AmmoPackItems[21] = MissileAmmo; 

$ItemMax[larmor,MECHRocketLauncher]		= 1;
$ItemMax[lfemale,MECHRocketLauncher]		= 1;
$ItemMax[marmor,MECHRocketLauncher]		= 0;
$ItemMax[mfemale,MECHRocketLauncher]		= 0;
$ItemMax[harmor,MECHRocketLauncher]		= 1;
$ItemMax[BlastechF, MECHRocketLauncher] = 0;
$ItemMax[BlastechM, MECHRocketLauncher] = 0;
$ItemMax[MagIonM, MECHRocketLauncher] = 0;
$ItemMax[MagIonF, MECHRocketLauncher] = 0;
$ItemMax[MECH, MECHRocketLauncher] = 1;

ItemImageData MECHRocketLauncherImage 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.345, 0.08, 0.004 }; 
	mountRotation = { 0, 1.575, 0 }; 
	weaponType = 0; 
	reloadTime = 1.5; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	sfxActivate = SoundPickupminigun; 
	sfxReload = SoundSpinUp; 
	sfxReady = SoundMiniDown; 
}; 

//-----------------
//  Begin MECHRocketLauncher Fire Function
//-----------------


function MECHRocketLauncherImage::onFire(%player, %slot) 
{ 
	%client = GameBase::getOwnerClient(%player); 
	Player::decItemCount(%player,$WeaponAmmo[MECHRocketLauncher],1); 
	%trans = GameBase::getMuzzleTransform(%player); 
	%vel = Item::getVelocity(%player); 
	Projectile::spawnProjectile("AAODRocket",%trans,%player,%vel,%player); 
	if(!$MDFiringMECHRocketLauncher[%client]) MDCheckMECHRocketLauncher(%client, %player); 
} 

ItemData MECHRocketLauncher 
{ 
	description = "MECHRocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	mountOffset = { -1.345, 0.08, 0.004 }; 
	mountRotation = { 0, 1.575, 0 }; 
	hudIcon = "mortar"; 
	heading = "eLaunchers"; 
	shadowDetailMask = 4; 
	imageType = MECHRocketLauncherImage; 
	price = 550; 
	showWeaponBar = true; 
}; 

function MECHRocketLauncher::onDrop(%player,%item) 
{ 
	%state = Player::getItemState(%player,$WeaponSlot); 
	if (%state != "Fire" && %state != "Reload") 
	{ 
		Player::setItemCount(%player, MECHRocketLauncher2, 0); 
		Item::onDrop(%player,%item); 
	}
} 

function MECHRocketLauncher::onMount(%player,%imageSlot) 
{ 
	Player::mountItem(%player,MECHRocketLauncher2,$MRocketgunSlotA); 
	Player::mountItem(%player,MECHRocketLauncher3,$MRocketgunSlotB); 
	Player::mountItem(%player,MECHRocketLauncher4,$MRocketgunSlotC); 
} 

function MECHRocketLauncher::onUnmount(%player,%imageSlot) 
{ 
	Player::unmountItem(%player,$MRocketgunSlotA);
	Player::unmountItem(%player,$MRocketgunSlotB);	 
	Player::unmountItem(%player,$MRocketgunSlotC);
} 


ItemImageData MECHRocketLauncher2Image 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { -1.2, -0.45, 0 }; 
	mountRotation = { 0, 0, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
};	

ItemData MECHRocketLauncher2 
{ 
	description = "MECHRocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortar"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MECHRocketLauncher2Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 
ItemImageData MECHRocketLauncher3Image 
{ 

shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0, -0.45, 0 }; 
	mountRotation = { 0, 0, 0 }; 
	weaponType = 0; 
	reloadTime = 1.0; 
	ammoType = MissileAmmo; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
}; 

ItemData MECHRocketLauncher3 
{ 
	description = "MECHRocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MECHRocketLauncher3Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 
ItemImageData MECHRocketLauncher4Image 
{ 
	shapeFile = "mortargun"; 
	mountPoint = 0; 
	mountOffset = { 0.15, 0.08, 0.01 }; 
	mountRotation = { 0, -1.575, 0}; 
	weaponType = 0; 
	reloadTime = 1.0; 
	ammoType = MissileAmmo; 
	projectileType = AAODRocket; 
	accuFire = true; 
	sfxFire = SoundMissileTurretFire; 
	fireTime = 0.1;
	minEnergy	= 5;	
	maxEnergy	= 6;
}; 

ItemData MECHRocketLauncher4 
{ 
	description = "MECHRocketgun"; 
	className = "Weapon"; 
	shapeFile = "mortargun"; 
	hudIcon = "mortar"; 
	heading = "bWeapons"; 
	shadowDetailMask = 4; 
	imageType = MECHRocketLauncher4Image; 
	price = 0; 
	showWeaponBar = true; 
	showInventory = false; 
}; 

function MDCheckMECHRocketLauncher(%client, %player) 
{ 
	if(Player::isTriggered(%player,$WeaponSlot) && (Player::getMountedItem(%player,$WeaponSlot) == "MECHRocketLauncher")) 
	{ 
		Player::trigger(%player,$MRocketgunSlotC,true);
		schedule("MDCheckMECHRocketLauncher(" @ %client @ "," @ %player @ ");",0.1); 
		$MDFiringMECHRocketLauncher[%client] = true; 
	} 
	else 
	{ 
		Player::trigger(%player,$MRocketgunSlotC,false); 
		$MDFiringMECHRocketLauncher[%client] = false; 
	} 
} 

//--------------------------------------------------------------------------------------------------------
// Laser Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData LaserPistolImage
{
	shapeFile = "energygun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.05;
	fireTime = 0.25;
	minEnergy = 10;
	maxEnergy = 10;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserPistol
{
	description = "Laser Pistol";
	className = "Weapon";
	shapeFile = "energygun";
	hudIcon = "sniper";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = LaserPistolImage;
	price = 100;
	showWeaponBar = true;
};

AddWeapon(LaserPistol);

$InvList[LaserPistol] = 1;
$RemoteInvList[LaserPistol] = 1;

$ItemMax[larmor, LaserPistol] = 0;
$ItemMax[marmor, LaserPistol] = 1;
$ItemMax[lfemale, LaserPistol] = 0;
$ItemMax[mfemale, LaserPistol] = 1;
$ItemMax[harmor, LaserPistol] = 1;
$ItemMax[BlastechF, LaserPistol] = 0;
$ItemMax[BlastechM, LaserPistol] = 0;
$ItemMax[MagIonM, LaserPistol] = 1;
$ItemMax[MagIonF, LaserPistol] = 1;
$ItemMax[MECH, LaserPistol] = 1;

//--------------------------------------------------------------------------------------------------------
// Laser Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData LaserRifleImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	projectileType = SniperLaser;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 40;

	lightType = 3;  // Weapon Fire
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LaserRifle
{
	description = "HP Laser Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "sniper";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = LaserRifleImage;
	price = 200;
	showWeaponBar = true;
};

AddWeapon(LaserRifle);

//--------------------------------------------------------------------------------------------------------
// Particle Beam Weapon
//--------------------------------------------------------------------------------------------------------

$AutoUse[PBW]			= True;

AddWeapon(PBW);

$InvList[PBW] = 1;
$RemoteInvList[PBW] = 1;

$ItemMax[harmor, PBW] = 0;
$ItemMax[marmor, PBW] = 1;
$ItemMax[mfemale, PBW] = 1;
$ItemMax[larmor, PBW] = 1;
$ItemMax[lfemale, PBW] = 1;
$ItemMax[BlastechF, PBW] = 1;
$ItemMax[BlastechM, PBW] = 1;
$ItemMax[MagIonM, PBW] = 1;
$ItemMax[MagIonF, PBW] = 1;
$ItemMax[MECH, PBW] = 0;

ItemImageData PBWImage 
{
	shapeFile = "grenammo";
	mountPoint = 0;

	weaponType = 0; 
	minEnergy = 40;
	maxEnergy = 80;
      projectileType = ParticleBeam;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0.5;
	
	sfxFire = SoundPBWBreakSoundBarrier; 
	sfxActivate = SoundDryFire;
	sfxReload = SoundPBWRecharge;
};

ItemData PBW
{
	description = "Particle Beam (PBW)";
	className = "Weapon";
	shapeFile = "grenammo";
	hudIcon = "blaster";
   heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = PBWImage;
	price = 2500;
	showWeaponBar = true;
};


//======================================================================================

$WeaponAmmo[LasCannon] = "Beacon";

$AutoUse[LasCannon]			= True;

AddWeapon(LasCannon);

$InvList[LasCannon] = 1;
$RemoteInvList[LasCannon] = 1;

$ItemMax[harmor, LasCannon] = 1;
$ItemMax[marmor, LasCannon] = 0;
$ItemMax[mfemale, LasCannon] = 0;
$ItemMax[larmor, LasCannon] = 0;
$ItemMax[lfemale, LasCannon] = 0;
$ItemMax[BlastechF, LasCannon] = 0;
$ItemMax[BlastechM, LasCannon] = 0;
$ItemMax[MagIonM, LasCannon] = 0;
$ItemMax[MagIonF, LasCannon] = 0;
$ItemMax[MECH, LasCannon] = 1;

ItemImageData LasCannonImage
{
	shapeFile = "mortargun";
	mountPoint = 0;
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 140;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	mass = 2.5;
	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData LasCannon
{
	description = "Death Ray";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "fBeam Weapons";
	shadowDetailMask = 4;
	imageType = LasCannonImage;
	price = 5000;
	mass = 2.5;
	showWeaponBar = true;

};


function LasCannonImage::onFire(%player, %slot) 
{
	%clientId = player::getclient(%player);
	
	if (%clientId.lascharge)
	{
		%clientId.charging = "";
		%lc = %clientId.lascharge;
		%armor = Player::getArmor(%player); %client = GameBase::getOwnerClient(%player); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); %pos = (gamebase::getposition(%player));	 %rot = (gamebase::getrotation(%player)); %dir = (Vector::getfromrot(%rot));

		if (%lc > 0)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
		}
		if (%lc > 3)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.2);		
		}
		if (%lc > 5)
		{
			schedule ("Projectile::spawnProjectile(GatlingLaser, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.15);
		}
		if (%lc > 7)
		{
			schedule ("Projectile::spawnProjectile(GatlingLaser, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.4);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.45);
		}
		if (%lc > 9)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.3);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.35);		

		}
		
		if (%lc == 15)
		{
			schedule ("Projectile::spawnProjectile(LasCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.35);
			schedule ("Projectile::spawnProjectile(LasCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.375);
			schedule ("Projectile::spawnProjectile(LasCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.35);
		}

		%clientId.lascharge = "0";
		return;
	}
	else
	{
		Client::sendMessage(%clientId,1,"** Death Ray uses Beacons to charge...~waccess_denied.wav");
		return;
	}
}


function LasCannoner::Charge(%clientId, %time)
{
	%player = client::getownedobject(%clientId);

	Player::mountItem(%clientId, LasCannon, $WeaponSlot);

	if (!%clientId.charging)
		return;
	
	if (%time > 0)
	{
		%time--;
		schedule("LasCannoner::Charge(" @ %clientId @", " @ %time @ ");",1.0);
		BottomPrint (%clientId, "** " @ %time @ " before full charge ", 1);
		%clientId.lascharge++;
		return;
	}

	else
	{
		BottomPrint (%clientId, "** Full charge attained... Ready!\n<f1>** Warning ** Due to the extreme stress of all that energy, the Death Ray may overload... ETA: 15 seconds"  , 5);
		%clientId.lascharge = 15;
		LasCannoner::Detonate(%clientId, 15);
		return;
	}
}

function LasCannoner::Detonate(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	Player::mountItem(%clientId, LasCannon, $WeaponSlot);
	
	if (%clientId.lascharge != 15)
		return;

	if (%time > 0)
	{
		%time--;
		schedule("LasCannoner::Detonate(" @ %clientId @", " @ %time @ ");",1.0);
	}
	else 
	{
		%clientId.charging = "";
		%clientId.lascharge = "0";
		Player::blowUp(%clientId);
			
			%obj = newObject("","Mine","HavocBlast");
			GameBase::throw(%obj,%clientId,0,false);		
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 1.5";
			%pos = Vector::add(GameBase::getPosition(%clientId), %padd);
			GameBase::setPosition(%obj, %pos);
		return;
	}
	if (%time > 0 && %time < 10)
	{
		bottomprint (%clientId, "<jc>** ETA to overload: " @ %time @ " seconds", 1);	
	}
}

LaserData GatlingLaser
{
	laserBitmapName   = "lightningNew.bmp";
	hitName           = "shield.dts";
	damageConversion  = 0.10;
	baseDamageType    = $LaserDamageType;
	beamTime          = 2.5;
	lightRange        = 5.0;
	lightColor        = { 0.01, 0.01, 1.25 };
	detachFromShooter = true;
	hitSoundId        = SoundLaserHit;
};

//========================================================================
RocketData LasCannonBolt
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = ShockwaveFour; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 0;
    	damageValue = 0.8; 
	damageType = $LaserDamageType;
	explosionRadius = 2; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 


	terminalVelocity = 3000.0;
	acceleration = 500; 
	totalTime = 14.0; 
	liveTime = 14.0; 
	lightRange = 5.0; 
	lightColor = { 0.0, 0.0, 1.5 }; 
	inheritedVelocityScale = 0.0; 
	trailType = 1;
	trailLength = 3000; 
	trailWidth = 2.0; 
	soundId = SoundJetHeavy;
};

RocketData LasCannonBolt2
{ 
	bulletShapeName = "enbolt.dts"; 
	explosionTag = ShockwaveFour; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 0;
    	damageValue = 0.5; 
	damageType = $LaserDamageType;
	explosionRadius = 2; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 250.0; 
	terminalVelocity = 3000.0;
	acceleration = 500; 
	totalTime = 14.0; 
	liveTime = 14.0; 
	lightRange = 5.0; 
	lightColor = { 0.0, 0.0, 1.5 }; 
	inheritedVelocityScale = 0.0; 
	trailType = 1;
	trailLength = 3000; 
	trailWidth = 1.0; 
	soundId = SoundJetHeavy;
};

RocketData LasCannonShock
{
	bulletShapeName  = "shield.dts";
	explosionTag     = ShockwaveFour;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 0;
	damageValue      = 1.0;
	damageType       = $LaserDamageType;
	explosionRadius  = 5.0;
	kickBackStrength = 0;
	muzzleVelocity   = 250.0;
	terminalVelocity = 4000.0;

	acceleration     = 500.0;
	totalTime        = 14.0;
	liveTime         = 14.0;
	lightRange       = 5.0;
	lightColor       = { 0.0, 0.1, 1.5 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "shield.dts";
	smokeDist   = 20.0;
	soundId = SoundJetHeavy;
};


//--------------------------------------------------------------------------------------------------------
// Poison Dart Rifle
//--------------------------------------------------------------------------------------------------------

ItemData Darts
{
	description = "Poison Darts";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData DartGunImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Darts;
	projectileType = PoisonDart;
	accuFire = true;
	reloadTime = 1.5;
	fireTime = 0;

	lightType = 3;  // Weapon Fire
	lightRadius = 6;
	lightTime = 2;
	lightColor = { 1.0, 0, 0 };

	sfxFire = SoundFirePistol;
	sfxActivate = SoundPickUpWeapon;
	
};

ItemData DartGun
{
	description = "Poison Dart Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = DartGunImage;
	price = 300;
	showWeaponBar = true;
};

$SellAmmo[Darts]			= 20;

AddWeapon(dartgun);

$InvList[DartGun] = 1;
$RemoteInvList[DartGun] = 1;

$AmmoPackMax[Darts] = 30;
$AmmoPackItems[22] = Darts;

$InvList[Darts] = 1;
$RemoteInvList[Darts] = 1;

$ItemMax[larmor, DartGun] = 1;
$ItemMax[lfemale, DartGun] = 1;
$ItemMax[marmor, DartGun] = 1;
$ItemMax[mfemale, DartGun] = 1;
$ItemMax[harmor, DartGun] = 0;
$ItemMax[BlastechF, DartGun] = 1;
$ItemMax[BlastechM, DartGun] = 1;
$ItemMax[MagIonM, DartGun] = 1;
$ItemMax[MagIonF, DartGun] = 1;
$ItemMax[MECH, DartGun] = 0;

$ItemMax[larmor, Darts] = 5;
$ItemMax[lfemale, Darts] = 5;
$ItemMax[marmor, Darts] = 10;
$ItemMax[mfemale, Darts] = 10;
$ItemMax[harmor, Darts] = 0;
$ItemMax[BlastechF, Darts] = 5;
$ItemMax[BlastechM, Darts] = 5;
$ItemMax[MagIonM, Darts] = 10;
$ItemMax[MagIonF, Darts] = 10;
$ItemMax[MECH, Darts] = 0;

ItemData Shells
{
	description = "Shells";
	className = "Ammo";
    heading = "zAmmo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
};
//=======================================

ItemData ARAmmo
{
	description = "Assault Bullets";
   heading = "xAmmunition";
	className = "Ammo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData ARImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = ARAmmo;
	projectileType = AssaultBullet;
	accuFire = true;
	reloadTime = 0.02;
	fireTime = 0.2;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = debrisSmallExplosion;
	sfxActivate = SoundJetLight;
	sfxReload = SoundJetLight;
};

ItemData AR
{
	description = "Assault Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = ARImage;
	price = 1300;
	showWeaponBar = true;
};
$SellAmmo[ARAmmo]			= 125;
$AmmoPackMax[ARAmmo]		= 10;

AddWeapon(AR);

$InvList[ARAmmo] = 1;
$RemoteInvList[ARAmmo] = 1;

$InvList[AR] = 1;
$RemoteInvList[AR] = 1;

$ItemMax[larmor, AR] = 0;
$ItemMax[lfemale, AR] = 0;
$ItemMax[marmor, AR] = 1;
$ItemMax[mfemale, AR] = 1;
$ItemMax[harmor, AR] = 1;

$ItemMax[larmor, ARAmmo] = 0;
$ItemMax[lfemale, ARAmmo] = 0;
$ItemMax[marmor, ARAmmo] = 100;
$ItemMax[mfemale, ARAmmo] = 100;
$ItemMax[harmor, ARAmmo] = 125;

//--------------------------------------------------------------------------------------------------------
// 80mm Railgun
//--------------------------------------------------------------------------------------------------------

ItemData RailAmmo 
{
  description = "Railgun Bolt";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData RailgunImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = RailAmmo;
  projectileType = RailRound;
  accuFire = true;
  reloadTime = 0.8;
  fireTime = 0.5;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundMissileTurretFire;
  sfxActivate = SoundPickUpWeapon;
  sfxSpinUp = SoundSpinUp;
  sfxSpinDown = SoundSpinDown;
};

ItemData Railgun 
{
  description = "80MM RailGun";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = "gRifles";
  shadowDetailMask = 4;
  imageType = RailgunImage;
  price = 1500;
  showWeaponBar = true;
};
    
$SellAmmo[RailAmmo]			= 30;
$AmmoPackMax[RailAmmo]		= 10;

AddWeapon(Railgun);

$InvList[RailAmmo] = 1;
$RemoteInvList[RailAmmo] = 1;

$InvList[Railgun] = 1;
$RemoteInvList[Railgun] = 1;

$ItemMax[larmor, Railgun] = 1;
$ItemMax[lfemale, Railgun] = 1;
$ItemMax[marmor, Railgun] = 1;
$ItemMax[mfemale, Railgun] = 1;
$ItemMax[harmor, Railgun] = 1;
$ItemMax[BlastechF, Railgun] = 1;
$ItemMax[BlastechM, Railgun] = 1;
$ItemMax[MagIonM, Railgun] = 1;
$ItemMax[MagIonF, Railgun] = 1;
$ItemMax[MECH, Railgun] = 1;

$ItemMax[larmor, RailAmmo] = 20;
$ItemMax[lfemale, RailAmmo] = 20;
$ItemMax[marmor, RailAmmo] = 20;
$ItemMax[mfemale, RailAmmo] = 20;
$ItemMax[harmor, RailAmmo] = 20;
$ItemMax[BlastechF, RailAmmo] = 20;
$ItemMax[BlastechM, RailAmmo] = 20;
$ItemMax[MagIonM, RailAmmo] = 20;
$ItemMax[MagIonF, RailAmmo] = 20;
$ItemMax[MECH, RailAmmo] = 20;

//--------------------------------------------------------------------------------------------------------
// 60MM Rifle
//--------------------------------------------------------------------------------------------------------

ItemImageData RailGun2Image
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0, -0.15 };

	weaponType = 0; // Single Shot
	ammoType = Shells;
	projectileType = RifleBullet;
	accuFire = true;
	reloadTime = 0.6;
	fireTime = 0.2;
};

ItemData RailGun2
{
	description = "60MM RailGun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = RailGun2Image;
	price = 200;
	showWeaponBar = true;
	showInventory = false;	
};

function RifleImage::onFire(%player,%imageSlot)
{
	Player::trigger(%player,$ExtraWeaponSlot,true);
	Player::trigger(%player,$ExtraWeaponSlot,false);
}

ItemImageData scopeImage
{
	shapeFile = "paintgun";
	mountPoint = 0;
	mountOffset = { 0, 0, 0 };
	weaponType = 2; // Single Shot
	projectileType = RailLaser;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.2;
	minEnergy = 0;
	maxEnergy = 0;

	sfxActivate = SoundPickUpWeapon;
};

ItemData scope
{
	description = "60MM RailGun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "targetlaser";
   heading = "bWeapons";
	shadowDetailMask = 4;
	imageType = ScopeImage;
	price = 0;
	showWeaponBar = false;
	showInventory = false;
};

function Rifle::onMount(%player,%imageSlot)
{
	Player::mountItem(%player,scope,$ExtraSlot);	
	Player::mountItem(%player,RailGun2,$ExtraWeaponSlot);	
	Player::trigger(%player,$ExtraSlot,true);
}

function Rifle::onUnmount(%player,%imageSlot)
{
	Player::unmountItem(%player,$ExtraSlot);
	Player::unmountItem(%player,$ExtraWeaponSlot);
	Player::trigger(%player,$ExtraSlot,false);
}

ItemImageData RifleImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Shells;
	projectileType = RifleBullet;
	accuFire = true;
	reloadTime = 0.6;
	fireTime = 0.2;
      lightType = 3;
      lightRadius = 6;
      lightTime = 2;
      lightColor = { 1.0, 0, 0 };
      sfxFire = SoundMissileTurretFire;
      sfxActivate = SoundPickUpWeapon;
      sfxSpinUp = SoundSpinUp;
      sfxSpinDown = SoundSpinDown;

};

ItemData Rifle
{
	description = "60MM RailGun";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = RifleImage;
	price = 600;
	showWeaponBar = true;
};

$SellAmmo[Shells]			= 50;

$AmmoPackMax[Shells] = 50;
$AmmoPackItems[23] = Shells;

AddWeapon(rifle);

$InvList[Shells] = 1;
$RemoteInvList[Shells] = 1;

$InvList[Rifle] = 1;
$RemoteInvList[Rifle] = 1;

$ItemMax[larmor, Rifle] = 1;
$ItemMax[lfemale, Rifle] = 1;
$ItemMax[marmor, Rifle] = 1;
$ItemMax[mfemale, Rifle] = 1;
$ItemMax[harmor, Rifle] = 1;
$ItemMax[BlastechF, Rifle] = 1;
$ItemMax[BlastechM, Rifle] = 1;
$ItemMax[MagIonM, Rifle] = 1;
$ItemMax[MagIonF, Rifle] = 1;
$ItemMax[MECH, Rifle] = 1;

$ItemMax[larmor, Shells] = 30;
$ItemMax[lfemale, Shells] = 30;
$ItemMax[marmor, Shells] = 40;
$ItemMax[mfemale, Shells] = 40;
$ItemMax[harmor, Shells] = 40;
$ItemMax[BlastechF, Shells] = 40;
$ItemMax[BlastechM, Shells] = 40;
$ItemMax[MagIonM, Shells] = 40;
$ItemMax[MagIonF, Shells] = 40;
$ItemMax[MECH, Shells] = 40;

//--------------------------------------------------------------------------------------------------------
// Mass Driver 40MM Rifle
//--------------------------------------------------------------------------------------------------------

ItemData Bolts
{
	description = "Mass Driver Bolts";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "ammo1";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData MassDriverImage
{
	shapeFile = "sniper";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = Bolts;
	projectileType = RifleBullet;
	accuFire = true;
	reloadTime = 0.5;
	fireTime = 0.2;
      lightType = 3;
      lightRadius = 6;
      lightTime = 2;
      lightColor = { 1.0, 0, 0 };
      sfxFire = SoundMissileTurretFire;
      sfxActivate = SoundPickUpWeapon;
      sfxSpinUp = SoundSpinUp;
      sfxSpinDown = SoundSpinDown;

	
};

ItemData MassDriver
{
	description = "40MM Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "blaster";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = MassDriverImage;
	price = 1200;
	showWeaponBar = true;
};

$SellAmmo[Bolts]			= 40;
$AmmoPackMax[Bolts] = 7;
$AmmoPackItems[25] = Bolts;

$InvList[MassDriver] = 1;
$RemoteInvList[MassDriver] = 1;

AddWeapon(massdriver);

$InvList[Bolts] = 1;
$RemoteInvList[Bolts] = 1;

$ItemMax[larmor, MassDriver] = 1;
$ItemMax[lfemale, MassDriver] = 1;
$ItemMax[marmor, MassDriver] = 1;
$ItemMax[mfemale, MassDriver] = 1;
$ItemMax[harmor, MassDriver] = 0;
$ItemMax[BlastechF, MassDriver] = 1;
$ItemMax[BlastechM, MassDriver] = 1;
$ItemMax[MagIonM, MassDriver] = 1;
$ItemMax[MagIonF, MassDriver] = 1;
$ItemMax[MECH, MassDriver] = 0;

$ItemMax[larmor, Bolts] = 30;
$ItemMax[lfemale, Bolts] = 30;
$ItemMax[marmor, Bolts] = 40;
$ItemMax[mfemale, Bolts] = 40;
$ItemMax[harmor, Bolts] = 0;
$ItemMax[BlastechF, Bolts] = 40;
$ItemMax[BlastechM, Bolts] = 40;
$ItemMax[MagIonM, Bolts] = 40;
$ItemMax[MagIonF, Bolts] = 40;
$ItemMax[MECH, Bolts] = 0;

//--------------------------------------------------------------------------------------------------------
// 20mm Sniper Rifle
//--------------------------------------------------------------------------------------------------------

ItemData SniperAmmo 
{
  description = "Sniper Bullet";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData SniperRifleImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0;
  ammoType = SniperAmmo;
  projectileType = SniperRound;
  accuFire = true;
  reloadTime = 0.4;
  fireTime = 0.2;
  lightType = 3;
  lightRadius = 6;
  lightTime = 2;
  lightColor = { 1.0, 0, 0 };
  sfxFire = SoundMissileTurretFire;
  sfxActivate = SoundPickUpWeapon;
  sfxSpinUp = SoundSpinUp;
  sfxSpinDown = SoundSpinDown;

};

ItemData SniperRifle 
{
  description = "20MM SkySnip Rifle";
  className = "Weapon";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = "gRifles";

  shadowDetailMask = 4;
  imageType = SniperRifleImage;
  price = 975;
  showWeaponBar = true;
};

$SellAmmo[SniperAmmo]			= 40;
$AmmoPackMax[SniperAmmo]		= 10;

$InvList[SniperRifle] = 1;
$RemoteInvList[SniperRifle] = 1;

AddWeapon(SniperRifle);

$InvList[SniperAmmo] = 1;
$RemoteInvList[SniperAmmo] = 1;

$ItemMax[larmor, SniperRifle] = 1;
$ItemMax[lfemale, SniperRifle] = 1;
$ItemMax[marmor, SniperRifle] = 1;
$ItemMax[mfemale, SniperRifle] = 1;
$ItemMax[harmor, SniperRifle] = 0;
$ItemMax[BlastechF, SniperRifle] = 1;
$ItemMax[BlastechM, SniperRifle] = 1;
$ItemMax[MagIonM, SniperRifle] = 1;
$ItemMax[MagIonF, SniperRifle] = 1;
$ItemMax[MECH, SniperRifle] = 0;

$ItemMax[larmor, SniperAmmo] = 30;
$ItemMax[lfemale, SniperAmmo] = 30;
$ItemMax[marmor, SniperAmmo] = 40;
$ItemMax[mfemale, SniperAmmo] = 40;
$ItemMax[harmor, SniperAmmo] = 0;
$ItemMax[BlastechF, SniperAmmo] = 40;
$ItemMax[BlastechM, SniperAmmo] = 40;
$ItemMax[MagIonM, SniperAmmo] = 40;
$ItemMax[MagIonF, SniperAmmo] = 40;
$ItemMax[MECH, SniperAmmo] = 0;

//--------------------------------------------------------------------------------------------------------
// AAOD SniperX
//--------------------------------------------------------------------------------------------------------

ItemData SXAmmo
{
	description = "HP Shots";
	className = "Ammo";
   heading = "zAmmo";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	price = 1;
};

ItemImageData SXImage 
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountRotation = { 0,-1.57, 0 };

	weaponType = 0; 
      projectileType = sniperXBullet;
	ammoType = SXAmmo;
	accuFire = true;
	fireTime = 1.5;
	reloadTime = 0;
	sfxFire = SoundFireSniperX;
	sfxActivate = SoundPickUpWeapon;
};

ItemData AAODSniperX
{
	description = "HP Sniper Rifle";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "chain";
   heading = "gRifles";
	shadowDetailMask = 4;
	imageType = SXImage;
	price = 4500;
	showWeaponBar = true;
};

$InvList[AAODSniperX] = 1;
$RemoteInvList[AAODSniperX] = 1;
$InvList[SXAmmo] = 1;
$RemoteInvList[SXAmmo] = 1;

AddWeapon(aaodsniperx);

$ItemMax[larmor, AAODSniperX] = 1;
$ItemMax[lfemale, AAODSniperX] = 1;
$ItemMax[marmor, AAODSniperX] = 1;
$ItemMax[mfemale, AAODSniperX] = 1;
$ItemMax[harmor, AAODSniperX] = 1;
$ItemMax[BlastechF, AAODSniperX] = 1;
$ItemMax[BlastechM, AAODSniperX] = 1;
$ItemMax[MagIonM, AAODSniperX] = 1;
$ItemMax[MagIonF, AAODSniperX] = 1;
$ItemMax[MECH, AAODSniperX] = 1;

$ItemMax[larmor, SXAmmo] = 30;
$ItemMax[lfemale, SXAmmo] = 30;
$ItemMax[marmor, SXAmmo] = 40;
$ItemMax[mfemale, SXAmmo] = 40;
$ItemMax[harmor, SXAmmo] = 50;
$ItemMax[BlastechF, SXAmmo] = 40;
$ItemMax[BlastechM, SXAmmo] = 40;
$ItemMax[MagIonM, SXAmmo] = 40;
$ItemMax[MagIonF, SXAmmo] = 40;
$ItemMax[MECH, SXAmmo] = 50;

//--------------------------------------------------------------------------------------------------------
// ELF Gun
//--------------------------------------------------------------------------------------------------------

ItemImageData EnergyRifleImage
{
	shapeFile = "shotgun";
   mountPoint = 0;

   weaponType = 2;  // Sustained
        projectileType = lightningCharge;
   minEnergy = 3;
   maxEnergy = 11;  // Energy used/sec for sustained weapons
	reloadTime = 0.2;
                        
   lightType = 3;  // Weapon Fire
   lightRadius = 2;
   lightTime = 1;
   lightColor = { 0.25, 0.25, 0.85 };

   sfxActivate = SoundPickUpWeapon;
   sfxFire     = SoundELFIdle;
};

ItemData EnergyRifle
{
   description = "ELF Gun";
	shapeFile = "shotgun";
	hudIcon = "energyRifle";
   className = "Weapon";
   heading = "jTools";
   shadowDetailMask = 4;
   imageType = EnergyRifleImage;
	showWeaponBar = true;
   price = 500;
};

AddWeapon(EnergyRifle);

//--------------------------------------------------------------------------------------------------------
// Repair Gun
//--------------------------------------------------------------------------------------------------------

ItemImageData RepairGunImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2;  // Sustained
	projectileType = RepairBolt;
	minEnergy  = 3;
	maxEnergy = 10;  // Energy used/sec for sustained weapons

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxActivate = SoundPickUpWeapon;
	sfxFire = SoundRepairItem;
};

ItemData RepairGun
{
	description = "Repair Gun";
	shapeFile = "repairgun";
	className = "Weapon";
	shadowDetailMask = 4;
	imageType = RepairGunImage;
	showInventory = false;
	price = 125;
};

function RepairGun::onMount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,true);
}

function RepairGun::onUnmount(%player,%imageSlot)
{
	Player::trigger(%player,$BackpackSlot,false);
}

//--------------------------------------------------------------------------------------------------------
// Repair Gun
//--------------------------------------------------------------------------------------------------------

//=============================================================================================

ItemImageData ReassemblerImage
{
	shapeFile = "repairgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = reassemblerBolt;
	accuFire = true;
	minEnergy = 2;
	maxEnergy = 5;
	reloadTime = 0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundRepairItem;
	sfxActivate = SoundPickUpWeapon;
};

ItemData Reassembler
{
	description   = "Reassembler";
	className     = "Tool";
	shapeFile     = "repairgun";
	hudIcon       = "targetlaser";
   heading = "jTools"; 
	shadowDetailMask = 4;
	imageType     = ReassemblerImage;
	price         = 100;
	showWeaponBar = false;
};

$AutoUse[Reassembler]			= true;

AddWeapon(reassembler);

$InvList[Reassembler] = 1;
$RemoteInvList[Reassembler] = 1;

$ItemMax[larmor, Reassembler] = 1;
$ItemMax[lfemale, Reassembler] = 1;
$ItemMax[marmor, Reassembler] = 1;
$ItemMax[mfemale, Reassembler] = 1;
$ItemMax[harmor, Reassembler] = 0;
$ItemMax[BlastechF, Reassembler] = 1;
$ItemMax[BlastechM, Reassembler] = 1;
$ItemMax[MagIonM, Reassembler] = 1;
$ItemMax[MagIonF, Reassembler] = 1;
$ItemMax[MECH, Reassembler] = 0;

	

//--------------------------------------------------------------------------------------------------------
// Plasma Gun
//--------------------------------------------------------------------------------------------------------

ItemData PlasmaAmmo
{
	description = "Plasma Bolt";
   heading = "zAmmo";
	className = "Ammo";
	shapeFile = "plasammo";
	shadowDetailMask = 4;
	price = 2;
};

ItemImageData PlasmaGunImage
{
	shapeFile = "plasma";
	mountPoint = 0;

	weaponType = 0; // Single Shot
	ammoType = PlasmaAmmo;
	accuFire = true;
	reloadTime = 0.15;
	fireTime = 0.1;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 1, 1, 0.2 };

	sfxFire = SoundFirePlasma;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundDryFire;
};

function PlasmaGunImage::onFire(%player, %slot) 
{
	 %Ammo = Player::getItemCount(%player, $WeaponAmmo[PlasmaGun]);
	 if(%Ammo) 
	 {
			 %playerId = Player::getClient(%player);
			 %client = GameBase::getOwnerClient(%player);
			 %trans = GameBase::getMuzzleTransform(%player);
		     %vel = Item::getVelocity(%player);

			if (%playerId.plasma == 0)
			{
				Projectile::spawnProjectile("PlasmaBolt",%trans,%player,%vel);
			 	Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],1);
			}
			else if (%playerId.plasma == 1)	// hidden plans exposed!
			{
				schedule ("PlasmaConnonShock2Fire(\"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\", \"" @ %clientId @ "\", \"0\");",0.2);
				schedule ("PlasmaConnonShock2Fire(\"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\", \"" @ %clientId @ "\", \"1\");",0.63);
				schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
				schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
				schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.65);
				Player::decItemCount(%player,$WeaponAmmo[PlasmaGun],10);
			}
	}
}

ItemData PlasmaGun
{
	description = "Plasma Sword";
	className = "Weapon";
	shapeFile = "plasma";
	hudIcon = "plasma";
   heading = "iHeat Effect Weapons & Riot Tools";
	shadowDetailMask = 4;
	imageType = PlasmaGunImage;
	price = 175;
	showWeaponBar = true;
};

AddWeapon(PlasmaGun);

$WeaponAmmo[PlasmaCannon] = "Beacon";

AddWeapon(plasmacannon);

$InvList[PlasmaCannon] = 1;
$RemoteInvList[PlasmaCannon] = 1;

$ItemMax[harmor, PlasmaCannon] = 1;
$ItemMax[larmor, PlasmaCannon] = 0;
$ItemMax[marmor, PlasmaCannon] = 0;
$ItemMax[lfemale, PlasmaCannon] = 0;
$ItemMax[mfemale, PlasmaCannon] = 0;
$ItemMax[BlastechM, PlasmaCannon] = 0;
$ItemMax[BlastechF, PlasmaCannon] = 0;
$ItemMax[MagIonM, PlasmaCannon] = 0;
$ItemMax[MagIonF, PlasmaCannon] = 0;
$ItemMax[MECH, PlasmaCannon] = 1;

ItemImageData PlasmaCannonImage
{
	shapeFile = "mortargun";
	mass = 2;
	mountPoint = 0;
	mountRotation = { 0, 0, 0 };
	weaponType = 0;
	accuFire = true;
	reloadTime = 0.1;
	fireTime = 0.5;
	minEnergy = 10;
	maxEnergy = 70;
	lightType = 3;
	lightRadius = 2;
	lightTime = 1;
	lightColor = { 1, 0, 0 };
	sfxFire = SoundFireMortar;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
	sfxReady = SoundMortarIdle;
};

ItemData PlasmaCannon
{
	description = "Plasma Cannon";
	className = "Weapon";
	shapeFile = "mortargun";
	hudIcon = "sniper";
   	heading = "iHeat Effect Weapons & Riot Tools";
	shadowDetailMask = 4;
	imageType = PlasmaCannonImage;
	price = 12800;
	showWeaponBar = true;
	mass = 2.5;
};

function PlasmaCannonImage::onFire(%player, %slot) 
{
	%clientId = player::getclient(%player);
	
	if (%clientId.plasmacharge)
	{
		%clientId.charging = "";
		%lc = %clientId.plasmacharge;
		
		%armor = Player::getArmor(%player); %client = GameBase::getOwnerClient(%player); %trans = GameBase::getMuzzleTransform(%player); %vel = Item::getVelocity(%player); %pos = (gamebase::getposition(%player));	 %rot = (gamebase::getrotation(%player)); %dir = (Vector::getfromrot(%rot));

		if (%lc > 0)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
		}
		if (%lc > 3)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.39);		
		}
		if (%lc > 5)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.425);
		}
		if (%lc > 7)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.475);
		}
		if (%lc > 9)
		{
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.35);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.5);		
		}
		
		if (%lc == 15)
		{
			schedule ("PlasmaConnonShock2Fire(\"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\", \"" @ %clientId @ "\", \"0\");",0.2);
			schedule ("PlasmaConnonShock2Fire(\"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\", \"" @ %clientId @ "\", \"1\");",0.63);
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.1);
			schedule ("Projectile::spawnProjectile(PlasmaCannonBolt2, \"" @ %trans@ "\",\"" @ %player @ "\",\"" @ %vel @ "\");",0.15);
			schedule ("Projectile::spawnProjectile(PlasmaCannonShock, \"" @ %trans @ "\", \"" @ %player @ "\", \"" @ %vel @ "\");",0.65);
		}
			%fired.deployer = %client;

		%clientId.plasmacharge = "0";
		return;
	}
	else
	{
		Client::sendMessage(%clientId,1,"** Plasma Cannon uses beacons to charge... ~waccess_denied.wav");
		return;
	}
}

function PlasmaCannoner::Charge(%clientId, %time)
{
	%player = client::getownedobject(%clientId);

	Player::mountItem(%clientId, PlasmaCannon, $WeaponSlot);

	if (!%clientId.charging)
		return;
	

	if (%time > 0)
	{
		%time--;
		schedule("PlasmaCannoner::Charge(" @ %clientId @", " @ %time @ ");",1.0);
                BottomPrint (%clientId, "** " @ %time @ " before full charge ", 1);
		%clientId.plasmacharge++;
		return;
	}
	else
	{
		BottomPrint (%clientId, "** Full charge attained... Ready!\n<f1>** Warning ** Due to the extreme stress of all that energy, the Plasma Cannon may overload... ETA: 30 seconds"  , 5);
		%clientId.plasmacharge = 15;
		PlasmaCannoner::Detonate(%clientId, 30);
		return;
	}
}

function PlasmaCannoner::Detonate(%clientId, %time)
{
	%player = client::getownedobject(%clientId);
	Player::mountItem(%clientId, PlasmaCannon, $WeaponSlot);
	
	if (%clientId.plasmacharge != 15)
		return;

	if (%time > 0)
	{
		%time--;
		schedule("PlasmaCannoner::Detonate(" @ %clientId @", " @ %time @ ");",1.0);
	}
	else
	{
		%clientId.charging = "";
		%clientId.plasmacharge = "0";
		Player::blowUp(%clientId);
			%obj = newObject("","Mine","HavocBlast");
			GameBase::throw(%obj,%clientId,0,false);		
			addToSet("MissionCleanup", %obj);
			%padd = "0 0 1.5";
			%pos = Vector::add(GameBase::getPosition(%clientId), %padd);
			GameBase::setPosition(%obj, %pos);
  		GameBase::applyDamage(%player, $DebrisDamageType, 5, "0 0 0", "0 0 0", "0 0 0", %clientId);
		return;
	}
	if (%time > 0 && %time < 25)
	{
		bottomprint (%clientId, "<jc>** ETA to overload: " @ %time @ " seconds", 1);
	}
}

RocketData PlasmaCannonBolt
{ 
	bulletShapeName = "plasmaex.dts"; 
	explosionTag = plasmaExp; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 1;
    	damageValue = 0.8; 
	damageType = $PlasmaDamageType;
	explosionRadius = 15; 
	kickBackStrength = 0.0; 
	muzzleVelocity   = 35.0;
	terminalVelocity = 55.0;
	acceleration     = 45.0;
	totalTime = 5.0; 
	liveTime = 5.0; 
	lightRange = 5.0; 
	lightColor = { 1.0, 0.0, 0.05 }; 
	inheritedVelocityScale = 0.0; 
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonBolt2

{ 
	bulletShapeName = "plasmabolt.dts"; 
	explosionTag = plasmaExp; 
	collisionRadius = 0.0;
	mass = 0.0; 
	damageClass = 1;
    	damageValue = 0.5; 
	damageType = $PlasmaDamageType;
	explosionRadius = 10; 
	kickBackStrength = 0.0; 
	muzzleVelocity = 35.0; 
	terminalVelocity = 45.0;
	acceleration = 35; 
	totalTime = 5.0; 
	liveTime = 5.0; 
	lightRange = 5.0; 
	lightColor = { 2.0, 0.0, 0.0 }; 
	inheritedVelocityScale = 0.0; 
	trailType   = 2;
	trailString = "plasmatrail.dts";
	smokeDist   = 180.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonShock
{
	bulletShapeName  = "plasmabolt.dts";
	explosionTag     = grenadeExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 1.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 15.0;
	kickBackStrength = 0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 55.0;
	acceleration     = 25.0;
	totalTime        = 5.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmabolt.dts";
	smokeDist   = 140.0;
	soundId = SoundJetHeavy;
};

RocketData PlasmaCannonShock2
{
	bulletShapeName  = "plasmaex.dts";
	explosionTag     = grenadeExp;
	collisionRadius  = 0.0;
	mass             = 0.0;
	damageClass      = 1;
	damageValue      = 1.0;
	damageType       = $PlasmaDamageType;
	explosionRadius  = 15.0;
	kickBackStrength = 0;
	muzzleVelocity   = 35.0;
	terminalVelocity = 65.0;
	acceleration     = 25.0;
	totalTime        = 5.0;
	liveTime         = 5.0;
	lightRange       = 5.0;
	lightColor       = { 1.0, 0.0, 0.0 };
	inheritedVelocityScale = 0.0;

	trailType   = 2;
	trailString = "plasmatrail.dts";
	smokeDist   = 160.0;
	soundId = SoundJetHeavy;
};


function PlasmaConnonShock2Fire(%trans, %player, %vel, %client, %num)
{
	%fired = (Projectile::spawnProjectile(PlasmaCannonShock2, %trans,%player,%vel));
	%fired.deployer = %client;
	
	if (%num == 0)
	{
		$Plasma[0] = %fired;
	}

	if (%num == 1)
	{
		%boom = $Plasma[0];
		$Plasma[%boom] = %fired;
	}
	
}

function PlasmaCannonShock2::OnRemove(%this)
{
	%boom = $Plasma[%this];
	
	if (%boom)
	{
		DeployFrags(%boom, 10, %boom.deployer);
		DeployFrags(%boom, 10, %boom.deployer);	
	}
}

function PlasmaCannonShock2::Blast(%this)
{
	DeployFrags(%this, 10, %this.deployer);
}

//==================================================================================================== Napalm Frags

MineData Frag1
{
   	mass = 5.0;
   	drag = 0.5;
   	density = 2.0;
	elasticity = 0.15;
	friction = 0.5;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = boltexp3;
	explosionRadius = 10.0;
	damageValue = 0.4;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Frag1::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Frag2
{
   	mass = 5.0;
   	drag = 0.5;
   	density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = boltexp3;
	explosionRadius = 10.0;
	damageValue = 0.4;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Frag2::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Frag3
{
   	mass = 5.0;
   	drag = 0.1;
   	density = 2.0;
	elasticity = 0.25;
	friction = 1.5;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "plasmabolt";
	shadowDetailMask = 4;
	explosionId = boltexp3;
	explosionRadius = 10.0;
	damageValue = 0.4;
	damageType = $PlasmaDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;

maxDamage = 1.5;
};

function Frag3::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

function DeployFrags(%this, %count, %player) 
{
        %cl = Player::getClient(%player);
	%pos = gamebase::getposition(%this);
	%team = GameBase::getTeam(%player);

	for (%i = 0; %i < %count; %i++)
	{
		%frag = "Frag" @ (floor(getRandom()*3)+1);
		%obj = newObject("","Mine", %frag);
		%obj.deployer = %cl;

		if ((floor(getRandom()*4)+1) > 2)
		{
			%dir = 120;			
			GameBase::throw(%obj,%cl,%dir,true);
		}
		else
		{
			%dir = 60;
			GameBase::throw(%obj,%cl,%dir,true);
		}

		addToSet("MissionCleanup", %obj);
		
		GameBase::setPosition(%obj, %pos);
	}

}
//--------------------------------------------------------------------------------------------------------
// Blade's Wrath
//--------------------------------------------------------------------------------------------------------

ItemData WrathAmmo 
{
  description = "BANG";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData BladeImage 
{
  shapeFile = "mortargun";
  mountPoint = 0;
  weaponType = 0; // Single Shot
  ammoType = WrathAmmo;
  projectileType = Wrath;
  accuFire = true;
  reloadTime = 7;
  fireTime = 2;
  lightType = 3;
  lightRadius = 5;
  lightTime = 5;
  lightColor = { 1.0, 3.0, 7.0 };
  sfxFire = SoundMissileTurretFire;
  sfxActivate = SoundPickUpWeapon;
  sfxSpinUp = SoundSpinUp;
  sfxSpinDown = SoundSpinDown;
};

ItemData Blade 
{
  description = "Q's Wrath";
  className = "Weapon";
  shapeFile = "Grenade";
  hudIcon = "targetlaser";
  heading = "eLaunchers";
  shadowDetailMask = 4;
  imageType = BladeImage;
  price = 1988;
  showWeaponBar = true;
};
    
$SellAmmo[WrathAmmo]			= 2;
$AmmoPackMax[WrathAmmo]		= 0;

AddWeapon(Blade);

$InvList[WrathAmmo] = 1;
$RemoteInvList[NukeAmmo] = 1;

$InvList[Blade] = 1;
$RemoteInvList[Blade] = 1;

$ItemMax[larmor, Blade] = 0;
$ItemMax[lfemale, Blade] = 0;
$ItemMax[marmor, Blade] = 0;
$ItemMax[mfemale, Blade] = 0;
$ItemMax[harmor, Blade] = 1;
$ItemMax[BlastechF, Blade] = 0;
$ItemMax[BlastechM, Blade] = 0;
$ItemMax[MagIonM, Blade] = 1;
$ItemMax[MagIonF, Blade] = 1;
$ItemMax[MECH, Blade] = 1;

$ItemMax[larmor, WrathAmmo] = 0;
$ItemMax[lfemale, WrathAmmo] = 0;
$ItemMax[marmor, WrathAmmo] = 0;
$ItemMax[mfemale, WrathAmmo] = 0;
$ItemMax[harmor, WrathAmmo] = 5;
$ItemMax[BlastechF, WrathAmmo] = 0;
$ItemMax[BlastechM, WrathAmmo] = 0;
$ItemMax[MagIonM, WrathAmmo] = 7;
$ItemMax[MagIonF, WrathAmmo] = 7;
$ItemMax[MECH, WrathAmmo] = 10;
	


//--------------------------------------------------------------------------------------------------------
// EctoPlasm
//--------------------------------------------------------------------------------------------------------

ItemData EAmmo 
{
  description = "Star Destroyers";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData EctoPlasmImage
{
	shapeFile = "shotgunbolt";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0 };

	weaponType = 0; // Single Shot
	minEnergy = 15; 
	maxEnergy = 15; 
	reloadTime = 0.1;
	fireTime = 0.1;
	ammoType = EAmmo;
	ProjectileType = EctoGoop;
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 6.8;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData EctoPlasm
{
	description = "Star Destoyer";
	className = "Weapon";
	shapeFile = "grenadeL";
	hudIcon = "Sniper";
   heading = "bEnergy Weapons";
	shadowDetailMask = 4;
	imageType = EctoPlasmImage;
	price = 19830;
	showWeaponBar = true;
};



function EctoPlasm::onMount(%player,%item,$WeaponSlot)
{
	%client = Player::getclient(%player);
	Player::mountItem(%player,EctoPlasmChargerA,$ExtraWeaponSlotA);
	Player::mountItem(%player,EctoPlasmChargerB,$ExtraWeaponSlotB);
	Player::mountItem(%player,EctoPlasmChargerC,$ExtraWeaponSlotC);
}

function EctoPlasm::onUnmount(%player,%item,$WeaponSlot)
{
	Player::unmountItem(%player,$ExtraWeaponSlotA);
	Player::unmountItem(%player,$ExtraWeaponSlotB);
	Player::unmountItem(%player,$ExtraWeaponSlotC);
}

ItemImageData EctoPlasmChargerAI
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0, 0, 0.25 };

	weaponType = 2; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = EctoGoop; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData EctoPlasmChargerA
{
	description = "EctoPlasm Charger A";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = EctoPlasmChargerAI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

ItemImageData EctoPlasmChargerBI
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { 0.15, 0, 0 };

	weaponType = 2; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = EctoGoop; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData EctoPlasmChargerB
{
	description = "EctoPlasm Charger B";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = EctoPlasmChargerBI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};


ItemImageData EctoPlasmChargerCI
{
	shapeFile = "sniper";
	mountPoint = 0;
	mountOffset = { -0.15, 0, 0 };

	weaponType = 2; // Single Shot
	minEnergy = 19; 
	maxEnergy = 20; 

	projectileType = EctoGoop; 
	accuFire = true; 

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };
};

ItemData EctoPlasmChargerC
{
	description = "Star Destroyer";
	className = "Weapon";
	shapeFile = "sniper";
	hudIcon = "grenade";
   heading = "cSpecialWeapons";
	shadowDetailMask = 4;
	imageType = EctoPlasmChargerCI;
	price = 0;
	showWeaponBar = true;
	showInventory = false;
};

function EctoPlasmChargerAI::onFire(%player,%slot)
{
	
	%client = GameBase::getOwnerClient(%player);
	%weapon = Player::getMountedItem(%player,$WeaponSlot);
	%playerId = Player::getClient(%player);
	if (GameBase::getLOSInfo(%player,900)) 
	{
	echo("Firing Meteor Shower");
	%dest = $los::position;
	DeathFromAbove2(%dest);
	}
	else
	{
	client::sendmessage(%playerId, 3,"Target Too Far for Meteor Shower");
	}
		
}


$InvList[EctoPlasm] = 1;
$RemoteInvList[EctoPlasm] = 1;

$ItemMax[larmor, EctoPlasm] = 0;
$ItemMax[lfemale, EctoPlasm] = 0;
$ItemMax[marmor, EctoPlasm] = 0;
$ItemMax[mfemale, EctoPlasm] = 0;
$ItemMax[harmor, EctoPlasm] = 1;
$ItemMax[BlastechM, EctoPlasm] = 0;
$ItemMax[BlastechF, EctoPlasm] = 0;
$ItemMax[MagIonM, EctoPlasm] = 0;
$ItemMax[MagIonF, EctoPlasm] = 0;
$ItemMax[MECH, EctoPlasm] = 1;

$ItemMax[larmor, EAmmo] = 0;
$ItemMax[lfemale, EAmmo] = 0;
$ItemMax[marmor, EAmmo] = 0;
$ItemMax[mfemale, EAmmo] = 0;
$ItemMax[harmor, EAmmo] = 1;
$ItemMax[BlastechF, EAmmo] = 0;
$ItemMax[BlastechM, EAmmo] = 0;
$ItemMax[MagIonM, EAmmo] = 1;
$ItemMax[MagIonF, EAmmo] = 1;
$ItemMax[MECH, EAmmo] = 1;
AddWeapon(EctoPlasm);

//--------------------------------------------------------------------------------------------------------
// BoomStick
//--------------------------------------------------------------------------------------------------------
AddWeapon(BoomStick);

ItemImageData BoomStickImage
{
	shapeFile = "Shotgun";
	mountPoint = 0;
	mountOffset = { 0, -0.1, 0 };

	weaponType = 0; // Single Shot
	ammoType = BoomStickAmm;
	accuFire = false;
	reloadTime = 2.5;
	fireTime = 1.5;

	lightType = 3;  // Weapon Fire
	lightRadius = 3;
	lightTime = 1;
	lightColor = { 0.6, 1, 1.0 };

	sfxFire = SoundFireSeeking;
	sfxActivate = SoundPickUpWeapon;
	sfxReload = SoundMortarReload;
};

ItemData BoomStickAmm
{
	description = "12-guage shells";
	className = "Ammo";
	shapeFile = "grenade";

  	heading = "zAmmo";
	shadowDetailMask = 4;
	price = 4;
};




ItemData BoomStick
{
	description = "Ash's BoomStick";
	className = "Weapon";
	shapeFile = "Shotgun";
	hudIcon = "disc";
   heading = "eLaunchers";
	shadowDetailMask = 4;
	imageType = BoomStickImage;
	price = 1992;
	showWeaponBar = true;
};

function BoomStickImage::onFire(%player,%slot)
{
#	%rawCharge = Player::getItemCount(%player,BoomStickAmm);\
#	%charge = %rawCharge *= 0.2;
#	if(%charge > 0)
#	{
#		for(%i=1; %i<%charge; %i++)
#		{
			%trans = GameBase::getMuzzleTransform(%player);
			%vel = Item::getVelocity(%player);
			Projectile::spawnProjectile("Bshell",%trans,%player,%vel);Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);
Projectile::spawnProjectile("Bshell",%trans,%player,%vel);#		}
#		Player::setItemCount(%player,Bshell,0);
#		if($BshellRecharging[%player] != True)
#		{
#			$BshellRecharging[%player] = True;
#			%guntype = BoomStick;
#			schedule("RechargeAmmo(" @ %player @ ", " @ %guntype @ ");",0.075,%player);
#		}
#	}
#		else Client::sendMessage(Player::getClient(%player),0,"BoomStick is out of Shells.");
}

function RechargeAmmo(%player,%gunType)
{
	%armor = Player::GetArmor(%player);
	if(%gunType == BoomStick && (Player::getItemCount(%player,DiskSpreader) > 0))
	{
		if(Player::getItemCount(%player,BoomStickAmm) < $ItemMax[%armor,BoomStickAmm])
		{

		Player::incItemCount(%player,BoomStickAmm,1);
			schedule("RechargeAmmo(" @ %player @ ", " @ %gunType @ ");",0.1,%player);
		}
		else
			$BoomStickRecharging[%player] = False;
	}
}

function THResuply(%player)
{
	Station::itemsToResupply(%player);
	schedule("THResuply(" @ %player @ ");",0.5,%this);
}

$SellAmmo[BoomStickAmm] = 15;
$AmmoPackMax[BoomStickAmm] = 15;
$AmmoPackItems[26] = BoomStickAmm;
$WeaponAmmo[DiskSpreader] = DiskSpreaderAmm;

$InvList[BoomStick] = 1;
$RemoteInvList[BoomStick] = 1;
$InvList[BoomStickAmm] = 1;
$RemoteInvList[BoomStickAmm] = 1;



$ItemMax[larmor, BoomStick] = 1;
$ItemMax[lfemale, BoomStick] = 1;
$ItemMax[marmor, BoomStick] = 1;
$ItemMax[mfemale, BoomStick] = 1;
$ItemMax[harmor, BoomStick] = 1;
$ItemMax[BlastechF, BoomStick] = 1;
$ItemMax[BlastechM, BoomStick] = 1;
$ItemMax[MagIonM, BoomStick] = 1;
$ItemMax[MagIonF, BoomStick] = 1;
$ItemMax[MECH, BoomStick] = 1;

$ItemMax[larmor, BoomStickAmm] = 30;
$ItemMax[lfemale, BoomStickAmm] = 30;
$ItemMax[marmor, BoomStickAmm] = 30;
$ItemMax[mfemale, BoomStickAmm] = 30;
$ItemMax[harmor, BoomStickAmm] = 30;
$ItemMax[BlastechF, BoomStickAmm] = 30;
$ItemMax[BlastechM, BoomStickAmm] = 30;
$ItemMax[MagIonM, BoomStickAmm] = 30;
$ItemMax[MagIonF, BoomStickAmm] = 30;
$ItemMax[MECH, BoomStickAmm] = 30;


//=============================
//        Jail Gun
//=============================


$ItemMax[larmor, JailGun] = 1;
$ItemMax[lfemale, JailGun] = 1;
$ItemMax[marmor, JailGun] = 1;
$ItemMax[mfemale, JailGun] = 1;
$ItemMax[harmor, JailGun] = 1;
$ItemMax[BlastechF, JailGun] = 1;
$ItemMax[BlastechM, JailGun] = 1;
$ItemMax[MagIonM, JailGun] = 1;
$ItemMax[MagIonF, JailGun] = 1;
$ItemMax[MECH, JailGun] = 1;

$InvList[JailGun] = 1;
$RemoteInvList[JailGun] = 1;

AddWeapon(JailGun);

$AutoUse[JailGun] = True;

LightningData jailbolt
{
  bitmapName       = "lightningNew.bmp";

   damageType       = $ElectricityDamageType;
   boltLength       = 25.0;
   coneAngle        = 30.0;
   damagePerSec      = 0.3;
   energyDrainPerSec = 5.0;
   segmentDivisions = 1;
   numSegments      = 5;
   beamWidth        = 0.125;

   updateTime   = 120;
   skipPercent  = 0.5;
   displaceBias = 0.15;

   lightRange = 3.0;
   lightColor = { 0.25, 0.25, 0.85 };

   soundId = SoundELFFire;
};

function jailbolt::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
%aclient = Player::getClient(%target);
if(getObjectType(%target) != "Player")
      {
       return;
      }


if(GameBase::getTeam(%target) == GameBase::getTeam(%shooterId))
        {
        return;
        }


    %teleset = nameToID("MissionCleanup/jailports");
    %playerTeam = GameBase::getTeam(%target);

    for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
    {
    %oteam=GameBase::getTeam(%o);
                  if(%oteam != %playerTeam)
                    {

                        %sclient = Player::getClient(%shooterId);
                        %sname = Client::getName(%sclient);
                        %client = Player::getClient(%target);
                        %vname = Client::getName(%client);
                        GameBase::SetPosition(%target,GameBase::GetPosition(%o));
				Messageall(1, %vname @ " has been placed in jail by " @ %sname @ ".");
                        centerprint(%client,"<jc><f0>You Have Been Placed Under Arrest By " @ %sname);
                        Client::SendMessage(%client,0,"Your jail sentence will last 15 seconds.");
                        echo("ADMINMSG: **** " @ %sname @ " zapped " @ %vname @ " Into Jail");
                        schedule("jLargeForceField::jailSesame("@%target@");",15);
                    }
                    }

}




ItemImageData JailGunImage
{
          shapeFile = "shotgun";
           mountPoint = 0;
           weaponType = 2;
           projectileType = jailbolt;
           minEnergy = 5;
           maxEnergy = 80;
           reloadTime = 1.0;

          lightType = 3;
          lightRadius = 2;
          lightTime = 1;
          lightColor = { 0.25, 0.25, 0.85 };

          sfxActivate = SoundPickUpWeapon;
          sfxFire     = SoundELFIdle;
};
ItemData JailGun
{
   heading = "bWeapons";
        description = "Jail Gun";
        className = "Weapon";
        shapeFile  = "repairgun";
        hadowDetailMask = 4;
        imageType = JailGunImage;
        price = 385;
        showWeaponBar = true;
};

function JailGun::onMount(%player,%item) 
{
  %client = Player::getClient(%player);
  Bottomprint(%client, "<jc><f2>Jail Gun:- <f0>Sends the victim to jail for 15 secs");
}

//--------------------------------------------------------------------------------------------------------
// Repair Sniper
//--------------------------------------------------------------------------------------------------------

ItemData RepairAmmo 
{
  description = "Repair Bolts";
  className = "Ammo";
  heading = "xAmmunition";
  shapeFile = "ammo1";
  shadowDetailMask = 4;
  price = 5;
};

ItemImageData RSniperImage 
{
  shapeFile = "sniper";
  mountPoint = 0;
  weaponType = 0; 
  mountRotation = { 0,110.0, 0 };
  ammoType = RepairAmmo;
  projectileType = RepairDiscShell;
  isvisible = true;
  accuFire = true;
  reloadTime = 0.3;
  fireTime = 0.05;
  lightType = 3;
  lightRadius = 5;
  lightTime = 5;
  lightColor = { 1.0, 3.0, 7.0 };
  sfxFire = SoundRepairItem;
  sfxActivate = SoundPickUpWeapon;
  sfxSpinUp = SoundSpinUp;
  sfxSpinDown = SoundSpinDown;
};

ItemData RSniper 
{
  description = "Repair Sniper";
  className = "Tool";
  shapeFile = "sniper";
  hudIcon = "targetlaser";
  heading = "jTools";
  shadowDetail = 4;
  ImageType = RSniperImage;
  price = 8752;
  showWeaponBar = true;
};
    
$SellAmmo[RepairAmmo]			= 20;
$AmmoPackMax[RepairAmmo]		= 0;

AddWeapon(RSniper);

$InvList[RepairAmmo] = 1;
$RemoteInvList[RepairAmmo] = 1;

$InvList[RSniper] = 1;
$RemoteInvList[RSniper] = 1;

$ItemMax[larmor, RSniper] = 1;
$ItemMax[lfemale, RSniper] = 1;
$ItemMax[marmor, RSniper] = 1;
$ItemMax[mfemale, RSniper] = 1;
$ItemMax[harmor, RSniper] = 1;
$ItemMax[BlastechF, RSniper] = 1;
$ItemMax[BlastechM, RSniper] = 1;
$ItemMax[MagIonM, RSniper] = 1;
$ItemMax[MagIonF, RSniper] = 1;
$ItemMax[MECH, RSniper] = 1;

$ItemMax[larmor, RepairAmmo] = 10;
$ItemMax[lfemale, RepairAmmo] = 10;
$ItemMax[marmor, RepairAmmo] = 10;
$ItemMax[mfemale, RepairAmmo] = 10;
$ItemMax[harmor, RepairAmmo] = 5;
$ItemMax[BlastechF, RepairAmmo] = 10;
$ItemMax[BlastechM, RepairAmmo] = 10;
$ItemMax[MagIonM, RepairAmmo] = 10;
$ItemMax[MagIonF, RepairAmmo] = 10;
$ItemMax[MECH, RepairAmmo] = 5;


//--------------------------------------------------------------------------------------------------------
// Targeting Laser
//--------------------------------------------------------------------------------------------------------

ItemImageData TargetingLaserImage
{
	shapeFile = "paintgun";
	mountPoint = 0;

	weaponType = 2; // Sustained
	projectileType = targetLaser;
	accuFire = true;
	minEnergy = 5;
	maxEnergy = 15;
	reloadTime = 1.0;

	lightType   = 3;  // Weapon Fire
	lightRadius = 1;
	lightTime   = 1;
	lightColor  = { 0.25, 1, 0.25 };

	sfxFire     = SoundFireTargetingLaser;
	sfxActivate = SoundPickUpWeapon;
};

ItemData TargetingLaser
{
	description   = "Targeting Laser";
	className     = "Tool";
	shapeFile     = "paintgun";
	hudIcon       = "targetlaser";
   heading = "jTools";
	shadowDetailMask = 4;
	imageType     = TargetingLaserImage;
	price         = 50;
	showWeaponBar = false;
};

function TargetingLaser::onUse(%player,%item)
{
	Weapon::onUse(%player,%item);
	bottomprint(Player::getClient(%player), "<jc>The Targeting Laser: <f1>An effective tool used mostly by bots.", 5);
}

$InvList[TargetingLaser]			= 1;
$RemoteInvList[TargetingLaser]		= 1;		

$ItemMax[larmor,TargetingLaser]	= 1;
$ItemMax[lfemale,TargetingLaser]	= 1;
$ItemMax[marmor,TargetingLaser]	= 1;
$ItemMax[mfemale,TargetingLaser]	= 1;
$ItemMax[harmor,TargetingLaser]	= 1;
$ItemMax[BlastechF, TargetingLaser] = 1;
$ItemMax[BlastechM, TargetingLaser] = 1;
$ItemMax[MagIonM, TargetingLaser] = 1;
$ItemMax[MagIonF, TargetingLaser] = 1;
$ItemMax[MECH, TargetingLaser] = 1;

