$Aeon::rockFall = 45;	 //- 1 rock every 0.75 minutes
$Aeon::rockHght = 800;	 //- Origin height for rocks from 0
$Aeon::rockHold = 1.0;	 //- time to wait to launch rock
$Aeon::rockStay = 5.0;	 //- pop time on rock hulk in minutes
$Aeon::rockValue = 25.0; //- max possible cash from meteor debris
$Aeon::rockAdd = 10.0;   //- max cash added to rockValue, with maxed Geology
$Aeon::ActiveSky = false; //- whether or not sky switches from day and night

$Aeon::QuakeDur["EarthQuake"] = 30.0;	//- Default Duration that a Quake will last
$Aeon::QuakeRad["EarthQuake"] = "";	//- Average Radius that a Quake will affect
$Aeon::QuakeInt["EarthQuake"] = 80;	//- Average Default Intensity of a Quake
$Aeon::QuakeSeq["EarthQuake"] = 0;	//- Sequence form, starts at 0, climaxes at 0.5, ends at 1.0;
$Aeon::QuakeDur["Meteor"] = 5.0;
$Aeon::QuakeRad["Meteor"] = 150;
$Aeon::QuakeInt["Meteor"] = 80;
$Aeon::QuakeSeq["Meteor"] = 0.5;
$Aeon::QuakeDur["Explos"] = 3.0;
$Aeon::QuakeRad["Explos"] = 10;
$Aeon::QuakeInt["Explos"] = 20;
$Aeon::QuakeSeq["Explos"] = 0.5;

$Aeon::SeisRad["Meteor"] = 200;
$Aeon::SeisRad["Explos"] = 75;

$Atmos::updateTime = 1.0;
$Atmos::cleanup = "";
$Atmos::active = true;
$DynSky::Texture["Day"] = "lushdayclear.dml";
$DynSky::Texture["DawnDusk"] = "";
$DynSky::Texture["Night"] = "";
$DynSky::rotRate = 1.0;
$DynSky::RGB["Day"] = RGB::conv(130)@" "@RGB::conv(154)@" "@RGB::conv(215);
$DynSky::RGB["DawnDusk"] = RGB::conv(190)@" "@RGB::conv(181)@" "@RGB::conv(164);
$DynSky::RGB["Night"] = RGB::conv(0)@" "@RGB::conv(0)@" "@RGB::conv(0);
$DynSky::Haze["Day"] = "0 0 0";
$DynSky::Haze["DawnDusk"] = "130 154 215";
$DynSky::Haze["Night"] = "255 255 255";
$DynSun::Texture["Day"] = "LushDayClear_Sun.bmp";
//$DynSun::Texture["DawnDusk"] = "LushDayClear_Sun.bmp";
$DynSun::Texture["DawnDusk"] = "lushdaysun.bmp";
//$DynSun::Texture["Night"] = "IceNitePlanet1.bmp";
$DynSun::Texture["Night"] = "blacksky_planet1.bmp";
$DynSun::rotRate = 0.1;
$DynSun::Zenith = 70; //- in Degrees
$DynWeather::Update = 0.75;
$DynWeather::DefDie = 30;

function Atmos::freeze()
{
	$Atmos::active = "";
}

function Atmos::reset()
{
	$Aeon::inQuake = "";
	$Aeon::lastRock = 0;
	$DynSky::Rotation = 0;
	$DynSun::Rotation[1] = 0;
	$DynSun::Rotation[2] = 0;
	$DynSky::RGBPhase = $DynSky::RGB["DawnDusk"];
	$DynSky::Phasing = "init";
}

