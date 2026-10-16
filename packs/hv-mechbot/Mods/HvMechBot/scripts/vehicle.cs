//----------------------------------------------------------------------------
FlierData ShortCoolProj 
{ 
	description = "ArrowIV Missile"; 
	explosionId = bulletExpHV;
	className = "Vehicle"; 
	shapeFile = "rocket"; 
	shieldShapeName = "shield_medium"; 
	mass = 9.0; 
	drag = 1.5; 
	density = 1.2; 
	maxBank = 50; 
	maxPitch = 5000; 
	maxSpeed = 51; 
	minSpeed = 50; 
	lift = 0; 
	maxAlt = 9000; 
	maxVertical = 10; 
	destroyDamage = 0.001; 
	maxDamage = 0.001; 
	damageLevel = {0.001, 0.001}; 
	maxEnergy = 10; 
	accel = 100.0; 

	groundDamageScale = 1.0; 

	repairRate = 0; 
	damageSound = SoundFlierCrash; 
	ramDamage = 0.01; 
	ramDamageType = $MissileDamageType; 
	visibleToSensor = true; 
	shadowDetailMask = 2; 

	idleSound = SoundWindGust; 
	moveSound = SoundWindGust; 
	visibleDriver = true; 
	driverPose = 22; 
};
function ShortCoolProj::onAdd(%this)//+++++++++ FIX ++++++++
{
	schedule("DeployKill(" @ %this @ " , 1);",8.0,%this);
}
function DeployKill(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","DogVomit2");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeployKill(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
function DeploySmoke2(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","DogVomit");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeploySmoke2(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}

//+++++++++++++++++++++++++++++++++++
FlierData Riever
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.5;
   maxPitch = 0.5;
   maxSpeed = 55;
   minSpeed = -5;
	lift = 0.75;
	maxAlt = 20;
	maxVertical = 10;
	maxDamage = 2.2;
	damageLevel = {1.0, 1.0};
	maxEnergy = 160;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = ArrowIVMissile;
	reloadDelay = 4.0;
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
	description = "Riever";
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData Corsair
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.65;
   maxPitch = 0.65;
   maxSpeed = 75;
   minSpeed = -5;
	lift = 0.75;
	maxAlt = 35;
	maxVertical = 15;
	maxDamage = 1.8;
	damageLevel = {1.0, 1.0};
	maxEnergy = 130;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = AC10Tracer;
	reloadDelay = 0.15;
	repairRate = 0;
	fireSound = debrisMediumExplosion;
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
	description = "Corsair";
};
function Corsair::onMount(%player,%item)
{
	Client::sendMessage(Player::getClient(%player), 0,"-Piloting a Corsair Aerotech Fighter-~wpda_on.wav");
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData Stingray
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.8;
   maxPitch = 0.8;
   maxSpeed = 65;
   minSpeed = -5;
	lift = 0.75;
	maxAlt = 25;
	maxVertical = 15;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	maxEnergy = 150;
	accel = 0.4;

	groundDamageScale = 1.0;

	projectileType = PPCBolt;
	reloadDelay = 1.75;
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
	description = "Stingray";
};
function Vehicle::OnFire(%this, %slot)
 {
   %enVal  = 30.0;
   %energy = GameBase::getEnergy(%this);
   %energy = %energy - %enVal;

   if (%energy > 5.0)
	{
   		 GameBase::setEnergy(%this,%energy);
		 playSound(SoundFireFlierRocket,GameBase::getPosition(%this));
		 %trans = GameBase::getMuzzleTransform(%this);
		 %vel = Item::getVelocity(%this);
		 Projectile::spawnProjectile("PPCBolt",%trans,%this,%vel);
	 }
	 else
	{
	 playSound(SoundPackFail,GameBase::getPosition(%this));
	 Player::trigger(%this,$WeaponSlot,false);
	 Client::sendMessage(Player::getClient(%player), 1,"-HEAT SINKS OVERLOADED, Cannot Fire-");
	} 
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData Leopard
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc_sml";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.3;
   maxPitch = 0.3;
   maxSpeed = 30;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 20;
	maxVertical = 8;
	maxDamage = 3.0;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 300;
	accel = 0.25;

	groundDamageScale = 0.50;

	projectileType = STR2Missile;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundMissileTurretFire;
	reloadDelay = 0.8;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Leopard Class";
};

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
FlierData Union
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "hover_apc";
   shieldShapeName = "shield_large";
   mass = 18.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 0.2;
   maxPitch = 0.2;
   maxSpeed = 25;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 4.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 500;
	accel = 0.25;

	groundDamageScale = 0.125;

	projectileType = MortarTurretShell;
	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = bigExplosion1;
	reloadDelay = 3.5;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "Union Class";
};

