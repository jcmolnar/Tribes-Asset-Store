$Property::limits[Width,max] = 400;
$Property::limits[Width,min] = 20;
$Property::limits[Length,max] = 400;
$Property::limits[Length,min] = 20;
$Property::limits[Height,max] = 400;
$Property::limits[Height,min] = 20;
$Property::extras["PD"] = 0;
$Property::extras["BR"] = 500;
$Property::extras["PP"] = 1000;
$Property::priceRate = 5.0;
$Property::minCstReq = ($Property::priceRate*($Property::limits[Width,min]*$Property::limits[Length,min]*($Property::limits[Height,min]/4)))+$Property::extras["PD"];

$Aeon::PropertyTeam = 0;

//-Property::hasPermission(%clientId,%prop,%act)
$Aeon::PropPerm[""] = 9;
$Aeon::PropPerm["owner"] = 9;
$Aeon::PropPerm["dele"] = 9;
$Aeon::PropPerm["lock"] = 8;
$Aeon::PropPerm["deploy"] = 7;
$Aeon::PropPerm["seed"] = 6;
$Aeon::PropPerm["posi"] = 5;
$Aeon::PropPerm["alig"] = 5;
$Aeon::PropPerm["rota"] = 5;
$Aeon::PropPerm["undo"] = 5;
$Aeon::PropPerm["skill"] = 4;
$Aeon::PropPerm["term"] = 3;
$Aeon::PropPerm["tele"] = 2;
$Aeon::PropPerm["spawn"] = 1;

$Aeon::PermDesc[9] = "Deleting, ";
$Aeon::PermDesc[8] = "(un)Locking, ";
$Aeon::PermDesc[7] = "Deploying, ";
$Aeon::PermDesc[6] = "Planting Seeds, ";
$Aeon::PermDesc[5] = "Moving Structures, ";
$Aeon::PermDesc[4] = "Use of Skill Funcs, ";
$Aeon::PermDesc[3] = "Use of Terminals, ";
$Aeon::PermDesc[2] = "Teleporting to and ";
$Aeon::PermDesc[1] = "Spawning on your Property.";

$Property[reserve,1] = "0 0";
$Property[reserve,1,radius] = 200;

$Property[special,1] = "0 0";
$Property[special,1,radius] = 50;
$Property[special,1,markup] = 200;

$AeonMap[xMin] = -3500;
$AeonMap[xMax] =  2600;
$AeonMap[yMin] = -3700;
$AeonMap[yMax] =  2400;

function Property::setOwner(%prop,%id,%hold)
{
	%owner = $Aeon::property[%prop,owner];
	Property::remFromOwner(%owner,%prop);
	%group = nameToID("MissionCleanup\\Property\\Property #"@%prop);
	$Aeon::property[%prop,owner] = %id;
	if($Aeon::ClientInfo[%id,ownP] == "")
		%props = %prop;
	else
		%props = $Aeon::ClientInfo[%id,ownP]@" "@%prop;
	$Aeon::ClientInfo[%id,ownP] = %props;
	if(%hold != true)
		Aeon::ExportProperty(%group);
}

function Property::remFromOwner(%id,%prop)
{
	%props = $Aeon::ClientInfo[%id,ownP];
	%len = AeonStr::len(%props);
	for(%i = 0; getWord(%props,%i) != -1; %i++) {
		if(getWord(%props,%i) == %prop) {
			%num2 = %i-2;
			if(%num2 <= 0)
				%num2 = 2;
			%part1 = String::getSubStr(%props,0,%i);
			%part2 = String::getSubStr(%props,%num2,%len-(%i+2));
			$Aeon::ClientInfo[%id,ownP] = %part1@%part2;
			return true;
		}
	}
	return false;
}

