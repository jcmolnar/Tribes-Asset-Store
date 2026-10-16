

MineData AntipersonelMine 
	{ 
	className = "Mine"; 
	description = "Antipersonel Mine"; 
	shapeFile = "mine"; 
	shadowDetailMask = 4; 
	explosionId = mineExp; 
	explosionRadius = 10.0; 
	damageValue = 0.75; 
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
	AntipersonelMine::deployCheck(%this); 
	} 

function AntipersonelMine::onCollision(%this,%object) 
	{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	} 

function AntipersonelMine::deployCheck(%this) 
	{ 
	if (GameBase::isAtRest(%this)) 
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
	else 
	schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 2, %this); 
	} 

function AntipersonelMine::onDestroyed(%this) 
	{ 
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--; 
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

MineData DMMine 
	{ 
	className = "Mine"; 
	description = "Antipersonel Mine"; 
	shapeFile = "mine"; 
	shadowDetailMask = 4; 
	explosionId = Largeshockwave2; 
	explosionRadius = 10.0; 
	damageValue = 0.25; 
	damageType = $ShrapnelDamageType; 
	kickBackStrength = 550; 
	triggerRadius = 2.5; 
	maxDamage = 0.5;
	shadowDetailMask = 0; 
	destroyDamage = 1.0; 
	damageLevel = {1.0, 1.0}; 
	}; 

function DMMine::onAdd(%this) 
	{ 
	%this.damage = 0; 
	DMMine::deployCheck(%this); 
	} 

function DMMine::onCollision(%this,%object) 
	{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) ) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	} 

function DMMine::deployCheck(%this) 
	{ 
	if (GameBase::isAtRest(%this)) 
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
	else 
	schedule("DMMine::deployCheck(" @ %this @ ");", 3, %this); 
	} 

function DMMine::onDestroyed(%this) 
	{ 
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--; 
	} 

function DMMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
	{ 
	if (%type == $MineDamageType) 
	%value = %value * 0.25; 
	%data = GameBase::getDataName(%this); 
	if((%data.maxDamage/1.5) < %this.damage+%value) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	else 
	%this.damage += %value; 
	} 

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

function HoloMine::onAdd(%this) 
	{ 
	%this.damage = 0; 
	HoloMine::deployCheck(%this); 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",120.0,%this); 
	} 

function HoloMine::onCollision(%this,%object) 
	{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if ((%type == "Player" || %data == HoloMine|| %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) ) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	} 

function HoloMine::deployCheck(%this) 
	{ 
	if (GameBase::isAtRest(%this)) 
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
	else 
	schedule("HoloMine::deployCheck(" @ %this @ ");", 3, %this); 
	} 

function HoloMine::onDestroyed(%this) 
	{ 
	$TeamItemCount[GameBase::getTeam(%this) @ "hologram"]--; 
	} 
	function HoloMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
	{ 
	if (%type == $MineDamageType) 
	%value = %value * 0.25; 
	%data = GameBase::getDataName(%this); 
	if((%data.maxDamage/1.5) < %this.damage+%value) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	else 
	%this.damage += %value; 
	} 

MineData Boostera 
	{ 
	className = "Mine"; 
	description = "Speed Booster"; 
	shapeFile = "mine"; 
	shadowDetailMask = 4; 
	explosionId = mineExp; 
	explosionRadius = 8.0; 
	damageValue = 0.0; 
	damageType = $MineDamageType; 
	kickBackStrength = 300; 
	triggerRadius = 250; 
	maxDamage = 0.0;
	shadowDetailMask = 0; 
	destroyDamage = 1.0; 
	damageLevel = {1.0, 1.0}; 
	}; 

function Boostera::onAdd(%this) 
	{ 
	%this.damage = 0; 
	Booster::deployCheck(%this); 
	} 

