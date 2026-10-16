StaticShapeData DeployableLargeForceField
{
className = "DeployableLargeForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "ForceField_4x8";
maxDamage = 4.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
side = "single";
isTranslucent = true;
};
function DeployableLargeForceField::Destruct(%this)
{
DeployableLargeForceField::doDamage(%this);
}
function DeployableLargeForceField::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); 
}
function DeployableLargeForceField::onDestroyed(%this)
{
DeployableLargeForceField::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "DeployableLargeForceField"]--;
}
function DeployableLargeForceField::onCollision(%this,%obj)
{
if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam && Player::getArmor(%c)!="infarmor" && Player::getArmor(%c)!="inffarmor")
{
return;
}
DeployableLargeForceField::openSesame(%this);
return;
}
function DeployableLargeForceField::openSesame(%this) {
if(%this.activated==False) {
GameBase::startfadeout(%this);
%this.activated=true;
schedule("DeployableLargeForceField::openSesame("@%this@");",6);
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 -5000");
schedule("GameBase::setPosition("@%this@",\""@%pos@"\");",2.75);
schedule("GameBase::playSound("@%this@",ForceFieldOpen,0);",0.35);
} else {
%this.activated=false;
%pos=GameBase::getPosition(%this);
%pos=Vector::add(%pos,"0 0 5000");
GameBase::setPosition(%this,%pos);
GameBase::startfadein(%this);
schedule("GameBase::playSound("@%this@",ForceFieldClose,0);",0.35);
}
}
ItemImageData LargeForceFieldPackImage
{
shapeFile = "shieldPack";
mountPoint = 2;
firstPerson = false;
};
ItemData LargeForceFieldPack
{
description = "Large Force Field";
shapeFile = "shieldpack";
className = "Backpack";
heading = "lDeployables";
imageType = LargeForceFieldPackImage;
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 2000;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function LargeForceFieldPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function LargeForceFieldPack::onDeploy(%player,%item,%pos)
{
if (LargeForceFieldPack::deployShape(%player,"Force Field",DeployableLargeForceField,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployableLargeForceField"]++;
}
}
function CreateLargeForceFieldSimSet()
{
%teleset = nameToID("MissionCleanup/LargeForceFields");
if(%teleset == -1)
{
newObject("LargeForceFields",SimSet);
addToSet("MissionCleanup","LargeForceFields");
}
}
function LargeForceFieldPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableLargeForceField"] < $TeamItemMax[DeployableLargeForceField]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)
||GameBase::getDataName($los::object)=="DeployableBlastDoor" 
||GameBase::getDataName($los::object)=="DeployableLargeForceField" 
||GameBase::getDataName($los::object)=="DeployableForceField") {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
if(checkForceFieldDeployArea(%client,$los::position)) {
%sensor = newObject("Large Force Field","StaticShape",%shape,true);
CreateLargeForceFieldSimSet();
addToSet("MissionCleanup/LargeForceFields", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 0");
GameBase::setRotation(%sensor,GameBase::getRotation(%player));
GameBase::setPosition(%sensor,%pos);
Gamebase::setMapName(%sensor,%name);
Client::sendMessage(%client,0,%item.description @ " deployed");
%sensor.disabled = false;
%sensor.activated=false;
GameBase::setAutoRepairRate(%sensor,$LargeForceFieldPack::RechargeRate);
echo("Force Field Deployed ("@%sensor@")");
playSound(SoundPickupBackpack,$los::position);
GameBase::startfadein(%sensor);
return true;
}
}
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
}
else 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
}
else 
Client::sendMessage(%client,0,"Deploy position out of range");
}
else
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
return false;
}
