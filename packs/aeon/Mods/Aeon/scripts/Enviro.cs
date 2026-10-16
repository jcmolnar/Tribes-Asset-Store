//- Aeon Inventory system
$Aeon::invStyle[Vege_MariJ] = "held";
$Aeon::invStyle[Vege_Corn] = "held";
$Aeon::invStyle[Vege_Potatoe] = "held";
$Aeon::invStyle[Vege_Tomatoe] = "held";
$Aeon::invStyle[Vege_Soybean] = "held";
$Aeon::invStyle[Vege_Hevea] = "held";
$Aeon::invStyle[Vege_Indigo] = "held";
$Aeon::invStyle[Vege_Wheat] = "held";
$Aeon::invStyle[Vege_Yam] = "held";
$Aeon::invStyle[Vege_Bamboo] = "held";
$Aeon::invStyle[Seed_MariJ] = "held";
$Aeon::invStyle[Seed_Corn] = "held";
$Aeon::invStyle[Seed_Potatoe] = "held";
$Aeon::invStyle[Seed_Tomatoe] = "held";
$Aeon::invStyle[Seed_Soybean] = "held";
$Aeon::invStyle[Seed_Hevea] = "held";
$Aeon::invStyle[Seed_Indigo] = "held";
$Aeon::invStyle[Seed_Wheat] = "held";
$Aeon::invStyle[Seed_Yam] = "held";
$Aeon::invStyle[Seed_Bamboo] = "held";
$Aeon::invStyle[Ore_Lead] = "held";
$Aeon::invStyle[Ore_Iron] = "held";
$Aeon::invStyle[Ore_Tin] = "held";
$Aeon::invStyle[Ore_Aluminum] = "held";
$Aeon::invStyle[Ore_Copper] = "held";
$Aeon::invStyle[Ore_Titanium] = "held";
$Aeon::invStyle[Ore_Silver] = "held";
$Aeon::invStyle[Ore_Gold] = "held";
$Aeon::invStyle[Ore_Platinum] = "held";
$Aeon::invStyle[Mineral_Carbon] = "held";
$Aeon::invStyle[Mineral_Sulfur] = "held";
$Aeon::invStyle[Mineral_Phosph] = "held";
$Aeon::invStyle[Mineral_Powder] = "held";

//- Future enviromental vegetation, ect. containment file
$Aeon::SeedRate  = 1.0;
$Aeon::SeedMax = 50;
$Aeon::SeedCeiling = 20;

$Aeon::SeedShape[0] = "Vege1";
$Aeon::SeedShape[1] = "Vege2";
$Aeon::SeedShape[2] = "Ore1";

//- Default Descriptions for the harvest shapes
$Aeon::SeedDefDesc["Vege1"] = "A Piece of Vegetation";
$Aeon::SeedDefDesc["Vege2"] = "A Piece of Vegetation";
$Aeon::SeedDefDesc["Ore1"]  = "A Chunk of Ore";

$Aeon::relativeSkill["Vege1"] = "aggr";
$Aeon::relativeSkill["Vege2"] = "aggr";
$Aeon::relativeSkill["Ore1"] = "metl";

//- Rough max field radius, seedable range from center
$Aeon::SeedFieldRadius["Vege1"] = 10.0;
$Aeon::SeedFieldRadius["Vege2"] = 10.0;
$Aeon::SeedFieldRadius["Ore1"]  = 2.0;

//- Default seed stage times, Total Time: 302 (old: 112)
$Aeon::SeedAgeTime["",1] = 100.0; // time till mature (old: 40)
$Aeon::SeedAgeTime["",2] = 100.0; // time till ripe (old: 40)
$Aeon::SeedAgeTime["",3] = 60.0; // time till seeds (old: 20)
$Aeon::SeedAgeTime["",4] = 40.0; // time between each seed (old: 10)
$Aeon::SeedAgeTime["",5] = 2.0;  // time to die after last seed (old: 2)
//- Special case "Ore" stage times, Total Time: 165
$Aeon::SeedAgeTime["Ore1",1] = 120.0; // time till full size
$Aeon::SeedAgeTime["Ore1",2] = 5.0;  // time till harvestable
$Aeon::SeedAgeTime["Ore1",3] = 20.0; // time till seeds
$Aeon::SeedAgeTime["Ore1",4] = 15.0;  // time between each seed
$Aeon::SeedAgeTime["Ore1",5] = 5.0;  // time to die after last seed

