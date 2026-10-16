//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

// Removed Because Ideal has replaced them.
$InvList[MineAmmo] = 0;
$InvList[Grenade] = 0;
$RemoteInvList[MineAmmo] = 0;
$RemoteInvList[Grenade] = 0;

// Not currently working. :(
// Since its not used very often, this is not a high priority bug
// but none the less I'll work on it when I get a chance.
$InvList[FlagMine] = 0;
$RemoteInvList[FlagMine] = 0;

MineData AntipersonelMine
{
	className = "Mine";
   description = "Antipersonel Mine";
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

function AntipersonelMine::onAdd(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "originalmine"]++;
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object)
{
		%type = getObjectType(%object);
		%data = GameBase::getDataName(%this);
		if (((%type == "Player") || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) //JR 1/31/99
			GameBase::setDamageLevel(%this, %data.maxDamage);
}


function AntipersonelMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)  || $TeamItemCount[GameBase::getTeam(%this) @ "originalmine"] > $TeamItemMax[originalmine])
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
	$TeamItemCount[GameBase::getTeam(%this) @ "originalmine"]--;
}

function AntipersonelMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//mod:

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
		%type = getObjectType(%object);
		%data = GameBase::getDataName(%this); 
		if (((%type == "Player") || %data.className == Mine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) //JR 1/31/99
			GameBase::setDamageLevel(%this, %data.maxDamage);
}

function FakeFlag::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)  || $TeamItemCount[GameBase::getTeam(%this) @ "FlagMine"] > $TeamItemMax[FlagMine])
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
   if (%type == $MineDamageType)
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
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if (((%type == "Player")  || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object))) //JR 1/31/99
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
   if (%type == $MineDamageType)
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
 	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,-1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);

	%obj = newObject("","Mine","ReplicatorMine");
	addToSet("MissionCleanup", %obj);
	GameBase::throw(%obj,%this,1.5,false);
	%obj.generation = %generation;

	GameBase::setTeam(%obj, %team);
}

//----------------------------------------------------------------------------

MineData Handgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.5;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Flashgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp1;
	explosionRadius = 0.0;
	damageValue = 0.5;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Flashgrenade1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Flashgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp2;
	explosionRadius = 0.0;
	damageValue = 0.5;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Flashgrenade2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Flashgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp3;
	explosionRadius = 0.0;
	damageValue = 0.5;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Flashgrenade3::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Flashgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp4;
	explosionRadius = 0.0;
	damageValue = 0.5;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Flashgrenade4::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Flashgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Flash Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = flashGrenExp;
	explosionRadius = 0.0;
	damageValue = 0.5;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};
//Thanks *IX*Savage1!
function Flashgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("DeployFlash(" @ %this @ " , 5);",0.8,%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.9,%this);
}

function DeployFlash(%this, %count) 
{
	if(%count && %this)
	{

		%rand = 1 + floor(getRandom() * 4);

		%name = "Flashgrenade" @ %rand;

		%obj = newObject("","Mine",%name);
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.3,true);
		
		%obj = newObject("","Mine",%name);
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.3,true);


		%count -= 1;
		schedule("DeployFlash(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}


MineData Stungrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Stun Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = plasmaExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $StunDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Stungrenade1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.3,%this);
}

MineData Stungrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Stun Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = plasmaExp;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $StunDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};
//Thanks *IX*Savage1!
function Stungrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("DeployStun(" @ %this @ " , 5);",0.8,%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.9,%this);
}

function DeployStun(%this, %count) 
{
	if(%count && %this)
	{

		%name = "Stungrenade1";

		%obj = newObject("","Mine",%name);
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.5,true);
		
		%obj = newObject("","Mine",%name);
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.5,true);

		%count -= 1;
		schedule("DeployStun(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}

MineData Smokegrenade
{
   mass = 0.0;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.35;
	friction = 1.0;
	className = "grenade";
   description = "Smoke Grenade";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = smokeGrenExp;
	explosionRadius = 0.0;
	damageValue = 0.5;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Smokegrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
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

MineData C4
{
   mass = 1;
   drag = 30.0;
   density = 2.0;
	elasticity = 0;
	friction = 20.0;
	className = "grenade";
   description = "C4";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 15.0;
	damageValue = 3.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function C4::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",10.0,%this);
}

MineData C4Oops
{
   mass = 10;
   drag = 3.0;
   density = 2.0;
	elasticity = 0;
	friction = 20.0;
	className = "grenade";
   description = "C4";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 3.0;
	damageValue = 3.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function C4Oops::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.01,%this);
}

MineData C4Dud
{
   mass = 10;
   drag = 3.0;
   density = 2.0;
	elasticity = 0;
	friction = 20.0;
	className = "grenade";
   description = "C4";
   shapeFile = "sensor_small";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 0.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function C4Dud::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",10.0,%this);
}


MineData SuicideBomb
{
	mass = 0;
	drag = 3.0;
	density = 2.0;
	elasticity = 0;
	friction = 2.0;
	className = "grenade";
	description = "Suicide Bomb";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 50.0;
	damageValue = 80.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function SuicideBomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData SuicideBomb2
{
	mass = 0;
	drag = 3.0;
	density = 2.0;
	elasticity = 0;
	friction = 2.0;
	className = "grenade";
	description = "Suicide Bomb";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = grenadeExp;
	explosionRadius = 3.0;
	damageValue = 80.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function SuicideBomb2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
MineData TeleFX
{
	mass = 0;
	drag = 3.0;
	density = 2.0;
	elasticity = 0;
	friction = 2.0;
	className = "grenade";
	description = "Teleport FX";
	shapeFile = "breath";
	shadowDetailMask = 4;
	explosionId = LargeShockwave;
	explosionRadius = 50.0;
	damageValue = 0.0;
	damageType = $NoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function TeleFX::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}