function Boostera::onCollision(%this,%object) 
	{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if ((%type == "Player" || %data == Boost || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	} 

function Boostera::deployCheck(%this) 
	{ 
	if (GameBase::isAtRest(%this)) 
	{ 
	GameBase::playSequence(%this,1,"deploy"); 
	GameBase::setActive(%this,true); 
	%set = newObject("set",SimSet); 
	if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
	{ 
	%data = GameBase::getDataName(%this); 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	} 
	} 
	else 
	schedule("Boostera::deployCheck(" @ %this @ ");", 3, %this); 
	} 

function Boostera::onDestroyed(%this) {}
 
function Boostera::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
	{ 
	if (%type == $MineDamageType) 
	%value = %value * 0.25; 
	%data = GameBase::getDataName(%this); 
	if((%data.maxDamage/1.5) < %this.damage+%value) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	else 
	%this.damage += %value; 
	} 

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
	lightColor = { 1, 1, 1 }; 
	}; 

function Hologram::onAdd(%this) 
	{ 
	%this.damage = 0; 
	Boost::deployCheck(%this); 
	} 

function Hologram::onCollision(%this,%object) 
	{ 
	%type = getObjectType(%object); 
	%data = GameBase::getDataName(%this); 
	if ((%type == "Player" || %data == Hologram || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this)) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	} 

function Hologram::deployCheck(%this) 
	{ 
	if (GameBase::isAtRest(%this)) 
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
	else 
	schedule("Hologram::deployCheck(" @ %this @ ");", 3, %this); 
	} 

function Hologram::onDestroyed(%this) { } 

function Hologram::onDamage(%this,%type,%value,%pos,%vec,%mom,%object) 
	{ 
	if (%type == $ShrapnelDamageType) 
	%value = %value * 0.25; 
	%data = GameBase::getDataName(%this); 
	if((%data.maxDamage/1.5) < %this.damage+%value) 
	GameBase::setDamageLevel(%this, %data.maxDamage); 
	else 
	%this.damage += %value; 
	} 

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
	explosionId = napalmExp; 
	explosionRadius = 12.5; 
	damageValue = 0.55; 
	damageType = $PlasmaDamageType; 
	kickBackStrength = 0; 
	triggerRadius = 0.5; 
	maxDamage = 2.0; 
	}; 

function Concussion::onAdd(%this) 
	{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); 
	} 

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
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); 
	} 

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
	explosionRadius = 10.0; 
	damageValue = 2.0; 
	damageType = $MortarDamageType; 
	kickBackStrength = 300; 
	triggerRadius = 0.5; 
	maxDamage = 2.0; 
	}; 

function Nukebomb::onAdd(%this) 
	{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",10.0,%this); 
	} 

function Nukebomb::onCollision(%this,%obj) 
	{ 
	if(getObjectType(%obj) != "Player") 
	{ 
	return; 
	} 
	if(Player::isDead(%obj)) 
	{ 
	return; 
	} 
	%c = Player::getClient(%obj); 
	%playerTeam = GameBase::getTeam(%obj); 
	%teleTeam = GameBase::getTeam(%this); 
	%armor = Player::getArmor(%obj); 
	if (%armor == "earmor" || %armor == "efemale") 
	{ 
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 8) 
	{ 
	Client::sendMessage(%c,1,"OOPS! You cut the wrong wire..."); 
	Mine::Detonate(" @ %this @ "); 
	return; 
	} 
	else 
	{ 
	deleteObject(%this); 
	Client::sendMessage(%c,1,"You disarm the Plastique Explosive."); 
	} 
	} 
	} 

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
	damageValue = 5.0; 
	damageType = $ShrapnelDamageType; 
	kickBackStrength = 300; 
	triggerRadius = 0.5; 
	maxDamage = 2.0; 
	}; 

function Suicidebomb::onAdd(%this) 
	{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",0.5,%this); 
	} 

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
	explosionRadius = 50.0; 
	damageValue = 5.0; 
	damageType = $ShrapnelDamageType; 
	kickBackStrength = 300; 
	triggerRadius = 0.5; 
	maxDamage = 2.0; 
	}; 

