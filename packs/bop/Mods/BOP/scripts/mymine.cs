$InvList[AirMineAmmo] = 1;
$InvList[flagmineammo] = 1;

$RemoteInvList[AirMineAmmo] = 1;
$RemoteInvList[flagmineammo] = 1;

$SellAmmo[AirMineAmmo] = 5;
$SellAmmo[flagmineammo] = 5;

$TeamItemMax[airmineammo] = 20;
$TeamItemMax[flagmineammo] = 10;

// -----------------------------------------------------------------------------

ItemData AirMineAmmo
{
   description = "Air Mine";
   shapeFile = "mineammo";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 15;
   className = "HandAmmo";
};

ItemData flagmineammo
{
   description = "Flag Mine";
   shapeFile = "sensor_small";
   heading = "eMiscellany";
   shadowDetailMask = 4;
   price = 20;
   className = "HandAmmo";
};

// ---------------------------------------------------------------------------------

MineData AirMine
{
	className = "Mine";
   description = "Air Mine";
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
	mass = 0.0;
};

function AirMine::onAdd(%this)
{
	%this.damage = 0;
	AirMine::deployCheck(%this);
}

function AirMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	if ((%type == "Player" || %data == AntipersonelMine || %data == AirMine || %data == FlagMine || %data == Vehicle || %type == "Moveable") &&
			GameBase::isActive(%this)) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
}

function AirMine::deployCheck(%this)
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
	

function AirMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "airmineammo"]--;
}

function AirMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
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

MineData FlagMine
{
	className = "Mine";
   description = "Flag Mine";
   shapeFile = "flag";
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

MineData realFlagMine
{
	className = "Mine";
   description = "Flag Mine";
   shapeFile = "flag";
   shadowDetailMask = 4;
   explosionId = mineExp;
	explosionRadius = 10.0;
	damageValue = 0.65;
	damageType = $MineDamageType;
	kickBackStrength = 150;
	triggerRadius = 0.5;
	maxDamage = 0.5;
	shadowDetailMask = 0;
	destroyDamage = 1.0;
	damageLevel = {1.0, 1.0};
	mass=0.0;
};

function FlagMine::onAdd(%this)
{
	%this.damage = 0;
	FlagMine::deployCheck(%this);
}

function FlagMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	%mineteam = GameBase::getTeam(%this);
	%objectteam = GameBase::getTeam(%object); 
	echo("mineteam = " @ %mineteam);
	echo("objteam = " @ %objectteam);
	if ((%type == "Player" || %data == AntipersonelMine || %data == AirMine || %data == FlagMine || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this) && %mineteam != %objectteam) 
			GameBase::setDamageLevel(%this, %data.maxDamage);
}

function realFlagMine::onCollision(%this,%object)
{
	%type = getObjectType(%object);
	%data = GameBase::getDataName(%this);
	%mineteam = GameBase::getTeam(%this);
	%objectteam = GameBase::getTeam(%object); 
	echo("mineteam = " @ %mineteam);
	echo("objteam = " @ %objectteam);
	if ((%type == "Player" || %data == AntipersonelMine || %data == AirMine || %data == FlagMine || realFlagMine || %data == Vehicle || %type == "Moveable")
		 && GameBase::isActive(%this) && %mineteam != %objectteam) 
			GameBase::setDamageLevel(%this, %data.maxDamage);
}

function FlagMine::deployCheck(%this)
{	
	if (GameBase::isAtRest(%this)) 
	{
	 	//GameBase::setActive(%this,true);
		//%set = newObject("set",SimSet);
		//if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) 
		//{
		//	%data = GameBase::getDataName(%this);
		//	GameBase::setDamageLevel(%this, %data.maxDamage);
		//}
		//deleteObject(%set);
		
		%pos = Gamebase::getPosition(%this);
		%xpos = getWord(%pos,0);
		%ypos = getWord(%pos,1);
		%zpos = getWord(%pos,2) + 1;
		%team = Gamebase::getTeam(%this);
		deleteObject(%this);
		%obj = newObject("","Mine","realflagMine");
		addToSet("MissionCleanup", %obj);
		GameBase::setTeam(%obj,%team);
		GameBase::setPosition(%obj, %xpos @ " " @ %ypos @ " " @ %zpos);
		GameBase::setActive(%obj,true);
		%set = newObject("set",SimSet);
		if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%obj),1,1,1,0)) 
		{
			%data = GameBase::getDataName(%obj);
			GameBase::setDamageLevel(%obj, %data.maxDamage);
		}
		deleteObject(%set);

	}
	else 
		schedule("FlagMine::deployCheck(" @ %this @ ");", 3, %this);
}	

function FlagMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "flagmineammo"]--;
}

function realFlagMine::onDestroyed(%this)
{
	$TeamItemCount[GameBase::getTeam(%this) @ "flagmineammo"]--;
}


function FlagMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}

function realFlagMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
   if (%type == $MineDamageType)
      %value = %value * 0.25;

	%data = GameBase::getDataName(%this);
	if((%data.maxDamage/1.5) < %this.damage+%value) 
		GameBase::setDamageLevel(%this, %data.maxDamage);
	else 
		%this.damage += %value;
}