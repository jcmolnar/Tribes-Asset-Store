//***************************
// TRIBAL COMBAT STATIC SHAPE
//***************************
StaticShapeData ssFSGenerator
{
shapeFile = "sensor_small";
debrisId = defaultDebrisSmall;
maxDamage = 8.0;
visibleToSensor = true;
description = "Force Screen Generator";
newPosition = "0 0 0";
newRot = "0 0 0";
};

function ssFSGenerator::onAdd(%this)
{
 %this.screen = -1;
 schedule("ssFSGeneator::generateScreen("@%this@");",0.01,%this);
}

function ssFSGenerator::onDestroyed(%this)
{
 $TeamItemCount[GameBase::getTeam(%this) @ "ForceScreen"]--;
 if(%this.screen != -1) GameBase::applyDamage(%this.screen,$ImpactDamageType,20,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
 StaticShape::onDestroyed(%this);
}

function ssFSGeneator::generateScreen(%this)
{
 %rot = GameBase::getRotation(%this);
 %pos = GameBase::getPosition(%this);
 %this.screen = newObject("ForceScreen",StaticShape,ssForceScreen,true);
 %this.screen.generator = %this;
 addToSet("MissionCleanup", %this.screen);
 GameBase::setTeam(%this.screen,GameBase::getTeam(%this));
 GameBase::setPosition(%this.screen,%pos);
 GameBase::setRotation(%this.screen,%rot);
 Gamebase::setMapName(%this.screen,"Force Screen");
 GameBase::startFadeIn(%this.screen);
}

//***************************
StaticShapeData ssForceScreen
{
shapeFile = "forcefield_5x5";
debrisId = defaultDebrisSmall;
maxDamage = 8.0;
visibleToSensor = true;
isTranslucent = true;
description = "Force Screen";
newPosition = "0 0 0";
newRot = "0 0 0";
};

function ssForceScreen::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
	if(%type == $DrainDamageType) %value *= 250;
	else if(%type == $BulletDamageType) %value /= 2.0;
	else if(%type == $PlasmaDamageType) %value *= 1.2;

	StaticShape::onDamage(%this,%type,%value,%pos,%vec,%mom,%object);
}