//- Seed Plant types
$Aeon::SeedPlant["Seed_MariJ"]   = "Vege_MariJ";
$Aeon::SeedPlant["Seed_Corn"]	 = "Vege_Corn";
$Aeon::SeedPlant["Seed_Potatoe"] = "Vege_Potatoe";
$Aeon::SeedPlant["Seed_Tomatoe"] = "Vege_Tomatoe";
$Aeon::SeedPlant["Seed_Soybean"] = "Vege_Soybean";
$Aeon::SeedPlant["Seed_Indigo"]  = "Vege_Indigo";
$Aeon::SeedPlant["Seed_Wheat"]   = "Vege_Wheat";
$Aeon::SeedPlant["Seed_Hevea"]   = "Vege_Hevea";
$Aeon::SeedPlant["Seed_Bamboo"]  = "Vege_Bamboo";
$Aeon::SeedPlant["Seed_Yam"]     = "Vege_Yam";

//- Harvest Object Types (image data association)
$Aeon::SeedType["Vege1",0] = "Vege_MariJ";
$Aeon::SeedType["Vege1",1] = "Vege_Corn";
$Aeon::SeedType["Vege1",2] = "Vege_Potatoe";
$Aeon::SeedType["Vege1",3] = "Vege_Tomatoe";
$Aeon::SeedType["Vege1",4] = "Vege_Soybean";
$Aeon::SeedType["Vege1",5] = "Vege_Indigo";
$Aeon::SeedType["Vege1",6] = "Vege_Wheat";
$Aeon::SeedType["Vege2",0] = "Vege_Hevea";
$Aeon::SeedType["Vege2",1] = "Vege_Bamboo";
$Aeon::SeedType["Vege2",2] = "Vege_Yam";

$Aeon::SeedType["Ore1",0] = "Ore_Lead";
$Aeon::SeedType["Ore1",1] = "Ore_Iron";
$Aeon::SeedType["Ore1",2] = "Ore_Tin";
$Aeon::SeedType["Ore1",3] = "Ore_Aluminum";
$Aeon::SeedType["Ore1",4] = "Ore_Copper";
$Aeon::SeedType["Ore1",5] = "Ore_Titanium";
$Aeon::SeedType["Ore1",6] = "Ore_Silver";
$Aeon::SeedType["Ore1",7] = "Ore_Gold";
$Aeon::SeedType["Ore1",8] = "Ore_Platinum";
$Aeon::SeedType["Ore1",9] = "Mineral_Carbon";
$Aeon::SeedType["Ore1",10] = "Mineral_Sulfur";
$Aeon::SeedType["Ore1",11] = "Mineral_Phosph";

//- Item types are harvestable?
$Aeon::Harvestable[Vege_MariJ] = true;
$Aeon::Harvestable[Vege_Corn] = true;
$Aeon::Harvestable[Vege_Potatoe] = true;
$Aeon::Harvestable[Vege_Tomatoe] = true;
$Aeon::Harvestable[Vege_Soybean] = true;
$Aeon::Harvestable[Vege_Hevea] = true;
$Aeon::Harvestable[Vege_Indigo] = true;
$Aeon::Harvestable[Vege_Wheat] = true;
$Aeon::Harvestable[Vege_Yam] = true;
$Aeon::Harvestable[Vege_Bamboo] = true;

$Aeon::Harvestable[Ore_Iron]  = true;
$Aeon::Harvestable[Ore_Lead]  = true;
$Aeon::Harvestable[Ore_Tin]  = true;
$Aeon::Harvestable[Ore_Aluminum]  = true;
$Aeon::Harvestable[Ore_Copper]  = true;
$Aeon::Harvestable[Ore_Titanium]  = true;
$Aeon::Harvestable[Ore_Silver]  = true;
$Aeon::Harvestable[Ore_Gold]  = true;
$Aeon::Harvestable[Ore_Platinum]  = true;
$Aeon::Harvestable[Mineral_Carbon]  = true;
$Aeon::Harvestable[Mineral_Sulfur]  = true;
$Aeon::Harvestable[Mineral_Phosph]  = true;

//- Seed crystal growth formation?
$Aeon::SeedCrystal["Vege1"] = false;
$Aeon::SeedCrystal["Vege2"] = false;
$Aeon::SeedCrystal["Ore1"]  = true;

//- Needs light to live/grow?
$Aeon::SeedPhotoSynth["Vege1"] = true;
$Aeon::SeedPhotoSynth["Vege2"] = true;
$Aeon::SeedPhotoSynth["Ore1"]  = false;

//- Sway reaction when touched?
$Aeon::SeedCanSway["Vege1"] = true;
$Aeon::SeedCanSway["Vege2"] = true;
$Aeon::SeedCanSway["Ore1"]  = false;