function Atmos::loop()
{
	if($Atmos::cleanup == "") {
		//%main = nameToID("MissionGroup\\Landscape");
		//for(%i = 0; %i < Group::objectCount(%main); %i++) {
		//	if(getObjectType(Group::getObject(%main,%i)) == "Sky" || getObjectType(Group::getObject(%main,%i)) == "Planet") // || getObjectType(Group::getObject(%main,%i)) == "SimTerrain")
		//		deleteObject(Group::getObject(%main,%i));
		//}
		%main = nameToID("MissionCleanup\\DynSky");
		if(%main == -1) {
			%group = newObject("DynSky",SimGroup,"Group");
			addToSet("MissionCleanup",%group);
		}
		%main = nameToID("MissionCleanup\\Atmos");
		if(%main == -1) {
			%group = newObject("Atmos",SimGroup,"Group");
			addToSet("MissionCleanup",%group);
		}
		%main = nameToID("MissionCleanup\\Lights");
		if(%main == -1) {
			%group = newObject("Lights",SimGroup,"Group");
			addToSet("MissionCleanup",%group);
		}
		$Atmos::cleanup = true;
	}

	if($Aeon::ActiveSky == true) {
		DynSun::update();
		DynSky::update();


	}

	if($Atmos::active)
		schedule("Atmos::loop();",$Atmos::updateTime);
}

//--------------------------------------------------------------
function DynSky::update()
{
	%state = Atmos::getState();
	%set = "MissionCleanup\\DynSky";
	%old = nameToID(%set@"\\DynSky");
	$DynSky::rotation += $DynSky::rotRate;
	if($DynSky::rotation >= 360 || $DynSky::rotation <= -360)
		$DynSky::rotation = 0;
	%acc = 0.05;
	if(Vector::compare($DynSky::RGBPhase,$DynSky::RGB[%state],%acc) != true) {
		%diff = Vector::sub($DynSky::RGBPhase,$DynSky::RGB[%state]);
		%x = 0;
		%y = 0;
		%z = 0;
		if(Calc::abs(getWord(%diff,0)) >= %acc)
			%x = %acc;
		else
			%x = Calc::abs(getWord(%diff,0));
		if(Calc::abs(getWord(%diff,1)) >= %acc)
			%y = %acc;
		else
			%y = Calc::abs(getWord(%diff,1));
		if(Calc::abs(getWord(%diff,2)) >= %acc)
			%z = %acc;
		else
			%z = Calc::abs(getWord(%diff,2));
		if(getWord(%diff,0) > 0)
			%x*=-1;
		if(getWord(%diff,1) > 0)
			%y*=-1;
		if(getWord(%diff,2) > 0)
			%z*=-1;
		$DynSky::Phasing = %x@" "@%y@" "@%z;
		%new = Vector::add($DynSky::RGBPhase,$DynSky::Phasing);
		$DynSky::RGBPhase = %new;
	}
	else {
		if($DynSky::Phasing != "init")
			$DynSky::Phasing = "";
		$DynSky::RGBPhase = $DynSky::RGB[%state];
	}
	if(%state == "Day") {
		if(%old > 0)
			deleteObject(%old);
		instant Sky "DynSky" {
			dmlName = $DynSky::Texture["Day"];
			skyColor = $DynSky::RGBPhase;
			hazeColor = $DynSky::Haze["Day"];
			featurePosition = $DynSky::rotation;
			size = 600*$DynSun::Flux;
			textures[0] = "0";
			textures[1] = "1";
			textures[2] = "2";
			textures[3] = "3";
			textures[4] = "4";
			textures[5] = "5";
			textures[6] = "6";
			textures[7] = "7";
			textures[8] = "8";
			textures[9] = "9";
			textures[10] = "10";
			textures[11] = "11";
			textures[12] = "12";
			textures[13] = "13";
			textures[14] = "14";
			textures[15] = "15";
			distance = "13000";
		};
		%sky = nameToID("DynSky");
		addToSet(%set,%sky);
	}
	else if(%state == "DawnDusk" && $DynSky::Phasing != "") {
		if(%old > 0)
			deleteObject(%old);
		instant Sky "DynSky" {
			dmlName = $DynSky::Texture["DawnDusk"];
			skyColor = $DynSky::RGBPhase;
			hazeColor = $DynSky::Haze["DawnDusk"];
			featurePosition = $DynSky::rotation;
			size = "600";
			textures[0] = "0";
			textures[1] = "1";
			textures[2] = "2";
			textures[3] = "3";
			textures[4] = "4";
			textures[5] = "5";
			textures[6] = "6";
			textures[7] = "7";
			textures[8] = "8";
			textures[9] = "9";
			textures[10] = "10";
			textures[11] = "11";
			textures[12] = "12";
			textures[13] = "13";
			textures[14] = "14";
			textures[15] = "15";
			distance = "100";
		};
		%sky = nameToID("DynSky");
		addToSet(%set,%sky);
	}
	else if(%state == "Night" && $DynSky::Phasing != "") {
		if(%old > 0)
			deleteObject(%old);
		instant Sky "DynSky" {
			dmlName = $DynSky::Texture["Night"];
			skyColor = $DynSky::RGBPhase;
			hazeColor = $DynSky::Haze["Night"];
			featurePosition = $DynSky::rotation;
			size = "600";
			textures[0] = "0";
			textures[1] = "1";
			textures[2] = "2";
			textures[3] = "3";
			textures[4] = "4";
			textures[5] = "5";
			textures[6] = "6";
			textures[7] = "7";
			textures[8] = "8";
			textures[9] = "9";
			textures[10] = "10";
			textures[11] = "11";
			textures[12] = "12";
			textures[13] = "13";
			textures[14] = "14";
			textures[15] = "15";
			distance = "100";
		};
		%sky = nameToID("DynSky");
		addToSet(%set,%sky);
	}
	if($DynSky::Phasing == "init")
		$DynSky::Phasing = "";
	$lastState = %state;
}

