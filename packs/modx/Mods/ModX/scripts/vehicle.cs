// |\/| _  _|\/
// |  |(_)(_|/\ Is under copyright!
// Creator:     Vage aka Jacob B. Gohlke
// Website:     http://modx.ath.cx:1337/
//
//----------------------------------------------------------------------------
//----------------------------------------------------------------------------
//

FlierData Scout
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "flyer";
   shieldShapeName = "shield_medium";
   mass = 9.0;
   drag = 1.0;
   density = 1.2;
   maxBank = 100;
   maxPitch = 100;
   maxSpeed = 125;
   minSpeed = -25;
	lift = 0.75;
	maxAlt = 3000;
	maxVertical = 100;
	maxDamage = 0.6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.31;

	groundDamageScale = 1.0;

	//projectileType = FlierRocket;
	reloadDelay = 2.0;
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

FlierData Ball
{
	explosionId = flashExpLarge;
	debrisId = flashDebrisLarge;
	className = "Vehicle";
   shapeFile = "discammo";
   shieldShapeName = "shield_medium";
   maxBank = 20;
   maxPitch = 20;
   maxSpeed = 21;
   minSpeed = -20;
	lift = 0;
 
    maxDamage = 5.0;
    
    groundForce = 40 * 8.0;
    mass = 9.0;
    groundTraction = 3.0;

    drag = 1.0;
    density = 1.2;

	minDamageSpeed = 5.5;//25;
 
	maxAlt = 0;
	maxVertical = 0;
	//maxDamage = 6;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0;

	groundDamageScale = 1.0;

	//projectileType = FlierRocket;
	reloadDelay = 2.0;
	repairRate = 0;
	ramDamage = 1.5;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	visibleToSensor = true;
	shadowDetailMask = 2;

	visibleDriver = false;
	driverPose = 22;
	description = "Ball";
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
   maxSpeed = 25;
   minSpeed = -1;
	lift = 0.5;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 1.5;
	damageLevel = {1.0, 1.0};
	destroyDamage = 1.0;
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.50;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
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
   maxSpeed = 25;								   
   minSpeed = -1;
	lift = 0.35;
	maxAlt = 15;
	maxVertical = 6;
	maxDamage = 2.0;
	damageLevel = {1.0, 1.0};
	maxEnergy = 100;
	accel = 0.25;

	groundDamageScale = 0.125;

	repairRate = 0;
	ramDamage = 2;
	ramDamageType = -1;
	mapFilter = 2;
	mapIcon = "M_vehicle";
	fireSound = SoundFireFlierRocket;
	reloadDelay = 3.0;
	damageSound = SoundTankCrash;
	visibleToSensor = true;
	shadowDetailMask = 2;

	mountSound = SoundFlyerMount;
	dismountSound = SoundFlyerDismount;
	idleSound = SoundFlyerIdle;
	moveSound = SoundFlyerActive;

	visibleDriver = true;
	driverPose = 23;
	description = "HPC";
};


//----------------------------------------------------------------------------

$DamageScale[Scout, $ImpactDamageType] = 0.0;
$DamageScale[Scout, $BulletDamageType] = 0.0;
$DamageScale[Scout, $PlasmaDamageType] = 0.0;
$DamageScale[Scout, $EnergyDamageType] = 0.0;
$DamageScale[Scout, $ExplosionDamageType] = 0.0;
$DamageScale[Scout, $ShrapnelDamageType] = 0.0;
$DamageScale[Scout, $DebrisDamageType] = 0.0;
$DamageScale[Scout, $MissileDamageType] = 0.0;
$DamageScale[Scout, $LaserDamageType] = 0.0;
$DamageScale[Scout, $MortarDamageType] = 0.0;
$DamageScale[Scout, $BlasterDamageType] = 0.0;
$DamageScale[Scout, $ElectricityDamageType] = 0.0;
$DamageScale[Scout, $MineDamageType]        = 0.0;

