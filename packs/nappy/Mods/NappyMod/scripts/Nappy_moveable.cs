function Elevator::onBlocker(%this,%obj)
{
// Will get called 30/s for blocking objects
//echo("Moveable::onBlocker: " @ %this @ " " @ %obj);
	%object = GameBase::getDataName(%obj);
	%class = %object.className;
	if(%class == "ARMOR"){
		GameBase::applyDamage(%obj,$CrushDamageType,$Nappy::Elevator::ArmorCrushDamage,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	}
	else{
		GameBase::applyDamage(%obj,$CrushDamageType,$Nappy::Elevator::ObjectCrushDamage,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
	}
}




function Elevator::onTrigger(%this,%object,%trigger)
{
	%position = Moveable::getPosition(%this);
	if(%position != 0 && !$Nappy::Elevator::Stoppable)
		return;
	if(%position == 0){
		%clearing = Nappy::Elevator::ClearStartPath(%this);
	}
	if(!%clearing){
		if(%this.triggerHit == "" && %this.delayTime < getSimTime()) {
			%this.triggerHit = 1;
			%this.status = "up";
		   	if(!Elevator::onCollision(%this,%object))
		  		%this.triggerHit = "";
		}
	}
}



function Elevator::onCollision(%this, %object)
{
	%position = Moveable::getPosition(%this);
	if(%position == 0){
		%clearing = Nappy::Elevator::ClearStartPath(%this);
	}
	if(!%clearing){
		if(!Player::isDead(%object) && getObjectType(%object) == "Player")
			if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || %this.noTeam != "" || GameBase::getTeam(%this) == -1) {
				if(GameBase::isActive(%this) && %this.loop == "" && GameBase::isPowered(%this)  && getSimTime() >= %this.delayTime) {
					if(Moveable::getPosition(%this) == 0 && (%this.triggered == "" || %this.delayTime + 1.5 < getSimTime()) && %this.triggerHit == "") { 
						%this.delayTime = getSimTime() + 2.0;
						%this.triggered = 1;
					}
					if( getSimTime() >= %this.delayTime ) { 
						Elevator::trigger(%this);
						return true;
					}
				}
				else if(GameBase::getDataName(%object) == AntipersonelMine) 
					AntipersonelMine::onCollision(%object,%this);
			}
	}
	return false;
	
}




function Elevator::onMove(%this)
{
	schedule("Nappy::StartElevatorTracking(" @ %this @ ");",0.2);
	if(GameBase::isPowered(%this) && GameBase::isActive(%this)) {	
		if(%this.status == "up")  
			Moveable::moveToWaypoint(%this,Moveable::getPosition(%this)+1);				
		else if(%this.status == "down")
			Moveable::moveToWaypoint(%this,Moveable::getPosition(%this)-1);				
		%this.triggered = "";
	}
}




function Nappy::Object::Delete(%object)
{
	%name = GameBase::getDataName(%object);
	%team = GameBase::getTeam(%object);
	if(%name == "DeployableMotionSensor"){
		$TeamItemCount[%team @ MotionSensorPack]--;
		return 1;
	}
	if(%name == "DeployablePulseSensor"){
		$TeamItemCount[%team @ PulseSensorPack]--;
		return 1;
	}
	if(%name == "DeployableSensorJammer"){
		$TeamItemCount[%team @ DeployableSensorJammerPack]--;
		return 1;
	}
	if(%name == "AlarmKit"){
		$TeamItemCount[%team @ BaseAlarm]--;
		return 1;
	}
	if(%name == "DeployableInvStation"){
		$TeamItemCount[%team @ DeployableInvPack]--;
		return 1;
	}
	if(%name == "DeployableAmmoStation"){
		$TeamItemCount[%team @ DeployableAmmoPack]--;
		return 1;
	}
	if(%name == "DeployableComStation"){
		$TeamItemCount[%team @ DeployableComPack]--;
		return 1;
	}
	return 0;
}




function Nappy::Elevator::ClearStartPath(%this)
{
	%pos = GameBase::getPosition(%this);
	%pos = Vector::add(%pos,"0 0 " @ $Nappy::ElevatorClearStartDistance::BoxHeightOffset);
	%BoxLength = $Nappy::ElevatorClearStartDistance::BoxLength;
	%BoxWidth = $Nappy::ElevatorClearStartDistance::BoxWidth;
	%BoxHeight = $Nappy::ElevatorClearStartDistance::BoxHeight;
	%set = newObject("AEStart" @ %this,SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType|$MineObjectType|$VehicleObjectType|$ItemObjectType, %pos, %BoxLength, %BoxWidth, %BoxHeight, 0);
	if(%num){//object(s) in the way
		%deleting = 0;
		%object = Group::getObject(%set,0);
		%delete = Nappy::Object::Delete(%object);
		if(%delete){
			deleteObject(Group::getObject(%set,0));
			%deleting = 1;
		}
		if(%num > 1){
			%object = Group::getObject(%set,1);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,1));
				%deleting = 1;
			}
		}
		if(%num > 2){
			%object = Group::getObject(%set,2);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,2));
				%deleting = 1;
			}
		}
		if(%num > 3){
			%object = Group::getObject(%set,3);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,3));
				%deleting = 1;
			}
		}
		if(%num > 4){
			%object = Group::getObject(%set,4);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,4));
				%deleting = 1;
			}
		}
		if(%num > 5){
			%object = Group::getObject(%set,5);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,5));
				%deleting = 1;
			}
		}
		if(%num > 6){
			%object = Group::getObject(%set,6);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,6));
				%deleting = 1;
			}
		}
		if(%num > 7){
			%object = Group::getObject(%set,7);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,7));
				%deleting = 1;
			}
		}
		if(%num > 8){
			%object = Group::getObject(%set,8);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,8));
				%deleting = 1;
			}
		}
		deleteObject(%set);
		return %deleting;
	}
	deleteObject(%set);
	return 0;
}



