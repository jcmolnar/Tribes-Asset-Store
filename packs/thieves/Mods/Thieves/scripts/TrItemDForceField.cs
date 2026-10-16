StaticShapeData DeployableForceField
{
className = "DeployableForceField";
damageSkinData = "objectDamageSkins";
shapeFile = "forcefield_5x5";
maxDamage = 2.75;
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
function DeployableForceField::Destruct(%this)
{
DeployableForceField::doDamage(%this);
}
function DeployableForceField::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 0.5, 25, 15, 4, 0.4, 0.1, 250, 100); 
}
function DeployableForceField::onDestroyed(%this)
{
DeployableForceField::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "DeployableForceField"]--;
}
function DeployableForceField::onCollision(%this,%obj)
{
%c = Player::getClient(%obj);
if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
if(%fieldTeam != %playerTeam && Player::getArmor(%c)!="infarmor" && Player::getArmor(%c)!="inffarmor")
{
return;
}
DeployableForceField::openSesame(%this);
return;
}
function DeployableForceField::openSesame(%this) {
if(%this.activated==False) {
GameBase::startfadeout(%this);
%this.activated=true;
schedule("DeployableForceField::openSesame("@%this@");",6);
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
ItemImageData ForceFieldPackImage
{
shapeFile = "shieldPack";
mountPoint = 2;
firstPerson = false;
};
ItemData ForceFieldPack
{
description = "Small Force Field";
shapeFile = "shieldpack";
className = "Backpack";
heading = "lDeployables";
imageType = ForceFieldPackImage;
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 1200;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function ForceFieldPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function ForceFieldPack::onDeploy(%player,%item,%pos)
{
if (ForceFieldPack::deployShape(%player,"Force Field",DeployableForceField,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployableForceField"]++;
}
}
function CreateForceFieldSimSet()
{
%teleset = nameToID("MissionCleanup/ForceFields");
if(%teleset == -1)
{
newObject("ForceFields",SimSet);
addToSet("MissionCleanup","ForceFields");
}
}
function ForceFieldPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableForceField"] < $TeamItemMax[DeployableForceField]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
echo("::"@GameBase::getDataName($los::object)@"::");
if (CheckDeployTerrain($los::object)
||GameBase::getDataName($los::object)=="DeployableLargeForceField" 
||GameBase::getDataName($los::object)=="DeployableBlastDoor" 
||GameBase::getDataName($los::object)=="DeployableForceField") {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
if(checkForceFieldDeployArea(%client,$los::position)) {
%sensor = newObject("Small Force Field","StaticShape",%shape,true);
CreateForceFieldSimSet();
addToSet("MissionCleanup/ForceFields", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 0");
GameBase::setRotation(%sensor,GameBase::getRotation(%player));
GameBase::setPosition(%sensor,%pos);
Gamebase::setMapName(%sensor,%name);
Client::sendMessage(%client,0,%item.description @ " deployed");
%sensor.disabled = false;
%sensor.activated=false;
GameBase::setAutoRepairRate(%sensor,$ForceFieldPack::RechargeRate);
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
