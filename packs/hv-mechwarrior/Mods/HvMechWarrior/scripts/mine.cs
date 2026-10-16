//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

MineData AntipersonelMine
{
	className = "Mine";
   description = "Vibro-Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = BombExp;
	explosionRadius = 15.0;
	damageValue = 1.0; //0.7;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 5;
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
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %data == Moveable) &&
			GameBase::isActive(%this)
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg++++++++++++
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AntipersonelMine::deployCheck(%this)
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
		schedule("AntipersonelMine::deployCheck(" @ %this @ ");", 3, %this);
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

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData DmMine
{
	className = "Mine";
   description = "Vibro-Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = BombExp;
	explosionRadius = 15.0; //250
	damageValue = 1.0; //0.7;
	damageType = $MineDamageType;
	kickBackStrength = 250;
	triggerRadius = 5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function DmMine::onAdd(%this)
{
	%this.damage = 0;
	DmMine::deployCheck(%this);
}

function DmMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %data == Moveable) &&
			GameBase::isActive(%this)
			)
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DmMine::deployCheck(%this)
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
		schedule("DmMine::deployCheck(" @ %this @ ");", 1, %this); //3+++++++++++
}	

function DmMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function DmMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData LRMMine
{
	className = "Mine";
   description = "Vibro-Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = BombExp;
	explosionRadius = 15.0;
	damageValue = 0.5;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function LRMMine::onAdd(%this)
{
	%this.damage = 0;
	LRMMine::deployCheck(%this);
	GameBase::setTeam(%this,$HVteam);//++++++
}

function LRMMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %data == Moveable) && GameBase::isActive(%this)
//			&& (GameBase::getTeam($HVteam)!=GameBase::getTeam(%this)) //no teamdmg++++++++++++
			&& (GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg++++++++++++
			) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function LRMMine::deployCheck(%this)
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
		schedule("LRMMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function LRMMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function LRMMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
//+++++++++++++++++++++++++++++++++
MineData LRMCluster
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Pocket Nuke";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp2; //BombExp;
	explosionRadius = 20.0;
	damageValue = 0.3;
	damageType = $ExplosionDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 7;
	lightTime = 0.1;//++++
	lightColor = { 0.6, 0.4, 0.15  };
};
function LRMCluster::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//+++++++++++++++++++++++++++++++++++++++++++++++
MineData ArtyShell
{
	className = "Mine";
   description = "Vibro-Mine";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp2;
	explosionRadius = 15.0;
	damageValue = 0.3;
	damageType = $ExplosionDamageType;
	kickBackStrength = 150;
	triggerRadius = 5;
	maxDamage = 0.25;
	shadowDetailMask = 0;
	destroyDamage = 0.25;
	damageLevel = {1.0, 1.0};
};

function ArtyShell::onAdd(%this)
{
//	%this.damage = 0;//+++++++
//	ArtyShell::deployCheck(%this);//++++
//	%data = GameBase::getDataName(%this);
	schedule("artyDeploy(" @ %this @ " , 1);",0.01,%this);
 	GameBase::setActive(%this,true);//++++++++++++
}
function artyDeploy(%this,%count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","ArtyBomblet");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.15,false);
		%obj = newObject("","Mine","ArtyBomblet");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.15,false);
		%obj = newObject("","Mine","ArtyBomblet");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.3,false);
		%obj = newObject("","Mine","ArtyBomblet");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.3,false);
		%obj = newObject("","Mine","ArtyBomblet");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-0.5,false);
		%obj = newObject("","Mine","ArtyBomblet");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,0.5,false);
		%count -= 1;
		schedule("artyDeploy(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
function ArtyShell::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
//	%damageLevel = GameBase::getDamageLevel(%this);
//	if(%damageLevel > 0)
//	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this); //++++++++++
	GameBase::setDamageLevel(%this,%data.maxDamage);
}
function ArtyShell::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %type == "SimTerrain" || %type == "InteriorShape" || %data == AntipersonelMine || %data == Vehicle || %data == Moveable)&&GameBase::isActive(%this))
		GameBase::setDamageLevel(%this, %data.maxDamage);
