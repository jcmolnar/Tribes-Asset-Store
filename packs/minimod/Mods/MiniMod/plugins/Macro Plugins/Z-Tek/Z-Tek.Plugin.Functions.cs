// This is a MiniMod plugin.
// This is the PhaseLok+SheildGens Pack from the Z-Tek mod. Ported by Dewy.


$DShield::MaxCapCharge=4.0;
$DShield::TimerTick=0.25;
$DShield::ShieldEnhance=0.05;
$DShield::ProtectArea=150; 
$DShield::OverlapValue=0; 

function setAutoShutdown(%timer) {
schedule("quit();",(%timer*60));
if(%timer>5) schedule("setAutoShutdownWarning(5);",(%timer*60)-300);
if(%timer>4) schedule("setAutoShutdownWarning(4);",(%timer*60)-240);
if(%timer>3) schedule("setAutoShutdownWarning(3);",(%timer*60)-180);
if(%timer>2) schedule("setAutoShutdownWarning(2);",(%timer*60)-120);
if(%timer>1) schedule("setAutoShutdownWarning(1);",(%timer*60)-60);
messageall(1,"WARNING: SYSTEM SHUTDOWN IN "@%timer@" MINUTES!");
}
function setAutoShutdownWarning(%timer) {
if(%timer > 1) 
{messageall(1,"WARNING: SYSTEM SHUTDOWN IN "@%timer@" MINUTES!");}
else
{messageall(1,"WARNING: SYSTEM SHUTDOWN IN "@%timer@" MINUTE!");}
}
function warpplayer(%clientto,%clientfrom) {
%playerto=client::getownedobject(%clientto);
%playerfrom=client::getownedobject(%clientfrom);
if(%playerto!=-1&&%playerfrom!=-1) {
%posto=gamebase::getposition(%playerto);
%posto=Vector::add(%posto,"0 0 5");
gamebase::setposition(%playerfrom,%posto);
}
}
function tp(%clientlos,%clientfrom) {
%playerlos=client::getownedobject(%clientlos);
%playerfrom=client::getownedobject(%clientfrom);
if(%playerlos!=-1&&%playerfrom!=-1) { 
if(GameBase::getLOSInfo(%playerlos,5000)==True) {
%posto=$los::position;
%posto=Vector::add(%posto,"0 0 2");
gamebase::setposition(%playerfrom,%posto);
}
}
}
function demigodmode(%client) {
%player=client::getownedobject(%client);
if(%player!=-1) { 
GameBase::setRechargeRate(%player,10000);
GameBase::setAutoRepairRate(%player,10000);
%player.shieldStrength=0.05;
}
}
function agmall() {
}
function CheckDeployTerrain (%this) {
%obj=getObjectType(%this);
if( %obj == "SimTerrain" 
|| %obj == "InteriorShape" 
|| GameBase::getDataName(%this) == "DeployableBaseOps" 
|| GameBase::getDataName(%this)=="DeployablePlatform") {
return 1;
}
return 0;
}

function ZTekDebug() {
%DebugClient=2049;
%DebugObject=Client::getOwnedObject(2049);
echo("Player Data:");
echo("Client: 2049");
echo("Player Object:"@%DebugObject);
echo("Shields: "@%DebugObject.shieldStrength);
} 
function cto(%name,%shapefile) {
if(gamebase::getlosinfo(client::getownedobject(2049),50) == True) { 
%pos=Vector::add($los::position,"0 0 50");
instant InteriorShape %name {
filename=%shapefile;
iscontainer="1";
position=%pos;
rotation="0 0 0";
lightparams="0";
locked="0";
};
} 
}
function info() {
if(gamebase::getlosinfo(client::getownedobject(2049),5000)) {
echo("LOS Object: "@$los::object);
echo("LOS Position: "@$los::position);
echo("Object Data Name: "@GameBase::getDataName($los::object));
echo("Object Map Name: "@GameBase::getMapName($los::object));
echo("Object Position: "@GameBase::getPosition($los::object));
}
}
function purg(%clientid) {
gamebase::setposition(%clientid,DRifter::getRandomPos());
}
function tx(%clientid) {
%player=Client::getownedobject(%clientid);
%tx=GameBase::getMuzzleTransform(%player); 
for(%c=0;(%w[%c]=getword(%tx,%c))!=-1;%c++) {}
%c--;
echo("TX:  "@%c+1@" parameters.");
%ntx="";
for(%cc=0;%cc<%c;%cc+=3) {
echo("TX:      P"@%cc@": "@%w[%cc]@"   P"@%cc+1@": "@%w[%cc+1]@"   P"@%cc+2@": "@%w[%cc+2]);
if(%cc!=0 && %cc!=6) %ntx=%ntx@%w[%cc]@" "@%w[%cc+1]@" "@%w[%cc+2]@" ";
else %ntx=%ntx@"0 0 0 ";
}
echo("TXNew: "@%ntx);
Projectile::spawnProjectile("FusionBolt",%ntx,%player,0);
}
function tf() {
if(gamebase::getlosinfo(client::getownedobject(2049),5000)) {
%pos=GameBase::getPosition($los::object);
%tx=GameBase::getMuzzleTransform($los::object); 
%ws[0]="";
%ws[1]="";
%ws[2]="";
%ws[3]="";
for(%c=0;(%w[%c]=getword(%tx,%c))!=-1;%c++) {
if(%c>=0 && %c<=2) {
%ws[0]=%ws[0]@%w[%c]@" ";
}
if(%c>=3 && %c<=5) {
%ws[1]=%ws[1]@%w[%c]@" ";
}
if(%c>=6 && %c<=8) {
%ws[2]=%ws[2]@%w[%c]@" ";
}
if(%c>=9 && %c<=11) {
%ws[3]=%ws[3]@%w[%c]@" ";
}
}
%pos=Vector::add(%pos,"0 1 1");
%tran="0 0 0 "@%ws[3]@"0 0 0 "@%pos;
Projectile::spawnProjectile("FusionBolt",%tran,$los::object,0);
echo("TRAN: "@%tran);
}
}