//----------------------------------------------------------------------------
$DamageScale[Riever, $LandingDamageType] = 1.0;
$DamageScale[Riever, $ImpactDamageType] = 1.0;
$DamageScale[Riever, $CrushDamageType] = 1.0;
$DamageScale[Riever, $DebrisDamageType] = 1.0;
$DamageScale[Riever, $ExplosionDamageType] = 1.0;
$DamageScale[Riever, $ShrapnelDamageType] = 1.0;
$DamageScale[Riever, $BulletDamageType] = 1.0;
$DamageScale[Riever, $FlamerDamageType] = 1.0;
$DamageScale[Riever, $ElectricityDamageType] = 1.0;
$DamageScale[Riever, $PPCDamageType] = 1.0;
$DamageScale[Riever, $GaussDamageType] = 1.0;
$DamageScale[Riever, $LaserDamageType] = 1.0;
$DamageScale[Riever, $ACDamageType] = 1.0;
$DamageScale[Riever, $SniperDamageType] = 1.0;
$DamageScale[Riever, $STRDamageType] = 1.0;
$DamageScale[Riever, $LRMDamageType] = 1.0;
$DamageScale[Riever, $MissileDamageType] = 1.0;
$DamageScale[Riever, $MineDamageType] = 1.0;
$DamageScale[Riever, $InfernoDamageType] = 1.0;

$DamageScale[Corsair, $LandingDamageType] = 1.0;
$DamageScale[Corsair, $ImpactDamageType] = 1.0;
$DamageScale[Corsair, $CrushDamageType] = 1.0;
$DamageScale[Corsair, $DebrisDamageType] = 1.0;
$DamageScale[Corsair, $ExplosionDamageType] = 1.0;
$DamageScale[Corsair, $ShrapnelDamageType] = 1.0;
$DamageScale[Corsair, $BulletDamageType] = 1.0;
$DamageScale[Corsair, $FlamerDamageType] = 1.0;
$DamageScale[Corsair, $ElectricityDamageType] = 1.0;
$DamageScale[Corsair, $PPCDamageType] = 1.0;
$DamageScale[Corsair, $GaussDamageType] = 1.0;
$DamageScale[Corsair, $LaserDamageType] = 1.0;
$DamageScale[Corsair, $ACDamageType] = 1.0;
$DamageScale[Corsair, $SniperDamageType] = 1.0;
$DamageScale[Corsair, $STRDamageType] = 1.0;
$DamageScale[Corsair, $LRMDamageType] = 1.0;
$DamageScale[Corsair, $MissileDamageType] = 1.0;
$DamageScale[Corsair, $MineDamageType] = 1.0;
$DamageScale[Corsair, $InfernoDamageType] = 1.0;