//		GameBase::setDamageLevel(%this, 99);
}

//+++++++++++++++++++++++++++++++++++++++++++++++
MineData ArtyBomblet
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Mine"; //"Handgrenade";
   description = "Pocket Nuke";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp2;
	explosionRadius = 15.0;
	damageValue = 0.3;
	damageType = $ExplosionDamageType;
	kickBackStrength = 150;
	triggerRadius = 5;
	maxDamage = 0.25;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 0.75, 0.55, 0.25  };
};

function ArtyBomblet::onAdd(%this)
{
//	%this.damage = 0;//+++++++
//	ArtyShell::deployCheck(%this);//++++
//	%data = GameBase::getDataName(%this);
//	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
 	GameBase::setActive(%this,true);//++++++++++++
}
function ArtyBomblet::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
//	%damageLevel = GameBase::getDamageLevel(%this);
//	if(%damageLevel > 0)
//	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this); //++++++++++
	GameBase::setDamageLevel(%this,%data.maxDamage);
}
function ArtyBomblet::onCollision(%this,%object)
{
		GameBase::setDamageLevel(%this, 99);
//	%type = getObjectType(%object);
//	%data = GameBase::getDataName(%this);
//	if ((%type == "Player" || %type == "SimTerrain" || %type =="InteriorShape" || %data == AntipersonelMine || %data == Vehicle || %data == Moveable) && (GameBase::isActive(%this))
//		{
//		GameBase::setDamageLevel(%this, %data.maxDamage);
//		}
//	else
//	{
//	GameBase::setDamageLevel(%this, %data.maxDamage);
//	}
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData IMine
{
	className = "Mine";
   description = "Inferno Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = InfernoExp;
	explosionRadius = 15.0;
	damageValue = 0.5;
	damageType = $InfernoDamageType;
	kickBackStrength = 25;
	triggerRadius = 5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function IMine::onAdd(%this)
{
	%this.damage = 0;
	IMine::deployCheck(%this);
}

function IMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %data == Moveable)&&GameBase::isActive(%this)&&(GameBase::getTeam(%this)!=GameBase::getTeam(%object)) //no teamdmg++++++++++++
			)
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function IMine::deployCheck(%this)
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
		schedule("IMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function IMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function IMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData DmIMine
{
	className = "Mine";
   description = "Inferno Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = InfernoExp;
	explosionRadius = 15.0;
	damageValue = 0.5;
	damageType = $InfernoDamageType;
	kickBackStrength = 25;
	triggerRadius = 5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function DmIMine::onAdd(%this)
{
	%this.damage = 0;
	DmMine::deployCheck(%this);
}

function DmIMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %data == Moveable) &&
			GameBase::isActive(%this)
			)
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function DmIMine::deployCheck(%this)
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
		schedule("DmIMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function DmIMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}

function DmIMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Handgrenade //Pocket Nuke
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Pocket Nuke";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = BombExp;
	explosionRadius = 15.0; //10.0;++++++++
	damageValue = 0.6;
	damageType = $ExplosionDamageType;
	kickBackStrength = 250;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 0.75, 0.55, 0.25  };
};

function Handgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); //3.0+++
}

//+++++++++++++++
MineData Handgrenade2 //Pocket Nuke 2
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Pocket Nuke";
   shapeFile = "breath"; //"force";+++++++++++
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 10.0;
	damageValue = 0.0;
	damageType = $ExplosionDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function Handgrenade2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); //3.0+++
}
//++++++++++++++++
MineData Handgrenade3
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Demolition Grenade";
   shapeFile = "mortar";
   shadowDetailMask = 4;
   explosionId = BombExp;
	explosionRadius = 7.0;
	damageValue = 1.0;
	damageType = $ExplosionDamageType;
	kickBackStrength = 350;
	triggerRadius = 6.0;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 8;
	lightTime = 0.05;//++++
      lightColor = { 0.85, 0.25, 0.25 };
};