//- How far does the object sink to grow from
$Aeon::SeedSink["Vege1"] = -1.9;
$Aeon::SeedSink["Vege2"] = -1.9;
$Aeon::SeedSink["Ore1"]  = -0.5;

//- Do we want to offset the object's position upon creation?
$Aeon::SeedPosOffset["Vege1"] = "0 0 -0.4";
$Aeon::SeedPosOffset["Vege2"] = "0 0 -0.4";
$Aeon::SeedPosOffset["Ore1"]  = "0 0 0";

//- Do we want to offset the object's rotation upon creation?
$Aeon::SeedRotOffset["Vege1"] = "0 0 0";
$Aeon::SeedRotOffset["Vege2"] = "0 0 0";
$Aeon::SeedRotOffset["Ore1"]  = "0 0 0";

//- How many seeds does each plant carry?
$Aeon::SeedCount["Vege1"] = 3.0;
$Aeon::SeedCount["Vege2"] = 3.0;
$Aeon::SeedCount["Ore1"]  = 2.0;

//- A rough radius of where to drop seeds
$Aeon::SeedRadius["Vege1"] = 2.8;
$Aeon::SeedRadius["Vege2"] = 2.4;
$Aeon::SeedRadius["Ore1"]  = 0.5;

//- Rough cubical dimensions of seed object
$Aeon::SeedDims["Vege1"] = 2.0;
$Aeon::SeedDims["Vege2"] = 2.0;
$Aeon::SeedDims["Ore1"]  = 0.35;

function Aeon::plantSeed(%pos,%type)
{
	%plant = $Aeon::SeedPlant[%type];
	%data = Harvest::getShape(%plant);
	return Aeon::vegetate(%pos,%data,%plant);
}

function Aeon::vegetate(%pos,%data,%type)
{
	%group = nameToID("MissionCleanup\\Vegetation");
	if(%group == -1) {
		%group = newObject("Vegetation",SimGroup,"Group");
		addToSet("MissionCleanup",%group);
	}
	if(%pos == "" || %pos == "0 0 0" || %pos == -1) {
		%OriX = 420+ranDim(3070);
		%OriY = 650+ranDim(3070);
		%OriZ = Property::terrainHeight(%OriX@" "@%OriY);
		%Orgn = %OriX@" "@%OriY@" "@%OriZ;
	}
	else
		%Orgn = %pos;
	%Orgn = Harvest::findSeedable(%Orgn,"0 0 0",10);
	if(%Orgn == false)
		return false;
	%Orgn = Vector::add(%Orgn,$Aeon::SeedPosOffset[%data]);
	%seed = newObject("plant",StaticShape,%data,true);
	addToSet("MissionCleanup\\Vegetation",%seed);
	GameBase::setPosition(%seed,%Orgn);
	$lastPos[%seed] = %Orgn;
	if(%type == "")
		%type = floor(getRandom()*Harvest::getTypeCount(%data));
	else
		%type = Harvest::getTypeNum(%data,%type);
	%seed.fldCntr = %Orgn;
	Harvest::init(%seed,%type);
	return true;
}

function Harvest::onAdd(%this)
{
	Shakeable::removeFromNetwork(%this);
}

function Harvest::init(%seed,%type)
{
	%data = GameBase::getDataName(%seed);
	%pos = GameBase::getPosition(%seed);
	%rot = $Aeon::SeedRotOffset[%data];
	%sink = Vector::add(%pos,"0 0 "@$Aeon::SeedSink[%data]);
	GameBase::setPosition(%seed,%sink);
	GameBase::setMapName(%seed,"Plant");
	%seed.seedCnt = $Aeon::SeedCount[%data];
	%seed.age = 0;
	%seed.rate = 1.0+ranDim(0.5);
	%seed.moved = 0;
	%seed.spark = 0;
	%seed.canSway = true;
	%seed.type = %type;
	%seed.createTime = getSimTime();
	if(%seed.parent && $Aeon::SeedCrystal[%data] == true)
		%rot = Vector::getRotAim(%pos,Vector::add(GameBase::getPosition(%seed.parent),"0 0 "@getRandom()/2));
	GameBase::setRotation(%seed,%rot);
	Harvest::grow(%seed);
}

function Harvest::getTypeNum(%data,%type)
{
	for(%i = 0; $Aeon::SeedType[%data,%i] != ""; %i++) {
		if($Aeon::SeedType[%data,%i] == %type)
			return %i;
	}
	return false;
}