function Property::buy(%clientId,%info)
{
	if(%info == -1 || %info == "")
		return false;
	%id = Aeon::getAeonID(%clientId);
	%len = AeonStr::Len(%info);
	%nm1 = String::indexOf(%info,"|");
	%nm2 = String::indexOf(%info,"|",%nm1+1);
	%loc = String::getSubStr(%info,0,%nm1-1);
	%dim = AeonStr::trim(String::getSubStr(%info,%nm1+2,(%nm2 - %nm1)-2));
	%pro = AeonStr::trim(String::getSubStr(%info,%nm2+2,(%len - %nm2)-2));
	%val = Property::getValue(%dim,%pro,%loc,true);
	if($Aeon::ClientInfo[%id,cash] >= %val) {
		%num = Property::getNext();
		$Aeon::ClientInfo[%id,cash] -= floor(%val);
		bottomPrint2(%clientId,"<jc><f3>You purchased "@Aeon::cashStr(%val)@" of land!",1,"BuySellSound.wav");
		%dimX = getWord(%dim,0);
		%dimY = getWord(%dim,2);
		%dimZ = getWord(%dim,4);
		%main = nameToID("MissionCleanup\\Property");
		if(%main == -1) {
			%main = newObject("Property",SimGroup,"Group");
			addToSet("MissionCleanup",%main);
		}
		%gName = "Property #"@%num;
		%group = nameToID("MissionCleanup\\Property\\"@%gName);
		if(%group == -1) {
			%group = newObject(%gName,SimGroup,"Group");
			addToSet("MissionCleanup\\Property",%group);
		}
		if(%num < 0 || %num == "" || %num == false)
			%num = 1;
		$Aeon::property[%num,locat] = %loc;
		$Aeon::property[%num,Width] = %dimX;
		$Aeon::property[%num,Lngth] = %dimY;
		$Aeon::property[%num,HghtZ] = %dimZ;
		$Aeon::property[%num,prprt] = %pro;
		%group.propID = %num;
		Property::setOwner(%num,%id,true);
		Property::initBuild(%num);
	}
}

function Property::initBuild(%prop)
{
	Property::setBox(%prop);
	%own = $Aeon::property[%prop,owner];
	%loc = $Aeon::property[%prop,locat];
	%dimX = $Aeon::property[%prop,Width];
	%dimY = $Aeon::property[%prop,Lngth];
	%dimZ = $Aeon::property[%prop,HghtZ];
	if(%dimZ >= $Property::limits[Height,max]/2)
		%size = "Lrg";
	else if(%dimZ >= $Property::limits[Height,max]/4)
		%size = "Med";
	else
		%size = "Sml";
	%type = "FencePost"@%size;
	%name = $Aeon::ClientInfo[%own,name];
	%NWps = newObject("",StaticShape,%type,true);
	%NEps = newObject("",StaticShape,%type,true);
	%SWps = newObject("",StaticShape,%type,true);
	%SEps = newObject("",StaticShape,%type,true);
	%set = "MissionCleanup\\Property\\Property #"@%prop;
	addToSet(%set,%NWps);
	addToSet(%set,%NEps);
	addToSet(%set,%SWps);
	addToSet(%set,%SEps);
	Gamebase::setMapName(%NWps,%name@"'s NW Post");
	Gamebase::setMapName(%NEps,%name@"'s NE Post");
	Gamebase::setMapName(%SWps,%name@"'s SW Post");
	Gamebase::setMapName(%SEps,%name@"'s SE Post");
	GameBase::setTeam(%NWps,$Aeon::PropertyTeam);
	GameBase::setTeam(%NEps,$Aeon::PropertyTeam);
	GameBase::setTeam(%SWps,$Aeon::PropertyTeam);
	GameBase::setTeam(%SEps,$Aeon::PropertyTeam);
	Property::owns(%prop,%NWps,"",true);
	Property::owns(%prop,%NEps,"",true);
	Property::owns(%prop,%SWps,"",true);
	Property::owns(%prop,%SEps);
	%NWps.locked = true;
	%NEps.locked = true;
	%SWps.locked = true;
	%SEps.locked = true;
	Property::updateDims(%prop);
	Aeon::ExportInfo(%clientId);
	return;
}

function Property::owns(%prop,%this,%shape,%hold)
{
	if(getObjectType(%this) == "SimManager")
		return;
	%own = Property::getOwner(%prop);
	%gName = "Property #"@%prop;
	%group = nameToID("MissionCleanup\\Property\\"@%gName);
	%this.prop = %prop;
	%this.ownsItem = GameBase::getDataName(%this);
	GameBase::setTeam(%this,$Aeon::PropertyTeam);
	if(String::findSubStr(%shape,".dis") > 0)
		%this.ownsItem = %shape;
	if(isMember(%group,%this) == false)
		addToSet("MissionCleanup\\Property\\"@%gName,%this);
	if(%hold != true)
		Aeon::ExportProperty(%group);
}

function Property::delete(%this,%man)
{
	%prop = Property::getPieceOwn(%this);
	if(%this.bindLight)
		Lights::turnOff(%this);
	if(GameBase::getDataName(%this) == "teleporter")
		Teleporter::removeFromNetwork(%this);
	deleteObject(%this);
	if(%man == true)
		Aeon::ExportProperty(%prop);
}

