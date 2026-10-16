StaticShapeData DeployablePDS
{
className = "DeployablePDS";
damageSkinData = "objectDamageSkins";
shapeFile = "elevator_6x6_octagon";
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
function DeployablePDS::Destruct(%this)
{
DeployablePDS::doDamage(%this);
}
function DeployablePDS::doDamage(%this) {
}
function DeployablePDS::onDestroyed(%this)
{
DeployablePDS::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "DeployablePDS"]--;
}
function DeployablePDS::onCollision(%this,%obj)
{
if(getObjectType(%obj) != "Player") {return;}
if(Player::isDead(%obj)) {return;}
%c = Player::getClient(%obj);
%pteam = GameBase::getTeam(%obj);
%oteam = GameBase::getTeam(%this);
%diffZ=getWord(GameBase::getPosition(%obj),2)-getWord(GameBase::getPosition(%this),2);
%tpos=GameBase::getPosition(%this);
%opos=GameBase::getPosition(%obj);
%tstartX=getWord(%tpos,0);
%tstartY=getWord(%tpos,1);
%tstartZ=getWord(%tpos,2);
%ostartX=getWord(%opos,0);
%ostartY=getWord(%opos,1);
%ostartZ=getWord(%opos,2);
%diffX=%ostartX-%tstartX;
%diffY=%ostartY-%tstartY;
%diffZ=%ostartZ-%tstartZ;
if(%pteam==%oteam) {
if(%obj.deployStandby!=1) {
if(%diffZ>0.950) {
%obj.deployStandby=1;
%msg="<f1>Personnel Deployment System Use:\n<f0>Face the direction you want to go, then jump or use your jets.  You may walk off the platform to avoid being deployed.";
remoteEval(%c, "CP", %msg, 0);
DeployablePDS::CheckPlayer(%this,%obj);
} 
} else if(%diffZ<0.950) {
remoteEval(%c, "CP", "", 0);
%obj.deployStandby=0;
}
}
return;
}
function DeployablePDS::CheckPlayer(%this,%obj) {
%tpos=GameBase::getPosition(%this);
%opos=GameBase::getPosition(%obj);
%tstartX=getWord(%tpos,0);
%tstartY=getWord(%tpos,1);
%tstartZ=getWord(%tpos,2);
%ostartX=getWord(%opos,0);
%ostartY=getWord(%opos,1);
%ostartZ=getWord(%opos,2);
%diffX=%ostartX-%tstartX;
%diffY=%ostartY-%tstartY;
%diffZ=%ostartZ-%tstartZ-0.92;
%deploy=0; 
%recall=1; 
if(%diffZ>0.5) %deploy=1;
if(%diffZ<0) %deploy=-1;
%client=Player::getClient(%obj);
if(%deploy>0) {
%armor=GameBase::getDataName(%obj);
%mass=%armor.mass;
%rot=GameBase::getRotation(%obj);
%len=50;
%zlen=50;
%rnd=floor(getrandom()*30);
if(%rnd>24 && %rnd<29) { 
playSound(debrisMediumExplosion,%tpos);
%len+=15;
%zlen+=20;
Client::sendMessage(%client,0,"P.D.S. Additional boost.");
} else if(%rnd>28) { 
playSound(debrisLargeExplosion,%tpos); 
%len+=200;
%zlen+=220;
Client::sendMessage(%client,0,"P.D.S. Orbital Vector Established.");
messageAll(2,Client::getName(%client)@" took an extended vacation.");
} else { 
playSound(debrisSmallExplosion,%tpos); 
}
%vec=Vector::getFromRot(%rot,%len*%mass,%zlen*%mass);
Player::applyImpulse(%obj,%vec);
schedule(%obj@".deployStandby=0;",0.1);
%recall=0;
} else if(%deploy<0) {
%recall=0;
%obj.deployStandby=0;
}
if(%recall) {
schedule("DeployablePDS::CheckPlayer("@%this@","@%obj@");",0.05);
} else {
remoteEval(%client, "CP", "", 0);
}
}
ItemImageData PDSPackImage
{
shapeFile = "shieldpack";
mountPoint = 2;
firstPerson = false;
};
ItemData PDSPack
{
description = "P. D. S.";
shapeFile = "elevator_6x6_octagon";
className = "Backpack";
heading = "lDeployables";
imageType = PDSPackImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 550;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function PDSPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function PDSPack::onDeploy(%player,%item,%pos)
{
if (PDSPack::deployShape(%player,"PDS",DeployablePDS,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployablePDS"]++;
}
}
function CreatePDSSimSet()
{
%teleset = nameToID("MissionCleanup/PDS");
if(%teleset == -1)
{
newObject("PDS",SimSet);
addToSet("MissionCleanup","PDS");
}
}
function PDSPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployablePDS"] < $TeamItemMax[DeployablePDS]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
echo("::"@GameBase::getDataName($los::object)@"::");
if (CheckDeployTerrain($los::object)) {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
%sensor = newObject("Deployable PDS","StaticShape",%shape,true);
CreatePDSSimSet();
addToSet("MissionCleanup/PDS", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 -0.25");
GameBase::setPosition(%player,Vector::add(%pos,"0 0 1"));
GameBase::setPosition(%sensor,%pos);
%Rot=GameBase::getRotation(%player);
%Rot=Vector::add(%Rot,"0 0 3.14159");
GameBase::setRotation(%sensor,%rot);
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
Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
}
else 
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
}
else {
Client::sendMessage(%client,0,"Deploy position out of range");
}
}
else
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
return false;
}
