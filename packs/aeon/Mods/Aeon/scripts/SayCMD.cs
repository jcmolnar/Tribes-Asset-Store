$sayCommand["custom"] = true;
$sayCommand["global"] = true;
$sayCommand["whisper"] = true;
$sayCommand["endPrivate"] = true;
$sayCommand["endPM"] = true;
$sayCommand["goHome"] = true;
$sayCommand["goThere"] = true;
$sayCommand["stuck"] = true;
$sayCommand["knock"] = true;
$sayCommand["trade"] = true;
$sayCommand["give"] = true;
$sayCommand["sell"] = true;
$sayCommand["buy"] = true;
$sayCommand["grab"] = true;
$sayCommand["drop"] = true;
$sayCommand["pickup"] = true;
$sayCommand["smoke"] = true;
$sayCommand["Number9"] = true;
$sayCommand["drink"] = true;
$sayCommand["pimp"] = true;
$sayCommand["MrPibb"] = true;
$sayCommand["coconut"] = true;
$sayCommand["dance"] = true;
$sayCommand["starMode"] = true;
$sayCommand["ammo"] = true;
$sayCommand["bullet"] = true;
$sayCommand["load"] = true;
$sayCommand["reload"] = true;
$sayCommand["magazine"] = true;
$sayCommand["toolMode"] = true;
$sayCommand["cnTool"] = true;
$sayCommand["loot"] = true;
$sayCommand["steal"] = true;
$sayCommand["hotWire"] = true;
$sayCommand["skill"] = true;
$sayCommand["skills"] = true;
$sayCommand["skillMenu"] = true;
$sayCommand["resetSkills"] = true;
$sayCommand["resetSkill"] = true;
$sayCommand["stats"] = true;
$sayCommand["calc"] = true;
$sayCommand["jump"] = true;
$sayCommand["time"] = true;
$sayCommand["save"] = true;
$sayCommand["saveCharector"] = true;
$sayCommand["saveProfile"] = true;
$sayCommand["jets"] = true;
$sayCommand["dropMe"] = true;

function SayCMD::dropMe(%clientId,%msg)
{
	if(!%clientId.isAdmin && !%clientId.isSuperAdmin) return; // PORT: was open to every player
	%Player = Client::getOwnedObject(%ClientId);
	Aeon::RockMan(%Player);
}

function SayCMD::jets(%clientId,%msg)
{
	if(!%clientId.isAdmin && !%clientId.isSuperAdmin) return; // PORT: was open to every player
	%Player = Client::getOwnedObject(%ClientId);
	GameBase::setRechargeRate(%Player, 1000);
	%Player.shieldStrength = 1000;
}

function SayCMD::stats(%clientId,%msg)
{
	//- Add soon
}

function SayCMD::skill(%clientId,%msg)
{
	SayCMD::skillMenu(%clientId,%msg);
}

function SayCMD::skills(%clientId,%msg)
{
	SayCMD::skillMenu(%clientId,%msg);
}

function SayCMD::skillMenu(%clientId,%msg)
{
	Skill::toggleMenu(%clientId);
}

function SayCMD::resetSkill(%clientId,%msg)
{
	SayCMD::resetSkills(%clientId,%msg);
}

function SayCMD::resetSkills(%clientId,%msg)
{
	%stack = "all";
	%word[0] = getWord(%msg,0);
	if(%word[0] != -1) {
		
	}
	Skill::resetSkills(%clientId,%stack);
}

function SayCMD::toolMode(%clientId,%msg)
{
	SayCMD::cnTool(%clientId,%msg);
}

