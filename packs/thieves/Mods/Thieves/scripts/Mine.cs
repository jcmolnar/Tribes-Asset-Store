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
ExplosionData DimensionalRifterMineExp
{
shapeName = "bluex.dts";
soundId = rocketExplosion;
faceCamera = true;
randomSpin = true;
hasLight = true;
lightRange = 8.0;
timeScale = 1.5;
timeZero = 0.250;
timeOne = 0.850;
colors[0] = { 0.4, 0.4, 1.0 };
colors[1] = { 1.0, 1.0, 1.0 };
colors[2] = { 1.0, 0.95, 1.0 };
radFactors = { 0.5, 1.0, 1.0 };
};
ExplosionData DimensionalRifterMineExpOld
{
shapeName = "shockwave_large.dts";
soundId = mineExp;
faceCamera = false;
randomSpin = true;
hasLight = true;
lightRange = 8.0;
timeZero = 0.450;
timeOne = 0.750;
colors[0] = { 1.0, 1.0, 1.0 };
colors[1] = { 1.0, 1.0, 1.0 };
colors[2] = { 1.0, 1.0, 1.0 };
radFactors = { 1.0, 1.0, 1.0 };
kickBackStrength = 0;
shiftPosition = True;
};
MineData AntipersonelRiftMine
{
className = "Mine";
description = "Dimensional Rifter Mine";
shapeFile = "mine";
shadowDetailMask = 4;
explosionId = DimensionalRifterMineExp;
explosionRadius = 10.0;
damageValue = 0.25;
damageType = $DimensionalRift;
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
if ((%type == "Player" || %data == AntipersonelMine || %data == Vehicle || %type == "Moveable") &&
GameBase::isActive(%this) &&
(GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
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
function AntipersonelRiftMine::onAdd(%this)
{
%this.damage = 0;
AntipersonelRiftMine::deployCheck(%this);
}
function AntipersonelRiftMine::onCollision(%this,%object)
{
%type = getObjectType(%object);
%data = GameBase::getDataName(%this);
if ((%type == "Player" || %data == AntipersonelRiftMine || %data == Vehicle || %type == "Moveable") &&
GameBase::isActive(%this) &&
(GameBase::getTeam(%this)!=GameBase::getTeam(%object))) 
GameBase::setDamageLevel(%this, %data.maxDamage);
}
function AntipersonelRiftMine::deployCheck(%this)
{
if (GameBase::isAtRest(%this)) {
GameBase::playSequence(%this,1,"deploy");
GameBase::setActive(%this,true);
GameBase::setRotation("\""@%obj,GameBase::getRotation(%player)@"\"");
%set = newObject("set",SimSet);
if(1 != containerBoxFillSet(%set,$MineObjectType,GameBase::getPosition(%this),1,1,1,0)) {
%data = GameBase::getDataName(%this);
GameBase::setDamageLevel(%this, %data.maxDamage);
}
deleteObject(%set);
}
else 
schedule("AntipersonelRiftMine::deployCheck(" @ %this @ ");", 3, %this);
} 
function AntipersonelRiftMine::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "mineammo"]--;
}
function AntipersonelRiftMine::onDamage(%this,%type,%value,%pos,%vec,%mom,%object)
{
if (%type == $MineDamageType)
%value = %value * 0.25;
%data = GameBase::getDataName(%this);
if((%data.maxDamage/1.5) < %this.damage+%value) 
GameBase::setDamageLevel(%this, %data.maxDamage);
else 
%this.damage += %value;
}
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
