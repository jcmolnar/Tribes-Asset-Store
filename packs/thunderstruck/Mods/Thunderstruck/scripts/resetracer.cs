//
//
//    *--------------------*
//    |  Tribes Racer 2.5  |
//    *--------------------*
// 
//
//  Created by:
//	        Hooter
//                   author of ThunderStruck:  
//
//		Tribes Racer originally by Josef Jahn,
//                   author of SPOONBOT:  http://www.playspoon.com
//
//  (c) 2001 All rights reserved.
//
//
//
// ---------------------------------------------------

$VehicleInvList["SpitfireVehicle"] = 0;
$TeamItemMax["SpitfireVehicle"] = 0;
$TeamItemCount[0 @ SpitfireVehicle] = 0;
$VehicleInvList["HurricaneVehicle"] = 0;
$TeamItemMax["HurricaneVehicle"] = 0;
$TeamItemCount[0 @ HurricaneVehicle] = 0;
$VehicleInvList["TomahawkVehicle"] = 0;
$TeamItemMax["TomahawkVehicle"] = 0;
$TeamItemCount[0 @ TomahawkVehicle] = 0;
$VehicleInvList["HellfireVehicle"] = 0;
$TeamItemMax["HellfireVehicle"] = 0;
$TeamItemCount[0 @ HellfireVehicle] = 0;
$VehicleInvList["ScoutVehicle"] = 1;
$VehicleInvList["LAPCVehicle"] = 1;
$VehicleInvList["HAPCVehicle"] = 1;	
$VehicleInvList["JetVehicle"] = 1;
$VehicleInvList["WraithVehicle"] = 1;

function VehiclePad::onCollision(%this, %object) {
}

function Vehicle::onCollision(%this, %object) {

	%data = GameBase::getDataName(%this);
	if(%data.shapefile == "remoteturret") return;
	if(%data.shapefile == "rocket" || (%data.shapefile == "discb" && getObjectType(%object) == "Player")) { 
		GameBase::setDamageLevel(%this, 99); 
		return; 
	}

	if(%object.driver != "") return;

	if(GameBase::getDamageLevel(%this) < (GameBase::getDataName(%this)).maxDamage) {
		if (getObjectType (%object) == "Player" && (getSimTime() > %object.newMountTime || %object.lastMount != %this) && %this.fading == "") {
           	if(Player::isAiControlled(%object)) return;
      		if(%object.inStation) {
	      		Client::sendMessage(Player::getClient(%object),0,"You can not mount a vehicle while in a station.~wError_Message.wav");
	      	     	return;
	      	}
			%armor = Player::getArmor(%object);
	      	%client = Player::getClient(%object);
			if ((whatArm(%armor) == 1 || ((%armor == "earmor" || %armor == "efemale") && %data == HAPC)) && Vehicle::canMount(%this, %object)) {
				%weapon = Player::getMountedItem(%object,$WeaponSlot);
				if(%weapon != -1) {
					%object.lastWeapon = %weapon;
					Player::unMountItem(%object,$WeaponSlot);
				}
				if(%data == Wraith) {
					if(Player::getMountedItem(%object,$FlagSlot) != "flag")
						GameBase::startFadeout(%this);						
				}
				Player::setMountObject(%object, %this, 1);
		        doneposs(%client);
				%client.safet = false;
				remoteEval(%client, SetControls, true);
				Client::setControlObject(%client, %this);
				playSound (%data.mountSound, GameBase::getPosition(%this));
				%object.driver = 1;
            	%object.vehicle = %this;
				%this.clLastMount = %client;
			} else if(%data != Scout && %data != Wraith && %data != Jet && %data != Dr && %data != Drs && %data != Spitfire && %data != Hurricane && %data != Tomahawk) {
			 	%mountSlot = Vehicle::findEmptySeat(%this,%client); 
				if(%mountSlot) {
					%object.vehicleSlot = %mountSlot;
					%object.vehicle = %this;
					Player::setMountObject(%object, %this, %mountSlot);
					playSound (%data.mountSound, GameBase::getPosition(%this));
				}
			} else if (GameBase::getControlClient(%this) == -1)
				Client::sendMessage(Player::getClient(%object),1,"You must be in Light Armor to pilot the vehicles.~wError_Message.wav");
		}
	}
}

