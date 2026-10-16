echo("Loading Screaming Fist Version");
//----------------------------------------------------------------------------
//
//----------------------------------------------------------------------------
//
//************************************************************************
// Changes have been made to the scout data block
// this is becuase of a few hitches with the model
// and its bounding box all other variables can be 
// changed appart from my changes although minor


// added note :-
// vehicle exploding when player exits has been fixed
// the player was colliding with a lower LOD model
// exit point has been placed to the back left of the 
// veicle if you want this changed let me know 

// (this MAY have fixed the problem with ground damage
// its not been tested yet!)

// the two muzzle's have been placed each side of the 
// models minigun for the missle version the muzzles
// will be places each side of the model by the missle 
// pods

// again should you want "driver position, muzzles & exit points
// changed (moved about) let me know
//************************************************************************

//*************************************************************************************************************
// SF Addition - Begin - 12/25/99 - 12:30AM
//*************************************************************************************************************

// comanche (with minigun)
FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "flyer";
	shieldShapeName = "shield_medium";
	mass = 20.0;
	drag = 2.0;
	density = 2.2;
	maxBank = 0.5;
	maxPitch = 0.5;
	maxSpeed = 60;
	minSpeed = -1;
	lift = 0.50;
	maxAlt = 75;
	maxVertical = 25;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.85;
	
	// Because of the abnormal size of the bounding box
	// having ground damage on can cause the model to explode 
	// at will for some unknown reason... best to experiment a bit
	
	groundDamageScale = 1.0;
	
	// this is the minigun model so best write up a new projectile for the minigun
	
	projectileType = ComancheBullet;
	
	reloadDelay = 0.1;
	repairRate = 0;
	fireSound = SoundFireComMachinegun;
	damageSound = SoundFlierCrash;
	
	// ram damage ( when you bump into a turret, sensor, or any other DTS object
	// this has caused a few problems with exiting the vehicle I belive its fixed 
	// now ... just dont jump into the rotor blades theres a good chapp =)
	
	ramDamage = 5.0;
	ramDamageType = 25;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundComancheIdle;
	moveSound = NoSound; //SoundComancheActive;
	
	// Best to turn off the visable driver we dont want arms and legs sticking 
	// out of out model do we =) (*note I may be able to pull it off with having 
	// a visable driver if you realy need it but best not to eah?)
	
	visibleDriver = False;
	driverPose = 22;
	description = "Comanche";
};

$DamageScale[Scout, $LandingDamageType] = 1.0;
$DamageScale[Scout, $ImpactDamageType] = 2.0;
$DamageScale[Scout, $CrushDamageType] = 1.0;
$DamageScale[Scout, $ExplosionDamageType] = 1.5;
$DamageScale[Scout, $DebrisDamageType] = 1.0;
$DamageScale[Scout, $ElectricityDamageType] = 1.0;
$DamageScale[Scout, $MineDamageType] = 1.5;
$DamageScale[Scout, $SniperRifleDamageType] = 0.35;
$DamageScale[Scout, $MinigunDamageType] = 0.2;
$DamageScale[Scout, $AssRifleDamageType] = 0.2;
$DamageScale[Scout, $FlamerDamageType] = 1.0;
$DamageScale[Scout, $GlockDamageType] = 0.2;
$DamageScale[Scout, $ShrapnelDamageType] = 1.5;
$DamageScale[Scout, $MissileDamageType] = 1.5;
$DamageScale[Scout, $FBWMissileDamageType] = 0.15;
$DamageScale[Scout, $MAWAssRifleDamageType] = 0.2;
$DamageScale[Scout, $MAWIncendiaryRifleDamageType] = 0.4;
$DamageScale[Scout, $SilencedAssRifleDamageType] = 0.15;
$DamageScale[Scout, $SilencedGlockDamageType] = 0.2;
$DamageScale[Scout, $ShotgunDamageType] = 0.25;
$DamageScale[Scout, $ComancheBulletDamageType] = 0.75;
$DamageScale[Scout, $ComancheImpactDamageType] = 3.0;
$DamageScale[Scout, $OspreyImpactDamageType] = 1.5;
$DamageScale[Scout, $BigCannonDamageType] = 2.8;
$DamageScale[Scout, $HowitzerDamageType] = 2.5;
$DamageScale[Scout, $OspreyTurretDamageType] = 1.0;
$DamageScale[Scout, $HomingFlareDamageType] = 0.0;

