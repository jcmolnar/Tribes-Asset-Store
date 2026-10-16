StaticShapeData DeployableTNTPak
{
className = "DeployableTNTPak";
damageSkinData = "objectDamageSkins";
shapeFile = "magcargo";
maxDamage = 10.0;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = LargeShockwave;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
};
function DeployableTNTPak::Destruct(%this)
{
DeployableTNTPak::doDamage(%this);
}
function DeployableTNTPak::doDamage(%this) {
CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,50,20,3,5,5,200,100);
}
function DeployableTNTPak::onDestroyed(%this)
{
$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTNTPak"]--;
}
function DeployableTNTPak::onCollision(%this,%obj)
{
return;
}
ItemImageData TNTPakImage
{
shapeFile = "magcargo";
mountPoint = 2;
mountOffset = { 0, -0.5, -0.5 };
mountRotation = { 0, 0, 0 };
firstPerson = false;
};
ItemData TNTPak
{
description = "TNT Pack";
shapeFile = "magcargo";
className = "Backpack";
heading = "lDeployables";
imageType = TNTPakImage;
shadowDetailMask = 4;
mass = 1.4;
elasticity = 0.2;
price = 1500;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function TNTPak::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function TNTPak::onDeploy(%player,%item,%pos)
{
if (TNTPak::deployShape(%player,"Nuke Pak",DeployableTNTPak,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTNTPak"]++;
}
}
function TNTPak::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTNTPak"] < $TeamItemMax[DeployableTNTPak]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
if(checkDeployArea(%client,$los::position)) {
%sensor = newObject("TNT Pack","StaticShape",%shape,true);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 0");
echo("LOS pos " @ $los::position @ " "@ %pos);
GameBase::setPosition(%sensor,%pos);
Gamebase::setMapName(%sensor,%name);
Client::sendMessage(%client,2,%item.description @ " deployed.  Explosion in 10 seconds");
%sensor.disabled = false;
playSound(SoundPickupBackpack,$los::position);
schedule("DeployableTNTPak::Destruct("@%sensor@");",10);
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