function Property::reAdd(%num)
{
	%start = 0;
	if($Aeon::property[%num,piece,0,itm] == "" && $Aeon::property[%num,piece,1,itm] != "")
		%start = 1;
	%own = $Aeon::property[%num,owner];
	%dimX = $Aeon::property[%num,Width];
	%dimY = $Aeon::property[%num,Lngth];
	%dimZ = $Aeon::property[%num,HghtZ];
	%pos = $Aeon::property[%num,locat];
	%rot = "0 0 0";
	%main = nameToID("MissionCleanup\\Property");
	if(%main == -1) {
		%main = newObject("Property",SimGroup,"Group");
		addToSet("MissionCleanup",%main);
	}
	%gName = "Property #"@%num;
	%group = nameToID("MissionCleanup\\Property\\"@%gName);
	if(%group == -1) {
		%group = newObject(%gName,SimGroup,"Group");
		addToSet("MissionCleanup\\Property",%group);
	}
	%set = "MissionCleanup\\Property\\"@%gName;
	for(%i = %start; $Aeon::property[%num,piece,%i,itm] != ""; %i++) {
		%pos = $Aeon::property[%num,locat];
		%itm = $Aeon::property[%num,piece,%i,itm];
		%typ = $Aeon::property[%num,piece,%i,typ];
		%nam = $Aeon::property[%num,piece,%i,nam];
		%pos = $Aeon::property[%num,piece,%i,pos];
		%rot = $Aeon::property[%num,piece,%i,rot];
		%dmg = $Aeon::property[%num,piece,%i,dmg];
		%lok = $Aeon::property[%num,piece,%i,lok];
		%ext1 = "";
		%ext2 = "";
		if(%typ == "StaticShape" || %typ == "flier")
			%ext1 = "true";
		else if(%typ == "Item") {
			%ext1 = "1";
			%ext2 = "false";
		}
		if(String::findSubStr(%itm,"FencePost") == 0) {
			if(%dimZ >= $Property::limits[Height,max]/2)
				%size = "Lrg";
			else if(%dimZ >= $Property::limits[Height,max]/4)
				%size = "Med";
			else
				%size = "Sml";
			%itm = "FencePost"@%size;
			%lok = true;
		}
		%group.propID = %num;
		%obj = newObject("",%typ,%itm,%ext);
		addToSet(%set,%obj);
		Gamebase::setMapName(%obj,%nam);
		GameBase::setTeam(%obj,$Aeon::PropertyTeam);
		GameBase::setPosition(%obj,%pos);
		GameBase::setRotation(%obj,%rot);
		GameBase::setDamageLevel(%obj,%dmg);
		%obj.ownsItem = %itm;
		%obj.locked = %lok;
		%obj.prop = %num;
	}
	Property::updateDims(%num);
}

function Property::setBox(%num)
{
	%gName = "Property #"@%num;
	%set = "MissionCleanup\\Property\\"@%gName;
	%oldBox = nameToID(%set@"\\PropBox_"@%num);
	if(%oldBox != -1)
		deleteObject(%oldBox);
	%own = $Aeon::property[%num,owner];
	%dimX = $Aeon::property[%num,Width];
	%dimY = $Aeon::property[%num,Lngth];
	%dimZ = $Aeon::property[%num,HghtZ];
	%pos = $Aeon::property[%num,locat];
	%rot = "0 0 0";
	instant Trigger "PropBox_"@%num {
		dataBlock = "PropBoxTrigger";
		name = "PropBox_"@%num;
		position = %pos;
		rotation = %rot;
		boundingBox = -%dimX/2@" "@-%dimY/2@" 0 "@%dimX/2@" "@%dimY/2@" "@%dimZ;
		isSphere = "false";
		num = "Trigger"@%num;
	};
	%box = nameToID("PropBox_"@%num);
	addToSet(%set,%box);
}

function Property::setOpts(%num,%dims,%loct,%prpr)
{
	$Aeon::property[%num,Width] = getWord(%dims,0);
	$Aeon::property[%num,Lngth] = getWord(%dims,2);
	$Aeon::property[%num,HghtZ] = getWord(%dims,4);
	if(%loct != "")
		$Aeon::property[%num,locat] = %loct;
	if(%prpr != "")
		$Aeon::property[%num,prprt] = %prpr;
}