function DShield::onDestroyed(%this)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onDestroyed: (%this)=" @ %this);
DShield::onDisabled(%this);
CalcRadiusDamage(%this,$DebrisDamageType,20,0.1,25,20,3,3,0.1,200,100);
$TeamItemCount[GameBase::getTeam(%this) @ "DShield"]--;
%teleset = nameToID("MissionCleanup/Teleports");
}
function DShieldPack::onUse(%player,%item)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onUse: (%player)=" @ %player @ " (%item)=" @ %item);
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function DShieldPack::onDeploy(%player,%item,%pos)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onDeploy: (%player)=" @ %player @ " (%item)=" @ %item @ "(%pos)=" @ %pos);
if (DShieldPack::deployShape(%player,"Shield Generator",DShield,%item)) {
Player::decItemCount(%player,%item);
$TeamItemCount[GameBase::getTeam(%player) @ "DShield"]++;
}
}
function CreateDShieldSimSet(%this)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::CreateDShieldSimSet");
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
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::deployShape: (%player)=" @ %player @ "(%name)=" @ %name @ "(%shape)=" @ %shape @ "(%item)=" @ %item);
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
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::deployShape: (%sensor)=" @ %sensor);
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
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onEnabled (%this)="@%this);
DShield::setActive(%this,true);
}
function DShield::onDisabled(%this)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onDisabled (%this)="@%this);
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
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::StartProtecting (%this)="@%this);
if(%this.shieldStrength<0.00) %this.shieldStrength=0.00;
%this.shieldStrength=$DShield::ShieldEnhance;
}
function DShield::StopProtecting(%this) {
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::StopProtecting (%this)="@%this);
%this.shieldStrength=0;
}
function DShield::onActivate(%this)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onActivate (%this)="@%this);
GameBase::playSequence(%this,0,"power");
}
function DShield::setActive(%this)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onActivate (%this)="@%this);
GameBase::playSequence(%this,0,"power");
}
function DShield::onDeactivate(%this)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::onDeactivate (%this)="@%this);
GameBase::stopSequence(%this,0);
playSound(SoundGeneratorPower,GameBase::getposition(%this));
}
function DShield::checkAreaCreateSimSet(%this,%t) {
%testset = nameToID("MissionCleanup/CASimSet"@%this@"!"@%t);
if(%testset == -1)
{
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::checkAreaCreateSimSet > Creating CASimSet"@%this@"!"@%t);
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
if($ZTek::Debug) echo($DebugHeading::ZTek @ "DShield::checkArea: (%this)=" @ %this @ " DESTROYED!");
}
}

function PhaseLokPack::onUse(%player,%item)
{
if($Debug::ZTek) echo($DebugHeading::ZTek @ "PhaseLokPack::onUse: (%player)=" @ %player @ " (%item)=" @ %item);
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}
function PhaseLokPack::onDeploy(%player,%item,%pos)
{
if($Debug::ZTek) echo($DebugHeading::ZTek @ "PhaseLokPack::onDeploy: (%player)=" @ %player @ " (%item)=" @ %item @ " (%pos)=" @ %pos);
if (PhaseLokPack::deployShape(%player,%item)) {
Player::decItemCount(%player,%item);
}
}
function PhaseLokPack::deployShape(%player,%item)
{
if($Debug::ZTek) echo($DebugHeading::ZTek @ "PhaseLokPack::deployShape: (%player)=" @ %player @ " (%item)=" @ %item);
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
function DeployablePhaseLok::onAdd(%this)
{
if($Debug::ZTek) echo($DebugHeading::ZTek @ "DeployablePhaseLok::onAdd: (%this)=" @ %this);
schedule("DeployablePhaseLok::deploy(" @ %this @ ");",1,%this);
%this.shieldStrength = 0;
if (GameBase::getMapName(%this) == "") {
GameBase::setMapName (%this, "Remote PhaseLok");
}
}
function DeployablePhaseLok::deploy(%this)
{
if($Debug::ZTek) echo($DebugHeading::ZTek @ "DeployablePhaseLok::deploy: (%this)=" @ %this);
GameBase::playSequence(%this,1,"deploy");
GameBase::setRechargeRate(%this,50);
}
function DeployablePhaseLok::onEndSequence(%this,%thread)
{
if($Debug::ZTek) echo($DebugHeading::ZTek @ "DeployablePhaseLok::onEndSequence: (%this)=" @ %this @ " (%thread)=" @ %thread);
GameBase::setActive(%this,true);
%this.shieldStrength = 0.0;
}
function DeployablePhaseLok::onDestroyed(%this)
{
if($Debug::ZTek) echo($DebugHeading::ZTek @ "DeployablePhaseLok::onDestroyed: (%this)=" @ %this);
Turret::onDestroyed(%this);
$TeamItemCount[GameBase::getTeam(%this) @ "PhaseLokAmmo"]--;
}
function DeployablePhaseLok::onPower(%this,%power,%generator) {}
function DeployablePhaseLok::onEnabled(%this) 
{
if($Debug::ZTek) echo($DebugHeading::ZTek @ "DeployablePhaseLok::onEnabled: (%this)=" @ %this);
GameBase::setRechargeRate(%this,5);
GameBase::setActive(%this,true);
} 
function DeployablePhaseLok::verifyTarget(%target, %this) //(%this, %target)
{
return "True";
}