//------------------------------------------------------------------------

FlierData Osprey
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
	shapeFile = "Osprey";
	shieldShapeName = "shield_medium";
	mass = 100.0;
	drag = 2.0;
	density = 4.2;
	maxBank = 0.25;
	maxPitch = 0.25;
	maxSpeed = 60;
	minSpeed = -1;
	lift = 0.75;
	maxAlt = 75;
	maxVertical = 15;
	maxDamage = 5.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.4;
	
	// Because of the abnormal size of the bounding box
	// having ground damage on can cause the model to explode 
	// at will for some unknown reason... best to experiment a bit
	
	groundDamageScale = 1.0;
	
	// this is the minigun model so best write up a new projectile for the minigun
	
	repairRate = 0;
	fireSound = SoundFireFlierRocket;
	damageSound = SoundTankCrash;
	
	// ram damage ( when you bump into a turret, sensor, or any other DTS object
	// this has caused a few problems with exiting the vehicle I belive its fixed 
	// now ... just dont jump into the rotor blades theres a good chapp =)
	
	ramDamage = 0.0;
	ramDamageType = 26;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundOspreyIdle;
	moveSound = NoSound;
	
	// Best to turn off the visable driver we dont want arms and legs sticking 
	// out of out model do we =) (*note I may be able to pull it off with having 
	// a visable driver if you realy need it but best not to eah?)
	
	visibleDriver = False;
	driverPose = 23;
	description = "Osprey";
};

function Osprey::onAdd(%this)
{
	//echo("I'm called !");
	//schedule("AddTurret("@%this@", 6, 0.785);",0);
	//schedule("AddTurret("@%this@", 7, -0.785);",0);
}

function AddTurret(%this, %MPoint, %rot)
{
	%tmount = spawnPlayer(tmount, "0 0 0", "0 0 0");
	
	Player::setMountObject(%tmount, %this, %MPoint);
	Player::mountItem(%tmount, OspreyTurret, $WeaponSlot);
	Player::setItemCount(%tmount, OspreyTurretAmmo, 500);
	%rot = "0 0 "@ %rot;
	%origRot = GameBase::getRotation(%tmount);
	%origRot = Vector::add(%rot, %origRot);
	GameBase::setRotation(%tmount, %origRot);
	$VehiclePlayerId[%MPoint,%this] = %tmount;
}

function removeTurret(%this, %MPoint)
{
	%object = $VehiclePlayerId[%MPoint, %this];
	%test = GameBase::getDataName(%object);
	//echo("%test ", %test);
	
	if( %test == tmount )
	{
		%tmount = %object;
		%test = Player::setItemCount(%tmount, OspreyTurret, 0);
		//echo(%test);
		%test = Player::setItemCount(%tmount, OspreyTurretAmmo, 0);
		//echo(%test);
	}	
	else
	{
		%player = %object;
		//echo("%player - ",%player);
		%client = GameBase::getOwnerClient(%player);
		//echo("%client - ",%client);
		%tmount = Client::getControlObject(%client);
		//echo("%tmount - ",%tmount);
		%test = Player::setItemCount(%tmount, OspreyTurret, 0);
		//echo(%test);
		%test = Player::setItemCount(%tmount, OspreyTurretAmmo, 0);
		//echo(%test);
		%test = Client::setControlObject(%client, %player);
		//echo(%test);
	}
	deleteObject(%tmount);
}

