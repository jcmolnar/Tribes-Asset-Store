SeekingMissileData DeployablePhaseLokMissile
{
bulletShapeName = "fusionbolt.dts";
explosionTag = rocketExp;
collisionRadius = 0;
mass = 2.0;
damageClass = 1; 
damageValue = 0.17; 
damageType = $MissileDamageType;
explosionRadius = 4.5;
kickBackStrength = 15;
muzzleVelocity = 30; 
totalTime = 25; 
liveTime = 25; 
seekingTurningRadius = 9;
nonSeekingTurningRadius = 75.0;
proximityDist = 1.5;
smokeDist = 1.5;
lightRange = 5.0;
lightColor = { 0, 0, 1.0 };
inheritedVelocityScale = 0.5;
soundId = SoundJetHeavy;
};
ItemImageData PhaseLokPackImage
{
shapeFile = "remoteTurret";
mountPoint = 2;
mountOffset = { 0, -0.12, -0.1 };
mountRotation = { 0, 0, 0 };
mass = 2.5;
firstPerson = false;
};
ItemData PhaseLokPack
{
description = "PhaseLok";
shapeFile = "mineammo";
className = "Backpack";
heading = "lDeployables";
imageType = PhaseLokPackImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 350;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function PhaseLokPack::onUse(%player,%item)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "PhaseLokPack::onUse: (%player)=" @ %player @ " (%item)=" @ %item);
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function PhaseLokPack::onDeploy(%player,%item,%pos)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "PhaseLokPack::onDeploy: (%player)=" @ %player @ " (%item)=" @ %item @ " (%pos)=" @ %pos);
if (PhaseLokPack::deployShape(%player,%item)) {
Player::decItemCount(%player,%item);
}
}
function PhaseLokPack::deployShape(%player,%item)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "PhaseLokPack::deployShape: (%player)=" @ %player @ " (%item)=" @ %item);
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "PhaseLokAmmo"] < $TeamItemMax["PhaseLokAmmo"]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
%set = newObject("set",SimSet);
%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMaxLength,$TurretBoxMaxWidth,$TurretBoxMaxHeight,0);
%num = CountObjects(%set,"DeployablePhaseLok",%num);
deleteObject(%set);
if($MaxNumTurretsInBox > %num) {
%set = newObject("set",SimSet);
%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,$TurretBoxMinLength,$TurretBoxMinWidth,$TurretBoxMinHeight,0);
%num = CountObjects(%set,"DeployablePhaseLok",%num);
deleteObject(%set);
if(0 == %num) {
%prot = GameBase::getRotation(%player);
%zRot = getWord(%prot,2);
if (Vector::dot($los::normal,"0 0 1") > 0.6) {
%rot = "0 0 " @ %zRot;
}
else {
if (Vector::dot($los::normal,"0 0 -1") > 0.6) {
%rot = "3.14159 0 " @ %zRot;
}
else {
%rot = Vector::getRotation($los::normal);
}
}
if(checkDeployArea(%client,$los::position)) {
%turret = newObject("PhaseLok","Turret",DeployablePhaseLok,true);
addToSet("MissionCleanup", %turret);
GameBase::setTeam(%turret,GameBase::getTeam(%player));
GameBase::setPosition(%turret,$los::position);
GameBase::setRotation(%turret,%rot);
Gamebase::setMapName(%turret,"PhaseLok (" @ Client::getName(%client)@")");
Client::sendMessage(%client,0,"PhaseLok deployed");
playSound(SoundPickupBackpack,$los::position);
$TeamItemCount[GameBase::getTeam(%player) @ PhaseLokAmmo]++;
echo("MSG: ",%client," deployed a PhaseLok");
return true;
}
} 
else
Client::sendMessage(%client,0,"Frequency Overload - Too close to other PhaseLoks");
}
else 
Client::sendMessage(%client,0,"Interference from other PhaseLoks in the area");
}
else 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
}
else 
Client::sendMessage(%client,0,"Deploy position out of range");
}
else 
Client::sendMessage(%client,0,"Deployable Item limit reached for PhaseLoks");
return false;
}
TurretData DeployablePhaseLok
{
className = "Turret";
shapeFile = "camera";
projectileType = DeployablePhaseLokMissile;
maxDamage = 0.7;
maxEnergy = 100;
gunRange = 100;
minGunEnergy = 30;
maxGunEnergy = 20;
sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
reloadDelay = 4;
speed = 10;
speedModifier = 1.5;
range = 50;
visibleToSensor = true;
shadowDetailMask = 4;
dopplerVelocity = 0;
castLOS = true;
supression = false;
mapFilter = 2;
mapIcon = "M_camera";
debrisId = flashDebrisMedium;
shieldShapeName = "shield";
fireSound = SoundMissileTurretFire;
activationSound = SoundMissileTurretOn;
deactivateSound = SoundMissileTurretOff;
targetableFovRatio = 0.5;
explosionId = debrisExpMedium;
description = "PhaseLok";
damageSkinData = "objectDamageSkins";
};
function DeployablePhaseLok::onAdd(%this)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployablePhaseLok::onAdd: (%this)=" @ %this);
schedule("DeployablePhaseLok::deploy(" @ %this @ ");",1,%this);
%this.shieldStrength = 0;
if (GameBase::getMapName(%this) == "") {
GameBase::setMapName (%this, "Remote PhaseLok");
}
}
function DeployablePhaseLok::deploy(%this)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployablePhaseLok::deploy: (%this)=" @ %this);
GameBase::playSequence(%this,1,"deploy");
GameBase::setRechargeRate(%this,50);
}
function DeployablePhaseLok::onEndSequence(%this,%thread)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployablePhaseLok::onEndSequence: (%this)=" @ %this @ " (%thread)=" @ %thread);
GameBase::setActive(%this,true);
%this.shieldStrength = 0.0;
}
function DeployablePhaseLok::onDestroyed(%this)
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployablePhaseLok::onDestroyed: (%this)=" @ %this);
Turret::onDestroyed(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "PhaseLokAmmo"]--;
}
function DeployablePhaseLok::onPower(%this,%power,%generator) {}
function DeployablePhaseLok::onEnabled(%this) 
{
if($Debug::Tr) echo($DebugHeading::Tr @ "DeployablePhaseLok::onEnabled: (%this)=" @ %this);
GameBase::setRechargeRate(%this,5);
GameBase::setActive(%this,true);
} 
function DeployablePhaseLok::verifyTarget(%target)
{
return "True";
}
