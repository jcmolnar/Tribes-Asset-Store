$AI::randName[0] = "Mike";
$AI::randName[1] = "Tom";
$AI::randName[2] = "Bob";
$AI::randName[3] = "John";

function AI::init()
{
	%main = nameToID("MissionCleanup\\AI_Manager");
	if(%main == -1) {
		%main = newObject("AI_Manager",SimGroup,"Group");
		addToSet("MissionCleanup",%main);
	}
}

function AI::create(%aiName,%armorType,%spawnPos,%spawnRot)
{
	%group = nameToID("MissionCleanup\\AI_Manager\\@%aiName");
	if(%group == -1 && AI::spawn(%aiName,%armorType,%spawnPos,%spawnRot,%aiName,"male2") != "false" ) {
		%group = newObject(%aiName,SimGroup,"Group");
		addToSet("MissionCleanup\\AI_Manager",%group);
		AI::setVar(%aiName,iq,70);
		AI::setVar(%aiName,attackMode,1);
		AI::setVar(%aiName,triggerPct,0.03);
		AI::setAutomaticTargets(%aiName);
		%aiId = AI::getId(%aiName);
		GameBase::setTeam(%aiId,0);
		%aiPl = Client::getOwnedObject(%aiId);
		addToSet("MissionCleanup\\AI_Manager\\"@%aiName,%aiPl);
		Player::setItemCount(%aiPl,Unarmed,1);
		Player::useItem(%aiPl,Unarmed);
		AI::order(%aiName);
		%aiPl.isSitting = "";
		$AI::tempJumpCnt[%aiPl] = 0;
		return %aiPl;
	}
	return false;
}

function AI::onPeriodic(%aiName)
{
	%tPos = $AI::PeriodicPos[%aiName];
	%aiPl = AI::getPlayer(%aiName);
	%pPos = GameBase::getPosition(%aiPl);
	if(%tPos != "") {
		%dist = Vector::getDistance(%pPos,%tPos);
		%speed = Vector::speed(%aiPl);
		if(%speed < 1.0 && %dist > 3) {
			if($AI::tempAIJumpCount[%aiPl] < 2 && %aiPl.tempAIfindPath < 1 && Calc::abs(%dist - %aiPl.lastAIDist) < 0.2) {
				%tPos = Vector::add(%pPos,"0 0 5");
				Player::applyImpulse(%aiPl,"0 0 80");
				%forw = Vector::getFromRot(Vector::getRotAim(%pPos,$AI::PeriodicPos[%aiName]),20);
				$AI::tempAIJumpCount[%aiPl]++;
				schedule("Player::applyImpulse(\""@%aiPl@"\",\""@%forw@"\");",0.2,%aiPl);
			}
			else if(Calc::abs(%dist - %aiPl.lastAIDist) < 1) {
				%tPos = AI::findPath(%aiPl);
				$AI::tempAIJumpCount[%aiPl]++;
				if($AI::tempAIJumpCount[%aiPl])
					schedule(%aiPl@".tempAIfindPath = 0;",3.0,%aiPl);
				$AI::tempAIJumpCount[%aiPl] = 0;
				%aiPl.tempAIfindPath++;
			}
			%aiPl.isSitting = "";
		}
		else {
			if($AI::sitType[%aiName] == true && %aiPl.isSitting != true) {
				%aiPl.isSitting = true;
				Player::setAnimation(%aiPl,48);
			}
			%aiPl.tempAIJumpCount = 0;
		}
		AI::DirectiveWaypoint(%aiName,%tPos,1);
		%aiPl.lastAIDist = %dist;
	}
}

function AI::findPath(%aiPl,%ac)
{
	if(!%ac)
		%ac = 5;
	%last = %aiPl.lastAIPath;
	%pos = GameBase::getPosition(%aiPl);
	%x = getWord(GameBase::getRotation(%aiPl),4);
	for(%i = 0; %i < 2*$Pi-0.4; %i += (2*$Pi)/%ac) {
		%rot = "0 0 "@%x+%i;
		%vec1 = Vector::getFromRot(%rot,2);
		%path = Vector::add(%pos,%vec1);
		%path = Vector::add(%path,"0 0 2");
		if(!Vector::compare(%rot,%last,0.1) && GameBase::testPosition(%aiPl,%path))
			break;
	}
	%aiPl.lastAIPath = %rot;
	return %path;
}

function AI::order(%aiName)
{
	schedule("AI::organize(\""@%aiName@"\");",0.2);
}

function AI::organize(%aiName)
{
	%object = false;
	%manager = false;
	%group = nameToID("MissionCleanup");
	for(%i = 0; Group::getObject(%group,%i) != -1; %i++) {
		%obj = Group::getObject(%group,%i);
		if(getObjectType(%obj) == "AI::Manager")
			%manager = %obj;
		if(getObjectType(%obj) == "AI::Object" && %aiName != "")
			%object = %obj;
	}
	if(%manager != false)

		addToSet("MissionCleanup\\AI_Manager",%manager);
	if(%object != false)
		addToSet("MissionCleanup\\AI_Manager\\"@%aiName,%object);
}

function AI::getPlayer(%aiName)
{
	%aiId = AI::getId(%aiName);
	return Client::getOwnedObject(%aiId);
}

function AI::getName(%player)
{
	%group = nameToID("MissionCleanup\\AI_Manager");
	for(%i = 0; Group::getObject(%group,%i) != -1; %i++) {
		%obj = Group::getObject(%group,%i);
		%aiName = Object::getName(%obj);
		%aiId = AI::getId(%aiName);
		if(Client::getOwnedObject(%aiId) == %player)
			return %aiName;
	}
	return false;
}

function AI::onInteract(%aiPl,%player)
{
	%clientId = Player::getClient(%player);
	%aiName = AI::getName(%aiPl);
	%clientAI = AI::getId(%aiName);
 	//AI::DirectiveTarget(%aiName,"");
	//AI::setVar(%aiName,attackMode,1);
	Player::setAnimation(%aiPl,50);
}

//AI::DirectiveTarget(%aiName,%clientId);
//AI::callWithId("*",Player::setItemCount,blaster,1);
//AI::callWithId("*",Player::mountItem,blaster,0);
function AI::test(%clientId)
{
	%pos = GameBase::getPosition(%clientId);
	%rot = "0 0 0";
	%name = radnomItems(7,"Bob","Jim","Punk","Bill","Mark","Tim","Carter");
	%ai = AI::create(%name,"larmor",%pos,%rot);
}

function AI::onTargetLOSAcquired(%aiName,%clientId)
{
	echo("target LOS acquired "@%aiName@" : "@%clientId);
}

function AI::onTargetDied(%aiName,%clientId)
{
	echo("target LOS died "@%aiName@" : "@%clientId);
}                                 

function AI::onTargetLOSLost(%aiName,%clientId)
{
	echo("target LOS lost "@%aiName@" : "@%clientId);
}

function AI::onTargetLOSRegained(%aiName,%clientId)
{
	%aiPlayer = AI::getPlayer(%aiName);

	Player::setAnimation(%aiPlayer,50);

	echo("target LOS regained "@%aiName@" : "@%clientId);
}

function AI::onDroneKilled(%aiName)
{
	
}     