$DamageScale[Osprey, $LandingDamageType] = 1.0;
$DamageScale[Osprey, $ImpactDamageType] = 2.0;
$DamageScale[Osprey, $CrushDamageType] = 1.0;
$DamageScale[Osprey, $ExplosionDamageType] = 2.5;
$DamageScale[Osprey, $DebrisDamageType] = 0.75;
$DamageScale[Osprey, $ElectricityDamageType] = 1.5;
$DamageScale[Osprey, $MineDamageType] = 2.5;
$DamageScale[Osprey, $SniperRifleDamageType] = 0.35;
$DamageScale[Osprey, $MinigunDamageType] = 0.25;
$DamageScale[Osprey, $AssRifleDamageType] = 0.3;
$DamageScale[Osprey, $FlamerDamageType] = 1.0;
$DamageScale[Osprey, $GlockDamageType] = 0.3;
$DamageScale[Osprey, $ShrapnelDamageType] = 1.5;
$DamageScale[Osprey, $MissileDamageType] = 2.5;
$DamageScale[Osprey, $FBWMissileDamageType] = 1.0;
$DamageScale[Osprey, $MAWAssRifleDamageType] = 0.3;
$DamageScale[Osprey, $MAWIncendiaryRifleDamageType] = 2.5;
$DamageScale[Osprey, $SilencedAssRifleDamageType] = 0.3;
$DamageScale[Osprey, $SilencedGlockDamageType] = 0.3;
$DamageScale[Osprey, $ShotgunDamageType] = 0.3;
$DamageScale[Osprey, $ComancheBulletDamageType] = 0.75;
$DamageScale[Osprey, $ComancheImpactDamageType] = 3.0;
$DamageScale[Osprey, $OspreyImpactDamageType] = 1.5;
$DamageScale[Osprey, $BigCannonDamageType] = 2.8;
$DamageScale[Osprey, $HowitzerDamageType] = 5.0;
$DamageScale[Osprey, $OspreyTurretDamageType] = 1.0;
$DamageScale[Osprey, $HomingFlareDamageType] = 0.0;

//-------------------------------------------------------------------------

FlierData FBWRocket
{
	explosionId = rocketExp;
	debrisId = NoDebris;
	className = "Vehicle";
	shapeFile = "rocket";
	shieldShapeName = "";
	mass = 1.0;
	drag = 1.0;
	density = 1.0;
	maxBank = 7.5;
	maxPitch = 7.5;
	maxSpeed = 60;
	minSpeed = 60;
	lift = 0.0;
	maxAlt = 2500;
	maxVertical = 1000;
	maxDamage = 0.001;
	damageLevel = {1.0, 1.0};
	maxEnergy = 15;
	accel = 25.0;
	
	groundDamageScale = 5.0;
	
	repairRate = 0;
	ramDamage = 0.005;
	ramDamageType = 21;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = NoSound;
	dismountSound = NoSound;
	idleSound = NoSound;
	moveSound = SoundJetHeavy;
	
	visibleDriver = false;
	driverPose = 23;
	description = "FBW Rocket";
};

function FBWRocket::onAdd(%this)
{
	schedule("checkOperator("@%this@");",5.0,%this);
	GameBase::setRechargeRate(%this, -1);
}


$DamageScale[FBWRocket, $LandingDamageType] = 1.0;
$DamageScale[FBWRocket, $ImpactDamageType] = 0.75;
$DamageScale[FBWRocket, $CrushDamageType] = 1.0;
$DamageScale[FBWRocket, $ExplosionDamageType] = 1.5;
$DamageScale[FBWRocket, $DebrisDamageType] = 1.0;
$DamageScale[FBWRocket, $ElectricityDamageType] = 1.0;
$DamageScale[FBWRocket, $MineDamageType] = 1.5;
$DamageScale[FBWRocket, $SniperRifleDamageType] = 0.35;
$DamageScale[FBWRocket, $MinigunDamageType] = 0.15;
$DamageScale[FBWRocket, $AssRifleDamageType] = 0.15;
$DamageScale[FBWRocket, $FlamerDamageType] = 1.0;
$DamageScale[FBWRocket, $GlockDamageType] = 0.15;
$DamageScale[FBWRocket, $ShrapnelDamageType] = 1.5;
$DamageScale[FBWRocket, $MissileDamageType] = 1.5;
$DamageScale[FBWRocket, $FBWMissileDamageType] = 0.15;
$DamageScale[FBWRocket, $MAWAssRifleDamageType] = 0.15;
$DamageScale[FBWRocket, $MAWIncendiaryRifleDamageType] = 0.4;
$DamageScale[FBWRocket, $SilencedAssRifleDamageType] = 0.15;
$DamageScale[FBWRocket, $SilencedGlockDamageType] = 0.15;
$DamageScale[FBWRocket, $ShotgunDamageType] = 0.15;
$DamageScale[FBWRocket, $ComancheBulletDamageType] = 0.15;
$DamageScale[FBWRocket, $ComancheImpactDamageType] = 2.0;
$DamageScale[FBWRocket, $OspreyImpactDamageType] = 1.5;
$DamageScale[FBWRocket, $BigCannonDamageType] = 2.2;
$DamageScale[FBWRocket, $HowitzerDamageType] = 10.0;
$DamageScale[FBWRocket, $HomingFlareDamageType] = 1.0;