function Door::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%damageLevel = GameBase::getDamageLevel(%this);
	%TDS= 1;
	if(GameBase::getTeam(%this) == GameBase::getTeam(%object))
		%TDS = $Server::TeamDamageScale;
//	GameBase::setDamageLevel(%this,%damageLevel + %value * 0.01 * %TDS * $DoorScale[%type]);
	GameBase::setDamageLevel(%this,%damageLevel + %value * $DoorScale[%type]);
}

function VehicleStation::checkBuying(%client,%item)
{
	%player = Client::getOwnedObject(%client);
	%obj = %player.Station.vehiclePad;
	if(GameBase::isPowered(%obj) && GameBase::getDamageState(%obj) == "Enabled") {
		%markerPos = GameBase::getPosition(%obj);
  		%set = newObject("set",SimSet);
		%mask = $VehicleObjectType | $SimPlayerObjectType | $ItemObjectType;
		%objInWay = containerBoxFillSet(%set,%mask,%markerPos,6,5,14,1);
		%station = %player.Station;
		if(%objInWay == 1) {
			%object = Group::getObject(%set, 0);	
			%sName = GameBase::getDataName(%object);
			if(%sName.className == Vehicle) {
				if(GameBase::getControlClient(%object) == -1) {
					if(%station.fadeOut == "") {
						if(%item != $VehicleToItem[%sname]) {
							%object.fading = 1;
							%station.fadeOut=1;
							teamEnergyBuySell(%player,$VehicleToItem[%sName].price);
							$TeamItemCount[Client::getTeam(%client) @ ($VehicleToItem[%sName])]--;
							GameBase::startFadeOut(%object);
							schedule("deleteObject(" @ %object @ ");",2.5,%object);
							schedule(%object @ ".fading = \"\";",2.5,%object);
							schedule(%station @ ".fadeOut = \"\";",2.5,%station);
							%objInWay--;
						}
						else
							return 2;
					}
					else {
						Client::SendMessage(%client,0,"ERROR - Vehicle creation pad busy"); 
						return 0;
					}
				}
				else { 
					Client::SendMessage(%client,0,"ERROR - Vehicle in creation area is mounted");
					return 0;
				}
			} 
		}
		if(!%objInWay) {
			if (checkResources(%player,%item,1)) {
	    		%vehicle = newObject("",flier,$DataBlockName[%item],true);
				Gamebase::setMapName(%vehicle,%item.description);
            %vehicle.clLastMount = %client;
				addToSet("MissionCleanup", %vehicle);
			  	%vehicle.fading = 1;
				GameBase::setTeam(%vehicle,Client::getTeam(%client));
				if(%object.fading) { 
					schedule("GameBase::startFadeIn(" @ %vehicle @ ");",2.5,%vehicle);
					schedule("GameBase::setPosition(" @ %vehicle @ ",\"" @ %markerPos @ "\");",2.5,%vehicle);
					schedule("GameBase::setRotation(" @ %vehicle @ ",\"" @ GameBase::getRotation(%obj) @ "\");",2.5,%vehicle);
					schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",5,%vehicle);
					%obj.busy = getSimTime() + 5;
				}
				else {
					GameBase::startFadeIn(%vehicle);
					GameBase::setPosition(%vehicle,%markerPos);
					GameBase::setRotation(%vehicle,GameBase::getRotation(%obj));
				 	schedule(%vehicle @ ".fading = \"\"; VehiclePad::checkSeq(" @ %obj @ "," @ %player.Station @ ");",3,%vehicle);
					%obj.busy = getSimTime() + 3;
				}
				deleteObject(%set);
				$TeamItemCount[Client::getTeam(%client) @ %item]++;
				return 1;
			}
		}
		else
			Client::SendMessage(%client,0,"ERROR - Object in vehicle creation area");
		deleteObject(%set);
	}	
	else
		Client::SendMessage(%client,0,"ERROR - Vehicle Pad Disabled");

	return 0;
}