function Harvest::getCount()
{
	%seedManager = nameToID("MissionCleanup\\Vegetation");
	%count = Group::objectCount(%seedManager);
	return %count;
}

function Harvest::getTypeCount(%data)
{
	%count = 0;
	for(%i = 0; $Aeon::SeedType[%data,%i] != ""; %i++)
		%count++;
	return %count;
}

function Harvest::getShape(%plant)
{
	for(%i = 0; $Aeon::SeedShape[%i] != ""; %i++) {
		if(Harvest::inShape(%plant,$Aeon::SeedShape[%i]))
			return $Aeon::SeedShape[%i];
	}
	return false;
}

function Harvest::inShape(%plant,%shape)
{
	for(%i = 0; $Aeon::SeedType[%shape,%i] != ""; %i++) {
		if($Aeon::SeedType[%shape,%i] == %plant)
			return true;
	}
	return false;
}

function Harvest::die(%seed)
{
	if(%seed.age != 5) {
		%seed.age = 5;
		Harvest::grow(%seed);
	}
}

function Harvest::grow(%seed)
{
	%data = GameBase::getDataName(%seed);
	if(!%seed || %seed < 5 || %seed.cnGrabber || %data == "" || %data == false || %data == -1)
		return;
	if($Aeon::SeedPhotoSynth[%data] == true && (Harvest::hasRoof(%seed) == true)) {
		if(!Aeon::inLight(%seed)) {
			if(%seed.age != 5)
				%seed.age = 5;
		}
	}
	%age = %seed.age;
	%pos = GameBase::getPosition(%seed);
	%rot = GameBase::getRotation(%seed);
	if(%age <= 0) {
		//- We are a growing seed, under ground right now
		%ageTime = $Aeon::SeedAgeTime[%data,%age+1];
		if(!%ageTime)
			%ageTime = $Aeon::SeedAgeTime["",%age+1];
		if(%seed.moved < -$Aeon::SeedSink[%data]) {
			%update = 1.0/$Aeon::SeedRate;
			%up = -$Aeon::SeedSink[%data] / %ageTime / %update;
			%pos = Vector::add(%pos,"0 0 "@%up);
			GameBase::setPosition(%seed,%pos);
			%seed.moved += %up;
		}
		else {
			%age = %seed.age++;
			%seed.origRot = %rot;
			$lastPos[%seed] = %pos;
		}
	}
	%ageTime = $Aeon::SeedAgeTime[%data,%age+1];
	if(!%ageTime)
		%ageTime = $Aeon::SeedAgeTime["",%age+1];
	if(%age == 1) {
		//- hmm... can't think of anything to do at maturity...
		%seed.lastAgeTime = getSimTime();
		%update = %ageTime/$Aeon::SeedRate;
		%seed.age++;
	}
	else if(%age == 2) {
		//- we are ripe! fire a ... ripe spark...
		%seed.isRipe = true;
		%aim = Vector::Add(%rot,$Pi/2@" 0 0");
		%trans = %rot@" "@Vector::getFromRot(%aim,0.9)@" "@%rot@" "@%pos;
		if(String::findSubStr(%trans,"NAN") != -1) {
			messageAll(0,"FARK!");
			%trans = %rot@" "@Vector::getFromRot($Pi@" 0 0",0.9)@" "@%rot@" "@%pos;
		}
		%spark = projectile::spawnProjectile("VegeRipeSpark",%trans,%seed,"0 0 0");
		%seed.seedFail = 0;
		%update = %ageTime/$Aeon::SeedRate;
		%seed.age++;
	}
	else if(%age == 3) {
		//- time to spread those seeds if we aren't picked yet
		if(%seed.seedCnt >= 1) {
			%update = %ageTime/$Aeon::SeedCount[%data]/$Aeon::SeedRate;
			%Orgn = Harvest::findSeedable(%pos,%rot,$Aeon::SeedCount[%data]+%seed.seedFail,true,true,%seed);
			%count = Harvest::getCount();
			if(%Orgn == false || %count >= $Aeon::SeedMax) {
				if(%seed.seedFail < 10)
					%seed.seedFail++;
				else
					%seed.seedCnt = 0;
			}
			else {
				%height2 = 2.0;
				%pos = Vector::add(%pos,"0 0 "@$Aeon::SeedCeiling);
				%aPos = Vector::sub(%pos,"0 0 "@$Aeon::SeedCeiling + 10);
				getLOSInfo(%pos,%aPos,1);
				if(GameBase::getDataName($los::object).className == "Window" || $Aeon::SeedPhotoSynth[%data] != true) {
					%pos = Vector::sub(%pos,"0 0 "@($Aeon::SeedCeiling-%height2));
					if($Aeon::SeedPhotoSynth[%data] != true)
						%pos = Vector::sub(%pos,"0 0 10");
					%aPos = Vector::sub(%pos,"0 0 10");
					getLOSInfo(%pos,%aPos,1);
				}
				if(getObjectType($los::object) == "SimTerrain") {
					%height = Vector::add($Aeon::SeedPosOffset[%data],"0 0 "@getWord($los::position,2));
					%Orgn = Vector::splice(%Orgn,%Orgn,%height);
					%newSeed = newObject("plant",StaticShape,%data,true);
					addToSet("MissionCleanup\\Vegetation",%newSeed);
					GameBase::setPosition(%newSeed,%Orgn);
					%newSeed.parent = %seed;
					%newSeed.fldCntr = %seed.fldCntr;
					Harvest::init(%newSeed,%seed.type);
					%seed.seedCnt--;
				}
			}
		}
		else {
			%update = %ageTime/$Aeon::SeedRate;
			%seed.age++;
		}
	}
	else if(%age == 4) {
		//- now... we wait to die... or maybe a dieing process...
		%update = %ageTime*$Aeon::SeedRate;
		%seed.age++;
	}
	else if(%age == 5) {
		//- time to die stupid plant, no more update for you
		%seed.isRipe = false;
		Harvest::wither(%seed);
	}
	if(%update != "" && %update > -1 && !%seed.cnGrabber)
		schedule("Harvest::grow("@%seed@");",(%update/%seed.rate)*$Atmos::updateTime,%seed);
}