$DamageScale[LAPC, $ImpactDamageType] = 1.0;
$DamageScale[LAPC, $BulletDamageType] = 1.0;
$DamageScale[LAPC, $PlasmaDamageType] = 1.0;
$DamageScale[LAPC, $EnergyDamageType] = 1.0;
$DamageScale[LAPC, $ExplosionDamageType] = 1.0;
$DamageScale[LAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[LAPC, $DebrisDamageType] = 1.0;
$DamageScale[LAPC, $MissileDamageType] = 1.0;
$DamageScale[LAPC, $LaserDamageType] = 0.5;
$DamageScale[LAPC, $MortarDamageType] = 1.0;
$DamageScale[LAPC, $BlasterDamageType] = 0.5;
$DamageScale[LAPC, $ElectricityDamageType] = 1.0;
$DamageScale[LAPC, $MineDamageType]        = 1.0;

$DamageScale[HAPC, $ImpactDamageType] = 1.0;
$DamageScale[HAPC, $BulletDamageType] = 1.0;
$DamageScale[HAPC, $PlasmaDamageType] = 1.0;
$DamageScale[HAPC, $EnergyDamageType] = 1.0;
$DamageScale[HAPC, $ExplosionDamageType] = 1.0;
$DamageScale[HAPC, $ShrapnelDamageType] = 1.0;
$DamageScale[HAPC, $DebrisDamageType] = 1.0;
$DamageScale[HAPC, $MissileDamageType] = 1.0;
$DamageScale[HAPC, $LaserDamageType] = 0.5;
$DamageScale[HAPC, $MortarDamageType] = 1.0;
$DamageScale[HAPC, $BlasterDamageType] = 0.5;
$DamageScale[HAPC, $ElectricityDamageType] = 1.0;
$DamageScale[HAPC, $MineDamageType]        = 1.0;

$DamageScale[Ball, $ImpactDamageType] = -0.0;

//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function Vehicle::onCollision (%this, %object)
{
        if(getSimTime() - %this.lastImpact < 1 && (getObjectType(%object) == "Player" || getObjectType(%object) == "Flyer"))
        {
            %parent = %object; //Easier...
            %child = %this;

            if(%child.isColliding == true)
            {
                %child.isColliding = false;
                return;
            }

            %parent.isColliding = true; //Make sure the collision doesn't nullify itself...

            // Plasmatic Code
            %Tm = GameBase::GetMass(%child);//player::getarmor(%child).mass;
            %Om = GameBase::GetMass(%parent);
            %m = %tm/%om;   //weight ratio between armors

            %vel1 = vector::multiply(%parent.lastVel,%m@" "@%m@" "@%m);
            %vel2 = vector::multiply(%child.lastVel,%m@" "@%m@" "@%m);
            // Plasmatic Code End

            %pVelocity = %vel1;
            %cVelocity = %vel2;

            %pVelX = getWord(%pVelocity, 0);
            %pVelY = getWord(%pVelocity, 1);
            %pVelZ = getWord(%pVelocity, 2);

            %cVelX = getWord(%cVelocity, 0);
            %cVelY = getWord(%cVelocity, 1);
            %cVelZ = getWord(%cVelocity, 2);

            //echo("PVX: " @ %pVelX);
            //echo("PVY: " @ %pVelY);
            //echo("PVZ: " @ %pVelZ);

            //echo("CVX: " @ %cVelX);
            //echo("CVY: " @ %cVelY);
            //echo("CVZ: " @ %cVelZ);

            %pVelVecLen = sqrt(pow(%pVelX, 2) + pow(%pVelY, 2) + pow(%pVelZ, 2));
            %pVelXNorm = %pVelX / %pVelVecLen;
            %pVelYNorm = %pVelY / %pVelVecLen;
            %pVelZNorm = %pVelZ / %pVelVecLen;

            %cVelVecLen = sqrt(pow(%cVelX, 2) + pow(%cVelY, 2) + pow(%cVelZ, 2));
            %cVelXNorm = %cVelX / %cVelVecLen;
            %cVelYNorm = %cVelY / %cVelVecLen;
            %cVelZNorm = %cVelZ / %cVelVecLen;

            //echo("PVN: " @ %pVelXNorm @ " " @ %pVelYNorm @ " " @ %pVelZNorm);
            //echo("CVN: " @ %cVelXNorm @ " " @ %cVelYNorm @ " " @ %cVelZNorm);

            //%pSpeed = (Vector::getDistance("0 0 0", %pVelocity) - 1.73205); //Adjust the speed here for inconsistance
            //%cSpeed = (Vector::getDistance("0 0 0", %cVelocity) - 1.73205); //in speed. (0 = 1.73205)

            //echo("PS: " @ %pSpeed @ "m/s");
            //echo("CS: " @ %cSpeed @ "m/s");

            %pPos = GameBase::getPosition(%parent);
            %cPos = GameBase::getPosition(%child);

            %distX = sqrt(pow(getWord(%pPos, 0), 2) + pow(getWord(%cPos, 0), 2));
            %distY = sqrt(pow(getWord(%pPos, 1), 2) + pow(getWord(%cPos, 1), 2));
            %distZ = sqrt(pow(getWord(%pPos, 2), 2) + pow(getWord(%cPos, 2), 2));

            //Assume it's two 'spheres' colliding.
            %collisionPlaneNormal = %distX @ " " @ %distY @ " " @ %distZ;
            //%collisionPlaneNormal = Vector::Normalize(Vector::Sub(%pPos, %cPos));

            %cpnX = getWord(%collisionPlaneNormal, 0);
            %cpnY = getWord(%collisionPlaneNormal, 1);
            %cpnZ = getWord(%collisionPlaneNormal, 2);

            %coeOfRestit = 0.2; //Coefficient of Restitution: 1 = Perfectly elastic -- 0 = Perfectly plastic

            %velDiffX = %pVelX - %cVelX;
            %velDiffY = %pVelY - %cVelY;
            %velDiffZ = %pVelZ - %cVelZ;

            %velDiffX *= -(1 + %coeOfRestit);
            %velDiffY *= -(1 + %coeOfRestit);
            %velDiffZ *= -(1 + %coeOfRestit);

            %pMass = GameBase::GetMass(%parent);
            %cMass = GameBase::GetMass(%child);

            //echo("PM: " @ %pMass);
            //echo("CM: " @ %cMass);

            %inversemass = (1 / %pMass) + (1 / %cMass);

            %impulseX = Vector::dot(%velDiffX, %cpnX) / Vector::dot(%cpnX, %cpnX * %inversemass);
            %impulseY = Vector::dot(%velDiffY, %cpnY) / Vector::dot(%cpnY, %cpnY * %inversemass);
            %impulseZ = Vector::dot(%velDiffZ, %cpnZ) / Vector::dot(%cpnZ, %cpnZ * %inversemass);

            //echo("IX: " @ %impulseX);
            //echo("IY: " @ %impulseY);
            //echo("IZ: " @ %impulseZ);

            %pFinalVelocityX = (%pVelX + (%impulseX / %pMass) * %cpnX);
            %pFinalVelocityY = (%pVelY + (%impulseY / %pMass) * %cpnY);
            %pFinalVelocityZ = (%pVelZ + (%impulseZ / %pMass) * %cpnZ);

            %cFinalVelocityX = (%cVelX - (%impulseX / %cMass) * %cpnX);
            %cFinalVelocityY = (%cVelY - (%impulseY / %cMass) * %cpnY);
            %cFinalVelocityZ = (%cVelZ - (%impulseZ / %cMass) * %cpnZ);

            %pFinalVelocity = %pFinalVelocityX @ " " @ %pFinalVelocityY @ " " @ %pFinalVelocityZ;
            %cFinalVelocity = %cFinalVelocityX @ " " @ %cFinalVelocityY @ " " @ %cFinalVelocityZ;

            //echo("POV: " @ %pVelocity);
            //echo("COV: " @ %cVelocity);

            //echo("PFV: " @ %pFinalVelocity);
            //echo("CFV: " @ %cFinalVelocity);

            Item::setVelocity(%parent, %pFinalVelocity);
            Item::setVelocity(%child, %cFinalVelocity);
        }

	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "")
			{
            if( Player::isAiControlled(%object) )
               return;

				else if(GameBase::getDataName(%this) == Ball)
					{
                        return;
					}
               
				%armor = Player::getArmor(%object);
		      %client = Player::getClient(%object);
				if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object))
					{
						%weapon = Player::getMountedItem(%object,$WeaponSlot);
						if(%weapon != -1) {
							%object.lastWeapon = %weapon;
							Player::unMountItem(%object,$WeaponSlot);
						}
						Player::setMountObject(%object, %this, 1);
				        Client::setControlObject(%client, %this);

                        //%velocity = 70;
                        //%zVec = 70;
                        //%mom = Vector::getFromRot(GameBase::getRotation(%object),%velocity,%zVec);

                        playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
						%object.driver= 1;
		                %object.vehicle = %this;
						%this.clLastMount = %client;
                        //Vehicle::jump(%this,%mom);
                        //schedule("Vehicle::jump("@%this@","@%mom@");", 10.1, %this);//300.1, %this);
					}
				else if(GameBase::getDataName(%this) != Scout) 
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
					Client::sendMessage(Player::getClient(%object),0,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
			}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
    if(GameBase::getDataName(%this) == Ball)
        %numSlots = 0;

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
        %this.PassengerMass += GameBase::getMass(Client::getOwnedObject(%client));
		%this.Seat[%lastEmpty-2] = %client;
		return %lastEmpty;
	}
	else if (%count > 1)	{
		%freeSlot = %slotVal[getClosestPosition(%count,GameBase::getPosition(%client),%slotPos[0],%slotPos[1],%slotPos[2],%slotPos[3])];
        %this.PassengerMass += GameBase::getMass(Client::getOwnedObject(%client));
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
  
        %this.PassengerMass -= GameBase::getMass(%passenger);
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

                %this.PassengerMass -= GameBase::getMass(%passenger);

                if(%pl.lastWeapon != "") {
					Player::useItem(%pl,%pl.lastWeapon);		 	
					%pl.lastWeapon = "";
      		}
				%pl.driver = "";
				%pl.vehicle = "";
                $TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--;
                schedule("deleteObject(" @ %this @ ");", 0.1, %this);
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
    //Plasmatic Code
    if(%type == $ImpactDamageType)
    {
      %vel = Item::getVelocity(%this);
      %speed = vector::getdistance(%vel,"0 0 0");

      %this.lastSpeed = %speed;
      %this.lastVel = %vel;
      %this.lastImpact  = getSimTime();
      
      Vehicle::onCollision (%this, %object);
    }
    //Plasmatic Code End

	%value *= $damageScale[GameBase::getDataName(%this), %type];
	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function Vehicle::getHeatFactor(%this)
{
	// Not getting called right now because turrets don't track
	// vehicles.  A hack has been placed in Player::getHeatFactor.
   return 1.0;
}