function ssForceScreen::onDestroyed(%this)
{
//$TeamItemCount[GameBase::getTeam(%this) @ "ForceScreen"]--;
 GameBase::applyDamage(%this.generator,$ImpactDamageType,20,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
 StaticShape::onDestroyed(%this);
}

function ssForceScreen::onCollision(%this,%object)
{
 if(getObjectType(%object) == "Flier")
 {
  if(GameBase::getDataName(%this) == Drone || GameBase::getDataName(%this) == GuidedBomb ||
     GameBase::getDataName(%this) == GuidedMissile || GameBase::getDataName(%this) == SurveyDrone ||
	 GameBase::getDataName(%this) == AttackDrone)
  GameBase::applyDamage(%object,$ImpactDamageType,10,GameBase::getPosition(%object),"0 0 0","0 0 0",%this);
 }
 if(getObjectType(%object) == "Player" && GameBase::getTeam(%object) == GameBase::getTeam(%this)) ssForceScreen::Create(%this);
}

function ssForceScreen::Create(%this)
{
   %rot = GameBase::getRotation(%this);
   %position = GameBase::getPosition(%this);
   %screen = newObject("ForceScreen","StaticShape",ssForceScreen,true);
   addToSet("MissionCleanup", %screen);
   Gamebase::setMapName(%this,"ForceScreen");
   GameBase::setTeam(%screen,GameBase::getTeam(%this));
   playSound(ForceFieldOpen,%position);
   GameBase::startFadeOut(%this);
   %screen.newPosition = %position;
   %screen.newRot = %rot;
   %screen.generator = %this.generator;
   %this.generator.screen = %screen;
   GameBase::virtual(%screen,ssForceScreen::Check,%screen);
   deleteObject(%this);
}

function ssForceScreen::Check(%this)
{
	schedule("ssForceScreen::Replace("@%this@");",3,%this);
}

function ssForceScreen::Replace(%this)
{
   GameBase::setPosition(%this,%this.newPosition);
   GameBase::setRotation(%this,%this.newRot);
   GameBase::startFadeIn(%this);
   playSound(ForceFieldClose,%this.newPosition);
}

//*************************************
StaticShapeData ssBarricade
{
shapeFile = "newdoor4_l";
debrisId = defaultDebrisSmall;
maxDamage = 8.0;
visibleToSensor = true;
damageSkinData = "objectDamageSkins";
description = "Barricade";
};

function ssBarricade::onDestroyed(%this)
{
 $TeamItemCount[GameBase::getTeam(%this) @ "Barricade"]--;
 %set = newObject("set",SimSet);
 %pos = getBoxCenter(%this);
 %num = containerBoxFillSet(%set,$StaticObjectType | $ItemObjectType,%pos,5,5,5,5);
 while(%num > 0)
 {
  %num--;
  %obj = getObjectType(Group::getObject(%set,%num));
  if(%obj == Turret || %obj == Sensor)
  {
   GameBase::applyDamage(Group::getObject(%set,%num),$ShrapnelDamageType,10,GameBase::getPosition(Group::getObject(%set,%num)),"0 0 0","0 0 0",%this);
  }
//echo(%obj@" "@%num);
 }
 deleteObject(%set);
 StaticShape::objectiveDestroyed(%this);
}

//*************************************
StaticShapeData ssFloatingPad
{
shapeFile = "elevator_6x6_octagon"; //"elevator6x6thin";
explosionId = LargeShockwave;
debrisId = defaultDebrisLarge;
maxDamage = 20.0;
visibleToSensor = true;
damageSkinData = "objectDamageSkins";
description = "FloatingPad";
};

function ssFloatingPad::onDestroyed(%this)
{
StaticShape::onDestroyed(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "FloatingPad"]--;
calcRadiusDamage(%this, $DebrisDamageType, 2.5, 0.05, 25, 13, 2, 0.55, 15, 225, 100); 
}

//*******************************
StaticShapeData ssTeleportPad
{
shapeFile = "flagstand";
debrisId = defaultDebrisSmall;
maxDamage = 2.0;
visibleToSensor = true;
damageSkinData = "objectDamageSkins";
description = "Teleport Pad";
};

function ssTeleportPad::onDestroyed(%this)
{
    $TeamItemCount[GameBase::getTeam(%this) @ "TeleportPad"]--;
    StaticShape::onDestroyed(%this);
    TeamMessages(1,GameBase::getTeam(%this),"The Teleport Pad has been destroyed - Teleport Packs are now useless.");
}

//*******************************
StaticShapeData ssTeleportField
{
shapeFile = "forcefield_3x4";
debrisId = defaultDebrisSmall;
maxDamage = 2.0;
visibleToSensor = true;
isTranslucent = true;
description = "Teleport Field";
};

function ssTeleportField::onDestroyed(%this)
{
    $TeamItemCount[GameBase::getTeam(%this) @ "TeleportField"]--;
    StaticShape::onDestroyed(%this);

	%group = nameToID("MissionCleanup/Teleport");
	if(Group::objectCount(%group) != 0)
	{
	for(%i = 0;(%teleport = Group::getObject(%group,%i)) != -1;%i++)
	 {
	 if(%teleport != %this && 
	    GameBase::getTeam(%teleport) == GameBase::getTeam(%this) &&
		GameBase::getDamageState(%teleport) != "Destroyed")
	  {  
      GameBase::applyDamage(%teleport,$DebrisDamageType,2,GameBase::getPosition(%teleport),"0 0 0","0 0 0",%this); 
	  TeamMessages(1,GameBase::getTeam(%this),"The Teleportation Fields have been destroyed.");
	  break;
	  }
	 }
	}
}

function ssTeleportField::onCollision(%this,%object)
{
	%client = Player::getClient(%object);
	%position = false;
	%group = nameToID("MissionCleanup/Teleport");
	if(Group::objectCount(%group) != 0)
	{
	for(%i = 0;(%teleport = Group::getObject(%group,%i)) != -1;%i++)
	 {
	 if(%teleport != %this && GameBase::getTeam(%teleport) == GameBase::getTeam(%this))
	  {
	   %position = $teleportPos[%teleport];
	   break;
	  }
	 }
	}

	if(!%this.enable)
	 {
		centerprint(%client,"<jc>Teleport Field disabled - Please move away from the field.");
		return;
	 }

	if(!%position)
	 {
	  centerprint(%client,"<jc>Teleporter inactive - No destination point");
	  return;
	 }

	if(getObjectType(%object) == "Player")
	{
	 if(!Player::isDead(%client))
	 {
	  %type = Player::getMountedItem(%client,$FlagSlot);
	  if(%type != -1)
	   {
		centerprint(%client,"<jc>Flags can not undergo teleportation.");
	    Player::dropItem(%client,%type);
	   }

	    %rot = adjustRot(GameBase::getRotation(%teleport),3);
		%this.enable = false;
		%teleport.enable = false;
		schedule("ssTeleportField::TeleportEnable("@%this@");",7,%this);
		schedule("ssTeleportField::TeleportEnable("@%teleport@");",7,%teleport);
		GameBase::setPosition(%object,%position);
		GameBase::setRotation(%object,%rot);
        playSound(ForceFieldOpen,%position);
	 }
	}
}

function ssTeleportField::TeleportEnable(%this)
{
	%this.enable = true;
}