function Integer(%oNum)
{
	%Num = RadnomItems(2, "", "-");
	%Num = %Num@%oNum;
	return %Num;
}

function Harvest::wither(%seed)
{
	if(!%seed)
		return;
	%maxRot = 2.2;
	%rot = GameBase::getRotation(%seed);
	%rotX = getWord(%rot,1);
	%rotY = getWord(%rot,0);
	if(Calc::abs(Calc::abs(%rotY) - $Pi/%maxRot) > 0.1)
	{
		%randY = $Pi*getRandom()/4;
		%randZ = Integer($Pi)/4;
		%newRot = Vector::add(%rot,%randY@" 0 "@%randZ);
		GameBase::setRotation(%seed,%newRot);
		schedule("Harvest::wither("@%seed@");",0.2,%seed);
	}
	else
		schedule("deleteObject("@%seed@");",1,%seed);
}

function Harvest::hasRoof(%seed,%strict)
{
	if(!%seed)
		return;
	%pos = GameBase::getPosition(%seed);
	%set = newObject("set",SimSet);
	%num = containerBoxFillSet(%set,$StaticObjectType | $SimInteriorObjectType,%pos,1,1,$Aeon::SeedCeiling,-$Aeon::SeedCeiling/2);
	if(%num > 1) {
		if(%strict) {
			deleteObject(%set);
			return true;
		}
		if(%num > 1 && (Harvest::areGlass(%set,%seed,"Harvest") != false)) {
			deleteObject(%set);
			return glass;
		}
		deleteObject(%set);
		return true;
	}
	deleteObject(%set);
	return false;
}

function Harvest::pick(%seed)
{
	if(!%seed)
		return;
	%data = GameBase::getDataName(%seed);
	%pos = GameBase::getPosition(%seed);
	%rot = GameBase::getRotation(%seed);
	%item = newObject("plant","Item",$Aeon::SeedType[%data,%seed.type],1,false);
	addToSet("MissionCleanup\\Vegetation",%item);
	GameBase::setPosition(%item,%pos);
	GameBase::setRotation(%item,%rot);
	deleteObject(%seed);
	schedule("deleteObject("@%item@");",120,%item);
	return %item;
}

function Harvest::findSeedable(%pos,%rot,%ac,%randRot,%randDst,%seed)
{
	if(Harvest::canSeed(%pos,%seed))
		return %pos;
	if(!%seed || %seed.cnGrabber)
		return false;
	%x = getWord(%rot,0);
	for(%i = 0; %i < 2*$Pi-0.1; %i += (2*$Pi)/%ac) {
		%rad = $Aeon::SeedRadius[GameBase::getDataName(%seed)];
		if(%randRot == true)
			%x += ranDim($Pi);
		if(%randDst == true)
			%rad += ((%rad*getRandom())/3);
		%test = Vector::add(%pos,Vector::getFromRot("0 0 "@%x+%i,%rad,0));
		if(Harvest::canSeed(%test,%seed)) {
			//if(GameBase::getLOSInfo(%seed,4)) {
			//	
			//}
			return %test;
		}
	}
	return false;
}

