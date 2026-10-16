function Teleporter::onAdd(%this)
{
	Teleporter::addToNetwork(%this);
	GameBase::playSequence(%this,1,"busy");
	schedule("GameBase::stopSequence("@%this@","@1@");",1.5);
	schedule("GameBase::playSequence("@%this@","@0@","@"idle"@");",1.5);
	$Aeon::InteractFunc[%this] = "Teleporter";
	schedule(%this@".ready = 1;",1.8,%this);
	Shakeable::addToNetwork(%this);
}

function Teleporter::onDelete(%this)
{
	Teleporter::removeFromNetwork(%this);
	Shakeable::removeFromNetwork(%this);
}

function Teleporter::strNetwork()
{
	%str = "";
	for(%i = 0; $Aeon::TeleNetwork[%i] != ""; %i++)
		%str = %str@$Aeon::TeleNetwork[%i]@" ";
	return %str;
}

function Teleporter::addToNetwork(%this)
{
	%num = Teleporter::getAddr(%this);
	$Aeon::TeleNetwork[%num] = %this;
}

function Teleporter::getAddr(%tele)
{
	for(%i = 0; $Aeon::TeleNetwork[%i] != ""; %i++) {
		if($Aeon::TeleNetwork[%i] == %tele)
			return %i;
	}
	return %i;
}

function Teleporter::removeFromNetwork(%tele)
{
	%found = false;
	for(%i = 0; $Aeon::TeleNetwork[%i] != ""; %i++) {
		if($Aeon::TeleNetwork[%i] == %tele) {
			//$Aeon::TeleNetwork[%i] = $Aeon::TeleNetwork[%i+1];
			%found = true;
		}
		if(%found == true)
			$Aeon::TeleNetwork[%i] = $Aeon::TeleNetwork[%i+1];
	}
	$Aeon::TeleNetwork[%i] = "";
}

function Teleporter::checkTarget(%this,%object)
{
	if(GameBase::getLOSInfo(%this,1,$Pi/2@" 0 0 ")) {
		%obj = $los::object;
		%lPs = $los::position;
		$los::object = "";
		$los::position = "";
		if(%obj == %object)
			return true;
	}
	%clientId = Player::getClient(%object);
	if(%clientId.teleMenu == true)
		remoteScoresOff(%clientId);
	else {
		%clientId.teleMenu = "";
		%clientId.lastTeleMenu = getSimTime();		
	}
	return false;
}

function Teleporter::onInteract(%this,%player)
{
	%check = Teleporter::onCollision(%this,%player,true);
	if(%check != true) {
		if(%check != time)
			bottomPrint(Player::getClient(%player),"<jc><f3>You must stand on the pad to use the Teleporter.",2);	
		else
			bottomPrint(Player::getClient(%player),"<jc><f3>Please try again later...",2);
	}
}

function Teleporter::onCollision(%this,%object,%manual)
{
	%clientId = Player::getClient(%object);
	%id = Aeon::getAeonID(%clientId);
	if(%clientId < 2049)
		return;
	if(%this.ready && %manual == true) {
		if(GameBase::getLOSInfo(%this,1,$Pi/2@" 0 0 ")) {
			%obj = $los::object;
			%lPs = $los::position;
			$los::object = "";
			$los::position = "";
			if(%obj == %object) {
				%go = Teleporter::canUse(%this);
				if(%go == true) {
					if(GameBase::getLOSInfo(%this,1,$Pi/2@" 0 0 ")) {
						%obj = $los::object;
						%lPs = $los::position;
						$los::object = "";
						$los::position = "";
						if(%obj == %object) {
							if(!%clientId.teleMenu && getSimTime()-%clientId.lastTeleMenu > 2.0) {
								%prop = %this.prop;
								if(%id == Property::getOwner(%prop) || Property::hasPermission(%clientId,%prop,"tele")) {
									bottomPrint(%clientId,"<jc><f1>All checks go!",5);
									Teleporter::initMenu(%clientId,"",%this);
									return true;
								}
								else
									bottomPrint(%clientId,"<jc><f3>You don't have permission to use this Teleporter!",5);
							}
							else
								schedule("Teleporter::checkTarget("@%this@","@%object@");",1.0);
							return time;
						}
						return false;
					}
					return false;
				}
				else if(%go == rot)
					bottomPrint(%clientId,"<jc><f3>This Teleporter cannot Operate at this Angle!",5);
				else
					bottomPrint(%clientId,"<jc><f3>This Teleporter needs more room to operate!",5);
				return false;
			}
			return false;
		}
		return false;
	}
	return false;
}

