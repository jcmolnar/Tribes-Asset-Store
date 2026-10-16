$InvList[MineAmmo] = 1;
$MobileInvList[MineAmmo] = 1;
$RemoteInvList[MineAmmo] = 1;
AddItem(MineAmmo);

$SellAmmo[MineAmmo] = 5;
$TeamItemMax[mineammo] = 35;

//$InvList[ReplicatingMine] = 1;
//$RemoteInvList[ReplicatingMine] = 1;

addAmmo("", MineAmmo, 1);

function miscMine::Initialize()
{
	$TeamItemCount[0 @ mineammo] = 0;
	$TeamItemCount[1 @ mineammo] = 0;
	$TeamItemCount[2 @ mineammo] = 0;
	$TeamItemCount[3 @ mineammo] = 0;
	$TeamItemCount[4 @ mineammo] = 0;
	$TeamItemCount[5 @ mineammo] = 0;
	$TeamItemCount[6 @ mineammo] = 0;
	$TeamItemCount[7 @ mineammo] = 0;
}

function oldMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%type == $MineDamageType) 
		%value = %value * 0.25;
	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this) 
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}

//function MineAmmo::onUse(%player,%item)
//{
//	if($matchStarted)
//	{
//		if(%player.throwTime < getSimTime() )
//		{
//
//			if(Player::getItemCount(%player, OriginalMine))
//			{
//				%name = "AntipersonelMine";
//				%item = OriginalMine;
//			}
//			else if(Player::getItemCount(%player, ReplicatingMine))
//			{
//				%name = "ReplicatorMine";
//				%item = ReplicatingMine;
//			}
//			else if(Player::getItemCount(%player, FlagMine))
//			{
//				%name = "FakeFlag";
//				%item = FlagMine;
//			}
//
//			if(!$build)Player::decItemCount(%player,%item);
//			Player::decItemCount(%player, MineAmmo);
//			%obj = newObject("","Mine",%name);
//			%obj.cloakable = true;	//for base cloaker
//			addToSet("MissionCleanup", %obj);
//			%client = Player::getClient(%player);
//			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
//			%player.throwTime = getSimTime() + 0.5;
//			GameBase::setTeam(%obj,GameBase::getTeam(%client));
//		}
//	}
//}

MineData Boost
{
	className = "Handgrenade";
   description = "Beacon";
   shapeFile = "mine";
      validateShape = true;
   validateMaterials = true;
   shadowDetailMask = 4;
   explosionId = BoosterExp;
	explosionRadius = 20.0; //250
	damageValue = 0.0; //0
	damageType = $MineDamageType;
	kickBackStrength = 350; //500
	triggerRadius = 250; //250
	maxDamage = 0.0;//0
	//shadowDetailMask = 0;
	//destroyDamage = 1.0;
	//damageLevel = {1.0, 1.0};
};

function Boost::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   //echo("Boost  onDamage");
   //if (%type == $MineDamageType)
   //   %value = %value * 0.25;

   //	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,2);
}


 //-=-=-=-

MineData Handgrenade 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Handgrenade::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
	  schedule("DeployShrapnel(" @ %this @ " , 16);",2.0,%this);
}

function Mine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

        %damageLevel = GameBase::getDamageLevel(%this);
        GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function Mine::Detonate(%this)
{
        %data = GameBase::getDataName(%this);
        GameBase::setDamageLevel(%this, %data.maxDamage);
}
 
function Handgrenade::onRemove(%this)
{
	//do nothing yet..
}


MineData Shrapnel
{
   mass = 0.3;
   drag = 1.0;

  density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Shrapnel";
   description = "Shrapnel";
   shapeFile = "staff";
   shadowDetailMask = 4;
   explosionId = bulletExp0;
	explosionRadius = 1.0;
	damageValue = 0.07;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Shrapnel::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

function DeployShrapnel(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20,true);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-20,false);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,20,false);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,20,true);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-25,false);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-25,true);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this, 25,false);
		%obj = newObject("","Mine","Shrapnel");
		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this, 25,true);
		%count -= 1;
		schedule("DeployShrapnel(" @ %this @ ", " @ %count @ ");",0.5,%this);
	}
}

 //-=-=-=- MineAmmo