function Harvest::canSeed(%pos,%seed)
{
	if(%seed && %seed.cnGrabber)
		return;
	%data = GameBase::getDataName(%seed);
	if(!%seed.parent || Vector::getDistance(%seed.fldCntr,%pos) < $Aeon::SeedFieldRadius[%data]) {
		%set = newObject("set",SimSet);
		%num = containerBoxFillSet(%set,$SimInteriorObjectType,%pos,3,3,4,-2);
		if(!%num) {
			deleteObject(%set);
			%set = newObject("set",SimSet);
			%dims = $Aeon::SeedDims[%data];
			%num = containerBoxFillSet(%set,$StaticObjectType,%pos,%dims,%dims,$Aeon::SeedCeiling,-$Aeon::SeedCeiling/2);
			if(!%num || (Harvest::areGlass(%set) == true)) {
				deleteObject(%set);
				%set = newObject("set",SimSet);
				if(containerBoxFillSet(%set,$StaticObjectType,%pos,%dims,%dims,2*%dims,-%dims)) {
					deleteObject(%set);
					return false;
				}
				deleteObject(%set);
				%aPos = Vector::sub(%pos,"0 0 10");
				getLOSInfo(Vector::add(%pos,"0 0 2"),%aPos,1);
				if(getObjectType($los::object) == "SimTerrain") {
					%parentPos = GameBase::getPosition(%seed);
					%aim = Vector::getRotAim(%parentPos,Vector::add(%pos,"0 0 2"));
					%rot = GameBase::getRotation(%seed);
					GameBase::setRotation(%seed,%aim);
					if(GameBase::getLOSinfo(%seed,$Aeon::SeedRadius[%data]+1) && $los::object != %seed.parent) {
						//echo(GameBase::getDataName($los::object));
						GameBase::setRotation(%seed,%rot);
						return false;
					}
					GameBase::setRotation(%seed,%rot);
					return true;
				}
				deleteObject(%set);
				return false;
			}
		}
		deleteObject(%set);
		return false;
	}
	return false;
}

function Harvest::areGlass(%set,%exclude,%exType)
{
	%count = Group::objectCount(%set);
	for(%i = 0; %i < %count; %i++) {
		%that = Group::getObject(%set,%i);
		if(GameBase::getDataName(%that).className != "Window" && %that != %exclude && GameBase::getDataName(%that).className != %exType && GameBase::getDataName(%that).className != "Lights")
			return false;
	}
	return true;
}

function Harvest::onCollision(%this,%object,%force)
{
	if(!%this || !%object || %this.cnGrabber || %this.age >= 5)
		return;
	%data = GameBase::getDataName(%this);
	if(getObjectType(%object) == "Player" && !%this.cnGrabber) {
		if(%this.age > 0 && %this.age < 5 && $Aeon::SeedCanSway[%data] == true && !%this.cnGrabber) {
			Harvest::swayReact(%this,%object,%force);
			if(!%force) {
				%this.isColliding = true;
				schedule("Harvest::onCollision("@%this@","@%object@", 1);",0.2);
				schedule("Harvest::onCollision("@%this@","@%object@", 2);",0.4);
				schedule("Harvest::onCollision("@%this@","@%object@", 3);",0.6);
				schedule("Harvest::onCollision("@%this@","@%object@", 4);",0.8);
				schedule(%this@".isColliding = false;",2.0);
			}
		}
		if(!%force) {
			if($Aeon::Harvestable[%data] == true && !%this.moveOnly) {
				%item = Item::getItemData(%this);
				%count = Player::getItemCount(%object,%item);
				if(Item::giveItem(%object,%item,Item::getCount(%this),%this)) {
					%clientId = Player::getClient(%object);
					%clientId.getting = getSimTime();
					schedule("Item::checkGetting("@%clientId@");",0.5,%clientId);
					deleteObject(%this);
				}
			}
		}
	}
}

