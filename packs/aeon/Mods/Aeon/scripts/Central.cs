//----------------------------------------------------------------------------
// Foundation	: Floor
// Bank		: Bank Building
// Market	: Market Area
// Library	: Library Hut
// TeleportRoom	: Teleporter Room
// Prison	: Prison Collection
// -CellBlock	: Prison Collection
// Wall		: City Walls and Entrances
//----------------------------------------------------------------------------
$Aeon::CentralInit["Bank"] = true;
$Aeon::CentralInit["Market"] = true;
$Aeon::CentralInit["Library"] = true;
$Aeon::CentralInit["TeleportRoom"] = true;
$Aeon::CentralInit["Prison"] = true;

function Central::clear()
{
	$Aeon::Central["Bank",init] = "";
	$Aeon::Central["Market",init] = "";
	$Aeon::Central["Library",init] = "";
	$Aeon::Central["TeleportRoom",init] = "";
	$Aeon::Central["Prison","CellBlock",init] = "";
	$Aeon::Central["Prison","DoorOutside",open] = "";
	$Aeon::Central["Prison","DoorOutside",opening] = "";
	$Aeon::Central["Prison","DoorInside",open] = "";
	$Aeon::Central["Prison","DoorInside",opening] = "";
	for(%i = 0; %i < 20; %i++)
		$Aeon::TeleNetwork[%i] = "";
}

function Central::initialize()
{
	%central = nameToID("MissionGroup\\Central");
	%cleanup = nameToID("MissionCleanup\\Central");
	if(%cleanup == -1) {
		%cleanup = newObject("Central",SimGroup,"Group");
		addToSet("MissionCleanup",%cleanup);
	}
	for(%i = 0; %i < Group::objectCount(%central); %i++) {
		%part[%i] = Group::getObject(%central,%i);
		%name = Object::getName(%part[%i]);
		$Aeon::Central[%name] = %part[%i];
		if($Aeon::CentralInit[%name] == true)
			Eval("Central::init"@%name@"("@%part[%i]@");");
	}
}

function Central::initBank(%group)
{
	%cleanup = nameToID("MissionCleanup\\Central\\Bank");
	if(%cleanup == -1) {
		%cleanup = newObject("Bank",SimGroup,"Group");
		addToSet("MissionCleanup\\Central",%cleanup);
	}
	%aiCount = 0;
	for(%i = 0; %i < Group::objectCount(%group); %i++) {
		%obj = Group::getObject(%group,%i);
		%name = Object::getName(%obj);
		if(%name == "Bank")
			%hut = %obj;
		else if(%name == "Seat1")
			%aiMarker[%aiCount++] = %obj;
		else if(%name == "Seat2")
			%aiMarker[%aiCount++] = %obj;
	}
	if($Aeon::Central["Bank",init] == true)
		return;
	if(%hut) {
		%rot = Vector::add(GameBase::getRotation(%hut),"0 0 "@$Pi/2);
		%pos = Vector::add(GameBase::getPosition(%hut),Vector::getFromRot(%rot,12,5));
		%term = newObject("Bank Terminal","StaticShape","Term_Bank",true);
		GameBase::setPosition(%term,%pos);
		GameBase::setRotation(%term,%rot);
		GameBase::setTeam(%term,$Aeon::PropertyTeam);
		addToSet("MissionCleanup\\Central\\Bank",%term);
		%term.prop = "Central";
		$Aeon::Central["Bank",Saving] = %term;
	}
	for(%i = 1; %aiMarker[%i] != ""; %i++) {
		%marker = %aiMarker[%i];
		%pos = Vector::add(GameBase::getPosition(%marker),"0 0 5");
		%rot = GameBase::getRotation(%marker);
		%aiName = "Banker #"@%i;
		%aiPl = AI::create(%aiName,"larmor",%pos,%rot);
		$AI::PeriodicPos[%aiName] = %pos;
		$AI::sitType[%aiName] = true;
		AI::CallbackPeriodic(%aiName,1.0);
		$Aeon::Central["Bank",NPC,%i] = %aiPl;
		Player::setAnimation(%aiPl,48);
	}
	$Aeon::Central["Bank",init] = true;
}