ItemData MineAmmo 
{
	description = "Mine";
	shapeFile = "mineammo";
	heading = $InvHead[ihMis];
	shadowDetailMask = 4;
	price = 10;
	className = "HandAmmo";
};
// over writes function above.. 
function MineAmmo::onUse(%player,%item) 
{
	if($matchStarted) 
	{
		GameBase::playSound(%player, SoundThrowItem,0);
		if(%player.throwTime < getSimTime() ) 
		{
			if(!$build)Player::decItemCount(%player,%item);
			%armor = Player::getArmor(%player);
			%client = Player::getClient(%player);
			if($Deathmatch)
				%obj = newObject("","Mine","DMMine");
			else 
			{
				%obj = newObject("","Mine","antipersonelMine");
				GameBase::setTeam (%obj,GameBase::getTeam (%client));
			}
			%obj.cloakable = true;	//for base cloaker
			addToSet("MissionCleanup", %obj);
			GameBase::throw(%obj,%player,15 * %client.throwStrength,false);
			%player.throwTime = getSimTime() + 0.5;
		}
	}
}

 //-=-=-=- 

MineData AntipersonelMine 
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	validateShape = true;
	validateMaterials = true;
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function AntipersonelMine::onAdd(%this) 
{
	%this.damage = 0;
	GameBase::setMapName(%this,"Mine");
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onRemove(%this)
{
	//do nothing yet..
}


function AntipersonelMine::onCollision(%this,%object) 
{	
	if($debug) 
		event::collision(%this,%object);

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this visible for a second 
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

// default annihilation mine
function AntipersonelMine::deployCheck(%this) 
{
	if(GameBase::isAtRest(%this)) 
	{
		//GameBase::playSound(%this, SoundMineActivate,0.5);
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
}

function AntipersonelMine::onDestroyed(%this) 
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
	%this.cloakable = "";
	%this.nuetron = "";
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%type == $MineDamageType) 
		%value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

 //-=-=-=-

MineData DMMine 
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.75;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 250;
	triggerRadius = 2.5;
	maxDamage = 0.75;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function DMMine::onAdd(%this) 
{
	%this.damage = 0;
	DMMine::deployCheck(%this);
}
 
function DMMine::onRemove(%this)
{
	//do nothing yet..
}


function DMMine::onCollision(%this,%object) 
{	
	if($debug) 
		event::collision(%this,%object);

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);
		%this.cloaked = "";
		}	//pop this visible for a second 
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DMMine::deployCheck(%this) 
{
	if(GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else schedule("DMMine::deployCheck(" @ %this @ ");", 3, %this);
}

function DMMine::onDestroyed(%this) 
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
	%this.cloakable = "";
	%this.nuetron = "";
}

function DMMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%type == $MineDamageType) %value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
	else %this.damage += %value;
}

 //-=-=-=-

MineData HoloMine 
{
	className = "Mine";
	description = "Hologram";
	shapeFile = "larmor";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 15.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 2.5;
	maxDamage = 2.00;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HoloMine::onAdd(%this,%clientId) 
{
	%this.damage = 0;
	HoloMine::deployCheck(%this);
	%data = GameBase::getDataName(%this);
	Client::sendMessage(%clientId,0,"You summon a mirror image of yourself");
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this);
}

function HoloMine::onRemove(%this)
{
	//do nothing yet..
}


function HoloMine::onCollision(%this,%object) 
{	
	if($debug) 
	  echo("?? EVENT collision "@GameBase::getDataName(%this)@" contacted by "@GameBase::getDataName(%object)@" control cl# "@GameBase::getControlClient(%object));

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);
		%this.cloaked = "";
		}	//pop this visible for a second 
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HoloMine::onUse(%clientId) 
{
Client::sendMessage(%clientId,0,"You summon a mirror image of yourself");
}

function HoloMine::deployCheck(%this) 
{
	 if(GameBase::isAtRest(%this))
	{
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this);
}