function Property::updateDims(%num,%force,%fOrgn)
{
	%gName = "Property #"@%num;
	%set = "MissionCleanup\\Property\\"@%gName;
	%group = nameToID(%set);
	%done = 0;
	Property::setBox(%num);
	for(%i = 0; Group::getObject(%group,%i) != -1 && %done < 4; %i++) {
		%obj = Group::getObject(%group,%i);
		%data = GameBase::getDataName(%obj);
		%name = GameBase::getMapName(%obj);
		if(String::findSubStr(%data,"FencePost") == 0) {
			%dimX = $Aeon::property[%num,Width];
			%dimY = $Aeon::property[%num,Lngth];
			%dimZ = $Aeon::property[%num,HghtZ];
			if(%force) {
				%dimX = getWord(%force,0);
				%dimY = getWord(%force,2);
				%dimZ = getWord(%force,4);
			}
			%pos = $Aeon::property[%num,locat];
			if(%fOrgn)
				%pos = %fOrgn;
			%dir = String::getSubStr(%name,AeonStr::len(%name)-7,2);
			if(%dir == "NW")
				%pos = Vector::add(%pos,%dimX/-2@" "@%dimY/2@" 0");
			else if(%dir == "NE")
				%pos = Vector::add(%pos,%dimX/2@" "@%dimY/2@" 0");
			else if(%dir == "SW")
				%pos = Vector::add(%pos,%dimX/-2@" "@%dimY/-2@" 0");
			else if(%dir == "SE")
				%pos = Vector::add(%pos,%dimX/2@" "@%dimY/-2@" 0");
			%pos = getWord(%pos,0)@" "@getWord(%pos,1)@" "@Property::terrainHeight(%pos)-1;
			if(%dimZ >= $Property::limits[Height,max]/2)
				%size = "Lrg";
			else if(%dimZ >= $Property::limits[Height,max]/4)
				%size = "Med";
			else
				%size = "Sml";
			%size = "FencePost"@%size;
			if(%data != %size) {
				%obj = newObject(%name,StaticShape,%size,true);
				addToSet(%set,%obj);
				Gamebase::setMapName(%obj,%name);
				GameBase::setTeam(%obj,$Aeon::PropertyTeam);
				GameBase::setRotation(%obj,"0 0 0");
			}
			GameBase::setPosition(%obj,%pos);
			%done++;
		}
	}
}

function Property::floatOrigin(%loc,%dir,%amt)
{
	if(%dir == "north") {
		%newLoc = Vector::add(%loc,"0 "@%amt/2@" 0");
	}
	else if(%dir == "east") {
		%newLoc = Vector::add(%loc,%amt/2@" 0 0");
	}
	else if(%dir == "south") {
		%newLoc = Vector::add(%loc,"0 "@%amt/-2@" 0");
	}
	else if(%dir == "west") {
		%newLoc = Vector::add(%loc,%amt/-2@" 0 0");
	}
	return %newLoc;
}

function Property::canExpand(%num,%add,%dir)
{
	%expans = Property::findExpand(%num,%add);
	%canN = getWord(%expans,0);
	%canE = getWord(%expans,1);
	%canS = getWord(%expans,2);
	%canW = getWord(%expans,3);
	if(%dir == "Width") {
		if(%canE == false && %canW == false)
			return false;
		else if(%canE == false)
			return "west";
		else if(%canW == false)
			return "east";
		return true;
	}
	else if(%dir == "Length") {
		if(%canN == false && %canS == false)
			return false;
		else if(%canN == false)
			return "south";
		else if(%canS == false)
			return "north";
		return true;
	}
	else if(%dir == "Height")
		return true;
}

function Property::findExpand(%num,%add)
{
	%dimX = $Aeon::property[%num,Width];
	%dimY = $Aeon::property[%num,Lngth];
	%dimZ = $Aeon::property[%num,HghtZ];
	%loc = $Aeon::property[%num,locat];
	
	%posN = Vector::add(%loc,"0 "@%dimY/2@" 0");
	%posE = Vector::add(%loc,%dimX/2@" 0 0");
	%posS = Vector::add(%loc,"0 "@%dimY/-2@" 0");
	%posW = Vector::add(%loc,%dimX/-2@" 0 0");

	%pos[1] = Vector::add(%posN,"0 "@getWord(%add,2)@" 0");
	%pos[2] = Vector::add(%posE,getWord(%add,0)@" 0 0");
	%pos[3] = Vector::add(%posS,"0 "@-getWord(%add,2)@" 0");
	%pos[4] = Vector::add(%posW,-getWord(%add,0)@" 0 0");

	for(%i = 1; %i <= 4; %i++) {
		if(Aeon::onMap(%pos[%i]) == true) {
			%able[%i] = false;
			if(Aeon::inProperty(%pos[%i],"",%num) == false)
				%able[%i] = true;
			%expans = %expans@%able[%i]@" ";
		}
	}
	return AeonStr::trim(%expans);
}

