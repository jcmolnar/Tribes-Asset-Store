$InvList[HealingTurret] = 1; 
$RemoteInvList[HealingTurret] = 1; 
$TeamItemMax[Healingturret] = 13;
//############### 
//############### 
$ItemMax[larmor, HealingTurret] = 0; 
$ItemMax[lfemale, HealingTurret] = 0; 
$ItemMax[marmor, HealingTurret] = 1; 
$ItemMax[mfemale, HealingTurret] = 1; 
$ItemMax[harmor, HealingTurret] = 0; 
//###############
ItemImageData HealingTurretImage
{
	shapeFile = "discammo";
	mountPoint = 2;
	mountOffset = { 0, -0.12, -0.1 };
	mountRotation = { 0, 0, 0 };
	mass = 2.5;
	firstPerson = false;
};

ItemData HealingTurret
{
	description = "Healing Turret";
	shapeFile = "remoteturret";
	className = "Backpack";
   	heading = "jTurret";
	imageType = ProtonTurretImage;
	shadowDetailMask = 4;
	mass = 2.0;
	elasticity = 0.2;
	price = 600;
	hudIcon = "deployable";
	showWeaponBar = true;
	hiliteOnActive = true;
};

function HealingTurret::onUse(%player,%item)
{
if (Player::getMountedItem(%player,$BackpackSlot) != %item) {
Player::mountItem(%player,%item,$BackpackSlot);
}
else {
Player::deployItem(%player,%item);
}
}

function HealingTurret::onDeploy(%player,%item,%pos)
{
if (HealingTurret::deployShape(%player,%item)) {
Player::decItemCount(%player,%item);
}
}

function HealingTurret::deployShape(%player,%item)
{
%client = Player::getClient(%player);
if($TeamItemCount[GameBase::getTeam(%player) @ %item] < $TeamItemMax[%item]) {
if (GameBase::getLOSInfo(%player,3)) {
		
%Set = newObject("set",SimSet);
%Mask = $StaticObjectType;
%num =containerBoxFillSet(%Set, %Mask, $los::position, 150, 150, 150,0);
for(%i; %i < %num; %i++)
{
%thing = Group::getObject(%Set, %i);
if(GameBase::getTeam(%thing) == GameBase::getTeam(%player))
{
%inbase= true;
break;
}
}
deleteObject(%Set);
if(%inbase)
{
%obj = getObjectType($los::object);
if (%obj == "SimTerrain" || %obj == "InteriorShape") {
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
%turret = newObject("remoteTurret","Turret",HealingTurretS,true);
addToSet("MissionCleanup", %turret);
GameBase::setTeam(%turret,GameBase::getTeam(%player));
GameBase::setRotation(%turret,%rot);
GameBase::setPosition(%turret,$los::position);
Gamebase::setMapName(%turret,"Healing Turret#"@ $totalNumTurrets++ @ " " @ Client::getName(%client));
Client::sendMessage(%client,0,"Healing turret Deployed");
playSound(SoundPickupBackpack,$los::position);
$TeamItemCount[GameBase::getTeam(%turret) @ "HealingTurret"]++;
echo("MSG: ",%client," deployed a Mini Devestator Turret");
Client::setOwnedObject(%client, %turret); 
Client::setOwnedObject(%client, %player);
return true;
}
}
else {
Client::sendMessage(%client,0,"Can only deploy on terrain or buildings");
}
}
		
else
				                                         
				                                        
bottomprint(%client, "Fair play distance exceeded for " @ %item.description @ "s", 3);
}
else {
Client::sendMessage(%client,0,"Deploy position out of range");		
}
}
else																						  
Client::sendMessage(%client,0,"Deployable Item limit reached for " @ %item.description @ "s");
	
return false;
}

//############################################
//Place in Turret.cs

TurretData HealingTurretS
{
	className = "Turret";
	shapeFile = "indoorgun";
   	validateShape = true;
   	validateMaterials = true;
	projectileType = HealingturretShell;
	maxDamage = 3;
	maxEnergy = 500;
	minGunEnergy = 6;
	maxGunEnergy = 5;
	sequenceSound[0] = { "deploy", SoundActivateMotionSensor };
	reloadDelay = 0.08;
	speed = 2;
	speedModifier = 2;
	range = 100;
	visibleToSensor = true;
	shadowDetailMask = 0;
	dopplerVelocity = 0;
	castLOS = true;
	supression = false;
	mapFilter = 2;
	mapIcon = "M_turret";
	debrisId = flashDebrisMedium;
	shieldShapeName = "shield";
	fireSound = SoundRemoteTurretFire;
	activationSound = SoundRemoteTurretOn;
	deactivateSound = SoundRemoteTurretOff;
	explosionId = flashExpMedium;
	description = "Healing Turret";
	damageSkinData = "objectDamageSkins";
};

function HealingTurretS::onAdd(%this)
{
	schedule("HealingTurretS::deploy(" @ %this @ ");",1,%this);
	GameBase::setRechargeRate(%this,5);
	%this.shieldStrength = 0;
	if (GameBase::getMapName(%this) == "") {
		GameBase::setMapName (%this, "Healing Turret");
	}
}

function HealingTurretS::deploy(%this)
{
	GameBase::playSequence(%this,1,"deploy");
}

function HealingTurretS::onEndSequence(%this,%thread)
{
	GameBase::setActive(%this,true);
}

function HealingTurretS::onDestroyed(%this)
{
	Turret::onDestroyed(%this);
  	$TeamItemCount[GameBase::getTeam(%this) @ "HealingTurret"]--;
}

function HealingTurretS::onPower(%this,%power,%generator) {}
function HealingTurretS::onEnabled(%this) 
{
	GameBase::setRechargeRate(%this,5);
	GameBase::setActive(%this,true);
}	

//############################################