function HoloMine::onDestroyed(%this) 
{
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--;
	%this.cloakable = "";
	%this.nuetron = "";
}

function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%type == $MineDamageType) %value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
	else %this.damage += %value;
}

 //-=-=-=-

MineData Hologram 
{
	className = "Mine";
	description = "Antipersonel Mine";
	shapeFile = "flag";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 5.0;
	damageValue = 0.75;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.0;
	maxDamage = 3.00;
	shadowDetailMask = 0;
	destroyDamage = 2.0;
	damageLevel = {1.0, 1.0};
	lightType = 2;
	lightRadius = 4;
	lightTime = 1.5;
	lightColor = {1, 1, 1 };
};

function Hologram::onAdd(%this) 
{
	%this.damage = 0;
	Boost::deployCheck(%this); // ???
}

function Hologram::onCollision(%this,%object) 
{	
	if($debug) 
	  echo("?? EVENT collision "@GameBase::getDataName(%this)@" contacted by "@GameBase::getDataName(%object)@" control cl# "@GameBase::getControlClient(%object));

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		%this.cloaked = "";
		GameBase::startFadein(%this);	}//pop this visible for a second 
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == Hologram || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Hologram::deployCheck(%this) 
{
	if(GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this);
}

function Hologram::onDestroyed(%this)
{
	%this.cloakable = "";
	%this.nuetron = "";
}

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
{
	if(%type == $ShrapnelDamageType) %value = %value * 0.25;
	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) GameBase::setDamageLevel(%this, %data.maxDamage);
	else %this.damage += %value;
}

 //-=-=-=-

MineData Tranqgrenade 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 10.0;
	damageValue = 0.15;
	damageType = $EnergyDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Tranqgrenade::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

 //-=-=-=-

MineData Shockgrenade 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = Shockwave;
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ShockDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Shockgrenade::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function Shockgrenade::onRemove(%this)
{
	//do nothing yet..
}


 //-=-=-=-

MineData Concussion 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 15.0;
	damageValue = 0.50;
	damageType = $PlasmaDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Concussion::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

 //-=-=-=-

MineData Nukebomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "Plastique";
	shapeFile = "sensor_small";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 7.5;
	damageValue = 2.0;
	damageType = $MortarDamageType;
	kickBackStrength = 400;
	triggerRadius = 0.5;
	maxDamage = 3.0;
};

function Nukebomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",15.0,%this);
}

function Nukebomb::onRemove(%this)
{
	//do nothing yet..
}


function Nukebomb::onCollision(%this,%obj) 
{	
	if($debug) 
		event::collision(%this,%obj);

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this visible for a second 
	if(getObjectType(%obj) != "Player") 
		return;
	if(Player::isDead(%obj)) 
		return;
	%clientId = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	if(%armor == "armormBuilder" || %armor == "armorfBuilder") 
	{
		%rnd = floor(getRandom() * 10);
		if(%rnd > 8.5) 
		{
			Client::sendMessage(%clientId,1,"OOPS! You cut the wrong wire...");
			Mine::Detonate(%this);
			return;
		}
		else 
		{
			deleteObject(%this);
			Client::sendMessage(%clientId,1,"You disarm the Plastique Explosive.");
		}
	}
}

//----------------- a lil easter egg.. 
MineData Fighterbomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.0;
	friction = 99.0;
	className = "Handgrenade";
	description = "Plastique";
	shapeFile = "flyer";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 7.5;
	damageValue = 1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 400;
	triggerRadius = 0.5;
	maxDamage = 3.0;
	
};

function Fighterbomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",15.0,%this);
}
 
function Fighterbomb::onRemove(%this)
{
	//do nothing yet..
}


//-------------------------------


// Deployed if Player wearing SuicidePack actually commits suicide
MineData Suicidebomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 50.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Suicidebomb::onAdd(%this) 
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}
 
function Suicidebomb::onRemove(%this)
{
	//do nothing yet..
}


// Deployed in normal manner with pack key
MineData Suicidebomb2 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "magcargo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 70.0;
	damageValue = 4.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 300;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