function Teleporter::initMenu(%clientId,%start,%tele1)
{
	%clientId.teleMenu = true;
	%id = Aeon::getAeonID(%clientId);
	if(!%start)
		%start = -1;
	Client::buildMenu(%clientId,"Teleporter Destination: ","TeleDest",true);
	for(%i = 0; $Aeon::TeleNetwork[%start+1] != "" && %i < 6; %i++) {
		%tele2 = $Aeon::TeleNetwork[%start++];
		if(Property::hasPermission(%clientId,%tele2.prop,"tele")) {
			%id2 = Property::getOwner(%tele2.prop);
			if(%id2 == "Central")
				%who = "Central";
			else if(%id2 == %id)
				%who = "Your";
			else {
				Aeon::clientInfo(%id2);
				%who = $Aeon::ClientInfo[%id2,Name]@"'s";
			}
			%name = %who@" Teleporter";
			if(%i < 5)
				Client::addMenuItem(%clientId,%i@%name,%tele1@" tele "@%start);
			else {
				if($Aeon::TeleNetwork[%i+1] != "") {
					if(%start > 6)
						Client::addMenuItem(%clientId,%i@"Back...",%tele1@" back "@%start);
					else
						Client::addMenuItem(%clientId,%i@"Next...",%tele1@" next "@%start);
				}
				else
					Client::addMenuItem(%clientId,%i@%name,%tele1@" tele "@%start);
			}
		}
		else
			%i--;
	}
	Client::addMenuItem(%clientId,%i@"Cancel",%tele1@" exit");
}

function processMenuTeleDest(%clientId,%opt)
{
	%id = Aeon::getAeonId(%clientId);
	%tele1 = getWord(%opt,0);
	%op1 = getWord(%opt,1);
	%op2 = getWord(%opt,2);
	%clientId.teleMenu = "";
	%clientId.lastTeleMenu = getSimTime();
	if(%op1 == "exit") {
		remoteScoresOff(%clientId);
		return;
	}
	else if(%op1 == "next") {
		Teleporter::initMenu(%clientId,%op2,%tele1);
		return;
	}
	else if(%op1 == "back") {
		Teleporter::initMenu(%clientId,%op2-10,%tele1);
		return;
	}
	else if(%op1 == "tele") {
		%tele2 = $Aeon::TeleNetwork[%op2];
		if(%tele2 && !Property::hasPermission(%clientId,%tele2.prop,"tele")) return; // PORT (2026-10-12): same test the destination list uses
		if(Teleporter::checkTarget(%tele1,Client::getOwnedObject(%clientId))) {
			if(%tele2)
				Teleporter::transfer(%tele1,%tele2,%clientId);
			else
				bottomPrint(%clientId,"<jc><f3>Destination Address currently disabled!",5);
		}
		else
			bottomPrint(%clientId,"<jc><f3>You have wandered off of the Teleporter Pad!",5);
	}
	else {
		
	}
}

function Teleporter::transfer(%tele1,%tele2,%clientId)
{
	GameBase::playSequence(%tele1,1,"busy");
	GameBase::playSequence(%tele2,1,"busy");
	%pos1 = GameBase::getPosition(%tele1);
	%pos2 = GameBase::getPosition(%tele2);
	%posP = GameBase::getPosition(%clientId);
	%posD = Vector::add(%pos2,Vector::sub(%posP,%pos1));
	Teleporter::sparkle(%posP);
	GameBase::setPosition(%clientId,%posD);
	if(Vector::getDistance(%posP,%posD) > 2.0)
		Teleporter::sparkle(%posD);
	schedule("GameBase::pauseSequence("@%tele1@",1);",2.0,%tele1);
	schedule("GameBase::pauseSequence("@%tele2@",1);",2.0,%tele2);
}

function Teleporter::sparkle(%pos)
{
	Projectile::spawnProjectile("TeleFX","0 0 1 0 0 0 0 0 1 "@Vector::add(%pos,"0 0 1"),2048,"0 0 0");
}

function Teleporter::getTeleporter(%prop)
{
	%gName = "Property #"@%prop;
	%group = nameToID("MissionCleanup\\Property\\"@%gName);
	if(%group != -1) {
		for(%i = 0; %i < Group::objectCount(%group); %i++) {
			%obj = Group::getObject(%group,%i);
			%name = GameBase::getDataName(%obj);
			if(%name == "teleporter")
				return %obj;
		}
		return false;
	}
	else
		return false;
}

function Teleporter::canUse(%this)
{
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%loc = Vector::add(%pos,Vector::getFromRot(Vector::add(%rot,$Pi/2@" 0 0"),1));
	%set = newObject("set",SimSet);
	if(containerBoxFillSet(%set,$StaticObjectType|$SimInteriorObjectType,%loc,1.0,1.0,3.0,0.0)) {
		if(Group::objectCount(%set) > 0) {
			for(%i = 0; %i < Group::objectCount(%set); %i++) {
				%obj = Group::getObject(%set,%i);
				%oPs = GameBase::getPosition(%obj);
				%dist = Vector::getDistance(%loc,%oPs);
				if(%obj != %this && %dist < 2) {
					echo(%obj);
					return false;
				}
			}
		}
	}
	deleteObject(%set);
	for(%i = 0; %i < 2; %i++) {
		if(Calc::abs(getWord(%rot,%i)) > 0.3)
			return rot;
	}
	return true;
}

function Teleporter::onEnabled(%this)
{
	GameBase::playSequence(%this,0,"idle");
}

function Teleporter::onDisabled(%this)
{
	GameBase::stopSequence(%this,0);
	GameBase::stopSequence(%this,1);
}

function Teleporter::onActivate(%this)
{
	if(%this.deployed == 1) {
		GameBase::playSequence(%this,1,"busy");
	}
	else
		GameBase::setActive(%this,false);
}