//%DynSun = newObject("DynSun",Planet,$DynSun::Texture,180,50,1,1,0.7,0.7,0.7,0.3,0.3,0.3);
//newObject("DynSun",Planet,(?texture?),(azimuth),(incendence),(shadows),(flare),(<dir int x>,<dir int y>,<dir int z>),(<amb int x>,<amb int y>,<amb int z>));
//addToSet("MissionCleanup\\DynSky",%DynSun);
//-Sun path should follow:
//	Sunrise: East	@ (270,0)
//	Noon:	 South	@ (180,45)
//	Sunset:	 West	@ (90,0)
//	Night:	 North	@ (0,-45)
//--------------------------------------------------------------
function DynSun::update()
{
	%lastState = Atmos::getState();
	%set = "MissionCleanup\\DynSky";
	%old = nameToID(%set@"\\DynSun");
	if(%old > 0)
		deleteObject(%old);
	%gName = "Property #"@%num;
	$DynSun::rotation[1] -= $DynSun::rotRate;
	if($DynSun::rotation[1] >= 360 || $DynSun::rotation[1] <= -360)
		$DynSun::rotation[1] = 0;
	if($DynSun::rotation[2] >= 360 || $DynSun::rotation[2] <= -360)
		$DynSun::rotation[2] = 0;
	$DynSun::rotation[2] -= $DynSun::rotRate;
	$DynSun::Flux = Calc::Sin(Calc::Rads($DynSun::rotation[2]));
	if(Atmos::getState() == "Day") {
		instant Planet "DynSun" {
			fileName = $DynSun::Texture["Day"];
			azimuth = 90+$DynSun::rotation[1];
			incidence = $DynSun::Zenith*$DynSun::Flux;
			castShadows = "True";
			useLensFlare = "True";
			intensity = "0.7 0.7 0.7";
			ambient = "0.3 0.3 0.3";
			size = 275-(150*$DynSun::Flux);
			distance = 1200;
		};
	}
	else if(Atmos::getState() == "DawnDusk") {
		instant Planet "DynSun" {
			fileName = $DynSun::Texture["DawnDusk"];
			azimuth = 90+$DynSun::rotation[1];
			incidence = $DynSun::Zenith*$DynSun::Flux;
			castShadows = "True";
			useLensFlare = "True";
			intensity = "0.7 0.7 0.7";
			ambient = "0.3 0.3 0.3";
			size = 275-(150*$DynSun::Flux);
			distance = 1200;
		};
	}
	else if(Atmos::getState() == "Night") {
		if($DynSun::moon == true) {
			instant Planet "DynSun" {
				fileName = $DynSun::Texture["Night"];
				azimuth = -(90+$DynSun::rotation[1]);
				incidence = -(($DynSun::Zenith/2)*$DynSun::Flux);
				castShadows = "True";
				useLensFlare = "false";
				intensity = "0.1 0.1 0.1";
				ambient = "0.1 0.1 0.1";
				size = 150;
				distance = 1200;
			};		
		}
	}
	%sun = nameToID("DynSun");
	if(%sun > 0)
		addToSet(%set,%sun);
	if(Atmos::getState() != %lastState)
		DynSky::onTrans(%lastState);
}