// Override base class
function Suicidebomb2::onAdd(%this) 
{
}
 
function Suicidebomb2::onRemove(%this)
{
	//do nothing yet..
}


function Suicidebomb2::onCollision(%this,%obj) 
{	
	if($debug) 
	  echo("?? EVENT collision "@GameBase::getDataName(%this)@" contacted by "@GameBase::getDataName(%object)@" control cl# "@GameBase::getControlClient(%object));

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);
		%this.cloaked = "";
		}	//pop this visible for a second 
	if(getObjectType(%obj) != "Player") 
		return;
	if(Player::isDead(%obj)) 
		return;
	%clientId = Player::getClient(%obj);
	%playerTeam = GameBase::getTeam(%obj);
	%teleTeam = GameBase::getTeam(%this);
	%armor = Player::getArmor(%obj);
	if(%armor == "armormBuilder" || %armor == "armorfBuilder") 
	{
		%rnd = floor(getRandom() * 10);
		if(%rnd > 8) 
		{
			Client::sendMessage(%clientId,1,"OOPS! You cut the wrong wire...");
			Mine::Detonate(" @ %this @ ");
			return;
		}
		else 
		{
			deleteObject(%this);
			Client::sendMessage(%clientId,1,"You disarm the DetPack.");
		}
	}
}

 //-=-=-=-

MineData Mortarbomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "sensor_small"; //"grenade";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $MortarDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Mortarbomb::onAdd(%this) 
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function Mortarbomb::onRemove(%this)
{
	//do nothing yet..
}


MineData Clusterbombmine 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "plasammo"; //"grenade";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $MortarDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 1.0;
};

function Clusterbombmine::onAdd(%this) 
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

function Clusterbombmine::onRemove(%this)
{
	//do nothing yet..
}


MineData AngelGren
{
  mass = 0.3;
  drag = 1.0;
  density = 2.0;
  elasticity = 0.15;
  friction = 1.0;
  className = "Handgrenade";
  description = "Handgrenade";
  shapeFile = "logo";
  shadowDetailMask = 4;
  explosionId = rocketExp;
  explosionRadius = 8.0;
  damageValue = 1;
  damageType = $MortarDamageType;
  kickBackStrength = 100;
  triggerRadius = 0.5;
  maxDamage = 2.0;
};

function AngelGren::onAdd(%this)
{
	schedule("DeployAngel(" @ %this @ " , 5);",0.5,%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

function DeployAngel(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Blues");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5,false);
		
		%obj = newObject("","Mine","Blues");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5,false);

		//%count -= 1;
		//schedule("DeployDisc(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
}

MineData blues
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "logo";
	shapeFile = "discb";
	shadowDetailMask = 4;
	explosionId = FlashExpsmall;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Blues::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.9,%this);
}


MineData TankBomb
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Tank Bomb";
	shapeFile = "mortarammo";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 30.0;
	damageValue = 0.8;
	damageType = $MortarDamageType;
	kickBackStrength = 400;
	triggerRadius = 0.5;
	maxDamage = 1.0;
};

function TankBomb::onAdd(%this) 
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function TankBomb::onRemove(%this)
{
	//do nothing yet..
}


MineData Firebomb 
{
	mass = 0.3;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Handgrenade";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = flashExpLarge;
	explosionRadius = 30.0;
	damageValue = 0.1;
	damageType = $ExplosionDamageType;
	kickBackStrength = 350;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Firebomb::onAdd(%this) 
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
 
function Firebomb::onRemove(%this)
{
	//do nothing yet..
}


MineData FakeFlag
{
	className = "Mine";
	description = "Fake Flag Mine";
	shapeFile = "flag";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};


};

function FakeFlag::onAdd(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "FlagMine"]++;
	%this.damage = 0;
	FakeFlag::deployCheck(%this);
}

function FakeFlag::onCollision(%this,%object)
{
	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this visible for a second 
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if(((%type == "Player") || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)))
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function FakeFlag::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	{
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)	|| $TeamItemCount[GameBase::getTeam(%this) @ "FlagMine"] > $TeamItemMax[FlagMine])
		{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("FakeFlag::deployCheck(" @ %this @ ");", 3, %this);
}	

