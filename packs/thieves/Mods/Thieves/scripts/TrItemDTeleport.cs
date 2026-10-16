StaticShapeData DeployableTeleport
{
className = "DeployableTeleport";
damageSkinData = "objectDamageSkins";
shapeFile = "flagstand";
maxDamage = 0.5;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
};
function RemoveBeam(%b)
{
deleteObject(%b);
} 
function DeployableTeleport::Destruct(%this)
{
DeployableTeleport::doDamage(%this);
}
function DeployableTeleport::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 4, 3, 25, 15, 4, 1.0, 0.1, 250, 100); 
}
function DeployableTeleport::onDestroyed(%this)
{
schedule("RemoveBeam("@%this.beam@");",1);
DeployableTeleport::doDamage(%this);
%teleset = nameToID("MissionCleanup/Teleports/"@%this.Owner);
for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
{
if(GameBase::getTeam(%o) == GameBase::getTeam(%this) && %o != %this)
{
GameBase::applyDamage(%o,$DebrisDamageType,20,GameBase::getPosition(%o),"0 0 0","0 0 0",%this);
}
}
deleteObject(%teleset);
$TeamItemCount[GameBase::getTeam(%this) @ "DeployableTeleport"]=Group::objectCount(%teleset);
return;
}
function DeployableTeleport::onCollision(%this,%obj)
{
if(getObjectType(%obj) != "Player")
{
return;
}
if(Player::isDead(%obj))
{
return;
}
%c = Player::getClient(%obj);
%playerTeam = GameBase::getTeam(%obj);
%teleTeam = GameBase::getTeam(%this);
if(%teleTeam != %playerTeam)
{
Client::SendMessage(%c,0,"Wrong team.  Self Destructing!");
GameBase::applyDamage(%this,$DebrisDamageType,10,GameBase::getPosition(%this),"0 0 0","0 0 0",%this);
return;
}
if(%this.disabled == true)
{
Client::SendMessage(%c,0,"Teleport Pad is recharging");
return;
}
if(%obj.carryFlag>0) {
Client::SendMessage(%c,0,"Flag carriers cannot teleport!");
return;
}
%teleset = nameToID("MissionCleanup/Teleports/"@%this.Owner);
for(%i = 0; (%o = Group::getObject(%teleset, %i)) != -1; %i++)
{
if(GameBase::getTeam(%o) == %playerteam && %o != %this)
{
if(Player::getArmor(%obj) == "harmor" ||Player::getArmor(%obj) == "dreadarmor")
{
Client::SendMessage(%c,0,"Cannot teleport in heavy armor");
return;
}
else
{
%set = newObject("set",SimSet);
%num = containerBoxFillSet(%set,$SimPlayerObjectType,Vector::add(GameBase::getPosition(%o),"0 0 1"),1.5,1.5,5,0);
if(%num) {
for(%x=0;%x<%num;%x++) {
%tfrag=Group::getObject(%set,%x);
%tclient=Player::getClient(%tfrag);
Client::SendMessage(%tclient,1,"You were just telefragged by "@Client::getName(%c));
messageall(2,Client::getName(%tclient)@" was just telefragged by "@Client::getName(%c));
Player::blowUp(%tclient);
GameBase::setDamageLevel(%tfrag,100);
}
}
deleteObject(%set);
GameBase::SetPosition(%obj,GameBase::GetPosition(%o));
%o.Disabled = true;
schedule("GameBase::playSound("@%this@",SoundBeaconUse,0);",0.35);
schedule("GameBase::playSound("@%o@",SoundBeaconUse,0);",0.35);
%this.Disabled = true;
GameBase::startfadeout(%o.beam);
%pos=GameBase::getPosition(%o.beam);
%pos=Vector::add(%pos,"0 0 -5000");
schedule("GameBase::setPosition("@%o.beam@",\""@%pos@"\");",3);
GameBase::startfadeout(%this.beam);
%pos=GameBase::getPosition(%this.beam);
%pos=Vector::add(%pos,"0 0 -5000");
schedule("GameBase::setPosition("@%this.beam@",\""@%pos@"\");",3);
if(floor(getRandom() * 100) == 0)
{
Client::SendMessage(%c,0,"Teleport self destructs");
DeployableTeleport::doDamage(%o);
}
else
{
schedule("DeployableTeleport::Reenable("@%o@");",7);
schedule("DeployableTeleport::Reenable("@%this@");",7);
}
return;
}
}
}
Client::SendMessage(%c,0,"No other pad to teleport to");
}
function DeployableTeleport::Reenable(%this)
{
%this.disabled = false;
%pos=GameBase::getPosition(%this.beam);
%pos=Vector::add(%pos,"0 0 5000");
GameBase::setPosition(%this.beam,%pos);
GameBase::startfadein(%this.beam);
}
ItemImageData TeleportPackImage
{
shapeFile = "flagstand";
mountPoint = 2;
mountOffset = { 0, 0, 0.1 };
mountRotation = { 1.57, 0, 0 };
firstPerson = false;
};
ItemData TeleportPack
{
description = "Teleport Pad";
shapeFile = "flagstand";
className = "Backpack";
heading = "lDeployables";
imageType = TeleportPackImage;
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 1500;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function TeleportPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function TeleportPack::onDeploy(%player,%item,%pos)
{
%client=Player::getClient(%player);
if (teleportPack::deployShape(%player,"Teleport Pad",DeployableTeleport,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"]=Group::objectCount(%teleset);
%teleset = nameToID("MissionCleanup/Teleports/"@Client::getName(%client));
if(Group::objectCount(%teleset)<2) {
Client::sendMessage(%client,0,"You have 10 minutes to set the other teleport.");
schedule("TeleportPack::CheckTeleport("@%player@","@%teleset@");",600);
}
}
}
function TeleportPack::CheckTeleport(%player,%teleset) {
%client=Player::getClient(%player);
%teletest=nameToID("MissionCleanup/Teleports/"@Client::getName(%client));
echo("TELE: "@%teletest@" "@%teleset);
if(%teletest!=%teleset) return; 
if(Group::objectCount(%teleset)<2) {
%objs=Group::objectCount(%teleset);
Client::sendMessage(%client,1,"Teleport Self Destruct!  You failed to set the other teleport!");
for(%x=0;%x<%objs;%x++) {
%obj=Group::getObject(%teleset,%x);
GameBase::setDamageLevel(%obj,10);
}
deleteObject(%teleset);
}
}
function CreateteleportSimSet(%this)
{
%teleset = nameToID("MissionCleanup/Teleports");
if(%teleset == -1)
{
newObject("Teleports",SimSet);
addToSet("MissionCleanup","Teleports");
}
%teleset = nameToID("MissionCleanup/Teleports/"@%this.Owner);
if(%teleset == -1)
{
newObject(%this.Owner,SimSet);
addToSet("MissionCleanup/Teleports",%this.Owner);
}
}
function TeleportPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableTeleport"] < $TeamItemMax[DeployableTeleport]) {
%teleset = nameToID("MissionCleanup/Teleports/"@Client::getName(%client));
if(%teleset!=-1) {
%objs=Group::objectCount(%teleset);
if(%objs>1) {
Client::sendMessage(%client,0,"You can only have one active teleport at a time.");
return false;
}
}
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
if(checkDeployArea(%client,$los::position)) {
%sensor = newObject("Teleport Pad","StaticShape",%shape,true);
%sensor.Owner=Client::getName(%client);
CreateteleportSimSet(%sensor);
addToSet("MissionCleanup/Teleports/"@%sensor.Owner, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 0.5");
echo("LOS pos " @ $los::position @ " "@ %pos);
GameBase::setPosition(%sensor,%pos);
%beam = newObject("","StaticShape",PoweredElectricalBeam,true);
addToSet("MissionCleanup", %beam);
GameBase::setTeam(%beam,GameBase::getTeam(%player));
if(%objs<2) {
GameBase::setPosition(%beam,"0 0 -5000");
} 
%sensor.beam = %beam;
%teleset = nameToID("MissionCleanup/Teleports/"@Client::getName(%client));
%objs=Group::objectCount(%teleset);
if(%objs<2) {
Gamebase::setMapName(%sensor,"TelePad ("@%sensor.Owner@") - No Destination");
} else {
for(%cnt=0;%cnt<%objs;%cnt++) {
%mobj=Group::getObject(%teleset,%cnt);
Gamebase::setMapName(%mobj,"TelePad +("@%mobj.Owner@")");
GameBase::setPosition(%mobj.beam,GameBase::getPosition(%mobj));
}
}
Client::sendMessage(%client,0,%item.description @ " deployed");
%sensor.disabled = false;
playSound(SoundPickupBackpack,$los::position);
%sensor.rotation=0; 
schedule("DeployableTeleport::Rotate("@%sensor@");",0.05);
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
function DeployableTeleport::Rotate(%this) { 
%crot=GameBase::getRotation(%this);
%pos=GameBase::getPosition(%this);
if(%pos!="0 0 0") {
%crad1=getWord(%crot,0);
%crad2=getWord(%crot,1);
%crad3=getWord(%crot,2);
%cdeg=%crad3/0.017453292;
if(%cdeg+1>359) %cdeg=0;
%crad3=(%cdeg+1)*0.017453292;
GameBase::setRotation(%this,%crad1@" "@%crad2@" "@%crad3);
GameBase::setRotation(%this.beam,%crad1@" "@%crad2@" "@%crad3);
schedule("DeployableTeleport::Rotate("@%this@");",0.05);
}
}