function Suicidebomb2::onAdd(%this) 
	{ 
	%data = GameBase::getDataName(%this); 
	schedule("Mine::Detonate(" @ %this @ ");",15,%this); 
	} 

function Suicidebomb2::onCollision(%this,%obj) 
	{ 
	if(getObjectType(%obj) != "Player") 
	{ 
	return; 
	} 
	if(Player::isDead(%obj)) 
	{ 
	return; 
	} 
	%c = Player::getClient(%obj); 
	%playerTeam = GameBase::getTeam(%obj); 
	%teleTeam = GameBase::getTeam(%this); 
	%armor = Player::getArmor(%obj); 
	if (%armor == "earmor" || %armor == "efemale") 
	{ 
	%rnd = floor(getRandom() * 10); 
	if(%rnd > 8) 
	{ 
	Client::sendMessage(%c,1,"OOPS! You cut the wrong wire..."); 
	Mine::Detonate(" @ %this @ "); 
	return; 
	} 
	else 
	{ 
	deleteObject(%this); 
	Client::sendMessage(%c,1,"You disarm the DetPack."); 
	} 
	} 
	} 

MineData Mortarbomb 
	{ 
	mass = 0.3; 
	drag = 1.0; 
	density = 2.0; 
	elasticity = 0.15; 
	friction = 1.0; 
	className = "Handgrenade"; 
	description = "Handgrenade"; 
	shapeFile = "mortarammo"; 
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
   explosionId = debrisExpLarge;
	explosionRadius = 20.0;
	damageValue = 0.1;
	damageType = $flashExpLarge;
	kickBackStrength = 600;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Firebomb::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
      schedule("DeployFrags(" @ %this @ " , 5);",1.0,%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}
function DeployFrags(%this, %count) 
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Frag1");
 		%team = GameBase::getTeam(%this);
            GameBase::setTeam(%obj, %team);

 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);

		%obj = newObject("","Mine","Frag2");
		%team = GameBase::getTeam(%this);
            GameBase::setTeam(%obj, %team);

 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);

		%obj = newObject("","Mine","Frag3");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0,false);
		%count -= 1;
		schedule("DeployFrags(" @ %this @ " , " @ %count @ ");",0.5,%this);
	}
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
//=-=-=-=-=-ClusterBomb++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Frag1x
{	
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ExplosionDamageType;
	kickBackStrength = 50;
	triggerRadius = 5.0;
	maxDamage = 1.5;
};

function Frag1x::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",8.0,%this);//2.0+++++++++++
}

MineData Frag2x
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ExplosionDamageType;
	kickBackStrength = 50;
	triggerRadius = 5.0;
	maxDamage = 1.5;
};

function Frag2x::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",8.5,%this);//2.25++++++++++++
}

MineData Frag3x
{
   	mass = 5.0;
   	drag = 1.0;
   	density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
	description = "Bomblet";
	shapeFile = "grenade";
	shadowDetailMask = 4;
	explosionId = rocketExp;
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $ExplosionDamageType;
	kickBackStrength = 50;
	triggerRadius = 5.0;
	maxDamage = 1.5;
};

function Frag3x::onAdd(%this)
{
	schedule("Mine::Detonate(" @ %this @ ");",9.0,%this);//2.5++++++++
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
//================
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Claymore
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = flashExpLarge;
	explosionRadius = 20.0;
	damageValue = 1.5;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.85, 0.25, 0.25 };
};

function Claymore::onAdd(%this)
{
	%this.damage = 0;
	Claymore::deployCheck(%this);
}

function Claymore::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function Claymore::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("Claymore::deployCheck(" @ %this @ ");", 3, %this);
}	

function Claymore::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function Claymore::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData TreeMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "discammo";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 30.0;
	damageValue = 0.3; //0.5;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 4.0;
	maxDamage = 6.0;
	shadowDetailMask = 0;
	destroyDamage = 6.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.75;
	lightColor = { 0.25, 0.25, 0.25 };
};

