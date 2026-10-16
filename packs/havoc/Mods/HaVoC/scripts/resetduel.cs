function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId) { 

%damVal = %timeSlice * %damPerSec; %enVal = %timeSlice * %enDrainPerSec; 

if (%damPerSec == 0.119997 || %damPerSec == 0.0449997 || %damPerSec == 0.0999997)
	GameBase::applyDamage(%target, $ElectricityTEDamageType, %damVal, %pos, %vec, %mom, %shooterId); 
else if(%damPerSec == 0.125 || %damPerSec == 0.176997)
	GameBase::applyDamage(%target, $Lit2DamageType, %damVal, %pos, %vec, %mom, %shooterId); 
else if(%damPerSec == 0.109997)
	GameBase::applyDamage(%target, $LitDamageType, %damVal, %pos, %vec, %mom, %shooterId); 
else
	GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId); 

%ot = getObjectType(%target);
if (%ot == "Turret" || %ot == "Sensor") %enVal *= 0.22;

%energy = GameBase::getEnergy(%target); %energy = %energy - %enVal; if (%energy < 0) { %energy = 0; } GameBase::setEnergy(%target, %energy); 

}

exec("ex.cs");

function Elevator::onAdd(%this)
{
	%this.delayTime = getSimTime();
}

function Elevator::onNewPath(%this)
{
	%this.status = "up";
	Moveable::setWaypoint(%this,0);
	if(%this.loop != "")	
		Elevator::onMove(%this);	
}

function Elevator::onEnabled(%this)
{
	GameBase::setActive(%this,true);
	if(!GameBase::isPowered(%this))
		Moveable::moveToWaypoint(%this,0);				
	if(Moveable::getPosition(%this) != 0 || %this.loop != "") {
		%this.delayTime = getSimTime() + 1;
		Elevator::checkDelay(%this);		
	}
}

function Elevator::trigger(%this)
{
	if(%this.loop == "" && Moveable::getPosition(%this) == 0)
		Elevator::checkDelay(%this);		
}

function Elevator::onPower(%this, %state, %generator)
{
	if(%state) {
		if(Moveable::getPosition(%this) != 0 || %this.loop != "") {
			%this.delayTime = getSimTime() + 1;
			Elevator::checkDelay(%this);		
		}
	}
	else  
		Moveable::moveToWaypoint(%this,0);				
}

function Elevator::onMove(%this)
{
	if(GameBase::isPowered(%this) && GameBase::isActive(%this)) {	
		if(%this.status == "up")  
			Moveable::moveToWaypoint(%this,Moveable::getPosition(%this)+1);				
		else if(%this.status == "down")
			Moveable::moveToWaypoint(%this,Moveable::getPosition(%this)-1);				
		%this.triggered = "";
	}
}

function Elevator::onFirst(%this)
{
	%this.status = "up";
	%this.delayTime = getSimTime() + 1.5;
	%this.triggerHit = "";
	if(%this.loop != "")	{
		Elevator::checkDelay(%this);		
	}
}

function Elevator::onWaypoint(%this)
{
	%waypoint = Moveable::getPosition(%this);
	if(%waypoint != 0 && %waypoint != Moveable::getWaypointCount(%this)-1) {  
		if((%this.status == "up" && %this.stopWayUp != "") || (%this.status == "down" && %this.stopWayDown != "")) {
			%this.delayTime = getSimTime() + 1.5;
			Elevator::checkDelay(%this);		
		}
		else
			Elevator::onMove(%this);
	}
}

function Elevator::onLast(%this)
{
	%this.status = "down";
	%this.waypoint = "top";
	%this.delayTime = getSimTime() + 1.5;
	Elevator::checkDelay(%this);		
}

$ItemMax[dmarmor, IXRocketLauncher] = 1;
$ItemMax[dmfemale, IXRocketLauncher] = 1;
$MaxWeapons[dmarmor] = 4;
$MaxWeapons[dmfemale] = 4;

function Elevator::onCollision(%this, %object)
{
	if(!Player::isDead(%object) && getObjectType(%object) == "Player")
		if (GameBase::getTeam(%this) == GameBase::getTeam(%object) || %this.noTeam != "" || GameBase::getTeam(%this) == -1) {
			if (GameBase::isActive(%this) && %this.loop == "" && GameBase::isPowered(%this)  && getSimTime() >= %this.delayTime) {
				if(Moveable::getPosition(%this) == 0 && (%this.triggered == "" || %this.delayTime + 1.5 < getSimTime()) && %this.triggerHit == "") { 
					%this.delayTime = getSimTime() + 2.0;
					%this.triggered = 1;
				}
				if( getSimTime() >= %this.delayTime ) { 
					Elevator::trigger(%this);
					return true;
				}
			}
			else if(GameBase::getDataName(%object) == AntipersonelMine || GameBase::getDataName(%object) == FireMine ) 
				AntipersonelMine::onCollision(%object,%this);
		}
	return false;
}


function Elevator::onBlocker(%this,%obj)
{
	// Will get called 30/s for blocking objects
	//echo("Moveable::onBlocker: " @ %this @ " " @ %obj);
	GameBase::applyDamage(%obj,$CrushDamageType,0.01,
		GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
}

function Elevator::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
}

function Elevator::onDisabled(%this)
{
	GameBase::setActive(%this,false);
   Moveable::stop(%this);
}

function Elevator::onDestroyed(%this)
{
	GameBase::setActive(%this,false); 		
   Moveable::stop(%this);
}	

function Elevator::checkDelay(%this)
{
	if (getSimTime() >= %this.delayTime) 
		Elevator::onMove(%this);
	else
		schedule("Elevator::checkDelay(" @ %this @ ");",1,%this);
}

function Elevator::onTrigEnter(%this,%object,%trigger)
{
}

function Elevator::onTrigLeave(%this,%object,%trigger)
{

}

function Elevator::onTrigger(%this,%object,%trigger)
{
	if(%this.triggerHit == "" && %this.delayTime < getSimTime()) {
		%this.triggerHit = 1;
		%this.status = "up";
	   if(!Elevator::onCollision(%this,%object))
	  		%this.triggerHit = "";
	}
}
