StaticShapeData DeployableBaseOps
{
className = "DeployableBaseOps";
damageSkinData = "objectDamageSkins";
shapeFile = "elevator6x6thin";
maxDamage = 100;
maxEnergy = 200;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,1.0,1.0};
side = "single";
isTranslucent = true;
};
StaticShapeData BaseOpsGen
{
className = "BaseOpsGenerator";
damageSkinData = "objectDamageSkins";
shapeFile = "generator"; 
maxDamage = 3.0;
maxEnergy = 500;
sfxAmbient = SoundGeneratorPower;
mapFilter = 2;
visibleToSensor = true;
explosionId = mortarExp;
debrisId = flashDebrisLarge;
lightRadius = 12.0;
lightType=2;
lightColor = {1.0,0.2,0.2};
mass=2.5;
};
function BaseOpsGenerator::onDestroyed(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "BaseOpsGenerator::onDestroyed: (%this)=" @ %this); 
BaseOpsGenerator::onDisabled(%this);
%team=GameBase::getTeam(%this);
%set=nameToID("MissionCleanup/BaseOps!"@%team);
if(%set!=-1) { 
DeployableBaseOps::onDestroyed(Group::getObject(%set,0));
}
}
function BaseOpsGenerator::onEnabled(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "BaseOpsGenerator::onEnabled (%this)="@%this); 
BaseOpsGenerator::setActive(%this,true);
}
function BaseOpsGenerator::onDisabled(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "BaseOpsGenerator::onDisabled (%this)="@%this);
GameBase::stopSequence(%this,0);
DeployableBaseOps::setPower(GameBase::getTeam(%this),0);
}
function BaseOpsGenerator::setActive(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "BaseOpsGenerator::onActivate (%this)="@%this);
GameBase::playSequence(%this,0,"power");
DeployableBaseOps::setPower(GameBase::getTeam(%this),1);
}
function BaseOpsGenerator::onActivate(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "BaseOpsGenerator::onActivate (%this)="@%this);
GameBase::playSequence(%this,0,"power");
DeployableBaseOps::setPower(GameBase::getTeam(%this),1);
}
function DeployableBaseOps::Destruct(%this)
{
DeployableBaseOps::doDamage(%this);
}
function DeployableBaseOps::doDamage(%this) {
calcRadiusDamage(%this, $DebrisDamageType, 5, 1, 25, 15, 4, 0.4, 0.1, 250, 100); 
}
function DeployableBaseOps::powerState(%this) {
%team=GameBase::getTeam(%this);
%set=nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
if(%set!=-1) {
%obs=Group::objectCount(%set);
%gen=-1;
%obj=-1;
for(%x=0;%x<%obs;%x++) {
%objt=Group::getObject(%set,%x);
if(%objt==%this) {
%obj=%objt; 
}
if(GameBase::getDataName(%objt)=="BaseOpsGen") %gen=%objt;
}
if(%obj!=-1&&%gen!=-1) { 
if(GameBase::getDamageState(%gen)!="Enabled") {
return 0;
} else {
return 1;
}
}
}
return 0;
}
function DeployableBaseOps::onDestroyed(%this)
{
DeployableBaseOps::doDamage(%this);
%team=GameBase::getTeam(%this);
%set1=nameToID("MissionCleanup/BaseOps!"@%team);
%set2=nameToID("MissionCleanup/BaseOpsX!"@%team);
%set3=nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
if(%set1!=-1&&%set2!=-1&&%set3!=-1) {
$TeamItemCount[%team @ "DeployableBaseOps"]--;
if(%this==Group::getObject(%set1,0)) {
%objs=group::objectcount(%set1);
for(%x=0;%x<%objs;%x++) {
%obj=Group::getObject(%set1,%x);
schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
if(GameBase::getMapName(%obj)=="RBO") schedule("$TeamItemCount["@%team@"@\"DeployableBaseOps\"]=0;",20);
} 
deleteObject(%set1);
%objs=group::objectcount(%set3);
for(%x=0;%x<%objs;%x++) {
%obj=Group::getObject(%set3,%x);
schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
} 
deleteObject(%set1);
%objs=group::objectcount(%set2);
for(%x=0;%x<%objs;%x++) {
%obj=Group::getObject(%set2,%x);
schedule("GameBase::setDamageLevel("@%obj@",10000);",(floor(getRandom()*150)/10));
} 
deleteObject(%set2);
} else {
GameBase::setDamageLevel(Group::getObject(%set1,0),100);
}
}
}
function DeployableBaseOps::onCollision(%this,%obj)
{
return;
}
ItemImageData BaseOpsPackImage
{
shapeFile = "shieldPack";
mountPoint = 2;
firstPerson = false;
};
ItemData BaseOpsPack
{
description = "R. B. O.";
shapeFile = "logo";
className = "Backpack";
heading = "lDeployables";
imageType = BaseOpsPackImage;
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 9950;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function BaseOpsPack::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function BaseOpsPack::onDeploy(%player,%item,%pos)
{
if (BaseOpsPack::deployShape(%player,"RBO",DeployableBaseOps,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DeployableBaseOps"]++;
}
}
function CreateBaseOpsimSet(%team)
{
%teleset = nameToID("MissionCleanup/BaseOps!"@%team);
if(%teleset == -1)
{
newObject("BaseOps!"@%team,SimSet);
addToSet("MissionCleanup","BaseOps!"@%team);
}
%teleset = nameToID("MissionCleanup/BaseOpsX!"@%team);
if(%teleset == -1)
{
newObject("BaseOpsX!"@%team,SimSet);
addToSet("MissionCleanup","BaseOpsX!"@%team);
}
%teleset = nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
if(%teleset == -1)
{
newObject("BaseOpsX!"@%team@"!Powered",SimSet);
addToSet("MissionCleanup","BaseOpsX!"@%team@"!Powered");
}
}
function DeployableBaseOps::setPower(%team,%power) {
%teleset = nameToID("MissionCleanup/BaseOpsX!"@%team@"!Powered");
if(%teleset != -1)
{
%objs=Group::objectCount(%teleset);
if(%objs) {
for(%x=0;%x<%objs;%x++) {
%obj=Group::getObject(%teleset,%x);
if(GameBase::getMapName(%obj)=="RBO Inventory Station" 
|| GameBase::getMapName(%obj)=="RBO Ammo Station"
|| GameBase::getMapName(%obj)=="RBO Command Station") {
if(GameBase::getDamageState(%obj)!="Disabled") {
Station::onPower(%obj,%power,0);
} else {
Station::onPower(%obj,0,0);
}
} else if(GameBase::getMapName(%obj)=="RBO Pulse Sensor") {
GameBase::setActive(%obj,%power);
if(GameBase::getDamageState(%obj)!="Disabled") {
if (%power) {
%obj.shieldStrength = 0.03;
GameBase::setRechargeRate(%obj,10);
GameBase::playSequence(%obj,0,"power");
}
else {
%this.shieldStrength = 0;
GameBase::setRechargeRate(%obj,0);
GameBase::StopSequence(%obj,0);
}
GameBase::setActive(%this,%power);
} else {
GameBase::StopSequence(%obj,0); 
}
} else {
}
}
}
}
}
function BaseOpsPack::deployShape(%player,%name,%shape,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DeployableBaseOps"] < $TeamItemMax[DeployableBaseOps]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
%team=GameBase::getTeam(%player);
CreateBaseOpsimSet(%team);
%rot="0 0 0";
%opos=Vector::add($los::position,"0 0 5");
%sensor = newObject("RBOCL1T0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 0 0");
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
GameBase::setPosition(%sensor,%pos);
GameBase::startFadeIn(%sensor);
Gamebase::setMapName(%sensor,%name);
%dcont=1;
for(%z=0;%z<10;%z++) { 
%tpos=Vector::add(%opos,"0 0 "@%z);
GameBase::setPosition(%sensor,%tpos);
for(%x=0;%x<360;%x+=5) { 
%rad=(%x/180)*3.141592654;
%rpos="0 0 "@%rad;
if(GameBase::getLOSInfo(%sensor,14,%rpos)!=False) {
%dcont=0;
break;
}
}
if(%dcont) %z++;
}
if(!%dcont) {
GameBase::setPosition(%sensor,"-2000,-2000,-2000"); 
GameBase::setDamageLevel(%sensor,10000);
Client::sendMessage(%client,0,"Cannot build RBO.  Object(s) in way.");
return false;
}
%opos=%tpos;
addToSet("MissionCleanup/BaseOps!"@%team, %sensor);
echo("Final Deployment Position:  "@%opos);
%sensor = newObject("Inventory1","StaticShape",InventoryStation,true);
%pos=Vector::add(%opos,"6.863 6.844 6.496");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 -0.752468");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Inventory Station");
%sensor = newObject("Command1","StaticShape",CommandStation,true);
%pos=Vector::add(%opos,"7.458 -7.435 6.496");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 -2.37301");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Command Station");
%sensor = newObject("Ammo1","StaticShape",AmmoStation,true);
%pos=Vector::add(%opos,"7.015 -6.949 0.496");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 -2.34776");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Ammo Station");
%sensor = newObject("Ammo2","StaticShape",AmmoStation,true);
%pos=Vector::add(%opos,"-7.459 7.344 0.496");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 0.803911");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Ammo Station");
%sensor = newObject("Pulse1","Sensor",PulseSensor,true);
%pos=Vector::add(%opos,"0 0 12.498");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 0 0");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Pulse Sensor");
%sensor = newObject("Generator1","StaticShape",BaseOpsGen,true);
%pos=Vector::add(%opos,"-5.909 6.186 6.495");
addToSet("MissionCleanup/BaseOpsX!"@%team@"!Powered", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,"0 -0 -0.0219599");
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name@" Generator");
GameBase::setActive(%sensor,True);
%sensor = newObject("RBOCL1T1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 0 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1T2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 0 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1T3","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1T4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1T6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1T7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1T8","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 -6 0");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 0 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 6 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 -6 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W3","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W5","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 0 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 6 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W8","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 -6 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W9","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W10","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL1W11","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 -8.5 3");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2T0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 0 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2T1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 0 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2T2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 0 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2T3","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2T4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2T5","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2T6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2T7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 6 6");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 0 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 6 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"8.5 -6 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W9","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W5","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"-1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 0 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 6 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W8","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-8.5 -6 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"0 -1.570796327 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W9","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W10","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL2W11","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 -8.5 9");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,Vector::add(%rot,"1.570796327 0 0"));
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T0","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 0 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T1","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 0 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T2","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 0 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T3","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T4","StaticShape",%shape,true);
%pos=Vector::add(%opos,"0 -6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T5","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T6","StaticShape",%shape,true);
%pos=Vector::add(%opos,"6 -6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T7","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
%sensor = newObject("RBOCL3T8","StaticShape",%shape,true);
%pos=Vector::add(%opos,"-6 -6 12");
addToSet("MissionCleanup/BaseOpsX!"@%team, %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,%team);
GameBase::setRotation(%sensor,%rot);
%rtime=(floor(getRandom()*150)/10);
schedule("GameBase::setPosition("@%sensor@",\""@%pos@"\");",%rtime);
schedule("GameBase::startFadeIn("@%sensor@");",%rtime);
Gamebase::setMapName(%sensor,%name);
Client::sendMessage(%client,0,%item.description @ " under construction.  Fifteen seconds to completion.");
echo("RBO Deployed ("@%sensor@")");
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
else 
Client::sendMessage(%client,0,"Deploy position out of range");
}
else
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %name @ "s");
return false;
}
