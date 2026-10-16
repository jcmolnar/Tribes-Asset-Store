$DShield::MaxCapCharge=4.0;
$DShield::TimerTick=0.50;
$DShield::ShieldEnhance=0.01;
$DShield::ProtectArea=50; 
$DShield::OverlapValue=0; 
StaticShapeData DShield
{
className = "DShield";
damageSkinData = "objectDamageSkins";
shapeFile = "generator_p"; 
maxDamage = 1.4;
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
ItemImageData DShieldPackImage
{
shapeFile = "generator_p"; 
mountPoint = 2;
mountOffset = { 0, -0.5, -1 }; 
mountRotation = { 0.2, 0, 0 }; 
firstPerson = false;
};
ItemData DShieldPack
{
description = "Shield Generator";
shapeFile = "generator_p"; 
className = "Backpack";
heading = "lDeployables"; 
imageType = "DShieldPackImage";
sequenceSound[0] = { "power", SoundSensorPower };
shadowDetailMask = 4;
mass = 5.0;
elasticity = 0.2;
price = 3200;
hudIcon = "deployable";
showWeaponBar = true;
hiliteOnActive = true;
};
function DShield::onDestroyed(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::onDestroyed: (%this)=" @ %this);
DShield::onDisabled(%this);
CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
$TeamItemCount[GameBase::getTeam(%this) @ "DShield"]--;
%teleset = nameToID("MissionCleanup/Teleports");
}
function DShieldPack::onUse(%player,%item)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::onUse: (%player)=" @ %player @ " (%item)=" @ %item);
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function DShieldPack::onDeploy(%player,%item,%pos)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::onDeploy: (%player)=" @ %player @ " (%item)=" @ %item @ "(%pos)=" @ %pos);
if (DShieldPack::deployShape(%player,"Shield Generator",DShield,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DShield"]++;
}
}
function CreateDShieldSimSet(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::CreateDShieldSimSet");
%dset = nameToID("MissionCleanup/DShield");
if(%dset == -1)
{
newObject("DShield",SimSet);
addToSet("MissionCleanup","DShield");
}
%dset = nameToID("MissionCleanup/DShield/DShield"@%this);
if(%dset == -1)
{
newObject("DShield"@%this,SimSet);
addToSet("MissionCleanup/DShield","DShield"@%this);
}
}
function DShieldPack::deployShape(%player,%name,%shape,%item)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::deployShape: (%player)=" @ %player @ "(%name)=" @ %name @ "(%shape)=" @ %shape @ "(%item)=" @ %item);
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ "DShield"] < $TeamItemMax[DShield]) {
if (GameBase::getLOSInfo(%player,3)) {
%obj = getObjectType($los::object);
if (CheckDeployTerrain($los::object)) {
%set = newObject("set",SimSet);
%ovr = ($DShield::ProtectArea-$DShield::OverlapValue)/2;
%num = containerBoxFillSet(%set,$StaticObjectType,$los::position,%ovr,%ovr,%ovr,0);
%num = CountObjects(%set,"DShield",%num);
deleteObject(%set);
if(!%num) {
if (Vector::dot($los::normal,"0 0 1") > 0.7) {
if(checkDeployArea(%client,$los::position)) {
%sensor = newObject("Shield Generator","StaticShape",%shape,true);
CreateDShieldSimSet(%sensor);
addToSet("MissionCleanup/DShield", %sensor);
addToSet("MissionCleanup", %sensor);
GameBase::setTeam(%sensor,GameBase::getTeam(%player));
%pos = Vector::add($los::position,"0 0 0");
GameBase::setRotation(%sensor,GameBase::getRotation(%player));
GameBase::setPosition(%sensor,%pos);
Gamebase::setMapName(%sensor,%name);
GameBase::setRechargeRate(%sensor,1);
GameBase::setActive(%sensor,True);
Client::sendMessage(%client,0,%item.description @ " deployed!");
playSound(SoundPickupBackpack,$los::position);
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::deployShape: (%sensor)=" @ %sensor);
Client::sendMessage(%client,0,%item.description @ " initializing flux.");
schedule("DShield::checkArea("@%sensor@");",5);
return true;
}
}
else 
Client::sendMessage(%client,0,"Can only deploy on flat surfaces");
}
else
Client::sendMessage(%client,0,"Too close to other shield generators");
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
function DShield::onEnabled(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::onEnabled (%this)="@%this);
DShield::setActive(%this,true);
}
function DShield::onDisabled(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::onDisabled (%this)="@%this);
GameBase::stopSequence(%this,0);
%t=GameBase::getTeam(%this);
%obc1=Group::objectCount("MissionCleanup/CASimSet" @%this@"!"@ %t);
echo("DShield::onDisabled("@%this@")");
echo("        Object Count: "@%obc1);
for(%i=0;%i<%obc1;%i++) {
%objt1=Group::getObject("MissionCleanup/CASimSet"@%this@"!"@%t,%i);
echo("        Stop Protecting: "@%objt1);
DShield::StopProtecting(%objt1);
if(Player::GetClient(%objt1)!=-1) {
Client::sendMessage(Player::getClient(%objt1),1,"WARNING:  Shield flux failure!");
}
GameBase::applyDamage(%objt1,$CrushDamageType,0.15,GameBase::getPosition(%objt1),"0 0 0","0 0 0",%this);
}
deleteObject("MissionCleanup/CASimSet"@%this@"!"@%t);
}
function DShield::StartProtecting(%this) {
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::StartProtecting (%this)="@%this);
if(%this.shieldStrength<0.00) %this.shieldStrength=0.00;
%this.shieldStrength=$DShield::ShieldEnhance;
}
function DShield::StopProtecting(%this) {
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::StopProtecting (%this)="@%this);
%this.shieldStrength=0;
}
function DShield::onActivate(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::onActivate (%this)="@%this);
GameBase::playSequence(%this,0,"power");
}
function DShield::setActive(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::onActivate (%this)="@%this);
GameBase::playSequence(%this,0,"power");
}
function DShield::onDeactivate(%this)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::onDeactivate (%this)="@%this);
GameBase::stopSequence(%this,0);
playSound(SoundGeneratorPower,GameBase::getposition(%this));
}
function DShield::checkAreaCreateSimSet(%this,%t) {
%testset = nameToID("MissionCleanup/CASimSet"@%this@"!"@%t);
if(%testset == -1)
{
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::checkAreaCreateSimSet > Creating CASimSet"@%this@"!"@%t);
newObject("CASimSet"@%this@"!"@%t,SimSet);
addToSet("MissionCleanup","CASimSet"@%this@"!"@%t);
}
}
function DShield::removeFromSet(%set,%index,%t,%this) {
%nset=newObject("DSRFSREPLACE",SimSet);
for(%i=0;%i<Group::objectCount(%set);%i++) {
if(%i!=%index) {
addToSet(%nset,Group::GetObject(%set,%i));
}
}
deleteObject(%set);
DShield::checkAreaCreateSimSet(%this,%t);
for(%i=0;%i<Group::objectCount(%nset);%i++) {
addToSet(%set,Group::GetObject(%nset,%i));
}
deleteObject(%nset);
}
function DShield::checkArea(%this) {
%pos=GameBase::getPosition(%this);
if(%pos!="0 0 0") {
if(GameBase::getDamageState(%this)!="Enabled") {
schedule("DShield::checkArea("@%this@");",$DShield::TimerTick*6);
return;
}
%t=GameBase::getTeam(%this);
%testset=newObject("shieldtestset","SimSet");
%mask=$SimPlayerObjectType;
%intestset=containerBoxFillSet(%testset,%mask,%pos,$DShield::ProtectArea,$DShield::ProtectArea,$DShield::ProtectArea,0);
DShield::checkAreaCreateSimSet(%this,%t);
%casimset=nameToId("MissionCleanup/CASimSet"@%this@"!"@%t);
if(%testset==-1||%casimset==-1) {
deleteObject(%testset);
echo("ERROR in DShield::checkArea! (%testset="@%testset@" %casimset="@%casimset);
return;
}
%obc1=Group::objectCount("MissionCleanup/CASimSet"@%this@"!"@%t);
%obc2=Group::objectCount(%testset);
for(%i=0;%i<%obc2;%i++) {
%objt1=Group::getObject(%testset,%i);
if(GameBase::getTeam(%objt1)==GameBase::getTeam(%this)) {
for(%it=0;%it<%obc1+1;%it++) {
if(%it<%obc1) {
%objt2=Group::getObject("MissionCleanup/CASimSet"@%this@"!"@%t,%it);
if(%objt1==%objt2) {break;}
} else if((%this!=%objt1)&&%objt1.shieldStrength<0.0001) {
addToSet("MissionCleanup/CASimSet"@%this@"!"@%t,%objt1);
DShield::StartProtecting(%objt1);
if(Player::GetClient(%objt1)!=-1) {
Client::sendMessage(Player::getClient(%objt1),1,"Shield Energy System Enhanced.");
}
}
}
} else {
if(Player::getArmor(%objt1)=="infarmor"||Player::getArmor(%objt1)=="inffarmor") {
%t=getsimtime();
if(%t-%objt1.headachetime>3) {
if(%t-%objt1.headachetime>7) Client::sendMessage(Player::getClient(%objt1),1,"Your head throbs with pain!");
%objt1.headachetime=getsimtime();
Player::setDamageFlash(%objt1,Player::getDamageFlash(%objt1)+0.03);
GameBase::applyDamage(%objt1,$CrushDamageType,0.03,GameBase::getPosition(%objt1),"0 0 0","0 0 0",%this);
}
}
}
}
%lt=True; 
%lc=0; 
while(%lt&&lc<500) {
%lc++;
%lt=False;
%obc1=Group::objectCount("MissionCleanup/CASimSet" @%this@"!"@ %t);
%obc2=Group::objectCount(%testset);
%it=0;
for(%i=0;%i<%obc1;%i++) {
%objt1=Group::getObject("MissionCleanup/CASimSet"@%this@"!"@%t,%i);
for(%it=0;%it<%obc2+1;%it++) {
if(%it<%obc2) {
%objt2=Group::getObject(%testset,%it);
if(%objt1==%objt2) {break;}
} else {
DShield::StopProtecting(%objt1);
DShield::removeFromSet("MissionCleanup/CASimSet"@%this@"!"@%t,%i,%t,%this);
if(Player::GetClient(%objt1)!=-1) {
Client::sendMessage(Player::getClient(%objt1),1,"Shield Energy System returns to normal.");
}
%lt=True;
break;
}
}
if(%lt) break;
}
}
%obc1=Group::objectCount("MissionCleanup/CASimSet" @%this@"!"@ %t);
for(%i=0;%i<%obc1;%i++) {
%objt1=Group::getObject("MissionCleanup/CASimSet"@%this@"!"@%t,%i);
%e=GameBase::getEnergy(%this);
if(%e-$DShield::MaxCapCharge>0) {
%curenergy=GameBase::getEnergy(%objt1);
GameBase::setEnergy(%objt1,%curenergy+$DShield::MaxCapCharge);
if(%curenergy!=GameBase::getEnergy(%objt1)) {
GameBase::setEnergy(%this,GameBase::getEnergy(%this)-$DShield::MaxCapCharge);
}
}
}
deleteObject(%testset);
schedule("DShield::checkArea("@%this@");",$DShield::TimerTick);
}
else {
if($Tr::Debug) echo($DebugHeading::Tr @ "DShield::checkArea: (%this)=" @ %this @ " DESTROYED!");
}
}