//-------------------------------------------------------------------------

FlierData FlyingBug
{
	explosionId = debrisExpMedium;
	debrisId = defaultDebrisSmall;
	className = "Vehicle";
	shapeFile = "camera";
	shieldShapeName = "";
	mass = 100.0;
	drag = 2.0;
	density = 4.2;
	maxBank = 7.5;
	maxPitch = 7.5;
	maxSpeed = 20;
	minSpeed = -20;
	lift = 0.75;
	maxAlt = 75;
	maxVertical = 20;
	maxDamage = 0.05;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 1.0;
	
	groundDamageScale = 0.0;
	
	projectileType = NoProjectile;
	
	reloadDelay = 0.7;
	repairRate = 0;
	fireSound = NoSound;
	damageSound = SoundFlierCrash;
	
	ramDamage = 0.05;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;
	
	mountSound = NoSound;
	dismountSound = NoSound;
	idleSound = NoSound;
	moveSound = NoSound;
	
	visibleDriver = true;
	driverPose = 23;
	description = "Remote Fly-Camera";
};

function FlyingBug::onAdd(%this)
{
	$FlyReload[%this] = FALSE;
	schedule("checkOperator("@%this@");",5.0,%this);
}

function FlyingBug::onFire(%this, %slot)
{
	%item = "CameraPack";
	%client = GameBase::getControlClient(%this);
	
	if( $FlyReload[%this] == FALSE )
	{
		$FlyReload[%this] = TRUE;
		schedule("$FlyReload["@%this@"] = FALSE;",1.0,%this);

		if($TeamItemCount[GameBase::getTeam(%client) @ %item] < $TeamItemMax[%item])
		{
			if (GameBase::getLOSInfo(%this,3))
			{
				%obj = getObjectType($los::object);
				if (%obj == "SimTerrain" || %obj == "InteriorShape")
				{
					%prot = GameBase::getRotation(%this);
					%zRot = getWord(%prot,2);
					if (Vector::dot($los::normal,"0 0 1") > 0.6)
						%rot = "0 0 " @ %zRot;
					else
					{
						if (Vector::dot($los::normal,"0 0 -1") > 0.6)
							%rot = "3.14159 0 " @ %zRot;
						else
							%rot = Vector::getRotation($los::normal);
					}
					if(checkDeployArea(%client,$los::position))
					{
						
						%camera = newObject("Camera","Turret",CameraTurret,true);
						addToSet("MissionCleanup", %camera);
						
						GameBase::setTeam(%camera,GameBase::getTeam(%client));
						GameBase::setRotation(%camera,%rot);
						GameBase::setPosition(%camera,$los::position);
						Gamebase::setMapName(%camera,"Camera#"@ $totalNumCameras++ @ " " @ Client::getName(%client));
						Client::sendMessage(%client,0,"Camera deployed");
						playSound(SoundPickupBackpack,$los::position);
						$TeamItemCount[GameBase::getTeam(%camera) @ "CameraPack"]++;
						//echo("MSG: ",%client," deployed a Camera");
						
						//Exit and delete the Flier model
						%player = Client::getOwnedObject(%client);
						Client::setControlObject(%client, %player);
						
						schedule("deleteObject("@%this@");",0.05, %this);
						
						return true;
					}
				}
				else 
					Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
			}
			else
				Client::sendMessage(%client,0,"Deploy position out of range");		
		}
		else																						  
			Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	}
	
	return false;
}