function Property::propInter(%num)
{
	%loc = $Aeon::property[%num,locat];
	if(Aeon::inProperty(%loc,Property::getDims(%num),%num))
		return true;
	return false;
}

function Property::addDims(%dim1,%dim2)
{
	%xDif = getWord(%dim1,0) + getWord(%dim2,0);
	%yDif = getWord(%dim1,2) + getWord(%dim2,2);
	%zDif = getWord(%dim1,4) + getWord(%dim2,4);
	return %xDif@" x "@%yDif@" x "@%zDif;
}

function Property::subDims(%dim1,%dim2)
{
	%xDif = getWord(%dim1,0) - getWord(%dim2,0);
	%yDif = getWord(%dim1,2) - getWord(%dim2,2);
	%zDif = getWord(%dim1,4) - getWord(%dim2,4);
	return %xDif@" x "@%yDif@" x "@%zDif;
}

function Property::dir2Dims(%dir,%amt)
{
	if(%dir == "Width")
		return %amt@" x 0 x 0";
	else if(%dir == "Length")
		return "0 x "@%amt@" x 0";
	else if(%dir == "Height")
		return "0 x 0 x "@%amt;
}

function Property::dimsPositive(%dims,%whch,%opt)
{
	if(!%opt)
		%opt = 1;
	if(%whch == "Width" && getWord(%dims,0) >= %opt)
		return true;
	else if(%whch == "Length" && getWord(%dims,2) >= %opt)
		return true;
	else if(%whch == "Height" && getWord(%dims,4) >= %opt)
		return true;
	return false;
}

function Property::dimsMax(%dim,%whch,%amt)
{
	if(!%amt)
		%amt = 0;
	if(%dim > $Property::limits[%whch,max]+%amt)
		return false;
	return true;
}

function Property::getDims(%num,%sub)
{
	if(!%sub)
		%sub = 0;
	%dimX = $Aeon::property[%num,Width]-%sub;
	%dimY = $Aeon::property[%num,Lngth]-%sub;
	%dimZ = $Aeon::property[%num,HghtZ]-%sub;
	return %dimX@" x "@%dimY@" x "@%dimZ;
}

function Property::subArea(%dim1,%dim2,%bool)
{
	%vol1 = getWord(%dim1,0)*getWord(%dim1,2)*getWord(%dim1,4);
	%vol2 = getWord(%dim2,0)*getWord(%dim2,2)*getWord(%dim2,4);
	%sub = %vol1 - %vol2;
	if(%bool) {
		%pow = pow(%sub,1/3);
		return %pow@" x "@%pow@" x "@%pow;
	}
	return %sub;
}

function Property::checkLocation(%clientId,%pos,%dims,%wp)
{
	%CPos = GameBase::getPosition(%clientId);
	if(Player::getLastContactCount(%clientId) != 0 || getWord(%CPos,2) > 300 || Vector::speed(%clientId) != 0) {
		bottomPrint2(%clientId,"<jc><f3>You must be on the ground not moving!",1,"C_BuySell.wav");
		return false;
	}
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType | $SimInteriorObjectType,%pos,getWord(%dims,0),getWord(%dims,2),getWord(%dims,4),0);
	if(%num) {
		if(!Group::areClass(%set,"Harvest","","Tossable")) {
			deleteObject(%set);
			bottomPrint2(%clientId,"<jc><f3>The location must be clear!",1,"C_BuySell.wav");
			return false;
		}
	}
	deleteObject(%set);
	if((%prop = Aeon::inProperty(%pos,%dims)) != false) {
		if(Property::getOwner(%prop) != Aeon::getAeonID(%clientId)) {
			bottomPrint2(%clientId,"<jc><f3>You are on somebody else's property!",1,"C_BuySell.wav");
			return false;
		}
		else
			return "exp "@%prop;
	}
	else {
		if(Aeon::onMap(%pos,%dims)) {
			if(Vector::sub(%wp,%pos) == "0 0 0") {
				%dist = Vector::getDistance(getWord(%CPos,0)@" "@getWord(%CPos,1)@" 0",getWord(%pos,0)@" "@getWord(%pos,1)@" 0");
				if(%dist < Vector::speed(getWord(%dims,0)@" "@getWord(%dims,1)@" 0",true)) {
					%loc = Vector::add(%pos,getWord(%dims,0)/2@" "@getWord(%dims,2)/2@" 0");
					return %loc;
				}
				else
					bottomPrint2(%clientId,"<jc><f3>That location is too far away!",1,"C_BuySell.wav");
				return false;
			}
			else
				return %pos;
		}
		else
			bottomPrint2(%clientId,"<jc><f3>That location is too close to the edge!",1,"C_BuySell.wav");
	}
	return false;
}

