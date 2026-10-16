MineData Suicidebomb {
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "marmor";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 600;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 5000;
};

function Suicidebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setTeam(%this, GameBase::getTeam(%this.player));
	Schedule("Mine::Detonate("@ %this @");", 0.5, %this);
}

function Suicidebomb::onDamage(%this, %type, %value, %pos, %vec, %mom, %object){
	if(%type == $DebugDamageType){
		%newObj = newObject("Instant_Health", Item, instantHealth, 1, false);
		addToSet("MissionCleanup", %newObj);
		GameBase::setPosition(%newObj, Vector::add(GameBase::getPosition(%this), "0 0 2"));
		GameBase::setTeam(%newObj, GameBase::getTeam(%object));
		Schedule("deleteObject("@ %newObj @");", 4, %newObj);
		Schedule("deleteObject("@ %this @");", 0.1, %this);
//		GameBase::setDamageLevel(%this, %data.maxDamage);
		return;
	}
}

MineData Suicidebomb2 {
	mass = 0.3;
	drag = 0.1;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "marmor";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 200;
	damageValue = 750.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 500;
};

function Suicidebomb2::onAdd(%this){
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate("@ %this @");", 20, %this);
}

function Suicidebomb2::onCollision(%this,%obj){
	if(getObjectType(%obj) != "Player" || Player::isDead(%obj)){
		return;
	}
	
	%clientId = Player::getClient(%obj);
	%pTeam = GameBase::getTeam(%obj);
	%dTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	
	if(%armor != "larmor" && %armor != "Earmor"){
		return;
	}
	
	%rnd = floor(getRandom() * 10);
	Echo("RND: "@ %rnd);
	
	if(%armor == "Earmor" || %clientId.isGodAdmin == true){
		//Engineer's and admins disarm detpacks.
		Schedule("deleteObject("@ %this @");", 0.1, %this);
		Client::sendMessage(%clientId, 0, "You disarmed A DetPack!");
		CenterPrint(%clientId, "<jc><f1>You disarmed A DetPack!", 5);
	}
	else{
		if(%rnd > 7){
			MessageAll(5, Client::getName(%clientId) @": I just ate my own ass after trying to Disarm a DetPack.");
			CenterPrint(%clientId, "<jc><f1> It Was The Blue Wire You Dumb Shit.", 5);
			Mine::Detonate(%this);
			%clientId.fuckedup = true;
			Schedule(%clientId @".fuckedup = false:", 25);
			return;
		}else{
			deleteObject(%this);
			Client::sendMessage(%clientId, 0, "You disarmed A DetPack!");
			CenterPrint(%clientId, "<jc><f1>You disarmed A DetPack!", 5);
		}
	}
}