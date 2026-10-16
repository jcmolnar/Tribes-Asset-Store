StaticShapeData DeployableBlastDoor
{
className = "DeployableBlastDoor";
damageSkinData = "objectDamageSkins";
shapeFile = "newdoor5";
maxDamage = 10;
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
function DeployableBlastDoor::Destruct(%this)
{
DeployableBlastDoor::doDamage(%this);
}
function DeployableBlastDoor::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 1, 25, 15, 4, 0.4, 0.1, 250, 100); 
}
function DeployableBlastDoor::onDestroyed(%this)
{
DeployableBlastDoor::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "DeployableBlastDoor"]--;
}
function DeployableBlastDoor::onCollision(%this,%obj)
{
%c = Player::getClient(%obj);
if(%this.activated==True || getObjectType(%obj)!="Player" || Player::isDead(%obj)) {
return;
}
%playerTeam = GameBase::getTeam(%obj);
%fieldTeam = GameBase::getTeam(%this);
DeployableBlastDoor::openSesame(%this);
return;
}
function DeployableBlastDoor::openSesame(%this) {
if(%this.activated==False) {
GameBase::startfadeout(%this);
%this.activated=true;
schedule("DeployableBlastDoor::openSesame("@%this@");",6);
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
ItemImageData BlastDoorPackImage
{
shapeFile = "shieldPack";
mountPoint = 2;
firstPerson = false;
};
ItemData BlastDoorPack
{
description = "Blast Door";
shapeFile = "shieldpack";
className = "Backpack";
heading = "lDeployables";
imageType = BlastDoorPackImage;
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 1200;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function BlastDoorPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function BlastDoorPack::onDeploy(%player,%item,%pos)
{
if (BlastDoorPack::deployShape(%player,"Blast Door",DeployableBlastDoor,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployableBlastDoor"]++;
}
}
function CreateBlastDoorSimSet()
{
%teleset = nameToID("MissionCleanup/BlastDoors");
if(%teleset == -1)
{
newObject("BlastDoors",SimSet);
addToSet("MissionCleanup","BlastDoors");
}
}
function BlastDoorPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableBlastDoor"] < $TeamItemMax[DeployableBlastDoor]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
echo("::"@GameBase::getDataName($los::object)@"::");
if (CheckDeployTerrain($los::object)
||GameBase::getDataName($los::object)=="DeployableLargeForceField" 
||GameBase::getDataName($los::object)=="DeployableForceField"
||GameBase::getDataName($los::object)=="DeployableBlastDoor") {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
if(checkForceFieldDeployArea(%client,$los::position)) {
%sensor = newObject("Blast Door","StaticShape",%shape,true);
CreateBlastDoorSimSet();
addToSet("MissionCleanup/BlastDoors", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 0");
GameBase::setRotation(%sensor,GameBase::getRotation(%player));
GameBase::setPosition(%sensor,%pos);
Gamebase::setMapName(%sensor,%name);
Client::sendMessage(%client,0,%item.description @ " deployed");
%sensor.disabled = false;
%sensor.activated=false;
GameBase::setAutoRepairRate(%sensor,$BlastDoorPack::RechargeRate);
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