//--------------------------------------------------------------

function DynSky::onTrans(%last)
{
	%state = Atmos::getState();
	%set = "MissionCleanup\\DynSky";
	%oldStar = nameToID(%set@"\\DynStr");
	if(%oldStar > 0)
		deleteObject(%oldStar);
	if(%state == "Day") {
		
	}
	else if(%state == "DawnDusk") {
		if(%last == "Day") {
			
		}
		else if(%last == "Night") {

		}
	}
	else if(%state == "Night") {
		%randStar = getRandom();
		instant StarField "DynStr" {
			inFrontOfSky = "True";
			colors[0] = "1 1 1";
			colors[1] = %randStar/2@" "@%randStar/2@" "@%randStar/2;
			colors[2] = %randStar/4@" "@%randStar/4@" "@%randStar/4;
		};
		%stars = nameToID("DynStr");
		addToSet(%set,%stars);
	}
}

function Atmos::getState()
{
	if(Atmos::isDay())
		return Day;
	else if(Atmos::isDawnDusk())
		return DawnDusk;
	else if(Atmos::isNight())
		return Night;
	else
		return false;
}

function Atmos::isDay()
{
	if($DynSun::Flux > 0.3)
		return true;
	return false;
}

function Atmos::isDawnDusk()
{
	if($DynSun::Flux >= -0.2 && $DynSun::Flux <= 0.3)
		return true;
	return false;
}

function Atmos::isNight()
{
	if($DynSun::Flux < -0.2)
		return true;
	return false;
}

function DynSky::isTexture(%texture)
{
	if(%texture != "" && %texture != -1) {
		if(String::findSubStr(%texture,".dml") >= 0)
			return true;
		return false;
	}
	return false;
}

function DynWeather::call(%type)
{
	%group = nameToID("MissionCleanup\\DynWeather");
	if(Group::getObject(%group,0) > 0)
		return;
	if(%group == -1) {
		%group = newObject("DynWeather",SimGroup,"Group");
		addToSet("MissionCleanup",%group);
	}
	if(%type != "" && %type != -1)
		DynWeather::fadeIn(%type,(getRandom()*50)+5);
	else {
		if(%DynWeather = Group::getObject(%group,0) > 0)
			deleteObject(%DynWeather);
	}
}