$DamageScale[Stingray, $LandingDamageType] = 1.0;
$DamageScale[Stingray, $ImpactDamageType] = 1.0;
$DamageScale[Stingray, $CrushDamageType] = 1.0;
$DamageScale[Stingray, $DebrisDamageType] = 1.0;
$DamageScale[Stingray, $ExplosionDamageType] = 1.0;
$DamageScale[Stingray, $ShrapnelDamageType] = 1.0;
$DamageScale[Stingray, $BulletDamageType] = 1.0;
$DamageScale[Stingray, $FlamerDamageType] = 1.0;
$DamageScale[Stingray, $ElectricityDamageType] = 1.0;
$DamageScale[Stingray, $PPCDamageType] = 1.0;
$DamageScale[Stingray, $GaussDamageType] = 1.0;
$DamageScale[Stingray, $LaserDamageType] = 1.0;
$DamageScale[Stingray, $ACDamageType] = 1.0;
$DamageScale[Stingray, $SniperDamageType] = 1.0;
$DamageScale[Stingray, $STRDamageType] = 1.0;
$DamageScale[Stingray, $LRMDamageType] = 1.0;
$DamageScale[Stingray, $MissileDamageType] = 1.0;
$DamageScale[Stingray, $MineDamageType] = 1.0;
$DamageScale[Stingray, $InfernoDamageType] = 1.0;

$DamageScale[Leopard, $LandingDamageType] = 1.0;
$DamageScale[Leopard, $ImpactDamageType] = 1.0;
$DamageScale[Leopard, $CrushDamageType] = 1.0;
$DamageScale[Leopard, $DebrisDamageType] = 1.0;
$DamageScale[Leopard, $ExplosionDamageType] = 1.0;
$DamageScale[Leopard, $ShrapnelDamageType] = 1.0;
$DamageScale[Leopard, $BulletDamageType] = 1.0;
$DamageScale[Leopard, $FlamerDamageType] = 1.0;
$DamageScale[Leopard, $ElectricityDamageType] = 1.0;
$DamageScale[Leopard, $PPCDamageType] = 1.0;
$DamageScale[Leopard, $GaussDamageType] = 1.0;
$DamageScale[Leopard, $LaserDamageType] = 1.0;
$DamageScale[Leopard, $ACDamageType] = 1.0;
$DamageScale[Leopard, $SniperDamageType] = 1.0;
$DamageScale[Leopard, $STRDamageType] = 1.0;
$DamageScale[Leopard, $LRMDamageType] = 1.0;
$DamageScale[Leopard, $MissileDamageType] = 1.0;
$DamageScale[Leopard, $MineDamageType] = 1.0;
$DamageScale[Leopard, $InfernoDamageType] = 1.0;

$DamageScale[Union, $LandingDamageType] = 1.0;
$DamageScale[Union, $ImpactDamageType] = 1.0;
$DamageScale[Union, $CrushDamageType] = 1.0;
$DamageScale[Union, $DebrisDamageType] = 1.0;
$DamageScale[Union, $ExplosionDamageType] = 1.0;
$DamageScale[Union, $ShrapnelDamageType] = 1.0;
$DamageScale[Union, $BulletDamageType] = 1.0;
$DamageScale[Union, $FlamerDamageType] = 1.0;
$DamageScale[Union, $ElectricityDamageType] = 1.0;
$DamageScale[Union, $PPCDamageType] = 1.0;
$DamageScale[Union, $GaussDamageType] = 1.0;
$DamageScale[Union, $LaserDamageType] = 1.0;
$DamageScale[Union, $ACDamageType] = 1.0;
$DamageScale[Union, $SniperDamageType] = 1.0;
$DamageScale[Union, $STRDamageType] = 1.0;
$DamageScale[Union, $LRMDamageType] = 1.0;
$DamageScale[Union, $MissileDamageType] = 1.0;
$DamageScale[Union, $MineDamageType] = 1.0;
$DamageScale[Union, $InfernoDamageType] = 1.0;