function Central::initMarket(%group)
{
	%cleanup = nameToID("MissionCleanup\\Central\\Market");
	if(%cleanup == -1) {
		%cleanup = newObject("Market",SimGroup,"Group");
		addToSet("MissionCleanup\\Central",%cleanup);
	}
	for(%i = 0; %i < Group::objectCount(%group); %i++) {
		%obj = Group::getObject(%group,%i);
		%name = Object::getName(%obj);
		if(%name == "Sales")
			%sales = %obj;
		else if(%name == "Market 1")
			%market1 = %obj;
		else if(%name == "Market 2")
			%market2 = %obj;
	}
	if($Aeon::Central["Market",init] == true)
		return;
	if(%sales) {
		%rot = Vector::add(GameBase::getRotation(%sales),"0 0 "@$Pi/-2);
		%pos = Vector::add(GameBase::getPosition(%sales),Vector::getFromRot(Vector::add(%rot,"0 0 "@$Pi/2),10,5.5));
		%term[Sales] = newObject("Sales Terminal","StaticShape","Term_Sales",true);
		GameBase::setPosition(%term[Sales],%pos);
		GameBase::setRotation(%term[Sales],%rot);
		GameBase::setTeam(%term[Sales],$Aeon::PropertyTeam);
		addToSet("MissionCleanup\\Central\\Market",%term[Sales]);
		%term[Sales].prop = "Central";
		$Aeon::Central["Market",Sales] = %term[Sales];
	}
	%count = 0;
	if(%market1) {
		%rot = Vector::add(GameBase::getRotation(%market1),"0 0 "@$Pi/4);
		%pos = GameBase::getPosition(%market1);
		for(%i = 0; %i < 2*$Pi-0.1; %i += (2*$Pi)/4) {
			%rot[%i] = Vector::add(%rot,"0 0 "@%i);
			%pos[%i] = Vector::add(%pos,Vector::getFromRot(%rot[%i],13,4));
			%term["Market_"@%i] = newObject("Market_ Terminal","StaticShape","Term_Market",true);
			GameBase::setPosition(%term["Market_"@%i],%pos[%i]);
			GameBase::setRotation(%term["Market_"@%i],%rot[%i]);
			GameBase::setTeam(%term["Market_"@%i],$Aeon::PropertyTeam);
			addToSet("MissionCleanup\\Central\\Market",%term["Market_"@%i]);
			%term["Market_"@%i].prop = "Central";
			$Aeon::Central["Market","Market_"@%count++] = %term["Market_"@%i];
		}
	}
	if(%market2) {
		%rot = Vector::add(GameBase::getRotation(%market2),"0 0 "@$Pi/4);
		%pos = GameBase::getPosition(%market2);
		for(%i = 0; %i < 2*$Pi-0.1; %i += (2*$Pi)/4) {
			%rot[%i] = Vector::add(%rot,"0 0 "@%i);
			%pos[%i] = Vector::add(%pos,Vector::getFromRot(%rot[%i],13,4));
			%term["Market_"@%i] = newObject("Market_ Terminal","StaticShape","Term_Market",true);
			GameBase::setPosition(%term["Market_"@%i],%pos[%i]);
			GameBase::setRotation(%term["Market_"@%i],%rot[%i]);
			GameBase::setTeam(%term["Market_"@%i],$Aeon::PropertyTeam);
			addToSet("MissionCleanup\\Central\\Market",%term["Market_"@%i]);
			%term["Market_"@%i].prop = "Central";
			$Aeon::Central["Market","Market_"@%count++] = %term["Market_"@%i];
		}
	}
	$Aeon::Central["Market",init] = true;
}