function TreeMine::onAdd(%this)
{
	%this.damage = 0;
	TreeMine::deployCheck(%this);
}

function TreeMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == Vehicle) &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function TreeMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("TreeMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function TreeMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function TreeMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData EMPMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 30.0;
	damageValue = 0.1;
	damageType = $EMPDamageType;
	kickBackStrength = 50;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.75, 0.25, 0.65 };
};

function EMPMine::onAdd(%this)
{
	%this.damage = 0;
	EMPMine::deployCheck(%this);
}

function EMPMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function EMPMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("EMPMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function EMPMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function EMPMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData MortarMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 1.0;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.25, 0.75, 0.05 };
};

function MortarMine::onAdd(%this)
{
	%this.damage = 0;
	MortarMine::deployCheck(%this);
}

function MortarMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MortarMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("MortarMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function MortarMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function MortarMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData ShockwaveMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = DebrisExpLarge;
	explosionRadius = 30.0;
	damageValue = 0.45;
	damageType = $MineDamageType;
	kickBackStrength = 350;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.05, 0.25, 0.45 };
};

function ShockwaveMine::onAdd(%this)
{
	%this.damage = 0;
	ShockwaveMine::deployCheck(%this);
}

function ShockwaveMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function ShockwaveMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("ShockwaveMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ShockwaveMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function ShockwaveMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData StingerMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = debrisExpLarge;
	explosionRadius = 20.0;
	damageValue = 0.55;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};

      lightType = 2;   // Pulsing
	lightRadius = 1;
	lightTime = 0.75;
	lightColor = { 0.75, 0.75, 0.35 };
};

function StingerMine::onAdd(%this)
{
	%this.damage = 0;
	StingerMine::deployCheck(%this);
}

function StingerMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function StingerMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("StingerMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function StingerMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function StingerMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData HologramMine
{
	className = "Mine";
   description = "Antipersonel Mine";
   shapeFile = "larmor";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 20.0;
	damageValue = 0.5;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 5.0;
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function HologramMine::onAdd(%this)
{
	%this.damage = 0;
	HologramMine::deployCheck(%this);
}

function HologramMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function HologramMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("HologramMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function HologramMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function HologramMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData BlastMine
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Demolition Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 10.0;
	damageValue = 1.35; //1.35+++++++++
	damageType = $MortarDamageType; 
	kickBackStrength = 350;
	triggerRadius = 5.0;
	maxDamage = 100.0;

      lightType = 2;   // Pulsing
	lightRadius = 8;
	lightTime = 0.1;
	lightColor = { 0.85, 0.25, 0.25 };
};

function BlastMine::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",5.0,%this);
}

function BlastMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%damageLevel = GameBase::getDamageLevel(%this);
	GameBase::setDamageLevel(%this,%damageLevel + %value);
}

function BlastMine::Detonate(%this)
{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
}
MineData MotionMine
{
	className = "DeployableSensor";
   description = "Antipersonel Mine";
   shapeFile = "Sensor_Small"; //"sensor_small";
   shadowDetailMask = 4;
   explosionId = mineExp;

	visibleToSensor = true;//++++++
	range = 50;//+++++++
	dopplerVelocity = 1;//+++++++++
   castLOS = false;//++++++
   supression = false;//+++++
	supressable = false;//++++++
	pinger = false;//++++++++

	explosionRadius = 15.0; //20
	damageValue = 0.65; 
	damageType = $MineDamageType;
	kickBackStrength = 150; 
	triggerRadius = 5; //8
	maxDamage = 1.0;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function MotionMine::onAdd(%this)
{
	%this.damage = 0;
	MotionMine::deployCheck(%this);
}

function MotionMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == MotionMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function MotionMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set); //
	}
	else 
		schedule("MotionMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function MotionMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function MotionMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
function DeployableSensor::onAdd(%this)
{
	schedule("DeployableSensor::deploy(" @ %this @ ");",1,%this);
}

function DeployableSensor::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function DeployableSensor::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
	GameBase::playSequence(%this,0,"power");
}
//-=-=-=-=-=-=-=-=-=-=-=-=-
// _RaMpAgE_v1.7 New Nades!
//-=-=-=-=-=-=-=-=-=-=-=-=-
//----------------------------------------------------------------------------

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
        maxDamage = 2;
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