function FakeFlag::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "FlagMine"]--;
}

function FakeFlag::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $MineDamageType)
			%value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}


MineData ReplicatorMine
{
	className = "Mine";
	description = "Replicating Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ReplicatorMine::onAdd(%this)
{
	%this.damage = 0;
	ReplicatorMine::deployCheck(%this);
}

function ReplicatorMine::onCollision(%this,%object)
{
	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this visible for a second 
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if(((%type == "Player") || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)))
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ReplicatorMine::deployCheck(%this)
{
	if(GameBase::isAtRest(%this))
	{
		%team = GameBase::getTeam(%this);
		echo(%team @ " in deploy check");

		$TeamItemCount[%team @ "replicatingmine"]++;
		if(%this.generation == 0)
			$TeamItemCount[%team @ "originalreplicatingmine"]++;
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0) || $TeamItemCount[%team @ "replicatingmine"] > $TeamItemMax[replicatingmine] || $TeamItemCount[%team @ "originalreplicatingmine"] > 5)
		{
			%this.generation = 5;
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("ReplicatorMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ReplicatorMine::onDestroyed(%this)
{
	%team = GameBase::getTeam(%this);
	echo(%team @ " in on Destroyed");

	$TeamItemCount[%team @ "replicatingmine"]--;

	if(%this.generation < 4)
		replicateMines(%this, %this.generation+1);
}

function ReplicatorMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	 if(%type == $MineDamageType)
			%value = %value * 0.3;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function replicateMines(%this, %generation)
{
	%team = GameBase::getTeam(%this);
	echo("Creating generation " @ %generation @ " for team " @ %team);

	%obj = newObject("","Mine","ReplicatorMine");
	%obj.cloakable = true;	//for base cloaker
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);

	%obj = newObject("","Mine","ReplicatorMine");
			%obj.cloakable = true;	//for base cloaker
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);
}

MineData Bomba
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bomba::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombb
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombb::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Bombc
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombc::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

MineData Bombd
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = GrenadeExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombd::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

MineData Bombe
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = mortarExp;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombe::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

MineData Bombf
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "force";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 25.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 1.5;
};

function Bombf::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",0.375,%this);
}



//-------Mine Launcher---------

MineData MineShell1
{
	mass = 5.0;
	drag = 1.0;
	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Mine";
	description = "Mini Mine";
	shapeFile = "mine";
	shadowDetailMask = 4;
	explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.6;
	damageType = $MineDamageType;
	kickBackStrength = 100;
	triggerRadius = 2;
	maxDamage = 1.0;
};

function MineShell1::onAdd(%this)
{
	%this.damage = 0;
	MineShell1::deployCheck(%this);
	$mine::count++;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}

function MineShell1::onRemove(%this)
{
	$mine::count -= 1;
	if(!$dedicated)
		bottomprint(2049,"Ammo count= "@$Ammo::count@" Item count= "@$item::count@" Miner count= "@$mine::count);
}


function MineShell1::onCollision(%this,%object)
{	
	if($debug) 
		event::collision(%this,%object);

	if(%this.cloaked > 0 && getObjectType(%object) == "Player"){
		GameBase::startFadein(%this);	
		%this.cloaked = "";
		}//pop this visible for a second 
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) //no teamdmg
	{
		GameBase::setDamageLevel(%this, %data.maxDamage);
		$mine::count--;
	}
}

// modified so cannot tk, even if player is dead 
function MineShell1::deployCheck(%this)
{
	if(GameBase::isAtRest(%this)) 
	{
		GameBase::playSequence(%this,1,"deploy");
		GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		{
			if(!%this.noOwner)
			{
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
			//$mine::count--;
			}
			else if(%this.noOwner) 
			{
			%this.noOwner = "";
			deleteObject(%this);
			$mine::count--;
			}
			
			
		}
		deleteObject(%set);
	}
	else 
		schedule("MineShell1::deployCheck(" @ %this @ ");", 3, %this);
}
