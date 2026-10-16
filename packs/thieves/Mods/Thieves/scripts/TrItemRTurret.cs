SeekingMissileData DeployableTurretMissile
{
bulletShapeName = "rocket.dts";
explosionTag = rocketExp;
collisionRadius = 0.0;
mass = 2.0;
damageClass = 1; 
damageValue = 0.2; 
damageType = $MissileDamageType;
explosionRadius = 6.5;
kickBackStrength = 125.0;
muzzleVelocity = 25; 
totalTime = 25; 
liveTime = 25; 
seekingTurningRadius = 9;
nonSeekingTurningRadius = 75.0;
proximityDist = 1.5;
smokeDist = 1.5;
lightRange = 5.0;
lightColor = { 0.4, 0.4, 1.0 };
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};
ItemImageData RocketTurretPackImage
{
shapeFile = "remoteTurret";
mountPoint = 2;
mountOffset = { 0, -0.12, -0.1 };
mountRotation = { 0, 0, 0 };
mass = 2.5;
firstPerson = false;
};
ItemData RocketTurretPack
{
description = "Rocket Turret";
shapeFile = "remoteturret";
className = "Backpack";
heading = "oTurrets";
imageType = RocketTurretPackImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 350;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function RocketTurretPack::onUse(%player,%item)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "RocketTurretPack::onUse: (%player)=" @ %player @ " (%item)=" @ %item);
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function RocketTurretPack::onDeploy(%player,%item,%pos)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "RocketTurretPack::onDeploy: (%player)=" @ %player @ " (%item)=" @ %item @ " (%pos)=" @ %pos);
if (RocketTurretPack::deployShape(%player,%item)) {
Player::decItemCount(%player,%item);
}
}
function RocketTurretPack::deployShape(%player,%item)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "RocketTurretPack::deployShape: (%player)=" @ %player @ " (%item)=" @ %item);
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
%set = newObject("set",SimSet);
%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
%num = CountObjects(%set,"DeployableRocketTurret",%num);
deleteObject(%set);
if($MaxNumTurretsInBox > %num) {
%set = newObject("set",SimSet);
%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
%num = CountObjects(%set,"DeployableRocketTurret",%num);
deleteObject(%set);
if(0 == %num) {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
if(checkDeployArea(%client,$los::position)) {
%rot = GameBase::getRotation(%player); 
%turret = newObject("remoteRocketTurret","Turret",DeployableRocketTurret,true);
addToSet("MissionCleanup", %turret);
GameBase::setTeam(%turret,GameBase::getTeam(%player));
GameBase::setPosition(%turret,$los::position);
GameBase::setRotation(%turret,%rot);
Gamebase::setMapName(%turret,"RMT Rocket Turret#" @ $totalNumRocketTurrets++ @ " "@ Client::getName(%client));
Client::sendMessage(%client,0,"Remote Rocket Turret deployed");
playSound(SoundPickupBackpack,$los::position);
$TeamItemCount[GameBase::getTeam(%player) @ "RocketTurretPack"]++;
echo("MSG: ",%client," deployed a Remote Rocket Turret");
return true;
}
}
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
} 
else
Client::sendMessage(%client,0,"Frequency Overload - Too close to other remote turrets");
}
else 
Client::sendMessage(%client,0,"Interference from other remote turrets in the area");
}
else 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
}
else 
Client::sendMessage(%client,0,"Deploy position out of range");
}
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
return false;
}
TurretData DeployableRocketTurret
{
className = "Turret";
shapeFile = "remoteturret";
projectileType = DeployableTurretMissile;
maxDamage = 0.55;
maxEnergy = 60; 
gunRange = 250;
minGunEnergy = 30;
maxGunEnergy = 20;
sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
reloadDelay = 3; 
speed = 3.0;
speedModifier = 1.5;
range = 150;
visibleToSensor = true;
shadowDetailMask = 4;
dopplerVelocity = 0;
castLOS = true;
supression = false;
mapFilter = 2;
mapIcon = "M_turret";
debrisId = flashDebrisMedium;
shieldShapeName = "shield";
fireSound = SoundMissileTurretFire;
activationSound = SoundMissileTurretOn;
deactivateSound = SoundMissileTurretOff;
targetableFovRatio = 0.5;
explosionId = Shockwave;
description = "Remote Rocket Turret";
damageSkinData = "objectDamageSkins";
};
function DeployableRocketTurret::onAdd(%this)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployableRocketTurret::onAdd: (%this)=" @ %this);
schedule("DeployableRocketTurret::deploy(" @ %this @ ");",1,%this);
GameBase::setRechargeRate(%this,5);
%this.shieldStrength = 0;
if (GameBase::getMapName(%this) == "") {
GameBase::setMapName (%this, "Remote Rocket Turret");
}
}
function DeployableRocketTurret::deploy(%this)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployableRocketTurret::deploy: (%this)=" @ %this);
GameBase::playSequence(%this,1,"deploy");
}
function DeployableRocketTurret::onEndSequence(%this,%thread)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployableRocketTurret::onEndSequence: (%this)=" @ %this @ " (%thread)=" @ %thread);
GameBase::setActive(%this,true);
%this.shieldStrength = 0.015;
}
function DeployableRocketTurret::onDestroyed(%this)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployableRocketTurret::onDestroyed: (%this)=" @ %this);
Turret::onDestroyed(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "RocketTurretPack"]--;
}
function DeployableRocketTurret::onPower(%this,%power,%generator) {}
function DeployableRocketTurret::onEnabled(%this) 
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployableRocketTurret::onEnabled: (%this)=" @ %this);
GameBase::setRechargeRate(%this,5);
GameBase::setActive(%this,true);
} 
function DeployableRocketTurret::verifyTarget(%this,%target)	// PORT: was (%target); the engine passes the turret first
{
if (GameBase::virtual(%target, "getHeatFactor") >= 1.0) {
return "True";
}
else {
return "False";
}
}