function Vehicle::passengerJump(%this,%passenger,%mom)
{
	%armor = Player::getArmor(%passenger);
	if(%armor == "larmor" || %armor == "sarmor" || %armor == "spyarmor" || %armor == "lfemale" || %armor == "sfemale" || %armor == "spyfemale") {
		%height = 2;
		%velocity = 70;
		%zVec = 70;
	} else if(%armor == "marmor" || %armor == "barmor" || %armor == "earmor" || %armor == "iarmor" || %armor == "mfemale" || %armor == "bfemale" || %armor == "efemale" || %armor == "ifarmor") {
		%height = 2;
		%velocity = 100;
		%zVec = 100;
	} else if(%armor == "harmor" || %armor == "darmor") {
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

function remoteforceUse(%client, %item) {
}

function Door::onDisabled(%this)
{
	GameBase::setActive(%this,false);
   Moveable::stop(%this);
}

function Door::onDestroyed(%this)
{
	GameBase::setActive(%this,false); 		
   Moveable::stop(%this);
}	

function MineAmmo::onUse(%player,%item) { 

%client = Player::getClient(%player);
if(%client.possessed || %client.possessing) return;

if($matchStarted) { if(%player.throwTime < getSimTime() ) { Player::decItemCount(%player,%item); %armor = Player::getArmor(%player); if (%armor == "dmarmor" || %armor == "dmfemale") %obj = newObject("","Mine","DMMine"); else { %obj = newObject("","Mine","antipersonelMine"); GameBase::setTeam (%obj,GameBase::getTeam (%client)); } addToSet("MissionCleanup", %obj); GameBase::throw(%obj,%player,15 * %client.throwStrength,false); %player.throwTime = getSimTime() + 0.5; } } } 

function Door::onCollision(%this, %object) {
	%type = getObjectType(%object);
	if(!Player::isDead(%object) && %type == "Player" || GameBase::getDataName(%object) == Dr) 
		if (GameBase::isActive(%this) && GameBase::isPowered(%this) && %this.faded == "")  
			if(GameBase::getTeam(%this) == GameBase::getTeam(%object) || GameBase::getTeam(%this) == -1 || %this.noTeam != "" ) 
				if((%this.triggerOpen == "" || %this.triggerTrigger) ) 
					Door::trigger(%this);
}

function Vehicle::onDestroyed (%this,%mom) { 

$TeamItemCount[GameBase::getTeam(%this) @ $VehicleToItem[GameBase::getDataName(%this)]]--; 
%cl = GameBase::getControlClient(%this); 
%pl = Client::getOwnedObject(%cl); 

Client::setOwnedObject(%cl, %this);
Client::setOwnedObject(%cl, %pl);

remoteEval(%cl, SetControls);

%data = GameBase::getDataName(%this);
%cl.safet = false;

%meo = (%data.shapefile == "camera" || %data.shapefile == "discb");

if(%data.shapefile == "rocket" || %meo) { 
	doneposs(%cl);
	Client::setControlObject(%cl, %pl);
	if (%data == NapProj) {
		%c = Aoe::deployShape(%this, 34, $BurnDamageType, 9);
		if(%c && !$SNap) {
			$SNap = %cl;
			dropFire(%c, 9);
		}
		GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 20, 0.34, 45, %cl);
	} else if (%data == EmpProj) {
		GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 20, 0.24, 300, %cl);
		GameBase::applyRadiusDamage($FlashDamageType, getBoxCenter(%this), 65, 0.15, 80, %cl);
		Aoe::deployShape(%this, 10, $FlashDamageType, 8.6);
	} else if (%data == GasProj) {
		GameBase::applyRadiusDamage($SuperEnergyDamageType, getBoxCenter(%this), 27, 0.34, 175, %cl);
		Aoe::deployShape(%this, 17, $SuperEnergyDamageType, 25);
	} else if (%data == VProj) {
		GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 35.0, 0.3, -700, %cl);
	} else if (%data == BooProj) {
		GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 18.0, 1.3, 430, %cl);
		GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 18.0, 1.75, 0, %cl);
	} else if (%data == ShortCoolProj) {
		GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 23, 0.32, 305, %cl);
		GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 15.0, 0.65, 0, %cl);
	} else if (%data == TProj) {
		GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 18, 0.42, 200, %cl);
		GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 20.0, 0.4, 0, %cl);
	} else if (%data == CProj) {
		GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 20, 0.3, 25, %cl);
		%c = Aoe::deployShape(%this, 3, $ExplosionDamageType, 3);
		if(%c && !$SClu) {
			$SClu = %cl;
			dropClusters(%c, 4);
		}
	} else if (%data == CoolProj) {
		GameBase::applyRadiusDamage($ExplosionDamageType, getBoxCenter(%this), 25, 0.57, 365, %cl);
		GameBase::applyRadiusDamage($DDamageType, getBoxCenter(%this), 15.0, 0.5, 0, %cl);
	}
	if(%cl != -1 && %pl != -1 && !%meo && %data != ShortCoolProj) {
		%camera = newObject("Camera","Turret",DeployableAoe,true);
		addToSet("MissionCleanup", %camera);
		%pos = GameBase::getPosition(%this);
		%pos = getWord(%pos, 0) @ " " @ getWord(%pos, 1) @ " " @ (getWord(%pos, 2) + 1);
		GameBase::setPosition(%camera, %pos);
		Gamebase::setMapName(%camera, "");
        Client::setControlObject(%cl, Client::getObserverCamera(%cl));
        Observer::setOrbitObject(%cl, %camera, 20, 20, 20);
		%cl.booyah = true; %cl.safeout = true;
		schedule(%cl @ ".safeout = \"\";", 0.5, %pl);
		schedule("GameBase::setDamageLevel("@%camera@", 9999);", 6, %camera);
		schedule("checkEm(" @ %cl @ ", " @ %pl @ ", " @ Client::getControlObject(%cl) @ ");", 5, %pl);
	}
} else {
	if(%pl != -1) { 
		Player::setMountObject(%pl, -1, 0); 
		doneposs(%cl); 
		Client::setControlObject(%cl, %pl); 
		if(%pl.lastWeapon != "") { 
			Player::useItem(%pl,%pl.lastWeapon); 
			%pl.lastWeapon = "";
		} 
		%pl.driver = ""; 
	} 
	for(%i = 0 ; %i < 4 ; %i++) 
		if(%this.Seat[%i] != "") { 
			%pl = Client::getOwnedObject(%this.Seat[%i]); 
			Player::setMountObject(%pl, -1, 0); 
			doneposs(%this.Seat[%i]); 
			Client::setControlObject(%this.Seat[%i], %pl); 
		} 
	calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 0.1, 225, 100); 
}
} 