function Handgrenade3::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",8.0,%this); //3.0+++
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Smoke1
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Smoke Cannister";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = SmokeExp;
	explosionRadius = 15.0;
	damageValue = 0.01;
	damageType = $DebrisDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};

function Smoke1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",1.0,%this);
}
//++++++++++++++
MineData Smoke2
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Smoke Cannister";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = SmokeExp;
	explosionRadius = 15.0;
	damageValue = 0.01;
	damageType = $DebrisDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};

function Smoke2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Nuke1
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Nuke";
   shapeFile = "force";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 15.0;
	damageValue = 0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};

function Nuke1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
//++++++++++++++++++++++++
MineData Nuke2
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Nuke";
   shapeFile = "force";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 15.0;
	damageValue = 0.4;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};

function Nuke2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Nuke3
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Nuke";
   shapeFile = "force";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 20.0;
	damageValue = 0;
	damageType = $ExplosionDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};

function Nuke3::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
//++++++++++++++++++++++++
MineData Nuke4
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Nuke";
   shapeFile = "force";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 0.6;
	damageType = $ExplosionDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};

function Nuke4::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData DogVomit
{
   mass = 0.0; 
   drag = 0.0; 
   density =1.0;
	elasticity = 0.15;
	friction = 1.0; 
	className = "Handgrenade";
   description = "Dog Vomit";
   shapeFile = "bullet"; //"mortar";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 0.7;
	damageType = $MissileDamageType;
	kickBackStrength = 175;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};
function DogVomit::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

MineData DogVomitINF
{
   mass = 0.0; 
   drag = 0.0; 
   density =1.0;
	elasticity = 0.15;
	friction = 1.0; 
	className = "Handgrenade";
   description = "Dog Vomit";
   shapeFile = "bullet"; //"mortar";
   shadowDetailMask = 4;
   explosionId = infernoExp;
	explosionRadius = 20.0;
	damageValue = 0.375;
	damageType = $Inferno2DamageType;
	kickBackStrength = 175;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};
function DogVomitINF::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData DogVomit2
{
   mass = 0.0; 
   drag = 0.0; 
   density =1.0;
	elasticity = 0.15;
	friction = 1.0; 
	className = "Handgrenade";
   description = "Dog Vomit";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = mortarExp;
	explosionRadius = 20.0;
	damageValue = 0.2;
	damageType = $MissileDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function DogVomit2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}
MineData DogVomitINF2
{
   mass = 0.0; 
   drag = 0.0; 
   density =1.0;
	elasticity = 0.15;
	friction = 1.0; 
	className = "Handgrenade";
   description = "Dog Vomit";
   shapeFile = "bullet";
   shadowDetailMask = 4;
   explosionId = infernoExp;
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $Inferno2DamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};

function DogVomitINF2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}

//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Napalmgrenade
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Inferno Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = InfernoExp;
	explosionRadius = 15.0;
	damageValue = 0.15;
	damageType = $InfernoDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 1, 1, 0 };
};

function Napalmgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); 
	schedule("DeployNapalm(" @ %this @ " , 1);",2.0,%this);
}

function DeployNapalm(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Napalm1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-5.0,true);
		%obj = newObject("","Mine","Napalm1");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,5.0,true);
		%count -= 1;
		schedule("DeployNapalm(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
//+++++++++++++++++++++++++++
MineData Napalmgrenade2
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Inferno Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = InfernoExp;
	explosionRadius = 15.0;
	damageValue = 0.05;
	damageType = $InfernoDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 1, 1, 0 };
};

function Napalmgrenade2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this); 
	schedule("DeployNapalm2(" @ %this @ " , 1);",2.0,%this);
}

function DeployNapalm2(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Napalm1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-7.0,true);
		%obj = newObject("","Mine","Napalm1");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,7.0,true);
		%count -= 1;
		schedule("DeployNapalm2(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}
//++++++++++++++++
MineData Napalm1
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Inferno Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = InfernoExp;
	explosionRadius = 15.0;
	damageValue = 0.15;
	damageType = $InfernoDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 1, 1, 0 };
};