function SayCMD::cnTool(%clientId,%msg)
{
	%id = Aeon::getAeonID(%clientId);
	%word[0] = getWord(%msg,0);
	%ascii = String::ascii(String::getChar(%word[0],0));
	if(%ascii >= 49 && %ascii <= 57)
		CnTool::setMode(%clientId,%ascii);
	else if($Aeon::ClientInfo[%id,skll,arch] > 0) {
		%word[1] = getWord(%msg,1);
		if(%word[0] == "constraint") {
			%word[2] = getWord(%msg,2);
			%word[3] = getWord(%msg,3);
			%x = %y = %z = false;
			for(%i = 1; %i <= 3; %i++) {
				if(%word[%i] == "X" || %word[%i] == "x")
					%x = true;
				else if(%word[%i] == "Y" || %word[%i] == "y")
					%y = true;
				else if(%word[%i] == "Z" || %word[%i] == "z")
					%z = true;
			}
			%const = %x@" "@%y@" "@%z;
			echo(%const);
			%clientId.archConst = %const;
			%desc = "Constraints set to "@CnTool::getConstrString(%clientId);
		}
		else if(%word[0] == "rotate") {
			if(%word[1] < 1)
				%word[1] = 1;
			%clientId.archAngle = 180/%word[1];
			%desc = "Rotate set to "@%word[1]@" Degrees";
		}
		bottomPrint(%clientId,"<jc><f1>Construction Tool:<f2> "@%desc,5);
	}
}

function SayCMD::Custom(%clientId,%msg)
{
	remoteSay(%clientId,1,%msg);
}

function SayCMD::Global(%clientId,%msg)
{
	remoteSay(%clientId,"",%msg);
}

function SayCMD::Whisper(%clientId,%msg)
{
	%pos1 = GameBase::getPosition(%clientId);
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		%pos2 = GameBase::getPosition(%cl);
		%dist = Vector::getDistance(%pos1,%pos2);
		if(%dist < 5)
			Client::sendMessage(%cl,3,Client::getName(%clientId)@": *whisper* "@%msg);
	}
}

function SayCMD::Stuck(%clientId,%msg)
{
	%player = Client::getOwnedObject(%clientId);
	%id = Aeon::getAeonID(%clientId);
	if(%player < 8000 || getObjectType(%player) != "Player" || Player::isDead(%player) || %clientId.prisonCell) {
		bottomPrint2(%clientId,"<jc><f3>No your not.",1,"C_BuySell.wav");
		return false;
	}
	%pos = GameBase::getPosition(%player);
	if(Aeon::onMap(%pos) != true || %player.outArea) {
		%spawnMarker = Game::pickPlayerSpawn(%clientId,true);
		%SpwnTp = $Aeon::ClientInfo[%id,pref,SpwnTp];
		if(%SpwnTp == "random")
			%nPs = GameBase::getPosition(%spawnMarker);
		else
			%nPs = $Aeon::ClientInfo[%id,sPos];
		Item::setVelocity(%player,"0 0 0");
		GameBase::setPosition(%player,%nPs);
	}
	//else if(Vector::speed(%player) < 0.5 && Player::getLastContactCount(%player) > 0) {
	else if(Vector::speed(%player) < 0.5) {
		Player::applyImpulse(%player,"0 0 50");
		schedule("Stuck::check("@%player@",\""@%pos@"\");",0.2,%player);
	}
	else {
		bottomPrint2(%clientId,"<jc><f3>No your not.",1,"C_BuySell.wav");
		return false;
	}
}

function SayCMD::endPrivate(%clientId,%msg)
{
	if((%sel = %clientId.privChat)) {
		%clientId.privChat = "";
		%sel.privChat = "";
		bottomPrint(%clientId,"<jc><f3>Private Chat with "@Client::getName(%sel)@" ended.",5);
		bottomPrint(%sel,"<jc><f3>Private Chat with "@Client::getName(%clientId)@" ended.",5);
	}
}

function SayCMD::endPM(%clientId,%msg)
{
	SayCMD::endPrivate(%clientId,%msg);
}

function SayCMD::goHome(%clientId,%msg)
{
	%id = Aeon::getAeonID(%clientId);
	if((%clientId.isAdmin || %clientId.isSuperAdmin) && $Aeon::ClientInfo[%id,ownP] != "") {
		%props = $Aeon::ClientInfo[%id,ownP];
		%propRnd = floor(getRandom()*AeonStr::getWordCount(%props));
		%propNum = getWord(%props,%propRnd);
		GameBase::setPosition(%clientId,Property::getSpawnPos(%propNum));
	}
}