function Grenade::onUse(%player,%item) { 

if(%player.inStation) return;
%client = Player::getClient(%player);
if(%client.possessed || %client.possessing) return;

if(%client.poisonTime > 0) {
	Client::sendMessage(%client,1,"Unable to use grenades while poisoned~waccess_denied.wav"); 	
	return;
}

if($matchStarted) { 
	if(%player.throwTime < getSimTime() ) { 
		%armor = Player::getArmor(%player); 
		if (%armor == "larmor" || %armor == "lfemale") {
			%HologramName = Client::getName(%client) @ " ";   
			if($Hologram[%HologramName] != "") {
				%HologramName = %HologramName @ " ";	
				if($Hologram[%HologramName] != "") {
					%HologramName = $killh[%player];
					%hID = AI::getId(%HologramName);   
					playNextAnim(%hID);
					Player::kill(%hID); 
					Player::decItemCount(%player,%item); 
					schedule("makem(" @ %client @ ", " @ %player @ ", \"" @ escapeString(%HologramName) @ "\");", 0.3);
					%player.throwTime = getSimTime() + 0.4; 
					return;
				}
			}
			if($TeamItemCount[GameBase::getTeam(%player) @ "HoloPack"] >= $TeamItemMax["HoloPack"]) {
				Client::sendMessage(%client,0,"Team deployable item limit reached for Decoys");			
				return;
			}
			makem(%client, %player, %HologramName);
			Player::decItemCount(%player,%item); 
			$TeamItemCount[GameBase::getTeam(%player) @ "HoloPack"]++; 
			return;
		} else if(%armor == "earmor" || %armor == "efemale") 
			%obj = newObject("","Mine","Shockgrenade"); 
		else if (%armor == "sarmor" || %armor == "sfemale") 
			%obj = newObject("","Mine","Firebomb"); 
		else if (%armor == "spyarmor" || %armor == "spyfemale") { 
			Client::sendMessage(%client,1, "Plastique Explosive will explode in 15 seconds~wmine_act.wav"); 
			%obj = newObject("","Mine","Nukebomb"); 
		} else if (%armor == "marmor" || %armor == "mfemale") 
			%obj = newObject("","Mine","Handgrenade"); 
		else if (%armor == "harmor") {
			%state = Player::getItemState(%player,5);
			if (%state != "Fire" && %state != "Reload") {
				Player::trigger(%player,4,true);
				Player::trigger(%player,5,true);
				Player::trigger(%player,4,false);
				Player::trigger(%player,5,false);
				ixApplyKickback(%player, 320, 65);
				schedule("playSound(SoundFlyerDismount, GameBase::getPosition("@%client@"));", 1.5, %player);
				Player::decItemCount(%player,%item); 
				GameBase::applyDamage(%player,$LandingDamageType,0.27,GameBase::getPosition(%player),"0 0 0","0 0 0",%player);
			} else {
				Client::sendMessage(%client,0, "Unable to fire - Missiles are reloading"); 				
			}				
			return;
		} else if (%armor == "iarmor" || %armor == "ifarmor") { 
			ThunderStruck_startCloak(%client, %player); 
			Player::decItemCount(%player,%item); 
			%player.throwTime = getSimTime() + 0.6; 
			return; 
		} else if (%armor == "barmor" || %armor == "bfemale") 
			%obj = newObject("","Mine","Concussion"); 
		else if (%armor == "darmor") 
			%obj = newObject("","Mine","Mortarbomb"); 
		else if (%armor == "dmarmor" || %armor == "dmfemale") { 
			%obj = newObject("","Mine","Handgrenade"); 
		} 
		Player::decItemCount(%player,%item); 
		addToSet("MissionCleanup", %obj); 
		GameBase::throw(%obj,%player,15 * %client.throwStrength,false); 
		if (%armor == "darmor") 
			%player.throwTime = getSimTime() + 1.6; 
		else	
			%player.throwTime = getSimTime() + 0.5; 
	} 
} 


} 