function Central::initLibrary(%group)
{
	%cleanup = nameToID("MissionCleanup\\Central\\Library");
	if(%cleanup == -1) {
		%cleanup = newObject("Library",SimGroup,"Group");
		addToSet("MissionCleanup\\Central",%cleanup);
	}
	for(%i = 0; %i < Group::objectCount(%group); %i++) {
		%obj = Group::getObject(%group,%i);
		%name = Object::getName(%obj);
		if(%name == "Library")
			%hut = %obj;
	}
	if($Aeon::Central["Library",init] == true)
		return;
	if(%hut) {
		%rot = Vector::add(GameBase::getRotation(%hut),"0 0 "@$Pi);
		%pos = Vector::add(GameBase::getPosition(%hut),Vector::getFromRot(%rot,7.2,10));
		%shelf = newObject("Library Terminal","StaticShape","Term_CheckOut",true);
		GameBase::setPosition(%shelf,%pos);
		GameBase::setRotation(%shelf,%rot);
		GameBase::setTeam(%shelf,$Aeon::PropertyTeam);
		addToSet("MissionCleanup\\Central\\Library",%shelf);
		%shelf.prop = "Central";
		$Aeon::Central["Library",CheckOut] = %shelf;
	}
	$Aeon::Central["Library",init] = true;
}

function Central::initTeleportRoom(%group)
{
	%cleanup = nameToID("MissionCleanup\\Central\\Tele");
	if(%cleanup == -1) {
		%cleanup = newObject("Tele",SimGroup,"Group");
		addToSet("MissionCleanup\\Central",%cleanup);
	}
	for(%i = 0; %i < Group::objectCount(%group); %i++) {
		%obj = Group::getObject(%group,%i);
		%name = Object::getName(%obj);
		if(%name == "Teleport Room")
			%teleRoom = %obj;
	}
	if($Aeon::Central["TeleportRoom",init] == true)
		return;
	if(%teleRoom) {
		%pos = Vector::add(GameBase::getPosition(%teleRoom),"0 0 14.9");
		%rot = Vector::add(GameBase::getRotation(%teleRoom),"0 0 "@3*$Pi/4);
		%tele = newObject("Central Teleporter","StaticShape","Teleporter",true);
		GameBase::setPosition(%tele,%pos);
		GameBase::setRotation(%tele,%rot);
		GameBase::setTeam(%tele,$Aeon::PropertyTeam);
		GameBase::setMapName(%tele,"Central Teleporter");
		addToSet("MissionCleanup\\Central\\Tele",%tele);
		%tele.prop = "Central";
		$Aeon::Central["TeleportRoom",tele] = %tele;
		$Aeon::Central["TeleportRoom",init] = true;
	}
}

function Central::initPrison(%group)
{
	%cleanup = nameToID("MissionCleanup\\Central\\Prison");
	if(%cleanup == -1) {
		%cleanup = newObject("Prison",SimGroup,"Group");
		addToSet("MissionCleanup\\Central",%cleanup);
	}
	if($Aeon::Central["Prison","CellBlock",init] == true)
		return;
	for(%i = 0; %i < Group::objectCount(%group); %i++) {
		%obj = Group::getObject(%group,%i);
		%name = Object::getName(%obj);
		if(%name == "DoorOutside") {
			$Aeon::Central["Prison",%name] = %obj;
			$Aeon::InteractFunc[%obj] = "PrisonDoor";
			$Aeon::Central["Prison",%name,rotation] = GameBase::getRotation(%obj);
			$Aeon::Central["Prison",%name,openRot] = GameBase::getRotation(%obj);
		}
		else if(%name == "DoorInside") {
			$Aeon::Central["Prison",%name] = %obj;
			$Aeon::InteractFunc[%obj] = "PrisonDoor";
			$Aeon::Central["Prison",%name,rotation] = GameBase::getRotation(%obj);
			$Aeon::Central["Prison",%name,openRot] = GameBase::getRotation(%obj);
		}
		else if(%name == "CellBlock")
			Central::initCellBlock(%obj);
	}
}

function Central::initCellBlock(%group)
{
	for(%i = 0; %i < Group::objectCount(%group); %i++) {
		%obj = Group::getObject(%group,%i);
		%name = Object::getName(%obj);
		if(%name == "Doors")
			$Aeon::Central["Prison","CellBlock"] = %obj;
	}
	%group = $Aeon::Central["Prison","CellBlock"];
	%count = 0;
	for(%i = 0; %i < Group::objectCount(%group); %i++) {
		%obj = Group::getObject(%group,%i);
		%name = Object::getName(%obj);
		if(%name == "Marker1") {
			%door[%count++] = %obj;
			$Aeon::Central["Prison","CellBlock","Door_"@%count] = %obj;
			Prison::initCellDoor(%obj,%count);
		}
	}
	$Aeon::Central["Prison","CellBlock",init] = true;
}