$DamageScale[FlyingBug, $LandingDamageType] = 1.0;
$DamageScale[FlyingBug, $ImpactDamageType] = 1.0;
$DamageScale[FlyingBug, $CrushDamageType] = 1.0;
$DamageScale[FlyingBug, $ExplosionDamageType] = 1.0;
$DamageScale[FlyingBug, $DebrisDamageType] = 1.0;
$DamageScale[FlyingBug, $ElectricityDamageType] = 1.0;
$DamageScale[FlyingBug, $MineDamageType] = 1.0;
$DamageScale[FlyingBug, $SniperRifleDamageType] = 1.0;
$DamageScale[FlyingBug, $MinigunDamageType] = 1.0;
$DamageScale[FlyingBug, $AssRifleDamageType] = 1.0;
$DamageScale[FlyingBug, $FlamerDamageType] = 1.0;
$DamageScale[FlyingBug, $GlockDamageType] = 1.0;
$DamageScale[FlyingBug, $ShrapnelDamageType] = 1.0;
$DamageScale[FlyingBug, $MissileDamageType] = 1.0;
$DamageScale[FlyingBug, $FBWMissileDamageType] = 1.0;
$DamageScale[FlyingBug, $MAWAssRifleDamageType] = 1.0;
$DamageScale[FlyingBug, $MAWIncendiaryRifleDamageType] = 1.0;
$DamageScale[FlyingBug, $SilencedAssRifleDamageType] = 1.0;
$DamageScale[FlyingBug, $SilencedGlockDamageType] = 1.0;
$DamageScale[FlyingBug, $ShotgunDamageType] = 1.0;
$DamageScale[FlyingBug, $ComancheBulletDamageType] = 1.0;
$DamageScale[FlyingBug, $ComancheImpactDamageType] = 1.0;
$DamageScale[FlyingBug, $OspreyImpactDamageType] = 1.0;
$DamageScale[FlyingBug, $BigCannonDamageType] = 1.0;
$DamageScale[FlyingBug, $HowitzerDamageType] = 1.0;
$DamageScale[FlyingBug, $HomingFlareDamageType] = 1.0;

//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

//----------------------------------------------------------------------------

//*************************************************************************************************************
// SF Addition - Begin - 7/17/99 - 1:30AM
//*************************************************************************************************************
function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function checkOperator(%this)
{
	%client = GameBase::getControlClient(%this);
	if(%client != -1 )
		schedule("checkOperator("@%this@");",5.0,%this);
	else
		GameBase::setDamageLevel(%this, 1.0);
}
//*************************************************************************************************************
// SF Addition - End
//*************************************************************************************************************