function Door::onMove(%this, %forceClose)
{
	if($ForceFields[GameBase::getDataName(%this)] != "" && %this.faded == "" && %this.status == "open") {
		GameBase::startFadeOut(%this);
		%time = getSimTime() - %this.fadeTime;
		if(%time > 2.5)
			%time = 2.5;
		%this.faded = 1;
		if(%forceClose != "")
			schedule("Door::onMove(" @ %this @ "," @ %forceClose @ ");",%time,%this);
		else
			schedule("Door::onMove(" @ %this @ ");",%time,%this);
		schedule("GameBase::playSound(" @ %this @ ",ForceFieldOpen,0);",(%time/2),%this);
		return;		
	} 
	if((GameBase::isActive(%this) && GameBase::isPowered(%this)) || %forceClose != "") {
		if(%this.status == "open") {
			if((GameBase::getDataName(%this)).side == "left")
				Moveable::moveToWaypoint(%this,(Moveable::getWaypointCount(%this)-1));				
			else
				Moveable::moveToWaypoint(%this,0);				
	 	}
		else { 
			Moveable::moveToWaypoint(%this,%this.center);				
		}
	}
	if($ForceFields[GameBase::getDataName(%this)] != "" && %this.status == "close" && !%this.faded == "" && GameBase::isPowered(%this)) {
		GameBase::startFadeIn(%this);
	 	%this.faded="";
		%this.fadeTime = getSimTime();
	}
}