function Prison::initCellDoor(%this,%num)
{
	if($Aeon::Central["Prison","CellBlock",init] == true)
		return;
	%pos = Vector::sub(GameBase::getPosition(%this),"0 0 1");
	%rot = GameBase::getRotation(%this);
	%door = newObject("Door"@%num,"StaticShape","Window_5x5",true);
	GameBase::setPosition(%door,%pos);
	GameBase::setRotation(%door,%rot);
	addToSet("MissionCleanup\\Central\\Prison",%door);
	%orgn = Vector::add(%pos,Vector::getFromRot(Vector::add(%rot,"0 0 "@$Pi/2),-2.5));
	%door.cell = %num;
	$Aeon::Central["Prison","CellBlock","Door_"@%num,state] = "closed";
	$Aeon::Central["Prison","CellBlock","Door_"@%num,closeRot] = %rot;
	$Aeon::Central["Prison","CellBlock","Door_"@%num,origin] = %orgn;
	$Aeon::InteractFunc[%door] = "CellBlockDoor";
}

function CellBlockDoor::onInteract(%this,%player)
{
	%clientId = Player::getClient(%player);
	if(%clientId.prisonCell > 0 && !%clientId.isSuperAdmin)
		return;
	%cell = %this.cell;
	%state = $Aeon::Central["Prison","CellBlock","Door_"@%cell,state];
	if(%state == "open" || %state == "closed")
		CellBlockDoor::rotate(%this);
}

function CellBlockDoor::rotate(%this)
{
	%cell = %this.cell;
	%state = $Aeon::Central["Prison","CellBlock","Door_"@%cell,state];
	if(%state == "open") {
		$Aeon::Central["Prison","CellBlock","Door_"@%cell,state] = "closing";
		CellBlockDoor::rotateLoop(%this);
	}
	else if(%state == "closed") {
		$Aeon::Central["Prison","CellBlock","Door_"@%cell,state] = "opening";
		CellBlockDoor::rotateLoop(%this);
	}
	else {
		echo("State Error: "@%state);
		return false;
	}
}

function CellBlockDoor::rotateLoop(%this)
{
	%cell = %this.cell;
	%pos = GameBase::getPosition(%this);
	%rot = GameBase::getRotation(%this);
	%state = $Aeon::Central["Prison","CellBlock","Door_"@%cell,state];
	if(%state != "open" && %state != "closed") {
		%init = getWord($Aeon::Central["Prison","CellBlock","Door_"@%cell,closeRot],2);
		%orgn = $Aeon::Central["Prison","CellBlock","Door_"@%cell,origin];
		%z = getWord(%rot,2);
		if(%state == "opening") {
			if(%z > %init+$Pi/-2+0.1) {
				%rot = Vector::add(%rot,"0 0 "@$Pi/-32);
				if(%z - %init > $Pi)
					$Aeon::Central["Prison","CellBlock","Door_"@%cell,state] = "open";
			}
			else {
				%rot = "0 0 "@%init+$Pi/-2;
				$Aeon::Central["Prison","CellBlock","Door_"@%cell,state] = "open";
			}
		}
		else if(%state == "closing") {
			if(%z < %init-0.1 || %z - %init > $Pi) {
				%rot = Vector::add(%rot,"0 0 "@$Pi/32);
			}
			else {
				%rot = "0 0 "@%init;
				$Aeon::Central["Prison","CellBlock","Door_"@%cell,state] = "closed";
			}
		}
		%pos = Vector::add(%orgn,Vector::getFromRot(Vector::add(%rot,"0 0 "@$Pi/2),2.5));
		GameBase::setPosition(%this,%pos);
		GameBase::setRotation(%this,%rot);
		schedule("CellBlockDoor::rotateLoop("@%this@");",0.1,%this);
	}
	else {
		%door = $Aeon::Central["Prison","CellBlock","Door_"@%cell];
		%rot = GameBase::getRotation(%door);
		%pos = GameBase::getPosition(%door);
		%pos = Vector::add(%pos,Vector::getFromRot(%rot,-2.5));
		%set = newObject("set",SimSet);
		if(containerBoxFillSet(%set,$SimPlayerObjectType|$CorpseObjectType,%pos,4.9,4.9,5,-5)) {
			if(%state == "closed") {
				for(%i = 0; %i < Group::objectCount(%set); %i++)
					Prison::jail(%cell,Group::getObject(%set,%i));
			}
			else
				schedule("Prison::free("@%cell@","@Group::getObject(%set,%i)@");",3.0,Group::getObject(%set,%i));
			deleteObject(%set);
		}
		if(%state == "open")
			schedule("CellBlockDoor::reset("@%this@");",3.0,%this);
	}
}

