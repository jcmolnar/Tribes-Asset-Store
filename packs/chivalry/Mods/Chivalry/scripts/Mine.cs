//----------------------------------------------------------------------------
// MINE DYNAMIC DATA

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
	%this.damage = 0;
	AntipersonelMine::deployCheck(%this);
}

function AntipersonelMine::onCollision(%this,%object) 
{ 	
	%type = getObjectType(%object);
 	%data = GameBase::getDataName(%this);
	if($Chivalry::FriendMines == "true")
	{
if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object)) 
GameBase::setDamageLevel(%this, %data.maxDamage);
	}
else if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this))  	
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
		deleteObject(%set);
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

//=====================================================
MineData ShkwvMine
{
	className = "Mine";
   description = "Shockwave Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = LargeShockwave;
	explosionRadius = 10.0;
	damageValue = 0.01;
	damageType = $ImpactDamageType;
	kickBackStrength = 350;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function ShkwvMine::onAdd(%this)
{
	%this.damage = 0;
	ShkwvMine::deployCheck(%this);
}

function ShkwvMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if($Chivalry::FriendMines == "true")
	{
if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object)) 
GameBase::setDamageLevel(%this, %data.maxDamage);
	}
else if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this))  	
GameBase::setDamageLevel(%this, %data.maxDamage);

}

function ShkwvMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("ShkwvMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function ShkwvMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "ShockwaveMine"]--;
}

function ShkwvMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//=====================================================
MineData engMine
{
	className = "Mine";
   description = "EMP Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 10.0;
	damageValue = 0.01;
	damageType = $EmpDamageType;
	kickBackStrength = 50;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function engMine::onAdd(%this)
{
	%this.damage = 0;
	engMine::deployCheck(%this);
}

function engMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if($Chivalry::FriendMines == "true")
	{
if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object)) 
GameBase::setDamageLevel(%this, %data.maxDamage);
	}
else if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this))  	
GameBase::setDamageLevel(%this, %data.maxDamage);

}

function engMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("engMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function engMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "EmpMine"]--;
}

function engMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//----------------------------------------------------------------------------
MineData stsMine
{
	className = "Mine";
   description = "Stasis Mine";
   shapeFile = "mine";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 5.0;
	damageValue = 0.01;
	damageType = $StasisDamageType;
	kickBackStrength =10;
	triggerRadius = 2.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
};

function stsMine::onAdd(%this)
{
	%this.damage = 0;
	stsMine::deployCheck(%this);
}

function stsMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if($Chivalry::FriendMines == "true")
	{
if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object)) 
GameBase::setDamageLevel(%this, %data.maxDamage);
	}
else if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this))  	
GameBase::setDamageLevel(%this, %data.maxDamage);

}

function stsMine::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("stsMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function stsMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "StasisMine"]--;
}

function stsMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}
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
}
//----------------------------------------------------------------------------

MineData HeMIRVgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.7;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 10.0;
	damageValue = 0.2;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function HeMIRVgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",4.0,%this);
}
//----------------------------------------------------------------------------

MineData EmpMIRVgrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.7;
	friction = 1.0;
	className = "Handgrenade";
   description = "Handgrenade";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = turretExp;
	explosionRadius = 10.0;
	damageValue = 0.001;
	damageType = $EmpDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function EmpMIRVgrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
	schedule("Mine::Detonate(" @ %this @ ");",4.0,%this);
}

//----------------------------------------------------------------------------

MineData Smokegrenade
{
   mass = 0.3;
   drag = 1.0;
   density = 2.0;
	elasticity = 0.15;
	friction = 1.0;
	className = "Handgrenade";
   description = "Smokegrenade";
   shapeFile = "armorPatch";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 0.0;
	damageValue = 0;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 0;
	triggerRadius = 0.5;
	maxDamage = 2;
};

function Smokegrenade::onAdd(%this)
{
	%data = GameBase::getDataName(%this);
}




//-------------------------------------------------------------------


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


//-------------------------------------------------
MineData Volc1
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

function Volc1::onAdd(%this)
{
	%this.damage = 0;
	Volc1::deployCheck(%this);
}

function Volc1::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if($Chivalry::FriendMines == "true")
	{
if((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") && GameBase::isActive(%this) && GameBase::getTeam(%this) != GameBase::getTeam(%object)) 
GameBase::setDamageLevel(%this, %data.maxDamage);
	}
else if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this))  	
GameBase::setDamageLevel(%this, %data.maxDamage);

}

function Volc1::deployCheck(%this)
{
	if (GameBase::isAtRest(%this)) {
		GameBase::playSequence(%this,1,"deploy");
	 	GameBase::setActive(%this,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
			%data = GameBase::getDataName(%this);
			GameBase::setDamageLevel(%this, %data.maxDamage);
		}
		deleteObject(%set);
	}
	else 
		schedule("Volc1::deployCheck(" @ %this @ ");", 3, %this);
}	

function Volc1::onDestroyed(%this)
{
	//$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
	$NumVolcMines--;
}

function Volc1::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

//----------------------------------------------------------------------------

MineData BrimstoneGren
{
   mass = 1.0;
   drag = 1.0;
   density = 1.0;
	elasticity = 0;
	friction = 1.0;
	className = "Handgrenade";
   description = "Brimstone";
   shapeFile = "grenade";
   shadowDetailMask = 4;
   explosionId = grenadeExp;
	explosionRadius = 30.0;
	damageValue = 0.8;
	damageType = $ShrapnelDamageType;
	kickBackStrength = 100;
	triggerRadius = 0.5;
	maxDamage = 0.2;
};

function BrimstoneGren::onAdd(%this)
{
BrimstoneGren::CheckRest(%this);
}

function BrimstoneGren::CheckRest(%this)
{
	if(GameBase::isAtRest(%this))
	{
	%data = GameBase::getDataName(%this);
	GameBase::setDamageLevel(%this, %data.maxDamage);
	}
	else
	schedule("BrimstoneGren::CheckRest("@%this@");",0.5,%this);
}
	