function DynWeather::fadeIn(%type,%dur,%loop)
{
	if(!%loop || %loop < 0) {
		%loop = 1/($DynWeather::Update * %dur);
		%randX = getRandom();
		%randY = getRandom();
		if(%type == "Rain") {
			%DynWeather = newObject("Rain",SnowFall,1,%randX,%randY,1);
			//$Aeon::SeedRate  *= 1.25;
		}
		else if(%type == "Snow") {
			%DynWeather = newObject("Snow",SnowFall,1,%randX,%randY,0);
			//$Aeon::SeedRate  *= 0.75;
		}
		%DynWeather.windX = %randX;
		%DynWeather.windY = %randY;
		%DynWeather.type = %type;
		addToSet("MissionCleanup\\DynWeather",%DynWeather);
	}
	else if(%type > 0) {
		%loop += 1/($DynWeather::Update * %dur);
		%randX = %type.windX;
		%randY = %type.windY;
		%old = %type;
		%type = %type.type;
		deleteObject(%old);
		if(%type == "Rain") {
			%DynWeather = newObject("Rain",SnowFall,%loop,%randX,%randY,1);
		}
		else if(%type == "Snow") {
			%DynWeather = newObject("Snow",SnowFall,%loop,%randX,%randY,0);
		}
		%DynWeather.windX = %randX;
		%DynWeather.windY = %randY;
		%DynWeather.type = %type;
		addToSet("MissionCleanup\\DynWeather",%DynWeather);
	}
	else
		echo("WTF?!");
	if(%loop < 1)
		schedule("DynWeather::fadeIn("@%DynWeather@","@%dur@","@%loop@");",$DynWeather::Update);
	else
		schedule("DynWeather::fadeOut("@%DynWeather@","@%dur@");",$DynWeather::DefDie);
}

function DynWeather::fadeOut(%Dyn,%dur,%loop)
{
	%loop -= 1/($DynWeather::Update * %dur);
	%old = %Dyn;
	%randX = %Dyn.windX;
	%randY = %Dyn.windY;
	%type = %Dyn.type;
	deleteObject(%old);
	if(%type == "Rain") {
		%DynWeather = newObject("Rain",SnowFall,%loop,%randX,%randY,1);
	}
	else if(%type == "Snow") {
		%DynWeather = newObject("Snow",SnowFall,%loop,%randX,%randY,0);
	}
	%DynWeather.windX = %randX;
	%DynWeather.windY = %randY;
	%DynWeather.type = %type;
	addToSet("MissionCleanup\\DynWeather",%DynWeather);
	if(%loop > 0)
		schedule("DynWeather::fadeOut("@%DynWeather@","@%dur@","@%loop@");",$DynWeather::Update);
	else {
		//if(%type == "Rain")
		//	$Aeon::SeedRate  /= 1.25;
		//else if(%type == "Snow")
		//	$Aeon::SeedRate  /= 0.75;			
		deleteObject(%DynWeather);
	}
}

function DynWeather::isRaining()
{
	%group = nameToID("MissionCleanup\\DynWeather");
	%DynWeather = Group::getObject(%group,0);
	if(%DynWeather.type == "Rain")
		return true;
	return false;
}

function DynWeather::isSnowing()
{
	%group = nameToID("MissionCleanup\\DynWeather");
	%DynWeather = Group::getObject(%group,0);
	if(%DynWeather.type == "Snow")
		return true;
	return false;
}

function Aeon::rockMan(%player)
{
	%clientId = Player::getClient(%player);
	if(%clientId != -1) {
		if(GameBase::getLOSInfo(%player,5000)) {
			Aeon::rockCall($los::position);
			bottomPrint2(%clientId,"<jc><f3>Meteor Coming!",1,"Error_Message.wav");
		}
	}
}

