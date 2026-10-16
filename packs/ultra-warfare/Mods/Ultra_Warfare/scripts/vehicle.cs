//-----------------------------------------------------------------
SoundData SoundVehMount
{
   wavFileName = "veh_Mount.wav";
   profile = Profile3dNear;
};
SoundData SoundVehDismount
{
   wavFileName = "veh_dismount.wav";
   profile = Profile3dNear;
};
SoundData SoundVehCrash
{
   wavFileName = "Veh_crash.wav";
   profile = Profile3dNear;
};
//==================================
exec(veh_cycle);
exec(veh_shrike);
exec(veh_bomber);
exec(veh_transport);

//==================================

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
			
			if ((%armor == "larmor" || %armor == "lfemale") && Vehicle::canMount (%this, %object))
				
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
	if(GameBase::getDataName(%this) == FBWRocket)
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

