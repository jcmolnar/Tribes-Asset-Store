$PlayerAnim::Crouching = 25;
$PlayerAnim::DieChest = 26;
$PlayerAnim::DieHead = 27;
$PlayerAnim::DieGrabBack = 28;
$PlayerAnim::DieRightSide = 29;
$PlayerAnim::DieLeftSide = 30;
$PlayerAnim::DieLegLeft = 31;
$PlayerAnim::DieLegRight = 32;
$PlayerAnim::DieBlownBack = 33;
$PlayerAnim::DieSpin = 34;
$PlayerAnim::DieForward = 35;
$PlayerAnim::DieForwardKneel = 36;
$PlayerAnim::DieBack = 37;
$CorpseTimeoutValue = 22;
function Player::onAdd(%this)
{
GameBase::setRechargeRate(%this,8);
}
function Player::onRemove(%this)
{
for (%i = 0; %i < 8; %i = %i + 1) {
%type = Player::getMountedItem(%this,%i);
if (%type != -1) {
%item = newObject("","Item",%type,1,false);
schedule("Item::Pop(" @ %item @ ");", $ItemPopTime, %item);
addToSet("MissionCleanup", %item);
GameBase::setPosition(%item,GameBase::getPosition(%this));
}
}
}
function Player::onNoAmmo(%player,%imageSlot,%itemType)
{
}
function Player::onKilled(%this)
{
%cl = GameBase::getOwnerClient(%this);
%cl.dead = 1;
if($AutoRespawn > 0)
schedule("Game::autoRespawn(" @ %cl @ ");",$AutoRespawn,%cl);
if(%this.outArea==1) 
leaveMissionAreaDamage(%cl);
Player::setDamageFlash(%this,0.75);
for (%i = 0; %i < 8; %i = %i + 1) {
%type = Player::getMountedItem(%this,%i);
if (%type != -1) {
if (%i != $WeaponSlot || !Player::isTriggered(%this,%i) || getRandom() > "0.5") 
Player::dropItem(%this,%type);
}
}
if(%cl != -1)
{
if(%this.vehicle != "") {
if(%this.driver != "") {
%this.driver = "";
Client::setControlObject(Player::getClient(%this), %this);
Player::setMountObject(%this, -1, 0);
}
else {
%this.vehicle.Seat[%this.vehicleSlot-2] = "";
%this.vehicleSlot = "";
}
%this.vehicle = ""; 
}
schedule("GameBase::startFadeOut(" @ %this @ ");", $CorpseTimeoutValue, %this);
Client::setOwnedObject(%cl, -1);
Client::setControlObject(%cl, Client::getObserverCamera(%cl));
Observer::setOrbitObject(%cl, %this, 5, 5, 5);
schedule("deleteObject(" @ %this @ ");", $CorpseTimeoutValue + 2.5, %this);
%cl.observerMode = "dead";
%cl.dieTime = getSimTime();
}
}
function Player::onDamage(%this,%type,%value,%pos,%vec,%mom,%vertPos,%quadrant,%object)
{
if (Player::isExposed(%this)) {
%damagedClient = Player::getClient(%this);
%shooterClient = %object;
if(player::getmounteditem(%object,$WeaponSlot)=="GravGun") %type=$GravityBoltDamageType;
if(player::getmounteditem(%object,$WeaponSlot)=="AntiGravGun") %type=$AntiGravityBoltDamageType;
Player::applyImpulse(%this,%mom);
if($teamplay && %damagedClient != %shooterClient && Client::getTeam(%damagedClient) == Client::getTeam(%shooterClient) ) {
if (%shooterClient != -1) {
%curTime = getSimTime();
if (((%curTime - %this.DamageTime > 3.5 || %this.LastHarm != %shooterClient) && %damagedClient != %shooterClient && $Server::TeamDamageScale > 0)&&%type!=$GravityBoltDamageType&&%type!=$AntiGravityBoltDamageType) {
if(%type != $MineDamageType) {
Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ "!");
Client::sendMessage(%damagedClient,0,"You took Friendly Fire from " @ Client::getName(%shooterClient) @ "!");
}
else {
Client::sendMessage(%shooterClient,0,"You just harmed Teammate " @ Client::getName(%damagedClient) @ " with your mine!");
Client::sendMessage(%damagedClient,0,"You just stepped on Teamate " @ Client::getName(%shooterClient) @ "'s mine!");
}
%this.LastHarm = %shooterClient;
%this.DamageStamp = %curTime;
}
}
%friendFire = $Server::TeamDamageScale;
}
else if(%type == $ImpactDamageType && Client::getTeam(%object.clLastMount) == Client::getTeam(%damagedClient)) 
%friendFire = $Server::TeamDamageScale;
else 
%friendFire = 1.0; 
if (!Player::isDead(%this)) {
%armor = Player::getArmor(%this);
if(%type==$DimensionalRift) { 
if(($Server::TeamDamageScale > 0 && (GameBase::getTeam(%shooterClient)==GameBase::getTeam(%damagedClient)))
||(GameBase::getTeam(%shooterClient)!=GameBase::getTeam(%damagedClient))||%shooterClient==%damagedClient) { 
%type=$EnergyDamageType;
if(getSimTime()-%damagedClient.lastRiftTime>21 && %armor!="predarmor"&&%armor!="predfarmor") {
DRifter::testPurgatory();
%damagedClient.lastRiftTime=getSimTime();
if(%shooterClient!=%damagedClient) {
Client::sendMessage(%shooterClient,0,"You just sent "@Client::getName(%damagedClient)@" elsewhere.");
Client::sendMessage(%damagedClient,1,Client::getName(%shooterClient)@" sent you purgatory.  Welcome to hell!");
} else {
Client::sendMessage(%damagedClient,2,"Purgatory, Layover to hell...  Welcome.");
}
%damagedClient.OriginalVec=GameBase::getPosition(%damagedClient);
%tele=DRifter::getRandomPos();
GameBase::setPosition(%damagedClient,%tele);
Item::setVelocity(%damagedClient,"0 0 0");
schedule("Item::setVelocity("@%damagedClient@",\"0 0 0\");",7);
schedule("GameBase::setPosition("@Client::getOwnedObject(%damagedClient)@",\""@%damagedClient.OriginalVec@"\");",7.01);
schedule("Client::sendMessage("@%damagedClient@",0,\"Your body feels whole again.\");",7.01);
schedule("Client::sendMessage("@%damagedClient@",0,\"You are immune for 15 seconds.\");",7.01);
}
}
}
if(%type==$GravityBoltDamageType) {
%impRot=GameBase::getRotation(%object);
%impRot=Vector::add(%impRot,"3.14159 3.14159 0");
%impX=getWord(%impRot,0);
%impY=getWord(%impRot,1);
%impZ=getWord(%impRot,2);
%sourcePos=GameBase::getPosition(%object);
%movePos=GameBase::getPosition(%this);
%Zsrc=getWord(%sourcePos,2);
%Zmv=getWord(%movePos,2);
%diffPos=%Zsrc-%Zmv;
%zDir=%diffPos;
%pushLen=15;
if(%armor=="dreadarmor") %pushLen=%pushLen/1.5;
%ZPullMod=2;
if(%armor=="dreadarmor") %ZPullMod=1.5;
%impVec=Vector::getFromRot(%impRot,%pushLen,%zDir*2);
Player::applyImpulse(%damagedClient,%impVec);
return;
}
if(%type==$AntiGravityBoltDamageType) {
%impRot=GameBase::getRotation(%object);
%impRot=Vector::add(%impRot,"0 3.14159 0");
%impX=getWord(%impRot,0);
%impY=getWord(%impRot,1);
%impZ=getWord(%impRot,2);
%sourcePos=GameBase::getPosition(%object);
%movePos=GameBase::getPosition(%this);
%Zsrc=getWord(%sourcePos,2);
%Zmv=getWord(%movePos,2);
%diffPos=%Zsrc-%Zmv;
%zDir=%diffPos;
%pushLen=15;
if(%armor=="dreadarmor") %pushLen=%pushLen/1.5;
%impVec=Vector::getFromRot(%impRot,%pushLen,%zDir);
Player::applyImpulse(%damagedClient,%impVec);
return;
}
if(%type==$NaniteBurstDamageType && %value>$NaniteDamageLevel+0.05) {
if(%this.NaniteLevel<1) { 
if(($Server::TeamDamageScale > 0 && (GameBase::getTeam(%shooterClient)==GameBase::getTeam(%damagedClient)))
||(GameBase::getTeam(%shooterClient)!=GameBase::getTeam(%damagedClient))||%shooterClient==%damagedClient) {
%this.NaniteLevel++;
NaniteBurst::Infection(%this,%object,$NaniteDamageTimes);
}
}
}
if(%type==$EMPDamageType) {
if(%this.EMPLevel<1) { 
if(($Server::TeamDamageScale > 0 && (GameBase::getTeam(%shooterClient)==GameBase::getTeam(%damagedClient)))
||(GameBase::getTeam(%shooterClient)!=GameBase::getTeam(%damagedClient))||%shooterClient==%damagedClient) {
%this.EMPLevel++;
Disruptor::EnergyDrain(%this,%object,$EMPDamageTime);
%this.EMPRecharge=GameBase::getRechargeRate(%this);
GameBase::setRechargeRate(%this,0);
GameBase::setEnergy(%this,0);
Client::sendMessage(%damagedClient,1,"Your energy system is short circuited!");
}
}
}
if(%vertPos == "head" && (%type == $LaserDamageType||%type==$NaniteBurstDamageType)) {
if(%armor == "harmor") { 
if(%quadrant == "middle_back" || %quadrant == "middle_front" || %quadrant == "middle_middle") {
%value += (%value * 0.3);
}
}
else {
%value += (%value * 0.3);
}
}
if (%type != -1 && %this.shieldStrength) {
%energy = GameBase::getEnergy(%this);
%strength = %this.shieldStrength;
if (%type == $ShrapnelDamageType || %type == $MortarDamageType)
%strength *= 0.75;
%absorb = %energy * %strength;
if (%value < %absorb) {
GameBase::setEnergy(%this,%energy - ((%value /%strength)*%friendFire));
%thisPos = getBoxCenter(%this);
%offsetZ =((getWord(%pos,2))-(getWord(%thisPos,2)));
GameBase::activateShield(%this,%vec,%offsetZ);
%value = 0;
}
else {
GameBase::setEnergy(%this,0);
%value = %value - %absorb;
}
}
if (%value) {
%value = $DamageScale[%armor, %type] * %value * %friendFire;
%dlevel = GameBase::getDamageLevel(%this) + %value;
%spillOver = %dlevel - %armor.maxDamage;
GameBase::setDamageLevel(%this,%dlevel);
%flash = Player::getDamageFlash(%this) + %value * 2;
if (%flash > 0.75) 
%flash = 0.75;
Player::setDamageFlash(%this,%flash);
if(!Player::isDead(%this)) { 
if(%damagedClient.lastDamage < getSimTime()) {
%sound = radnomItems(3,injure1,injure2,injure3);
playVoice(%damagedClient,%sound);
%damagedClient.lastdamage = getSimTime() + 1.5;
}
}
else {
if(%spillOver > 0.5 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType|| %type == $MissileDamageType)) {
Player::trigger(%this, $WeaponSlot, false);
%weaponType = Player::getMountedItem(%this,$WeaponSlot);
if(%weaponType != -1)
Player::dropItem(%this,%weaponType);
Player::blowUp(%this);
}
else
{
if ((%value > 0.40 && (%type== $ExplosionDamageType || %type == $ShrapnelDamageType || %type== $MortarDamageType || %type == $MissileDamageType )) || (Player::getLastContactCount(%this) > 6) ) {
if(%quadrant == "front_left" || %quadrant == "front_right") 
%curDie = $PlayerAnim::DieBlownBack;
else
%curDie = $PlayerAnim::DieForward;
}
else if( Player::isCrouching(%this) ) 
%curDie = $PlayerAnim::Crouching; 
else if(%vertPos=="head") {
if(%quadrant == "front_left" || %quadrant == "front_right" ) 
%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieBack);
else 
%curDie = radnomItems(2, $PlayerAnim::DieHead, $PlayerAnim::DieForward);
}
else if (%vertPos == "torso") {
if(%quadrant == "front_left" ) 
%curDie = radnomItems(3, $PlayerAnim::DieLeftSide, $PlayerAnim::DieChest, $PlayerAnim::DieForwardKneel);
else if(%quadrant == "front_right") 
%curDie = radnomItems(3, $PlayerAnim::DieChest, $PlayerAnim::DieRightSide, $PlayerAnim::DieSpin);
else if(%quadrant == "back_left" ) 
%curDie = radnomItems(4, $PlayerAnim::DieLeftSide, $PlayerAnim::DieGrabBack, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
else if(%quadrant == "back_right") 
%curDie = radnomItems(4, $PlayerAnim::DieGrabBack, $PlayerAnim::DieRightSide, $PlayerAnim::DieForward, $PlayerAnim::DieForwardKneel);
}
else if (%vertPos == "legs") {
if(%quadrant == "front_left" || %quadrant == "back_left") 
%curDie = $PlayerAnim::DieLegLeft;
if(%quadrant == "front_right" || %quadrant == "back_right") 
%curDie = $PlayerAnim::DieLegRight;
}
Player::setAnimation(%this, %curDie);
}
if(%type == $ImpactDamageType && %object.clLastMount != "") 
%shooterClient = %object.clLastMount;
Client::onKilled(%damagedClient,%shooterClient, %type);
}
}
}
}
}
function radnomItems(%num, %an0, %an1, %an2, %an3, %an4, %an5, %an6)
{
return %an[floor(getRandom() * (%num - 0.01))];
}
function Player::onCollision(%this,%object)
{
if (Player::isDead(%this)) {
if (getObjectType(%object) == "Player") {
%sound = false;
%max = getNumItems();
for (%i = 0; %i < %max; %i = %i + 1) {
%count = Player::getItemCount(%this,%i);
if (%count) {
%delta = Item::giveItem(%object,getItemData(%i),%count);
if (%delta > 0) {
Player::decItemCount(%this,%i,%delta);
%sound = true;
}
}
}
if (%sound) {
playSound(SoundPickupItem,GameBase::getPosition(%this));
}
}
} else {
if(GameBase::getTeam(%this)!=GameBase::getTeam(%object)) {
if(GameBase::getDataName(%object)=="solarmor"||GameBase::getDataName(%object)=="solfarmor") {
if(getSimTime()-%this.lastslaptime>1) {
%thiscl=Player::getClient(%this);
%objectcl=Player::getClient(%object);
if(%thiscl!=-1&&%objectcl!=-1) {
if(GameBase::getLOSInfo(%object,3)) {
%obj = getObjectType($los::object);
if(%obj=="Player") {
echo("LOSOBJECT: "@%obj);
playSound(SoundSoldierThump,GameBase::getPosition(%this));
Client::SendMessage(%thiscl,1,Client::getName(%objectcl)@" just bitch-slapped you.");
GameBase::applyDamage(%this,$CrushDamageType,0.20,GameBase::getPosition(%this),"0 0 0","0 0 0",%object);
Client::SendMessage(%objectcl,0,"You just bitch-slapped "@Client::getName(%thiscl)@"!");
%this.lastslaptime=getSimTime();
}
}
}
}
}
}
}
}
function Player::getHeatFactor(%this)
{
%client = Player::getClient(%this);
if (Client::getControlObject(%client) != %this)
return 1.0;
%time = getIntegerTime(true) >> 5;
%lastTime = Player::lastJetTime(%this) >> 10;
if ((%lastTime + 1.5) < %time) {
return 0.0;
} else {
%diff = %time - %lastTime;
%heat = 1.0 - (%diff /1.5);
if(Player::getMountedItem(%this,$BackPackSlot)=="IntercoolerPack") %heat/=2;
return %heat;
}
}
function Player::jump(%this,%mom)
{
%cl = GameBase::getControlClient(%this);
if(%cl != -1)
{
%vehicle = Player::getMountObject (%this);
%this.lastMount = %vehicle;
%this.newMountTime = getSimTime() + 3.0;
Player::setMountObject(%this, %vehicle, 0);
Player::setMountObject(%this, -1, 0);
Player::applyImpulse(%pl,%mom);
playSound (GameBase::getDataName(%this).dismountSound, GameBase::getPosition(%this));
}
}
function remoteKill(%client)
{
if(!$matchStarted)
return;
%player = Client::getOwnedObject(%client);
if(%player != -1 && getObjectType(%player) == "Player" && !Player::isDead(%player))
{
playNextAnim(%client);
Player::kill(%client);
Client::onKilled(%client,%client);
}
}
$animNumber = 25; 
function playNextAnim(%client)
{
if($animNumber > 36) 
$animNumber = 25; 
Player::setAnimation(%client,$animNumber++);
}
function Client::takeControl(%clientId, %objectId)
{
if(%objectId == -1)
{
return;
}
%pl = Client::getOwnedObject(%clientId);
if(%pl.driver != ""|| %pl.vehicleSlot != "")
return;
if(GameBase::getTeam(%objectId) != Client::getTeam(%clientId))
{
return;
}
if(GameBase::getControlClient(%objectId) != -1)
{
echo("Ctrl Client = " @ GameBase::getControlClient(%objectId));
return;
}
%name = GameBase::getDataName(%objectId);
if(%name != CameraTurret && %name != DeployableTurret && %name != DeployableRocketTurret)
{
if(!GameBase::isPowered(%objectId)) 
{
return;
}
}
if(!(Client::getOwnedObject(%clientId)).CommandTag && GameBase::getDataName(%objectId) != CameraTurret &&
!$TestCheats) {
Client::SendMessage(%clientId,0,"Must be at a Command Station to control turrets");
return;
}
if(GameBase::getDamageState(%objectId) == "Enabled") {
Client::setControlObject(%clientId, %objectId);
Client::setGuiMode(%clientId, $GuiModePlay);
}
}
function remoteCmdrMountObject(%clientId, %objectIdx)
{
Client::takeControl(%clientId, getObjectByTargetIndex(%objectIdx));
}
function checkControlUnmount(%clientId)
{
%ownedObject = Client::getOwnedObject(%clientId);
%ctrlObject = Client::getControlObject(%clientId);
if(%ownedObject != %ctrlObject)
{
if(%ownedObject == -1 || %ctrlObject == -1)
return;
if(getObjectType(%ownedObject) == "Player" && Player::getMountObject(%ownedObject) == %ctrlObject)
return;
Client::setControlObject(%clientId, %ownedObject);
}
}