function Aeon::rockCall(%pos)
{
	if(Client::getFirst() < 2049)
		return;
	%z = $Aeon::rockHght;
	%cleanup = nameToID("MissionCleanup\\Atmos");
	if(%cleanup == -1) {
		%cleanup = newObject("Atmos",SimGroup,"Group");
		addToSet("MissionCleanup",%cleanup);
	}
	%OriX = -420+(ranDim(3070-%z));
	%OriY = -650+(ranDim(3070-%z));
	%Orgn = %OriX@" "@%OriY@" "@%z;
	%TRot = (((-2+ranDim(1))*$Pi)/4)@" "@(((-2+ranDim(1))*$Pi)/4)@" 0";
	if(%pos != -1 && %pos != "") {
		%Orgn = getWord(%pos,0)+ranDim(%z/2)@" "@getWord(%pos,1)+ranDim(%z/2)@" "@%z;
		%TRot = Vector::getRotAim(%Orgn,%pos);
	}
	%temp = newObject("",StaticShape,"rockTemp",true);
	addToSet("MissionCleanup",%temp);
	GameBase::setPosition(%temp,%Orgn);
	GameBase::setRotation(%temp,%TRot);
	addToSet("MissionCleanup\\Atmos",%temp);
	schedule("Aeon::rockFall("@%temp@");",$Aeon::rockHold,%temp);
}

function Aeon::rockFall(%rock)
{
	if(%rock == -1)
		return;
	if(!%rock.cancel) {
		%trans = GameBase::getMuzzleTransform(%rock);
		%vec = Vector::getFromRot(GameBase::getRotation(%rock),30+ranDim(10));
		%proj = projectile::spawnProjectile("rockProj1",%trans,%rock,%vec);
		addToSet("MissionCleanup\\Atmos",%proj);
	}
	if(%rock)
		deleteObject(%rock);
}

function Aeon::rockImpact(%pos)
{
	%pos = Vector::add(%pos,"0 0 0.1");
	%rot  = "0 0 0";
	%closest = 1000;
	for(%cl = Client::getFirst(); %cl != -1; %cl = Client::getNext(%cl)) {
		%dist = Vector::getDistance(%pos,GameBase::getPosition(%cl));
		if(%dist < %closest && %dist != -1)
			%closest = %dist;
	}
	if(%closest < 500) {
		for(%i = -$Pi; %i <= $Pi; %i += $Pi/5) {
			%newRot = Vector::Add(%rot,"0 0 "@%i);
			%newVec = Vector::getFromRot(%newRot,0.5);
			%trans = %rot@" "@%newVec@" "@%rot@" "@%pos;
			Projectile::spawnProjectile(rockSpark,%trans,2048,%newVec);
		}
		Projectile::spawnProjectile(rockSmoke,"1 0 0 0 1 0 0 0 1 "@%pos,2048,"0 0 10");
	}
	%seis = %pos@" "@$Aeon::SeisRad["Meteor"];
	Seismic::addToNetwork(%seis);
	Seismic::Quake("","","Meteor",%pos);
	schedule("Seismic::removeFromNetwork(\""@%seis@"\");",30);
	if(Aeon::inProperty(%pos))
		return;
	for(%i = 1; %i <= 6; %i++) {
		%rock[%i] = newObject("",InteriorShape,"lrock"@%i@".dis");
		if(%i == 1) {
			$Aeon::impactSite[%rock[%i]] = %pos;
			%Group = newObject("ImpactSite #"@%rock[1],SimGroup,"Group");
			addToSet("MissionCleanup\\Atmos",%Group);
		}
		addToSet("MissionCleanup\\Atmos\\ImpactSite #"@%rock[1],%rock[%i]);
		%newRot = Vector::Add(%rot,"0 0 "@2*((%i*$Pi)/6));
		%newVec = Vector::getFromRot(%newRot,15+ranDim(5));
		%newPos = Vector::add(%pos,%newVec);
		if(getLOSInfo(%newPos,Vector::add(%newPos,"0 0 -50"),1))
			%newPos = Vector::add($los::position,"0 0 0");
		else
			%newPos = Vector::add(%newPos,"0 0 1");
		%prop = Aeon::inProperty(%newPos);
		if(%prop != false) {
			deleteObject(%rock[%i]);
			return;
		}
		GameBase::setRotation(%rock[%i],Vector::add(Vector::mult(Vector::normalize(%newRot),"180 180 180"),"0 90 0"));
		GameBase::setPosition(%rock[%i],%newPos);
		%rock[%i].isRock = getSimTime();
		schedule("Aeon::rockHulk("@%group@");",$Aeon::rockStay*60,%group);
	}
	$impactCount++;
}