MineData SmallGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Small Handgrenade";
   shapeFile = "force";
   shadowDetailMask = 4;
   explosionId = debrisExpLarge;
        explosionRadius = 5.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function SmallGrenade::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
	  schedule("DeployShrapnel(" @ %this @ " , 7);",2.0,%this);
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

MineData ShockGrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Shock Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = debrisExpLarge;
        explosionRadius = 10.0;
        damageValue = 0.5;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function ShockGrenade::onAdd(%this)
{
      schedule("ShockZap(" @ %this @ ");",1.9,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
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

function ShockZap(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

//----------------------------------------------------------------------------

MineData C4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Shock Grenade";
   shapeFile = "grenammo";
   shadowDetailMask = 4;
   explosionId = GrenadeExp;
        explosionRadius = 25.0;
        damageValue = 15;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 14.999;
};

function C4::onAdd(%this)
{
      schedule("ShockZap(" @ %this @ ");",14.95,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15.0,%this);
}

MineData C4Quick
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Shock Grenade";
   shapeFile = "grenammo";
   shadowDetailMask = 4;
   explosionId = GrenadeExp;
        explosionRadius = 25.0;
        damageValue = 2.5;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 5;
};

function C4Quick::onAdd(%this)
{
      schedule("ShockZap(" @ %this @ ");",1.99,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
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

function ShockZap(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

//from here on: added by werewolf edited by Bhall


MineData TNT
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Blast Pack";
   shapeFile = "magcargo";
   shadowDetailMask = 4;
   explosionId = MortarExp;
        explosionRadius = 50;
        damageValue = 30;
        damageType = $FlierBombDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 29.999;
};

function TNT::onAdd(%this)
{
      schedule("TNTExplosion(" @ %this @ ");",14.95,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

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

function TNTExplosion(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","shockadd2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 2";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","shockadd3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 4";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}
//==================================================================================================== Suicide Pack 2 On Deploy

MineData Shockadd
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "End of the line";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0.25;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 0.5;
};

function shockadd::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Shockadd2
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "End of the line";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0.25;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 0.5;
};

function shockadd2::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData Shockadd3
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "End of the line";
        shapeFile = "force";
        shadowDetailMask = 4;
        explosionId = LargeShockwave;
        explosionRadius = 37.5;
        damageValue = 0.25;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 0.5;
};

function shockadd3::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData MinePlayer1
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.001;
        friction = 1.0;
        className = "Holomine";
        description = "Lagging Player";
        shapeFile = "larmor";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 10.0;
        damageValue = 20.0;
        damageType = $BustedDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 20.5;
};

function MinePlayer1::onAdd(%this)
{
                schedule("MinePlayer1Explosion(" @ %this @ ");",15,%this);
%data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function MinePlayer1::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
        {
        return;
        }

    if(Player::isDead(%obj))
        {
        return;
        }

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
        %teleTeam = GameBase::getTeam(%this);


%armor = Player::getArmor(%obj);
                   if (%armor == "earmor" || %armor == "efemale")
                {
                %rnd = floor(getRandom() * 10);
                                                        if(%rnd > 7)
                                                        {
                                                          Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
                                                                Mine::Detonate(" @ %this @ ");
                                                        return;
                                                        }
                                                        else
                                                        {
                                                        deleteObject(%this);
                                                        Client::sendMessage(%c,1,"You disarmed the Dynamite.");
                                                        }
                }

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

function MinePlayer1Explosion(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 1.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

MineData MinePlayer2
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.001;
        friction = 1.0;
        className = "Holomine";
        description = "Lagging Player";
        shapeFile = "marmor";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 10.0;
        damageValue = 20.0;
        damageType = $BustedDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 20.5;
};


function MinePlayer2::onAdd(%this)
{
                schedule("MinePlayer2Explosion(" @ %this @ ");",15,%this);
%data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function MinePlayer2::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
        {
        return;
        }

    if(Player::isDead(%obj))
        {
        return;
        }

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
        %teleTeam = GameBase::getTeam(%this);


%armor = Player::getArmor(%obj);
                   if (%armor == "earmor" || %armor == "efemale")
                {
                %rnd = floor(getRandom() * 10);
                                                        if(%rnd > 7)
                                                        {
                                                          Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
                                                                Mine::Detonate(" @ %this @ ");
                                                        return;
                                                        }
                                                        else
                                                        {
                                                        deleteObject(%this);
                                                        Client::sendMessage(%c,1,"You disarmed the Dynamite.");
                                                        }
                }

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

function MinePlayer2Explosion(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);

               %padd = "0 0 1.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}

MineData MinePlayer3
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.001;
        friction = 1.0;
        className = "Holomine";
        description = "Lagging Player";
        shapeFile = "harmor";
        shadowDetailMask = 4;
        explosionId = mortarExp;
        explosionRadius = 10.0;
        damageValue = 20.0;
        damageType = $BustedDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 20.5;
};

function MinePlayer3::onAdd(%this)
{
                schedule("MinePlayer3Explosion(" @ %this @ ");",15,%this);
%data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",15,%this);

}

function MinePlayer3::onCollision(%this,%obj)
{
    if(getObjectType(%obj) != "Player")
        {
        return;
        }

    if(Player::isDead(%obj))
        {
        return;
        }

    %c = Player::getClient(%obj);


    %playerTeam = GameBase::getTeam(%obj);
        %teleTeam = GameBase::getTeam(%this);


%armor = Player::getArmor(%obj);
                   if (%armor == "earmor" || %armor == "efemale")
                {
                %rnd = floor(getRandom() * 10);
                                                        if(%rnd > 7)
                                                        {
                                                          Client::sendMessage(%c,1,"OOPS! You cut the wrong wire...");
                                                                Mine::Detonate(" @ %this @ ");
                                                        return;
                                                        }
                                                        else
                                                        {
                                                        deleteObject(%this);
                                                        Client::sendMessage(%c,1,"You disarmed the Dynamite.");
                                                        }
                }

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

function MinePlayer3Explosion(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 1.0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);

}


//=-=-=-=-
MineData Cluster1
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15;
        damageValue = 0.5;
        damageType = $PlasmaDamageType;
        kickBackStrength = 50;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Cluster1::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData Cluster2
{
           mass = 4.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15;
        damageValue = 0.8;
        damageType = $PlasmaDamageType;
        kickBackStrength = 150;
        triggerRadius = 0.8;
        maxDamage = 2.5;
};

function Cluster2::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",2.25,%this);
}

MineData Cluster3
{
          mass = 8.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.55;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 1.0;
        damageType = $PlasmaDamageType;
        kickBackStrength = 250;
        triggerRadius = 1.5;
        maxDamage = 2.5;
};

function Cluster3::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

MineData Cluster4
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.28;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $PlasmaDamageType;
        kickBackStrength = 40;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Cluster4::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",2.75,%this);
}

