//- Place Holder file, eventually will house metallurgy structures
$Aeon::TerminalType["Foundry"] = "toss";

$Aeon::invStyle[Metal_Cinder] = "held";
$Aeon::invStyle[Metal_Lead] = "held";
$Aeon::invStyle[Metal_Iron] = "held";
$Aeon::invStyle[Metal_Tin] = "held";
$Aeon::invStyle[Metal_Aluminum] = "held";
$Aeon::invStyle[Metal_Copper] = "held";
$Aeon::invStyle[Metal_Titanium] = "held";
$Aeon::invStyle[Metal_Silver] = "held";
$Aeon::invStyle[Metal_Gold] = "held";
$Aeon::invStyle[Metal_Platinum] = "held";
$Aeon::invStyle[Alloy_Steel] = "held";
$Aeon::invStyle[Alloy_Bronze] = "held";
$Aeon::invStyle[Alloy_Pewter] = "held";
$Aeon::invStyle[Alloy_Electrum] = "held";
$Aeon::invStyle[Alloy_Duralumin] = "held";
$Aeon::invStyle[Exp_C1] = "held";
$Aeon::invStyle[Exp_C2] = "held";
$Aeon::invStyle[Exp_C3] = "held";
$Aeon::invStyle[Exp_C4] = "held";
$Aeon::invStyle[Exp_C5] = "held";

//Skill 0/3 = C1: lead-100 
//Skill 1/3 = C2: iron-100, tin-100
//Skill 2/3 = C3: aluminum-200, copper-200
//Skill 3/3 = C4: titanium-500, silver-400
//Skill 3/3 = C5: gold-750, platinum-1000
$Aeon::ChargeProduct[Exp_C1,0] = "Ore_Lead";
$Aeon::ChargeProduct[Exp_C2,0] = "Ore_Iron";
$Aeon::ChargeProduct[Exp_C2,1] = "Ore_Tin";
$Aeon::ChargeProduct[Exp_C2,2] = "Mineral_Carbon";
$Aeon::ChargeProduct[Exp_C3,0] = "Ore_Aluminum";
$Aeon::ChargeProduct[Exp_C3,1] = "Ore_Copper";
$Aeon::ChargeProduct[Exp_C3,2] = "Mineral_Sulfur";
$Aeon::ChargeProduct[Exp_C4,0] = "Ore_Titanium";
$Aeon::ChargeProduct[Exp_C4,1] = "Ore_Silver";
$Aeon::ChargeProduct[Exp_C4,2] = "Mineral_Phosph";
$Aeon::ChargeProduct[Exp_C5,0] = "Ore_Gold";
$Aeon::ChargeProduct[Exp_C5,1] = "Ore_Platinum";
$Aeon::ChargeRequire[Exp_C1] = 0;
$Aeon::ChargeRequire[Exp_C2] = 1;
$Aeon::ChargeRequire[Exp_C3] = 2;
$Aeon::ChargeRequire[Exp_C4] = 3;
$Aeon::ChargeRequire[Exp_C5] = 3;

function Foundry::onCollision(%this,%object)
{
	if(!%this || !%object || %object.fdnMade)
		return;
	%data = GameBase::getDataName(%object);
	%type = getObjectType(%object);
	%pos = Vector::add(GameBase::getPosition(%this),"0 0 1.2");
	%rot = Vector::add(GameBase::getRotation(%this),"0 0 "@$Pi/2);
	if(getSimTime() > %this.lastTime+1 && !%this.inUse) {
		if(%type == "Item") {
			if(Property::hasPermission(Player::getClient(%object.tosser),%this.prop,"term")) {
				deleteObject(%object);
				GameBase::setSequenceDirection(%this,1,1);
				GameBase::playSequence(%this,0,"power");
				GameBase::playSequence(%this,1,"activate");
				%time = 1.5+ranDim(1.0);
				if($Element::heatReact[$Aeon::Elements[%data,0]] == "smoke")
					schedule("Foundry::smoke("@%this@");",%time/2,%this);
				schedule("Foundry::done("@%this@","@%data@",\""@%pos@"\",\""@%rot@"\");",%time,%this);
				%this.inUse = true;
			}
		}
		else if(%type == "Player") {
			%set = newObject("set",SimSet);
			if(containerBoxFillSet(%set,$CorpseObjectType,%pos,5,5,6,-3)) {
				if(Group::objectCount(%set) > 0) {
					for(%i = 0; %i < Group::objectCount(%set); %i++) {
						%obj = Group::getObject(%set,%i);
						break;
					}
					%armor = Player::getArmor(%obj);
					%armor = Aeon::convertArmor(%armor);
					deleteObject(%obj);
					GameBase::setSequenceDirection(%this,1,1);
					GameBase::playSequence(%this,0,"power");
					GameBase::playSequence(%this,1,"activate");
					%time = 2+ranDim(1.0);
					schedule("Foundry::done("@%this@",\""@%armor@"\",\""@%pos@"\",\""@%rot@"\");",%time,%this);
					%this.inUse = true;
				}
			}
			deleteObject(%set);
		}
		else
			echo(%type);
	}
}

