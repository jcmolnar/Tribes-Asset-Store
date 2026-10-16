
//----------------------------------------------------------------------------

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function Vehicle::onCollision (%this, %object)
{
	// if the vehicle is not destroyed
	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {

		// if a player collides with the vehicle, and the player is not already in a vehicle, and time condition, and not disappearing
		if (getObjectType (%object) == "Player" && %object.vehicle == "" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") {

			// if an AI bot, sorry no vehicle for you
			if( Player::isAiControlled(%object) )
				return;

			// === Added in Base v1.11 ===
			if(%object.Station != "") {
				Client::sendMessage(Player::getClient(%object),0,"You must leave the Inventory Station to pilot the vehicles.~wError_Message.wav");
				return;
			}
			// ============================

			// get player information               
			%armor = Player::getArmor(%object);
			%client = Player::getClient(%object);

			// if in commander armor, and this is an any vehicle (we don't allow commander to ride in any)
			if(%armor == "commanderarmor") {
				Client::sendMessage(Player::getClient(%object), 0, "You cannot enter this vehicle in your current armor.~wError_Message.wav");
				return;
			}

			%name = GameBase::getDataName(%this);

			// if in the correct armor, and the vehicle is mountable
			if ((%armor == "reconarmor" || %armor == "reconfemalearmor" 
				|| %armor == "espionagearmor" || %armor == "espionagefemalearmor")
				&& Vehicle::canMount (%this, %object)) {
				%pilot = true;
			}

			// new
			else if ((%name != Bomber && %name != Fighter && %name != Helicopter)
				&& (%armor == "infantryarmor" || %armor == "infantryfemalearmor" 
					|| %armor == "falloutarmor" || %armor == "falloutfemalearmor"
					|| %armor == "engineerarmor" || %armor == "engineerfemalearmor")
				&& Vehicle::canMount(%this, %object)) {
				%pilot = true;
			}
			else if ((%name == APC || %name == Cargo || %name == Supply || %name == Tank)
				&& (%armor == "artilleryarmor" || %armor == "assaultarmor" 
					|| %armor == "demolitionsarmor")
				&& Vehicle::canMount(%this, %object)) {
				%pilot = true;
			}

			if (%pilot == true) {

				// let's save the player's current weapon for when we dismount, and let's have them stow it
				%weapon = Player::getMountedItem(%object,$WeaponSlot);
				if(%weapon != -1) {
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}

				// mount the player on the vehicle, and give player control of it
				Player::setMountObject(%object, %this, 1);
				Client::setControlObject(%client, %this);

				// play the mount sound
				playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));

				// set various data members
				%object.driver= 1;
				%object.vehicle = %this;
				%this.clLastMount = %client;
				return;
			}
			// but if not in correct armor, and this is a one-man vehicle
			if(%name == Scout || %name == Bomber || %name == Fighter || %name == Helicopter) {
				if (GameBase::getControlClient(%this) == -1) {
					Client::sendMessage(Player::getClient(%object), 0, "You must be in a light armor to pilot this vehicle.~wError_Message.wav");
					return;
				}
			}
			if(%name != Scout || %name != Bomber || %name != Fighter || %name != Helicopter) {
				// but if not in correct armor, if this is not a one-man vehicle
				// let's get the next empty passenger seat
			 	%mountSlot= Vehicle::findEmptySeat(%this,%client); 

				// if there's an empty passenger seat, put the player there, etc.
				if(%mountSlot) {
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (GameBase::getDataName(%this).mountSound, GameBase::getPosition(%this));
					return;
				}
			}
			// if not in correct armor, and this is an outrider
			if(%name == Outrider) {
				if (GameBase::getControlClient(%this) == -1) {
					Client::sendMessage(Player::getClient(%object), 0, "You must be in a light or medium armor to pilot this vehicle.~wError_Message.wav");
					return;
				}
			}
		}
	}
}

function Vehicle::findEmptySeat(%this,%client)
{
	if(GameBase::getDataName(%this) == HAPC || GameBase::getDataName(%this) == Tank || GameBase::getDataName(%this) == APC)
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

function Vehicle::passengerJump(%this, %passenger, %mom)
{
	%armor = Player::getArmor(%passenger);

	// echo("Jumping in armor: " @%armor);

	if(%armor == "reconarmor" || %armor == "reconfemalearmor" || %armor == "espionagearmor" || %armor == "espionagefemalearmor") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	}
	else if(%armor == "infantryarmor" || %armor == "infantryfemalearmor" || %armor == "falloutarmor" || %armor == "falloutfemalearmor" || %armor == "engineerarmor" || %armor == "engineerfemalearmor") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	}
	else if(%armor == "demolitionsarmor" || %armor == "assaultarmor" || %armor == "artilleryarmor" || %armor == "commanderarmor") {
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
	// echo("dismount()");
	%cl = GameBase::getControlClient(%this);
	if(%cl != -1) {
		%pl = Client::getOwnedObject(%cl);
		if(getObjectType(%pl) == "Player") {
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

			// remove cannon, if any
			Player::setItemCount(%pl, TankArtilleryShell, 0);
			Player::setItemCount(%pl, TankCannon, 0);

			%pl.vehicleSlot = "";
			%pl.vehicle= "";
		}
		calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); 
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