function Napalm1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.4,%this); 
}
//++++++++++++++++
MineData Napalm2
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.8;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Inferno Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = InfernoExp;
	explosionRadius = 15.0;
	damageValue = 0.05;
	damageType = $InfernoDamageType;
	kickBackStrength = 25;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 1, 1, 0 };
};

function Napalm2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.8,%this); 
}

//++++++++++++++++++++++++++
MineData SmokerGrenade
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Smoke Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = SmokeExp;
	explosionRadius = 15.0;
	damageValue = 0.01;
	damageType = $DebrisDamageType;
	kickBackStrength = 50;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};

function SmokerGrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
	schedule("DeploySmokeG(" @ %this @ " , 2);",1.8,%this);
}
function DeploySmokeG(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Smoke1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.0,true);
		%obj = newObject("","Mine","Smoke2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2.0,true);
		%obj = newObject("","Mine","Smoke1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2.65,true);
		%obj = newObject("","Mine","Smoke2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.65,true);
		%count -= 1;
		schedule("DeploySmokeG(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}

//++++++++++++++++++++++++++
MineData SmokerGrenade2
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Flash-Bang Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = BangExp;
	explosionRadius = 15.0;
	damageValue = 0.07;
	damageType = $DebrisDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};

function SmokerGrenade2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",2.0,%this);
	schedule("DeploySmokeG2(" @ %this @ " , 2);",1.8,%this);
}
function DeploySmokeG2(%this, %count)
{
	if(%count && %this)
	{
		%obj = newObject("","Mine","Bang1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.0,true);
		%obj = newObject("","Mine","Bang2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2.0,true);
		%obj = newObject("","Mine","Bang1");
 		addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,-2.65,true);
		%obj = newObject("","Mine","Bang2");
	 	addToSet("MissionCleanup", %obj);
		GameBase::throw(%obj,%this,2.65,true);
		%count -= 1;
		schedule("DeploySmokeG2(" @ %this @ " , " @ %count @ ");",0.2,%this);
	}
}

//++++++++++++++++
MineData Bang1
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Inferno Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = BangExp;
	explosionRadius = 15.0;
	damageValue = 0.07;
	damageType = $FlashDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 1, 1, 0 };
};

function Bang1::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.4,%this); 
}

//++++++++++++++++
MineData Bang2
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Inferno Grenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = BangExp;
	explosionRadius = 15.0;
	damageValue = 0.07;
	damageType = $FlashDamageType;
	kickBackStrength = 200;
	triggerRadius = 0.5;
	maxDamage = 2.0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 1, 1, 0 };
};

function Bang2::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.8,%this); 
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
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Blank
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Inferno Grenade";
   shapeFile = "breath";
   shadowDetailMask = 4;
//   explosionId = InfernoExp;
	explosionRadius = 0;
	damageValue = 0;
	damageType = $InfernoDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 0;

      lightType = 2;   // Pulsing
	lightRadius = 4;
	lightTime = 0.05;//++++
	lightColor = { 1, 1, 0 };
};
function Breath::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this); 
}
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
MineData Nuke1NotNeeded
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Nuke";
   shapeFile = "force";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 15.0;
	damageValue = 0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2.0;

};
//function Nuke1::onAdd(%this)
//{
//	%data = GameBase::getDataName(%this);
//	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
//}

//++++++++++++++++++++++++
MineData SmokeDeath
{
   mass = 0.2; 
   drag = 1.0; 
   density = 2.0;
	elasticity = 0.15;
	friction = 2.0; 
	className = "Handgrenade";
   description = "Nuke";
   shapeFile = "force";
   shadowDetailMask = 4;
   explosionId = SmokeExp2;
	explosionRadius = 5.0;
	damageValue = 0.0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0.0;
	triggerRadius = 0.5;
	maxDamage = 2.0;
};
function SmokeDeath::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",0.1,%this);
}