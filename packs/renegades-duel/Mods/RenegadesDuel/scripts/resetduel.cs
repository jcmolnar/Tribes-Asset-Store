function Lightning::damageTarget(%target, %timeSlice, %damPerSec, %enDrainPerSec, %pos, %vec, %mom, %shooterId)
{
   %damVal = %timeSlice * %damPerSec;
   %enVal  = %timeSlice * %enDrainPerSec;

   GameBase::applyDamage(%target, $ElectricityDamageType, %damVal, %pos, %vec, %mom, %shooterId);

   %energy = GameBase::getEnergy(%target);
   %energy = %energy - %enVal;
   if (%energy < 0) {
      %energy = 0;
   }
   GameBase::setEnergy(%target, %energy);
}

// PORT: the three item handlers a duel map replaces, as Renegades Classic 1.1c item.cs defines them
// (the archive restored the stock MineAmmo::onUse and never restored the other two).
function MineAmmo::onUse(%player,%item) {
   if($matchStarted) {
      if(%player.throwTime < getSimTime() ) {
         %armor = Player::getArmor(%player);
         %client = Player::getClient(%player);
         if($TeamItemCount[GameBase::getTeam(%client) @ "mineammo"] < $TeamItemMax["mineammo"]) $TeamItemCount[GameBase::getTeam(%client) @ "mineammo"]++;
         else {
            Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
            return;
         }
         Player::decItemCount(%player,%item);
         if (%armor == "dmarmor" || %armor == "dmfemale") %obj = newObject("","Mine","DMMine");
         else {
            %obj = newObject("","Mine","antipersonelMine");
            GameBase::setTeam (%obj,GameBase::getTeam (%client));
         }
         addToSet("MissionCleanup", %obj);
         GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
         %player.throwTime = getSimTime() + 0.5;
      }
   }
}

function Grenade::onUse(%player,%item) {
   if($matchStarted) {
      if(%player.throwTime < getSimTime() ) {
         %armor = Player::getArmor(%player);
         if (%armor == "larmor" || %armor == "lfemale") {
            %clTeam = GameBase::getTeam(Player::getClient(%player));
            if($TeamItemCount[%clTeam @ "holomine"] < $TeamItemMax["holomine"]) {
               $TeamItemCount[%clTeam @ "holomine"]++;
               %obj = newObject("","Mine","HoloMine");
            }
            else {
               Client::sendMessage(Player::getClient(%player),0,"Deployable Item limit reached for Hologram Mines");
               return;
            }
         }
         if(%armor == "earmor" || %armor == "efemale") %obj = newObject("","Mine","Shockgrenade");
         if (%armor == "sarmor" || %armor == "sfemale") %obj = newObject("","Mine","Firebomb");
         if (%armor == "spyarmor" || %armor == "spyfemale") {
            Client::sendMessage(Player::getClient(%player),1, "Plastique Explosive will explode in 10 seconds");
            %obj = newObject("","Mine","Nukebomb");
         }
         if (%armor == "marmor" || %armor == "mfemale") %obj = newObject("","Mine","Handgrenade");
         if (%armor == "aarmor" || %armor == "afemale") %obj = newObject("","Mine","Tranqgrenade");
         if (%armor == "barmor" || %armor == "bfemale") %obj = newObject("","Mine","Concussion");
         if (%armor == "darmor") %obj = newObject("","Mine","Mortarbomb");
         if (%armor == "dmarmor" || %armor == "dmfemale") %obj = newObject("","Mine","Handgrenade");
         Player::decItemCount(%player,%item);
         addToSet("MissionCleanup", %obj);
         %client = Player::getClient(%player);
         GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
         %player.throwTime = getSimTime() + 0.5;
         GameBase::setTeam (%obj,GameBase::getTeam (%client));
      }
   }
}

function Beacon::onUse(%player,%item) {
   if(%player.station) return;
   %armor = Player::getArmor(%player);
   %clientId = Player::getClient(%player);
   if (%armor == "barmor" || %armor == "bfemale") {
      if ($stimTime[%clientId] == 0) {
         Renegades_startStim(%clientId, %player);
         Player::decItemCount(%player, %item);
      }
      else return;
   }
   if (%armor == "larmor" || %armor == "lfemale") {
      SniperJammer(%clientId, %player, %item);
   }
   if(%armor == "earmor" || %armor == "efemale") EngCamera(%clientId, %player, %item);
   if (%armor == "sarmor" || %armor == "sfemale") {
      ScoutSensor(%clientId, %player, %item);
   }
   if (%armor == "spyarmor" || %armor == "spyfemale") {
      DeploySatchel(%clientId, %player, %item);
   }
   if (%armor == "marmor" || %armor == "mfemale") {
      if($matchStarted) {
         if(%player.throwTime < getSimTime() ) {
            %obj = newObject("","Mine","Booster");
            addToSet("MissionCleanup", %obj);
            %client = Player::getClient(%player);
            GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
            %player.throwTime = getSimTime() + 0.5;
            Client::sendMessage(Player::getClient(%player),0, "You use a Speed Booster.");
            Player::decItemCount(%player,%item);
         }
      }
   }
   if (%armor == "aarmor" || %armor == "afemale" || %armor == "dmarmor"|| %armor == "dmfemale") {
      Renegades_startCloak(%clientId, %player);
      Player::decItemCount(%player,%item);
   }
   if (%armor == "darmor"){
      Renegades_startShield(%clientId, %player);
      Player::decItemCount(%player,%item);
   }
}


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
			else if(GameBase::getDataName(%object) == AntipersonelMine) 
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

function Admin::changeMissionMenu(%clientId) { 
	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = 1; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > 8) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more 8"); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
			%index++; 
		} 
	}
} 

function processMenuCMType(%clientId, %options)
{

   if(getWord(%options, 0) == "more") { %first = getWord(%options, 1); processMenuCMoo(%clientId, %first); return; }

   %curItem = 0;
   %option = getWord(%options, 0);
   %first = getWord(%options, 1);
   Client::buildMenu(%clientId, "Pick Mission", "cmission", true);
   
   for(%i = 0; (%misIndex = getWord($MLIST::MissionList[%option], %first + %i)) != -1; %i++)
   {
      if(%i > 6)
      {
         Client::addMenuItem(%clientId, %i+1 @ "More missions...", "more " @ %first + %i @ " " @ %option);
         break;
      }
      Client::addMenuItem(%clientId, %i+1 @ $MLIST::EName[%misIndex], %misIndex @ " " @ %option);
   }
}

function processMenuCMoo(%clientId, %first) {

	Client::buildMenu(%clientId, "Select Mission Type", "cmtype", true); 
	%index = 1; 
	for(%type = %first; %type < $MLIST::TypeCount; %type++) {
		if($MLIST::Type[%type] != "Training") { 
			if(%index == 8 && $MLIST::TypeCount > %first + %index) { 
				Client::addMenuItem(%clientId, %index @ "View More Types...", "more " @ %first + %index); 
				break; 
			}
			Client::addMenuItem(%clientId, %index @ $MLIST::Type[%type], %type @ " 0"); 
			%index++; 
		} 
	}
}