MineData Cluster5
{
           mass = 5.0;
           drag = 1.0;
           density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
        description = "Cluster";
        shapeFile = "grenade";
        shadowDetailMask = 4;
        explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $PlasmaDamageType;
        kickBackStrength = 10;
        triggerRadius = 0.5;
        maxDamage = 1.5;
};

function Cluster5::onAdd(%this)
{
        schedule("Mine::Detonate(" @ %this @ ");",1.75,%this);
}



//----------------------------------------------------------------------------

MineData PocketNuke1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Pocket Nuke 1";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = FDExp;
        explosionRadius = 10.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 4;
};

function PocketNuke1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
	  schedule("DeployShrapnel(" @ %this @ " , 32);",2.0,%this);
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

//----------------------------------------------------------------------------

MineData PocketNuke2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Pocket Nuke 2";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 4;
};

function PocketNuke2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
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

MineData HavocBlast
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Pocket Nuke 2";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 20.0;
        damageValue = 5;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 4;
};

function HavocBlast::onAdd(%this)
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

MineData BSPulla
{
   mass = 0;
   drag = 1.0;
   density = 2.0;
        elasticity = 0;
        friction = 0;
        className = "Singularity";
   description = "Singularity";
   shapeFile = "breath";
   shadowDetailMask = 4;
   explosionId = MortarExp;
        explosionRadius = 75.0;
        damageValue = 101;
        damageType = $VulcanDamageType;
        kickBackStrength = -1024;
        triggerRadius = 0.5;
        maxDamage = 100;
};