function Vehicle::onCollision (%this, %object)
{
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage && GameBase::getDataName(%this) != FBWRocket && GameBase::getDataName(%this) != FlyingBug) {
		if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
		{
			//            if( Player::isAiControlled(%object) )
			//               return;
			//
			//            ^^Commented out so that AI can ride on the vehicles with the rest of the norms :)
			//               
			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);
			
			//*************************************************************************************************************
			// SF Addition - Begin - 5/7/99 - 11:30PM
			//*************************************************************************************************************
			
			if ((%armor == "somale" || %armor == "sofemale" || %armor == "imale" || %armor == "ifemale") && Vehicle::canMount (%this, %object))
				
				//*************************************************************************************************************
				// SF Additions - End
				//*************************************************************************************************************
				
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
			else if(GameBase::getDataName(%this) != Scout) 
			{
				%mountSlot= Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) 
				{
					//echo("MountSlot = ",%mountSlot);
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					
					if( GameBase::getDataName(%this) == Osprey )
					{
						if(%mountSlot != 4 && %mountSlot != 5)
						{
							Player::setMountObject(%object, %this, %mountSlot);
							playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						}
					}
					else
					{
						Player::setMountObject(%object, %this, %mountSlot);
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
					}
					//*************************************************************************************************************
					// SF Addition - Begin - 10/5/99 - 12:00AM - MOUNT CODE!!
					//*************************************************************************************************************
					//if( GameBase::getDataName(%this) == Osprey )
					//{
					//	if(%mountSlot == 2)
					//	{
					//		Player::unmountItem( %object, 0);
					//		%tmount = $VehiclePlayerId[6,%this];
					
					//Player Rotation stuff
					//		%origRot = GameBase::getRotation(%tmount);
					//		GameBase::setRotation(%object, %origRot);
					
					//		Client::setControlObject(%client, %tmount);
					//	}
					//	else if(%mountSlot == 3)
					//	{
					//		Player::unmountItem( %object, 0);
					//		%tmount = $VehiclePlayerId[7,%this];
					
					//Player Rotation stuff
					//		%origRot = GameBase::getRotation(%tmount);
					//		GameBase::setRotation(%object, %origRot);
					
					//		Client::setControlObject(%client, %tmount);
					//	}
					//}
					//*************************************************************************************************************
					// SF Addition - End
					//*************************************************************************************************************
				}
			}
			else if (GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),0,"You must be a Special Ops or Infantry Class to pilot the vehicles.~wError_Message.wav");
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	//*************************************************************************************************************
	// SF Addition - Begin - 6/19/99 - 10:30PM
	//*************************************************************************************************************
	if(GameBase::getDataName(%this) == FBWRocket || GameBase::getDataName(%this) == FlyingBug)
		%numSlots = 0;
	else
		if(GameBase::getDataName(%this) == Osprey)
			%numSlots = 6;
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
	//*************************************************************************************************************
	// SF Addition - Begin - 12/19/99 - 2:00AM
	//*************************************************************************************************************
	%armor = Player::getArmor(%passenger);
	//echo(%passenger);
	
	//if(%armor == "tmount") {
	
	// Puts player in control of player model
	//	%tmount = %passenger;
	//	echo("%tmount - ",%tmount);
	//	%client = GameBase::getControlClient(%tmount);
	//	echo("%client - ",%client);
	//	%player = Client::getOwnedObject(%client);
	//	echo("%player - ",%player);
	//	%test = Client::setControlObject(%client, %player);
	//	echo(%test);
	//	return;
	//}
	//else 
	
	if(%armor == "somale" || %armor == "sofemale") {
		%height = 1;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "cmmale" || %armor == "cmfemale") {
		%height = 1;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "imale" || %armor == "ifemale") {
		%height = 1;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "himale" || %armor == "hifemale") {
		%height = 1;
		%velocity = 100;
		%zVec = 100;
	}
	
	//*************************************************************************************************************
	// SF Additions - End
	//*************************************************************************************************************
	
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
		//*************************************************************************************************************
		// SF Addition - Begin - 6/19/99 - 3:30PM
		//*************************************************************************************************************
		%name = GameBase::getDataName(%this);
		if(%name == FBWRocket)
		{
			//echo("$FBWClientID[%this] - Vehicle Dismount ",$FBWClientID[%this]);
			Client::setControlObject(%cl, %pl);
			%test = GameBase::setDamageLevel(%this, 0.1);
			//echo(%test);
			//schedule("GameBase::setDamageLevel("@%this@","@%name.maxDamage@");", 5.0, %this);
		}
		else	if(%name == FlyingBug)
		{
			//echo("$FlyingBugClient[%this] - Vehicle Dismount ",$FlyingBugClient[%this]);
			Client::setControlObject(%cl, %pl);
			GameBase::setDamageLevel(%this, %name.maxDamage);
		}
		//*************************************************************************************************************
		// SF Addition - End
		//*************************************************************************************************************
		else if(getObjectType(%pl) == "Player")
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
		}
		else
			Client::sendMessage(%cl,0,"Can not dismount - Obstacle in the way.~wError_Message.wav");
	}
}

function Vehicle::onDestroyed (%this,%mom)
{
	//	if($testcheats || $servercheats)
	if(GameBase::getDataName(%this) == Osprey)
	{
		//echo("I'm called!");
		removeTurret( %this, 6 );
		removeTurret( %this, 7 );
	}
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
		//*************************************************************************************************************
		// SF Addition - Begin - 7/12/99 - 3:30AM
		//*************************************************************************************************************
		%center = GameBase::getPosition(%this);
		$ClientCommand[%FBWClientIDonRemove] = FALSE;
		
		if(GameBase::getDataName(%this) == FBWRocket)
		{
			//echo("$FBWClientIDonRemove - Vehicle onDestroyed ",$FBWClientIDonRemove);
			GameBase::applyRadiusDamage( 6, %center, 21, 1.0, 250.0, $FBWClientIDonRemove);
		}
		else
			//*************************************************************************************************************
			// SF Addition - End
			//*************************************************************************************************************
			calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 
			0.1, 225, 100); 
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	//*************************************************************************************************************
	// SF Addition - Begin - 12/18/99 - 11:30PM - CRASH CODE!!!
	//*************************************************************************************************************
	%data = GameBase::getDataName(%this);
	
	if(%data == FBWRocket)
	{
		$FBWClientIDonRemove = $FBWClientID[%this];
		%type = $FBWMissleDamageType;
		//echo("Mr. FBW is suppose to be hurt and destroyed now");
		GameBase::setDamageLevel(%this, 0.1);		
	}
	else if(%data == Osprey && GameBase::getDataName(%object) == Osprey)
		return;
	//*************************************************************************************************************
	// SF Addition - End
	//*************************************************************************************************************
	
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
	return 1.0;
}