function Nappy::StartElevatorTracking(%this)
{
	%pos = GameBase::getPosition(%this);
	%BoxLength = $Nappy::ElevatorServerCrashDistance::BoxLength;
	%BoxWidth = $Nappy::ElevatorServerCrashDistance::BoxWidth;
	%BoxHeight = $Nappy::ElevatorServerCrashDistance::BoxHeight;
	%set = newObject("AEScrash" @ %this,SimSet);
	%num = containerBoxFillSet(%set, $StaticObjectType|$MineObjectType|$VehicleObjectType|$ItemObjectType, %pos, %BoxLength, %BoxWidth, %BoxHeight, 0);
	if(%num){//object(s) in the way
		%object = Group::getObject(%set,0);
		%delete = Nappy::Object::Delete(%object);
		if(%delete){
			deleteObject(Group::getObject(%set,0));
		}
		if(%num > 1){
			%object = Group::getObject(%set,1);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,1));
			}
		}
		if(%num > 2){
			%object = Group::getObject(%set,2);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,2));
			}
		}
		if(%num > 3){
			%object = Group::getObject(%set,3);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,3));
			}
		}
		if(%num > 4){
			%object = Group::getObject(%set,4);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,4));
			}
		}
		if(%num > 5){
			%object = Group::getObject(%set,5);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,5));
			}
		}
		if(%num > 6){
			%object = Group::getObject(%set,6);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,6));
			}
		}
		if(%num > 7){
			%object = Group::getObject(%set,7);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,7));
			}
		}
		if(%num > 8){
			%object = Group::getObject(%set,8);
			%delete = Nappy::Object::Delete(%object);
			if(%delete){
				deleteObject(Group::getObject(%set,8));
			}
		}
		//deleteObject(%set);
	}
	deleteObject(%set);
	%position = Moveable::getPosition(%this);
	if(%position == 0){
		//return;
	}
	else
		schedule("Nappy::StartElevatorTracking(" @ %this @ ");",0.1);
}

