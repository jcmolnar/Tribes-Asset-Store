StaticShapeData DeployablePlatform
{
className = "DeployablePlatform";
damageSkinData = "objectDamageSkins";
shapeFile = "elevator_5x5";
maxDamage = 3.33333;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = debrisExpLarge;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = false;
};
function DeployablePlatform::Destruct(%this)
{
DeployablePlatform::doDamage(%this);
}
function DeployablePlatform::doDamage(%this) {
}
function DeployablePlatform::onDestroyed(%this)
{
DeployablePlatform::doDamage(%this);
%set=newobject("set",SimSet); 
%num=containerBoxFillSet(%set,$StaticObjectType|$ItemObjectType,GameBase::getPosition(%this),5,5,1,0);
echo("PLATFORMDEST:  "@%num@" objects attached!");
if(%num) {
%tobj=0;
for(%x=0;%x<%num;%x++) {
%obj=Group::getObject(%set,%x);
if(GameBase::getDataName(%obj)!="DeployableBaseOps"&&GameBase::getDataName(%obj)!="DeployablePlatform") {
GameBase::setDamageLevel(%obj,10000); 
echo("Destroy: "@%obj@" "@GameBase::getDataName(%obj));
}
}
}
$TeamItemCount[GameBase::getTeam(%this) @ "DeployablePlatform"]--;
}
function DeployablePlatform::onCollision(%this,%obj)
{
return;
}
ItemImageData PlatformPackImage
{
shapeFile = "shieldpack";
mountPoint = 2;
firstPerson = false;
};
ItemData PlatformPack
{
description = "Deployable Platform";
shapeFile = "elevator_4x4";
className = "Backpack";
heading = "lDeployables";
imageType = PlatformPackImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 350;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function PlatformPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function PlatformPack::onDeploy(%player,%item,%pos)
{
if (PlatformPack::deployShape(%player,"Platform",DeployablePlatform,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployablePlatform"]++;
}
}
function CreatePlatformSimSet()
{
%teleset = nameToID("MissionCleanup/Platforms");
if(%teleset == -1)
{
newObject("Platforms",SimSet);
addToSet("MissionCleanup","Platforms");
}
}
function PlatformPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployablePlatform"] < $TeamItemMax[DeployablePlatform]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
echo("::"@GameBase::getDataName($los::object)@"::");
if (CheckDeployTerrain($los::object)) {
%sensor = newObject("Deployable Platform","StaticShape",%shape,true);
if(GameBase::getDataName($los::object)=="DeployablePlatform") { 
%ZLevel=getWord(GameBase::getPosition($los::object),2);
}
CreatePlatformSimSet();
addToSet("MissionCleanup/Platforms", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 0");
GameBase::setPosition(%sensor,%pos);
%Rot=GameBase::getRotation(%player);
%Rot=Vector::add(%Rot,"0 0 3.14159");
GameBase::setRotation(%sensor,%rot);
%Vec=Vector::getFromRot(%Rot,2,0);
%pos=Vector::add(%vec,%pos);
if(%ZLevel!=0) { 
%newX=getWord(%Pos,0);
%newY=getWord(%Pos,1);
%newZ=%ZLevel;
%pos=%newX@" "@%newY@" "@%newZ;
}
GameBase::setPosition(%sensor,%pos);
Gamebase::setMapName(%sensor,%name);
Client::sendMessage(%client,0,%item.description @ " deployed");
%sensor.disabled = false;
%sensor.activated=false;
GameBase::startFadeIn(%sensor);
playSound(SoundPickupBackpack,$los::position);
GameBase::startfadein(%sensor);
return true;
}
else 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
}
else {
if (GameBase::getLOSInfo(%player,10)!=True) { 
echo("DEPLOY PLATFORM CALLED");
%sensor = newObject("Deployable Platform","StaticShape",%shape,true);
CreatePlatformSimSet();
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%Rot=GameBase::getRotation(%player);
%pos = Vector::add(GameBase::getPosition(%player),"0 0 6");
GameBase::setRotation(%sensor,%rot);
GameBase::setPosition(%sensor,%pos);
if(GameBase::getLOSInfo(%sensor,15,"0 3.14159 0")!="True") {
Gamebase::setMapName(%sensor,%name);
Client::sendMessage(%client,0,%item.description @ " deployed");
%sensor.disabled = false;
%sensor.activated=false;
GameBase::startFadeIn(%sensor);
playSound(SoundPickupBackpack,%pos);
GameBase::startfadein(%sensor);
addToSet("MissionCleanup/Platforms", %sensor);
addToSet("MissionCleanup", %sensor);
} else { 
Client::sendMessage(%client,0,"Unable to deploy aerial platform.  Object in the way");
addToSet("MissionCleanup/Platforms", %sensor);
addToSet("MissionCleanup", %sensor);
deleteobject(%sensor); 
return false;
}
return true;
} else
Client::sendMessage(%client,0,"Deploy position out of range");
}
}
else
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
return false;
}