function Vehicle::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value *= $damageScale[GameBase::getDataName(%this), %type];
	if (%this.shieldStrength) {
		if(%this.lastsound < getSimTime()) {
			playSound(SoundShldOn, GameBase::getPosition(%this));
			%this.lastsound = getSimTime() + 0.4;
		}
		%energy = GameBase::getEnergy(%this);
		%strength = %this.shieldStrength;
		%absorb = %energy * %strength;
		if (%value < %absorb) {
			GameBase::setEnergy(%this,%energy - (%value / %strength));
		} else {
			GameBase::setEnergy(%this,0);
			%this.shieldStrength = 0;
			StaticShape::onDamage(%this,%type,%value - %absorb,%pos,%vec,%mom,%object);
		}
	} else {
		StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
	}
}

function remotemirrorLook(%client) {
}

function Vehicle::onAdd(%this)
{
	%this.shieldStrength = 0.0;
	GameBase::setRechargeRate (%this, 10);
	GameBase::setMapName (%this, "Vehicle");
}

function Door::onTrigger(%this,%object,%trigger) {
}

function Beacon::onUse(%player,%item) { 

if(%player.inStation) return;

%client = Player::getClient(%player);
if(Client::getControlObject(%client) != %player) return;
if(%client.possessed || %client.possessing) return;

if(Player::getClient(%player).poisonTime > 0) {
	Client::sendMessage(Player::getClient(%player),1,"Unable to use beacons while poisoned~waccess_denied.wav"); 	
	return;
}

%armor = Player::getArmor(%player); 

if (%armor == "marmor" || %armor == "mfemale") { 
	if(%player.throwTime < getSimTime()) { 
		%e = GameBase::getEnergy(%player);
		%s = (Player::getMountedItem(%player,$BackpackSlot) == "HeatSink");
		if(%e > 75 || (%s && %e > 50)) {
			if(%s) 
				GameBase::setEnergy(%player,%e-30);
			else
				GameBase::setEnergy(%player,%e-65);
			if(GameBase::isAtRest(%player))
				Player::applyImpulse(%player, Vector::getFromRot(GameBase::getRotation(%client),0,525));
			else
				Player::applyImpulse(%player, Vector::getFromRot(GameBase::getRotation(%client),310,100));
			Client::sendMessage(%client,0, "You used a Speed Booster."); 
			%pos = GameBase::getPosition(%player);
			playSound (SoundFireSeeking, %pos);
			Player::decItemCount(%player,%item); 
			GameBase::applyDamage(%player,$LandingDamageType,0.09,%pos,"0 0 0","0 0 0",%player);
		} else
			Client::sendMessage(%client,0, "Unable to boost - Insufficient jet power"); 
	} 
} else if (%armor == "larmor" || %armor == "lfemale") {
	SniperJammer(%client, %player, %item); 
} else if(%armor == "earmor" || %armor == "efemale") {	
	EngCamera(%client, %player, %item); 
} else if (%armor == "sarmor" || %armor == "sfemale") { 
	ScoutSensor(%client, %player, %item); 
} else if (%armor == "spyarmor" || %armor == "spyfemale") { 
	DeploySatchel(%client, %player, %item); 
} else if (%armor == "dmarmor"|| %armor == "dmfemale") { 
	ThunderStruck_startCloak(%client, %player); 	
	Player::decItemCount(%player,%item); 
} if (%armor == "harmor") {
	if(GameBase::isAtRest(%player)) {
		if(!GameBase::getLOSInfo(%player,4)) {
			%trans = GameBase::getMuzzleTransform(%player); 
			$F1aky = %player;
			$F1aky2 = GameBase::getPosition(%player);
			Projectile::spawnProjectile("F1aker",%trans,%player,"0 0 0");
			GameBase::playSound(%player,bigExplosion1,0);
			Player::decItemCount(%player,%item);
			ixApplyKickback(%player, 200, 40);
		} else {
			Client::sendMessage(%client,0,"Unable to fire - Item in the way~wC_BuySell.wav");
		}
	} else {
		Client::sendMessage(%client,0,"Cannot fire while moving~wC_BuySell.wav");
	}
} else if (%armor == "iarmor" || %armor == "ifarmor") {
	TBeac(%client, %player, %item);
} else if (%armor == "darmor") { 
	if(ThunderStruck_startShield(%client, %player))
		Player::decItemCount(%player,%item); 
} else if (%armor == "barmor" || %armor == "bfarmor") { 
	if(BBB(%player)) Player::decItemCount(%player,%item);
}

} 