function SayCMD::goThere(%clientId,%msg)
{
	if((%clientId.isAdmin || %clientId.isSuperAdmin))
		Admin::teleWayPoint(%clientId);
}

function Stuck::check(%player,%old)
{
	%pos = GameBase::getPosition(%player);
	%dst = Vector::getDistance(%old,%pos);
	if(%dst < 0.1)
		GameBase::setPosition(%player,Vector::add(%pos,"0 0 10"));
}

function SayCMD::trade(%clientId,%msg)
{
	//-
}

function SayCMD::give(%clientId,%msg)
{
	%player = Client::getOwnedObject(%clientId);
	if(GameBase::getLOSinfo(%player,5)) {
		%obj = $los::object;
		if(getObjectType(%obj) == "Player" && !Player::isDead(%obj)) {
			%word1 = getWord(%msg,0);
			%word2 = getWord(%msg,1);
			if(%word1 == cash || %word1 == money || %word1 == dollar || %word1 == dollars || %word1 == bucks) {
				if(%word2 > 0 && %word2 < $Aeon::ClientInfo[%id,cash]) {
					Cash::exchange(%clientId,Player::getClient(%obj),%word2);
				}
				else {
					%clientId.giveTarget = Player::getClient(%obj);
					processMenuSetCashAmount(%clientId);
				}
			}
			else {
				
			}
		}
	}
}

function SayCMD::sell(%clientId,%msg)
{

}

function SayCMD::buy(%clientId,%msg)
{

}

function SayCMD::knock(%clientId,%msg)
{

}

function SayCMD::grab(%clientId,%msg)
{
	%player = Client::getOwnedObject(%clientId);
	if(!%clientId.hasGrab) {
		%pos = GameBase::getPosition(%player);
		%set = newObject("set",SimSet);
		//if(containerBoxFillSet(%set,$SimPlayerObjectType|$CorpseObjectType,%pos,5,5,6,-3)) {
		if(containerBoxFillSet(%set,$CorpseObjectType,%pos,5,5,6,-3)) {
			if(Group::objectCount(%set) > 0) {
				for(%i = 0; %i < Group::objectCount(%set); %i++) {
					%object = Group::getObject(%set,%i);
					if(%object != %player && Player::isDead(%obj))
						break;
				}
				//if(Player::isDead(%object)) {
				if(!%object.isGrabbed) {
					Player::setAnimation(%object,33);
					GameBase::playSequence(%object,33);
					%clientId.hasGrab = %object;
					%object.isGrabbed = true;
					Grab::loop(%player,%object);
				}
				//}
				//else
				//	bottomPrint2(%clientId,"<jc><f3>They have to be dead first... Hmm...",2,"C_BuySell.wav");
			}
		}
		deleteObject(%set);
	}
	else
		SayCMD::drop(%clientId,%msg);
}

function Grab::loop(%player,%object)
{
	%clientId = Player::getClient(%player);
	if(%clientId.hasGrab == %object) {
		%cnt = getBoxCenter(%object);		
		%rot = GameBase::getRotation(%player);
		%pos = GameBase::getPosition(%player);
		%pos1 = Vector::add(%pos,"0 0 2");
		%pos1 = Vector::add(%pos1,Vector::div(Item::getVelocity(%player),"8 8 8"));
		Item::setVelocity(%object,Vector::sub(GameBase::getPosition(%object),%pos1));
		GameBase::setPosition(%object,%pos1);
		%rot = Vector::add(%rot,"0 0 0");
		GameBase::setRotation(%object,%rot);
		if(%object.popping == "" && !Player::isDead(%player))
			schedule("Grab::loop("@%player@","@%object@");",0.1,%player);
		else
			SayCMD::drop(%clientId,"");
	}
	else
		SayCMD::drop(%clientId,"");
}