function Foundry::done(%this,%data,%pos,%rot)
{
	%elmCnt = Metallurgy::getElementCount(%data);
	if(%elmCnt == 0) {
		$Aeon::Elements[%data,0] = %data;
		%elmCnt = 1;
	}
	for(%i = 0; $Aeon::Elements[%data,%i] != ""; %i++) {
		%elm = $Aeon::Elements[%data,%i];
		if(%elm == "")
			%elm = $Aeon::Elements["",0];
		%react = $Element::heatReact[%elm];
		if(%react == "combust") {
			%mine = newObject("","Mine","Exp_CMine");
			addToSet("MissionCleanup",%mine);
			GameBase::setPosition(%mine,GameBase::getPosition(%this));
			GameBase::setDamageLevel(%this,GameBase::getDataName(%this).maxDamage);
			schedule("Mine::Detonate("@%mine@");",0.1,%mine);
			schedule("deleteObject("@%this@");",0.1);
			schedule("Aeon::ExportProperty("@Property::getPieceOwn(%this)@");",0.5);
			return;
		}
		else {
			if(%react == "cinder") {
				%elm = "Metal_Cinder";
			}
			else if(%react == "smoke") {
				Foundry::smoke(%this);
				%elm = "Metal_Cinder";
			}
			%rot = Vector::add(%rot,"0 0 "@$Pi/(%elmCnt+1));
			%vec = Vector::getFromRot(%rot,1);
			%org = Vector::add(%pos,%vec);
			%new = newObject("","Item",%elm,1,false);
			%new.fdnMade = true;
			addToSet("MissionCleanup",%new);
			GameBase::setPosition(%new,%org);
			Item::setVelocity(%new,Vector::mult(%vec,"2 2 2"));
			schedule("deleteObject("@%new@");",30.0,%new);
		}
	}
	GameBase::pauseSequence(%this,1);
	GameBase::setSequenceDirection(%this,1,0);
	GameBase::playSequence(%this,1);
	%this.lastTime = getSimTime();
	%this.inUse = "";
}

function Foundry::smoke(%this)
{
	%trans = New::getMuzzleTransform(%this,1.0,$Pi/2@" 0 0",0.8);
	%smoke = projectile::spawnProjectile("smoke3",%trans,%this,"0 0 0");
	return %smoke;
}

function Foundry::onEndSequence(%this,%thread)
{
	GameBase::stopSequence(%this,0);
}

function Metallurgy::getElementCount(%data)
{
	%count = 0;
	for(%i = 0; $Aeon::Elements[%data,%i] != ""; %i++)
		%count++;
	return %count;
}

function Metal::quickGive(%clientId)
{
	Aeon::incItemCount(%clientId,Metal_Cinder,10);
	Aeon::incItemCount(%clientId,Metal_Iron,10);
	Aeon::incItemCount(%clientId,Metal_Lead,10);
	Aeon::incItemCount(%clientId,Metal_Tin,10);
	Aeon::incItemCount(%clientId,Metal_Aluminum,10);
	Aeon::incItemCount(%clientId,Metal_Copper,10);
	Aeon::incItemCount(%clientId,Metal_Titanium,10);
	Aeon::incItemCount(%clientId,Metal_Silver,10);
	Aeon::incItemCount(%clientId,Metal_Gold,10);
	Aeon::incItemCount(%clientId,Metal_Platinum,10);
	Aeon::incItemCount(%clientId,Alloy_Steel,10);
	Aeon::incItemCount(%clientId,Alloy_Bronze,10);
	Aeon::incItemCount(%clientId,Alloy_Pewter,10);
	Aeon::incItemCount(%clientId,Alloy_Electrum,10);
	Aeon::incItemCount(%clientId,Alloy_Duralumin,10);
	Aeon::incItemCount(%clientId,Exp_C1,10);
	Aeon::incItemCount(%clientId,Exp_C2,10);
	Aeon::incItemCount(%clientId,Exp_C3,10);
	Aeon::incItemCount(%clientId,Exp_C4,10);
	Aeon::incItemCount(%clientId,Exp_C5,10);
}

function Explosive::onUse(%player,%item)
{
	%clientId = Player::getClient(%player);
	if(getSimTime() - %clientId.lastSeedTime < 1.0)
		return;
	%clientId.lastSeedTime = getSimTime();
	if(Explosive::checkSkill(%clientId,%item) == true) {
		%obj = newObject("","Item",%item,1,false);
		addToSet("MissionCleanup",%obj);
		%count = Player::getItemCount(%clientId,%item);
		Player::setItemCount(%player,%item,%count-1);
		GameBase::throw(%obj,%player,15,false);
		Item::playPickupSound(%obj);
		%obj.tosser = %player;
		Explosive::deployCheck(%obj);
		Aeon::ExportInfo(%clientId);
	}
	else
		bottomPrint2(%clientId,"<jc><f3>You lack the <f2>Metallurgy<f3> Skill to use the <f2>"@%item.description@"<f3>.",1,"C_BuySell.wav");
}