$DamageScale[ShortCoolProj, $LandingDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ImpactDamageType] = 1.0;
$DamageScale[ShortCoolProj, $CrushDamageType] = 1.0;
$DamageScale[ShortCoolProj, $DebrisDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ExplosionDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ShrapnelDamageType] = 1.0;
$DamageScale[ShortCoolProj, $BulletDamageType] = 1.0;
$DamageScale[ShortCoolProj, $FlamerDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ElectricityDamageType] = 1.0;
$DamageScale[ShortCoolProj, $PPCDamageType] = 1.0;
$DamageScale[ShortCoolProj, $GaussDamageType] = 1.0;
$DamageScale[ShortCoolProj, $LaserDamageType] = 1.0;
$DamageScale[ShortCoolProj, $ACDamageType] = 1.0;
$DamageScale[ShortCoolProj, $SniperDamageType] = 1.0;
$DamageScale[ShortCoolProj, $STRDamageType] = 1.0;
$DamageScale[ShortCoolProj, $LRMDamageType] = 1.0;
$DamageScale[ShortCoolProj, $MissileDamageType] = 1.0;
$DamageScale[ShortCoolProj, $InfernoDamageType] = 1.0;

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
//            if( Player::isAiControlled(%object) )
//              return;
               
				%armor = Player::getArmor(%object);
		     		 %client = Player::getClient(%object);
				if ((%armor == "larmor") && Vehicle::canMount (%this, %object))
					{
					if (!Player::isAiControlled(%object))  //No bots allowed as drivers!! Only as passengers!
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
						$Spoonbot::IsPilot[%client] = True;
						BotFuncs::BotsHopOn(%client);
						}
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				      	Client::setControlObject(%client, %this);
					      doneposs(%client);//++++++++++++++
						Client::sendMessage(Player::getClient(%object), 0,"-Piloting a "@ GameBase::getDataName(%this) @ "-Class Aerotech Vehicle-~wpda_on.wav"); //++++++++++++++++
						playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		            %object.vehicle = %this;
						%this.clLastMount = %client;
					}
				else if(GameBase::getDataName(%this) != Riever && GameBase::getDataName(%this) != Corsair && GameBase::getDataName(%this) != Stingray) 
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
					Client::sendMessage(Player::getClient(%object),1,"-Only a Commando is small enough to pilot Aerotech Vehicles-~wError_Message.wav");
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{							
	if((GameBase::getDataName(%this) == HAPC)||(GameBase::getDataName(%this) == Union)||(GameBase::getDataName(%this) == "Union Class"))
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
	if(%armor == "larmor" || %armor == "parmor" || %armor == "dmarmor") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "marmor" || %armor == "carmor" || %armor == "hbarmor" || %armor == "aarmor") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "harmor" || %armor == "barmor") {
		%height = 2;
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
		if ($Spoonbot::IsPilot[%client]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
		{
			BotsHopOff(%client);
		}
	}
	else
		Client::sendMessage(Player::getClient(%passanger),1,"Can not dismount - Obstacle in the way.~wError_Message.wav");
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
			if ($Spoonbot::IsPilot[%cl]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
			{
				BotsHopOff(%cl);
			}
			if ($Spoonbot::IsPilot[%pl]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
			{
				BotsHopOff(%pl);
			}
      		}
				%pl.driver = "";
				%pl.vehicle = "";
			}
			else
				Client::sendMessage(%cl,1,"Can not dismount - Obstacle in the way.~wError_Message.wav");
		}
   }
}

function Vehicle::onDestroyed (%this,%mom)
{
						//+++++++++ ArrowIV Guidance client drop ++++++++++++++++
						if(GameBase::getDataName(%this) == ShortCoolProj)
						{
						schedule("DeploySmoke2(" @ %this @ " , 1);",0.01,%this);
						}
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
	if ($Spoonbot::IsPilot[%cl]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
	{
		BotsHopOff(%cl);
	}
	if ($Spoonbot::IsPilot[%pl]==True)  //It's a human who was piloting this thing, so make all riding bots bail out too.
	{
		BotsHopOff(%pl);
	}
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