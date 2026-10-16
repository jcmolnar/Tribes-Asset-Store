///-----------------------------------------------
/// Description - "Accelerator pad";
/// Plugin Created by TriCon Team C3 & graphfx
/// http://www.planetstarsiege.com/tricon
/// Original Idea ripped from Z-Tek
/// http://216.169.122.124/Z-Tek
///-----------------------------------------------

MiniMod::MonitorFile(start, "AccelPad.CodeFusion.cs", "Accelerator Pad Plugin");
MiniMod::Turbo::Class(AccelPPack, 9);

$TeamItemMax[AccelPPack] = 3;


StaticShapeData AccelPadPack
{
className = "AccelPadPack";
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
function AccelPadPack::Destruct(%this)
{
AccelPadPack::doDamage(%this);
}
function AccelPadPack::doDamage(%this) {
}
function AccelPadPack::onDestroyed(%this)
{
AccelPadPack::doDamage(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "AccelPadPack"]--;
}
function AccelPadPack::onCollision(%this,%obj)
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
%msg="<f1>Accelerator Pad : <f0>Face the direction you want to go, then jump or use your jets.  You may walk off the platform to avoid being deployed.";
remoteEval(%c, "BP", %msg, 0);
AccelPadPack::CheckPlayer(%this,%obj);
}
} else if(%diffZ<0.950) {
remoteEval(%c, "CP", "", 0);
%obj.deployStandby=0;
}
}
return;
}
function AccelPadPack::CheckPlayer(%this,%obj) {
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
} else if(%rnd>28) {
playSound(debrisLargeExplosion,%tpos);
%len+=200;
%zlen+=220;
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
schedule("AccelPadPack::CheckPlayer("@%this@","@%obj@");",0.05);
} else {
remoteEval(%client, "CP", "", 0);
}
}
ItemImageData AccelPPackImage
{
shapeFile = "shieldpack";
mountPoint = 2;
firstPerson = false;
};
ItemData AccelPPack
{
description = "Accelerator Pad";
shapeFile = "elevator_6x6_octagon";
className = "Backpack";
heading = "sPersonnel Movers";
imageType = AccelPPackImage;
shadowDetailMask = 4;
mass = 2.0;
elasticity = 0.2;
price = 950;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function AccelPPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function AccelPPack::onDeploy(%player,%item,%pos)
{
if (AccelPPack::deployShape(%player,"AccelPad",AccelPadPack,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"]++;
}
}
function CreateAccelPadSimSet()
{
%teleset = nameToID("MissionCleanup/AccelPadPack");
if(%teleset == -1)
{
newObject("AccelPadPack",SimSet);
addToSet("MissionCleanup","AccelPadPack");
}
}
function AccelPPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "AccelPPack"] < $TeamItemMax[AccelPPack]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
%sensor = newObject("AccelPadPack","StaticShape",%shape,true);
CreateAccelPadSimSet();
addToSet("MissionCleanup/AccelPadPack", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 -0.25");
GameBase::setPosition(%player,Vector::add(%pos,"0 0 1"));
GameBase::setPosition(%sensor,%pos);
%Rot=GameBase::getRotation(%player);
%Rot=Vector::add(%Rot,"0 0 3.14159");
GameBase::setRotation(%sensor,%rot);
GameBase::setPosition(%sensor,%pos);
Gamebase::setMapName(%sensor,"Accel Pad");
Client::sendMessage(%client,0,%item.description @ " deployed");
echo("MSG: ",%client," deployed an Accelerator Pad ");
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
else {
Client::sendMessage(%client,0,"Deploy position out of range");
}
}
else
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
return false;
}

$InvList[AccelPPack] = 1;
$RemoteInvList[AccelPPack] = 1;

MiniMod::MonitorFile(stop, "AccelPad.CodeFusion.cs", "Accelerator Pad Plugin");