function Property::terrainHeight(%pos)
{
	if(AeonStr::getWordCount(%pos) < 2)
		return error;
	if(AeonStr::getWordCount(%pos) < 3)
		%pos = %pos@" 0";
	if(getLOSinfo(Vector::add(%pos,"0 0 1000"),Vector::sub(%pos,"0 0 1000"),1)) {
		%z = getWord($los::position,2);
		return %z;
	}
	return false;
}

function Property::hasKey(%clientId,%id)
{
	//%id = Aeon::getAeonID(%clientId);
	//if(Aeon::getAeonID(%clientId) == %id)
	//	return true;
	//for(%i = 1; $Aeon::ClientInfo[%id,keys,%i] != ""; %i++) {
	//	if($Aeon::ClientInfo[%id,keys,%i] == %id)
	//		return true;
	//}
	return false;
}

//-Aeon::clientInfo(%owner);
function Property::hasPermission(%clientId,%prop,%act)
{
	%id = Aeon::getAeonID(%clientId);
	%owner = Property::getOwner(%prop);
	if(%id == %owner || %clientId.isSuperAdmin)
		return true;
	%perms = $Aeon::ClientInfo[%id,prms,%owner];
	%req = $Aeon::PropPerm[%act];
	//echo("Prop: "@%prop@", Req: "@%req);
	if(%prop == "Central")
		%perms = 3;
	if(%req == "")
		%req = $Aeon::PropPerm[""];
	if(%perms >= %req)
		return true;
	return false;
}

function Aeon::onMap(%pos,%dims)
{
	if(AeonStr::getWordCount(%pos) < 2)
		return error;
	if(AeonStr::getWordCount(%pos) < 3)
		%pos = %pos@" 0";
	%width = getWord(%dims,0);
	%length = getWord(%dims,2);
	%xPos = getWord(%pos,0);
	%yPos = getWord(%pos,1);
	if((%xPos + (%width/2) < $AeonMap[xMax]) && (%xPos - (%width/2) > $AeonMap[xMin])) {
		if((%yPos + (%length/2) < $AeonMap[yMax]) && (%yPos - (%length/2) > $AeonMap[yMin]))
			return true;
		return false;
	}
	return false;
}

function Aeon::inProperty(%pos,%dims,%ex)
{
	if(%dims < 0 || %dims == "")
		%dims = "0 x 0 x 0";
	%prop = Property::getClosest(%pos,%ex);
	%loc = $Aeon::property[%prop,locat];
	%rad = Vector::getDistance("0 0 0",getWord(%dims,0)/2@" "@getWord(%dims,2)/2@" 0");
	%aim = Vector::getRotAim(%pos,%loc);
	%vec = Vector::getFromRot(%aim,%rad);
	%new = Vector::add(%pos,%vec);
	//%proj = Projectile::spawnProjectile("fire", "0 0 1 0 0 0 0 0 1 " @ %new, 2048, "0 0 0");
	%wdth = ($Aeon::property[%prop,Width]/2)+2;
	%lngh = ($Aeon::property[%prop,Lngth]/2)+2;
	%hght = $Aeon::property[%prop,HghtZ];
	if(getWord(%new,0) < (getWord(%loc,0) + %wdth) && getWord(%new,0) > (getWord(%loc,0) - %wdth)) {
		if(getWord(%new,1) < (getWord(%loc,1) + %lngh) && getWord(%new,1) > (getWord(%loc,1) - %lngh)) {
			if(getWord(%new,2) < (getWord(%loc,2) + %hght) && getWord(%new,2) > (getWord(%loc,2) - %hght))
				return %prop;
		}
	}
	return false;
}