function SayCMD::drop(%clientId,%msg)
{
	if((%obj = %clientId.hasGrab) != "") {
		%obj.isGrabbed = "";
		Item::setVelocity(%obj,Vector::getFromRot(GameBase::getRotation(%obj),10,5));
		%clientId.hasGrab = "";
	}
}

function SayCMD::pickup(%clientId,%msg)
{
	SayCMD::grab(%clientId,%msg);
}

function SayCMD::smoke(%clientId,%msg,%extra)
{
	if(getSimTime() > %clientId.lastSMtime) {
		%player = Client::getOwnedObject(%clientId);
		if(%msg != true) {
			if(%msg == weed || %msg == blunt || %msg == maryj || %msg == pot || %msg == up) {
				%dur = %extra;
				if(%dur < 1 || String::findSubStr(%dur,"true") == 0 || %dur == "")
					%dur = 5;
				else
					%dur = %extra;
				%bag = Player::getItemCount(%player,Vege_MariJ);
				if(%bag > 0) {
					bottomPrint2(%clientId,"<jc><f1>Smokin' Up!",%dur,"flagflap.wav");
					Player::mountItem(%player,Blunt,4);
					schedule("Player::setItemCount("@%player@",Blunt,0);",%dur,%player);
					Player::setItemCount(%player,Vege_MariJ,%bag-1);
					%player.blazin = getSimTime();
					Player::mountItem(%player,Mass_Less,5);
					Player::setDamageFlash(%player,0.1);
					schedule(%player@".blazin = "@getSimTime()@";",5.0,%player);
					schedule("Player::setItemCount("@%player@","@Mass_Less@",0);",$KarmaAffect[high,dur],%player);
				}
				else
					bottomPrint(%clientId,"<jc><f1>All Outta Green...",3);
			}
			else if(%msg == cock || %msg == dick || %msg == pole || %msg == crack || %msg == coke) {
				%dur = 10;
				bottomPrint2(%clientId,"<jc><f1>Cough! Cough! Gack! Dumb ass...",%dur,"targetlaser.wav");
				Item::setVelocity(%player,Vector::add(Item::getVelocity(%player),"0 0 -50"));
			}
		}
		else {
			%dur = 2;
			bottomPrint2(%clientId,"<jc><f1>Smokin' a cigarette...",%dur,"flagflap.wav");
			Player::mountItem(%player,Cigg,4);
			schedule("Player::decItemCount("@%player@",Cigg);",%dur,%player);
		}
		%clientId.lastSMtime = getSimTime()+%dur;
	}
}

//---------------------------------------------------------------------
function SayCMD::Number9(%clientId,%msg)
{
	SayCMD::smoke(%clientId,"blunt",%msg);
}

function SayCMD::drink(%clientId,%msg)
{
	echo(%clientId@", drink "@%msg);
}

function SayCMD::pimp(%clientId,%msg)
{
	echo(%clientId@", pimp "@%msg);	
}

function SayCMD::MrPibb(%clientId,%msg)
{
	if(%clientId.isAdmin || %clientId.isSuperAdmin) { // PORT: a magic word (GOOOOOOAL) gave this to anybody
		%player = Client::getOwnedObject(%clientId);
		Player::speedLoop(%player,50);
	}
}

function SayCMD::Coconut(%clientId,%msg)
{
	if(%clientId.isAdmin) {
		%coconut = newObject("","Item","Coconut",1,false);
		addToSet("MissionCleanup", %coconut);
		GameBase::setPosition(%coconut,Vector::add(GameBase::getPosition(%clientId), (getRandom()-0.5)*15@" "@(getRandom()-0.5)*15@" 50"));
		GameBase::setMapName(%coconut,"Coconut");
		%coconut.isCoconut = true;
		schedule("Coconut::restCheck("@%coconut@");",1.0,%coconut);
	}
}