function BSPulla::onAdd(%this)
{
      schedule("BShaRMSUCK(" @ %this @ ");",2.9,%this);
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this  @ ");",3,%this);
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

function BSHarmSuck(%this)
{
                %obj = newObject("","Mine","shockadd");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 0";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","shockadd2");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 2";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
                %obj = newObject("","Mine","shockadd3");
                addToSet("MissionCleanup", %obj);
                %padd = "0 0 4";
                %pos = Vector::add(GameBase::getPosition(%this), %padd);
                GameBase::setPosition(%obj, %pos);
}

MineData BSpull1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",0.25,%this);
}

MineData BSpull2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",0.5,%this);
}

MineData BSpull3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",0.75,%this);
}

MineData BSpull4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}

MineData BSpull5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",1.25,%this);
}

MineData BSpull6
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull6::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",1.5,%this);
}

MineData BSpull7
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull7::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",1.75,%this);
}

MineData BSpull8
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull8::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

MineData BSpull9
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.15;
        friction = 1.0;
        className = "Handgrenade";
   description = "Black star negative force";
   shapeFile = "rsmoke";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
        explosionRadius = 150.0;
        damageValue = 0;
        damageType = $NullDamageType;
        kickBackStrength = -512;
        triggerRadius = 0.5;
        maxDamage = 0;
};

function BSpull9::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.5,%this);
}

//----------------------------------------------------------------------------

MineData MDHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MDHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MDHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.45;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
        explosionRadius = 15.0;
        damageValue = 0.5;
        damageType = $ShrapnelDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MDHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;

        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Mortar";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = mortarExp;
        explosionRadius = 20.0;
        damageValue = 1;
        damageType = $MortarDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 2;
};

function MHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}


MineData MEHandgrenade1
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade1::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//----------------------------------------------------------------------------

MineData MEHandgrenade2
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade2::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.4,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade3
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade3::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",2.7,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade4
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade4::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.1,%this);
}
//----------------------------------------------------------------------------

MineData MEHandgrenade5
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
        elasticity = 0.25;
        friction = 1.0;
        className = "Handgrenade";
   description = "Implosion Explosion";
   shapeFile = "armorkit";
   shadowDetailMask = 4;
   explosionId = impExp;
        explosionRadius = 7.5;
        damageValue = 1;
        damageType = $MineDamageType;
        kickBackStrength = 100;
        triggerRadius = 0.5;
        maxDamage = 1;
};

function MHandgrenade5::onAdd(%this)
{
        %data = GameBase::getDataName(%this);
        schedule("Mine::Detonate(" @ %this @ ");",3.5,%this);
}

//----------------------------------------------------------------------------

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
//PORT-OFF: sionCleanup", %obj);
//PORT-OFF: 		GameBase::throw(%obj,%this, 25,true);
//PORT-OFF: 		%count -= 1;
//PORT-OFF: 		schedule("DeployShrapnel(" @ %this @ ", " @ %count @ ");",0.5,%this);
//PORT-OFF: 	}
//PORT-OFF: }