function Aeon::rockHulk(%group)
{
	if(%group == -1)
		return;
	$impactCount--;
	deleteObject(%group);
}

function Aeon::rockConvert(%rock)
{
	%group = getGroup(%rock);
	deleteObject(%rock);
	%rocks = Group::objectCount(%group);
	if(%rocks < 1) {
		deleteObject(%group);
		$impactCount--;
	}
}

function Aeon::rockToCash(%clientId,%rock)
{
	%max = $Aeon::rockValue + ($Aeon::rockAdd*Skill::getSkillRatio(%clientId,geol));
	%fresh = 1-((getSimTime()-%rock.isRock)/($Aeon::rockStay*60));
	%val = floor(%max*%fresh);
	%id = Aeon::getAeonID(%clientId);
	$Aeon::ClientInfo[%id,cash]+=%val;
	Karma::result(%id,"farm Meteor");
	bottomPrint2(%clientId,"<jc><f1>You got $"@%val@"!",5,"BuySellSound.wav");
	Aeon::rockConvert(%rock);
}

function Seismic::compare(%pos1,%pos2,%acc)
{
	%rad1 = getWord(%pos1,3);
	%rad2 = getWord(%pos2,3);
	%pos1 = getWord(%pos1,0)@" "@getWord(%pos1,1)@" "@getWord(%pos1,2);
	%pos2 = getWord(%pos2,0)@" "@getWord(%pos2,1)@" "@getWord(%pos2,2);
	if(!%acc || %acc < 0)
		%acc = 1;
	%dist = Vector::getDistance(%pos1,%pos2);
	if(Calc::abs(%dist) < %acc)
		return true;
	return false;
}

function Seismic::addToNetwork(%pos)
{
	%num = Seismic::getAddr(%pos);
	$Aeon::Seismic[%num] = %pos;
}

function Seismic::getAddr(%pos)
{
	for(%i = 0; $Aeon::Seismic[%i] != ""; %i++) {
		if(Seismic::compare($Aeon::Seismic[%i],%pos,2))
			return %i;
	}
	return %i;
}

function Seismic::removeFromNetwork(%pos)
{
	%found = false;
	for(%i = 0; $Aeon::Seismic[%i] != ""; %i++) {
		if(Seismic::compare($Aeon::Seismic[%i],%pos,2))
			%found = true;
		if(%found == true)
			$Aeon::Seismic[%i] = $Aeon::Seismic[%i+1];
	}
	$Aeon::Seismic[%i] = "";
}

function Seismic::strNetwork()
{
	%str = "";
	for(%i = 0; $Aeon::Seismic[%i] != ""; %i++)
		%str = %str@$Aeon::Seismic[%i]@", ";
	return %str;
}

function Aeon::inQuake()
{
	if($Aeon::inQuake == true)
		return true;
	return false;
}

function Seismic::Quake(%intens,%dur,%type,%pos)
{
	if(Aeon::inQuake())
		return;
	if(%type == "")
		%type = "EarthQuake";
	if(%intens == "")
		%intens = $Aeon::QuakeInt[%type];
	if(%dur == "")
		%dur = $Aeon::QuakeDur[%type];
	%dur += ranDim(%dur/10);
	%count = $Aeon::QuakeSeq[%type]*(10*%dur);
	if($Aeon::QuakeSeq[%type] > 0)
		%dur = %dur / $Aeon::QuakeSeq[%type];
	$Aeon::inQuake = true;
	//echo(%intens@", "@%count@", "@%type@", "@%pos);
	Seismic::shake(%intens,%count,%type,%pos);
	schedule("$Aeon::inQuake = \"\";",%dur);
}