function Prison::Jail(%cell,%player)
{
	%clientId = Player::getClient(%player);
	//echo(%clientId);
	//%door = $Aeon::Central["Prison","CellBlock","Door_"@%cell];
	%clientId.prisonCell = %cell;
	Player::unMountItem(%player,$WeaponSlot);
}

function Prison::free(%cell,%player)
{
	%door = $Aeon::Central["Prison","CellBlock","Door_"@%cell];
	%rot = GameBase::getRotation(%door);
	%pos = GameBase::getPosition(%door);
	%pos = Vector::add(%pos,Vector::getFromRot(%rot,-2.5));
	%set = newObject("set",SimSet);
	if(containerBoxFillSet(%set,$SimPlayerObjectType|$CorpseObjectType,%pos2,4.9,4.9,5,-5)) {
		for(%i = 0; %i < Group::objectCount(%set); %i++) {
			if(Group::getObject(%set,%i) == %player)
				%still = true;
			else
				Prison::Jail(%cell,Group::getObject(%set,%i));
		}
	}
	if(%still != true)
		Player::getClient(%player).prisonCell = "";
	deleteObject(%set);	
}

function CellBlockDoor::reset(%this)
{
	if($Aeon::Central["Prison","CellBlock","Door_"@%this.cell,state] == "open")
		CellBlockDoor::rotate(%this);
}

function Prison::cellCountInmates(%cell)
{
	%door = $Aeon::Central["Prison","CellBlock","Door_"@%cell];
	%rot = GameBase::getRotation(%door);
	%pos = GameBase::getPosition(%door);
	%pos = Vector::add(%pos,Vector::getFromRot(%rot,-2.5));
	%set = newObject("set",SimSet);
	%count = containerBoxFillSet(%set,$SimPlayerObjectType|$CorpseObjectType,%pos,4.9,4.9,5,0);
	deleteObject(%set);
	return %count;
}

function DoorOutside::onInteract(%this,%player)
{
	if(%this != $Aeon::Central["Prison","DoorOutside"] || %this.inMotion)
		return false;
	%that = $Aeon::Central["Prison","DoorInside"];
	%pos1 = GameBase::getPosition(%this);
	%pos2 = GameBase::getPosition(%that);
	playSound(SoundMineActivate,%pos1);
	playSound(SoundMineActivate,%pos2);
	%set = newObject("set",SimSet);
	if(containerBoxFillSet(%set,$SimPlayerObjectType|$CorpseObjectType,%pos1,4.9,4.9,5,-5)) {
		for(%i = 0; %i < Group::objectCount(%set); %i++) {
			%obj = Group::getObject(%set,%i);
			Prison::doorWarp(%this,%that,%obj);
		}
		Prison::doorRotate(%this,%that);
		schedule("Prison::doorReset("@%this@","@%that@");",7.0);
	}
	if(containerBoxFillSet(%set,$SimPlayerObjectType|$CorpseObjectType,%pos2,4.9,4.9,5,-5)) {
		for(%i = 0; %i < Group::objectCount(%set); %i++)
			Prison::doorWarp(%that,%this,Group::getObject(%set,%i));
	}
	deleteObject(%set);
}

function DoorInside::onInteract(%this,%player)
{
	if(%this != $Aeon::Central["Prison","DoorInside"] || %this.inMotion)
		return false;
	%that = $Aeon::Central["Prison","DoorOutside"];
	%pos1 = GameBase::getPosition(%this);
	%pos2 = GameBase::getPosition(%that);
	playSound(SoundMineActivate,%pos1);
	playSound(SoundMineActivate,%pos2);
	Prison::doorRotate(%this,%that);
	schedule("Prison::doorReset("@%this@","@%that@");",7.0);
	Prison::doorGetPlayers(%this,%that);
}