function Harvest::swayReact(%seed,%player,%force)
{
	if(!%seed || %seed.cnGrabber || %seed.age > 4)
		return;
	%oRot = GameBase::getRotation(%seed);
	%rotX = getWord(%oRot,1);
	%rotY = getWord(%oRot,0);
	%maxRot = 2.2;
	if(Calc::abs(Calc::abs(%rotX) - $Pi/%maxRot) < 0.1 || Calc::abs(Calc::abs(%rotY) - $Pi/%maxRot) < 0.1)
	{
		//-Was too lazy to use != or whatever =p
		%seed.atMax = true;
	}
	else if(%seed.swayReseting != true || %seed.atMax != true)
	{
		%sPos = GameBase::getPosition(%seed);
		%pPos = GameBase::getPosition(%player);
		%dist = Vector::getDistance(%sPos,%pPos);
		%cVec = Vector::sub(%sPos,%pPos);
		%cVel = Vector::div(%cVec,%dist@" "@%dist@" "@%dist);
		%velX = %rotX+getWord(%cVel,0)/4;
		%velY = %rotY-getWord(%cVel,1)/4;
		if(%dist > 2.0 && %force) {
			%velX /= %force;
			%velY /= %force;
		}
		if(%velY > $Pi/%maxRot5)
			%velY = $Pi/%maxRot;
		else if(%velY < $Pi/-%maxRot)
			%velY = $Pi/-%maxRot;
		if(%velX > $Pi/%maxRot)
			%velX = $Pi/%maxRot;
		else if(%velX < $Pi/-%maxRot)
			%velX = $Pi/-%maxRot;
		%nRot = %velY@" "@%velX@" 0";
		GameBase::setRotation(%seed,%nRot);
		%seed.newRot = %nRot;
	}
	schedule("Harvest::swayEnd("@%seed@");",2.0,%seed);
}

function Harvest::swayEnd(%seed)
{
	if(!%seed || %seed.cnGrabber || %seed.age > 4)
		return;
	%rot = GameBase::getRotation(%seed);
	%dif = Vector::dif(%seed.origRot,%rot);
	if(%seed.isColliding == true || %dif < 0.1) {
		%seed.atMax = "";
		return;
	}
	%gol = Vector::sub(%seed.origRot,%seed.newRot);
	%gol = Vector::div(%gol,"3 3 3");
	%newRot = Vector::add(%rot,%gol);
	%newRot = Vector::splice(%newRot,%newRot,"0 0 0");
	GameBase::setRotation(%seed,%newRot);
	schedule("Harvest::swayEnd("@%seed@");",0.5,%seed);
}

function Seed::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	%id = Aeon::getAeonID(%clientId);
	if(getSimTime() - %clientId.lastSeedTime < 1.0)
		return;
	%clientId.lastSeedTime = getSimTime();
	%skill = $Aeon::ClientInfo[%id,skll,aggr];
	if(%skill >= 1) {
		if(GameBase::getLOSInfo(%player,4)) {
			%obj = getObjectType($los::object);
			if(%obj == "SimTerrain") {
				%pos = GameBase::getPosition(%player);
				%rot = GameBase::getRotation(%player);
				%prop = Aeon::inProperty($los::position);
				if(%prop != false) {
					%owner = Property::getOwner(%prop);
					if(%owner == %id || Property::hasPermission(%clientId,%prop,"seed") == true) {
						%bool = Aeon::plantSeed($los::position,%item);
						if(%bool == true) {
							bottomPrint(%clientId,"<jc><f3>You planted a <f1>"@%item.description@"<f3>.",1);
							playSound(SoundPickupBackpack,$los::position);
							Player::decItemCount(%player,%item);
							Aeon::ExportInfo(%clientId);
							return true;
						}
						else {
							bottomPrint2(%clientId,"<jc><f3>You were not able to plant a <f1>"@%item.description@"<f3> here.",1,"C_BuySell.wav");
							return false;
						}
					}
					else
						bottomPrint2(%clientId,"<jc><f3>You don't have permission to plant seeds here.",1,"C_BuySell.wav");
				}
				else
					bottomPrint2(%clientId,"<jc><f3>You can only plant seeds on property.",1,"C_BuySell.wav");
			}
			else
				bottomPrint2(%clientId,"<jc><f3>You can only plant seeds in the ground.",1,"C_BuySell.wav");
		}
		else
			bottomPrint2(%clientId,"<jc><f3>You can't reach that far!",1,"C_BuySell.wav");
		return false;
	}
	else
		bottomPrint2(%clientId,"<jc><f3>You lack the <f2>Aggriculture<f3> Skill to plant the <f2>"@%item.description@"<f2>!",1,"C_BuySell.wav");
}

function Harvest::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	%data = GameBase::getDataName(%this);
	%damageLevel = GameBase::getDamageLevel(%this);
	if(!%this || %damageLevel >= %data.maxDamage)
		return;
	if(%type == $FireDamageType || %type == $ColdDamageType || %type == $ShrapnelDamageType || %type == $ExplosionDamageType) {
		if(%type == $FireDamageType) {
			%value *= 2.0;
			SpecialDamage::Fire(%this);
		}
		else if(%type == $ColdDamageType) {
			%value *= 1.5;
		}
		%dValue = %damageLevel + %value;
		GameBase::setDamageLevel(%this,%dValue);
	}
	else
		return;
}