function Seismic::shake(%intens,%count,%type,%pos)
{
	if($Aeon::inQuake == true) {
		if(!%count)
			%count = 0;
		%dur = $Aeon::QuakeDur[%type];
		if($Aeon::QuakeSeq[%type] > 0)
			%dur = %dur / $Aeon::QuakeSeq[%type];
		%int = %intens*Calc::sin($Pi*(%count++/(10*%dur)));
		if(%int < 0)
			return;
		%randX = ranDim(%int);
		%randY = ranDim(%int);
		%randZ = ranDim(%int/3);
		%vec1 = %randX@" "@%randY@" "@%randZ/2;
		%vec2 = "0 0 "@%randZ/4;
		Shakeable::cleanNetwork();
		%affect = 0;
		for(%i = 0; $Aeon::Shakeable[%i] != ""; %i++) {
			%obj = $Aeon::Shakeable[%i];
			%dist = Vector::getDistance(GameBase::getPosition(%obj),%pos);
			%rad = $Aeon::QuakeRad[%type];
			if(%pos == "" || %dist <= %rad) {
				%mult = 1;
				if(%pos != "")
					%mult = (%rad-%dist)/%rad;
				%vec1 = Vector::mult(%vec1,%mult@" "@%mult@" "@%mult);
				%vec2 = Vector::mult(%vec2,%mult@" "@%mult@" "@%mult);
				if(Player::getLastContactCount(%obj) > 2)
					Player::applyImpulse(%obj,%vec2);
				else if(Player::getLastContactCount(%obj) >= 0)
					GameBase::applyImpulse(%obj,%vec1);
				else
					GameBase::applyImpulse(%obj,%vec1);
				%affect++;
			}
		}
		if(%pos != "" && %affect < 1) {
			$Aeon::inQuake = "";
			return;
		}
		schedule("Seismic::shake("@%intens@","@%count@",\""@%type@"\",\""@%pos@"\");",0.1+ranDim(0.05));
	}
}

function Shakeable::cleanNetwork()
{
	for(%i = 0; $Aeon::Shakeable[%i] != ""; %i++) {
		%obj = $Aeon::Shakeable[%i];
		if(GameBase::getDataName(%obj) == "")
			Shakeable::removeFromNetwork(%obj);
	}
}

function Shakeable::addToNetwork(%this)
{
	%num = Shakeable::getAddr(%this);
	$Aeon::Shakeable[%num] = %this;
}

function Shakeable::getAddr(%this)
{
	for(%i = 0; $Aeon::Shakeable[%i] != ""; %i++) {
		if($Aeon::Shakeable[%i] == %this)
			return %i;
	}
	return %i;
}

function Shakeable::removeFromNetwork(%this)
{
	%found = false;
	for(%i = 0; $Aeon::Shakeable[%i] != ""; %i++) {
		if($Aeon::Shakeable[%i] == %this)
			%found = true;
		if(%found == true)
			$Aeon::Shakeable[%i] = $Aeon::Shakeable[%i+1];
	}
	$Aeon::Shakeable[%i] = "";
}

function rockProj1::onAdd(%this)
{
	GameBase::setMapName(%this,"Rock");
	Rock::spark(%this);
}

function rockProj1::onRemove(%this)
{
	Aeon::rockImpact($tempPos[%this]);
}

function Rock::spark(%this)
{
	%pos = Vector::add(GameBase::getPosition(%this),"0 0 2");
	%rot = GameBase::getRotation(%this);
	%vel = Item::getVelocity(%this);
	%vec = Vector::getFromRot(%rot,5);
	%trans = %rot@" "@%vec@" "@%rot@" "@%pos;
	%proj = Projectile::spawnProjectile(rockSpark,%trans,2048,%vel);
	addToSet("MissionCleanup\\Atmos",%proj);
	$tempPos[%this] = GameBase::getPosition(%this);
	schedule("Rock::spark("@%this@");",0.2,%this);
}

function ranDim(%dim)
{
	%rand = %dim*(2*getRandom()-1);
	return %rand;
}