function Aeon::getClosestOwnedProp(%id,%pos)
{
	%props = $Aeon::ClientInfo[%id,"ownP"];
	%closest = getWord(%props,0);
	for(%i = 0; %i < AeonStr::getWordCount(%props); %i++) {
		%prop = getWord(%props,%i);
		%loct = $Aeon::property[%prop,locat];
		%dist = Vector::getDistance(%loct,getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord(%loct,2));
		if(%dist < Vector::getDistance($Aeon::property[%closest,locat],getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord($Aeon::property[%closest,locat],2)))
			%closest = %prop;
	}
	return %closest;
}

function Property::getClosest(%pos,%ex)
{
	$Aeon::property[0,locat] = "5000 5000 5000";
	%closest = 0;
	for(%i = 1; $Aeon::property[%i,owner] != ""; %i++) {
		%loct = $Aeon::property[%i,locat];
		%dist = Vector::getDistance(%loct,getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord(%loct,2));
		if(%i != %ex && %dist < Vector::getDistance($Aeon::property[%closest,locat],getWord(%pos,0)@" "@getWord(%pos,1)@" "@getWord($Aeon::property[%closest,locat],2)))
			%closest = %i;
	}
	return %closest;
}

function Property::getOwner(%prop,%opt)
{
	if(%prop == "Central")
		return "Central";
	%ownID = $Aeon::Property[%prop,owner];
	if(%opt) {
		Aeon::clientInfo(%ownId);
		%ownID = $Aeon::ClientInfo[%ownID,name];
	}
	return %ownID;
}

function Property::updateOwner(%id)
{
	$Aeon::ClientInfo[%id,ownP] = "";
	for(%i = 1; $Aeon::Property[%i,owner] != ""; %i++) {
		if($Aeon::Property[%i,owner] == %id) {
			if($Aeon::ClientInfo[%id,ownP] == "")
				$Aeon::ClientInfo[%id,ownP] = %i;
			else
				$Aeon::ClientInfo[%id,ownP] = $Aeon::ClientInfo[%id,ownP]@" "@%i;
		}
	}
}

function Property::getValue(%dims,%prpr,%loc,%ext)
{
	%prpr = $Property::extras[%prpr];
	%area = floor(getWord(%dims,0)*getWord(%dims,2)*(getWord(%dims,4)/4));
	%cost = (%area*$Property::priceRate)+%prpr;
	if(%loc != "" && %loc != -1) {
		for(%i = 1; (%spc = $Property[special,%i]) != ""; %i++)
			if(Vector::getDistance(%loc,%spc@" "@getWord(%loc,2)) < $Property[special,%i,radius]) {
				%cost += $Property[special,%i,markup];
		}
	}
	%price = %cost;
	if(%ext != "true") {
		if(%ext == com)
			%price = String::cashComma(%cost);
		else
			%price = Aeon::cashStr(%cost);
	}
	return %price;
}

function Property::getPieceCount(%prop)
{
	%own = Property::getOwner(%prop);
	%gName = "Property #"@%prop.propID;
	%group = nameToID("MissionCleanup\\Property\\"@%gName);
	%count = Group::objectCount(%group);
	return %count;
}

function Property::getPieceOwn(%obj)
{
	%group = getGroup(%obj);
	//%gName = Object::getName(%group);
	//%id = String::getSubStr(%gName,0,String::indexOf(%gName,"'"));
	//%prop = Aeon::getClosestOwnedProp(%id,GameBase::getPosition(%obj));
	//if(!%prop)
	//	%prop = %obj.prop;
	return %group;
}

function Property::gotoPiece(%clientId,%prop,%num,%z)
{
	if(%clientId < 0 || !%clientId)
		return false;
	else if(%clientId > 3000) {
		%player = %clientId;
		%clientId = Player::getClient(%player);
	}
	else
		%player = Client::getOwnedObject(%clientId);
	if(Player::isDead(%player) || !%player)
		return false;
	%location = $Aeon::property[%prop,"piece",%num,"pos"];
	Item::setVelocity(%player,"0 0 0");
	if(%z)
		%location = Vector::add(%location,"0 0 "@%z);
	GameBase::setPosition(%player,%location);
}

function Property::getCount()
{
	%propManager = nameToID("MissionCleanup\\Property");
	%propCount = Group::objectCount(%propManager);
	return %propCount;
}

function Property::getNext()
{
	%propNext = Property::getCount()+1;
	while($Aeon::property[%propNext,owner])
		%propNext++;
	return %propNext;
}

function FencePost::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%value = 0;
	return;
}