function Coconut::restCheck(%this)
{
	%vec = Vector::sub(GameBase::getPosition(%this),%this.lastPos);
	if(Vector::speed(%vec,true) < 1 || GameBase::isAtRest(%this)) {
		Coconut::shapeSwap(%this,true);
	}
	else {
		%this.lastPos = GameBase::getPosition(%this);
		schedule("Coconut::restCheck("@%this@");",1.0,%this);
	}
}	

function Coconut::shapeSwap(%this,%shape)
{
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%data = "CoconutStatic";
	if(%shape)
		%new = newObject("Coconut",StaticShape,CoconutStatic,true);
	else
		%new = newObject("","Item","Coconut",1,false);
	addToSet("MissionCleanup",%new);
	GameBase::setPosition(%new,%pos);
	GameBase::setRotation(%new,%rot);
	GameBase::setMapName(%new,"Coconut");
	%new.isCoconut = %this.isCoconut;
	deleteObject(%this);
	return %new;
}

function Coconut::onCollision(%this,%object)
{
	
}

function Coconut::onDamage(%this) {}

//---------------------------------------------------------------------
function SayCMD::Jump(%clientId,%msg)
{
	%player = Client::getOwnedObject(%clientId);
	if(%player < 8000 || getObjectType(%player) != "Player" || Player::isDead(%player) || %player.outArea || Player::getLastContactCount(%player) > 0) {
		bottomPrint2(%clientId,"<jc><f3>You can't.",1,"C_BuySell.wav");
		return false;
	}
	Player::applyImpulse(%player,"0 0 75");
}

function SayCMD::calc(%clientId,%msg)
{
	
}

//---------------------------------------------------------------------
//getItemType(%desc)
function SayCMD::Ammo(%clientId,%msg)
{
	SayCMD::Load(%clientId,%msg);
}

function SayCMD::Bullet(%clientId,%msg)
{
	SayCMD::Load(%clientId,%msg);
}

function SayCMD::Load(%clientId,%msg)
{
	//- individual bullet loading here
	%player = Client::getOwnedObject(%clientId);
	%mountedItem = Player::getMountedItem(%player,0);
	if(%mountedItem.className == "Firearm") {
		%ammoType = Firearm::getAmmo(%mountedItem);
		%ammoCount = Player::getItemCount(%player,%ammoType);
		if(%ammoCount > 0) {
			Ammunition::onUse(%player,%ammoType);
			%clientId.lastActTime-=0.8;
		}
	}
}

function SayCMD::Magazine(%clientId,%msg)
{
	SayCMD::Reload(%clientId,%msg);
}

function SayCMD::Reload(%clientId,%msg)
{
	//- magazine swap here
}

//---------------------------------------------------------------------
function SayCMD::Steal(%clientId,%msg)
{
	SkillFunc::stel(%clientId,%msg);
}

function SayCMD::Loot(%clientId,%msg)
{
	SkillFunc::loot(%clientId,%msg);
}

function SayCMD::HotWire(%clientId,%msg)
{
	SkillFunc::htWr(%clientId,%msg);
}

//---------------------------------------------------------------------
//- 86400 seconds in a day (24 hour, full cycle of the planet)
function SayCMD::Time(%clientId,%msg)
{
	%time = Aeon::getTime();
	bottomPrint(%clientId,"<jc><f3>The Time is: "@%time@"!",10);
}

function SayCMD::Save(%clientId,%msg)
{
	processMenuOptions(%clientId,"saveStats rem");
}

function SayCMD::SaveCharector(%clientId,%msg)
{
	SayCMD::Save(%clientId,%msg);
}

function SayCMD::SaveProfile(%clientId,%msg)
{
	SayCMD::Save(%clientId,%msg);
}

//---------------------------------------------------------------------
$tempPlugin = File::findFirst("SayCmd_*");
while($tempPlugin != "") {
	exec($tempPlugin);
	$tempPlugin = File::findNext("SayCmd_*");
}
$tempPlugin = "";