function Explosive::checkSkill(%clientId,%item)
{
	%id = Aeon::getAeonID(%clientId);
	%skill = $Aeon::ClientInfo[%id,skll,metl];
	if(%skill >= $Aeon::ChargeRequire[%item])
		return true;
	return false;
}

function Explosive::deployCheck(%this)
{
	if(GameBase::isAtRest(%this)) {
		%data = GameBase::getDataName(%this);
		%pos = GameBase::getPosition(%this);
		%rot = GameBase::getRotation(%this);
		%player = %this.tosser;
		deleteObject(%this);
		%obj = newObject("Explosive",StaticShape,Exp_CStatic,true);
		%name = %data.description;
		addToSet("MissionCleanup",%obj);
		GameBase::setPosition(%obj,%pos);
		GameBase::setRotation(%obj,%rot);
		GameBase::setTeam(%obj,$Aeon::PropertyTeam);
		%obj.tosser = %player;
		%time[0] = %name@": <(5)>";
		%time[1] = %name@": <(4)>";
		%time[2] = %name@": <(3)>";
		%time[3] = %name@": <(2)>";
		%time[4] = %name@": <(1)>";
		%time[5] = %name@": <[CLEAR]>";
		GameBase::setMapName(%obj,%time[0]);
		playSound(SoundExplosiveBeep,%pos);
		//Shakeable::addToNetwork(%obj);

		schedule("Explosive::setTimer("@%obj@",\""@%time[1]@"\");",1.0,%obj);
		schedule("Explosive::setTimer("@%obj@",\""@%time[2]@"\");",2.0,%obj);
		schedule("Explosive::setTimer("@%obj@",\""@%time[3]@"\");",3.0,%obj);
		schedule("Explosive::setTimer("@%obj@",\""@%time[4]@"\");",4.0,%obj);
		schedule("Explosive::setTimer("@%obj@",\""@%time[5]@"\");",5.0,%obj);
		schedule("Explosive::detonate("@%obj@","@%data@");",5.0,%obj);
	}
	else
		schedule("Explosive::deployCheck("@%this@");",1,%this);
}	

function Explosive::setTimer(%this,%time)
{
	if(%this) {
		%pos = GameBase::getPosition(%this);
		GameBase::setMapName(%this,%time);
		playSound(SoundExplosiveBeep,%pos);
		return true;
	}
	return false;
}

function Explosive::detonate(%this,%data)
{
	%player = %this.tosser;
	%pos = GameBase::getPosition(%this);
	%mine = newObject("","Mine","Exp_CMine");
	addToSet("MissionCleanup",%mine);
	GameBase::setPosition(%mine,%pos);
	$lastPos[%mine] = %pos;
	schedule("deleteObject("@%this@");",0.1,%this);
	schedule("Explosive::afterExplode("@%player@",\""@%pos@"\","@%data@");",0.1,%mine);
	schedule("Mine::Detonate("@%mine@");",0.1,%mine);

	%seis = %pos@" "@$Aeon::SeisRad["Explos"];
	Seismic::addToNetwork(%seis);
	Seismic::Quake("","","Explos",%pos);
	schedule("Seismic::removeFromNetwork(\""@%seis@"\");",10);
}

function Explosive::afterExplode(%player,%pos,%data)
{
	%clientId = Player::getClient(%player);
	%id = Aeon::getAeonID(%clientId);
	%skill = $Aeon::ClientInfo[%id,skll,metl];
	getLOSInfo(Vector::add(%pos,"0 0 2"),Vector::sub(%pos,"0 0 2"),1);
	%obj = $los::object;
	%lPs = $los::position;
	$los::object = "";
	$los::position = "";
	if(getObjectType(%obj) == "SimTerrain") {
		%rat = Skill::getSkillRatio(%clientId,metl)+1;
		%rnd = getRandom()*5;
		//echo(%rnd@"*"@%rat@" = "@%rnd*%rat@" > 3.0");
		if(%rnd*%rat > 3.0) {
			%num = 0;
			for(%i = 0; $Aeon::ChargeProduct[%data,%i] != ""; %i++)
				%num++;
			%rand = floor(getRandom()*(%num-0.01));
			%type = $Aeon::ChargeProduct[%data,%rand];
			%bool = Aeon::startOre(%lPs,%type);
			if(%bool == true)
				bottomPrint(%clientId,"<jc><f3>Success!",1);
		}
	}
}

function Aeon::startOre(%pos,%type)
{
	%data = Harvest::getShape(%type);
	//echo(%data@" : "@%type);
	return Aeon::vegetate(%pos,%data,%type);
}