function Aeon::spawnCheck(%clientId)
{
	%player = Client::getOwnedObject(%clientId);
	if(%player < 8000 || getObjectType(%player) != "Player" || Player::isDead(%player) || %player.outArea)
		return false;
	%id = Aeon::getAeonID(%clientId);
	%pos = GameBase::getPosition(%player);
	if((%prop = Aeon::inProperty(%pos)) != "false") {
		%ownID = Property::getOwner(%prop);
		if(%ownID != %id && $Aeon::property[%prop,prprt] != "PD") {
			if(Property::hasPermission(%clientId,%prop,"spawn") || Property::hasKey(%clientId,%ownID))
				return true;
			return false;
		}
		return true;
	}
	return true;
}

function Aeon::spawnPref(%clientId,%opt)
{
	if(%opt == -1)
		return false;
	%id = Aeon::getAeonID(%clientId);
	if(Aeon::spawnCheck(%clientId) != true) {
		%pos = GameBase::getPosition(%clientId);
		%prop = Aeon::inProperty(%pos);
		%owner = Property::getOwner(%prop,true);
		bottomPrint2(%clientId,"<jc><f3>You need permission from "@%owner@" to spawn here.",5,"C_BuySell.wav");
		return false;
	}
	%player = Client::getOwnedObject(%clientId);
	if(%player < 8000 || getObjectType(%player) != "Player" || Player::isDead(%player) || %player.outArea)
		return false;
	if(%opt == "hereMk") {
		if(getWord(GameBase::getPosition(%clientId),2) > 95) {
			if(Vector::speed(%player) < 0.5) {
				$Aeon::ClientInfo[%id,sPos] = GameBase::getPosition(%clientId);
				$Aeon::ClientInfo[%id,sRot] = GameBase::getRotation(%clientId);
			}
			else
				bottomPrint2(%clientId,"<jc><f3>You cannot mark a spawn point while moving.",5,"C_BuySell.wav");
		}
		else
			bottomPrint2(%clientId,"<jc><f3>You cannot save here.",5,"C_BuySell.wav");
	}
	$Aeon::ClientInfo[%id,pref,SpwnTp] = %opt;
	Aeon::ExportInfo(%clientId);
}

function Property::getSpawnPos(%prop,%opt)
{
	%loc = $Aeon::property[%prop,locat];
	if(%opt) {
		//
	}
	else
		%pos = getWord(%loc,0)@" "@getWord(%loc,1)@" "@Property::terrainHeight(%loc);
	return %pos;
}

function Property::deletePiece(%prop,%num)
{
	%gName = "Property #"@%prop;
	%group = nameToID("MissionCleanup\\Property\\"@%gName);
	%obj = Group::getObject(%group,%num);
	if(%obj != -1)
		deleteObject(%obj);
}

function PropBoxTrigger::onEnter(%this,%object)
{
	//%group = getGroup(%this);
	//%prop = %group.propID;
	//%type = getObjectType(%object);
	//if(%type == "Player") {
	//	%clientId = Player::getClient(%object);
	//	%ownId = Property::getOwner(%prop);
	//	%name = Aeon::getName(%ownId);
	//	if(%name == Client::getName(%clientId))
	//		%name = "Your";
	//	else
	//		%name = %name@"<><f1>'s";
	//	%str = escapeString("<jc><f1>You have entered <f2>"@%name@"<f1> Property!");
	//	bottomPrint(%clientId,%str,1);
	//}
	//else {
		%object.inProp = %prop;
	//}
}

function PropBoxTrigger::onLeave(%this,%object)
{
	//%type = getObjectType(%object);
	//if(%type == "Player") {
	//	%group = getGroup(%this);
	//	%prop = %group.propID;
	//	%ownId = Property::getOwner(%prop);
	//	%clientId = Player::getClient(%object);
	//	%name = Aeon::getName(%ownId);
	//	if(%name == Client::getName(%clientId))
	//		%name = "Your";
	//	else
	//		%name = %name@"<><f1>'s";
	//	%str = escapeString("<jc><f1>You have left <f2>"@%name@"<f1> Property!");
	//	bottomPrint(%clientId,%str,1);
	//}
	//else {
		%object.inProp = "";
	//}
}

function PropBoxTrigger::onContact(%this,%object)
{
	//%type = getObjectType(%object);
	//if(%type == "Player") {
	//	%group = getGroup(%this);
	//	%prop = %group.propID;
	//}
}

function PropBoxTrigger::onActivate(%this)
{
}

function PropBoxTrigger::onDeactivate(%this)
{
}