function Harvest::getStats(%seed)
{
	%data = GameBase::getDataName(%seed);
	%type = $Aeon::SeedType[%data,%seed.type];
	%age = floor(getSimTime()-%seed.createTime);
	if(String::findSubStr(%data,"Ore") == 0) {
		if(%seed.age == 0)
			%ripe = "Crystallizing";
		else if(%seed.age == 1)
			%ripe = "Crystallizing";
		else if(%seed.age == 2)
			%ripe = "Maturing";
		else if(%seed.age == 3)
			%ripe = "Ready";
		else if(%seed.age == 4)
			%ripe = "Clustering";
		else
			%ripe = "Crumbling";
	}
	else {
		if(%seed.age == 0)
			%ripe = "Growing";
		else if(%seed.age == 1)
			%ripe = "Growing";
		else if(%seed.age == 2)
			%ripe = "Ripening";
		else if(%seed.age == 3 && %seed.isRipe == true)
			%ripe = "Ripe";
		else if(%seed.age == 4)
			%ripe = "Seeding";
		else
			%ripe = "Dieing";
	}
	%string = "<jc><f3>Type: <f1>"@%type.description@"<f3> : Condition: <f1>"@%ripe@"<f3> : Age: <f1>"@%age@"<f3>.";
	return %string;
}

function Vege_MariJ::onUse(%player,%item)
{
	if(Player::getItemCount(%player,%item) >= 1) {
		SayCMD::smoke(Player::getClient(%player),"maryj",15+ranDim(5));
	}
}

function Aeon::getHigh(%id)
{
	%blazin = getSimTime() - Client::getOwnedObject(Aeon::getClient(%id,true)).blazin;
	if(%blazin > $KarmaAffect[high,dur])
		%blazin = $KarmaAffect[high,dur];
	%high = ($KarmaAffect[high,dur]-%blazin)/$KarmaAffect[high,dur];
	return %high;
}

function Harvest::quickGive(%clientId)
{
	Aeon::incItemCount(%clientId,Vege_MariJ,10);
	Aeon::incItemCount(%clientId,Vege_Corn,10);
	Aeon::incItemCount(%clientId,Vege_Potatoe,10);
	Aeon::incItemCount(%clientId,Vege_Tomatoe,10);
	Aeon::incItemCount(%clientId,Vege_Soybean,10);
	Aeon::incItemCount(%clientId,Vege_Hevea,10);
	Aeon::incItemCount(%clientId,Vege_Indigo,10);
	Aeon::incItemCount(%clientId,Vege_Wheat,10);
	Aeon::incItemCount(%clientId,Vege_Yam,10);
	Aeon::incItemCount(%clientId,Vege_Bamboo,10);
	Aeon::incItemCount(%clientId,Seed_MariJ,10);
	Aeon::incItemCount(%clientId,Seed_Corn,10);
	Aeon::incItemCount(%clientId,Seed_Potatoe,10);
	Aeon::incItemCount(%clientId,Seed_Tomatoe,10);
	Aeon::incItemCount(%clientId,Seed_Soybean,10);
	Aeon::incItemCount(%clientId,Seed_Hevea,10);
	Aeon::incItemCount(%clientId,Seed_Indigo,10);
	Aeon::incItemCount(%clientId,Seed_Wheat,10);
	Aeon::incItemCount(%clientId,Seed_Yam,10);
	Aeon::incItemCount(%clientId,Seed_Bamboo,10);
	Aeon::incItemCount(%clientId,Ore_Iron,10);
	Aeon::incItemCount(%clientId,Ore_Lead,10);
	Aeon::incItemCount(%clientId,Ore_Tin,10);
	Aeon::incItemCount(%clientId,Ore_Aluminum,10);
	Aeon::incItemCount(%clientId,Ore_Copper,10);
	Aeon::incItemCount(%clientId,Ore_Titanium,10);
	Aeon::incItemCount(%clientId,Ore_Silver,10);
	Aeon::incItemCount(%clientId,Ore_Gold,10);
	Aeon::incItemCount(%clientId,Ore_Platinum,10);
	Aeon::incItemCount(%clientId,Mineral_Carbon,10);
	Aeon::incItemCount(%clientId,Mineral_Sulfur,10);
}