function Prison::doorReset(%this,%that)
{
	if(!%this.inMotion && !%that.inMotion && $Aeon::Central["Prison","DoorOutside",open] == true) {
		Prison::doorRotate(%this,%that);
		Prison::doorGetPlayers(%this,%that);
	}
}

function Prison::doorGetPlayers(%this,%that)
{
	%set = newObject("set",SimSet);
	if(containerBoxFillSet(%set,$SimPlayerObjectType|$CorpseObjectType,GameBase::getPosition(%this),4.9,4.9,5,-5)) {
		for(%i = 0; %i < Group::objectCount(%set); %i++)
			Prison::doorWarp(%this,%that,Group::getObject(%set,%i));
	}
	if(containerBoxFillSet(%set,$SimPlayerObjectType|$CorpseObjectType,GameBase::getPosition(%that),4.9,4.9,5,-5)) {
		for(%i = 0; %i < Group::objectCount(%set); %i++)
			Prison::doorWarp(%that,%this,Group::getObject(%set,%i));
	}
	deleteObject(%set);

}

function Prison::doorWarp(%this,%that,%player)
{
	if(getSimTime() - %player.lastDoorWarp < 0.5)
		return;
	%player.lastDoorWarp = getSimTime();
	%pos1 = GameBase::getPosition(%this);
	%pos2 = GameBase::getPosition(%that);
	%posP = GameBase::getPosition(%player);
	%vec = Vector::sub(%posP,%pos1);
	%pos = Vector::add(%pos2,%vec);
	GameBase::setPosition(%player,%pos);
	Player::getClient(%player).prisonCell = "";
}

function Prison::doorRotate(%this,%that)
{
	if($Aeon::Central["Prison","DoorOutside",opening] == true) {
		$Aeon::Central["Prison","DoorOutside",opening] = false;
		Prison::doorRotateLoop(%this,%that);
	}
	else {
		$Aeon::Central["Prison","DoorOutside",opening] = true;
		Prison::doorRotateLoop(%this,%that);
	}
}

function Prison::doorRotateLoop(%this,%that)
{
	%start = $Aeon::Central["Prison","DoorOutside",openRot];
	%rot = $Aeon::Central["Prison","DoorOutside",rotation];
	%update = true;
	%this.inMotion = true;
	%that.inMotion = true;
	if($Aeon::Central["Prison","DoorOutside",opening] == true && $Aeon::Central["Prison","DoorOutside",open] != "true") {
		%DoorX = getWord(%rot,2);
		//echo(%doorX@" < "@Calc::unifyPi(%start+$Pi));
		if(%DoorX < getWord(%start,2)+$Pi-0.1) {
			$Aeon::Central["Prison","DoorOutside",rotation] = Vector::add(%rot,"0 0 "@$Pi/32);
		}
		else {
			$Aeon::Central["Prison","DoorOutside",rotation] = getWord(%rot,0)@" "@getWord(%rot,1)@" "@getWord(%start,2)+$Pi;
			$Aeon::Central["Prison","DoorOutside",open] = "true";
		}
	}
	else if($Aeon::Central["Prison","DoorOutside",opening] != true && $Aeon::Central["Prison","DoorOutside",open] != "false") {
		%DoorX = getWord(%rot,2);
		if(%DoorX > getWord(%start,2)) {
			$Aeon::Central["Prison","DoorOutside",rotation] = Vector::add(%rot,"0 0 "@$Pi/-32);
		}
		else {
			$Aeon::Central["Prison","DoorOutside",rotation] = getWord(%rot,0)@" "@getWord(%rot,1)@" "@getWord(%start,2);
			$Aeon::Central["Prison","DoorOutside",open] = "false";
		}
	}
	else {
		%this.inMotion = "";
		%that.inMotion = "";
		%update = false;
	}
	%rot = $Aeon::Central["Prison","DoorOutside",rotation];
	GameBase::setRotation(%this,%rot);
	GameBase::setRotation(%that,%rot);
	if(%update == true)
		schedule("Prison::doorRotateLoop("@%this@","@%that@",\""@%state@"\");",0.1,%this);
}
